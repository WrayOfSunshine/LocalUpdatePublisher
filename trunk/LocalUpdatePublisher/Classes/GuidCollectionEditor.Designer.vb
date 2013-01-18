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
		Me.components = New System.ComponentModel.Container
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GuidCollectionEditor))
		Me.dgv = New System.Windows.Forms.DataGridView
		Me.dgvItems = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.panel1 = New System.Windows.Forms.Panel
		Me.btnRemove = New System.Windows.Forms.Button
		Me.btnAdd = New System.Windows.Forms.Button
		Me.errorProviderGUID = New System.Windows.Forms.ErrorProvider(Me.components)
		Me.panel1.SuspendLayout
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
		resources.ApplyResources(Me.dgv, "dgv")
		Me.dgv.MultiSelect = false
		Me.dgv.Name = "dgv"
		Me.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
		Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgv.TabStop = false
		AddHandler Me.dgv.CellEndEdit, AddressOf Me.dgv_CellEndEdit
		AddHandler Me.dgv.SelectionChanged, AddressOf Me.dgv_SelectionChanged
		'
		'dgvItems
		'
		resources.ApplyResources(Me.dgvItems, "dgvItems")
		Me.dgvItems.MaxInputLength = 40
		Me.dgvItems.Name = "dgvItems"
		'
		'panel1
		'
		Me.panel1.Controls.Add(Me.btnRemove)
		Me.panel1.Controls.Add(Me.btnAdd)
		resources.ApplyResources(Me.panel1, "panel1")
		Me.panel1.Name = "panel1"
		'
		'btnRemove
		'
		resources.ApplyResources(Me.btnRemove, "btnRemove")
		Me.btnRemove.Name = "btnRemove"
		Me.btnRemove.UseVisualStyleBackColor = true
		AddHandler Me.btnRemove.Click, AddressOf Me.btnRemove_Click
		'
		'btnAdd
		'
		resources.ApplyResources(Me.btnAdd, "btnAdd")
		Me.btnAdd.Name = "btnAdd"
		Me.btnAdd.UseVisualStyleBackColor = true
		AddHandler Me.btnAdd.Click, AddressOf Me.btnAdd_Click
		'
		'errorProviderGUID
		'
		Me.errorProviderGUID.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
		Me.errorProviderGUID.ContainerControl = Me
		'
		'GuidCollectionEditor
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.dgv)
		Me.Controls.Add(Me.panel1)
		Me.Name = "GuidCollectionEditor"
		AddHandler Load, AddressOf Me.GuidCollectionEditor_Load
		Me.panel1.ResumeLayout(false)
		Me.ResumeLayout(false)
	End Sub
	Private errorProviderGUID As System.Windows.Forms.ErrorProvider
	
	#End Region
	
    Private WithEvents dgv As System.Windows.Forms.DataGridView
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents btnRemove As System.Windows.Forms.Button
    Private WithEvents btnAdd As System.Windows.Forms.Button
    Private WithEvents dgvItems As System.Windows.Forms.DataGridViewTextBoxColumn
	
End Class

