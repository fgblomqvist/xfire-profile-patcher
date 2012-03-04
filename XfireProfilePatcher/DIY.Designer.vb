<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DIY
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DIY))
        Me.grpStepOne = New System.Windows.Forms.GroupBox()
        Me.lblSearchResults = New System.Windows.Forms.Label()
        Me.txtSearchXireINI = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.lblSelectGameInfo = New System.Windows.Forms.Label()
        Me.grpStepThree = New System.Windows.Forms.GroupBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lblDoneText = New System.Windows.Forms.Label()
        Me.grpStepTwo = New System.Windows.Forms.GroupBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.txtLauncher = New System.Windows.Forms.TextBox()
        Me.grpStepOne.SuspendLayout()
        Me.grpStepThree.SuspendLayout()
        Me.grpStepTwo.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpStepOne
        '
        Me.grpStepOne.Controls.Add(Me.lblSearchResults)
        Me.grpStepOne.Controls.Add(Me.txtSearchXireINI)
        Me.grpStepOne.Controls.Add(Me.btnSearch)
        Me.grpStepOne.Controls.Add(Me.lblSelectGameInfo)
        Me.grpStepOne.Location = New System.Drawing.Point(12, 12)
        Me.grpStepOne.Name = "grpStepOne"
        Me.grpStepOne.Size = New System.Drawing.Size(331, 139)
        Me.grpStepOne.TabIndex = 0
        Me.grpStepOne.TabStop = False
        Me.grpStepOne.Text = "Select game"
        '
        'lblSearchResults
        '
        Me.lblSearchResults.AutoSize = True
        Me.lblSearchResults.Location = New System.Drawing.Point(118, 103)
        Me.lblSearchResults.Name = "lblSearchResults"
        Me.lblSearchResults.Size = New System.Drawing.Size(102, 13)
        Me.lblSearchResults.TabIndex = 3
        Me.lblSearchResults.Text = "x games was found"
        '
        'txtSearchXireINI
        '
        Me.txtSearchXireINI.Location = New System.Drawing.Point(21, 67)
        Me.txtSearchXireINI.Name = "txtSearchXireINI"
        Me.txtSearchXireINI.Size = New System.Drawing.Size(208, 20)
        Me.txtSearchXireINI.TabIndex = 2
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(235, 65)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lblSelectGameInfo
        '
        Me.lblSelectGameInfo.AutoSize = True
        Me.lblSelectGameInfo.Location = New System.Drawing.Point(18, 27)
        Me.lblSelectGameInfo.Name = "lblSelectGameInfo"
        Me.lblSelectGameInfo.Size = New System.Drawing.Size(179, 26)
        Me.lblSelectGameInfo.TabIndex = 0
        Me.lblSelectGameInfo.Text = "Please input the name of the game " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "you want to create a profile for:"
        '
        'grpStepThree
        '
        Me.grpStepThree.Controls.Add(Me.btnAdd)
        Me.grpStepThree.Controls.Add(Me.lblDoneText)
        Me.grpStepThree.Location = New System.Drawing.Point(12, 248)
        Me.grpStepThree.Name = "grpStepThree"
        Me.grpStepThree.Size = New System.Drawing.Size(331, 135)
        Me.grpStepThree.TabIndex = 0
        Me.grpStepThree.TabStop = False
        Me.grpStepThree.Text = "Add"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(101, 96)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(114, 23)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "Add Game Profile"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lblDoneText
        '
        Me.lblDoneText.AutoSize = True
        Me.lblDoneText.Location = New System.Drawing.Point(18, 25)
        Me.lblDoneText.Name = "lblDoneText"
        Me.lblDoneText.Size = New System.Drawing.Size(310, 52)
        Me.lblDoneText.TabIndex = 0
        Me.lblDoneText.Text = resources.GetString("lblDoneText.Text")
        Me.lblDoneText.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'grpStepTwo
        '
        Me.grpStepTwo.Controls.Add(Me.btnBrowse)
        Me.grpStepTwo.Controls.Add(Me.txtLauncher)
        Me.grpStepTwo.Location = New System.Drawing.Point(12, 157)
        Me.grpStepTwo.Name = "grpStepTwo"
        Me.grpStepTwo.Size = New System.Drawing.Size(331, 85)
        Me.grpStepTwo.TabIndex = 0
        Me.grpStepTwo.TabStop = False
        Me.grpStepTwo.Text = "Select launch exe or shortcut"
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(285, 33)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(25, 20)
        Me.btnBrowse.TabIndex = 1
        Me.btnBrowse.Text = "..."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtLauncher
        '
        Me.txtLauncher.Location = New System.Drawing.Point(15, 33)
        Me.txtLauncher.Name = "txtLauncher"
        Me.txtLauncher.Size = New System.Drawing.Size(264, 20)
        Me.txtLauncher.TabIndex = 0
        '
        'DIY
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(355, 395)
        Me.Controls.Add(Me.grpStepTwo)
        Me.Controls.Add(Me.grpStepThree)
        Me.Controls.Add(Me.grpStepOne)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DIY"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Game profile creation wizard"
        Me.grpStepOne.ResumeLayout(False)
        Me.grpStepOne.PerformLayout()
        Me.grpStepThree.ResumeLayout(False)
        Me.grpStepThree.PerformLayout()
        Me.grpStepTwo.ResumeLayout(False)
        Me.grpStepTwo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpStepOne As System.Windows.Forms.GroupBox
    Friend WithEvents lblSearchResults As System.Windows.Forms.Label
    Friend WithEvents txtSearchXireINI As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lblSelectGameInfo As System.Windows.Forms.Label
    Friend WithEvents grpStepThree As System.Windows.Forms.GroupBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lblDoneText As System.Windows.Forms.Label
    Friend WithEvents grpStepTwo As System.Windows.Forms.GroupBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents txtLauncher As System.Windows.Forms.TextBox
End Class
