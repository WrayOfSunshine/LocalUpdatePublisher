Option Explicit On
Option Strict On
' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
' PersistWindowState
'
' Based on Joel Matthias's class found here: http://www.codeproject.com/KB/cs/restoreformstate.aspx
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 10/15/2010
' Time: 9:49 AM
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports Microsoft.Win32


Public Class PersistWindowState
    Inherits System.ComponentModel.Component

    ' event info that allows form to persist extra window state data
    Public Delegate Sub WindowStateDelegate(sender As Object)
    Public Event LoadStateEvent As WindowStateDelegate
    Public Event SaveStateEvent As WindowStateDelegate

    Private m_parent As Form
    Private m_normalLeft As Integer
    Private m_normalTop As Integer
    Private m_normalWidth As Integer
    Private m_normalHeight As Integer
    Private m_windowState As FormWindowState
    Private m_allowSaveMinimized As Boolean = False

    Public Sub New()
    End Sub
    ''' <summary>
    ''' Parent Form
    ''' </summary>
    ''' <value>Form</value>
    Public Property Parent() As Form

        ' subscribe to parent form's events

        ' get initial width and height in case form is never resized
        Get
            Return m_parent
        End Get
        Set(value As Form)
            m_parent = Value
            AddHandler m_parent.Closing, New System.ComponentModel.CancelEventHandler(AddressOf OnClosing)
            AddHandler m_parent.Resize, New System.EventHandler(AddressOf OnResize)
            AddHandler m_parent.Move, New System.EventHandler(AddressOf OnMove)
            AddHandler m_parent.Load, New System.EventHandler(AddressOf OnLoad)
            m_normalWidth = m_parent.Width
            m_normalHeight = m_parent.Height
        End Set
    End Property
    ''' <summary>
    ''' Allow settings to be saved when minimized.
    ''' </summary>
    ''' <value>Boolean</value>
    Public WriteOnly Property AllowSaveMinimized() As Boolean
        Set(value As Boolean)
            m_allowSaveMinimized = Value
        End Set
    End Property
    ''' <summary>
    ''' On Resize Event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub OnResize(sender As Object, e As System.EventArgs)
        ' save width and height
        If m_parent.WindowState = FormWindowState.Normal Then
            m_normalWidth = m_parent.Width
            m_normalHeight = m_parent.Height
        End If

        Call EnsureFormVisible()
    End Sub
    ''' <summary>
    ''' On Move Event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OnMove(sender As Object, e As System.EventArgs)
        ' save position
        If m_parent.WindowState = FormWindowState.Normal Then
            m_normalLeft = m_parent.Left
            m_normalTop = m_parent.Top
        End If
        ' save state
        m_windowState = m_parent.WindowState
    End Sub
    ''' <summary>
    ''' On Closing Event.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub OnClosing(sender As Object, e As System.ComponentModel.CancelEventArgs)
        ' save position, size and state
        Globals.appSettings.WindowLeft = m_normalLeft
        Globals.appSettings.WindowTop = m_normalTop
        Globals.appSettings.WindowWidth = m_normalWidth
        Globals.appSettings.WindowHeight = m_normalHeight

        ' check if we are allowed to save the state as minimized (not normally)
        If Not m_allowSaveMinimized Then
            If m_windowState = FormWindowState.Minimized Then
                m_windowState = FormWindowState.Normal
            End If
        End If

        Globals.appSettings.WindowState = CInt(m_windowState)

        ' fire SaveState event
        RaiseEvent SaveStateEvent(Me)
    End Sub
    ''' <summary>
    ''' On Load Event.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub OnLoad(sender As Object, e As System.EventArgs)
        ' attempt to read state from registry

        If Globals.appSettings IsNot Nothing Then
            Dim left As Integer = Globals.appSettings.WindowLeft
            Dim top As Integer = Globals.appSettings.WindowTop
            Dim width As Integer = Globals.appSettings.WindowWidth
            Dim height As Integer = Globals.appSettings.WindowHeight
            Dim windowState As FormWindowState = CType(Globals.appSettings.WindowState, FormWindowState)

            m_parent.Location = New Point(left, top)
            m_parent.Size = New Size(width, height)
            m_parent.WindowState = windowState

            Call EnsureFormVisible()

            ' fire LoadState event
            RaiseEvent LoadStateEvent(Me)
        End If
    End Sub

    ''' <summary>
    ''' Ensures that the form is visible on the current screen -
    ''' to be called after the form has been repositioned based
    ''' on saved settings
    ''' Form to be shown on screen
    ''' </summary>
    Private Sub EnsureFormVisible()

        Dim currentScreen As Screen = Screen.FromHandle(m_parent.Handle)
        ' Ensure top visible
        If (m_parent.Top < currentScreen.Bounds.Top) OrElse ((m_parent.Top + m_parent.Height) > (currentScreen.Bounds.Top + currentScreen.Bounds.Height)) Then
            m_parent.Top = currentScreen.Bounds.Top
        End If
        ' Ensure at least 60 px of Title Bar visible
        If ((m_parent.Left + m_parent.Width - 60) < currentScreen.Bounds.Left) OrElse ((m_parent.Left + 60) > (currentScreen.Bounds.Left + currentScreen.Bounds.Width)) Then
            m_parent.Left = currentScreen.Bounds.Left
        End If
    End Sub
End Class

