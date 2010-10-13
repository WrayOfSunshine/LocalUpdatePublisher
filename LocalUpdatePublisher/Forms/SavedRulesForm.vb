﻿' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' Saved Rules Form
' This form is used in multiple ways depending on the SavedRulesFormUses enumeration.
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 2/12/2010
' Time: 12:40 PM

Public Partial Class SavedRulesForm
	Private _formUse As SavedRulesFormUses
	Private Dim _ruleCollection As RuleCollection = New RuleCollection
	
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
	End Sub
	
	'Call ShowDialog.
	Public Overloads Function ShowDialog(formUse As SavedRulesFormUses) As RuleCollection
		_formUse = formUse
		dgvRules.Rows.Clear
		
		Select Case _formUse
			Case SavedRulesFormUses.Load
				Text = "Select Rules to Load"
				btnAction.Text = "Load"
				btnAction.DialogResult = DialogResult.OK
				btnAction2.Text = "Clear Selection"
				
				'Load rules from the application settings.
				For Each tmpRule As Rule In appSettings.SavedRuleCollection
					Dim tmpRow As Integer = dgvRules.Rows.Add
					dgvRules.Rows(tmpRow).Cells("RuleName").Value = tmpRule.Name
				Next
												
				'Create temporary Rule collection.
				Dim tmpRuleCollection As RuleCollection = New RuleCollection
				
				'Populate collection if the user hits Ok.
				If MyBase.ShowDialog = DialogResult.OK Then
					'Add selected rules to temporary collection.
					For Each tmpRow As DataGridViewRow In dgvRules.Rows
						If DirectCast(tmpRow.Cells("Include").Value, Boolean) Then
							tmpRuleCollection.Add(appSettings.SavedRuleCollection(tmpRow.Index))
						End If
					Next
				End If
				
				Return tmpRuleCollection				
			Case SavedRulesFormUses.Manage
				Text = "Select Rules to Manage"
				btnAction.Text = "Rename"
				btnAction2.Text = "Delete"
				
				'Load rules from the application settings.
				For Each tmpRule As Rule In appSettings.SavedRuleCollection
					Dim tmpRow As Integer = dgvRules.Rows.Add
					dgvRules.Rows(tmpRow).Cells("RuleName").Value = tmpRule.Name
				Next
				
				MyBase.ShowDialog
				Return Nothing
			Case SavedRulesFormUses.Import
				Text = "Select Rules to Import"
				btnAction.Text = "Import"
				btnAction2.Text = "Clear Selection"
				
				_ruleCollection = RuleCollection.ImportRules
				
				If _ruleCollection Is Nothing Then
					Return Nothing
				Else If _ruleCollection.Count = 0 Then
					Msgbox ("There are no rules in the import file.")
					Return Nothing
				End If
				
				'Load rules from the imported collection.
				For Each tmpRule As Rule In _ruleCollection
					Dim tmpRow As Integer = dgvRules.Rows.Add
					dgvRules.Rows(tmpRow).Cells("RuleName").Value = tmpRule.Name
				Next
				
				MyBase.ShowDialog
				Return Nothing
			Case SavedRulesFormUses.Export
				Text = "Select Rules to Export"
				btnAction.Text = "Export"
				btnAction2.Text = "Clear Selection"
				
				'Load rules from the application settings.
				For Each tmpRule As Rule In appSettings.SavedRuleCollection
					Dim tmpRow As Integer = dgvRules.Rows.Add
					dgvRules.Rows(tmpRow).Cells("RuleName").Value = tmpRule.Name
				Next
				
				MyBase.ShowDialog
				Return Nothing
			Case Else
				Return Nothing
		End Select
		
	End Function
	
	
	'Perform main action depending on current use.
	Sub BtnActionClick(sender As Object, e As EventArgs)
		
		Select Case _formUse
			Case SavedRulesFormUses.Load
				Dim tmpBool As Boolean = False
				
				'Add selected rules to temp collection.
				For Each tmpRow As DataGridViewRow In dgvRules.Rows
					If DirectCast(tmpRow.Cells(0).Value, Boolean) Then
						tmpBool = True
					End If
				Next
				
				'Make sure user has selected updates.
				If tmpBool Then
					Me.Close 'Close the form.
				Else
					Msgbox ("You have not selected any rules to export.")
				End If
			Case SavedRulesFormUses.Manage
				'Loop through and rename.
				For Each tmpRow As DataGridViewRow In dgvRules.Rows
					If DirectCast(tmpRow.Cells(0).Value, Boolean) Then
						Dim tmpString As String = Nothing
						
						'Loop until we get a unique rule name or the user skips/cancels.
						While True
							If tmpString = Nothing Then
								tmpString = InputBox("Change " & DirectCast(tmpRow.Cells(1).Value, String) & " to:","Rename Rule", DirectCast(tmpRow.Cells(1).Value, String)).Trim
								
								'If user cancelled then move on.
								If tmpString = Nothing Then Continue For
							Else If appSettings.SavedRuleCollection.Contains(tmpString) Then
								
								My.Forms.MessageBoxForm.Location = New Point ( Me.Location.X + 100, Me.Location.Y + 100)
								
								Dim result As Integer = My.Forms.MessageBoxForm.ShowDialog("There is already a rule called " & _
									tmpString & vbNewLine & "What would you like to do?", _
									"Rename", "Skip" , "Cancel")
								
								If result = 1 Then 'Rename
									tmpString = InputBox("Change " & tmpString & " to:","Rename Rule", tmpString).Trim
									
									'If user cancelled then move on.
									If tmpString = Nothing Then Continue For
								Else If result = 2 Then 'Skip
									Continue For
								Else If result = 3 'Cancel
									Exit Sub
								End If
							Else
								appSettings.SavedRuleCollection(tmpRow.Index).Name = tmpString
								tmpRow.Cells(1).Value = tmpString
								Exit While
							End If
						End While 'While there is an existing rule with the same name.
						
					End If
				Next
			Case SavedRulesFormUses.Import
				
				'Add selected rules to application settings.
				For Each tmpRow As DataGridViewRow In dgvRules.Rows
					If DirectCast(tmpRow.Cells(0).Value, Boolean) Then
						
						'If the rule has the name of an existing record then loop until the
						' user provides a unique name, skips the rule, or cancels.
						While (appSettings.SavedRuleCollection.Contains(_ruleCollection(tmpRow.Index).Name))
							My.Forms.MessageBoxForm.Location = New Point ( Me.Location.X + 100, Me.Location.Y + 100)
							
							Dim result As Integer = My.Forms.MessageBoxForm.ShowDialog("There is already a rule called " & _
								_ruleCollection(tmpRow.Index).Name & vbNewLine & "What would you like to do?", _
								"Rename", "Skip" , "Cancel")
							
							If result = 1 Then 'Rename
								Dim tmpString As String = InputBox("Rename the rule","Rename Rule")
								
								'If we got a new name then change the rule to use it.
								If tmpString = Nothing Then
									'Do nothing
								Else
									_ruleCollection(tmpRow.Index).Name = tmpString
									tmpRow.Cells(1).Value = tmpString
								End If
							Else If result = 2 Then 'Skip
								Continue For
							Else If result = 3 'Cancel
								Exit Sub
							End If
							
						End While 'While there is an existing rule with the same name.
						
						'Add the row.
						appSettings.SavedRuleCollection.Add(_ruleCollection(tmpRow.Index))
						
					End If 'If checked.
				Next 'Loop through DGV.
				Me.Close
			Case SavedRulesFormUses.Export
				Dim tmpRuleCollection As RuleCollection = New RuleCollection
				
				'Add selected rules to temporary collection.
				For Each tmpRow As DataGridViewRow In dgvRules.Rows
					If DirectCast(tmpRow.Cells(0).Value, Boolean) Then
						tmpRuleCollection.Add(appSettings.SavedRuleCollection(tmpRow.Index))
					End If
				Next
				
				'Make sure user has selected updates.
				If tmpRuleCollection.Count = 0 Then
					Msgbox ("You have not selected any rules to export.")
				Else
					'Save the temporary collection to a file.
					RuleCollection.ExportRules(tmpRuleCollection)
					Me.Close
				End If
		End Select
	End Sub
	
	'Perform secondary action depending on current use.
	Sub BtnAction2Click(sender As Object, e As EventArgs)
		Select Case _formUse
			Case SavedRulesFormUses.Load
				'Clear rule selection.
				For Each tmpRow As DataGridViewRow In dgvRules.Rows
					tmpRow.Cells(0).Value = False
				Next
			Case SavedRulesFormUses.Manage
				Dim selectedCount As Integer = 0
				
				'Count the number of rows selected.
				For Each tmpRow As DataGridViewRow In dgvRules.Rows
					If DirectCast(tmpRow.Cells(0).Value, Boolean) Then
						selectedCount += 1
					End If
				Next
				
				If selectedCount = 0 Then
					Msgbox ("You must select records for deletion.")
				Else
					'Prompt the user to confirm deletion
					If Msgbox("Are you sure you want to delete the selected rules?", MsgBoxStyle.YesNo) = DialogResult.Yes Then
						
						'Loop backwards to avoid changing indices.
						For i As Integer = dgvRules.Rows.Count - 1 To 0 Step -1
							If DirectCast(dgvRules.Rows(i).Cells(0).Value, Boolean) Then
								appSettings.SavedRuleCollection.RemoveAt(i)
								dgvRules.Rows.RemoveAt(i)
							End If
						Next
					End If
				End If
				
			Case SavedRulesFormUses.Import
				'Clear rule selection.
				For Each tmpRow As DataGridViewRow In dgvRules.Rows
					tmpRow.Cells(0).Value = False
				Next
			Case SavedRulesFormUses.Export
				'Clear rule selection.
				For Each tmpRow As DataGridViewRow In dgvRules.Rows
					tmpRow.Cells(0).Value = False
				Next
		End Select
	End Sub
End Class
