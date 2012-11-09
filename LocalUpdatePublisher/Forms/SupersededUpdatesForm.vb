Option Explicit On
Option Strict On
' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' SupersededUpdatesForm allows the user to view and manage the list of packages superseded by the current package.
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 3/25/2010
' Time: 11:44 AM
Imports Microsoft.UpdateServices.Administration

Partial Public Class SupersededUpdatesForm
    Private m_updateGuids As IList(Of Guid)
    Private m_currentUpdate As Guid

    Public Sub New()
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        Me.InitializeComponent()

        'Initialize the current update.
        m_currentUpdate = New Guid
    End Sub

    ''' <summary>
    ''' Show dialog with superseded updates based on the passed in update.
    ''' </summary>
    ''' <param name="update">The current update.</param>
    ''' <returns>DialogResult</returns>
    Public Overloads Function ShowDialog(update As IUpdate) As DialogResult
        'Hide the Remove/Add buttons.
        btnRemove.Visible = False
        btnAdd.Visible = False
        btnOk.Enabled = False

        'Set the current update id we are working on.
        m_currentUpdate = update.Id.UpdateId

        If update.HasSupersededUpdates Then
            dgvUpdates.Rows.Clear()

            'Load the superseded updates here.
            For Each tmpUpdate As IUpdate In update.GetRelatedUpdates(UpdateRelationship.UpdatesSupersededByThisUpdate)
                Dim tmpRow As Integer = dgvUpdates.Rows.Add
                dgvUpdates.Rows(tmpRow).Cells("Title").Value = tmpUpdate.Title
            Next

            Return MyBase.ShowDialog()
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' Show dialog with superseded updates based on the passed in list of update Guids.
    ''' </summary>
    ''' <param name="updateGuids">A list of Update GUIDs.</param>
    ''' <param name="currentUpdate">GUID of current update.</param>
    ''' <returns>DialogResult</returns>
    Public Overloads Function ShowDialog(ByRef updateGuids As IList(Of Guid), currentUpdate As Guid) As DialogResult
        Dim tmpTitle As String
        m_updateGuids = updateGuids

        'Show the Remove/Add buttons.
        btnRemove.Visible = True
        btnAdd.Visible = True
        btnOk.Enabled = True

        'Set the current update id we are working on.
        m_currentUpdate = currentUpdate

        dgvUpdates.Rows.Clear()

        'Load the superseded updates here.
        For Each tmpUpdateGuid As Guid In m_updateGuids
            Dim tmpRow As Integer = dgvUpdates.Rows.Add
            dgvUpdates.Rows(tmpRow).Cells("Id").Value = tmpUpdateGuid

            Try
                tmpTitle = ConnectionManager.CurrentServer.GetUpdate(New UpdateRevisionId(tmpUpdateGuid)).Title
            Catch
                tmpTitle = Globals.globalRM.GetString("unknown")
            End Try

            dgvUpdates.Rows(tmpRow).Cells("Title").Value = tmpTitle
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
    ''' Click OK button.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Sub BtnOkClick(sender As Object, e As EventArgs)
        'Clear the list.
        m_updateGuids.Clear()

        'Add the superseded updates.
        For Each tmpRow As DataGridViewRow In Me.dgvUpdates.Rows
            m_updateGuids.Add(DirectCast(tmpRow.Cells("Id").Value, Guid))
        Next
    End Sub

End Class
