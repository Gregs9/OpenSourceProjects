<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Useable_items
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Useable_items))
        Me.LSBUseableItems = New System.Windows.Forms.ListBox()
        Me.CMDUseItem = New System.Windows.Forms.Button()
        Me.GRBCombatItemInfo = New System.Windows.Forms.GroupBox()
        Me.PCBCombatItemIcon = New System.Windows.Forms.PictureBox()
        Me.PCBmnuCombatItemValue = New System.Windows.Forms.PictureBox()
        Me.LBLCombatItemValue = New System.Windows.Forms.Label()
        Me.LBLCombatItemDescription = New System.Windows.Forms.Label()
        Me.LBLCombatItemType = New System.Windows.Forms.Label()
        Me.GRBCombatItemInfo.SuspendLayout()
        CType(Me.PCBCombatItemIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCBmnuCombatItemValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LSBUseableItems
        '
        Me.LSBUseableItems.BackColor = System.Drawing.Color.Maroon
        Me.LSBUseableItems.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LSBUseableItems.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LSBUseableItems.ForeColor = System.Drawing.Color.White
        Me.LSBUseableItems.FormattingEnabled = True
        Me.LSBUseableItems.ItemHeight = 19
        Me.LSBUseableItems.Location = New System.Drawing.Point(0, 0)
        Me.LSBUseableItems.Name = "LSBUseableItems"
        Me.LSBUseableItems.Size = New System.Drawing.Size(361, 194)
        Me.LSBUseableItems.TabIndex = 0
        '
        'CMDUseItem
        '
        Me.CMDUseItem.BackColor = System.Drawing.Color.Maroon
        Me.CMDUseItem.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDUseItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDUseItem.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDUseItem.ForeColor = System.Drawing.Color.White
        Me.CMDUseItem.Location = New System.Drawing.Point(423, 161)
        Me.CMDUseItem.Name = "CMDUseItem"
        Me.CMDUseItem.Size = New System.Drawing.Size(100, 30)
        Me.CMDUseItem.TabIndex = 2
        Me.CMDUseItem.Text = "USE"
        Me.CMDUseItem.UseVisualStyleBackColor = False
        '
        'GRBCombatItemInfo
        '
        Me.GRBCombatItemInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GRBCombatItemInfo.Controls.Add(Me.PCBCombatItemIcon)
        Me.GRBCombatItemInfo.Controls.Add(Me.PCBmnuCombatItemValue)
        Me.GRBCombatItemInfo.Controls.Add(Me.LBLCombatItemValue)
        Me.GRBCombatItemInfo.Controls.Add(Me.LBLCombatItemDescription)
        Me.GRBCombatItemInfo.Controls.Add(Me.LBLCombatItemType)
        Me.GRBCombatItemInfo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRBCombatItemInfo.ForeColor = System.Drawing.Color.White
        Me.GRBCombatItemInfo.Location = New System.Drawing.Point(361, 1)
        Me.GRBCombatItemInfo.Margin = New System.Windows.Forms.Padding(2)
        Me.GRBCombatItemInfo.Name = "GRBCombatItemInfo"
        Me.GRBCombatItemInfo.Padding = New System.Windows.Forms.Padding(2)
        Me.GRBCombatItemInfo.Size = New System.Drawing.Size(236, 158)
        Me.GRBCombatItemInfo.TabIndex = 58
        Me.GRBCombatItemInfo.TabStop = False
        Me.GRBCombatItemInfo.Text = "GRBShopItemInfo"
        Me.GRBCombatItemInfo.Visible = False
        '
        'PCBCombatItemIcon
        '
        Me.PCBCombatItemIcon.Location = New System.Drawing.Point(170, 18)
        Me.PCBCombatItemIcon.Margin = New System.Windows.Forms.Padding(2)
        Me.PCBCombatItemIcon.Name = "PCBCombatItemIcon"
        Me.PCBCombatItemIcon.Size = New System.Drawing.Size(56, 61)
        Me.PCBCombatItemIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PCBCombatItemIcon.TabIndex = 54
        Me.PCBCombatItemIcon.TabStop = False
        '
        'PCBmnuCombatItemValue
        '
        Me.PCBmnuCombatItemValue.Image = CType(resources.GetObject("PCBmnuCombatItemValue.Image"), System.Drawing.Image)
        Me.PCBmnuCombatItemValue.Location = New System.Drawing.Point(7, 133)
        Me.PCBmnuCombatItemValue.Margin = New System.Windows.Forms.Padding(2)
        Me.PCBmnuCombatItemValue.Name = "PCBmnuCombatItemValue"
        Me.PCBmnuCombatItemValue.Size = New System.Drawing.Size(15, 16)
        Me.PCBmnuCombatItemValue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PCBmnuCombatItemValue.TabIndex = 55
        Me.PCBmnuCombatItemValue.TabStop = False
        '
        'LBLCombatItemValue
        '
        Me.LBLCombatItemValue.AutoSize = True
        Me.LBLCombatItemValue.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCombatItemValue.ForeColor = System.Drawing.Color.White
        Me.LBLCombatItemValue.Location = New System.Drawing.Point(27, 133)
        Me.LBLCombatItemValue.Name = "LBLCombatItemValue"
        Me.LBLCombatItemValue.Size = New System.Drawing.Size(16, 16)
        Me.LBLCombatItemValue.TabIndex = 53
        Me.LBLCombatItemValue.Text = "0"
        '
        'LBLCombatItemDescription
        '
        Me.LBLCombatItemDescription.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCombatItemDescription.ForeColor = System.Drawing.Color.Coral
        Me.LBLCombatItemDescription.Location = New System.Drawing.Point(4, 99)
        Me.LBLCombatItemDescription.Name = "LBLCombatItemDescription"
        Me.LBLCombatItemDescription.Size = New System.Drawing.Size(225, 32)
        Me.LBLCombatItemDescription.TabIndex = 45
        Me.LBLCombatItemDescription.Text = "0"
        '
        'LBLCombatItemType
        '
        Me.LBLCombatItemType.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCombatItemType.ForeColor = System.Drawing.Color.White
        Me.LBLCombatItemType.Location = New System.Drawing.Point(115, 80)
        Me.LBLCombatItemType.Name = "LBLCombatItemType"
        Me.LBLCombatItemType.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LBLCombatItemType.Size = New System.Drawing.Size(104, 19)
        Me.LBLCombatItemType.TabIndex = 43
        Me.LBLCombatItemType.Text = "0"
        '
        'Useable_items
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(598, 194)
        Me.Controls.Add(Me.GRBCombatItemInfo)
        Me.Controls.Add(Me.CMDUseItem)
        Me.Controls.Add(Me.LSBUseableItems)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Useable_items"
        Me.Text = "Useable_items"
        Me.GRBCombatItemInfo.ResumeLayout(False)
        Me.GRBCombatItemInfo.PerformLayout()
        CType(Me.PCBCombatItemIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCBmnuCombatItemValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LSBUseableItems As ListBox
    Friend WithEvents CMDUseItem As Button
    Friend WithEvents GRBCombatItemInfo As GroupBox
    Friend WithEvents PCBCombatItemIcon As PictureBox
    Friend WithEvents PCBmnuCombatItemValue As PictureBox
    Friend WithEvents LBLCombatItemValue As Label
    Friend WithEvents LBLCombatItemType As Label
    Friend WithEvents LBLCombatItemDescription As Label
End Class
