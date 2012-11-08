Option Explicit On
Option Strict On
' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' PasswordForm
' This is a simple form that utilizes the
' secure text box to receive a password from the user.
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 11/2/2009
' Time: 1:46 PM

Imports System.Security

Public Partial Class PasswordForm
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
	End Sub
	
	Private Sub BtnOKClick(sender As Object, e As EventArgs)
		Me.Close
	End Sub
	
	ReadOnly Property Password() As SecureString
		Get
			Return stbPassword.SecureText
		End Get
	End Property
End Class
