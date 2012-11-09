Option Explicit On
Option Strict On
' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' GuidCollectionEditor
' Represents a user control that allows you to edit a collection of GUIDs.
'
' Created by SharpDevelop.
' User: kdixon
' Date: 10/2/2010
' Time: 11:10 AM

Imports System.Collections.Generic
Imports System.Windows.Forms

Partial Public Class GuidCollectionEditor
    Inherits UserControl
    Public Sub New()
        InitializeComponent()

        RequireGuids = True
        RequireAtLeastOne = True
    End Sub

    ''' <summary>
    ''' The header text to show.
    ''' </summary>
    ''' <value>String</value>
    Public Property Header() As String
        Get
            Return dgv.Columns(0).HeaderText
        End Get
        Set(value As String)
            dgv.Columns(0).HeaderText = Value
        End Set
    End Property

    ''' <summary>
    ''' True if the input items must be GUIDs.
    ''' </summary>
    ''' <value>Boolean</value>
    Public Property RequireGuids() As Boolean
        Get
            Return m_RequireGuids
        End Get
        Set(value As Boolean)
            m_RequireGuids = Value
        End Set
    End Property

    Private m_RequireGuids As Boolean
    ''' <summary>
    ''' True if you require one or more items.
    ''' </summary>
    ''' <value>Boolean</value>
    Public Property RequireAtLeastOne() As Boolean
        Get
            Return m_RequireAtLeastOne
        End Get
        Set(value As Boolean)
            m_RequireAtLeastOne = Value
        End Set
    End Property
    Private m_RequireAtLeastOne As Boolean

    ''' <summary>
    ''' Returns the list of all valid GUIDs in the items.
    ''' </summary>
    ''' <value>List of GUIDs</value>
    Public ReadOnly Property ItemGuids() As List(Of Guid)
        Get
            Dim s As New List(Of Guid)()
            For Each r As DataGridViewRow In dgv.Rows
                Try
                    s.Add(New Guid(r.Cells(0).Value.ToString()))
                Catch
                End Try
            Next
            Return s
        End Get
    End Property

    ''' <summary>
    ''' Returns or Sets the strings for all items in the list.
    ''' </summary>
    ''' <value>List of String</value>
    Public Property Items() As List(Of String)
        Get
            Dim s As New List(Of String)()
            For Each r As DataGridViewRow In dgv.Rows
                s.Add(r.Cells(0).Value.ToString())
            Next
            Return s
        End Get
        Set(value As List(Of String))
            dgv.Rows.Clear()
            If Value IsNot Nothing Then
                For Each s As String In Value
                    dgv.Rows.Add(New Object() {s})
                Next
            End If
        End Set
    End Property

    ''' <summary>
    ''' Add GUID.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnAdd_Click(sender As Object, e As EventArgs)
        Dim row As Integer = dgv.Rows.Add()
        dgv.CurrentCell = dgv.Rows(row).Cells(0)
        dgv.BeginEdit(True)

        ValidateData()
    End Sub

    ''' <summary>
    ''' Remove GUID.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRemove_Click(sender As Object, e As EventArgs)
        For Each row As DataGridViewRow In dgv.SelectedRows
            dgv.Rows.Remove(row)
        Next
        ValidateData()
    End Sub

    ''' <summary>
    ''' Validate each GUID in the data grid view.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ValidateData()
        Dim countOK As Boolean = ((dgv.Rows.Count > 0) AndAlso RequireAtLeastOne) OrElse Not RequireAtLeastOne

        Dim guidsValid As Boolean = True
        If RequireGuids Then
            For Each r As DataGridViewRow In dgv.Rows
                Try
                    Dim g As New Guid(r.Cells(0).Value.ToString())
                    guidsValid = guidsValid AndAlso True
                Catch
                    guidsValid = False
                    Exit Try
                End Try
            Next
        End If

        If countOK AndAlso guidsValid Then
            Me.errorProviderGUID.SetError(Me.dgv, "")
        Else
            Me.errorProviderGUID.SetError(Me.dgv, "Invalid input.")
        End If

        RaiseEvent ValidInputChanged(Me, New EventArgs())
    End Sub

    ''' <summary>
    ''' True if the input is valid given the configured rules.
    ''' </summary>
    ''' <value>Boolean</value>
    Public ReadOnly Property ValidInput() As Boolean
        Get
            If String.IsNullOrEmpty(Me.errorProviderGUID.GetError(Me.dgv)) Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

    ''' <summary>
    ''' Valid Input Changed Event Handler
    ''' </summary>
    ''' <remarks></remarks>
    Public Event ValidInputChanged As EventHandler

    ''' <summary>
    ''' Selecting Changed Event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv_SelectionChanged(sender As Object, e As EventArgs)
        btnRemove.Enabled = dgv.SelectedRows.Count > 0
    End Sub
    ''' <summary>
    ''' Cell End Edit
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dgv_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs)
        If RequireGuids Then
            Try
                Dim g As New Guid(dgv.Rows(e.RowIndex).Cells(0).Value.ToString())
                dgv.Rows(e.RowIndex).Cells(0).Value = g.ToString("D")
            Catch
            End Try
        End If
        ValidateData()
    End Sub
    ''' <summary>
    ''' Loaded the GUIDs.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub GuidCollectionEditor_Load(sender As Object, e As EventArgs)
        ValidateData()
    End Sub
End Class
