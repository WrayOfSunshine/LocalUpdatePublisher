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
		Me.SuspendLayout
		'
		'chkRememberTreeNode
		'
		Me.chkRememberTreeNode.Location = New System.Drawing.Point(12, 14)
		Me.chkRememberTreeNode.Name = "chkRememberTreeNode"
		Me.chkRememberTreeNode.Size = New System.Drawing.Size(249, 24)
		Me.chkRememberTreeNode.TabIndex = 0
		Me.chkRememberTreeNode.Text = "Remember last selection."
		Me.chkRememberTreeNode.UseVisualStyleBackColor = true
		AddHandler Me.chkRememberTreeNode.CheckedChanged, AddressOf Me.ChkRememberTreeNodeCheckedChanged
		'
		'btnClose
		'
		Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnClose.Location = New System.Drawing.Point(12, 64)
		Me.btnClose.Name = "btnClose"
		Me.btnClose.Size = New System.Drawing.Size(106, 27)
		Me.btnClose.TabIndex = 16
		Me.btnClose.Text = "Close"
		Me.btnClose.UseVisualStyleBackColor = true
		'
		'chkReportRollup
		'
		Me.chkReportRollup.Location = New System.Drawing.Point(12, 37)
		Me.chkReportRollup.Name = "chkReportRollup"
		Me.chkReportRollup.Size = New System.Drawing.Size(249, 24)
		Me.chkReportRollup.TabIndex = 17
		Me.chkReportRollup.Text = "Rollup dowstream clients."
		Me.chkReportRollup.UseVisualStyleBackColor = true
		AddHandler Me.chkReportRollup.CheckedChanged, AddressOf Me.ChkReportRollupCheckedChanged
		'
		'SettingsForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(258, 100)
		Me.Controls.Add(Me.chkReportRollup)
		Me.Controls.Add(Me.btnClose)
		Me.Controls.Add(Me.chkRememberTreeNode)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.Name = "SettingsForm"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "Settings"
		AddHandler Load, AddressOf Me.SettingsLoad
		Me.ResumeLayout(false)
	End Sub
	Private chkReportRollup As System.Windows.Forms.CheckBox
	Private btnClose As System.Windows.Forms.Button
	Private chkRememberTreeNode As System.Windows.Forms.CheckBox
End Class
