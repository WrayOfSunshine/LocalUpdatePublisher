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
		Me.SuspendLayout
		'
		'chkRememberTreeNode
		'
		Me.chkRememberTreeNode.AccessibleDescription = Nothing
		Me.chkRememberTreeNode.AccessibleName = Nothing
		resources.ApplyResources(Me.chkRememberTreeNode, "chkRememberTreeNode")
		Me.chkRememberTreeNode.BackgroundImage = Nothing
		Me.chkRememberTreeNode.Font = Nothing
		Me.chkRememberTreeNode.Name = "chkRememberTreeNode"
		Me.chkRememberTreeNode.UseVisualStyleBackColor = true
		AddHandler Me.chkRememberTreeNode.CheckedChanged, AddressOf Me.ChkRememberTreeNodeCheckedChanged
		'
		'btnClose
		'
		Me.btnClose.AccessibleDescription = Nothing
		Me.btnClose.AccessibleName = Nothing
		resources.ApplyResources(Me.btnClose, "btnClose")
		Me.btnClose.BackgroundImage = Nothing
		Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnClose.Font = Nothing
		Me.btnClose.Name = "btnClose"
		Me.btnClose.UseVisualStyleBackColor = true
		'
		'chkReportRollup
		'
		Me.chkReportRollup.AccessibleDescription = Nothing
		Me.chkReportRollup.AccessibleName = Nothing
		resources.ApplyResources(Me.chkReportRollup, "chkReportRollup")
		Me.chkReportRollup.BackgroundImage = Nothing
		Me.chkReportRollup.Font = Nothing
		Me.chkReportRollup.Name = "chkReportRollup"
		Me.chkReportRollup.UseVisualStyleBackColor = true
		AddHandler Me.chkReportRollup.CheckedChanged, AddressOf Me.ChkReportRollupCheckedChanged
		'
		'chkDemoteClassification
		'
		Me.chkDemoteClassification.AccessibleDescription = Nothing
		Me.chkDemoteClassification.AccessibleName = Nothing
		resources.ApplyResources(Me.chkDemoteClassification, "chkDemoteClassification")
		Me.chkDemoteClassification.BackgroundImage = Nothing
		Me.chkDemoteClassification.Font = Nothing
		Me.chkDemoteClassification.Name = "chkDemoteClassification"
		Me.chkDemoteClassification.UseVisualStyleBackColor = true
		AddHandler Me.chkDemoteClassification.CheckedChanged, AddressOf Me.ChkDemoteClassificationCheckedChanged
		'
		'chkHideOfficialUpdates
		'
		Me.chkHideOfficialUpdates.AccessibleDescription = Nothing
		Me.chkHideOfficialUpdates.AccessibleName = Nothing
		resources.ApplyResources(Me.chkHideOfficialUpdates, "chkHideOfficialUpdates")
		Me.chkHideOfficialUpdates.BackgroundImage = Nothing
		Me.chkHideOfficialUpdates.Font = Nothing
		Me.chkHideOfficialUpdates.Name = "chkHideOfficialUpdates"
		Me.chkHideOfficialUpdates.UseVisualStyleBackColor = true
		AddHandler Me.chkHideOfficialUpdates.CheckedChanged, AddressOf Me.ChkHideOfficialUpdatesCheckedChanged
		'
		'SettingsForm
		'
		Me.AccessibleDescription = Nothing
		Me.AccessibleName = Nothing
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackgroundImage = Nothing
		Me.CancelButton = Me.btnClose
		Me.Controls.Add(Me.chkHideOfficialUpdates)
		Me.Controls.Add(Me.chkDemoteClassification)
		Me.Controls.Add(Me.chkReportRollup)
		Me.Controls.Add(Me.btnClose)
		Me.Controls.Add(Me.chkRememberTreeNode)
		Me.Font = Nothing
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "SettingsForm"
		Me.ShowInTaskbar = false
		AddHandler Load, AddressOf Me.SettingsLoad
		Me.ResumeLayout(false)
	End Sub
	Private chkHideOfficialUpdates As System.Windows.Forms.CheckBox
	Private chkDemoteClassification As System.Windows.Forms.CheckBox
	Private chkReportRollup As System.Windows.Forms.CheckBox
	Private btnClose As System.Windows.Forms.Button
	Private chkRememberTreeNode As System.Windows.Forms.CheckBox
End Class
