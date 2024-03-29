﻿'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 3/25/2010
' Time: 10:02 AM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class UpdateSelectionForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UpdateSelectionForm))
		Me.dgvUpdates = New System.Windows.Forms.DataGridView
		Me.tlpMain = New System.Windows.Forms.TableLayoutPanel
		Me.tlpButtons = New System.Windows.Forms.TableLayoutPanel
		Me.btnSelect = New System.Windows.Forms.Button
		Me.btnCancel = New System.Windows.Forms.Button
		Me.tlpHeader = New System.Windows.Forms.TableLayoutPanel
		Me.lblVendor = New System.Windows.Forms.Label
		Me.cboVendor = New System.Windows.Forms.ComboBox
		Me.tlpMain.SuspendLayout
		Me.tlpButtons.SuspendLayout
		Me.tlpHeader.SuspendLayout
		Me.SuspendLayout
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
		resources.ApplyResources(Me.dgvUpdates, "dgvUpdates")
		Me.dgvUpdates.Name = "dgvUpdates"
		Me.dgvUpdates.ReadOnly = true
		Me.dgvUpdates.RowHeadersVisible = false
		Me.dgvUpdates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		AddHandler Me.dgvUpdates.CellMouseDoubleClick, AddressOf Me.DgvUpdatesCellMouseDoubleClick
		'
		'tlpMain
		'
		resources.ApplyResources(Me.tlpMain, "tlpMain")
		Me.tlpMain.Controls.Add(Me.tlpButtons, 0, 2)
		Me.tlpMain.Controls.Add(Me.tlpHeader, 0, 0)
		Me.tlpMain.Controls.Add(Me.dgvUpdates, 0, 1)
		Me.tlpMain.Name = "tlpMain"
		'
		'tlpButtons
		'
		resources.ApplyResources(Me.tlpButtons, "tlpButtons")
		Me.tlpButtons.Controls.Add(Me.btnSelect, 0, 0)
		Me.tlpButtons.Controls.Add(Me.btnCancel, 1, 0)
		Me.tlpButtons.Name = "tlpButtons"
		'
		'btnSelect
		'
		resources.ApplyResources(Me.btnSelect, "btnSelect")
		Me.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnSelect.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnSelect.Name = "btnSelect"
		Me.btnSelect.UseVisualStyleBackColor = true
		'
		'btnCancel
		'
		resources.ApplyResources(Me.btnCancel, "btnCancel")
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.UseVisualStyleBackColor = true
		'
		'tlpHeader
		'
		resources.ApplyResources(Me.tlpHeader, "tlpHeader")
		Me.tlpHeader.Controls.Add(Me.lblVendor, 0, 0)
		Me.tlpHeader.Controls.Add(Me.cboVendor, 1, 0)
		Me.tlpHeader.Name = "tlpHeader"
		'
		'lblVendor
		'
		resources.ApplyResources(Me.lblVendor, "lblVendor")
		Me.lblVendor.Name = "lblVendor"
		'
		'cboVendor
		'
		resources.ApplyResources(Me.cboVendor, "cboVendor")
		Me.cboVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboVendor.FormattingEnabled = true
		Me.cboVendor.Name = "cboVendor"
		AddHandler Me.cboVendor.SelectedIndexChanged, AddressOf Me.CboVendorSelectedIndexChanged
		'
		'UpdateSelectionForm
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.tlpMain)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "UpdateSelectionForm"
		Me.ShowInTaskbar = false
		Me.tlpMain.ResumeLayout(false)
		Me.tlpMain.PerformLayout
		Me.tlpButtons.ResumeLayout(false)
		Me.tlpButtons.PerformLayout
		Me.tlpHeader.ResumeLayout(false)
		Me.tlpHeader.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
    Private WithEvents tlpHeader As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpButtons As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Private WithEvents lblVendor As System.Windows.Forms.Label
    Private WithEvents cboVendor As System.Windows.Forms.ComboBox
    Private WithEvents dgvUpdates As System.Windows.Forms.DataGridView
    Private WithEvents btnSelect As System.Windows.Forms.Button
    Private WithEvents btnCancel As System.Windows.Forms.Button
End Class
