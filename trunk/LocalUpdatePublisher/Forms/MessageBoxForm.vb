Option Explicit On
Option Strict On
' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' MessageBoxForm
' This form can serve many purposes and is design for reuse.
' In situations where the default message box just won't do
' this form does what we need it to.
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 11/24/2009
' Time: 2:14 PM

Partial Public Class MessageBoxForm

    Private m_result As Integer

    Public Sub New()
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        Me.InitializeComponent()

    End Sub

    ''' <summary>
    ''' Call ShowDialog with one button.
    ''' </summary>
    ''' <param name="mainText"></param>
    ''' <param name="buttonOne"></param>
    ''' <returns>Integer indicating result.</returns>
    Public Overloads Function ShowDialog(mainText As String, buttonOne As String) As Integer
        Return ShowDialog(mainText, buttonOne, Nothing, Nothing)
    End Function


    ''' <summary>
    ''' Call ShowDialog with two button.
    ''' </summary>
    ''' <param name="mainText"></param>
    ''' <param name="buttonOne"></param>
    ''' <returns>Integer indicating result.</returns>
    Public Overloads Function ShowDialog(mainText As String, buttonOne As String, buttonTwo As String) As Integer
        Return ShowDialog(mainText, buttonOne, buttonTwo, Nothing)
    End Function


    ''' <summary>
    ''' Call ShowDialog with three buttons.
    ''' </summary>
    ''' <param name="mainText"></param>
    ''' <param name="buttonOne"></param>
    ''' <returns>Integer indicating result.</returns>
    Public Overloads Function ShowDialog(mainText As String, buttonOne As String, _
        buttonTwo As String, buttonThree As String) As Integer
        Me.btnOne.Text = buttonOne
        If buttonTwo = Nothing Then
            Me.btnTwo.Hide()
        Else
            Me.btnTwo.Show()
            Me.btnTwo.Text = buttonTwo
        End If
        If buttonThree = Nothing Then
            Me.btnThree.Hide()
        Else
            Me.btnThree.Show()
            Me.btnThree.Text = buttonThree
        End If

        Me.lblText.Text = mainText

        MyBase.ShowDialog()
        Return m_result
    End Function
    ''' <summary>
    ''' Set result to first button.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnOneClick(sender As Object, e As EventArgs)
        m_result = 1
    End Sub
    ''' <summary>
    ''' Set result to second button.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnTwoClick(sender As Object, e As EventArgs)
        m_result = 2
    End Sub
    ''' <summary>
    ''' Set result to third button.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnThreeClick(sender As Object, e As EventArgs)
        m_result = 3
    End Sub
    ''' <summary>
    ''' Custom resize the form so that is expands vertically rather than horizontally.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Shadows Sub TextChanged(sender As Object, e As EventArgs)
        Globals.ResizeVertically(sender)
    End Sub
End Class
