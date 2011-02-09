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
		Me.pnlUpdates = New System.Windows.Forms.Panel
		Me.tabMainUpdates = New System.Windows.Forms.TabControl
		Me.tabUpdateInfo = New System.Windows.Forms.TabPage
		Me.lblNetwork = New System.Windows.Forms.Label
		Me.txtNetwork = New System.Windows.Forms.TextBox
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
		Me.cmDgvMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.statusStrip = New System.Windows.Forms.StatusStrip
		Me.toolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
		Me.toolStripStatusLabelLink = New System.Windows.Forms.ToolStripStatusLabel
		Me.importFileDialog = New System.Windows.Forms.OpenFileDialog
		Me.exportFileDialog = New System.Windows.Forms.SaveFileDialog
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
		Me.pnlUpdates.SuspendLayout
		Me.tabMainUpdates.SuspendLayout
		Me.tabUpdateInfo.SuspendLayout
		Me.tabUpdateStatus.SuspendLayout
		CType(Me.dgvUpdateStatus,System.ComponentModel.ISupportInitialize).BeginInit
		Me.tabUpdateReport.SuspendLayout
		CType(Me.dgvUpdateReport,System.ComponentModel.ISupportInitialize).BeginInit
		Me.pnlComputers.SuspendLayout
		Me.tabMainComputers.SuspendLayout
		Me.tabComputerInfo.SuspendLayout
		Me.tabComputerStatus.SuspendLayout
		CType(Me.dgvComputerGroupStatus,System.ComponentModel.ISupportInitialize).BeginInit
		Me.tabComputerReport.SuspendLayout
		CType(Me.dgvComputerReport,System.ComponentModel.ISupportInitialize).BeginInit
		Me.menuStrip.SuspendLayout
		Me.statusStrip.SuspendLayout
		Me.SuspendLayout
		'
		'splitContainerVert
		'
		Me.splitContainerVert.AccessibleDescription = Nothing
		Me.splitContainerVert.AccessibleName = Nothing
		resources.ApplyResources(Me.splitContainerVert, "splitContainerVert")
		Me.splitContainerVert.BackgroundImage = Nothing
		Me.splitContainerVert.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
		Me.splitContainerVert.Font = Nothing
		Me.splitContainerVert.Name = "splitContainerVert"
		'
		'splitContainerVert.Panel1
		'
		Me.splitContainerVert.Panel1.AccessibleDescription = Nothing
		Me.splitContainerVert.Panel1.AccessibleName = Nothing
		resources.ApplyResources(Me.splitContainerVert.Panel1, "splitContainerVert.Panel1")
		Me.splitContainerVert.Panel1.BackgroundImage = Nothing
		Me.splitContainerVert.Panel1.Controls.Add(Me.treeView)
		Me.splitContainerVert.Panel1.Font = Nothing
		'
		'splitContainerVert.Panel2
		'
		Me.splitContainerVert.Panel2.AccessibleDescription = Nothing
		Me.splitContainerVert.Panel2.AccessibleName = Nothing
		resources.ApplyResources(Me.splitContainerVert.Panel2, "splitContainerVert.Panel2")
		Me.splitContainerVert.Panel2.BackgroundImage = Nothing
		Me.splitContainerVert.Panel2.Controls.Add(Me.splitContainerHorz)
		Me.splitContainerVert.Panel2.Font = Nothing
		AddHandler Me.splitContainerVert.SplitterMoved, AddressOf Me.SplitContainerVertSplitterMoved
		'
		'treeView
		'
		Me.treeView.AccessibleDescription = Nothing
		Me.treeView.AccessibleName = Nothing
		resources.ApplyResources(Me.treeView, "treeView")
		Me.treeView.BackgroundImage = Nothing
		Me.treeView.Font = Nothing
		Me.treeView.HideSelection = false
		Me.treeView.Name = "treeView"
		AddHandler Me.treeView.AfterSelect, AddressOf Me.TreeViewAfterSelect
		AddHandler Me.treeView.BeforeSelect, AddressOf Me.TreeViewBeforeSelect
		'
		'splitContainerHorz
		'
		Me.splitContainerHorz.AccessibleDescription = Nothing
		Me.splitContainerHorz.AccessibleName = Nothing
		resources.ApplyResources(Me.splitContainerHorz, "splitContainerHorz")
		Me.splitContainerHorz.BackgroundImage = Nothing
		Me.splitContainerHorz.Font = Nothing
		Me.splitContainerHorz.Name = "splitContainerHorz"
		'
		'splitContainerHorz.Panel1
		'
		Me.splitContainerHorz.Panel1.AccessibleDescription = Nothing
		Me.splitContainerHorz.Panel1.AccessibleName = Nothing
		resources.ApplyResources(Me.splitContainerHorz.Panel1, "splitContainerHorz.Panel1")
		Me.splitContainerHorz.Panel1.BackgroundImage = Nothing
		Me.splitContainerHorz.Panel1.Controls.Add(Me.scHeader)
		Me.splitContainerHorz.Panel1.Font = Nothing
		'
		'splitContainerHorz.Panel2
		'
		Me.splitContainerHorz.Panel2.AccessibleDescription = Nothing
		Me.splitContainerHorz.Panel2.AccessibleName = Nothing
		resources.ApplyResources(Me.splitContainerHorz.Panel2, "splitContainerHorz.Panel2")
		Me.splitContainerHorz.Panel2.BackgroundImage = Nothing
		Me.splitContainerHorz.Panel2.Controls.Add(Me.pnlUpdates)
		Me.splitContainerHorz.Panel2.Controls.Add(Me.pnlComputers)
		Me.splitContainerHorz.Panel2.Font = Nothing
		AddHandler Me.splitContainerHorz.SplitterMoved, AddressOf Me.SplitContainerSplitterMoved
		'
		'scHeader
		'
		Me.scHeader.AccessibleDescription = Nothing
		Me.scHeader.AccessibleName = Nothing
		resources.ApplyResources(Me.scHeader, "scHeader")
		Me.scHeader.BackgroundImage = Nothing
		Me.scHeader.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
		Me.scHeader.Font = Nothing
		Me.scHeader.Name = "scHeader"
		'
		'scHeader.Panel1
		'
		Me.scHeader.Panel1.AccessibleDescription = Nothing
		Me.scHeader.Panel1.AccessibleName = Nothing
		resources.ApplyResources(Me.scHeader.Panel1, "scHeader.Panel1")
		Me.scHeader.Panel1.BackgroundImage = Nothing
		Me.scHeader.Panel1.Controls.Add(Me.chkInheritApprovals)
		Me.scHeader.Panel1.Controls.Add(Me.chkApprovedOnly)
		Me.scHeader.Panel1.Controls.Add(Me.pnlHeaderTop)
		Me.scHeader.Panel1.Controls.Add(Me.lblComputerStatus)
		Me.scHeader.Panel1.Controls.Add(Me.btnComputerListRefresh)
		Me.scHeader.Panel1.Controls.Add(Me.cboComputerStatus)
		Me.scHeader.Panel1.Font = Nothing
		'
		'scHeader.Panel2
		'
		Me.scHeader.Panel2.AccessibleDescription = Nothing
		Me.scHeader.Panel2.AccessibleName = Nothing
		resources.ApplyResources(Me.scHeader.Panel2, "scHeader.Panel2")
		Me.scHeader.Panel2.BackgroundImage = Nothing
		Me.scHeader.Panel2.Controls.Add(Me._dgvMain)
		Me.scHeader.Panel2.Font = Nothing
		'
		'chkInheritApprovals
		'
		Me.chkInheritApprovals.AccessibleDescription = Nothing
		Me.chkInheritApprovals.AccessibleName = Nothing
		resources.ApplyResources(Me.chkInheritApprovals, "chkInheritApprovals")
		Me.chkInheritApprovals.BackgroundImage = Nothing
		Me.chkInheritApprovals.Font = Nothing
		Me.chkInheritApprovals.Name = "chkInheritApprovals"
		Me.chkInheritApprovals.UseVisualStyleBackColor = true
		AddHandler Me.chkInheritApprovals.CheckedChanged, AddressOf Me.ChkInheritApprovalsCheckedChanged
		'
		'chkApprovedOnly
		'
		Me.chkApprovedOnly.AccessibleDescription = Nothing
		Me.chkApprovedOnly.AccessibleName = Nothing
		resources.ApplyResources(Me.chkApprovedOnly, "chkApprovedOnly")
		Me.chkApprovedOnly.BackgroundImage = Nothing
		Me.chkApprovedOnly.Font = Nothing
		Me.chkApprovedOnly.Name = "chkApprovedOnly"
		Me.chkApprovedOnly.UseVisualStyleBackColor = true
		AddHandler Me.chkApprovedOnly.CheckedChanged, AddressOf Me.ChkApprovedOnlyCheckedChanged
		'
		'pnlHeaderTop
		'
		Me.pnlHeaderTop.AccessibleDescription = Nothing
		Me.pnlHeaderTop.AccessibleName = Nothing
		resources.ApplyResources(Me.pnlHeaderTop, "pnlHeaderTop")
		Me.pnlHeaderTop.BackColor = System.Drawing.SystemColors.ControlDark
		Me.pnlHeaderTop.BackgroundImage = Nothing
		Me.pnlHeaderTop.Controls.Add(Me.lblSelectedTargetGroupCount)
		Me.pnlHeaderTop.Controls.Add(Me.lblSelectedTargetGroup)
		Me.pnlHeaderTop.Font = Nothing
		Me.pnlHeaderTop.Name = "pnlHeaderTop"
		'
		'lblSelectedTargetGroupCount
		'
		Me.lblSelectedTargetGroupCount.AccessibleDescription = Nothing
		Me.lblSelectedTargetGroupCount.AccessibleName = Nothing
		resources.ApplyResources(Me.lblSelectedTargetGroupCount, "lblSelectedTargetGroupCount")
		Me.lblSelectedTargetGroupCount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
		Me.lblSelectedTargetGroupCount.Name = "lblSelectedTargetGroupCount"
		'
		'lblSelectedTargetGroup
		'
		Me.lblSelectedTargetGroup.AccessibleDescription = Nothing
		Me.lblSelectedTargetGroup.AccessibleName = Nothing
		resources.ApplyResources(Me.lblSelectedTargetGroup, "lblSelectedTargetGroup")
		Me.lblSelectedTargetGroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
		Me.lblSelectedTargetGroup.Name = "lblSelectedTargetGroup"
		'
		'lblComputerStatus
		'
		Me.lblComputerStatus.AccessibleDescription = Nothing
		Me.lblComputerStatus.AccessibleName = Nothing
		resources.ApplyResources(Me.lblComputerStatus, "lblComputerStatus")
		Me.lblComputerStatus.Font = Nothing
		Me.lblComputerStatus.Name = "lblComputerStatus"
		'
		'btnComputerListRefresh
		'
		Me.btnComputerListRefresh.AccessibleDescription = Nothing
		Me.btnComputerListRefresh.AccessibleName = Nothing
		resources.ApplyResources(Me.btnComputerListRefresh, "btnComputerListRefresh")
		Me.btnComputerListRefresh.BackgroundImage = Nothing
		Me.btnComputerListRefresh.Font = Nothing
		Me.btnComputerListRefresh.Name = "btnComputerListRefresh"
		Me.btnComputerListRefresh.UseVisualStyleBackColor = true
		AddHandler Me.btnComputerListRefresh.Click, AddressOf Me.BtnComputerListRefreshClick
		'
		'cboComputerStatus
		'
		Me.cboComputerStatus.AccessibleDescription = Nothing
		Me.cboComputerStatus.AccessibleName = Nothing
		resources.ApplyResources(Me.cboComputerStatus, "cboComputerStatus")
		Me.cboComputerStatus.BackgroundImage = Nothing
		Me.cboComputerStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboComputerStatus.Font = Nothing
		Me.cboComputerStatus.FormattingEnabled = true
		Me.cboComputerStatus.Name = "cboComputerStatus"
		AddHandler Me.cboComputerStatus.SelectedIndexChanged, AddressOf Me.CboComputerStatusSelectedIndexChanged
		'
		'_dgvMain
		'
		Me._dgvMain.AccessibleDescription = Nothing
		Me._dgvMain.AccessibleName = Nothing
		Me._dgvMain.AllowUserToAddRows = false
		Me._dgvMain.AllowUserToDeleteRows = false
		Me._dgvMain.AllowUserToOrderColumns = true
		Me._dgvMain.AllowUserToResizeRows = false
		resources.ApplyResources(Me._dgvMain, "_dgvMain")
		Me._dgvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me._dgvMain.BackgroundColor = System.Drawing.SystemColors.Window
		Me._dgvMain.BackgroundImage = Nothing
		Me._dgvMain.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._dgvMain.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
		Me._dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me._dgvMain.Font = Nothing
		Me._dgvMain.Name = "_dgvMain"
		Me._dgvMain.ReadOnly = true
		Me._dgvMain.RowHeadersVisible = false
		Me._dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		AddHandler Me._dgvMain.Sorted, AddressOf Me.DgvMainSorted
		AddHandler Me._dgvMain.RowEnter, AddressOf Me.dgvMainRowEnter
		AddHandler Me._dgvMain.CellMouseDown, AddressOf Me.dgvMainCellMouseDown
		AddHandler Me._dgvMain.Leave, AddressOf Me.dgvMainLeave
		AddHandler Me._dgvMain.KeyUp, AddressOf Me.dgvMainKeyUp
		'
		'pnlUpdates
		'
		Me.pnlUpdates.AccessibleDescription = Nothing
		Me.pnlUpdates.AccessibleName = Nothing
		resources.ApplyResources(Me.pnlUpdates, "pnlUpdates")
		Me.pnlUpdates.BackgroundImage = Nothing
		Me.pnlUpdates.Controls.Add(Me.tabMainUpdates)
		Me.pnlUpdates.Font = Nothing
		Me.pnlUpdates.Name = "pnlUpdates"
		'
		'tabMainUpdates
		'
		Me.tabMainUpdates.AccessibleDescription = Nothing
		Me.tabMainUpdates.AccessibleName = Nothing
		resources.ApplyResources(Me.tabMainUpdates, "tabMainUpdates")
		Me.tabMainUpdates.BackgroundImage = Nothing
		Me.tabMainUpdates.Controls.Add(Me.tabUpdateInfo)
		Me.tabMainUpdates.Controls.Add(Me.tabUpdateStatus)
		Me.tabMainUpdates.Controls.Add(Me.tabUpdateReport)
		Me.tabMainUpdates.Font = Nothing
		Me.tabMainUpdates.Name = "tabMainUpdates"
		Me.tabMainUpdates.SelectedIndex = 0
		'
		'tabUpdateInfo
		'
		Me.tabUpdateInfo.AccessibleDescription = Nothing
		Me.tabUpdateInfo.AccessibleName = Nothing
		resources.ApplyResources(Me.tabUpdateInfo, "tabUpdateInfo")
		Me.tabUpdateInfo.BackgroundImage = Nothing
		Me.tabUpdateInfo.Controls.Add(Me.lblNetwork)
		Me.tabUpdateInfo.Controls.Add(Me.txtNetwork)
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
		Me.tabUpdateInfo.Font = Nothing
		Me.tabUpdateInfo.Name = "tabUpdateInfo"
		Me.tabUpdateInfo.UseVisualStyleBackColor = true
		'
		'lblNetwork
		'
		Me.lblNetwork.AccessibleDescription = Nothing
		Me.lblNetwork.AccessibleName = Nothing
		resources.ApplyResources(Me.lblNetwork, "lblNetwork")
		Me.lblNetwork.Font = Nothing
		Me.lblNetwork.Name = "lblNetwork"
		'
		'txtNetwork
		'
		Me.txtNetwork.AccessibleDescription = Nothing
		Me.txtNetwork.AccessibleName = Nothing
		resources.ApplyResources(Me.txtNetwork, "txtNetwork")
		Me.txtNetwork.BackgroundImage = Nothing
		Me.txtNetwork.Font = Nothing
		Me.txtNetwork.Name = "txtNetwork"
		Me.txtNetwork.ReadOnly = true
		'
		'txtPackageType
		'
		Me.txtPackageType.AccessibleDescription = Nothing
		Me.txtPackageType.AccessibleName = Nothing
		resources.ApplyResources(Me.txtPackageType, "txtPackageType")
		Me.txtPackageType.BackgroundImage = Nothing
		Me.txtPackageType.Font = Nothing
		Me.txtPackageType.Name = "txtPackageType"
		Me.txtPackageType.ReadOnly = true
		'
		'lblPackageType
		'
		Me.lblPackageType.AccessibleDescription = Nothing
		Me.lblPackageType.AccessibleName = Nothing
		resources.ApplyResources(Me.lblPackageType, "lblPackageType")
		Me.lblPackageType.Font = Nothing
		Me.lblPackageType.Name = "lblPackageType"
		'
		'lblPrerequisites
		'
		Me.lblPrerequisites.AccessibleDescription = Nothing
		Me.lblPrerequisites.AccessibleName = Nothing
		resources.ApplyResources(Me.lblPrerequisites, "lblPrerequisites")
		Me.lblPrerequisites.ForeColor = System.Drawing.SystemColors.ActiveCaption
		Me.lblPrerequisites.Name = "lblPrerequisites"
		AddHandler Me.lblPrerequisites.Click, AddressOf Me.LblPrerequisitesClick
		'
		'lblSupersedes
		'
		Me.lblSupersedes.AccessibleDescription = Nothing
		Me.lblSupersedes.AccessibleName = Nothing
		resources.ApplyResources(Me.lblSupersedes, "lblSupersedes")
		Me.lblSupersedes.ForeColor = System.Drawing.SystemColors.ActiveCaption
		Me.lblSupersedes.Name = "lblSupersedes"
		AddHandler Me.lblSupersedes.Click, AddressOf Me.LblSupersedesClick
		'
		'lblReturnCodes
		'
		Me.lblReturnCodes.AccessibleDescription = Nothing
		Me.lblReturnCodes.AccessibleName = Nothing
		resources.ApplyResources(Me.lblReturnCodes, "lblReturnCodes")
		Me.lblReturnCodes.ForeColor = System.Drawing.SystemColors.ActiveCaption
		Me.lblReturnCodes.Name = "lblReturnCodes"
		'
		'lblUninstall
		'
		Me.lblUninstall.AccessibleDescription = Nothing
		Me.lblUninstall.AccessibleName = Nothing
		resources.ApplyResources(Me.lblUninstall, "lblUninstall")
		Me.lblUninstall.Font = Nothing
		Me.lblUninstall.Name = "lblUninstall"
		'
		'txtUninstall
		'
		Me.txtUninstall.AccessibleDescription = Nothing
		Me.txtUninstall.AccessibleName = Nothing
		resources.ApplyResources(Me.txtUninstall, "txtUninstall")
		Me.txtUninstall.BackgroundImage = Nothing
		Me.txtUninstall.Font = Nothing
		Me.txtUninstall.Name = "txtUninstall"
		Me.txtUninstall.ReadOnly = true
		'
		'txtImpact
		'
		Me.txtImpact.AccessibleDescription = Nothing
		Me.txtImpact.AccessibleName = Nothing
		resources.ApplyResources(Me.txtImpact, "txtImpact")
		Me.txtImpact.BackgroundImage = Nothing
		Me.txtImpact.Font = Nothing
		Me.txtImpact.Name = "txtImpact"
		Me.txtImpact.ReadOnly = true
		'
		'txtPackage
		'
		Me.txtPackage.AccessibleDescription = Nothing
		Me.txtPackage.AccessibleName = Nothing
		resources.ApplyResources(Me.txtPackage, "txtPackage")
		Me.txtPackage.BackgroundImage = Nothing
		Me.txtPackage.Font = Nothing
		Me.txtPackage.Name = "txtPackage"
		Me.txtPackage.ReadOnly = true
		'
		'lblID
		'
		Me.lblID.AccessibleDescription = Nothing
		Me.lblID.AccessibleName = Nothing
		resources.ApplyResources(Me.lblID, "lblID")
		Me.lblID.Font = Nothing
		Me.lblID.Name = "lblID"
		'
		'txtProduct
		'
		Me.txtProduct.AccessibleDescription = Nothing
		Me.txtProduct.AccessibleName = Nothing
		resources.ApplyResources(Me.txtProduct, "txtProduct")
		Me.txtProduct.BackgroundImage = Nothing
		Me.txtProduct.Font = Nothing
		Me.txtProduct.Name = "txtProduct"
		Me.txtProduct.ReadOnly = true
		'
		'txtDescription
		'
		Me.txtDescription.AccessibleDescription = Nothing
		Me.txtDescription.AccessibleName = Nothing
		resources.ApplyResources(Me.txtDescription, "txtDescription")
		Me.txtDescription.BackgroundImage = Nothing
		Me.txtDescription.Font = Nothing
		Me.txtDescription.Name = "txtDescription"
		Me.txtDescription.ReadOnly = true
		'
		'lblImpact
		'
		Me.lblImpact.AccessibleDescription = Nothing
		Me.lblImpact.AccessibleName = Nothing
		resources.ApplyResources(Me.lblImpact, "lblImpact")
		Me.lblImpact.Font = Nothing
		Me.lblImpact.Name = "lblImpact"
		'
		'txtPackageTitle
		'
		Me.txtPackageTitle.AccessibleDescription = Nothing
		Me.txtPackageTitle.AccessibleName = Nothing
		resources.ApplyResources(Me.txtPackageTitle, "txtPackageTitle")
		Me.txtPackageTitle.BackgroundImage = Nothing
		Me.txtPackageTitle.Font = Nothing
		Me.txtPackageTitle.Name = "txtPackageTitle"
		Me.txtPackageTitle.ReadOnly = true
		'
		'txtVendor
		'
		Me.txtVendor.AccessibleDescription = Nothing
		Me.txtVendor.AccessibleName = Nothing
		resources.ApplyResources(Me.txtVendor, "txtVendor")
		Me.txtVendor.BackgroundImage = Nothing
		Me.txtVendor.Font = Nothing
		Me.txtVendor.Name = "txtVendor"
		Me.txtVendor.ReadOnly = true
		'
		'lblDescription
		'
		Me.lblDescription.AccessibleDescription = Nothing
		Me.lblDescription.AccessibleName = Nothing
		resources.ApplyResources(Me.lblDescription, "lblDescription")
		Me.lblDescription.Font = Nothing
		Me.lblDescription.Name = "lblDescription"
		'
		'lblRebootBehavior
		'
		Me.lblRebootBehavior.AccessibleDescription = Nothing
		Me.lblRebootBehavior.AccessibleName = Nothing
		resources.ApplyResources(Me.lblRebootBehavior, "lblRebootBehavior")
		Me.lblRebootBehavior.Font = Nothing
		Me.lblRebootBehavior.Name = "lblRebootBehavior"
		'
		'lblPackageTitle
		'
		Me.lblPackageTitle.AccessibleDescription = Nothing
		Me.lblPackageTitle.AccessibleName = Nothing
		resources.ApplyResources(Me.lblPackageTitle, "lblPackageTitle")
		Me.lblPackageTitle.Font = Nothing
		Me.lblPackageTitle.Name = "lblPackageTitle"
		'
		'txtClassification
		'
		Me.txtClassification.AccessibleDescription = Nothing
		Me.txtClassification.AccessibleName = Nothing
		resources.ApplyResources(Me.txtClassification, "txtClassification")
		Me.txtClassification.BackgroundImage = Nothing
		Me.txtClassification.Font = Nothing
		Me.txtClassification.Name = "txtClassification"
		Me.txtClassification.ReadOnly = true
		'
		'txtRebootBehavior
		'
		Me.txtRebootBehavior.AccessibleDescription = Nothing
		Me.txtRebootBehavior.AccessibleName = Nothing
		resources.ApplyResources(Me.txtRebootBehavior, "txtRebootBehavior")
		Me.txtRebootBehavior.BackgroundImage = Nothing
		Me.txtRebootBehavior.Font = Nothing
		Me.txtRebootBehavior.Name = "txtRebootBehavior"
		Me.txtRebootBehavior.ReadOnly = true
		'
		'txtServerity
		'
		Me.txtServerity.AccessibleDescription = Nothing
		Me.txtServerity.AccessibleName = Nothing
		resources.ApplyResources(Me.txtServerity, "txtServerity")
		Me.txtServerity.BackgroundImage = Nothing
		Me.txtServerity.Font = Nothing
		Me.txtServerity.Name = "txtServerity"
		Me.txtServerity.ReadOnly = true
		'
		'txtArticleID
		'
		Me.txtArticleID.AccessibleDescription = Nothing
		Me.txtArticleID.AccessibleName = Nothing
		resources.ApplyResources(Me.txtArticleID, "txtArticleID")
		Me.txtArticleID.BackgroundImage = Nothing
		Me.txtArticleID.Font = Nothing
		Me.txtArticleID.Name = "txtArticleID"
		Me.txtArticleID.ReadOnly = true
		'
		'txtBulletinID
		'
		Me.txtBulletinID.AccessibleDescription = Nothing
		Me.txtBulletinID.AccessibleName = Nothing
		resources.ApplyResources(Me.txtBulletinID, "txtBulletinID")
		Me.txtBulletinID.BackgroundImage = Nothing
		Me.txtBulletinID.Font = Nothing
		Me.txtBulletinID.Name = "txtBulletinID"
		Me.txtBulletinID.ReadOnly = true
		'
		'lblMoreInfoURL
		'
		Me.lblMoreInfoURL.AccessibleDescription = Nothing
		Me.lblMoreInfoURL.AccessibleName = Nothing
		resources.ApplyResources(Me.lblMoreInfoURL, "lblMoreInfoURL")
		Me.lblMoreInfoURL.Font = Nothing
		Me.lblMoreInfoURL.Name = "lblMoreInfoURL"
		'
		'txtCVEID
		'
		Me.txtCVEID.AccessibleDescription = Nothing
		Me.txtCVEID.AccessibleName = Nothing
		resources.ApplyResources(Me.txtCVEID, "txtCVEID")
		Me.txtCVEID.BackgroundImage = Nothing
		Me.txtCVEID.Font = Nothing
		Me.txtCVEID.Name = "txtCVEID"
		Me.txtCVEID.ReadOnly = true
		'
		'lblArticleID
		'
		Me.lblArticleID.AccessibleDescription = Nothing
		Me.lblArticleID.AccessibleName = Nothing
		resources.ApplyResources(Me.lblArticleID, "lblArticleID")
		Me.lblArticleID.Font = Nothing
		Me.lblArticleID.Name = "lblArticleID"
		'
		'txtMoreInfoURL
		'
		Me.txtMoreInfoURL.AccessibleDescription = Nothing
		Me.txtMoreInfoURL.AccessibleName = Nothing
		resources.ApplyResources(Me.txtMoreInfoURL, "txtMoreInfoURL")
		Me.txtMoreInfoURL.BackgroundImage = Nothing
		Me.txtMoreInfoURL.Font = Nothing
		Me.txtMoreInfoURL.Name = "txtMoreInfoURL"
		Me.txtMoreInfoURL.ReadOnly = true
		'
		'lblProduct
		'
		Me.lblProduct.AccessibleDescription = Nothing
		Me.lblProduct.AccessibleName = Nothing
		resources.ApplyResources(Me.lblProduct, "lblProduct")
		Me.lblProduct.Font = Nothing
		Me.lblProduct.Name = "lblProduct"
		'
		'lblCVEID
		'
		Me.lblCVEID.AccessibleDescription = Nothing
		Me.lblCVEID.AccessibleName = Nothing
		resources.ApplyResources(Me.lblCVEID, "lblCVEID")
		Me.lblCVEID.Font = Nothing
		Me.lblCVEID.Name = "lblCVEID"
		'
		'lblVendor
		'
		Me.lblVendor.AccessibleDescription = Nothing
		Me.lblVendor.AccessibleName = Nothing
		resources.ApplyResources(Me.lblVendor, "lblVendor")
		Me.lblVendor.Font = Nothing
		Me.lblVendor.Name = "lblVendor"
		'
		'lblSeverity
		'
		Me.lblSeverity.AccessibleDescription = Nothing
		Me.lblSeverity.AccessibleName = Nothing
		resources.ApplyResources(Me.lblSeverity, "lblSeverity")
		Me.lblSeverity.Font = Nothing
		Me.lblSeverity.Name = "lblSeverity"
		'
		'lblBullitinID
		'
		Me.lblBullitinID.AccessibleDescription = Nothing
		Me.lblBullitinID.AccessibleName = Nothing
		resources.ApplyResources(Me.lblBullitinID, "lblBullitinID")
		Me.lblBullitinID.Font = Nothing
		Me.lblBullitinID.Name = "lblBullitinID"
		'
		'lblClassification
		'
		Me.lblClassification.AccessibleDescription = Nothing
		Me.lblClassification.AccessibleName = Nothing
		resources.ApplyResources(Me.lblClassification, "lblClassification")
		Me.lblClassification.Font = Nothing
		Me.lblClassification.Name = "lblClassification"
		'
		'tabUpdateStatus
		'
		Me.tabUpdateStatus.AccessibleDescription = Nothing
		Me.tabUpdateStatus.AccessibleName = Nothing
		resources.ApplyResources(Me.tabUpdateStatus, "tabUpdateStatus")
		Me.tabUpdateStatus.BackgroundImage = Nothing
		Me.tabUpdateStatus.Controls.Add(Me.dgvUpdateStatus)
		Me.tabUpdateStatus.Font = Nothing
		Me.tabUpdateStatus.Name = "tabUpdateStatus"
		Me.tabUpdateStatus.UseVisualStyleBackColor = true
		'
		'dgvUpdateStatus
		'
		Me.dgvUpdateStatus.AccessibleDescription = Nothing
		Me.dgvUpdateStatus.AccessibleName = Nothing
		Me.dgvUpdateStatus.AllowUserToAddRows = false
		Me.dgvUpdateStatus.AllowUserToDeleteRows = false
		Me.dgvUpdateStatus.AllowUserToOrderColumns = true
		Me.dgvUpdateStatus.AllowUserToResizeRows = false
		resources.ApplyResources(Me.dgvUpdateStatus, "dgvUpdateStatus")
		Me.dgvUpdateStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.dgvUpdateStatus.BackgroundColor = System.Drawing.SystemColors.Window
		Me.dgvUpdateStatus.BackgroundImage = Nothing
		Me.dgvUpdateStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.dgvUpdateStatus.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
		Me.dgvUpdateStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvUpdateStatus.Font = Nothing
		Me.dgvUpdateStatus.Name = "dgvUpdateStatus"
		Me.dgvUpdateStatus.ReadOnly = true
		Me.dgvUpdateStatus.RowHeadersVisible = false
		Me.dgvUpdateStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		'
		'tabUpdateReport
		'
		Me.tabUpdateReport.AccessibleDescription = Nothing
		Me.tabUpdateReport.AccessibleName = Nothing
		resources.ApplyResources(Me.tabUpdateReport, "tabUpdateReport")
		Me.tabUpdateReport.BackgroundImage = Nothing
		Me.tabUpdateReport.Controls.Add(Me.btnUpdateRefreshReport)
		Me.tabUpdateReport.Controls.Add(Me.dgvUpdateReport)
		Me.tabUpdateReport.Controls.Add(Me.lblUpdateStatus)
		Me.tabUpdateReport.Controls.Add(Me.lblComputerGroup)
		Me.tabUpdateReport.Controls.Add(Me.cboUpdateStatus)
		Me.tabUpdateReport.Controls.Add(Me.cboTargetGroup)
		Me.tabUpdateReport.Font = Nothing
		Me.tabUpdateReport.Name = "tabUpdateReport"
		Me.tabUpdateReport.UseVisualStyleBackColor = true
		'
		'btnUpdateRefreshReport
		'
		Me.btnUpdateRefreshReport.AccessibleDescription = Nothing
		Me.btnUpdateRefreshReport.AccessibleName = Nothing
		resources.ApplyResources(Me.btnUpdateRefreshReport, "btnUpdateRefreshReport")
		Me.btnUpdateRefreshReport.BackgroundImage = Nothing
		Me.btnUpdateRefreshReport.Font = Nothing
		Me.btnUpdateRefreshReport.Name = "btnUpdateRefreshReport"
		Me.btnUpdateRefreshReport.UseVisualStyleBackColor = true
		AddHandler Me.btnUpdateRefreshReport.Click, AddressOf Me.BtnUpdateRefreshReportClick
		'
		'dgvUpdateReport
		'
		Me.dgvUpdateReport.AccessibleDescription = Nothing
		Me.dgvUpdateReport.AccessibleName = Nothing
		Me.dgvUpdateReport.AllowUserToAddRows = false
		Me.dgvUpdateReport.AllowUserToDeleteRows = false
		Me.dgvUpdateReport.AllowUserToOrderColumns = true
		Me.dgvUpdateReport.AllowUserToResizeRows = false
		resources.ApplyResources(Me.dgvUpdateReport, "dgvUpdateReport")
		Me.dgvUpdateReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.dgvUpdateReport.BackgroundColor = System.Drawing.SystemColors.Window
		Me.dgvUpdateReport.BackgroundImage = Nothing
		Me.dgvUpdateReport.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.dgvUpdateReport.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
		Me.dgvUpdateReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvUpdateReport.Font = Nothing
		Me.dgvUpdateReport.Name = "dgvUpdateReport"
		Me.dgvUpdateReport.ReadOnly = true
		Me.dgvUpdateReport.RowHeadersVisible = false
		Me.dgvUpdateReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		AddHandler Me.dgvUpdateReport.Sorted, AddressOf Me.DgvUpdateReportSorted
		AddHandler Me.dgvUpdateReport.CellMouseDown, AddressOf Me.DgvUpdateReportCellMouseDown
		'
		'lblUpdateStatus
		'
		Me.lblUpdateStatus.AccessibleDescription = Nothing
		Me.lblUpdateStatus.AccessibleName = Nothing
		resources.ApplyResources(Me.lblUpdateStatus, "lblUpdateStatus")
		Me.lblUpdateStatus.Font = Nothing
		Me.lblUpdateStatus.Name = "lblUpdateStatus"
		'
		'lblComputerGroup
		'
		Me.lblComputerGroup.AccessibleDescription = Nothing
		Me.lblComputerGroup.AccessibleName = Nothing
		resources.ApplyResources(Me.lblComputerGroup, "lblComputerGroup")
		Me.lblComputerGroup.Font = Nothing
		Me.lblComputerGroup.Name = "lblComputerGroup"
		'
		'cboUpdateStatus
		'
		Me.cboUpdateStatus.AccessibleDescription = Nothing
		Me.cboUpdateStatus.AccessibleName = Nothing
		resources.ApplyResources(Me.cboUpdateStatus, "cboUpdateStatus")
		Me.cboUpdateStatus.BackgroundImage = Nothing
		Me.cboUpdateStatus.Font = Nothing
		Me.cboUpdateStatus.FormattingEnabled = true
		Me.cboUpdateStatus.Name = "cboUpdateStatus"
		AddHandler Me.cboUpdateStatus.SelectedIndexChanged, AddressOf Me.cboUpdateStatusSelectedIndexChanged
		'
		'cboTargetGroup
		'
		Me.cboTargetGroup.AccessibleDescription = Nothing
		Me.cboTargetGroup.AccessibleName = Nothing
		resources.ApplyResources(Me.cboTargetGroup, "cboTargetGroup")
		Me.cboTargetGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
		Me.cboTargetGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cboTargetGroup.BackgroundImage = Nothing
		Me.cboTargetGroup.Font = Nothing
		Me.cboTargetGroup.FormattingEnabled = true
		Me.cboTargetGroup.Name = "cboTargetGroup"
		AddHandler Me.cboTargetGroup.SelectedIndexChanged, AddressOf Me.CboTargetGroupSelectedIndexChanged
		'
		'pnlComputers
		'
		Me.pnlComputers.AccessibleDescription = Nothing
		Me.pnlComputers.AccessibleName = Nothing
		resources.ApplyResources(Me.pnlComputers, "pnlComputers")
		Me.pnlComputers.BackgroundImage = Nothing
		Me.pnlComputers.Controls.Add(Me.tabMainComputers)
		Me.pnlComputers.Font = Nothing
		Me.pnlComputers.Name = "pnlComputers"
		'
		'tabMainComputers
		'
		Me.tabMainComputers.AccessibleDescription = Nothing
		Me.tabMainComputers.AccessibleName = Nothing
		resources.ApplyResources(Me.tabMainComputers, "tabMainComputers")
		Me.tabMainComputers.BackgroundImage = Nothing
		Me.tabMainComputers.Controls.Add(Me.tabComputerInfo)
		Me.tabMainComputers.Controls.Add(Me.tabComputerStatus)
		Me.tabMainComputers.Controls.Add(Me.tabComputerReport)
		Me.tabMainComputers.Font = Nothing
		Me.tabMainComputers.Name = "tabMainComputers"
		Me.tabMainComputers.SelectedIndex = 0
		'
		'tabComputerInfo
		'
		Me.tabComputerInfo.AccessibleDescription = Nothing
		Me.tabComputerInfo.AccessibleName = Nothing
		resources.ApplyResources(Me.tabComputerInfo, "tabComputerInfo")
		Me.tabComputerInfo.BackColor = System.Drawing.Color.Transparent
		Me.tabComputerInfo.BackgroundImage = Nothing
		Me.tabComputerInfo.Controls.Add(Me.txtUpdatesNeededNum)
		Me.tabComputerInfo.Controls.Add(Me.txtUpdatesInstalledorNANum)
		Me.tabComputerInfo.Controls.Add(Me.txtUpdateNoStatusNum)
		Me.tabComputerInfo.Controls.Add(Me.txtUpdatesWErrorsNum)
		Me.tabComputerInfo.Controls.Add(Me.lblUpdateNoStatus)
		Me.tabComputerInfo.Controls.Add(Me.lblUpdatesInstalledorNA)
		Me.tabComputerInfo.Controls.Add(Me.lblUpdatesNeeded)
		Me.tabComputerInfo.Controls.Add(Me.lblUpdatesWErrors)
		Me.tabComputerInfo.Font = Nothing
		Me.tabComputerInfo.Name = "tabComputerInfo"
		'
		'txtUpdatesNeededNum
		'
		Me.txtUpdatesNeededNum.AccessibleDescription = Nothing
		Me.txtUpdatesNeededNum.AccessibleName = Nothing
		resources.ApplyResources(Me.txtUpdatesNeededNum, "txtUpdatesNeededNum")
		Me.txtUpdatesNeededNum.BackColor = System.Drawing.SystemColors.Control
		Me.txtUpdatesNeededNum.BackgroundImage = Nothing
		Me.txtUpdatesNeededNum.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.txtUpdatesNeededNum.Font = Nothing
		Me.txtUpdatesNeededNum.Name = "txtUpdatesNeededNum"
		Me.txtUpdatesNeededNum.ReadOnly = true
		'
		'txtUpdatesInstalledorNANum
		'
		Me.txtUpdatesInstalledorNANum.AccessibleDescription = Nothing
		Me.txtUpdatesInstalledorNANum.AccessibleName = Nothing
		resources.ApplyResources(Me.txtUpdatesInstalledorNANum, "txtUpdatesInstalledorNANum")
		Me.txtUpdatesInstalledorNANum.BackColor = System.Drawing.SystemColors.Control
		Me.txtUpdatesInstalledorNANum.BackgroundImage = Nothing
		Me.txtUpdatesInstalledorNANum.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.txtUpdatesInstalledorNANum.Font = Nothing
		Me.txtUpdatesInstalledorNANum.Name = "txtUpdatesInstalledorNANum"
		Me.txtUpdatesInstalledorNANum.ReadOnly = true
		'
		'txtUpdateNoStatusNum
		'
		Me.txtUpdateNoStatusNum.AccessibleDescription = Nothing
		Me.txtUpdateNoStatusNum.AccessibleName = Nothing
		resources.ApplyResources(Me.txtUpdateNoStatusNum, "txtUpdateNoStatusNum")
		Me.txtUpdateNoStatusNum.BackColor = System.Drawing.SystemColors.Control
		Me.txtUpdateNoStatusNum.BackgroundImage = Nothing
		Me.txtUpdateNoStatusNum.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.txtUpdateNoStatusNum.Font = Nothing
		Me.txtUpdateNoStatusNum.Name = "txtUpdateNoStatusNum"
		Me.txtUpdateNoStatusNum.ReadOnly = true
		'
		'txtUpdatesWErrorsNum
		'
		Me.txtUpdatesWErrorsNum.AccessibleDescription = Nothing
		Me.txtUpdatesWErrorsNum.AccessibleName = Nothing
		resources.ApplyResources(Me.txtUpdatesWErrorsNum, "txtUpdatesWErrorsNum")
		Me.txtUpdatesWErrorsNum.BackColor = System.Drawing.SystemColors.Control
		Me.txtUpdatesWErrorsNum.BackgroundImage = Nothing
		Me.txtUpdatesWErrorsNum.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.txtUpdatesWErrorsNum.Font = Nothing
		Me.txtUpdatesWErrorsNum.Name = "txtUpdatesWErrorsNum"
		Me.txtUpdatesWErrorsNum.ReadOnly = true
		'
		'lblUpdateNoStatus
		'
		Me.lblUpdateNoStatus.AccessibleDescription = Nothing
		Me.lblUpdateNoStatus.AccessibleName = Nothing
		resources.ApplyResources(Me.lblUpdateNoStatus, "lblUpdateNoStatus")
		Me.lblUpdateNoStatus.Font = Nothing
		Me.lblUpdateNoStatus.Name = "lblUpdateNoStatus"
		'
		'lblUpdatesInstalledorNA
		'
		Me.lblUpdatesInstalledorNA.AccessibleDescription = Nothing
		Me.lblUpdatesInstalledorNA.AccessibleName = Nothing
		resources.ApplyResources(Me.lblUpdatesInstalledorNA, "lblUpdatesInstalledorNA")
		Me.lblUpdatesInstalledorNA.Font = Nothing
		Me.lblUpdatesInstalledorNA.Name = "lblUpdatesInstalledorNA"
		'
		'lblUpdatesNeeded
		'
		Me.lblUpdatesNeeded.AccessibleDescription = Nothing
		Me.lblUpdatesNeeded.AccessibleName = Nothing
		resources.ApplyResources(Me.lblUpdatesNeeded, "lblUpdatesNeeded")
		Me.lblUpdatesNeeded.Font = Nothing
		Me.lblUpdatesNeeded.Name = "lblUpdatesNeeded"
		'
		'lblUpdatesWErrors
		'
		Me.lblUpdatesWErrors.AccessibleDescription = Nothing
		Me.lblUpdatesWErrors.AccessibleName = Nothing
		resources.ApplyResources(Me.lblUpdatesWErrors, "lblUpdatesWErrors")
		Me.lblUpdatesWErrors.Font = Nothing
		Me.lblUpdatesWErrors.Name = "lblUpdatesWErrors"
		'
		'tabComputerStatus
		'
		Me.tabComputerStatus.AccessibleDescription = Nothing
		Me.tabComputerStatus.AccessibleName = Nothing
		resources.ApplyResources(Me.tabComputerStatus, "tabComputerStatus")
		Me.tabComputerStatus.BackgroundImage = Nothing
		Me.tabComputerStatus.Controls.Add(Me.dgvComputerGroupStatus)
		Me.tabComputerStatus.Font = Nothing
		Me.tabComputerStatus.Name = "tabComputerStatus"
		Me.tabComputerStatus.UseVisualStyleBackColor = true
		'
		'dgvComputerGroupStatus
		'
		Me.dgvComputerGroupStatus.AccessibleDescription = Nothing
		Me.dgvComputerGroupStatus.AccessibleName = Nothing
		Me.dgvComputerGroupStatus.AllowUserToAddRows = false
		Me.dgvComputerGroupStatus.AllowUserToDeleteRows = false
		Me.dgvComputerGroupStatus.AllowUserToOrderColumns = true
		Me.dgvComputerGroupStatus.AllowUserToResizeRows = false
		resources.ApplyResources(Me.dgvComputerGroupStatus, "dgvComputerGroupStatus")
		Me.dgvComputerGroupStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.dgvComputerGroupStatus.BackgroundColor = System.Drawing.SystemColors.Window
		Me.dgvComputerGroupStatus.BackgroundImage = Nothing
		Me.dgvComputerGroupStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.dgvComputerGroupStatus.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
		Me.dgvComputerGroupStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvComputerGroupStatus.Font = Nothing
		Me.dgvComputerGroupStatus.Name = "dgvComputerGroupStatus"
		Me.dgvComputerGroupStatus.ReadOnly = true
		Me.dgvComputerGroupStatus.RowHeadersVisible = false
		Me.dgvComputerGroupStatus.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
		Me.dgvComputerGroupStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		'
		'tabComputerReport
		'
		Me.tabComputerReport.AccessibleDescription = Nothing
		Me.tabComputerReport.AccessibleName = Nothing
		resources.ApplyResources(Me.tabComputerReport, "tabComputerReport")
		Me.tabComputerReport.BackgroundImage = Nothing
		Me.tabComputerReport.Controls.Add(Me.btnComputerRefreshReport)
		Me.tabComputerReport.Controls.Add(Me.dgvComputerReport)
		Me.tabComputerReport.Controls.Add(Me.lblComputerUpdateStatus)
		Me.tabComputerReport.Font = Nothing
		Me.tabComputerReport.Name = "tabComputerReport"
		Me.tabComputerReport.UseVisualStyleBackColor = true
		'
		'btnComputerRefreshReport
		'
		Me.btnComputerRefreshReport.AccessibleDescription = Nothing
		Me.btnComputerRefreshReport.AccessibleName = Nothing
		resources.ApplyResources(Me.btnComputerRefreshReport, "btnComputerRefreshReport")
		Me.btnComputerRefreshReport.BackgroundImage = Nothing
		Me.btnComputerRefreshReport.Font = Nothing
		Me.btnComputerRefreshReport.Name = "btnComputerRefreshReport"
		Me.btnComputerRefreshReport.UseVisualStyleBackColor = true
		AddHandler Me.btnComputerRefreshReport.Click, AddressOf Me.BtnComputerRefreshReportClick
		'
		'dgvComputerReport
		'
		Me.dgvComputerReport.AccessibleDescription = Nothing
		Me.dgvComputerReport.AccessibleName = Nothing
		Me.dgvComputerReport.AllowUserToAddRows = false
		Me.dgvComputerReport.AllowUserToDeleteRows = false
		Me.dgvComputerReport.AllowUserToOrderColumns = true
		Me.dgvComputerReport.AllowUserToResizeRows = false
		resources.ApplyResources(Me.dgvComputerReport, "dgvComputerReport")
		Me.dgvComputerReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.dgvComputerReport.BackgroundColor = System.Drawing.SystemColors.Window
		Me.dgvComputerReport.BackgroundImage = Nothing
		Me.dgvComputerReport.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.dgvComputerReport.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
		Me.dgvComputerReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvComputerReport.Font = Nothing
		Me.dgvComputerReport.Name = "dgvComputerReport"
		Me.dgvComputerReport.ReadOnly = true
		Me.dgvComputerReport.RowHeadersVisible = false
		Me.dgvComputerReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		AddHandler Me.dgvComputerReport.Sorted, AddressOf Me.DgvComputerReportSorted
		AddHandler Me.dgvComputerReport.CellMouseDown, AddressOf Me.DgvComputerReportCellMouseDown
		'
		'lblComputerUpdateStatus
		'
		Me.lblComputerUpdateStatus.AccessibleDescription = Nothing
		Me.lblComputerUpdateStatus.AccessibleName = Nothing
		resources.ApplyResources(Me.lblComputerUpdateStatus, "lblComputerUpdateStatus")
		Me.lblComputerUpdateStatus.Font = Nothing
		Me.lblComputerUpdateStatus.Name = "lblComputerUpdateStatus"
		'
		'menuStrip
		'
		Me.menuStrip.AccessibleDescription = Nothing
		Me.menuStrip.AccessibleName = Nothing
		resources.ApplyResources(Me.menuStrip, "menuStrip")
		Me.menuStrip.BackgroundImage = Nothing
		Me.menuStrip.Font = Nothing
		Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.toolsToolStripMenuItem, Me.updateToolStripMenuItem, Me.helpToolStripMenuItem})
		Me.menuStrip.Name = "menuStrip"
		'
		'fileToolStripMenuItem
		'
		Me.fileToolStripMenuItem.AccessibleDescription = Nothing
		Me.fileToolStripMenuItem.AccessibleName = Nothing
		resources.ApplyResources(Me.fileToolStripMenuItem, "fileToolStripMenuItem")
		Me.fileToolStripMenuItem.BackgroundImage = Nothing
		Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.importCatalogToolStripMenuItem, Me.exportCatalogToolStripMenuItem, Me.toolStripSeparator3, Me.exportListToolStripMenuItem, Me.exportReportToolStripMenuItem, Me.toolStripSeparator2, Me.exitToolStripMenuItem})
		Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
		Me.fileToolStripMenuItem.ShortcutKeyDisplayString = Nothing
		'
		'importCatalogToolStripMenuItem
		'
		Me.importCatalogToolStripMenuItem.AccessibleDescription = Nothing
		Me.importCatalogToolStripMenuItem.AccessibleName = Nothing
		resources.ApplyResources(Me.importCatalogToolStripMenuItem, "importCatalogToolStripMenuItem")
		Me.importCatalogToolStripMenuItem.BackgroundImage = Nothing
		Me.importCatalogToolStripMenuItem.Name = "importCatalogToolStripMenuItem"
		Me.importCatalogToolStripMenuItem.ShortcutKeyDisplayString = Nothing
		AddHandler Me.importCatalogToolStripMenuItem.Click, AddressOf Me.ImportCatalogToolStripMenuItemClick
		'
		'exportCatalogToolStripMenuItem
		'
		Me.exportCatalogToolStripMenuItem.AccessibleDescription = Nothing
		Me.exportCatalogToolStripMenuItem.AccessibleName = Nothing
		resources.ApplyResources(Me.exportCatalogToolStripMenuItem, "exportCatalogToolStripMenuItem")
		Me.exportCatalogToolStripMenuItem.BackgroundImage = Nothing
		Me.exportCatalogToolStripMenuItem.Name = "exportCatalogToolStripMenuItem"
		Me.exportCatalogToolStripMenuItem.ShortcutKeyDisplayString = Nothing
		AddHandler Me.exportCatalogToolStripMenuItem.Click, AddressOf Me.ExportCatalogToolStripMenuItemClick
		'
		'toolStripSeparator3
		'
		Me.toolStripSeparator3.AccessibleDescription = Nothing
		Me.toolStripSeparator3.AccessibleName = Nothing
		resources.ApplyResources(Me.toolStripSeparator3, "toolStripSeparator3")
		Me.toolStripSeparator3.Name = "toolStripSeparator3"
		'
		'exportListToolStripMenuItem
		'
		Me.exportListToolStripMenuItem.AccessibleDescription = Nothing
		Me.exportListToolStripMenuItem.AccessibleName = Nothing
		resources.ApplyResources(Me.exportListToolStripMenuItem, "exportListToolStripMenuItem")
		Me.exportListToolStripMenuItem.BackgroundImage = Nothing
		Me.exportListToolStripMenuItem.Name = "exportListToolStripMenuItem"
		Me.exportListToolStripMenuItem.ShortcutKeyDisplayString = Nothing
		AddHandler Me.exportListToolStripMenuItem.Click, AddressOf Me.ExportListToolStripMenuItemClick
		'
		'exportReportToolStripMenuItem
		'
		Me.exportReportToolStripMenuItem.AccessibleDescription = Nothing
		Me.exportReportToolStripMenuItem.AccessibleName = Nothing
		resources.ApplyResources(Me.exportReportToolStripMenuItem, "exportReportToolStripMenuItem")
		Me.exportReportToolStripMenuItem.BackgroundImage = Nothing
		Me.exportReportToolStripMenuItem.Name = "exportReportToolStripMenuItem"
		Me.exportReportToolStripMenuItem.ShortcutKeyDisplayString = Nothing
		AddHandler Me.exportReportToolStripMenuItem.Click, AddressOf Me.ExportReportToolStripMenuItemClick
		'
		'toolStripSeparator2
		'
		Me.toolStripSeparator2.AccessibleDescription = Nothing
		Me.toolStripSeparator2.AccessibleName = Nothing
		resources.ApplyResources(Me.toolStripSeparator2, "toolStripSeparator2")
		Me.toolStripSeparator2.Name = "toolStripSeparator2"
		'
		'exitToolStripMenuItem
		'
		Me.exitToolStripMenuItem.AccessibleDescription = Nothing
		Me.exitToolStripMenuItem.AccessibleName = Nothing
		resources.ApplyResources(Me.exitToolStripMenuItem, "exitToolStripMenuItem")
		Me.exitToolStripMenuItem.BackgroundImage = Nothing
		Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
		Me.exitToolStripMenuItem.ShortcutKeyDisplayString = Nothing
		AddHandler Me.exitToolStripMenuItem.Click, AddressOf Me.ExitToolStripMenuItemClick
		'
		'toolsToolStripMenuItem
		'
		Me.toolsToolStripMenuItem.AccessibleDescription = Nothing
		Me.toolsToolStripMenuItem.AccessibleName = Nothing
		resources.ApplyResources(Me.toolsToolStripMenuItem, "toolsToolStripMenuItem")
		Me.toolsToolStripMenuItem.BackgroundImage = Nothing
		Me.toolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.createUpdateToolStripMenuItem, Me.importUpdateToolStripMenuItem, Me.exportUpdateToolStripMenuItem, Me.toolStripSeparator1, Me.savedRulesToolStripMenuItem, Me.certificateInfoToolStripMenuItem, Me.connectionSettingsToolStripMenuItem, Me.optionsToolStripMenuItem})
		Me.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem"
		Me.toolsToolStripMenuItem.ShortcutKeyDisplayString = Nothing
		'
		'createUpdateToolStripMenuItem
		'
		Me.createUpdateToolStripMenuItem.AccessibleDescription = Nothing
		Me.createUpdateToolStripMenuItem.AccessibleName = Nothing
		resources.ApplyResources(Me.createUpdateToolStripMenuItem, "createUpdateToolStripMenuItem")
		Me.createUpdateToolStripMenuItem.BackgroundImage = Nothing
		Me.createUpdateToolStripMenuItem.Name = "createUpdateToolStripMenuItem"
		Me.createUpdateToolStripMenuItem.ShortcutKeyDisplayString = Nothing
		AddHandler Me.createUpdateToolStripMenuItem.Click, AddressOf Me.CreateUpdateToolStripMenuItemClick
		'
		'importUpdateToolStripMenuItem
		'
		Me.importUpdateToolStripMenuItem.AccessibleDescription = Nothing
		Me.importUpdateToolStripMenuItem.AccessibleName = Nothing
		resources.ApplyResources(Me.importUpdateToolStripMenuItem, "importUpdateToolStripMenuItem")
		Me.importUpdateToolStripMenuItem.BackgroundImage = Nothing
		Me.importUpdateToolStripMenuItem.Name = "importUpdateToolStripMenuItem"
		Me.importUpdateToolStripMenuItem.ShortcutKeyDisplayString = Nothing
		AddHandler Me.importUpdateToolStripMenuItem.Click, AddressOf Me.ImportUpdateToolStripMenuItemClick
		'
		'exportUpdateToolStripMenuItem
		'
		Me.exportUpdateToolStripMenuItem.AccessibleDescription = Nothing
		Me.exportUpdateToolStripMenuItem.AccessibleName = Nothing
		resources.ApplyResources(Me.exportUpdateToolStripMenuItem, "exportUpdateToolStripMenuItem")
		Me.exportUpdateToolStripMenuItem.BackgroundImage = Nothing
		Me.exportUpdateToolStripMenuItem.Name = "exportUpdateToolStripMenuItem"
		Me.exportUpdateToolStripMenuItem.ShortcutKeyDisplayString = Nothing
		AddHandler Me.exportUpdateToolStripMenuItem.Click, AddressOf Me.ExportUpdateToolStripMenuItemClick
		'
		'toolStripSeparator1
		'
		Me.toolStripSeparator1.AccessibleDescription = Nothing
		Me.toolStripSeparator1.AccessibleName = Nothing
		resources.ApplyResources(Me.toolStripSeparator1, "toolStripSeparator1")
		Me.toolStripSeparator1.Name = "toolStripSeparator1"
		'
		'savedRulesToolStripMenuItem
		'
		Me.savedRulesToolStripMenuItem.AccessibleDescription = Nothing
		Me.savedRulesToolStripMenuItem.AccessibleName = Nothing
		resources.ApplyResources(Me.savedRulesToolStripMenuItem, "savedRulesToolStripMenuItem")
		Me.savedRulesToolStripMenuItem.BackgroundImage = Nothing
		Me.savedRulesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.manageRulesToolStripMenuItem, Me.importRulesToolStripMenuItem, Me.exportRulesToolStripMenuItem})
		Me.savedRulesToolStripMenuItem.Name = "savedRulesToolStripMenuItem"
		Me.savedRulesToolStripMenuItem.ShortcutKeyDisplayString = Nothing
		'
		'manageRulesToolStripMenuItem
		'
		Me.manageRulesToolStripMenuItem.AccessibleDescription = Nothing
		Me.manageRulesToolStripMenuItem.AccessibleName = Nothing
		resources.ApplyResources(Me.manageRulesToolStripMenuItem, "manageRulesToolStripMenuItem")
		Me.manageRulesToolStripMenuItem.BackgroundImage = Nothing
		Me.manageRulesToolStripMenuItem.Name = "manageRulesToolStripMenuItem"
		Me.manageRulesToolStripMenuItem.ShortcutKeyDisplayString = Nothing
		AddHandler Me.manageRulesToolStripMenuItem.Click, AddressOf Me.ManageRulesToolStripMenuItemClick
		'
		'importRulesToolStripMenuItem
		'
		Me.importRulesToolStripMenuItem.AccessibleDescription = Nothing
		Me.importRulesToolStripMenuItem.AccessibleName = Nothing
		resources.ApplyResources(Me.importRulesToolStripMenuItem, "importRulesToolStripMenuItem")
		Me.importRulesToolStripMenuItem.BackgroundImage = Nothing
		Me.importRulesToolStripMenuItem.Name = "importRulesToolStripMenuItem"
		Me.importRulesToolStripMenuItem.ShortcutKeyDisplayString = Nothing
		AddHandler Me.importRulesToolStripMenuItem.Click, AddressOf Me.ImportRulesToolStripMenuItemClick
		'
		'exportRulesToolStripMenuItem
		'
		Me.exportRulesToolStripMenuItem.AccessibleDescription = Nothing
		Me.exportRulesToolStripMenuItem.AccessibleName = Nothing
		resources.ApplyResources(Me.exportRulesToolStripMenuItem, "exportRulesToolStripMenuItem")
		Me.exportRulesToolStripMenuItem.BackgroundImage = Nothing
		Me.exportRulesToolStripMenuItem.Name = "exportRulesToolStripMenuItem"
		Me.exportRulesToolStripMenuItem.ShortcutKeyDisplayString = Nothing
		AddHandler Me.exportRulesToolStripMenuItem.Click, AddressOf Me.ExportRulesToolStripMenuItemClick
		'
		'certificateInfoToolStripMenuItem
		'
		Me.certificateInfoToolStripMenuItem.AccessibleDescription = Nothing
		Me.certificateInfoToolStripMenuItem.AccessibleName = Nothing
		resources.ApplyResources(Me.certificateInfoToolStripMenuItem, "certificateInfoToolStripMenuItem")
		Me.certificateInfoToolStripMenuItem.BackgroundImage = Nothing
		Me.certificateInfoToolStripMenuItem.Name = "certificateInfoToolStripMenuItem"
		Me.certificateInfoToolStripMenuItem.ShortcutKeyDisplayString = Nothing
		AddHandler Me.certificateInfoToolStripMenuItem.Click, AddressOf Me.CertificateInfoToolStripMenuItemClick
		'
		'connectionSettingsToolStripMenuItem
		'
		Me.connectionSettingsToolStripMenuItem.AccessibleDescription = Nothing
		Me.connectionSettingsToolStripMenuItem.AccessibleName = Nothing
		resources.ApplyResources(Me.connectionSettingsToolStripMenuItem, "connectionSettingsToolStripMenuItem")
		Me.connectionSettingsToolStripMenuItem.BackgroundImage = Nothing
		Me.connectionSettingsToolStripMenuItem.Name = "connectionSettingsToolStripMenuItem"
		Me.connectionSettingsToolStripMenuItem.ShortcutKeyDisplayString = Nothing
		AddHandler Me.connectionSettingsToolStripMenuItem.Click, AddressOf Me.ConnectionSettingsToolStripMenuItemClick
		'
		'optionsToolStripMenuItem
		'
		Me.optionsToolStripMenuItem.AccessibleDescription = Nothing
		Me.optionsToolStripMenuItem.AccessibleName = Nothing
		resources.ApplyResources(Me.optionsToolStripMenuItem, "optionsToolStripMenuItem")
		Me.optionsToolStripMenuItem.BackgroundImage = Nothing
		Me.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem"
		Me.optionsToolStripMenuItem.ShortcutKeyDisplayString = Nothing
		AddHandler Me.optionsToolStripMenuItem.Click, AddressOf Me.OptionsToolStripMenuItemClick
		'
		'updateToolStripMenuItem
		'
		Me.updateToolStripMenuItem.AccessibleDescription = Nothing
		Me.updateToolStripMenuItem.AccessibleName = Nothing
		resources.ApplyResources(Me.updateToolStripMenuItem, "updateToolStripMenuItem")
		Me.updateToolStripMenuItem.BackgroundImage = Nothing
		Me.updateToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Replace
		Me.updateToolStripMenuItem.Name = "updateToolStripMenuItem"
		Me.updateToolStripMenuItem.ShortcutKeyDisplayString = Nothing
		'
		'helpToolStripMenuItem
		'
		Me.helpToolStripMenuItem.AccessibleDescription = Nothing
		Me.helpToolStripMenuItem.AccessibleName = Nothing
		resources.ApplyResources(Me.helpToolStripMenuItem, "helpToolStripMenuItem")
		Me.helpToolStripMenuItem.BackgroundImage = Nothing
		Me.helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.aboutToolStripMenuItem, Me.helpForumsToolStripMenuItem, Me.lupHelpToolStripMenuItem})
		Me.helpToolStripMenuItem.Name = "helpToolStripMenuItem"
		Me.helpToolStripMenuItem.ShortcutKeyDisplayString = Nothing
		'
		'aboutToolStripMenuItem
		'
		Me.aboutToolStripMenuItem.AccessibleDescription = Nothing
		Me.aboutToolStripMenuItem.AccessibleName = Nothing
		resources.ApplyResources(Me.aboutToolStripMenuItem, "aboutToolStripMenuItem")
		Me.aboutToolStripMenuItem.BackgroundImage = Nothing
		Me.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem"
		Me.aboutToolStripMenuItem.ShortcutKeyDisplayString = Nothing
		AddHandler Me.aboutToolStripMenuItem.Click, AddressOf Me.AboutToolStripMenuItemClick
		'
		'helpForumsToolStripMenuItem
		'
		Me.helpForumsToolStripMenuItem.AccessibleDescription = Nothing
		Me.helpForumsToolStripMenuItem.AccessibleName = Nothing
		resources.ApplyResources(Me.helpForumsToolStripMenuItem, "helpForumsToolStripMenuItem")
		Me.helpForumsToolStripMenuItem.BackgroundImage = Nothing
		Me.helpForumsToolStripMenuItem.Name = "helpForumsToolStripMenuItem"
		Me.helpForumsToolStripMenuItem.ShortcutKeyDisplayString = Nothing
		AddHandler Me.helpForumsToolStripMenuItem.Click, AddressOf Me.HelpForumsToolStripMenuItemClick
		'
		'lupHelpToolStripMenuItem
		'
		Me.lupHelpToolStripMenuItem.AccessibleDescription = Nothing
		Me.lupHelpToolStripMenuItem.AccessibleName = Nothing
		resources.ApplyResources(Me.lupHelpToolStripMenuItem, "lupHelpToolStripMenuItem")
		Me.lupHelpToolStripMenuItem.BackgroundImage = Nothing
		Me.lupHelpToolStripMenuItem.Name = "lupHelpToolStripMenuItem"
		Me.lupHelpToolStripMenuItem.ShortcutKeyDisplayString = Nothing
		AddHandler Me.lupHelpToolStripMenuItem.Click, AddressOf Me.LupHelpToolStripMenuItemClick
		'
		'cmDgvMain
		'
		Me.cmDgvMain.AccessibleDescription = Nothing
		Me.cmDgvMain.AccessibleName = Nothing
		resources.ApplyResources(Me.cmDgvMain, "cmDgvMain")
		Me.cmDgvMain.BackgroundImage = Nothing
		Me.cmDgvMain.Font = Nothing
		Me.cmDgvMain.Name = "Data Grid Context Menu"
		'
		'statusStrip
		'
		Me.statusStrip.AccessibleDescription = Nothing
		Me.statusStrip.AccessibleName = Nothing
		resources.ApplyResources(Me.statusStrip, "statusStrip")
		Me.statusStrip.BackgroundImage = Nothing
		Me.statusStrip.Font = Nothing
		Me.statusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusLabel, Me.toolStripStatusLabelLink})
		Me.statusStrip.Name = "statusStrip"
		'
		'toolStripStatusLabel
		'
		Me.toolStripStatusLabel.AccessibleDescription = Nothing
		Me.toolStripStatusLabel.AccessibleName = Nothing
		resources.ApplyResources(Me.toolStripStatusLabel, "toolStripStatusLabel")
		Me.toolStripStatusLabel.BackgroundImage = Nothing
		Me.toolStripStatusLabel.Name = "toolStripStatusLabel"
		Me.toolStripStatusLabel.Spring = true
		'
		'toolStripStatusLabelLink
		'
		Me.toolStripStatusLabelLink.AccessibleDescription = Nothing
		Me.toolStripStatusLabelLink.AccessibleName = Nothing
		resources.ApplyResources(Me.toolStripStatusLabelLink, "toolStripStatusLabelLink")
		Me.toolStripStatusLabelLink.BackgroundImage = Nothing
		Me.toolStripStatusLabelLink.IsLink = true
		Me.toolStripStatusLabelLink.Name = "toolStripStatusLabelLink"
		Me.toolStripStatusLabelLink.Spring = true
		AddHandler Me.toolStripStatusLabelLink.Click, AddressOf Me.ToolStripStatusLabelLinkClick
		'
		'importFileDialog
		'
		resources.ApplyResources(Me.importFileDialog, "importFileDialog")
		'
		'exportFileDialog
		'
		Me.exportFileDialog.DefaultExt = "tab"
		resources.ApplyResources(Me.exportFileDialog, "exportFileDialog")
		'
		'MainForm
		'
		Me.AccessibleDescription = Nothing
		Me.AccessibleName = Nothing
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackgroundImage = Nothing
		Me.Controls.Add(Me.statusStrip)
		Me.Controls.Add(Me.menuStrip)
		Me.Controls.Add(Me.splitContainerVert)
		Me.Font = Nothing
		Me.MainMenuStrip = Me.menuStrip
		Me.Name = "MainForm"
		AddHandler Load, AddressOf Me.MainFormLoad
		AddHandler Activated, AddressOf Me.MainFormActivated
		AddHandler FormClosing, AddressOf Me.MainFormFormClosing
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
		Me.pnlUpdates.ResumeLayout(false)
		Me.tabMainUpdates.ResumeLayout(false)
		Me.tabUpdateInfo.ResumeLayout(false)
		Me.tabUpdateInfo.PerformLayout
		Me.tabUpdateStatus.ResumeLayout(false)
		CType(Me.dgvUpdateStatus,System.ComponentModel.ISupportInitialize).EndInit
		Me.tabUpdateReport.ResumeLayout(false)
		CType(Me.dgvUpdateReport,System.ComponentModel.ISupportInitialize).EndInit
		Me.pnlComputers.ResumeLayout(false)
		Me.tabMainComputers.ResumeLayout(false)
		Me.tabComputerInfo.ResumeLayout(false)
		Me.tabComputerInfo.PerformLayout
		Me.tabComputerStatus.ResumeLayout(false)
		CType(Me.dgvComputerGroupStatus,System.ComponentModel.ISupportInitialize).EndInit
		Me.tabComputerReport.ResumeLayout(false)
		CType(Me.dgvComputerReport,System.ComponentModel.ISupportInitialize).EndInit
		Me.menuStrip.ResumeLayout(false)
		Me.menuStrip.PerformLayout
		Me.statusStrip.ResumeLayout(false)
		Me.statusStrip.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private lblNetwork As System.Windows.Forms.Label
	Private txtNetwork As System.Windows.Forms.TextBox
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
