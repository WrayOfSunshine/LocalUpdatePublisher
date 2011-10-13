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
		Me.Rule = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.XML = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.btn_add = New System.Windows.Forms.Button
		Me.lbl_title = New System.Windows.Forms.Label
		Me.lbl_xml = New System.Windows.Forms.Label
		Me.tb_xml = New System.Windows.Forms.TextBox
		Me.btnSaveRules = New System.Windows.Forms.Button
		Me.btnLoadRules = New System.Windows.Forms.Button
		Me.btnEditInstallableItem = New System.Windows.Forms.Button
		Me.tlpMain = New System.Windows.Forms.TableLayoutPanel
		CType(Me.dgv_rules,System.ComponentModel.ISupportInitialize).BeginInit
		Me.tlpMain.SuspendLayout
		Me.SuspendLayout
		'
		'lbl_instructions
		'
		Me.lbl_instructions.AccessibleDescription = Nothing
		Me.lbl_instructions.AccessibleName = Nothing
		resources.ApplyResources(Me.lbl_instructions, "lbl_instructions")
		Me.lbl_instructions.CausesValidation = false
		Me.tlpMain.SetColumnSpan(Me.lbl_instructions, 5)
		Me.lbl_instructions.Name = "lbl_instructions"
		AddHandler Me.lbl_instructions.TextChanged, AddressOf Me.TextChanged
		'
		'btn_group
		'
		Me.btn_group.AccessibleDescription = Nothing
		Me.btn_group.AccessibleName = Nothing
		resources.ApplyResources(Me.btn_group, "btn_group")
		Me.btn_group.BackgroundImage = Nothing
		Me.btn_group.CausesValidation = false
		Me.btn_group.Font = Nothing
		Me.btn_group.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btn_group.Name = "btn_group"
		Me.btn_group.UseVisualStyleBackColor = true
		AddHandler Me.btn_group.Click, AddressOf Me.btn_group_Click
		'
		'btn_edit
		'
		Me.btn_edit.AccessibleDescription = Nothing
		Me.btn_edit.AccessibleName = Nothing
		resources.ApplyResources(Me.btn_edit, "btn_edit")
		Me.btn_edit.BackgroundImage = Nothing
		Me.btn_edit.CausesValidation = false
		Me.btn_edit.Font = Nothing
		Me.btn_edit.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btn_edit.Name = "btn_edit"
		Me.btn_edit.UseVisualStyleBackColor = true
		AddHandler Me.btn_edit.Click, AddressOf Me.btn_edit_Click
		'
		'btn_remove
		'
		Me.btn_remove.AccessibleDescription = Nothing
		Me.btn_remove.AccessibleName = Nothing
		resources.ApplyResources(Me.btn_remove, "btn_remove")
		Me.btn_remove.BackgroundImage = Nothing
		Me.btn_remove.CausesValidation = false
		Me.btn_remove.Font = Nothing
		Me.btn_remove.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btn_remove.Name = "btn_remove"
		Me.btn_remove.UseVisualStyleBackColor = true
		AddHandler Me.btn_remove.Click, AddressOf Me.btn_remove_Click
		'
		'dgv_rules
		'
		Me.dgv_rules.AccessibleDescription = Nothing
		Me.dgv_rules.AccessibleName = Nothing
		Me.dgv_rules.AllowUserToAddRows = false
		Me.dgv_rules.AllowUserToDeleteRows = false
		resources.ApplyResources(Me.dgv_rules, "dgv_rules")
		Me.dgv_rules.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
		Me.dgv_rules.BackgroundImage = Nothing
		Me.dgv_rules.CausesValidation = false
		Me.dgv_rules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgv_rules.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Rule, Me.XML})
		Me.tlpMain.SetColumnSpan(Me.dgv_rules, 5)
		dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
		dataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
		dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
		dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgv_rules.DefaultCellStyle = dataGridViewCellStyle1
		Me.dgv_rules.Font = Nothing
		Me.dgv_rules.Name = "dgv_rules"
		Me.dgv_rules.ReadOnly = true
		Me.dgv_rules.RowHeadersVisible = false
		Me.dgv_rules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		AddHandler Me.dgv_rules.RowsAdded, AddressOf Me.Dgv_rulesRowsAddRemoved
		AddHandler Me.dgv_rules.CellMouseDoubleClick, AddressOf Me.Dgv_rulesCellMouseDoubleClick
		AddHandler Me.dgv_rules.RowsRemoved, AddressOf Me.Dgv_rulesRowsAddRemoved
		AddHandler Me.dgv_rules.SelectionChanged, AddressOf Me.dgv_rules_SelectionChanged
		'
		'Rule
		'
		Me.Rule.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		resources.ApplyResources(Me.Rule, "Rule")
		Me.Rule.Name = "Rule"
		Me.Rule.ReadOnly = true
		'
		'XML
		'
		resources.ApplyResources(Me.XML, "XML")
		Me.XML.Name = "XML"
		Me.XML.ReadOnly = true
		'
		'btn_add
		'
		Me.btn_add.AccessibleDescription = Nothing
		Me.btn_add.AccessibleName = Nothing
		resources.ApplyResources(Me.btn_add, "btn_add")
		Me.btn_add.BackgroundImage = Nothing
		Me.btn_add.CausesValidation = false
		Me.btn_add.Font = Nothing
		Me.btn_add.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btn_add.Name = "btn_add"
		Me.btn_add.UseVisualStyleBackColor = true
		AddHandler Me.btn_add.Click, AddressOf Me.btn_add_Click
		'
		'lbl_title
		'
		Me.lbl_title.AccessibleDescription = Nothing
		Me.lbl_title.AccessibleName = Nothing
		resources.ApplyResources(Me.lbl_title, "lbl_title")
		Me.lbl_title.CausesValidation = false
		Me.tlpMain.SetColumnSpan(Me.lbl_title, 3)
		Me.lbl_title.Name = "lbl_title"
		'
		'lbl_xml
		'
		Me.lbl_xml.AccessibleDescription = Nothing
		Me.lbl_xml.AccessibleName = Nothing
		resources.ApplyResources(Me.lbl_xml, "lbl_xml")
		Me.lbl_xml.CausesValidation = false
		Me.lbl_xml.Name = "lbl_xml"
		'
		'tb_xml
		'
		Me.tb_xml.AccessibleDescription = Nothing
		Me.tb_xml.AccessibleName = Nothing
		resources.ApplyResources(Me.tb_xml, "tb_xml")
		Me.tb_xml.BackgroundImage = Nothing
		Me.tb_xml.CausesValidation = false
		Me.tlpMain.SetColumnSpan(Me.tb_xml, 5)
		Me.tb_xml.Font = Nothing
		Me.tb_xml.Name = "tb_xml"
		Me.tb_xml.ReadOnly = true
		'
		'btnSaveRules
		'
		Me.btnSaveRules.AccessibleDescription = Nothing
		Me.btnSaveRules.AccessibleName = Nothing
		resources.ApplyResources(Me.btnSaveRules, "btnSaveRules")
		Me.btnSaveRules.BackgroundImage = Nothing
		Me.btnSaveRules.CausesValidation = false
		Me.btnSaveRules.Font = Nothing
		Me.btnSaveRules.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnSaveRules.Name = "btnSaveRules"
		Me.btnSaveRules.UseVisualStyleBackColor = true
		AddHandler Me.btnSaveRules.Click, AddressOf Me.BtnSaveRulesClick
		'
		'btnLoadRules
		'
		Me.btnLoadRules.AccessibleDescription = Nothing
		Me.btnLoadRules.AccessibleName = Nothing
		resources.ApplyResources(Me.btnLoadRules, "btnLoadRules")
		Me.btnLoadRules.BackgroundImage = Nothing
		Me.btnLoadRules.CausesValidation = false
		Me.btnLoadRules.Font = Nothing
		Me.btnLoadRules.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnLoadRules.Name = "btnLoadRules"
		Me.btnLoadRules.UseVisualStyleBackColor = true
		AddHandler Me.btnLoadRules.Click, AddressOf Me.BtnLoadRulesClick
		'
		'btnEditInstallableItem
		'
		Me.btnEditInstallableItem.AccessibleDescription = Nothing
		Me.btnEditInstallableItem.AccessibleName = Nothing
		resources.ApplyResources(Me.btnEditInstallableItem, "btnEditInstallableItem")
		Me.btnEditInstallableItem.BackgroundImage = Nothing
		Me.btnEditInstallableItem.CausesValidation = false
		Me.btnEditInstallableItem.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnEditInstallableItem.Name = "btnEditInstallableItem"
		Me.btnEditInstallableItem.UseVisualStyleBackColor = true
		AddHandler Me.btnEditInstallableItem.Click, AddressOf Me.BtnEditInstallableItemClick
		'
		'tlpMain
		'
		Me.tlpMain.AccessibleDescription = Nothing
		Me.tlpMain.AccessibleName = Nothing
		resources.ApplyResources(Me.tlpMain, "tlpMain")
		Me.tlpMain.BackgroundImage = Nothing
		Me.tlpMain.Controls.Add(Me.lbl_instructions, 0, 0)
		Me.tlpMain.Controls.Add(Me.btnEditInstallableItem, 4, 4)
		Me.tlpMain.Controls.Add(Me.tb_xml, 0, 5)
		Me.tlpMain.Controls.Add(Me.lbl_title, 0, 1)
		Me.tlpMain.Controls.Add(Me.btn_group, 2, 3)
		Me.tlpMain.Controls.Add(Me.btnSaveRules, 3, 1)
		Me.tlpMain.Controls.Add(Me.btn_edit, 3, 3)
		Me.tlpMain.Controls.Add(Me.btnLoadRules, 4, 1)
		Me.tlpMain.Controls.Add(Me.btn_remove, 4, 3)
		Me.tlpMain.Controls.Add(Me.dgv_rules, 0, 2)
		Me.tlpMain.Controls.Add(Me.btn_add, 0, 3)
		Me.tlpMain.Font = Nothing
		Me.tlpMain.Name = "tlpMain"
		'
		'RulesEditor
		'
		Me.AccessibleDescription = Nothing
		Me.AccessibleName = Nothing
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackgroundImage = Nothing
		Me.CausesValidation = false
		Me.Controls.Add(Me.tlpMain)
		Me.Controls.Add(Me.lbl_xml)
		Me.Font = Nothing
		Me.Name = "RulesEditor"
		CType(Me.dgv_rules,System.ComponentModel.ISupportInitialize).EndInit
		Me.tlpMain.ResumeLayout(false)
		Me.tlpMain.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private tlpMain As System.Windows.Forms.TableLayoutPanel
	Private Rule As System.Windows.Forms.DataGridViewTextBoxColumn
	Private RuleCol As System.Windows.Forms.DataGridViewTextBoxColumn
	Private XML As System.Windows.Forms.DataGridViewTextBoxColumn
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
