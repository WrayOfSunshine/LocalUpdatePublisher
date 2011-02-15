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
	
	'Export the selected packages.
	Sub BtnExportClick(sender As Object, e As EventArgs)
		Dim packageFile As String
		Dim writer As XmlWriter
		Dim xmlNode As XmlNode
		Dim doc As XmlDocument = New XmlDocument
		Dim tmpCompress As CabLib.Compress
		Dim tmpFile As String
		Dim tmpFileList As ArrayList
		
		
		
		'Select a file and open the export catalog dialog.
		exportFileDialog.Filter = globalRM.GetString("file_filter_cab")
		If exportFileDialog.ShowDialog = DialogResult.Cancel Then
			Exit Sub
		Else If Not Strings.Right(exportFileDialog.FileName, 3).ToLower = "cab" Then
			Msgbox ( globalRM.GetString("error_export_catalog_not_cab"))
			Exit Sub
		End If
		
		'Create the namespace.
		Dim nsmgr As XmlNamespaceManager = New XmlNamespaceManager(New NameTable())
		nsmgr.AddNamespace("", "http://www.w3.org/2001/XMLSchema")
		nsmgr.AddNamespace("smc", "http://schemas.microsoft.com/sms/2005/04/CorporatePublishing/SystemsManagementCatalog.xsd")
		nsmgr.AddNamespace("bar", "http://schemas.microsoft.com/wsus/2005/04/CorporatePublishing/BaseApplicabilityRules.xsd")
		nsmgr.AddNamespace("bt", "http://schemas.microsoft.com/wsus/2005/04/CorporatePublishing/BaseTypes.xsd")
		nsmgr.AddNamespace("cmd", "http://schemas.microsoft.com/wsus/2005/04/CorporatePublishing/Installers/CommandLineInstallation.xsd")
		nsmgr.AddNamespace("lar", "http://schemas.microsoft.com/wsus/2005/04/CorporatePublishing/LogicalApplicabilityRules.xsd")
		nsmgr.AddNamespace("msi", "http://schemas.microsoft.com/wsus/2005/04/CorporatePublishing/Installers/MsiInstallation.xsd")
		nsmgr.AddNamespace("msiar", "http://schemas.microsoft.com/wsus/2005/04/CorporatePublishing/MsiApplicabilityRules.xsd")
		nsmgr.AddNamespace("msp", "http://schemas.microsoft.com/wsus/2005/04/CorporatePublishing/Installers/MspInstallation.xsd")
		nsmgr.AddNamespace("sdp", "http://schemas.microsoft.com/wsus/2005/04/CorporatePublishing/SoftwareDistributionPackage.xsd")
		nsmgr.AddNamespace("usp", "http://schemas.microsoft.com/wsus/2005/04/CorporatePublishing/UpdateServicesPackage.xsd")
		nsmgr.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance")
		
		'Setup temporary XML file and create the XML writer using it.
		tmpFile = Path.Combine(Path.GetTempPath, Path.GetFileNameWithoutExtension(exportFileDialog.FileName) & ".xml")
		writer = New XmlTextWriter(tmpFile, Nothing)
		
		'Write the first element with namespaces.
		writer.WriteStartElement("smc", "SystemsManagementCatalog" , "http://www.w3.org/2001/XMLSchema")
		writer.WriteAttributeString("xmlns", "", Nothing, "http://www.w3.org/2001/XMLSchema")
		writer.WriteAttributeString("xmlns", "smc", Nothing, "http://schemas.microsoft.com/sms/2005/04/CorporatePublishing/SystemsManagementCatalog.xsd")
		writer.WriteAttributeString("xmlns", "bar", Nothing, "http://schemas.microsoft.com/wsus/2005/04/CorporatePublishing/BaseApplicabilityRules.xsd")
		writer.WriteAttributeString("xmlns", "bt", Nothing, "http://schemas.microsoft.com/wsus/2005/04/CorporatePublishing/BaseTypes.xsd")
		writer.WriteAttributeString("xmlns", "cmd", Nothing, "http://schemas.microsoft.com/wsus/2005/04/CorporatePublishing/Installers/CommandLineInstallation.xsd")
		writer.WriteAttributeString("xmlns", "lar", Nothing, "http://schemas.microsoft.com/wsus/2005/04/CorporatePublishing/LogicalApplicabilityRules.xsd")
		writer.WriteAttributeString("xmlns", "msi", Nothing, "http://schemas.microsoft.com/wsus/2005/04/CorporatePublishing/Installers/MsiInstallation.xsd")
		writer.WriteAttributeString("xmlns", "msiar", Nothing, "http://schemas.microsoft.com/wsus/2005/04/CorporatePublishing/MsiApplicabilityRules.xsd")
		writer.WriteAttributeString("xmlns", "msp", Nothing, "http://schemas.microsoft.com/wsus/2005/04/CorporatePublishing/Installers/MspInstallation.xsd")
		writer.WriteAttributeString("xmlns", "sdp", Nothing, "http://schemas.microsoft.com/wsus/2005/04/CorporatePublishing/SoftwareDistributionPackage.xsd")
		writer.WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
		
		'Loop through each row and if it is selected add it to the catalog.
		For Each tmpRow As DataGridViewRow In dgvUpdates.Rows
			packageFile = DirectCast(tmpRow.Cells("File").Value, String)
			
			'If the row is selected and there is an SDP object for its tag.
			If DirectCast(tmpRow.Cells("Include").Value, Boolean) AndAlso _
				Not packageFile Is Nothing AndAlso _
				My.Computer.FileSystem.FileExists(packageFile) Then
				
				'Load the SDP node into the catalog.
				doc.Load(DirectCast(packageFile, String))
				xmlNode = doc.SelectSingleNode("usp:UpdateServicesPackage/usp:SoftwareDistributionPackage", nsmgr)
				writer.WriteRaw(Strings.Replace(xmlNode.OuterXml, "usp:SoftwareDistributionPackage", "smc:SoftwareDistributionPackage"))
				
			End If
		Next
		
		'End first element and close the writer.
		Writer.WriteEndElement
		writer.Close
		
		'Compress the temporary file to the cab.
		tmpCompress = New CabLib.Compress()
		tmpFileList = New ArrayList
		tmpFileList.Add(New String() { tmpFile , Path.GetFileName(tmpFile) })
		tmpCompress.CompressFileList( tmpFileList , exportFileDialog.FileName, True, True, 0)
		
		'Delete the temporary file.
		Try
			My.Computer.FileSystem.DeleteFile( tmpFile )
		Catch
		End Try
		
	End Sub
	
	'When we close the form, clear any temporary data created.
	Sub ExportCatalogFormFormClosed(sender As Object, e As FormClosedEventArgs)
		'If a temp directory was created, delete it.
		If Not String.IsNullOrEmpty(_compactPath) AndAlso Directory.Exists(_compactPath) Then Directory.Delete(_compactPath,True)
		
		'Delete any temp files created.
		For Each tmpRow As DataGridViewRow In Me.dgvUpdates.Rows
			If Not tmpRow.Cells("File").Value Is Nothing Then
				ConnectionManager.DeleteSDP(DirectCast(tmpRow.Cells("File").Value, String ))
			End If
		Next
		
		'Clear datasource.
		If Not dgvUpdates.Rows Is Nothing Then dgvUpdates.Rows.Clear
	End Sub
	
	'Add an update to the list.
	Sub BtnAddClick(sender As Object, e As EventArgs)
		UpdateSelectionForm.Location = New Point(Me.Location.X + 100 , Me.Location.Y + 100)
		
		'Loop through the selected updates and add them.
		For Each tmpUpdate As IUpdate In UpdateSelectionForm.ShowDialog
			
			If AddSDPtoDGV ( ConnectionManager.ExportSDP( tmpUpdate.Id ) ) = False Then
				Msgbox (globalRM.GetString("error_export_catalog_no_url"))
			End If
			
		Next
	End Sub
	
	'Add all of the updates
	Sub BtnAddAllClick(sender As Object, e As EventArgs)
		Dim  errorBool As Boolean = False
		If ConnectionManager.Connected Then
			For Each tmpUpdate As IUpdate In ConnectionManager.CurrentServer.GetUpdates(localUpdatesScope)
				
				'Add the packages and track if any of them were not added.
				If AddSDPtoDGV ( ConnectionManager.ExportSDP( tmpUpdate.Id ) ) = False Then
					errorBool = True
				End If
			Next
			
			'If any of the packages cannot be added, warn the user.
			If errorBool Then
				Msgbox (globalRM.GetString("error_export_catalog_no_url_multiple"))
			End If
		End IF
	End Sub
	
	'If there's in installable item and a file URI then add it to the DGV.
	Private Function AddSDPtoDGV( packageFile As String ) As Boolean
		Dim SDP As SoftwareDistributionPackage = ConnectionManager.GetSDP( packageFile )
		
		
		If SDP.InstallableItems.Count > 0 AndAlso _
			Not SDP.InstallableItems(0).OriginalSourceFile Is Nothing AndAlso _
			Not SDP.InstallableItems(0).OriginalSourceFile.OriginUri Is Nothing AndAlso _
			Not SDP.InstallableItems(0).OriginalSourceFile.OriginUri.AbsoluteUri Is Nothing Then
			
			'Update the DGV with the updates
			Dim tmpRow As Integer = dgvUpdates.Rows.Add
			dgvUpdates.Rows(tmpRow).Cells("Id").Value = SDP.PackageId
			dgvUpdates.Rows(tmpRow).Cells("Id").Tag = SDP
			dgvUpdates.Rows(tmpRow).Cells("File").Value = packageFile
			dgvUpdates.Rows(tmpRow).Cells("Include").Value = True
			dgvUpdates.Rows(tmpRow).Cells("Title").Value = SDP.Title
			dgvUpdates.Refresh
			
			If dgvUpdates.Rows.Count > 0 Then
				Me.btnExport.Enabled = True
			End If
			
			Return True
		Else
			'Delete the package file.
			ConnectionManager.DeleteSDP(packageFile)
			Return False
		End If
		
	End Function
	
End Class
