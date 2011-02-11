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
		Me.tabsImportUpdate.AccessibleDescription = Nothing
		Me.tabsImportUpdate.AccessibleName = Nothing
		resources.ApplyResources(Me.tabsImportUpdate, "tabsImportUpdate")
		Me.tabsImportUpdate.BackgroundImage = Nothing
		Me.tabsImportUpdate.Controls.Add(Me.tabIntro)
		Me.tabsImportUpdate.Controls.Add(Me.tabPackageInfo)
		Me.tabsImportUpdate.Controls.Add(Me.tabIsInstalled)
		Me.tabsImportUpdate.Controls.Add(Me.tabIsInstallable)
		Me.tabsImportUpdate.Controls.Add(Me.tabIsSuperseded)
		Me.tabsImportUpdate.Controls.Add(Me.tabMetaData)
		Me.tabsImportUpdate.Controls.Add(Me.tabSummary)
		Me.errorProviderUpdate.SetError(Me.tabsImportUpdate, resources.GetString("tabsImportUpdate.Error"))
		Me.tabsImportUpdate.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.tabsImportUpdate, CType(resources.GetObject("tabsImportUpdate.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.tabsImportUpdate, CType(resources.GetObject("tabsImportUpdate.IconPadding"),Integer))
		Me.tabsImportUpdate.Name = "tabsImportUpdate"
		Me.tabsImportUpdate.SelectedIndex = 0
		'
		'tabIntro
		'
		Me.tabIntro.AccessibleDescription = Nothing
		Me.tabIntro.AccessibleName = Nothing
		resources.ApplyResources(Me.tabIntro, "tabIntro")
		Me.tabIntro.BackColor = System.Drawing.SystemColors.Control
		Me.tabIntro.BackgroundImage = Nothing
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
		Me.errorProviderUpdate.SetError(Me.tabIntro, resources.GetString("tabIntro.Error"))
		Me.tabIntro.Font = Nothing
		Me.tabIntro.ForeColor = System.Drawing.SystemColors.ControlText
		Me.errorProviderUpdate.SetIconAlignment(Me.tabIntro, CType(resources.GetObject("tabIntro.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.tabIntro, CType(resources.GetObject("tabIntro.IconPadding"),Integer))
		Me.tabIntro.Name = "tabIntro"
		'
		'btnAddDir
		'
		Me.btnAddDir.AccessibleDescription = Nothing
		Me.btnAddDir.AccessibleName = Nothing
		resources.ApplyResources(Me.btnAddDir, "btnAddDir")
		Me.btnAddDir.BackgroundImage = Nothing
		Me.errorProviderUpdate.SetError(Me.btnAddDir, resources.GetString("btnAddDir.Error"))
		Me.btnAddDir.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.btnAddDir, CType(resources.GetObject("btnAddDir.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.btnAddDir, CType(resources.GetObject("btnAddDir.IconPadding"),Integer))
		Me.btnAddDir.Name = "btnAddDir"
		Me.btnAddDir.UseVisualStyleBackColor = true
		AddHandler Me.btnAddDir.Click, AddressOf Me.BtnAddDirClick
		'
		'lblInfo
		'
		Me.lblInfo.AccessibleDescription = Nothing
		Me.lblInfo.AccessibleName = Nothing
		resources.ApplyResources(Me.lblInfo, "lblInfo")
		Me.errorProviderUpdate.SetError(Me.lblInfo, resources.GetString("lblInfo.Error"))
		Me.errorProviderUpdate.SetIconAlignment(Me.lblInfo, CType(resources.GetObject("lblInfo.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.lblInfo, CType(resources.GetObject("lblInfo.IconPadding"),Integer))
		Me.lblInfo.Name = "lblInfo"
		'
		'txtMSIPath
		'
		Me.txtMSIPath.AccessibleDescription = Nothing
		Me.txtMSIPath.AccessibleName = Nothing
		resources.ApplyResources(Me.txtMSIPath, "txtMSIPath")
		Me.txtMSIPath.BackgroundImage = Nothing
		Me.errorProviderUpdate.SetError(Me.txtMSIPath, resources.GetString("txtMSIPath.Error"))
		Me.txtMSIPath.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.txtMSIPath, CType(resources.GetObject("txtMSIPath.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.txtMSIPath, CType(resources.GetObject("txtMSIPath.IconPadding"),Integer))
		Me.txtMSIPath.Name = "txtMSIPath"
		'
		'lblMSIPath
		'
		Me.lblMSIPath.AccessibleDescription = Nothing
		Me.lblMSIPath.AccessibleName = Nothing
		resources.ApplyResources(Me.lblMSIPath, "lblMSIPath")
		Me.errorProviderUpdate.SetError(Me.lblMSIPath, resources.GetString("lblMSIPath.Error"))
		Me.errorProviderUpdate.SetIconAlignment(Me.lblMSIPath, CType(resources.GetObject("lblMSIPath.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.lblMSIPath, CType(resources.GetObject("lblMSIPath.IconPadding"),Integer))
		Me.lblMSIPath.Name = "lblMSIPath"
		'
		'btnAddFiles
		'
		Me.btnAddFiles.AccessibleDescription = Nothing
		Me.btnAddFiles.AccessibleName = Nothing
		resources.ApplyResources(Me.btnAddFiles, "btnAddFiles")
		Me.btnAddFiles.BackgroundImage = Nothing
		Me.errorProviderUpdate.SetError(Me.btnAddFiles, resources.GetString("btnAddFiles.Error"))
		Me.btnAddFiles.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.btnAddFiles, CType(resources.GetObject("btnAddFiles.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.btnAddFiles, CType(resources.GetObject("btnAddFiles.IconPadding"),Integer))
		Me.btnAddFiles.Name = "btnAddFiles"
		Me.btnAddFiles.UseVisualStyleBackColor = true
		AddHandler Me.btnAddFiles.Click, AddressOf Me.BtnAddFilesClick
		'
		'dgvAdditionalFiles
		'
		Me.dgvAdditionalFiles.AccessibleDescription = Nothing
		Me.dgvAdditionalFiles.AccessibleName = Nothing
		Me.dgvAdditionalFiles.AllowUserToAddRows = false
		Me.dgvAdditionalFiles.AllowUserToDeleteRows = false
		resources.ApplyResources(Me.dgvAdditionalFiles, "dgvAdditionalFiles")
		Me.dgvAdditionalFiles.BackgroundImage = Nothing
		Me.dgvAdditionalFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvAdditionalFiles.ColumnHeadersVisible = false
		Me.dgvAdditionalFiles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FileName, Me.RemoveFile, Me.FileObject})
		Me.errorProviderUpdate.SetError(Me.dgvAdditionalFiles, resources.GetString("dgvAdditionalFiles.Error"))
		Me.dgvAdditionalFiles.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.dgvAdditionalFiles, CType(resources.GetObject("dgvAdditionalFiles.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.dgvAdditionalFiles, CType(resources.GetObject("dgvAdditionalFiles.IconPadding"),Integer))
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
		Me.RemoveFile.Text = "Supprimer"
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
		Me.lblAdditionalFiles.AccessibleDescription = Nothing
		Me.lblAdditionalFiles.AccessibleName = Nothing
		resources.ApplyResources(Me.lblAdditionalFiles, "lblAdditionalFiles")
		Me.errorProviderUpdate.SetError(Me.lblAdditionalFiles, resources.GetString("lblAdditionalFiles.Error"))
		Me.errorProviderUpdate.SetIconAlignment(Me.lblAdditionalFiles, CType(resources.GetObject("lblAdditionalFiles.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.lblAdditionalFiles, CType(resources.GetObject("lblAdditionalFiles.IconPadding"),Integer))
		Me.lblAdditionalFiles.Name = "lblAdditionalFiles"
		'
		'btnUpdateFile
		'
		Me.btnUpdateFile.AccessibleDescription = Nothing
		Me.btnUpdateFile.AccessibleName = Nothing
		resources.ApplyResources(Me.btnUpdateFile, "btnUpdateFile")
		Me.btnUpdateFile.BackgroundImage = Nothing
		Me.errorProviderUpdate.SetError(Me.btnUpdateFile, resources.GetString("btnUpdateFile.Error"))
		Me.btnUpdateFile.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.btnUpdateFile, CType(resources.GetObject("btnUpdateFile.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.btnUpdateFile, CType(resources.GetObject("btnUpdateFile.IconPadding"),Integer))
		Me.btnUpdateFile.Name = "btnUpdateFile"
		Me.btnUpdateFile.UseVisualStyleBackColor = true
		AddHandler Me.btnUpdateFile.Click, AddressOf Me.BtnUpdateFileClick
		'
		'txtUpdateFile
		'
		Me.txtUpdateFile.AccessibleDescription = Nothing
		Me.txtUpdateFile.AccessibleName = Nothing
		resources.ApplyResources(Me.txtUpdateFile, "txtUpdateFile")
		Me.txtUpdateFile.BackgroundImage = Nothing
		Me.errorProviderUpdate.SetError(Me.txtUpdateFile, resources.GetString("txtUpdateFile.Error"))
		Me.txtUpdateFile.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.txtUpdateFile, CType(resources.GetObject("txtUpdateFile.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.txtUpdateFile, CType(resources.GetObject("txtUpdateFile.IconPadding"),Integer))
		Me.txtUpdateFile.Name = "txtUpdateFile"
		Me.txtUpdateFile.ReadOnly = true
		Me.txtUpdateFile.TabStop = false
		AddHandler Me.txtUpdateFile.Validated, AddressOf Me.ControlValidated
		AddHandler Me.txtUpdateFile.Validating, AddressOf Me.ControlValidating
		'
		'lblUpdateFile
		'
		Me.lblUpdateFile.AccessibleDescription = Nothing
		Me.lblUpdateFile.AccessibleName = Nothing
		resources.ApplyResources(Me.lblUpdateFile, "lblUpdateFile")
		Me.errorProviderUpdate.SetError(Me.lblUpdateFile, resources.GetString("lblUpdateFile.Error"))
		Me.errorProviderUpdate.SetIconAlignment(Me.lblUpdateFile, CType(resources.GetObject("lblUpdateFile.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.lblUpdateFile, CType(resources.GetObject("lblUpdateFile.IconPadding"),Integer))
		Me.lblUpdateFile.Name = "lblUpdateFile"
		'
		'tabPackageInfo
		'
		Me.tabPackageInfo.AccessibleDescription = Nothing
		Me.tabPackageInfo.AccessibleName = Nothing
		resources.ApplyResources(Me.tabPackageInfo, "tabPackageInfo")
		Me.tabPackageInfo.BackColor = System.Drawing.SystemColors.Control
		Me.tabPackageInfo.BackgroundImage = Nothing
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
		Me.errorProviderUpdate.SetError(Me.tabPackageInfo, resources.GetString("tabPackageInfo.Error"))
		Me.tabPackageInfo.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.tabPackageInfo, CType(resources.GetObject("tabPackageInfo.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.tabPackageInfo, CType(resources.GetObject("tabPackageInfo.IconPadding"),Integer))
		Me.tabPackageInfo.Name = "tabPackageInfo"
		'
		'txtNetwork
		'
		Me.txtNetwork.AccessibleDescription = Nothing
		Me.txtNetwork.AccessibleName = Nothing
		resources.ApplyResources(Me.txtNetwork, "txtNetwork")
		Me.txtNetwork.BackgroundImage = Nothing
		Me.errorProviderUpdate.SetError(Me.txtNetwork, resources.GetString("txtNetwork.Error"))
		Me.txtNetwork.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.txtNetwork, CType(resources.GetObject("txtNetwork.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.txtNetwork, CType(resources.GetObject("txtNetwork.IconPadding"),Integer))
		Me.txtNetwork.Name = "txtNetwork"
		Me.txtNetwork.ReadOnly = true
		'
		'lblNetwork
		'
		Me.lblNetwork.AccessibleDescription = Nothing
		Me.lblNetwork.AccessibleName = Nothing
		resources.ApplyResources(Me.lblNetwork, "lblNetwork")
		Me.errorProviderUpdate.SetError(Me.lblNetwork, resources.GetString("lblNetwork.Error"))
		Me.errorProviderUpdate.SetIconAlignment(Me.lblNetwork, CType(resources.GetObject("lblNetwork.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.lblNetwork, CType(resources.GetObject("lblNetwork.IconPadding"),Integer))
		Me.lblNetwork.Name = "lblNetwork"
		'
		'txtOriginalURI
		'
		Me.txtOriginalURI.AccessibleDescription = Nothing
		Me.txtOriginalURI.AccessibleName = Nothing
		resources.ApplyResources(Me.txtOriginalURI, "txtOriginalURI")
		Me.txtOriginalURI.BackgroundImage = Nothing
		Me.errorProviderUpdate.SetError(Me.txtOriginalURI, resources.GetString("txtOriginalURI.Error"))
		Me.txtOriginalURI.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.txtOriginalURI, CType(resources.GetObject("txtOriginalURI.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.txtOriginalURI, CType(resources.GetObject("txtOriginalURI.IconPadding"),Integer))
		Me.txtOriginalURI.Name = "txtOriginalURI"
		AddHandler Me.txtOriginalURI.TextChanged, AddressOf Me.txtOriginalURITextChanged
		AddHandler Me.txtOriginalURI.KeyDown, AddressOf Me.TxtOriginalURIKeyDown
		AddHandler Me.txtOriginalURI.KeyPress, AddressOf Me.TxtOriginalURIKeyPress
		'
		'lblOriginalURI
		'
		Me.lblOriginalURI.AccessibleDescription = Nothing
		Me.lblOriginalURI.AccessibleName = Nothing
		resources.ApplyResources(Me.lblOriginalURI, "lblOriginalURI")
		Me.errorProviderUpdate.SetError(Me.lblOriginalURI, resources.GetString("lblOriginalURI.Error"))
		Me.errorProviderUpdate.SetIconAlignment(Me.lblOriginalURI, CType(resources.GetObject("lblOriginalURI.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.lblOriginalURI, CType(resources.GetObject("lblOriginalURI.IconPadding"),Integer))
		Me.lblOriginalURI.Name = "lblOriginalURI"
		'
		'cboPackageType
		'
		Me.cboPackageType.AccessibleDescription = Nothing
		Me.cboPackageType.AccessibleName = Nothing
		resources.ApplyResources(Me.cboPackageType, "cboPackageType")
		Me.cboPackageType.BackgroundImage = Nothing
		Me.cboPackageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.errorProviderUpdate.SetError(Me.cboPackageType, resources.GetString("cboPackageType.Error"))
		Me.cboPackageType.Font = Nothing
		Me.cboPackageType.FormattingEnabled = true
		Me.errorProviderUpdate.SetIconAlignment(Me.cboPackageType, CType(resources.GetObject("cboPackageType.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.cboPackageType, CType(resources.GetObject("cboPackageType.IconPadding"),Integer))
		Me.cboPackageType.Items.AddRange(New Object() {resources.GetString("cboPackageType.Items"), resources.GetString("cboPackageType.Items1")})
		Me.cboPackageType.Name = "cboPackageType"
		AddHandler Me.cboPackageType.SelectedIndexChanged, AddressOf Me.CboPackageTypeSelectedIndexChanged
		'
		'lblPackageType
		'
		Me.lblPackageType.AccessibleDescription = Nothing
		Me.lblPackageType.AccessibleName = Nothing
		resources.ApplyResources(Me.lblPackageType, "lblPackageType")
		Me.errorProviderUpdate.SetError(Me.lblPackageType, resources.GetString("lblPackageType.Error"))
		Me.errorProviderUpdate.SetIconAlignment(Me.lblPackageType, CType(resources.GetObject("lblPackageType.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.lblPackageType, CType(resources.GetObject("lblPackageType.IconPadding"),Integer))
		Me.lblPackageType.Name = "lblPackageType"
		'
		'lblPrerequisites
		'
		Me.lblPrerequisites.AccessibleDescription = Nothing
		Me.lblPrerequisites.AccessibleName = Nothing
		resources.ApplyResources(Me.lblPrerequisites, "lblPrerequisites")
		Me.errorProviderUpdate.SetError(Me.lblPrerequisites, resources.GetString("lblPrerequisites.Error"))
		Me.lblPrerequisites.ForeColor = System.Drawing.SystemColors.ActiveCaption
		Me.errorProviderUpdate.SetIconAlignment(Me.lblPrerequisites, CType(resources.GetObject("lblPrerequisites.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.lblPrerequisites, CType(resources.GetObject("lblPrerequisites.IconPadding"),Integer))
		Me.lblPrerequisites.Name = "lblPrerequisites"
		AddHandler Me.lblPrerequisites.Click, AddressOf Me.LblPrerequisitesClick
		'
		'lblSupersedes
		'
		Me.lblSupersedes.AccessibleDescription = Nothing
		Me.lblSupersedes.AccessibleName = Nothing
		resources.ApplyResources(Me.lblSupersedes, "lblSupersedes")
		Me.errorProviderUpdate.SetError(Me.lblSupersedes, resources.GetString("lblSupersedes.Error"))
		Me.lblSupersedes.ForeColor = System.Drawing.SystemColors.ActiveCaption
		Me.errorProviderUpdate.SetIconAlignment(Me.lblSupersedes, CType(resources.GetObject("lblSupersedes.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.lblSupersedes, CType(resources.GetObject("lblSupersedes.IconPadding"),Integer))
		Me.lblSupersedes.Name = "lblSupersedes"
		AddHandler Me.lblSupersedes.Click, AddressOf Me.LblSupersedesClick
		'
		'lblReturnCodes
		'
		Me.lblReturnCodes.AccessibleDescription = Nothing
		Me.lblReturnCodes.AccessibleName = Nothing
		resources.ApplyResources(Me.lblReturnCodes, "lblReturnCodes")
		Me.errorProviderUpdate.SetError(Me.lblReturnCodes, resources.GetString("lblReturnCodes.Error"))
		Me.lblReturnCodes.ForeColor = System.Drawing.SystemColors.ActiveCaption
		Me.errorProviderUpdate.SetIconAlignment(Me.lblReturnCodes, CType(resources.GetObject("lblReturnCodes.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.lblReturnCodes, CType(resources.GetObject("lblReturnCodes.IconPadding"),Integer))
		Me.lblReturnCodes.Name = "lblReturnCodes"
		AddHandler Me.lblReturnCodes.Click, AddressOf Me.LblReturnCodesClick
		'
		'txtUninstall
		'
		Me.txtUninstall.AccessibleDescription = Nothing
		Me.txtUninstall.AccessibleName = Nothing
		resources.ApplyResources(Me.txtUninstall, "txtUninstall")
		Me.txtUninstall.BackgroundImage = Nothing
		Me.errorProviderUpdate.SetError(Me.txtUninstall, resources.GetString("txtUninstall.Error"))
		Me.txtUninstall.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.txtUninstall, CType(resources.GetObject("txtUninstall.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.txtUninstall, CType(resources.GetObject("txtUninstall.IconPadding"),Integer))
		Me.txtUninstall.Name = "txtUninstall"
		Me.txtUninstall.ReadOnly = true
		'
		'lblUninstall
		'
		Me.lblUninstall.AccessibleDescription = Nothing
		Me.lblUninstall.AccessibleName = Nothing
		resources.ApplyResources(Me.lblUninstall, "lblUninstall")
		Me.errorProviderUpdate.SetError(Me.lblUninstall, resources.GetString("lblUninstall.Error"))
		Me.errorProviderUpdate.SetIconAlignment(Me.lblUninstall, CType(resources.GetObject("lblUninstall.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.lblUninstall, CType(resources.GetObject("lblUninstall.IconPadding"),Integer))
		Me.lblUninstall.Name = "lblUninstall"
		'
		'lblPackageInfo
		'
		Me.lblPackageInfo.AccessibleDescription = Nothing
		Me.lblPackageInfo.AccessibleName = Nothing
		resources.ApplyResources(Me.lblPackageInfo, "lblPackageInfo")
		Me.errorProviderUpdate.SetError(Me.lblPackageInfo, resources.GetString("lblPackageInfo.Error"))
		Me.errorProviderUpdate.SetIconAlignment(Me.lblPackageInfo, CType(resources.GetObject("lblPackageInfo.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.lblPackageInfo, CType(resources.GetObject("lblPackageInfo.IconPadding"),Integer))
		Me.lblPackageInfo.Name = "lblPackageInfo"
		'
		'txtCommandLine
		'
		Me.txtCommandLine.AccessibleDescription = Nothing
		Me.txtCommandLine.AccessibleName = Nothing
		resources.ApplyResources(Me.txtCommandLine, "txtCommandLine")
		Me.txtCommandLine.BackgroundImage = Nothing
		Me.errorProviderUpdate.SetError(Me.txtCommandLine, resources.GetString("txtCommandLine.Error"))
		Me.txtCommandLine.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.txtCommandLine, CType(resources.GetObject("txtCommandLine.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.txtCommandLine, CType(resources.GetObject("txtCommandLine.IconPadding"),Integer))
		Me.txtCommandLine.Name = "txtCommandLine"
		'
		'lblCommandLine
		'
		Me.lblCommandLine.AccessibleDescription = Nothing
		Me.lblCommandLine.AccessibleName = Nothing
		resources.ApplyResources(Me.lblCommandLine, "lblCommandLine")
		Me.errorProviderUpdate.SetError(Me.lblCommandLine, resources.GetString("lblCommandLine.Error"))
		Me.errorProviderUpdate.SetIconAlignment(Me.lblCommandLine, CType(resources.GetObject("lblCommandLine.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.lblCommandLine, CType(resources.GetObject("lblCommandLine.IconPadding"),Integer))
		Me.lblCommandLine.Name = "lblCommandLine"
		'
		'cboRebootBehavior
		'
		Me.cboRebootBehavior.AccessibleDescription = Nothing
		Me.cboRebootBehavior.AccessibleName = Nothing
		resources.ApplyResources(Me.cboRebootBehavior, "cboRebootBehavior")
		Me.cboRebootBehavior.BackgroundImage = Nothing
		Me.cboRebootBehavior.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.errorProviderUpdate.SetError(Me.cboRebootBehavior, resources.GetString("cboRebootBehavior.Error"))
		Me.cboRebootBehavior.Font = Nothing
		Me.cboRebootBehavior.FormattingEnabled = true
		Me.errorProviderUpdate.SetIconAlignment(Me.cboRebootBehavior, CType(resources.GetObject("cboRebootBehavior.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.cboRebootBehavior, CType(resources.GetObject("cboRebootBehavior.IconPadding"),Integer))
		Me.cboRebootBehavior.Items.AddRange(New Object() {resources.GetString("cboRebootBehavior.Items"), resources.GetString("cboRebootBehavior.Items1"), resources.GetString("cboRebootBehavior.Items2")})
		Me.cboRebootBehavior.Name = "cboRebootBehavior"
		AddHandler Me.cboRebootBehavior.Validating, AddressOf Me.ControlValidating
		AddHandler Me.cboRebootBehavior.SelectedValueChanged, AddressOf Me.ValidateCombo
		AddHandler Me.cboRebootBehavior.Validated, AddressOf Me.ControlValidated
		'
		'cboImpact
		'
		Me.cboImpact.AccessibleDescription = Nothing
		Me.cboImpact.AccessibleName = Nothing
		resources.ApplyResources(Me.cboImpact, "cboImpact")
		Me.cboImpact.BackgroundImage = Nothing
		Me.cboImpact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.errorProviderUpdate.SetError(Me.cboImpact, resources.GetString("cboImpact.Error"))
		Me.cboImpact.Font = Nothing
		Me.cboImpact.FormattingEnabled = true
		Me.errorProviderUpdate.SetIconAlignment(Me.cboImpact, CType(resources.GetObject("cboImpact.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.cboImpact, CType(resources.GetObject("cboImpact.IconPadding"),Integer))
		Me.cboImpact.Items.AddRange(New Object() {resources.GetString("cboImpact.Items"), resources.GetString("cboImpact.Items1"), resources.GetString("cboImpact.Items2")})
		Me.cboImpact.Name = "cboImpact"
		AddHandler Me.cboImpact.Validating, AddressOf Me.ControlValidating
		AddHandler Me.cboImpact.SelectedValueChanged, AddressOf Me.ValidateCombo
		AddHandler Me.cboImpact.Validated, AddressOf Me.ControlValidated
		'
		'txtMoreInfoURL
		'
		Me.txtMoreInfoURL.AccessibleDescription = Nothing
		Me.txtMoreInfoURL.AccessibleName = Nothing
		resources.ApplyResources(Me.txtMoreInfoURL, "txtMoreInfoURL")
		Me.txtMoreInfoURL.BackgroundImage = Nothing
		Me.errorProviderUpdate.SetError(Me.txtMoreInfoURL, resources.GetString("txtMoreInfoURL.Error"))
		Me.txtMoreInfoURL.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.txtMoreInfoURL, CType(resources.GetObject("txtMoreInfoURL.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.txtMoreInfoURL, CType(resources.GetObject("txtMoreInfoURL.IconPadding"),Integer))
		Me.txtMoreInfoURL.Name = "txtMoreInfoURL"
		AddHandler Me.txtMoreInfoURL.TextChanged, AddressOf Me.txtURITextChanged
		'
		'txtSupportURL
		'
		Me.txtSupportURL.AccessibleDescription = Nothing
		Me.txtSupportURL.AccessibleName = Nothing
		resources.ApplyResources(Me.txtSupportURL, "txtSupportURL")
		Me.txtSupportURL.BackgroundImage = Nothing
		Me.errorProviderUpdate.SetError(Me.txtSupportURL, resources.GetString("txtSupportURL.Error"))
		Me.txtSupportURL.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.txtSupportURL, CType(resources.GetObject("txtSupportURL.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.txtSupportURL, CType(resources.GetObject("txtSupportURL.IconPadding"),Integer))
		Me.txtSupportURL.Name = "txtSupportURL"
		AddHandler Me.txtSupportURL.TextChanged, AddressOf Me.txtURITextChanged
		'
		'cboSeverity
		'
		Me.cboSeverity.AccessibleDescription = Nothing
		Me.cboSeverity.AccessibleName = Nothing
		resources.ApplyResources(Me.cboSeverity, "cboSeverity")
		Me.cboSeverity.BackgroundImage = Nothing
		Me.cboSeverity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.errorProviderUpdate.SetError(Me.cboSeverity, resources.GetString("cboSeverity.Error"))
		Me.cboSeverity.Font = Nothing
		Me.cboSeverity.FormattingEnabled = true
		Me.errorProviderUpdate.SetIconAlignment(Me.cboSeverity, CType(resources.GetObject("cboSeverity.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.cboSeverity, CType(resources.GetObject("cboSeverity.IconPadding"),Integer))
		Me.cboSeverity.Items.AddRange(New Object() {resources.GetString("cboSeverity.Items"), resources.GetString("cboSeverity.Items1"), resources.GetString("cboSeverity.Items2"), resources.GetString("cboSeverity.Items3"), resources.GetString("cboSeverity.Items4")})
		Me.cboSeverity.Name = "cboSeverity"
		AddHandler Me.cboSeverity.Validating, AddressOf Me.ControlValidating
		AddHandler Me.cboSeverity.SelectedIndexChanged, AddressOf Me.ValidateCombo
		AddHandler Me.cboSeverity.Validated, AddressOf Me.ControlValidated
		'
		'txtCVEID
		'
		Me.txtCVEID.AccessibleDescription = Nothing
		Me.txtCVEID.AccessibleName = Nothing
		resources.ApplyResources(Me.txtCVEID, "txtCVEID")
		Me.txtCVEID.BackgroundImage = Nothing
		Me.errorProviderUpdate.SetError(Me.txtCVEID, resources.GetString("txtCVEID.Error"))
		Me.txtCVEID.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.txtCVEID, CType(resources.GetObject("txtCVEID.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.txtCVEID, CType(resources.GetObject("txtCVEID.IconPadding"),Integer))
		Me.txtCVEID.Name = "txtCVEID"
		'
		'txtArticleID
		'
		Me.txtArticleID.AccessibleDescription = Nothing
		Me.txtArticleID.AccessibleName = Nothing
		resources.ApplyResources(Me.txtArticleID, "txtArticleID")
		Me.txtArticleID.BackgroundImage = Nothing
		Me.errorProviderUpdate.SetError(Me.txtArticleID, resources.GetString("txtArticleID.Error"))
		Me.txtArticleID.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.txtArticleID, CType(resources.GetObject("txtArticleID.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.txtArticleID, CType(resources.GetObject("txtArticleID.IconPadding"),Integer))
		Me.txtArticleID.Name = "txtArticleID"
		'
		'cboProduct
		'
		Me.cboProduct.AccessibleDescription = Nothing
		Me.cboProduct.AccessibleName = Nothing
		resources.ApplyResources(Me.cboProduct, "cboProduct")
		Me.cboProduct.BackgroundImage = Nothing
		Me.errorProviderUpdate.SetError(Me.cboProduct, resources.GetString("cboProduct.Error"))
		Me.cboProduct.Font = Nothing
		Me.cboProduct.FormattingEnabled = true
		Me.errorProviderUpdate.SetIconAlignment(Me.cboProduct, CType(resources.GetObject("cboProduct.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.cboProduct, CType(resources.GetObject("cboProduct.IconPadding"),Integer))
		Me.cboProduct.Name = "cboProduct"
		AddHandler Me.cboProduct.Validating, AddressOf Me.ControlValidating
		AddHandler Me.cboProduct.SelectedIndexChanged, AddressOf Me.ValidateCombo
		AddHandler Me.cboProduct.Validated, AddressOf Me.ControlValidated
		AddHandler Me.cboProduct.TextChanged, AddressOf Me.ValidateCombo
		'
		'cboVendor
		'
		Me.cboVendor.AccessibleDescription = Nothing
		Me.cboVendor.AccessibleName = Nothing
		resources.ApplyResources(Me.cboVendor, "cboVendor")
		Me.cboVendor.BackgroundImage = Nothing
		Me.errorProviderUpdate.SetError(Me.cboVendor, resources.GetString("cboVendor.Error"))
		Me.cboVendor.Font = Nothing
		Me.cboVendor.FormattingEnabled = true
		Me.errorProviderUpdate.SetIconAlignment(Me.cboVendor, CType(resources.GetObject("cboVendor.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.cboVendor, CType(resources.GetObject("cboVendor.IconPadding"),Integer))
		Me.cboVendor.Name = "cboVendor"
		AddHandler Me.cboVendor.Validating, AddressOf Me.ControlValidating
		AddHandler Me.cboVendor.SelectedIndexChanged, AddressOf Me.CboVendorSelectedIndexChanged
		AddHandler Me.cboVendor.Validated, AddressOf Me.ControlValidated
		AddHandler Me.cboVendor.TextChanged, AddressOf Me.ValidateCombo
		'
		'cboClassification
		'
		Me.cboClassification.AccessibleDescription = Nothing
		Me.cboClassification.AccessibleName = Nothing
		resources.ApplyResources(Me.cboClassification, "cboClassification")
		Me.cboClassification.BackgroundImage = Nothing
		Me.cboClassification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.errorProviderUpdate.SetError(Me.cboClassification, resources.GetString("cboClassification.Error"))
		Me.cboClassification.Font = Nothing
		Me.cboClassification.FormattingEnabled = true
		Me.errorProviderUpdate.SetIconAlignment(Me.cboClassification, CType(resources.GetObject("cboClassification.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.cboClassification, CType(resources.GetObject("cboClassification.IconPadding"),Integer))
		Me.cboClassification.Items.AddRange(New Object() {resources.GetString("cboClassification.Items"), resources.GetString("cboClassification.Items1"), resources.GetString("cboClassification.Items2"), resources.GetString("cboClassification.Items3"), resources.GetString("cboClassification.Items4"), resources.GetString("cboClassification.Items5"), resources.GetString("cboClassification.Items6"), resources.GetString("cboClassification.Items7"), resources.GetString("cboClassification.Items8"), resources.GetString("cboClassification.Items9")})
		Me.cboClassification.Name = "cboClassification"
		AddHandler Me.cboClassification.Validating, AddressOf Me.ControlValidating
		AddHandler Me.cboClassification.SelectedIndexChanged, AddressOf Me.ValidateCombo
		AddHandler Me.cboClassification.Validated, AddressOf Me.ControlValidated
		'
		'txtBulletinID
		'
		Me.txtBulletinID.AccessibleDescription = Nothing
		Me.txtBulletinID.AccessibleName = Nothing
		resources.ApplyResources(Me.txtBulletinID, "txtBulletinID")
		Me.txtBulletinID.BackgroundImage = Nothing
		Me.errorProviderUpdate.SetError(Me.txtBulletinID, resources.GetString("txtBulletinID.Error"))
		Me.txtBulletinID.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.txtBulletinID, CType(resources.GetObject("txtBulletinID.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.txtBulletinID, CType(resources.GetObject("txtBulletinID.IconPadding"),Integer))
		Me.txtBulletinID.Name = "txtBulletinID"
		AddHandler Me.txtBulletinID.Validating, AddressOf Me.TxtBulletinIDValidating
		'
		'txtDescription
		'
		Me.txtDescription.AccessibleDescription = Nothing
		Me.txtDescription.AccessibleName = Nothing
		resources.ApplyResources(Me.txtDescription, "txtDescription")
		Me.txtDescription.BackgroundImage = Nothing
		Me.errorProviderUpdate.SetError(Me.txtDescription, resources.GetString("txtDescription.Error"))
		Me.txtDescription.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.txtDescription, CType(resources.GetObject("txtDescription.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.txtDescription, CType(resources.GetObject("txtDescription.IconPadding"),Integer))
		Me.txtDescription.Name = "txtDescription"
		AddHandler Me.txtDescription.Validated, AddressOf Me.ControlValidated
		AddHandler Me.txtDescription.Validating, AddressOf Me.ControlValidating
		'
		'txtPackageTitle
		'
		Me.txtPackageTitle.AccessibleDescription = Nothing
		Me.txtPackageTitle.AccessibleName = Nothing
		resources.ApplyResources(Me.txtPackageTitle, "txtPackageTitle")
		Me.txtPackageTitle.BackgroundImage = Nothing
		Me.errorProviderUpdate.SetError(Me.txtPackageTitle, resources.GetString("txtPackageTitle.Error"))
		Me.txtPackageTitle.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.txtPackageTitle, CType(resources.GetObject("txtPackageTitle.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.txtPackageTitle, CType(resources.GetObject("txtPackageTitle.IconPadding"),Integer))
		Me.txtPackageTitle.Name = "txtPackageTitle"
		AddHandler Me.txtPackageTitle.Validated, AddressOf Me.ControlValidated
		AddHandler Me.txtPackageTitle.Validating, AddressOf Me.ControlValidating
		'
		'lblRebootBehavior
		'
		Me.lblRebootBehavior.AccessibleDescription = Nothing
		Me.lblRebootBehavior.AccessibleName = Nothing
		resources.ApplyResources(Me.lblRebootBehavior, "lblRebootBehavior")
		Me.errorProviderUpdate.SetError(Me.lblRebootBehavior, resources.GetString("lblRebootBehavior.Error"))
		Me.errorProviderUpdate.SetIconAlignment(Me.lblRebootBehavior, CType(resources.GetObject("lblRebootBehavior.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.lblRebootBehavior, CType(resources.GetObject("lblRebootBehavior.IconPadding"),Integer))
		Me.lblRebootBehavior.Name = "lblRebootBehavior"
		'
		'lblImpact
		'
		Me.lblImpact.AccessibleDescription = Nothing
		Me.lblImpact.AccessibleName = Nothing
		resources.ApplyResources(Me.lblImpact, "lblImpact")
		Me.errorProviderUpdate.SetError(Me.lblImpact, resources.GetString("lblImpact.Error"))
		Me.errorProviderUpdate.SetIconAlignment(Me.lblImpact, CType(resources.GetObject("lblImpact.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.lblImpact, CType(resources.GetObject("lblImpact.IconPadding"),Integer))
		Me.lblImpact.Name = "lblImpact"
		'
		'lblMoreInfoURL
		'
		Me.lblMoreInfoURL.AccessibleDescription = Nothing
		Me.lblMoreInfoURL.AccessibleName = Nothing
		resources.ApplyResources(Me.lblMoreInfoURL, "lblMoreInfoURL")
		Me.errorProviderUpdate.SetError(Me.lblMoreInfoURL, resources.GetString("lblMoreInfoURL.Error"))
		Me.errorProviderUpdate.SetIconAlignment(Me.lblMoreInfoURL, CType(resources.GetObject("lblMoreInfoURL.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.lblMoreInfoURL, CType(resources.GetObject("lblMoreInfoURL.IconPadding"),Integer))
		Me.lblMoreInfoURL.Name = "lblMoreInfoURL"
		'
		'lblSupportURL
		'
		Me.lblSupportURL.AccessibleDescription = Nothing
		Me.lblSupportURL.AccessibleName = Nothing
		resources.ApplyResources(Me.lblSupportURL, "lblSupportURL")
		Me.errorProviderUpdate.SetError(Me.lblSupportURL, resources.GetString("lblSupportURL.Error"))
		Me.errorProviderUpdate.SetIconAlignment(Me.lblSupportURL, CType(resources.GetObject("lblSupportURL.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.lblSupportURL, CType(resources.GetObject("lblSupportURL.IconPadding"),Integer))
		Me.lblSupportURL.Name = "lblSupportURL"
		'
		'lblSeverity
		'
		Me.lblSeverity.AccessibleDescription = Nothing
		Me.lblSeverity.AccessibleName = Nothing
		resources.ApplyResources(Me.lblSeverity, "lblSeverity")
		Me.errorProviderUpdate.SetError(Me.lblSeverity, resources.GetString("lblSeverity.Error"))
		Me.errorProviderUpdate.SetIconAlignment(Me.lblSeverity, CType(resources.GetObject("lblSeverity.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.lblSeverity, CType(resources.GetObject("lblSeverity.IconPadding"),Integer))
		Me.lblSeverity.Name = "lblSeverity"
		'
		'lblCVEID
		'
		Me.lblCVEID.AccessibleDescription = Nothing
		Me.lblCVEID.AccessibleName = Nothing
		resources.ApplyResources(Me.lblCVEID, "lblCVEID")
		Me.errorProviderUpdate.SetError(Me.lblCVEID, resources.GetString("lblCVEID.Error"))
		Me.errorProviderUpdate.SetIconAlignment(Me.lblCVEID, CType(resources.GetObject("lblCVEID.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.lblCVEID, CType(resources.GetObject("lblCVEID.IconPadding"),Integer))
		Me.lblCVEID.Name = "lblCVEID"
		'
		'lblArticleID
		'
		Me.lblArticleID.AccessibleDescription = Nothing
		Me.lblArticleID.AccessibleName = Nothing
		resources.ApplyResources(Me.lblArticleID, "lblArticleID")
		Me.errorProviderUpdate.SetError(Me.lblArticleID, resources.GetString("lblArticleID.Error"))
		Me.errorProviderUpdate.SetIconAlignment(Me.lblArticleID, CType(resources.GetObject("lblArticleID.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.lblArticleID, CType(resources.GetObject("lblArticleID.IconPadding"),Integer))
		Me.lblArticleID.Name = "lblArticleID"
		'
		'lblProduct
		'
		Me.lblProduct.AccessibleDescription = Nothing
		Me.lblProduct.AccessibleName = Nothing
		resources.ApplyResources(Me.lblProduct, "lblProduct")
		Me.errorProviderUpdate.SetError(Me.lblProduct, resources.GetString("lblProduct.Error"))
		Me.errorProviderUpdate.SetIconAlignment(Me.lblProduct, CType(resources.GetObject("lblProduct.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.lblProduct, CType(resources.GetObject("lblProduct.IconPadding"),Integer))
		Me.lblProduct.Name = "lblProduct"
		'
		'lblVendor
		'
		Me.lblVendor.AccessibleDescription = Nothing
		Me.lblVendor.AccessibleName = Nothing
		resources.ApplyResources(Me.lblVendor, "lblVendor")
		Me.errorProviderUpdate.SetError(Me.lblVendor, resources.GetString("lblVendor.Error"))
		Me.errorProviderUpdate.SetIconAlignment(Me.lblVendor, CType(resources.GetObject("lblVendor.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.lblVendor, CType(resources.GetObject("lblVendor.IconPadding"),Integer))
		Me.lblVendor.Name = "lblVendor"
		'
		'lblBullitinID
		'
		Me.lblBullitinID.AccessibleDescription = Nothing
		Me.lblBullitinID.AccessibleName = Nothing
		resources.ApplyResources(Me.lblBullitinID, "lblBullitinID")
		Me.errorProviderUpdate.SetError(Me.lblBullitinID, resources.GetString("lblBullitinID.Error"))
		Me.errorProviderUpdate.SetIconAlignment(Me.lblBullitinID, CType(resources.GetObject("lblBullitinID.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.lblBullitinID, CType(resources.GetObject("lblBullitinID.IconPadding"),Integer))
		Me.lblBullitinID.Name = "lblBullitinID"
		AddHandler Me.lblBullitinID.Validating, AddressOf Me.ControlValidating
		'
		'lblClassification
		'
		Me.lblClassification.AccessibleDescription = Nothing
		Me.lblClassification.AccessibleName = Nothing
		resources.ApplyResources(Me.lblClassification, "lblClassification")
		Me.errorProviderUpdate.SetError(Me.lblClassification, resources.GetString("lblClassification.Error"))
		Me.errorProviderUpdate.SetIconAlignment(Me.lblClassification, CType(resources.GetObject("lblClassification.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.lblClassification, CType(resources.GetObject("lblClassification.IconPadding"),Integer))
		Me.lblClassification.Name = "lblClassification"
		'
		'lblDescription
		'
		Me.lblDescription.AccessibleDescription = Nothing
		Me.lblDescription.AccessibleName = Nothing
		resources.ApplyResources(Me.lblDescription, "lblDescription")
		Me.errorProviderUpdate.SetError(Me.lblDescription, resources.GetString("lblDescription.Error"))
		Me.errorProviderUpdate.SetIconAlignment(Me.lblDescription, CType(resources.GetObject("lblDescription.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.lblDescription, CType(resources.GetObject("lblDescription.IconPadding"),Integer))
		Me.lblDescription.Name = "lblDescription"
		'
		'lblPackageTitle
		'
		Me.lblPackageTitle.AccessibleDescription = Nothing
		Me.lblPackageTitle.AccessibleName = Nothing
		resources.ApplyResources(Me.lblPackageTitle, "lblPackageTitle")
		Me.errorProviderUpdate.SetError(Me.lblPackageTitle, resources.GetString("lblPackageTitle.Error"))
		Me.errorProviderUpdate.SetIconAlignment(Me.lblPackageTitle, CType(resources.GetObject("lblPackageTitle.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.lblPackageTitle, CType(resources.GetObject("lblPackageTitle.IconPadding"),Integer))
		Me.lblPackageTitle.Name = "lblPackageTitle"
		'
		'tabIsInstalled
		'
		Me.tabIsInstalled.AccessibleDescription = Nothing
		Me.tabIsInstalled.AccessibleName = Nothing
		resources.ApplyResources(Me.tabIsInstalled, "tabIsInstalled")
		Me.tabIsInstalled.BackColor = System.Drawing.SystemColors.Control
		Me.tabIsInstalled.BackgroundImage = Nothing
		Me.tabIsInstalled.Controls.Add(Me.isInstalledRules)
		Me.errorProviderUpdate.SetError(Me.tabIsInstalled, resources.GetString("tabIsInstalled.Error"))
		Me.tabIsInstalled.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.tabIsInstalled, CType(resources.GetObject("tabIsInstalled.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.tabIsInstalled, CType(resources.GetObject("tabIsInstalled.IconPadding"),Integer))
		Me.tabIsInstalled.Name = "tabIsInstalled"
		'
		'isInstalledRules
		'
		Me.isInstalledRules.AccessibleDescription = Nothing
		Me.isInstalledRules.AccessibleName = Nothing
		resources.ApplyResources(Me.isInstalledRules, "isInstalledRules")
		Me.isInstalledRules.ApplicabilityRule = ""
		Me.isInstalledRules.BackgroundImage = Nothing
		Me.isInstalledRules.CausesValidation = false
		Me.errorProviderUpdate.SetError(Me.isInstalledRules, resources.GetString("isInstalledRules.Error"))
		Me.isInstalledRules.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.isInstalledRules, CType(resources.GetObject("isInstalledRules.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.isInstalledRules, CType(resources.GetObject("isInstalledRules.IconPadding"),Integer))
		Me.isInstalledRules.Instructions = resources.GetString("isInstalledRules.Instructions")
		Me.isInstalledRules.Name = "isInstalledRules"
		Me.isInstalledRules.Rule = ""
		Me.isInstalledRules.RuleEditorTitle = "Installé règle"
		Me.isInstalledRules.Title = "Forfait Niveau - Règles installée"
		Me.isInstalledRules.TitleItemLevel = "Niveau Point Installation"
		'
		'tabIsInstallable
		'
		Me.tabIsInstallable.AccessibleDescription = Nothing
		Me.tabIsInstallable.AccessibleName = Nothing
		resources.ApplyResources(Me.tabIsInstallable, "tabIsInstallable")
		Me.tabIsInstallable.BackColor = System.Drawing.SystemColors.Control
		Me.tabIsInstallable.BackgroundImage = Nothing
		Me.tabIsInstallable.Controls.Add(Me.isInstallableRules)
		Me.errorProviderUpdate.SetError(Me.tabIsInstallable, resources.GetString("tabIsInstallable.Error"))
		Me.tabIsInstallable.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.tabIsInstallable, CType(resources.GetObject("tabIsInstallable.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.tabIsInstallable, CType(resources.GetObject("tabIsInstallable.IconPadding"),Integer))
		Me.tabIsInstallable.Name = "tabIsInstallable"
		'
		'isInstallableRules
		'
		Me.isInstallableRules.AccessibleDescription = Nothing
		Me.isInstallableRules.AccessibleName = Nothing
		resources.ApplyResources(Me.isInstallableRules, "isInstallableRules")
		Me.isInstallableRules.ApplicabilityRule = ""
		Me.isInstallableRules.BackgroundImage = Nothing
		Me.isInstallableRules.CausesValidation = false
		Me.errorProviderUpdate.SetError(Me.isInstallableRules, resources.GetString("isInstallableRules.Error"))
		Me.isInstallableRules.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.isInstallableRules, CType(resources.GetObject("isInstallableRules.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.isInstallableRules, CType(resources.GetObject("isInstallableRules.IconPadding"),Integer))
		Me.isInstallableRules.Instructions = resources.GetString("isInstallableRules.Instructions")
		Me.isInstallableRules.Name = "isInstallableRules"
		Me.isInstallableRules.Rule = ""
		Me.isInstallableRules.RuleEditorTitle = "Règle Installable"
		Me.isInstallableRules.Title = "Forfait Niveau - Règles Installable"
		Me.isInstallableRules.TitleItemLevel = "Niveau Point Installation"
		'
		'tabIsSuperseded
		'
		Me.tabIsSuperseded.AccessibleDescription = Nothing
		Me.tabIsSuperseded.AccessibleName = Nothing
		resources.ApplyResources(Me.tabIsSuperseded, "tabIsSuperseded")
		Me.tabIsSuperseded.BackColor = System.Drawing.SystemColors.Control
		Me.tabIsSuperseded.BackgroundImage = Nothing
		Me.tabIsSuperseded.Controls.Add(Me.btnIsSupersededEdit)
		Me.tabIsSuperseded.Controls.Add(Me.lblIsSuperseded)
		Me.tabIsSuperseded.Controls.Add(Me.lblIsSuperceded_InstallableItem)
		Me.tabIsSuperseded.Controls.Add(Me.txtIsSuperceded_InstallableItem)
		Me.errorProviderUpdate.SetError(Me.tabIsSuperseded, resources.GetString("tabIsSuperseded.Error"))
		Me.tabIsSuperseded.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.tabIsSuperseded, CType(resources.GetObject("tabIsSuperseded.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.tabIsSuperseded, CType(resources.GetObject("tabIsSuperseded.IconPadding"),Integer))
		Me.tabIsSuperseded.Name = "tabIsSuperseded"
		'
		'btnIsSupersededEdit
		'
		Me.btnIsSupersededEdit.AccessibleDescription = Nothing
		Me.btnIsSupersededEdit.AccessibleName = Nothing
		resources.ApplyResources(Me.btnIsSupersededEdit, "btnIsSupersededEdit")
		Me.btnIsSupersededEdit.BackgroundImage = Nothing
		Me.errorProviderUpdate.SetError(Me.btnIsSupersededEdit, resources.GetString("btnIsSupersededEdit.Error"))
		Me.errorProviderUpdate.SetIconAlignment(Me.btnIsSupersededEdit, CType(resources.GetObject("btnIsSupersededEdit.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.btnIsSupersededEdit, CType(resources.GetObject("btnIsSupersededEdit.IconPadding"),Integer))
		Me.btnIsSupersededEdit.Name = "btnIsSupersededEdit"
		Me.btnIsSupersededEdit.UseVisualStyleBackColor = true
		AddHandler Me.btnIsSupersededEdit.Click, AddressOf Me.BtnIsSupersededEditClick
		'
		'lblIsSuperseded
		'
		Me.lblIsSuperseded.AccessibleDescription = Nothing
		Me.lblIsSuperseded.AccessibleName = Nothing
		resources.ApplyResources(Me.lblIsSuperseded, "lblIsSuperseded")
		Me.errorProviderUpdate.SetError(Me.lblIsSuperseded, resources.GetString("lblIsSuperseded.Error"))
		Me.errorProviderUpdate.SetIconAlignment(Me.lblIsSuperseded, CType(resources.GetObject("lblIsSuperseded.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.lblIsSuperseded, CType(resources.GetObject("lblIsSuperseded.IconPadding"),Integer))
		Me.lblIsSuperseded.Name = "lblIsSuperseded"
		'
		'lblIsSuperceded_InstallableItem
		'
		Me.lblIsSuperceded_InstallableItem.AccessibleDescription = Nothing
		Me.lblIsSuperceded_InstallableItem.AccessibleName = Nothing
		resources.ApplyResources(Me.lblIsSuperceded_InstallableItem, "lblIsSuperceded_InstallableItem")
		Me.errorProviderUpdate.SetError(Me.lblIsSuperceded_InstallableItem, resources.GetString("lblIsSuperceded_InstallableItem.Error"))
		Me.errorProviderUpdate.SetIconAlignment(Me.lblIsSuperceded_InstallableItem, CType(resources.GetObject("lblIsSuperceded_InstallableItem.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.lblIsSuperceded_InstallableItem, CType(resources.GetObject("lblIsSuperceded_InstallableItem.IconPadding"),Integer))
		Me.lblIsSuperceded_InstallableItem.Name = "lblIsSuperceded_InstallableItem"
		'
		'txtIsSuperceded_InstallableItem
		'
		Me.txtIsSuperceded_InstallableItem.AccessibleDescription = Nothing
		Me.txtIsSuperceded_InstallableItem.AccessibleName = Nothing
		resources.ApplyResources(Me.txtIsSuperceded_InstallableItem, "txtIsSuperceded_InstallableItem")
		Me.txtIsSuperceded_InstallableItem.BackgroundImage = Nothing
		Me.errorProviderUpdate.SetError(Me.txtIsSuperceded_InstallableItem, resources.GetString("txtIsSuperceded_InstallableItem.Error"))
		Me.txtIsSuperceded_InstallableItem.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.txtIsSuperceded_InstallableItem, CType(resources.GetObject("txtIsSuperceded_InstallableItem.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.txtIsSuperceded_InstallableItem, CType(resources.GetObject("txtIsSuperceded_InstallableItem.IconPadding"),Integer))
		Me.txtIsSuperceded_InstallableItem.Name = "txtIsSuperceded_InstallableItem"
		Me.txtIsSuperceded_InstallableItem.ReadOnly = true
		'
		'tabMetaData
		'
		Me.tabMetaData.AccessibleDescription = Nothing
		Me.tabMetaData.AccessibleName = Nothing
		resources.ApplyResources(Me.tabMetaData, "tabMetaData")
		Me.tabMetaData.BackColor = System.Drawing.SystemColors.Control
		Me.tabMetaData.BackgroundImage = Nothing
		Me.tabMetaData.Controls.Add(Me.btnMetaDataEdit)
		Me.tabMetaData.Controls.Add(Me.lblMetaData_InstallableItem)
		Me.tabMetaData.Controls.Add(Me.lblMetaData)
		Me.tabMetaData.Controls.Add(Me.txtInstallableItemMetaData)
		Me.errorProviderUpdate.SetError(Me.tabMetaData, resources.GetString("tabMetaData.Error"))
		Me.tabMetaData.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.tabMetaData, CType(resources.GetObject("tabMetaData.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.tabMetaData, CType(resources.GetObject("tabMetaData.IconPadding"),Integer))
		Me.tabMetaData.Name = "tabMetaData"
		'
		'btnMetaDataEdit
		'
		Me.btnMetaDataEdit.AccessibleDescription = Nothing
		Me.btnMetaDataEdit.AccessibleName = Nothing
		resources.ApplyResources(Me.btnMetaDataEdit, "btnMetaDataEdit")
		Me.btnMetaDataEdit.BackgroundImage = Nothing
		Me.errorProviderUpdate.SetError(Me.btnMetaDataEdit, resources.GetString("btnMetaDataEdit.Error"))
		Me.errorProviderUpdate.SetIconAlignment(Me.btnMetaDataEdit, CType(resources.GetObject("btnMetaDataEdit.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.btnMetaDataEdit, CType(resources.GetObject("btnMetaDataEdit.IconPadding"),Integer))
		Me.btnMetaDataEdit.Name = "btnMetaDataEdit"
		Me.btnMetaDataEdit.UseVisualStyleBackColor = true
		AddHandler Me.btnMetaDataEdit.Click, AddressOf Me.BtnMetaDataEditClick
		'
		'lblMetaData_InstallableItem
		'
		Me.lblMetaData_InstallableItem.AccessibleDescription = Nothing
		Me.lblMetaData_InstallableItem.AccessibleName = Nothing
		resources.ApplyResources(Me.lblMetaData_InstallableItem, "lblMetaData_InstallableItem")
		Me.errorProviderUpdate.SetError(Me.lblMetaData_InstallableItem, resources.GetString("lblMetaData_InstallableItem.Error"))
		Me.errorProviderUpdate.SetIconAlignment(Me.lblMetaData_InstallableItem, CType(resources.GetObject("lblMetaData_InstallableItem.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.lblMetaData_InstallableItem, CType(resources.GetObject("lblMetaData_InstallableItem.IconPadding"),Integer))
		Me.lblMetaData_InstallableItem.Name = "lblMetaData_InstallableItem"
		'
		'lblMetaData
		'
		Me.lblMetaData.AccessibleDescription = Nothing
		Me.lblMetaData.AccessibleName = Nothing
		resources.ApplyResources(Me.lblMetaData, "lblMetaData")
		Me.errorProviderUpdate.SetError(Me.lblMetaData, resources.GetString("lblMetaData.Error"))
		Me.errorProviderUpdate.SetIconAlignment(Me.lblMetaData, CType(resources.GetObject("lblMetaData.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.lblMetaData, CType(resources.GetObject("lblMetaData.IconPadding"),Integer))
		Me.lblMetaData.Name = "lblMetaData"
		'
		'txtInstallableItemMetaData
		'
		Me.txtInstallableItemMetaData.AccessibleDescription = Nothing
		Me.txtInstallableItemMetaData.AccessibleName = Nothing
		resources.ApplyResources(Me.txtInstallableItemMetaData, "txtInstallableItemMetaData")
		Me.txtInstallableItemMetaData.BackgroundImage = Nothing
		Me.errorProviderUpdate.SetError(Me.txtInstallableItemMetaData, resources.GetString("txtInstallableItemMetaData.Error"))
		Me.txtInstallableItemMetaData.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.txtInstallableItemMetaData, CType(resources.GetObject("txtInstallableItemMetaData.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.txtInstallableItemMetaData, CType(resources.GetObject("txtInstallableItemMetaData.IconPadding"),Integer))
		Me.txtInstallableItemMetaData.Name = "txtInstallableItemMetaData"
		Me.txtInstallableItemMetaData.ReadOnly = true
		'
		'tabSummary
		'
		Me.tabSummary.AccessibleDescription = Nothing
		Me.tabSummary.AccessibleName = Nothing
		resources.ApplyResources(Me.tabSummary, "tabSummary")
		Me.tabSummary.BackColor = System.Drawing.SystemColors.Control
		Me.tabSummary.BackgroundImage = Nothing
		Me.tabSummary.Controls.Add(Me.label4)
		Me.tabSummary.Controls.Add(Me.txtSummary)
		Me.errorProviderUpdate.SetError(Me.tabSummary, resources.GetString("tabSummary.Error"))
		Me.tabSummary.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.tabSummary, CType(resources.GetObject("tabSummary.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.tabSummary, CType(resources.GetObject("tabSummary.IconPadding"),Integer))
		Me.tabSummary.Name = "tabSummary"
		'
		'label4
		'
		Me.label4.AccessibleDescription = Nothing
		Me.label4.AccessibleName = Nothing
		resources.ApplyResources(Me.label4, "label4")
		Me.errorProviderUpdate.SetError(Me.label4, resources.GetString("label4.Error"))
		Me.errorProviderUpdate.SetIconAlignment(Me.label4, CType(resources.GetObject("label4.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.label4, CType(resources.GetObject("label4.IconPadding"),Integer))
		Me.label4.Name = "label4"
		'
		'txtSummary
		'
		Me.txtSummary.AccessibleDescription = Nothing
		Me.txtSummary.AccessibleName = Nothing
		resources.ApplyResources(Me.txtSummary, "txtSummary")
		Me.txtSummary.BackgroundImage = Nothing
		Me.errorProviderUpdate.SetError(Me.txtSummary, resources.GetString("txtSummary.Error"))
		Me.txtSummary.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.txtSummary, CType(resources.GetObject("txtSummary.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.txtSummary, CType(resources.GetObject("txtSummary.IconPadding"),Integer))
		Me.txtSummary.Name = "txtSummary"
		Me.txtSummary.ReadOnly = true
		Me.txtSummary.TabStop = false
		'
		'btnPrevious
		'
		Me.btnPrevious.AccessibleDescription = Nothing
		Me.btnPrevious.AccessibleName = Nothing
		resources.ApplyResources(Me.btnPrevious, "btnPrevious")
		Me.btnPrevious.BackgroundImage = Nothing
		Me.btnPrevious.CausesValidation = false
		Me.errorProviderUpdate.SetError(Me.btnPrevious, resources.GetString("btnPrevious.Error"))
		Me.btnPrevious.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.btnPrevious, CType(resources.GetObject("btnPrevious.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.btnPrevious, CType(resources.GetObject("btnPrevious.IconPadding"),Integer))
		Me.btnPrevious.Name = "btnPrevious"
		Me.btnPrevious.UseVisualStyleBackColor = true
		AddHandler Me.btnPrevious.Click, AddressOf Me.BtnPreviousClick
		'
		'btnNext
		'
		Me.btnNext.AccessibleDescription = Nothing
		Me.btnNext.AccessibleName = Nothing
		resources.ApplyResources(Me.btnNext, "btnNext")
		Me.btnNext.BackgroundImage = Nothing
		Me.btnNext.CausesValidation = false
		Me.errorProviderUpdate.SetError(Me.btnNext, resources.GetString("btnNext.Error"))
		Me.btnNext.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.btnNext, CType(resources.GetObject("btnNext.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.btnNext, CType(resources.GetObject("btnNext.IconPadding"),Integer))
		Me.btnNext.Name = "btnNext"
		Me.btnNext.UseVisualStyleBackColor = true
		AddHandler Me.btnNext.Click, AddressOf Me.BtnNextClick
		'
		'btnCancel
		'
		Me.btnCancel.AccessibleDescription = Nothing
		Me.btnCancel.AccessibleName = Nothing
		resources.ApplyResources(Me.btnCancel, "btnCancel")
		Me.btnCancel.BackgroundImage = Nothing
		Me.btnCancel.CausesValidation = false
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.errorProviderUpdate.SetError(Me.btnCancel, resources.GetString("btnCancel.Error"))
		Me.btnCancel.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.btnCancel, CType(resources.GetObject("btnCancel.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.btnCancel, CType(resources.GetObject("btnCancel.IconPadding"),Integer))
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
		Me.chkExportSdp.AccessibleDescription = Nothing
		Me.chkExportSdp.AccessibleName = Nothing
		resources.ApplyResources(Me.chkExportSdp, "chkExportSdp")
		Me.chkExportSdp.BackgroundImage = Nothing
		Me.chkExportSdp.CausesValidation = false
		Me.errorProviderUpdate.SetError(Me.chkExportSdp, resources.GetString("chkExportSdp.Error"))
		Me.chkExportSdp.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.chkExportSdp, CType(resources.GetObject("chkExportSdp.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.chkExportSdp, CType(resources.GetObject("chkExportSdp.IconPadding"),Integer))
		Me.chkExportSdp.Name = "chkExportSdp"
		Me.chkExportSdp.UseVisualStyleBackColor = true
		'
		'dlgExportSdp
		'
		resources.ApplyResources(Me.dlgExportSdp, "dlgExportSdp")
		'
		'dlgUpdateDir
		'
		resources.ApplyResources(Me.dlgUpdateDir, "dlgUpdateDir")
		'
		'chkMetadataOnly
		'
		Me.chkMetadataOnly.AccessibleDescription = Nothing
		Me.chkMetadataOnly.AccessibleName = Nothing
		resources.ApplyResources(Me.chkMetadataOnly, "chkMetadataOnly")
		Me.chkMetadataOnly.BackgroundImage = Nothing
		Me.chkMetadataOnly.CausesValidation = false
		Me.errorProviderUpdate.SetError(Me.chkMetadataOnly, resources.GetString("chkMetadataOnly.Error"))
		Me.chkMetadataOnly.Font = Nothing
		Me.errorProviderUpdate.SetIconAlignment(Me.chkMetadataOnly, CType(resources.GetObject("chkMetadataOnly.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderUpdate.SetIconPadding(Me.chkMetadataOnly, CType(resources.GetObject("chkMetadataOnly.IconPadding"),Integer))
		Me.chkMetadataOnly.Name = "chkMetadataOnly"
		Me.chkMetadataOnly.UseVisualStyleBackColor = true
		AddHandler Me.chkMetadataOnly.CheckedChanged, AddressOf Me.CboMetadataOnlyCheckedChanged
		'
		'errorProviderUpdate
		'
		Me.errorProviderUpdate.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
		Me.errorProviderUpdate.ContainerControl = Me
		resources.ApplyResources(Me.errorProviderUpdate, "errorProviderUpdate")
		'
		'UpdateForm
		'
		Me.AccessibleDescription = Nothing
		Me.AccessibleName = Nothing
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
		Me.BackgroundImage = Nothing
		Me.CancelButton = Me.btnCancel
		Me.Controls.Add(Me.chkMetadataOnly)
		Me.Controls.Add(Me.chkExportSdp)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnNext)
		Me.Controls.Add(Me.btnPrevious)
		Me.Controls.Add(Me.tabsImportUpdate)
		Me.Font = Nothing
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
