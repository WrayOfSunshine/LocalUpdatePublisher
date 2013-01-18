'
' Created by SharpDevelop.
' User: Bryan Dam
' Date: 8/31/2010
' Time: 8:53 AM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class ApprovalProgressForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ApprovalProgressForm))
		Me.dgvProgress = New System.Windows.Forms.DataGridView
		Me.Action = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.Result = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.pbUpdateApprovals = New System.Windows.Forms.ProgressBar
		Me.btnClose = New System.Windows.Forms.Button
		Me.btnCancel = New System.Windows.Forms.Button
		Me.btnPause = New System.Windows.Forms.Button
		Me.lblProgress = New System.Windows.Forms.Label
		Me.tlpMain = New System.Windows.Forms.TableLayoutPanel
		Me.tlpMain.SuspendLayout
		Me.SuspendLayout
		'
		'dgvProgress
		'
		Me.dgvProgress.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.dgvProgress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvProgress.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Action, Me.Result})
		Me.tlpMain.SetColumnSpan(Me.dgvProgress, 5)
		resources.ApplyResources(Me.dgvProgress, "dgvProgress")
		Me.dgvProgress.Name = "dgvProgress"
		Me.dgvProgress.RowHeadersVisible = false
		'
		'Action
		'
		Me.Action.FillWeight = 149.2386!
		resources.ApplyResources(Me.Action, "Action")
		Me.Action.Name = "Action"
		'
		'Result
		'
		Me.Result.FillWeight = 50.76142!
		resources.ApplyResources(Me.Result, "Result")
		Me.Result.Name = "Result"
		'
		'pbUpdateApprovals
		'
		Me.tlpMain.SetColumnSpan(Me.pbUpdateApprovals, 5)
		resources.ApplyResources(Me.pbUpdateApprovals, "pbUpdateApprovals")
		Me.pbUpdateApprovals.ForeColor = System.Drawing.Color.SeaGreen
		Me.pbUpdateApprovals.Name = "pbUpdateApprovals"
		'
		'btnClose
		'
		resources.ApplyResources(Me.btnClose, "btnClose")
		Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnClose.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnClose.Name = "btnClose"
		Me.btnClose.UseVisualStyleBackColor = true
		'
		'btnCancel
		'
		resources.ApplyResources(Me.btnCancel, "btnCancel")
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.UseVisualStyleBackColor = true
		'
		'btnPause
		'
		resources.ApplyResources(Me.btnPause, "btnPause")
		Me.btnPause.MinimumSize = New System.Drawing.Size(80, 25)
		Me.btnPause.Name = "btnPause"
		Me.btnPause.UseVisualStyleBackColor = true
		AddHandler Me.btnPause.Click, AddressOf Me.BtnPauseClick
		'
		'lblProgress
		'
		resources.ApplyResources(Me.lblProgress, "lblProgress")
		Me.tlpMain.SetColumnSpan(Me.lblProgress, 5)
		Me.lblProgress.Name = "lblProgress"
		'
		'tlpMain
		'
		resources.ApplyResources(Me.tlpMain, "tlpMain")
		Me.tlpMain.Controls.Add(Me.btnPause, 2, 3)
		Me.tlpMain.Controls.Add(Me.lblProgress, 0, 0)
		Me.tlpMain.Controls.Add(Me.btnCancel, 3, 3)
		Me.tlpMain.Controls.Add(Me.pbUpdateApprovals, 0, 1)
		Me.tlpMain.Controls.Add(Me.btnClose, 4, 3)
		Me.tlpMain.Controls.Add(Me.dgvProgress, 0, 2)
		Me.tlpMain.Name = "tlpMain"
		'
		'ApprovalProgressForm
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.btnClose
		Me.Controls.Add(Me.tlpMain)
		Me.MinimizeBox = false
		Me.Name = "ApprovalProgressForm"
		Me.ShowInTaskbar = false
		Me.tlpMain.ResumeLayout(false)
		Me.tlpMain.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
    Private WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Private WithEvents pbUpdateApprovals As System.Windows.Forms.ProgressBar
    Private WithEvents dgvProgress As System.Windows.Forms.DataGridView
    Private WithEvents lblProgress As System.Windows.Forms.Label
    Private WithEvents btnPause As System.Windows.Forms.Button
    Private WithEvents btnCancel As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents Result As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents Action As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
