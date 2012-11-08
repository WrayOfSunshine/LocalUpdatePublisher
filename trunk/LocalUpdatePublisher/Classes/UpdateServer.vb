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
	Private _name As String
	Private _port As Integer
	Private _ssl As Boolean
	Private _childServer As Boolean
	Private _replicaServer as Boolean
	
	Sub New()
		'Set defaults.
		_name = ""
		_port = 80
		_ssl = False
		_childServer = False
		_replicaServer = False
		
	End Sub
	
	Sub New (name As String, port As Integer, ssl As Boolean, childServer As Boolean, replicaServer As Boolean)
		'Set defaults.
		_name = name
		_port = port
		_ssl = ssl
		_childServer = childServer
		_replicaServer = replicaServer
	End Sub
	
	
	' Property Server Name
	Public Property Name() As String
		Get
			Return _name
		End Get
		Set
			_name = value
		End Set
	End Property
	
	' Property Port Number
	Public Property Port() As Integer
		Get
			Return _port
		End Get
		Set
			_port = value
		End Set
	End Property
	
	' Property use SSL
	Public Property Ssl() As Boolean
		Get
			Return _ssl
		End Get
		Set
			_ssl = value
		End Set
	End Property
	
	' Property ChildServer
	Public Property ChildServer() As Boolean
		Get
			Return _childServer
		End Get
		Set
			_childServer = value
		End Set
	End Property
	
	' Property ChildServer
	Public Property ReplicaServer() As Boolean
		Get
			Return _replicaServer
		End Get
		Set
			_replicaServer = value
		End Set
	End Property
	
End Class
