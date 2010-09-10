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
		Dim secureString1 As System.Security.SecureString = New System.Security.SecureString
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PasswordForm))
		Me.lblPassword = New System.Windows.Forms.Label
		Me.btnOK = New System.Windows.Forms.Button
		Me.stbPassword = New LocalUpdatePublisher.SecureTextBox
		Me.SuspendLayout
		'
		'lblPassword
		'
		Me.lblPassword.Location = New System.Drawing.Point(12, 9)
		Me.lblPassword.Name = "lblPassword"
		Me.lblPassword.Size = New System.Drawing.Size(229, 15)
		Me.lblPassword.TabIndex = 0
		Me.lblPassword.Text = "If this certificate has a password, enter it here"
		'
		'btnOK
		'
		Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnOK.Location = New System.Drawing.Point(276, 29)
		Me.btnOK.Name = "btnOK"
		Me.btnOK.Size = New System.Drawing.Size(48, 19)
		Me.btnOK.TabIndex = 2
		Me.btnOK.Text = "OK"
		Me.btnOK.UseVisualStyleBackColor = true
		AddHandler Me.btnOK.Click, AddressOf Me.BtnOKClick
		'
		'stbPassword
		'
		Me.stbPassword.Location = New System.Drawing.Point(12, 30)
		Me.stbPassword.Name = "stbPassword"
		Me.stbPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
		Me.stbPassword.SecureText = secureString1
		Me.stbPassword.Size = New System.Drawing.Size(229, 20)
		Me.stbPassword.TabIndex = 3
		'
		'PasswordForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(333, 62)
		Me.Controls.Add(Me.stbPassword)
		Me.Controls.Add(Me.btnOK)
		Me.Controls.Add(Me.lblPassword)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.Name = "PasswordForm"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "Enter Certificate Password"
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private stbPassword As LocalUpdatePublisher.SecureTextBox
	Private btnOK As System.Windows.Forms.Button
	Private lblPassword As System.Windows.Forms.Label
End Class
