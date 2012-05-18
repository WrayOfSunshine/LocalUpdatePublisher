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

Imports System.Net
Imports System.Security
Imports System.ComponentModel
Imports Microsoft.UpdateServices.Administration
Imports System.Security.Cryptography.X509Certificates
'Imports System.Security.Cryptography.DSACryptoServiceProvider
'Imports System.Security.Cryptography.RSACryptoServiceProvider
Imports System.IO
Imports System.Xml.Schema


Friend NotInheritable Class ConnectionManager
	Private Sub New()
	End Sub
	
	#Region "Properties"
	Private Shared  _serverCollection As UpdateServerCollection
	Public Shared ReadOnly Property ServerCollection()  As UpdateServerCollection
		Get
			Return _serverCollection
		End Get
	End Property
	
	Private Shared _parentServer As IUpdateServer
	Public Shared ReadOnly Property ParentServer()  As IUpdateServer
		Get
			Return _parentServer
		End Get
	End Property
	
	Private Shared  _currentServer As IUpdateServer
	Public Shared ReadOnly Property CurrentServer()  As IUpdateServer
		Get
			Return _currentServer
		End Get
	End Property
	
	Private Shared  _currentServerConfiguration As IUpdateServerConfiguration
	Public Shared ReadOnly Property CurrentServerConfiguration()  As IUpdateServerConfiguration
		Get
			Return _currentServerConfiguration
		End Get
	End Property
	
	Private Shared _currentServerCertificate As X509Certificate
	Public Shared Property CurrentServerCertificate() As X509Certificate
		Get
			Return _currentServerCertificate
		End Get
		Private Set
			_currentServerCertificate = Value
		End Set
	End Property
	#End Region
	
	#Region "Connection"
	Public Shared Sub LoadServerList()
		_serverCollection = appSettings.UpdateServers
		'If there are no servers then prompt for initial connection info.
		If _serverCollection.Count = 0 Then
			My.Forms.ConnectionSettingsForm.Location =  New Point(My.Forms.MainForm.Location.X + 100, _
				My.Forms.MainForm.Location.Y + 100)
			
			Dim DialogReturn As DialogResult = My.Forms.ConnectionSettingsForm.ShowDialog
			
			'If user doesn't enter settings then continue.
			If DialogReturn = DialogResult.Cancel Then
				Exit Sub
			End If
		End If
	End Sub
	
	'Connect to server.
	Public Shared Function Connect(server as UpdateServer) As Boolean
		'Set our Global to nothing
		_currentServer = Nothing
		_currentServerConfiguration = Nothing
		ConnectionManager.ClearCert
		
		My.Forms.MainForm.Status = String.Format(globalRM.GetString("status_server_connecting"), server.Name)
		My.Forms.MainForm.Update
		
		Try
			'Connect to the server using the appropriate call.
			If String.IsNullOrEmpty(server.Name) OrElse lcase(server.Name) = "localhost" Then
				_currentServer = AdminProxy.GetUpdateServer()
			Else
				_currentServer = AdminProxy.GetUpdateServer(server.Name,server.Ssl,server.Port)
			End If
			
			'Set the culture for the server.
			Try
				_currentServer.PreferredCulture = appSettings.Culture
			Catch x As ArgumentOutOfRangeException
				'This culture is not supported.
			End Try
			
			'If this is a not a child server then set the parent server to
			' be the current server.
			If Not server.ChildServer Then _parentServer = _currentServer
			
			'Get update server configuration.
			_currentServerConfiguration = _currentServer.GetConfiguration
			My.Forms.MainForm.Status = String.Format(globalRM.GetString("status_server_connected") , _currentServer.Name)
			My.Forms.MainForm.Update
			
			
			'Try to retrieve cert info from server.
			'If there is no cert info, prompt the user to create it.
			If Not ConnectionManager.LoadCert Then
				If server.ChildServer AndAlso Not currentserverconfiguration.IsReplicaServer
					MsgBox (String.Format(globalRM.GetString("error_connection_no_cert"), server.Name))
				Else
					If (MsgBox ( _
						String.Format(globalRM.GetString("error_connection_no_cert"), server.Name) & vbNewLine & globalRM.GetString("prompt_connection_cert"), _
						MsgBoxStyle.YesNo, _
						globalRM.GetString("warning_connection_no_cert")) _
						) = vbYes Then
						My.Forms.MainForm.Status = globalRM.GetString("warning_connection_no_cert")
						My.Forms.MainForm.Update
						
						'Show Cert Info form.
						My.Forms.CertificateInfoForm.ShowDialog
						
					End If
				End If
			End If
			
			'If we have gotten this far without an exception then we are connected.
			Return True
			
			'Handle the various exceptions that could occur.
		Catch x As WebException
			msgbox(globalRM.GetString("exception_web") & ": " & globalRM.GetString("error_connection_connect") & vbNewline & x.Message)
		Catch x As WsusInvalidServerException
			msgbox(globalRM.GetString("exception_wsus_invalid_server") & ": " & globalRM.GetString("error_connection_connect") & vbNewline & x.Message)
		Catch x As SecurityException
			msgbox(globalRM.GetString("exception_security") & ": " & globalRM.GetString("error_connection_connect_security") & vbNewline & x.Message)
		Catch x As UriFormatException
			msgbox(globalRM.GetString("exception_URI_format") & ": " & globalRM.GetString("error_connection_connect_URI") & vbNewline & x.Message)
		End Try
		
		'If we got this far then we failed to connect.
		My.Forms.MainForm.Status = globalRM.GetString("error_connection_connect")
		My.Forms.MainForm.Update
		Return False
	End Function 'Connect
	
	'If we are connected to the server
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
	
	'Return a file path to an SDP file of the given update id.
	Public Shared Function ExportSDP (updateRevisionId As UpdateRevisionId) As String
		Dim packageFile As String
		If ConnectionManager.Connected Then
			Try

				'Export the SDP to a temporary file.
				packageFile = Path.Combine(Path.GetTempPath, updateRevisionId.UpdateId.ToString & ".xml")
				ConnectionManager.ParentServer.ExportPackageMetadata(updateRevisionId, packageFile)
				Return packageFile
				
			Catch x As InvalidOperationException
				Msgbox (globalRM.GetString("exception_invalid_operation") & ": " & globalRM.GetString("error_connection_export_SDP") & vbNewLine & x.Message)
			Catch x As ArgumentNullException
				Msgbox (globalRM.GetString("exception_argument_null") & ": " & globalRM.GetString("error_connection_export_SDP") & vbNewLine & x.Message)
			Catch x As ArgumentOutOfRangeException
				Msgbox (globalRM.GetString("exception_argument_out_of_range") & ": " & globalRM.GetString("error_connection_export_SDP") & vbNewLine & x.Message)
			Catch x As WsusObjectNotFoundException
				Msgbox (globalRM.GetString("exception_wsus_object_not_found") & ": " & globalRM.GetString("error_connection_export_SDP") & vbNewLine & x.Message)
			Catch x As Exception
				Msgbox (globalRM.GetString("exception") & ": " & globalRM.GetString("error_connection_export_SDP") & vbNewline & x.Message)
			End Try
		End If
		
		Return Nothing
	End Function
	
	'Return an SDP object from the given update id.
	Public Shared Function GetSDP (updateRevisionId As UpdateRevisionId) As SoftwareDistributionPackage
		Dim tmpSDP As SoftwareDistributionPackage
		Dim packageFile As String
		If ConnectionManager.Connected Then
			Try
				
				'Export the SDP to a temporary file.
				packageFile = ExportSDP (updateRevisionId)
				tmpSDP = New SoftwareDistributionPackage(packageFile)
				DeleteSDP (packageFile)
				Return tmpSDP
				
			Catch x As FileNotFoundException
				Msgbox (globalRM.GetString("exception_file_not_found") & ": " & globalRM.GetString("error_connection_get_SDP") & vbNewLine & x.Message)
			Catch x As XmlSchemaValidationException
				Msgbox (globalRM.GetString("exception_XML_schema") & ": " & globalRM.GetString("error_connection_get_SDP") & vbNewLine & x.Message)
			Catch x As Exception
				Msgbox (globalRM.GetString("exception") & ": " & globalRM.GetString("error_connection_get_SDP") & vbNewline & x.Message)
			End Try
		End If
		
		Return Nothing
	End Function
	
	'Return an SDP object from the given SDP file.
	Public Shared Function GetSDP ( packageFile As String ) As SoftwareDistributionPackage
		Dim tmpSDP As SoftwareDistributionPackage
		
		If ConnectionManager.Connected Then
			Try
				
				'Export the SDP to a temporary file.
				tmpSDP = New SoftwareDistributionPackage(packageFile)
				Return tmpSDP
				
			Catch x As FileNotFoundException
				Msgbox (globalRM.GetString("exception_file_not_found") & ": " & globalRM.GetString("error_connection_get_SDP") & vbNewLine & x.Message)
			Catch x As XmlSchemaValidationException
				Msgbox (globalRM.GetString("exception_XML_schema") & ": " & globalRM.GetString("error_connection_get_SDP") & vbNewLine & x.Message)
			Catch x As Exception
				Msgbox (globalRM.GetString("exception") & ": " & globalRM.GetString("error_connection_get_SDP") & vbNewline & x.Message)
			End Try
		End If
		
		Return Nothing
	End Function
	
	'Delete the SDP file and ignore any errors.
	Public Shared Sub DeleteSDP ( packageFile As String )
		
		Try
			My.Computer.FileSystem.DeleteFile( packageFile )
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
	
	'This function creates a certificate on the WSUS service.  If the user
	' has provided a certificate path AND a password then import their certificate.
	' If the user has provided neither than create a self-signed certificate.  If the user
	' has provided one but not the other, error out.
	Public Shared Sub CreateCert(pfxFile As String, password As SecureString)
		If CertExists Then
			MessageBox.Show(globalRM.GetString("warning_connection_cert_exists"))
		Else
			Try
				If (pfxFile IsNot Nothing) AndAlso (password IsNot Nothing) Then
					_currentServerConfiguration.SetSigningCertificate(pfxFile, password)
					_currentServerConfiguration.Save()
					MessageBox.Show(globalRM.GetString("success_connection_cert_import"))
					LoadCert()
				ElseIf pfxFile Is Nothing AndAlso password Is Nothing Then
					_currentServerConfiguration.SetSigningCertificate()
					_currentServerConfiguration.Save()
					MessageBox.Show(globalRM.GetString("success_connection_cert_created"))
					LoadCert()
				Else
					MessageBox.Show(globalRM.GetString("warning_connection_cert_import"))
				End If
				'Handle the exceptions that could occur.
			Catch x As WsusInvalidDataException
				MessageBox.Show(globalRM.GetString("exception_wsus_invalid_data") & ": " & globalRM.GetString("error_connection_cert_save") & Environment.NewLine & x.Message)
			Catch x As InvalidOperationException
				MessageBox.Show(globalRM.GetString("exception_invalid_operation") & ": " & globalRM.GetString("error_connection_cert_save") & Environment.NewLine & x.Message)
			Catch x As FileNotFoundException
				MessageBox.Show(globalRM.GetString("exception_file_not_found") & ": " & globalRM.GetString("error_connection_cert_save") & Environment.NewLine & x.Message)
			Catch x As Win32Exception
				MessageBox.Show(globalRM.GetString("exception_win32") & ": " & globalRM.GetString("error_connection_cert_save") & Environment.NewLine & x.Message)
			End Try
		End If
	End Sub
	
	'This function loads the certificate from the WSUS service.
	Public Shared Function LoadCert() As Boolean
		Dim tempFile As String = Path.GetTempFileName()
		Try
			_currentServerConfiguration.GetSigningCertificate(tempFile)
			_currentServerCertificate = X509Certificate.CreateFromCertFile(tempFile)
			File.Delete(tempFile)
			Return True
		Catch
			'If there was a problem loading the certificate
			' then make the cert nothing
			_currentServerCertificate = Nothing
		End Try
		
		'If we got this far an exception was thrown so return false
		Return False
	End Function
	
	'This function clears the certificate.
	Public Shared Sub ClearCert()
		_currentServerCertificate = Nothing
	End Sub
	
	'This function exports the certificate from the WSUS service
	Public Shared Sub ExportCert(fileName As String)
		_currentServerConfiguration.GetSigningCertificate(fileName)
	End Sub
	#End Region
	
	#Region "Misc"
	'Modified from a posting: http://www.vbdotnetforums.com/remoting/82-webclient-download-progress.html
	'Download file and update the Progress Bar.
	Public Shared Sub DownloadChunks(ByVal sURL As Uri, ByVal pProgress As ProgressBar, ByVal Filename As String)
		'Dim wRemote As System.Net.WebRequest
		Dim URLReq As WebRequest
		Dim URLRes As WebResponse
		Dim FileStreamer As New FileStream(Filename, FileMode.Create)
		Dim sChunks As Stream = Nothing
		Dim bBuffer(999) As Byte
		Dim iBytesRead As Integer
		
		Try
			'By using CreateDefault we can handle both http:// and file://
			' URIs which allow us to both download from the internet and use
			' local paths.
			URLReq = WebRequest.CreateDefault(sURL)
			
			'Handle FTP and File URLS.
			If sURL.Scheme = "ftp" Then
				URLReq.Method = WebRequestMethods.Ftp.DownloadFile
			Else If Not sURL.IsFile Then
				'If this is a file url then we do not need credentials.
				URLReq.Proxy.Credentials = CredentialCache.DefaultCredentials
			End If
			
			
			URLRes = URLReq.GetResponse
			sChunks = URLReq.GetResponse.GetResponseStream
			pProgress.Maximum = CInt(URLRes.ContentLength)
			
			Do
				iBytesRead = sChunks.Read(bBuffer, 0, 1000)
				FileStreamer.Write(bBuffer, 0, iBytesRead)
				If pProgress.Value + iBytesRead <= pProgress.Maximum Then
					pProgress.Value += iBytesRead
				Else
					pProgress.Value = pProgress.Maximum
				End If
				Application.DoEvents
			Loop Until iBytesRead = 0
			pProgress.Value = pProgress.Maximum
			sChunks.Close()
			FileStreamer.Close()
			'Return sResponseData
		Catch
			If Not sChunks Is Nothing Then sChunks.Close()
			If Not FileStreamer Is Nothing Then FileStreamer.Close()
			MsgBox(String.Format(globalRM.GetString("error_connection_download") , sURL.AbsolutePath) & vbNewLine & Err.Description)
		End Try
	End Sub
	#End Region
End Class
