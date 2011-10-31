'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 8/31/2010
' Time: 8:53 AM
'
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports Microsoft.UpdateServices.Administration
Imports System.IO

Public Partial Class ApprovalProgressForm
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		'Localize the data grid view
		For Each colTemp As DataGridViewColumn In Me.dgvProgress.Columns
			colTemp.HeaderText = globalRM.GetString(colTemp.Name)
		Next
	End Sub
	
	'Call ShowDialog with multiple updates.
	Public Overloads Function ShowDialog(computerGroups As DataGridViewRowCollection, selectedRows As DataGridViewSelectedRowCollection) As DialogResult
		Dim strAction As String
		Dim strResult As String
		Dim intCurrentRow As Integer
		Dim update As IUpdate
		
		'Check server connection.
		If Not ConnectionManager.Connected Then
			Msgbox(globalRM.GetString("error_server_disconnected"))
			Return DialogResult.Cancel
		End If
		
		'Setup progress bar.
		Me.pbUpdateApprovals.Minimum = 0
		Me.pbUpdateApprovals.Maximum = selectedRows.Count
		Me.pbUpdateApprovals.Step = 1
		
		'Setup buttons.
		Me.btnPause.Enabled = True
		Me.btnCancel.Enabled = False
		Me.btnClose.Enabled = False
		
		
		'Setup label.
		Me.lblProgress.Text = String.Format(globalRM.GetString("label_approval_form_multiple"), selectedRows.Count)
		
		'Clear data grid view.
		Me.dgvProgress.Rows.Clear
		Me.Refresh
		
		'Loop through each update in the selected rows.
		For Each updateRow As DataGridViewRow In selectedRows
			
			'Get update.
			update = ConnectionManager.CurrentServer.GetUpdate(DirectCast(updateRow.Cells.Item("Id").Value, UpdateRevisionId))
			
			'Add new row
			strAction = String.Format(globalRM.GetString("label_approval_progress_form"), update.Title)
			intCurrentRow = Me.dgvProgress.Rows.Add(New String() {strAction})
			Me.Refresh
			
			'Set default result to success.
			strResult = globalRM.GetString("success")
			
			'Loop through the approval groups and if the row has an approval action
			' then perform that action for that row's group.
			For Each tempRow As DataGridViewRow In computerGroups
				Dim tmpResult As String
				'Approve the Update
				tmpResult= ApproveUpdate( update, _
					tempRow.Cells.Item("ApprovalAction").Value, _
					tempRow.Cells.Item("TargetGroup").Value, _
					tempRow.Cells.Item("OptionalInstall").Value, _
					tempRow.Cells.Item("Deadline").Value)
				
				'Ignore successfull approvals so that if error occur the entire update is flagged with that error.
				If Not tmpResult = globalRM.GetString("success") Then
					strResult = tmpResult
				End If
			Next
			
			'Update the DGV with the results
			Me.dgvProgress.Rows(intCurrentRow).Cells("Result").Value = strResult
			Me.pbUpdateApprovals.PerformStep
			Me.Refresh
		Next
		
		Me.btnPause.Enabled = False
		Me.btnCancel.Enabled = False
		Me.btnClose.Enabled = True
		
		Return MyBase.ShowDialog
		
	End Function
	
	'Call ShowDialog with a single update.
	Public Overloads Function ShowDialog(computerGroups As DataGridViewRowCollection, update As IUpdate) As DialogResult
		Dim strAction As String
		Dim strResult As String
		Dim intCurrentRow As Integer
		
		'Check server connection.
		If Not ConnectionManager.Connected Then
			Msgbox("The server is not connected.")
			Return DialogResult.Cancel
		End If
		
		'Setup progress bar.
		Me.pbUpdateApprovals.Minimum = 0
		Me.pbUpdateApprovals.Maximum = 1
		Me.pbUpdateApprovals.Step = 1
		
		'Setup buttons.
		Me.btnPause.Enabled = False
		Me.btnCancel.Enabled = False
		Me.btnClose.Enabled = False
		
		'Setup label.
		Me.lblProgress.Text = String.Format(globalRM.GetString("label_approval_progress_form"), update.Title)
		
		'Clear data grid view.
		Me.dgvProgress.Rows.Clear
		Me.Refresh
		
		'Loop through the approval groups and if the row has an approval action
		' then perform that action for that row's group.
		For Each tempRow As DataGridViewRow In computerGroups
			
			strAction = String.Format(globalRM.GetString("label_approval_progress_status") , _
				update.Title,DirectCast(tempRow.Cells.Item("Approval").Value, String),DirectCast(tempRow.Cells.Item("ComputerGroup").Value, String))
			
			'Set default result to success.
			strResult = globalRM.GetString("success")
			
			'Skip any row where no approval action was set.
			If tempRow.Cells.Item("ApprovalAction").Value Is Nothing Then
				intCurrentRow = -1
			Else
				intCurrentRow = Me.dgvProgress.Rows.Add(New String() {strAction})
				Me.Refresh
				
				
				' If the installation isn't possible then use the metadata to republish it with the binaries.
				If update.State = UpdateState.InstallationImpossible Then
					'SDP Path.
					Dim sdpFilePath As String = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), update.Id.UpdateId.ToString() & ".xml")
					
					'Export the udpate's metadata to the sdp path.
					update.ExportPackageMetadata(sdpFilePath)
					
					'Publish the update as a catalog snippet which will download the files.
					Dim tmpSdp As SoftwareDistributionPackage = New SoftwareDistributionPackage(sdpFilePath)
					ConnectionManager.PublishPackageFromCatalog(tmpSdp, sdpFilePath, Me)
					update.Refresh
				End If
				
				'Approve the Update
				Me.dgvProgress.Rows(intCurrentRow).Cells("Result").Value = ApproveUpdate( update, _
					tempRow.Cells.Item("ApprovalAction").Value, _
					tempRow.Cells.Item("TargetGroup").Value, _
					tempRow.Cells.Item("OptionalInstall").Value, _
					tempRow.Cells.Item("Deadline").Value)
				
				Me.pbUpdateApprovals.PerformStep
				
			End If
			
			Me.Refresh
			
		Next
		
		Me.btnClose.Enabled = True
		
		Return MyBase.ShowDialog
		
	End Function
	
	'Approve update handles the actual approval of the updates and returns the results as a string.
	Function ApproveUpdate(update As IUpdate, approvalAction As Object, targetGroup As Object, optionalInstall As Object, deadline As Object) As String
		'Set default result to success.
		Dim strResult As String = globalRM.GetString("success")
		
		If Not update Is Nothing AndAlso _
			Not targetGroup Is Nothing AndAlso TypeOf targetGroup Is IComputerTargetGroup AndAlso _
			Not approvalAction Is Nothing AndAlso TypeOf approvalAction Is UpdateApprovalAction Then
			Try
				'If optionalInstall is populated, a boolean, and true then optionally approve the update.
				If  Not optionalInstall Is Nothing AndAlso TypeOf optionalInstall Is Boolean AndAlso DirectCast(optionalInstall, Boolean) Then
					update.ApproveForOptionalInstall( DirectCast(targetGroup, IComputerTargetGroup) )
					'If there is a deadline then approve it with a deadline.
				Else If Not deadline Is Nothing AndAlso TypeOf deadline Is Date AndAlso Not DirectCast(deadline, Date) = Date.MinValue
					update.Approve( _
						DirectCast(approvalAction, UpdateApprovalAction), _
						DirectCast(targetGroup, IComputerTargetGroup), _
						DirectCast(deadline, Date))
					'Otherwise just approve this normally.
				Else
					update.Approve( _
						DirectCast(approvalAction, UpdateApprovalAction), _
						DirectCast(targetGroup, IComputerTargetGroup))
				End If
			Catch x As ArgumentOutOfRangeException
				strResult = globalRM.GetString("exception_argument_out_of_range") & ": " & x.Message
			Catch x As ArgumentNullException
				strResult = globalRM.GetString("exception_argument_null") & ": " & x.Message
			Catch x As InvalidOperationException
				strResult = globalRM.GetString("exception_invalid_operation") & ": " & x.Message
			Catch x As WsusObjectNotFoundException
				strResult = globalRM.GetString("exception_wsus_object_not_found") & ": " & x.Message
			Catch x As Exception
				strResult = globalRM.GetString("exception") & ": " & x.Message
			End Try
		End If
		
		'If we get this far, return generic error
		Return strResult
	End Function
	
	Sub BtnPauseClick(sender As Object, e As EventArgs)
		Me.btnCancel.Enabled = True
	End Sub
End Class
