Option Explicit On
Option Strict On
' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
'UpdateServerCollection
' This class is used to create a collection
' of UpdateServer objects.  We use this to then
' serialize the list of WSUS servers to the settings file.
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 1/28/2010
' Time: 1:33 PM

Public Class UpdateServerCollection
    Inherits CollectionBase

    ''' <summary>
    ''' Add the server.
    ''' </summary>
    ''' <param name="value">UpdateServer to add.</param>
    Public Sub Add(ByVal value As UpdateServer)
        List.Add(value)
    End Sub

    ''' <summary>
    ''' Detect if collection contains UpdateServer.
    ''' </summary>
    ''' <param name="value">UpdateServer to search for.</param>
    ''' <returns>Boolean indicating if vendor object is in the collection.</returns>
    Public Function Contains(ByVal value As UpdateServer) As Boolean
        Return List.Contains(value)
    End Function

    ''' <summary>
    ''' Index of server in the collection.
    ''' </summary>
    ''' <param name="value">UpdateServer object to search for.</param>
    ''' <returns>Intiger representing index of UpdateServer in the collection.</returns>
    ''' <remarks></remarks>
    Public Function IndexOf(ByVal value As UpdateServer) As Integer
        Return List.IndexOf(value)
    End Function

    ''' <summary>
    ''' Insert UpdateServer into collection as a specific index.
    ''' </summary>
    ''' <param name="index">Index to add UpdateServer at.</param>
    ''' <param name="value">UpdateServer to add.</param>
    ''' <remarks></remarks>
    Public Sub Insert(ByVal index As Integer, ByVal value As UpdateServer)
        List.Insert(index, value)
    End Sub

    ''' <summary>
    ''' UpdateServer at given index.
    ''' </summary>
    ''' <param name="index">Index location of server.</param>
    ''' <returns>UpdateServer object at index.</returns>
    Default Public ReadOnly Property Item(ByVal index As Integer) As UpdateServer
        Get
            Return DirectCast(List.Item(index), UpdateServer)
        End Get
    End Property

    ''' <summary>
    ''' Remove UpdateServer.
    ''' </summary>
    ''' <param name="value">UpdateServer to remove.</param>
    ''' <remarks></remarks>
    Public Sub Remove(ByVal value As UpdateServer)
        List.Remove(value)
    End Sub

End Class
