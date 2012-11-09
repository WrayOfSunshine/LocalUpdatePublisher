Option Explicit On
Option Strict On
' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 9/20/2011
' Time: 9:20 AM
Imports Microsoft.UpdateServices.Administration
Imports System.Resources

Friend NotInheritable Class Globals
    Public Shared appSettings As Settings
    Public Shared localUpdatesScope As UpdateScope
    Public Shared defaultPaddingSize As Integer = 10
    Public Shared globalRM As ResourceManager
    'Public Shared globalTP As ThreadPool

    Private Sub New()
    End Sub

    Public Shared Sub ResizeVertically(sender As Object)
        Dim sz As Size
        Dim borders As Integer
        Dim h As Integer
        Dim flags As TextFormatFlags = TextFormatFlags.WordBreak
        Dim padding As Integer = 3

        'Make sure the sending object is a TextBox or Label
        If TypeOf (sender) Is TextBox Then
            Dim tmpTextBox As TextBox = DirectCast(sender, TextBox)
            sz = New Size(tmpTextBox.ClientSize.Width, Integer.MaxValue)
            borders = tmpTextBox.Height - tmpTextBox.ClientSize.Height
            sz = TextRenderer.MeasureText(tmpTextBox.Text, tmpTextBox.Font, sz, flags)
            h = sz.Height + borders + padding
            'if (tmpTextBox.Top + h > tmpTextBox.ClientSize.Height - 10)
            '	h = tmpTextBox.ClientSize.Height - 10 - tmpTextBox.Top
            'End If
            tmpTextBox.Height = h
        ElseIf TypeOf (sender) Is Label Then
            Dim tmpLabel As Label = DirectCast(sender, Label)
            sz = New Size(tmpLabel.ClientSize.Width, Integer.MaxValue)
            borders = tmpLabel.Height - tmpLabel.ClientSize.Height
            sz = TextRenderer.MeasureText(tmpLabel.Text, tmpLabel.Font, sz, flags)
            h = sz.Height + borders + padding
            'if (tmpLabel.Top + h > tmpLabel.ClientSize.Height - 10)
            '	h = tmpLabel.ClientSize.Height - 10 - tmpLabel.Top
            'End If
            tmpLabel.Height = h
        Else
            Exit Sub
        End If
    End Sub
End Class
