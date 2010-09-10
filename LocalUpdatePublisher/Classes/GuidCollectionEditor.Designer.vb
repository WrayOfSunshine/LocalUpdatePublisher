' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt

Partial Class GuidCollectionEditor
	''' <summary>
	''' Required designer Objectiable.
	''' </summary>
	Private components As System.ComponentModel.IContainer = Nothing
	
	''' <summary>
	''' Clean up any resources being used.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overloads Overrides Sub Dispose(disposing As Boolean)
		If disposing AndAlso (components IsNot Nothing) Then
			components.Dispose()
		End If
		MyBase.Dispose(disposing)
	End Sub
	
	#Region "Component Designer generated code"
	
	''' <summary>
	''' Required method for Designer support - do not modify
	''' the contents of this method with the code editor.
	''' </summary>
	Private Sub InitializeComponent()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GuidCollectionEditor))
		Me.dgv = New System.Windows.Forms.DataGridView
		Me.dgvItems = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.panel1 = New System.Windows.Forms.Panel
		Me.picValid = New System.Windows.Forms.PictureBox
		Me.btnRemove = New System.Windows.Forms.Button
		Me.btnAdd = New System.Windows.Forms.Button
		CType(Me.dgv,System.ComponentModel.ISupportInitialize).BeginInit
		Me.panel1.SuspendLayout
		CType(Me.picValid,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'dgv
		'
		Me.dgv.AllowUserToAddRows = false
		Me.dgv.AllowUserToDeleteRows = false
		Me.dgv.AllowUserToResizeColumns = false
		Me.dgv.AllowUserToResizeRows = false
		Me.dgv.BackgroundColor = System.Drawing.SystemColors.Control
		Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvItems})
		Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
		Me.dgv.Location = New System.Drawing.Point(0, 0)
		Me.dgv.MultiSelect = false
		Me.dgv.Name = "dgv"
		Me.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
		Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgv.Size = New System.Drawing.Size(290, 127)
		Me.dgv.TabIndex = 0
		AddHandler Me.dgv.CellEndEdit, AddressOf Me.dgv_CellEndEdit
		AddHandler Me.dgv.SelectionChanged, AddressOf Me.dgv_SelectionChanged
		'
		'dgvItems
		'
		Me.dgvItems.HeaderText = "Header Text"
		Me.dgvItems.MaxInputLength = 40
		Me.dgvItems.Name = "dgvItems"
		Me.dgvItems.Width = 225
		'
		'panel1
		'
		Me.panel1.Controls.Add(Me.picValid)
		Me.panel1.Controls.Add(Me.btnRemove)
		Me.panel1.Controls.Add(Me.btnAdd)
		Me.panel1.Dock = System.Windows.Forms.DockStyle.Right
		Me.panel1.Location = New System.Drawing.Point(290, 0)
		Me.panel1.Name = "panel1"
		Me.panel1.Size = New System.Drawing.Size(30, 127)
		Me.panel1.TabIndex = 1
		'
		'picValid
		'
		Me.picValid.Location = New System.Drawing.Point(5, 3)
		Me.picValid.Name = "picValid"
		Me.picValid.Size = New System.Drawing.Size(21, 21)
		Me.picValid.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
		Me.picValid.TabIndex = 2
		Me.picValid.TabStop = false
		'
		'btnRemove
		'
		Me.btnRemove.Image = CType(resources.GetObject("btnRemove.Image"),System.Drawing.Image)
		Me.btnRemove.Location = New System.Drawing.Point(3, 61)
		Me.btnRemove.Name = "btnRemove"
		Me.btnRemove.Size = New System.Drawing.Size(25, 25)
		Me.btnRemove.TabIndex = 1
		Me.btnRemove.UseVisualStyleBackColor = true
		AddHandler Me.btnRemove.Click, AddressOf Me.btnRemove_Click
		'
		'btnAdd
		'
		Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"),System.Drawing.Image)
		Me.btnAdd.Location = New System.Drawing.Point(3, 30)
		Me.btnAdd.Name = "btnAdd"
		Me.btnAdd.Size = New System.Drawing.Size(25, 25)
		Me.btnAdd.TabIndex = 0
		Me.btnAdd.UseVisualStyleBackColor = true
		AddHandler Me.btnAdd.Click, AddressOf Me.btnAdd_Click
		'
		'GuidCollectionEditor
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.dgv)
		Me.Controls.Add(Me.panel1)
		Me.Name = "GuidCollectionEditor"
		Me.Size = New System.Drawing.Size(320, 127)
		AddHandler Load, AddressOf Me.GuidCollectionEditor_Load
		CType(Me.dgv,System.ComponentModel.ISupportInitialize).EndInit
		Me.panel1.ResumeLayout(false)
		CType(Me.picValid,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
	End Sub
	
	#End Region
	
	Private dgv As System.Windows.Forms.DataGridView
	Private panel1 As System.Windows.Forms.Panel
	Private btnRemove As System.Windows.Forms.Button
	Private btnAdd As System.Windows.Forms.Button
	Private picValid As System.Windows.Forms.PictureBox
	Private dgvItems As System.Windows.Forms.DataGridViewTextBoxColumn
	
End Class

