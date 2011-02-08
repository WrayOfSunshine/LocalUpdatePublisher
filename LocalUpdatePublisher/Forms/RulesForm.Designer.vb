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
		Me.cboRuleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboRuleType.FormattingEnabled = true
		resources.ApplyResources(Me.cboRuleType, "cboRuleType")
		Me.cboRuleType.Name = "cboRuleType"
		AddHandler Me.cboRuleType.SelectedIndexChanged, AddressOf Me.cboRuleTypeSelectedIndexChanged
		AddHandler Me.cboRuleType.Format, AddressOf Me.CboRuleTypeFormat
		'
		'lblRuleType
		'
		resources.ApplyResources(Me.lblRuleType, "lblRuleType")
		Me.lblRuleType.Name = "lblRuleType"
		'
		'lblProductType
		'
		resources.ApplyResources(Me.lblProductType, "lblProductType")
		Me.lblProductType.Name = "lblProductType"
		'
		'cboProductType
		'
		Me.cboProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboProductType.FormattingEnabled = true
		Me.cboProductType.Items.AddRange(New Object() {resources.GetString("cboProductType.Items"), resources.GetString("cboProductType.Items1"), resources.GetString("cboProductType.Items2"), resources.GetString("cboProductType.Items3")})
		resources.ApplyResources(Me.cboProductType, "cboProductType")
		Me.cboProductType.Name = "cboProductType"
		'
		'txtSPMinorVersion
		'
		resources.ApplyResources(Me.txtSPMinorVersion, "txtSPMinorVersion")
		Me.txtSPMinorVersion.Name = "txtSPMinorVersion"
		'
		'txtSPMajorVersion
		'
		resources.ApplyResources(Me.txtSPMajorVersion, "txtSPMajorVersion")
		Me.txtSPMajorVersion.Name = "txtSPMajorVersion"
		'
		'txtOSMinorVersion
		'
		resources.ApplyResources(Me.txtOSMinorVersion, "txtOSMinorVersion")
		Me.txtOSMinorVersion.Name = "txtOSMinorVersion"
		AddHandler Me.txtOSMinorVersion.TextChanged, AddressOf Me.ValidateForm
		'
		'txtOSMajorVersion
		'
		resources.ApplyResources(Me.txtOSMajorVersion, "txtOSMajorVersion")
		Me.txtOSMajorVersion.Name = "txtOSMajorVersion"
		AddHandler Me.txtOSMajorVersion.TextChanged, AddressOf Me.ValidateForm
		'
		'lblServicePack
		'
		resources.ApplyResources(Me.lblServicePack, "lblServicePack")
		Me.lblServicePack.Name = "lblServicePack"
		'
		'cboServicePack
		'
		Me.cboServicePack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboServicePack.FormattingEnabled = true
		Me.cboServicePack.Items.AddRange(New Object() {resources.GetString("cboServicePack.Items"), resources.GetString("cboServicePack.Items1"), resources.GetString("cboServicePack.Items2"), resources.GetString("cboServicePack.Items3")})
		resources.ApplyResources(Me.cboServicePack, "cboServicePack")
		Me.cboServicePack.Name = "cboServicePack"
		AddHandler Me.cboServicePack.SelectedIndexChanged, AddressOf Me.GetServicePackCode
		'
		'lbl_OSVersion
		'
		resources.ApplyResources(Me.lbl_OSVersion, "lbl_OSVersion")
		Me.lbl_OSVersion.Name = "lbl_OSVersion"
		'
		'cboOSVersion
		'
		Me.cboOSVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboOSVersion.FormattingEnabled = true
		Me.cboOSVersion.Items.AddRange(New Object() {resources.GetString("cboOSVersion.Items"), resources.GetString("cboOSVersion.Items1"), resources.GetString("cboOSVersion.Items2"), resources.GetString("cboOSVersion.Items3"), resources.GetString("cboOSVersion.Items4"), resources.GetString("cboOSVersion.Items5")})
		resources.ApplyResources(Me.cboOSVersion, "cboOSVersion")
		Me.cboOSVersion.Name = "cboOSVersion"
		AddHandler Me.cboOSVersion.SelectedIndexChanged, AddressOf Me.GetOSVersionCodes
		'
		'lblComparison
		'
		resources.ApplyResources(Me.lblComparison, "lblComparison")
		Me.lblComparison.Name = "lblComparison"
		'
		'cboComparison
		'
		Me.cboComparison.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboComparison.FormattingEnabled = true
		Me.cboComparison.Items.AddRange(New Object() {resources.GetString("cboComparison.Items"), resources.GetString("cboComparison.Items1"), resources.GetString("cboComparison.Items2"), resources.GetString("cboComparison.Items3"), resources.GetString("cboComparison.Items4")})
		resources.ApplyResources(Me.cboComparison, "cboComparison")
		Me.cboComparison.Name = "cboComparison"
		AddHandler Me.cboComparison.SelectedIndexChanged, AddressOf Me.ValidateForm
		'
		'lblLanguage
		'
		resources.ApplyResources(Me.lblLanguage, "lblLanguage")
		Me.lblLanguage.Name = "lblLanguage"
		'
		'cboLanguage
		'
		Me.cboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboLanguage.FormattingEnabled = true
		Me.cboLanguage.Items.AddRange(New Object() {resources.GetString("cboLanguage.Items"), resources.GetString("cboLanguage.Items1"), resources.GetString("cboLanguage.Items2"), resources.GetString("cboLanguage.Items3"), resources.GetString("cboLanguage.Items4"), resources.GetString("cboLanguage.Items5"), resources.GetString("cboLanguage.Items6"), resources.GetString("cboLanguage.Items7"), resources.GetString("cboLanguage.Items8"), resources.GetString("cboLanguage.Items9"), resources.GetString("cboLanguage.Items10"), resources.GetString("cboLanguage.Items11"), resources.GetString("cboLanguage.Items12"), resources.GetString("cboLanguage.Items13"), resources.GetString("cboLanguage.Items14"), resources.GetString("cboLanguage.Items15"), resources.GetString("cboLanguage.Items16"), resources.GetString("cboLanguage.Items17"), resources.GetString("cboLanguage.Items18"), resources.GetString("cboLanguage.Items19"), resources.GetString("cboLanguage.Items20"), resources.GetString("cboLanguage.Items21"), resources.GetString("cboLanguage.Items22"), resources.GetString("cboLanguage.Items23"), resources.GetString("cboLanguage.Items24")})
		resources.ApplyResources(Me.cboLanguage, "cboLanguage")
		Me.cboLanguage.Name = "cboLanguage"
		AddHandler Me.cboLanguage.SelectedIndexChanged, AddressOf Me.ValidateForm
		'
		'lblProcessorType
		'
		resources.ApplyResources(Me.lblProcessorType, "lblProcessorType")
		Me.lblProcessorType.Name = "lblProcessorType"
		'
		'cboProcessorType
		'
		Me.cboProcessorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboProcessorType.FormattingEnabled = true
		Me.cboProcessorType.Items.AddRange(New Object() {resources.GetString("cboProcessorType.Items"), resources.GetString("cboProcessorType.Items1"), resources.GetString("cboProcessorType.Items2")})
		resources.ApplyResources(Me.cboProcessorType, "cboProcessorType")
		Me.cboProcessorType.Name = "cboProcessorType"
		AddHandler Me.cboProcessorType.SelectedIndexChanged, AddressOf Me.ValidateForm
		'
		'lblEnvironmentVariable
		'
		resources.ApplyResources(Me.lblEnvironmentVariable, "lblEnvironmentVariable")
		Me.lblEnvironmentVariable.Name = "lblEnvironmentVariable"
		'
		'cboEnvironmentVariable
		'
		Me.cboEnvironmentVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboEnvironmentVariable.FormattingEnabled = true
		resources.ApplyResources(Me.cboEnvironmentVariable, "cboEnvironmentVariable")
		Me.cboEnvironmentVariable.Name = "cboEnvironmentVariable"
		'
		'txtVersion
		'
		resources.ApplyResources(Me.txtVersion, "txtVersion")
		Me.txtVersion.Name = "txtVersion"
		AddHandler Me.txtVersion.TextChanged, AddressOf Me.ValidateForm
		AddHandler Me.txtVersion.Validating, AddressOf Me.ValidateVersion
		'
		'lblVersion
		'
		resources.ApplyResources(Me.lblVersion, "lblVersion")
		Me.lblVersion.Name = "lblVersion"
		'
		'txtRegistryValue
		'
		resources.ApplyResources(Me.txtRegistryValue, "txtRegistryValue")
		Me.txtRegistryValue.Name = "txtRegistryValue"
		AddHandler Me.txtRegistryValue.TextChanged, AddressOf Me.ValidateForm
		'
		'lblRegistryValue
		'
		resources.ApplyResources(Me.lblRegistryValue, "lblRegistryValue")
		Me.lblRegistryValue.Name = "lblRegistryValue"
		'
		'chkRegistry32Bit
		'
		resources.ApplyResources(Me.chkRegistry32Bit, "chkRegistry32Bit")
		Me.chkRegistry32Bit.Name = "chkRegistry32Bit"
		Me.chkRegistry32Bit.UseVisualStyleBackColor = true
		'
		'txtRegistrySubKey
		'
		resources.ApplyResources(Me.txtRegistrySubKey, "txtRegistrySubKey")
		Me.txtRegistrySubKey.Name = "txtRegistrySubKey"
		AddHandler Me.txtRegistrySubKey.TextChanged, AddressOf Me.ValidateForm
		'
		'lblRegistryKey
		'
		resources.ApplyResources(Me.lblRegistryKey, "lblRegistryKey")
		Me.lblRegistryKey.Name = "lblRegistryKey"
		'
		'cboRegistryKey
		'
		Me.cboRegistryKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboRegistryKey.FormattingEnabled = true
		Me.cboRegistryKey.Items.AddRange(New Object() {resources.GetString("cboRegistryKey.Items")})
		resources.ApplyResources(Me.cboRegistryKey, "cboRegistryKey")
		Me.cboRegistryKey.Name = "cboRegistryKey"
		AddHandler Me.cboRegistryKey.SelectedIndexChanged, AddressOf Me.ValidateForm
		'
		'txtFilePath
		'
		resources.ApplyResources(Me.txtFilePath, "txtFilePath")
		Me.txtFilePath.Name = "txtFilePath"
		AddHandler Me.txtFilePath.TextChanged, AddressOf Me.ValidateForm
		'
		'lblFilePath
		'
		resources.ApplyResources(Me.lblFilePath, "lblFilePath")
		Me.lblFilePath.Name = "lblFilePath"
		'
		'dtpDate
		'
		Me.dtpDate.Checked = false
		Me.dtpDate.Cursor = System.Windows.Forms.Cursors.IBeam
		resources.ApplyResources(Me.dtpDate, "dtpDate")
		Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
		Me.dtpDate.Name = "dtpDate"
		Me.dtpDate.ShowCheckBox = true
		AddHandler Me.dtpDate.ValueChanged, AddressOf Me.ValidateForm
		'
		'lblDate
		'
		resources.ApplyResources(Me.lblDate, "lblDate")
		Me.lblDate.Name = "lblDate"
		'
		'lblDataInfo
		'
		resources.ApplyResources(Me.lblDataInfo, "lblDataInfo")
		Me.lblDataInfo.Name = "lblDataInfo"
		'
		'txtData
		'
		resources.ApplyResources(Me.txtData, "txtData")
		Me.txtData.Name = "txtData"
		AddHandler Me.txtData.TextChanged, AddressOf Me.ValidateForm
		'
		'lblData
		'
		resources.ApplyResources(Me.lblData, "lblData")
		Me.lblData.Name = "lblData"
		'
		'txtQuery
		'
		Me.txtQuery.AcceptsReturn = true
		Me.txtQuery.AcceptsTab = true
		resources.ApplyResources(Me.txtQuery, "txtQuery")
		Me.txtQuery.Name = "txtQuery"
		AddHandler Me.txtQuery.TextChanged, AddressOf Me.ValidateForm
		'
		'lblQuery
		'
		resources.ApplyResources(Me.lblQuery, "lblQuery")
		Me.lblQuery.Name = "lblQuery"
		'
		'chkNotRule
		'
		resources.ApplyResources(Me.chkNotRule, "chkNotRule")
		Me.chkNotRule.Name = "chkNotRule"
		Me.chkNotRule.UseVisualStyleBackColor = true
		'
		'btnAdd
		'
		resources.ApplyResources(Me.btnAdd, "btnAdd")
		Me.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnAdd.Name = "btnAdd"
		Me.btnAdd.UseVisualStyleBackColor = true
		AddHandler Me.btnAdd.Click, AddressOf Me.BtnAddClick
		'
		'btnCancel
		'
		resources.ApplyResources(Me.btnCancel, "btnCancel")
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.UseVisualStyleBackColor = true
		'
		'lblRegistryValueType
		'
		resources.ApplyResources(Me.lblRegistryValueType, "lblRegistryValueType")
		Me.lblRegistryValueType.MinimumSize = Me.lblRegistryValueType.Size
		Me.lblRegistryValueType.Name = "lblRegistryValueType"
		'
		'cboRegistryValueType
		'
		Me.cboRegistryValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboRegistryValueType.FormattingEnabled = true
		Me.cboRegistryValueType.Items.AddRange(New Object() {resources.GetString("cboRegistryValueType.Items"), resources.GetString("cboRegistryValueType.Items1"), resources.GetString("cboRegistryValueType.Items2"), resources.GetString("cboRegistryValueType.Items3")})
		resources.ApplyResources(Me.cboRegistryValueType, "cboRegistryValueType")
		Me.cboRegistryValueType.Name = "cboRegistryValueType"
		AddHandler Me.cboRegistryValueType.SelectedIndexChanged, AddressOf Me.ValidateForm
		'
		'splitContainer
		'
		resources.ApplyResources(Me.splitContainer, "splitContainer")
		Me.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
		Me.splitContainer.Name = "splitContainer"
		'
		'splitContainer.Panel1
		'
		Me.splitContainer.Panel1.Controls.Add(Me.cboRuleType)
		Me.splitContainer.Panel1.Controls.Add(Me.lblRuleType)
		Me.splitContainer.Panel1.Controls.Add(Me.chkNotRule)
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
		Me.splitContainer.TabStop = false
		'
		'pnlComponentCollection
		'
		Me.pnlComponentCollection.Controls.Add(Me.gceComponentCollection)
		Me.pnlComponentCollection.Controls.Add(Me.chkComponentCollection_requireAll)
		Me.pnlComponentCollection.Controls.Add(Me.lblComponentCollection)
		resources.ApplyResources(Me.pnlComponentCollection, "pnlComponentCollection")
		Me.pnlComponentCollection.Name = "pnlComponentCollection"
		'
		'gceComponentCollection
		'
		Me.gceComponentCollection.Header = "Component Codes"
		Me.gceComponentCollection.Items = CType(resources.GetObject("gceComponentCollection.Items"),System.Collections.Generic.List(Of String))
		resources.ApplyResources(Me.gceComponentCollection, "gceComponentCollection")
		Me.gceComponentCollection.Name = "gceComponentCollection"
		Me.gceComponentCollection.RequireAtLeastOne = true
		Me.gceComponentCollection.RequireGuids = true
		AddHandler Me.gceComponentCollection.ValidInputChanged, AddressOf Me.ValidateForm
		'
		'chkComponentCollection_requireAll
		'
		resources.ApplyResources(Me.chkComponentCollection_requireAll, "chkComponentCollection_requireAll")
		Me.chkComponentCollection_requireAll.Name = "chkComponentCollection_requireAll"
		Me.chkComponentCollection_requireAll.UseVisualStyleBackColor = true
		'
		'lblComponentCollection
		'
		resources.ApplyResources(Me.lblComponentCollection, "lblComponentCollection")
		Me.lblComponentCollection.Name = "lblComponentCollection"
		'
		'pnlFeatureCollection
		'
		Me.pnlFeatureCollection.Controls.Add(Me.gceFeatureCollection)
		Me.pnlFeatureCollection.Controls.Add(Me.chkFeatureCollection_requireAll)
		Me.pnlFeatureCollection.Controls.Add(Me.lblFeatureCollection)
		resources.ApplyResources(Me.pnlFeatureCollection, "pnlFeatureCollection")
		Me.pnlFeatureCollection.Name = "pnlFeatureCollection"
		'
		'gceFeatureCollection
		'
		Me.gceFeatureCollection.Header = "Feature Names"
		Me.gceFeatureCollection.Items = CType(resources.GetObject("gceFeatureCollection.Items"),System.Collections.Generic.List(Of String))
		resources.ApplyResources(Me.gceFeatureCollection, "gceFeatureCollection")
		Me.gceFeatureCollection.Name = "gceFeatureCollection"
		Me.gceFeatureCollection.RequireAtLeastOne = true
		Me.gceFeatureCollection.RequireGuids = false
		AddHandler Me.gceFeatureCollection.ValidInputChanged, AddressOf Me.ValidateForm
		'
		'chkFeatureCollection_requireAll
		'
		resources.ApplyResources(Me.chkFeatureCollection_requireAll, "chkFeatureCollection_requireAll")
		Me.chkFeatureCollection_requireAll.Name = "chkFeatureCollection_requireAll"
		Me.chkFeatureCollection_requireAll.UseVisualStyleBackColor = true
		'
		'lblFeatureCollection
		'
		resources.ApplyResources(Me.lblFeatureCollection, "lblFeatureCollection")
		Me.lblFeatureCollection.Name = "lblFeatureCollection"
		'
		'pnlProductCollection
		'
		Me.pnlProductCollection.Controls.Add(Me.gceProductCollection)
		Me.pnlProductCollection.Controls.Add(Me.chkProductCollection_requireAll)
		Me.pnlProductCollection.Controls.Add(Me.lblProductCollection)
		resources.ApplyResources(Me.pnlProductCollection, "pnlProductCollection")
		Me.pnlProductCollection.Name = "pnlProductCollection"
		'
		'gceProductCollection
		'
		Me.gceProductCollection.Header = "Product Codes"
		Me.gceProductCollection.Items = CType(resources.GetObject("gceProductCollection.Items"),System.Collections.Generic.List(Of String))
		resources.ApplyResources(Me.gceProductCollection, "gceProductCollection")
		Me.gceProductCollection.Name = "gceProductCollection"
		Me.gceProductCollection.RequireAtLeastOne = true
		Me.gceProductCollection.RequireGuids = true
		AddHandler Me.gceProductCollection.ValidInputChanged, AddressOf Me.ValidateForm
		'
		'chkProductCollection_requireAll
		'
		resources.ApplyResources(Me.chkProductCollection_requireAll, "chkProductCollection_requireAll")
		Me.chkProductCollection_requireAll.Name = "chkProductCollection_requireAll"
		Me.chkProductCollection_requireAll.UseVisualStyleBackColor = true
		'
		'lblProductCollection
		'
		resources.ApplyResources(Me.lblProductCollection, "lblProductCollection")
		Me.lblProductCollection.Name = "lblProductCollection"
		'
		'pnlMinVersion
		'
		Me.pnlMinVersion.Controls.Add(Me.txtMinVersion)
		Me.pnlMinVersion.Controls.Add(Me.lblMinVersion)
		resources.ApplyResources(Me.pnlMinVersion, "pnlMinVersion")
		Me.pnlMinVersion.Name = "pnlMinVersion"
		'
		'txtMinVersion
		'
		resources.ApplyResources(Me.txtMinVersion, "txtMinVersion")
		Me.txtMinVersion.Name = "txtMinVersion"
		AddHandler Me.txtMinVersion.TextChanged, AddressOf Me.ValidateForm
		AddHandler Me.txtMinVersion.Validating, AddressOf Me.ValidateVersion
		'
		'lblMinVersion
		'
		resources.ApplyResources(Me.lblMinVersion, "lblMinVersion")
		Me.lblMinVersion.Name = "lblMinVersion"
		'
		'pnlMaxVersion
		'
		Me.pnlMaxVersion.Controls.Add(Me.txtMaxVersion)
		Me.pnlMaxVersion.Controls.Add(Me.lblMaxVersion)
		resources.ApplyResources(Me.pnlMaxVersion, "pnlMaxVersion")
		Me.pnlMaxVersion.Name = "pnlMaxVersion"
		'
		'txtMaxVersion
		'
		resources.ApplyResources(Me.txtMaxVersion, "txtMaxVersion")
		Me.txtMaxVersion.Name = "txtMaxVersion"
		AddHandler Me.txtMaxVersion.TextChanged, AddressOf Me.ValidateForm
		AddHandler Me.txtMaxVersion.Validating, AddressOf Me.ValidateVersion
		'
		'lblMaxVersion
		'
		resources.ApplyResources(Me.lblMaxVersion, "lblMaxVersion")
		Me.lblMaxVersion.Name = "lblMaxVersion"
		'
		'pnlPatchCode
		'
		Me.pnlPatchCode.Controls.Add(Me.txtPatchCode)
		Me.pnlPatchCode.Controls.Add(Me.lblPatchCode)
		resources.ApplyResources(Me.pnlPatchCode, "pnlPatchCode")
		Me.pnlPatchCode.Name = "pnlPatchCode"
		'
		'txtPatchCode
		'
		resources.ApplyResources(Me.txtPatchCode, "txtPatchCode")
		Me.txtPatchCode.Name = "txtPatchCode"
		AddHandler Me.txtPatchCode.TextChanged, AddressOf Me.ValidateForm
		'
		'lblPatchCode
		'
		resources.ApplyResources(Me.lblPatchCode, "lblPatchCode")
		Me.lblPatchCode.Name = "lblPatchCode"
		'
		'pnlProductCode
		'
		Me.pnlProductCode.Controls.Add(Me.txtProductCode)
		Me.pnlProductCode.Controls.Add(Me.lblProductCode)
		resources.ApplyResources(Me.pnlProductCode, "pnlProductCode")
		Me.pnlProductCode.Name = "pnlProductCode"
		'
		'txtProductCode
		'
		resources.ApplyResources(Me.txtProductCode, "txtProductCode")
		Me.txtProductCode.Name = "txtProductCode"
		AddHandler Me.txtProductCode.TextChanged, AddressOf Me.ValidateForm
		'
		'lblProductCode
		'
		resources.ApplyResources(Me.lblProductCode, "lblProductCode")
		Me.lblProductCode.Name = "lblProductCode"
		'
		'pnlRegistry32Bit
		'
		Me.pnlRegistry32Bit.Controls.Add(Me.chkRegistry32Bit)
		resources.ApplyResources(Me.pnlRegistry32Bit, "pnlRegistry32Bit")
		Me.pnlRegistry32Bit.Name = "pnlRegistry32Bit"
		'
		'pnlQuery
		'
		Me.pnlQuery.Controls.Add(Me.txtQuery)
		Me.pnlQuery.Controls.Add(Me.lblQuery)
		resources.ApplyResources(Me.pnlQuery, "pnlQuery")
		Me.pnlQuery.Name = "pnlQuery"
		'
		'pnlDate
		'
		Me.pnlDate.Controls.Add(Me.dtpDate)
		Me.pnlDate.Controls.Add(Me.lblDate)
		resources.ApplyResources(Me.pnlDate, "pnlDate")
		Me.pnlDate.Name = "pnlDate"
		'
		'pnlData
		'
		Me.pnlData.Controls.Add(Me.txtData)
		Me.pnlData.Controls.Add(Me.lblData)
		Me.pnlData.Controls.Add(Me.lblDataInfo)
		resources.ApplyResources(Me.pnlData, "pnlData")
		Me.pnlData.Name = "pnlData"
		'
		'pnlVersion
		'
		Me.pnlVersion.Controls.Add(Me.txtVersion)
		Me.pnlVersion.Controls.Add(Me.lblVersion)
		resources.ApplyResources(Me.pnlVersion, "pnlVersion")
		Me.pnlVersion.Name = "pnlVersion"
		'
		'pnlFilePath
		'
		Me.pnlFilePath.Controls.Add(Me.txtFilePath)
		Me.pnlFilePath.Controls.Add(Me.lblFilePath)
		resources.ApplyResources(Me.pnlFilePath, "pnlFilePath")
		Me.pnlFilePath.Name = "pnlFilePath"
		'
		'pnlEnvironmentVariable
		'
		Me.pnlEnvironmentVariable.Controls.Add(Me.cboEnvironmentVariable)
		Me.pnlEnvironmentVariable.Controls.Add(Me.lblEnvironmentVariable)
		resources.ApplyResources(Me.pnlEnvironmentVariable, "pnlEnvironmentVariable")
		Me.pnlEnvironmentVariable.Name = "pnlEnvironmentVariable"
		'
		'pnlRegistryValueType
		'
		Me.pnlRegistryValueType.Controls.Add(Me.cboRegistryValueType)
		Me.pnlRegistryValueType.Controls.Add(Me.lblRegistryValueType)
		resources.ApplyResources(Me.pnlRegistryValueType, "pnlRegistryValueType")
		Me.pnlRegistryValueType.Name = "pnlRegistryValueType"
		'
		'pnlRegistryValue
		'
		Me.pnlRegistryValue.Controls.Add(Me.lblRegistryValue)
		Me.pnlRegistryValue.Controls.Add(Me.txtRegistryValue)
		resources.ApplyResources(Me.pnlRegistryValue, "pnlRegistryValue")
		Me.pnlRegistryValue.Name = "pnlRegistryValue"
		'
		'pnlRegistryKey
		'
		Me.pnlRegistryKey.Controls.Add(Me.txtRegistrySubKey)
		Me.pnlRegistryKey.Controls.Add(Me.lblRegistryKey)
		Me.pnlRegistryKey.Controls.Add(Me.cboRegistryKey)
		resources.ApplyResources(Me.pnlRegistryKey, "pnlRegistryKey")
		Me.pnlRegistryKey.Name = "pnlRegistryKey"
		'
		'pnlProcessorType
		'
		Me.pnlProcessorType.Controls.Add(Me.cboProcessorType)
		Me.pnlProcessorType.Controls.Add(Me.lblProcessorType)
		resources.ApplyResources(Me.pnlProcessorType, "pnlProcessorType")
		Me.pnlProcessorType.Name = "pnlProcessorType"
		'
		'pnlLanguage
		'
		Me.pnlLanguage.Controls.Add(Me.cboLanguage)
		Me.pnlLanguage.Controls.Add(Me.lblLanguage)
		resources.ApplyResources(Me.pnlLanguage, "pnlLanguage")
		Me.pnlLanguage.Name = "pnlLanguage"
		'
		'pnlProductType
		'
		Me.pnlProductType.Controls.Add(Me.cboProductType)
		Me.pnlProductType.Controls.Add(Me.lblProductType)
		resources.ApplyResources(Me.pnlProductType, "pnlProductType")
		Me.pnlProductType.Name = "pnlProductType"
		'
		'pnlServicePack
		'
		Me.pnlServicePack.Controls.Add(Me.txtSPMinorVersion)
		Me.pnlServicePack.Controls.Add(Me.txtSPMajorVersion)
		Me.pnlServicePack.Controls.Add(Me.cboServicePack)
		Me.pnlServicePack.Controls.Add(Me.lblServicePack)
		resources.ApplyResources(Me.pnlServicePack, "pnlServicePack")
		Me.pnlServicePack.Name = "pnlServicePack"
		'
		'pnlOSVersion
		'
		Me.pnlOSVersion.Controls.Add(Me.txtOSMinorVersion)
		Me.pnlOSVersion.Controls.Add(Me.txtOSMajorVersion)
		Me.pnlOSVersion.Controls.Add(Me.cboOSVersion)
		Me.pnlOSVersion.Controls.Add(Me.lbl_OSVersion)
		resources.ApplyResources(Me.pnlOSVersion, "pnlOSVersion")
		Me.pnlOSVersion.Name = "pnlOSVersion"
		'
		'pnlComparison
		'
		Me.pnlComparison.BackColor = System.Drawing.SystemColors.Control
		Me.pnlComparison.Controls.Add(Me.cboComparison)
		Me.pnlComparison.Controls.Add(Me.lblComparison)
		Me.pnlComparison.ForeColor = System.Drawing.SystemColors.ControlText
		resources.ApplyResources(Me.pnlComparison, "pnlComparison")
		Me.pnlComparison.Name = "pnlComparison"
		'
		'errorProviderRules
		'
		Me.errorProviderRules.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
		Me.errorProviderRules.ContainerControl = Me
		'
		'RulesForm
		'
		Me.AcceptButton = Me.btnAdd
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.btnCancel
		Me.Controls.Add(Me.btnAdd)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.splitContainer)
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
