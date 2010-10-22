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
Imports System.Security.Cryptography.DSACryptoServiceProvider
Imports System.Security.Cryptography.RSACryptoServiceProvider
Imports System.IO
Imports System.IO.Packaging
Imports System.Xml
Imports System.Xml.Schema
Imports System.Windows.Forms


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
		
		My.Forms.MainForm.Status = "Connecting to " & server.Name
		My.Forms.MainForm.Update
		
		Try
			'Connect to the server using the appropriate call.
			If String.IsNullOrEmpty(server.Name) OrElse lcase(server.Name) = "localhost" Then
				_currentServer = AdminProxy.GetUpdateServer()
			Else
				_currentServer = AdminProxy.GetUpdateServer(server.Name,server.Ssl,server.Port)
			End If
			
			'If this is a not a child server then set the parent server to
			' be the current server.
			If Not server.ChildServer Then _parentServer = _currentServer
			
			'Get update server configuration.
			_currentServerConfiguration = _currentServer.GetConfiguration
			My.Forms.MainForm.Status = "Connected to " & _currentServer.Name
			My.Forms.MainForm.Update
			
			
			'Try to retreive cert info from server.
			'If there is no cert info, prompt the user to create it.
			If Not ConnectionManager.LoadCert Then
				If server.ChildServer AndAlso Not currentserverconfiguration.IsReplicaServer
					MsgBox ( "There is no certificate on " & server.Name &".  " & _
						"Until you create or import a certificate you will not be able to publish updates.")
				Else
					If (MsgBox ( _
						"There is no certificate on " & server.Name &".  " & _
						"Until you create or import a certificate you will not be able to publish updates.  " & _
						"Would you like to do so now?", _
						MsgBoxStyle.YesNo, _
						"No WSUS Certificate found") _
						) = vbYes Then
						My.Forms.MainForm.Status = "Certificate not found"
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
			msgbox("WebException: could not connect to WSUS server." & vbNewline & x.Message)
		Catch x As WsusInvalidServerException
			msgbox("WsusInvalidServerException: could not connect to WSUS server." & vbNewline & x.Message)
		Catch x As SecurityException
			msgbox("SecurityException: you are not permitted to connect to the WSUS server." & vbNewline & x.Message)
		Catch x As UriFormatException
			msgbox("UriFormatException: your servername is not properly formatted." & vbNewline & x.Message)
		End Try
		
		'If we got this far then we failed to connect.
		My.Forms.MainForm.Status = "Failed to connect to server"
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
				Msgbox ("Could not export SDP:" & vbNewLine & "InvalidOperationException: " & x.Message)
			Catch x As ArgumentNullException
				Msgbox ("Could not export SDP:" & vbNewLine & "ArgumentNullException: " & x.Message)
			Catch x As ArgumentOutOfRangeException
				Msgbox ("Could not export SDP:" & vbNewLine & "ArgumentOutOfRangeException: " & x.Message)
			Catch x As WsusObjectNotFoundException
				Msgbox ("Could not export SDP:" & vbNewLine & "WsusObjectNotFoundException: " & x.Message)
			Catch x As Exception
				Msgbox ("Could not export SDP:" & vbNewline & x.Message)
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
				Msgbox ("Could not get SDP:" & vbNewLine & "FileNotFoundException: " & x.Message)
			Catch x As XmlSchemaValidationException
				Msgbox ("Could not get SDP:" & vbNewLine & "XmlSchemaValidationException: " & x.Message)
			Catch x As Exception
				Msgbox ("Could not get SDP:" & vbNewline & x.Message)
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
				Msgbox ("Could not get SDP:" & vbNewLine & "FileNotFoundException: " & x.Message)
			Catch x As XmlSchemaValidationException
				Msgbox ("Could not get SDP:" & vbNewLine & "XmlSchemaValidationException: " & x.Message)
			Catch x As Exception
				Msgbox ("Could not get SDP:" & vbNewline & x.Message)
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
			MessageBox.Show("A certificate already exists.")
		Else
			Try
				If (pfxFile IsNot Nothing) AndAlso (password IsNot Nothing) Then
					_currentServerConfiguration.SetSigningCertificate(pfxFile, password)
					_currentServerConfiguration.Save()
					MessageBox.Show("Your certificate was imported successfully.  " & "This certificate must now be distributed to each client according the Microsofts Local Publsihing documentation.")
					LoadCert()
				ElseIf pfxFile Is Nothing AndAlso password Is Nothing Then
					_currentServerConfiguration.SetSigningCertificate()
					_currentServerConfiguration.Save()
					MessageBox.Show("A self-signed certificate has been created.  " & "This certificate must now be distributed to each client according the Microsofts Local Publsihing documentation.")
					LoadCert()
				Else
					MessageBox.Show("The certificate could not be imported.  " & "You must supply both a certificate file and a password to use an existing certificate.")
				End If
			Catch x As WsusInvalidDataException
				
				'Handle the Objectious exceptions that could occur.
				MessageBox.Show("WsusInvalidDataException: There was an error saving the certificate to the WSUS server." & Environment.NewLine & x.Message)
			Catch x As InvalidOperationException
				MessageBox.Show("InvalidOperationException: There was an error saving the certificate to the WSUS server." & Environment.NewLine & x.Message)
			Catch x As FileNotFoundException
				MessageBox.Show("FileNotFoundException: There was an error saving the certificate to the WSUS server." & Environment.NewLine & x.Message)
			Catch x As Win32Exception
				MessageBox.Show("Win32Exception: There was an error creating the certificate." & Environment.NewLine & x.Message)
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
	
	#Region "Publish Packages"
	
	'Revise package.
	Public Shared Function RevisePackage(sdp As SoftwareDistributionPackage, parentForm As Form) As Boolean
		Dim i_Compress As CabLib.Compress = New CabLib.Compress
		
		Try
			'Save the SDP.
			Dim sdpFilePath As String = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), sdp.PackageId.ToString() & ".xml")
			sdp.Save(sdpFilePath)
			
			'Use the SDP file to create a new publisher.
			Dim publisher As IPublisher = ConnectionManager.ParentServer.GetPublisher(sdpFilePath)
			
			
			'Add the event handler to the publisher to show progress.
			AddHandler publisher.ProgressHandler, AddressOf PublisherProgressHandler
			
			'Set cursor and position of progress form.
			
			My.Forms.ProgressForm.Location =  New Point(My.Forms.MainForm.Location.X + 100, My.Forms.MainForm.Location.Y + 100)
			
			'Show the progress form and publish the revision.
			My.Forms.ProgressForm.ShowDialog("Please wait while the update is revised.", parentForm)
			publisher.RevisePackage
			My.Forms.ProgressForm.Dispose
			RemoveHandler publisher.ProgressHandler, AddressOf PublisherProgressHandler
			publisher = Nothing
			My.Forms.ProgressForm.Dispose
			System.IO.File.Delete(sdpFilePath) 'Delete the SDP file.
			
			Return True
		Catch x As PathTooLongException
			Msgbox ("The package could not be published." & vbNewline & "Path Too Long Exception: " & vbNewLine & x.Message)
		Catch x As SecurityException
			Msgbox ("The package could not be published." & vbNewline & "Security Exception: " & vbNewLine & x.Message)
		Catch x As UnauthorizedAccessException
			Msgbox ("The package could not be published." & vbNewline & "Unauthorized Access Exception: " & vbNewLine & x.Message)
		Catch x As NotSupportedException
			Msgbox ("The package could not be published." & vbNewline & "Not Supported Exception: " & vbNewLine & x.Message)
		Catch x As ArgumentNullException
			Msgbox ("The package could not be published." & vbNewline & "Argument Null Exception: " & vbNewLine & x.Message)
		Catch x As FileNotFoundException
			Msgbox ("The package could not be published." & vbNewline & "File Not Found Exception: " & vbNewLine & x.Message)
		Catch x As InvalidDataException
			Msgbox ("The package could not be published." & vbNewline & "Invalid Data Exception: " & vbNewLine & x.Message)
		Catch x As InvalidOperationException
			Msgbox ("The package could not be published." & vbNewline & "Invalid Operation Exception: " & vbNewLine & x.Message)
		Catch x As ArgumentException
			Msgbox ("The package could not be published." & vbNewline & "Argument Exception: " & vbNewLine & x.Message)
		Catch x As IOException
			Msgbox ("The package could not be published." & vbNewline & "IO Exception: " & vbNewLine & x.Message)
		Catch x As Win32Exception
			Msgbox ("The package could not be published." & vbNewline & "Win32 Exception: " & vbNewLine & x.Message)
		Finally
			My.Forms.ProgressForm.Dispose
		End Try
		Return False
	End Function
'	
'	'Call with no temporary path.
'	Public Shared Function PublishPackageFromCatalog(sdp As SoftwareDistributionPackage, parentForm As Form) As Boolean'
'		Return PublishPackageFromCatalog(sdp, parentForm)
'	End Function
	
	'Publish package, downloading any files necessary from the installable item.
	Public Shared Function PublishPackageFromCatalog(sdp As SoftwareDistributionPackage, tmpPath As String, parentForm As Form) As Boolean
		Dim fileDownloader As New WebClient()
		Dim fileList As IList(Of Object) = New List(Of Object)
		Dim tmpFileUri As Uri = Nothing
		Dim result As Boolean = False		
		
		Try
			'If an installable item exists
			If sdp.InstallableItems.Count > 0 Then
				
				'If there's no URI, a path was given, and it exists then use the
				' files in that path.  Otherwise download the file using the URI.
				If sdp.InstallableItems(0).OriginalSourceFile.OriginUri Is Nothing AndAlso _
					Not String.IsNullOrEmpty(tmpPath) AndAlso _
					Directory.Exists(tmpPath)Then
					
					'Loop through the package's directory and add the files to the list.
					For Each tmpFilePath As String In Directory.GetFiles(Path.Combine(tmpPath , sdp.PackageId.ToString))
						fileList.Add(New FileInfo(tmpFilePath)) 'Add it to the list.
					Next
					
					result = PublishPackage(Sdp, fileList, parentForm) 'Publish it.
				Else
					Dim tmpFilePath As String = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), sdp.InstallableItems(0).OriginalSourceFile.FileName )
					'Get download location.
					tmpFileUri = sdp.InstallableItems(0).OriginalSourceFile.OriginUri
					
					'Set cursor and position of progress form.
					My.Forms.ProgressForm.Location =  New Point(My.Forms.MainForm.Location.X + 100, My.Forms.MainForm.Location.Y + 100)
					My.Forms.ProgressForm.ShowDialog("Downloading files for " & sdp.Title, parentForm)
					My.Forms.ProgressForm.SetCurrentStep(tmpFileUri.ToString)
					DownloadChunks(tmpFileUri, My.Forms.ProgressForm.progressBar, tmpFilePath)
					fileList.Add(New FileInfo(tmpFilePath)) 'Add it to the list.
					
					result = PublishPackage(Sdp, fileList, parentForm) 'Publish it.
					System.IO.File.Delete(tmpFilePath) 'Delete the temp file.
				End If
				
				Return result
			Else
				Return False
			End If
			
		Catch ex As HttpListenerException
			Console.WriteLine("HttpListenerException:" & vbNewLine & "Could not download " & tmpFileUri.ToString & vbNewLine & ex.Message)
		Catch ex As Exception
			Console.WriteLine("Exception:" & vbNewLine & "Could not download " & tmpFileUri.ToString & vbNewLine & ex.Message)
		End Try
		Return False
	End Function
	
	Public Shared Function PublishPackageFromCAB( cabFile As FileInfo, parentForm As Form) As Boolean
		Dim sdpFile As FileInfo = Nothing
		Dim packageCab As FileInfo = Nothing
		
		If cabFile.Exists Then
			
			'Extract the CAB to a new temporary path.
			Dim tmpExtract As New CabLib.Extract()
			Dim extractPath As New DirectoryInfo(Path.Combine(Path.GetTempPath, Path.GetRandomFileName))
			tmpExtract.ExtractFile(cabFile.FullName, extractPath.ToString)
			
			'Loop through the temp folderand find the XML and CAB files.
			For Each tmpFile As FileInfo In extractPath.GetFiles
				If tmpFile.Extension = ".xml" Then
					sdpFile = tmpFile
				Else If tmpFile.Extension = ".cab" Then
					packageCab = tmpFile
				End If
			Next
			
			'Make sure an SDP and CAB file were found.
			If sdpFile Is Nothing Then
				Msgbox ("This file does not contain an XML file.")
				Return False
			Else If packageCab Is Nothing Then
				Msgbox ("This file does not contain a CAB file.")
				Return False
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
			
			Try
				'Use the SDP file to create a new publisher.
				Dim publisher As IPublisher = ConnectionManager.ParentServer.GetPublisher(sdpFile.FullName)
				
				'Add the event handler to the publisher to show progress.
				AddHandler publisher.ProgressHandler, AddressOf PublisherProgressHandler
				
				'Show the progress form and publish the package.
				My.Forms.ProgressForm.ShowDialog("Please wait while the update is published.", parentForm)
				publisher.PublishSignedPackage(packageCab.FullName, Nothing)
				
				My.Forms.ProgressForm.Dispose
				RemoveHandler publisher.ProgressHandler, AddressOf PublisherProgressHandler
				publisher = Nothing
				My.Forms.ProgressForm.Dispose
				extractPath.Delete(True) 'Remove the update directory from the temp folder.
				Return True
				
			Catch x As PathTooLongException
				Msgbox ("The package could not be published." & vbNewline & "Path Too Long Exception: " & vbNewLine & x.Message)
			Catch x As SecurityException
				Msgbox ("The package could not be published." & vbNewline & "Security Exception: " & vbNewLine & x.Message)
			Catch x As UnauthorizedAccessException
				Msgbox ("The package could not be published." & vbNewline & "Unauthorized Access Exception: " & vbNewLine & x.Message)
			Catch x As NotSupportedException
				Msgbox ("The package could not be published." & vbNewline & "Not Supported Exception: " & vbNewLine & x.Message)
			Catch x As ArgumentNullException
				Msgbox ("The package could not be published." & vbNewline & "Argument Null Exception: " & vbNewLine & x.Message)
			Catch x As FileNotFoundException
				Msgbox ("The package could not be published." & vbNewline & "File Not Found Exception: " & vbNewLine & x.Message)
			Catch x As InvalidDataException
				Msgbox ("The package could not be published." & vbNewline & "Invalid Data Exception: " & vbNewLine & x.Message)
			Catch x As InvalidOperationException
				Msgbox ("The package could not be published." & vbNewline & "Invalid Operation Exception: " & vbNewLine & x.Message)
			Catch x As ArgumentException
				Msgbox ("The package could not be published." & vbNewline & "Argument Exception: " & vbNewLine & x.Message)
			Catch x As IOException
				Msgbox ("The package could not be published." & vbNewline & "IO Exception: " & vbNewLine & x.Message)
			Catch x As Win32Exception
				Msgbox ("The package could not be published." & vbNewline & "Win32 Exception: " & vbNewLine & x.Message)
			Finally
				My.Forms.ProgressForm.Dispose
			End Try
			Return False
		End If
		
	End Function
	
	'Publish package metadata without any files.
	Public Shared Function PublishPackageMetaData(sdp As SoftwareDistributionPackage, parentForm As Form) As Boolean
		Return PublishPackage (sdp, Nothing, parentForm)
	End Function
	
	'Publish package with list of files and directories.
	Public Shared Function PublishPackage(sdp As SoftwareDistributionPackage, updateFiles As IList (Of Object), parentForm As Form) As Boolean
		
		'Save the SDP.
		Dim sdpFilePath As String = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), sdp.PackageId.ToString() & ".xml")
		sdp.Save(sdpFilePath)
		
		Try
			'Use the SDP file to create a new publisher.
			Dim publisher As IPublisher = ConnectionManager.ParentServer.GetPublisher(SdpFilePath)
			
			'If no files were passed in then only publish the metadata.
			If updateFiles Is Nothing Then publisher.MetadataOnly = True
			
			'Add the event handler to the publisher to show progress.
			AddHandler publisher.ProgressHandler, AddressOf PublisherProgressHandler
			
			'Set cursor and position of progress form.
			My.Forms.ProgressForm.Location =  New Point(My.Forms.MainForm.Location.X + 100, My.Forms.MainForm.Location.Y + 100)
			
			'Create temporary directory.
			Dim updateDir As DirectoryInfo = New DirectoryInfo (Path.Combine(Environment.GetEnvironmentVariable("TEMP"),sdp.PackageId.ToString()))
			If not updateDir.Exists then updateDir.Create 'Create directory if needed.
			
			'Copy files into the temporary directory if needed.
			If Not publisher.MetadataOnly AndAlso _
				Not updateFiles Is Nothing AndAlso _
				updateFiles.Count > 0 Then
				
				'Add each file or directory to the target directory.
				For Each tmpFileDir As Object In updateFiles
					
					'Copy these using the appropriate method based on their object type.
					If TypeOf tmpFileDir Is FileInfo AndAlso DirectCast(tmpFileDir, FileInfo).Exists Then
						DirectCast(tmpFileDir,FileInfo).CopyTo(Path.Combine(updateDir.FullName , DirectCast(tmpFileDir, FileInfo).Name), True)
					Else If TypeOf tmpFileDir Is DirectoryInfo AndAlso DirectCast(tmpFileDir, DirectoryInfo).Exists Then
						CopyDirectory(DirectCast(tmpFileDir, DirectoryInfo).FullName, Path.Combine(updateDir.FullName , DirectCast(tmpFileDir, DirectoryInfo).Name) )
					End If
				Next
			End If
			
			'Show the progress form and publish the package.
			My.Forms.ProgressForm.ShowDialog("Please wait while the update is published.", parentForm)
			publisher.PublishPackage(updateDir.FullName, Nothing, Nothing)
			My.Forms.ProgressForm.Dispose
			RemoveHandler publisher.ProgressHandler, AddressOf PublisherProgressHandler
			publisher = Nothing
			My.Forms.ProgressForm.Dispose
			File.Delete(SdpFilePath) 'Delete the SDP file.
			updateDir.Delete(True) 'Remove the update directory from the temp folder.
			
			Return True
		Catch x As PathTooLongException
			Msgbox ("The package could not be published." & vbNewline & "Path Too Long Exception: " & vbNewLine & x.Message)
		Catch x As SecurityException
			Msgbox ("The package could not be published." & vbNewline & "Security Exception: " & vbNewLine & x.Message)
		Catch x As UnauthorizedAccessException
			Msgbox ("The package could not be published." & vbNewline & "Unauthorized Access Exception: " & vbNewLine & x.Message)
		Catch x As NotSupportedException
			Msgbox ("The package could not be published." & vbNewline & "Not Supported Exception: " & vbNewLine & x.Message)
		Catch x As ArgumentNullException
			Msgbox ("The package could not be published." & vbNewline & "Argument Null Exception: " & vbNewLine & x.Message)
		Catch x As FileNotFoundException
			Msgbox ("The package could not be published." & vbNewline & "File Not Found Exception: " & vbNewLine & x.Message)
		Catch x As InvalidDataException
			Msgbox ("The package could not be published." & vbNewline & "Invalid Data Exception: " & vbNewLine & x.Message)
		Catch x As InvalidOperationException
			Msgbox ("The package could not be published." & vbNewline & "Invalid Operation Exception: " & vbNewLine & x.Message)
		Catch x As ArgumentException
			Msgbox ("The package could not be published." & vbNewline & "Argument Exception: " & vbNewLine & x.Message)
		Catch x As IOException
			Msgbox ("The package could not be published." & vbNewline & "IO Exception: " & vbNewLine & x.Message)
		Catch x As Win32Exception
			Msgbox ("The package could not be published." & vbNewline & "Win32 Exception: " & vbNewLine & x.Message)
		Finally
			My.Forms.ProgressForm.Dispose
		End Try
		Return False
	End Function
	
	'Copy a complete directory, recursively including any subdirectories.
	Private Shared Sub CopyDirectory(sourceDirectoryName As String, targetDirectoryName As String)
		
		Try
			
			'Create directory if needed.
			Directory.CreateDirectory(targetDirectoryName)
			
			'Copy the files.
			For Each tmpFileName As String In Directory.GetFiles(sourceDirectoryName)
				File.Copy(tmpFileName, Path.Combine(targetDirectoryName,Path.GetFileName(tmpFileName)),True)
			Next
			
			'Copy the directories recursively.
			For Each tmpSubDirectory As String In Directory.GetDirectories(sourceDirectoryName)
				CopyDirectory(tmpSubDirectory, Path.Combine(targetDirectoryName, Path.GetFileName(tmpSubDirectory)))
			Next
			
		Catch
			Msgbox ("Unable to copy directory: " & vbNewline & sourceDirectoryName)
		End Try
		
	End Sub
	
	'Handle the progress of the publisher object by updating
	' the progress form.
	Private Shared Sub PublisherProgressHandler (sender As Object, e As Microsoft.UpdateServices.Administration.PublishingEventArgs)
		With My.Forms.ProgressForm
			.SetCurrentStep(e.ProgressStep.ToString)
			.progressBar.Maximum = CInt(e.UpperProgressBound)
			.progressBar.Value = CInt(e.CurrentProgress)
			.progressBar.Refresh
			.Refresh
		End With
		Application.DoEvents
	End Sub
	
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

			'If this is a file url then we do not need credentials.
			If Not sURL.IsFile Then				
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
			MsgBox("Couldn't download the file." & vbNewLine & Err.Description)
		End Try
	End Sub
	
	#End Region
End Class
