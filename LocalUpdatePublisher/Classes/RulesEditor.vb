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

Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Xml

Public Partial Class RulesEditor
	Inherits UserControl
	
	Public Sub New()
		InitializeComponent()
	End Sub
	
	
	#Region "Properties and Accessors"
	Private ReadOnly Property _Begin_And() As String
		Get
			Return globalRM.GetString("group_begin_and")
		End Get
	End Property
	
	Private ReadOnly Property _End_And() As String
		Get
			Return globalRM.GetString("group_end_and")
		End Get
	End Property
	
	Private ReadOnly Property _Begin_Or() As String
		Get
			Return globalRM.GetString("group_begin_or")
		End Get
	End Property
	
	Private ReadOnly Property _End_Or() As String
		Get
			Return globalRM.GetString("group_end_or")
		End Get
	End Property
	
	Private ReadOnly Property _Add_Group() As String
		Get
			Return globalRM.GetString("group")
		End Get
	End Property
	
	Private ReadOnly Property _Remove_And() As String
		Get
			Return globalRM.GetString("group_remove_and")
		End Get
	End Property
	
	Private ReadOnly Property _Remove_Or() As String
		Get
			Return globalRM.GetString("group_remove_or")
		End Get
	End Property
	
	
	'Instructional text to appear at the top.
	<Localizable(True)> _
		Public Property Instructions() As String
		Get
			Return lblinstructions.Text
		End Get
		Set
			lblinstructions.Text = value
		End Set
	End Property
	
	'Title of this rule builder.
	<Localizable(True)> _
		Public Property Title() As String
		Get
			Return lbltitle.Text
		End Get
		Set
			lbltitle.Text = value
		End Set
	End Property
	
	'The title that goes under the main rule builder.
	<Localizable(True)> _
		Public Property TitleItemLevel() As String
		Get
			Return lblxml.Text
		End Get
		Set
			lblxml.Text = value
		End Set
	End Property
	
	'Number of rules listed.
	Public ReadOnly Property Count() As Integer
		Get
			Return dgvRules.Rows.Count
		End Get
	End Property
	
	'The item applicability rule.
	Public Property ApplicabilityRule() As String
		Get
			Return txtXml.Text
		End Get
		Set
			'TODO more stuff here
			txtXml.Text = value
		End Set
	End Property
	
	'If the item applicability rule was edited manually.
	Public ReadOnly Property ApplicabilityRuleEdited() As Boolean
		Get
			If txtXml.ReadOnly Then
				Return False
			Else
				Return True
			End If
		End Get
	End Property
	
	'The rules the editor is representing.
	Public Property Rules() As String
		Get
			Dim tmpStringBuilder As New StringBuilder()
			If Me.Count > 1 Then
				tmpStringBuilder.Append("<lar:And>")
			End If
			
			For Each row As DataGridViewRow In dgvRules.Rows
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
	
	#End Region
	
	#REGION "Implementation"
	'This routine receives a fragment of XML.  It parses the
	' XML into WSUS rules and loads them into the DGV.
	Public Sub LoadRules(xmlFragment As String)
		
		'Make sure we have at least two columns in our datagridview and that
		' the xmlFragment isn't empty.
		If (dgvRules.Columns.Count < 2) OrElse (xmlFragment Is Nothing) Then
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
				
				Dim tmpRow As Integer = dgvRules.Rows.Add()
				
				'Set padding depth.
				Dim tmpPadding As Padding = dgvRules.Rows(tmpRow).Cells(0).Style.Padding
				tmpPadding.Left = defaultPaddingSize * indentationDepth
				dgvRules.Rows(tmpRow).Cells(0).Style.Padding = tmpPadding
				
				Select Case xmlReader.LocalName
						
					Case "And"
						dgvRules.Rows(tmpRow).Cells(0).Value = _Begin_And
						dgvRules.Rows(tmpRow).Cells(1).Value = "<" & xmlReader.Name & ">"
						indentationDepth += 1
						Exit Select
					Case "Or"
						dgvRules.Rows(tmpRow).Cells(0).Value = _Begin_Or
						dgvRules.Rows(tmpRow).Cells(1).Value = "<" & xmlReader.Name & ">"
						indentationDepth += 1
						Exit Select
					Case Else
						dgvRules.Rows(tmpRow).Cells(1).Value = xmlReader.ReadOuterXml()
						Dim f As New RulesForm()
						dgvRules.Rows(tmpRow).Cells(0).Value = f.GenerateReadableRuleFromXml(dgvRules.Rows(tmpRow).Cells(1).Value.ToString())
						f.Dispose()
						needRead = False
						'We don't need a read because of the ReadOuterXML call
						Exit Select
				End Select
			Else
				'Element is a closing element.
				indentationDepth -= 1
				Dim tmpRow As Integer = dgvRules.Rows.Add()
				
				'Set padding depth.
				Dim tmpPadding As Padding = dgvRules.Rows(tmpRow).Cells(0).Style.Padding
				tmpPadding.Left = defaultPaddingSize * indentationDepth
				dgvRules.Rows(tmpRow).Cells(0).Style.Padding = tmpPadding
				
				If xmlReader.LocalName = "And" Then
					dgvRules.Rows(tmpRow).Cells(0).Value = _End_And
				Else
					dgvRules.Rows(tmpRow).Cells(0).Value = _End_Or
				End If
				dgvRules.Rows(tmpRow).Cells(1).Value = "</" & xmlReader.Name & ">"
				'Loop through XML.
			End If
		End While
	End Sub
	
	
	'Add rule.
	Private Sub btnAdd_Click(sender As Object, e As EventArgs)
		Dim tmpRow As Integer
		
		'Prompt user to create rule.
		Dim tmpRulesForm As New RulesForm(globalRM.GetString("RulesEditor_CreatePrompt"))
		tmpRulesForm.Location =  New Point(ParentForm.Location.X + 100, ParentForm.Location.Y + 100)
		
		If DialogResult.OK = tmpRulesForm.ShowDialog(Me) Then
			tmpRow = Me.dgvRules.Rows.Add(New String() {tmpRulesForm.ReadableRule, tmpRulesForm.XmlRule})
			Me.dgvRules.CurrentCell = Me.dgvRules.Rows(tmpRow).Cells("Rule")
		End If
		tmpRulesForm.Dispose()
	End Sub
	
	'Remove rule.
	Private Sub btnRemove_Click(sender As Object, e As EventArgs)
		'Make sure a Row is selected.
		If dgvRules.SelectedRows.Count > 0 Then
			'Prompt the user and remove the row
			If DialogResult.Yes = MessageBox.Show(Me, globalRM.GetString("prompt_ruled_editor_confirm_delete"), globalRM.GetString("prompt_ruled_editor_delete"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
				For Each tempRow As DataGridViewRow In dgvRules.SelectedRows
					dgvRules.Rows.RemoveAt(tempRow.Index)
				Next
			End If
		End If
	End Sub
	
	'Edit rule.
	Private Sub btnEdit_Click(sender As Object, e As EventArgs)
		'Make sure a row is selected.
		If dgvRules.SelectedRows.Count = 1 Then
			Dim tmpRulesForm As New RulesForm(globalRM.GetString("RulesEditor_EditPrompt"))
			tmpRulesForm.Location =  New Point(ParentForm.Location.X + 100, ParentForm.Location.Y + 100)
			
			If DialogResult.OK = tmpRulesForm.ShowDialog(Me, dgvRules.CurrentRow.Cells(1).Value.ToString()) Then
				dgvRules.CurrentRow.Cells(0).Value = tmpRulesForm.ReadableRule
				dgvRules.CurrentRow.Cells(1).Value = tmpRulesForm.XmlRule
			End If
			tmpRulesForm.Dispose()
		End If
	End Sub
	
	'If the user double clicks on a row, then edit it.
	Sub dgvRulesCellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs)
		If e.RowIndex > -1 Then
			btnEdit_Click(sender, e)
		End If
	End Sub
	
	'Group rules.
	Private Sub btnGroup_Click(sender As Object, e As EventArgs)
		
		'Make sure the sender is a button
		If TypeOf sender Is Button Then
			
			'If the button was the Add Group button then show the grouping options.
			If DirectCast(sender, Button).Text = _Add_Group Then
				Dim tmpContextMenu As New ContextMenu()
				tmpContextMenu.MenuItems.Add(New MenuItem(globalRM.GetString("and"), New EventHandler(AddressOf menuDoGrouping_Click)))
				tmpContextMenu.MenuItems.Add(New MenuItem(globalRM.GetString("or"), New EventHandler(AddressOf menuDoGrouping_Click)))
				tmpContextMenu.Show(DirectCast(sender, Control), New Point(1, 1))
				
				'If the button was one of the remove options then remove the group.
			ElseIf DirectCast(sender, Button).Text = _Remove_And OrElse DirectCast(sender, Button).Text = _Remove_Or
				GroupRules(False)
			End If
		End If
	End Sub
	
	'Do the grouping.
	Private Sub menuDoGrouping_Click(sender As Object, e As EventArgs)
		If TypeOf sender Is MenuItem Then
			If DirectCast(sender, MenuItem).Text = globalRM.GetString("and")
				GroupRules(True)
			Else
				GroupRules(False)
			End If
		End If
	End Sub
	
	'GroupRules deals with adding and removing And/Or groupings to the selected set of rules.
	Public Sub GroupRules(andRules As Boolean)
		If dgvRules.SelectedRows.Count > 1 Then
			'Must have more than one row selected.
			
			'Find the highest and lowest index values in the selected rows.
			Dim tmpHighestIndex As Integer = -1
			Dim tmpLowestIndex As Integer = -1
			For Each tempRow As DataGridViewRow In dgvRules.SelectedRows
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
				If btnGroup.Text = _add_Group Then
					'Add an Add grouping.
					If andRules Then
						dgvRules.Rows.Insert(tmpHighestIndex + 1, New String() {_end_And, "</lar:And>"})
						dgvRules.Rows.Insert(tmpLowestIndex, New String() {_Begin_And, "<lar:And>"})
					Else
						'Add an Or grouping.
						dgvRules.Rows.Insert(tmpHighestIndex + 1, New String() {_end_Or, "</lar:Or>"})
						dgvRules.Rows.Insert(tmpLowestIndex, New String() {_begin_Or, "<lar:Or>"})
					End If
					
					'Indent the new group.
					For i As Integer = tmpLowestIndex To tmpHighestIndex + 2
						Dim tmpPadding As Padding = dgvRules.Rows(i).Cells(0).Style.Padding
						tmpPadding.Left += defaultPaddingSize
						dgvRules.Rows(i).Cells(0).Style.Padding = tmpPadding
					Next
				ElseIf (btnGroup.Text = _remove_And) OrElse (btnGroup.Text = _remove_Or) Then
					'Remove grouping
					
					'Remove the first and last rows which contain the grouping rows.
					dgvRules.Rows.RemoveAt(tmpHighestIndex)
					dgvRules.Rows.RemoveAt(tmpLowestIndex)
					
					'Un-indent the selected rows.
					For i As Integer = tmpLowestIndex To tmpHighestIndex - 2
						Dim tmpPadding As Padding = dgvRules.Rows(i).Cells(0).Style.Padding
						tmpPadding.Left = tmpPadding.Left - defaultPaddingSize
						dgvRules.Rows(i).Cells(0).Style.Padding = tmpPadding
						
						'dgvRules.Rows(i).Cells(0).Value = dgvRules.Rows(i).Cells(0).Value.ToString().TrimStart(New Char() {" "C})
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
	Private Sub dgvRules_SelectionChanged(sender As Object, e As EventArgs)
		Dim tmpDgv As DataGridView = DirectCast(sender, DataGridView)
		
		Application.DoEvents()
		
		btnRemove.Enabled = False
		
		'Finish the event then proceed.
		If tmpDgv.SelectedRows.Count = 1 Then
			btnEdit.Enabled = Not RowIsGroupConstruct(tmpDgv.SelectedRows(0))
			btnGroup.Text = globalRM.GetString("remove_group")
			btnGroup.Enabled = False
			btnRemove.Enabled = Not RowIsGroupConstruct(tmpDgv.SelectedRows(0))
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
				If tempRow.Cells(0).Value.ToString() = _Begin_And Then
					tmpAndRuleCount += 1
				End If
				If tempRow.Cells(0).Value.ToString() = _end_And Then
					tmpAndRuleCount -= 1
				End If
				If tempRow.Cells(0).Value.ToString() = _begin_Or Then
					tmpOrRuleCount += 1
				End If
				If tempRow.Cells(0).Value.ToString() = _end_Or Then
					tmpOrRuleCount -= 1
				End If
			Next
			
			
			'Make sure the difference between the highest and lowest indexes match the
			' number of rows selected.  If they do not, then the user has not selected
			' a continuous collection of rows.
			If (tmpHighestIndex - tmpLowestIndex) + 1 <> tmpDgv.SelectedRows.Count Then
				btnGroup.Text = _add_Group
				btnGroup.Enabled = False
				
				'If the lowest row is a Begin rule and the highest rule is a End
				' rule of the same type then allow the user to remove the group.
			ElseIf (dgvRules.Rows(tmpLowestIndex).Cells(0).Value.ToString().Trim() = _Begin_And) AndAlso (dgvRules.Rows(tmpHighestIndex).Cells(0).Value.ToString().Trim() = _end_And) AndAlso (tmpAndRuleCount = 0) AndAlso (tmpOrRuleCount = 0) Then
				
				btnGroup.Text = _remove_And
				btnGroup.Enabled = True
				
			ElseIf (dgvRules.Rows(tmpLowestIndex).Cells(0).Value.ToString().Trim() = _begin_Or) AndAlso (dgvRules.Rows(tmpHighestIndex).Cells(0).Value.ToString().Trim() = _end_Or) AndAlso (tmpAndRuleCount = 0) AndAlso (tmpOrRuleCount = 0) Then
				
				btnGroup.Text = _remove_Or
				btnGroup.Enabled = True
				
			ElseIf (tmpAndRuleCount = 0) AndAlso (tmpOrRuleCount = 0) Then
				btnGroup.Text = _add_Group
				btnGroup.Enabled = True
			Else
				btnGroup.Text = _add_Group
				btnGroup.Enabled = False
			End If
			
			'Only one row selected.
			btnEdit.Enabled = False
		End If
	End Sub
	
	
	'If there are no rules then disable the Save Rules button.
	Sub dgvRulesRowsAddRemoved(sender As Object, e As Object)
		If dgvRules.Rows.Count > 0 Then
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
			Return ((construct = _Begin_And) OrElse (construct = _End_And) OrElse (construct = _Begin_Or) OrElse (construct = _End_Or))
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
				appSettings.SavedRuleCollection.Add(New Rule(strInput, Rules))
			End If
		End If
	End Sub
	
	'Allow user to edit the Installable Item level rules.
	Sub BtnEditInstallableItemClick(sender As Object, e As EventArgs)
		Msgbox (globalRM.GetString("warning_update_manual_edit"))
		txtXml.ScrollBars = ScrollBars.Vertical
		txtXml.ReadOnly = False
		btnEditInstallableItem.Visible = False
	End Sub
	
	'Clear all the rules.
	Sub Clear
		Me.dgvRules.Rows.Clear
	End Sub
	
	Shadows Sub TextChanged(sender As Object, e As EventArgs)
		CustomResize.ResizeVertically( sender, e)
	End Sub
	
	#End Region
	
End Class

