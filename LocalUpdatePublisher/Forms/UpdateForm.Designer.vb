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
		Me.tabsImportUpdate = New LocalUpdatePublisher.CustomTabControl
		Me.tabIntro = New System.Windows.Forms.TabPage
		Me.btnAddDir = New System.Windows.Forms.Button
		Me.lblInfo = New System.Windows.Forms.Label
		Me.txtMSIPath = New System.Windows.Forms.TextBox
		Me.lblMSIPath = New System.Windows.Forms.Label
		Me.btnAddFiles = New System.Windows.Forms.Button
		Me.dgvAdditionalFiles = New System.Windows.Forms.DataGridView
		Me.FileName = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.RemoveFile = New System.Windows.Forms.DataGridViewButtonColumn
		Me.FileObject = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.lblAdditionalFiles = New System.Windows.Forms.Label
		Me.btnUpdateFile = New System.Windows.Forms.Button
		Me.txtUpdateFile = New System.Windows.Forms.TextBox
		Me.lblUpdateFile = New System.Windows.Forms.Label
		Me.tabPackageInfo = New System.Windows.Forms.TabPage
		Me.txtNetwork = New System.Windows.Forms.TextBox
		Me.lblNetwork = New System.Windows.Forms.Label
		Me.txtOriginalURI = New System.Windows.Forms.TextBox
		Me.lblOriginalURI = New System.Windows.Forms.Label
		Me.cboPackageType = New System.Windows.Forms.ComboBox
		Me.lblPackageType = New System.Windows.Forms.Label
		Me.lblPrerequisites = New System.Windows.Forms.Label
		Me.lblSupersedes = New System.Windows.Forms.Label
		Me.lblReturnCodes = New System.Windows.Forms.Label
		Me.txtUninstall = New System.Windows.Forms.TextBox
		Me.lblUninstall = New System.Windows.Forms.Label
		Me.lblPackageInfo = New System.Windows.Forms.Label
		Me.txtCommandLine = New System.Windows.Forms.TextBox
		Me.lblCommandLine = New System.Windows.Forms.Label
		Me.cboRebootBehavior = New System.Windows.Forms.ComboBox
		Me.cboImpact = New System.Windows.Forms.ComboBox
		Me.txtMoreInfoURL = New System.Windows.Forms.TextBox
		Me.txtSupportURL = New System.Windows.Forms.TextBox
		Me.cboSeverity = New System.Windows.Forms.ComboBox
		Me.txtCVEID = New System.Windows.Forms.TextBox
		Me.txtArticleID = New System.Windows.Forms.TextBox
		Me.cboProduct = New System.Windows.Forms.ComboBox
		Me.cboVendor = New System.Windows.Forms.ComboBox
		Me.cboClassification = New System.Windows.Forms.ComboBox
		Me.txtBulletinID = New System.Windows.Forms.TextBox
		Me.txtDescription = New System.Windows.Forms.TextBox
		Me.txtPackageTitle = New System.Windows.Forms.TextBox
		Me.lblRebootBehavior = New System.Windows.Forms.Label
		Me.lblImpact = New System.Windows.Forms.Label
		Me.lblMoreInfoURL = New System.Windows.Forms.Label
		Me.lblSupportURL = New System.Windows.Forms.Label
		Me.lblSeverity = New System.Windows.Forms.Label
		Me.lblCVEID = New System.Windows.Forms.Label
		Me.lblArticleID = New System.Windows.Forms.Label
		Me.lblProduct = New System.Windows.Forms.Label
		Me.lblVendor = New System.Windows.Forms.Label
		Me.lblBullitinID = New System.Windows.Forms.Label
		Me.lblClassification = New System.Windows.Forms.Label
		Me.lblDescription = New System.Windows.Forms.Label
		Me.lblPackageTitle = New System.Windows.Forms.Label
		Me.tabIsInstalled = New System.Windows.Forms.TabPage
		Me.isInstalledRules = New LocalUpdatePublisher.RulesEditor
		Me.tabIsInstallable = New System.Windows.Forms.TabPage
		Me.isInstallableRules = New LocalUpdatePublisher.RulesEditor
		Me.tabIsSuperseded = New System.Windows.Forms.TabPage
		Me.btnIsSupersededEdit = New System.Windows.Forms.Button
		Me.lblIsSuperseded = New System.Windows.Forms.Label
		Me.lblIsSuperceded_InstallableItem = New System.Windows.Forms.Label
		Me.txtIsSuperceded_InstallableItem = New System.Windows.Forms.TextBox
		Me.tabMetaData = New System.Windows.Forms.TabPage
		Me.btnMetaDataEdit = New System.Windows.Forms.Button
		Me.lblMetaData_InstallableItem = New System.Windows.Forms.Label
		Me.lblMetaData = New System.Windows.Forms.Label
		Me.txtInstallableItemMetaData = New System.Windows.Forms.TextBox
		Me.tabSummary = New System.Windows.Forms.TabPage
		Me.label4 = New System.Windows.Forms.Label
		Me.txtSummary = New System.Windows.Forms.TextBox
		Me.btnPrevious = New System.Windows.Forms.Button
		Me.btnNext = New System.Windows.Forms.Button
		Me.btnCancel = New System.Windows.Forms.Button
		Me.dlgUpdateFile = New System.Windows.Forms.OpenFileDialog
		Me.chkExportSdp = New System.Windows.Forms.CheckBox
		Me.dlgExportSdp = New System.Windows.Forms.SaveFileDialog
		Me.dlgUpdateDir = New System.Windows.Forms.FolderBrowserDialog
		Me.chkMetadataOnly = New System.Windows.Forms.CheckBox
		Me.errorProviderUpdate = New System.Windows.Forms.ErrorProvider(Me.components)
		Me.tabsImportUpdate.SuspendLayout
		Me.tabIntro.SuspendLayout
		CType(Me.dgvAdditionalFiles,System.ComponentModel.ISupportInitialize).BeginInit
		Me.tabPackageInfo.SuspendLayout
		Me.tabIsInstalled.SuspendLayout
		Me.tabIsInstallable.SuspendLayout
		Me.tabIsSuperseded.SuspendLayout
		Me.tabMetaData.SuspendLayout
		Me.tabSummary.SuspendLayout
		CType(Me.errorProviderUpdate,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'tabsImportUpdate
		'
		resources.ApplyResources(Me.tabsImportUpdate, "tabsImportUpdate")
		Me.tabsImportUpdate.Controls.Add(Me.tabIntro)
		Me.tabsImportUpdate.Controls.Add(Me.tabPackageInfo)
		Me.tabsImportUpdate.Controls.Add(Me.tabIsInstalled)
		Me.tabsImportUpdate.Controls.Add(Me.tabIsInstallable)
		Me.tabsImportUpdate.Controls.Add(Me.tabIsSuperseded)
		Me.tabsImportUpdate.Controls.Add(Me.tabMetaData)
		Me.tabsImportUpdate.Controls.Add(Me.tabSummary)
		Me.tabsImportUpdate.Name = "tabsImportUpdate"
		Me.tabsImportUpdate.SelectedIndex = 0
		'
		'tabIntro
		'
		Me.tabIntro.BackColor = System.Drawing.SystemColors.Control
		Me.tabIntro.Controls.Add(Me.btnAddDir)
		Me.tabIntro.Controls.Add(Me.lblInfo)
		Me.tabIntro.Controls.Add(Me.txtMSIPath)
		Me.tabIntro.Controls.Add(Me.lblMSIPath)
		Me.tabIntro.Controls.Add(Me.btnAddFiles)
		Me.tabIntro.Controls.Add(Me.dgvAdditionalFiles)
		Me.tabIntro.Controls.Add(Me.lblAdditionalFiles)
		Me.tabIntro.Controls.Add(Me.btnUpdateFile)
		Me.tabIntro.Controls.Add(Me.txtUpdateFile)
		Me.tabIntro.Controls.Add(Me.lblUpdateFile)
		Me.tabIntro.ForeColor = System.Drawing.SystemColors.ControlText
		resources.ApplyResources(Me.tabIntro, "tabIntro")
		Me.tabIntro.Name = "tabIntro"
		'
		'btnAddDir
		'
		resources.ApplyResources(Me.btnAddDir, "btnAddDir")
		Me.btnAddDir.Name = "btnAddDir"
		Me.btnAddDir.UseVisualStyleBackColor = true
		AddHandler Me.btnAddDir.Click, AddressOf Me.BtnAddDirClick
		'
		'lblInfo
		'
		resources.ApplyResources(Me.lblInfo, "lblInfo")
		Me.lblInfo.Name = "lblInfo"
		'
		'txtMSIPath
		'
		resources.ApplyResources(Me.txtMSIPath, "txtMSIPath")
		Me.txtMSIPath.Name = "txtMSIPath"
		'
		'lblMSIPath
		'
		resources.ApplyResources(Me.lblMSIPath, "lblMSIPath")
		Me.lblMSIPath.Name = "lblMSIPath"
		'
		'btnAddFiles
		'
		resources.ApplyResources(Me.btnAddFiles, "btnAddFiles")
		Me.btnAddFiles.Name = "btnAddFiles"
		Me.btnAddFiles.UseVisualStyleBackColor = true
		AddHandler Me.btnAddFiles.Click, AddressOf Me.BtnAddFilesClick
		'
		'dgvAdditionalFiles
		'
		Me.dgvAdditionalFiles.AllowUserToAddRows = false
		Me.dgvAdditionalFiles.AllowUserToDeleteRows = false
		Me.dgvAdditionalFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvAdditionalFiles.ColumnHeadersVisible = false
		Me.dgvAdditionalFiles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FileName, Me.RemoveFile, Me.FileObject})
		resources.ApplyResources(Me.dgvAdditionalFiles, "dgvAdditionalFiles")
		Me.dgvAdditionalFiles.Name = "dgvAdditionalFiles"
		Me.dgvAdditionalFiles.ReadOnly = true
		Me.dgvAdditionalFiles.RowHeadersVisible = false
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
		Me.RemoveFile.Text = "Remove"
		Me.RemoveFile.UseColumnTextForButtonValue = true
		'
		'FileObject
		'
		Me.FileObject.Frozen = true
		resources.ApplyResources(Me.FileObject, "FileObject")
		Me.FileObject.Name = "FileObject"
		Me.FileObject.ReadOnly = true
		'
		'lblAdditionalFiles
		'
		resources.ApplyResources(Me.lblAdditionalFiles, "lblAdditionalFiles")
		Me.lblAdditionalFiles.Name = "lblAdditionalFiles"
		'
		'btnUpdateFile
		'
		resources.ApplyResources(Me.btnUpdateFile, "btnUpdateFile")
		Me.btnUpdateFile.Name = "btnUpdateFile"
		Me.btnUpdateFile.UseVisualStyleBackColor = true
		AddHandler Me.btnUpdateFile.Click, AddressOf Me.BtnUpdateFileClick
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
		'lblUpdateFile
		'
		resources.ApplyResources(Me.lblUpdateFile, "lblUpdateFile")
		Me.lblUpdateFile.Name = "lblUpdateFile"
		'
		'tabPackageInfo
		'
		Me.tabPackageInfo.BackColor = System.Drawing.SystemColors.Control
		Me.tabPackageInfo.Controls.Add(Me.txtNetwork)
		Me.tabPackageInfo.Controls.Add(Me.lblNetwork)
		Me.tabPackageInfo.Controls.Add(Me.txtOriginalURI)
		Me.tabPackageInfo.Controls.Add(Me.lblOriginalURI)
		Me.tabPackageInfo.Controls.Add(Me.cboPackageType)
		Me.tabPackageInfo.Controls.Add(Me.lblPackageType)
		Me.tabPackageInfo.Controls.Add(Me.lblPrerequisites)
		Me.tabPackageInfo.Controls.Add(Me.lblSupersedes)
		Me.tabPackageInfo.Controls.Add(Me.lblReturnCodes)
		Me.tabPackageInfo.Controls.Add(Me.txtUninstall)
		Me.tabPackageInfo.Controls.Add(Me.lblUninstall)
		Me.tabPackageInfo.Controls.Add(Me.lblPackageInfo)
		Me.tabPackageInfo.Controls.Add(Me.txtCommandLine)
		Me.tabPackageInfo.Controls.Add(Me.lblCommandLine)
		Me.tabPackageInfo.Controls.Add(Me.cboRebootBehavior)
		Me.tabPackageInfo.Controls.Add(Me.cboImpact)
		Me.tabPackageInfo.Controls.Add(Me.txtMoreInfoURL)
		Me.tabPackageInfo.Controls.Add(Me.txtSupportURL)
		Me.tabPackageInfo.Controls.Add(Me.cboSeverity)
		Me.tabPackageInfo.Controls.Add(Me.txtCVEID)
		Me.tabPackageInfo.Controls.Add(Me.txtArticleID)
		Me.tabPackageInfo.Controls.Add(Me.cboProduct)
		Me.tabPackageInfo.Controls.Add(Me.cboVendor)
		Me.tabPackageInfo.Controls.Add(Me.cboClassification)
		Me.tabPackageInfo.Controls.Add(Me.txtBulletinID)
		Me.tabPackageInfo.Controls.Add(Me.txtDescription)
		Me.tabPackageInfo.Controls.Add(Me.txtPackageTitle)
		Me.tabPackageInfo.Controls.Add(Me.lblRebootBehavior)
		Me.tabPackageInfo.Controls.Add(Me.lblImpact)
		Me.tabPackageInfo.Controls.Add(Me.lblMoreInfoURL)
		Me.tabPackageInfo.Controls.Add(Me.lblSupportURL)
		Me.tabPackageInfo.Controls.Add(Me.lblSeverity)
		Me.tabPackageInfo.Controls.Add(Me.lblCVEID)
		Me.tabPackageInfo.Controls.Add(Me.lblArticleID)
		Me.tabPackageInfo.Controls.Add(Me.lblProduct)
		Me.tabPackageInfo.Controls.Add(Me.lblVendor)
		Me.tabPackageInfo.Controls.Add(Me.lblBullitinID)
		Me.tabPackageInfo.Controls.Add(Me.lblClassification)
		Me.tabPackageInfo.Controls.Add(Me.lblDescription)
		Me.tabPackageInfo.Controls.Add(Me.lblPackageTitle)
		resources.ApplyResources(Me.tabPackageInfo, "tabPackageInfo")
		Me.tabPackageInfo.Name = "tabPackageInfo"
		'
		'txtNetwork
		'
		resources.ApplyResources(Me.txtNetwork, "txtNetwork")
		Me.txtNetwork.Name = "txtNetwork"
		Me.txtNetwork.ReadOnly = true
		'
		'lblNetwork
		'
		resources.ApplyResources(Me.lblNetwork, "lblNetwork")
		Me.lblNetwork.Name = "lblNetwork"
		'
		'txtOriginalURI
		'
		resources.ApplyResources(Me.txtOriginalURI, "txtOriginalURI")
		Me.txtOriginalURI.Name = "txtOriginalURI"
		AddHandler Me.txtOriginalURI.TextChanged, AddressOf Me.txtOriginalURITextChanged
		AddHandler Me.txtOriginalURI.KeyDown, AddressOf Me.TxtOriginalURIKeyDown
		AddHandler Me.txtOriginalURI.KeyPress, AddressOf Me.TxtOriginalURIKeyPress
		'
		'lblOriginalURI
		'
		resources.ApplyResources(Me.lblOriginalURI, "lblOriginalURI")
		Me.lblOriginalURI.Name = "lblOriginalURI"
		'
		'cboPackageType
		'
		Me.cboPackageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboPackageType.FormattingEnabled = true
		Me.cboPackageType.Items.AddRange(New Object() {resources.GetString("cboPackageType.Items"), resources.GetString("cboPackageType.Items1")})
		resources.ApplyResources(Me.cboPackageType, "cboPackageType")
		Me.cboPackageType.Name = "cboPackageType"
		AddHandler Me.cboPackageType.SelectedIndexChanged, AddressOf Me.CboPackageTypeSelectedIndexChanged
		'
		'lblPackageType
		'
		resources.ApplyResources(Me.lblPackageType, "lblPackageType")
		Me.lblPackageType.Name = "lblPackageType"
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
		AddHandler Me.lblReturnCodes.Click, AddressOf Me.LblReturnCodesClick
		'
		'txtUninstall
		'
		resources.ApplyResources(Me.txtUninstall, "txtUninstall")
		Me.txtUninstall.Name = "txtUninstall"
		Me.txtUninstall.ReadOnly = true
		'
		'lblUninstall
		'
		resources.ApplyResources(Me.lblUninstall, "lblUninstall")
		Me.lblUninstall.Name = "lblUninstall"
		'
		'lblPackageInfo
		'
		resources.ApplyResources(Me.lblPackageInfo, "lblPackageInfo")
		Me.lblPackageInfo.Name = "lblPackageInfo"
		'
		'txtCommandLine
		'
		resources.ApplyResources(Me.txtCommandLine, "txtCommandLine")
		Me.txtCommandLine.Name = "txtCommandLine"
		'
		'lblCommandLine
		'
		resources.ApplyResources(Me.lblCommandLine, "lblCommandLine")
		Me.lblCommandLine.Name = "lblCommandLine"
		'
		'cboRebootBehavior
		'
		Me.cboRebootBehavior.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboRebootBehavior.FormattingEnabled = true
		Me.cboRebootBehavior.Items.AddRange(New Object() {resources.GetString("cboRebootBehavior.Items"), resources.GetString("cboRebootBehavior.Items1"), resources.GetString("cboRebootBehavior.Items2")})
		resources.ApplyResources(Me.cboRebootBehavior, "cboRebootBehavior")
		Me.cboRebootBehavior.Name = "cboRebootBehavior"
		AddHandler Me.cboRebootBehavior.Validating, AddressOf Me.ControlValidating
		AddHandler Me.cboRebootBehavior.SelectedValueChanged, AddressOf Me.ValidateCombo
		AddHandler Me.cboRebootBehavior.Validated, AddressOf Me.ControlValidated
		'
		'cboImpact
		'
		Me.cboImpact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboImpact.FormattingEnabled = true
		Me.cboImpact.Items.AddRange(New Object() {resources.GetString("cboImpact.Items"), resources.GetString("cboImpact.Items1"), resources.GetString("cboImpact.Items2")})
		resources.ApplyResources(Me.cboImpact, "cboImpact")
		Me.cboImpact.Name = "cboImpact"
		AddHandler Me.cboImpact.Validating, AddressOf Me.ControlValidating
		AddHandler Me.cboImpact.SelectedValueChanged, AddressOf Me.ValidateCombo
		AddHandler Me.cboImpact.Validated, AddressOf Me.ControlValidated
		'
		'txtMoreInfoURL
		'
		resources.ApplyResources(Me.txtMoreInfoURL, "txtMoreInfoURL")
		Me.txtMoreInfoURL.Name = "txtMoreInfoURL"
		AddHandler Me.txtMoreInfoURL.TextChanged, AddressOf Me.txtURITextChanged
		'
		'txtSupportURL
		'
		resources.ApplyResources(Me.txtSupportURL, "txtSupportURL")
		Me.txtSupportURL.Name = "txtSupportURL"
		AddHandler Me.txtSupportURL.TextChanged, AddressOf Me.txtURITextChanged
		'
		'cboSeverity
		'
		Me.cboSeverity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		resources.ApplyResources(Me.cboSeverity, "cboSeverity")
		Me.cboSeverity.FormattingEnabled = true
		Me.cboSeverity.Items.AddRange(New Object() {resources.GetString("cboSeverity.Items"), resources.GetString("cboSeverity.Items1"), resources.GetString("cboSeverity.Items2"), resources.GetString("cboSeverity.Items3"), resources.GetString("cboSeverity.Items4")})
		Me.cboSeverity.Name = "cboSeverity"
		AddHandler Me.cboSeverity.Validating, AddressOf Me.ControlValidating
		AddHandler Me.cboSeverity.SelectedIndexChanged, AddressOf Me.ValidateCombo
		AddHandler Me.cboSeverity.Validated, AddressOf Me.ControlValidated
		'
		'txtCVEID
		'
		resources.ApplyResources(Me.txtCVEID, "txtCVEID")
		Me.txtCVEID.Name = "txtCVEID"
		'
		'txtArticleID
		'
		resources.ApplyResources(Me.txtArticleID, "txtArticleID")
		Me.txtArticleID.Name = "txtArticleID"
		'
		'cboProduct
		'
		resources.ApplyResources(Me.cboProduct, "cboProduct")
		Me.cboProduct.FormattingEnabled = true
		Me.cboProduct.Name = "cboProduct"
		AddHandler Me.cboProduct.Validating, AddressOf Me.ControlValidating
		AddHandler Me.cboProduct.SelectedIndexChanged, AddressOf Me.ValidateCombo
		AddHandler Me.cboProduct.Validated, AddressOf Me.ControlValidated
		AddHandler Me.cboProduct.TextChanged, AddressOf Me.ValidateCombo
		'
		'cboVendor
		'
		resources.ApplyResources(Me.cboVendor, "cboVendor")
		Me.cboVendor.FormattingEnabled = true
		Me.cboVendor.Name = "cboVendor"
		AddHandler Me.cboVendor.Validating, AddressOf Me.ControlValidating
		AddHandler Me.cboVendor.SelectedIndexChanged, AddressOf Me.CboVendorSelectedIndexChanged
		AddHandler Me.cboVendor.Validated, AddressOf Me.ControlValidated
		AddHandler Me.cboVendor.TextChanged, AddressOf Me.ValidateCombo
		'
		'cboClassification
		'
		Me.cboClassification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboClassification.FormattingEnabled = true
		Me.cboClassification.Items.AddRange(New Object() {resources.GetString("cboClassification.Items"), resources.GetString("cboClassification.Items1"), resources.GetString("cboClassification.Items2"), resources.GetString("cboClassification.Items3"), resources.GetString("cboClassification.Items4"), resources.GetString("cboClassification.Items5"), resources.GetString("cboClassification.Items6"), resources.GetString("cboClassification.Items7"), resources.GetString("cboClassification.Items8"), resources.GetString("cboClassification.Items9")})
		resources.ApplyResources(Me.cboClassification, "cboClassification")
		Me.cboClassification.Name = "cboClassification"
		AddHandler Me.cboClassification.Validating, AddressOf Me.ControlValidating
		AddHandler Me.cboClassification.SelectedIndexChanged, AddressOf Me.ValidateCombo
		AddHandler Me.cboClassification.Validated, AddressOf Me.ControlValidated
		'
		'txtBulletinID
		'
		resources.ApplyResources(Me.txtBulletinID, "txtBulletinID")
		Me.txtBulletinID.Name = "txtBulletinID"
		AddHandler Me.txtBulletinID.Validating, AddressOf Me.TxtBulletinIDValidating
		'
		'txtDescription
		'
		resources.ApplyResources(Me.txtDescription, "txtDescription")
		Me.txtDescription.Name = "txtDescription"
		AddHandler Me.txtDescription.Validated, AddressOf Me.ControlValidated
		AddHandler Me.txtDescription.Validating, AddressOf Me.ControlValidating
		'
		'txtPackageTitle
		'
		resources.ApplyResources(Me.txtPackageTitle, "txtPackageTitle")
		Me.txtPackageTitle.Name = "txtPackageTitle"
		AddHandler Me.txtPackageTitle.Validated, AddressOf Me.ControlValidated
		AddHandler Me.txtPackageTitle.Validating, AddressOf Me.ControlValidating
		'
		'lblRebootBehavior
		'
		resources.ApplyResources(Me.lblRebootBehavior, "lblRebootBehavior")
		Me.lblRebootBehavior.Name = "lblRebootBehavior"
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
		'lblSupportURL
		'
		resources.ApplyResources(Me.lblSupportURL, "lblSupportURL")
		Me.lblSupportURL.Name = "lblSupportURL"
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
		'lblVendor
		'
		resources.ApplyResources(Me.lblVendor, "lblVendor")
		Me.lblVendor.Name = "lblVendor"
		'
		'lblBullitinID
		'
		resources.ApplyResources(Me.lblBullitinID, "lblBullitinID")
		Me.lblBullitinID.Name = "lblBullitinID"
		AddHandler Me.lblBullitinID.Validating, AddressOf Me.ControlValidating
		'
		'lblClassification
		'
		resources.ApplyResources(Me.lblClassification, "lblClassification")
		Me.lblClassification.Name = "lblClassification"
		'
		'lblDescription
		'
		resources.ApplyResources(Me.lblDescription, "lblDescription")
		Me.lblDescription.Name = "lblDescription"
		'
		'lblPackageTitle
		'
		resources.ApplyResources(Me.lblPackageTitle, "lblPackageTitle")
		Me.lblPackageTitle.Name = "lblPackageTitle"
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
		Me.isInstalledRules.CausesValidation = false
		resources.ApplyResources(Me.isInstalledRules, "isInstalledRules")
		Me.isInstalledRules.Instructions = resources.GetString("isInstalledRules.Instructions")
		Me.isInstalledRules.Name = "isInstalledRules"
		Me.isInstalledRules.Rule = ""
		Me.isInstalledRules.RuleEditorTitle = "Installed Rule"
		Me.isInstalledRules.Title = "Package Level - Installed Rules"
		Me.isInstalledRules.TitleItemLevel = "Installation Item Level"
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
		Me.isInstallableRules.CausesValidation = false
		resources.ApplyResources(Me.isInstallableRules, "isInstallableRules")
		Me.isInstallableRules.Instructions = resources.GetString("isInstallableRules.Instructions")
		Me.isInstallableRules.Name = "isInstallableRules"
		Me.isInstallableRules.Rule = ""
		Me.isInstallableRules.RuleEditorTitle = "Installable Rule"
		Me.isInstallableRules.Title = "Package Level - Installable Rules"
		Me.isInstallableRules.TitleItemLevel = "Installation Item Level"
		'
		'tabIsSuperseded
		'
		Me.tabIsSuperseded.BackColor = System.Drawing.SystemColors.Control
		Me.tabIsSuperseded.Controls.Add(Me.btnIsSupersededEdit)
		Me.tabIsSuperseded.Controls.Add(Me.lblIsSuperseded)
		Me.tabIsSuperseded.Controls.Add(Me.lblIsSuperceded_InstallableItem)
		Me.tabIsSuperseded.Controls.Add(Me.txtIsSuperceded_InstallableItem)
		resources.ApplyResources(Me.tabIsSuperseded, "tabIsSuperseded")
		Me.tabIsSuperseded.Name = "tabIsSuperseded"
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
		Me.lblIsSuperseded.Name = "lblIsSuperseded"
		'
		'lblIsSuperceded_InstallableItem
		'
		resources.ApplyResources(Me.lblIsSuperceded_InstallableItem, "lblIsSuperceded_InstallableItem")
		Me.lblIsSuperceded_InstallableItem.Name = "lblIsSuperceded_InstallableItem"
		'
		'txtIsSuperceded_InstallableItem
		'
		resources.ApplyResources(Me.txtIsSuperceded_InstallableItem, "txtIsSuperceded_InstallableItem")
		Me.txtIsSuperceded_InstallableItem.Name = "txtIsSuperceded_InstallableItem"
		Me.txtIsSuperceded_InstallableItem.ReadOnly = true
		'
		'tabMetaData
		'
		Me.tabMetaData.BackColor = System.Drawing.SystemColors.Control
		Me.tabMetaData.Controls.Add(Me.btnMetaDataEdit)
		Me.tabMetaData.Controls.Add(Me.lblMetaData_InstallableItem)
		Me.tabMetaData.Controls.Add(Me.lblMetaData)
		Me.tabMetaData.Controls.Add(Me.txtInstallableItemMetaData)
		resources.ApplyResources(Me.tabMetaData, "tabMetaData")
		Me.tabMetaData.Name = "tabMetaData"
		'
		'btnMetaDataEdit
		'
		resources.ApplyResources(Me.btnMetaDataEdit, "btnMetaDataEdit")
		Me.btnMetaDataEdit.Name = "btnMetaDataEdit"
		Me.btnMetaDataEdit.UseVisualStyleBackColor = true
		AddHandler Me.btnMetaDataEdit.Click, AddressOf Me.BtnMetaDataEditClick
		'
		'lblMetaData_InstallableItem
		'
		resources.ApplyResources(Me.lblMetaData_InstallableItem, "lblMetaData_InstallableItem")
		Me.lblMetaData_InstallableItem.Name = "lblMetaData_InstallableItem"
		'
		'lblMetaData
		'
		resources.ApplyResources(Me.lblMetaData, "lblMetaData")
		Me.lblMetaData.Name = "lblMetaData"
		'
		'txtInstallableItemMetaData
		'
		resources.ApplyResources(Me.txtInstallableItemMetaData, "txtInstallableItemMetaData")
		Me.txtInstallableItemMetaData.Name = "txtInstallableItemMetaData"
		Me.txtInstallableItemMetaData.ReadOnly = true
		'
		'tabSummary
		'
		Me.tabSummary.BackColor = System.Drawing.SystemColors.Control
		Me.tabSummary.Controls.Add(Me.label4)
		Me.tabSummary.Controls.Add(Me.txtSummary)
		resources.ApplyResources(Me.tabSummary, "tabSummary")
		Me.tabSummary.Name = "tabSummary"
		'
		'label4
		'
		resources.ApplyResources(Me.label4, "label4")
		Me.label4.Name = "label4"
		'
		'txtSummary
		'
		resources.ApplyResources(Me.txtSummary, "txtSummary")
		Me.txtSummary.Name = "txtSummary"
		Me.txtSummary.ReadOnly = true
		Me.txtSummary.TabStop = false
		'
		'btnPrevious
		'
		resources.ApplyResources(Me.btnPrevious, "btnPrevious")
		Me.btnPrevious.CausesValidation = false
		Me.btnPrevious.Name = "btnPrevious"
		Me.btnPrevious.UseVisualStyleBackColor = true
		AddHandler Me.btnPrevious.Click, AddressOf Me.BtnPreviousClick
		'
		'btnNext
		'
		resources.ApplyResources(Me.btnNext, "btnNext")
		Me.btnNext.CausesValidation = false
		Me.btnNext.Name = "btnNext"
		Me.btnNext.UseVisualStyleBackColor = true
		AddHandler Me.btnNext.Click, AddressOf Me.BtnNextClick
		'
		'btnCancel
		'
		resources.ApplyResources(Me.btnCancel, "btnCancel")
		Me.btnCancel.CausesValidation = false
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
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
		'chkMetadataOnly
		'
		resources.ApplyResources(Me.chkMetadataOnly, "chkMetadataOnly")
		Me.chkMetadataOnly.CausesValidation = false
		Me.chkMetadataOnly.Name = "chkMetadataOnly"
		Me.chkMetadataOnly.UseVisualStyleBackColor = true
		AddHandler Me.chkMetadataOnly.CheckedChanged, AddressOf Me.CboMetadataOnlyCheckedChanged
		'
		'errorProviderUpdate
		'
		Me.errorProviderUpdate.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
		Me.errorProviderUpdate.ContainerControl = Me
		'
		'UpdateForm
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
		Me.CancelButton = Me.btnCancel
		Me.Controls.Add(Me.chkMetadataOnly)
		Me.Controls.Add(Me.chkExportSdp)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnNext)
		Me.Controls.Add(Me.btnPrevious)
		Me.Controls.Add(Me.tabsImportUpdate)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "UpdateForm"
		Me.ShowInTaskbar = false
		Me.tabsImportUpdate.ResumeLayout(false)
		Me.tabIntro.ResumeLayout(false)
		Me.tabIntro.PerformLayout
		CType(Me.dgvAdditionalFiles,System.ComponentModel.ISupportInitialize).EndInit
		Me.tabPackageInfo.ResumeLayout(false)
		Me.tabPackageInfo.PerformLayout
		Me.tabIsInstalled.ResumeLayout(false)
		Me.tabIsInstallable.ResumeLayout(false)
		Me.tabIsSuperseded.ResumeLayout(false)
		Me.tabIsSuperseded.PerformLayout
		Me.tabMetaData.ResumeLayout(false)
		Me.tabMetaData.PerformLayout
		Me.tabSummary.ResumeLayout(false)
		Me.tabSummary.PerformLayout
		CType(Me.errorProviderUpdate,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
	End Sub
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
	Private label4 As System.Windows.Forms.Label
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
	Private tabsImportUpdate As LocalUpdatePublisher.CustomTabControl
End Class
