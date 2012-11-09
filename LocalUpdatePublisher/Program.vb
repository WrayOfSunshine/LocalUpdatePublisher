' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' Program
' This module is the beginning of the program.  It loads the settings
' from the settings file.  It prompts the user for connection info if
' none was found.  Lastly, it loads the main form.
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 10/30/2009
' Time: 7:54 AM
'
'The icons for this project are licensed under the LGPL and
' can be found here: http://www.everaldo.com/crystal.

Imports System.Net
Imports System.Diagnostics
Imports System.Security.Permissions
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.UpdateServices.Administration
Imports System.Resources
Imports System.Reflection
Imports System.Threading
Imports System.Globalization

Namespace My
    ' This file controls the behavior of the application.

    Partial Class MyApplication

        Public Sub New()

            MyBase.New(AuthenticationMode.Windows)

            Me.IsSingleInstance = False
            Me.EnableVisualStyles = True
            Me.SaveMySettingsOnExit = False ' MySettings are not supported in SharpDevelop.
            Me.ShutdownStyle = ShutdownMode.AfterMainFormCloses

        End Sub 'New

        <SecurityPermission(SecurityAction.Demand, Flags:=SecurityPermissionFlag.ControlAppDomain)> _
        Private Sub Main( _
            ByVal sender As Object, _
            ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs _
            ) Handles Me.Startup


            ' Add the event handler for handling non-UI thread exceptions to the event.
            AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf CurrentDomain_UnhandledException


            'Initialize and load the settings.						
            Globals.appSettings = New Settings()
            Globals.appSettings = LocalUpdatePublisher.Settings.LoadSettingsFromFile

            'Set default scope based on the app settings.
            Globals.localUpdatesScope = New UpdateScope()
            If Globals.appSettings.HideOfficialUpdates Then
                Globals.localUpdatesScope.UpdateSources = UpdateSources.Other 'Show non-Microsoft updates
            End If

            System.Net.ServicePointManager.Expect100Continue = False

            'Initialize the global resource handler
            Thread.CurrentThread.CurrentCulture = New CultureInfo(Globals.appSettings.Culture)
            Thread.CurrentThread.CurrentUICulture = New CultureInfo(Globals.appSettings.Culture)
            Globals.globalRM = New ResourceManager("LocalUpdatePublisher.GlobalStrings", Assembly.GetExecutingAssembly())

            'Load server connections.
            ConnectionManager.LoadServerList()

            'If any arguments were passed run in batch mode.
            If My.Application.CommandLineArgs.Count > 0 Then


                'At the minimum we need 2 arguments to run any of the reports.
                If My.Application.CommandLineArgs.Count >= 3 AndAlso _
                    Not String.IsNullOrEmpty(My.Application.CommandLineArgs(1)) AndAlso _
                    Not String.IsNullOrEmpty(My.Application.CommandLineArgs(2)) Then

                    Dim serverName As String = My.Application.CommandLineArgs(1)
                    Dim outputFile As String = My.Application.CommandLineArgs(2)

                    'Find and connect to server.
                    For Each tmpServer As UpdateServer In ConnectionManager.ServerCollection
                        If tmpServer.Name = serverName Then
                            ConnectionManager.Connect(tmpServer)
                        End If
                    Next

                    'If we're not connected, try the child servers.
                    Dim foundServer As Boolean = False
                    If Not ConnectionManager.Connected Then

                        'Loop through each saved server.
                        For Each tmpParentServer As UpdateServer In ConnectionManager.ServerCollection
                            ConnectionManager.Connect(tmpParentServer) ' Connect to each parent server.

                            'Loop through each child server.
                            For Each childServer As IUpdateServer In ConnectionManager.CurrentServer.GetChildServers

                                'If a child server with the correct name is found.
                                If childServer.Name = serverName Then
                                    foundServer = True 'Set found boolean.

                                    'Connect to child server.
                                    ConnectionManager.Connect(New UpdateServer(childServer.Name, childServer.PortNumber, childServer.IsConnectionSecureForApiRemoting, True, childServer.GetConfiguration.IsReplicaServer))
                                    Exit For 'Exit the child servers loop.
                                End If
                            Next

                            'If a child server was found then exit the parent server loop as well.
                            If foundServer Then Exit For
                        Next
                    End If 'Not connected.

                    'Make sure we are connected.
                    If ConnectionManager.Connected Then

                        Select Case My.Application.CommandLineArgs(0).ToLower
                            Case "-gr" 'Group Report

                                Dim groupName As String = ""
                                Dim status As String = ""

                                'If a group name was passed, set it here.
                                'Otherwise, default to the All Computers group.
                                If My.Application.CommandLineArgs.Count >= 4 AndAlso _
                                    Not String.IsNullOrEmpty(My.Application.CommandLineArgs(3)) Then
                                    groupName = My.Application.CommandLineArgs(3)
                                Else
                                    groupName = ConnectionManager.CurrentServer.GetComputerTargetGroup(ComputerTargetGroupId.AllComputers).Name
                                End If

                                'If a status was passed, set it here.
                                If My.Application.CommandLineArgs.Count >= 5 AndAlso _
                                    Not String.IsNullOrEmpty(My.Application.CommandLineArgs(4)) Then
                                    status = My.Application.CommandLineArgs(4)
                                End If

                                'Find the group based on its name.
                                Dim foundGroup As IComputerTargetGroup = Nothing
                                Dim tmpGroupCollection As ComputerTargetGroupCollection = ConnectionManager.ParentServer.GetComputerTargetGroups
                                For Each tmpGroup As IComputerTargetGroup In tmpGroupCollection
                                    If UCase(tmpGroup.Name) = UCase(groupName) Then
                                        foundGroup = tmpGroup
                                    End If
                                Next

                                'If the group wasn't found, error out.
                                If foundGroup Is Nothing Then
                                    LogError(String.Format(Globals.globalRM.GetString("error_command_find_group"), groupName))
                                Else 'Group was found.

                                    'Export the data, using the status if one was passed in.
                                    If status Is Nothing Then
                                        DataRoutines.ExportData(DataRoutines.GetComputerList(foundGroup), outputFile)
                                    Else
                                        DataRoutines.ExportData(DataRoutines.GetComputerList(foundGroup, status), outputFile)
                                    End If
                                End If

                            Case "-cr"
                                'We need at least 4 arguments for this report.
                                If My.Application.CommandLineArgs.Count >= 4 AndAlso _
                                    Not String.IsNullOrEmpty(My.Application.CommandLineArgs(3)) Then

                                    Dim computerName As String = My.Application.CommandLineArgs(3)
                                    Dim status As String = ""

                                    'If a status was passed, set it here.
                                    If My.Application.CommandLineArgs.Count >= 5 AndAlso _
                                        Not String.IsNullOrEmpty(My.Application.CommandLineArgs(4)) Then
                                        status = My.Application.CommandLineArgs(4)
                                    End If

                                    'Find the computer based on its name.
                                    Dim foundComputer As String = Nothing
                                    Dim tmpComputerCollection As ComputerTargetCollection = ConnectionManager.ParentServer.SearchComputerTargets(computerName)
                                    For Each tmpComputer As IComputerTarget In tmpComputerCollection
                                        If UCase(tmpComputer.FullDomainName) = UCase(computerName) Then
                                            foundComputer = tmpComputer.Id
                                        End If
                                    Next

                                    'If the computer wasn't found then error out.
                                    If foundComputer Is Nothing Then
                                        LogError(String.Format(Globals.globalRM.GetString("error_command_find_computer"), computerName))
                                    Else 'computer was found.

                                        'Export the data, using the status if one was passed in.
                                        If status Is Nothing Then
                                            DataRoutines.ExportData(DataRoutines.GetComputerReport(foundComputer), outputFile)
                                        Else
                                            DataRoutines.ExportData(DataRoutines.GetComputerReport(foundComputer, status), outputFile)
                                        End If
                                    End If
                                Else
                                    'Not the right number of arguments.
                                End If
                            Case "-ur"
                                'We need at least 4 arguments for this report.
                                If My.Application.CommandLineArgs.Count >= 4 AndAlso _
                                    Not String.IsNullOrEmpty(My.Application.CommandLineArgs(3)) Then

                                    Dim updateName As String = My.Application.CommandLineArgs(3)
                                    Dim groupName As String = ""
                                    Dim status As String = ""

                                    'If a group name was passed then set it here.
                                    'Otherwise, default to the All Computers group.
                                    If My.Application.CommandLineArgs.Count >= 5 AndAlso _
                                        Not String.IsNullOrEmpty(My.Application.CommandLineArgs(4)) Then
                                        groupName = My.Application.CommandLineArgs(4)
                                    Else
                                        groupName = ConnectionManager.CurrentServer.GetComputerTargetGroup(ComputerTargetGroupId.AllComputers).Name
                                    End If

                                    'If a status was passedthen set it here.
                                    If My.Application.CommandLineArgs.Count >= 6 Then
                                        status = My.Application.CommandLineArgs(5)
                                    End If

                                    'Find the update based on its name.
                                    Dim foundUpdate As IUpdate = Nothing
                                    Dim tmpUpdateCollection As UpdateCollection = ConnectionManager.ParentServer.SearchUpdates(updateName)
                                    For Each tmpUpdate As IUpdate In tmpUpdateCollection
                                        If UCase(tmpUpdate.Title) = UCase(updateName) Then
                                            foundUpdate = tmpUpdate
                                        End If
                                    Next

                                    'Find the group based on its name.
                                    Dim foundGroup As IComputerTargetGroup = Nothing
                                    Dim tmpGroupCollection As ComputerTargetGroupCollection = ConnectionManager.ParentServer.GetComputerTargetGroups
                                    For Each tmpGroup As IComputerTargetGroup In tmpGroupCollection
                                        If UCase(tmpGroup.Name) = UCase(groupName) Then
                                            foundGroup = tmpGroup
                                        End If
                                    Next

                                    'If the computer wasn't found then error out.
                                    If foundUpdate Is Nothing Then
                                        LogError(String.Format(Globals.globalRM.GetString("error_command_find_update"), updateName))
                                    ElseIf foundGroup Is Nothing Then
                                        LogError(String.Format(Globals.globalRM.GetString("error_command_find_group"), groupName))
                                    Else 'Computer and group were found.

                                        'Export the data, using the status if one was passed in.
                                        If status Is Nothing Then
                                            DataRoutines.ExportData(DataRoutines.GetUpdateReport(foundUpdate, foundGroup), outputFile)
                                        Else
                                            DataRoutines.ExportData(DataRoutines.GetUpdateReport(foundUpdate, foundGroup, status), outputFile)
                                        End If
                                    End If
                                Else
                                    'Not the right number of arguments.
                                End If
                            Case Else
                                MsgBox(Globals.globalRM.GetString("error_command_unknown"))
                        End Select
                    Else 'Not connected to server.
                        LogError(String.Format(Globals.globalRM.GetString("error_command_connect"), serverName))
                    End If
                Else 'Too few arguments.
                    LogError(Globals.globalRM.GetString("error_command_arguments"))
                End If

                End 'Exit the program.
            End If 'Command line arguments were passed.
        End Sub

        ''' <summary>
        ''' Log the error to the event logs.  Try to create a source for LUP
        ''' but if that fails use the generic 'Application" source.
        ''' </summary>
        ''' <param name="errorMessage">String</param>
        Private Shared Sub LogError(errorMessage As String)
            Dim sourceFound As Boolean = False

            'Try to find the source for LUP.
            Try
                sourceFound = EventLog.SourceExists("Local Update Publisher")
            Catch
                'Ignore errors
            End Try

            'Use it if found or try to create it.
            If Not sourceFound Then

                'Try to create the source.  If this fails, use the generic source.
                Try
                    EventLog.CreateEventSource("Local Update Publisher", "Application")
                    EventLog.WriteEntry("Local Update Publisher", Formatted(errorMessage))
                Catch
                    EventLog.WriteEntry("Application", Formatted(vbNewLine & "Local Update Publisher " & vbNewLine & errorMessage))
                End Try
            Else
                EventLog.WriteEntry("Local Update Publisher", Formatted(errorMessage))
            End If
        End Sub
        ''' <summary>
        ''' Format a string.
        ''' </summary>
        ''' <param name="Message">String to be formatted.</param>
        ''' <returns>String</returns>
        Private Shared Function Formatted(ByVal Message As String) As String
            Return String.Format(vbNewLine & "{0} {1}", Now, Message)
        End Function

        ''' <summary>
        ''' Create main form event.
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub OnCreateMainForm()
            Me.MainForm = My.Forms.MainForm
        End Sub


        ''' <summary>
        ''' Handle the exceptions by showing a dialog box, and asking the user whether
        ''' or not they wish to abort execution.
        '''  NOTE: This exception cannot be kept from terminating the application - it can only
        ''' log the event, and inform the user about it.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Shared Sub CurrentDomain_UnhandledException(ByVal sender As Object, ByVal e As System.UnhandledExceptionEventArgs)
            Try
                Dim ex As Exception = DirectCast(e.ExceptionObject, Exception)
                Dim errorMsg As String = "An application error occurred. Please contact the adminstrator " & _
                    "with the following information:" & ControlChars.Lf & ControlChars.Lf

                ' Since we can't prevent the app from terminating, log this to the event log.
                If (Not EventLog.SourceExists("ThreadException")) Then
                    EventLog.CreateEventSource("ThreadException", "Application")
                End If

                ' Create an EventLog instance and assign its source.
                Dim myLog As New EventLog()
                myLog.Source = "ThreadException"
                myLog.WriteEntry((errorMsg + ex.Message & ControlChars.Lf & ControlChars.Lf & _
                    "Stack Trace:" & ControlChars.Lf & ex.StackTrace))
            Catch exc As Exception
                Try
                    MessageBox.Show("Fatal Non-UI Error", "Fatal Non-UI Error. Could not write the error to the event log. " & _
                        "Reason: " & exc.Message, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Finally
                    End
                End Try
            End Try
        End Sub

        ''' <summary>
        ''' Creates the error message and displays it.
        ''' </summary>
        ''' <param name="title"></param>
        ''' <param name="e"></param>
        ''' <returns>DialogResult</returns>
        Private Shared Function ShowThreadExceptionDialog(ByVal title As String, ByVal e As Exception) As DialogResult
            Dim errorMsg As String = "An application error occurred. Please contact the adminstrator " & _
                "with the following information:" & ControlChars.Lf & ControlChars.Lf
            errorMsg = errorMsg & e.Message & ControlChars.Lf & _
                ControlChars.Lf & "Stack Trace:" & ControlChars.Lf & e.StackTrace

            Return MessageBox.Show(errorMsg, title, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop)
        End Function

    End Class
End Namespace


