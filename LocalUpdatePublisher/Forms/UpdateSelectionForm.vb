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
	Private CUSTOMGUID As String = "Custom GUID"
	
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		'Add the custom GUID option to the combo box.
		cboVendor.Items.Add(CUSTOMGUID)		
		
		'If the update node is instantiated, load the vendor dropdown.
		'cboVendor.Items.Clear
		If Not My.Forms.MainForm.UpdateNode Is Nothing Then
			For Each tmpNode As TreeNode In My.Forms.MainForm.UpdateNode.Nodes
				cboVendor.Items.Add(New ComboVendors(DirectCast(tmpNode.Tag, IUpdateCategory)))
			Next
		End If
	End Sub
	
	'Overloaded show dialog function that returns the update revision id.
	Public Overloads Function ShowDialog() As UpdateRevisionId
		cboVendor.SelectedIndex = -1
		dgvUpdates.DataSource = Nothing
		
		MyBase.ShowDialog()
		
		'If no row is currently selected return nothing.  Otherwise
		' return the selected update revision Id.
		If dgvUpdates.CurrentRow Is Nothing Then
			Return Nothing
		Else
			Return DirectCast(dgvUpdates.CurrentRow.Cells("Id").Value, UpdateRevisionID)
		End If
		
	End Function
	
	
	'Update the DGV to list the correct updates.
	Sub CboVendorSelectedIndexChanged(sender As Object, e As EventArgs)
		
		'If the user choses a custom GUID then prompt for that GUID
		' and loop until they enter one or cancel.  If the custom
		' GUID is taken exit the dialog when finished.
		If cboVendor.Text = CUSTOMGUID Then
			
			'Loop until user provides a valid GUID or exits.
			Dim tmpGuid As String = ""
			While Not ValidateGuid(tmpGuid)
				tmpGuid = InputBox("Enter the GUID you would like to use:", "Custom GUID Entry",tmpGuid)
				If String.IsNullOrEmpty(tmpGuid) Then Exit While
			End While
			
			'If the GUID string is empty then exit the dialog, otherwise 
			'add the GUID to the dgv so it can be returned.
			If String.IsNullOrEmpty(tmpGuid) Then
				Me.DialogResult = DialogResult.Cancel
			Else
				'Setup the dgv and add the Id column.
				dgvUpdates.DataSource = Nothing
				dgvUpdates.Columns.Add("Id", "Id")
				
				'Add the custom GUID to a new row.
				Dim tmpRow As Integer = dgvUpdates.Rows.Add
				dgvUpdates.Rows(tmpRow).Cells("Id").Value = New UpdateRevisionId( New Guid( tmpGuid ))
				dgvUpdates.CurrentCell = dgvUpdates.Rows(tmpRow).Cells("Id")
				
				'Close the dialog.
				Me.DialogResult = DialogResult.OK
			End If
		Else If Not cboVendor.SelectedIndex = -1
			'Load the list of udpates for this vendor.			
			dgvUpdates.DataSource = GetUpdateList( DirectCast(cboVendor.SelectedItem, ComboVendors).Value )
			
			'Now hide the rows we don't want.
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
	
End Class
