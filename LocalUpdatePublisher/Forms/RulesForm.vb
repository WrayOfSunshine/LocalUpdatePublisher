' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' RulesForm
' This form allows the user to create the rules used
' to create the software distribution package.  It creates
' both a human readable rule for the rule DGVs to show
' as well as the XML fragment needed for the SDP.
' Currently, only basic WSUS rules are supported.
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 11/12/2009
' Time: 11:10 AM
' kdixon added MSI rules Jan 10

Imports System.Xml
Imports System.IO
Imports System.ComponentModel

Public Partial Class RulesForm
	Private ReadOnly _scalarComparison As String ()
	Private ReadOnly _stringComparison As String ()
	Private ReadOnly _productTypes As String ()
	
	#REGION "Properties"
	Private _readableRule As String
	ReadOnly Property ReadableRule()  As String
		Get
			Return _readableRule
		End Get
	End Property
	
	Private _xmlRule As String
	ReadOnly Property XmlRule()  As String
		Get
			Return _xmlRule
		End Get
	End Property
	#END Region
	
	Public Sub New()
		Call Me.New(globalRM.GetString("create_rule"))
	End Sub
	
	Public Sub New(title As String )
		'Set the ReadOnly string arrays for the comboboxes.
		' Currently we use the first item to test if the array is already
		' loaded into the combobox.
		_scalarComparison =  New String() {globalRM.GetString("equal_to"), globalRM.GetString("less_than"), globalRM.GetString("less_than_or_equal_to"), globalRM.GetString("greater_than"), globalRM.GetString("greater_than_or_equal_to")}
		_stringComparison =  New String() {globalRM.GetString("begins_with"), globalRM.GetString("ends_with"), globalRM.GetString("contains"), globalRM.GetString("equal_to")}
		_productTypes =  New String() {globalRM.GetString("none"), globalRM.GetString("workstation"), globalRM.GetString("domain_controller"), globalRM.GetString("server")}
		
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		Me.Text = title
		
		'Set comboboxes
		Me.cboProductType.Items.AddRange(_productTypes)
		Me.cboLanguage.Items.AddRange(Languages.Names)
		
		'Set the Environment variable data source.
		Me.cboEnvironmentVariable.DataSource = GetSortedEnum(GetType(CSIDL))
		Me.cboEnvironmentVariable.SelectedIndex = -1
		
		'Load the Rule Types into the combo box based on the Enum.
		For Each tmpRuleType As String In [Enum].GetNames(GetType(RuleTypes))
			cboRuleType.Items.Add([Enum].Parse(GetType(RuleTypes), tmpRuleType))
		Next
		
		'Set localized strings.		
		Me.gceProductCollection.Header = globalRM.GetString("product_codes")
		Me.gceComponentCollection.Header = globalRM.GetString("component_codes")
		Me.gceFeatureCollection.Header = globalRM.GetString("feature_names")
		
		Call ValidateFields
	End Sub
	
	#Region "Events"
	
	'If a rule is passed then load it.
	Public Overloads Function ShowDialog(owner As IWin32Window, ruleXml As String) As DialogResult
		ClearForm()
		If String.IsNullOrEmpty(ruleXml) Then
			Me.btnAdd.Text = globalRM.GetString("add_rule")
		Else
			Me.btnAdd.Text = globalRM.GetString("save_rule")
			If Not LoadRule(ruleXml) Then
				Return DialogResult.Abort
			End If
		End If
		If owner Is Nothing Then
			Return MyBase.ShowDialog()
		Else
			Return MyBase.ShowDialog(owner)
		End If
	End Function
	
	'Clear the form of any existing data.
	Sub ClearForm
		Me.cboRuleType.SelectedIndex = - 1
		Me.cboServicePack.SelectedIndex = - 1
		Me.cboOSVersion.SelectedIndex = - 1
		Me.cboComparison.SelectedIndex = - 1
		Me.cboLanguage.SelectedIndex = - 1
		Me.cboProcessorType.SelectedIndex = - 1
		Me.cboEnvironmentVariable.SelectedIndex = - 1
		Me.cboRegistryValueType.SelectedIndex = - 1
		Me.cboRegistryKey.SelectedIndex = - 1
		Me.chkNotRule.Checked = False
		Me.chkRegistry32Bit.Checked = False
		Me.dtpDate.Text = ""
		Me.txtSPMinorVersion.Text = ""
		Me.txtSPMajorVersion.Text = ""
		Me.txtOSMinorVersion.Text = ""
		Me.txtOSMajorVersion.Text = ""
		Me.txtVersion.Text = ""
		Me.txtRegistryValue.Text = ""
		Me.txtRegistrySubKey.Text = ""
		Me.txtFilePath.Text = ""
		Me.txtData.Text = ""
		Me.txtQuery.Text = ""
		Me.txtMaxVersion.Text = ""
		Me.txtMinVersion.Text = ""
		Me.txtProductCode.Text = ""
		Me.txtPatchCode.Text = ""
		Me.gceComponentCollection.Items = Nothing
		Me.gceFeatureCollection.Items = Nothing
		Me.gceProductCollection.Items = Nothing
	End Sub
	
	'When the user chooses a rule type we need to rearrange
	' the form to show/hide and position the appropriate controls
	' and change the occasional label text.  The controls have been
	' grouped into rows of the table layout panel so that we can manipulate groupings
	' of controls rather than individual ones.  We loop through the controls
	' looking for the ones we need shown and then hide the rest.
	Private Sub cboRuleTypeSelectedIndexChanged(sender As Object, e As EventArgs)
		'Loop through each panel on the lower split-panel.  Hide the panels we don't
		' need and position the items that we do need.
		If Me.cboRuleType.SelectedIndex >= 0 Then 'The combobox must be populated.
			
			'Setup the panel based on the selection from the combobox.
			Select Case Me.cboRuleType.SelectedIndex
				Case RuleTypes.WindowsVersion
					For Each controlObject As Control In Me.tlpRules.Controls
						Select Case controlObject.Name
							Case "tlpComparison"
								
								'Only change if we need to by testing to see if the
								' first element needed already exists in the combobox.
								If Not Me.cboComparison.Items.Count = _scalarComparison.Length Then
									'Me.cboComparison.SelectedIndex = -1
									Me.cboComparison.Items.Clear
									Me.cboComparison.Items.AddRange(_scalarComparison)
								End If
								controlObject.TabIndex = 0
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpOSVersion"
								controlObject.TabIndex = 1
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpServicePack"
								controlObject.TabIndex = 2
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpData"
								
								controlObject.TabIndex = 3
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								Me.txtData.Width = Me.txtVersion.Width
								
								If Not Me.lblData.Text = globalRM.GetString("build_number") Then
									Me.txtData.Text = ""
									Me.lblData.Text = globalRM.GetString("build_number")
								End If
								
								Me.lblDataInfo.Hide
								controlObject.Show
							Case "tlpProductType"
								controlObject.TabIndex = 4
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.WindowsLanguage
					For Each controlObject As Control In Me.tlpRules.Controls
						Select Case controlObject.Name
							Case "tlpLanguage"
								controlObject.Show
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.ProcessorArchitecture
					For Each controlObject As Control In Me.tlpRules.Controls
						Select Case controlObject.Name
							Case "tlpProcessorType"
								controlObject.Show
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.FileExists
					For Each controlObject As Control In Me.tlpRules.Controls
						Select Case controlObject.Name
							Case "tlpEnvironmentVariable"
								controlObject.TabIndex = 0
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpFilePath"
								controlObject.TabIndex = 1
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpVersion"
								controlObject.TabIndex = 2
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.FileExistsWithRegistry
					For Each controlObject As Control In Me.tlpRules.Controls
						Select Case controlObject.Name
							Case "tlpRegistryKey"
								controlObject.TabIndex = 0
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpRegistryValue"
								controlObject.TabIndex = 1
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpRegistry32Bit"
								controlObject.TabIndex = 2
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
								controlObject.Left = Me.tlpRegistryValue.Left + Me.tlpRegistryValue.Width + 5
							Case "tlpFilePath"
								controlObject.TabIndex = 3
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpVersion"
								controlObject.TabIndex = 4
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.FileCreation
					For Each controlObject As Control In Me.tlpRules.Controls
						Select Case controlObject.Name
							Case "tlpEnvironmentVariable"
								controlObject.TabIndex =0
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpFilePath"
								controlObject.TabIndex = 1
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpComparison"
								'Only change if we need to by testing to see if the
								' first element needed already exists in the combobox
								If Not Me.cboComparison.Items.Count = _scalarComparison.Length Then
									Me.cboComparison.Items.Clear
									Me.cboComparison.Items.AddRange(_scalarComparison)
								End If
								
								controlObject.TabIndex = 2
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpDate"
								controlObject.TabIndex = 3
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								Me.lblDate.Text = globalRM.GetString("creation_date")
								controlObject.Show
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.FileCreationWithRegistry
					For Each controlObject As Control In Me.tlpRules.Controls
						Select Case controlObject.Name
							Case "tlpRegistryKey"
								controlObject.TabIndex = 0
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpRegistryValue"
								controlObject.TabIndex = 1
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpRegistry32Bit"
								controlObject.TabIndex = 2
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
								controlObject.Left = Me.tlpRegistryValue.Left + Me.tlpRegistryValue.Width + 5
							Case "tlpFilePath"
								controlObject.TabIndex = 3
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpComparison"
								'Only change if we need to by testing to see if the
								' first element needed already exists in the combobox.
								If Not Me.cboComparison.Items.Count = _scalarComparison.Length Then
									Me.cboComparison.Items.Clear
									Me.cboComparison.Items.AddRange(_scalarComparison)
								End If
								
								controlObject.TabIndex = 4
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpDate"
								controlObject.TabIndex = 5
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								Me.lblDate.Text = globalRM.GetString("creation_date")
								controlObject.Show
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.FileModified
					For Each controlObject As Control In Me.tlpRules.Controls
						Select Case controlObject.Name
							Case "tlpEnvironmentVariable"
								controlObject.TabIndex = 0
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpFilePath"
								controlObject.TabIndex = 1
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpComparison"
								'Only change if we need to by testing to see if the
								' first element needed already exists in the combobox.
								If Not Me.cboComparison.Items.Count = _scalarComparison.Length Then
									Me.cboComparison.Items.Clear
									Me.cboComparison.Items.AddRange(_scalarComparison)
								End If
								
								controlObject.TabIndex = 2
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpDate"
								controlObject.TabIndex = 3
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								Me.lblDate.Text = globalRM.GetString("modified_date")
								controlObject.Show
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.FileModifiedWithRegistry
					For Each controlObject As Control In Me.tlpRules.Controls
						Select Case controlObject.Name
							Case "tlpRegistryKey"
								controlObject.TabIndex = 0
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpRegistryValue"
								controlObject.TabIndex = 1
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpRegistry32Bit"
								controlObject.TabIndex = 2
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
								controlObject.Left = Me.tlpRegistryValue.Left + Me.tlpRegistryValue.Width + 5
							Case "tlpRegistry32Bit"
								controlObject.TabIndex = 3
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
								controlObject.Left = Me.tlpRegistryValue.Left + Me.tlpRegistryValue.Width + 5
							Case "tlpFilePath"
								controlObject.TabIndex = 4
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpComparison"
								'Only change if we need to by testing to see if the
								' first element needed already exists in the combobox.
								If Not Me.cboComparison.Items.Count = _scalarComparison.Length Then
									Me.cboComparison.Items.Clear
									Me.cboComparison.Items.AddRange(_scalarComparison)
								End If
								
								controlObject.TabIndex = 5
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpDate"
								controlObject.TabIndex = 6
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								Me.lblDate.Text = globalRM.GetString("modified_date")
								controlObject.Show
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.FileSize
					For Each controlObject As Control In Me.tlpRules.Controls
						Select Case controlObject.Name
							Case "tlpEnvironmentVariable"
								controlObject.TabIndex = 0
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpFilePath"
								controlObject.TabIndex = 1
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpComparison"
								'Only change if we need to by testing to see if the
								' first element needed already exists in the combobox.
								If Not Me.cboComparison.Items.Count = _scalarComparison.Length Then
									Me.cboComparison.Items.Clear
									Me.cboComparison.Items.AddRange(_scalarComparison)
								End If
								
								controlObject.TabIndex = 2
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpData"
								controlObject.TabIndex = 3
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								Me.txtData.Width = Me.txtVersion.Width
								
								If Not Me.lblData.Text = globalRM.GetString("size") Then
									Me.txtData.Text = ""
									Me.lblData.Text = globalRM.GetString("size")
								End If
								
								Me.lblDataInfo.Text = globalRM.GetString("in_bytes_example")
								Me.lblDataInfo.Show
								controlObject.Show
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.FileSizeWithRegistry
					For Each controlObject As Control In Me.tlpRules.Controls
						Select Case controlObject.Name
							Case "tlpRegistryKey"
								controlObject.TabIndex = 0
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpRegistryValue"
								controlObject.TabIndex = 1
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpRegistry32Bit"
								controlObject.TabIndex = 2
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
								controlObject.Left = Me.tlpRegistryValue.Left + Me.tlpRegistryValue.Width + 5
							Case "tlpFilePath"
								controlObject.TabIndex = 3
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpComparison"
								'Only change if we need to by testing to see if the
								' first element needed already exists in the combobox.
								If Not Me.cboComparison.Items.Count = _scalarComparison.Length Then
									Me.cboComparison.Items.Clear
									Me.cboComparison.Items.AddRange(_scalarComparison)
								End If
								
								controlObject.TabIndex = 4
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpData"
								controlObject.TabIndex = 5
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								Me.txtData.Width = Me.txtVersion.Width
								
								If Not Me.lblData.Text = globalRM.GetString("size") Then
									Me.txtData.Text = ""
									Me.lblData.Text = globalRM.GetString("size")
								End If
								
								Me.lblDataInfo.Text = globalRM.GetString("in_bytes_example")
								Me.lblDataInfo.Show
								controlObject.Show
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.FileVersion
					For Each controlObject As Control In Me.tlpRules.Controls
						Select Case controlObject.Name
							Case "tlpEnvironmentVariable"
								controlObject.TabIndex = 0
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
								'controlObject.Top = _startingYConstant
							Case "tlpFilePath"
								controlObject.TabIndex = 1
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpComparison"
								'Only change if we need to by testing to see if the
								' first element needed already exists in the combobox.
								If Not Me.cboComparison.Items.Count = _scalarComparison.Length Then
									Me.cboComparison.Items.Clear
									Me.cboComparison.Items.AddRange(_scalarComparison)
								End If
								
								controlObject.TabIndex = 2
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpVersion"
								controlObject.TabIndex = 3
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.FileVersionWithRegistry
					For Each controlObject As Control In Me.tlpRules.Controls
						Select Case controlObject.Name
							Case "tlpRegistryKey"
								controlObject.TabIndex = 0
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpRegistryValue"
								controlObject.TabIndex = 1
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpRegistry32Bit"
								controlObject.TabIndex = 2
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
								controlObject.Left = Me.tlpRegistryValue.Left + Me.tlpRegistryValue.Width + 5
							Case "tlpFilePath"
								controlObject.TabIndex = 3
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpComparison"
								'Only change if we need to by testing to see if the
								' first element needed already exists in the combobox.
								If Not Me.cboComparison.Items.Count = _scalarComparison.Length Then
									Me.cboComparison.Items.Clear
									Me.cboComparison.Items.AddRange(_scalarComparison)
								End If
								
								controlObject.TabIndex = 4
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpVersion"
								controlObject.TabIndex = 5
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.RegistryKeyExists
					For Each controlObject As Control In Me.tlpRules.Controls
						Select Case controlObject.Name
							Case "tlpRegistryKey"
								controlObject.TabIndex = 0
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpRegistry32Bit"
								controlObject.TabIndex = 1
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
								controlObject.Left = Me.cboRegistryKey.Left
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.RegistryValueExists
					For Each controlObject As Control In Me.tlpRules.Controls
						Select Case controlObject.Name
							Case "tlpRegistryKey"
								controlObject.TabIndex = 0
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpRegistryValue"
								controlObject.TabIndex = 1
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpRegistry32Bit"
								controlObject.TabIndex = 2
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
								controlObject.Left = Me.tlpRegistryValue.Left + Me.tlpRegistryValue.Width + 5
							Case "tlpRegistryValueType"
								controlObject.TabIndex = 3
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.RegistryDWORDValue
					For Each controlObject As Control In Me.tlpRules.Controls
						Select Case controlObject.Name
							Case "tlpRegistryKey"
								controlObject.TabIndex = 0
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpRegistryValue"
								controlObject.TabIndex = 1
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpRegistry32Bit"
								controlObject.TabIndex = 2
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
								controlObject.Left = Me.tlpRegistryValue.Left + Me.tlpRegistryValue.Width + 5
							Case "tlpComparison"
								'Only change if we need to by testing to see if the
								' first element needed already exists in the combobox.
								If Not Me.cboComparison.Items.Count = _scalarComparison.Length
									Me.cboComparison.Items.Clear
									Me.cboComparison.Items.AddRange(_scalarComparison)
								End If
								
								controlObject.TabIndex = 3
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpData"
								controlObject.TabIndex = 4
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								
								If Not Me.lblData.Text = globalRM.GetString("DWORD_value") Then
									Me.txtData.Text = ""
									Me.lblData.Text = globalRM.GetString("DWORD_value")
								End If
								
								Me.lblDataInfo.Hide
								Me.txtData.Width = Me.txtFilePath.Width
								controlObject.Show
								'controlObject.Top = _startingYConstant + (3 * _spacingConstant)
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.RegistryExpandSzValue
					For Each controlObject As Control In Me.tlpRules.Controls
						Select Case controlObject.Name
							Case "tlpRegistryKey"
								controlObject.TabIndex = 0
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpRegistryValue"
								controlObject.TabIndex = 1
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpRegistry32Bit"
								controlObject.TabIndex = 2
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
								controlObject.Left = Me.tlpRegistryValue.Left + Me.tlpRegistryValue.Width + 5
							Case "tlpComparison"
								'Only change if we need to by testing to see if the
								' first element needed already exists in the combobox.
								If Not Me.cboComparison.Items.Count = _stringComparison.Length Then
									Me.cboComparison.Items.Clear
									Me.cboComparison.Items.AddRange(_stringComparison)
								End If
								
								controlObject.TabIndex = 3
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpData"
								controlObject.TabIndex = 4
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								If Not Me.lblData.Text = globalRM.GetString("string") Then
									Me.txtData.Text = ""
									Me.lblData.Text = globalRM.GetString("string")
								End If
								Me.lblDataInfo.Hide
								Me.txtData.Width = Me.txtFilePath.Width
								controlObject.Show
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.RegistryVersionInSz
					For Each controlObject As Control In Me.tlpRules.Controls
						Select Case controlObject.Name
							Case "tlpRegistryKey"
								controlObject.TabIndex = 0
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpRegistryValue"
								controlObject.TabIndex = 1
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpRegistry32Bit"
								controlObject.TabIndex = 2
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
								controlObject.Left = Me.tlpRegistryValue.Left + Me.tlpRegistryValue.Width + 5
							Case "tlpComparison"
								'Only change if we need to by testing to see if the
								' first element needed already exists in the combobox.
								If Not Me.cboComparison.Items.Count = _scalarComparison.Length Then
									Me.cboComparison.Items.Clear
									Me.cboComparison.Items.AddRange(_scalarComparison)
								End If
								
								controlObject.TabIndex = 3
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpVersion"
								controlObject.TabIndex = 4
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.RegistrySzValue
					For Each controlObject As Control In Me.tlpRules.Controls
						Select Case controlObject.Name
							Case "tlpRegistryKey"
								controlObject.TabIndex = 0
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpRegistryValue"
								controlObject.TabIndex = 1
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpRegistry32Bit"
								controlObject.TabIndex = 2
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
								controlObject.Left = Me.tlpRegistryValue.Left + Me.tlpRegistryValue.Width + 5
							Case "tlpComparison"
								'Only change if we need to by testing to see if the
								' first element needed already exists in the combobox.
								If Not Me.cboComparison.Items.Count = _stringComparison.Length Then
									Me.cboComparison.Items.Clear
									Me.cboComparison.Items.AddRange(_stringComparison)
								End If
								
								controlObject.TabIndex = 3
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
							Case "tlpData"
								controlObject.TabIndex = 4
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								Me.txtData.Width = Me.txtFilePath.Width
								
								If Not Me.lblData.Text = globalRM.GetString("string") Then
									Me.txtData.Text = ""
									Me.lblData.Text = globalRM.GetString("string")
								End If
								
								Me.lblDataInfo.Hide
								controlObject.Show
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.WMIQuery
					For Each controlObject As Control In Me.tlpRules.Controls
						Select Case controlObject.Name
							Case "tlpData"
								controlObject.TabIndex = 0
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								Me.txtData.Width = Me.txtFilePath.Width
								Me.txtData.Text = ""
								Me.lblData.Text = globalRM.GetString("label_rules_WMI_namespace")
								Me.lblDataInfo.Hide
								controlObject.Show
							Case "tlpQuery"
								controlObject.TabIndex =1
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								'We set the hight here rather than the designer because the designer will not
								' allow the form to be high enough to design all of the elements at the same time.
								Me.txtQuery.Height = 300
								controlObject.Show
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.MsiProductInstalled
					For Each controlObject As Control In Me.tlpRules.Controls
						Select Case controlObject.Name
							Case "tlpProductCode"
								controlObject.TabIndex = 0
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
								Exit Select
							Case "tlpMinVersion"
								controlObject.TabIndex = 1
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
								Exit Select
							Case "tlpMaxVersion"
								controlObject.TabIndex = 2
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
								Exit Select
							Case "tlpLanguage"
								controlObject.TabIndex = 3
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
								Exit Select
							Case Else
								controlObject.Hide
								Exit Select
						End Select
					Next
				Case RuleTypes.MsiPatchInstalled
					For Each controlObject As Control In Me.tlpRules.Controls
						Select Case controlObject.Name
							Case "tlpProductCode"
								controlObject.TabIndex = 0
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
								Exit Select
							Case "tlpPatchCode"
								controlObject.TabIndex = 1
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
								Exit Select
							Case "tlpMinVersion"
								controlObject.TabIndex = 2
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
								Exit Select
							Case "tlpMaxVersion"
								controlObject.TabIndex = 3
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
								Exit Select
							Case "tlpLanguage"
								controlObject.TabIndex = 4
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
								Exit Select
							Case Else
								controlObject.Hide
								Exit Select
						End Select
					Next
				Case RuleTypes.MsiComponentInstalled
					For Each controlObject As Control In Me.tlpRules.Controls
						Select Case controlObject.Name
							Case "pnlProductCollection"
								controlObject.TabIndex = 0
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
								Exit Select
							Case "pnlComponentCollection"
								controlObject.TabIndex = 1
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
								Exit Select
							Case Else
								controlObject.Hide
								Exit Select
						End Select
					Next
				Case RuleTypes.MsiFeatureInstalled
					For Each controlObject As Control In Me.tlpRules.Controls
						Select Case controlObject.Name
							Case "pnlProductCollection"
								controlObject.TabIndex = 0
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
								Exit Select
							Case "pnlFeatureCollection"
								controlObject.TabIndex = 1
								Me.tlpRules.SetRow(controlObject,controlObject.TabIndex)
								controlObject.Show
								Exit Select
							Case Else
								controlObject.Hide
								Exit Select
						End Select
					Next
				Case Else
					Msgbox(globalRM.GetString("error_rules_unsupported_type"))
					For Each controlObject As Control In Me.tlpRules.Controls
						If TypeOf controlObject Is Panel or TypeOf controlObject Is TableLayoutPanel Then
							controlObject.Hide
						End If
					Next
			End Select
			
			Call ValidateForm
		End If 'Combobox has a selection.
	End Sub
	
	'When user is finished, generate the rule and close.
	Private Sub BtnAddClick(sender As Object, e As EventArgs)
		Call GenerateRule
	End Sub
	
	'Set the corresponding text boxes and the service pack combo when
	' the user modifies the OS version checkboxes.
	Private Sub GetOSVersionCodes(sender As Object, e As EventArgs)
		'Clear the service pack combobox.
		Me.cboServicePack.SelectedIndex = -1
		Me.cboServicePack.Items.Clear
		Me.cboServicePack.Items.Add("")
		
		Select Case Me.cboOSVersion.Text
			Case "Windows 2000"
				Me.txtOSMajorVersion.Text = "5"
				Me.txtOSMinorVersion.Text = "0"
				Me.cboServicePack.Items.Add("SP 1")
				Me.cboServicePack.Items.Add("SP 2")
				Me.cboServicePack.Items.Add("SP 3")
				Me.cboServicePack.Items.Add("SP 4")
			Case "Windows XP"
				Me.txtOSMajorVersion.Text = "5"
				Me.txtOSMinorVersion.Text = "1"
				Me.cboServicePack.Items.Add("SP 1")
				Me.cboServicePack.Items.Add("SP 2")
				Me.cboServicePack.Items.Add("SP 3")
			Case "Windows Server 2003"
				Me.txtOSMajorVersion.Text = "5"
				Me.txtOSMinorVersion.Text = "2"
				Me.cboServicePack.Items.Add("SP 1")
				Me.cboServicePack.Items.Add("SP 2")
			Case "Windows Vista"
				Me.txtOSMajorVersion.Text = "6"
				Me.txtOSMinorVersion.Text = "0"
				Me.cboServicePack.Items.Add("SP 1")
				Me.cboServicePack.Items.Add("SP 2")
			Case "Windows Server 2008"
				Me.txtOSMajorVersion.Text = "6"
				Me.txtOSMinorVersion.Text = "1"
				Me.cboServicePack.Items.Add("SP 1")
				Me.cboServicePack.Items.Add("SP 2")
			Case "Windows 7"
				Me.txtOSMajorVersion.Text = "6"
				Me.txtOSMinorVersion.Text = "1"
				Me.cboServicePack.Items.Add("SP 1")
			Case Else
				Me.txtOSMajorVersion.Text = "0"
				Me.txtOSMinorVersion.Text = "0"
		End Select
	End Sub
	
	'Set the corresponding codes to the service pack.
	Private Sub GetServicePackCode(sender As Object, e As EventArgs)
		Select Case Me.cboServicePack.Text
			Case "SP 1"
				Me.txtSPMajorVersion.Text = "1"
				Me.txtSPMinorVersion.Text = "0"
			Case "SP 2"
				Me.txtSPMajorVersion.Text = "2"
				Me.txtSPMinorVersion.Text = "0"
			Case "SP 3"
				Me.txtSPMajorVersion.Text = "3"
				Me.txtSPMinorVersion.Text = "0"
			Case "SP 4"
				Me.txtSPMajorVersion.Text = "4"
				Me.txtSPMinorVersion.Text = "0"
			Case Else
				Me.txtSPMajorVersion.Text = "0"
				Me.txtSPMinorVersion.Text = "0"
		End Select
	End Sub
	
	#End Region
	
	#REGION "Shared Methods"
	
	'Set the corresponding text fields to the service pack.
	Shared Function GetServicePackText(spMajor As String) As String
		Return "SP " & spMajor
	End Function
	
	'	'Return the CSID number for the selected directory.
	'	Shared Private Function GetCSIDCode(directory As String) As String
	'		Select Case directory
	'			Case "System"
	'				Return "37"
	'			Case "Program Files"
	'				Return "38"
	'			Case "Program Files Common"
	'				Return "43"
	'			Case "Windows"
	'				Return "36"
	'			Case "Common Admin Tools"
	'				Return "47"
	'			Case "Common Alt Startup"
	'				Return "30"
	'			Case "Common App Data"
	'				Return "35"
	'			Case "Common Desktop Directory"
	'				Return "25"
	'			Case "Common Documents"
	'				Return "46"
	'			Case "Common Favorites"
	'				Return "31"
	'			Case "Common Music"
	'				Return "53"
	'			Case "Common Pictures"
	'				Return "54"
	'			Case "Common Programs"
	'				Return "23"
	'			Case "Common Startup"
	'				Return "24"
	'			Case "Common Start Menu"
	'				Return "22"
	'			Case "Common Templates"
	'				Return "45"
	'			Case "Common Video"
	'				Return "55"
	'			Case "Controls"
	'				Return "3"
	'			Case "Drives"
	'				Return "17"
	'			Case "Printers"
	'				Return "4"
	'			Case "Profiles"
	'				Return "62"
	'			Case Else
	'				Return Nothing
	'		End Select
	'	End Function
	'
	'	'Return the CSID text for the selected directory.
	'	Shared  Function GetCsidCodeText(code As String) As String
	'		Select Case code
	'			Case "37"
	'				Return "System"
	'			Case "38"
	'				Return "Program Files"
	'			Case "43"
	'				Return "Program Files Common"
	'			Case "36"
	'				Return "Windows"
	'			Case "47"
	'				Return "Common Admin Tools"
	'			Case "30"
	'				Return "Common Alt Startup"
	'			Case "35"
	'				Return "Common App Data"
	'			Case "25"
	'				Return "Common Desktop Directory"
	'			Case "46"
	'				Return "Common Documents"
	'			Case "31"
	'				Return "Common Favorites"
	'			Case "53"
	'				Return "Common Music"
	'			Case "54"
	'				Return "Common Pictures"
	'			Case "23"
	'				Return "Common Programs"
	'			Case "24"
	'				Return "Common Startup"
	'			Case "22"
	'				Return "Common Start Menu"
	'			Case "45"
	'				Return "Common Templates"
	'			Case "55"
	'				Return "Common Video"
	'			Case "3"
	'				Return "Controls"
	'			Case "17"
	'				Return "Drives"
	'			Case "4"
	'				Return "Printers"
	'			Case "62"
	'				Return "Profiles"
	'			Case Else
	'				Return Nothing
	'		End Select
	'	End Function
	
	'Return the XML compatible comparison string based on the human readable string.
	Shared Function GetComparisonCode(comparison As String) As String
		Select Case comparison
			Case globalRM.GetString("equal_to")
				Return "EqualTo"
			Case globalRM.GetString("less_than")
				Return "LessThan"
			Case globalRM.GetString("less_than_or_equal_to")
				Return "LessThanOrEqualTo"
			Case globalRM.GetString("greater_than")
				Return "GreaterThan"
			Case globalRM.GetString("greater_than_or_equal_to")
				Return "GreaterThanOrEqualTo"
			Case globalRM.GetString("begins_with")
				Return "BeginsWith"
			Case globalRM.GetString("ends_with")
				Return "EndsWith"
			Case globalRM.GetString("contains")
				Return "Contains"
			Case Else
				Return Nothing
		End Select
	End Function
	
	'Return the human readable string based on the XML compatible comparison string.
	Shared Function GetComparisonText(comparisonCode As String) As String
		Select Case comparisonCode
			Case "EqualTo"
				Return globalRM.GetString("equal_to")
			Case "LessThan"
				Return globalRM.GetString("less_than")
			Case "LessThanOrEqualTo"
				Return globalRM.GetString("less_than_or_equal_to")
			Case "GreaterThan"
				Return globalRM.GetString("greater_than")
			Case "GreaterThanOrEqualTo"
				Return globalRM.GetString("greater_than_or_equal_to")
			Case "BeginsWith"
				Return globalRM.GetString("begins_with")
			Case "EndsWith"
				Return globalRM.GetString("ends_with")
			Case "Contains"
				Return globalRM.GetString("contains")
			Case Else
				Return Nothing
		End Select
	End Function
	
	'Return the language code based on the human readable string.
	Shared Function GetLanguageCode(language As String) As String
		Select Case language
			Case globalRM.GetString("language_arabic")
				Return "ar"
			Case globalRM.GetString("language_chinese_HK_SAR")
				Return "zh-HK"
			Case globalRM.GetString("language_chinese_simplified")
				Return "zh-CHS"
			Case globalRM.GetString("language_chinese_traditional")
				Return "zh-CHT"
			Case globalRM.GetString("language_czech")
				Return "cs"
			Case globalRM.GetString("language_danish")
				Return "da"
			Case globalRM.GetString("language_dutch")
				Return "nl"
			Case globalRM.GetString("language_english")
				Return "en"
			Case globalRM.GetString("language_finnish")
				Return "fi"
			Case globalRM.GetString("language_french")
				Return "fr"
			Case globalRM.GetString("language_german")
				Return "de"
			Case globalRM.GetString("language_greek")
				Return "el"
			Case globalRM.GetString("language_hebrew")
				Return "he"
			Case globalRM.GetString("language_hungarian")
				Return "hu"
			Case globalRM.GetString("language_italian")
				Return "it"
			Case globalRM.GetString("language_japanese")
				Return "ja"
			Case globalRM.GetString("language_korean")
				Return "ko"
			Case globalRM.GetString("language_norwegian")
				Return "no"
			Case globalRM.GetString("language_polish")
				Return "pl"
			Case globalRM.GetString("language_portuguese")
				Return "pt"
			Case globalRM.GetString("language_portuguese_brazil")
				Return "pt-BR"
			Case globalRM.GetString("language_russian")
				Return "ru"
			Case globalRM.GetString("language_spanish")
				Return "es"
			Case globalRM.GetString("language_swedish")
				Return "sv"
			Case globalRM.GetString("language_turkish")
				Return "tr"
			Case Else
				Return Nothing
		End Select
	End Function
	
	'Gets the MSI language code (integer) for the given.
	Public Shared Function GetMsiLanguageCode(iso6391Code As String) As Integer
		Select Case iso6391Code
			Case "ar"
				Return 1
			Case "zh-HK"
				Return 3076
			Case "zh-CHS"
				Return 4
			Case "zh-CHT"
				Return 31748
			Case "cs"
				Return 5
			Case "da"
				Return 6
			Case "nl"
				Return 19
			Case "en"
				Return 9
			Case "fi"
				Return 11
			Case "fr"
				Return 12
			Case "de"
				Return 7
			Case "el"
				Return 8
			Case "he"
				Return 13
			Case "hu"
				Return 14
			Case "it"
				Return 16
			Case "ja"
				Return 17
			Case "ko"
				Return 18
			Case "no"
				Return 20
			Case "pl"
				Return 21
			Case "pt"
				Return 22
			Case "pt-BR"
				Return 1046
			Case "ru"
				Return 25
			Case "es"
				Return 10
			Case "sv"
				Return 29
			Case "tr"
				Return 31
			Case Else
				Throw New NotSupportedException("The language code " & iso6391Code & " does not have an MSI Langauge Number!")
		End Select
	End Function
	
	
	'When a processor type is selected show the XML compatible value.
	Shared Function GetProcessorTypeCode(processorType as String) as String
		Select Case processorType
			Case "x86"
				Return "0"
			Case "x64"
				Return "9"
			Case "IA64"
				Return "6"
			Case Else
				Return Nothing
		End Select
	End Function
	
	'When a processor type is selected show the XML compatible value.
	Shared Function GetProcessorTypeText(processorTypeCode as String) as String
		Select Case processorTypeCode
			Case "0"
				Return "x86"
			Case "9"
				Return "x64"
			Case "6"
				Return "IA64"
			Case Else
				Return Nothing
		End Select
	End Function
	
	'Return a product type based on the number.
	Shared Function GetProductTypeText (productTypeCode As Integer) As String
		Select Case productTypeCode
			Case 1
				Return "Workstation"
			Case 2
				Return "Domain Controller"
			Case 3
				Return "Server"
			Case Else
				Return Nothing
		End Select
	End Function
	
	#End Region
	
	#REGION "Rules"
	'When the user is finished, this routine populates the human readable string
	' and the XML string accordingly.  The routine calling this form must then use
	' these strings to add to the appropriate DGV as well as the SDP's XML.
	Sub GenerateRule
		'Begin the rule based on the selected rule type.
		_readableRule = CType(Me.cboRuleType.SelectedItem, RuleTypes).ToDisplayString() & ": "
		_xmlRule = "<" & CType(Me.cboRuleType.SelectedItem, RuleTypes).ToXmlTag() & " "
		
		
		Select Case Me.cboRuleType.SelectedIndex 'Generate rule based on combobox selection.
			Case RuleTypes.WindowsVersion
				'Set the readable rule.
				Me._readableRule += "   " & globalRM.GetString("comparison") & ":" & Me.cboComparison.Text & " " & _
					"   " & globalRM.GetString("version") & ":" & Me.txtOSMajorVersion.Text & "." & Me.txtOSMinorVersion.Text & " "
				If Not String.IsNullOrEmpty(Me.txtSPMajorVersion.Text) Then Me._readableRule += "   " & globalRM.GetString("service_pack") & ":" & Me.txtSPMajorVersion.Text & "." & Me.txtSPMinorVersion.Text
				If Not String.IsNullOrEmpty(Me.txtData.Text) Then Me._readableRule += "   " & globalRM.GetString("build_number") & ":" & Me.txtData.Text
				If Not String.IsNullOrEmpty(Me.cboProductType.Text) Then Me._readableRule += "   " & globalRM.GetString("product_type") & ":" & Me.cboProductType.Text
				
				'Set the xmlrule.
				_xmlRule += "Comparison=""" & StringToXML(GetComparisonCode(Me.cboComparison.Text)) & """ " & _
					"MajorVersion=""" & StringToXML(Me.txtOSMajorVersion.Text) & """ " & _
					"MinorVersion=""" & StringToXML(Me.txtOSMinorVersion.Text) & """ "
				If Not String.IsNullOrEmpty(Me.txtData.Text) Then _xmlRule += "BuildNumber=""" & StringToXML(Me.txtData.Text) & """ "
				_xmlRule += "ServicePackMajor="""  & If (String.IsNullOrEmpty(Me.txtSPMajorVersion.Text) , "0" , StringToXML(Me.txtSPMajorVersion.Text) ) & """ "
				_xmlRule += "ServicePackMinor="""  & If (String.IsNullOrEmpty(Me.txtSPMinorVersion.Text) , "0" , StringToXML(Me.txtSPMinorVersion.Text) ) & """ "
				
				If Not String.IsNullOrEmpty(Me.cboProductType.Text) Then _xmlRule += "ProductType=""" & Me.cboProductType.SelectedIndex & """ "
				_xmlRule += " />"
			Case RuleTypes.WindowsLanguage
				'Set the readable rule.
				Me._readableRule += Me.cboLanguage.Text
				
				'Set the xmlrule.
				_xmlRule += "Language=""" & GetLanguageCode(Me.cboLanguage.Text) & """ />"
			Case RuleTypes.ProcessorArchitecture
				'Set the readable rule.
				Me._readableRule += Me.cboProcessorType.Text
				
				'Set the xmlrule.
				_xmlRule += "Architecture=""" & GetProcessorTypeCode(Me.cboProcessorType.Text) & """ />"
			Case RuleTypes.FileExists
				'Set the readable rule.
				Me._readableRule += Me.txtFilePath.Text.Trim("\"c)
				If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) AndAlso Not Me.cboEnvironmentVariable.Text = "NONE" Then Me._readableRule += "   " & globalRM.GetString("CSID") & ": " & Me.cboEnvironmentVariable.Text
				If Not String.IsNullOrEmpty(Me.txtVersion.Text) Then Me._readableRule += "   " & globalRM.GetString("version") & ": " & Me.txtVersion.Text
				
				'Set the xmlrule.
				_xmlRule += "Path=""" & StringToXML(Me.txtFilePath.Text.Trim("\"c)) & """ "
				'If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text ) Then _xmlRule += "Csidl=""" & GetCSIDCode(Me.cboEnvironmentVariable.Text) & """ "
				If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text ) AndAlso Not Me.cboEnvironmentVariable.Text = "NONE" Then _xmlRule += "Csidl=""" & DirectCast(Me.cboEnvironmentVariable.SelectedValue, Integer) & """ "
				
				If Not String.IsNullOrEmpty(Me.txtVersion.Text) Then _xmlRule += "Version=""" & StringToXML(Me.txtVersion.Text) & """ "
				_xmlRule += " />"
			Case RuleTypes.FileExistsWithRegistry
				'Set the readable rule.
				Me._readableRule += Me.cboRegistryKey.Text & "\" & Me.txtRegistrySubKey.Text.Trim("\"c) & "\" & Me.txtRegistryValue.Text.Trim("\"c)
				If Me.chkRegistry32bit.Checked Then Me._readableRule += "   Reg32:" & globalRM.GetString("true")
				Me._readableRule += "   " & globalRM.GetString("path") & ":" & Me.txtFilePath.Text.Trim("\"c)
				If Not String.IsNullOrEmpty(Me.txtVersion.Text) Then Me._readableRule += "   " & globalRM.GetString("version") & ": " & Me.txtVersion.Text
				
				'Set the xmlrule.
				_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
					"Subkey=""" & StringToXML(Me.txtRegistrySubKey.Text.Trim("\"c)) & """ " & _
					"Value=""" & StringToXML(Me.txtRegistryValue.Text.Trim("\"c)) & """ "
				If Me.chkRegistry32bit.Checked Then _xmlRule += "RegType32=""true"" "
				_xmlRule += "Path=""" & StringToXML(Me.txtFilePath.Text.Trim("\"c)) & """ "
				If Not String.IsNullOrEmpty(Me.txtVersion.Text) Then _xmlRule += "Version=""" & StringToXML(Me.txtVersion.Text) & """ "
				_xmlRule += " />"
			Case RuleTypes.FileCreation
				'Set the readable rule.
				Me._readableRule += Me.txtFilePath.Text.Trim("\"c)
				If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) AndAlso Not Me.cboEnvironmentVariable.Text = "NONE" Then Me._readableRule += "   " & globalRM.GetString("CSID") & ": " & Me.cboEnvironmentVariable.Text
				Me._readableRule += "   " & globalRM.GetString("comparison") & ":" & Me.cboComparison.Text & _
					"   " & globalRM.GetString("created") & ":" & Me.dtpDate.Value.ToLongDateString
				
				'Set the xmlrule.
				_xmlRule += "Path=""" & StringToXML(Me.txtFilePath.Text.Trim("\"c)) & """ "
				'If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) Then _xmlRule += "Csidl=""" & GetCSIDCode(Me.cboEnvironmentVariable.Text) & """ "
				If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) AndAlso Not Me.cboEnvironmentVariable.Text = "NONE" Then _xmlRule += "Csidl=""" & DirectCast(Me.cboEnvironmentVariable.SelectedValue, Integer) & """ "
				_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
					"Created=""" & Format(Me.dtpDate.Value.ToUniversalTime,"yyyy-MM-dd'T'HH:mm:ss" & "Z") & """ "
				_xmlRule += " />"
			Case RuleTypes.FileCreationWithRegistry
				'Set the readable rule.
				Me._readableRule += Me.cboRegistryKey.Text & "\" & Me.txtRegistrySubKey.Text.Trim("\"c) & "\" & Me.txtRegistryValue.Text.Trim("\"c)
				If Me.chkRegistry32Bit.Checked Then Me._readableRule += "   Reg32:" & globalRM.GetString("true")
				Me._readableRule += "   " & globalRM.GetString("path") & ":" & Me.txtFilePath.Text.Trim("\"c)
				Me._readableRule += "   " & globalRM.GetString("comparison") & ":" & Me.cboComparison.Text & _
					"   " & globalRM.GetString("created") & ":" & Me.dtpDate.Value.ToLongDateString
				
				'Set the xmlrule.
				_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
					"Subkey=""" & StringToXML(Me.txtRegistrySubKey.Text.Trim("\"c)) & """ " & _
					"Value=""" & StringToXML(Me.txtRegistryValue.Text.Trim("\"c)) & """ "
				If Me.chkRegistry32Bit.Checked Then _xmlRule += "RegType32=""true"" "
				_xmlRule += "Path=""" & StringToXML(Me.txtFilePath.Text.Trim("\"c)) & """ "
				_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
					"Created=""" & Format(Me.dtpDate.Value.ToUniversalTime,"yyyy-MM-dd'T'HH:mm:ss" & "Z") & """ "
				_xmlRule += " />"
			Case RuleTypes.FileModified
				'Set the readable rule
				Me._readableRule += Me.txtFilePath.Text.Trim("\"c)
				If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) AndAlso Not Me.cboEnvironmentVariable.Text = "NONE" Then Me._readableRule += "   " & globalRM.GetString("CSID") & ": " & Me.cboEnvironmentVariable.Text
				Me._readableRule += "   " & globalRM.GetString("comparison") & ":" & Me.cboComparison.Text & _
					"   " & globalRM.GetString("modified") & ":" & Me.dtpDate.Value.ToLongDateString
				
				'Set the xmlrule.
				_xmlRule += "Path=""" & StringToXML(Me.txtFilePath.Text.Trim("\"c)) & """ "
				'If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) Then _xmlRule += "Csidl=""" & GetCSIDCode(Me.cboEnvironmentVariable.Text) & """ "
				If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) AndAlso Not Me.cboEnvironmentVariable.Text = "NONE" Then _xmlRule += "Csidl=""" & DirectCast(Me.cboEnvironmentVariable.SelectedValue, Integer).ToString & """ "
				_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
					"Modified=""" & Format(Me.dtpDate.Value.ToUniversalTime,"yyyy-MM-dd'T'HH:mm:ss" & "Z") & """ "
				_xmlRule += " />"
			Case RuleTypes.FileModifiedWithRegistry
				'Set the readable rule.
				Me._readableRule += Me.cboRegistryKey.Text & "\" & Me.txtRegistrySubKey.Text.Trim("\"c) & "\" & Me.txtRegistryValue.Text.Trim("\"c)
				If Me.chkRegistry32Bit.Checked Then Me._readableRule += "   Reg32:" & globalRM.GetString("true")
				Me._readableRule += "   " & globalRM.GetString("path") & ":" & Me.txtFilePath.Text.Trim("\"c)
				Me._readableRule += "   " & globalRM.GetString("comparison") & ":" & Me.cboComparison.Text & _
					"   " & globalRM.GetString("modified") & ":" & Me.dtpDate.Value.ToLongDateString
				
				'Set the xmlrule.
				_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
					"Subkey=""" & StringToXML(Me.txtRegistrySubKey.Text.Trim("\"c)) & """ " & _
					"Value=""" & StringToXML(Me.txtRegistryValue.Text.Trim("\"c)) & """ "
				If Me.chkRegistry32Bit.Checked Then _xmlRule += "RegType32=""true"" "
				_xmlRule += "Path=""" & StringToXML(Me.txtFilePath.Text.Trim("\"c)) & """ "
				_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
					"Modified=""" & Format(Me.dtpDate.Value.ToUniversalTime,"yyyy-MM-dd'T'HH:mm:ss" & "Z") & """ "
				_xmlRule += " />"
			Case RuleTypes.FileSize
				'Set the readable rule.
				Me._readableRule += Me.txtFilePath.Text.Trim("\"c)
				If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) AndAlso Not Me.cboEnvironmentVariable.Text = "NONE" Then Me._readableRule += "   " & globalRM.GetString("CSID") & ": " & Me.cboEnvironmentVariable.Text
				Me._readableRule += "   " & globalRM.GetString("comparison") & ":" & Me.cboComparison.Text & _
					"   " & globalRM.GetString("size") & ": " & Me.txtData.Text
				
				'Set the xmlrule.
				_xmlRule += "Path=""" & StringToXML(Me.txtFilePath.Text.Trim("\"c)) & """ "
				'If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) Then _xmlRule += "Csidl=""" & GetCSIDCode(Me.cboEnvironmentVariable.Text) & """ "
				If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) AndAlso Not Me.cboEnvironmentVariable.Text = "NONE" Then _xmlRule += "Csidl=""" & DirectCast(Me.cboEnvironmentVariable.SelectedValue, Integer).ToString & """ "
				_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
					"Size=""" & StringToXML(Me.txtData.Text) & """ "
				_xmlRule += " />"
			Case RuleTypes.FileSizeWithRegistry
				'Set the readable rule.
				Me._readableRule += Me.cboRegistryKey.Text & "\" & Me.txtRegistrySubKey.Text.Trim("\"c) & "\" & Me.txtRegistryValue.Text.Trim("\"c)
				If Me.chkRegistry32Bit.Checked Then Me._readableRule += "   Reg32:" & globalRM.GetString("true")
				Me._readableRule += "   " & globalRM.GetString("path") & ":" & Me.txtFilePath.Text.Trim("\"c)
				Me._readableRule += "   " & globalRM.GetString("comparison") & ":" & Me.cboComparison.Text & _
					"   " & globalRM.GetString("size") & ": " & Me.txtData.Text
				
				'Set the xmlrule.
				_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
					"Subkey=""" & StringToXML(Me.txtRegistrySubKey.Text.Trim("\"c)) & """ " & _
					"Value=""" & StringToXML(Me.txtRegistryValue.Text.Trim("\"c)) & """ "
				If Me.chkRegistry32Bit.Checked Then _xmlRule += "RegType32=""true"" "
				_xmlRule += "Path=""" & StringToXML(Me.txtFilePath.Text.Trim("\"c)) & """ "
				_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
					"Size=""" & StringToXML(Me.txtData.Text) & """ "
				_xmlRule += " />"
			Case RuleTypes.FileVersion
				'Set the readable rule.
				Me._readableRule += Me.txtFilePath.Text.Trim("\"c)
				If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) AndAlso Not Me.cboEnvironmentVariable.Text = "NONE" Then Me._readableRule += "   " & globalRM.GetString("CSID") & ": " & Me.cboEnvironmentVariable.Text
				Me._readableRule += "   " & globalRM.GetString("comparison") & ":" & Me.cboComparison.Text
				If Not String.IsNullOrEmpty(Me.txtVersion.Text) AndAlso Not Me.cboEnvironmentVariable.Text = "NONE" Then Me._readableRule += "   " & globalRM.GetString("version") & ": " & Me.txtVersion.Text
				
				'Set the xmlrule.
				_xmlRule += "Path=""" & StringToXML(Me.txtFilePath.Text.Trim("\"c)) & """ "
				'If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) Then _xmlRule += "Csidl=""" & GetCSIDCode(Me.cboEnvironmentVariable.Text) & """ "
				If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) Then _xmlRule += "Csidl=""" & DirectCast(Me.cboEnvironmentVariable.SelectedValue, Integer).ToString & """ "
				_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ "
				If Not String.IsNullOrEmpty(Me.txtVersion.Text) Then _xmlRule += "Version=""" & StringToXML(Me.txtVersion.Text) & """ "
				_xmlRule += " />"
			Case RuleTypes.FileVersionWithRegistry
				'Set the readable rule.
				Me._readableRule += Me.cboRegistryKey.Text & "\" & Me.txtRegistrySubKey.Text.Trim("\"c) & "\" & Me.txtRegistryValue.Text.Trim("\"c) & _
					"   " & globalRM.GetString("path") & ":" & Me.txtFilePath.Text.Trim("\"c) & _
					"   " & globalRM.GetString("comparison") & ":" & Me.cboComparison.Text & _
					"   " & globalRM.GetString("version") & ":" & Me.txtVersion.Text
				If Me.chkRegistry32Bit.Checked Then Me._readableRule += "   Reg32:" & globalRM.GetString("true")
				
				'Set the xmlrule.
				_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
					"Subkey=""" & StringToXML(Me.txtRegistrySubKey.Text.Trim("\"c)) & """ " & _
					"Value=""" & StringToXML(Me.txtRegistryValue.Text.Trim("\"c)) & """ "
				If Me.chkRegistry32Bit.Checked Then _xmlRule += "RegType32=""true"" "
				_xmlRule += "Path=""" & StringToXML(Me.txtFilePath.Text.Trim("\"c)) & """ " & _
					"Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
					"Version=""" & StringToXML(Me.txtVersion.Text) & """ "
				_xmlRule += " />"
			Case RuleTypes.RegistryKeyExists
				'Set the readable rule.
				Me._readableRule += Me.cboRegistryKey.Text & "\" & _
					Me.txtRegistrySubKey.Text.Trim("\"c)
				If Me.chkRegistry32Bit.Checked Then Me._readableRule += "   Reg32:" & globalRM.GetString("true")
				
				'Set the xmlrule.
				_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
					"Subkey=""" & StringToXML(Me.txtRegistrySubKey.Text.Trim("\"c)) & """ "
				If Me.chkRegistry32Bit.Checked Then _xmlRule += "RegType32=""true"" "
				_xmlRule += " />"
			Case RuleTypes.RegistryValueExists
				'Set the readable rule.
				Me._readableRule += Me.cboRegistryKey.Text & "\" & Me.txtRegistrySubKey.Text.Trim("\"c) & _
					"   " & globalRM.GetString("value") & ":" & Me.txtRegistryValue.Text & _
					"   " & globalRM.GetString("value_type") & ":" & Me.cboRegistryValueType.Text
				If Me.chkRegistry32Bit.Checked Then Me._readableRule += "   Reg32:" & globalRM.GetString("true")
				
				'Set the xmlrule.
				_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
					"Subkey=""" & StringToXML(Me.txtRegistrySubKey.Text.Trim("\"c)) & """ "
				If Not String.IsNullOrEmpty(Me.txtRegistryValue.Text) Then _xmlRule += "Value=""" & StringToXML(Me.txtRegistryValue.Text) & """ "
				If Me.chkRegistry32Bit.Checked Then _xmlRule += "RegType32=""true"" "
				_xmlRule += "Type=""" & StringToXML(Me.cboRegistryValueType.Text) & """ "
				_xmlRule += " />"
			Case RuleTypes.RegistryDWORDValue
				'Set the readable rule.
				Me._readableRule += Me.cboRegistryKey.Text & "\" & Me.txtRegistrySubKey.Text.Trim("\"c) & "\" & Me.txtRegistryValue.Text.Trim("\"c) & _
					"   " & globalRM.GetString("comparison") & ":" & Me.cboComparison.Text & _
					"   " & globalRM.GetString("data") & ":" & Me.txtData.Text
				If Me.chkRegistry32Bit.Checked Then Me._readableRule += "   Reg32:" & globalRM.GetString("true")
				
				'Set the xmlrule.
				_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
					"Subkey=""" & StringToXML(Me.txtRegistrySubKey.Text.Trim("\"c)) & """ " & _
					"Value=""" & StringToXML(Me.txtRegistryValue.Text.Trim("\"c)) & """ "
				If Me.chkRegistry32Bit.Checked Then _xmlRule += "RegType32=""true"" "
				_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
					"Data=""" & StringToXML(Me.txtData.Text) & """ "
				_xmlRule += " />"
			Case RuleTypes.RegistryExpandSzValue
				'Set the readable rule.
				Me._readableRule += Me.cboRegistryKey.Text & "\" & Me.txtRegistrySubKey.Text.Trim("\"c) & "\" & Me.txtRegistryValue.Text.Trim("\"c) & _
					"   " & globalRM.GetString("comparison") & ":" & Me.cboComparison.Text & _
					"   " & globalRM.GetString("string") & ":" & Me.txtData.Text
				If Me.chkRegistry32Bit.Checked Then Me._readableRule += "   Reg32:" & globalRM.GetString("true")
				
				'Set the xmlrule.
				_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
					"Subkey=""" & StringToXML(Me.txtRegistrySubKey.Text.Trim("\"c)) & """ " & _
					"Value=""" & StringToXML(Me.txtRegistryValue.Text.Trim("\"c)) & """ "
				If Me.chkRegistry32Bit.Checked Then _xmlRule += "RegType32=""true"" "
				_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
					"Data=""" & StringToXML(Me.txtData.Text) & """ "
				_xmlRule += " />"
			Case RuleTypes.RegistryVersionInSz
				'Set the readable rule.
				Me._readableRule += Me.cboRegistryKey.Text & "\" & Me.txtRegistrySubKey.Text.Trim("\"c) & "\" & Me.txtRegistryValue.Text.Trim("\"c) & _
					"   " & globalRM.GetString("comparison") & ":" & Me.cboComparison.Text & _
					"   " & globalRM.GetString("string") & ":" & Me.txtVersion.Text
				If Me.chkRegistry32Bit.Checked Then Me._readableRule += "   Reg32:" & globalRM.GetString("true")
				
				'Set the xmlrule.
				_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
					"Subkey=""" & StringToXML(Me.txtRegistrySubKey.Text.Trim("\"c)) & """ " & _
					"Value=""" & StringToXML(Me.txtRegistryValue.Text.Trim("\"c)) & """ "
				If Me.chkRegistry32Bit.Checked Then _xmlRule += "RegType32=""true"" "
				_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
					"Data=""" & StringToXML(Me.txtVersion.Text) & """ "
				_xmlRule += " />"
			Case RuleTypes.RegistrySzValue
				'Set the readable rule.
				Me._readableRule += Me.cboRegistryKey.Text & "\" & Me.txtRegistrySubKey.Text.Trim("\"c) & "\" & Me.txtRegistryValue.Text.Trim("\"c) & _
					"   " & globalRM.GetString("comparison") & ":" & Me.cboComparison.Text & _
					"   " & globalRM.GetString("string") & ":" & Me.txtData.Text
				If Me.chkRegistry32Bit.Checked Then Me._readableRule += "   Reg32:" & globalRM.GetString("true")
				
				'Set the xmlrule.
				_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
					"Subkey=""" & StringToXML(Me.txtRegistrySubKey.Text.Trim("\"c)) & """ " & _
					"Value=""" & StringToXML(Me.txtRegistryValue.Text.Trim("\"c)) & """ "
				If Me.chkRegistry32Bit.Checked Then _xmlRule += "RegType32=""true"" "
				_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
					"Data=""" & StringToXML(Me.txtData.Text) & """ "
				_xmlRule += " />"
			Case RuleTypes.WMIQuery
				'Set the readable rule.
				If Not String.IsNullOrEmpty(Me.txtData.Text) Then Me._readableRule += "NameSpace:" & Me.txtData.Text & " "
				Me._readableRule += globalRM.GetString("query") & ": " & Me.txtQuery.Text
				
				'Set the xmlrule.
				If Not String.IsNullOrEmpty(Me.txtData.Text) Then _xmlRule += "Namespace=""" & StringToXML(Me.txtData.Text) & """ "
				_xmlRule += "WqlQuery=""" & StringToXML(Me.txtQuery.Text) & """ "
				_xmlRule += " />"
				
			Case RuleTypes.MsiProductInstalled
				
				_readableRule += New Guid(txtProductCode.Text).ToString("B") & "  "
				If Not String.IsNullOrEmpty(txtMaxVersion.Text) Then _readableRule += " " & globalRM.GetString("version_maximum") & " = " & txtMaxVersion.Text
				If Not String.IsNullOrEmpty(txtMinVersion.Text) Then _readableRule += " " & globalRM.GetString("version_minimum") & " = " & txtMinVersion.Text
				If Not String.IsNullOrEmpty(GetLanguageCode(cboLanguage.Text)) Then _readableRule += " " & globalRM.GetString("language") & " = " & cboLanguage.Text
				
				_xmlRule += "ProductCode=""" & (New Guid(txtProductCode.Text).ToString("B")) & """"
				If Not String.IsNullOrEmpty(txtMaxVersion.Text) Then _xmlRule += " VersionMax=""" & StringToXML(txtMaxVersion.Text) & """"
				If Not String.IsNullOrEmpty(txtMinVersion.Text) Then _xmlRule += " VersionMin=""" & StringToXML(txtMinVersion.Text) & """"
				If Not String.IsNullOrEmpty(GetLanguageCode(cboLanguage.Text)) Then _xmlRule += " Language=""" & GetMsiLanguageCode(GetLanguageCode(cboLanguage.Text)) & """"
				_xmlRule+= " />"
			Case RuleTypes.MsiPatchInstalled
				
				_readableRule += " " & globalRM.GetString("patch_code") & " = " & (New Guid(txtPatchCode.Text).ToString("B")) & "  " & " for " & globalRM.GetString("product_code") & " = " & (New Guid(txtProductCode.Text).ToString("B")) & "  "
				If Not String.IsNullOrEmpty(txtMaxVersion.Text) Then _readableRule += " " & globalRM.GetString("version_maximum") & " = " & txtMaxVersion.Text
				If Not String.IsNullOrEmpty(txtMinVersion.Text) Then _readableRule += " " & globalRM.GetString("version_minimum") & " = " & txtMinVersion.Text
				If Not String.IsNullOrEmpty(GetLanguageCode(cboLanguage.Text)) Then _readableRule += " " & globalRM.GetString("language") & " = " & cboLanguage.Text
				
				_xmlRule += "PatchCode=""" & (New Guid(txtPatchCode.Text).ToString("B")) & """" & " ProductCode=""" & (New Guid(txtProductCode.Text).ToString("B")) & """"
				If Not String.IsNullOrEmpty(txtMaxVersion.Text) Then _xmlRule += " VersionMax=""" & StringToXML(txtMaxVersion.Text) & """"
				If Not String.IsNullOrEmpty(txtMinVersion.Text) Then _xmlRule += " VersionMin=""" & StringToXML(txtMinVersion.Text) & """"
				If Not String.IsNullOrEmpty(GetLanguageCode(cboLanguage.Text)) Then _xmlRule += " Language=""" & GetMsiLanguageCode(GetLanguageCode(cboLanguage.Text)) & """"
				_xmlRule += " />"
			Case RuleTypes.MsiComponentInstalled
				
				'Set the all products and components required value.
				If chkProductCollection_requireAll.Checked Then
					_xmlRule += " AllProductsRequired=""true"""
				End If
				If chkComponentCollection_requireAll.Checked Then
					_xmlRule += " AllComponentsRequired=""true"""
				End If
				_xmlRule += ">"
				
				_readableRule += globalRM.GetString("components") & ": "
				If chkComponentCollection_requireAll.Checked Then _readableRule += " (" & globalRM.GetString("all_required") & ")" & "  "
				
				'Add the component Guids.
				For Each tmpGuid As Guid In gceComponentCollection.ItemGuids
					_readableRule += tmpGuid.ToString("B") & "  "
					_xmlRule += "<msiar:Component>" & tmpGuid.ToString("B") & "</msiar:Component>"
				Next
				
				_readableRule += globalRM.GetString("products") & ": "
				If chkProductCollection_requireAll.Checked Then _readableRule += " (" & globalRM.GetString("all_required") & ")" & "  "
				
				'Add the product Guids.
				For Each tmpGuid As Guid In gceProductCollection.ItemGuids
					_readableRule += tmpGuid.ToString("B") & "  "
					_xmlRule += "<msiar:Product>" & tmpGuid.ToString("B") & "</msiar:Product>"
				Next
				
				_xmlRule += "</" & RuleTypes.MsiComponentInstalled.ToXmlTag() & ">"
			Case RuleTypes.MsiFeatureInstalled
				
				'Set the all products and components required value.
				If chkProductCollection_requireAll.Checked Then
					_xmlRule += " AllProductsRequired=""true"""
				End If
				If chkFeatureCollection_requireAll.Checked Then
					_xmlRule += " AllFeaturesRequired=""true"""
				End If
				_xmlRule += ">"
				
				_readableRule += globalRM.GetString("features") & ": "
				If chkFeatureCollection_requireAll.Checked Then _readableRule += " (" & globalRM.GetString("all_required") & ")" & "  "
				
				'Add the feature names.
				For Each tmpFeature As String In gceFeatureCollection.Items
					_readableRule += tmpFeature & "  "
					_xmlRule += "<msiar:Feature>" & tmpFeature & "</msiar:Feature>"
				Next
				
				_readableRule += globalRM.GetString("products") & ": "
				If chkProductCollection_requireAll.Checked Then _readableRule += " (" & globalRM.GetString("all_required") & ")" & "  "
				
				'Add the product Guids.
				For Each tmpGuid As Guid In gceProductCollection.ItemGuids
					_readableRule += tmpGuid.ToString("B") & "  "
					_xmlRule += "<msiar:Product>" & tmpGuid.ToString("B") & "</msiar:Product>"
				Next
				
				_xmlRule += "</" & RuleTypes.MsiFeatureInstalled.ToXmlTag() & ">"
			Case Else
				Msgbox(globalRM.GetString("error_rules_unsupported_type"))
				Me._readableRule = ""
				_xmlRule = ""
		End Select
		
		'apply NOT to the rule
		If Me.chkNotRule.Checked Then
			Me._readableRule = "NOT " & Me._readableRule
			_xmlRule = "<lar:Not>" & _xmlRule & "</lar:Not>"
		End If
	End Sub
	
	'This function returns the readable string based on the passed xml string.
	Public Function GenerateReadableRuleFromXml(ruleXml As String) As String
		If LoadRule(ruleXml) Then
			Call GenerateRule
			Return Me._readableRule
		Else
			Return Nothing
		End If
	End Function
	
	'Loads the rule based on the XML string.
	Private Function LoadRule(ruleXml As String) As Boolean
		
		'Create the namespace and add the lar and bar namespaces.
		Dim nsmgr as XmlNamespaceManager = new XmlNamespaceManager(new NameTable())
		nsmgr.AddNamespace("lar", "http://schemas.microsoft.com/wsus/2005/04/CorporatePublishing/LogicalApplicabilityRules.xsd")
		nsmgr.AddNamespace("bar", "http://schemas.microsoft.com/wsus/2005/04/CorporatePublishing/BaseApplicabilityRules.xsd")
		nsmgr.AddNamespace("msiar", "http://schemas.microsoft.com/wsus/2005/04/CorporatePublishing/MsiApplicabilityRules.xsd")
		
		'Create the XmlParserContext.
		Dim context as XmlParserContext = new XmlParserContext(nothing, nsmgr, nothing, XmlSpace.Default)
		
		Try
			'Create the XmlTextReader and set whitespace handling to none.
			Dim xmlReader As XmlTextReader = New XmlTextReader(ruleXml, XmlNodeType.Element, context)
			xmlReader.WhitespaceHandling = WhitespaceHandling.None
			
			'Read the first element.
			xmlReader.Read
			
			'See if the first element is a Not element.  If so then change the xml reader to
			' use the InnerXML so that the surrounding Not elements are ignored.  Also
			' set the Not checkbox accordingly.
			If xmlReader.LocalName = "Not" Then
				Me.chkNotRule.Checked = True
				xmlReader = New XmlTextReader(xmlReader.ReadInnerXml, XmlNodeType.Element, context)
				xmlReader.Read
			End If
			
			Select Case xmlReader.LocalName 'Now create the rules based on the xml element's name
				Case "WindowsVersion"
					'Select the rule type.
					Me.cboRuleType.SelectedIndex = RuleTypes.WindowsVersion
					
					'Load the data.
					Me.cboComparison.Text = GetComparisonText(xmlReader.GetAttribute("Comparison"))
					Me.txtOSMajorVersion.Text = xmlReader.GetAttribute("MajorVersion")
					Me.txtOSMinorVersion.Text = xmlReader.GetAttribute("MinorVersion")
					Me.txtData.Text = xmlReader.GetAttribute("BuildNumber")
					Me.txtSPMajorVersion.Text = xmlReader.GetAttribute("ServicePackMajor")
					Me.txtSPMinorVersion.Text = xmlReader.GetAttribute("ServicePackMinor")
					If Not xmlReader.GetAttribute("ProductType") Is Nothing Then Me.cboProductType.Text = GetProductTypeText(CInt(xmlReader.GetAttribute("ProductType")))
					
				Case "WindowsLanguage"
					'Select the rule type.
					Me.cboRuleType.SelectedIndex = RuleTypes.WindowsLanguage
					
					'Load the data.
					Me.cboLanguage.Text = Languages.Name(xmlReader.GetAttribute("Language"))
					
				Case "Processor"
					'Select the rule.
					Me.cboRuleType.SelectedIndex = RuleTypes.ProcessorArchitecture
					
					'Load the data.
					Me.cboProcessorType.Text = GetProcessorTypeText(xmlReader.GetAttribute("Architecture"))
					
				Case "FileExists"
					'Select the rule.
					Me.cboRuleType.SelectedIndex = RuleTypes.FileExists
					
					'Load the data.
					Me.txtFilePath.Text = xmlReader.GetAttribute("Path")
					'Me.cboEnvironmentVariable.Text = GetCsidCodeText(xmlReader.GetAttribute("Csidl"))
					Me.cboEnvironmentVariable.Text = [Enum].GetName(GetType(CSIDL), Convert.ToInt32(xmlReader.GetAttribute("Csidl")) )
					Me.txtVersion.Text = xmlReader.GetAttribute("Version")
					
				Case "FileExistsPrependRegSz"
					'Select the rule.
					Me.cboRuleType.SelectedIndex = RuleTypes.FileExistsWithRegistry
					
					'Load the data.
					Me.cboRegistryKey.Text = xmlReader.GetAttribute("Key")
					Me.txtRegistrySubKey.Text = xmlReader.GetAttribute("Subkey")
					Me.txtRegistryValue.Text = xmlReader.GetAttribute("Value")
					If xmlReader.GetAttribute("RegType32") = "true" Then Me.chkRegistry32Bit.Checked = True
					Me.txtFilePath.Text = xmlReader.GetAttribute("Path")
					Me.txtVersion.Text = xmlReader.GetAttribute("Version")
				Case "FileCreated"
					'Select the Rule.
					Me.cboRuleType.SelectedIndex = RuleTypes.FileCreation
					
					'Load the data.
					Me.txtFilePath.Text = xmlReader.GetAttribute("Path")
					'Me.cboEnvironmentVariable.Text = GetCsidCodeText(xmlReader.GetAttribute("Csidl"))
					Me.cboEnvironmentVariable.Text = [Enum].GetName(GetType(CSIDL), Convert.ToInt32(xmlReader.GetAttribute("Csidl")) )
					Me.cboComparison.Text = GetComparisonText(xmlReader.GetAttribute("Comparison"))
					Me.dtpDate.Checked = True
					Me.dtpDate.Value = Date.Parse(xmlReader.GetAttribute("Created")).ToLocalTime
					
					
				Case "FileCreatedPrependRegSz"
					'Select the rule.
					Me.cboRuleType.SelectedIndex = RuleTypes.FileCreationWithRegistry
					
					'Load the data.
					Me.cboRegistryKey.Text = xmlReader.GetAttribute("Key")
					Me.txtRegistrySubKey.Text = xmlReader.GetAttribute("Subkey")
					Me.txtRegistryValue.Text = xmlReader.GetAttribute("Value")
					If xmlReader.GetAttribute("RegType32") = "true" Then Me.chkRegistry32Bit.Checked = True
					Me.txtFilePath.Text = xmlReader.GetAttribute("Path")
					Me.cboComparison.Text = GetComparisonText(xmlReader.GetAttribute("Comparison"))
					Me.dtpDate.Checked = True
					Me.dtpDate.Value = Date.Parse(xmlReader.GetAttribute("Created")).ToLocalTime
				Case "FileModified"
					'Select the Rule.
					Me.cboRuleType.SelectedIndex = RuleTypes.FileModified
					
					'Load the data.
					Me.txtFilePath.Text = xmlReader.GetAttribute("Path")
					'Me.cboEnvironmentVariable.Text = GetCsidCodeText(xmlReader.GetAttribute("Csidl"))
					Me.cboEnvironmentVariable.Text = [Enum].GetName(GetType(CSIDL), Convert.ToInt32(xmlReader.GetAttribute("Csidl")) )
					Me.cboComparison.Text = GetComparisonText(xmlReader.GetAttribute("Comparison"))
					Me.dtpDate.Checked = True
					Me.dtpDate.Value = Date.Parse(xmlReader.GetAttribute("Modified")).ToLocalTime
					
				Case "FileModifiedPrependRegSz"
					'Select the rule.
					Me.cboRuleType.SelectedIndex = RuleTypes.FileModifiedWithRegistry
					
					'Load the data.
					Me.cboRegistryKey.Text = xmlReader.GetAttribute("Key")
					Me.txtRegistrySubKey.Text = xmlReader.GetAttribute("Subkey")
					Me.txtRegistryValue.Text = xmlReader.GetAttribute("Value")
					If xmlReader.GetAttribute("RegType32") = "true" Then Me.chkRegistry32Bit.Checked = True
					Me.txtFilePath.Text = xmlReader.GetAttribute("Path")
					Me.cboComparison.Text = GetComparisonText(xmlReader.GetAttribute("Comparison"))
					Me.dtpDate.Checked = True
					Me.dtpDate.Value = Date.Parse(xmlReader.GetAttribute("Modified")).ToLocalTime
					
				Case "FileSize"
					'Select the rule.
					Me.cboRuleType.SelectedIndex = RuleTypes.FileSize
					
					'Load the data.
					Me.txtFilePath.Text = xmlReader.GetAttribute("Path")
					'Me.cboEnvironmentVariable.Text = GetCsidCodeText(xmlReader.GetAttribute("Csidl"))
					Me.cboEnvironmentVariable.Text = [Enum].GetName(GetType(CSIDL), Convert.ToInt32(xmlReader.GetAttribute("Csidl")) )
					Me.cboComparison.Text = GetComparisonText(xmlReader.GetAttribute("Comparison"))
					Me.txtData.Text = xmlReader.GetAttribute("Size")
					
				Case "FileSizePrependRegSz"
					'Select the rule.
					Me.cboRuleType.SelectedIndex = RuleTypes.FileSizeWithRegistry
					
					'Load the data
					Me.cboRegistryKey.Text = xmlReader.GetAttribute("Key")
					Me.txtRegistrySubKey.Text = xmlReader.GetAttribute("Subkey")
					Me.txtRegistryValue.Text = xmlReader.GetAttribute("Value")
					If xmlReader.GetAttribute("RegType32") = "true" Then Me.chkRegistry32Bit.Checked = True
					Me.txtFilePath.Text = xmlReader.GetAttribute("Path")
					Me.cboComparison.Text = GetComparisonText(xmlReader.GetAttribute("Comparison"))
					Me.txtData.Text = xmlReader.GetAttribute("Size")
					
				Case "FileVersion"
					'Select the rule.
					Me.cboRuleType.SelectedIndex = RuleTypes.FileVersion
					
					'Load the data
					Me.txtFilePath.Text = xmlReader.GetAttribute("Path")
					'Me.cboEnvironmentVariable.Text = GetCsidCodeText(xmlReader.GetAttribute("Csidl"))
					Me.cboEnvironmentVariable.Text = [Enum].GetName(GetType(CSIDL), Convert.ToInt32(xmlReader.GetAttribute("Csidl")) )
					Me.cboComparison.Text = GetComparisonText(xmlReader.GetAttribute("Comparison"))
					Me.txtVersion.Text = xmlReader.GetAttribute("Version")
					
				Case "FileVersionPrependRegSz"
					'Select the rule.
					Me.cboRuleType.SelectedIndex = RuleTypes.FileVersionWithRegistry
					
					'Load the data
					Me.cboRegistryKey.Text = xmlReader.GetAttribute("Key")
					Me.txtRegistrySubKey.Text = xmlReader.GetAttribute("Subkey")
					Me.txtRegistryValue.Text = xmlReader.GetAttribute("Value")
					If xmlReader.GetAttribute("RegType32") = "true" Then Me.chkRegistry32Bit.Checked = True
					Me.txtFilePath.Text = xmlReader.GetAttribute("Path")
					Me.cboComparison.Text = GetComparisonText(xmlReader.GetAttribute("Comparison"))
					Me.txtVersion.Text = xmlReader.GetAttribute("Version")
					
				Case "RegKeyExists"
					'Select the rule.
					Me.cboRuleType.SelectedIndex = RuleTypes.RegistryKeyExists
					
					'Load the data.
					Me.cboRegistryKey.Text = xmlReader.GetAttribute("Key")
					Me.txtRegistrySubKey.Text = xmlReader.GetAttribute("Subkey")
					If xmlReader.GetAttribute("RegType32") = "true" Then Me.chkRegistry32Bit.Checked = True
					
				Case "RegValueExists"
					'Select the rule.
					Me.cboRuleType.SelectedIndex = RuleTypes.RegistryValueExists
					
					'Load the data.
					Me.cboRegistryKey.Text = xmlReader.GetAttribute("Key")
					Me.txtRegistrySubKey.Text = xmlReader.GetAttribute("Subkey")
					Me.txtRegistryValue.Text = xmlReader.GetAttribute("Value")
					If xmlReader.GetAttribute("RegType32") = "true" Then Me.chkRegistry32Bit.Checked = True
					Me.cboRegistryValueType.Text = xmlReader.GetAttribute("Type")
					
				Case "RegDword"
					'Select the rule.
					Me.cboRuleType.SelectedIndex = RuleTypes.RegistryDWORDValue
					
					'Load the data.
					Me.cboRegistryKey.Text = xmlReader.GetAttribute("Key")
					Me.txtRegistrySubKey.Text = xmlReader.GetAttribute("Subkey")
					Me.txtRegistryValue.Text = xmlReader.GetAttribute("Value")
					If xmlReader.GetAttribute("RegType32") = "true" Then Me.chkRegistry32Bit.Checked = True
					Me.cboComparison.Text = GetComparisonText(xmlReader.GetAttribute("Comparison"))
					Me.txtData.Text = xmlReader.GetAttribute("Data")
					
				Case "RegExpandSz"
					'Select the rule.
					Me.cboRuleType.SelectedIndex = RuleTypes.RegistryExpandSzValue
					
					'Load the data.
					Me.cboRegistryKey.Text = xmlReader.GetAttribute("Key")
					Me.txtRegistrySubKey.Text = xmlReader.GetAttribute("Subkey")
					Me.txtRegistryValue.Text = xmlReader.GetAttribute("Value")
					If xmlReader.GetAttribute("RegType32") = "true" Then Me.chkRegistry32Bit.Checked = True
					Me.cboComparison.Text = GetComparisonText(xmlReader.GetAttribute("Comparison"))
					Me.txtData.Text = xmlReader.GetAttribute("Data")
					
				Case "RegSzToVersion"
					'Select the rule.
					Me.cboRuleType.SelectedIndex = RuleTypes.RegistryVersionInSz
					
					'Load the data
					Me.cboRegistryKey.Text = xmlReader.GetAttribute("Key")
					Me.txtRegistrySubKey.Text = xmlReader.GetAttribute("Subkey")
					Me.txtRegistryValue.Text = xmlReader.GetAttribute("Value")
					If xmlReader.GetAttribute("RegType32") = "true" Then Me.chkRegistry32Bit.Checked = True
					Me.cboComparison.Text = GetComparisonText(xmlReader.GetAttribute("Comparison"))
					Me.txtVersion.Text = xmlReader.GetAttribute("Data")
					
				Case "RegSz"
					'Select the rule.
					Me.cboRuleType.SelectedIndex = RuleTypes.RegistrySzValue
					
					'Load the data
					Me.cboRegistryKey.Text = xmlReader.GetAttribute("Key")
					Me.txtRegistrySubKey.Text = xmlReader.GetAttribute("Subkey")
					Me.txtRegistryValue.Text = xmlReader.GetAttribute("Value")
					If xmlReader.GetAttribute("RegType32") = "true" Then Me.chkRegistry32Bit.Checked = True
					Me.cboComparison.Text = GetComparisonText(xmlReader.GetAttribute("Comparison"))
					Me.txtData.Text = xmlReader.GetAttribute("Data")
					
				Case "WmiQuery"
					'Select the rule.
					Me.cboRuleType.SelectedIndex = RuleTypes.WMIQuery
					
					'Load the Data.
					Me.txtData.Text = xmlReader.GetAttribute("Namespace")
					Me.txtQuery.Text = xmlReader.GetAttribute("WqlQuery")
					
				Case "MsiPatchInstalledForProduct"
					'Select the rule.
					Me.cboRuleType.SelectedItem = RuleTypes.MsiPatchInstalled
					
					'Load the Data.
					Me.txtProductCode.Text = xmlReader.GetAttribute("ProductCode")
					Me.txtPatchCode.Text = xmlReader.GetAttribute("PatchCode")
					Me.txtMaxVersion.Text = xmlReader.GetAttribute("VersionMax")
					Me.txtMinVersion.Text = xmlReader.GetAttribute("VersionMin")
					Me.cboLanguage.Text = Languages.Name(Languages.Code(Cint(xmlReader.GetAttribute("Language"))))
					
				Case "MsiProductInstalled"
					'Select the rule.
					Me.cboRuleType.SelectedItem = RuleTypes.MsiProductInstalled
					
					'Load the Data.
					Me.txtProductCode.Text = xmlReader.GetAttribute("ProductCode")
					Me.txtMaxVersion.Text = xmlReader.GetAttribute("VersionMax")
					Me.txtMinVersion.Text = xmlReader.GetAttribute("VersionMin")
					Me.cboLanguage.Text = Languages.Name(Languages.Code(Cint(xmlReader.GetAttribute("Language"))))
					
				Case "MsiComponentInstalledForProduct"
					'Select the rule.
					Me.cboRuleType.SelectedItem = RuleTypes.MsiComponentInstalled
					
					'Load the Data.
					Dim apr As String = xmlReader.GetAttribute("AllProductsRequired")
					Dim acr As String = xmlReader.GetAttribute("AllComponentsRequired")
					chkProductCollection_requireAll.Checked = (If(apr, String.Empty)).ToLowerInvariant() = "true"
					chkComponentCollection_requireAll.Checked = (If(acr, String.Empty)).ToLowerInvariant() = "true"
					
					Dim products As New List(Of String)()
					Dim components As New List(Of String)()
					
					xmlReader.Read()
					Do
						If xmlReader.NodeType = XmlNodeType.Element Then
							Dim n As XmlNodeType = xmlReader.MoveToContent()
							If n = XmlNodeType.Element Then
								Try
									Dim x As String = xmlReader.ReadString()
									If x.Length = 34 Then
										x = x.Substring(1, 32)
									End If
									Dim g As New Guid(x)
									If xmlReader.LocalName = "Component" Then
										components.Add(g.ToString("D"))
									ElseIf xmlReader.LocalName = "Product" Then
										products.Add(g.ToString("D"))
									End If
								Catch
								End Try
							End If
						End If
						
						xmlReader.Read()
						
						If xmlReader.EOF Then
							Exit Do
						End If
					Loop While ((xmlReader.LocalName <> "MsiComponentInstalledForProduct") AndAlso (xmlReader.NodeType <> XmlNodeType.EndElement))
					
					gceProductCollection.Items = products
					gceComponentCollection.Items = components
					
					
				Case "MsiFeatureInstalledForProduct"
					'Select the rule.
					Me.cboRuleType.SelectedItem = RuleTypes.MsiFeatureInstalled
					
					'Load the Data.
					
					Dim apr As String = xmlReader.GetAttribute("AllProductsRequired")
					Dim afr As String = xmlReader.GetAttribute("AllFeaturesRequired")
					chkProductCollection_requireAll.Checked = String.IsNullOrEmpty(apr)
					chkFeatureCollection_requireAll.Checked = String.IsNullOrEmpty(afr)
					
					Dim products As New List(Of String)()
					Dim features As New List(Of String)()
					
					xmlReader.Read()
					Do
						If xmlReader.NodeType = XmlNodeType.Element Then
							Dim n As XmlNodeType = xmlReader.MoveToContent()
							If n = XmlNodeType.Element Then
								Try
									Dim x As String = xmlReader.ReadString()
									
									If xmlReader.LocalName = "Feature" Then
										features.Add(x)
									ElseIf xmlReader.LocalName = "Product" Then
										If x.Length = 34 Then
											x = x.Substring(1, 32)
										End If
										Dim g As New Guid(x)
										products.Add(g.ToString("D"))
									End If
								Catch
								End Try
							End If
						End If
						
						xmlReader.Read()
						
						If xmlReader.EOF Then
							Exit Do
						End If
					Loop While ((xmlReader.LocalName <> "MsiFeatureInstalledForProduct") AndAlso (xmlReader.NodeType <> XmlNodeType.EndElement))
					
					gceProductCollection.Items = products
					gceFeatureCollection.Items = features
					
				Case Else
					Msgbox (globalRM.GetString("error_rules_unrecognized") & ": " & xmlreader.LocalName.Replace("bar:",""))
			End Select
			xmlReader.Close
			
			Return True
		Catch x As XmlException
			Msgbox(globalRM.GetString("exception_XML") & ": " & globalRM.GetString("error_rules_load") & vbNewLine & x.Message )
			Return False
		Catch x As Exception
			Msgbox(globalRM.GetString("exception") & ": " & globalRM.GetString("error_rules_load") & vbNewLine & x.Message )
			Return False
		End Try
	End Function
	
	'Show human readable strings in the combo box.
	Sub CboRuleTypeFormat(sender As Object, e As ListControlConvertEventArgs)
		If TypeOf e.ListItem Is RuleTypes Then
			e.Value = CType(e.ListItem, RuleTypes).ToDisplayString()
		Else
			e.Value = e.ListItem.ToString()
		End If
	End Sub
	#End Region
	
	#Region "Validation"
	
	'The version rule demands a version in the form #.#.#.# so
	' this routine makes sure that the text is formatted that way.
	Private Sub ValidateVersion(sender As Object, e As EventArgs)
		'If this is a textbox then format it as a version string
		If TypeOf Sender Is TextBox Then
			
			'If there's a string and it's less than 4 digits then pad with zeros
			If Not String.IsNullOrEmpty( DirectCast(Sender,TextBox).Text ) Then
				Dim strArray as String() = DirectCast(Sender,TextBox).Text.Split("."c)
				
				Select Case strArray.Length
					Case 1
						DirectCast(Sender,TextBox).Text = strArray(0) & ".0.0.0"
					Case 2
						DirectCast(Sender,TextBox).Text = strArray(0) & "." & strArray(1) & ".0.0"
					Case 3
						DirectCast(Sender,TextBox).Text = strArray(0) & "." & strArray(1)& "." & strArray(2) & ".0"
					Case Else
						DirectCast(Sender,TextBox).Text = strArray(0) & "." & strArray(1)& "." & strArray(2) & "." & strArray(3)
				End Select
			End If
		End If
	End Sub
	
	Private Sub ValidateGuid(sender As Object, e As CancelEventArgs)
		If TypeOf sender Is TextBox Then
			Try
				Dim g As New Guid(DirectCast(sender, TextBox).Text)
				DirectCast(sender, TextBox).Text = g.ToString()
				'do nothing
			Catch
			End Try
		End If
	End Sub
	
	Private Sub ValidateForm(sender As Object, e As EventArgs)
		ValidateForm()
	End Sub
	
	'Verify the form and set the icons accordingly.
	Sub ValidateForm
		Call ValidateFields
		Call ValidateRule
	End Sub
	
	'Validate the individual fields.
	Sub ValidateFields
		
		If Me.cboComparison.SelectedIndex = -1 Then
			Me.errorProviderRules.SetError(Me.cboComparison,globalRM.GetString("warning_rules_comparison"))
		Else
			Me.errorProviderRules.SetError(Me.cboComparison,"")
		End If
		
		If String.IsNullOrEmpty(Me.txtOSMajorVersion.Text) Or String.IsNullOrEmpty(Me.txtOSMinorVersion.Text) Then
			Me.errorProviderRules.SetError(Me.txtOSMinorVersion,globalRM.GetString("warning_rules_OS"))
		Else
			Me.errorProviderRules.SetError(Me.txtOSMinorVersion,"")
		End If
		
		If Me.cboLanguage.SelectedIndex = -1 Then
			Select Case Me.cboRuleType.SelectedIndex
				Case RuleTypes.WindowsLanguage
					Me.errorProviderRules.SetError(Me.cboLanguage,globalRM.GetString("warning_rules_language"))
				Case Else
					Me.errorProviderRules.SetError(Me.cboLanguage,"")
			End Select
		Else
			Me.errorProviderRules.SetError(Me.cboLanguage,"")
		End If
		
		If Me.cboProcessorType.SelectedIndex = -1 Then
			Me.errorProviderRules.SetError(Me.cboProcessorType,globalRM.GetString("warning_rules_processor"))
		Else
			Me.errorProviderRules.SetError(Me.cboProcessorType,"")
		End If
		
		If Me.cboRegistryKey.SelectedIndex = -1 Then
			Me.errorProviderRules.SetError(Me.txtRegistrySubKey,globalRM.GetString("warning_rules_registry_key"))
		Else If String.IsNullOrEmpty(Me.txtRegistrySubKey.Text) Then
			Me.errorProviderRules.SetError(Me.txtRegistrySubKey,globalRM.GetString("warning_rules_registry_sub_key"))
		Else
			Me.errorProviderRules.SetError(Me.txtRegistrySubKey,"")
		End If
		
		If Me.cboRegistryValueType.SelectedIndex = -1 Then
			Me.errorProviderRules.SetError(Me.cboRegistryValueType,globalRM.GetString("warning_rules_registry_type"))
		Else
			Me.errorProviderRules.SetError(Me.cboRegistryValueType,"")
		End If
		
		If String.IsNullOrEmpty(Me.txtFilePath.Text) Then
			Me.errorProviderRules.SetError(Me.txtFilePath,globalRM.GetString("warning_rules_file_path"))
		Else
			Me.errorProviderRules.SetError(Me.txtFilePath,"")
		End If
		
		If String.IsNullOrEmpty(Me.txtVersion.Text) Then
			Select Case Me.cboRuleType.SelectedIndex
				Case RuleTypes.FileVersion
					Me.errorProviderRules.SetError(Me.txtVersion,globalRM.GetString("warning_rules_version"))
				Case RuleTypes.FileVersionWithRegistry
					Me.errorProviderRules.SetError(Me.txtVersion,globalRM.GetString("warning_rules_version"))
				Case Else
					Me.errorProviderRules.SetError(Me.txtVersion,"")
			End Select
		Else
			Me.errorProviderRules.SetError(Me.txtVersion,"")
		End If
		
		'TODO: for RegDWord and RegExpandSz rule, this must be numeric
		'Set the Data field error based on the selected rule type since this field is repurposed for several rules.
		If String.IsNullOrEmpty(Me.txtData.Text) Then
			Select Case Me.cboRuleType.SelectedIndex
				Case RuleTypes.FileSize
					Me.errorProviderRules.SetError(Me.txtData,globalRM.GetString("warning_rules_file_size"))
				Case RuleTypes.FileSizeWithRegistry
					Me.errorProviderRules.SetError(Me.txtData,globalRM.GetString("warning_rules_file_size"))
				Case RuleTypes.RegistryDWORDValue
					Me.errorProviderRules.SetError(Me.txtData,globalRM.GetString("warning_rules_registry_value"))
				Case RuleTypes.RegistryExpandSzValue
					Me.errorProviderRules.SetError(Me.txtData,globalRM.GetString("warning_rules_registry_value"))
				Case RuleTypes.RegistrySzValue
					Me.errorProviderRules.SetError(Me.txtData,globalRM.GetString("warning_rules_registry_value"))
				Case RuleTypes.WMIQuery
					Me.errorProviderRules.SetError(Me.txtData,globalRM.GetString("warning_rules_namespace"))
				Case Else
					Me.errorProviderRules.SetError(Me.txtData,"")
			End Select
		Else
			Me.errorProviderRules.SetError(Me.txtData,"")
		End If
		
		If Not Me.dtpDate.Checked Then
			Me.errorProviderRules.SetError(Me.dtpDate,globalRM.GetString("warning_rules_date"))
		Else
			Me.errorProviderRules.SetError(Me.dtpDate,"")
		End If
		
		If String.IsNullOrEmpty(Me.txtQuery.Text) Then
			Me.errorProviderRules.SetError(Me.txtQuery,globalRM.GetString("warning_rules_query"))
		Else
			Me.errorProviderRules.SetError(Me.txtQuery,"")
		End If
		
		Try
			Dim g As New Guid(Me.txtProductCode.Text)
			Me.errorProviderRules.SetError(Me.txtProductCode,"")
		Catch
			Me.errorProviderRules.SetError(Me.txtProductCode,globalRM.GetString("warning_rules_GUID"))
		End Try
		
		Try
			Dim g As New Guid(Me.txtPatchCode.Text)
			Me.errorProviderRules.SetError(Me.txtPatchCode,"")
		Catch
			Me.errorProviderRules.SetError(Me.txtPatchCode,globalRM.GetString("warning_rules_GUID"))
		End Try
	End Sub
	
	'Enable or disable the Add Rule button based on current rule
	' and which fields are valid.  The verification looks to see if
	' the appropriate validation picture boxes have the proper boolean in their tag.
	Sub ValidateRule
		
		If Me.cboRuleType.SelectedIndex >= 0 Then 'Verify based on combobox selection.
			Select Case Me.cboRuleType.SelectedIndex
				Case RuleTypes.WindowsVersion
					btnAdd.Enabled = String.IsNullOrEmpty(Me.errorProviderRules.GetError(Me.cboComparison) & Me.errorProviderRules.GetError(Me.txtOSMinorVersion))
				Case RuleTypes.WindowsLanguage
					btnAdd.Enabled = String.IsNullOrEmpty(Me.errorProviderRules.GetError(Me.cboLanguage))
				Case RuleTypes.ProcessorArchitecture
					btnAdd.Enabled = String.IsNullOrEmpty(Me.errorProviderRules.GetError(Me.cboProcessorType))
				Case RuleTypes.FileExists
					btnAdd.Enabled = String.IsNullOrEmpty(Me.errorProviderRules.GetError(Me.txtFilePath))
				Case RuleTypes.FileExistsWithRegistry
					btnAdd.Enabled = String.IsNullOrEmpty(Me.errorProviderRules.GetError(Me.cboRegistryKey) & Me.errorProviderRules.GetError(Me.txtRegistrySubKey) & Me.errorProviderRules.GetError(Me.txtFilePath))
				Case RuleTypes.FileCreation
					btnAdd.Enabled = String.IsNullOrEmpty(Me.errorProviderRules.GetError(Me.txtFilePath) & Me.errorProviderRules.GetError(Me.cboComparison) & Me.errorProviderRules.GetError(Me.dtpDate))
				Case RuleTypes.FileCreationWithRegistry
					btnAdd.Enabled = String.IsNullOrEmpty(Me.errorProviderRules.GetError(Me.cboRegistryKey) & Me.errorProviderRules.GetError(Me.txtRegistrySubKey) & Me.errorProviderRules.GetError(Me.txtRegistryValue) & Me.errorProviderRules.GetError(Me.cboComparison) & Me.errorProviderRules.GetError(Me.dtpDate))
				Case RuleTypes.FileModified
					btnAdd.Enabled = String.IsNullOrEmpty(Me.errorProviderRules.GetError(Me.txtFilePath) & Me.errorProviderRules.GetError(Me.cboComparison) & Me.errorProviderRules.GetError(Me.dtpDate))
				Case RuleTypes.FileModifiedWithRegistry
					btnAdd.Enabled = String.IsNullOrEmpty(Me.errorProviderRules.GetError(Me.cboRegistryKey) & Me.errorProviderRules.GetError(Me.txtRegistrySubKey) & Me.errorProviderRules.GetError(Me.txtFilePath)& Me.errorProviderRules.GetError(Me.cboComparison) & Me.errorProviderRules.GetError(Me.dtpDate))
				Case RuleTypes.FileSize
					btnAdd.Enabled =  String.IsNullOrEmpty(Me.errorProviderRules.GetError(Me.txtFilePath) & Me.errorProviderRules.GetError(Me.cboComparison) & Me.errorProviderRules.GetError(Me.txtData))
				Case RuleTypes.FileSizeWithRegistry
					btnAdd.Enabled = String.IsNullOrEmpty(Me.errorProviderRules.GetError(Me.cboRegistryKey) & Me.errorProviderRules.GetError(Me.txtRegistrySubKey) & Me.errorProviderRules.GetError(Me.txtFilePath) & Me.errorProviderRules.GetError(Me.cboComparison) & Me.errorProviderRules.GetError(Me.txtData))
				Case RuleTypes.FileVersion
					btnAdd.Enabled = String.IsNullOrEmpty( Me.errorProviderRules.GetError(Me.txtFilePath) & Me.errorProviderRules.GetError(Me.cboComparison) & Me.errorProviderRules.GetError(Me.txtVersion))
				Case RuleTypes.FileVersionWithRegistry
					btnAdd.Enabled = String.IsNullOrEmpty( Me.errorProviderRules.GetError(Me.cboRegistryKey) & Me.errorProviderRules.GetError(Me.txtRegistrySubKey) & Me.errorProviderRules.GetError(Me.txtFilePath)  & Me.errorProviderRules.GetError(Me.cboComparison) & Me.errorProviderRules.GetError(Me.txtVersion))
				Case RuleTypes.RegistryKeyExists
					btnAdd.Enabled = String.IsNullOrEmpty(Me.errorProviderRules.GetError(Me.cboRegistryKey) & Me.errorProviderRules.GetError(Me.txtRegistrySubKey) )
				Case RuleTypes.RegistryValueExists
					btnAdd.Enabled = String.IsNullOrEmpty(Me.errorProviderRules.GetError(Me.cboRegistryKey) & Me.errorProviderRules.GetError(Me.txtRegistrySubKey) & Me.errorProviderRules.GetError(Me.cboRegistryValueType))
				Case RuleTypes.RegistryDWORDValue
					btnAdd.Enabled = String.IsNullOrEmpty(Me.errorProviderRules.GetError(Me.cboRegistryKey) & Me.errorProviderRules.GetError(Me.txtRegistrySubKey) & Me.errorProviderRules.GetError(Me.cboComparison) & Me.errorProviderRules.GetError(Me.txtData))
				Case RuleTypes.RegistryExpandSzValue
					btnAdd.Enabled = String.IsNullOrEmpty(Me.errorProviderRules.GetError(Me.cboRegistryKey) & Me.errorProviderRules.GetError(Me.txtRegistrySubKey) & Me.errorProviderRules.GetError(Me.cboComparison) & Me.errorProviderRules.GetError(Me.txtData))
				Case RuleTypes.RegistryVersionInSz
					btnAdd.Enabled = String.IsNullOrEmpty( Me.errorProviderRules.GetError(Me.cboRegistryKey) & Me.errorProviderRules.GetError(Me.txtRegistrySubKey) & Me.errorProviderRules.GetError(Me.cboComparison) & Me.errorProviderRules.GetError(Me.txtVersion))
				Case RuleTypes.RegistrySzValue
					btnAdd.Enabled = String.IsNullOrEmpty( Me.errorProviderRules.GetError(Me.cboRegistryKey) & Me.errorProviderRules.GetError(Me.txtRegistrySubKey) & Me.errorProviderRules.GetError(Me.cboComparison) & Me.errorProviderRules.GetError(Me.txtData))
				Case RuleTypes.WMIQuery
					btnAdd.Enabled = String.IsNullOrEmpty( Me.errorProviderRules.GetError(Me.txtQuery) & Me.errorProviderRules.GetError(Me.txtData))
				Case RuleTypes.MsiComponentInstalled
					btnAdd.Enabled = gceProductCollection.ValidInput AndAlso gceComponentCollection.ValidInput
				Case RuleTypes.MsiFeatureInstalled
					btnAdd.Enabled = gceProductCollection.ValidInput AndAlso gceFeatureCollection.ValidInput
				Case RuleTypes.MsiPatchInstalled
					btnAdd.Enabled = Me.gceProductCollection.ValidInput AndAlso String.IsNullOrEmpty(Me.errorProviderRules.GetError(Me.txtPatchCode))
				Case RuleTypes.MsiProductInstalled
					btnAdd.Enabled = String.IsNullOrEmpty(Me.errorProviderRules.GetError(Me.txtProductCode))
			End Select
		End If 'Combobox has selection.
	End Sub
	
	'Strip out reserved XML characters and deal with characters not in the 7-bit ASCII set.
	'Written by Tony Proctor
	'Found here: http://www.codenewsgroups.net/vb/t5072-xml-escape-sequence-routine.aspx
	Public Function StringToXML(ByVal sText As String) As String
		Dim i As Integer
		Dim sCh As String
		Dim tmpString As String
		Const SKIP As Integer = 6   'Character count to skip over character entity (i.e. at least '&#nnn;')
		
		' Do entity references first
		tmpString = Replace(Replace(Replace(Replace(Replace( sText, "&", "&amp;"), "<", "&lt;"), ">", "&gt;"), """", "&quot;"), "'", "&apos;")
		
		' Now do character entities for anything that's not 7-bit ASCII
		i = 1
		Do While i <= Len(tmpString)
			sCh = Mid$(tmpString, i, 1)
			If AscW(sCh) > 127 Then
				tmpString = Microsoft.VisualBasic.Left$( tmpString, i - 1) & "&#" & CStr(AscW(sCh)) & ";" & Microsoft.VisualBasic.Mid$(tmpString, i + 1)
				i = i + SKIP
			Else
				i = i + 1
			End If
		Loop
		
		Return tmpString
	End Function
	#END Region
	
End Class
