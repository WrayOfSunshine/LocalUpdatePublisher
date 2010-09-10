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
		Me.chkSsl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.chkSsl.Location = New System.Drawing.Point(135, 91)
		Me.chkSsl.Name = "chkSsl"
		Me.chkSsl.Size = New System.Drawing.Size(94, 16)
		Me.chkSsl.TabIndex = 14
		Me.chkSsl.Text = "Use SSL"
		Me.chkSsl.UseVisualStyleBackColor = true
		AddHandler Me.chkSsl.CheckedChanged, AddressOf Me.ChkSSLCheckedChanged
		'
		'lblLocalServer
		'
		Me.lblLocalServer.Location = New System.Drawing.Point(315, 65)
		Me.lblLocalServer.Name = "lblLocalServer"
		Me.lblLocalServer.Size = New System.Drawing.Size(169, 19)
		Me.lblLocalServer.TabIndex = 13
		Me.lblLocalServer.Text = "(Leave blank to use local server)"
		'
		'txtPort
		'
		Me.txtPort.Location = New System.Drawing.Point(73, 88)
		Me.txtPort.Name = "txtPort"
		Me.txtPort.Size = New System.Drawing.Size(35, 20)
		Me.txtPort.TabIndex = 12
		'
		'lblPort
		'
		Me.lblPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblPort.Location = New System.Drawing.Point(27, 88)
		Me.lblPort.Name = "lblPort"
		Me.lblPort.Size = New System.Drawing.Size(38, 19)
		Me.lblPort.TabIndex = 11
		Me.lblPort.Text = "Port"
		Me.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtName
		'
		Me.txtName.Location = New System.Drawing.Point(73, 62)
		Me.txtName.Name = "txtName"
		Me.txtName.Size = New System.Drawing.Size(236, 20)
		Me.txtName.TabIndex = 10
		'
		'lblName
		'
		Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblName.Location = New System.Drawing.Point(13, 62)
		Me.lblName.Name = "lblName"
		Me.lblName.Size = New System.Drawing.Size(52, 19)
		Me.lblName.TabIndex = 9
		Me.lblName.Text = "Name"
		Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'btnConnect
		'
		Me.btnConnect.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnConnect.Location = New System.Drawing.Point(29, 125)
		Me.btnConnect.Name = "btnConnect"
		Me.btnConnect.Size = New System.Drawing.Size(106, 27)
		Me.btnConnect.TabIndex = 15
		Me.btnConnect.Text = "Connect"
		Me.btnConnect.UseVisualStyleBackColor = true
		AddHandler Me.btnConnect.Click, AddressOf Me.BtnConnectClick
		'
		'btnCancel
		'
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Location = New System.Drawing.Point(241, 125)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(106, 27)
		Me.btnCancel.TabIndex = 16
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.UseVisualStyleBackColor = true
		'
		'cboServers
		'
		Me.cboServers.FormattingEnabled = true
		Me.cboServers.Location = New System.Drawing.Point(73, 27)
		Me.cboServers.Name = "cboServers"
		Me.cboServers.Size = New System.Drawing.Size(383, 21)
		Me.cboServers.TabIndex = 17
		AddHandler Me.cboServers.SelectedIndexChanged, AddressOf Me.CboServersSelectedIndexChanged
		'
		'lblServers
		'
		Me.lblServers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblServers.Location = New System.Drawing.Point(13, 29)
		Me.lblServers.Name = "lblServers"
		Me.lblServers.Size = New System.Drawing.Size(52, 19)
		Me.lblServers.TabIndex = 18
		Me.lblServers.Text = "Servers"
		Me.lblServers.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'btnDelete
		'
		Me.btnDelete.Enabled = false
		Me.btnDelete.Location = New System.Drawing.Point(135, 125)
		Me.btnDelete.Name = "btnDelete"
		Me.btnDelete.Size = New System.Drawing.Size(106, 27)
		Me.btnDelete.TabIndex = 19
		Me.btnDelete.Text = "Delete"
		Me.btnDelete.UseVisualStyleBackColor = true
		AddHandler Me.btnDelete.Click, AddressOf Me.BtnDeleteClick
		'
		'ConnectionSettingsForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(503, 171)
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
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "ConnectionSettingsForm"
		Me.ShowIcon = false
		Me.ShowInTaskbar = false
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "Connect to WSUS Server"
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
