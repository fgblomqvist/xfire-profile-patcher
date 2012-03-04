<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XfireProfilePatcher
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XfireProfilePatcher))
        Me.btnPatch = New System.Windows.Forms.Button()
        Me.HelpTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.AboutLabel = New System.Windows.Forms.LinkLabel()
        Me.SettingsButton = New System.Windows.Forms.Button()
        Me.btnRestore = New System.Windows.Forms.Button()
        Me.TrayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.timerOne = New System.Windows.Forms.Timer(Me.components)
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.bw = New System.ComponentModel.BackgroundWorker()
        Me.bwCheckUpdates = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'btnPatch
        '
        Me.btnPatch.Location = New System.Drawing.Point(52, 12)
        Me.btnPatch.Name = "btnPatch"
        Me.btnPatch.Size = New System.Drawing.Size(110, 23)
        Me.btnPatch.TabIndex = 0
        Me.btnPatch.Text = "Patch"
        Me.btnPatch.UseVisualStyleBackColor = True
        '
        'HelpTip
        '
        Me.HelpTip.AutoPopDelay = 10000
        Me.HelpTip.InitialDelay = 2000
        Me.HelpTip.IsBalloon = True
        Me.HelpTip.ReshowDelay = 100
        Me.HelpTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(52, 41)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(110, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Manage Games"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'AboutLabel
        '
        Me.AboutLabel.ActiveLinkColor = System.Drawing.Color.Black
        Me.AboutLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.AboutLabel.AutoSize = True
        Me.AboutLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.AboutLabel.LinkColor = System.Drawing.SystemColors.ControlText
        Me.AboutLabel.Location = New System.Drawing.Point(12, 145)
        Me.AboutLabel.Name = "AboutLabel"
        Me.AboutLabel.Size = New System.Drawing.Size(35, 13)
        Me.AboutLabel.TabIndex = 3
        Me.AboutLabel.TabStop = True
        Me.AboutLabel.Text = "About"
        Me.AboutLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText
        '
        'SettingsButton
        '
        Me.SettingsButton.Location = New System.Drawing.Point(52, 70)
        Me.SettingsButton.Name = "SettingsButton"
        Me.SettingsButton.Size = New System.Drawing.Size(110, 23)
        Me.SettingsButton.TabIndex = 4
        Me.SettingsButton.Text = "Settings"
        Me.SettingsButton.UseVisualStyleBackColor = True
        '
        'btnRestore
        '
        Me.btnRestore.Location = New System.Drawing.Point(52, 99)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(110, 23)
        Me.btnRestore.TabIndex = 5
        Me.btnRestore.Text = "Restore Original"
        Me.btnRestore.UseVisualStyleBackColor = True
        '
        'TrayIcon
        '
        Me.TrayIcon.Icon = CType(resources.GetObject("TrayIcon.Icon"), System.Drawing.Icon)
        '
        'timerOne
        '
        Me.timerOne.Interval = 3000
        '
        'StatusLabel
        '
        Me.StatusLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatusLabel.Location = New System.Drawing.Point(94, 146)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(109, 13)
        Me.StatusLabel.TabIndex = 6
        Me.StatusLabel.Text = "-"
        Me.StatusLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'bw
        '
        '
        'bwCheckUpdates
        '
        '
        'XfireProfilePatcher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(213, 167)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.btnRestore)
        Me.Controls.Add(Me.SettingsButton)
        Me.Controls.Add(Me.AboutLabel)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnPatch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "XfireProfilePatcher"
        Me.Opacity = 0.0R
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "XPP"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPatch As System.Windows.Forms.Button
    Friend WithEvents HelpTip As System.Windows.Forms.ToolTip
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents AboutLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents SettingsButton As System.Windows.Forms.Button
    Friend WithEvents btnRestore As System.Windows.Forms.Button
    Friend WithEvents TrayIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents timerOne As System.Windows.Forms.Timer
    Friend WithEvents StatusLabel As System.Windows.Forms.Label
    Friend WithEvents bw As System.ComponentModel.BackgroundWorker
    Friend WithEvents bwCheckUpdates As System.ComponentModel.BackgroundWorker

End Class
