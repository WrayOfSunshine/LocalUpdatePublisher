' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt

Partial Class RulesEditor
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
		Dim dataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
		Me.lbl_instructions = New System.Windows.Forms.Label
		Me.btn_group = New System.Windows.Forms.Button
		Me.btn_edit = New System.Windows.Forms.Button
		Me.btn_remove = New System.Windows.Forms.Button
		Me.dgv_rules = New System.Windows.Forms.DataGridView
		Me.dataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.dataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.btn_add = New System.Windows.Forms.Button
		Me.lbl_title = New System.Windows.Forms.Label
		Me.lbl_xml = New System.Windows.Forms.Label
		Me.tb_xml = New System.Windows.Forms.TextBox
		Me.btnSaveRules = New System.Windows.Forms.Button
		Me.btnLoadRules = New System.Windows.Forms.Button
		Me.btnEditInstallableItem = New System.Windows.Forms.Button
		CType(Me.dgv_rules,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'lbl_instructions
		'
		Me.lbl_instructions.CausesValidation = false
		Me.lbl_instructions.Dock = System.Windows.Forms.DockStyle.Top
		Me.lbl_instructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lbl_instructions.Location = New System.Drawing.Point(0, 0)
		Me.lbl_instructions.Name = "lbl_instructions"
		Me.lbl_instructions.Size = New System.Drawing.Size(595, 42)
		Me.lbl_instructions.TabIndex = 47
		'
		'btn_group
		'
		Me.btn_group.CausesValidation = false
		Me.btn_group.Enabled = false
		Me.btn_group.Location = New System.Drawing.Point(322, 292)
		Me.btn_group.Name = "btn_group"
		Me.btn_group.Size = New System.Drawing.Size(80, 24)
		Me.btn_group.TabIndex = 46
		Me.btn_group.Text = "Group Rules"
		Me.btn_group.UseVisualStyleBackColor = true
		AddHandler Me.btn_group.Click, AddressOf Me.btn_group_Click
		'
		'btn_edit
		'
		Me.btn_edit.CausesValidation = false
		Me.btn_edit.Enabled = false
		Me.btn_edit.Location = New System.Drawing.Point(420, 292)
		Me.btn_edit.Name = "btn_edit"
		Me.btn_edit.Size = New System.Drawing.Size(80, 24)
		Me.btn_edit.TabIndex = 45
		Me.btn_edit.Text = "Edit Rule"
		Me.btn_edit.UseVisualStyleBackColor = true
		AddHandler Me.btn_edit.Click, AddressOf Me.btn_edit_Click
		'
		'btn_remove
		'
		Me.btn_remove.CausesValidation = false
		Me.btn_remove.Enabled = false
		Me.btn_remove.Location = New System.Drawing.Point(506, 292)
		Me.btn_remove.Name = "btn_remove"
		Me.btn_remove.Size = New System.Drawing.Size(80, 24)
		Me.btn_remove.TabIndex = 44
		Me.btn_remove.Text = "Remove Rule"
		Me.btn_remove.UseVisualStyleBackColor = true
		AddHandler Me.btn_remove.Click, AddressOf Me.btn_remove_Click
		'
		'dgv_rules
		'
		Me.dgv_rules.AllowUserToAddRows = false
		Me.dgv_rules.AllowUserToDeleteRows = false
		Me.dgv_rules.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
		Me.dgv_rules.CausesValidation = false
		Me.dgv_rules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgv_rules.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dataGridViewTextBoxColumn3, Me.dataGridViewTextBoxColumn4})
		dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
		dataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
		dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
		dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgv_rules.DefaultCellStyle = dataGridViewCellStyle1
		Me.dgv_rules.Location = New System.Drawing.Point(6, 62)
		Me.dgv_rules.Name = "dgv_rules"
		Me.dgv_rules.ReadOnly = true
		Me.dgv_rules.RowHeadersVisible = false
		Me.dgv_rules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgv_rules.Size = New System.Drawing.Size(580, 224)
		Me.dgv_rules.TabIndex = 43
		AddHandler Me.dgv_rules.RowsAdded, AddressOf Me.Dgv_rulesRowsAddRemoved
		AddHandler Me.dgv_rules.RowsRemoved, AddressOf Me.Dgv_rulesRowsAddRemoved
		AddHandler Me.dgv_rules.SelectionChanged, AddressOf Me.dgv_rules_SelectionChanged
		'
		'dataGridViewTextBoxColumn3
		'
		Me.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.dataGridViewTextBoxColumn3.HeaderText = "Rule"
		Me.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3"
		Me.dataGridViewTextBoxColumn3.ReadOnly = true
		'
		'dataGridViewTextBoxColumn4
		'
		Me.dataGridViewTextBoxColumn4.HeaderText = "XML"
		Me.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4"
		Me.dataGridViewTextBoxColumn4.ReadOnly = true
		Me.dataGridViewTextBoxColumn4.Visible = false
		'
		'btn_add
		'
		Me.btn_add.CausesValidation = false
		Me.btn_add.Location = New System.Drawing.Point(6, 292)
		Me.btn_add.Name = "btn_add"
		Me.btn_add.Size = New System.Drawing.Size(80, 24)
		Me.btn_add.TabIndex = 42
		Me.btn_add.Text = "Add Rule"
		Me.btn_add.UseVisualStyleBackColor = true
		AddHandler Me.btn_add.Click, AddressOf Me.btn_add_Click
		'
		'lbl_title
		'
		Me.lbl_title.CausesValidation = false
		Me.lbl_title.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lbl_title.Location = New System.Drawing.Point(13, 42)
		Me.lbl_title.Name = "lbl_title"
		Me.lbl_title.Size = New System.Drawing.Size(206, 17)
		Me.lbl_title.TabIndex = 41
		Me.lbl_title.Text = "Package Level - Installed Rules"
		'
		'lbl_xml
		'
		Me.lbl_xml.CausesValidation = false
		Me.lbl_xml.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lbl_xml.Location = New System.Drawing.Point(13, 322)
		Me.lbl_xml.Name = "lbl_xml"
		Me.lbl_xml.Size = New System.Drawing.Size(165, 17)
		Me.lbl_xml.TabIndex = 40
		Me.lbl_xml.Text = "Installable Item Level"
		'
		'tb_xml
		'
		Me.tb_xml.CausesValidation = false
		Me.tb_xml.Location = New System.Drawing.Point(3, 342)
		Me.tb_xml.Multiline = true
		Me.tb_xml.Name = "tb_xml"
		Me.tb_xml.ReadOnly = true
		Me.tb_xml.Size = New System.Drawing.Size(580, 110)
		Me.tb_xml.TabIndex = 39
		'
		'btnSaveRules
		'
		Me.btnSaveRules.CausesValidation = false
		Me.btnSaveRules.Enabled = false
		Me.btnSaveRules.Location = New System.Drawing.Point(417, 35)
		Me.btnSaveRules.Name = "btnSaveRules"
		Me.btnSaveRules.Size = New System.Drawing.Size(80, 24)
		Me.btnSaveRules.TabIndex = 49
		Me.btnSaveRules.Text = "Save Rules"
		Me.btnSaveRules.UseVisualStyleBackColor = true
		AddHandler Me.btnSaveRules.Click, AddressOf Me.BtnSaveRulesClick
		'
		'btnLoadRules
		'
		Me.btnLoadRules.CausesValidation = false
		Me.btnLoadRules.Location = New System.Drawing.Point(503, 35)
		Me.btnLoadRules.Name = "btnLoadRules"
		Me.btnLoadRules.Size = New System.Drawing.Size(80, 24)
		Me.btnLoadRules.TabIndex = 48
		Me.btnLoadRules.Text = "Load Rules"
		Me.btnLoadRules.UseVisualStyleBackColor = true
		AddHandler Me.btnLoadRules.Click, AddressOf Me.BtnLoadRulesClick
		'
		'btnEditInstallableItem
		'
		Me.btnEditInstallableItem.CausesValidation = false
		Me.btnEditInstallableItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 7!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.btnEditInstallableItem.Location = New System.Drawing.Point(148, 319)
		Me.btnEditInstallableItem.Margin = New System.Windows.Forms.Padding(0)
		Me.btnEditInstallableItem.Name = "btnEditInstallableItem"
		Me.btnEditInstallableItem.Size = New System.Drawing.Size(40, 20)
		Me.btnEditInstallableItem.TabIndex = 50
		Me.btnEditInstallableItem.Text = "Edit"
		Me.btnEditInstallableItem.UseVisualStyleBackColor = true
		AddHandler Me.btnEditInstallableItem.Click, AddressOf Me.BtnEditInstallableItemClick
		'
		'RulesEditor
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CausesValidation = false
		Me.Controls.Add(Me.btnEditInstallableItem)
		Me.Controls.Add(Me.btnSaveRules)
		Me.Controls.Add(Me.btnLoadRules)
		Me.Controls.Add(Me.btn_group)
		Me.Controls.Add(Me.btn_edit)
		Me.Controls.Add(Me.btn_remove)
		Me.Controls.Add(Me.dgv_rules)
		Me.Controls.Add(Me.btn_add)
		Me.Controls.Add(Me.lbl_title)
		Me.Controls.Add(Me.lbl_xml)
		Me.Controls.Add(Me.tb_xml)
		Me.Controls.Add(Me.lbl_instructions)
		Me.Name = "RulesEditor"
		Me.Size = New System.Drawing.Size(595, 459)
		CType(Me.dgv_rules,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private btnEditInstallableItem As System.Windows.Forms.Button
	Private btnSaveRules As System.Windows.Forms.Button
	Private btnLoadRules As System.Windows.Forms.Button
	
	#End Region
	
	Private lbl_instructions As System.Windows.Forms.Label
	Private btn_group As System.Windows.Forms.Button
	Private btn_edit As System.Windows.Forms.Button
	Private btn_remove As System.Windows.Forms.Button
	Private dgv_rules As System.Windows.Forms.DataGridView
	Private dataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
	Private dataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
	Private btn_add As System.Windows.Forms.Button
	Private lbl_title As System.Windows.Forms.Label
	Private lbl_xml As System.Windows.Forms.Label
	Private tb_xml As System.Windows.Forms.TextBox
End Class
