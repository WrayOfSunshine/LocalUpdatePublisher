' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 11/2/2009
' Time: 1:46 PM

Partial Class PasswordForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PasswordForm))
		Dim secureString1 As System.Security.SecureString = New System.Security.SecureString
		Me.lblPassword = New System.Windows.Forms.Label
		Me.btnOK = New System.Windows.Forms.Button
		Me.stbPassword = New LocalUpdatePublisher.SecureTextBox
		Me.btnCancel = New System.Windows.Forms.Button
		Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
		Me.tableLayoutPanel1.SuspendLayout
		Me.SuspendLayout
		'
		'lblPassword
		'
		resources.ApplyResources(Me.lblPassword, "lblPassword")
		Me.tableLayoutPanel1.SetColumnSpan(Me.lblPassword, 4)
		Me.lblPassword.Name = "lblPassword"
		'
		'btnOK
		'
		resources.ApplyResources(Me.btnOK, "btnOK")
		Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnOK.Name = "btnOK"
		Me.btnOK.UseVisualStyleBackColor = true
		AddHandler Me.btnOK.Click, AddressOf Me.BtnOKClick
		'
		'stbPassword
		'
		Me.tableLayoutPanel1.SetColumnSpan(Me.stbPassword, 4)
		resources.ApplyResources(Me.stbPassword, "stbPassword")
		Me.stbPassword.Name = "stbPassword"
		Me.stbPassword.SecureText = secureString1
		'
		'btnCancel
		'
		resources.ApplyResources(Me.btnCancel, "btnCancel")
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.UseVisualStyleBackColor = true
		'
		'tableLayoutPanel1
		'
		resources.ApplyResources(Me.tableLayoutPanel1, "tableLayoutPanel1")
		Me.tableLayoutPanel1.Controls.Add(Me.btnCancel, 3, 2)
		Me.tableLayoutPanel1.Controls.Add(Me.lblPassword, 0, 0)
		Me.tableLayoutPanel1.Controls.Add(Me.stbPassword, 0, 1)
		Me.tableLayoutPanel1.Controls.Add(Me.btnOK, 2, 2)
		Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
		'
		'PasswordForm
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.btnCancel
		Me.Controls.Add(Me.tableLayoutPanel1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "PasswordForm"
		Me.ShowInTaskbar = false
		Me.tableLayoutPanel1.ResumeLayout(false)
		Me.tableLayoutPanel1.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Private btnCancel As System.Windows.Forms.Button
	Private stbPassword As LocalUpdatePublisher.SecureTextBox
	Private btnOK As System.Windows.Forms.Button
	Private lblPassword As System.Windows.Forms.Label
End Class
