Option Explicit On
Option Strict On
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

Partial Public Class MainForm
    Private m_serverNode As TreeNode
    Private m_rootNode As TreeNode
    Private m_originalValue As String
    Private m_noEvents As Boolean
    Private m_dgvMainLoading As Boolean
    Private m_windowState As PersistWindowState
    Private m_remainingTreePath As String
    Private ReadOnly m_updateStatus As String()

#Region "Properties"
    Private m_computerNode As TreeNode
    ReadOnly Property ComputerNode() As TreeNode
        Get
            Return m_computerNode
        End Get
    End Property

    Private m_vendorCollection As New VendorCollection
    ReadOnly Property VendorCollection() As VendorCollection
        Get
            Return m_vendorCollection
        End Get
    End Property

    Private m_updateNode As TreeNode
    ReadOnly Property UpdateNode() As TreeNode
        Get
            Return m_updateNode
        End Get
    End Property

    ''' <summary>
    ''' Controls the status toolstrip label.
    ''' </summary>
    ''' <value></value>
    ''' <returns>String</returns>
    Public Property Status() As String
        Get
            Return toolStripStatusLabel.Text
        End Get
        Set(value As String)
            toolStripStatusLabel.Text = value
        End Set
    End Property
#End Region

    Public Sub New()
        'Set the persist window object.
        m_windowState = New PersistWindowState()
        m_windowState.Parent = Me

        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        Me.InitializeComponent()

        'Populate the dropdowns
        m_updateStatus = New String() {Globals.globalRM.GetString("failed_or_needed"), Globals.globalRM.GetString("installed_not_applicable_no_status"), Globals.globalRM.GetString("failed"), Globals.globalRM.GetString("needed"), Globals.globalRM.GetString("installed_not_applicable"), Globals.globalRM.GetString("no_status"), Globals.globalRM.GetString("any")}
        Me.cboUpdateStatus.Items.AddRange(m_updateStatus)
        Me.cboComputerStatus.Items.AddRange(m_updateStatus)

        'Initialize the base treenodes
        m_updateNode = New TreeNode
        m_rootNode = New TreeNode
        m_serverNode = New TreeNode
        m_computerNode = New TreeNode
        m_noEvents = False

        'Sort Treeview
        treeView.Sorted = True

        'Clear status label.
        toolStripStatusLabel.Text = ""

        'Hide the header panel by default.
        Me.scHeader.Panel1Collapsed = True

        'Load settings.
        Me.chkApprovedOnly.Checked = Globals.appSettings.ApprovedUpdatesOnly
        Me.chkInheritApprovals.Checked = Globals.appSettings.InheritApprovals
        Me.chkInheritApprovals.Enabled = Me.chkApprovedOnly.Checked

    End Sub

#Region "Form Events"
    ''' <summary>
    '''Check to see if we are connected and set menu items accordingly.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MainFormActivated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Call SetToolStrip()
    End Sub

    ''' <summary>
    ''' Create and populate the base nodes.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MainFormLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        toolStripStatusLabel.Text = Globals.globalRM.GetString("status_loading_form")
        Me.Update()
        m_noEvents = True
        Call LoadMainForm()

        Call SetToolStrip()
        m_noEvents = False
        toolStripStatusLabel.Text = ""
    End Sub

    ''' <summary>
    ''' Save various details when the form is closing.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub MainFormFormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'Save the current DGV states.
        If Not treeView.SelectedNode Is Nothing AndAlso _
            Not treeView.SelectedNode.Tag Is Nothing Then
            Call SaveDgvState(treeView.SelectedNode)
        End If

        'Save the currently selected node's path
        If Not treeView.SelectedNode Is Nothing Then
            Globals.appSettings.TreePath = treeView.SelectedNode.FullPath
        End If

        'Save the settings to file
        Settings.SaveSettingsToFile(Globals.appSettings)
    End Sub

    ''' <summary>
    ''' When the splitter moved save its position.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SplitContainerSplitterMoved(sender As Object, e As SplitterEventArgs) Handles splitContainerHorz.SplitterMoved
        'Save the settings to the settings object depending on the selected node type.
        If Not m_noEvents AndAlso _
            Not treeView.SelectedNode Is Nothing AndAlso _
            Not treeView.SelectedNode.Tag Is Nothing Then

            If TypeOf treeView.SelectedNode.Tag Is IComputerTargetGroup Then 'Computer Note
                Globals.appSettings.ComputerSplitter = Me.splitContainerHorz.SplitterDistance
            ElseIf TypeOf treeView.SelectedNode.Tag Is IUpdateCategory Then 'Update Node
                Globals.appSettings.UpdateSplitter = Me.splitContainerHorz.SplitterDistance
            End If

            'This shouldn't be necessary but fixes a bug with the background when expanding a panel.
            Me.splitContainerHorz.Refresh()
        End If


    End Sub

    ''' <summary>
    ''' When the splitter moved save its position.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Sub SplitContainerVertSplitterMoved(sender As Object, e As SplitterEventArgs) Handles splitContainerVert.SplitterMoved
        Globals.appSettings.TreeSplitter = splitContainerVert.SplitterDistance
    End Sub

    ''' <summary>
    ''' If the user changes the show approved packages only option update the relevant controls.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub ChkApprovedOnlyCheckedChanged(sender As Object, e As EventArgs) Handles chkApprovedOnly.CheckedChanged
        'Save the change.
        Globals.appSettings.ApprovedUpdatesOnly = Me.chkApprovedOnly.Checked

        'Enable/Disable the inherit checkbox appropriately.
        Me.chkInheritApprovals.Enabled = Me.chkApprovedOnly.Checked

        'Refresh the computer list.
        If m_noEvents = False Then
            Cursor = Cursors.WaitCursor 'Set wait cursor.
            m_noEvents = True
            Call RefreshComputerList(True)
            Call LoadComputerGroupStatus()
            m_noEvents = False
            Cursor = Cursors.Arrow 'Set arrow cursor.
        End If
    End Sub
    ''' <summary>
    ''' If the user changes the inherit approval option update the relevant controls.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Sub ChkInheritApprovalsCheckedChanged(sender As Object, e As EventArgs) Handles chkInheritApprovals.CheckedChanged
        'Save the change.
        Globals.appSettings.InheritApprovals = Me.chkInheritApprovals.Checked

        'Refresh the computer list.
        If m_noEvents = False Then
            Cursor = Cursors.WaitCursor 'Set wait cursor.
            m_noEvents = True
            Call RefreshComputerList(True)
            Call LoadComputerGroupStatus()
            m_noEvents = False
            Cursor = Cursors.Arrow 'Set arrow cursor.
        End If
    End Sub

    ''' <summary>
    ''' Load the update report.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub CboTargetGroupSelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTargetGroup.SelectedIndexChanged
        If m_noEvents = False Then
            m_noEvents = True
            Me.Update()
            If Not Me.m_dgvMain.CurrentRow Is Nothing Then
                Call LoadUpdateReport(Me.m_dgvMain.CurrentRow.Index, True)
            End If
            m_noEvents = False
        End If
    End Sub

    ''' <summary>
    ''' Refresh the computer list.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub CboComputerStatusSelectedIndexChanged(sender As Object, e As EventArgs) Handles cboComputerStatus.SelectedIndexChanged
        If m_noEvents = False Then
            Cursor = Cursors.WaitCursor 'Set wait cursor.
            m_noEvents = True
            Call RefreshComputerList(True)
            m_noEvents = False
            Cursor = Cursors.Arrow 'Set arrow cursor.
        End If

        CheckBGWThreads()

    End Sub

    ''' <summary>
    ''' Update the appropriate controls depending on the type of tree node that is selected.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cboUpdateStatusSelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUpdateStatus.SelectedIndexChanged
        If m_noEvents = False Then
            m_noEvents = True
            If Not Me.treeView.SelectedNode Is Nothing AndAlso _
                Not Me.treeView.SelectedNode.Tag Is Nothing AndAlso _
                Me.cboUpdateStatus.SelectedIndex <> -1 AndAlso _
                Not Me.m_dgvMain.CurrentRow Is Nothing Then
                'If type is a ComputerTargetGroup load the computers in the DGV.
                If TypeOf Me.treeView.SelectedNode.Tag Is IComputerTargetGroup Then
                    Me.Update()
                    Call LoadComputerReport(Me.m_dgvMain.CurrentRow.Index, True)

                    'If type is an update node.
                ElseIf TypeOf Me.treeView.SelectedNode.Tag Is IUpdateCategory Then
                    Call LoadUpdateReport(Me.m_dgvMain.CurrentRow.Index, True)
                End If
            End If
            m_noEvents = False
        End If

        CheckBGWThreads()

    End Sub

    ''' <summary>
    ''' Refresh computer report.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub BtnComputerRefreshReportClick(sender As Object, e As EventArgs) Handles btnComputerRefreshReport.Click
        Cursor = Cursors.WaitCursor 'Set wait cursor.

        'Save the state.
        SaveDgvState(dgvComputerReport)

        m_noEvents = True
        If Not Me.m_dgvMain.CurrentRow Is Nothing Then
            Call LoadComputerReport(Me.m_dgvMain.CurrentRow.Index, True)
        End If
        m_noEvents = False
        Cursor = Cursors.Arrow 'Set arrow cursor.

        CheckBGWThreads()

    End Sub


    ''' <summary>
    ''' Refresh update report.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub BtnUpdateRefreshReportClick(sender As Object, e As EventArgs) Handles btnUpdateRefreshReport.Click
        Cursor = Cursors.WaitCursor 'Set wait cursor.

        'Save the state.
        SaveDgvState(dgvUpdateReport)

        m_noEvents = True

        If Not Me.DgvMain.CurrentRow Is Nothing Then
            Call LoadUpdateReport(Me.m_dgvMain.CurrentRow.Index, True)
        End If

        m_noEvents = False
        Cursor = Cursors.Arrow 'Set arrow cursor.

        CheckBGWThreads()

    End Sub

    ''' <summary>
    ''' Refresh computer list.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub BtnComputerListRefreshClick(sender As Object, e As EventArgs) Handles btnComputerListRefresh.Click
        Cursor = Cursors.WaitCursor 'Set wait cursor.

        'Save the state.
        SaveDgvState(m_dgvMain)

        m_noEvents = True
        Call RefreshComputerList(True)
        m_noEvents = False
        Cursor = Cursors.Arrow 'Set arrow cursor.
    End Sub

    ''' <summary>
    ''' Open the list of prerequisite updates.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub LblPrerequisitesClick(sender As Object, e As EventArgs) Handles lblPrerequisites.Click
        If Not Me.m_dgvMain.CurrentRow Is Nothing Then
            PrerequisiteUpdatesForm.ShowDialog(DirectCast(Me.m_dgvMain.CurrentRow.Cells("IUpdate").Value, IUpdate))
        End If
    End Sub

    ''' <summary>
    ''' Open the list of superseded updates.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub LblSupersedesClick(sender As Object, e As EventArgs) Handles lblSupersedes.Click
        If Not Me.m_dgvMain.CurrentRow Is Nothing Then
            SupersededUpdatesForm.ShowDialog(DirectCast(Me.m_dgvMain.CurrentRow.Cells("IUpdate").Value, IUpdate))
        End If
    End Sub

    ''' <summary>
    ''' When the user clicks on the link in the toolstrip bring them to the project's website.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub ToolStripStatusLabelLinkClick(sender As Object, e As EventArgs) Handles toolStripStatusLabelLink.Click
        'Launch home page
        System.Diagnostics.Process.Start("http://www.localupdatepublisher.com")
    End Sub

#End Region

#Region "Form Methods"
    ''' <summary>
    ''' Load the saved form settings, add and populate the base tree nodes.
    ''' </summary>
    Sub LoadMainForm()
        Me.Cursor = Cursors.WaitCursor 'Set wait cursor.
        splitContainerVert.SplitterDistance = Globals.appSettings.TreeSplitter

        Call ClearForm()

        If Not Me.treeView.ImageList Is Nothing Then
            Me.treeView.ImageIndex = Me.treeView.ImageList.Images.Count
            Me.treeView.SelectedImageIndex = Me.treeView.ImageList.Images.Count
        End If

        'Add to the base nodes.
        m_rootNode = Me.treeView.Nodes.Add("root", Globals.globalRM.GetString("update_services"))
        'Load tree with server nodes.
        For Each server As UpdateServer In ConnectionManager.ServerCollection
            Dim tmpServerName As String

            'If connecting to a local server show localhost as the name.
            If String.IsNullOrEmpty(server.Name) Then
                tmpServerName = "localhost"
            Else
                tmpServerName = server.Name
            End If

            Dim tmpNode As TreeNode = m_rootNode.Nodes.Add(tmpServerName, UCase(tmpServerName))
            tmpNode.Tag = server
            tmpNode.ImageIndex = 1
            tmpNode.SelectedImageIndex = 1
        Next

        'If the user wants to remember the tree path and
        ' there is a saved tree path then load it
        ' after removing the root node from the beginning.
        ' Otherwise just expand the root node.
        ' The call to load the saved node is ran asyncronously in order
        ' to wait for the tree nodes to be fully populated before
        ' making the call.
        If Globals.appSettings.RememberTreePath = False Or _
            String.IsNullOrEmpty(Globals.appSettings.TreePath) Or _
            Globals.appSettings.TreePath.Trim = m_rootNode.Text.Trim Then
            m_rootNode.Expand()
        Else
            m_rootNode.Expand()
            Me.Refresh()
            'treeView.BeginUpdate
            Call SelectNode(m_rootNode, Globals.appSettings.TreePath)
            'treeView.EndUpdate
        End If

        Me.Cursor = Cursors.Arrow 'Set arrow cursor.

    End Sub

    ''' <summary>
    ''' Call SelectNode with the default parameters.
    ''' </summary>
    Sub SelectNode()
        SelectNode(treeView.SelectedNode, Me.m_remainingTreePath)
    End Sub

    ''' <summary>
    ''' Recall the node that was previously selected.
    ''' </summary>
    ''' <param name="node">The current node to be found and selected.</param>
    ''' <param name="path">The path remaining to be searched.</param>
    ''' <remarks>This function is recursive.</remarks>
    Sub SelectNode(node As TreeNode, path As String)
        Dim nodeValue As String = path.Split("\"c)(0)
        Dim foundNode As TreeNode = Nothing

        If path = String.Empty Then Exit Sub

        Me.m_remainingTreePath = path

        'If the passed in node is the one we're looking for, select it.  Otherwise, loop through the children.
        If node.Text.Trim = nodeValue.Trim Then
            foundNode = node
            Call TreeViewAfterSelect(Me, New TreeViewEventArgs(node))
            foundNode.Expand()
        Else
            'Loop through the node's children to find the correct node,
            ' select it, set the foundNode, and exit the loop.
            For Each tmpNode As TreeNode In node.Nodes
                If tmpNode.Text.Trim = nodeValue.Trim Then
                    foundNode = tmpNode
                    treeView.SelectedNode = tmpNode
                    Call TreeViewAfterSelect(Me, New TreeViewEventArgs(tmpNode))
                    Exit For
                End If
            Next
        End If

        'If we found a node and there's more levels in the path continue.
        If Not foundNode Is Nothing Then
            If path.Contains("\") Then
                Call SelectNode(foundNode, Strings.Right(path, path.Length - (nodeValue.Length + 1)))
            Else
                Me.m_remainingTreePath = String.Empty
            End If
        End If
    End Sub

    ''' <summary>
    ''' Call Clear Form with defaults settings.
    ''' </summary>
    Sub ClearForm()
        Call ClearForm(True)
    End Sub

    ''' <summary>
    ''' Clear the form including the treview depending on the boolean.
    ''' </summary>
    ''' <param name="clearTreeView">Boolean that indicates if the treeview gets wiped out as well.</param>
    Sub ClearForm(clearTreeView As Boolean)
        m_noEvents = True

        'Clear the form.
        If clearTreeView Then
            treeView.Nodes.Clear()
            m_rootNode = Nothing
            m_serverNode = Nothing
            m_updateNode = Nothing
        End If

        scHeader.Panel1Collapsed = True
        pnlUpdates.Visible = False
        pnlComputers.Visible = False
        Refresh()

        m_dgvMainLoading = True
        m_dgvMain.DataSource = Nothing
        m_dgvMainLoading = False

        m_noEvents = False
    End Sub

    ''' <summary>
    ''' Clear the update tab.
    ''' </summary>
    ''' <remarks></remarks>
    Sub ClearUpdateInfo()
        Call ClearAllControls(Me.tabUpdateInfo.Controls)
    End Sub

    ''' <summary>
    ''' Clear the computer tab.
    ''' </summary>
    ''' <remarks></remarks>
    Sub ClearComputerInfo()
        Call ClearAllControls(Me.tabComputerInfo.Controls)
    End Sub

    ''' <summary>
    ''' It loops through a Control Collection and clears everything based on the control type.  An optional boolean
    ''' dictates if the sub calls itself recursively on any panels or groups it finds.
    ''' </summary>
    ''' <param name="container"></param>
    ''' <param name="Recurse"></param>
    ''' <remarks>
    ''' This code is lifted and modified from StackOverFlow.com
    ''' http://stackoverflow.com/questions/199521/vb-net-iterating-through-controls-in-a-container-object
    ''' </remarks>
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
                    ClearAllControls(tbpg.Controls, Recurse)
                End If
            End If
        Next
    End Sub

    ''' <summary>
    ''' This is a routine which will check the background threads and manage
    ''' the UI while they do their work.  The goal of the BGWs are to keep the
    ''' UI responsive, not to allow the user to continue working with the program.
    ''' </summary>
    Sub CheckBGWThreads()
        If Me.bgwComputerList.IsBusy Then
            Me.toolStripStatusLabel.Text = Globals.globalRM.GetString("refreshing_computer_list")
            Me.Enabled = False
        ElseIf Me.bgwComputerReport.IsBusy Then
            Me.toolStripStatusLabel.Text = Globals.globalRM.GetString("refreshing_computer_report")
            Me.Enabled = False
        ElseIf Me.bgwServers.IsBusy Then
            Me.Enabled = False
        ElseIf Me.bgwUpdateNodes.IsBusy Then
            toolStripStatusLabel.Text = Globals.globalRM.GetString("status_loading_update_categories")
            Me.Enabled = False
        ElseIf Me.bgwUpdateList.IsBusy Then
            toolStripStatusLabel.Text = Globals.globalRM.GetString("refreshing_update_list")
            Me.Enabled = False
        ElseIf Me.bgwUpdateReport.IsBusy Then
            toolStripStatusLabel.Text = Globals.globalRM.GetString("refreshing_update_report")
            Me.Enabled = False
        ElseIf Me.bgwResign.IsBusy Then
            toolStripStatusLabel.Text = Globals.globalRM.GetString("resigning_updates")
            Me.Enabled = False
        Else
            toolStripStatusLabel.Text = Nothing
            Me.Enabled = True
        End If

    End Sub

#End Region

#Region "Form Menu Events"

    ''' <summary>
    ''' Import updates from a catalog.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub ImportCatalogToolStripMenuItemClick(sender As Object, e As EventArgs) Handles importCatalogToolStripMenuItem.Click

        If ConnectionManager.Connected Then

            ImportCatalogForm.Location = New Point(Me.Location.X + 100, Me.Location.Y + 100)
            'Select a file and open the import catalog dialog.
            importFileDialog.Filter = Globals.globalRM.GetString("file_filter_cab") & "|" & Globals.globalRM.GetString("file_filter_xml")
            If Not importFileDialog.ShowDialog = DialogResult.Cancel Then
                My.Forms.ImportCatalogForm.ShowDialog(importFileDialog.FileName)
                Call LoadUpdateNodes()
                Call RefreshUpdateList()
            End If

        Else
            MsgBox(Globals.globalRM.GetString("error_connection_none"))
        End If
    End Sub

    ''' <summary>
    ''' Export updates to a catalog.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub ExportCatalogToolStripMenuItemClick(sender As Object, e As EventArgs) Handles exportCatalogToolStripMenuItem.Click
        If ConnectionManager.Connected Then

            ExportCatalogForm.Location = New Point(Me.Location.X + 100, Me.Location.Y + 100)
            My.Forms.ExportCatalogForm.ShowDialog()

        Else
            MsgBox(Globals.globalRM.GetString("error_connection_none"))
        End If

    End Sub

    ''' <summary>
    ''' Exit the program.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ExitToolStripMenuItemClick(sender As Object, e As EventArgs) Handles exitToolStripMenuItem.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Export the list from the main datagridview.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub ExportListToolStripMenuItemClick(sender As Object, e As EventArgs) Handles exportListToolStripMenuItem.Click
        'Make sure a computer tree node it selected
        If Not treeView.SelectedNode Is Nothing AndAlso _
            Not treeView.SelectedNode.Tag Is Nothing AndAlso _
            TypeOf treeView.SelectedNode.Tag Is IComputerTargetGroup Then

            'Get file to save data to.
            If Not exportFileDialog.ShowDialog = DialogResult.Cancel Then
                DataRoutines.ExportData(DirectCast(m_dgvMain.DataSource, DataTable), exportFileDialog.FileName)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Create an update.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub createUpdateToolStripMenuItemClick(sender As Object, e As EventArgs) Handles createUpdateToolStripMenuItem.Click
        Dim tmpSDP As SoftwareDistributionPackage
        Dim tmpRevisionId As UpdateRevisionId

        'Show the Import Update dialog and dispose of it.
        My.Forms.UpdateForm.Location = New Point(Me.Location.X + 100, Me.Location.Y + 100)

        'If the user didn't cancel then reload the tree.
        tmpSDP = My.Forms.UpdateForm.ShowDialog
        If Not tmpSDP Is Nothing Then
            Call LoadUpdateNodes()
            'Call RefreshUpdateList()

            Call SelectNode(Me.m_updateNode, Path.Combine(tmpSDP.VendorName, tmpSDP.ProductNames(0)))

            tmpRevisionId = New UpdateRevisionId(tmpSDP.PackageId)
            For Each tmpRow As DataGridViewRow In Me.m_dgvMain.Rows
                If DirectCast(tmpRow.Cells("Id").Value, UpdateRevisionId).UpdateId.Equals(tmpRevisionId.UpdateId) Then
                    Me.m_dgvMain.CurrentCell = tmpRow.Cells("Title")
                End If
            Next
        End If

        My.Forms.UpdateForm.Dispose()
    End Sub

    ''' <summary>
    ''' Export the current update to a CAB file.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub ExportUpdateToolStripMenuItemClick(sender As Object, e As EventArgs) Handles exportUpdateToolStripMenuItem.Click

        If Not Me.m_dgvMain.CurrentRow Is Nothing Then
            Dim update As IUpdate = DirectCast(Me.m_dgvMain.CurrentRow.Cells("IUpdate").Value, IUpdate)

            exportFileDialog.Reset()
            exportFileDialog.Filter = Globals.globalRM.GetString("file_filter_cab")

            If Not update Is Nothing AndAlso _
                Not exportFileDialog.ShowDialog = DialogResult.Cancel Then

                'Create Temporary Folder.
                Dim tmpFolder As New DirectoryInfo(Path.Combine(Path.GetTempPath, Path.GetRandomFileName))
                tmpFolder.Create()

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
                        MsgBox(Globals.globalRM.GetString("error_export_update_data"))
                    End If

                    'Delete the temporary folder.
                    tmpFolder.Delete(True)

                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' Import an update from a CAB file.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub ImportUpdateToolStripMenuItemClick(sender As Object, e As EventArgs) Handles importUpdateToolStripMenuItem.Click
        importFileDialog.Reset()
        importFileDialog.Filter = Globals.globalRM.GetString("file_filter_cab")

        'If we're connected and a file was chosen.
        If ConnectionManager.Connected AndAlso _
            Not importFileDialog.ShowDialog = DialogResult.Cancel Then

            'Add the handler for when the publisher finishes.
            AddHandler AsyncPublisher.Completed, AddressOf Me.PublishingResults

            'Publish the CAB asyconously.
            Call AsyncPublisher.PublishPackageFromCAB(New FileInfo(importFileDialog.FileName), Me)

        End If
    End Sub

    ''' <summary>
    ''' When the asyncronous publishing call completes this will run.
    ''' </summary>
    ''' <param name="result"></param>
    Sub PublishingResults(result As Boolean)
        Dim treePath As String = String.Empty


        If result Then
            If Not treeView.SelectedNode Is Nothing Then treePath = treeView.SelectedNode.FullPath
            MsgBox(Globals.globalRM.GetString("success_update_imported"))
            Call LoadUpdateNodes()
            Call RefreshUpdateList()

            'If Not treePath = String.Empty Then Call SelectNode(Me.m_rootNode, treePath)
        Else
            MsgBox(Globals.globalRM.GetString("error_update_imported"))
        End If

        RemoveHandler AsyncPublisher.Completed, AddressOf Me.PublishingResults
    End Sub

    ''' <summary>
    ''' Show the connection settings.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ConnectionSettingsToolStripMenuItemClick(sender As Object, e As EventArgs) Handles connectionSettingsToolStripMenuItem.Click

        'Show connection settings dialog.
        My.Forms.ConnectionSettingsForm.Location = New Point(Me.Location.X + 100, Me.Location.Y + 100)
        Dim DialogReturn As DialogResult = My.Forms.ConnectionSettingsForm.ShowDialog

        'If the user saved their changes then reconnect.
        If DialogReturn = DialogResult.OK Then
            Call LoadMainForm()
        End If
    End Sub

    ''' <summary>
    ''' Show the manage saved rules form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub ManageRulesToolStripMenuItemClick(sender As Object, e As EventArgs) Handles manageRulesToolStripMenuItem.Click
        My.Forms.SavedRulesForm.Location = New Point(Me.Location.X + 100, Me.Location.Y + 100)
        My.Forms.SavedRulesForm.ShowDialog(SavedRulesFormUses.Manage)
    End Sub
    ''' <summary>
    ''' Import rules from a file.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Sub ImportRulesToolStripMenuItemClick(sender As Object, e As EventArgs) Handles importRulesToolStripMenuItem.Click
        My.Forms.SavedRulesForm.Location = New Point(Me.Location.X + 100, Me.Location.Y + 100)
        My.Forms.SavedRulesForm.ShowDialog(SavedRulesFormUses.Import)
    End Sub
    ''' <summary>
    ''' Export rules to a file.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Sub ExportRulesToolStripMenuItemClick(sender As Object, e As EventArgs) Handles exportRulesToolStripMenuItem.Click
        My.Forms.SavedRulesForm.Location = New Point(Me.Location.X + 100, Me.Location.Y + 100)
        My.Forms.SavedRulesForm.ShowDialog(SavedRulesFormUses.Export)
    End Sub

    ''' <summary>
    ''' Prompt the user for a filename and export the data.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub ExportReportToolStripMenuItemClick(sender As Object, e As EventArgs) Handles exportReportToolStripMenuItem.Click

        'Make sure we can export the report and that the user has provided a filename.
        If Not cboUpdateStatus.SelectedIndex = -1 AndAlso _
            Not treeView.SelectedNode Is Nothing AndAlso _
            Not treeView.SelectedNode.Tag Is Nothing AndAlso _
            Not exportFileDialog.ShowDialog = DialogResult.Cancel Then

            'Export the data based on the selected node's tag type.
            If TypeOf Me.treeView.SelectedNode.Tag Is IComputerTargetGroup Then
                DataRoutines.ExportData(DirectCast(dgvComputerReport.DataSource, DataTable), exportFileDialog.FileName)
            ElseIf TypeOf Me.treeView.SelectedNode.Tag Is IUpdateCategory Then
                DataRoutines.ExportData(DirectCast(dgvUpdateReport.DataSource, DataTable), exportFileDialog.FileName)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Show the application settings.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub OptionsToolStripMenuItemClick(sender As Object, e As EventArgs) Handles settingsToolStripMenuItem.Click
        My.Forms.SettingsForm.Location = New Point(Me.Location.X + 100, Me.Location.Y + 100)
        My.Forms.SettingsForm.ShowDialog()
    End Sub

    ''' <summary>
    ''' Show the about form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AboutToolStripMenuItemClick(sender As Object, e As EventArgs) Handles aboutToolStripMenuItem.Click
        My.Forms.AboutForm.Location = New Point(Me.Location.X + 100, Me.Location.Y + 100)
        My.Forms.AboutForm.Show()
    End Sub

    ''' <summary>
    ''' Show the certificate info form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CertificateInfoToolStripMenuItemClick(sender As Object, e As EventArgs) Handles certificateInfoToolStripMenuItem.Click
        'Show certificate info
        My.Forms.CertificateInfoForm.Location = New Point(Me.Location.X + 100, Me.Location.Y + 100)
        My.Forms.CertificateInfoForm.ShowDialog()
    End Sub

    ''' <summary>
    ''' Go to the help Wiki.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub LupHelpToolStripMenuItemClick(sender As Object, e As EventArgs) Handles lupHelpToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://sourceforge.net/apps/mediawiki/localupdatepubl")
    End Sub

    ''' <summary>
    ''' Go to the help forum.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub HelpForumsToolStripMenuItemClick(sender As Object, e As EventArgs) Handles helpForumsToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://sourceforge.net/projects/localupdatepubl/forums/forum/1076879")
    End Sub

#End Region

#Region "Context Menu Events"
    ''' <summary>
    ''' Show the accept update dialog.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ApproveUpdate_Click(sender As Object, e As EventArgs)

        'Make sure a current row is selected.
        If Me.m_dgvMain.SelectedRows.Count < 1 Then
            MsgBox(Globals.globalRM.GetString("warning_no_row_selected"))
        Else
            'Display the approval dialog.
            My.Forms.ApprovalForm.Location = New Point(Me.Location.X + 100, Me.Location.Y + 100)

            'Get result.
            If My.Forms.ApprovalForm.ShowDialog(Me.m_dgvMain.SelectedRows) = DialogResult.OK Then
                'Refresh the DGV.
                Call RefreshUpdateList(True)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Open the update form and pass it the currently selected update's SDP file.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ReviseUpdate_Click(sender As Object, e As EventArgs)
        Dim tmpSDP As SoftwareDistributionPackage
        Dim tmpRevisionID As UpdateRevisionId

        'Make sure a current row is selected.
        If Me.m_dgvMain.CurrentRow Is Nothing Then
            MsgBox(Globals.globalRM.GetString("warning_no_row_selected"))
        ElseIf Me.m_dgvMain.SelectedRows.Count > 1 Then
            MsgBox(Globals.globalRM.GetString("warning_revise_packages"))
        Else
            'Make Sure the current row has an UpdateID.
            If TypeOf Me.m_dgvMain.CurrentRow.Cells.Item("Id").Value Is UpdateRevisionId Then
                tmpRevisionID = DirectCast(Me.m_dgvMain.CurrentRow.Cells.Item("Id").Value, UpdateRevisionId)

                'Export the SDP to a temporary file.
                Dim packageFile As String = ConnectionManager.ExportSDP(tmpRevisionID)

                'If the package file exists.
                If Not packageFile Is Nothing Then
                    'Bring Up the approval dialog and dispose it when finished.
                    My.Forms.UpdateForm.Location = New Point(Me.Location.X + 100, Me.Location.Y + 100)
                    tmpSDP = My.Forms.UpdateForm.ShowDialog(packageFile)
                    My.Forms.UpdateForm.Dispose()

                    'If the user completed the revision then refresh the list.
                    If Not tmpSDP Is Nothing Then
                        'Refresh the DGV.
                        Call RefreshUpdateList(True)
                    End If
                End If
            Else
                MsgBox(Globals.globalRM.GetString("error_row_invalid_update_id"))
            End If
        End If
    End Sub

    ''' <summary>
    ''' Decline the update.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DeclineUpdate_Click(sender As Object, e As EventArgs)
        Dim response As MsgBoxResult


        'Prompt user for confirmation.
        If Me.m_dgvMain.SelectedRows.Count > 1 Then
            response = MsgBox(String.Format(Globals.globalRM.GetString("prompt_decline_packages"), Me.m_dgvMain.SelectedRows.Count), vbYesNo)
        ElseIf Not Me.m_dgvMain.CurrentRow Is Nothing Then
            response = MsgBox(String.Format(Globals.globalRM.GetString("prompt_decline_package"), DirectCast(Me.m_dgvMain.CurrentRow.Cells("Title").Value, String)), _
                vbYesNo)
        End If

        'If user really wants to remove the updates then do so
        If response = MsgBoxResult.Yes Then
            Me.Cursor = Cursors.WaitCursor
            'Loop through and delete rows that have an Id listed.
            For Each tmpRow As DataGridViewRow In Me.m_dgvMain.SelectedRows
                If Not tmpRow.Cells("IUpdate").Value Is Nothing Then
                    'Decline update.
                    DirectCast(tmpRow.Cells("IUpdate").Value, IUpdate).Decline()
                End If
            Next

            'Refresh the DGV.
            Call RefreshUpdateList(True)

            Me.Cursor = Cursors.Arrow
        End If

    End Sub

    ''' <summary>
    ''' Remove the update.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub RemoveUpdate_Click(sender As Object, e As EventArgs)
        Dim response As MsgBoxResult
        Dim tmpUpdate As IUpdate = Nothing

        'Prompt user for confirmation.
        If Me.m_dgvMain.SelectedRows.Count > 1 Then
            response = MsgBox(String.Format(Globals.globalRM.GetString("prompt_remove_packages"), Me.m_dgvMain.SelectedRows.Count), vbYesNo)
        ElseIf Not Me.m_dgvMain.CurrentRow Is Nothing Then
            response = MsgBox(String.Format(Globals.globalRM.GetString("prompt_remove_package"), DirectCast(Me.m_dgvMain.CurrentRow.Cells("Title").Value, String)), _
                vbYesNo)
        End If

        'If user really wants to remove the updates then do so
        If response = MsgBoxResult.Yes Then
            Me.Cursor = Cursors.WaitCursor

            'Loop through and delete rows that have an Id listed.
            For Each tmpRow As DataGridViewRow In Me.m_dgvMain.SelectedRows

                If Not tmpRow.Cells("IUpdate").Value Is Nothing Then
                    'Get update.
                    tmpUpdate = DirectCast(tmpRow.Cells("IUpdate").Value, IUpdate)

                    'Set status.
                    Me.toolStripStatusLabel.Text = String.Format(Globals.globalRM.GetString("removing"), tmpUpdate.Title)

                    'Remove the approvals
                    For Each approval As IUpdateApproval In tmpUpdate.GetUpdateApprovals
                        approval.Delete()
                    Next

                    Try
                        'Remove the package.
                        ConnectionManager.ParentServer.DeleteUpdate(tmpUpdate.Id.UpdateId)
                    Catch x As WsusObjectNotFoundException
                        MsgBox(Globals.globalRM.GetString("exception_wsus_object_not_found") & ": " & x.Message)
                    Catch x As InvalidOperationException
                        MsgBox(Globals.globalRM.GetString("exception_invalid_operation") & ": " & x.Message)
                    Catch x As Exception
                        MsgBox(Globals.globalRM.GetString("exception") & ": " & x.Message)
                    End Try

                    'Delete the package's folder from the ~\WSUS\UpdateServicesPackages folder.
                    'If there is an error then prompt the user to delete the content manually.
                    'Currently we check to see if the folder exists because earlier version of LUP
                    ' published the packages to a single location in error.  At some point
                    ' this code should be removed and an error thrown if the content isn't found.
                    Dim tmpDirectory As String = "\\" & ConnectionManager.ParentServer.Name & "\UpdateServicesPackages\" & tmpUpdate.Id.UpdateId.ToString
                    Try
                        If Directory.Exists(tmpDirectory) Then
                            Directory.Delete(tmpDirectory, True)
                        End If
                    Catch
                        MsgBox(Globals.globalRM.GetString("warning_remove_package_data") & ": " & vbNewLine & tmpUpdate.Id.UpdateId.ToString)
                    End Try

                    'Clear the status
                    Me.toolStripStatusLabel.Text = Nothing
                End If
            Next

            'Reload the update nodes in case they have changed.  Attempt to re-select the currently selected node.
            If Not tmpUpdate Is Nothing Then
                Call LoadUpdateNodes(Path.Combine(tmpUpdate.CompanyTitles(0), tmpUpdate.ProductTitles(0)))
            Else
                Call LoadUpdateNodes()
            End If

            Me.Cursor = Cursors.Arrow
        End If


    End Sub

    ''' <summary>
    ''' Expire the update.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ExpireUpdate_Click(sender As Object, e As EventArgs)
        Dim response As MsgBoxResult
        Dim tmpRevisionID As UpdateRevisionId
        Dim allExpired As Boolean = True

        'Prompt user for confirmation.
        If Me.m_dgvMain.SelectedRows.Count > 1 Then
            response = MsgBox(String.Format(Globals.globalRM.GetString("prompt_expire_packages"), Me.m_dgvMain.SelectedRows.Count), vbYesNo)
        ElseIf Not Me.m_dgvMain.CurrentRow Is Nothing Then
            response = MsgBox(String.Format(Globals.globalRM.GetString("prompt_expire_package"), DirectCast(Me.m_dgvMain.CurrentRow.Cells("Title").Value, String)), _
                vbYesNo)
        End If

        'If user really wants to remove the updates then do so
        If response = MsgBoxResult.Yes Then
            Me.Cursor = Cursors.WaitCursor
            'Loop through selected rows.
            For Each tmpRow As DataGridViewRow In Me.m_dgvMain.SelectedRows

                'Make Sure the current row has an UpdateID.
                If TypeOf tmpRow.Cells.Item("Id").Value Is UpdateRevisionId Then
                    tmpRevisionID = DirectCast(tmpRow.Cells.Item("Id").Value, UpdateRevisionId)

                    If Not tmpRow.Cells.Item("Id").Value Is Nothing Then
                        ConnectionManager.ParentServer.ExpirePackage(DirectCast(tmpRow.Cells.Item("Id").Value, UpdateRevisionId))
                    End If
                Else
                    MsgBox(Globals.globalRM.GetString("error_row_invalid_update_id"))
                End If
            Next

            'Refresh the datagrid view
            Call RefreshUpdateList()

            Me.Cursor = Cursors.Arrow

            If allExpired Then
                MsgBox(Globals.globalRM.GetString("success_packages_expired"))
            Else
                MsgBox(Globals.globalRM.GetString("error_packages_expired"))
            End If
        End If

    End Sub

    ''' <summary>
    ''' Re-sign the update.  This is only needed if the certificate has changed
    ''' since the update was initially created.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ResignUpdate_Click(sender As Object, e As EventArgs)

        'Make sure a current row is selected.
        If Me.m_dgvMain.SelectedRows.Count < 1 Then
            MsgBox(Globals.globalRM.GetString("warning_no_row_selected"))
        ElseIf Me.bgwResign.IsBusy Then
            MsgBox(Globals.globalRM.GetString("resigning_in_progress"))
        Else
            Dim response As MsgBoxResult

            'Prompt user for confirmation.
            If Me.m_dgvMain.SelectedRows.Count > 1 Then
                response = MsgBox(String.Format(Globals.globalRM.GetString("prompt_resign_packages"), Me.m_dgvMain.SelectedRows.Count), vbYesNo)
            ElseIf Not Me.m_dgvMain.CurrentRow Is Nothing Then
                response = MsgBox(String.Format(Globals.globalRM.GetString("prompt_resign_package"), DirectCast(Me.m_dgvMain.CurrentRow.Cells("Title").Value, String)), _
                    vbYesNo)
            End If

            'If user really wants to remove the updates then do so asynchronously.
            If response = MsgBoxResult.Yes Then

                Me.bgwResign.RunWorkerAsync(Me.m_dgvMain.SelectedRows)

            End If
        End If
    End Sub
    ''' <summary>
    ''' The background worker that does the work of re-sign the update.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub BgwResignDoWork(sender As Object, e As DoWorkEventArgs) Handles bgwResign.DoWork
        Dim packageFile As String
        Dim packageCount As Integer = 0
        Dim tmpRevisionID As UpdateRevisionId
        Dim allResigned As Boolean = True
        Dim selectedRows As DataGridViewSelectedRowCollection


        'Make sure we were passed a collection of selected DGV rows.
        If TypeOf e.Argument Is DataGridViewSelectedRowCollection Then
            selectedRows = DirectCast(e.Argument, DataGridViewSelectedRowCollection)
        Else
            Exit Sub
        End If

        For Each tmpRow As DataGridViewRow In selectedRows
            packageCount += 1

            'Make Sure the current row has an UpdateID.
            If TypeOf tmpRow.Cells.Item("Id").Value Is UpdateRevisionId Then
                tmpRevisionID = DirectCast(tmpRow.Cells.Item("Id").Value, UpdateRevisionId)

                'Check to see if this is a metadata-only update.  There is no good way to do this so the current method is to
                ' see if any binary data exists in \\%WSUSSERVER%\UpdateServicesPackages.
                If Not Directory.Exists("\\" & ConnectionManager.ParentServer.Name & "\UpdateServicesPackages\" & tmpRevisionID.UpdateId.ToString) Then
                    MsgBox(String.Format(Globals.globalRM.GetString("warning_resign_metadata"), DirectCast(tmpRow.Cells.Item("Title").Value, String)))
                    allResigned = False
                Else
                    Try

                        Me.bgwResign.ReportProgress(Convert.ToInt32(packageCount / selectedRows.Count * 100), tmpRow.Cells.Item("Title").Value)

                        'Export the SDP to a temporary file.
                        packageFile = ConnectionManager.ExportSDP(DirectCast(tmpRow.Cells.Item("Id").Value, UpdateRevisionId))
                        'ConnectionManager.ParentServer.ExportPackageMetadata(DirectCast(tmpRow.Cells.Item("Id").Value, UpdateRevisionId ), packageFile)

                        'Create a publisher object with the SDP and resign the package.
                        Dim publisher As IPublisher = ConnectionManager.ParentServer.GetPublisher(packageFile)
                        publisher.ResignPackage()
                        My.Computer.FileSystem.DeleteFile(packageFile)

                    Catch x As UnauthorizedAccessException
                        MsgBox(Globals.globalRM.GetString("error_package_resigned") & vbNewLine & Globals.globalRM.GetString("exception_unauthorized_access") & ": " & vbNewLine & x.Message & vbNewLine & x.StackTrace)
                    Catch x As ArgumentNullException
                        MsgBox(Globals.globalRM.GetString("error_package_resigned") & vbNewLine & Globals.globalRM.GetString("exception_argument_null") & ": " & vbNewLine & x.Message & vbNewLine & x.StackTrace)
                    Catch x As FileNotFoundException
                        MsgBox(Globals.globalRM.GetString("error_package_resigned") & vbNewLine & Globals.globalRM.GetString("exception_file_not_found") & ": " & vbNewLine & x.Message & vbNewLine & x.StackTrace)
                    Catch x As InvalidDataException
                        MsgBox(Globals.globalRM.GetString("error_package_resigned") & vbNewLine & Globals.globalRM.GetString("exception_invalid_data") & ": " & vbNewLine & x.Message & vbNewLine & x.StackTrace)
                    Catch x As InvalidOperationException
                        MsgBox(Globals.globalRM.GetString("error_package_resigned") & vbNewLine & Globals.globalRM.GetString("exception_invalid_operation") & ": " & vbNewLine & x.Message & vbNewLine & x.StackTrace)
                    Catch x As Exception
                        MsgBox(Globals.globalRM.GetString("error_package_resigned") & vbNewLine & Globals.globalRM.GetString("exception") & ": " & vbNewLine & x.Message & vbNewLine & x.StackTrace)
                    End Try
                End If
            Else
                MsgBox(Globals.globalRM.GetString("error_row_invalid_update_id"))
            End If
        Next

        e.Result = allResigned
    End Sub
    ''' <summary>
    ''' Update the status tool strip on the progress of the resigning background worker.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub BgwResignProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwResign.ProgressChanged
        If TypeOf e.UserState Is String Then
            Me.toolStripStatusLabel.Text = String.Format(Globals.globalRM.GetString("resigning"), DirectCast(e.UserState, String)) & " " & e.ProgressPercentage & "%"
        Else
            Me.toolStripStatusLabel.Text = String.Empty
        End If
    End Sub
    ''' <summary>
    ''' Let the user know that the result of re-signing the packages.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub BgwResignRunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwResign.RunWorkerCompleted

        If TypeOf e.Result Is Boolean AndAlso DirectCast(e.Result, Boolean) Then
            MsgBox(Globals.globalRM.GetString("success_packages_resigned"))
        Else
            MsgBox(Globals.globalRM.GetString("error_packages_resigned"))
        End If

        Call CheckBGWThreads()
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
    ''' <summary>
    ''' Set the context menus based on the currently selected node.
    ''' </summary>
    ''' <param name="rowIndex"></param>
    Sub SetContextMenu(rowIndex As Integer)
        'Clear the context menu.
        Me.cmDgvMain.Items.Clear()

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
            Me.updateToolStripMenuItem.DropDownItems.Clear()

            'Add the items to both the context menu and the update menustrip if
            ' this server is not a replica server.

            'Set the list based on the update source.
            If Not Me.m_dgvMain.Rows(rowIndex) Is Nothing _
                AndAlso Not Me.m_dgvMain.Rows(rowIndex).Cells.Item("IUpdate").Value Is Nothing _
                AndAlso TypeOf Me.m_dgvMain.Rows(rowIndex).Cells.Item("IUpdate").Value Is IUpdate Then

                If DirectCast(Me.m_dgvMain.Rows(rowIndex).Cells.Item("IUpdate").Value, IUpdate).UpdateSource = UpdateSource.Other Then
                    Me.cmDgvMain.Items.Add(Globals.globalRM.GetString("approve"), Nothing, New EventHandler(AddressOf ApproveUpdate_Click))
                    Me.updateToolStripMenuItem.DropDownItems.Add(Globals.globalRM.GetString("approve"), Nothing, New EventHandler(AddressOf ApproveUpdate_Click))
                    Me.cmDgvMain.Items.Add(Globals.globalRM.GetString("revise"), Nothing, New EventHandler(AddressOf ReviseUpdate_Click))
                    Me.updateToolStripMenuItem.DropDownItems.Add(Globals.globalRM.GetString("revise"), Nothing, New EventHandler(AddressOf ReviseUpdate_Click))
                    Me.cmDgvMain.Items.Add(Globals.globalRM.GetString("resign"), Nothing, New EventHandler(AddressOf ResignUpdate_Click))
                    Me.updateToolStripMenuItem.DropDownItems.Add(Globals.globalRM.GetString("resign"), Nothing, New EventHandler(AddressOf ResignUpdate_Click))
                    Me.cmDgvMain.Items.Add(Globals.globalRM.GetString("expire"), Nothing, New EventHandler(AddressOf ExpireUpdate_Click))
                    Me.updateToolStripMenuItem.DropDownItems.Add(Globals.globalRM.GetString("expire"), Nothing, New EventHandler(AddressOf ExpireUpdate_Click))
                    Me.cmDgvMain.Items.Add(Globals.globalRM.GetString("decline"), Nothing, New EventHandler(AddressOf DeclineUpdate_Click))
                    Me.updateToolStripMenuItem.DropDownItems.Add(Globals.globalRM.GetString("decline"), Nothing, New EventHandler(AddressOf DeclineUpdate_Click))
                    Me.cmDgvMain.Items.Add(Globals.globalRM.GetString("remove"), Nothing, New EventHandler(AddressOf RemoveUpdate_Click))
                    Me.updateToolStripMenuItem.DropDownItems.Add(Globals.globalRM.GetString("remove"), Nothing, New EventHandler(AddressOf RemoveUpdate_Click))
                    '			Future Functionality:
                    '			Me.cmDgvMain.Items.Add(New ToolStripSeparator)
                    '			Me.updateToolStripMenuItem.DropDownItems.Add(New ToolStripSeparator)
                    '			Me.cmDgvMain.Items.Add("Revisions", Nothing , New EventHandler(AddressOf RevisionHistoryUpdate_Click))
                    '			Me.updateToolStripMenuItem.DropDownItems.Add("Revisions", Nothing , New EventHandler(AddressOf RevisionHistoryUpdate_Click))
                    '			Me.cmDgvMain.Items.Add("File Info", Nothing , New EventHandler(AddressOf FileInfoUpdate_Click))
                    '			Me.updateToolStripMenuItem.DropDownItems.Add("File Info", Nothing , New EventHandler(AddressOf FileInfoUpdate_Click))
                    '			Me.cmDgvMain.Items.Add("Status Report", Nothing , New EventHandler(AddressOf StatusReportUpdate_Click))
                    '			Me.updateToolStripMenuItem.DropDownItems.Add("Status Report", Nothing , New EventHandler(AddressOf StatusReportUpdate_Click))
                Else
                    Me.cmDgvMain.Items.Add(Globals.globalRM.GetString("approve"), Nothing, New EventHandler(AddressOf ApproveUpdate_Click))
                    Me.updateToolStripMenuItem.DropDownItems.Add(Globals.globalRM.GetString("approve"), Nothing, New EventHandler(AddressOf ApproveUpdate_Click))
                    Me.cmDgvMain.Items.Add(Globals.globalRM.GetString("expire"), Nothing, New EventHandler(AddressOf ExpireUpdate_Click))
                    Me.updateToolStripMenuItem.DropDownItems.Add(Globals.globalRM.GetString("expire"), Nothing, New EventHandler(AddressOf ExpireUpdate_Click))
                    Me.cmDgvMain.Items.Add(Globals.globalRM.GetString("decline"), Nothing, New EventHandler(AddressOf DeclineUpdate_Click))
                    Me.updateToolStripMenuItem.DropDownItems.Add(Globals.globalRM.GetString("decline"), Nothing, New EventHandler(AddressOf DeclineUpdate_Click))

                End If
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

    ''' <summary>
    ''' Create an update based on the currently selected vendor and/or product.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub createCategoryUpdateToolStripMenuItemClick(sender As Object, e As EventArgs) Handles createCategoryUpdateToolStripMenuItem.Click

        'Make sure the selected node has a tag and that the tag is an update category.
        If Not treeView.SelectedNode.Tag Is Nothing AndAlso TypeOf (treeView.SelectedNode.Tag) Is IUpdateCategory Then

            Dim updateCategory As IUpdateCategory = DirectCast(treeView.SelectedNode.Tag, IUpdateCategory)
            Dim tmpSDP As SoftwareDistributionPackage = New SoftwareDistributionPackage
            Dim tmpRevisionId As UpdateRevisionId

            'Show the Import Update dialog and dispose of it.
            My.Forms.UpdateForm.Location = New Point(Me.Location.X + 100, Me.Location.Y + 100)

            'If this is a product then include the product and vendor.
            If updateCategory.Type = UpdateCategoryType.Product Then
                If updateCategory.GetParentUpdateCategory.Type = UpdateCategoryType.Company Then
                    tmpSDP = My.Forms.UpdateForm.ShowDialog(updateCategory.GetParentUpdateCategory, updateCategory)
                Else
                    tmpSDP = My.Forms.UpdateForm.ShowDialog(updateCategory.GetParentUpdateCategory.GetParentUpdateCategory, updateCategory)
                End If
            ElseIf updateCategory.Type = UpdateCategoryType.Company Then
                tmpSDP = My.Forms.UpdateForm.ShowDialog(updateCategory)
            End If


            'If the user didn't cancel then reload the tree.
            If Not tmpSDP Is Nothing Then
                Call LoadUpdateNodes()
                'Call RefreshUpdateList()

                Call SelectNode(Me.m_updateNode, Path.Combine(tmpSDP.VendorName, tmpSDP.ProductNames(0)))

                tmpRevisionId = New UpdateRevisionId(tmpSDP.PackageId)
                For Each tmpRow As DataGridViewRow In Me.m_dgvMain.Rows
                    If DirectCast(tmpRow.Cells("Id").Value, UpdateRevisionId).UpdateId.Equals(tmpRevisionId.UpdateId) Then
                        Me.m_dgvMain.CurrentCell = tmpRow.Cells("Title")
                    End If
                Next
            End If

            My.Forms.UpdateForm.Dispose()

        End If
    End Sub
#End Region

#Region "TreeView Events"

    ''' <summary>
    ''' Before we move to the next node, save the current DGV states.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub TreeViewBeforeSelect(sender As Object, e As TreeViewCancelEventArgs) Handles treeView.BeforeSelect
        'If there are rows loaded and the previous node has a tag.
        If m_dgvMain.Rows.Count > 0 AndAlso _
            Not treeView.SelectedNode Is Nothing AndAlso _
            Not treeView.SelectedNode.Tag Is Nothing Then
            Call SaveDgvState(treeView.SelectedNode)
        End If
    End Sub

    ''' <summary>
    ''' This method responds to a node being selected.  
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' We base our action off of the node type. 
    ''' First, if the tag isn't instantiated then do nothing.  If the tag is instantiated 
    ''' then find its type and act accordingly.
    ''' </remarks>
    Private Sub TreeViewAfterSelect(sender As Object, e As TreeViewEventArgs) Handles treeView.AfterSelect
        Cursor = Cursors.WaitCursor

        'Make sure the correct server is selected.
        VerifyCurrentServer(e.Node)

        'If the tag object is instantiated.
        If Not e.Node.Tag Is Nothing Then

            If TypeOf e.Node.Tag Is UpdateServer Then 'Server Node
                Call ClearForm(False)
                'treeview.BeginUpdate
                Call TreeViewSelectServerNode(e.Node)
                'treeview.EndUpdate
            ElseIf TypeOf e.Node.Tag Is IComputerTargetGroup Then 'Computer Note
                Call TreeViewSelectComputerNode(sender, e)
            ElseIf TypeOf e.Node.Tag Is IUpdateCategory Then 'Update Node

                'Only load update nodes that cannot directly contain updates.
                If DirectCast(e.Node.Tag, IUpdateCategory).ProhibitsUpdates = False Then
                    Call TreeViewSelectUpdateNode(sender, e)
                End If
            End If 'Type of node's tag.

        Else 'If the node's tag isn't instantiated then clear the datagrid.
            m_noEvents = True
            scHeader.Panel1Collapsed = True 'Hide the header panel.
            pnlUpdates.Visible = False
            pnlComputers.Visible = False
            Me.Update()
            m_dgvMainLoading = True
            m_dgvMain.DataSource = Nothing
            m_dgvMainLoading = False
            m_noEvents = False
        End If 'Node tag instantiated.

        Cursor = Cursors.Arrow
    End Sub
    ''' <summary>
    ''' If a server node has been selected then update the relevant controls.
    ''' </summary>
    ''' <param name="node"></param>
    Private Sub TreeViewSelectServerNode(node As TreeNode)

        'If this node is already the current server then exit.
        If Not m_serverNode Is Nothing AndAlso m_serverNode.Equals(node) Then Exit Sub

        'If this is a parent node then clear
        ' everything but the current server node.
        If Not DirectCast(node.Tag, UpdateServer).ChildServer Then
            For Each tmpNode As TreeNode In node.Nodes
                If Not tmpNode.Equals(node) Then tmpNode.Nodes.Clear()
            Next
        End If

        'If this node already has child nodes then
        ' do not reload it and exit the routine.
        If node.Nodes.Count > 0 Then
            Exit Sub
        End If

        'If we are connected then populate the tree view.
        If Not ConnectionManager.CurrentServer Is Nothing Then

            'Set the server node
            m_serverNode = node

            'Add the downstream server nodes.
            For Each downstreamServer As IDownstreamServer In ConnectionManager.CurrentServer.GetDownstreamServers
                Dim tmpNode As TreeNode = m_serverNode.Nodes.Add(downstreamServer.FullDomainName, UCase(downstreamServer.FullDomainName))
                tmpNode.Tag = New UpdateServer(downstreamServer.FullDomainName, ConnectionManager.CurrentServer.PortNumber, ConnectionManager.CurrentServer.IsConnectionSecureForApiRemoting, True, downstreamServer.IsReplica)
                tmpNode.ImageIndex = 1
                tmpNode.SelectedImageIndex = 1
            Next

            'Add the computer and update nodes
            m_computerNode = m_serverNode.Nodes.Add("computers", Globals.globalRM.GetString("computers"))
            m_computerNode.ImageIndex = 0
            m_computerNode.SelectedImageIndex = 0

            m_updateNode = m_serverNode.Nodes.Add("updates", Globals.globalRM.GetString("updates"))
            m_updateNode.ImageIndex = 2
            m_updateNode.SelectedImageIndex = 2

            'Load the tree nodes.
            Call LoadComputerNodes()
            Call LoadUpdateNodes()

            'Open the server node.
            m_rootNode.Expand()
            m_serverNode.Expand()

        End If
    End Sub
    ''' <summary>
    ''' If a computer node was selected update the relevant controls.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TreeViewSelectComputerNode(sender As Object, e As TreeViewEventArgs)

        'Update the selected group label.
        lblSelectedTargetGroup.Text = DirectCast(treeView.SelectedNode.Tag, IComputerTargetGroup).Name

        'Setup the panels.
        scHeader.Panel1Collapsed = False
        pnlUpdates.Visible = False
        splitContainerHorz.SplitterDistance = Globals.appSettings.ComputerSplitter
        pnlComputers.Visible = True
        Update()

        'Setup the menus.
        exportListToolStripMenuItem.Visible = True

        'Reset the main update tab.
        tabMainUpdates.SelectedIndex = 0

        m_noEvents = True
        dgvComputerReport.DataSource = Nothing 'Clear report.
        m_noEvents = False

        'Move the target group combo to the computer report tab.
        If Not tlpComputerReport.Controls.Contains(cboUpdateStatus) Then
            cboUpdateStatus.Margin = New Padding(20, 3, 3, 3)
            tlpComputerReport.Controls.Add(cboUpdateStatus, 0, 1)
            cboUpdateStatus.SelectedIndex = -1
        End If

        Call RefreshComputerList()
        Call LoadComputerGroupStatus()

    End Sub
    ''' <summary>
    ''' If an update node was selected then update the relevant controls.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TreeViewSelectUpdateNode(sender As Object, e As TreeViewEventArgs)
        'Setup the panels.
        scHeader.Panel1Collapsed = True
        pnlComputers.Visible = False
        pnlUpdates.Visible = True
        Me.Update()


        'Reset the main computers tab.
        tabMainComputers.SelectedIndex = 0

        m_noEvents = True
        splitContainerHorz.SplitterDistance = Globals.appSettings.UpdateSplitter
        dgvUpdateReport.DataSource = Nothing 'Clear report.
        m_noEvents = False

        'Move the target group combo to the update report tab.
        If Not tlpUpdateReport.Controls.Contains(cboUpdateStatus) Then
            cboUpdateStatus.Margin = New Padding(3, 3, 3, 3)
            tlpUpdateReport.Controls.Add(cboUpdateStatus, 1, 1)
            cboUpdateStatus.SelectedIndex = -1
        End If

        Call RefreshUpdateList()

    End Sub

#End Region

#Region "TreeView Methods"
    ''' <summary>
    ''' Call LoadComputerNodes with the default settings.
    ''' </summary>
    ''' <remarks></remarks>
    Sub LoadComputerNodes()
        Call LoadComputerNodes(m_computerNode)
    End Sub

    ''' <summary>
    ''' Load up the computer nodes.
    ''' </summary>
    ''' <param name="node"></param>
    ''' <remarks>
    ''' This is a recursive subroutine.  When the form
    ''' loads it calls this with the based computer node.  If that node hasn't been
    ''' populated yet then we add the all computers node and recursively call
    ''' the routine to fill in the rest.
    ''' </remarks>
    Sub LoadComputerNodes(node As TreeNode)

        'If the all computer node has been passed.
        If node.Equals(m_computerNode) Then

            'Clear the computers node.
            node.Nodes.Clear()

            'Clear the computer group combobox.
            Me.cboTargetGroup.Items.Clear()

            'Wait until a connection to the server is made.
            ConnectionManager.WaitForConnection(Globals.appSettings.TimeOut)

            If ConnectionManager.Connected Then

                'Load the top level computer groups, starting at the All Computers group
                ' and working our way down recursively.
                Dim allComputersGroup As IComputerTargetGroup = ConnectionManager.CurrentServer.GetComputerTargetGroup(ComputerTargetGroupId.AllComputers)

                'Add all computers group to which we'll add the groups.
                Dim tmpNode As TreeNode = node.Nodes.Add(allComputersGroup.Id.ToString, allComputersGroup.Name)
                tmpNode.Tag = allComputersGroup

                'Call recursively.
                Call LoadComputerNodes(tmpNode)

                'Load combo boxes.
                LoadComputerCombo(tmpNode)
            End If
        ElseIf Not node.Tag Is Nothing Then

            'Wait until a connection to the server is made.
            ConnectionManager.WaitForConnection(Globals.appSettings.TimeOut)

            If ConnectionManager.Connected Then
                'Loop through the collection of groups, add them to the all computers node,
                ' and set their tag object to the target group.
                For Each targetGroup As IComputerTargetGroup In DirectCast(node.Tag, IComputerTargetGroup).GetChildTargetGroups
                    Dim tmpNode As TreeNode = node.Nodes.Add(targetGroup.Id.ToString, targetGroup.Name)
                    tmpNode.Tag = targetGroup

                    'Call recursively.
                    Call LoadComputerNodes(tmpNode)

                Next
            End If
        End If

        'See if a node is still being looked for.
        'Call SelectNode
    End Sub

    ''' <summary>
    ''' This routine adds the computer groups to the combo box for the reports.
    ''' </summary>
    ''' <param name="node">The node that is to be traversed.</param>
    ''' <remarks>Called after all the nodes have been loaded so that this is sorted.</remarks>
    Sub LoadComputerCombo(node As TreeNode)
        If Not node Is Nothing Then
            'Add the computer group to the combo.
            Me.cboTargetGroup.Items.Add(New ComboTargetGroups(DirectCast(node.Tag, IComputerTargetGroup), node.Level - ComputerNode.Level - 2))

            'Add its child groups.
            For Each childNode As TreeNode In node.Nodes
                LoadComputerCombo(childNode)
            Next
        End If
    End Sub

    ''' <summary>
    ''' Asynchronously load the Update Nodes.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub BgwUpdateNodesDoWork(sender As Object, e As DoWorkEventArgs) Handles bgwUpdateNodes.DoWork
        Dim startNode As TreeNode = New TreeNode
        Dim vendorNode As TreeNode
        Dim tmpVendor As Vendor = New Vendor
        Dim tmpProductNode As TreeNode
        Dim tmpProductFamilyNode As TreeNode

        startNode = DirectCast(Me.m_updateNode.Clone, TreeNode)

        'Clear the updates node and the import update and report comboboxes.
        If Not startNode Is Nothing Then

            'Clear the main update node and the list of vendors.
            startNode.Nodes.Clear()
            Me.m_vendorCollection.Clear()

            'Wait until a connection to the server is made.
            ConnectionManager.WaitForConnection(Globals.appSettings.TimeOut)

            If ConnectionManager.Connected Then 'Make sure we're connected still.

                'Load the vendor update categories
                For Each vendorCategory As IUpdateCategory In ConnectionManager.CurrentServer.GetRootUpdateCategories

                    'Add the vendor and add its category.
                    vendorNode = startNode.Nodes.Add(vendorCategory.Title)
                    vendorNode.Tag = vendorCategory
                    tmpVendor = New Vendor(vendorCategory.Title)

                    'Loop through each category under the vendor.
                    For Each category As IUpdateCategory In vendorCategory.GetSubcategories

                        'If this is a product category then add it.
                        If category.Type = UpdateCategoryType.Product Then

                            If category.UpdateSource = UpdateSource.Other OrElse Not Globals.appSettings.HideOfficialUpdates Then
                                tmpVendor.Products.Add(category.Title)
                                tmpProductNode = vendorNode.Nodes.Add(category.Title)
                                tmpProductNode.Tag = category

                                'If category.GetSubcategories.Count > 0 Then Msgbox ( category.Title & " " & category.GetSubcategories.Count)
                            End If

                            'If this is a product family category and loop through it.
                        ElseIf category.Type = UpdateCategoryType.ProductFamily Then
                            tmpProductFamilyNode = vendorNode.Nodes.Add(category.Title)

                            'Loop through each product in the product family.
                            For Each product As IUpdateCategory In category.GetSubcategories

                                If product.UpdateSource = UpdateSource.Other OrElse Not Globals.appSettings.HideOfficialUpdates Then
                                    tmpVendor.Products.Add(product.Title)
                                    tmpProductNode = tmpProductFamilyNode.Nodes.Add(product.Title)
                                    tmpProductNode.Tag = product

                                    'If product.GetSubcategories.Count > 0 Then Msgbox ( product.Title & " " & product.GetSubcategories.Count)
                                End If
                            Next

                            'Remove the product family node if it doesn't have any product nodes under it.
                            If tmpProductFamilyNode.Nodes.Count = 0 Then
                                vendorNode.Nodes.Remove(tmpProductFamilyNode)
                            End If

                        End If

                    Next 'Product or Product Family


                    'If the vendor node has it's own nodes at this point then add the vendor
                    'to the list.  Otherwise, remove the empty node.
                    If vendorNode.Nodes.Count > 0 Then
                        m_vendorCollection.Add(tmpVendor)
                    Else
                        startNode.Nodes.Remove(vendorNode)
                    End If

                Next 'Vendor

            End If
        End If

        'If the argument is a string then pass it along as the selected node path
        If Not e.Argument Is Nothing AndAlso TypeOf e.Argument Is String Then
            e.Result = New NodeDetails(startNode, DirectCast(e.Argument, String))
        Else
            e.Result = New NodeDetails(startNode, Nothing)
        End If
    End Sub

    ''' <summary>
    ''' When the asynchronous process is complete add the nodes to the update node.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub BgwUpdateNodesRunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwUpdateNodes.RunWorkerCompleted
        If TypeOf e.Result Is NodeDetails Then
            Dim tmpAsyncNodeDetails As NodeDetails = DirectCast(e.Result, NodeDetails)
            m_updateNode.Nodes.Clear()


            For Each tmpNode As TreeNode In tmpAsyncNodeDetails.Node.Nodes
                m_updateNode.Nodes.Add(tmpNode)
            Next

            'If a path was passed along then try to select it, otherwise just refresh the update list.
            If Not tmpAsyncNodeDetails.SelectedNodePath Is Nothing Then
                'If at some point the tmpUpdate object was instantiated then try to reload its vendor and product.
                Call SelectNode(Me.m_updateNode, tmpAsyncNodeDetails.SelectedNodePath)

                'If the vendor or product wasn't found, refresh the list to clear the DGV.
                If Me.treeView.SelectedNode.Equals(Me.m_updateNode) Then
                    Call RefreshUpdateList()
                End If
            Else
                Call RefreshUpdateList()
            End If

        End If

        Call CheckBGWThreads()

        'See if a node is still being looked for.
        Call SelectNode()
    End Sub

    ''' <summary>
    ''' Call LoadUpdateNodes with the defaults.
    ''' </summary>
    Sub LoadUpdateNodes()
        Call LoadUpdateNodes(Nothing)
    End Sub

    ''' <summary>
    ''' Load the main update node with vendors, product families, and products.
    ''' </summary>
    Sub LoadUpdateNodes(selectedNodePath As String)
        If Not Me.bgwUpdateNodes.IsBusy Then
            Me.bgwUpdateNodes.RunWorkerAsync(selectedNodePath)
        End If

        Call CheckBGWThreads()
    End Sub

    ''' <summary>
    ''' Verify that the correct server is current based on the node that was selected.
    ''' </summary>
    ''' <param name="node"></param>
    Sub VerifyCurrentServer(node As TreeNode)
        If node Is Nothing Then
            Exit Sub
        ElseIf Not node.Tag Is Nothing AndAlso _
            TypeOf node.Tag Is UpdateServer Then 'node is an update server.

            'If the current server is the one we want then exit.  Otherwise connect to it.
            If Not ConnectionManager.CurrentServer Is Nothing AndAlso _
                DirectCast(node.Tag, UpdateServer).Name = ConnectionManager.CurrentServer.Name Then
                Exit Sub
            Else
                ConnectionManager.Connect(DirectCast(node.Tag, UpdateServer))
                Call SetToolStrip()
            End If
        ElseIf Not node.Parent Is Nothing Then 'Recursively call with the node's parent.
            VerifyCurrentServer(node.Parent)
        Else
            Exit Sub
        End If
    End Sub

    ''' <summary>
    ''' Show a context menu when the user right clicks on a node.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub TreeViewMouseUp(sender As Object, e As MouseEventArgs) Handles treeView.MouseUp

        ' Show menu only if Right Mouse button is clicked
        If e.Button = MouseButtons.Right Then

            ' Point where mouse is clicked
            Dim p As Point = New Point(e.X, e.Y)

            ' Go to the node that the user clicked
            Dim node As TreeNode = treeView.GetNodeAt(p)
            If Not node Is Nothing AndAlso Not node.Tag Is Nothing AndAlso TypeOf node.Tag Is IUpdateCategory Then

                ' Highlight the node that the user clicked.
                treeView.SelectedNode = node

                'Show the context menu.
                cmCreateCategoryUpdate.Show(treeView, p)


            End If
        End If

    End Sub

    ''' <summary>
    ''' Used to enable or disable elements in the toolstrip.
    ''' </summary>
    Sub SetToolStrip()

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
    ''' <summary>
    ''' Save the datagridview state when leaving it.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub dgvMainLeave(sender As Object, e As EventArgs) Handles m_dgvMain.Leave
        'Save the dgvstate
        SaveDgvState(treeView.SelectedNode)
    End Sub

    ''' <summary>
    ''' If the user uses the up or down keys then load the new row.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub dgvMainKeyUp(sender As Object, e As KeyEventArgs) Handles m_dgvMain.KeyUp
        If Not m_dgvMainLoading AndAlso Not m_dgvMain.CurrentRow Is Nothing AndAlso m_dgvMain.CurrentRow.Index >= 0 AndAlso _
            (e.KeyCode = 40 OrElse _
            e.KeyCode = 38) Then
            m_dgvMain.Update()

            Call LoadRow(m_dgvMain.CurrentRow.Index)
        End If
    End Sub
    ''' <summary>
    ''' Load the row data when entered.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Sub dgvMainRowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles m_dgvMain.RowEnter
        If Not m_dgvMainLoading Then
            'Load the newly selected row.
            Call LoadRow(e.RowIndex)
        End If

    End Sub

    ''' <summary>
    ''' Handle header row and right clicks.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dgvMainCellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles m_dgvMain.CellMouseDown

        'If user right clicks on a non-header row
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso e.Button = MouseButtons.Right Then

            'Update current cell to load the new row
            m_dgvMain.CurrentCell = m_dgvMain.Rows(e.RowIndex).Cells(e.ColumnIndex)


            Dim r As Rectangle = m_dgvMain.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
            cmDgvMain.Show(DirectCast(sender, Control), r.Left + e.X, r.Top + e.Y)
            'If user left clicks on a header row and rows are selected.
        ElseIf m_dgvMain.SelectedRows.Count = 1 AndAlso e.Button = MouseButtons.Left Then
            'Save the currently selected row based on the currently selected tree node.
            If TypeOf Me.treeView.SelectedNode.Tag Is IComputerTargetGroup Then
                m_originalValue = DirectCast(m_dgvMain.CurrentRow.Cells.Item("ComputerName").Value, String)

            ElseIf TypeOf Me.treeView.SelectedNode.Tag Is IUpdateCategory Then
                m_originalValue = DirectCast(m_dgvMain.CurrentRow.Cells.Item("Title").Value, String)
            End If
        Else
            m_originalValue = Nothing
        End If

    End Sub

    ''' <summary>
    ''' Capture the current row's value before a sort.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub DgvComputerReportCellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvComputerReport.CellMouseDown
        'If a valid header was clicked and there is a row selected then save its info.
        If e.RowIndex = -1 And e.ColumnIndex > -1 And dgvComputerReport.SelectedRows.Count = 1 Then
            'Save the currently selected update.
            m_originalValue = DirectCast(dgvComputerReport.CurrentRow.Cells.Item("UpdateTitle").Value, String)
        ElseIf e.RowIndex <> -1 AndAlso Not Me.m_dgvMain.CurrentRow Is Nothing Then
            m_originalValue = Nothing

            'If the column is the status column then display the history.
            If dgvComputerReport.Columns(e.ColumnIndex).Name = "UpdateInstallationState" Then
                Dim tmpMessage As String = ""
                Me.Cursor = Cursors.WaitCursor
                For Each tmpEvent As IUpdateEvent In DirectCast(Me.dgvComputerReport.Rows(e.RowIndex).Cells("IUpdate").Value, IUpdate).GetUpdateEventHistory(Date.MinValue, Date.MaxValue)
                    If DirectCast(m_dgvMain.CurrentRow.Cells("TargetID").Value, String) = tmpEvent.ComputerId Then
                        tmpMessage += Globals.globalRM.GetString("date") & ": " & tmpEvent.CreationDate.ToLocalTime & vbTab & "  " & tmpEvent.Message & vbNewLine
                    End If
                Next
                Me.Cursor = Cursors.Arrow
                If Not String.IsNullOrEmpty(tmpMessage) Then
                    MsgBox(tmpMessage, MsgBoxStyle.OkOnly, Globals.globalRM.GetString("History for") & " " & DirectCast(dgvComputerReport.Rows(e.RowIndex).Cells("UpdateTitle").Value, String))
                End If
            End If
        Else
            m_originalValue = Nothing
        End If

    End Sub

    ''' <summary>
    ''' Capture the current row's value before a sort.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub DgvUpdateReportCellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvUpdateReport.CellMouseDown
        'If a valid header was clicked and there is a row selected then save its info.
        If e.RowIndex = -1 And e.ColumnIndex > -1 And dgvUpdateReport.SelectedRows.Count = 1 Then
            'Save the currently selected update.
            m_originalValue = DirectCast(dgvUpdateReport.CurrentRow.Cells.Item("ComputerName").Value, String)
        ElseIf e.RowIndex <> -1 Then
            m_originalValue = Nothing

            'If the column is the status column then display the error history.
            If dgvUpdateReport.Columns(e.ColumnIndex).Name = "UpdateInstallationState" AndAlso Not Me.m_dgvMain.CurrentRow Is Nothing Then
                Dim tmpMessage As String = ""
                Me.Cursor = Cursors.WaitCursor
                For Each tmpEvent As IUpdateEvent In DirectCast(Me.m_dgvMain.CurrentRow.Cells("IUpdate").Value, IUpdate).GetUpdateEventHistory(Date.MinValue, Date.MaxValue)
                    If DirectCast(dgvUpdateReport.Rows(e.RowIndex).Cells("ComputerID").Value, String) = tmpEvent.ComputerId Then
                        tmpMessage += Globals.globalRM.GetString("date") & ": " & tmpEvent.CreationDate.ToLocalTime & vbTab & "  " & tmpEvent.Message & vbNewLine
                    End If
                Next
                Me.Cursor = Cursors.Arrow
                If Not String.IsNullOrEmpty(tmpMessage) Then
                    MsgBox(tmpMessage, MsgBoxStyle.OkOnly, Globals.globalRM.GetString("History for") & " " & DirectCast(dgvUpdateReport.Rows(e.RowIndex).Cells("ComputerName").Value, String))
                End If
            End If
        Else
            m_originalValue = Nothing
        End If

    End Sub

    ''' <summary>
    ''' After the user sorts the DGV, load the new row that is selected.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DgvMainSorted(sender As Object, e As EventArgs) Handles m_dgvMain.Sorted
        Dim columnName As String = ""
        If Not m_noEvents Then

            If m_dgvMain.Rows.Count > 0 Then
                If Not m_originalValue = Nothing Then

                    'Choose the column name based on the tree view node.
                    If TypeOf Me.treeView.SelectedNode.Tag Is IComputerTargetGroup Then
                        columnName = "ComputerName"
                    ElseIf TypeOf Me.treeView.SelectedNode.Tag Is IUpdateCategory Then
                        columnName = "Title"
                    End If

                    'Select and load the original row.
                    For Each tmpRow As DataGridViewRow In m_dgvMain.Rows
                        If m_originalValue = DirectCast(tmpRow.Cells(columnName).Value, String) Then
                            m_dgvMain.CurrentCell = tmpRow.Cells(columnName)
                            Exit For
                        ElseIf tmpRow.Index = m_dgvMain.Rows.Count - 1 Then
                            m_dgvMain.CurrentCell = m_dgvMain.Rows(0).Cells(columnName)
                        End If
                    Next
                End If
                If Not Me.m_dgvMain.CurrentRow Is Nothing Then
                    Call LoadRow(m_dgvMain.CurrentRow.Index)
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' This routine finds the original row if it was saved.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub DgvComputerReportSorted(sender As Object, e As EventArgs) Handles dgvComputerReport.Sorted
        If m_noEvents = False Then

            If Not m_originalValue = Nothing And dgvComputerReport.Rows.Count > 0 Then
                'Select and load the original row.
                For Each tmpRow As DataGridViewRow In dgvComputerReport.Rows
                    If m_originalValue = DirectCast(tmpRow.Cells("UpdateTitle").Value, String) Then
                        dgvComputerReport.CurrentCell = tmpRow.Cells("UpdateTitle")
                        Exit For
                    ElseIf tmpRow.Index = dgvComputerReport.Rows.Count - 1 Then
                        dgvComputerReport.CurrentCell = dgvComputerReport.Rows(0).Cells("UpdateTitle")
                    End If
                Next
            End If
        End If
    End Sub

    ''' <summary>
    ''' This routine finds the original row if it was saved.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub DgvUpdateReportSorted(sender As Object, e As EventArgs) Handles dgvUpdateReport.Sorted
        If m_noEvents = False Then

            If Not m_originalValue = Nothing And dgvUpdateReport.Rows.Count > 0 Then
                'Select and load the original row.
                For Each tmpRow As DataGridViewRow In dgvUpdateReport.Rows
                    If m_originalValue = DirectCast(tmpRow.Cells("ComputerName").Value, String) Then
                        dgvUpdateReport.CurrentCell = tmpRow.Cells("ComputerName")
                        Exit For
                    ElseIf tmpRow.Index = dgvUpdateReport.Rows.Count - 1 Then
                        dgvUpdateReport.CurrentCell = dgvUpdateReport.Rows(0).Cells("ComputerName")
                    End If
                Next
            End If
        End If
    End Sub
#End Region

#Region "DGV Load Methods"

    ''' <summary>
    ''' Getting the computer list asynchronously.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub BgwComputerListDoWork(sender As Object, e As DoWorkEventArgs) Handles bgwComputerList.DoWork

        'If we were passed a RefreshInfo object then use it to call GetComputer list, store the data, and pass it to the result.
        If TypeOf e.Argument Is RefreshInfo Then
            Dim riTemp As RefreshInfo = DirectCast(e.Argument, RefreshInfo)
            If TypeOf riTemp.TreeNodeTag Is IComputerTargetGroup Then
                riTemp.DataTable = DataRoutines.GetComputerList(DirectCast(riTemp.TreeNodeTag, IComputerTargetGroup))
            End If
            e.Result = riTemp
        End If
    End Sub

    ''' <summary>
    ''' Load the data returned from the asynchronous process into the DGV.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub BgwComputerListRunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwComputerList.RunWorkerCompleted
        Dim riTemp As RefreshInfo = New RefreshInfo

        'If the result of the background work process was a RefreshInfo object then set the datasource to the returned data table.
        If TypeOf e.Result Is RefreshInfo Then
            riTemp = DirectCast(e.Result, RefreshInfo)
            m_dgvMainLoading = True
            m_dgvMain.DataSource = riTemp.DataTable
            m_dgvMainLoading = False
        End If

        If m_dgvMain.DataSource Is Nothing Then
            'Update the count.
            Me.lblSelectedTargetGroupCount.Text = String.Format(Globals.globalRM.GetString("computers_shown"), "0")
        Else

            'Set header texts for main DGV.
            Me.m_dgvMain.Columns("ComputerName").HeaderText = Globals.globalRM.GetString("computer_name")
            Me.m_dgvMain.Columns("ComputerName").SortMode = DataGridViewColumnSortMode.Automatic
            Me.m_dgvMain.Columns("IPAddress").HeaderText = Globals.globalRM.GetString("ip_address")
            Me.m_dgvMain.Columns("IPAddress").SortMode = DataGridViewColumnSortMode.Automatic
            Me.m_dgvMain.Columns("OperatingSystem").HeaderText = Globals.globalRM.GetString("operating_system")
            Me.m_dgvMain.Columns("OperatingSystem").SortMode = DataGridViewColumnSortMode.Automatic
            Me.m_dgvMain.Columns("InstalledNotApplicable").HeaderText = Globals.globalRM.GetString("installed_not_applicable")
            Me.m_dgvMain.Columns("InstalledNotApplicable").SortMode = DataGridViewColumnSortMode.Automatic
            Me.m_dgvMain.Columns("InstalledNotApplicable").DefaultCellStyle.Format = "p0"
            Me.m_dgvMain.Columns("InstalledNotApplicable").SortMode = DataGridViewColumnSortMode.Automatic
            Me.m_dgvMain.Columns("LastStatusReport").HeaderText = Globals.globalRM.GetString("last_status_report")
            Me.m_dgvMain.Columns("LastStatusReport").SortMode = DataGridViewColumnSortMode.Automatic


            'Hide some columns.
            Me.m_dgvMain.Columns("IComputerTarget").Visible = False
            Me.m_dgvMain.Columns("TargetID").Visible = False

            'Update the count.
            Me.lblSelectedTargetGroupCount.Text = String.Format(Globals.globalRM.GetString("computers_shown"), Me.m_dgvMain.Rows.Count)

            'If computers are listed in the DGV.
            If m_dgvMain.Rows.Count > 0 Then

                Call LoadDgvState(m_dgvMain)

                'If we are maintaining the row.
                If riTemp.MaintainSelectedRow Then
                    'Select the original row.
                    For Each tmpRow As DataGridViewRow In Me.m_dgvMain.Rows
                        If riTemp.OriginalValue = DirectCast(tmpRow.Cells("ComputerName").Value, String) Then
                            m_dgvMain.CurrentCell = tmpRow.Cells("ComputerName")
                            Exit For
                        ElseIf tmpRow.Index = m_dgvMain.Rows.Count - 1 Then
                            m_dgvMain.CurrentCell = m_dgvMain.Rows(0).Cells("ComputerName")
                        End If
                    Next
                Else
                    'Select the first row.
                    m_dgvMain.CurrentCell = m_dgvMain.Rows(0).Cells("ComputerName")
                End If

                btnComputerListRefresh.Enabled = True
                exportListToolStripMenuItem.Enabled = True

                'Load the selected computer's info.
                Call LoadComputerInfo(Me.m_dgvMain.CurrentRow.Index)

                '				I believe this is not needed; the Load Row method called via the current cell assignment above will take care of it.
                '				'If the user is currently on the report tab then update it.
                '				' Otherwise, clear the combo selections.
                '				If Me.tabMainComputers.SelectedTab.Name = Me.tabComputerReport.Name Then
                '					
                '					Call LoadComputerReport(Me._dgvMain.CurrentRow.Index)
                '					Call LoadDgvState(dgvComputerReport)
                '				Else
                '					Me.dgvComputerReport.DataSource = Nothing
                '					Me.cboTargetGroup.SelectedIndex =  -1
                '					Me.cboUpdateStatus.SelectedIndex = -1
                '				End If
            Else 'No computers listed in the DGV.
                btnComputerListRefresh.Enabled = False
                exportListToolStripMenuItem.Enabled = False

                'Call LoadComputerInfo( Me._dgvMain.CurrentRow.Index)
                Me.dgvUpdateReport.DataSource = Nothing
                Me.cboTargetGroup.SelectedIndex = -1
                Me.cboUpdateStatus.SelectedIndex = -1
            End If
        End If

        m_noEvents = False

        Call CheckBGWThreads()
    End Sub

    ''' <summary>
    ''' Call RefreshComputerList with defaults.
    ''' </summary>
    Sub RefreshComputerList()
        Call RefreshComputerList(False)
    End Sub

    ''' <summary>
    ''' Refresh the list of computers shown in the main DGV.
    ''' </summary>
    ''' <param name="maintainSelectedRow"></param>>
    Sub RefreshComputerList(maintainSelectedRow As Boolean)
        If Not Me.bgwComputerList.IsBusy Then
            Dim riTemp As RefreshInfo = New RefreshInfo

            m_noEvents = True

            'Make sure a computer tree node it selected
            If Not treeView.SelectedNode Is Nothing AndAlso _
                Not treeView.SelectedNode.Tag Is Nothing AndAlso _
                TypeOf treeView.SelectedNode.Tag Is IComputerTargetGroup Then

                'Populate refresh info object
                riTemp.TreeNodeTag = treeView.SelectedNode.Tag
                riTemp.MaintainSelectedRow = maintainSelectedRow

                'If we are maintaining the status then save the status.
                If maintainSelectedRow And m_dgvMain.SelectedRows.Count = 1 Then
                    riTemp.OriginalValue = DirectCast(m_dgvMain.CurrentRow.Cells.Item("ComputerName").Value, String)
                Else
                    riTemp.OriginalValue = Nothing
                End If

                'Clear the main DGV and computers listed count.
                m_dgvMainLoading = True
                m_dgvMain.DataSource = Nothing
                m_dgvMainLoading = False
                Me.lblSelectedTargetGroupCount.Text = Nothing

                'Make the asynchronous call.
                Me.bgwComputerList.RunWorkerAsync(riTemp)
            Else
                m_noEvents = False
            End If
        End If

        Call CheckBGWThreads()
    End Sub
    ''' <summary>
    ''' Asynchronously create a table with the update list.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Sub BgwUpdateListDoWork(sender As Object, e As DoWorkEventArgs) Handles bgwUpdateList.DoWork

        'If we were passed a RefreshInfo object then use it to call GetUpdateList, store the data, and pass it to the result.
        If TypeOf e.Argument Is RefreshInfo Then
            Dim riTemp As RefreshInfo = DirectCast(e.Argument, RefreshInfo)

            If TypeOf riTemp.TreeNodeTag Is IUpdateCategory Then
                riTemp.DataTable = DataRoutines.GetUpdateList(DirectCast(riTemp.TreeNodeTag, IUpdateCategory))
            End If
            e.Result = riTemp
        End If

    End Sub
    ''' <summary>
    ''' Load the data returned from the asynchronous call.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub BgwUpdateListRunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwUpdateList.RunWorkerCompleted
        Dim riTemp As RefreshInfo = New RefreshInfo

        'If the result of the background work process was a RefreshInfo object then set the datasource to the returned data table.
        If TypeOf e.Result Is RefreshInfo Then
            riTemp = DirectCast(e.Result, RefreshInfo)
            m_dgvMainLoading = True
            m_dgvMain.DataSource = riTemp.DataTable
            m_dgvMainLoading = False
        End If

        If Not m_dgvMain.DataSource Is Nothing Then

            'Hide columns.
            Me.m_dgvMain.Columns("IUpdate").Visible = False
            Me.m_dgvMain.Columns("Id").Visible = False

            'Change header text.
            Me.m_dgvMain.Columns("CreationDate").HeaderText = Globals.globalRM.GetString("creation_date")


            'If updates are loaded in the DGV.
            If m_dgvMain.Rows.Count > 0 Then
                Call LoadDgvState(m_dgvMain)

                'If we are maintaining the row.
                If riTemp.MaintainSelectedRow Then
                    'Select the original row.
                    For Each tmpRow As DataGridViewRow In Me.m_dgvMain.Rows
                        If riTemp.OriginalValue.Equals(DirectCast(tmpRow.Cells("Id").Value, UpdateRevisionId).UpdateId) Then
                            m_dgvMain.CurrentCell = tmpRow.Cells("Title")
                            Exit For
                        ElseIf tmpRow.Index = m_dgvMain.Rows.Count - 1 Then
                            m_dgvMain.CurrentCell = m_dgvMain.Rows(0).Cells("Title")
                        End If
                    Next
                Else
                    m_dgvMain.CurrentCell = m_dgvMain.Rows(0).Cells("Title")
                End If

                'Load the currently selected update's data.
                If Not Me.m_dgvMain.CurrentRow Is Nothing Then
                    Call LoadUpdateInfo(Me.m_dgvMain.CurrentRow.Index)
                    Call LoadUpdateStatus(Me.m_dgvMain.CurrentRow.Index)
                End If

                '				I believe this is not needed;  the Load Row method called via the current cell assignment above will take care of it.
                '				'If the user is currently on the report tab then update it.
                '				' Otherwise, clear the combo selections.
                '				If Me.tabMainUpdates.SelectedTab.Name = Me.tabUpdateReport.Name Then
                '					If Not Me._dgvMain.CurrentRow Is Nothing Then
                '						Call LoadUpdateReport(Me._dgvMain.CurrentRow.Index)
                '					End If
                '					Call LoadDgvState(dgvUpdateReport)
                '					
                '				Else
                '					
                '					Me.dgvUpdateReport.DataSource = Nothing
                '					Me.cboTargetGroup.SelectedIndex =  -1
                '					Me.cboUpdateStatus.SelectedIndex = -1
                '				End If
            End If
        End If

        Call CheckBGWThreads()
    End Sub

    ''' <summary>
    ''' Call RefreshUpdateList with defaults.
    ''' </summary>
    Sub RefreshUpdateList()
        Call RefreshUpdateList(False)
    End Sub

    ''' <summary>
    ''' Refresh the main data grid view with updates based on the currently selected tree node. 
    ''' </summary>
    ''' <param name="maintainSelectedRow">Used to select the current update again after the data grid view is refreshed</param>
    Sub RefreshUpdateList(maintainSelectedRow As Boolean)
        Dim originalValue As Guid

        If Not Me.bgwUpdateList.IsBusy Then
            Dim riTemp As RefreshInfo = New RefreshInfo

            m_noEvents = True
            If Me.treeView.SelectedNode Is Nothing OrElse _
                Me.treeView.SelectedNode.Tag Is Nothing Then

                'Clear the main DGV.
                m_dgvMainLoading = True
                m_dgvMain.DataSource = Nothing
                m_dgvMainLoading = False

                'Clear the update data by calling the loads with an index equal to the number of rows.
                Call LoadUpdateInfo(Me.m_dgvMain.Rows.Count)
                Call LoadUpdateStatus(Me.m_dgvMain.Rows.Count)


            ElseIf Not TypeOf Me.treeView.SelectedNode.Tag Is IUpdateCategory Then
                m_dgvMainLoading = True
                m_dgvMain.DataSource = Nothing 'Clear the main DGV.
                m_dgvMainLoading = False
            Else
                If DirectCast(Me.treeView.SelectedNode.Tag, IUpdateCategory).ProhibitsUpdates = False Then
                    'Populate refresh info object
                    riTemp.TreeNodeTag = treeView.SelectedNode.Tag
                    riTemp.MaintainSelectedRow = maintainSelectedRow

                    'If we are maintaining the status then save the status.
                    If maintainSelectedRow And m_dgvMain.SelectedRows.Count = 1 Then
                        originalValue = DirectCast(m_dgvMain.CurrentRow.Cells.Item("Id").Value, UpdateRevisionId).UpdateId
                    Else
                        originalValue = Nothing
                    End If

                    'Clear the main DGV.
                    m_dgvMainLoading = True
                    m_dgvMain.DataSource = Nothing
                    m_dgvMainLoading = False

                    'Make the asynchronous call.
                    Me.bgwUpdateList.RunWorkerAsync(riTemp)
                End If
            End If
        End If

        Call CheckBGWThreads()
        m_noEvents = False
    End Sub
#End Region

#Region "DGV Methods"
    ''' <summary>
    ''' This routine loads the data from the currently selected row in the main DGV
    ''' </summary>
    ''' <param name="rowIndex">The row index to be loaded.</param>
    ''' <remarks>
    ''' Since there is no good row changed event in
    ''' VB we are using the mousedown event of the DGV.  Since the user
    ''' might click multiple times on the same row we track the current row
    '''  ourselves using the intCurrentRow object.  In this way we do not
    ''' load the same row twice.
    ''' </remarks>
    Sub LoadRow(rowIndex As Integer)
        'If the current row hasn't changed, there is no selected treenode,
        ' or that tree node's tag is not populated then exit this routine.
        If Me.treeView.SelectedNode Is Nothing OrElse _
            Me.treeView.SelectedNode.Tag Is Nothing Then
            Call SetContextMenu(-1)
            Exit Sub
            'Computer Node
        ElseIf TypeOf Me.treeView.SelectedNode.Tag Is IComputerTargetGroup Then
            '_currentRowIndex = rowIndex 'Set new row as current.


            Call LoadComputerInfo(rowIndex)
            Call SetContextMenu(rowIndex)

            'If the user is currently on the Report tab then update it
            ' Otherwise clear the combo selections.
            If Me.tabMainComputers.SelectedTab.Name = Me.tabComputerReport.Name Then
                Call LoadComputerReport(rowIndex)
            Else
                m_noEvents = True
                Me.dgvUpdateReport.DataSource = Nothing
                Me.cboTargetGroup.SelectedIndex = -1
                Me.cboUpdateStatus.SelectedIndex = -1
                m_noEvents = False
            End If
            'Update node.
        ElseIf TypeOf Me.treeView.SelectedNode.Tag Is IUpdateCategory Then

            'Load the currently selected update's data.
            Call LoadUpdateInfo(rowIndex)
            Call LoadUpdateStatus(rowIndex)
            Call SetContextMenu(rowIndex)

            'If the user is currently on the report tab then update it.
            ' Otherwise clear the combo selections.
            If Me.tabMainUpdates.SelectedTab.Name = Me.tabUpdateReport.Name Then
                Call LoadUpdateReport(rowIndex)
            Else
                m_noEvents = True
                Me.dgvUpdateReport.DataSource = Nothing
                Me.cboTargetGroup.SelectedIndex = -1
                Me.cboUpdateStatus.SelectedIndex = -1
                m_noEvents = False
            End If
        End If
    End Sub

    ''' <summary>
    ''' Load the update info for the currently selected update.
    ''' </summary>
    ''' <param name="rowIndex"></param>
    Sub LoadUpdateInfo(rowIndex As Integer)
        Me.Cursor = Cursors.WaitCursor 'Set wait cursor.

        Call ClearUpdateInfo()

        '		'Exit if the index passed in is not within range.
        '		If Me._dgvMain.Rows.Count <= rowIndex Then Exit Sub



        'Make sure that the rowIndex is within range, at least one row is selected, and the node selected
        ' is an update category.
        If Me.m_dgvMain.Rows.Count > rowIndex AndAlso Me.m_dgvMain.SelectedRows.Count = 1 AndAlso _
            TypeOf Me.treeView.SelectedNode.Tag Is IUpdateCategory Then

            'Load the data
            Dim update As IUpdate = DirectCast(Me.m_dgvMain.Rows(rowIndex).Cells("IUpdate").Value, IUpdate)
            If update.UpdateType = UpdateType.Software Then
                Me.txtPackageType.Text = Globals.globalRM.GetString("update")
            ElseIf update.UpdateType = UpdateType.SoftwareApplication Then
                Me.txtPackageType.Text = Globals.globalRM.GetString("application")
            ElseIf update.UpdateType = UpdateType.Driver Then
                Me.txtPackageType.Text = Globals.globalRM.GetString("driver")
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
            Me.txtNetwork.Text = update.InstallationBehavior.RequiresNetworkConnectivity.ToString

            'Set the prerequisite objects.
            If update.GetRelatedUpdates(UpdateRelationship.UpdatesRequiredByThisUpdate).Count > 0 Then
                lblPrerequisites.Visible = True
                PrerequisiteUpdatesForm = Nothing
            Else
                lblPrerequisites.Visible = False
            End If

            'Set the superseded objects
            If update.HasSupersededUpdates Then
                lblSupersedes.Visible = True
                LanguageSelectionForm = Nothing
            Else
                lblSupersedes.Visible = False
            End If
        End If

        Me.Cursor = Cursors.Arrow 'Set arrow cursor.
    End Sub

    ''' <summary>
    ''' Populate the update status DGV.
    ''' </summary>
    ''' <param name="rowIndex"></param>
    Sub LoadUpdateStatus(rowIndex As Integer)

        'Make sure we are in a data row, not the header and that the tree node
        ' selected has a tag on which we can base how to load the data
        If Me.m_dgvMain.Rows.Count <= rowIndex OrElse Me.m_dgvMain.SelectedRows.Count <> 1 Then
            m_noEvents = True
            'Clear the data source of the status DGV.
            Me.dgvUpdateStatus.DataSource = Nothing
            m_noEvents = False
        ElseIf TypeOf Me.treeView.SelectedNode.Tag Is IUpdateCategory Then


            'Set the data source of the status DGV.
            Me.dgvUpdateStatus.DataSource = DataRoutines.GetUpdateStatus(DirectCast(Me.m_dgvMain.Rows(rowIndex).Cells("IUpdate").Value, IUpdate), Me.m_computerNode)

            'Set header texts for status DGV.
            Me.dgvUpdateStatus.Columns("GroupName").HeaderText = Globals.globalRM.GetString("group_name")
            Me.dgvUpdateStatus.Columns("InstalledCount").HeaderText = Globals.globalRM.GetString("installed")
            Me.dgvUpdateStatus.Columns("NotInstalledCount").HeaderText = Globals.globalRM.GetString("not_installed")
            Me.dgvUpdateStatus.Columns("NotApplicableCount").HeaderText = Globals.globalRM.GetString("not_applicable")
            Me.dgvUpdateStatus.Columns("FailedCount").HeaderText = Globals.globalRM.GetString("failed")
            Me.dgvUpdateStatus.Columns("DownloadedCount").HeaderText = Globals.globalRM.GetString("downloaded")
            Me.dgvUpdateStatus.Columns("UnknownCount").HeaderText = Globals.globalRM.GetString("unknown")
            Me.dgvUpdateStatus.Columns("LastUpdated").HeaderText = Globals.globalRM.GetString("last_updated")

            If dgvUpdateStatus.Rows.Count > 0 Then
                Call LoadDgvState(dgvUpdateStatus)
            End If
        End If

    End Sub

    ''' <summary>
    ''' Load the currently selected computer's info into the form.
    ''' </summary>
    ''' <param name="rowIndex"></param>
    Sub LoadComputerInfo(rowIndex As Integer)
        Me.Cursor = Cursors.WaitCursor 'Set wait cursor

        Call ClearComputerInfo()

        If Me.m_dgvMain.Rows.Count >= rowIndex AndAlso Me.m_dgvMain.SelectedRows.Count = 1 Then
            'Set the update scope to only include locally published updates for the selected group.
            Dim tmpUpdateScope As UpdateScope = New UpdateScope
            tmpUpdateScope.UpdateSources = UpdateSources.Other

            'Add groups to approvals reported based on application settings.
            If Globals.appSettings.ApprovedUpdatesOnly Then
                DataRoutines.AddParentGroupApprovals(tmpUpdateScope, DirectCast(treeView.SelectedNode.Tag, IComputerTargetGroup), Globals.appSettings.InheritApprovals) 'Add groups recursively.
            End If

            Dim tmpUpdateSummary As IUpdateSummary = DirectCast(Me.m_dgvMain.Rows(rowIndex).Cells("IComputerTarget").Value, IComputerTarget).GetUpdateInstallationSummary(tmpUpdateScope)
            Me.txtUpdatesWErrorsNum.Text = CStr(tmpUpdateSummary.FailedCount)
            Me.txtUpdatesNeededNum.Text = CStr(tmpUpdateSummary.NotInstalledCount + tmpUpdateSummary.DownloadedCount)
            Me.txtUpdatesInstalledorNANum.Text = CStr(tmpUpdateSummary.NotApplicableCount + tmpUpdateSummary.InstalledCount + tmpUpdateSummary.InstalledPendingRebootCount)
            Me.txtUpdateNoStatusNum.Text = CStr(tmpUpdateSummary.UnknownCount)
        End If

        Me.Cursor = Cursors.Arrow 'Set arrow cursor
    End Sub

    ''' <summary>
    ''' Load the summary data for each update based on the currently selected group.
    ''' </summary>
    Sub LoadComputerGroupStatus()
        'Make sure the selected not has a tag.
        If Me.treeView.SelectedNode Is Nothing OrElse _
            Me.treeView.SelectedNode.Tag Is Nothing Then
            'Clear the data source of the status DGV.
            Me.dgvComputerGroupStatus.DataSource = Nothing
        ElseIf TypeOf Me.treeView.SelectedNode.Tag Is IComputerTargetGroup Then

            'Set the data source of the status DGV.
            Me.dgvComputerGroupStatus.DataSource = DataRoutines.GetComputerGroupStatus(DirectCast(Me.treeView.SelectedNode.Tag, IComputerTargetGroup))

            'Set header texts for status DGV.
            dgvComputerGroupStatus.Columns("Title").HeaderText = Globals.globalRM.GetString("title")
            dgvComputerGroupStatus.Columns("InstalledCount").HeaderText = Globals.globalRM.GetString("installed")
            dgvComputerGroupStatus.Columns("NotInstalledCount").HeaderText = Globals.globalRM.GetString("not_installed")
            dgvComputerGroupStatus.Columns("NotApplicableCount").HeaderText = Globals.globalRM.GetString("not_applicable")
            dgvComputerGroupStatus.Columns("FailedCount").HeaderText = Globals.globalRM.GetString("failed")
            dgvComputerGroupStatus.Columns("DownloadedCount").HeaderText = Globals.globalRM.GetString("downloaded")
            dgvComputerGroupStatus.Columns("UnknownCount").HeaderText = Globals.globalRM.GetString("unknown")
            dgvComputerGroupStatus.Columns("LastUpdated").HeaderText = Globals.globalRM.GetString("last_updated")

            If dgvComputerGroupStatus.Rows.Count > 0 Then
                Call LoadDgvState(dgvComputerGroupStatus)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Call LoadComputerReport with the default parameters.
    ''' </summary>
    ''' <param name="rowIndex"></param>
    Sub LoadComputerReport(rowIndex As Integer)
        LoadComputerReport(rowIndex, False)
    End Sub

    ''' <summary>
    ''' Load the report data for the currently selected computer.
    ''' </summary>
    ''' <param name="rowIndex">Row index used to indicate the update to report upon.</param>
    ''' <param name="maintainSelectedRow">Maintain the selected row after report is loaded.</param>
    Sub LoadComputerReport(rowIndex As Integer, maintainSelectedRow As Boolean)

        Dim originalValue As String
        Me.Cursor = Cursors.WaitCursor 'Set wait cursor
        m_noEvents = True

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

            'Get the computer report data asynchronously.
            If Not Me.bgwComputerReport.IsBusy Then
                Me.bgwComputerReport.RunWorkerAsync(New ComputerReportDetails(DirectCast(Me.m_dgvMain.Rows(rowIndex).Cells("TargetID").Value, String), Me.cboUpdateStatus.Text, originalValue))
            End If

        End If 'Nothing selected in cboUpdateStatus.
        m_noEvents = False
        Me.Cursor = Cursors.Arrow 'Set arrow cursor

        Call CheckBGWThreads()
    End Sub
    ''' <summary>
    ''' Asynchronously get the computer report.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub BgwComputerReportDoWork(sender As Object, e As DoWorkEventArgs) Handles bgwComputerReport.DoWork
        Try
            Dim computerReportDetails As ComputerReportDetails = Nothing

            If TypeOf e.Argument Is ComputerReportDetails Then
                computerReportDetails = DirectCast(e.Argument, ComputerReportDetails)

                'Get the data.			
                computerReportDetails.Data = DataRoutines.GetComputerReport(computerReportDetails.ComputerID, computerReportDetails.Status)

            End If

            e.Result = computerReportDetails

        Catch x As Exception
            MsgBox("BgwComputerReportDoWork: " & x.Message)
        End Try
    End Sub
    ''' <summary>
    ''' Load the data returned by the asynchronous call.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub BgwComputerReportRunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwComputerReport.RunWorkerCompleted
        Dim computerReportDetails As ComputerReportDetails

        Try
            If TypeOf e.Result Is ComputerReportDetails Then
                computerReportDetails = DirectCast(e.Result, ComputerReportDetails)


                'Set the data source.	
                m_noEvents = True
                dgvComputerReport.DataSource = computerReportDetails.Data
                m_noEvents = False

                'Hide columns
                dgvComputerReport.Columns("IUpdate").Visible = False
                dgvComputerReport.Columns("UpdateID").Visible = False

                'Rename some columns.
                dgvComputerReport.Columns("UpdateTitle").HeaderText = Globals.globalRM.GetString("update_title")
                dgvComputerReport.Columns("UpdateInstallationState").HeaderText = Globals.globalRM.GetString("status")
                dgvComputerReport.Columns("UpdateApprovalAction").HeaderText = Globals.globalRM.GetString("approval")

                'Make the status column's text blue
                dgvComputerReport.Columns("UpdateInstallationState").DefaultCellStyle.ForeColor = Color.Blue

                'If updates are loaded in the DGV.
                If dgvComputerReport.Rows.Count > 0 Then
                    btnComputerRefreshReport.Enabled = True
                    exportReportToolStripMenuItem.Enabled = True

                    Call LoadDgvState(dgvComputerReport)

                    'If we are maintaining the selected row.
                    If Not String.IsNullOrEmpty(computerReportDetails.OriginalValue) Then

                        'Select and load the original row.
                        For Each tmpRow As DataGridViewRow In dgvComputerReport.Rows
                            If computerReportDetails.OriginalValue = DirectCast(tmpRow.Cells("UpdateTitle").Value, String) Then
                                dgvComputerReport.CurrentCell = tmpRow.Cells("UpdateTitle")
                                Exit For
                            ElseIf tmpRow.Index = dgvComputerReport.Rows.Count - 1 Then
                                dgvComputerReport.CurrentCell = dgvComputerReport.Rows(0).Cells("UpdateTitle")
                            End If
                        Next
                    Else 'Select first row.
                        dgvComputerReport.CurrentCell = dgvComputerReport.Rows(0).Cells("UpdateTitle")
                    End If
                Else 'No rows returned.
                    btnComputerRefreshReport.Enabled = False
                    exportReportToolStripMenuItem.Enabled = False
                End If 'Rows returned.			
            End If

            Call CheckBGWThreads()

        Catch x As Exception
            MsgBox("BgwComputerReportRunWorkerCompleted: " & x.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Call LoadUpdateReport with defaults.
    ''' </summary>
    ''' <param name="rowIndex"></param>
    Sub LoadUpdateReport(rowIndex As Integer)
        Call LoadUpdateReport(rowIndex, False)
    End Sub

    ''' <summary>
    ''' Populate the update report DGV.
    ''' </summary>
    ''' <param name="rowIndex">Row Index used to indicate the update to report upon.</param>
    ''' <param name="maintainSelectedRow">Maintain the currently selected row.</param>
    Sub LoadUpdateReport(rowIndex As Integer, maintainSelectedRow As Boolean)
        Dim originalValue As String
        Me.Cursor = Cursors.WaitCursor 'Set wait cursor.
        m_noEvents = True

        'If an Update Status was selected or no update is selected.
        If cboTargetGroup.SelectedIndex = -1 OrElse Me.m_dgvMain.Rows(rowIndex).Cells("IUpdate").Value Is Nothing Then
            'Clear the DGV.
            Me.dgvUpdateReport.DataSource = Nothing
        Else

            'If the user hasn't selected an update status then choose any status.
            If cboUpdateStatus.SelectedIndex = -1 Then cboUpdateStatus.SelectedIndex = 6

            'If we are maintaining the status then save the status.
            If maintainSelectedRow AndAlso Not dgvUpdateReport.CurrentRow Is Nothing Then
                originalValue = DirectCast(dgvUpdateReport.CurrentRow.Cells.Item("ComputerName").Value, String)
            Else
                maintainSelectedRow = False
                originalValue = ""
            End If


            'Get the computer report data asynchronously.
            If Not Me.bgwUpdateReport.IsBusy Then
                Me.bgwUpdateReport.RunWorkerAsync(New UpdateReportDetails(DirectCast(Me.m_dgvMain.Rows(rowIndex).Cells("IUpdate").Value, IUpdate), DirectCast(Me.cboTargetGroup.SelectedItem, ComboTargetGroups).Value, Me.cboUpdateStatus.Text, originalValue))
            End If

        End If 'Status of combobox.

        m_noEvents = False
        Me.Cursor = Cursors.Arrow 'Set arrow cursor.


        Call CheckBGWThreads()
    End Sub
    ''' <summary>
    ''' Asynchronously get the update report.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Sub BgwUpdateReportDoWork(sender As Object, e As DoWorkEventArgs) Handles bgwUpdateReport.DoWork
        Dim updateReportDetails As UpdateReportDetails = Nothing

        If TypeOf e.Argument Is UpdateReportDetails Then
            updateReportDetails = DirectCast(e.Argument, UpdateReportDetails)

            'Set the data source.
            updateReportDetails.Data = DataRoutines.GetUpdateReport(updateReportDetails.Update, updateReportDetails.TargetGroup, updateReportDetails.Status)
        End If

        e.Result = updateReportDetails
    End Sub
    ''' <summary>
    ''' Load the date returned by the asynchronous call.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Sub BgwUpdateReportRunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwUpdateReport.RunWorkerCompleted
        Dim updateReportDetails As UpdateReportDetails

        If TypeOf e.Result Is UpdateReportDetails Then
            updateReportDetails = DirectCast(e.Result, UpdateReportDetails)

            'Set the data source.
            dgvUpdateReport.DataSource = updateReportDetails.Data

            'Hide the ID column.
            dgvUpdateReport.Columns("ComputerID").Visible = False

            'Rename some columns.
            dgvUpdateReport.Columns("ComputerName").HeaderText = Globals.globalRM.GetString("computer_name")
            dgvUpdateReport.Columns("UpdateInstallationState").HeaderText = Globals.globalRM.GetString("status")
            dgvUpdateReport.Columns("UpdateApprovalAction").HeaderText = Globals.globalRM.GetString("approval")

            'Make the status column's text blue
            dgvUpdateReport.Columns("UpdateInstallationState").DefaultCellStyle.ForeColor = Color.Blue

            'If updates are loaded in the DGV.
            If dgvUpdateReport.Rows.Count > 0 Then
                btnUpdateRefreshReport.Enabled = True
                exportReportToolStripMenuItem.Enabled = True

                Call LoadDgvState(dgvUpdateReport)

                'If we are maintaining the selected row.
                If Not String.IsNullOrEmpty(updateReportDetails.OriginalValue) Then

                    'Select and load the original row.
                    For Each tmpRow As DataGridViewRow In dgvUpdateReport.Rows
                        If updateReportDetails.OriginalValue = DirectCast(tmpRow.Cells("ComputerName").Value, String) Then
                            dgvUpdateReport.CurrentCell = tmpRow.Cells("ComputerName")
                            Exit For
                        ElseIf tmpRow.Index = dgvUpdateReport.Rows.Count - 1 Then
                            dgvUpdateReport.CurrentCell = dgvUpdateReport.Rows(0).Cells("ComputerName")
                        End If
                    Next
                Else 'Select the first row.
                    dgvUpdateReport.CurrentCell = dgvUpdateReport.Rows(0).Cells("ComputerName")
                End If

            Else
                btnUpdateRefreshReport.Enabled = False
                exportReportToolStripMenuItem.Enabled = False
            End If
        End If

        Call CheckBGWThreads()

    End Sub
    ''' <summary>
    ''' Load the state of the passed in DGV using saved settings.
    ''' </summary>
    ''' <param name="dgv"></param>
    ''' <remarks>Only run if the number of columns match. While the
    ''' state is being loaded prevent any events from happening.
    ''' </remarks>
    Sub LoadDgvState(ByRef dgv As DataGridView)
        m_noEvents = True

        'Differentiate the right setting by the DGV's name.
        If dgv.Name = Me.m_dgvMain.Name Then

            'Make sure a node is selected and has a tag.
            If Not treeView.SelectedNode Is Nothing AndAlso _
                Not treeView.SelectedNode.Tag Is Nothing Then

                'If the selected node's tag is an update or a computer node.
                If TypeOf treeView.SelectedNode.Tag Is IComputerTargetGroup Then

                    'Sort the columns if a sort order is saved.
                    If Not Globals.appSettings.StateMainComputersDGV.SortColumn Is Nothing AndAlso _
                        Not dgv.Columns(Globals.appSettings.StateMainComputersDGV.SortColumn) Is Nothing Then

                        dgv.Sort(dgv.Columns(Globals.appSettings.StateMainComputersDGV.SortColumn), _
                            Globals.appSettings.StateMainComputersDGV.SortDirection)
                    End If

                    'Set the widths using the saved values
                    If Globals.appSettings.StateMainComputersDGV.ColumnFillWeights.Length = dgv.Columns.Count Then
                        For Each column As DataGridViewColumn In dgv.Columns
                            column.FillWeight = Globals.appSettings.StateMainComputersDGV.ColumnFillWeights(column.Index)
                        Next
                    End If
                    'If type is an Update node.
                ElseIf TypeOf treeView.SelectedNode.Tag Is IUpdateCategory Then

                    'Sort the columns if a sort order is saved.
                    If Not Globals.appSettings.StateMainUpdatesDGV.SortColumn Is Nothing AndAlso _
                        Not dgv.Columns(Globals.appSettings.StateMainUpdatesDGV.SortColumn) Is Nothing Then
                        dgv.Sort(dgv.Columns(Globals.appSettings.StateMainUpdatesDGV.SortColumn), _
                            Globals.appSettings.StateMainUpdatesDGV.SortDirection)
                    End If

                    If Globals.appSettings.StateMainUpdatesDGV.ColumnFillWeights.Length = dgv.Columns.Count Then
                        For Each column As DataGridViewColumn In dgv.Columns
                            column.FillWeight = Globals.appSettings.StateMainUpdatesDGV.ColumnFillWeights(column.Index)
                        Next
                    End If
                End If
            End If 'Node is selected and tag instantiated.
        ElseIf dgv.Name = Me.dgvComputerReport.Name Then

            'Sort the columns if a sort order is saved.
            If Not Globals.appSettings.StateComputerReportDGV.SortColumn = Nothing AndAlso _
                Not dgv.Columns(Globals.appSettings.StateComputerReportDGV.SortColumn) Is Nothing Then

                dgv.Sort(dgv.Columns(Globals.appSettings.StateComputerReportDGV.SortColumn), _
                    Globals.appSettings.StateComputerReportDGV.SortDirection)
            End If

            If Globals.appSettings.StateComputerReportDGV.ColumnFillWeights.Length = dgv.Columns.Count Then

                For Each column As DataGridViewColumn In dgv.Columns
                    column.FillWeight = Globals.appSettings.StateComputerReportDGV.ColumnFillWeights(column.Index)
                Next
            End If
        ElseIf dgv.Name = Me.dgvComputerGroupStatus.Name Then

            'Sort the columns if a sort order is saved.
            If Not Globals.appSettings.StateComputerGroupStatusDGV.SortColumn = Nothing AndAlso _
                Not dgv.Columns(Globals.appSettings.StateComputerGroupStatusDGV.SortColumn) Is Nothing Then

                dgv.Sort(dgv.Columns(Globals.appSettings.StateComputerGroupStatusDGV.SortColumn), _
                    Globals.appSettings.StateComputerGroupStatusDGV.SortDirection)
            End If

            If Globals.appSettings.StateComputerGroupStatusDGV.ColumnFillWeights.Length = dgv.Columns.Count Then

                For Each column As DataGridViewColumn In dgv.Columns
                    column.FillWeight = Globals.appSettings.StateComputerGroupStatusDGV.ColumnFillWeights(column.Index)
                Next
            End If
        ElseIf dgv.Name = Me.dgvUpdateReport.Name Then

            'Sort the columns if a sort order is saved.
            If Not Globals.appSettings.StateUpdateReportDGV.SortColumn = Nothing AndAlso _
                Not dgv.Columns(Globals.appSettings.StateUpdateReportDGV.SortColumn) Is Nothing Then

                dgv.Sort(dgv.Columns(Globals.appSettings.StateUpdateReportDGV.SortColumn), _
                    Globals.appSettings.StateUpdateReportDGV.SortDirection)
            End If

            If Globals.appSettings.StateUpdateReportDGV.ColumnFillWeights.Length = dgv.Columns.Count Then

                For Each column As DataGridViewColumn In dgv.Columns
                    column.FillWeight = Globals.appSettings.StateUpdateReportDGV.ColumnFillWeights(column.Index)
                Next
            End If
        ElseIf dgv.Name = Me.dgvUpdateStatus.Name Then

            'Sort the columns if a sort order is saved.
            If Not Globals.appSettings.StateUpdateStatusDGV.SortColumn = Nothing AndAlso _
                Not dgv.Columns(Globals.appSettings.StateUpdateStatusDGV.SortColumn) Is Nothing Then

                dgv.Sort(dgv.Columns(Globals.appSettings.StateUpdateStatusDGV.SortColumn), _
                    Globals.appSettings.StateUpdateStatusDGV.SortDirection)
            End If

            If Globals.appSettings.StateUpdateStatusDGV.ColumnFillWeights.Length = dgv.Columns.Count Then

                For Each column As DataGridViewColumn In dgv.Columns
                    column.FillWeight = Globals.appSettings.StateUpdateStatusDGV.ColumnFillWeights(column.Index)
                Next
            End If
        End If

        m_noEvents = False
    End Sub

    ''' <summary>
    ''' Save the state of DGVs based on the type of node passed in.
    ''' </summary>
    ''' <param name="node"></param>
    Sub SaveDgvState(ByRef node As TreeNode)

        'If the node has a tag then save the appropriate DGVs.
        If Not node Is Nothing AndAlso Not node.Tag Is Nothing Then
            If TypeOf node.Tag Is IComputerTargetGroup Then 'Computer Note
                Call SaveDgvState(m_dgvMain)
                If tabMainComputers.SelectedTab.Equals(tabComputerReport) Then
                    Call SaveDgvState(dgvComputerReport)
                ElseIf tabMainComputers.SelectedTab.Equals(tabComputerStatus) Then
                    Call SaveDgvState(dgvComputerGroupStatus)
                End If
            ElseIf TypeOf node.Tag Is IUpdateCategory Then 'Update Node
                Call SaveDgvState(m_dgvMain)
                If tabMainUpdates.SelectedTab.Equals(tabUpdateReport) Then
                    Call SaveDgvState(dgvUpdateReport)
                ElseIf tabMainUpdates.SelectedTab.Equals(tabUpdateStatus) Then
                    Call SaveDgvState(dgvUpdateStatus)
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' Save the state the DGV.
    ''' </summary>
    ''' <param name="dgv"></param>
    Sub SaveDGVState(ByRef dgv As DataGridView)

        'Save the dgv's columns to a temporary array.
        Dim tmpArray As Integer() = New Integer(dgv.Columns.Count - 1) {}
        For Each column As DataGridViewColumn In dgv.Columns
            tmpArray(column.Index) = CInt(column.FillWeight)
        Next

        'Differentiate the right setting by the DGV's name.
        If dgv.Name = Me.m_dgvMain.Name Then

            'Make sure a node is selected and has a tag.
            If Not treeView.SelectedNode Is Nothing AndAlso _
                Not treeView.SelectedNode.Tag Is Nothing Then

                'If the selected node's tag is an update or a computer node.
                If TypeOf treeView.SelectedNode.Tag Is IComputerTargetGroup Then

                    'Save the sort column if the DGV is sorted.
                    If dgv.SortedColumn Is Nothing AndAlso dgv.Rows.Count > 0 Then

                        Globals.appSettings.StateMainComputersDGV.SortColumn = Nothing
                        Globals.appSettings.StateMainComputersDGV.SortDirection = ListSortDirection.Descending
                    ElseIf Not dgv.SortedColumn Is Nothing Then
                        Globals.appSettings.StateMainComputersDGV.SortColumn = dgv.SortedColumn.Name

                        'Save the sort order.
                        If dgv.SortOrder = SortOrder.Ascending Then
                            Globals.appSettings.StateMainComputersDGV.SortDirection = ListSortDirection.Ascending
                        ElseIf dgv.SortOrder = SortOrder.Descending Then
                            Globals.appSettings.StateMainComputersDGV.SortDirection = ListSortDirection.Descending
                        End If
                    End If

                    'Save the column fill weights and the dgv name.
                    Globals.appSettings.StateMainComputersDGV.ColumnFillWeights = tmpArray
                    Globals.appSettings.StateMainComputersDGV.Name = dgv.Name
                    'If type is an Update node.
                ElseIf TypeOf treeView.SelectedNode.Tag Is IUpdateCategory Then

                    'Save the sort column if the DGV is sorted.
                    If dgv.SortedColumn Is Nothing AndAlso dgv.Rows.Count > 0 Then

                        Globals.appSettings.StateMainUpdatesDGV.SortColumn = Nothing
                        Globals.appSettings.StateMainUpdatesDGV.SortDirection = ListSortDirection.Descending
                    ElseIf Not dgv.SortedColumn Is Nothing Then
                        Globals.appSettings.StateMainUpdatesDGV.SortColumn = dgv.SortedColumn.Name

                        'Save the sort order.
                        If dgv.SortOrder = SortOrder.Ascending Then
                            Globals.appSettings.StateMainUpdatesDGV.SortDirection = ListSortDirection.Ascending
                        ElseIf dgv.SortOrder = SortOrder.Descending Then
                            Globals.appSettings.StateMainUpdatesDGV.SortDirection = ListSortDirection.Descending
                        End If
                    End If

                    'Save the column fill weights and the dgv name.
                    Globals.appSettings.StateMainUpdatesDGV.ColumnFillWeights = tmpArray
                    Globals.appSettings.StateMainUpdatesDGV.Name = dgv.Name
                End If
            End If 'Node is selected tag instantiated.
        ElseIf dgv.Name = Me.dgvComputerReport.Name Then

            'Save the sort column if the DGV is sorted.
            If dgv.SortedColumn Is Nothing AndAlso dgv.Rows.Count > 0 Then
                Globals.appSettings.StateComputerReportDGV.SortColumn = Nothing
                Globals.appSettings.StateComputerReportDGV.SortDirection = ListSortDirection.Descending
            ElseIf Not dgv.SortedColumn Is Nothing Then
                Globals.appSettings.StateComputerReportDGV.SortColumn = dgv.SortedColumn.Name

                'Save the sort order.
                If dgv.SortOrder = SortOrder.Ascending Then
                    Globals.appSettings.StateComputerReportDGV.SortDirection = ListSortDirection.Ascending
                ElseIf dgv.SortOrder = SortOrder.Descending Then
                    Globals.appSettings.StateComputerReportDGV.SortDirection = ListSortDirection.Descending
                End If
            End If

            'Save the column fill weights and the dgv name.
            Globals.appSettings.StateComputerReportDGV.ColumnFillWeights = tmpArray
            Globals.appSettings.StateComputerReportDGV.Name = dgv.Name
        ElseIf dgv.Name = Me.dgvComputerGroupStatus.Name Then

            'Save the sort column if the DGV is sorted.
            If dgv.SortedColumn Is Nothing AndAlso dgv.Rows.Count > 0 Then
                Globals.appSettings.StateComputerGroupStatusDGV.SortColumn = Nothing
                Globals.appSettings.StateComputerGroupStatusDGV.SortDirection = ListSortDirection.Descending
            ElseIf Not dgv.SortedColumn Is Nothing Then
                Globals.appSettings.StateComputerGroupStatusDGV.SortColumn = dgv.SortedColumn.Name

                'Save the sort order.
                If dgv.SortOrder = SortOrder.Ascending Then
                    Globals.appSettings.StateComputerGroupStatusDGV.SortDirection = ListSortDirection.Ascending
                ElseIf dgv.SortOrder = SortOrder.Descending Then
                    Globals.appSettings.StateComputerGroupStatusDGV.SortDirection = ListSortDirection.Descending
                End If
            End If

            'Save the column fill weights and the dgv name.
            Globals.appSettings.StateComputerGroupStatusDGV.ColumnFillWeights = tmpArray
            Globals.appSettings.StateComputerGroupStatusDGV.Name = dgv.Name
        ElseIf dgv.Name = Me.dgvUpdateReport.Name Then

            'Save the sort column if the DGV is sorted.
            If dgv.SortedColumn Is Nothing AndAlso dgv.Rows.Count > 0 Then
                Globals.appSettings.StateUpdateReportDGV.SortColumn = Nothing
                Globals.appSettings.StateUpdateReportDGV.SortDirection = ListSortDirection.Descending
            ElseIf Not dgv.SortedColumn Is Nothing Then
                Globals.appSettings.StateUpdateReportDGV.SortColumn = dgv.SortedColumn.Name

                'Save the sort order.
                If dgv.SortOrder = SortOrder.Ascending Then
                    Globals.appSettings.StateUpdateReportDGV.SortDirection = ListSortDirection.Ascending
                ElseIf dgv.SortOrder = SortOrder.Descending Then
                    Globals.appSettings.StateUpdateReportDGV.SortDirection = ListSortDirection.Descending
                End If
            End If

            'Save the column fill weights and the dgv name.
            Globals.appSettings.StateUpdateReportDGV.ColumnFillWeights = tmpArray
            Globals.appSettings.StateUpdateReportDGV.Name = dgv.Name

        ElseIf dgv.Name = Me.dgvUpdateStatus.Name Then

            'Save the sort column if the DGV is sorted.
            If dgv.SortedColumn Is Nothing AndAlso dgv.Rows.Count > 0 Then
                Globals.appSettings.StateUpdateStatusDGV.SortColumn = Nothing
                Globals.appSettings.StateUpdateStatusDGV.SortDirection = ListSortDirection.Descending
            ElseIf Not dgv.SortedColumn Is Nothing Then
                Globals.appSettings.StateUpdateStatusDGV.SortColumn = dgv.SortedColumn.Name

                'Save the sort order.
                If dgv.SortOrder = SortOrder.Ascending Then
                    Globals.appSettings.StateUpdateStatusDGV.SortDirection = ListSortDirection.Ascending
                ElseIf dgv.SortOrder = SortOrder.Descending Then
                    Globals.appSettings.StateUpdateStatusDGV.SortDirection = ListSortDirection.Descending
                End If

                'Save the column fill weights and the dgv name.
                Globals.appSettings.StateUpdateStatusDGV.ColumnFillWeights = tmpArray
                Globals.appSettings.StateUpdateReportDGV.Name = dgv.Name
            End If
        End If
    End Sub
#End Region

End Class

#Region "Backgroundworker Object Classes"
Public Class UpdateReportDetails
    Public Sub New()
    End Sub

    Public Sub New(update As IUpdate, targetGroup As IComputerTargetGroup, status As String, originalValue As String)
        m_update = update
        m_targetGroup = targetGroup
        m_status = status
        m_originalValue = originalValue
        m_data = Nothing

    End Sub

    Private m_update As IUpdate
    Public Property Update() As IUpdate
        Get
            Return m_update
        End Get
        Set(value As IUpdate)
            m_update = value
        End Set
    End Property

    Private m_targetGroup As IComputerTargetGroup
    Public Property TargetGroup() As IComputerTargetGroup
        Get
            Return m_targetGroup
        End Get
        Set(value As IComputerTargetGroup)
            m_targetGroup = value
        End Set
    End Property

    Private m_status As String
    Public Property Status() As String
        Get
            Return m_status
        End Get
        Set(value As String)
            m_status = value
        End Set
    End Property

    Private m_originalValue As String
    Public Property OriginalValue() As String
        Get
            Return m_originalValue
        End Get
        Set(value As String)
            m_originalValue = value
        End Set
    End Property

    Private m_data As DataTable
    Public Property Data() As DataTable
        Get
            Return m_data
        End Get
        Set(value As DataTable)
            m_data = value
        End Set
    End Property
End Class

Public Class ComputerReportDetails
    Public Sub New()
    End Sub

    Public Sub New(computerID As String, status As String, originalValue As String)
        m_computerID = computerID
        m_status = status
        m_originalValue = originalValue
        m_data = Nothing

    End Sub

    Private m_computerID As String
    Public Property ComputerID() As String
        Get
            Return m_computerID
        End Get
        Set(value As String)
            m_computerID = value
        End Set
    End Property

    Private m_status As String
    Public Property Status() As String
        Get
            Return m_status
        End Get
        Set(value As String)
            m_status = value
        End Set
    End Property

    Private m_originalValue As String
    Public Property OriginalValue() As String
        Get
            Return m_originalValue
        End Get
        Set(value As String)
            m_originalValue = value
        End Set
    End Property

    Private m_data As DataTable
    Public Property Data() As DataTable
        Get
            Return m_data
        End Get
        Set(value As DataTable)
            m_data = value
        End Set
    End Property
End Class


Public Class NodeDetails
    Public Sub New()
    End Sub

    Public Sub New(node As TreeNode, selectedNodePath As String)
        m_node = node
        m_selectedNodePath = selectedNodePath
    End Sub

    Private m_node As TreeNode
    Public Property Node() As TreeNode
        Get
            Return m_node
        End Get
        Set(value As TreeNode)
            m_node = value
        End Set
    End Property

    Private m_selectedNodePath As String
    Public Property SelectedNodePath() As String
        Get
            Return m_selectedNodePath
        End Get
        Set(value As String)
            m_selectedNodePath = value
        End Set
    End Property
End Class

#End Region