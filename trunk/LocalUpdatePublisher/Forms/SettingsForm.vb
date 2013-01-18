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

Partial Public Class SettingsForm
    Private m_dtCultures As DataTable
    Private m_cultures As ArrayList

    Public Sub New()
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        Me.InitializeComponent()

        Call PopulateCultureData()

        'Associate data table to combobox
        Me.cboCulture.DataSource = m_dtCultures
        Me.cboCulture.DisplayMember = "Culture"
        Me.cboCulture.ValueMember = "Code"
        Me.cboCulture.BindingContext = Me.BindingContext
    End Sub

    ''' <summary>
    ''' Populate the culture data table with the list of supported cultures.
    ''' </summary>
    Sub PopulateCultureData()
        'Create datatable
        m_dtCultures = New DataTable("Cultures")
        m_dtCultures.Locale = System.Globalization.CultureInfo.CurrentCulture

        'Add Columns to the data table.
        m_dtCultures.Columns.Add("Culture", System.Type.GetType("System.String"))
        m_dtCultures.Columns.Add("Code", System.Type.GetType("System.String"))

        'Add list of supported cultures
        m_dtCultures.Rows.Add((New String() {"Català", "ca-ES"}))
        m_dtCultures.Rows.Add((New String() {"Dansk", "da-DK"}))
        m_dtCultures.Rows.Add((New String() {"Deutsch", "de-DE"}))
        m_dtCultures.Rows.Add((New String() {"Français", "fr-FR"}))
        m_dtCultures.Rows.Add((New String() {"English", "en-US"}))
        m_dtCultures.Rows.Add((New String() {"Español", "es-ES"}))
        m_dtCultures.Rows.Add((New String() {"Polski", "pl-PL"}))
        m_dtCultures.Rows.Add((New String() {"Pусский", "ru-RU"}))
        m_dtCultures.Rows.Add((New String() {"Nederlands", "nl-NL"}))
        m_dtCultures.Rows.Add((New String() {"Suomi", "fi-FI"}))
        m_dtCultures.Rows.Add((New String() {"Svenska", "sv-SE"}))
        m_dtCultures.Rows.Add((New String() {"中文", "zh-CN"}))
    End Sub

    ''' <summary>
    ''' Load the appSetting into the form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub SettingsLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.chkRememberTreeNode.Checked = Globals.appSettings.RememberTreePath
        Me.chkReportRollup.Checked = Globals.appSettings.RollupReporting
        Me.chkDemoteClassification.Checked = Globals.appSettings.DemoteClassification
        Me.chkHideOfficialUpdates.Checked = Globals.appSettings.HideOfficialUpdates
        Me.cboCulture.SelectedValue = Globals.appSettings.Culture
        Me.txtTimeOut.Text = Globals.appSettings.TimeOut.ToString
    End Sub

    Sub ChkRememberTreeNodeCheckedChanged(sender As Object, e As EventArgs) Handles chkRememberTreeNode.CheckedChanged
        Globals.appSettings.RememberTreePath = Me.chkRememberTreeNode.Checked
    End Sub


    Sub ChkReportRollupCheckedChanged(sender As Object, e As EventArgs) Handles chkReportRollup.CheckedChanged
        Globals.appSettings.RollupReporting = Me.chkReportRollup.Checked
    End Sub

    Sub ChkDemoteClassificationCheckedChanged(sender As Object, e As EventArgs) Handles chkDemoteClassification.CheckedChanged
        Globals.appSettings.DemoteClassification = Me.chkDemoteClassification.Checked
    End Sub

    Sub CboCultureSelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCulture.SelectedIndexChanged
        Globals.appSettings.Culture = DirectCast(cboCulture.SelectedValue, String)
    End Sub

    Sub CboCultureSelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCulture.SelectionChangeCommitted
        MsgBox(Globals.globalRM.GetString("warning_options_restart"))
    End Sub

    Sub TxtTimeOutTextChanged(sender As Object, e As EventArgs) Handles txtTimeOut.TextChanged
        Globals.appSettings.TimeOut = Convert.ToInt32(txtTimeOut.Text)
    End Sub

    Sub ChkHideOfficialUpdatesCheckedChanged(sender As Object, e As EventArgs) Handles chkHideOfficialUpdates.CheckedChanged
        Globals.appSettings.HideOfficialUpdates = Me.chkHideOfficialUpdates.Checked
        MsgBox(Globals.globalRM.GetString("warning_options_restart"))
    End Sub
End Class
