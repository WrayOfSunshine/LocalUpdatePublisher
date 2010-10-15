' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 10/21/2009
' Time: 2:49 PM

Partial Class MainForm
	Inherits System.Windows.Forms.Form
	
	''' <summary>
	''' Designer variable used to keep track of non-visual components.
	''' </summary>
	Private components As System.ComponentModel.IContainer
	
	''' <summary>
	''' Disposes resources used by the form.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If components IsNot Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub
	
	''' <summary>
	''' This method is required for Windows Forms designer support.
	''' Do not change the method contents inside the source code editor. The Forms designer might
	''' not be able to load this method if it was changed manually.
	''' </summary>
	Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
		Me.menuStrip = New System.Windows.Forms.MenuStrip
		Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.importCatalogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.exportCatalogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
		Me.exportListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.exportReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
		Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.toolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.createUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.importUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.exportUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
		Me.savedRulesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.manageRulesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.importRulesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.exportRulesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.certificateInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.connectionSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.optionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.updateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.helpForumsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.lupHelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.splitContainerVert = New System.Windows.Forms.SplitContainer
		Me.treeView = New System.Windows.Forms.TreeView
		Me.splitContainerHorz = New System.Windows.Forms.SplitContainer
		Me.scHeader = New System.Windows.Forms.SplitContainer
		Me.chkInheritApprovals = New System.Windows.Forms.CheckBox
		Me.chkApprovedOnly = New System.Windows.Forms.CheckBox
		Me.pnlHeaderTop = New System.Windows.Forms.Panel
		Me.lblSelectedTargetGroupCount = New System.Windows.Forms.Label
		Me.lblSelectedTargetGroup = New System.Windows.Forms.Label
		Me.lblComputerStatus = New System.Windows.Forms.Label
		Me.btnComputerListRefresh = New System.Windows.Forms.Button
		Me.cboComputerStatus = New System.Windows.Forms.ComboBox
		Me._dgvMain = New System.Windows.Forms.DataGridView
		Me.pnlComputers = New System.Windows.Forms.Panel
		Me.tabMainComputers = New System.Windows.Forms.TabControl
		Me.tabComputerInfo = New System.Windows.Forms.TabPage
		Me.txtUpdatesNeededNum = New System.Windows.Forms.TextBox
		Me.txtUpdatesInstalledorNANum = New System.Windows.Forms.TextBox
		Me.txtUpdateNoStatusNum = New System.Windows.Forms.TextBox
		Me.txtUpdatesWErrorsNum = New System.Windows.Forms.TextBox
		Me.lblUpdateNoStatus = New System.Windows.Forms.Label
		Me.lblUpdatesInstalledorNA = New System.Windows.Forms.Label
		Me.lblUpdatesNeeded = New System.Windows.Forms.Label
		Me.lblUpdatesWErrors = New System.Windows.Forms.Label
		Me.tabComputerStatus = New System.Windows.Forms.TabPage
		Me.dgvComputerGroupStatus = New System.Windows.Forms.DataGridView
		Me.tabComputerReport = New System.Windows.Forms.TabPage
		Me.btnComputerRefreshReport = New System.Windows.Forms.Button
		Me.dgvComputerReport = New System.Windows.Forms.DataGridView
		Me.lblComputerUpdateStatus = New System.Windows.Forms.Label
		Me.pnlUpdates = New System.Windows.Forms.Panel
		Me.tabMainUpdates = New System.Windows.Forms.TabControl
		Me.tabUpdateInfo = New System.Windows.Forms.TabPage
		Me.txtPackageType = New System.Windows.Forms.TextBox
		Me.lblPackageType = New System.Windows.Forms.Label
		Me.lblPrerequisites = New System.Windows.Forms.Label
		Me.lblSupersedes = New System.Windows.Forms.Label
		Me.lblReturnCodes = New System.Windows.Forms.Label
		Me.lblUninstall = New System.Windows.Forms.Label
		Me.txtUninstall = New System.Windows.Forms.TextBox
		Me.txtImpact = New System.Windows.Forms.TextBox
		Me.txtPackage = New System.Windows.Forms.TextBox
		Me.lblID = New System.Windows.Forms.Label
		Me.txtProduct = New System.Windows.Forms.TextBox
		Me.txtDescription = New System.Windows.Forms.TextBox
		Me.lblImpact = New System.Windows.Forms.Label
		Me.txtPackageTitle = New System.Windows.Forms.TextBox
		Me.txtVendor = New System.Windows.Forms.TextBox
		Me.lblDescription = New System.Windows.Forms.Label
		Me.lblRebootBehavior = New System.Windows.Forms.Label
		Me.lblPackageTitle = New System.Windows.Forms.Label
		Me.txtClassification = New System.Windows.Forms.TextBox
		Me.txtRebootBehavior = New System.Windows.Forms.TextBox
		Me.txtServerity = New System.Windows.Forms.TextBox
		Me.txtArticleID = New System.Windows.Forms.TextBox
		Me.txtBulletinID = New System.Windows.Forms.TextBox
		Me.lblMoreInfoURL = New System.Windows.Forms.Label
		Me.txtCVEID = New System.Windows.Forms.TextBox
		Me.lblArticleID = New System.Windows.Forms.Label
		Me.txtMoreInfoURL = New System.Windows.Forms.TextBox
		Me.lblProduct = New System.Windows.Forms.Label
		Me.lblCVEID = New System.Windows.Forms.Label
		Me.lblVendor = New System.Windows.Forms.Label
		Me.lblSeverity = New System.Windows.Forms.Label
		Me.lblBullitinID = New System.Windows.Forms.Label
		Me.lblClassification = New System.Windows.Forms.Label
		Me.tabUpdateStatus = New System.Windows.Forms.TabPage
		Me.dgvUpdateStatus = New System.Windows.Forms.DataGridView
		Me.tabUpdateReport = New System.Windows.Forms.TabPage
		Me.btnUpdateRefreshReport = New System.Windows.Forms.Button
		Me.dgvUpdateReport = New System.Windows.Forms.DataGridView
		Me.lblUpdateStatus = New System.Windows.Forms.Label
		Me.lblComputerGroup = New System.Windows.Forms.Label
		Me.cboUpdateStatus = New System.Windows.Forms.ComboBox
		Me.cboTargetGroup = New System.Windows.Forms.ComboBox
		Me.cmDgvMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.statusStrip = New System.Windows.Forms.StatusStrip
		Me.toolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
		Me.toolStripStatusLabelLink = New System.Windows.Forms.ToolStripStatusLabel
		Me.importFileDialog = New System.Windows.Forms.OpenFileDialog
		Me.exportFileDialog = New System.Windows.Forms.SaveFileDialog
		Me.menuStrip.SuspendLayout
		Me.splitContainerVert.Panel1.SuspendLayout
		Me.splitContainerVert.Panel2.SuspendLayout
		Me.splitContainerVert.SuspendLayout
		Me.splitContainerHorz.Panel1.SuspendLayout
		Me.splitContainerHorz.Panel2.SuspendLayout
		Me.splitContainerHorz.SuspendLayout
		Me.scHeader.Panel1.SuspendLayout
		Me.scHeader.Panel2.SuspendLayout
		Me.scHeader.SuspendLayout
		Me.pnlHeaderTop.SuspendLayout
		CType(Me._dgvMain,System.ComponentModel.ISupportInitialize).BeginInit
		Me.pnlComputers.SuspendLayout
		Me.tabMainComputers.SuspendLayout
		Me.tabComputerInfo.SuspendLayout
		Me.tabComputerStatus.SuspendLayout
		CType(Me.dgvComputerGroupStatus,System.ComponentModel.ISupportInitialize).BeginInit
		Me.tabComputerReport.SuspendLayout
		CType(Me.dgvComputerReport,System.ComponentModel.ISupportInitialize).BeginInit
		Me.pnlUpdates.SuspendLayout
		Me.tabMainUpdates.SuspendLayout
		Me.tabUpdateInfo.SuspendLayout
		Me.tabUpdateStatus.SuspendLayout
		CType(Me.dgvUpdateStatus,System.ComponentModel.ISupportInitialize).BeginInit
		Me.tabUpdateReport.SuspendLayout
		CType(Me.dgvUpdateReport,System.ComponentModel.ISupportInitialize).BeginInit
		Me.statusStrip.SuspendLayout
		Me.SuspendLayout
		'
		'menuStrip
		'
		Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.toolsToolStripMenuItem, Me.updateToolStripMenuItem, Me.helpToolStripMenuItem})
		Me.menuStrip.Location = New System.Drawing.Point(0, 0)
		Me.menuStrip.Name = "menuStrip"
		Me.menuStrip.Size = New System.Drawing.Size(858, 24)
		Me.menuStrip.TabIndex = 0
		Me.menuStrip.Text = "menuStrip"
		'
		'fileToolStripMenuItem
		'
		Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.importCatalogToolStripMenuItem, Me.exportCatalogToolStripMenuItem, Me.toolStripSeparator3, Me.exportListToolStripMenuItem, Me.exportReportToolStripMenuItem, Me.toolStripSeparator2, Me.exitToolStripMenuItem})
		Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
		Me.fileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
		Me.fileToolStripMenuItem.Text = "File"
		'
		'importCatalogToolStripMenuItem
		'
		Me.importCatalogToolStripMenuItem.Name = "importCatalogToolStripMenuItem"
		Me.importCatalogToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
		Me.importCatalogToolStripMenuItem.Text = "Import Catalog"
		AddHandler Me.importCatalogToolStripMenuItem.Click, AddressOf Me.ImportCatalogToolStripMenuItemClick
		'
		'exportCatalogToolStripMenuItem
		'
		Me.exportCatalogToolStripMenuItem.Name = "exportCatalogToolStripMenuItem"
		Me.exportCatalogToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
		Me.exportCatalogToolStripMenuItem.Text = "Export Catalog"
		AddHandler Me.exportCatalogToolStripMenuItem.Click, AddressOf Me.ExportCatalogToolStripMenuItemClick
		'
		'toolStripSeparator3
		'
		Me.toolStripSeparator3.Name = "toolStripSeparator3"
		Me.toolStripSeparator3.Size = New System.Drawing.Size(154, 6)
		'
		'exportListToolStripMenuItem
		'
		Me.exportListToolStripMenuItem.Enabled = false
		Me.exportListToolStripMenuItem.Name = "exportListToolStripMenuItem"
		Me.exportListToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
		Me.exportListToolStripMenuItem.Text = "Export List"
		Me.exportListToolStripMenuItem.Visible = false
		AddHandler Me.exportListToolStripMenuItem.Click, AddressOf Me.ExportListToolStripMenuItemClick
		'
		'exportReportToolStripMenuItem
		'
		Me.exportReportToolStripMenuItem.Enabled = false
		Me.exportReportToolStripMenuItem.Name = "exportReportToolStripMenuItem"
		Me.exportReportToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
		Me.exportReportToolStripMenuItem.Text = "Export Report"
		Me.exportReportToolStripMenuItem.Visible = false
		AddHandler Me.exportReportToolStripMenuItem.Click, AddressOf Me.ExportReportToolStripMenuItemClick
		'
		'toolStripSeparator2
		'
		Me.toolStripSeparator2.Name = "toolStripSeparator2"
		Me.toolStripSeparator2.Size = New System.Drawing.Size(154, 6)
		'
		'exitToolStripMenuItem
		'
		Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
		Me.exitToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
		Me.exitToolStripMenuItem.Text = "Exit"
		AddHandler Me.exitToolStripMenuItem.Click, AddressOf Me.ExitToolStripMenuItemClick
		'
		'toolsToolStripMenuItem
		'
		Me.toolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.createUpdateToolStripMenuItem, Me.importUpdateToolStripMenuItem, Me.exportUpdateToolStripMenuItem, Me.toolStripSeparator1, Me.savedRulesToolStripMenuItem, Me.certificateInfoToolStripMenuItem, Me.connectionSettingsToolStripMenuItem, Me.optionsToolStripMenuItem})
		Me.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem"
		Me.toolsToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
		Me.toolsToolStripMenuItem.Text = "Tools"
		'
		'createUpdateToolStripMenuItem
		'
		Me.createUpdateToolStripMenuItem.Name = "createUpdateToolStripMenuItem"
		Me.createUpdateToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
		Me.createUpdateToolStripMenuItem.Text = "Create Update"
		AddHandler Me.createUpdateToolStripMenuItem.Click, AddressOf Me.CreateUpdateToolStripMenuItemClick
		'
		'importUpdateToolStripMenuItem
		'
		Me.importUpdateToolStripMenuItem.Name = "importUpdateToolStripMenuItem"
		Me.importUpdateToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
		Me.importUpdateToolStripMenuItem.Text = "Import Update"
		AddHandler Me.importUpdateToolStripMenuItem.Click, AddressOf Me.ImportUpdateToolStripMenuItemClick
		'
		'exportUpdateToolStripMenuItem
		'
		Me.exportUpdateToolStripMenuItem.Name = "exportUpdateToolStripMenuItem"
		Me.exportUpdateToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
		Me.exportUpdateToolStripMenuItem.Text = "Export Update"
		AddHandler Me.exportUpdateToolStripMenuItem.Click, AddressOf Me.ExportUpdateToolStripMenuItemClick
		'
		'toolStripSeparator1
		'
		Me.toolStripSeparator1.Name = "toolStripSeparator1"
		Me.toolStripSeparator1.Size = New System.Drawing.Size(178, 6)
		'
		'savedRulesToolStripMenuItem
		'
		Me.savedRulesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.manageRulesToolStripMenuItem, Me.importRulesToolStripMenuItem, Me.exportRulesToolStripMenuItem})
		Me.savedRulesToolStripMenuItem.Name = "savedRulesToolStripMenuItem"
		Me.savedRulesToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
		Me.savedRulesToolStripMenuItem.Text = "Saved Rules"
		'
		'manageRulesToolStripMenuItem
		'
		Me.manageRulesToolStripMenuItem.Name = "manageRulesToolStripMenuItem"
		Me.manageRulesToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
		Me.manageRulesToolStripMenuItem.Text = "Manage Rules"
		AddHandler Me.manageRulesToolStripMenuItem.Click, AddressOf Me.ManageRulesToolStripMenuItemClick
		'
		'importRulesToolStripMenuItem
		'
		Me.importRulesToolStripMenuItem.Name = "importRulesToolStripMenuItem"
		Me.importRulesToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
		Me.importRulesToolStripMenuItem.Text = "Import Rules"
		AddHandler Me.importRulesToolStripMenuItem.Click, AddressOf Me.ImportRulesToolStripMenuItemClick
		'
		'exportRulesToolStripMenuItem
		'
		Me.exportRulesToolStripMenuItem.Name = "exportRulesToolStripMenuItem"
		Me.exportRulesToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
		Me.exportRulesToolStripMenuItem.Text = "Export Rules"
		AddHandler Me.exportRulesToolStripMenuItem.Click, AddressOf Me.ExportRulesToolStripMenuItemClick
		'
		'certificateInfoToolStripMenuItem
		'
		Me.certificateInfoToolStripMenuItem.Name = "certificateInfoToolStripMenuItem"
		Me.certificateInfoToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
		Me.certificateInfoToolStripMenuItem.Text = "Certificate Info"
		AddHandler Me.certificateInfoToolStripMenuItem.Click, AddressOf Me.CertificateInfoToolStripMenuItemClick
		'
		'connectionSettingsToolStripMenuItem
		'
		Me.connectionSettingsToolStripMenuItem.Name = "connectionSettingsToolStripMenuItem"
		Me.connectionSettingsToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
		Me.connectionSettingsToolStripMenuItem.Text = "Connection Settings"
		AddHandler Me.connectionSettingsToolStripMenuItem.Click, AddressOf Me.ConnectionSettingsToolStripMenuItemClick
		'
		'optionsToolStripMenuItem
		'
		Me.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem"
		Me.optionsToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
		Me.optionsToolStripMenuItem.Text = "Options"
		AddHandler Me.optionsToolStripMenuItem.Click, AddressOf Me.OptionsToolStripMenuItemClick
		'
		'updateToolStripMenuItem
		'
		Me.updateToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Replace
		Me.updateToolStripMenuItem.Name = "updateToolStripMenuItem"
		Me.updateToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
		Me.updateToolStripMenuItem.Text = "Update"
		Me.updateToolStripMenuItem.Visible = false
		'
		'helpToolStripMenuItem
		'
		Me.helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.aboutToolStripMenuItem, Me.helpForumsToolStripMenuItem, Me.lupHelpToolStripMenuItem})
		Me.helpToolStripMenuItem.Name = "helpToolStripMenuItem"
		Me.helpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
		Me.helpToolStripMenuItem.Text = "Help"
		'
		'aboutToolStripMenuItem
		'
		Me.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem"
		Me.aboutToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
		Me.aboutToolStripMenuItem.Text = "About"
		AddHandler Me.aboutToolStripMenuItem.Click, AddressOf Me.AboutToolStripMenuItemClick
		'
		'helpForumsToolStripMenuItem
		'
		Me.helpForumsToolStripMenuItem.Name = "helpForumsToolStripMenuItem"
		Me.helpForumsToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
		Me.helpForumsToolStripMenuItem.Text = "Help Forum"
		AddHandler Me.helpForumsToolStripMenuItem.Click, AddressOf Me.HelpForumsToolStripMenuItemClick
		'
		'lupHelpToolStripMenuItem
		'
		Me.lupHelpToolStripMenuItem.Name = "lupHelpToolStripMenuItem"
		Me.lupHelpToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
		Me.lupHelpToolStripMenuItem.Text = "Support Wiki"
		AddHandler Me.lupHelpToolStripMenuItem.Click, AddressOf Me.LupHelpToolStripMenuItemClick
		'
		'splitContainerVert
		'
		Me.splitContainerVert.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
						Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.splitContainerVert.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
		Me.splitContainerVert.Location = New System.Drawing.Point(0, 27)
		Me.splitContainerVert.Name = "splitContainerVert"
		'
		'splitContainerVert.Panel1
		'
		Me.splitContainerVert.Panel1.Controls.Add(Me.treeView)
		'
		'splitContainerVert.Panel2
		'
		Me.splitContainerVert.Panel2.Controls.Add(Me.splitContainerHorz)
		Me.splitContainerVert.Size = New System.Drawing.Size(858, 629)
		Me.splitContainerVert.SplitterDistance = 175
		Me.splitContainerVert.TabIndex = 1
		AddHandler Me.splitContainerVert.SplitterMoved, AddressOf Me.SplitContainerVertSplitterMoved
		'
		'treeView
		'
		Me.treeView.Dock = System.Windows.Forms.DockStyle.Fill
		Me.treeView.HideSelection = false
		Me.treeView.Location = New System.Drawing.Point(0, 0)
		Me.treeView.Name = "treeView"
		Me.treeView.Size = New System.Drawing.Size(175, 629)
		Me.treeView.TabIndex = 0
		AddHandler Me.treeView.AfterSelect, AddressOf Me.TreeViewAfterSelect
		AddHandler Me.treeView.BeforeSelect, AddressOf Me.TreeViewBeforeSelect
		'
		'splitContainerHorz
		'
		Me.splitContainerHorz.Dock = System.Windows.Forms.DockStyle.Fill
		Me.splitContainerHorz.Location = New System.Drawing.Point(0, 0)
		Me.splitContainerHorz.Name = "splitContainerHorz"
		Me.splitContainerHorz.Orientation = System.Windows.Forms.Orientation.Horizontal
		'
		'splitContainerHorz.Panel1
		'
		Me.splitContainerHorz.Panel1.Controls.Add(Me.scHeader)
		'
		'splitContainerHorz.Panel2
		'
		Me.splitContainerHorz.Panel2.Controls.Add(Me.pnlUpdates)
		Me.splitContainerHorz.Panel2.Controls.Add(Me.pnlComputers)
		Me.splitContainerHorz.Size = New System.Drawing.Size(679, 629)
		Me.splitContainerHorz.SplitterDistance = 147
		Me.splitContainerHorz.TabIndex = 1
		AddHandler Me.splitContainerHorz.SplitterMoved, AddressOf Me.SplitContainerSplitterMoved
		'
		'scHeader
		'
		Me.scHeader.Dock = System.Windows.Forms.DockStyle.Fill
		Me.scHeader.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
		Me.scHeader.IsSplitterFixed = true
		Me.scHeader.Location = New System.Drawing.Point(0, 0)
		Me.scHeader.Name = "scHeader"
		Me.scHeader.Orientation = System.Windows.Forms.Orientation.Horizontal
		'
		'scHeader.Panel1
		'
		Me.scHeader.Panel1.Controls.Add(Me.chkInheritApprovals)
		Me.scHeader.Panel1.Controls.Add(Me.chkApprovedOnly)
		Me.scHeader.Panel1.Controls.Add(Me.pnlHeaderTop)
		Me.scHeader.Panel1.Controls.Add(Me.lblComputerStatus)
		Me.scHeader.Panel1.Controls.Add(Me.btnComputerListRefresh)
		Me.scHeader.Panel1.Controls.Add(Me.cboComputerStatus)
		'
		'scHeader.Panel2
		'
		Me.scHeader.Panel2.Controls.Add(Me._dgvMain)
		Me.scHeader.Size = New System.Drawing.Size(679, 147)
		Me.scHeader.TabIndex = 1
		'
		'chkInheritApprovals
		'
		Me.chkInheritApprovals.Location = New System.Drawing.Point(530, 25)
		Me.chkInheritApprovals.Name = "chkInheritApprovals"
		Me.chkInheritApprovals.Size = New System.Drawing.Size(134, 24)
		Me.chkInheritApprovals.TabIndex = 11
		Me.chkInheritApprovals.Text = "Inherit Approvals"
		Me.chkInheritApprovals.UseVisualStyleBackColor = true
		AddHandler Me.chkInheritApprovals.CheckedChanged, AddressOf Me.ChkInheritApprovalsCheckedChanged
		'
		'chkApprovedOnly
		'
		Me.chkApprovedOnly.Location = New System.Drawing.Point(380, 27)
		Me.chkApprovedOnly.Name = "chkApprovedOnly"
		Me.chkApprovedOnly.Size = New System.Drawing.Size(145, 21)
		Me.chkApprovedOnly.TabIndex = 10
		Me.chkApprovedOnly.Text = "Approved Updates Only"
		Me.chkApprovedOnly.UseVisualStyleBackColor = true
		AddHandler Me.chkApprovedOnly.CheckedChanged, AddressOf Me.ChkApprovedOnlyCheckedChanged
		'
		'pnlHeaderTop
		'
		Me.pnlHeaderTop.BackColor = System.Drawing.SystemColors.ControlDark
		Me.pnlHeaderTop.Controls.Add(Me.lblSelectedTargetGroupCount)
		Me.pnlHeaderTop.Controls.Add(Me.lblSelectedTargetGroup)
		Me.pnlHeaderTop.Dock = System.Windows.Forms.DockStyle.Top
		Me.pnlHeaderTop.Location = New System.Drawing.Point(0, 0)
		Me.pnlHeaderTop.Name = "pnlHeaderTop"
		Me.pnlHeaderTop.Size = New System.Drawing.Size(679, 25)
		Me.pnlHeaderTop.TabIndex = 9
		'
		'lblSelectedTargetGroupCount
		'
		Me.lblSelectedTargetGroupCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 11!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblSelectedTargetGroupCount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
		Me.lblSelectedTargetGroupCount.Location = New System.Drawing.Point(241, 0)
		Me.lblSelectedTargetGroupCount.Name = "lblSelectedTargetGroupCount"
		Me.lblSelectedTargetGroupCount.Size = New System.Drawing.Size(197, 24)
		Me.lblSelectedTargetGroupCount.TabIndex = 10
		Me.lblSelectedTargetGroupCount.Text = "(# of computers shown)"
		Me.lblSelectedTargetGroupCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblSelectedTargetGroup
		'
		Me.lblSelectedTargetGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblSelectedTargetGroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
		Me.lblSelectedTargetGroup.Location = New System.Drawing.Point(0, 1)
		Me.lblSelectedTargetGroup.Name = "lblSelectedTargetGroup"
		Me.lblSelectedTargetGroup.Size = New System.Drawing.Size(197, 24)
		Me.lblSelectedTargetGroup.TabIndex = 9
		Me.lblSelectedTargetGroup.Text = "Selected Target Group"
		Me.lblSelectedTargetGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblComputerStatus
		'
		Me.lblComputerStatus.Location = New System.Drawing.Point(4, 31)
		Me.lblComputerStatus.Name = "lblComputerStatus"
		Me.lblComputerStatus.Size = New System.Drawing.Size(37, 15)
		Me.lblComputerStatus.TabIndex = 8
		Me.lblComputerStatus.Text = "Status"
		'
		'btnComputerListRefresh
		'
		Me.btnComputerListRefresh.Enabled = false
		Me.btnComputerListRefresh.Location = New System.Drawing.Point(291, 25)
		Me.btnComputerListRefresh.Name = "btnComputerListRefresh"
		Me.btnComputerListRefresh.Size = New System.Drawing.Size(75, 23)
		Me.btnComputerListRefresh.TabIndex = 7
		Me.btnComputerListRefresh.Text = "Refresh"
		Me.btnComputerListRefresh.UseVisualStyleBackColor = true
		AddHandler Me.btnComputerListRefresh.Click, AddressOf Me.BtnComputerListRefreshClick
		'
		'cboComputerStatus
		'
		Me.cboComputerStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboComputerStatus.FormattingEnabled = true
		Me.cboComputerStatus.Items.AddRange(New Object() {"Failed or Needed", "Installed/Not Applicable or No Status", "Failed", "Needed", "Installed/Not Applicable", "No Status", "Any"})
		Me.cboComputerStatus.Location = New System.Drawing.Point(47, 27)
		Me.cboComputerStatus.Name = "cboComputerStatus"
		Me.cboComputerStatus.Size = New System.Drawing.Size(233, 21)
		Me.cboComputerStatus.TabIndex = 6
		AddHandler Me.cboComputerStatus.SelectedIndexChanged, AddressOf Me.CboComputerStatusSelectedIndexChanged
		'
		'_dgvMain
		'
		Me._dgvMain.AllowUserToAddRows = false
		Me._dgvMain.AllowUserToDeleteRows = false
		Me._dgvMain.AllowUserToOrderColumns = true
		Me._dgvMain.AllowUserToResizeRows = false
		Me._dgvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me._dgvMain.BackgroundColor = System.Drawing.SystemColors.Window
		Me._dgvMain.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._dgvMain.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
		Me._dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me._dgvMain.Dock = System.Windows.Forms.DockStyle.Fill
		Me._dgvMain.Location = New System.Drawing.Point(0, 0)
		Me._dgvMain.Name = "_dgvMain"
		Me._dgvMain.ReadOnly = true
		Me._dgvMain.RowHeadersVisible = false
		Me._dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me._dgvMain.Size = New System.Drawing.Size(679, 93)
		Me._dgvMain.TabIndex = 0
		AddHandler Me._dgvMain.Sorted, AddressOf Me.DgvMainSorted
		AddHandler Me._dgvMain.RowEnter, AddressOf Me.dgvMainRowEnter
		AddHandler Me._dgvMain.CellMouseDown, AddressOf Me.dgvMainCellMouseDown
		AddHandler Me._dgvMain.Leave, AddressOf Me.dgvMainLeave
		AddHandler Me._dgvMain.KeyUp, AddressOf Me.dgvMainKeyUp
		'
		'pnlComputers
		'
		Me.pnlComputers.Controls.Add(Me.tabMainComputers)
		Me.pnlComputers.Dock = System.Windows.Forms.DockStyle.Fill
		Me.pnlComputers.Location = New System.Drawing.Point(0, 0)
		Me.pnlComputers.Name = "pnlComputers"
		Me.pnlComputers.Size = New System.Drawing.Size(679, 478)
		Me.pnlComputers.TabIndex = 60
		Me.pnlComputers.Visible = false
		'
		'tabMainComputers
		'
		Me.tabMainComputers.Controls.Add(Me.tabComputerInfo)
		Me.tabMainComputers.Controls.Add(Me.tabComputerStatus)
		Me.tabMainComputers.Controls.Add(Me.tabComputerReport)
		Me.tabMainComputers.Dock = System.Windows.Forms.DockStyle.Fill
		Me.tabMainComputers.Location = New System.Drawing.Point(0, 0)
		Me.tabMainComputers.Name = "tabMainComputers"
		Me.tabMainComputers.SelectedIndex = 0
		Me.tabMainComputers.Size = New System.Drawing.Size(679, 478)
		Me.tabMainComputers.TabIndex = 0
		'
		'tabComputerInfo
		'
		Me.tabComputerInfo.BackColor = System.Drawing.Color.Transparent
		Me.tabComputerInfo.Controls.Add(Me.txtUpdatesNeededNum)
		Me.tabComputerInfo.Controls.Add(Me.txtUpdatesInstalledorNANum)
		Me.tabComputerInfo.Controls.Add(Me.txtUpdateNoStatusNum)
		Me.tabComputerInfo.Controls.Add(Me.txtUpdatesWErrorsNum)
		Me.tabComputerInfo.Controls.Add(Me.lblUpdateNoStatus)
		Me.tabComputerInfo.Controls.Add(Me.lblUpdatesInstalledorNA)
		Me.tabComputerInfo.Controls.Add(Me.lblUpdatesNeeded)
		Me.tabComputerInfo.Controls.Add(Me.lblUpdatesWErrors)
		Me.tabComputerInfo.Location = New System.Drawing.Point(4, 22)
		Me.tabComputerInfo.Name = "tabComputerInfo"
		Me.tabComputerInfo.Padding = New System.Windows.Forms.Padding(3)
		Me.tabComputerInfo.Size = New System.Drawing.Size(671, 452)
		Me.tabComputerInfo.TabIndex = 0
		Me.tabComputerInfo.Text = "Info"
		'
		'txtUpdatesNeededNum
		'
		Me.txtUpdatesNeededNum.BackColor = System.Drawing.SystemColors.Control
		Me.txtUpdatesNeededNum.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.txtUpdatesNeededNum.Location = New System.Drawing.Point(176, 30)
		Me.txtUpdatesNeededNum.Name = "txtUpdatesNeededNum"
		Me.txtUpdatesNeededNum.ReadOnly = true
		Me.txtUpdatesNeededNum.Size = New System.Drawing.Size(100, 13)
		Me.txtUpdatesNeededNum.TabIndex = 15
		Me.txtUpdatesNeededNum.Text = "##"
		'
		'txtUpdatesInstalledorNANum
		'
		Me.txtUpdatesInstalledorNANum.BackColor = System.Drawing.SystemColors.Control
		Me.txtUpdatesInstalledorNANum.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.txtUpdatesInstalledorNANum.Location = New System.Drawing.Point(176, 51)
		Me.txtUpdatesInstalledorNANum.Name = "txtUpdatesInstalledorNANum"
		Me.txtUpdatesInstalledorNANum.ReadOnly = true
		Me.txtUpdatesInstalledorNANum.Size = New System.Drawing.Size(100, 13)
		Me.txtUpdatesInstalledorNANum.TabIndex = 14
		Me.txtUpdatesInstalledorNANum.Text = "##"
		'
		'txtUpdateNoStatusNum
		'
		Me.txtUpdateNoStatusNum.BackColor = System.Drawing.SystemColors.Control
		Me.txtUpdateNoStatusNum.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.txtUpdateNoStatusNum.Location = New System.Drawing.Point(176, 72)
		Me.txtUpdateNoStatusNum.Name = "txtUpdateNoStatusNum"
		Me.txtUpdateNoStatusNum.ReadOnly = true
		Me.txtUpdateNoStatusNum.Size = New System.Drawing.Size(100, 13)
		Me.txtUpdateNoStatusNum.TabIndex = 13
		Me.txtUpdateNoStatusNum.Text = "##"
		'
		'txtUpdatesWErrorsNum
		'
		Me.txtUpdatesWErrorsNum.BackColor = System.Drawing.SystemColors.Control
		Me.txtUpdatesWErrorsNum.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.txtUpdatesWErrorsNum.Location = New System.Drawing.Point(176, 9)
		Me.txtUpdatesWErrorsNum.Name = "txtUpdatesWErrorsNum"
		Me.txtUpdatesWErrorsNum.ReadOnly = true
		Me.txtUpdatesWErrorsNum.Size = New System.Drawing.Size(100, 13)
		Me.txtUpdatesWErrorsNum.TabIndex = 12
		Me.txtUpdatesWErrorsNum.Text = "##"
		'
		'lblUpdateNoStatus
		'
		Me.lblUpdateNoStatus.Location = New System.Drawing.Point(6, 75)
		Me.lblUpdateNoStatus.Name = "lblUpdateNoStatus"
		Me.lblUpdateNoStatus.Size = New System.Drawing.Size(138, 18)
		Me.lblUpdateNoStatus.TabIndex = 3
		Me.lblUpdateNoStatus.Text = "Updates with no status:"
		'
		'lblUpdatesInstalledorNA
		'
		Me.lblUpdatesInstalledorNA.Location = New System.Drawing.Point(6, 54)
		Me.lblUpdatesInstalledorNA.Name = "lblUpdatesInstalledorNA"
		Me.lblUpdatesInstalledorNA.Size = New System.Drawing.Size(179, 18)
		Me.lblUpdatesInstalledorNA.TabIndex = 2
		Me.lblUpdatesInstalledorNA.Text = "Updates installed/not available:"
		'
		'lblUpdatesNeeded
		'
		Me.lblUpdatesNeeded.Location = New System.Drawing.Point(6, 33)
		Me.lblUpdatesNeeded.Name = "lblUpdatesNeeded"
		Me.lblUpdatesNeeded.Size = New System.Drawing.Size(138, 18)
		Me.lblUpdatesNeeded.TabIndex = 1
		Me.lblUpdatesNeeded.Text = "Updates Needed:"
		'
		'lblUpdatesWErrors
		'
		Me.lblUpdatesWErrors.Location = New System.Drawing.Point(6, 12)
		Me.lblUpdatesWErrors.Name = "lblUpdatesWErrors"
		Me.lblUpdatesWErrors.Size = New System.Drawing.Size(138, 18)
		Me.lblUpdatesWErrors.TabIndex = 0
		Me.lblUpdatesWErrors.Text = "Updates with Errors:"
		'
		'tabComputerStatus
		'
		Me.tabComputerStatus.Controls.Add(Me.dgvComputerGroupStatus)
		Me.tabComputerStatus.Location = New System.Drawing.Point(4, 22)
		Me.tabComputerStatus.Name = "tabComputerStatus"
		Me.tabComputerStatus.Padding = New System.Windows.Forms.Padding(3)
		Me.tabComputerStatus.Size = New System.Drawing.Size(671, 452)
		Me.tabComputerStatus.TabIndex = 2
		Me.tabComputerStatus.Text = "Group Status"
		Me.tabComputerStatus.UseVisualStyleBackColor = true
		'
		'dgvComputerGroupStatus
		'
		Me.dgvComputerGroupStatus.AllowUserToAddRows = false
		Me.dgvComputerGroupStatus.AllowUserToDeleteRows = false
		Me.dgvComputerGroupStatus.AllowUserToOrderColumns = true
		Me.dgvComputerGroupStatus.AllowUserToResizeRows = false
		Me.dgvComputerGroupStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.dgvComputerGroupStatus.BackgroundColor = System.Drawing.SystemColors.Window
		Me.dgvComputerGroupStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.dgvComputerGroupStatus.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
		Me.dgvComputerGroupStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvComputerGroupStatus.Dock = System.Windows.Forms.DockStyle.Fill
		Me.dgvComputerGroupStatus.Location = New System.Drawing.Point(3, 3)
		Me.dgvComputerGroupStatus.Name = "dgvComputerGroupStatus"
		Me.dgvComputerGroupStatus.ReadOnly = true
		Me.dgvComputerGroupStatus.RowHeadersVisible = false
		Me.dgvComputerGroupStatus.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
		Me.dgvComputerGroupStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvComputerGroupStatus.Size = New System.Drawing.Size(665, 446)
		Me.dgvComputerGroupStatus.TabIndex = 1
		'
		'tabComputerReport
		'
		Me.tabComputerReport.Controls.Add(Me.btnComputerRefreshReport)
		Me.tabComputerReport.Controls.Add(Me.dgvComputerReport)
		Me.tabComputerReport.Controls.Add(Me.lblComputerUpdateStatus)
		Me.tabComputerReport.Location = New System.Drawing.Point(4, 22)
		Me.tabComputerReport.Name = "tabComputerReport"
		Me.tabComputerReport.Padding = New System.Windows.Forms.Padding(3)
		Me.tabComputerReport.Size = New System.Drawing.Size(671, 452)
		Me.tabComputerReport.TabIndex = 1
		Me.tabComputerReport.Text = "Report"
		Me.tabComputerReport.UseVisualStyleBackColor = true
		'
		'btnComputerRefreshReport
		'
		Me.btnComputerRefreshReport.Enabled = false
		Me.btnComputerRefreshReport.Location = New System.Drawing.Point(299, 34)
		Me.btnComputerRefreshReport.Name = "btnComputerRefreshReport"
		Me.btnComputerRefreshReport.Size = New System.Drawing.Size(75, 23)
		Me.btnComputerRefreshReport.TabIndex = 6
		Me.btnComputerRefreshReport.Text = "Refresh"
		Me.btnComputerRefreshReport.UseVisualStyleBackColor = true
		AddHandler Me.btnComputerRefreshReport.Click, AddressOf Me.BtnComputerRefreshReportClick
		'
		'dgvComputerReport
		'
		Me.dgvComputerReport.AllowUserToAddRows = false
		Me.dgvComputerReport.AllowUserToDeleteRows = false
		Me.dgvComputerReport.AllowUserToOrderColumns = true
		Me.dgvComputerReport.AllowUserToResizeRows = false
		Me.dgvComputerReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
						Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.dgvComputerReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.dgvComputerReport.BackgroundColor = System.Drawing.SystemColors.Window
		Me.dgvComputerReport.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.dgvComputerReport.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
		Me.dgvComputerReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvComputerReport.Location = New System.Drawing.Point(7, 63)
		Me.dgvComputerReport.Name = "dgvComputerReport"
		Me.dgvComputerReport.ReadOnly = true
		Me.dgvComputerReport.RowHeadersVisible = false
		Me.dgvComputerReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvComputerReport.Size = New System.Drawing.Size(657, 384)
		Me.dgvComputerReport.TabIndex = 5
		AddHandler Me.dgvComputerReport.Sorted, AddressOf Me.DgvComputerReportSorted
		AddHandler Me.dgvComputerReport.CellMouseDown, AddressOf Me.DgvComputerReportCellMouseDown
		'
		'lblComputerUpdateStatus
		'
		Me.lblComputerUpdateStatus.Location = New System.Drawing.Point(50, 17)
		Me.lblComputerUpdateStatus.Name = "lblComputerUpdateStatus"
		Me.lblComputerUpdateStatus.Size = New System.Drawing.Size(100, 15)
		Me.lblComputerUpdateStatus.TabIndex = 4
		Me.lblComputerUpdateStatus.Text = "Update Status"
		'
		'pnlUpdates
		'
		Me.pnlUpdates.Controls.Add(Me.tabMainUpdates)
		Me.pnlUpdates.Dock = System.Windows.Forms.DockStyle.Fill
		Me.pnlUpdates.Location = New System.Drawing.Point(0, 0)
		Me.pnlUpdates.Name = "pnlUpdates"
		Me.pnlUpdates.Size = New System.Drawing.Size(679, 478)
		Me.pnlUpdates.TabIndex = 0
		Me.pnlUpdates.Visible = false
		'
		'tabMainUpdates
		'
		Me.tabMainUpdates.Controls.Add(Me.tabUpdateInfo)
		Me.tabMainUpdates.Controls.Add(Me.tabUpdateStatus)
		Me.tabMainUpdates.Controls.Add(Me.tabUpdateReport)
		Me.tabMainUpdates.Dock = System.Windows.Forms.DockStyle.Fill
		Me.tabMainUpdates.Location = New System.Drawing.Point(0, 0)
		Me.tabMainUpdates.Name = "tabMainUpdates"
		Me.tabMainUpdates.SelectedIndex = 0
		Me.tabMainUpdates.Size = New System.Drawing.Size(679, 478)
		Me.tabMainUpdates.TabIndex = 61
		'
		'tabUpdateInfo
		'
		Me.tabUpdateInfo.Controls.Add(Me.txtPackageType)
		Me.tabUpdateInfo.Controls.Add(Me.lblPackageType)
		Me.tabUpdateInfo.Controls.Add(Me.lblPrerequisites)
		Me.tabUpdateInfo.Controls.Add(Me.lblSupersedes)
		Me.tabUpdateInfo.Controls.Add(Me.lblReturnCodes)
		Me.tabUpdateInfo.Controls.Add(Me.lblUninstall)
		Me.tabUpdateInfo.Controls.Add(Me.txtUninstall)
		Me.tabUpdateInfo.Controls.Add(Me.txtImpact)
		Me.tabUpdateInfo.Controls.Add(Me.txtPackage)
		Me.tabUpdateInfo.Controls.Add(Me.lblID)
		Me.tabUpdateInfo.Controls.Add(Me.txtProduct)
		Me.tabUpdateInfo.Controls.Add(Me.txtDescription)
		Me.tabUpdateInfo.Controls.Add(Me.lblImpact)
		Me.tabUpdateInfo.Controls.Add(Me.txtPackageTitle)
		Me.tabUpdateInfo.Controls.Add(Me.txtVendor)
		Me.tabUpdateInfo.Controls.Add(Me.lblDescription)
		Me.tabUpdateInfo.Controls.Add(Me.lblRebootBehavior)
		Me.tabUpdateInfo.Controls.Add(Me.lblPackageTitle)
		Me.tabUpdateInfo.Controls.Add(Me.txtClassification)
		Me.tabUpdateInfo.Controls.Add(Me.txtRebootBehavior)
		Me.tabUpdateInfo.Controls.Add(Me.txtServerity)
		Me.tabUpdateInfo.Controls.Add(Me.txtArticleID)
		Me.tabUpdateInfo.Controls.Add(Me.txtBulletinID)
		Me.tabUpdateInfo.Controls.Add(Me.lblMoreInfoURL)
		Me.tabUpdateInfo.Controls.Add(Me.txtCVEID)
		Me.tabUpdateInfo.Controls.Add(Me.lblArticleID)
		Me.tabUpdateInfo.Controls.Add(Me.txtMoreInfoURL)
		Me.tabUpdateInfo.Controls.Add(Me.lblProduct)
		Me.tabUpdateInfo.Controls.Add(Me.lblCVEID)
		Me.tabUpdateInfo.Controls.Add(Me.lblVendor)
		Me.tabUpdateInfo.Controls.Add(Me.lblSeverity)
		Me.tabUpdateInfo.Controls.Add(Me.lblBullitinID)
		Me.tabUpdateInfo.Controls.Add(Me.lblClassification)
		Me.tabUpdateInfo.Location = New System.Drawing.Point(4, 22)
		Me.tabUpdateInfo.Name = "tabUpdateInfo"
		Me.tabUpdateInfo.Padding = New System.Windows.Forms.Padding(3)
		Me.tabUpdateInfo.Size = New System.Drawing.Size(671, 452)
		Me.tabUpdateInfo.TabIndex = 0
		Me.tabUpdateInfo.Text = "Info"
		Me.tabUpdateInfo.UseVisualStyleBackColor = true
		'
		'txtPackageType
		'
		Me.txtPackageType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.txtPackageType.Location = New System.Drawing.Point(129, 7)
		Me.txtPackageType.Name = "txtPackageType"
		Me.txtPackageType.ReadOnly = true
		Me.txtPackageType.Size = New System.Drawing.Size(522, 20)
		Me.txtPackageType.TabIndex = 66
		'
		'lblPackageType
		'
		Me.lblPackageType.Location = New System.Drawing.Point(41, 7)
		Me.lblPackageType.Name = "lblPackageType"
		Me.lblPackageType.Size = New System.Drawing.Size(80, 17)
		Me.lblPackageType.TabIndex = 65
		Me.lblPackageType.Text = "Package Type"
		'
		'lblPrerequisites
		'
		Me.lblPrerequisites.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.lblPrerequisites.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblPrerequisites.ForeColor = System.Drawing.SystemColors.ActiveCaption
		Me.lblPrerequisites.Location = New System.Drawing.Point(482, 337)
		Me.lblPrerequisites.Name = "lblPrerequisites"
		Me.lblPrerequisites.Size = New System.Drawing.Size(113, 17)
		Me.lblPrerequisites.TabIndex = 64
		Me.lblPrerequisites.Text = "Prerequisites"
		Me.lblPrerequisites.Visible = false
		AddHandler Me.lblPrerequisites.Click, AddressOf Me.LblPrerequisitesClick
		'
		'lblSupersedes
		'
		Me.lblSupersedes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.lblSupersedes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblSupersedes.ForeColor = System.Drawing.SystemColors.ActiveCaption
		Me.lblSupersedes.Location = New System.Drawing.Point(482, 363)
		Me.lblSupersedes.Name = "lblSupersedes"
		Me.lblSupersedes.Size = New System.Drawing.Size(113, 17)
		Me.lblSupersedes.TabIndex = 63
		Me.lblSupersedes.Text = "Supersedes"
		Me.lblSupersedes.Visible = false
		AddHandler Me.lblSupersedes.Click, AddressOf Me.LblSupersedesClick
		'
		'lblReturnCodes
		'
		Me.lblReturnCodes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.lblReturnCodes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblReturnCodes.ForeColor = System.Drawing.SystemColors.ActiveCaption
		Me.lblReturnCodes.Location = New System.Drawing.Point(482, 389)
		Me.lblReturnCodes.Name = "lblReturnCodes"
		Me.lblReturnCodes.Size = New System.Drawing.Size(113, 17)
		Me.lblReturnCodes.TabIndex = 62
		Me.lblReturnCodes.Text = "Return Codes"
		Me.lblReturnCodes.Visible = false
		'
		'lblUninstall
		'
		Me.lblUninstall.Location = New System.Drawing.Point(43, 366)
		Me.lblUninstall.Name = "lblUninstall"
		Me.lblUninstall.Size = New System.Drawing.Size(80, 17)
		Me.lblUninstall.TabIndex = 60
		Me.lblUninstall.Text = "Uninstall"
		'
		'txtUninstall
		'
		Me.txtUninstall.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.txtUninstall.Location = New System.Drawing.Point(129, 363)
		Me.txtUninstall.Name = "txtUninstall"
		Me.txtUninstall.ReadOnly = true
		Me.txtUninstall.Size = New System.Drawing.Size(296, 20)
		Me.txtUninstall.TabIndex = 61
		'
		'txtImpact
		'
		Me.txtImpact.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.txtImpact.Location = New System.Drawing.Point(129, 337)
		Me.txtImpact.Name = "txtImpact"
		Me.txtImpact.ReadOnly = true
		Me.txtImpact.Size = New System.Drawing.Size(296, 20)
		Me.txtImpact.TabIndex = 55
		'
		'txtPackage
		'
		Me.txtPackage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.txtPackage.Location = New System.Drawing.Point(129, 33)
		Me.txtPackage.Name = "txtPackage"
		Me.txtPackage.ReadOnly = true
		Me.txtPackage.Size = New System.Drawing.Size(522, 20)
		Me.txtPackage.TabIndex = 53
		'
		'lblID
		'
		Me.lblID.Location = New System.Drawing.Point(41, 33)
		Me.lblID.Name = "lblID"
		Me.lblID.Size = New System.Drawing.Size(80, 17)
		Me.lblID.TabIndex = 52
		Me.lblID.Text = "Package ID"
		'
		'txtProduct
		'
		Me.txtProduct.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.txtProduct.Location = New System.Drawing.Point(129, 208)
		Me.txtProduct.Name = "txtProduct"
		Me.txtProduct.ReadOnly = true
		Me.txtProduct.Size = New System.Drawing.Size(522, 20)
		Me.txtProduct.TabIndex = 59
		'
		'txtDescription
		'
		Me.txtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.txtDescription.Location = New System.Drawing.Point(129, 85)
		Me.txtDescription.Multiline = true
		Me.txtDescription.Name = "txtDescription"
		Me.txtDescription.ReadOnly = true
		Me.txtDescription.Size = New System.Drawing.Size(522, 39)
		Me.txtDescription.TabIndex = 40
		'
		'lblImpact
		'
		Me.lblImpact.Location = New System.Drawing.Point(43, 339)
		Me.lblImpact.Name = "lblImpact"
		Me.lblImpact.Size = New System.Drawing.Size(80, 17)
		Me.lblImpact.TabIndex = 37
		Me.lblImpact.Text = "Impact"
		'
		'txtPackageTitle
		'
		Me.txtPackageTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.txtPackageTitle.Location = New System.Drawing.Point(129, 59)
		Me.txtPackageTitle.Name = "txtPackageTitle"
		Me.txtPackageTitle.ReadOnly = true
		Me.txtPackageTitle.Size = New System.Drawing.Size(522, 20)
		Me.txtPackageTitle.TabIndex = 39
		'
		'txtVendor
		'
		Me.txtVendor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.txtVendor.Location = New System.Drawing.Point(129, 182)
		Me.txtVendor.Name = "txtVendor"
		Me.txtVendor.ReadOnly = true
		Me.txtVendor.Size = New System.Drawing.Size(522, 20)
		Me.txtVendor.TabIndex = 58
		'
		'lblDescription
		'
		Me.lblDescription.Location = New System.Drawing.Point(41, 86)
		Me.lblDescription.Name = "lblDescription"
		Me.lblDescription.Size = New System.Drawing.Size(80, 17)
		Me.lblDescription.TabIndex = 27
		Me.lblDescription.Text = "Description"
		'
		'lblRebootBehavior
		'
		Me.lblRebootBehavior.Location = New System.Drawing.Point(30, 392)
		Me.lblRebootBehavior.Name = "lblRebootBehavior"
		Me.lblRebootBehavior.Size = New System.Drawing.Size(93, 17)
		Me.lblRebootBehavior.TabIndex = 38
		Me.lblRebootBehavior.Text = "Reboot Behavior"
		'
		'lblPackageTitle
		'
		Me.lblPackageTitle.Location = New System.Drawing.Point(41, 59)
		Me.lblPackageTitle.Name = "lblPackageTitle"
		Me.lblPackageTitle.Size = New System.Drawing.Size(80, 17)
		Me.lblPackageTitle.TabIndex = 26
		Me.lblPackageTitle.Text = "Package Title"
		'
		'txtClassification
		'
		Me.txtClassification.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.txtClassification.Location = New System.Drawing.Point(129, 130)
		Me.txtClassification.Name = "txtClassification"
		Me.txtClassification.ReadOnly = true
		Me.txtClassification.Size = New System.Drawing.Size(296, 20)
		Me.txtClassification.TabIndex = 57
		'
		'txtRebootBehavior
		'
		Me.txtRebootBehavior.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.txtRebootBehavior.Location = New System.Drawing.Point(129, 389)
		Me.txtRebootBehavior.Name = "txtRebootBehavior"
		Me.txtRebootBehavior.ReadOnly = true
		Me.txtRebootBehavior.Size = New System.Drawing.Size(296, 20)
		Me.txtRebootBehavior.TabIndex = 54
		'
		'txtServerity
		'
		Me.txtServerity.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.txtServerity.Location = New System.Drawing.Point(129, 286)
		Me.txtServerity.Name = "txtServerity"
		Me.txtServerity.ReadOnly = true
		Me.txtServerity.Size = New System.Drawing.Size(296, 20)
		Me.txtServerity.TabIndex = 56
		'
		'txtArticleID
		'
		Me.txtArticleID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.txtArticleID.Location = New System.Drawing.Point(129, 234)
		Me.txtArticleID.Name = "txtArticleID"
		Me.txtArticleID.ReadOnly = true
		Me.txtArticleID.Size = New System.Drawing.Size(296, 20)
		Me.txtArticleID.TabIndex = 45
		'
		'txtBulletinID
		'
		Me.txtBulletinID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.txtBulletinID.Location = New System.Drawing.Point(129, 156)
		Me.txtBulletinID.Name = "txtBulletinID"
		Me.txtBulletinID.ReadOnly = true
		Me.txtBulletinID.Size = New System.Drawing.Size(296, 20)
		Me.txtBulletinID.TabIndex = 41
		'
		'lblMoreInfoURL
		'
		Me.lblMoreInfoURL.Location = New System.Drawing.Point(42, 314)
		Me.lblMoreInfoURL.Name = "lblMoreInfoURL"
		Me.lblMoreInfoURL.Size = New System.Drawing.Size(80, 17)
		Me.lblMoreInfoURL.TabIndex = 36
		Me.lblMoreInfoURL.Text = "More Info URL"
		'
		'txtCVEID
		'
		Me.txtCVEID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.txtCVEID.Location = New System.Drawing.Point(129, 260)
		Me.txtCVEID.Name = "txtCVEID"
		Me.txtCVEID.ReadOnly = true
		Me.txtCVEID.Size = New System.Drawing.Size(296, 20)
		Me.txtCVEID.TabIndex = 46
		'
		'lblArticleID
		'
		Me.lblArticleID.Location = New System.Drawing.Point(41, 235)
		Me.lblArticleID.Name = "lblArticleID"
		Me.lblArticleID.Size = New System.Drawing.Size(80, 17)
		Me.lblArticleID.TabIndex = 32
		Me.lblArticleID.Text = "Article ID"
		'
		'txtMoreInfoURL
		'
		Me.txtMoreInfoURL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.txtMoreInfoURL.Location = New System.Drawing.Point(129, 311)
		Me.txtMoreInfoURL.Name = "txtMoreInfoURL"
		Me.txtMoreInfoURL.ReadOnly = true
		Me.txtMoreInfoURL.Size = New System.Drawing.Size(522, 20)
		Me.txtMoreInfoURL.TabIndex = 49
		'
		'lblProduct
		'
		Me.lblProduct.Location = New System.Drawing.Point(41, 209)
		Me.lblProduct.Name = "lblProduct"
		Me.lblProduct.Size = New System.Drawing.Size(80, 17)
		Me.lblProduct.TabIndex = 31
		Me.lblProduct.Text = "Product"
		'
		'lblCVEID
		'
		Me.lblCVEID.Location = New System.Drawing.Point(42, 263)
		Me.lblCVEID.Name = "lblCVEID"
		Me.lblCVEID.Size = New System.Drawing.Size(80, 17)
		Me.lblCVEID.TabIndex = 33
		Me.lblCVEID.Text = "CVE ID"
		'
		'lblVendor
		'
		Me.lblVendor.Location = New System.Drawing.Point(41, 185)
		Me.lblVendor.Name = "lblVendor"
		Me.lblVendor.Size = New System.Drawing.Size(80, 17)
		Me.lblVendor.TabIndex = 30
		Me.lblVendor.Text = "Vendor"
		'
		'lblSeverity
		'
		Me.lblSeverity.Location = New System.Drawing.Point(42, 288)
		Me.lblSeverity.Name = "lblSeverity"
		Me.lblSeverity.Size = New System.Drawing.Size(80, 17)
		Me.lblSeverity.TabIndex = 34
		Me.lblSeverity.Text = "Severity"
		'
		'lblBullitinID
		'
		Me.lblBullitinID.Location = New System.Drawing.Point(41, 158)
		Me.lblBullitinID.Name = "lblBullitinID"
		Me.lblBullitinID.Size = New System.Drawing.Size(80, 17)
		Me.lblBullitinID.TabIndex = 29
		Me.lblBullitinID.Text = "Bulletin ID"
		'
		'lblClassification
		'
		Me.lblClassification.Location = New System.Drawing.Point(41, 133)
		Me.lblClassification.Name = "lblClassification"
		Me.lblClassification.Size = New System.Drawing.Size(80, 17)
		Me.lblClassification.TabIndex = 28
		Me.lblClassification.Text = "Classification"
		'
		'tabUpdateStatus
		'
		Me.tabUpdateStatus.Controls.Add(Me.dgvUpdateStatus)
		Me.tabUpdateStatus.Location = New System.Drawing.Point(4, 22)
		Me.tabUpdateStatus.Name = "tabUpdateStatus"
		Me.tabUpdateStatus.Padding = New System.Windows.Forms.Padding(3)
		Me.tabUpdateStatus.Size = New System.Drawing.Size(671, 452)
		Me.tabUpdateStatus.TabIndex = 1
		Me.tabUpdateStatus.Text = "Status"
		Me.tabUpdateStatus.UseVisualStyleBackColor = true
		'
		'dgvUpdateStatus
		'
		Me.dgvUpdateStatus.AllowUserToAddRows = false
		Me.dgvUpdateStatus.AllowUserToDeleteRows = false
		Me.dgvUpdateStatus.AllowUserToOrderColumns = true
		Me.dgvUpdateStatus.AllowUserToResizeRows = false
		Me.dgvUpdateStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.dgvUpdateStatus.BackgroundColor = System.Drawing.SystemColors.Window
		Me.dgvUpdateStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.dgvUpdateStatus.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
		Me.dgvUpdateStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvUpdateStatus.Dock = System.Windows.Forms.DockStyle.Fill
		Me.dgvUpdateStatus.Location = New System.Drawing.Point(3, 3)
		Me.dgvUpdateStatus.Name = "dgvUpdateStatus"
		Me.dgvUpdateStatus.ReadOnly = true
		Me.dgvUpdateStatus.RowHeadersVisible = false
		Me.dgvUpdateStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvUpdateStatus.Size = New System.Drawing.Size(665, 446)
		Me.dgvUpdateStatus.TabIndex = 0
		'
		'tabUpdateReport
		'
		Me.tabUpdateReport.Controls.Add(Me.btnUpdateRefreshReport)
		Me.tabUpdateReport.Controls.Add(Me.dgvUpdateReport)
		Me.tabUpdateReport.Controls.Add(Me.lblUpdateStatus)
		Me.tabUpdateReport.Controls.Add(Me.lblComputerGroup)
		Me.tabUpdateReport.Controls.Add(Me.cboUpdateStatus)
		Me.tabUpdateReport.Controls.Add(Me.cboTargetGroup)
		Me.tabUpdateReport.Location = New System.Drawing.Point(4, 22)
		Me.tabUpdateReport.Name = "tabUpdateReport"
		Me.tabUpdateReport.Padding = New System.Windows.Forms.Padding(3)
		Me.tabUpdateReport.Size = New System.Drawing.Size(671, 452)
		Me.tabUpdateReport.TabIndex = 2
		Me.tabUpdateReport.Text = "Report"
		Me.tabUpdateReport.UseVisualStyleBackColor = true
		'
		'btnUpdateRefreshReport
		'
		Me.btnUpdateRefreshReport.Enabled = false
		Me.btnUpdateRefreshReport.Location = New System.Drawing.Point(563, 33)
		Me.btnUpdateRefreshReport.Name = "btnUpdateRefreshReport"
		Me.btnUpdateRefreshReport.Size = New System.Drawing.Size(75, 23)
		Me.btnUpdateRefreshReport.TabIndex = 5
		Me.btnUpdateRefreshReport.Text = "Refresh"
		Me.btnUpdateRefreshReport.UseVisualStyleBackColor = true
		AddHandler Me.btnUpdateRefreshReport.Click, AddressOf Me.BtnUpdateRefreshReportClick
		'
		'dgvUpdateReport
		'
		Me.dgvUpdateReport.AllowUserToAddRows = false
		Me.dgvUpdateReport.AllowUserToDeleteRows = false
		Me.dgvUpdateReport.AllowUserToOrderColumns = true
		Me.dgvUpdateReport.AllowUserToResizeRows = false
		Me.dgvUpdateReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
						Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.dgvUpdateReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.dgvUpdateReport.BackgroundColor = System.Drawing.SystemColors.Window
		Me.dgvUpdateReport.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.dgvUpdateReport.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
		Me.dgvUpdateReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvUpdateReport.Location = New System.Drawing.Point(7, 60)
		Me.dgvUpdateReport.Name = "dgvUpdateReport"
		Me.dgvUpdateReport.ReadOnly = true
		Me.dgvUpdateReport.RowHeadersVisible = false
		Me.dgvUpdateReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvUpdateReport.Size = New System.Drawing.Size(657, 384)
		Me.dgvUpdateReport.TabIndex = 4
		AddHandler Me.dgvUpdateReport.Sorted, AddressOf Me.DgvUpdateReportSorted
		AddHandler Me.dgvUpdateReport.CellMouseDown, AddressOf Me.DgvUpdateReportCellMouseDown
		'
		'lblUpdateStatus
		'
		Me.lblUpdateStatus.Location = New System.Drawing.Point(307, 17)
		Me.lblUpdateStatus.Name = "lblUpdateStatus"
		Me.lblUpdateStatus.Size = New System.Drawing.Size(100, 15)
		Me.lblUpdateStatus.TabIndex = 3
		Me.lblUpdateStatus.Text = "Update Status"
		'
		'lblComputerGroup
		'
		Me.lblComputerGroup.Location = New System.Drawing.Point(50, 17)
		Me.lblComputerGroup.Name = "lblComputerGroup"
		Me.lblComputerGroup.Size = New System.Drawing.Size(100, 15)
		Me.lblComputerGroup.TabIndex = 2
		Me.lblComputerGroup.Text = "Computer Group"
		'
		'cboUpdateStatus
		'
		Me.cboUpdateStatus.FormattingEnabled = true
		Me.cboUpdateStatus.Items.AddRange(New Object() {"Failed or Needed", "Installed/Not Applicable or No Status", "Failed", "Needed", "Installed/Not Applicable", "No Status", "Any"})
		Me.cboUpdateStatus.Location = New System.Drawing.Point(307, 35)
		Me.cboUpdateStatus.Name = "cboUpdateStatus"
		Me.cboUpdateStatus.Size = New System.Drawing.Size(233, 21)
		Me.cboUpdateStatus.TabIndex = 1
		Me.cboUpdateStatus.Text = "Any"
		AddHandler Me.cboUpdateStatus.SelectedIndexChanged, AddressOf Me.cboUpdateStatusSelectedIndexChanged
		'
		'cboTargetGroup
		'
		Me.cboTargetGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
		Me.cboTargetGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cboTargetGroup.FormattingEnabled = true
		Me.cboTargetGroup.Location = New System.Drawing.Point(50, 35)
		Me.cboTargetGroup.Name = "cboTargetGroup"
		Me.cboTargetGroup.Size = New System.Drawing.Size(233, 21)
		Me.cboTargetGroup.TabIndex = 0
		AddHandler Me.cboTargetGroup.SelectedIndexChanged, AddressOf Me.CboTargetGroupSelectedIndexChanged
		'
		'cmDgvMain
		'
		Me.cmDgvMain.Name = "Data Grid Context Menu"
		Me.cmDgvMain.Size = New System.Drawing.Size(61, 4)
		'
		'statusStrip
		'
		Me.statusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusLabel, Me.toolStripStatusLabelLink})
		Me.statusStrip.Location = New System.Drawing.Point(0, 659)
		Me.statusStrip.Name = "statusStrip"
		Me.statusStrip.Size = New System.Drawing.Size(858, 22)
		Me.statusStrip.TabIndex = 2
		Me.statusStrip.Text = "statusStrip1"
		'
		'toolStripStatusLabel
		'
		Me.toolStripStatusLabel.Name = "toolStripStatusLabel"
		Me.toolStripStatusLabel.Size = New System.Drawing.Size(421, 17)
		Me.toolStripStatusLabel.Spring = true
		Me.toolStripStatusLabel.Text = "toolStripStatusLabel"
		Me.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'toolStripStatusLabelLink
		'
		Me.toolStripStatusLabelLink.IsLink = true
		Me.toolStripStatusLabelLink.Name = "toolStripStatusLabelLink"
		Me.toolStripStatusLabelLink.Size = New System.Drawing.Size(421, 17)
		Me.toolStripStatusLabelLink.Spring = true
		Me.toolStripStatusLabelLink.Text = "http://www.localupdatepublisher.com"
		Me.toolStripStatusLabelLink.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		AddHandler Me.toolStripStatusLabelLink.Click, AddressOf Me.ToolStripStatusLabelLinkClick
		'
		'exportFileDialog
		'
		Me.exportFileDialog.DefaultExt = "tab"
		Me.exportFileDialog.Filter = "Tab Delimited|*.tab"
		'
		'MainForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(858, 681)
		Me.Controls.Add(Me.statusStrip)
		Me.Controls.Add(Me.menuStrip)
		Me.Controls.Add(Me.splitContainerVert)
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.MainMenuStrip = Me.menuStrip
		Me.Name = "MainForm"
		Me.Text = "Local Update Publisher"
		AddHandler Load, AddressOf Me.MainFormLoad
		AddHandler Activated, AddressOf Me.MainFormActivated
		AddHandler FormClosing, AddressOf Me.MainFormFormClosing
		Me.menuStrip.ResumeLayout(false)
		Me.menuStrip.PerformLayout
		Me.splitContainerVert.Panel1.ResumeLayout(false)
		Me.splitContainerVert.Panel2.ResumeLayout(false)
		Me.splitContainerVert.ResumeLayout(false)
		Me.splitContainerHorz.Panel1.ResumeLayout(false)
		Me.splitContainerHorz.Panel2.ResumeLayout(false)
		Me.splitContainerHorz.ResumeLayout(false)
		Me.scHeader.Panel1.ResumeLayout(false)
		Me.scHeader.Panel2.ResumeLayout(false)
		Me.scHeader.ResumeLayout(false)
		Me.pnlHeaderTop.ResumeLayout(false)
		CType(Me._dgvMain,System.ComponentModel.ISupportInitialize).EndInit
		Me.pnlComputers.ResumeLayout(false)
		Me.tabMainComputers.ResumeLayout(false)
		Me.tabComputerInfo.ResumeLayout(false)
		Me.tabComputerInfo.PerformLayout
		Me.tabComputerStatus.ResumeLayout(false)
		CType(Me.dgvComputerGroupStatus,System.ComponentModel.ISupportInitialize).EndInit
		Me.tabComputerReport.ResumeLayout(false)
		CType(Me.dgvComputerReport,System.ComponentModel.ISupportInitialize).EndInit
		Me.pnlUpdates.ResumeLayout(false)
		Me.tabMainUpdates.ResumeLayout(false)
		Me.tabUpdateInfo.ResumeLayout(false)
		Me.tabUpdateInfo.PerformLayout
		Me.tabUpdateStatus.ResumeLayout(false)
		CType(Me.dgvUpdateStatus,System.ComponentModel.ISupportInitialize).EndInit
		Me.tabUpdateReport.ResumeLayout(false)
		CType(Me.dgvUpdateReport,System.ComponentModel.ISupportInitialize).EndInit
		Me.statusStrip.ResumeLayout(false)
		Me.statusStrip.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private exportFileDialog As System.Windows.Forms.SaveFileDialog
	Private txtUpdatesWErrorsNum As System.Windows.Forms.TextBox
	Private txtUpdateNoStatusNum As System.Windows.Forms.TextBox
	Private txtUpdatesInstalledorNANum As System.Windows.Forms.TextBox
	Private txtUpdatesNeededNum As System.Windows.Forms.TextBox
	Private chkInheritApprovals As System.Windows.Forms.CheckBox
	Private chkApprovedOnly As System.Windows.Forms.CheckBox
	Private lblPackageType As System.Windows.Forms.Label
	Private txtPackageType As System.Windows.Forms.TextBox
	Private exportCatalogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private exportUpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private importUpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private importFileDialog As System.Windows.Forms.OpenFileDialog
	Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
	Private importCatalogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private lblPrerequisites As System.Windows.Forms.Label
	Private lblReturnCodes As System.Windows.Forms.Label
	Private lblSupersedes As System.Windows.Forms.Label
	Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
	Private exportReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private exportListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private btnComputerListRefresh As System.Windows.Forms.Button
	Private helpForumsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private lupHelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private createUpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private savedRulesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private exportRulesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private importRulesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private manageRulesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private txtUninstall As System.Windows.Forms.TextBox
	Private lblUninstall As System.Windows.Forms.Label
	Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
	Private toolStripStatusLabelLink As System.Windows.Forms.ToolStripStatusLabel
	Private optionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private connectionSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private toolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
	Private statusStrip As System.Windows.Forms.StatusStrip
	Private updateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private dgvComputerGroupStatus As System.Windows.Forms.DataGridView
	Private tabComputerStatus As System.Windows.Forms.TabPage
	Private btnComputerRefreshReport As System.Windows.Forms.Button
	Private btnUpdateRefreshReport As System.Windows.Forms.Button
	Private tabMainUpdates As System.Windows.Forms.TabControl
	Private tabUpdateInfo As System.Windows.Forms.TabPage
	Private tabUpdateStatus As System.Windows.Forms.TabPage
	Private dgvUpdateStatus As System.Windows.Forms.DataGridView
	Private tabUpdateReport As System.Windows.Forms.TabPage
	Private pnlUpdates As System.Windows.Forms.Panel
	Private pnlComputers As System.Windows.Forms.Panel
	Private dgvUpdateReport As System.Windows.Forms.DataGridView
	Private tabMainComputers As System.Windows.Forms.TabControl
	Private dgvComputerReport As System.Windows.Forms.DataGridView
	Private lblComputerUpdateStatus As System.Windows.Forms.Label
	Private tabComputerReport As System.Windows.Forms.TabPage
	Private lblUpdatesWErrors As System.Windows.Forms.Label
	Private lblUpdatesNeeded As System.Windows.Forms.Label
	Private lblUpdatesInstalledorNA As System.Windows.Forms.Label
	Private lblUpdateNoStatus As System.Windows.Forms.Label
	Private tabComputerInfo As System.Windows.Forms.TabPage
	Private lblSelectedTargetGroup As System.Windows.Forms.Label
	Private lblSelectedTargetGroupCount As System.Windows.Forms.Label
	Private pnlHeaderTop As System.Windows.Forms.Panel
	Private lblComputerStatus As System.Windows.Forms.Label
	Private cboComputerStatus As System.Windows.Forms.ComboBox
	Private scHeader As System.Windows.Forms.SplitContainer
	Private cboTargetGroup As System.Windows.Forms.ComboBox
	Private cboUpdateStatus As System.Windows.Forms.ComboBox
	Private lblComputerGroup As System.Windows.Forms.Label
	Private lblUpdateStatus As System.Windows.Forms.Label
	Private txtProduct As System.Windows.Forms.TextBox
	Private txtClassification As System.Windows.Forms.TextBox
	Private txtServerity As System.Windows.Forms.TextBox
	Private txtImpact As System.Windows.Forms.TextBox
	Private txtVendor As System.Windows.Forms.TextBox
	Private lblPackageTitle As System.Windows.Forms.Label
	Private lblDescription As System.Windows.Forms.Label
	Private lblClassification As System.Windows.Forms.Label
	Private lblBullitinID As System.Windows.Forms.Label
	Private lblVendor As System.Windows.Forms.Label
	Private lblProduct As System.Windows.Forms.Label
	Private lblArticleID As System.Windows.Forms.Label
	Private lblCVEID As System.Windows.Forms.Label
	Private lblSeverity As System.Windows.Forms.Label
	Private lblMoreInfoURL As System.Windows.Forms.Label
	Private lblImpact As System.Windows.Forms.Label
	Private lblRebootBehavior As System.Windows.Forms.Label
	Private txtPackageTitle As System.Windows.Forms.TextBox
	Private txtDescription As System.Windows.Forms.TextBox
	Private txtBulletinID As System.Windows.Forms.TextBox
	Private txtArticleID As System.Windows.Forms.TextBox
	Private txtCVEID As System.Windows.Forms.TextBox
	Private txtMoreInfoURL As System.Windows.Forms.TextBox
	Private lblID As System.Windows.Forms.Label
	Private txtPackage As System.Windows.Forms.TextBox
	Private txtRebootBehavior As System.Windows.Forms.TextBox
	Private splitContainerVert As System.Windows.Forms.SplitContainer
	Private splitContainerHorz As System.Windows.Forms.SplitContainer
	Private cmDgvMain As System.Windows.Forms.ContextMenuStrip
	Private treeView As System.Windows.Forms.TreeView
	Private certificateInfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private menuStrip As System.Windows.Forms.MenuStrip
	Private aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private toolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private _dgvMain As System.Windows.Forms.DataGridView
	ReadOnly Property DgvMain()  As System.Windows.Forms.DataGridView
		Get
			Return _dgvMain
		End Get
	End Property
End Class
