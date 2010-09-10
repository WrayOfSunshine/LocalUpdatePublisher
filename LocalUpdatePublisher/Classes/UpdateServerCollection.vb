' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
'UpdateServerCollection
' This class is used to create a collection
' of UpdateServer objects.  We use this to then
' serealize the list of WSUS servers to the settings file.
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 1/28/2010
' Time: 1:33 PM

Public Class UpdateServerCollection
	Inherits CollectionBase
	
	'Add the server.
	Public Sub Add(ByVal value as UpdateServer)
		List.Add(value)
	End Sub
	
	'Return True if the collection contains this server.
	Public Function Contains(ByVal value As UpdateServer) As Boolean
		Return List.Contains(value)
	End Function
	
	'Return this server's index.
	Public Function IndexOf(ByVal value As UpdateServer) As Integer
		Return List.IndexOf(value)
	End Function
	
	'Insert a new server.
	Public Sub Insert(ByVal index As Integer, ByVal value As UpdateServer)
		List.Insert(index, value)
	End Sub
	
	'Return the server at this position.
	Default Public ReadOnly Property Item(ByVal index As Integer) As UpdateServer
		Get
			Return DirectCast(List.Item(index), UpdateServer)
		End Get
	End Property
	
	'Remove the server based on the value.
	Public Sub Remove(ByVal value As UpdateServer)
		List.Remove(value)
	End Sub
	
End Class
