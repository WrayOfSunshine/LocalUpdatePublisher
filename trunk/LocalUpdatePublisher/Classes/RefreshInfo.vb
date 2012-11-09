Option Explicit On
Option Strict On
' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 11/1/2011
' Time: 10:42 AM

Imports System.Data

Public Class RefreshInfo
    Private m_treeNodeTag As Object
    Private m_originalValue As String
    Private m_maintainSelectedRow As Boolean
    Private m_dataTable As DataTable

    Sub New()
        m_treeNodeTag = New Object
        m_originalValue = ""
        m_maintainSelectedRow = New Boolean
        m_dataTable = New DataTable
    End Sub

    Sub New(treeNodeTag As Object, originalValue As String, maintainSelectedRow As Boolean)
        m_treeNodeTag = treeNodeTag
        m_originalValue = originalValue
        m_maintainSelectedRow = maintainSelectedRow
    End Sub

    Sub New(treeNodeTag As Object, originalValue As String, maintainSelectedRow As Boolean, dataTable As DataTable)
        m_treeNodeTag = treeNodeTag
        m_originalValue = originalValue
        m_maintainSelectedRow = maintainSelectedRow
        m_dataTable = dataTable
    End Sub

    ' Property Tree Node Tag
    Public Property TreeNodeTag() As Object
        Get
            Return m_treeNodeTag
        End Get
        Set(value As Object)
            m_treeNodeTag = value
        End Set
    End Property

    ''' <summary>
    ''' Original Value
    ''' </summary>
    ''' <value>String</value>
    Public Property OriginalValue() As String
        Get
            Return m_originalValue
        End Get
        Set(value As String)
            m_originalValue = value
        End Set
    End Property

    ''' <summary>
    ''' Maintain Selected Row
    ''' </summary>
    ''' <value>Boolean</value>
    ''' <remarks>Indicates if the selected row should be maintained after refresshing the data.</remarks>
    Public Property MaintainSelectedRow() As Boolean
        Get
            Return m_maintainSelectedRow
        End Get
        Set(value As Boolean)
            m_maintainSelectedRow = value
        End Set
    End Property

    ''' <summary>
    ''' Data Table
    ''' </summary>
    ''' <value>DataTable</value>
    Public Property DataTable() As DataTable
        Get
            Return m_dataTable
        End Get
        Set(value As DataTable)
            m_dataTable = value
        End Set
    End Property
End Class
