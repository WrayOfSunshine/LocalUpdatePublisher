Option Explicit On
Option Strict On
' Copyright (C) <2010> <Bryan R. Dam>
' Released Under The MIT License As Found In LICENSE.Txt
'
' UpdateForm
' This form is used to create and revise Software Distribution Packages
' for the WSUS server.  If the form is called with a string to a SDP file
' then it loads the form with that data.  Otherwise, it walks the user through creating
' a new package.
' This form is intended to work like a typical wizard.  This is accomplished by using
' a customized TabControl object that allows us to hide the tab names.  In this manner
' we can create pages of the wizard easily in design mode but hide the tab
' navigation at run time.
'
' Created By SharpDevelop.
' User: Bryan
' Date: 10/22/2009
' Time: 9:19 PM

Imports Microsoft.UpdateServices.Administration
Imports System.Xml
Imports System.Xml.Schema
Imports System.IO
Imports System.Text
Imports System.ComponentModel
Imports System.Security
Imports System.Security.Cryptography
Imports System.Collections.Specialized

Partial Public Class UpdateForm

    Private m_SDP As SoftwareDistributionPackage
    Private m_tabsHidden As New List(Of TabPage)
    Private m_updateType As LocalUpdateTypes
    Private m_revision As Boolean
    Private m_originalURIChanged As Boolean
    Private m_originalFileInfo As FileInfo
    Private m_publisher As IPublisher
    Private m_sdpFilePath As String
    Private m_languages As StringCollection

    Public Sub New()
        ' The Me.InitializeComponent call is required for windows forms designer support.
        Me.InitializeComponent()
        Me.btnPrevious.Hide()

        'Set The Defaults.
        Me.DialogResult = DialogResult.Cancel
        Me.tabsUpdate.HideTabs = True
        Me.btnPrevious.Image = My.Resources.previous.ToBitmap
        Me.btnNext.Image = My.Resources.forward.ToBitmap

        'Set the strings for the Rule Editor controls using the resource manager.
        Me.isInstallableRules.Instructions = Globals.globalRM.GetString("IsInstallable_Instructions")
        Me.isInstallableRules.Title = Globals.globalRM.GetString("IsInstallable_Title")
        Me.isInstallableRules.TitleItemLevel = Globals.globalRM.GetString("IsInstallable_TitleItemLevel")

        Me.isInstalledRules.Instructions = Globals.globalRM.GetString("IsInstalled_Instructions")
        Me.isInstalledRules.Title = Globals.globalRM.GetString("IsInstalled_Title")
        Me.isInstalledRules.TitleItemLevel = Globals.globalRM.GetString("IsInstalled_TitleItemLevel")

        'Resize the Reboot Behavior combo based on the options.
        Dim cellWidth As Integer
        For Each cboItem As String In Me.cboRebootBehavior.Items
            If cboItem.Length > cellWidth Then cellWidth = cboItem.Length
        Next
        Me.cboRebootBehavior.Width = 30 + (cellWidth * 5)

        'Resize the Impact combo based on the options.
        cellWidth = 0
        For Each cboItem As String In Me.cboImpact.Items
            If cboItem.Length > cellWidth Then cellWidth = cboItem.Length
        Next
        Me.cboImpact.Width = 30 + (cellWidth * 5)

        'Resize the package info label vertically.		
        Globals.ResizeVertically(lblPackageInfo)

        'The tab control will not auto resize so once initialized, we reset the size of it
        ' to make sure the package info table layout panel will fit.
        Dim tmpSize As Size = Me.tlpPackageInfo.Size
        tmpSize.Height = tmpSize.Height + 5
        Me.tabsUpdate.Size = tmpSize

    End Sub

#Region "Form Methods"

    ''' <summary>
    ''' Create a new package.
    ''' </summary>
    ''' <returns>SoftwareDistributionPackage.</returns>
    Public Overloads Function ShowDialog() As SoftwareDistributionPackage
        Return Me.ShowDialog(Nothing, Nothing)
    End Function

    ''' <summary>
    ''' Create a new package with vendor.
    ''' </summary>
    ''' <param name="vendor">IUpdateCategory of vendor.</param>
    ''' <returns>SoftwareDistributionPackage</returns>
    Public Overloads Function ShowDialog(vendor As IUpdateCategory) As SoftwareDistributionPackage
        Return Me.ShowDialog(vendor, Nothing)
    End Function


    ''' <summary>
    ''' Created new package with vendor and product names.
    ''' </summary>
    ''' <param name="vendor">IUpdateCategory of vendor.</param>
    ''' <param name="product">IUpdateCategory of product.</param>
    ''' <returns>SoftwareDistributionPackage</returns>
    Public Overloads Function ShowDialog(vendor As IUpdateCategory, product As IUpdateCategory) As SoftwareDistributionPackage
        'Clear The Supporting Forms.
        LanguageSelectionForm = Nothing
        SupersededUpdatesForm = Nothing
        PrerequisiteUpdatesForm = Nothing
        ReturnCodesForm = Nothing

        'Set default values.
        Me.m_SDP = New SoftwareDistributionPackage()
        Me.m_revision = False
        Me.m_originalURIChanged = False
        Me.txtMSIPath.Enabled = False
        Me.errorProviderUpdate.SetError(Me.txtUpdateFile, Globals.globalRM.GetString("warning_select_file"))

        'If there is a hidden tab in the temp tab control then load it.
        If m_tabsHidden.Count > 0 Then
            Me.tabsUpdate.TabPages.Insert(0, Me.m_tabsHidden(0))
            m_tabsHidden.RemoveAt(0)
        End If

        'Load the vendor combo box.
        Me.cboVendor.Items.Clear()
        For Each tmpVendor As Vendor In My.Forms.MainForm.VendorCollection
            Me.cboVendor.Items.Add(tmpVendor.Name)
        Next

        'Load the vendor and product if they were passed in.
        If Not vendor Is Nothing Then Me.cboVendor.Text = vendor.Title
        If Not product Is Nothing Then Me.cboProduct.Text = product.Title

        Me.DialogResult = DialogResult.Cancel

        'Return the SDP file.
        If MyBase.ShowDialog() = DialogResult.OK Then
            Return Me.m_SDP
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' Revise existing packages.
    ''' </summary>
    ''' <param name="path">Path to SDP XML file.</param>
    ''' <returns>SoftwareDistributionPackage</returns>
    Public Overloads Function ShowDialog(path As String) As SoftwareDistributionPackage
        'Clear the supporting forms.
        LanguageSelectionForm = Nothing
        SupersededUpdatesForm = Nothing
        PrerequisiteUpdatesForm = Nothing
        ReturnCodesForm = Nothing

        'Load SDP from passed file, set revision boolean, load SDP data, and set the filename.
        Me.m_SDP = New SoftwareDistributionPackage(path)
        Me.m_revision = True
        Me.m_originalURIChanged = False

        'Set the update type based on the type of installable item.
        If TypeOf m_SDP.InstallableItems.Item(0) Is CommandLineItem Then
            m_updateType = LocalUpdateTypes.EXE
            Me.lblReturnCodes.Visible = True
        ElseIf TypeOf m_SDP.InstallableItems.Item(0) Is WindowsInstallerItem Then
            m_updateType = LocalUpdateTypes.MSI
        ElseIf TypeOf m_SDP.InstallableItems.Item(0) Is WindowsInstallerPatchItem Then
            m_updateType = LocalUpdateTypes.MSP
        End If

        'Check to see if this is a metadata-only update.  There is no good way to do this so the current method is to
        ' see if any binary data exists in \\%WSUSSERVER%\UpdateServicesPackages.
        If Directory.Exists("\\" & ConnectionManager.ParentServer.Name & "\UpdateServicesPackages\" & m_SDP.PackageId.ToString) Then
            Me.chkMetadataOnly.Checked = False
        Else
            Me.chkMetadataOnly.Checked = True
        End If

        'Disable the MetaData only flag.
        Me.chkMetadataOnly.Enabled = False

        Call LoadSdpData()

        'We do not need to prompt the user for files so skip the initial tab.
        If m_tabsHidden.Count = 0 Then
            Me.m_tabsHidden.Add(Me.tabsUpdate.TabPages("TabIntro"))
            Me.tabsUpdate.TabPages.RemoveAt(Me.tabIntro.TabIndex)
        End If

        'Load the vendor combo box.
        Me.cboVendor.Items.Clear()
        For Each tmpVendor As Vendor In My.Forms.MainForm.VendorCollection
            Me.cboVendor.Items.Add(tmpVendor.Name)
        Next

        Me.ValidateChildren()

        Me.DialogResult = DialogResult.Cancel

        'Return the SDP file.
        If MyBase.ShowDialog() = DialogResult.OK Then
            Return Me.m_SDP
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' Allow the user to edit the metadata.
    ''' </summary>
    ''' <param name="Sender"></param>
    ''' <param name="E"></param>
    ''' <remarks>This is generally not recommended as it provides direct access to various XML elements.</remarks>
    Sub BtnMetaDataEditClick(Sender As Object, E As EventArgs) Handles btnMetaDataEdit.Click
        MsgBox(Globals.globalRM.GetString("warning_update_manual_edit"))
        txtInstallableItemMetaData.ScrollBars = ScrollBars.Vertical
        txtInstallableItemMetaData.ReadOnly = False
        btnMetaDataEdit.Visible = False
    End Sub

    ''' <summary>
    ''' Alow the user to edit the superseded metadata.
    ''' </summary>
    ''' <param name="Sender"></param>
    ''' <param name="E"></param>
    ''' <remarks>This is generally not recommended as it provides direct access to various XML elements</remarks>
    Sub BtnIsSupersededEditClick(Sender As Object, E As EventArgs) Handles btnIsSupersededEdit.Click
        MsgBox(Globals.globalRM.GetString("warning_update_manual_edit"))
        txtIsSuperceded_InstallableItem.ScrollBars = ScrollBars.Vertical
        txtIsSuperceded_InstallableItem.ReadOnly = False
        btnIsSupersededEdit.Visible = False
    End Sub

    ''' <summary>
    ''' Go to the previous tab and hide buttons accordingly.
    ''' </summary>
    ''' <param name="Sender"></param>
    ''' <param name="E"></param>
    Private Sub BtnPreviousClick(Sender As Object, E As EventArgs) Handles btnPrevious.Click
        Me.tabsUpdate.SelectedIndex = Me.tabsUpdate.SelectedIndex - 1

        Call SetMetadataOnly()

        'Show and hide the previous button as needed.
        If (Me.tabsUpdate.SelectedIndex > 0) Then
            Me.btnPrevious.Show()
        Else
            Me.btnPrevious.Hide()
        End If

        'Change the next button's text as needed.
        If (Me.tabsUpdate.SelectedIndex < Me.tabsUpdate.TabCount) Then
            Me.btnNext.Show()
            Me.btnNext.Text = Globals.globalRM.GetString("next")
            Me.btnNext.Image = My.Resources.forward.ToBitmap
            Me.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Else
            Me.btnNext.Hide()
        End If

        Me.ValidateChildren()
    End Sub

    ''' <summary>
    ''' Go to the next tab and hide buttons accordingly.
    ''' </summary>
    ''' <param name="Sender"></param>
    ''' <param name="E"></param>
    Private Sub BtnNextClick(Sender As Object, E As EventArgs) Handles btnNext.Click
        'Perform action depending on current tab.
        ' If the action could not be performed do not continue.
        If Not PerformAction() Then
            Exit Sub
            'User has selected the finish button so close the form.
        ElseIf Me.tabsUpdate.SelectedIndex = Me.tabsUpdate.TabCount - 1 Then
            Me.btnNext.Enabled = False
            Exit Sub
        End If

        'Move to the next tab.
        Me.tabsUpdate.SelectedIndex = Me.tabsUpdate.SelectedIndex + 1

        Call SetMetadataOnly()

        'Show and hide the previous button as needed.
        If (Me.tabsUpdate.SelectedIndex > 0) Then
            Me.btnPrevious.Show()
        Else
            Me.btnPrevious.Hide()
        End If

        'Change the next button's text as needed.
        If (Me.tabsUpdate.SelectedIndex < Me.tabsUpdate.TabCount - 1) Then
            Me.btnNext.Show()
            Me.btnNext.Text = Globals.globalRM.GetString("next")
        Else
            Me.btnNext.Text = Globals.globalRM.GetString("finish")
            Me.btnNext.Image = Nothing
            Me.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        End If

        Me.ValidateChildren()
    End Sub

    ''' <summary>
    ''' Depending on the current tab, enable or disable the metadata only check box.
    ''' </summary>
    Private Sub SetMetadataOnly()
        If Not Me.m_revision AndAlso (tabsUpdate.SelectedTab.Name = "tabIntro" OrElse tabsUpdate.SelectedTab.Name = "tabPackageInfo") Then
            Me.chkMetadataOnly.Enabled = True
        Else
            Me.chkMetadataOnly.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' If the user cancels, close the form.
    ''' </summary>
    ''' <param name="Sender"></param>
    ''' <param name="E"></param>
    Private Sub BtnCancelClick(Sender As Object, E As EventArgs) Handles btnCancel.Click

        'Delete the temporary SDP file and ignore any errors.
        If Not String.IsNullOrEmpty(m_sdpFilePath) Then
            Try
                System.IO.File.Delete(m_sdpFilePath) 'Delete the SDP file.
            Catch
            End Try
        End If

        Me.Close()
    End Sub

    ''' <summary>
    ''' Prompt the user to select a file, set the textbox and next button accordingly.
    ''' </summary>
    ''' <param name="Sender"></param>
    ''' <param name="E"></param>
    Private Sub BtnUpdateFileClick(Sender As Object, E As EventArgs) Handles btnUpdateFile.Click
        'Set the file filter.
        Me.dlgUpdateFile.Filter = Globals.globalRM.GetString("file_filter_update_binary")

        'Disable the MSI path.
        Me.txtMSIPath.Enabled = False

        'Show file dialog and continue if the user chose a file.
        If Me.dlgUpdateFile.ShowDialog = vbOK Then
            Me.chkMetadataOnly.Enabled = True

            Dim TmpFile As FileInfo = New FileInfo(dlgUpdateFile.FileName)

            Me.txtUpdateFile.Text = TmpFile.Name
            Me.txtUpdateFile.Tag = TmpFile

            'Set the type of update and enable the next button once a file is chosen.
            If TmpFile.Extension.ToLower.Equals(".exe") Then
                Me.m_updateType = LocalUpdateTypes.EXE
            ElseIf TmpFile.Extension.ToLower.Equals(".msi") Then
                Me.m_updateType = LocalUpdateTypes.MSI
                Me.txtMSIPath.Enabled = True
            ElseIf TmpFile.Extension.ToLower.Equals(".msp") Then
                Me.m_updateType = LocalUpdateTypes.MSP
            End If


        Else 'User didn't select a file.
            Me.chkMetadataOnly.Enabled = False
            Me.txtUpdateFile.Text = ""
            Me.txtUpdateFile.Tag = Nothing
        End If

        Me.ValidateChildren()
    End Sub

    ''' <summary>
    ''' Show the return codes dialog.
    ''' </summary>
    ''' <param name="Sender"></param>
    ''' <param name="E"></param>
    Sub LblReturnCodesClick(Sender As Object, E As EventArgs) Handles lblReturnCodes.Click
        ReturnCodesForm.Location = New Point(Me.Location.X + 100, Me.Location.Y + 100)
        ReturnCodesForm.ShowDialog(CType(m_SDP.InstallableItems.Item(0), CommandLineItem).ReturnCodes)
    End Sub

    ''' <summary>
    ''' Manage the list of updates that this update supersedes.
    ''' </summary>
    ''' <param name="Sender"></param>
    ''' <param name="E"></param>
    Sub LblSupersedesClick(Sender As Object, E As EventArgs) Handles lblSupersedes.Click
        SupersededUpdatesForm.Location = New Point(Me.Location.X + 100, Me.Location.Y + 100)
        SupersededUpdatesForm.ShowDialog(m_SDP.SupersededPackages, m_SDP.PackageId)
    End Sub
    ''' <summary>
    ''' Select the languages for this package.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub LblLanguagesClick(sender As Object, e As EventArgs) Handles lblLanguages.Click
        If m_SDP.InstallableItems.Count > 0 Then
            LanguageSelectionForm.Location = New Point(Me.Location.X + 100, Me.Location.Y + 100)

            If Not m_SDP.InstallableItems(0).Languages Is Nothing Then
                m_languages = LanguageSelectionForm.ShowDialog(m_languages)
            Else
                m_languages = LanguageSelectionForm.ShowDialog()
            End If
        End If
    End Sub

    ''' <summary>
    ''' ManagetThe list of updates that this update requires before installing.
    ''' </summary>
    ''' <param name="Sender"></param>
    ''' <param name="E"></param>
    Sub LblPrerequisitesClick(Sender As Object, E As EventArgs) Handles lblPrerequisites.Click
        PrerequisiteUpdatesForm.Location = New Point(Me.Location.X + 100, Me.Location.Y + 100)
        PrerequisiteUpdatesForm.ShowDialog(m_SDP.Prerequisites, m_SDP.PackageId)
    End Sub

    ''' <summary>
    ''' Perform action according to the currently selected tab.
    ''' Return a boolean depending upon the success of the action.
    ''' </summary>
    Function PerformAction() As Boolean

        'Import the file and set the appropriate fields if this isn't a revision.
        Select Case tabsUpdate.SelectedTab.Name
            Case "tabIntro"
                'Don't do anything if this is a revision.
                If Not Me.m_revision Then
                    'Create new Software Distribution Package.
                    m_SDP = New SoftwareDistributionPackage

                    'Populate SDP from installation file based on its type.
                    Try
                        Select Case m_updateType
                            Case LocalUpdateTypes.MSI

                                m_SDP.PopulatePackageFromWindowsInstaller(DirectCast(Me.txtUpdateFile.Tag, FileInfo).FullName)

                                'Create the default IsInstallable and IsInstalled rules for MSI packages.
                                If m_SDP.InstallableItems.Count > 0 Then
                                    Dim TmpGuid As String = CType(m_SDP.InstallableItems.Item(0), WindowsInstallerItem).WindowsInstallerProductCode.ToString
                                    isInstalledRules.Clear()
                                    isInstalledRules.Rules = "<msiar:MsiProductInstalled ProductCode=""{" & TmpGuid & "}"" />"
                                    isInstallableRules.Clear()
                                    isInstallableRules.Rules = "<lar:Not ><msiar:MsiProductInstalled ProductCode=""{" & TmpGuid & "}"" /></lar:Not>"
                                End If

                                'Set the package type to application.
                                m_SDP.PackageType = PackageType.Application

                            Case LocalUpdateTypes.MSP
                                m_SDP.PopulatePackageFromWindowsInstallerPatch(DirectCast(Me.txtUpdateFile.Tag, FileInfo).FullName)

                                'Set the package type to update.
                                m_SDP.PackageType = PackageType.Update
                            Case LocalUpdateTypes.EXE
                                'Use a Wrapped MSI file if a relative MSI path was given.
                                If String.IsNullOrEmpty(Me.txtMSIPath.Text) Then
                                    m_SDP.PopulatePackageFromExe(DirectCast(Me.txtUpdateFile.Tag, FileInfo).FullName)

                                    'Clear the default Installable Item rules created by the API.
                                    'This puts the user in complete control of the EXE logic.
                                    If m_SDP.InstallableItems.Count > 0 Then
                                        m_SDP.InstallableItems.Item(0).IsInstallableApplicabilityRule = Nothing
                                        m_SDP.InstallableItems.Item(0).IsInstalledApplicabilityRule = Nothing
                                    End If
                                Else
                                    m_SDP.PopulatePackageFromExeWrappedMsi(DirectCast(Me.txtUpdateFile.Tag, FileInfo).FullName, New String() { _
                                        Me.txtMSIPath.Text}, New String() {})
                                End If

                                'Set the package type to application.
                                m_SDP.PackageType = PackageType.Application

                                lblReturnCodes.Visible = True
                        End Select

                        Call LoadSdpData() 'Load the SDP data into the form.

                        'If any of the additional files are MST files then setup the transform in the command line automatically.
                        For Each TmpRow As DataGridViewRow In dgvAdditionalFiles.Rows
                            If TypeOf TmpRow.Cells("FileObject").Value Is FileInfo Then

                                If UCase(DirectCast(TmpRow.Cells("FileObject").Value, FileInfo).Extension) = ".MST" Then
                                    txtCommandLine.Text = "TRANSFORMS=""" & DirectCast(TmpRow.Cells("FileObject").Value, FileInfo).Name & """"
                                End If
                            ElseIf TypeOf TmpRow.Cells("FileObject").Value Is DirectoryInfo Then
                                Dim TmpFiles As FileInfo() = DirectCast(TmpRow.Cells("FileObject").Value, DirectoryInfo).GetFiles("*.Mst")
                                If TmpFiles.Length > 0 Then
                                    txtCommandLine.Text = "TRANSFORMS=""" & DirectCast(TmpRow.Cells("FileObject").Value, DirectoryInfo).Name & "\" & TmpFiles(0).Name & """"
                                End If
                            End If
                        Next

                        'Verify the URI to confirm the additional files logic.
                        Call VerifyOriginalURI()

                        'Catch any exception related to the creation of the SDP.
                    Catch X As InvalidOperationException
                        MsgBox(Globals.globalRM.GetString("exception_invalid_operation") & ":" & Globals.globalRM.GetString("error_update_create_SDP") & vbNewLine & X.Message)
                    Catch X As ArgumentNullException
                        MsgBox(Globals.globalRM.GetString("exception_argument_null") & ":" & Globals.globalRM.GetString("error_update_create_SDP") & vbNewLine & X.Message)
                    Catch X As ArgumentException
                        MsgBox(Globals.globalRM.GetString("exception_argument") & ":" & Globals.globalRM.GetString("error_update_create_SDP") & vbNewLine & X.Message)
                    Catch X As FileNotFoundException
                        MsgBox(Globals.globalRM.GetString("exception_file_not_found") & ":" & Globals.globalRM.GetString("error_update_create_SDP") & vbNewLine & X.Message)
                    Catch X As InvalidDataException
                        MsgBox(Globals.globalRM.GetString("exception_invalid_data") & ":" & Globals.globalRM.GetString("error_update_create_SDP") & vbNewLine & X.Message)
                    Catch X As Win32Exception
                        MsgBox(Globals.globalRM.GetString("exception_win32") & ":" & Globals.globalRM.GetString("error_update_create_SDP") & vbNewLine & X.Message)
                    End Try
                End If 'If this is a revision.

            Case "tabPackageInfo"
                Try
                    'Save the info from the form into the SDP object.
                    m_SDP.PackageType = DirectCast(Me.cboPackageType.SelectedIndex, PackageType)
                    m_SDP.Title = Me.txtPackageTitle.Text
                    m_SDP.Description = Me.txtDescription.Text
                    m_SDP.PackageUpdateClassification = DirectCast(Me.cboClassification.SelectedIndex, PackageUpdateClassification)
                    m_SDP.SecurityBulletinId = Me.txtBulletinID.Text

                    'Set the security rating only if a Bulletin ID has been entered.
                    If Not String.IsNullOrEmpty(Me.txtBulletinID.Text) Then
                        m_SDP.SecurityRating = DirectCast(Me.cboSeverity.SelectedIndex, SecurityRating)
                    Else
                        m_SDP.SecurityRating = Nothing
                    End If

                    m_SDP.VendorName = Me.cboVendor.Text

                    'If a product name exists then change it.  Otherwise add a new one to the list.
                    If m_SDP.ProductNames.Count > 0 Then
                        m_SDP.ProductNames(0) = Me.cboProduct.Text
                    Else
                        m_SDP.ProductNames.Add(Me.cboProduct.Text)
                    End If

                    m_SDP.KnowledgebaseArticleId = Me.txtArticleID.Text

                    'Recreate string collection of common vulnerabilities.
                    m_SDP.CommonVulnerabilitiesIds.Clear()
                    If Not String.IsNullOrEmpty(Me.txtCVEID.Text) Then
                        m_SDP.CommonVulnerabilitiesIds.Add(Me.txtCVEID.Text)
                    End If

                    If Not String.IsNullOrEmpty(Me.txtSupportURL.Text) Then m_SDP.SupportUrl = New Uri(Me.txtSupportURL.Text)

                    'If an Additional Info URL exists then change it.  Otherwise add a new one to the list.
                    If m_SDP.AdditionalInformationUrls.Count > 0 And Not String.IsNullOrEmpty(Me.txtMoreInfoURL.Text) Then
                        m_SDP.AdditionalInformationUrls.Item(0) = New Uri(Me.txtMoreInfoURL.Text)
                    ElseIf Not String.IsNullOrEmpty(Me.txtMoreInfoURL.Text) Then
                        m_SDP.AdditionalInformationUrls.Add(New Uri(Me.txtMoreInfoURL.Text))
                    End If

                    'If there is an Installable Item, save its values as well.
                    If m_SDP.InstallableItems.Count > 0 Then
                        'Set the languages
                        m_SDP.InstallableItems.Item(0).Languages.Clear()
                        If Not m_languages Is Nothing AndAlso m_languages.Count > 0 Then
                            For Each tmpLanguage As String In m_languages
                                m_SDP.InstallableItems.Item(0).Languages.Add(tmpLanguage)
                            Next
                        End If

                        With m_SDP.InstallableItems.Item(0).InstallBehavior
                            .Impact = DirectCast(Me.cboImpact.SelectedIndex, InstallationImpact)
                            .RebootBehavior = DirectCast(Me.cboRebootBehavior.SelectedIndex, RebootBehavior)
                            .CanRequestUserInput = Me.chkUserInput.Checked
                            .RequiresNetworkConnectivity = Me.chkNetwork.Checked
                        End With

                        'If there is a command line string then set it based on the update type otherwise set it to null.
                        ' The type of the Installable Items objects depends on the type of file we populated
                        ' the SDP with.  Therefore, we need to cast the Installable Item accordingly
                        ' so that we can add the command line string using the right property name.
                        Select Case m_updateType
                            Case LocalUpdateTypes.EXE
                                If String.IsNullOrEmpty(Me.txtCommandLine.Text) Then
                                    DirectCast(m_SDP.InstallableItems.Item(0), CommandLineItem).Arguments = Nothing
                                Else
                                    DirectCast(m_SDP.InstallableItems.Item(0), CommandLineItem).Arguments = Me.txtCommandLine.Text
                                End If
                            Case LocalUpdateTypes.MSI
                                If String.IsNullOrEmpty(Me.txtCommandLine.Text) Then
                                    DirectCast(m_SDP.InstallableItems.Item(0), WindowsInstallerItem).InstallCommandLine = Nothing
                                Else
                                    DirectCast(m_SDP.InstallableItems.Item(0), WindowsInstallerItem).InstallCommandLine = Me.txtCommandLine.Text
                                End If
                            Case LocalUpdateTypes.MSP
                                If String.IsNullOrEmpty(Me.txtCommandLine.Text) Then
                                    DirectCast(m_SDP.InstallableItems.Item(0), WindowsInstallerPatchItem).InstallCommandLine = Nothing
                                Else
                                    DirectCast(m_SDP.InstallableItems.Item(0), WindowsInstallerPatchItem).InstallCommandLine = Me.txtCommandLine.Text
                                End If
                        End Select

                        'Add the original URI if it is present and this is a new update or we are revising an update and the
                        ' original URI was changed.
                        If Not String.IsNullOrEmpty(Me.txtOriginalURI.Text) AndAlso _
                            (Not Me.m_revision OrElse _
                            Me.m_originalURIChanged AndAlso m_originalFileInfo Is Nothing) Then
                            Dim hashProvider As SHA1CryptoServiceProvider = New SHA1CryptoServiceProvider
                            Dim digest As String
                            Dim inStream As FileStream
                            Dim fileItem As FileForInstallableItem = New FileForInstallableItem

                            'If we are revising the update then download the file.
                            If Me.m_revision Then
                                Dim tmpFilePath As String
                                tmpFilePath = Path.Combine(Path.GetTempPath, Path.GetFileName(Me.txtOriginalURI.Text))

                                'Set cursor and position of progress form.
                                My.Forms.ProgressForm.Location = New Point(My.Forms.MainForm.Location.X + 100, My.Forms.MainForm.Location.Y + 100)
                                My.Forms.ProgressForm.ShowDialog("Downloading files for " & m_SDP.Title, ParentForm)
                                My.Forms.ProgressForm.SetCurrentStep(Me.txtOriginalURI.Text)
                                ConnectionManager.DownloadChunks(New Uri(Me.txtOriginalURI.Text), My.Forms.ProgressForm.progressBar, tmpFilePath)
                                My.Forms.ProgressForm.Dispose()

                                m_originalFileInfo = New FileInfo(tmpFilePath)

                                'If file was not downloaded then delete the file and exit the function.
                                If m_originalFileInfo.Length = 0 Then
                                    m_originalFileInfo.Delete()
                                    m_originalFileInfo = Nothing
                                    Return False
                                End If
                            Else
                                m_originalFileInfo = DirectCast(Me.txtUpdateFile.Tag, FileInfo)
                            End If

                            'Get the SHA1 hash of the file.
                            inStream = m_originalFileInfo.OpenRead()
                            digest = Convert.ToBase64String(hashProvider.ComputeHash(inStream))
                            'Msgbox ( System.BitConverter.ToString(Convert.FromBase64String(digest)))
                            inStream.Close()

                            'Setup the FileForInstallable Item
                            fileItem.FileName = m_originalFileInfo.Name
                            fileItem.OriginUri = New Uri(Me.txtOriginalURI.Text)
                            fileItem.Digest = digest
                            fileItem.Modified = m_originalFileInfo.LastWriteTimeUtc
                            fileItem.Size = m_originalFileInfo.Length

                            'Assign it to the SDP.
                            m_SDP.InstallableItems(0).OriginalSourceFile = fileItem

                            'If we are revising an update delete the temporary file.
                            If Me.m_revision Then
                                Me.m_originalURIChanged = False
                                Try
                                    m_originalFileInfo.Delete()
                                Catch
                                End Try
                            End If
                        ElseIf String.IsNullOrEmpty(Me.txtOriginalURI.Text) Then
                            m_SDP.InstallableItems(0).OriginalSourceFile = Nothing
                        End If

                    End If 'There is at least one Installable Item object.

                Catch X As UriFormatException
                    My.Forms.ProgressForm.Dispose()
                    MsgBox(Globals.globalRM.GetString("exception_URI_format") & ":" & Globals.globalRM.GetString("error_update_save") & vbNewLine & X.Message)
                    Return False
                Catch X As Exception
                    My.Forms.ProgressForm.Dispose()
                    MsgBox(Globals.globalRM.GetString("exception") & ":" & Globals.globalRM.GetString("error_update_save") & vbNewLine & X.Message)
                    Return False
                End Try
            Case "tabIsInstalled"
                'If there are rules then add them to the IsInstallable property.
                If Not String.IsNullOrEmpty(isInstalledRules.Rules) Then
                    m_SDP.IsInstalled = isInstalledRules.Rules
                Else
                    m_SDP.IsInstalled = Nothing
                End If

                'If the user has edited the Installable Item level XML then save their changes.
                If isInstalledRules.ApplicabilityRuleEdited Then
                    If Not String.IsNullOrEmpty(isInstalledRules.ApplicabilityRule) Then
                        m_SDP.InstallableItems(0).IsInstalledApplicabilityRule = isInstalledRules.ApplicabilityRule
                    Else
                        m_SDP.InstallableItems(0).IsInstalledApplicabilityRule = Nothing
                    End If
                End If
            Case "tabIsInstallable"
                'If there are rules then add them to the IsInstallable property.
                If Not String.IsNullOrEmpty(isInstallableRules.Rules) Then
                    m_SDP.IsInstallable = isInstallableRules.Rules
                Else
                    m_SDP.IsInstallable = Nothing
                End If

                'If the user has edited the Installable Item level XML then save their changes.
                If isInstallableRules.ApplicabilityRuleEdited Then
                    If Not String.IsNullOrEmpty(isInstallableRules.ApplicabilityRule) Then
                        m_SDP.InstallableItems(0).IsInstallableApplicabilityRule = isInstallableRules.ApplicabilityRule
                    Else
                        m_SDP.InstallableItems(0).IsInstallableApplicabilityRule = Nothing
                    End If
                End If
            Case "tabIsSuperseded"
                'If the user has edited the Installable Item level XML then save their changes.
                If Not txtIsSuperceded_InstallableItem.ReadOnly Then
                    If Not String.IsNullOrEmpty(txtIsSuperceded_InstallableItem.Text) Then
                        m_SDP.InstallableItems(0).IsSupersededApplicabilityRule = txtIsSuperceded_InstallableItem.Text
                    Else
                        m_SDP.InstallableItems(0).IsSupersededApplicabilityRule = Nothing
                    End If
                End If
            Case "tabMetaData"
                'If the user has edited the metadata then save their changes.
                If Not txtInstallableItemMetaData.ReadOnly Then
                    If Not String.IsNullOrEmpty(txtInstallableItemMetaData.Text) Then
                        m_SDP.InstallableItems(0).ApplicabilityMetadata = txtInstallableItemMetaData.Text
                    Else
                        m_SDP.InstallableItems(0).ApplicabilityMetadata = Nothing
                    End If
                End If

                'Save the SDP file and then load it into the summary field.
                Try
                    m_sdpFilePath = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), m_SDP.PackageId.ToString() & ".Xml")
                    m_SDP.Save(m_sdpFilePath)
                    Dim Sr As New IO.StreamReader(m_sdpFilePath)
                    Me.txtSummary.Text = Sr.ReadToEnd()
                    Sr.Close()
                    Me.txtSummary.Text = IndentXmlString(Me.txtSummary.Text)
                    Me.txtSummary.DeselectAll()
                Catch X As XmlException
                    MsgBox(Globals.globalRM.GetString("exception_XML") & ": " & Globals.globalRM.GetString("error_update_invalid_XML") & vbNewLine & X.Message)
                    Return False
                Catch X As XmlSchemaException
                    MsgBox(Globals.globalRM.GetString("exception_XML_schema") & ": " & Globals.globalRM.GetString("error_update_invalid_XML") & vbNewLine & X.Message)
                    Return False
                End Try


            Case "tabSummary" 'Publish the package and catch any errors.


                'If the user wants to export the SDP then prompt for a filename.
                If chkExportSdp.Checked Then
                    'Set default extension.
                    dlgExportSdp.Filter = Globals.globalRM.GetString("file_filter_xml")
                    dlgExportSdp.DefaultExt = ".XML"
                    dlgExportSdp.AddExtension = True
                    dlgExportSdp.FileName = m_SDP.Title & ".Xml"

                    'Show dialog and copy the file.
                    If dlgExportSdp.ShowDialog = vbOK Then
                        MsgBox(m_sdpFilePath)
                        My.Computer.FileSystem.CopyFile(m_sdpFilePath, dlgExportSdp.FileName, True)
                    End If
                End If

                If m_revision Then 'This is a revision.
                    Me.Cursor = Cursors.WaitCursor

                    'Add the handler for when the publisher finishes.
                    AddHandler AsyncPublisher.Completed, AddressOf Me.RevisionResults

                    'Revise the package asyncronously.
                    Call AsyncPublisher.RevisePackage(m_SDP, Me, chkMetadataOnly.Checked)

                    Return True

                Else 'This is a new update.

                    'Add the files to a new iList.
                    Dim FileList As IList(Of Object) = New List(Of Object)
                    FileList.Add(txtUpdateFile.Tag) ' Add main update file.

                    'Add additional files and directories.
                    For Each TmpRow As DataGridViewRow In dgvAdditionalFiles.Rows
                        FileList.Add(TmpRow.Cells("FileObject").Value)
                    Next

                    'Add the handler for when the publisher finishes.
                    AddHandler AsyncPublisher.Completed, AddressOf Me.PublishingResults

                    'Publish package asycronously according to the metadata only checkbox.
                    If chkMetadataOnly.Checked Then
                        Call AsyncPublisher.PublishPackageMetaData(m_SDP, Me)
                    Else
                        Call AsyncPublisher.PublishPackage(m_SDP, FileList, Me)
                    End If

                    Return True
                End If

        End Select

        Return True 'If we got this far we succeeded.
    End Function 'PerformAction

    ''' <summary>
    ''' When the asyncronous publishing call completes this will run.
    ''' </summary>
    ''' <param name="result">Boolean indicating publishing result.</param>
    Sub PublishingResults(result As Boolean)
        If result Then
            MsgBox(Globals.globalRM.GetString("warning_update_publish_success"))
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MsgBox(Globals.globalRM.GetString("warning_update_publish_failed"))
            Me.DialogResult = DialogResult.Cancel
            Me.btnNext.Enabled = True
        End If

        'Remove the handler.
        RemoveHandler AsyncPublisher.Completed, AddressOf Me.PublishingResults
    End Sub

    ''' <summary>
    ''' When the asyncronous revision call completes this will run.
    ''' </summary>
    ''' <param name="result">Boolean indicating revision results.</param>
    Sub RevisionResults(result As Boolean)
        If result Then
            MsgBox(Globals.globalRM.GetString("warning_update_revise_success"))
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MsgBox(Globals.globalRM.GetString("warning_update_revised_failed"))
            Me.DialogResult = DialogResult.Cancel
            Me.btnNext.Enabled = True
        End If

        'Remove the handler.
        RemoveHandler AsyncPublisher.Completed, AddressOf Me.RevisionResults
    End Sub

    ''' <summary>
    ''' This routine loads the SDP passed into the form and
    ''' loads the form with the appropriate data.  This is the first
    ''' step in revising an existing update.
    ''' </summary>
    Sub LoadSdpData()

        If Not m_SDP Is Nothing Then 'Make sure the SDP object is instantiated.

            'Load the basic info into the form.
            Me.cboPackageType.SelectedIndex = DirectCast(m_SDP.PackageType, Integer)
            If Not String.IsNullOrEmpty(m_SDP.Title) Then Me.txtPackageTitle.Text = m_SDP.Title
            If Not String.IsNullOrEmpty(m_SDP.Description) Then Me.txtDescription.Text = m_SDP.Description
            Me.cboClassification.SelectedIndex = m_SDP.PackageUpdateClassification
            If Not String.IsNullOrEmpty(m_SDP.SecurityBulletinId) Then Me.txtBulletinID.Text = m_SDP.SecurityBulletinId
            Me.cboSeverity.SelectedIndex = m_SDP.SecurityRating
            If String.IsNullOrEmpty(Me.cboVendor.Text) AndAlso Not String.IsNullOrEmpty(m_SDP.VendorName) Then Me.cboVendor.Text = m_SDP.VendorName
            If String.IsNullOrEmpty(Me.cboProduct.Text) AndAlso m_SDP.ProductNames.Count > 0 Then Me.cboProduct.Text = m_SDP.ProductNames(0)
            If Not String.IsNullOrEmpty(m_SDP.KnowledgebaseArticleId) Then Me.txtArticleID.Text = m_SDP.KnowledgebaseArticleId
            If m_SDP.CommonVulnerabilitiesIds.Count > 0 Then Me.txtCVEID.Text = m_SDP.CommonVulnerabilitiesIds.Item(0)
            If Not m_SDP.SupportUrl Is Nothing Then Me.txtSupportURL.Text = m_SDP.SupportUrl.ToString
            If m_SDP.AdditionalInformationUrls.Count > 0 Then Me.txtMoreInfoURL.Text = m_SDP.AdditionalInformationUrls.Item(0).ToString

            'Load the Installable Item info
            If m_SDP.InstallableItems.Count > 0 Then 'There is an Installable Item.
                With m_SDP.InstallableItems.Item(0)
                    m_languages = .Languages

                    If .UninstallBehavior Is Nothing Then
                        Me.txtUninstall.Text = Globals.globalRM.GetString("false")
                    Else
                        Me.txtUninstall.Text = Globals.globalRM.GetString("true")
                    End If

                    With .InstallBehavior
                        Me.cboImpact.SelectedIndex = .Impact
                        Me.cboRebootBehavior.SelectedIndex = .RebootBehavior
                        Me.chkNetwork.Checked = .RequiresNetworkConnectivity
                        Me.chkUserInput.Checked = .CanRequestUserInput
                    End With

                    'Set the command line based on the update type.
                    Select Case m_updateType
                        Case LocalUpdateTypes.EXE
                            Me.txtCommandLine.Text = CType(m_SDP.InstallableItems.Item(0), CommandLineItem).Arguments
                        Case LocalUpdateTypes.MSI
                            Me.txtCommandLine.Text = CType(m_SDP.InstallableItems.Item(0), WindowsInstallerItem).InstallCommandLine
                        Case LocalUpdateTypes.MSP
                            Me.txtCommandLine.Text = CType(m_SDP.InstallableItems.Item(0), WindowsInstallerPatchItem).InstallCommandLine
                    End Select

                    'Load the Installable Item level applicability rules.
                    Me.isInstalledRules.ApplicabilityRule = .IsInstalledApplicabilityRule
                    Me.isInstallableRules.ApplicabilityRule = .IsInstallableApplicabilityRule
                    Me.txtIsSuperceded_InstallableItem.Text = .IsSupersededApplicabilityRule
                    Me.txtInstallableItemMetaData.Text = .ApplicabilityMetadata

                    'Load the Original URI
                    If Not .OriginalSourceFile Is Nothing AndAlso _
                        Not .OriginalSourceFile.OriginUri Is Nothing Then
                        Me.txtOriginalURI.Text = .OriginalSourceFile.OriginUri.ToString
                    End If
                End With
            End If 'There is a Installable Item.

            'Note: In previous versions of LUP we didn't check to see if the IsInstalled or
            ' IsInstallable members were empty and the SDP was set with these members instantiated
            ' to an empty string.  If we detect these when loading then set the member to nothing.

            'Load the package's IsInstalled rules.
            If Not String.IsNullOrEmpty(m_SDP.IsInstalled) Then
                isInstalledRules.Rules = m_SDP.IsInstalled
            Else
                m_SDP.IsInstalled = Nothing
            End If

            'Load the package's IsInstallable rules.
            If Not String.IsNullOrEmpty(m_SDP.IsInstallable) Then
                isInstallableRules.Rules = m_SDP.IsInstallable
            Else
                m_SDP.IsInstallable = Nothing
            End If

        End If 'SDP is not instantiated.
    End Sub 'LoadSDPData.

    ''' <summary>
    ''' This function formats the SDP XML into something more
    ''' readable by indenting the lines appropriately.
    ''' </summary>
    ''' <param name="Xml">XML fragment to to format.</param>
    ''' <returns>It's directly based off of Les Smith's example found here:
    ''' http://www.knowdotnet.com/articles/indentxml.html</returns>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")> _
    Shared Function IndentXmlString(Xml As String) As String

        Dim Ms As MemoryStream = New MemoryStream()
        ' Create a XML text writer that will send its output to a memory stream (file).
        Dim Xtw As XmlTextWriter = New XmlTextWriter(Ms, Encoding.Unicode)
        Dim Doc As XmlDocument = New XmlDocument()

        Try

            ' Load the unformatted XML text string into an instance
            ' of the XML document object model (DOM).
            Doc.LoadXml(Xml)

            ' Set the formatting property of the XML text writer to indented.
            ' The text writer is where the indenting will be performed.
            Xtw.Formatting = Formatting.Indented

            ' Write DOM XML to the XML text writer.
            Doc.WriteContentTo(Xtw)

            ' Flush the contents of the text writer to the memory stream (file).
            Xtw.Flush()

            ' Set to start of the memory stream (file).
            Ms.Seek(0, SeekOrigin.Begin)
            ' Create a reader to read the content of the memory stream (file).
            Dim Sr As StreamReader = New StreamReader(Ms)
            ' Return the sormatted string to caller.
            Return Sr.ReadToEnd()

        Catch X As OutOfMemoryException
            MessageBox.Show(Globals.globalRM.GetString("exception_out_of_memory") & ": " & vbNewLine & X.Message)
        Catch X As IOException
            MessageBox.Show(Globals.globalRM.GetString("exception_IO") & ": " & vbNewLine & X.Message)
        Catch X As ArgumentOutOfRangeException
            MessageBox.Show(Globals.globalRM.GetString("exception_argument_out_of_range") & ": " & vbNewLine & X.Message)
        Catch X As ArgumentNullException
            MessageBox.Show(Globals.globalRM.GetString("exception_argument_null") & ": " & vbNewLine & X.Message)
        Catch X As ArgumentException
            MessageBox.Show(Globals.globalRM.GetString("exception_argument") & ": " & vbNewLine & X.Message)
        Catch X As ObjectDisposedException
            MessageBox.Show(Globals.globalRM.GetString("exception_object_disposed") & ": " & vbNewLine & X.Message)
        Catch X As XmlException
            MessageBox.Show(Globals.globalRM.GetString("exception_XML") & ": " & vbNewLine & X.Message)
        End Try
        Return String.Empty 'If we got here there was an exception.
    End Function

    ''' <summary>
    ''' Prompt the user for files and add them to the collection.
    ''' </summary>
    ''' <param name="Sender"></param>
    ''' <param name="E"></param>
    Private Sub BtnAddFilesClick(Sender As Object, E As EventArgs) Handles btnAddFiles.Click

        'Set dialog values.
        Me.dlgUpdateFile.Filter = ""
        Me.dlgUpdateFile.Multiselect = True

        'Show dialog and load the file into the DGV if the user chose a file.
        If Me.dlgUpdateFile.ShowDialog(Me) = vbOK Then

            'Loop through the selected files and add them.
            For Each tmpFile As String In Me.dlgUpdateFile.FileNames
                Call DgvAdditionalFileAddFile(tmpFile)
            Next
        End If
    End Sub

    ''' <summary>
    ''' Prompt the user for a directory and add it to the collection.
    ''' </summary>
    ''' <param name="Sender"></param>
    ''' <param name="E"></param>
    Sub BtnAddDirClick(Sender As Object, E As EventArgs) Handles btnAddDir.Click
        If dlgUpdateDir.ShowDialog(Me) = vbOK Then
            Call DgvAdditionalFileAddDirectory(dlgUpdateDir.SelectedPath)
        End If
    End Sub

    ''' <summary>
    ''' Give the user feedback when hovering items over the data grid view.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub DgvAdditionalFilesDragEnter(sender As Object, e As DragEventArgs) Handles dgvAdditionalFiles.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

    ''' <summary>
    ''' Allow the user to drop files and folders onto the data grid view.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub DgvAdditionalFilesDragDrop(sender As Object, e As DragEventArgs) Handles dgvAdditionalFiles.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            For Each tmpPath As String In DirectCast(e.Data.GetData(DataFormats.FileDrop), String())
                If System.IO.Directory.Exists(tmpPath) Then
                    Call DgvAdditionalFileAddDirectory(tmpPath)
                ElseIf System.IO.File.Exists(tmpPath) Then
                    Call DgvAdditionalFileAddFile(tmpPath)
                Else
                    'Do nothing if this is neither a file nor a drecotry.
                End If
            Next
        End If
    End Sub

    ''' <summary>
    ''' Add the file to the additional files data grid view.
    ''' </summary>
    ''' <param name="path">Path to file to add.</param>
    Sub DgvAdditionalFileAddFile(path As String)
        Dim tmpFile As FileInfo
        Dim tmpRow As Integer

        If System.IO.File.Exists(path) Then
            tmpFile = New FileInfo(path)
            tmpRow = dgvAdditionalFiles.Rows.Add(New String() {tmpFile.Name})
            Me.dgvAdditionalFiles.Rows.Item(tmpRow).Cells("FileObject").Value = tmpFile
        End If
    End Sub

    ''' <summary>
    ''' Add the directory to the additional files data grid view.
    ''' </summary>
    ''' <param name="dirPath">Path to directory.</param>
    Sub DgvAdditionalFileAddDirectory(path As String)
        Dim tmpDir As DirectoryInfo
        Dim tmpRow As Integer

        If System.IO.Directory.Exists(path) Then
            tmpDir = New DirectoryInfo(path)
            tmpRow = dgvAdditionalFiles.Rows.Add(New String() {tmpDir.Name & " (Dir)"})
            dgvAdditionalFiles.Rows.Item(tmpRow).Cells("FileObject").Value = tmpDir
        End If
    End Sub

    ''' <summary>
    ''' Remove the file from the files DGV.
    ''' </summary>
    ''' <param name="Sender"></param>
    ''' <param name="E"></param>
    Private Sub DgvAdditionalFilesCellContentClick(Sender As Object, E As DataGridViewCellEventArgs) Handles dgvAdditionalFiles.CellContentClick
        If Me.dgvAdditionalFiles.Columns(E.ColumnIndex).Name = "RemoveFile" Then
            Me.dgvAdditionalFiles.Rows.RemoveAt(E.RowIndex)
        End If
    End Sub

    Shadows Sub TextChanged(sender As Object, e As EventArgs) Handles lblSummary.TextChanged, lblMetaData.TextChanged, lblIsSuperseded.TextChanged, lblInfo.TextChanged
        Globals.ResizeVertically(sender)
    End Sub

#End Region

#Region "Validation"
    ''' <summary>
    ''' If we publish a metadata update only then the user must give an original URL and
    ''' the update cannot contain additional files.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub CboMetadataOnlyCheckedChanged(sender As Object, e As EventArgs) Handles chkMetadataOnly.CheckedChanged
        If chkMetadataOnly.Checked Then

            'Prevent user from selecting metadata only if they have additional files.
            If Me.dgvAdditionalFiles.Rows.Count > 0 Then
                MsgBox(Globals.globalRM.GetString("warning_update_metadata_additional_files"))
                chkMetadataOnly.Checked = False
                Exit Sub
            End If

            Me.btnAddFiles.Enabled = False
            Me.btnAddDir.Enabled = False
            Me.dgvAdditionalFiles.Enabled = False

            'Add the filename to the OriginalURI textbox and set the error handler.
            If String.IsNullOrEmpty(Me.txtOriginalURI.Text) AndAlso Not Me.txtUpdateFile.Tag Is Nothing Then
                Me.txtOriginalURI.Text = DirectCast(Me.txtUpdateFile.Tag, FileInfo).Name
            End If
        Else
            Me.btnAddFiles.Enabled = True
            Me.btnAddDir.Enabled = True
            Me.dgvAdditionalFiles.Enabled = True

            'If the only thing in the original URI is the name of the file then clear it.
            If Me.txtOriginalURI.Text = DirectCast(Me.txtUpdateFile.Tag, FileInfo).Name Then
                Me.txtOriginalURI.Text = ""
            End If
        End If

        Me.ValidateChildren()
    End Sub

    ''' <summary>
    ''' Call the verify original URI routine.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub txtOriginalURITextChanged(sender As Object, e As EventArgs) Handles txtOriginalURI.TextChanged
        Call VerifyOriginalURI()
    End Sub

    ''' <summary>
    ''' Handle non-alphanumeric keypresses.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub TxtOriginalURIKeyDown(sender As Object, e As KeyEventArgs) Handles txtOriginalURI.KeyDown
        If Me.m_revision AndAlso Not Me.m_originalURIChanged AndAlso e.KeyCode = Keys.Delete Then
            e.Handled = TxtOriginalURIVerifyKey()
        End If
    End Sub

    'Handle alpha-numeric keypresses
    Sub TxtOriginalURIKeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOriginalURI.KeyPress
        'If we're revising the update then any change to the URI will result in downloading it for verification.
        If e.KeyChar = ChrW(1) Then
            Me.txtOriginalURI.SelectAll()
        ElseIf Me.m_revision AndAlso Not Me.m_originalURIChanged AndAlso Not e.KeyChar = ChrW(3) Then
            e.Handled = TxtOriginalURIVerifyKey()
        Else
            e.Handled = False
        End If

    End Sub
    ''' <summary>
    ''' Verify the URI for the original download file.
    ''' </summary>
    ''' <returns>Boolean indicating validity of URI.</returns>
    Function TxtOriginalURIVerifyKey() As Boolean
        If MsgBox(Globals.globalRM.GetString("prompt_update_redownload"), MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Me.m_originalURIChanged = True
            Me.m_originalFileInfo = Nothing
            Return False
        Else
            Return True
        End If
    End Function

    ''' <summary>
    ''' Validate that the source URL is valid and points to the selected file.
    ''' </summary>
    Sub VerifyOriginalURI()
        If String.IsNullOrEmpty(Me.txtOriginalURI.Text) Then
            If Me.chkMetadataOnly.Checked Then
                Me.errorProviderUpdate.SetError(Me.txtOriginalURI, Globals.globalRM.GetString("warning_update_no_uri"))
            Else
                Me.errorProviderUpdate.SetError(Me.txtOriginalURI, "")
            End If
        ElseIf Not Me.m_revision AndAlso Me.dgvAdditionalFiles.Rows.Count > 0 Then
            Me.errorProviderUpdate.SetError(Me.txtOriginalURI, Globals.globalRM.GetString("warning_update_additional_files_uri"))
        ElseIf Not Uri.IsWellFormedUriString(Me.txtOriginalURI.Text, UriKind.Absolute) Then
            Me.errorProviderUpdate.SetError(Me.txtOriginalURI, Globals.globalRM.GetString("warning_update_invalid_URI"))
        ElseIf Not Me.m_revision AndAlso Not Me.txtOriginalURI.Text.Contains(DirectCast(Me.txtUpdateFile.Tag, FileInfo).Name) Then
            Me.errorProviderUpdate.SetError(Me.txtOriginalURI, Globals.globalRM.GetString("warning_update_file_mismatch"))
        Else
            Me.errorProviderUpdate.SetError(Me.txtOriginalURI, "")
        End If

        Me.ValidateChildren()
    End Sub

    ''' <summary>
    ''' Validate that a URI is valid.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub txtURITextChanged(sender As Object, e As EventArgs) Handles txtSupportURL.TextChanged, txtMoreInfoURL.TextChanged
        Dim tmpTextBox As TextBox
        If TypeOf sender Is TextBox Then
            tmpTextBox = DirectCast(sender, TextBox)
            If Not String.IsNullOrEmpty(tmpTextBox.Text) AndAlso Not Uri.IsWellFormedUriString(tmpTextBox.Text, UriKind.Absolute) Then
                Me.errorProviderUpdate.SetError(tmpTextBox, Globals.globalRM.GetString("warning_update_invalid_URI."))
            Else
                Me.errorProviderUpdate.SetError(tmpTextBox, "")
            End If
        End If

        Me.ValidateChildren()
    End Sub

    ''' <summary>
    ''' Populate the Product combo box.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub CboVendorSelectedIndexChanged(sender As Object, e As EventArgs) Handles cboVendor.SelectedIndexChanged
        Me.cboProduct.Items.Clear()
        'Load the products combo with the selected vendor.
        If My.Forms.MainForm.VendorCollection.Contains(Me.cboVendor.Text) Then
            For Each tmpProduct As String In My.Forms.MainForm.VendorCollection(Me.cboVendor.Text).Products
                Me.cboProduct.Items.Add(tmpProduct)
            Next
        End If

        'Now validate the combo.
        ValidateCombo(sender, e)
    End Sub


    ''' <summary>
    ''' Enable and Disable the appropriate details based on the package type.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub CboPackageTypeSelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPackageType.SelectedIndexChanged
        If DirectCast(Me.cboPackageType.SelectedIndex, PackageType) = PackageType.Application Then
            Me.cboClassification.Enabled = False
            Me.txtBulletinID.Enabled = False
            Me.txtArticleID.Enabled = False
            Me.txtCVEID.Enabled = False
        Else
            Me.cboClassification.Enabled = True
            Me.txtBulletinID.Enabled = True
            Me.txtArticleID.Enabled = True
            Me.txtCVEID.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' A generic validated routine that clears the validation errors
    ''' </summary>
    ''' <param name="Sender"></param>
    ''' <param name="E"></param>
    Sub ControlValidated(Sender As Object, E As EventArgs) Handles txtUpdateFile.Validated, txtPackageTitle.Validated, txtDescription.Validated, cboVendor.Validated, cboSeverity.Validated, cboRebootBehavior.Validated, cboProduct.Validated, cboImpact.Validated, cboClassification.Validated
        Me.errorProviderUpdate.SetError(DirectCast(Sender, Control), "")
    End Sub

    ''' <summary>
    ''' A generic validating routine that verifies the sender control isn't empty.
    ''' </summary>
    ''' <param name="Sender"></param>
    ''' <param name="E"></param>
    Sub ControlValidating(Sender As Object, E As CancelEventArgs) Handles txtUpdateFile.Validating, txtPackageTitle.Validating, txtDescription.Validating, lblBullitinID.Validating, cboVendor.Validating, cboSeverity.Validating, cboRebootBehavior.Validating, cboProduct.Validating, cboImpact.Validating, cboClassification.Validating
        Try
            If TypeOf Sender Is TextBox OrElse TypeOf Sender Is ComboBox Then

                If DirectCast(Sender, Control).Text.Length = 0 Then
                    Me.errorProviderUpdate.SetError(DirectCast(Sender, Control), Globals.globalRM.GetString("warning_no_value"))
                    E.Cancel = True
                End If

                Call ValidateTabControl() 'Validate the current tab.
            End If
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Validate the current tab and enable or disable the next buttons accordingly.
    ''' </summary>
    Sub ValidateTabControl()
        Try

            Dim Invalid As Boolean = False

            Select Case tabsUpdate.SelectedTab.Name
                'Verify a file has been selected.
                Case "tabIntro"
                    If Not String.IsNullOrEmpty(Me.errorProviderUpdate.GetError(Me.txtUpdateFile)) Then
                        Invalid = True
                    End If

                    'Verify that a vendor and product name have been given.
                Case "tabPackageInfo"

                    'Verify that no errors are shown.
                    If Not String.IsNullOrEmpty(Me.errorProviderUpdate.GetError(Me.txtPackageTitle)) OrElse _
                        Not String.IsNullOrEmpty(Me.errorProviderUpdate.GetError(Me.txtDescription)) OrElse _
                        Not String.IsNullOrEmpty(Me.errorProviderUpdate.GetError(Me.cboClassification)) OrElse _
                        Not String.IsNullOrEmpty(Me.errorProviderUpdate.GetError(Me.cboVendor)) OrElse _
                        Not String.IsNullOrEmpty(Me.errorProviderUpdate.GetError(Me.cboProduct)) OrElse _
                        Not String.IsNullOrEmpty(Me.errorProviderUpdate.GetError(Me.cboImpact)) OrElse _
                        Not String.IsNullOrEmpty(Me.errorProviderUpdate.GetError(Me.cboRebootBehavior)) OrElse _
                        Not String.IsNullOrEmpty(Me.errorProviderUpdate.GetError(Me.txtOriginalURI)) OrElse _
                        Not String.IsNullOrEmpty(Me.errorProviderUpdate.GetError(Me.txtSupportURL)) OrElse _
                        Not String.IsNullOrEmpty(Me.errorProviderUpdate.GetError(Me.txtMoreInfoURL)) Then
                        Invalid = True
                    End If

                Case "tabIsInstalled"
                Case "tabIsInstallable"
                Case "tabIsSuperceded"
                Case "tabMetaData"
                Case "tabSummary"
            End Select

            'If a problem was found then exit and disable the next button.
            If Invalid Then
                Me.btnNext.Enabled = False
            Else
                Me.btnNext.Enabled = True
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Enable and validate the severity combo only if something is entered for the bulletin ID.
    ''' </summary>
    ''' <param name="Sender"></param>
    ''' <param name="E"></param>
    Sub TxtBulletinIDValidating(Sender As Object, E As CancelEventArgs) Handles txtBulletinID.Validating
        If txtBulletinID.Text.Length = 0 Then
            Me.cboSeverity.Enabled = False
        Else
            Me.cboSeverity.Enabled = True
            Me.errorProviderUpdate.SetError(Me.cboSeverity, "")
        End If
    End Sub

    ''' <summary>
    ''' Validate the form based on combobox actions.
    ''' </summary>
    ''' <param name="Sender"></param>
    ''' <param name="E"></param>
    Sub ValidateCombo(Sender As Object, E As EventArgs) Handles cboVendor.TextChanged, cboSeverity.SelectedIndexChanged, cboRebootBehavior.SelectedValueChanged, cboProduct.TextChanged, cboProduct.SelectedIndexChanged, cboImpact.SelectedValueChanged, cboClassification.SelectedIndexChanged
        Try
            If TypeOf Sender Is ComboBox Then
                Me.Validate()
            End If
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
    End Sub

#End Region


End Class