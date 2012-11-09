Option Explicit On
Option Strict On
' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' Rule Class
' The rule class is a simple class to create a rule object.
'
' Created by SharpDevelop.
' User: Bryan
' Date: 2/11/2010
' Time: 8:27 PM

Public Class Rule
    Private m_name As String
    Private m_xml As String

    Sub New()
        'Set defaults.
        m_name = ""
        m_xml = ""
    End Sub

    Sub New(name As String, xml As String)
        'Set defaults.
        m_name = name
        m_xml = xml
    End Sub

    ''' <summary>
    ''' Rule name.
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
    ''' XML
    ''' </summary>
    ''' <value>String</value>
    Public Property Xml() As String
        Get
            Return m_xml
        End Get
        Set(value As String)
            m_xml = value
        End Set
    End Property
End Class
