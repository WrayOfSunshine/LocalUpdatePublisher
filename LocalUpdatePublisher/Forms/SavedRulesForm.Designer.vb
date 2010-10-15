' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 2/12/2010
' Time: 12:40 PM

Partial Class SavedRulesForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SavedRulesForm))
		Me.dgvRules = New System.Windows.Forms.DataGridView
		Me.Include = New System.Windows.Forms.DataGridViewCheckBoxColumn
		Me.RuleName = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.btnCancel = New System.Windows.Forms.Button
		Me.btnAction = New System.Windows.Forms.Button
		Me.btnAction2 = New System.Windows.Forms.Button
		CType(Me.dgvRules,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'dgvRules
		'
		Me.dgvRules.AllowUserToAddRows = false
		Me.dgvRules.AllowUserToDeleteRows = false
		Me.dgvRules.AllowUserToResizeColumns = false
		Me.dgvRules.AllowUserToResizeRows = false
		Me.dgvRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvRules.ColumnHeadersVisible = false
		Me.dgvRules.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Include, Me.RuleName})
		Me.dgvRules.Location = New System.Drawing.Point(12, 12)
		Me.dgvRules.Name = "dgvRules"
		Me.dgvRules.RowHeadersVisible = false
		Me.dgvRules.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.dgvRules.Size = New System.Drawing.Size(430, 245)
		Me.dgvRules.TabIndex = 0
		'
		'Include
		'
		Me.Include.FillWeight = 5!
		Me.Include.HeaderText = ""
		Me.Include.Name = "Include"
		Me.Include.Width = 20
		'
		'RuleName
		'
		Me.RuleName.HeaderText = "RuleName"
		Me.RuleName.Name = "RuleName"
		Me.RuleName.Width = 407
		'
		'btnCancel
		'
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Location = New System.Drawing.Point(367, 263)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(75, 23)
		Me.btnCancel.TabIndex = 4
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.UseVisualStyleBackColor = true
		'
		'btnAction
		'
		Me.btnAction.Location = New System.Drawing.Point(286, 263)
		Me.btnAction.Name = "btnAction"
		Me.btnAction.Size = New System.Drawing.Size(75, 23)
		Me.btnAction.TabIndex = 3
		Me.btnAction.Text = "Action"
		Me.btnAction.UseVisualStyleBackColor = true
		AddHandler Me.btnAction.Click, AddressOf Me.BtnActionClick
		'
		'btnAction2
		'
		Me.btnAction2.Location = New System.Drawing.Point(12, 263)
		Me.btnAction2.Name = "btnAction2"
		Me.btnAction2.Size = New System.Drawing.Size(75, 23)
		Me.btnAction2.TabIndex = 5
		Me.btnAction2.Text = "Action2"
		Me.btnAction2.UseVisualStyleBackColor = true
		AddHandler Me.btnAction2.Click, AddressOf Me.BtnAction2Click
		'
		'SavedRulesForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.btnCancel
		Me.ClientSize = New System.Drawing.Size(454, 295)
		Me.Controls.Add(Me.btnAction2)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnAction)
		Me.Controls.Add(Me.dgvRules)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.MinimizeBox = false
		Me.Name = "SavedRulesForm"
		Me.ShowInTaskbar = false
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "Saved Rules Form"
		CType(Me.dgvRules,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
	End Sub
	Private btnAction2 As System.Windows.Forms.Button
	Private RuleName As System.Windows.Forms.DataGridViewTextBoxColumn
	Private btnAction As System.Windows.Forms.Button
	Private btnCancel As System.Windows.Forms.Button
	Private Include As System.Windows.Forms.DataGridViewCheckBoxColumn
	Private dgvRules As System.Windows.Forms.DataGridView
End Class
