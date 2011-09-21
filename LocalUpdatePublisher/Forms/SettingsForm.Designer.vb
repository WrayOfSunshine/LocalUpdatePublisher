' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 2/3/2010
' Time: 8:31 AM

Partial Class SettingsForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SettingsForm))
		Me.chkRememberTreeNode = New System.Windows.Forms.CheckBox
		Me.btnClose = New System.Windows.Forms.Button
		Me.chkReportRollup = New System.Windows.Forms.CheckBox
		Me.chkDemoteClassification = New System.Windows.Forms.CheckBox
		Me.chkHideOfficialUpdates = New System.Windows.Forms.CheckBox
		Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
		Me.tableLayoutPanel1.SuspendLayout
		Me.SuspendLayout
		'
		'chkRememberTreeNode
		'
		resources.ApplyResources(Me.chkRememberTreeNode, "chkRememberTreeNode")
		Me.chkRememberTreeNode.Name = "chkRememberTreeNode"
		Me.chkRememberTreeNode.UseVisualStyleBackColor = true
		AddHandler Me.chkRememberTreeNode.CheckedChanged, AddressOf Me.ChkRememberTreeNodeCheckedChanged
		'
		'btnClose
		'
		resources.ApplyResources(Me.btnClose, "btnClose")
		Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnClose.Name = "btnClose"
		Me.btnClose.UseVisualStyleBackColor = true
		'
		'chkReportRollup
		'
		resources.ApplyResources(Me.chkReportRollup, "chkReportRollup")
		Me.chkReportRollup.Name = "chkReportRollup"
		Me.chkReportRollup.UseVisualStyleBackColor = true
		AddHandler Me.chkReportRollup.CheckedChanged, AddressOf Me.ChkReportRollupCheckedChanged
		'
		'chkDemoteClassification
		'
		resources.ApplyResources(Me.chkDemoteClassification, "chkDemoteClassification")
		Me.chkDemoteClassification.Name = "chkDemoteClassification"
		Me.chkDemoteClassification.UseVisualStyleBackColor = true
		AddHandler Me.chkDemoteClassification.CheckedChanged, AddressOf Me.ChkDemoteClassificationCheckedChanged
		'
		'chkHideOfficialUpdates
		'
		resources.ApplyResources(Me.chkHideOfficialUpdates, "chkHideOfficialUpdates")
		Me.chkHideOfficialUpdates.Name = "chkHideOfficialUpdates"
		Me.chkHideOfficialUpdates.UseVisualStyleBackColor = true
		AddHandler Me.chkHideOfficialUpdates.CheckedChanged, AddressOf Me.ChkHideOfficialUpdatesCheckedChanged
		'
		'tableLayoutPanel1
		'
		resources.ApplyResources(Me.tableLayoutPanel1, "tableLayoutPanel1")
		Me.tableLayoutPanel1.Controls.Add(Me.chkRememberTreeNode, 0, 0)
		Me.tableLayoutPanel1.Controls.Add(Me.chkHideOfficialUpdates, 0, 3)
		Me.tableLayoutPanel1.Controls.Add(Me.chkReportRollup, 0, 1)
		Me.tableLayoutPanel1.Controls.Add(Me.chkDemoteClassification, 0, 2)
		Me.tableLayoutPanel1.Controls.Add(Me.btnClose, 0, 5)
		Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
		'
		'SettingsForm
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.btnClose
		Me.Controls.Add(Me.tableLayoutPanel1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "SettingsForm"
		Me.ShowInTaskbar = false
		AddHandler Load, AddressOf Me.SettingsLoad
		Me.tableLayoutPanel1.ResumeLayout(false)
		Me.tableLayoutPanel1.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Private chkHideOfficialUpdates As System.Windows.Forms.CheckBox
	Private chkDemoteClassification As System.Windows.Forms.CheckBox
	Private chkReportRollup As System.Windows.Forms.CheckBox
	Private btnClose As System.Windows.Forms.Button
	Private chkRememberTreeNode As System.Windows.Forms.CheckBox
End Class
