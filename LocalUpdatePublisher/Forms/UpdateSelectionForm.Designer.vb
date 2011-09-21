'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 3/25/2010
' Time: 10:02 AM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class UpdateSelectionForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UpdateSelectionForm))
		Me.btnCancel = New System.Windows.Forms.Button
		Me.btnSelect = New System.Windows.Forms.Button
		Me.dgvUpdates = New System.Windows.Forms.DataGridView
		Me.cboVendor = New System.Windows.Forms.ComboBox
		Me.lblVendor = New System.Windows.Forms.Label
		Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
		CType(Me.dgvUpdates,System.ComponentModel.ISupportInitialize).BeginInit
		Me.tableLayoutPanel1.SuspendLayout
		Me.SuspendLayout
		'
		'btnCancel
		'
		resources.ApplyResources(Me.btnCancel, "btnCancel")
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.UseVisualStyleBackColor = true
		'
		'btnSelect
		'
		resources.ApplyResources(Me.btnSelect, "btnSelect")
		Me.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnSelect.Name = "btnSelect"
		Me.btnSelect.UseVisualStyleBackColor = true
		'
		'dgvUpdates
		'
		Me.dgvUpdates.AllowUserToAddRows = false
		Me.dgvUpdates.AllowUserToDeleteRows = false
		Me.dgvUpdates.AllowUserToResizeColumns = false
		Me.dgvUpdates.AllowUserToResizeRows = false
		Me.dgvUpdates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.dgvUpdates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvUpdates.ColumnHeadersVisible = false
		Me.tableLayoutPanel1.SetColumnSpan(Me.dgvUpdates, 4)
		resources.ApplyResources(Me.dgvUpdates, "dgvUpdates")
		Me.dgvUpdates.Name = "dgvUpdates"
		Me.dgvUpdates.ReadOnly = true
		Me.dgvUpdates.RowHeadersVisible = false
		Me.dgvUpdates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		AddHandler Me.dgvUpdates.CellMouseDoubleClick, AddressOf Me.DgvUpdatesCellMouseDoubleClick
		'
		'cboVendor
		'
		Me.tableLayoutPanel1.SetColumnSpan(Me.cboVendor, 2)
		Me.cboVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboVendor.FormattingEnabled = true
		resources.ApplyResources(Me.cboVendor, "cboVendor")
		Me.cboVendor.Name = "cboVendor"
		AddHandler Me.cboVendor.SelectedIndexChanged, AddressOf Me.CboVendorSelectedIndexChanged
		'
		'lblVendor
		'
		resources.ApplyResources(Me.lblVendor, "lblVendor")
		Me.lblVendor.Name = "lblVendor"
		'
		'tableLayoutPanel1
		'
		resources.ApplyResources(Me.tableLayoutPanel1, "tableLayoutPanel1")
		Me.tableLayoutPanel1.Controls.Add(Me.dgvUpdates, 0, 1)
		Me.tableLayoutPanel1.Controls.Add(Me.btnSelect, 2, 2)
		Me.tableLayoutPanel1.Controls.Add(Me.btnCancel, 3, 2)
		Me.tableLayoutPanel1.Controls.Add(Me.lblVendor, 0, 0)
		Me.tableLayoutPanel1.Controls.Add(Me.cboVendor, 1, 0)
		Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
		'
		'UpdateSelectionForm
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.btnCancel
		Me.Controls.Add(Me.tableLayoutPanel1)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "UpdateSelectionForm"
		Me.ShowInTaskbar = false
		CType(Me.dgvUpdates,System.ComponentModel.ISupportInitialize).EndInit
		Me.tableLayoutPanel1.ResumeLayout(false)
		Me.tableLayoutPanel1.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Private lblVendor As System.Windows.Forms.Label
	Private cboVendor As System.Windows.Forms.ComboBox
	Private dgvUpdates As System.Windows.Forms.DataGridView
	Private btnSelect As System.Windows.Forms.Button
	Private btnCancel As System.Windows.Forms.Button
End Class
