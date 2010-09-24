' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 1/18/2010
' Time: 9:53 AM

Partial Class ProgressForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProgressForm))
		Me.progressBar = New System.Windows.Forms.ProgressBar
		Me.lblText = New System.Windows.Forms.Label
		Me.lblCurrentStep = New System.Windows.Forms.Label
		Me.SuspendLayout
		'
		'progressBar
		'
		Me.progressBar.Location = New System.Drawing.Point(30, 60)
		Me.progressBar.Name = "progressBar"
		Me.progressBar.Size = New System.Drawing.Size(379, 23)
		Me.progressBar.TabIndex = 0
		'
		'lblText
		'
		Me.lblText.Location = New System.Drawing.Point(12, 9)
		Me.lblText.Name = "lblText"
		Me.lblText.Size = New System.Drawing.Size(409, 48)
		Me.lblText.TabIndex = 1
		Me.lblText.Text = "Place Text Here"
		'
		'lblCurrentStep
		'
		Me.lblCurrentStep.Location = New System.Drawing.Point(30, 86)
		Me.lblCurrentStep.Name = "lblCurrentStep"
		Me.lblCurrentStep.Size = New System.Drawing.Size(379, 23)
		Me.lblCurrentStep.TabIndex = 2
		Me.lblCurrentStep.Text = "Current Step"
		'
		'ProgressForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoSize = true
		Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.ClientSize = New System.Drawing.Size(433, 113)
		Me.Controls.Add(Me.lblCurrentStep)
		Me.Controls.Add(Me.lblText)
		Me.Controls.Add(Me.progressBar)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "ProgressForm"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "Progress"
		Me.ResumeLayout(false)
	End Sub
	Private lblCurrentStep As System.Windows.Forms.Label
	Private lblText As System.Windows.Forms.Label
	Public progressBar As System.Windows.Forms.ProgressBar
End Class
