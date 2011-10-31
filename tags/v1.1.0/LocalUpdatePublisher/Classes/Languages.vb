'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 2/16/2011
' Time: 4:14 PM
'
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Public Class Languages
	Public Shared Codes As String() =  New String() {"ar", "zh-HK", "zh-CHS", "zh-CHT", "cs", "da", "nl", "en", "fi", "fr", "de", "el", "he", _
	"hu", "it", "ja", "ko", "no", "pl", "pt", "pt-BR", "ru", "es", "sv", "tr"}	
	
	'Translates the MSI Language Number to an ISO 639-1 code.
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
	
	Public Shared Names As String() =  New String() {globalRM.GetString("language_arabic"), globalRM.GetString("language_chinese_HK_SAR"), globalRM.GetString("language_chinese_simplified"), globalRM.GetString("language_chinese_traditional"), _
		globalRM.GetString("language_czech"), globalRM.GetString("language_danish"), globalRM.GetString("language_dutch"), globalRM.GetString("language_english"), globalRM.GetString("language_finnish"), _
		globalRM.GetString("language_french"), globalRM.GetString("language_german"), globalRM.GetString("language_greek"), globalRM.GetString("language_hebrew"), globalRM.GetString("language_hungarian"), _
		globalRM.GetString("language_italian"), globalRM.GetString("language_japanese"), globalRM.GetString("language_korean"), globalRM.GetString("language_norwegian"), globalRM.GetString("language_polish"), _
	globalRM.GetString("language_portuguese"), globalRM.GetString("language_portuguese_brazil"), globalRM.GetString("language_russian"), globalRM.GetString("language_spanish"), globalRM.GetString("language_swedish"), globalRM.GetString("language_turkish")}
	
	'Return the human readable string based on the language code.
	Public Shared Function Code(languageCode As String) As String
		Select Case languageCode
			Case globalRM.GetString("language_arabic")
				Return "ar"
			Case globalRM.GetString("language_chinese_HK_SAR")
				Return "zh-HK"
			Case globalRM.GetString("language_chinese_simplified")
				Return "zh-CHS"
			Case globalRM.GetString("language_chinese_traditional")
				Return "zh-CHT"
			Case globalRM.GetString("language_czech")
				Return "cs"
			Case globalRM.GetString("language_danish")
				Return "da"
			Case globalRM.GetString("language_dutch")
				Return "nl"
			Case globalRM.GetString("language_english")
				Return "en"
			Case globalRM.GetString("language_finnish")
				Return "fi"
			Case globalRM.GetString("language_french")
				Return "fr"
			Case globalRM.GetString("language_german")
				Return "de"
			Case globalRM.GetString("language_greek")
				Return "el"
			Case globalRM.GetString("language_hebrew")
				Return "he"
			Case globalRM.GetString("language_hungarian")
				Return "hu"
			Case globalRM.GetString("language_italian")
				Return "it"
			Case globalRM.GetString("language_japanese")
				Return "ja"
			Case globalRM.GetString("language_korean")
				Return "ko"
			Case globalRM.GetString("language_norwegian")
				Return "no"
			Case globalRM.GetString("language_polish")
				Return "pl"
			Case globalRM.GetString("language_portuguese")
				Return "pt"
			Case globalRM.GetString("language_portuguese_brazil")
				Return "pt-BR"
			Case globalRM.GetString("language_russian")
				Return "ru"
			Case globalRM.GetString("language_spanish")
				Return "es"
			Case globalRM.GetString("language_swedish")
				Return "sv"
			Case globalRM.GetString("language_turkish")
				Return "tr"
			Case Else
				Return Nothing
		End Select
	End Function
	
	'Return the human readable string based on the language code.
	Public Shared Function Name(languageCode As String) As String
		Select Case languageCode
			Case "ar"
				Return globalRM.GetString("language_arabic")
			Case "zh-HK"
				Return globalRM.GetString("language_chinese_HK_SAR")
			Case "zh-CHS"
				Return globalRM.GetString("language_chinese_simplified")
			Case "zh-CHT"
				Return globalRM.GetString("language_chinese_traditional")
			Case "cs"
				Return globalRM.GetString("language_czech")
			Case "da"
				Return globalRM.GetString("language_danish")
			Case "nl"
				Return globalRM.GetString("language_dutch")
			Case "en"
				Return globalRM.GetString("language_english")
			Case "fi"
				Return globalRM.GetString("language_finnish")
			Case "fr"
				Return globalRM.GetString("language_french")
			Case "de"
				Return globalRM.GetString("language_german")
			Case "el"
				Return globalRM.GetString("language_greek")
			Case "he"
				Return globalRM.GetString("language_hebrew")
			Case "hu"
				Return globalRM.GetString("language_hungarian")
			Case "it"
				Return globalRM.GetString("language_italian")
			Case "ja"
				Return globalRM.GetString("language_japanese")
			Case "ko"
				Return globalRM.GetString("language_korean")
			Case "no"
				Return globalRM.GetString("language_norwegian")
			Case "pl"
				Return globalRM.GetString("language_polish")
			Case "pt"
				Return globalRM.GetString("language_portuguese")
			Case "pt-BR"
				Return globalRM.GetString("language_portuguese_brazil")
			Case "ru"
				Return globalRM.GetString("language_russian")
			Case "es"
				Return globalRM.GetString("language_spanish")
			Case "sv"
				Return globalRM.GetString("language_swedish")
			Case "tr"
				Return globalRM.GetString("language_turkish")
			Case Else
				Return Nothing
		End Select
	End Function
End Class
