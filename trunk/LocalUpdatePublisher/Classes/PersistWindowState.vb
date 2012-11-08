Option Explicit On
Option Strict On
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
	
	Public Property Parent() As Form
		
		' subscribe to parent form's events
		
		' get initial width and height in case form is never resized
		Get
			Return m_parent
		End Get
		Set
			m_parent = value
			AddHandler m_parent.Closing, New System.ComponentModel.CancelEventHandler(AddressOf OnClosing)
			AddHandler m_parent.Resize, New System.EventHandler(AddressOf OnResize)
			AddHandler m_parent.Move, New System.EventHandler(AddressOf OnMove)
			AddHandler m_parent.Load, New System.EventHandler(AddressOf OnLoad)
			m_normalWidth = m_parent.Width
			m_normalHeight = m_parent.Height
		End Set
	End Property
	
	Public WriteOnly Property AllowSaveMinimized() As Boolean
		Set
			m_allowSaveMinimized = value
		End Set
	End Property
	
	Private Sub OnResize(sender As Object, e As System.EventArgs)
		' save width and height
		If m_parent.WindowState = FormWindowState.Normal Then
			m_normalWidth = m_parent.Width
			m_normalHeight = m_parent.Height
		End If
		
		Call EnsureFormVisible
	End Sub
	
	Private Sub OnMove(sender As Object, e As System.EventArgs)
		' save position
		If m_parent.WindowState = FormWindowState.Normal Then
			m_normalLeft = m_parent.Left
			m_normalTop = m_parent.Top
		End If
		' save state
		m_windowState = m_parent.WindowState
	End Sub
	
	Private Sub OnClosing(sender As Object, e As System.ComponentModel.CancelEventArgs)
		' save position, size and state
		appSettings.WindowLeft = m_normalLeft
		appSettings.WindowTop = m_normalTop
		appSettings.WindowWidth = m_normalWidth
		appSettings.WindowHeight = m_normalHeight
		
		' check if we are allowed to save the state as minimized (not normally)
		If Not m_allowSaveMinimized Then
			If m_windowState = FormWindowState.Minimized Then
				m_windowState = FormWindowState.Normal
			End If
		End If
		
		appSettings.WindowState = CInt(m_windowState)
		
		' fire SaveState event
		RaiseEvent SaveStateEvent(Me)
	End Sub
	
	Private Sub OnLoad(sender As Object, e As System.EventArgs)
		' attempt to read state from registry
		
		If appSettings IsNot Nothing Then
			Dim left As Integer = appSettings.WindowLeft
			Dim top As Integer = appSettings.WindowTop
			Dim width As Integer = appSettings.WindowWidth
			Dim height As Integer = appSettings.WindowHeight
			Dim windowState As FormWindowState = CType(appSettings.WindowState, FormWindowState)
			
			m_parent.Location = New Point(left, top)
			m_parent.Size = New Size(width, height)
			m_parent.WindowState = windowState
			
			Call EnsureFormVisible
			
			' fire LoadState event
			RaiseEvent LoadStateEvent(Me)
		End If
	End Sub
	
	''' Ensures that the form is visible on the current screen -
	''' to be called after the form has been repositioned based
	''' on saved settings
	''' Form to be shown on screen
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

'Public Class AppForm
'	Inherits System.Windows.Forms.Form
'	Private m_windowState As PersistWindowState
'	
'	Public Sub New()
'		Me.Text = "RestoreFormState"
'		
'		m_windowState = New PersistWindowState()
'		m_windowState.Parent = Me
'		' set registry path in HKEY_CURRENT_USER
'		AddHandler m_windowState.LoadStateEvent, New PersistWindowState.WindowStateDelegate(AddressOf LoadState)
'		AddHandler m_windowState.SaveStateEvent, New PersistWindowState.WindowStateDelegate(AddressOf SaveState)
'	End Sub
'	
'	Private m_data As Integer = 34
'	
'	Private Sub LoadState(sender As Object)
'		' get additional state information from registry
'		m_data = appSettings.WindowData
'	End Sub
'	
'	Private Sub SaveState(sender As Object)
'		' save additional state information to registry
'		appSettings.WindowData = m_data
'	End Sub
'	
'	<STAThread> _
'		Private Shared Sub Main()
'		Application.Run(New AppForm())
'	End Sub
'End Class

