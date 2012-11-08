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
	Private _name As String
	ReadOnly Property Name() As String
		Get
			Return _name
		End Get
	End Property
	
	Private _value As IUpdateCategory
	ReadOnly Property Value()  As IUpdateCategory
		Get
			Return _value
		End Get
	End Property
	
	Public Sub New(value As IUpdateCategory)
		Me._name = value.Title
		Me._value = value
	End Sub		
	
	Public Overrides Function ToString() As String
		Return _name
	End Function	
	
End Class
