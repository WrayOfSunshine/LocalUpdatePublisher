'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 2/10/2012
' Time: 10:29 AM
'
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports System.ComponentModel
Imports Microsoft.UpdateServices.Administration
Imports System.IO
Imports System.Security
Imports System.Net

Public Class AsyncPublisher
	
	Public Sub New()
	End Sub
	
	#Region "Properties"
	
	Private Shared _bgwPublisher As BackgroundWorker
	
	#End Region
	
	#Region "Events"
	
	Public Shared Event Completed(success As Boolean)
	
	#End Region
	
	#Region "Revise Existing Package"
	Public Shared Sub RevisePackage(sdp As SoftwareDistributionPackage, parentForm As Form)
		Call RevisePackage ( sdp, parentForm, False)
	End Sub
	
	
	'Revise package.
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
			My.Forms.ProgressForm.Location =  New Point(parentForm.Location.X + 100, parentForm.Location.Y + 100)
			My.Forms.ProgressForm.ShowDialog(globalRM.GetString("prompt_connection_wait_revise"), parentForm)
			
			'Setup the bgwPublisher object.
			Call SetupBgwPublisher
			
			'Make the asyncronous call to revise the package.
			_bgwPublisher.RunWorkerAsync( New AsyncPublishingDetails(publisher, PublishMethod.Revise ) )
			
			Exit Sub
			
		Catch x As PathTooLongException
			Msgbox (globalRM.GetString("exception_path_too_long") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
		Catch x As SecurityException
			Msgbox (globalRM.GetString("exception_security") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
		Catch x As UnauthorizedAccessException
			Msgbox (globalRM.GetString("exception_unauthorized_access") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
		Catch x As NotSupportedException
			Msgbox (globalRM.GetString("exception_not_supported") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
		Catch x As ArgumentNullException
			Msgbox (globalRM.GetString("exception_argument_null") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
		Catch x As FileNotFoundException
			Msgbox (globalRM.GetString("exception_file_not_found") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
		Catch x As InvalidDataException
			Msgbox (globalRM.GetString("exception_invalid_data") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
		Catch x As InvalidOperationException
			Msgbox (globalRM.GetString("exception_invalid_operation") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
		Catch x As ArgumentException
			Msgbox (globalRM.GetString("exception_argument") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
		Catch x As IOException
			Msgbox (globalRM.GetString("exception_IO") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
		Catch x As Win32Exception
			Msgbox (globalRM.GetString("exception_win32") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
		End Try
		RaiseEvent Completed( False )
	End Sub
	
	
	'	'Call with no temporary path.
	'	Public Shared Function PublishPackageFromCatalog(sdp As SoftwareDistributionPackage, parentForm As Form) As Boolean'
	'		Return PublishPackageFromCatalog(sdp, parentForm)
	'	End Function
	#End Region
	
	#Region "Publish New Package"
	'Publish package, downloading any files necessary from the installable item.
	Public Shared Sub PublishPackageFromCatalog(sdp As SoftwareDistributionPackage, tmpPath As String, parentForm As Form)
		Dim fileDownloader As New WebClient()
		Dim fileList As IList(Of Object) = New List(Of Object)
		Dim tmpFileUri As Uri = Nothing
		
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
					
					Call PublishPackage(Sdp, fileList, parentForm) 'Publish it.
				Else
					Dim tmpFilePath As String = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), sdp.InstallableItems(0).OriginalSourceFile.FileName )
					'Get download location.
					tmpFileUri = sdp.InstallableItems(0).OriginalSourceFile.OriginUri
					
					'Set cursor and position of progress form.
					My.Forms.ProgressForm.Location =  New Point(My.Forms.MainForm.Location.X + 100, My.Forms.MainForm.Location.Y + 100)
					My.Forms.ProgressForm.ShowDialog(String.Format(globalRM.GetString("status_connection_downloading") , sdp.Title), parentForm)
					My.Forms.ProgressForm.SetCurrentStep(tmpFileUri.ToString)
					
					'Download the file and add it to the file list
					ConnectionManager.DownloadChunks(tmpFileUri, My.Forms.ProgressForm.progressBar, tmpFilePath)
					fileList.Add(New FileInfo(tmpFilePath)) 'Add it to the list.
					
					Call PublishPackage(Sdp, fileList, parentForm) 'Publish it.
					'TODO System.IO.File.Delete(tmpFilePath) 'Delete the temp file.
				End If
				
			Else
				RaiseEvent Completed( False )
			End If
			
			Exit Sub
			
		Catch ex As HttpListenerException
			Console.WriteLine(globalRM.GetString("exception_HTTP_listener") & ": " & vbNewLine & String.Format( globalRM.GetString("error_connection_download") , tmpFileUri.ToString) & vbNewLine & ex.Message)
		Catch ex As Exception
			Console.WriteLine(globalRM.GetString("exception") & ": " & vbNewLine & String.Format( globalRM.GetString("error_connection_download") , tmpFileUri.ToString) & vbNewLine & ex.Message)
		End Try
		RaiseEvent Completed( False )
	End Sub
	
	Public Shared Sub PublishPackageFromCAB( cabFile As FileInfo, parentForm As Form)
		Dim sdpFile As FileInfo = Nothing
		Dim packageCab As FileInfo = Nothing
		
		If cabFile.Exists Then
			Try
				'Extract the CAB to a new temporary path.
				Dim tmpExtract As New CabLib.Extract()
				Dim extractPath As New DirectoryInfo(Path.Combine(Path.GetTempPath, Path.GetRandomFileName))
				tmpExtract.ExtractFile(cabFile.FullName, extractPath.ToString)
				
				'Loop through the temp folder and find the XML and CAB files.
				For Each tmpFile As FileInfo In extractPath.GetFiles
					If tmpFile.Extension = ".xml" Then
						sdpFile = tmpFile
					Else If tmpFile.Extension = ".cab" Then
						packageCab = tmpFile
					End If
				Next
				
				'Make sure an SDP and CAB file were found.
				If sdpFile Is Nothing Then
					Msgbox (globalRM.GetString("error_connection_no_XML"))
					RaiseEvent Completed( False )
				Else If packageCab Is Nothing Then
					Msgbox (globalRM.GetString("error_connection_no_cab"))
					RaiseEvent Completed( False )
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
				sdpFile.Delete
				
				'Setup and show the progress form.
				My.Forms.ProgressForm.Location =  New Point(parentForm.Location.X + 100, parentForm.Location.Y + 100)
				My.Forms.ProgressForm.ShowDialog(globalRM.GetString("prompt_connection_wait"), parentForm)
				
				'Setup the bgwPublisher object.
				Call SetupBgwPublisher
				
				'Make the asyncronous call to publish the package.
				_bgwPublisher.RunWorkerAsync( New AsyncPublishingDetails(publisher, PublishMethod.PublishCAB, packageCab) )
				
				'TODO: The extract path itself doesn't get deleted by the asyncronous method but the SDP and CAB files themseles will.
				Exit Sub
				
			Catch x As PathTooLongException
				Msgbox (globalRM.GetString("exception_path_too_long") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
			Catch x As SecurityException
				Msgbox (globalRM.GetString("exception_security") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
			Catch x As UnauthorizedAccessException
				Msgbox (globalRM.GetString("exception_unauthorized_access") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
			Catch x As NotSupportedException
				Msgbox (globalRM.GetString("exception_not_supported") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
			Catch x As ArgumentNullException
				Msgbox (globalRM.GetString("exception_argument_null") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
			Catch x As FileNotFoundException
				Msgbox (globalRM.GetString("exception_file_not_found") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
			Catch x As InvalidDataException
				Msgbox (globalRM.GetString("exception_invalid_data") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
			Catch x As InvalidOperationException
				Msgbox (globalRM.GetString("exception_invalid_operation") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
			Catch x As ArgumentException
				Msgbox (globalRM.GetString("exception_argument") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
			Catch x As IOException
				Msgbox (globalRM.GetString("exception_IO") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
			Catch x As Win32Exception
				Msgbox (globalRM.GetString("exception_win32") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
			End Try
			
			RaiseEvent Completed( False )
		End If
		
	End Sub
	
	'Publish package metadata without any files.
	Public Shared Sub PublishPackageMetaData(sdp As SoftwareDistributionPackage, parentForm As Form)
		Call PublishPackage (sdp, Nothing, parentForm)
	End Sub
	
	'Publish package with list of files and directories.
	Public Shared Sub PublishPackage(sdp As SoftwareDistributionPackage, updateFiles As IList (Of Object), parentForm As Form)
		
		Try
			
			'Save the SDP, use it to create a publisher object, and then delete it.
			Dim sdpFilePath As String = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), sdp.PackageId.ToString() & ".xml")
			sdp.Save(sdpFilePath)
			Dim publisher As IPublisher = ConnectionManager.ParentServer.GetPublisher(SdpFilePath)
			File.Delete(SdpFilePath)
			
			'If no files were passed in then only publish the metadata.
			If updateFiles Is Nothing Then publisher.MetadataOnly = True
			
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
			
			
			'Setup and show the progress form.
			My.Forms.ProgressForm.Location =  New Point(parentForm.Location.X + 100, parentForm.Location.Y + 100)
			My.Forms.ProgressForm.Show(globalRM.GetString("prompt_connection_wait"), parentForm)
			
			'Setup the bgwPublisher object.
			Call SetupBgwPublisher
			
			'Make the asyncronous call to publish the package.
			_bgwPublisher.RunWorkerAsync( New AsyncPublishingDetails(publisher, PublishMethod.Publish, updateDir) )
			
			Exit Sub
		Catch x As PathTooLongException
			Msgbox (globalRM.GetString("exception_path_too_long") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
		Catch x As SecurityException
			Msgbox (globalRM.GetString("exception_security") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
		Catch x As UnauthorizedAccessException
			Msgbox (globalRM.GetString("exception_unauthorized_access") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
		Catch x As NotSupportedException
			Msgbox (globalRM.GetString("exception_not_supported") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
		Catch x As ArgumentNullException
			Msgbox (globalRM.GetString("exception_argument_null") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
		Catch x As FileNotFoundException
			Msgbox (globalRM.GetString("exception_file_not_found") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
		Catch x As InvalidDataException
			Msgbox (globalRM.GetString("exception_invalid_data") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
		Catch x As InvalidOperationException
			Msgbox (globalRM.GetString("exception_invalid_operation") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
		Catch x As ArgumentException
			Msgbox (globalRM.GetString("exception_argument") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
		Catch x As IOException
			Msgbox (globalRM.GetString("exception_IO") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
		Catch x As Win32Exception
			Msgbox (globalRM.GetString("exception_win32") & ": " & globalRM.GetString("error_connection_manager_publish") & vbNewLine & x.Message)
		End Try
		
		RaiseEvent Completed( False )
	End Sub
	
	#End Region
	
	#Region "BackGroundWorker Details"
	Private Shared Sub _bgwPublisherDoWork(sender As Object, e As DoWorkEventArgs)
		
		'Make sure an argument was passed and that it is a PublishignDetails object.
		If Not e.Argument Is Nothing AndAlso TypeOf e.Argument Is AsyncPublishingDetails Then
			Dim tmpPublishingDetails As AsyncPublishingDetails = DirectCast ( e.Argument, AsyncPublishingDetails )
			
			'Make sure that a publisher was set as well as the update directory.
			If Not tmpPublishingDetails.Publisher Is Nothing Then
				
				'Add the event handler to the publisher to show progress.
				AddHandler tmpPublishingDetails.Publisher.ProgressHandler, AddressOf PublisherProgressHandler
				
				'Publishing the package based on the publishing method
				Select Case tmpPublishingDetails.PublishMethod
					Case PublishMethod.Publish
						If Not tmpPublishingDetails.UpdateDir Is Nothing
							tmpPublishingDetails.Publisher.PublishPackage(tmpPublishingDetails.UpdateDir.FullName, Nothing, Nothing)
						End If
					Case PublishMethod.PublishCAB
						If Not tmpPublishingDetails.UpdateFile Is Nothing
							tmpPublishingDetails.Publisher.PublishSignedPackage(tmpPublishingDetails.UpdateFile.FullName, Nothing)
						End If
					Case PublishMethod.Revise
						tmpPublishingDetails.Publisher.RevisePackage
					Case Else
						'TODO:Not sure if I need to do something here.
				End Select
				
				'Send the argument on as the result.
				e.Result = e.Argument
			End If
		End If
	End Sub
	
	Private Shared Sub _bgwPublisherProgressChanged(sender As Object, e As ProgressChangedEventArgs)
		
		'If the UserState object is instantiated and a PublishingEventArgs then update the progress form.
		If Not e.UserState Is Nothing And TypeOf e.UserState Is Microsoft.UpdateServices.Administration.PublishingEventArgs Then
			Dim tmpPublishingEventArgs As PublishingEventArgs = DirectCast( e.UserState, PublishingEventArgs )
			
			With My.Forms.ProgressForm
				.SetCurrentStep(tmpPublishingEventArgs.ProgressStep.ToString)
				.progressBar.Maximum = CInt(tmpPublishingEventArgs.UpperProgressBound)
				.progressBar.Value = CInt(tmpPublishingEventArgs.CurrentProgress)
				.progressBar.Refresh
				.Refresh
			End With
			
		End If
	End Sub
	
	'If
	Private Shared Sub _bgwPublisherRunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
		
		If e.Cancelled Or Not e.Error Is Nothing Then
			RaiseEvent Completed( False )
		Else
			
			My.Forms.ProgressForm.Dispose
			'Make sure the result was set and that it is a PublishignDetails object.
			If Not e.Result Is Nothing AndAlso TypeOf e.Result Is AsyncPublishingDetails Then
				Dim tmpPublishingDetails As AsyncPublishingDetails = DirectCast ( e.Result, AsyncPublishingDetails )
				
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
							tmpPublishingDetails.UpdateFile.Delete 'Remove the update directory from the temp folder.
						Catch
						End Try
					End If
				End If
			End If
			
			RaiseEvent Completed( True )
		End If
	End Sub
	
	'Handle the progress of the publisher object by updating the progress form.
	Private Shared Sub PublisherProgressHandler (sender As Object, e As Microsoft.UpdateServices.Administration.PublishingEventArgs)
		_bgwPublisher.ReportProgress(0,e)
	End Sub
	
	'Instantiage the bgwPublisher object if it hasn't been done so already.
	Private Shared Sub SetupBgwPublisher
		
		If _bgwPublisher Is Nothing Then
			_bgwPublisher = New System.ComponentModel.BackgroundWorker
			_bgwPublisher.WorkerReportsProgress = True
			AddHandler _bgwPublisher.DoWork, AddressOf _bgwPublisherDoWork
			AddHandler _bgwPublisher.ProgressChanged, AddressOf _bgwPublisherProgressChanged
			AddHandler _bgwPublisher.RunWorkerCompleted, AddressOf _bgwPublisherRunWorkerCompleted
		End If
		
	End Sub
	#End Region
	
	#Region "Misc"
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
			Msgbox (globalRM.GetString("error_connection_copy_directory") & ": " & vbNewline & sourceDirectoryName)
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
		_publisher = publisher
		_publishMethod = publishMethod
		_updateDir = updateDir
	End Sub
	
	Public Sub New(publisher As IPublisher, publishMethod As PublishMethod, updateDir As DirectoryInfo)
		_publisher = publisher
		_publishMethod = publishMethod
		_updateDir = updateDir
	End Sub
	
	Public Sub New(publisher As IPublisher, publishMethod As PublishMethod, updateFile As FileInfo)
		_publisher = publisher
		_publishMethod = publishMethod
		_updateFile = updateFile
	End Sub
	
	#Region "Properties"
	Private _publisher As IPublisher
	Public Property Publisher() As IPublisher
		Get
			Return _publisher
		End Get
		Set
			_publisher = Value
		End Set
	End Property
	
	Private _publishMethod As PublishMethod
	Public Property PublishMethod() As  PublishMethod
		Get
			Return _publishMethod
		End Get
		Set
			_publishMethod = Value
		End Set
	End Property
	
	Private _updateDir As DirectoryInfo
	Public Property UpdateDir() As  DirectoryInfo
		Get
			Return _updateDir
		End Get
		Set
			_updateDir = Value
		End Set
	End Property
	
	Private _updateFile As FileInfo
	Public Property UpdateFile() As  FileInfo
		Get
			Return _updateFile
		End Get
		Set
			_updateFile = Value
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
