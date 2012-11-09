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
		Me.tlpMain = New System.Windows.Forms.TableLayoutPanel
		Me.tlpButtons = New System.Windows.Forms.TableLayoutPanel
		Me.tlpMain.SuspendLayout
		Me.tlpButtons.SuspendLayout
		Me.SuspendLayout
		'
		'lblText
		'
		resources.ApplyResources(Me.lblText, "lblText")
		Me.lblText.Name = "lblText"
		AddHandler Me.lblText.TextChanged, AddressOf Me.TextChanged
		'
		'btnOne
		'
		resources.ApplyResources(Me.btnOne, "btnOne")
		Me.btnOne.DialogResult = System.Windows.Forms.DialogResult.Yes
		Me.btnOne.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnOne.Name = "btnOne"
		Me.btnOne.UseVisualStyleBackColor = true
		AddHandler Me.btnOne.Click, AddressOf Me.BtnOneClick
		'
		'btnTwo
		'
		resources.ApplyResources(Me.btnTwo, "btnTwo")
		Me.btnTwo.DialogResult = System.Windows.Forms.DialogResult.No
		Me.btnTwo.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnTwo.Name = "btnTwo"
		Me.btnTwo.UseVisualStyleBackColor = true
		AddHandler Me.btnTwo.Click, AddressOf Me.BtnTwoClick
		'
		'btnThree
		'
		resources.ApplyResources(Me.btnThree, "btnThree")
		Me.btnThree.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnThree.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnThree.Name = "btnThree"
		Me.btnThree.UseVisualStyleBackColor = true
		AddHandler Me.btnThree.Click, AddressOf Me.BtnThreeClick
		'
		'tlpMain
		'
		resources.ApplyResources(Me.tlpMain, "tlpMain")
		Me.tlpMain.Controls.Add(Me.tlpButtons, 0, 1)
		Me.tlpMain.Controls.Add(Me.lblText, 0, 0)
		Me.tlpMain.Name = "tlpMain"
		'
		'tlpButtons
		'
		resources.ApplyResources(Me.tlpButtons, "tlpButtons")
		Me.tlpButtons.Controls.Add(Me.btnOne, 0, 0)
		Me.tlpButtons.Controls.Add(Me.btnThree, 2, 0)
		Me.tlpButtons.Controls.Add(Me.btnTwo, 1, 0)
		Me.tlpButtons.Name = "tlpButtons"
		'
		'MessageBoxForm
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.btnThree
		Me.Controls.Add(Me.tlpMain)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "MessageBoxForm"
		Me.ShowInTaskbar = false
		Me.tlpMain.ResumeLayout(false)
		Me.tlpMain.PerformLayout
		Me.tlpButtons.ResumeLayout(false)
		Me.tlpButtons.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
    Private WithEvents tlpButtons As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Private WithEvents btnThree As System.Windows.Forms.Button
    Private WithEvents btnTwo As System.Windows.Forms.Button
    Private WithEvents btnOne As System.Windows.Forms.Button
    Private WithEvents lblText As System.Windows.Forms.Label
End Class
