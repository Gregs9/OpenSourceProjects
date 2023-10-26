<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Splash_Final_Thrust
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Splash_Final_Thrust))
        Me.PCBLogo = New System.Windows.Forms.PictureBox()
        Me.LBLVersion = New System.Windows.Forms.Label()
        Me.LBLCopyright = New System.Windows.Forms.Label()
        CType(Me.PCBLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PCBLogo
        '
        Me.PCBLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PCBLogo.Image = CType(resources.GetObject("PCBLogo.Image"), System.Drawing.Image)
        Me.PCBLogo.Location = New System.Drawing.Point(12, 12)
        Me.PCBLogo.Name = "PCBLogo"
        Me.PCBLogo.Size = New System.Drawing.Size(472, 156)
        Me.PCBLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PCBLogo.TabIndex = 0
        Me.PCBLogo.TabStop = False
        '
        'LBLVersion
        '
        Me.LBLVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LBLVersion.AutoSize = True
        Me.LBLVersion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLVersion.ForeColor = System.Drawing.Color.White
        Me.LBLVersion.Location = New System.Drawing.Point(407, 186)
        Me.LBLVersion.Name = "LBLVersion"
        Me.LBLVersion.Size = New System.Drawing.Size(77, 14)
        Me.LBLVersion.TabIndex = 1
        Me.LBLVersion.Text = "Version a1.0.0"
        '
        'LBLCopyright
        '
        Me.LBLCopyright.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LBLCopyright.AutoSize = True
        Me.LBLCopyright.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCopyright.ForeColor = System.Drawing.Color.White
        Me.LBLCopyright.Location = New System.Drawing.Point(453, 200)
        Me.LBLCopyright.Name = "LBLCopyright"
        Me.LBLCopyright.Size = New System.Drawing.Size(31, 14)
        Me.LBLCopyright.TabIndex = 2
        Me.LBLCopyright.Text = "Greg"
        '
        'Splash_Final_Thrust
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(496, 220)
        Me.ControlBox = False
        Me.Controls.Add(Me.LBLCopyright)
        Me.Controls.Add(Me.LBLVersion)
        Me.Controls.Add(Me.PCBLogo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Splash_Final_Thrust"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PCBLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PCBLogo As PictureBox
    Friend WithEvents LBLVersion As Label
    Friend WithEvents LBLCopyright As Label
End Class
