' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' Rule Collection Clas
' A simple collection class to hold a collection of rule objects.
'
' Created by SharpDevelop.
' User: Bryan
' Date: 2/11/2010
' Time: 8:30 PM

Imports System.Xml.Serialization
Imports System.IO

<Serializable> _
	Public Class RuleCollection
	Inherits CollectionBase
	
	Private Shared openFileDialog As OpenFileDialog = New OpenFileDialog
	Private Shared saveFileDialog As SaveFileDialog = New SaveFileDialog
	
	
	#Region "Static Methods"
	
	'Prompt for file name and import rules.
	Public Shared Function ImportRules() As RuleCollection
		openFileDialog.Filter = "XML Files|*.xml"
		saveFileDialog.FilterIndex = 1
		If openFileDialog.ShowDialog = DialogResult.OK Then
			Return ImportRules(openFileDialog.FileName)
		Else
			Return Nothing
		End If
		
	End Function
	
	'Loads a serialized instance of the rule collection from the specified file
	' returns default values if the file doesn't exist or an error occurs.
	Public Shared Function ImportRules(filePath As String) As RuleCollection
		Dim ruleCollection As RuleCollection = New RuleCollection
		Dim xs As New XmlSerializer(GetType(RuleCollection))
		
		If File.Exists(filePath) Then
			Dim fs As FileStream = Nothing
			
			'Try to open the file.
			Try
				fs = File.Open(filePath, FileMode.Open, FileAccess.Read)
			Catch
				Msgbox ("Could not import rule file.")
			End Try
			
			'Try to cast the import file to a rule collection.
			Try
				ruleCollection = DirectCast(xs.Deserialize(fs), RuleCollection)
			Catch
				Msgbox ("Could not cast import rule file to rule collection.")
				ruleCollection = Nothing
			Finally
				fs.Close()
			End Try
		Else
			Msgbox ("The import file does not exist.")
		End If
		
		Return ruleCollection
	End Function
	
	'Prompt for export file name and export rules.
	Public Shared Sub ExportRules(ruleCollection As RuleCollection)
		saveFileDialog.Filter = "XML Files|*.xml"
		saveFileDialog.FilterIndex = 1
		saveFileDialog.DefaultExt = ".xml"
		If saveFileDialog.ShowDialog = DialogResult.OK Then
				ExportRules(saveFileDialog.FileName, ruleCollection)
		End If
	End Sub
	
	'Persists the rules to the specified filename.
	Public Shared Sub ExportRules(filePath As String, ruleCollection As RuleCollection)
		Dim fs As FileStream = Nothing
		Dim xs As New XmlSerializer(GetType(RuleCollection))
		
		fs = File.Open(filePath, FileMode.Create, FileAccess.Write)
		
		Try
			xs.Serialize(fs, ruleCollection)
		Finally
			fs.Close()
		End Try
	End Sub
	
	#END Region
	
	'Add the rule.
	Public Sub Add(ByVal value as Rule)
		List.Add(value)
	End Sub
	
	'Return True if the collection contains this rule.
	Public Function Contains(ByVal value As Rule) As Boolean
		Return List.Contains(value)
	End Function
	
	'Return True if the collection contains this rule name.
	Public Function Contains(ByVal value As String) As Boolean
		Dim tmpBool As Boolean = False
		For Each tmpRule As Rule In List
			If tmpRule.Name = value Then tmpBool = True
		Next
		Return tmpBool
	End Function
	
	'Return this rule's index.
	Public Function IndexOf(ByVal value As Rule) As Integer
		Return List.IndexOf(value)
	End Function
	
	'Insert a new server.
	Public Sub Insert(ByVal index As Integer, ByVal value As UpdateServer)
		List.Insert(index, value)
	End Sub
	
	'Return the rule at this position.
	Default Public ReadOnly Property Item(ByVal index As Integer) As Rule
		Get
			Return DirectCast(List.Item(index), Rule)
		End Get
	End Property
	
	'Remove the rule based on the value.
	Public Sub Remove(ByVal value As Rule)
		List.Remove(value)
	End Sub
	
End Class
