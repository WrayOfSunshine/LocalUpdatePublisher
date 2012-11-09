' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 10/22/2009
' Time: 3:11 PM
'
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class AboutForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutForm))
		Me.lblAbout = New System.Windows.Forms.Label
		Me.linkLabel = New System.Windows.Forms.LinkLabel
		Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
		Me.tableLayoutPanel1.SuspendLayout
		Me.SuspendLayout
		'
		'lblAbout
		'
		resources.ApplyResources(Me.lblAbout, "lblAbout")
		Me.lblAbout.Name = "lblAbout"
		AddHandler Me.lblAbout.TextChanged, AddressOf Me.TextChanged
		'
		'linkLabel
		'
		resources.ApplyResources(Me.linkLabel, "linkLabel")
		Me.linkLabel.Name = "linkLabel"
		Me.linkLabel.TabStop = true
		AddHandler Me.linkLabel.LinkClicked, AddressOf Me.LinkLabelLinkClicked
		'
		'tableLayoutPanel1
		'
		resources.ApplyResources(Me.tableLayoutPanel1, "tableLayoutPanel1")
		Me.tableLayoutPanel1.Controls.Add(Me.lblAbout, 0, 0)
		Me.tableLayoutPanel1.Controls.Add(Me.linkLabel, 0, 1)
		Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
		'
		'AboutForm
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.tableLayoutPanel1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.KeyPreview = true
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "AboutForm"
		Me.ShowInTaskbar = false
		AddHandler KeyDown, AddressOf Me.AboutFormKeyDown
		Me.tableLayoutPanel1.ResumeLayout(false)
		Me.tableLayoutPanel1.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
    Private WithEvents tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents linkLabel As System.Windows.Forms.LinkLabel
    Private WithEvents lblAbout As System.Windows.Forms.Label
	
	Sub AboutFormKeyUp(sender As Object, e As KeyEventArgs)
		Msgbox ( e.KeyValue )
	End Sub
End Class
