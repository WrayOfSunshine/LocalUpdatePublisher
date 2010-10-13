'
' Created by SharpDevelop.
' User: Bryan
' Date: 3/25/2010
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


Public Partial Class ImportCatalogForm
	Private _extractPath As String
	
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
	End Sub
	
	'Populate the DGV with SDPs from the file.
	Public Overloads Function ShowDialog(importFile As String) As DialogResult
		Dim doc As XmlDocument = New XmlDocument
		
		'Clear datasource.
		If Not dgvUpdates.Rows Is Nothing Then dgvUpdates.Rows.Clear
		
		'Verify that a filename was passed in and that is exists.
		If Not String.IsNullOrEmpty(importFile) AndAlso _
			File.Exists(importFile) Then
			
			'Verify that a CAB or XML file was passed.
			'If this is a CAB file then extract it.
			If Strings.Right(importFile, 3).ToLower = "cab" Then
				
				'Extract the file to a new temporary path.
				Dim tmpExtract As CabLib.Extract = New CabLib.Extract()
				_extractPath = Path.Combine(Path.GetTempPath, Path.GetRandomFileName)
				tmpExtract.ExtractFile(importFile, _extractPath)
				importFile = Nothing 'Clear the import file
				
				'Loop through the temp folderand find the XML file.
				For Each tmpFile As String In Directory.GetFiles(_extractPath)
					If Strings.Right(tmpFile, 3).ToLower = "xml" Then
						importFile = tmpFile
						Exit For
					End If
				Next
				
				'Make sure that an XML file was found in the CAB file.
				If String.IsNullOrEmpty(importFile) Then
					Msgbox("No XML file was found in this Cabinet file")
					Return Nothing
				End If
				
			Else If Not Strings.Right(importFile, 3).ToLower = "xml"
				Return Nothing
			End If
			
			'Create the namespace and add the lar and bar namespaces.
			Dim nsmgr As XmlNamespaceManager = New XmlNamespaceManager(New NameTable())
			nsmgr.AddNamespace("", "http://www.w3.org/2001/XMLSchema")
			nsmgr.AddNamespace("smc", "http://schemas.microsoft.com/sms/2005/04/CorporatePublishing/SystemsManagementCatalog.xsd")
			
			'Load the document.
			doc.Load(importFile)
			
			'Loop through each SDP node and load it.
			For Each tmpNode As XmlNode In doc.SelectNodes("smc:SystemsManagementCatalog/smc:SoftwareDistributionPackage",nsmgr)
							
				'We are using the deprecated constructor because the new one gives a validation error for no good reason.
				Dim tmpSdp As SoftwareDistributionPackage = New SoftwareDistributionPackage(tmpNode.CreateNavigator)
				'Add the new row and set the first column's tag as the SDP object.
				Dim tmpRow As Integer = dgvUpdates.Rows.Add(New Object() {False, False, tmpSdp.Title})
				dgvUpdates.Rows(tmpRow).Cells("Include").Tag = tmpSdp
			Next
			
		End If
				
		Return MyBase.ShowDialog
	End Function
	
	'Publish the selected SDPs to the server.
	Sub BtnImportClick(sender As Object, e As EventArgs)
		
		'Loop through each row.
		For Each tmpRow As DataGridViewRow In dgvUpdates.Rows
			
			'If the row is selected and there is an SDP object for it's tag.
			If DirectCast(tmpRow.Cells("Include").Value, Boolean) AndAlso _
				Not tmpRow.Cells("Include").Tag Is Nothing Then
				
				'Import the SDP file based on the metadata flag.
				If DirectCast(tmpRow.Cells("Metadata").Value, Boolean) Then
					ConnectionManager.PublishPackageMetaData(DirectCast(tmpRow.Cells("Include").Tag, SoftwareDistributionPackage))
				Else	
					ConnectionManager.PublishPackageFromCatalog(DirectCast(tmpRow.Cells("Include").Tag, SoftwareDistributionPackage), _extractPath)
				End If
			End If
		Next
	End Sub
	
	'When we close the form, clear any temporary directory created.
	Sub ImportCatalogFormFormClosed(sender As Object, e As FormClosedEventArgs)
		'If a temp directory was created, delete it.
		If Not String.IsNullOrEmpty(_extractPath) AndAlso Directory.Exists(_extractPath) Then 
			Directory.Delete(_extractPath,True)
		End If		
	End Sub
End Class
