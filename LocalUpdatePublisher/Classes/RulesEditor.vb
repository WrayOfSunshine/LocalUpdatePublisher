' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' Represents the Rule Collection Editor
'
' Created by SharpDevelop.
' User: kdixon
' Date: 10/2/2010
' Time: 11:10 AM
' Factored out of UpdateForm originally developed by BRD.

Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Xml

Public Partial Class RulesEditor
	Inherits UserControl
	Private _beginAnd As String
	Private _endAnd As String
	Private _beginOr As String
	Private _endOr As String
	Private _addGroup As String
	Private _removeAnd As String
	Private _removeOr As String
	
	Public Sub New()
		InitializeComponent()
		
		_beginAnd = globalRM.GetString("group_begin_and")
		_endAnd = globalRM.GetString("group_end_and")
		_beginOr = globalRM.GetString("group_begin_or")
		_endOr = globalRM.GetString("group_end_or")
		_addGroup = globalRM.GetString("group")
		_removeAnd = globalRM.GetString("group_remove_and")
		_removeOr = globalRM.GetString("group_remove_or")
	End Sub
	
	#Region "Properties and Accessors"
	
	'Instructional text to appear at the top.
	Public Property Instructions() As String
		Get
			Return lbl_instructions.Text
		End Get
		Set
			lbl_instructions.Text = value
		End Set
	End Property
	
	'Title of this rule builder.
	Public Property Title() As String
		Get
			Return lbl_title.Text
		End Get
		Set
			lbl_title.Text = value
		End Set
	End Property
	
	'The title that goes under the main rule builder.
	Public Property TitleItemLevel() As String
		Get
			Return lbl_xml.Text
		End Get
		Set
			lbl_xml.Text = value
		End Set
	End Property
	
	'Number of rules listed.
	Public ReadOnly Property Count() As Integer
		Get
			Return dgv_rules.Rows.Count
		End Get
	End Property
	
	'The item applicability rule.
	Public Property ApplicabilityRule() As String
		Get
			Return tb_xml.Text
		End Get
		Set
			'TODO more stuff here
			tb_xml.Text = value
		End Set
	End Property
	
	'If the item applicability rule was edited manually.
	Public ReadOnly Property ApplicabilityRuleEdited() As Boolean
		Get
			If tb_xml.ReadOnly Then
				Return False
			Else
				Return True
			End If
		End Get
	End Property
	
	'The rule the editor is representing.
	Public Property Rule() As String
		Get
			Dim tmpStringBuilder As New StringBuilder()
			If Me.Count > 1 Then
				tmpStringBuilder.Append("<lar:And>")
			End If
			
			For Each row As DataGridViewRow In dgv_rules.Rows
				tmpStringBuilder.Append(row.Cells(1).Value.ToString())
			Next
			
			If Me.Count > 1 Then
				tmpStringBuilder.Append("</lar:And>")
			End If
			
			Return tmpStringBuilder.ToString()
		End Get
		Set
			LoadRules(value)
		End Set
	End Property
	
	Private _ruleEditorTitle As String
	Public Property RuleEditorTitle As String
		Get
			Return _ruleEditorTitle
		End Get
		Set
			_ruleEditorTitle = value
		End Set
	End Property
	
	
	#End Region
	
	#REGION "Implementation"
	'This routine receives a fragment of XML.  It parses the
	' XML into WSUS rules and loads them into the DGV.
	Public Sub LoadRules(xmlFragment As String)
		
		'Make sure we have at least two columns in our datagridview and that
		' the xmlFragment isn't empty.
		If (dgv_rules.Columns.Count < 2) OrElse (xmlFragment Is Nothing) Then
			Return
		End If
		
		
		'This boolean tracks if we need to read a line.
		Dim needRead As Boolean = False
		
		'Setup the namespace and add the lar and bar namespaces.
		Dim nsmgr As New XmlNamespaceManager(New NameTable())
		nsmgr.AddNamespace("lar", "http://schemas.microsoft.com/wsus/2005/04/CorporatePublishing/LogicalApplicabilityRules.xsd")
		nsmgr.AddNamespace("bar", "http://schemas.microsoft.com/wsus/2005/04/CorporatePublishing/BaseApplicabilityRules.xsd")
		nsmgr.AddNamespace("msiar", "http://schemas.microsoft.com/wsus/2005/04/CorporatePublishing/MsiApplicabilityRules.xsd")
		
		'Create the XmlParserContext.
		Dim context As New XmlParserContext(Nothing, nsmgr, Nothing, XmlSpace.[Default])
		
		'Create the XmlTextReader and set whitespace handling to none.
		Dim xmlReader As XmlTextReader = New XmlTextReader(xmlFragment, XmlNodeType.Element, context)
		xmlReader.WhitespaceHandling = WhitespaceHandling.None
		
		'See if the first element is an And element.  If so then change the xml reader to
		' use the InnerXML so that the first surrounding And gets ignored.
		xmlReader.Read()
		If xmlReader.LocalName = "And" Then
			xmlReader = New XmlTextReader(xmlReader.ReadInnerXml(), XmlNodeType.Element, context)
			needRead = True
		Else
			'We have already read the first element so we don't need a read
			needRead = False
		End If
		
		'Set whitespace handling to ignore whitespace.
		xmlReader.WhitespaceHandling = WhitespaceHandling.None
		
		'Use this integer to track the indentation depth.
		Dim indentationDepth As Integer = 0
		
		'Loop through the XML fragment.
		While True
			'If we need to read then do so.
			If needRead Then
				'Read the next element, exiting if there is nothing more to be read.
				If Not xmlReader.Read() Then
					Exit While
					
				End If
			Else
				'We don't need to read.
				If xmlReader.EOF Then
					Exit While
					'Exit the loop if at the end of the file.
					
				End If
			End If
			
			'Change needRead to true which is the default value.
			needRead = True
			
			'If the element is a start element.
			If xmlReader.IsStartElement() Then
				'We use local name rather than the prefix because we want to deal with
				' the Not elements like we do elements in the bar namespace.  That is,
				' we want the outer XML so that we include the not element as well as
				' the inner bar element.
				
				Dim tmpRow As Integer = dgv_rules.Rows.Add()
				
				'Set padding depth.
				Dim tmpPadding As Padding = dgv_rules.Rows(tmpRow).Cells(0).Style.Padding
				tmpPadding.Left = defaultPaddingSize * indentationDepth
				dgv_rules.Rows(tmpRow).Cells(0).Style.Padding = tmpPadding
				
				Select Case xmlReader.LocalName
						
					Case "And"
						dgv_rules.Rows(tmpRow).Cells(0).Value = _beginAnd
						dgv_rules.Rows(tmpRow).Cells(1).Value = "<" & xmlReader.Name & ">"
						indentationDepth += 1
						Exit Select
					Case "Or"
						dgv_rules.Rows(tmpRow).Cells(0).Value = _beginOr
						dgv_rules.Rows(tmpRow).Cells(1).Value = "<" & xmlReader.Name & ">"
						indentationDepth += 1
						Exit Select
					Case Else
						dgv_rules.Rows(tmpRow).Cells(1).Value = xmlReader.ReadOuterXml()
						Dim f As New RulesForm()
						dgv_rules.Rows(tmpRow).Cells(0).Value = f.GenerateReadableRuleFromXml(dgv_rules.Rows(tmpRow).Cells(1).Value.ToString())
						f.Dispose()
						needRead = False
						'We don't need a read because of the ReadOuterXML call
						Exit Select
				End Select
			Else
				'Element is a closing element.
				indentationDepth -= 1
				Dim tmpRow As Integer = dgv_rules.Rows.Add()
				
				'Set padding depth.
				Dim tmpPadding As Padding = dgv_rules.Rows(tmpRow).Cells(0).Style.Padding
				tmpPadding.Left = defaultPaddingSize * indentationDepth
				dgv_rules.Rows(tmpRow).Cells(0).Style.Padding = tmpPadding
				
				dgv_rules.Rows(tmpRow).Cells(0).Value = "End " & xmlReader.LocalName
				dgv_rules.Rows(tmpRow).Cells(1).Value = "</" & xmlReader.Name & ">"
				'Loop through XML.
			End If
		End While
	End Sub
	
	
	'Add rule.
	Private Sub btn_add_Click(sender As Object, e As EventArgs)
		Dim tmpRow As Integer
		
		'Prompt user to create rule.
		Dim tmpRulesForm As New RulesForm("Create " & Me.RuleEditorTitle)
		tmpRulesForm.Location =  New Point(ParentForm.Location.X + 100, ParentForm.Location.Y + 100)
		
		If DialogResult.OK = tmpRulesForm.ShowDialog(Me) Then
			tmpRow = Me.dgv_rules.Rows.Add(New String() {tmpRulesForm.ReadableRule, tmpRulesForm.XmlRule})
			Me.dgv_rules.CurrentCell = Me.dgv_rules.Rows(tmpRow).Cells("Rule")
		End If
		tmpRulesForm.Dispose()
	End Sub
	
	'Remove rule.
	Private Sub btn_remove_Click(sender As Object, e As EventArgs)
		'Make sure a Row is selected.
		If dgv_rules.SelectedRows.Count > 0 Then
			'Prompt the user and remove the row
			If DialogResult.Yes = MessageBox.Show(Me, globalRM.GetString("prompt_ruled_editor_confirm_delete"), globalRM.GetString("prompt_ruled_editor_delete"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
				For Each tempRow As DataGridViewRow In dgv_rules.SelectedRows
					dgv_rules.Rows.RemoveAt(tempRow.Index)
				Next
			End If
		End If
	End Sub
	
	'Edit rule.
	Private Sub btn_edit_Click(sender As Object, e As EventArgs)
		'Make sure a row is selected.
		If dgv_rules.SelectedRows.Count = 1 Then
			Dim tmpRulesForm As New RulesForm(globalRM.GetString("edit") & " " & Me.RuleEditorTitle)
			tmpRulesForm.Location =  New Point(ParentForm.Location.X + 100, ParentForm.Location.Y + 100)
			
			If DialogResult.OK = tmpRulesForm.ShowDialog(Me, dgv_rules.CurrentRow.Cells(1).Value.ToString()) Then
				dgv_rules.CurrentRow.Cells(0).Value = tmpRulesForm.ReadableRule
				dgv_rules.CurrentRow.Cells(1).Value = tmpRulesForm.XmlRule
			End If
			tmpRulesForm.Dispose()
		End If
	End Sub
	
	'If the user double clicks on a row, then edit it.
	Sub Dgv_rulesCellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs)
		If e.RowIndex > -1 Then
			btn_edit_Click(sender, e)
		End If
	End Sub
	
	'Group rules.
	Private Sub btn_group_Click(sender As Object, e As EventArgs)
		'this code handles the button if it is not in "Make Group" mode
		If TypeOf sender Is Button Then
			If DirectCast(sender, Button).Text <> _addGroup Then
				GroupRules(False)
				Return
			End If
		End If
		
		Dim tmpContextMenu As New ContextMenu()
		tmpContextMenu.MenuItems.Add(New MenuItem("AND", New EventHandler(AddressOf menuDoGrouping_Click)))
		tmpContextMenu.MenuItems.Add(New MenuItem("OR", New EventHandler(AddressOf menuDoGrouping_Click)))
		tmpContextMenu.Show(DirectCast(sender, Control), New Point(1, 1))
	End Sub
	
	'Do the grouping.
	Private Sub menuDoGrouping_Click(sender As Object, e As EventArgs)
		If TypeOf sender Is MenuItem Then
			GroupRules(DirectCast(sender, MenuItem).Text = "AND")
		End If
	End Sub
	
	'GroupRules deals with adding and removing And/Or groupings to the selected set of rules.
	Public Sub GroupRules(andRules As Boolean)
		If dgv_rules.SelectedRows.Count > 1 Then
			'Must have more than one row selected.
			
			'Find the highest and lowest index values in the selected rows.
			Dim tmpHighestIndex As Integer = -1
			Dim tmpLowestIndex As Integer = -1
			For Each tempRow As DataGridViewRow In dgv_rules.SelectedRows
				If tmpHighestIndex = -1 Then
					tmpHighestIndex = tempRow.Index
				End If
				If tmpLowestIndex = -1 Then
					tmpLowestIndex = tempRow.Index
				End If
				If tempRow.Index > tmpHighestIndex Then
					tmpHighestIndex = tempRow.Index
				End If
				If tempRow.Index < tmpLowestIndex Then
					tmpLowestIndex = tempRow.Index
				End If
			Next
			
			Try
				'If we are adding a rule group.
				If btn_group.Text = _addGroup Then
					'Add an Add grouping.
					If andRules Then
						dgv_rules.Rows.Insert(tmpHighestIndex + 1, New String() {_endAnd, "</lar:And>"})
						dgv_rules.Rows.Insert(tmpLowestIndex, New String() {_beginAnd, "<lar:And>"})
					Else
						'Add an Or grouping.
						
						dgv_rules.Rows.Insert(tmpHighestIndex + 1, New String() {_endOr, "</lar:Or>"})
						dgv_rules.Rows.Insert(tmpLowestIndex, New String() {_beginOr, "<lar:Or>"})
					End If
					
					'Indent the new group.
					For i As Integer = tmpLowestIndex To tmpHighestIndex + 2
						Dim tmpPadding As Padding = dgv_rules.Rows(i).Cells(0).Style.Padding
						tmpPadding.Left += defaultPaddingSize
						dgv_rules.Rows(i).Cells(0).Style.Padding = tmpPadding
					Next
				ElseIf (btn_group.Text = _removeAnd) OrElse (btn_group.Text = _removeOr) Then
					'Remove grouping
					
					'Remove the first and last rows which contain the grouping rows.
					dgv_rules.Rows.RemoveAt(tmpHighestIndex)
					dgv_rules.Rows.RemoveAt(tmpLowestIndex)
					
					'Un-indent the selected rows.
					For i As Integer = tmpLowestIndex To tmpHighestIndex - 2
						Dim tmpPadding As Padding = dgv_rules.Rows(i).Cells(0).Style.Padding
						tmpPadding.Left = tmpPadding.Left - defaultPaddingSize
						dgv_rules.Rows(i).Cells(0).Style.Padding = tmpPadding
						
						'dgv_rules.Rows(i).Cells(0).Value = dgv_rules.Rows(i).Cells(0).Value.ToString().TrimStart(New Char() {" "C})
						'Adding or removing rule group.
					Next
				End If
			Catch x As ArgumentOutOfRangeException
				MessageBox.Show(globalRM.GetString("exception_argument_out_of_range") & ":" & globalRM.GetString("error_rules_editor_add_remove_group") & Environment.NewLine & x.Message)
				'More than one row selected.
			End Try
		End If
	End Sub
	
	'When the user select a records enable and disable buttons depending
	' on what they selected.
	Private Sub dgv_rules_SelectionChanged(sender As Object, e As EventArgs)
		Dim tmpDgv As DataGridView = DirectCast(sender, DataGridView)
		
		Application.DoEvents()
		
		btn_remove.Enabled = False
		
		'Finish the event then proceed.
		If tmpDgv.SelectedRows.Count = 1 Then
			btn_edit.Enabled = Not RowIsGroupConstruct(tmpDgv.SelectedRows(0))
			btn_group.Text = "Remove Group"
			btn_group.Enabled = False
			btn_remove.Enabled = Not RowIsGroupConstruct(tmpDgv.SelectedRows(0))
		ElseIf tmpDgv.SelectedRows.Count > 1 Then
			
			'Find the highest and lowest index values in the selected rows.
			'Also count the number of unfinished And and Or rules by
			' incrementing on the Begin rows and decreasing on the End rows.
			Dim tmpHighestIndex As Integer = -1
			Dim tmpLowestIndex As Integer = tmpDgv.Rows.Count
			Dim tmpAndRuleCount As Integer = 0
			Dim tmpOrRuleCount As Integer = 0
			
			For Each tempRow As DataGridViewRow In tmpDgv.SelectedRows
				If tempRow.Index > tmpHighestIndex Then
					tmpHighestIndex = tempRow.Index
				End If
				If tempRow.Index < tmpLowestIndex Then
					tmpLowestIndex = tempRow.Index
				End If
				If tempRow.Cells(0).Value.ToString() = _beginAnd Then
					tmpAndRuleCount += 1
				End If
				If tempRow.Cells(0).Value.ToString() = _endAnd Then
					tmpAndRuleCount -= 1
				End If
				If tempRow.Cells(0).Value.ToString() = _beginOr Then
					tmpOrRuleCount += 1
				End If
				If tempRow.Cells(0).Value.ToString() = _endOr Then
					tmpOrRuleCount -= 1
				End If
			Next
			
			
			'Make sure the difference between the highest and lowest indexes match the
			' number of rows selected.  If they do not, then the user has not selected
			' a continuous collection of rows.
			If (tmpHighestIndex - tmpLowestIndex) + 1 <> tmpDgv.SelectedRows.Count Then
				btn_group.Text = _addGroup
				btn_group.Enabled = False
				
				'If the lowest row is a Begin rule and the highest rule is a End
				' rule of the same type then allow the user to remove the group.
			ElseIf (dgv_rules.Rows(tmpLowestIndex).Cells(0).Value.ToString().Trim() = _beginAnd) AndAlso (dgv_rules.Rows(tmpHighestIndex).Cells(0).Value.ToString().Trim() = _endAnd) AndAlso (tmpAndRuleCount = 0) AndAlso (tmpOrRuleCount = 0) Then
				
				btn_group.Text = _removeAnd
				btn_group.Enabled = True
				
			ElseIf (dgv_rules.Rows(tmpLowestIndex).Cells(0).Value.ToString().Trim() = _beginOr) AndAlso (dgv_rules.Rows(tmpHighestIndex).Cells(0).Value.ToString().Trim() = _endOr) AndAlso (tmpAndRuleCount = 0) AndAlso (tmpOrRuleCount = 0) Then
				
				btn_group.Text = _removeOr
				btn_group.Enabled = True
				
			ElseIf (tmpAndRuleCount = 0) AndAlso (tmpOrRuleCount = 0) Then
				btn_group.Text = _addGroup
				btn_group.Enabled = True
			Else
				btn_group.Text = _addGroup
				btn_group.Enabled = False
			End If
			
			'Only one row selected.
			btn_edit.Enabled = False
		End If
	End Sub
	
	
	'If there are no rules then disable the Save Rules button.
	Sub Dgv_rulesRowsAddRemoved(sender As Object, e As Object)
		If Dgv_rules.Rows.Count > 0 Then
			btnSaveRules.Enabled = True
		Else
			btnSaveRules.Enabled = False
		End If
		
	End Sub
	
	'Returns true if the selected row is a grouping construct.
	Private Function RowIsGroupConstruct(row As DataGridViewRow) As Boolean
		If row Is Nothing OrElse row.Cells(0).Value Is Nothing Then
			Return Nothing
		Else
			Dim construct As String = row.Cells(0).Value.ToString()
			Return ((construct = _beginAnd) OrElse (construct = _endAnd) OrElse (construct = _beginOr) OrElse (construct = _endOr))
		End If
	End Function
	
	'Display the saved rule dialog and load the rule.
	Sub BtnLoadRulesClick(sender As Object, e As EventArgs)
		My.Forms.SavedRulesForm.Location = New Point(Me.ParentForm.Location.X + 100 , Me.ParentForm.Location.Y + 100)
		
		Dim tmpRuleCollection As RuleCollection = My.Forms.SavedRulesForm.ShowDialog(SavedRulesFormUses.Load)
		
		'If rules were returned then load them.
		If tmpRuleCollection.Count > 0 Then
			
			For Each tmpRule As Rule In tmpRuleCollection
				LoadRules(tmpRule.Xml)
			Next
		End If
	End Sub
	
	'Save the current set of rules.
	Sub BtnSaveRulesClick(sender As Object, e As EventArgs)
		Dim strInput As String = InputBox(globalRM.GetString("prompt_rules_editor_name_new_rule"),globalRM.GetString("prompt_rules_editor_name_rule"))
		If Not strInput = Nothing Then
			
			'If the rule doesn't already exist then add it.
			If appSettings.SavedRuleCollection.Contains(strInput) Then
				Msgbox (globalRM.GetString("warning_rules_editor_exists"))
			Else
				appSettings.SavedRuleCollection.Add(New Rule(strInput, Rule))
			End If
		End If
	End Sub
	
	'Allow user to edit the Installable Item level rules.
	Sub BtnEditInstallableItemClick(sender As Object, e As EventArgs)
		Msgbox("Edit this XML at your own risk.")
		tb_xml.ScrollBars = ScrollBars.Vertical
		tb_xml.ReadOnly = False
		btnEditInstallableItem.Visible = False
	End Sub
	
	'Clear all the rules.
	Sub Clear
		Me.dgv_rules.Rows.Clear
	End Sub
	
	#End Region
End Class

