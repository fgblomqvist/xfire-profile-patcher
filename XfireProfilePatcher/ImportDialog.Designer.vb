<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportDialog
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

    Private Sub InitializeComponent()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.txtImportDir = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.ImportFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lboxGames = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(297, 46)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(25, 20)
        Me.btnBrowse.TabIndex = 1
        Me.btnBrowse.Text = "..."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtImportDir
        '
        Me.txtImportDir.Location = New System.Drawing.Point(12, 47)
        Me.txtImportDir.Name = "txtImportDir"
        Me.txtImportDir.ReadOnly = True
        Me.txtImportDir.Size = New System.Drawing.Size(279, 20)
        Me.txtImportDir.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(231, 26)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "This will allow you to import gameprofiles." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Please select the file you want to i" & _
    "mport from:"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancel.Location = New System.Drawing.Point(167, 236)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnImport
        '
        Me.btnImport.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnImport.Location = New System.Drawing.Point(86, 236)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(75, 23)
        Me.btnImport.TabIndex = 2
        Me.btnImport.Text = "Import"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'ImportFileDialog
        '
        Me.ImportFileDialog.DefaultExt = "xml"
        Me.ImportFileDialog.Filter = "Xfire Game Profiles (*.xml)|*.xml|All files (*.*)|*.*"
        Me.ImportFileDialog.Title = "Import game profiles"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(158, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "These games will be imported:"
        '
        'lboxGames
        '
        Me.lboxGames.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lboxGames.FormattingEnabled = True
        Me.lboxGames.Location = New System.Drawing.Point(12, 111)
        Me.lboxGames.Name = "lboxGames"
        Me.lboxGames.Size = New System.Drawing.Size(310, 108)
        Me.lboxGames.TabIndex = 11
        '
        'ImportDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(334, 271)
        Me.Controls.Add(Me.lboxGames)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.txtImportDir)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "ImportDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Import Game Profiles"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents txtImportDir As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents ImportFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lboxGames As System.Windows.Forms.ListBox
End Class
