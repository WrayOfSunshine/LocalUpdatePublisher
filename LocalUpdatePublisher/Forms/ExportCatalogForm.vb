'
' Created by SharpDevelop.
' User: Bryan
' Date: 7/19/2010
' Time: 8:46 PM
'
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports Microsoft.UpdateServices.Administration
Imports System.Data
Imports System.IO
Imports System.Xml
Imports System.Xml.XPath
Imports System.Xml.Schema


Public Partial Class ExportCatalogForm
	Private _compactPath As String
	
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
	End Sub
	
	'Populate the DGV with SDPs from the file.
	Public Overloads Function ShowDialog(exportFile As String) As DialogResult
		Dim doc As XmlDocument = New XmlDocument
		
		'Clear datasource.
		If Not dgvUpdates.Rows Is Nothing Then dgvUpdates.Rows.Clear
		
		'Verify that a filename was passed in and that is exists.
		If Not String.IsNullOrEmpty(exportFile) AndAlso _
			File.Exists(exportFile) Then
			
			'Verify that a CAB file was passed.
			If Not Strings.Right(exportFile, 3).ToLower = "cab" Then
				Return Nothing
			End If
			
		End If
		
		Return MyBase.ShowDialog
	End Function
	
	'Publish the selected SDPs to the server.
	Sub BtnExportClick(sender As Object, e As EventArgs)
		'Create the namespace and add the lar and bar namespaces.
		Dim nsmgr As XmlNamespaceManager = New XmlNamespaceManager(New NameTable())
		nsmgr.AddNamespace("", "http://www.w3.org/2001/XMLSchema")
		nsmgr.AddNamespace("smc", "http://schemas.microsoft.com/sms/2005/04/CorporatePublishing/SystemsManagementCatalog.xsd")
		
		'		'Load the document.
		'		doc.Load(exportFile)
		'
		'		'Loop through each SDP node and load it.
		'		For Each tmpNode As XmlNode In doc.SelectNodes("smc:SystemsManagementCatalog/smc:SoftwareDistributionPackage",nsmgr)
		'
		'		Next
		
		
		'Loop through each row.
		For Each tmpRow As DataGridViewRow In dgvUpdates.Rows
			
			'If the row is selected and there is an SDP object for it's tag.
			If DirectCast(tmpRow.Cells("Include").Value, Boolean) AndAlso _
				Not tmpRow.Cells("Include").Tag Is Nothing Then
				
				
			End If
		Next
	End Sub
	
	'When we close the form, clear any temporary directory created.
	Sub ExportCatalogFormFormClosed(sender As Object, e As FormClosedEventArgs)
		'If a temp directory was created, delete it.
		If Not String.IsNullOrEmpty(_compactPath) AndAlso Directory.Exists(_compactPath) Then Directory.Delete(_compactPath,True)
		
	End Sub
	
	'Add an update to the list.
	Sub BtnAddClick(sender As Object, e As EventArgs)
		UpdateSelectionForm.Location = New Point(Me.Location.X + 100 , Me.Location.Y + 100)
		Dim tmpUpdateRevisionId As UpdateRevisionId = UpdateSelectionForm.ShowDialog
		Dim tmpString As String = ""
		Dim packageFile As String = ""
		Dim tmpSDP As SoftwareDistributionPackage
		If Not tmpUpdateRevisionId Is Nothing Then
			Try
				tmpString = ConnectionManager.CurrentServer.GetUpdate(tmpUpdateRevisionId).Title
				
				'Export the SDP to a temporary file.
				packageFile = Path.Combine(Path.GetTempPath, tmpUpdateRevisionId.UpdateId.ToString & ".xml")
				ConnectionManager.ParentServer.ExportPackageMetadata(tmpUpdateRevisionId, packageFile)
				
				tmpSDP = New SoftwareDistributionPackage(packageFile)
				
			Catch x As WsusInvalidDataException
				Msgbox ("Could not add custom GUID:" & vbNewline & _
					"WsusInvalidDataException: " & x.Message)
				Exit Sub
			Catch x As WsusObjectNotFoundException
				Msgbox ("Could not add custom GUID:" & vbNewline & _
					"WsusObjectNotFoundException: " & x.Message)
				Exit Sub
			End Try
			
			'Update the DGV with the updates
			Dim tmpRow As Integer = dgvUpdates.Rows.Add
			dgvUpdates.Rows(tmpRow).Cells("Id").Value = tmpUpdateRevisionId.UpdateId
			dgvUpdates.Rows(tmpRow).Cells("Id").Tag = tmpSDP
			dgvUpdates.Rows(tmpRow).Cells("Include").Value = True
			dgvUpdates.Rows(tmpRow).Cells("Title").Value = tmpString
			
			'If there's in installable item, get the file url.
			If tmpSDP.InstallableItems.Count > 0 AndAlso Not tmpSDP.InstallableItems(0).OriginalSourceFile Is Nothing Then
				dgvUpdates.Rows(tmpRow).Cells("FileURL").Value = tmpSDP.InstallableItems(0).OriginalSourceFile.OriginUri.AbsoluteUri
			End If
			
			dgvUpdates.Refresh
		End If
	End Sub
End Class
