Option Explicit On
Option Strict On
' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' ComboVendors
' Creates an object that holds an update category
' as well as a string for its name.  This allows us
' to add the object to comboboxes and have the name displayed
' and the target group accessible.
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 11/11/2009
' Time: 3:24 PM

Imports Microsoft.UpdateServices.Administration

Public Class ComboVendors
    Private m_name As String
    ReadOnly Property Name() As String
        Get
            Return m_name
        End Get
    End Property

    Private m_value As IUpdateCategory
    ReadOnly Property Value() As IUpdateCategory
        Get
            Return m_value
        End Get
    End Property

    Public Sub New(value As IUpdateCategory)
        Me.m_name = value.Title
        Me.m_value = value
    End Sub

    Public Overrides Function ToString() As String
        Return m_name
    End Function

End Class
