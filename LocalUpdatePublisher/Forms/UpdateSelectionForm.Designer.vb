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
		Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Location = New System.Drawing.Point(367, 278)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(75, 23)
		Me.btnCancel.TabIndex = 8
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.UseVisualStyleBackColor = true
		'
		'btnSelect
		'
		Me.btnSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnSelect.Enabled = false
		Me.btnSelect.Location = New System.Drawing.Point(286, 278)
		Me.btnSelect.Name = "btnSelect"
		Me.btnSelect.Size = New System.Drawing.Size(75, 23)
		Me.btnSelect.TabIndex = 7
		Me.btnSelect.Text = "Select"
		Me.btnSelect.UseVisualStyleBackColor = true
		'
		'dgvUpdates
		'
		Me.dgvUpdates.AllowUserToAddRows = false
		Me.dgvUpdates.AllowUserToDeleteRows = false
		Me.dgvUpdates.AllowUserToResizeColumns = false
		Me.dgvUpdates.AllowUserToResizeRows = false
		Me.dgvUpdates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
						Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.dgvUpdates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.dgvUpdates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvUpdates.ColumnHeadersVisible = false
		Me.dgvUpdates.Location = New System.Drawing.Point(11, 27)
		Me.dgvUpdates.MultiSelect = false
		Me.dgvUpdates.Name = "dgvUpdates"
		Me.dgvUpdates.ReadOnly = true
		Me.dgvUpdates.RowHeadersVisible = false
		Me.dgvUpdates.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.dgvUpdates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvUpdates.Size = New System.Drawing.Size(430, 245)
		Me.dgvUpdates.TabIndex = 6
		AddHandler Me.dgvUpdates.CellMouseDoubleClick, AddressOf Me.DgvUpdatesCellMouseDoubleClick
		'
		'cboVendor
		'
		Me.cboVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboVendor.FormattingEnabled = true
		Me.cboVendor.Location = New System.Drawing.Point(112, 3)
		Me.cboVendor.Name = "cboVendor"
		Me.cboVendor.Size = New System.Drawing.Size(233, 21)
		Me.cboVendor.TabIndex = 26
		AddHandler Me.cboVendor.SelectedIndexChanged, AddressOf Me.CboVendorSelectedIndexChanged
		'
		'lblVendor
		'
		Me.lblVendor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblVendor.Location = New System.Drawing.Point(19, 5)
		Me.lblVendor.Name = "lblVendor"
		Me.lblVendor.Size = New System.Drawing.Size(86, 17)
		Me.lblVendor.TabIndex = 25
		Me.lblVendor.Text = "Vendor"
		Me.lblVendor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'UpdateSelectionForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.btnCancel
		Me.ClientSize = New System.Drawing.Size(453, 306)
		Me.Controls.Add(Me.cboVendor)
		Me.Controls.Add(Me.lblVendor)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnSelect)
		Me.Controls.Add(Me.dgvUpdates)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "UpdateSelectionForm"
		Me.ShowInTaskbar = false
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "Select Update"
		CType(Me.dgvUpdates,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
	End Sub
	Private lblVendor As System.Windows.Forms.Label
	Private cboVendor As System.Windows.Forms.ComboBox
	Private dgvUpdates As System.Windows.Forms.DataGridView
	Private btnSelect As System.Windows.Forms.Button
	Private btnCancel As System.Windows.Forms.Button
End Class
