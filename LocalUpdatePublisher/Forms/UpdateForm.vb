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

Public Partial Class UpdateForm
	
	Private _Sdp As SoftwareDistributionPackage
	Private _TabsHidden As New List(Of TabPage)
	Private _UpdateType As LocalUpdateTypes
	Private _Revision As Boolean
	Private _OriginalURIChanged As Boolean
	Private _OriginalFileInfo As FileInfo
	Private _Publisher As IPublisher
	Private _SdpFilePath As String
	Private _Languages As StringCollection
	
	Public Sub New()
		' The Me.InitializeComponent call is required for windows forms designer support.
		Me.InitializeComponent()
		Me.BtnPrevious.Hide
		
		'Set The Defaults.
		Me.DialogResult = DialogResult.Cancel
		Me.TabsUpdate.HideTabs = True
		Me.BtnPrevious.Image = My.Resources.Previous.ToBitmap
		Me.BtnNext.Image = My.Resources.Forward.ToBitmap
		
		'Set the strings for the Rule Editor controls using the resource manager.
		Me.isInstallableRules.Instructions = globalRM.GetString("IsInstallable_Instructions")
		Me.isInstallableRules.Title = globalRM.GetString("IsInstallable_Title")
		Me.isInstallableRules.TitleItemLevel = globalRM.GetString("IsInstallable_TitleItemLevel")
		
		Me.isInstalledRules.Instructions = globalRM.GetString("IsInstalled_Instructions")
		Me.isInstalledRules.Title = globalRM.GetString("IsInstalled_Title")
		Me.isInstalledRules.TitleItemLevel = globalRM.GetString("IsInstalled_TitleItemLevel")
	End Sub
	
	#Region "Form Methods"
	
	'Call without either a vendor or product
	Public Overloads Function ShowDialog() As SoftwareDistributionPackage
		Return Me.ShowDialog( Nothing , Nothing )
	End Function
	
	'Call with just a vendor.
	Public Overloads Function ShowDialog(vendor As IUpdateCategory) As SoftwareDistributionPackage
		Return Me.ShowDialog ( vendor , Nothing )
	End Function
	
	
	'Create a new SDP.
	Public Overloads Function ShowDialog(vendor As IUpdateCategory, product As IUpdateCategory) As SoftwareDistributionPackage
		'Clear The Supporting Forms.
		LanguageSelectionForm = Nothing
		SupersededUpdatesForm = Nothing
		PrerequisiteUpdatesForm = Nothing
		ReturnCodesForm = Nothing
		
		'Set default values.
		Me._Sdp = New SoftwareDistributionPackage()
		Me._Revision = False
		Me._OriginalURIChanged = False
		Me.TxtMSIPath.Enabled = False
		Me.ErrorProviderUpdate.SetError(Me.TxtUpdateFile, globalRM.GetString("warning_select_file"))
		
		'If there is a hidden tab in the temp tab control then load it.
		If _TabsHidden.Count > 0 Then
			Me.TabsUpdate.TabPages.Insert(0, Me._TabsHidden(0))
			_TabsHidden.RemoveAt(0)
		End If
		
		'Load the vendor combo box.
		Me.CboVendor.Items.Clear
		For Each tmpVendor As Vendor In My.Forms.MainForm.VendorCollection
			Me.cboVendor.Items.Add(tmpVendor.Name)
		Next
		
		'Load the vendor and product if they were passed in.
		If Not vendor Is Nothing Then Me.cboVendor.Text = vendor.Title
		If Not product Is Nothing Then Me.cboProduct.Text = product.Title
		
		Me.DialogResult = DialogResult.Cancel
		
		'Return the SDP file.
		If MyBase.ShowDialog() = DialogResult.OK Then
			Return Me._Sdp
		Else
			Return Nothing
		End If
	End Function
	
	'Revise and existing SDP.
	Public Overloads Function ShowDialog(PackageFile As String ) As SoftwareDistributionPackage
		'Clear the supporting forms.
		LanguageSelectionForm = Nothing
		SupersededUpdatesForm = Nothing
		PrerequisiteUpdatesForm = Nothing
		ReturnCodesForm = Nothing
		
		'Load SDP from passed file, set revision boolean, load SDP data, and set the filename.
		Me._Sdp = New SoftwareDistributionPackage(PackageFile)
		Me._Revision = True
		Me._OriginalURIChanged = False
		
		'Set the update type based on the type of installable item.
		If TypeOf _Sdp.InstallableItems.Item(0) Is CommandLineItem Then
			_UpdateType = LocalUpdateTypes.EXE
			Me.lblReturnCodes.Visible = True
		Else If TypeOf _Sdp.InstallableItems.Item(0) Is WindowsInstallerItem Then
			_UpdateType = LocalUpdateTypes.MSI
		Else If TypeOf _Sdp.InstallableItems.Item(0) Is WindowsInstallerPatchItem Then
			_UpdateType = LocalUpdateTypes.MSP
		End If
		
		'Disable the MetaData only flag.
		Me.chkMetadataOnly.Enabled = False
		
		Call LoadSdpData
		
		'We do not need to prompt the user for files so skip the initial tab.
		If _TabsHidden.Count = 0 Then
			Me._TabsHidden.Add(Me.TabsUpdate.TabPages("TabIntro"))
			Me.TabsUpdate.TabPages.RemoveAt(Me.TabIntro.TabIndex)
		End If
		
		'Load the vendor combo box.
		Me.CboVendor.Items.Clear
		For Each tmpVendor As Vendor In My.Forms.MainForm.VendorCollection
			Me.cboVendor.Items.Add(tmpVendor.Name)
		Next
		
		Me.ValidateChildren
		
		Me.DialogResult = DialogResult.Cancel
		
		'Return the SDP file.
		If MyBase.ShowDialog() = DialogResult.OK Then
			Return Me._Sdp
		Else
			Return Nothing
		End If
	End Function
	
	'Allow the user to edit the metadata.
	Sub BtnMetaDataEditClick(Sender As Object, E As EventArgs)
		Msgbox (globalRM.GetString("warning_update_manual_edit"))
		TxtInstallableItemMetaData.ScrollBars = ScrollBars.Vertical
		TxtInstallableItemMetaData.ReadOnly = False
		BtnMetaDataEdit.Visible = False
	End Sub
	
	'Alow the user to edit the superseded metadata.
	Sub BtnIsSupersededEditClick(Sender As Object, E As EventArgs)
		Msgbox (globalRM.GetString("warning_update_manual_edit"))
		TxtIsSuperceded_InstallableItem.ScrollBars = ScrollBars.Vertical
		TxtIsSuperceded_InstallableItem.ReadOnly = False
		BtnIsSupersededEdit.Visible = False
	End Sub
	
	'This routine goes to the previous tab and hides buttons accordingly.
	Private Sub BtnPreviousClick(Sender As Object, E As EventArgs)
		Me.TabsUpdate.SelectedIndex = Me.TabsUpdate.SelectedIndex - 1
		
		Call SetMetadataOnly
		
		'Show and hide the previous button as needed.
		If ( Me.TabsUpdate.SelectedIndex > 0 ) Then
			Me.BtnPrevious.Show
		Else
			Me.BtnPrevious.Hide
		End If
		
		'Change the next button's text as needed.
		If ( Me.TabsUpdate.SelectedIndex < Me.TabsUpdate.TabCount ) Then
			Me.BtnNext.Show
			Me.BtnNext.Text = globalRM.GetString("next")
			Me.BtnNext.Image = My.Resources.Forward.ToBitmap
			Me.BtnNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Else
			Me.BtnNext.Hide
		End If
		
		Me.ValidateChildren
	End Sub
	
	'This routine goes to the next tab and hides buttons accordingly.
	Private Sub BtnNextClick(Sender As Object, E As EventArgs)
		'Perform action depending on current tab.
		' If the action could not be performed do not continue.
		If Not PerformAction Then
			Exit Sub
			'User has selected the finish button so close the form.
		Else If Me.TabsUpdate.SelectedIndex = Me.TabsUpdate.TabCount - 1 Then
			Me.Close
			Exit Sub
		End If
		
		'Move to the next tab.
		Me.TabsUpdate.SelectedIndex = Me.TabsUpdate.SelectedIndex + 1
		
		Call SetMetadataOnly
		
		'Show and hide the previous button as needed.
		If ( Me.TabsUpdate.SelectedIndex > 0 ) Then
			Me.BtnPrevious.Show
		Else
			Me.BtnPrevious.Hide
		End If
		
		'Change the next button's text as needed.
		If ( Me.TabsUpdate.SelectedIndex < Me.TabsUpdate.TabCount - 1 ) Then
			Me.BtnNext.Show
			Me.BtnNext.Text = globalRM.GetString("next")
		Else
			Me.BtnNext.Text = globalRM.GetString("finish")
			Me.BtnNext.Image = Nothing
			Me.BtnNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		End If
		
		Me.ValidateChildren
	End Sub
	
	'Depending on the current tab, enable or disable the metadata only check box.
	Private Sub SetMetadataOnly
		If Not Me._Revision AndAlso ( TabsUpdate.SelectedTab.Name = "tabIntro" OrElse TabsUpdate.SelectedTab.Name = "tabPackageInfo" ) Then
			Me.chkMetadataOnly.Enabled = True
		Else
			Me.chkMetadataOnly.Enabled = False
		End If
	End Sub
	
	'If the user cancels, close the form.
	Private Sub BtnCancelClick(Sender As Object, E As EventArgs)
		
		'Delete the temporary SDP file and ignore any errors.
		If Not String.IsNullOrEmpty(_SdpFilePath) Then
			Try
				System.IO.File.Delete(_SdpFilePath) 'Delete the SDP file.
			Catch
			End Try
		End If
		
		Me.Close
	End Sub
	
	'Prompt the user to select a file, set the textbox and next button accordingly.
	Private Sub BtnUpdateFileClick(Sender As Object, E As EventArgs)
		'Set the file filter.
		Me.DlgUpdateFile.Filter = globalRM.GetString("file_filter_update_binary")
		
		'Disable the MSI path.
		Me.TxtMSIPath.Enabled = False
		
		'Show file dialog and continue if the user chose a file.
		If Me.DlgUpdateFile.ShowDialog = VbOK Then
			Me.chkMetadataOnly.Enabled = True
			
			Dim TmpFile As FileInfo = New FileInfo (DlgUpdateFile.FileName)
			
			Me.TxtUpdateFile.Text = TmpFile.Name
			Me.TxtUpdateFile.Tag = TmpFile
			
			'Set the type of update and enable the next button once a file is chosen.
			If TmpFile.Extension.ToLower.Equals(".exe") Then
				Me._UpdateType = LocalUpdateTypes.EXE
			ElseIf TmpFile.Extension.ToLower.Equals(".msi") Then
				Me._UpdateType = LocalUpdateTypes.MSI
				Me.TxtMSIPath.Enabled = True
			ElseIf TmpFile.Extension.ToLower.Equals(".msp") Then
				Me._UpdateType = LocalUpdateTypes.MSP
			End If
			
			
		Else 'User didn't select a file.
			Me.chkMetadataOnly.Enabled = False
			Me.TxtUpdateFile.Text = ""
			Me.TxtUpdateFile.Tag = Nothing
		End If
		
		Me.ValidateChildren
	End Sub
	
	'Show the return codes dialog.
	Sub LblReturnCodesClick(Sender As Object, E As EventArgs)
		ReturnCodesForm.Location = New Point(Me.Location.X + 100 , Me.Location.Y + 100)
		ReturnCodesForm.ShowDialog(CType(_Sdp.InstallableItems.Item(0), CommandLineItem).ReturnCodes)
	End Sub
	
	'Manage the list of updates that this update supersedes.
	Sub LblSupersedesClick(Sender As Object, E As EventArgs)
		SupersededUpdatesForm.Location = New Point(Me.Location.X + 100 , Me.Location.Y + 100)
		SupersededUpdatesForm.ShowDialog(_Sdp.SupersededPackages, _Sdp.PackageId)
	End Sub
	
	Sub LblLanguagesClick(sender As Object, e As EventArgs)
		If _Sdp.InstallableItems.Count > 0 Then
			LanguageSelectionForm.Location = New Point(Me.Location.X + 100 , Me.Location.Y + 100)
			
			If Not _Sdp.InstallableItems(0).Languages Is Nothing Then
				_Languages = LanguageSelectionForm.ShowDialog(_Languages)
			Else
				_Languages = LanguageSelectionForm.ShowDialog()
			End If
		End If
	End Sub
	
	'ManagetThe list of updates that this update requires before installing.
	Sub LblPrerequisitesClick(Sender As Object, E As EventArgs)
		PrerequisiteUpdatesForm.Location = New Point(Me.Location.X + 100 , Me.Location.Y + 100)
		PrerequisiteUpdatesForm.ShowDialog(_Sdp.Prerequisites, _Sdp.PackageId)
	End Sub
	
	'Perform action according to the currently selected tab.
	' Return a boolean depending upon the success of the action.
	Function PerformAction As Boolean
		
		'Import the file and set the appropriate fields if this isn't a revision.
		Select Case TabsUpdate.SelectedTab.Name
			Case "tabIntro"
				'Don't do anything if this is a revision.
				If Not Me._Revision Then
					'Create new Software Distribution Package.
					_Sdp = New SoftwareDistributionPackage
					
					'Populate SDP from installation file based on its type.
					Try
						Select Case _UpdateType
							Case LocalUpdateTypes.MSI
								
								_Sdp.PopulatePackageFromWindowsInstaller(DirectCast(Me.TxtUpdateFile.Tag, FileInfo).FullName)
								
								'Create the default IsInstallable and IsInstalled rules for MSI packages.
								If _Sdp.InstallableItems.Count > 0
									Dim TmpGuid As String = CType(_Sdp.InstallableItems.Item(0), WindowsInstallerItem).WindowsInstallerProductCode.ToString
									IsInstalledRules.Clear
									IsInstalledRules.Rules = "<msiar:MsiProductInstalled ProductCode=""{" & TmpGuid & "}"" />"
									IsInstallableRules.Clear
									IsInstallableRules.Rules = "<lar:Not ><msiar:MsiProductInstalled ProductCode=""{" & TmpGuid & "}"" /></lar:Not>"
								End If
								
								'Set the package type to application.
								_Sdp.PackageType = PackageType.Application
								
							Case LocalUpdateTypes.MSP
								_Sdp.PopulatePackageFromWindowsInstallerPatch(DirectCast(Me.TxtUpdateFile.Tag,FileInfo).FullName)
								
								'Set the package type to update.
								_Sdp.PackageType  = PackageType.Update
							Case LocalUpdateTypes.EXE
								'Use a Wrapped MSI file if a relative MSI path was given.
								If String.IsNullOrEmpty(Me.TxtMSIPath.Text) Then
									_Sdp.PopulatePackageFromExe(DirectCast(Me.TxtUpdateFile.Tag,FileInfo).FullName)
									
									'Clear the default Installable Item rules created by the API.
									'This puts the user in complete control of the EXE logic.
									If _Sdp.InstallableItems.Count > 0 Then
										_Sdp.InstallableItems.Item(0).IsInstallableApplicabilityRule = Nothing
										_Sdp.InstallableItems.Item(0).IsInstalledApplicabilityRule = Nothing
									End If
								Else
									_Sdp.PopulatePackageFromExeWrappedMsi(DirectCast(Me.TxtUpdateFile.Tag,FileInfo).FullName, New String() { _
										Me.TxtMSIPath.Text}, New String() {})
								End If
								
								'Set the package type to application.
								_Sdp.PackageType  = PackageType.Application
								
								LblReturnCodes.Visible = True
						End Select
						
						Call LoadSdpData 'Load the SDP data into the form.
						
						'If any of the additional files are MST files then setup the transform in the command line automatically.
						For Each TmpRow As DataGridViewRow In DgvAdditionalFiles.Rows
							If TypeOf TmpRow.Cells("FileObject").Value Is FileInfo Then
								
								If Ucase(DirectCast(TmpRow.Cells("FileObject").Value,FileInfo).Extension) = ".MST" Then
									TxtCommandLine.Text = "TRANSFORMS=""" & DirectCast(TmpRow.Cells("FileObject").Value,FileInfo).Name & """"
								End If
							Else If TypeOf TmpRow.Cells("FileObject").Value Is DirectoryInfo Then
								Dim TmpFiles As FileInfo() = DirectCast(TmpRow.Cells("FileObject").Value,DirectoryInfo).GetFiles("*.Mst")
								If TmpFiles.Length > 0 Then
									TxtCommandLine.Text = "TRANSFORMS=""" & DirectCast(TmpRow.Cells("FileObject").Value,DirectoryInfo).Name & "\" & TmpFiles(0).Name & """"
								End If
							End If
						Next
						
						'Verify the URI to confirm the additional files logic.
						Call VerifyOriginalURI()
						
						'Catch any exception related to the creation of the SDP.
					Catch X As InvalidOperationException
						Msgbox (globalRM.GetString("exception_invalid_operation") & ":" & globalRM.GetString("error_update_create_SDP") & VbNewline & X.Message)
					Catch X As ArgumentNullException
						Msgbox (globalRM.GetString("exception_argument_null") & ":" & globalRM.GetString("error_update_create_SDP") & VbNewline & X.Message)
					Catch X As ArgumentException
						Msgbox (globalRM.GetString("exception_argument") & ":" & globalRM.GetString("error_update_create_SDP") & VbNewline & X.Message)
					Catch X As FileNotFoundException
						Msgbox (globalRM.GetString("exception_file_not_found") & ":" & globalRM.GetString("error_update_create_SDP") & VbNewline & X.Message)
					Catch X As InvalidDataException
						Msgbox (globalRM.GetString("exception_invalid_data") & ":" & globalRM.GetString("error_update_create_SDP") & VbNewline & X.Message)
					Catch X As Win32Exception
						Msgbox (globalRM.GetString("exception_win32") & ":" & globalRM.GetString("error_update_create_SDP") & VbNewline & X.Message)
					End Try
				End If 'If this is a revision.
				
			Case "tabPackageInfo"
				Try
					'Save the info from the form into the SDP object.
					_Sdp.PackageType = DirectCast(Me.cboPackageType.SelectedIndex, PackageType)
					_Sdp.Title = Me.TxtPackageTitle.Text
					_Sdp.Description = Me.TxtDescription.Text
					_Sdp.PackageUpdateClassification = DirectCast(Me.CboClassification.SelectedIndex, PackageUpdateClassification)
					_Sdp.SecurityBulletinId = Me.TxtBulletinID.Text
					
					'Set the security rating only if a Bulletin ID has been entered.
					If Not String.IsNullOrEmpty(Me.TxtBulletinID.Text) Then
						_Sdp.SecurityRating = DirectCast(Me.CboSeverity.SelectedIndex, SecurityRating)
					Else
						_Sdp.SecurityRating = Nothing
					End If
					
					_Sdp.VendorName = Me.CboVendor.Text
					
					'If a product name exists then change it.  Otherwise add a new one to the list.
					If _Sdp.ProductNames.Count > 0 Then
						_Sdp.ProductNames(0) = Me.CboProduct.Text
					Else
						_Sdp.ProductNames.Add(Me.CboProduct.Text)
					End If
					
					_Sdp.KnowledgebaseArticleId = Me.TxtArticleID.Text
					
					'Recreate string collection of common vulnerabilities.
					_Sdp.CommonVulnerabilitiesIds.Clear
					If Not String.IsNullOrEmpty(Me.TxtCVEID.Text) Then
						_Sdp.CommonVulnerabilitiesIds.Add(Me.TxtCVEID.Text)
					End If
					
					If Not String.IsNullOrEmpty(Me.TxtSupportURL.Text) Then _Sdp.SupportUrl = New Uri( Me.TxtSupportURL.Text)
					
					'If an Additional Info URL exists then change it.  Otherwise add a new one to the list.
					If _Sdp.AdditionalInformationUrls.Count > 0 And Not String.IsNullOrEmpty(Me.TxtMoreInfoURL.Text) Then
						_Sdp.AdditionalInformationUrls.Item(0) = New Uri(Me.TxtMoreInfoURL.Text)
					Else If Not String.IsNullOrEmpty(Me.TxtMoreInfoURL.Text)
						_Sdp.AdditionalInformationUrls.Add(New Uri(Me.TxtMoreInfoURL.Text))
					End If
					
					'If there is an Installable Item, save its values as well.
					If _Sdp.InstallableItems.Count > 0 Then
						'Set the languages
						_Sdp.InstallableItems.Item(0).Languages.Clear
						If Not _Languages Is Nothing AndAlso _Languages.Count > 0 Then
							For Each tmpLanguage As String In _Languages
								_Sdp.InstallableItems.Item(0).Languages.Add(tmpLanguage)
							Next
						End If
						
						_Sdp.InstallableItems.Item(0).InstallBehavior.Impact = DirectCast(Me.CboImpact.SelectedIndex, InstallationImpact)
						_Sdp.InstallableItems.Item(0).InstallBehavior.RebootBehavior = DirectCast(Me.CboRebootBehavior.SelectedIndex, RebootBehavior)
						
						'If there is a command line string then set it based on the update type otherwise set it to null.
						' The type of the Installable Items objects depends on the type of file we populated
						' the SDP with.  Therefore, we need to cast the Installable Item accordingly
						' so that we can add the command line string using the right property name.
						Select Case _UpdateType
							Case LocalUpdateTypes.EXE
								If String.IsNullOrEmpty(Me.TxtCommandLine.Text) Then
									DirectCast(_Sdp.InstallableItems.Item(0), CommandLineItem).Arguments = Nothing
								Else
									DirectCast(_Sdp.InstallableItems.Item(0), CommandLineItem).Arguments = Me.TxtCommandLine.Text
								End If
							Case LocalUpdateTypes.MSI
								If String.IsNullOrEmpty(Me.TxtCommandLine.Text) Then
									DirectCast(_Sdp.InstallableItems.Item(0), WindowsInstallerItem).InstallCommandLine = Nothing
								Else
									DirectCast(_Sdp.InstallableItems.Item(0), WindowsInstallerItem).InstallCommandLine = Me.TxtCommandLine.Text
								End If
							Case LocalUpdateTypes.MSP
								If String.IsNullOrEmpty(Me.TxtCommandLine.Text) Then
									DirectCast(_Sdp.InstallableItems.Item(0), WindowsInstallerPatchItem).InstallCommandLine = Nothing
								Else
									DirectCast(_Sdp.InstallableItems.Item(0), WindowsInstallerPatchItem).InstallCommandLine = Me.TxtCommandLine.Text
								End If
						End Select
						
						'Add the original URI if it is present and this is a new update or we are revising an update and the
						' original URI was changed.
						If Not String.IsNullOrEmpty( Me.txtOriginalURI.Text ) AndAlso _
							(Not Me._Revision OrElse _
							Me._OriginalURIChanged AndAlso _OriginalFileInfo Is Nothing ) Then
							Dim hashProvider As SHA1CryptoServiceProvider = New SHA1CryptoServiceProvider
							Dim digest As String
							Dim inStream As FileStream
							Dim fileItem As FileForInstallableItem = New FileForInstallableItem
							
							'If we are revising the update then download the file.
							If Me._Revision Then
								Dim tmpFilePath As String
								tmpFilePath = Path.Combine( Path.GetTempPath , Path.GetFileName(Me.txtOriginalURI.Text))
								
								'Set cursor and position of progress form.
								My.Forms.ProgressForm.Location =  New Point(My.Forms.MainForm.Location.X + 100, My.Forms.MainForm.Location.Y + 100)
								My.Forms.ProgressForm.ShowDialog("Downloading files for " & _Sdp.Title, parentForm)
								My.Forms.ProgressForm.SetCurrentStep(Me.txtOriginalURI.Text)
								ConnectionManager.DownloadChunks(New Uri(Me.txtOriginalURI.Text), My.Forms.ProgressForm.progressBar, tmpFilePath)
								My.Forms.ProgressForm.Dispose
								
								_OriginalFileInfo = New FileInfo(tmpFilePath)
								
								'If file was not downloaded then delete the file and exit the function.
								If _OriginalFileInfo.Length = 0 Then
									_OriginalFileInfo.Delete
									_OriginalFileInfo = Nothing
									Return False
								End If
							Else
								_OriginalFileInfo = DirectCast(Me.txtUpdateFile.Tag,FileInfo)
							End If
							
							'Get the SHA1 hash of the file.
							inStream = _OriginalFileInfo.OpenRead()
							digest = Convert.ToBase64String(hashProvider.ComputeHash(inStream))
							'Msgbox ( System.BitConverter.ToString(Convert.FromBase64String(digest)))
							instream.Close
							
							'Setup the FileForInstallable Item
							fileItem.FileName = _OriginalFileInfo.Name
							fileItem.OriginUri = New Uri(Me.txtOriginalURI.Text)
							fileItem.Digest = digest
							fileItem.Modified = _OriginalFileInfo.LastWriteTimeUtc
							fileItem.Size = _OriginalFileInfo.Length
							
							'Assign it to the SDP.
							_Sdp.InstallableItems(0).OriginalSourceFile = fileItem
							
							'If we are revising an update delete the temporary file.
							If Me._Revision Then
								Me._OriginalURIChanged = False
								Try
									_OriginalFileInfo.Delete
								Catch
								End Try
							End If
						Else If String.IsNullOrEmpty( Me.txtOriginalURI.Text )
							_Sdp.InstallableItems(0).OriginalSourceFile = Nothing
						End If
						
					End If 'There is at least one Installable Item object.
					
				Catch X As UriFormatException
					My.Forms.ProgressForm.Dispose
					Msgbox(globalRM.GetString("exception_URI_format") & ":" & globalRM.GetString("error_update_save") & VbNewline & X.Message)
					Return False
				Catch X As Exception
					My.Forms.ProgressForm.Dispose
					Msgbox(globalRM.GetString("exception") & ":" & globalRM.GetString("error_update_save") & VbNewline & X.Message)
					Return False
				End Try
			Case "tabIsInstalled"
				'If there are rules then add them to the IsInstallable property.
				If Not String.IsNullOrEmpty(IsInstalledRules.Rules) Then
					_Sdp.IsInstalled = IsInstalledRules.Rules
				Else
					_Sdp.IsInstalled = Nothing
				End If
				
				'If the user has edited the Installable Item level XML then save their changes.
				If IsInstalledRules.ApplicabilityRuleEdited Then
					If Not String.IsNullOrEmpty(IsInstalledRules.ApplicabilityRule) Then
						_Sdp.InstallableItems(0).IsInstalledApplicabilityRule = IsInstalledRules.ApplicabilityRule
					Else
						_Sdp.InstallableItems(0).IsInstalledApplicabilityRule = Nothing
					End If
				End If
			Case "tabIsInstallable"
				'If there are rules then add them to the IsInstallable property.
				If Not String.IsNullOrEmpty(IsInstallableRules.Rules) Then
					_Sdp.IsInstallable = IsInstallableRules.Rules
				Else
					_Sdp.IsInstallable = Nothing
				End If
				
				'If the user has edited the Installable Item level XML then save their changes.
				If IsInstallableRules.ApplicabilityRuleEdited Then
					If Not String.IsNullOrEmpty(IsInstallableRules.ApplicabilityRule) Then
						_Sdp.InstallableItems(0).IsInstallableApplicabilityRule = IsInstallableRules.ApplicabilityRule
					Else
						_Sdp.InstallableItems(0).IsInstallableApplicabilityRule = Nothing
					End If
				End If
			Case "tabIsSuperseded"
				'If the user has edited the Installable Item level XML then save their changes.
				If Not TxtIsSuperceded_InstallableItem.ReadOnly Then
					If Not String.IsNullOrEmpty(TxtIsSuperceded_InstallableItem.Text) Then
						_Sdp.InstallableItems(0).IsSupersededApplicabilityRule = TxtIsSuperceded_InstallableItem.Text
					Else
						_Sdp.InstallableItems(0).IsSupersededApplicabilityRule = Nothing
					End If
				End If
			Case "tabMetaData"
				'If the user has edited the metadata then save their changes.
				If Not TxtInstallableItemMetaData.ReadOnly Then
					If Not String.IsNullOrEmpty(TxtInstallableItemMetaData.Text) Then
						_Sdp.InstallableItems(0).ApplicabilityMetadata = TxtInstallableItemMetaData.Text
					Else
						_Sdp.InstallableItems(0).ApplicabilityMetadata = Nothing
					End If
				End If
				
				'Save the SDP file and then load it into the summary field.
				Try
					_SdpFilePath = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), _Sdp.PackageId.ToString() & ".Xml")
					_Sdp.Save(_SdpFilePath)
					Dim Sr As New IO.StreamReader(_SdpFilePath)
					Me.TxtSummary.Text = Sr.ReadToEnd()
					Sr.Close()
					Me.TxtSummary.Text = IndentXMLString(Me.TxtSummary.Text)
					Me.TxtSummary.DeselectAll
				Catch X As XmlException
					Msgbox(globalRM.GetString("exception_XML") & ": " & globalRM.GetString("error_update_invalid_XML") & VbNewLine & X.Message)
					Return False
				Catch X As XmlSchemaException
					Msgbox(globalRM.GetString("exception_XML_schema") & ": " & globalRM.GetString("error_update_invalid_XML") & VbNewLine & X.Message)
					Return False
				End Try
				
				
			Case "tabSummary" 'Publish the package and catch any errors.
				
				
				'If the user wants to export the SDP then prompt for a filename.
				If ChkExportSdp.Checked Then
					'Set default extension.
					DlgExportSdp.Filter = globalRM.GetString("file_filter_xml")
					DlgExportSdp.DefaultExt = ".XML"
					DlgExportSdp.AddExtension = True
					DlgExportSdp.FileName = _Sdp.Title & ".Xml"
					
					'Show dialog and copy the file.
					If DlgExportSdp.ShowDialog = VbOK Then
						Msgbox ( _SdpFilePath )
						My.Computer.FileSystem.CopyFile( _SdpFilePath, DlgExportSdp.FileName, True)
					End If
				End If
				
				If _Revision Then 'This is a revision.
					Me.Cursor = Cursors.WaitCursor
					
					If ConnectionManager.RevisePackage(_Sdp, Me) Then
						Msgbox (globalRM.GetString("warning_update_revise_success"))
					Else
						Msgbox (globalRM.GetString("warning_update_revised_failed"))
					End If
					Me.Cursor = Cursors.Arrow
					Me.DialogResult = DialogResult.OK
					
					Return True
					
				Else 'This is a new update.
					
					'Add the files to a new iList.
					Dim FileList As IList(Of Object) = New List(Of Object)
					FileList.Add(TxtUpdateFile.Tag) ' Add main update file.
					
					'Add additional files and directories.
					For Each TmpRow As DataGridViewRow In DgvAdditionalFiles.Rows
						FileList.Add(TmpRow.Cells("FileObject").Value)
					Next
					
					Me.Cursor = Cursors.WaitCursor
					
					'Publish package according to the metadata only checkbox.
					Dim Result As Boolean = False
					If chkMetadataOnly.Checked Then
						Result = ConnectionManager.PublishPackageMetaData(_Sdp, Me)
					Else
						Result = ConnectionManager.PublishPackage(_Sdp,FileList, Me)
					End If
					
					Me.Cursor = Cursors.Arrow
					
					If Result Then
						Msgbox (globalRM.GetString("warning_update_publish_success"))
					Else
						Msgbox (globalRM.GetString("warning_update_publish_failed"))
					End If
					
					Me.DialogResult = DialogResult.OK
					Return True
				End If
				Return False 'If we got this far we failed.
		End Select
		
		Return True 'If we got this far we succeeded.
	End Function 'PerformAction
	
	
	'This routine loads the SDP passed into the form and
	' loads the form with the appropriate data.  This is the first
	' step in revising an existing update.
	Sub LoadSdpData
		
		If Not _Sdp Is Nothing Then 'Make sure the SDP object is instantiated.
			
			'Load the basic info into the form.
			Me.cboPackageType.SelectedIndex = DirectCast(_Sdp.PackageType, Integer)
			If Not String.IsNullOrEmpty(_Sdp.Title) Then Me.TxtPackageTitle.Text = _Sdp.Title
			If Not String.IsNullOrEmpty(_Sdp.Description) Then Me.TxtDescription.Text = _Sdp.Description
			Me.CboClassification.SelectedIndex = _Sdp.PackageUpdateClassification
			If Not String.IsNullOrEmpty(_Sdp.SecurityBulletinId) Then Me.TxtBulletinID.Text = _Sdp.SecurityBulletinId
			Me.CboSeverity.SelectedIndex = _Sdp.SecurityRating
			If String.IsNullOrEmpty(Me.CboVendor.Text) AndAlso Not String.IsNullOrEmpty(_Sdp.VendorName) Then Me.CboVendor.Text = _Sdp.VendorName
			If String.IsNullOrEmpty(Me.CboProduct.Text) AndAlso _Sdp.ProductNames.Count > 0 Then Me.CboProduct.Text = _Sdp.ProductNames(0)
			If Not String.IsNullOrEmpty(_Sdp.KnowledgebaseArticleId) Then Me.TxtArticleID.Text = _Sdp.KnowledgebaseArticleId
			If _Sdp.CommonVulnerabilitiesIds.Count > 0 Then Me.TxtCVEID.Text = _Sdp.CommonVulnerabilitiesIds.Item(0)
			If Not _Sdp.SupportUrl Is Nothing Then Me.TxtSupportURL.Text = _Sdp.SupportUrl.ToString
			If _Sdp.AdditionalInformationUrls.Count > 0 Then Me.TxtMoreInfoURL.Text = _Sdp.AdditionalInformationUrls.Item(0).ToString
			
			'Load the Installable Item info
			If _Sdp.InstallableItems.Count > 0 Then 'There is an Installable Item.
				
				_Languages = _Sdp.InstallableItems.Item(0).Languages
				
				If _Sdp.InstallableItems.Item(0).UninstallBehavior Is Nothing Then
					Me.TxtUninstall.Text = globalRM.GetString("false")
				Else
					Me.TxtUninstall.Text = globalRM.GetString("true")
				End If
				
				Me.CboImpact.SelectedIndex = _Sdp.InstallableItems.Item(0).InstallBehavior.Impact
				Me.CboRebootBehavior.SelectedIndex = _Sdp.InstallableItems.Item(0).InstallBehavior.RebootBehavior
				Me.txtNetwork.Text = _Sdp.InstallableItems.Item(0).InstallBehavior.RequiresNetworkConnectivity.ToString
				
				'Set the command line based on the update type.
				Select Case _UpdateType
					Case LocalUpdateTypes.EXE
						Me.TxtCommandLine.Text = CType(_Sdp.InstallableItems.Item(0), CommandLineItem).Arguments
					Case LocalUpdateTypes.MSI
						Me.TxtCommandLine.Text = CType(_Sdp.InstallableItems.Item(0), WindowsInstallerItem).InstallCommandLine
					Case LocalUpdateTypes.MSP
						Me.TxtCommandLine.Text = CType(_Sdp.InstallableItems.Item(0), WindowsInstallerPatchItem).InstallCommandLine
				End Select
				
				'Load the Installable Item level applicability rules.
				Me.IsInstalledRules.ApplicabilityRule = _Sdp.InstallableItems(0).IsInstalledApplicabilityRule
				Me.IsInstallableRules.ApplicabilityRule = _Sdp.InstallableItems(0).IsInstallableApplicabilityRule
				Me.TxtIsSuperceded_InstallableItem.Text = _Sdp.InstallableItems(0).IsSupersededApplicabilityRule
				Me.TxtInstallableItemMetaData.Text = _Sdp.InstallableItems(0).ApplicabilityMetadata
				
				'Load the Original URI
				If Not _Sdp.InstallableItems(0).OriginalSourceFile Is Nothing AndAlso _
					Not _Sdp.InstallableItems(0).OriginalSourceFile.OriginUri Is Nothing Then										
					Me.txtOriginalURI.Text = _Sdp.InstallableItems(0).OriginalSourceFile.OriginUri.ToString
				End If
				
			End If 'There is a Installable Item.
			
			'Note: In previous versions of LUP we didn't check to see if the IsInstalled or
			' IsInstallable members were empty and the SDP was set with these members instantiated
			' to an empty string.  If we detect these when loading then set the member to nothing.
			
			'Load the package's IsInstalled rules.
			If Not String.IsNullOrEmpty(_Sdp.IsInstalled) Then
				IsInstalledRules.Rules = _Sdp.IsInstalled
			Else
				_Sdp.IsInstalled = Nothing
			End If
			
			'Load the package's IsInstallable rules.
			If Not String.IsNullOrEmpty(_Sdp.IsInstallable) Then
				IsInstallableRules.Rules = _Sdp.IsInstallable
			Else
				_Sdp.IsInstallable = Nothing
			End If
			
		End If 'SDP is not instantiated.
	End Sub 'LoadSDPData.
	
	'This function formats the SDP XML into something more
	' readable by indenting the lines appropriately.
	' It's directly based off of Les Smith's example found here:
	' http://www.knowdotnet.com/articles/indentxml.html
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
			Dim Sr  As StreamReader = New StreamReader(Ms)
			' Return the sormatted string to caller.
			Return Sr.ReadToEnd()
			
		Catch X As OutOfMemoryException
			MessageBox.Show(globalRM.GetString("exception_out_of_memory") & ": " & VbNewline & X.Message)
		Catch X As IOException
			MessageBox.Show(globalRM.GetString("exception_IO") & ": " & VbNewline & X.Message)
		Catch X As ArgumentOutOfRangeException
			MessageBox.Show(globalRM.GetString("exception_argument_out_of_range") & ": " & VbNewline & X.Message)
		Catch X As ArgumentNullException
			MessageBox.Show(globalRM.GetString("exception_argument_null") & ": " & VbNewline & X.Message)
		Catch X As ArgumentException
			MessageBox.Show(globalRM.GetString("exception_argument") & ": " & VbNewline & X.Message)
		Catch X As ObjectDisposedException
			MessageBox.Show(globalRM.GetString("exception_object_disposed") & ": " & VbNewline & X.Message)
		Catch X As XMLException
			MessageBox.Show(globalRM.GetString("exception_XML") & ": " & VbNewline & X.Message)
		End Try
		Return String.Empty 'If we got here there was an exception.
	End Function
	
	'Prompt the user for files and add them to the collection.
	Private Sub BtnAddFilesClick(Sender As Object, E As EventArgs)
		
		'Set dialog values.
		Me.dlgUpdateFile.Filter = ""
		Me.dlgUpdateFile.Multiselect = True
		
		'Show dialog and load the file into the DGV if the user chose a file.
		If Me.DlgUpdateFile.ShowDialog(Me) = VbOK Then
			
			'Loop through the selected files and add them.
			For Each tmpFile As String In Me.dlgUpdateFile.FileNames
				Call DgvAdditionalFileAddFile(tmpFile)
			Next
		End If
	End Sub
	
	'Prompt the user for a directory and add it to the collection.
	Sub BtnAddDirClick(Sender As Object, E As EventArgs)
		If DlgUpdateDir.ShowDialog(Me) = VbOK Then
			Call DgvAdditionalFileAddDirectory(DlgUpdateDir.SelectedPath)
		End If
	End Sub
	
	'Give the user feedback when hovering items over the data grid view.
	Sub DgvAdditionalFilesDragEnter(sender As Object, e As DragEventArgs)
		e.Effect = DragDropEffects.Copy
	End Sub
	
	'Allow the user to drop files and folders onto the data grid view.
	Sub DgvAdditionalFilesDragDrop(sender As Object, e As DragEventArgs)
		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			For Each tmpPath As String In DirectCast(e.Data.GetData(DataFormats.FileDrop), String())
				If System.IO.Directory.Exists(tmpPath) Then
					Call DgvAdditionalFileAddDirectory(tmpPath)
				Else If System.IO.File.Exists(tmpPath)
					Call DgvAdditionalFileAddFile(tmpPath)
				Else
					'Do nothing if this is neither a file nor a drecotry.
				End If
			Next
		End If
	End Sub
	
	'Add the file to the additional files data grid view
	Sub DgvAdditionalFileAddFile(filePath As String)
		Dim tmpFile As FileInfo
		Dim tmpRow As Integer
		
		If System.IO.File.Exists(filePath) Then
			tmpFile = New FileInfo(filePath)
			tmpRow = DgvAdditionalFiles.Rows.Add(New String() {TmpFile.Name })
			Me.dgvAdditionalFiles.Rows.Item(TmpRow).Cells("FileObject").Value = TmpFile
		End If
	End Sub
	
	'Add the directory to the additional files data grid view
	Sub DgvAdditionalFileAddDirectory(dirPath As String)
		Dim tmpDir As DirectoryInfo
		Dim tmpRow As Integer
		
		If System.IO.Directory.Exists(dirPath) Then
			tmpDir = New DirectoryInfo(dirPath)
			tmpRow = DgvAdditionalFiles.Rows.Add(New String() {TmpDir.Name & " (Dir)" })
			DgvAdditionalFiles.Rows.Item(TmpRow).Cells("FileObject").Value = TmpDir
		End If
	End Sub
	
	'Remove the file from the files DGV.
	Private Sub DgvAdditionalFilesCellContentClick(Sender As Object, E As DataGridViewCellEventArgs)
		If Me.DgvAdditionalFiles.Columns(E.ColumnIndex).Name = "RemoveFile" Then
			Me.DgvAdditionalFiles.Rows.RemoveAt(E.RowIndex)
		End If
	End Sub
	
	Shadows Sub TextChanged(sender As Object, e As EventArgs)
		CustomResize.ResizeVertically( sender, e)
	End Sub
	
	#End Region
	
	#Region "Validation"
	'If we publish a metadata update only then the user must give an original URL and
	' the update cannot contain additional files.
	Sub CboMetadataOnlyCheckedChanged(sender As Object, e As EventArgs)
		If chkMetaDataOnly.Checked Then
			
			'Prevent user from selecting metadata only if they have additional files.
			If Me.dgvAdditionalFiles.Rows.Count > 0 Then
				Msgbox (globalRM.GetString("warning_update_metadata_additional_files"))
				chkMetaDataOnly.Checked = False
				Exit Sub
			End If
			
			Me.btnAddFiles.Enabled = False
			Me.btnAddDir.Enabled = False
			Me.dgvAdditionalFiles.Enabled = False
			
			'Add the filename to the OriginalURI textbox and set the error handler.
			If String.IsNullOrEmpty( Me.txtOriginalURI.Text ) Then
				Me.txtOriginalURI.Text = DirectCast( Me.txtUpdateFile.Tag, FileInfo).Name
				'Me.ErrorProviderUpdate.SetError(Me.txtOriginalURI,"No URL Is Given")
			End If
		Else
			Me.btnAddFiles.Enabled = True
			Me.btnAddDir.Enabled = True
			Me.dgvAdditionalFiles.Enabled = True
			
			'If the original URI field is empty then make it valid.
			If String.IsNullOrEmpty(Me.txtOriginalURI.Text) Then
				Me.ErrorProviderUpdate.SetError(Me.txtOriginalURI,"")
			End If
		End If
		
		Me.ValidateChildren
	End Sub
	
	'Call the verify original URI routine.
	Sub txtOriginalURITextChanged(sender As Object, e As EventArgs)
		Call VerifyOriginalURI
	End Sub
	
	'Handle non-alphanumeric keypresses.
	Sub TxtOriginalURIKeyDown(sender As Object, e As KeyEventArgs)
		If Me._Revision AndAlso Not Me._OriginalURIChanged AndAlso e.KeyCode = Keys.Delete Then
			e.Handled = TxtOriginalURIVerifyKey
		End If
	End Sub
	
	'Handle alpha-numeric keypresses
	Sub TxtOriginalURIKeyPress(sender As Object, e As KeyPressEventArgs)
		'If we're revising the update then any change to the URI will result in downloading it for verification.
		If e.KeyChar = ChrW(1) Then
			Me.txtOriginalURI.SelectAll
		Else If Me._Revision AndAlso Not Me._OriginalURIChanged AndAlso Not e.KeyChar = ChrW(3)  Then
			e.Handled = TxtOriginalURIVerifyKey
		Else
			e.Handled = False
		End If
		
	End Sub
	
	Function TxtOriginalURIVerifyKey() As Boolean
		If MsgBox(globalRM.GetString("prompt_update_redownload"), MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
			Me._OriginalURIChanged = True
			Me._OriginalFileInfo = Nothing
			Return False
		Else
			Return True
		End If
	End Function
	
	
	'Validate that the source URL is valid and points to the selected file.
	Sub VerifyOriginalURI()
		If String.IsNullOrEmpty(Me.txtOriginalURI.Text) Then
			If Me.chkMetadataOnly.Checked Then
				Me.ErrorProviderUpdate.SetError(Me.txtOriginalURI,globalRM.GetString("warning_update_no_uri"))
			Else
				Me.ErrorProviderUpdate.SetError(Me.txtOriginalURI,"")
			End If
		ElseIf Not Me._Revision AndAlso Me.dgvAdditionalFiles.Rows.Count > 0 Then
			Me.ErrorProviderUpdate.SetError(Me.txtOriginalURI,globalRM.GetString("warning_update_additional_files_uri"))
		ElseIf Not Uri.IsWellFormedUriString(Me.txtOriginalURI.Text, UriKind.Absolute) Then
			Me.ErrorProviderUpdate.SetError(Me.txtOriginalURI,globalRM.GetString("warning_update_invalid_URI"))
		ElseIf Not me._Revision AndAlso Not Me.txtOriginalURI.Text.Contains(DirectCast( Me.txtUpdateFile.Tag, FileInfo).Name)
			Me.ErrorProviderUpdate.SetError(Me.txtOriginalURI,globalRM.GetString("warning_update_file_mismatch"))
		Else
			Me.ErrorProviderUpdate.SetError(Me.txtOriginalURI,"")
		End If
		
		Me.ValidateChildren
	End Sub
	
	'Validate that a URI is valid.
	Sub txtURITextChanged(sender As Object, e As EventArgs)
		Dim tmpTextBox As TextBox
		If TypeOf Sender Is TextBox Then
			tmpTextBox = DirectCast(sender, TextBox)
			If Not String.IsNullOrEmpty(tmpTextBox.Text) AndAlso Not Uri.IsWellFormedUriString(tmpTextBox.Text, UriKind.Absolute) Then
				Me.ErrorProviderUpdate.SetError(tmpTextBox, globalRM.GetString("warning_update_invalid_URI."))
			Else
				Me.ErrorProviderUpdate.SetError(tmpTextBox,"")
			End If
		End If
		
		Me.ValidateChildren
	End Sub
	
	'Populate the Product combo box.
	Sub CboVendorSelectedIndexChanged(sender As Object, e As EventArgs)
		Me.cboProduct.Items.Clear
		'Load the products combo with the selected vendor.
		If My.Forms.MainForm.VendorCollection.Contains(Me.cboVendor.Text) Then
			For Each tmpProduct As String In My.Forms.MainForm.VendorCollection(Me.cboVendor.Text).Products
				Me.cboProduct.Items.Add(tmpProduct)
			Next
		End If
		
		'Now validate the combo.
		ValidateCombo( sender, e )
	End Sub
	
	'Enable and Disable the appropriate details based on the package type.
	Sub CboPackageTypeSelectedIndexChanged(sender As Object, e As EventArgs)
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
	
	'A generic validated routine that clears the validation errors.
	Sub ControlValidated(Sender As Object, E As EventArgs)
		Me.ErrorProviderUpdate.SetError(DirectCast(Sender, Control),"")
	End Sub
	
	'A generic validating routine that verifies the sender control isn't empty.
	Sub ControlValidating(Sender As Object, E As CancelEventArgs)
		Try
			If TypeOf Sender Is TextBox OrElse TypeOf Sender Is ComboBox Then
				
				If DirectCast(Sender, Control).Text.Length = 0 Then
					Me.ErrorProviderUpdate.SetError(DirectCast(Sender, Control), globalRM.GetString("warning_no_value"))
					E.Cancel = True
				End If
				
				Call ValidateTabControl() 'Validate the current tab.
			End If
		Catch Ex As Exception
			MsgBox(Ex.Message)
		End Try
	End Sub
	
	'Validate the current tab and enable or disable the next buttons accordingly.
	Sub ValidateTabControl()
		Try
			
			Dim Invalid As Boolean = False
			
			Select Case TabsUpdate.SelectedTab.Name
					'Verify a file has been selected.
				Case "tabIntro"
					If Not String.IsNullOrEmpty(Me.ErrorProviderUpdate.GetError(Me.txtUpdateFile)) Then
						Invalid = True
					End If
					
					'Verify that a vendor and product name have been given.
				Case "tabPackageInfo"
					
					'Verify that no errors are shown.
					If Not String.IsNullOrEmpty(Me.ErrorProviderUpdate.GetError(Me.TxtPackageTitle)) OrElse _
						Not String.IsNullOrEmpty(Me.ErrorProviderUpdate.GetError(Me.TxtDescription)) OrElse _
						Not String.IsNullOrEmpty(Me.ErrorProviderUpdate.GetError(Me.CboClassification)) OrElse _
						Not String.IsNullOrEmpty(Me.ErrorProviderUpdate.GetError(Me.CboVendor))  OrElse _
						Not String.IsNullOrEmpty(Me.ErrorProviderUpdate.GetError(Me.CboProduct)) OrElse _
						Not String.IsNullOrEmpty(Me.ErrorProviderUpdate.GetError(Me.CboImpact)) OrElse _
						Not String.IsNullOrEmpty(Me.ErrorProviderUpdate.GetError(Me.CboRebootBehavior))OrElse _
						Not String.IsNullOrEmpty(Me.ErrorProviderUpdate.GetError(Me.txtOriginalURI))OrElse _
						Not String.IsNullOrEmpty(Me.ErrorProviderUpdate.GetError(Me.txtSupportURL))OrElse _
						Not String.IsNullOrEmpty(Me.ErrorProviderUpdate.GetError(Me.txtMoreInfoURL))
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
				Me.BtnNext.Enabled = False
			Else
				Me.BtnNext.Enabled = True
			End If
			
		Catch Ex As Exception
			MsgBox(Ex.Message)
		End Try
	End Sub
	
	'Enable and validate the severity combo only if something is entered for the bulletin ID.
	Sub TxtBulletinIDValidating(Sender As Object, E As CancelEventArgs)
		If TxtBulletinID.Text.Length = 0 Then
			Me.CboSeverity.Enabled = False
		Else
			Me.CboSeverity.Enabled = True
			Me.ErrorProviderUpdate.SetError(Me.CboSeverity, "")
		End If
	End Sub
	
	'Validate the form based on combobox actions.
	Sub ValidateCombo(Sender As Object, E As EventArgs)
		Try
			If TypeOf Sender Is ComboBox Then
				Me.Validate
			End If
		Catch Ex As Exception
			MsgBox(Ex.Message)
		End Try
	End Sub
	
	#End Region
End Class