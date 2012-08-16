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
		Me.tlpMain = New System.Windows.Forms.TableLayoutPanel
		Me.tlpCulture = New System.Windows.Forms.TableLayoutPanel
		Me.lblTimeOut = New System.Windows.Forms.Label
		Me.lblCulture = New System.Windows.Forms.Label
		Me.cboCulture = New System.Windows.Forms.ComboBox
		Me.txtTimeOut = New System.Windows.Forms.TextBox
		Me.tlpMain.SuspendLayout
		Me.tlpCulture.SuspendLayout
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
		Me.btnClose.MinimumSize = New System.Drawing.Size(80, 25)
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
		'tlpMain
		'
		resources.ApplyResources(Me.tlpMain, "tlpMain")
		Me.tlpMain.Controls.Add(Me.tlpCulture, 0, 4)
		Me.tlpMain.Controls.Add(Me.chkRememberTreeNode, 0, 0)
		Me.tlpMain.Controls.Add(Me.chkHideOfficialUpdates, 0, 3)
		Me.tlpMain.Controls.Add(Me.chkReportRollup, 0, 1)
		Me.tlpMain.Controls.Add(Me.chkDemoteClassification, 0, 2)
		Me.tlpMain.Controls.Add(Me.btnClose, 0, 5)
		Me.tlpMain.Name = "tlpMain"
		'
		'tlpCulture
		'
		resources.ApplyResources(Me.tlpCulture, "tlpCulture")
		Me.tlpCulture.Controls.Add(Me.lblTimeOut, 0, 0)
		Me.tlpCulture.Controls.Add(Me.lblCulture, 0, 1)
		Me.tlpCulture.Controls.Add(Me.cboCulture, 1, 1)
		Me.tlpCulture.Controls.Add(Me.txtTimeOut, 1, 0)
		Me.tlpCulture.Name = "tlpCulture"
		'
		'lblTimeOut
		'
		resources.ApplyResources(Me.lblTimeOut, "lblTimeOut")
		Me.lblTimeOut.Name = "lblTimeOut"
		'
		'lblCulture
		'
		resources.ApplyResources(Me.lblCulture, "lblCulture")
		Me.lblCulture.Name = "lblCulture"
		'
		'cboCulture
		'
		resources.ApplyResources(Me.cboCulture, "cboCulture")
		Me.cboCulture.FormattingEnabled = true
		Me.cboCulture.Name = "cboCulture"
		AddHandler Me.cboCulture.SelectionChangeCommitted, AddressOf Me.CboCultureSelectionChangeCommitted
		AddHandler Me.cboCulture.SelectedIndexChanged, AddressOf Me.CboCultureSelectedIndexChanged
		'
		'txtTimeOut
		'
		resources.ApplyResources(Me.txtTimeOut, "txtTimeOut")
		Me.txtTimeOut.MaximumSize = New System.Drawing.Size(50, 100)
		Me.txtTimeOut.Name = "txtTimeOut"
		AddHandler Me.txtTimeOut.TextChanged, AddressOf Me.TxtTimeOutTextChanged
		'
		'SettingsForm
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.btnClose
		Me.Controls.Add(Me.tlpMain)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "SettingsForm"
		Me.ShowInTaskbar = false
		AddHandler Load, AddressOf Me.SettingsLoad
		Me.tlpMain.ResumeLayout(false)
		Me.tlpMain.PerformLayout
		Me.tlpCulture.ResumeLayout(false)
		Me.tlpCulture.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private txtTimeOut As System.Windows.Forms.TextBox
	Private lblTimeOut As System.Windows.Forms.Label
	Private tlpMain As System.Windows.Forms.TableLayoutPanel
	Private cboCulture As System.Windows.Forms.ComboBox
	Private lblCulture As System.Windows.Forms.Label
	Private tlpCulture As System.Windows.Forms.TableLayoutPanel
	Private chkHideOfficialUpdates As System.Windows.Forms.CheckBox
	Private chkDemoteClassification As System.Windows.Forms.CheckBox
	Private chkReportRollup As System.Windows.Forms.CheckBox
	Private btnClose As System.Windows.Forms.Button
	Private chkRememberTreeNode As System.Windows.Forms.CheckBox
End Class
