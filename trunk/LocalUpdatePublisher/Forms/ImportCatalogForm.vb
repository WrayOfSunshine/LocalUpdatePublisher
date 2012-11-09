Option Explicit On
Option Strict On
' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
'
' Created by SharpDevelop.
' User: Bryan
' Date: 3/25/2010
' Time: 8:46 PM
Imports Microsoft.UpdateServices.Administration
Imports System.Data
Imports System.IO
Imports System.Xml
Imports System.Xml.XPath
Imports System.Xml.Schema


Partial Public Class ImportCatalogForm
    Private m_extractPath As String

    Public Sub New()
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        Me.InitializeComponent()

    End Sub

    ''' <summary>
    ''' Populate the DGV with SDPs from the file.
    ''' </summary>
    ''' <param name="path">Path to SDP XML file.</param>
    ''' <returns>DialogResult</returns>
    Public Overloads Function ShowDialog(path As String) As DialogResult
        Dim doc As XmlDocument = New XmlDocument

        'Clear datasource.
        If Not dgvUpdates.Rows Is Nothing Then dgvUpdates.Rows.Clear()

        'Verify that a filename was passed in and that is exists.
        If Not String.IsNullOrEmpty(path) AndAlso _
            File.Exists(path) Then

            'Verify that a CAB or XML file was passed.
            'If this is a CAB file then extract it.
            If Strings.Right(path, 3).ToLower = "cab" Then

                'Extract the file to a new temporary path.
                Dim tmpExtract As CabLib.Extract = New CabLib.Extract()
                m_extractPath = System.IO.Path.Combine(System.IO.Path.GetTempPath, System.IO.Path.GetRandomFileName)
                tmpExtract.ExtractFile(path, m_extractPath)
                path = Nothing 'Clear the import file

                'Loop through the temp folder and find the XML file.
                For Each tmpFile As String In Directory.GetFiles(m_extractPath)
                    If Strings.Right(tmpFile, 3).ToLower = "xml" Then
                        path = tmpFile
                        Exit For
                    End If
                Next

                'Make sure that an XML file was found in the CAB file.
                If String.IsNullOrEmpty(path) Then
                    MsgBox(Globals.globalRM.GetString("error_import_catalog_no_xml"))
                    Return Nothing
                End If

            ElseIf Not Strings.Right(path, 3).ToLower = "xml" Then
                Return Nothing
            End If

            'Create the namespace and add the lar and bar namespaces.
            Dim nsmgr As XmlNamespaceManager = New XmlNamespaceManager(New NameTable())
            nsmgr.AddNamespace("", "http://www.w3.org/2001/XMLSchema")
            nsmgr.AddNamespace("smc", "http://schemas.microsoft.com/sms/2005/04/CorporatePublishing/SystemsManagementCatalog.xsd")

            'Load the document.
            doc.Load(path)

            'Loop through each SDP node and load it.
            For Each tmpNode As XmlNode In doc.SelectNodes("smc:SystemsManagementCatalog/smc:SoftwareDistributionPackage", nsmgr)

                'We are using the deprecated constructor because the new one gives a validation error for no good reason.
                Dim tmpSdp As SoftwareDistributionPackage = New SoftwareDistributionPackage(tmpNode.CreateNavigator)

                'Add the new row and set the first column's tag as the SDP object.
                Dim tmpRow As Integer = dgvUpdates.Rows.Add(New Object() {False, False, tmpSdp.Title})
                dgvUpdates.Rows(tmpRow).Cells("Include").Tag = tmpSdp
            Next

        End If

        Return MyBase.ShowDialog
    End Function

    ''' <summary>
    ''' Publish the selected SDPs to the server.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub BtnImportClick(sender As Object, e As EventArgs)
        Dim tmpSDP As SoftwareDistributionPackage
        'Loop through each row.
        For Each tmpRow As DataGridViewRow In dgvUpdates.Rows

            'If the row is selected and there is an SDP object for its tag.
            If DirectCast(tmpRow.Cells("Include").Value, Boolean) AndAlso _
                Not tmpRow.Cells("Include").Tag Is Nothing Then

                tmpSDP = DirectCast(tmpRow.Cells("Include").Tag, SoftwareDistributionPackage)

                If Globals.appSettings.DemoteClassification AndAlso _
                    (tmpSDP.PackageUpdateClassification = PackageUpdateClassification.CriticalUpdates OrElse _
                    tmpSDP.PackageUpdateClassification = PackageUpdateClassification.SecurityUpdates) Then
                    tmpSDP.PackageUpdateClassification = PackageUpdateClassification.Updates
                End If

                'Import the SDP file based on the metadata flag.
                If DirectCast(tmpRow.Cells("Metadata").Value, Boolean) Then
                    AsyncPublisher.PublishPackageMetaData(tmpSDP, Me)
                Else
                    AsyncPublisher.PublishPackageFromCatalog(tmpSDP, m_extractPath, Me)
                End If
            End If
        Next
    End Sub

    ''' <summary>
    ''' When we close the form, clear any temporary directory created.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub ImportCatalogFormFormClosed(sender As Object, e As FormClosedEventArgs)
        'If a temp directory was created, delete it.
        If Not String.IsNullOrEmpty(m_extractPath) AndAlso Directory.Exists(m_extractPath) Then
            Directory.Delete(m_extractPath, True)
        End If
    End Sub
End Class
