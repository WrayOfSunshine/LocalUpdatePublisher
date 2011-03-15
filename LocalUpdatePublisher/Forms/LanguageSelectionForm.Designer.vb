'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 3/25/2010
' Time: 11:44 AM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class LanguageSelectionForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LanguageSelectionForm))
		Me.btnRemove = New System.Windows.Forms.Button
		Me.btnCancel = New System.Windows.Forms.Button
		Me.dgvLanguages = New System.Windows.Forms.DataGridView
		Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.Language = New System.Windows.Forms.DataGridViewComboBoxColumn
		Me.btnOk = New System.Windows.Forms.Button
		CType(Me.dgvLanguages,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'btnRemove
		'
		resources.ApplyResources(Me.btnRemove, "btnRemove")
		Me.btnRemove.Name = "btnRemove"
		Me.btnRemove.UseVisualStyleBackColor = true
		AddHandler Me.btnRemove.Click, AddressOf Me.BtnRemoveClick
		'
		'btnCancel
		'
		resources.ApplyResources(Me.btnCancel, "btnCancel")
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.UseVisualStyleBackColor = true
		'
		'dgvLanguages
		'
		Me.dgvLanguages.AllowUserToResizeColumns = false
		Me.dgvLanguages.AllowUserToResizeRows = false
		resources.ApplyResources(Me.dgvLanguages, "dgvLanguages")
		Me.dgvLanguages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.dgvLanguages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvLanguages.ColumnHeadersVisible = false
		Me.dgvLanguages.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Language})
		Me.dgvLanguages.Name = "dgvLanguages"
		Me.dgvLanguages.RowHeadersVisible = false
		Me.dgvLanguages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		AddHandler Me.dgvLanguages.CellValueChanged, AddressOf Me.DgvLanguagesCellValueChanged
		'
		'Id
		'
		resources.ApplyResources(Me.Id, "Id")
		Me.Id.Name = "Id"
		'
		'Language
		'
		resources.ApplyResources(Me.Language, "Language")
		Me.Language.Name = "Language"
		Me.Language.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
		Me.Language.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
		'
		'btnOk
		'
		resources.ApplyResources(Me.btnOk, "btnOk")
		Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnOk.Name = "btnOk"
		Me.btnOk.UseVisualStyleBackColor = true
		'
		'LanguageSelectionForm
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.btnCancel
		Me.Controls.Add(Me.btnOk)
		Me.Controls.Add(Me.btnRemove)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.dgvLanguages)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "LanguageSelectionForm"
		Me.ShowInTaskbar = false
		CType(Me.dgvLanguages,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
	End Sub
	Private dgvLanguages As System.Windows.Forms.DataGridView
	Private Id As System.Windows.Forms.DataGridViewTextBoxColumn
	Private btnOk As System.Windows.Forms.Button
	Private btnCancel As System.Windows.Forms.Button
	Private Language As System.Windows.Forms.DataGridViewComboBoxColumn
	Private btnRemove As System.Windows.Forms.Button
End Class
