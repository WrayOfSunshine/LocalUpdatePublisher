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
        Dim SecureString1 As System.Security.SecureString = New System.Security.SecureString()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.stbPassword = New LocalUpdatePublisher.SecureTextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpButtons = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpMain.SuspendLayout()
        Me.tlpButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblPassword
        '
        resources.ApplyResources(Me.lblPassword, "lblPassword")
        Me.lblPassword.Name = "lblPassword"
        '
        'btnOK
        '
        resources.ApplyResources(Me.btnOK, "btnOK")
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Name = "btnOK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'stbPassword
        '
        resources.ApplyResources(Me.stbPassword, "stbPassword")
        Me.stbPassword.Name = "stbPassword"
        Me.stbPassword.SecureText = SecureString1
        '
        'btnCancel
        '
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'tlpMain
        '
        resources.ApplyResources(Me.tlpMain, "tlpMain")
        Me.tlpMain.Controls.Add(Me.tlpButtons, 0, 2)
        Me.tlpMain.Controls.Add(Me.lblPassword, 0, 0)
        Me.tlpMain.Controls.Add(Me.stbPassword, 0, 1)
        Me.tlpMain.Name = "tlpMain"
        '
        'tlpButtons
        '
        resources.ApplyResources(Me.tlpButtons, "tlpButtons")
        Me.tlpButtons.Controls.Add(Me.btnOK, 0, 0)
        Me.tlpButtons.Controls.Add(Me.btnCancel, 1, 0)
        Me.tlpButtons.Name = "tlpButtons"
        '
        'PasswordForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.Controls.Add(Me.tlpMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PasswordForm"
        Me.ShowInTaskbar = False
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        Me.tlpButtons.ResumeLayout(False)
        Me.tlpButtons.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents tlpButtons As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Private WithEvents btnCancel As System.Windows.Forms.Button
    Private WithEvents stbPassword As LocalUpdatePublisher.SecureTextBox
    Private WithEvents btnOK As System.Windows.Forms.Button
    Private WithEvents lblPassword As System.Windows.Forms.Label
End Class
