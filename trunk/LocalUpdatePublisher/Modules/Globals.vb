﻿' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' Globals is a place for global variables and routines.
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 10/22/2009
' Time: 3:43 PM

Imports Microsoft.UpdateServices.Administration
Imports System.Resources
Imports System.Threading

Module Globals
	Public appSettings As Settings
	Public localUpdatesScope As UpdateScope
	Public defaultPaddingSize as Integer = 10
	Public globalRM As ResourceManager
	Public globalTP As ThreadPool
End Module