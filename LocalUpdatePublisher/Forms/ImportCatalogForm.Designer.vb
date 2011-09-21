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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportCatalogForm))
		Me.btnCancel = New System.Windows.Forms.Button
		Me.btnImport = New System.Windows.Forms.Button
		Me.dgvUpdates = New System.Windows.Forms.DataGridView
		Me.Include = New System.Windows.Forms.DataGridViewCheckBoxColumn
		Me.Metadata = New System.Windows.Forms.DataGridViewCheckBoxColumn
		Me.Title = New System.Windows.Forms.DataGridViewTextBoxColumn
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
		'btnImport
		'
		resources.ApplyResources(Me.btnImport, "btnImport")
		Me.btnImport.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnImport.Name = "btnImport"
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
		Me.tableLayoutPanel1.SetColumnSpan(Me.dgvUpdates, 5)
		resources.ApplyResources(Me.dgvUpdates, "dgvUpdates")
		Me.dgvUpdates.Name = "dgvUpdates"
		Me.dgvUpdates.RowHeadersVisible = false
		'
		'Include
		'
		Me.Include.FillWeight = 10!
		resources.ApplyResources(Me.Include, "Include")
		Me.Include.Name = "Include"
		'
		'Metadata
		'
		Me.Metadata.FillWeight = 25!
		resources.ApplyResources(Me.Metadata, "Metadata")
		Me.Metadata.Name = "Metadata"
		'
		'Title
		'
		Me.Title.FillWeight = 145.6853!
		resources.ApplyResources(Me.Title, "Title")
		Me.Title.Name = "Title"
		'
		'tableLayoutPanel1
		'
		resources.ApplyResources(Me.tableLayoutPanel1, "tableLayoutPanel1")
		Me.tableLayoutPanel1.Controls.Add(Me.dgvUpdates, 0, 0)
		Me.tableLayoutPanel1.Controls.Add(Me.btnCancel, 3, 1)
		Me.tableLayoutPanel1.Controls.Add(Me.btnImport, 2, 1)
		Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
		'
		'ImportCatalogForm
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.btnCancel
		Me.Controls.Add(Me.tableLayoutPanel1)
		Me.MinimizeBox = false
		Me.Name = "ImportCatalogForm"
		Me.ShowInTaskbar = false
		AddHandler FormClosed, AddressOf Me.ImportCatalogFormFormClosed
		CType(Me.dgvUpdates,System.ComponentModel.ISupportInitialize).EndInit
		Me.tableLayoutPanel1.ResumeLayout(false)
		Me.tableLayoutPanel1.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Private Metadata As System.Windows.Forms.DataGridViewCheckBoxColumn
	Private btnImport As System.Windows.Forms.Button
	Private Title As System.Windows.Forms.DataGridViewTextBoxColumn
	Private dgvUpdates As System.Windows.Forms.DataGridView
	Private Include As System.Windows.Forms.DataGridViewCheckBoxColumn
	Private btnCancel As System.Windows.Forms.Button
End Class
