Option Explicit On
Option Strict On
' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
'SecureTextBox
' This is a TextBox implementation that uses the System.Security.SecureString as its backing
' store instead of standard managed string instance. At no time, is a managed string instance
' used to hold a component of the textual entry.
' It does not display any text and relies on the 'PasswordChar' character to display the amount of
' characters entered. If no password char is defined, then an 'asterisk' is used.
'
' This class is the work of Paul Glavich and can be found here:
' http://weblogs.asp.net/pglavich/archive/2006/03/14/440191.aspx

#Region "Using Statements"

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Security
Imports System.Security.Permissions
Imports System.Runtime.InteropServices

#End Region



Partial Public Class SecureTextBox
    Inherits TextBox
#Region "Private fields"

    Private m_displayChar As Boolean ' = False
    Private m_secureEntry As New SecureString()

#End Region

#Region "Constructor"
    Public Sub New()
        InitializeComponent()

        ' default to an asterisk
        Me.PasswordChar = "*"c
    End Sub

#End Region

#Region "Public properties"

    ''' <summary>
    ''' The secure string instance captured so far.
    ''' This is the preferred method of accessing the string contents.
    ''' </summary>
    Public Property SecureText() As SecureString
        Get
            Return m_secureEntry
        End Get
        Set(value As SecureString)
            m_secureEntry = value
        End Set
    End Property

    ''' <summary>
    ''' Allows the consumer to retrieve this string instance as a character array. NOte that this is still
    ''' visible plainly in memory and should be 'consumed' as quickly as possible, then the contents
    ''' 'zero-ed' so that they cannot be viewed.
    ''' </summary>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", _
        "CA1819:PropertiesShouldNotReturnArrays")> _
    Public ReadOnly Property CharacterData() As Char()
        Get
            Dim bytes As Char() = New Char(m_secureEntry.Length - 1) {}
            Dim ptr As IntPtr = IntPtr.Zero

            Try
                ptr = Marshal.SecureStringToBSTR(m_secureEntry)
                bytes = New Char(m_secureEntry.Length - 1) {}
                Marshal.Copy(ptr, bytes, 0, m_secureEntry.Length)
            Finally
                If ptr <> IntPtr.Zero Then
                    Marshal.ZeroFreeBSTR(ptr)
                End If
            End Try

            Return bytes
        End Get
    End Property


#End Region

#Region "ProcessKeyMessage"
    <SecurityPermission(SecurityAction.LinkDemand, Flags:=SecurityPermissionFlag.UnmanagedCode)> _
    Protected Overloads Overrides Function ProcessKeyMessage(ByRef m As Message) As Boolean

        If m_displayChar Then
            Return MyBase.ProcessKeyMessage(m)
        Else
            m_displayChar = True
            Return True
        End If
    End Function

#End Region

#Region "IsInputChar"

    Protected Overloads Overrides Function IsInputChar(charCode As Char) As Boolean
        Dim startPos As Integer = Me.SelectionStart

        Dim isChar As Boolean = MyBase.IsInputChar(charCode)
        If isChar Then
            Dim keyCode As Integer = Val(charCode)

            ' If the key pressed is NOT a control/cursor type key, then add it to our instance.
            ' Note: This does not catch the SHIFT key or anything like that
            If Not [Char].IsControl(charCode) AndAlso Not Char.IsHighSurrogate(charCode) AndAlso _
                Not Char.IsLowSurrogate(charCode) Then

                If Me.SelectionLength > 0 Then
                    For i As Integer = 0 To Me.SelectionLength - 1
                        m_secureEntry.RemoveAt(Me.SelectionStart)
                    Next
                End If

                If startPos = m_secureEntry.Length Then
                    m_secureEntry.AppendChar(charCode)
                Else
                    m_secureEntry.InsertAt(startPos, charCode)
                End If

                Me.Text = New String("*"c, m_secureEntry.Length)


                m_displayChar = False
                startPos += 1

                Me.SelectionStart = startPos
            Else
                ' We need to check what key has been pressed.

                Select Case keyCode
                    Case CInt(Keys.Back)
                        If Me.SelectionLength = 0 AndAlso startPos > 0 Then
                            startPos -= 1
                            m_secureEntry.RemoveAt(startPos)
                            Me.Text = New String("*"c, m_secureEntry.Length)
                            Me.SelectionStart = startPos
                        ElseIf Me.SelectionLength > 0 Then
                            For i As Integer = 0 To Me.SelectionLength - 1
                                m_secureEntry.RemoveAt(Me.SelectionStart)
                            Next
                        End If
                        m_displayChar = False
                        ' If we don't do this, we get a 'double' BACK keystroke effect
                        Exit Select
                End Select
            End If
        Else
            m_displayChar = True
        End If

        Return isChar
    End Function

#End Region

#Region "IsInputKey"

    Protected Overloads Overrides Function IsInputKey(keyData As Keys) As Boolean
        Dim result As Boolean = True

        ' Note: This whole section is only to deal with the 'Delete' key.

        Dim allowedToDelete As Boolean = (((keyData And Keys.Delete) = Keys.Delete))

        ' Debugging only
        'this.Parent.Text = keyData.ToString() + " " + ((int)keyData).ToString() + " allowedToDelete = " + allowedToDelete.ToString();

        If allowedToDelete Then
            If Me.SelectionLength = m_secureEntry.Length Then
                m_secureEntry.Clear()
            ElseIf Me.SelectionLength > 0 Then
                For i As Integer = 0 To Me.SelectionLength - 1
                    m_secureEntry.RemoveAt(Me.SelectionStart)

                Next
            Else
                If (keyData And Keys.Delete) = Keys.Delete AndAlso Me.SelectionStart < Me.Text.Length Then
                    m_secureEntry.RemoveAt(Me.SelectionStart)
                End If

            End If
        End If

        Return result

    End Function

#End Region

End Class

