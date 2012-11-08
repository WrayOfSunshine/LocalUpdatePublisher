Option Explicit On
Option Strict On
' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
'Custom Tab Control
' Provides a tab control with the ability to hide the tab labels
' which allows the tab to be used in a wizard-like fashion.
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 11/1/2009
' Time: 9:06 PM
'
' This class is directly based off of Mick Doherty class published here:
' http://dotnetrix.co.uk/tabcontrol.htm

Imports System.ComponentModel

<ToolboxBitmap(GetType(System.Windows.Forms.TabControl))> _
	Public Class CustomTabControl
	Inherits System.Windows.Forms.TabControl
	
	Private _hideTabs As Boolean
	
	<DefaultValue(False), RefreshProperties(RefreshProperties.All)> _
		Public Property HideTabs() As Boolean
		Get
			Return _hideTabs
		End Get
		Set(ByVal value As Boolean)
			If _hideTabs = Value Then Return
			_hideTabs = Value
			If value = True Then Me.Multiline = True
			Me.UpdateStyles()
		End Set
	End Property
	
	<RefreshProperties(RefreshProperties.All)> _
		Public Overloads Property Multiline() As Boolean
		Get
			If Me.HideTabs Then Return True
			Return MyBase.Multiline
		End Get
		Set(ByVal value As Boolean)
			If Me.HideTabs Then
				MyBase.Multiline = True
			Else
				MyBase.Multiline = value
			End If
		End Set
	End Property
	
	Public Overrides ReadOnly Property DisplayRectangle() As System.Drawing.Rectangle
		Get
			If Me.HideTabs Then
				Return New Rectangle(0, 0, Width, Height)
			Else
				Dim tabStripHeight, itemHeight As Int32
				
				If Me.Alignment <= TabAlignment.Bottom Then
					itemHeight = Me.ItemSize.Height
				Else
					itemHeight = Me.ItemSize.Width
				End If
				
				If Me.Appearance = TabAppearance.Normal Then
					tabStripHeight = 5 + (itemHeight * Me.RowCount)
				Else
					tabStripHeight = (3 + itemHeight) * Me.RowCount
				End If
				Select Case Me.Alignment
					Case TabAlignment.Top
						Return New Rectangle(4, tabStripHeight, Width - 8, Height - tabStripHeight - 4)
					Case TabAlignment.Bottom
						Return New Rectangle(4, 4, Width - 8, Height - tabStripHeight - 4)
					Case TabAlignment.Left
						Return New Rectangle(tabStripHeight, 4, Width - tabStripHeight - 4, Height - 8)
					Case TabAlignment.Right
						Return New Rectangle(4, 4, Width - tabStripHeight - 4, Height - 8)
				End Select
			End If
		End Get
	End Property
	
End Class
	
                    