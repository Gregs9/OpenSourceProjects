
Imports System.IO
Imports System.IO.Path
Public Class Form1

    'GLOBAL VARIABLES
    Dim damage_min As Integer
    Dim damage_max As Integer
    Dim skill_damage_modifier As Integer
    Dim turn_counter As Integer
    Dim foe_turn_index As Integer = 1
    Dim alysha_skill_1_CD = 0, alysha_skill_2_CD = 0, alysha_skill_3_CD = 0, alysha_skill_4_CD = 0, alysha_skill_5_CD = 0
    Dim makyr_skill_1_CD = 0, makyr_skill_2_CD = 0, makyr_skill_3_CD = 0, makyr_skill_4_CD = 0, makyr_skill_5_CD = 0
    Dim nardina_skill_1_CD = 0, nardina_skill_2_CD = 0, nardina_skill_3_CD = 0, nardina_skill_4_CD = 0, nardina_skill_5_CD = 0
    Dim nylathria_skill_1_CD = 0, nylathria_skill_2_CD = 0, nylathria_skill_3_CD = 0, nylathria_skill_4_CD = 0, nylathria_skill_5_CD = 0
    Dim sagraxes_skill_1_CD = 0, sagraxes_skill_2_CD = 0, sagraxes_skill_3_CD = 0, sagraxes_skill_4_CD = 0, sagraxes_skill_5_CD = 0
    Dim is_blocking As Boolean = False

    'we need these variables to be global so we can use them to calculate hit chance/crit chance during the arena
    Dim total_extra_hc As Integer = 0
    Dim total_extra_cc As Integer = 0

    'used to prevent form_closing event from firing twice
    Dim is_closing As Boolean = False

    'variable to keep music position so it can be resumed
    Dim music_arena_position As String

    'variable to mute music/sfx
    Dim mute_music As Boolean = False





    'MENU-ING
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.KeyPreview = True
        music_player.settings.setMode("Loop", True)
        music_player.settings.volume = My.Settings.Music_Volume
        TCBMusicVolume.Value = My.Settings.Music_Volume
        LBLVolume.Text = "Music Volume: " & My.Settings.Music_Volume
        music_player.URL = "G:\Final Thrust\game_data\sfx\music_general.mp3"
        music_player.Ctlcontrols.play()

        'load inventory
        Dim lines() As String = IO.File.ReadAllLines("G:\Final Thrust\player_data\player_inventory.ini")
        For Each item As String In lines
            If IsNumeric(item) = False Then
                LSBInventory.Items.Add(item) 'give entire line of info, request only item name
            Else
                LBLGold.Text = item
            End If
        Next

        'load masteries
        load_masteries()

        load_character("Alysha")

        'add regen hp here
        TimerRegen.Start()

    End Sub
    Private Sub CMDConsole_Click(sender As Object, e As EventArgs) Handles CMDConsole.Click
        trigger_console()
    End Sub
    Private Sub CMDEquip_Click(sender As Object, e As EventArgs) Handles CMDEquip.Click
        If LSBInventory.SelectedItem <> "" Then

            Dim read_item As String = LSBInventory.SelectedItem

            'check item type
            Select Case translate_item_data(read_item, 1, 2)
                Case "Head"
                    playsound("(un)equip_armor", False)
                    'prevent overwriting already equipped item
                    If TXTHead.Text <> "" Then
                        add_item_to_inventory(TXTHead.Text)
                    End If
                    TXTHead.Text = read_item
                    LSBInventory.Items.RemoveAt(LSBInventory.SelectedIndex)
                Case "Shoulders"
                    playsound("(un)equip_armor", False)
                    If TXTShoulders.Text <> "" Then
                        add_item_to_inventory(TXTShoulders.Text)
                    End If
                    TXTShoulders.Text = read_item
                    LSBInventory.Items.RemoveAt(LSBInventory.SelectedIndex)
                Case "Chest"
                    playsound("(un)equip_armor", False)
                    If TXTChest.Text <> "" Then
                        add_item_to_inventory(TXTChest.Text)
                    End If
                    TXTChest.Text = read_item
                    LSBInventory.Items.RemoveAt(LSBInventory.SelectedIndex)
                Case "Legs"
                    playsound("(un)equip_armor", False)
                    If TXTLegs.Text <> "" Then
                        add_item_to_inventory(TXTLegs.Text)
                    End If
                    TXTLegs.Text = read_item
                    LSBInventory.Items.RemoveAt(LSBInventory.SelectedIndex)
                Case "Boots"
                    playsound("(un)equip_armor", False)
                    If TXTBoots.Text <> "" Then
                        add_item_to_inventory(TXTBoots.Text)
                    End If
                    TXTBoots.Text = read_item
                    LSBInventory.Items.RemoveAt(LSBInventory.SelectedIndex)
                Case "1H"
                    playsound("(un)equip_weapon", False)
                    'allow for dual-wielding two 1H items
                    If TXTMainHand.Text = "" Then 'if mainhand is empty, equip it in main hand
                        TXTMainHand.Text = read_item
                    ElseIf TXTOffHand.Text = "" Then 'if mainhand is not empty, but offhand is empty, equip in offhand
                        TXTOffHand.Text = read_item
                    Else 'if neither mainhand and offhand are empty, overwrite mainhand
                        add_item_to_inventory(TXTMainHand.Text)
                        TXTMainHand.Text = read_item
                    End If
                    LSBInventory.Items.RemoveAt(LSBInventory.SelectedIndex)
                Case "2H"
                    playsound("(un)equip_weapon", False)
                    If TXTMainHand.Text <> "" Then
                        add_item_to_inventory(TXTMainHand.Text)
                    End If
                    TXTMainHand.Text = read_item
                    TXTOffHand.BackColor = Color.Black
                    TXTOffHand.Enabled = False
                    LSBInventory.Items.RemoveAt(LSBInventory.SelectedIndex)
                Case "Offhand"
                    playsound("(un)equip_weapon", False)
                    If TXTOffHand.Text <> "" Then
                        add_item_to_inventory(TXTOffHand.Text)
                    End If
                    TXTOffHand.Text = read_item
                    LSBInventory.Items.RemoveAt(LSBInventory.SelectedIndex)
                Case "Consumable"
                    use_consumable(read_item)
                Case Else
                    playsound("warning", False)
                    MessageBox.Show("Cannot equip this item.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Select

            'set correct rarity colors for the equiped items
            'loop through every textbox in the equipment groupbox
            For Each ctrl As Control In GRBEquipment.Controls
                If TypeOf ctrl Is TextBox Then
                    If ctrl.Text <> "" Then
                        Select Case translate_item_data(ctrl.Text, 1, 4)
                            Case "Legendary"
                                ctrl.ForeColor = Color.Orange
                            Case "Epic"
                                ctrl.ForeColor = Color.MediumOrchid
                            Case "Rare"
                                ctrl.ForeColor = Color.DodgerBlue
                            Case "Common"
                                ctrl.ForeColor = Color.White
                        End Select
                    End If
                End If
            Next

            update_attribute_modifiers()

        Else
            playsound("warning", False)
            MessageBox.Show("Cannot equip this item.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub PCBAvatar_Click(sender As Object, e As EventArgs) Handles PCBAvatar.Click
        save()
        Character_Select.Show()
    End Sub
    Private Sub CMDCharacter_Click(sender As Object, e As EventArgs) Handles CMDCharacter.Click
        save()
        PNLCharacter.Visible = True
        PNLMasteries.Visible = False
        PNLFountain.Visible = False
        PNLTheArena.Visible = False
        PNLShop.Visible = False
        If music_player.URL <> "G:\Final Thrust\game_data\sfx\music_general.mp3" Then
            music_player.URL = "G:\Final Thrust\game_data\sfx\music_general.mp3"
            music_player.Ctlcontrols.play()
        End If

        update_attribute_modifiers()
    End Sub
    Private Sub CMDFountain_Click(sender As Object, e As EventArgs) Handles CMDFountain.Click
        save()
        PNLCharacter.Visible = False
        PNLMasteries.Visible = False
        PNLFountain.Visible = True
        PNLTheArena.Visible = False
        PNLShop.Visible = False
        music_player.URL = "G:\Final Thrust\game_data\sfx\music_well.mp3"
        music_player.Ctlcontrols.play()
    End Sub
    Private Sub CMDMasteries_Click(sender As Object, e As EventArgs) Handles CMDMasteries.Click
        save()
        PNLCharacter.Visible = False
        PNLMasteries.Visible = True
        PNLFountain.Visible = False
        PNLTheArena.Visible = False
        PNLShop.Visible = False
        If music_player.URL <> "G:\Final Thrust\game_data\sfx\music_general.mp3" Then
            music_player.URL = "G:\Final Thrust\game_data\sfx\music_general.mp3"
            music_player.Ctlcontrols.play()
        End If
        LBLMasteryTitle.Text = ""
        LBLMasteryDescription.Text = ""
    End Sub
    Private Sub CMDShop_Click(sender As Object, e As EventArgs) Handles CMDShop.Click
        playsound("door", True)
        PNLCharacter.Visible = False
        PNLMasteries.Visible = False
        PNLFountain.Visible = False
        PNLTheArena.Visible = False
        PNLShop.Visible = True
        LSBShopBuy.Items.Clear()


        'generate shop
        'https://docs.microsoft.com/en-us/dotnet/api/system.datetime.compare?view=netcore-3.1 comparing dates


        If File.Exists("G:\Final Thrust\game_data\shop_cache.ini") = True Then
            Dim shop_cache As StreamReader = My.Computer.FileSystem.OpenTextFileReader("G:\Final Thrust\game_data\shop_cache.ini")

            Dim cached_date As Date = shop_cache.ReadLine
            Dim todays_date As Date = Date.Now().ToString("yyyy-MM-dd")

            shop_cache.Close()

            Dim result As Integer = DateTime.Compare(cached_date, todays_date)

            'if cached_date is earlier than today, generate new shopping list
            If result < 0 Then
                'generate new shopping list
                Dim shop_data As StreamReader = My.Computer.FileSystem.OpenTextFileReader("G:\Final Thrust\game_data\item_database.ini")
                Dim shop_data_count = File.ReadAllLines("G:\Final Thrust\game_data\item_database.ini").Length
                Dim found_items As Integer = 0

                'create seperate list of all items sold by the shop
                Dim shopable_items As New List(Of String)
                For index As Integer = 0 To (shop_data_count - 1)
                    Dim check_string = shop_data.ReadLine
                    Dim item_name As String = translate_item_data(check_string, -1, 1)
                    If translate_item_data(check_string, -1, 8) = 1 Then
                        shopable_items.Add(item_name)
                    End If
                Next
                shop_data.Close()

                While found_items < 10
                    Randomize()
                    Dim item_RNG As Integer = Int(((shopable_items.Count - 1) * Rnd()) + 0) 'generate random number between 0 and list bounds
                    LSBShopBuy.Items.Add(shopable_items(item_RNG))
                    found_items += 1
                End While

                'write list to txt file with date
                Dim sb As New System.Text.StringBuilder()

                Dim regDate As Date = Date.Now()
                sb.AppendLine(regDate.ToString("yyyy-MM-dd"))
                For Each o As Object In LSBShopBuy.Items
                    sb.AppendLine(o)
                Next
                System.IO.File.WriteAllText("G:\Final Thrust\game_data\shop_cache.ini", sb.ToString())


            ElseIf result = 0 Then 'if cached date is the same as today, load already existing shopping list
                Dim lines() As String = IO.File.ReadAllLines("G:\Final Thrust\game_data\shop_cache.ini")
                LSBShopBuy.Items.AddRange(lines)
                LSBShopBuy.Items.RemoveAt(0) 'remove date from read file
            Else 'if cached date is later than todays date, throw error
                playsound("warning", False)
                MessageBox.Show("Invalid date in shop_cache.ini.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            LSBShopBuy.SelectedIndex = 0
        End If

        LBLShopGold.Text = LBLGold.Text

        'load inventory into sell listbox
        LSBShopSell.Items.Clear()
        For Each item In LSBInventory.Items
            LSBShopSell.Items.Add(item)
        Next

        music_player.URL = "G:\Final Thrust\game_data\sfx\music_shop.mp3"
        music_player.Ctlcontrols.play()








    End Sub
    Private Sub CMDTheArena_Click(sender As Object, e As EventArgs) Handles CMDTheArena.Click

        If LBLCurrentHP.Text > 0 Then
            If vbYes = MsgBox("Entering the arena will initiate combat, are you sure you wish to continue?", vbYesNo, "WARNING") Then
                save()

                TimerRegen.Stop()

                PNLCharacter.Visible = False
                PNLMasteries.Visible = False
                PNLFountain.Visible = False
                PNLTheArena.Visible = True
                PNLShop.Visible = False

                CMDCharacter.Enabled = False
                CMDMasteries.Enabled = False
                CMDFountain.Enabled = False
                CMDTheArena.Enabled = False
                CMDShop.Enabled = False
                'initialize data

                PCBArenaAvatar.Image = PCBAvatar.Image
                LBLArenaCharacterName.Text = LBLCharacterName.Text
                LBLArenaCurrentHP.Text = LBLCurrentHP.Text
                LBLArenaCurrentMP.Text = LBLCurrentMP.Text
                LBLArenaMaxHP.Text = LBLMaxHP.Text
                LBLArenaMaxMP.Text = LBLMaxMP.Text
                LBLArenaLevel.Text = LBLLevel.Text
                PGBPlayerHP.Maximum = LBLArenaMaxHP.Text
                PGBPlayerHP.Value = LBLArenaCurrentHP.Text
                PGBPlayerMP.Maximum = LBLArenaMaxMP.Text
                PGBPlayerMP.Value = LBLArenaCurrentMP.Text

                turn_counter = 1
                LBLTurnCounter.Text = "Turn: " & turn_counter
                'load skillset
                Select Case (LBLCharacterName.Text).ToLower
                    Case "alysha"
                        GRBAlyshaSkills.Visible = True
                        GRBMakyrSkills.Visible = False
                        GRBNardinaSkills.Visible = False
                        GRBNylathriaSkills.Visible = False
                        GRBSagraxesSkills.Visible = False
                    Case "makyr"
                        GRBAlyshaSkills.Visible = False
                        GRBMakyrSkills.Visible = True
                        GRBNardinaSkills.Visible = False
                        GRBNylathriaSkills.Visible = False
                        GRBSagraxesSkills.Visible = False
                    Case "nardina"
                        GRBAlyshaSkills.Visible = False
                        GRBMakyrSkills.Visible = False
                        GRBNardinaSkills.Visible = True
                        GRBNylathriaSkills.Visible = False
                        GRBSagraxesSkills.Visible = False
                    Case "nylathria"
                        GRBAlyshaSkills.Visible = False
                        GRBMakyrSkills.Visible = False
                        GRBNardinaSkills.Visible = False
                        GRBNylathriaSkills.Visible = True
                        GRBSagraxesSkills.Visible = False
                    Case "sagraxes"
                        GRBAlyshaSkills.Visible = False
                        GRBMakyrSkills.Visible = False
                        GRBNardinaSkills.Visible = False
                        GRBNylathriaSkills.Visible = False
                        GRBSagraxesSkills.Visible = True
                End Select
                GRBAlyshaSkills.Top = 160
                GRBAlyshaSkills.Left = 5
                GRBMakyrSkills.Top = 160
                GRBMakyrSkills.Left = 5
                GRBNardinaSkills.Top = 160
                GRBNardinaSkills.Left = 5
                GRBNylathriaSkills.Top = 160
                GRBNylathriaSkills.Left = 5
                GRBSagraxesSkills.Top = 160
                GRBSagraxesSkills.Left = 5
                GRBGeneralSkills.Top = 250
                GRBGeneralSkills.Left = 5
                generate_foe()
                music_player.URL = "G:\Final Thrust\game_data\sfx\music_arena.mp3"
                music_player.Ctlcontrols.play()
            End If
        Else
            playsound("warning", False)
            MessageBox.Show("You cannot enter the arena while " & LBLCharacterName.Text & " is dead.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Sub PCBWishingWell_Click(sender As Object, e As EventArgs) Handles PCBWishingWell.Click

        If NMCGoldDonation.Value > 0 Then
            If NMCGoldDonation.Value <= LBLGold.Text Then
                playsound("splash", True)
                LBLGold.Text -= NMCGoldDonation.Value

                Randomize()
                Dim RNG As Integer = Int((1000000 * Rnd()) + 1) 'generate random number between 1 and a million

                RNG += NMCGoldDonation.Value

                If RNG >= 1000000 Then
                    'GENERATE LOOT
                    Dim loot_table As StreamReader = My.Computer.FileSystem.OpenTextFileReader("G:\Final Thrust\game_data\item_database.ini")
                    Dim loot_table_count = File.ReadAllLines("G:\Final Thrust\game_data\item_database.ini").Length

                    'create seperate list of all lootable items
                    Dim lootable_items As New List(Of String)

                    For index As Integer = 0 To (loot_table_count - 1)
                        Dim check_string = loot_table.ReadLine

                        Dim get_item_name As String = translate_item_data(check_string, -1, 1)

                        If get_item_name.Contains("Prismatic ") Then
                            lootable_items.Add(get_item_name)
                        End If
                    Next

                    Randomize()
                    Dim item_RNG As Integer = Int(((lootable_items.Count - 1) * Rnd()) + 0) 'generate random number between 0 and list bounds
                    'add to inventory
                    add_item_to_inventory(lootable_items(item_RNG))

                    MessageBox.Show("You received " & lootable_items(item_RNG) & "!", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    playsound("warning", False)
                    MessageBox.Show("You received nothing.", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Else
                playsound("warning", False)
                MessageBox.Show("You don't have this much gold.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            playsound("warning", False)
            MessageBox.Show("You have to donate at least 1 gold.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub CMDTrash_Click(sender As Object, e As EventArgs) Handles CMDTrash.Click
        If LSBInventory.SelectedItem <> "" Then
            Dim result As DialogResult = MessageBox.Show("Are you sure you wish to delete " & LSBInventory.SelectedItem & "?", "WARNING", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                LSBInventory.Items.RemoveAt(LSBInventory.SelectedIndex)
                playsound("trash", False)
            End If
            save()
        End If
    End Sub
    Private Sub CMDSave_Click(sender As Object, e As EventArgs) Handles CMDSave.Click
        save()
    End Sub
    Private Sub CMDResetSave_Click(sender As Object, e As EventArgs) Handles CMDResetSave.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you wish to delete ALL your save data?" & vbCrLf & "Final Thrust will close.", "WARNING", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            'reset inventory
            System.IO.File.WriteAllText("G:\Final Thrust\player_data\player_inventory.ini", "0")
            'reset Alysha data
            System.IO.File.WriteAllText("G:\Final Thrust\player_data\Alysha_attributes.ini", "100" & vbCrLf & "100" & vbCrLf & "0" & vbCrLf & "0" & vbCrLf & "12" & vbCrLf & "12" & vbCrLf & "12" & vbCrLf & "12" & vbCrLf & "12" & vbCrLf & "12" & vbCrLf & "Alysha Starter Hood" & vbCrLf & "Alysha Starter Shoulders" & vbCrLf & "Alysha Starter Chest" & vbCrLf & "Alysha Starter Legs" & vbCrLf & "Alysha Starter Boots" & vbCrLf & "Alysha Starter Dagger" & vbCrLf)
            'reset Makyr data
            System.IO.File.WriteAllText("G:\Final Thrust\player_data\Makyr_attributes.ini", "100" & vbCrLf & "100" & vbCrLf & "0" & vbCrLf & "0" & vbCrLf & "10" & vbCrLf & "10" & vbCrLf & "10" & vbCrLf & "13" & vbCrLf & "16" & vbCrLf & "16" & vbCrLf & "Makyr Starter Halo" & vbCrLf & "Makyr Starter Shoulderpads" & vbCrLf & "Makyr Starter Robe" & vbCrLf & "Makyr Starter Leggings" & vbCrLf & "Makyr Starter Heels" & vbCrLf & "Makyr Starter Staff" & vbCrLf)
            'reset Nardina data
            System.IO.File.WriteAllText("G:\Final Thrust\player_data\Nardina_attributes.ini", "100" & vbCrLf & "100" & vbCrLf & "0" & vbCrLf & "0" & vbCrLf & "14" & vbCrLf & "14" & vbCrLf & "14" & vbCrLf & "14" & vbCrLf & "10" & vbCrLf & "10" & vbCrLf & "Nardina Starter Cap" & vbCrLf & "Nardina Starter Shoulders" & vbCrLf & "Nardina Starter Chestpiece" & vbCrLf & "Nardina Starter Leggings" & vbCrLf & "Nardina Starter Boots" & vbCrLf & "Nardina Starter Sword" & vbCrLf)
            'reset Nylathria data
            System.IO.File.WriteAllText("G:\Final Thrust\player_data\Nylathria_attributes.ini", "100" & vbCrLf & "100" & vbCrLf & "0" & vbCrLf & "0" & vbCrLf & "14" & vbCrLf & "16" & vbCrLf & "15" & vbCrLf & "10" & vbCrLf & "10" & vbCrLf & "10" & vbCrLf & "Nylathria Starter Cap" & vbCrLf & "Nylathria Starter Shoulderpads" & vbCrLf & "Nylathria Starter Chestpiece" & vbCrLf & "Nylathria Starter Leggings" & vbCrLf & "Nylathria Starter Boots" & vbCrLf & "Nylathria Starter Dagger" & vbCrLf & "Nylathria Starter Dagger")
            'reset Sagraxes data
            System.IO.File.WriteAllText("G:\Final Thrust\player_data\Sagraxes_attributes.ini", "100" & vbCrLf & "100" & vbCrLf & "0" & vbCrLf & "0" & vbCrLf & "16" & vbCrLf & "13" & vbCrLf & "16" & vbCrLf & "10" & vbCrLf & "10" & vbCrLf & "10" & vbCrLf & "Sagraxes Starter Helmet" & vbCrLf & "Sagraxes Starter Shoulderguards" & vbCrLf & "Sagraxes Starter Chestplate" & vbCrLf & "Sagraxes Starter Legguards" & vbCrLf & "Sagraxes Starter Threads" & vbCrLf & "Sagraxes Starter Mace" & vbCrLf & "Sagraxes Starter Shield")
            'reset progression data
            System.IO.File.WriteAllText("G:\Final Thrust\player_data\progression.ini", "1" & vbCrLf & "2" & vbCrLf & "2" & vbCrLf & "1" & vbCrLf & "4" & vbCrLf & "1" & vbCrLf & "5" & vbCrLf & "3" & vbCrLf & "3")

            My.Settings.Reset()

            Me.Close()
        End If

    End Sub
    Private Sub CMDAchievements_Click(sender As Object, e As EventArgs) Handles CMDAchievements.Click
        Achievements.Show()
    End Sub
    Private Sub TimerRegenerationCheck_Tick(sender As Object, e As EventArgs)
        If (LBLCurrentHP.Text + 2) > LBLMaxHP.Text Then
            LBLCurrentHP.Text = LBLMaxHP.Text
        Else
            LBLCurrentHP.Text += 2
        End If

        If LBLCurrentHP.Text = 0 Then
            PCBAvatar.ImageLocation = "G:\Final Thrust\game_data\game_characters\" & LBLCharacterName.Text & "\" & LBLCharacterName.Text & "_Death.png"
        Else
            PCBAvatar.ImageLocation = "G:\Final Thrust\game_data\game_characters\" & LBLCharacterName.Text & "\" & LBLCharacterName.Text & ".png"
        End If
    End Sub
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If is_closing = False Then
            playsound("warning", False)
            If vbYes = MsgBox("Are you sure you wish to quit? Your progress will be saved.", vbYesNo, "WARNING") Then
                is_closing = True
                Application.Exit()
            Else
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub LSBInventory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LSBInventory.SelectedIndexChanged
        If LSBInventory.SelectedItem <> "" Then
            'Handle visibility
            'this data never changes position or visibility
            GRBItemInfo.Visible = True
            GRBItemInfo.Text = LSBInventory.SelectedItem
            LBLEquipmentType.Text = translate_item_data(LSBInventory.SelectedItem, 1, 2)
            LBLEquipmentType.Left = GRBItemInfo.Width - LBLEquipmentType.Width - 5

            'AC will always be in the same position because it is the first line
            LBLEquipmentAC.Text = translate_item_data(LSBInventory.SelectedItem, 1, 5)
            If LBLEquipmentAC.Text = 0 Then
                LBLEquipmentAC.Visible = False
                LBLmnuEquipmentAC.Visible = False
            Else
                LBLEquipmentAC.Visible = True
                LBLmnuEquipmentAC.Visible = True
            End If

            LBLEquipmentDamage.Text = translate_item_data(LSBInventory.SelectedItem, 1, 6) & " - " & translate_item_data(LSBInventory.SelectedItem, 1, 7)
            If translate_item_data(LSBInventory.SelectedItem, 1, 6) = 0 Then
                LBLEquipmentDamage.Visible = False
                LBLmnuEquipmentDamage.Visible = False
            Else
                LBLEquipmentDamage.Visible = True
                LBLmnuEquipmentDamage.Visible = True
            End If

            LBLEquipmentExtraHealth.Text = "+ " & translate_item_data(LSBInventory.SelectedItem, 1, 13) & " Health"
            If translate_item_data(LSBInventory.SelectedItem, 1, 13) = 0 Then
                LBLEquipmentExtraHealth.Visible = False
            Else
                LBLEquipmentExtraHealth.Visible = True
            End If

            LBLEquipmentExtraMana.Text = "+ " & translate_item_data(LSBInventory.SelectedItem, 1, 14) & " Mana"
            If translate_item_data(LSBInventory.SelectedItem, 1, 14) = 0 Then
                LBLEquipmentExtraMana.Visible = False
            Else
                LBLEquipmentExtraMana.Visible = True
            End If

            LBLEquipmentExtraHitChance.Text = "+ " & translate_item_data(LSBInventory.SelectedItem, 1, 15) & "% Hit Chance"
            If translate_item_data(LSBInventory.SelectedItem, 1, 15) = 0 Then
                LBLEquipmentExtraHitChance.Visible = False
            Else
                LBLEquipmentExtraHitChance.Visible = True
            End If

            LBLEquipmentExtraCritChance.Text = "+ " & translate_item_data(LSBInventory.SelectedItem, 1, 16) & "% Crit Chance"
            If translate_item_data(LSBInventory.SelectedItem, 1, 16) = 0 Then
                LBLEquipmentExtraCritChance.Visible = False
            Else
                LBLEquipmentExtraCritChance.Visible = True
            End If


            LBLEquipmentDescription.Text = Chr(34) & translate_item_data(LSBInventory.SelectedItem, 1, 3) & Chr(34)


            LBLEquipmentValue.Text = translate_item_data(LSBInventory.SelectedItem, 1, 9)
            PCBSelecteditem.ImageLocation = translate_item_data(LSBInventory.SelectedItem, 1, 12)


            Select Case translate_item_data(LSBInventory.SelectedItem, 1, 4)
                Case "Legendary"
                    GRBItemInfo.ForeColor = Color.Orange
                Case "Epic"
                    GRBItemInfo.ForeColor = Color.MediumOrchid
                Case "Rare"
                    GRBItemInfo.ForeColor = Color.DodgerBlue
                Case "Common"
                    GRBItemInfo.ForeColor = Color.White
            End Select

            'Handle Orientation

        Else
            GRBItemInfo.Visible = False
        End If
    End Sub
    Private Sub CMDSettings_Click(sender As Object, e As EventArgs) Handles CMDSettings.Click
        If PNLSettings.Visible = True Then
            PNLSettings.Visible = False
        Else
            PNLSettings.Visible = True
        End If
    End Sub
    Private Sub TCBMusicVolume_Scroll(sender As Object, e As EventArgs) Handles TCBMusicVolume.Scroll
        'set video player volume to the selected value on the scrollbar
        music_player.settings.volume = TCBMusicVolume.Value
        LBLVolume.Text = "Music Volume: " & TCBMusicVolume.Value
        If TCBMusicVolume.Value = 0 Then
            music_player.settings.mute = True
            mute_music = True
            CMDMuteMusic.BackgroundImage = System.Drawing.Image.FromFile("G:\Final Thrust\game_data\image sources\cntrl_UnmuteVolume.png")
            'if video is muted, unmute it
        Else
            music_player.settings.mute = False
            mute_music = False
            CMDMuteMusic.BackgroundImage = System.Drawing.Image.FromFile("G:\Final Thrust\game_data\image sources\cntrl_MuteVolume.png")
        End If
        My.Settings.Music_Volume = TCBMusicVolume.Value

    End Sub
    Private Sub CMDMuteMusic_Click(sender As Object, e As EventArgs) Handles CMDMuteMusic.Click
        If mute_music = False Then
            music_player.settings.mute = True
            mute_music = True
            CMDMuteMusic.BackgroundImage = System.Drawing.Image.FromFile("G:\Final Thrust\game_data\image sources\cntrl_UnmuteVolume.png")
        Else
            music_player.settings.mute = False
            mute_music = False
            CMDMuteMusic.BackgroundImage = System.Drawing.Image.FromFile("G:\Final Thrust\game_data\image sources\cntrl_MuteVolume.png")
        End If
    End Sub
    Private Sub CMDMuteSfx_Click(sender As Object, e As EventArgs) Handles CMDMuteSfx.Click
        If My.Settings.SFX_Mute = False Then
            My.Settings.SFX_Mute = True
            CMDMuteSfx.BackgroundImage = System.Drawing.Image.FromFile("G:\Final Thrust\game_data\image sources\cntrl_UnmuteVolume.png")
        Else
            My.Settings.SFX_Mute = False
            CMDMuteSfx.BackgroundImage = System.Drawing.Image.FromFile("G:\Final Thrust\game_data\image sources\cntrl_MuteVolume.png")
        End If
        My.Settings.Save()
    End Sub
    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            trigger_console()
        End If
    End Sub
    Private Sub TimerRegen_Tick(sender As Object, e As EventArgs) Handles TimerRegen.Tick
        If (LBLCurrentHP.Text + 2) > LBLMaxHP.Text Then
            LBLCurrentHP.Text = LBLMaxHP.Text
        Else
            LBLCurrentHP.Text += 2
        End If
        Select Case LBLCharacterName.Text
            Case "Alysha"
                My.Settings.Alysha_last_played = Now
            Case "Makyr"
                My.Settings.Makyr_last_played = Now
            Case "Nardina"
                My.Settings.Nardina_last_played = Now
            Case "Nylathria"
                My.Settings.Nylathria_last_played = Now
            Case "Sagraxes"
                My.Settings.Sagraxes_last_played = Now
        End Select
        My.Settings.Save()
    End Sub

    'DATA SUBS
    Private Sub unequip_item(sender As Object, e As EventArgs) Handles CMDUnequipHead.Click, CMDUnequipShoulders.Click, CMDUnequipChest.Click, CMDUnequipLegs.Click, CMDUnequipBoots.Click, CMDUnequipMainhand.Click, CMDUnequipOffhand.Click

        Select Case sender.name
            Case "CMDUnequipHead"
                playsound("(un)equip_armor", False)
                If TXTHead.Text <> "" Then
                    add_item_to_inventory(translate_item_data(TXTHead.Text, 1, 1))
                    TXTHead.Text = ""
                End If

            Case "CMDUnequipShoulders"
                playsound("(un)equip_armor", False)
                If TXTShoulders.Text <> "" Then
                    add_item_to_inventory(translate_item_data(TXTShoulders.Text, 1, 1))
                    TXTShoulders.Text = ""
                End If

            Case "CMDUnequipChest"
                playsound("(un)equip_armor", False)
                If TXTChest.Text <> "" Then
                    add_item_to_inventory(translate_item_data(TXTChest.Text, 1, 1))
                    TXTChest.Text = ""
                End If

            Case "CMDUnequipLegs"
                playsound("(un)equip_armor", False)
                If TXTLegs.Text <> "" Then
                    add_item_to_inventory(translate_item_data(TXTLegs.Text, 1, 1))
                    TXTLegs.Text = ""
                End If

            Case "CMDUnequipBoots"
                playsound("(un)equip_armor", False)
                If TXTBoots.Text <> "" Then
                    add_item_to_inventory(translate_item_data(TXTBoots.Text, 1, 1))
                    TXTBoots.Text = ""
                End If

            Case "CMDUnequipMainhand"
                playsound("(un)equip_weapon", False)
                If TXTMainHand.Text <> "" Then
                    add_item_to_inventory(translate_item_data(TXTMainHand.Text, 1, 1))
                    TXTMainHand.Text = ""
                    TXTOffHand.BackColor = Color.Maroon
                    TXTOffHand.Enabled = True
                End If

            Case "CMDUnequipOffhand"
                playsound("(un)equip_weapon", False)
                If TXTOffHand.Text <> "" Then
                    add_item_to_inventory(translate_item_data(TXTOffHand.Text, 1, 1))
                    TXTOffHand.Text = ""
                End If
        End Select

        update_attribute_modifiers()

    End Sub
    Public Sub add_item_to_inventory(item_name As String)
        LSBInventory.Items.Add(item_name)
    End Sub
    Public Sub update_attribute_modifiers()

        If LBLUnspentAttributePoints.Text = 0 Then
            CMDAddStrength.Enabled = False
            CMDAddStrength.BackColor = Color.FromArgb(0, 64, 0, 0)
            CMDAddDexterity.Enabled = False
            CMDAddDexterity.BackColor = Color.FromArgb(0, 64, 0, 0)
            CMDAddConstitution.Enabled = False
            CMDAddConstitution.BackColor = Color.FromArgb(0, 64, 0, 0)
            CMDAddIntelligence.Enabled = False
            CMDAddIntelligence.BackColor = Color.FromArgb(0, 64, 0, 0)
            CMDAddWisdom.Enabled = False
            CMDAddWisdom.BackColor = Color.FromArgb(0, 64, 0, 0)
            CMDAddCharisma.Enabled = False
            CMDAddCharisma.BackColor = Color.FromArgb(0, 64, 0, 0)
        Else
            If LBLStrength.Text = 20 + (LBLMastery61Score.Text * 2) Then
                CMDAddStrength.Enabled = False
                CMDAddStrength.BackColor = Color.FromArgb(0, 64, 0, 0)
            Else
                CMDAddStrength.Enabled = True
                CMDAddStrength.BackColor = Color.Maroon
            End If

            If LBLDexterity.Text = 20 + (LBLMastery61Score.Text * 2) Then
                CMDAddDexterity.Enabled = False
                CMDAddDexterity.BackColor = Color.FromArgb(0, 64, 0, 0)
            Else
                CMDAddDexterity.Enabled = True
                CMDAddDexterity.BackColor = Color.Maroon
            End If

            If LBLConstitution.Text = 20 + (LBLMastery61Score.Text * 2) Then
                CMDAddConstitution.Enabled = False
                CMDAddConstitution.BackColor = Color.FromArgb(0, 64, 0, 0)
            Else
                CMDAddConstitution.Enabled = True
                CMDAddConstitution.BackColor = Color.Maroon
            End If

            If LBLIntelligence.Text = 20 + (LBLMastery61Score.Text * 2) Then
                CMDAddIntelligence.Enabled = False
                CMDAddIntelligence.BackColor = Color.FromArgb(0, 64, 0, 0)
            Else
                CMDAddIntelligence.Enabled = True
                CMDAddIntelligence.BackColor = Color.Maroon
            End If

            If LBLWisdom.Text = 20 + (LBLMastery61Score.Text * 2) Then
                CMDAddWisdom.Enabled = False
                CMDAddWisdom.BackColor = Color.FromArgb(0, 64, 0, 0)
            Else
                CMDAddWisdom.Enabled = True
                CMDAddWisdom.BackColor = Color.Maroon
            End If

            If LBLCharisma.Text = 20 + (LBLMastery61Score.Text * 2) Then
                CMDAddCharisma.Enabled = False
                CMDAddCharisma.BackColor = Color.FromArgb(0, 64, 0, 0)
            Else
                CMDAddCharisma.Enabled = True
                CMDAddCharisma.BackColor = Color.Maroon
            End If
        End If


        If LBLStrength.Text <= 10 Then
            CMDSubtractStrength.Enabled = False
            CMDSubtractStrength.BackColor = Color.FromArgb(0, 64, 0, 0)
        Else
            CMDSubtractStrength.Enabled = True
            CMDSubtractStrength.BackColor = Color.Maroon
        End If

        If LBLDexterity.Text <= 10 Then
            CMDSubtractDexterity.Enabled = False
            CMDSubtractDexterity.BackColor = Color.FromArgb(0, 64, 0, 0)
        Else
            CMDSubtractDexterity.Enabled = True
            CMDSubtractDexterity.BackColor = Color.Maroon
        End If

        If LBLConstitution.Text <= 10 Then
            CMDSubtractConstitution.Enabled = False
            CMDSubtractConstitution.BackColor = Color.FromArgb(0, 64, 0, 0)
        Else
            CMDSubtractConstitution.Enabled = True
            CMDSubtractConstitution.BackColor = Color.Maroon
        End If

        If LBLIntelligence.Text <= 10 Then
            CMDSubtractIntelligence.Enabled = False
            CMDSubtractIntelligence.BackColor = Color.FromArgb(0, 64, 0, 0)
        Else
            CMDSubtractIntelligence.Enabled = True
            CMDSubtractIntelligence.BackColor = Color.Maroon
        End If

        If LBLWisdom.Text <= 10 Then
            CMDSubtractWisdom.Enabled = False
            CMDSubtractWisdom.BackColor = Color.FromArgb(0, 64, 0, 0)
        Else
            CMDSubtractWisdom.Enabled = True
            CMDSubtractWisdom.BackColor = Color.Maroon
        End If

        If LBLCharisma.Text <= 10 Then
            CMDSubtractCharisma.Enabled = False
            CMDSubtractCharisma.BackColor = Color.FromArgb(0, 64, 0, 0)
        Else
            CMDSubtractCharisma.Enabled = True
            CMDSubtractCharisma.BackColor = Color.Maroon
        End If

        LBLStrengthMod.Text = Math.Floor((LBLStrength.Text - 10) / 2)
        LBLDexterityMod.Text = Math.Floor((LBLDexterity.Text - 10) / 2)
        LBLConstitutionMod.Text = Math.Floor((LBLConstitution.Text - 10) / 2)
        LBLIntelligenceMod.Text = Math.Floor((LBLIntelligence.Text - 10) / 2)
        LBLWisdomMod.Text = Math.Floor((LBLWisdom.Text - 10) / 2)
        LBLCharismaMod.Text = Math.Floor((LBLCharisma.Text - 10) / 2)

        'update skill damage modifier
        skill_damage_modifier = (LBLWisdomMod.Text * 5)

        'update max hp
        LBLMaxHP.Text = (100 + ((LBLLevel.Text * 10) - 10)) + (LBLConstitutionMod.Text * 50)
        Dim mastery_hp As Integer = ((LBLMaxHP.Text / 100) * 20) * LBLMastery41Score.Text
        LBLMaxHP.Text += mastery_hp

        'update max mp
        LBLMaxMP.Text = (100 + ((LBLLevel.Text * 10) - 10)) + (LBLIntelligenceMod.Text * 50)
        Dim mastery_mp As Integer = ((LBLMaxMP.Text / 100) * 20) * LBLMastery42Score.Text
        LBLMaxMP.Text += mastery_mp

        update_equipment_stats()
    End Sub
    Public Sub update_equipment_stats()
        Dim total_equipment_ac As Integer = 0
        Dim total_min_equipment_dmg As Integer = 0
        Dim total_max_equipment_dmg As Integer = 0
        Dim total_extra_health As Integer = 0
        Dim total_extra_mana As Integer = 0

        'update head
        If TXTHead.Text <> "" Then
            total_equipment_ac += translate_item_data(TXTHead.Text, 1, 5) 'request AC
            total_min_equipment_dmg += translate_item_data(TXTHead.Text, 1, 6) 'request damage min
            total_max_equipment_dmg += translate_item_data(TXTHead.Text, 1, 7) 'request damage max
            total_extra_health += translate_item_data(TXTHead.Text, 1, 13)
            total_extra_mana += translate_item_data(TXTHead.Text, 1, 14)
            total_extra_hc += translate_item_data(TXTHead.Text, 1, 15)
            total_extra_cc += translate_item_data(TXTHead.Text, 1, 16)
        End If

        'update shoulders
        If TXTShoulders.Text <> "" Then
            total_equipment_ac += translate_item_data(TXTShoulders.Text, 1, 5) 'request AC
            total_min_equipment_dmg += translate_item_data(TXTShoulders.Text, 1, 6) 'request damage min
            total_max_equipment_dmg += translate_item_data(TXTShoulders.Text, 1, 7) 'request damage max
            total_extra_health += translate_item_data(TXTShoulders.Text, 1, 13)
            total_extra_mana += translate_item_data(TXTShoulders.Text, 1, 14)
            total_extra_hc += translate_item_data(TXTShoulders.Text, 1, 15)
            total_extra_cc += translate_item_data(TXTShoulders.Text, 1, 16)
        End If

        'update chest
        If TXTChest.Text <> "" Then
            total_equipment_ac += translate_item_data(TXTChest.Text, 1, 5) 'request AC
            total_min_equipment_dmg += translate_item_data(TXTChest.Text, 1, 6) 'request damage min
            total_max_equipment_dmg += translate_item_data(TXTChest.Text, 1, 7) 'request damage max
            total_extra_health += translate_item_data(TXTChest.Text, 1, 13)
            total_extra_mana += translate_item_data(TXTChest.Text, 1, 14)
            total_extra_hc += translate_item_data(TXTChest.Text, 1, 15)
            total_extra_cc += translate_item_data(TXTChest.Text, 1, 16)
        End If

        'update legs
        If TXTLegs.Text <> "" Then
            total_equipment_ac += translate_item_data(TXTLegs.Text, 1, 5) 'request AC
            total_min_equipment_dmg += translate_item_data(TXTLegs.Text, 1, 6) 'request damage min
            total_max_equipment_dmg += translate_item_data(TXTLegs.Text, 1, 7) 'request damage max
            total_extra_health += translate_item_data(TXTLegs.Text, 1, 13)
            total_extra_mana += translate_item_data(TXTLegs.Text, 1, 14)
            total_extra_hc += translate_item_data(TXTLegs.Text, 1, 15)
            total_extra_cc += translate_item_data(TXTLegs.Text, 1, 16)
        End If

        'update boots
        If TXTBoots.Text <> "" Then
            total_equipment_ac += translate_item_data(TXTBoots.Text, 1, 5) 'request AC
            total_min_equipment_dmg += translate_item_data(TXTBoots.Text, 1, 6) 'request damage min
            total_max_equipment_dmg += translate_item_data(TXTBoots.Text, 1, 7) 'request damage max
            total_extra_health += translate_item_data(TXTBoots.Text, 1, 13)
            total_extra_mana += translate_item_data(TXTBoots.Text, 1, 14)
            total_extra_hc += translate_item_data(TXTBoots.Text, 1, 15)
            total_extra_cc += translate_item_data(TXTBoots.Text, 1, 16)
        End If

        'update main hand
        If TXTMainHand.Text <> "" Then
            total_equipment_ac += translate_item_data(TXTMainHand.Text, 1, 5) 'request AC
            total_min_equipment_dmg += translate_item_data(TXTMainHand.Text, 1, 6) 'request damage min
            total_max_equipment_dmg += translate_item_data(TXTMainHand.Text, 1, 7) 'request damage max
            total_extra_health += translate_item_data(TXTMainHand.Text, 1, 13)
            total_extra_mana += translate_item_data(TXTMainHand.Text, 1, 14)
            total_extra_hc += translate_item_data(TXTMainHand.Text, 1, 15)
            total_extra_cc += translate_item_data(TXTMainHand.Text, 1, 16)
        End If

        'check if 2H item is equiped
        If TXTMainHand.Text <> "" Then

            If translate_item_data(TXTMainHand.Text, 1, 2) = "2H" Then
                TXTOffHand.Enabled = False
                TXTOffHand.BackColor = Color.Black
            Else
                TXTOffHand.Enabled = True
                TXTOffHand.BackColor = Color.Maroon
            End If
        Else
            TXTOffHand.Enabled = True
            TXTOffHand.BackColor = Color.Maroon
        End If

        'update off hand only if txtoffhand.enabled = true   --- is disabled when a 2H item is equipped.
        If TXTOffHand.Enabled = True Then
            If TXTOffHand.Text <> "" Then
                total_equipment_ac += translate_item_data(TXTOffHand.Text, 1, 5) 'request AC
                total_min_equipment_dmg += translate_item_data(TXTOffHand.Text, 1, 6) 'request damage min
                total_max_equipment_dmg += translate_item_data(TXTOffHand.Text, 1, 7) 'request damage max
                total_extra_health += translate_item_data(TXTOffHand.Text, 1, 13)
                total_extra_mana += translate_item_data(TXTOffHand.Text, 1, 14)
                total_extra_hc += translate_item_data(TXTOffHand.Text, 1, 15)
                total_extra_cc += translate_item_data(TXTOffHand.Text, 1, 16)
            End If
        End If


        'update ac
        Dim mastery_ac As Integer = 0
        If TXTOffHand.Text <> "" Then
            If translate_item_data(TXTOffHand.Text, 1, 2) = "OH" Then mastery_ac = LBLMastery33Score.Text
        End If
        LBLarmorclass.Text = 3 + LBLDexterityMod.Text + total_equipment_ac + mastery_ac

        'damage calculation
        damage_min = 1 + total_min_equipment_dmg + (LBLStrengthMod.Text * 5)
        damage_max = 1 + total_max_equipment_dmg + (LBLStrengthMod.Text * 5)
        skill_damage_modifier += damage_min 'this adds weapon min damage to spell potency

        'update hit chance
        LBLHitChance.Text = 100 - (30 - total_extra_hc - (LBLCharismaMod.Text * 2)) & "%"

        'update crit chance
        LBLCritChance.Text = (LBLDexterityMod.Text * 4) + 1 + total_extra_cc & "%"

        'update max hp
        LBLMaxHP.Text += total_extra_health

        'update max mp
        LBLMaxMP.Text += total_extra_mana

        'update damage
        LBLDamage.Text = damage_min & " - " & damage_max

        'make sure current hp doesn't exceed max hp
        If LBLCurrentHP.Text > LBLMaxHP.Text Then
            LBLCurrentHP.Text = LBLMaxHP.Text
        End If

        'make sure current mp doesn't exceed max mp
        If LBLCurrentMP.Text > LBLMaxMP.Text Then
            LBLCurrentMP.Text = LBLMaxMP.Text
        End If
    End Sub
    Public Sub load_character(character_name As String)

        'load character info
        Dim character_info As StreamReader = My.Computer.FileSystem.OpenTextFileReader("G:\Final Thrust\game_data\game_characters\" & character_name & "\" & character_name & ".ini")
        LBLCharacterName.Text = character_info.ReadLine
        LBLRace.Text = character_info.ReadLine
        LBLAlignment.Text = character_info.ReadLine
        LBLGender.Text = character_info.ReadLine
        character_info.Close()

        'load character data
        Dim character_data As StreamReader = My.Computer.FileSystem.OpenTextFileReader("G:\Final Thrust\player_data\" & character_name & "_attributes.ini")
        Dim current_hp As Integer = character_data.ReadLine 'load current hp after stats have been updated  
        LBLCurrentMP.Text = character_data.ReadLine
        LBLExperience.Text = character_data.ReadLine
        LBLUnspentAttributePoints.Text = character_data.ReadLine
        LBLStrength.Text = character_data.ReadLine
        LBLDexterity.Text = character_data.ReadLine
        LBLConstitution.Text = character_data.ReadLine
        LBLIntelligence.Text = character_data.ReadLine
        LBLWisdom.Text = character_data.ReadLine
        LBLCharisma.Text = character_data.ReadLine
        TXTHead.Text = character_data.ReadLine
        TXTShoulders.Text = character_data.ReadLine
        TXTChest.Text = character_data.ReadLine
        TXTLegs.Text = character_data.ReadLine
        TXTBoots.Text = character_data.ReadLine
        TXTMainHand.Text = character_data.ReadLine
        TXTOffHand.Text = character_data.ReadLine
        character_data.Close()

        If current_hp = 0 Then
            PCBAvatar.ImageLocation = "G:\Final Thrust\game_data\game_characters\" & LBLCharacterName.Text & "\" & LBLCharacterName.Text & "_Death.png"
        Else
            PCBAvatar.ImageLocation = "G:\Final Thrust\game_data\game_characters\" & LBLCharacterName.Text & "\" & LBLCharacterName.Text & ".png"
        End If

        'set correct rarity colors for the equiped items
        'loop through every textbox in the equipment groupbox
        For Each ctrl As Control In GRBEquipment.Controls
            If TypeOf ctrl Is TextBox Then
                If ctrl.Text <> "" Then
                    Select Case translate_item_data(ctrl.Text, 1, 4)
                        Case "Legendary"
                            ctrl.ForeColor = Color.Orange
                        Case "Epic"
                            ctrl.ForeColor = Color.MediumOrchid
                        Case "Rare"
                            ctrl.ForeColor = Color.DodgerBlue
                        Case "Common"
                            ctrl.ForeColor = Color.White
                    End Select
                End If
            End If
        Next


        'update stats
        update_attribute_modifiers()


        display_level(LBLExperience.Text)

        'load current hp from previously read file
        LBLCurrentHP.Text = current_hp

        'add heal from time being offline
        add_regen_health()
    End Sub
    Private Sub display_level(total_xp As Integer)
        Select Case total_xp
            Case < 300
                LBLLevel.Text = 1
                LBLArenaLevel.Text = 1
            Case < 900
                LBLLevel.Text = 2
                LBLArenaLevel.Text = 2
            Case < 2700
                LBLLevel.Text = 3
                LBLArenaLevel.Text = 3
            Case < 6500
                LBLLevel.Text = 4
                LBLArenaLevel.Text = 4
            Case < 14000
                LBLLevel.Text = 5
                LBLArenaLevel.Text = 5
            Case < 23000
                LBLLevel.Text = 6
                LBLArenaLevel.Text = 6
            Case < 34000
                LBLLevel.Text = 7
                LBLArenaLevel.Text = 7
            Case < 48000
                LBLLevel.Text = 8
                LBLArenaLevel.Text = 8
            Case < 64000
                LBLLevel.Text = 9
                LBLArenaLevel.Text = 9
            Case < 85000
                LBLLevel.Text = 10
                LBLArenaLevel.Text = 10
            Case < 100000
                LBLLevel.Text = 11
                LBLArenaLevel.Text = 11
            Case < 120000
                LBLLevel.Text = 12
                LBLArenaLevel.Text = 12
            Case < 140000
                LBLLevel.Text = 13
                LBLArenaLevel.Text = 13
            Case < 165000
                LBLLevel.Text = 14
                LBLArenaLevel.Text = 14
            Case < 195000
                LBLLevel.Text = 15
                LBLArenaLevel.Text = 15
            Case < 225000
                LBLLevel.Text = 16
                LBLArenaLevel.Text = 16
            Case < 265000
                LBLLevel.Text = 17
                LBLArenaLevel.Text = 17
            Case < 305000
                LBLLevel.Text = 18
                LBLArenaLevel.Text = 18
            Case < 355000
                LBLLevel.Text = 19
                LBLArenaLevel.Text = 19
            Case Else
                LBLLevel.Text = 20
                LBLArenaLevel.Text = 20
        End Select
    End Sub
    Private Sub gain_xp(xp As Integer)

        LBLExperience.Text += xp

        Dim old_level As Integer = LBLLevel.Text

        display_level(LBLExperience.Text)

        If old_level <> LBLLevel.Text Then
            'leveled up
            LBLUnspentAttributePoints.Text += 1
            'fully restore hp & mp when leveled
            LBLCurrentHP.Text = LBLMaxHP.Text
            LBLCurrentMP.Text = LBLMaxMP.Text
            LBLArenaCurrentHP.Text = LBLArenaMaxHP.Text
            LBLArenaCurrentMP.Text = LBLArenaMaxMP.Text
            playsound("levelup", True)
        End If

        update_attribute_modifiers()

    End Sub
    Private Sub modify_attribute_points_Click(sender As Object, e As EventArgs) Handles CMDSubtractStrength.Click, CMDSubtractDexterity.Click, CMDSubtractConstitution.Click, CMDSubtractIntelligence.Click, CMDSubtractWisdom.Click, CMDSubtractCharisma.Click, CMDAddStrength.Click, CMDAddDexterity.Click, CMDAddConstitution.Click, CMDAddIntelligence.Click, CMDAddWisdom.Click, CMDAddCharisma.Click

        If sender.text = "+" Then
            Select Case sender.name.tolower
                Case "cmdaddstrength"
                    If LBLStrength.Text < 20 + (LBLMastery61Score.Text * 2) Then
                        LBLStrength.Text += 1
                        LBLUnspentAttributePoints.Text -= 1
                    End If
                Case "cmdadddexterity"
                    If LBLDexterity.Text < 20 + (LBLMastery61Score.Text * 2) Then
                        LBLDexterity.Text += 1
                        LBLUnspentAttributePoints.Text -= 1
                    End If
                Case "cmdaddconstitution"
                    If LBLConstitution.Text < 20 + (LBLMastery61Score.Text * 2) Then
                        LBLConstitution.Text += 1
                        LBLUnspentAttributePoints.Text -= 1
                    End If
                Case "cmdaddintelligence"
                    If LBLIntelligence.Text < 20 + (LBLMastery61Score.Text * 2) Then
                        LBLIntelligence.Text += 1
                        LBLUnspentAttributePoints.Text -= 1
                    End If
                Case "cmdaddwisdom"
                    If LBLWisdom.Text < 20 + (LBLMastery61Score.Text * 2) Then
                        LBLWisdom.Text += 1
                        LBLUnspentAttributePoints.Text -= 1
                    End If
                Case "cmdaddcharisma"
                    If LBLCharisma.Text < 20 + (LBLMastery61Score.Text * 2) Then
                        LBLCharisma.Text += 1
                        LBLUnspentAttributePoints.Text -= 1
                    End If
            End Select
        Else
            Select Case sender.name.tolower
                Case "cmdsubtractstrength"
                    If LBLStrength.Text > 10 Then
                        LBLStrength.Text -= 1
                        LBLUnspentAttributePoints.Text += 1
                    End If
                Case "cmdsubtractdexterity"
                    If LBLDexterity.Text > 10 Then
                        LBLDexterity.Text -= 1
                        LBLUnspentAttributePoints.Text += 1
                    End If
                Case "cmdsubtractconstitution"
                    If LBLConstitution.Text > 10 Then
                        LBLConstitution.Text -= 1
                        LBLUnspentAttributePoints.Text += 1
                    End If
                Case "cmdsubtractintelligence"
                    If LBLIntelligence.Text > 10 Then
                        LBLIntelligence.Text -= 1
                        LBLUnspentAttributePoints.Text += 1
                    End If
                Case "cmdsubtractwisdom"
                    If LBLWisdom.Text > 10 Then
                        LBLWisdom.Text -= 1
                        LBLUnspentAttributePoints.Text += 1
                    End If
                Case "cmdsubtractcharisma"
                    If LBLCharisma.Text > 10 Then
                        LBLCharisma.Text -= 1
                        LBLUnspentAttributePoints.Text += 1
                    End If

            End Select
        End If
        update_attribute_modifiers()
    End Sub
    Private Sub change_skin(skin As String)

        If vbYes = MsgBox("Loading a new skin will require a restart of the game. Do you wish to continue?", vbYesNo, "WARNING") Then

            save()

            'delete all character avatars (deletes all png files in given folder - careful for bugs)
            Dim character_avatars As String = "G:\Final Thrust\game_data\game_characters"
            For Each deleteFile In Directory.GetFiles(character_avatars, "*.png*", SearchOption.AllDirectories)
                File.Delete(deleteFile)
            Next

            'delete all progression images (deletes all files in given folder - careful for bugs)
            Dim progression_images As String = "G:\Final Thrust\game_data\progression"
            For Each deleteFile In Directory.GetFiles(progression_images, "*.*", SearchOption.AllDirectories)
                File.Delete(deleteFile)
            Next



            Select Case skin
                Case "mod:default"
                    'Copy new character images
                    File.Copy("G:\Final Thrust\game_data\mods\default_skin\characters\Alysha.png", "G:\Final Thrust\game_data\game_characters\Alysha\Alysha.png", True)
                    File.Copy("G:\Final Thrust\game_data\mods\default_skin\characters\Makyr.png", "G:\Final Thrust\game_data\game_characters\Makyr\Makyr.png", True)
                    File.Copy("G:\Final Thrust\game_data\mods\default_skin\characters\Nardina.png", "G:\Final Thrust\game_data\game_characters\Nardina\Nardina.png", True)
                    File.Copy("G:\Final Thrust\game_data\mods\default_skin\characters\Nylathria.png", "G:\Final Thrust\game_data\game_characters\Nylathria\Nylathria.png", True)
                    File.Copy("G:\Final Thrust\game_data\mods\default_skin\characters\Sagraxes.png", "G:\Final Thrust\game_data\game_characters\Sagraxes\Sagraxes.png", True)

                    'Copy new progression images
                    Dim progression_images_new As String = "G:\Final Thrust\game_data\mods\default_skin\progression"
                    For Each copyFile In Directory.GetFiles(progression_images_new, "*.*", SearchOption.AllDirectories)
                        Dim parts() = copyFile.Split("\")
                        File.Copy(copyFile, "G:\Final Thrust\game_data\progression\" & parts(6) & "\" & Path.GetFileName(copyFile), True)
                    Next

                Case "mod:hmod"
                    'Copy new character images
                    File.Copy("G:\Final Thrust\game_data\mods\h_skin\characters\Alysha.png", "G:\Final Thrust\game_data\game_characters\Alysha\Alysha.png", True)
                    File.Copy("G:\Final Thrust\game_data\mods\h_skin\characters\Makyr.png", "G:\Final Thrust\game_data\game_characters\Makyr\Makyr.png", True)
                    File.Copy("G:\Final Thrust\game_data\mods\h_skin\characters\Nardina.png", "G:\Final Thrust\game_data\game_characters\Nardina\Nardina.png", True)
                    File.Copy("G:\Final Thrust\game_data\mods\h_skin\characters\Nylathria.png", "G:\Final Thrust\game_data\game_characters\Nylathria\Nylathria.png", True)
                    File.Copy("G:\Final Thrust\game_data\mods\h_skin\characters\Sagraxes.png", "G:\Final Thrust\game_data\game_characters\Sagraxes\Sagraxes.png", True)

                    'Copy new progression images
                    Dim progression_images_new As String = "G:\Final Thrust\game_data\mods\h_skin\progression"
                    For Each copyFile In Directory.GetFiles(progression_images_new, "*.*", SearchOption.AllDirectories)
                        Dim parts() = copyFile.Split("\")
                        File.Copy(copyFile, "G:\Final Thrust\game_data\progression\" & parts(6) & "\" & Path.GetFileName(copyFile), True)
                    Next

                Case "mod:pixelhmod"
                    'WIP
            End Select

            Me.Close()
        End If
    End Sub
    Public Function translate_item_data(item_info As String, given_part As Integer, requested_part As Integer)

        'REQUESTABLE PARTS
        '0: ID
        '1: Name
        '2: Type
        '3: Description
        '4: Rarity
        '5: AC
        '6: dmg_min
        '7: dmg_max
        '8: sold_by_store
        '9: Value
        '10: Droppable
        '11: loot_tier
        '12: icon_image_location
        '13: Extra HP
        '14: Extra MP
        '15: Extra Hit Chance
        '16: Extra Crit Chance

        GC.Collect()

        If item_info <> "" Then
            'MsgBox("translate_item_data function called with the following parameters:" & vbCrLf & vbCrLf & "item_info: " & item_info & vbCrLf & "given_part: " & given_part & vbCrLf & "requested part: " & requested_part)
            'if item_info is an entire line, then given_part has to be -1
            If given_part = -1 Then
                Dim parts() = item_info.Split(",")
                Return parts(requested_part)
                Exit Function
            Else
                'find the entire line of the given information
                'load database
                Dim lines() As String = IO.File.ReadAllLines("G:\Final Thrust\game_data\item_database.ini")
                For Each item As String In lines


                    Dim parts() = item.Split(",")
                    If parts(given_part) = item_info Then
                        'if entire line is requested, request_part must be -1
                        If requested_part = -1 Then
                            Return item_info
                            Exit Function
                        Else
                            Return parts(requested_part)
                            Exit Function
                        End If
                    End If
                Next
            End If
        End If
    End Function
    Public Sub playsound(sfx As String, wait As Boolean)
        If My.Settings.SFX_Mute = False Then
            'MsgBox("Now playing sound file: " & vbCrLf & sfx)
            'if SFX is swing, randomize to play 1 of 3 swing sounds
            If sfx.Contains("swing") Then
                Randomize()
                Dim RNG As Integer = Int((3 * Rnd()) + 1) 'generate random number between 1 and 3
                If wait = False Then
                    My.Computer.Audio.Play("G:\Final Thrust\game_data\sfx\" & sfx & RNG & ".wav")
                Else
                    My.Computer.Audio.Play("G:\Final Thrust\game_data\sfx\" & sfx & RNG & ".wav", AudioPlayMode.WaitToComplete)
                End If
                'if SFX is wound, determine which charater wound needs to be played
            ElseIf sfx.Contains("_Wound") Then
                My.Computer.Audio.Play("G:\Final Thrust\game_data\sfx\" & LBLCharacterName.Text & sfx & ".wav")
            ElseIf sfx.Contains("_Death") Then
                My.Computer.Audio.Play("G:\Final Thrust\game_data\sfx\" & LBLCharacterName.Text & sfx & ".wav", AudioPlayMode.WaitToComplete)
            Else
                If wait = False Then
                    My.Computer.Audio.Play("G:\Final Thrust\game_data\sfx\" & sfx & ".wav")
                Else
                    My.Computer.Audio.Play("G:\Final Thrust\game_data\sfx\" & sfx & ".wav", AudioPlayMode.WaitToComplete)
                End If
            End If
        End If
    End Sub
    Public Sub use_consumable(consumable_name As String)
        If vbYes = MsgBox("Are you sure you wish to use " & consumable_name & "?", vbYesNo, "WARNING") Then
            Dim gains As Integer = 0
            Select Case consumable_name
                Case "Small Healing Potion"
                    gains = 50
                    If (LBLCurrentHP.Text + gains) > LBLMaxHP.Text Then
                        LBLCurrentHP.Text = LBLMaxHP.Text
                    Else
                        LBLCurrentHP.Text += gains
                    End If
                Case "Potent Healing Potion"
                    gains = 100
                    If (LBLCurrentHP.Text + gains) > LBLMaxHP.Text Then
                        LBLCurrentHP.Text = LBLMaxHP.Text
                    Else
                        LBLCurrentHP.Text += gains
                    End If
                Case "Major Healing Potion"
                    gains = 150
                    If (LBLCurrentHP.Text + gains) > LBLMaxHP.Text Then
                        LBLCurrentHP.Text = LBLMaxHP.Text
                    Else
                        LBLCurrentHP.Text += gains
                    End If
                Case "Superior Healing Potion"
                    gains = 200
                    If (LBLCurrentHP.Text + gains) > LBLMaxHP.Text Then
                        LBLCurrentHP.Text = LBLMaxHP.Text
                    Else
                        LBLCurrentHP.Text += gains
                    End If
                Case "Small Mana Potion"
                    gains = 50
                    If (LBLCurrentMP.Text + gains) > LBLMaxMP.Text Then
                        LBLCurrentMP.Text = LBLMaxMP.Text
                    Else
                        LBLCurrentMP.Text += gains
                    End If
                Case "Potent Mana Potion"
                    gains = 100
                    If (LBLCurrentMP.Text + gains) > LBLMaxMP.Text Then
                        LBLCurrentMP.Text = LBLMaxMP.Text
                    Else
                        LBLCurrentMP.Text += gains
                    End If
                Case "Major Mana Potion"
                    gains = 150
                    If (LBLCurrentMP.Text + gains) > LBLMaxMP.Text Then
                        LBLCurrentMP.Text = LBLMaxMP.Text
                    Else
                        LBLCurrentMP.Text += gains
                    End If
                Case "Superior Mana Potion"
                    gains = 200
                    If (LBLCurrentMP.Text + gains) > LBLMaxMP.Text Then
                        LBLCurrentMP.Text = LBLMaxMP.Text
                    Else
                        LBLCurrentMP.Text += gains
                    End If
            End Select
        End If

        'remove used item from inventory
        Dim item_index As Integer = 0
        For Each item In LSBInventory.Items
            If item.contains(consumable_name) Then
                LSBInventory.Items.RemoveAt(item_index)
                Exit For
            End If
            item_index += 1
        Next


    End Sub
    Private Sub trigger_console()
        Dim input_command As String = InputBox("", "CONSOLE")

        If input_command.ToLower = "devloot" Then
            LSBInventory.Items.Add(translate_item_data("0001", 0, 1))
            LSBInventory.Items.Add(translate_item_data("0002", 0, 1))
            LSBInventory.Items.Add(translate_item_data("0003", 0, 1))
            LSBInventory.Items.Add(translate_item_data("0004", 0, 1))
            LSBInventory.Items.Add(translate_item_data("0005", 0, 1))
            LSBInventory.Items.Add(translate_item_data("0006", 0, 1))
            LSBInventory.Items.Add(translate_item_data("0007", 0, 1))
        ElseIf input_command.ToLower = "teebu" Then
            LSBInventory.Items.Add(translate_item_data("0008", 0, 1))
        ElseIf input_command.ToLower = "joe" Then
            LSBInventory.Items.Add(translate_item_data("0009", 0, 1))
        ElseIf input_command.ToLower = "richboy" Then
            LBLGold.Text += 1000000
        ElseIf input_command.ToLower = "all-loot" Then
            Dim item_database_reader As StreamReader = My.Computer.FileSystem.OpenTextFileReader(My.Resources.item_database)
            Dim read_item As String = ""
            Do
                read_item = item_database_reader.ReadLine
                If read_item <> "" Then
                    LSBInventory.Items.Add(read_item)
                End If
            Loop Until read_item Is Nothing
            item_database_reader.Close()
        ElseIf input_command.ToLower = "xp" Then
            'give 250*100 xp = 25000xp
            For i As Integer = 1 To 100
                gain_xp(299)
            Next


        ElseIf input_command.ToLower = "skillz" Then
            LBLUnspentAttributePoints.Text += 10
            update_attribute_modifiers()
        ElseIf input_command.ToLower = "restore" Then
            LBLCurrentHP.Text = LBLMaxHP.Text
            LBLCurrentMP.Text = LBLMaxMP.Text
        ElseIf input_command.ToLower = "cut" Then
            LBLCurrentHP.Text -= 50
        ElseIf input_command.ToLower = "mod:default" Then
            change_skin("mod:default")
        ElseIf input_command.ToLower = "mod:hmod" Then
            change_skin("mod:hmod")
        ElseIf input_command.ToLower = "mod:pixelhmod" Then
            change_skin("mod:pixelhmod")
        ElseIf input_command.ToLower = "key" Then
            LSBInventory.Items.Add(translate_item_data("0095", 0, 1))
        ElseIf input_command.ToLower = "keyz" Then
            For keycount As Integer = 1 To 252
                LSBInventory.Items.Add(translate_item_data("0095", 0, 1))
            Next
        ElseIf input_command.ToLower = "newday" Then
            System.IO.File.WriteAllText("G:\Final Thrust\game_data\shop_cache.ini", DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"))
        ElseIf input_command.Contains("aibid:") = True Then
            Dim parts = input_command.Split(":")
            add_item_to_inventory(translate_item_data(parts(1), 0, 1))
        ElseIf input_command.ToLower = "master" Then
            For tokencount As Integer = 1 To 10
                LSBInventory.Items.Add(translate_item_data("0162", 0, 1))
            Next
        ElseIf input_command = "slave" Then
            My.Settings.Mastery_String = "0000000000000"
            My.Settings.Save()
        ElseIf input_command = "" Then
            'prevent throwing an error in case nothing is entered.
        Else
            MessageBox.Show("Command not recognized.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        save()
    End Sub
    Private Sub load_masteries()

        Dim masteries(12) As Char
        Dim i As Integer = 0

        For Each c As Char In My.Settings.Mastery_String
            masteries(i) = c
            i += 1
        Next

        LBLMastery11Score.Text = masteries(0)
        LBLMastery12Score.Text = masteries(1)
        LBLMastery13Score.Text = masteries(2)

        LBLMastery21Score.Text = masteries(3)
        LBLMastery22Score.Text = masteries(4)

        LBLMastery31Score.Text = masteries(5)
        LBLMastery32Score.Text = masteries(6)
        LBLMastery33Score.Text = masteries(7)

        LBLMastery41Score.Text = masteries(8)
        LBLMastery42Score.Text = masteries(9)

        LBLMastery51Score.Text = masteries(10)
        LBLMastery52Score.Text = masteries(11)

        LBLMastery61Score.Text = masteries(12)

        If Convert.ToInt32(LBLMastery11Score.Text) + Convert.ToInt32(LBLMastery12Score.Text) + Convert.ToInt32(LBLMastery13Score.Text) >= 5 Then
            PCBMasteryTier_2_1.ImageLocation = "G:\Final Thrust\game_data\image sources\mastery_tier_2_1.jpg"
            PCBMasteryTier_2_2.ImageLocation = "G:\Final Thrust\game_data\image sources\mastery_tier_2_2.jpg"
            PCBMasteryTier_2_1.Enabled = True
            PCBMasteryTier_2_2.Enabled = True
        Else
            PCBMasteryTier_2_1.ImageLocation = "G:\Final Thrust\game_data\image sources\mastery_tier_2_1_disabled.jpg"
            PCBMasteryTier_2_2.ImageLocation = "G:\Final Thrust\game_data\image sources\mastery_tier_2_2_disabled.jpg"
            PCBMasteryTier_2_1.Enabled = False
            PCBMasteryTier_2_2.Enabled = False
        End If

        If Convert.ToInt32(LBLMastery21Score.Text) + Convert.ToInt32(LBLMastery22Score.Text) >= 5 Then
            PCBMasteryTier_3_1.ImageLocation = "G:\Final Thrust\game_data\image sources\mastery_tier_3_1.jpg"
            PCBMasteryTier_3_2.ImageLocation = "G:\Final Thrust\game_data\image sources\mastery_tier_3_2.jpg"
            PCBMasteryTier_3_3.ImageLocation = "G:\Final Thrust\game_data\image sources\mastery_tier_3_3.jpg"
            PCBMasteryTier_3_1.Enabled = True
            PCBMasteryTier_3_2.Enabled = True
            PCBMasteryTier_3_3.Enabled = True
        Else
            PCBMasteryTier_3_1.ImageLocation = "G:\Final Thrust\game_data\image sources\mastery_tier_3_1_disabled.jpg"
            PCBMasteryTier_3_2.ImageLocation = "G:\Final Thrust\game_data\image sources\mastery_tier_3_2_disabled.jpg"
            PCBMasteryTier_3_3.ImageLocation = "G:\Final Thrust\game_data\image sources\mastery_tier_3_3_disabled.jpg"
            PCBMasteryTier_3_1.Enabled = False
            PCBMasteryTier_3_2.Enabled = False
            PCBMasteryTier_3_3.Enabled = False
        End If

        If Convert.ToInt32(LBLMastery31Score.Text) + Convert.ToInt32(LBLMastery32Score.Text) + Convert.ToInt32(LBLMastery33Score.Text) >= 5 Then
            PCBMasteryTier_4_1.ImageLocation = "G:\Final Thrust\game_data\image sources\mastery_tier_4_1.jpg"
            PCBMasteryTier_4_2.ImageLocation = "G:\Final Thrust\game_data\image sources\mastery_tier_4_2.jpg"
            PCBMasteryTier_4_1.Enabled = True
            PCBMasteryTier_4_2.Enabled = True
        Else
            PCBMasteryTier_4_1.ImageLocation = "G:\Final Thrust\game_data\image sources\mastery_tier_4_1_disabled.jpg"
            PCBMasteryTier_4_2.ImageLocation = "G:\Final Thrust\game_data\image sources\mastery_tier_4_2_disabled.jpg"
            PCBMasteryTier_4_1.Enabled = False
            PCBMasteryTier_4_2.Enabled = False
        End If

        If Convert.ToInt32(LBLMastery41Score.Text) + Convert.ToInt32(LBLMastery42Score.Text) >= 5 Then
            PCBMasteryTier_5_1.ImageLocation = "G:\Final Thrust\game_data\image sources\mastery_tier_5_1.jpg"
            PCBMasteryTier_5_2.ImageLocation = "G:\Final Thrust\game_data\image sources\mastery_tier_5_2.jpg"
            PCBMasteryTier_5_1.Enabled = True
            PCBMasteryTier_5_2.Enabled = True
        Else
            PCBMasteryTier_5_1.ImageLocation = "G:\Final Thrust\game_data\image sources\mastery_tier_5_1_disabled.jpg"
            PCBMasteryTier_5_2.ImageLocation = "G:\Final Thrust\game_data\image sources\mastery_tier_5_2_disabled.jpg"
            PCBMasteryTier_5_1.Enabled = False
            PCBMasteryTier_5_2.Enabled = False
        End If

        If Convert.ToInt32(LBLMastery51Score.Text) + Convert.ToInt32(LBLMastery52Score.Text) >= 5 Then
            PCBMasteryTier_6_1.ImageLocation = "G:\Final Thrust\game_data\image sources\mastery_tier_6_1.jpg"
            PCBMasteryTier_6_1.Enabled = True
        Else
            PCBMasteryTier_6_1.ImageLocation = "G:\Final Thrust\game_data\image sources\mastery_tier_6_1_disabled.jpg"
            PCBMasteryTier_6_1.Enabled = False
        End If

    End Sub
    Public Sub save()
        'save inventory to G:\Final Thrust\player_data\player_inventory.ini
        Dim sb_inv As New System.Text.StringBuilder()
        sb_inv.AppendLine(LBLGold.Text)
        For Each o As Object In LSBInventory.Items
            sb_inv.AppendLine(o)
        Next
        System.IO.File.WriteAllText("G:\Final Thrust\player_data\player_inventory.ini", sb_inv.ToString())


        'save character data'
        Dim sb_character As New System.Text.StringBuilder
        sb_character.AppendLine(LBLCurrentHP.Text)
        sb_character.AppendLine(LBLCurrentMP.Text)
        sb_character.AppendLine(LBLExperience.Text)
        sb_character.AppendLine(LBLUnspentAttributePoints.Text)
        sb_character.AppendLine(LBLStrength.Text)
        sb_character.AppendLine(LBLDexterity.Text)
        sb_character.AppendLine(LBLConstitution.Text)
        sb_character.AppendLine(LBLIntelligence.Text)
        sb_character.AppendLine(LBLWisdom.Text)
        sb_character.AppendLine(LBLCharisma.Text)
        sb_character.AppendLine(TXTHead.Text)
        sb_character.AppendLine(TXTShoulders.Text)
        sb_character.AppendLine(TXTChest.Text)
        sb_character.AppendLine(TXTLegs.Text)
        sb_character.AppendLine(TXTBoots.Text)
        sb_character.AppendLine(TXTMainHand.Text)
        sb_character.AppendLine(TXTOffHand.Text)

        System.IO.File.WriteAllText("G:\Final Thrust\player_data\" & LBLCharacterName.Text & "_attributes.ini", sb_character.ToString())

        My.Settings.Save()
    End Sub
    Private Sub add_regen_health()

        Dim date1 As Date

        Select Case LBLCharacterName.Text

            Case "Alysha"
                date1 = Date.Parse(My.Settings.Alysha_last_played)
            Case "Makyr"
                date1 = Date.Parse(My.Settings.Makyr_last_played)
            Case "Nardina"
                date1 = Date.Parse(My.Settings.Nardina_last_played)
            Case "Nylathria"
                date1 = Date.Parse(My.Settings.Nylathria_last_played)
            Case "Sagraxes"
                date1 = Date.Parse(My.Settings.Sagraxes_last_played)
        End Select

        Dim date2 As Date = Now

        ' Determine the number of days between the two dates.
        Dim heal As Long = (DateDiff(DateInterval.Minute, date1, date2)) * 2

        If (LBLCurrentHP.Text + heal) > LBLMaxHP.Text Then
            LBLCurrentHP.Text = LBLMaxHP.Text
        Else
            LBLCurrentHP.Text += heal
        End If

        Select Case LBLCharacterName.Text
            Case "Alysha"
                My.Settings.Alysha_last_played = Now
            Case "Makyr"
                My.Settings.Makyr_last_played = Now
            Case "Nardina"
                My.Settings.Nardina_last_played = Now
            Case "Nylathria"
                My.Settings.Nylathria_last_played = Now
            Case "Sagraxes"
                My.Settings.Sagraxes_last_played = Now
        End Select
        My.Settings.Save()

    End Sub

    'MASTERIES
    Private Sub PCBMastery_MouseClick(sender As Object, e As MouseEventArgs) Handles PCBMasteryTier_6_1.MouseClick, PCBMasteryTier_5_2.MouseClick, PCBMasteryTier_5_1.MouseClick, PCBMasteryTier_4_2.MouseClick, PCBMasteryTier_4_1.MouseClick, PCBMasteryTier_3_3.MouseClick, PCBMasteryTier_3_2.MouseClick, PCBMasteryTier_3_1.MouseClick, PCBMasteryTier_2_2.MouseClick, PCBMasteryTier_2_1.MouseClick, PCBMasteryTier_1_3.MouseClick, PCBMasteryTier_1_2.MouseClick, PCBMasteryTier_1_1.MouseClick

        'CHECK IF PLAYER HAS A TOKEN
        Dim item_index As Integer = 0
        Dim has_token As Boolean = False
        For Each item In LSBInventory.Items

            If item.contains("Mastery Token") Then
                has_token = True

                Exit For
            End If
            item_index += 1
        Next

        'if player has a key, use it
        If has_token = True Then
            has_token = False
            'execute code here
            Select Case sender.name
                Case "PCBMasteryTier_1_1"
                    If LBLMastery11Score.Text < LBLMastery11MaxScore.Text.Substring(1, 1) Then
                        LBLMastery11Score.Text += 1
                    Else
                        playsound("warning", False)
                        MessageBox.Show("This mastery cannot be upgraded any more.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Case "PCBMasteryTier_1_2"
                    If LBLMastery12Score.Text < LBLMastery12MaxScore.Text.Substring(1, 1) Then
                        LBLMastery12Score.Text += 1
                    Else
                        playsound("warning", False)
                        MessageBox.Show("This mastery cannot be upgraded any more.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Case "PCBMasteryTier_1_3"
                    If LBLMastery13Score.Text < LBLMastery13MaxScore.Text.Substring(1, 1) Then
                        LBLMastery13Score.Text += 1
                    Else
                        playsound("warning", False)
                        MessageBox.Show("This mastery cannot be upgraded any more.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Case "PCBMasteryTier_2_1"
                    If LBLMastery21Score.Text < LBLMastery21MaxScore.Text.Substring(1, 1) Then
                        LBLMastery21Score.Text += 1
                    Else
                        playsound("warning", False)
                        MessageBox.Show("This mastery cannot be upgraded any more.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Case "PCBMasteryTier_2_2"
                    If LBLMastery22Score.Text < LBLMastery22MaxScore.Text.Substring(1, 1) Then
                        LBLMastery22Score.Text += 1
                        LBLUnspentAttributePoints.Text += 1
                        update_attribute_modifiers()
                    Else
                        playsound("warning", False)
                        MessageBox.Show("This mastery cannot be upgraded any more.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Case "PCBMasteryTier_3_1"
                    If LBLMastery31Score.Text < LBLMastery31MaxScore.Text.Substring(1, 1) Then
                        LBLMastery31Score.Text += 1
                    Else
                        playsound("warning", False)
                        MessageBox.Show("This mastery cannot be upgraded any more.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Case "PCBMasteryTier_3_2"
                    If LBLMastery32Score.Text < LBLMastery32MaxScore.Text.Substring(1, 1) Then
                        LBLMastery32Score.Text += 1
                    Else
                        playsound("warning", False)
                        MessageBox.Show("This mastery cannot be upgraded any more.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Case "PCBMasteryTier_3_3"
                    If LBLMastery33Score.Text < LBLMastery33MaxScore.Text.Substring(1, 1) Then
                        LBLMastery33Score.Text += 1
                    Else
                        playsound("warning", False)
                        MessageBox.Show("This mastery cannot be upgraded any more.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Case "PCBMasteryTier_4_1"
                    If LBLMastery41Score.Text < LBLMastery41MaxScore.Text.Substring(1, 1) Then
                        LBLMastery41Score.Text += 1
                    Else
                        playsound("warning", False)
                        MessageBox.Show("This mastery cannot be upgraded any more.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Case "PCBMasteryTier_4_2"
                    If LBLMastery42Score.Text < LBLMastery42MaxScore.Text.Substring(1, 1) Then
                        LBLMastery42Score.Text += 1
                    Else
                        playsound("warning", False)
                        MessageBox.Show("This mastery cannot be upgraded any more.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Case "PCBMasteryTier_5_1"
                    If LBLMastery51Score.Text < LBLMastery51MaxScore.Text.Substring(1, 1) Then
                        LBLMastery51Score.Text += 1
                    Else
                        playsound("warning", False)
                        MessageBox.Show("This mastery cannot be upgraded any more.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Case "PCBMasteryTier_5_2"
                    If LBLMastery52Score.Text < LBLMastery52MaxScore.Text.Substring(1, 1) Then
                        LBLMastery52Score.Text += 1
                    Else
                        playsound("warning", False)
                        MessageBox.Show("This mastery cannot be upgraded any more.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Case "PCBMasteryTier_6_1"
                    If LBLMastery61Score.Text < LBLMastery61MaxScore.Text.Substring(1, 1) Then
                        LBLMastery61Score.Text += 1
                    Else
                        playsound("warning", False)
                        MessageBox.Show("This mastery cannot be upgraded any more.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
            End Select

            'remove used token from player inventory
            LSBInventory.Items.RemoveAt(item_index)

            'save new mastery_string
            Dim string_builder As String
            string_builder = LBLMastery11Score.Text.Substring(0, 1) & LBLMastery12Score.Text.Substring(0, 1) & LBLMastery13Score.Text.Substring(0, 1) & LBLMastery21Score.Text.Substring(0, 1) & LBLMastery22Score.Text.Substring(0, 1) & LBLMastery31Score.Text.Substring(0, 1) & LBLMastery32Score.Text.Substring(0, 1) & LBLMastery33Score.Text.Substring(0, 1) & LBLMastery41Score.Text.Substring(0, 1) & LBLMastery42Score.Text.Substring(0, 1) & LBLMastery51Score.Text.Substring(0, 1) & LBLMastery52Score.Text.Substring(0, 1) & LBLMastery61Score.Text.Substring(0, 1)

            My.Settings.Mastery_String = string_builder
            My.Settings.Save()

            load_masteries()





        Else
            playsound("warning", False)
            MessageBox.Show("You Do Not have a mastery token.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        save()
    End Sub
    Private Sub PCBMasteryTier_MouseHover(sender As Object, e As EventArgs) Handles PCBMasteryTier_6_1.MouseHover, PCBMasteryTier_5_2.MouseHover, PCBMasteryTier_5_1.MouseHover, PCBMasteryTier_4_2.MouseHover, PCBMasteryTier_4_1.MouseHover, PCBMasteryTier_3_3.MouseHover, PCBMasteryTier_3_2.MouseHover, PCBMasteryTier_3_1.MouseHover, PCBMasteryTier_2_2.MouseHover, PCBMasteryTier_2_1.MouseHover, PCBMasteryTier_1_3.MouseHover, PCBMasteryTier_1_2.MouseHover, PCBMasteryTier_1_1.MouseHover
        Select Case sender.name
            Case "PCBMasteryTier_1_1"
                LBLMasteryTitle.Text = "Experienced"
                LBLMasteryDescription.Text = "Increase experience gained by an additional 1%."
            Case "PCBMasteryTier_1_2"
                LBLMasteryTitle.Text = "Keen Eyes"
                LBLMasteryDescription.Text = "Gain an additional 10% more gold from defeating foes."
            Case "PCBMasteryTier_1_3"
                LBLMasteryTitle.Text = "incr loot"
                LBLMasteryDescription.Text = "Increase your chance to find loot by an additional 1%."
            Case "PCBMasteryTier_2_1"
                LBLMasteryTitle.Text = "Barter"
                LBLMasteryDescription.Text = "Item sold by the shop are an additional 5% cheaper."
            Case "PCBMasteryTier_2_2"
                LBLMasteryTitle.Text = "Skillful"
                LBLMasteryDescription.Text = "Gain an extra attribute point to spend."
            Case "PCBMasteryTier_3_1"
                LBLMasteryTitle.Text = "One-Hand Specialization"
                LBLMasteryDescription.Text = "Damage dealt with one-handed weapons is increased by an additional 10%."
            Case "PCBMasteryTier_3_2"
                LBLMasteryTitle.Text = "Two-Hand Specialization"
                LBLMasteryDescription.Text = "Damage dealt with two-handed weapons is increased by an additional 10%."
            Case "PCBMasteryTier_3_3"
                LBLMasteryTitle.Text = "Shield Specialization"
                LBLMasteryDescription.Text = "Shields give an additional point of AC."
            Case "PCBMasteryTier_4_1"
                LBLMasteryTitle.Text = "Vitality"
                LBLMasteryDescription.Text = "Increase your maximum HP by an additional 20%."
            Case "PCBMasteryTier_4_2"
                LBLMasteryTitle.Text = "Vivacious"
                LBLMasteryDescription.Text = "Increase your maximum HP by an additional 20%."
            Case "PCBMasteryTier_5_1"
                LBLMasteryTitle.Text = "Head Hunter"
                LBLMasteryDescription.Text = "Increase the chance of rare foes spawning in the arena by an additional 1%."
            Case "PCBMasteryTier_5_2"
                LBLMasteryTitle.Text = "Demoralize"
                LBLMasteryDescription.Text = "Decrease the maximum HP of foes by 15%."
            Case "PCBMasteryTier_6_1"
                LBLMasteryDescription.Text = "Ascension"
                LBLMasteryDescription.Text = "Increase the attribute cap by 2 additional points."
        End Select
    End Sub
    Private Sub PCBMasteryTier_MouseLeave(sender As Object, e As EventArgs) Handles PCBMasteryTier_6_1.MouseLeave, PCBMasteryTier_5_2.MouseLeave, PCBMasteryTier_5_1.MouseLeave, PCBMasteryTier_4_2.MouseLeave, PCBMasteryTier_4_1.MouseLeave, PCBMasteryTier_3_3.MouseLeave, PCBMasteryTier_3_2.MouseLeave, PCBMasteryTier_3_1.MouseLeave, PCBMasteryTier_2_2.MouseLeave, PCBMasteryTier_2_1.MouseLeave, PCBMasteryTier_1_3.MouseLeave, PCBMasteryTier_1_2.MouseLeave, PCBMasteryTier_1_1.MouseLeave
        LBLMasteryTitle.Text = ""
        LBLMasteryDescription.Text = ""
    End Sub


    'SHOP CODE
    Private Sub LSBShopBuy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LSBShopBuy.SelectedIndexChanged
        If LSBShopBuy.SelectedItem <> "" Then
            LSBShopSell.SelectedIndex = -1
            GRBShopItemInfo.Top = LSBShopBuy.Top
            'LBLEquipmentName.Text = LSBInventory.SelectedItem
            GRBShopItemInfo.Visible = True
            GRBShopItemInfo.Text = LSBShopBuy.SelectedItem
            LBLShopItemType.Text = translate_item_data(LSBShopBuy.SelectedItem, 1, 2)
            LBLShopItemDescription.Text = Chr(34) & translate_item_data(LSBShopBuy.SelectedItem, 1, 3) & Chr(34)
            LBLShopItemAC.Text = translate_item_data(LSBShopBuy.SelectedItem, 1, 5)
            LBLShopItemDamage.Text = translate_item_data(LSBShopBuy.SelectedItem, 1, 6) & " - " & translate_item_data(LSBShopBuy.SelectedItem, 1, 7)
            PCBShopItemIcon.ImageLocation = translate_item_data(LSBShopBuy.SelectedItem, 1, 12)
            LBLShopItemExtraHealth.Text = "+ " & translate_item_data(LSBShopBuy.SelectedItem, 1, 13) & " Health"
            LBLShopItemExtraMana.Text = "+ " & translate_item_data(LSBShopBuy.SelectedItem, 1, 14) & " Mana"
            Select Case translate_item_data(LSBShopBuy.SelectedItem, 1, 4)
                Case "Legendary"
                    GRBShopItemInfo.ForeColor = Color.Orange
                Case "Epic"
                    GRBShopItemInfo.ForeColor = Color.MediumOrchid
                Case "Rare"
                    GRBShopItemInfo.ForeColor = Color.DodgerBlue
                Case "Common"
                    GRBShopItemInfo.ForeColor = Color.White
            End Select

            Dim buy_value As Decimal = ((translate_item_data(LSBShopBuy.SelectedItem, 1, 9) / 100) * (25 - (5 * LBLMastery21Score.Text)))
            LBLShopItemValue.Text = translate_item_data(LSBShopBuy.SelectedItem, 1, 9) + Math.Round(buy_value)

        Else
            GRBShopItemInfo.Visible = False
        End If


    End Sub
    Private Sub CMDBuy_Click(sender As Object, e As EventArgs) Handles CMDBuy.Click
        If vbYes = MsgBox("Are you sure you wish To purchase this item?", vbYesNo, "WARNING") Then
            If LBLGold.Text - LBLShopItemValue.Text >= 0 Then
                playsound("coin", False)
                LBLGold.Text -= LBLShopItemValue.Text
                add_item_to_inventory(LSBShopBuy.SelectedItem)
                LSBShopBuy.Items.RemoveAt(LSBShopBuy.SelectedIndex)

                'save modified shopping list, where the purchased item is removed from the list and also shop_cache
                Dim todays_date As Date = Date.Now().ToString("yyyy-MM-dd")

                Dim sb As New System.Text.StringBuilder()
                sb.AppendLine(todays_date)
                For Each o As Object In LSBShopBuy.Items
                    sb.AppendLine(o)
                Next

                System.IO.File.WriteAllText("G:\Final Thrust\game_data\shop_cache.ini", sb.ToString())

                'update inventory
                LSBShopSell.Items.Clear()

                For Each item In LSBInventory.Items
                    LSBShopSell.Items.Add(item)
                Next

            Else
                playsound("warning", False)
                MessageBox.Show("You do Not have enough gold to purchase this item!", "ERROR", MessageBoxButtons.OK)
            End If
        End If
        LBLShopGold.Text = LBLGold.Text
        save()
    End Sub
    Private Sub LSBShopSell_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LSBShopSell.SelectedIndexChanged
        If LSBShopSell.SelectedItem <> "" Then
            LSBShopBuy.SelectedIndex = -1
            GRBShopItemInfo.Top = LSBShopSell.Top
            'LBLEquipmentName.Text = LSBInventory.SelectedItem
            GRBShopItemInfo.Visible = True
            GRBShopItemInfo.Text = LSBShopSell.SelectedItem
            LBLShopItemType.Text = translate_item_data(LSBShopSell.SelectedItem, 1, 2)
            LBLShopItemDescription.Text = Chr(34) & translate_item_data(LSBShopSell.SelectedItem, 1, 3) & Chr(34)
            LBLShopItemAC.Text = translate_item_data(LSBShopSell.SelectedItem, 1, 5)
            LBLShopItemDamage.Text = translate_item_data(LSBShopSell.SelectedItem, 1, 6) & " - " & translate_item_data(LSBShopSell.SelectedItem, 1, 7)

            PCBShopItemIcon.ImageLocation = translate_item_data(LSBShopSell.SelectedItem, 1, 12)
            LBLShopItemExtraHealth.Text = "+ " & translate_item_data(LSBShopSell.SelectedItem, 1, 13) & " Health"
            LBLShopItemExtraMana.Text = "+ " & translate_item_data(LSBShopSell.SelectedItem, 1, 14) & " Mana"
            Select Case translate_item_data(LSBShopSell.SelectedItem, 1, 4)
                Case "Legendary"
                    GRBShopItemInfo.ForeColor = Color.Orange
                Case "Epic"
                    GRBShopItemInfo.ForeColor = Color.MediumOrchid
                Case "Rare"
                    GRBShopItemInfo.ForeColor = Color.DodgerBlue
                Case "Common"
                    GRBShopItemInfo.ForeColor = Color.White
            End Select

            Dim sell_value As Integer = (translate_item_data(LSBShopSell.SelectedItem, 1, 9) / 100) * 25
            LBLShopItemValue.Text = (translate_item_data(LSBShopSell.SelectedItem, 1, 9) - sell_value)

        Else
            GRBShopItemInfo.Visible = False
        End If
    End Sub
    Private Sub CMDSell_Click(sender As Object, e As EventArgs) Handles CMDSell.Click
        If LSBShopSell.SelectedItem <> "" Then
            If vbYes = MsgBox("Are you sure you wish to sell this item?", vbYesNo, "WARNING") Then
                playsound("coin", False)
                LBLGold.Text += Convert.ToInt32(LBLShopItemValue.Text)
                'remove item from inventory
                Dim item_index As Integer = 0
                For Each item In LSBInventory.Items
                    If item = LSBShopSell.SelectedItem Then
                        LSBInventory.Items.RemoveAt(item_index)
                        LSBShopBuy.Items.Add(item)
                        My.Computer.FileSystem.WriteAllText("G:\Final Thrust\game_data\shop_cache.ini", item & vbNewLine, True)
                        Exit For
                    End If
                    item_index += 1
                Next
            End If
            LSBShopSell.Items.RemoveAt(LSBShopSell.SelectedIndex)
            LBLShopGold.Text = LBLGold.Text
        End If
        save()
    End Sub


    'THE ARENA CODE
    Private Sub CMDFlee_Click(sender As Object, e As EventArgs) Handles CMDFlee.Click
        If vbYes = MsgBox("Are you sure you wish to flee from combat?", vbYesNo, "WARNING") Then
            playsound("flee", True)
            'write new arena data to character data
            LBLCurrentHP.Text = LBLArenaCurrentHP.Text
            LBLCurrentMP.Text = LBLArenaCurrentMP.Text
            Useable_items.Close()

            CMDMasteries.Enabled = True
            CMDCharacter.Enabled = True
            CMDFountain.Enabled = True
            CMDTheArena.Enabled = True
            CMDShop.Enabled = True

            CMDCharacter.PerformClick()

            TimerRegen.Start()
        End If
    End Sub
    Private Sub CMDBlock_Click(sender As Object, e As EventArgs) Handles CMDBlock.Click
        is_blocking = True
        check_round_status()
    End Sub
    Private Sub CMDUseItem_Click(sender As Object, e As EventArgs) Handles CMDUseItem.Click
        Useable_items.Show()
    End Sub
    Private Sub generate_foe()

        'load every creature in their own sub list by rarity
        Dim lineCount = File.ReadAllLines("G:\Final Thrust\game_data\foe_database.ini").Length
        Dim foe_info As StreamReader = My.Computer.FileSystem.OpenTextFileReader("G:\Final Thrust\game_data\foe_database.ini")

        Dim leg_creature_list As New List(Of String)
        Dim epic_creature_list As New List(Of String)
        Dim rare_creature_list As New List(Of String)
        Dim com_creature_list As New List(Of String)

        For index As Integer = 0 To (lineCount - 1)
            'Dim check_String As String = foe_info.ReadLine
            Dim check_string = foe_info.ReadLine
            Dim parts() As String = check_string.Split(",")

            If parts(2).ToLower = "legendary" Then
                leg_creature_list.Add(check_string)

            ElseIf parts(2).ToLower = "epic" Then
                epic_creature_list.Add(check_string)

            ElseIf parts(2).ToLower = "rare" Then
                rare_creature_list.Add(check_string)

            Else 'common
                com_creature_list.Add(check_string)

            End If
        Next

        ' determine how many creatures to spawn (1 for every 4 levels)
        Dim amount_of_foes As Integer = Math.Ceiling(LBLLevel.Text / 4)

        For amount_foes As Integer = 1 To amount_of_foes

            Dim rarity_RNG As Decimal = (Int((100 * Rnd()) + 1)) + LBLMastery51Score.Text
            'Dim rarity_RNG As Integer = Int((2 * Rnd()) + 1) 'enable this to only spawn legendary foes
            Dim disposable_string As String = ""
            Dim creature_rng As Integer = 0
            Dim foe_name As String = ""
            Dim foe_imagelocation As String = ""
            Dim foe_hp As Integer = (Int((120 * Rnd()) + 80)) + ((LBLLevel.Text * 15) - 20)
            Dim mastery_decrease_foe_hp As Integer = ((foe_hp / 100) * 15) * LBLMastery52Score.Text
            foe_hp -= mastery_decrease_foe_hp
            Dim rarity As String = ""

            If rarity_RNG >= 100 Then
                creature_rng = Int((leg_creature_list.Count * Rnd()) + 0)

                For index As Integer = 0 To (leg_creature_list.Count - 1)
                    disposable_string = leg_creature_list(index)
                    If index = creature_rng Then

                        Dim parts() As String = disposable_string.Split(",")
                        foe_name = parts(0)
                        foe_imagelocation = parts(1)
                        foe_hp = foe_hp * 3 'in case of epic creature, multiply hp by 3
                    End If
                Next
                rarity = "legendary"


            ElseIf rarity_RNG >= 90 Then
                creature_rng = Int((epic_creature_list.Count * Rnd()) + 0)

                For index As Integer = 0 To (epic_creature_list.Count - 1)
                    disposable_string = epic_creature_list(index)
                    If index = creature_rng Then

                        Dim parts() As String = disposable_string.Split(",")
                        foe_name = parts(0)
                        foe_imagelocation = parts(1)
                        foe_hp = foe_hp * 2 'in case of epic creature, multiply hp by 2
                    End If
                Next
                rarity = "epic"


            ElseIf rarity_RNG >= 70 Then
                creature_rng = Int((rare_creature_list.Count * Rnd()) + 0)

                For index As Integer = 0 To (rare_creature_list.Count - 1)
                    disposable_string = rare_creature_list(index)
                    If index = creature_rng Then

                        Dim parts() As String = disposable_string.Split(",")
                        foe_name = parts(0)
                        foe_imagelocation = parts(1)
                        foe_hp = Math.Floor((foe_hp * 15) / 10) 'in case of rare creature, multiply hp by 1.5
                    End If
                Next
                rarity = "rare"









            Else
                creature_rng = Int((com_creature_list.Count * Rnd()) + 0)

                For index As Integer = 0 To (com_creature_list.Count - 1)
                    disposable_string = com_creature_list(index)
                    If index = creature_rng Then

                        Dim parts() As String = disposable_string.Split(",")
                        foe_name = parts(0)
                        foe_imagelocation = parts(1)

                    End If
                Next
                rarity = "common"











            End If

            'generate foe stats

            If amount_foes = 1 Then
                LBLArenaFoe1Name.Text = foe_name
                PCBArenaFoe1Avatar.ImageLocation = foe_imagelocation
                If foe_name = "Tyrande Whisperwind" Then 'give tyrande 10 times the health of a legendary creature
                    LBLArenaFoe1MaxHP.Text = (foe_hp * 10)
                Else
                    LBLArenaFoe1MaxHP.Text = foe_hp
                End If
                LBLArenaFoe1CurrentHP.Text = LBLArenaFoe1MaxHP.Text
                PGBFoe1HP.Maximum = LBLArenaFoe1MaxHP.Text
                PGBFoe1HP.Value = LBLArenaFoe1CurrentHP.Text
                GRBFoe1.Visible = True
                Select Case rarity
                    Case "legendary"
                        LBLArenaFoe1Border.BackColor = Color.Orange
                    Case "epic"
                        LBLArenaFoe1Border.BackColor = Color.Purple
                    Case "rare"
                        LBLArenaFoe1Border.BackColor = Color.Blue
                    Case "common"
                        LBLArenaFoe1Border.BackColor = Color.White
                End Select

            End If
            If amount_foes = 2 Then
                LBLArenaFoe2Name.Text = foe_name
                PCBArenaFoe2Avatar.ImageLocation = foe_imagelocation
                LBLArenaFoe2MaxHP.Text = foe_hp
                LBLArenaFoe2CurrentHP.Text = LBLArenaFoe2MaxHP.Text
                PGBFoe2HP.Maximum = LBLArenaFoe2MaxHP.Text
                PGBFoe2HP.Value = LBLArenaFoe2CurrentHP.Text
                GRBFoe2.Visible = True
                Select Case rarity
                    Case "legendary"
                        LBLArenaFoe2Border.BackColor = Color.Orange
                    Case "epic"
                        LBLArenaFoe2Border.BackColor = Color.Purple
                    Case "rare"
                        LBLArenaFoe2Border.BackColor = Color.Blue
                    Case "common"
                        LBLArenaFoe2Border.BackColor = Color.White
                End Select
            End If
            If amount_foes = 3 Then
                LBLArenaFoe3Name.Text = foe_name
                PCBArenaFoe3Avatar.ImageLocation = foe_imagelocation
                LBLArenaFoe3MaxHP.Text = foe_hp
                LBLArenaFoe3CurrentHP.Text = LBLArenaFoe3MaxHP.Text
                PGBFoe3HP.Maximum = LBLArenaFoe3MaxHP.Text
                PGBFoe3HP.Value = LBLArenaFoe3CurrentHP.Text
                GRBFoe3.Visible = True
                Select Case rarity
                    Case "legendary"
                        LBLArenaFoe3Border.BackColor = Color.Orange
                    Case "epic"
                        LBLArenaFoe3Border.BackColor = Color.Purple
                    Case "rare"
                        LBLArenaFoe3Border.BackColor = Color.Blue
                    Case "common"
                        LBLArenaFoe3Border.BackColor = Color.White
                End Select
            End If
            If amount_foes = 4 Then
                LBLArenaFoe4Name.Text = foe_name
                PCBArenaFoe4Avatar.ImageLocation = foe_imagelocation
                LBLArenaFoe4MaxHP.Text = foe_hp
                LBLArenaFoe4CurrentHP.Text = LBLArenaFoe4MaxHP.Text
                PGBFoe4HP.Maximum = LBLArenaFoe4MaxHP.Text
                PGBFoe4HP.Value = LBLArenaFoe4CurrentHP.Text
                GRBFoe4.Visible = True
                Select Case rarity
                    Case "legendary"
                        LBLArenaFoe4Border.BackColor = Color.Orange
                    Case "epic"
                        LBLArenaFoe4Border.BackColor = Color.Purple
                    Case "rare"
                        LBLArenaFoe4Border.BackColor = Color.Blue
                    Case "common"
                        LBLArenaFoe4Border.BackColor = Color.White
                End Select
            End If
            If amount_foes = 5 Then
                LBLArenaFoe5Name.Text = foe_name
                PCBArenaFoe5Avatar.ImageLocation = foe_imagelocation
                LBLArenaFoe5MaxHP.Text = foe_hp
                LBLArenaFoe5CurrentHP.Text = LBLArenaFoe5MaxHP.Text
                PGBFoe5HP.Maximum = LBLArenaFoe5MaxHP.Text
                PGBFoe5HP.Value = LBLArenaFoe5CurrentHP.Text
                GRBFoe5.Visible = True
                Select Case rarity
                    Case "legendary"
                        LBLArenaFoe5Border.BackColor = Color.Orange
                    Case "epic"
                        LBLArenaFoe5Border.BackColor = Color.Purple
                    Case "rare"
                        LBLArenaFoe5Border.BackColor = Color.Blue
                    Case "common"
                        LBLArenaFoe5Border.BackColor = Color.White
                End Select
            End If

        Next

        If (LBLArenaFoe1Border.BackColor = Color.Orange) Or (LBLArenaFoe2Border.BackColor = Color.Orange) Or (LBLArenaFoe3Border.BackColor = Color.Orange) Or (LBLArenaFoe4Border.BackColor = Color.Orange) Or (LBLArenaFoe5Border.BackColor = Color.Orange) Then
            'LBLTimePlaying.Text = VideoPlayer.Ctlcontrols.currentPosition.ToString
            'TCBDuration.Value = CInt(VideoPlayer.Ctlcontrols.currentPosition)
            music_arena_position = music_player.Ctlcontrols.currentPosition.ToString
            music_player.URL = "G:\Final Thrust\game_data\sfx\music_legendaryarena.mp3"
            music_player.Ctlcontrols.play()
        Else
            'check if music is already playing
            If music_player.URL = "G:\Final Thrust\game_data\sfx\music_arena.mp3" = False Then
                music_player.URL = "G:\Final Thrust\game_data\sfx\music_arena.mp3"
                music_player.Ctlcontrols.currentPosition = music_arena_position
                music_player.Ctlcontrols.play()
            End If
        End If
    End Sub
    Private Sub PCBArenaFoeAvatar_Click(sender As Object, e As EventArgs) Handles PCBArenaFoe1Avatar.Click, PCBArenaFoe2Avatar.Click, PCBArenaFoe3Avatar.Click, PCBArenaFoe4Avatar.Click, PCBArenaFoe5Avatar.Click
        attack_foe(sender.name)
    End Sub
    Private Sub attack_foe(foe_no As String)

        'check if attack hits
        Randomize()
        Dim hit_RNG As Integer = Int((100 * Rnd()) + 1) 'generate random number between 1 and 100
        If hit_RNG <= (30 - ((LBLCharismaMod.Text * 2) - total_extra_hc)) Then 'if RNG is equal or below 20 - (charisma mod * 4) the attack misses., if charisma is +5 the generated number needs to be equal or below 0 zero which is impossible so the attacks auto-hit
            TXTCombatLog.Text = "Your attack missed." & vbCrLf & vbCrLf & TXTCombatLog.Text
            playsound("miss", False)
        Else

            Dim crit_modifier As Integer = 1
            'generate damage
            'check for crit
            If (hit_RNG >= (100 - (LBLDexterityMod.Text * 4) - total_extra_cc)) Then
                crit_modifier = 2
                playsound("crit", False)
            Else
                crit_modifier = 1
                playsound("swing", False)
            End If

            Dim mh_mastery_damage As Integer = 0

            Select Case translate_item_data(TXTMainHand.Text, 1, 2) 'get main hand weapon type
                Case "1H"
                    mh_mastery_damage = (translate_item_data(TXTMainHand.Text, 1, 7) / 100) * 10
                    mh_mastery_damage = mh_mastery_damage * LBLMastery31Score.Text
                Case "2H"
                    mh_mastery_damage = (translate_item_data(TXTMainHand.Text, 1, 7) / 100) * 10
                    mh_mastery_damage = mh_mastery_damage * LBLMastery32Score.Text
            End Select

            Dim oh_mastery_damage As Integer = 0

            If TXTOffHand.Text <> "" Then
                Select Case translate_item_data(TXTOffHand.Text, 1, 2) 'get off hand weapon type
                    Case "1H"
                        oh_mastery_damage = (translate_item_data(TXTMainHand.Text, 1, 7) / 100) * 10
                        oh_mastery_damage = oh_mastery_damage * LBLMastery31Score.Text
                End Select
            End If

            'generate random number between the weapon's minimum and maximum damage value
            Randomize()
            Dim dmg_RNG As Integer = crit_modifier * ((Int((damage_max - damage_min + 1) * Rnd() + damage_min)) + (mh_mastery_damage + oh_mastery_damage))

            If foe_no = "PCBArenaFoe1Avatar" Then
                If crit_modifier = 2 Then
                    TXTCombatLog.Text = "You CRITICALLY hit " & LBLArenaFoe1Name.Text & " for " & dmg_RNG & " damage." & vbCrLf & vbCrLf & TXTCombatLog.Text
                Else
                    TXTCombatLog.Text = "You hit " & LBLArenaFoe1Name.Text & " for " & dmg_RNG & " damage." & vbCrLf & vbCrLf & TXTCombatLog.Text
                End If
                If (LBLArenaFoe1CurrentHP.Text - dmg_RNG) <= 0 Then
                    foe_death(1, LBLArenaFoe1Border.BackColor)
                Else
                    LBLArenaFoe1CurrentHP.Text -= dmg_RNG
                End If

            ElseIf foe_no = "PCBArenaFoe2Avatar" Then
                If crit_modifier = 2 Then
                    TXTCombatLog.Text = "You CRITICALLY hit " & LBLArenaFoe2Name.Text & " for " & dmg_RNG & " damage." & vbCrLf & vbCrLf & TXTCombatLog.Text
                Else
                    TXTCombatLog.Text = "You hit " & LBLArenaFoe2Name.Text & " for " & dmg_RNG & " damage." & vbCrLf & vbCrLf & TXTCombatLog.Text
                End If
                If (LBLArenaFoe2CurrentHP.Text - dmg_RNG) <= 0 Then
                    foe_death(2, LBLArenaFoe2Border.BackColor)
                Else
                    LBLArenaFoe2CurrentHP.Text -= dmg_RNG
                End If

            ElseIf foe_no = "PCBArenaFoe3Avatar" Then
                If crit_modifier = 2 Then
                    TXTCombatLog.Text = "You CRITICALLY hit " & LBLArenaFoe3Name.Text & " for " & dmg_RNG & " damage." & vbCrLf & vbCrLf & TXTCombatLog.Text
                Else
                    TXTCombatLog.Text = "You hit " & LBLArenaFoe3Name.Text & " for " & dmg_RNG & " damage." & vbCrLf & vbCrLf & TXTCombatLog.Text
                End If
                If (LBLArenaFoe3CurrentHP.Text - dmg_RNG) <= 0 Then
                    foe_death(3, LBLArenaFoe3Border.BackColor)
                Else
                    LBLArenaFoe3CurrentHP.Text -= dmg_RNG
                End If

            ElseIf foe_no = "PCBArenaFoe4Avatar" Then
                If crit_modifier = 2 Then
                    TXTCombatLog.Text = "You CRITICALLY hit " & LBLArenaFoe4Name.Text & " for " & dmg_RNG & " damage." & vbCrLf & vbCrLf & TXTCombatLog.Text
                Else
                    TXTCombatLog.Text = "You hit " & LBLArenaFoe4Name.Text & " for " & dmg_RNG & " damage." & vbCrLf & vbCrLf & TXTCombatLog.Text
                End If
                If (LBLArenaFoe4CurrentHP.Text - dmg_RNG) <= 0 Then
                    foe_death(4, LBLArenaFoe4Border.BackColor)
                Else
                    LBLArenaFoe4CurrentHP.Text -= dmg_RNG
                End If

            ElseIf foe_no = "PCBArenaFoe5Avatar" Then
                If crit_modifier = 2 Then
                    TXTCombatLog.Text = "You CRITICALLY hit " & LBLArenaFoe5Name.Text & " for " & dmg_RNG & " damage." & vbCrLf & vbCrLf & TXTCombatLog.Text
                Else
                    TXTCombatLog.Text = "You hit " & LBLArenaFoe5Name.Text & " for " & dmg_RNG & " damage." & vbCrLf & vbCrLf & TXTCombatLog.Text
                End If
                If (LBLArenaFoe5CurrentHP.Text - dmg_RNG) <= 0 Then
                    foe_death(5, LBLArenaFoe5Border.BackColor)
                Else
                    LBLArenaFoe5CurrentHP.Text -= dmg_RNG
                End If
            End If
        End If

        check_round_status()

    End Sub
    Private Sub foe_turn()
        'NOTE ABOUT FOE TURN


        'ESSENTIALLY, ALL FOES HIT THE PLAYER AT THE SAME TIME AND AN AVERAGE IS CALCULATED
        Dim which_foes_turn_name As String = LBLArenaFoe1Name.Text
        Dim foe_cap As Integer = Math.Ceiling(LBLLevel.Text / 4)


        If foe_turn_index = 1 Then
            If (GRBFoe1.Visible = True) Then
                which_foes_turn_name = LBLArenaFoe1Name.Text
            Else 'skip dead foe's turn
                If foe_turn_index <= foe_cap Then
                    foe_turn_index += 1
                Else
                    foe_turn_index = 1
                    Exit Sub
                End If
            End If
        End If

        If foe_turn_index = 2 Then
            If (GRBFoe2.Visible = True) Then
                which_foes_turn_name = LBLArenaFoe2Name.Text
            Else 'skip dead foe's turn
                If foe_turn_index <= foe_cap Then
                    foe_turn_index += 1
                Else
                    foe_turn_index = 1
                    Exit Sub
                End If
            End If
        End If
        If foe_turn_index = 3 Then
            If (GRBFoe3.Visible = True) Then
                which_foes_turn_name = LBLArenaFoe3Name.Text
            Else 'skip dead foe's turn
                If foe_turn_index <= foe_cap Then
                    foe_turn_index += 1
                Else
                    foe_turn_index = 1
                    Exit Sub
                End If
            End If
        End If
        If foe_turn_index = 4 Then
            If (GRBFoe4.Visible = True) Then
                which_foes_turn_name = LBLArenaFoe4Name.Text
            Else 'skip dead foe's turn
                If foe_turn_index <= foe_cap Then
                    foe_turn_index += 1
                Else
                    foe_turn_index = 1
                    Exit Sub
                End If
            End If
        End If
        If foe_turn_index = 5 Then
            If (GRBFoe5.Visible = True) Then
                which_foes_turn_name = LBLArenaFoe5Name.Text
            Else 'skip dead foe's turn
                foe_turn_index = 1
                Exit Sub
            End If
        End If


        Dim crit_multiplier As Integer = 1
        Dim damage As Integer = 0

        'check if attack hits player
        Randomize()
        Dim hit_RNG As Integer = Int((20 * Rnd()) + 1) 'generate random number between 1 and 20




        If hit_RNG = 20 Then
            crit_multiplier = 2
        Else
            crit_multiplier = 1
        End If


        If (hit_RNG + LBLLevel.Text) > LBLarmorclass.Text Then
            'damage calculation
            If is_blocking = True Then
                playsound("block", False)
                is_blocking = False
                damage = Math.Floor(((5 + Math.Floor(LBLLevel.Text / 2)) * crit_multiplier) / 100) * 20
                TXTCombatLog.Text = which_foes_turn_name & "'s attack was blocked and you took " & damage & " damage." & vbCrLf & vbCrLf & TXTCombatLog.Text
            Else
                damage = (5 + Math.Floor(LBLLevel.Text / 2)) * crit_multiplier
                If crit_multiplier > 1 Then
                    playsound("_Wound", False)
                    TXTCombatLog.Text = which_foes_turn_name & "'s attack dealt " & damage & " CRITICAL damage." & vbCrLf & vbCrLf & TXTCombatLog.Text
                Else
                    TXTCombatLog.Text = which_foes_turn_name & "'s attack dealt " & damage & " damage." & vbCrLf & vbCrLf & TXTCombatLog.Text
                End If


            End If


            If (LBLArenaCurrentHP.Text - damage) <= 0 Then

                playsound("_Death", False)

                'character defeated
                LBLArenaCurrentHP.Text = 0
                PGBPlayerHP.Value = LBLArenaCurrentHP.Text
                music_player.Ctlcontrols.stop()
                TXTCombatLog.Text = LBLCharacterName.Text & " has been defeated!" & vbCrLf & vbCrLf & TXTCombatLog.Text
                MessageBox.Show(LBLCharacterName.Text & " has been defeated!" & vbCrLf & vbCrLf & "Leaving the arena now.", "RIP", MessageBoxButtons.OK)
                PCBAvatar.ImageLocation = "G:\Final Thrust\game_data\game_characters\" & LBLCharacterName.Text & "\" & LBLCharacterName.Text & "_Death.png"


                'write new arena data to character data
                LBLCurrentHP.Text = LBLArenaCurrentHP.Text
                LBLCurrentMP.Text = LBLArenaCurrentMP.Text
                Useable_items.Close()
                CMDCharacter.Enabled = True
                CMDFountain.Enabled = True
                CMDTheArena.Enabled = True
                CMDShop.Enabled = True
                playsound("defeat", True)
                CMDCharacter.PerformClick()

            Else
                LBLArenaCurrentHP.Text -= damage
                PGBPlayerHP.Value = LBLArenaCurrentHP.Text
            End If




        Else
            TXTCombatLog.Text = which_foes_turn_name & "'s attack missed!" & vbCrLf & vbCrLf & TXTCombatLog.Text
        End If


        foe_turn_index += 1



    End Sub
    Public Sub check_round_status()

        turn_counter += 1
        LBLTurnCounter.Text = "Round: " & turn_counter

        PGBPlayerHP.Value = LBLArenaCurrentHP.Text
        PGBPlayerMP.Value = LBLArenaCurrentMP.Text
        PGBFoe1HP.Value = LBLArenaFoe1CurrentHP.Text
        PGBFoe2HP.Value = LBLArenaFoe2CurrentHP.Text
        PGBFoe3HP.Value = LBLArenaFoe3CurrentHP.Text
        PGBFoe4HP.Value = LBLArenaFoe4CurrentHP.Text
        PGBFoe5HP.Value = LBLArenaFoe5CurrentHP.Text

        'handle skill CDs
        If alysha_skill_1_CD <> 0 Then
            If alysha_skill_1_CD <= (turn_counter - 2) Then '1 turn cooldown on Alysha Skill 1
                CMDAlyshaSkill1.Enabled = True
                CMDAlyshaSkill1.Text = ""
            End If
        End If

        If alysha_skill_2_CD <> 0 Then
            If alysha_skill_2_CD <= (turn_counter - 6) Then '5 turn cooldown on Alysha Skill 2
                CMDAlyshaSkill2.Enabled = True
                CMDAlyshaSkill2.Text = ""
            End If
        End If

        If alysha_skill_3_CD <> 0 Then
            If alysha_skill_3_CD <= (turn_counter - 6) Then '5 turn cooldown on Alysha Skill 3
                CMDAlyshaSkill3.Enabled = True
                CMDAlyshaSkill3.Text = ""
            End If
        End If

        If alysha_skill_4_CD <> 0 Then
            If alysha_skill_4_CD <= (turn_counter - 3) Then '2 turn cooldown on Alysha Skill 4
                CMDAlyshaSkill4.Enabled = True
                CMDAlyshaSkill4.Text = ""
            End If
        End If

        If alysha_skill_5_CD <> 0 Then
            If alysha_skill_5_CD <= (turn_counter - 6) Then '5 turn cooldown on Alysha Skill 5
                CMDAlyshaSkill5.Enabled = True
                CMDAlyshaSkill5.Text = ""
            End If
        End If

        If makyr_skill_1_CD <> 0 Then
            If makyr_skill_1_CD <= (turn_counter - 4) Then '3 turn cooldown on Makyr Skill 1
                CMDMakyrSkill1.Enabled = True
                CMDMakyrSkill1.Text = ""
            End If
        End If

        If makyr_skill_2_CD <> 0 Then
            If makyr_skill_2_CD <= (turn_counter - 6) Then '5 turn cooldown on Makyr Skill 2
                CMDMakyrSkill2.Enabled = True
                CMDMakyrSkill2.Text = ""
            End If
        End If

        If makyr_skill_3_CD <> 0 Then
            If makyr_skill_3_CD <= (turn_counter - 5) Then '4 turn cooldown on Makyr Skill 3
                CMDMakyrSkill3.Enabled = True
                CMDMakyrSkill3.Text = ""
            End If
        End If

        If makyr_skill_4_CD <> 0 Then
            If makyr_skill_4_CD <= (turn_counter - 6) Then '5 turn cooldown on Makyr Skill 4
                CMDMakyrSkill4.Enabled = True
                CMDMakyrSkill4.Text = ""
            End If
        End If

        If makyr_skill_5_CD <> 0 Then
            If makyr_skill_5_CD <= (turn_counter - 3) Then '2 turn cooldown on Makyr Skill 5
                CMDMakyrSkill5.Enabled = True
                CMDMakyrSkill5.Text = ""
            End If
        End If

        If nardina_skill_1_CD <> 0 Then
            If nardina_skill_1_CD <= (turn_counter - 5) Then '4 turn cooldown on Nardina Skill 1
                CMDNardinaSkill1.Enabled = True
                CMDNardinaSkill1.Text = ""
            End If
        End If

        If nardina_skill_2_CD <> 0 Then
            If nardina_skill_2_CD <= (turn_counter - 6) Then '5 turn cooldown on Nardina Skill 2
                CMDNardinaSkill2.Enabled = True
                CMDNardinaSkill2.Text = ""
            End If
        End If

        If nardina_skill_3_CD <> 0 Then
            If nardina_skill_3_CD <= (turn_counter - 7) Then '6 turn cooldown on Nardina Skill 3
                CMDNardinaSkill3.Enabled = True
                CMDNardinaSkill3.Text = ""
            End If
        End If

        If nardina_skill_4_CD <> 0 Then
            If nardina_skill_4_CD <= (turn_counter - 7) Then '6 turn cooldown on Nardina Skill 4
                CMDNardinaSkill4.Enabled = True
                CMDNardinaSkill4.Text = ""
            End If
        End If

        If nardina_skill_5_CD <> 0 Then
            If nardina_skill_5_CD <= (turn_counter - 11) Then '11 turn cooldown on Nardina Skill 5
                CMDNardinaSkill5.Enabled = True
                CMDNardinaSkill5.Text = ""
            End If
        End If

        If nylathria_skill_1_CD <> 0 Then
            If nylathria_skill_1_CD <= (turn_counter - 4) Then '3 turn cooldown on Nylthatira Skill 1
                CMDNylathriaSkill1.Enabled = True
                CMDNylathriaSkill1.Text = ""
            End If
        End If

        If nylathria_skill_2_CD <> 0 Then
            If nylathria_skill_2_CD <= (turn_counter - 5) Then '4 turn cooldown on Nylthatira Skill 2
                CMDNylathriaSkill2.Enabled = True
                CMDNylathriaSkill2.Text = ""
            End If
        End If

        If nylathria_skill_3_CD <> 0 Then
            If nylathria_skill_3_CD <= (turn_counter - 6) Then '5 turn cooldown on Nylthatira Skill 3
                CMDNylathriaSkill3.Enabled = True
                CMDNylathriaSkill3.Text = ""
            End If
        End If

        If nylathria_skill_4_CD <> 0 Then
            If nylathria_skill_4_CD <= (turn_counter - 2) Then '1 turn cooldown on Nylthatira Skill 4
                CMDNylathriaSkill4.Enabled = True
                CMDNylathriaSkill4.Text = ""
            End If
        End If

        If nylathria_skill_5_CD <> 0 Then
            If nylathria_skill_5_CD <= (turn_counter - 3) Then '2 turn cooldown on Nylathria Skill 5
                CMDNylathriaSkill5.Enabled = True
                CMDNylathriaSkill5.Text = ""
            End If
        End If
        If sagraxes_skill_1_CD <> 0 Then
            If sagraxes_skill_1_CD <= (turn_counter - 4) Then '3 turn cooldown on Sagraxes Skill 1
                CMDSagraxesSkill1.Enabled = True
                CMDSagraxesSkill1.Text = ""
            End If
        End If

        If sagraxes_skill_2_CD <> 0 Then
            If sagraxes_skill_2_CD <= (turn_counter - 3) Then '2 turn cooldown on Sagraxes Skill 2
                CMDSagraxesSkill2.Enabled = True
                CMDSagraxesSkill2.Text = ""
            End If
        End If

        If sagraxes_skill_3_CD <> 0 Then
            If sagraxes_skill_3_CD <= (turn_counter - 4) Then '3 turn cooldown on Sagraxes Skill 3
                CMDSagraxesSkill3.Enabled = True
                CMDSagraxesSkill3.Text = ""
            End If
        End If

        If sagraxes_skill_4_CD <> 0 Then
            If sagraxes_skill_4_CD <= (turn_counter - 4) Then '3 turn cooldown on Sagraxes Skill 4
                CMDSagraxesSkill4.Enabled = True
                CMDSagraxesSkill4.Text = ""
            End If
        End If

        If sagraxes_skill_5_CD <> 0 Then
            If sagraxes_skill_5_CD <= (turn_counter - 3) Then '2 turn cooldown on Sagraxes Skill 5
                CMDSagraxesSkill5.Enabled = True
                CMDSagraxesSkill5.Text = ""
            End If
        End If


        If (GRBFoe1.Visible = False) And (GRBFoe2.Visible = False) And (GRBFoe3.Visible = False) And (GRBFoe4.Visible = False) And (GRBFoe5.Visible = False) Then
            'NEW ROUND

            'restore some HP & MP here
            If (LBLArenaCurrentHP.Text + (Convert.ToInt32(LBLConstitutionMod.Text)) + 5) > LBLArenaMaxHP.Text Then
                LBLArenaCurrentHP.Text = LBLArenaMaxHP.Text
            Else
                LBLArenaCurrentHP.Text = LBLArenaCurrentHP.Text + Convert.ToInt32(LBLConstitutionMod.Text) + 5
            End If

            If (LBLArenaCurrentMP.Text + (Convert.ToInt32(LBLIntelligenceMod.Text)) + 5) > LBLArenaMaxMP.Text Then
                LBLArenaCurrentMP.Text = LBLArenaMaxMP.Text
            Else
                LBLArenaCurrentMP.Text += Convert.ToInt32(LBLIntelligenceMod.Text) + 5
            End If


            generate_foe()
        Else
            foe_turn()
        End If
    End Sub
    Private Sub foe_death(foe_index As Integer, foe_rarity As Color)
        'calculate & give experience
        Dim rarity_modifier As Integer
        Dim foe_name As String = ""

        Select Case foe_index
            Case 1
                foe_name = LBLArenaFoe1Name.Text
                LBLArenaFoe1CurrentHP.Text = 0
                GRBFoe1.Visible = False
                playsound("foedefeat", False)
            Case 2
                foe_name = LBLArenaFoe2Name.Text
                LBLArenaFoe2CurrentHP.Text = 0
                GRBFoe2.Visible = False
                playsound("foedefeat", False)
            Case 3
                foe_name = LBLArenaFoe3Name.Text
                LBLArenaFoe3CurrentHP.Text = 0
                GRBFoe3.Visible = False
                playsound("foedefeat", False)
            Case 4
                foe_name = LBLArenaFoe4Name.Text
                LBLArenaFoe4CurrentHP.Text = 0
                GRBFoe4.Visible = False
                playsound("foedefeat", False)
            Case 5
                foe_name = LBLArenaFoe5Name.Text
                LBLArenaFoe5CurrentHP.Text = 0
                GRBFoe5.Visible = False
                playsound("foedefeat", False)
        End Select

        If foe_rarity = Color.White Then
            rarity_modifier = 1
        ElseIf foe_rarity = Color.Blue Then
            rarity_modifier = 2
        ElseIf foe_rarity = Color.Purple Then
            rarity_modifier = 3
        ElseIf foe_rarity = Color.Orange Then
            rarity_modifier = 5
        End If

        TXTCombatLog.Text = foe_name & " defeated." & vbCrLf & vbCrLf & TXTCombatLog.Text

        If foe_name = "Tyrande Whisperwind" Then
            add_item_to_inventory("Glowing Key")
            TXTCombatLog.Text = "You received A GLOWING KEY!" & vbCrLf & vbCrLf & TXTCombatLog.Text
        Else
            'decide if foe drops loot
            Randomize()
            Dim drop_chance_RNG As Integer = Int(((100) * Rnd()) + 1) 'generate random number between 1 and 100
            Select Case rarity_modifier
                Case 1 'common
                    drop_chance_RNG += 0
                Case 2 'rare
                    drop_chance_RNG += 10
                Case 3 'epic
                    drop_chance_RNG += 40
                Case 5 'legendary
                    drop_chance_RNG += 99 'prevent second piece of loot
            End Select

            'add mastery, 1% chance for each point spent
            drop_chance_RNG += LBLMastery13Score.Text

            If drop_chance_RNG >= 100 Then 'if player gets loot


                'GENERATE LOOT
                Dim loot_table As StreamReader = My.Computer.FileSystem.OpenTextFileReader("G:\Final Thrust\game_data\item_database.ini")
                Dim loot_table_count = File.ReadAllLines("G:\Final Thrust\game_data\item_database.ini").Length

                'create seperate list of all lootable items
                Dim lootable_items As New List(Of String)

                For index As Integer = 0 To (loot_table_count - 1)
                    Dim check_string = loot_table.ReadLine

                    Dim get_item_name As String = translate_item_data(check_string, -1, 1)
                    Dim get_item_lootable As Integer = translate_item_data(check_string, -1, 10)
                    Dim get_item_loot_tier As Integer = translate_item_data(check_string, -1, 11)

                    'IF RARITY MOD = 5 (LEGENDARY) THAN ONLY ADD TITAN AFFIX ITEMS TO THE LIST AND GIVE A RANDOM TITAN AFFIX ITEM
                    If rarity_modifier = 5 Then
                        If get_item_name.Contains("Titan ") Then
                            lootable_items.Add(get_item_name)
                        End If
                    Else
                        'calculate correct loot tier
                        Dim loot_tier As Integer = 0

                        If LBLLevel.Text < 6 Then
                            loot_tier = 1
                        ElseIf LBLLevel.Text < 11 Then
                            loot_tier = 2
                        ElseIf LBLLevel.Text < 16 Then
                            loot_tier = 3
                        Else
                            loot_tier = 4
                        End If
                        'check part 11 if item is lootable
                        If get_item_lootable = 1 Then
                            'check part 12 to add correct loot_tier
                            If get_item_loot_tier <= loot_tier Then
                                lootable_items.Add(get_item_name)
                            End If
                        End If
                    End If

                Next
                Randomize()

                Dim item_RNG As Integer = Int(((lootable_items.Count - 1) * Rnd()) + 0) 'generate random number between 0 and list bounds
                'add to inventory
                add_item_to_inventory(lootable_items(item_RNG))

                TXTCombatLog.Text = "You received " & lootable_items(item_RNG) & "!" & vbCrLf & vbCrLf & TXTCombatLog.Text
            End If
        End If

        'generate lootable gold
        Randomize()
        Dim gold_RNG As Integer = Int(((20) * Rnd()) + 1) 'generate random number between 1 and 20
        Dim looted_gold As Integer = gold_RNG + Convert.ToInt32(LBLLevel.Text * 10) * rarity_modifier
        Dim experience As Integer = (50 + (LBLLevel.Text * 10)) * rarity_modifier

        looted_gold = looted_gold + ((looted_gold / 100 * (LBLMastery12Score.Text * 10)))
        experience = experience + ((experience / 100) * LBLMastery11Score.Text)

        gain_xp(experience)
        LBLGold.Text += looted_gold

        TXTCombatLog.Text = "You gained " & experience & " experience!" & vbCrLf & vbCrLf & TXTCombatLog.Text
        TXTCombatLog.Text = looted_gold & " gold received!" & vbCrLf & vbCrLf & TXTCombatLog.Text
    End Sub
    Private Sub CHBHideCombatLog_CheckedChanged(sender As Object, e As EventArgs) Handles CHBHideCombatLog.CheckedChanged
        If CHBHideCombatLog.Checked = True Then
            TXTCombatLog.Visible = False
        Else
            TXTCombatLog.Visible = True
        End If
    End Sub
    Private Function damage_target(damage As Integer, target As String)
        'FOR RANDOM TARGET, SET TARGET TO -1

        If target = -1 Then
            'Create list of all valid targets
            Dim valid_targets As New List(Of Integer)

            If GRBFoe1.Visible = True Then
                valid_targets.Add(1)
            End If
            If GRBFoe2.Visible = True Then
                valid_targets.Add(2)
            End If
            If GRBFoe3.Visible = True Then
                valid_targets.Add(3)
            End If
            If GRBFoe4.Visible = True Then
                valid_targets.Add(4)
            End If
            If GRBFoe5.Visible = True Then
                valid_targets.Add(5)
            End If

            'Pick a random foe from all valid foes
            Randomize()
            Dim target_RNG As Integer = Int(((valid_targets.Count - 1) * Rnd()) + 0)

            Select Case valid_targets(target_RNG)
                Case 1
                    If GRBFoe1.Visible = True Then
                        If (LBLArenaFoe1CurrentHP.Text - damage) <= 0 Then
                            foe_death(1, LBLArenaFoe1Border.BackColor)
                        Else
                            LBLArenaFoe1CurrentHP.Text -= damage
                            PGBFoe1HP.Value = LBLArenaFoe1CurrentHP.Text
                        End If
                    End If
                Case 2
                    If GRBFoe2.Visible = True Then
                        If (LBLArenaFoe2CurrentHP.Text - damage) <= 0 Then
                            foe_death(2, LBLArenaFoe2Border.BackColor)
                        Else
                            LBLArenaFoe2CurrentHP.Text -= damage
                            PGBFoe2HP.Value = LBLArenaFoe2CurrentHP.Text
                        End If
                    End If
                Case 3
                    If GRBFoe3.Visible = True Then
                        If (LBLArenaFoe3CurrentHP.Text - damage) <= 0 Then
                            foe_death(3, LBLArenaFoe3Border.BackColor)
                        Else
                            LBLArenaFoe3CurrentHP.Text -= damage
                            PGBFoe3HP.Value = LBLArenaFoe3CurrentHP.Text
                        End If
                    End If
                Case 4
                    If GRBFoe4.Visible = True Then
                        If (LBLArenaFoe4CurrentHP.Text - damage) <= 0 Then
                            foe_death(4, LBLArenaFoe4Border.BackColor)
                        Else
                            LBLArenaFoe4CurrentHP.Text -= damage
                            PGBFoe4HP.Value = LBLArenaFoe4CurrentHP.Text
                        End If
                    End If
                Case 5
                    If GRBFoe5.Visible = True Then
                        If (LBLArenaFoe5CurrentHP.Text - damage) <= 0 Then
                            foe_death(5, LBLArenaFoe5Border.BackColor)
                        Else
                            LBLArenaFoe5CurrentHP.Text -= damage
                            PGBFoe5HP.Value = LBLArenaFoe5CurrentHP.Text
                        End If
                    End If
            End Select


        Else
            Select Case target
                Case 1
                    If GRBFoe1.Visible = True Then
                        If (LBLArenaFoe1CurrentHP.Text - damage) <= 0 Then
                            foe_death(1, LBLArenaFoe1Border.BackColor)
                        Else
                            LBLArenaFoe1CurrentHP.Text -= damage
                            PGBFoe1HP.Value = LBLArenaFoe1CurrentHP.Text
                        End If
                    End If
                Case 2
                    If GRBFoe2.Visible = True Then
                        If (LBLArenaFoe2CurrentHP.Text - damage) <= 0 Then
                            foe_death(2, LBLArenaFoe2Border.BackColor)
                        Else
                            LBLArenaFoe2CurrentHP.Text -= damage
                            PGBFoe2HP.Value = LBLArenaFoe2CurrentHP.Text
                        End If
                    End If
                Case 3
                    If GRBFoe3.Visible = True Then
                        If (LBLArenaFoe3CurrentHP.Text - damage) <= 0 Then
                            foe_death(3, LBLArenaFoe3Border.BackColor)
                        Else
                            LBLArenaFoe3CurrentHP.Text -= damage
                            PGBFoe3HP.Value = LBLArenaFoe3CurrentHP.Text
                        End If
                    End If
                Case 4
                    If GRBFoe4.Visible = True Then
                        If (LBLArenaFoe4CurrentHP.Text - damage) <= 0 Then
                            foe_death(4, LBLArenaFoe4Border.BackColor)
                        Else
                            LBLArenaFoe4CurrentHP.Text -= damage
                            PGBFoe4HP.Value = LBLArenaFoe4CurrentHP.Text
                        End If
                    End If
                Case 5
                    If GRBFoe5.Visible = True Then
                        If (LBLArenaFoe5CurrentHP.Text - damage) <= 0 Then
                            foe_death(5, LBLArenaFoe5Border.BackColor)
                        Else
                            LBLArenaFoe5CurrentHP.Text -= damage
                            PGBFoe5HP.Value = LBLArenaFoe5CurrentHP.Text
                        End If
                    End If
            End Select

        End If
    End Function


    'HARD CODED SKILL DESCRIPTIONS
    Private Sub CMDSkill_Description_Clear_MouseLeave(sender As Object, e As EventArgs) Handles CMDSagraxesSkill1.MouseLeave, CMDSagraxesSkill2.MouseLeave, CMDSagraxesSkill3.MouseLeave, CMDSagraxesSkill4.MouseLeave, CMDSagraxesSkill5.MouseLeave, PCBArenaFoe1Avatar.MouseLeave, PCBArenaFoe2Avatar.MouseLeave, PCBArenaFoe3Avatar.MouseLeave, PCBArenaFoe4Avatar.MouseLeave, PCBArenaFoe5Avatar.MouseLeave, CMDFlee.MouseLeave, CMDBlock.MouseLeave, CMDAlyshaSkill1.MouseLeave, CMDAlyshaSkill2.MouseLeave, CMDAlyshaSkill3.MouseLeave, CMDAlyshaSkill4.MouseLeave, CMDAlyshaSkill5.MouseLeave, CMDMakyrSkill1.MouseLeave, CMDMakyrSkill2.MouseLeave, CMDMakyrSkill3.MouseLeave, CMDMakyrSkill4.MouseLeave, CMDMakyrSkill5.MouseLeave, CMDNardinaSkill1.MouseLeave, CMDNardinaSkill2.MouseLeave, CMDNardinaSkill3.MouseLeave, CMDNardinaSkill4.MouseLeave, CMDNardinaSkill5.MouseLeave, CMDNylathriaSkill1.MouseLeave, CMDNylathriaSkill2.MouseLeave, CMDNylathriaSkill3.MouseLeave, CMDNylathriaSkill4.MouseLeave, CMDNylathriaSkill5.MouseLeave, CMDUseItem.MouseLeave
        LBLSkillDescription.Text = ""
    End Sub
    Private Sub CMDBlock_MouseHover(sender As Object, e As EventArgs) Handles CMDBlock.MouseHover
        LBLSkillDescription.Text = "Block" & vbCrLf & vbCrLf & "Block the next incomming attack." & vbCrLf & vbCrLf & "Cost: 0 mana" & vbCrLf & "Cooldown: 0 turns"
    End Sub
    Private Sub CMDflee_mousehover(sender As Object, e As EventArgs) Handles CMDFlee.MouseHover
        LBLSkillDescription.Text = "Flee!" & vbCrLf & vbCrLf & "Flee from combat." & vbCrLf & vbCrLf & "Cost: 0 mana" & vbCrLf & "Cooldown: 0 turns"
    End Sub
    Private Sub CMDUseItem_mousehover(sender As Object, e As EventArgs) Handles CMDUseItem.MouseHover
        LBLSkillDescription.Text = "Use Item" & vbCrLf & vbCrLf & "Use an item from your inventory." & vbCrLf & vbCrLf & "Cost: 0 mana" & vbCrLf & "Cooldown: 0 turns"
    End Sub
    Private Sub foe_avatar_mousehover(sender As Object, e As EventArgs) Handles PCBArenaFoe1Avatar.MouseHover, PCBArenaFoe2Avatar.MouseHover, PCBArenaFoe3Avatar.MouseHover, PCBArenaFoe4Avatar.MouseHover, PCBArenaFoe5Avatar.MouseHover
        LBLSkillDescription.Text = "Attack!" & vbCrLf & vbCrLf & "Perform a normal weapon attack." & vbCrLf & vbCrLf & "Cost: 0 mana" & vbCrLf & "Cooldown: 0 turns"
    End Sub

    Private Sub CMDAlyshaSkill1_MouseHover(sender As Object, e As EventArgs) Handles CMDAlyshaSkill1.MouseHover
        LBLSkillDescription.Text = "Uppercut" & vbCrLf & vbCrLf & "Deal " & 40 + skill_damage_modifier & " damage to a random foe." & vbCrLf & vbCrLf & "Cost: 10 mana" & vbCrLf & "Cooldown: 1 turn"
    End Sub
    Private Sub CMDAlyshaSkill2_MouseHover(sender As Object, e As EventArgs) Handles CMDAlyshaSkill2.MouseHover
        LBLSkillDescription.Text = "Mana Burn" & vbCrLf & vbCrLf & "Lose all your mana. Deal " & 2 + LBLWisdomMod.Text & " damage to a random foe for each mana point lost." & vbCrLf & vbCrLf & "Cost: 0 mana" & vbCrLf & "Cooldown: 5 turns"
    End Sub
    Private Sub CMDAlyshaSkill3_MouseHover(sender As Object, e As EventArgs) Handles CMDAlyshaSkill3.MouseHover
        LBLSkillDescription.Text = "Focus" & vbCrLf & vbCrLf & "Block the next attack attack and restore " & 40 + skill_damage_modifier & " mana." & vbCrLf & vbCrLf & "Cost: 10 mana" & vbCrLf & "Cooldown: 5 turns"
    End Sub
    Private Sub CMDAlyshaSkill4_MouseHover(sender As Object, e As EventArgs) Handles CMDAlyshaSkill4.MouseHover
        LBLSkillDescription.Text = "Dance For Me!" & vbCrLf & vbCrLf & "Regain all your health if you are below " & 10 + skill_damage_modifier & " health." & vbCrLf & vbCrLf & "Cost: 50 mana" & vbCrLf & "Cooldown: 2 turns"
    End Sub
    Private Sub CMDAlyshaSkill5_MouseHover(sender As Object, e As EventArgs) Handles CMDAlyshaSkill5.MouseHover
        LBLSkillDescription.Text = "Bandage" & vbCrLf & vbCrLf & "You heal for " & 20 + skill_damage_modifier & " health " & LBLWisdomMod.Text & " time(s)." & vbCrLf & vbCrLf & "Cost: 30 mana" & vbCrLf & "Cooldown: 5 turns"
    End Sub

    Private Sub cmdMakyrSkill1_MouseHover(sender As Object, e As EventArgs) Handles CMDMakyrSkill1.MouseHover
        LBLSkillDescription.Text = "Banish" & vbCrLf & vbCrLf & "Deal " & 60 + skill_damage_modifier & " damage to a random foe." & vbCrLf & vbCrLf & "Cost: 25 mana" & vbCrLf & "Cooldown: 3 turns"
    End Sub
    Private Sub cmdMakyrSkill2_MouseHover(sender As Object, e As EventArgs) Handles CMDMakyrSkill2.MouseHover
        LBLSkillDescription.Text = "Healing Light" & vbCrLf & vbCrLf & "Heal for " & 50 + skill_damage_modifier & " health. If all your opponents are at full health, restore all your mana." & vbCrLf & vbCrLf & "Cost: 10 mana" & vbCrLf & "Cooldown: 5 turns"
    End Sub
    Private Sub cmdMakyrSkill3_MouseHover(sender As Object, e As EventArgs) Handles CMDMakyrSkill3.MouseHover
        LBLSkillDescription.Text = "Healing Breeze" & vbCrLf & vbCrLf & "Heal for " & 40 + skill_damage_modifier & " for each foe you face." & vbCrLf & vbCrLf & "Cost: 20 mana" & vbCrLf & "Cooldown: 4 turns"
    End Sub
    Private Sub cmdMakyrSkill4_MouseHover(sender As Object, e As EventArgs) Handles CMDMakyrSkill4.MouseHover
        LBLSkillDescription.Text = "Ray of Judgment" & vbCrLf & vbCrLf & "Deal " & 200 + skill_damage_modifier & " damage to all legendary foes." & vbCrLf & vbCrLf & "Cost: 40 mana" & vbCrLf & "Cooldown: 5 turns"
    End Sub
    Private Sub cmdMakyrSkill5_MouseHover(sender As Object, e As EventArgs) Handles CMDMakyrSkill5.MouseHover
        LBLSkillDescription.Text = "Spirit Bond" & vbCrLf & vbCrLf & "Deal " & 20 + skill_damage_modifier & " damage to a random foe and restore damage dealt as health and mana." & vbCrLf & vbCrLf & "Cost: 5 mana" & vbCrLf & "Cooldown: 2 turns"
    End Sub

    Private Sub CMDNardinaSkill1_MouseHover(sender As Object, e As EventArgs) Handles CMDNardinaSkill1.MouseHover
        LBLSkillDescription.Text = "Bed of Coals" & vbCrLf & vbCrLf & "Deal " & 50 + skill_damage_modifier & " damage to all common foes." & vbCrLf & vbCrLf & "Cost: 30 mana" & vbCrLf & "Cooldown: 4 turns"
    End Sub
    Private Sub CMDNardinaSkill2_MouseHover(sender As Object, e As EventArgs) Handles CMDNardinaSkill2.MouseHover
        LBLSkillDescription.Text = "Crystal Wave" & vbCrLf & vbCrLf & "Deal " & 40 + skill_damage_modifier & " damage to all odd positioned foes and " & vbCrLf & 20 + skill_damage_modifier & " damage to all even positioned foes." & vbCrLf & vbCrLf & "Cost: 25 mana" & vbCrLf & "Cooldown: 5 turns"
    End Sub
    Private Sub CMDNardinaSkill3_MouseHover(sender As Object, e As EventArgs) Handles CMDNardinaSkill3.MouseHover
        LBLSkillDescription.Text = "Mana Blast" & vbCrLf & vbCrLf & "Lose half your mana, deal amount of mana lost times four +" & skill_damage_modifier & " damage to a random foe." & vbCrLf & vbCrLf & "Cost: 0 mana" & vbCrLf & "Cooldown: 6 turns"
    End Sub
    Private Sub CMDNardinaSkill4_MouseHover(sender As Object, e As EventArgs) Handles CMDNardinaSkill4.MouseHover
        LBLSkillDescription.Text = "Glowing Gaze" & vbCrLf & vbCrLf & "Gain " & 10 + skill_damage_modifier & " mana for each foe you face." & vbCrLf & vbCrLf & "Cost: 0 mana" & vbCrLf & "Cooldown: 6 turns"
    End Sub
    Private Sub CMDNardinaSkill5_MouseHover(sender As Object, e As EventArgs) Handles CMDNardinaSkill5.MouseHover
        LBLSkillDescription.Text = "Phoenix" & vbCrLf & vbCrLf & "Convert all your mana into health +" & skill_damage_modifier & "." & vbCrLf & vbCrLf & "Cost: 0 mana" & vbCrLf & "Cooldown: 10 turns"
    End Sub

    Private Sub CMDNylathriaSkill1_MouseHover(sender As Object, e As EventArgs) Handles CMDNylathriaSkill1.MouseHover
        LBLSkillDescription.Text = "Vampiric Spirit" & vbCrLf & vbCrLf & "Deal " & 40 + skill_damage_modifier & " damage to a random foe and regain damage done as mana." & vbCrLf & vbCrLf & "Cost: 20 mana" & vbCrLf & "Cooldown: 3 turns"
    End Sub
    Private Sub CMDNylathriaSkill2_MouseHover(sender As Object, e As EventArgs) Handles CMDNylathriaSkill2.MouseHover
        LBLSkillDescription.Text = "Vampiric Swarm" & vbCrLf & vbCrLf & "Deal " & 10 + skill_damage_modifier & " damage to all foes and regain damage done as health." & vbCrLf & vbCrLf & "Cost: 30 mana" & vbCrLf & "Cooldown: 4 turns"
    End Sub
    Private Sub CMDNylathriaSkill3_MouseHover(sender As Object, e As EventArgs) Handles CMDNylathriaSkill3.MouseHover
        LBLSkillDescription.Text = "Spinal Shivers" & vbCrLf & vbCrLf & "Deal " & 50 + skill_damage_modifier & " damage to a random foe. If target is at maximum health, deal an additional " & 100 + skill_damage_modifier & " damage." & vbCrLf & vbCrLf & "Cost: 25 mana" & vbCrLf & "Cooldown: 5 turns"
    End Sub
    Private Sub CMDNylathriaSkill4_MouseHover(sender As Object, e As EventArgs) Handles CMDNylathriaSkill4.MouseHover
        LBLSkillDescription.Text = "Blood is Power" & vbCrLf & vbCrLf & "Deal 50 damage to yourself, regain " & 50 + skill_damage_modifier & " mana." & vbCrLf & vbCrLf & "Cost: 0 mana" & vbCrLf & "Cooldown: 1 turns"
    End Sub
    Private Sub CMDNylathriaSkill5_MouseHover(sender As Object, e As EventArgs) Handles CMDNylathriaSkill5.MouseHover
        LBLSkillDescription.Text = "Dark Fury" & vbCrLf & vbCrLf & "Lose 50% of your health and deal health lost plus " & skill_damage_modifier & " as damage to all foes." & vbCrLf & vbCrLf & "Cost: 10 mana" & vbCrLf & "Cooldown: 2 turns"
    End Sub

    Private Sub CMDSagraxesSkill1_MouseHover(sender As Object, e As EventArgs) Handles CMDSagraxesSkill1.MouseHover
        LBLSkillDescription.Text = "Cleave" & vbCrLf & vbCrLf & "Deal " & 20 + skill_damage_modifier & " damage to a random foe and " & 10 + skill_damage_modifier + damage_min & " to adjacent foes." & vbCrLf & vbCrLf & "Cost: 20 mana" & vbCrLf & "Cooldown: 3 turns"
    End Sub
    Private Sub CMDSagraxesSkill2_MouseHover(sender As Object, e As EventArgs) Handles CMDSagraxesSkill2.MouseHover
        LBLSkillDescription.Text = "Whirlwind Attack" & vbCrLf & vbCrLf & "Deal " & 10 + skill_damage_modifier & " damage to all foes." & vbCrLf & vbCrLf & "Cost: 20 mana" & vbCrLf & "Cooldown: 2 turns"
    End Sub
    Private Sub CMDSagraxesSkill3_MouseHover(sender As Object, e As EventArgs) Handles CMDSagraxesSkill3.MouseHover
        LBLSkillDescription.Text = "Power Attack" & vbCrLf & vbCrLf & "Deal " & 50 + skill_damage_modifier & " damage to the healthiest foe. Unblockable." & vbCrLf & vbCrLf & "Cost: 30 mana" & vbCrLf & "Cooldown: 3 turns"
    End Sub
    Private Sub CMDSagraxesSkill4_MouseHover(sender As Object, e As EventArgs) Handles CMDSagraxesSkill4.MouseHover
        LBLSkillDescription.Text = "Sun and Moon Slash" & vbCrLf & vbCrLf & "Deal " & 30 + skill_damage_modifier & " damage to two random foes." & vbCrLf & vbCrLf & "Cost: 25 mana" & vbCrLf & "Cooldown: 3 turns"
    End Sub
    Private Sub CMDSagraxesSkill5_MouseHover(sender As Object, e As EventArgs) Handles CMDSagraxesSkill5.MouseHover
        LBLSkillDescription.Text = "Defensive Stance" & vbCrLf & vbCrLf & "Block the next attack and restore " & 10 + skill_damage_modifier & " health." & vbCrLf & vbCrLf & "Cost: 15 mana" & vbCrLf & "Cooldown: 2 turns"
    End Sub



    'HARD CODED SKILLS
    Private Sub CMDAlyshaSkill1_Click(sender As Object, e As EventArgs) Handles CMDAlyshaSkill1.Click
        'LBLSkillDescription.Text = "Deal " & 40 + skill_damage_modifier & " damage to a random foe." & vbCrLf & "Cost: 10 mana" & vbCrLf & "Cooldown: 1 turn"

        'DO THE SKILL
        If LBLArenaCurrentMP.Text - 10 >= 0 Then
            LBLArenaCurrentMP.Text -= 10
            playsound("Alysha_Skill_1", True)
            'damage calculation
            Dim damage As Integer = 40 + skill_damage_modifier

            'deal damage to random target
            damage_target(damage, -1)

            'WHEN SKILL IS USED, SAVE THE TURN THE SKILL WAS USED ON
            alysha_skill_1_CD = turn_counter

            CMDAlyshaSkill1.Enabled = False
            CMDAlyshaSkill1.Text = "X"

            TXTCombatLog.Text = "You hit a random foe for " & damage & " damage." & vbCrLf & vbCrLf & TXTCombatLog.Text
            check_round_status()

        Else
            TXTCombatLog.Text = "You don't have enough mana to use that skill" & vbCrLf & vbCrLf & TXTCombatLog.Text
        End If
    End Sub
    Private Sub CMDAlyshaSkill2_Click(sender As Object, e As EventArgs) Handles CMDAlyshaSkill2.Click
        'DO THE SKILL
        'damage calculation
        Dim damage As Integer = LBLArenaCurrentMP.Text * (2 + LBLWisdomMod.Text)
        playsound("Alysha_Skill_2", True)
        'subtract all mana
        LBLArenaCurrentMP.Text = 0
        PGBPlayerMP.Value = 0

        'deal damage to random target
        damage_target(damage, -1)

        'WHEN SKILL IS USED, SAVE THE TURN THE SKILL WAS USED ON
        alysha_skill_2_CD = turn_counter

        CMDAlyshaSkill2.Enabled = False
        CMDAlyshaSkill2.Text = "X"

        TXTCombatLog.Text = "You hit a random foe for " & damage & " damage." & vbCrLf & vbCrLf & TXTCombatLog.Text
        check_round_status()


    End Sub
    Private Sub CMDAlyshaSkill3_Click(sender As Object, e As EventArgs) Handles CMDAlyshaSkill3.Click
        'DO THE SKILL
        If LBLArenaCurrentMP.Text - 10 >= 0 Then
            LBLArenaCurrentMP.Text -= 10
            playsound("Alysha_Skill_3", True)
            Dim regen As Integer = 40 + skill_damage_modifier

            is_blocking = True

            If (LBLArenaCurrentMP.Text + regen) > LBLArenaMaxMP.Text Then
                LBLArenaCurrentMP.Text = LBLArenaMaxMP.Text
            Else
                LBLArenaCurrentMP.Text += regen
            End If

            'WHEN SKILL IS USED, SAVE THE TURN THE SKILL WAS USED ON
            alysha_skill_3_CD = turn_counter

            CMDAlyshaSkill3.Enabled = False
            CMDAlyshaSkill3.Text = "X"

            TXTCombatLog.Text = "You will block the next incomming attack and regained " & regen & " mana." & vbCrLf & vbCrLf & TXTCombatLog.Text
            check_round_status()

        Else
            TXTCombatLog.Text = "You don't have enough mana to use that skill" & vbCrLf & vbCrLf & TXTCombatLog.Text
        End If
    End Sub
    Private Sub CMDAlyshaSkill4_Click(sender As Object, e As EventArgs) Handles CMDAlyshaSkill4.Click
        'DO THE SKILL
        If LBLArenaCurrentHP.Text < (10 + skill_damage_modifier) Then
            If LBLArenaCurrentMP.Text - 50 >= 0 Then
                LBLArenaCurrentMP.Text -= 50
                LBLArenaCurrentHP.Text = LBLArenaMaxHP.Text
                PGBPlayerHP.Value = LBLArenaCurrentHP.Text
                playsound("Alysha_Skill_4", True)
                'WHEN SKILL IS USED, SAVE THE TURN THE SKILL WAS USED ON
                alysha_skill_4_CD = turn_counter

                CMDAlyshaSkill4.Enabled = False
                CMDAlyshaSkill4.Text = "X"

                TXTCombatLog.Text = "Your health was fully restored" & vbCrLf & vbCrLf & TXTCombatLog.Text
                check_round_status()
            Else
                TXTCombatLog.Text = "You don't have enough mana to use that skill" & vbCrLf & vbCrLf & TXTCombatLog.Text
            End If
        Else
            TXTCombatLog.Text = "You are not below " & 10 + skill_damage_modifier & " health." & vbCrLf & vbCrLf & TXTCombatLog.Text
        End If
    End Sub
    Private Sub CMDAlyshaSkill5_Click(sender As Object, e As EventArgs) Handles CMDAlyshaSkill5.Click
        'DO THE SKILL
        If LBLArenaCurrentMP.Text - 30 >= 0 Then
            LBLArenaCurrentMP.Text -= 30
            playsound("Alysha_Skill_5", True)
            Dim heal As Integer = 20 + skill_damage_modifier

            For i As Integer = 0 To LBLWisdomMod.Text


                If (LBLArenaCurrentHP.Text + heal) > LBLArenaMaxHP.Text Then
                    LBLArenaCurrentHP.Text = LBLArenaMaxHP.Text
                Else
                    LBLArenaCurrentHP.Text += heal
                End If

            Next

            'WHEN SKILL IS USED, SAVE THE TURN THE SKILL WAS USED ON
            alysha_skill_5_CD = turn_counter

            CMDAlyshaSkill5.Enabled = False
            CMDAlyshaSkill5.Text = "X"

            TXTCombatLog.Text = "You healed for a total of " & (heal * LBLWisdomMod.Text) & " health." & vbCrLf & vbCrLf & TXTCombatLog.Text
            check_round_status()

        Else
            TXTCombatLog.Text = "You don't have enough mana to use that skill" & vbCrLf & vbCrLf & TXTCombatLog.Text
        End If
    End Sub

    Private Sub CMDMakyrSkill1_Click(sender As Object, e As EventArgs) Handles CMDMakyrSkill1.Click
        'DO THE SKILL
        If LBLArenaCurrentMP.Text - 25 >= 0 Then
            LBLArenaCurrentMP.Text -= 25
            playsound("Makyr_Skill_1", True)
            'damage calculation
            Dim damage As Integer = 60 + skill_damage_modifier

            'deal damage to random target
            damage_target(damage, -1)

            'WHEN SKILL IS USED, SAVE THE TURN THE SKILL WAS USED ON
            makyr_skill_1_CD = turn_counter

            CMDMakyrSkill1.Enabled = False
            CMDMakyrSkill1.Text = "X"

            TXTCombatLog.Text = "You hit a random foe For " & damage & " damage." & vbCrLf & vbCrLf & TXTCombatLog.Text
            check_round_status()

        Else
            TXTCombatLog.Text = "You don't have enough mana to use that skill" & vbCrLf & vbCrLf & TXTCombatLog.Text
        End If
    End Sub
    Private Sub CMDMakyrSkill2_Click(sender As Object, e As EventArgs) Handles CMDMakyrSkill2.Click
        'DO THE SKILL
        If LBLArenaCurrentMP.Text - 10 >= 0 Then
            LBLArenaCurrentMP.Text -= 10
            playsound("Makyr_Skill_2", True)
            Dim heal As Integer = 50 + skill_damage_modifier
            Dim amount_of_foes As Integer = (Math.Ceiling(LBLLevel.Text / 4)) 'generate random number between 1 and amount of foes spawned
            Dim mana_restored As Boolean = False

            If (LBLArenaCurrentHP.Text + heal) > LBLArenaMaxHP.Text Then
                LBLArenaCurrentHP.Text = LBLArenaMaxHP.Text
            Else
                LBLArenaCurrentHP.Text += heal
            End If

            Select Case amount_of_foes
                Case 1
                    If LBLArenaFoe1CurrentHP.Text = LBLArenaFoe1MaxHP.Text Then
                        LBLArenaCurrentMP.Text = LBLArenaMaxMP.Text
                        mana_restored = True
                    End If
                Case 2
                    If LBLArenaFoe1CurrentHP.Text = LBLArenaFoe1MaxHP.Text Then
                        If LBLArenaFoe2CurrentHP.Text = LBLArenaFoe2MaxHP.Text Then
                            LBLArenaCurrentMP.Text = LBLArenaMaxMP.Text
                            mana_restored = True
                        End If
                    End If
                Case 3
                    If LBLArenaFoe1CurrentHP.Text = LBLArenaFoe1MaxHP.Text Then
                        If LBLArenaFoe2CurrentHP.Text = LBLArenaFoe2MaxHP.Text Then
                            If LBLArenaFoe3CurrentHP.Text = LBLArenaFoe3MaxHP.Text Then
                                LBLArenaCurrentMP.Text = LBLArenaMaxMP.Text
                                mana_restored = True
                            End If
                        End If
                    End If
                Case 4
                    If LBLArenaFoe1CurrentHP.Text = LBLArenaFoe1MaxHP.Text Then
                        If LBLArenaFoe2CurrentHP.Text = LBLArenaFoe2MaxHP.Text Then
                            If LBLArenaFoe3CurrentHP.Text = LBLArenaFoe3MaxHP.Text Then
                                If LBLArenaFoe4CurrentHP.Text = LBLArenaFoe4MaxHP.Text Then
                                    LBLArenaCurrentMP.Text = LBLArenaMaxMP.Text
                                    mana_restored = True
                                End If
                            End If
                        End If
                    End If
                Case 5
                    If LBLArenaFoe1CurrentHP.Text = LBLArenaFoe1MaxHP.Text Then
                        If LBLArenaFoe2CurrentHP.Text = LBLArenaFoe2MaxHP.Text Then
                            If LBLArenaFoe3CurrentHP.Text = LBLArenaFoe3MaxHP.Text Then
                                If LBLArenaFoe4CurrentHP.Text = LBLArenaFoe4MaxHP.Text Then
                                    If LBLArenaFoe5CurrentHP.Text = LBLArenaFoe5MaxHP.Text Then
                                        LBLArenaCurrentMP.Text = LBLArenaMaxMP.Text
                                        mana_restored = True
                                    End If
                                End If
                            End If
                        End If
                    End If
            End Select

            'WHEN SKILL IS USED, SAVE THE TURN THE SKILL WAS USED ON
            makyr_skill_2_CD = turn_counter

            CMDMakyrSkill2.Enabled = False
            CMDMakyrSkill2.Text = "X"

            If mana_restored = True Then
                TXTCombatLog.Text = "You healed for " & heal & " health and restored all your mana." & vbCrLf & vbCrLf & TXTCombatLog.Text
            Else
                TXTCombatLog.Text = "You healed for " & heal & " health." & vbCrLf & vbCrLf & TXTCombatLog.Text
            End If

            check_round_status()

        Else
            TXTCombatLog.Text = "You don't have enough mana to use that skill" & vbCrLf & vbCrLf & TXTCombatLog.Text
        End If
    End Sub
    Private Sub CMDMakyrSkill3_Click(sender As Object, e As EventArgs) Handles CMDMakyrSkill3.Click
        'DO THE SKILL
        If LBLArenaCurrentMP.Text - 20 >= 0 Then
            LBLArenaCurrentMP.Text -= 20
            playsound("Makyr_Skill_3", True)
            Dim heal = (40 * (Math.Ceiling(LBLLevel.Text / 4))) + skill_damage_modifier

            If (LBLArenaCurrentHP.Text + heal) > LBLArenaMaxHP.Text Then
                LBLArenaCurrentHP.Text = LBLArenaMaxHP.Text
            Else
                LBLArenaCurrentHP.Text += heal
            End If

            'WHEN SKILL IS USED, SAVE THE TURN THE SKILL WAS USED ON
            makyr_skill_3_CD = turn_counter

            CMDMakyrSkill3.Enabled = False
            CMDMakyrSkill3.Text = "X"

            TXTCombatLog.Text = "You healed for " & heal & " health." & vbCrLf & vbCrLf & TXTCombatLog.Text

            check_round_status()

        Else
            TXTCombatLog.Text = "You don't have enough mana to use that skill" & vbCrLf & vbCrLf & TXTCombatLog.Text
        End If
    End Sub
    Private Sub CMDMakyrSkill4_Click(sender As Object, e As EventArgs) Handles CMDMakyrSkill4.Click
        'DO THE SKILL
        If LBLArenaCurrentMP.Text - 40 >= 0 Then
            LBLArenaCurrentMP.Text -= 40
            playsound("Makyr_Skill_4", True)

            Dim leg_damage As Integer = 200 + skill_damage_modifier

            If GRBFoe1.Visible = True Then
                If LBLArenaFoe1Border.BackColor = Color.Orange Then
                    damage_target(leg_damage, 1)
                End If
            End If

            If GRBFoe2.Visible = True Then
                If LBLArenaFoe2Border.BackColor = Color.Orange Then
                    damage_target(leg_damage, 2)
                End If
            End If

            If GRBFoe3.Visible = True Then
                If LBLArenaFoe3Border.BackColor = Color.Orange Then
                    damage_target(leg_damage, 3)
                End If
            End If

            If GRBFoe4.Visible = True Then
                If LBLArenaFoe4Border.BackColor = Color.Orange Then
                    damage_target(leg_damage, 4)
                End If
            End If

            If GRBFoe5.Visible = True Then
                If LBLArenaFoe5Border.BackColor = Color.Orange Then
                    damage_target(leg_damage, 5)
                End If
            End If


            'WHEN SKILL IS USED, SAVE THE TURN THE SKILL WAS USED ON
            makyr_skill_4_CD = turn_counter

            CMDMakyrSkill4.Enabled = False
            CMDMakyrSkill4.Text = "X"

            TXTCombatLog.Text = "You hit a legendary foe for " & leg_damage & " damage." & vbCrLf & vbCrLf & TXTCombatLog.Text
            check_round_status()

        Else
            TXTCombatLog.Text = "You don't have enough mana to use that skill" & vbCrLf & vbCrLf & TXTCombatLog.Text
        End If
    End Sub
    Private Sub CMDMakyrSkill5_Click(sender As Object, e As EventArgs) Handles CMDMakyrSkill5.Click
        'DO THE SKILL
        If LBLArenaCurrentMP.Text - 5 >= 0 Then
            LBLArenaCurrentMP.Text -= 5
            playsound("Makyr_Skill_5", True)
            'damage calculation
            Dim damage As Integer = 20 + skill_damage_modifier

            damage_target(damage, -1)

            If (LBLArenaCurrentHP.Text + damage) > LBLArenaMaxHP.Text Then
                LBLArenaCurrentHP.Text = LBLArenaMaxHP.Text
            Else
                LBLArenaCurrentHP.Text += damage
            End If

            If (LBLArenaCurrentMP.Text + damage) > LBLArenaMaxMP.Text Then
                LBLArenaCurrentMP.Text = LBLArenaMaxMP.Text
            Else
                LBLArenaCurrentMP.Text += damage
            End If

            'WHEN SKILL IS USED, SAVE THE TURN THE SKILL WAS USED ON
            makyr_skill_5_CD = turn_counter

            CMDMakyrSkill5.Enabled = False
            CMDMakyrSkill5.Text = "X"

            TXTCombatLog.Text = "You hit a random foe for " & damage & " damage and regained " & damage & " health and mana." & vbCrLf & vbCrLf & TXTCombatLog.Text
            check_round_status()

        Else
            TXTCombatLog.Text = "You don't have enough mana to use that skill" & vbCrLf & vbCrLf & TXTCombatLog.Text
        End If
    End Sub

    Private Sub CMDNardinaSkill1_Click(sender As Object, e As EventArgs) Handles CMDNardinaSkill1.Click
        'DO THE SKILL
        If LBLArenaCurrentMP.Text - 30 >= 0 Then
            LBLArenaCurrentMP.Text -= 30
            playsound("Nardina_Skill_1", True)
            'damage calculation
            Dim damage As Integer = 50 + skill_damage_modifier

            If GRBFoe1.Visible = True Then
                If LBLArenaFoe1Border.BackColor = Color.White Then
                    damage_target(damage, 1)
                End If
            End If

            If GRBFoe2.Visible = True Then
                If LBLArenaFoe2Border.BackColor = Color.White Then
                    damage_target(damage, 2)
                End If
            End If

            If GRBFoe3.Visible = True Then
                If LBLArenaFoe3Border.BackColor = Color.White Then
                    damage_target(damage, 3)
                End If
            End If

            If GRBFoe4.Visible = True Then
                If LBLArenaFoe4Border.BackColor = Color.White Then
                    damage_target(damage, 4)
                End If
            End If

            If GRBFoe5.Visible = True Then
                If LBLArenaFoe5Border.BackColor = Color.White Then
                    damage_target(damage, 5)
                End If
            End If

            'WHEN SKILL IS USED, SAVE THE TURN THE SKILL WAS USED ON
            nardina_skill_1_CD = turn_counter

            CMDNardinaSkill1.Enabled = False
            CMDNardinaSkill1.Text = "X"

            TXTCombatLog.Text = "You hit all common foes for " & damage & " damage." & vbCrLf & vbCrLf & TXTCombatLog.Text
            check_round_status()

        Else
            TXTCombatLog.Text = "You don't have enough mana to use that skill" & vbCrLf & vbCrLf & TXTCombatLog.Text
        End If
    End Sub
    Private Sub CMDNardinaSkill2_Click(sender As Object, e As EventArgs) Handles CMDNardinaSkill2.Click
        'DO THE SKILL
        If LBLArenaCurrentMP.Text - 25 >= 0 Then
            LBLArenaCurrentMP.Text -= 25
            playsound("Nardina_Skill_2", True)
            'damage calculation
            Dim odd_damage As Integer = 50 + skill_damage_modifier
            Dim even_damage As Integer = 20 + skill_damage_modifier

            If GRBFoe1.Visible = True Then
                damage_target(odd_damage, 1)
            End If

            If GRBFoe2.Visible = True Then
                damage_target(even_damage, 2)
            End If

            If GRBFoe3.Visible = True Then
                damage_target(odd_damage, 3)
            End If

            If GRBFoe4.Visible = True Then
                damage_target(even_damage, 4)
            End If

            If GRBFoe5.Visible = True Then
                damage_target(odd_damage, 5)
            End If

            'WHEN SKILL IS USED, SAVE THE TURN THE SKILL WAS USED ON
            nardina_skill_2_CD = turn_counter

            CMDNardinaSkill2.Enabled = False
            CMDNardinaSkill2.Text = "X"

            TXTCombatLog.Text = "You hit all odd positioned foes for " & odd_damage & " damage and all even positioned foes for " & even_damage & " damage." & vbCrLf & vbCrLf & TXTCombatLog.Text
            check_round_status()

        Else
            TXTCombatLog.Text = "You don't have enough mana to use that skill" & vbCrLf & vbCrLf & TXTCombatLog.Text
        End If
    End Sub
    Private Sub CMDNardinaSkill3_Click(sender As Object, e As EventArgs) Handles CMDNardinaSkill3.Click
        'DO THE SKILL
        Dim damage As Integer = Math.Ceiling(LBLArenaCurrentMP.Text / 2) * 4
        playsound("Nardina_Skill_3", True)
        LBLArenaCurrentMP.Text = Math.Ceiling(LBLArenaCurrentMP.Text / 2)

        damage_target(damage, -1)

        'WHEN SKILL IS USED, SAVE THE TURN THE SKILL WAS USED ON
        nardina_skill_3_CD = turn_counter

        CMDNardinaSkill3.Enabled = False
        CMDNardinaSkill3.Text = "X"

        TXTCombatLog.Text = "You lost half your mana and hit a foe for " & damage & " damage." & vbCrLf & vbCrLf & TXTCombatLog.Text
        check_round_status()


    End Sub
    Private Sub CMDNardinaSkill4_Click(sender As Object, e As EventArgs) Handles CMDNardinaSkill4.Click

        Dim mana_regen As Integer = (10 * (Math.Ceiling(LBLLevel.Text / 4))) + skill_damage_modifier
        playsound("Nardina_Skill_4", True)
        If (LBLArenaCurrentMP.Text + mana_regen) > LBLArenaMaxMP.Text Then
            LBLArenaCurrentMP.Text = LBLArenaMaxMP.Text
        Else
            LBLArenaCurrentMP.Text += mana_regen
        End If

        'WHEN SKILL IS USED, SAVE THE TURN THE SKILL WAS USED ON
        nardina_skill_4_CD = turn_counter

        CMDNardinaSkill4.Enabled = False
        CMDNardinaSkill4.Text = "X"

        TXTCombatLog.Text = "You gained " & mana_regen & " mana." & vbCrLf & vbCrLf & TXTCombatLog.Text
        check_round_status()


    End Sub
    Private Sub CMDNardinaSkill5_Click(sender As Object, e As EventArgs) Handles CMDNardinaSkill5.Click

        Dim heal As Integer = LBLArenaCurrentMP.Text + skill_damage_modifier
        playsound("Nardina_Skill_5", True)
        LBLArenaCurrentMP.Text = 0

        If (LBLArenaCurrentHP.Text + heal) > LBLArenaMaxHP.Text Then
            LBLArenaCurrentHP.Text = LBLArenaMaxHP.Text
        Else
            LBLArenaCurrentHP.Text += heal
        End If

        'WHEN SKILL IS USED, SAVE THE TURN THE SKILL WAS USED ON
        nardina_skill_5_CD = turn_counter

        CMDNardinaSkill5.Enabled = False
        CMDNardinaSkill5.Text = "X"

        TXTCombatLog.Text = "You converted all your mana into health." & vbCrLf & vbCrLf & vbCrLf & TXTCombatLog.Text
        check_round_status()

    End Sub

    Private Sub CMDNylathriaSkill1_Click(sender As Object, e As EventArgs) Handles CMDNylathriaSkill1.Click
        'DO THE SKILL
        If LBLArenaCurrentMP.Text - 20 >= 0 Then
            LBLArenaCurrentMP.Text -= 20
            playsound("Nylathria_Skill_1", True)
            'damage calculation
            Dim damage As Integer = 40 + skill_damage_modifier

            damage_target(damage, -1)

            If (LBLArenaCurrentMP.Text + damage) > LBLArenaMaxMP.Text Then
                LBLArenaCurrentMP.Text = LBLArenaMaxMP.Text
            Else
                LBLArenaCurrentMP.Text += damage
            End If

            'WHEN SKILL IS USED, SAVE THE TURN THE SKILL WAS USED ON
            nylathria_skill_1_CD = turn_counter

            CMDNylathriaSkill1.Enabled = False
            CMDNylathriaSkill1.Text = "X"

            TXTCombatLog.Text = "You hit a random foe for " & damage & " damage and regained " & damage & " mana." & vbCrLf & vbCrLf & TXTCombatLog.Text
            check_round_status()

        Else
            TXTCombatLog.Text = "You don't have enough mana to use that skill" & vbCrLf & vbCrLf & TXTCombatLog.Text
        End If
    End Sub
    Private Sub CMDNylathriaSkill2_Click(sender As Object, e As EventArgs) Handles CMDNylathriaSkill2.Click
        'DO THE SKILL
        If LBLArenaCurrentMP.Text - 30 >= 0 Then
            LBLArenaCurrentMP.Text -= 30
            playsound("Nylathria_Skill_2", True)
            Dim damage As Integer = 10 + skill_damage_modifier
            Dim heal As Integer = damage * Math.Ceiling(LBLLevel.Text / 4)

            If (LBLArenaCurrentHP.Text + heal) > LBLArenaMaxHP.Text Then
                LBLArenaCurrentHP.Text = LBLArenaMaxHP.Text
            Else
                LBLArenaCurrentHP.Text += heal
            End If

            damage_target(damage, 1)
            damage_target(damage, 2)
            damage_target(damage, 3)
            damage_target(damage, 4)
            damage_target(damage, 5)

            'WHEN SKILL IS USED, SAVE THE TURN THE SKILL WAS USED ON
            nylathria_skill_2_CD = turn_counter

            CMDNylathriaSkill2.Enabled = False
            CMDNylathriaSkill2.Text = "X"

            TXTCombatLog.Text = "You hit all foes for " & damage & " damage and regained " & heal & " health." & vbCrLf & vbCrLf & TXTCombatLog.Text




            check_round_status()
        Else
            TXTCombatLog.Text = "You don't have enough mana to use that skill" & vbCrLf & vbCrLf & TXTCombatLog.Text
        End If
    End Sub
    Private Sub CMDNylathriaSkill3_Click(sender As Object, e As EventArgs) Handles CMDNylathriaSkill3.Click
        'DO THE SKILL
        If LBLArenaCurrentMP.Text - 25 >= 0 Then
            LBLArenaCurrentMP.Text -= 25
            playsound("Nylathria_Skill_3", True)
            'damage calculation
            Dim damage As Integer = 50 + skill_damage_modifier
            Dim add_damage As Integer = 100 + skill_damage_modifier

            'Create list of all valid targets
            Dim valid_targets As New List(Of Integer)

            If GRBFoe1.Visible = True Then
                valid_targets.Add(1)
            End If
            If GRBFoe2.Visible = True Then
                valid_targets.Add(2)
            End If
            If GRBFoe2.Visible = True Then
                valid_targets.Add(3)
            End If
            If GRBFoe3.Visible = True Then
                valid_targets.Add(4)
            End If
            If GRBFoe4.Visible = True Then
                valid_targets.Add(5)
            End If

            'Pick a random foe from all valid foes
            Randomize()
            Dim target_RNG As Integer = Int(((valid_targets.Count - 1) * Rnd()) + 0)

            Select Case valid_targets(target_RNG)
                Case 1
                    If LBLArenaFoe1CurrentHP.Text = LBLArenaFoe1MaxHP.Text Then damage += add_damage
                    damage_target(damage, 1)
                Case 2
                    If LBLArenaFoe2CurrentHP.Text = LBLArenaFoe2MaxHP.Text Then damage += add_damage
                    damage_target(damage, 2)
                Case 3
                    If LBLArenaFoe3CurrentHP.Text = LBLArenaFoe3MaxHP.Text Then damage += add_damage
                    damage_target(damage, 3)
                Case 4
                    If LBLArenaFoe4CurrentHP.Text = LBLArenaFoe4MaxHP.Text Then damage += add_damage
                    damage_target(damage, 4)
                Case 5
                    If LBLArenaFoe5CurrentHP.Text = LBLArenaFoe5MaxHP.Text Then damage += add_damage
                    damage_target(damage, 5)
            End Select


            'WHEN SKILL IS USED, SAVE THE TURN THE SKILL WAS USED ON
            nylathria_skill_3_CD = turn_counter

            CMDNylathriaSkill3.Enabled = False
            CMDNylathriaSkill3.Text = "X"

            TXTCombatLog.Text = "You hit a random foe for " & damage & " damage." & vbCrLf & vbCrLf & TXTCombatLog.Text
            check_round_status()

        Else
            TXTCombatLog.Text = "You don't have enough mana to use that skill" & vbCrLf & vbCrLf & TXTCombatLog.Text
        End If
    End Sub
    Private Sub CMDNylathriaSkill4_Click(sender As Object, e As EventArgs) Handles CMDNylathriaSkill4.Click
        'DO THE SKILL
        Dim damage As Integer = 50 + skill_damage_modifier
        playsound("Nylathria_Skill_4", True)

        LBLArenaCurrentHP.Text -= 50


        If (LBLArenaCurrentMP.Text + damage) > LBLArenaMaxMP.Text Then
            LBLArenaCurrentMP.Text = LBLArenaMaxMP.Text
        Else
            LBLArenaCurrentMP.Text += damage
        End If


        'WHEN SKILL IS USED, SAVE THE TURN THE SKILL WAS USED ON
        nylathria_skill_4_CD = turn_counter

        CMDNylathriaSkill4.Enabled = False
        CMDNylathriaSkill4.Text = "X"

        TXTCombatLog.Text = "You lost 50 health and regained " & damage & " mana." & vbCrLf & vbCrLf & TXTCombatLog.Text
        check_round_status()

    End Sub
    Private Sub CMDNylathriaSkill5_Click(sender As Object, e As EventArgs) Handles CMDNylathriaSkill5.Click
        'DO THE SKILL
        If LBLArenaCurrentMP.Text - 10 >= 0 Then
            LBLArenaCurrentMP.Text -= 10
            playsound("Nylathria_Skill_5", True)
            Dim self_damage As Integer = Math.Floor(LBLArenaCurrentHP.Text / 2)
            Dim damage As Integer = self_damage + skill_damage_modifier

            LBLArenaCurrentHP.Text -= self_damage

            damage_target(damage, 1)
            damage_target(damage, 2)
            damage_target(damage, 3)
            damage_target(damage, 4)
            damage_target(damage, 5)

            'WHEN SKILL IS USED, SAVE THE TURN THE SKILL WAS USED ON
            nylathria_skill_5_CD = turn_counter
            CMDNylathriaSkill5.Enabled = False
            CMDNylathriaSkill5.Text = "X"

            TXTCombatLog.Text = "You took " & self_damage & " damage and dealt " & damage & " damage to all foes." & vbCrLf & vbCrLf & TXTCombatLog.Text

            check_round_status()
        Else
            TXTCombatLog.Text = "You don't have enough mana to use that skill" & vbCrLf & vbCrLf & TXTCombatLog.Text
        End If
    End Sub

    Private Sub CMDSagraxesSkill1_Click(sender As Object, e As EventArgs) Handles CMDSagraxesSkill1.Click
        'check if player has enough mana to use this skill
        If LBLArenaCurrentMP.Text - 20 >= 0 Then
            LBLArenaCurrentMP.Text -= 20
            playsound("Sagraxes_Skill_1", True)
            Dim main_damage As Integer = 20 + skill_damage_modifier
            Dim side_damage As Integer = 10 + skill_damage_modifier

            Dim target_main_damage As Integer = 0

            'THIS IS WHERE THE SKILL HAPPENS

            'DECIDE WHICH FOE TO HIT
            If GRBFoe2.Visible = True Then
                target_main_damage = 2
                'hit foe 2 with main damage
                damage_target(main_damage, 2)
            ElseIf GRBFoe3.Visible = True Then
                target_main_damage = 3
                'hit foe 3 with main damage
                damage_target(main_damage, 3)
            ElseIf GRBFoe4.Visible = True Then
                target_main_damage = 4
                'hit foe 4 with main damage
                damage_target(main_damage, 4)
            ElseIf GRBFoe1.Visible = True Then
                target_main_damage = 1
                'hit foe 1 with main damage
                damage_target(main_damage, 1)
            Else
                target_main_damage = 5
                'hit foe 5 with main damage
                damage_target(main_damage, 5)
            End If


            If target_main_damage = 1 Then
                'hit target 2 with side damage
                damage_target(side_damage, 2)
            ElseIf target_main_damage = 2 Then
                'hit target 1 with side damage
                damage_target(side_damage, 1)
                'hit target 3 with side damage
                damage_target(side_damage, 3)
            ElseIf target_main_damage = 3 Then
                'hit target 2 with side damage
                damage_target(side_damage, 2)
                'hit target 4 with side damage
                damage_target(side_damage, 4)
            ElseIf target_main_damage = 4 Then
                'hit target 3 with side damage
                damage_target(side_damage, 3)
                'hit target 5 with side damage
                damage_target(side_damage, 5)
            Else
                'hit target 4 with side damage
                damage_target(side_damage, 4)
            End If

            'WHEN SKILL IS USED, SAVE THE TURN THE SKILL WAS USED ON
            sagraxes_skill_1_CD = turn_counter

            CMDSagraxesSkill1.Enabled = False
            CMDSagraxesSkill1.Text = "X"



            TXTCombatLog.Text = "You hit a centered foe for " & main_damage & " damage and adjacent foes for " & side_damage & " damage." & vbCrLf & vbCrLf & TXTCombatLog.Text
            check_round_status()

        Else
            TXTCombatLog.Text = "You don't have enough mana to use that skill" & vbCrLf & vbCrLf & TXTCombatLog.Text
        End If
    End Sub
    Private Sub CMDSagraxesSkill2_Click(sender As Object, e As EventArgs) Handles CMDSagraxesSkill2.Click
        'DO THE SKILL
        If LBLArenaCurrentMP.Text - 20 >= 0 Then
            LBLArenaCurrentMP.Text -= 20
            Dim damage As Integer = 10 + skill_damage_modifier
            playsound("Sagraxes_Skill_2", True)
            damage_target(damage, 1)
            damage_target(damage, 2)
            damage_target(damage, 3)
            damage_target(damage, 4)
            damage_target(damage, 5)


            'WHEN SKILL IS USED, SAVE THE TURN THE SKILL WAS USED ON
            sagraxes_skill_2_CD = turn_counter

            CMDSagraxesSkill2.Enabled = False
            CMDSagraxesSkill2.Text = "X"

            TXTCombatLog.Text = "You hit all foes for " & damage & " damage." & vbCrLf & vbCrLf & TXTCombatLog.Text

            check_round_status()
        Else
            TXTCombatLog.Text = "You don't have enough mana to use that skill" & vbCrLf & vbCrLf & TXTCombatLog.Text
        End If


    End Sub
    Private Sub CMDSagraxesSkill3_Click(sender As Object, e As EventArgs) Handles CMDSagraxesSkill3.Click
        'DO THE SKILL
        If LBLArenaCurrentMP.Text - 30 >= 0 Then
            LBLArenaCurrentMP.Text -= 30
            playsound("Sagraxes_Skill_3", True)
            'damage calculation
            Dim damage As Integer = 50 + skill_damage_modifier

            'GET TARGET WITH HIGHEST HP
            Dim vals As Integer() = {LBLArenaFoe1CurrentHP.Text, LBLArenaFoe2CurrentHP.Text, LBLArenaFoe3CurrentHP.Text, LBLArenaFoe4CurrentHP.Text, LBLArenaFoe5CurrentHP.Text}
            Dim largest As Integer
            For Each element As Integer In vals
                largest = Math.Max(largest, element)
            Next

            If LBLArenaFoe1CurrentHP.Text = largest Then
                damage_target(damage, 1)
            ElseIf LBLArenaFoe2CurrentHP.Text = largest Then
                damage_target(damage, 2)
            ElseIf LBLArenaFoe3CurrentHP.Text = largest Then
                damage_target(damage, 3)
            ElseIf LBLArenaFoe4CurrentHP.Text = largest Then
                damage_target(damage, 4)
            ElseIf LBLArenaFoe5CurrentHP.Text = largest Then
                damage_target(damage, 5)
            End If

            'WHEN SKILL IS USED, SAVE THE TURN THE SKILL WAS USED ON
            sagraxes_skill_3_CD = turn_counter

            CMDSagraxesSkill3.Enabled = False
            CMDSagraxesSkill3.Text = "X"


            TXTCombatLog.Text = "You hit the healthies foe for " & damage & " damage." & vbCrLf & vbCrLf & TXTCombatLog.Text
            check_round_status()

        Else
            TXTCombatLog.Text = "You don't have enough mana to use that skill" & vbCrLf & vbCrLf & TXTCombatLog.Text
        End If
    End Sub
    Private Sub CMDSagraxesSkill4_Click(sender As Object, e As EventArgs) Handles CMDSagraxesSkill4.Click
        'DO THE SKILL
        If LBLArenaCurrentMP.Text - 25 >= 0 Then
            LBLArenaCurrentMP.Text -= 25
            playsound("Sagraxes_Skill_4", True)
            'damage calculation
            Dim damage As Integer = 30 + skill_damage_modifier



            'perform two random attacks
            For i As Integer = 1 To 2
                damage_target(damage, -1)
            Next

            'WHEN SKILL IS USED, SAVE THE TURN THE SKILL WAS USED ON
            sagraxes_skill_4_CD = turn_counter

            CMDSagraxesSkill4.Enabled = False
            CMDSagraxesSkill4.Text = "X"


            TXTCombatLog.Text = "You hit two random foes for " & damage & " damage." & vbCrLf & vbCrLf & TXTCombatLog.Text
            check_round_status()

        Else
            TXTCombatLog.Text = "You don't have enough mana to use that skill" & vbCrLf & vbCrLf & TXTCombatLog.Text
        End If
    End Sub
    Private Sub CMDSagraxesSkill5_Click(sender As Object, e As EventArgs) Handles CMDSagraxesSkill5.Click
        'DO THE SKILL
        If LBLArenaCurrentMP.Text - 25 >= 0 Then
            LBLArenaCurrentMP.Text -= 25
            playsound("Sagraxes_Skill_5", True)
            Dim heal As Integer = 10 + skill_damage_modifier

            is_blocking = True

            If (LBLArenaCurrentHP.Text + heal) > LBLArenaMaxHP.Text Then
                LBLArenaCurrentHP.Text = LBLArenaMaxHP.Text
            Else
                LBLArenaCurrentHP.Text += heal
            End If



            'WHEN SKILL IS USED, SAVE THE TURN THE SKILL WAS USED ON
            sagraxes_skill_5_CD = turn_counter

            CMDSagraxesSkill5.Enabled = False
            CMDSagraxesSkill5.Text = "X"

            TXTCombatLog.Text = "You will block the next incomming attack and healed for " & heal & "." & vbCrLf & vbCrLf & TXTCombatLog.Text
            check_round_status()

        Else
            TXTCombatLog.Text = "You don't have enough mana to use that skill" & vbCrLf & vbCrLf & TXTCombatLog.Text
        End If
    End Sub


End Class


