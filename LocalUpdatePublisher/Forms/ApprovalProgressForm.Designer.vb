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
		Me.dgvProgress = New System.Windows.Forms.DataGridView
		Me.Action = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.Result = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.pbUpdateApprovals = New System.Windows.Forms.ProgressBar
		Me.btnClose = New System.Windows.Forms.Button
		Me.btnCancel = New System.Windows.Forms.Button
		Me.btnPause = New System.Windows.Forms.Button
		Me.lblProgress = New System.Windows.Forms.Label
		CType(Me.dgvProgress,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'dgvProgress
		'
		Me.dgvProgress.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
						Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.dgvProgress.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.dgvProgress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvProgress.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Action, Me.Result})
		Me.dgvProgress.Location = New System.Drawing.Point(12, 72)
		Me.dgvProgress.Name = "dgvProgress"
		Me.dgvProgress.RowHeadersVisible = false
		Me.dgvProgress.Size = New System.Drawing.Size(561, 211)
		Me.dgvProgress.TabIndex = 0
		'
		'Action
		'
		Me.Action.FillWeight = 149.2386!
		Me.Action.HeaderText = "Action"
		Me.Action.Name = "Action"
		'
		'Result
		'
		Me.Result.FillWeight = 50.76142!
		Me.Result.HeaderText = "Result"
		Me.Result.Name = "Result"
		'
		'pbUpdateApprovals
		'
		Me.pbUpdateApprovals.ForeColor = System.Drawing.Color.SeaGreen
		Me.pbUpdateApprovals.Location = New System.Drawing.Point(12, 51)
		Me.pbUpdateApprovals.Name = "pbUpdateApprovals"
		Me.pbUpdateApprovals.Size = New System.Drawing.Size(561, 14)
		Me.pbUpdateApprovals.TabIndex = 1
		'
		'btnClose
		'
		Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnClose.Location = New System.Drawing.Point(498, 289)
		Me.btnClose.Name = "btnClose"
		Me.btnClose.Size = New System.Drawing.Size(75, 23)
		Me.btnClose.TabIndex = 6
		Me.btnClose.Text = "Close"
		Me.btnClose.UseVisualStyleBackColor = true
		'
		'btnCancel
		'
		Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Location = New System.Drawing.Point(417, 289)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(75, 23)
		Me.btnCancel.TabIndex = 5
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.UseVisualStyleBackColor = true
		'
		'btnPause
		'
		Me.btnPause.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.btnPause.Location = New System.Drawing.Point(336, 289)
		Me.btnPause.Name = "btnPause"
		Me.btnPause.Size = New System.Drawing.Size(75, 23)
		Me.btnPause.TabIndex = 4
		Me.btnPause.Text = "Pause"
		Me.btnPause.UseVisualStyleBackColor = true
		AddHandler Me.btnPause.Click, AddressOf Me.BtnPauseClick
		'
		'lblProgress
		'
		Me.lblProgress.Location = New System.Drawing.Point(12, 9)
		Me.lblProgress.Name = "lblProgress"
		Me.lblProgress.Size = New System.Drawing.Size(561, 32)
		Me.lblProgress.TabIndex = 7
		Me.lblProgress.Text = "lblProgress"
		Me.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'ApprovalProgressForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(585, 315)
		Me.Controls.Add(Me.lblProgress)
		Me.Controls.Add(Me.btnClose)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnPause)
		Me.Controls.Add(Me.pbUpdateApprovals)
		Me.Controls.Add(Me.dgvProgress)
		Me.Name = "ApprovalProgressForm"
		Me.Text = "Approval Progress"
		CType(Me.dgvProgress,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
	End Sub
	Private pbUpdateApprovals As System.Windows.Forms.ProgressBar
	Private dgvProgress As System.Windows.Forms.DataGridView
	Private lblProgress As System.Windows.Forms.Label
	Private btnPause As System.Windows.Forms.Button
	Private btnCancel As System.Windows.Forms.Button
	Private btnClose As System.Windows.Forms.Button
	Private Result As System.Windows.Forms.DataGridViewTextBoxColumn
	Private Action As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
