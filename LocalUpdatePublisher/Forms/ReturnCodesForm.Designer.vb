' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 2/12/2010
' Time: 12:40 PM

Partial Class ReturnCodesForm
	Inherits System.Windows.Forms.Form
	
	''' <summary>
	''' Designer variable used to keep track of non-visual components.
	''' </summary>
	Private components As System.ComponentModel.IContainer
	
	''' <summary>
	''' Disposes resources used by the form.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If components IsNot Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub
	
	''' <summary>
	''' This method is required for Windows Forms designer support.
	''' Do not change the method contents inside the source code editor. The Forms designer might
	''' not be able to load this method if it was changed manually.
	''' </summary>
	Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container
		Me.dgvReturnCodes = New System.Windows.Forms.DataGridView
		Me.btnCancel = New System.Windows.Forms.Button
		Me.btnOk = New System.Windows.Forms.Button
		Me.btnDelete = New System.Windows.Forms.Button
		Me.contextMenuCodeType = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.failedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.succeededToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.cancelledToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.Result = New System.Windows.Forms.DataGridViewComboBoxColumn
		Me.ReturnCode = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.Reboot = New System.Windows.Forms.DataGridViewCheckBoxColumn
		Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn
		CType(Me.dgvReturnCodes,System.ComponentModel.ISupportInitialize).BeginInit
		Me.contextMenuCodeType.SuspendLayout
		Me.SuspendLayout
		'
		'dgvReturnCodes
		'
		Me.dgvReturnCodes.AllowUserToOrderColumns = true
		Me.dgvReturnCodes.AllowUserToResizeColumns = false
		Me.dgvReturnCodes.AllowUserToResizeRows = false
		Me.dgvReturnCodes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.dgvReturnCodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvReturnCodes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Result, Me.ReturnCode, Me.Reboot, Me.Description})
		Me.dgvReturnCodes.Location = New System.Drawing.Point(12, 12)
		Me.dgvReturnCodes.MultiSelect = false
		Me.dgvReturnCodes.Name = "dgvReturnCodes"
		Me.dgvReturnCodes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.dgvReturnCodes.Size = New System.Drawing.Size(430, 245)
		Me.dgvReturnCodes.TabIndex = 0
		AddHandler Me.dgvReturnCodes.RowValidating, AddressOf Me.DgvReturnCodesRowValidating
		'
		'btnCancel
		'
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Location = New System.Drawing.Point(367, 263)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(75, 23)
		Me.btnCancel.TabIndex = 4
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.UseVisualStyleBackColor = true
		'
		'btnOk
		'
		Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnOk.Enabled = false
		Me.btnOk.Location = New System.Drawing.Point(286, 263)
		Me.btnOk.Name = "btnOk"
		Me.btnOk.Size = New System.Drawing.Size(75, 23)
		Me.btnOk.TabIndex = 3
		Me.btnOk.Text = "Ok"
		Me.btnOk.UseVisualStyleBackColor = true
		AddHandler Me.btnOk.Click, AddressOf Me.BtnOkClick
		'
		'btnDelete
		'
		Me.btnDelete.Location = New System.Drawing.Point(12, 263)
		Me.btnDelete.Name = "btnDelete"
		Me.btnDelete.Size = New System.Drawing.Size(75, 23)
		Me.btnDelete.TabIndex = 5
		Me.btnDelete.Text = "Delete"
		Me.btnDelete.UseVisualStyleBackColor = true
		AddHandler Me.btnDelete.Click, AddressOf Me.BtnDeleteClick
		'
		'contextMenuCodeType
		'
		Me.contextMenuCodeType.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.failedToolStripMenuItem, Me.succeededToolStripMenuItem, Me.cancelledToolStripMenuItem})
		Me.contextMenuCodeType.Name = "contextMenuStrip1"
		Me.contextMenuCodeType.Size = New System.Drawing.Size(138, 70)
		'
		'failedToolStripMenuItem
		'
		Me.failedToolStripMenuItem.Name = "failedToolStripMenuItem"
		Me.failedToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
		Me.failedToolStripMenuItem.Text = "Failed"
		'
		'succeededToolStripMenuItem
		'
		Me.succeededToolStripMenuItem.Name = "succeededToolStripMenuItem"
		Me.succeededToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
		Me.succeededToolStripMenuItem.Text = "Succeeded"
		'
		'cancelledToolStripMenuItem
		'
		Me.cancelledToolStripMenuItem.Name = "cancelledToolStripMenuItem"
		Me.cancelledToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
		Me.cancelledToolStripMenuItem.Text = "Cancelled"
		'
		'Result
		'
		Me.Result.FillWeight = 113.0288!
		Me.Result.HeaderText = "Result"
		Me.Result.Items.AddRange(New Object() {"", "Failed", "Succeeded", "Cancelled"})
		Me.Result.Name = "Result"
		'
		'ReturnCode
		'
		Me.ReturnCode.FillWeight = 113.0288!
		Me.ReturnCode.HeaderText = "Return Code"
		Me.ReturnCode.Name = "ReturnCode"
		'
		'Reboot
		'
		Me.Reboot.FalseValue = False
		Me.Reboot.FillWeight = 60.9137!
		Me.Reboot.HeaderText = "Reboot"
		Me.Reboot.IndeterminateValue = ""
		Me.Reboot.Name = "Reboot"
		Me.Reboot.TrueValue = True
		'
		'Description
		'
		Me.Description.FillWeight = 113.0288!
		Me.Description.HeaderText = "Description"
		Me.Description.Name = "Description"
		'
		'ReturnCodesForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
		Me.ClientSize = New System.Drawing.Size(454, 295)
		Me.Controls.Add(Me.btnDelete)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnOk)
		Me.Controls.Add(Me.dgvReturnCodes)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Name = "ReturnCodesForm"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "Return Codes"
		CType(Me.dgvReturnCodes,System.ComponentModel.ISupportInitialize).EndInit
		Me.contextMenuCodeType.ResumeLayout(false)
		Me.ResumeLayout(false)
	End Sub
	Private Reboot As System.Windows.Forms.DataGridViewCheckBoxColumn
	Private ReturnCode As System.Windows.Forms.DataGridViewTextBoxColumn
	Private Description As System.Windows.Forms.DataGridViewTextBoxColumn
	Private Result As System.Windows.Forms.DataGridViewComboBoxColumn
	Private contextMenuCodeType As System.Windows.Forms.ContextMenuStrip
	Private btnOk As System.Windows.Forms.Button
	Private btnDelete As System.Windows.Forms.Button
	Private succeededToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private failedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private cancelledToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private dgvReturnCodes As System.Windows.Forms.DataGridView
	Private btnCancel As System.Windows.Forms.Button
End Class
