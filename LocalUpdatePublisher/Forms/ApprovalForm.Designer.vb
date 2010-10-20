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
		Me.ComputerGroup = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.Approval = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.cntxtMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.approveForInstallToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.approveForRemovalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.notApprovedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.CreationDate = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.ApprovalAction = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.TargetGroup = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.btnOK = New System.Windows.Forms.Button
		Me.btnCancel = New System.Windows.Forms.Button
		Me.lblUninstallable = New System.Windows.Forms.Label
		Me.btnReload = New System.Windows.Forms.Button
		CType(Me.dgvApprovals,System.ComponentModel.ISupportInitialize).BeginInit
		Me.cntxtMenuStrip.SuspendLayout
		Me.SuspendLayout
		'
		'lblInfo
		'
		Me.lblInfo.Location = New System.Drawing.Point(12, 17)
		Me.lblInfo.Name = "lblInfo"
		Me.lblInfo.Size = New System.Drawing.Size(506, 21)
		Me.lblInfo.TabIndex = 0
		'
		'dgvApprovals
		'
		Me.dgvApprovals.AllowUserToAddRows = false
		Me.dgvApprovals.AllowUserToDeleteRows = false
		Me.dgvApprovals.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
						Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.dgvApprovals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.dgvApprovals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvApprovals.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ComputerGroup, Me.Approval, Me.CreationDate, Me.ApprovalAction, Me.TargetGroup})
		Me.dgvApprovals.Location = New System.Drawing.Point(5, 41)
		Me.dgvApprovals.Name = "dgvApprovals"
		Me.dgvApprovals.ReadOnly = true
		Me.dgvApprovals.RowHeadersVisible = false
		Me.dgvApprovals.Size = New System.Drawing.Size(568, 299)
		Me.dgvApprovals.TabIndex = 1
		AddHandler Me.dgvApprovals.CellMouseDown, AddressOf Me.DtaGridViewCellMouseDown
		'
		'ComputerGroup
		'
		Me.ComputerGroup.FillWeight = 142.2902!
		Me.ComputerGroup.HeaderText = "Computer Group"
		Me.ComputerGroup.Name = "ComputerGroup"
		Me.ComputerGroup.ReadOnly = true
		'
		'Approval
		'
		Me.Approval.ContextMenuStrip = Me.cntxtMenuStrip
		Me.Approval.FillWeight = 96.79607!
		Me.Approval.HeaderText = "Approval"
		Me.Approval.Name = "Approval"
		Me.Approval.ReadOnly = true
		Me.Approval.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
		Me.Approval.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
		'
		'cntxtMenuStrip
		'
		Me.cntxtMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.approveForInstallToolStripMenuItem, Me.approveForRemovalToolStripMenuItem, Me.notApprovedToolStripMenuItem})
		Me.cntxtMenuStrip.Name = "contextMenuStrip"
		Me.cntxtMenuStrip.Size = New System.Drawing.Size(188, 70)
		'
		'approveForInstallToolStripMenuItem
		'
		Me.approveForInstallToolStripMenuItem.Name = "approveForInstallToolStripMenuItem"
		Me.approveForInstallToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
		Me.approveForInstallToolStripMenuItem.Text = "Approve for Install"
		AddHandler Me.approveForInstallToolStripMenuItem.Click, AddressOf Me.ApproveForInstallToolStripMenuItemClick
		'
		'approveForRemovalToolStripMenuItem
		'
		Me.approveForRemovalToolStripMenuItem.Name = "approveForRemovalToolStripMenuItem"
		Me.approveForRemovalToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
		Me.approveForRemovalToolStripMenuItem.Text = "Approve for Removal"
		AddHandler Me.approveForRemovalToolStripMenuItem.Click, AddressOf Me.ApproveForRemovalToolStripMenuItemClick
		'
		'notApprovedToolStripMenuItem
		'
		Me.notApprovedToolStripMenuItem.Name = "notApprovedToolStripMenuItem"
		Me.notApprovedToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
		Me.notApprovedToolStripMenuItem.Text = "Not Approved"
		AddHandler Me.notApprovedToolStripMenuItem.Click, AddressOf Me.NotApprovedToolStripMenuItemClick
		'
		'CreationDate
		'
		Me.CreationDate.FillWeight = 60.9137!
		Me.CreationDate.HeaderText = "Date"
		Me.CreationDate.Name = "CreationDate"
		Me.CreationDate.ReadOnly = true
		'
		'ApprovalAction
		'
		Me.ApprovalAction.HeaderText = "Approval Action"
		Me.ApprovalAction.Name = "ApprovalAction"
		Me.ApprovalAction.ReadOnly = true
		Me.ApprovalAction.Visible = false
		'
		'TargetGroup
		'
		Me.TargetGroup.HeaderText = "Target Group"
		Me.TargetGroup.Name = "TargetGroup"
		Me.TargetGroup.ReadOnly = true
		Me.TargetGroup.Visible = false
		'
		'btnOK
		'
		Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnOK.Enabled = false
		Me.btnOK.Location = New System.Drawing.Point(363, 364)
		Me.btnOK.Name = "btnOK"
		Me.btnOK.Size = New System.Drawing.Size(99, 28)
		Me.btnOK.TabIndex = 2
		Me.btnOK.Text = "Ok"
		Me.btnOK.UseVisualStyleBackColor = true
		AddHandler Me.btnOK.Click, AddressOf Me.btnOKClick
		'
		'btnCancel
		'
		Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Location = New System.Drawing.Point(468, 364)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(99, 28)
		Me.btnCancel.TabIndex = 3
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.UseVisualStyleBackColor = true
		'
		'lblUninstallable
		'
		Me.lblUninstallable.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.lblUninstallable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblUninstallable.Location = New System.Drawing.Point(7, 348)
		Me.lblUninstallable.Name = "lblUninstallable"
		Me.lblUninstallable.Size = New System.Drawing.Size(429, 14)
		Me.lblUninstallable.TabIndex = 5
		Me.lblUninstallable.Text = "This update cannot be uninstalled."
		Me.lblUninstallable.Visible = false
		'
		'btnReload
		'
		Me.btnReload.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.btnReload.Location = New System.Drawing.Point(24, 364)
		Me.btnReload.Name = "btnReload"
		Me.btnReload.Size = New System.Drawing.Size(99, 28)
		Me.btnReload.TabIndex = 6
		Me.btnReload.Text = "Reload"
		Me.btnReload.UseVisualStyleBackColor = true
		AddHandler Me.btnReload.Click, AddressOf Me.BtnReloadClick
		'
		'ApprovalForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.btnCancel
		Me.ClientSize = New System.Drawing.Size(580, 397)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnReload)
		Me.Controls.Add(Me.btnOK)
		Me.Controls.Add(Me.lblUninstallable)
		Me.Controls.Add(Me.lblInfo)
		Me.Controls.Add(Me.dgvApprovals)
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.MinimizeBox = false
		Me.Name = "ApprovalForm"
		Me.ShowIcon = false
		Me.ShowInTaskbar = false
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Approve Update"
		AddHandler FormClosed, AddressOf Me.UpdateApprovalFormFormClosed
		CType(Me.dgvApprovals,System.ComponentModel.ISupportInitialize).EndInit
		Me.cntxtMenuStrip.ResumeLayout(false)
		Me.ResumeLayout(false)
	End Sub
	Private CreationDate As System.Windows.Forms.DataGridViewTextBoxColumn
	Private btnOK As System.Windows.Forms.Button
	Private btnReload As System.Windows.Forms.Button
	Private dgvApprovals As System.Windows.Forms.DataGridView
	Private TargetGroup As System.Windows.Forms.DataGridViewTextBoxColumn
	Private ApprovalAction As System.Windows.Forms.DataGridViewTextBoxColumn
	Private notApprovedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private approveForRemovalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private approveForInstallToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private Approval As System.Windows.Forms.DataGridViewTextBoxColumn
	Private ComputerGroup As System.Windows.Forms.DataGridViewTextBoxColumn
	Private lblUninstallable As System.Windows.Forms.Label
	Private cntxtMenuStrip As System.Windows.Forms.ContextMenuStrip
	Private btnCancel As System.Windows.Forms.Button
	Private lblInfo As System.Windows.Forms.Label
End Class
