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
	Private _name As String
	Private _xml As String
	
	Sub New()
		'Set defaults.
		_name = ""
		_xml = ""
	End Sub
	
	Sub New(name as String, xml As String)
		'Set defaults.
		_name = name
		_xml = xml
	End Sub
	
	' Property Rule Name.
	Public Property Name() As String
		Get
			Return _name
		End Get
		Set
			_name = value
		End Set
	End Property
	
	' Property Xml.
	Public Property Xml() As String
		Get
			Return _xml
		End Get
		Set
			_xml = value
		End Set
	End Property
End Class
