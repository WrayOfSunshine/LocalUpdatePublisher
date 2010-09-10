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
	Private Const _startingYConstant As Integer = 10
	Private Const _spacingConstant As Integer = 25
	Private ReadOnly _numericComparisons As String ()
	Private ReadOnly _stringComparisons As String ()
	
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
		'Set the ReadOnly string arrays for the comboboxes.
		' Currently we use the first item to test if the array is already
		' loaded into the combobox.
		_numericComparisons =  New String() {"Equal To", "Less Than", "Less Than or Equal To", "Greater Than", "Greater Than or Equal To"}
		_stringComparisons =  New String() {"Begins With", "Ends With", "Contains", "Equals"}
		
		
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		'Load the Rule Types into the combo box based on the Enum.
		For Each tmpRuleType As String In [Enum].GetNames(GetType(RuleTypes))
			cboRuleType.Items.Add([Enum].Parse(GetType(RuleTypes), tmpRuleType))
		Next
		
		Call SetVerificationIcons
	End Sub
	
	#Region "Events"
	
	'If a rule is passed then load it.
	Public Overloads Function ShowDialog(owner As IWin32Window, ruleXml As String) As DialogResult
		ClearForm()
		If String.IsNullOrEmpty(ruleXml) Then
			Me.btnAdd.Text = "Add Rule"
		Else
			Me.btnAdd.Text = "Save Rule"
			LoadRule(ruleXml)
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
	' grouped into distinct panels so that we can manipulate groupings
	' of controls rather than individual ones.  We loop through the controls
	' looking for the ones we need shown and then hide the rest.
	Private Sub cboRuleTypeSelectedIndexChanged(sender As Object, e As EventArgs)
		'Loop through each groupicox item on the second panel.  Hide anything we don't
		' need and position what we do need.
		If Me.cboRuleType.SelectedIndex >= 0 Then 'The combobox must be populated.
			
			'Setup the panel based on the selection from the combobox.
			Select Case Me.cboRuleType.SelectedIndex
				Case RuleTypes.WindowsVersion
					For Each controlObject As Control In Me.splitContainer.Panel2.Controls
						Select Case controlObject.Name
							Case "pnlComparison"
								
								'Only change if we need to by testing to see if the
								' first element needed already exists in the combobox.
								If Not Me.cboComparison.Items.Contains(_numericComparisons(0))
									Me.cboComparison.Items.Clear
									Me.cboComparison.Items.AddRange(_numericComparisons)
								End If
								
								controlObject.Show
								controlObject.Top = _startingYConstant
							Case "pnlOSVersion"
								controlObject.Show
								controlObject.Top = _startingYConstant + _spacingConstant
							Case "pnlServicePack"
								controlObject.Show
								controlObject.Top = _startingYConstant + ( 2 * _spacingConstant )
							Case "pnlData"
								Me.txtData.Width = Me.txtVersion.Width
								Me.txtData.Text = ""
								Me.lblData.Text = "Build Number"
								Me.lblDataInfo.Hide
								Me.picData.Left = Me.txtData.Left + Me.txtData.Width + 5
								Me.picData.Hide
								Me.picData.Tag = True
								controlObject.Show
								controlObject.Top = _startingYConstant + (3 * _spacingConstant)
							Case "pnlProductType"
								controlObject.Show
								controlObject.Top = _startingYConstant + (4 * _spacingConstant)
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.WindowsLanguage
					For Each controlObject As Control In Me.splitContainer.Panel2.Controls
						Select Case controlObject.Name
							Case "pnlLanguage"
								controlObject.Show
								controlObject.Top = _startingYConstant
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.ProcessorArchitecture
					For Each controlObject As Control In Me.splitContainer.Panel2.Controls
						Select Case controlObject.Name
							Case "pnlProcessorType"
								controlObject.Show
								controlObject.Top = _startingYConstant
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.FileExists
					For Each controlObject As Control In Me.splitContainer.Panel2.Controls
						Select Case controlObject.Name
							Case "pnlEnvironmentVariable"
								controlObject.Show
								controlObject.Top = _startingYConstant
							Case "pnlFilePath"
								controlObject.Show
								controlObject.Top = _startingYConstant + _spacingConstant
							Case "pnlVersion"
								Me.picVersion.Hide
								Me.picVersion.Tag = True
								controlObject.Show
								controlObject.Top = _startingYConstant + (2 * _spacingConstant)
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.FileExistsWithRegistry
					For Each controlObject As Control In Me.splitContainer.Panel2.Controls
						Select Case controlObject.Name
							Case "pnlRegistryKey"
								controlObject.Show
								controlObject.Top = _startingYConstant
							Case "pnlRegistryValue"
								Me.picRegistryValue.Hide
								controlObject.Show
								controlObject.Top = _startingYConstant + _spacingConstant
							Case "pnlRegistry32Bit"
								controlObject.Show
								controlObject.Top = _startingYConstant + _spacingConstant
								controlObject.Left = Me.pnlRegistryValue.Left + Me.pnlRegistryValue.Width + 5
							Case "pnlFilePath"
								controlObject.Show
								controlObject.Top = _startingYConstant + (2 * _spacingConstant)
							Case "pnlVersion"
								Me.picVersion.Hide
								Me.picVersion.Tag = True
								controlObject.Show
								controlObject.Top = _startingYConstant + (3 * _spacingConstant)
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.FileCreation
					For Each controlObject As Control In Me.splitContainer.Panel2.Controls
						Select Case controlObject.Name
							Case "pnlEnvironmentVariable"
								controlObject.Show
								controlObject.Top = _startingYConstant
							Case "pnlFilePath"
								controlObject.Show
								controlObject.Top = _startingYConstant + _spacingConstant
							Case "pnlComparison"
								'Only change if we need to by testing to see if the
								' first element needed already exists in the combobox
								If Not Me.cboComparison.Items.Contains(_numericComparisons(0))
									Me.cboComparison.Items.Clear
									Me.cboComparison.Items.AddRange(_numericComparisons)
								End If
								
								controlObject.Show
								controlObject.Top = _startingYConstant + (2 * _spacingConstant)
							Case "pnlDate"
								Me.lblDate.Text = "Created Date:"
								controlObject.Show
								controlObject.Top = _startingYConstant + (3 * _spacingConstant)
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.FileCreationWithRegistry
					For Each controlObject As Control In Me.splitContainer.Panel2.Controls
						Select Case controlObject.Name
							Case "pnlRegistryKey"
								controlObject.Show
								controlObject.Top = _startingYConstant
							Case "pnlRegistryValue"
								Me.picRegistryValue.Hide
								controlObject.Show
								controlObject.Top = _startingYConstant + _spacingConstant
							Case "pnlRegistry32Bit"
								controlObject.Show
								controlObject.Top = _startingYConstant + _spacingConstant
								controlObject.Left = Me.pnlRegistryValue.Left + Me.pnlRegistryValue.Width + 5
							Case "pnlFilePath"
								controlObject.Show
								controlObject.Top = _startingYConstant + (2 * _spacingConstant)
							Case "pnlComparison"
								'Only change if we need to by testing to see if the
								' first element needed already exists in the combobox.
								If Not Me.cboComparison.Items.Contains(_numericComparisons(0))
									Me.cboComparison.Items.Clear
									Me.cboComparison.Items.AddRange(_numericComparisons)
								End If
								controlObject.Show
								controlObject.Top = _startingYConstant + (3 * _spacingConstant)
							Case "pnlDate"
								Me.lblDate.Text = "Created Date:"
								controlObject.Show
								controlObject.Top = _startingYConstant + (4 * _spacingConstant)
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.FileModified
					For Each controlObject As Control In Me.splitContainer.Panel2.Controls
						Select Case controlObject.Name
							Case "pnlEnvironmentVariable"
								controlObject.Show
								controlObject.Top = _startingYConstant
							Case "pnlFilePath"
								controlObject.Show
								controlObject.Top = _startingYConstant + _spacingConstant
							Case "pnlComparison"
								'Only change if we need to by testing to see if the
								' first element needed already exists in the combobox.
								If Not Me.cboComparison.Items.Contains(_numericComparisons(0))
									Me.cboComparison.Items.Clear
									Me.cboComparison.Items.AddRange(_numericComparisons)
								End If
								controlObject.Show
								controlObject.Top = _startingYConstant + (2 * _spacingConstant)
							Case "pnlDate"
								Me.lblDate.Text = "Modified Date:"
								controlObject.Show
								controlObject.Top = _startingYConstant + (3 * _spacingConstant)
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.FileModifiedWithRegistry
					For Each controlObject As Control In Me.splitContainer.Panel2.Controls
						Select Case controlObject.Name
							Case "pnlRegistryKey"
								controlObject.Show
								controlObject.Top = _startingYConstant
							Case "pnlRegistryValue"
								Me.picRegistryValue.Hide
								controlObject.Show
								controlObject.Top = _startingYConstant + _spacingConstant
							Case "pnlRegistry32Bit"
								controlObject.Show
								controlObject.Top = _startingYConstant + _spacingConstant
								controlObject.Left = Me.pnlRegistryValue.Left + Me.pnlRegistryValue.Width + 5
							Case "pnlRegistry32Bit"
								controlObject.Show
								controlObject.Top = _startingYConstant + _spacingConstant
								controlObject.Left = Me.pnlRegistryValue.Left + Me.pnlRegistryValue.Width + 5
							Case "pnlFilePath"
								controlObject.Show
								controlObject.Top = _startingYConstant + (2 * _spacingConstant)
							Case "pnlComparison"
								'Only change if we need to by testing to see if the
								' first element needed already exists in the combobox.
								If Not Me.cboComparison.Items.Contains(_numericComparisons(0))
									Me.cboComparison.Items.Clear
									Me.cboComparison.Items.AddRange(_numericComparisons)
								End If
								controlObject.Show
								controlObject.Top = _startingYConstant + (3 * _spacingConstant)
							Case "pnlDate"
								Me.lblDate.Text = "Modified Date:"
								controlObject.Show
								controlObject.Top = _startingYConstant + (4 * _spacingConstant)
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.FileSize
					For Each controlObject As Control In Me.splitContainer.Panel2.Controls
						Select Case controlObject.Name
							Case "pnlEnvironmentVariable"
								controlObject.Show
								controlObject.Top = _startingYConstant
							Case "pnlFilePath"
								controlObject.Show
								controlObject.Top = _startingYConstant + _spacingConstant
							Case "pnlComparison"
								'Only change if we need to by testing to see if the
								' first element needed already exists in the combobox.
								If Not Me.cboComparison.Items.Contains(_numericComparisons(0))
									Me.cboComparison.Items.Clear
									Me.cboComparison.Items.AddRange(_numericComparisons)
								End If
								controlObject.Show
								controlObject.Top = _startingYConstant + (2 * _spacingConstant)
							Case "pnlData"
								Me.txtData.Width = Me.txtVersion.Width
								Me.txtData.Text = ""
								Me.lblData.Text = "Size:"
								Me.lblDataInfo.Text = "in bytes (ex. 1024)"
								Me.lblDataInfo.Show
								Me.picData.Show
								Me.picData.Tag = False
								Me.picData.Left = Me.lblDataInfo.Left + me.lblDataInfo.Width + 5
								controlObject.Show
								controlObject.Top = _startingYConstant + (3 * _spacingConstant)
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.FileSizeWithRegistry
					For Each controlObject As Control In Me.splitContainer.Panel2.Controls
						Select Case controlObject.Name
							Case "pnlRegistryKey"
								controlObject.Show
								controlObject.Top = _startingYConstant
							Case "pnlRegistryValue"
								Me.picRegistryValue.Hide
								controlObject.Show
								controlObject.Top = _startingYConstant + _spacingConstant
							Case "pnlRegistry32Bit"
								controlObject.Show
								controlObject.Top = _startingYConstant + _spacingConstant
								controlObject.Left = Me.pnlRegistryValue.Left + Me.pnlRegistryValue.Width + 5
							Case "pnlFilePath"
								controlObject.Show
								controlObject.Top = _startingYConstant + (2 * _spacingConstant)
							Case "pnlComparison"
								'Only change if we need to by testing to see if the
								' first element needed already exists in the combobox.
								If Not Me.cboComparison.Items.Contains(_numericComparisons(0))
									Me.cboComparison.Items.Clear
									Me.cboComparison.Items.AddRange(_numericComparisons)
								End If
								controlObject.Show
								controlObject.Top = _startingYConstant + (3 * _spacingConstant)
							Case "pnlData"
								Me.txtData.Width = Me.txtVersion.Width
								Me.txtData.Text = ""
								Me.lblData.Text = "Size:"
								Me.lblDataInfo.Text = "in bytes (ex. 1024)"
								Me.lblDataInfo.Show
								Me.picData.Show
								Me.picData.Tag = False
								Me.picData.Left = Me.lblDataInfo.Left + me.lblDataInfo.Width + 5
								controlObject.Show
								controlObject.Top = _startingYConstant + (4 * _spacingConstant)
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.FileVersion
					For Each controlObject As Control In Me.splitContainer.Panel2.Controls
						Select Case controlObject.Name
							Case "pnlEnvironmentVariable"
								controlObject.Show
								controlObject.Top = _startingYConstant
							Case "pnlFilePath"
								controlObject.Show
								controlObject.Top = _startingYConstant + _spacingConstant
							Case "pnlComparison"
								'Only change if we need to by testing to see if the
								' first element needed already exists in the combobox.
								If Not Me.cboComparison.Items.Contains(_numericComparisons(0))
									Me.cboComparison.Items.Clear
									Me.cboComparison.Items.AddRange(_numericComparisons)
								End If
								controlObject.Show
								controlObject.Top = _startingYConstant + (2 * _spacingConstant)
							Case "pnlVersion"
								Me.picVersion.Show
								Me.picVersion.Tag = False
								controlObject.Show
								controlObject.Top = _startingYConstant + (3 * _spacingConstant)
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.FileVersionWithRegistry
					For Each controlObject As Control In Me.splitContainer.Panel2.Controls
						Select Case controlObject.Name
							Case "pnlRegistryKey"
								controlObject.Show
								controlObject.Top = _startingYConstant
							Case "pnlRegistryValue"
								Me.picRegistryValue.Hide
								controlObject.Show
								controlObject.Top = _startingYConstant + _spacingConstant
							Case "pnlRegistry32Bit"
								controlObject.Show
								controlObject.Top = _startingYConstant + _spacingConstant
								controlObject.Left = Me.pnlRegistryValue.Left + Me.pnlRegistryValue.Width + 5
							Case "pnlFilePath"
								controlObject.Show
								controlObject.Top = _startingYConstant + (2 * _spacingConstant)
							Case "pnlComparison"
								'Only change if we need to by testing to see if the
								' first element needed already exists in the combobox.
								If Not Me.cboComparison.Items.Contains(_numericComparisons(0))
									Me.cboComparison.Items.Clear
									Me.cboComparison.Items.AddRange(_numericComparisons)
								End If
								controlObject.Show
								controlObject.Top = _startingYConstant + (3 * _spacingConstant)
							Case "pnlVersion"
								Me.picVersion.Show
								Me.picVersion.Tag = False
								controlObject.Show
								controlObject.Top = _startingYConstant + (4 * _spacingConstant)
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.RegistryKeyExists
					For Each controlObject As Control In Me.splitContainer.Panel2.Controls
						Select Case controlObject.Name
							Case "pnlRegistryKey"
								controlObject.Show
								controlObject.Top = _startingYConstant
							Case "pnlRegistry32Bit"
								controlObject.Show
								controlObject.Top = _startingYConstant + _spacingConstant
								controlObject.Left = Me.cboRegistryKey.Left
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.RegistryValueExists
					For Each controlObject As Control In Me.splitContainer.Panel2.Controls
						Select Case controlObject.Name
							Case "pnlRegistryKey"
								controlObject.Show
								controlObject.Top = _startingYConstant
							Case "pnlRegistryValue"
								Me.picRegistryValue.Hide
								controlObject.Show
								controlObject.Top = _startingYConstant + _spacingConstant
							Case "pnlRegistry32Bit"
								controlObject.Show
								controlObject.Top = _startingYConstant + _spacingConstant
								controlObject.Left = Me.pnlRegistryValue.Left + Me.pnlRegistryValue.Width + 5
							Case "pnlRegistryValueType"
								controlObject.Show
								controlObject.Top = _startingYConstant + (2 * _spacingConstant)
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.RegistryDWORDValue
					For Each controlObject As Control In Me.splitContainer.Panel2.Controls
						Select Case controlObject.Name
							Case "pnlRegistryKey"
								controlObject.Show
								controlObject.Top = _startingYConstant
							Case "pnlRegistryValue"
								Me.picRegistryValue.Hide
								controlObject.Show
								controlObject.Top = _startingYConstant + _spacingConstant
							Case "pnlRegistry32Bit"
								controlObject.Show
								controlObject.Top = _startingYConstant + _spacingConstant
								controlObject.Left = Me.pnlRegistryValue.Left + Me.pnlRegistryValue.Width + 5
							Case "pnlComparison"
								'Only change if we need to by testing to see if the
								' first element needed already exists in the combobox.
								If Not Me.cboComparison.Items.Contains(_numericComparisons(0))
									Me.cboComparison.Items.Clear
									Me.cboComparison.Items.AddRange(_numericComparisons)
								End If
								controlObject.Show
								controlObject.Top = _startingYConstant + (2 * _spacingConstant)
							Case "pnlData"
								Me.lblData.Text = "DWORD Value:"
								Me.lblDataInfo.Hide
								Me.txtData.Width = Me.txtFilePath.Width
								Me.txtData.Text = ""
								Me.picData.Left = Me.txtData.Left + Me.txtData.Width + 5
								Me.picData.Show
								Me.picData.Tag = False
								controlObject.Show
								controlObject.Top = _startingYConstant + (3 * _spacingConstant)
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.RegistryExpandSzValue
					For Each controlObject As Control In Me.splitContainer.Panel2.Controls
						Select Case controlObject.Name
							Case "pnlRegistryKey"
								controlObject.Show
								controlObject.Top = _startingYConstant
							Case "pnlRegistryValue"
								Me.picRegistryValue.Hide
								controlObject.Show
								controlObject.Top = _startingYConstant + _spacingConstant
							Case "pnlRegistry32Bit"
								controlObject.Show
								controlObject.Top = _startingYConstant + _spacingConstant
								controlObject.Left = Me.pnlRegistryValue.Left + Me.pnlRegistryValue.Width + 5
							Case "pnlComparison"
								'Only change if we need to by testing to see if the
								' first element needed already exists in the combobox.
								If Not Me.cboComparison.Items.Contains(_stringComparisons(0))
									Me.cboComparison.Items.Clear
									Me.cboComparison.Items.AddRange(_stringComparisons)
								End If
								controlObject.Show
								controlObject.Top = _startingYConstant + (2 * _spacingConstant)
							Case "pnlData"
								Me.lblData.Text = "String:"
								Me.lblDataInfo.Hide
								Me.txtData.Width = Me.txtFilePath.Width
								Me.txtData.Text = ""
								Me.picData.Left = Me.txtData.Left + Me.txtData.Width + 5
								Me.picData.Show
								Me.picData.Tag = False
								controlObject.Show
								controlObject.Top = _startingYConstant + (3 * _spacingConstant)
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.RegistryVersionInSz
					For Each controlObject As Control In Me.splitContainer.Panel2.Controls
						Select Case controlObject.Name
							Case "pnlRegistryKey"
								controlObject.Show
								controlObject.Top = _startingYConstant
							Case "pnlRegistryValue"
								Me.picRegistryValue.Hide
								controlObject.Show
								controlObject.Top = _startingYConstant + _spacingConstant
							Case "pnlRegistry32Bit"
								controlObject.Show
								controlObject.Top = _startingYConstant + _spacingConstant
								controlObject.Left = Me.pnlRegistryValue.Left + Me.pnlRegistryValue.Width + 5
							Case "pnlComparison"
								'Only change if we need to by testing to see if the
								' first element needed already exists in the combobox.
								If Not Me.cboComparison.Items.Contains(_stringComparisons(0))
									Me.cboComparison.Items.Clear
									Me.cboComparison.Items.AddRange(_stringComparisons)
								End If
								controlObject.Show
								controlObject.Top = _startingYConstant + (2 * _spacingConstant)
							Case "pnlVersion"
								Me.picVersion.Show
								Me.picVersion.Tag = False
								controlObject.Show
								controlObject.Top = _startingYConstant + (3 * _spacingConstant)
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.RegistrySzValue
					For Each controlObject As Control In Me.splitContainer.Panel2.Controls
						Select Case controlObject.Name
							Case "pnlRegistryKey"
								controlObject.Show
								controlObject.Top = _startingYConstant
							Case "pnlRegistryValue"
								Me.picRegistryValue.Hide
								controlObject.Show
								controlObject.Top = _startingYConstant + _spacingConstant
							Case "pnlRegistry32Bit"
								controlObject.Show
								controlObject.Top = _startingYConstant + _spacingConstant
								controlObject.Left = Me.pnlRegistryValue.Left + Me.pnlRegistryValue.Width + 5
							Case "pnlComparison"
								'Only change if we need to by testing to see if the
								' first element needed already exists in the combobox.
								If Not Me.cboComparison.Items.Contains(_numericComparisons(0))
									Me.cboComparison.Items.Clear
									Me.cboComparison.Items.AddRange(_numericComparisons)
								End If
								controlObject.Show
								controlObject.Top = _startingYConstant + (2 * _spacingConstant)
							Case "pnlData"
								Me.txtData.Width = Me.txtFilePath.Width
								Me.txtData.Text = ""
								Me.lblData.Text = "String:"
								Me.lblDataInfo.Hide
								Me.picData.Left = Me.txtData.Left + Me.txtData.Width + 5
								Me.picData.Show
								Me.picData.Tag = False
								controlObject.Show
								controlObject.Top = _startingYConstant + (3 * _spacingConstant)
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.WMIQuery
					For Each controlObject As Control In Me.splitContainer.Panel2.Controls
						Select Case controlObject.Name
							Case "pnlData"
								Me.txtData.Width = Me.txtFilePath.Width
								Me.txtData.Text = ""
								Me.lblData.Text = "WMI Namespace:"
								Me.lblDataInfo.Hide
								Me.picData.Left = Me.txtData.Left + Me.txtData.Width + 5
								Me.picData.Show
								Me.picData.Tag = False
								controlObject.Show
								controlObject.Top = _startingYConstant
							Case "pnlQuery"
								controlObject.Top = _startingYConstant + _spacingConstant
								controlObject.Height = controlObject.Parent.Height - controlObject.Top - btnAdd.Height - _spacingConstant
								controlObject.Show
							Case Else
								controlObject.Hide
						End Select
					Next
				Case RuleTypes.MsiProductInstalled
					For Each controlObject As Control In Me.splitContainer.Panel2.Controls
						Select Case controlObject.Name
							Case "pnlProductCode"
								controlObject.Top = _startingYConstant
								controlObject.Show()
								Exit Select
							Case "pnlMaxVersion"
								controlObject.Top = _startingYConstant + _spacingConstant
								controlObject.Show()
								Exit Select
							Case "pnlMinVersion"
								controlObject.Top = _startingYConstant + (2 * _spacingConstant)
								controlObject.Show()
								Exit Select
							Case "pnlLanguage"
								controlObject.Top = _startingYConstant + (3 * _spacingConstant)
								controlObject.Show()
								Exit Select
							Case Else
								controlObject.Hide()
								Exit Select
						End Select
					Next
				Case RuleTypes.MsiPatchInstalled
					For Each controlObject As Control In Me.splitContainer.Panel2.Controls
						Select Case controlObject.Name
							Case "pnlProductCode"
								controlObject.Top = _startingYConstant
								controlObject.Show()
								Exit Select
							Case "pnlPatchCode"
								controlObject.Top = _startingYConstant + _spacingConstant
								controlObject.Show()
								Exit Select
							Case "pnlMaxVersion"
								controlObject.Top = _startingYConstant + (2 * _spacingConstant)
								controlObject.Show()
								Exit Select
							Case "pnlMinVersion"
								controlObject.Top = _startingYConstant + (3 * _spacingConstant)
								controlObject.Show()
								Exit Select
							Case "pnlLanguage"
								controlObject.Top = _startingYConstant + (4 * _spacingConstant)
								controlObject.Show()
								Exit Select
							Case Else
								controlObject.Hide()
								Exit Select
						End Select
					Next
				Case RuleTypes.MsiComponentInstalled
					For Each controlObject As Control In Me.splitContainer.Panel2.Controls
						Select Case controlObject.Name
							Case "pnlProductCollection"
								controlObject.Top = _startingYConstant
								controlObject.Show()
								Exit Select
							Case "pnlComponentCollection"
								controlObject.Top = _startingYConstant + (5 * _spacingConstant)
								controlObject.Show()
								Exit Select
							Case Else
								controlObject.Hide()
								Exit Select
						End Select
					Next
				Case RuleTypes.MsiFeatureInstalled
					For Each controlObject As Control In Me.splitContainer.Panel2.Controls
						Select Case controlObject.Name
							Case "pnlProductCollection"
								controlObject.Top = _startingYConstant
								controlObject.Show()
								Exit Select
							Case "pnlFeatureCollection"
								controlObject.Top = _startingYConstant + (5 * _spacingConstant)
								controlObject.Show()
								Exit Select
							Case Else
								controlObject.Hide()
								Exit Select
						End Select
					Next
				Case Else
					Msgbox("This Rule Type Isn't Supported Yet")
					For Each controlObject As Control In Me.splitContainer.Panel2.Controls
						If TypeOf controlObject Is Panel Then
							controlObject.Hide
						End If
					Next
			End Select
			
			Call VerifyForm
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
				Me.txtOSMajorVersion.Text = "7"
				Me.txtOSMinorVersion.Text = "0"
				Me.cboServicePack.Items.Add("SP 1")
			Case Else
				Me.txtOSMajorVersion.Text = "0"
				Me.txtOSMinorVersion.Text = "0"
		End Select
	End Sub
	
	'Call  GetOSVersionText with defaults
	Function GetOSVersionText() As String
		Return GetOSVersionText(Cint(Me.txtOSMajorVersion.Text), Cint(Me.txtOSMinorVersion.Text))
	End Function
	
	'Return the text based on the os version textboxes.
	Function GetOSVersionText(osMajor As Integer, osMinor As Integer) As String
		'Clear the service pack combobox.
		Me.cboServicePack.SelectedIndex = -1
		Me.cboServicePack.Items.Clear
		Me.cboServicePack.Items.Add("")
		
		Select Case osMajor
			Case 5
				Select Case osMinor
					Case 0
						Me.cboServicePack.Items.Add("SP 1")
						Me.cboServicePack.Items.Add("SP 2")
						Me.cboServicePack.Items.Add("SP 3")
						Me.cboServicePack.Items.Add("SP 4")
						Return "Windows 2000"
					Case 1
						Me.cboServicePack.Items.Add("SP 1")
						Me.cboServicePack.Items.Add("SP 2")
						Me.cboServicePack.Items.Add("SP 3")
						Return "Windows XP"
					Case 2
						Me.cboServicePack.Items.Add("SP 1")
						Me.cboServicePack.Items.Add("SP 2")
						Return "Windows Server 2003"
					Case Else
						Return Nothing
				End Select
			Case 6
				Select Case osMinor
					Case 0
						Me.cboServicePack.Items.Add("SP 1")
						Me.cboServicePack.Items.Add("SP 2")
						Return "Windows Vista"
					Case 1
						Me.cboServicePack.Items.Add("SP 1")
						Me.cboServicePack.Items.Add("SP 2")
						Return "Windows Server 2008"
					Case Else
						Return Nothing
				End Select
			Case 7
				Return "Windows 7"
			Case Else
				Return Nothing
		End Select
	End Function
	
	'Set the corresonding codes to the service pack.
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
	
	'Call GetServicePackText with defaults.
	Function GetServicePackText() As String
		If Me.txtSPMajorVersion.Text = Nothing Then
			Return Nothing
		Else
			Return GetServicePackText(Me.txtSPMajorVersion.Text)
		End If
	End Function
	
	#End Region
	
	#REGION "Shared Methods"
	
	'Set the corresonding text fields to the service pack.
	Shared Function GetServicePackText(spMajor As String) As String
		Return "SP " & spMajor
	End Function
	
	'Return the CSID number for the selected directory.
	Shared Private Function GetCSIDCode(directory As String) As String
		Select Case directory
			Case "System"
				Return "37"
			Case "Program Files"
				Return "38"
			Case "Program Files Common"
				Return "43"
			Case "Windows"
				Return "36"
			Case "Common Admin Tools"
				Return "47"
			Case "Common Alt Startup"
				Return "30"
			Case "Common App Data"
				Return "35"
			Case "Common Desktop Directory"
				Return "25"
			Case "Common Documents"
				Return "46"
			Case "Common Favorites"
				Return "31"
			Case "Common Music"
				Return "53"
			Case "Common Pictures"
				Return "54"
			Case "Common Programs"
				Return "23"
			Case "Common Startup"
				Return "24"
			Case "Common Start Menu"
				Return "22"
			Case "Common Templates"
				Return "45"
			Case "Common Video"
				Return "55"
			Case "Controls"
				Return "3"
			Case "Drives"
				Return "17"
			Case "Printers"
				Return "4"
			Case "Profiles"
				Return "62"
			Case Else
				Return Nothing
		End Select
	End Function
	
	'Return the CSID text for the selected directory.
	Shared  Function GetCsidCodeText(code As String) As String
		Select Case code
			Case "37"
				Return "System"
			Case "38"
				Return "Program Files"
			Case "43"
				Return "Program Files Common"
			Case "36"
				Return "Windows"
			Case "47"
				Return "Common Admin Tools"
			Case "30"
				Return "Common Alt Startup"
			Case "35"
				Return "Common App Data"
			Case "25"
				Return "Common Desktop Directory"
			Case "46"
				Return "Common Documents"
			Case "31"
				Return "Common Favorites"
			Case "53"
				Return "Common Music"
			Case "54"
				Return "Common Pictures"
			Case "23"
				Return "Common Programs"
			Case "24"
				Return "Common Startup"
			Case "22"
				Return "Common Start Menu"
			Case "45"
				Return "Common Templates"
			Case "55"
				Return "Common Video"
			Case "3"
				Return "Controls"
			Case "17"
				Return "Drives"
			Case "4"
				Return "Printers"
			Case "62"
				Return "Profiles"
			Case Else
				Return Nothing
		End Select
	End Function
	
	'Return the XML compatable comparison string based on the human readable string.
	Shared Function GetComparisonCode(comparison As String) As String
		Select Case comparison
			Case "Equal To"
				Return "EqualTo"
			Case "Less Than"
				Return "LessThan"
			Case "Less Than or Equal To"
				Return "LessThanOrEqualTo"
			Case "Greater Than"
				Return "GreaterThan"
			Case "Greater Than or Equal To"
				Return "GreaterThanOrEqualTo"
			Case "Begins With"
				Return "BeginsWith"
			Case "Ends With"
				Return "EndsWith"
			Case "Contains"
				Return "Contains"
			Case Else
				Return Nothing
		End Select
	End Function
	
	'Return the human readable string based on the XML compatable comparison string.
	Shared Function GetComparisonText(comparisonCode As String) As String
		Select Case comparisonCode
			Case "EqualTo"
				Return "Equal To"
			Case "LessThan"
				Return "Less Than"
			Case "LessThanOrEqualTo"
				Return "Less Than Or Equal To"
			Case "GreaterThan"
				Return "Greater Than"
			Case "GreaterThanOrEqualTo"
				Return "Greater Than Or Equal To"
			Case "BeginsWith"
				Return "Begins With"
			Case "EndsWith"
				Return "Ends With"
			Case "Contains"
				Return "Contains"
			Case Else
				Return Nothing
		End Select
	End Function
	
	'Return the language code based on the human readable string.
	Shared Function GetLanguageCode(language As String) As String
		Select Case language
			Case "Arabic"
				Return "ar"
			Case "Chinese (Hong Kong SAR)"
				Return "zh-HK"
			Case "Chinese (Simplified)"
				Return "zh-CHS"
			Case "Chinese (Traditional)"
				Return "zh-CHT"
			Case "Czech"
				Return "cs"
			Case "Danish"
				Return "da"
			Case "Dutch"
				Return "nl"
			Case "English"
				Return "en"
			Case "Finnish"
				Return "fi"
			Case "French"
				Return "fr"
			Case "German"
				Return "de"
			Case "Greek"
				Return "el"
			Case "Hebrew"
				Return "he"
			Case "Hungarian"
				Return "hu"
			Case "Italian"
				Return "it"
			Case "Japanese"
				Return "ja"
			Case "Korean"
				Return "ko"
			Case "Norwegian"
				Return "no"
			Case "Polish"
				Return "pl"
			Case "Portuguese"
				Return "pt"
			Case "Portuguese (Brazil)"
				Return "pt-BR"
			Case "Russian"
				Return "ru"
			Case "Spanish"
				Return "es"
			Case "Swedish"
				Return "sv"
			Case "Turkish"
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
	
	'Translates the MSI Language Number to an ISO 639-1 code.
	Public Shared Function GetISOForMsiLanguage(msiLanguageNumber As Integer) As String
		Select Case msiLanguageNumber
			Case 1
				Return "ar"
			Case 3076
				Return "zh-HK"
			Case 4
				Return "zh-CHS"
			Case 31748
				Return "zh-CHT"
			Case 5
				Return "cs"
			Case 6
				Return "da"
			Case 19
				Return "nl"
			Case 9
				Return "en"
			Case 11
				Return "fi"
			Case 12
				Return "fr"
			Case 7
				Return "de"
			Case 8
				Return "el"
			Case 13
				Return "he"
			Case 14
				Return "hu"
			Case 16
				Return "it"
			Case 17
				Return "ja"
			Case 18
				Return "ko"
			Case 20
				Return "no"
			Case 21
				Return "pl"
			Case 22
				Return "pt"
			Case 1046
				Return "pt-BR"
			Case 25
				Return "ru"
			Case 10
				Return "es"
			Case 29
				Return "sv"
			Case 31
				Return "tr"
			Case Nothing
				Return Nothing
			Case Else
				Throw New NotSupportedException("An ISO 639-1 code is not known for MSI Language " & msiLanguageNumber)
		End Select
	End Function
	
	'Return the human readable string based on the language code.
	Shared Function GetLanguageText(languageCode As String) As String
		Select Case languageCode
			Case "ar"
				Return "Arabic"
			Case "zh-HK"
				Return "Chinese (Hong Kong SAR)"
			Case "zh-CHS"
				Return "Chinese (Simplified)"
			Case "zh-CHT"
				Return "Chinese (Traditional)"
			Case "cs"
				Return "Czech"
			Case "da"
				Return "Danish"
			Case "nl"
				Return "Dutch"
			Case "en"
				Return "English"
			Case "fi"
				Return "Finnish"
			Case "fr"
				Return "French"
			Case "de"
				Return "German"
			Case "el"
				Return "Greek"
			Case "he"
				Return "Hebrew"
			Case "hu"
				Return "Hungarian"
			Case "it"
				Return "Italian"
			Case "ja"
				Return "Japanese"
			Case "ko"
				Return "Korean"
			Case "no"
				Return "Norwegian"
			Case "pl"
				Return "Polish"
			Case "pt"
				Return "Portuguese"
			Case "pt-BR"
				Return "Portuguese (Brazil)"
			Case "ru"
				Return "Russian"
			Case "es"
				Return "Spanish"
			Case "sv"
				Return "Swedish"
			Case "tr"
				Return "Turkish"
			Case Else
				Return Nothing
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
			Case 0
				Return "None"
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
				Me._readableRule += "   Comparison:" & Me.cboComparison.Text & " " & _
					"   Version:" & Me.cboOSVersion.Text & " "
				If Not String.IsNullOrEmpty(Me.cboServicePack.Text) Then Me._readableRule += "   ServicePack:" & Me.cboServicePack.Text
				If Not String.IsNullOrEmpty(Me.txtData.Text) Then Me._readableRule += "   BuildNumber:" & Me.txtData.Text
				If Not String.IsNullOrEmpty(Me.cboProductType.Text) Then Me._readableRule += "   Product Type:" & Me.cboProductType.Text
				
				'Set the xmlrule.
				_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
					"MajorVersion=""" & Me.txtOSMajorVersion.Text & """ " & _
					"MinorVersion=""" & Me.txtOSMinorVersion.Text & """ "
				If Not String.IsNullOrEmpty(Me.txtData.Text) Then _xmlRule += "BuildNumber=""" & Me.txtData.Text & """ "
				_xmlRule += "ServicePackMajor="""  & If (String.IsNullOrEmpty(Me.txtSPMajorVersion.Text) , "0" , Me.txtSPMajorVersion.Text ) & """ "
				_xmlRule += "ServicePackMinor="""  & If (String.IsNullOrEmpty(Me.txtSPMinorVersion.Text) , "0" , Me.txtSPMinorVersion.Text ) & """ "
				
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
				If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) Then Me._readableRule += "   CSID: " & Me.cboEnvironmentVariable.Text
				If Not String.IsNullOrEmpty(Me.txtVersion.Text) Then Me._readableRule += "   Version: " & Me.txtVersion.Text
				
				'Set the xmlrule.
				_xmlRule += "Path=""" & Me.txtFilePath.Text.Trim("\"c) & """ "
				If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text ) Then _xmlRule += "Csidl=""" & GetCSIDCode(Me.cboEnvironmentVariable.Text) & """ "
				If Not String.IsNullOrEmpty(Me.txtVersion.Text) Then _xmlRule += "Version=""" & Me.txtVersion.Text & """ "
				_xmlRule += " />"
			Case RuleTypes.FileExistsWithRegistry
				'Set the readable rule.
				Me._readableRule += Me.cboRegistryKey.Text & "\" & Me.txtRegistrySubKey.Text.Trim("\"c) & "\" & Me.txtRegistryValue.Text.Trim("\"c)
				If Me.chkRegistry32bit.Checked Then Me._readableRule += "   Reg32:True"
				Me._readableRule += "   Path:" & Me.txtFilePath.Text.Trim("\"c)
				If Not String.IsNullOrEmpty(Me.txtVersion.Text) Then Me._readableRule += "   Version: " & Me.txtVersion.Text
				
				'Set the xmlrule.
				_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
					"Subkey=""" & Me.txtRegistrySubKey.Text.Trim("\"c) & """ " & _
					"Value=""" & Me.txtRegistryValue.Text.Trim("\"c) & """ "
				If Me.chkRegistry32bit.Checked Then _xmlRule += "RegType32=""true"" "
				_xmlRule += "Path=""" & Me.txtFilePath.Text.Trim("\"c) & """ "
				If Not String.IsNullOrEmpty(Me.txtVersion.Text) Then _xmlRule += "Version=""" & Me.txtVersion.Text & """ "
				_xmlRule += " />"
			Case RuleTypes.FileCreation
				'Set the readble rule.
				Me._readableRule += Me.txtFilePath.Text.Trim("\"c)
				If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) Then Me._readableRule += "   CSID: " & Me.cboEnvironmentVariable.Text
				Me._readableRule += "   Comparison:" & Me.cboComparison.Text & _
					"   Created:" & Me.dtpDate.Value.ToLongDateString
				
				'Set the xmlrule.
				_xmlRule += "Path=""" & Me.txtFilePath.Text.Trim("\"c) & """ "
				If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) Then _xmlRule += "Csidl=""" & GetCSIDCode(Me.cboEnvironmentVariable.Text) & """ "
				_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
					"Created=""" & Format(Me.dtpDate.Value.ToUniversalTime,"yyyy-MM-dd'T'HH:mm:ss") & """ "
				_xmlRule += " />"
			Case RuleTypes.FileCreationWithRegistry
				'Set the readble rule.
				Me._readableRule += Me.cboRegistryKey.Text & "\" & Me.txtRegistrySubKey.Text.Trim("\"c) & "\" & Me.txtRegistryValue.Text.Trim("\"c)
				If Me.chkRegistry32Bit.Checked Then Me._readableRule += "   Reg32:True"
				Me._readableRule += "   Path:" & Me.txtFilePath.Text.Trim("\"c)
				Me._readableRule += "   Comparison:" & Me.cboComparison.Text & _
					"   Created:" & Me.dtpDate.Value.ToLongDateString
				
				'Set the xmlrule.
				_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
					"Subkey=""" & Me.txtRegistrySubKey.Text.Trim("\"c) & """ " & _
					"Value=""" & Me.txtRegistryValue.Text.Trim("\"c) & """ "
				If Me.chkRegistry32Bit.Checked Then _xmlRule += "RegType32=""true"" "
				_xmlRule += "Path=""" & Me.txtFilePath.Text.Trim("\"c) & """ "
				_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
					"Created=""" & Format(Me.dtpDate.Value.ToUniversalTime,"yyyy-MM-dd'T'HH:mm:ss") & """ "
				_xmlRule += " />"
			Case RuleTypes.FileModified
				'Set the readble rule
				Me._readableRule += Me.txtFilePath.Text.Trim("\"c)
				If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) Then Me._readableRule += "   CSID: " & Me.cboEnvironmentVariable.Text
				Me._readableRule += "   Comparison:" & Me.cboComparison.Text & _
					"   Created:" & Me.dtpDate.Value.ToLongDateString
				
				'Set the xmlrule.
				_xmlRule += "Path=""" & Me.txtFilePath.Text.Trim("\"c) & """ "
				If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) Then _xmlRule += "Csidl=""" & GetCSIDCode(Me.cboEnvironmentVariable.Text) & """ "
				_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
					"Modified=""" & Format(Me.dtpDate.Value.ToUniversalTime,"yyyy-MM-dd'T'HH:mm:ss") & """ "
				_xmlRule += " />"
			Case RuleTypes.FileModifiedWithRegistry
				'Set the readble rule.
				Me._readableRule += Me.cboRegistryKey.Text & "\" & Me.txtRegistrySubKey.Text.Trim("\"c) & "\" & Me.txtRegistryValue.Text.Trim("\"c)
				If Me.chkRegistry32Bit.Checked Then Me._readableRule += "   Reg32:True"
				Me._readableRule += "   Path:" & Me.txtFilePath.Text.Trim("\"c)
				Me._readableRule += "   Comparison:" & Me.cboComparison.Text & _
					"   Modified:" & Me.dtpDate.Value.ToLongDateString
				
				'Set the xmlrule.
				_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
					"Subkey=""" & Me.txtRegistrySubKey.Text.Trim("\"c) & """ " & _
					"Value=""" & Me.txtRegistryValue.Text.Trim("\"c) & """ "
				If Me.chkRegistry32Bit.Checked Then _xmlRule += "RegType32=""true"" "
				_xmlRule += "Path=""" & Me.txtFilePath.Text.Trim("\"c) & """ "
				_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
					"Modified=""" & Format(Me.dtpDate.Value.ToUniversalTime,"yyyy-MM-dd'T'HH:mm:ss") & """ "
				_xmlRule += " />"
			Case RuleTypes.FileSize
				'Set the readable rule.
				Me._readableRule += Me.txtFilePath.Text.Trim("\"c)
				If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) Then Me._readableRule += "   CSID: " & Me.cboEnvironmentVariable.Text
				Me._readableRule += "   Comparison:" & Me.cboComparison.Text & _
					"   Size: " & Me.txtData.Text
				
				'Set the xmlrule.
				_xmlRule += "Path=""" & Me.txtFilePath.Text.Trim("\"c) & """ "
				If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) Then _xmlRule += "Csidl=""" & GetCSIDCode(Me.cboEnvironmentVariable.Text) & """ "
				_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
					"Size=""" & Me.txtData.Text & """ "
				_xmlRule += " />"
			Case RuleTypes.FileSizeWithRegistry
				'Set the readable rule.
				Me._readableRule += Me.cboRegistryKey.Text & "\" & Me.txtRegistrySubKey.Text.Trim("\"c) & "\" & Me.txtRegistryValue.Text.Trim("\"c)
				If Me.chkRegistry32Bit.Checked Then Me._readableRule += "   Reg32:True"
				Me._readableRule += "   Path:" & Me.txtFilePath.Text.Trim("\"c)
				Me._readableRule += "   Comparison:" & Me.cboComparison.Text & _
					"   Size: " & Me.txtData.Text
				
				'Set the xmlrule.
				_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
					"Subkey=""" & Me.txtRegistrySubKey.Text.Trim("\"c) & """ " & _
					"Value=""" & Me.txtRegistryValue.Text.Trim("\"c) & """ "
				If Me.chkRegistry32Bit.Checked Then _xmlRule += "RegType32=""true"" "
				_xmlRule += "Path=""" & Me.txtFilePath.Text.Trim("\"c) & """ "
				_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
					"Size=""" & Me.txtData.Text & """ "
				_xmlRule += " />"
			Case RuleTypes.FileVersion
				'Set the readable rule.
				Me._readableRule += Me.txtFilePath.Text.Trim("\"c)
				If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) Then Me._readableRule += "   CSID: " & Me.cboEnvironmentVariable.Text
				Me._readableRule += "   Comparison:" & Me.cboComparison.Text
				If Not String.IsNullOrEmpty(Me.txtVersion.Text) Then Me._readableRule += "   Version: " & Me.txtVersion.Text
				
				'Set the xmlrule.
				_xmlRule += "Path=""" & Me.txtFilePath.Text.Trim("\"c) & """ "
				If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) Then _xmlRule += "Csidl=""" & GetCSIDCode(Me.cboEnvironmentVariable.Text) & """ "
				_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ "
				If Not String.IsNullOrEmpty(Me.txtVersion.Text) Then _xmlRule += "Version=""" & Me.txtVersion.Text & """ "
				_xmlRule += " />"
			Case RuleTypes.FileVersionWithRegistry
				'Set the readable rule.
				Me._readableRule += Me.cboRegistryKey.Text & "\" & Me.txtRegistrySubKey.Text.Trim("\"c) & "\" & Me.txtRegistryValue.Text.Trim("\"c) & _
					"   Path:" & Me.txtFilePath.Text.Trim("\"c) & _
					"   Comparison:" & Me.cboComparison.Text & _
					"   Version:" & Me.txtVersion.Text
				If Me.chkRegistry32Bit.Checked Then Me._readableRule += "   Reg32:True"
				
				'Set the xmlrule.
				_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
					"Subkey=""" & Me.txtRegistrySubKey.Text.Trim("\"c) & """ " & _
					"Value=""" & Me.txtRegistryValue.Text.Trim("\"c) & """ "
				If Me.chkRegistry32Bit.Checked Then _xmlRule += "RegType32=""true"" "
				_xmlRule += "Path=""" & Me.txtFilePath.Text.Trim("\"c) & """ " & _
					"Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
					"Version=""" & Me.txtVersion.Text & """ "
				_xmlRule += " />"
			Case RuleTypes.RegistryKeyExists
				'Set the readable rule.
				Me._readableRule += Me.cboRegistryKey.Text & "\" & _
					Me.txtRegistrySubKey.Text.Trim("\"c)
				If Me.chkRegistry32Bit.Checked Then Me._readableRule += "   Reg32:True"
				
				'Set the xmlrule.
				_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
					"Subkey=""" & Me.txtRegistrySubKey.Text.Trim("\"c) & """ "
				If Me.chkRegistry32Bit.Checked Then _xmlRule += "RegType32=""true"" "
				_xmlRule += " />"
			Case RuleTypes.RegistryValueExists
				'Set the readable rule.
				Me._readableRule += Me.cboRegistryKey.Text & "\" & Me.txtRegistrySubKey.Text.Trim("\"c) & _
					"   Value:" & Me.txtRegistryValue.Text & _
					"   ValueType:" & Me.cboRegistryValueType.Text
				If Me.chkRegistry32Bit.Checked Then Me._readableRule += "   Reg32:True"
				
				'Set the xmlrule.
				_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
					"Subkey=""" & Me.txtRegistrySubKey.Text.Trim("\"c) & """ "
				If Not String.IsNullOrEmpty(Me.txtRegistryValue.Text) Then _xmlRule += "Value=""" & Me.txtRegistryValue.Text & """ "
				If Me.chkRegistry32Bit.Checked Then _xmlRule += "RegType32=""true"" "
				_xmlRule += "Type=""" & Me.cboRegistryValueType.Text & """ "
				_xmlRule += " />"
			Case RuleTypes.RegistryDWORDValue
				'Set the readable rule.
				Me._readableRule += Me.cboRegistryKey.Text & "\" & Me.txtRegistrySubKey.Text.Trim("\"c) & "\" & Me.txtRegistryValue.Text.Trim("\"c) & _
					"   Comparison:" & Me.cboComparison.Text & _
					"   Data:" & Me.txtData.Text
				If Me.chkRegistry32Bit.Checked Then Me._readableRule += "   Reg32:True"
				
				'Set the xmlrule.
				_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
					"Subkey=""" & Me.txtRegistrySubKey.Text.Trim("\"c) & """ " & _
					"Value=""" & Me.txtRegistryValue.Text.Trim("\"c) & """ "
				If Me.chkRegistry32Bit.Checked Then _xmlRule += "RegType32=""true"" "
				_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
					"Data=""" & Me.txtData.Text & """ "
				_xmlRule += " />"
			Case RuleTypes.RegistryExpandSzValue
				'Set the readable rule.
				Me._readableRule += Me.cboRegistryKey.Text & "\" & Me.txtRegistrySubKey.Text.Trim("\"c) & "\" & Me.txtRegistryValue.Text.Trim("\"c) & _
					"   Comparison:" & Me.cboComparison.Text & _
					"   String:" & Me.txtData.Text
				If Me.chkRegistry32Bit.Checked Then Me._readableRule += "   Reg32:True"
				
				'Set the xmlrule.
				_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
					"Subkey=""" & Me.txtRegistrySubKey.Text.Trim("\"c) & """ " & _
					"Value=""" & Me.txtRegistryValue.Text.Trim("\"c) & """ "
				If Me.chkRegistry32Bit.Checked Then _xmlRule += "RegType32=""true"" "
				_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
					"Data=""" & Me.txtData.Text & """ "
				_xmlRule += " />"
			Case RuleTypes.RegistryVersionInSz
				'Set the readable rule.
				Me._readableRule += Me.cboRegistryKey.Text & "\" & Me.txtRegistrySubKey.Text.Trim("\"c) & "\" & Me.txtRegistryValue.Text.Trim("\"c) & _
					"   Comparison:" & Me.cboComparison.Text & _
					"   String:" & Me.txtVersion.Text
				If Me.chkRegistry32Bit.Checked Then Me._readableRule += "   Reg32:True"
				
				'Set the xmlrule.
				_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
					"Subkey=""" & Me.txtRegistrySubKey.Text.Trim("\"c) & """ " & _
					"Value=""" & Me.txtRegistryValue.Text.Trim("\"c) & """ "
				If Me.chkRegistry32Bit.Checked Then _xmlRule += "RegType32=""true"" "
				_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
					"Data=""" & Me.txtVersion.Text & """ "
				_xmlRule += " />"
			Case RuleTypes.RegistrySzValue
				'Set the readable rule.
				Me._readableRule += Me.cboRegistryKey.Text & "\" & Me.txtRegistrySubKey.Text.Trim("\"c) & "\" & Me.txtRegistryValue.Text.Trim("\"c) & _
					"   Comparison:" & Me.cboComparison.Text & _
					"   String:" & Me.txtData.Text
				If Me.chkRegistry32Bit.Checked Then Me._readableRule += "   Reg32:True"
				
				'Set the xmlrule.
				_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
					"Subkey=""" & Me.txtRegistrySubKey.Text.Trim("\"c) & """ " & _
					"Value=""" & Me.txtRegistryValue.Text.Trim("\"c) & """ "
				If Me.chkRegistry32Bit.Checked Then _xmlRule += "RegType32=""true"" "
				_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
					"Data=""" & Me.txtData.Text & """ "
				_xmlRule += " />"
			Case RuleTypes.WMIQuery
				'Set the readable rule.
				If Not String.IsNullOrEmpty(Me.txtData.Text) Then Me._readableRule += "   NameSpace:" & Me.txtData.Text
				Me._readableRule += Me.txtQuery.Text
				
				'Set the xmlrule.
				If Not String.IsNullOrEmpty(Me.txtData.Text) Then _xmlRule += "Namespace=""" & Me.txtData.Text & """ "
				_xmlRule += "WqlQuery=""" & Me.txtQuery.Text & """ "
				_xmlRule += " />"
				
			Case RuleTypes.MsiProductInstalled
				
				_readableRule += New Guid(txtProductCode.Text).ToString("B") & "  "
				If Not String.IsNullOrEmpty(txtMaxVersion.Text) Then _readableRule += "  VersionMax = " & txtMaxVersion.Text
				If Not String.IsNullOrEmpty(txtMinVersion.Text) Then _readableRule += "  VersionMin = " & txtMinVersion.Text
				If Not String.IsNullOrEmpty(GetLanguageCode(cboLanguage.Text)) Then _readableRule += "  Language = " & cboLanguage.Text
				
				_xmlRule += "ProductCode=""" & (New Guid(txtProductCode.Text).ToString("B")) & """"
				If Not String.IsNullOrEmpty(txtMaxVersion.Text) Then _xmlRule += " VersionMax=""" & txtMaxVersion.Text & """"
				If Not String.IsNullOrEmpty(txtMinVersion.Text) Then _xmlRule += " VersionMin=""" & txtMinVersion.Text & """"
				If Not String.IsNullOrEmpty(GetLanguageCode(cboLanguage.Text)) Then _xmlRule += " Language=""" & GetMsiLanguageCode(GetLanguageCode(cboLanguage.Text)) & """"
				_xmlRule+= " />"
			Case RuleTypes.MsiPatchInstalled
				
				_readableRule += " PatchCode = " & (New Guid(txtPatchCode.Text).ToString("B")) & "  " & " for ProductCode = " & (New Guid(txtProductCode.Text).ToString("B")) & "  "
				If Not String.IsNullOrEmpty(txtMaxVersion.Text) Then _readableRule += " VersionMax = " & txtMaxVersion.Text
				If Not String.IsNullOrEmpty(txtMinVersion.Text) Then _readableRule += " VersionMin = " & txtMinVersion.Text
				If Not String.IsNullOrEmpty(GetLanguageCode(cboLanguage.Text)) Then _readableRule += " Language = " & cboLanguage.Text
				
				_xmlRule += "PatchCode=""" & (New Guid(txtPatchCode.Text).ToString("B")) & """" & " ProductCode=""" & (New Guid(txtProductCode.Text).ToString("B")) & """"
				If Not String.IsNullOrEmpty(txtMaxVersion.Text) Then _xmlRule += " VersionMax=""" & txtMaxVersion.Text & """"
				If Not String.IsNullOrEmpty(txtMinVersion.Text) Then _xmlRule += " VersionMin=""" & txtMinVersion.Text & """"
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
				
				_readableRule += "Components: "
				If chkComponentCollection_requireAll.Checked Then _readableRule += " (all required)" & "  "
				
				'Add the component Guids.
				For Each tmpGuid As Guid In gceComponentCollection.ItemGuids
					_readableRule += tmpGuid.ToString("B") & "  "
					_xmlRule += "<msiar:Component>" & tmpGuid.ToString("B") & "</msiar:Component>"
				Next
				
				_readableRule += "Products: "
				If chkProductCollection_requireAll.Checked Then _readableRule += " (all required)" & "  "
				
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
				
				_readableRule += "Features: "
				If chkFeatureCollection_requireAll.Checked Then _readableRule += " (all required)" & "  "
				
				'Add the feature names.
				For Each tmpFeature As String In gceFeatureCollection.Items
					_readableRule += tmpFeature & "  "
					_xmlRule += "<msiar:Feature>" & tmpFeature & "</msiar:Feature>"
				Next
				
				_readableRule += "Products: "
				If chkProductCollection_requireAll.Checked Then _readableRule += " (all required)" & "  "
				
				'Add the product Guids.
				For Each tmpGuid As Guid In gceProductCollection.ItemGuids
					_readableRule += tmpGuid.ToString("B") & "  "
					_xmlRule += "<msiar:Product>" & tmpGuid.ToString("B") & "</msiar:Product>"
				Next
				
				_xmlRule += "</" & RuleTypes.MsiFeatureInstalled.ToXmlTag() & ">"
			Case Else
				Msgbox("This Rule Type Isn't Supported Yet")
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
		LoadRule(ruleXml)
		Call GenerateRule
		Return Me._readableRule
	End Function
	
	'Loads the rule based on the XML string.
	Sub LoadRule(ruleXml As String)
		
		'Create the namespace and add the lar and bar namespaces.
		Dim nsmgr as XmlNamespaceManager = new XmlNamespaceManager(new NameTable())
		nsmgr.AddNamespace("lar", "http://schemas.microsoft.com/wsus/2005/04/CorporatePublishing/LogicalApplicabilityRules.xsd")
		nsmgr.AddNamespace("bar", "http://schemas.microsoft.com/wsus/2005/04/CorporatePublishing/BaseApplicabilityRules.xsd")
		nsmgr.AddNamespace("msiar", "http://schemas.microsoft.com/wsus/2005/04/CorporatePublishing/MsiApplicabilityRules.xsd")
		
		'Create the XmlParserContext.
		Dim context as XmlParserContext = new XmlParserContext(nothing, nsmgr, nothing, XmlSpace.Default)
		
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
				'Load the data.
				Me.cboComparison.Text = GetComparisonText(xmlReader.GetAttribute("Comparison"))
				Me.txtOSMajorVersion.Text = xmlReader.GetAttribute("MajorVersion")
				Me.txtOSMinorVersion.Text = xmlReader.GetAttribute("MinorVersion")
				Me.cboOSVersion.Text = GetOSVersionText
				Me.txtData.Text = xmlReader.GetAttribute("BuildNumber")
				Me.txtSPMajorVersion.Text = xmlReader.GetAttribute("ServicePackMajor")
				Me.txtSPMinorVersion.Text = xmlReader.GetAttribute("ServicePackMinor")
				Me.cboServicePack.Text = GetServicePackText
				Me.cboProductType.Text = GetProductTypeText(CInt(xmlReader.GetAttribute("ProductType")))
				
				'Select the rule type.
				Me.cboRuleType.SelectedIndex = RuleTypes.WindowsVersion
			Case "WindowsLanguage"
				'Load the data.
				Me.cboLanguage.Text = GetLanguageText(xmlReader.GetAttribute("Language"))
				
				'Select the rule type.
				Me.cboRuleType.SelectedIndex = RuleTypes.WindowsLanguage
			Case "Processor"
				'Load the data.
				Me.cboProcessorType.Text = GetProcessorTypeText(xmlReader.GetAttribute("Architecture"))
				
				'Select the rule.
				Me.cboRuleType.SelectedIndex = RuleTypes.ProcessorArchitecture
			Case "FileExists"
				'Load the data.
				Me.txtFilePath.Text = xmlReader.GetAttribute("Path")
				Me.cboEnvironmentVariable.Text = GetCsidCodeText(xmlReader.GetAttribute("Csidl"))
				Me.txtVersion.Text = xmlReader.GetAttribute("Version")
				
				'Select the rule.
				Me.cboRuleType.SelectedIndex = RuleTypes.FileExists
			Case "FileExistsPrependRegSz"
				'Load the data.
				Me.cboRegistryKey.Text = xmlReader.GetAttribute("Key")
				Me.txtRegistrySubKey.Text = xmlReader.GetAttribute("Subkey")
				Me.txtRegistryValue.Text = xmlReader.GetAttribute("Value")
				If xmlReader.GetAttribute("RegType32") = "true" Then Me.chkRegistry32Bit.Checked = True
				Me.txtFilePath.Text = xmlReader.GetAttribute("Path")
				Me.txtVersion.Text = xmlReader.GetAttribute("Version")
				
				'Select the rule.
				Me.cboRuleType.SelectedIndex = RuleTypes.FileExistsWithRegistry
			Case "FileCreated"
				'Load the data.
				Me.txtFilePath.Text = xmlReader.GetAttribute("Path")
				Me.cboEnvironmentVariable.Text = GetCsidCodeText(xmlReader.GetAttribute("Csidl"))
				Me.cboComparison.Text = GetComparisonText(xmlReader.GetAttribute("Comparison"))
				Me.dtpDate.Text = xmlReader.GetAttribute("Created")
				
				'Select the Rule.
				Me.cboRuleType.SelectedIndex = RuleTypes.FileCreation
			Case "FileCreatedPrependRegSz"
				'Load the data.
				Me.cboRegistryKey.Text = xmlReader.GetAttribute("Key")
				Me.txtRegistrySubKey.Text = xmlReader.GetAttribute("Subkey")
				Me.txtRegistryValue.Text = xmlReader.GetAttribute("Value")
				If xmlReader.GetAttribute("RegType32") = "true" Then Me.chkRegistry32Bit.Checked = True
				Me.txtFilePath.Text = xmlReader.GetAttribute("Path")
				Me.cboComparison.Text = GetComparisonText(xmlReader.GetAttribute("Comparison"))
				Me.dtpDate.Text = xmlReader.GetAttribute("Created")
				'Select the rule.
				Me.cboRuleType.SelectedIndex = RuleTypes.FileCreationWithRegistry
			Case "FileModified"
				'Load the data.
				Me.txtFilePath.Text = xmlReader.GetAttribute("Path")
				Me.cboEnvironmentVariable.Text = GetCsidCodeText(xmlReader.GetAttribute("Csidl"))
				Me.cboComparison.Text = GetComparisonText(xmlReader.GetAttribute("Comparison"))
				Me.dtpDate.Text = xmlReader.GetAttribute("Modified")
				
				'Select the Rule.
				Me.cboRuleType.SelectedIndex = RuleTypes.FileModified
			Case "FileModifiedPrependRegSz"
				'Load the data.
				Me.cboRegistryKey.Text = xmlReader.GetAttribute("Key")
				Me.txtRegistrySubKey.Text = xmlReader.GetAttribute("Subkey")
				Me.txtRegistryValue.Text = xmlReader.GetAttribute("Value")
				If xmlReader.GetAttribute("RegType32") = "true" Then Me.chkRegistry32Bit.Checked = True
				Me.txtFilePath.Text = xmlReader.GetAttribute("Path")
				Me.cboComparison.Text = GetComparisonText(xmlReader.GetAttribute("Comparison"))
				Me.dtpDate.Text = xmlReader.GetAttribute("Modified")
				'Select the rule.
				Me.cboRuleType.SelectedIndex = RuleTypes.FileModifiedWithRegistry
			Case "FileSize"
				'Load the data.
				Me.txtFilePath.Text = xmlReader.GetAttribute("Path")
				Me.cboEnvironmentVariable.Text = GetCsidCodeText(xmlReader.GetAttribute("Csidl"))
				Me.cboComparison.Text = GetComparisonText(xmlReader.GetAttribute("Comparison"))
				Me.txtData.Text = xmlReader.GetAttribute("Size")
				
				'Select the rule.
				Me.cboRuleType.SelectedIndex = RuleTypes.FileSize
			Case "FileSizePrependRegSz"
				'Load the data
				Me.cboRegistryKey.Text = xmlReader.GetAttribute("Key")
				Me.txtRegistrySubKey.Text = xmlReader.GetAttribute("Subkey")
				Me.txtRegistryValue.Text = xmlReader.GetAttribute("Value")
				If xmlReader.GetAttribute("RegType32") = "true" Then Me.chkRegistry32Bit.Checked = True
				Me.txtFilePath.Text = xmlReader.GetAttribute("Path")
				Me.cboComparison.Text = GetComparisonText(xmlReader.GetAttribute("Comparison"))
				Me.txtData.Text = xmlReader.GetAttribute("Size")
				
				'Select the rule.
				Me.cboRuleType.SelectedIndex = RuleTypes.FileSizeWithRegistry
			Case "FileVersion"
				'Load the data
				Me.txtFilePath.Text = xmlReader.GetAttribute("Path")
				Me.cboEnvironmentVariable.Text = GetCsidCodeText(xmlReader.GetAttribute("Csidl"))
				Me.cboComparison.Text = GetComparisonText(xmlReader.GetAttribute("Comparison"))
				Me.txtVersion.Text = xmlReader.GetAttribute("Version")
				
				'Select the rule.
				Me.cboRuleType.SelectedIndex = RuleTypes.FileVersion
			Case "FileVersionPrependRegSz"
				'Load the data
				Me.cboRegistryKey.Text = xmlReader.GetAttribute("Key")
				Me.txtRegistrySubKey.Text = xmlReader.GetAttribute("Subkey")
				Me.txtRegistryValue.Text = xmlReader.GetAttribute("Value")
				If xmlReader.GetAttribute("RegType32") = "true" Then Me.chkRegistry32Bit.Checked = True
				Me.txtFilePath.Text = xmlReader.GetAttribute("Path")
				Me.cboComparison.Text = GetComparisonText(xmlReader.GetAttribute("Comparison"))
				Me.txtVersion.Text = xmlReader.GetAttribute("Version")
				
				'Select the rule.
				Me.cboRuleType.SelectedIndex = RuleTypes.FileVersionWithRegistry
			Case "RegKeyExists"
				'Load the data.
				Me.cboRegistryKey.Text = xmlReader.GetAttribute("Key")
				Me.txtRegistrySubKey.Text = xmlReader.GetAttribute("Subkey")
				If xmlReader.GetAttribute("RegType32") = "true" Then Me.chkRegistry32Bit.Checked = True
				
				'Select the rule.
				Me.cboRuleType.SelectedIndex = RuleTypes.RegistryKeyExists
			Case "RegValueExists"
				'Load the data.
				Me.cboRegistryKey.Text = xmlReader.GetAttribute("Key")
				Me.txtRegistrySubKey.Text = xmlReader.GetAttribute("Subkey")
				Me.txtRegistryValue.Text = xmlReader.GetAttribute("Value")
				If xmlReader.GetAttribute("RegType32") = "true" Then Me.chkRegistry32Bit.Checked = True
				Me.cboRegistryValueType.Text = xmlReader.GetAttribute("Type")
				
				'Select the rule.
				Me.cboRuleType.SelectedIndex = RuleTypes.RegistryValueExists
			Case "RegDword"
				'Load the data.
				Me.cboRegistryKey.Text = xmlReader.GetAttribute("Key")
				Me.txtRegistrySubKey.Text = xmlReader.GetAttribute("Subkey")
				Me.txtRegistryValue.Text = xmlReader.GetAttribute("Value")
				If xmlReader.GetAttribute("RegType32") = "true" Then Me.chkRegistry32Bit.Checked = True
				Me.cboComparison.Text = GetComparisonText(xmlReader.GetAttribute("Comparison"))
				Me.txtData.Text = xmlReader.GetAttribute("Data")
				
				'Select the rule.
				Me.cboRuleType.SelectedIndex = RuleTypes.RegistryDWORDValue
			Case "RegExpandSz"
				'Load the data.
				Me.cboRegistryKey.Text = xmlReader.GetAttribute("Key")
				Me.txtRegistrySubKey.Text = xmlReader.GetAttribute("Subkey")
				Me.txtRegistryValue.Text = xmlReader.GetAttribute("Value")
				If xmlReader.GetAttribute("RegType32") = "true" Then Me.chkRegistry32Bit.Checked = True
				Me.cboComparison.Text = GetComparisonText(xmlReader.GetAttribute("Comparison"))
				Me.txtData.Text = xmlReader.GetAttribute("Data")
				
				'Select the rule.
				Me.cboRuleType.SelectedIndex = RuleTypes.RegistryExpandSzValue
			Case "RegSzToVersion"
				'Load the data
				Me.cboRegistryKey.Text = xmlReader.GetAttribute("Key")
				Me.txtRegistrySubKey.Text = xmlReader.GetAttribute("Subkey")
				Me.txtRegistryValue.Text = xmlReader.GetAttribute("Value")
				If xmlReader.GetAttribute("RegType32") = "true" Then Me.chkRegistry32Bit.Checked = True
				Me.cboComparison.Text = GetComparisonText(xmlReader.GetAttribute("Comparison"))
				Me.txtData.Text = xmlReader.GetAttribute("Data")
				
				'Select the rule.
				Me.cboRuleType.SelectedIndex = RuleTypes.RegistryVersionInSz
			Case "RegSz"
				'Load the data
				Me.cboRegistryKey.Text = xmlReader.GetAttribute("Key")
				Me.txtRegistrySubKey.Text = xmlReader.GetAttribute("Subkey")
				Me.txtRegistryValue.Text = xmlReader.GetAttribute("Value")
				If xmlReader.GetAttribute("RegType32") = "true" Then Me.chkRegistry32Bit.Checked = True
				Me.cboComparison.Text = GetComparisonText(xmlReader.GetAttribute("Comparison"))
				Me.txtData.Text = xmlReader.GetAttribute("Data")
				
				'Select the rule.
				Me.cboRuleType.SelectedIndex = RuleTypes.RegistrySzValue
			Case "WmiQuery"
				'Load the Data.
				Me.txtData.Text = xmlReader.GetAttribute("Namespace")
				Me.txtQuery.Text = xmlReader.GetAttribute("WqlQuery")
				
				'Select the rule.
				Me.cboRuleType.SelectedIndex = RuleTypes.WMIQuery
			Case "MsiPatchInstalledForProduct"
				
				Me.txtProductCode.Text = xmlReader.GetAttribute("ProductCode")
				Me.txtPatchCode.Text = xmlReader.GetAttribute("PatchCode")
				Me.txtMaxVersion.Text = xmlReader.GetAttribute("VersionMax")
				Me.txtMinVersion.Text = xmlReader.GetAttribute("VersionMin")
				Me.cboLanguage.Text = GetLanguageText(GetISOForMsiLanguage(Cint(xmlReader.GetAttribute("Language"))))
				
				Me.cboRuleType.SelectedItem = RuleTypes.MsiPatchInstalled
				Exit Select
				
			Case "MsiProductInstalled"
				
				Me.txtProductCode.Text = xmlReader.GetAttribute("ProductCode")
				Me.txtMaxVersion.Text = xmlReader.GetAttribute("VersionMax")
				Me.txtMinVersion.Text = xmlReader.GetAttribute("VersionMin")
				Me.cboLanguage.Text = GetLanguageText(GetISOForMsiLanguage(Cint(xmlReader.GetAttribute("Language"))))
				
				Me.cboRuleType.SelectedItem = RuleTypes.MsiProductInstalled
				Exit Select
				
			Case "MsiComponentInstalledForProduct"
				If True Then
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
					
					Me.cboRuleType.SelectedItem = RuleTypes.MsiComponentInstalled
				End If
				Exit Select
				
			Case "MsiFeatureInstalledForProduct"
				If True Then
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
					
					Me.cboRuleType.SelectedItem = RuleTypes.MsiFeatureInstalled
				End If
				Exit Select
			Case Else
				Msgbox ("This rule is not recognized: " & xmlreader.LocalName.Replace("bar:",""))
		End Select
		xmlReader.Close
	End Sub
	
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
	' this routine makes sure that the text is formated that way.
	Private Sub ValidateVersion(sender As Object, e As EventArgs)
		'If this is a textbox then format it as a version string
		If TypeOf Sender Is TextBox Then
			
			'If there's a string, and it's less than 4 digits then pad with zeros
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
	
	Private Sub VerifyForm(sender As Object, e As EventArgs)
		VerifyForm()
	End Sub
	
	'Verify the form and set the icons accordinly.
	Sub VerifyForm
		Call SetVerificationIcons
		Call VerifyRule
	End Sub
	
	'Update verification icons.
	Sub SetVerificationIcons
		'Set the picture boxes icons and tags.
		If Me.cboComparison.SelectedIndex = -1 Then
			Me.picComparison.Image = My.Resources.attention.ToBitmap
			Me.picComparison.Tag = False
		Else
			Me.picComparison.Image = My.Resources.check.ToBitmap
			Me.picComparison.Tag = True
		End If
		
		If String.IsNullOrEmpty(Me.txtOSMajorVersion.Text) Or String.IsNullOrEmpty(Me.txtOSMinorVersion.Text) Then
			Me.picOSVersion.Image = My.Resources.attention.ToBitmap
			Me.picOSVersion.Tag = False
		Else
			Me.picOSVersion.Image = My.Resources.check.ToBitmap
			Me.picOSVersion.Tag = True
		End If
		
		'The language selection is only validated when the rule type is Windows Language
		If Me.cboRuleType.SelectedIndex = RuleTypes.WindowsLanguage Then
			Me.picLanguage.Show
			
			'Validate the value.
			If Me.cboLanguage.SelectedIndex = -1 Then
				Me.picLanguage.Image = My.Resources.attention.ToBitmap
				Me.picLanguage.Tag = False
			Else
				Me.picLanguage.Image = My.Resources.check.ToBitmap
				Me.picLanguage.Tag = True
			End If
		Else
			Me.picLanguage.Hide
		End If
		
		
		
		If Me.cboProcessorType.SelectedIndex = -1 Then
			Me.picProcessorType.Image = My.Resources.attention.ToBitmap
			Me.picProcessorType.Tag = False
		Else
			Me.picProcessorType.Image = My.Resources.check.ToBitmap
			Me.picProcessorType.Tag = True
		End If
		
		If String.IsNullOrEmpty(Me.txtRegistrySubKey.Text) Then
			Me.picRegistryKey.Image = My.Resources.attention.ToBitmap
			Me.picRegistryKey.Tag = False
		Else
			Me.picRegistryKey.Image = My.Resources.check.ToBitmap
			Me.picRegistryKey.Tag = True
		End If
		
		'The registry value key is only validated when the rule type is Registry Value Exists
		' and the Registry Value Type isn't REG_SZ.  So only show it in that case.
		If Me.cboRuleType.SelectedIndex = RuleTypes.RegistryValueExists And _
			Not Me.cboRegistryValueType.Text = "REG_SZ" And _
			Not Me.cboRegistryValueType.SelectedIndex = -1 Then
			Me.picRegistryValue.Show()
			
			'Validate the value.
			If String.IsNullOrEmpty(Me.txtRegistryValue.Text) Then
				Me.picRegistryValue.Image = My.Resources.attention.ToBitmap
				Me.picRegistryValue.Tag = False
			Else
				Me.picRegistryValue.Image = My.Resources.check.ToBitmap
				Me.picRegistryValue.Tag = True
			End If
		Else
			Me.picRegistryValue.Hide()
		End If
		
		If Me.cboRegistryValueType.SelectedIndex = -1 Then
			Me.picRegistryValueType.Image = My.Resources.attention.ToBitmap
			Me.picRegistryValueType.Tag = False
		Else
			Me.picRegistryValueType.Image = My.Resources.check.ToBitmap
			Me.picRegistryValueType.Tag = True
		End If
		
		If String.IsNullOrEmpty(Me.txtFilePath.Text) Then
			Me.picFilePath.Image = My.Resources.attention.ToBitmap
			Me.picFilePath.Tag = False
		Else
			Me.picFilePath.Image = My.Resources.check.ToBitmap
			Me.picFilePath.Tag = True
		End If
		
		If String.IsNullOrEmpty(Me.txtVersion.Text) Then
			Me.picVersion.Image = My.Resources.attention.ToBitmap
			Me.picVersion.Tag = False
		Else
			Me.picVersion.Image = My.Resources.check.ToBitmap
			Me.picVersion.Tag = True
		End If
		
		'TODO: for RegDWord and RegExpandSz rule, this must be numeric
		If String.IsNullOrEmpty(Me.txtData.Text) Then
			Me.picData.Image = My.Resources.attention.ToBitmap
			Me.picData.Tag = False
		Else
			Me.picData.Image = My.Resources.check.ToBitmap
			Me.picData.Tag = True
		End If
		
		If Not Me.dtpDate.Checked Then
			Me.picDate.Image = My.Resources.attention.ToBitmap
			Me.picDate.Tag = False
		Else
			Me.picDate.Image = My.Resources.check.ToBitmap
			Me.picDate.Tag = True
		End If
		
		If String.IsNullOrEmpty(Me.txtQuery.Text) Then
			Me.picQuery.Image = My.Resources.attention.ToBitmap
			Me.picQuery.Tag = False
		Else
			Me.picQuery.Image = My.Resources.check.ToBitmap
			Me.picQuery.Tag = True
		End If
		
		Try
			Dim g As New Guid(Me.txtProductCode.Text)
			Me.picProductCode.Image = My.Resources.check.ToBitmap
			Me.picProductCode.Tag = True
		Catch
			Me.picProductCode.Image = My.Resources.attention.ToBitmap
			Me.picProductCode.Tag = False
		End Try
		
		Try
			Dim g As New Guid(Me.txtPatchCode.Text)
			Me.picPatchCode.Image = My.Resources.check.ToBitmap
			Me.picPatchCode.Tag = True
		Catch
			Me.picPatchCode.Image = My.Resources.attention.ToBitmap
			Me.picPatchCode.Tag = False
		End Try
	End Sub
	
	'Enable or disable the Add Rule button based on current rule
	' and which fields are valid.  The verification looks to see if
	' the appropriate validation picture boxes have the proper boolean in their tag.
	Sub VerifyRule
		If Me.cboRuleType.SelectedIndex >= 0 Then 'Verify based on combobox selection.
			Select Case Me.cboRuleType.SelectedIndex
				Case RuleTypes.WindowsVersion
					If DirectCast(Me.picComparison.Tag, Boolean) And DirectCast(Me.picOSVersion.Tag,Boolean) Then
						Me.btnAdd.Enabled = True
					Else
						Me.btnAdd.Enabled = False
					End If
				Case RuleTypes.WindowsLanguage
					If DirectCast(Me.picLanguage.Tag, Boolean) Then
						Me.btnAdd.Enabled = True
					Else
						Me.btnAdd.Enabled = False
					End If
				Case RuleTypes.ProcessorArchitecture
					If DirectCast(Me.picProcessorType.Tag, Boolean) Then
						Me.btnAdd.Enabled = True
					Else
						Me.btnAdd.Enabled = False
					End If
				Case RuleTypes.FileExists
					If DirectCast(Me.picFilePath.Tag, Boolean) Then
						Me.btnAdd.Enabled = True
					Else
						Me.btnAdd.Enabled = False
					End If
				Case RuleTypes.FileExistsWithRegistry
					If DirectCast(Me.picRegistryKey.Tag, Boolean) and DirectCast(Me.picFilePath.Tag, Boolean) Then
						Me.btnAdd.Enabled = True
					Else
						Me.btnAdd.Enabled = False
					End If
				Case RuleTypes.FileCreation
					If DirectCast(Me.picFilePath.Tag, Boolean) and DirectCast(Me.picComparison.Tag, Boolean) and DirectCast(Me.picDate.Tag, Boolean) Then
						Me.btnAdd.Enabled = True
					Else
						Me.btnAdd.Enabled = False
					End If
				Case RuleTypes.FileCreationWithRegistry
					If DirectCast(Me.picRegistryKey.Tag, Boolean) And DirectCast(Me.picComparison.Tag, Boolean) and DirectCast(Me.picDate.Tag, Boolean) Then
						Me.btnAdd.Enabled = True
					Else
						Me.btnAdd.Enabled = False
					End If
				Case RuleTypes.FileModified
					If DirectCast(Me.picFilePath.Tag, Boolean) and DirectCast(Me.picComparison.Tag, Boolean) and DirectCast(Me.picDate.Tag, Boolean) Then
						Me.btnAdd.Enabled = True
					Else
						Me.btnAdd.Enabled = False
					End If
				Case RuleTypes.FileModifiedWithRegistry
					If DirectCast(Me.picRegistryKey.Tag, Boolean) And DirectCast(Me.picFilePath.Tag, Boolean) _
						and DirectCast(Me.picComparison.Tag, Boolean) and DirectCast(Me.picDate.Tag, Boolean) Then
						Me.btnAdd.Enabled = True
					Else
						Me.btnAdd.Enabled = False
					End If
				Case RuleTypes.FileSize
					If DirectCast(Me.picFilePath.Tag, Boolean) and DirectCast(Me.picComparison.Tag, Boolean) and DirectCast(Me.picData.Tag, Boolean) Then
						Me.btnAdd.Enabled = True
					Else
						Me.btnAdd.Enabled = False
					End If
				Case RuleTypes.FileSizeWithRegistry
					If DirectCast(Me.picRegistryKey.Tag, Boolean) And DirectCast(Me.picFilePath.Tag, Boolean) And _
						DirectCast(Me.picComparison.Tag, Boolean) and DirectCast(Me.picData.Tag, Boolean) Then
						Me.btnAdd.Enabled = True
					Else
						Me.btnAdd.Enabled = False
					End If
				Case RuleTypes.FileVersion
					If DirectCast(Me.picFilePath.Tag, Boolean) and DirectCast(Me.picComparison.Tag, Boolean) and DirectCast(Me.picVersion.Tag, Boolean) Then
						Me.btnAdd.Enabled = True
					Else
						Me.btnAdd.Enabled = False
					End If
				Case RuleTypes.FileVersionWithRegistry
					If DirectCast(Me.picRegistryKey.Tag, Boolean) And DirectCast(Me.picFilePath.Tag, Boolean) And _
						DirectCast(Me.picComparison.Tag, Boolean) and DirectCast(Me.picVersion.Tag, Boolean) Then
						Me.btnAdd.Enabled = True
					Else
						Me.btnAdd.Enabled = False
					End If
				Case RuleTypes.RegistryKeyExists
					If DirectCast(Me.picRegistryKey.Tag, Boolean) Then
						Me.btnAdd.Enabled = True
					Else
						Me.btnAdd.Enabled = False
					End If
				Case RuleTypes.RegistryValueExists
					If DirectCast(Me.picRegistryKey.Tag, Boolean) and DirectCast(Me.picRegistryValueType.Tag, Boolean) Then
						Me.btnAdd.Enabled = True
					Else
						Me.btnAdd.Enabled = False
					End If
				Case RuleTypes.RegistryDWORDValue
					If DirectCast(Me.picRegistryKey.Tag, Boolean) And DirectCast(Me.picComparison.Tag, Boolean) and DirectCast(Me.picData.Tag, Boolean) Then
						Me.btnAdd.Enabled = True
					Else
						Me.btnAdd.Enabled = False
					End If
				Case RuleTypes.RegistryExpandSzValue
					If DirectCast(Me.picRegistryKey.Tag, Boolean) And DirectCast(Me.picComparison.Tag, Boolean) and DirectCast(Me.picData.Tag, Boolean) Then
						Me.btnAdd.Enabled = True
					Else
						Me.btnAdd.Enabled = False
					End If
				Case RuleTypes.RegistryVersionInSz
					If DirectCast(Me.picRegistryKey.Tag, Boolean) And DirectCast(Me.picComparison.Tag, Boolean) and DirectCast(Me.picVersion.Tag, Boolean) Then
						Me.btnAdd.Enabled = True
					Else
						Me.btnAdd.Enabled = False
					End If
				Case RuleTypes.RegistrySzValue
					If DirectCast(Me.picRegistryKey.Tag, Boolean) And DirectCast(Me.picComparison.Tag, Boolean) and DirectCast(Me.picData.Tag, Boolean) Then
						Me.btnAdd.Enabled = True
					Else
						Me.btnAdd.Enabled = False
					End If
				Case RuleTypes.WMIQuery
					If DirectCast(Me.picData.Tag, Boolean) And DirectCast(Me.picQuery.Tag, Boolean) Then
						Me.btnAdd.Enabled = True
					Else
						Me.btnAdd.Enabled = False
					End If
				Case RuleTypes.MsiComponentInstalled
					btnAdd.Enabled = gceProductCollection.ValidInput AndAlso gceComponentCollection.ValidInput
				Case RuleTypes.MsiFeatureInstalled
					btnAdd.Enabled = gceProductCollection.ValidInput AndAlso gceFeatureCollection.ValidInput
				Case RuleTypes.MsiPatchInstalled
					btnAdd.Enabled = FieldsValid(New Control() {picProductCode, picPatchCode})
				Case RuleTypes.MsiProductInstalled
					btnAdd.Enabled = FieldsValid(New Control() {picProductCode})
			End Select
		End If 'Combobox has selection.
	End Sub
	
	
	' AND's the Tag fields of all passed controls
	' Receives controls who's Tag's indicate true = valid, false = invalid
	' Returns true if all controls have a boolean tag that is true
	Private Function FieldsValid(controls As Control()) As Boolean
		Dim total As Boolean = True
		For Each tmpControl As Control In controls
			If TypeOf tmpControl.Tag Is Boolean Then
				total = total AndAlso CBool(tmpControl.Tag)
			Else
				Return False
			End If
		Next
		Return total
	End Function
	#END Region
	
End Class
