' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 11/12/2009
' Time: 11:10 AM

Partial Class RulesForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RulesForm))
		Me.lblInfo = New System.Windows.Forms.Label
		Me.cboRuleType = New System.Windows.Forms.ComboBox
		Me.lblRuleType = New System.Windows.Forms.Label
		Me.lblProductType = New System.Windows.Forms.Label
		Me.cboProductType = New System.Windows.Forms.ComboBox
		Me.txtSPMinorVersion = New System.Windows.Forms.TextBox
		Me.txtSPMajorVersion = New System.Windows.Forms.TextBox
		Me.txtOSMinorVersion = New System.Windows.Forms.TextBox
		Me.txtOSMajorVersion = New System.Windows.Forms.TextBox
		Me.lblServicePack = New System.Windows.Forms.Label
		Me.cboServicePack = New System.Windows.Forms.ComboBox
		Me.lbl_OSVersion = New System.Windows.Forms.Label
		Me.cboOSVersion = New System.Windows.Forms.ComboBox
		Me.lblComparison = New System.Windows.Forms.Label
		Me.cboComparison = New System.Windows.Forms.ComboBox
		Me.lblLanguage = New System.Windows.Forms.Label
		Me.cboLanguage = New System.Windows.Forms.ComboBox
		Me.lblProcessorType = New System.Windows.Forms.Label
		Me.cboProcessorType = New System.Windows.Forms.ComboBox
		Me.lblEnvironmentVariable = New System.Windows.Forms.Label
		Me.cboEnvironmentVariable = New System.Windows.Forms.ComboBox
		Me.txtVersion = New System.Windows.Forms.TextBox
		Me.lblVersion = New System.Windows.Forms.Label
		Me.txtRegistryValue = New System.Windows.Forms.TextBox
		Me.lblRegistryValue = New System.Windows.Forms.Label
		Me.chkRegistry32Bit = New System.Windows.Forms.CheckBox
		Me.txtRegistrySubKey = New System.Windows.Forms.TextBox
		Me.lblRegistryKey = New System.Windows.Forms.Label
		Me.cboRegistryKey = New System.Windows.Forms.ComboBox
		Me.txtFilePath = New System.Windows.Forms.TextBox
		Me.lblFilePath = New System.Windows.Forms.Label
		Me.dtpDate = New System.Windows.Forms.DateTimePicker
		Me.lblDate = New System.Windows.Forms.Label
		Me.lblDataInfo = New System.Windows.Forms.Label
		Me.txtData = New System.Windows.Forms.TextBox
		Me.lblData = New System.Windows.Forms.Label
		Me.txtQuery = New System.Windows.Forms.TextBox
		Me.lblQuery = New System.Windows.Forms.Label
		Me.chkNotRule = New System.Windows.Forms.CheckBox
		Me.btnAdd = New System.Windows.Forms.Button
		Me.btnCancel = New System.Windows.Forms.Button
		Me.lblRegistryValueType = New System.Windows.Forms.Label
		Me.cboRegistryValueType = New System.Windows.Forms.ComboBox
		Me.splitContainer = New System.Windows.Forms.SplitContainer
		Me.pnlComponentCollection = New System.Windows.Forms.Panel
		Me.gceComponentCollection = New LocalUpdatePublisher.GuidCollectionEditor
		Me.chkComponentCollection_requireAll = New System.Windows.Forms.CheckBox
		Me.lblComponentCollection = New System.Windows.Forms.Label
		Me.pnlFeatureCollection = New System.Windows.Forms.Panel
		Me.gceFeatureCollection = New LocalUpdatePublisher.GuidCollectionEditor
		Me.chkFeatureCollection_requireAll = New System.Windows.Forms.CheckBox
		Me.lblFeatureCollection = New System.Windows.Forms.Label
		Me.pnlProductCollection = New System.Windows.Forms.Panel
		Me.gceProductCollection = New LocalUpdatePublisher.GuidCollectionEditor
		Me.chkProductCollection_requireAll = New System.Windows.Forms.CheckBox
		Me.lblProductCollection = New System.Windows.Forms.Label
		Me.pnlMinVersion = New System.Windows.Forms.Panel
		Me.txtMinVersion = New System.Windows.Forms.TextBox
		Me.lblMinVersion = New System.Windows.Forms.Label
		Me.pnlMaxVersion = New System.Windows.Forms.Panel
		Me.txtMaxVersion = New System.Windows.Forms.TextBox
		Me.lblMaxVersion = New System.Windows.Forms.Label
		Me.pnlPatchCode = New System.Windows.Forms.Panel
		Me.txtPatchCode = New System.Windows.Forms.TextBox
		Me.lblPatchCode = New System.Windows.Forms.Label
		Me.pnlProductCode = New System.Windows.Forms.Panel
		Me.txtProductCode = New System.Windows.Forms.TextBox
		Me.lblProductCode = New System.Windows.Forms.Label
		Me.pnlRegistry32Bit = New System.Windows.Forms.Panel
		Me.pnlQuery = New System.Windows.Forms.Panel
		Me.pnlDate = New System.Windows.Forms.Panel
		Me.pnlData = New System.Windows.Forms.Panel
		Me.pnlVersion = New System.Windows.Forms.Panel
		Me.pnlFilePath = New System.Windows.Forms.Panel
		Me.pnlEnvironmentVariable = New System.Windows.Forms.Panel
		Me.pnlRegistryValueType = New System.Windows.Forms.Panel
		Me.pnlRegistryValue = New System.Windows.Forms.Panel
		Me.pnlRegistryKey = New System.Windows.Forms.Panel
		Me.pnlProcessorType = New System.Windows.Forms.Panel
		Me.pnlLanguage = New System.Windows.Forms.Panel
		Me.pnlProductType = New System.Windows.Forms.Panel
		Me.pnlServicePack = New System.Windows.Forms.Panel
		Me.pnlOSVersion = New System.Windows.Forms.Panel
		Me.pnlComparison = New System.Windows.Forms.Panel
		Me.errorProviderRules = New System.Windows.Forms.ErrorProvider(Me.components)
		Me.splitContainer.Panel1.SuspendLayout
		Me.splitContainer.Panel2.SuspendLayout
		Me.splitContainer.SuspendLayout
		Me.pnlComponentCollection.SuspendLayout
		Me.pnlFeatureCollection.SuspendLayout
		Me.pnlProductCollection.SuspendLayout
		Me.pnlMinVersion.SuspendLayout
		Me.pnlMaxVersion.SuspendLayout
		Me.pnlPatchCode.SuspendLayout
		Me.pnlProductCode.SuspendLayout
		Me.pnlRegistry32Bit.SuspendLayout
		Me.pnlQuery.SuspendLayout
		Me.pnlDate.SuspendLayout
		Me.pnlData.SuspendLayout
		Me.pnlVersion.SuspendLayout
		Me.pnlFilePath.SuspendLayout
		Me.pnlEnvironmentVariable.SuspendLayout
		Me.pnlRegistryValueType.SuspendLayout
		Me.pnlRegistryValue.SuspendLayout
		Me.pnlRegistryKey.SuspendLayout
		Me.pnlProcessorType.SuspendLayout
		Me.pnlLanguage.SuspendLayout
		Me.pnlProductType.SuspendLayout
		Me.pnlServicePack.SuspendLayout
		Me.pnlOSVersion.SuspendLayout
		Me.pnlComparison.SuspendLayout
		CType(Me.errorProviderRules,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'lblInfo
		'
		Me.lblInfo.Location = New System.Drawing.Point(25, 4)
		Me.lblInfo.Name = "lblInfo"
		Me.lblInfo.Size = New System.Drawing.Size(388, 15)
		Me.lblInfo.TabIndex = 3
		Me.lblInfo.Text = "Use this form to create a new rule that determines if this update can be installe"& _ 
		"d"
		'
		'cboRuleType
		'
		Me.cboRuleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboRuleType.FormattingEnabled = true
		Me.cboRuleType.Location = New System.Drawing.Point(79, 23)
		Me.cboRuleType.Name = "cboRuleType"
		Me.cboRuleType.Size = New System.Drawing.Size(200, 21)
		Me.cboRuleType.TabIndex = 0
		AddHandler Me.cboRuleType.SelectedIndexChanged, AddressOf Me.cboRuleTypeSelectedIndexChanged
		AddHandler Me.cboRuleType.Format, AddressOf Me.CboRuleTypeFormat
		'
		'lblRuleType
		'
		Me.lblRuleType.Location = New System.Drawing.Point(13, 26)
		Me.lblRuleType.Name = "lblRuleType"
		Me.lblRuleType.Size = New System.Drawing.Size(60, 20)
		Me.lblRuleType.TabIndex = 0
		Me.lblRuleType.Text = "Rule Type"
		'
		'lblProductType
		'
		Me.lblProductType.Location = New System.Drawing.Point(0, 0)
		Me.lblProductType.Name = "lblProductType"
		Me.lblProductType.Size = New System.Drawing.Size(115, 20)
		Me.lblProductType.TabIndex = 13
		Me.lblProductType.Text = "Product Type"
		Me.lblProductType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cboProductType
		'
		Me.cboProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboProductType.FormattingEnabled = true
		Me.cboProductType.Items.AddRange(New Object() {"None", "Workstation", "Domain Controller", "Server"})
		Me.cboProductType.Location = New System.Drawing.Point(120, 0)
		Me.cboProductType.Name = "cboProductType"
		Me.cboProductType.Size = New System.Drawing.Size(185, 21)
		Me.cboProductType.TabIndex = 0
		'
		'txtSPMinorVersion
		'
		Me.txtSPMinorVersion.Location = New System.Drawing.Point(335, 0)
		Me.txtSPMinorVersion.Name = "txtSPMinorVersion"
		Me.txtSPMinorVersion.Size = New System.Drawing.Size(20, 20)
		Me.txtSPMinorVersion.TabIndex = 9
		'
		'txtSPMajorVersion
		'
		Me.txtSPMajorVersion.Location = New System.Drawing.Point(310, 0)
		Me.txtSPMajorVersion.Name = "txtSPMajorVersion"
		Me.txtSPMajorVersion.Size = New System.Drawing.Size(20, 20)
		Me.txtSPMajorVersion.TabIndex = 8
		'
		'txtOSMinorVersion
		'
		Me.txtOSMinorVersion.Location = New System.Drawing.Point(335, 0)
		Me.txtOSMinorVersion.Name = "txtOSMinorVersion"
		Me.txtOSMinorVersion.Size = New System.Drawing.Size(20, 20)
		Me.txtOSMinorVersion.TabIndex = 6
		AddHandler Me.txtOSMinorVersion.TextChanged, AddressOf Me.ValidateForm
		'
		'txtOSMajorVersion
		'
		Me.txtOSMajorVersion.Location = New System.Drawing.Point(310, 0)
		Me.txtOSMajorVersion.Name = "txtOSMajorVersion"
		Me.txtOSMajorVersion.Size = New System.Drawing.Size(20, 20)
		Me.txtOSMajorVersion.TabIndex = 5
		AddHandler Me.txtOSMajorVersion.TextChanged, AddressOf Me.ValidateForm
		'
		'lblServicePack
		'
		Me.lblServicePack.Location = New System.Drawing.Point(0, 0)
		Me.lblServicePack.Name = "lblServicePack"
		Me.lblServicePack.Size = New System.Drawing.Size(115, 20)
		Me.lblServicePack.TabIndex = 5
		Me.lblServicePack.Text = "Service Pack"
		Me.lblServicePack.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cboServicePack
		'
		Me.cboServicePack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboServicePack.FormattingEnabled = true
		Me.cboServicePack.Items.AddRange(New Object() {"SP 1", "SP 2", "SP 3", "SP 4"})
		Me.cboServicePack.Location = New System.Drawing.Point(120, 0)
		Me.cboServicePack.Name = "cboServicePack"
		Me.cboServicePack.Size = New System.Drawing.Size(185, 21)
		Me.cboServicePack.TabIndex = 0
		AddHandler Me.cboServicePack.SelectedIndexChanged, AddressOf Me.GetServicePackCode
		'
		'lbl_OSVersion
		'
		Me.lbl_OSVersion.Location = New System.Drawing.Point(0, 0)
		Me.lbl_OSVersion.Name = "lbl_OSVersion"
		Me.lbl_OSVersion.Size = New System.Drawing.Size(115, 20)
		Me.lbl_OSVersion.TabIndex = 3
		Me.lbl_OSVersion.Text = "OS Version"
		Me.lbl_OSVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cboOSVersion
		'
		Me.cboOSVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboOSVersion.FormattingEnabled = true
		Me.cboOSVersion.Items.AddRange(New Object() {"Windows 2000", "Windows XP", "Windows Server 2003", "Windows Vista", "Windows Server 2008", "Windows 7"})
		Me.cboOSVersion.Location = New System.Drawing.Point(120, 0)
		Me.cboOSVersion.Name = "cboOSVersion"
		Me.cboOSVersion.Size = New System.Drawing.Size(185, 21)
		Me.cboOSVersion.TabIndex = 0
		AddHandler Me.cboOSVersion.SelectedIndexChanged, AddressOf Me.GetOSVersionCodes
		'
		'lblComparison
		'
		Me.lblComparison.Location = New System.Drawing.Point(0, 0)
		Me.lblComparison.Name = "lblComparison"
		Me.lblComparison.Size = New System.Drawing.Size(115, 20)
		Me.lblComparison.TabIndex = 1
		Me.lblComparison.Text = "Comparison"
		Me.lblComparison.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cboComparison
		'
		Me.cboComparison.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboComparison.FormattingEnabled = true
		Me.cboComparison.Items.AddRange(New Object() {"Equal To", "Less Than", "Less Than or Equal To", "Greater Than", "Greater Than or Equal To"})
		Me.cboComparison.Location = New System.Drawing.Point(120, 0)
		Me.cboComparison.Name = "cboComparison"
		Me.cboComparison.Size = New System.Drawing.Size(185, 21)
		Me.cboComparison.TabIndex = 0
		AddHandler Me.cboComparison.SelectedIndexChanged, AddressOf Me.ValidateForm
		'
		'lblLanguage
		'
		Me.lblLanguage.Location = New System.Drawing.Point(0, 0)
		Me.lblLanguage.Name = "lblLanguage"
		Me.lblLanguage.Size = New System.Drawing.Size(115, 23)
		Me.lblLanguage.TabIndex = 9
		Me.lblLanguage.Text = "Language"
		Me.lblLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cboLanguage
		'
		Me.cboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboLanguage.FormattingEnabled = true
		Me.cboLanguage.Items.AddRange(New Object() {"Arabic", "Chinese (Hong Kong SAR)", "Chinese (Simplified)", "Chinese (Traditional)", "Czech", "Danish", "Dutch", "English", "Finnish", "French", "German", "Greek", "Hebrew", "Hungarian", "Italian", "Japenese", "Korean", "Norwegian", "Polish", "Portuguese", "Portuguese (Brazil)", "Russian", "Spanish", "Swedish", "Turkish"})
		Me.cboLanguage.Location = New System.Drawing.Point(120, 0)
		Me.cboLanguage.Name = "cboLanguage"
		Me.cboLanguage.Size = New System.Drawing.Size(185, 21)
		Me.cboLanguage.TabIndex = 0
		AddHandler Me.cboLanguage.SelectedIndexChanged, AddressOf Me.ValidateForm
		'
		'lblProcessorType
		'
		Me.lblProcessorType.Location = New System.Drawing.Point(0, 0)
		Me.lblProcessorType.Name = "lblProcessorType"
		Me.lblProcessorType.Size = New System.Drawing.Size(115, 20)
		Me.lblProcessorType.TabIndex = 3
		Me.lblProcessorType.Text = "Processor Type"
		Me.lblProcessorType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cboProcessorType
		'
		Me.cboProcessorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboProcessorType.FormattingEnabled = true
		Me.cboProcessorType.Items.AddRange(New Object() {"x86", "x64", "IA64"})
		Me.cboProcessorType.Location = New System.Drawing.Point(120, 0)
		Me.cboProcessorType.Name = "cboProcessorType"
		Me.cboProcessorType.Size = New System.Drawing.Size(185, 21)
		Me.cboProcessorType.TabIndex = 0
		AddHandler Me.cboProcessorType.SelectedIndexChanged, AddressOf Me.ValidateForm
		'
		'lblEnvironmentVariable
		'
		Me.lblEnvironmentVariable.Location = New System.Drawing.Point(0, 0)
		Me.lblEnvironmentVariable.Name = "lblEnvironmentVariable"
		Me.lblEnvironmentVariable.Size = New System.Drawing.Size(115, 20)
		Me.lblEnvironmentVariable.TabIndex = 16
		Me.lblEnvironmentVariable.Text = "Environment Variable"
		Me.lblEnvironmentVariable.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cboEnvironmentVariable
		'
		Me.cboEnvironmentVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboEnvironmentVariable.FormattingEnabled = true
		Me.cboEnvironmentVariable.Items.AddRange(New Object() {"None", "System", "Program Files", "Program Files Common", "Windows", "Common Admin Tools", "Common Alt Startup", "Common App Data", "Common Desktop Directory", "Common Documents", "Common Favorites", "Common Music", "Common Pictures", "Common Programs", "Common Startup", "Common Start Menu", "Common Templates", "Common Video", "Controls", "Drives", "Printers", "Profiles"})
		Me.cboEnvironmentVariable.Location = New System.Drawing.Point(120, 0)
		Me.cboEnvironmentVariable.Name = "cboEnvironmentVariable"
		Me.cboEnvironmentVariable.Size = New System.Drawing.Size(185, 21)
		Me.cboEnvironmentVariable.TabIndex = 0
		'
		'txtVersion
		'
		Me.txtVersion.Location = New System.Drawing.Point(120, 0)
		Me.txtVersion.Name = "txtVersion"
		Me.txtVersion.Size = New System.Drawing.Size(185, 20)
		Me.txtVersion.TabIndex = 0
		AddHandler Me.txtVersion.TextChanged, AddressOf Me.ValidateForm
		AddHandler Me.txtVersion.Validating, AddressOf Me.ValidateVersion
		'
		'lblVersion
		'
		Me.lblVersion.Location = New System.Drawing.Point(0, 0)
		Me.lblVersion.Name = "lblVersion"
		Me.lblVersion.Size = New System.Drawing.Size(115, 20)
		Me.lblVersion.TabIndex = 13
		Me.lblVersion.Text = "Version"
		Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtRegistryValue
		'
		Me.txtRegistryValue.Location = New System.Drawing.Point(120, 0)
		Me.txtRegistryValue.Name = "txtRegistryValue"
		Me.txtRegistryValue.Size = New System.Drawing.Size(185, 20)
		Me.txtRegistryValue.TabIndex = 0
		AddHandler Me.txtRegistryValue.TextChanged, AddressOf Me.ValidateForm
		'
		'lblRegistryValue
		'
		Me.lblRegistryValue.Location = New System.Drawing.Point(0, 0)
		Me.lblRegistryValue.Name = "lblRegistryValue"
		Me.lblRegistryValue.Size = New System.Drawing.Size(115, 20)
		Me.lblRegistryValue.TabIndex = 41
		Me.lblRegistryValue.Text = "Registry Value"
		Me.lblRegistryValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'chkRegistry32Bit
		'
		Me.chkRegistry32Bit.Location = New System.Drawing.Point(0, 0)
		Me.chkRegistry32Bit.Name = "chkRegistry32Bit"
		Me.chkRegistry32Bit.Size = New System.Drawing.Size(104, 21)
		Me.chkRegistry32Bit.TabIndex = 0
		Me.chkRegistry32Bit.Text = "32 Bit Registry"
		Me.chkRegistry32Bit.UseVisualStyleBackColor = true
		'
		'txtRegistrySubKey
		'
		Me.txtRegistrySubKey.Location = New System.Drawing.Point(270, 0)
		Me.txtRegistrySubKey.Name = "txtRegistrySubKey"
		Me.txtRegistrySubKey.Size = New System.Drawing.Size(260, 20)
		Me.txtRegistrySubKey.TabIndex = 1
		AddHandler Me.txtRegistrySubKey.TextChanged, AddressOf Me.ValidateForm
		'
		'lblRegistryKey
		'
		Me.lblRegistryKey.Location = New System.Drawing.Point(0, 0)
		Me.lblRegistryKey.Name = "lblRegistryKey"
		Me.lblRegistryKey.Size = New System.Drawing.Size(115, 20)
		Me.lblRegistryKey.TabIndex = 37
		Me.lblRegistryKey.Text = "Registry Key"
		Me.lblRegistryKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cboRegistryKey
		'
		Me.cboRegistryKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboRegistryKey.FormattingEnabled = true
		Me.cboRegistryKey.Items.AddRange(New Object() {"HKEY_LOCAL_MACHINE"})
		Me.cboRegistryKey.Location = New System.Drawing.Point(120, 0)
		Me.cboRegistryKey.Name = "cboRegistryKey"
		Me.cboRegistryKey.Size = New System.Drawing.Size(145, 21)
		Me.cboRegistryKey.TabIndex = 0
		AddHandler Me.cboRegistryKey.SelectedIndexChanged, AddressOf Me.ValidateForm
		'
		'txtFilePath
		'
		Me.txtFilePath.Location = New System.Drawing.Point(120, 0)
		Me.txtFilePath.Name = "txtFilePath"
		Me.txtFilePath.Size = New System.Drawing.Size(410, 20)
		Me.txtFilePath.TabIndex = 0
		AddHandler Me.txtFilePath.TextChanged, AddressOf Me.ValidateForm
		'
		'lblFilePath
		'
		Me.lblFilePath.Location = New System.Drawing.Point(0, 0)
		Me.lblFilePath.Name = "lblFilePath"
		Me.lblFilePath.Size = New System.Drawing.Size(115, 20)
		Me.lblFilePath.TabIndex = 15
		Me.lblFilePath.Text = "Path"
		Me.lblFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'dtpDate
		'
		Me.dtpDate.Checked = false
		Me.dtpDate.CustomFormat = "yyyy/MM/dd HH:mm:ss"
		Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
		Me.dtpDate.Location = New System.Drawing.Point(120, 0)
		Me.dtpDate.Name = "dtpDate"
		Me.dtpDate.ShowCheckBox = true
		Me.dtpDate.ShowUpDown = true
		Me.dtpDate.Size = New System.Drawing.Size(185, 20)
		Me.dtpDate.TabIndex = 0
		AddHandler Me.dtpDate.ValueChanged, AddressOf Me.ValidateForm
		'
		'lblDate
		'
		Me.lblDate.Location = New System.Drawing.Point(0, 0)
		Me.lblDate.Name = "lblDate"
		Me.lblDate.Size = New System.Drawing.Size(115, 20)
		Me.lblDate.TabIndex = 27
		Me.lblDate.Text = "Created Date"
		Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'lblDataInfo
		'
		Me.lblDataInfo.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.lblDataInfo.Location = New System.Drawing.Point(310, 0)
		Me.lblDataInfo.Name = "lblDataInfo"
		Me.lblDataInfo.Size = New System.Drawing.Size(97, 21)
		Me.lblDataInfo.TabIndex = 1
		Me.lblDataInfo.Text = "in Bytes (ex. 1024)"
		Me.lblDataInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'txtData
		'
		Me.txtData.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.txtData.Location = New System.Drawing.Point(120, 0)
		Me.txtData.Name = "txtData"
		Me.txtData.Size = New System.Drawing.Size(185, 20)
		Me.txtData.TabIndex = 0
		AddHandler Me.txtData.TextChanged, AddressOf Me.ValidateForm
		'
		'lblData
		'
		Me.lblData.Location = New System.Drawing.Point(0, 0)
		Me.lblData.Name = "lblData"
		Me.lblData.Size = New System.Drawing.Size(115, 20)
		Me.lblData.TabIndex = 25
		Me.lblData.Text = "Data Label"
		Me.lblData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtQuery
		'
		Me.txtQuery.AcceptsReturn = true
		Me.txtQuery.AcceptsTab = true
		Me.txtQuery.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
						Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.txtQuery.Location = New System.Drawing.Point(120, 0)
		Me.txtQuery.Multiline = true
		Me.txtQuery.Name = "txtQuery"
		Me.txtQuery.Size = New System.Drawing.Size(410, 20)
		Me.txtQuery.TabIndex = 0
		AddHandler Me.txtQuery.TextChanged, AddressOf Me.ValidateForm
		'
		'lblQuery
		'
		Me.lblQuery.Location = New System.Drawing.Point(0, 0)
		Me.lblQuery.Name = "lblQuery"
		Me.lblQuery.Size = New System.Drawing.Size(115, 20)
		Me.lblQuery.TabIndex = 34
		Me.lblQuery.Text = "Query"
		Me.lblQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'chkNotRule
		'
		Me.chkNotRule.Location = New System.Drawing.Point(315, 23)
		Me.chkNotRule.Name = "chkNotRule"
		Me.chkNotRule.Size = New System.Drawing.Size(104, 24)
		Me.chkNotRule.TabIndex = 1
		Me.chkNotRule.Text = "Negation Rule"
		Me.chkNotRule.UseVisualStyleBackColor = true
		'
		'btnAdd
		'
		Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnAdd.Enabled = false
		Me.btnAdd.Location = New System.Drawing.Point(372, 389)
		Me.btnAdd.Name = "btnAdd"
		Me.btnAdd.Size = New System.Drawing.Size(75, 24)
		Me.btnAdd.TabIndex = 0
		Me.btnAdd.Text = "Add Rule"
		Me.btnAdd.UseVisualStyleBackColor = true
		AddHandler Me.btnAdd.Click, AddressOf Me.BtnAddClick
		'
		'btnCancel
		'
		Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Location = New System.Drawing.Point(453, 389)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(75, 24)
		Me.btnCancel.TabIndex = 1
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.UseVisualStyleBackColor = true
		'
		'lblRegistryValueType
		'
		Me.lblRegistryValueType.Location = New System.Drawing.Point(0, 0)
		Me.lblRegistryValueType.MinimumSize = Me.lblRegistryValueType.Size
		Me.lblRegistryValueType.Name = "lblRegistryValueType"
		Me.lblRegistryValueType.Size = New System.Drawing.Size(115, 23)
		Me.lblRegistryValueType.TabIndex = 44
		Me.lblRegistryValueType.Text = "Registry Value Type"
		Me.lblRegistryValueType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cboRegistryValueType
		'
		Me.cboRegistryValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboRegistryValueType.FormattingEnabled = true
		Me.cboRegistryValueType.Items.AddRange(New Object() {"REG_BINARY", "REG_DWORD", "REG_EXPAND_SZ", "REG_SZ"})
		Me.cboRegistryValueType.Location = New System.Drawing.Point(120, 0)
		Me.cboRegistryValueType.Name = "cboRegistryValueType"
		Me.cboRegistryValueType.Size = New System.Drawing.Size(185, 21)
		Me.cboRegistryValueType.TabIndex = 0
		AddHandler Me.cboRegistryValueType.SelectedIndexChanged, AddressOf Me.ValidateForm
		'
		'splitContainer
		'
		Me.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill
		Me.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
		Me.splitContainer.Location = New System.Drawing.Point(0, 0)
		Me.splitContainer.Name = "splitContainer"
		Me.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
		'
		'splitContainer.Panel1
		'
		Me.splitContainer.Panel1.Controls.Add(Me.cboRuleType)
		Me.splitContainer.Panel1.Controls.Add(Me.lblRuleType)
		Me.splitContainer.Panel1.Controls.Add(Me.chkNotRule)
		Me.splitContainer.Panel1.Controls.Add(Me.lblInfo)
		'
		'splitContainer.Panel2
		'
		Me.splitContainer.Panel2.Controls.Add(Me.pnlComponentCollection)
		Me.splitContainer.Panel2.Controls.Add(Me.pnlFeatureCollection)
		Me.splitContainer.Panel2.Controls.Add(Me.pnlProductCollection)
		Me.splitContainer.Panel2.Controls.Add(Me.pnlMinVersion)
		Me.splitContainer.Panel2.Controls.Add(Me.pnlMaxVersion)
		Me.splitContainer.Panel2.Controls.Add(Me.pnlPatchCode)
		Me.splitContainer.Panel2.Controls.Add(Me.pnlProductCode)
		Me.splitContainer.Panel2.Controls.Add(Me.pnlRegistry32Bit)
		Me.splitContainer.Panel2.Controls.Add(Me.pnlQuery)
		Me.splitContainer.Panel2.Controls.Add(Me.pnlDate)
		Me.splitContainer.Panel2.Controls.Add(Me.pnlData)
		Me.splitContainer.Panel2.Controls.Add(Me.pnlVersion)
		Me.splitContainer.Panel2.Controls.Add(Me.pnlFilePath)
		Me.splitContainer.Panel2.Controls.Add(Me.pnlEnvironmentVariable)
		Me.splitContainer.Panel2.Controls.Add(Me.pnlRegistryValueType)
		Me.splitContainer.Panel2.Controls.Add(Me.pnlRegistryValue)
		Me.splitContainer.Panel2.Controls.Add(Me.pnlRegistryKey)
		Me.splitContainer.Panel2.Controls.Add(Me.pnlProcessorType)
		Me.splitContainer.Panel2.Controls.Add(Me.pnlLanguage)
		Me.splitContainer.Panel2.Controls.Add(Me.pnlProductType)
		Me.splitContainer.Panel2.Controls.Add(Me.pnlServicePack)
		Me.splitContainer.Panel2.Controls.Add(Me.pnlOSVersion)
		Me.splitContainer.Panel2.Controls.Add(Me.pnlComparison)
		Me.splitContainer.Size = New System.Drawing.Size(565, 418)
		Me.splitContainer.TabIndex = 45
		Me.splitContainer.TabStop = false
		'
		'pnlComponentCollection
		'
		Me.pnlComponentCollection.Controls.Add(Me.gceComponentCollection)
		Me.pnlComponentCollection.Controls.Add(Me.chkComponentCollection_requireAll)
		Me.pnlComponentCollection.Controls.Add(Me.lblComponentCollection)
		Me.pnlComponentCollection.Location = New System.Drawing.Point(0, 705)
		Me.pnlComponentCollection.Name = "pnlComponentCollection"
		Me.pnlComponentCollection.Size = New System.Drawing.Size(555, 105)
		Me.pnlComponentCollection.TabIndex = 68
		Me.pnlComponentCollection.Visible = false
		'
		'gceComponentCollection
		'
		Me.gceComponentCollection.Header = "Component Codes"
		Me.gceComponentCollection.Items = CType(resources.GetObject("gceComponentCollection.Items"),System.Collections.Generic.List(Of String))
		Me.gceComponentCollection.Location = New System.Drawing.Point(121, 1)
		Me.gceComponentCollection.Name = "gceComponentCollection"
		Me.gceComponentCollection.RequireAtLeastOne = true
		Me.gceComponentCollection.RequireGuids = true
		Me.gceComponentCollection.Size = New System.Drawing.Size(320, 101)
		Me.gceComponentCollection.TabIndex = 0
		AddHandler Me.gceComponentCollection.ValidInputChanged, AddressOf Me.ValidateForm
		'
		'chkComponentCollection_requireAll
		'
		Me.chkComponentCollection_requireAll.Location = New System.Drawing.Point(453, 3)
		Me.chkComponentCollection_requireAll.Name = "chkComponentCollection_requireAll"
		Me.chkComponentCollection_requireAll.Size = New System.Drawing.Size(99, 38)
		Me.chkComponentCollection_requireAll.TabIndex = 1
		Me.chkComponentCollection_requireAll.Text = "All Components Required"
		Me.chkComponentCollection_requireAll.UseVisualStyleBackColor = true
		'
		'lblComponentCollection
		'
		Me.lblComponentCollection.Location = New System.Drawing.Point(0, 0)
		Me.lblComponentCollection.Name = "lblComponentCollection"
		Me.lblComponentCollection.Size = New System.Drawing.Size(115, 20)
		Me.lblComponentCollection.TabIndex = 13
		Me.lblComponentCollection.Text = "Components"
		Me.lblComponentCollection.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'pnlFeatureCollection
		'
		Me.pnlFeatureCollection.Controls.Add(Me.gceFeatureCollection)
		Me.pnlFeatureCollection.Controls.Add(Me.chkFeatureCollection_requireAll)
		Me.pnlFeatureCollection.Controls.Add(Me.lblFeatureCollection)
		Me.pnlFeatureCollection.Location = New System.Drawing.Point(0, 595)
		Me.pnlFeatureCollection.Name = "pnlFeatureCollection"
		Me.pnlFeatureCollection.Size = New System.Drawing.Size(555, 105)
		Me.pnlFeatureCollection.TabIndex = 67
		Me.pnlFeatureCollection.Visible = false
		'
		'gceFeatureCollection
		'
		Me.gceFeatureCollection.Header = "Feature Names"
		Me.gceFeatureCollection.Items = CType(resources.GetObject("gceFeatureCollection.Items"),System.Collections.Generic.List(Of String))
		Me.gceFeatureCollection.Location = New System.Drawing.Point(121, 1)
		Me.gceFeatureCollection.Name = "gceFeatureCollection"
		Me.gceFeatureCollection.RequireAtLeastOne = true
		Me.gceFeatureCollection.RequireGuids = false
		Me.gceFeatureCollection.Size = New System.Drawing.Size(320, 101)
		Me.gceFeatureCollection.TabIndex = 0
		AddHandler Me.gceFeatureCollection.ValidInputChanged, AddressOf Me.ValidateForm
		'
		'chkFeatureCollection_requireAll
		'
		Me.chkFeatureCollection_requireAll.Location = New System.Drawing.Point(453, 3)
		Me.chkFeatureCollection_requireAll.Name = "chkFeatureCollection_requireAll"
		Me.chkFeatureCollection_requireAll.Size = New System.Drawing.Size(99, 38)
		Me.chkFeatureCollection_requireAll.TabIndex = 1
		Me.chkFeatureCollection_requireAll.Text = "All Features Required"
		Me.chkFeatureCollection_requireAll.UseVisualStyleBackColor = true
		'
		'lblFeatureCollection
		'
		Me.lblFeatureCollection.Location = New System.Drawing.Point(0, 0)
		Me.lblFeatureCollection.Name = "lblFeatureCollection"
		Me.lblFeatureCollection.Size = New System.Drawing.Size(115, 20)
		Me.lblFeatureCollection.TabIndex = 13
		Me.lblFeatureCollection.Text = "Features"
		Me.lblFeatureCollection.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'pnlProductCollection
		'
		Me.pnlProductCollection.Controls.Add(Me.gceProductCollection)
		Me.pnlProductCollection.Controls.Add(Me.chkProductCollection_requireAll)
		Me.pnlProductCollection.Controls.Add(Me.lblProductCollection)
		Me.pnlProductCollection.Location = New System.Drawing.Point(0, 485)
		Me.pnlProductCollection.Name = "pnlProductCollection"
		Me.pnlProductCollection.Size = New System.Drawing.Size(555, 105)
		Me.pnlProductCollection.TabIndex = 66
		Me.pnlProductCollection.Visible = false
		'
		'gceProductCollection
		'
		Me.gceProductCollection.Header = "Product Codes"
		Me.gceProductCollection.Items = CType(resources.GetObject("gceProductCollection.Items"),System.Collections.Generic.List(Of String))
		Me.gceProductCollection.Location = New System.Drawing.Point(121, 1)
		Me.gceProductCollection.Name = "gceProductCollection"
		Me.gceProductCollection.RequireAtLeastOne = true
		Me.gceProductCollection.RequireGuids = true
		Me.gceProductCollection.Size = New System.Drawing.Size(320, 101)
		Me.gceProductCollection.TabIndex = 1
		AddHandler Me.gceProductCollection.ValidInputChanged, AddressOf Me.ValidateForm
		'
		'chkProductCollection_requireAll
		'
		Me.chkProductCollection_requireAll.Location = New System.Drawing.Point(453, 3)
		Me.chkProductCollection_requireAll.Name = "chkProductCollection_requireAll"
		Me.chkProductCollection_requireAll.Size = New System.Drawing.Size(99, 38)
		Me.chkProductCollection_requireAll.TabIndex = 2
		Me.chkProductCollection_requireAll.Text = "All Products Required"
		Me.chkProductCollection_requireAll.UseVisualStyleBackColor = true
		'
		'lblProductCollection
		'
		Me.lblProductCollection.Location = New System.Drawing.Point(0, 0)
		Me.lblProductCollection.Name = "lblProductCollection"
		Me.lblProductCollection.Size = New System.Drawing.Size(115, 20)
		Me.lblProductCollection.TabIndex = 13
		Me.lblProductCollection.Text = "Products"
		Me.lblProductCollection.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'pnlMinVersion
		'
		Me.pnlMinVersion.Controls.Add(Me.txtMinVersion)
		Me.pnlMinVersion.Controls.Add(Me.lblMinVersion)
		Me.pnlMinVersion.Location = New System.Drawing.Point(0, 460)
		Me.pnlMinVersion.Name = "pnlMinVersion"
		Me.pnlMinVersion.Size = New System.Drawing.Size(555, 21)
		Me.pnlMinVersion.TabIndex = 65
		Me.pnlMinVersion.Visible = false
		'
		'txtMinVersion
		'
		Me.txtMinVersion.Location = New System.Drawing.Point(120, 0)
		Me.txtMinVersion.Name = "txtMinVersion"
		Me.txtMinVersion.Size = New System.Drawing.Size(185, 20)
		Me.txtMinVersion.TabIndex = 0
		AddHandler Me.txtMinVersion.TextChanged, AddressOf Me.ValidateForm
		AddHandler Me.txtMinVersion.Validating, AddressOf Me.ValidateVersion
		'
		'lblMinVersion
		'
		Me.lblMinVersion.Location = New System.Drawing.Point(0, 0)
		Me.lblMinVersion.Name = "lblMinVersion"
		Me.lblMinVersion.Size = New System.Drawing.Size(115, 20)
		Me.lblMinVersion.TabIndex = 13
		Me.lblMinVersion.Text = "Minimum Version"
		Me.lblMinVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'pnlMaxVersion
		'
		Me.pnlMaxVersion.Controls.Add(Me.txtMaxVersion)
		Me.pnlMaxVersion.Controls.Add(Me.lblMaxVersion)
		Me.pnlMaxVersion.Location = New System.Drawing.Point(0, 435)
		Me.pnlMaxVersion.Name = "pnlMaxVersion"
		Me.pnlMaxVersion.Size = New System.Drawing.Size(555, 21)
		Me.pnlMaxVersion.TabIndex = 64
		Me.pnlMaxVersion.Visible = false
		'
		'txtMaxVersion
		'
		Me.txtMaxVersion.Location = New System.Drawing.Point(120, 0)
		Me.txtMaxVersion.Name = "txtMaxVersion"
		Me.txtMaxVersion.Size = New System.Drawing.Size(185, 20)
		Me.txtMaxVersion.TabIndex = 0
		AddHandler Me.txtMaxVersion.TextChanged, AddressOf Me.ValidateForm
		AddHandler Me.txtMaxVersion.Validating, AddressOf Me.ValidateVersion
		'
		'lblMaxVersion
		'
		Me.lblMaxVersion.Location = New System.Drawing.Point(0, 0)
		Me.lblMaxVersion.Name = "lblMaxVersion"
		Me.lblMaxVersion.Size = New System.Drawing.Size(115, 20)
		Me.lblMaxVersion.TabIndex = 13
		Me.lblMaxVersion.Text = "Maximum Version"
		Me.lblMaxVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'pnlPatchCode
		'
		Me.pnlPatchCode.Controls.Add(Me.txtPatchCode)
		Me.pnlPatchCode.Controls.Add(Me.lblPatchCode)
		Me.pnlPatchCode.Location = New System.Drawing.Point(0, 410)
		Me.pnlPatchCode.Name = "pnlPatchCode"
		Me.pnlPatchCode.Size = New System.Drawing.Size(555, 21)
		Me.pnlPatchCode.TabIndex = 63
		Me.pnlPatchCode.Visible = false
		'
		'txtPatchCode
		'
		Me.txtPatchCode.AcceptsReturn = true
		Me.txtPatchCode.AcceptsTab = true
		Me.txtPatchCode.Location = New System.Drawing.Point(120, 0)
		Me.txtPatchCode.Multiline = true
		Me.txtPatchCode.Name = "txtPatchCode"
		Me.txtPatchCode.Size = New System.Drawing.Size(234, 20)
		Me.txtPatchCode.TabIndex = 0
		AddHandler Me.txtPatchCode.TextChanged, AddressOf Me.ValidateForm
		'
		'lblPatchCode
		'
		Me.lblPatchCode.Location = New System.Drawing.Point(0, 0)
		Me.lblPatchCode.Name = "lblPatchCode"
		Me.lblPatchCode.Size = New System.Drawing.Size(115, 20)
		Me.lblPatchCode.TabIndex = 34
		Me.lblPatchCode.Text = "Patch Code"
		Me.lblPatchCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'pnlProductCode
		'
		Me.pnlProductCode.Controls.Add(Me.txtProductCode)
		Me.pnlProductCode.Controls.Add(Me.lblProductCode)
		Me.pnlProductCode.Location = New System.Drawing.Point(0, 385)
		Me.pnlProductCode.Name = "pnlProductCode"
		Me.pnlProductCode.Size = New System.Drawing.Size(555, 21)
		Me.pnlProductCode.TabIndex = 62
		Me.pnlProductCode.Visible = false
		'
		'txtProductCode
		'
		Me.txtProductCode.AcceptsReturn = true
		Me.txtProductCode.AcceptsTab = true
		Me.txtProductCode.Location = New System.Drawing.Point(120, 0)
		Me.txtProductCode.Multiline = true
		Me.txtProductCode.Name = "txtProductCode"
		Me.txtProductCode.Size = New System.Drawing.Size(234, 20)
		Me.txtProductCode.TabIndex = 0
		AddHandler Me.txtProductCode.TextChanged, AddressOf Me.ValidateForm
		'
		'lblProductCode
		'
		Me.lblProductCode.Location = New System.Drawing.Point(0, 0)
		Me.lblProductCode.Name = "lblProductCode"
		Me.lblProductCode.Size = New System.Drawing.Size(115, 20)
		Me.lblProductCode.TabIndex = 34
		Me.lblProductCode.Text = "Product Code"
		Me.lblProductCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'pnlRegistry32Bit
		'
		Me.pnlRegistry32Bit.Controls.Add(Me.chkRegistry32Bit)
		Me.pnlRegistry32Bit.Location = New System.Drawing.Point(345, 185)
		Me.pnlRegistry32Bit.Name = "pnlRegistry32Bit"
		Me.pnlRegistry32Bit.Size = New System.Drawing.Size(210, 21)
		Me.pnlRegistry32Bit.TabIndex = 60
		Me.pnlRegistry32Bit.Visible = false
		'
		'pnlQuery
		'
		Me.pnlQuery.Controls.Add(Me.txtQuery)
		Me.pnlQuery.Controls.Add(Me.lblQuery)
		Me.pnlQuery.Location = New System.Drawing.Point(0, 360)
		Me.pnlQuery.Name = "pnlQuery"
		Me.pnlQuery.Size = New System.Drawing.Size(555, 21)
		Me.pnlQuery.TabIndex = 59
		Me.pnlQuery.Visible = false
		'
		'pnlDate
		'
		Me.pnlDate.Controls.Add(Me.dtpDate)
		Me.pnlDate.Controls.Add(Me.lblDate)
		Me.pnlDate.Location = New System.Drawing.Point(0, 335)
		Me.pnlDate.Name = "pnlDate"
		Me.pnlDate.Size = New System.Drawing.Size(555, 21)
		Me.pnlDate.TabIndex = 58
		Me.pnlDate.Visible = false
		'
		'pnlData
		'
		Me.pnlData.Controls.Add(Me.txtData)
		Me.pnlData.Controls.Add(Me.lblData)
		Me.pnlData.Controls.Add(Me.lblDataInfo)
		Me.pnlData.Location = New System.Drawing.Point(0, 310)
		Me.pnlData.Name = "pnlData"
		Me.pnlData.Size = New System.Drawing.Size(555, 21)
		Me.pnlData.TabIndex = 57
		Me.pnlData.Visible = false
		'
		'pnlVersion
		'
		Me.pnlVersion.Controls.Add(Me.txtVersion)
		Me.pnlVersion.Controls.Add(Me.lblVersion)
		Me.pnlVersion.Location = New System.Drawing.Point(0, 285)
		Me.pnlVersion.Name = "pnlVersion"
		Me.pnlVersion.Size = New System.Drawing.Size(555, 21)
		Me.pnlVersion.TabIndex = 56
		Me.pnlVersion.Visible = false
		'
		'pnlFilePath
		'
		Me.pnlFilePath.Controls.Add(Me.txtFilePath)
		Me.pnlFilePath.Controls.Add(Me.lblFilePath)
		Me.pnlFilePath.Location = New System.Drawing.Point(0, 260)
		Me.pnlFilePath.Name = "pnlFilePath"
		Me.pnlFilePath.Size = New System.Drawing.Size(555, 21)
		Me.pnlFilePath.TabIndex = 55
		Me.pnlFilePath.Visible = false
		'
		'pnlEnvironmentVariable
		'
		Me.pnlEnvironmentVariable.Controls.Add(Me.cboEnvironmentVariable)
		Me.pnlEnvironmentVariable.Controls.Add(Me.lblEnvironmentVariable)
		Me.pnlEnvironmentVariable.Location = New System.Drawing.Point(0, 235)
		Me.pnlEnvironmentVariable.Name = "pnlEnvironmentVariable"
		Me.pnlEnvironmentVariable.Size = New System.Drawing.Size(555, 21)
		Me.pnlEnvironmentVariable.TabIndex = 54
		Me.pnlEnvironmentVariable.Visible = false
		'
		'pnlRegistryValueType
		'
		Me.pnlRegistryValueType.Controls.Add(Me.cboRegistryValueType)
		Me.pnlRegistryValueType.Controls.Add(Me.lblRegistryValueType)
		Me.pnlRegistryValueType.Location = New System.Drawing.Point(0, 210)
		Me.pnlRegistryValueType.Name = "pnlRegistryValueType"
		Me.pnlRegistryValueType.Size = New System.Drawing.Size(555, 21)
		Me.pnlRegistryValueType.TabIndex = 53
		Me.pnlRegistryValueType.Visible = false
		'
		'pnlRegistryValue
		'
		Me.pnlRegistryValue.Controls.Add(Me.lblRegistryValue)
		Me.pnlRegistryValue.Controls.Add(Me.txtRegistryValue)
		Me.pnlRegistryValue.Location = New System.Drawing.Point(0, 185)
		Me.pnlRegistryValue.Name = "pnlRegistryValue"
		Me.pnlRegistryValue.Size = New System.Drawing.Size(340, 21)
		Me.pnlRegistryValue.TabIndex = 52
		Me.pnlRegistryValue.Visible = false
		'
		'pnlRegistryKey
		'
		Me.pnlRegistryKey.Controls.Add(Me.txtRegistrySubKey)
		Me.pnlRegistryKey.Controls.Add(Me.lblRegistryKey)
		Me.pnlRegistryKey.Controls.Add(Me.cboRegistryKey)
		Me.pnlRegistryKey.Location = New System.Drawing.Point(0, 160)
		Me.pnlRegistryKey.Name = "pnlRegistryKey"
		Me.pnlRegistryKey.Size = New System.Drawing.Size(555, 21)
		Me.pnlRegistryKey.TabIndex = 51
		Me.pnlRegistryKey.Visible = false
		'
		'pnlProcessorType
		'
		Me.pnlProcessorType.Controls.Add(Me.cboProcessorType)
		Me.pnlProcessorType.Controls.Add(Me.lblProcessorType)
		Me.pnlProcessorType.Location = New System.Drawing.Point(0, 135)
		Me.pnlProcessorType.Name = "pnlProcessorType"
		Me.pnlProcessorType.Size = New System.Drawing.Size(555, 21)
		Me.pnlProcessorType.TabIndex = 50
		Me.pnlProcessorType.Visible = false
		'
		'pnlLanguage
		'
		Me.pnlLanguage.Controls.Add(Me.cboLanguage)
		Me.pnlLanguage.Controls.Add(Me.lblLanguage)
		Me.pnlLanguage.Location = New System.Drawing.Point(0, 110)
		Me.pnlLanguage.Name = "pnlLanguage"
		Me.pnlLanguage.Size = New System.Drawing.Size(555, 21)
		Me.pnlLanguage.TabIndex = 49
		Me.pnlLanguage.Visible = false
		'
		'pnlProductType
		'
		Me.pnlProductType.Controls.Add(Me.cboProductType)
		Me.pnlProductType.Controls.Add(Me.lblProductType)
		Me.pnlProductType.Location = New System.Drawing.Point(0, 85)
		Me.pnlProductType.Name = "pnlProductType"
		Me.pnlProductType.Size = New System.Drawing.Size(555, 21)
		Me.pnlProductType.TabIndex = 48
		Me.pnlProductType.Visible = false
		'
		'pnlServicePack
		'
		Me.pnlServicePack.Controls.Add(Me.txtSPMinorVersion)
		Me.pnlServicePack.Controls.Add(Me.txtSPMajorVersion)
		Me.pnlServicePack.Controls.Add(Me.cboServicePack)
		Me.pnlServicePack.Controls.Add(Me.lblServicePack)
		Me.pnlServicePack.Location = New System.Drawing.Point(0, 60)
		Me.pnlServicePack.Name = "pnlServicePack"
		Me.pnlServicePack.Size = New System.Drawing.Size(555, 21)
		Me.pnlServicePack.TabIndex = 47
		Me.pnlServicePack.Visible = false
		'
		'pnlOSVersion
		'
		Me.pnlOSVersion.Controls.Add(Me.txtOSMinorVersion)
		Me.pnlOSVersion.Controls.Add(Me.txtOSMajorVersion)
		Me.pnlOSVersion.Controls.Add(Me.cboOSVersion)
		Me.pnlOSVersion.Controls.Add(Me.lbl_OSVersion)
		Me.pnlOSVersion.Location = New System.Drawing.Point(0, 35)
		Me.pnlOSVersion.Name = "pnlOSVersion"
		Me.pnlOSVersion.Size = New System.Drawing.Size(555, 21)
		Me.pnlOSVersion.TabIndex = 46
		Me.pnlOSVersion.Visible = false
		'
		'pnlComparison
		'
		Me.pnlComparison.BackColor = System.Drawing.SystemColors.Control
		Me.pnlComparison.Controls.Add(Me.cboComparison)
		Me.pnlComparison.Controls.Add(Me.lblComparison)
		Me.pnlComparison.ForeColor = System.Drawing.SystemColors.ControlText
		Me.pnlComparison.Location = New System.Drawing.Point(0, 10)
		Me.pnlComparison.Name = "pnlComparison"
		Me.pnlComparison.Size = New System.Drawing.Size(555, 21)
		Me.pnlComparison.TabIndex = 45
		Me.pnlComparison.Visible = false
		'
		'errorProviderRules
		'
		Me.errorProviderRules.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
		Me.errorProviderRules.ContainerControl = Me
		'
		'RulesForm
		'
		Me.AcceptButton = Me.btnAdd
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.btnCancel
		Me.ClientSize = New System.Drawing.Size(565, 418)
		Me.Controls.Add(Me.btnAdd)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.splitContainer)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "RulesForm"
		Me.ShowInTaskbar = false
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "Create Install Rule"
		Me.splitContainer.Panel1.ResumeLayout(false)
		Me.splitContainer.Panel2.ResumeLayout(false)
		Me.splitContainer.ResumeLayout(false)
		Me.pnlComponentCollection.ResumeLayout(false)
		Me.pnlFeatureCollection.ResumeLayout(false)
		Me.pnlProductCollection.ResumeLayout(false)
		Me.pnlMinVersion.ResumeLayout(false)
		Me.pnlMinVersion.PerformLayout
		Me.pnlMaxVersion.ResumeLayout(false)
		Me.pnlMaxVersion.PerformLayout
		Me.pnlPatchCode.ResumeLayout(false)
		Me.pnlPatchCode.PerformLayout
		Me.pnlProductCode.ResumeLayout(false)
		Me.pnlProductCode.PerformLayout
		Me.pnlRegistry32Bit.ResumeLayout(false)
		Me.pnlQuery.ResumeLayout(false)
		Me.pnlQuery.PerformLayout
		Me.pnlDate.ResumeLayout(false)
		Me.pnlData.ResumeLayout(false)
		Me.pnlData.PerformLayout
		Me.pnlVersion.ResumeLayout(false)
		Me.pnlVersion.PerformLayout
		Me.pnlFilePath.ResumeLayout(false)
		Me.pnlFilePath.PerformLayout
		Me.pnlEnvironmentVariable.ResumeLayout(false)
		Me.pnlRegistryValueType.ResumeLayout(false)
		Me.pnlRegistryValue.ResumeLayout(false)
		Me.pnlRegistryValue.PerformLayout
		Me.pnlRegistryKey.ResumeLayout(false)
		Me.pnlRegistryKey.PerformLayout
		Me.pnlProcessorType.ResumeLayout(false)
		Me.pnlLanguage.ResumeLayout(false)
		Me.pnlProductType.ResumeLayout(false)
		Me.pnlServicePack.ResumeLayout(false)
		Me.pnlServicePack.PerformLayout
		Me.pnlOSVersion.ResumeLayout(false)
		Me.pnlOSVersion.PerformLayout
		Me.pnlComparison.ResumeLayout(false)
		CType(Me.errorProviderRules,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
	End Sub
	Private errorProviderRules As System.Windows.Forms.ErrorProvider
	Private chkComponentCollection_requireAll As System.Windows.Forms.CheckBox
	Private lblComponentCollection As System.Windows.Forms.Label
	Private chkFeatureCollection_requireAll As System.Windows.Forms.CheckBox
	Private lblFeatureCollection As System.Windows.Forms.Label
	Private pnlProductCollection As System.Windows.Forms.Panel
	Private pnlMinVersion As System.Windows.Forms.Panel
	Private gceFeatureCollection As LocalUpdatePublisher.GuidCollectionEditor
	Private pnlFeatureCollection As System.Windows.Forms.Panel
	Private gceComponentCollection As LocalUpdatePublisher.GuidCollectionEditor
	Private pnlComponentCollection As System.Windows.Forms.Panel
	Private gceProductCollection As LocalUpdatePublisher.GuidCollectionEditor
	Private lblProductCode As System.Windows.Forms.Label
	Private txtProductCode As System.Windows.Forms.TextBox
	Private pnlProductCode As System.Windows.Forms.Panel
	Private lblPatchCode As System.Windows.Forms.Label
	Private txtPatchCode As System.Windows.Forms.TextBox
	Private pnlPatchCode As System.Windows.Forms.Panel
	Private lblMaxVersion As System.Windows.Forms.Label
	Private txtMaxVersion As System.Windows.Forms.TextBox
	Private pnlMaxVersion As System.Windows.Forms.Panel
	Private lblMinVersion As System.Windows.Forms.Label
	Private txtMinVersion As System.Windows.Forms.TextBox
	Private lblProductCollection As System.Windows.Forms.Label
	Private chkProductCollection_requireAll As System.Windows.Forms.CheckBox
	Private cboProductType As System.Windows.Forms.ComboBox
	Private cboRegistryKey As System.Windows.Forms.ComboBox
	Private cboEnvironmentVariable As System.Windows.Forms.ComboBox
	Private cboRuleType As System.Windows.Forms.ComboBox
	Private cboServicePack As System.Windows.Forms.ComboBox
	Private cboOSVersion As System.Windows.Forms.ComboBox
	Private cboComparison As System.Windows.Forms.ComboBox
	Private cboProcessorType As System.Windows.Forms.ComboBox
	Private cboLanguage As System.Windows.Forms.ComboBox
	Private cboRegistryValueType As System.Windows.Forms.ComboBox
	Private pnlRegistry32Bit As System.Windows.Forms.Panel
	Private splitContainer As System.Windows.Forms.SplitContainer
	Private lblRegistryValueType As System.Windows.Forms.Label
	Private pnlRegistryValueType As System.Windows.Forms.Panel
	Private lblProcessorType As System.Windows.Forms.Label
	Private pnlProcessorType As System.Windows.Forms.Panel
	Private lblLanguage As System.Windows.Forms.Label
	Private pnlLanguage As System.Windows.Forms.Panel
	Private lblVersion As System.Windows.Forms.Label
	Private txtVersion As System.Windows.Forms.TextBox
	Private pnlVersion As System.Windows.Forms.Panel
	Private txtSPMajorVersion As System.Windows.Forms.TextBox
	Private txtSPMinorVersion As System.Windows.Forms.TextBox
	Private pnlServicePack As System.Windows.Forms.Panel
	Private txtOSMinorVersion As System.Windows.Forms.TextBox
	Private txtOSMajorVersion As System.Windows.Forms.TextBox
	Private pnlOSVersion As System.Windows.Forms.Panel
	Private lblServicePack As System.Windows.Forms.Label
	Private lbl_OSVersion As System.Windows.Forms.Label
	Private lblComparison As System.Windows.Forms.Label
	Private pnlComparison As System.Windows.Forms.Panel
	Private lblEnvironmentVariable As System.Windows.Forms.Label
	Private pnlEnvironmentVariable As System.Windows.Forms.Panel
	Private txtQuery As System.Windows.Forms.TextBox
	Private lblQuery As System.Windows.Forms.Label
	Private pnlQuery As System.Windows.Forms.Panel
	Private lblProductType As System.Windows.Forms.Label
	Private txtRegistryValue As System.Windows.Forms.TextBox
	Private lblRegistryValue As System.Windows.Forms.Label
	Private pnlRegistryValue As System.Windows.Forms.Panel
	Private chkRegistry32Bit As System.Windows.Forms.CheckBox
	Private txtRegistrySubKey As System.Windows.Forms.TextBox
	Private lblRegistryKey As System.Windows.Forms.Label
	Private pnlRegistryKey As System.Windows.Forms.Panel
	Private txtFilePath As System.Windows.Forms.TextBox
	Private lblFilePath As System.Windows.Forms.Label
	Private pnlFilePath As System.Windows.Forms.Panel
	Private dtpDate As System.Windows.Forms.DateTimePicker
	Private lblDate As System.Windows.Forms.Label
	Private pnlDate As System.Windows.Forms.Panel
	Private lblDataInfo As System.Windows.Forms.Label
	Private txtData As System.Windows.Forms.TextBox
	Private lblData As System.Windows.Forms.Label
	Private pnlData As System.Windows.Forms.Panel
	Private btnCancel As System.Windows.Forms.Button
	Private btnAdd As System.Windows.Forms.Button
	Private chkNotRule As System.Windows.Forms.CheckBox
	Private lblRuleType As System.Windows.Forms.Label
	Private lblInfo As System.Windows.Forms.Label
	Private pnlProductType As System.Windows.Forms.Panel
	
End Class
