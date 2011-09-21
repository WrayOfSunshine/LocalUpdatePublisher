' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' MessageBoxForm
' This form can server many purposes and is design for reuse.
' In situations where the default message box just won't do
' this form does what we need it to.
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 11/24/2009
' Time: 2:14 PM

Public Partial Class MessageBoxForm
	
	Private _result As Integer
	
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
	End Sub
	
	'Call ShowDialog with one button.
	Public Overloads Function ShowDialog(mainText As String, buttonOne As String) As Integer
		Return ShowDialog(mainText, ButtonOne, Nothing, Nothing)
	End Function
	
	'Call ShowDialog with two buttons.
	Public Overloads Function ShowDialog(mainText As String, buttonOne As String, buttonTwo As String) As Integer
		Return ShowDialog(mainText, buttonOne, buttonTwo, Nothing)
	End Function
	
	'If a rule is not passed.
	Public Overloads Function ShowDialog(mainText As String, buttonOne As String, _
		buttonTwo as String, buttonThree as String) As Integer
		Me.btnOne.Text = buttonOne
		If buttonTwo = Nothing Then
			Me.btnTwo.Hide
		Else
			Me.btnTwo.Show
			Me.btnTwo.Text = buttonTwo
		End If
		If buttonThree = Nothing Then
			Me.btnThree.Hide
		Else
			Me.btnThree.Show
			Me.btnThree.Text = buttonThree
		End If
		
		Me.lblText.Text = mainText
		
		MyBase.ShowDialog
		Return _result
	End Function
	
	Private Sub BtnOneClick(sender As Object, e As EventArgs)
		_result = 1
	End Sub
	
	Private Sub BtnTwoClick(sender As Object, e As EventArgs)
		_result = 2
	End Sub
	
	Private Sub BtnThreeClick(sender As Object, e As EventArgs)
		_result = 3
	End Sub
	
End Class
