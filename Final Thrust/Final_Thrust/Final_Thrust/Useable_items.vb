Public Class Useable_items
    Private Sub Useable_items_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each item In Form1.LSBInventory.Items
            If Form1.translate_item_data(item, 1, 2) = "Consumable" Then
                LSBUseableItems.Items.Add(item)
            End If
        Next
        If LSBUseableItems.Items.Count = 0 Then
            Me.Close()
            Form1.playsound("warning", False)
            MessageBox.Show("You have no consumables in your inventory!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub CMDUseItem_Click(sender As Object, e As EventArgs) Handles CMDUseItem.Click
        Dim gains As Integer = 0
        Select Case LSBUseableItems.SelectedItem
            Case "Small Healing Potion"
                gains = 50
                If (Form1.LBLArenaCurrentHP.Text + gains) > Form1.LBLArenaMaxHP.Text Then
                    Form1.LBLArenaCurrentHP.Text = Form1.LBLArenaMaxHP.Text
                Else
                    Form1.LBLArenaCurrentHP.Text += gains
                End If
            Case "Potent Healing Potion"
                gains = 100
                If (Form1.LBLArenaCurrentHP.Text + gains) > Form1.LBLArenaMaxHP.Text Then
                    Form1.LBLArenaCurrentHP.Text = Form1.LBLArenaMaxHP.Text
                Else
                    Form1.LBLArenaCurrentHP.Text += gains
                End If
            Case "Major Healing Potion"
                gains = 150
                If (Form1.LBLArenaCurrentHP.Text + gains) > Form1.LBLArenaMaxHP.Text Then
                    Form1.LBLArenaCurrentHP.Text = Form1.LBLArenaMaxHP.Text
                Else
                    Form1.LBLArenaCurrentHP.Text += gains
                End If
            Case "Superior Healing Potion"
                gains = 200
                If (Form1.LBLArenaCurrentHP.Text + gains) > Form1.LBLArenaMaxHP.Text Then
                    Form1.LBLArenaCurrentHP.Text = Form1.LBLArenaMaxHP.Text
                Else
                    Form1.LBLArenaCurrentHP.Text += gains
                End If
            Case "Small Mana Potion"
                gains = 50
                If (Form1.LBLArenaCurrentMP.Text + gains) > Form1.LBLArenaMaxMP.Text Then
                    Form1.LBLArenaCurrentMP.Text = Form1.LBLArenaMaxMP.Text
                Else
                    Form1.LBLArenaCurrentMP.Text += gains
                End If
            Case "Potent Mana Potion"
                gains = 100
                If (Form1.LBLArenaCurrentMP.Text + gains) > Form1.LBLArenaMaxMP.Text Then
                    Form1.LBLArenaCurrentMP.Text = Form1.LBLArenaMaxMP.Text
                Else
                    Form1.LBLArenaCurrentMP.Text += gains
                End If
            Case "Major Mana Potion"
                gains = 150
                If (Form1.LBLArenaCurrentMP.Text + gains) > Form1.LBLArenaMaxMP.Text Then
                    Form1.LBLArenaCurrentMP.Text = Form1.LBLArenaMaxMP.Text
                Else
                    Form1.LBLArenaCurrentMP.Text += gains
                End If
            Case "Superior Mana Potion"
                gains = 200
                If (Form1.LBLArenaCurrentMP.Text + gains) > Form1.LBLArenaMaxMP.Text Then
                    Form1.LBLArenaCurrentMP.Text = Form1.LBLArenaMaxMP.Text
                Else
                    Form1.LBLArenaCurrentMP.Text += gains
                End If
        End Select
        'remove used item from inventory
        Dim item_index As Integer = 0
        For Each item In Form1.LSBInventory.Items
            If item.contains(LSBUseableItems.SelectedItem) Then
                Form1.LSBInventory.Items.RemoveAt(item_index)
                Exit For
            End If
            item_index += 1
        Next
        Form1.check_round_status()
        Me.Close()
    End Sub

    Private Sub LSBUseableItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LSBUseableItems.SelectedIndexChanged
        If LSBUseableItems.SelectedItem <> "" Then
            GRBCombatItemInfo.Top = LSBUseableItems.Top
            'LBLEquipmentName.Text = LSBInventory.SelectedItem
            GRBCombatItemInfo.Visible = True
            GRBCombatItemInfo.Text = LSBUseableItems.SelectedItem
            LBLCombatItemType.Text = Form1.translate_item_data(LSBUseableItems.SelectedItem, 1, 2)
            LBLCombatItemDescription.Text = Chr(34) & Form1.translate_item_data(LSBUseableItems.SelectedItem, 1, 3) & Chr(34)
            LBLCombatItemValue.Text = Form1.translate_item_data(LSBUseableItems.SelectedItem, 1, 9)
            PCBCombatItemIcon.ImageLocation = Form1.translate_item_data(LSBUseableItems.SelectedItem, 1, 12)
            Select Case Form1.translate_item_data(LSBUseableItems.SelectedItem, 1, 4)
                Case "Legendary"
                    GRBCombatItemInfo.ForeColor = Color.Orange
                Case "Epic"
                    GRBCombatItemInfo.ForeColor = Color.MediumOrchid
                Case "Rare"
                    GRBCombatItemInfo.ForeColor = Color.DodgerBlue
                Case "Common"
                    GRBCombatItemInfo.ForeColor = Color.White
            End Select
        Else
            GRBCombatItemInfo.Visible = False
        End If
    End Sub


End Class