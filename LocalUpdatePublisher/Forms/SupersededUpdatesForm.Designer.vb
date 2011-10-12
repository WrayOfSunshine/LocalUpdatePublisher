'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 3/25/2010
' Time: 11:44 AM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class SupersededUpdatesForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SupersededUpdatesForm))
		Me.btnRemove = New System.Windows.Forms.Button
		Me.btnCancel = New System.Windows.Forms.Button
		Me.btnAdd = New System.Windows.Forms.Button
		Me.dgvUpdates = New System.Windows.Forms.DataGridView
		Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.Title = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.btnOk = New System.Windows.Forms.Button
		Me.tlpMain = New System.Windows.Forms.TableLayoutPanel
		CType(Me.dgvUpdates,System.ComponentModel.ISupportInitialize).BeginInit
		Me.tlpMain.SuspendLayout
		Me.SuspendLayout
		'
		'btnRemove
		'
		resources.ApplyResources(Me.btnRemove, "btnRemove")
		Me.btnRemove.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnRemove.Name = "btnRemove"
		Me.btnRemove.UseVisualStyleBackColor = true
		AddHandler Me.btnRemove.Click, AddressOf Me.BtnRemoveClick
		'
		'btnCancel
		'
		resources.ApplyResources(Me.btnCancel, "btnCancel")
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.UseVisualStyleBackColor = true
		'
		'btnAdd
		'
		resources.ApplyResources(Me.btnAdd, "btnAdd")
		Me.btnAdd.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnAdd.Name = "btnAdd"
		Me.btnAdd.UseVisualStyleBackColor = true
		AddHandler Me.btnAdd.Click, AddressOf Me.BtnAddClick
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
		Me.dgvUpdates.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Title})
		Me.tlpMain.SetColumnSpan(Me.dgvUpdates, 5)
		resources.ApplyResources(Me.dgvUpdates, "dgvUpdates")
		Me.dgvUpdates.Name = "dgvUpdates"
		Me.dgvUpdates.ReadOnly = true
		Me.dgvUpdates.RowHeadersVisible = false
		Me.dgvUpdates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		'
		'Id
		'
		resources.ApplyResources(Me.Id, "Id")
		Me.Id.Name = "Id"
		Me.Id.ReadOnly = true
		'
		'Title
		'
		resources.ApplyResources(Me.Title, "Title")
		Me.Title.Name = "Title"
		Me.Title.ReadOnly = true
		'
		'btnOk
		'
		resources.ApplyResources(Me.btnOk, "btnOk")
		Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnOk.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnOk.Name = "btnOk"
		Me.btnOk.UseVisualStyleBackColor = true
		AddHandler Me.btnOk.Click, AddressOf Me.BtnOkClick
		'
		'tlpMain
		'
		resources.ApplyResources(Me.tlpMain, "tlpMain")
		Me.tlpMain.Controls.Add(Me.btnRemove, 0, 1)
		Me.tlpMain.Controls.Add(Me.btnAdd, 1, 1)
		Me.tlpMain.Controls.Add(Me.btnCancel, 4, 1)
		Me.tlpMain.Controls.Add(Me.dgvUpdates, 0, 0)
		Me.tlpMain.Controls.Add(Me.btnOk, 3, 1)
		Me.tlpMain.Name = "tlpMain"
		'
		'SupersededUpdatesForm
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.btnCancel
		Me.Controls.Add(Me.tlpMain)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "SupersededUpdatesForm"
		Me.ShowInTaskbar = false
		CType(Me.dgvUpdates,System.ComponentModel.ISupportInitialize).EndInit
		Me.tlpMain.ResumeLayout(false)
		Me.tlpMain.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private tlpMain As System.Windows.Forms.TableLayoutPanel
	Private btnOk As System.Windows.Forms.Button
	Private btnCancel As System.Windows.Forms.Button
	Private Title As System.Windows.Forms.DataGridViewTextBoxColumn
	Private Id As System.Windows.Forms.DataGridViewTextBoxColumn
	Private dgvUpdates As System.Windows.Forms.DataGridView
	Private btnAdd As System.Windows.Forms.Button
	Private btnRemove As System.Windows.Forms.Button
End Class
