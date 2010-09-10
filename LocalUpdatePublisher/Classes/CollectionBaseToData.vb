' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
'CollectionBaseToData
' This class automates the process of converting a collection
' into a data set or data table.  This is useful for using these
' collections in a data grid view.
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 11/1/2009
' Time: 9:06 PM
'
' This class is directly based off of Okta Endy class published here:
' http://www.codeproject.com/KB/grid/collectionbasetodataset.aspx


Imports System
Imports System.Data
Imports System.Reflection
Imports System.Collections


Public Class CollectionBaseToData
	Private _collectionBaseData As CollectionBase
	
	Public Sub New(ByVal data As CollectionBase)
		_collectionBaseData = data
	End Sub
	Private _PropertyInfos As PropertyInfo()' = Nothing
	
	Private ReadOnly Property PropertyInfos() As PropertyInfo()
		Get
			If _PropertyInfos Is Nothing Then
				_PropertyInfos = GetPropertyInfo
			End If
			Return _PropertyInfos
		End Get
	End Property
	
	Private Function GetPropertyInfo() As PropertyInfo()
		If _collectionBaseData.Count > 0 Then
			Dim propertyEnumerator As IEnumerator = _collectionBaseData.GetEnumerator
			propertyEnumerator.MoveNext()
			Return propertyEnumerator.Current.GetType.GetProperties
		End If
		Return Nothing
	End Function
	
	Private Function CreateDataTable() As DataTable
		Dim collectionDataTable As DataTable = New DataTable("GridDataTable")
		collectionDataTable.Locale = System.Globalization.CultureInfo.CurrentCulture
		For Each dataProperty As PropertyInfo In PropertyInfos
			Dim dataType as Type = dataProperty.PropertyType
			collectionDataTable.Columns.Add(dataProperty.Name.ToString(),dataType)
		Next
		Return collectionDataTable
	End Function
	
	Private Function CreateDataSet() As DataSet
		Dim collectionDataSet As DataSet = New DataSet("GridDataSet")
		collectionDataSet.Locale = System.Globalization.CultureInfo.CurrentCulture
		collectionDataSet.Tables.Add(FillDataTable)
		Return collectionDataSet
	End Function
	
	Private Function FillDataRow(ByVal row As DataRow, ByVal data As Object) As DataRow
		Dim dataType as Type
		For Each dataPropertyInfo As PropertyInfo In PropertyInfos
			'If the value is null then set type to String
			If dataPropertyInfo.GetValue(data,Nothing) Is Nothing Then
				dataType = GetType(String)
			Else
				dataType = dataPropertyInfo.GetValue(data,Nothing).GetType
			End If
			
			row(dataPropertyInfo.Name.ToString) = Convert.ChangeType(dataPropertyInfo.GetValue(data,Nothing), _
			                                                         dataType, _
			                                                         System.Globalization.CultureInfo.CurrentCulture)
		Next
		Return row
	End Function
	
	Private Function FillDataTable() As DataTable
		Dim dataCollectionBase As CollectionBase = CType(_collectionBaseData, CollectionBase)
		Dim dataEnumerator As IEnumerator = dataCollectionBase.GetEnumerator
		Dim collectionDataTable As DataTable = CreateDataTable
		While dataEnumerator.MoveNext
			collectionDataTable.Rows.Add(FillDataRow(collectionDataTable.NewRow, dataEnumerator.Current))
		End While
		Return collectionDataTable
	End Function
	
	Public Function ToDataSet() As DataSet
		Return CreateDataSet
	End Function
	
	Public Function ToDataTable() As DataTable
		Return FillDataTable
	End Function
End Class

