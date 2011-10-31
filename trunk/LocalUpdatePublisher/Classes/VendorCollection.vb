'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 9/24/2010
' Time: 9:46 AM
'
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Public Class VendorCollection
	Inherits CollectionBase
	
	'Add the server.
	Public Sub Add(ByVal value as Vendor)
		List.Add(value)
	End Sub
	
	'Return True if the collection contains this server.
	Public Function Contains(ByVal value As Vendor) As Boolean
		Return List.Contains(value)
	End Function
	
	'Return True if the collection contains this vendor.
	Public Function Contains(ByVal value As String) As Boolean
		For Each tmpVendor As Vendor In List
			If tmpVendor.Name.ToUpper = value.ToUpper
				Return True
			End If
		Next
		Return False
	End Function
	
	'Return this vendor's index.
	Public Function IndexOf(ByVal value As Vendor) As Integer
		Return List.IndexOf(value)
	End Function
	
	'Insert a new vendor.
	Public Sub Insert(ByVal index As Integer, ByVal value As Vendor)
		List.Insert(index, value)
	End Sub
	
	'Return the vendor at this position.
	Default Public ReadOnly Property Item(ByVal index As Integer) As Vendor
		Get
			Return DirectCast(List.Item(index), Vendor)
		End Get
	End Property
	
	'Return the vendor with this name.
	Default Public ReadOnly Property Item(ByVal index As String) As Vendor
		Get
			For Each tmpVendor As Vendor In List
				If tmpVendor.Name.ToUpper = index.ToUpper
					Return tmpVendor
				End If
			Next
			Return Nothing
		End Get
	End Property
	
	'Remove the vendor based on the value.
	Public Sub Remove(ByVal value As Vendor)
		List.Remove(value)
	End Sub
	
End Class
