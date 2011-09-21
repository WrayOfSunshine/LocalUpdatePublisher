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
		Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
		Me.tableLayoutPanel1.SuspendLayout
		Me.SuspendLayout
		'
		'lblText
		'
		resources.ApplyResources(Me.lblText, "lblText")
		Me.tableLayoutPanel1.SetColumnSpan(Me.lblText, 5)
		Me.lblText.Name = "lblText"
		AddHandler Me.lblText.TextChanged, AddressOf CustomResize.ResizeVertically
		'
		'btnOne
		'
		resources.ApplyResources(Me.btnOne, "btnOne")
		Me.btnOne.DialogResult = System.Windows.Forms.DialogResult.Yes
		Me.btnOne.Name = "btnOne"
		Me.btnOne.UseVisualStyleBackColor = true
		AddHandler Me.btnOne.Click, AddressOf Me.BtnOneClick
		'
		'btnTwo
		'
		resources.ApplyResources(Me.btnTwo, "btnTwo")
		Me.btnTwo.DialogResult = System.Windows.Forms.DialogResult.No
		Me.btnTwo.Name = "btnTwo"
		Me.btnTwo.UseVisualStyleBackColor = true
		AddHandler Me.btnTwo.Click, AddressOf Me.BtnTwoClick
		'
		'btnThree
		'
		resources.ApplyResources(Me.btnThree, "btnThree")
		Me.btnThree.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnThree.Name = "btnThree"
		Me.btnThree.UseVisualStyleBackColor = true
		AddHandler Me.btnThree.Click, AddressOf Me.BtnThreeClick
		'
		'tableLayoutPanel1
		'
		resources.ApplyResources(Me.tableLayoutPanel1, "tableLayoutPanel1")
		Me.tableLayoutPanel1.Controls.Add(Me.btnThree, 4, 1)
		Me.tableLayoutPanel1.Controls.Add(Me.lblText, 0, 0)
		Me.tableLayoutPanel1.Controls.Add(Me.btnOne, 2, 1)
		Me.tableLayoutPanel1.Controls.Add(Me.btnTwo, 3, 1)
		Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
		'
		'MessageBoxForm
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.btnThree
		Me.Controls.Add(Me.tableLayoutPanel1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "MessageBoxForm"
		Me.ShowInTaskbar = false
		Me.tableLayoutPanel1.ResumeLayout(false)
		Me.tableLayoutPanel1.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Private btnThree As System.Windows.Forms.Button
	Private btnTwo As System.Windows.Forms.Button
	Private btnOne As System.Windows.Forms.Button
	Private lblText As System.Windows.Forms.Label
End Class
