'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 11/1/2011
' Time: 10:42 AM

Imports System.Data

Public Class RefreshInfo
	Private _treeNodeTag As Object
	Private _originalValue As String
	Private _maintainSelectedRow As Boolean
	Private _dataTable As DataTable
	
	Sub New()
		_treeNodeTag = New Object
		_originalValue = ""
		_maintainSelectedRow = New Boolean
		_dataTable = New DataTable
	End Sub
	
	Sub New(treeNodeTag As Object, originalValue As String, maintainSelectedRow As Boolean)
		_treeNodeTag = treeNodeTag
		_originalValue = originalValue
		_maintainSelectedRow = maintainSelectedRow
	End Sub
	
	Sub New(treeNodeTag As Object, originalValue As String, maintainSelectedRow As Boolean, dataTable As DataTable)
		_treeNodeTag = treeNodeTag
		_originalValue = originalValue
		_maintainSelectedRow = maintainSelectedRow
		_dataTable = dataTable
	End Sub
	
	' Property Tree Node Tag
	Public Property TreeNodeTag() As Object
		Get
			Return _treeNodeTag
		End Get
		Set
			_treeNodeTag = value
		End Set
	End Property
	
	' Property Original Value
	Public Property OriginalValue() As String
		Get
			Return _originalValue
		End Get
		Set
			_originalValue = value
		End Set
	End Property
	
	' Property Maintain Selected Row
	Public Property MaintainSelectedRow() As Boolean
		Get
			Return _maintainSelectedRow
		End Get
		Set
			_maintainSelectedRow = value
		End Set
	End Property
	
	' Property Data Table
	Public Property DataTable() As DataTable
		Get
			Return _dataTable
		End Get
		Set
			_dataTable = value
		End Set
	End Property
End Class
