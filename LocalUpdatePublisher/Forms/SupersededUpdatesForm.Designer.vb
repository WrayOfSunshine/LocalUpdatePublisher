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
		Me.btnRemove = New System.Windows.Forms.Button
		Me.btnCancel = New System.Windows.Forms.Button
		Me.btnAdd = New System.Windows.Forms.Button
		Me.dgvUpdates = New System.Windows.Forms.DataGridView
		Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.Title = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.btnOk = New System.Windows.Forms.Button
		CType(Me.dgvUpdates,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'btnRemove
		'
		Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.btnRemove.Location = New System.Drawing.Point(12, 263)
		Me.btnRemove.Name = "btnRemove"
		Me.btnRemove.Size = New System.Drawing.Size(75, 23)
		Me.btnRemove.TabIndex = 9
		Me.btnRemove.Text = "Remove"
		Me.btnRemove.UseVisualStyleBackColor = true
		AddHandler Me.btnRemove.Click, AddressOf Me.BtnRemoveClick
		'
		'btnCancel
		'
		Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Location = New System.Drawing.Point(367, 263)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(75, 23)
		Me.btnCancel.TabIndex = 8
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.UseVisualStyleBackColor = true
		'
		'btnAdd
		'
		Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.btnAdd.Location = New System.Drawing.Point(93, 263)
		Me.btnAdd.Name = "btnAdd"
		Me.btnAdd.Size = New System.Drawing.Size(75, 23)
		Me.btnAdd.TabIndex = 7
		Me.btnAdd.Text = "Add"
		Me.btnAdd.UseVisualStyleBackColor = true
		AddHandler Me.btnAdd.Click, AddressOf Me.BtnAddClick
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
		Me.dgvUpdates.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Title})
		Me.dgvUpdates.Location = New System.Drawing.Point(12, 12)
		Me.dgvUpdates.Name = "dgvUpdates"
		Me.dgvUpdates.ReadOnly = true
		Me.dgvUpdates.RowHeadersVisible = false
		Me.dgvUpdates.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.dgvUpdates.Size = New System.Drawing.Size(430, 245)
		Me.dgvUpdates.TabIndex = 6
		'
		'Id
		'
		Me.Id.HeaderText = "Id"
		Me.Id.Name = "Id"
		Me.Id.ReadOnly = true
		Me.Id.Visible = false
		'
		'Title
		'
		Me.Title.HeaderText = "Title"
		Me.Title.Name = "Title"
		Me.Title.ReadOnly = true
		'
		'btnOk
		'
		Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnOk.Location = New System.Drawing.Point(286, 263)
		Me.btnOk.Name = "btnOk"
		Me.btnOk.Size = New System.Drawing.Size(75, 23)
		Me.btnOk.TabIndex = 10
		Me.btnOk.Text = "Ok"
		Me.btnOk.UseVisualStyleBackColor = true
		AddHandler Me.btnOk.Click, AddressOf Me.BtnOkClick
		'
		'SupersededUpdatesForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.btnCancel
		Me.ClientSize = New System.Drawing.Size(454, 294)
		Me.Controls.Add(Me.btnOk)
		Me.Controls.Add(Me.btnRemove)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnAdd)
		Me.Controls.Add(Me.dgvUpdates)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "SupersededUpdatesForm"
		Me.ShowInTaskbar = false
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "Superseded Updates"
		CType(Me.dgvUpdates,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
	End Sub
	Private btnOk As System.Windows.Forms.Button
	Private btnCancel As System.Windows.Forms.Button
	Private Title As System.Windows.Forms.DataGridViewTextBoxColumn
	Private Id As System.Windows.Forms.DataGridViewTextBoxColumn
	Private dgvUpdates As System.Windows.Forms.DataGridView
	Private btnAdd As System.Windows.Forms.Button
	Private btnRemove As System.Windows.Forms.Button
End Class
