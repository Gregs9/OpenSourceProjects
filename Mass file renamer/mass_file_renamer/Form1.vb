Imports System
Imports System.IO
Public Class Form1
    Dim md5_hash As String
    Dim match As Boolean
    Dim files_affected As Integer = 0
    Dim files_checked As Integer = 0
    Dim extension As String


    Private Function get_md5(Filename As String)
        Dim MD5 = System.Security.Cryptography.MD5.Create
        Dim Hash As Byte()
        Dim sb As New System.Text.StringBuilder

        Using st As New IO.FileStream(Filename, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
            Hash = MD5.ComputeHash(st)
        End Using

        For Each b In Hash
            sb.Append(b.ToString("X2"))
        Next

        Return sb.ToString.ToLower
    End Function
    Private Function compare_filename_md5(Filename As String, md5 As String)
        'compare filename to md5
        If Path.GetFileNameWithoutExtension(Filename) = md5_hash Then
            match = True
        Else
            match = False
        End If
        Return match
    End Function

    Dim filesFictional() As String
    Dim filesFictionalHof() As String
    Private Sub CMDRename_Click(sender As Object, e As EventArgs) Handles CMDRename.Click

        filesFictionalHof = System.IO.Directory.GetFiles("Path Here", "*", IO.SearchOption.AllDirectories)
        BackgroundWorker1.RunWorkerAsync()




    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        TextBox1.Text = TextBox1.Text & filesFictionalHof.ToString & vbCrLf
        For Each filename As String In filesFictionalHof
            TextBox1.Text = TextBox1.Text & filename & vbCrLf
            files_checked += 1
        Next

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        LBLFilesAffected.Text = files_affected & " Files renamed."
        LBLFilesChecked.Text = files_checked & " Files checked"
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        MessageBox.Show("DONE")
    End Sub
End Class
