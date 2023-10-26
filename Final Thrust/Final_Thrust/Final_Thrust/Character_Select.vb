Imports System.IO
Imports System.IO.Path

'1      −5
'2–3	−4
'4–5	−3
'6–7	−2
'8–9	−1
'10–11	+0      human average
'12–13	+1
'14–15	+2
'16–17	+3
'18–19	+4      end game
'20–21	+5
'22–23	+6
'24–25	+7
'26–27	+8
'28–29	+9
'30     +10     divine being

Public Class Character_Select
    Dim selected_character As String = ""
    Private Sub Character_Select_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim character_info_reader As StreamReader
        Dim character_name As String
        Dim character_portrait As String

        For Each file In Directory.GetFiles("G:\Final Thrust\player_data")
            If Path.GetFileName(file).Contains("_attributes.ini") Then

                'get character name
                Dim parts() As String = Path.GetFileName(file).Split("_")
                character_name = parts(0)

                'get character portrait location
                character_portrait = "G:\Final Thrust\game_data\game_characters\" & character_name & "\" & character_name & ".png"

                'MsgBox(Path.GetFullPath(file))
                character_info_reader = My.Computer.FileSystem.OpenTextFileReader(Path.GetFullPath(file))
                'skip first four line as they contain data we don't need
                character_info_reader.ReadLine()
                character_info_reader.ReadLine()
                character_info_reader.ReadLine()
                character_info_reader.ReadLine()

                Select Case character_name
                    Case "Alysha"
                        LBLAlyshaStrength.Text = character_info_reader.ReadLine
                        LBLAlyshaDexterity.Text = character_info_reader.ReadLine
                        LBLAlyshaConstitution.Text = character_info_reader.ReadLine
                        LBLAlyshaIntelligence.Text = character_info_reader.ReadLine
                        LBLAlyshaWisdom.Text = character_info_reader.ReadLine
                        LBLAlyshaCharisma.Text = character_info_reader.ReadLine
                        PCBAlysha.ImageLocation = character_portrait
                    Case "Makyr"
                        LBLMakyrStrength.Text = character_info_reader.ReadLine
                        LBLMakyrDexterity.Text = character_info_reader.ReadLine
                        LBLMakyrConstitution.Text = character_info_reader.ReadLine
                        LBLMakyrIntelligence.Text = character_info_reader.ReadLine
                        LBLMakyrWisdom.Text = character_info_reader.ReadLine
                        LBLMakyrCharisma.Text = character_info_reader.ReadLine
                        PCBMakyr.ImageLocation = character_portrait
                    Case "Nardina"
                        LBLNardinaStrength.Text = character_info_reader.ReadLine
                        LBLNardinaDexterity.Text = character_info_reader.ReadLine
                        LBLNardinaConstitution.Text = character_info_reader.ReadLine
                        LBLNardinaIntelligence.Text = character_info_reader.ReadLine
                        LBLNardinaWisdom.Text = character_info_reader.ReadLine
                        LBLNardinaCharisma.Text = character_info_reader.ReadLine
                        PCBNardina.ImageLocation = character_portrait
                    Case "Nylathria"
                        LBLNylathriaStrength.Text = character_info_reader.ReadLine
                        LBLNylathriaDexterity.Text = character_info_reader.ReadLine
                        LBLNylathriaConstitution.Text = character_info_reader.ReadLine
                        LBLNylathriaIntelligence.Text = character_info_reader.ReadLine
                        LBLNylathriaWisdom.Text = character_info_reader.ReadLine
                        LBLNylathriaCharisma.Text = character_info_reader.ReadLine
                        PCBNylathria.ImageLocation = character_portrait
                    Case "Sagraxes"
                        LBLSagraxesStrength.Text = character_info_reader.ReadLine
                        LBLSagraxesDexterity.Text = character_info_reader.ReadLine
                        LBLSagraxesConstitution.Text = character_info_reader.ReadLine
                        LBLSagraxesIntelligence.Text = character_info_reader.ReadLine
                        LBLSagraxesWisdom.Text = character_info_reader.ReadLine
                        LBLSagraxesCharisma.Text = character_info_reader.ReadLine
                        PCBSagraxes.ImageLocation = character_portrait
                End Select
                character_info_reader.Close()
            End If
        Next
    End Sub


    Private Sub pictureboxes_MouseHover(sender As Object, e As EventArgs) Handles PCBAlysha.MouseHover, PCBMakyr.MouseHover, PCBNardina.MouseHover, PCBNylathria.MouseHover, PCBSagraxes.MouseHover
        sender.borderstyle = BorderStyle.FixedSingle
    End Sub

    Private Sub pictureboxes_MouseLeave(sender As Object, e As EventArgs) Handles PCBAlysha.MouseLeave, PCBMakyr.MouseLeave, PCBNardina.MouseLeave, PCBNylathria.MouseLeave, PCBSagraxes.MouseLeave
        sender.borderstyle = BorderStyle.None
    End Sub
    Private Sub pictureboxes_Click(sender As Object, e As EventArgs) Handles PCBAlysha.Click, PCBMakyr.Click, PCBNardina.Click, PCBNylathria.Click, PCBSagraxes.Click

        selected_character = sender.name

        Select Case sender.name
            Case "PCBAlysha"
                Form1.PCBAvatar.ImageLocation = "G:\Final Thrust\game_data\game_characters\Alysha\Alysha.png"
                Form1.load_character("Alysha")
            Case "PCBMakyr"
                Form1.PCBAvatar.ImageLocation = "G:\Final Thrust\game_data\game_characters\Makyr\Makyr.png"
                Form1.load_character("Makyr")
            Case "PCBNardina"
                Form1.PCBAvatar.ImageLocation = "G:\Final Thrust\game_data\game_characters\Nardina\Nardina.png"
                Form1.load_character("Nardina")
            Case "PCBNylathria"
                Form1.PCBAvatar.ImageLocation = "G:\Final Thrust\game_data\game_characters\Nylathria\Nylathria.png"
                Form1.load_character("Nylathria")
            Case "PCBSagraxes"
                Form1.PCBAvatar.ImageLocation = "G:\Final Thrust\game_data\game_characters\Sagraxes\Sagraxes.png"
                Form1.load_character("Sagraxes")
        End Select

        Form1.update_attribute_modifiers()
        Form1.update_equipment_stats()

        Me.Close()

    End Sub


End Class