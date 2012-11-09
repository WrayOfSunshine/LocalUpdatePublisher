Option Explicit On
Option Strict On
' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' ComboTargetGroup
' Creates an object that holds a Computer Target Group
' as well as a string for its name.  This allows us
' to add the object to comboboxes and have the name displayed
' and the target group accessible.
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 11/11/2009
' Time: 3:24 PM

Imports Microsoft.UpdateServices.Administration

Public Class ComboTargetGroups
    Private m_name As String
    ReadOnly Property Name() As String
        Get
            Return m_name
        End Get
    End Property

    Private m_value As IComputerTargetGroup
    ReadOnly Property Value() As IComputerTargetGroup
        Get
            Return m_value
        End Get
    End Property

    Public Sub New(value As IComputerTargetGroup)
        Me.m_name = value.Name
        Me.m_value = value
    End Sub

    Public Sub New(value As IComputerTargetGroup, depth As Integer)
        Me.m_name = GetComboIndentation(depth) & value.Name
        Me.m_value = value
    End Sub

    Public Overrides Function ToString() As String
        Return m_name
    End Function
    ''' <summary>
    ''' Get indentation for the combobox item.
    ''' </summary>
    ''' <param name="depth"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetComboIndentation(depth As Integer) As String
        Dim tmpStr As String = ""
        For i As Integer = 0 To depth
            tmpStr += "   "
        Next
        Return tmpStr
    End Function


End Class
