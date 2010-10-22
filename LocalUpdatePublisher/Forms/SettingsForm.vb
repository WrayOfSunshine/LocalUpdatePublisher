' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
'Settings
' This form provides a place to manage the application settings.
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 2/3/2010
' Time: 8:31 AM

Public Partial Class SettingsForm
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
	End Sub
	
	'Load the appSetting into the form.
	Sub SettingsLoad(sender As Object, e As EventArgs)
		Me.chkRememberTreeNode.Checked = appSettings.RememberTreePath
		Me.chkReportRollup.Checked = appSettings.RollupReporting
		Me.chkDemoteClassification.Checked = appSettings.DemoteClassification
	End Sub
	
	Sub ChkRememberTreeNodeCheckedChanged(sender As Object, e As EventArgs)
		appSettings.RememberTreePath = Me.chkRememberTreeNode.Checked
	End Sub
	
	
	Sub ChkReportRollupCheckedChanged(sender As Object, e As EventArgs)
		appSettings.RollupReporting = Me.chkReportRollup.Checked
	End Sub
	
	Sub ChkDemoteClassificationCheckedChanged(sender As Object, e As EventArgs)
		appSettings.DemoteClassification = Me.chkDemoteClassification.Checked
	End Sub
End Class
