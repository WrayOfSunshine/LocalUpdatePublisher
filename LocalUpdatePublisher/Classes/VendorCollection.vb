Option Explicit On
Option Strict On
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 9/24/2010
' Time: 9:46 AM
Public Class VendorCollection
    Inherits CollectionBase

    ''' <summary>
    ''' Add the server.
    ''' </summary>
    ''' <param name="value">Vendor object to be added.</param>
    Public Sub Add(ByVal value As Vendor)
        List.Add(value)
    End Sub

    ''' <summary>
    ''' Detect if collection contains vendor.
    ''' </summary>
    ''' <param name="value">Vendor object to be found.</param>
    ''' <returns>Boolean indicated if vendor was found.</returns>
    Public Function Contains(ByVal value As Vendor) As Boolean
        Return List.Contains(value)
    End Function

    'Return True if the collection contains this vendor.
    Public Function Contains(ByVal value As String) As Boolean
        For Each tmpVendor As Vendor In List
            If tmpVendor.Name.ToUpper = value.ToUpper Then
                Return True
            End If
        Next
        Return False
    End Function

    ''' <summary>
    ''' Return vendor index.
    ''' </summary>
    ''' <param name="value">Vendor object.</param>
    ''' <returns>Integer represending index of vender.</returns>
    Public Function IndexOf(ByVal value As Vendor) As Integer
        Return List.IndexOf(value)
    End Function

    ''' <summary>
    ''' Insert a new vendor.
    ''' </summary>
    ''' <param name="index">Index to insert at.</param>
    ''' <param name="value">Vendor object to insert.</param>
    Public Sub Insert(ByVal index As Integer, ByVal value As Vendor)
        List.Insert(index, value)
    End Sub

    ''' <summary>
    ''' Return the vendor object at given index.
    ''' </summary>
    ''' <param name="index">Index of vendor object to return.</param>
    ''' <returns>Vendor object.</returns>
    ''' <remarks></remarks>
    Default Public ReadOnly Property Item(ByVal index As Integer) As Vendor
        Get
            Return DirectCast(List.Item(index), Vendor)
        End Get
    End Property

    ''' <summary>
    ''' Return the vendor with given name.
    ''' </summary>
    ''' <param name="index">Vendor name to find.</param>
    ''' <returns>Vendor object.</returns>
    Default Public ReadOnly Property Item(ByVal index As String) As Vendor
        Get
            For Each tmpVendor As Vendor In List
                If tmpVendor.Name.ToUpper = index.ToUpper Then
                    Return tmpVendor
                End If
            Next
            Return Nothing
        End Get
    End Property

    ''' <summary>
    ''' Remove vendor.
    ''' </summary>
    ''' <param name="value">Vendor to remove.</param>
    Public Sub Remove(ByVal value As Vendor)
        List.Remove(value)
    End Sub

End Class
