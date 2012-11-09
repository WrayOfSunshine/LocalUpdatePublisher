Option Explicit On
Option Strict On
' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
'DataGridViewState
' This custom object saves the state of a given DGV.
' We use this to save and load the state from the
' settings file.
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 1/29/2010
' Time: 8:44 AM
Imports System.ComponentModel

Public Class DataGridViewState
    Private m_name As String
    Private m_sortColumn As String
    Private m_sortDirection As ListSortDirection
    Private m_columnFillWeights() As Integer

    Sub New()
        'Set defaults.
        m_name = Nothing
        m_sortColumn = "0"
        m_sortDirection = ListSortDirection.Descending
        m_columnFillWeights = New Integer() {0}

    End Sub

    Sub New(dgv As DataGridView)

        m_name = dgv.Name

        'Set the sort column and order
        If dgv.SortedColumn Is Nothing Then
            m_sortColumn = ""
            m_sortDirection = ListSortDirection.Descending
        Else
            m_sortColumn = dgv.SortedColumn.Name


            If dgv.SortOrder = SortOrder.Ascending Then
                Globals.appSettings.StateMainComputersDGV.SortDirection = ListSortDirection.Ascending
            ElseIf dgv.SortOrder = SortOrder.Descending Then
                Globals.appSettings.StateMainComputersDGV.SortDirection = ListSortDirection.Descending
            End If
        End If

        'Save the dgv's columns to a temporary array.
        m_columnFillWeights = New Integer(dgv.Columns.Count - 1) {}
        For Each column As DataGridViewColumn In dgv.Columns
            m_columnFillWeights(column.Index) = CInt(column.FillWeight)
        Next
    End Sub

    ''' <summary>
    ''' DataGridView Name
    ''' </summary>
    ''' <value>String</value>
    Public Property Name() As String
        Get
            Return m_name
        End Get
        Set(value As String)
            m_name = value
        End Set
    End Property

    ''' <summary>
    ''' Sort Column Name
    ''' </summary>
    ''' <value>String</value>
    Public Property SortColumn() As String
        Get
            Return m_sortColumn
        End Get
        Set(value As String)
            m_sortColumn = value
        End Set
    End Property

    ''' <summary>
    ''' Sort Direction
    ''' </summary>
    ''' <value>ListSortDirection</value>
    Public Property SortDirection() As ListSortDirection
        Get
            Return m_sortDirection
        End Get
        Set(value As ListSortDirection)
            m_sortDirection = value
        End Set
    End Property

    ''' <summary>
    ''' Column Fill Weights
    ''' </summary>
    ''' <value>Integer Array</value>
    Public Property ColumnFillWeights() As Integer()
        Get
            Return m_columnFillWeights
        End Get
        Set(value As Integer())
            m_columnFillWeights = value
        End Set
    End Property
End Class
