Option Explicit On
Option Strict On
' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' PrerequisiteUpdatesForm allows the user to view and manage the list of packages required for the current package.
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 3/25/2010
' Time: 11:44 AM

Imports Microsoft.UpdateServices.Administration
Imports System.Drawing

Partial Public Class PrerequisiteUpdatesForm
    Private m_prerequisiteGroups As IList(Of PrerequisiteGroup)
    Private m_currentUpdate As Guid

    Public Sub New()
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        Me.InitializeComponent()

        'Initialize the current update.
        m_currentUpdate = New Guid
    End Sub

    ''' <summary>
    ''' Show form with prerequisites based on the passed in update.
    ''' </summary>
    ''' <param name="update"></param>
    ''' <returns>DialogResult</returns>
    Public Overloads Function ShowDialog(update As IUpdate) As DialogResult
        'Hide the Remove/Add buttons.
        btnRemove.Visible = False
        btnAdd.Visible = False
        btnOk.Enabled = False

        'Set the current update id we are working on.
        m_currentUpdate = update.Id.UpdateId

        'Load the prerequisite updates here.
        dgvUpdates.Rows.Clear()
        For Each tmpUpdate As IUpdate In update.GetRelatedUpdates(UpdateRelationship.UpdatesRequiredByThisUpdate)
            Dim tmpRow As Integer = dgvUpdates.Rows.Add
            dgvUpdates.Rows(tmpRow).Cells("Id").Value = tmpUpdate.Id.UpdateId
            dgvUpdates.Rows(tmpRow).Cells("Title").Value = tmpUpdate.Title
        Next

        Return MyBase.ShowDialog()
    End Function

    ''' <summary>
    ''' Show form with prerequisites based on the passed in prerequisite group.
    ''' </summary>
    ''' <param name="prerequisiteGroups"></param>
    ''' <param name="currentUpdate"></param>
    ''' <returns>DialogResult</returns>
    Public Overloads Function ShowDialog(ByRef prerequisiteGroups As IList(Of PrerequisiteGroup), currentUpdate As Guid) As DialogResult
        Dim tmpTitle As String
        m_prerequisiteGroups = prerequisiteGroups

        'Show the Remove/Add buttons.
        btnRemove.Visible = True
        btnAdd.Visible = True
        btnOk.Enabled = True

        'Set the current update id we are working on.
        m_currentUpdate = currentUpdate

        'Load the prerequisite updates here.
        dgvUpdates.Rows.Clear()
        For Each tmpPrerequisiteGroup As PrerequisiteGroup In m_prerequisiteGroups
            For Each tmpUpdateGuid As Guid In tmpPrerequisiteGroup.Ids
                Dim tmpRow As Integer = dgvUpdates.Rows.Add
                dgvUpdates.Rows(tmpRow).Cells("Id").Value = tmpUpdateGuid

                Try
                    tmpTitle = ConnectionManager.CurrentServer.GetUpdate(New UpdateRevisionId(tmpUpdateGuid)).Title
                Catch
                    tmpTitle = Globals.globalRM.GetString("unknown")
                End Try

                dgvUpdates.Rows(tmpRow).Cells("Title").Value = tmpTitle
            Next
        Next

        Return MyBase.ShowDialog()
    End Function

    ''' <summary>
    ''' Prompt the user to add an update to the list.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub BtnAddClick(sender As Object, e As EventArgs)
        UpdateSelectionForm.Location = New Point(Me.Location.X + 100, Me.Location.Y + 100)

        'Loop through the selected updates and add them.
        For Each tmpUpdate As IUpdate In UpdateSelectionForm.ShowDialog(m_currentUpdate)

            Dim tmpRow As Integer = dgvUpdates.Rows.Add
            dgvUpdates.Rows(tmpRow).Cells("Id").Value = tmpUpdate.Id.UpdateId
            dgvUpdates.Rows(tmpRow).Cells("Title").Value = tmpUpdate.Title
            dgvUpdates.Refresh()

            'Select the added cell.
            dgvUpdates.CurrentCell = dgvUpdates.Rows(tmpRow).Cells("Title")

        Next

    End Sub

    ''' <summary>
    ''' If there is a current row, delete it.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub BtnRemoveClick(sender As Object, e As EventArgs)
        For Each tmpRow As DataGridViewRow In dgvUpdates.SelectedRows
            dgvUpdates.Rows.Remove(tmpRow)
        Next
    End Sub

    ''' <summary>
    ''' Save the changes and close the form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub BtnOkClick(sender As Object, e As EventArgs)
        Dim tmpPrerequisiteGroup As PrerequisiteGroup

        'Clear the list.
        m_prerequisiteGroups.Clear()

        'If there are prerequisites, then add them to a temp group
        ' and add them to the list of groups
        If Me.dgvUpdates.Rows.Count > 0 Then
            tmpPrerequisiteGroup = New PrerequisiteGroup

            'Loop through the DGV and add the IDs to the temp group.
            For Each tmpRow As DataGridViewRow In Me.dgvUpdates.Rows
                tmpPrerequisiteGroup.Ids.Add(DirectCast(tmpRow.Cells("Id").Value, Guid))
            Next

            'Add the temp group to the IList of groups.
            m_prerequisiteGroups.Add(tmpPrerequisiteGroup)
        End If
    End Sub
End Class
