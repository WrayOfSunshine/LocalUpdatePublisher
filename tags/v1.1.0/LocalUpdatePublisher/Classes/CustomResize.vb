'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 9/20/2011
' Time: 9:20 AM
'
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Friend NotInheritable Class CustomResize
	Private Sub New()
	End Sub
	
	Public Shared Sub ResizeVertically(sender As Object, e As EventArgs)
	Dim sz As Size
	Dim borders As Integer
	Dim h as Integer
	Dim flags as TextFormatFlags = TextFormatFlags.WordBreak
	Dim padding As Integer = 3
	
	'Make sure the sending object is a TextBox or Label
	If TypeOf(sender) Is TextBox Then
		Dim tmpTextBox As TextBox = DirectCast(sender, TextBox)
		sz = New Size(tmpTextBox.ClientSize.Width, Integer.MaxValue)
		borders = tmpTextBox.Height - tmpTextBox.ClientSize.Height
		sz = TextRenderer.MeasureText(tmpTextBox.Text, tmpTextBox.Font, sz, flags)
		h = sz.Height + borders + padding
		'if (tmpTextBox.Top + h > tmpTextBox.ClientSize.Height - 10)
		'	h = tmpTextBox.ClientSize.Height - 10 - tmpTextBox.Top
		'End If
		tmpTextBox.Height = h
	Else If TypeOf(sender) Is Label Then
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
