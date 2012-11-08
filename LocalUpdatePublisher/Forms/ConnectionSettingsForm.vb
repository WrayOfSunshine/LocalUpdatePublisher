Option Explicit On
Option Strict On
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

Partial Public Class ConnectionSettingsForm

    Public Sub New()
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        Me.InitializeComponent()
    End Sub

    ''' <summary>
    ''' Call ShowDialog with defaults
    ''' </summary>
    Public Overloads Function ShowDialog() As DialogResult

        cboServers.Items.Clear()
        For Each server As UpdateServer In ConnectionManager.ServerCollection
            If String.IsNullOrEmpty(server.Name) Then
                cboServers.Items.Add("localhost")
            Else
                cboServers.Items.Add(server.Name)
            End If
        Next
        cboServers.Items.Add(globalRM.GetString("add_new_server"))

        Call ClearForm()

        Return MyBase.ShowDialog
    End Function

    ''' <summary>
    ''' The user has chosen to save the settings an connect to the server.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
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
    ''' <summary>
    ''' When the user checks the SSH checkbox set the default por for that selection.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub chkSslCheckedChanged(sender As Object, e As EventArgs)

        If Me.chkSsl.Checked AndAlso Me.txtPort.Text = "80" Then
            Me.txtPort.Text = "443"
        ElseIf Me.txtPort.Text = "443" Then
            Me.txtPort.Text = "80"
        End If
    End Sub

    ''' <summary>
    ''' Load the server data into the form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub CboServersSelectedIndexChanged(sender As Object, e As EventArgs)

        'If this is the last item then blank out the fields.
        If cboServers.SelectedIndex = -1 Then
            Call ClearForm()
        ElseIf cboServers.SelectedIndex = cboServers.Items.Count - 1 Then
            btnDelete.Enabled = False
            txtName.Text = ""
            chkSsl.Checked = False
            txtPort.Text = "80"
        Else
            btnDelete.Enabled = True
            txtName.Text = ConnectionManager.ServerCollection.Item(cboServers.SelectedIndex).Name
            chkSsl.Checked = ConnectionManager.ServerCollection.Item(cboServers.SelectedIndex).Ssl
            txtPort.Text = CStr(ConnectionManager.ServerCollection.Item(cboServers.SelectedIndex).Port)
        End If
    End Sub

    ''' <summary>
    ''' 'Remove the current server from the list.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub BtnDeleteClick(sender As Object, e As EventArgs)

        'Make sure something is selected and that this isn't the last item.
        If cboServers.SelectedIndex > -1 And _
            cboServers.SelectedIndex <> cboServers.Items.Count - 1 Then
            Dim removeIndex As Integer = cboServers.SelectedIndex
            cboServers.Items.RemoveAt(removeIndex)
            ConnectionManager.ServerCollection.RemoveAt(removeIndex)
            Call ClearForm()
        End If
    End Sub

    ''' <summary>
    ''' Clear the text fields and set the defaults.
    ''' </summary>
    Sub ClearForm()
        cboServers.SelectedIndex = cboServers.Items.Count - 1
        btnDelete.Enabled = False
        txtName.Text = ""
        txtPort.Text = "80"
        chkSsl.Checked = False
    End Sub

End Class
