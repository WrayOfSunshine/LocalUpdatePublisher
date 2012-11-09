Option Explicit On
Option Strict On
' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
' 
' CustomTreeView
' Better handles icons in the treeview.
'
' RightToCopy & PublishAndPerish: OrlandoCurioso 2006
' Taken from http://www.codeproject.com/Articles/13999/Using-treenodes-with-and-without-images-in-a-TreeV?msg=2074901
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 11/1/2009
' Time: 9:06 PM
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms


Public Class CustomTreeView
    Inherits TreeView
    Public Const NOIMAGE As Integer = -1

    Public Sub New()
        MyBase.New()
        ' .NET Bug: Unless LineColor is set, Win32 treeview returns -1 (default), .NET returns Color.Black!
        MyBase.LineColor = SystemColors.GrayText

        MyBase.DrawMode = TreeViewDrawMode.OwnerDrawAll
    End Sub

    Protected Overrides Sub OnDrawNode(e As DrawTreeNodeEventArgs)
        Const SPACE_IL As Integer = 3
        ' space between Image and Label
        ' we only do additional drawing
        e.DrawDefault = True

        MyBase.OnDrawNode(e)

        If MyBase.ShowLines AndAlso MyBase.ImageList IsNot Nothing AndAlso e.Node.ImageIndex = NOIMAGE Then
            ' exclude root nodes, if root lines are disabled
            '&& (base.ShowRootLines || e.Node.Level > 0))
            ' Using lines & images, but this node has none: fill up missing treelines

            ' Image size
            Dim imgW As Integer = MyBase.ImageList.ImageSize.Width
            Dim imgH As Integer = MyBase.ImageList.ImageSize.Height

            ' Image center
            Dim xPos As Integer = e.Node.Bounds.Left - SPACE_IL - imgW \ 2
            Dim yPos As Integer = (e.Node.Bounds.Top + e.Node.Bounds.Bottom) \ 2

            ' Image rect
            Dim imgRect As New Rectangle(xPos, yPos, 0, 0)
            imgRect.Inflate(imgW \ 2, imgH \ 2)

            Using p As New Pen(MyBase.LineColor, 1)
                p.DashStyle = DashStyle.Dot

                ' account uneven Indent for both lines
                p.DashOffset = MyBase.Indent Mod 2

                ' Horizontal treeline across width of image
                ' account uneven half of delta ItemHeight & ImageHeight
                Dim yHor As Integer = yPos + ((MyBase.ItemHeight - imgRect.Height) \ 2) Mod 2

                'if (base.ShowRootLines || e.Node.Level > 0)
                '{
                '    e.Graphics.DrawLine(p, imgRect.Left, yHor, imgRect.Right, yHor);
                '}
                'else
                '{
                '    // for root nodes, if root lines are disabled, start at center
                '    e.Graphics.DrawLine(p, xPos - (int)p.DashOffset, yHor, imgRect.Right, yHor);
                '}

                e.Graphics.DrawLine(p, If((MyBase.ShowRootLines OrElse e.Node.Level > 0), imgRect.Left, xPos - CInt(Math.Truncate(p.DashOffset))), yHor, imgRect.Right, yHor)


                If Not MyBase.CheckBoxes AndAlso e.Node.IsExpanded Then
                    ' Vertical treeline , offspring from NodeImage center to e.Node.Bounds.Bottom
                    ' yStartPos: account uneven Indent and uneven half of delta ItemHeight & ImageHeight
                    Dim yVer As Integer = yHor + CInt(Math.Truncate(p.DashOffset))
                    e.Graphics.DrawLine(p, xPos, yVer, xPos, e.Node.Bounds.Bottom)
                End If
            End Using
        End If
    End Sub

    ''' <summary>
    ''' After Collapse Event.
    ''' </summary>
    ''' <param name="e"></param>
    Protected Overrides Sub OnAfterCollapse(e As TreeViewEventArgs)
        MyBase.OnAfterCollapse(e)

        If Not MyBase.CheckBoxes AndAlso MyBase.ImageList IsNot Nothing AndAlso e.Node.ImageIndex = NOIMAGE Then
            ' DrawNode event not raised: redraw node with collapsed treeline
            MyBase.Invalidate(e.Node.Bounds)
        End If
    End Sub

End Class
