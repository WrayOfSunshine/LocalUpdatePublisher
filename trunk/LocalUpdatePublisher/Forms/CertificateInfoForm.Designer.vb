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
		Me.btnCreateCert = New System.Windows.Forms.Button
		Me.btnExportImportCert = New System.Windows.Forms.Button
		Me.saveFileDialog = New System.Windows.Forms.SaveFileDialog
		Me.openFileDialog = New System.Windows.Forms.OpenFileDialog
		Me.tlpMain = New System.Windows.Forms.TableLayoutPanel
		Me.txtSize = New System.Windows.Forms.TextBox
		Me.lblSize = New System.Windows.Forms.Label
		Me.tlpButtonsLeft = New System.Windows.Forms.TableLayoutPanel
		Me.txtCertInfo = New System.Windows.Forms.TextBox
		Me.tlpMain.SuspendLayout
		Me.tlpButtonsLeft.SuspendLayout
		Me.SuspendLayout
		'
		'lblSubject
		'
		resources.ApplyResources(Me.lblSubject, "lblSubject")
		Me.lblSubject.Name = "lblSubject"
		'
		'lblIssuer
		'
		resources.ApplyResources(Me.lblIssuer, "lblIssuer")
		Me.lblIssuer.Name = "lblIssuer"
		'
		'lblEffectiveDates
		'
		resources.ApplyResources(Me.lblEffectiveDates, "lblEffectiveDates")
		Me.lblEffectiveDates.Name = "lblEffectiveDates"
		'
		'lblSerial
		'
		resources.ApplyResources(Me.lblSerial, "lblSerial")
		Me.lblSerial.Name = "lblSerial"
		'
		'lblHash
		'
		resources.ApplyResources(Me.lblHash, "lblHash")
		Me.lblHash.Name = "lblHash"
		'
		'txtSubject
		'
		Me.tlpMain.SetColumnSpan(Me.txtSubject, 3)
		resources.ApplyResources(Me.txtSubject, "txtSubject")
		Me.txtSubject.Name = "txtSubject"
		Me.txtSubject.ReadOnly = true
		'
		'txtHash
		'
		Me.tlpMain.SetColumnSpan(Me.txtHash, 3)
		resources.ApplyResources(Me.txtHash, "txtHash")
		Me.txtHash.Name = "txtHash"
		Me.txtHash.ReadOnly = true
		'
		'txtEndDate
		'
		resources.ApplyResources(Me.txtEndDate, "txtEndDate")
		Me.txtEndDate.Name = "txtEndDate"
		Me.txtEndDate.ReadOnly = true
		'
		'txtStartDate
		'
		resources.ApplyResources(Me.txtStartDate, "txtStartDate")
		Me.txtStartDate.Name = "txtStartDate"
		Me.txtStartDate.ReadOnly = true
		'
		'txtIssuer
		'
		Me.tlpMain.SetColumnSpan(Me.txtIssuer, 3)
		resources.ApplyResources(Me.txtIssuer, "txtIssuer")
		Me.txtIssuer.Name = "txtIssuer"
		Me.txtIssuer.ReadOnly = true
		'
		'lblTo
		'
		resources.ApplyResources(Me.lblTo, "lblTo")
		Me.lblTo.Name = "lblTo"
		'
		'txtSerial
		'
		Me.tlpMain.SetColumnSpan(Me.txtSerial, 3)
		resources.ApplyResources(Me.txtSerial, "txtSerial")
		Me.txtSerial.Name = "txtSerial"
		Me.txtSerial.ReadOnly = true
		'
		'btnOK
		'
		resources.ApplyResources(Me.btnOK, "btnOK")
		Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnOK.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnOK.Name = "btnOK"
		Me.btnOK.UseVisualStyleBackColor = true
		'
		'btnCreateCert
		'
		resources.ApplyResources(Me.btnCreateCert, "btnCreateCert")
		Me.btnCreateCert.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnCreateCert.Name = "btnCreateCert"
		Me.btnCreateCert.UseVisualStyleBackColor = true
		AddHandler Me.btnCreateCert.Click, AddressOf Me.BtnCreateCertClick
		'
		'btnExportImportCert
		'
		resources.ApplyResources(Me.btnExportImportCert, "btnExportImportCert")
		Me.btnExportImportCert.MinimumSize = New System.Drawing.Size(80, 25)
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
		'tlpMain
		'
		resources.ApplyResources(Me.tlpMain, "tlpMain")
		Me.tlpMain.Controls.Add(Me.txtSize, 1, 6)
		Me.tlpMain.Controls.Add(Me.lblSize, 0, 6)
		Me.tlpMain.Controls.Add(Me.tlpButtonsLeft, 0, 7)
		Me.tlpMain.Controls.Add(Me.txtCertInfo, 0, 0)
		Me.tlpMain.Controls.Add(Me.lblTo, 2, 3)
		Me.tlpMain.Controls.Add(Me.txtEndDate, 3, 3)
		Me.tlpMain.Controls.Add(Me.lblSubject, 0, 1)
		Me.tlpMain.Controls.Add(Me.txtStartDate, 1, 3)
		Me.tlpMain.Controls.Add(Me.lblIssuer, 0, 2)
		Me.tlpMain.Controls.Add(Me.lblEffectiveDates, 0, 3)
		Me.tlpMain.Controls.Add(Me.txtSubject, 1, 1)
		Me.tlpMain.Controls.Add(Me.txtHash, 1, 5)
		Me.tlpMain.Controls.Add(Me.lblSerial, 0, 4)
		Me.tlpMain.Controls.Add(Me.txtSerial, 1, 4)
		Me.tlpMain.Controls.Add(Me.txtIssuer, 1, 2)
		Me.tlpMain.Controls.Add(Me.lblHash, 0, 5)
		Me.tlpMain.Controls.Add(Me.btnOK, 3, 7)
		Me.tlpMain.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize
		Me.tlpMain.Name = "tlpMain"
		'
		'txtSize
		'
		Me.tlpMain.SetColumnSpan(Me.txtSize, 3)
		resources.ApplyResources(Me.txtSize, "txtSize")
		Me.txtSize.Name = "txtSize"
		Me.txtSize.ReadOnly = true
		'
		'lblSize
		'
		resources.ApplyResources(Me.lblSize, "lblSize")
		Me.lblSize.Name = "lblSize"
		'
		'tlpButtonsLeft
		'
		resources.ApplyResources(Me.tlpButtonsLeft, "tlpButtonsLeft")
		Me.tlpMain.SetColumnSpan(Me.tlpButtonsLeft, 2)
		Me.tlpButtonsLeft.Controls.Add(Me.btnExportImportCert, 0, 0)
		Me.tlpButtonsLeft.Controls.Add(Me.btnCreateCert, 1, 0)
		Me.tlpButtonsLeft.Name = "tlpButtonsLeft"
		'
		'txtCertInfo
		'
		Me.txtCertInfo.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.tlpMain.SetColumnSpan(Me.txtCertInfo, 4)
		resources.ApplyResources(Me.txtCertInfo, "txtCertInfo")
		Me.txtCertInfo.Name = "txtCertInfo"
		Me.txtCertInfo.ReadOnly = true
		AddHandler Me.txtCertInfo.TextChanged, AddressOf Me.TextChanged
		'
		'CertificateInfoForm
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.btnOK
		Me.Controls.Add(Me.tlpMain)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "CertificateInfoForm"
		Me.ShowIcon = false
		Me.ShowInTaskbar = false
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		AddHandler Load, AddressOf Me.CertificateInfoFormLoad
		Me.tlpMain.ResumeLayout(false)
		Me.tlpMain.PerformLayout
		Me.tlpButtonsLeft.ResumeLayout(false)
		Me.tlpButtonsLeft.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private lblSize As System.Windows.Forms.Label
	Private txtSize As System.Windows.Forms.TextBox
	Private tlpButtonsLeft As System.Windows.Forms.TableLayoutPanel
	Private tlpMain As System.Windows.Forms.TableLayoutPanel
	Private txtCertInfo As System.Windows.Forms.TextBox
	Private btnExportImportCert As System.Windows.Forms.Button
	Private openFileDialog As System.Windows.Forms.OpenFileDialog
	Private saveFileDialog As System.Windows.Forms.SaveFileDialog
	Private btnCreateCert As System.Windows.Forms.Button
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
