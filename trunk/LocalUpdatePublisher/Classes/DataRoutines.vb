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

Friend NotInheritable Class DataRoutines

    Private Sub New()
    End Sub

    ''' <summary>
    ''' Call GetComputerList with defaults.
    ''' </summary>
    ''' <param name="targetGroup">IComputerTargetGroup</param>
    ''' <returns>DataTable</returns>
    Shared Function GetComputerList(targetGroup As IComputerTargetGroup) As DataTable
        Return GetComputerList(targetGroup, Nothing)
    End Function

    ''' <summary>
    ''' Return the computer list.
    ''' </summary>
    ''' <param name="targetGroup">IComputerTargetGroup</param>
    ''' <param name="status">Status to filter by.</param>
    ''' <returns>DataTable</returns>
    Shared Function GetComputerList(targetGroup As IComputerTargetGroup, status As String) As DataTable
        'Set the computer target scope.
        Dim computers As ComputerTargetScope = New ComputerTargetScope()
        computers.ComputerTargetGroups.Add(targetGroup) 'Show currently selected group

        'Include downstream clients if rollup reporting is enabled.
        If Globals.appSettings.RollupReporting Then
            computers.IncludeDownstreamComputerTargets = True
        End If

        'Filter the list by what update statuses the computer target has.
        If status = Globals.globalRM.GetString("failed_or_needed") Then
            computers.IncludedInstallationStates = UpdateInstallationStates.Failed Or UpdateInstallationStates.NotInstalled
        ElseIf status = Globals.globalRM.GetString("installed_not_applicable_no_status") Then
            computers.IncludedInstallationStates = UpdateInstallationStates.Installed Or _
                UpdateInstallationStates.NotApplicable Or UpdateInstallationStates.Unknown Or UpdateInstallationStates.InstalledPendingReboot
        ElseIf status = Globals.globalRM.GetString("failed") Then
            computers.IncludedInstallationStates = UpdateInstallationStates.Failed
        ElseIf status = Globals.globalRM.GetString("needed") Then
            computers.IncludedInstallationStates = UpdateInstallationStates.NotInstalled
        ElseIf status = Globals.globalRM.GetString("installed_not_applicable") Then
            computers.IncludedInstallationStates = UpdateInstallationStates.Installed Or UpdateInstallationStates.NotApplicable Or UpdateInstallationStates.InstalledPendingReboot
        ElseIf status = Globals.globalRM.GetString("no_status") Then
            computers.IncludedInstallationStates = UpdateInstallationStates.Unknown
        End If


        'Set the update scope to only include locally published updates for the selected group.
        Dim tmpUpdateScope As UpdateScope = New UpdateScope
        tmpUpdateScope.UpdateSources = UpdateSources.Other

        'Add groups to approvals reported based on application settings.
        If Globals.appSettings.ApprovedUpdatesOnly Then
            AddParentGroupApprovals(tmpUpdateScope, targetGroup, Globals.appSettings.InheritApprovals) 'Add groups recursively.
        End If

        'Create a new data table.
        Dim dt As DataTable = New DataTable("ComputerTargets")
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
        For Each tmpSummary As IUpdateSummary In ConnectionManager.CurrentServer.GetSummariesPerComputerTarget(tmpUpdateScope, computers)
            Dim tmpRow As DataRow = dt.NewRow()
            Dim computerTarget As IComputerTarget = ConnectionManager.CurrentServer.GetComputerTarget(tmpSummary.ComputerTargetId)
            Dim tmpDenominator As Integer = (tmpSummary.InstalledCount + tmpSummary.NotApplicableCount + tmpSummary.DownloadedCount + _
                tmpSummary.FailedCount + tmpSummary.InstalledPendingRebootCount + tmpSummary.NotInstalledCount + tmpSummary.UnknownCount)
            tmpRow("IComputerTarget") = computerTarget
            tmpRow("TargetID") = tmpSummary.ComputerTargetId
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

    ''' <summary>
    ''' Export computer list with defaults.
    ''' </summary>
    ''' <param name="path">Path to destination file.</param>
    ''' <param name="targetGroup">IComputerTargetGroup</param>
    ''' <returns>Boolean indicating success.</returns>
    Shared Function ExportComputerList(path As String, targetGroup As IComputerTargetGroup) As Boolean
        Return ExportComputerList(path, targetGroup, Nothing)
    End Function

    ''' <summary>
    ''' Export the computer list to the provided file.
    ''' </summary>
    ''' <param name="path">Path to destination file.</param>
    ''' <param name="targetGroup">IComputerTargetGroup</param>
    ''' <param name="status">Status to filter by.</param>
    ''' <returns></returns>
    Shared Function ExportComputerList(path As String, targetGroup As IComputerTargetGroup, status As String) As Boolean
        'If there are any errors then return false.
        Try
            ExportData(GetComputerList(targetGroup, status), path)
            Return True
        Catch
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Get computer group status.
    ''' </summary>
    ''' <param name="targetGroup">IComputerTargetGroup</param>
    ''' <returns>DataTable</returns>
    Shared Function GetComputerGroupStatus(targetGroup As IComputerTargetGroup) As DataTable
        If Not targetGroup Is Nothing Then
            'Set the computer target scope.
            Dim computers As ComputerTargetScope = New ComputerTargetScope()
            computers.ComputerTargetGroups.Add(targetGroup) 'Show currently selected group

            'Include downstream clients if rollup reporting is enabled.
            If Globals.appSettings.RollupReporting Then
                computers.IncludeDownstreamComputerTargets = True
            End If

            'Set the update scope to only include locally published updates for the selected group.
            Dim tmpUpdateScope As UpdateScope = New UpdateScope
            tmpUpdateScope.UpdateSources = UpdateSources.Other

            'Add groups to approvals reported based on application settings.
            If Globals.appSettings.ApprovedUpdatesOnly Then
                AddParentGroupApprovals(tmpUpdateScope, targetGroup, Globals.appSettings.InheritApprovals) 'Add groups recursively.
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
            For Each tmpSummary As IUpdateSummary In ConnectionManager.CurrentServer.GetSummariesPerUpdate(tmpUpdateScope, computers)
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

    ''' <summary>
    ''' Get computer report with defaults.
    ''' </summary>
    ''' <param name="computerID">Computer Id</param>
    ''' <returns>DataTable</returns>
    Shared Function GetComputerReport(computerID As String) As DataTable
        Return GetComputerReport(computerID, Nothing)
    End Function

    ''' <summary>
    ''' Get computer report.
    ''' </summary>
    ''' <param name="computerID">Computer Id</param>
    ''' <param name="status">Status to filter on.</param>
    ''' <returns>DataTable</returns>
    Shared Function GetComputerReport(computerID As String, status As String) As DataTable
        'Create new data table.
        Dim dt As DataTable = New DataTable("Updates")
        dt.Locale = System.Globalization.CultureInfo.CurrentCulture

        'Add Columns to the data table.
        dt.Columns.Add("IUpdate", System.Type.GetType("System.Object"))
        dt.Columns.Add("UpdateID", System.Type.GetType("System.Guid"))
        dt.Columns.Add("UpdateTitle", System.Type.GetType("System.String"))
        dt.Columns.Add("UpdateInstallationState", System.Type.GetType("System.String"))
        dt.Columns.Add("UpdateApprovalAction", System.Type.GetType("System.String"))

        'Create row for each update installation info and add it to the data table.
        For Each tmpUpdate As IUpdateInstallationInfo In ConnectionManager.CurrentServer.GetComputerTarget( _
            computerID).GetUpdateInstallationInfoPerUpdate(Globals.localUpdatesScope)

            'We filter the report by skipping rows based on the update status
            ' combo box text and the update's installation state string.
            If status = Globals.globalRM.GetString("failed_or_needed") And _
                tmpUpdate.UpdateInstallationState <> UpdateInstallationState.Failed And _
                tmpUpdate.UpdateInstallationState <> UpdateInstallationState.NotInstalled Then
                'Do not add this row
            ElseIf status = Globals.globalRM.GetString("installed_not_applicable_no_status") And _
                tmpUpdate.UpdateInstallationState <> UpdateInstallationState.Installed And _
                tmpUpdate.UpdateInstallationState <> UpdateInstallationState.InstalledPendingReboot And _
                tmpUpdate.UpdateInstallationState <> UpdateInstallationState.NotApplicable And _
                tmpUpdate.UpdateInstallationState <> UpdateInstallationState.Unknown Then
                'Do not add this row.
            ElseIf status = Globals.globalRM.GetString("failed") And tmpUpdate.UpdateInstallationState <> UpdateInstallationState.Failed Then
                'Do not add this row.
            ElseIf status = Globals.globalRM.GetString("needed") And tmpUpdate.UpdateInstallationState <> UpdateInstallationState.NotInstalled Then
                'Do not add this row.
            ElseIf status = Globals.globalRM.GetString("installed_not_applicable") And _
                tmpUpdate.UpdateInstallationState <> UpdateInstallationState.Installed And _
                tmpUpdate.UpdateInstallationState <> UpdateInstallationState.InstalledPendingReboot And _
                tmpUpdate.UpdateInstallationState <> UpdateInstallationState.NotApplicable Then
                'Do not add this row.
            ElseIf status = Globals.globalRM.GetString("no_status") And tmpUpdate.UpdateInstallationState <> UpdateInstallationState.Unknown Then
                'Do not add this row.
            Else 'Add this row.
                Dim tmpRow As DataRow = dt.NewRow()
                tmpRow("IUpdate") = tmpUpdate.GetUpdate
                tmpRow("UpdateID") = tmpUpdate.UpdateId
                tmpRow("UpdateTitle") = ConnectionManager.CurrentServer.GetUpdate(New UpdateRevisionId(tmpUpdate.UpdateId)).Title
                tmpRow("UpdateInstallationState") = tmpUpdate.UpdateInstallationState.ToString().Replace("Not", "Not ")
                tmpRow("UpdateApprovalAction") = tmpUpdate.UpdateApprovalAction.ToString().Replace("Not", "Not ")
                dt.Rows.Add(tmpRow)
            End If
        Next
        Return dt
    End Function

    ''' <summary>
    ''' Export computer report with default.
    ''' </summary>
    ''' <param name="path">Path to destination file.</param>
    ''' <param name="computerID">Computer Id</param>
    ''' <returns>Boolean</returns>
    Shared Function ExportComputerReport(path As String, computerID As String) As Boolean
        Return ExportComputerReport(path, computerID, Nothing)
    End Function

    ''' <summary>
    ''' Export computer report
    ''' </summary>
    ''' <param name="path">Path to destination file.</param>
    ''' <param name="computerID">Computer Id</param>
    ''' <param name="status">Status to filter by.</param>
    ''' <returns>Boolean</returns>
    Shared Function ExportComputerReport(path As String, computerID As String, status As String) As Boolean
        'If there are any errors, return false
        Try
            Dim dt As DataTable = GetComputerReport(computerID, status)
            Return True
        Catch
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Call the function without hiding an update.
    ''' </summary>
    ''' <param name="updateCategory">IUpdateCategory</param>
    ''' <returns>DataTable</returns>
    Shared Function GetUpdateList(updateCategory As IUpdateCategory) As DataTable
        Return GetUpdateList(updateCategory, New Guid)
    End Function

    ''' <summary>
    ''' Return a datatable containing updates in the category except for the hidden Update.
    ''' </summary>
    ''' <param name="updateCategory">IUpdateCategory</param>
    ''' <param name="hiddenUpdate">Update GUID to hide.</param>
    ''' <returns>DataTable</returns>
    Shared Function GetUpdateList(updateCategory As IUpdateCategory, hiddenUpdate As Guid) As DataTable
        Dim tmpUpdateScope As UpdateScope = New UpdateScope
        tmpUpdateScope.Categories.Add(updateCategory)

        If Globals.appSettings.HideOfficialUpdates Then
            tmpUpdateScope.UpdateSources = UpdateSources.Other
        End If

        'Get update collection.
        Dim tmpUpdateCollection As UpdateCollection = ConnectionManager.CurrentServer.GetUpdates(tmpUpdateScope)

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
                If Not tmpUpdate.Id.UpdateId.Equals(hiddenUpdate) Then
                    Dim tmpRow As DataRow = dt.NewRow()

                    tmpRow("IUpdate") = tmpUpdate
                    tmpRow("Id") = tmpUpdate.Id
                    tmpRow("Title") = tmpUpdate.Title
                    tmpRow("CreationDate") = tmpUpdate.CreationDate.ToLocalTime

                    If tmpUpdate.IsDeclined Then
                        If tmpUpdate.PublicationState = PublicationState.Expired Then
                            tmpRow("Status") = Globals.globalRM.GetString("declined_expired")
                        Else
                            tmpRow("Status") = Globals.globalRM.GetString("declined")
                        End If
                    ElseIf tmpUpdate.IsSuperseded Then
                        tmpRow("Status") = Globals.globalRM.GetString("superseded")
                    ElseIf tmpUpdate.IsApproved Then
                        tmpRow("Status") = Globals.globalRM.GetString("approved")
                    End If

                    dt.Rows.Add(tmpRow)
                End If
            Next
            Return dt
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' Return a datatable containing updates in the category except for the hidden Update.
    ''' </summary>
    ''' <param name="updateRevisionID">UpdateRevisionId</param>
    ''' <returns>DataTable</returns>
    Shared Function GetUpdate(updateRevisionID As UpdateRevisionId) As DataTable
        If ConnectionManager.Connected Then
            Try

                Dim tmpUpdate As IUpdate = ConnectionManager.CurrentServer.GetUpdate(updateRevisionID)

                'Make sure there are updates in the collection before loading it.
                If Not tmpUpdate Is Nothing Then

                    'Create new data table.
                    Dim dt As DataTable = New DataTable("Updates")
                    dt.Locale = System.Globalization.CultureInfo.CurrentCulture

                    'Add columns to the data table.
                    dt.Columns.Add("IUpdate", System.Type.GetType("System.Object"))
                    dt.Columns.Add("Id", System.Type.GetType("System.Object"))
                    dt.Columns.Add("Title", System.Type.GetType("System.String"))
                    dt.Columns.Add("CreationDate", System.Type.GetType("System.DateTime"))
                    dt.Columns.Add("Status", System.Type.GetType("System.String"))

                    'Add a row for the update.
                    Dim tmpRow As DataRow = dt.NewRow()
                    tmpRow("IUpdate") = tmpUpdate
                    tmpRow("Id") = tmpUpdate.Id
                    tmpRow("Title") = tmpUpdate.Title
                    tmpRow("CreationDate") = tmpUpdate.CreationDate.ToLocalTime

                    If tmpUpdate.IsDeclined Then
                        If tmpUpdate.PublicationState = PublicationState.Expired Then
                            tmpRow("Status") = Globals.globalRM.GetString("declined_expired")
                        Else
                            tmpRow("Status") = Globals.globalRM.GetString("declined")
                        End If
                    ElseIf tmpUpdate.IsSuperseded Then
                        tmpRow("Status") = Globals.globalRM.GetString("superseded")
                    ElseIf tmpUpdate.IsApproved Then
                        tmpRow("Status") = Globals.globalRM.GetString("approved")
                    End If

                    dt.Rows.Add(tmpRow)

                    Return dt
                Else
                    Return Nothing
                End If

            Catch x As WsusInvalidDataException
                MsgBox(Globals.globalRM.GetString("warning_GUID_not_found") & ":" & vbNewLine & _
                    Globals.globalRM.GetString("exception_wsus_invalid_data") & ": " & x.Message)
            Catch x As WsusObjectNotFoundException
                MsgBox(Globals.globalRM.GetString("warning_GUID_not_found") & ":" & vbNewLine & _
                    Globals.globalRM.GetString("exception_wsus_object_not_found") & ": " & x.Message)
            End Try
        End If

        'If there was an error, return nothing
        Return Nothing
    End Function

    ''' <summary>
    ''' Sets up the data table and search scope and calls the recursive function.
    ''' </summary>
    ''' <param name="update">IUpdate</param>
    ''' <param name="node">Treenode</param>
    ''' <returnsDataTable></returns>
    Shared Function GetUpdateStatus(update As IUpdate, node As TreeNode) As DataTable
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

        'If the update and node object check out then populate the data table.
        If Not update Is Nothing AndAlso Not node Is Nothing Then
            Dim computerTargetScope As ComputerTargetScope = New ComputerTargetScope

            'Set downstream computer target boolean
            computerTargetScope.IncludeDownstreamComputerTargets = Globals.appSettings.RollupReporting

            dt = GetTargetGroupStatus(update, dt, node, computerTargetScope)
        End If

        Return dt
    End Function

    ''' <summary>
    ''' This is a recursive function that parses the tree for computer targets, gets a summary
    ' for each group, and adds the results to the data table.
    ''' </summary>
    ''' <param name="update">IUpdate</param>
    ''' <param name="dt">DataTable</param>
    ''' <param name="node">TreeNode</param>
    ''' <param name="computerTargetScope">ComputerTargetScope</param>
    ''' <returns>DataTable</returns>
    Private Shared Function GetTargetGroupStatus(update As IUpdate, dt As DataTable, node As TreeNode, computerTargetScope As ComputerTargetScope) As DataTable

        'If the node tag is a computer group then add the summary results to the data table.
        If Not node.Tag Is Nothing AndAlso TypeOf node.Tag Is IComputerTargetGroup Then
            Dim updateSummary As IUpdateSummary
            Dim dataRow As DataRow
            Dim computerTargetGroup As IComputerTargetGroup = DirectCast(node.Tag, IComputerTargetGroup)

            'Set target group scope.
            computerTargetScope.ComputerTargetGroups.Clear()
            computerTargetScope.ComputerTargetGroups.Add(computerTargetGroup)

            Try
                'Get the summary and it to the data table.
                updateSummary = update.GetSummary(computerTargetScope)
                dataRow = dt.NewRow()
                dataRow("GroupName") = computerTargetGroup.Name
                dataRow("InstalledCount") = updateSummary.InstalledCount + updateSummary.InstalledPendingRebootCount
                dataRow("NotInstalledCount") = updateSummary.NotInstalledCount
                dataRow("NotApplicableCount") = updateSummary.NotApplicableCount
                dataRow("FailedCount") = updateSummary.FailedCount
                dataRow("DownloadedCount") = updateSummary.DownloadedCount
                dataRow("UnknownCount") = updateSummary.UnknownCount
                dataRow("LastUpdated") = updateSummary.LastUpdated.ToLocalTime
                dt.Rows.Add(dataRow)
            Catch x As ArgumentNullException
                MsgBox(Globals.globalRM.GetString("exception_argument_null") & ": GetTargetGroupStatus" & vbNewLine & x.Message)
            Catch x As ArgumentOutOfRangeException
                MsgBox(Globals.globalRM.GetString("exception_argument_out_of_range") & ": GetTargetGroupStatus" & vbNewLine & x.Message)
            Catch x As WsusObjectNotFoundException
                MsgBox(Globals.globalRM.GetString("exception_wsus_object_not_found") & ": GetTargetGroupStatus" & vbNewLine & computerTargetGroup.Name & vbNewLine & x.Message)
            End Try

        End If

        'Recursively call on child nodes.
        For Each tmpNode As TreeNode In node.Nodes
            dt = GetTargetGroupStatus(update, dt, tmpNode, computerTargetScope)
        Next

        Return dt
    End Function

    ''' <summary>
    ''' Get update report with defaults.
    ''' </summary>
    ''' <param name="update">IUpdate</param>
    ''' <param name="targetGroup">IComputerTargetGroup</param>
    ''' <returns>DataTable</returns>
    Shared Function GetUpdateReport(update As IUpdate, targetGroup As IComputerTargetGroup) As DataTable
        Return GetUpdateReport(update, targetGroup, Nothing)
    End Function

    ''' <summary>
    ''' Get update report.
    ''' </summary>
    ''' <param name="update">IUpdate</param>
    ''' <param name="targetGroup">IComputerTargetGroup</param>
    ''' <param name="status">Status to filter on.</param>
    ''' <returns>DataTable</returns>
    Shared Function GetUpdateReport(update As IUpdate, targetGroup As IComputerTargetGroup, status As String) As DataTable
        'Set the computer target scope.
        Dim computers As ComputerTargetScope = New ComputerTargetScope()
        computers.ComputerTargetGroups.Add(targetGroup) 'Show currently selected group

        'Include downstream clients if rollup reporting is enabled.
        If Globals.appSettings.RollupReporting Then
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

        'Create row for each update installation info and add it to the data table.
        For Each tmpUpdate As IUpdateInstallationInfo In update.GetUpdateInstallationInfoPerComputerTarget(computers)

            'We filter the report by skipping rows based on the update status
            ' combo box text and the update's installation state string.
            If status = Globals.globalRM.GetString("failed_or_needed") And _
                tmpUpdate.UpdateInstallationState <> UpdateInstallationState.Failed And _
                tmpUpdate.UpdateInstallationState <> UpdateInstallationState.NotInstalled Then
                'Do not add this row.
            ElseIf status = Globals.globalRM.GetString("installed_not_applicable_no_status") And _
                tmpUpdate.UpdateInstallationState <> UpdateInstallationState.Installed And _
                tmpUpdate.UpdateInstallationState <> UpdateInstallationState.InstalledPendingReboot And _
                tmpUpdate.UpdateInstallationState <> UpdateInstallationState.NotApplicable And _
                tmpUpdate.UpdateInstallationState <> UpdateInstallationState.Unknown Then
                'Do not add this row.
            ElseIf status = Globals.globalRM.GetString("failed") And tmpUpdate.UpdateInstallationState <> UpdateInstallationState.Failed Then
                'Do not add this row.
            ElseIf status = Globals.globalRM.GetString("needed") And tmpUpdate.UpdateInstallationState <> UpdateInstallationState.NotInstalled Then
                'Do not add this row.
            ElseIf status = Globals.globalRM.GetString("installed_not_applicable") And _
                tmpUpdate.UpdateInstallationState <> UpdateInstallationState.Installed And _
                tmpUpdate.UpdateInstallationState <> UpdateInstallationState.InstalledPendingReboot And _
                tmpUpdate.UpdateInstallationState <> UpdateInstallationState.NotApplicable Then
                'Do not add this row.
            ElseIf status = Globals.globalRM.GetString("no_status") And tmpUpdate.UpdateInstallationState <> UpdateInstallationState.Unknown Then
                'Do not add this row.
            Else 'Add this row.
                Dim tmpRow As DataRow = dt.NewRow()
                tmpRow("ComputerID") = tmpUpdate.ComputerTargetId
                tmpRow("ComputerName") = ConnectionManager.CurrentServer.GetComputerTarget(tmpUpdate.ComputerTargetId).FullDomainName
                tmpRow("UpdateInstallationState") = tmpUpdate.UpdateInstallationState.ToString().Replace("Not", "Not ")
                tmpRow("UpdateApprovalAction") = tmpUpdate.UpdateApprovalAction.ToString().Replace("Not", "Not ")
                dt.Rows.Add(tmpRow)
            End If
        Next
        Return dt
    End Function

    ''' <summary>
    ''' Export update report with defaults.
    ''' </summary>
    ''' <param name="outputFile">Path to destination file.</param>
    ''' <param name="update">IUpdate</param>
    ''' <param name="targetGroup">IComputerTargetGroup</param>
    ''' <returns>Boolean</returns>
    Shared Function ExportUpdateReport(path As String, update As IUpdate, targetGroup As IComputerTargetGroup) As Boolean
        Return ExportUpdateReport(path, update, targetGroup, Nothing)
    End Function

    ''' <summary>
    ''' Export update report.
    ''' </summary>
    ''' <param name="path">Path to destination file.</param>
    ''' <param name="update">IUpdate</param>
    ''' <param name="targetGroup">IComputerTargetGroup</param>
    ''' <param name="status">Status to filter on.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function ExportUpdateReport(path As String, update As IUpdate, targetGroup As IComputerTargetGroup, status As String) As Boolean
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

    ''' <summary>
    ''' Export data with the defaults
    ''' </summary>
    ''' <param name="dt">DataTable to export.</param>
    ''' <param name="path">Path to destination file.</param>
    Shared Sub ExportData(ByVal dt As DataTable, path As String)
        ExportData(dt, path, vbTab)
    End Sub

    ''' <summary>
    ''' Export data.
    ''' </summary>
    ''' <param name="dt">Datatable to export</param>
    ''' <param name="path">Path to destination File.</param>
    ''' <param name="delimiter">Delimiter to use between fields.</param>
    Shared Sub ExportData(ByVal dt As DataTable, path As String, delimiter As String)
        Dim tmpWriter As System.IO.StreamWriter = Nothing
        Try
            tmpWriter = New System.IO.StreamWriter(path)

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


    ''' <summary>
    ''' Recursively add parent groups.
    ''' </summary>
    ''' <param name="updateScope">UpdateScope</param>
    ''' <param name="computerGroup">IComputerTargetGroup</param>
    ''' <remarks>Recurse through parent groups to generate full list of applicable approvals.</remarks>
    Shared Sub AddParentGroupApprovals(ByRef updateScope As UpdateScope, computerGroup As IComputerTargetGroup)
        Call AddParentGroupApprovals(updateScope, computerGroup, True)
    End Sub

    ''' <summary>
    ''' Recursively add parent groups.
    ''' </summary>
    ''' <param name="updateScope">UpdateScope</param>
    ''' <param name="computerGroup">IComputerTargetGroup</param>
    ''' <param name="recursive">Boolean</param>
    Shared Sub AddParentGroupApprovals(ByRef updateScope As UpdateScope, computerGroup As IComputerTargetGroup, recursive As Boolean)

        'If the group exists, add it, and call the routine recursively.
        If computerGroup Is Nothing Then
            Exit Sub
        Else
            updateScope.ApprovedComputerTargetGroups.Add(computerGroup)

            If recursive Then
                'The GetParentGroup call will fail if there is no parent group so exit on errors.
                Try
                    AddParentGroupApprovals(updateScope, computerGroup.GetParentTargetGroup, True)
                Catch
                    Exit Sub
                End Try
            End If
        End If
    End Sub
End Class
