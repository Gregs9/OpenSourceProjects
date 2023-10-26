<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.LBLCredit = New System.Windows.Forms.Label()
        Me.CMDExit = New System.Windows.Forms.Button()
        Me.CMDRename = New System.Windows.Forms.Button()
        Me.LBLFilesChecked = New System.Windows.Forms.Label()
        Me.LBLFilesAffected = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'LBLCredit
        '
        Me.LBLCredit.AutoSize = True
        Me.LBLCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCredit.Location = New System.Drawing.Point(103, 94)
        Me.LBLCredit.Name = "LBLCredit"
        Me.LBLCredit.Size = New System.Drawing.Size(183, 12)
        Me.LBLCredit.TabIndex = 17
        Me.LBLCredit.Text = "Made by Greg @ GPSv2 - Version A1.0.0.0"
        '
        'CMDExit
        '
        Me.CMDExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDExit.Location = New System.Drawing.Point(172, 60)
        Me.CMDExit.Name = "CMDExit"
        Me.CMDExit.Size = New System.Drawing.Size(114, 31)
        Me.CMDExit.TabIndex = 16
        Me.CMDExit.Text = "Exit"
        Me.CMDExit.UseVisualStyleBackColor = True
        '
        'CMDRename
        '
        Me.CMDRename.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDRename.Location = New System.Drawing.Point(15, 60)
        Me.CMDRename.Name = "CMDRename"
        Me.CMDRename.Size = New System.Drawing.Size(114, 31)
        Me.CMDRename.TabIndex = 13
        Me.CMDRename.Text = "Rename files"
        Me.CMDRename.UseVisualStyleBackColor = True
        '
        'LBLFilesChecked
        '
        Me.LBLFilesChecked.AutoSize = True
        Me.LBLFilesChecked.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLFilesChecked.Location = New System.Drawing.Point(12, 9)
        Me.LBLFilesChecked.Name = "LBLFilesChecked"
        Me.LBLFilesChecked.Size = New System.Drawing.Size(82, 13)
        Me.LBLFilesChecked.TabIndex = 20
        Me.LBLFilesChecked.Text = "0 Files checked"
        '
        'LBLFilesAffected
        '
        Me.LBLFilesAffected.AutoSize = True
        Me.LBLFilesAffected.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLFilesAffected.Location = New System.Drawing.Point(12, 33)
        Me.LBLFilesAffected.Name = "LBLFilesAffected"
        Me.LBLFilesAffected.Size = New System.Drawing.Size(81, 13)
        Me.LBLFilesAffected.TabIndex = 21
        Me.LBLFilesAffected.Text = "0 Files renamed"
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Location = New System.Drawing.Point(15, 109)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(266, 333)
        Me.TextBox1.TabIndex = 22
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(293, 454)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.LBLFilesAffected)
        Me.Controls.Add(Me.LBLFilesChecked)
        Me.Controls.Add(Me.LBLCredit)
        Me.Controls.Add(Me.CMDExit)
        Me.Controls.Add(Me.CMDRename)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Compare md5 to filename"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LBLCredit As Label
    Friend WithEvents CMDExit As Button
    Friend WithEvents CMDRename As Button
    Friend WithEvents LBLFilesChecked As Label
    Friend WithEvents LBLFilesAffected As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents TextBox1 As TextBox
End Class
