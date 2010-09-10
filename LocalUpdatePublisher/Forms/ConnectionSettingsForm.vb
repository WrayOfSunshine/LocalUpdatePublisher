' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' ConnectionSettingsForm
' This form is used to modify the list of servers the
' program connects to.
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 10/29/2009
' Time: 11:26 AM

Public Partial Class ConnectionSettingsForm
	
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
	End Sub
	
	'Call ShowDialog with defaults
	Public Overloads Function ShowDialog() As DialogResult
		
		cboServers.Items.Clear
		For Each server As UpdateServer In ConnectionManager.ServerCollection
			If String.IsNullOrEmpty(Server.Name) Then
				cboServers.Items.Add("localhost")
			Else
			cboServers.Items.Add(server.Name)
			End If
		Next
		cboServers.Items.Add("Add New Server")
		
		Call ClearForm
		
		Return MyBase.ShowDialog
	End Function
	
	'The user has chosen to save the settings an connect to the server.
	Private Sub BtnConnectClick(sender As Object, e As EventArgs)
		
		'If this is the last item or a selection hasn't been made
		' then save a new update server to the server collection.
		If cboServers.SelectedIndex = cboServers.Items.Count - 1 Or cboServers.SelectedIndex = -1 Then
			Dim tmpServer As UpdateServer = New UpdateServer()
			tmpServer.Name = Me.txtName.Text.Trim
			tmpServer.Port = Convert.ToInt16(Me.txtPort.Text.Trim, System.Globalization.CultureInfo.CurrentCulture)
			tmpServer.Ssl = Me.chkSsl.Checked
			
			ConnectionManager.ServerCollection.Add(tmpServer)
		Else
			ConnectionManager.ServerCollection.Item(cboServers.SelectedIndex).Name = Me.txtName.Text.Trim
			ConnectionManager.ServerCollection.Item(cboServers.SelectedIndex).Port = Convert.ToInt16(Me.txtPort.Text.Trim, System.Globalization.CultureInfo.CurrentCulture)
			ConnectionManager.ServerCollection.Item(cboServers.SelectedIndex).Ssl = Me.chkSsl.Checked
		End If
	
	End Sub
	
	'When the user checks the SSH checkbox set the default port
	' for that selection.
	Private Sub chkSslCheckedChanged(sender As Object, e As EventArgs)
		If Me.chkSsl.Checked Then
			Me.txtPort.Text = "443"
		Else
			Me.txtPort.Text = "80"
		End If
	End Sub
	
	'Load the server data into the form.
	Sub CboServersSelectedIndexChanged(sender As Object, e As EventArgs)
		
		'If this is the last item then blank out the fields.
		If cboServers.SelectedIndex = -1 Then
			Call ClearForm
		Else If cboServers.SelectedIndex = cboServers.Items.Count - 1 Then
			btnDelete.Enabled = False
			txtName.Text = ""
			txtPort.Text = "80"
			chkSsl.Checked = False
		Else
			btnDelete.Enabled = True
			txtName.Text = ConnectionManager.ServerCollection.Item(cboServers.SelectedIndex).Name
			txtPort.Text = CStr(ConnectionManager.ServerCollection.Item(cboServers.SelectedIndex).Port)
			chkSsl.Checked = ConnectionManager.ServerCollection.Item(cboServers.SelectedIndex).Ssl
		End If
	End Sub
	
	'Remove the current server from the list.
	Sub BtnDeleteClick(sender As Object, e As EventArgs)
		
		'Make sure something is selected and that this isn't the last item.
		If cboServers.SelectedIndex > -1 And _
			cboServers.SelectedIndex <> cboServers.Items.Count - 1 Then
			Dim removeIndex As Integer = cboServers.SelectedIndex
			cboServers.Items.RemoveAt(removeIndex)
			ConnectionManager.ServerCollection.RemoveAt(removeIndex)
			Call ClearForm
		End If
	End Sub
	
	'Clear the text fields and set the defaults.
	Sub ClearForm
		cboServers.SelectedIndex = cboServers.Items.Count - 1
		btnDelete.Enabled = False
		txtName.Text = ""
		txtPort.Text = "80"
		chkSsl.Checked = False
	End Sub
End Class
