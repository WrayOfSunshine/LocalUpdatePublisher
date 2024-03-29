﻿Option Explicit On
Option Strict On
' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
' 
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 3/25/2010
' Time: 11:44 AM
Imports Microsoft.UpdateServices.Administration
Imports System.Collections.Specialized

Partial Public Class LanguageSelectionForm

    Public Sub New()
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        Me.InitializeComponent()

        DirectCast(dgvLanguages.Columns("Language"), DataGridViewComboBoxColumn).Items.AddRange(Languages.Names)
    End Sub

    ''' <summary>
    ''' Show Dialog
    ''' </summary>
    ''' <returns>StringCollection of language codes.</returns>
    Public Overloads Function ShowDialog() As StringCollection
        Dim tmpStringCollection As StringCollection = New StringCollection

        'Hide the Remove/Add buttons.
        btnRemove.Visible = False
        btnOk.Enabled = False

        MyBase.ShowDialog()

        For Each tmpRow As DataGridViewRow In dgvLanguages.Rows
            If Not tmpRow.IsNewRow Then
                tmpStringCollection.Add(DirectCast(tmpRow.Cells("Id").Value, String))
            End If
        Next

        Return tmpStringCollection
    End Function

    ''' <summary>
    ''' Show dialog with superseded updates based on the passed in list of update GUIDs.
    ''' </summary>
    ''' <param name="languageCollection"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function ShowDialog(ByRef languageCollection As StringCollection) As StringCollection
        Dim tmpStringCollection As StringCollection = New StringCollection

        'Show the Remove/Add buttons.
        btnRemove.Visible = True
        btnOk.Enabled = True


        dgvLanguages.Rows.Clear()

        'Load the superseded updates here.
        For Each tmpLanguage As String In languageCollection
            Dim tmpRow As Integer = dgvLanguages.Rows.Add
            dgvLanguages.Rows(tmpRow).Cells("Id").Value = tmpLanguage
            dgvLanguages.Rows(tmpRow).Cells("Language").Value = Languages.Name(tmpLanguage)
        Next

        MyBase.ShowDialog()

        For Each tmpRow As DataGridViewRow In dgvLanguages.Rows
            If Not tmpRow.IsNewRow Then
                tmpStringCollection.Add(DirectCast(tmpRow.Cells("Id").Value, String))
            End If
        Next

        Return tmpStringCollection
    End Function

    ''' <summary>
    ''' If there is a current row, delete it.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub BtnRemoveClick(sender As Object, e As EventArgs)
        For Each tmpRow As DataGridViewRow In dgvLanguages.SelectedRows
            If Not tmpRow.IsNewRow Then
                dgvLanguages.Rows.Remove(tmpRow)
            End If
        Next
    End Sub

    ''' <summary>
    ''' When the user makes a selection from the combo box then update the Id field accordingly.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub DgvLanguagesCellValueChanged(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex > -1 AndAlso e.ColumnIndex > -1 AndAlso e.ColumnIndex = Me.dgvLanguages.Columns("Language").Index Then
            dgvLanguages.Rows(e.RowIndex).Cells("Id").Value = Languages.Code(DirectCast(dgvLanguages.Rows(e.RowIndex).Cells("Language").Value, String))
        End If
    End Sub
End Class
