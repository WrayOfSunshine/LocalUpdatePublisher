Option Explicit On
Option Strict On
' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
'ProgressForm
'This is as simple form used to show the progress of
' a given task.  The Show method is overridden to take
' a string and set that to the descriptive text.  The
' progress bar is a public control so that the caller
' can have direct access to updating it.
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 1/18/2010
' Time: 9:53 AM

Public Partial Class ProgressForm
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
	End Sub
	
	'If a string is passed then set it as the descriptive text.
	Public Overloads Sub ShowDialog(value as String, parentForm As Form)
		Me.lblText.Text = value
		Me.Refresh
		Me.Owner = parentForm
		MyBase.Show()
	End Sub
	
	'If a string is passed then set it as the descriptive text.
	Public Overloads Sub Show(value as String, parentForm As Form)
		Me.lblText.Text = value
		Me.Refresh
		Me.Owner = parentForm
		MyBase.Show()
	End Sub
	
	'Change the text of the current step.
	Public Sub SetCurrentStep(value As String)
		Me.lblCurrentStep.Text = value
		Me.Refresh
	End Sub
	
	Shadows Sub TextChanged(sender As Object, e As EventArgs)
		CustomResize.ResizeVertically(sender)
	End Sub
End Class
