' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
'DataGridViewState
' This custom object saves the state of a given DGV.
' We use this to save and load the state from the
' settings file.
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 1/29/2010
' Time: 8:44 AM

Imports System.ComponentModel

Public Class DataGridViewState
		Private _name As String
	Private _sortColumn As String
	Private _sortDirection As ListSortDirection
	Private _columnFillWeights() As Integer
	
	Sub New()
		'Set defaults.
		_name = Nothing
		_sortColumn = "0"
		_sortDirection = ListSortDirection.Descending
		_columnFillWeights = New Integer(){0}
		
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
	Public Property SortColumn() As String
		Get
			Return _sortColumn
		End Get
		Set
			_sortColumn = value
		End Set
	End Property
	
	' Property use SSL
	Public Property SortDirection() As ListSortDirection
		Get
			Return _sortDirection
		End Get
		Set
			_sortDirection = value
		End Set
	End Property
	
	' Property ChildServer
	Public Property ColumnFillWeights() As Integer()
		Get
			Return _columnFillWeights
		End Get
		Set
			_columnFillWeights = value
		End Set
	End Property
End Class
