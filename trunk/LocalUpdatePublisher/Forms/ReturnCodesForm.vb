Option Explicit On
Option Strict On
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

Partial Public Class ReturnCodesForm

    Private m_codeList As IList(Of ReturnCode)
    Private m_resultCodes As ArrayList

    Public Sub New()
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        Me.InitializeComponent()

        'Localize the data grid view
        For Each colTemp As DataGridViewColumn In Me.dgvReturnCodes.Columns
            colTemp.HeaderText = globalRM.GetString(colTemp.Name)
        Next

        'Populate the Result Code list in a way that mimics the enumeration.
        m_resultCodes = New ArrayList
        m_resultCodes.Add("")
        m_resultCodes.Add(globalRM.GetString("failed"))
        m_resultCodes.Add(globalRM.GetString("Succeeded"))
        m_resultCodes.Add(globalRM.GetString("Cancelled"))

        'Localize the Result column if it exists.
        If Me.dgvReturnCodes.Columns.Contains("Result") Then
            DirectCast(Me.dgvReturnCodes.Columns("Result"), DataGridViewComboBoxColumn).DataSource = m_resultCodes
        End If
    End Sub

    ''' <summary>
    ''' Call ShowDialog with IList of ReturnCode passed in.
    ''' </summary>
    ''' <param name="codeList"></param>
    ''' <returns>DialogResult</returns>
    Public Overloads Function ShowDialog(ByRef codeList As IList(Of ReturnCode)) As DialogResult
        Dim tmpRow As Integer
        m_codeList = codeList

        'Load the code list into the DGV.
        Me.dgvReturnCodes.Rows.Clear()
        For Each code As ReturnCode In codeList
            tmpRow = Me.dgvReturnCodes.Rows.Add
            Me.dgvReturnCodes.Rows(tmpRow).Cells("Result").Value = m_resultCodes(code.InstallationResult)   '[Enum].GetName(GetType(InstallationResult),code.InstallationResult)
            Me.dgvReturnCodes.Rows(tmpRow).Cells("ReturnCode").Value = code.ReturnCodeValue
            Me.dgvReturnCodes.Rows(tmpRow).Cells("Reboot").Value = code.IsRebootRequired
            Me.dgvReturnCodes.Rows(tmpRow).Cells("Description").Value = code.Description
        Next

        Return MyBase.ShowDialog()

    End Function

    ''' <summary>
    ''' Save changes to code list and exit.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub BtnOkClick(sender As Object, e As EventArgs)
        Dim tmpReturnCode As ReturnCode

        'Clear the code list.
        m_codeList.Clear()

        'Loop through records and build new return code list.
        For Each tmpRow As DataGridViewRow In dgvReturnCodes.Rows
            'Make sure this isn't a new row and that no errors exist
            If tmpRow.IsNewRow Then
                tmpRow.ErrorText = String.Empty
            ElseIf Not String.IsNullOrEmpty(tmpRow.ErrorText) Then
                Exit Sub
            Else
                tmpReturnCode = New ReturnCode
                tmpReturnCode.Language = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName

                'Use the selected index of the Result column to set the InstallationResult property.
                tmpReturnCode.InstallationResult = DirectCast(DirectCast(tmpRow.Cells("Result"), DataGridViewComboBoxCell).Items.IndexOf(tmpRow.Cells("Result").Value), InstallationResult)
                tmpReturnCode.ReturnCodeValue = CInt(tmpRow.Cells("ReturnCode").Value)
                If Not tmpRow.Cells("Reboot").Value Is Nothing Then tmpReturnCode.IsRebootRequired = DirectCast(tmpRow.Cells("Reboot").Value, Boolean)
                If Not tmpRow.Cells("Description").Value Is Nothing Then tmpReturnCode.Description = tmpRow.Cells("Description").Value.ToString
                m_codeList.Add(tmpReturnCode)

            End If
        Next

    End Sub

    ''' <summary>
    ''' Delete the current return code.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub BtnDeleteClick(sender As Object, e As EventArgs)
        If Not dgvReturnCodes.CurrentRow Is Nothing AndAlso dgvReturnCodes.CurrentRow.Index > -1 Then
            dgvReturnCodes.Rows.RemoveAt(dgvReturnCodes.CurrentRow.Index)
        End If
    End Sub

    ''' <summary>
    ''' Validate the DGV rows.
    ''' </summary>
    ''' <returns>Boolean indicating if any error exist with the return codes.</returns>
    Function ValidateDGVReturnCodes() As Boolean

        'Loop through each row and see if any errors exist.
        For Each tmpRow As DataGridViewRow In Me.dgvReturnCodes.Rows
            If Not String.IsNullOrEmpty(tmpRow.ErrorText) AndAlso Not tmpRow.IsNewRow Then
                Return False
            End If
        Next

        Return True
    End Function
    ''' <summary>
    ''' Validate that the row has a result and return code entered.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub DgvReturnCodesRowValidating(sender As Object, e As DataGridViewCellCancelEventArgs)
        Dim columnName As String = dgvReturnCodes.Columns(e.ColumnIndex).Name
        Dim errorText As String

        'Make sure the row has a result and return code entered.
        If dgvReturnCodes.Rows(e.RowIndex).IsNewRow Then 'Don't validate new rows.
            errorText = String.Empty
        ElseIf (String.IsNullOrEmpty(DirectCast(dgvReturnCodes.Rows(e.RowIndex).Cells("Result").Value, String))) Then
            errorText = globalRM.GetString("error_result_code_empty")
        ElseIf (String.IsNullOrEmpty(CStr(dgvReturnCodes.Rows(e.RowIndex).Cells("ReturnCode").Value))) Then
            errorText = globalRM.GetString("error_return_codes_empty")
        Else 'No errors in row.
            errorText = String.Empty
        End If

        dgvReturnCodes.Rows(e.RowIndex).ErrorText = errorText

        'Set the OK button based on the DGV validation.
        Me.btnOk.Enabled = ValidateDGVReturnCodes()
    End Sub

    ''' <summary>
    ''' Add the formatted value of the cell to the cboBoxColumn
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub DgvReturnCodesCellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs)
        Dim cboBoxColumn As DataGridViewComboBoxColumn = DirectCast(Me.dgvReturnCodes.Columns("Result"), DataGridViewComboBoxColumn)
        If (e.ColumnIndex = cboBoxColumn.DisplayIndex) Then
            If (Not cboBoxColumn.Items.Contains(e.FormattedValue)) Then
                cboBoxColumn.Items.Add(e.FormattedValue)
            End If
        End If
    End Sub

    ''' <summary>
    ''' The dynamically added items to the result drop down cause a data validation error that needs to be ignored.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub DgvReturnCodesDataError(sender As Object, e As DataGridViewDataErrorEventArgs)
        If Me.dgvReturnCodes.Columns.Contains("Result") AndAlso sender.Equals(Me.dgvReturnCodes.Columns.Contains("Result")) Then
            e.Cancel = True
        End If
    End Sub
End Class
