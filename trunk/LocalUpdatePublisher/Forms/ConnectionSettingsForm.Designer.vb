' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 10/29/2009
' Time: 11:26 AM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class ConnectionSettingsForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConnectionSettingsForm))
		Me.chkSsl = New System.Windows.Forms.CheckBox
		Me.lblLocalServer = New System.Windows.Forms.Label
		Me.txtPort = New System.Windows.Forms.TextBox
		Me.lblPort = New System.Windows.Forms.Label
		Me.txtName = New System.Windows.Forms.TextBox
		Me.lblName = New System.Windows.Forms.Label
		Me.btnConnect = New System.Windows.Forms.Button
		Me.btnCancel = New System.Windows.Forms.Button
		Me.cboServers = New System.Windows.Forms.ComboBox
		Me.lblServers = New System.Windows.Forms.Label
		Me.btnDelete = New System.Windows.Forms.Button
		Me.tlpMain = New System.Windows.Forms.TableLayoutPanel
		Me.tlpButtons = New System.Windows.Forms.TableLayoutPanel
		Me.tlpMain.SuspendLayout
		Me.tlpButtons.SuspendLayout
		Me.SuspendLayout
		'
		'chkSsl
		'
		resources.ApplyResources(Me.chkSsl, "chkSsl")
		Me.chkSsl.Name = "chkSsl"
		Me.chkSsl.UseVisualStyleBackColor = true
		AddHandler Me.chkSsl.CheckedChanged, AddressOf Me.ChkSSLCheckedChanged
		'
		'lblLocalServer
		'
		resources.ApplyResources(Me.lblLocalServer, "lblLocalServer")
		Me.lblLocalServer.Name = "lblLocalServer"
		'
		'txtPort
		'
		resources.ApplyResources(Me.txtPort, "txtPort")
		Me.txtPort.Name = "txtPort"
		'
		'lblPort
		'
		resources.ApplyResources(Me.lblPort, "lblPort")
		Me.lblPort.Name = "lblPort"
		'
		'txtName
		'
		resources.ApplyResources(Me.txtName, "txtName")
		Me.txtName.Name = "txtName"
		'
		'lblName
		'
		resources.ApplyResources(Me.lblName, "lblName")
		Me.lblName.Name = "lblName"
		'
		'btnConnect
		'
		resources.ApplyResources(Me.btnConnect, "btnConnect")
		Me.btnConnect.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnConnect.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnConnect.Name = "btnConnect"
		Me.btnConnect.UseVisualStyleBackColor = true
		AddHandler Me.btnConnect.Click, AddressOf Me.BtnConnectClick
		'
		'btnCancel
		'
		resources.ApplyResources(Me.btnCancel, "btnCancel")
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.UseVisualStyleBackColor = true
		'
		'cboServers
		'
		Me.tlpMain.SetColumnSpan(Me.cboServers, 2)
		resources.ApplyResources(Me.cboServers, "cboServers")
		Me.cboServers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboServers.FormattingEnabled = true
		Me.cboServers.Name = "cboServers"
		AddHandler Me.cboServers.SelectedIndexChanged, AddressOf Me.CboServersSelectedIndexChanged
		'
		'lblServers
		'
		resources.ApplyResources(Me.lblServers, "lblServers")
		Me.lblServers.Name = "lblServers"
		'
		'btnDelete
		'
		resources.ApplyResources(Me.btnDelete, "btnDelete")
		Me.btnDelete.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnDelete.Name = "btnDelete"
		Me.btnDelete.UseVisualStyleBackColor = true
		AddHandler Me.btnDelete.Click, AddressOf Me.BtnDeleteClick
		'
		'tlpMain
		'
		resources.ApplyResources(Me.tlpMain, "tlpMain")
		Me.tlpMain.Controls.Add(Me.lblLocalServer, 2, 1)
		Me.tlpMain.Controls.Add(Me.cboServers, 1, 0)
		Me.tlpMain.Controls.Add(Me.txtName, 1, 1)
		Me.tlpMain.Controls.Add(Me.chkSsl, 2, 2)
		Me.tlpMain.Controls.Add(Me.lblPort, 0, 2)
		Me.tlpMain.Controls.Add(Me.lblName, 0, 1)
		Me.tlpMain.Controls.Add(Me.txtPort, 1, 2)
		Me.tlpMain.Controls.Add(Me.lblServers, 0, 0)
		Me.tlpMain.Controls.Add(Me.tlpButtons, 0, 3)
		Me.tlpMain.Name = "tlpMain"
		'
		'tlpButtons
		'
		resources.ApplyResources(Me.tlpButtons, "tlpButtons")
		Me.tlpMain.SetColumnSpan(Me.tlpButtons, 3)
		Me.tlpButtons.Controls.Add(Me.btnConnect, 0, 0)
		Me.tlpButtons.Controls.Add(Me.btnCancel, 2, 0)
		Me.tlpButtons.Controls.Add(Me.btnDelete, 1, 0)
		Me.tlpButtons.Name = "tlpButtons"
		'
		'ConnectionSettingsForm
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.btnCancel
		Me.Controls.Add(Me.tlpMain)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "ConnectionSettingsForm"
		Me.ShowIcon = false
		Me.ShowInTaskbar = false
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.tlpMain.ResumeLayout(false)
		Me.tlpMain.PerformLayout
		Me.tlpButtons.ResumeLayout(false)
		Me.tlpButtons.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private tlpButtons As System.Windows.Forms.TableLayoutPanel
	Private tlpMain As System.Windows.Forms.TableLayoutPanel
	Private chkSsl As System.Windows.Forms.CheckBox
	Private btnDelete As System.Windows.Forms.Button
	Private lblServers As System.Windows.Forms.Label
	Private cboServers As System.Windows.Forms.ComboBox
	Private lblName As System.Windows.Forms.Label
	Private txtName As System.Windows.Forms.TextBox
	Private btnCancel As System.Windows.Forms.Button
	Private btnConnect As System.Windows.Forms.Button
	Private lblPort As System.Windows.Forms.Label
	Private txtPort As System.Windows.Forms.TextBox
	Private lblLocalServer As System.Windows.Forms.Label
End Class
