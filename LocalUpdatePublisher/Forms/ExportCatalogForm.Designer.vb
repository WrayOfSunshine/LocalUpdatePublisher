'
' Created by SharpDevelop.
' User: Bryan
' Date: 7/19/2010
' Time: 8:46 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class ExportCatalogForm
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
		Me.btnExport = New System.Windows.Forms.Button
		Me.dgvUpdates = New System.Windows.Forms.DataGridView
		Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.File = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.Include = New System.Windows.Forms.DataGridViewCheckBoxColumn
		Me.Title = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.btnAdd = New System.Windows.Forms.Button
		Me.btnAddAll = New System.Windows.Forms.Button
		Me.exportFileDialog = New System.Windows.Forms.SaveFileDialog
		CType(Me.dgvUpdates,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'btnCancel
		'
		Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Location = New System.Drawing.Point(377, 263)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(75, 23)
		Me.btnCancel.TabIndex = 7
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.UseVisualStyleBackColor = true
		'
		'btnExport
		'
		Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.btnExport.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnExport.Enabled = false
		Me.btnExport.Location = New System.Drawing.Point(296, 263)
		Me.btnExport.Name = "btnExport"
		Me.btnExport.Size = New System.Drawing.Size(75, 23)
		Me.btnExport.TabIndex = 6
		Me.btnExport.Text = "Export"
		Me.btnExport.UseVisualStyleBackColor = true
		AddHandler Me.btnExport.Click, AddressOf Me.BtnExportClick
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
		Me.dgvUpdates.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.File, Me.Include, Me.Title})
		Me.dgvUpdates.Location = New System.Drawing.Point(12, 12)
		Me.dgvUpdates.Name = "dgvUpdates"
		Me.dgvUpdates.RowHeadersVisible = false
		Me.dgvUpdates.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.dgvUpdates.Size = New System.Drawing.Size(434, 245)
		Me.dgvUpdates.TabIndex = 5
		'
		'Id
		'
		Me.Id.HeaderText = "Id"
		Me.Id.Name = "Id"
		Me.Id.Visible = false
		'
		'File
		'
		Me.File.HeaderText = "File"
		Me.File.Name = "File"
		Me.File.Visible = false
		'
		'Include
		'
		Me.Include.FillWeight = 3.045685!
		Me.Include.HeaderText = ""
		Me.Include.Name = "Include"
		'
		'Title
		'
		Me.Title.FillWeight = 56.95432!
		Me.Title.HeaderText = "Title"
		Me.Title.Name = "Title"
		Me.Title.ReadOnly = true
		'
		'btnAdd
		'
		Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.btnAdd.Location = New System.Drawing.Point(93, 262)
		Me.btnAdd.Name = "btnAdd"
		Me.btnAdd.Size = New System.Drawing.Size(75, 23)
		Me.btnAdd.TabIndex = 9
		Me.btnAdd.Text = "Add"
		Me.btnAdd.UseVisualStyleBackColor = true
		AddHandler Me.btnAdd.Click, AddressOf Me.BtnAddClick
		'
		'btnAddAll
		'
		Me.btnAddAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.btnAddAll.Location = New System.Drawing.Point(12, 262)
		Me.btnAddAll.Name = "btnAddAll"
		Me.btnAddAll.Size = New System.Drawing.Size(75, 23)
		Me.btnAddAll.TabIndex = 8
		Me.btnAddAll.Text = "Add All"
		Me.btnAddAll.UseVisualStyleBackColor = true
		AddHandler Me.btnAddAll.Click, AddressOf Me.BtnAddAllClick
		'
		'exportFileDialog
		'
		Me.exportFileDialog.DefaultExt = "tab"
		Me.exportFileDialog.Filter = "Tab Delimited|*.tab"
		'
		'ExportCatalogForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.btnCancel
		Me.ClientSize = New System.Drawing.Size(458, 297)
		Me.Controls.Add(Me.btnAdd)
		Me.Controls.Add(Me.btnAddAll)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnExport)
		Me.Controls.Add(Me.dgvUpdates)
		Me.MinimizeBox = false
		Me.Name = "ExportCatalogForm"
		Me.ShowInTaskbar = false
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "Select Updates to Export"
		AddHandler FormClosed, AddressOf Me.ExportCatalogFormFormClosed
		CType(Me.dgvUpdates,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
	End Sub
	Private File As System.Windows.Forms.DataGridViewTextBoxColumn
	Private exportFileDialog As System.Windows.Forms.SaveFileDialog
	Private Id As System.Windows.Forms.DataGridViewTextBoxColumn
	Private btnAddAll As System.Windows.Forms.Button
	Private btnAdd As System.Windows.Forms.Button
	Private btnExport As System.Windows.Forms.Button
	Private Title As System.Windows.Forms.DataGridViewTextBoxColumn
	Private dgvUpdates As System.Windows.Forms.DataGridView
	Private Include As System.Windows.Forms.DataGridViewCheckBoxColumn
	Private btnCancel As System.Windows.Forms.Button
End Class
