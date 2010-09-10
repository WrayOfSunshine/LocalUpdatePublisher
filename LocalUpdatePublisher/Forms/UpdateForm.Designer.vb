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
		Me.btnAddFile = New System.Windows.Forms.Button
		Me.dgvAdditionalFiles = New System.Windows.Forms.DataGridView
		Me.FileName = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.RemoveFile = New System.Windows.Forms.DataGridViewButtonColumn
		Me.FileObject = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.lblAdditionalFiles = New System.Windows.Forms.Label
		Me.btnUpdateFile = New System.Windows.Forms.Button
		Me.txtUpdateFile = New System.Windows.Forms.TextBox
		Me.lblUpdateFile = New System.Windows.Forms.Label
		Me.tabPackageInfo = New System.Windows.Forms.TabPage
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
		Me.cboMetadataOnly = New System.Windows.Forms.CheckBox
		Me.errorProviderUpdate = New System.Windows.Forms.ErrorProvider(Me.components)
		Me.cboPackageType = New System.Windows.Forms.ComboBox
		Me.lblPackageType = New System.Windows.Forms.Label
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
		Me.tabsImportUpdate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
						Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.tabsImportUpdate.Controls.Add(Me.tabIntro)
		Me.tabsImportUpdate.Controls.Add(Me.tabPackageInfo)
		Me.tabsImportUpdate.Controls.Add(Me.tabIsInstalled)
		Me.tabsImportUpdate.Controls.Add(Me.tabIsInstallable)
		Me.tabsImportUpdate.Controls.Add(Me.tabIsSuperseded)
		Me.tabsImportUpdate.Controls.Add(Me.tabMetaData)
		Me.tabsImportUpdate.Controls.Add(Me.tabSummary)
		Me.tabsImportUpdate.Location = New System.Drawing.Point(-1, 3)
		Me.tabsImportUpdate.Name = "tabsImportUpdate"
		Me.tabsImportUpdate.SelectedIndex = 0
		Me.tabsImportUpdate.Size = New System.Drawing.Size(613, 515)
		Me.tabsImportUpdate.TabIndex = 0
		'
		'tabIntro
		'
		Me.tabIntro.BackColor = System.Drawing.SystemColors.Control
		Me.tabIntro.Controls.Add(Me.btnAddDir)
		Me.tabIntro.Controls.Add(Me.lblInfo)
		Me.tabIntro.Controls.Add(Me.txtMSIPath)
		Me.tabIntro.Controls.Add(Me.lblMSIPath)
		Me.tabIntro.Controls.Add(Me.btnAddFile)
		Me.tabIntro.Controls.Add(Me.dgvAdditionalFiles)
		Me.tabIntro.Controls.Add(Me.lblAdditionalFiles)
		Me.tabIntro.Controls.Add(Me.btnUpdateFile)
		Me.tabIntro.Controls.Add(Me.txtUpdateFile)
		Me.tabIntro.Controls.Add(Me.lblUpdateFile)
		Me.tabIntro.ForeColor = System.Drawing.SystemColors.ControlText
		Me.tabIntro.Location = New System.Drawing.Point(4, 23)
		Me.tabIntro.Name = "tabIntro"
		Me.tabIntro.Padding = New System.Windows.Forms.Padding(3)
		Me.tabIntro.Size = New System.Drawing.Size(605, 488)
		Me.tabIntro.TabIndex = 0
		Me.tabIntro.Text = "Intro"
		'
		'btnAddDir
		'
		Me.btnAddDir.Location = New System.Drawing.Point(535, 112)
		Me.btnAddDir.Name = "btnAddDir"
		Me.btnAddDir.Size = New System.Drawing.Size(53, 19)
		Me.btnAddDir.TabIndex = 11
		Me.btnAddDir.Text = "Add Dir"
		Me.btnAddDir.UseVisualStyleBackColor = true
		AddHandler Me.btnAddDir.Click, AddressOf Me.BtnAddDirClick
		'
		'lblInfo
		'
		Me.lblInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblInfo.Location = New System.Drawing.Point(0, 3)
		Me.lblInfo.Name = "lblInfo"
		Me.lblInfo.Size = New System.Drawing.Size(582, 53)
		Me.lblInfo.TabIndex = 10
		Me.lblInfo.Text = resources.GetString("lblInfo.Text")
		'
		'txtMSIPath
		'
		Me.txtMSIPath.Enabled = false
		Me.txtMSIPath.Location = New System.Drawing.Point(94, 88)
		Me.txtMSIPath.Name = "txtMSIPath"
		Me.txtMSIPath.Size = New System.Drawing.Size(435, 20)
		Me.txtMSIPath.TabIndex = 9
		'
		'lblMSIPath
		'
		Me.lblMSIPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblMSIPath.Location = New System.Drawing.Point(6, 90)
		Me.lblMSIPath.Name = "lblMSIPath"
		Me.lblMSIPath.Size = New System.Drawing.Size(84, 15)
		Me.lblMSIPath.TabIndex = 8
		Me.lblMSIPath.Text = "MSI Path"
		Me.lblMSIPath.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'btnAddFile
		'
		Me.btnAddFile.Location = New System.Drawing.Point(535, 133)
		Me.btnAddFile.Name = "btnAddFile"
		Me.btnAddFile.Size = New System.Drawing.Size(53, 19)
		Me.btnAddFile.TabIndex = 7
		Me.btnAddFile.Text = "Add File"
		Me.btnAddFile.UseVisualStyleBackColor = true
		AddHandler Me.btnAddFile.Click, AddressOf Me.BtnAddFileClick
		'
		'dgvAdditionalFiles
		'
		Me.dgvAdditionalFiles.AllowUserToAddRows = false
		Me.dgvAdditionalFiles.AllowUserToDeleteRows = false
		Me.dgvAdditionalFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvAdditionalFiles.ColumnHeadersVisible = false
		Me.dgvAdditionalFiles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FileName, Me.RemoveFile, Me.FileObject})
		Me.dgvAdditionalFiles.Location = New System.Drawing.Point(94, 116)
		Me.dgvAdditionalFiles.Name = "dgvAdditionalFiles"
		Me.dgvAdditionalFiles.ReadOnly = true
		Me.dgvAdditionalFiles.RowHeadersVisible = false
		Me.dgvAdditionalFiles.Size = New System.Drawing.Size(435, 346)
		Me.dgvAdditionalFiles.TabIndex = 6
		AddHandler Me.dgvAdditionalFiles.CellContentClick, AddressOf Me.DgvAdditionalFilesCellContentClick
		'
		'FileName
		'
		Me.FileName.Frozen = true
		Me.FileName.HeaderText = "File Name"
		Me.FileName.Name = "FileName"
		Me.FileName.ReadOnly = true
		Me.FileName.Width = 270
		'
		'RemoveFile
		'
		Me.RemoveFile.Frozen = true
		Me.RemoveFile.HeaderText = ""
		Me.RemoveFile.Name = "RemoveFile"
		Me.RemoveFile.ReadOnly = true
		Me.RemoveFile.Text = "Remove"
		Me.RemoveFile.UseColumnTextForButtonValue = true
		Me.RemoveFile.Width = 50
		'
		'FileObject
		'
		Me.FileObject.Frozen = true
		Me.FileObject.HeaderText = "File Object"
		Me.FileObject.Name = "FileObject"
		Me.FileObject.ReadOnly = true
		Me.FileObject.Visible = false
		'
		'lblAdditionalFiles
		'
		Me.lblAdditionalFiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblAdditionalFiles.Location = New System.Drawing.Point(5, 116)
		Me.lblAdditionalFiles.Name = "lblAdditionalFiles"
		Me.lblAdditionalFiles.Size = New System.Drawing.Size(84, 15)
		Me.lblAdditionalFiles.TabIndex = 5
		Me.lblAdditionalFiles.Text = "Additional Files"
		Me.lblAdditionalFiles.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblAdditionalFiles.Visible = false
		'
		'btnUpdateFile
		'
		Me.btnUpdateFile.Location = New System.Drawing.Point(535, 63)
		Me.btnUpdateFile.Name = "btnUpdateFile"
		Me.btnUpdateFile.Size = New System.Drawing.Size(53, 19)
		Me.btnUpdateFile.TabIndex = 4
		Me.btnUpdateFile.Text = "Browse"
		Me.btnUpdateFile.UseVisualStyleBackColor = true
		AddHandler Me.btnUpdateFile.Click, AddressOf Me.BtnUpdateFileClick
		'
		'txtUpdateFile
		'
		Me.txtUpdateFile.Location = New System.Drawing.Point(94, 62)
		Me.txtUpdateFile.Name = "txtUpdateFile"
		Me.txtUpdateFile.ReadOnly = true
		Me.txtUpdateFile.Size = New System.Drawing.Size(412, 20)
		Me.txtUpdateFile.TabIndex = 3
		AddHandler Me.txtUpdateFile.Validated, AddressOf Me.ControlValidated
		AddHandler Me.txtUpdateFile.Validating, AddressOf Me.ControlValidating
		'
		'lblUpdateFile
		'
		Me.lblUpdateFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblUpdateFile.Location = New System.Drawing.Point(5, 64)
		Me.lblUpdateFile.Name = "lblUpdateFile"
		Me.lblUpdateFile.Size = New System.Drawing.Size(84, 15)
		Me.lblUpdateFile.TabIndex = 2
		Me.lblUpdateFile.Text = "Update File"
		Me.lblUpdateFile.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'tabPackageInfo
		'
		Me.tabPackageInfo.BackColor = System.Drawing.SystemColors.Control
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
		Me.tabPackageInfo.Location = New System.Drawing.Point(4, 23)
		Me.tabPackageInfo.Name = "tabPackageInfo"
		Me.tabPackageInfo.Padding = New System.Windows.Forms.Padding(3)
		Me.tabPackageInfo.Size = New System.Drawing.Size(605, 488)
		Me.tabPackageInfo.TabIndex = 1
		Me.tabPackageInfo.Text = "Package Info"
		'
		'lblPrerequisites
		'
		Me.lblPrerequisites.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.lblPrerequisites.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblPrerequisites.ForeColor = System.Drawing.SystemColors.ActiveCaption
		Me.lblPrerequisites.Location = New System.Drawing.Point(96, 475)
		Me.lblPrerequisites.Name = "lblPrerequisites"
		Me.lblPrerequisites.Size = New System.Drawing.Size(113, 17)
		Me.lblPrerequisites.TabIndex = 65
		Me.lblPrerequisites.Text = "Prerequisites"
		AddHandler Me.lblPrerequisites.Click, AddressOf Me.LblPrerequisitesClick
		'
		'lblSupersedes
		'
		Me.lblSupersedes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.lblSupersedes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblSupersedes.ForeColor = System.Drawing.SystemColors.ActiveCaption
		Me.lblSupersedes.Location = New System.Drawing.Point(260, 475)
		Me.lblSupersedes.Name = "lblSupersedes"
		Me.lblSupersedes.Size = New System.Drawing.Size(113, 17)
		Me.lblSupersedes.TabIndex = 64
		Me.lblSupersedes.Text = "Supersedes"
		AddHandler Me.lblSupersedes.Click, AddressOf Me.LblSupersedesClick
		'
		'lblReturnCodes
		'
		Me.lblReturnCodes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblReturnCodes.ForeColor = System.Drawing.SystemColors.ActiveCaption
		Me.lblReturnCodes.Location = New System.Drawing.Point(424, 475)
		Me.lblReturnCodes.Name = "lblReturnCodes"
		Me.lblReturnCodes.Size = New System.Drawing.Size(113, 17)
		Me.lblReturnCodes.TabIndex = 40
		Me.lblReturnCodes.Text = "Return Codes"
		Me.lblReturnCodes.Visible = false
		AddHandler Me.lblReturnCodes.Click, AddressOf Me.LblReturnCodesClick
		'
		'txtUninstall
		'
		Me.txtUninstall.Location = New System.Drawing.Point(114, 397)
		Me.txtUninstall.Name = "txtUninstall"
		Me.txtUninstall.ReadOnly = true
		Me.txtUninstall.Size = New System.Drawing.Size(233, 20)
		Me.txtUninstall.TabIndex = 39
		'
		'lblUninstall
		'
		Me.lblUninstall.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblUninstall.Location = New System.Drawing.Point(21, 400)
		Me.lblUninstall.Name = "lblUninstall"
		Me.lblUninstall.Size = New System.Drawing.Size(86, 17)
		Me.lblUninstall.TabIndex = 38
		Me.lblUninstall.Text = "Uninstall"
		Me.lblUninstall.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblPackageInfo
		'
		Me.lblPackageInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblPackageInfo.Location = New System.Drawing.Point(0, 3)
		Me.lblPackageInfo.Name = "lblPackageInfo"
		Me.lblPackageInfo.Size = New System.Drawing.Size(598, 34)
		Me.lblPackageInfo.TabIndex = 37
		Me.lblPackageInfo.Text = "Enter the relavant details about the software package here.  Refer to the documen"& _ 
		"tation for questions regarding individual fields."
		'
		'txtCommandLine
		'
		Me.txtCommandLine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.txtCommandLine.Location = New System.Drawing.Point(114, 449)
		Me.txtCommandLine.Name = "txtCommandLine"
		Me.txtCommandLine.Size = New System.Drawing.Size(457, 20)
		Me.txtCommandLine.TabIndex = 27
		'
		'lblCommandLine
		'
		Me.lblCommandLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblCommandLine.Location = New System.Drawing.Point(21, 450)
		Me.lblCommandLine.Name = "lblCommandLine"
		Me.lblCommandLine.Size = New System.Drawing.Size(86, 17)
		Me.lblCommandLine.TabIndex = 26
		Me.lblCommandLine.Text = "Command Line"
		Me.lblCommandLine.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'cboRebootBehavior
		'
		Me.cboRebootBehavior.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboRebootBehavior.FormattingEnabled = true
		Me.cboRebootBehavior.Items.AddRange(New Object() {"Never Reboots", "Always Requires Reboot", "Can Request Reboot"})
		Me.cboRebootBehavior.Location = New System.Drawing.Point(114, 423)
		Me.cboRebootBehavior.Name = "cboRebootBehavior"
		Me.cboRebootBehavior.Size = New System.Drawing.Size(233, 21)
		Me.cboRebootBehavior.TabIndex = 25
		AddHandler Me.cboRebootBehavior.Validating, AddressOf Me.ControlValidating
		AddHandler Me.cboRebootBehavior.SelectedValueChanged, AddressOf Me.ValidateCombo
		AddHandler Me.cboRebootBehavior.Validated, AddressOf Me.ControlValidated
		'
		'cboImpact
		'
		Me.cboImpact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboImpact.FormattingEnabled = true
		Me.cboImpact.Items.AddRange(New Object() {"Normal", "Minor", "Requires Exclusive Handling"})
		Me.cboImpact.Location = New System.Drawing.Point(114, 370)
		Me.cboImpact.Name = "cboImpact"
		Me.cboImpact.Size = New System.Drawing.Size(233, 21)
		Me.cboImpact.TabIndex = 24
		AddHandler Me.cboImpact.Validating, AddressOf Me.ControlValidating
		AddHandler Me.cboImpact.SelectedValueChanged, AddressOf Me.ValidateCombo
		AddHandler Me.cboImpact.Validated, AddressOf Me.ControlValidated
		'
		'txtMoreInfoURL
		'
		Me.txtMoreInfoURL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.txtMoreInfoURL.Location = New System.Drawing.Point(114, 344)
		Me.txtMoreInfoURL.Name = "txtMoreInfoURL"
		Me.txtMoreInfoURL.Size = New System.Drawing.Size(457, 20)
		Me.txtMoreInfoURL.TabIndex = 23
		'
		'txtSupportURL
		'
		Me.txtSupportURL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.txtSupportURL.Location = New System.Drawing.Point(114, 318)
		Me.txtSupportURL.Name = "txtSupportURL"
		Me.txtSupportURL.Size = New System.Drawing.Size(457, 20)
		Me.txtSupportURL.TabIndex = 22
		'
		'cboSeverity
		'
		Me.cboSeverity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboSeverity.Enabled = false
		Me.cboSeverity.FormattingEnabled = true
		Me.cboSeverity.Items.AddRange(New Object() {"Unspecified", "Critical", "Important", "Moderate", "Low"})
		Me.cboSeverity.Location = New System.Drawing.Point(114, 185)
		Me.cboSeverity.Name = "cboSeverity"
		Me.cboSeverity.Size = New System.Drawing.Size(233, 21)
		Me.cboSeverity.TabIndex = 21
		AddHandler Me.cboSeverity.Validating, AddressOf Me.ControlValidating
		AddHandler Me.cboSeverity.SelectedIndexChanged, AddressOf Me.ValidateCombo
		AddHandler Me.cboSeverity.Validated, AddressOf Me.ControlValidated
		'
		'txtCVEID
		'
		Me.txtCVEID.Location = New System.Drawing.Point(114, 292)
		Me.txtCVEID.Name = "txtCVEID"
		Me.txtCVEID.Size = New System.Drawing.Size(233, 20)
		Me.txtCVEID.TabIndex = 20
		'
		'txtArticleID
		'
		Me.txtArticleID.Location = New System.Drawing.Point(114, 266)
		Me.txtArticleID.Name = "txtArticleID"
		Me.txtArticleID.Size = New System.Drawing.Size(233, 20)
		Me.txtArticleID.TabIndex = 19
		'
		'cboProduct
		'
		Me.cboProduct.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.cboProduct.FormattingEnabled = true
		Me.cboProduct.Location = New System.Drawing.Point(114, 239)
		Me.cboProduct.Name = "cboProduct"
		Me.cboProduct.Size = New System.Drawing.Size(457, 21)
		Me.cboProduct.TabIndex = 18
		AddHandler Me.cboProduct.Validating, AddressOf Me.ControlValidating
		AddHandler Me.cboProduct.SelectedValueChanged, AddressOf Me.ValidateCombo
		AddHandler Me.cboProduct.Validated, AddressOf Me.ControlValidated
		'
		'cboVendor
		'
		Me.cboVendor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.cboVendor.FormattingEnabled = true
		Me.cboVendor.Location = New System.Drawing.Point(114, 212)
		Me.cboVendor.Name = "cboVendor"
		Me.cboVendor.Size = New System.Drawing.Size(457, 21)
		Me.cboVendor.TabIndex = 17
		AddHandler Me.cboVendor.Validating, AddressOf Me.ControlValidating
		AddHandler Me.cboVendor.SelectionChangeCommitted, AddressOf Me.ValidateCombo
		AddHandler Me.cboVendor.Validated, AddressOf Me.ControlValidated
		'
		'cboClassification
		'
		Me.cboClassification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboClassification.FormattingEnabled = true
		Me.cboClassification.Items.AddRange(New Object() {"", "Updates", "Critical Updates", "Security Updates", "Feature Packs", "Update Rollups", "Service Packs", "Tools", "Hotfixes", "Drivers"})
		Me.cboClassification.Location = New System.Drawing.Point(114, 132)
		Me.cboClassification.Name = "cboClassification"
		Me.cboClassification.Size = New System.Drawing.Size(233, 21)
		Me.cboClassification.TabIndex = 16
		AddHandler Me.cboClassification.Validating, AddressOf Me.ControlValidating
		AddHandler Me.cboClassification.SelectedIndexChanged, AddressOf Me.ValidateCombo
		AddHandler Me.cboClassification.Validated, AddressOf Me.ControlValidated
		'
		'txtBulletinID
		'
		Me.txtBulletinID.Location = New System.Drawing.Point(114, 159)
		Me.txtBulletinID.Name = "txtBulletinID"
		Me.txtBulletinID.Size = New System.Drawing.Size(233, 20)
		Me.txtBulletinID.TabIndex = 15
		AddHandler Me.txtBulletinID.Validating, AddressOf Me.TxtBulletinIDValidating
		'
		'txtDescription
		'
		Me.txtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.txtDescription.Location = New System.Drawing.Point(114, 87)
		Me.txtDescription.Multiline = true
		Me.txtDescription.Name = "txtDescription"
		Me.txtDescription.Size = New System.Drawing.Size(457, 39)
		Me.txtDescription.TabIndex = 14
		AddHandler Me.txtDescription.Validated, AddressOf Me.ControlValidated
		AddHandler Me.txtDescription.Validating, AddressOf Me.ControlValidating
		'
		'txtPackageTitle
		'
		Me.txtPackageTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.txtPackageTitle.Location = New System.Drawing.Point(114, 61)
		Me.txtPackageTitle.Name = "txtPackageTitle"
		Me.txtPackageTitle.Size = New System.Drawing.Size(457, 20)
		Me.txtPackageTitle.TabIndex = 13
		AddHandler Me.txtPackageTitle.Validated, AddressOf Me.ControlValidated
		AddHandler Me.txtPackageTitle.Validating, AddressOf Me.ControlValidating
		'
		'lblRebootBehavior
		'
		Me.lblRebootBehavior.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblRebootBehavior.Location = New System.Drawing.Point(21, 425)
		Me.lblRebootBehavior.Name = "lblRebootBehavior"
		Me.lblRebootBehavior.Size = New System.Drawing.Size(86, 17)
		Me.lblRebootBehavior.TabIndex = 12
		Me.lblRebootBehavior.Text = "Reboot Behavior"
		Me.lblRebootBehavior.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblImpact
		'
		Me.lblImpact.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblImpact.Location = New System.Drawing.Point(21, 372)
		Me.lblImpact.Name = "lblImpact"
		Me.lblImpact.Size = New System.Drawing.Size(86, 17)
		Me.lblImpact.TabIndex = 11
		Me.lblImpact.Text = "Impact"
		Me.lblImpact.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblMoreInfoURL
		'
		Me.lblMoreInfoURL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblMoreInfoURL.Location = New System.Drawing.Point(21, 347)
		Me.lblMoreInfoURL.Name = "lblMoreInfoURL"
		Me.lblMoreInfoURL.Size = New System.Drawing.Size(86, 17)
		Me.lblMoreInfoURL.TabIndex = 10
		Me.lblMoreInfoURL.Text = "More Info URL"
		Me.lblMoreInfoURL.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblSupportURL
		'
		Me.lblSupportURL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblSupportURL.Location = New System.Drawing.Point(21, 320)
		Me.lblSupportURL.Name = "lblSupportURL"
		Me.lblSupportURL.Size = New System.Drawing.Size(86, 17)
		Me.lblSupportURL.TabIndex = 9
		Me.lblSupportURL.Text = "Support URL"
		Me.lblSupportURL.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblSeverity
		'
		Me.lblSeverity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblSeverity.Location = New System.Drawing.Point(21, 189)
		Me.lblSeverity.Name = "lblSeverity"
		Me.lblSeverity.Size = New System.Drawing.Size(86, 17)
		Me.lblSeverity.TabIndex = 8
		Me.lblSeverity.Text = "Severity"
		Me.lblSeverity.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblCVEID
		'
		Me.lblCVEID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblCVEID.Location = New System.Drawing.Point(21, 296)
		Me.lblCVEID.Name = "lblCVEID"
		Me.lblCVEID.Size = New System.Drawing.Size(86, 17)
		Me.lblCVEID.TabIndex = 7
		Me.lblCVEID.Text = "CVE ID"
		Me.lblCVEID.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblArticleID
		'
		Me.lblArticleID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblArticleID.Location = New System.Drawing.Point(21, 269)
		Me.lblArticleID.Name = "lblArticleID"
		Me.lblArticleID.Size = New System.Drawing.Size(86, 17)
		Me.lblArticleID.TabIndex = 6
		Me.lblArticleID.Text = "Article ID"
		Me.lblArticleID.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblProduct
		'
		Me.lblProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblProduct.Location = New System.Drawing.Point(21, 243)
		Me.lblProduct.Name = "lblProduct"
		Me.lblProduct.Size = New System.Drawing.Size(86, 17)
		Me.lblProduct.TabIndex = 5
		Me.lblProduct.Text = "Product"
		Me.lblProduct.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblVendor
		'
		Me.lblVendor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblVendor.Location = New System.Drawing.Point(21, 216)
		Me.lblVendor.Name = "lblVendor"
		Me.lblVendor.Size = New System.Drawing.Size(86, 17)
		Me.lblVendor.TabIndex = 4
		Me.lblVendor.Text = "Vendor"
		Me.lblVendor.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblBullitinID
		'
		Me.lblBullitinID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblBullitinID.Location = New System.Drawing.Point(21, 163)
		Me.lblBullitinID.Name = "lblBullitinID"
		Me.lblBullitinID.Size = New System.Drawing.Size(86, 17)
		Me.lblBullitinID.TabIndex = 3
		Me.lblBullitinID.Text = "Bulletin ID"
		Me.lblBullitinID.TextAlign = System.Drawing.ContentAlignment.TopRight
		AddHandler Me.lblBullitinID.Validating, AddressOf Me.ControlValidating
		'
		'lblClassification
		'
		Me.lblClassification.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblClassification.Location = New System.Drawing.Point(21, 136)
		Me.lblClassification.Name = "lblClassification"
		Me.lblClassification.Size = New System.Drawing.Size(86, 17)
		Me.lblClassification.TabIndex = 2
		Me.lblClassification.Text = "Classification"
		Me.lblClassification.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblDescription
		'
		Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblDescription.Location = New System.Drawing.Point(21, 88)
		Me.lblDescription.Name = "lblDescription"
		Me.lblDescription.Size = New System.Drawing.Size(86, 17)
		Me.lblDescription.TabIndex = 1
		Me.lblDescription.Text = "Description"
		Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblPackageTitle
		'
		Me.lblPackageTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblPackageTitle.Location = New System.Drawing.Point(21, 61)
		Me.lblPackageTitle.Name = "lblPackageTitle"
		Me.lblPackageTitle.Size = New System.Drawing.Size(86, 17)
		Me.lblPackageTitle.TabIndex = 0
		Me.lblPackageTitle.Text = "Package Title"
		Me.lblPackageTitle.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'tabIsInstalled
		'
		Me.tabIsInstalled.BackColor = System.Drawing.SystemColors.Control
		Me.tabIsInstalled.Controls.Add(Me.isInstalledRules)
		Me.tabIsInstalled.Location = New System.Drawing.Point(4, 23)
		Me.tabIsInstalled.Name = "tabIsInstalled"
		Me.tabIsInstalled.Padding = New System.Windows.Forms.Padding(3)
		Me.tabIsInstalled.Size = New System.Drawing.Size(605, 488)
		Me.tabIsInstalled.TabIndex = 2
		Me.tabIsInstalled.Text = "IsInstalled"
		'
		'isInstalledRules
		'
		Me.isInstalledRules.ApplicibilityRule = ""
		Me.isInstalledRules.CausesValidation = false
		Me.isInstalledRules.Dock = System.Windows.Forms.DockStyle.Fill
		Me.isInstalledRules.Instructions = resources.GetString("isInstalledRules.Instructions")
		Me.isInstalledRules.Location = New System.Drawing.Point(3, 3)
		Me.isInstalledRules.Name = "isInstalledRules"
		Me.isInstalledRules.Rule = ""
		Me.isInstalledRules.Size = New System.Drawing.Size(599, 482)
		Me.isInstalledRules.TabIndex = 39
		Me.isInstalledRules.Title = "Package Level - Installed Rules"
		Me.isInstalledRules.TitleItemLevel = "Installation Item Level"
		'
		'tabIsInstallable
		'
		Me.tabIsInstallable.BackColor = System.Drawing.SystemColors.Control
		Me.tabIsInstallable.Controls.Add(Me.isInstallableRules)
		Me.tabIsInstallable.Location = New System.Drawing.Point(4, 23)
		Me.tabIsInstallable.Name = "tabIsInstallable"
		Me.tabIsInstallable.Padding = New System.Windows.Forms.Padding(3)
		Me.tabIsInstallable.Size = New System.Drawing.Size(605, 488)
		Me.tabIsInstallable.TabIndex = 3
		Me.tabIsInstallable.Text = "IsInstallable"
		'
		'isInstallableRules
		'
		Me.isInstallableRules.ApplicibilityRule = ""
		Me.isInstallableRules.CausesValidation = false
		Me.isInstallableRules.Dock = System.Windows.Forms.DockStyle.Fill
		Me.isInstallableRules.Instructions = resources.GetString("isInstallableRules.Instructions")
		Me.isInstallableRules.Location = New System.Drawing.Point(3, 3)
		Me.isInstallableRules.Name = "isInstallableRules"
		Me.isInstallableRules.Rule = ""
		Me.isInstallableRules.Size = New System.Drawing.Size(599, 482)
		Me.isInstallableRules.TabIndex = 40
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
		Me.tabIsSuperseded.Location = New System.Drawing.Point(4, 23)
		Me.tabIsSuperseded.Name = "tabIsSuperseded"
		Me.tabIsSuperseded.Padding = New System.Windows.Forms.Padding(3)
		Me.tabIsSuperseded.Size = New System.Drawing.Size(605, 488)
		Me.tabIsSuperseded.TabIndex = 5
		Me.tabIsSuperseded.Text = "IsSuperseded"
		'
		'btnIsSupersededEdit
		'
		Me.btnIsSupersededEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.btnIsSupersededEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 7!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.btnIsSupersededEdit.Location = New System.Drawing.Point(558, 42)
		Me.btnIsSupersededEdit.Margin = New System.Windows.Forms.Padding(0)
		Me.btnIsSupersededEdit.Name = "btnIsSupersededEdit"
		Me.btnIsSupersededEdit.Size = New System.Drawing.Size(40, 20)
		Me.btnIsSupersededEdit.TabIndex = 43
		Me.btnIsSupersededEdit.Text = "Edit"
		Me.btnIsSupersededEdit.UseVisualStyleBackColor = true
		AddHandler Me.btnIsSupersededEdit.Click, AddressOf Me.BtnIsSupersededEditClick
		'
		'lblIsSuperseded
		'
		Me.lblIsSuperseded.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblIsSuperseded.Location = New System.Drawing.Point(0, 3)
		Me.lblIsSuperseded.Name = "lblIsSuperseded"
		Me.lblIsSuperseded.Size = New System.Drawing.Size(598, 44)
		Me.lblIsSuperseded.TabIndex = 40
		Me.lblIsSuperseded.Text = resources.GetString("lblIsSuperseded.Text")
		'
		'lblIsSuperceded_InstallableItem
		'
		Me.lblIsSuperceded_InstallableItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblIsSuperceded_InstallableItem.Location = New System.Drawing.Point(58, 45)
		Me.lblIsSuperceded_InstallableItem.Name = "lblIsSuperceded_InstallableItem"
		Me.lblIsSuperceded_InstallableItem.Size = New System.Drawing.Size(262, 17)
		Me.lblIsSuperceded_InstallableItem.TabIndex = 3
		Me.lblIsSuperceded_InstallableItem.Text = "Installation Item Level - Superseded Rules"
		'
		'txtIsSuperceded_InstallableItem
		'
		Me.txtIsSuperceded_InstallableItem.Location = New System.Drawing.Point(5, 65)
		Me.txtIsSuperceded_InstallableItem.Multiline = true
		Me.txtIsSuperceded_InstallableItem.Name = "txtIsSuperceded_InstallableItem"
		Me.txtIsSuperceded_InstallableItem.ReadOnly = true
		Me.txtIsSuperceded_InstallableItem.Size = New System.Drawing.Size(595, 397)
		Me.txtIsSuperceded_InstallableItem.TabIndex = 2
		'
		'tabMetaData
		'
		Me.tabMetaData.BackColor = System.Drawing.SystemColors.Control
		Me.tabMetaData.Controls.Add(Me.btnMetaDataEdit)
		Me.tabMetaData.Controls.Add(Me.lblMetaData_InstallableItem)
		Me.tabMetaData.Controls.Add(Me.lblMetaData)
		Me.tabMetaData.Controls.Add(Me.txtInstallableItemMetaData)
		Me.tabMetaData.Location = New System.Drawing.Point(4, 23)
		Me.tabMetaData.Name = "tabMetaData"
		Me.tabMetaData.Padding = New System.Windows.Forms.Padding(3)
		Me.tabMetaData.Size = New System.Drawing.Size(605, 488)
		Me.tabMetaData.TabIndex = 6
		Me.tabMetaData.Text = "MetaData"
		'
		'btnMetaDataEdit
		'
		Me.btnMetaDataEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.btnMetaDataEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 7!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.btnMetaDataEdit.Location = New System.Drawing.Point(558, 42)
		Me.btnMetaDataEdit.Margin = New System.Windows.Forms.Padding(0)
		Me.btnMetaDataEdit.Name = "btnMetaDataEdit"
		Me.btnMetaDataEdit.Size = New System.Drawing.Size(40, 20)
		Me.btnMetaDataEdit.TabIndex = 42
		Me.btnMetaDataEdit.Text = "Edit"
		Me.btnMetaDataEdit.UseVisualStyleBackColor = true
		AddHandler Me.btnMetaDataEdit.Click, AddressOf Me.BtnMetaDataEditClick
		'
		'lblMetaData_InstallableItem
		'
		Me.lblMetaData_InstallableItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblMetaData_InstallableItem.Location = New System.Drawing.Point(58, 45)
		Me.lblMetaData_InstallableItem.Name = "lblMetaData_InstallableItem"
		Me.lblMetaData_InstallableItem.Size = New System.Drawing.Size(239, 17)
		Me.lblMetaData_InstallableItem.TabIndex = 41
		Me.lblMetaData_InstallableItem.Text = "Installation Item Level - Rule Metadata"
		'
		'lblMetaData
		'
		Me.lblMetaData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblMetaData.Location = New System.Drawing.Point(0, 3)
		Me.lblMetaData.Name = "lblMetaData"
		Me.lblMetaData.Size = New System.Drawing.Size(598, 41)
		Me.lblMetaData.TabIndex = 40
		Me.lblMetaData.Text = resources.GetString("lblMetaData.Text")
		'
		'txtInstallableItemMetaData
		'
		Me.txtInstallableItemMetaData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
						Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.txtInstallableItemMetaData.Location = New System.Drawing.Point(5, 65)
		Me.txtInstallableItemMetaData.Multiline = true
		Me.txtInstallableItemMetaData.Name = "txtInstallableItemMetaData"
		Me.txtInstallableItemMetaData.ReadOnly = true
		Me.txtInstallableItemMetaData.Size = New System.Drawing.Size(595, 417)
		Me.txtInstallableItemMetaData.TabIndex = 2
		'
		'tabSummary
		'
		Me.tabSummary.BackColor = System.Drawing.SystemColors.Control
		Me.tabSummary.Controls.Add(Me.label4)
		Me.tabSummary.Controls.Add(Me.txtSummary)
		Me.tabSummary.Location = New System.Drawing.Point(4, 23)
		Me.tabSummary.Name = "tabSummary"
		Me.tabSummary.Padding = New System.Windows.Forms.Padding(3)
		Me.tabSummary.Size = New System.Drawing.Size(605, 488)
		Me.tabSummary.TabIndex = 4
		Me.tabSummary.Text = "Summary"
		'
		'label4
		'
		Me.label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.label4.Location = New System.Drawing.Point(0, 3)
		Me.label4.Name = "label4"
		Me.label4.Size = New System.Drawing.Size(598, 36)
		Me.label4.TabIndex = 41
		Me.label4.Text = "Use this form to review the XML data that will be used to describe the software p"& _ 
		"ackage.  Select Finish to publish this package to the WSUS server."
		'
		'txtSummary
		'
		Me.txtSummary.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.txtSummary.Location = New System.Drawing.Point(6, 42)
		Me.txtSummary.Multiline = true
		Me.txtSummary.Name = "txtSummary"
		Me.txtSummary.ReadOnly = true
		Me.txtSummary.ScrollBars = System.Windows.Forms.ScrollBars.Both
		Me.txtSummary.Size = New System.Drawing.Size(593, 420)
		Me.txtSummary.TabIndex = 2
		Me.txtSummary.TabStop = false
		Me.txtSummary.WordWrap = false
		'
		'btnPrevious
		'
		Me.btnPrevious.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.btnPrevious.CausesValidation = false
		Me.btnPrevious.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.btnPrevious.Location = New System.Drawing.Point(354, 524)
		Me.btnPrevious.Name = "btnPrevious"
		Me.btnPrevious.Size = New System.Drawing.Size(78, 24)
		Me.btnPrevious.TabIndex = 1
		Me.btnPrevious.Text = "Previous"
		Me.btnPrevious.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.btnPrevious.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnPrevious.UseVisualStyleBackColor = true
		AddHandler Me.btnPrevious.Click, AddressOf Me.BtnPreviousClick
		'
		'btnNext
		'
		Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.btnNext.CausesValidation = false
		Me.btnNext.Enabled = false
		Me.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnNext.Location = New System.Drawing.Point(433, 524)
		Me.btnNext.Name = "btnNext"
		Me.btnNext.Size = New System.Drawing.Size(78, 24)
		Me.btnNext.TabIndex = 2
		Me.btnNext.Text = "Next"
		Me.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
		Me.btnNext.UseVisualStyleBackColor = true
		AddHandler Me.btnNext.Click, AddressOf Me.BtnNextClick
		'
		'btnCancel
		'
		Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.btnCancel.CausesValidation = false
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Location = New System.Drawing.Point(546, 524)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(66, 24)
		Me.btnCancel.TabIndex = 3
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.UseVisualStyleBackColor = true
		AddHandler Me.btnCancel.Click, AddressOf Me.BtnCancelClick
		'
		'dlgUpdateFile
		'
		Me.dlgUpdateFile.Title = "Select Update File"
		'
		'chkExportSdp
		'
		Me.chkExportSdp.CausesValidation = false
		Me.chkExportSdp.Location = New System.Drawing.Point(4, 533)
		Me.chkExportSdp.Name = "chkExportSdp"
		Me.chkExportSdp.Size = New System.Drawing.Size(216, 19)
		Me.chkExportSdp.TabIndex = 4
		Me.chkExportSdp.Text = "Save Software Definition Package"
		Me.chkExportSdp.UseVisualStyleBackColor = true
		'
		'cboMetadataOnly
		'
		Me.cboMetadataOnly.CausesValidation = false
		Me.cboMetadataOnly.Location = New System.Drawing.Point(4, 516)
		Me.cboMetadataOnly.Name = "cboMetadataOnly"
		Me.cboMetadataOnly.Size = New System.Drawing.Size(216, 19)
		Me.cboMetadataOnly.TabIndex = 5
		Me.cboMetadataOnly.Text = "Publish Metadata Only"
		Me.cboMetadataOnly.UseVisualStyleBackColor = true
		'
		'errorProviderUpdate
		'
		Me.errorProviderUpdate.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
		Me.errorProviderUpdate.ContainerControl = Me
		'
		'cboPackageType
		'
		Me.cboPackageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboPackageType.FormattingEnabled = true
		Me.cboPackageType.Items.AddRange(New Object() {"Application", "Update"})
		Me.cboPackageType.Location = New System.Drawing.Point(114, 34)
		Me.cboPackageType.Name = "cboPackageType"
		Me.cboPackageType.Size = New System.Drawing.Size(233, 21)
		Me.cboPackageType.TabIndex = 67
		'
		'lblPackageType
		'
		Me.lblPackageType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblPackageType.Location = New System.Drawing.Point(8, 38)
		Me.lblPackageType.Name = "lblPackageType"
		Me.lblPackageType.Size = New System.Drawing.Size(99, 17)
		Me.lblPackageType.TabIndex = 66
		Me.lblPackageType.Text = "Package Type"
		Me.lblPackageType.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'UpdateForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
		Me.ClientSize = New System.Drawing.Size(615, 556)
		Me.Controls.Add(Me.cboMetadataOnly)
		Me.Controls.Add(Me.chkExportSdp)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnNext)
		Me.Controls.Add(Me.btnPrevious)
		Me.Controls.Add(Me.tabsImportUpdate)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.Name = "UpdateForm"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "Import Update from File"
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
	Private lblPackageType As System.Windows.Forms.Label
	Private cboPackageType As System.Windows.Forms.ComboBox
	Private errorProviderUpdate As System.Windows.Forms.ErrorProvider
	Private cboMetadataOnly As System.Windows.Forms.CheckBox
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
	Private btnAddFile As System.Windows.Forms.Button
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
