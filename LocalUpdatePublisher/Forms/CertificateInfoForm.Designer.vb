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
		Me.lblSubject.Location = New System.Drawing.Point(27, 55)
		Me.lblSubject.Name = "lblSubject"
		Me.lblSubject.Size = New System.Drawing.Size(74, 16)
		Me.lblSubject.TabIndex = 0
		Me.lblSubject.Text = "Subject"
		Me.lblSubject.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'lblIssuer
		'
		Me.lblIssuer.Location = New System.Drawing.Point(26, 83)
		Me.lblIssuer.Name = "lblIssuer"
		Me.lblIssuer.Size = New System.Drawing.Size(75, 16)
		Me.lblIssuer.TabIndex = 1
		Me.lblIssuer.Text = "Issued By"
		Me.lblIssuer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'lblEffectiveDates
		'
		Me.lblEffectiveDates.Location = New System.Drawing.Point(26, 111)
		Me.lblEffectiveDates.Name = "lblEffectiveDates"
		Me.lblEffectiveDates.Size = New System.Drawing.Size(75, 16)
		Me.lblEffectiveDates.TabIndex = 2
		Me.lblEffectiveDates.Text = "Effective"
		Me.lblEffectiveDates.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'lblSerial
		'
		Me.lblSerial.Location = New System.Drawing.Point(1, 139)
		Me.lblSerial.Name = "lblSerial"
		Me.lblSerial.Size = New System.Drawing.Size(100, 16)
		Me.lblSerial.TabIndex = 3
		Me.lblSerial.Text = "Serial Number"
		Me.lblSerial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'lblHash
		'
		Me.lblHash.Location = New System.Drawing.Point(35, 167)
		Me.lblHash.Name = "lblHash"
		Me.lblHash.Size = New System.Drawing.Size(66, 16)
		Me.lblHash.TabIndex = 4
		Me.lblHash.Text = "Hash"
		Me.lblHash.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtSubject
		'
		Me.txtSubject.Location = New System.Drawing.Point(116, 56)
		Me.txtSubject.Name = "txtSubject"
		Me.txtSubject.ReadOnly = true
		Me.txtSubject.Size = New System.Drawing.Size(310, 20)
		Me.txtSubject.TabIndex = 5
		'
		'txtHash
		'
		Me.txtHash.Location = New System.Drawing.Point(116, 163)
		Me.txtHash.Name = "txtHash"
		Me.txtHash.ReadOnly = true
		Me.txtHash.Size = New System.Drawing.Size(310, 20)
		Me.txtHash.TabIndex = 6
		'
		'txtEndDate
		'
		Me.txtEndDate.Location = New System.Drawing.Point(285, 111)
		Me.txtEndDate.Name = "txtEndDate"
		Me.txtEndDate.ReadOnly = true
		Me.txtEndDate.Size = New System.Drawing.Size(141, 20)
		Me.txtEndDate.TabIndex = 7
		'
		'txtStartDate
		'
		Me.txtStartDate.Location = New System.Drawing.Point(116, 111)
		Me.txtStartDate.Name = "txtStartDate"
		Me.txtStartDate.ReadOnly = true
		Me.txtStartDate.Size = New System.Drawing.Size(141, 20)
		Me.txtStartDate.TabIndex = 8
		'
		'txtIssuer
		'
		Me.txtIssuer.Location = New System.Drawing.Point(116, 83)
		Me.txtIssuer.Name = "txtIssuer"
		Me.txtIssuer.ReadOnly = true
		Me.txtIssuer.Size = New System.Drawing.Size(310, 20)
		Me.txtIssuer.TabIndex = 9
		'
		'lblTo
		'
		Me.lblTo.Location = New System.Drawing.Point(258, 109)
		Me.lblTo.Name = "lblTo"
		Me.lblTo.Size = New System.Drawing.Size(23, 23)
		Me.lblTo.TabIndex = 10
		Me.lblTo.Text = "To"
		Me.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtSerial
		'
		Me.txtSerial.Location = New System.Drawing.Point(116, 139)
		Me.txtSerial.Name = "txtSerial"
		Me.txtSerial.ReadOnly = true
		Me.txtSerial.Size = New System.Drawing.Size(310, 20)
		Me.txtSerial.TabIndex = 11
		'
		'btnOK
		'
		Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnOK.Location = New System.Drawing.Point(338, 200)
		Me.btnOK.Name = "btnOK"
		Me.btnOK.Size = New System.Drawing.Size(88, 25)
		Me.btnOK.TabIndex = 12
		Me.btnOK.Text = "OK"
		Me.btnOK.UseVisualStyleBackColor = true
		'
		'lblCertInfo
		'
		Me.lblCertInfo.Location = New System.Drawing.Point(11, 8)
		Me.lblCertInfo.Name = "lblCertInfo"
		Me.lblCertInfo.Size = New System.Drawing.Size(305, 45)
		Me.lblCertInfo.TabIndex = 13
		'
		'btnCreateCert
		'
		Me.btnCreateCert.Location = New System.Drawing.Point(116, 200)
		Me.btnCreateCert.Name = "btnCreateCert"
		Me.btnCreateCert.Size = New System.Drawing.Size(101, 25)
		Me.btnCreateCert.TabIndex = 14
		Me.btnCreateCert.Text = "Create Certificate"
		Me.btnCreateCert.UseVisualStyleBackColor = true
		AddHandler Me.btnCreateCert.Click, AddressOf Me.BtnCreateCertClick
		'
		'btnExportImportCert
		'
		Me.btnExportImportCert.Location = New System.Drawing.Point(12, 200)
		Me.btnExportImportCert.Name = "btnExportImportCert"
		Me.btnExportImportCert.Size = New System.Drawing.Size(101, 25)
		Me.btnExportImportCert.TabIndex = 15
		Me.btnExportImportCert.Text = "Export Certificate"
		Me.btnExportImportCert.UseVisualStyleBackColor = true
		AddHandler Me.btnExportImportCert.Click, AddressOf Me.BtnExportImportCertClick
		'
		'saveFileDialog
		'
		Me.saveFileDialog.DefaultExt = "cer"
		Me.saveFileDialog.Filter = "Certificates |*.cer"
		'
		'openFileDialog
		'
		Me.openFileDialog.DefaultExt = "cer"
		Me.openFileDialog.Filter = "PFX Certificate Files |*.pfx"
		'
		'CertificateInfoForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.btnOK
		Me.ClientSize = New System.Drawing.Size(452, 237)
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
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "CertificateInfoForm"
		Me.ShowIcon = false
		Me.ShowInTaskbar = false
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Certificate Information"
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
