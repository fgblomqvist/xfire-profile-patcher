<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
        Me.cboxAutoPatch = New System.Windows.Forms.CheckBox()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.HelpTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.cboxRestartXfire = New System.Windows.Forms.CheckBox()
        Me.radbtnOnline = New System.Windows.Forms.RadioButton()
        Me.radbtnManually = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboxCheckForUpdates = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboxAutoPatch
        '
        Me.cboxAutoPatch.AutoSize = True
        Me.cboxAutoPatch.Location = New System.Drawing.Point(6, 30)
        Me.cboxAutoPatch.Name = "cboxAutoPatch"
        Me.cboxAutoPatch.Size = New System.Drawing.Size(175, 17)
        Me.cboxAutoPatch.TabIndex = 1
        Me.cboxAutoPatch.Text = "Autopatch on Windows Startup"
        Me.HelpTip.SetToolTip(Me.cboxAutoPatch, "XPP will start with windows and silently patch xfire and then quit.")
        Me.cboxAutoPatch.UseVisualStyleBackColor = True
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.Location = New System.Drawing.Point(77, 289)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 2
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(158, 289)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'HelpTip
        '
        Me.HelpTip.IsBalloon = True
        '
        'cboxRestartXfire
        '
        Me.cboxRestartXfire.AutoSize = True
        Me.cboxRestartXfire.Location = New System.Drawing.Point(34, 53)
        Me.cboxRestartXfire.Name = "cboxRestartXfire"
        Me.cboxRestartXfire.Size = New System.Drawing.Size(143, 17)
        Me.cboxRestartXfire.TabIndex = 4
        Me.cboxRestartXfire.Text = "Restart Xfire when done"
        Me.HelpTip.SetToolTip(Me.cboxRestartXfire, "If you enable this XPP will restart Xfire after it has patched it so " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "it will de" & _
        "tect games automatically without you needing to do anything.")
        Me.cboxRestartXfire.UseVisualStyleBackColor = True
        '
        'radbtnOnline
        '
        Me.radbtnOnline.AutoSize = True
        Me.radbtnOnline.Checked = True
        Me.radbtnOnline.Location = New System.Drawing.Point(10, 47)
        Me.radbtnOnline.Name = "radbtnOnline"
        Me.radbtnOnline.Size = New System.Drawing.Size(91, 17)
        Me.radbtnOnline.TabIndex = 1
        Me.radbtnOnline.TabStop = True
        Me.radbtnOnline.Text = "Automatically"
        Me.HelpTip.SetToolTip(Me.radbtnOnline, "Fetches new game profiles each time the " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Application is started.")
        Me.radbtnOnline.UseVisualStyleBackColor = True
        '
        'radbtnManually
        '
        Me.radbtnManually.AutoSize = True
        Me.radbtnManually.Location = New System.Drawing.Point(10, 70)
        Me.radbtnManually.Name = "radbtnManually"
        Me.radbtnManually.Size = New System.Drawing.Size(69, 17)
        Me.radbtnManually.TabIndex = 3
        Me.radbtnManually.Text = "Manually"
        Me.HelpTip.SetToolTip(Me.radbtnManually, "You update the profiles manually by right-clicking the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "game profiles box and sel" & _
        "ecting 'Update Game Profiles'")
        Me.radbtnManually.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.radbtnManually)
        Me.GroupBox1.Controls.Add(Me.radbtnOnline)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 105)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(282, 102)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Game Profiles"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(252, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Choose how the game profiles should be updated:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboxAutoPatch)
        Me.GroupBox2.Controls.Add(Me.cboxRestartXfire)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(282, 87)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "AutoPatcher"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboxCheckForUpdates)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 213)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(282, 61)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Updates"
        '
        'cboxCheckForUpdates
        '
        Me.cboxCheckForUpdates.AutoSize = True
        Me.cboxCheckForUpdates.Location = New System.Drawing.Point(10, 28)
        Me.cboxCheckForUpdates.Name = "cboxCheckForUpdates"
        Me.cboxCheckForUpdates.Size = New System.Drawing.Size(199, 17)
        Me.cboxCheckForUpdates.TabIndex = 0
        Me.cboxCheckForUpdates.Text = "Check for updates on program start"
        Me.cboxCheckForUpdates.UseVisualStyleBackColor = True
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(306, 324)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.OKButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Settings"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboxAutoPatch As System.Windows.Forms.CheckBox
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents HelpTip As System.Windows.Forms.ToolTip
    Friend WithEvents cboxRestartXfire As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents radbtnOnline As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents radbtnManually As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cboxCheckForUpdates As System.Windows.Forms.CheckBox
End Class
