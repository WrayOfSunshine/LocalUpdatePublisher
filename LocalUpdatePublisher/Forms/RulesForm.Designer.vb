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
		'cboRuleType
		'
		Me.cboRuleType.AccessibleDescription = Nothing
		Me.cboRuleType.AccessibleName = Nothing
		resources.ApplyResources(Me.cboRuleType, "cboRuleType")
		Me.cboRuleType.BackgroundImage = Nothing
		Me.cboRuleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.errorProviderRules.SetError(Me.cboRuleType, resources.GetString("cboRuleType.Error"))
		Me.cboRuleType.Font = Nothing
		Me.cboRuleType.FormattingEnabled = true
		Me.errorProviderRules.SetIconAlignment(Me.cboRuleType, CType(resources.GetObject("cboRuleType.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.cboRuleType, CType(resources.GetObject("cboRuleType.IconPadding"),Integer))
		Me.cboRuleType.Name = "cboRuleType"
		AddHandler Me.cboRuleType.SelectedIndexChanged, AddressOf Me.cboRuleTypeSelectedIndexChanged
		AddHandler Me.cboRuleType.Format, AddressOf Me.CboRuleTypeFormat
		'
		'lblRuleType
		'
		Me.lblRuleType.AccessibleDescription = Nothing
		Me.lblRuleType.AccessibleName = Nothing
		resources.ApplyResources(Me.lblRuleType, "lblRuleType")
		Me.errorProviderRules.SetError(Me.lblRuleType, resources.GetString("lblRuleType.Error"))
		Me.lblRuleType.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.lblRuleType, CType(resources.GetObject("lblRuleType.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.lblRuleType, CType(resources.GetObject("lblRuleType.IconPadding"),Integer))
		Me.lblRuleType.Name = "lblRuleType"
		'
		'lblProductType
		'
		Me.lblProductType.AccessibleDescription = Nothing
		Me.lblProductType.AccessibleName = Nothing
		resources.ApplyResources(Me.lblProductType, "lblProductType")
		Me.errorProviderRules.SetError(Me.lblProductType, resources.GetString("lblProductType.Error"))
		Me.lblProductType.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.lblProductType, CType(resources.GetObject("lblProductType.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.lblProductType, CType(resources.GetObject("lblProductType.IconPadding"),Integer))
		Me.lblProductType.Name = "lblProductType"
		'
		'cboProductType
		'
		Me.cboProductType.AccessibleDescription = Nothing
		Me.cboProductType.AccessibleName = Nothing
		resources.ApplyResources(Me.cboProductType, "cboProductType")
		Me.cboProductType.BackgroundImage = Nothing
		Me.cboProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.errorProviderRules.SetError(Me.cboProductType, resources.GetString("cboProductType.Error"))
		Me.cboProductType.Font = Nothing
		Me.cboProductType.FormattingEnabled = true
		Me.errorProviderRules.SetIconAlignment(Me.cboProductType, CType(resources.GetObject("cboProductType.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.cboProductType, CType(resources.GetObject("cboProductType.IconPadding"),Integer))
		Me.cboProductType.Name = "cboProductType"
		'
		'txtSPMinorVersion
		'
		Me.txtSPMinorVersion.AccessibleDescription = Nothing
		Me.txtSPMinorVersion.AccessibleName = Nothing
		resources.ApplyResources(Me.txtSPMinorVersion, "txtSPMinorVersion")
		Me.txtSPMinorVersion.BackgroundImage = Nothing
		Me.errorProviderRules.SetError(Me.txtSPMinorVersion, resources.GetString("txtSPMinorVersion.Error"))
		Me.txtSPMinorVersion.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.txtSPMinorVersion, CType(resources.GetObject("txtSPMinorVersion.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.txtSPMinorVersion, CType(resources.GetObject("txtSPMinorVersion.IconPadding"),Integer))
		Me.txtSPMinorVersion.Name = "txtSPMinorVersion"
		'
		'txtSPMajorVersion
		'
		Me.txtSPMajorVersion.AccessibleDescription = Nothing
		Me.txtSPMajorVersion.AccessibleName = Nothing
		resources.ApplyResources(Me.txtSPMajorVersion, "txtSPMajorVersion")
		Me.txtSPMajorVersion.BackgroundImage = Nothing
		Me.errorProviderRules.SetError(Me.txtSPMajorVersion, resources.GetString("txtSPMajorVersion.Error"))
		Me.txtSPMajorVersion.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.txtSPMajorVersion, CType(resources.GetObject("txtSPMajorVersion.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.txtSPMajorVersion, CType(resources.GetObject("txtSPMajorVersion.IconPadding"),Integer))
		Me.txtSPMajorVersion.Name = "txtSPMajorVersion"
		'
		'txtOSMinorVersion
		'
		Me.txtOSMinorVersion.AccessibleDescription = Nothing
		Me.txtOSMinorVersion.AccessibleName = Nothing
		resources.ApplyResources(Me.txtOSMinorVersion, "txtOSMinorVersion")
		Me.txtOSMinorVersion.BackgroundImage = Nothing
		Me.errorProviderRules.SetError(Me.txtOSMinorVersion, resources.GetString("txtOSMinorVersion.Error"))
		Me.txtOSMinorVersion.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.txtOSMinorVersion, CType(resources.GetObject("txtOSMinorVersion.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.txtOSMinorVersion, CType(resources.GetObject("txtOSMinorVersion.IconPadding"),Integer))
		Me.txtOSMinorVersion.Name = "txtOSMinorVersion"
		AddHandler Me.txtOSMinorVersion.TextChanged, AddressOf Me.ValidateForm
		'
		'txtOSMajorVersion
		'
		Me.txtOSMajorVersion.AccessibleDescription = Nothing
		Me.txtOSMajorVersion.AccessibleName = Nothing
		resources.ApplyResources(Me.txtOSMajorVersion, "txtOSMajorVersion")
		Me.txtOSMajorVersion.BackgroundImage = Nothing
		Me.errorProviderRules.SetError(Me.txtOSMajorVersion, resources.GetString("txtOSMajorVersion.Error"))
		Me.txtOSMajorVersion.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.txtOSMajorVersion, CType(resources.GetObject("txtOSMajorVersion.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.txtOSMajorVersion, CType(resources.GetObject("txtOSMajorVersion.IconPadding"),Integer))
		Me.txtOSMajorVersion.Name = "txtOSMajorVersion"
		AddHandler Me.txtOSMajorVersion.TextChanged, AddressOf Me.ValidateForm
		'
		'lblServicePack
		'
		Me.lblServicePack.AccessibleDescription = Nothing
		Me.lblServicePack.AccessibleName = Nothing
		resources.ApplyResources(Me.lblServicePack, "lblServicePack")
		Me.errorProviderRules.SetError(Me.lblServicePack, resources.GetString("lblServicePack.Error"))
		Me.lblServicePack.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.lblServicePack, CType(resources.GetObject("lblServicePack.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.lblServicePack, CType(resources.GetObject("lblServicePack.IconPadding"),Integer))
		Me.lblServicePack.Name = "lblServicePack"
		'
		'cboServicePack
		'
		Me.cboServicePack.AccessibleDescription = Nothing
		Me.cboServicePack.AccessibleName = Nothing
		resources.ApplyResources(Me.cboServicePack, "cboServicePack")
		Me.cboServicePack.BackgroundImage = Nothing
		Me.cboServicePack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.errorProviderRules.SetError(Me.cboServicePack, resources.GetString("cboServicePack.Error"))
		Me.cboServicePack.Font = Nothing
		Me.cboServicePack.FormattingEnabled = true
		Me.errorProviderRules.SetIconAlignment(Me.cboServicePack, CType(resources.GetObject("cboServicePack.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.cboServicePack, CType(resources.GetObject("cboServicePack.IconPadding"),Integer))
		Me.cboServicePack.Items.AddRange(New Object() {resources.GetString("cboServicePack.Items"), resources.GetString("cboServicePack.Items1"), resources.GetString("cboServicePack.Items2"), resources.GetString("cboServicePack.Items3")})
		Me.cboServicePack.Name = "cboServicePack"
		AddHandler Me.cboServicePack.SelectedIndexChanged, AddressOf Me.GetServicePackCode
		'
		'lbl_OSVersion
		'
		Me.lbl_OSVersion.AccessibleDescription = Nothing
		Me.lbl_OSVersion.AccessibleName = Nothing
		resources.ApplyResources(Me.lbl_OSVersion, "lbl_OSVersion")
		Me.errorProviderRules.SetError(Me.lbl_OSVersion, resources.GetString("lbl_OSVersion.Error"))
		Me.lbl_OSVersion.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.lbl_OSVersion, CType(resources.GetObject("lbl_OSVersion.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.lbl_OSVersion, CType(resources.GetObject("lbl_OSVersion.IconPadding"),Integer))
		Me.lbl_OSVersion.Name = "lbl_OSVersion"
		'
		'cboOSVersion
		'
		Me.cboOSVersion.AccessibleDescription = Nothing
		Me.cboOSVersion.AccessibleName = Nothing
		resources.ApplyResources(Me.cboOSVersion, "cboOSVersion")
		Me.cboOSVersion.BackgroundImage = Nothing
		Me.cboOSVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.errorProviderRules.SetError(Me.cboOSVersion, resources.GetString("cboOSVersion.Error"))
		Me.cboOSVersion.Font = Nothing
		Me.cboOSVersion.FormattingEnabled = true
		Me.errorProviderRules.SetIconAlignment(Me.cboOSVersion, CType(resources.GetObject("cboOSVersion.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.cboOSVersion, CType(resources.GetObject("cboOSVersion.IconPadding"),Integer))
		Me.cboOSVersion.Items.AddRange(New Object() {resources.GetString("cboOSVersion.Items"), resources.GetString("cboOSVersion.Items1"), resources.GetString("cboOSVersion.Items2"), resources.GetString("cboOSVersion.Items3"), resources.GetString("cboOSVersion.Items4"), resources.GetString("cboOSVersion.Items5")})
		Me.cboOSVersion.Name = "cboOSVersion"
		AddHandler Me.cboOSVersion.SelectedIndexChanged, AddressOf Me.GetOSVersionCodes
		'
		'lblComparison
		'
		Me.lblComparison.AccessibleDescription = Nothing
		Me.lblComparison.AccessibleName = Nothing
		resources.ApplyResources(Me.lblComparison, "lblComparison")
		Me.errorProviderRules.SetError(Me.lblComparison, resources.GetString("lblComparison.Error"))
		Me.lblComparison.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.lblComparison, CType(resources.GetObject("lblComparison.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.lblComparison, CType(resources.GetObject("lblComparison.IconPadding"),Integer))
		Me.lblComparison.Name = "lblComparison"
		'
		'cboComparison
		'
		Me.cboComparison.AccessibleDescription = Nothing
		Me.cboComparison.AccessibleName = Nothing
		resources.ApplyResources(Me.cboComparison, "cboComparison")
		Me.cboComparison.BackgroundImage = Nothing
		Me.cboComparison.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.errorProviderRules.SetError(Me.cboComparison, resources.GetString("cboComparison.Error"))
		Me.cboComparison.Font = Nothing
		Me.cboComparison.FormattingEnabled = true
		Me.errorProviderRules.SetIconAlignment(Me.cboComparison, CType(resources.GetObject("cboComparison.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.cboComparison, CType(resources.GetObject("cboComparison.IconPadding"),Integer))
		Me.cboComparison.Name = "cboComparison"
		AddHandler Me.cboComparison.SelectedIndexChanged, AddressOf Me.ValidateForm
		'
		'lblLanguage
		'
		Me.lblLanguage.AccessibleDescription = Nothing
		Me.lblLanguage.AccessibleName = Nothing
		resources.ApplyResources(Me.lblLanguage, "lblLanguage")
		Me.errorProviderRules.SetError(Me.lblLanguage, resources.GetString("lblLanguage.Error"))
		Me.lblLanguage.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.lblLanguage, CType(resources.GetObject("lblLanguage.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.lblLanguage, CType(resources.GetObject("lblLanguage.IconPadding"),Integer))
		Me.lblLanguage.Name = "lblLanguage"
		'
		'cboLanguage
		'
		Me.cboLanguage.AccessibleDescription = Nothing
		Me.cboLanguage.AccessibleName = Nothing
		resources.ApplyResources(Me.cboLanguage, "cboLanguage")
		Me.cboLanguage.BackgroundImage = Nothing
		Me.cboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.errorProviderRules.SetError(Me.cboLanguage, resources.GetString("cboLanguage.Error"))
		Me.cboLanguage.Font = Nothing
		Me.cboLanguage.FormattingEnabled = true
		Me.errorProviderRules.SetIconAlignment(Me.cboLanguage, CType(resources.GetObject("cboLanguage.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.cboLanguage, CType(resources.GetObject("cboLanguage.IconPadding"),Integer))
		Me.cboLanguage.Name = "cboLanguage"
		AddHandler Me.cboLanguage.SelectedIndexChanged, AddressOf Me.ValidateForm
		'
		'lblProcessorType
		'
		Me.lblProcessorType.AccessibleDescription = Nothing
		Me.lblProcessorType.AccessibleName = Nothing
		resources.ApplyResources(Me.lblProcessorType, "lblProcessorType")
		Me.errorProviderRules.SetError(Me.lblProcessorType, resources.GetString("lblProcessorType.Error"))
		Me.lblProcessorType.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.lblProcessorType, CType(resources.GetObject("lblProcessorType.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.lblProcessorType, CType(resources.GetObject("lblProcessorType.IconPadding"),Integer))
		Me.lblProcessorType.Name = "lblProcessorType"
		'
		'cboProcessorType
		'
		Me.cboProcessorType.AccessibleDescription = Nothing
		Me.cboProcessorType.AccessibleName = Nothing
		resources.ApplyResources(Me.cboProcessorType, "cboProcessorType")
		Me.cboProcessorType.BackgroundImage = Nothing
		Me.cboProcessorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.errorProviderRules.SetError(Me.cboProcessorType, resources.GetString("cboProcessorType.Error"))
		Me.cboProcessorType.Font = Nothing
		Me.cboProcessorType.FormattingEnabled = true
		Me.errorProviderRules.SetIconAlignment(Me.cboProcessorType, CType(resources.GetObject("cboProcessorType.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.cboProcessorType, CType(resources.GetObject("cboProcessorType.IconPadding"),Integer))
		Me.cboProcessorType.Items.AddRange(New Object() {resources.GetString("cboProcessorType.Items"), resources.GetString("cboProcessorType.Items1"), resources.GetString("cboProcessorType.Items2")})
		Me.cboProcessorType.Name = "cboProcessorType"
		AddHandler Me.cboProcessorType.SelectedIndexChanged, AddressOf Me.ValidateForm
		'
		'lblEnvironmentVariable
		'
		Me.lblEnvironmentVariable.AccessibleDescription = Nothing
		Me.lblEnvironmentVariable.AccessibleName = Nothing
		resources.ApplyResources(Me.lblEnvironmentVariable, "lblEnvironmentVariable")
		Me.errorProviderRules.SetError(Me.lblEnvironmentVariable, resources.GetString("lblEnvironmentVariable.Error"))
		Me.lblEnvironmentVariable.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.lblEnvironmentVariable, CType(resources.GetObject("lblEnvironmentVariable.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.lblEnvironmentVariable, CType(resources.GetObject("lblEnvironmentVariable.IconPadding"),Integer))
		Me.lblEnvironmentVariable.Name = "lblEnvironmentVariable"
		'
		'cboEnvironmentVariable
		'
		Me.cboEnvironmentVariable.AccessibleDescription = Nothing
		Me.cboEnvironmentVariable.AccessibleName = Nothing
		resources.ApplyResources(Me.cboEnvironmentVariable, "cboEnvironmentVariable")
		Me.cboEnvironmentVariable.BackgroundImage = Nothing
		Me.cboEnvironmentVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.errorProviderRules.SetError(Me.cboEnvironmentVariable, resources.GetString("cboEnvironmentVariable.Error"))
		Me.cboEnvironmentVariable.Font = Nothing
		Me.cboEnvironmentVariable.FormattingEnabled = true
		Me.errorProviderRules.SetIconAlignment(Me.cboEnvironmentVariable, CType(resources.GetObject("cboEnvironmentVariable.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.cboEnvironmentVariable, CType(resources.GetObject("cboEnvironmentVariable.IconPadding"),Integer))
		Me.cboEnvironmentVariable.Name = "cboEnvironmentVariable"
		'
		'txtVersion
		'
		Me.txtVersion.AccessibleDescription = Nothing
		Me.txtVersion.AccessibleName = Nothing
		resources.ApplyResources(Me.txtVersion, "txtVersion")
		Me.txtVersion.BackgroundImage = Nothing
		Me.errorProviderRules.SetError(Me.txtVersion, resources.GetString("txtVersion.Error"))
		Me.txtVersion.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.txtVersion, CType(resources.GetObject("txtVersion.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.txtVersion, CType(resources.GetObject("txtVersion.IconPadding"),Integer))
		Me.txtVersion.Name = "txtVersion"
		AddHandler Me.txtVersion.TextChanged, AddressOf Me.ValidateForm
		AddHandler Me.txtVersion.Validating, AddressOf Me.ValidateVersion
		'
		'lblVersion
		'
		Me.lblVersion.AccessibleDescription = Nothing
		Me.lblVersion.AccessibleName = Nothing
		resources.ApplyResources(Me.lblVersion, "lblVersion")
		Me.errorProviderRules.SetError(Me.lblVersion, resources.GetString("lblVersion.Error"))
		Me.lblVersion.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.lblVersion, CType(resources.GetObject("lblVersion.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.lblVersion, CType(resources.GetObject("lblVersion.IconPadding"),Integer))
		Me.lblVersion.Name = "lblVersion"
		'
		'txtRegistryValue
		'
		Me.txtRegistryValue.AccessibleDescription = Nothing
		Me.txtRegistryValue.AccessibleName = Nothing
		resources.ApplyResources(Me.txtRegistryValue, "txtRegistryValue")
		Me.txtRegistryValue.BackgroundImage = Nothing
		Me.errorProviderRules.SetError(Me.txtRegistryValue, resources.GetString("txtRegistryValue.Error"))
		Me.txtRegistryValue.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.txtRegistryValue, CType(resources.GetObject("txtRegistryValue.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.txtRegistryValue, CType(resources.GetObject("txtRegistryValue.IconPadding"),Integer))
		Me.txtRegistryValue.Name = "txtRegistryValue"
		AddHandler Me.txtRegistryValue.TextChanged, AddressOf Me.ValidateForm
		'
		'lblRegistryValue
		'
		Me.lblRegistryValue.AccessibleDescription = Nothing
		Me.lblRegistryValue.AccessibleName = Nothing
		resources.ApplyResources(Me.lblRegistryValue, "lblRegistryValue")
		Me.errorProviderRules.SetError(Me.lblRegistryValue, resources.GetString("lblRegistryValue.Error"))
		Me.lblRegistryValue.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.lblRegistryValue, CType(resources.GetObject("lblRegistryValue.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.lblRegistryValue, CType(resources.GetObject("lblRegistryValue.IconPadding"),Integer))
		Me.lblRegistryValue.Name = "lblRegistryValue"
		'
		'chkRegistry32Bit
		'
		Me.chkRegistry32Bit.AccessibleDescription = Nothing
		Me.chkRegistry32Bit.AccessibleName = Nothing
		resources.ApplyResources(Me.chkRegistry32Bit, "chkRegistry32Bit")
		Me.chkRegistry32Bit.BackgroundImage = Nothing
		Me.errorProviderRules.SetError(Me.chkRegistry32Bit, resources.GetString("chkRegistry32Bit.Error"))
		Me.chkRegistry32Bit.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.chkRegistry32Bit, CType(resources.GetObject("chkRegistry32Bit.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.chkRegistry32Bit, CType(resources.GetObject("chkRegistry32Bit.IconPadding"),Integer))
		Me.chkRegistry32Bit.Name = "chkRegistry32Bit"
		Me.chkRegistry32Bit.UseVisualStyleBackColor = true
		'
		'txtRegistrySubKey
		'
		Me.txtRegistrySubKey.AccessibleDescription = Nothing
		Me.txtRegistrySubKey.AccessibleName = Nothing
		resources.ApplyResources(Me.txtRegistrySubKey, "txtRegistrySubKey")
		Me.txtRegistrySubKey.BackgroundImage = Nothing
		Me.errorProviderRules.SetError(Me.txtRegistrySubKey, resources.GetString("txtRegistrySubKey.Error"))
		Me.txtRegistrySubKey.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.txtRegistrySubKey, CType(resources.GetObject("txtRegistrySubKey.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.txtRegistrySubKey, CType(resources.GetObject("txtRegistrySubKey.IconPadding"),Integer))
		Me.txtRegistrySubKey.Name = "txtRegistrySubKey"
		AddHandler Me.txtRegistrySubKey.TextChanged, AddressOf Me.ValidateForm
		'
		'lblRegistryKey
		'
		Me.lblRegistryKey.AccessibleDescription = Nothing
		Me.lblRegistryKey.AccessibleName = Nothing
		resources.ApplyResources(Me.lblRegistryKey, "lblRegistryKey")
		Me.errorProviderRules.SetError(Me.lblRegistryKey, resources.GetString("lblRegistryKey.Error"))
		Me.lblRegistryKey.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.lblRegistryKey, CType(resources.GetObject("lblRegistryKey.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.lblRegistryKey, CType(resources.GetObject("lblRegistryKey.IconPadding"),Integer))
		Me.lblRegistryKey.Name = "lblRegistryKey"
		'
		'cboRegistryKey
		'
		Me.cboRegistryKey.AccessibleDescription = Nothing
		Me.cboRegistryKey.AccessibleName = Nothing
		resources.ApplyResources(Me.cboRegistryKey, "cboRegistryKey")
		Me.cboRegistryKey.BackgroundImage = Nothing
		Me.cboRegistryKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.errorProviderRules.SetError(Me.cboRegistryKey, resources.GetString("cboRegistryKey.Error"))
		Me.cboRegistryKey.Font = Nothing
		Me.cboRegistryKey.FormattingEnabled = true
		Me.errorProviderRules.SetIconAlignment(Me.cboRegistryKey, CType(resources.GetObject("cboRegistryKey.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.cboRegistryKey, CType(resources.GetObject("cboRegistryKey.IconPadding"),Integer))
		Me.cboRegistryKey.Items.AddRange(New Object() {resources.GetString("cboRegistryKey.Items")})
		Me.cboRegistryKey.Name = "cboRegistryKey"
		AddHandler Me.cboRegistryKey.SelectedIndexChanged, AddressOf Me.ValidateForm
		'
		'txtFilePath
		'
		Me.txtFilePath.AccessibleDescription = Nothing
		Me.txtFilePath.AccessibleName = Nothing
		resources.ApplyResources(Me.txtFilePath, "txtFilePath")
		Me.txtFilePath.BackgroundImage = Nothing
		Me.errorProviderRules.SetError(Me.txtFilePath, resources.GetString("txtFilePath.Error"))
		Me.txtFilePath.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.txtFilePath, CType(resources.GetObject("txtFilePath.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.txtFilePath, CType(resources.GetObject("txtFilePath.IconPadding"),Integer))
		Me.txtFilePath.Name = "txtFilePath"
		AddHandler Me.txtFilePath.TextChanged, AddressOf Me.ValidateForm
		'
		'lblFilePath
		'
		Me.lblFilePath.AccessibleDescription = Nothing
		Me.lblFilePath.AccessibleName = Nothing
		resources.ApplyResources(Me.lblFilePath, "lblFilePath")
		Me.errorProviderRules.SetError(Me.lblFilePath, resources.GetString("lblFilePath.Error"))
		Me.lblFilePath.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.lblFilePath, CType(resources.GetObject("lblFilePath.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.lblFilePath, CType(resources.GetObject("lblFilePath.IconPadding"),Integer))
		Me.lblFilePath.Name = "lblFilePath"
		'
		'dtpDate
		'
		Me.dtpDate.AccessibleDescription = Nothing
		Me.dtpDate.AccessibleName = Nothing
		resources.ApplyResources(Me.dtpDate, "dtpDate")
		Me.dtpDate.BackgroundImage = Nothing
		Me.dtpDate.CalendarFont = Nothing
		Me.dtpDate.Checked = false
		Me.dtpDate.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.errorProviderRules.SetError(Me.dtpDate, resources.GetString("dtpDate.Error"))
		Me.dtpDate.Font = Nothing
		Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
		Me.errorProviderRules.SetIconAlignment(Me.dtpDate, CType(resources.GetObject("dtpDate.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.dtpDate, CType(resources.GetObject("dtpDate.IconPadding"),Integer))
		Me.dtpDate.Name = "dtpDate"
		Me.dtpDate.ShowCheckBox = true
		AddHandler Me.dtpDate.ValueChanged, AddressOf Me.ValidateForm
		'
		'lblDate
		'
		Me.lblDate.AccessibleDescription = Nothing
		Me.lblDate.AccessibleName = Nothing
		resources.ApplyResources(Me.lblDate, "lblDate")
		Me.errorProviderRules.SetError(Me.lblDate, resources.GetString("lblDate.Error"))
		Me.lblDate.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.lblDate, CType(resources.GetObject("lblDate.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.lblDate, CType(resources.GetObject("lblDate.IconPadding"),Integer))
		Me.lblDate.Name = "lblDate"
		'
		'lblDataInfo
		'
		Me.lblDataInfo.AccessibleDescription = Nothing
		Me.lblDataInfo.AccessibleName = Nothing
		resources.ApplyResources(Me.lblDataInfo, "lblDataInfo")
		Me.errorProviderRules.SetError(Me.lblDataInfo, resources.GetString("lblDataInfo.Error"))
		Me.lblDataInfo.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.lblDataInfo, CType(resources.GetObject("lblDataInfo.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.lblDataInfo, CType(resources.GetObject("lblDataInfo.IconPadding"),Integer))
		Me.lblDataInfo.Name = "lblDataInfo"
		'
		'txtData
		'
		Me.txtData.AccessibleDescription = Nothing
		Me.txtData.AccessibleName = Nothing
		resources.ApplyResources(Me.txtData, "txtData")
		Me.txtData.BackgroundImage = Nothing
		Me.errorProviderRules.SetError(Me.txtData, resources.GetString("txtData.Error"))
		Me.txtData.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.txtData, CType(resources.GetObject("txtData.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.txtData, CType(resources.GetObject("txtData.IconPadding"),Integer))
		Me.txtData.Name = "txtData"
		AddHandler Me.txtData.TextChanged, AddressOf Me.ValidateForm
		'
		'lblData
		'
		Me.lblData.AccessibleDescription = Nothing
		Me.lblData.AccessibleName = Nothing
		resources.ApplyResources(Me.lblData, "lblData")
		Me.errorProviderRules.SetError(Me.lblData, resources.GetString("lblData.Error"))
		Me.lblData.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.lblData, CType(resources.GetObject("lblData.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.lblData, CType(resources.GetObject("lblData.IconPadding"),Integer))
		Me.lblData.Name = "lblData"
		'
		'txtQuery
		'
		Me.txtQuery.AcceptsReturn = true
		Me.txtQuery.AcceptsTab = true
		Me.txtQuery.AccessibleDescription = Nothing
		Me.txtQuery.AccessibleName = Nothing
		resources.ApplyResources(Me.txtQuery, "txtQuery")
		Me.txtQuery.BackgroundImage = Nothing
		Me.errorProviderRules.SetError(Me.txtQuery, resources.GetString("txtQuery.Error"))
		Me.txtQuery.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.txtQuery, CType(resources.GetObject("txtQuery.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.txtQuery, CType(resources.GetObject("txtQuery.IconPadding"),Integer))
		Me.txtQuery.Name = "txtQuery"
		AddHandler Me.txtQuery.TextChanged, AddressOf Me.ValidateForm
		'
		'lblQuery
		'
		Me.lblQuery.AccessibleDescription = Nothing
		Me.lblQuery.AccessibleName = Nothing
		resources.ApplyResources(Me.lblQuery, "lblQuery")
		Me.errorProviderRules.SetError(Me.lblQuery, resources.GetString("lblQuery.Error"))
		Me.lblQuery.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.lblQuery, CType(resources.GetObject("lblQuery.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.lblQuery, CType(resources.GetObject("lblQuery.IconPadding"),Integer))
		Me.lblQuery.Name = "lblQuery"
		'
		'chkNotRule
		'
		Me.chkNotRule.AccessibleDescription = Nothing
		Me.chkNotRule.AccessibleName = Nothing
		resources.ApplyResources(Me.chkNotRule, "chkNotRule")
		Me.chkNotRule.BackgroundImage = Nothing
		Me.errorProviderRules.SetError(Me.chkNotRule, resources.GetString("chkNotRule.Error"))
		Me.chkNotRule.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.chkNotRule, CType(resources.GetObject("chkNotRule.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.chkNotRule, CType(resources.GetObject("chkNotRule.IconPadding"),Integer))
		Me.chkNotRule.Name = "chkNotRule"
		Me.chkNotRule.UseVisualStyleBackColor = true
		'
		'btnAdd
		'
		Me.btnAdd.AccessibleDescription = Nothing
		Me.btnAdd.AccessibleName = Nothing
		resources.ApplyResources(Me.btnAdd, "btnAdd")
		Me.btnAdd.BackgroundImage = Nothing
		Me.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.errorProviderRules.SetError(Me.btnAdd, resources.GetString("btnAdd.Error"))
		Me.btnAdd.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.btnAdd, CType(resources.GetObject("btnAdd.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.btnAdd, CType(resources.GetObject("btnAdd.IconPadding"),Integer))
		Me.btnAdd.Name = "btnAdd"
		Me.btnAdd.UseVisualStyleBackColor = true
		AddHandler Me.btnAdd.Click, AddressOf Me.BtnAddClick
		'
		'btnCancel
		'
		Me.btnCancel.AccessibleDescription = Nothing
		Me.btnCancel.AccessibleName = Nothing
		resources.ApplyResources(Me.btnCancel, "btnCancel")
		Me.btnCancel.BackgroundImage = Nothing
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.errorProviderRules.SetError(Me.btnCancel, resources.GetString("btnCancel.Error"))
		Me.btnCancel.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.btnCancel, CType(resources.GetObject("btnCancel.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.btnCancel, CType(resources.GetObject("btnCancel.IconPadding"),Integer))
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.UseVisualStyleBackColor = true
		'
		'lblRegistryValueType
		'
		Me.lblRegistryValueType.AccessibleDescription = Nothing
		Me.lblRegistryValueType.AccessibleName = Nothing
		resources.ApplyResources(Me.lblRegistryValueType, "lblRegistryValueType")
		Me.errorProviderRules.SetError(Me.lblRegistryValueType, resources.GetString("lblRegistryValueType.Error"))
		Me.lblRegistryValueType.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.lblRegistryValueType, CType(resources.GetObject("lblRegistryValueType.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.lblRegistryValueType, CType(resources.GetObject("lblRegistryValueType.IconPadding"),Integer))
		Me.lblRegistryValueType.MinimumSize = Me.lblRegistryValueType.Size
		Me.lblRegistryValueType.Name = "lblRegistryValueType"
		'
		'cboRegistryValueType
		'
		Me.cboRegistryValueType.AccessibleDescription = Nothing
		Me.cboRegistryValueType.AccessibleName = Nothing
		resources.ApplyResources(Me.cboRegistryValueType, "cboRegistryValueType")
		Me.cboRegistryValueType.BackgroundImage = Nothing
		Me.cboRegistryValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.errorProviderRules.SetError(Me.cboRegistryValueType, resources.GetString("cboRegistryValueType.Error"))
		Me.cboRegistryValueType.Font = Nothing
		Me.cboRegistryValueType.FormattingEnabled = true
		Me.errorProviderRules.SetIconAlignment(Me.cboRegistryValueType, CType(resources.GetObject("cboRegistryValueType.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.cboRegistryValueType, CType(resources.GetObject("cboRegistryValueType.IconPadding"),Integer))
		Me.cboRegistryValueType.Items.AddRange(New Object() {resources.GetString("cboRegistryValueType.Items"), resources.GetString("cboRegistryValueType.Items1"), resources.GetString("cboRegistryValueType.Items2"), resources.GetString("cboRegistryValueType.Items3")})
		Me.cboRegistryValueType.Name = "cboRegistryValueType"
		AddHandler Me.cboRegistryValueType.SelectedIndexChanged, AddressOf Me.ValidateForm
		'
		'splitContainer
		'
		Me.splitContainer.AccessibleDescription = Nothing
		Me.splitContainer.AccessibleName = Nothing
		resources.ApplyResources(Me.splitContainer, "splitContainer")
		Me.splitContainer.BackgroundImage = Nothing
		Me.errorProviderRules.SetError(Me.splitContainer, resources.GetString("splitContainer.Error"))
		Me.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
		Me.splitContainer.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.splitContainer, CType(resources.GetObject("splitContainer.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.splitContainer, CType(resources.GetObject("splitContainer.IconPadding"),Integer))
		Me.splitContainer.Name = "splitContainer"
		'
		'splitContainer.Panel1
		'
		Me.splitContainer.Panel1.AccessibleDescription = Nothing
		Me.splitContainer.Panel1.AccessibleName = Nothing
		resources.ApplyResources(Me.splitContainer.Panel1, "splitContainer.Panel1")
		Me.splitContainer.Panel1.BackgroundImage = Nothing
		Me.splitContainer.Panel1.Controls.Add(Me.cboRuleType)
		Me.splitContainer.Panel1.Controls.Add(Me.lblRuleType)
		Me.splitContainer.Panel1.Controls.Add(Me.chkNotRule)
		Me.errorProviderRules.SetError(Me.splitContainer.Panel1, resources.GetString("splitContainer.Panel1.Error"))
		Me.splitContainer.Panel1.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.splitContainer.Panel1, CType(resources.GetObject("splitContainer.Panel1.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.splitContainer.Panel1, CType(resources.GetObject("splitContainer.Panel1.IconPadding"),Integer))
		'
		'splitContainer.Panel2
		'
		Me.splitContainer.Panel2.AccessibleDescription = Nothing
		Me.splitContainer.Panel2.AccessibleName = Nothing
		resources.ApplyResources(Me.splitContainer.Panel2, "splitContainer.Panel2")
		Me.splitContainer.Panel2.BackgroundImage = Nothing
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
		Me.errorProviderRules.SetError(Me.splitContainer.Panel2, resources.GetString("splitContainer.Panel2.Error"))
		Me.splitContainer.Panel2.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.splitContainer.Panel2, CType(resources.GetObject("splitContainer.Panel2.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.splitContainer.Panel2, CType(resources.GetObject("splitContainer.Panel2.IconPadding"),Integer))
		Me.splitContainer.TabStop = false
		'
		'pnlComponentCollection
		'
		Me.pnlComponentCollection.AccessibleDescription = Nothing
		Me.pnlComponentCollection.AccessibleName = Nothing
		resources.ApplyResources(Me.pnlComponentCollection, "pnlComponentCollection")
		Me.pnlComponentCollection.BackgroundImage = Nothing
		Me.pnlComponentCollection.Controls.Add(Me.gceComponentCollection)
		Me.pnlComponentCollection.Controls.Add(Me.chkComponentCollection_requireAll)
		Me.pnlComponentCollection.Controls.Add(Me.lblComponentCollection)
		Me.errorProviderRules.SetError(Me.pnlComponentCollection, resources.GetString("pnlComponentCollection.Error"))
		Me.pnlComponentCollection.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.pnlComponentCollection, CType(resources.GetObject("pnlComponentCollection.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.pnlComponentCollection, CType(resources.GetObject("pnlComponentCollection.IconPadding"),Integer))
		Me.pnlComponentCollection.Name = "pnlComponentCollection"
		'
		'gceComponentCollection
		'
		Me.gceComponentCollection.AccessibleDescription = Nothing
		Me.gceComponentCollection.AccessibleName = Nothing
		resources.ApplyResources(Me.gceComponentCollection, "gceComponentCollection")
		Me.gceComponentCollection.BackgroundImage = Nothing
		Me.errorProviderRules.SetError(Me.gceComponentCollection, resources.GetString("gceComponentCollection.Error"))
		Me.gceComponentCollection.Font = Nothing
		Me.gceComponentCollection.Header = "Codes des Appareils"
		Me.errorProviderRules.SetIconAlignment(Me.gceComponentCollection, CType(resources.GetObject("gceComponentCollection.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.gceComponentCollection, CType(resources.GetObject("gceComponentCollection.IconPadding"),Integer))
		Me.gceComponentCollection.Items = CType(resources.GetObject("gceComponentCollection.Items"),System.Collections.Generic.List(Of String))
		Me.gceComponentCollection.Name = "gceComponentCollection"
		Me.gceComponentCollection.RequireAtLeastOne = true
		Me.gceComponentCollection.RequireGuids = true
		AddHandler Me.gceComponentCollection.ValidInputChanged, AddressOf Me.ValidateForm
		'
		'chkComponentCollection_requireAll
		'
		Me.chkComponentCollection_requireAll.AccessibleDescription = Nothing
		Me.chkComponentCollection_requireAll.AccessibleName = Nothing
		resources.ApplyResources(Me.chkComponentCollection_requireAll, "chkComponentCollection_requireAll")
		Me.chkComponentCollection_requireAll.BackgroundImage = Nothing
		Me.errorProviderRules.SetError(Me.chkComponentCollection_requireAll, resources.GetString("chkComponentCollection_requireAll.Error"))
		Me.chkComponentCollection_requireAll.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.chkComponentCollection_requireAll, CType(resources.GetObject("chkComponentCollection_requireAll.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.chkComponentCollection_requireAll, CType(resources.GetObject("chkComponentCollection_requireAll.IconPadding"),Integer))
		Me.chkComponentCollection_requireAll.Name = "chkComponentCollection_requireAll"
		Me.chkComponentCollection_requireAll.UseVisualStyleBackColor = true
		'
		'lblComponentCollection
		'
		Me.lblComponentCollection.AccessibleDescription = Nothing
		Me.lblComponentCollection.AccessibleName = Nothing
		resources.ApplyResources(Me.lblComponentCollection, "lblComponentCollection")
		Me.errorProviderRules.SetError(Me.lblComponentCollection, resources.GetString("lblComponentCollection.Error"))
		Me.lblComponentCollection.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.lblComponentCollection, CType(resources.GetObject("lblComponentCollection.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.lblComponentCollection, CType(resources.GetObject("lblComponentCollection.IconPadding"),Integer))
		Me.lblComponentCollection.Name = "lblComponentCollection"
		'
		'pnlFeatureCollection
		'
		Me.pnlFeatureCollection.AccessibleDescription = Nothing
		Me.pnlFeatureCollection.AccessibleName = Nothing
		resources.ApplyResources(Me.pnlFeatureCollection, "pnlFeatureCollection")
		Me.pnlFeatureCollection.BackgroundImage = Nothing
		Me.pnlFeatureCollection.Controls.Add(Me.gceFeatureCollection)
		Me.pnlFeatureCollection.Controls.Add(Me.chkFeatureCollection_requireAll)
		Me.pnlFeatureCollection.Controls.Add(Me.lblFeatureCollection)
		Me.errorProviderRules.SetError(Me.pnlFeatureCollection, resources.GetString("pnlFeatureCollection.Error"))
		Me.pnlFeatureCollection.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.pnlFeatureCollection, CType(resources.GetObject("pnlFeatureCollection.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.pnlFeatureCollection, CType(resources.GetObject("pnlFeatureCollection.IconPadding"),Integer))
		Me.pnlFeatureCollection.Name = "pnlFeatureCollection"
		'
		'gceFeatureCollection
		'
		Me.gceFeatureCollection.AccessibleDescription = Nothing
		Me.gceFeatureCollection.AccessibleName = Nothing
		resources.ApplyResources(Me.gceFeatureCollection, "gceFeatureCollection")
		Me.gceFeatureCollection.BackgroundImage = Nothing
		Me.errorProviderRules.SetError(Me.gceFeatureCollection, resources.GetString("gceFeatureCollection.Error"))
		Me.gceFeatureCollection.Font = Nothing
		Me.gceFeatureCollection.Header = "Nom de l'Entité"
		Me.errorProviderRules.SetIconAlignment(Me.gceFeatureCollection, CType(resources.GetObject("gceFeatureCollection.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.gceFeatureCollection, CType(resources.GetObject("gceFeatureCollection.IconPadding"),Integer))
		Me.gceFeatureCollection.Items = CType(resources.GetObject("gceFeatureCollection.Items"),System.Collections.Generic.List(Of String))
		Me.gceFeatureCollection.Name = "gceFeatureCollection"
		Me.gceFeatureCollection.RequireAtLeastOne = true
		Me.gceFeatureCollection.RequireGuids = false
		AddHandler Me.gceFeatureCollection.ValidInputChanged, AddressOf Me.ValidateForm
		'
		'chkFeatureCollection_requireAll
		'
		Me.chkFeatureCollection_requireAll.AccessibleDescription = Nothing
		Me.chkFeatureCollection_requireAll.AccessibleName = Nothing
		resources.ApplyResources(Me.chkFeatureCollection_requireAll, "chkFeatureCollection_requireAll")
		Me.chkFeatureCollection_requireAll.BackgroundImage = Nothing
		Me.errorProviderRules.SetError(Me.chkFeatureCollection_requireAll, resources.GetString("chkFeatureCollection_requireAll.Error"))
		Me.chkFeatureCollection_requireAll.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.chkFeatureCollection_requireAll, CType(resources.GetObject("chkFeatureCollection_requireAll.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.chkFeatureCollection_requireAll, CType(resources.GetObject("chkFeatureCollection_requireAll.IconPadding"),Integer))
		Me.chkFeatureCollection_requireAll.Name = "chkFeatureCollection_requireAll"
		Me.chkFeatureCollection_requireAll.UseVisualStyleBackColor = true
		'
		'lblFeatureCollection
		'
		Me.lblFeatureCollection.AccessibleDescription = Nothing
		Me.lblFeatureCollection.AccessibleName = Nothing
		resources.ApplyResources(Me.lblFeatureCollection, "lblFeatureCollection")
		Me.errorProviderRules.SetError(Me.lblFeatureCollection, resources.GetString("lblFeatureCollection.Error"))
		Me.lblFeatureCollection.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.lblFeatureCollection, CType(resources.GetObject("lblFeatureCollection.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.lblFeatureCollection, CType(resources.GetObject("lblFeatureCollection.IconPadding"),Integer))
		Me.lblFeatureCollection.Name = "lblFeatureCollection"
		'
		'pnlProductCollection
		'
		Me.pnlProductCollection.AccessibleDescription = Nothing
		Me.pnlProductCollection.AccessibleName = Nothing
		resources.ApplyResources(Me.pnlProductCollection, "pnlProductCollection")
		Me.pnlProductCollection.BackgroundImage = Nothing
		Me.pnlProductCollection.Controls.Add(Me.gceProductCollection)
		Me.pnlProductCollection.Controls.Add(Me.chkProductCollection_requireAll)
		Me.pnlProductCollection.Controls.Add(Me.lblProductCollection)
		Me.errorProviderRules.SetError(Me.pnlProductCollection, resources.GetString("pnlProductCollection.Error"))
		Me.pnlProductCollection.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.pnlProductCollection, CType(resources.GetObject("pnlProductCollection.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.pnlProductCollection, CType(resources.GetObject("pnlProductCollection.IconPadding"),Integer))
		Me.pnlProductCollection.Name = "pnlProductCollection"
		'
		'gceProductCollection
		'
		Me.gceProductCollection.AccessibleDescription = Nothing
		Me.gceProductCollection.AccessibleName = Nothing
		resources.ApplyResources(Me.gceProductCollection, "gceProductCollection")
		Me.gceProductCollection.BackgroundImage = Nothing
		Me.errorProviderRules.SetError(Me.gceProductCollection, resources.GetString("gceProductCollection.Error"))
		Me.gceProductCollection.Font = Nothing
		Me.gceProductCollection.Header = "Codes des Produits"
		Me.errorProviderRules.SetIconAlignment(Me.gceProductCollection, CType(resources.GetObject("gceProductCollection.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.gceProductCollection, CType(resources.GetObject("gceProductCollection.IconPadding"),Integer))
		Me.gceProductCollection.Items = CType(resources.GetObject("gceProductCollection.Items"),System.Collections.Generic.List(Of String))
		Me.gceProductCollection.Name = "gceProductCollection"
		Me.gceProductCollection.RequireAtLeastOne = true
		Me.gceProductCollection.RequireGuids = true
		AddHandler Me.gceProductCollection.ValidInputChanged, AddressOf Me.ValidateForm
		'
		'chkProductCollection_requireAll
		'
		Me.chkProductCollection_requireAll.AccessibleDescription = Nothing
		Me.chkProductCollection_requireAll.AccessibleName = Nothing
		resources.ApplyResources(Me.chkProductCollection_requireAll, "chkProductCollection_requireAll")
		Me.chkProductCollection_requireAll.BackgroundImage = Nothing
		Me.errorProviderRules.SetError(Me.chkProductCollection_requireAll, resources.GetString("chkProductCollection_requireAll.Error"))
		Me.chkProductCollection_requireAll.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.chkProductCollection_requireAll, CType(resources.GetObject("chkProductCollection_requireAll.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.chkProductCollection_requireAll, CType(resources.GetObject("chkProductCollection_requireAll.IconPadding"),Integer))
		Me.chkProductCollection_requireAll.Name = "chkProductCollection_requireAll"
		Me.chkProductCollection_requireAll.UseVisualStyleBackColor = true
		'
		'lblProductCollection
		'
		Me.lblProductCollection.AccessibleDescription = Nothing
		Me.lblProductCollection.AccessibleName = Nothing
		resources.ApplyResources(Me.lblProductCollection, "lblProductCollection")
		Me.errorProviderRules.SetError(Me.lblProductCollection, resources.GetString("lblProductCollection.Error"))
		Me.lblProductCollection.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.lblProductCollection, CType(resources.GetObject("lblProductCollection.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.lblProductCollection, CType(resources.GetObject("lblProductCollection.IconPadding"),Integer))
		Me.lblProductCollection.Name = "lblProductCollection"
		'
		'pnlMinVersion
		'
		Me.pnlMinVersion.AccessibleDescription = Nothing
		Me.pnlMinVersion.AccessibleName = Nothing
		resources.ApplyResources(Me.pnlMinVersion, "pnlMinVersion")
		Me.pnlMinVersion.BackgroundImage = Nothing
		Me.pnlMinVersion.Controls.Add(Me.txtMinVersion)
		Me.pnlMinVersion.Controls.Add(Me.lblMinVersion)
		Me.errorProviderRules.SetError(Me.pnlMinVersion, resources.GetString("pnlMinVersion.Error"))
		Me.pnlMinVersion.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.pnlMinVersion, CType(resources.GetObject("pnlMinVersion.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.pnlMinVersion, CType(resources.GetObject("pnlMinVersion.IconPadding"),Integer))
		Me.pnlMinVersion.Name = "pnlMinVersion"
		'
		'txtMinVersion
		'
		Me.txtMinVersion.AccessibleDescription = Nothing
		Me.txtMinVersion.AccessibleName = Nothing
		resources.ApplyResources(Me.txtMinVersion, "txtMinVersion")
		Me.txtMinVersion.BackgroundImage = Nothing
		Me.errorProviderRules.SetError(Me.txtMinVersion, resources.GetString("txtMinVersion.Error"))
		Me.txtMinVersion.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.txtMinVersion, CType(resources.GetObject("txtMinVersion.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.txtMinVersion, CType(resources.GetObject("txtMinVersion.IconPadding"),Integer))
		Me.txtMinVersion.Name = "txtMinVersion"
		AddHandler Me.txtMinVersion.TextChanged, AddressOf Me.ValidateForm
		AddHandler Me.txtMinVersion.Validating, AddressOf Me.ValidateVersion
		'
		'lblMinVersion
		'
		Me.lblMinVersion.AccessibleDescription = Nothing
		Me.lblMinVersion.AccessibleName = Nothing
		resources.ApplyResources(Me.lblMinVersion, "lblMinVersion")
		Me.errorProviderRules.SetError(Me.lblMinVersion, resources.GetString("lblMinVersion.Error"))
		Me.lblMinVersion.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.lblMinVersion, CType(resources.GetObject("lblMinVersion.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.lblMinVersion, CType(resources.GetObject("lblMinVersion.IconPadding"),Integer))
		Me.lblMinVersion.Name = "lblMinVersion"
		'
		'pnlMaxVersion
		'
		Me.pnlMaxVersion.AccessibleDescription = Nothing
		Me.pnlMaxVersion.AccessibleName = Nothing
		resources.ApplyResources(Me.pnlMaxVersion, "pnlMaxVersion")
		Me.pnlMaxVersion.BackgroundImage = Nothing
		Me.pnlMaxVersion.Controls.Add(Me.txtMaxVersion)
		Me.pnlMaxVersion.Controls.Add(Me.lblMaxVersion)
		Me.errorProviderRules.SetError(Me.pnlMaxVersion, resources.GetString("pnlMaxVersion.Error"))
		Me.pnlMaxVersion.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.pnlMaxVersion, CType(resources.GetObject("pnlMaxVersion.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.pnlMaxVersion, CType(resources.GetObject("pnlMaxVersion.IconPadding"),Integer))
		Me.pnlMaxVersion.Name = "pnlMaxVersion"
		'
		'txtMaxVersion
		'
		Me.txtMaxVersion.AccessibleDescription = Nothing
		Me.txtMaxVersion.AccessibleName = Nothing
		resources.ApplyResources(Me.txtMaxVersion, "txtMaxVersion")
		Me.txtMaxVersion.BackgroundImage = Nothing
		Me.errorProviderRules.SetError(Me.txtMaxVersion, resources.GetString("txtMaxVersion.Error"))
		Me.txtMaxVersion.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.txtMaxVersion, CType(resources.GetObject("txtMaxVersion.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.txtMaxVersion, CType(resources.GetObject("txtMaxVersion.IconPadding"),Integer))
		Me.txtMaxVersion.Name = "txtMaxVersion"
		AddHandler Me.txtMaxVersion.TextChanged, AddressOf Me.ValidateForm
		AddHandler Me.txtMaxVersion.Validating, AddressOf Me.ValidateVersion
		'
		'lblMaxVersion
		'
		Me.lblMaxVersion.AccessibleDescription = Nothing
		Me.lblMaxVersion.AccessibleName = Nothing
		resources.ApplyResources(Me.lblMaxVersion, "lblMaxVersion")
		Me.errorProviderRules.SetError(Me.lblMaxVersion, resources.GetString("lblMaxVersion.Error"))
		Me.lblMaxVersion.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.lblMaxVersion, CType(resources.GetObject("lblMaxVersion.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.lblMaxVersion, CType(resources.GetObject("lblMaxVersion.IconPadding"),Integer))
		Me.lblMaxVersion.Name = "lblMaxVersion"
		'
		'pnlPatchCode
		'
		Me.pnlPatchCode.AccessibleDescription = Nothing
		Me.pnlPatchCode.AccessibleName = Nothing
		resources.ApplyResources(Me.pnlPatchCode, "pnlPatchCode")
		Me.pnlPatchCode.BackgroundImage = Nothing
		Me.pnlPatchCode.Controls.Add(Me.txtPatchCode)
		Me.pnlPatchCode.Controls.Add(Me.lblPatchCode)
		Me.errorProviderRules.SetError(Me.pnlPatchCode, resources.GetString("pnlPatchCode.Error"))
		Me.pnlPatchCode.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.pnlPatchCode, CType(resources.GetObject("pnlPatchCode.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.pnlPatchCode, CType(resources.GetObject("pnlPatchCode.IconPadding"),Integer))
		Me.pnlPatchCode.Name = "pnlPatchCode"
		'
		'txtPatchCode
		'
		Me.txtPatchCode.AccessibleDescription = Nothing
		Me.txtPatchCode.AccessibleName = Nothing
		resources.ApplyResources(Me.txtPatchCode, "txtPatchCode")
		Me.txtPatchCode.BackgroundImage = Nothing
		Me.errorProviderRules.SetError(Me.txtPatchCode, resources.GetString("txtPatchCode.Error"))
		Me.txtPatchCode.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.txtPatchCode, CType(resources.GetObject("txtPatchCode.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.txtPatchCode, CType(resources.GetObject("txtPatchCode.IconPadding"),Integer))
		Me.txtPatchCode.Name = "txtPatchCode"
		AddHandler Me.txtPatchCode.TextChanged, AddressOf Me.ValidateForm
		'
		'lblPatchCode
		'
		Me.lblPatchCode.AccessibleDescription = Nothing
		Me.lblPatchCode.AccessibleName = Nothing
		resources.ApplyResources(Me.lblPatchCode, "lblPatchCode")
		Me.errorProviderRules.SetError(Me.lblPatchCode, resources.GetString("lblPatchCode.Error"))
		Me.lblPatchCode.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.lblPatchCode, CType(resources.GetObject("lblPatchCode.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.lblPatchCode, CType(resources.GetObject("lblPatchCode.IconPadding"),Integer))
		Me.lblPatchCode.Name = "lblPatchCode"
		'
		'pnlProductCode
		'
		Me.pnlProductCode.AccessibleDescription = Nothing
		Me.pnlProductCode.AccessibleName = Nothing
		resources.ApplyResources(Me.pnlProductCode, "pnlProductCode")
		Me.pnlProductCode.BackgroundImage = Nothing
		Me.pnlProductCode.Controls.Add(Me.txtProductCode)
		Me.pnlProductCode.Controls.Add(Me.lblProductCode)
		Me.errorProviderRules.SetError(Me.pnlProductCode, resources.GetString("pnlProductCode.Error"))
		Me.pnlProductCode.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.pnlProductCode, CType(resources.GetObject("pnlProductCode.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.pnlProductCode, CType(resources.GetObject("pnlProductCode.IconPadding"),Integer))
		Me.pnlProductCode.Name = "pnlProductCode"
		'
		'txtProductCode
		'
		Me.txtProductCode.AccessibleDescription = Nothing
		Me.txtProductCode.AccessibleName = Nothing
		resources.ApplyResources(Me.txtProductCode, "txtProductCode")
		Me.txtProductCode.BackgroundImage = Nothing
		Me.errorProviderRules.SetError(Me.txtProductCode, resources.GetString("txtProductCode.Error"))
		Me.txtProductCode.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.txtProductCode, CType(resources.GetObject("txtProductCode.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.txtProductCode, CType(resources.GetObject("txtProductCode.IconPadding"),Integer))
		Me.txtProductCode.Name = "txtProductCode"
		AddHandler Me.txtProductCode.TextChanged, AddressOf Me.ValidateForm
		'
		'lblProductCode
		'
		Me.lblProductCode.AccessibleDescription = Nothing
		Me.lblProductCode.AccessibleName = Nothing
		resources.ApplyResources(Me.lblProductCode, "lblProductCode")
		Me.errorProviderRules.SetError(Me.lblProductCode, resources.GetString("lblProductCode.Error"))
		Me.lblProductCode.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.lblProductCode, CType(resources.GetObject("lblProductCode.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.lblProductCode, CType(resources.GetObject("lblProductCode.IconPadding"),Integer))
		Me.lblProductCode.Name = "lblProductCode"
		'
		'pnlRegistry32Bit
		'
		Me.pnlRegistry32Bit.AccessibleDescription = Nothing
		Me.pnlRegistry32Bit.AccessibleName = Nothing
		resources.ApplyResources(Me.pnlRegistry32Bit, "pnlRegistry32Bit")
		Me.pnlRegistry32Bit.BackgroundImage = Nothing
		Me.pnlRegistry32Bit.Controls.Add(Me.chkRegistry32Bit)
		Me.errorProviderRules.SetError(Me.pnlRegistry32Bit, resources.GetString("pnlRegistry32Bit.Error"))
		Me.pnlRegistry32Bit.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.pnlRegistry32Bit, CType(resources.GetObject("pnlRegistry32Bit.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.pnlRegistry32Bit, CType(resources.GetObject("pnlRegistry32Bit.IconPadding"),Integer))
		Me.pnlRegistry32Bit.Name = "pnlRegistry32Bit"
		'
		'pnlQuery
		'
		Me.pnlQuery.AccessibleDescription = Nothing
		Me.pnlQuery.AccessibleName = Nothing
		resources.ApplyResources(Me.pnlQuery, "pnlQuery")
		Me.pnlQuery.BackgroundImage = Nothing
		Me.pnlQuery.Controls.Add(Me.txtQuery)
		Me.pnlQuery.Controls.Add(Me.lblQuery)
		Me.errorProviderRules.SetError(Me.pnlQuery, resources.GetString("pnlQuery.Error"))
		Me.pnlQuery.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.pnlQuery, CType(resources.GetObject("pnlQuery.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.pnlQuery, CType(resources.GetObject("pnlQuery.IconPadding"),Integer))
		Me.pnlQuery.Name = "pnlQuery"
		'
		'pnlDate
		'
		Me.pnlDate.AccessibleDescription = Nothing
		Me.pnlDate.AccessibleName = Nothing
		resources.ApplyResources(Me.pnlDate, "pnlDate")
		Me.pnlDate.BackgroundImage = Nothing
		Me.pnlDate.Controls.Add(Me.dtpDate)
		Me.pnlDate.Controls.Add(Me.lblDate)
		Me.errorProviderRules.SetError(Me.pnlDate, resources.GetString("pnlDate.Error"))
		Me.pnlDate.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.pnlDate, CType(resources.GetObject("pnlDate.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.pnlDate, CType(resources.GetObject("pnlDate.IconPadding"),Integer))
		Me.pnlDate.Name = "pnlDate"
		'
		'pnlData
		'
		Me.pnlData.AccessibleDescription = Nothing
		Me.pnlData.AccessibleName = Nothing
		resources.ApplyResources(Me.pnlData, "pnlData")
		Me.pnlData.BackgroundImage = Nothing
		Me.pnlData.Controls.Add(Me.txtData)
		Me.pnlData.Controls.Add(Me.lblData)
		Me.pnlData.Controls.Add(Me.lblDataInfo)
		Me.errorProviderRules.SetError(Me.pnlData, resources.GetString("pnlData.Error"))
		Me.pnlData.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.pnlData, CType(resources.GetObject("pnlData.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.pnlData, CType(resources.GetObject("pnlData.IconPadding"),Integer))
		Me.pnlData.Name = "pnlData"
		'
		'pnlVersion
		'
		Me.pnlVersion.AccessibleDescription = Nothing
		Me.pnlVersion.AccessibleName = Nothing
		resources.ApplyResources(Me.pnlVersion, "pnlVersion")
		Me.pnlVersion.BackgroundImage = Nothing
		Me.pnlVersion.Controls.Add(Me.txtVersion)
		Me.pnlVersion.Controls.Add(Me.lblVersion)
		Me.errorProviderRules.SetError(Me.pnlVersion, resources.GetString("pnlVersion.Error"))
		Me.pnlVersion.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.pnlVersion, CType(resources.GetObject("pnlVersion.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.pnlVersion, CType(resources.GetObject("pnlVersion.IconPadding"),Integer))
		Me.pnlVersion.Name = "pnlVersion"
		'
		'pnlFilePath
		'
		Me.pnlFilePath.AccessibleDescription = Nothing
		Me.pnlFilePath.AccessibleName = Nothing
		resources.ApplyResources(Me.pnlFilePath, "pnlFilePath")
		Me.pnlFilePath.BackgroundImage = Nothing
		Me.pnlFilePath.Controls.Add(Me.txtFilePath)
		Me.pnlFilePath.Controls.Add(Me.lblFilePath)
		Me.errorProviderRules.SetError(Me.pnlFilePath, resources.GetString("pnlFilePath.Error"))
		Me.pnlFilePath.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.pnlFilePath, CType(resources.GetObject("pnlFilePath.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.pnlFilePath, CType(resources.GetObject("pnlFilePath.IconPadding"),Integer))
		Me.pnlFilePath.Name = "pnlFilePath"
		'
		'pnlEnvironmentVariable
		'
		Me.pnlEnvironmentVariable.AccessibleDescription = Nothing
		Me.pnlEnvironmentVariable.AccessibleName = Nothing
		resources.ApplyResources(Me.pnlEnvironmentVariable, "pnlEnvironmentVariable")
		Me.pnlEnvironmentVariable.BackgroundImage = Nothing
		Me.pnlEnvironmentVariable.Controls.Add(Me.cboEnvironmentVariable)
		Me.pnlEnvironmentVariable.Controls.Add(Me.lblEnvironmentVariable)
		Me.errorProviderRules.SetError(Me.pnlEnvironmentVariable, resources.GetString("pnlEnvironmentVariable.Error"))
		Me.pnlEnvironmentVariable.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.pnlEnvironmentVariable, CType(resources.GetObject("pnlEnvironmentVariable.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.pnlEnvironmentVariable, CType(resources.GetObject("pnlEnvironmentVariable.IconPadding"),Integer))
		Me.pnlEnvironmentVariable.Name = "pnlEnvironmentVariable"
		'
		'pnlRegistryValueType
		'
		Me.pnlRegistryValueType.AccessibleDescription = Nothing
		Me.pnlRegistryValueType.AccessibleName = Nothing
		resources.ApplyResources(Me.pnlRegistryValueType, "pnlRegistryValueType")
		Me.pnlRegistryValueType.BackgroundImage = Nothing
		Me.pnlRegistryValueType.Controls.Add(Me.cboRegistryValueType)
		Me.pnlRegistryValueType.Controls.Add(Me.lblRegistryValueType)
		Me.errorProviderRules.SetError(Me.pnlRegistryValueType, resources.GetString("pnlRegistryValueType.Error"))
		Me.pnlRegistryValueType.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.pnlRegistryValueType, CType(resources.GetObject("pnlRegistryValueType.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.pnlRegistryValueType, CType(resources.GetObject("pnlRegistryValueType.IconPadding"),Integer))
		Me.pnlRegistryValueType.Name = "pnlRegistryValueType"
		'
		'pnlRegistryValue
		'
		Me.pnlRegistryValue.AccessibleDescription = Nothing
		Me.pnlRegistryValue.AccessibleName = Nothing
		resources.ApplyResources(Me.pnlRegistryValue, "pnlRegistryValue")
		Me.pnlRegistryValue.BackgroundImage = Nothing
		Me.pnlRegistryValue.Controls.Add(Me.lblRegistryValue)
		Me.pnlRegistryValue.Controls.Add(Me.txtRegistryValue)
		Me.errorProviderRules.SetError(Me.pnlRegistryValue, resources.GetString("pnlRegistryValue.Error"))
		Me.pnlRegistryValue.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.pnlRegistryValue, CType(resources.GetObject("pnlRegistryValue.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.pnlRegistryValue, CType(resources.GetObject("pnlRegistryValue.IconPadding"),Integer))
		Me.pnlRegistryValue.Name = "pnlRegistryValue"
		'
		'pnlRegistryKey
		'
		Me.pnlRegistryKey.AccessibleDescription = Nothing
		Me.pnlRegistryKey.AccessibleName = Nothing
		resources.ApplyResources(Me.pnlRegistryKey, "pnlRegistryKey")
		Me.pnlRegistryKey.BackgroundImage = Nothing
		Me.pnlRegistryKey.Controls.Add(Me.txtRegistrySubKey)
		Me.pnlRegistryKey.Controls.Add(Me.lblRegistryKey)
		Me.pnlRegistryKey.Controls.Add(Me.cboRegistryKey)
		Me.errorProviderRules.SetError(Me.pnlRegistryKey, resources.GetString("pnlRegistryKey.Error"))
		Me.pnlRegistryKey.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.pnlRegistryKey, CType(resources.GetObject("pnlRegistryKey.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.pnlRegistryKey, CType(resources.GetObject("pnlRegistryKey.IconPadding"),Integer))
		Me.pnlRegistryKey.Name = "pnlRegistryKey"
		'
		'pnlProcessorType
		'
		Me.pnlProcessorType.AccessibleDescription = Nothing
		Me.pnlProcessorType.AccessibleName = Nothing
		resources.ApplyResources(Me.pnlProcessorType, "pnlProcessorType")
		Me.pnlProcessorType.BackgroundImage = Nothing
		Me.pnlProcessorType.Controls.Add(Me.cboProcessorType)
		Me.pnlProcessorType.Controls.Add(Me.lblProcessorType)
		Me.errorProviderRules.SetError(Me.pnlProcessorType, resources.GetString("pnlProcessorType.Error"))
		Me.pnlProcessorType.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.pnlProcessorType, CType(resources.GetObject("pnlProcessorType.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.pnlProcessorType, CType(resources.GetObject("pnlProcessorType.IconPadding"),Integer))
		Me.pnlProcessorType.Name = "pnlProcessorType"
		'
		'pnlLanguage
		'
		Me.pnlLanguage.AccessibleDescription = Nothing
		Me.pnlLanguage.AccessibleName = Nothing
		resources.ApplyResources(Me.pnlLanguage, "pnlLanguage")
		Me.pnlLanguage.BackgroundImage = Nothing
		Me.pnlLanguage.Controls.Add(Me.cboLanguage)
		Me.pnlLanguage.Controls.Add(Me.lblLanguage)
		Me.errorProviderRules.SetError(Me.pnlLanguage, resources.GetString("pnlLanguage.Error"))
		Me.pnlLanguage.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.pnlLanguage, CType(resources.GetObject("pnlLanguage.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.pnlLanguage, CType(resources.GetObject("pnlLanguage.IconPadding"),Integer))
		Me.pnlLanguage.Name = "pnlLanguage"
		'
		'pnlProductType
		'
		Me.pnlProductType.AccessibleDescription = Nothing
		Me.pnlProductType.AccessibleName = Nothing
		resources.ApplyResources(Me.pnlProductType, "pnlProductType")
		Me.pnlProductType.BackgroundImage = Nothing
		Me.pnlProductType.Controls.Add(Me.cboProductType)
		Me.pnlProductType.Controls.Add(Me.lblProductType)
		Me.errorProviderRules.SetError(Me.pnlProductType, resources.GetString("pnlProductType.Error"))
		Me.pnlProductType.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.pnlProductType, CType(resources.GetObject("pnlProductType.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.pnlProductType, CType(resources.GetObject("pnlProductType.IconPadding"),Integer))
		Me.pnlProductType.Name = "pnlProductType"
		'
		'pnlServicePack
		'
		Me.pnlServicePack.AccessibleDescription = Nothing
		Me.pnlServicePack.AccessibleName = Nothing
		resources.ApplyResources(Me.pnlServicePack, "pnlServicePack")
		Me.pnlServicePack.BackgroundImage = Nothing
		Me.pnlServicePack.Controls.Add(Me.txtSPMinorVersion)
		Me.pnlServicePack.Controls.Add(Me.txtSPMajorVersion)
		Me.pnlServicePack.Controls.Add(Me.cboServicePack)
		Me.pnlServicePack.Controls.Add(Me.lblServicePack)
		Me.errorProviderRules.SetError(Me.pnlServicePack, resources.GetString("pnlServicePack.Error"))
		Me.pnlServicePack.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.pnlServicePack, CType(resources.GetObject("pnlServicePack.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.pnlServicePack, CType(resources.GetObject("pnlServicePack.IconPadding"),Integer))
		Me.pnlServicePack.Name = "pnlServicePack"
		'
		'pnlOSVersion
		'
		Me.pnlOSVersion.AccessibleDescription = Nothing
		Me.pnlOSVersion.AccessibleName = Nothing
		resources.ApplyResources(Me.pnlOSVersion, "pnlOSVersion")
		Me.pnlOSVersion.BackgroundImage = Nothing
		Me.pnlOSVersion.Controls.Add(Me.txtOSMinorVersion)
		Me.pnlOSVersion.Controls.Add(Me.txtOSMajorVersion)
		Me.pnlOSVersion.Controls.Add(Me.cboOSVersion)
		Me.pnlOSVersion.Controls.Add(Me.lbl_OSVersion)
		Me.errorProviderRules.SetError(Me.pnlOSVersion, resources.GetString("pnlOSVersion.Error"))
		Me.pnlOSVersion.Font = Nothing
		Me.errorProviderRules.SetIconAlignment(Me.pnlOSVersion, CType(resources.GetObject("pnlOSVersion.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.pnlOSVersion, CType(resources.GetObject("pnlOSVersion.IconPadding"),Integer))
		Me.pnlOSVersion.Name = "pnlOSVersion"
		'
		'pnlComparison
		'
		Me.pnlComparison.AccessibleDescription = Nothing
		Me.pnlComparison.AccessibleName = Nothing
		resources.ApplyResources(Me.pnlComparison, "pnlComparison")
		Me.pnlComparison.BackColor = System.Drawing.SystemColors.Control
		Me.pnlComparison.BackgroundImage = Nothing
		Me.pnlComparison.Controls.Add(Me.cboComparison)
		Me.pnlComparison.Controls.Add(Me.lblComparison)
		Me.errorProviderRules.SetError(Me.pnlComparison, resources.GetString("pnlComparison.Error"))
		Me.pnlComparison.Font = Nothing
		Me.pnlComparison.ForeColor = System.Drawing.SystemColors.ControlText
		Me.errorProviderRules.SetIconAlignment(Me.pnlComparison, CType(resources.GetObject("pnlComparison.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
		Me.errorProviderRules.SetIconPadding(Me.pnlComparison, CType(resources.GetObject("pnlComparison.IconPadding"),Integer))
		Me.pnlComparison.Name = "pnlComparison"
		'
		'errorProviderRules
		'
		Me.errorProviderRules.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
		Me.errorProviderRules.ContainerControl = Me
		resources.ApplyResources(Me.errorProviderRules, "errorProviderRules")
		'
		'RulesForm
		'
		Me.AcceptButton = Me.btnAdd
		Me.AccessibleDescription = Nothing
		Me.AccessibleName = Nothing
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackgroundImage = Nothing
		Me.CancelButton = Me.btnCancel
		Me.Controls.Add(Me.btnAdd)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.splitContainer)
		Me.Font = Nothing
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "RulesForm"
		Me.ShowInTaskbar = false
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
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
	Private pnlProductType As System.Windows.Forms.Panel
	
End Class
