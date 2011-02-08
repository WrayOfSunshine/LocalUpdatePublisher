' SupersededUpdatesForm allows the user to view and manage the list of packages superseded by the current package.
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 3/25/2010
' Time: 11:44 AM
'
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'

Imports Microsoft.UpdateServices.Administration

Public Partial Class SupersededUpdatesForm
	Private _updateGuids As IList(Of Guid)
	Private _currentUpdate As Guid
	
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		'Initialize the current update.
		_currentUpdate = New Guid
	End Sub
	
	'Show dialog with superseded updates based on the passed in update.
	Public Overloads Function ShowDialog(update As IUpdate ) As DialogResult
		'Hide the Remove/Add buttons.
		btnRemove.Visible = False
		btnAdd.Visible = False
		btnOk.Enabled = False
		
		'Set the current update id we are working on.
		_currentUpdate = update.Id.UpdateId
		
		If update.HasSupersededUpdates Then
			dgvUpdates.Rows.Clear
			
			'Load the superseded updates here.
			For Each tmpUpdate As IUpdate In update.GetRelatedUpdates( UpdateRelationship.UpdatesSupersededByThisUpdate)
				Dim tmpRow As Integer = dgvUpdates.Rows.Add
				dgvUpdates.Rows(tmpRow).Cells("Title").Value = tmpUpdate.Title
			Next
			
			Return MyBase.ShowDialog()
		Else
			Return Nothing
		End If
	End Function
	
	'Show dialog with superseded updates based on the passed in list of update Guids.
	Public Overloads Function ShowDialog(ByRef updateGuids As IList( Of Guid), currentUpdate As Guid ) As Windows.Forms.DialogResult
		Dim tmpTitle As String
		_updateGuids = updateGuids
		
		'Show the Remove/Add buttons.
		btnRemove.Visible = True
		btnAdd.Visible = True
		btnOk.Enabled = True
		
		'Set the current update id we are working on.
		_currentUpdate = currentUpdate
		
		dgvUpdates.Rows.Clear
		
		'Load the superseded updates here.
		For Each tmpUpdateGuid As Guid In _updateGuids
			Dim tmpRow As Integer = dgvUpdates.Rows.Add
			dgvUpdates.Rows(tmpRow).Cells("Id").Value = tmpUpdateGuid
			
			Try
				tmpTitle = ConnectionManager.CurrentServer.GetUpdate(New UpdateRevisionId(tmpUpdateGuid)).Title
			Catch
				tmpTitle = globalRM.GetString("unknown")
			End Try
			
			dgvUpdates.Rows(tmpRow).Cells("Title").Value = tmpTitle
		Next
		
		Return MyBase.ShowDialog()
	End Function
	
	'Prompt the user to add an update to the list.
	Sub BtnAddClick(sender As Object, e As EventArgs)
		UpdateSelectionForm.Location = New Point(Me.Location.X + 100 , Me.Location.Y + 100)
		Dim tmpUpdateRevisionId As UpdateRevisionId = UpdateSelectionForm.ShowDialog(_currentUpdate)
		Dim tmpTitle As String
		
		If Not tmpUpdateRevisionId Is Nothing Then
			Try
				tmpTitle = ConnectionManager.CurrentServer.GetUpdate(tmpUpdateRevisionId).Title
			Catch x As WsusInvalidDataException
				Msgbox (globalRM.GetString("warning_GUID_not_found") & ":" & vbNewline & _
					globalRM.GetString("exception_wsus_invalid_data") & ": " & x.Message)
				Exit Sub
			Catch x As WsusObjectNotFoundException
				Msgbox (globalRM.GetString("warning_GUID_not_found") & ":" & vbNewline & _
					globalRM.GetString("exception_wsus_object_not_found") & ": " & x.Message)
				Exit Sub
			End Try
			
			Dim tmpRow As Integer = dgvUpdates.Rows.Add
			dgvUpdates.Rows(tmpRow).Cells("Id").Value = tmpUpdateRevisionId.UpdateId
			dgvUpdates.Rows(tmpRow).Cells("Title").Value = tmpTitle
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
	
	Sub BtnOkClick(sender As Object, e As EventArgs)
		'Clear the list.
		_updateGuids.Clear
		
		'Add the superseded updates.
		For Each tmpRow As DataGridViewRow In Me.dgvUpdates.Rows
			_updateGuids.Add(DirectCast(tmpRow.Cells("Id").Value, Guid))
		Next
	End Sub
	
End Class
