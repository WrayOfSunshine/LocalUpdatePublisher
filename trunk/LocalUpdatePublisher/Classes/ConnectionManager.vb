Option Explicit On
Option Strict On
' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' Handles the connection and certificate routines.
'
' Created by SharpDevelop.
' User: kdixon
' Date: 10/2/2010
' Time: 11:10 AM
' Factored out of code originally developed by BRD.

Imports System
Imports System.Reflection
Imports System.Net
Imports System.Security
Imports System.ComponentModel
Imports Microsoft.UpdateServices.Administration
Imports System.Security.Cryptography.X509Certificates
Imports System.IO
Imports System.Xml.Schema
Imports System.Drawing


Friend NotInheritable Class ConnectionManager
    Private Sub New()
    End Sub

#Region "Properties"
    Private Shared m_serverCollection As UpdateServerCollection
    Public Shared ReadOnly Property ServerCollection() As UpdateServerCollection
        Get
            Return m_serverCollection
        End Get
    End Property

    Private Shared m_parentServer As IUpdateServer
    Public Shared ReadOnly Property ParentServer() As IUpdateServer
        Get
            Return m_parentServer
        End Get
    End Property

    Private Shared m_currentServer As IUpdateServer
    Public Shared ReadOnly Property CurrentServer() As IUpdateServer
        Get
            Return m_currentServer
        End Get
    End Property

    Private Shared m_currentServerConfiguration As IUpdateServerConfiguration
    Public Shared ReadOnly Property CurrentServerConfiguration() As IUpdateServerConfiguration
        Get
            Return m_currentServerConfiguration
        End Get
    End Property

    Private Shared m_currentServerCertificate As X509Certificate2
    Public Shared Property CurrentServerCertificate() As X509Certificate2
        Get
            Return m_currentServerCertificate
        End Get
        Private Set(value As X509Certificate2)
            m_currentServerCertificate = value
        End Set
    End Property
#End Region

#Region "Connection"
    ''' <summary>
    ''' Load the list of available servers from the Globals.appSettings global.
    ''' If there are none, prompt the user to enter server info.
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub LoadServerList()
        m_serverCollection = Globals.appSettings.UpdateServers
        'If there are no servers then prompt for initial connection info.
        If m_serverCollection.Count = 0 Then
            My.Forms.ConnectionSettingsForm.Location = New Point(My.Forms.MainForm.Location.X + 100, _
                My.Forms.MainForm.Location.Y + 100)

            Dim DialogReturn As DialogResult = My.Forms.ConnectionSettingsForm.ShowDialog

            'If user doesn't enter settings then continue.
            If DialogReturn = DialogResult.Cancel Then
                Exit Sub
            End If
        End If
    End Sub

    ''' <summary>
    ''' Connect to server.
    ''' </summary>
    ''' <param name="server">UpdateServer object to connect to.</param>
    ''' <returns>Boolean indicating if the connection was successful.</returns>
    Public Shared Function Connect(server As UpdateServer) As Boolean
        'Set our Global to nothing
        m_currentServer = Nothing
        m_currentServerConfiguration = Nothing
        ConnectionManager.ClearCert()

        ''My.Forms.MainForm.Status = String.Format(Globals.globalRM.GetString("status_server_connecting"), server.Name)
        ''My.Forms.MainForm.Update

        Try
            'Connect to the server using the appropriate call.
            If String.IsNullOrEmpty(server.Name) OrElse LCase(server.Name) = "localhost" Then
                m_currentServer = AdminProxy.GetUpdateServer("localhost", server.Ssl, server.Port)
            Else
                m_currentServer = AdminProxy.GetUpdateServer(server.Name, server.Ssl, server.Port)
            End If

            'Set the culture for the server.
            Try
                m_currentServer.PreferredCulture = Globals.appSettings.Culture
            Catch x As ArgumentOutOfRangeException
                'This culture is not supported.
            End Try

            'If this is a not a child server then set the parent server to
            ' be the current server.
            If Not server.ChildServer Then m_parentServer = m_currentServer

            'Get update server configuration.
            m_currentServerConfiguration = m_currentServer.GetConfiguration
            ''My.Forms.MainForm.Status = String.Format(Globals.globalRM.GetString("status_server_connected") , _currentServer.Name)
            ''My.Forms.MainForm.Update

            'Check the server version
            'TODO: This check isn't accurate because the file version of the referenced DLL doesn't correlate to the API version.
            'ConnectionManager.CheckAPIVersion()

            'Try to retrieve cert info from server.
            'If there is no cert info, prompt the user to create it.
            If Not ConnectionManager.LoadCert Then
                If server.ChildServer AndAlso Not CurrentServerConfiguration.IsReplicaServer Then
                    MsgBox(String.Format(Globals.globalRM.GetString("error_connection_no_cert"), server.Name))
                Else
                    If (MsgBox( _
                        String.Format(Globals.globalRM.GetString("error_connection_no_cert"), server.Name) & vbNewLine & Globals.globalRM.GetString("prompt_connection_cert"), _
                        MsgBoxStyle.YesNo, _
                        Globals.globalRM.GetString("warning_connection_no_cert")) _
                        ) = vbYes Then
                        My.Forms.MainForm.Status = Globals.globalRM.GetString("warning_connection_no_cert")
                        My.Forms.MainForm.Update()

                        'Show Cert Info form.
                        My.Forms.CertificateInfoForm.ShowDialog()

                    End If
                End If
            End If

            'If we have gotten this far without an exception then we are connected.
            Return True

            'Handle the various exceptions that could occur.
        Catch x As WebException
            MsgBox(Globals.globalRM.GetString("exception_web") & ": " & Globals.globalRM.GetString("error_connection_connect") & vbNewLine & x.Message)
        Catch x As WsusInvalidServerException
            MsgBox(Globals.globalRM.GetString("exception_wsus_invalid_server") & ": " & Globals.globalRM.GetString("error_connection_connect") & vbNewLine & x.Message)
        Catch x As SecurityException
            MsgBox(Globals.globalRM.GetString("exception_security") & ": " & Globals.globalRM.GetString("error_connection_connect_security") & vbNewLine & x.Message)
        Catch x As UriFormatException
            MsgBox(Globals.globalRM.GetString("exception_URI_format") & ": " & Globals.globalRM.GetString("error_connection_connect_URI") & vbNewLine & x.Message)
        End Try

        'If we got this far then we failed to connect.
        My.Forms.MainForm.Status = Globals.globalRM.GetString("error_connection_connect")
        My.Forms.MainForm.Update()
        Return False
    End Function 'Connect

    ''' <summary>
    ''' Check the API version of the client and server.
    ''' </summary>
    Public Shared Sub CheckAPIVersion()



        Dim serverVersion As Version = m_currentServer.Version

        Dim a As Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Assembly.GetExecutingAssembly()
        For Each an As AssemblyName In a.GetReferencedAssemblies()
            If an.Name = "Microsoft.UpdateServices.Administration" Then
                Dim clientVersion As Version = New Version(FileVersionInfo.GetVersionInfo(Assembly.ReflectionOnlyLoad(an.ToString).Location).FileVersion)

                If Not serverVersion = clientVersion Then
                    MsgBox("The version of the client WSUS API does not match the server.  You will be unable to publish updates." & vbNewLine & "Server: " & serverVersion.ToString & vbNewLine & "Client: " & clientVersion.ToString)
                End If


            End If


        Next
    End Sub

    ''' <summary>
    ''' Wait until a connection is made or the timeout is reached.
    ''' </summary>
    ''' <param name="timeOut">Number of seconds to wait for connection.</param>
    Public Shared Sub WaitForConnection(timeOut As Integer)
        Dim startTime As DateTime = DateTime.Now

        Do
            System.Threading.Thread.Sleep(200)
        Loop While (Not Connected AndAlso DateTime.Now.Subtract(startTime).Seconds <= timeOut)
    End Sub

    ''' <summary>
    ''' Tests to see if there is a current server connection.
    ''' </summary>
    ''' <value></value>
    ''' <returns>Boolean indicating if a current server connection exists.</returns>
    Public Shared ReadOnly Property Connected() As Boolean
        Get
            If CurrentServer Is Nothing Or CurrentServerConfiguration Is Nothing Then
                Return False
            Else
                Return True
            End If
        End Get
    End Property
#End Region

#Region "Software Definition Packages"

    ''' <summary>
    ''' Export an SDP XML file from the parent server.
    ''' </summary>
    ''' <param name="updateRevisionId">UpdateRevisionId of the package to be exported.</param>
    ''' <returns>String holding the path to the SDP XMP file that was exported.</returns>
    Public Shared Function ExportSDP(updateRevisionId As UpdateRevisionId) As String
        Dim packageFile As String
        If ConnectionManager.Connected Then
            Try

                'Export the SDP to a temporary file.
                packageFile = Path.Combine(Path.GetTempPath, updateRevisionId.UpdateId.ToString & ".xml")
                ConnectionManager.ParentServer.ExportPackageMetadata(updateRevisionId, packageFile)
                Return packageFile

            Catch x As InvalidOperationException
                MsgBox(Globals.globalRM.GetString("exception_invalid_operation") & ": " & Globals.globalRM.GetString("error_connection_export_SDP") & vbNewLine & x.Message)
            Catch x As ArgumentNullException
                MsgBox(Globals.globalRM.GetString("exception_argument_null") & ": " & Globals.globalRM.GetString("error_connection_export_SDP") & vbNewLine & x.Message)
            Catch x As ArgumentOutOfRangeException
                MsgBox(Globals.globalRM.GetString("exception_argument_out_of_range") & ": " & Globals.globalRM.GetString("error_connection_export_SDP") & vbNewLine & x.Message)
            Catch x As WsusObjectNotFoundException
                MsgBox(Globals.globalRM.GetString("exception_wsus_object_not_found") & ": " & Globals.globalRM.GetString("error_connection_export_SDP") & vbNewLine & x.Message)
            Catch x As Exception
                MsgBox(Globals.globalRM.GetString("exception") & ": " & Globals.globalRM.GetString("error_connection_export_SDP") & vbNewLine & x.Message)
            End Try
        End If

        Return Nothing
    End Function

    ''' <summary>
    ''' Retrieve a SoftwareDistributionPackage from the current parent server.
    ''' </summary>
    ''' <param name="updateRevisionId">UpdateRevisionID to be retrieved.</param>
    ''' <returns>SoftwareDistributionPackage</returns>
    Public Shared Function GetSDP(updateRevisionId As UpdateRevisionId) As SoftwareDistributionPackage
        Dim tmpSDP As SoftwareDistributionPackage
        Dim packageFile As String
        If ConnectionManager.Connected Then
            Try

                'Export the SDP to a temporary file.
                packageFile = ExportSDP(updateRevisionId)
                tmpSDP = New SoftwareDistributionPackage(packageFile)
                DeleteSDP(packageFile)
                Return tmpSDP

            Catch x As FileNotFoundException
                MsgBox(Globals.globalRM.GetString("exception_file_not_found") & ": " & Globals.globalRM.GetString("error_connection_get_SDP") & vbNewLine & x.Message)
            Catch x As XmlSchemaValidationException
                MsgBox(Globals.globalRM.GetString("exception_XML_schema") & ": " & Globals.globalRM.GetString("error_connection_get_SDP") & vbNewLine & x.Message)
            Catch x As Exception
                MsgBox(Globals.globalRM.GetString("exception") & ": " & Globals.globalRM.GetString("error_connection_get_SDP") & vbNewLine & x.Message)
            End Try
        End If

        Return Nothing
    End Function

    ''' <summary>
    ''' Create an SDP object from the given file path.
    ''' </summary>
    ''' <param name="packageFile">The path to the SDP XML file.</param>
    ''' <returns>SoftwareDistributionPackage</returns>
    Public Shared Function GetSDP(packageFile As String) As SoftwareDistributionPackage
        Dim tmpSDP As SoftwareDistributionPackage

        If ConnectionManager.Connected Then
            Try

                'Export the SDP to a temporary file.
                tmpSDP = New SoftwareDistributionPackage(packageFile)
                Return tmpSDP

            Catch x As FileNotFoundException
                MsgBox(Globals.globalRM.GetString("exception_file_not_found") & ": " & Globals.globalRM.GetString("error_connection_get_SDP") & vbNewLine & x.Message)
            Catch x As XmlSchemaValidationException
                MsgBox(Globals.globalRM.GetString("exception_XML_schema") & ": " & Globals.globalRM.GetString("error_connection_get_SDP") & vbNewLine & x.Message)
            Catch x As Exception
                MsgBox(Globals.globalRM.GetString("exception") & ": " & Globals.globalRM.GetString("error_connection_get_SDP") & vbNewLine & x.Message)
            End Try
        End If

        Return Nothing
    End Function

    ''' <summary>
    ''' Delete the SDP file and ignore any errors.
    ''' </summary>
    ''' <param name="packageFile">Path to file.</param>
    Public Shared Sub DeleteSDP(packageFile As String)

        Try
            My.Computer.FileSystem.DeleteFile(packageFile)
        Catch
        End Try

    End Sub

#End Region

#Region "Certificates"
    Public Shared ReadOnly Property CertExists() As Boolean
        Get
            If CurrentServerCertificate Is Nothing Then
                Return False
            Else
                Return True
            End If
        End Get
    End Property

    ''' <summary>
    ''' Creates a certificate on the WSUS server.  
    ''' </summary>
    ''' <param name="pfxFile">Path to a certificate file.</param>
    ''' <param name="password">Password for opening the certificate file.</param>
    ''' <remarks>
    ''' If the user has provided a certificate path AND a password then import their certificate.
    ''' If the user has provided neither than create a self-signed certificate.  If the user
    ''' has provided one but not the other, error out.
    ''' </remarks>
    Public Shared Sub CreateCert(pfxFile As String, password As SecureString)
        If CertExists Then
            MessageBox.Show(Globals.globalRM.GetString("warning_connection_cert_exists"))
        Else
            Try
                If (pfxFile IsNot Nothing) AndAlso (password IsNot Nothing) Then
                    m_currentServerConfiguration.SetSigningCertificate(pfxFile, password)
                    m_currentServerConfiguration.Save()
                    MessageBox.Show(Globals.globalRM.GetString("success_connection_cert_import"))
                    LoadCert()
                ElseIf pfxFile Is Nothing AndAlso password Is Nothing Then
                    m_currentServerConfiguration.SetSigningCertificate()
                    m_currentServerConfiguration.Save()
                    MessageBox.Show(Globals.globalRM.GetString("success_connection_cert_created"))
                    LoadCert()
                Else
                    MessageBox.Show(Globals.globalRM.GetString("warning_connection_cert_import"))
                End If
                'Handle the exceptions that could occur.
            Catch x As WsusInvalidDataException
                MessageBox.Show(Globals.globalRM.GetString("exception_wsus_invalid_data") & ": " & Globals.globalRM.GetString("error_connection_cert_save") & Environment.NewLine & x.Message)
            Catch x As InvalidOperationException
                MessageBox.Show(Globals.globalRM.GetString("exception_invalid_operation") & ": " & Globals.globalRM.GetString("error_connection_cert_save") & Environment.NewLine & x.Message)
            Catch x As FileNotFoundException
                MessageBox.Show(Globals.globalRM.GetString("exception_file_not_found") & ": " & Globals.globalRM.GetString("error_connection_cert_save") & Environment.NewLine & x.Message)
            Catch x As Win32Exception
                MessageBox.Show(Globals.globalRM.GetString("exception_win32") & ": " & Globals.globalRM.GetString("error_connection_cert_save") & Environment.NewLine & x.Message)
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Loads the certificate from the WSUS server.
    ''' </summary>
    ''' <returns>Boolean that indicates if the certificate was successfully loaded.</returns>
    Public Shared Function LoadCert() As Boolean
        Dim tempFile As String = String.Empty

        Try
            tempFile = Path.GetTempFileName()
        Catch ex As IOException
            MsgBox("ConnectionManager.LoadCert" & vbNewLine & Globals.globalRM.GetString("exception_IO") & ": " & vbNewLine & ex.Message)
            Return False
        Catch ex As SecurityException
            MsgBox("ConnectionManager.LoadCert" & vbNewLine & Globals.globalRM.GetString("exception_security") & ": " & vbNewLine & ex.Message)
            Return False
        Catch ex As UnauthorizedAccessException
            MsgBox("ConnectionManager.LoadCert" & vbNewLine & Globals.globalRM.GetString("exception_unauthorized_access") & ": " & vbNewLine & ex.Message)
            Return False
        End Try

        Try
            m_currentServerConfiguration.GetSigningCertificate(tempFile)
            m_currentServerCertificate = New X509Certificate2(tempFile)
            File.Delete(tempFile)
            Return True
        Catch
            'If there was a problem loading the certificate
            ' then make the cert nothing
            m_currentServerCertificate = Nothing
        End Try

        'If we got this far an exception was thrown so return false
        Return False
    End Function

    ''' <summary>
    ''' Clear the certificate.
    ''' </summary>
    Public Shared Sub ClearCert()
        m_currentServerCertificate = Nothing
    End Sub

    ''' <summary>
    ''' Export the certificate from the WSUS service.
    ''' </summary>
    ''' <param name="fileName"></param>
    Public Shared Sub ExportCert(fileName As String)
        m_currentServerConfiguration.GetSigningCertificate(fileName)
    End Sub
#End Region

#Region "Misc"
    ''' <summary>
    ''' Download a file in smaller pieces.
    ''' </summary>
    ''' <param name="URL">URL to be downloaded.</param>
    ''' <param name="progress">ProgressBar to update.</param>
    ''' <param name="path">File path to save downloaded file to.</param>
    ''' <remarks>Modified from a posting: http://www.vbdotnetforums.com/remoting/82-webclient-download-progress.html</remarks>
    Public Shared Sub DownloadChunks(ByVal URL As Uri, ByVal progress As ProgressBar, ByVal path As String)
        'Dim wRemote As System.Net.WebRequest
        Dim URLReq As WebRequest
        Dim URLRes As WebResponse
        Dim FileStreamer As New FileStream(path, FileMode.Create)
        Dim sChunks As Stream = Nothing
        Dim bBuffer(999) As Byte
        Dim iBytesRead As Integer

        Try
            'By using CreateDefault we can handle both http:// and file://
            ' URIs which allow us to both download from the internet and use
            ' local paths.
            URLReq = WebRequest.CreateDefault(URL)

            'Handle FTP and File URLS.
            If URL.Scheme = "ftp" Then
                URLReq.Method = WebRequestMethods.Ftp.DownloadFile
            ElseIf Not URL.IsFile Then
                'If this is a file url then we do not need credentials.
                URLReq.Proxy.Credentials = CredentialCache.DefaultCredentials
            End If


            URLRes = URLReq.GetResponse
            sChunks = URLReq.GetResponse.GetResponseStream
            progress.Maximum = CInt(URLRes.ContentLength)

            Do
                iBytesRead = sChunks.Read(bBuffer, 0, 1000)
                FileStreamer.Write(bBuffer, 0, iBytesRead)
                If progress.Value + iBytesRead <= progress.Maximum Then
                    progress.Value += iBytesRead
                Else
                    progress.Value = progress.Maximum
                End If
                Application.DoEvents()
            Loop Until iBytesRead = 0
            progress.Value = progress.Maximum
            sChunks.Close()
            FileStreamer.Close()
            'Return sResponseData
        Catch
            If Not sChunks Is Nothing Then sChunks.Close()
            If Not FileStreamer Is Nothing Then FileStreamer.Close()
            MsgBox(String.Format(Globals.globalRM.GetString("error_connection_download"), URL.AbsolutePath) & vbNewLine & Err.Description)
        End Try
    End Sub
#End Region
End Class
