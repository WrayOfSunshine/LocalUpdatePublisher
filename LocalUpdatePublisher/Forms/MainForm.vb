' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' MainForm
' This is the main form of the project.  From here essentially
' everything else happens.
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 10/21/2009
' Time: 2:49 PM

Imports Microsoft.UpdateServices.Administration
Imports System.Data
Imports System.IO
Imports System.Net
Imports System.Security
Imports System.ComponentModel
Imports System.Security.Cryptography.X509Certificates

Public Partial Class MainForm
	Private _serverNode As TreeNode
	Private _rootNode As TreeNode
	Private _originalValue As String
	Private _noEvents As Boolean
	
	#Region "Properties"
	Private _computerNode As TreeNode
	ReadOnly Property ComputerNode()  As TreeNode
		Get
			Return _computerNode
		End Get
	End Property
	
	Private _vendorCollection As New VendorCollection
	ReadOnly Property VendorCollection() As VendorCollection
		Get
			Return _vendorCollection
		End Get
	End Property
	
	Private _updateNode As TreeNode
	ReadOnly Property UpdateNode()  As TreeNode
		Get
			Return _updateNode
		End Get
	End Property
	
	'If we are connected to the server
	Public Property Status() As String
		Get
			Return toolStripStatusLabel.Text
		End Get
		Set
			toolStripStatusLabel.Text = Value
		End Set
	End Property
	#End Region
	
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		'Initialize the base treenodes
		_updateNode = New TreeNode
		_rootNode = New TreeNode
		_serverNode = New TreeNode
		_computerNode = New TreeNode
		_noEvents = False
		
		'Sort Treeview
		treeView.Sorted = True
		
		'Clear status label.
		toolStripStatusLabel.Text = ""
		
		'Set minimum size to the size at design time.
		Me.MinimumSize = Me.Size
		
		'Hide the header panel by default.
		Me.scHeader.Panel1Collapsed = True
		
		'Set default scope.
		localUpdatesScope = New UpdateScope()
		localUpdatesScope.UpdateSources = UpdateSources.Other 'Show non-Microsoft updates
		
		'Load settings.
		Me.chkApprovedOnly.Checked = appSettings.ApprovedUpdatesOnly
		Me.chkInheritApprovals.Checked = appSettings.InheritApprovals
		Me.chkInheritApprovals.Enabled = Me.chkApprovedOnly.Checked
	End Sub
	
	#REGION "Form Events"
	'Anytime the form is activated, check to see if we are connected and
	' set menu items accordingly.
	Private Sub MainFormActivated(sender As Object, e As EventArgs)
		Call SetToolStrip
	End Sub
	
	'When we load the frame, import the base nodes.
	Private Sub MainFormLoad(sender As Object, e As EventArgs)
		toolStripStatusLabel.Text = "Loading form"
		Me.Update
		_noEvents = True
		Call LoadMainForm
		
		Call SetToolStrip
		_noEvents = False
		toolStripStatusLabel.Text = ""
	End Sub
	
	'Save various details when the form is closing.
	Sub MainFormFormClosing(sender As Object, e As FormClosingEventArgs)
		'Save the current DGV states.
		If Not treeView.SelectedNode Is Nothing AndAlso _
			Not treeView.SelectedNode.Tag Is Nothing Then
			Call SaveDgvState (treeView.SelectedNode)
		End If
		
		'Save the current position
		appSettings.WindowLocation = Me.Location
		
		'Save the currently selected node's path
		If Not treeView.SelectedNode Is Nothing Then
			appSettings.TreePath = treeView.SelectedNode.FullPath
		End If
		
		'Save the settings to file
		settings.SaveSettingsToFile(appSettings)
	End Sub
	
	'When the splitter moved save its position.
	Private Sub SplitContainerSplitterMoved(sender As Object, e As SplitterEventArgs)
		'Save the settings to the settings object depending on the selected node type.
		If Not treeView.SelectedNode Is Nothing AndAlso _
			Not treeView.SelectedNode.Tag Is Nothing Then
			
			If TypeOf treeView.SelectedNode.Tag Is IComputerTargetGroup Then 'Computer Note
				appSettings.ComputerSplitter = Me.splitContainerHorz.SplitterDistance
			Else If TypeOf treeView.SelectedNode.Tag Is IUpdateCategory Then 'Update Node
				appSettings.UpdateSplitter = Me.splitContainerHorz.SplitterDistance
			End If
		End If
		
		
	End Sub
	
	'When the splitter moved save its position.
	Sub SplitContainerVertSplitterMoved(sender As Object, e As SplitterEventArgs)
		appSettings.TreeSplitter = splitContainerVert.SplitterDistance
	End Sub
	
	'When the form is resized save it's state.
	Private Sub MainFormResize(sender As Object, e As EventArgs)
		'Save the window statu to the settings object
		appSettings.WindowState = Me.WindowState
	End Sub
	
	Sub ChkApprovedOnlyCheckedChanged(sender As Object, e As EventArgs)
		'Save the change.
		appSettings.ApprovedUpdatesOnly = Me.chkApprovedOnly.Checked
		
		'Enable/Disable the inherit checkbox appropriately.
		Me.chkInheritApprovals.Enabled = Me.chkApprovedOnly.Checked
		
		'Refresh the computer list.
		If _noEvents = False Then
			Cursor = Cursors.WaitCursor 'Set wait cursor.
			_noEvents = True
			Call RefreshComputerList(True)
			Call LoadComputerGroupStatus
			_noEvents = False
			Cursor = Cursors.Arrow 'Set arrow cursor.
		End If
	End Sub
	
	Sub ChkInheritApprovalsCheckedChanged(sender As Object, e As EventArgs)
		'Save the change.
		appSettings.InheritApprovals = Me.chkInheritApprovals.Checked
		
		'Refresh the computer list.
		If _noEvents = False Then
			Cursor = Cursors.WaitCursor 'Set wait cursor.
			_noEvents = True
			Call RefreshComputerList(True)
			Call LoadComputerGroupStatus
			_noEvents = False
			Cursor = Cursors.Arrow 'Set arrow cursor.
		End If
	End Sub
	
	'Load the update report.
	Sub CboTargetGroupSelectedIndexChanged(sender As Object, e As EventArgs)
		If _noEvents = False Then
			_noEvents = True
			toolStripStatusLabel.Text = "Loading update report"
			Me.Update
			If Not Me._dgvMain.CurrentRow Is Nothing Then
				Call LoadUpdateReport(Me._dgvMain.CurrentRow.Index, True)
			End If
			toolStripStatusLabel.Text = ""
			_noEvents = False
		End If
	End Sub
	
	'Refresh the computer list.
	Sub CboComputerStatusSelectedIndexChanged(sender As Object, e As EventArgs)
		If _noEvents = False Then
			Cursor = Cursors.WaitCursor 'Set wait cursor.
			_noEvents = True
			Call RefreshComputerList(True)
			_noEvents = False
			Cursor = Cursors.Arrow 'Set arrow cursor.
		End If
	End Sub
	
	'Update the appropriate report depending on the type of
	' tree node that is selected.
	Private Sub cboUpdateStatusSelectedIndexChanged(sender As Object, e As EventArgs)
		If _noEvents = False Then
			_noEvents = True
			If Not Me.treeView.SelectedNode Is Nothing AndAlso _
				Not Me.treeView.SelectedNode.Tag Is Nothing AndAlso _
				Me.cboUpdateStatus.SelectedIndex <> -1 AndAlso _
				Not Me._dgvMain.CurrentRow is Nothing Then
				'If type is a ComputerTargetGroup load the computers in the DGV.
				If TypeOf Me.treeView.SelectedNode.Tag Is IComputerTargetGroup Then
					toolStripStatusLabel.Text = "Loading computer report"
					Me.Update
					Call LoadComputerReport(Me._dgvMain.CurrentRow.Index, True)
					
					'If type is an update node.
				Else If TypeOf Me.treeView.SelectedNode.Tag Is IUpdateCategory Then
					toolStripStatusLabel.Text = "Loading update report"
					Me.Update
					Call LoadUpdateReport(Me._dgvMain.CurrentRow.Index, True)
				End If
				toolStripStatusLabel.Text = ""
			End If
			_noEvents = False
		End If
	End Sub
	
	'Refresh computer report.
	Sub BtnComputerRefreshReportClick(sender As Object, e As EventArgs)
		Cursor = Cursors.WaitCursor 'Set wait cursor.
		
		'Save the state.
		SaveDGVState(dgvComputerReport)
		
		_noEvents = True
		toolStripStatusLabel.Text = "Loading computer report"
		Me.Update
		If Not Me._dgvMain.CurrentRow Is Nothing Then
			Call LoadComputerReport(Me._dgvMain.CurrentRow.Index, True)
		End If
		toolStripStatusLabel.Text = ""
		_noEvents = False
		Cursor = Cursors.Arrow 'Set arrow cursor.
	End Sub
	
	
	'Refresh update report.
	Sub BtnUpdateRefreshReportClick(sender As Object, e As EventArgs)
		Cursor = Cursors.WaitCursor 'Set wait cursor.
		
		'Save the state.
		SaveDGVState(dgvUpdateReport)
		
		_noEvents = True
		toolStripStatusLabel.Text = "Loading update report"
		Me.Update
		
		If Not Me.DgvMain.CurrentRow Is Nothing Then
			Call LoadUpdateReport(Me._dgvMain.CurrentRow.Index, True)
		End If
		
		toolStripStatusLabel.Text = ""
		_noEvents = False
		Cursor = Cursors.Arrow 'Set arrow cursor.
	End Sub
	
	'Refresh computer list.
	Sub BtnComputerListRefreshClick(sender As Object, e As EventArgs)
		Cursor = Cursors.WaitCursor 'Set wait cursor.
		
		'Save the state.
		SaveDGVState(_dgvMain)
		
		_noEvents = True
		Call RefreshComputerList(True)
		_noEvents = False
		Cursor = Cursors.Arrow 'Set arrow cursor.
	End Sub
	
	'Open the list of prerequisite updates.
	Sub LblPrerequisitesClick(sender As Object, e As EventArgs)
		If Not Me._dgvMain.CurrentRow Is Nothing Then
			PrerequisiteUpdatesForm.ShowDialog(DirectCast(Me._dgvMain.CurrentRow.Cells("IUpdate").Value, IUpdate))
		End If
	End Sub
	
	'Open the list of superseded updates.
	Sub LblSupersedesClick(sender As Object, e As EventArgs)
		If Not Me._dgvMain.CurrentRow Is Nothing Then
			SupersededUpdatesForm.ShowDialog(DirectCast(Me._dgvMain.CurrentRow.Cells("IUpdate").Value, IUpdate))
		End If
	End Sub
	
	Sub ToolStripStatusLabelLinkClick(sender As Object, e As EventArgs)
		'Launch home page
		System.Diagnostics.Process.Start("http://www.localupdatepublisher.com")
	End Sub
	
	#End Region
	
	#Region "Form Methods"
	Sub LoadMainForm
		Me.Cursor = Cursors.WaitCursor 'Set wait cursor.
		Me.Location = appSettings.WindowLocation
		Me.WindowState = DirectCast(appSettings.WindowState, FormWindowState)
		splitContainerVert.SplitterDistance = appSettings.TreeSplitter
		
		Call ClearForm
		
		'Add the the base nodes.
		_rootNode = Me.treeView.Nodes.Add("root", "Update Services")
		
		'Load tree with server nodes.
		For Each server As UpdateServer In ConnectionManager.ServerCollection
			Dim tmpServerName As String
			
			'If connecting to a local server show localhost as the name.
			If String.IsNullOrEmpty(server.Name) Then
				tmpServerName = "localhost"
			Else
				tmpServerName = server.Name
			End If
			
			Dim tmpNode As TreeNode= _rootNode.Nodes.Add(tmpServerName, ucase(tmpServerName))
			tmpNode.Tag = server
		Next
		
		'If the user wants to remember the tree path and
		' there is a saved tree path then load it
		' after removing the root node from the beginning.
		' Otherwise just expand the root node.
		If appSettings.RememberTreePath = False Or _
			String.IsNullOrEmpty (appSettings.TreePath) Or _
			appSettings.TreePath.Trim = _rootNode.Text.Trim Then
			_rootNode.Expand
		Else
			_rootNode.Expand
			Me.Refresh
			treeView.BeginUpdate
			Call SelectNode (_rootNode, Strings.Right(appSettings.TreePath, appSettings.TreePath.Length - (_rootNode.Text.Length + 1)))
			treeView.EndUpdate
		End If
		
		Me.Cursor = Cursors.Arrow 'Set arrow cursor.
	End Sub
	
	'Recall the node that was previously selected.
	Sub SelectNode (node As TreeNode, path As String)
		Dim nodeValue As String= path.Split("\"c)(0)
		Dim foundNode as TreeNode = Nothing
		
		'Loop through the node's children to find the correct node,
		' select it, set the foundNode, and exit the loop.
		For Each tmpNode As TreeNode In node.Nodes
			If tmpNode.Text.Trim = nodeValue.Trim Then
				foundNode = tmpNode
				
				'Only select the server nodes so that they are loaded or
				' the final node we are looking for.
				If Not tmpNode.Tag Is Nothing Then
					If TypeOf tmpNode.Tag Is UpdateServer Or _
						tmpNode.Text.Trim = path.Trim Then
						Me.Update
						treeView.SelectedNode = tmpNode
						Me.Update
					End If
				End If
				
				tmpNode.Expand
				Exit For
			End If
		Next
		
		'If we found a node and there's more levels in the path continue.
		If Not foundNode Is Nothing And path.Contains("\") Then
			Call SelectNode(foundNode, Strings.Right(Path, path.Length - (nodeValue.Length + 1)))
		End If
		
	End Sub
	
	'Call Clear Form with defaults settings.
	Sub ClearForm
		Call ClearForm(True)
	End Sub
	
	'Clear the form including the treview depending on the boolean.
	Sub ClearForm( clearTreeView As Boolean)
		_noEvents = True
		
		'Clear the form.
		
		If clearTreeView then
			treeView.Nodes.Clear
			_rootNode = Nothing
			_serverNode = Nothing
			_updateNode = Nothing
		End If
		
		scHeader.Panel1Collapsed = True
		pnlUpdates.Visible = False
		pnlComputers.Visible = False
		Refresh
		
		_dgvMain.DataSource = Nothing
		
		_noEvents = False
	End Sub
	
	'Clear the update tab
	Sub ClearUpdateInfo
		Call ClearAllControls( Me.tabUpdateInfo.Controls )
	End Sub
	
	'Clear the computer tab
	Sub ClearComputerInfo
		Call ClearAllControls( Me.tabComputerInfo.Controls)
	End Sub
	
	'This code is lifted and modified from StackOverFlow.com
	'http://stackoverflow.com/questions/199521/vb-net-iterating-through-controls-in-a-container-object
	'It loops through a Control Collection and clears everything based on the control type.  An optional boolean
	' dictates if the sub calls itself recursively on any panels or groups it finds.
	Sub ClearAllControls(ByRef container As System.Windows.Forms.Control.ControlCollection, Optional Recurse As Boolean = True)
		'Clear all of the controls within the container object
		
		If container Is Nothing Then Exit Sub
		
		For Each ctrl As Control In container
			If (ctrl.GetType() Is GetType(TextBox)) Then
				Dim txt As TextBox = CType(ctrl, TextBox)
				txt.Text = String.Empty
			End If
			If (ctrl.GetType() Is GetType(CheckBox)) Then
				Dim chkbx As CheckBox = CType(ctrl, CheckBox)
				chkbx.Checked = False
			End If
			If (ctrl.GetType() Is GetType(ComboBox)) Then
				Dim cbobx As ComboBox = CType(ctrl, ComboBox)
				cbobx.SelectedIndex = -1
			End If
			If (ctrl.GetType() Is GetType(DateTimePicker)) Then
				Dim dtp As DateTimePicker = CType(ctrl, DateTimePicker)
				dtp.Value = Now()
			End If
			If (ctrl.GetType() Is GetType(DataGridView)) Then
				Dim dgv As DataGridView = CType(ctrl, DataGridView)
				dgv.DataSource = Nothing
			End If
			
			'If "Recurse" is true, then also clear controls within any sub-containers
			If Recurse Then
				If (ctrl.GetType() Is GetType(Panel)) Then
					Dim pnl As Panel = CType(ctrl, Panel)
					ClearAllControls(pnl.Controls, Recurse)
				End If
				If ctrl.GetType() Is GetType(GroupBox) Then
					Dim grbx As GroupBox = CType(ctrl, GroupBox)
					ClearAllControls(grbx.Controls, Recurse)
				End If
				If ctrl.GetType Is GetType(TabPage) Then
					Dim tbpg As TabPage = CType(ctrl, TabPage)
					ClearAllcontrols(tbpg.Controls, Recurse)
				End If
			End If
		Next
	End Sub
	
	
	#End Region
	
	#Region "Form Menu Events"
	
	'Import updates from a catalog.
	Sub ImportCatalogToolStripMenuItemClick(sender As Object, e As EventArgs)
		
		ImportCatalogForm.Location =  New Point(Me.Location.X + 100, Me.Location.Y + 100)
		
		'Select a file and open the import catalog dialog.
		importFileDialog.Filter = "CAB File|*.cab|XML File|*.xml"
		If Not importFileDialog.ShowDialog = DialogResult.Cancel Then
			My.Forms.ImportCatalogForm.ShowDialog(importFileDialog.FileName)
			Call LoadUpdateNodes()
			Call RefreshUpdateList()
		End If
	End Sub
	
	'Export updates to a catalog.
	Sub ExportCatalogToolStripMenuItemClick(sender As Object, e As EventArgs)
		ExportCatalogForm.Location =  New Point(Me.Location.X + 100, Me.Location.Y + 100)
		
		'Select a file and open the export catalog dialog.
		exportFileDialog.Filter = "CAB File|*.cab"
		If Not exportFileDialog.ShowDialog = DialogResult.Cancel Then
			My.Forms.ExportCatalogForm.ShowDialog(exportFileDialog.FileName)
		End If
	End Sub
	
	'Exit the program.
	Private Sub ExitToolStripMenuItemClick(sender As Object, e As EventArgs)
		Me.Close
	End Sub
	
	'Export the list from the main datagridview.
	Sub ExportListToolStripMenuItemClick(sender As Object, e As EventArgs)
		'Make sure a computer tree node it selected
		If Not treeView.SelectedNode Is Nothing AndAlso _
			Not treeView.SelectedNode.Tag Is Nothing AndAlso _
			TypeOf treeView.SelectedNode.Tag Is IComputerTargetGroup Then
			
			'Get file to save data to.
			If Not exportFileDialog.ShowDialog = DialogResult.Cancel Then
				ExportData(DirectCast(_dgvMain.DataSource, DataTable), exportFileDialog.FileName)
			End If
		End If
	End Sub
	
	'Create an update.
	Private Sub createUpdateToolStripMenuItemClick(sender As Object, e As EventArgs)
		
		'Show the Import Update dialog and dispose of it.
		My.Forms.UpdateForm.Location =  New Point(Me.Location.X + 100, Me.Location.Y + 100)
		
		'If the user didn't cancel then reload the tree.
		If My.Forms.UpdateForm.ShowDialog = DialogResult.OK Then
			Call LoadUpdateNodes()
			Call RefreshUpdateList()
		End If
		My.Forms.UpdateForm.Dispose
	End Sub
	
	'Export the current update to a CAB file.
	Sub ExportUpdateToolStripMenuItemClick(sender As Object, e As EventArgs)
		
		If Not Me._dgvMain.CurrentRow Is Nothing
			Dim update As IUpdate = DirectCast(Me._dgvMain.CurrentRow.Cells("IUpdate").Value, IUpdate)
			
			exportFileDialog.Reset
			exportFileDialog.Filter = "CAB Files|*.cab"
			
			If Not update Is Nothing AndAlso _
				Not exportFileDialog.ShowDialog = DialogResult.Cancel Then
				
				'Create Temporary Folder.
				Dim tmpFolder As New DirectoryInfo( Path.Combine(Path.GetTempPath, Path.GetRandomFileName) )
				tmpFolder.Create
				
				'Save the SDP file to the temp folder.
				Dim sdpFile As String = Path.Combine(tmpFolder.ToString, update.Id.UpdateId.ToString & ".xml")
				ConnectionManager.ParentServer.ExportPackageMetadata(update.Id, sdpFile)
				
				Dim tmpSDP As SoftwareDistributionPackage = New SoftwareDistributionPackage(sdpFile)
				
				If tmpSDP.InstallableItems.Count > 0 Then
					
					Dim cabFile As New FileInfo("\\" & ConnectionManager.ParentServer.Name & "\UpdateServicesPackages\" & update.Id.UpdateId.ToString & "\" & tmpSDP.InstallableItems(0).Id.ToString & "_1.cab")
					
					If cabFile.Exists Then
						
						'Move the CAB to temp folder.
						File.Copy(cabFile.ToString, Path.Combine(tmpFolder.ToString, update.Id.UpdateId.ToString & ".cab"), True)
						
						'Create CAB of the temp folder.
						Dim cabCompressed As CabLib.Compress = New CabLib.Compress
						cabCompressed.CompressFolder(tmpFolder.ToString, exportFileDialog.FileName, "", True, True, 0)
					Else
						Msgbox("The package content does not exist in the UpdateServicesPackages folder.")
					End If
					
					'Delete the temporary folder.
					tmpFolder.Delete(True)
					
				End If
			End If
		End If
	End Sub
	
	'Import an update from a CAB file.
	Sub ImportUpdateToolStripMenuItemClick(sender As Object, e As EventArgs)
		importFileDialog.Reset
		importFileDialog.Filter = "CAB Files|*.cab"
		
		'If we're connected and a file was chosen.
		If ConnectionManager.Connected AndAlso _
			Not importFileDialog.ShowDialog = DialogResult.Cancel Then
			
			'Publish the CAB
			If ConnectionManager.PublishPackageFromCAB(New FileInfo(importFileDialog.FileName)) Then
				Msgbox ("Update was successfully imported.")
				Call LoadUpdateNodes()
				Call RefreshUpdateList()
			Else
				Msgbox ("Update was not imported.")
			End If
			
			
		End If
	End Sub
	
	'Show the connection settings.
	Private Sub ConnectionSettingsToolStripMenuItemClick(sender As Object, e As EventArgs)
		
		'Show connection settings dialog.
		My.Forms.ConnectionSettingsForm.Location =  New Point(Me.Location.X + 100, Me.Location.Y + 100)
		Dim DialogReturn As DialogResult = My.Forms.ConnectionSettingsForm.ShowDialog
		
		'If the user saved their changes then reconnect.
		If DialogReturn = DialogResult.OK Then
			Call LoadMainForm
		End If
	End Sub
	
	'Show the manage saved rules form.
	Sub ManageRulesToolStripMenuItemClick(sender As Object, e As EventArgs)
		My.Forms.SavedRulesForm.Location = New Point(Me.Location.X + 100, Me.Location.Y + 100)
		My.Forms.SavedRulesForm.ShowDialog(SavedRulesFormUses.Manage)
	End Sub
	
	Sub ImportRulesToolStripMenuItemClick(sender As Object, e As EventArgs)
		My.Forms.SavedRulesForm.Location = New Point(Me.Location.X + 100, Me.Location.Y + 100)
		My.Forms.SavedRulesForm.ShowDialog( SavedRulesFormUses.Import)
	End Sub
	
	Sub ExportRulesToolStripMenuItemClick(sender As Object, e As EventArgs)
		My.Forms.SavedRulesForm.Location = New Point(Me.Location.X + 100, Me.Location.Y + 100)
		My.Forms.SavedRulesForm.ShowDialog( SavedRulesFormUses.Export)
	End Sub
	
	'Prompt the user for a filename and export the data.
	Sub ExportReportToolStripMenuItemClick(sender As Object, e As EventArgs)
		
		'Make sure we can export the report and that the user has provided a filename.
		If Not cboUpdateStatus.SelectedIndex = -1 AndAlso _
			Not treeView.SelectedNode Is Nothing AndAlso _
			Not treeView.SelectedNode.Tag Is Nothing AndAlso _
			Not exportFileDialog.ShowDialog = DialogResult.Cancel Then
			
			'Export the data based on the selected node's tag type.
			If TypeOf Me.treeView.SelectedNode.Tag Is IComputerTargetGroup Then
				ExportData(DirectCast(dgvComputerReport.DataSource, DataTable),exportFileDialog.FileName)
			ElseIf TypeOf Me.treeView.SelectedNode.Tag Is IUpdateCategory Then
				ExportData(DirectCast(dgvUpdateReport.DataSource, DataTable),exportFileDialog.FileName)
			End If
		End If
	End Sub
	
	'Show the application settings.
	Sub OptionsToolStripMenuItemClick(sender As Object, e As EventArgs)
		My.Forms.SettingsForm.Location =  new Point(Me.Location.X + 100, Me.Location.Y + 100)
		My.Forms.SettingsForm.ShowDialog
	End Sub
	
	'Show the about form.
	Private Sub AboutToolStripMenuItemClick(sender As Object, e As EventArgs)
		My.Forms.AboutForm.Location =  new Point(Me.Location.X + 100, Me.Location.Y + 100)
		My.Forms.AboutForm.Show
	End Sub
	
	'Show the certificate info form.
	Private Sub CertificateInfoToolStripMenuItemClick(sender As Object, e As EventArgs)
		'Show certificate info
		My.Forms.CertificateInfoForm.Location =  new Point(Me.Location.X + 100, Me.Location.Y + 100)
		My.Forms.CertificateInfoForm.ShowDialog
	End Sub
	
	'Go to the help Wiki.
	Sub LupHelpToolStripMenuItemClick(sender As Object, e As EventArgs)
		System.Diagnostics.Process.Start("http://sourceforge.net/apps/mediawiki/localupdatepubl")
	End Sub
	
	'Go to the help forum.
	Sub HelpForumsToolStripMenuItemClick(sender As Object, e As EventArgs)
		System.Diagnostics.Process.Start("http://sourceforge.net/projects/localupdatepubl/forums")
	End Sub
	
	#End Region
	
	#Region "Context Menu Events"
	'Show the accept update dialog.
	Private Sub ApproveUpdate_Click(sender As Object, e As EventArgs)
		
		'Make sure a current row is selected.
		If Me._dgvMain.SelectedRows.Count < 1 Then
			Msgbox("No row selected.")
		Else
			'Display the approval dialog.
			My.Forms.ApprovalForm.Location =  New Point(Me.Location.X + 100, Me.Location.Y + 100)
			
			'Get result.
			If My.Forms.ApprovalForm.ShowDialog( Me._dgvMain.SelectedRows) = DialogResult.OK Then
				'Refresh the DGV.
				Call RefreshUpdateList(True)
			End If
			
			
		End If
	End Sub
	
	'Open the update form and pass it the currently selected update's SDP file.
	Private Sub ReviseUpdate_Click(sender As Object, e As EventArgs)
		
		'Make sure a current row is selected.
		If Me._dgvMain.CurrentRow Is Nothing
			msgbox("No row selected")
		Else If Me._dgvMain.SelectedRows.Count > 1 Then
			MsgBox ("You cannot revise multiple updates at the same time.")
		Else
			'Make Sure the current row has an UpdateID.
			If TypeOf Me._dgvMain.CurrentRow.Cells.Item("Id").Value Is UpdateRevisionId Then
				'Export the SDP to a temporary file.
				Dim packageFile As String = My.Computer.FileSystem.GetTempFileName
				ConnectionManager.ParentServer.ExportPackageMetadata(DirectCast(Me._dgvMain.CurrentRow.Cells("IUpdate").Value, IUpdate).Id, packageFile)
				
				'Bring Up the approval dialog and dispose it when finished.
				My.Forms.UpdateForm.Location =  new Point(Me.Location.X + 100, Me.Location.Y + 100)
				If My.Forms.UpdateForm.ShowDialog(packageFile) = DialogResult.OK Then
					'Refresh the DGV.
					Call RefreshUpdateList(True)
				End If
				
				My.Forms.UpdateForm.Dispose
			Else
				MsgBox("This row did not return a valid UpdateID")
			End If
		End If
	End Sub
	
	'Decline the update.
	Private Sub DeclineUpdate_Click(sender As Object, e As EventArgs)
		Dim response As MsgBoxResult
		
		
		'Prompt user for confirmation.
		If Me._dgvMain.SelectedRows.Count > 1 Then
			response = Msgbox("Do you wish to decline these " & Me._dgvMain.SelectedRows.Count & " updates?" , vbYesNo)
		Else If Not Me._dgvMain.CurrentRow Is Nothing
			response = Msgbox("Do you wish to decline " & _
				DirectCast(Me._dgvMain.CurrentRow.Cells("Title").Value, String) , _
				vbYesNo)
		End If
		
		'If user really wants to remove the updates then do so
		If response = MsgBoxResult.Yes Then
			Me.Cursor = Cursors.WaitCursor
			'Loop through and delete rows that have an Id listed.
			For Each tmpRow As DataGridViewRow In Me._dgvMain.SelectedRows
				If Not tmpRow.Cells("IUpdate").Value Is Nothing Then
					'Decline update.
					DirectCast( tmpRow.Cells("IUpdate").Value, IUpdate).Decline
				End IF
			Next
			
			'Refresh the DGV.
			Call RefreshUpdateList(True)
			
			Me.Cursor = Cursors.Arrow
		End If
		
	End Sub
	
	'Remove the update.
	Private Sub RemoveUpdate_Click(sender As Object, e As EventArgs)
		Dim response As MsgBoxResult
		Dim update As IUpdate
		
		'Prompt user for confirmation.
		If Me._dgvMain.SelectedRows.Count > 1 Then
			response = Msgbox("Do you wish to remove these " & Me._dgvMain.SelectedRows.Count & " updates?" , vbYesNo)
		Else If Not Me._dgvMain.CurrentRow Is Nothing
			response = Msgbox("Do you wish to remove " & _
				DirectCast(Me._dgvMain.CurrentRow.Cells("Title").Value, String) , _
				vbYesNo)
		End If
		
		'If user really wants to remove the updates then do so
		If response = MsgBoxResult.Yes Then
			Me.Cursor = Cursors.WaitCursor
			'Loop through and delete rows that have an Id listed.
			For Each tmpRow As DataGridViewRow In Me._dgvMain.SelectedRows
				
				If Not tmpRow.Cells("IUpdate").Value Is Nothing Then
					'Get update.
					update = DirectCast( tmpRow.Cells("IUpdate").Value, IUpdate)
					
					'Remove the approvals
					For Each approval As IUpdateApproval In update.GetUpdateApprovals
						approval.Delete
					Next
					
					Try
						'Remove the package.
						ConnectionManager.ParentServer.DeleteUpdate( update.Id.UpdateId )
					Catch x As WsusObjectNotFoundException
						Msgbox ("WsusObjectNotFoundException: " & x.Message)
					Catch x As InvalidOperationException
						Msgbox ("InvalidOperationException: " & x.Message)
					Catch x As Exception
						Msgbox ("Exception: " & x.Message)
					End Try
					
					'Delete the package's folder from the ~\WSUS\UpdateServicesPackages folder.
					'If there is an error then prompt the user to delete the content manually.
					'Currently we check to see if the folder exists because earlier version of LUP
					' published the packages to a single location in error.  At some point
					' this code should be removed and an error thrown if the content isn't found.
					Dim tmpDirectory As String = "\\" & ConnectionManager.ParentServer.Name & "\UpdateServicesPackages\" & update.Id.UpdateId.ToString
					Try
						If Directory.Exists(tmpDirectory) Then
							Directory.Delete(tmpDirectory, True)
						End If
					Catch
						Msgbox("There was a problem deleting the package content from the UpdateServicesPackages.  Use this UpdateID to do so manually: " & vbNewline & update.Id.UpdateId.ToString)
					End Try
				End IF
			Next
			
			Call LoadUpdateNodes
			Call RefreshUpdateList
			
			Me.Cursor = Cursors.Arrow
		End If
		
		
	End Sub
	
	'Expire the update.
	Private Sub ExpireUpdate_Click(sender As Object, e As EventArgs)
		Dim response As MsgBoxResult
		
		'Prompt user for confirmation.
		If Me._dgvMain.SelectedRows.Count > 1 Then
			response = Msgbox("Do you wish to expire these " & Me._dgvMain.SelectedRows.Count & " updates?" , vbYesNo)
		Else
			response = Msgbox("Do you wish to expire " & _
				DirectCast(Me._dgvMain.CurrentRow.Cells("Title").Value, String) , _
				vbYesNo)
		End If
		
		'If user really wants to remove the updates then do so
		If response = MsgBoxResult.Yes Then
			Me.Cursor = Cursors.WaitCursor
			'Loop through selected rows.
			For Each tmpRow As DataGridViewRow In Me._dgvMain.SelectedRows
				'Make sure we have something selected
				If Not tmpRow.Cells.Item("Id").Value Is Nothing Then
					ConnectionManager.ParentServer.ExpirePackage( DirectCast(tmpRow.Cells.Item("Id").Value,UpdateRevisionId) )
				End If
				
			Next
			
			'Refresh the datagrid view
			Call RefreshUpdateList
			
			Me.Cursor = Cursors.Arrow
		End If
		
	End Sub
	
	'Resign the update.  This is only needed if the certificate has changed
	' since the update was initially created.
	Private Sub ResignUpdate_Click(sender As Object, e As EventArgs)
		Dim packageFile As String
		
		'Make sure a current row is selected.
		If Me._dgvMain.SelectedRows.Count < 1 Then
			msgbox("No row selected")
		Else
			Dim response As MsgBoxResult
			
			'Prompt user for confirmation.
			If Me._dgvMain.SelectedRows.Count > 1 Then
				response = Msgbox("Do you wish to re-sign these " & Me._dgvMain.SelectedRows.Count & " updates?" , vbYesNo)
			Else If Not Me._dgvMain.CurrentRow Is Nothing
				response = Msgbox("Do you wish to re-sign " & _
					DirectCast(Me._dgvMain.CurrentRow.Cells("Title").Value, String) & "?" , _
					vbYesNo)
			End If
			
			'If user really wants to remove the updates then do so
			If response = MsgBoxResult.Yes Then
				
				Me.Cursor = Cursors.WaitCursor
				
				For Each tmpRow As DataGridViewRow In Me._dgvMain.SelectedRows
					
					'Make Sure the current row has an UpdateID.
					If TypeOf tmpRow.Cells.Item("Id").Value Is UpdateRevisionId Then
						'Export the SDP to a temporary file.
						packageFile = My.Computer.FileSystem.GetTempFileName
						ConnectionManager.ParentServer.ExportPackageMetadata(DirectCast(tmpRow.Cells.Item("Id").Value, UpdateRevisionId ), packageFile)
						
						'Create a publisher object with the SDP and resign the package.
						Dim publisher As IPublisher = ConnectionManager.ParentServer.GetPublisher(packageFile)
						Try
							publisher.ResignPackage()
							My.Computer.FileSystem.DeleteFile(packageFile)
							
						Catch x As UnauthorizedAccessException
							Msgbox ("The package could not be re-signed." & vbNewline & "Unauthorized Access Exception: " & vbNewLine & x.Message & vbNewLine & x.StackTrace)
						Catch x As ArgumentNullException
							Msgbox ("The package could not be re-signed." & vbNewline & "Argument Null Exception: " & vbNewLine & x.Message & vbNewLine & x.StackTrace)
						Catch x As FileNotFoundException
							Msgbox ("The package could not be re-signed." & vbNewline & "File Not Found Exception: " & vbNewLine & x.Message & vbNewLine & x.StackTrace)
						Catch x As InvalidDataException
							Msgbox ("The package could not be re-signed." & vbNewline & "Invalid Data Exception: " & vbNewLine & x.Message & vbNewLine & x.StackTrace)
						Catch x As InvalidOperationException
							Msgbox ("The package could not be re-signed." & vbNewline & "Invalid Operation Exception: " & vbNewLine & x.Message & vbNewLine & x.StackTrace)
						Catch x As Exception
							Msgbox ("The package could not be re-signed." & vbNewline & "Exception: " & vbNewLine & x.Message & vbNewLine & x.StackTrace)
						End Try
					Else
						MsgBox("This row did not return a valid UpdateID")
					End If
					
				Next
				
				Me.Cursor = Cursors.Arrow
				Msgbox ("Packages successfully re-signed.")
				
			End If
		End If
	End Sub
	
	Private Sub RevisionHistoryUpdate_Click(sender As Object, e As EventArgs)
		'TODO: Add code to produce revision history
	End Sub
	
	Private Sub FileInfoUpdate_Click(sender As Object, e As EventArgs)
		'TODO: Add code to produce File Info
	End Sub
	
	Private Sub StatusReportUpdate_Click(sender As Object, e As EventArgs)
		'TODO: Add code to produce Status Report
	End Sub
	#End Region
	
	#Region "Context Menu Methods"
	'Setup the context menus based on the currently selected node.
	Sub SetupContextMenu
		'Clear the context menu.
		Me.cmDgvMain.Items.Clear
		
		'If there's no selected node, or the selected node doesn't have a tag object.
		If treeView.SelectedNode Is Nothing OrElse _
			treeView.SelectedNode.Tag Is Nothing Then
			
			updateToolStripMenuItem.Visible = False
			exportListToolStripMenuItem.Visible = False
		ElseIf TypeOf Me.treeView.SelectedNode.Tag Is IComputerTargetGroup Then
			'If this is an target group node.
			updateToolStripMenuItem.Visible = False
			
			'Show the export menu items.
			exportListToolStripMenuItem.Visible = True
			exportListToolStripMenuItem.Enabled = False
			exportReportToolStripMenuItem.Visible = True
			exportReportToolStripMenuItem.Enabled = False
		ElseIf TypeOf Me.treeView.SelectedNode.Tag Is IUpdateCategory Then
			'If this is an update category node.
			
			'Show the correct export menu items.
			exportListToolStripMenuItem.Visible = False
			exportReportToolStripMenuItem.Visible = True
			exportReportToolStripMenuItem.Enabled = False
			
			'Clear the update menu strip item.
			Me.updateToolStripMenuItem.DropDownItems.Clear
			
			'Add the items to both the context menu and the update menustrip if
			' this server is not a replica server.
			If ConnectionManager.Connected AndAlso Not ConnectionManager.CurrentServerConfiguration.IsReplicaServer
				Me.cmDgvMain.Items.Add("Approve", Nothing , New EventHandler(AddressOf ApproveUpdate_Click))
				Me.updateToolStripMenuItem.DropDownItems.Add("Approve", Nothing , New EventHandler(AddressOf ApproveUpdate_Click))
				Me.cmDgvMain.Items.Add("Revise", Nothing , New EventHandler(AddressOf ReviseUpdate_Click))
				Me.updateToolStripMenuItem.DropDownItems.Add("Revise", Nothing , New EventHandler(AddressOf ReviseUpdate_Click))
				Me.cmDgvMain.Items.Add("Re-sign", Nothing , New EventHandler(AddressOf ResignUpdate_Click))
				Me.updateToolStripMenuItem.DropDownItems.Add("Re-sign", Nothing , New EventHandler(AddressOf ResignUpdate_Click))
				Me.cmDgvMain.Items.Add("Expire", Nothing , New EventHandler(AddressOf ExpireUpdate_Click))
				Me.updateToolStripMenuItem.DropDownItems.Add("Expire", Nothing , New EventHandler(AddressOf ExpireUpdate_Click))
				Me.cmDgvMain.Items.Add("Decline", Nothing , New EventHandler(AddressOf DeclineUpdate_Click))
				Me.updateToolStripMenuItem.DropDownItems.Add("Decline", Nothing , New EventHandler(AddressOf DeclineUpdate_Click))
				Me.cmDgvMain.Items.Add("Remove", Nothing , New EventHandler(AddressOf RemoveUpdate_Click))
				Me.updateToolStripMenuItem.DropDownItems.Add("Remove", Nothing , New EventHandler(AddressOf RemoveUpdate_Click))
				'			Future Functionality:
				'			Me.cmDgvMain.Items.Add(New ToolStripSeparator)
				'			Me.updateToolStripMenuItem.DropDownItems.Add(New ToolStripSeparator)
				'			Me.cmDgvMain.Items.Add("Revisions", Nothing , New EventHandler(AddressOf RevisionHistoryUpdate_Click))
				'			Me.updateToolStripMenuItem.DropDownItems.Add("Revisions", Nothing , New EventHandler(AddressOf RevisionHistoryUpdate_Click))
				'			Me.cmDgvMain.Items.Add("File Info", Nothing , New EventHandler(AddressOf FileInfoUpdate_Click))
				'			Me.updateToolStripMenuItem.DropDownItems.Add("File Info", Nothing , New EventHandler(AddressOf FileInfoUpdate_Click))
				'			Me.cmDgvMain.Items.Add("Status Report", Nothing , New EventHandler(AddressOf StatusReportUpdate_Click))
				'			Me.updateToolStripMenuItem.DropDownItems.Add("Status Report", Nothing , New EventHandler(AddressOf StatusReportUpdate_Click))
			End If
			
			'Enable the update item on the menustrip.
			Me.updateToolStripMenuItem.Visible = True
		Else
			'Hide the toolstrips if we don't know what this node is.
			updateToolStripMenuItem.Visible = False
			exportListToolStripMenuItem.Visible = False
			exportListToolStripMenuItem.Enabled = False
			exportReportToolStripMenuItem.Visible = False
			exportReportToolStripMenuItem.Enabled = False
		End If
	End Sub
	#End Region
	
	#Region "TreeView Events"
	
	'Before we move to the next node, save the current DGV states.
	Sub TreeViewBeforeSelect(sender As Object, e As TreeViewCancelEventArgs)
		'If there are rows loaded and the previous node has a tag.
		If _dgvMain.Rows.Count > 0 AndAlso _
			Not treeView.SelectedNode Is Nothing AndAlso _
			Not treeView.SelectedNode.Tag Is Nothing Then
			Call SaveDgvState(treeView.SelectedNode)
		End If
	End Sub
	
	'This method responds to a node being selected.  We base our action off of the node type.
	' First, if the tag isn't intantiatiated then do nothing.  If the tag is instantiated
	' then find it's type and act accordingly.
	Private Sub TreeViewAfterSelect(sender As Object, e As TreeViewEventArgs)
		Cursor = Cursors.WaitCursor
		
		'Make sure the correct server is selected.
		VerifyCurrentServer(e.Node)
		
		'If the tag object is instantiated.
		If Not e.Node.Tag Is Nothing Then
			
			If TypeOf e.Node.Tag Is UpdateServer Then 'Server Node
				Call TreeViewSelectServerNode(sender , e )
			Else If TypeOf e.Node.Tag Is IComputerTargetGroup Then 'Computer Note
				Call TreeViewSelectComputerNode(sender, e)
			Else If TypeOf e.Node.Tag Is IUpdateCategory Then 'Update Node
				
				'Only load update nodes that cannot directly contain updates.
				If DirectCast(e.Node.Tag, IUpdateCategory) .ProhibitsUpdates = False Then
					Call TreeViewSelectUpdateNode(sender ,e)
				End If
			End If 'Type of node's tag.
			
		Else 'If the node's tag isn't instantiated then clear the datagrid.
			_noEvents = True
			scHeader.Panel1Collapsed = True 'Hide the header panel.
			pnlUpdates.Visible = False
			pnlComputers.Visible = False
			Update
			_dgvMain.DataSource = Nothing
			_noEvents = False
		End If 'Node tag instantiated.
		
		Call SetupContextMenu()
		Cursor = Cursors.Arrow
	End Sub
	
	Private Sub TreeViewSelectServerNode(sender As Object, e As TreeViewEventArgs)
		
		treeView.BeginUpdate
		
		Call ClearForm(False)
		
		'If this is a a parent node then clear
		' everything but the current server node.
		If Not DirectCast(e.Node.Tag, UpdateServer).ChildServer Then
			For Each node As TreeNode In _rootNode.Nodes
				If Not node.Equals(e.Node) Then node.Nodes.Clear
			Next
		End If
		
		'If this node already has child nodes then
		' do not reload it and exit the routine.
		If e.Node.Nodes.Count > 0 Then
			treeView.EndUpdate
			Exit Sub
		End If
		
		'If we are connected then populate the tree view.
		If Not ConnectionManager.CurrentServer Is Nothing Then
			
			'Set the server node
			_serverNode = e.Node
			
			'Add the downstream server nodes.
			For Each downstreamServer As IDownstreamServer In ConnectionManager.CurrentServer.GetDownstreamServers
				Dim tmpNode As TreeNode = _serverNode.Nodes.Add(downstreamServer.FullDomainName, UCase(downstreamServer.FullDomainName))
				tmpNode.Tag = New UpdateServer(downstreamServer.FullDomainName, ConnectionManager.CurrentServer.PortNumber, ConnectionManager.CurrentServer.IsConnectionSecureForApiRemoting, True, downstreamServer.IsReplica)
			Next
			
			_computerNode = _serverNode.Nodes.Add("computers", "Computers")
			
			'Add the Locally published packages category as the updates base node.
			For Each category As IUpdateCategory In ConnectionManager.CurrentServer.GetRootUpdateCategories
				'
				'If the category is the locally published category.
				If category.Title = "Local Publisher" Then
					
					'Add the updateNode and set it's tag.
					_updateNode = _serverNode.Nodes.Add(category.Id.ToString, "Updates")
				End If
				
			Next
			
			'Load the tree nodes.
			Call LoadComputerNodes(_computerNode)
			Call LoadUpdateNodes
			
			'Open the server node.
			_rootNode.Expand
			_serverNode.Expand
			
		End If
		
		treeView.EndUpdate
	End Sub
	
	Private Sub TreeViewSelectComputerNode(sender As Object, e As TreeViewEventArgs)
		'Setup the panels.
		scHeader.Panel1Collapsed = False
		pnlUpdates.Visible = False
		splitContainerHorz.SplitterDistance = appSettings.ComputerSplitter
		pnlComputers.Visible = True
		Refresh
		
		'Setup the menus.
		exportListToolStripMenuItem.Visible = True
		
		'Reset the main update tab.
		tabMainUpdates.SelectedIndex = 0
		
		_noEvents = True
		dgvComputerReport.DataSource = Nothing 'Clear report.
		_noEvents = False
		
		'Move the target group combo to the computer report tab.
		If Not tabComputerReport.Controls.Contains(cboUpdateStatus)
			tabComputerReport.Controls.Remove(cboUpdateStatus)
			tabComputerReport.Controls.Add(cboUpdateStatus)
			cboUpdateStatus.Location = New System.Drawing.Point(50, 35)
			cboUpdateStatus.SelectedIndex = -1
		End If
		
		Call RefreshComputerList
		Call LoadComputerGroupStatus
		lblSelectedTargetGroup.Text = DirectCast(treeView.SelectedNode.Tag, IComputerTargetGroup ).Name
	End Sub
	
	Private Sub TreeViewSelectUpdateNode(sender As Object, e As TreeViewEventArgs)
		'Setup the panels.
		scHeader.Panel1Collapsed = True
		pnlComputers.Visible = False
		splitContainerHorz.SplitterDistance = appSettings.UpdateSplitter
		pnlUpdates.Visible = True
		Refresh
		
		
		'Reset the main computers tab.
		tabMainComputers.SelectedIndex = 0
		
		_noEvents = True
		dgvUpdateReport.DataSource = Nothing 'Clear report.
		_noEvents = False
		
		'Move the target group combo to the update report tab.
		If Not tabUpdateReport.Controls.Contains(cboUpdateStatus) Then
			tabUpdateReport.Controls.Remove(cboUpdateStatus)
			tabUpdateReport.Controls.Add(cboUpdateStatus)
			cboUpdateStatus.Location = New System.Drawing.Point(307, 35)
			cboUpdateStatus.SelectedIndex = -1
		End If
		
		Call RefreshUpdateList
		
	End Sub
	
	#End Region
	
	#Region "TreeView Methods"
	'Load up the computer nodes.  This is a recursive subroutine.  When the form
	' loads it calls this with the based computer node.  If that node hasn't been
	' populated yet then we add the all computers node and recursively call
	' the routine to fill in the rest.
	Sub LoadComputerNodes( node as TreeNode )
		
		'If the all computer node has been passed and it doesn't have a tag.
		If node.Equals(_computerNode) And node.GetNodeCount(False) = 0 Then
			
			'Clear the computers node.
			_computerNode.Nodes.Clear
			
			'Clear the computer group combobox.
			Me.cboTargetGroup.Items.Clear
			
			If ConnectionManager.Connected Then
				
				'Load the top level computer groups, starting at the All Computers group
				' and working our way down recursively.
				Dim allComputersGroup As IComputerTargetGroup = ConnectionManager.CurrentServer.GetComputerTargetGroup(ComputerTargetGroupId.AllComputers)
				
				'Add all computers group to which we'll add the groups.
				Dim tmpNode As TreeNode = _computerNode.Nodes.Add(allComputersGroup.Id.ToString,allComputersGroup.Name)
				tmpNode.Tag = allComputersGroup
				
				'Call recursively.
				Call LoadComputerNodes ( tmpNode )
				
				'Load combo boxes.
				LoadComputerCombo ( tmpNode )
			End If
		Else If Not node.Tag Is Nothing
			
			If ConnectionManager.Connected Then
				'Loop through the collection of groups, add them to the all computers node,
				' and set their tag object to the target group.
				For each targetGroup as IComputerTargetGroup in DirectCast(node.Tag, IComputerTargetGroup).GetChildTargetGroups
					Dim tmpNode As TreeNode = node.Nodes.Add(targetGroup.Id.ToString, targetGroup.Name)
					tmpNode.Tag = targetGroup
					
					'Call recursively.
					Call LoadComputerNodes ( tmpNode )
					
				Next
			End If
		End If
	End Sub
	
	'This routine adds the computer groups to the combo box for the reports.
	'  This is done after all the nodes have been loaded so that this is sorted.
	Sub LoadComputerCombo ( node As TreeNode )
		If Not node Is Nothing Then
			'Add the computer group to the combo.
			Me.cboTargetGroup.Items.Add(New ComboTargetGroups(DirectCast(node.Tag, IComputerTargetGroup) ,node.Level - ComputerNode.Level - 2))
			
			'Add it's child groups
			For Each childNode As TreeNode In Node.Nodes
				LoadComputerCombo ( childNode )
			Next
		End If
	End Sub
	
	
	'Load up the updates nodes.
	Sub LoadUpdateNodes
		
		'Clear the updates node and the import update and report comboboxes.
		If Not _updateNode Is Nothing Then
			_updateNode.Nodes.Clear
			
			Me._vendorCollection.Clear
			
			If ConnectionManager.Connected Then 'Make sure we're connected still.
				
				'Load the companies categories under the Locally Published Packages category.
				For Each category As IUpdateCategory In ConnectionManager.CurrentServer.GetRootUpdateCategories
					
					'If the category is the locally published category.
					If category.Title <> "Local Publisher" And _
						category.Title <> "Microsoft" Then
						
						'Add the node and add it's category.
						Dim tmpNode As TreeNode = _updateNode.Nodes.Add( category.Title )
						tmpNode.Tag = category
						
						'Add the vendor to the import update dropdown.
						'_vendors += vbNewline & category.Title
						Dim tmpVendor As New Vendor(category.Title)
						
						'If there might be subcategories then load them.
						If category.ProhibitsSubcategories = False Then
							Dim tmpProductCollection As Collections.Generic.List(Of String) = New Collections.Generic.List(Of String)
							
							'Now add the categories under the locally published category.
							For Each subCategory As IUpdateCategory In category.GetSubcategories
								
								'Note: this code works to hide empty categories but it is resource
								' intensive to load the updates for every category before adding it.
								'If the category is empty hide it, and it's parent.
								'If subCategory.GetUpdates().Count > 0 Then
								
								'Add the node.
								Dim tmpSubNode As TreeNode = tmpNode.Nodes.Add ( subCategory.Id.ToString, subCategory.Title)
								tmpSubNode.Tag = subCategory
								
								'Add the software package to the import update dropdown
								tmpProductCollection.Add( subCategory.Title )
								
								'								Else
								'									'Remove the parent node.
								'									tmpNode.Remove
								'
								'									'Remove the vendor from the list
								'									_vendors.Replace(category.Title,"")
								'								End If
							Next
							
							'Add the products to the vendor object.
							tmpVendor.Products = tmpProductCollection
							
							'Add the vendor the the vendor collection.
							Me._vendorCollection.Add(tmpVendor)
							
						End If
					End if
				Next
				
			End If
		End If
	End Sub
	
	'Verify that the correct server is current based on the node that was selected.
	Sub VerifyCurrentServer(node As TreeNode)
		If node Is Nothing Then
			Exit Sub
		Else If Not node.Tag Is Nothing AndAlso _
			TypeOf node.Tag Is UpdateServer Then 'node is an update server.
			
			'If the current server is the one we want then exit.  Otherwise connect to it.
			If Not ConnectionManager.CurrentServer Is Nothing AndAlso _
				DirectCast(node.Tag, UpdateServer).Name = ConnectionManager.CurrentServer.Name Then
				Exit Sub
			Else
				ConnectionManager.Connect(DirectCast(node.Tag, UpdateServer))
				Call SetToolStrip
			End If
		Else If Not node.Parent Is Nothing 'Recursively call with the node's parent.
			VerifyCurrentServer(node.Parent)
		Else
			Exit Sub
		End If
	End Sub
	
	'Used to enable or disable elements in the toolstrip.
	Sub SetToolStrip
		
		'Check to see if we're connected to a master server that has a certificate.
		If ConnectionManager.Connected Then
			
			'Show the certificate info.
			Me.certificateInfoToolStripMenuItem.Enabled = True
			
			'If the certificate doesn't exist then we can't import updates.
			If ConnectionManager.CertExists AndAlso Not ConnectionManager.CurrentServerConfiguration.IsReplicaServer Then
				Me.createUpdateToolStripMenuItem.Enabled = True
			Else
				Me.createUpdateToolStripMenuItem.Enabled = False
			End If
			
		Else 'Not connected.
			Me.certificateInfoToolStripMenuItem.Enabled = False
			Me.createUpdateToolStripMenuItem.Enabled = False
		End If
		
	End Sub
	#End Region
	
	#Region "DGV Events"
	Sub dgvMainLeave(sender As Object, e As EventArgs)
		'Save the dgvstate
		Savedgvstate ( treeView.SelectedNode)
	End Sub
	
	'If the user uses the upd or down keys then load the new row.
	Sub dgvMainKeyUp(sender As Object, e As KeyEventArgs)
		If Not _noEvents AndAlso Not _dgvMain.CurrentRow Is Nothing AndAlso _dgvMain.CurrentRow.Index >= 0 AndAlso _
			(e.KeyCode = 40 OrElse _
			e.KeyCode = 38 ) Then
			_dgvMain.Update
			
			Call LoadRow( _dgvMain.CurrentRow.Index)
		End If
	End Sub
	
	Sub dgvMainRowEnter(sender As Object, e As DataGridViewCellEventArgs)
		If  Not _noEvents Then
			'Load the newly selected row.
			Call LoadRow(e.RowIndex)
		End If
		
	End Sub
	
	'Handle header row and right clicks.
	Private Sub dgvMainCellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs)
		
		'If user right clicks on a non-header row
		If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso e.Button = MouseButtons.Right Then
			
			'Update current cell to load the new row
			_dgvMain.CurrentCell = _dgvMain.Rows(e.RowIndex).Cells(e.ColumnIndex)
			
			
			Dim r As Rectangle = _dgvMain.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true)
			cmDgvMain.Show(DirectCast(sender, Control), r.Left + e.X, r.Top + e.Y)
			'If user left clicks on a header row and rows are selected.
		Else If  _dgvMain.SelectedRows.Count = 1 AndAlso e.Button = MouseButtons.Left Then
			'Save the currently selected row based on the currently selected tree node.
			If TypeOf Me.treeView.SelectedNode.Tag Is IComputerTargetGroup Then
				_originalValue = DirectCast(_dgvMain.CurrentRow.Cells.Item("ComputerName").Value, String)
				
			Else If TypeOf Me.treeView.SelectedNode.Tag Is IUpdateCategory Then
				_originalValue = DirectCast(_dgvMain.CurrentRow.Cells.Item("Title").Value, String)
			End If
		Else
			_originalValue = Nothing
		End If
		
	End Sub
	
	'This routine captures the current row's value before a sort.
	Sub DgvComputerReportCellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs)
		'If a valid header was clicked and there is a row selected then save its info.
		If e.RowIndex = -1 And e.ColumnIndex > -1 And dgvComputerReport.SelectedRows.Count = 1 Then
			'Save the currently selected update.
			_originalValue = DirectCast(dgvComputerReport.CurrentRow.Cells.Item("UpdateTitle").Value, String)
		Else If e.RowIndex <> -1 AndAlso Not Me._dgvMain.CurrentRow Is Nothing Then
			_originalValue = Nothing
			
			'If the column is the status column and this update has failed then display the error history.
			If dgvComputerReport.Columns(e.ColumnIndex).Name = "UpdateInstallationState"  Then
				Dim tmpMessage As String = ""
				Me.Cursor = Cursors.WaitCursor
				For Each tmpEvent As IUpdateEvent In DirectCast( Me.dgvComputerReport.Rows(e.RowIndex).Cells("IUpdate").Value, IUpdate).GetUpdateEventHistory(Date.MinValue, Date.MaxValue)
					If DirectCast(_dgvMain.CurrentRow.Cells("TargetID").Value, String) = tmpEvent.ComputerId
						tmpMessage += "Date: " & tmpEvent.CreationDate & vbTab & "  " & tmpEvent.Message & vbNewline
					End If
				Next
				Me.Cursor = Cursors.Arrow
				If Not String.IsNullOrEmpty ( tmpMessage ) Then
					Msgbox (tmpMessage,MsgBoxStyle.OkOnly, "History for " & DirectCast(dgvComputerReport.Rows(e.RowIndex).Cells("UpdateTitle").Value, String))
				End If
			End If
		Else
			_originalValue = Nothing
		End If
		
		
	End Sub
	
	'This routine captures the current row's value before a sort.
	Sub DgvUpdateReportCellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs)
		'If a valid header was clicked and there is a row selected then save its info.
		If e.RowIndex = -1 And e.ColumnIndex > -1 And dgvUpdateReport.SelectedRows.Count = 1 Then
			'Save the currently selected update.
			_originalValue = DirectCast(dgvUpdateReport.CurrentRow.Cells.Item("ComputerName").Value, String)
		Else If e.RowIndex <> -1
			_originalValue = Nothing
			
			'If the column is the status column and this update has failed then display the error history.
			If dgvUpdateReport.Columns(e.ColumnIndex).Name = "UpdateInstallationState" AndAlso Not Me._dgvMain.CurrentRow Is Nothing
				Dim tmpMessage As String = ""
				Me.Cursor = Cursors.WaitCursor
				For Each tmpEvent As IUpdateEvent In DirectCast(Me._dgvMain.CurrentRow.Cells("IUpdate").Value, IUpdate).GetUpdateEventHistory(Date.MinValue, Date.MaxValue)
					If DirectCast(dgvUpdateReport.Rows(e.RowIndex).Cells("ComputerID").Value, String) = tmpEvent.ComputerId Then
						tmpMessage += "Date: " & tmpEvent.CreationDate & vbTab & "  " & tmpEvent.Message & vbNewline
					End If
				Next
				Me.Cursor = Cursors.Arrow
				If Not String.IsNullOrEmpty ( tmpMessage ) Then
					Msgbox (tmpMessage,MsgBoxStyle.OkOnly, "Error History for " & DirectCast(dgvUpdateReport.Rows(e.RowIndex).Cells("ComputerName").Value, String))
				End If
			End If
		Else
			_originalValue = Nothing
		End If
		
	End Sub
	
	'After the user sorts the DGV, load the new row
	' that is selected.
	Private Sub DgvMainSorted(sender As Object, e As EventArgs)
		Dim columnName As String = ""
		If Not _noEvents Then
			
			If _dgvMain.Rows.Count > 0 Then
				If Not _originalValue = Nothing Then
					
					'Choose the column name based on the tree view node.
					If TypeOf Me.treeView.SelectedNode.Tag Is IComputerTargetGroup Then
						columnName = "ComputerName"
					Else If TypeOf Me.treeView.SelectedNode.Tag Is IUpdateCategory Then
						columnName = "Title"
					End If
					
					'Select and load the original row.
					For Each tmpRow As DataGridViewRow In _dgvMain.Rows
						If _originalValue = DirectCast(tmpRow.Cells(columnName).Value, String) Then
							_dgvMain.CurrentCell = tmpRow.Cells(columnName)
							Exit For
						Else If tmpRow.Index = _dgvMain.Rows.Count - 1
							_dgvMain.CurrentCell =  _dgvMain.Rows(0).Cells(columnName)
						End If
					Next
				End If
				If Not Me._dgvMain.CurrentRow Is Nothing Then
					Call LoadRow ( _dgvMain.CurrentRow.Index )
				End If
			End If
		End If
	End Sub
	
	'This routine finds the original row if it was saved.
	Sub DgvComputerReportSorted(sender As Object, e As EventArgs)
		If _noEvents = False Then
			
			If Not _originalValue = Nothing And dgvComputerReport.Rows.Count > 0 Then
				'Select and load the original row.
				For Each tmpRow As DataGridViewRow In dgvComputerReport.Rows
					If _originalValue = DirectCast(tmpRow.Cells("UpdateTitle").Value, String) Then
						dgvComputerReport.CurrentCell = tmpRow.Cells("UpdateTitle")
						Exit For
					Else If tmpRow.Index = dgvComputerReport.Rows.Count - 1
						dgvComputerReport.CurrentCell =  dgvComputerReport.Rows(0).Cells("UpdateTitle")
					End If
				Next
			End If
		End If
	End Sub
	
	'This routine finds the original row if it was saved.
	Sub DgvUpdateReportSorted(sender As Object, e As EventArgs)
		If _noEvents = False Then
			
			If Not _originalValue = Nothing And dgvUpdateReport.Rows.Count > 0 Then
				'Select and load the original row.
				For Each tmpRow As DataGridViewRow In dgvUpdateReport.Rows
					If _originalValue = DirectCast(tmpRow.Cells("ComputerName").Value, String) Then
						dgvUpdateReport.CurrentCell = tmpRow.Cells("ComputerName")
						Exit For
					Else If tmpRow.Index = dgvUpdateReport.Rows.Count - 1
						dgvUpdateReport.CurrentCell =  dgvUpdateReport.Rows(0).Cells("ComputerName")
					End If
				Next
			End If
		End If
	End Sub
	#End Region
	
	#Region "DGV Load Methods"
	
	'Call RefreshComputerList with defaults.
	Sub RefreshComputerList
		Call RefreshComputerList(false)
	End Sub
	
	'Refresh the list of computers shown in the main DGV.
	Sub RefreshComputerList( maintainSelectedRow As Boolean )
		Dim originalValue As String
		
		_noEvents = True
		toolStripStatusLabel.Text = "Refreshing computer list"
		Me.Update
		
		'Make sure a computer tree node it selected
		If Not treeView.SelectedNode Is Nothing AndAlso _
			Not treeView.SelectedNode.Tag Is Nothing AndAlso _
			TypeOf treeView.SelectedNode.Tag Is IComputerTargetGroup Then
			
			'If we are maintaining the status then save the status.
			If maintainSelectedRow And _dgvMain.SelectedRows.Count = 1 Then
				originalValue = DirectCast(_dgvMain.CurrentRow.Cells.Item("ComputerName").Value, String)
			Else
				maintainSelectedRow = False
				originalValue = ""
			End If
			
			'Set current row to negative one.
			'Me._currentRowIndex = -1
			
			'Set the datasource to list of computers.  If nothing then exit sub.
			_dgvMain.DataSource = GetComputerList(DirectCast(treeView.SelectedNode.Tag, IComputerTargetGroup))
			If _dgvMain.DataSource Is Nothing Then Exit Sub
			
			'Set header texts for main DGV.
			Me._dgvMain.Columns("ComputerName").HeaderText = "Computer Name"
			Me._dgvMain.Columns("ComputerName").SortMode = DataGridViewColumnSortMode.Automatic
			Me._dgvMain.Columns("IPAddress").HeaderText = "IP Address"
			Me._dgvMain.Columns("IPAddress").SortMode = DataGridViewColumnSortMode.Automatic
			Me._dgvMain.Columns("OperatingSystem").HeaderText = "Operating Sytem"
			Me._dgvMain.Columns("OperatingSystem").SortMode = DataGridViewColumnSortMode.Automatic
			Me._dgvMain.Columns("InstalledNotApplicable").HeaderText = "Installed/Not Applicable"
			Me._dgvMain.Columns("InstalledNotApplicable").SortMode = DataGridViewColumnSortMode.Automatic
			Me._dgvMain.Columns("InstalledNotApplicable").DefaultCellStyle.Format = "p0"
			Me._dgvMain.Columns("InstalledNotApplicable").SortMode = DataGridViewColumnSortMode.Automatic
			Me._dgvMain.Columns("LastStatusReport").HeaderText = "Last Status Report"
			Me._dgvMain.Columns("LastStatusReport").SortMode = DataGridViewColumnSortMode.Automatic
			
			
			'Hide some columns.
			Me._dgvMain.Columns("IComputerTarget").Visible = False
			Me._dgvMain.Columns("TargetID").Visible = False
			
			'Update the count.
			Me.lblSelectedTargetGroupCount.Text = Me._dgvMain.Rows.Count & " computers shown"
			
			'If computers are listed in the DGV.
			If _dgvMain.Rows.Count > 0 Then
				
				Call LoadDgvState(_dgvMain)
				
				'If we are maintaining the row.
				If maintainSelectedRow Then
					'Select the original row.
					For Each tmpRow As DataGridViewRow In Me._dgvMain.Rows
						If originalValue = DirectCast(tmpRow.Cells("ComputerName").Value, String) Then
							_dgvMain.CurrentCell = tmpRow.Cells("ComputerName")
							Exit For
						Else If tmpRow.Index = _dgvMain.Rows.Count - 1
							_dgvMain.CurrentCell =  _dgvMain.Rows(0).Cells("ComputerName")
						End If
					Next
				Else
					'Select the first row.
					_dgvMain.CurrentCell = _dgvMain.Rows(0).Cells("ComputerName")
				End If
				
				btnComputerListRefresh.Enabled = True
				exportListToolStripMenuItem.Enabled = True
				
				'Load the selected computer's info.
				'Call LoadComputerInfo ( Me._dgvMain.CurrentRow.Index)
				
				'If the user is currently on the report tab then update it.
				' Otherwise, clear the combo selections.
				If Me.tabMainComputers.SelectedTab.Name = Me.tabComputerReport.Name Then
					
					Call LoadComputerReport(Me._dgvMain.CurrentRow.Index)
					Call LoadDgvState(dgvComputerReport)
				Else
					Me.dgvComputerReport.DataSource = Nothing
					Me.cboTargetGroup.SelectedIndex =  -1
					Me.cboUpdateStatus.SelectedIndex = -1
				End If
			Else 'No computers listed in the DGV.
				btnComputerListRefresh.Enabled = False
				exportListToolStripMenuItem.Enabled = False
				
				'Call LoadComputerInfo( Me._dgvMain.CurrentRow.Index)
				Me.dgvUpdateReport.DataSource = Nothing
				Me.cboTargetGroup.SelectedIndex =  -1
				Me.cboUpdateStatus.SelectedIndex = -1
			End If
		End If
		
		_noEvents = False
		toolStripStatusLabel.Text = ""
	End Sub
	
	'Call RefreshUpdateList with defauls.
	Sub RefreshUpdateList()
		Call RefreshUpdateList(False)
	End Sub
	
	'Refresh the main data grid view with updates based on the currently selected tree node.
	' If the optional parameter selectedUpdateID is given then use it to select
	' the current update again after the data grid view is refreshed.  This mechanism
	' allows us to maintain the current selection when the data grid view is refreshed
	' and the currently selected update might no longer exist or has a different index value.
	Sub RefreshUpdateList(maintainSelectedRow As Boolean)
		Dim originalValue As String
		
		_noEvents = True
		toolStripStatusLabel.Text = "Refreshing Update List"
		Me.Update
		
		'Set current row to negative one.
		'Me._currentRowIndex = -1
		
		If Me.treeView.SelectedNode Is Nothing OrElse _
			Me.treeView.SelectedNode.Tag Is Nothing Then
			_dgvMain.DataSource = Nothing 'Clear the main DGV.
			'Clear the udpate data by calling the loads with an index equal to the number of rows.
			Call LoadUpdateInfo( Me._dgvMain.Rows.Count)
			Call LoadUpdateStatus( Me._dgvMain.Rows.Count)
			Exit Sub
		Else If Not TypeOf Me.treeView.SelectedNode.Tag Is IUpdateCategory Then
			Exit Sub
		Else
			If DirectCast(Me.treeView.SelectedNode.Tag, IUpdateCategory).ProhibitsUpdates = False  Then
				
				'If we are maintaining the status then save the status.
				If maintainSelectedRow And _dgvMain.SelectedRows.Count = 1 Then
					originalValue = _dgvMain.CurrentRow.Cells.Item("Id").Value.ToString
				Else
					maintainSelectedRow = False
					originalValue = ""
				End If
				
				
				'Set datasource to list of updates.  Exit if no updates are found.
				_dgvMain.DataSource = GetUpdateList( DirectCast(Me.treeView.SelectedNode.Tag, IUpdateCategory) )
				If _dgvMain.DataSource Is Nothing Then Exit Sub
				
				'Hide column.
				Me._dgvMain.Columns("IUpdate").Visible = False
				Me._dgvMain.Columns("Id").Visible = False
				
				'Change header text.
				Me._dgvMain.Columns("CreationDate").HeaderText = "Creation Date"
				
				
				'If updates are loaded in the DGV.
				If _dgvMain.Rows.Count > 0 Then
					Call LoadDgvState(_dgvMain)
					
					'If we are maintaining the row.
					If maintainSelectedRow Then
						'Select the original row.
						For Each tmpRow As DataGridViewRow In Me._dgvMain.Rows
							If originalValue = tmpRow.Cells("Id").Value.ToString Then
								_dgvMain.CurrentCell = tmpRow.Cells("Title")
								Exit For
							Else If tmpRow.Index = _dgvMain.Rows.Count - 1
								_dgvMain.CurrentCell =  _dgvMain.Rows(0).Cells("Title")
							End If
						Next
					Else
						_dgvMain.CurrentCell = _dgvMain.Rows(0).Cells("Title")
					End If
					
					'Load the currently selected udpate's data.
					If Not Me._dgvMain.CurrentRow Is Nothing Then
						Call LoadUpdateInfo( Me._dgvMain.CurrentRow.Index)
						Call LoadUpdateStatus( Me._dgvMain.CurrentRow.Index)
					End If
					
					'If the user is currently on the report tab then update it.
					' Otherwise, clear the combo selections.
					If Me.tabMainUpdates.SelectedTab.Name = Me.tabUpdateReport.Name Then
						If Not Me._dgvMain.CurrentRow Is Nothing Then
							Call LoadUpdateReport(Me._dgvMain.CurrentRow.Index)
						End If
						Call LoadDgvState(dgvUpdateReport)
						
					Else
						
						Me.dgvUpdateReport.DataSource = Nothing
						Me.cboTargetGroup.SelectedIndex =  -1
						Me.cboUpdateStatus.SelectedIndex = -1
					End If
				End If
			End If
		End If
		
		toolStripStatusLabel.Text = ""
		_noEvents = False
	End Sub
	#End Region
	
	#Region "DGV Methods"
	'This routine loads the data from the currently selected row
	' in the main DGV.  Since there is no good row changed event in
	' VB we are using the mousedown event of the DGV.  Since the user
	' might click multiple times on the same row we track the current row
	' ourselves using the intCurrentRow object.  In this way we do not
	' load the same row twice.
	Sub LoadRow( rowIndex As Integer)
		'If the current row hasn't changed, there is no selected treenode,
		' or that tree node's tag is not populated then exit this routine.
		If  Me.treeView.SelectedNode Is Nothing OrElse _
			Me.treeView.SelectedNode.Tag Is Nothing Then
			Exit Sub
			'Computer Node
		ElseIf TypeOf Me.treeView.SelectedNode.Tag Is IComputerTargetGroup Then
			'_currentRowIndex = rowIndex 'Set new row as current.
			
			Call LoadComputerInfo( rowIndex )
			
			'If the user is currently on the Report tab then update it
			' Otherwise clear the combo selections.
			If Me.tabMainComputers.SelectedTab.Name = Me.tabComputerReport.Name Then
				Call LoadComputerReport(rowIndex)
			Else
				_noEvents = True
				Me.dgvUpdateReport.DataSource = Nothing
				Me.cboTargetGroup.SelectedIndex =  -1
				Me.cboUpdateStatus.SelectedIndex = -1
				_noEvents = False
			End If
			'Update node.
		ElseIf TypeOf Me.treeView.SelectedNode.Tag Is IUpdateCategory Then
			
			'Load the currently selected udpate's data.
			Call LoadUpdateInfo( rowIndex )
			Call LoadUpdateStatus( rowIndex )
			
			'If the user is currently on the report tab then update it.
			' Otherwise clear the combo selections.
			If Me.tabMainUpdates.SelectedTab.Name = Me.tabUpdateReport.Name Then
				Call LoadUpdateReport(rowIndex)
			Else
				_noEvents = True
				Me.dgvUpdateReport.DataSource = Nothing
				Me.cboTargetGroup.SelectedIndex =  -1
				Me.cboUpdateStatus.SelectedIndex = -1
				_noEvents = False
			End If
		End If
	End Sub
	
	'Load the update info for the currently selected update.
	Sub LoadUpdateInfo( rowIndex As Integer )
		Me.Cursor = Cursors.WaitCursor 'Set wait cursor.
		
		Call ClearUpdateInfo
		
'		'Exit if the index passed in is not withing range.
'		If Me._dgvMain.Rows.Count <= rowIndex Then Exit Sub
		
		
								
		'Make sure that the rowIndex is within range, at least one row is selected, and the node selected
		' is an update category.
		If Me._dgvMain.Rows.Count > rowIndex AndAlso Me._dgvMain.SelectedRows.Count = 1 AndAlso _
			TypeOf Me.treeView.SelectedNode.Tag Is IUpdateCategory Then
									
			'Load the data
			Dim update As IUpdate = DirectCast(Me._dgvMain.Rows(rowIndex).Cells("IUpdate").Value, IUpdate)
			If update.UpdateType = UpdateType.Software Then
				Me.txtPackageType.Text = "Update"
			Else If update.UpdateType = UpdateType.SoftwareApplication
				Me.txtPackageType.Text = "Application"
			Else If update.UpdateType = UpdateType.Driver
				Me.txtPackageType.Text = "Driver"
			Else
				Me.txtPackageType.Text = String.Empty
			End If
			
			Me.txtPackage.Text = update.Id.UpdateId.ToString
			Me.txtPackageTitle.Text = update.Title
			Me.txtDescription.Text = update.Description
			Me.txtClassification.Text = update.UpdateClassificationTitle
			If update.SecurityBulletins.Count > 0 Then Me.txtBulletinID.Text = update.SecurityBulletins(0)
			If update.CompanyTitles.Count > 0 Then Me.txtVendor.Text = update.CompanyTitles.Item(0)
			If update.ProductTitles.Count > 0 Then Me.txtProduct.Text = update.ProductTitles.Item(0)
			If update.KnowledgebaseArticles.Count > 0 Then Me.txtArticleID.Text = update.KnowledgebaseArticles.Item(0)
			Me.txtServerity.Text = update.MsrcSeverity.ToString
			If update.AdditionalInformationUrls.Count > 0 Then Me.txtMoreInfoURL.Text = update.AdditionalInformationUrls.Item(0)
			Me.txtImpact.Text = update.InstallationBehavior.Impact.ToString
			Me.txtRebootBehavior.Text = update.InstallationBehavior.RebootBehavior.ToString
			Me.txtUninstall.Text = update.UninstallationBehavior.IsSupported.ToString
			
			'Set the prerequisite objects.
			If update.GetRelatedUpdates( UpdateRelationship.UpdatesRequiredByThisUpdate).Count > 0 Then
				lblPrerequisites.Visible = True
				PrerequisiteUpdatesForm = Nothing
			Else
				lblPrerequisites.Visible = False
			End If
			
			'Set the superseded objects
			If update.HasSupersededUpdates Then
				lblSupersedes.Visible = True
				SupersededUpdatesForm = Nothing
			Else
				lblSupersedes.Visible = False
			End If
		End If
		
		Me.Cursor = Cursors.Arrow 'Set arrow cursor.
	End Sub
	
	'Populate the update status DGV.
	Sub LoadUpdateStatus( rowIndex As Integer)
		
		'Make sure we are in a data row, not the header and that the tree node
		' selected has a tag on which we can base how to load the data
		If Me._dgvMain.Rows.Count <= rowIndex OrElse Me._dgvMain.SelectedRows.Count <> 1 Then
			_noEvents = True
			'Clear the data source of the status DGV.
			Me.dgvUpdateStatus.DataSource = Nothing
			_noEvents = False
		Else If TypeOf Me.treeView.SelectedNode.Tag Is IUpdateCategory Then
			
			
			'Set the data source of the status DGV.
			Me.dgvUpdateStatus.DataSource = GetUpdateStatus( DirectCast(Me._dgvMain.Rows(rowIndex).Cells("IUpdate").Value, IUpdate) )
			
			'Set header texts for status DGV.
			Me.dgvUpdateStatus.Columns("GroupName").HeaderText = "Group Name"
			Me.dgvUpdateStatus.Columns("InstalledCount").HeaderText = "Installed"
			Me.dgvUpdateStatus.Columns("NotInstalledCount").HeaderText = "Not Installed"
			Me.dgvUpdateStatus.Columns("NotApplicableCount").HeaderText = "Not Applicable"
			Me.dgvUpdateStatus.Columns("FailedCount").HeaderText = "Failed"
			Me.dgvUpdateStatus.Columns("DownloadedCount").HeaderText = "Downloaded"
			Me.dgvUpdateStatus.Columns("UnknownCount").HeaderText = "Unknown"
			Me.dgvUpdateStatus.Columns("LastUpdated").HeaderText = "Last Updated"
			
			If dgvUpdateStatus.Rows.Count > 0 Then
				Call LoadDgvState( dgvUpdateStatus )
			End If
		End If
		
	End Sub
	
	'Load the currently selected computer's info into the form.
	Sub LoadComputerInfo( rowIndex As Integer)
		Me.Cursor = Cursors.WaitCursor 'Set wait cursor
		
		Call ClearComputerInfo
		
		If Me._dgvMain.Rows.Count >= rowIndex AndAlso Me._dgvMain.SelectedRows.Count = 1 Then
			'Set the update scope to only include locally published updates for the selected group.
			Dim tmpUpdateScope As UpdateScope = New UpdateScope
			tmpUpdateScope.UpdateSources = UpdateSources.Other
			
			'Add groups to approvals reported based on application settings.
			If appSettings.ApprovedUpdatesOnly Then
				AddParentGroupApprovals(tmpUpdateScope, DirectCast(treeView.SelectedNode.Tag, IComputerTargetGroup), appSettings.InheritApprovals) 'Add groups recursively.
			End If
			
			Dim tmpUpdateSummary As IUpdateSummary = DirectCast(Me._dgvMain.Rows(rowIndex).Cells("IComputerTarget").Value, IComputerTarget).GetUpdateInstallationSummary(tmpUpdateScope)
			Me.txtUpdatesWErrorsNum.Text = CStr(tmpUpdateSummary.FailedCount)
			Me.txtUpdatesNeededNum.Text = CStr(tmpUpdateSummary.NotInstalledCount)
			Me.txtUpdatesInstalledorNANum.Text = CStr(tmpUpdateSummary.NotApplicableCount + tmpUpdateSummary.InstalledCount)
			Me.txtUpdateNoStatusNum.Text = CStr(tmpUpdateSummary.UnknownCount)
		End If
		
		Me.Cursor = Cursors.Arrow 'Set arrow cursor
	End Sub
	
	'Load the summary data for each update based on the currently selected group.
	Sub LoadComputerGroupStatus
		'Make sure the selected not has a tag.
		If Me.treeView.SelectedNode Is Nothing OrElse _
			Me.treeView.SelectedNode.Tag Is Nothing Then
			'Clear the data source of the status DGV.
			Me.dgvComputerGroupStatus.DataSource = Nothing
		Else If TypeOf Me.treeView.SelectedNode.Tag Is IComputerTargetGroup Then
			
			'Set the data source of the status DGV.
			Me.dgvComputerGroupStatus.DataSource = GetComputerGroupStatus(DirectCast(Me.treeView.SelectedNode.Tag, IComputerTargetGroup))
			
			'Set header texts for status DGV.
			dgvComputerGroupStatus.Columns("Title").HeaderText = "Title"
			dgvComputerGroupStatus.Columns("InstalledCount").HeaderText = "Installed"
			dgvComputerGroupStatus.Columns("NotInstalledCount").HeaderText = "Not Installed"
			dgvComputerGroupStatus.Columns("NotApplicableCount").HeaderText = "Not Applicable"
			dgvComputerGroupStatus.Columns("FailedCount").HeaderText = "Failed"
			dgvComputerGroupStatus.Columns("DownloadedCount").HeaderText = "Downloaded"
			dgvComputerGroupStatus.Columns("UnknownCount").HeaderText = "Unknown"
			dgvComputerGroupStatus.Columns("LastUpdated").HeaderText = "Last Updated"
			
			If dgvComputerGroupStatus.Rows.Count > 0 Then
				Call LoadDgvState(dgvComputerGroupStatus)
			End If
		End If
	End Sub
	
	'Call LoadComputerReport with the default parameters.
	Sub LoadComputerReport (rowIndex As Integer)
		LoadComputerReport (rowIndex, False)
	End Sub
	
	'Load the report data for the currently selected computer.
	Sub LoadComputerReport (rowIndex As Integer, maintainSelectedRow As Boolean)
		
		Dim originalValue As String
		Me.Cursor = Cursors.WaitCursor 'Set wait cursor
		_noEvents = True
		
		'Status of Update Status combobox.
		If Me.cboUpdateStatus.SelectedIndex = -1 Then
			'Clear the DGV.
			dgvComputerReport.DataSource = Nothing
		Else
			
			'If we are maintaining the status then save the status.
			If maintainSelectedRow And dgvComputerReport.SelectedRows.Count = 1 Then
				originalValue = DirectCast(dgvComputerReport.CurrentRow.Cells.Item("UpdateTitle").Value, String)
			Else
				maintainSelectedRow = False
				originalValue = ""
			End If
			
			
			
			'Set the data source.
			dgvComputerReport.DataSource = GetComputerReport(DirectCast(Me._dgvMain.Rows(rowIndex).Cells("TargetID").Value, String), Me.cboUpdateStatus.Text)
			
			'Hide columns
			dgvComputerReport.Columns("IUpdate").Visible = False
			dgvComputerReport.Columns("UpdateID").Visible = False
			
			'Rename some columns.
			dgvComputerReport.Columns("UpdateTitle").HeaderText = "Update Title"
			dgvComputerReport.Columns("UpdateInstallationState").HeaderText = "Status"
			dgvComputerReport.Columns("UpdateApprovalAction").HeaderText = "Approval"
			
			'Make the status column's text blue
			dgvComputerReport.Columns("UpdateInstallationState").DefaultCellStyle.ForeColor = Color.Blue
			
			'If updates are loaded in the DGV.
			If dgvComputerReport.Rows.Count > 0 Then
				btnComputerRefreshReport.Enabled = True
				ExportReportToolStripMenuItem.Enabled = True
				
				Call LoadDgvState(dgvComputerReport)
				
				'If we are maintaining the selected row.
				If maintainSelectedRow Then
					
					'Select and load the original row.
					For Each tmpRow As DataGridViewRow In dgvComputerReport.Rows
						If originalValue = DirectCast(tmpRow.Cells("UpdateTitle").Value, String) Then
							dgvComputerReport.CurrentCell = tmpRow.Cells("UpdateTitle")
							Exit For
						Else If tmpRow.Index = dgvComputerReport.Rows.Count - 1
							dgvComputerReport.CurrentCell =  dgvComputerReport.Rows(0).Cells("UpdateTitle")
						End If
					Next
				Else 'Select first row.
					dgvComputerReport.CurrentCell =  dgvComputerReport.Rows(0).Cells("UpdateTitle")
				End If
			Else 'No rows returned.
				btnComputerRefreshReport.Enabled = False
				exportReportToolStripMenuItem.Enabled = False
			End If 'Rows returned.
			
		End If 'Nothing selected in cboUdpateStatus.
		
		_noEvents = False
		Me.Cursor = Cursors.Arrow 'Set arrow cursor
	End Sub
	
	'Call LoadUpdateReport with defaults.
	Sub LoadUpdateReport( rowIndex As Integer )
		Call LoadUpdateReport(rowIndex, false)
	End Sub
	
	'Populate the update report DGV.
	Sub LoadUpdateReport( rowIndex As Integer, maintainSelectedRow As Boolean)
		Dim originalValue As String
		Me.Cursor = Cursors.WaitCursor 'Set wait cursor.
		_noEvents = True
		
		'If an Update Status was selected or no update is selected.
		If cboTargetGroup.SelectedIndex = -1 OrElse Me._dgvMain.Rows(rowIndex).Cells("IUpdate").Value is Nothing Then
			'Clear the DGV.
			Me.dgvUpdateReport.DataSource = Nothing
		Else
			
			'If the user hasn't selected an update status then choose any status.
			If cboUpdateStatus.SelectedIndex = -1 Then cboUpdateStatus.Text = "Any"
			
			'If we are maintaining the status then save the status.
			If maintainSelectedRow AndAlso Not dgvUpdateReport.CurrentRow Is Nothing Then
				originalValue = DirectCast(dgvUpdateReport.CurrentRow.Cells.Item("ComputerName").Value, String)
			Else
				maintainSelectedRow = False
				originalValue = ""
			End If
			
			'Set the data source.
			dgvUpdateReport.DataSource = GetUpdateReport(DirectCast(Me._dgvMain.Rows(rowIndex).Cells("IUpdate").Value, IUpdate), DirectCast(Me.cboTargetGroup.SelectedItem,ComboTargetGroups).Value,Me.cboUpdateStatus.Text)
			
			'Hide the ID column.
			dgvUpdateReport.Columns("ComputerID").Visible = False
			
			'Rename some columns.
			dgvUpdateReport.Columns("ComputerName").HeaderText = "Computer Name"
			dgvUpdateReport.Columns("UpdateInstallationState").HeaderText = "Status"
			dgvUpdateReport.Columns("UpdateApprovalAction").HeaderText = "Approval"
			
			'Make the status column's text blue
			dgvUpdateReport.Columns("UpdateInstallationState").DefaultCellStyle.ForeColor = Color.Blue
			
			'If updates are loaded in the DGV.
			If dgvUpdateReport.Rows.Count > 0 Then
				btnUpdateRefreshReport.Enabled = True
				exportReportToolStripMenuItem.Enabled = True
				
				Call LoadDgvState(dgvUpdateReport)
				
				'If we are maintaining the selected row.
				If maintainSelectedRow Then
					
					'Select and load the original row.
					For Each tmpRow As DataGridViewRow In dgvUpdateReport.Rows
						If originalValue = DirectCast(tmpRow.Cells("ComputerName").Value, String) Then
							dgvUpdateReport.CurrentCell = tmpRow.Cells("ComputerName")
							Exit For
						Else If tmpRow.Index = dgvUpdateReport.Rows.Count - 1
							dgvUpdateReport.CurrentCell =  dgvUpdateReport.Rows(0).Cells("ComputerName")
						End If
					Next
				Else 'Select the first row.
					dgvUpdateReport.CurrentCell =  dgvUpdateReport.Rows(0).Cells("ComputerName")
				End If
				
			Else
				btnUpdateRefreshReport.Enabled = False
				exportReportToolStripMenuItem.Enabled = False
			End If
		End If 'Status of combobox.
		
		_noEvents = False
		Me.Cursor = Cursors.Arrow 'Set arrow cursor.
	End Sub
	
	'Load the state of the passed in DGV using saved settings.
	' Only do so if the number of columns match. While the
	' state is being loaded prevent any events from happening.
	Sub LoadDgvState(ByRef dgv As DataGridView )
		_noEvents = True
		
		'Differentiate the right setting by the DGV's name.
		If dgv.Name = Me._dgvMain.Name Then
			
			'Make sure a node is selected and has a tag.
			If Not treeView.SelectedNode Is Nothing AndAlso _
				Not treeView.SelectedNode.Tag Is Nothing Then
				
				'If the selected node's tag is an update or a computer node.
				If TypeOf treeView.SelectedNode.Tag Is IComputerTargetGroup Then
					
					'Sort the columns if a sort order is saved.
					If Not appSettings.StateMainComputersDGV.SortColumn Is Nothing AndAlso _
						Not dgv.Columns(appSettings.StateMainComputersDGV.SortColumn) Is Nothing Then
						
						dgv.Sort(dgv.Columns(appSettings.StateMainComputersDGV.SortColumn), _
							appSettings.StateMainComputersDGV.SortDirection )
					End If
					
					'Set the widths using the saved values
					If appSettings.StateMainComputersDGV.ColumnFillWeights.Length = dgv.Columns.Count Then
						For Each column As DataGridViewColumn In dgv.Columns
							column.FillWeight = appSettings.StateMainComputersDGV.ColumnFillWeights(column.Index)
						Next
					End If
					'If type is an Update node.
				Else If TypeOf treeView.SelectedNode.Tag Is IUpdateCategory Then
					
					'Sort the columns if a sort order is saved.
					If Not appSettings.StateMainUpdatesDGV.SortColumn Is Nothing AndAlso _
						Not dgv.Columns(appSettings.StateMainUpdatesDGV.SortColumn) Is Nothing Then
						dgv.Sort(dgv.Columns(appSettings.StateMainUpdatesDGV.SortColumn), _
							appSettings.StateMainUpdatesDGV.SortDirection )
					End If
					
					If appSettings.StateMainUpdatesDGV.ColumnFillWeights.Length = dgv.Columns.Count Then
						For Each column As DataGridViewColumn In dgv.Columns
							column.FillWeight = appSettings.StateMainUpdatesDGV.ColumnFillWeights(column.Index)
						Next
					End If
				End If
			End If 'Node is selected and tag instantiated.
		Else If dgv.Name = Me.dgvComputerReport.Name Then
			
			'Sort the columns if a sort order is saved.
			If  Not appSettings.StateComputerReportDGV.SortColumn = Nothing AndAlso _
				Not dgv.Columns(appSettings.StateComputerReportDGV.SortColumn) Is Nothing Then
				
				dgv.Sort(dgv.Columns(appSettings.StateComputerReportDGV.SortColumn), _
					appSettings.StateComputerReportDGV.SortDirection )
			End If
			
			If appSettings.StateComputerReportDGV.ColumnFillWeights.Length = dgv.Columns.Count Then
				
				For Each column As DataGridViewColumn In dgv.Columns
					column.FillWeight = appSettings.StateComputerReportDGV.ColumnFillWeights(column.Index)
				Next
			End If
		Else If dgv.Name = Me.dgvComputerGroupStatus.Name Then
			
			'Sort the columns if a sort order is saved.
			If  Not appSettings.StateComputerGroupStatusDGV.SortColumn = Nothing AndAlso _
				Not dgv.Columns(appSettings.StateComputerGroupStatusDGV.SortColumn) Is Nothing Then
				
				dgv.Sort(dgv.Columns(appSettings.StateComputerGroupStatusDGV.SortColumn), _
					appSettings.StateComputerGroupStatusDGV.SortDirection )
			End If
			
			If appSettings.StateComputerGroupStatusDGV.ColumnFillWeights.Length = dgv.Columns.Count Then
				
				For Each column As DataGridViewColumn In dgv.Columns
					column.FillWeight = appSettings.StateComputerGroupStatusDGV.ColumnFillWeights(column.Index)
				Next
			End If
		Else If dgv.Name = Me.dgvUpdateReport.Name Then
			
			'Sort the columns if a sort order is saved.
			If  Not appSettings.StateUpdateReportDGV.SortColumn = Nothing AndAlso _
				Not dgv.Columns(appSettings.StateUpdateReportDGV.SortColumn) Is Nothing Then
				
				dgv.Sort(dgv.Columns(appSettings.StateUpdateReportDGV.SortColumn), _
					appSettings.StateUpdateReportDGV.SortDirection )
			End If
			
			If appSettings.StateUpdateReportDGV.ColumnFillWeights.Length = dgv.Columns.Count Then
				
				For Each column As DataGridViewColumn In dgv.Columns
					column.FillWeight = appSettings.StateUpdateReportDGV.ColumnFillWeights(column.Index)
				Next
			End If
		Else If dgv.Name = Me.dgvUpdateStatus.Name Then
			
			'Sort the columns if a sort order is saved.
			If  Not appSettings.StateUpdateStatusDGV.SortColumn = Nothing AndAlso _
				Not dgv.Columns(appSettings.StateUpdateStatusDGV.SortColumn) Is Nothing Then
				
				dgv.Sort(dgv.Columns(appSettings.StateUpdateStatusDGV.SortColumn), _
					appSettings.StateUpdateStatusDGV.SortDirection )
			End If
			
			If appSettings.StateUpdateStatusDGV.ColumnFillWeights.Length = dgv.Columns.Count Then
				
				For Each column As DataGridViewColumn In dgv.Columns
					column.FillWeight = appSettings.StateUpdateStatusDGV.ColumnFillWeights(column.Index)
				Next
			End If
		End If
		
		_noEvents = False
	End Sub
	
	'Save the state of DGVs based on the type of node passed in.
	Sub SaveDgvState ( ByRef node As TreeNode )
		
		'If the node has a tag then save the appropriate DGVs.
		If Not node Is Nothing AndAlso Not node.Tag Is Nothing Then
			If TypeOf node.Tag Is IComputerTargetGroup Then 'Computer Note
				Call SaveDgvState( _dgvMain)
				If tabMainComputers.SelectedTab.Equals(tabComputerReport) Then
					Call SaveDgvState (dgvComputerReport)
				Else If tabMainComputers.SelectedTab.Equals(tabComputerStatus) Then
					Call SaveDgvState (dgvComputerGroupStatus)
				End If
			Else If TypeOf node.Tag Is IUpdateCategory Then 'Update Node
				Call SaveDgvState( _dgvMain)
				If tabMainUpdates.SelectedTab.Equals(tabUpdateReport) Then
					Call SaveDgvState (dgvUpdateReport)
				Else If tabMainUpdates.SelectedTab.Equals(tabUpdateStatus) Then
					Call SaveDgvState (dgvUpdateStatus)
				End If
			End If
		End If
	End Sub
	
	'Save the state the DGV
	Sub SaveDGVState(ByRef dgv As DataGridView )
		
		'Save the dgv's columns to a temporary array.
		Dim tmpArray As Integer() = New Integer(dgv.Columns.Count - 1){}
		For Each column As DataGridViewColumn In dgv.Columns
			tmpArray (column.Index) = CInt(column.FillWeight)
		Next
		
		'Differentiate the right setting by the DGV's name.
		If dgv.Name = Me._dgvMain.Name Then
			
			'Make sure a node is selected and has a tag.
			If Not treeView.SelectedNode Is Nothing AndAlso _
				Not treeView.SelectedNode.Tag Is Nothing Then
				
				'If the selected node's tag is an update or a computer node.
				If TypeOf treeView.SelectedNode.Tag Is IComputerTargetGroup Then
					
					'Save the sort column if the DGV is sorted.
					If dgv.SortedColumn Is Nothing AndAlso dgv.Rows.Count > 0 Then
						
						appSettings.StateMainComputersDGV.SortColumn = Nothing
						appSettings.StateMainComputersDGV.SortDirection = ListSortDirection.Descending
					ElseIf Not dgv.SortedColumn Is Nothing
						appSettings.StateMainComputersDGV.SortColumn = dgv.SortedColumn.Name
						
						'Save the sort order.
						If dgv.SortOrder = SortOrder.Ascending Then
							appSettings.StateMainComputersDGV.SortDirection = ListSortDirection.Ascending
						Else If dgv.SortOrder = SortOrder.Descending Then
							appSettings.StateMainComputersDGV.SortDirection = ListSortDirection.Descending
						End If
					End If
					
					'Save the column fill weights and the dgv name.
					appSettings.StateMainComputersDGV.ColumnFillWeights = tmpArray
					appSettings.StateMainComputersDGV.Name = dgv.Name
					'If type is an Update node.
				Else If TypeOf treeView.SelectedNode.Tag Is IUpdateCategory Then
					
					'Save the sort column if the DGV is sorted.
					If dgv.SortedColumn Is Nothing AndAlso dgv.Rows.Count > 0 Then
						
						appSettings.StateMainUpdatesDGV.SortColumn = Nothing
						appSettings.StateMainUpdatesDGV.SortDirection = ListSortDirection.Descending
					ElseIf Not dgv.SortedColumn Is Nothing
						appSettings.StateMainUpdatesDGV.SortColumn = dgv.SortedColumn.Name
						
						'Save the sort order.
						If dgv.SortOrder = SortOrder.Ascending Then
							appSettings.StateMainUpdatesDGV.SortDirection = ListSortDirection.Ascending
						Else If dgv.SortOrder = SortOrder.Descending Then
							appSettings.StateMainUpdatesDGV.SortDirection = ListSortDirection.Descending
						End If
					End If
					
					'Save the column fill weights and the dgv name.
					appSettings.StateMainUpdatesDGV.ColumnFillWeights = tmpArray
					appSettings.StateMainUpdatesDGV.Name = dgv.Name
				End If
			End If 'Node is selected tag instantiated.
		Else If dgv.Name = Me.dgvComputerReport.Name Then
			
			'Save the sort column if the DGV is sorted.
			If dgv.SortedColumn Is Nothing AndAlso dgv.Rows.Count > 0 Then
				appSettings.StateComputerReportDGV.SortColumn = Nothing
				appSettings.StateComputerReportDGV.SortDirection = ListSortDirection.Descending
			ElseIf Not dgv.SortedColumn Is Nothing
				appSettings.StateComputerReportDGV.SortColumn = dgv.SortedColumn.Name
				
				'Save the sort order.
				If dgv.SortOrder = SortOrder.Ascending Then
					appSettings.StateComputerReportDGV.SortDirection = ListSortDirection.Ascending
				Else If dgv.SortOrder = SortOrder.Descending Then
					appSettings.StateComputerReportDGV.SortDirection = ListSortDirection.Descending
				End If
			End If
			
			'Save the column fill weights and the dgv name.
			appSettings.StateComputerReportDGV.ColumnFillWeights = tmpArray
			appSettings.StateComputerReportDGV.Name = dgv.Name
		Else If dgv.Name = Me.dgvComputerGroupStatus.Name Then
			
			'Save the sort column if the DGV is sorted.
			If dgv.SortedColumn Is Nothing AndAlso dgv.Rows.Count > 0 Then
				appSettings.StateComputerGroupStatusDGV.SortColumn = Nothing
				appSettings.StateComputerGroupStatusDGV.SortDirection = ListSortDirection.Descending
			ElseIf Not dgv.SortedColumn Is Nothing
				appSettings.StateComputerGroupStatusDGV.SortColumn = dgv.SortedColumn.Name
				
				'Save the sort order.
				If dgv.SortOrder = SortOrder.Ascending Then
					appSettings.StateComputerGroupStatusDGV.SortDirection = ListSortDirection.Ascending
				Else If dgv.SortOrder = SortOrder.Descending Then
					appSettings.StateComputerGroupStatusDGV.SortDirection = ListSortDirection.Descending
				End If
			End If
			
			'Save the column fill weights and the dgv name.
			appSettings.StateComputerGroupStatusDGV.ColumnFillWeights = tmpArray
			appSettings.StateComputerGroupStatusDGV.Name = dgv.Name
		Else If dgv.Name = Me.dgvUpdateReport.Name Then
			
			'Save the sort column if the DGV is sorted.
			If dgv.SortedColumn Is Nothing AndAlso dgv.Rows.Count > 0 Then
				appSettings.StateUpdateReportDGV.SortColumn = Nothing
				appSettings.StateUpdateReportDGV.SortDirection = ListSortDirection.Descending
			ElseIf Not dgv.SortedColumn Is Nothing
				appSettings.StateUpdateReportDGV.SortColumn = dgv.SortedColumn.Name
				
				'Save the sort order.
				If dgv.SortOrder = SortOrder.Ascending Then
					appSettings.StateUpdateReportDGV.SortDirection = ListSortDirection.Ascending
				Else If dgv.SortOrder = SortOrder.Descending Then
					appSettings.StateUpdateReportDGV.SortDirection = ListSortDirection.Descending
				End If
			End If
			
			'Save the column fill weights and the dgv name.
			appSettings.StateUpdateReportDGV.ColumnFillWeights = tmpArray
			appSettings.StateUpdateReportDGV.Name = dgv.Name
			
		Else If dgv.Name = Me.dgvUpdateStatus.Name Then
			
			'Save the sort column if the DGV is sorted.
			If dgv.SortedColumn Is Nothing AndAlso dgv.Rows.Count > 0 Then
				appSettings.StateUpdateStatusDGV.SortColumn = Nothing
				appSettings.StateUpdateStatusDGV.SortDirection = ListSortDirection.Descending
			ElseIf Not dgv.SortedColumn Is Nothing
				appSettings.StateUpdateStatusDGV.SortColumn = dgv.SortedColumn.Name
				
				'Save the sort order.
				If dgv.SortOrder = SortOrder.Ascending Then
					appSettings.StateUpdateStatusDGV.SortDirection = ListSortDirection.Ascending
				Else If dgv.SortOrder = SortOrder.Descending Then
					appSettings.StateUpdateStatusDGV.SortDirection = ListSortDirection.Descending
				End If
				
				'Save the column fill weights and the dgv name.
				appSettings.StateUpdateStatusDGV.ColumnFillWeights = tmpArray
				appSettings.StateUpdateReportDGV.Name = dgv.Name
			End If
		End If
	End Sub
	#End Region
End Class
				