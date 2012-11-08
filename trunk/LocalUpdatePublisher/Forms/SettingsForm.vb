Option Explicit On
Option Strict On
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
Imports System.Data

Public Partial Class SettingsForm
	Private _dtCultures As DataTable
	Private _cultures As ArrayList
	
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		Call PopulateCultureData
		
		'Associate data table to combobox
		Me.cboCulture.DataSource = _dtCultures
		Me.cboCulture.DisplayMember = "Culture"
		Me.cboCulture.ValueMember = "Code"
		Me.cboCulture.BindingContext = me.BindingContext
	End Sub
	
	'Populate the culture data table with the list of supported cultures.
	Sub PopulateCultureData
		'Create datatable
		_dtCultures = New DataTable("Cultures")
		_dtCultures.Locale = System.Globalization.CultureInfo.CurrentCulture
		
		'Add Columns to the data table.
		_dtCultures.Columns.Add("Culture", System.Type.GetType("System.String"))
		_dtCultures.Columns.Add("Code", System.Type.GetType("System.String"))
		
		'Add list of supported cultures
		_dtCultures.Rows.Add((New String(){"Català","ca-ES"}))
		_dtCultures.Rows.Add((New String(){"Dansk","da-DK"}))
		_dtCultures.Rows.Add((New String(){"Deutsch","de-DE"}))
		_dtCultures.Rows.Add((New String(){"Français","fr-FR"}))
		_dtCultures.Rows.Add((New String(){"English","en-US"}))
		_dtCultures.Rows.Add((New String(){"Español","es-ES"}))
		_dtCultures.Rows.Add((New String(){"Polski","pl-PL"}))
		_dtCultures.Rows.Add((New String(){"Pусский","ru-RU"}))
		_dtCultures.Rows.Add((New String(){"Nederlands","nl-NL"}))
		_dtCultures.Rows.Add((New String(){"Suomi","fi-FI"}))
		_dtCultures.Rows.Add((New String(){"Svenska","sv-SE"}))
		_dtCultures.Rows.Add((New String(){"中文","zh-CN"}))
	End Sub
	
	'Load the appSetting into the form.
	Sub SettingsLoad(sender As Object, e As EventArgs)
		Me.chkRememberTreeNode.Checked = appSettings.RememberTreePath
		Me.chkReportRollup.Checked = appSettings.RollupReporting
		Me.chkDemoteClassification.Checked = appSettings.DemoteClassification
		Me.chkHideOfficialUpdates.Checked = appSettings.HideOfficialUpdates
		Me.cboCulture.SelectedValue = appSettings.Culture
		Me.txtTimeOut.Text = appSettings.TimeOut.ToString
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
	
	Sub CboCultureSelectedIndexChanged(sender As Object, e As EventArgs)
		appSettings.Culture = DirectCast(cboCulture.SelectedValue, String)
	End Sub
	
	Sub CboCultureSelectionChangeCommitted(sender As Object, e As EventArgs)
		Msgbox (globalRM.GetString("warning_options_restart"))
	End Sub
	
	Sub TxtTimeOutTextChanged(sender As Object, e As EventArgs)
		appSettings.TimeOut = Convert.ToInt32(txtTimeOut.Text)
	End Sub
	
	Sub ChkHideOfficialUpdatesCheckedChanged(sender As Object, e As EventArgs)
		appSettings.HideOfficialUpdates = Me.chkHideOfficialUpdates.Checked
		Msgbox (globalRM.GetString("warning_options_restart"))
	End Sub
End Class
