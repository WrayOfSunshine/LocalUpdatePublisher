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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.splitContainerVert = New System.Windows.Forms.SplitContainer()
        Me.treeView = New LocalUpdatePublisher.CustomTreeView()
        Me.ilTreeView = New System.Windows.Forms.ImageList(Me.components)
        Me.splitContainerHorz = New System.Windows.Forms.SplitContainer()
        Me.scHeader = New System.Windows.Forms.SplitContainer()
        Me.tlpHeader = New System.Windows.Forms.TableLayoutPanel()
        Me.chkInheritApprovals = New System.Windows.Forms.CheckBox()
        Me.chkApprovedOnly = New System.Windows.Forms.CheckBox()
        Me.lblComputerStatus = New System.Windows.Forms.Label()
        Me.btnComputerListRefresh = New System.Windows.Forms.Button()
        Me.cboComputerStatus = New System.Windows.Forms.ComboBox()
        Me.tlpHeaderTop = New System.Windows.Forms.TableLayoutPanel()
        Me.lblSelectedTargetGroup = New System.Windows.Forms.Label()
        Me.lblSelectedTargetGroupCount = New System.Windows.Forms.Label()
        Me.m_dgvMain = New System.Windows.Forms.DataGridView()
        Me.pnlComputers = New System.Windows.Forms.Panel()
        Me.tabMainComputers = New System.Windows.Forms.TabControl()
        Me.tabComputerInfo = New System.Windows.Forms.TabPage()
        Me.tlpComputerInfo = New System.Windows.Forms.TableLayoutPanel()
        Me.lblUpdatesWErrors = New System.Windows.Forms.Label()
        Me.txtUpdateNoStatusNum = New System.Windows.Forms.TextBox()
        Me.txtUpdatesInstalledorNANum = New System.Windows.Forms.TextBox()
        Me.txtUpdatesNeededNum = New System.Windows.Forms.TextBox()
        Me.lblUpdatesNeeded = New System.Windows.Forms.Label()
        Me.lblUpdatesInstalledorNA = New System.Windows.Forms.Label()
        Me.lblUpdateNoStatus = New System.Windows.Forms.Label()
        Me.txtUpdatesWErrorsNum = New System.Windows.Forms.TextBox()
        Me.tabComputerStatus = New System.Windows.Forms.TabPage()
        Me.dgvComputerGroupStatus = New System.Windows.Forms.DataGridView()
        Me.tabComputerReport = New System.Windows.Forms.TabPage()
        Me.tlpComputerReport = New System.Windows.Forms.TableLayoutPanel()
        Me.lblComputerUpdateStatus = New System.Windows.Forms.Label()
        Me.dgvComputerReport = New System.Windows.Forms.DataGridView()
        Me.btnComputerRefreshReport = New System.Windows.Forms.Button()
        Me.pnlUpdates = New System.Windows.Forms.Panel()
        Me.tabMainUpdates = New System.Windows.Forms.TabControl()
        Me.tabUpdateInfo = New System.Windows.Forms.TabPage()
        Me.tlpUpdateInfo = New System.Windows.Forms.TableLayoutPanel()
        Me.lblUninstall = New System.Windows.Forms.Label()
        Me.tlpUpdateInfoUninstall = New System.Windows.Forms.TableLayoutPanel()
        Me.txtNetwork = New System.Windows.Forms.TextBox()
        Me.txtUninstall = New System.Windows.Forms.TextBox()
        Me.lblNetwork = New System.Windows.Forms.Label()
        Me.txtPackageType = New System.Windows.Forms.TextBox()
        Me.lblRebootBehavior = New System.Windows.Forms.Label()
        Me.txtPackage = New System.Windows.Forms.TextBox()
        Me.lblPackageType = New System.Windows.Forms.Label()
        Me.txtPackageTitle = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtRebootBehavior = New System.Windows.Forms.TextBox()
        Me.txtImpact = New System.Windows.Forms.TextBox()
        Me.txtClassification = New System.Windows.Forms.TextBox()
        Me.txtVendor = New System.Windows.Forms.TextBox()
        Me.txtBulletinID = New System.Windows.Forms.TextBox()
        Me.lblID = New System.Windows.Forms.Label()
        Me.lblPrerequisites = New System.Windows.Forms.Label()
        Me.txtProduct = New System.Windows.Forms.TextBox()
        Me.lblSupersedes = New System.Windows.Forms.Label()
        Me.lblReturnCodes = New System.Windows.Forms.Label()
        Me.lblPackageTitle = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblImpact = New System.Windows.Forms.Label()
        Me.lblMoreInfoURL = New System.Windows.Forms.Label()
        Me.lblSeverity = New System.Windows.Forms.Label()
        Me.lblCVEID = New System.Windows.Forms.Label()
        Me.lblClassification = New System.Windows.Forms.Label()
        Me.lblBullitinID = New System.Windows.Forms.Label()
        Me.lblVendor = New System.Windows.Forms.Label()
        Me.lblArticleID = New System.Windows.Forms.Label()
        Me.txtArticleID = New System.Windows.Forms.TextBox()
        Me.txtServerity = New System.Windows.Forms.TextBox()
        Me.lblProduct = New System.Windows.Forms.Label()
        Me.txtCVEID = New System.Windows.Forms.TextBox()
        Me.txtMoreInfoURL = New System.Windows.Forms.TextBox()
        Me.tabUpdateStatus = New System.Windows.Forms.TabPage()
        Me.dgvUpdateStatus = New System.Windows.Forms.DataGridView()
        Me.tabUpdateReport = New System.Windows.Forms.TabPage()
        Me.tlpUpdateReport = New System.Windows.Forms.TableLayoutPanel()
        Me.lblComputerGroup = New System.Windows.Forms.Label()
        Me.dgvUpdateReport = New System.Windows.Forms.DataGridView()
        Me.btnUpdateRefreshReport = New System.Windows.Forms.Button()
        Me.lblUpdateStatus = New System.Windows.Forms.Label()
        Me.cboTargetGroup = New System.Windows.Forms.ComboBox()
        Me.cboUpdateStatus = New System.Windows.Forms.ComboBox()
        Me.menuStrip = New System.Windows.Forms.MenuStrip()
        Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.importCatalogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.exportCatalogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.exportListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.exportReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.createUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.importUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.exportUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.savedRulesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.manageRulesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.importRulesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.exportRulesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.certificateInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.connectionSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.settingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.updateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.helpForumsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lupHelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmDgvMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.statusStrip = New System.Windows.Forms.StatusStrip()
        Me.toolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toolStripStatusLabelLink = New System.Windows.Forms.ToolStripStatusLabel()
        Me.importFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.exportFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.cmCreateCategoryUpdate = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.createCategoryUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.bgwComputerList = New System.ComponentModel.BackgroundWorker()
        Me.bgwUpdateList = New System.ComponentModel.BackgroundWorker()
        Me.bgwServers = New System.ComponentModel.BackgroundWorker()
        Me.bgwUpdateNodes = New System.ComponentModel.BackgroundWorker()
        Me.bgwResign = New System.ComponentModel.BackgroundWorker()
        Me.bgwUpdateReport = New System.ComponentModel.BackgroundWorker()
        Me.bgwComputerReport = New System.ComponentModel.BackgroundWorker()
        CType(Me.splitContainerVert, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitContainerVert.Panel1.SuspendLayout()
        Me.splitContainerVert.Panel2.SuspendLayout()
        Me.splitContainerVert.SuspendLayout()
        CType(Me.splitContainerHorz, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitContainerHorz.Panel1.SuspendLayout()
        Me.splitContainerHorz.Panel2.SuspendLayout()
        Me.splitContainerHorz.SuspendLayout()
        CType(Me.scHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scHeader.Panel1.SuspendLayout()
        Me.scHeader.Panel2.SuspendLayout()
        Me.scHeader.SuspendLayout()
        Me.tlpHeader.SuspendLayout()
        Me.tlpHeaderTop.SuspendLayout()
        CType(Me.m_dgvMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlComputers.SuspendLayout()
        Me.tabMainComputers.SuspendLayout()
        Me.tabComputerInfo.SuspendLayout()
        Me.tlpComputerInfo.SuspendLayout()
        Me.tabComputerStatus.SuspendLayout()
        CType(Me.dgvComputerGroupStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabComputerReport.SuspendLayout()
        Me.tlpComputerReport.SuspendLayout()
        CType(Me.dgvComputerReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlUpdates.SuspendLayout()
        Me.tabMainUpdates.SuspendLayout()
        Me.tabUpdateInfo.SuspendLayout()
        Me.tlpUpdateInfo.SuspendLayout()
        Me.tlpUpdateInfoUninstall.SuspendLayout()
        Me.tabUpdateStatus.SuspendLayout()
        CType(Me.dgvUpdateStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabUpdateReport.SuspendLayout()
        Me.tlpUpdateReport.SuspendLayout()
        CType(Me.dgvUpdateReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuStrip.SuspendLayout()
        Me.statusStrip.SuspendLayout()
        Me.cmCreateCategoryUpdate.SuspendLayout()
        Me.tlpMain.SuspendLayout()
        Me.SuspendLayout()
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
        '
        'treeView
        '
        resources.ApplyResources(Me.treeView, "treeView")
        Me.treeView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll
        Me.treeView.HideSelection = False
        Me.treeView.ImageList = Me.ilTreeView
        Me.treeView.LineColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.treeView.Name = "treeView"
        '
        'ilTreeView
        '
        Me.ilTreeView.ImageStream = CType(resources.GetObject("ilTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilTreeView.TransparentColor = System.Drawing.Color.Transparent
        Me.ilTreeView.Images.SetKeyName(0, "computer.ico")
        Me.ilTreeView.Images.SetKeyName(1, "server.ico")
        Me.ilTreeView.Images.SetKeyName(2, "updates.ico")
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
        Me.splitContainerHorz.Panel2.Controls.Add(Me.pnlComputers)
        Me.splitContainerHorz.Panel2.Controls.Add(Me.pnlUpdates)
        '
        'scHeader
        '
        resources.ApplyResources(Me.scHeader, "scHeader")
        Me.scHeader.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.scHeader.Name = "scHeader"
        '
        'scHeader.Panel1
        '
        Me.scHeader.Panel1.Controls.Add(Me.tlpHeader)
        '
        'scHeader.Panel2
        '
        Me.scHeader.Panel2.Controls.Add(Me.m_dgvMain)
        '
        'tlpHeader
        '
        resources.ApplyResources(Me.tlpHeader, "tlpHeader")
        Me.tlpHeader.Controls.Add(Me.chkInheritApprovals, 4, 1)
        Me.tlpHeader.Controls.Add(Me.chkApprovedOnly, 3, 1)
        Me.tlpHeader.Controls.Add(Me.lblComputerStatus, 0, 1)
        Me.tlpHeader.Controls.Add(Me.btnComputerListRefresh, 2, 1)
        Me.tlpHeader.Controls.Add(Me.cboComputerStatus, 1, 1)
        Me.tlpHeader.Controls.Add(Me.tlpHeaderTop, 0, 0)
        Me.tlpHeader.Name = "tlpHeader"
        '
        'chkInheritApprovals
        '
        resources.ApplyResources(Me.chkInheritApprovals, "chkInheritApprovals")
        Me.chkInheritApprovals.Name = "chkInheritApprovals"
        Me.chkInheritApprovals.UseVisualStyleBackColor = True
        '
        'chkApprovedOnly
        '
        resources.ApplyResources(Me.chkApprovedOnly, "chkApprovedOnly")
        Me.chkApprovedOnly.Name = "chkApprovedOnly"
        Me.chkApprovedOnly.UseVisualStyleBackColor = True
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
        Me.btnComputerListRefresh.UseVisualStyleBackColor = True
        '
        'cboComputerStatus
        '
        resources.ApplyResources(Me.cboComputerStatus, "cboComputerStatus")
        Me.cboComputerStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboComputerStatus.FormattingEnabled = True
        Me.cboComputerStatus.Name = "cboComputerStatus"
        '
        'tlpHeaderTop
        '
        resources.ApplyResources(Me.tlpHeaderTop, "tlpHeaderTop")
        Me.tlpHeaderTop.BackColor = System.Drawing.SystemColors.ControlDark
        Me.tlpHeader.SetColumnSpan(Me.tlpHeaderTop, 5)
        Me.tlpHeaderTop.Controls.Add(Me.lblSelectedTargetGroup, 0, 0)
        Me.tlpHeaderTop.Controls.Add(Me.lblSelectedTargetGroupCount, 1, 0)
        Me.tlpHeaderTop.Name = "tlpHeaderTop"
        '
        'lblSelectedTargetGroup
        '
        resources.ApplyResources(Me.lblSelectedTargetGroup, "lblSelectedTargetGroup")
        Me.lblSelectedTargetGroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblSelectedTargetGroup.Name = "lblSelectedTargetGroup"
        '
        'lblSelectedTargetGroupCount
        '
        resources.ApplyResources(Me.lblSelectedTargetGroupCount, "lblSelectedTargetGroupCount")
        Me.lblSelectedTargetGroupCount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblSelectedTargetGroupCount.Name = "lblSelectedTargetGroupCount"
        '
        'm_dgvMain
        '
        Me.m_dgvMain.AllowUserToAddRows = False
        Me.m_dgvMain.AllowUserToDeleteRows = False
        Me.m_dgvMain.AllowUserToOrderColumns = True
        Me.m_dgvMain.AllowUserToResizeRows = False
        Me.m_dgvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.m_dgvMain.BackgroundColor = System.Drawing.SystemColors.Window
        Me.m_dgvMain.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.m_dgvMain.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.m_dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        resources.ApplyResources(Me.m_dgvMain, "m_dgvMain")
        Me.m_dgvMain.Name = "m_dgvMain"
        Me.m_dgvMain.ReadOnly = True
        Me.m_dgvMain.RowHeadersVisible = False
        Me.m_dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
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
        Me.tabComputerInfo.Controls.Add(Me.tlpComputerInfo)
        resources.ApplyResources(Me.tabComputerInfo, "tabComputerInfo")
        Me.tabComputerInfo.Name = "tabComputerInfo"
        '
        'tlpComputerInfo
        '
        resources.ApplyResources(Me.tlpComputerInfo, "tlpComputerInfo")
        Me.tlpComputerInfo.BackColor = System.Drawing.Color.White
        Me.tlpComputerInfo.Controls.Add(Me.lblUpdatesWErrors, 0, 0)
        Me.tlpComputerInfo.Controls.Add(Me.txtUpdateNoStatusNum, 1, 3)
        Me.tlpComputerInfo.Controls.Add(Me.txtUpdatesInstalledorNANum, 1, 2)
        Me.tlpComputerInfo.Controls.Add(Me.txtUpdatesNeededNum, 1, 1)
        Me.tlpComputerInfo.Controls.Add(Me.lblUpdatesNeeded, 0, 1)
        Me.tlpComputerInfo.Controls.Add(Me.lblUpdatesInstalledorNA, 0, 2)
        Me.tlpComputerInfo.Controls.Add(Me.lblUpdateNoStatus, 0, 3)
        Me.tlpComputerInfo.Controls.Add(Me.txtUpdatesWErrorsNum, 1, 0)
        Me.tlpComputerInfo.Name = "tlpComputerInfo"
        '
        'lblUpdatesWErrors
        '
        resources.ApplyResources(Me.lblUpdatesWErrors, "lblUpdatesWErrors")
        Me.lblUpdatesWErrors.Name = "lblUpdatesWErrors"
        '
        'txtUpdateNoStatusNum
        '
        Me.txtUpdateNoStatusNum.BackColor = System.Drawing.Color.White
        Me.txtUpdateNoStatusNum.BorderStyle = System.Windows.Forms.BorderStyle.None
        resources.ApplyResources(Me.txtUpdateNoStatusNum, "txtUpdateNoStatusNum")
        Me.txtUpdateNoStatusNum.Name = "txtUpdateNoStatusNum"
        Me.txtUpdateNoStatusNum.ReadOnly = True
        '
        'txtUpdatesInstalledorNANum
        '
        Me.txtUpdatesInstalledorNANum.BackColor = System.Drawing.Color.White
        Me.txtUpdatesInstalledorNANum.BorderStyle = System.Windows.Forms.BorderStyle.None
        resources.ApplyResources(Me.txtUpdatesInstalledorNANum, "txtUpdatesInstalledorNANum")
        Me.txtUpdatesInstalledorNANum.Name = "txtUpdatesInstalledorNANum"
        Me.txtUpdatesInstalledorNANum.ReadOnly = True
        '
        'txtUpdatesNeededNum
        '
        Me.txtUpdatesNeededNum.BackColor = System.Drawing.Color.White
        Me.txtUpdatesNeededNum.BorderStyle = System.Windows.Forms.BorderStyle.None
        resources.ApplyResources(Me.txtUpdatesNeededNum, "txtUpdatesNeededNum")
        Me.txtUpdatesNeededNum.Name = "txtUpdatesNeededNum"
        Me.txtUpdatesNeededNum.ReadOnly = True
        '
        'lblUpdatesNeeded
        '
        resources.ApplyResources(Me.lblUpdatesNeeded, "lblUpdatesNeeded")
        Me.lblUpdatesNeeded.Name = "lblUpdatesNeeded"
        '
        'lblUpdatesInstalledorNA
        '
        resources.ApplyResources(Me.lblUpdatesInstalledorNA, "lblUpdatesInstalledorNA")
        Me.lblUpdatesInstalledorNA.Name = "lblUpdatesInstalledorNA"
        '
        'lblUpdateNoStatus
        '
        resources.ApplyResources(Me.lblUpdateNoStatus, "lblUpdateNoStatus")
        Me.lblUpdateNoStatus.Name = "lblUpdateNoStatus"
        '
        'txtUpdatesWErrorsNum
        '
        Me.txtUpdatesWErrorsNum.BackColor = System.Drawing.Color.White
        Me.txtUpdatesWErrorsNum.BorderStyle = System.Windows.Forms.BorderStyle.None
        resources.ApplyResources(Me.txtUpdatesWErrorsNum, "txtUpdatesWErrorsNum")
        Me.txtUpdatesWErrorsNum.Name = "txtUpdatesWErrorsNum"
        Me.txtUpdatesWErrorsNum.ReadOnly = True
        '
        'tabComputerStatus
        '
        Me.tabComputerStatus.Controls.Add(Me.dgvComputerGroupStatus)
        resources.ApplyResources(Me.tabComputerStatus, "tabComputerStatus")
        Me.tabComputerStatus.Name = "tabComputerStatus"
        Me.tabComputerStatus.UseVisualStyleBackColor = True
        '
        'dgvComputerGroupStatus
        '
        Me.dgvComputerGroupStatus.AllowUserToAddRows = False
        Me.dgvComputerGroupStatus.AllowUserToDeleteRows = False
        Me.dgvComputerGroupStatus.AllowUserToOrderColumns = True
        Me.dgvComputerGroupStatus.AllowUserToResizeRows = False
        Me.dgvComputerGroupStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvComputerGroupStatus.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvComputerGroupStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvComputerGroupStatus.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvComputerGroupStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        resources.ApplyResources(Me.dgvComputerGroupStatus, "dgvComputerGroupStatus")
        Me.dgvComputerGroupStatus.Name = "dgvComputerGroupStatus"
        Me.dgvComputerGroupStatus.ReadOnly = True
        Me.dgvComputerGroupStatus.RowHeadersVisible = False
        Me.dgvComputerGroupStatus.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvComputerGroupStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'tabComputerReport
        '
        Me.tabComputerReport.Controls.Add(Me.tlpComputerReport)
        resources.ApplyResources(Me.tabComputerReport, "tabComputerReport")
        Me.tabComputerReport.Name = "tabComputerReport"
        Me.tabComputerReport.UseVisualStyleBackColor = True
        '
        'tlpComputerReport
        '
        resources.ApplyResources(Me.tlpComputerReport, "tlpComputerReport")
        Me.tlpComputerReport.Controls.Add(Me.lblComputerUpdateStatus, 0, 0)
        Me.tlpComputerReport.Controls.Add(Me.dgvComputerReport, 0, 2)
        Me.tlpComputerReport.Controls.Add(Me.btnComputerRefreshReport, 1, 1)
        Me.tlpComputerReport.Name = "tlpComputerReport"
        '
        'lblComputerUpdateStatus
        '
        resources.ApplyResources(Me.lblComputerUpdateStatus, "lblComputerUpdateStatus")
        Me.tlpComputerReport.SetColumnSpan(Me.lblComputerUpdateStatus, 2)
        Me.lblComputerUpdateStatus.Name = "lblComputerUpdateStatus"
        '
        'dgvComputerReport
        '
        Me.dgvComputerReport.AllowUserToAddRows = False
        Me.dgvComputerReport.AllowUserToDeleteRows = False
        Me.dgvComputerReport.AllowUserToOrderColumns = True
        Me.dgvComputerReport.AllowUserToResizeRows = False
        resources.ApplyResources(Me.dgvComputerReport, "dgvComputerReport")
        Me.dgvComputerReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvComputerReport.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvComputerReport.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvComputerReport.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvComputerReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpComputerReport.SetColumnSpan(Me.dgvComputerReport, 2)
        Me.dgvComputerReport.Name = "dgvComputerReport"
        Me.dgvComputerReport.ReadOnly = True
        Me.dgvComputerReport.RowHeadersVisible = False
        Me.dgvComputerReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'btnComputerRefreshReport
        '
        resources.ApplyResources(Me.btnComputerRefreshReport, "btnComputerRefreshReport")
        Me.btnComputerRefreshReport.Name = "btnComputerRefreshReport"
        Me.btnComputerRefreshReport.UseVisualStyleBackColor = True
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
        Me.tabUpdateInfo.UseVisualStyleBackColor = True
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
        Me.txtNetwork.ReadOnly = True
        '
        'txtUninstall
        '
        resources.ApplyResources(Me.txtUninstall, "txtUninstall")
        Me.txtUninstall.Name = "txtUninstall"
        Me.txtUninstall.ReadOnly = True
        '
        'lblNetwork
        '
        resources.ApplyResources(Me.lblNetwork, "lblNetwork")
        Me.lblNetwork.Name = "lblNetwork"
        '
        'txtPackageType
        '
        Me.tlpUpdateInfo.SetColumnSpan(Me.txtPackageType, 3)
        resources.ApplyResources(Me.txtPackageType, "txtPackageType")
        Me.txtPackageType.Name = "txtPackageType"
        Me.txtPackageType.ReadOnly = True
        '
        'lblRebootBehavior
        '
        resources.ApplyResources(Me.lblRebootBehavior, "lblRebootBehavior")
        Me.lblRebootBehavior.Name = "lblRebootBehavior"
        '
        'txtPackage
        '
        Me.tlpUpdateInfo.SetColumnSpan(Me.txtPackage, 3)
        resources.ApplyResources(Me.txtPackage, "txtPackage")
        Me.txtPackage.Name = "txtPackage"
        Me.txtPackage.ReadOnly = True
        '
        'lblPackageType
        '
        resources.ApplyResources(Me.lblPackageType, "lblPackageType")
        Me.lblPackageType.Name = "lblPackageType"
        '
        'txtPackageTitle
        '
        Me.tlpUpdateInfo.SetColumnSpan(Me.txtPackageTitle, 3)
        resources.ApplyResources(Me.txtPackageTitle, "txtPackageTitle")
        Me.txtPackageTitle.Name = "txtPackageTitle"
        Me.txtPackageTitle.ReadOnly = True
        '
        'txtDescription
        '
        Me.tlpUpdateInfo.SetColumnSpan(Me.txtDescription, 3)
        resources.ApplyResources(Me.txtDescription, "txtDescription")
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ReadOnly = True
        '
        'txtRebootBehavior
        '
        Me.tlpUpdateInfo.SetColumnSpan(Me.txtRebootBehavior, 2)
        resources.ApplyResources(Me.txtRebootBehavior, "txtRebootBehavior")
        Me.txtRebootBehavior.Name = "txtRebootBehavior"
        Me.txtRebootBehavior.ReadOnly = True
        '
        'txtImpact
        '
        resources.ApplyResources(Me.txtImpact, "txtImpact")
        Me.tlpUpdateInfo.SetColumnSpan(Me.txtImpact, 2)
        Me.txtImpact.Name = "txtImpact"
        Me.txtImpact.ReadOnly = True
        '
        'txtClassification
        '
        Me.tlpUpdateInfo.SetColumnSpan(Me.txtClassification, 3)
        resources.ApplyResources(Me.txtClassification, "txtClassification")
        Me.txtClassification.Name = "txtClassification"
        Me.txtClassification.ReadOnly = True
        '
        'txtVendor
        '
        Me.tlpUpdateInfo.SetColumnSpan(Me.txtVendor, 3)
        resources.ApplyResources(Me.txtVendor, "txtVendor")
        Me.txtVendor.Name = "txtVendor"
        Me.txtVendor.ReadOnly = True
        '
        'txtBulletinID
        '
        Me.tlpUpdateInfo.SetColumnSpan(Me.txtBulletinID, 3)
        resources.ApplyResources(Me.txtBulletinID, "txtBulletinID")
        Me.txtBulletinID.Name = "txtBulletinID"
        Me.txtBulletinID.ReadOnly = True
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
        '
        'txtProduct
        '
        Me.tlpUpdateInfo.SetColumnSpan(Me.txtProduct, 3)
        resources.ApplyResources(Me.txtProduct, "txtProduct")
        Me.txtProduct.Name = "txtProduct"
        Me.txtProduct.ReadOnly = True
        '
        'lblSupersedes
        '
        resources.ApplyResources(Me.lblSupersedes, "lblSupersedes")
        Me.lblSupersedes.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblSupersedes.Name = "lblSupersedes"
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
        'txtArticleID
        '
        Me.tlpUpdateInfo.SetColumnSpan(Me.txtArticleID, 3)
        resources.ApplyResources(Me.txtArticleID, "txtArticleID")
        Me.txtArticleID.Name = "txtArticleID"
        Me.txtArticleID.ReadOnly = True
        '
        'txtServerity
        '
        Me.tlpUpdateInfo.SetColumnSpan(Me.txtServerity, 3)
        resources.ApplyResources(Me.txtServerity, "txtServerity")
        Me.txtServerity.Name = "txtServerity"
        Me.txtServerity.ReadOnly = True
        '
        'lblProduct
        '
        resources.ApplyResources(Me.lblProduct, "lblProduct")
        Me.lblProduct.Name = "lblProduct"
        '
        'txtCVEID
        '
        Me.tlpUpdateInfo.SetColumnSpan(Me.txtCVEID, 3)
        resources.ApplyResources(Me.txtCVEID, "txtCVEID")
        Me.txtCVEID.Name = "txtCVEID"
        Me.txtCVEID.ReadOnly = True
        '
        'txtMoreInfoURL
        '
        Me.tlpUpdateInfo.SetColumnSpan(Me.txtMoreInfoURL, 3)
        resources.ApplyResources(Me.txtMoreInfoURL, "txtMoreInfoURL")
        Me.txtMoreInfoURL.Name = "txtMoreInfoURL"
        Me.txtMoreInfoURL.ReadOnly = True
        '
        'tabUpdateStatus
        '
        Me.tabUpdateStatus.Controls.Add(Me.dgvUpdateStatus)
        resources.ApplyResources(Me.tabUpdateStatus, "tabUpdateStatus")
        Me.tabUpdateStatus.Name = "tabUpdateStatus"
        Me.tabUpdateStatus.UseVisualStyleBackColor = True
        '
        'dgvUpdateStatus
        '
        Me.dgvUpdateStatus.AllowUserToAddRows = False
        Me.dgvUpdateStatus.AllowUserToDeleteRows = False
        Me.dgvUpdateStatus.AllowUserToOrderColumns = True
        Me.dgvUpdateStatus.AllowUserToResizeRows = False
        Me.dgvUpdateStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvUpdateStatus.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvUpdateStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvUpdateStatus.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvUpdateStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        resources.ApplyResources(Me.dgvUpdateStatus, "dgvUpdateStatus")
        Me.dgvUpdateStatus.Name = "dgvUpdateStatus"
        Me.dgvUpdateStatus.ReadOnly = True
        Me.dgvUpdateStatus.RowHeadersVisible = False
        Me.dgvUpdateStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'tabUpdateReport
        '
        Me.tabUpdateReport.Controls.Add(Me.tlpUpdateReport)
        resources.ApplyResources(Me.tabUpdateReport, "tabUpdateReport")
        Me.tabUpdateReport.Name = "tabUpdateReport"
        Me.tabUpdateReport.UseVisualStyleBackColor = True
        '
        'tlpUpdateReport
        '
        resources.ApplyResources(Me.tlpUpdateReport, "tlpUpdateReport")
        Me.tlpUpdateReport.Controls.Add(Me.lblComputerGroup, 0, 0)
        Me.tlpUpdateReport.Controls.Add(Me.dgvUpdateReport, 0, 2)
        Me.tlpUpdateReport.Controls.Add(Me.btnUpdateRefreshReport, 2, 1)
        Me.tlpUpdateReport.Controls.Add(Me.lblUpdateStatus, 1, 0)
        Me.tlpUpdateReport.Controls.Add(Me.cboTargetGroup, 0, 1)
        Me.tlpUpdateReport.Controls.Add(Me.cboUpdateStatus, 1, 1)
        Me.tlpUpdateReport.Name = "tlpUpdateReport"
        '
        'lblComputerGroup
        '
        resources.ApplyResources(Me.lblComputerGroup, "lblComputerGroup")
        Me.lblComputerGroup.Name = "lblComputerGroup"
        '
        'dgvUpdateReport
        '
        Me.dgvUpdateReport.AllowUserToAddRows = False
        Me.dgvUpdateReport.AllowUserToDeleteRows = False
        Me.dgvUpdateReport.AllowUserToOrderColumns = True
        Me.dgvUpdateReport.AllowUserToResizeRows = False
        Me.dgvUpdateReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvUpdateReport.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvUpdateReport.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvUpdateReport.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvUpdateReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpUpdateReport.SetColumnSpan(Me.dgvUpdateReport, 3)
        resources.ApplyResources(Me.dgvUpdateReport, "dgvUpdateReport")
        Me.dgvUpdateReport.Name = "dgvUpdateReport"
        Me.dgvUpdateReport.ReadOnly = True
        Me.dgvUpdateReport.RowHeadersVisible = False
        Me.dgvUpdateReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'btnUpdateRefreshReport
        '
        resources.ApplyResources(Me.btnUpdateRefreshReport, "btnUpdateRefreshReport")
        Me.btnUpdateRefreshReport.Name = "btnUpdateRefreshReport"
        Me.btnUpdateRefreshReport.UseVisualStyleBackColor = True
        '
        'lblUpdateStatus
        '
        resources.ApplyResources(Me.lblUpdateStatus, "lblUpdateStatus")
        Me.lblUpdateStatus.Name = "lblUpdateStatus"
        '
        'cboTargetGroup
        '
        Me.cboTargetGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboTargetGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboTargetGroup.FormattingEnabled = True
        resources.ApplyResources(Me.cboTargetGroup, "cboTargetGroup")
        Me.cboTargetGroup.Name = "cboTargetGroup"
        '
        'cboUpdateStatus
        '
        Me.cboUpdateStatus.FormattingEnabled = True
        resources.ApplyResources(Me.cboUpdateStatus, "cboUpdateStatus")
        Me.cboUpdateStatus.Name = "cboUpdateStatus"
        '
        'menuStrip
        '
        resources.ApplyResources(Me.menuStrip, "menuStrip")
        Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.toolsToolStripMenuItem, Me.updateToolStripMenuItem, Me.helpToolStripMenuItem})
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
        '
        'exportCatalogToolStripMenuItem
        '
        Me.exportCatalogToolStripMenuItem.Name = "exportCatalogToolStripMenuItem"
        resources.ApplyResources(Me.exportCatalogToolStripMenuItem, "exportCatalogToolStripMenuItem")
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
        '
        'exportReportToolStripMenuItem
        '
        resources.ApplyResources(Me.exportReportToolStripMenuItem, "exportReportToolStripMenuItem")
        Me.exportReportToolStripMenuItem.Name = "exportReportToolStripMenuItem"
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
        '
        'toolsToolStripMenuItem
        '
        Me.toolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.createUpdateToolStripMenuItem, Me.importUpdateToolStripMenuItem, Me.exportUpdateToolStripMenuItem, Me.toolStripSeparator1, Me.savedRulesToolStripMenuItem, Me.certificateInfoToolStripMenuItem, Me.connectionSettingsToolStripMenuItem, Me.settingsToolStripMenuItem})
        Me.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem"
        resources.ApplyResources(Me.toolsToolStripMenuItem, "toolsToolStripMenuItem")
        '
        'createUpdateToolStripMenuItem
        '
        Me.createUpdateToolStripMenuItem.Name = "createUpdateToolStripMenuItem"
        resources.ApplyResources(Me.createUpdateToolStripMenuItem, "createUpdateToolStripMenuItem")
        '
        'importUpdateToolStripMenuItem
        '
        Me.importUpdateToolStripMenuItem.Name = "importUpdateToolStripMenuItem"
        resources.ApplyResources(Me.importUpdateToolStripMenuItem, "importUpdateToolStripMenuItem")
        '
        'exportUpdateToolStripMenuItem
        '
        Me.exportUpdateToolStripMenuItem.Name = "exportUpdateToolStripMenuItem"
        resources.ApplyResources(Me.exportUpdateToolStripMenuItem, "exportUpdateToolStripMenuItem")
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
        '
        'importRulesToolStripMenuItem
        '
        Me.importRulesToolStripMenuItem.Name = "importRulesToolStripMenuItem"
        resources.ApplyResources(Me.importRulesToolStripMenuItem, "importRulesToolStripMenuItem")
        '
        'exportRulesToolStripMenuItem
        '
        Me.exportRulesToolStripMenuItem.Name = "exportRulesToolStripMenuItem"
        resources.ApplyResources(Me.exportRulesToolStripMenuItem, "exportRulesToolStripMenuItem")
        '
        'certificateInfoToolStripMenuItem
        '
        Me.certificateInfoToolStripMenuItem.Name = "certificateInfoToolStripMenuItem"
        resources.ApplyResources(Me.certificateInfoToolStripMenuItem, "certificateInfoToolStripMenuItem")
        '
        'connectionSettingsToolStripMenuItem
        '
        Me.connectionSettingsToolStripMenuItem.Name = "connectionSettingsToolStripMenuItem"
        resources.ApplyResources(Me.connectionSettingsToolStripMenuItem, "connectionSettingsToolStripMenuItem")
        '
        'settingsToolStripMenuItem
        '
        Me.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem"
        resources.ApplyResources(Me.settingsToolStripMenuItem, "settingsToolStripMenuItem")
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
        '
        'helpForumsToolStripMenuItem
        '
        Me.helpForumsToolStripMenuItem.Name = "helpForumsToolStripMenuItem"
        resources.ApplyResources(Me.helpForumsToolStripMenuItem, "helpForumsToolStripMenuItem")
        '
        'lupHelpToolStripMenuItem
        '
        Me.lupHelpToolStripMenuItem.Name = "lupHelpToolStripMenuItem"
        resources.ApplyResources(Me.lupHelpToolStripMenuItem, "lupHelpToolStripMenuItem")
        '
        'cmDgvMain
        '
        Me.cmDgvMain.DropShadowEnabled = False
        Me.cmDgvMain.Name = "Data Grid Context Menu"
        Me.cmDgvMain.ShowImageMargin = False
        resources.ApplyResources(Me.cmDgvMain, "cmDgvMain")
        '
        'statusStrip
        '
        resources.ApplyResources(Me.statusStrip, "statusStrip")
        Me.statusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusLabel, Me.toolStripStatusLabelLink})
        Me.statusStrip.Name = "statusStrip"
        '
        'toolStripStatusLabel
        '
        Me.toolStripStatusLabel.Name = "toolStripStatusLabel"
        resources.ApplyResources(Me.toolStripStatusLabel, "toolStripStatusLabel")
        Me.toolStripStatusLabel.Spring = True
        '
        'toolStripStatusLabelLink
        '
        Me.toolStripStatusLabelLink.IsLink = True
        Me.toolStripStatusLabelLink.Name = "toolStripStatusLabelLink"
        resources.ApplyResources(Me.toolStripStatusLabelLink, "toolStripStatusLabelLink")
        Me.toolStripStatusLabelLink.Spring = True
        '
        'exportFileDialog
        '
        Me.exportFileDialog.DefaultExt = "tab"
        resources.ApplyResources(Me.exportFileDialog, "exportFileDialog")
        '
        'cmCreateCategoryUpdate
        '
        Me.cmCreateCategoryUpdate.DropShadowEnabled = False
        Me.cmCreateCategoryUpdate.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.createCategoryUpdateToolStripMenuItem})
        Me.cmCreateCategoryUpdate.Name = "cmCreateUpdate"
        Me.cmCreateCategoryUpdate.ShowImageMargin = False
        resources.ApplyResources(Me.cmCreateCategoryUpdate, "cmCreateCategoryUpdate")
        '
        'createCategoryUpdateToolStripMenuItem
        '
        Me.createCategoryUpdateToolStripMenuItem.Name = "createCategoryUpdateToolStripMenuItem"
        resources.ApplyResources(Me.createCategoryUpdateToolStripMenuItem, "createCategoryUpdateToolStripMenuItem")
        '
        'tlpMain
        '
        resources.ApplyResources(Me.tlpMain, "tlpMain")
        Me.tlpMain.Controls.Add(Me.menuStrip, 0, 0)
        Me.tlpMain.Controls.Add(Me.splitContainerVert, 0, 1)
        Me.tlpMain.Controls.Add(Me.statusStrip, 0, 2)
        Me.tlpMain.Name = "tlpMain"
        '
        'bgwComputerList
        '
        '
        'bgwUpdateList
        '
        '
        'bgwUpdateNodes
        '
        '
        'bgwResign
        '
        Me.bgwResign.WorkerReportsProgress = True
        '
        'bgwUpdateReport
        '
        '
        'bgwComputerReport
        '
        '
        'MainForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tlpMain)
        Me.MainMenuStrip = Me.menuStrip
        Me.Name = "MainForm"
        Me.splitContainerVert.Panel1.ResumeLayout(False)
        Me.splitContainerVert.Panel2.ResumeLayout(False)
        CType(Me.splitContainerVert, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitContainerVert.ResumeLayout(False)
        Me.splitContainerHorz.Panel1.ResumeLayout(False)
        Me.splitContainerHorz.Panel2.ResumeLayout(False)
        CType(Me.splitContainerHorz, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitContainerHorz.ResumeLayout(False)
        Me.scHeader.Panel1.ResumeLayout(False)
        Me.scHeader.Panel1.PerformLayout()
        Me.scHeader.Panel2.ResumeLayout(False)
        CType(Me.scHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scHeader.ResumeLayout(False)
        Me.tlpHeader.ResumeLayout(False)
        Me.tlpHeader.PerformLayout()
        Me.tlpHeaderTop.ResumeLayout(False)
        Me.tlpHeaderTop.PerformLayout()
        CType(Me.m_dgvMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlComputers.ResumeLayout(False)
        Me.tabMainComputers.ResumeLayout(False)
        Me.tabComputerInfo.ResumeLayout(False)
        Me.tabComputerInfo.PerformLayout()
        Me.tlpComputerInfo.ResumeLayout(False)
        Me.tlpComputerInfo.PerformLayout()
        Me.tabComputerStatus.ResumeLayout(False)
        CType(Me.dgvComputerGroupStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabComputerReport.ResumeLayout(False)
        Me.tlpComputerReport.ResumeLayout(False)
        Me.tlpComputerReport.PerformLayout()
        CType(Me.dgvComputerReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlUpdates.ResumeLayout(False)
        Me.tabMainUpdates.ResumeLayout(False)
        Me.tabUpdateInfo.ResumeLayout(False)
        Me.tabUpdateInfo.PerformLayout()
        Me.tlpUpdateInfo.ResumeLayout(False)
        Me.tlpUpdateInfo.PerformLayout()
        Me.tlpUpdateInfoUninstall.ResumeLayout(False)
        Me.tlpUpdateInfoUninstall.PerformLayout()
        Me.tabUpdateStatus.ResumeLayout(False)
        CType(Me.dgvUpdateStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabUpdateReport.ResumeLayout(False)
        Me.tlpUpdateReport.ResumeLayout(False)
        Me.tlpUpdateReport.PerformLayout()
        CType(Me.dgvUpdateReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuStrip.ResumeLayout(False)
        Me.menuStrip.PerformLayout()
        Me.statusStrip.ResumeLayout(False)
        Me.statusStrip.PerformLayout()
        Me.cmCreateCategoryUpdate.ResumeLayout(False)
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents bgwComputerReport As System.ComponentModel.BackgroundWorker
    Private WithEvents bgwUpdateReport As System.ComponentModel.BackgroundWorker
    Private WithEvents bgwResign As System.ComponentModel.BackgroundWorker
    Private WithEvents ilTreeView As System.Windows.Forms.ImageList
    Private WithEvents bgwComputerList As System.ComponentModel.BackgroundWorker
    Private WithEvents bgwUpdateList As System.ComponentModel.BackgroundWorker
    Private WithEvents tlpUpdateReport As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpComputerReport As System.Windows.Forms.TableLayoutPanel
    Private WithEvents bgwUpdateNodes As System.ComponentModel.BackgroundWorker
    Private WithEvents bgwServers As System.ComponentModel.BackgroundWorker
    Private WithEvents settingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpComputerInfo As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpHeaderTop As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpHeader As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpUpdateInfoUninstall As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpUpdateInfo As System.Windows.Forms.TableLayoutPanel
    Private WithEvents cmCreateCategoryUpdate As System.Windows.Forms.ContextMenuStrip
    Private WithEvents createCategoryUpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents lblNetwork As System.Windows.Forms.Label
    Private WithEvents txtNetwork As System.Windows.Forms.TextBox
    Private WithEvents exportFileDialog As System.Windows.Forms.SaveFileDialog
    Private WithEvents txtUpdatesWErrorsNum As System.Windows.Forms.TextBox
    Private WithEvents txtUpdateNoStatusNum As System.Windows.Forms.TextBox
    Private WithEvents txtUpdatesInstalledorNANum As System.Windows.Forms.TextBox
    Private WithEvents txtUpdatesNeededNum As System.Windows.Forms.TextBox
    Private WithEvents chkInheritApprovals As System.Windows.Forms.CheckBox
    Private WithEvents chkApprovedOnly As System.Windows.Forms.CheckBox
    Private WithEvents lblPackageType As System.Windows.Forms.Label
    Private WithEvents txtPackageType As System.Windows.Forms.TextBox
    Private WithEvents exportCatalogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents exportUpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents importUpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents importFileDialog As System.Windows.Forms.OpenFileDialog
    Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents importCatalogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents lblPrerequisites As System.Windows.Forms.Label
    Private WithEvents lblReturnCodes As System.Windows.Forms.Label
    Private WithEvents lblSupersedes As System.Windows.Forms.Label
    Private WithEvents toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents exportReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents exportListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents btnComputerListRefresh As System.Windows.Forms.Button
    Private WithEvents helpForumsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents lupHelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents createUpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents savedRulesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents exportRulesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents importRulesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents manageRulesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents txtUninstall As System.Windows.Forms.TextBox
    Private WithEvents lblUninstall As System.Windows.Forms.Label
    Private WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolStripStatusLabelLink As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents connectionSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents statusStrip As System.Windows.Forms.StatusStrip
    Private WithEvents updateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents dgvComputerGroupStatus As System.Windows.Forms.DataGridView
    Private WithEvents tabComputerStatus As System.Windows.Forms.TabPage
    Private WithEvents btnComputerRefreshReport As System.Windows.Forms.Button
    Private WithEvents btnUpdateRefreshReport As System.Windows.Forms.Button
    Private WithEvents tabMainUpdates As System.Windows.Forms.TabControl
    Private WithEvents tabUpdateInfo As System.Windows.Forms.TabPage
    Private WithEvents tabUpdateStatus As System.Windows.Forms.TabPage
    Private WithEvents dgvUpdateStatus As System.Windows.Forms.DataGridView
    Private WithEvents tabUpdateReport As System.Windows.Forms.TabPage
    Private WithEvents pnlUpdates As System.Windows.Forms.Panel
    Private WithEvents pnlComputers As System.Windows.Forms.Panel
    Private WithEvents dgvUpdateReport As System.Windows.Forms.DataGridView
    Private WithEvents tabMainComputers As System.Windows.Forms.TabControl
    Private WithEvents dgvComputerReport As System.Windows.Forms.DataGridView
    Private WithEvents lblComputerUpdateStatus As System.Windows.Forms.Label
    Private WithEvents tabComputerReport As System.Windows.Forms.TabPage
    Private WithEvents lblUpdatesWErrors As System.Windows.Forms.Label
    Private WithEvents lblUpdatesNeeded As System.Windows.Forms.Label
    Private WithEvents lblUpdatesInstalledorNA As System.Windows.Forms.Label
    Private WithEvents lblUpdateNoStatus As System.Windows.Forms.Label
    Private WithEvents tabComputerInfo As System.Windows.Forms.TabPage
    Private WithEvents lblSelectedTargetGroup As System.Windows.Forms.Label
    Private WithEvents lblSelectedTargetGroupCount As System.Windows.Forms.Label
    Private WithEvents lblComputerStatus As System.Windows.Forms.Label
    Private WithEvents cboComputerStatus As System.Windows.Forms.ComboBox
    Private WithEvents scHeader As System.Windows.Forms.SplitContainer
    Private WithEvents cboTargetGroup As System.Windows.Forms.ComboBox
    Private WithEvents cboUpdateStatus As System.Windows.Forms.ComboBox
    Private WithEvents lblComputerGroup As System.Windows.Forms.Label
    Private WithEvents lblUpdateStatus As System.Windows.Forms.Label
    Private WithEvents txtProduct As System.Windows.Forms.TextBox
    Private WithEvents txtClassification As System.Windows.Forms.TextBox
    Private WithEvents txtServerity As System.Windows.Forms.TextBox
    Private WithEvents txtImpact As System.Windows.Forms.TextBox
    Private WithEvents txtVendor As System.Windows.Forms.TextBox
    Private WithEvents lblPackageTitle As System.Windows.Forms.Label
    Private WithEvents lblDescription As System.Windows.Forms.Label
    Private WithEvents lblClassification As System.Windows.Forms.Label
    Private WithEvents lblBullitinID As System.Windows.Forms.Label
    Private WithEvents lblVendor As System.Windows.Forms.Label
    Private WithEvents lblProduct As System.Windows.Forms.Label
    Private WithEvents lblArticleID As System.Windows.Forms.Label
    Private WithEvents lblCVEID As System.Windows.Forms.Label
    Private WithEvents lblSeverity As System.Windows.Forms.Label
    Private WithEvents lblMoreInfoURL As System.Windows.Forms.Label
    Private WithEvents lblImpact As System.Windows.Forms.Label
    Private WithEvents lblRebootBehavior As System.Windows.Forms.Label
    Private WithEvents txtPackageTitle As System.Windows.Forms.TextBox
    Private WithEvents txtDescription As System.Windows.Forms.TextBox
    Private WithEvents txtBulletinID As System.Windows.Forms.TextBox
    Private WithEvents txtArticleID As System.Windows.Forms.TextBox
    Private WithEvents txtCVEID As System.Windows.Forms.TextBox
    Private WithEvents txtMoreInfoURL As System.Windows.Forms.TextBox
    Private WithEvents lblID As System.Windows.Forms.Label
    Private WithEvents txtPackage As System.Windows.Forms.TextBox
    Private WithEvents txtRebootBehavior As System.Windows.Forms.TextBox
    Private WithEvents splitContainerVert As System.Windows.Forms.SplitContainer
    Private WithEvents splitContainerHorz As System.Windows.Forms.SplitContainer
    Private WithEvents cmDgvMain As System.Windows.Forms.ContextMenuStrip
    Private WithEvents treeView As LocalUpdatePublisher.CustomTreeView
    Private WithEvents certificateInfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents menuStrip As System.Windows.Forms.MenuStrip
    Private WithEvents aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents m_dgvMain As System.Windows.Forms.DataGridView
    ReadOnly Property DgvMain() As System.Windows.Forms.DataGridView
        Get
            Return m_dgvMain
        End Get
    End Property
End Class
