Option Explicit On
Option Strict On
' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' Async Publisher handles the work of publishing packages asynchronously.
'
' User: Bryan Dam
' Date: 2/10/2012
' Time: 10:29 AM
'
Imports System.ComponentModel
Imports Microsoft.UpdateServices.Administration
Imports System.IO
Imports System.Security
Imports System.Net
Imports System.Drawing

Public Class AsyncPublisher

    Public Sub New()
    End Sub

#Region "Properties"

    Private Shared m_bgwPublisher As BackgroundWorker

#End Region

#Region "Events"

    Public Shared Event Completed(success As Boolean)

#End Region

#Region "Revise Existing Package"
    Public Shared Sub RevisePackage(sdp As SoftwareDistributionPackage, parentForm As Form)
        Call RevisePackage(sdp, parentForm, False)
    End Sub


    ''' <summary>
    ''' Revise package.
    ''' </summary>
    ''' <param name="sdp">SDP to revise.</param>
    ''' <param name="parentForm">Parent form.</param>
    ''' <param name="metaDataOnly">Only publish the metadata.</param>
    Public Shared Sub RevisePackage(sdp As SoftwareDistributionPackage, parentForm As Form, metaDataOnly As Boolean)
        Dim i_Compress As CabLib.Compress = New CabLib.Compress

        Try
            'Get the SDP, use to create the publisher, and then delete it.
            Dim sdpFilePath As String = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), sdp.PackageId.ToString() & ".xml")
            sdp.Save(sdpFilePath)
            Dim publisher As IPublisher = ConnectionManager.ParentServer.GetPublisher(sdpFilePath)
            System.IO.File.Delete(sdpFilePath)

            'Set the publisher's metadata value.
            publisher.MetadataOnly = metaDataOnly

            'Setup and show the progress form.
            My.Forms.ProgressForm.Location = New Point(parentForm.Location.X + 100, parentForm.Location.Y + 100)
            My.Forms.ProgressForm.ShowDialog(Globals.globalRM.GetString("prompt_connection_wait_revise"), parentForm)

            'Setup the bgwPublisher object.
            Call SetupBgwPublisher()

            'Make the asyncronous call to revise the package.
            m_bgwPublisher.RunWorkerAsync(New AsyncPublishingDetails(publisher, PublishMethod.Revise))

            Exit Sub

        Catch x As PathTooLongException
            MsgBox(Globals.globalRM.GetString("exception_path_too_long") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
        Catch x As SecurityException
            MsgBox(Globals.globalRM.GetString("exception_security") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
        Catch x As UnauthorizedAccessException
            MsgBox(Globals.globalRM.GetString("exception_unauthorized_access") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
        Catch x As NotSupportedException
            MsgBox(Globals.globalRM.GetString("exception_not_supported") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
        Catch x As ArgumentNullException
            MsgBox(Globals.globalRM.GetString("exception_argument_null") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
        Catch x As FileNotFoundException
            MsgBox(Globals.globalRM.GetString("exception_file_not_found") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
        Catch x As InvalidDataException
            MsgBox(Globals.globalRM.GetString("exception_invalid_data") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
        Catch x As InvalidOperationException
            MsgBox(Globals.globalRM.GetString("exception_invalid_operation") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
        Catch x As ArgumentException
            MsgBox(Globals.globalRM.GetString("exception_argument") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
        Catch x As IOException
            MsgBox(Globals.globalRM.GetString("exception_IO") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
        Catch x As Win32Exception
            MsgBox(Globals.globalRM.GetString("exception_win32") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
        End Try
        RaiseEvent Completed(False)
    End Sub


    '	'Call with no temporary path.
    '	Public Shared Function PublishPackageFromCatalog(sdp As SoftwareDistributionPackage, parentForm As Form) As Boolean'
    '		Return PublishPackageFromCatalog(sdp, parentForm)
    '	End Function
#End Region

#Region "Publish New Package"
    ''' <summary>
    ''' Publish package, downloading any files necessary from the installable item.
    ''' </summary>
    ''' <param name="sdp">SDP to publish.</param>
    ''' <param name="path">Path to catalog file.</param>
    ''' <param name="parentForm">Parent form.</param>
    Public Shared Sub PublishPackageFromCatalog(sdp As SoftwareDistributionPackage, path As String, parentForm As Form)
        Dim fileDownloader As New WebClient()
        Dim fileList As IList(Of Object) = New List(Of Object)
        Dim tmpFileUri As Uri = Nothing

        Try
            'If an installable item exists
            If sdp.InstallableItems.Count > 0 Then

                'If there's no URI, a path was given, and it exists then use the
                ' files in that path.  Otherwise download the file using the URI.
                If sdp.InstallableItems(0).OriginalSourceFile.OriginUri Is Nothing AndAlso _
                    Not String.IsNullOrEmpty(path) AndAlso _
                    Directory.Exists(path) Then

                    'Loop through the package's directory and add the files to the list.
                    For Each tmpFilePath As String In Directory.GetFiles(System.IO.Path.Combine(path, sdp.PackageId.ToString))
                        fileList.Add(New FileInfo(tmpFilePath)) 'Add it to the list.
                    Next

                    Call PublishPackage(sdp, fileList, parentForm) 'Publish it.
                Else
                    Dim tmpFilePath As String = System.IO.Path.Combine(Environment.GetEnvironmentVariable("TEMP"), sdp.InstallableItems(0).OriginalSourceFile.FileName)
                    'Get download location.
                    tmpFileUri = sdp.InstallableItems(0).OriginalSourceFile.OriginUri

                    'Set cursor and position of progress form.
                    My.Forms.ProgressForm.Location = New Point(My.Forms.MainForm.Location.X + 100, My.Forms.MainForm.Location.Y + 100)
                    My.Forms.ProgressForm.ShowDialog(String.Format(Globals.globalRM.GetString("status_connection_downloading"), sdp.Title), parentForm)
                    My.Forms.ProgressForm.SetCurrentStep(tmpFileUri.ToString)

                    'Download the file and add it to the file list
                    ConnectionManager.DownloadChunks(tmpFileUri, My.Forms.ProgressForm.progressBar, tmpFilePath)
                    fileList.Add(New FileInfo(tmpFilePath)) 'Add it to the list.

                    Call PublishPackage(sdp, fileList, parentForm) 'Publish it.
                    'TODO System.IO.File.Delete(tmpFilePath) 'Delete the temp file.
                End If

            Else
                RaiseEvent Completed(False)
            End If

            Exit Sub

        Catch ex As HttpListenerException
            Console.WriteLine(Globals.globalRM.GetString("exception_HTTP_listener") & ": " & vbNewLine & String.Format(Globals.globalRM.GetString("error_connection_download"), tmpFileUri.ToString) & vbNewLine & ex.Message)
        Catch ex As Exception
            Console.WriteLine(Globals.globalRM.GetString("exception") & ": " & vbNewLine & String.Format(Globals.globalRM.GetString("error_connection_download"), tmpFileUri.ToString) & vbNewLine & ex.Message)
        End Try
        RaiseEvent Completed(False)
    End Sub
    ''' <summary>
    ''' Publish individual package from CAB file.
    ''' </summary>
    ''' <param name="file">FileInfo object represending the CAB to be imported.</param>
    ''' <param name="parentForm">Parent form.</param>
    Public Shared Sub PublishPackageFromCAB(file As FileInfo, parentForm As Form)
        Dim sdpFile As FileInfo = Nothing
        Dim packageCab As FileInfo = Nothing

        If file.Exists Then
            Try
                'Extract the CAB to a new temporary path.
                Dim tmpExtract As New CabLib.Extract()
                Dim extractPath As New DirectoryInfo(System.IO.Path.Combine(Path.GetTempPath, Path.GetRandomFileName))
                tmpExtract.ExtractFile(file.FullName, extractPath.ToString)

                'Loop through the temp folder and find the XML and CAB files.
                For Each tmpFile As FileInfo In extractPath.GetFiles
                    If tmpFile.Extension = ".xml" Then
                        sdpFile = tmpFile
                    ElseIf tmpFile.Extension = ".cab" Then
                        packageCab = tmpFile
                    End If
                Next

                'Make sure an SDP and CAB file were found.
                If sdpFile Is Nothing Then
                    MsgBox(Globals.globalRM.GetString("error_connection_no_XML"))
                    RaiseEvent Completed(False)
                ElseIf packageCab Is Nothing Then
                    MsgBox(Globals.globalRM.GetString("error_connection_no_cab"))
                    RaiseEvent Completed(False)
                End If

                'Make sure that the WSUS and CAB certificates match.
                'Dim tmpPackage As Package = Package.Open(

                'tmpPackage.GetParts(0).


                '			Dim MySigner As New Cryptography.DSACryptoServiceProvider
                '
                '			Dim file As New FileStream(packageCab.FullName, FileMode.Open, FileAccess.Read)
                '			Dim reader As New BinaryReader(file)
                '			Dim data As Byte() = reader.ReadBytes(file.Length)
                '
                '			Dim signature As byte() = MySigner.SignData(data)
                '			Dim publicKey As String = MySigner.ToXmlString(False)
                '
                '			reader.Close()
                '			file.Close()
                '
                '			Dim verifier As New Cryptography.DSACryptoServiceProvider()
                '
                '			verifier.FromXmlString(publicKey)
                '
                '			Dim file2 As New FileStream(packageCab.FullName, FileMode.Open, FileAccess.Read)
                '			Dim reader2 As New BinaryReader(file2)
                '			Dim data2 As byte() = reader2.ReadBytes(file2.Length)
                '
                '			If verifier.VerifyData(data2, signature) Then
                '				Console.WriteLine("Signature")
                '			Else
                '				Console.WriteLine("Signature is not verified")
                '				reader2.Close()
                '				file2.Close()
                '
                '			End If
                '
                '			 Dim rsaCsp As New Cryptography.RSACryptoServiceProvider
                '			 rsaCsp.
                '
                '			Debug.WriteLine(vbnewline & "signature: " & Convert.ToBase64String(signature))
                '			Debug.WriteLine(vbnewline & "MySigner.GetHashCode: " & MySigner.GetHashCode)
                '			Debug.WriteLine(vbnewline & "MySigner.KeyExchangeAlgorithm: " & MySigner.KeyExchangeAlgorithm)
                '			Debug.WriteLine(vbnewline & "MySigner.SignatureAlgorithm: " & MySigner.SignatureAlgorithm)
                '			Debug.WriteLine(vbnewline & "publickey: " & publickey)
                '			Debug.WriteLine(vbnewline & "Cert.KeyAlgorithm: " & _currentServerCertificate.GetKeyAlgorithm)
                '			Debug.WriteLine(vbnewline & "Cert.Format: " & _currentServerCertificate.GetFormat)
                '			Debug.WriteLine(vbnewline & "Cert.HashString: " & _currentServerCertificate.GetCertHashString)
                '			Debug.WriteLine(vbnewline & "Cert.HashCode: " & _currentServerCertificate.GetHashCode)
                '			Debug.WriteLine(vbnewline & "Cert.PublicKey: " & Convert.ToBase64String(_currentServerCertificate.GetPublicKey))
                '			Debug.WriteLine(vbnewline & "Cert.PublicKeyString: " & _currentServerCertificate.GetPublicKeyString)
                '			Debug.WriteLine(vbnewline & "Cert.RawCertDataString: " & _currentServerCertificate.GetRawCertDataString)
                '			Debug.WriteLine(vbnewline & "Cert.SerialNumberString: " & _currentServerCertificate.GetSerialNumberString)
                '			Debug.WriteLine(vbnewline & "Cert.Details: " & _currentServerCertificate.ToString(True))

                '			Return Nothing

                'Use the SDP file to create a new publisher and then delete it.
                Dim publisher As IPublisher = ConnectionManager.ParentServer.GetPublisher(sdpFile.FullName)
                sdpFile.Delete()

                'Setup and show the progress form.
                My.Forms.ProgressForm.Location = New Point(parentForm.Location.X + 100, parentForm.Location.Y + 100)
                My.Forms.ProgressForm.ShowDialog(Globals.globalRM.GetString("prompt_connection_wait"), parentForm)

                'Setup the bgwPublisher object.
                Call SetupBgwPublisher()

                'Make the asyncronous call to publish the package.
                m_bgwPublisher.RunWorkerAsync(New AsyncPublishingDetails(publisher, PublishMethod.PublishCAB, packageCab))

                'TODO: The extract path itself doesn't get deleted by the asyncronous method but the SDP and CAB files themseles will.
                Exit Sub

            Catch x As PathTooLongException
                MsgBox(Globals.globalRM.GetString("exception_path_too_long") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
            Catch x As SecurityException
                MsgBox(Globals.globalRM.GetString("exception_security") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
            Catch x As UnauthorizedAccessException
                MsgBox(Globals.globalRM.GetString("exception_unauthorized_access") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
            Catch x As NotSupportedException
                MsgBox(Globals.globalRM.GetString("exception_not_supported") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
            Catch x As ArgumentNullException
                MsgBox(Globals.globalRM.GetString("exception_argument_null") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
            Catch x As FileNotFoundException
                MsgBox(Globals.globalRM.GetString("exception_file_not_found") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
            Catch x As InvalidDataException
                MsgBox(Globals.globalRM.GetString("exception_invalid_data") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
            Catch x As InvalidOperationException
                MsgBox(Globals.globalRM.GetString("exception_invalid_operation") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
            Catch x As ArgumentException
                MsgBox(Globals.globalRM.GetString("exception_argument") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
            Catch x As IOException
                MsgBox(Globals.globalRM.GetString("exception_IO") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
            Catch x As Win32Exception
                MsgBox(Globals.globalRM.GetString("exception_win32") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
            End Try

            RaiseEvent Completed(False)
        End If

    End Sub

    ''' <summary>
    ''' Publish package metadata without any files.
    ''' </summary>
    ''' <param name="sdp">SDP</param>
    ''' <param name="parentForm">Parent form.</param>
    ''' <remarks></remarks>
    Public Shared Sub PublishPackageMetaData(sdp As SoftwareDistributionPackage, parentForm As Form)
        Call PublishPackage(sdp, Nothing, parentForm)
    End Sub

    ''' <summary>
    ''' Publish package with list of files and directories.
    ''' </summary>
    ''' <param name="sdp">SDP to publish.</param>
    ''' <param name="updateFiles">List of FileInfo objects represending the additonal files to be included.</param>
    ''' <param name="parentForm">Parent form.</param>
    Public Shared Sub PublishPackage(sdp As SoftwareDistributionPackage, updateFiles As IList(Of Object), parentForm As Form)

        Try

            'Save the SDP, use it to create a publisher object, and then delete it.
            Dim sdpFilePath As String = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), sdp.PackageId.ToString() & ".xml")
            sdp.Save(sdpFilePath)
            Dim publisher As IPublisher = ConnectionManager.ParentServer.GetPublisher(sdpFilePath)
            File.Delete(sdpFilePath)

            'If no files were passed in then only publish the metadata.
            If updateFiles Is Nothing Then publisher.MetadataOnly = True

            'Set cursor and position of progress form.
            My.Forms.ProgressForm.Location = New Point(My.Forms.MainForm.Location.X + 100, My.Forms.MainForm.Location.Y + 100)

            'Create temporary directory.
            Dim updateDir As DirectoryInfo = New DirectoryInfo(Path.Combine(Environment.GetEnvironmentVariable("TEMP"), sdp.PackageId.ToString()))
            If Not updateDir.Exists Then updateDir.Create() 'Create directory if needed.

            'Copy files into the temporary directory if needed.
            If Not publisher.MetadataOnly AndAlso _
                Not updateFiles Is Nothing AndAlso _
                updateFiles.Count > 0 Then

                'Add each file or directory to the target directory.
                For Each tmpFileDir As Object In updateFiles

                    'Copy these using the appropriate method based on their object type.
                    If TypeOf tmpFileDir Is FileInfo AndAlso DirectCast(tmpFileDir, FileInfo).Exists Then
                        DirectCast(tmpFileDir, FileInfo).CopyTo(Path.Combine(updateDir.FullName, DirectCast(tmpFileDir, FileInfo).Name), True)
                    ElseIf TypeOf tmpFileDir Is DirectoryInfo AndAlso DirectCast(tmpFileDir, DirectoryInfo).Exists Then
                        CopyDirectory(DirectCast(tmpFileDir, DirectoryInfo).FullName, Path.Combine(updateDir.FullName, DirectCast(tmpFileDir, DirectoryInfo).Name))
                    End If
                Next
            End If


            'Setup and show the progress form.
            My.Forms.ProgressForm.Location = New Point(parentForm.Location.X + 100, parentForm.Location.Y + 100)
            My.Forms.ProgressForm.Show(Globals.globalRM.GetString("prompt_connection_wait"), parentForm)

            'Setup the bgwPublisher object.
            Call SetupBgwPublisher()

            'Make the asyncronous call to publish the package.
            m_bgwPublisher.RunWorkerAsync(New AsyncPublishingDetails(publisher, PublishMethod.Publish, updateDir))

            Exit Sub
        Catch x As PathTooLongException
            MsgBox(Globals.globalRM.GetString("exception_path_too_long") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
        Catch x As SecurityException
            MsgBox(Globals.globalRM.GetString("exception_security") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
        Catch x As UnauthorizedAccessException
            MsgBox(Globals.globalRM.GetString("exception_unauthorized_access") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
        Catch x As NotSupportedException
            MsgBox(Globals.globalRM.GetString("exception_not_supported") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
        Catch x As ArgumentNullException
            MsgBox(Globals.globalRM.GetString("exception_argument_null") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
        Catch x As FileNotFoundException
            MsgBox(Globals.globalRM.GetString("exception_file_not_found") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
        Catch x As InvalidDataException
            MsgBox(Globals.globalRM.GetString("exception_invalid_data") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
        Catch x As InvalidOperationException
            MsgBox(Globals.globalRM.GetString("exception_invalid_operation") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
        Catch x As ArgumentException
            MsgBox(Globals.globalRM.GetString("exception_argument") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
        Catch x As IOException
            MsgBox(Globals.globalRM.GetString("exception_IO") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
        Catch x As Win32Exception
            MsgBox(Globals.globalRM.GetString("exception_win32") & ": " & Globals.globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
        End Try

        RaiseEvent Completed(False)
    End Sub

#End Region

#Region "BackGroundWorker Details"
    ''' <summary>
    ''' Instantiate the bgwPublisher object if it hasn't been done so already.
    ''' </summary>
    Private Shared Sub SetupBgwPublisher()

        If m_bgwPublisher Is Nothing Then
            m_bgwPublisher = New System.ComponentModel.BackgroundWorker
            m_bgwPublisher.WorkerReportsProgress = True
            AddHandler m_bgwPublisher.DoWork, AddressOf _bgwPublisherDoWork
            AddHandler m_bgwPublisher.ProgressChanged, AddressOf _bgwPublisherProgressChanged
            AddHandler m_bgwPublisher.RunWorkerCompleted, AddressOf _bgwPublisherRunWorkerCompleted
        End If

    End Sub

    ''' <summary>
    ''' Publish the packages asynchronously.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>This routine does the actual publishing work.  It needs to receive a Publishing Details object which tells
    ''' it what to do and also sets up the event handler to update the progress.  This is done here so that the
    ''' progress handler runs and fires events on the BGW thread.
    ''' </remarks>
    Private Shared Sub _bgwPublisherDoWork(sender As Object, e As DoWorkEventArgs)

        'Make sure an argument was passed and that it is a PublishignDetails object.
        If Not e.Argument Is Nothing AndAlso TypeOf e.Argument Is AsyncPublishingDetails Then
            Dim tmpPublishingDetails As AsyncPublishingDetails = DirectCast(e.Argument, AsyncPublishingDetails)

            'Make sure that a publisher was set as well as the update directory.
            If Not tmpPublishingDetails.Publisher Is Nothing Then

                'Add the event handler to the publisher to show progress.
                AddHandler tmpPublishingDetails.Publisher.ProgressHandler, AddressOf PublisherProgressHandler

                'Publishing the package based on the publishing method
                Select Case tmpPublishingDetails.PublishMethod
                    Case PublishMethod.Publish
                        If Not tmpPublishingDetails.UpdateDir Is Nothing Then
                            tmpPublishingDetails.Publisher.PublishPackage(tmpPublishingDetails.UpdateDir.FullName, Nothing, Nothing)
                        End If
                    Case PublishMethod.PublishCAB
                        If Not tmpPublishingDetails.UpdateFile Is Nothing Then
                            tmpPublishingDetails.Publisher.PublishSignedPackage(tmpPublishingDetails.UpdateFile.FullName, Nothing)
                        End If
                    Case PublishMethod.Revise
                        tmpPublishingDetails.Publisher.RevisePackage()
                    Case Else
                        'TODO:Not sure if I need to do something here.
                End Select

                'Send the argument on as the result.
                e.Result = e.Argument
            End If
        End If
    End Sub

    ''' <summary>
    ''' Update the UI on the progress of the publshing thread.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>This progress handler is assigned and thus runs in the BGW thread.  It then calls the BGW's Report Progress routine
    ''' to interact with the main UI thread to update the progress bar.
    ''' </remarks>
    Private Shared Sub PublisherProgressHandler(sender As Object, e As Microsoft.UpdateServices.Administration.PublishingEventArgs)
        m_bgwPublisher.ReportProgress(0, e)
    End Sub

    ''' <summary>
    ''' This routine is called from the BGW thread and updates the progress form on the UI thread.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Shared Sub _bgwPublisherProgressChanged(sender As Object, e As ProgressChangedEventArgs)

        'If the UserState object is instantiated and a PublishingEventArgs then update the progress form.
        If Not e.UserState Is Nothing And TypeOf e.UserState Is Microsoft.UpdateServices.Administration.PublishingEventArgs Then
            Dim tmpPublishingEventArgs As PublishingEventArgs = DirectCast(e.UserState, PublishingEventArgs)

            With My.Forms.ProgressForm
                .SetCurrentStep(tmpPublishingEventArgs.ProgressStep.ToString)
                .progressBar.Maximum = CInt(tmpPublishingEventArgs.UpperProgressBound)
                .progressBar.Value = CInt(tmpPublishingEventArgs.CurrentProgress)
                .progressBar.Refresh()
                .Refresh()
            End With

        End If
    End Sub


    ''' <summary>
    ''' When the asyncronous publishing work is done handle the results.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Shared Sub _bgwPublisherRunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)

        If e.Cancelled Or Not e.Error Is Nothing Then
            RaiseEvent Completed(False)
        Else

            My.Forms.ProgressForm.Dispose()
            'Make sure the result was set and that it is a PublishignDetails object.
            If Not e.Result Is Nothing AndAlso TypeOf e.Result Is AsyncPublishingDetails Then
                Dim tmpPublishingDetails As AsyncPublishingDetails = DirectCast(e.Result, AsyncPublishingDetails)

                'Make sure that a publisher was set as well as the update directory.
                If Not tmpPublishingDetails.Publisher Is Nothing Then

                    'Remove with the progress handler.
                    RemoveHandler tmpPublishingDetails.Publisher.ProgressHandler, AddressOf PublisherProgressHandler
                    tmpPublishingDetails.Publisher = Nothing

                    'Delete the temporary directory if it was set and ignore any errors.
                    If Not tmpPublishingDetails.UpdateDir Is Nothing Then
                        Try
                            tmpPublishingDetails.UpdateDir.Delete(True) 'Remove the update directory from the temp folder.
                        Catch
                        End Try
                    End If

                    'Delete the update file if it was set and ignore any errors.
                    If Not tmpPublishingDetails.UpdateFile Is Nothing Then
                        Try
                            tmpPublishingDetails.UpdateFile.Delete() 'Remove the update directory from the temp folder.
                        Catch
                        End Try
                    End If
                End If
            End If

            RaiseEvent Completed(True)
        End If
    End Sub

#End Region

#Region "Misc"
    ''' <summary>
    ''' Copy a complete directory, recursively including any subdirectories.
    ''' </summary>
    ''' <param name="sourceDirectoryName"></param>
    ''' <param name="targetDirectoryName"></param>
    Private Shared Sub CopyDirectory(sourceDirectoryName As String, targetDirectoryName As String)

        Try
            'Create directory if needed.
            Directory.CreateDirectory(targetDirectoryName)

            'Copy the files.
            For Each tmpFileName As String In Directory.GetFiles(sourceDirectoryName)
                File.Copy(tmpFileName, Path.Combine(targetDirectoryName, Path.GetFileName(tmpFileName)), True)
            Next

            'Copy the directories recursively.
            For Each tmpSubDirectory As String In Directory.GetDirectories(sourceDirectoryName)
                CopyDirectory(tmpSubDirectory, Path.Combine(targetDirectoryName, Path.GetFileName(tmpSubDirectory)))
            Next

        Catch
            MsgBox(Globals.globalRM.GetString("error_connection_copy_directory") & ": " & vbNewLine & sourceDirectoryName)
        End Try

    End Sub
#End Region


End Class

'A simple class to pass the object we need through the backgroundworker thread.
#Region "AsyncPublishingDetails Class"
Public Class AsyncPublishingDetails
    Public Sub New()
    End Sub

    Public Sub New(publisher As IPublisher, publishMethod As PublishMethod)
        m_publisher = publisher
        m_publishMethod = publishMethod
        m_updateDir = UpdateDir
    End Sub

    Public Sub New(publisher As IPublisher, publishMethod As PublishMethod, updateDir As DirectoryInfo)
        m_publisher = publisher
        m_publishMethod = publishMethod
        m_updateDir = updateDir
    End Sub

    Public Sub New(publisher As IPublisher, publishMethod As PublishMethod, updateFile As FileInfo)
        m_publisher = publisher
        m_publishMethod = publishMethod
        m_updateFile = updateFile
    End Sub

#Region "Properties"
    Private m_publisher As IPublisher
    Public Property Publisher() As IPublisher
        Get
            Return m_publisher
        End Get
        Set(value As IPublisher)
            m_publisher = value
        End Set
    End Property

    Private m_publishMethod As PublishMethod
    Public Property PublishMethod() As PublishMethod
        Get
            Return m_publishMethod
        End Get
        Set(value As PublishMethod)
            m_publishMethod = value
        End Set
    End Property

    Private m_updateDir As DirectoryInfo
    Public Property UpdateDir() As DirectoryInfo
        Get
            Return m_updateDir
        End Get
        Set(value As DirectoryInfo)
            m_updateDir = value
        End Set
    End Property

    Private m_updateFile As FileInfo
    Public Property UpdateFile() As FileInfo
        Get
            Return m_updateFile
        End Get
        Set(value As FileInfo)
            m_updateFile = value
        End Set
    End Property

#End Region
End Class
#End Region

Public Enum PublishMethod
    Revise
    Publish
    PublishCAB
End Enum
