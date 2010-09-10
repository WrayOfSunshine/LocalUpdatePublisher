' Copyright (C) <2010> <Bryan R. Dam>
' Released Under The MIT License As Found In LICENSE.Txt
'
' UpdateForm
' This Form Is Used To Create And Revise Software Distribution Packages
' For The WSUS Server.  If The Form Is Called With A String To A SDP File
' Then Load The Form With That Data.  Otherwise, Walk The User Through Creating
' A New Package.
' This Form Is Intened To Work Like A Typical Wizard.  This Is Accomplished By Using
' A Customized TabControl Object That Allows Us To Hide The Tab Names.  In This Manner
' We Can Create Pages Of The Wizard Easily In Design Mode But Hide The Tab
' Navigation At Run Time.
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

Public Partial Class UpdateForm
	
	Private _Sdp As SoftwareDistributionPackage
	Private _TabsHidden As New List(Of TabPage)
	Private _UpdateType As Integer
	Private _Revision As Boolean
	Private _Publisher As IPublisher
	Private _SdpFilePath As String
	
	Public Sub New()
		' The Me.InitializeComponent Call Is Required For Windows Forms Designer Support.
		Me.InitializeComponent()
		Me.BtnPrevious.Hide
		
		'Set The Defaults.
		Me.DialogResult = DialogResult.Cancel
		Me.TabsImportUpdate.HideTabs = True
		Me.BtnPrevious.Image = My.Resources.Previous.ToBitmap
		Me.BtnNext.Image = My.Resources.Forward.ToBitmap
	End Sub
	
	#REGION "Form Methods"
	'If No SDP Is Passed Then Create A New, Blank One.
	Public Overloads Function ShowDialog() As DialogResult
		'Clear The Supporting Forms.
		SupersededUpdatesForm = Nothing
		PrerequisiteUpdatesForm = Nothing
		
		'Set Default Values.
		Me._Sdp = New SoftwareDistributionPackage()
		Me._Revision = False
		Me.TxtMSIPath.Enabled = False
		Me.ErrorProviderUpdate.SetError(Me.TxtUpdateFile, "Please Select A File.")
		
		'If There'S A Hidden Tab In The Temp Tab Control, Load It.
		If _TabsHidden.Count > 0 Then
			Me.TabsImportUpdate.TabPages.Insert(0, Me._TabsHidden(0))
			_TabsHidden.RemoveAt(0)
		End If
		
		'Clear The Product And Vendor Combo Boxes And Load Them From
		' The Strings Created In The Main Form.  These Strings Are Created
		' As The Main Form Loads The Updates And Vendors Into The Tree View.
		Me.CboProduct.Items.Clear
		Me.CboProduct.Items.AddRange(Split(My.Forms.MainForm.Products ,VbNewLine))
		Me.CboVendor.Items.Clear
		Me.CboVendor.Items.AddRange(Split(My.Forms.MainForm.Vendors ,VbNewLine))
		
		Me.DialogResult = DialogResult.Cancel
		Return MyBase.ShowDialog() 'Return The Dialog Result.
	End Function
	
	'If No SDP Is Passed Then Create A New, Blank One.
	Public Overloads Function ShowDialog(PackageFile As String ) As DialogResult
		'Clear The Supporting Forms.
		SupersededUpdatesForm = Nothing
		PrerequisiteUpdatesForm = Nothing
		ReturnCodesForm = Nothing
		
		'Load SDP From Passed File, Set Revision Boolean, And Load SDP Data,
		' And Set The Filename.
		Me._Sdp = New SoftwareDistributionPackage(PackageFile)
		Me._Revision = True
		
		'Set The Update Type Based On The Type Of The Installable Item.
		If TypeOf _Sdp.InstallableItems.Item(0) Is CommandLineItem Then
			_UpdateType = LocalUpdateTypes.EXE
			Me.lblReturnCodes.Visible = True
		Else If TypeOf _Sdp.InstallableItems.Item(0) Is WindowsInstallerItem Then
			_UpdateType = LocalUpdateTypes.MSI
		Else If TypeOf _Sdp.InstallableItems.Item(0) Is WindowsInstallerPatchItem Then
			_UpdateType = LocalUpdateTypes.MSP
		Else
			_UpdateType = Nothing
		End If
		
		Call LoadSdpData
		
		
		'We Do Not Need To Prompt The User For Files So Hide
		' The Initial Tab.
		If _TabsHidden.Count = 0 Then
			Me._TabsHidden.Add(Me.TabsImportUpdate.TabPages("TabIntro"))
			Me.TabsImportUpdate.TabPages.RemoveAt(Me.TabIntro.TabIndex)
		End If
		
		'Clear The Product And Vendor Combo Boxes And Load Them From
		' The Strings Created In The Main Form.  These Strings Are Created
		' As The Main Form Loads The Updates And Vendors Into The Tree View.
		Me.CboProduct.Items.Clear
		Me.CboProduct.Items.AddRange(Split(My.Forms.MainForm.Products ,VbNewLine))
		Me.CboVendor.Items.Clear
		Me.CboVendor.Items.AddRange(Split(My.Forms.MainForm.Vendors ,VbNewLine))
		
		Me.ValidateChildren
		
		Me.DialogResult = DialogResult.Cancel
		Return MyBase.ShowDialog() 'Return The Dialog Result.
	End Function
	
	'Clear The Product Combobox
	Sub ClearProducts
		Me.CboProduct.Items.Clear
	End Sub
	
	'Clear The Vendor Combobox
	Sub ClearVendors
		Me.CboVendor.Items.Clear
	End Sub
	
	'Allow The User To Edit The Metadata.
	Sub BtnMetaDataEditClick(Sender As Object, E As EventArgs)
		Msgbox ("Edit This XML At Your Own Risk.")
		TxtInstallableItemMetaData.ScrollBars = ScrollBars.Vertical
		TxtInstallableItemMetaData.ReadOnly = False
		BtnMetaDataEdit.Visible = False
	End Sub
	
	Sub BtnIsSupersededEditClick(Sender As Object, E As EventArgs)
		Msgbox ("Edit This XML At Your Own Risk.")
		TxtIsSuperceded_InstallableItem.ScrollBars = ScrollBars.Vertical
		TxtIsSuperceded_InstallableItem.ReadOnly = False
		BtnIsSupersededEdit.Visible = False
	End Sub
	
	'This Routine Goes To The Previous Tab And Hides Buttons Accordingly.
	Private Sub BtnPreviousClick(Sender As Object, E As EventArgs)
		Me.TabsImportUpdate.SelectedIndex = Me.TabsImportUpdate.SelectedIndex - 1
		
		'Show And Hide The Previous Button As Needed.
		If ( Me.TabsImportUpdate.SelectedIndex > 0 ) Then
			Me.BtnPrevious.Show
		Else
			Me.BtnPrevious.Hide
		End If
		
		'Change The Next Button'S Text As Needed.
		If ( Me.TabsImportUpdate.SelectedIndex < Me.TabsImportUpdate.TabCount ) Then
			Me.BtnNext.Show
			Me.BtnNext.Text = "Next"
			Me.BtnNext.Image = My.Resources.Forward.ToBitmap
			Me.BtnNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Else
			Me.BtnNext.Hide
		End If
		
		Me.ValidateChildren
	End Sub
	
	'This Routine Goes To The Next Tab And Hides Buttons Accordingly.
	Private Sub BtnNextClick(Sender As Object, E As EventArgs)
		'Perform Action Depending On Current Tab.
		' If The Action Could Not Be Performed Do Not Continue Forward.
		If Not PerformAction Then
			Exit Sub
			'User Has Selected The Finish Button So Close The Form.
		Else If Me.TabsImportUpdate.SelectedIndex = Me.TabsImportUpdate.TabCount - 1 Then
			Me.Close
			Exit Sub
		End If
		
		'Move To The Next Tab.
		Me.TabsImportUpdate.SelectedIndex = Me.TabsImportUpdate.SelectedIndex + 1
		
		'Show And Hide The Previous Button As Needed.
		If ( Me.TabsImportUpdate.SelectedIndex > 0 ) Then
			Me.BtnPrevious.Show
		Else
			Me.BtnPrevious.Hide
		End If
		
		'Change The Next Button'S Text As Needed.
		If ( Me.TabsImportUpdate.SelectedIndex < Me.TabsImportUpdate.TabCount - 1 ) Then
			Me.BtnNext.Show
			Me.BtnNext.Text = "Next"
		Else
			Me.BtnNext.Text = "Finish"
			Me.BtnNext.Image = Nothing
			Me.BtnNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		End If
		
		Me.ValidateChildren
	End Sub
	
	'If The User Cancels, Close The Form.
	Private Sub BtnCancelClick(Sender As Object, E As EventArgs)
		
		'Delete The Temporary SDP File And Ignore Any Errors.
		If Not String.IsNullOrEmpty(_SdpFilePath) Then
			Try
				System.IO.File.Delete(_SdpFilePath) 'Delete The SDP File.
			Catch
			End Try
		End If
		
		Me.Close
	End Sub
	
	'Prompt The User To Select A File, Set The Textbox And Next Button Accordingly.
	Private Sub BtnUpdateFileClick(Sender As Object, E As EventArgs)
		'Set File Filter.
		Me.DlgUpdateFile.Filter ="MSI Files|*.MSI|MSP Files|*.MSP|EXE Files|*.EXE"
		
		'Disable The MSI Path.
		Me.TxtMSIPath.Enabled = False
		
		'Show File Dialog And If User Has Chosen A File Continue.
		If Me.DlgUpdateFile.ShowDialog = VbOK Then
			Dim TmpFile As FileInfo = New FileInfo (DlgUpdateFile.FileName)
			
			Me.TxtUpdateFile.Text = TmpFile.Name
			Me.TxtUpdateFile.Tag = TmpFile
			
			'Set The Type Of Update And Enable The Next Button
			' Once A File Is Chosen.
			If TmpFile.Extension.ToLower.Equals(".exe") Then
				Me._UpdateType = LocalUpdateTypes.EXE
			ElseIf TmpFile.Extension.ToLower.Equals(".msi") Then
				Me._UpdateType = LocalUpdateTypes.MSI
				Me.TxtMSIPath.Enabled = True
			ElseIf TmpFile.Extension.ToLower.Equals(".msp") Then
				Me._UpdateType = LocalUpdateTypes.MSP
			End If
			
			
		Else 'User Didn'T Select A File.
			Me.TxtUpdateFile.Text = ""
			Me.TxtUpdateFile.Tag = Nothing
			Me.BtnNext.Enabled = False
			
		End If
		
		Me.ValidateChildren
	End Sub
	
	'Show The Return Codes Dialog.
	Sub LblReturnCodesClick(Sender As Object, E As EventArgs)
		ReturnCodesForm.Location = New Point(Me.Location.X + 100 , Me.Location.Y + 100)
		ReturnCodesForm.ShowDialog(CType(_Sdp.InstallableItems.Item(0), CommandLineItem).ReturnCodes)
	End Sub
	
	'Manage The List Of Updates That This Update Supersedes.
	Sub LblSupersedesClick(Sender As Object, E As EventArgs)
		SupersededUpdatesForm.Location = New Point(Me.Location.X + 100 , Me.Location.Y + 100)
		
		If _Revision Then
			
			If _Sdp.SupersededPackages.Count = 0 OrElse _
				SupersededUpdatesForm.GetUpdates.Count > 0 Then
				SupersededUpdatesForm.ShowDialog
			Else
				SupersededUpdatesForm.ShowDialog(_Sdp.SupersededPackages)
				
				'If The User Has Removed All The Superseded Updates Then Clear The SDP Object.
				If SupersededUpdatesForm.GetUpdates.Count = 0 Then
					_Sdp.SupersededPackages.Clear
				End If
			End If
		Else
			SupersededUpdatesForm.ShowDialog
		End If
	End Sub
	
	'Manage The List Of Updates That This Update Requires Before Installing.
	Sub LblPrerequisitesClick(Sender As Object, E As EventArgs)
		
		PrerequisiteUpdatesForm.Location = New Point(Me.Location.X + 100 , Me.Location.Y + 100)
		
		If _Revision Then
			If _Sdp.Prerequisites.Count = 0 OrElse _
				PrerequisiteUpdatesForm.GetUpdates.Count > 0 Then
				PrerequisiteUpdatesForm.ShowDialog
			Else
				PrerequisiteUpdatesForm.ShowDialog(_Sdp.Prerequisites)
				
				'If The User Has Removed All The Superseded Updates Then Clear The SDP Object.
				If PrerequisiteUpdatesForm.GetUpdates.Count = 0 Then
					_Sdp.Prerequisites.Clear
				End If
			End If
		Else
			PrerequisiteUpdatesForm.ShowDialog
		End If
		
	End Sub
	
	
	'Validate The Form And Return A Boolean Indicating
	' If The Info Is Valid Or Not.
	'	Function ValidateForm As Boolean
	'		Dim Invalid As Boolean = False
	'
	'		Select Case TabsImportUpdate.SelectedTab.Name
	'				'Verify A File Has Been Given.
	'			Case "TabIntro"
	'				If TxtUpdateFile.Tag Is Nothing Then
	'					BtnNext.Enabled = False
	'					Return False
	'				End If
	'
	'				'Verify That A Vendor And Product Name Have Been Given.
	'			Case "TabPackageInfo"
	'
	'				'				'Verify Title.
	'				'				If String.IsNullOrEmpty(Me.TxtPackageTitle.Text) Then
	'				'					Me.PicTitle.Image = My.Resources.Attention.ToBitmap
	'				'					Invalid = True
	'				'				Else
	'				'					Me.PicTitle.Image = My.Resources.Check.ToBitmap
	'				'				End If
	'				'
	'				'				'Verify Description.
	'				'				If String.IsNullOrEmpty(Me.TxtDescription.Text) Then
	'				'					Me.PicDescription.Image = My.Resources.Attention.ToBitmap
	'				'					Invalid = True
	'				'				Else
	'				'					Me.PicDescription.Image = My.Resources.Check.ToBitmap
	'				'				End If
	'				'
	'				'				'Verify Classification.
	'				'				If Me.CboClassification.SelectedIndex = -1 Then
	'				'					Me.PicClassification.Image = My.Resources.Attention.ToBitmap
	'				'					Invalid = True
	'				'				Else
	'				'					Me.PicClassification.Image = My.Resources.Check.ToBitmap
	'				'				End If
	'				'
	'				'				'Enable Severity Combo If Bulletin Id Is Entered.
	'				'				If String.IsNullOrEmpty(Me.TxtBulletinID.Text) Then
	'				'					Me.CboSeverity.Enabled = False
	'				'				Else
	'				'					Me.CboSeverity.Enabled = True
	'				'				End If
	'				'
	'				'				'Verify Vendor.
	'				'				If String.IsNullOrEmpty(Me.CboVendor.Text) OrElse UCase(CboVendor.Text) = "MICROSOFT" Then
	'				'					If UCase(CboVendor.Text) = "MICROSOFT" Then Msgbox ("Vendor Cannot Be Microsoft")
	'				'					Me.PicVendor.Image = My.Resources.Attention.ToBitmap
	'				'					Invalid = True
	'				'				Else
	'				'					Me.PicVendor.Image = My.Resources.Check.ToBitmap
	'				'				End If
	'				'
	'				'				'Verify Product.
	'				'				If String.IsNullOrEmpty(Me.CboProduct.Text) Then
	'				'					Me.PicProduct.Image = My.Resources.Attention.ToBitmap
	'				'					Invalid = True
	'				'				Else
	'				'					Me.PicProduct.Image = My.Resources.Check.ToBitmap
	'				'				End If
	'				'
	'				'				'Verify Impact.
	'				'				If Me.CboImpact.SelectedIndex = -1 Then
	'				'					Me.PicImpact.Image = My.Resources.Attention.ToBitmap
	'				'					Invalid = True
	'				'				Else
	'				'					Me.PicImpact.Image = My.Resources.Check.ToBitmap
	'				'				End If
	'				'
	'				'				'Verify Reboot Behavior.
	'				'				If Me.CboRebootBehavior.SelectedIndex = -1 Then
	'				'					Me.PicReboot.Image = My.Resources.Attention.ToBitmap
	'				'					Invalid = True
	'				'				Else
	'				'					Me.PicReboot.Image = My.Resources.Check.ToBitmap
	'				'				End If
	'
	'				'If A Problem Was Found Then Exit The Routine And Do Not Advance.
	'				If Invalid Then
	'					Me.BtnNext.Enabled = False
	'					Return False
	'				End If
	'			Case "TabIsInstalled"
	'			Case "TabIsInstallable"
	'			Case "TabIsSuperceded"
	'			Case "TabMetaData"
	'			Case "TabSummary"
	'		End Select 'ValidateForm
	'
	'		'Enable The User To Continue And Move Forward.
	'		Me.BtnNext.Enabled = True
	'		Return True
	'	End Function
	
	'Perform Action According To The Currently Selected Tab.
	' Return A Boolean Depending Upon The Success Of The Action.
	Function PerformAction As Boolean
		
		'Import The File And Set The Appropriate Fields If This Isn'T A Revision.
		Select Case TabsImportUpdate.SelectedTab.Name
			Case "tabIntro"
				'Don'T Do Anything If This Is A Revision.
				If Not Me._Revision Then
					'Create New Software Distribution Package.
					_Sdp = New SoftwareDistributionPackage
					
					'Populate SDP From Installation File Based On Its Type.
					Try
						Select Case _UpdateType
							Case LocalUpdateTypes.MSI
								
								_Sdp.PopulatePackageFromWindowsInstaller(DirectCast(Me.TxtUpdateFile.Tag, FileInfo).FullName)
								
								'Create The Default IsInstallable And IsInstalled Rules For MSI Packages.
								If _Sdp.InstallableItems.Count > 0
									Dim TmpGuid As String = CType(_Sdp.InstallableItems.Item(0), WindowsInstallerItem).WindowsInstallerProductCode.ToString
									IsInstalledRules.Clear
									IsInstalledRules.Rule = "<msiar:MsiProductInstalled ProductCode=""{" & TmpGuid & "}"" />"
									IsInstallableRules.Clear
									IsInstallableRules.Rule = "<lar:Not ><msiar:MsiProductInstalled ProductCode=""{" & TmpGuid & "}"" /></lar:Not>"
								End If
								
								'Set the package type to application.
								_Sdp.PackageType = PackageType.Application
								
							Case LocalUpdateTypes.MSP
								_Sdp.PopulatePackageFromWindowsInstallerPatch(DirectCast(Me.TxtUpdateFile.Tag,FileInfo).FullName)
								
								'Set the package type to update.
								_Sdp.PackageType  = PackageType.Update
							Case LocalUpdateTypes.EXE
								'Use A Wrapped MSI File If A Relative MSI Path Was Given.
								If String.IsNullOrEmpty(Me.TxtMSIPath.Text) Then
									_Sdp.PopulatePackageFromExe(DirectCast(Me.TxtUpdateFile.Tag,FileInfo).FullName)
									
									'Clear The Default Installable Item Rules Created By The API.
									'This Puts The User In Complete Control Of The EXE Logic.
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
						
						Call LoadSdpData 'Load The SDP Data Into The Form.
						
						'If Any Of The Additional Files Are MST Files Then Setup The Transform Command Line Automatically.
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
						
						'Catch Any Exception Related To The Creation Of The SDP.
					Catch X As InvalidOperationException
						Msgbox ("Could Not Create Software Distribution Package:" & VbNewline & _
							"InvalidOperationException: " & X.Message)
					Catch X As ArgumentNullException
						Msgbox ("Could Not Create Software Distribution Package:" & VbNewline & _
							"ArgumentNullException: " & X.Message)
					Catch X As ArgumentException
						Msgbox ("Could Not Create Software Distribution Package:" & VbNewline & _
							"ArgumentException: " & X.Message)
					Catch X As FileNotFoundException
						Msgbox ("Could Not Create Software Distribution Package:" & VbNewline & _
							"FileNotFoundException: " & X.Message)
					Catch X As InvalidDataException
						Msgbox ("Could Not Create Software Distribution Package:" & VbNewline & _
							"InvalidDataException: " & X.Message)
					Catch X As Win32Exception
						Msgbox ("Could Not Create Software Distribution Package:" & VbNewline & _
							"Win32Exception: " & X.Message)
					End Try
				End If 'If This Is A Revision.
				
			Case "tabPackageInfo"
				Try
					'Save The Info From The Form Into The SDP Object.
					_Sdp.PackageType = DirectCast(Me.cboPackageType.SelectedIndex, PackageType)
					_Sdp.Title = Me.TxtPackageTitle.Text
					_Sdp.Description = Me.TxtDescription.Text
					_Sdp.PackageUpdateClassification = DirectCast(Me.CboClassification.SelectedIndex, PackageUpdateClassification)
					_Sdp.SecurityBulletinId = Me.TxtBulletinID.Text
					
					'Set The Security Rating Only If A Bulletin ID Has Been Entered.
					If Not String.IsNullOrEmpty(Me.TxtBulletinID.Text) Then
						_Sdp.SecurityRating = DirectCast(Me.CboSeverity.SelectedIndex, SecurityRating)
					Else
						_Sdp.SecurityRating = Nothing
					End If
					
					_Sdp.VendorName = Me.CboVendor.Text
					
					'If A Product Name Exists Then Change It.  Otherwise Add A New One To The List.
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
					
					'If An Additional Info URL Exists Then Change It.  Otherwise Add A New One To The List.
					If _Sdp.AdditionalInformationUrls.Count > 0 And Not String.IsNullOrEmpty(Me.TxtSupportURL.Text) Then
						_Sdp.AdditionalInformationUrls.Item(0) = New Uri(Me.TxtMoreInfoURL.Text)
					Else If Not String.IsNullOrEmpty(Me.TxtSupportURL.Text)
						_Sdp.AdditionalInformationUrls.Add(New Uri(Me.TxtMoreInfoURL.Text))
					End If
					
					'If There Is An Installable Item, Save It'S Values As Well.
					If _Sdp.InstallableItems.Count > 0 Then
						
						_Sdp.InstallableItems.Item(0).InstallBehavior.Impact = DirectCast(Me.CboImpact.SelectedIndex, InstallationImpact)
						_Sdp.InstallableItems.Item(0).InstallBehavior.RebootBehavior = DirectCast(Me.CboRebootBehavior.SelectedIndex, RebootBehavior)
						
						'If There Is A Command Line String Then Set It Based On The Update Type Otherwise Set It To Null.
						'The Type Of The InstallableItems Objects Depends On The Type Of File We Populated
						' The SDP With.  Therefore, We Need To Cast The InstallableItem Accordingly
						' So That We Can Add The Command Line String Using The Right Property Name.
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
					End If 'There Is At Least One InstallableItme Object.
					
					
					'Create Temporary Prerequisite Group And Add Updates To It.
					Dim TmpPrerequisiteGroup As PrerequisiteGroup = New PrerequisiteGroup
					For Each TmpRow As DataGridViewRow In PrerequisiteUpdatesForm.GetUpdates
						TmpPrerequisiteGroup.Ids.Add(DirectCast(TmpRow.Cells("Id").Value, Guid))
					Next
					
					'If The Temporary Group Has Anything, Add It To The SDP.
					_Sdp.Prerequisites.Clear
					If TmpPrerequisiteGroup.Ids.Count > 0 Then
						_Sdp.Prerequisites.Add(TmpPrerequisiteGroup)
					End If
					
					'Add The Superceded Updates.
					_Sdp.SupersededPackages.Clear
					For Each TmpRow As DataGridViewRow In SupersededUpdatesForm.GetUpdates
						_Sdp.SupersededPackages.Add(DirectCast(TmpRow.Cells("Id").Value, Guid))
					Next
					
				Catch X As UriFormatException
					Msgbox("UriFormatException:Could Not Save The Update Information." & VbNewline & X.Message)
					Return False
				Catch X As Exception
					Msgbox("Exception:Could Not Save The Update Information." & VbNewline & X.Message)
					Return False
				End Try
			Case "tabIsInstalled"
				'If There Are Rules Then Add Them To The IsInstallable Property.
				If Not String.IsNullOrEmpty(IsInstalledRules.Rule) Then
					_Sdp.IsInstalled = IsInstalledRules.Rule
				Else
					_Sdp.IsInstalled = Nothing
				End If
				
				'If The User Had Edited The Installable Item Level XML Then Save Their Changes.
				If IsInstalledRules.ApplicibilityRuleEdited Then
					If Not String.IsNullOrEmpty(IsInstalledRules.ApplicibilityRule) Then
						_Sdp.InstallableItems(0).IsInstalledApplicabilityRule = IsInstalledRules.ApplicibilityRule
					Else
						_Sdp.InstallableItems(0).IsInstalledApplicabilityRule = Nothing
					End If
				End If
			Case "tabIsInstallable"
				'If There Are Rules Then Add Them To The IsInstallable Property.
				If Not String.IsNullOrEmpty(IsInstallableRules.Rule) Then
					_Sdp.IsInstallable = IsInstallableRules.Rule
				Else
					_Sdp.IsInstallable = Nothing
				End If
				
				'If The User Had Edited The Installable Item Level XML Then Save Their Changes.
				If IsInstallableRules.ApplicibilityRuleEdited Then
					If Not String.IsNullOrEmpty(IsInstallableRules.ApplicibilityRule) Then
						_Sdp.InstallableItems(0).IsInstallableApplicabilityRule = IsInstallableRules.ApplicibilityRule
					Else
						_Sdp.InstallableItems(0).IsInstallableApplicabilityRule = Nothing
					End If
				End If
			Case "tabIsSuperseded"
				'If The User Had Edited The Installable Item Level XML Then Save Their Changes.
				If Not TxtIsSuperceded_InstallableItem.ReadOnly Then
					If Not String.IsNullOrEmpty(TxtIsSuperceded_InstallableItem.Text) Then
						_Sdp.InstallableItems(0).IsSupersededApplicabilityRule = TxtIsSuperceded_InstallableItem.Text
					Else
						_Sdp.InstallableItems(0).IsSupersededApplicabilityRule = Nothing
					End If
				End If
			Case "tabMetaData"
				'If The User Had Edited The Metadata Then Save Their Changes.
				If Not TxtInstallableItemMetaData.ReadOnly Then
					If Not String.IsNullOrEmpty(TxtInstallableItemMetaData.Text) Then
						_Sdp.InstallableItems(0).ApplicabilityMetadata = TxtInstallableItemMetaData.Text
					Else
						_Sdp.InstallableItems(0).ApplicabilityMetadata = Nothing
					End If
				End If
				
				'Save The SdpFile And Then Load It Into The Summary Field.
				Try
					_SdpFilePath = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), _Sdp.PackageId.ToString() & ".Xml")
					_Sdp.Save(_SdpFilePath)
					Dim Sr As New IO.StreamReader(_SdpFilePath)
					Me.TxtSummary.Text = Sr.ReadToEnd()
					Sr.Close()
					Me.TxtSummary.Text = IndentXMLString(Me.TxtSummary.Text)
					Me.TxtSummary.DeselectAll
				Catch X As XmlException
					Msgbox("XmlException: The XML For The SDP Is Invalid." & VbNewLine & X.Message)
					Return False
				Catch X As XmlSchemaException
					Msgbox("XmlSchemaException: The XML For The SDP Is Invalid." & VbNewLine & X.Message)
					Return False
				End Try
				
				
			Case "tabSummary" 'Publish The Package.
				'Try Publishing The Update And Catch Any Errors.
				
				
				'If The User Wants To Export The SDP Then Prompt For A Filename.
				If ChkExportSdp.Checked Then
					'Set Default Extention.
					DlgExportSdp.Filter = "XML Files|*.XML"
					DlgExportSdp.DefaultExt = ".XML"
					DlgExportSdp.AddExtension = True
					DlgExportSdp.FileName = _Sdp.Title & ".Xml"
					
					'Show Dialog And Copy The File.
					If DlgExportSdp.ShowDialog = VbOK Then
						Msgbox ( _SdpFilePath )
						My.Computer.FileSystem.CopyFile( _SdpFilePath, DlgExportSdp.FileName, True)
					End If
				End If
				
				If _Revision Then 'This Is A Revision.
					Me.Cursor = Cursors.WaitCursor
					
					If ConnectionManager.RevisePackage(_Sdp) Then
						Msgbox ("Package Successfully Revised")
					Else
						Msgbox ("Package Was Not Revised")
					End If
					Me.Cursor = Cursors.Arrow
					Me.DialogResult = DialogResult.OK
					
					Return True
					
				Else 'This Is A New Update.
					
					'Add The Files To A New IList.
					Dim FileList As IList(Of Object) = New List(Of Object)
					FileList.Add(TxtUpdateFile.Tag) ' Add Main Update File.
					
					'Add Additional Files And Directories.
					For Each TmpRow As DataGridViewRow In DgvAdditionalFiles.Rows
						FileList.Add(TmpRow.Cells("FileObject").Value)
					Next
					
					Me.Cursor = Cursors.WaitCursor
					
					'Publish Package According The Meta Data Only Checkbox.
					Dim Result As Boolean = False
					If CboMetadataOnly.Checked Then
						Result = ConnectionManager.PublishPackageMetaData(_Sdp)
					Else
						Result = ConnectionManager.PublishPackage(_Sdp,FileList)
					End If
					
					Me.Cursor = Cursors.Arrow
					
					If Result Then
						Msgbox ("Package Successfully Published")
					Else
						Msgbox ("Package Was Not Published")
					End If
					
					Me.DialogResult = DialogResult.OK
					Return True
				End If
				Return False 'If We Got This Far We Failed.
		End Select
		
		Return True 'If We Got This Far We Succeeded.
	End Function 'PerformAction
	
	
	'This Rouding Loads The SDP Passed Into The Form And
	' Loads The Form With The Appropriate Data.  This Is The First
	' Step In Revising And Existing Update.
	Sub LoadSdpData
		
		If Not _Sdp Is Nothing Then 'Make Sure The Sdp Object Is Instantiated.
			
			'Load The Basic Info Into The Form.
			Me.cboPackageType.SelectedIndex = DirectCast(_Sdp.PackageType, Integer)
			Me.TxtPackageTitle.Text = _Sdp.Title
			Me.TxtDescription.Text = _Sdp.Description
			Me.CboClassification.SelectedIndex = _Sdp.PackageUpdateClassification
			Me.TxtBulletinID.Text = _Sdp.SecurityBulletinId
			Me.CboSeverity.SelectedIndex = _Sdp.SecurityRating
			Me.CboVendor.Text = _Sdp.VendorName
			If _Sdp.ProductNames.Count > 0 Then Me.CboProduct.Text = _Sdp.ProductNames(0)
			Me.TxtArticleID.Text = _Sdp.KnowledgebaseArticleId
			If _Sdp.CommonVulnerabilitiesIds.Count > 0 Then Me.TxtCVEID.Text = _Sdp.CommonVulnerabilitiesIds.Item(0)
			If Not _Sdp.SupportUrl Is Nothing Then Me.TxtSupportURL.Text = _Sdp.SupportUrl.ToString
			If _Sdp.AdditionalInformationUrls.Count > 0 Then Me.TxtMoreInfoURL.Text = _Sdp.AdditionalInformationUrls.Item(0).ToString
			
			If _Sdp.InstallableItems.Item(0).UninstallBehavior Is Nothing Then
				Me.TxtUninstall.Text = "False"
			Else
				Me.TxtUninstall.Text = "True"
			End If
			
			'Load The Installable Item Info
			If _Sdp.InstallableItems.Count > 0 Then 'There'S An Installable Item.
				
				Me.CboImpact.SelectedIndex = _Sdp.InstallableItems.Item(0).InstallBehavior.Impact
				Me.CboRebootBehavior.SelectedIndex = _Sdp.InstallableItems.Item(0).InstallBehavior.RebootBehavior
				
				'Set The Command Line Based On The Update Type.
				Select Case _UpdateType
					Case LocalUpdateTypes.EXE
						Me.TxtCommandLine.Text = CType(_Sdp.InstallableItems.Item(0), CommandLineItem).Arguments
					Case LocalUpdateTypes.MSI
						Me.TxtCommandLine.Text = CType(_Sdp.InstallableItems.Item(0), WindowsInstallerItem).InstallCommandLine
					Case LocalUpdateTypes.MSP
						Me.TxtCommandLine.Text = CType(_Sdp.InstallableItems.Item(0), WindowsInstallerPatchItem).InstallCommandLine
				End Select
				
				'Load The Installable Item Level Applicability Rules.
				Me.IsInstalledRules.ApplicibilityRule = _Sdp.InstallableItems(0).IsInstalledApplicabilityRule
				Me.IsInstallableRules.ApplicibilityRule = _Sdp.InstallableItems(0).IsInstallableApplicabilityRule
				Me.TxtIsSuperceded_InstallableItem.Text = _Sdp.InstallableItems(0).IsSupersededApplicabilityRule
				Me.TxtInstallableItemMetaData.Text = _Sdp.InstallableItems(0).ApplicabilityMetadata
			End If 'There Is A Installable Item.
			
			'Note: In Previous Versions Of LUP We Didn'T Check To See If The IsInstalled Or
			' IsInstallable Members Were Empty And The SDP Was Set With These Members Instantiated
			' To An Empty String.  If We Detect These When Loading Then Set The Member To Nothing.
			
			'Load The Package'S IsInstalled Rules.
			If Not String.IsNullOrEmpty(_Sdp.IsInstalled) Then
				IsInstalledRules.Rule = _Sdp.IsInstalled
			Else
				_Sdp.IsInstalled = Nothing
			End If
			
			'Load The Package'S IsInstallable Rules.
			If Not String.IsNullOrEmpty(_Sdp.IsInstallable) Then
				IsInstallableRules.Rule = _Sdp.IsInstallable
			Else
				_Sdp.IsInstallable = Nothing
			End If
			
		End If 'SDP Is Not Instantiated.
	End Sub 'LoadSDPData.
	
	'This Function Formats The SDP'S XML Into Something More
	' Readable By Indenting The Lines Appropriately.
	' It Is Directly Based Off Les Smith'S Example Found Here:
	' Http://Www.Knowdotnet.Com/Articles/Indentxml.Html
	<System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")> _
		Shared Function IndentXmlString(Xml As String) As String
		
		Dim Ms As MemoryStream = New MemoryStream()
		' Create A XMLTextWriter That Will Send Its Output To A Memory Stream (File).
		Dim Xtw As XmlTextWriter = New XmlTextWriter(Ms, Encoding.Unicode)
		Dim Doc As XmlDocument = New XmlDocument()
		
		Try
			
			' Load The Unformatted XML Text String Into An Instance
			' Of The XML Document Object Model (DOM).
			Doc.LoadXml(Xml)
			
			' Set The Formatting Property Of The XML Text Writer To Indented
			' The Text Writer Is Where The Indenting Will Be Performed.
			Xtw.Formatting = Formatting.Indented
			
			' Write Dom Xml To The Xmltextwriter.
			Doc.WriteContentTo(Xtw)
			' Flush The Contents Of The Text Writer
			' To The Memory Stream, Which Is Simply A Memory File.
			Xtw.Flush()
			
			' Set To Start Of The Memory Stream (File).
			Ms.Seek(0, SeekOrigin.Begin)
			' Create A Reader To Read The Content Of The Memory Stream (File).
			Dim Sr  As StreamReader = New StreamReader(Ms)
			' Return The Formatted String To Caller.
			Return Sr.ReadToEnd()
			
		Catch X As OutOfMemoryException
			MessageBox.Show("Out Of Memory Exception: " & VbNewline & X.Message)
		Catch X As IOException
			MessageBox.Show("IO Exception: " & VbNewline & X.Message)
		Catch X As ArgumentOutOfRangeException
			MessageBox.Show("Argument Out Of Range Exception: " & VbNewline & X.Message)
		Catch X As ArgumentNullException
			MessageBox.Show("Argument Null Exception: " & VbNewline & X.Message)
		Catch X As ArgumentException
			MessageBox.Show("Argument Exception: " & VbNewline & X.Message)
		Catch X As ObjectDisposedException
			MessageBox.Show("Object Disposed Exception: " & VbNewline & X.Message)
		Catch X As XMLException
			MessageBox.Show("XML Exception: " & VbNewline & X.Message)
		End Try
		Return String.Empty 'If We Got Here There Was An Exception.
	End Function
	
	'Prompt The User For A File And Add It To The Collection.
	Private Sub BtnAddFileClick(Sender As Object, E As EventArgs)
		
		'Set File Filter.
		DlgUpdateFile.Filter = ""
		
		'Show Dialog And Load The File Into The DGV If The User Chose A File.
		If Me.DlgUpdateFile.ShowDialog(Me) = VbOK Then
			Dim TmpFile As FileInfo = New FileInfo(DlgUpdateFile.FileName)
			Dim TmpRow As Integer= DgvAdditionalFiles.Rows.Add(New String() {TmpFile.Name })
			DgvAdditionalFiles.Rows.Item(TmpRow).Cells("FileObject").Value = TmpFile
		End If
	End Sub
	
	Sub BtnAddDirClick(Sender As Object, E As EventArgs)
		
		If DlgUpdateDir.ShowDialog(Me) = VbOK Then
			Dim TmpDir As DirectoryInfo = New DirectoryInfo(DlgUpdateDir.SelectedPath)
			Dim TmpRow As Integer = DgvAdditionalFiles.Rows.Add(New String() {TmpDir.Name & " (Dir)" })
			DgvAdditionalFiles.Rows.Item(TmpRow).Cells("FileObject").Value = TmpDir
		End If
	End Sub
	
	'Remove The File From The Files DGV.
	Private Sub DgvAdditionalFilesCellContentClick(Sender As Object, E As DataGridViewCellEventArgs)
		If Me.DgvAdditionalFiles.Columns(E.ColumnIndex).Name = "RemoveFile" Then
			Me.DgvAdditionalFiles.Rows.RemoveAt(E.RowIndex)
		End If
	End Sub
	
	#End Region
	
	#Region "Validation"
	'A Generic Validated Routine That Sets The Sender Control'S As Validated
	Sub ControlValidated(Sender As Object, E As EventArgs)
		Me.ErrorProviderUpdate.SetError(DirectCast(Sender, Control),"")
	End Sub
	
	'A Generic Validating Routine That Verify The Sender Control'S Have Something Entered.
	Sub ControlValidating(Sender As Object, E As CancelEventArgs)
		Try
			If TypeOf Sender Is TextBox OrElse TypeOf Sender Is ComboBox
				
				If DirectCast(Sender, Control).Text.Length = 0 Then
					Me.ErrorProviderUpdate.SetError(DirectCast(Sender, Control), "Please Enter A Value.")
					E.Cancel = True
				End If
			End If
			
			Call ValidateTabControl() 'Validate The Current Tab.
		Catch Ex As Exception
			MsgBox(Ex.Message)
		End Try
	End Sub
	
	'Validate The Current Tab And Enable Or Disable The Next Buttons Accordingly.
	Sub ValidateTabControl()
		Try
			
			Dim Invalid As Boolean = False
			
			Select Case tabsImportUpdate.SelectedTab.Name
					'Verify A File Has Been Given.
				Case "tabIntro"
					If Not String.IsNullOrEmpty(Me.ErrorProviderUpdate.GetError(TxtUpdateFile)) Then
						Invalid = True
					End If
					
					'Verify That A Vendor And Product Name Have Been Given.
				Case "tabPackageInfo"
					
					'Verify That No Errors Are Shown.
					If Not String.IsNullOrEmpty(Me.ErrorProviderUpdate.GetError(Me.TxtPackageTitle)) OrElse _
						Not String.IsNullOrEmpty(Me.ErrorProviderUpdate.GetError(Me.TxtDescription)) OrElse _
						Not String.IsNullOrEmpty(Me.ErrorProviderUpdate.GetError(Me.CboClassification)) OrElse _
						Not String.IsNullOrEmpty(Me.ErrorProviderUpdate.GetError(Me.CboVendor))  OrElse _
						Not String.IsNullOrEmpty(Me.ErrorProviderUpdate.GetError(Me.CboProduct)) OrElse _
						Not String.IsNullOrEmpty(Me.ErrorProviderUpdate.GetError(Me.CboImpact)) OrElse _
						Not String.IsNullOrEmpty(Me.ErrorProviderUpdate.GetError(Me.CboRebootBehavior))
						Invalid = True
					End If
					
				Case "tabIsInstalled"
				Case "tabIsInstallable"
				Case "tabIsSuperceded"
				Case "tabMetaData"
				Case "tabSummary"
			End Select
			
			'If A Problem Was Found Then Exit Then Disable The Next Button.
			If Invalid Then
				Me.BtnNext.Enabled = False
			Else
				Me.BtnNext.Enabled = True
			End If
			
		Catch Ex As Exception
			MsgBox(Ex.Message)
		End Try
	End Sub
	
	'Enable And Validate The Severity Combo Only If Something Is Entered For The Bulletin Field.
	Sub TxtBulletinIDValidating(Sender As Object, E As CancelEventArgs)
		If TxtBulletinID.Text.Length = 0 Then
			Me.CboSeverity.Enabled = False
		Else
			Me.CboSeverity.Enabled = True
			Me.ErrorProviderUpdate.SetError(Me.CboSeverity, "")
		End If
	End Sub
	
	'Validate The Form Based On Combobox Actions.
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
