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
		Me.dgvReturnCodes.AccessibleDescription = Nothing
		Me.dgvReturnCodes.AccessibleName = Nothing
		Me.dgvReturnCodes.AllowUserToOrderColumns = true
		Me.dgvReturnCodes.AllowUserToResizeColumns = false
		Me.dgvReturnCodes.AllowUserToResizeRows = false
		resources.ApplyResources(Me.dgvReturnCodes, "dgvReturnCodes")
		Me.dgvReturnCodes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.dgvReturnCodes.BackgroundImage = Nothing
		Me.dgvReturnCodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvReturnCodes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Result, Me.ReturnCode, Me.Reboot, Me.Description})
		Me.dgvReturnCodes.Font = Nothing
		Me.dgvReturnCodes.MultiSelect = false
		Me.dgvReturnCodes.Name = "dgvReturnCodes"
		AddHandler Me.dgvReturnCodes.RowValidating, AddressOf Me.DgvReturnCodesRowValidating
		'
		'btnCancel
		'
		Me.btnCancel.AccessibleDescription = Nothing
		Me.btnCancel.AccessibleName = Nothing
		resources.ApplyResources(Me.btnCancel, "btnCancel")
		Me.btnCancel.BackgroundImage = Nothing
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Font = Nothing
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.UseVisualStyleBackColor = true
		'
		'btnOk
		'
		Me.btnOk.AccessibleDescription = Nothing
		Me.btnOk.AccessibleName = Nothing
		resources.ApplyResources(Me.btnOk, "btnOk")
		Me.btnOk.BackgroundImage = Nothing
		Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnOk.Font = Nothing
		Me.btnOk.Name = "btnOk"
		Me.btnOk.UseVisualStyleBackColor = true
		AddHandler Me.btnOk.Click, AddressOf Me.BtnOkClick
		'
		'btnDelete
		'
		Me.btnDelete.AccessibleDescription = Nothing
		Me.btnDelete.AccessibleName = Nothing
		resources.ApplyResources(Me.btnDelete, "btnDelete")
		Me.btnDelete.BackgroundImage = Nothing
		Me.btnDelete.Font = Nothing
		Me.btnDelete.Name = "btnDelete"
		Me.btnDelete.UseVisualStyleBackColor = true
		AddHandler Me.btnDelete.Click, AddressOf Me.BtnDeleteClick
		'
		'contextMenuCodeType
		'
		Me.contextMenuCodeType.AccessibleDescription = Nothing
		Me.contextMenuCodeType.AccessibleName = Nothing
		resources.ApplyResources(Me.contextMenuCodeType, "contextMenuCodeType")
		Me.contextMenuCodeType.BackgroundImage = Nothing
		Me.contextMenuCodeType.Font = Nothing
		Me.contextMenuCodeType.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.failedToolStripMenuItem, Me.succeededToolStripMenuItem, Me.cancelledToolStripMenuItem})
		Me.contextMenuCodeType.Name = "contextMenuStrip1"
		'
		'failedToolStripMenuItem
		'
		Me.failedToolStripMenuItem.AccessibleDescription = Nothing
		Me.failedToolStripMenuItem.AccessibleName = Nothing
		resources.ApplyResources(Me.failedToolStripMenuItem, "failedToolStripMenuItem")
		Me.failedToolStripMenuItem.BackgroundImage = Nothing
		Me.failedToolStripMenuItem.Name = "failedToolStripMenuItem"
		Me.failedToolStripMenuItem.ShortcutKeyDisplayString = Nothing
		'
		'succeededToolStripMenuItem
		'
		Me.succeededToolStripMenuItem.AccessibleDescription = Nothing
		Me.succeededToolStripMenuItem.AccessibleName = Nothing
		resources.ApplyResources(Me.succeededToolStripMenuItem, "succeededToolStripMenuItem")
		Me.succeededToolStripMenuItem.BackgroundImage = Nothing
		Me.succeededToolStripMenuItem.Name = "succeededToolStripMenuItem"
		Me.succeededToolStripMenuItem.ShortcutKeyDisplayString = Nothing
		'
		'cancelledToolStripMenuItem
		'
		Me.cancelledToolStripMenuItem.AccessibleDescription = Nothing
		Me.cancelledToolStripMenuItem.AccessibleName = Nothing
		resources.ApplyResources(Me.cancelledToolStripMenuItem, "cancelledToolStripMenuItem")
		Me.cancelledToolStripMenuItem.BackgroundImage = Nothing
		Me.cancelledToolStripMenuItem.Name = "cancelledToolStripMenuItem"
		Me.cancelledToolStripMenuItem.ShortcutKeyDisplayString = Nothing
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
		'ReturnCodesForm
		'
		Me.AccessibleDescription = Nothing
		Me.AccessibleName = Nothing
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
		Me.BackgroundImage = Nothing
		Me.CancelButton = Me.btnCancel
		Me.Controls.Add(Me.btnDelete)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnOk)
		Me.Controls.Add(Me.dgvReturnCodes)
		Me.Font = Nothing
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = Nothing
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "ReturnCodesForm"
		Me.ShowInTaskbar = false
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
