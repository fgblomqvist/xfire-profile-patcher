Imports XfireProfilePatcher.WinFormsControls

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManageGames
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ManageGames))
        Me.lboxAddedGames = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.cboxGameProfiles = New System.Windows.Forms.ComboBox()
        Me.menuGameUpdate = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.UpdateGameProfilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveButton = New System.Windows.Forms.Button()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.btnAddManually = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblGameProfiles = New Global.XfireProfilePatcher.WinFormsControls.TransparentLabel()
        Me.lblCustomSettings = New System.Windows.Forms.LinkLabel()
        Me.HelpTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.EditButton = New System.Windows.Forms.Button()
        Me.ImportButton = New System.Windows.Forms.Button()
        Me.ExportButton = New System.Windows.Forms.Button()
        Me.bwCheckUpdates = New System.ComponentModel.BackgroundWorker()
        Me.btnContribute = New System.Windows.Forms.Button()
        Me.btnDIY = New System.Windows.Forms.Button()
        Me.menuGameUpdate.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lboxAddedGames
        '
        Me.lboxAddedGames.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lboxAddedGames.FormattingEnabled = True
        Me.lboxAddedGames.Location = New System.Drawing.Point(12, 25)
        Me.lboxAddedGames.Name = "lboxAddedGames"
        Me.lboxAddedGames.Size = New System.Drawing.Size(276, 134)
        Me.lboxAddedGames.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Games that will be patched:"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnAdd.Enabled = False
        Me.btnAdd.Location = New System.Drawing.Point(298, 58)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(49, 23)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'cboxGameProfiles
        '
        Me.cboxGameProfiles.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboxGameProfiles.ContextMenuStrip = Me.menuGameUpdate
        Me.cboxGameProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxGameProfiles.FormattingEnabled = True
        Me.cboxGameProfiles.Location = New System.Drawing.Point(6, 29)
        Me.cboxGameProfiles.Name = "cboxGameProfiles"
        Me.cboxGameProfiles.Size = New System.Drawing.Size(270, 21)
        Me.cboxGameProfiles.TabIndex = 3
        '
        'menuGameUpdate
        '
        Me.menuGameUpdate.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdateGameProfilesToolStripMenuItem})
        Me.menuGameUpdate.Name = "menuGameUpdate"
        Me.menuGameUpdate.Size = New System.Drawing.Size(182, 26)
        '
        'UpdateGameProfilesToolStripMenuItem
        '
        Me.UpdateGameProfilesToolStripMenuItem.Name = "UpdateGameProfilesToolStripMenuItem"
        Me.UpdateGameProfilesToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.UpdateGameProfilesToolStripMenuItem.Text = "Update Game Profiles"
        '
        'RemoveButton
        '
        Me.RemoveButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RemoveButton.Location = New System.Drawing.Point(294, 25)
        Me.RemoveButton.Name = "RemoveButton"
        Me.RemoveButton.Size = New System.Drawing.Size(73, 22)
        Me.RemoveButton.TabIndex = 4
        Me.RemoveButton.Text = "Remove"
        Me.RemoveButton.UseVisualStyleBackColor = True
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.Location = New System.Drawing.Point(213, 283)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 5
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.Location = New System.Drawing.Point(294, 283)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(73, 23)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "Cancel"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'btnAddManually
        '
        Me.btnAddManually.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddManually.Location = New System.Drawing.Point(12, 283)
        Me.btnAddManually.Name = "btnAddManually"
        Me.btnAddManually.Size = New System.Drawing.Size(88, 23)
        Me.btnAddManually.TabIndex = 7
        Me.btnAddManually.Text = "Add Manually"
        Me.btnAddManually.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblGameProfiles)
        Me.GroupBox1.Controls.Add(Me.lblCustomSettings)
        Me.GroupBox1.Controls.Add(Me.cboxGameProfiles)
        Me.GroupBox1.Controls.Add(Me.btnAdd)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 177)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(353, 93)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Add Game"
        '
        'lblGameProfiles
        '
        Me.lblGameProfiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGameProfiles.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblGameProfiles.Location = New System.Drawing.Point(10, 32)
        Me.lblGameProfiles.Name = "lblGameProfiles"
        Me.lblGameProfiles.Size = New System.Drawing.Size(219, 13)
        Me.lblGameProfiles.TabIndex = 11
        Me.lblGameProfiles.TabStop = False
        Me.lblGameProfiles.Text = "Searching for game profiles..."
        Me.lblGameProfiles.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'lblCustomSettings
        '
        Me.lblCustomSettings.AutoSize = True
        Me.lblCustomSettings.Enabled = False
        Me.lblCustomSettings.LinkColor = System.Drawing.Color.Black
        Me.lblCustomSettings.Location = New System.Drawing.Point(7, 67)
        Me.lblCustomSettings.Name = "lblCustomSettings"
        Me.lblCustomSettings.Size = New System.Drawing.Size(69, 13)
        Me.lblCustomSettings.TabIndex = 9
        Me.lblCustomSettings.TabStop = True
        Me.lblCustomSettings.Text = "Customize..."
        '
        'HelpTip
        '
        Me.HelpTip.AutoPopDelay = 5000
        Me.HelpTip.InitialDelay = 1500
        Me.HelpTip.IsBalloon = True
        Me.HelpTip.ReshowDelay = 100
        Me.HelpTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.HelpTip.ToolTipTitle = "Tooltip"
        '
        'EditButton
        '
        Me.EditButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EditButton.Location = New System.Drawing.Point(294, 53)
        Me.EditButton.Name = "EditButton"
        Me.EditButton.Size = New System.Drawing.Size(73, 22)
        Me.EditButton.TabIndex = 9
        Me.EditButton.Text = "Edit"
        Me.EditButton.UseVisualStyleBackColor = True
        '
        'ImportButton
        '
        Me.ImportButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImportButton.Location = New System.Drawing.Point(294, 81)
        Me.ImportButton.Name = "ImportButton"
        Me.ImportButton.Size = New System.Drawing.Size(73, 22)
        Me.ImportButton.TabIndex = 10
        Me.ImportButton.Text = "Import"
        Me.ImportButton.UseVisualStyleBackColor = True
        '
        'ExportButton
        '
        Me.ExportButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExportButton.Location = New System.Drawing.Point(294, 109)
        Me.ExportButton.Name = "ExportButton"
        Me.ExportButton.Size = New System.Drawing.Size(73, 22)
        Me.ExportButton.TabIndex = 11
        Me.ExportButton.Text = "Export"
        Me.ExportButton.UseVisualStyleBackColor = True
        '
        'bwCheckUpdates
        '
        Me.bwCheckUpdates.WorkerSupportsCancellation = True
        '
        'btnContribute
        '
        Me.btnContribute.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnContribute.Location = New System.Drawing.Point(294, 137)
        Me.btnContribute.Name = "btnContribute"
        Me.btnContribute.Size = New System.Drawing.Size(73, 22)
        Me.btnContribute.TabIndex = 12
        Me.btnContribute.Text = "Contribute"
        Me.btnContribute.UseVisualStyleBackColor = True
        '
        'btnDIY
        '
        Me.btnDIY.Location = New System.Drawing.Point(106, 283)
        Me.btnDIY.Name = "btnDIY"
        Me.btnDIY.Size = New System.Drawing.Size(75, 23)
        Me.btnDIY.TabIndex = 13
        Me.btnDIY.Text = "DIY Wizard"
        Me.btnDIY.UseVisualStyleBackColor = True
        Me.btnDIY.Visible = False
        '
        'ManageGames
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(379, 315)
        Me.Controls.Add(Me.btnDIY)
        Me.Controls.Add(Me.btnContribute)
        Me.Controls.Add(Me.ExportButton)
        Me.Controls.Add(Me.ImportButton)
        Me.Controls.Add(Me.EditButton)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnAddManually)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.RemoveButton)
        Me.Controls.Add(Me.lboxAddedGames)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ManageGames"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Manage Games"
        Me.menuGameUpdate.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lboxAddedGames As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents cboxGameProfiles As System.Windows.Forms.ComboBox
    Friend WithEvents RemoveButton As System.Windows.Forms.Button
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents btnAddManually As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents HelpTip As System.Windows.Forms.ToolTip
    Friend WithEvents EditButton As System.Windows.Forms.Button
    Friend WithEvents ImportButton As System.Windows.Forms.Button
    Friend WithEvents ExportButton As System.Windows.Forms.Button
    Friend WithEvents menuGameUpdate As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents UpdateGameProfilesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bwCheckUpdates As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblCustomSettings As System.Windows.Forms.LinkLabel
    Friend WithEvents btnContribute As System.Windows.Forms.Button
    Friend WithEvents btnDIY As System.Windows.Forms.Button
    Friend WithEvents lblGameProfiles As TransparentLabel
End Class
