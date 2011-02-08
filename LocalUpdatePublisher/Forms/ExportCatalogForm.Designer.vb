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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExportCatalogForm))
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
		resources.ApplyResources(Me.btnCancel, "btnCancel")
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.UseVisualStyleBackColor = true
		'
		'btnExport
		'
		resources.ApplyResources(Me.btnExport, "btnExport")
		Me.btnExport.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnExport.Name = "btnExport"
		Me.btnExport.UseVisualStyleBackColor = true
		AddHandler Me.btnExport.Click, AddressOf Me.BtnExportClick
		'
		'dgvUpdates
		'
		Me.dgvUpdates.AllowUserToAddRows = false
		Me.dgvUpdates.AllowUserToDeleteRows = false
		Me.dgvUpdates.AllowUserToResizeColumns = false
		Me.dgvUpdates.AllowUserToResizeRows = false
		resources.ApplyResources(Me.dgvUpdates, "dgvUpdates")
		Me.dgvUpdates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.dgvUpdates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvUpdates.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.File, Me.Include, Me.Title})
		Me.dgvUpdates.Name = "dgvUpdates"
		Me.dgvUpdates.RowHeadersVisible = false
		'
		'Id
		'
		resources.ApplyResources(Me.Id, "Id")
		Me.Id.Name = "Id"
		'
		'File
		'
		resources.ApplyResources(Me.File, "File")
		Me.File.Name = "File"
		'
		'Include
		'
		Me.Include.FillWeight = 3.045685!
		resources.ApplyResources(Me.Include, "Include")
		Me.Include.Name = "Include"
		'
		'Title
		'
		Me.Title.FillWeight = 56.95432!
		resources.ApplyResources(Me.Title, "Title")
		Me.Title.Name = "Title"
		Me.Title.ReadOnly = true
		'
		'btnAdd
		'
		resources.ApplyResources(Me.btnAdd, "btnAdd")
		Me.btnAdd.Name = "btnAdd"
		Me.btnAdd.UseVisualStyleBackColor = true
		AddHandler Me.btnAdd.Click, AddressOf Me.BtnAddClick
		'
		'btnAddAll
		'
		resources.ApplyResources(Me.btnAddAll, "btnAddAll")
		Me.btnAddAll.Name = "btnAddAll"
		Me.btnAddAll.UseVisualStyleBackColor = true
		AddHandler Me.btnAddAll.Click, AddressOf Me.BtnAddAllClick
		'
		'exportFileDialog
		'
		Me.exportFileDialog.DefaultExt = "tab"
		resources.ApplyResources(Me.exportFileDialog, "exportFileDialog")
		'
		'ExportCatalogForm
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.btnCancel
		Me.Controls.Add(Me.btnAdd)
		Me.Controls.Add(Me.btnAddAll)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnExport)
		Me.Controls.Add(Me.dgvUpdates)
		Me.MinimizeBox = false
		Me.Name = "ExportCatalogForm"
		Me.ShowInTaskbar = false
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
