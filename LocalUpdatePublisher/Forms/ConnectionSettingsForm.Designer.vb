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
		Me.SuspendLayout
		'
		'chkSsl
		'
		Me.chkSsl.AccessibleDescription = Nothing
		Me.chkSsl.AccessibleName = Nothing
		resources.ApplyResources(Me.chkSsl, "chkSsl")
		Me.chkSsl.BackgroundImage = Nothing
		Me.chkSsl.Name = "chkSsl"
		Me.chkSsl.UseVisualStyleBackColor = true
		AddHandler Me.chkSsl.CheckedChanged, AddressOf Me.ChkSSLCheckedChanged
		'
		'lblLocalServer
		'
		Me.lblLocalServer.AccessibleDescription = Nothing
		Me.lblLocalServer.AccessibleName = Nothing
		resources.ApplyResources(Me.lblLocalServer, "lblLocalServer")
		Me.lblLocalServer.Font = Nothing
		Me.lblLocalServer.Name = "lblLocalServer"
		'
		'txtPort
		'
		Me.txtPort.AccessibleDescription = Nothing
		Me.txtPort.AccessibleName = Nothing
		resources.ApplyResources(Me.txtPort, "txtPort")
		Me.txtPort.BackgroundImage = Nothing
		Me.txtPort.Font = Nothing
		Me.txtPort.Name = "txtPort"
		'
		'lblPort
		'
		Me.lblPort.AccessibleDescription = Nothing
		Me.lblPort.AccessibleName = Nothing
		resources.ApplyResources(Me.lblPort, "lblPort")
		Me.lblPort.Name = "lblPort"
		'
		'txtName
		'
		Me.txtName.AccessibleDescription = Nothing
		Me.txtName.AccessibleName = Nothing
		resources.ApplyResources(Me.txtName, "txtName")
		Me.txtName.BackgroundImage = Nothing
		Me.txtName.Font = Nothing
		Me.txtName.Name = "txtName"
		'
		'lblName
		'
		Me.lblName.AccessibleDescription = Nothing
		Me.lblName.AccessibleName = Nothing
		resources.ApplyResources(Me.lblName, "lblName")
		Me.lblName.Name = "lblName"
		'
		'btnConnect
		'
		Me.btnConnect.AccessibleDescription = Nothing
		Me.btnConnect.AccessibleName = Nothing
		resources.ApplyResources(Me.btnConnect, "btnConnect")
		Me.btnConnect.BackgroundImage = Nothing
		Me.btnConnect.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnConnect.Font = Nothing
		Me.btnConnect.Name = "btnConnect"
		Me.btnConnect.UseVisualStyleBackColor = true
		AddHandler Me.btnConnect.Click, AddressOf Me.BtnConnectClick
		'
		'btnCancel
		'
		Me.btnCancel.AccessibleDescription = Nothing
		Me.btnCancel.AccessibleName = Nothing
		resources.ApplyResources(Me.btnCancel, "btnCancel")
		Me.btnCancel.BackgroundImage = Nothing
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Font = Nothing
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.UseVisualStyleBackColor = true
		'
		'cboServers
		'
		Me.cboServers.AccessibleDescription = Nothing
		Me.cboServers.AccessibleName = Nothing
		resources.ApplyResources(Me.cboServers, "cboServers")
		Me.cboServers.BackgroundImage = Nothing
		Me.cboServers.Font = Nothing
		Me.cboServers.FormattingEnabled = true
		Me.cboServers.Name = "cboServers"
		AddHandler Me.cboServers.SelectedIndexChanged, AddressOf Me.CboServersSelectedIndexChanged
		'
		'lblServers
		'
		Me.lblServers.AccessibleDescription = Nothing
		Me.lblServers.AccessibleName = Nothing
		resources.ApplyResources(Me.lblServers, "lblServers")
		Me.lblServers.Name = "lblServers"
		'
		'btnDelete
		'
		Me.btnDelete.AccessibleDescription = Nothing
		Me.btnDelete.AccessibleName = Nothing
		resources.ApplyResources(Me.btnDelete, "btnDelete")
		Me.btnDelete.BackgroundImage = Nothing
		Me.btnDelete.Font = Nothing
		Me.btnDelete.Name = "btnDelete"
		Me.btnDelete.UseVisualStyleBackColor = true
		AddHandler Me.btnDelete.Click, AddressOf Me.BtnDeleteClick
		'
		'ConnectionSettingsForm
		'
		Me.AccessibleDescription = Nothing
		Me.AccessibleName = Nothing
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackgroundImage = Nothing
		Me.CancelButton = Me.btnCancel
		Me.Controls.Add(Me.btnDelete)
		Me.Controls.Add(Me.cboServers)
		Me.Controls.Add(Me.lblServers)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnConnect)
		Me.Controls.Add(Me.chkSsl)
		Me.Controls.Add(Me.lblLocalServer)
		Me.Controls.Add(Me.txtPort)
		Me.Controls.Add(Me.lblPort)
		Me.Controls.Add(Me.txtName)
		Me.Controls.Add(Me.lblName)
		Me.Font = Nothing
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "ConnectionSettingsForm"
		Me.ShowIcon = false
		Me.ShowInTaskbar = false
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
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
