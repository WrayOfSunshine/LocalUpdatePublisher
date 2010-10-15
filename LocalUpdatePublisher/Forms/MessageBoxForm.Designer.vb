' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 11/24/2009
' Time: 2:14 PM

Partial Class MessageBoxForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MessageBoxForm))
		Me.lblText = New System.Windows.Forms.Label
		Me.btnOne = New System.Windows.Forms.Button
		Me.btnTwo = New System.Windows.Forms.Button
		Me.btnThree = New System.Windows.Forms.Button
		Me.SuspendLayout
		'
		'lblText
		'
		Me.lblText.Location = New System.Drawing.Point(12, 9)
		Me.lblText.Name = "lblText"
		Me.lblText.Size = New System.Drawing.Size(442, 45)
		Me.lblText.TabIndex = 0
		Me.lblText.Text = "label1"
		'
		'btnOne
		'
		Me.btnOne.DialogResult = System.Windows.Forms.DialogResult.Yes
		Me.btnOne.Location = New System.Drawing.Point(217, 57)
		Me.btnOne.Name = "btnOne"
		Me.btnOne.Size = New System.Drawing.Size(75, 23)
		Me.btnOne.TabIndex = 1
		Me.btnOne.UseVisualStyleBackColor = true
		AddHandler Me.btnOne.Click, AddressOf Me.BtnOneClick
		'
		'btnTwo
		'
		Me.btnTwo.DialogResult = System.Windows.Forms.DialogResult.No
		Me.btnTwo.Location = New System.Drawing.Point(298, 57)
		Me.btnTwo.Name = "btnTwo"
		Me.btnTwo.Size = New System.Drawing.Size(75, 23)
		Me.btnTwo.TabIndex = 2
		Me.btnTwo.UseVisualStyleBackColor = true
		AddHandler Me.btnTwo.Click, AddressOf Me.BtnTwoClick
		'
		'btnThree
		'
		Me.btnThree.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnThree.Location = New System.Drawing.Point(379, 57)
		Me.btnThree.Name = "btnThree"
		Me.btnThree.Size = New System.Drawing.Size(75, 23)
		Me.btnThree.TabIndex = 3
		Me.btnThree.UseVisualStyleBackColor = true
		AddHandler Me.btnThree.Click, AddressOf Me.BtnThreeClick
		'
		'MessageBoxForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.btnThree
		Me.ClientSize = New System.Drawing.Size(467, 85)
		Me.Controls.Add(Me.btnThree)
		Me.Controls.Add(Me.btnTwo)
		Me.Controls.Add(Me.btnOne)
		Me.Controls.Add(Me.lblText)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "MessageBoxForm"
		Me.ShowInTaskbar = false
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "MessageBoxForm"
		Me.ResumeLayout(false)
	End Sub
	Private btnThree As System.Windows.Forms.Button
	Private btnTwo As System.Windows.Forms.Button
	Private btnOne As System.Windows.Forms.Button
	Private lblText As System.Windows.Forms.Label
End Class
