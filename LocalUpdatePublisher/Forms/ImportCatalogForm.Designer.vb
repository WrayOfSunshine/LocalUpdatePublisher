'
' Created by SharpDevelop.
' User: Bryan
' Date: 3/25/2010
' Time: 8:46 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class ImportCatalogForm
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
		Me.btnImport = New System.Windows.Forms.Button
		Me.dgvUpdates = New System.Windows.Forms.DataGridView
		Me.Include = New System.Windows.Forms.DataGridViewCheckBoxColumn
		Me.Metadata = New System.Windows.Forms.DataGridViewCheckBoxColumn
		Me.Title = New System.Windows.Forms.DataGridViewTextBoxColumn
		CType(Me.dgvUpdates,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'btnCancel
		'
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Location = New System.Drawing.Point(367, 263)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(75, 23)
		Me.btnCancel.TabIndex = 7
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.UseVisualStyleBackColor = true
		'
		'btnImport
		'
		Me.btnImport.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnImport.Location = New System.Drawing.Point(286, 263)
		Me.btnImport.Name = "btnImport"
		Me.btnImport.Size = New System.Drawing.Size(75, 23)
		Me.btnImport.TabIndex = 6
		Me.btnImport.Text = "Import"
		Me.btnImport.UseVisualStyleBackColor = true
		AddHandler Me.btnImport.Click, AddressOf Me.BtnImportClick
		'
		'dgvUpdates
		'
		Me.dgvUpdates.AllowUserToAddRows = false
		Me.dgvUpdates.AllowUserToDeleteRows = false
		Me.dgvUpdates.AllowUserToResizeColumns = false
		Me.dgvUpdates.AllowUserToResizeRows = false
		Me.dgvUpdates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.dgvUpdates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvUpdates.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Include, Me.Metadata, Me.Title})
		Me.dgvUpdates.Location = New System.Drawing.Point(12, 12)
		Me.dgvUpdates.Name = "dgvUpdates"
		Me.dgvUpdates.RowHeadersVisible = false
		Me.dgvUpdates.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.dgvUpdates.Size = New System.Drawing.Size(430, 245)
		Me.dgvUpdates.TabIndex = 5
		'
		'Include
		'
		Me.Include.FillWeight = 10!
		Me.Include.HeaderText = ""
		Me.Include.Name = "Include"
		'
		'Metadata
		'
		Me.Metadata.FillWeight = 25!
		Me.Metadata.HeaderText = "Metadata"
		Me.Metadata.Name = "Metadata"
		'
		'Title
		'
		Me.Title.FillWeight = 145.6853!
		Me.Title.HeaderText = "Title"
		Me.Title.Name = "Title"
		'
		'ImportCatalogForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.btnCancel
		Me.ClientSize = New System.Drawing.Size(452, 297)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnImport)
		Me.Controls.Add(Me.dgvUpdates)
		Me.MinimizeBox = false
		Me.Name = "ImportCatalogForm"
		Me.ShowInTaskbar = false
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "Select Updates to Import"
		AddHandler FormClosed, AddressOf Me.ImportCatalogFormFormClosed
		CType(Me.dgvUpdates,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
	End Sub
	Private Metadata As System.Windows.Forms.DataGridViewCheckBoxColumn
	Private btnImport As System.Windows.Forms.Button
	Private Title As System.Windows.Forms.DataGridViewTextBoxColumn
	Private dgvUpdates As System.Windows.Forms.DataGridView
	Private Include As System.Windows.Forms.DataGridViewCheckBoxColumn
	Private btnCancel As System.Windows.Forms.Button
End Class
