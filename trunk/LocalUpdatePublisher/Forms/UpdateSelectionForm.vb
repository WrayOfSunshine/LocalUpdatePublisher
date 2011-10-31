'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 3/25/2010
' Time: 10:02 AM
'
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports Microsoft.UpdateServices.Administration

Public Partial Class UpdateSelectionForm
	Private _currentUpdate As Guid
	
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
	End Sub
	
	
	'Show the dialog and hide the current update.
	Public Overloads Function ShowDialog(currentUpdate As Guid) As UpdateCollection
		_currentUpdate = currentUpdate		
		Call UpdateVendors
		
		'If no row is currently selected return nothing.  Otherwise
		' return the selected update revision Id.
		If MyBase.ShowDialog() = DialogResult.Cancel OrElse dgvUpdates.SelectedRows.Count = 0 Then
			Return New UpdateCollection
		Else
			Return GetUpdateCollection
		End If
		
	End Function
	
	
	'Overloaded show dialog function that returns the update revision id.
	Public Overloads Function ShowDialog() As UpdateCollection
		cboVendor.SelectedIndex = -1
		dgvUpdates.DataSource = Nothing
		Call UpdateVendors
		
		
		'If no row is currently selected return nothing.  Otherwise
		' return the selected update revision Id.
		If MyBase.ShowDialog() = DialogResult.Cancel OrElse dgvUpdates.SelectedRows.Count = 0 Then
			Return New UpdateCollection
		Else
			Return GetUpdateCollection
		End If
		
	End Function
	
	Private Sub UpdateVendors()
		cboVendor.Items.Clear
		
		'Add the custom GUID option to the combo box.
		cboVendor.Items.Add(globalRM.GetString("custom_GUID"))
		
		'If the update node is instantiated, load the vendor dropdown.
		'cboVendor.Items.Clear
		If Not My.Forms.MainForm.UpdateNode Is Nothing Then
			For Each tmpNode As TreeNode In My.Forms.MainForm.UpdateNode.Nodes
				If Not tmpNode.Tag Is Nothing AndAlso TypeOf(tmpNode.Tag) Is IUpdateCategory Then
					cboVendor.Items.Add(New ComboVendors(DirectCast(tmpNode.Tag, IUpdateCategory)))
				End If
			Next
		End If
	End Sub
	
	Private Function GetUpdateCollection As UpdateCollection
		Dim tmpUpdateCollection As UpdateCollection = New UpdateCollection
		For Each tmpRow As DataGridViewRow In dgvUpdates.SelectedRows
			tmpUpdateCollection.Add(DirectCast(tmpRow.Cells("IUpdate").Value, IUpdate))
		Next
		Return tmpUpdateCollection
	End Function
	
	'Update the DGV to list the correct updates.
	Sub CboVendorSelectedIndexChanged(sender As Object, e As EventArgs)
		
		'If the user chooses a custom GUID then prompt for that GUID
		' and loop until they enter one or cancel.  If the custom
		' GUID is taken exit the dialog when finished.
		If cboVendor.Text = globalRM.GetString("custom_GUID") Then
			
			'Loop until user provides a valid GUID or exits.
			Dim tmpGuid As String = ""
			While Not ValidateGuid(tmpGuid)
				tmpGuid = InputBox(globalRM.GetString("prompt_update_selection_GUID") & ":", globalRM.GetString("prompt_update_selection_GUID_title"),tmpGuid)
				If String.IsNullOrEmpty(tmpGuid) Then Exit While
			End While
			
			'If the GUID string is empty then exit the dialog, otherwise
			'add the GUID to the dgv so it can be returned.
			If String.IsNullOrEmpty(tmpGuid) Then
				Me.DialogResult = DialogResult.Cancel
			Else
				'Load the list of updates for this vendor.
				dgvUpdates.DataSource = GetUpdate( New UpdateRevisionId( New Guid(tmpGuid)))
			End If
			
		Else If Not cboVendor.SelectedIndex = -1
			'Load the list of updates for this vendor.
			dgvUpdates.DataSource = GetUpdateList( DirectCast(cboVendor.SelectedItem, ComboVendors).Value, _currentUpdate )
		End If
		
		'Now hide the columns we don't want.
		For Each tmpColumn As DataGridViewColumn In dgvUpdates.Columns
			If Not tmpColumn.Name = "Title" Then
				tmpColumn.Visible = False
			End If
		Next
		
		'If rows are show, select the first.
		If dgvUpdates.Rows.Count > 0 Then
			btnSelect.Enabled = True
			dgvUpdates.CurrentCell = dgvUpdates.Rows(0).Cells("Title")
		Else
			btnSelect.Enabled = False
		End If
		
	End Sub
	
	'Verifies and formats the passed in string as a GUID.
	Private Function ValidateGuid(ByRef guidString As String) As Boolean
		Try
			Dim g As New Guid(guidString)
			guidString = g.ToString
			Return True
		Catch
			Return False
		End Try
	End Function
	
	Sub DgvUpdatesCellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs)
		Me.DialogResult = DialogResult.OK
		Me.Close
	End Sub
	
End Class
