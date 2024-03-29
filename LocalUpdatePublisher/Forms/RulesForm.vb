﻿Option Explicit On
Option Strict On
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

Partial Public Class RulesForm
    Private ReadOnly m_scalarComparison As String()
    Private ReadOnly m_stringComparison As String()
    Private ReadOnly m_productTypes As String()

#Region "Properties"
    Private m_readableRule As String
    ReadOnly Property ReadableRule() As String
        Get
            Return m_readableRule
        End Get
    End Property

    Private m_xmlRule As String
    ReadOnly Property XmlRule() As String
        Get
            Return m_xmlRule
        End Get
    End Property
#End Region

    Public Sub New()
        Call Me.New(Globals.globalRM.GetString("create_rule"))
    End Sub

    Public Sub New(title As String)
        'Set the ReadOnly string arrays for the comboboxes.
        ' Currently we use the first item to test if the array is already
        ' loaded into the combobox.
        m_scalarComparison = New String() {Globals.globalRM.GetString("equal_to"), Globals.globalRM.GetString("less_than"), Globals.globalRM.GetString("less_than_or_equal_to"), Globals.globalRM.GetString("greater_than"), Globals.globalRM.GetString("greater_than_or_equal_to")}
        m_stringComparison = New String() {Globals.globalRM.GetString("begins_with"), Globals.globalRM.GetString("ends_with"), Globals.globalRM.GetString("contains"), Globals.globalRM.GetString("equal_to")}
        m_productTypes = New String() {Globals.globalRM.GetString("none"), Globals.globalRM.GetString("workstation"), Globals.globalRM.GetString("domain_controller"), Globals.globalRM.GetString("server")}

        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        Me.InitializeComponent()
        Me.Text = title

        'Set comboboxes
        Me.cboProductType.Items.AddRange(m_productTypes)
        Me.cboLanguage.Items.AddRange(Languages.Names)

        'Set the Environment variable data source.
        Me.cboEnvironmentVariable.DataSource = GetSortedEnum(GetType(CSIDL))
        Me.cboEnvironmentVariable.SelectedIndex = -1

        'Load the Rule Types into the combo box based on the Enum.
        For Each tmpRuleType As String In [Enum].GetNames(GetType(RuleTypes))
            cboRuleType.Items.Add([Enum].Parse(GetType(RuleTypes), tmpRuleType))
        Next

        'Set localized strings.		
        Me.gceProductCollection.Header = Globals.globalRM.GetString("product_codes")
        Me.gceComponentCollection.Header = Globals.globalRM.GetString("component_codes")
        Me.gceFeatureCollection.Header = Globals.globalRM.GetString("feature_names")

        Call ValidateFields()
    End Sub

#Region "Events"

    ''' <summary>
    ''' If a rule is passed then load it.
    ''' </summary>
    ''' <param name="owner">IWin32Window</param>
    ''' <param name="ruleXml">String</param>
    ''' <returns>DialogResult</returns>
    Public Overloads Function ShowDialog(owner As IWin32Window, ruleXml As String) As DialogResult
        ClearForm()
        If String.IsNullOrEmpty(ruleXml) Then
            Me.btnAdd.Text = Globals.globalRM.GetString("add_rule")
        Else
            Me.btnAdd.Text = Globals.globalRM.GetString("save_rule")
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

    ''' <summary>
    ''' Clear the form of any existing data.
    ''' </summary>
    Sub ClearForm()
        Me.cboRuleType.SelectedIndex = -1
        Me.cboServicePack.SelectedIndex = -1
        Me.cboOSVersion.SelectedIndex = -1
        Me.cboComparison.SelectedIndex = -1
        Me.cboLanguage.SelectedIndex = -1
        Me.cboProcessorType.SelectedIndex = -1
        Me.cboEnvironmentVariable.SelectedIndex = -1
        Me.cboRegistryValueType.SelectedIndex = -1
        Me.cboRegistryKey.SelectedIndex = -1
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

    ''' <summary>
    ''' When the user chooses a rule type we need to rearrange
    ''' the form to show/hide and position the appropriate controls
    ''' and change the occasional label text.  The controls have been
    ''' grouped into rows of the table layout panel so that we can manipulate groupings
    ''' of controls rather than individual ones.  We loop through the controls
    ''' looking for the ones we need shown and then hide the rest.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cboRuleTypeSelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRuleType.SelectedIndexChanged
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
                                If Not Me.cboComparison.Items.Count = m_scalarComparison.Length Then
                                    'Me.cboComparison.SelectedIndex = -1
                                    Me.cboComparison.Items.Clear()
                                    Me.cboComparison.Items.AddRange(m_scalarComparison)
                                End If
                                controlObject.TabIndex = 0
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpOSVersion"
                                controlObject.TabIndex = 1
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpServicePack"
                                controlObject.TabIndex = 2
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpData"

                                controlObject.TabIndex = 3
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                Me.txtData.Width = Me.txtVersion.Width

                                If Not Me.lblData.Text = Globals.globalRM.GetString("build_number") Then
                                    Me.txtData.Text = ""
                                    Me.lblData.Text = Globals.globalRM.GetString("build_number")
                                End If

                                Me.lblDataInfo.Hide()
                                controlObject.Show()
                            Case "tlpProductType"
                                controlObject.TabIndex = 4
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case Else
                                controlObject.Hide()
                        End Select
                    Next
                Case RuleTypes.WindowsLanguage
                    For Each controlObject As Control In Me.tlpRules.Controls
                        Select Case controlObject.Name
                            Case "tlpLanguage"
                                controlObject.Show()
                            Case Else
                                controlObject.Hide()
                        End Select
                    Next
                Case RuleTypes.ProcessorArchitecture
                    For Each controlObject As Control In Me.tlpRules.Controls
                        Select Case controlObject.Name
                            Case "tlpProcessorType"
                                controlObject.Show()
                            Case Else
                                controlObject.Hide()
                        End Select
                    Next
                Case RuleTypes.FileExists
                    For Each controlObject As Control In Me.tlpRules.Controls
                        Select Case controlObject.Name
                            Case "tlpEnvironmentVariable"
                                controlObject.TabIndex = 0
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpFilePath"
                                controlObject.TabIndex = 1
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpVersion"
                                controlObject.TabIndex = 2
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case Else
                                controlObject.Hide()
                        End Select
                    Next
                Case RuleTypes.FileExistsWithRegistry
                    For Each controlObject As Control In Me.tlpRules.Controls
                        Select Case controlObject.Name
                            Case "tlpRegistryKey"
                                controlObject.TabIndex = 0
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpRegistryValue"
                                controlObject.TabIndex = 1
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpRegistry32Bit"
                                controlObject.TabIndex = 2
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                                controlObject.Left = Me.tlpRegistryValue.Left + Me.tlpRegistryValue.Width + 5
                            Case "tlpFilePath"
                                controlObject.TabIndex = 3
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpVersion"
                                controlObject.TabIndex = 4
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case Else
                                controlObject.Hide()
                        End Select
                    Next
                Case RuleTypes.FileCreation
                    For Each controlObject As Control In Me.tlpRules.Controls
                        Select Case controlObject.Name
                            Case "tlpEnvironmentVariable"
                                controlObject.TabIndex = 0
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpFilePath"
                                controlObject.TabIndex = 1
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpComparison"
                                'Only change if we need to by testing to see if the
                                ' first element needed already exists in the combobox
                                If Not Me.cboComparison.Items.Count = m_scalarComparison.Length Then
                                    Me.cboComparison.Items.Clear()
                                    Me.cboComparison.Items.AddRange(m_scalarComparison)
                                End If

                                controlObject.TabIndex = 2
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpDate"
                                controlObject.TabIndex = 3
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                Me.lblDate.Text = Globals.globalRM.GetString("creation_date")
                                controlObject.Show()
                            Case Else
                                controlObject.Hide()
                        End Select
                    Next
                Case RuleTypes.FileCreationWithRegistry
                    For Each controlObject As Control In Me.tlpRules.Controls
                        Select Case controlObject.Name
                            Case "tlpRegistryKey"
                                controlObject.TabIndex = 0
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpRegistryValue"
                                controlObject.TabIndex = 1
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpRegistry32Bit"
                                controlObject.TabIndex = 2
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                                controlObject.Left = Me.tlpRegistryValue.Left + Me.tlpRegistryValue.Width + 5
                            Case "tlpFilePath"
                                controlObject.TabIndex = 3
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpComparison"
                                'Only change if we need to by testing to see if the
                                ' first element needed already exists in the combobox.
                                If Not Me.cboComparison.Items.Count = m_scalarComparison.Length Then
                                    Me.cboComparison.Items.Clear()
                                    Me.cboComparison.Items.AddRange(m_scalarComparison)
                                End If

                                controlObject.TabIndex = 4
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpDate"
                                controlObject.TabIndex = 5
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                Me.lblDate.Text = Globals.globalRM.GetString("creation_date")
                                controlObject.Show()
                            Case Else
                                controlObject.Hide()
                        End Select
                    Next
                Case RuleTypes.FileModified
                    For Each controlObject As Control In Me.tlpRules.Controls
                        Select Case controlObject.Name
                            Case "tlpEnvironmentVariable"
                                controlObject.TabIndex = 0
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpFilePath"
                                controlObject.TabIndex = 1
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpComparison"
                                'Only change if we need to by testing to see if the
                                ' first element needed already exists in the combobox.
                                If Not Me.cboComparison.Items.Count = m_scalarComparison.Length Then
                                    Me.cboComparison.Items.Clear()
                                    Me.cboComparison.Items.AddRange(m_scalarComparison)
                                End If

                                controlObject.TabIndex = 2
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpDate"
                                controlObject.TabIndex = 3
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                Me.lblDate.Text = Globals.globalRM.GetString("modified_date")
                                controlObject.Show()
                            Case Else
                                controlObject.Hide()
                        End Select
                    Next
                Case RuleTypes.FileModifiedWithRegistry
                    For Each controlObject As Control In Me.tlpRules.Controls
                        Select Case controlObject.Name
                            Case "tlpRegistryKey"
                                controlObject.TabIndex = 0
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpRegistryValue"
                                controlObject.TabIndex = 1
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpRegistry32Bit"
                                controlObject.TabIndex = 2
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                                controlObject.Left = Me.tlpRegistryValue.Left + Me.tlpRegistryValue.Width + 5
                            Case "tlpRegistry32Bit"
                                controlObject.TabIndex = 3
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                                controlObject.Left = Me.tlpRegistryValue.Left + Me.tlpRegistryValue.Width + 5
                            Case "tlpFilePath"
                                controlObject.TabIndex = 4
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpComparison"
                                'Only change if we need to by testing to see if the
                                ' first element needed already exists in the combobox.
                                If Not Me.cboComparison.Items.Count = m_scalarComparison.Length Then
                                    Me.cboComparison.Items.Clear()
                                    Me.cboComparison.Items.AddRange(m_scalarComparison)
                                End If

                                controlObject.TabIndex = 5
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpDate"
                                controlObject.TabIndex = 6
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                Me.lblDate.Text = Globals.globalRM.GetString("modified_date")
                                controlObject.Show()
                            Case Else
                                controlObject.Hide()
                        End Select
                    Next
                Case RuleTypes.FileSize
                    For Each controlObject As Control In Me.tlpRules.Controls
                        Select Case controlObject.Name
                            Case "tlpEnvironmentVariable"
                                controlObject.TabIndex = 0
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpFilePath"
                                controlObject.TabIndex = 1
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpComparison"
                                'Only change if we need to by testing to see if the
                                ' first element needed already exists in the combobox.
                                If Not Me.cboComparison.Items.Count = m_scalarComparison.Length Then
                                    Me.cboComparison.Items.Clear()
                                    Me.cboComparison.Items.AddRange(m_scalarComparison)
                                End If

                                controlObject.TabIndex = 2
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpData"
                                controlObject.TabIndex = 3
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                Me.txtData.Width = Me.txtVersion.Width

                                If Not Me.lblData.Text = Globals.globalRM.GetString("size") Then
                                    Me.txtData.Text = ""
                                    Me.lblData.Text = Globals.globalRM.GetString("size")
                                End If

                                Me.lblDataInfo.Text = Globals.globalRM.GetString("in_bytes_example")
                                Me.lblDataInfo.Show()
                                controlObject.Show()
                            Case Else
                                controlObject.Hide()
                        End Select
                    Next
                Case RuleTypes.FileSizeWithRegistry
                    For Each controlObject As Control In Me.tlpRules.Controls
                        Select Case controlObject.Name
                            Case "tlpRegistryKey"
                                controlObject.TabIndex = 0
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpRegistryValue"
                                controlObject.TabIndex = 1
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpRegistry32Bit"
                                controlObject.TabIndex = 2
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                                controlObject.Left = Me.tlpRegistryValue.Left + Me.tlpRegistryValue.Width + 5
                            Case "tlpFilePath"
                                controlObject.TabIndex = 3
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpComparison"
                                'Only change if we need to by testing to see if the
                                ' first element needed already exists in the combobox.
                                If Not Me.cboComparison.Items.Count = m_scalarComparison.Length Then
                                    Me.cboComparison.Items.Clear()
                                    Me.cboComparison.Items.AddRange(m_scalarComparison)
                                End If

                                controlObject.TabIndex = 4
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpData"
                                controlObject.TabIndex = 5
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                Me.txtData.Width = Me.txtVersion.Width

                                If Not Me.lblData.Text = Globals.globalRM.GetString("size") Then
                                    Me.txtData.Text = ""
                                    Me.lblData.Text = Globals.globalRM.GetString("size")
                                End If

                                Me.lblDataInfo.Text = Globals.globalRM.GetString("in_bytes_example")
                                Me.lblDataInfo.Show()
                                controlObject.Show()
                            Case Else
                                controlObject.Hide()
                        End Select
                    Next
                Case RuleTypes.FileVersion
                    For Each controlObject As Control In Me.tlpRules.Controls
                        Select Case controlObject.Name
                            Case "tlpEnvironmentVariable"
                                controlObject.TabIndex = 0
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                                'controlObject.Top = _startingYConstant
                            Case "tlpFilePath"
                                controlObject.TabIndex = 1
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpComparison"
                                'Only change if we need to by testing to see if the
                                ' first element needed already exists in the combobox.
                                If Not Me.cboComparison.Items.Count = m_scalarComparison.Length Then
                                    Me.cboComparison.Items.Clear()
                                    Me.cboComparison.Items.AddRange(m_scalarComparison)
                                End If

                                controlObject.TabIndex = 2
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpVersion"
                                controlObject.TabIndex = 3
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case Else
                                controlObject.Hide()
                        End Select
                    Next
                Case RuleTypes.FileVersionWithRegistry
                    For Each controlObject As Control In Me.tlpRules.Controls
                        Select Case controlObject.Name
                            Case "tlpRegistryKey"
                                controlObject.TabIndex = 0
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpRegistryValue"
                                controlObject.TabIndex = 1
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpRegistry32Bit"
                                controlObject.TabIndex = 2
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                                controlObject.Left = Me.tlpRegistryValue.Left + Me.tlpRegistryValue.Width + 5
                            Case "tlpFilePath"
                                controlObject.TabIndex = 3
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpComparison"
                                'Only change if we need to by testing to see if the
                                ' first element needed already exists in the combobox.
                                If Not Me.cboComparison.Items.Count = m_scalarComparison.Length Then
                                    Me.cboComparison.Items.Clear()
                                    Me.cboComparison.Items.AddRange(m_scalarComparison)
                                End If

                                controlObject.TabIndex = 4
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpVersion"
                                controlObject.TabIndex = 5
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case Else
                                controlObject.Hide()
                        End Select
                    Next
                Case RuleTypes.RegistryKeyExists
                    For Each controlObject As Control In Me.tlpRules.Controls
                        Select Case controlObject.Name
                            Case "tlpRegistryKey"
                                controlObject.TabIndex = 0
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpRegistry32Bit"
                                controlObject.TabIndex = 1
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                                controlObject.Left = Me.cboRegistryKey.Left
                            Case Else
                                controlObject.Hide()
                        End Select
                    Next
                Case RuleTypes.RegistryValueExists
                    For Each controlObject As Control In Me.tlpRules.Controls
                        Select Case controlObject.Name
                            Case "tlpRegistryKey"
                                controlObject.TabIndex = 0
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpRegistryValue"
                                controlObject.TabIndex = 1
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpRegistry32Bit"
                                controlObject.TabIndex = 2
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                                controlObject.Left = Me.tlpRegistryValue.Left + Me.tlpRegistryValue.Width + 5
                            Case "tlpRegistryValueType"
                                controlObject.TabIndex = 3
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case Else
                                controlObject.Hide()
                        End Select
                    Next
                Case RuleTypes.RegistryDWORDValue
                    For Each controlObject As Control In Me.tlpRules.Controls
                        Select Case controlObject.Name
                            Case "tlpRegistryKey"
                                controlObject.TabIndex = 0
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpRegistryValue"
                                controlObject.TabIndex = 1
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpRegistry32Bit"
                                controlObject.TabIndex = 2
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                                controlObject.Left = Me.tlpRegistryValue.Left + Me.tlpRegistryValue.Width + 5
                            Case "tlpComparison"
                                'Only change if we need to by testing to see if the
                                ' first element needed already exists in the combobox.
                                If Not Me.cboComparison.Items.Count = m_scalarComparison.Length Then
                                    Me.cboComparison.Items.Clear()
                                    Me.cboComparison.Items.AddRange(m_scalarComparison)
                                End If

                                controlObject.TabIndex = 3
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpData"
                                controlObject.TabIndex = 4
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)

                                If Not Me.lblData.Text = Globals.globalRM.GetString("DWORD_value") Then
                                    Me.txtData.Text = ""
                                    Me.lblData.Text = Globals.globalRM.GetString("DWORD_value")
                                End If

                                Me.lblDataInfo.Hide()
                                Me.txtData.Width = Me.txtFilePath.Width
                                controlObject.Show()
                                'controlObject.Top = _startingYConstant + (3 * _spacingConstant)
                            Case Else
                                controlObject.Hide()
                        End Select
                    Next
                Case RuleTypes.RegistryExpandSzValue
                    For Each controlObject As Control In Me.tlpRules.Controls
                        Select Case controlObject.Name
                            Case "tlpRegistryKey"
                                controlObject.TabIndex = 0
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpRegistryValue"
                                controlObject.TabIndex = 1
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpRegistry32Bit"
                                controlObject.TabIndex = 2
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                                controlObject.Left = Me.tlpRegistryValue.Left + Me.tlpRegistryValue.Width + 5
                            Case "tlpComparison"
                                'Only change if we need to by testing to see if the
                                ' first element needed already exists in the combobox.
                                If Not Me.cboComparison.Items.Count = m_stringComparison.Length Then
                                    Me.cboComparison.Items.Clear()
                                    Me.cboComparison.Items.AddRange(m_stringComparison)
                                End If

                                controlObject.TabIndex = 3
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpData"
                                controlObject.TabIndex = 4
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                If Not Me.lblData.Text = Globals.globalRM.GetString("string") Then
                                    Me.txtData.Text = ""
                                    Me.lblData.Text = Globals.globalRM.GetString("string")
                                End If
                                Me.lblDataInfo.Hide()
                                Me.txtData.Width = Me.txtFilePath.Width
                                controlObject.Show()
                            Case Else
                                controlObject.Hide()
                        End Select
                    Next
                Case RuleTypes.RegistryVersionInSz
                    For Each controlObject As Control In Me.tlpRules.Controls
                        Select Case controlObject.Name
                            Case "tlpRegistryKey"
                                controlObject.TabIndex = 0
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpRegistryValue"
                                controlObject.TabIndex = 1
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpRegistry32Bit"
                                controlObject.TabIndex = 2
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                                controlObject.Left = Me.tlpRegistryValue.Left + Me.tlpRegistryValue.Width + 5
                            Case "tlpComparison"
                                'Only change if we need to by testing to see if the
                                ' first element needed already exists in the combobox.
                                If Not Me.cboComparison.Items.Count = m_scalarComparison.Length Then
                                    Me.cboComparison.Items.Clear()
                                    Me.cboComparison.Items.AddRange(m_scalarComparison)
                                End If

                                controlObject.TabIndex = 3
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpVersion"
                                controlObject.TabIndex = 4
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case Else
                                controlObject.Hide()
                        End Select
                    Next
                Case RuleTypes.RegistrySzValue
                    For Each controlObject As Control In Me.tlpRules.Controls
                        Select Case controlObject.Name
                            Case "tlpRegistryKey"
                                controlObject.TabIndex = 0
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpRegistryValue"
                                controlObject.TabIndex = 1
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpRegistry32Bit"
                                controlObject.TabIndex = 2
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                                controlObject.Left = Me.tlpRegistryValue.Left + Me.tlpRegistryValue.Width + 5
                            Case "tlpComparison"
                                'Only change if we need to by testing to see if the
                                ' first element needed already exists in the combobox.
                                If Not Me.cboComparison.Items.Count = m_stringComparison.Length Then
                                    Me.cboComparison.Items.Clear()
                                    Me.cboComparison.Items.AddRange(m_stringComparison)
                                End If

                                controlObject.TabIndex = 3
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                            Case "tlpData"
                                controlObject.TabIndex = 4
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                Me.txtData.Width = Me.txtFilePath.Width

                                If Not Me.lblData.Text = Globals.globalRM.GetString("string") Then
                                    Me.txtData.Text = ""
                                    Me.lblData.Text = Globals.globalRM.GetString("string")
                                End If

                                Me.lblDataInfo.Hide()
                                controlObject.Show()
                            Case Else
                                controlObject.Hide()
                        End Select
                    Next
                Case RuleTypes.WMIQuery
                    For Each controlObject As Control In Me.tlpRules.Controls
                        Select Case controlObject.Name
                            Case "tlpData"
                                controlObject.TabIndex = 0
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                Me.txtData.Width = Me.txtFilePath.Width
                                Me.txtData.Text = ""
                                Me.lblData.Text = Globals.globalRM.GetString("label_rules_WMI_namespace")
                                Me.lblDataInfo.Hide()
                                controlObject.Show()
                            Case "tlpQuery"
                                controlObject.TabIndex = 1
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                'We set the hight here rather than the designer because the designer will not
                                ' allow the form to be high enough to design all of the elements at the same time.
                                Me.txtQuery.Height = 300
                                controlObject.Show()
                            Case Else
                                controlObject.Hide()
                        End Select
                    Next
                Case RuleTypes.MsiProductInstalled
                    For Each controlObject As Control In Me.tlpRules.Controls
                        Select Case controlObject.Name
                            Case "tlpProductCode"
                                controlObject.TabIndex = 0
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                                Exit Select
                            Case "tlpMinVersion"
                                controlObject.TabIndex = 1
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                                Exit Select
                            Case "tlpMaxVersion"
                                controlObject.TabIndex = 2
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                                Exit Select
                            Case "tlpLanguage"
                                controlObject.TabIndex = 3
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                                Exit Select
                            Case Else
                                controlObject.Hide()
                                Exit Select
                        End Select
                    Next
                Case RuleTypes.MsiPatchInstalled
                    For Each controlObject As Control In Me.tlpRules.Controls
                        Select Case controlObject.Name
                            Case "tlpProductCode"
                                controlObject.TabIndex = 0
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                                Exit Select
                            Case "tlpPatchCode"
                                controlObject.TabIndex = 1
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                                Exit Select
                            Case "tlpMinVersion"
                                controlObject.TabIndex = 2
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                                Exit Select
                            Case "tlpMaxVersion"
                                controlObject.TabIndex = 3
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                                Exit Select
                            Case "tlpLanguage"
                                controlObject.TabIndex = 4
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                                Exit Select
                            Case Else
                                controlObject.Hide()
                                Exit Select
                        End Select
                    Next
                Case RuleTypes.MsiComponentInstalled
                    For Each controlObject As Control In Me.tlpRules.Controls
                        Select Case controlObject.Name
                            Case "pnlProductCollection"
                                controlObject.TabIndex = 0
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                                Exit Select
                            Case "pnlComponentCollection"
                                controlObject.TabIndex = 1
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                                Exit Select
                            Case Else
                                controlObject.Hide()
                                Exit Select
                        End Select
                    Next
                Case RuleTypes.MsiFeatureInstalled
                    For Each controlObject As Control In Me.tlpRules.Controls
                        Select Case controlObject.Name
                            Case "pnlProductCollection"
                                controlObject.TabIndex = 0
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                                Exit Select
                            Case "pnlFeatureCollection"
                                controlObject.TabIndex = 1
                                Me.tlpRules.SetRow(controlObject, controlObject.TabIndex)
                                controlObject.Show()
                                Exit Select
                            Case Else
                                controlObject.Hide()
                                Exit Select
                        End Select
                    Next
                Case Else
                    MsgBox(Globals.globalRM.GetString("error_rules_unsupported_type"))
                    For Each controlObject As Control In Me.tlpRules.Controls
                        If TypeOf controlObject Is Panel Or TypeOf controlObject Is TableLayoutPanel Then
                            controlObject.Hide()
                        End If
                    Next
            End Select

            Call ValidateForm()
        End If 'Combobox has a selection.
    End Sub

    ''' <summary>
    ''' When user is finished, generate the rule and close.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnAddClick(sender As Object, e As EventArgs) Handles btnAdd.Click
        Call GenerateRule()
    End Sub

    ''' <summary>
    ''' Set the corresponding text boxes and the service pack combo when
    ''' the user modifies the OS version checkboxes.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub GetOSVersionCodes(sender As Object, e As EventArgs) Handles cboOSVersion.SelectedIndexChanged
        'Clear the service pack combobox.
        Me.cboServicePack.SelectedIndex = -1
        Me.cboServicePack.Items.Clear()
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

    ''' <summary>
    ''' Set the corresponding codes to the service pack.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub GetServicePackCode(sender As Object, e As EventArgs) Handles cboServicePack.SelectedIndexChanged
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

#Region "Shared Methods"

    ''' <summary>
    ''' Set the corresponding text fields to the service pack.
    ''' </summary>
    ''' <param name="spMajor">Service Pack</param>
    ''' <returns>String</returns>
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

    ''' <summary>
    ''' Return the XML compatible comparison string based on the human readable string.
    ''' </summary>
    ''' <param name="comparison">Code indicating comparison type.</param>
    ''' <returns>String</returns>
    Shared Function GetComparisonCode(comparison As String) As String
        Select Case comparison
            Case Globals.globalRM.GetString("equal_to")
                Return "EqualTo"
            Case Globals.globalRM.GetString("less_than")
                Return "LessThan"
            Case Globals.globalRM.GetString("less_than_or_equal_to")
                Return "LessThanOrEqualTo"
            Case Globals.globalRM.GetString("greater_than")
                Return "GreaterThan"
            Case Globals.globalRM.GetString("greater_than_or_equal_to")
                Return "GreaterThanOrEqualTo"
            Case Globals.globalRM.GetString("begins_with")
                Return "BeginsWith"
            Case Globals.globalRM.GetString("ends_with")
                Return "EndsWith"
            Case Globals.globalRM.GetString("contains")
                Return "Contains"
            Case Else
                Return Nothing
        End Select
    End Function

    ''' <summary>
    ''' Return the human readable string based on the XML compatible comparison string.
    ''' </summary>
    ''' <param name="comparisonCode">Code indicating comparison type.</param>
    ''' <returns>String</returns>
    Shared Function GetComparisonText(comparisonCode As String) As String
        Select Case comparisonCode
            Case "EqualTo"
                Return Globals.globalRM.GetString("equal_to")
            Case "LessThan"
                Return Globals.globalRM.GetString("less_than")
            Case "LessThanOrEqualTo"
                Return Globals.globalRM.GetString("less_than_or_equal_to")
            Case "GreaterThan"
                Return Globals.globalRM.GetString("greater_than")
            Case "GreaterThanOrEqualTo"
                Return Globals.globalRM.GetString("greater_than_or_equal_to")
            Case "BeginsWith"
                Return Globals.globalRM.GetString("begins_with")
            Case "EndsWith"
                Return Globals.globalRM.GetString("ends_with")
            Case "Contains"
                Return Globals.globalRM.GetString("contains")
            Case Else
                Return Nothing
        End Select
    End Function

    ''' <summary>
    ''' Return the language code based on the human readable string.
    ''' </summary>
    ''' <param name="language">Language name</param>
    ''' <returns>Lanugage Code</returns>
    Shared Function GetLanguageCode(language As String) As String
        Select Case language
            Case Globals.globalRM.GetString("language_arabic")
                Return "ar"
            Case Globals.globalRM.GetString("language_chinese_HK_SAR")
                Return "zh-HK"
            Case Globals.globalRM.GetString("language_chinese_simplified")
                Return "zh-CHS"
            Case Globals.globalRM.GetString("language_chinese_traditional")
                Return "zh-CHT"
            Case Globals.globalRM.GetString("language_czech")
                Return "cs"
            Case Globals.globalRM.GetString("language_danish")
                Return "da"
            Case Globals.globalRM.GetString("language_dutch")
                Return "nl"
            Case Globals.globalRM.GetString("language_english")
                Return "en"
            Case Globals.globalRM.GetString("language_finnish")
                Return "fi"
            Case Globals.globalRM.GetString("language_french")
                Return "fr"
            Case Globals.globalRM.GetString("language_german")
                Return "de"
            Case Globals.globalRM.GetString("language_greek")
                Return "el"
            Case Globals.globalRM.GetString("language_hebrew")
                Return "he"
            Case Globals.globalRM.GetString("language_hungarian")
                Return "hu"
            Case Globals.globalRM.GetString("language_italian")
                Return "it"
            Case Globals.globalRM.GetString("language_japanese")
                Return "ja"
            Case Globals.globalRM.GetString("language_korean")
                Return "ko"
            Case Globals.globalRM.GetString("language_norwegian")
                Return "no"
            Case Globals.globalRM.GetString("language_polish")
                Return "pl"
            Case Globals.globalRM.GetString("language_portuguese")
                Return "pt"
            Case Globals.globalRM.GetString("language_portuguese_brazil")
                Return "pt-BR"
            Case Globals.globalRM.GetString("language_russian")
                Return "ru"
            Case Globals.globalRM.GetString("language_spanish")
                Return "es"
            Case Globals.globalRM.GetString("language_swedish")
                Return "sv"
            Case Globals.globalRM.GetString("language_turkish")
                Return "tr"
            Case Else
                Return Nothing
        End Select
    End Function

    ''' <summary>
    ''' Gets the MSI language code (integer) for the given.
    ''' </summary>
    ''' <param name="iso6391Code">ISO 6391 code</param>
    ''' <returns>Integer</returns>
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


    ''' <summary>
    ''' When a processor type is selected show the XML compatible value.
    ''' </summary>
    ''' <param name="processorType">Processor type</param>
    ''' <returns>String</returns>
    Shared Function GetProcessorTypeCode(processorType As String) As String
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

    ''' <summary>
    ''' When a processor type is selected show the XML compatible value.
    ''' </summary>
    ''' <param name="processorTypeCode">Processor Type Code</param>
    ''' <returns>String</returns>
    Shared Function GetProcessorTypeText(processorTypeCode As String) As String
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

    ''' <summary>
    ''' Return a product type based on the number.
    ''' </summary>
    ''' <param name="productTypeCode">Product Type Code</param>
    ''' <returns>String</returns>
    Shared Function GetProductTypeText(productTypeCode As Integer) As String
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

#Region "Rules"
    ''' <summary>
    ''' When the user is finished, this routine populates the human readable string
    ''' and the XML string accordingly.  The routine calling this form must then use
    ''' these strings to add to the appropriate DGV as well as the SDP's XML.
    ''' </summary>
    Sub GenerateRule()
        'Begin the rule based on the selected rule type.
        m_readableRule = CType(Me.cboRuleType.SelectedItem, RuleTypes).ToDisplayString() & ": "
        m_xmlRule = "<" & CType(Me.cboRuleType.SelectedItem, RuleTypes).ToXmlTag() & " "


        Select Case Me.cboRuleType.SelectedIndex 'Generate rule based on combobox selection.
            Case RuleTypes.WindowsVersion
                'Set the readable rule.
                Me.m_readableRule += "   " & Globals.globalRM.GetString("comparison") & ":" & Me.cboComparison.Text & " " & _
                    "   " & Globals.globalRM.GetString("version") & ":" & Me.txtOSMajorVersion.Text & "." & Me.txtOSMinorVersion.Text & " "
                If Not String.IsNullOrEmpty(Me.txtSPMajorVersion.Text) Then Me.m_readableRule += "   " & Globals.globalRM.GetString("service_pack") & ":" & Me.txtSPMajorVersion.Text & "." & Me.txtSPMinorVersion.Text
                If Not String.IsNullOrEmpty(Me.txtData.Text) Then Me.m_readableRule += "   " & Globals.globalRM.GetString("build_number") & ":" & Me.txtData.Text
                If Not String.IsNullOrEmpty(Me.cboProductType.Text) Then Me.m_readableRule += "   " & Globals.globalRM.GetString("product_type") & ":" & Me.cboProductType.Text

                'Set the xmlrule.
                m_xmlRule += "Comparison=""" & StringToXML(GetComparisonCode(Me.cboComparison.Text)) & """ " & _
                    "MajorVersion=""" & StringToXML(Me.txtOSMajorVersion.Text) & """ " & _
                    "MinorVersion=""" & StringToXML(Me.txtOSMinorVersion.Text) & """ "
                If Not String.IsNullOrEmpty(Me.txtData.Text) Then m_xmlRule += "BuildNumber=""" & StringToXML(Me.txtData.Text) & """ "
                m_xmlRule += "ServicePackMajor=""" & If(String.IsNullOrEmpty(Me.txtSPMajorVersion.Text), "0", StringToXML(Me.txtSPMajorVersion.Text)) & """ "
                m_xmlRule += "ServicePackMinor=""" & If(String.IsNullOrEmpty(Me.txtSPMinorVersion.Text), "0", StringToXML(Me.txtSPMinorVersion.Text)) & """ "

                If Not String.IsNullOrEmpty(Me.cboProductType.Text) Then m_xmlRule += "ProductType=""" & Me.cboProductType.SelectedIndex & """ "
                m_xmlRule += " />"
            Case RuleTypes.WindowsLanguage
                'Set the readable rule.
                Me.m_readableRule += Me.cboLanguage.Text

                'Set the xmlrule.
                m_xmlRule += "Language=""" & GetLanguageCode(Me.cboLanguage.Text) & """ />"
            Case RuleTypes.ProcessorArchitecture
                'Set the readable rule.
                Me.m_readableRule += Me.cboProcessorType.Text

                'Set the xmlrule.
                m_xmlRule += "Architecture=""" & GetProcessorTypeCode(Me.cboProcessorType.Text) & """ />"
            Case RuleTypes.FileExists
                'Set the readable rule.
                Me.m_readableRule += Me.txtFilePath.Text.Trim("\"c)
                If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) AndAlso Not Me.cboEnvironmentVariable.Text = "NONE" Then Me.m_readableRule += "   " & Globals.globalRM.GetString("CSID") & ": " & Me.cboEnvironmentVariable.Text
                If Not String.IsNullOrEmpty(Me.txtVersion.Text) Then Me.m_readableRule += "   " & Globals.globalRM.GetString("version") & ": " & Me.txtVersion.Text

                'Set the xmlrule.
                m_xmlRule += "Path=""" & StringToXML(Me.txtFilePath.Text.Trim("\"c)) & """ "
                'If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text ) Then _xmlRule += "Csidl=""" & GetCSIDCode(Me.cboEnvironmentVariable.Text) & """ "
                If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) AndAlso Not Me.cboEnvironmentVariable.Text = "NONE" Then m_xmlRule += "Csidl=""" & DirectCast(Me.cboEnvironmentVariable.SelectedValue, Integer) & """ "

                If Not String.IsNullOrEmpty(Me.txtVersion.Text) Then m_xmlRule += "Version=""" & StringToXML(Me.txtVersion.Text) & """ "
                m_xmlRule += " />"
            Case RuleTypes.FileExistsWithRegistry
                'Set the readable rule.
                Me.m_readableRule += Me.cboRegistryKey.Text & "\" & Me.txtRegistrySubKey.Text.Trim("\"c) & "\" & Me.txtRegistryValue.Text.Trim("\"c)
                If Me.chkRegistry32Bit.Checked Then Me.m_readableRule += "   Reg32:" & Globals.globalRM.GetString("true")
                Me.m_readableRule += "   " & Globals.globalRM.GetString("path") & ":" & Me.txtFilePath.Text.Trim("\"c)
                If Not String.IsNullOrEmpty(Me.txtVersion.Text) Then Me.m_readableRule += "   " & Globals.globalRM.GetString("version") & ": " & Me.txtVersion.Text

                'Set the xmlrule.
                m_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
                    "Subkey=""" & StringToXML(Me.txtRegistrySubKey.Text.Trim("\"c)) & """ " & _
                    "Value=""" & StringToXML(Me.txtRegistryValue.Text.Trim("\"c)) & """ "
                If Me.chkRegistry32Bit.Checked Then m_xmlRule += "RegType32=""true"" "
                m_xmlRule += "Path=""" & StringToXML(Me.txtFilePath.Text.Trim("\"c)) & """ "
                If Not String.IsNullOrEmpty(Me.txtVersion.Text) Then m_xmlRule += "Version=""" & StringToXML(Me.txtVersion.Text) & """ "
                m_xmlRule += " />"
            Case RuleTypes.FileCreation
                'Set the readable rule.
                Me.m_readableRule += Me.txtFilePath.Text.Trim("\"c)
                If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) AndAlso Not Me.cboEnvironmentVariable.Text = "NONE" Then Me.m_readableRule += "   " & Globals.globalRM.GetString("CSID") & ": " & Me.cboEnvironmentVariable.Text
                Me.m_readableRule += "   " & Globals.globalRM.GetString("comparison") & ":" & Me.cboComparison.Text & _
                    "   " & Globals.globalRM.GetString("created") & ":" & Me.dtpDate.Value.ToLongDateString

                'Set the xmlrule.
                m_xmlRule += "Path=""" & StringToXML(Me.txtFilePath.Text.Trim("\"c)) & """ "
                'If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) Then _xmlRule += "Csidl=""" & GetCSIDCode(Me.cboEnvironmentVariable.Text) & """ "
                If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) AndAlso Not Me.cboEnvironmentVariable.Text = "NONE" Then m_xmlRule += "Csidl=""" & DirectCast(Me.cboEnvironmentVariable.SelectedValue, Integer) & """ "
                m_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
                    "Created=""" & Format(Me.dtpDate.Value.ToUniversalTime, "yyyy-MM-dd'T'HH:mm:ss" & "Z") & """ "
                m_xmlRule += " />"
            Case RuleTypes.FileCreationWithRegistry
                'Set the readable rule.
                Me.m_readableRule += Me.cboRegistryKey.Text & "\" & Me.txtRegistrySubKey.Text.Trim("\"c) & "\" & Me.txtRegistryValue.Text.Trim("\"c)
                If Me.chkRegistry32Bit.Checked Then Me.m_readableRule += "   Reg32:" & Globals.globalRM.GetString("true")
                Me.m_readableRule += "   " & Globals.globalRM.GetString("path") & ":" & Me.txtFilePath.Text.Trim("\"c)
                Me.m_readableRule += "   " & Globals.globalRM.GetString("comparison") & ":" & Me.cboComparison.Text & _
                    "   " & Globals.globalRM.GetString("created") & ":" & Me.dtpDate.Value.ToLongDateString

                'Set the xmlrule.
                m_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
                    "Subkey=""" & StringToXML(Me.txtRegistrySubKey.Text.Trim("\"c)) & """ " & _
                    "Value=""" & StringToXML(Me.txtRegistryValue.Text.Trim("\"c)) & """ "
                If Me.chkRegistry32Bit.Checked Then m_xmlRule += "RegType32=""true"" "
                m_xmlRule += "Path=""" & StringToXML(Me.txtFilePath.Text.Trim("\"c)) & """ "
                m_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
                    "Created=""" & Format(Me.dtpDate.Value.ToUniversalTime, "yyyy-MM-dd'T'HH:mm:ss" & "Z") & """ "
                m_xmlRule += " />"
            Case RuleTypes.FileModified
                'Set the readable rule
                Me.m_readableRule += Me.txtFilePath.Text.Trim("\"c)
                If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) AndAlso Not Me.cboEnvironmentVariable.Text = "NONE" Then Me.m_readableRule += "   " & Globals.globalRM.GetString("CSID") & ": " & Me.cboEnvironmentVariable.Text
                Me.m_readableRule += "   " & Globals.globalRM.GetString("comparison") & ":" & Me.cboComparison.Text & _
                    "   " & Globals.globalRM.GetString("modified") & ":" & Me.dtpDate.Value.ToLongDateString

                'Set the xmlrule.
                m_xmlRule += "Path=""" & StringToXML(Me.txtFilePath.Text.Trim("\"c)) & """ "
                'If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) Then _xmlRule += "Csidl=""" & GetCSIDCode(Me.cboEnvironmentVariable.Text) & """ "
                If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) AndAlso Not Me.cboEnvironmentVariable.Text = "NONE" Then m_xmlRule += "Csidl=""" & DirectCast(Me.cboEnvironmentVariable.SelectedValue, Integer).ToString & """ "
                m_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
                    "Modified=""" & Format(Me.dtpDate.Value.ToUniversalTime, "yyyy-MM-dd'T'HH:mm:ss" & "Z") & """ "
                m_xmlRule += " />"
            Case RuleTypes.FileModifiedWithRegistry
                'Set the readable rule.
                Me.m_readableRule += Me.cboRegistryKey.Text & "\" & Me.txtRegistrySubKey.Text.Trim("\"c) & "\" & Me.txtRegistryValue.Text.Trim("\"c)
                If Me.chkRegistry32Bit.Checked Then Me.m_readableRule += "   Reg32:" & Globals.globalRM.GetString("true")
                Me.m_readableRule += "   " & Globals.globalRM.GetString("path") & ":" & Me.txtFilePath.Text.Trim("\"c)
                Me.m_readableRule += "   " & Globals.globalRM.GetString("comparison") & ":" & Me.cboComparison.Text & _
                    "   " & Globals.globalRM.GetString("modified") & ":" & Me.dtpDate.Value.ToLongDateString

                'Set the xmlrule.
                m_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
                    "Subkey=""" & StringToXML(Me.txtRegistrySubKey.Text.Trim("\"c)) & """ " & _
                    "Value=""" & StringToXML(Me.txtRegistryValue.Text.Trim("\"c)) & """ "
                If Me.chkRegistry32Bit.Checked Then m_xmlRule += "RegType32=""true"" "
                m_xmlRule += "Path=""" & StringToXML(Me.txtFilePath.Text.Trim("\"c)) & """ "
                m_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
                    "Modified=""" & Format(Me.dtpDate.Value.ToUniversalTime, "yyyy-MM-dd'T'HH:mm:ss" & "Z") & """ "
                m_xmlRule += " />"
            Case RuleTypes.FileSize
                'Set the readable rule.
                Me.m_readableRule += Me.txtFilePath.Text.Trim("\"c)
                If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) AndAlso Not Me.cboEnvironmentVariable.Text = "NONE" Then Me.m_readableRule += "   " & Globals.globalRM.GetString("CSID") & ": " & Me.cboEnvironmentVariable.Text
                Me.m_readableRule += "   " & Globals.globalRM.GetString("comparison") & ":" & Me.cboComparison.Text & _
                    "   " & Globals.globalRM.GetString("size") & ": " & Me.txtData.Text

                'Set the xmlrule.
                m_xmlRule += "Path=""" & StringToXML(Me.txtFilePath.Text.Trim("\"c)) & """ "
                'If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) Then _xmlRule += "Csidl=""" & GetCSIDCode(Me.cboEnvironmentVariable.Text) & """ "
                If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) AndAlso Not Me.cboEnvironmentVariable.Text = "NONE" Then m_xmlRule += "Csidl=""" & DirectCast(Me.cboEnvironmentVariable.SelectedValue, Integer).ToString & """ "
                m_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
                    "Size=""" & StringToXML(Me.txtData.Text) & """ "
                m_xmlRule += " />"
            Case RuleTypes.FileSizeWithRegistry
                'Set the readable rule.
                Me.m_readableRule += Me.cboRegistryKey.Text & "\" & Me.txtRegistrySubKey.Text.Trim("\"c) & "\" & Me.txtRegistryValue.Text.Trim("\"c)
                If Me.chkRegistry32Bit.Checked Then Me.m_readableRule += "   Reg32:" & Globals.globalRM.GetString("true")
                Me.m_readableRule += "   " & Globals.globalRM.GetString("path") & ":" & Me.txtFilePath.Text.Trim("\"c)
                Me.m_readableRule += "   " & Globals.globalRM.GetString("comparison") & ":" & Me.cboComparison.Text & _
                    "   " & Globals.globalRM.GetString("size") & ": " & Me.txtData.Text

                'Set the xmlrule.
                m_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
                    "Subkey=""" & StringToXML(Me.txtRegistrySubKey.Text.Trim("\"c)) & """ " & _
                    "Value=""" & StringToXML(Me.txtRegistryValue.Text.Trim("\"c)) & """ "
                If Me.chkRegistry32Bit.Checked Then m_xmlRule += "RegType32=""true"" "
                m_xmlRule += "Path=""" & StringToXML(Me.txtFilePath.Text.Trim("\"c)) & """ "
                m_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
                    "Size=""" & StringToXML(Me.txtData.Text) & """ "
                m_xmlRule += " />"
            Case RuleTypes.FileVersion
                'Set the readable rule.
                Me.m_readableRule += Me.txtFilePath.Text.Trim("\"c)
                If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) AndAlso Not Me.cboEnvironmentVariable.Text = "NONE" Then Me.m_readableRule += "   " & Globals.globalRM.GetString("CSID") & ": " & Me.cboEnvironmentVariable.Text
                Me.m_readableRule += "   " & Globals.globalRM.GetString("comparison") & ":" & Me.cboComparison.Text
                If Not String.IsNullOrEmpty(Me.txtVersion.Text) AndAlso Not Me.cboEnvironmentVariable.Text = "NONE" Then Me.m_readableRule += "   " & Globals.globalRM.GetString("version") & ": " & Me.txtVersion.Text

                'Set the xmlrule.
                m_xmlRule += "Path=""" & StringToXML(Me.txtFilePath.Text.Trim("\"c)) & """ "
                'If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) Then _xmlRule += "Csidl=""" & GetCSIDCode(Me.cboEnvironmentVariable.Text) & """ "
                If Not String.IsNullOrEmpty(Me.cboEnvironmentVariable.Text) Then m_xmlRule += "Csidl=""" & DirectCast(Me.cboEnvironmentVariable.SelectedValue, Integer).ToString & """ "
                m_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ "
                If Not String.IsNullOrEmpty(Me.txtVersion.Text) Then m_xmlRule += "Version=""" & StringToXML(Me.txtVersion.Text) & """ "
                m_xmlRule += " />"
            Case RuleTypes.FileVersionWithRegistry
                'Set the readable rule.
                Me.m_readableRule += Me.cboRegistryKey.Text & "\" & Me.txtRegistrySubKey.Text.Trim("\"c) & "\" & Me.txtRegistryValue.Text.Trim("\"c) & _
                    "   " & Globals.globalRM.GetString("path") & ":" & Me.txtFilePath.Text.Trim("\"c) & _
                    "   " & Globals.globalRM.GetString("comparison") & ":" & Me.cboComparison.Text & _
                    "   " & Globals.globalRM.GetString("version") & ":" & Me.txtVersion.Text
                If Me.chkRegistry32Bit.Checked Then Me.m_readableRule += "   Reg32:" & Globals.globalRM.GetString("true")

                'Set the xmlrule.
                m_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
                    "Subkey=""" & StringToXML(Me.txtRegistrySubKey.Text.Trim("\"c)) & """ " & _
                    "Value=""" & StringToXML(Me.txtRegistryValue.Text.Trim("\"c)) & """ "
                If Me.chkRegistry32Bit.Checked Then m_xmlRule += "RegType32=""true"" "
                m_xmlRule += "Path=""" & StringToXML(Me.txtFilePath.Text.Trim("\"c)) & """ " & _
                    "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
                    "Version=""" & StringToXML(Me.txtVersion.Text) & """ "
                m_xmlRule += " />"
            Case RuleTypes.RegistryKeyExists
                'Set the readable rule.
                Me.m_readableRule += Me.cboRegistryKey.Text & "\" & _
                    Me.txtRegistrySubKey.Text.Trim("\"c)
                If Me.chkRegistry32Bit.Checked Then Me.m_readableRule += "   Reg32:" & Globals.globalRM.GetString("true")

                'Set the xmlrule.
                m_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
                    "Subkey=""" & StringToXML(Me.txtRegistrySubKey.Text.Trim("\"c)) & """ "
                If Me.chkRegistry32Bit.Checked Then m_xmlRule += "RegType32=""true"" "
                m_xmlRule += " />"
            Case RuleTypes.RegistryValueExists
                'Set the readable rule.
                Me.m_readableRule += Me.cboRegistryKey.Text & "\" & Me.txtRegistrySubKey.Text.Trim("\"c) & _
                    "   " & Globals.globalRM.GetString("value") & ":" & Me.txtRegistryValue.Text & _
                    "   " & Globals.globalRM.GetString("value_type") & ":" & Me.cboRegistryValueType.Text
                If Me.chkRegistry32Bit.Checked Then Me.m_readableRule += "   Reg32:" & Globals.globalRM.GetString("true")

                'Set the xmlrule.
                m_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
                    "Subkey=""" & StringToXML(Me.txtRegistrySubKey.Text.Trim("\"c)) & """ "
                If Not String.IsNullOrEmpty(Me.txtRegistryValue.Text) Then m_xmlRule += "Value=""" & StringToXML(Me.txtRegistryValue.Text) & """ "
                If Me.chkRegistry32Bit.Checked Then m_xmlRule += "RegType32=""true"" "
                m_xmlRule += "Type=""" & StringToXML(Me.cboRegistryValueType.Text) & """ "
                m_xmlRule += " />"
            Case RuleTypes.RegistryDWORDValue
                'Set the readable rule.
                Me.m_readableRule += Me.cboRegistryKey.Text & "\" & Me.txtRegistrySubKey.Text.Trim("\"c) & "\" & Me.txtRegistryValue.Text.Trim("\"c) & _
                    "   " & Globals.globalRM.GetString("comparison") & ":" & Me.cboComparison.Text & _
                    "   " & Globals.globalRM.GetString("data") & ":" & Me.txtData.Text
                If Me.chkRegistry32Bit.Checked Then Me.m_readableRule += "   Reg32:" & Globals.globalRM.GetString("true")

                'Set the xmlrule.
                m_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
                    "Subkey=""" & StringToXML(Me.txtRegistrySubKey.Text.Trim("\"c)) & """ " & _
                    "Value=""" & StringToXML(Me.txtRegistryValue.Text.Trim("\"c)) & """ "
                If Me.chkRegistry32Bit.Checked Then m_xmlRule += "RegType32=""true"" "
                m_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
                    "Data=""" & StringToXML(Me.txtData.Text) & """ "
                m_xmlRule += " />"
            Case RuleTypes.RegistryExpandSzValue
                'Set the readable rule.
                Me.m_readableRule += Me.cboRegistryKey.Text & "\" & Me.txtRegistrySubKey.Text.Trim("\"c) & "\" & Me.txtRegistryValue.Text.Trim("\"c) & _
                    "   " & Globals.globalRM.GetString("comparison") & ":" & Me.cboComparison.Text & _
                    "   " & Globals.globalRM.GetString("string") & ":" & Me.txtData.Text
                If Me.chkRegistry32Bit.Checked Then Me.m_readableRule += "   Reg32:" & Globals.globalRM.GetString("true")

                'Set the xmlrule.
                m_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
                    "Subkey=""" & StringToXML(Me.txtRegistrySubKey.Text.Trim("\"c)) & """ " & _
                    "Value=""" & StringToXML(Me.txtRegistryValue.Text.Trim("\"c)) & """ "
                If Me.chkRegistry32Bit.Checked Then m_xmlRule += "RegType32=""true"" "
                m_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
                    "Data=""" & StringToXML(Me.txtData.Text) & """ "
                m_xmlRule += " />"
            Case RuleTypes.RegistryVersionInSz
                'Set the readable rule.
                Me.m_readableRule += Me.cboRegistryKey.Text & "\" & Me.txtRegistrySubKey.Text.Trim("\"c) & "\" & Me.txtRegistryValue.Text.Trim("\"c) & _
                    "   " & Globals.globalRM.GetString("comparison") & ":" & Me.cboComparison.Text & _
                    "   " & Globals.globalRM.GetString("string") & ":" & Me.txtVersion.Text
                If Me.chkRegistry32Bit.Checked Then Me.m_readableRule += "   Reg32:" & Globals.globalRM.GetString("true")

                'Set the xmlrule.
                m_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
                    "Subkey=""" & StringToXML(Me.txtRegistrySubKey.Text.Trim("\"c)) & """ " & _
                    "Value=""" & StringToXML(Me.txtRegistryValue.Text.Trim("\"c)) & """ "
                If Me.chkRegistry32Bit.Checked Then m_xmlRule += "RegType32=""true"" "
                m_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
                    "Data=""" & StringToXML(Me.txtVersion.Text) & """ "
                m_xmlRule += " />"
            Case RuleTypes.RegistrySzValue
                'Set the readable rule.
                Me.m_readableRule += Me.cboRegistryKey.Text & "\" & Me.txtRegistrySubKey.Text.Trim("\"c) & "\" & Me.txtRegistryValue.Text.Trim("\"c) & _
                    "   " & Globals.globalRM.GetString("comparison") & ":" & Me.cboComparison.Text & _
                    "   " & Globals.globalRM.GetString("string") & ":" & Me.txtData.Text
                If Me.chkRegistry32Bit.Checked Then Me.m_readableRule += "   Reg32:" & Globals.globalRM.GetString("true")

                'Set the xmlrule.
                m_xmlRule += "Key=""" & Me.cboRegistryKey.Text & """ " & _
                    "Subkey=""" & StringToXML(Me.txtRegistrySubKey.Text.Trim("\"c)) & """ " & _
                    "Value=""" & StringToXML(Me.txtRegistryValue.Text.Trim("\"c)) & """ "
                If Me.chkRegistry32Bit.Checked Then m_xmlRule += "RegType32=""true"" "
                m_xmlRule += "Comparison=""" & GetComparisonCode(Me.cboComparison.Text) & """ " & _
                    "Data=""" & StringToXML(Me.txtData.Text) & """ "
                m_xmlRule += " />"
            Case RuleTypes.WMIQuery
                'Set the readable rule.
                If Not String.IsNullOrEmpty(Me.txtData.Text) Then Me.m_readableRule += "NameSpace:" & Me.txtData.Text & " "
                Me.m_readableRule += Globals.globalRM.GetString("query") & ": " & Me.txtQuery.Text

                'Set the xmlrule.
                If Not String.IsNullOrEmpty(Me.txtData.Text) Then m_xmlRule += "Namespace=""" & StringToXML(Me.txtData.Text) & """ "
                m_xmlRule += "WqlQuery=""" & StringToXML(Me.txtQuery.Text) & """ "
                m_xmlRule += " />"

            Case RuleTypes.MsiProductInstalled

                m_readableRule += New Guid(txtProductCode.Text).ToString("B") & "  "
                If Not String.IsNullOrEmpty(txtMaxVersion.Text) Then m_readableRule += " " & Globals.globalRM.GetString("version_maximum") & " = " & txtMaxVersion.Text
                If Not String.IsNullOrEmpty(txtMinVersion.Text) Then m_readableRule += " " & Globals.globalRM.GetString("version_minimum") & " = " & txtMinVersion.Text
                If Not String.IsNullOrEmpty(GetLanguageCode(cboLanguage.Text)) Then m_readableRule += " " & Globals.globalRM.GetString("language") & " = " & cboLanguage.Text

                m_xmlRule += "ProductCode=""" & (New Guid(txtProductCode.Text).ToString("B")) & """"
                If Not String.IsNullOrEmpty(txtMaxVersion.Text) Then m_xmlRule += " VersionMax=""" & StringToXML(txtMaxVersion.Text) & """"
                If Not String.IsNullOrEmpty(txtMinVersion.Text) Then m_xmlRule += " VersionMin=""" & StringToXML(txtMinVersion.Text) & """"
                If Not String.IsNullOrEmpty(GetLanguageCode(cboLanguage.Text)) Then m_xmlRule += " Language=""" & GetMsiLanguageCode(GetLanguageCode(cboLanguage.Text)) & """"
                m_xmlRule += " />"
            Case RuleTypes.MsiPatchInstalled

                m_readableRule += " " & Globals.globalRM.GetString("patch_code") & " = " & (New Guid(txtPatchCode.Text).ToString("B")) & "  " & " for " & Globals.globalRM.GetString("product_code") & " = " & (New Guid(txtProductCode.Text).ToString("B")) & "  "
                If Not String.IsNullOrEmpty(txtMaxVersion.Text) Then m_readableRule += " " & Globals.globalRM.GetString("version_maximum") & " = " & txtMaxVersion.Text
                If Not String.IsNullOrEmpty(txtMinVersion.Text) Then m_readableRule += " " & Globals.globalRM.GetString("version_minimum") & " = " & txtMinVersion.Text
                If Not String.IsNullOrEmpty(GetLanguageCode(cboLanguage.Text)) Then m_readableRule += " " & Globals.globalRM.GetString("language") & " = " & cboLanguage.Text

                m_xmlRule += "PatchCode=""" & (New Guid(txtPatchCode.Text).ToString("B")) & """" & " ProductCode=""" & (New Guid(txtProductCode.Text).ToString("B")) & """"
                If Not String.IsNullOrEmpty(txtMaxVersion.Text) Then m_xmlRule += " VersionMax=""" & StringToXML(txtMaxVersion.Text) & """"
                If Not String.IsNullOrEmpty(txtMinVersion.Text) Then m_xmlRule += " VersionMin=""" & StringToXML(txtMinVersion.Text) & """"
                If Not String.IsNullOrEmpty(GetLanguageCode(cboLanguage.Text)) Then m_xmlRule += " Language=""" & GetMsiLanguageCode(GetLanguageCode(cboLanguage.Text)) & """"
                m_xmlRule += " />"
            Case RuleTypes.MsiComponentInstalled

                'Set the all products and components required value.
                If chkProductCollection_requireAll.Checked Then
                    m_xmlRule += " AllProductsRequired=""true"""
                End If
                If chkComponentCollection_requireAll.Checked Then
                    m_xmlRule += " AllComponentsRequired=""true"""
                End If
                m_xmlRule += ">"

                m_readableRule += Globals.globalRM.GetString("components") & ": "
                If chkComponentCollection_requireAll.Checked Then m_readableRule += " (" & Globals.globalRM.GetString("all_required") & ")" & "  "

                'Add the component Guids.
                For Each tmpGuid As Guid In gceComponentCollection.ItemGuids
                    m_readableRule += tmpGuid.ToString("B") & "  "
                    m_xmlRule += "<msiar:Component>" & tmpGuid.ToString("B") & "</msiar:Component>"
                Next

                m_readableRule += Globals.globalRM.GetString("products") & ": "
                If chkProductCollection_requireAll.Checked Then m_readableRule += " (" & Globals.globalRM.GetString("all_required") & ")" & "  "

                'Add the product Guids.
                For Each tmpGuid As Guid In gceProductCollection.ItemGuids
                    m_readableRule += tmpGuid.ToString("B") & "  "
                    m_xmlRule += "<msiar:Product>" & tmpGuid.ToString("B") & "</msiar:Product>"
                Next

                m_xmlRule += "</" & RuleTypes.MsiComponentInstalled.ToXmlTag() & ">"
            Case RuleTypes.MsiFeatureInstalled

                'Set the all products and components required value.
                If chkProductCollection_requireAll.Checked Then
                    m_xmlRule += " AllProductsRequired=""true"""
                End If
                If chkFeatureCollection_requireAll.Checked Then
                    m_xmlRule += " AllFeaturesRequired=""true"""
                End If
                m_xmlRule += ">"

                m_readableRule += Globals.globalRM.GetString("features") & ": "
                If chkFeatureCollection_requireAll.Checked Then m_readableRule += " (" & Globals.globalRM.GetString("all_required") & ")" & "  "

                'Add the feature names.
                For Each tmpFeature As String In gceFeatureCollection.Items
                    m_readableRule += tmpFeature & "  "
                    m_xmlRule += "<msiar:Feature>" & tmpFeature & "</msiar:Feature>"
                Next

                m_readableRule += Globals.globalRM.GetString("products") & ": "
                If chkProductCollection_requireAll.Checked Then m_readableRule += " (" & Globals.globalRM.GetString("all_required") & ")" & "  "

                'Add the product Guids.
                For Each tmpGuid As Guid In gceProductCollection.ItemGuids
                    m_readableRule += tmpGuid.ToString("B") & "  "
                    m_xmlRule += "<msiar:Product>" & tmpGuid.ToString("B") & "</msiar:Product>"
                Next

                m_xmlRule += "</" & RuleTypes.MsiFeatureInstalled.ToXmlTag() & ">"
            Case Else
                MsgBox(Globals.globalRM.GetString("error_rules_unsupported_type"))
                Me.m_readableRule = ""
                m_xmlRule = ""
        End Select

        'apply NOT to the rule
        If Me.chkNotRule.Checked Then
            Me.m_readableRule = "NOT " & Me.m_readableRule
            m_xmlRule = "<lar:Not>" & m_xmlRule & "</lar:Not>"
        End If
    End Sub

    ''' <summary>
    ''' This function returns the readable string based on the passed xml string.
    ''' </summary>
    ''' <param name="ruleXml">Rule's XML</param>
    ''' <returns>String</returns>
    Public Function GenerateReadableRuleFromXml(ruleXml As String) As String
        If LoadRule(ruleXml) Then
            Call GenerateRule()
            Return Me.m_readableRule
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' Loads the rule based on the XML string.
    ''' </summary>
    ''' <param name="ruleXml">Rule's XML</param>
    ''' <returns>Boolean indicating the XML was loaded successfully.</returns>
    Private Function LoadRule(ruleXml As String) As Boolean

        'Create the namespace and add the lar and bar namespaces.
        Dim nsmgr As XmlNamespaceManager = New XmlNamespaceManager(New NameTable())
        nsmgr.AddNamespace("lar", "http://schemas.microsoft.com/wsus/2005/04/CorporatePublishing/LogicalApplicabilityRules.xsd")
        nsmgr.AddNamespace("bar", "http://schemas.microsoft.com/wsus/2005/04/CorporatePublishing/BaseApplicabilityRules.xsd")
        nsmgr.AddNamespace("msiar", "http://schemas.microsoft.com/wsus/2005/04/CorporatePublishing/MsiApplicabilityRules.xsd")

        'Create the XmlParserContext.
        Dim context As XmlParserContext = New XmlParserContext(Nothing, nsmgr, Nothing, XmlSpace.Default)

        Try
            'Create the XmlTextReader and set whitespace handling to none.
            Dim xmlReader As XmlTextReader = New XmlTextReader(ruleXml, XmlNodeType.Element, context)
            xmlReader.WhitespaceHandling = WhitespaceHandling.None

            'Read the first element.
            xmlReader.Read()

            'See if the first element is a Not element.  If so then change the xml reader to
            ' use the InnerXML so that the surrounding Not elements are ignored.  Also
            ' set the Not checkbox accordingly.
            If xmlReader.LocalName = "Not" Then
                Me.chkNotRule.Checked = True
                xmlReader = New XmlTextReader(xmlReader.ReadInnerXml, XmlNodeType.Element, context)
                xmlReader.Read()
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
                    Me.cboEnvironmentVariable.Text = [Enum].GetName(GetType(CSIDL), Convert.ToInt32(xmlReader.GetAttribute("Csidl")))
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
                    Me.cboEnvironmentVariable.Text = [Enum].GetName(GetType(CSIDL), Convert.ToInt32(xmlReader.GetAttribute("Csidl")))
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
                    Me.cboEnvironmentVariable.Text = [Enum].GetName(GetType(CSIDL), Convert.ToInt32(xmlReader.GetAttribute("Csidl")))
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
                    Me.cboEnvironmentVariable.Text = [Enum].GetName(GetType(CSIDL), Convert.ToInt32(xmlReader.GetAttribute("Csidl")))
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
                    Me.cboEnvironmentVariable.Text = [Enum].GetName(GetType(CSIDL), Convert.ToInt32(xmlReader.GetAttribute("Csidl")))
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
                    Me.cboLanguage.Text = Languages.Name(Languages.Code(CInt(xmlReader.GetAttribute("Language"))))

                Case "MsiProductInstalled"
                    'Select the rule.
                    Me.cboRuleType.SelectedItem = RuleTypes.MsiProductInstalled

                    'Load the Data.
                    Me.txtProductCode.Text = xmlReader.GetAttribute("ProductCode")
                    Me.txtMaxVersion.Text = xmlReader.GetAttribute("VersionMax")
                    Me.txtMinVersion.Text = xmlReader.GetAttribute("VersionMin")
                    Me.cboLanguage.Text = Languages.Name(Languages.Code(CInt(xmlReader.GetAttribute("Language"))))

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
                    MsgBox(Globals.globalRM.GetString("error_rules_unrecognized") & ": " & xmlReader.LocalName.Replace("bar:", ""))
            End Select
            xmlReader.Close()

            Return True
        Catch x As XmlException
            MsgBox(Globals.globalRM.GetString("exception_XML") & ": " & Globals.globalRM.GetString("error_rules_load") & vbNewLine & x.Message)
            Return False
        Catch x As Exception
            MsgBox(Globals.globalRM.GetString("exception") & ": " & Globals.globalRM.GetString("error_rules_load") & vbNewLine & x.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Show human readable strings in the combo box.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub CboRuleTypeFormat(sender As Object, e As ListControlConvertEventArgs) Handles cboRuleType.Format
        If TypeOf e.ListItem Is RuleTypes Then
            e.Value = CType(e.ListItem, RuleTypes).ToDisplayString()
        Else
            e.Value = e.ListItem.ToString()
        End If
    End Sub
#End Region

#Region "Validation"

    ''' <summary>
    ''' The version rule demands a version in the form #.#.#.# so
    ''' this routine makes sure that the text is formatted that way.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ValidateVersion(sender As Object, e As EventArgs)
        'If this is a textbox then format it as a version string
        If TypeOf sender Is TextBox Then

            'If there's a string and it's less than 4 digits then pad with zeros
            If Not String.IsNullOrEmpty(DirectCast(sender, TextBox).Text) Then
                Dim strArray As String() = DirectCast(sender, TextBox).Text.Split("."c)

                Select Case strArray.Length
                    Case 1
                        DirectCast(sender, TextBox).Text = strArray(0) & ".0.0.0"
                    Case 2
                        DirectCast(sender, TextBox).Text = strArray(0) & "." & strArray(1) & ".0.0"
                    Case 3
                        DirectCast(sender, TextBox).Text = strArray(0) & "." & strArray(1) & "." & strArray(2) & ".0"
                    Case Else
                        DirectCast(sender, TextBox).Text = strArray(0) & "." & strArray(1) & "." & strArray(2) & "." & strArray(3)
                End Select
            End If
        End If
    End Sub
    ''' <summary>
    ''' Validate sender's GUID
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
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
    ''' <summary>
    ''' Validate the form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ValidateForm(sender As Object, e As EventArgs) Handles txtVersion.TextChanged, txtRegistryValue.TextChanged, txtRegistrySubKey.TextChanged, txtQuery.TextChanged, txtProductCode.TextChanged, txtPatchCode.TextChanged, txtOSMinorVersion.TextChanged, txtOSMajorVersion.TextChanged, txtMinVersion.TextChanged, txtMaxVersion.TextChanged, txtFilePath.TextChanged, txtData.TextChanged, gceProductCollection.ValidInputChanged, gceFeatureCollection.ValidInputChanged, gceComponentCollection.ValidInputChanged, dtpDate.ValueChanged, cboRegistryValueType.SelectedIndexChanged, cboRegistryKey.SelectedIndexChanged, cboProcessorType.SelectedIndexChanged, cboLanguage.SelectedIndexChanged, cboComparison.SelectedIndexChanged
        ValidateForm()
    End Sub

    ''' <summary>
    ''' Verify the form and set the icons accordingly.
    ''' </summary>
    Sub ValidateForm()
        Call ValidateFields()
        Call ValidateRule()
    End Sub

    ''' <summary>
    ''' Validate the individual fields.
    ''' </summary>
    Sub ValidateFields()

        If Me.cboComparison.SelectedIndex = -1 Then
            Me.errorProviderRules.SetError(Me.cboComparison, Globals.globalRM.GetString("warning_rules_comparison"))
        Else
            Me.errorProviderRules.SetError(Me.cboComparison, "")
        End If

        If String.IsNullOrEmpty(Me.txtOSMajorVersion.Text) Or String.IsNullOrEmpty(Me.txtOSMinorVersion.Text) Then
            Me.errorProviderRules.SetError(Me.txtOSMinorVersion, Globals.globalRM.GetString("warning_rules_OS"))
        Else
            Me.errorProviderRules.SetError(Me.txtOSMinorVersion, "")
        End If

        If Me.cboLanguage.SelectedIndex = -1 Then
            Select Case Me.cboRuleType.SelectedIndex
                Case RuleTypes.WindowsLanguage
                    Me.errorProviderRules.SetError(Me.cboLanguage, Globals.globalRM.GetString("warning_rules_language"))
                Case Else
                    Me.errorProviderRules.SetError(Me.cboLanguage, "")
            End Select
        Else
            Me.errorProviderRules.SetError(Me.cboLanguage, "")
        End If

        If Me.cboProcessorType.SelectedIndex = -1 Then
            Me.errorProviderRules.SetError(Me.cboProcessorType, Globals.globalRM.GetString("warning_rules_processor"))
        Else
            Me.errorProviderRules.SetError(Me.cboProcessorType, "")
        End If

        If Me.cboRegistryKey.SelectedIndex = -1 Then
            Me.errorProviderRules.SetError(Me.txtRegistrySubKey, Globals.globalRM.GetString("warning_rules_registry_key"))
        ElseIf String.IsNullOrEmpty(Me.txtRegistrySubKey.Text) Then
            Me.errorProviderRules.SetError(Me.txtRegistrySubKey, Globals.globalRM.GetString("warning_rules_registry_sub_key"))
        Else
            Me.errorProviderRules.SetError(Me.txtRegistrySubKey, "")
        End If

        If Me.cboRegistryValueType.SelectedIndex = -1 Then
            Me.errorProviderRules.SetError(Me.cboRegistryValueType, Globals.globalRM.GetString("warning_rules_registry_type"))
        Else
            Me.errorProviderRules.SetError(Me.cboRegistryValueType, "")
        End If

        If String.IsNullOrEmpty(Me.txtFilePath.Text) Then
            Me.errorProviderRules.SetError(Me.txtFilePath, Globals.globalRM.GetString("warning_rules_file_path"))
        Else
            Me.errorProviderRules.SetError(Me.txtFilePath, "")
        End If

        If String.IsNullOrEmpty(Me.txtVersion.Text) Then
            Select Case Me.cboRuleType.SelectedIndex
                Case RuleTypes.FileVersion
                    Me.errorProviderRules.SetError(Me.txtVersion, Globals.globalRM.GetString("warning_rules_version"))
                Case RuleTypes.FileVersionWithRegistry
                    Me.errorProviderRules.SetError(Me.txtVersion, Globals.globalRM.GetString("warning_rules_version"))
                Case Else
                    Me.errorProviderRules.SetError(Me.txtVersion, "")
            End Select
        Else
            Me.errorProviderRules.SetError(Me.txtVersion, "")
        End If

        'TODO: for RegDWord and RegExpandSz rule, this must be numeric
        'Set the Data field error based on the selected rule type since this field is repurposed for several rules.
        If String.IsNullOrEmpty(Me.txtData.Text) Then
            Select Case Me.cboRuleType.SelectedIndex
                Case RuleTypes.FileSize
                    Me.errorProviderRules.SetError(Me.txtData, Globals.globalRM.GetString("warning_rules_file_size"))
                Case RuleTypes.FileSizeWithRegistry
                    Me.errorProviderRules.SetError(Me.txtData, Globals.globalRM.GetString("warning_rules_file_size"))
                Case RuleTypes.RegistryDWORDValue
                    Me.errorProviderRules.SetError(Me.txtData, Globals.globalRM.GetString("warning_rules_registry_value"))
                Case RuleTypes.RegistryExpandSzValue
                    Me.errorProviderRules.SetError(Me.txtData, Globals.globalRM.GetString("warning_rules_registry_value"))
                Case RuleTypes.RegistrySzValue
                    Me.errorProviderRules.SetError(Me.txtData, Globals.globalRM.GetString("warning_rules_registry_value"))
                Case RuleTypes.WMIQuery
                    Me.errorProviderRules.SetError(Me.txtData, Globals.globalRM.GetString("warning_rules_namespace"))
                Case Else
                    Me.errorProviderRules.SetError(Me.txtData, "")
            End Select
        Else
            Me.errorProviderRules.SetError(Me.txtData, "")
        End If

        If Not Me.dtpDate.Checked Then
            Me.errorProviderRules.SetError(Me.dtpDate, Globals.globalRM.GetString("warning_rules_date"))
        Else
            Me.errorProviderRules.SetError(Me.dtpDate, "")
        End If

        If String.IsNullOrEmpty(Me.txtQuery.Text) Then
            Me.errorProviderRules.SetError(Me.txtQuery, Globals.globalRM.GetString("warning_rules_query"))
        Else
            Me.errorProviderRules.SetError(Me.txtQuery, "")
        End If

        Try
            Dim g As New Guid(Me.txtProductCode.Text)
            Me.errorProviderRules.SetError(Me.txtProductCode, "")
        Catch
            Me.errorProviderRules.SetError(Me.txtProductCode, Globals.globalRM.GetString("warning_rules_GUID"))
        End Try

        Try
            Dim g As New Guid(Me.txtPatchCode.Text)
            Me.errorProviderRules.SetError(Me.txtPatchCode, "")
        Catch
            Me.errorProviderRules.SetError(Me.txtPatchCode, Globals.globalRM.GetString("warning_rules_GUID"))
        End Try
    End Sub

    ''' <summary>
    ''' Enable or disable the Add Rule button based on current rule
    ''' and which fields are valid.  The verification looks to see if
    ''' the appropriate validation picture boxes have the proper boolean in their tag.
    ''' </summary>
    Sub ValidateRule()

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
                    btnAdd.Enabled = String.IsNullOrEmpty(Me.errorProviderRules.GetError(Me.cboRegistryKey) & Me.errorProviderRules.GetError(Me.txtRegistrySubKey) & Me.errorProviderRules.GetError(Me.txtFilePath) & Me.errorProviderRules.GetError(Me.cboComparison) & Me.errorProviderRules.GetError(Me.dtpDate))
                Case RuleTypes.FileSize
                    btnAdd.Enabled = String.IsNullOrEmpty(Me.errorProviderRules.GetError(Me.txtFilePath) & Me.errorProviderRules.GetError(Me.cboComparison) & Me.errorProviderRules.GetError(Me.txtData))
                Case RuleTypes.FileSizeWithRegistry
                    btnAdd.Enabled = String.IsNullOrEmpty(Me.errorProviderRules.GetError(Me.cboRegistryKey) & Me.errorProviderRules.GetError(Me.txtRegistrySubKey) & Me.errorProviderRules.GetError(Me.txtFilePath) & Me.errorProviderRules.GetError(Me.cboComparison) & Me.errorProviderRules.GetError(Me.txtData))
                Case RuleTypes.FileVersion
                    btnAdd.Enabled = String.IsNullOrEmpty(Me.errorProviderRules.GetError(Me.txtFilePath) & Me.errorProviderRules.GetError(Me.cboComparison) & Me.errorProviderRules.GetError(Me.txtVersion))
                Case RuleTypes.FileVersionWithRegistry
                    btnAdd.Enabled = String.IsNullOrEmpty(Me.errorProviderRules.GetError(Me.cboRegistryKey) & Me.errorProviderRules.GetError(Me.txtRegistrySubKey) & Me.errorProviderRules.GetError(Me.txtFilePath) & Me.errorProviderRules.GetError(Me.cboComparison) & Me.errorProviderRules.GetError(Me.txtVersion))
                Case RuleTypes.RegistryKeyExists
                    btnAdd.Enabled = String.IsNullOrEmpty(Me.errorProviderRules.GetError(Me.cboRegistryKey) & Me.errorProviderRules.GetError(Me.txtRegistrySubKey))
                Case RuleTypes.RegistryValueExists
                    btnAdd.Enabled = String.IsNullOrEmpty(Me.errorProviderRules.GetError(Me.cboRegistryKey) & Me.errorProviderRules.GetError(Me.txtRegistrySubKey) & Me.errorProviderRules.GetError(Me.cboRegistryValueType))
                Case RuleTypes.RegistryDWORDValue
                    btnAdd.Enabled = String.IsNullOrEmpty(Me.errorProviderRules.GetError(Me.cboRegistryKey) & Me.errorProviderRules.GetError(Me.txtRegistrySubKey) & Me.errorProviderRules.GetError(Me.cboComparison) & Me.errorProviderRules.GetError(Me.txtData))
                Case RuleTypes.RegistryExpandSzValue
                    btnAdd.Enabled = String.IsNullOrEmpty(Me.errorProviderRules.GetError(Me.cboRegistryKey) & Me.errorProviderRules.GetError(Me.txtRegistrySubKey) & Me.errorProviderRules.GetError(Me.cboComparison) & Me.errorProviderRules.GetError(Me.txtData))
                Case RuleTypes.RegistryVersionInSz
                    btnAdd.Enabled = String.IsNullOrEmpty(Me.errorProviderRules.GetError(Me.cboRegistryKey) & Me.errorProviderRules.GetError(Me.txtRegistrySubKey) & Me.errorProviderRules.GetError(Me.cboComparison) & Me.errorProviderRules.GetError(Me.txtVersion))
                Case RuleTypes.RegistrySzValue
                    btnAdd.Enabled = String.IsNullOrEmpty(Me.errorProviderRules.GetError(Me.cboRegistryKey) & Me.errorProviderRules.GetError(Me.txtRegistrySubKey) & Me.errorProviderRules.GetError(Me.cboComparison) & Me.errorProviderRules.GetError(Me.txtData))
                Case RuleTypes.WMIQuery
                    btnAdd.Enabled = String.IsNullOrEmpty(Me.errorProviderRules.GetError(Me.txtQuery) & Me.errorProviderRules.GetError(Me.txtData))
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


    ''' <summary>
    ''' Strip out reserved XML characters and deal with characters not in the 7-bit ASCII set.
    ''' </summary>
    ''' <param name="text">String to be converted.</param>
    ''' <returns>String</returns>
    ''' <remarks>'Written by Tony Proctor
    ''' Found here: http://www.codenewsgroups.net/vb/t5072-xml-escape-sequence-routine.aspx</remarks>
    Public Function StringToXML(ByVal text As String) As String
        Dim i As Integer
        Dim sCh As String
        Dim tmpString As String
        Const SKIP As Integer = 6   'Character count to skip over character entity (i.e. at least '&#nnn;')

        ' Do entity references first
        tmpString = Replace(Replace(Replace(Replace(Replace(text, "&", "&amp;"), "<", "&lt;"), ">", "&gt;"), """", "&quot;"), "'", "&apos;")

        ' Now do character entities for anything that's not 7-bit ASCII
        i = 1
        Do While i <= Len(tmpString)
            sCh = Mid$(tmpString, i, 1)
            If AscW(sCh) > 127 Then
                tmpString = Microsoft.VisualBasic.Left$(tmpString, i - 1) & "&#" & CStr(AscW(sCh)) & ";" & Microsoft.VisualBasic.Mid$(tmpString, i + 1)
                i = i + SKIP
            Else
                i = i + 1
            End If
        Loop

        Return tmpString
    End Function
#End Region

End Class
