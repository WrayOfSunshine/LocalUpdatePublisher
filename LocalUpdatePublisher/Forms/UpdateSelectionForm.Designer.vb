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
		CType(Me.dgvUpdates,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
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
		'btnSelect
		'
		Me.btnSelect.AccessibleDescription = Nothing
		Me.btnSelect.AccessibleName = Nothing
		resources.ApplyResources(Me.btnSelect, "btnSelect")
		Me.btnSelect.BackgroundImage = Nothing
		Me.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnSelect.Font = Nothing
		Me.btnSelect.Name = "btnSelect"
		Me.btnSelect.UseVisualStyleBackColor = true
		'
		'dgvUpdates
		'
		Me.dgvUpdates.AccessibleDescription = Nothing
		Me.dgvUpdates.AccessibleName = Nothing
		Me.dgvUpdates.AllowUserToAddRows = false
		Me.dgvUpdates.AllowUserToDeleteRows = false
		Me.dgvUpdates.AllowUserToResizeColumns = false
		Me.dgvUpdates.AllowUserToResizeRows = false
		resources.ApplyResources(Me.dgvUpdates, "dgvUpdates")
		Me.dgvUpdates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.dgvUpdates.BackgroundImage = Nothing
		Me.dgvUpdates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvUpdates.ColumnHeadersVisible = false
		Me.dgvUpdates.Font = Nothing
		Me.dgvUpdates.MultiSelect = false
		Me.dgvUpdates.Name = "dgvUpdates"
		Me.dgvUpdates.ReadOnly = true
		Me.dgvUpdates.RowHeadersVisible = false
		Me.dgvUpdates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		AddHandler Me.dgvUpdates.CellMouseDoubleClick, AddressOf Me.DgvUpdatesCellMouseDoubleClick
		'
		'cboVendor
		'
		Me.cboVendor.AccessibleDescription = Nothing
		Me.cboVendor.AccessibleName = Nothing
		resources.ApplyResources(Me.cboVendor, "cboVendor")
		Me.cboVendor.BackgroundImage = Nothing
		Me.cboVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboVendor.Font = Nothing
		Me.cboVendor.FormattingEnabled = true
		Me.cboVendor.Name = "cboVendor"
		AddHandler Me.cboVendor.SelectedIndexChanged, AddressOf Me.CboVendorSelectedIndexChanged
		'
		'lblVendor
		'
		Me.lblVendor.AccessibleDescription = Nothing
		Me.lblVendor.AccessibleName = Nothing
		resources.ApplyResources(Me.lblVendor, "lblVendor")
		Me.lblVendor.Name = "lblVendor"
		'
		'UpdateSelectionForm
		'
		Me.AccessibleDescription = Nothing
		Me.AccessibleName = Nothing
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackgroundImage = Nothing
		Me.CancelButton = Me.btnCancel
		Me.Controls.Add(Me.cboVendor)
		Me.Controls.Add(Me.lblVendor)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnSelect)
		Me.Controls.Add(Me.dgvUpdates)
		Me.Font = Nothing
		Me.Icon = Nothing
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "UpdateSelectionForm"
		Me.ShowInTaskbar = false
		CType(Me.dgvUpdates,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
	End Sub
	Private lblVendor As System.Windows.Forms.Label
	Private cboVendor As System.Windows.Forms.ComboBox
	Private dgvUpdates As System.Windows.Forms.DataGridView
	Private btnSelect As System.Windows.Forms.Button
	Private btnCancel As System.Windows.Forms.Button
End Class
