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
		Me.tlpUpdateInfo = New System.Windows.Forms.TableLayoutPanel
		Me.txtPackageType = New System.Windows.Forms.TextBox
		Me.txtImpact = New System.Windows.Forms.TextBox
		Me.txtPackage = New System.Windows.Forms.TextBox
		Me.txtProduct = New System.Windows.Forms.TextBox
		Me.txtDescription = New System.Windows.Forms.TextBox
		Me.txtPackageTitle = New System.Windows.Forms.TextBox
		Me.txtVendor = New System.Windows.Forms.TextBox
		Me.txtClassification = New System.Windows.Forms.TextBox
		Me.txtRebootBehavior = New System.Windows.Forms.TextBox
		Me.txtServerity = New System.Windows.Forms.TextBox
		Me.txtArticleID = New System.Windows.Forms.TextBox
		Me.txtBulletinID = New System.Windows.Forms.TextBox
		Me.txtCVEID = New System.Windows.Forms.TextBox
		Me.txtMoreInfoURL = New System.Windows.Forms.TextBox
		Me.lblUninstall = New System.Windows.Forms.Label
		Me.tlpUpdateInfoUninstall = New System.Windows.Forms.TableLayoutPanel
		Me.txtNetwork = New System.Windows.Forms.TextBox
		Me.txtUninstall = New System.Windows.Forms.TextBox
		Me.lblNetwork = New System.Windows.Forms.Label
		Me.lblRebootBehavior = New System.Windows.Forms.Label
		Me.lblPackageType = New System.Windows.Forms.Label
		Me.lblID = New System.Windows.Forms.Label
		Me.lblPrerequisites = New System.Windows.Forms.Label
		Me.lblSupersedes = New System.Windows.Forms.Label
		Me.lblReturnCodes = New System.Windows.Forms.Label
		Me.lblPackageTitle = New System.Windows.Forms.Label
		Me.lblDescription = New System.Windows.Forms.Label
		Me.lblImpact = New System.Windows.Forms.Label
		Me.lblMoreInfoURL = New System.Windows.Forms.Label
		Me.lblSeverity = New System.Windows.Forms.Label
		Me.lblCVEID = New System.Windows.Forms.Label
		Me.lblClassification = New System.Windows.Forms.Label
		Me.lblBullitinID = New System.Windows.Forms.Label
		Me.lblVendor = New System.Windows.Forms.Label
		Me.lblArticleID = New System.Windows.Forms.Label
		Me.lblProduct = New System.Windows.Forms.Label
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
		Me.cmCreateCategoryUpdate = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.createCategoryUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
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
		Me.tlpUpdateInfo.SuspendLayout
		Me.tlpUpdateInfoUninstall.SuspendLayout
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
		Me.cmCreateCategoryUpdate.SuspendLayout
		Me.SuspendLayout
		'
		'splitContainerVert
		'
		resources.ApplyResources(Me.splitContainerVert, "splitContainerVert")
		Me.splitContainerVert.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
		Me.splitContainerVert.Name = "splitContainerVert"
		'
		'splitContainerVert.Panel1
		'
		Me.splitContainerVert.Panel1.Controls.Add(Me.treeView)
		'
		'splitContainerVert.Panel2
		'
		Me.splitContainerVert.Panel2.Controls.Add(Me.splitContainerHorz)
		AddHandler Me.splitContainerVert.SplitterMoved, AddressOf Me.SplitContainerVertSplitterMoved
		'
		'treeView
		'
		resources.ApplyResources(Me.treeView, "treeView")
		Me.treeView.HideSelection = false
		Me.treeView.Name = "treeView"
		AddHandler Me.treeView.MouseUp, AddressOf Me.TreeViewMouseUp
		AddHandler Me.treeView.AfterSelect, AddressOf Me.TreeViewAfterSelect
		AddHandler Me.treeView.BeforeSelect, AddressOf Me.TreeViewBeforeSelect
		'
		'splitContainerHorz
		'
		resources.ApplyResources(Me.splitContainerHorz, "splitContainerHorz")
		Me.splitContainerHorz.Name = "splitContainerHorz"
		'
		'splitContainerHorz.Panel1
		'
		Me.splitContainerHorz.Panel1.Controls.Add(Me.scHeader)
		'
		'splitContainerHorz.Panel2
		'
		Me.splitContainerHorz.Panel2.Controls.Add(Me.pnlUpdates)
		Me.splitContainerHorz.Panel2.Controls.Add(Me.pnlComputers)
		AddHandler Me.splitContainerHorz.SplitterMoved, AddressOf Me.SplitContainerSplitterMoved
		'
		'scHeader
		'
		resources.ApplyResources(Me.scHeader, "scHeader")
		Me.scHeader.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
		Me.scHeader.Name = "scHeader"
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
		'
		'chkInheritApprovals
		'
		resources.ApplyResources(Me.chkInheritApprovals, "chkInheritApprovals")
		Me.chkInheritApprovals.Name = "chkInheritApprovals"
		Me.chkInheritApprovals.UseVisualStyleBackColor = true
		AddHandler Me.chkInheritApprovals.CheckedChanged, AddressOf Me.ChkInheritApprovalsCheckedChanged
		'
		'chkApprovedOnly
		'
		resources.ApplyResources(Me.chkApprovedOnly, "chkApprovedOnly")
		Me.chkApprovedOnly.Name = "chkApprovedOnly"
		Me.chkApprovedOnly.UseVisualStyleBackColor = true
		AddHandler Me.chkApprovedOnly.CheckedChanged, AddressOf Me.ChkApprovedOnlyCheckedChanged
		'
		'pnlHeaderTop
		'
		Me.pnlHeaderTop.BackColor = System.Drawing.SystemColors.ControlDark
		Me.pnlHeaderTop.Controls.Add(Me.lblSelectedTargetGroupCount)
		Me.pnlHeaderTop.Controls.Add(Me.lblSelectedTargetGroup)
		resources.ApplyResources(Me.pnlHeaderTop, "pnlHeaderTop")
		Me.pnlHeaderTop.Name = "pnlHeaderTop"
		'
		'lblSelectedTargetGroupCount
		'
		resources.ApplyResources(Me.lblSelectedTargetGroupCount, "lblSelectedTargetGroupCount")
		Me.lblSelectedTargetGroupCount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
		Me.lblSelectedTargetGroupCount.Name = "lblSelectedTargetGroupCount"
		'
		'lblSelectedTargetGroup
		'
		resources.ApplyResources(Me.lblSelectedTargetGroup, "lblSelectedTargetGroup")
		Me.lblSelectedTargetGroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
		Me.lblSelectedTargetGroup.Name = "lblSelectedTargetGroup"
		'
		'lblComputerStatus
		'
		resources.ApplyResources(Me.lblComputerStatus, "lblComputerStatus")
		Me.lblComputerStatus.Name = "lblComputerStatus"
		'
		'btnComputerListRefresh
		'
		resources.ApplyResources(Me.btnComputerListRefresh, "btnComputerListRefresh")
		Me.btnComputerListRefresh.Name = "btnComputerListRefresh"
		Me.btnComputerListRefresh.UseVisualStyleBackColor = true
		AddHandler Me.btnComputerListRefresh.Click, AddressOf Me.BtnComputerListRefreshClick
		'
		'cboComputerStatus
		'
		Me.cboComputerStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboComputerStatus.FormattingEnabled = true
		resources.ApplyResources(Me.cboComputerStatus, "cboComputerStatus")
		Me.cboComputerStatus.Name = "cboComputerStatus"
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
		resources.ApplyResources(Me._dgvMain, "_dgvMain")
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
		Me.pnlUpdates.Controls.Add(Me.tabMainUpdates)
		resources.ApplyResources(Me.pnlUpdates, "pnlUpdates")
		Me.pnlUpdates.Name = "pnlUpdates"
		'
		'tabMainUpdates
		'
		Me.tabMainUpdates.Controls.Add(Me.tabUpdateInfo)
		Me.tabMainUpdates.Controls.Add(Me.tabUpdateStatus)
		Me.tabMainUpdates.Controls.Add(Me.tabUpdateReport)
		resources.ApplyResources(Me.tabMainUpdates, "tabMainUpdates")
		Me.tabMainUpdates.Name = "tabMainUpdates"
		Me.tabMainUpdates.SelectedIndex = 0
		'
		'tabUpdateInfo
		'
		Me.tabUpdateInfo.Controls.Add(Me.tlpUpdateInfo)
		resources.ApplyResources(Me.tabUpdateInfo, "tabUpdateInfo")
		Me.tabUpdateInfo.Name = "tabUpdateInfo"
		Me.tabUpdateInfo.UseVisualStyleBackColor = true
		'
		'tlpUpdateInfo
		'
		resources.ApplyResources(Me.tlpUpdateInfo, "tlpUpdateInfo")
		Me.tlpUpdateInfo.Controls.Add(Me.lblUninstall, 0, 13)
		Me.tlpUpdateInfo.Controls.Add(Me.tlpUpdateInfoUninstall, 1, 13)
		Me.tlpUpdateInfo.Controls.Add(Me.txtPackageType, 1, 0)
		Me.tlpUpdateInfo.Controls.Add(Me.lblRebootBehavior, 0, 14)
		Me.tlpUpdateInfo.Controls.Add(Me.txtPackage, 1, 1)
		Me.tlpUpdateInfo.Controls.Add(Me.lblPackageType, 0, 0)
		Me.tlpUpdateInfo.Controls.Add(Me.txtPackageTitle, 1, 2)
		Me.tlpUpdateInfo.Controls.Add(Me.txtDescription, 1, 3)
		Me.tlpUpdateInfo.Controls.Add(Me.txtRebootBehavior, 1, 14)
		Me.tlpUpdateInfo.Controls.Add(Me.txtImpact, 1, 12)
		Me.tlpUpdateInfo.Controls.Add(Me.txtClassification, 1, 4)
		Me.tlpUpdateInfo.Controls.Add(Me.txtVendor, 1, 6)
		Me.tlpUpdateInfo.Controls.Add(Me.txtBulletinID, 1, 5)
		Me.tlpUpdateInfo.Controls.Add(Me.lblID, 0, 1)
		Me.tlpUpdateInfo.Controls.Add(Me.lblPrerequisites, 3, 12)
		Me.tlpUpdateInfo.Controls.Add(Me.txtProduct, 1, 7)
		Me.tlpUpdateInfo.Controls.Add(Me.lblSupersedes, 3, 13)
		Me.tlpUpdateInfo.Controls.Add(Me.lblReturnCodes, 3, 14)
		Me.tlpUpdateInfo.Controls.Add(Me.lblPackageTitle, 0, 2)
		Me.tlpUpdateInfo.Controls.Add(Me.lblDescription, 0, 3)
		Me.tlpUpdateInfo.Controls.Add(Me.lblImpact, 0, 12)
		Me.tlpUpdateInfo.Controls.Add(Me.lblMoreInfoURL, 0, 11)
		Me.tlpUpdateInfo.Controls.Add(Me.lblSeverity, 0, 10)
		Me.tlpUpdateInfo.Controls.Add(Me.lblCVEID, 0, 9)
		Me.tlpUpdateInfo.Controls.Add(Me.lblClassification, 0, 4)
		Me.tlpUpdateInfo.Controls.Add(Me.lblBullitinID, 0, 5)
		Me.tlpUpdateInfo.Controls.Add(Me.lblVendor, 0, 6)
		Me.tlpUpdateInfo.Controls.Add(Me.lblArticleID, 0, 8)
		Me.tlpUpdateInfo.Controls.Add(Me.txtArticleID, 1, 8)
		Me.tlpUpdateInfo.Controls.Add(Me.txtServerity, 1, 10)
		Me.tlpUpdateInfo.Controls.Add(Me.lblProduct, 0, 7)
		Me.tlpUpdateInfo.Controls.Add(Me.txtCVEID, 1, 9)
		Me.tlpUpdateInfo.Controls.Add(Me.txtMoreInfoURL, 1, 11)
		Me.tlpUpdateInfo.Name = "tlpUpdateInfo"
		'
		'txtPackageType
		'
		Me.tlpUpdateInfo.SetColumnSpan(Me.txtPackageType, 3)
		resources.ApplyResources(Me.txtPackageType, "txtPackageType")
		Me.txtPackageType.Name = "txtPackageType"
		Me.txtPackageType.ReadOnly = true
		'
		'txtImpact
		'
		resources.ApplyResources(Me.txtImpact, "txtImpact")
		Me.tlpUpdateInfo.SetColumnSpan(Me.txtImpact, 2)
		Me.txtImpact.Name = "txtImpact"
		Me.txtImpact.ReadOnly = true
		'
		'txtPackage
		'
		Me.tlpUpdateInfo.SetColumnSpan(Me.txtPackage, 3)
		resources.ApplyResources(Me.txtPackage, "txtPackage")
		Me.txtPackage.Name = "txtPackage"
		Me.txtPackage.ReadOnly = true
		'
		'txtProduct
		'
		Me.tlpUpdateInfo.SetColumnSpan(Me.txtProduct, 3)
		resources.ApplyResources(Me.txtProduct, "txtProduct")
		Me.txtProduct.Name = "txtProduct"
		Me.txtProduct.ReadOnly = true
		'
		'txtDescription
		'
		Me.tlpUpdateInfo.SetColumnSpan(Me.txtDescription, 3)
		resources.ApplyResources(Me.txtDescription, "txtDescription")
		Me.txtDescription.Name = "txtDescription"
		Me.txtDescription.ReadOnly = true
		'
		'txtPackageTitle
		'
		Me.tlpUpdateInfo.SetColumnSpan(Me.txtPackageTitle, 3)
		resources.ApplyResources(Me.txtPackageTitle, "txtPackageTitle")
		Me.txtPackageTitle.Name = "txtPackageTitle"
		Me.txtPackageTitle.ReadOnly = true
		'
		'txtVendor
		'
		Me.tlpUpdateInfo.SetColumnSpan(Me.txtVendor, 3)
		resources.ApplyResources(Me.txtVendor, "txtVendor")
		Me.txtVendor.Name = "txtVendor"
		Me.txtVendor.ReadOnly = true
		'
		'txtClassification
		'
		Me.tlpUpdateInfo.SetColumnSpan(Me.txtClassification, 3)
		resources.ApplyResources(Me.txtClassification, "txtClassification")
		Me.txtClassification.Name = "txtClassification"
		Me.txtClassification.ReadOnly = true
		'
		'txtRebootBehavior
		'
		Me.tlpUpdateInfo.SetColumnSpan(Me.txtRebootBehavior, 2)
		resources.ApplyResources(Me.txtRebootBehavior, "txtRebootBehavior")
		Me.txtRebootBehavior.Name = "txtRebootBehavior"
		Me.txtRebootBehavior.ReadOnly = true
		'
		'txtServerity
		'
		Me.tlpUpdateInfo.SetColumnSpan(Me.txtServerity, 3)
		resources.ApplyResources(Me.txtServerity, "txtServerity")
		Me.txtServerity.Name = "txtServerity"
		Me.txtServerity.ReadOnly = true
		'
		'txtArticleID
		'
		Me.tlpUpdateInfo.SetColumnSpan(Me.txtArticleID, 3)
		resources.ApplyResources(Me.txtArticleID, "txtArticleID")
		Me.txtArticleID.Name = "txtArticleID"
		Me.txtArticleID.ReadOnly = true
		'
		'txtBulletinID
		'
		Me.tlpUpdateInfo.SetColumnSpan(Me.txtBulletinID, 3)
		resources.ApplyResources(Me.txtBulletinID, "txtBulletinID")
		Me.txtBulletinID.Name = "txtBulletinID"
		Me.txtBulletinID.ReadOnly = true
		'
		'txtCVEID
		'
		Me.tlpUpdateInfo.SetColumnSpan(Me.txtCVEID, 3)
		resources.ApplyResources(Me.txtCVEID, "txtCVEID")
		Me.txtCVEID.Name = "txtCVEID"
		Me.txtCVEID.ReadOnly = true
		'
		'txtMoreInfoURL
		'
		Me.tlpUpdateInfo.SetColumnSpan(Me.txtMoreInfoURL, 3)
		resources.ApplyResources(Me.txtMoreInfoURL, "txtMoreInfoURL")
		Me.txtMoreInfoURL.Name = "txtMoreInfoURL"
		Me.txtMoreInfoURL.ReadOnly = true
		'
		'lblUninstall
		'
		resources.ApplyResources(Me.lblUninstall, "lblUninstall")
		Me.lblUninstall.Name = "lblUninstall"
		'
		'tlpUpdateInfoUninstall
		'
		resources.ApplyResources(Me.tlpUpdateInfoUninstall, "tlpUpdateInfoUninstall")
		Me.tlpUpdateInfo.SetColumnSpan(Me.tlpUpdateInfoUninstall, 2)
		Me.tlpUpdateInfoUninstall.Controls.Add(Me.txtNetwork, 2, 0)
		Me.tlpUpdateInfoUninstall.Controls.Add(Me.txtUninstall, 0, 0)
		Me.tlpUpdateInfoUninstall.Controls.Add(Me.lblNetwork, 1, 0)
		Me.tlpUpdateInfoUninstall.Name = "tlpUpdateInfoUninstall"
		'
		'txtNetwork
		'
		resources.ApplyResources(Me.txtNetwork, "txtNetwork")
		Me.txtNetwork.Name = "txtNetwork"
		Me.txtNetwork.ReadOnly = true
		'
		'txtUninstall
		'
		resources.ApplyResources(Me.txtUninstall, "txtUninstall")
		Me.txtUninstall.Name = "txtUninstall"
		Me.txtUninstall.ReadOnly = true
		'
		'lblNetwork
		'
		resources.ApplyResources(Me.lblNetwork, "lblNetwork")
		Me.lblNetwork.Name = "lblNetwork"
		'
		'lblRebootBehavior
		'
		resources.ApplyResources(Me.lblRebootBehavior, "lblRebootBehavior")
		Me.lblRebootBehavior.Name = "lblRebootBehavior"
		'
		'lblPackageType
		'
		resources.ApplyResources(Me.lblPackageType, "lblPackageType")
		Me.lblPackageType.Name = "lblPackageType"
		'
		'lblID
		'
		resources.ApplyResources(Me.lblID, "lblID")
		Me.lblID.Name = "lblID"
		'
		'lblPrerequisites
		'
		resources.ApplyResources(Me.lblPrerequisites, "lblPrerequisites")
		Me.lblPrerequisites.ForeColor = System.Drawing.SystemColors.ActiveCaption
		Me.lblPrerequisites.Name = "lblPrerequisites"
		AddHandler Me.lblPrerequisites.Click, AddressOf Me.LblPrerequisitesClick
		'
		'lblSupersedes
		'
		resources.ApplyResources(Me.lblSupersedes, "lblSupersedes")
		Me.lblSupersedes.ForeColor = System.Drawing.SystemColors.ActiveCaption
		Me.lblSupersedes.Name = "lblSupersedes"
		AddHandler Me.lblSupersedes.Click, AddressOf Me.LblSupersedesClick
		'
		'lblReturnCodes
		'
		resources.ApplyResources(Me.lblReturnCodes, "lblReturnCodes")
		Me.lblReturnCodes.ForeColor = System.Drawing.SystemColors.ActiveCaption
		Me.lblReturnCodes.Name = "lblReturnCodes"
		'
		'lblPackageTitle
		'
		resources.ApplyResources(Me.lblPackageTitle, "lblPackageTitle")
		Me.lblPackageTitle.Name = "lblPackageTitle"
		'
		'lblDescription
		'
		resources.ApplyResources(Me.lblDescription, "lblDescription")
		Me.lblDescription.Name = "lblDescription"
		'
		'lblImpact
		'
		resources.ApplyResources(Me.lblImpact, "lblImpact")
		Me.lblImpact.Name = "lblImpact"
		'
		'lblMoreInfoURL
		'
		resources.ApplyResources(Me.lblMoreInfoURL, "lblMoreInfoURL")
		Me.lblMoreInfoURL.Name = "lblMoreInfoURL"
		'
		'lblSeverity
		'
		resources.ApplyResources(Me.lblSeverity, "lblSeverity")
		Me.lblSeverity.Name = "lblSeverity"
		'
		'lblCVEID
		'
		resources.ApplyResources(Me.lblCVEID, "lblCVEID")
		Me.lblCVEID.Name = "lblCVEID"
		'
		'lblClassification
		'
		resources.ApplyResources(Me.lblClassification, "lblClassification")
		Me.lblClassification.Name = "lblClassification"
		'
		'lblBullitinID
		'
		resources.ApplyResources(Me.lblBullitinID, "lblBullitinID")
		Me.lblBullitinID.Name = "lblBullitinID"
		'
		'lblVendor
		'
		resources.ApplyResources(Me.lblVendor, "lblVendor")
		Me.lblVendor.Name = "lblVendor"
		'
		'lblArticleID
		'
		resources.ApplyResources(Me.lblArticleID, "lblArticleID")
		Me.lblArticleID.Name = "lblArticleID"
		'
		'lblProduct
		'
		resources.ApplyResources(Me.lblProduct, "lblProduct")
		Me.lblProduct.Name = "lblProduct"
		'
		'tabUpdateStatus
		'
		Me.tabUpdateStatus.Controls.Add(Me.dgvUpdateStatus)
		resources.ApplyResources(Me.tabUpdateStatus, "tabUpdateStatus")
		Me.tabUpdateStatus.Name = "tabUpdateStatus"
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
		resources.ApplyResources(Me.dgvUpdateStatus, "dgvUpdateStatus")
		Me.dgvUpdateStatus.Name = "dgvUpdateStatus"
		Me.dgvUpdateStatus.ReadOnly = true
		Me.dgvUpdateStatus.RowHeadersVisible = false
		Me.dgvUpdateStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		'
		'tabUpdateReport
		'
		Me.tabUpdateReport.Controls.Add(Me.btnUpdateRefreshReport)
		Me.tabUpdateReport.Controls.Add(Me.dgvUpdateReport)
		Me.tabUpdateReport.Controls.Add(Me.lblUpdateStatus)
		Me.tabUpdateReport.Controls.Add(Me.lblComputerGroup)
		Me.tabUpdateReport.Controls.Add(Me.cboUpdateStatus)
		Me.tabUpdateReport.Controls.Add(Me.cboTargetGroup)
		resources.ApplyResources(Me.tabUpdateReport, "tabUpdateReport")
		Me.tabUpdateReport.Name = "tabUpdateReport"
		Me.tabUpdateReport.UseVisualStyleBackColor = true
		'
		'btnUpdateRefreshReport
		'
		resources.ApplyResources(Me.btnUpdateRefreshReport, "btnUpdateRefreshReport")
		Me.btnUpdateRefreshReport.Name = "btnUpdateRefreshReport"
		Me.btnUpdateRefreshReport.UseVisualStyleBackColor = true
		AddHandler Me.btnUpdateRefreshReport.Click, AddressOf Me.BtnUpdateRefreshReportClick
		'
		'dgvUpdateReport
		'
		Me.dgvUpdateReport.AllowUserToAddRows = false
		Me.dgvUpdateReport.AllowUserToDeleteRows = false
		Me.dgvUpdateReport.AllowUserToOrderColumns = true
		Me.dgvUpdateReport.AllowUserToResizeRows = false
		resources.ApplyResources(Me.dgvUpdateReport, "dgvUpdateReport")
		Me.dgvUpdateReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.dgvUpdateReport.BackgroundColor = System.Drawing.SystemColors.Window
		Me.dgvUpdateReport.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.dgvUpdateReport.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
		Me.dgvUpdateReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvUpdateReport.Name = "dgvUpdateReport"
		Me.dgvUpdateReport.ReadOnly = true
		Me.dgvUpdateReport.RowHeadersVisible = false
		Me.dgvUpdateReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		AddHandler Me.dgvUpdateReport.Sorted, AddressOf Me.DgvUpdateReportSorted
		AddHandler Me.dgvUpdateReport.CellMouseDown, AddressOf Me.DgvUpdateReportCellMouseDown
		'
		'lblUpdateStatus
		'
		resources.ApplyResources(Me.lblUpdateStatus, "lblUpdateStatus")
		Me.lblUpdateStatus.Name = "lblUpdateStatus"
		'
		'lblComputerGroup
		'
		resources.ApplyResources(Me.lblComputerGroup, "lblComputerGroup")
		Me.lblComputerGroup.Name = "lblComputerGroup"
		'
		'cboUpdateStatus
		'
		Me.cboUpdateStatus.FormattingEnabled = true
		resources.ApplyResources(Me.cboUpdateStatus, "cboUpdateStatus")
		Me.cboUpdateStatus.Name = "cboUpdateStatus"
		AddHandler Me.cboUpdateStatus.SelectedIndexChanged, AddressOf Me.cboUpdateStatusSelectedIndexChanged
		'
		'cboTargetGroup
		'
		Me.cboTargetGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
		Me.cboTargetGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cboTargetGroup.FormattingEnabled = true
		resources.ApplyResources(Me.cboTargetGroup, "cboTargetGroup")
		Me.cboTargetGroup.Name = "cboTargetGroup"
		AddHandler Me.cboTargetGroup.SelectedIndexChanged, AddressOf Me.CboTargetGroupSelectedIndexChanged
		'
		'pnlComputers
		'
		Me.pnlComputers.Controls.Add(Me.tabMainComputers)
		resources.ApplyResources(Me.pnlComputers, "pnlComputers")
		Me.pnlComputers.Name = "pnlComputers"
		'
		'tabMainComputers
		'
		Me.tabMainComputers.Controls.Add(Me.tabComputerInfo)
		Me.tabMainComputers.Controls.Add(Me.tabComputerStatus)
		Me.tabMainComputers.Controls.Add(Me.tabComputerReport)
		resources.ApplyResources(Me.tabMainComputers, "tabMainComputers")
		Me.tabMainComputers.Name = "tabMainComputers"
		Me.tabMainComputers.SelectedIndex = 0
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
		resources.ApplyResources(Me.tabComputerInfo, "tabComputerInfo")
		Me.tabComputerInfo.Name = "tabComputerInfo"
		'
		'txtUpdatesNeededNum
		'
		Me.txtUpdatesNeededNum.BackColor = System.Drawing.SystemColors.Control
		Me.txtUpdatesNeededNum.BorderStyle = System.Windows.Forms.BorderStyle.None
		resources.ApplyResources(Me.txtUpdatesNeededNum, "txtUpdatesNeededNum")
		Me.txtUpdatesNeededNum.Name = "txtUpdatesNeededNum"
		Me.txtUpdatesNeededNum.ReadOnly = true
		'
		'txtUpdatesInstalledorNANum
		'
		Me.txtUpdatesInstalledorNANum.BackColor = System.Drawing.SystemColors.Control
		Me.txtUpdatesInstalledorNANum.BorderStyle = System.Windows.Forms.BorderStyle.None
		resources.ApplyResources(Me.txtUpdatesInstalledorNANum, "txtUpdatesInstalledorNANum")
		Me.txtUpdatesInstalledorNANum.Name = "txtUpdatesInstalledorNANum"
		Me.txtUpdatesInstalledorNANum.ReadOnly = true
		'
		'txtUpdateNoStatusNum
		'
		Me.txtUpdateNoStatusNum.BackColor = System.Drawing.SystemColors.Control
		Me.txtUpdateNoStatusNum.BorderStyle = System.Windows.Forms.BorderStyle.None
		resources.ApplyResources(Me.txtUpdateNoStatusNum, "txtUpdateNoStatusNum")
		Me.txtUpdateNoStatusNum.Name = "txtUpdateNoStatusNum"
		Me.txtUpdateNoStatusNum.ReadOnly = true
		'
		'txtUpdatesWErrorsNum
		'
		Me.txtUpdatesWErrorsNum.BackColor = System.Drawing.SystemColors.Control
		Me.txtUpdatesWErrorsNum.BorderStyle = System.Windows.Forms.BorderStyle.None
		resources.ApplyResources(Me.txtUpdatesWErrorsNum, "txtUpdatesWErrorsNum")
		Me.txtUpdatesWErrorsNum.Name = "txtUpdatesWErrorsNum"
		Me.txtUpdatesWErrorsNum.ReadOnly = true
		'
		'lblUpdateNoStatus
		'
		resources.ApplyResources(Me.lblUpdateNoStatus, "lblUpdateNoStatus")
		Me.lblUpdateNoStatus.Name = "lblUpdateNoStatus"
		'
		'lblUpdatesInstalledorNA
		'
		resources.ApplyResources(Me.lblUpdatesInstalledorNA, "lblUpdatesInstalledorNA")
		Me.lblUpdatesInstalledorNA.Name = "lblUpdatesInstalledorNA"
		'
		'lblUpdatesNeeded
		'
		resources.ApplyResources(Me.lblUpdatesNeeded, "lblUpdatesNeeded")
		Me.lblUpdatesNeeded.Name = "lblUpdatesNeeded"
		'
		'lblUpdatesWErrors
		'
		resources.ApplyResources(Me.lblUpdatesWErrors, "lblUpdatesWErrors")
		Me.lblUpdatesWErrors.Name = "lblUpdatesWErrors"
		'
		'tabComputerStatus
		'
		Me.tabComputerStatus.Controls.Add(Me.dgvComputerGroupStatus)
		resources.ApplyResources(Me.tabComputerStatus, "tabComputerStatus")
		Me.tabComputerStatus.Name = "tabComputerStatus"
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
		resources.ApplyResources(Me.dgvComputerGroupStatus, "dgvComputerGroupStatus")
		Me.dgvComputerGroupStatus.Name = "dgvComputerGroupStatus"
		Me.dgvComputerGroupStatus.ReadOnly = true
		Me.dgvComputerGroupStatus.RowHeadersVisible = false
		Me.dgvComputerGroupStatus.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
		Me.dgvComputerGroupStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		'
		'tabComputerReport
		'
		Me.tabComputerReport.Controls.Add(Me.btnComputerRefreshReport)
		Me.tabComputerReport.Controls.Add(Me.dgvComputerReport)
		Me.tabComputerReport.Controls.Add(Me.lblComputerUpdateStatus)
		resources.ApplyResources(Me.tabComputerReport, "tabComputerReport")
		Me.tabComputerReport.Name = "tabComputerReport"
		Me.tabComputerReport.UseVisualStyleBackColor = true
		'
		'btnComputerRefreshReport
		'
		resources.ApplyResources(Me.btnComputerRefreshReport, "btnComputerRefreshReport")
		Me.btnComputerRefreshReport.Name = "btnComputerRefreshReport"
		Me.btnComputerRefreshReport.UseVisualStyleBackColor = true
		AddHandler Me.btnComputerRefreshReport.Click, AddressOf Me.BtnComputerRefreshReportClick
		'
		'dgvComputerReport
		'
		Me.dgvComputerReport.AllowUserToAddRows = false
		Me.dgvComputerReport.AllowUserToDeleteRows = false
		Me.dgvComputerReport.AllowUserToOrderColumns = true
		Me.dgvComputerReport.AllowUserToResizeRows = false
		resources.ApplyResources(Me.dgvComputerReport, "dgvComputerReport")
		Me.dgvComputerReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.dgvComputerReport.BackgroundColor = System.Drawing.SystemColors.Window
		Me.dgvComputerReport.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.dgvComputerReport.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
		Me.dgvComputerReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvComputerReport.Name = "dgvComputerReport"
		Me.dgvComputerReport.ReadOnly = true
		Me.dgvComputerReport.RowHeadersVisible = false
		Me.dgvComputerReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		AddHandler Me.dgvComputerReport.Sorted, AddressOf Me.DgvComputerReportSorted
		AddHandler Me.dgvComputerReport.CellMouseDown, AddressOf Me.DgvComputerReportCellMouseDown
		'
		'lblComputerUpdateStatus
		'
		resources.ApplyResources(Me.lblComputerUpdateStatus, "lblComputerUpdateStatus")
		Me.lblComputerUpdateStatus.Name = "lblComputerUpdateStatus"
		'
		'menuStrip
		'
		Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.toolsToolStripMenuItem, Me.updateToolStripMenuItem, Me.helpToolStripMenuItem})
		resources.ApplyResources(Me.menuStrip, "menuStrip")
		Me.menuStrip.Name = "menuStrip"
		'
		'fileToolStripMenuItem
		'
		Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.importCatalogToolStripMenuItem, Me.exportCatalogToolStripMenuItem, Me.toolStripSeparator3, Me.exportListToolStripMenuItem, Me.exportReportToolStripMenuItem, Me.toolStripSeparator2, Me.exitToolStripMenuItem})
		Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
		resources.ApplyResources(Me.fileToolStripMenuItem, "fileToolStripMenuItem")
		'
		'importCatalogToolStripMenuItem
		'
		Me.importCatalogToolStripMenuItem.Name = "importCatalogToolStripMenuItem"
		resources.ApplyResources(Me.importCatalogToolStripMenuItem, "importCatalogToolStripMenuItem")
		AddHandler Me.importCatalogToolStripMenuItem.Click, AddressOf Me.ImportCatalogToolStripMenuItemClick
		'
		'exportCatalogToolStripMenuItem
		'
		Me.exportCatalogToolStripMenuItem.Name = "exportCatalogToolStripMenuItem"
		resources.ApplyResources(Me.exportCatalogToolStripMenuItem, "exportCatalogToolStripMenuItem")
		AddHandler Me.exportCatalogToolStripMenuItem.Click, AddressOf Me.ExportCatalogToolStripMenuItemClick
		'
		'toolStripSeparator3
		'
		Me.toolStripSeparator3.Name = "toolStripSeparator3"
		resources.ApplyResources(Me.toolStripSeparator3, "toolStripSeparator3")
		'
		'exportListToolStripMenuItem
		'
		resources.ApplyResources(Me.exportListToolStripMenuItem, "exportListToolStripMenuItem")
		Me.exportListToolStripMenuItem.Name = "exportListToolStripMenuItem"
		AddHandler Me.exportListToolStripMenuItem.Click, AddressOf Me.ExportListToolStripMenuItemClick
		'
		'exportReportToolStripMenuItem
		'
		resources.ApplyResources(Me.exportReportToolStripMenuItem, "exportReportToolStripMenuItem")
		Me.exportReportToolStripMenuItem.Name = "exportReportToolStripMenuItem"
		AddHandler Me.exportReportToolStripMenuItem.Click, AddressOf Me.ExportReportToolStripMenuItemClick
		'
		'toolStripSeparator2
		'
		Me.toolStripSeparator2.Name = "toolStripSeparator2"
		resources.ApplyResources(Me.toolStripSeparator2, "toolStripSeparator2")
		'
		'exitToolStripMenuItem
		'
		Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
		resources.ApplyResources(Me.exitToolStripMenuItem, "exitToolStripMenuItem")
		AddHandler Me.exitToolStripMenuItem.Click, AddressOf Me.ExitToolStripMenuItemClick
		'
		'toolsToolStripMenuItem
		'
		Me.toolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.createUpdateToolStripMenuItem, Me.importUpdateToolStripMenuItem, Me.exportUpdateToolStripMenuItem, Me.toolStripSeparator1, Me.savedRulesToolStripMenuItem, Me.certificateInfoToolStripMenuItem, Me.connectionSettingsToolStripMenuItem, Me.optionsToolStripMenuItem})
		Me.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem"
		resources.ApplyResources(Me.toolsToolStripMenuItem, "toolsToolStripMenuItem")
		'
		'createUpdateToolStripMenuItem
		'
		Me.createUpdateToolStripMenuItem.Name = "createUpdateToolStripMenuItem"
		resources.ApplyResources(Me.createUpdateToolStripMenuItem, "createUpdateToolStripMenuItem")
		AddHandler Me.createUpdateToolStripMenuItem.Click, AddressOf Me.CreateUpdateToolStripMenuItemClick
		'
		'importUpdateToolStripMenuItem
		'
		Me.importUpdateToolStripMenuItem.Name = "importUpdateToolStripMenuItem"
		resources.ApplyResources(Me.importUpdateToolStripMenuItem, "importUpdateToolStripMenuItem")
		AddHandler Me.importUpdateToolStripMenuItem.Click, AddressOf Me.ImportUpdateToolStripMenuItemClick
		'
		'exportUpdateToolStripMenuItem
		'
		Me.exportUpdateToolStripMenuItem.Name = "exportUpdateToolStripMenuItem"
		resources.ApplyResources(Me.exportUpdateToolStripMenuItem, "exportUpdateToolStripMenuItem")
		AddHandler Me.exportUpdateToolStripMenuItem.Click, AddressOf Me.ExportUpdateToolStripMenuItemClick
		'
		'toolStripSeparator1
		'
		Me.toolStripSeparator1.Name = "toolStripSeparator1"
		resources.ApplyResources(Me.toolStripSeparator1, "toolStripSeparator1")
		'
		'savedRulesToolStripMenuItem
		'
		Me.savedRulesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.manageRulesToolStripMenuItem, Me.importRulesToolStripMenuItem, Me.exportRulesToolStripMenuItem})
		Me.savedRulesToolStripMenuItem.Name = "savedRulesToolStripMenuItem"
		resources.ApplyResources(Me.savedRulesToolStripMenuItem, "savedRulesToolStripMenuItem")
		'
		'manageRulesToolStripMenuItem
		'
		Me.manageRulesToolStripMenuItem.Name = "manageRulesToolStripMenuItem"
		resources.ApplyResources(Me.manageRulesToolStripMenuItem, "manageRulesToolStripMenuItem")
		AddHandler Me.manageRulesToolStripMenuItem.Click, AddressOf Me.ManageRulesToolStripMenuItemClick
		'
		'importRulesToolStripMenuItem
		'
		Me.importRulesToolStripMenuItem.Name = "importRulesToolStripMenuItem"
		resources.ApplyResources(Me.importRulesToolStripMenuItem, "importRulesToolStripMenuItem")
		AddHandler Me.importRulesToolStripMenuItem.Click, AddressOf Me.ImportRulesToolStripMenuItemClick
		'
		'exportRulesToolStripMenuItem
		'
		Me.exportRulesToolStripMenuItem.Name = "exportRulesToolStripMenuItem"
		resources.ApplyResources(Me.exportRulesToolStripMenuItem, "exportRulesToolStripMenuItem")
		AddHandler Me.exportRulesToolStripMenuItem.Click, AddressOf Me.ExportRulesToolStripMenuItemClick
		'
		'certificateInfoToolStripMenuItem
		'
		Me.certificateInfoToolStripMenuItem.Name = "certificateInfoToolStripMenuItem"
		resources.ApplyResources(Me.certificateInfoToolStripMenuItem, "certificateInfoToolStripMenuItem")
		AddHandler Me.certificateInfoToolStripMenuItem.Click, AddressOf Me.CertificateInfoToolStripMenuItemClick
		'
		'connectionSettingsToolStripMenuItem
		'
		Me.connectionSettingsToolStripMenuItem.Name = "connectionSettingsToolStripMenuItem"
		resources.ApplyResources(Me.connectionSettingsToolStripMenuItem, "connectionSettingsToolStripMenuItem")
		AddHandler Me.connectionSettingsToolStripMenuItem.Click, AddressOf Me.ConnectionSettingsToolStripMenuItemClick
		'
		'optionsToolStripMenuItem
		'
		Me.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem"
		resources.ApplyResources(Me.optionsToolStripMenuItem, "optionsToolStripMenuItem")
		AddHandler Me.optionsToolStripMenuItem.Click, AddressOf Me.OptionsToolStripMenuItemClick
		'
		'updateToolStripMenuItem
		'
		Me.updateToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Replace
		Me.updateToolStripMenuItem.Name = "updateToolStripMenuItem"
		resources.ApplyResources(Me.updateToolStripMenuItem, "updateToolStripMenuItem")
		'
		'helpToolStripMenuItem
		'
		Me.helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.aboutToolStripMenuItem, Me.helpForumsToolStripMenuItem, Me.lupHelpToolStripMenuItem})
		Me.helpToolStripMenuItem.Name = "helpToolStripMenuItem"
		resources.ApplyResources(Me.helpToolStripMenuItem, "helpToolStripMenuItem")
		'
		'aboutToolStripMenuItem
		'
		Me.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem"
		resources.ApplyResources(Me.aboutToolStripMenuItem, "aboutToolStripMenuItem")
		AddHandler Me.aboutToolStripMenuItem.Click, AddressOf Me.AboutToolStripMenuItemClick
		'
		'helpForumsToolStripMenuItem
		'
		Me.helpForumsToolStripMenuItem.Name = "helpForumsToolStripMenuItem"
		resources.ApplyResources(Me.helpForumsToolStripMenuItem, "helpForumsToolStripMenuItem")
		AddHandler Me.helpForumsToolStripMenuItem.Click, AddressOf Me.HelpForumsToolStripMenuItemClick
		'
		'lupHelpToolStripMenuItem
		'
		Me.lupHelpToolStripMenuItem.Name = "lupHelpToolStripMenuItem"
		resources.ApplyResources(Me.lupHelpToolStripMenuItem, "lupHelpToolStripMenuItem")
		AddHandler Me.lupHelpToolStripMenuItem.Click, AddressOf Me.LupHelpToolStripMenuItemClick
		'
		'cmDgvMain
		'
		Me.cmDgvMain.Name = "Data Grid Context Menu"
		resources.ApplyResources(Me.cmDgvMain, "cmDgvMain")
		'
		'statusStrip
		'
		Me.statusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusLabel, Me.toolStripStatusLabelLink})
		resources.ApplyResources(Me.statusStrip, "statusStrip")
		Me.statusStrip.Name = "statusStrip"
		'
		'toolStripStatusLabel
		'
		Me.toolStripStatusLabel.Name = "toolStripStatusLabel"
		resources.ApplyResources(Me.toolStripStatusLabel, "toolStripStatusLabel")
		Me.toolStripStatusLabel.Spring = true
		'
		'toolStripStatusLabelLink
		'
		Me.toolStripStatusLabelLink.IsLink = true
		Me.toolStripStatusLabelLink.Name = "toolStripStatusLabelLink"
		resources.ApplyResources(Me.toolStripStatusLabelLink, "toolStripStatusLabelLink")
		Me.toolStripStatusLabelLink.Spring = true
		AddHandler Me.toolStripStatusLabelLink.Click, AddressOf Me.ToolStripStatusLabelLinkClick
		'
		'exportFileDialog
		'
		Me.exportFileDialog.DefaultExt = "tab"
		resources.ApplyResources(Me.exportFileDialog, "exportFileDialog")
		'
		'cmCreateCategoryUpdate
		'
		Me.cmCreateCategoryUpdate.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.createCategoryUpdateToolStripMenuItem})
		Me.cmCreateCategoryUpdate.Name = "cmCreateUpdate"
		resources.ApplyResources(Me.cmCreateCategoryUpdate, "cmCreateCategoryUpdate")
		'
		'createCategoryUpdateToolStripMenuItem
		'
		Me.createCategoryUpdateToolStripMenuItem.Name = "createCategoryUpdateToolStripMenuItem"
		resources.ApplyResources(Me.createCategoryUpdateToolStripMenuItem, "createCategoryUpdateToolStripMenuItem")
		AddHandler Me.createCategoryUpdateToolStripMenuItem.Click, AddressOf Me.CreateCategoryUpdateToolStripMenuItemClick
		'
		'MainForm
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.statusStrip)
		Me.Controls.Add(Me.menuStrip)
		Me.Controls.Add(Me.splitContainerVert)
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
		Me.scHeader.Panel1.PerformLayout
		Me.scHeader.Panel2.ResumeLayout(false)
		Me.scHeader.ResumeLayout(false)
		Me.pnlHeaderTop.ResumeLayout(false)
		Me.pnlHeaderTop.PerformLayout
		CType(Me._dgvMain,System.ComponentModel.ISupportInitialize).EndInit
		Me.pnlUpdates.ResumeLayout(false)
		Me.tabMainUpdates.ResumeLayout(false)
		Me.tabUpdateInfo.ResumeLayout(false)
		Me.tabUpdateInfo.PerformLayout
		Me.tlpUpdateInfo.ResumeLayout(false)
		Me.tlpUpdateInfo.PerformLayout
		Me.tlpUpdateInfoUninstall.ResumeLayout(false)
		Me.tlpUpdateInfoUninstall.PerformLayout
		Me.tabUpdateStatus.ResumeLayout(false)
		CType(Me.dgvUpdateStatus,System.ComponentModel.ISupportInitialize).EndInit
		Me.tabUpdateReport.ResumeLayout(false)
		Me.tabUpdateReport.PerformLayout
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
		Me.cmCreateCategoryUpdate.ResumeLayout(false)
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private tlpUpdateInfoUninstall As System.Windows.Forms.TableLayoutPanel
	Private tlpUpdateInfo As System.Windows.Forms.TableLayoutPanel
	Private cmCreateCategoryUpdate As System.Windows.Forms.ContextMenuStrip
	Private createCategoryUpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
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
