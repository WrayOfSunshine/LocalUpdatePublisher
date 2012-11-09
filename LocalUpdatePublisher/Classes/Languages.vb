Option Explicit On
Option Strict On
' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 2/16/2011
' Time: 4:14 PM
Public Class Languages
    Public Shared Codes As String() = New String() {"ar", "zh-HK", "zh-CHS", "zh-CHT", "cs", "da", "nl", "en", "fi", "fr", "de", "el", "he", _
    "hu", "it", "ja", "ko", "no", "pl", "pt", "pt-BR", "ru", "es", "sv", "tr"}

    ''' <summary>
    ''' Translates the MSI Language Number to an ISO 639-1 code
    ''' </summary>
    ''' <param name="msiLanguageNumber">Ingeger representing MSI language code.</param>
    ''' <returns>String</returns>
    Public Shared Function Code(msiLanguageNumber As Integer) As String
        Select Case msiLanguageNumber
            Case 1
                Return "ar"
            Case 3076
                Return "zh-HK"
            Case 4
                Return "zh-CHS"
            Case 31748
                Return "zh-CHT"
            Case 5
                Return "cs"
            Case 6
                Return "da"
            Case 19
                Return "nl"
            Case 9
                Return "en"
            Case 11
                Return "fi"
            Case 12
                Return "fr"
            Case 7
                Return "de"
            Case 8
                Return "el"
            Case 13
                Return "he"
            Case 14
                Return "hu"
            Case 16
                Return "it"
            Case 17
                Return "ja"
            Case 18
                Return "ko"
            Case 20
                Return "no"
            Case 21
                Return "pl"
            Case 22
                Return "pt"
            Case 1046
                Return "pt-BR"
            Case 25
                Return "ru"
            Case 10
                Return "es"
            Case 29
                Return "sv"
            Case 31
                Return "tr"
            Case Nothing
                Return Nothing
            Case Else
                Throw New NotSupportedException("An ISO 639-1 code is not known for MSI Language " & msiLanguageNumber)
        End Select
    End Function

    Public Shared Names As String() = New String() {Globals.globalRM.GetString("language_arabic"), Globals.globalRM.GetString("language_chinese_HK_SAR"), Globals.globalRM.GetString("language_chinese_simplified"), Globals.globalRM.GetString("language_chinese_traditional"), _
        Globals.globalRM.GetString("language_czech"), Globals.globalRM.GetString("language_danish"), Globals.globalRM.GetString("language_dutch"), Globals.globalRM.GetString("language_english"), Globals.globalRM.GetString("language_finnish"), _
        Globals.globalRM.GetString("language_french"), Globals.globalRM.GetString("language_german"), Globals.globalRM.GetString("language_greek"), Globals.globalRM.GetString("language_hebrew"), Globals.globalRM.GetString("language_hungarian"), _
        Globals.globalRM.GetString("language_italian"), Globals.globalRM.GetString("language_japanese"), Globals.globalRM.GetString("language_korean"), Globals.globalRM.GetString("language_norwegian"), Globals.globalRM.GetString("language_polish"), _
    Globals.globalRM.GetString("language_portuguese"), Globals.globalRM.GetString("language_portuguese_brazil"), Globals.globalRM.GetString("language_russian"), Globals.globalRM.GetString("language_spanish"), Globals.globalRM.GetString("language_swedish"), Globals.globalRM.GetString("language_turkish")}

    ''' <summary>
    ''' Return the human readable string based on the language code.
    ''' </summary>
    ''' <param name="languageCode">Language Code</param>
    ''' <returns>String</returns>
    Public Shared Function Code(languageCode As String) As String
        Select Case languageCode
            Case Globals.globalRM.GetString("language_arabic")
                Return "ar"
            Case Globals.globalRM.GetString("language_chinese_HK_SAR")
                Return "zh-HK"
            Case Globals.globalRM.GetString("language_chinese_simplified")
                Return "zh-CHS"
            Case Globals.globalRM.GetString("language_chinese_traditional")
                Return "zh-CHT"
            Case Globals.globalRM.GetString("language_czech")
                Return "cs"
            Case Globals.globalRM.GetString("language_danish")
                Return "da"
            Case Globals.globalRM.GetString("language_dutch")
                Return "nl"
            Case Globals.globalRM.GetString("language_english")
                Return "en"
            Case Globals.globalRM.GetString("language_finnish")
                Return "fi"
            Case Globals.globalRM.GetString("language_french")
                Return "fr"
            Case Globals.globalRM.GetString("language_german")
                Return "de"
            Case Globals.globalRM.GetString("language_greek")
                Return "el"
            Case Globals.globalRM.GetString("language_hebrew")
                Return "he"
            Case Globals.globalRM.GetString("language_hungarian")
                Return "hu"
            Case Globals.globalRM.GetString("language_italian")
                Return "it"
            Case Globals.globalRM.GetString("language_japanese")
                Return "ja"
            Case Globals.globalRM.GetString("language_korean")
                Return "ko"
            Case Globals.globalRM.GetString("language_norwegian")
                Return "no"
            Case Globals.globalRM.GetString("language_polish")
                Return "pl"
            Case Globals.globalRM.GetString("language_portuguese")
                Return "pt"
            Case Globals.globalRM.GetString("language_portuguese_brazil")
                Return "pt-BR"
            Case Globals.globalRM.GetString("language_russian")
                Return "ru"
            Case Globals.globalRM.GetString("language_spanish")
                Return "es"
            Case Globals.globalRM.GetString("language_swedish")
                Return "sv"
            Case Globals.globalRM.GetString("language_turkish")
                Return "tr"
            Case Else
                Return Nothing
        End Select
    End Function

    ''' <summary>
    ''' Return the human readable string based on the language code.
    ''' </summary>
    ''' <param name="languageCode">Language Code</param>
    ''' <returns>String</returns>
    Public Shared Function Name(languageCode As String) As String
        Select Case languageCode
            Case "ar"
                Return Globals.globalRM.GetString("language_arabic")
            Case "zh-HK"
                Return Globals.globalRM.GetString("language_chinese_HK_SAR")
            Case "zh-CHS"
                Return Globals.globalRM.GetString("language_chinese_simplified")
            Case "zh-CHT"
                Return Globals.globalRM.GetString("language_chinese_traditional")
            Case "cs"
                Return Globals.globalRM.GetString("language_czech")
            Case "da"
                Return Globals.globalRM.GetString("language_danish")
            Case "nl"
                Return Globals.globalRM.GetString("language_dutch")
            Case "en"
                Return Globals.globalRM.GetString("language_english")
            Case "fi"
                Return Globals.globalRM.GetString("language_finnish")
            Case "fr"
                Return Globals.globalRM.GetString("language_french")
            Case "de"
                Return Globals.globalRM.GetString("language_german")
            Case "el"
                Return Globals.globalRM.GetString("language_greek")
            Case "he"
                Return Globals.globalRM.GetString("language_hebrew")
            Case "hu"
                Return Globals.globalRM.GetString("language_hungarian")
            Case "it"
                Return Globals.globalRM.GetString("language_italian")
            Case "ja"
                Return Globals.globalRM.GetString("language_japanese")
            Case "ko"
                Return Globals.globalRM.GetString("language_korean")
            Case "no"
                Return Globals.globalRM.GetString("language_norwegian")
            Case "pl"
                Return Globals.globalRM.GetString("language_polish")
            Case "pt"
                Return Globals.globalRM.GetString("language_portuguese")
            Case "pt-BR"
                Return Globals.globalRM.GetString("language_portuguese_brazil")
            Case "ru"
                Return Globals.globalRM.GetString("language_russian")
            Case "es"
                Return Globals.globalRM.GetString("language_spanish")
            Case "sv"
                Return Globals.globalRM.GetString("language_swedish")
            Case "tr"
                Return Globals.globalRM.GetString("language_turkish")
            Case Else
                Return Nothing
        End Select
    End Function
End Class
