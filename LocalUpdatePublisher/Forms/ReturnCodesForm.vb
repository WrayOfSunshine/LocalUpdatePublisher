' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' Saved Rules Form
' This form is used in multiple ways depending on the SavedRulesFormUses enumeration.
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 2/12/2010
' Time: 12:40 PM
Imports Microsoft.UpdateServices.Administration

Public Partial Class ReturnCodesForm
	
	Private Dim _codeList As IList(Of ReturnCode)
	Private Dim _resultCodes As ArrayList
	
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		'Localize the data grid view
		For Each colTemp As DataGridViewColumn In Me.dgvReturnCodes.Columns
			colTemp.HeaderText = globalRM.GetString(colTemp.Name)
		Next
		
		'Populate the Result Code list in a way that mimics the enumeration.
		_resultCodes = New ArrayList
		_resultCodes.Add("")
		_resultCodes.Add(globalRM.GetString("failed"))
		_resultCodes.Add(globalRM.GetString("Succeeded"))
		_resultCodes.Add(globalRM.GetString("Cancelled"))
		
		'Localize the Result column if it exists.
		If Me.dgvReturnCodes.Columns.Contains("Result") Then
			DirectCast(Me.dgvReturnCodes.Columns("Result"), DataGridViewComboBoxColumn).DataSource = _resultCodes
		End If
	End Sub
	
	'Call ShowDialog with IList of ReturnCode passed in.
	Public Overloads Function ShowDialog(ByRef codeList As IList(Of ReturnCode)) As DialogResult
		Dim tmpRow As Integer
		_codeList = codeList
		
		'Load the code list into the DGV.
		Me.dgvReturnCodes.Rows.Clear
		For Each code As ReturnCode In codeList
			tmpRow = Me.dgvReturnCodes.Rows.Add
			Me.dgvReturnCodes.Rows(tmpRow).Cells("Result").Value = _resultCodes(code.InstallationResult)   '[Enum].GetName(GetType(InstallationResult),code.InstallationResult)
			Me.dgvReturnCodes.Rows(tmpRow).Cells("ReturnCode").Value = code.ReturnCodeValue
			Me.dgvReturnCodes.Rows(tmpRow).Cells("Reboot").Value = code.IsRebootRequired
			Me.dgvReturnCodes.Rows(tmpRow).Cells("Description").Value = code.Description
		Next
		
		Return MyBase.ShowDialog()
		
	End Function
	
	'Save changes to code list and exit.
	Sub BtnOkClick(sender As Object, e As EventArgs)
		Dim tmpReturnCode As ReturnCode
		
		'Clear the code list.
		_codeList.Clear
		
		'Loop through records and build new return code list.
		For Each tmpRow As DataGridViewRow In dgvReturnCodes.Rows
			'Make sure this isn't a new row and that no errors exist
			If tmpRow.IsNewRow Then
				tmpRow.ErrorText = String.Empty
			Else If Not String.IsNullOrEmpty(tmpRow.ErrorText) Then
				Exit Sub
			Else
				tmpReturnCode = New ReturnCode
				tmpReturnCode.Language = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName
				
				'Use the selected index of the Result column to set the InstallationResult property.
				tmpReturnCode.InstallationResult = DirectCast(DirectCast(tmpRow.Cells("Result"),DataGridViewComboBoxCell).Items.IndexOf(tmpRow.Cells("Result").Value), InstallationResult)
				tmpReturnCode.ReturnCodeValue = CInt(tmpRow.Cells("ReturnCode").Value)
				If Not tmpRow.Cells("Reboot").Value Is Nothing Then tmpReturnCode.IsRebootRequired = DirectCast(tmpRow.Cells("Reboot").Value, Boolean)
				If Not tmpRow.Cells("Description").Value Is Nothing Then tmpReturnCode.Description = tmpRow.Cells("Description").Value.ToString
				_codeList.Add(tmpReturnCode)
				
			End If
		Next
		
	End Sub
	
	'Delete the current return code.
	Sub BtnDeleteClick(sender As Object, e As EventArgs)
		If Not dgvReturnCodes.CurrentRow Is Nothing AndAlso dgvReturnCodes.CurrentRow.Index > -1  Then
			dgvReturnCodes.Rows.RemoveAt(dgvReturnCodes.CurrentRow.Index)
		End If
	End Sub
	
	'Validate the DGV rows.
	Function ValidateDGVReturnCodes As Boolean
		
		'Loop through each row and see if any errors exist.
		For Each tmpRow As DataGridViewRow In Me.dgvReturnCodes.Rows
			If Not String.IsNullOrEmpty(tmpRow.ErrorText) AndAlso Not tmpRow.IsNewRow Then
				Return False
			End If
		Next
		
		Return True
	End Function
	
	Sub DgvReturnCodesRowValidating(sender As Object, e As DataGridViewCellCancelEventArgs)
		Dim columnName As String = DgvReturnCodes.Columns(e.ColumnIndex).Name
		Dim errorText As String
		
		'Make sure the row has a result and return code entered.
		If DgvReturnCodes.Rows(e.RowIndex).IsNewRow Then 'Don't validate new rows.
			errorText = String.Empty
		Else If (String.IsNullOrEmpty(DirectCast(DgvReturnCodes.Rows(e.RowIndex).Cells("Result").Value, String))) Then
			errorText = globalRM.GetString("error_result_code_empty")
		Else If (String.IsNullOrEmpty(CStr(DgvReturnCodes.Rows(e.RowIndex).Cells("ReturnCode").Value))) Then
			errorText = globalRM.GetString("error_return_codes_empty")
		Else 'No errors in row.
			errorText = String.Empty
		End If
		
		DgvReturnCodes.Rows(e.RowIndex).ErrorText = errorText
		
		'Set the OK button based on the DGV validation.
		Me.btnOk.Enabled = ValidateDGVReturnCodes
	End Sub
	
	
	Sub DgvReturnCodesCellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs)
		Dim comboBoxColumn As DataGridViewComboBoxColumn = DirectCast(Me.dgvReturnCodes.Columns("Result"),DataGridViewComboBoxColumn)
		If (e.ColumnIndex = comboBoxColumn.DisplayIndex) Then
			If (Not comboBoxColumn.Items.Contains( e.FormattedValue)) Then
				comboBoxColumn.Items.Add(e.FormattedValue)
			End If
		End If
	End Sub
	
	'The dynamically added items to the Result drop down cause a data validation error that needs to be ignored.
	Sub DgvReturnCodesDataError(sender As Object, e As DataGridViewDataErrorEventArgs)
		If Me.dgvReturnCodes.Columns.Contains("Result") AndAlso sender.Equals(Me.dgvReturnCodes.Columns.Contains("Result")) Then
			e.Cancel = True
		End If
	End Sub
End Class
