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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RulesEditor))
		Dim dataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
		Me.lbl_instructions = New System.Windows.Forms.Label
		Me.btn_group = New System.Windows.Forms.Button
		Me.btn_edit = New System.Windows.Forms.Button
		Me.btn_remove = New System.Windows.Forms.Button
		Me.dgv_rules = New System.Windows.Forms.DataGridView
		Me.RuleColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.XML = New System.Windows.Forms.DataGridViewTextBoxColumn
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
		resources.ApplyResources(Me.lbl_instructions, "lbl_instructions")
		Me.lbl_instructions.Name = "lbl_instructions"
		'
		'btn_group
		'
		Me.btn_group.CausesValidation = false
		resources.ApplyResources(Me.btn_group, "btn_group")
		Me.btn_group.Name = "btn_group"
		Me.btn_group.UseVisualStyleBackColor = true
		AddHandler Me.btn_group.Click, AddressOf Me.btn_group_Click
		'
		'btn_edit
		'
		Me.btn_edit.CausesValidation = false
		resources.ApplyResources(Me.btn_edit, "btn_edit")
		Me.btn_edit.Name = "btn_edit"
		Me.btn_edit.UseVisualStyleBackColor = true
		AddHandler Me.btn_edit.Click, AddressOf Me.btn_edit_Click
		'
		'btn_remove
		'
		Me.btn_remove.CausesValidation = false
		resources.ApplyResources(Me.btn_remove, "btn_remove")
		Me.btn_remove.Name = "btn_remove"
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
		Me.dgv_rules.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RuleColumn, Me.XML})
		dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
		dataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
		dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
		dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgv_rules.DefaultCellStyle = dataGridViewCellStyle1
		resources.ApplyResources(Me.dgv_rules, "dgv_rules")
		Me.dgv_rules.Name = "dgv_rules"
		Me.dgv_rules.ReadOnly = true
		Me.dgv_rules.RowHeadersVisible = false
		Me.dgv_rules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		AddHandler Me.dgv_rules.RowsAdded, AddressOf Me.Dgv_rulesRowsAddRemoved
		AddHandler Me.dgv_rules.CellMouseDoubleClick, AddressOf Me.Dgv_rulesCellMouseDoubleClick
		AddHandler Me.dgv_rules.RowsRemoved, AddressOf Me.Dgv_rulesRowsAddRemoved
		AddHandler Me.dgv_rules.SelectionChanged, AddressOf Me.dgv_rules_SelectionChanged
		'
		'RuleColumn
		'
		Me.RuleColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		resources.ApplyResources(Me.RuleColumn, "Rule")
		Me.RuleColumn.Name = "Rule"
		Me.RuleColumn.ReadOnly = true
		'
		'XML
		'
		resources.ApplyResources(Me.XML, "XML")
		Me.XML.Name = "XML"
		Me.XML.ReadOnly = true
		'
		'btn_add
		'
		Me.btn_add.CausesValidation = false
		resources.ApplyResources(Me.btn_add, "btn_add")
		Me.btn_add.Name = "btn_add"
		Me.btn_add.UseVisualStyleBackColor = true
		AddHandler Me.btn_add.Click, AddressOf Me.btn_add_Click
		'
		'lbl_title
		'
		Me.lbl_title.CausesValidation = false
		resources.ApplyResources(Me.lbl_title, "lbl_title")
		Me.lbl_title.Name = "lbl_title"
		'
		'lbl_xml
		'
		Me.lbl_xml.CausesValidation = false
		resources.ApplyResources(Me.lbl_xml, "lbl_xml")
		Me.lbl_xml.Name = "lbl_xml"
		'
		'tb_xml
		'
		Me.tb_xml.CausesValidation = false
		resources.ApplyResources(Me.tb_xml, "tb_xml")
		Me.tb_xml.Name = "tb_xml"
		Me.tb_xml.ReadOnly = true
		'
		'btnSaveRules
		'
		Me.btnSaveRules.CausesValidation = false
		resources.ApplyResources(Me.btnSaveRules, "btnSaveRules")
		Me.btnSaveRules.Name = "btnSaveRules"
		Me.btnSaveRules.UseVisualStyleBackColor = true
		AddHandler Me.btnSaveRules.Click, AddressOf Me.BtnSaveRulesClick
		'
		'btnLoadRules
		'
		Me.btnLoadRules.CausesValidation = false
		resources.ApplyResources(Me.btnLoadRules, "btnLoadRules")
		Me.btnLoadRules.Name = "btnLoadRules"
		Me.btnLoadRules.UseVisualStyleBackColor = true
		AddHandler Me.btnLoadRules.Click, AddressOf Me.BtnLoadRulesClick
		'
		'btnEditInstallableItem
		'
		Me.btnEditInstallableItem.CausesValidation = false
		resources.ApplyResources(Me.btnEditInstallableItem, "btnEditInstallableItem")
		Me.btnEditInstallableItem.Name = "btnEditInstallableItem"
		Me.btnEditInstallableItem.UseVisualStyleBackColor = true
		AddHandler Me.btnEditInstallableItem.Click, AddressOf Me.BtnEditInstallableItemClick
		'
		'RulesEditor
		'
		resources.ApplyResources(Me, "$this")
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
		CType(Me.dgv_rules,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private XML As System.Windows.Forms.DataGridViewTextBoxColumn
	Private RuleColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Private btnEditInstallableItem As System.Windows.Forms.Button
	Private btnSaveRules As System.Windows.Forms.Button
	Private btnLoadRules As System.Windows.Forms.Button
	
	#End Region
	
	Private lbl_instructions As System.Windows.Forms.Label
	Private btn_group As System.Windows.Forms.Button
	Private btn_edit As System.Windows.Forms.Button
	Private btn_remove As System.Windows.Forms.Button
	Private dgv_rules As System.Windows.Forms.DataGridView
	Private col_Rule As System.Windows.Forms.DataGridViewTextBoxColumn
	Private col_XML As System.Windows.Forms.DataGridViewTextBoxColumn
	Private btn_add As System.Windows.Forms.Button
	Private lbl_title As System.Windows.Forms.Label
	Private lbl_xml As System.Windows.Forms.Label
	Private tb_xml As System.Windows.Forms.TextBox
End Class
