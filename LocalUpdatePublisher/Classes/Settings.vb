' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' Settings
' This class holds the various settings the application needs
' and allows them to be serialized to an XML file.
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 11/1/2009
' Time: 9:06 PM
'
' This class is based off of James T. Johnson's class published here:
' http://www.codeproject.com/KB/XML/xmlsettings.aspx


Imports System.Xml.Serialization
Imports System.IO
Imports System.ComponentModel
Imports System.Reflection


<Serializable> _
	Public Class Settings
	Private Shared _productName As String
	Protected _settingsHash As Hashtable
	
	#Region "Constructors"
	''' <summary>
	''' Static constructor to retreive the productName
	''' from the assembly
	''' </summary>
	Shared Sub New()
		Dim assembly As Assembly = GetType(Settings).Assembly
		
		Dim apas As AssemblyProductAttribute() = DirectCast(assembly.GetCustomAttributes(GetType(AssemblyProductAttribute), True), _
			AssemblyProductAttribute())
		If apas.Length > 0 Then
			Dim apa As AssemblyProductAttribute = apas(0)
			_productName = apa.Product
		Else
			_productName = ""
		End If
	End Sub
	
	''' <summary>
	''' Creates a new instance of the settings class, loading in the default values
	''' </summary>
	Public Sub New()
		_settingsHash = New Hashtable(10)
		
		LoadDefaultSettings()
	End Sub
	#End Region
	
	#Region "Static Methods"
	''' <summary>
	''' Loads a serialized instance of the settings from a file, returns
	''' default values if the file doesn't exist or an error occurs
	''' </summary>
	''' <returns>The persisted settings from the file</returns>
	Public Shared Function LoadSettingsFromFile() As Settings
		
		'Try creating the settings directory and ignore any errors
		Try
			Directory.CreateDirectory(SettingsDirectory)
		Catch
		End Try
		
		'Load the settings using the default file
		Return LoadSettingsFromFile(SettingsDirectory & "\config.xml")
	End Function
	
	''' <summary>
	''' Loads a serialized instance of the settings from the specified file
	''' returns default values if the file doesn't exist or an error occurs
	''' </summary>
	''' <returns>The persisted settings from the file</returns>
	Public Shared Function LoadSettingsFromFile(filePath As String) As Settings
		Dim settings As Settings
		Dim xs As New XmlSerializer(GetType(Settings))
		
		If File.Exists(filePath) Then
			Dim fs As FileStream = Nothing
			
			Try
				fs = File.Open(filePath, FileMode.Open, FileAccess.Read)
			Catch
				Return New Settings()
			End Try
			
			Try
				settings = DirectCast(xs.Deserialize(fs), Settings)
			Catch
				settings = New Settings()
			Finally
				fs.Close()
			End Try
		Else
			settings = New Settings()
		End If
		
		Return settings
	End Function
	
	'Persists the settings to a default filename.
	Public Shared Sub SaveSettingsToFile(settings As Settings)
		Dim userfile As String
		
		Try
			Directory.CreateDirectory(SettingsDirectory)
		Catch x As UnauthorizedAccessException
			Msgbox ("Unauthorized Access Exception: " & vbNewLine & x.Message)
		Catch x As ArgumentNullException
			Msgbox ("Argument Null Exception: " & vbNewLine & x.Message)
		Catch x As ArgumentException
			Msgbox ("Argument Exception: " & vbNewLine & x.Message)
		Catch x As PathTooLongException
			Msgbox ("Path Too Long Exception: " & vbNewLine & x.Message)
		Catch x As DirectoryNotFoundException
			Msgbox ("Directory Not Found Exception: " & vbNewLine & x.Message)
		Catch x As IOException
			Msgbox ("IO Exception: " & vbNewLine & x.Message)
		Catch x As NotSupportedException
			Msgbox ("Not Supported Exception: " & vbNewLine & x.Message)
		End Try
		
		userfile = SettingsDirectory & "\config.xml"
		
		SaveSettingsToFile(userfile, settings)
	End Sub
	
	'Persists the settings to the specified filename.
	Public Shared Sub SaveSettingsToFile(filePath As String, settings As Settings)
		Dim fs As FileStream = Nothing
		Dim xs As New XmlSerializer(GetType(Settings))
		
		fs = File.Open(filePath, FileMode.Create, FileAccess.Write)
		
		Try
			xs.Serialize(fs, settings)
		Finally
			fs.Close()
		End Try
	End Sub
	
	'Gets the directory used for storing the settings.
	Public Shared ReadOnly Property SettingsDirectory() As String
		Get
			Dim userFiles As String
			
			userFiles = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
			
			userFiles += "\" & _productName
			
			Return userFiles
		End Get
	End Property
	
	'Sets all settings to reasonable default values.
	Public Sub LoadDefaultSettings()
		UpdateServers = New UpdateServerCollection()
		RememberTreePath = True
		RollupReporting = False
		ApprovedUpdatesOnly = True
		InheritApprovals = True
		DemoteClassification = True
		TreePath = ""
		TreeSplitter = 175
		UpdateSplitter = 175
		ComputerSplitter = 175
		WindowState = 0
		SavedRuleCollection = New RuleCollection
		StateMainComputersDGV = New DataGridViewState
		StateMainUpdatesDGV = New DataGridViewState
		StateComputerReportDGV = New DataGridViewState
		StateComputerGroupStatusDGV = New DataGridViewState
		StateUpdateReportDGV = New DataGridViewState
		StateUpdateStatusDGV = New DataGridViewState
	End Sub
	#End Region
	
	#Region "Properties"
	' Property Server Name
	<Browsable(True)> _
		<Description("Servers")> _
		<DefaultValue("")> _
		Public Property UpdateServers() As UpdateServerCollection
		Get
			Return DirectCast(_settingsHash("UpdateServers"), UpdateServerCollection)
		End Get
		Set
			_settingsHash("UpdateServers") = value
		End Set
	End Property
	
	' Property TreePath Name
	<Browsable(True)> _
		<Description("Remember path for tree view")> _
		<DefaultValue(True)> _
		Public Property RememberTreePath() As Boolean
		Get
			Return DirectCast(_settingsHash("RememberTreePath"), Boolean)
		End Get
		Set
			_settingsHash("RememberTreePath") = value
		End Set
	End Property
	
	' Property TreePath Name
	<Browsable(True)> _
		<Description("Saved path for tree view")> _
		<DefaultValue("")> _
		Public Property TreePath() As String
		Get
			Return DirectCast(_settingsHash("TreePath"), String)
		End Get
		Set
			_settingsHash("TreePath") = value
		End Set
	End Property
	
	' Property Rollup Reporting
	<Browsable(True)> _
		<Description("Rollup downstream clients into reports.")> _
		<DefaultValue(False)> _
		Public Property RollupReporting() As Boolean
		Get
			Return DirectCast(_settingsHash("RollupReporting"), Boolean)
		End Get
		Set
			_settingsHash("RollupReporting") = value
		End Set
	End Property
	
	' Property Approved Updates
	<Browsable(True)> _
		<Description("Only show approved updates in percentages.")> _
		<DefaultValue(True)> _
		Public Property ApprovedUpdatesOnly() As Boolean
		Get
			Return DirectCast(_settingsHash("ApprovedUpdatesOnly"), Boolean)
		End Get
		Set
			_settingsHash("ApprovedUpdatesOnly") = value
		End Set
	End Property
	
	' Property Inherit Approvals
	<Browsable(True)> _
		<Description("Inherit approvals for percentages.")> _
		<DefaultValue(True)> _
		Public Property InheritApprovals() As Boolean
		Get
			Return DirectCast(_settingsHash("InheritApprovals"), Boolean)
		End Get
		Set
			_settingsHash("InheritApprovals") = value
		End Set
	End Property	
		
	' Property Inherit Approvals
	<Browsable(True)> _
		<Description("Demote critical and security updates to normal updates.")> _
		<DefaultValue(True)> _
		Public Property DemoteClassification() As Boolean
		Get
			Return DirectCast(_settingsHash("DemoteClassification"), Boolean)
		End Get
		Set
			_settingsHash("DemoteClassification") = value
		End Set
	End Property
	
	' Property for the TreeSplitter's splitter size
	<Browsable(True)> _
		<Description("TreeSplitter")> _
		<DefaultValue(175)> _
		Public Property TreeSplitter() As Integer
		Get
			Return CInt(_settingsHash("TreeSplitter"))
		End Get
		Set
			_settingsHash("TreeSplitter") = value
		End Set
	End Property
	
	
	' Property for the update's splitter size
	<Browsable(True)> _
		<Description("UpdateSplitter")> _
		<DefaultValue(175)> _
		Public Property UpdateSplitter() As Integer
		Get
			Return CInt(_settingsHash("UpdateSplitter"))
		End Get
		Set
			_settingsHash("UpdateSplitter") = value
		End Set
	End Property
	
	' Property for the computers' splitter size
	<Browsable(True)> _
		<Description("ComputerSplitter")> _
		<DefaultValue(175)> _
		Public Property ComputerSplitter() As Integer
		Get
			Return CInt(_settingsHash("ComputerSplitter"))
		End Get
		Set
			_settingsHash("ComputerSplitter") = value
		End Set
	End Property
	
	' Property for the main form's window state.
	<Browsable(True)> _
		<Description("Main window state")> _
		<DefaultValue(0)> _
		Public Property WindowState() As Integer
		Get
			Return CInt(_settingsHash("WindowState"))
		End Get
		Set
			_settingsHash("WindowState") = value
		End Set
	End Property
	
	' Property for the main form's window state
	<Browsable(True)> _
		<Description("Main window location")> _
		<DefaultValue(0)> _
		Public Property WindowLocation() As Point
		Get
			Return CType(_settingsHash("WindowLocation"), Point)
		End Get
		Set
			_settingsHash("WindowLocation") = value
		End Set
	End Property
	
	
	' Property for the saved rule collection.
	<Browsable(True)> _
		<Description("Saved Rule Collection")> _
		<DefaultValue(0)> _
		Public Property SavedRuleCollection() As RuleCollection
		Get
			Return CType(_settingsHash("SavedRuleCollection"), RuleCollection)
		End Get
		Set
			_settingsHash("SavedRuleCollection") = value
		End Set
	End Property
	
	' Property for the main DGV for updates.
	<Browsable(True)> _
		<Description("Main DGV State for Updates")> _
		<DefaultValue(0)> _
		Public Property StateMainUpdatesDGV() As DataGridViewState
		Get
			Return CType(_settingsHash("StateMainUpdatesDGV"), DataGridViewState)
		End Get
		Set
			_settingsHash("StateMainUpdatesDGV") = value
		End Set
	End Property
	
	' Property for the main DGV for computers.
	<Browsable(True)> _
		<Description("Main DGV State for Computers")> _
		<DefaultValue(0)> _
		Public Property StateMainComputersDGV() As DataGridViewState
		Get
			Return CType(_settingsHash("StateMainComputersDGV"), DataGridViewState)
		End Get
		Set
			_settingsHash("StateMainComputersDGV") = value
		End Set
	End Property
	
	' Property for the main computer report DGV.
	<Browsable(True)> _
		<Description("Computer report DGV state")> _
		<DefaultValue(0)> _
		Public Property StateComputerReportDGV() As DataGridViewState
		Get
			Return CType(_settingsHash("StateComputerReportDGV"), DataGridViewState)
		End Get
		Set
			_settingsHash("StateComputerReportDGV") = value
		End Set
	End Property
	
	' Property for the main computer group status DGV.
	<Browsable(True)> _
		<Description("Computer group status DGV state")> _
		<DefaultValue(0)> _
		Public Property StateComputerGroupStatusDGV() As DataGridViewState
		Get
			Return CType(_settingsHash("StateComputerGroupStatusDGV"), DataGridViewState)
		End Get
		Set
			_settingsHash("StateComputerGroupStatusDGV") = value
		End Set
	End Property
	
	' Property for the main update report DGV.
	<Browsable(True)> _
		<Description("Update report DGV state")> _
		<DefaultValue(0)> _
		Public Property StateUpdateReportDGV() As DataGridViewState
		Get
			Return CType(_settingsHash("StateUpdateReportDGV"), DataGridViewState)
		End Get
		Set
			_settingsHash("StateUpdateReportDGV") = value
		End Set
	End Property
	
	' Property for the main update status DGV.
	<Browsable(True)> _
		<Description("Update status DGV state")> _
		<DefaultValue(0)> _
		Public Property StateUpdateStatusDGV() As DataGridViewState
		Get
			Return CType(_settingsHash("StateUpdateStatusDGV"), DataGridViewState)
		End Get
		Set
			_settingsHash("StateUpdateStatusDGV") = value
		End Set
	End Property
	
	#End Region
End Class
