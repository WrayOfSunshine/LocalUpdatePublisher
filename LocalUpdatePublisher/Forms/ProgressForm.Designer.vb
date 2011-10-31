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
		Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
		Me.tableLayoutPanel1.SuspendLayout
		Me.SuspendLayout
		'
		'progressBar
		'
		resources.ApplyResources(Me.progressBar, "progressBar")
		Me.progressBar.Name = "progressBar"
		'
		'lblText
		'
		resources.ApplyResources(Me.lblText, "lblText")
		Me.lblText.Name = "lblText"
		AddHandler Me.lblText.TextChanged, AddressOf Me.TextChanged
		'
		'lblCurrentStep
		'
		resources.ApplyResources(Me.lblCurrentStep, "lblCurrentStep")
		Me.lblCurrentStep.Name = "lblCurrentStep"
		'
		'tableLayoutPanel1
		'
		resources.ApplyResources(Me.tableLayoutPanel1, "tableLayoutPanel1")
		Me.tableLayoutPanel1.Controls.Add(Me.lblText, 0, 0)
		Me.tableLayoutPanel1.Controls.Add(Me.lblCurrentStep, 0, 2)
		Me.tableLayoutPanel1.Controls.Add(Me.progressBar, 0, 1)
		Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
		'
		'ProgressForm
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.tableLayoutPanel1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "ProgressForm"
		Me.ShowInTaskbar = false
		Me.tableLayoutPanel1.ResumeLayout(false)
		Me.tableLayoutPanel1.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Private lblCurrentStep As System.Windows.Forms.Label
	Private lblText As System.Windows.Forms.Label
	Public progressBar As System.Windows.Forms.ProgressBar
End Class
