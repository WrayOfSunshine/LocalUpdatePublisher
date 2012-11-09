Option Explicit On
Option Strict On
' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' Rule Collection Class
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

    Private Shared m_openFileDialog As OpenFileDialog = New OpenFileDialog
    Private Shared m_saveFileDialog As SaveFileDialog = New SaveFileDialog


#Region "Static Methods"

    ''' <summary>
    ''' Prompt for file name and import rules.
    ''' </summary>
    ''' <returns>RulesCollection</returns>
    Public Shared Function ImportRules() As RuleCollection
        m_openFileDialog.Filter = Globals.globalRM.GetString("file_filter_xml")
        m_saveFileDialog.FilterIndex = 1
        If m_openFileDialog.ShowDialog = DialogResult.OK Then
            Return ImportRules(m_openFileDialog.FileName)
        Else
            Return Nothing
        End If

    End Function

    ''' <summary>
    ''' Loads a serialized instance of the rule collection from the specified file
    '''  returns default values if the file doesn't exist or an error occurs.
    ''' </summary>
    ''' <param name="path">Path to XML file containing rules.</param>
    ''' <returns>RuleCollection</returns>
    Public Shared Function ImportRules(path As String) As RuleCollection
        Dim ruleCollection As RuleCollection = New RuleCollection
        Dim xs As New XmlSerializer(GetType(RuleCollection))

        If File.Exists(path) Then
            Dim fs As FileStream = Nothing

            'Try to open the file.
            Try
                fs = File.Open(path, FileMode.Open, FileAccess.Read)
            Catch
                MsgBox(Globals.globalRM.GetString("error_rulecollection_file_open"))
            End Try

            'Try to cast the import file to a rule collection.
            Try
                ruleCollection = DirectCast(xs.Deserialize(fs), RuleCollection)
            Catch
                MsgBox(Globals.globalRM.GetString("error_rulecollection_cast"))
                ruleCollection = Nothing
            Finally
                fs.Close()
            End Try
        Else
            MsgBox(Globals.globalRM.GetString("error_rulecollection_import_file_exist"))
        End If

        Return ruleCollection
    End Function

    ''' <summary>
    ''' Prompt for export file name and export rules.
    ''' </summary>
    ''' <param name="ruleCollection">RuleCollection</param>
    Public Shared Sub ExportRules(ruleCollection As RuleCollection)
        m_saveFileDialog.Filter = Globals.globalRM.GetString("file_filter_xml")
        m_saveFileDialog.FilterIndex = 1
        m_saveFileDialog.DefaultExt = ".xml"
        If m_saveFileDialog.ShowDialog = DialogResult.OK Then
            ExportRules(m_saveFileDialog.FileName, ruleCollection)
        End If
    End Sub

    ''' <summary>
    ''' Persists the rules to the specified filename.
    ''' </summary>
    ''' <param name="path">Path to XML file to export to.</param>
    ''' <param name="ruleCollection">RuleCollection to export to.</param>
    Public Shared Sub ExportRules(path As String, ruleCollection As RuleCollection)
        Dim fs As FileStream = Nothing
        Dim xs As New XmlSerializer(GetType(RuleCollection))

        fs = File.Open(path, FileMode.Create, FileAccess.Write)

        Try
            xs.Serialize(fs, ruleCollection)
        Finally
            fs.Close()
        End Try
    End Sub

#End Region

    ''' <summary>
    ''' Add the rule.
    ''' </summary>
    ''' <param name="value">Rule to add.</param>
    Public Sub Add(ByVal value As Rule)
        List.Add(value)
    End Sub

    ''' <summary>
    ''' Return True if the collection contains this rule.
    ''' </summary>
    ''' <param name="value">Rule to search for.</param>
    ''' <returns>Boolean indicating if the collection contains the rule.</returns>
    Public Function Contains(ByVal value As Rule) As Boolean
        Return List.Contains(value)
    End Function

    ''' <summary>
    ''' Return True if the collection contains this rule name
    ''' </summary>
    ''' <param name="value">Name of rule.</param>
    ''' <returns>Boolean indicating if the collection contains the rule.</returns>
    Public Function Contains(ByVal value As String) As Boolean
        Dim tmpBool As Boolean = False
        For Each tmpRule As Rule In List
            If tmpRule.Name = value Then tmpBool = True
        Next
        Return tmpBool
    End Function

    ''' <summary>
    ''' Return this rule's index.
    ''' </summary>
    ''' <param name="value">Rule to search for.</param>
    ''' <returns>Integer</returns>
    Public Function IndexOf(ByVal value As Rule) As Integer
        Return List.IndexOf(value)
    End Function

    ''' <summary>
    ''' Insert a new server.
    ''' </summary>
    ''' <param name="index">Index to insert at.</param>
    ''' <param name="value">UpdateServer to insert.</param>
    ''' <remarks></remarks>
    Public Sub Insert(ByVal index As Integer, ByVal value As UpdateServer)
        List.Insert(index, value)
    End Sub

    ''' <summary>
    ''' Return the rule at this position.
    ''' </summary>
    ''' <param name="index">Index of Rule to retrieve.</param>
    ''' <value>Rule</value>
    Default Public ReadOnly Property Item(ByVal index As Integer) As Rule
        Get
            Return DirectCast(List.Item(index), Rule)
        End Get
    End Property

    ''' <summary>
    ''' Remove the rule based on the value.
    ''' </summary>
    ''' <param name="value">Rule to remove.</param>
    Public Sub Remove(ByVal value As Rule)
        List.Remove(value)
    End Sub

End Class
