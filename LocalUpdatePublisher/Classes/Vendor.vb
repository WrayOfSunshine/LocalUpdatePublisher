Option Explicit On
Option Strict On
' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
'Vendor
' This class is used to create a vendor object
' that holds a collection containing their products.
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 1/28/2010
' Time: 1:33 PM
Public Class Vendor
    Private m_name As String
    Private m_products As Collections.Generic.List(Of String)

    Sub New()
        m_name = ""
        m_products = New Collections.Generic.List(Of String)
    End Sub
    ''' <summary>
    ''' Create vendor object.
    ''' </summary>
    ''' <param name="name">Name of vendor.</param>
    Sub New(name As String)
        m_name = name
        m_products = New Collections.Generic.List(Of String)
    End Sub
    ''' <summary>
    ''' Create vendor object.
    ''' </summary>
    ''' <param name="name">Name of vendor.</param>
    ''' <param name="products"Collection of vendor's products.></param>
    ''' <remarks></remarks>
    Sub New(name As String, products As Collections.Generic.List(Of String))
        m_name = name
        m_products = products
    End Sub

    ''' <summary>
    ''' Property Vendor Name
    ''' </summary>
    Public Property Name() As String
        Get
            Return m_name
        End Get
        Set(value As String)
            m_name = value
        End Set
    End Property

    ''' <summary>
    ''' Property Products
    ''' </summary>
    Public Property Products() As Collections.Generic.List(Of String)
        Get
            Return m_products
        End Get
        Set(value As Collections.Generic.List(Of String))
            m_products = value
        End Set
    End Property

End Class

