' Copyright (c) <2010> <Bryan R. Dam>
' Released under the MIT license as found in LICENSE.txt
'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 11/6/2009
' Time: 2:55 PM

Partial Class ApprovalForm
	Inherits System.Windows.Forms.Form
	
	''' <summary>
	''' Designer variable used to keep track of non-visual components.
	''' </summary>
	Private components As System.ComponentModel.IContainer
	
	''' <summary>
	''' Disposes resources used by the form.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If components IsNot Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub
	
	''' <summary>
	''' This method is required for Windows Forms designer support.
	''' Do not change the method contents inside the source code editor. The Forms designer might
	''' not be able to load this method if it was changed manually.
	''' </summary>
	Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ApprovalForm))
		Me.lblInfo = New System.Windows.Forms.Label
		Me.dgvApprovals = New System.Windows.Forms.DataGridView
		Me.cntxtMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.approveForOptionalInstallToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.approveForInstallToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.approveForRemovalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.notApprovedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.btnOK = New System.Windows.Forms.Button
		Me.btnCancel = New System.Windows.Forms.Button
		Me.lblUninstallable = New System.Windows.Forms.Label
		Me.btnReload = New System.Windows.Forms.Button
		Me.tlpMain = New System.Windows.Forms.TableLayoutPanel
		Me.ComputerGroup = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.approval = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.Deadline = New LocalUpdatePublisher.CalendarColumn
		Me.OptionalInstall = New System.Windows.Forms.DataGridViewCheckBoxColumn
		Me.CreationDate = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.ApprovalAction = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.TargetGroup = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.cntxtMenuStrip.SuspendLayout
		Me.tlpMain.SuspendLayout
		Me.SuspendLayout
		'
		'lblInfo
		'
		Me.tlpMain.SetColumnSpan(Me.lblInfo, 4)
		resources.ApplyResources(Me.lblInfo, "lblInfo")
		Me.lblInfo.Name = "lblInfo"
		'
		'dgvApprovals
		'
		Me.dgvApprovals.AllowUserToAddRows = false
		Me.dgvApprovals.AllowUserToDeleteRows = false
		Me.dgvApprovals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.dgvApprovals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvApprovals.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ComputerGroup, Me.approval, Me.Deadline, Me.OptionalInstall, Me.CreationDate, Me.ApprovalAction, Me.TargetGroup})
		Me.tlpMain.SetColumnSpan(Me.dgvApprovals, 4)
		resources.ApplyResources(Me.dgvApprovals, "dgvApprovals")
		Me.dgvApprovals.Name = "dgvApprovals"
		Me.dgvApprovals.RowHeadersVisible = false
		AddHandler Me.dgvApprovals.CellMouseDown, AddressOf Me.DtaGridViewCellMouseDown
		'
		'cntxtMenuStrip
		'
		Me.cntxtMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.approveForOptionalInstallToolStripMenuItem, Me.approveForInstallToolStripMenuItem, Me.approveForRemovalToolStripMenuItem, Me.notApprovedToolStripMenuItem})
		Me.cntxtMenuStrip.Name = "contextMenuStrip"
		resources.ApplyResources(Me.cntxtMenuStrip, "cntxtMenuStrip")
		'
		'approveForOptionalInstallToolStripMenuItem
		'
		Me.approveForOptionalInstallToolStripMenuItem.Name = "approveForOptionalInstallToolStripMenuItem"
		resources.ApplyResources(Me.approveForOptionalInstallToolStripMenuItem, "approveForOptionalInstallToolStripMenuItem")
		AddHandler Me.approveForOptionalInstallToolStripMenuItem.Click, AddressOf Me.ApproveForOptionalInstallToolStripMenuItemClick
		'
		'approveForInstallToolStripMenuItem
		'
		Me.approveForInstallToolStripMenuItem.Name = "approveForInstallToolStripMenuItem"
		resources.ApplyResources(Me.approveForInstallToolStripMenuItem, "approveForInstallToolStripMenuItem")
		AddHandler Me.approveForInstallToolStripMenuItem.Click, AddressOf Me.ApproveForInstallToolStripMenuItemClick
		'
		'approveForRemovalToolStripMenuItem
		'
		Me.approveForRemovalToolStripMenuItem.Name = "approveForRemovalToolStripMenuItem"
		resources.ApplyResources(Me.approveForRemovalToolStripMenuItem, "approveForRemovalToolStripMenuItem")
		AddHandler Me.approveForRemovalToolStripMenuItem.Click, AddressOf Me.ApproveForRemovalToolStripMenuItemClick
		'
		'notApprovedToolStripMenuItem
		'
		Me.notApprovedToolStripMenuItem.Name = "notApprovedToolStripMenuItem"
		resources.ApplyResources(Me.notApprovedToolStripMenuItem, "notApprovedToolStripMenuItem")
		AddHandler Me.notApprovedToolStripMenuItem.Click, AddressOf Me.NotApprovedToolStripMenuItemClick
		'
		'btnOK
		'
		resources.ApplyResources(Me.btnOK, "btnOK")
		Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnOK.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnOK.Name = "btnOK"
		Me.btnOK.UseVisualStyleBackColor = true
		AddHandler Me.btnOK.Click, AddressOf Me.btnOKClick
		'
		'btnCancel
		'
		resources.ApplyResources(Me.btnCancel, "btnCancel")
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.UseVisualStyleBackColor = true
		'
		'lblUninstallable
		'
		Me.tlpMain.SetColumnSpan(Me.lblUninstallable, 4)
		resources.ApplyResources(Me.lblUninstallable, "lblUninstallable")
		Me.lblUninstallable.Name = "lblUninstallable"
		'
		'btnReload
		'
		resources.ApplyResources(Me.btnReload, "btnReload")
		Me.btnReload.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnReload.Name = "btnReload"
		Me.btnReload.UseVisualStyleBackColor = true
		AddHandler Me.btnReload.Click, AddressOf Me.BtnReloadClick
		'
		'tlpMain
		'
		resources.ApplyResources(Me.tlpMain, "tlpMain")
		Me.tlpMain.Controls.Add(Me.btnCancel, 3, 3)
		Me.tlpMain.Controls.Add(Me.btnOK, 2, 3)
		Me.tlpMain.Controls.Add(Me.btnReload, 0, 3)
		Me.tlpMain.Controls.Add(Me.dgvApprovals, 0, 1)
		Me.tlpMain.Controls.Add(Me.lblInfo, 0, 0)
		Me.tlpMain.Controls.Add(Me.lblUninstallable, 0, 2)
		Me.tlpMain.Name = "tlpMain"
		'
		'ComputerGroup
		'
		Me.ComputerGroup.FillWeight = 30!
		resources.ApplyResources(Me.ComputerGroup, "ComputerGroup")
		Me.ComputerGroup.Name = "ComputerGroup"
		Me.ComputerGroup.ReadOnly = true
		'
		'approval
		'
		Me.approval.ContextMenuStrip = Me.cntxtMenuStrip
		Me.approval.FillWeight = 30!
		resources.ApplyResources(Me.approval, "approval")
		Me.approval.Name = "approval"
		Me.approval.ReadOnly = true
		Me.approval.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
		Me.approval.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
		'
		'Deadline
		'
		Me.Deadline.FillWeight = 25!
		resources.ApplyResources(Me.Deadline, "Deadline")
		Me.Deadline.Name = "Deadline"
		'
		'OptionalInstall
		'
		resources.ApplyResources(Me.OptionalInstall, "OptionalInstall")
		Me.OptionalInstall.Name = "OptionalInstall"
		'
		'CreationDate
		'
		Me.CreationDate.FillWeight = 15!
		resources.ApplyResources(Me.CreationDate, "CreationDate")
		Me.CreationDate.Name = "CreationDate"
		Me.CreationDate.ReadOnly = true
		'
		'ApprovalAction
		'
		resources.ApplyResources(Me.ApprovalAction, "ApprovalAction")
		Me.ApprovalAction.Name = "ApprovalAction"
		Me.ApprovalAction.ReadOnly = true
		'
		'TargetGroup
		'
		resources.ApplyResources(Me.TargetGroup, "TargetGroup")
		Me.TargetGroup.Name = "TargetGroup"
		Me.TargetGroup.ReadOnly = true
		'
		'ApprovalForm
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.btnCancel
		Me.Controls.Add(Me.tlpMain)
		Me.MinimizeBox = false
		Me.Name = "ApprovalForm"
		Me.ShowIcon = false
		Me.ShowInTaskbar = false
		AddHandler FormClosed, AddressOf Me.UpdateApprovalFormFormClosed
		Me.cntxtMenuStrip.ResumeLayout(false)
		Me.tlpMain.ResumeLayout(false)
		Me.tlpMain.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
    Private WithEvents approval As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents approveForOptionalInstallToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Private WithEvents Deadline As LocalUpdatePublisher.CalendarColumn
    Private WithEvents CreationDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents OptionalInstall As System.Windows.Forms.DataGridViewCheckBoxColumn
    Private WithEvents btnOK As System.Windows.Forms.Button
    Private WithEvents btnReload As System.Windows.Forms.Button
    Private WithEvents dgvApprovals As System.Windows.Forms.DataGridView
    Private WithEvents TargetGroup As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents ApprovalAction As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents notApprovedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents approveForRemovalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents approveForInstallToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ComputerGroup As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents lblUninstallable As System.Windows.Forms.Label
    Private WithEvents cntxtMenuStrip As System.Windows.Forms.ContextMenuStrip
    Private WithEvents btnCancel As System.Windows.Forms.Button
    Private WithEvents lblInfo As System.Windows.Forms.Label
End Class
