﻿' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
' Modified by kdixon Jan 10
'
' CertificateInfoForm
' This form allows us to view, create, and export the WSUS certificate.
' If the WSUS server doesn't have a certificate this form will
' allow us to create a self-signed certificate.  If a certificate exists
' we can export it to a file for distribution.
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 11/2/2009
' Time: 11:24 AM

Public Partial Class CertificateInfoForm
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
	End Sub
	
	'Load the certificate info when form loads.
	Private Sub CertificateInfoFormLoad(sender As Object, e As EventArgs)
		Call LoadCertInfo
	End Sub
	
	'Create a certificate if one doesn't exist.
	Private Sub BtnCreateCertClick(sender As Object, e As EventArgs)
		If ConnectionManager.CurrentServerCertificate Is Nothing Then
			ConnectionManager.CreateCert(Nothing, Nothing)
			LoadCertInfo()
		Else
			MessageBox.Show(globalRM.GetString("label_certificate_info_preexists"))
		End If
	End Sub
	
	'Prompt the user for a filename and then export the certificate.
	Private Sub BtnExportImportCertClick(sender As Object, e As EventArgs)
		If Me.btnExportImportCert.Text = globalRM.GetString("import_certificate") Then
			
			If ConnectionManager.CurrentServer.IsConnectionSecureForApiRemoting Then
				Dim DialogResult As DialogResult = Me.openFileDialog.ShowDialog
				
				'If the user selected a file.
				If DialogResult = Windows.Forms.DialogResult.OK Then
					'Prompt user for password.
					My.Forms.PasswordForm.Location =  new Point(Me.Location.X + 100, Me.Location.Y + 100)
					DialogResult = My.Forms.PasswordForm.ShowDialog
					
					'If the user entered a password.
					If DialogResult = DialogResult.OK Then
						ConnectionManager.CreateCert(Me.openFileDialog.FileName, My.Forms.PasswordForm.Password)
						Call LoadCertInfo
					End If
				End If
			Else
				MsgBox (globalRM.GetString("error_certificate_import_ssl"))
			End If
		Else
			Dim DialogResult As DialogResult = Me.saveFileDialog.ShowDialog
			
			'If the user selected a file.
			If DialogResult = DialogResult.OK Then
				ConnectionManager.ExportCert(Me.saveFileDialog.FileName)
			End If
		End If
		
	End Sub
	
	'Load WSUS certificate info into the form.  Show and hide the
	' create and export buttons depending upon the existence of a certificate.
	Sub LoadCertInfo()
		If ConnectionManager.CurrentServerCertificate Is Nothing Then
			Me.btnCreateCert.Show
			Me.btnExportImportCert.Text = globalRM.GetString("import_certificate")
			Me.txtCertInfo.Text = globalRM.GetString("label_certificate_info_no_cert")
		Else
			Me.btnCreateCert.Hide
			Me.btnExportImportCert.Text = globalRM.GetString("export_certificate")
			Me.txtCertInfo.Text = globalRM.GetString("label_certificate_info_exists")
			Me.txtSubject.Text = ConnectionManager.CurrentServerCertificate.Subject.ToString
			Me.txtIssuer.Text = ConnectionManager.CurrentServerCertificate.Issuer.ToString
			Me.txtStartDate.Text = ConnectionManager.CurrentServerCertificate.GetEffectiveDateString
			Me.txtEndDate.Text = ConnectionManager.CurrentServerCertificate.GetExpirationDateString
			Me.txtSerial.Text = ConnectionManager.CurrentServerCertificate.GetSerialNumberString
			Me.txtHash.Text = ConnectionManager.CurrentServerCertificate.GetCertHashString
		End If
	End Sub
	
	Shadows Sub TextChanged(sender As Object, e As EventArgs)
		CustomResize.ResizeVertically( sender, e)
	End Sub
End Class
