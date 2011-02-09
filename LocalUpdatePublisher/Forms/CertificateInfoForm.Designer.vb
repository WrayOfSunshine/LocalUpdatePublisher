' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 11/2/2009
' Time: 11:24 AM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class CertificateInfoForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CertificateInfoForm))
		Me.lblSubject = New System.Windows.Forms.Label
		Me.lblIssuer = New System.Windows.Forms.Label
		Me.lblEffectiveDates = New System.Windows.Forms.Label
		Me.lblSerial = New System.Windows.Forms.Label
		Me.lblHash = New System.Windows.Forms.Label
		Me.txtSubject = New System.Windows.Forms.TextBox
		Me.txtHash = New System.Windows.Forms.TextBox
		Me.txtEndDate = New System.Windows.Forms.TextBox
		Me.txtStartDate = New System.Windows.Forms.TextBox
		Me.txtIssuer = New System.Windows.Forms.TextBox
		Me.lblTo = New System.Windows.Forms.Label
		Me.txtSerial = New System.Windows.Forms.TextBox
		Me.btnOK = New System.Windows.Forms.Button
		Me.lblCertInfo = New System.Windows.Forms.Label
		Me.btnCreateCert = New System.Windows.Forms.Button
		Me.btnExportImportCert = New System.Windows.Forms.Button
		Me.saveFileDialog = New System.Windows.Forms.SaveFileDialog
		Me.openFileDialog = New System.Windows.Forms.OpenFileDialog
		Me.SuspendLayout
		'
		'lblSubject
		'
		Me.lblSubject.AccessibleDescription = Nothing
		Me.lblSubject.AccessibleName = Nothing
		resources.ApplyResources(Me.lblSubject, "lblSubject")
		Me.lblSubject.Font = Nothing
		Me.lblSubject.Name = "lblSubject"
		'
		'lblIssuer
		'
		Me.lblIssuer.AccessibleDescription = Nothing
		Me.lblIssuer.AccessibleName = Nothing
		resources.ApplyResources(Me.lblIssuer, "lblIssuer")
		Me.lblIssuer.Font = Nothing
		Me.lblIssuer.Name = "lblIssuer"
		'
		'lblEffectiveDates
		'
		Me.lblEffectiveDates.AccessibleDescription = Nothing
		Me.lblEffectiveDates.AccessibleName = Nothing
		resources.ApplyResources(Me.lblEffectiveDates, "lblEffectiveDates")
		Me.lblEffectiveDates.Font = Nothing
		Me.lblEffectiveDates.Name = "lblEffectiveDates"
		'
		'lblSerial
		'
		Me.lblSerial.AccessibleDescription = Nothing
		Me.lblSerial.AccessibleName = Nothing
		resources.ApplyResources(Me.lblSerial, "lblSerial")
		Me.lblSerial.Font = Nothing
		Me.lblSerial.Name = "lblSerial"
		'
		'lblHash
		'
		Me.lblHash.AccessibleDescription = Nothing
		Me.lblHash.AccessibleName = Nothing
		resources.ApplyResources(Me.lblHash, "lblHash")
		Me.lblHash.Font = Nothing
		Me.lblHash.Name = "lblHash"
		'
		'txtSubject
		'
		Me.txtSubject.AccessibleDescription = Nothing
		Me.txtSubject.AccessibleName = Nothing
		resources.ApplyResources(Me.txtSubject, "txtSubject")
		Me.txtSubject.BackgroundImage = Nothing
		Me.txtSubject.Font = Nothing
		Me.txtSubject.Name = "txtSubject"
		Me.txtSubject.ReadOnly = true
		'
		'txtHash
		'
		Me.txtHash.AccessibleDescription = Nothing
		Me.txtHash.AccessibleName = Nothing
		resources.ApplyResources(Me.txtHash, "txtHash")
		Me.txtHash.BackgroundImage = Nothing
		Me.txtHash.Font = Nothing
		Me.txtHash.Name = "txtHash"
		Me.txtHash.ReadOnly = true
		'
		'txtEndDate
		'
		Me.txtEndDate.AccessibleDescription = Nothing
		Me.txtEndDate.AccessibleName = Nothing
		resources.ApplyResources(Me.txtEndDate, "txtEndDate")
		Me.txtEndDate.BackgroundImage = Nothing
		Me.txtEndDate.Font = Nothing
		Me.txtEndDate.Name = "txtEndDate"
		Me.txtEndDate.ReadOnly = true
		'
		'txtStartDate
		'
		Me.txtStartDate.AccessibleDescription = Nothing
		Me.txtStartDate.AccessibleName = Nothing
		resources.ApplyResources(Me.txtStartDate, "txtStartDate")
		Me.txtStartDate.BackgroundImage = Nothing
		Me.txtStartDate.Font = Nothing
		Me.txtStartDate.Name = "txtStartDate"
		Me.txtStartDate.ReadOnly = true
		'
		'txtIssuer
		'
		Me.txtIssuer.AccessibleDescription = Nothing
		Me.txtIssuer.AccessibleName = Nothing
		resources.ApplyResources(Me.txtIssuer, "txtIssuer")
		Me.txtIssuer.BackgroundImage = Nothing
		Me.txtIssuer.Font = Nothing
		Me.txtIssuer.Name = "txtIssuer"
		Me.txtIssuer.ReadOnly = true
		'
		'lblTo
		'
		Me.lblTo.AccessibleDescription = Nothing
		Me.lblTo.AccessibleName = Nothing
		resources.ApplyResources(Me.lblTo, "lblTo")
		Me.lblTo.Font = Nothing
		Me.lblTo.Name = "lblTo"
		'
		'txtSerial
		'
		Me.txtSerial.AccessibleDescription = Nothing
		Me.txtSerial.AccessibleName = Nothing
		resources.ApplyResources(Me.txtSerial, "txtSerial")
		Me.txtSerial.BackgroundImage = Nothing
		Me.txtSerial.Font = Nothing
		Me.txtSerial.Name = "txtSerial"
		Me.txtSerial.ReadOnly = true
		'
		'btnOK
		'
		Me.btnOK.AccessibleDescription = Nothing
		Me.btnOK.AccessibleName = Nothing
		resources.ApplyResources(Me.btnOK, "btnOK")
		Me.btnOK.BackgroundImage = Nothing
		Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnOK.Font = Nothing
		Me.btnOK.Name = "btnOK"
		Me.btnOK.UseVisualStyleBackColor = true
		'
		'lblCertInfo
		'
		Me.lblCertInfo.AccessibleDescription = Nothing
		Me.lblCertInfo.AccessibleName = Nothing
		resources.ApplyResources(Me.lblCertInfo, "lblCertInfo")
		Me.lblCertInfo.Font = Nothing
		Me.lblCertInfo.Name = "lblCertInfo"
		'
		'btnCreateCert
		'
		Me.btnCreateCert.AccessibleDescription = Nothing
		Me.btnCreateCert.AccessibleName = Nothing
		resources.ApplyResources(Me.btnCreateCert, "btnCreateCert")
		Me.btnCreateCert.BackgroundImage = Nothing
		Me.btnCreateCert.Font = Nothing
		Me.btnCreateCert.Name = "btnCreateCert"
		Me.btnCreateCert.UseVisualStyleBackColor = true
		AddHandler Me.btnCreateCert.Click, AddressOf Me.BtnCreateCertClick
		'
		'btnExportImportCert
		'
		Me.btnExportImportCert.AccessibleDescription = Nothing
		Me.btnExportImportCert.AccessibleName = Nothing
		resources.ApplyResources(Me.btnExportImportCert, "btnExportImportCert")
		Me.btnExportImportCert.BackgroundImage = Nothing
		Me.btnExportImportCert.Font = Nothing
		Me.btnExportImportCert.Name = "btnExportImportCert"
		Me.btnExportImportCert.UseVisualStyleBackColor = true
		AddHandler Me.btnExportImportCert.Click, AddressOf Me.BtnExportImportCertClick
		'
		'saveFileDialog
		'
		Me.saveFileDialog.DefaultExt = "cer"
		resources.ApplyResources(Me.saveFileDialog, "saveFileDialog")
		'
		'openFileDialog
		'
		Me.openFileDialog.DefaultExt = "cer"
		resources.ApplyResources(Me.openFileDialog, "openFileDialog")
		'
		'CertificateInfoForm
		'
		Me.AccessibleDescription = Nothing
		Me.AccessibleName = Nothing
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackgroundImage = Nothing
		Me.CancelButton = Me.btnOK
		Me.Controls.Add(Me.btnExportImportCert)
		Me.Controls.Add(Me.btnCreateCert)
		Me.Controls.Add(Me.lblCertInfo)
		Me.Controls.Add(Me.btnOK)
		Me.Controls.Add(Me.txtSerial)
		Me.Controls.Add(Me.lblTo)
		Me.Controls.Add(Me.txtIssuer)
		Me.Controls.Add(Me.txtStartDate)
		Me.Controls.Add(Me.txtEndDate)
		Me.Controls.Add(Me.txtHash)
		Me.Controls.Add(Me.txtSubject)
		Me.Controls.Add(Me.lblHash)
		Me.Controls.Add(Me.lblSerial)
		Me.Controls.Add(Me.lblEffectiveDates)
		Me.Controls.Add(Me.lblIssuer)
		Me.Controls.Add(Me.lblSubject)
		Me.Font = Nothing
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "CertificateInfoForm"
		Me.ShowIcon = false
		Me.ShowInTaskbar = false
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		AddHandler Load, AddressOf Me.CertificateInfoFormLoad
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private btnExportImportCert As System.Windows.Forms.Button
	Private openFileDialog As System.Windows.Forms.OpenFileDialog
	Private saveFileDialog As System.Windows.Forms.SaveFileDialog
	Private btnCreateCert As System.Windows.Forms.Button
	Private lblCertInfo As System.Windows.Forms.Label
	Private txtHash As System.Windows.Forms.TextBox
	Private btnOK As System.Windows.Forms.Button
	Private txtSerial As System.Windows.Forms.TextBox
	Private lblTo As System.Windows.Forms.Label
	Private txtIssuer As System.Windows.Forms.TextBox
	Private txtStartDate As System.Windows.Forms.TextBox
	Private txtEndDate As System.Windows.Forms.TextBox
	Private txtSubject As System.Windows.Forms.TextBox
	Private lblHash As System.Windows.Forms.Label
	Private lblSerial As System.Windows.Forms.Label
	Private lblEffectiveDates As System.Windows.Forms.Label
	Private lblIssuer As System.Windows.Forms.Label
	Private lblSubject As System.Windows.Forms.Label
End Class
