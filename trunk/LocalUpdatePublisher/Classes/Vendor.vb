Option Explicit On
Option Strict On
' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
'Vendor
' This class is used to create a vendor object
' that holds a collection containing their products.
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 1/28/2010
' Time: 1:33 PM
Public Class Vendor
	Private _name As String
	Private _products As Collections.Generic.List(Of String)
	
	Sub New
		_name = ""
		_products = New Collections.Generic.List(Of String)
	End Sub
	
	Sub New ( name As String )
		_name = name
		_products = New Collections.Generic.List(Of String)
	End Sub
	
	Sub New( name As String, products As Collections.Generic.List(Of String))
		_name = name
		_products = products
	End Sub
	
	' Property Vendor Name
	Public Property Name() As String
		Get
			Return _name
		End Get
		Set
			_name = value
		End Set
	End Property
	
	' Property Products
	Public Property Products() As Collections.Generic.List(Of String)
		Get
			Return _products
		End Get
		Set
			_products = value
		End Set
	End Property
	
End Class

