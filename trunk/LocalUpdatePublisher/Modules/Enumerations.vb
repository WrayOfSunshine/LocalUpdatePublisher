' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' Enumerations
' A central module to contain the various enumerations
' the program uses.
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 11/12/2009
' Time: 11:10 AM
' This is mostly the work of kdixon

Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Microsoft.UpdateServices.Administration
Imports System.Drawing

Public Enum LocalUpdateTypes
MSI
MSP
EXE
End Enum

Public Enum RuleTypes
WindowsVersion = 0
WindowsLanguage
ProcessorArchitecture
FileExists
FileExistsWithRegistry
FileVersion
FileVersionWithRegistry
FileCreation
FileCreationWithRegistry
FileModified
FileModifiedWithRegistry
FileSize
FileSizeWithRegistry
RegistryKeyExists
RegistryValueExists
RegistryDWORDValue
RegistryExpandSzValue
RegistrySzValue
RegistryVersionInSz
WMIQuery
MsiProductInstalled
MsiPatchInstalled
MsiComponentInstalled
MsiFeatureInstalled
End Enum

Public Enum SavedRulesFormUses
Load
Manage
Import
Export
End Enum

Public Enum CSIDL
NONE = -1
COMMON_ADMINTOOLS = &H2F
COMMON_ALTSTARTUP = &H1E
COMMON_APPDATA = &H23
COMMON_DESKTOPDIRECTORY = &H19
COMMON_DOCUMENTS = &H2E
COMMON_FAVORITES = &H1F
COMMON_MUSIC = &H35
COMMON_OEM_LINKS = &H3A
COMMON_PICTURES = &H36
COMMON_PROGRAMS = &H17
COMMON_STARTMENU = &H16
COMMON_STARTUP = &H18
COMMON_TEMPLATES = &H2D
COMMON_VIDEO = &H37
CONTROLS = &H3
DRIVES = &H11
FONTS = &H14
PRINTERS = &H4
PROFILES = &H3E
PROGRAM_FILES = &H26
PROGRAM_FILES_COMMON = &H2B
PROGRAM_FILES_COMMONX86 = &H2C
PROGRAM_FILESX86 = &H2A
PROGRAMS = &H2
SYSTEM = &H25
SYSTEMX86 = &H29
WINDOWS = &H24
End Enum


Public Module EnumExtensions
	
	<System.Runtime.CompilerServices.Extension> _
		Public Function ToDisplayString(r As RuleTypes) As String
		Select Case r
			Case RuleTypes.WindowsVersion
				Return globalRM.GetString("rule_windows_version")
				
			Case RuleTypes.WindowsLanguage
				Return globalRM.GetString("rule_windows_language")
				
			Case RuleTypes.ProcessorArchitecture
				Return globalRM.GetString("rule_processor_architecture")
				
			Case RuleTypes.FileExists
				Return globalRM.GetString("rule_file_exists")
				
			Case RuleTypes.FileExistsWithRegistry
				Return globalRM.GetString("rule_file_exists_with_registry")
				
			Case RuleTypes.FileVersion
				Return globalRM.GetString("rule_file_version")
				
			Case RuleTypes.FileVersionWithRegistry
				Return globalRM.GetString("rule_file_version_with_registry")
				
			Case RuleTypes.FileCreation
				Return globalRM.GetString("rule_file_creation")
				
			Case RuleTypes.FileCreationWithRegistry
				Return globalRM.GetString("rule_file_creation_with_registry")
				
			Case RuleTypes.FileModified
				Return globalRM.GetString("rule_file_modified")
				
			Case RuleTypes.FileModifiedWithRegistry
				Return globalRM.GetString("rule_file_modified_with_registry")
				
			Case RuleTypes.FileSize
				Return globalRM.GetString("rule_file_size")
				
			Case RuleTypes.FileSizeWithRegistry
				Return globalRM.GetString("rule_file_size_with_registry")
				
			Case RuleTypes.RegistryKeyExists
				Return globalRM.GetString("rule_registry_key_exists")
				
			Case RuleTypes.RegistryValueExists
				Return globalRM.GetString("rule_registry_value_exists")
				
			Case RuleTypes.RegistryDWORDValue
				Return globalRM.GetString("rule_registry_DWORD_value")
				
			Case RuleTypes.RegistryExpandSzValue
				Return globalRM.GetString("rule_registry_expand_SZ_value")
				
			Case RuleTypes.RegistrySzValue
				Return globalRM.GetString("rule_registry_SZ_value")
				
			Case RuleTypes.RegistryVersionInSz
				Return globalRM.GetString("rule_registry_version_in_SZ")
				
			Case RuleTypes.WMIQuery
				Return globalRM.GetString("rule_WMI_query")
				
			Case RuleTypes.MsiProductInstalled
				Return globalRM.GetString("rule_MSI_product")
				
			Case RuleTypes.MsiPatchInstalled
				Return globalRM.GetString("rule_MSI_patch")
				
			Case RuleTypes.MsiComponentInstalled
				Return globalRM.GetString("rule_MSI_component")
				
			Case RuleTypes.MsiFeatureInstalled
				Return globalRM.GetString("rule_MSI_feature")
			Case Else
				
				Return ""
		End Select
	End Function
	
	<System.Runtime.CompilerServices.Extension> _
		Public Function ToXmlTag(r As RuleTypes) As String
		Select Case r
			Case RuleTypes.WindowsVersion
				Return "bar:WindowsVersion"
				
			Case RuleTypes.WindowsLanguage
				Return "bar:WindowsLanguage"
				
			Case RuleTypes.ProcessorArchitecture
				Return "bar:Processor"
				
			Case RuleTypes.FileExists
				Return "bar:FileExists"
				
			Case RuleTypes.FileExistsWithRegistry
				Return "bar:FileExistsPrependRegSz"
				
			Case RuleTypes.FileVersion
				Return "bar:FileVersion"
				
			Case RuleTypes.FileVersionWithRegistry
				Return "bar:FileVersionPrependRegSz"
				
			Case RuleTypes.FileCreation
				Return "bar:FileCreated"
				
			Case RuleTypes.FileCreationWithRegistry
				Return "bar:FileCreatedPrependRegSz"
				
			Case RuleTypes.FileModified
				Return "bar:FileModified"
				
			Case RuleTypes.FileModifiedWithRegistry
				Return "bar:FileModifiedPrependRegSz"
				
			Case RuleTypes.FileSize
				Return "bar:FileSize"
				
			Case RuleTypes.FileSizeWithRegistry
				Return "bar:FileSizePrependRegSz"
				
			Case RuleTypes.RegistryKeyExists
				Return "bar:RegKeyExists"
				
			Case RuleTypes.RegistryValueExists
				Return "bar:RegValueExists"
				
			Case RuleTypes.RegistryDWORDValue
				Return "bar:RegDword"
				
			Case RuleTypes.RegistryExpandSzValue
				Return "bar:RegExpandSz"
				
			Case RuleTypes.RegistrySzValue
				Return "bar:RegSz"
				
			Case RuleTypes.RegistryVersionInSz
				Return "bar:RegSzToVersion"
				
			Case RuleTypes.WMIQuery
				Return "bar:WmiQuery"
				
			Case RuleTypes.MsiProductInstalled
				Return "msiar:MsiProductInstalled"
				
			Case RuleTypes.MsiPatchInstalled
				Return "msiar:MsiPatchInstalledForProduct"
				
			Case RuleTypes.MsiComponentInstalled
				Return "msiar:MsiComponentInstalledForProduct"
				
			Case RuleTypes.MsiFeatureInstalled
				Return "msiar:MsiFeatureInstalledForProduct"
			Case Else
				
				Return ""
		End Select
	End Function
	
	
	' Retrieves a friendly name for the given approval action
	<System.Runtime.CompilerServices.Extension> _
		Public Function ToDisplayString(a As UpdateApprovalAction) As String
		Select Case a
			Case UpdateApprovalAction.All
				Return globalRM.GetString("all")
			Case UpdateApprovalAction.Install
				Return globalRM.GetString("approved_for_install")
			Case UpdateApprovalAction.NotApproved
				Return globalRM.GetString("not_approved")
			Case UpdateApprovalAction.Uninstall
				Return globalRM.GetString("uninstall")
			Case Else
				Return ""
		End Select
	End Function
	
	' Retrieves the appropriate icon for a given approval action
	<System.Runtime.CompilerServices.Extension> _
		Public Function GetIcon(a As UpdateApprovalAction) As Bitmap
		Select Case a
			Case UpdateApprovalAction.Install
				Return My.Resources.check.ToBitmap
			Case UpdateApprovalAction.NotApproved
				Return My.Resources.attention.ToBitmap
			Case UpdateApprovalAction.Uninstall
				Return My.Resources.delete.ToBitmap
			Case Else
				Return Nothing
		End Select
	End Function
	
	
	' Take an enumerator and resort it based on its names rather then
	' its binary data.
	Public Function GetSortedEnum(ByVal enumType As Type) As ArrayList
		Dim tmpArray As ArrayList = New ArrayList
		
		'Make sure it's an enumerator.
		If enumType.BaseType.FullName = "System.Enum" Then
			
			'Get and sor the enumerator's strings
			Dim strEnum() As Object = [Enum].GetNames(enumType)
			Array.Sort(strEnum)
			
			
			'Loop through the sorted array and add the matching
			' enumerator items to the temporary array
			For Each tmpString As String In strEnum
				tmpArray.Add([Enum].Parse(enumType, tmpString))
			Next
			
			Return tmpArray
		Else
			Throw New ArgumentException(globalRM.GetString("error_sort_enumerator"), "t")
			Return Nothing
		End If
	End Function	
	
End Module

