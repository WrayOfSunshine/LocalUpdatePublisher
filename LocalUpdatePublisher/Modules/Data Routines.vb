' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' Data Routines
' This module holds the various data routines that go one. A good deal
' of it deals with the process of converting a collection into a data table.
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 10/30/2009
' Time: 7:54 AM
'
Imports Microsoft.UpdateServices.Administration
Imports System.Data

Public Module Data_Routines
	
	'Call GetComputerList with defaults.
	Function GetComputerList(targetGroup As IComputerTargetGroup) As DataTable
		Return GetComputerList(targetGroup, Nothing)
	End Function
	
	'Return the computer list.
	Function GetComputerList(targetGroup As IComputerTargetGroup, status As String) As DataTable
		'Set the computer target scope.
		Dim computers As ComputerTargetScope = New ComputerTargetScope()
		computers.ComputerTargetGroups.Add(targetGroup) 'Show currently selected group
		
		'Include downstream clients if rollup reporting is enabled.
		If appSettings.RollupReporting Then
			computers.IncludeDownstreamComputerTargets = True
		End If
		
		'Filter the list by what update statuses the computer target has.
		If status = "Failed or Needed" Then
			computers.IncludedInstallationStates = UpdateInstallationStates.Failed or UpdateInstallationStates.NotInstalled
		Else If status = "Installed/Not Applicable or No Status" Then
			computers.IncludedInstallationStates = UpdateInstallationStates.Installed or _
				UpdateInstallationStates.NotApplicable or UpdateInstallationStates.Unknown or UpdateInstallationStates.InstalledPendingReboot
		Else If status = "Failed" Then
			computers.IncludedInstallationStates = UpdateInstallationStates.Failed
		Else If status = "Needed" Then
			computers.IncludedInstallationStates = UpdateInstallationStates.NotInstalled
		Else If status = "Installed/Not Applicable" Then
			computers.IncludedInstallationStates = UpdateInstallationStates.Installed or UpdateInstallationStates.NotApplicable or UpdateInstallationStates.InstalledPendingReboot
		Else If status = "No Status" Then
			computers.IncludedInstallationStates = UpdateInstallationStates.Unknown
		End If
		
		
		'Set the update scope to only include locally published updates for the selected group.
		Dim tmpUpdateScope As UpdateScope = New UpdateScope
		tmpUpdateScope.UpdateSources = UpdateSources.Other
		
		'Add groups to approvals reported based on application settings.
		If appSettings.ApprovedUpdatesOnly Then
			AddParentGroupApprovals(tmpUpdateScope, targetGroup, appSettings.InheritApprovals) 'Add groups recursively.
		End If
		
		'Create a new data table.
		Dim dt As DataTable= New DataTable("ComputerTargets")
		dt.Locale = System.Globalization.CultureInfo.CurrentCulture
		
		'Add the columns to the data table.
		dt.Columns.Add("IComputerTarget", System.Type.GetType("System.Object"))
		dt.Columns.Add("TargetID", System.Type.GetType("System.String"))
		dt.Columns.Add("ComputerName", System.Type.GetType("System.String"))
		dt.Columns.Add("IPAddress", System.Type.GetType("System.String"))
		dt.Columns.Add("OperatingSystem", System.Type.GetType("System.String"))
		dt.Columns.Add("InstalledNotApplicable", System.Type.GetType("System.Double"))
		dt.Columns.Add("LastStatusReport", System.Type.GetType("System.DateTime"))
		
		'Loop through update summary Collection and add rows accordingly to the Data table.
		For Each tmpSummary as IUpdateSummary In ConnectionManager.CurrentServer.GetSummariesPerComputerTarget(tmpUpdateScope, computers)
			Dim tmpRow As DataRow = dt.NewRow()
			Dim computerTarget As IComputerTarget = ConnectionManager.CurrentServer.GetComputerTarget(tmpSummary.ComputerTargetID)
			Dim tmpDenominator As Integer = (tmpSummary.InstalledCount + tmpSummary.NotApplicableCount + tmpSummary.DownloadedCount + _
				tmpSummary.FailedCount + tmpSummary.InstalledPendingRebootCount + tmpSummary.NotInstalledCount + tmpSummary.UnknownCount)
			tmpRow("IComputerTarget") = computerTarget
			tmpRow("TargetID") = tmpSummary.ComputerTargetID
			tmpRow("ComputerName") = computerTarget.FullDomainName
			tmpRow("IPAddress") = computerTarget.IPAddress
			tmpRow("OperatingSystem") = computerTarget.OSDescription
			
			'Make sure the denominator isn't zero.
			If tmpDenominator = 0 Then
				tmpRow("InstalledNotApplicable") = 1
			Else
				tmpRow("InstalledNotApplicable") = (tmpSummary.InstalledCount + tmpSummary.NotApplicableCount) / tmpDenominator
			End If
			
			tmpRow("LastStatusReport") = computerTarget.LastReportedStatusTime.ToLocalTime
			dt.Rows.Add(tmpRow)
		Next
		
		'If no rows were added then return nothing.
		If dt.Rows.Count > 0 Then
			Return dt
		Else
			Return Nothing
		End If
	End Function
	
	'Export computer list with defaults.
	Function ExportComputerList(outputFile As String, targetGroup As IComputerTargetGroup) As Boolean
		Return ExportComputerList(outputFile, targetGroup, Nothing)
	End Function
	
	'Export the computer list to the provided file.
	Function ExportComputerList(outputFile As String, targetGroup As IComputerTargetGroup, status As String) As Boolean
		'If there are any errors then return false.
		Try
			ExportData( GetComputerList(targetGroup,status), outputFile)
			Return True
		Catch
			Return False
		End Try
	End Function
	
	Function GetComputerGroupStatus(targetGroup As IComputerTargetGroup) As DataTable
		If Not targetGroup Is Nothing Then
			'Set the computer target scope.
			Dim computers As ComputerTargetScope = New ComputerTargetScope()
			computers.ComputerTargetGroups.Add(targetGroup) 'Show currently selected group
			
			'Include downstream clients if rollup reporting is enabled.
			If appSettings.RollupReporting Then
				computers.IncludeDownstreamComputerTargets = True
			End If
			
			'Set the update scope to only include locally published updates for the selected group.
			Dim tmpUpdateScope As UpdateScope = New UpdateScope
			tmpUpdateScope.UpdateSources = UpdateSources.Other
			
			'Add groups to approvals reported based on application settings.
			If appSettings.ApprovedUpdatesOnly Then
				AddParentGroupApprovals(tmpUpdateScope, targetGroup, appSettings.InheritApprovals) 'Add groups recursively.
			End If
			
			'Create a new Data Table
			Dim dt As DataTable = New DataTable("Status")
			dt.Locale = System.Globalization.CultureInfo.CurrentCulture
			
			'Add the Columns to the data table.
			dt.Columns.Add("Title", System.Type.GetType("System.String"))
			dt.Columns.Add("InstalledCount", System.Type.GetType("System.Int16"))
			dt.Columns.Add("NotInstalledCount", System.Type.GetType("System.Int16"))
			dt.Columns.Add("NotApplicableCount", System.Type.GetType("System.Int16"))
			dt.Columns.Add("FailedCount", System.Type.GetType("System.Int16"))
			dt.Columns.Add("DownloadedCount", System.Type.GetType("System.Int16"))
			dt.Columns.Add("UnknownCount", System.Type.GetType("System.Int16"))
			dt.Columns.Add("LastUpdated", System.Type.GetType("System.DateTime"))
			
			'Loop through update summary collection and add rows accordingly to the data table.
			For Each tmpSummary as IUpdateSummary In ConnectionManager.CurrentServer.GetSummariesPerUpdate(tmpUpdateScope,computers)
				Dim tmpRow As DataRow = dt.NewRow()
				tmpRow("Title") = ConnectionManager.CurrentServer.GetUpdate(New UpdateRevisionId(tmpSummary.UpdateId)).Title
				tmpRow("InstalledCount") = tmpSummary.InstalledCount + tmpSummary.InstalledPendingRebootCount
				tmpRow("NotInstalledCount") = tmpSummary.NotInstalledCount
				tmpRow("NotApplicableCount") = tmpSummary.NotApplicableCount
				tmpRow("FailedCount") = tmpSummary.FailedCount
				tmpRow("DownloadedCount") = tmpSummary.DownloadedCount
				tmpRow("UnknownCount") = tmpSummary.UnknownCount
				tmpRow("LastUpdated") = tmpSummary.LastUpdated.ToLocalTime
				dt.Rows.Add(tmpRow)
			Next
			
			Return dt
		Else
			Return Nothing
		End If
	End Function
	
	'Get coputer report with defaults.
	Function GetComputerReport (computerID As String) As DataTable
		Return GetComputerReport (computerID, Nothing)
	End Function
	
	'Get computer report.
	Function GetComputerReport (computerID As String, status As String) As DataTable
		'Create new data table.
		Dim dt As DataTable = New DataTable("Updates")
		dt.Locale = System.Globalization.CultureInfo.CurrentCulture
		
		'Add Columns to the data table.
		dt.Columns.Add("IUpdate", System.Type.GetType("System.Object"))
		dt.Columns.Add("UpdateID", System.Type.GetType("System.Guid"))
		dt.Columns.Add("UpdateTitle", System.Type.GetType("System.String"))
		dt.Columns.Add("UpdateInstallationState", System.Type.GetType("System.String"))
		dt.Columns.Add("UpdateApprovalAction", System.Type.GetType("System.String"))
		
		'Create row for each update instalation info and add it to the data table.
		For Each tmpUpdate As IUpdateInstallationInfo  In ConnectionManager.CurrentServer.GetComputerTarget( _
			computerID).GetUpdateInstallationInfoPerUpdate(localUpdatesScope)
			
			'We filter the report by skipping rows based on the update status
			' combo box text and the update's installation state string.
			If status = "Failed or Needed" And _
				tmpUpdate.UpdateInstallationState <> UpdateInstallationState.Failed And _
				tmpUpdate.UpdateInstallationState <> UpdateInstallationState.NotInstalled Then
				'Do not add this row
			Else If status = "Installed/Not Applicable or No Status" And _
				tmpUpdate.UpdateInstallationState <> UpdateInstallationState.Installed And _
				tmpUpdate.UpdateInstallationState <> UpdateInstallationState.InstalledPendingReboot And _
				tmpUpdate.UpdateInstallationState <> UpdateInstallationState.NotApplicable And _
				tmpUpdate.UpdateInstallationState <> UpdateInstallationState.Unknown Then
				'Do not add this row.
			Else If status = "Failed" And tmpUpdate.UpdateInstallationState <> UpdateInstallationState.Failed Then
				'Do not add this row.
			Else If status = "Needed" And tmpUpdate.UpdateInstallationState <> UpdateInstallationState.NotInstalled Then
				'Do not add this row.
			Else If status = "Installed/Not Applicable" And _
				tmpUpdate.UpdateInstallationState <> UpdateInstallationState.Installed And _
				tmpUpdate.UpdateInstallationState <> UpdateInstallationState.InstalledPendingReboot And _
				tmpUpdate.UpdateInstallationState <> UpdateInstallationState.NotApplicable Then
				'Do not add this row.
			Else If status = "No Status" And tmpUpdate.UpdateInstallationState <> UpdateInstallationState.Unknown Then
				'Do not add this row.
			Else 'Add this row.
				Dim tmpRow As DataRow = dt.NewRow()
				tmpRow("IUpdate") = tmpUpdate.GetUpdate
				tmpRow("UpdateID") = tmpUpdate.UpdateId
				tmpRow("UpdateTitle") = ConnectionManager.CurrentServer.GetUpdate(New UpdateRevisionId(tmpUpdate.UpdateId)).Title
				tmpRow("UpdateInstallationState") = tmpUpdate.UpdateInstallationState.ToString().Replace("Not","Not ")
				tmpRow("UpdateApprovalAction") = tmpUpdate.UpdateApprovalAction.ToString().Replace("Not","Not ")
				dt.Rows.Add(tmpRow)
			End If
		Next
		Return dt
	End Function
	
	'Export computer report with default.
	Function ExportComputerReport (outputFile As String, computerID As String) As Boolean
		Return ExportComputerReport (outputFile, computerID, Nothing)
	End Function
	
	'Export computer report
	Function ExportComputerReport (outputFile As String, computerID As String, status As String) As Boolean
		'If there are any errors, return false
		Try
			Dim dt As DataTable = GetComputerReport(computerID, status)
			Return True
		Catch
			Return False
		End Try
	End Function
	
	Function GetUpdateList (updateCategory As IUpdateCategory) As DataTable
		'Setup the category filter.
		Dim categoryCollecion As UpdateCategoryCollection = New UpdateCategoryCollection()
		categoryCollecion.Add( updateCategory )
		
		'Get update collection.
		Dim tmpUpdateCollection As UpdateCollection = ConnectionManager.CurrentServer.GetUpdates( _
			ApprovedStates.Any,DateTime.MinValue,DateTime.MaxValue, categoryCollecion , Nothing )
		
		'Make sure there are updates in the collection before loading it.
		If tmpUpdateCollection.Count > 0 Then
			
			'Create new data table.
			Dim dt As DataTable = New DataTable("Updates")
			dt.Locale = System.Globalization.CultureInfo.CurrentCulture
			
			'Add columns to the data table.
			dt.Columns.Add("IUpdate", System.Type.GetType("System.Object"))
			dt.Columns.Add("Id", System.Type.GetType("System.Object"))
			dt.Columns.Add("Title", System.Type.GetType("System.String"))
			dt.Columns.Add("CreationDate", System.Type.GetType("System.DateTime"))
			dt.Columns.Add("Status", System.Type.GetType("System.String"))
			
			
			'Add a row for each update.
			For Each tmpUpdate As IUpdate In tmpUpdateCollection
				
				Dim tmpRow As DataRow = dt.NewRow()
				tmpRow("IUpdate") = tmpUpdate
				tmpRow("Id") = tmpUpdate.Id
				tmpRow("Title") = tmpUpdate.Title
				tmpRow("CreationDate") = tmpUpdate.CreationDate.ToLocalTime
				
				If tmpUpdate.IsDeclined
					tmpRow("Status") = "Declined"
				Else If tmpUpdate.IsSuperseded Then
					tmpRow("Status") = "Superseded"
				Else If tmpUpdate.IsApproved
					tmpRow("Status") = "Approved"					
				End If
							
				dt.Rows.Add(tmpRow)
				
			Next
			Return dt
		Else
			Return Nothing
		End If
	End Function
	
	Function GetUpdateStatus(update As IUpdate) As DataTable
		If Not "" Is Nothing Then
			
			'Create a new Data Table
			Dim dt As DataTable = New DataTable("Status")
			dt.Locale = System.Globalization.CultureInfo.CurrentCulture
			
			'Add the Columns to the data table.
			dt.Columns.Add("GroupName", System.Type.GetType("System.String"))
			dt.Columns.Add("InstalledCount", System.Type.GetType("System.Int16"))
			dt.Columns.Add("NotInstalledCount", System.Type.GetType("System.Int16"))
			dt.Columns.Add("NotApplicableCount", System.Type.GetType("System.Int16"))
			dt.Columns.Add("FailedCount", System.Type.GetType("System.Int16"))
			dt.Columns.Add("DownloadedCount", System.Type.GetType("System.Int16"))
			dt.Columns.Add("UnknownCount", System.Type.GetType("System.Int16"))
			dt.Columns.Add("LastUpdated", System.Type.GetType("System.DateTime"))
			
			'Loop through update summary collection and add rows accordingly to the data table.
			For Each tmpSummary as IUpdateSummary In update.GetSummaryPerComputerTargetGroup
				Dim tmpRow As DataRow = dt.NewRow()
				tmpRow("GroupName") = ConnectionManager.CurrentServer.GetComputerTargetGroup(tmpSummary.ComputerTargetGroupId).Name
				tmpRow("InstalledCount") = tmpSummary.InstalledCount + tmpSummary.InstalledPendingRebootCount
				tmpRow("NotInstalledCount") = tmpSummary.NotInstalledCount
				tmpRow("NotApplicableCount") = tmpSummary.NotApplicableCount
				tmpRow("FailedCount") = tmpSummary.FailedCount
				tmpRow("DownloadedCount") = tmpSummary.DownloadedCount
				tmpRow("UnknownCount") = tmpSummary.UnknownCount
				tmpRow("LastUpdated") = tmpSummary.LastUpdated.ToLocalTime
				dt.Rows.Add(tmpRow)
			Next
			
			Return dt
		Else
			Return Nothing
		End If
	End Function
	
	'Get update report with defaults.
	Function GetUpdateReport (update As IUpdate, targetGroup As IComputerTargetGroup) As DataTable
		Return GetUpdateReport (update , targetGroup , Nothing)
	End Function
	
	'Get update report.
	Function GetUpdateReport (update As IUpdate, targetGroup As IComputerTargetGroup, status As String) As DataTable
		'Set the computer target scope.
		Dim computers As ComputerTargetScope = New ComputerTargetScope()
		computers.ComputerTargetGroups.Add(targetGroup) 'Show currently selected group
		
		'Include downstream clients if rollup reporting is enabled.
		If appSettings.RollupReporting Then
			computers.IncludeDownstreamComputerTargets = True
		End If
		
		'Create new data table.
		Dim dt As DataTable = New DataTable("Updates")
		dt.Locale = System.Globalization.CultureInfo.CurrentCulture
		
		'Add columns to the data table.
		dt.Columns.Add("ComputerID", System.Type.GetType("System.String"))
		dt.Columns.Add("ComputerName", System.Type.GetType("System.String"))
		dt.Columns.Add("UpdateInstallationState", System.Type.GetType("System.String"))
		dt.Columns.Add("UpdateApprovalAction", System.Type.GetType("System.String"))
		
		'Create row for each update instalation info and add it to the data table.
		For Each tmpUpdate As IUpdateInstallationInfo In update.GetUpdateInstallationInfoPerComputerTarget(computers)
			
			'We filter the report by skipping rows based on the update status
			' combo box text and the update's installation state string.
			If status = "Failed or Needed" And _
				tmpUpdate.UpdateInstallationState <> UpdateInstallationState.Failed And _
				tmpUpdate.UpdateInstallationState <> UpdateInstallationState.NotInstalled Then
				'Do not add this row.
			Else If status = "Installed/Not Applicable or No Status" And _
				tmpUpdate.UpdateInstallationState <> UpdateInstallationState.Installed And _
				tmpUpdate.UpdateInstallationState <> UpdateInstallationState.InstalledPendingReboot And _
				tmpUpdate.UpdateInstallationState <> UpdateInstallationState.NotApplicable And _
				tmpUpdate.UpdateInstallationState <> UpdateInstallationState.Unknown Then
				'Do not add this row.
			Else If status = "Failed" And tmpUpdate.UpdateInstallationState <> UpdateInstallationState.Failed Then
				'Do not add this row.
			Else If status = "Needed" And tmpUpdate.UpdateInstallationState <> UpdateInstallationState.NotInstalled Then
				'Do not add this row.
			Else If status = "Installed/Not Applicable" And _
				tmpUpdate.UpdateInstallationState <> UpdateInstallationState.Installed And _
				tmpUpdate.UpdateInstallationState <> UpdateInstallationState.InstalledPendingReboot And _
				tmpUpdate.UpdateInstallationState <> UpdateInstallationState.NotApplicable Then
				'Do not add this row.
			Else If status = "No Status" And tmpUpdate.UpdateInstallationState <> UpdateInstallationState.Unknown Then
				'Do not add this row.
			Else 'Add this row.
				Dim tmpRow As DataRow = dt.NewRow()
				tmpRow("ComputerID") = tmpUpdate.ComputerTargetId
				tmpRow("ComputerName") = ConnectionManager.CurrentServer.GetComputerTarget(tmpUpdate.ComputerTargetId).FullDomainName
				tmpRow("UpdateInstallationState") = tmpUpdate.UpdateInstallationState.ToString().Replace("Not","Not ")
				tmpRow("UpdateApprovalAction") = tmpUpdate.UpdateApprovalAction.ToString().Replace("Not","Not ")
				dt.Rows.Add(tmpRow)
			End If
		Next
		Return dt
	End Function
	
	'Export update report with defaults.
	Function ExportUpdateReport (outputFile As String, update As IUpdate, targetGroup As IComputerTargetGroup) As Boolean
		Return ExportUpdateReport(outputFile, update, targetGroup, Nothing)
	End Function
	
	'Export update report.
	Function ExportUpdateReport (outputFile As String, update As IUpdate, targetGroup As IComputerTargetGroup, status As String) As Boolean
		'If there are any errors return false.
		Try
			Dim dt As DataTable = GetUpdateReport(update, targetGroup, status)
			Return True
		Catch
			Return False
		End Try
	End Function
	
	'	'Get return codes report.
	'	Function GetReturnCodes (codeList As IList(Of ReturnCode)) As DataTable
	'		'Create new data table.
	'		Dim dt As DataTable = New DataTable("ReturnCodes")
	'		dt.Locale = System.Globalization.CultureInfo.CurrentCulture
	'
	'		'Add columns to the data table.
	'		dt.Columns.Add("Result", System.Type.GetType("System.String"))
	'		dt.Columns.Add("ReturnCode", System.Type.GetType("System.Single"))
	'		dt.Columns.Add("Description", System.Type.GetType("System.String"))
	'
	'		'Create row for each return code info and add it to the data table.
	'		For Each tmpReturnCode As ReturnCode In codeList
	'
	'			Dim tmpRow As DataRow = dt.NewRow()
	'			'tmpRow("Result") = tmpReturnCode.InstallationResult
	'			tmpRow("Result") = [Enum].GetName(GetType(InstallationResult),tmpReturnCode.InstallationResult)
	'			tmpRow("ReturnCode") = tmpReturnCode.ReturnCodeValue
	'			tmpRow("Description") = tmpReturnCode.Description
	'			dt.Rows.Add(tmpRow)
	'		Next
	'
	'		Return dt
	'	End Function
	
	'Export data with the defaults
	Sub ExportData(ByVal dt As DataTable, outputFile As String)
		ExportData(dt, outputFile, vbTab)
	End Sub
	
	'Export data.
	Sub ExportData(ByVal dt As DataTable, outputFile As String, delimiter As String)
		Dim tmpWriter As System.IO.StreamWriter = Nothing
		Try
			tmpWriter = New System.IO.StreamWriter(outputFile)
			
			'Write a columns name to first line
			Dim delim As String = ""
			Dim builder As New System.Text.StringBuilder
			For Each col As DataColumn In dt.Columns
				builder.Append(delim).Append(col.ColumnName)
				delim = delimiter
			Next
			tmpWriter.WriteLine(builder.ToString())
			
			'Write data rows.
			For Each row As DataRow In dt.Rows
				delim = ""
				builder = New System.Text.StringBuilder
				
				For Each col As DataColumn In dt.Columns
					builder.Append(delim).Append(row(col.ColumnName))
					delim = delimiter
				Next
				tmpWriter.WriteLine(builder.ToString())
			Next
		Catch
			'Ignore errors.
		Finally
			If Not tmpWriter Is Nothing Then tmpWriter.Close()
		End Try
	End Sub
	
	
	'Recursively add parent groups.
	Sub AddParentGroupApprovals(ByRef updateScope As UpdateScope, computerGroup As IComputerTargetGroup)
		Call AddParentGroupApprovals(updateScope, computerGroup, True)
	End Sub
	
	'Recursively add parent groups.
	Sub AddParentGroupApprovals(ByRef updateScope As UpdateScope, computerGroup As IComputerTargetGroup, recursive As Boolean)
		
		'If the group exists, add it, and call the routine recursively.
		If computerGroup Is Nothing Then
			Exit Sub
		Else
			updateScope.ApprovedComputerTargetGroups.Add(computerGroup)
			
			If recursive then
				'The GetParentGroup call will fail if there is no parent group so exit on errors.
				Try
					AddParentGroupApprovals(updateScope , computerGroup.GetParentTargetGroup, True)
				Catch
					Exit Sub
				End Try
			End If
		End If
	End Sub
End Module
