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
		Me.lblInstructions = New System.Windows.Forms.Label
		Me.btnGroup = New System.Windows.Forms.Button
		Me.btnEdit = New System.Windows.Forms.Button
		Me.btnRemove = New System.Windows.Forms.Button
		Me.dgvRules = New System.Windows.Forms.DataGridView
		Me.Rule = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.XML = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.btnAdd = New System.Windows.Forms.Button
		Me.lblTitle = New System.Windows.Forms.Label
		Me.txtXml = New System.Windows.Forms.TextBox
		Me.btnSaveRules = New System.Windows.Forms.Button
		Me.btnLoadRules = New System.Windows.Forms.Button
		Me.btnEditInstallableItem = New System.Windows.Forms.Button
		Me.tlpMain = New System.Windows.Forms.TableLayoutPanel
		Me.lblXml = New System.Windows.Forms.Label
		Me.tlpMain.SuspendLayout
		Me.SuspendLayout
		'
		'lblInstructions
		'
		resources.ApplyResources(Me.lblInstructions, "lblInstructions")
		Me.lblInstructions.CausesValidation = false
		Me.tlpMain.SetColumnSpan(Me.lblInstructions, 5)
		Me.lblInstructions.Name = "lblInstructions"
		AddHandler Me.lblInstructions.TextChanged, AddressOf Me.TextChanged
		'
		'btnGroup
		'
		resources.ApplyResources(Me.btnGroup, "btnGroup")
		Me.btnGroup.CausesValidation = false
		Me.btnGroup.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnGroup.Name = "btnGroup"
		Me.btnGroup.UseVisualStyleBackColor = true
		AddHandler Me.btnGroup.Click, AddressOf Me.btnGroup_Click
		'
		'btnEdit
		'
		resources.ApplyResources(Me.btnEdit, "btnEdit")
		Me.btnEdit.CausesValidation = false
		Me.btnEdit.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnEdit.Name = "btnEdit"
		Me.btnEdit.UseVisualStyleBackColor = true
		AddHandler Me.btnEdit.Click, AddressOf Me.btnEdit_Click
		'
		'btnRemove
		'
		resources.ApplyResources(Me.btnRemove, "btnRemove")
		Me.btnRemove.CausesValidation = false
		Me.btnRemove.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnRemove.Name = "btnRemove"
		Me.btnRemove.UseVisualStyleBackColor = true
		AddHandler Me.btnRemove.Click, AddressOf Me.btnRemove_Click
		'
		'dgvRules
		'
		Me.dgvRules.AllowUserToAddRows = false
		Me.dgvRules.AllowUserToDeleteRows = false
		Me.dgvRules.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
		Me.dgvRules.CausesValidation = false
		Me.dgvRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvRules.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Rule, Me.XML})
		Me.tlpMain.SetColumnSpan(Me.dgvRules, 5)
		dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
		dataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
		dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
		dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvRules.DefaultCellStyle = dataGridViewCellStyle1
		resources.ApplyResources(Me.dgvRules, "dgvRules")
		Me.dgvRules.Name = "dgvRules"
		Me.dgvRules.ReadOnly = true
		Me.dgvRules.RowHeadersVisible = false
		Me.dgvRules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		AddHandler Me.dgvRules.RowsAdded, AddressOf Me.DgvRulesRowsAddRemoved
		AddHandler Me.dgvRules.CellMouseDoubleClick, AddressOf Me.DgvRulesCellMouseDoubleClick
		AddHandler Me.dgvRules.RowsRemoved, AddressOf Me.DgvRulesRowsAddRemoved
		AddHandler Me.dgvRules.SelectionChanged, AddressOf Me.dgvRules_SelectionChanged
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
		'btnAdd
		'
		resources.ApplyResources(Me.btnAdd, "btnAdd")
		Me.btnAdd.CausesValidation = false
		Me.btnAdd.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnAdd.Name = "btnAdd"
		Me.btnAdd.UseVisualStyleBackColor = true
		AddHandler Me.btnAdd.Click, AddressOf Me.btnAdd_Click
		'
		'lblTitle
		'
		resources.ApplyResources(Me.lblTitle, "lblTitle")
		Me.lblTitle.CausesValidation = false
		Me.tlpMain.SetColumnSpan(Me.lblTitle, 3)
		Me.lblTitle.Name = "lblTitle"
		'
		'txtXml
		'
		Me.txtXml.CausesValidation = false
		Me.tlpMain.SetColumnSpan(Me.txtXml, 5)
		resources.ApplyResources(Me.txtXml, "txtXml")
		Me.txtXml.Name = "txtXml"
		Me.txtXml.ReadOnly = true
		'
		'btnSaveRules
		'
		resources.ApplyResources(Me.btnSaveRules, "btnSaveRules")
		Me.btnSaveRules.CausesValidation = false
		Me.btnSaveRules.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnSaveRules.Name = "btnSaveRules"
		Me.btnSaveRules.UseVisualStyleBackColor = true
		AddHandler Me.btnSaveRules.Click, AddressOf Me.BtnSaveRulesClick
		'
		'btnLoadRules
		'
		resources.ApplyResources(Me.btnLoadRules, "btnLoadRules")
		Me.btnLoadRules.CausesValidation = false
		Me.btnLoadRules.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnLoadRules.Name = "btnLoadRules"
		Me.btnLoadRules.UseVisualStyleBackColor = true
		AddHandler Me.btnLoadRules.Click, AddressOf Me.BtnLoadRulesClick
		'
		'btnEditInstallableItem
		'
		resources.ApplyResources(Me.btnEditInstallableItem, "btnEditInstallableItem")
		Me.btnEditInstallableItem.CausesValidation = false
		Me.btnEditInstallableItem.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnEditInstallableItem.Name = "btnEditInstallableItem"
		Me.btnEditInstallableItem.UseVisualStyleBackColor = true
		AddHandler Me.btnEditInstallableItem.Click, AddressOf Me.BtnEditInstallableItemClick
		'
		'tlpMain
		'
		resources.ApplyResources(Me.tlpMain, "tlpMain")
		Me.tlpMain.Controls.Add(Me.lblXml, 0, 4)
		Me.tlpMain.Controls.Add(Me.lblInstructions, 0, 0)
		Me.tlpMain.Controls.Add(Me.btnEditInstallableItem, 4, 4)
		Me.tlpMain.Controls.Add(Me.txtXml, 0, 5)
		Me.tlpMain.Controls.Add(Me.lblTitle, 0, 1)
		Me.tlpMain.Controls.Add(Me.btnGroup, 2, 3)
		Me.tlpMain.Controls.Add(Me.btnSaveRules, 3, 1)
		Me.tlpMain.Controls.Add(Me.btnEdit, 3, 3)
		Me.tlpMain.Controls.Add(Me.btnLoadRules, 4, 1)
		Me.tlpMain.Controls.Add(Me.btnRemove, 4, 3)
		Me.tlpMain.Controls.Add(Me.dgvRules, 0, 2)
		Me.tlpMain.Controls.Add(Me.btnAdd, 0, 3)
		Me.tlpMain.Name = "tlpMain"
		'
		'lblXml
		'
		resources.ApplyResources(Me.lblXml, "lblXml")
		Me.lblXml.CausesValidation = false
		Me.tlpMain.SetColumnSpan(Me.lblXml, 4)
		Me.lblXml.Name = "lblXml"
		'
		'RulesEditor
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CausesValidation = false
		Me.Controls.Add(Me.tlpMain)
		Me.Name = "RulesEditor"
		Me.tlpMain.ResumeLayout(false)
		Me.tlpMain.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
    Private WithEvents txtXml As System.Windows.Forms.TextBox
    Private WithEvents lblXml As System.Windows.Forms.Label
    Private WithEvents btnAdd As System.Windows.Forms.Button
    Private WithEvents dgvRules As System.Windows.Forms.DataGridView
    Private WithEvents btnRemove As System.Windows.Forms.Button
    Private WithEvents btnEdit As System.Windows.Forms.Button
    Private WithEvents btnGroup As System.Windows.Forms.Button
    Private WithEvents lblTitle As System.Windows.Forms.Label
    Private WithEvents lblInstructions As System.Windows.Forms.Label
    Private WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Private WithEvents Rule As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents RuleCol As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents XML As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents btnEditInstallableItem As System.Windows.Forms.Button
    Private WithEvents btnSaveRules As System.Windows.Forms.Button
    Private WithEvents btnLoadRules As System.Windows.Forms.Button
	
	#End Region
	
	Private col_Rule As System.Windows.Forms.DataGridViewTextBoxColumn
	Private col_XML As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
