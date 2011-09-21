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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReturnCodesForm))
		Me.dgvReturnCodes = New System.Windows.Forms.DataGridView
		Me.Result = New System.Windows.Forms.DataGridViewComboBoxColumn
		Me.ReturnCode = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.Reboot = New System.Windows.Forms.DataGridViewCheckBoxColumn
		Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.btnCancel = New System.Windows.Forms.Button
		Me.btnOk = New System.Windows.Forms.Button
		Me.btnDelete = New System.Windows.Forms.Button
		Me.contextMenuCodeType = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.failedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.succeededToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.cancelledToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
		CType(Me.dgvReturnCodes,System.ComponentModel.ISupportInitialize).BeginInit
		Me.contextMenuCodeType.SuspendLayout
		Me.tableLayoutPanel1.SuspendLayout
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
		Me.tableLayoutPanel1.SetColumnSpan(Me.dgvReturnCodes, 4)
		resources.ApplyResources(Me.dgvReturnCodes, "dgvReturnCodes")
		Me.dgvReturnCodes.MultiSelect = false
		Me.dgvReturnCodes.Name = "dgvReturnCodes"
		AddHandler Me.dgvReturnCodes.RowValidating, AddressOf Me.DgvReturnCodesRowValidating
		'
		'Result
		'
		Me.Result.FillWeight = 113.0288!
		resources.ApplyResources(Me.Result, "Result")
		Me.Result.Items.AddRange(New Object() {"", "Failed", "Succeeded", "Cancelled"})
		Me.Result.Name = "Result"
		'
		'ReturnCode
		'
		Me.ReturnCode.FillWeight = 113.0288!
		resources.ApplyResources(Me.ReturnCode, "ReturnCode")
		Me.ReturnCode.Name = "ReturnCode"
		'
		'Reboot
		'
		Me.Reboot.FalseValue = false
		Me.Reboot.FillWeight = 60.9137!
		resources.ApplyResources(Me.Reboot, "Reboot")
		Me.Reboot.IndeterminateValue = ""
		Me.Reboot.Name = "Reboot"
		Me.Reboot.TrueValue = true
		'
		'Description
		'
		Me.Description.FillWeight = 113.0288!
		resources.ApplyResources(Me.Description, "Description")
		Me.Description.Name = "Description"
		'
		'btnCancel
		'
		resources.ApplyResources(Me.btnCancel, "btnCancel")
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.UseVisualStyleBackColor = true
		'
		'btnOk
		'
		resources.ApplyResources(Me.btnOk, "btnOk")
		Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnOk.Name = "btnOk"
		Me.btnOk.UseVisualStyleBackColor = true
		AddHandler Me.btnOk.Click, AddressOf Me.BtnOkClick
		'
		'btnDelete
		'
		resources.ApplyResources(Me.btnDelete, "btnDelete")
		Me.btnDelete.Name = "btnDelete"
		Me.btnDelete.UseVisualStyleBackColor = true
		AddHandler Me.btnDelete.Click, AddressOf Me.BtnDeleteClick
		'
		'contextMenuCodeType
		'
		Me.contextMenuCodeType.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.failedToolStripMenuItem, Me.succeededToolStripMenuItem, Me.cancelledToolStripMenuItem})
		Me.contextMenuCodeType.Name = "contextMenuStrip1"
		resources.ApplyResources(Me.contextMenuCodeType, "contextMenuCodeType")
		'
		'failedToolStripMenuItem
		'
		Me.failedToolStripMenuItem.Name = "failedToolStripMenuItem"
		resources.ApplyResources(Me.failedToolStripMenuItem, "failedToolStripMenuItem")
		'
		'succeededToolStripMenuItem
		'
		Me.succeededToolStripMenuItem.Name = "succeededToolStripMenuItem"
		resources.ApplyResources(Me.succeededToolStripMenuItem, "succeededToolStripMenuItem")
		'
		'cancelledToolStripMenuItem
		'
		Me.cancelledToolStripMenuItem.Name = "cancelledToolStripMenuItem"
		resources.ApplyResources(Me.cancelledToolStripMenuItem, "cancelledToolStripMenuItem")
		'
		'tableLayoutPanel1
		'
		resources.ApplyResources(Me.tableLayoutPanel1, "tableLayoutPanel1")
		Me.tableLayoutPanel1.Controls.Add(Me.dgvReturnCodes, 0, 0)
		Me.tableLayoutPanel1.Controls.Add(Me.btnDelete, 0, 1)
		Me.tableLayoutPanel1.Controls.Add(Me.btnCancel, 3, 1)
		Me.tableLayoutPanel1.Controls.Add(Me.btnOk, 2, 1)
		Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
		'
		'ReturnCodesForm
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
		Me.CancelButton = Me.btnCancel
		Me.Controls.Add(Me.tableLayoutPanel1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "ReturnCodesForm"
		Me.ShowInTaskbar = false
		CType(Me.dgvReturnCodes,System.ComponentModel.ISupportInitialize).EndInit
		Me.contextMenuCodeType.ResumeLayout(false)
		Me.tableLayoutPanel1.ResumeLayout(false)
		Me.tableLayoutPanel1.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
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
