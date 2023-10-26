Imports System.IO
Imports System.IO.Path
Public Class Achievements

    'Dim piece_locks(8) As Integer
    Dim piece_locks = New Integer() {1, 1, 1, 1, 1, 1, 1, 1, 1}

    Dim has_key As Boolean = False

    Private Sub load_progression_save()

        Dim progress As StreamReader = My.Computer.FileSystem.OpenTextFileReader("G:\Final Thrust\player_data\progression.ini")


        For i As Integer = 0 To 8
            piece_locks(i) = Convert.ToInt32(progress.ReadLine)
            If i <> 0 Then
                display_locks(i, piece_locks(i))
            Else
                LBLProgressionLevel.Text = piece_locks(0)
            End If
            ' i += 1
        Next

        progress.Close()



    End Sub


    Private Sub PCBPiece_Click(sender As Object, e As EventArgs) Handles PCBPiece1.Click, PCBPiece2.Click, PCBPiece3.Click, PCBPiece4.Click, PCBPiece5.Click, PCBPiece6.Click, PCBPiece7.Click, PCBPiece8.Click
        'use and remove a key from inventory if they have one
        Dim item_index As Integer = 0
        For Each item In Form1.LSBInventory.Items

            If item.contains("Glowing Key") Then 'glowing key ID
                has_key = True
                Form1.LSBInventory.Items.RemoveAt(item_index)
                Exit For
            End If
            item_index += 1
        Next

        'if player has a key, use it
        If has_key = True Then
            Form1.playsound("usekey", True)
            Select Case sender.name
                Case "PCBPiece1"
                    piece_locks(1) -= 1
                    display_locks(1, piece_locks(1))
                Case "PCBPiece2"
                    piece_locks(2) -= 1
                    display_locks(2, piece_locks(2))
                Case "PCBPiece3"
                    piece_locks(3) -= 1
                    display_locks(3, piece_locks(3))
                Case "PCBPiece4"
                    piece_locks(4) -= 1
                    display_locks(4, piece_locks(4))
                Case "PCBPiece5"
                    piece_locks(5) -= 1
                    display_locks(5, piece_locks(5))
                Case "PCBPiece6"
                    piece_locks(6) -= 1
                    display_locks(6, piece_locks(6))
                Case "PCBPiece7"
                    piece_locks(7) -= 1
                    display_locks(7, piece_locks(7))
                Case "PCBPiece8"
                    piece_locks(8) -= 1
                    display_locks(8, piece_locks(8))
            End Select
            PGBProgress.Value += 1
            has_key = False


        Else
            Form1.playsound("warning", False)
            MessageBox.Show("You do not own a glowing key!", "ERROR", MessageBoxButtons.OK)
        End If
        save_progression()
    End Sub


    Private Sub display_locks(piece_no As Integer, locks As Integer)
        'MsgBox("display_lock called with piece_no " & piece_no & " and amount of locks " & locks)
        Select Case locks
            Case 1
                Select Case piece_no
                    Case 1
                        PCBPiece1.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_1.png"
                        PCBPiece1.BorderStyle = BorderStyle.FixedSingle
                    Case 2
                        PCBPiece2.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_1.png"
                        PCBPiece2.BorderStyle = BorderStyle.FixedSingle
                    Case 3
                        PCBPiece3.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_1.png"
                        PCBPiece3.BorderStyle = BorderStyle.FixedSingle
                    Case 4
                        PCBPiece4.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_1.png"
                        PCBPiece4.BorderStyle = BorderStyle.FixedSingle
                    Case 5
                        PCBPiece5.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_1.png"
                        PCBPiece5.BorderStyle = BorderStyle.FixedSingle
                    Case 6
                        PCBPiece6.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_1.png"
                        PCBPiece6.BorderStyle = BorderStyle.FixedSingle
                    Case 7
                        PCBPiece7.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_1.png"
                        PCBPiece7.BorderStyle = BorderStyle.FixedSingle
                    Case 8
                        PCBPiece8.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_1.png"
                        PCBPiece8.BorderStyle = BorderStyle.FixedSingle
                End Select

            Case 2
                Select Case piece_no
                    Case 1
                        PCBPiece1.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_2.png"
                        PCBPiece1.BorderStyle = BorderStyle.FixedSingle
                    Case 2
                        PCBPiece2.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_2.png"
                        PCBPiece2.BorderStyle = BorderStyle.FixedSingle
                    Case 3
                        PCBPiece3.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_2.png"
                        PCBPiece3.BorderStyle = BorderStyle.FixedSingle
                    Case 4
                        PCBPiece4.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_2.png"
                        PCBPiece4.BorderStyle = BorderStyle.FixedSingle
                    Case 5
                        PCBPiece5.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_2.png"
                        PCBPiece5.BorderStyle = BorderStyle.FixedSingle
                    Case 6
                        PCBPiece6.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_2.png"
                        PCBPiece6.BorderStyle = BorderStyle.FixedSingle
                    Case 7
                        PCBPiece7.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_2.png"
                        PCBPiece7.BorderStyle = BorderStyle.FixedSingle
                    Case 8
                        PCBPiece8.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_2.png"
                        PCBPiece8.BorderStyle = BorderStyle.FixedSingle
                End Select
            Case 3
                Select Case piece_no
                    Case 1
                        PCBPiece1.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_3.png"
                        PCBPiece1.BorderStyle = BorderStyle.FixedSingle
                    Case 2
                        PCBPiece2.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_3.png"
                        PCBPiece2.BorderStyle = BorderStyle.FixedSingle
                    Case 3
                        PCBPiece3.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_3.png"
                        PCBPiece3.BorderStyle = BorderStyle.FixedSingle
                    Case 4
                        PCBPiece4.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_3.png"
                        PCBPiece4.BorderStyle = BorderStyle.FixedSingle
                    Case 5
                        PCBPiece5.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_3.png"
                        PCBPiece5.BorderStyle = BorderStyle.FixedSingle
                    Case 6
                        PCBPiece6.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_3.png"
                        PCBPiece6.BorderStyle = BorderStyle.FixedSingle
                    Case 7
                        PCBPiece7.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_3.png"
                        PCBPiece7.BorderStyle = BorderStyle.FixedSingle
                    Case 8
                        PCBPiece8.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_3.png"
                        PCBPiece8.BorderStyle = BorderStyle.FixedSingle
                End Select
            Case 4
                Select Case piece_no
                    Case 1
                        PCBPiece1.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_4.png"
                        PCBPiece1.BorderStyle = BorderStyle.FixedSingle
                    Case 2
                        PCBPiece2.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_4.png"
                        PCBPiece2.BorderStyle = BorderStyle.FixedSingle
                    Case 3
                        PCBPiece3.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_4.png"
                        PCBPiece3.BorderStyle = BorderStyle.FixedSingle
                    Case 4
                        PCBPiece4.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_4.png"
                        PCBPiece4.BorderStyle = BorderStyle.FixedSingle
                    Case 5
                        PCBPiece5.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_4.png"
                        PCBPiece5.BorderStyle = BorderStyle.FixedSingle
                    Case 6
                        PCBPiece6.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_4.png"
                        PCBPiece6.BorderStyle = BorderStyle.FixedSingle
                    Case 7
                        PCBPiece7.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_4.png"
                        PCBPiece7.BorderStyle = BorderStyle.FixedSingle
                    Case 8
                        PCBPiece8.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_4.png"
                        PCBPiece8.BorderStyle = BorderStyle.FixedSingle
                End Select
            Case 5
                Select Case piece_no
                    Case 1
                        PCBPiece1.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_5.png"
                        PCBPiece1.BorderStyle = BorderStyle.FixedSingle
                    Case 2
                        PCBPiece2.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_5.png"
                        PCBPiece2.BorderStyle = BorderStyle.FixedSingle
                    Case 3
                        PCBPiece3.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_5.png"
                        PCBPiece3.BorderStyle = BorderStyle.FixedSingle
                    Case 4
                        PCBPiece4.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_5.png"
                        PCBPiece4.BorderStyle = BorderStyle.FixedSingle
                    Case 5
                        PCBPiece5.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_5.png"
                        PCBPiece5.BorderStyle = BorderStyle.FixedSingle
                    Case 6
                        PCBPiece6.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_5.png"
                        PCBPiece6.BorderStyle = BorderStyle.FixedSingle
                    Case 7
                        PCBPiece7.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_5.png"
                        PCBPiece7.BorderStyle = BorderStyle.FixedSingle
                    Case 8
                        PCBPiece8.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_5.png"
                        PCBPiece8.BorderStyle = BorderStyle.FixedSingle
                End Select
            Case Else

                Dim file = Directory.GetFiles("G:\Final Thrust\game_data\progression\image_" & LBLProgressionLevel.Text, "*.*", SearchOption.TopDirectoryOnly)
                Dim file_extension As String = Path.GetExtension(file(0))
                'MsgBox(file_extension)

                Select Case piece_no
                        Case 1
                            PCBPiece1.ImageLocation = "G:\Final Thrust\game_data\progression\image_" & LBLProgressionLevel.Text & "\" & piece_no & file_extension
                        PCBPiece1.BorderStyle = BorderStyle.None
                        PCBPiece1.Enabled = False
                    Case 2
                            PCBPiece2.ImageLocation = "G:\Final Thrust\game_data\progression\image_" & LBLProgressionLevel.Text & "\" & piece_no & file_extension
                        PCBPiece2.BorderStyle = BorderStyle.None
                        PCBPiece2.Enabled = False
                    Case 3
                            PCBPiece3.ImageLocation = "G:\Final Thrust\game_data\progression\image_" & LBLProgressionLevel.Text & "\" & piece_no & file_extension
                        PCBPiece3.BorderStyle = BorderStyle.None
                        PCBPiece3.Enabled = False
                    Case 4
                            PCBPiece4.ImageLocation = "G:\Final Thrust\game_data\progression\image_" & LBLProgressionLevel.Text & "\" & piece_no & file_extension
                        PCBPiece4.BorderStyle = BorderStyle.None
                        PCBPiece4.Enabled = False
                    Case 5
                            PCBPiece5.ImageLocation = "G:\Final Thrust\game_data\progression\image_" & LBLProgressionLevel.Text & "\" & piece_no & file_extension
                        PCBPiece5.BorderStyle = BorderStyle.None
                        PCBPiece5.Enabled = False
                    Case 6
                            PCBPiece6.ImageLocation = "G:\Final Thrust\game_data\progression\image_" & LBLProgressionLevel.Text & "\" & piece_no & file_extension
                        PCBPiece6.BorderStyle = BorderStyle.None
                        PCBPiece6.Enabled = False
                    Case 7
                            PCBPiece7.ImageLocation = "G:\Final Thrust\game_data\progression\image_" & LBLProgressionLevel.Text & "\" & piece_no & file_extension
                        PCBPiece7.BorderStyle = BorderStyle.None
                        PCBPiece7.Enabled = False
                    Case 8
                            PCBPiece8.ImageLocation = "G:\Final Thrust\game_data\progression\image_" & LBLProgressionLevel.Text & "\" & piece_no & file_extension
                        PCBPiece8.BorderStyle = BorderStyle.None
                        PCBPiece8.Enabled = False
                End Select


                If (piece_locks(1) = 0) And (piece_locks(2) = 0) And (piece_locks(3) = 0) And (piece_locks(4) = 0) And (piece_locks(5) = 0) And (piece_locks(6) = 0) And (piece_locks(7) = 0) And (piece_locks(8) = 0) Then
                    Form1.playsound("achievement", True)
                    MsgBox("Progression level " & LBLProgressionLevel.Text & " completed!")
                    CBBUnlockedImages.Items.Add("FT_Reward_Image_" & LBLProgressionLevel.Text)
                    If LBLProgressionLevel.Text < 12 Then
                        LBLProgressionLevel.Text += 1
                        reset_progression_image()
                        piece_autosize()
                    Else
                        piece_autosize()
                        Form1.add_item_to_inventory("Infinity Warglaive of Devastation")
                        Form1.add_item_to_inventory("Infinity Warglaive of Havoc")
                        Form1.LBLGold.Text += 1000000
                        MsgBox("All progression levels completed!" & vbCrLf & vbCrLf & "Congratulations!")
                        MsgBox("You received Infinity Warglaive of Devastation" & vbCrLf & vbCrLf & "You received Infinity Warglaive of Havoc" & vbCrLf & vbCrLf & "You received 1.000.000 gold!")
                    End If
                End If
        End Select
    End Sub

    Private Sub reset_progression_image()
        piece_locks(0) = LBLProgressionLevel.Text
        piece_locks(1) = 2
        piece_locks(2) = 2
        piece_locks(3) = 1
        piece_locks(4) = 4
        piece_locks(5) = 1
        piece_locks(6) = 5
        piece_locks(7) = 3
        piece_locks(8) = 3

        PCBPiece1.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_2.png"
        PCBPiece2.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_2.png"
        PCBPiece3.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_1.png"
        PCBPiece4.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_4.png"
        PCBPiece5.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_1.png"
        PCBPiece6.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_5.png"
        PCBPiece7.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_3.png"
        PCBPiece8.ImageLocation = "G:\Final Thrust\game_data\progression\locks\lock_3.png"

        PCBPiece1.BorderStyle = BorderStyle.FixedSingle
        PCBPiece2.BorderStyle = BorderStyle.FixedSingle
        PCBPiece3.BorderStyle = BorderStyle.FixedSingle
        PCBPiece4.BorderStyle = BorderStyle.FixedSingle
        PCBPiece5.BorderStyle = BorderStyle.FixedSingle
        PCBPiece6.BorderStyle = BorderStyle.FixedSingle
        PCBPiece7.BorderStyle = BorderStyle.FixedSingle
        PCBPiece8.BorderStyle = BorderStyle.FixedSingle

        PCBPiece1.Enabled = True
        PCBPiece2.Enabled = True
        PCBPiece3.Enabled = True
        PCBPiece4.Enabled = True
        PCBPiece5.Enabled = True
        PCBPiece6.Enabled = True
        PCBPiece7.Enabled = True
        PCBPiece8.Enabled = True

    End Sub

    Private Sub save_progression()
        System.IO.File.WriteAllText("G:\Final Thrust\player_data\progression.ini", LBLProgressionLevel.Text & vbCrLf & piece_locks(1) & vbCrLf & piece_locks(2) & vbCrLf & piece_locks(3) & vbCrLf & piece_locks(4) & vbCrLf & piece_locks(5) & vbCrLf & piece_locks(6) & vbCrLf & piece_locks(7) & vbCrLf & piece_locks(8))
        'MsgBox(LBLProgressionLevel.Text & vbCrLf & piece_locks(1) & vbCrLf & piece_locks(2) & vbCrLf & piece_locks(3) & vbCrLf & piece_locks(4) & vbCrLf & piece_locks(5) & vbCrLf & piece_locks(6) & vbCrLf & piece_locks(7) & vbCrLf & piece_locks(8))
    End Sub

    Private Sub Achievements_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_progression_save()
        load_progress()
        piece_autosize()
    End Sub
    Private Sub load_progress()

        'display progressbar
        Dim progression_progress As Integer = 0
        progression_progress = (LBLProgressionLevel.Text * 21) '- 21

        For i As Integer = 1 To 8
            progression_progress -= piece_locks(i)
        Next

        PGBProgress.Value = progression_progress

        'load completed images into combobox
        For j As Integer = 0 To (LBLProgressionLevel.Text - 1)
            If j <> 0 Then CBBUnlockedImages.Items.Add("FT_Reward_Image_" & j)

        Next
    End Sub

    Private Sub CMDDownload_Click(sender As Object, e As EventArgs) Handles CMDDownload.Click
        If CBBUnlockedImages.SelectedItem <> "" Then
            Dim extension As String
            For Each file In Directory.GetFiles("G:\Final Thrust\game_data\progression\rewards")
                'MsgBox("does " & Path.GetFileName(file) & " contain " & CBBUnlockedImages.SelectedItem & "?")
                If Path.GetFileName(file).Contains(CBBUnlockedImages.SelectedItem) Then
                    extension = Path.GetExtension(file)
                    My.Computer.FileSystem.CopyFile(file, My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & Path.GetFileName(file), overwrite:=False)
                    MessageBox.Show("Image downloaded to desktop!", "SUCCESS", MessageBoxButtons.OK)
                    Exit For
                End If
            Next
        Else
            MessageBox.Show("No image selected!", "ERROR", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub piece_autosize()
        'Create bitmap for each puzzle piece

        Dim pictures(8 - 1) As Bitmap 'create an array that can hold 10 Bitmaps



        Dim bitmap_index As Integer = 0
        Dim P1_bitmaps As String = "G:\Final Thrust\game_data\progression\image_" & LBLProgressionLevel.Text



        For Each copyFile In Directory.GetFiles(P1_bitmaps, "*.*", SearchOption.TopDirectoryOnly)
            pictures(bitmap_index) = New Bitmap(copyFile) 'create a new Bitmap object and assign it to the array.
            bitmap_index += 1
        Next



        PCBPiece1.Left = 3
        PCBPiece1.Top = 2
        PCBPiece1.Height = pictures(0).Height
        PCBPiece1.Width = pictures(0).Width

        PCBPiece2.Left = PCBPiece1.Left + PCBPiece1.Width
        PCBPiece2.Top = PCBPiece1.Top
        PCBPiece2.Height = pictures(1).Height
        PCBPiece2.Width = pictures(1).Width

        PCBPiece3.Left = PCBPiece1.Left
        PCBPiece3.Top = PCBPiece1.Top + PCBPiece1.Height
        PCBPiece3.Height = pictures(2).Height
        PCBPiece3.Width = pictures(2).Width

        PCBPiece4.Left = PCBPiece1.Left + PCBPiece3.Width
        PCBPiece4.Top = PCBPiece1.Top + PCBPiece1.Height
        PCBPiece4.Height = pictures(3).Height
        PCBPiece4.Width = pictures(3).Width

        PCBPiece5.Left = PCBPiece1.Left + PCBPiece3.Width + PCBPiece4.Width
        PCBPiece5.Top = PCBPiece1.Top + PCBPiece1.Height
        PCBPiece5.Height = pictures(4).Height
        PCBPiece5.Width = pictures(4).Width

        PCBPiece6.Left = PCBPiece1.Left + PCBPiece3.Width
        PCBPiece6.Top = PCBPiece1.Top + PCBPiece1.Height + PCBPiece4.Height
        PCBPiece6.Height = pictures(5).Height
        PCBPiece6.Width = pictures(5).Width

        PCBPiece7.Left = PCBPiece1.Left
        PCBPiece7.Top = PCBPiece1.Top + PCBPiece1.Height + PCBPiece3.Height
        PCBPiece7.Height = pictures(6).Height
        PCBPiece7.Width = pictures(6).Width

        PCBPiece8.Left = (PCBPiece1.Left + PCBPiece1.Width + PCBPiece2.Width) - pictures(7).Width
        PCBPiece8.Top = PCBPiece1.Top + PCBPiece2.Height + PCBPiece5.Height
        PCBPiece8.Height = pictures(7).Height
        PCBPiece8.Width = pictures(7).Width

        GRBUnlocks.Left = PCBPiece2.Left + pictures(1).Width + 1
        GRBUnlocks.Top = -6
        GRBUnlocks.Height = PCBPiece1.Top + PCBPiece1.Height + PCBPiece3.Height + PCBPiece7.Height + 8

        PGBProgress.Top = PCBPiece1.Top + PCBPiece1.Height + PCBPiece3.Height + PCBPiece7.Height + 2

        PCBEndReward.Left = PGBProgress.Left + PGBProgress.Width + 2
        PCBEndReward.Top = PGBProgress.Top

        LBLmnuDash1.Top = PGBProgress.Top + 29
        LBLmnuDash2.Top = PGBProgress.Top + 29
        LBLmnuDash3.Top = PGBProgress.Top + 29
        LBLmnuDash4.Top = PGBProgress.Top + 29
        LBLmnuDash5.Top = PGBProgress.Top + 29
        LBLmnuDash6.Top = PGBProgress.Top + 29
        LBLmnuDash7.Top = PGBProgress.Top + 29
        LBLmnuDash8.Top = PGBProgress.Top + 29
        LBLmnuDash9.Top = PGBProgress.Top + 29
        LBLmnuDash10.Top = PGBProgress.Top + 29
        LBLmnuDash11.Top = PGBProgress.Top + 29
        LBLmnuDash12.Top = PGBProgress.Top + 29

        Me.Height = PGBProgress.Top + PGBProgress.Height + 2 + 70
        Me.Width = GRBUnlocks.Left + GRBUnlocks.Width + 2
    End Sub

    Private Sub PCBPiece1_MouseHover(sender As Object, e As EventArgs) Handles PCBPiece1.MouseHover, PCBPiece2.MouseHover, PCBPiece3.MouseHover, PCBPiece4.MouseHover, PCBPiece5.MouseHover, PCBPiece6.MouseHover, PCBPiece7.MouseHover, PCBPiece8.MouseHover
        Dim piece_no As Integer = Convert.ToInt32(sender.name.Substring(sender.name.Length - 1))
        sender.imagelocation = "G:\Final Thrust\game_data\progression\locks\lock_" & piece_locks(piece_no) & "_glow.png"
    End Sub
    Private Sub PCBPiece1_MouseLeave(sender As Object, e As EventArgs) Handles PCBPiece1.MouseLeave, PCBPiece2.MouseLeave, PCBPiece3.MouseLeave, PCBPiece4.MouseLeave, PCBPiece5.MouseLeave, PCBPiece6.MouseLeave, PCBPiece7.MouseLeave, PCBPiece8.MouseLeave
        Dim piece_no As Integer = Convert.ToInt32(sender.name.Substring(sender.name.Length - 1))
        sender.imagelocation = "G:\Final Thrust\game_data\progression\locks\lock_" & piece_locks(piece_no) & ".png"
    End Sub
End Class