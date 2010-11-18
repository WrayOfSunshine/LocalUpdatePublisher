' PrerequisiteUpdatesForm allows the user to view and manage the list of packages required for the current package.
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 3/25/2010
' Time: 11:44 AM
'
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'

Imports Microsoft.UpdateServices.Administration

Public Partial Class PrerequisiteUpdatesForm
	Private _prerequisiteGroups As IList(Of PrerequisiteGroup)
	Private _currentUpdate As Guid
	
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		'Initialize the current update.
		_currentUpdate = New Guid
	End Sub
	
	'Show form with prerequisites based on the passed in update.
	Public Overloads Function ShowDialog(update As IUpdate ) As DialogResult
		'Hide the Remove/Add buttons.
		btnRemove.Visible = False
		btnAdd.Visible = False
		btnOk.Enabled = False
		
		'Set the current update id we are working on.
		_currentUpdate = update.Id.UpdateId
						
		'Load the prerequisite updates here.
		dgvUpdates.Rows.Clear
		For Each tmpUpdate As IUpdate In update.GetRelatedUpdates( UpdateRelationship.UpdatesRequiredByThisUpdate)
			Dim tmpRow As Integer = dgvUpdates.Rows.Add
			dgvUpdates.Rows(tmpRow).Cells("Id").Value = tmpUpdate.Id.UpdateId
			dgvUpdates.Rows(tmpRow).Cells("Title").Value = tmpUpdate.Title
		Next
		
		Return MyBase.ShowDialog()		
	End Function
	
	'Show form with prerequisites based on the passed in prerequisite group.
	Public Overloads Function ShowDialog(ByRef prerequisiteGroups As IList(Of PrerequisiteGroup), currentUpdate As Guid  ) As DialogResult
		_prerequisiteGroups = prerequisiteGroups
		
		'Show the Remove/Add buttons.
		btnRemove.Visible = True
		btnAdd.Visible = True
		btnOK.Enabled = True
		
		'Set the current update id we are working on.
		_currentUpdate = currentUpdate
		
		'Load the prerequisite updates here.
		dgvUpdates.Rows.Clear		
		For Each tmpPrerequisiteGroup As PrerequisiteGroup In _prerequisiteGroups
			For Each tmpUpdateGuid As Guid In tmpPrerequisiteGroup.Ids
				Dim tmpRow As Integer = dgvUpdates.Rows.Add
				dgvUpdates.Rows(tmpRow).Cells("Id").Value = tmpUpdateGuid
				dgvUpdates.Rows(tmpRow).Cells("Title").Value = ConnectionManager.CurrentServer.GetUpdate(New UpdateRevisionId(tmpUpdateGuid)).Title
			Next
		Next
		
		Return MyBase.ShowDialog()		
	End Function
	
	'Prompt the user to add an update to the list.
	Sub BtnAddClick(sender As Object, e As EventArgs)
		UpdateSelectionForm.Location = New Point(Me.Location.X + 100 , Me.Location.Y + 100)
		Dim tmpUpdateRevisionId As UpdateRevisionId = UpdateSelectionForm.ShowDialog(_currentUpdate)
		Dim tmpString As String = ""
		
		If Not tmpUpdateRevisionId Is Nothing Then
			Try
				tmpString = ConnectionManager.CurrentServer.GetUpdate(tmpUpdateRevisionId).Title
			Catch x As WsusInvalidDataException
				Msgbox ("Could not add or find GUID:" & vbNewline & _
					"WsusInvalidDataException: " & x.Message)
				Exit Sub
			Catch x As WsusObjectNotFoundException
				Msgbox ("Could not add or find GUID:" & vbNewline & _
					"WsusObjectNotFoundException: " & x.Message)
				Exit Sub
			End Try
			
			Dim tmpRow As Integer = dgvUpdates.Rows.Add
			dgvUpdates.Rows(tmpRow).Cells("Id").Value = tmpUpdateRevisionId.UpdateId
			dgvUpdates.Rows(tmpRow).Cells("Title").Value = tmpString
			dgvUpdates.Refresh
			
			'Select the added cell.
			dgvUpdates.CurrentCell = dgvUpdates.Rows(tmpRow).Cells("Title")
		End If
	End Sub
	
	'If there is a current row, delete it.
	Sub BtnRemoveClick(sender As Object, e As EventArgs)
		If Not dgvUpdates.CurrentRow Is Nothing Then
			dgvUpdates.Rows.Remove(dgvUpdates.CurrentRow)
		End If
	End Sub
	
	'Save the changes and close the form.
	Sub BtnOkClick(sender As Object, e As EventArgs)
		Dim tmpPrerequisiteGroup As PrerequisiteGroup
		
		'Clear the list.
		_prerequisiteGroups.Clear
		
		'If there are prerequisites, then add them to a temp group
		' and add them to the list of groups
		If Me.dgvUpdates.Rows.Count > 0 Then
			tmpPrerequisiteGroup = New PrerequisiteGroup
			
			'Loop through the DGV and add the IDs to the temp group.
			For Each tmpRow As DataGridViewRow In Me.dgvUpdates.Rows
				tmpPrerequisiteGroup.Ids.Add(DirectCast(TmpRow.Cells("Id").Value, Guid))
			Next
			
			'Add the temp group to the IList of groups.
			_prerequisiteGroups.Add(tmpPrerequisiteGroup)
		End If
	End Sub
End Class
