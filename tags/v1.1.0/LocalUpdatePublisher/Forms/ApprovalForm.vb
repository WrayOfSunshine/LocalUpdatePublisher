﻿' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' UpdateApprovalForm
' This form displays the current update's approval for each target group.
' It also allows the user to change the approval.
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 11/6/2009
' Time: 2:55 PM

Imports Microsoft.UpdateServices.Administration

Public Partial Class ApprovalForm
	Private _selectedRows As DataGridViewSelectedRowCollection
	Private _selectedUpdate As IUpdate
	Private _multipleUpdates As Boolean
	
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		'Prevent the form from being sized too small.
		Me.MinimumSize = Me.Size
		
		'Localize the data grid view
		For Each colTemp As DataGridViewColumn In Me.dgvApprovals.Columns
			colTemp.HeaderText = globalRM.GetString(colTemp.Name)
		Next
	End Sub
	
	'Call ShowDialog
	Public Overloads Function ShowDialog( selectedRows As DataGridViewSelectedRowCollection) As DialogResult
		
		
		'Set label and multiple updates flag and initialize the private members.
		If selectedRows.Count > 1 Then
			Me._multipleUpdates = True
			Me._selectedRows = selectedRows
			Me.lblInfo.Text = String.Format(globalRM.GetString("label_approval_form_multiple"), selectedRows.Count)
		Else
			Me._multipleUpdates = False
			Me._selectedUpdate = DirectCast(selectedRows(0).Cells("IUpdate").Value, IUpdate) 'Get IUpdate object from first and only row.
			Me.lblInfo.Text = String.Format(globalRM.GetString("label_approval_form"), _selectedUpdate.Title)
		End If
		
		'Set defaults for buttons
		Me.btnOK.DialogResult = Nothing
		Me.btnCancel.Enabled = True
		
		Call LoadData()
		
		Return MyBase.ShowDialog
	End Function
	
	
	'When the form closes, clear the datagridview.
	Private Sub UpdateApprovalFormFormClosed(sender As Object, e As FormClosedEventArgs)
		Me.dgvApprovals.Rows.Clear
	End Sub
	
	'Approve for Install.
	Private Sub ApproveForInstallToolStripMenuItemClick(sender As Object, e As EventArgs)
		Call SetApprovals(UpdateApprovalAction.Install)
	End Sub
	
	Sub ApproveForOptionalInstallToolStripMenuItemClick(sender As Object, e As EventArgs)
		Call SetApprovals(UpdateApprovalAction.Install, True)
	End Sub
	
	'Approve for Removal.
	Private Sub ApproveForRemovalToolStripMenuItemClick(sender As Object, e As EventArgs)
		'Make sure this is a single update that can be uninstalled
		If _multipleUpdates Then
			Msgbox (globalRM.GetString("error_cannot_uninstall_multiple"))
		Else If Not _selectedUpdate Is Nothing AndAlso _selectedUpdate.UninstallationBehavior.IsSupported Then
			Call SetApprovals(UpdateApprovalAction.Uninstall)
		Else
			Msgbox (globalRM.GetString("error_cannot_uninstall"))
		End If
		
	End Sub
	
	'Remove Approval.
	Private Sub NotApprovedToolStripMenuItemClick(sender As Object, e As EventArgs)
		'The All Computers group cannot be set to not approved.
		If dgvApprovals.CurrentRow.Index = 0 Then
			Msgbox (globalRM.GetString("warning_not_approved_all"))
		Else
			Call SetApprovals(UpdateApprovalAction.NotApproved)
		End If
	End Sub
	
	'Set the current group's approval based on the Approval Type passed in.
	Sub SetApprovals(approval As UpdateApprovalAction, optionalInstall As Boolean)
		
		'Enable to Approve button.
		Me.btnOK.Enabled = True
		
		'Set the current row to approve the update.
		If optionalInstall Then
			Me.dgvApprovals.CurrentRow.Cells("approval").Value = globalRM.GetString("OptionalInstall")
			Me.dgvApprovals.CurrentRow.Cells("ApprovalAction").Value = approval
			Me.dgvApprovals.CurrentRow.Cells("OptionalInstall").Value = True
		Else
			Me.dgvApprovals.CurrentRow.Cells("approval").Value = approval.ToDisplayString()
			Me.dgvApprovals.CurrentRow.Cells("ApprovalAction").Value = approval
			Me.dgvApprovals.CurrentRow.Cells("OptionalInstall").Value = False
		End If
		
	End Sub
	
	'Call with default parameters
	Sub SetApprovals(approval As UpdateApprovalAction)
		Call SetApprovals( approval, False)
	End Sub
	
	'Pressing this button will set the approvals for the update.
	Private Sub btnOKClick(sender As Object, e As EventArgs)
		
		'Call the update progress form based on whether we are approving multiple updates.
		If _multipleUpdates Then
			My.Forms.ApprovalProgressForm.ShowDialog(Me.dgvApprovals.Rows, _selectedRows)
		Else
			My.Forms.ApprovalProgressForm.ShowDialog(Me.dgvApprovals.Rows, _selectedUpdate)
		End If
		
		Me.DialogResult = DialogResult.OK
		Me.Close
		
		
	End Sub
	
	'Call LoadData with the base computer node.
	Sub LoadData
		LoadData( My.Forms.MainForm.ComputerNode )
	End Sub
	
	'Load the current update's approvals into the data grid view.
	Sub LoadData( node as TreeNode )
		Dim tmpApprovals As UpdateApprovalCollection
		
		'If the main computer node has been passed.
		If node.Equals(My.Forms.MainForm.ComputerNode) Then
			
			'Clear the datagridview.
			Me.dgvApprovals.Rows.Clear
			
			'Disable to approve button.
			Me.btnOK.Enabled = False
			
			'Get the first child which will be the all computer group.
			Dim computerGroup As IComputerTargetGroup = DirectCast(My.Forms.MainForm.ComputerNode.Nodes(0).Tag, IComputerTargetGroup)
			
			'Load the existing approvals.
			If  _multipleUpdates Then
				'There is no parent approval.
				Call AddApprovalRow(computerGroup, Nothing)
				
			Else If Not _selectedUpdate Is Nothing Then
				'Get the approvals
				tmpApprovals =_selectedUpdate.GetUpdateApprovals(computerGroup)
				
				If tmpApprovals.Count > 0 Then
					Call AddApprovalRow(computerGroup, tmpApprovals.Item(0))
				Else
					'There is no parent approval.
					Call AddApprovalRow(computerGroup, Nothing)
				End If
			End If
			
			'			'Make sure a row was added and tmpRow is a valid index.
			'			If tmpRow < Me.dgvApprovals.Rows.Count
			'				'Set the target group value to equal the computerGroup.
			'				Me.dgvApprovals.Rows.Item(tmpRow).Cells("TargetGroup").Value = computerGroup
			'
			Call LoadData(My.Forms.MainForm.ComputerNode.Nodes(0))
			'			End If
			
		Else 'Is not the main computer node.
			
			'Either load multiple updates or make sure a single update is selected.
			If _multipleUpdates OrElse Not _selectedUpdate Is Nothing Then
				Dim startingDepth As Integer = My.Forms.MainForm.ComputerNode.Level + 1
				
				'Now loop through all any child nodes.
				For Each tmpNode As TreeNode In node.Nodes
					
					If  _multipleUpdates Then
						'No approval
						Call AddApprovalRow(DirectCast(tmpNode.Tag, IComputerTargetGroup), Nothing, False, startingDepth , tmpNode.Level)
						
					Else If Not _selectedUpdate Is Nothing Then
						
						'Get approval for this computer group.
						tmpApprovals = _selectedUpdate.GetUpdateApprovals(DirectCast(tmpNode.Tag, IComputerTargetGroup))
						
						'If there is an approval already then load it, do not over-ride with the parent's approval.
						If tmpApprovals.Count > 0 Then
							
							Call AddApprovalRow(DirectCast(tmpNode.Tag, IComputerTargetGroup), tmpApprovals.Item(0), False, startingDepth , tmpNode.Level)
							
							'If there is no approval then inherit the parent's approval.
						Else
							
							'Get approval for this node's parent group.
							tmpApprovals = GetParentApprovals(DirectCast(node.Tag, IComputerTargetGroup))
							
							'If there is an approval already then load it, do not over-ride with the parent's approval.
							If tmpApprovals.Count > 0 Then
								'tmpRow = Me.dgvApprovals.Rows.Add(New String() {tmpNode.Text, tmpApproval.Action.ToDisplayString() & " (" & globalRM.GetString("inherited") & ")"})
								
								Call AddApprovalRow(DirectCast(tmpNode.Tag, IComputerTargetGroup), tmpApprovals.Item(0), True, startingDepth , tmpNode.Level)
								
								'If there is no approval then inherit the parent's approval.
							Else
								'No approval
								Call AddApprovalRow(DirectCast(tmpNode.Tag, IComputerTargetGroup), Nothing, False, startingDepth , tmpNode.Level)
							End If
						End If
					End If
					Call LoadData(tmpNode)
				Next
			End If 'Selected update is nothing.
		End If 'Main computer node or child node.
	End Sub
	
	'Create a new row in the data grid view for this target group's approval.
	Sub AddApprovalRow (targetGroup As IComputerTargetGroup, approval As IUpdateApproval, inherited As Boolean, startingDepth As Integer, padding As Integer)
		Dim tmpRow As Integer
		tmpRow = Me.dgvApprovals.Rows.Add()
		
		'Set common fields
		Me.dgvApprovals.Rows(tmpRow).Cells("ComputerGroup").Value = targetGroup.Name
		Me.dgvApprovals.Rows(tmpRow).Cells("TargetGroup").Value = targetGroup
		
		If approval Is Nothing Then
			Me.dgvApprovals.Rows(tmpRow).Cells("ComputerGroup").Value = targetGroup.Name
			Me.dgvApprovals.Rows(tmpRow).Cells("Approval").Value = globalRM.GetString("no_approval")
		Else
			
			'Set common fields
			Me.dgvApprovals.Rows(tmpRow).Cells("ApprovalAction").Value = approval.Action
			Me.dgvApprovals.Rows(tmpRow).Cells("CreationDate").Value = approval.CreationDate.ToShortDateString
			
			'Set fields affected by the optional install.
			If approval.IsOptional Then
				Me.dgvApprovals.Rows(tmpRow).Cells("Approval").Value = globalRM.GetString("OptionalInstall")
				Me.dgvApprovals.Rows(tmpRow).Cells("OptionalInstall").Value = True
			Else
				Me.dgvApprovals.Rows(tmpRow).Cells("Approval").Value = approval.Action.ToDisplayString()
				Me.dgvApprovals.Rows(tmpRow).Cells("OptionalInstall").Value = False
			End If
			
			If inherited Then
				Me.dgvApprovals.Rows(tmpRow).Cells("Approval").Value = DirectCast(Me.dgvApprovals.Rows(tmpRow).Cells("Approval").Value,String) & " (" & globalRM.GetString("inherited") & ")"
			End If
			
			'If the deadline is the max date then there is no deadling so set the value to nothing.
			If approval.Deadline = Date.MaxValue Then
				Me.dgvApprovals.Rows(tmpRow).Cells("Deadline").Value = Nothing
			Else
				Me.dgvApprovals.Rows(tmpRow).Cells("Deadline").Value = approval.Deadline
			End If
			
			'Set padding depth.
			Dim tmpPadding As Padding = dgvApprovals.Rows(tmpRow).Cells(0).Style.Padding
			tmpPadding.Left = defaultPaddingSize * ( padding - startingDepth )
			dgvApprovals.Rows(tmpRow).Cells(0).Style.Padding = tmpPadding
		End If
	End Sub
	
	'Call AddApprovalRow without boolean or padding options
	Sub AddApprovalRow (targetGroup As IComputerTargetGroup, approval As IUpdateApproval)
		Call AddApprovalRow (targetGroup, approval, False, 0, 0)
	End Sub
	
	'Get approvals recursively.
	Private Function GetParentApprovals ( computerGroup As IComputerTargetGroup ) As UpdateApprovalCollection
		'Get the group's approvals for the selected update.
		Dim tmpUpdateApprovalCollection As UpdateApprovalCollection = New UpdateApprovalCollection
		tmpUpdateApprovalCollection = _selectedUpdate.GetUpdateApprovals(computerGroup)
		
		'If there are no approvals, try getting the approvals from the parent recursively.
		If tmpUpdateApprovalCollection.Count = 0 AndAlso Not computerGroup.Id.Equals(ComputerTargetGroupId.AllComputers) Then
			Return GetParentApprovals( computerGroup.GetParentTargetGroup )
		Else
			return tmpUpdateApprovalCollection
		End If
	End Function
	
	'Make the selected row current and show the context menu.  Show the menu
	' if the user right clicks anywhere or left clicks in the approval column.
	Private Sub DtaGridViewCellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs)
		'		If e.Button = Windows.Forms.MouseButtons.Right AndAlso e.RowIndex >= 0 Then
		'			dgvApprovals.CurrentCell = dgvApprovals.Rows.Item(e.RowIndex).Cells(e.ColumnIndex)
		'		Else If e.Button = Windows.Forms.MouseButtons.Left AndAlso e.RowIndex >= 0 Then
		'			cntxtMenuStrip.Show(Cursor.Position)
		'		End If
		If e.Button = Windows.Forms.MouseButtons.Left AndAlso e.RowIndex >= 0 AndALso e.ColumnIndex = dgvApprovals.Columns("approval").Index Then
			cntxtMenuStrip.Show(Cursor.Position)
		End If
	End Sub
	
	'Reload the current update's approvals into the data grid view.
	Private Sub BtnReloadClick(sender As Object, e As EventArgs)
		Call LoadData()
	End Sub
	
End Class
