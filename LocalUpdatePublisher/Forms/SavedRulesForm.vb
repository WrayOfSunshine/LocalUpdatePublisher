Option Explicit On
Option Strict On

Imports System.Drawing

' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' Saved Rules Form
' This form is used in multiple ways depending on the SavedRulesFormUses enumeration.
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 2/12/2010
' Time: 12:40 PM

Partial Public Class SavedRulesForm
    Private m_formUse As SavedRulesFormUses
    Private m_ruleCollection As RuleCollection = New RuleCollection

    Public Sub New()
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        Me.InitializeComponent()
    End Sub

    ''' <summary>
    ''' Show Dialog
    ''' </summary>
    ''' <param name="formUse">SavedRulesFormUses enumeration.</param>
    ''' <returns>RuleCollection</returns>
    Public Overloads Function ShowDialog(formUse As SavedRulesFormUses) As RuleCollection
        m_formUse = formUse
        dgvRules.Rows.Clear()

        Select Case m_formUse
            Case SavedRulesFormUses.Load
                Text = Globals.globalRM.GetString("select_rules_to_load")
                btnAction.Text = Globals.globalRM.GetString("load")
                btnAction.DialogResult = DialogResult.OK
                btnAction2.Text = Globals.globalRM.GetString("clear_selection")
                btnCancel.Text = Globals.globalRM.GetString("cancel")

                'Load rules from the application settings.
                For Each tmpRule As Rule In Globals.appSettings.SavedRuleCollection
                    Dim tmpRow As Integer = dgvRules.Rows.Add
                    dgvRules.Rows(tmpRow).Cells("Include").Value = False
                    dgvRules.Rows(tmpRow).Cells("RuleName").Value = tmpRule.Name
                Next

                'Create temporary Rule collection.
                Dim tmpRuleCollection As RuleCollection = New RuleCollection

                'Populate collection if the user hits Ok.
                If MyBase.ShowDialog = DialogResult.OK Then
                    'Add selected rules to temporary collection.
                    For Each tmpRow As DataGridViewRow In dgvRules.Rows
                        If DirectCast(tmpRow.Cells("Include").Value, Boolean) Then
                            tmpRuleCollection.Add(Globals.appSettings.SavedRuleCollection(tmpRow.Index))
                        End If
                    Next
                End If

                Return tmpRuleCollection
            Case SavedRulesFormUses.Manage
                Text = Globals.globalRM.GetString("select_rules_to_manage")
                btnAction.Text = Globals.globalRM.GetString("rename")
                btnAction2.Text = Globals.globalRM.GetString("delete")
                btnCancel.Text = Globals.globalRM.GetString("close")

                'Load rules from the application settings.
                For Each tmpRule As Rule In Globals.appSettings.SavedRuleCollection
                    Dim tmpRow As Integer = dgvRules.Rows.Add
                    dgvRules.Rows(tmpRow).Cells("Include").Value = False
                    dgvRules.Rows(tmpRow).Cells("RuleName").Value = tmpRule.Name
                Next

                MyBase.ShowDialog()
                Return Nothing
            Case SavedRulesFormUses.Import
                Text = Globals.globalRM.GetString("select_rules_to_import")
                btnAction.Text = Globals.globalRM.GetString("import")
                btnAction2.Text = Globals.globalRM.GetString("clear_selection")
                btnCancel.Text = Globals.globalRM.GetString("cancel")

                m_ruleCollection = RuleCollection.ImportRules

                If m_ruleCollection Is Nothing Then
                    Return Nothing
                ElseIf m_ruleCollection.Count = 0 Then
                    MsgBox(Globals.globalRM.GetString("There are no rules in the import file."))
                    Return Nothing
                End If

                'Load rules from the imported collection.
                For Each tmpRule As Rule In m_ruleCollection
                    Dim tmpRow As Integer = dgvRules.Rows.Add
                    dgvRules.Rows(tmpRow).Cells("Include").Value = False
                    dgvRules.Rows(tmpRow).Cells("RuleName").Value = tmpRule.Name
                Next

                MyBase.ShowDialog()
                Return Nothing
            Case SavedRulesFormUses.Export
                Text = Globals.globalRM.GetString("select_rules_to_export")
                btnAction.Text = Globals.globalRM.GetString("export")
                btnAction2.Text = Globals.globalRM.GetString("clear_selection")
                btnCancel.Text = Globals.globalRM.GetString("cancel")

                'Load rules from the application settings.
                For Each tmpRule As Rule In Globals.appSettings.SavedRuleCollection
                    Dim tmpRow As Integer = dgvRules.Rows.Add
                    dgvRules.Rows(tmpRow).Cells("Include").Value = False
                    dgvRules.Rows(tmpRow).Cells("RuleName").Value = tmpRule.Name
                Next

                MyBase.ShowDialog()
                Return Nothing
            Case Else
                Return Nothing
        End Select

    End Function


    ''' <summary>
    ''' Perform main action depending on current use.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub BtnActionClick(sender As Object, e As EventArgs)

        Select Case m_formUse
            Case SavedRulesFormUses.Load
                Dim tmpBool As Boolean = False

                'Add selected rules to temp collection.
                For Each tmpRow As DataGridViewRow In dgvRules.Rows
                    If DirectCast(tmpRow.Cells("Include").Value, Boolean) Then
                        tmpBool = True
                    End If
                Next

                'Make sure user has selected updates.
                If tmpBool Then
                    Me.Close() 'Close the form.
                Else
                    MsgBox(Globals.globalRM.GetString("warning_saved_rules_export"))
                End If
            Case SavedRulesFormUses.Manage
                'Loop through and rename.
                For Each tmpRow As DataGridViewRow In dgvRules.Rows

                    If DirectCast(tmpRow.Cells("Include").Value, Boolean) Then
                        Dim tmpString As String = Nothing

                        'Loop until we get a unique rule name or the user skips/cancels.
                        While True
                            If tmpString = Nothing Then
                                tmpString = InputBox(String.Format(Globals.globalRM.GetString("prompt_saved_rules_rename"), DirectCast(tmpRow.Cells("RuleName").Value, String)) & ":", Globals.globalRM.GetString("rename_rule"), _
                                Globals.globalRM.GetString("rename_rule")).Trim

                                'If user cancelled then move on.
                                If tmpString = Nothing Then Continue For
                            ElseIf Globals.appSettings.SavedRuleCollection.Contains(tmpString) Then

                                My.Forms.MessageBoxForm.Location = New Point(Me.Location.X + 100, Me.Location.Y + 100)

                                Dim result As Integer = My.Forms.MessageBoxForm.ShowDialog(String.Format(Globals.globalRM.GetString("prompt_saved_rules_rule_exists"), tmpString), _
                                    Globals.globalRM.GetString("rename"), Globals.globalRM.GetString("skip"), Globals.globalRM.GetString("cancel"))

                                If result = 1 Then 'Rename
                                    tmpString = InputBox(String.Format(Globals.globalRM.GetString("prompt_saved_rules_rename"), tmpString) & ":", Globals.globalRM.GetString("rename_rule"), tmpString).Trim

                                    'If user cancelled then move on.
                                    If tmpString = Nothing Then Continue For
                                ElseIf result = 2 Then 'Skip
                                    Continue For
                                ElseIf result = 3 Then 'Cancel
                                    Exit Sub
                                End If
                            Else
                                Globals.appSettings.SavedRuleCollection(tmpRow.Index).Name = tmpString
                                tmpRow.Cells("RuleName").Value = tmpString
                                Exit While
                            End If
                        End While 'While there is an existing rule with the same name.

                    End If
                Next
            Case SavedRulesFormUses.Import

                'Add selected rules to application settings.
                For Each tmpRow As DataGridViewRow In dgvRules.Rows
                    If DirectCast(tmpRow.Cells("Include").Value, Boolean) Then

                        'If the rule has the name of an existing record then loop until the
                        ' user provides a unique name, skips the rule, or cancels.
                        While (Globals.appSettings.SavedRuleCollection.Contains(m_ruleCollection(tmpRow.Index).Name))
                            My.Forms.MessageBoxForm.Location = New Point(Me.Location.X + 100, Me.Location.Y + 100)

                            Dim result As Integer = My.Forms.MessageBoxForm.ShowDialog(String.Format(Globals.globalRM.GetString("prompt_saved_rules_rule_exists"), m_ruleCollection(tmpRow.Index).Name), _
                                Globals.globalRM.GetString("rename"), Globals.globalRM.GetString("skip"), Globals.globalRM.GetString("cancel"))

                            If result = 1 Then 'Rename
                                Dim tmpString As String = InputBox(Globals.globalRM.GetString("rename_rule"), Globals.globalRM.GetString("rename_rule"))

                                'If we got a new name then change the rule to use it.
                                If tmpString = Nothing Then
                                    'Do nothing
                                Else
                                    m_ruleCollection(tmpRow.Index).Name = tmpString
                                    tmpRow.Cells("RuleName").Value = tmpString
                                End If
                            ElseIf result = 2 Then 'Skip
                                Continue For
                            ElseIf result = 3 Then 'Cancel
                                Exit Sub
                            End If

                        End While 'While there is an existing rule with the same name.

                        'Add the row.
                        Globals.appSettings.SavedRuleCollection.Add(m_ruleCollection(tmpRow.Index))

                    End If 'If checked.
                Next 'Loop through DGV.
                Me.Close()
            Case SavedRulesFormUses.Export
                Dim tmpRuleCollection As RuleCollection = New RuleCollection

                'Add selected rules to temporary collection.
                For Each tmpRow As DataGridViewRow In dgvRules.Rows
                    If DirectCast(tmpRow.Cells("Include").Value, Boolean) Then
                        tmpRuleCollection.Add(Globals.appSettings.SavedRuleCollection(tmpRow.Index))
                    End If
                Next

                'Make sure user has selected updates.
                If tmpRuleCollection.Count = 0 Then
                    MsgBox("error_saved_rules_export")
                Else
                    'Save the temporary collection to a file.
                    RuleCollection.ExportRules(tmpRuleCollection)
                    Me.Close()
                End If
        End Select
    End Sub

    ''' <summary>
    ''' Perform secondary action depending on current use.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub BtnAction2Click(sender As Object, e As EventArgs)
        Select Case m_formUse
            Case SavedRulesFormUses.Load
                'Clear rule selection.
                For Each tmpRow As DataGridViewRow In dgvRules.Rows
                    tmpRow.Cells("Include").Value = False
                Next
            Case SavedRulesFormUses.Manage
                Dim selectedCount As Integer = 0

                'Count the number of rows selected.
                For Each tmpRow As DataGridViewRow In dgvRules.Rows
                    If DirectCast(tmpRow.Cells("Include").Value, Boolean) Then
                        selectedCount += 1
                    End If
                Next

                If selectedCount = 0 Then
                    MsgBox(Globals.globalRM.GetString("warning_saved_rules_delete"))
                Else
                    'Prompt the user to confirm deletion
                    If MsgBox(Globals.globalRM.GetString("prompt_saves_rules_delete"), MsgBoxStyle.YesNo) = DialogResult.Yes Then

                        'Loop backwards to avoid changing indices.
                        For i As Integer = dgvRules.Rows.Count - 1 To 0 Step -1
                            If DirectCast(dgvRules.Rows(i).Cells("Include").Value, Boolean) Then
                                Globals.appSettings.SavedRuleCollection.RemoveAt(i)
                                dgvRules.Rows.RemoveAt(i)
                            End If
                        Next
                    End If
                End If

            Case SavedRulesFormUses.Import
                'Clear rule selection.
                For Each tmpRow As DataGridViewRow In dgvRules.Rows
                    tmpRow.Cells("Include").Value = False
                Next
            Case SavedRulesFormUses.Export
                'Clear rule selection.
                For Each tmpRow As DataGridViewRow In dgvRules.Rows
                    tmpRow.Cells("Include").Value = False
                Next
        End Select
    End Sub
End Class
