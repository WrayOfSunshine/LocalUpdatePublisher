Option Explicit On
Option Strict On
' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
'UpdateServer
' This class is used to create a simple server object
' that can be used to connect to a WSUS server.  We also
' use these objects to save the data to the settings file.
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 1/28/2010
' Time: 1:33 PM

Public Class UpdateServer
    Private m_name As String
    Private m_port As Integer
    Private m_ssl As Boolean
    Private m_childServer As Boolean
    Private m_replicaServer As Boolean

    Sub New()
        'Set defaults.
        m_name = ""
        m_port = 80
        m_ssl = False
        m_childServer = False
        m_replicaServer = False

    End Sub

    Sub New(name As String, port As Integer, ssl As Boolean, childServer As Boolean, replicaServer As Boolean)
        'Set defaults.
        m_name = name
        m_port = port
        m_ssl = ssl
        m_childServer = childServer
        m_replicaServer = replicaServer
    End Sub


    ''' <summary>
    ''' Server Name
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
    ''' Port Number
    ''' </summary>
    ''' <value>Integer</value>
    Public Property Port() As Integer
        Get
            Return m_port
        End Get
        Set(value As Integer)
            m_port = value
        End Set
    End Property

    ''' <summary>
    ''' SSL
    ''' </summary>
    ''' <value>Boolean</value>
    ''' <remarks>Indicates if connection should use SSL.</remarks>
    Public Property Ssl() As Boolean
        Get
            Return m_ssl
        End Get
        Set(value As Boolean)
            m_ssl = value
        End Set
    End Property

    ''' <summary>
    ''' Child Server
    ''' </summary>
    ''' <value>Boolean</value>
    Public Property ChildServer() As Boolean
        Get
            Return m_childServer
        End Get
        Set(value As Boolean)
            m_childServer = value
        End Set
    End Property

    ''' <summary>
    ''' Replica Server
    ''' </summary>
    ''' <value>Boolean</value>
    Public Property ReplicaServer() As Boolean
        Get
            Return m_replicaServer
        End Get
        Set(value As Boolean)
            m_replicaServer = value
        End Set
    End Property

End Class
