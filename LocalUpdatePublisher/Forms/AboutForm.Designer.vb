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
		Me.SuspendLayout
		'
		'lblAbout
		'
		Me.lblAbout.AccessibleDescription = Nothing
		Me.lblAbout.AccessibleName = Nothing
		resources.ApplyResources(Me.lblAbout, "lblAbout")
		Me.lblAbout.Font = Nothing
		Me.lblAbout.Name = "lblAbout"
		'
		'linkLabel
		'
		Me.linkLabel.AccessibleDescription = Nothing
		Me.linkLabel.AccessibleName = Nothing
		resources.ApplyResources(Me.linkLabel, "linkLabel")
		Me.linkLabel.Font = Nothing
		Me.linkLabel.Name = "linkLabel"
		Me.linkLabel.TabStop = true
		AddHandler Me.linkLabel.LinkClicked, AddressOf Me.LinkLabelLinkClicked
		'
		'AboutForm
		'
		Me.AccessibleDescription = Nothing
		Me.AccessibleName = Nothing
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackgroundImage = Nothing
		Me.Controls.Add(Me.linkLabel)
		Me.Controls.Add(Me.lblAbout)
		Me.Font = Nothing
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.KeyPreview = true
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "AboutForm"
		Me.ShowInTaskbar = false
		AddHandler KeyDown, AddressOf Me.AboutFormKeyDown
		Me.ResumeLayout(false)
	End Sub
	Private linkLabel As System.Windows.Forms.LinkLabel
	Private lblAbout As System.Windows.Forms.Label
	
	Sub AboutFormKeyUp(sender As Object, e As KeyEventArgs)
		Msgbox ( e.KeyValue )
	End Sub
End Class
