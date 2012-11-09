Option Explicit On
Option Strict On
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
Imports System.Threading
Imports System.Globalization


<Serializable> _
Public Class Settings
    Private Shared m_productName As String
    Protected m_settingsHash As Hashtable

#Region "Constructors"
    ''' <summary>
    ''' Static constructor to retrieve the productName
    ''' from the assembly
    ''' </summary>
    Shared Sub New()
        Dim assembly As Assembly = GetType(Settings).Assembly

        Dim apas As AssemblyProductAttribute() = DirectCast(assembly.GetCustomAttributes(GetType(AssemblyProductAttribute), True),  _
            AssemblyProductAttribute())
        If apas.Length > 0 Then
            Dim apa As AssemblyProductAttribute = apas(0)
            m_productName = apa.Product
        Else
            m_productName = ""
        End If
    End Sub

    ''' <summary>
    ''' Creates a new instance of the settings class, loading in the default values
    ''' </summary>
    Public Sub New()
        m_settingsHash = New Hashtable(10)

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

    ''' <summary>
    ''' Persists the settings to a default filename.
    ''' </summary>
    ''' <param name="settings">Settings object to save.</param>
    Public Shared Sub SaveSettingsToFile(settings As Settings)
        Dim userfile As String

        Try
            Directory.CreateDirectory(SettingsDirectory)
            userfile = SettingsDirectory & "\config.xml"
            SaveSettingsToFile(userfile, settings)

        Catch x As UnauthorizedAccessException
            MsgBox("Settings.SaveSettingsToFile" & vbNewLine & Globals.globalRM.GetString("exception_unauthorized_access") & ": " & vbNewLine & x.Message)
        Catch x As ArgumentNullException
            MsgBox("Settings.SaveSettingsToFile" & vbNewLine & Globals.globalRM.GetString("exception_argument_null") & ": " & vbNewLine & x.Message)
        Catch x As ArgumentException
            MsgBox("Settings.SaveSettingsToFile" & vbNewLine & Globals.globalRM.GetString("exception_argument") & ": " & vbNewLine & x.Message)
        Catch x As PathTooLongException
            MsgBox("Settings.SaveSettingsToFile" & vbNewLine & Globals.globalRM.GetString("exception_path_too_long") & ": " & vbNewLine & x.Message)
        Catch x As DirectoryNotFoundException
            MsgBox("Settings.SaveSettingsToFile" & vbNewLine & Globals.globalRM.GetString("exception_directory_not_found") & ": " & vbNewLine & x.Message)
        Catch x As IOException
            MsgBox("Settings.SaveSettingsToFile" & vbNewLine & Globals.globalRM.GetString("exception_IO") & ": " & vbNewLine & x.Message)
        Catch x As NotSupportedException
            MsgBox("Settings.SaveSettingsToFile" & vbNewLine & Globals.globalRM.GetString("exception_not_supported") & ": " & vbNewLine & x.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Persists the settings to the specified filename.
    ''' </summary>
    ''' <param name="path">Fie path save to.</param>
    ''' <param name="settings">Settings object to save.</param>
    ''' <remarks></remarks>
    Public Shared Sub SaveSettingsToFile(path As String, settings As Settings)
        Dim fs As FileStream = Nothing
        Dim xs As New XmlSerializer(GetType(Settings))

        fs = File.Open(path, FileMode.Create, FileAccess.Write)

        Try
            xs.Serialize(fs, settings)
        Finally
            fs.Close()
        End Try
    End Sub

    ''' <summary>
    ''' Gets the directory used for storing the settings.
    ''' </summary>
    ''' <returns>Directory path as string.</returns>
    Public Shared ReadOnly Property SettingsDirectory() As String
        Get
            Dim userFiles As String

            userFiles = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)

            userFiles += "\" & m_productName

            Return userFiles
        End Get
    End Property

    ''' <summary>
    ''' Sets default values.
    ''' </summary>
    Public Sub LoadDefaultSettings()
        UpdateServers = New UpdateServerCollection()
        RememberTreePath = True
        RollupReporting = False
        ApprovedUpdatesOnly = True
        InheritApprovals = True
        DemoteClassification = True
        HideOfficialUpdates = True
        TreePath = ""
        TreeSplitter = 175
        UpdateSplitter = 175
        ComputerSplitter = 175
        WindowState = 0
        Me.WindowWidth = CInt(My.Computer.Screen.WorkingArea.Width * 0.75)
        Me.WindowHeight = CInt(My.Computer.Screen.WorkingArea.Height * 0.75)
        Me.WindowTop = CInt((My.Computer.Screen.WorkingArea.Height - Me.WindowHeight) * 0.5)
        Me.WindowLeft = CInt((My.Computer.Screen.WorkingArea.Width - Me.WindowWidth) * 0.5)
        SavedRuleCollection = New RuleCollection
        StateMainComputersDGV = New DataGridViewState
        StateMainUpdatesDGV = New DataGridViewState
        StateComputerReportDGV = New DataGridViewState
        StateComputerGroupStatusDGV = New DataGridViewState
        StateUpdateReportDGV = New DataGridViewState
        StateUpdateStatusDGV = New DataGridViewState
        StateApprovalDGV = New DataGridViewState
        Culture = Thread.CurrentThread.CurrentCulture.Name
        TimeOut = 90
    End Sub
#End Region

#Region "Properties"
    ''' <summary>
    '''  Property Server Name
    ''' </summary>
    <Browsable(True)> _
        <Description("Servers")> _
        <DefaultValue("")> _
    Public Property UpdateServers() As UpdateServerCollection
        Get
            Return DirectCast(m_settingsHash("UpdateServers"), UpdateServerCollection)
        End Get
        Set(value As UpdateServerCollection)
            m_settingsHash("UpdateServers") = value
        End Set
    End Property

    ''' <summary>
    '''  Property TreePath Name
    ''' </summary>
    <Browsable(True)> _
        <Description("Remember path for tree view")> _
        <DefaultValue(True)> _
    Public Property RememberTreePath() As Boolean
        Get
            Return DirectCast(m_settingsHash("RememberTreePath"), Boolean)
        End Get
        Set(value As Boolean)
            m_settingsHash("RememberTreePath") = value
        End Set
    End Property

    ''' <summary>
    ''' Property TreePath Name
    ''' </summary>
    <Browsable(True)> _
        <Description("Saved path for tree view")> _
        <DefaultValue("")> _
    Public Property TreePath() As String
        Get
            Return DirectCast(m_settingsHash("TreePath"), String)
        End Get
        Set(value As String)
            m_settingsHash("TreePath") = value
        End Set
    End Property

    ''' <summary>
    ''' Property Rollup Reporting
    ''' </summary>
    <Browsable(True)> _
        <Description("Rollup downstream clients into reports.")> _
        <DefaultValue(False)> _
    Public Property RollupReporting() As Boolean
        Get
            Return DirectCast(m_settingsHash("RollupReporting"), Boolean)
        End Get
        Set(value As Boolean)
            m_settingsHash("RollupReporting") = value
        End Set
    End Property

    ''' <summary>
    ''' Property Approved Updates
    ''' </summary>
    <Browsable(True)> _
        <Description("Only show approved updates in percentages.")> _
        <DefaultValue(True)> _
    Public Property ApprovedUpdatesOnly() As Boolean
        Get
            Return DirectCast(m_settingsHash("ApprovedUpdatesOnly"), Boolean)
        End Get
        Set(value As Boolean)
            m_settingsHash("ApprovedUpdatesOnly") = value
        End Set
    End Property

    ''' <summary>
    ''' Property Inherit Approvals
    ''' </summary>
    <Browsable(True)> _
        <Description("Inherit approvals for percentages.")> _
        <DefaultValue(True)> _
    Public Property InheritApprovals() As Boolean
        Get
            Return DirectCast(m_settingsHash("InheritApprovals"), Boolean)
        End Get
        Set(value As Boolean)
            m_settingsHash("InheritApprovals") = value
        End Set
    End Property

    ''' <summary>
    ''' Property Inherit Approvals
    ''' </summary>
    <Browsable(True)> _
        <Description("Demote critical and security updates to normal updates.")> _
        <DefaultValue(True)> _
    Public Property DemoteClassification() As Boolean
        Get
            Return DirectCast(m_settingsHash("DemoteClassification"), Boolean)
        End Get
        Set(value As Boolean)
            m_settingsHash("DemoteClassification") = value
        End Set
    End Property

    ''' <summary>
    ''' Property Hide Official Updates
    ''' </summary>
    <Browsable(True)> _
        <Description("Hide official Microsoft updates.")> _
        <DefaultValue(True)> _
    Public Property HideOfficialUpdates() As Boolean
        Get
            Return DirectCast(m_settingsHash("HideOfficialUpdates"), Boolean)
        End Get
        Set(value As Boolean)
            m_settingsHash("HideOfficialUpdates") = value
        End Set
    End Property

    ''' <summary>
    ''' Property for the TreeSplitter's splitter size
    ''' </summary>
    <Browsable(True)> _
        <Description("TreeSplitter")> _
        <DefaultValue(175)> _
    Public Property TreeSplitter() As Integer
        Get
            Return CInt(m_settingsHash("TreeSplitter"))
        End Get
        Set(value As Integer)
            m_settingsHash("TreeSplitter") = value
        End Set
    End Property


    ''' <summary>
    ''' Property for the update's splitter size
    ''' </summary>
    <Browsable(True)> _
        <Description("UpdateSplitter")> _
        <DefaultValue(175)> _
    Public Property UpdateSplitter() As Integer
        Get
            Return CInt(m_settingsHash("UpdateSplitter"))
        End Get
        Set(value As Integer)
            m_settingsHash("UpdateSplitter") = value
        End Set
    End Property

    ''' <summary>
    ''' Property for the computers' splitter size
    ''' </summary>
    <Browsable(True)> _
        <Description("ComputerSplitter")> _
        <DefaultValue(175)> _
    Public Property ComputerSplitter() As Integer
        Get
            Return CInt(m_settingsHash("ComputerSplitter"))
        End Get
        Set(value As Integer)
            m_settingsHash("ComputerSplitter") = value
        End Set
    End Property

    ''' <summary>
    ''' Property for the main form's window state.
    ''' </summary>
    <Browsable(True)> _
        <Description("Main window state")> _
        <DefaultValue(0)> _
    Public Property WindowState() As Integer
        Get
            Return CInt(m_settingsHash("WindowState"))
        End Get
        Set(value As Integer)
            m_settingsHash("WindowState") = value
        End Set
    End Property

    ''' <summary>
    ''' Property for the main form's window left position.
    ''' </summary>
    <Browsable(True)> _
        <Description("Main window location")> _
        <DefaultValue(0)> _
    Public Property WindowLeft() As Integer
        Get
            Return CType(m_settingsHash("WindowLeft"), Integer)
        End Get
        Set(value As Integer)
            m_settingsHash("WindowLeft") = value
        End Set
    End Property

    ''' <summary>
    ''' Property for the main form's window top position.
    ''' </summary>
    <Browsable(True)> _
        <Description("Main window location")> _
        <DefaultValue(0)> _
    Public Property WindowTop() As Integer
        Get
            Return CType(m_settingsHash("WindowTop"), Integer)
        End Get
        Set(value As Integer)
            m_settingsHash("WindowTop") = value
        End Set
    End Property

    ''' <summary>
    ''' Property for the main form's window width.
    ''' </summary>
    <Browsable(True)> _
        <Description("Main window location")> _
        <DefaultValue(0)> _
    Public Property WindowWidth() As Integer
        Get
            Return CType(m_settingsHash("WindowWidth"), Integer)
        End Get
        Set(value As Integer)
            m_settingsHash("WindowWidth") = value
        End Set
    End Property

    ''' <summary>
    ''' Property for the main form's window height.
    ''' </summary>
    <Browsable(True)> _
        <Description("Main window location")> _
        <DefaultValue(0)> _
    Public Property WindowHeight() As Integer
        Get
            Return CType(m_settingsHash("WindowHeight"), Integer)
        End Get
        Set(value As Integer)
            m_settingsHash("WindowHeight") = value
        End Set
    End Property

    ''' <summary>
    ''' Property for the main form's window state
    ''' </summary>
    <Browsable(True)> _
        <Description("Main window location")> _
        <DefaultValue(0)> _
    Public Property WindowData() As Integer
        Get
            Return CType(m_settingsHash("WindowData"), Integer)
        End Get
        Set(value As Integer)
            m_settingsHash("WindowData") = value
        End Set
    End Property

    ''' <summary>
    ''' Property for the saved rule collection.
    ''' </summary>
    <Browsable(True)> _
        <Description("Saved Rule Collection")> _
        <DefaultValue(0)> _
    Public Property SavedRuleCollection() As RuleCollection
        Get
            Return CType(m_settingsHash("SavedRuleCollection"), RuleCollection)
        End Get
        Set(value As RuleCollection)
            m_settingsHash("SavedRuleCollection") = value
        End Set
    End Property

    ''' <summary>
    ''' Property for the main DGV for updates.
    ''' </summary>
    <Browsable(True)> _
        <Description("Main DGV State for Updates")> _
        <DefaultValue(0)> _
    Public Property StateMainUpdatesDGV() As DataGridViewState
        Get
            Return CType(m_settingsHash("StateMainUpdatesDGV"), DataGridViewState)
        End Get
        Set(value As DataGridViewState)
            m_settingsHash("StateMainUpdatesDGV") = value
        End Set
    End Property

    ''' <summary>
    ''' Property for the main DGV for computers.
    ''' </summary>
    <Browsable(True)> _
        <Description("Main DGV State for Computers")> _
        <DefaultValue(0)> _
    Public Property StateMainComputersDGV() As DataGridViewState
        Get
            Return CType(m_settingsHash("StateMainComputersDGV"), DataGridViewState)
        End Get
        Set(value As DataGridViewState)
            m_settingsHash("StateMainComputersDGV") = value
        End Set
    End Property

    ''' <summary>
    ''' Property for the main computer report DGV.
    ''' </summary>
    <Browsable(True)> _
        <Description("Computer report DGV state")> _
        <DefaultValue(0)> _
    Public Property StateComputerReportDGV() As DataGridViewState
        Get
            Return CType(m_settingsHash("StateComputerReportDGV"), DataGridViewState)
        End Get
        Set(value As DataGridViewState)
            m_settingsHash("StateComputerReportDGV") = value
        End Set
    End Property

    ''' <summary>
    ''' Property for the main computer group status DGV.
    ''' </summary>
    <Browsable(True)> _
        <Description("Computer group status DGV state")> _
        <DefaultValue(0)> _
    Public Property StateComputerGroupStatusDGV() As DataGridViewState
        Get
            Return CType(m_settingsHash("StateComputerGroupStatusDGV"), DataGridViewState)
        End Get
        Set(value As DataGridViewState)
            m_settingsHash("StateComputerGroupStatusDGV") = value
        End Set
    End Property

    ''' <summary>
    ''' Property for the main update report DGV.
    ''' </summary>
    <Browsable(True)> _
        <Description("Update report DGV state")> _
        <DefaultValue(0)> _
    Public Property StateUpdateReportDGV() As DataGridViewState
        Get
            Return CType(m_settingsHash("StateUpdateReportDGV"), DataGridViewState)
        End Get
        Set(value As DataGridViewState)
            m_settingsHash("StateUpdateReportDGV") = value
        End Set
    End Property

    ''' <summary>
    ''' Property for the main update status DGV.
    ''' </summary>
    <Browsable(True)> _
        <Description("Update status DGV state")> _
        <DefaultValue(0)> _
    Public Property StateUpdateStatusDGV() As DataGridViewState
        Get
            Return CType(m_settingsHash("StateUpdateStatusDGV"), DataGridViewState)
        End Get
        Set(value As DataGridViewState)
            m_settingsHash("StateUpdateStatusDGV") = value
        End Set
    End Property


    ''' <summary>
    ''' Property for the approval form's DGV.
    ''' </summary>
    <Browsable(True)> _
        <Description("Approval DGV state")> _
        <DefaultValue(0)> _
    Public Property StateApprovalDGV() As DataGridViewState
        Get
            Return CType(m_settingsHash("StateApprovalDGV"), DataGridViewState)
        End Get
        Set(value As DataGridViewState)
            m_settingsHash("StateApprovalDGV") = value
        End Set
    End Property

    ''' <summary>
    ''' Property for the culture to be used.
    ''' </summary>
    <Browsable(True)> _
        <Description("Culture and language")> _
        <DefaultValue("")> _
    Public Property Culture() As String
        Get
            Return CType(m_settingsHash("Culture"), String)
        End Get
        Set(value As String)
            m_settingsHash("Culture") = value
        End Set
    End Property

    ''' <summary>
    ''' Property for the asyncronous time out.
    ''' </summary>
    ''' <remarks></remarks>
    <Browsable(True)> _
        <Description("Time Out Value")> _
        <DefaultValue(0)> _
    Public Property TimeOut() As Integer
        Get
            Return CType(m_settingsHash("TimeOut"), Integer)
        End Get
        Set(value As Integer)
            m_settingsHash("TimeOut") = value
        End Set
    End Property
#End Region
End Class
