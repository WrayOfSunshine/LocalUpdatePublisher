Option Explicit On
Option Strict On
' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' ComboTargetGroup
' Creates an object that holds a Computer Target Group
' as well as a string for its name.  This allows us
' to add the object to comboboxes and have the name displayed
' and the target group accessible.
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 11/11/2009
' Time: 3:24 PM

Imports Microsoft.UpdateServices.Administration

Public Class ComboTargetGroups
	Private _name As String
	ReadOnly Property Name() As String
		Get
			Return _name
		End Get
	End Property
	
	Private _value As IComputerTargetGroup
	ReadOnly Property Value()  As IComputerTargetGroup
		Get
			Return _value
		End Get
	End Property
	
	Public Sub New(value As IComputerTargetGroup)
		Me._name = value.Name
		Me._value = value
	End Sub
		
	Public Sub New(value As IComputerTargetGroup, depth as Integer)
		Me._name = GetComboIndentation(depth) & value.Name
		Me._value = value
	End Sub
	
	Public Overrides Function ToString() As String
		Return _name
	End Function
	
	Private Function GetComboIndentation (depth As Integer) As String
		Dim tmpStr As String = ""
		For i As Integer = 0 To depth
			tmpStr += "   "
		Next
		Return tmpStr
	End Function
	
	
End Class
