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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RulesForm))
        Me.tlpHeader = New System.Windows.Forms.TableLayoutPanel()
        Me.chkNotRule = New System.Windows.Forms.CheckBox()
        Me.cboRuleType = New System.Windows.Forms.ComboBox()
        Me.lblRuleType = New System.Windows.Forms.Label()
        Me.tlpFooter = New System.Windows.Forms.TableLayoutPanel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.tlpRules = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpComparison = New System.Windows.Forms.TableLayoutPanel()
        Me.cboComparison = New System.Windows.Forms.ComboBox()
        Me.lblComparison = New System.Windows.Forms.Label()
        Me.tlpOSVersion = New System.Windows.Forms.TableLayoutPanel()
        Me.txtOSMinorVersion = New System.Windows.Forms.TextBox()
        Me.lblOSVersion = New System.Windows.Forms.Label()
        Me.txtOSMajorVersion = New System.Windows.Forms.TextBox()
        Me.cboOSVersion = New System.Windows.Forms.ComboBox()
        Me.tlpServicePack = New System.Windows.Forms.TableLayoutPanel()
        Me.txtSPMinorVersion = New System.Windows.Forms.TextBox()
        Me.lblServicePack = New System.Windows.Forms.Label()
        Me.txtSPMajorVersion = New System.Windows.Forms.TextBox()
        Me.cboServicePack = New System.Windows.Forms.ComboBox()
        Me.tlpProductType = New System.Windows.Forms.TableLayoutPanel()
        Me.cboProductType = New System.Windows.Forms.ComboBox()
        Me.lblProductType = New System.Windows.Forms.Label()
        Me.tlpLanguage = New System.Windows.Forms.TableLayoutPanel()
        Me.cboLanguage = New System.Windows.Forms.ComboBox()
        Me.lblLanguage = New System.Windows.Forms.Label()
        Me.tlpProcessorType = New System.Windows.Forms.TableLayoutPanel()
        Me.cboProcessorType = New System.Windows.Forms.ComboBox()
        Me.lblProcessorType = New System.Windows.Forms.Label()
        Me.tlpRegistryKey = New System.Windows.Forms.TableLayoutPanel()
        Me.txtRegistrySubKey = New System.Windows.Forms.TextBox()
        Me.lblRegistryKey = New System.Windows.Forms.Label()
        Me.cboRegistryKey = New System.Windows.Forms.ComboBox()
        Me.tlpRegistryValue = New System.Windows.Forms.TableLayoutPanel()
        Me.chkRegistry32Bit = New System.Windows.Forms.CheckBox()
        Me.txtRegistryValue = New System.Windows.Forms.TextBox()
        Me.lblRegistryValue = New System.Windows.Forms.Label()
        Me.tlpRegistryValueType = New System.Windows.Forms.TableLayoutPanel()
        Me.cboRegistryValueType = New System.Windows.Forms.ComboBox()
        Me.lblRegistryValueType = New System.Windows.Forms.Label()
        Me.tlpEnvironmentVariable = New System.Windows.Forms.TableLayoutPanel()
        Me.cboEnvironmentVariable = New System.Windows.Forms.ComboBox()
        Me.lblEnvironmentVariable = New System.Windows.Forms.Label()
        Me.tlpFilePath = New System.Windows.Forms.TableLayoutPanel()
        Me.txtFilePath = New System.Windows.Forms.TextBox()
        Me.lblPath = New System.Windows.Forms.Label()
        Me.tlpVersion = New System.Windows.Forms.TableLayoutPanel()
        Me.txtVersion = New System.Windows.Forms.TextBox()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.tlpData = New System.Windows.Forms.TableLayoutPanel()
        Me.lblDataInfo = New System.Windows.Forms.Label()
        Me.txtData = New System.Windows.Forms.TextBox()
        Me.lblData = New System.Windows.Forms.Label()
        Me.tlpDate = New System.Windows.Forms.TableLayoutPanel()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.tlpProductCode = New System.Windows.Forms.TableLayoutPanel()
        Me.txtProductCode = New System.Windows.Forms.TextBox()
        Me.lblProductCode = New System.Windows.Forms.Label()
        Me.tlpPatchCode = New System.Windows.Forms.TableLayoutPanel()
        Me.txtPatchCode = New System.Windows.Forms.TextBox()
        Me.lblPatchCode = New System.Windows.Forms.Label()
        Me.tlpMaxVersion = New System.Windows.Forms.TableLayoutPanel()
        Me.txtMaxVersion = New System.Windows.Forms.TextBox()
        Me.lblMaxVersion = New System.Windows.Forms.Label()
        Me.pnlFeatureCollection = New System.Windows.Forms.Panel()
        Me.gceFeatureCollection = New LocalUpdatePublisher.GuidCollectionEditor()
        Me.chkFeatureCollection_requireAll = New System.Windows.Forms.CheckBox()
        Me.lblFeatureCollection = New System.Windows.Forms.Label()
        Me.pnlComponentCollection = New System.Windows.Forms.Panel()
        Me.gceComponentCollection = New LocalUpdatePublisher.GuidCollectionEditor()
        Me.chkComponentCollection_requireAll = New System.Windows.Forms.CheckBox()
        Me.lblComponentCollection = New System.Windows.Forms.Label()
        Me.pnlProductCollection = New System.Windows.Forms.Panel()
        Me.gceProductCollection = New LocalUpdatePublisher.GuidCollectionEditor()
        Me.chkProductCollection_requireAll = New System.Windows.Forms.CheckBox()
        Me.lblProductCollection = New System.Windows.Forms.Label()
        Me.tlpMinVersion = New System.Windows.Forms.TableLayoutPanel()
        Me.lblMinVersion = New System.Windows.Forms.Label()
        Me.txtMinVersion = New System.Windows.Forms.TextBox()
        Me.tlpQuery = New System.Windows.Forms.TableLayoutPanel()
        Me.txtQuery = New System.Windows.Forms.TextBox()
        Me.lblQuery = New System.Windows.Forms.Label()
        Me.errorProviderRules = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpHeader.SuspendLayout()
        Me.tlpFooter.SuspendLayout()
        Me.tlpRules.SuspendLayout()
        Me.tlpComparison.SuspendLayout()
        Me.tlpOSVersion.SuspendLayout()
        Me.tlpServicePack.SuspendLayout()
        Me.tlpProductType.SuspendLayout()
        Me.tlpLanguage.SuspendLayout()
        Me.tlpProcessorType.SuspendLayout()
        Me.tlpRegistryKey.SuspendLayout()
        Me.tlpRegistryValue.SuspendLayout()
        Me.tlpRegistryValueType.SuspendLayout()
        Me.tlpEnvironmentVariable.SuspendLayout()
        Me.tlpFilePath.SuspendLayout()
        Me.tlpVersion.SuspendLayout()
        Me.tlpData.SuspendLayout()
        Me.tlpDate.SuspendLayout()
        Me.tlpProductCode.SuspendLayout()
        Me.tlpPatchCode.SuspendLayout()
        Me.tlpMaxVersion.SuspendLayout()
        Me.pnlFeatureCollection.SuspendLayout()
        Me.pnlComponentCollection.SuspendLayout()
        Me.pnlProductCollection.SuspendLayout()
        Me.tlpMinVersion.SuspendLayout()
        Me.tlpQuery.SuspendLayout()
        CType(Me.errorProviderRules, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpHeader
        '
        resources.ApplyResources(Me.tlpHeader, "tlpHeader")
        Me.tlpHeader.Controls.Add(Me.chkNotRule, 2, 0)
        Me.tlpHeader.Controls.Add(Me.cboRuleType, 1, 0)
        Me.tlpHeader.Controls.Add(Me.lblRuleType, 0, 0)
        Me.tlpHeader.Name = "tlpHeader"
        '
        'chkNotRule
        '
        resources.ApplyResources(Me.chkNotRule, "chkNotRule")
        Me.chkNotRule.Name = "chkNotRule"
        Me.chkNotRule.UseVisualStyleBackColor = True
        '
        'cboRuleType
        '
        Me.cboRuleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRuleType.FormattingEnabled = True
        resources.ApplyResources(Me.cboRuleType, "cboRuleType")
        Me.cboRuleType.Name = "cboRuleType"
        '
        'lblRuleType
        '
        resources.ApplyResources(Me.lblRuleType, "lblRuleType")
        Me.lblRuleType.Name = "lblRuleType"
        '
        'tlpFooter
        '
        resources.ApplyResources(Me.tlpFooter, "tlpFooter")
        Me.tlpFooter.Controls.Add(Me.btnCancel, 1, 0)
        Me.tlpFooter.Controls.Add(Me.btnAdd, 0, 0)
        Me.tlpFooter.Name = "tlpFooter"
        '
        'btnCancel
        '
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        resources.ApplyResources(Me.btnAdd, "btnAdd")
        Me.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'tlpRules
        '
        resources.ApplyResources(Me.tlpRules, "tlpRules")
        Me.tlpRules.Controls.Add(Me.tlpComparison, 0, 0)
        Me.tlpRules.Controls.Add(Me.tlpOSVersion, 0, 1)
        Me.tlpRules.Controls.Add(Me.tlpServicePack, 0, 2)
        Me.tlpRules.Controls.Add(Me.tlpProductType, 0, 3)
        Me.tlpRules.Controls.Add(Me.tlpLanguage, 0, 4)
        Me.tlpRules.Controls.Add(Me.tlpProcessorType, 0, 5)
        Me.tlpRules.Controls.Add(Me.tlpRegistryKey, 0, 6)
        Me.tlpRules.Controls.Add(Me.tlpRegistryValue, 0, 7)
        Me.tlpRules.Controls.Add(Me.tlpRegistryValueType, 0, 8)
        Me.tlpRules.Controls.Add(Me.tlpEnvironmentVariable, 0, 9)
        Me.tlpRules.Controls.Add(Me.tlpFilePath, 0, 10)
        Me.tlpRules.Controls.Add(Me.tlpVersion, 0, 11)
        Me.tlpRules.Controls.Add(Me.tlpData, 0, 12)
        Me.tlpRules.Controls.Add(Me.tlpDate, 0, 13)
        Me.tlpRules.Controls.Add(Me.tlpProductCode, 0, 15)
        Me.tlpRules.Controls.Add(Me.tlpPatchCode, 0, 16)
        Me.tlpRules.Controls.Add(Me.tlpMaxVersion, 0, 17)
        Me.tlpRules.Controls.Add(Me.pnlFeatureCollection, 0, 21)
        Me.tlpRules.Controls.Add(Me.pnlComponentCollection, 0, 20)
        Me.tlpRules.Controls.Add(Me.pnlProductCollection, 0, 19)
        Me.tlpRules.Controls.Add(Me.tlpMinVersion, 0, 18)
        Me.tlpRules.Controls.Add(Me.tlpQuery, 0, 14)
        Me.tlpRules.Name = "tlpRules"
        '
        'tlpComparison
        '
        resources.ApplyResources(Me.tlpComparison, "tlpComparison")
        Me.tlpComparison.Controls.Add(Me.cboComparison, 1, 0)
        Me.tlpComparison.Controls.Add(Me.lblComparison, 0, 0)
        Me.tlpComparison.Name = "tlpComparison"
        '
        'cboComparison
        '
        Me.cboComparison.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboComparison.FormattingEnabled = True
        resources.ApplyResources(Me.cboComparison, "cboComparison")
        Me.cboComparison.Name = "cboComparison"
        '
        'lblComparison
        '
        resources.ApplyResources(Me.lblComparison, "lblComparison")
        Me.lblComparison.Name = "lblComparison"
        '
        'tlpOSVersion
        '
        resources.ApplyResources(Me.tlpOSVersion, "tlpOSVersion")
        Me.tlpOSVersion.Controls.Add(Me.txtOSMinorVersion, 3, 0)
        Me.tlpOSVersion.Controls.Add(Me.lblOSVersion, 0, 0)
        Me.tlpOSVersion.Controls.Add(Me.txtOSMajorVersion, 2, 0)
        Me.tlpOSVersion.Controls.Add(Me.cboOSVersion, 1, 0)
        Me.tlpOSVersion.Name = "tlpOSVersion"
        '
        'txtOSMinorVersion
        '
        resources.ApplyResources(Me.txtOSMinorVersion, "txtOSMinorVersion")
        Me.txtOSMinorVersion.Name = "txtOSMinorVersion"
        '
        'lblOSVersion
        '
        resources.ApplyResources(Me.lblOSVersion, "lblOSVersion")
        Me.lblOSVersion.Name = "lblOSVersion"
        '
        'txtOSMajorVersion
        '
        resources.ApplyResources(Me.txtOSMajorVersion, "txtOSMajorVersion")
        Me.txtOSMajorVersion.Name = "txtOSMajorVersion"
        '
        'cboOSVersion
        '
        resources.ApplyResources(Me.cboOSVersion, "cboOSVersion")
        Me.cboOSVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOSVersion.FormattingEnabled = True
        Me.cboOSVersion.Items.AddRange(New Object() {resources.GetString("cboOSVersion.Items"), resources.GetString("cboOSVersion.Items1"), resources.GetString("cboOSVersion.Items2"), resources.GetString("cboOSVersion.Items3"), resources.GetString("cboOSVersion.Items4"), resources.GetString("cboOSVersion.Items5")})
        Me.cboOSVersion.Name = "cboOSVersion"
        '
        'tlpServicePack
        '
        resources.ApplyResources(Me.tlpServicePack, "tlpServicePack")
        Me.tlpServicePack.Controls.Add(Me.txtSPMinorVersion, 3, 0)
        Me.tlpServicePack.Controls.Add(Me.lblServicePack, 0, 0)
        Me.tlpServicePack.Controls.Add(Me.txtSPMajorVersion, 2, 0)
        Me.tlpServicePack.Controls.Add(Me.cboServicePack, 1, 0)
        Me.tlpServicePack.Name = "tlpServicePack"
        '
        'txtSPMinorVersion
        '
        resources.ApplyResources(Me.txtSPMinorVersion, "txtSPMinorVersion")
        Me.txtSPMinorVersion.Name = "txtSPMinorVersion"
        '
        'lblServicePack
        '
        resources.ApplyResources(Me.lblServicePack, "lblServicePack")
        Me.lblServicePack.Name = "lblServicePack"
        '
        'txtSPMajorVersion
        '
        resources.ApplyResources(Me.txtSPMajorVersion, "txtSPMajorVersion")
        Me.txtSPMajorVersion.Name = "txtSPMajorVersion"
        '
        'cboServicePack
        '
        resources.ApplyResources(Me.cboServicePack, "cboServicePack")
        Me.cboServicePack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServicePack.FormattingEnabled = True
        Me.cboServicePack.Items.AddRange(New Object() {resources.GetString("cboServicePack.Items"), resources.GetString("cboServicePack.Items1"), resources.GetString("cboServicePack.Items2"), resources.GetString("cboServicePack.Items3")})
        Me.cboServicePack.Name = "cboServicePack"
        '
        'tlpProductType
        '
        resources.ApplyResources(Me.tlpProductType, "tlpProductType")
        Me.tlpProductType.Controls.Add(Me.cboProductType, 1, 0)
        Me.tlpProductType.Controls.Add(Me.lblProductType, 0, 0)
        Me.tlpProductType.Name = "tlpProductType"
        '
        'cboProductType
        '
        Me.cboProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProductType.FormattingEnabled = True
        resources.ApplyResources(Me.cboProductType, "cboProductType")
        Me.cboProductType.Name = "cboProductType"
        '
        'lblProductType
        '
        resources.ApplyResources(Me.lblProductType, "lblProductType")
        Me.lblProductType.Name = "lblProductType"
        '
        'tlpLanguage
        '
        resources.ApplyResources(Me.tlpLanguage, "tlpLanguage")
        Me.tlpLanguage.Controls.Add(Me.cboLanguage, 1, 0)
        Me.tlpLanguage.Controls.Add(Me.lblLanguage, 0, 0)
        Me.tlpLanguage.Name = "tlpLanguage"
        '
        'cboLanguage
        '
        Me.cboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLanguage.FormattingEnabled = True
        resources.ApplyResources(Me.cboLanguage, "cboLanguage")
        Me.cboLanguage.Name = "cboLanguage"
        '
        'lblLanguage
        '
        resources.ApplyResources(Me.lblLanguage, "lblLanguage")
        Me.lblLanguage.Name = "lblLanguage"
        '
        'tlpProcessorType
        '
        resources.ApplyResources(Me.tlpProcessorType, "tlpProcessorType")
        Me.tlpProcessorType.Controls.Add(Me.cboProcessorType, 1, 0)
        Me.tlpProcessorType.Controls.Add(Me.lblProcessorType, 0, 0)
        Me.tlpProcessorType.Name = "tlpProcessorType"
        '
        'cboProcessorType
        '
        Me.cboProcessorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProcessorType.FormattingEnabled = True
        Me.cboProcessorType.Items.AddRange(New Object() {resources.GetString("cboProcessorType.Items"), resources.GetString("cboProcessorType.Items1"), resources.GetString("cboProcessorType.Items2")})
        resources.ApplyResources(Me.cboProcessorType, "cboProcessorType")
        Me.cboProcessorType.Name = "cboProcessorType"
        '
        'lblProcessorType
        '
        resources.ApplyResources(Me.lblProcessorType, "lblProcessorType")
        Me.lblProcessorType.Name = "lblProcessorType"
        '
        'tlpRegistryKey
        '
        resources.ApplyResources(Me.tlpRegistryKey, "tlpRegistryKey")
        Me.tlpRegistryKey.Controls.Add(Me.txtRegistrySubKey, 2, 0)
        Me.tlpRegistryKey.Controls.Add(Me.lblRegistryKey, 0, 0)
        Me.tlpRegistryKey.Controls.Add(Me.cboRegistryKey, 1, 0)
        Me.tlpRegistryKey.Name = "tlpRegistryKey"
        '
        'txtRegistrySubKey
        '
        resources.ApplyResources(Me.txtRegistrySubKey, "txtRegistrySubKey")
        Me.txtRegistrySubKey.Name = "txtRegistrySubKey"
        '
        'lblRegistryKey
        '
        resources.ApplyResources(Me.lblRegistryKey, "lblRegistryKey")
        Me.lblRegistryKey.Name = "lblRegistryKey"
        '
        'cboRegistryKey
        '
        resources.ApplyResources(Me.cboRegistryKey, "cboRegistryKey")
        Me.cboRegistryKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRegistryKey.FormattingEnabled = True
        Me.cboRegistryKey.Items.AddRange(New Object() {resources.GetString("cboRegistryKey.Items")})
        Me.cboRegistryKey.Name = "cboRegistryKey"
        '
        'tlpRegistryValue
        '
        resources.ApplyResources(Me.tlpRegistryValue, "tlpRegistryValue")
        Me.tlpRegistryValue.Controls.Add(Me.chkRegistry32Bit, 2, 0)
        Me.tlpRegistryValue.Controls.Add(Me.txtRegistryValue, 1, 0)
        Me.tlpRegistryValue.Controls.Add(Me.lblRegistryValue, 0, 0)
        Me.tlpRegistryValue.Name = "tlpRegistryValue"
        '
        'chkRegistry32Bit
        '
        resources.ApplyResources(Me.chkRegistry32Bit, "chkRegistry32Bit")
        Me.chkRegistry32Bit.Name = "chkRegistry32Bit"
        Me.chkRegistry32Bit.UseVisualStyleBackColor = True
        '
        'txtRegistryValue
        '
        resources.ApplyResources(Me.txtRegistryValue, "txtRegistryValue")
        Me.txtRegistryValue.Name = "txtRegistryValue"
        '
        'lblRegistryValue
        '
        resources.ApplyResources(Me.lblRegistryValue, "lblRegistryValue")
        Me.lblRegistryValue.Name = "lblRegistryValue"
        '
        'tlpRegistryValueType
        '
        resources.ApplyResources(Me.tlpRegistryValueType, "tlpRegistryValueType")
        Me.tlpRegistryValueType.Controls.Add(Me.cboRegistryValueType, 1, 0)
        Me.tlpRegistryValueType.Controls.Add(Me.lblRegistryValueType, 0, 0)
        Me.tlpRegistryValueType.Name = "tlpRegistryValueType"
        '
        'cboRegistryValueType
        '
        Me.cboRegistryValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRegistryValueType.FormattingEnabled = True
        Me.cboRegistryValueType.Items.AddRange(New Object() {resources.GetString("cboRegistryValueType.Items"), resources.GetString("cboRegistryValueType.Items1"), resources.GetString("cboRegistryValueType.Items2"), resources.GetString("cboRegistryValueType.Items3")})
        resources.ApplyResources(Me.cboRegistryValueType, "cboRegistryValueType")
        Me.cboRegistryValueType.Name = "cboRegistryValueType"
        '
        'lblRegistryValueType
        '
        resources.ApplyResources(Me.lblRegistryValueType, "lblRegistryValueType")
        Me.lblRegistryValueType.MinimumSize = Me.lblRegistryValueType.Size
        Me.lblRegistryValueType.Name = "lblRegistryValueType"
        '
        'tlpEnvironmentVariable
        '
        resources.ApplyResources(Me.tlpEnvironmentVariable, "tlpEnvironmentVariable")
        Me.tlpEnvironmentVariable.Controls.Add(Me.cboEnvironmentVariable, 1, 0)
        Me.tlpEnvironmentVariable.Controls.Add(Me.lblEnvironmentVariable, 0, 0)
        Me.tlpEnvironmentVariable.Name = "tlpEnvironmentVariable"
        '
        'cboEnvironmentVariable
        '
        Me.cboEnvironmentVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEnvironmentVariable.FormattingEnabled = True
        resources.ApplyResources(Me.cboEnvironmentVariable, "cboEnvironmentVariable")
        Me.cboEnvironmentVariable.Name = "cboEnvironmentVariable"
        '
        'lblEnvironmentVariable
        '
        resources.ApplyResources(Me.lblEnvironmentVariable, "lblEnvironmentVariable")
        Me.lblEnvironmentVariable.Name = "lblEnvironmentVariable"
        '
        'tlpFilePath
        '
        resources.ApplyResources(Me.tlpFilePath, "tlpFilePath")
        Me.tlpFilePath.Controls.Add(Me.txtFilePath, 1, 0)
        Me.tlpFilePath.Controls.Add(Me.lblPath, 0, 0)
        Me.tlpFilePath.Name = "tlpFilePath"
        '
        'txtFilePath
        '
        resources.ApplyResources(Me.txtFilePath, "txtFilePath")
        Me.txtFilePath.Name = "txtFilePath"
        '
        'lblPath
        '
        resources.ApplyResources(Me.lblPath, "lblPath")
        Me.lblPath.Name = "lblPath"
        '
        'tlpVersion
        '
        resources.ApplyResources(Me.tlpVersion, "tlpVersion")
        Me.tlpVersion.Controls.Add(Me.txtVersion, 1, 0)
        Me.tlpVersion.Controls.Add(Me.lblVersion, 0, 0)
        Me.tlpVersion.Name = "tlpVersion"
        '
        'txtVersion
        '
        resources.ApplyResources(Me.txtVersion, "txtVersion")
        Me.txtVersion.Name = "txtVersion"
        '
        'lblVersion
        '
        resources.ApplyResources(Me.lblVersion, "lblVersion")
        Me.lblVersion.Name = "lblVersion"
        '
        'tlpData
        '
        resources.ApplyResources(Me.tlpData, "tlpData")
        Me.tlpData.Controls.Add(Me.lblDataInfo, 2, 0)
        Me.tlpData.Controls.Add(Me.txtData, 1, 0)
        Me.tlpData.Controls.Add(Me.lblData, 0, 0)
        Me.tlpData.Name = "tlpData"
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
        '
        'lblData
        '
        resources.ApplyResources(Me.lblData, "lblData")
        Me.lblData.Name = "lblData"
        '
        'tlpDate
        '
        resources.ApplyResources(Me.tlpDate, "tlpDate")
        Me.tlpDate.Controls.Add(Me.dtpDate, 1, 0)
        Me.tlpDate.Controls.Add(Me.lblDate, 0, 0)
        Me.tlpDate.Name = "tlpDate"
        '
        'dtpDate
        '
        Me.dtpDate.Checked = False
        Me.dtpDate.Cursor = System.Windows.Forms.Cursors.IBeam
        resources.ApplyResources(Me.dtpDate, "dtpDate")
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.ShowCheckBox = True
        '
        'lblDate
        '
        resources.ApplyResources(Me.lblDate, "lblDate")
        Me.lblDate.Name = "lblDate"
        '
        'tlpProductCode
        '
        resources.ApplyResources(Me.tlpProductCode, "tlpProductCode")
        Me.tlpProductCode.Controls.Add(Me.txtProductCode, 1, 0)
        Me.tlpProductCode.Controls.Add(Me.lblProductCode, 0, 0)
        Me.tlpProductCode.Name = "tlpProductCode"
        '
        'txtProductCode
        '
        resources.ApplyResources(Me.txtProductCode, "txtProductCode")
        Me.txtProductCode.Name = "txtProductCode"
        '
        'lblProductCode
        '
        resources.ApplyResources(Me.lblProductCode, "lblProductCode")
        Me.lblProductCode.Name = "lblProductCode"
        '
        'tlpPatchCode
        '
        resources.ApplyResources(Me.tlpPatchCode, "tlpPatchCode")
        Me.tlpPatchCode.Controls.Add(Me.txtPatchCode, 1, 0)
        Me.tlpPatchCode.Controls.Add(Me.lblPatchCode, 0, 0)
        Me.tlpPatchCode.Name = "tlpPatchCode"
        '
        'txtPatchCode
        '
        resources.ApplyResources(Me.txtPatchCode, "txtPatchCode")
        Me.txtPatchCode.Name = "txtPatchCode"
        '
        'lblPatchCode
        '
        resources.ApplyResources(Me.lblPatchCode, "lblPatchCode")
        Me.lblPatchCode.Name = "lblPatchCode"
        '
        'tlpMaxVersion
        '
        resources.ApplyResources(Me.tlpMaxVersion, "tlpMaxVersion")
        Me.tlpMaxVersion.Controls.Add(Me.txtMaxVersion, 1, 0)
        Me.tlpMaxVersion.Controls.Add(Me.lblMaxVersion, 0, 0)
        Me.tlpMaxVersion.Name = "tlpMaxVersion"
        '
        'txtMaxVersion
        '
        resources.ApplyResources(Me.txtMaxVersion, "txtMaxVersion")
        Me.txtMaxVersion.Name = "txtMaxVersion"
        '
        'lblMaxVersion
        '
        resources.ApplyResources(Me.lblMaxVersion, "lblMaxVersion")
        Me.lblMaxVersion.Name = "lblMaxVersion"
        '
        'pnlFeatureCollection
        '
        resources.ApplyResources(Me.pnlFeatureCollection, "pnlFeatureCollection")
        Me.pnlFeatureCollection.Controls.Add(Me.gceFeatureCollection)
        Me.pnlFeatureCollection.Controls.Add(Me.chkFeatureCollection_requireAll)
        Me.pnlFeatureCollection.Controls.Add(Me.lblFeatureCollection)
        Me.pnlFeatureCollection.Name = "pnlFeatureCollection"
        '
        'gceFeatureCollection
        '
        Me.gceFeatureCollection.Header = "Feature Name"
        Me.gceFeatureCollection.Items = CType(resources.GetObject("gceFeatureCollection.Items"), System.Collections.Generic.List(Of String))
        resources.ApplyResources(Me.gceFeatureCollection, "gceFeatureCollection")
        Me.gceFeatureCollection.Name = "gceFeatureCollection"
        Me.gceFeatureCollection.RequireAtLeastOne = True
        Me.gceFeatureCollection.RequireGuids = False
        '
        'chkFeatureCollection_requireAll
        '
        resources.ApplyResources(Me.chkFeatureCollection_requireAll, "chkFeatureCollection_requireAll")
        Me.chkFeatureCollection_requireAll.Name = "chkFeatureCollection_requireAll"
        Me.chkFeatureCollection_requireAll.UseVisualStyleBackColor = True
        '
        'lblFeatureCollection
        '
        resources.ApplyResources(Me.lblFeatureCollection, "lblFeatureCollection")
        Me.lblFeatureCollection.Name = "lblFeatureCollection"
        '
        'pnlComponentCollection
        '
        resources.ApplyResources(Me.pnlComponentCollection, "pnlComponentCollection")
        Me.pnlComponentCollection.Controls.Add(Me.gceComponentCollection)
        Me.pnlComponentCollection.Controls.Add(Me.chkComponentCollection_requireAll)
        Me.pnlComponentCollection.Controls.Add(Me.lblComponentCollection)
        Me.pnlComponentCollection.Name = "pnlComponentCollection"
        '
        'gceComponentCollection
        '
        Me.gceComponentCollection.Header = "Component Codes"
        Me.gceComponentCollection.Items = CType(resources.GetObject("gceComponentCollection.Items"), System.Collections.Generic.List(Of String))
        resources.ApplyResources(Me.gceComponentCollection, "gceComponentCollection")
        Me.gceComponentCollection.Name = "gceComponentCollection"
        Me.gceComponentCollection.RequireAtLeastOne = True
        Me.gceComponentCollection.RequireGuids = True
        '
        'chkComponentCollection_requireAll
        '
        resources.ApplyResources(Me.chkComponentCollection_requireAll, "chkComponentCollection_requireAll")
        Me.chkComponentCollection_requireAll.Name = "chkComponentCollection_requireAll"
        Me.chkComponentCollection_requireAll.UseVisualStyleBackColor = True
        '
        'lblComponentCollection
        '
        resources.ApplyResources(Me.lblComponentCollection, "lblComponentCollection")
        Me.lblComponentCollection.Name = "lblComponentCollection"
        '
        'pnlProductCollection
        '
        resources.ApplyResources(Me.pnlProductCollection, "pnlProductCollection")
        Me.pnlProductCollection.Controls.Add(Me.gceProductCollection)
        Me.pnlProductCollection.Controls.Add(Me.chkProductCollection_requireAll)
        Me.pnlProductCollection.Controls.Add(Me.lblProductCollection)
        Me.pnlProductCollection.Name = "pnlProductCollection"
        '
        'gceProductCollection
        '
        Me.gceProductCollection.Header = "Product Codes"
        Me.gceProductCollection.Items = CType(resources.GetObject("gceProductCollection.Items"), System.Collections.Generic.List(Of String))
        resources.ApplyResources(Me.gceProductCollection, "gceProductCollection")
        Me.gceProductCollection.Name = "gceProductCollection"
        Me.gceProductCollection.RequireAtLeastOne = True
        Me.gceProductCollection.RequireGuids = True
        '
        'chkProductCollection_requireAll
        '
        resources.ApplyResources(Me.chkProductCollection_requireAll, "chkProductCollection_requireAll")
        Me.chkProductCollection_requireAll.Name = "chkProductCollection_requireAll"
        Me.chkProductCollection_requireAll.UseVisualStyleBackColor = True
        '
        'lblProductCollection
        '
        resources.ApplyResources(Me.lblProductCollection, "lblProductCollection")
        Me.lblProductCollection.Name = "lblProductCollection"
        '
        'tlpMinVersion
        '
        resources.ApplyResources(Me.tlpMinVersion, "tlpMinVersion")
        Me.tlpMinVersion.Controls.Add(Me.lblMinVersion, 0, 0)
        Me.tlpMinVersion.Controls.Add(Me.txtMinVersion, 1, 0)
        Me.tlpMinVersion.Name = "tlpMinVersion"
        '
        'lblMinVersion
        '
        resources.ApplyResources(Me.lblMinVersion, "lblMinVersion")
        Me.lblMinVersion.Name = "lblMinVersion"
        '
        'txtMinVersion
        '
        resources.ApplyResources(Me.txtMinVersion, "txtMinVersion")
        Me.txtMinVersion.Name = "txtMinVersion"
        '
        'tlpQuery
        '
        resources.ApplyResources(Me.tlpQuery, "tlpQuery")
        Me.tlpQuery.Controls.Add(Me.txtQuery, 1, 0)
        Me.tlpQuery.Controls.Add(Me.lblQuery, 0, 0)
        Me.tlpQuery.Name = "tlpQuery"
        '
        'txtQuery
        '
        Me.txtQuery.AcceptsReturn = True
        Me.txtQuery.AcceptsTab = True
        resources.ApplyResources(Me.txtQuery, "txtQuery")
        Me.txtQuery.Name = "txtQuery"
        '
        'lblQuery
        '
        resources.ApplyResources(Me.lblQuery, "lblQuery")
        Me.lblQuery.Name = "lblQuery"
        '
        'errorProviderRules
        '
        Me.errorProviderRules.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.errorProviderRules.ContainerControl = Me
        '
        'tlpMain
        '
        resources.ApplyResources(Me.tlpMain, "tlpMain")
        Me.tlpMain.Controls.Add(Me.tlpHeader, 0, 0)
        Me.tlpMain.Controls.Add(Me.tlpFooter, 0, 2)
        Me.tlpMain.Controls.Add(Me.tlpRules, 0, 1)
        Me.tlpMain.Name = "tlpMain"
        '
        'RulesForm
        '
        Me.AcceptButton = Me.btnAdd
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.Controls.Add(Me.tlpMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RulesForm"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.tlpHeader.ResumeLayout(False)
        Me.tlpHeader.PerformLayout()
        Me.tlpFooter.ResumeLayout(False)
        Me.tlpFooter.PerformLayout()
        Me.tlpRules.ResumeLayout(False)
        Me.tlpRules.PerformLayout()
        Me.tlpComparison.ResumeLayout(False)
        Me.tlpComparison.PerformLayout()
        Me.tlpOSVersion.ResumeLayout(False)
        Me.tlpOSVersion.PerformLayout()
        Me.tlpServicePack.ResumeLayout(False)
        Me.tlpServicePack.PerformLayout()
        Me.tlpProductType.ResumeLayout(False)
        Me.tlpProductType.PerformLayout()
        Me.tlpLanguage.ResumeLayout(False)
        Me.tlpLanguage.PerformLayout()
        Me.tlpProcessorType.ResumeLayout(False)
        Me.tlpProcessorType.PerformLayout()
        Me.tlpRegistryKey.ResumeLayout(False)
        Me.tlpRegistryKey.PerformLayout()
        Me.tlpRegistryValue.ResumeLayout(False)
        Me.tlpRegistryValue.PerformLayout()
        Me.tlpRegistryValueType.ResumeLayout(False)
        Me.tlpRegistryValueType.PerformLayout()
        Me.tlpEnvironmentVariable.ResumeLayout(False)
        Me.tlpEnvironmentVariable.PerformLayout()
        Me.tlpFilePath.ResumeLayout(False)
        Me.tlpFilePath.PerformLayout()
        Me.tlpVersion.ResumeLayout(False)
        Me.tlpVersion.PerformLayout()
        Me.tlpData.ResumeLayout(False)
        Me.tlpData.PerformLayout()
        Me.tlpDate.ResumeLayout(False)
        Me.tlpDate.PerformLayout()
        Me.tlpProductCode.ResumeLayout(False)
        Me.tlpProductCode.PerformLayout()
        Me.tlpPatchCode.ResumeLayout(False)
        Me.tlpPatchCode.PerformLayout()
        Me.tlpMaxVersion.ResumeLayout(False)
        Me.tlpMaxVersion.PerformLayout()
        Me.pnlFeatureCollection.ResumeLayout(False)
        Me.pnlComponentCollection.ResumeLayout(False)
        Me.pnlProductCollection.ResumeLayout(False)
        Me.tlpMinVersion.ResumeLayout(False)
        Me.tlpMinVersion.PerformLayout()
        Me.tlpQuery.ResumeLayout(False)
        Me.tlpQuery.PerformLayout()
        CType(Me.errorProviderRules, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblPath As System.Windows.Forms.Label
    Private WithEvents lblOSVersion As System.Windows.Forms.Label
    Private WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpRules As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpHeader As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpFooter As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpOSVersion As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpComparison As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpServicePack As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpQuery As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpMinVersion As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpMaxVersion As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpPatchCode As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpProductCode As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpDate As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpData As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpVersion As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpFilePath As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpEnvironmentVariable As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpRegistryValueType As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpRegistryValue As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpRegistryKey As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpProcessorType As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpLanguage As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpProductType As System.Windows.Forms.TableLayoutPanel
    Private WithEvents errorProviderRules As System.Windows.Forms.ErrorProvider
    Private WithEvents chkComponentCollection_requireAll As System.Windows.Forms.CheckBox
    Private WithEvents lblComponentCollection As System.Windows.Forms.Label
    Private WithEvents chkFeatureCollection_requireAll As System.Windows.Forms.CheckBox
    Private WithEvents lblFeatureCollection As System.Windows.Forms.Label
    Private WithEvents pnlProductCollection As System.Windows.Forms.Panel
    Private WithEvents gceFeatureCollection As LocalUpdatePublisher.GuidCollectionEditor
    Private WithEvents pnlFeatureCollection As System.Windows.Forms.Panel
    Private WithEvents gceComponentCollection As LocalUpdatePublisher.GuidCollectionEditor
    Private WithEvents pnlComponentCollection As System.Windows.Forms.Panel
    Private WithEvents gceProductCollection As LocalUpdatePublisher.GuidCollectionEditor
    Private WithEvents lblProductCode As System.Windows.Forms.Label
    Private WithEvents txtProductCode As System.Windows.Forms.TextBox
    Private WithEvents lblPatchCode As System.Windows.Forms.Label
    Private WithEvents txtPatchCode As System.Windows.Forms.TextBox
    Private WithEvents lblMaxVersion As System.Windows.Forms.Label
    Private WithEvents txtMaxVersion As System.Windows.Forms.TextBox
    Private WithEvents lblMinVersion As System.Windows.Forms.Label
    Private WithEvents txtMinVersion As System.Windows.Forms.TextBox
    Private WithEvents lblProductCollection As System.Windows.Forms.Label
    Private WithEvents chkProductCollection_requireAll As System.Windows.Forms.CheckBox
    Private WithEvents cboProductType As System.Windows.Forms.ComboBox
    Private WithEvents cboRegistryKey As System.Windows.Forms.ComboBox
    Private WithEvents cboEnvironmentVariable As System.Windows.Forms.ComboBox
    Private WithEvents cboRuleType As System.Windows.Forms.ComboBox
    Private WithEvents cboServicePack As System.Windows.Forms.ComboBox
    Private WithEvents cboOSVersion As System.Windows.Forms.ComboBox
    Private WithEvents cboComparison As System.Windows.Forms.ComboBox
    Private WithEvents cboProcessorType As System.Windows.Forms.ComboBox
    Private WithEvents cboLanguage As System.Windows.Forms.ComboBox
    Private WithEvents cboRegistryValueType As System.Windows.Forms.ComboBox
    Private WithEvents lblRegistryValueType As System.Windows.Forms.Label
    Private WithEvents lblProcessorType As System.Windows.Forms.Label
    Private WithEvents lblLanguage As System.Windows.Forms.Label
    Private WithEvents lblVersion As System.Windows.Forms.Label
    Private WithEvents txtVersion As System.Windows.Forms.TextBox
    Private WithEvents txtSPMajorVersion As System.Windows.Forms.TextBox
    Private WithEvents txtSPMinorVersion As System.Windows.Forms.TextBox
    Private WithEvents txtOSMinorVersion As System.Windows.Forms.TextBox
    Private WithEvents txtOSMajorVersion As System.Windows.Forms.TextBox
    Private WithEvents lblServicePack As System.Windows.Forms.Label
    Private WithEvents lblComparison As System.Windows.Forms.Label
    Private WithEvents lblEnvironmentVariable As System.Windows.Forms.Label
    Private WithEvents txtQuery As System.Windows.Forms.TextBox
    Private WithEvents lblQuery As System.Windows.Forms.Label
    Private WithEvents lblProductType As System.Windows.Forms.Label
    Private WithEvents txtRegistryValue As System.Windows.Forms.TextBox
    Private WithEvents lblRegistryValue As System.Windows.Forms.Label
    Private WithEvents chkRegistry32Bit As System.Windows.Forms.CheckBox
    Private WithEvents txtRegistrySubKey As System.Windows.Forms.TextBox
    Private WithEvents lblRegistryKey As System.Windows.Forms.Label
    Private WithEvents txtFilePath As System.Windows.Forms.TextBox
    Private WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Private WithEvents lblDate As System.Windows.Forms.Label
    Private WithEvents lblDataInfo As System.Windows.Forms.Label
    Private WithEvents txtData As System.Windows.Forms.TextBox
    Private WithEvents lblData As System.Windows.Forms.Label
    Private WithEvents btnCancel As System.Windows.Forms.Button
    Private WithEvents btnAdd As System.Windows.Forms.Button
    Private WithEvents chkNotRule As System.Windows.Forms.CheckBox
    Private WithEvents lblRuleType As System.Windows.Forms.Label
	
End Class
