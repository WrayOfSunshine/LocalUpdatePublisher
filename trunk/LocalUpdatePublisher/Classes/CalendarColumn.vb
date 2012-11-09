Option Explicit On
Option Strict On
' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' From http://msdn.microsoft.com/library/7tas5c80%28en-us,vs.80%29.aspx
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 2/14/2011
' Time: 2:59 PM
Imports System
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class CalendarColumn
    Inherits DataGridViewColumn


    Public Sub New()
        MyBase.New(New CalendarCell())
    End Sub




    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)

            ' Ensure that the cell used for the template is a CalendarCell.
            If (value IsNot Nothing) AndAlso _
                Not value.GetType().IsAssignableFrom(GetType(CalendarCell)) _
                Then
                Throw New InvalidCastException("Must be a CalendarCell")
            End If
            MyBase.CellTemplate = value

        End Set
    End Property

    Protected Overrides Sub OnDataGridViewChanged()
        MyBase.OnDataGridViewChanged()
        If Not Me.DataGridView Is Nothing Then
            AddHandler Me.DataGridView.CellValidating, AddressOf CalendarDataGridView_CellValidating
            'Me.DataGridView.CellValidating += New DataGridViewCellValidatingEventHandler(CalendarDataGridView_CellValidating)
        End If
    End Sub

    Protected Sub CalendarDataGridView_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs)
        If sender Is DataGridView Then
            Dim dgv As DataGridView = DirectCast(sender, DataGridView)
            If e.ColumnIndex >= 0 AndAlso e.ColumnIndex < dgv.Columns.Count _
                AndAlso e.RowIndex >= 0 AndAlso e.RowIndex < dgv.Rows.Count Then
                If TypeOf (dgv.Columns(e.ColumnIndex)) Is CalendarColumn AndAlso dgv.Columns(e.ColumnIndex).Equals(Me) Then
                    If Not dgv.EditingPanel Is Nothing Then dgv.EditingPanel.Select()
                End If
            End If
        End If
    End Sub

End Class

Public Class CalendarCell
    Inherits DataGridViewTextBoxCell

    Private m_showCheckBox As Boolean = False

    Public Sub New()
        ' Use the short date format.
        Me.Style.Format = "MM/dd/yyyy hh:mm tt"
    End Sub

    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, _
        ByVal initialFormattedValue As Object, _
        ByVal dataGridViewCellStyle As DataGridViewCellStyle)

        m_showCheckBox = True

        ' Set the value of the editing control to the current cell value.
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, _
            dataGridViewCellStyle)

        Dim ctl As CalendarEditingControl = _
            CType(DataGridView.EditingControl, CalendarEditingControl)

        ctl.ShowCheckBox = m_showCheckBox

        If Not Me.Value Is Nothing Then
            If TypeOf (Me.Value) Is DateTime Then
                ctl.Value = DirectCast(Me.Value, DateTime)
            Else
                Dim dtVal As DateTime
                If DateTime.TryParse(Convert.ToString(Me.Value), dtVal) Then ctl.Value = dtVal
            End If
            If m_showCheckBox Then ctl.Checked = True
        ElseIf m_showCheckBox Then
            ctl.Checked = False
        End If

        '		If Me.Value IsNot Nothing Then
        '			ctl.Value = CType(Me.Value, DateTime)
        '		End If
    End Sub


    Public Overrides ReadOnly Property EditType() As Type
        Get
            ' Return the type of the editing contol that CalendarCell uses.
            Return GetType(CalendarEditingControl)
        End Get
    End Property

    Public Overrides ReadOnly Property ValueType() As Type
        Get
            ' Return the type of the value that CalendarCell contains.
            Return GetType(DateTime)
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            If m_showCheckBox Then
                Return Nothing
            Else
                ' Use the current date and time as the default value.
                Return DateTime.Now
            End If
        End Get
    End Property

End Class

Class CalendarEditingControl
    Inherits DateTimePicker
    Implements IDataGridViewEditingControl

    Private m_dataGridViewControl As DataGridView
    Private m_valueIsChanged As Boolean = False
    Private m_rowIndexNum As Integer

    Public Sub New()
        Me.Format = DateTimePickerFormat.Custom
        Me.CustomFormat = "MM/dd/yyyy hh:mm tt"
        Me.ShowCheckBox = True
    End Sub

    Public Property EditingControlFormattedValue() As Object _
        Implements IDataGridViewEditingControl.EditingControlFormattedValue

        Get
            If Me.Checked Then
                Return Me.Value.ToString(Me.CustomFormat)
            Else
                Return String.Empty
            End If
        End Get

        Set(ByVal value As Object)
            If TypeOf value Is String Then
                Me.Value = DateTime.Parse(CStr(value))
            End If
        End Set

    End Property

    Public Function GetEditingControlFormattedValue(ByVal context _
        As DataGridViewDataErrorContexts) As Object _
        Implements IDataGridViewEditingControl.GetEditingControlFormattedValue

        If Me.Checked Then
            Return Me.Value.ToString(Me.CustomFormat)
        Else
            Return String.Empty
        End If

    End Function

    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As  _
        DataGridViewCellStyle) _
        Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

        Me.Font = dataGridViewCellStyle.Font
        Me.CalendarForeColor = dataGridViewCellStyle.ForeColor
        Me.CalendarMonthBackground = dataGridViewCellStyle.BackColor

    End Sub

    Public Property EditingControlRowIndex() As Integer _
        Implements IDataGridViewEditingControl.EditingControlRowIndex

        Get
            Return m_rowIndexNum
        End Get
        Set(ByVal value As Integer)
            m_rowIndexNum = value
        End Set

    End Property

    Public Function EditingControlWantsInputKey(ByVal key As Keys, _
        ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
        Implements IDataGridViewEditingControl.EditingControlWantsInputKey

        ' Let the DateTimePicker handle the keys listed.
        Select Case key And Keys.KeyCode
            Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, _
                Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp

                Return True

            Case Else
                Return False
        End Select

    End Function

    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
        Implements IDataGridViewEditingControl.PrepareEditingControlForEdit

        If (selectAll) Then MyBase.RecreateHandle()

    End Sub

    Public ReadOnly Property RepositionEditingControlOnValueChange() _
        As Boolean Implements _
        IDataGridViewEditingControl.RepositionEditingControlOnValueChange

        Get
            Return False
        End Get

    End Property

    Public Property EditingControlDataGridView() As DataGridView _
        Implements IDataGridViewEditingControl.EditingControlDataGridView

        Get
            Return m_dataGridViewControl
        End Get
        Set(ByVal value As DataGridView)
            m_dataGridViewControl = value
        End Set

    End Property

    Public Property EditingControlValueChanged() As Boolean _
        Implements IDataGridViewEditingControl.EditingControlValueChanged

        Get
            Return m_valueIsChanged
        End Get
        Set(ByVal value As Boolean)
            m_valueIsChanged = value
        End Set

    End Property

    Public ReadOnly Property EditingControlCursor() As Cursor _
        Implements IDataGridViewEditingControl.EditingPanelCursor

        Get
            Return MyBase.Cursor
        End Get

    End Property

    Protected Overrides Sub OnValueChanged(ByVal eventargs As EventArgs)

        ' Notify the DataGridView that the contents of the cell have changed.
        m_valueIsChanged = True
        Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
        MyBase.OnValueChanged(eventargs)

    End Sub

End Class

