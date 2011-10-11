' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
'
' Created by SharpDevelop.
' User: Bryan
' Date: 10/22/2009
' Time: 9:19 PM

Partial Class UpdateForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UpdateForm))
		Me.tabsUpdate = New LocalUpdatePublisher.CustomTabControl
		Me.tabIntro = New System.Windows.Forms.TabPage
		Me.tlpIntro = New System.Windows.Forms.TableLayoutPanel
		Me.lblInfo = New System.Windows.Forms.Label
		Me.txtMSIPath = New System.Windows.Forms.TextBox
		Me.btnUpdateFile = New System.Windows.Forms.Button
		Me.dgvAdditionalFiles = New System.Windows.Forms.DataGridView
		Me.FileName = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.RemoveFile = New System.Windows.Forms.DataGridViewButtonColumn
		Me.FileObject = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.lblUpdateFile = New System.Windows.Forms.Label
		Me.lblMSIPath = New System.Windows.Forms.Label
		Me.lblAdditionalFiles = New System.Windows.Forms.Label
		Me.txtUpdateFile = New System.Windows.Forms.TextBox
		Me.btnAddFiles = New System.Windows.Forms.Button
		Me.btnAddDir = New System.Windows.Forms.Button
		Me.tabPackageInfo = New System.Windows.Forms.TabPage
		Me.tlpPackageInfo = New System.Windows.Forms.TableLayoutPanel
		Me.lblRebootBehavior = New System.Windows.Forms.Label
		Me.cboPackageType = New System.Windows.Forms.ComboBox
		Me.txtOriginalURI = New System.Windows.Forms.TextBox
		Me.lblPackageType = New System.Windows.Forms.Label
		Me.lblPackageInfo = New System.Windows.Forms.Label
		Me.txtCommandLine = New System.Windows.Forms.TextBox
		Me.txtNetwork = New System.Windows.Forms.TextBox
		Me.lblCommandLine = New System.Windows.Forms.Label
		Me.lblOriginalURI = New System.Windows.Forms.Label
		Me.cboRebootBehavior = New System.Windows.Forms.ComboBox
		Me.lblNetwork = New System.Windows.Forms.Label
		Me.lblUninstall = New System.Windows.Forms.Label
		Me.txtUninstall = New System.Windows.Forms.TextBox
		Me.lblImpact = New System.Windows.Forms.Label
		Me.txtPackageTitle = New System.Windows.Forms.TextBox
		Me.txtDescription = New System.Windows.Forms.TextBox
		Me.lblPackageTitle = New System.Windows.Forms.Label
		Me.cboSeverity = New System.Windows.Forms.ComboBox
		Me.txtBulletinID = New System.Windows.Forms.TextBox
		Me.cboImpact = New System.Windows.Forms.ComboBox
		Me.lblClassification = New System.Windows.Forms.Label
		Me.cboVendor = New System.Windows.Forms.ComboBox
		Me.cboProduct = New System.Windows.Forms.ComboBox
		Me.lblBullitinID = New System.Windows.Forms.Label
		Me.txtArticleID = New System.Windows.Forms.TextBox
		Me.txtCVEID = New System.Windows.Forms.TextBox
		Me.lblSeverity = New System.Windows.Forms.Label
		Me.lblMoreInfoURL = New System.Windows.Forms.Label
		Me.txtMoreInfoURL = New System.Windows.Forms.TextBox
		Me.lblSupportURL = New System.Windows.Forms.Label
		Me.lblVendor = New System.Windows.Forms.Label
		Me.txtSupportURL = New System.Windows.Forms.TextBox
		Me.lblCVEID = New System.Windows.Forms.Label
		Me.lblProduct = New System.Windows.Forms.Label
		Me.lblArticleID = New System.Windows.Forms.Label
		Me.cboClassification = New System.Windows.Forms.ComboBox
		Me.lblDescription = New System.Windows.Forms.Label
		Me.tlpOptions = New System.Windows.Forms.TableLayoutPanel
		Me.lblLanguages = New System.Windows.Forms.Label
		Me.lblPrerequisites = New System.Windows.Forms.Label
		Me.lblReturnCodes = New System.Windows.Forms.Label
		Me.lblSupersedes = New System.Windows.Forms.Label
		Me.tabIsInstalled = New System.Windows.Forms.TabPage
		Me.isInstalledRules = New LocalUpdatePublisher.RulesEditor
		Me.tabIsInstallable = New System.Windows.Forms.TabPage
		Me.isInstallableRules = New LocalUpdatePublisher.RulesEditor
		Me.tabIsSuperseded = New System.Windows.Forms.TabPage
		Me.tlpIsSuperseded = New System.Windows.Forms.TableLayoutPanel
		Me.txtIsSuperceded_InstallableItem = New System.Windows.Forms.TextBox
		Me.btnIsSupersededEdit = New System.Windows.Forms.Button
		Me.lblIsSuperseded = New System.Windows.Forms.Label
		Me.lblIsSuperceded_InstallableItem = New System.Windows.Forms.Label
		Me.tabMetaData = New System.Windows.Forms.TabPage
		Me.tlpMetaData = New System.Windows.Forms.TableLayoutPanel
		Me.txtInstallableItemMetaData = New System.Windows.Forms.TextBox
		Me.btnMetaDataEdit = New System.Windows.Forms.Button
		Me.lblMetaData = New System.Windows.Forms.Label
		Me.lblMetaData_InstallableItem = New System.Windows.Forms.Label
		Me.tabSummary = New System.Windows.Forms.TabPage
		Me.tlpSummary = New System.Windows.Forms.TableLayoutPanel
		Me.txtSummary = New System.Windows.Forms.TextBox
		Me.lblSummary = New System.Windows.Forms.Label
		Me.btnPrevious = New System.Windows.Forms.Button
		Me.btnNext = New System.Windows.Forms.Button
		Me.btnCancel = New System.Windows.Forms.Button
		Me.dlgUpdateFile = New System.Windows.Forms.OpenFileDialog
		Me.chkExportSdp = New System.Windows.Forms.CheckBox
		Me.dlgExportSdp = New System.Windows.Forms.SaveFileDialog
		Me.dlgUpdateDir = New System.Windows.Forms.FolderBrowserDialog
		Me.errorProviderUpdate = New System.Windows.Forms.ErrorProvider(Me.components)
		Me.tlpMain = New System.Windows.Forms.TableLayoutPanel
		Me.tlpButtons = New System.Windows.Forms.TableLayoutPanel
		Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
		Me.chkMetadataOnly = New System.Windows.Forms.CheckBox
		Me.tabsUpdate.SuspendLayout
		Me.tabIntro.SuspendLayout
		Me.tlpIntro.SuspendLayout
		CType(Me.dgvAdditionalFiles,System.ComponentModel.ISupportInitialize).BeginInit
		Me.tabPackageInfo.SuspendLayout
		Me.tlpPackageInfo.SuspendLayout
		Me.tlpOptions.SuspendLayout
		Me.tabIsInstalled.SuspendLayout
		Me.tabIsInstallable.SuspendLayout
		Me.tabIsSuperseded.SuspendLayout
		Me.tlpIsSuperseded.SuspendLayout
		Me.tabMetaData.SuspendLayout
		Me.tlpMetaData.SuspendLayout
		Me.tabSummary.SuspendLayout
		Me.tlpSummary.SuspendLayout
		CType(Me.errorProviderUpdate,System.ComponentModel.ISupportInitialize).BeginInit
		Me.tlpMain.SuspendLayout
		Me.tlpButtons.SuspendLayout
		Me.tableLayoutPanel1.SuspendLayout
		Me.SuspendLayout
		'
		'tabsUpdate
		'
		Me.tabsUpdate.Controls.Add(Me.tabIntro)
		Me.tabsUpdate.Controls.Add(Me.tabPackageInfo)
		Me.tabsUpdate.Controls.Add(Me.tabIsInstalled)
		Me.tabsUpdate.Controls.Add(Me.tabIsInstallable)
		Me.tabsUpdate.Controls.Add(Me.tabIsSuperseded)
		Me.tabsUpdate.Controls.Add(Me.tabMetaData)
		Me.tabsUpdate.Controls.Add(Me.tabSummary)
		resources.ApplyResources(Me.tabsUpdate, "tabsUpdate")
		Me.tabsUpdate.Multiline = true
		Me.tabsUpdate.Name = "tabsUpdate"
		Me.tabsUpdate.SelectedIndex = 0
		'
		'tabIntro
		'
		Me.tabIntro.BackColor = System.Drawing.SystemColors.Control
		Me.tabIntro.Controls.Add(Me.tlpIntro)
		Me.tabIntro.ForeColor = System.Drawing.SystemColors.ControlText
		resources.ApplyResources(Me.tabIntro, "tabIntro")
		Me.tabIntro.Name = "tabIntro"
		'
		'tlpIntro
		'
		resources.ApplyResources(Me.tlpIntro, "tlpIntro")
		Me.tlpIntro.Controls.Add(Me.lblInfo, 0, 0)
		Me.tlpIntro.Controls.Add(Me.txtMSIPath, 1, 2)
		Me.tlpIntro.Controls.Add(Me.btnUpdateFile, 2, 1)
		Me.tlpIntro.Controls.Add(Me.dgvAdditionalFiles, 1, 3)
		Me.tlpIntro.Controls.Add(Me.lblUpdateFile, 0, 1)
		Me.tlpIntro.Controls.Add(Me.lblMSIPath, 0, 2)
		Me.tlpIntro.Controls.Add(Me.lblAdditionalFiles, 0, 3)
		Me.tlpIntro.Controls.Add(Me.txtUpdateFile, 1, 1)
		Me.tlpIntro.Controls.Add(Me.btnAddFiles, 2, 4)
		Me.tlpIntro.Controls.Add(Me.btnAddDir, 2, 3)
		Me.tlpIntro.Name = "tlpIntro"
		'
		'lblInfo
		'
		resources.ApplyResources(Me.lblInfo, "lblInfo")
		Me.tlpIntro.SetColumnSpan(Me.lblInfo, 3)
		Me.lblInfo.Name = "lblInfo"
		AddHandler Me.lblInfo.TextChanged, AddressOf Me.TextChanged
		'
		'txtMSIPath
		'
		resources.ApplyResources(Me.txtMSIPath, "txtMSIPath")
		Me.txtMSIPath.Name = "txtMSIPath"
		'
		'btnUpdateFile
		'
		resources.ApplyResources(Me.btnUpdateFile, "btnUpdateFile")
		Me.btnUpdateFile.MinimumSize = New System.Drawing.Size(60, 25)
		Me.btnUpdateFile.Name = "btnUpdateFile"
		Me.btnUpdateFile.UseVisualStyleBackColor = true
		AddHandler Me.btnUpdateFile.Click, AddressOf Me.BtnUpdateFileClick
		'
		'dgvAdditionalFiles
		'
		Me.dgvAdditionalFiles.AllowUserToAddRows = false
		Me.dgvAdditionalFiles.AllowUserToDeleteRows = false
		Me.dgvAdditionalFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvAdditionalFiles.ColumnHeadersVisible = false
		Me.dgvAdditionalFiles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FileName, Me.RemoveFile, Me.FileObject})
		resources.ApplyResources(Me.dgvAdditionalFiles, "dgvAdditionalFiles")
		Me.dgvAdditionalFiles.MinimumSize = New System.Drawing.Size(450, 408)
		Me.dgvAdditionalFiles.Name = "dgvAdditionalFiles"
		Me.dgvAdditionalFiles.ReadOnly = true
		Me.dgvAdditionalFiles.RowHeadersVisible = false
		Me.tlpIntro.SetRowSpan(Me.dgvAdditionalFiles, 2)
		Me.dgvAdditionalFiles.TabStop = false
		AddHandler Me.dgvAdditionalFiles.CellContentClick, AddressOf Me.DgvAdditionalFilesCellContentClick
		'
		'FileName
		'
		Me.FileName.Frozen = true
		resources.ApplyResources(Me.FileName, "FileName")
		Me.FileName.Name = "FileName"
		Me.FileName.ReadOnly = true
		'
		'RemoveFile
		'
		Me.RemoveFile.Frozen = true
		resources.ApplyResources(Me.RemoveFile, "RemoveFile")
		Me.RemoveFile.Name = "RemoveFile"
		Me.RemoveFile.ReadOnly = true
		Me.RemoveFile.Text = "Delete"
		Me.RemoveFile.UseColumnTextForButtonValue = true
		'
		'FileObject
		'
		Me.FileObject.Frozen = true
		resources.ApplyResources(Me.FileObject, "FileObject")
		Me.FileObject.Name = "FileObject"
		Me.FileObject.ReadOnly = true
		'
		'lblUpdateFile
		'
		resources.ApplyResources(Me.lblUpdateFile, "lblUpdateFile")
		Me.lblUpdateFile.Name = "lblUpdateFile"
		'
		'lblMSIPath
		'
		resources.ApplyResources(Me.lblMSIPath, "lblMSIPath")
		Me.lblMSIPath.Name = "lblMSIPath"
		'
		'lblAdditionalFiles
		'
		resources.ApplyResources(Me.lblAdditionalFiles, "lblAdditionalFiles")
		Me.lblAdditionalFiles.Name = "lblAdditionalFiles"
		'
		'txtUpdateFile
		'
		resources.ApplyResources(Me.txtUpdateFile, "txtUpdateFile")
		Me.txtUpdateFile.Name = "txtUpdateFile"
		Me.txtUpdateFile.ReadOnly = true
		Me.txtUpdateFile.TabStop = false
		AddHandler Me.txtUpdateFile.Validated, AddressOf Me.ControlValidated
		AddHandler Me.txtUpdateFile.Validating, AddressOf Me.ControlValidating
		'
		'btnAddFiles
		'
		resources.ApplyResources(Me.btnAddFiles, "btnAddFiles")
		Me.btnAddFiles.MinimumSize = New System.Drawing.Size(60, 25)
		Me.btnAddFiles.Name = "btnAddFiles"
		Me.btnAddFiles.UseVisualStyleBackColor = true
		AddHandler Me.btnAddFiles.Click, AddressOf Me.BtnAddFilesClick
		'
		'btnAddDir
		'
		resources.ApplyResources(Me.btnAddDir, "btnAddDir")
		Me.btnAddDir.MinimumSize = New System.Drawing.Size(60, 25)
		Me.btnAddDir.Name = "btnAddDir"
		Me.btnAddDir.UseVisualStyleBackColor = true
		AddHandler Me.btnAddDir.Click, AddressOf Me.BtnAddDirClick
		'
		'tabPackageInfo
		'
		Me.tabPackageInfo.BackColor = System.Drawing.SystemColors.Control
		Me.tabPackageInfo.Controls.Add(Me.tlpPackageInfo)
		resources.ApplyResources(Me.tabPackageInfo, "tabPackageInfo")
		Me.tabPackageInfo.Name = "tabPackageInfo"
		'
		'tlpPackageInfo
		'
		resources.ApplyResources(Me.tlpPackageInfo, "tlpPackageInfo")
		Me.tlpPackageInfo.Controls.Add(Me.lblRebootBehavior, 0, 16)
		Me.tlpPackageInfo.Controls.Add(Me.cboPackageType, 1, 1)
		Me.tlpPackageInfo.Controls.Add(Me.txtOriginalURI, 1, 11)
		Me.tlpPackageInfo.Controls.Add(Me.lblPackageType, 0, 1)
		Me.tlpPackageInfo.Controls.Add(Me.lblPackageInfo, 0, 0)
		Me.tlpPackageInfo.Controls.Add(Me.txtCommandLine, 1, 17)
		Me.tlpPackageInfo.Controls.Add(Me.txtNetwork, 3, 15)
		Me.tlpPackageInfo.Controls.Add(Me.lblCommandLine, 0, 17)
		Me.tlpPackageInfo.Controls.Add(Me.lblOriginalURI, 0, 11)
		Me.tlpPackageInfo.Controls.Add(Me.cboRebootBehavior, 1, 16)
		Me.tlpPackageInfo.Controls.Add(Me.lblNetwork, 2, 15)
		Me.tlpPackageInfo.Controls.Add(Me.lblUninstall, 0, 15)
		Me.tlpPackageInfo.Controls.Add(Me.txtUninstall, 1, 15)
		Me.tlpPackageInfo.Controls.Add(Me.lblImpact, 0, 14)
		Me.tlpPackageInfo.Controls.Add(Me.txtPackageTitle, 1, 2)
		Me.tlpPackageInfo.Controls.Add(Me.txtDescription, 1, 3)
		Me.tlpPackageInfo.Controls.Add(Me.lblPackageTitle, 0, 2)
		Me.tlpPackageInfo.Controls.Add(Me.cboSeverity, 1, 6)
		Me.tlpPackageInfo.Controls.Add(Me.txtBulletinID, 1, 5)
		Me.tlpPackageInfo.Controls.Add(Me.cboImpact, 1, 14)
		Me.tlpPackageInfo.Controls.Add(Me.lblClassification, 0, 4)
		Me.tlpPackageInfo.Controls.Add(Me.cboVendor, 1, 7)
		Me.tlpPackageInfo.Controls.Add(Me.cboProduct, 1, 8)
		Me.tlpPackageInfo.Controls.Add(Me.lblBullitinID, 0, 5)
		Me.tlpPackageInfo.Controls.Add(Me.txtArticleID, 1, 9)
		Me.tlpPackageInfo.Controls.Add(Me.txtCVEID, 1, 10)
		Me.tlpPackageInfo.Controls.Add(Me.lblSeverity, 0, 6)
		Me.tlpPackageInfo.Controls.Add(Me.lblMoreInfoURL, 0, 13)
		Me.tlpPackageInfo.Controls.Add(Me.txtMoreInfoURL, 1, 13)
		Me.tlpPackageInfo.Controls.Add(Me.lblSupportURL, 0, 12)
		Me.tlpPackageInfo.Controls.Add(Me.lblVendor, 0, 7)
		Me.tlpPackageInfo.Controls.Add(Me.txtSupportURL, 1, 12)
		Me.tlpPackageInfo.Controls.Add(Me.lblCVEID, 0, 10)
		Me.tlpPackageInfo.Controls.Add(Me.lblProduct, 0, 8)
		Me.tlpPackageInfo.Controls.Add(Me.lblArticleID, 0, 9)
		Me.tlpPackageInfo.Controls.Add(Me.cboClassification, 1, 4)
		Me.tlpPackageInfo.Controls.Add(Me.lblDescription, 0, 3)
		Me.tlpPackageInfo.Controls.Add(Me.tlpOptions, 1, 18)
		Me.tlpPackageInfo.Name = "tlpPackageInfo"
		'
		'lblRebootBehavior
		'
		resources.ApplyResources(Me.lblRebootBehavior, "lblRebootBehavior")
		Me.lblRebootBehavior.Name = "lblRebootBehavior"
		'
		'cboPackageType
		'
		Me.tlpPackageInfo.SetColumnSpan(Me.cboPackageType, 3)
		resources.ApplyResources(Me.cboPackageType, "cboPackageType")
		Me.cboPackageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboPackageType.FormattingEnabled = true
		Me.cboPackageType.Items.AddRange(New Object() {resources.GetString("cboPackageType.Items"), resources.GetString("cboPackageType.Items1")})
		Me.cboPackageType.Name = "cboPackageType"
		AddHandler Me.cboPackageType.SelectedIndexChanged, AddressOf Me.CboPackageTypeSelectedIndexChanged
		'
		'txtOriginalURI
		'
		Me.tlpPackageInfo.SetColumnSpan(Me.txtOriginalURI, 3)
		resources.ApplyResources(Me.txtOriginalURI, "txtOriginalURI")
		Me.txtOriginalURI.Name = "txtOriginalURI"
		AddHandler Me.txtOriginalURI.TextChanged, AddressOf Me.txtOriginalURITextChanged
		AddHandler Me.txtOriginalURI.KeyDown, AddressOf Me.TxtOriginalURIKeyDown
		AddHandler Me.txtOriginalURI.KeyPress, AddressOf Me.TxtOriginalURIKeyPress
		'
		'lblPackageType
		'
		resources.ApplyResources(Me.lblPackageType, "lblPackageType")
		Me.lblPackageType.Name = "lblPackageType"
		'
		'lblPackageInfo
		'
		resources.ApplyResources(Me.lblPackageInfo, "lblPackageInfo")
		Me.tlpPackageInfo.SetColumnSpan(Me.lblPackageInfo, 4)
		Me.lblPackageInfo.Name = "lblPackageInfo"
		AddHandler Me.lblPackageInfo.TextChanged, AddressOf Me.TextChanged
		'
		'txtCommandLine
		'
		resources.ApplyResources(Me.txtCommandLine, "txtCommandLine")
		Me.txtCommandLine.Name = "txtCommandLine"
		'
		'txtNetwork
		'
		resources.ApplyResources(Me.txtNetwork, "txtNetwork")
		Me.txtNetwork.Name = "txtNetwork"
		Me.txtNetwork.ReadOnly = true
		'
		'lblCommandLine
		'
		resources.ApplyResources(Me.lblCommandLine, "lblCommandLine")
		Me.lblCommandLine.Name = "lblCommandLine"
		'
		'lblOriginalURI
		'
		resources.ApplyResources(Me.lblOriginalURI, "lblOriginalURI")
		Me.lblOriginalURI.Name = "lblOriginalURI"
		'
		'cboRebootBehavior
		'
		resources.ApplyResources(Me.cboRebootBehavior, "cboRebootBehavior")
		Me.cboRebootBehavior.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboRebootBehavior.FormattingEnabled = true
		Me.cboRebootBehavior.Items.AddRange(New Object() {resources.GetString("cboRebootBehavior.Items"), resources.GetString("cboRebootBehavior.Items1"), resources.GetString("cboRebootBehavior.Items2")})
		Me.cboRebootBehavior.Name = "cboRebootBehavior"
		AddHandler Me.cboRebootBehavior.Validating, AddressOf Me.ControlValidating
		AddHandler Me.cboRebootBehavior.SelectedValueChanged, AddressOf Me.ValidateCombo
		AddHandler Me.cboRebootBehavior.Validated, AddressOf Me.ControlValidated
		'
		'lblNetwork
		'
		resources.ApplyResources(Me.lblNetwork, "lblNetwork")
		Me.lblNetwork.Name = "lblNetwork"
		'
		'lblUninstall
		'
		resources.ApplyResources(Me.lblUninstall, "lblUninstall")
		Me.lblUninstall.Name = "lblUninstall"
		'
		'txtUninstall
		'
		resources.ApplyResources(Me.txtUninstall, "txtUninstall")
		Me.txtUninstall.Name = "txtUninstall"
		Me.txtUninstall.ReadOnly = true
		'
		'lblImpact
		'
		resources.ApplyResources(Me.lblImpact, "lblImpact")
		Me.lblImpact.Name = "lblImpact"
		'
		'txtPackageTitle
		'
		Me.tlpPackageInfo.SetColumnSpan(Me.txtPackageTitle, 3)
		resources.ApplyResources(Me.txtPackageTitle, "txtPackageTitle")
		Me.txtPackageTitle.Name = "txtPackageTitle"
		AddHandler Me.txtPackageTitle.Validated, AddressOf Me.ControlValidated
		AddHandler Me.txtPackageTitle.Validating, AddressOf Me.ControlValidating
		'
		'txtDescription
		'
		Me.tlpPackageInfo.SetColumnSpan(Me.txtDescription, 3)
		resources.ApplyResources(Me.txtDescription, "txtDescription")
		Me.txtDescription.Name = "txtDescription"
		AddHandler Me.txtDescription.Validated, AddressOf Me.ControlValidated
		AddHandler Me.txtDescription.Validating, AddressOf Me.ControlValidating
		'
		'lblPackageTitle
		'
		resources.ApplyResources(Me.lblPackageTitle, "lblPackageTitle")
		Me.lblPackageTitle.Name = "lblPackageTitle"
		'
		'cboSeverity
		'
		resources.ApplyResources(Me.cboSeverity, "cboSeverity")
		Me.cboSeverity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboSeverity.FormattingEnabled = true
		Me.cboSeverity.Items.AddRange(New Object() {resources.GetString("cboSeverity.Items"), resources.GetString("cboSeverity.Items1"), resources.GetString("cboSeverity.Items2"), resources.GetString("cboSeverity.Items3"), resources.GetString("cboSeverity.Items4")})
		Me.cboSeverity.Name = "cboSeverity"
		AddHandler Me.cboSeverity.Validating, AddressOf Me.ControlValidating
		AddHandler Me.cboSeverity.SelectedIndexChanged, AddressOf Me.ValidateCombo
		AddHandler Me.cboSeverity.Validated, AddressOf Me.ControlValidated
		'
		'txtBulletinID
		'
		Me.tlpPackageInfo.SetColumnSpan(Me.txtBulletinID, 3)
		resources.ApplyResources(Me.txtBulletinID, "txtBulletinID")
		Me.txtBulletinID.Name = "txtBulletinID"
		AddHandler Me.txtBulletinID.Validating, AddressOf Me.TxtBulletinIDValidating
		'
		'cboImpact
		'
		resources.ApplyResources(Me.cboImpact, "cboImpact")
		Me.cboImpact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboImpact.FormattingEnabled = true
		Me.cboImpact.Items.AddRange(New Object() {resources.GetString("cboImpact.Items"), resources.GetString("cboImpact.Items1"), resources.GetString("cboImpact.Items2")})
		Me.cboImpact.Name = "cboImpact"
		AddHandler Me.cboImpact.Validating, AddressOf Me.ControlValidating
		AddHandler Me.cboImpact.SelectedValueChanged, AddressOf Me.ValidateCombo
		AddHandler Me.cboImpact.Validated, AddressOf Me.ControlValidated
		'
		'lblClassification
		'
		resources.ApplyResources(Me.lblClassification, "lblClassification")
		Me.lblClassification.Name = "lblClassification"
		'
		'cboVendor
		'
		Me.tlpPackageInfo.SetColumnSpan(Me.cboVendor, 3)
		resources.ApplyResources(Me.cboVendor, "cboVendor")
		Me.cboVendor.FormattingEnabled = true
		Me.cboVendor.Name = "cboVendor"
		AddHandler Me.cboVendor.Validating, AddressOf Me.ControlValidating
		AddHandler Me.cboVendor.SelectedIndexChanged, AddressOf Me.CboVendorSelectedIndexChanged
		AddHandler Me.cboVendor.Validated, AddressOf Me.ControlValidated
		AddHandler Me.cboVendor.TextChanged, AddressOf Me.ValidateCombo
		'
		'cboProduct
		'
		Me.tlpPackageInfo.SetColumnSpan(Me.cboProduct, 3)
		resources.ApplyResources(Me.cboProduct, "cboProduct")
		Me.cboProduct.FormattingEnabled = true
		Me.cboProduct.Name = "cboProduct"
		AddHandler Me.cboProduct.Validating, AddressOf Me.ControlValidating
		AddHandler Me.cboProduct.SelectedIndexChanged, AddressOf Me.ValidateCombo
		AddHandler Me.cboProduct.Validated, AddressOf Me.ControlValidated
		AddHandler Me.cboProduct.TextChanged, AddressOf Me.ValidateCombo
		'
		'lblBullitinID
		'
		resources.ApplyResources(Me.lblBullitinID, "lblBullitinID")
		Me.lblBullitinID.Name = "lblBullitinID"
		AddHandler Me.lblBullitinID.Validating, AddressOf Me.ControlValidating
		'
		'txtArticleID
		'
		resources.ApplyResources(Me.txtArticleID, "txtArticleID")
		Me.txtArticleID.Name = "txtArticleID"
		'
		'txtCVEID
		'
		resources.ApplyResources(Me.txtCVEID, "txtCVEID")
		Me.txtCVEID.Name = "txtCVEID"
		'
		'lblSeverity
		'
		resources.ApplyResources(Me.lblSeverity, "lblSeverity")
		Me.lblSeverity.Name = "lblSeverity"
		'
		'lblMoreInfoURL
		'
		resources.ApplyResources(Me.lblMoreInfoURL, "lblMoreInfoURL")
		Me.lblMoreInfoURL.Name = "lblMoreInfoURL"
		'
		'txtMoreInfoURL
		'
		Me.tlpPackageInfo.SetColumnSpan(Me.txtMoreInfoURL, 3)
		resources.ApplyResources(Me.txtMoreInfoURL, "txtMoreInfoURL")
		Me.txtMoreInfoURL.Name = "txtMoreInfoURL"
		AddHandler Me.txtMoreInfoURL.TextChanged, AddressOf Me.txtURITextChanged
		'
		'lblSupportURL
		'
		resources.ApplyResources(Me.lblSupportURL, "lblSupportURL")
		Me.lblSupportURL.Name = "lblSupportURL"
		'
		'lblVendor
		'
		resources.ApplyResources(Me.lblVendor, "lblVendor")
		Me.lblVendor.Name = "lblVendor"
		'
		'txtSupportURL
		'
		Me.tlpPackageInfo.SetColumnSpan(Me.txtSupportURL, 3)
		resources.ApplyResources(Me.txtSupportURL, "txtSupportURL")
		Me.txtSupportURL.Name = "txtSupportURL"
		AddHandler Me.txtSupportURL.TextChanged, AddressOf Me.txtURITextChanged
		'
		'lblCVEID
		'
		resources.ApplyResources(Me.lblCVEID, "lblCVEID")
		Me.lblCVEID.Name = "lblCVEID"
		'
		'lblProduct
		'
		resources.ApplyResources(Me.lblProduct, "lblProduct")
		Me.lblProduct.Name = "lblProduct"
		'
		'lblArticleID
		'
		resources.ApplyResources(Me.lblArticleID, "lblArticleID")
		Me.lblArticleID.Name = "lblArticleID"
		'
		'cboClassification
		'
		Me.tlpPackageInfo.SetColumnSpan(Me.cboClassification, 3)
		resources.ApplyResources(Me.cboClassification, "cboClassification")
		Me.cboClassification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboClassification.FormattingEnabled = true
		Me.cboClassification.Items.AddRange(New Object() {resources.GetString("cboClassification.Items"), resources.GetString("cboClassification.Items1"), resources.GetString("cboClassification.Items2"), resources.GetString("cboClassification.Items3"), resources.GetString("cboClassification.Items4"), resources.GetString("cboClassification.Items5"), resources.GetString("cboClassification.Items6"), resources.GetString("cboClassification.Items7"), resources.GetString("cboClassification.Items8"), resources.GetString("cboClassification.Items9")})
		Me.cboClassification.Name = "cboClassification"
		AddHandler Me.cboClassification.Validating, AddressOf Me.ControlValidating
		AddHandler Me.cboClassification.SelectedIndexChanged, AddressOf Me.ValidateCombo
		AddHandler Me.cboClassification.Validated, AddressOf Me.ControlValidated
		'
		'lblDescription
		'
		resources.ApplyResources(Me.lblDescription, "lblDescription")
		Me.lblDescription.Name = "lblDescription"
		'
		'tlpOptions
		'
		resources.ApplyResources(Me.tlpOptions, "tlpOptions")
		Me.tlpPackageInfo.SetColumnSpan(Me.tlpOptions, 3)
		Me.tlpOptions.Controls.Add(Me.lblLanguages, 4, 0)
		Me.tlpOptions.Controls.Add(Me.lblPrerequisites, 0, 0)
		Me.tlpOptions.Controls.Add(Me.lblReturnCodes, 2, 0)
		Me.tlpOptions.Controls.Add(Me.lblSupersedes, 1, 0)
		Me.tlpOptions.Name = "tlpOptions"
		'
		'lblLanguages
		'
		resources.ApplyResources(Me.lblLanguages, "lblLanguages")
		Me.lblLanguages.ForeColor = System.Drawing.SystemColors.ActiveCaption
		Me.lblLanguages.Name = "lblLanguages"
		AddHandler Me.lblLanguages.Click, AddressOf Me.lblLanguagesClick
		'
		'lblPrerequisites
		'
		resources.ApplyResources(Me.lblPrerequisites, "lblPrerequisites")
		Me.lblPrerequisites.ForeColor = System.Drawing.SystemColors.ActiveCaption
		Me.lblPrerequisites.Name = "lblPrerequisites"
		AddHandler Me.lblPrerequisites.Click, AddressOf Me.lblPrerequisitesClick
		'
		'lblReturnCodes
		'
		resources.ApplyResources(Me.lblReturnCodes, "lblReturnCodes")
		Me.lblReturnCodes.ForeColor = System.Drawing.SystemColors.ActiveCaption
		Me.lblReturnCodes.Name = "lblReturnCodes"
		AddHandler Me.lblReturnCodes.Click, AddressOf Me.lblReturnCodesClick
		'
		'lblSupersedes
		'
		resources.ApplyResources(Me.lblSupersedes, "lblSupersedes")
		Me.lblSupersedes.ForeColor = System.Drawing.SystemColors.ActiveCaption
		Me.lblSupersedes.Name = "lblSupersedes"
		AddHandler Me.lblSupersedes.Click, AddressOf Me.lblSupersedesClick
		'
		'tabIsInstalled
		'
		Me.tabIsInstalled.BackColor = System.Drawing.SystemColors.Control
		Me.tabIsInstalled.Controls.Add(Me.isInstalledRules)
		resources.ApplyResources(Me.tabIsInstalled, "tabIsInstalled")
		Me.tabIsInstalled.Name = "tabIsInstalled"
		'
		'isInstalledRules
		'
		Me.isInstalledRules.ApplicabilityRule = ""
		resources.ApplyResources(Me.isInstalledRules, "isInstalledRules")
		Me.isInstalledRules.CausesValidation = false
		Me.isInstalledRules.Name = "isInstalledRules"
		Me.isInstalledRules.Rules = ""
		'
		'tabIsInstallable
		'
		Me.tabIsInstallable.BackColor = System.Drawing.SystemColors.Control
		Me.tabIsInstallable.Controls.Add(Me.isInstallableRules)
		resources.ApplyResources(Me.tabIsInstallable, "tabIsInstallable")
		Me.tabIsInstallable.Name = "tabIsInstallable"
		'
		'isInstallableRules
		'
		Me.isInstallableRules.ApplicabilityRule = ""
		resources.ApplyResources(Me.isInstallableRules, "isInstallableRules")
		Me.isInstallableRules.CausesValidation = false
		Me.isInstallableRules.Name = "isInstallableRules"
		Me.isInstallableRules.Rules = ""
		'
		'tabIsSuperseded
		'
		Me.tabIsSuperseded.BackColor = System.Drawing.SystemColors.Control
		Me.tabIsSuperseded.Controls.Add(Me.tlpIsSuperseded)
		resources.ApplyResources(Me.tabIsSuperseded, "tabIsSuperseded")
		Me.tabIsSuperseded.Name = "tabIsSuperseded"
		'
		'tlpIsSuperseded
		'
		resources.ApplyResources(Me.tlpIsSuperseded, "tlpIsSuperseded")
		Me.tlpIsSuperseded.Controls.Add(Me.txtIsSuperceded_InstallableItem, 0, 2)
		Me.tlpIsSuperseded.Controls.Add(Me.btnIsSupersededEdit, 1, 1)
		Me.tlpIsSuperseded.Controls.Add(Me.lblIsSuperseded, 0, 0)
		Me.tlpIsSuperseded.Controls.Add(Me.lblIsSuperceded_InstallableItem, 0, 1)
		Me.tlpIsSuperseded.Name = "tlpIsSuperseded"
		'
		'txtIsSuperceded_InstallableItem
		'
		Me.tlpIsSuperseded.SetColumnSpan(Me.txtIsSuperceded_InstallableItem, 2)
		resources.ApplyResources(Me.txtIsSuperceded_InstallableItem, "txtIsSuperceded_InstallableItem")
		Me.txtIsSuperceded_InstallableItem.Name = "txtIsSuperceded_InstallableItem"
		Me.txtIsSuperceded_InstallableItem.ReadOnly = true
		'
		'btnIsSupersededEdit
		'
		resources.ApplyResources(Me.btnIsSupersededEdit, "btnIsSupersededEdit")
		Me.btnIsSupersededEdit.Name = "btnIsSupersededEdit"
		Me.btnIsSupersededEdit.UseVisualStyleBackColor = true
		AddHandler Me.btnIsSupersededEdit.Click, AddressOf Me.BtnIsSupersededEditClick
		'
		'lblIsSuperseded
		'
		resources.ApplyResources(Me.lblIsSuperseded, "lblIsSuperseded")
		Me.tlpIsSuperseded.SetColumnSpan(Me.lblIsSuperseded, 2)
		Me.lblIsSuperseded.Name = "lblIsSuperseded"
		AddHandler Me.lblIsSuperseded.TextChanged, AddressOf Me.TextChanged
		'
		'lblIsSuperceded_InstallableItem
		'
		resources.ApplyResources(Me.lblIsSuperceded_InstallableItem, "lblIsSuperceded_InstallableItem")
		Me.lblIsSuperceded_InstallableItem.Name = "lblIsSuperceded_InstallableItem"
		'
		'tabMetaData
		'
		Me.tabMetaData.BackColor = System.Drawing.SystemColors.Control
		Me.tabMetaData.Controls.Add(Me.tlpMetaData)
		resources.ApplyResources(Me.tabMetaData, "tabMetaData")
		Me.tabMetaData.Name = "tabMetaData"
		'
		'tlpMetaData
		'
		resources.ApplyResources(Me.tlpMetaData, "tlpMetaData")
		Me.tlpMetaData.Controls.Add(Me.txtInstallableItemMetaData, 0, 2)
		Me.tlpMetaData.Controls.Add(Me.btnMetaDataEdit, 1, 1)
		Me.tlpMetaData.Controls.Add(Me.lblMetaData, 0, 0)
		Me.tlpMetaData.Controls.Add(Me.lblMetaData_InstallableItem, 0, 1)
		Me.tlpMetaData.Name = "tlpMetaData"
		'
		'txtInstallableItemMetaData
		'
		Me.tlpMetaData.SetColumnSpan(Me.txtInstallableItemMetaData, 2)
		resources.ApplyResources(Me.txtInstallableItemMetaData, "txtInstallableItemMetaData")
		Me.txtInstallableItemMetaData.Name = "txtInstallableItemMetaData"
		Me.txtInstallableItemMetaData.ReadOnly = true
		'
		'btnMetaDataEdit
		'
		resources.ApplyResources(Me.btnMetaDataEdit, "btnMetaDataEdit")
		Me.btnMetaDataEdit.Name = "btnMetaDataEdit"
		Me.btnMetaDataEdit.UseVisualStyleBackColor = true
		AddHandler Me.btnMetaDataEdit.Click, AddressOf Me.BtnMetaDataEditClick
		'
		'lblMetaData
		'
		resources.ApplyResources(Me.lblMetaData, "lblMetaData")
		Me.tlpMetaData.SetColumnSpan(Me.lblMetaData, 2)
		Me.lblMetaData.Name = "lblMetaData"
		AddHandler Me.lblMetaData.TextChanged, AddressOf Me.TextChanged
		'
		'lblMetaData_InstallableItem
		'
		resources.ApplyResources(Me.lblMetaData_InstallableItem, "lblMetaData_InstallableItem")
		Me.lblMetaData_InstallableItem.Name = "lblMetaData_InstallableItem"
		'
		'tabSummary
		'
		Me.tabSummary.BackColor = System.Drawing.SystemColors.Control
		Me.tabSummary.Controls.Add(Me.tlpSummary)
		resources.ApplyResources(Me.tabSummary, "tabSummary")
		Me.tabSummary.Name = "tabSummary"
		'
		'tlpSummary
		'
		resources.ApplyResources(Me.tlpSummary, "tlpSummary")
		Me.tlpSummary.Controls.Add(Me.txtSummary, 0, 1)
		Me.tlpSummary.Controls.Add(Me.lblSummary, 0, 0)
		Me.tlpSummary.Name = "tlpSummary"
		'
		'txtSummary
		'
		resources.ApplyResources(Me.txtSummary, "txtSummary")
		Me.txtSummary.Name = "txtSummary"
		Me.txtSummary.ReadOnly = true
		Me.txtSummary.TabStop = false
		'
		'lblSummary
		'
		resources.ApplyResources(Me.lblSummary, "lblSummary")
		Me.lblSummary.Name = "lblSummary"
		AddHandler Me.lblSummary.TextChanged, AddressOf Me.TextChanged
		'
		'btnPrevious
		'
		resources.ApplyResources(Me.btnPrevious, "btnPrevious")
		Me.btnPrevious.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnPrevious.Name = "btnPrevious"
		Me.btnPrevious.UseVisualStyleBackColor = true
		AddHandler Me.btnPrevious.Click, AddressOf Me.BtnPreviousClick
		'
		'btnNext
		'
		resources.ApplyResources(Me.btnNext, "btnNext")
		Me.btnNext.CausesValidation = false
		Me.btnNext.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnNext.Name = "btnNext"
		Me.btnNext.UseVisualStyleBackColor = true
		AddHandler Me.btnNext.Click, AddressOf Me.BtnNextClick
		'
		'btnCancel
		'
		resources.ApplyResources(Me.btnCancel, "btnCancel")
		Me.btnCancel.CausesValidation = false
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.UseVisualStyleBackColor = true
		AddHandler Me.btnCancel.Click, AddressOf Me.BtnCancelClick
		'
		'dlgUpdateFile
		'
		resources.ApplyResources(Me.dlgUpdateFile, "dlgUpdateFile")
		'
		'chkExportSdp
		'
		resources.ApplyResources(Me.chkExportSdp, "chkExportSdp")
		Me.chkExportSdp.CausesValidation = false
		Me.chkExportSdp.Name = "chkExportSdp"
		Me.chkExportSdp.UseVisualStyleBackColor = true
		'
		'errorProviderUpdate
		'
		Me.errorProviderUpdate.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
		Me.errorProviderUpdate.ContainerControl = Me
		'
		'tlpMain
		'
		resources.ApplyResources(Me.tlpMain, "tlpMain")
		Me.tlpMain.Controls.Add(Me.tlpButtons, 0, 2)
		Me.tlpMain.Controls.Add(Me.tabsUpdate, 0, 0)
		Me.tlpMain.Controls.Add(Me.chkExportSdp, 0, 1)
		Me.tlpMain.Name = "tlpMain"
		'
		'tlpButtons
		'
		resources.ApplyResources(Me.tlpButtons, "tlpButtons")
		Me.tlpButtons.Controls.Add(Me.tableLayoutPanel1, 1, 0)
		Me.tlpButtons.Controls.Add(Me.chkMetadataOnly, 0, 0)
		Me.tlpButtons.Name = "tlpButtons"
		'
		'tableLayoutPanel1
		'
		resources.ApplyResources(Me.tableLayoutPanel1, "tableLayoutPanel1")
		Me.tableLayoutPanel1.Controls.Add(Me.btnCancel, 2, 0)
		Me.tableLayoutPanel1.Controls.Add(Me.btnNext, 1, 0)
		Me.tableLayoutPanel1.Controls.Add(Me.btnPrevious, 0, 0)
		Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
		'
		'chkMetadataOnly
		'
		Me.chkMetadataOnly.CausesValidation = false
		resources.ApplyResources(Me.chkMetadataOnly, "chkMetadataOnly")
		Me.chkMetadataOnly.MinimumSize = New System.Drawing.Size(0, 25)
		Me.chkMetadataOnly.Name = "chkMetadataOnly"
		Me.chkMetadataOnly.UseVisualStyleBackColor = true
		'
		'UpdateForm
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
		Me.CancelButton = Me.btnCancel
		Me.Controls.Add(Me.tlpMain)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "UpdateForm"
		Me.ShowInTaskbar = false
		Me.tabsUpdate.ResumeLayout(false)
		Me.tabIntro.ResumeLayout(false)
		Me.tabIntro.PerformLayout
		Me.tlpIntro.ResumeLayout(false)
		Me.tlpIntro.PerformLayout
		CType(Me.dgvAdditionalFiles,System.ComponentModel.ISupportInitialize).EndInit
		Me.tabPackageInfo.ResumeLayout(false)
		Me.tabPackageInfo.PerformLayout
		Me.tlpPackageInfo.ResumeLayout(false)
		Me.tlpPackageInfo.PerformLayout
		Me.tlpOptions.ResumeLayout(false)
		Me.tlpOptions.PerformLayout
		Me.tabIsInstalled.ResumeLayout(false)
		Me.tabIsInstalled.PerformLayout
		Me.tabIsInstallable.ResumeLayout(false)
		Me.tabIsInstallable.PerformLayout
		Me.tabIsSuperseded.ResumeLayout(false)
		Me.tabIsSuperseded.PerformLayout
		Me.tlpIsSuperseded.ResumeLayout(false)
		Me.tlpIsSuperseded.PerformLayout
		Me.tabMetaData.ResumeLayout(false)
		Me.tabMetaData.PerformLayout
		Me.tlpMetaData.ResumeLayout(false)
		Me.tlpMetaData.PerformLayout
		Me.tabSummary.ResumeLayout(false)
		Me.tabSummary.PerformLayout
		Me.tlpSummary.ResumeLayout(false)
		Me.tlpSummary.PerformLayout
		CType(Me.errorProviderUpdate,System.ComponentModel.ISupportInitialize).EndInit
		Me.tlpMain.ResumeLayout(false)
		Me.tlpMain.PerformLayout
		Me.tlpButtons.ResumeLayout(false)
		Me.tlpButtons.PerformLayout
		Me.tableLayoutPanel1.ResumeLayout(false)
		Me.tableLayoutPanel1.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Private tlpButtons As System.Windows.Forms.TableLayoutPanel
	Private tlpOptions As System.Windows.Forms.TableLayoutPanel
	Private tlpSummary As System.Windows.Forms.TableLayoutPanel
	Private tlpMetaData As System.Windows.Forms.TableLayoutPanel
	Private lblSummary As System.Windows.Forms.Label
	Private tlpIsSuperseded As System.Windows.Forms.TableLayoutPanel
	Private tlpPackageInfo As System.Windows.Forms.TableLayoutPanel
	Private tabsUpdate As LocalUpdatePublisher.CustomTabControl
	Private tlpIntro As System.Windows.Forms.TableLayoutPanel
	Private tlpMain As System.Windows.Forms.TableLayoutPanel
	Private lblLanguages As System.Windows.Forms.Label
	Private lblNetwork As System.Windows.Forms.Label
	Private txtNetwork As System.Windows.Forms.TextBox
	Private btnAddFiles As System.Windows.Forms.Button
	Private txtOriginalURI As System.Windows.Forms.TextBox
	Private lblOriginalURI As System.Windows.Forms.Label
	Private chkMetadataOnly As System.Windows.Forms.CheckBox
	Private lblPackageType As System.Windows.Forms.Label
	Private cboPackageType As System.Windows.Forms.ComboBox
	Private errorProviderUpdate As System.Windows.Forms.ErrorProvider
	Private lblPrerequisites As System.Windows.Forms.Label
	Private lblSupersedes As System.Windows.Forms.Label
	Private lblReturnCodes As System.Windows.Forms.Label
	Private dlgUpdateDir As System.Windows.Forms.FolderBrowserDialog
	Private btnAddDir As System.Windows.Forms.Button
	Private btnIsSupersededEdit As System.Windows.Forms.Button
	Private btnMetaDataEdit As System.Windows.Forms.Button
	Private lblUninstall As System.Windows.Forms.Label
	Private txtUninstall As System.Windows.Forms.TextBox
	Private dlgExportSdp As System.Windows.Forms.SaveFileDialog
	Private chkExportSdp As System.Windows.Forms.CheckBox
	Private isInstalledRules As LocalUpdatePublisher.RulesEditor
	Private isInstallableRules As LocalUpdatePublisher.RulesEditor
	Private lblMetaData As System.Windows.Forms.Label
	Private lblMetaData_InstallableItem As System.Windows.Forms.Label
	Private lblIsSuperseded As System.Windows.Forms.Label
	Private lblPackageInfo As System.Windows.Forms.Label
	Private lblInfo As System.Windows.Forms.Label
	Private txtMSIPath As System.Windows.Forms.TextBox
	Private lblMSIPath As System.Windows.Forms.Label
	'Private RemoveRule As System.Windows.Forms.DataGridViewButtonColumn
	Private lblIsSuperceded_InstallableItem As System.Windows.Forms.Label
	Private txtIsSuperceded_InstallableItem As System.Windows.Forms.TextBox
	Private tabIntro As System.Windows.Forms.TabPage
	Private tabSummary As System.Windows.Forms.TabPage
	Private tabIsInstallable As System.Windows.Forms.TabPage
	Private tabPackageInfo As System.Windows.Forms.TabPage
	Private tabIsInstalled As System.Windows.Forms.TabPage
	Private tabIsSuperseded As System.Windows.Forms.TabPage
	Private tabMetaData As System.Windows.Forms.TabPage
	Private txtCommandLine As System.Windows.Forms.TextBox
	Private lblCommandLine As System.Windows.Forms.Label
	Private FileObject As System.Windows.Forms.DataGridViewTextBoxColumn
	Private lblAdditionalFiles As System.Windows.Forms.Label
	Private RemoveFile As System.Windows.Forms.DataGridViewButtonColumn
	Private FileName As System.Windows.Forms.DataGridViewTextBoxColumn
	Private dgvAdditionalFiles As System.Windows.Forms.DataGridView
	Private txtInstallableItemMetaData As System.Windows.Forms.TextBox
	Private txtSummary As System.Windows.Forms.TextBox
	Private dlgUpdateFile As System.Windows.Forms.OpenFileDialog
	Private lblUpdateFile As System.Windows.Forms.Label
	Private txtUpdateFile As System.Windows.Forms.TextBox
	Private btnUpdateFile As System.Windows.Forms.Button
	Private lblPackageTitle As System.Windows.Forms.Label
	Private lblDescription As System.Windows.Forms.Label
	Private lblClassification As System.Windows.Forms.Label
	Private lblBullitinID As System.Windows.Forms.Label
	Private lblVendor As System.Windows.Forms.Label
	Private lblProduct As System.Windows.Forms.Label
	Private lblArticleID As System.Windows.Forms.Label
	Private lblCVEID As System.Windows.Forms.Label
	Private lblSeverity As System.Windows.Forms.Label
	Private lblSupportURL As System.Windows.Forms.Label
	Private lblMoreInfoURL As System.Windows.Forms.Label
	Private lblImpact As System.Windows.Forms.Label
	Private lblRebootBehavior As System.Windows.Forms.Label
	Private txtPackageTitle As System.Windows.Forms.TextBox
	Private txtDescription As System.Windows.Forms.TextBox
	Private txtBulletinID As System.Windows.Forms.TextBox
	Private cboClassification As System.Windows.Forms.ComboBox
	Private txtArticleID As System.Windows.Forms.TextBox
	Private txtCVEID As System.Windows.Forms.TextBox
	Private cboSeverity As System.Windows.Forms.ComboBox
	Private txtSupportURL As System.Windows.Forms.TextBox
	Private txtMoreInfoURL As System.Windows.Forms.TextBox
	Private cboImpact As System.Windows.Forms.ComboBox
	Private cboRebootBehavior As System.Windows.Forms.ComboBox
	Private cboProduct As System.Windows.Forms.ComboBox
	Private cboVendor As System.Windows.Forms.ComboBox
	Private btnCancel As System.Windows.Forms.Button
	Private btnNext As System.Windows.Forms.Button
	Private btnPrevious As System.Windows.Forms.Button
End Class
