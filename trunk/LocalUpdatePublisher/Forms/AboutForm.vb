Option Explicit On
Option Strict On
' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' AboutForm
' A simple form to show some basic info about the project.
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 10/22/2009
' Time: 3:11 PM

Partial Public Class AboutForm
    Public Sub New()
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        Me.InitializeComponent()

        Me.lblAbout.Text = String.Format(lblAbout.Text, Application.ProductVersion)
    End Sub

    'Go to the home page and close the form.
    Sub LinkLabelLinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        System.Diagnostics.Process.Start("http://www.localupdatepublisher.com")
        Me.Close()
    End Sub

    Sub AboutFormKeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub


    Shadows Sub TextChanged(sender As Object, e As EventArgs)
        Globals.ResizeVertically(sender)
    End Sub
End Class
