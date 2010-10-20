'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 3/25/2010
' Time: 11:44 AM
'
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'

Imports Microsoft.UpdateServices.Administration

Public Partial Class PrerequisiteUpdatesForm
	
	'Get the collection of prerequisites.
	Public ReadOnly Property GetUpdates() As DataGridViewRowCollection
		Get
			Return dgvUpdates.Rows
		End Get
	End Property
	
	'Get the number of prerequisites.
	Public ReadOnly Property GetUpdateCount() As Integer
		Get
			Return dgvUpdates.Rows.Count
		End Get
	End Property
	
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
	End Sub
	
	'Show form without loading any updates.
	Public Overloads Function ShowDialog() As DialogResult
		'Show the Remove/Add buttons.
		btnRemove.Visible = True
		btnAdd.Visible = True
		
		Return MyBase.ShowDialog()
	End Function
	
	'Show form with prerequisites based on the passed in update.
	Public Overloads Function ShowDialog(update As IUpdate ) As DialogResult
		'Hide the Remove/Add buttons.
		btnRemove.Visible = False
		btnAdd.Visible = False
				
		dgvUpdates.Rows.Clear
		
		'Load the superceded updates here.
		For Each tmpUpdate As IUpdate In update.GetRelatedUpdates( UpdateRelationship.UpdatesRequiredByThisUpdate)
			Dim tmpRow As Integer = dgvUpdates.Rows.Add
			dgvUpdates.Rows(tmpRow).Cells("Id").Value = tmpUpdate.Id.UpdateId
			dgvUpdates.Rows(tmpRow).Cells("Title").Value = tmpUpdate.Title
		Next
		
		Return MyBase.ShowDialog()
		
	End Function
	
	'Show form with prerequisites based on the passed in prerequisite group.
	Public Overloads Function ShowDialog(prerequisiteGroups As IList(Of PrerequisiteGroup) ) As DialogResult
		'Show the Remove/Add buttons.
		btnRemove.Visible = True
		btnAdd.Visible = True
		
		dgvUpdates.Rows.Clear
		
		'Load the prerequisite updates here.
		For Each tmpUpdateGuid As Guid In prerequisiteGroups.Item(0).Ids
			Dim tmpRow As Integer = dgvUpdates.Rows.Add
			dgvUpdates.Rows(tmpRow).Cells("Id").Value = tmpUpdateGuid
			dgvUpdates.Rows(tmpRow).Cells("Title").Value = ConnectionManager.CurrentServer.GetUpdate(New UpdateRevisionId(tmpUpdateGuid)).Title
		Next
		
		Return MyBase.ShowDialog()
		
	End Function
	
	Sub BtnAddClick(sender As Object, e As EventArgs)
		UpdateSelectionForm.Location = New Point(Me.Location.X + 100 , Me.Location.Y + 100)
		Dim tmpUpdateRevisionId As UpdateRevisionId = UpdateSelectionForm.ShowDialog
		Dim tmpString As String = ""
		
		If Not tmpUpdateRevisionId Is Nothing Then			
			Try				
				tmpString = ConnectionManager.CurrentServer.GetUpdate(tmpUpdateRevisionId).Title
			Catch x As WsusInvalidDataException
				Msgbox ("Could not add custom GUID:" & vbNewline & _
					"WsusInvalidDataException: " & x.Message)
				Exit Sub
			Catch x As WsusObjectNotFoundException
				Msgbox ("Could not add custom GUID:" & vbNewline & _
					"WsusObjectNotFoundException: " & x.Message)
				Exit Sub
			End Try
			
			Dim tmpRow As Integer = dgvUpdates.Rows.Add
			dgvUpdates.Rows(tmpRow).Cells("Id").Value = tmpUpdateRevisionId.UpdateId
			dgvUpdates.Rows(tmpRow).Cells("Title").Value = tmpString
			dgvUpdates.Refresh
		End If
	End Sub
	
	'If there is a current row, delete it.
	Sub BtnRemoveClick(sender As Object, e As EventArgs)
		If Not dgvUpdates.CurrentRow Is Nothing Then
			dgvUpdates.Rows.Remove(dgvUpdates.CurrentRow)
		End If
	End Sub
End Class
