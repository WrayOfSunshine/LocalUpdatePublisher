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
		Me.lblAbout.Location = New System.Drawing.Point(-4, 1)
		Me.lblAbout.Margin = New System.Windows.Forms.Padding(50)
		Me.lblAbout.Name = "lblAbout"
		Me.lblAbout.Padding = New System.Windows.Forms.Padding(5)
		Me.lblAbout.Size = New System.Drawing.Size(465, 92)
		Me.lblAbout.TabIndex = 0
		Me.lblAbout.Text = "Local Update Publisher Version: 1.0"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"Local Update Publisher uses the WSUS API t"& _ 
		"o extend your WSUS implementation to include installs and updates from third par"& _ 
		"ties."&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"For support and updates go to"
		'
		'linkLabel
		'
		Me.linkLabel.Location = New System.Drawing.Point(152, 70)
		Me.linkLabel.Name = "linkLabel"
		Me.linkLabel.Size = New System.Drawing.Size(192, 23)
		Me.linkLabel.TabIndex = 1
		Me.linkLabel.TabStop = true
		Me.linkLabel.Text = "http://www.localupdatepublisher.com"
		AddHandler Me.linkLabel.LinkClicked, AddressOf Me.LinkLabelLinkClicked
		'
		'AboutForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(464, 109)
		Me.Controls.Add(Me.linkLabel)
		Me.Controls.Add(Me.lblAbout)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.KeyPreview = true
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "AboutForm"
		Me.ShowInTaskbar = false
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "About"
		AddHandler KeyDown, AddressOf Me.AboutFormKeyDown
		Me.ResumeLayout(false)
	End Sub
	Private linkLabel As System.Windows.Forms.LinkLabel
	Private lblAbout As System.Windows.Forms.Label
	
	Sub AboutFormKeyUp(sender As Object, e As KeyEventArgs)
		Msgbox ( e.KeyValue )
	End Sub
End Class
