Imports System.Text.RegularExpressions
Public Class Form1
    Private Const zzV = "^(\d+\s*)(g|m|G|M|gb|mb|GB|MB|Gb|Mb|gB|mB)?$"
    Private Const zzS = "^(\d+\s*)(k|m|K|M|kb|mb|kB|mB|KB|MB|Kb|Mb|k\/s|m\/s|K\/s|M\/s|kb\/s|mb\/s|kB\/s|mB\/s|KB\/s|MB\/s|Kb\/s|Mb\/s|k\/S|m\/S|K\/S|M\/S|kb\/S|mb\/S|KB\/S|MB\/S|Kb\/S|Mb\/S|kB\/S|mB\/S)?$"
    Dim mV As Match
    Dim mS As Match

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Jisuan()
        mV = Regex.Match(TextBox_Volume.Text, zzV)
        Dim V As String = mV.Groups(2).ToString
        Dim Volume As Double = Val(mV.Groups(1).ToString)
        mS = Regex.Match(TextBox_Speed.Text, zzS)
        Dim S As String = mS.Groups(2).ToString
        Dim Speed As Double = Val(mS.Groups(1).ToString)
        If Volume <> 0 And Speed <> 0 Then
            Select Case V
                Case "M", "Mb", "m", "mb", "MB", "mB"
                    Volume = Volume * 1024
                Case Else
                    Volume = Volume * 1024 * 1024
            End Select
            Select Case S
                Case "M", "Mb", "m", "mb", "MB", "mB", "M/s", "Mb/s", "m/s", "mb/s", "MB/s", "mB/s", "M/S", "Mb/S", "m/S", "mb/S", "MB/S", "mB/S"
                    Speed = Speed * 1024
            End Select
            Dim timeS As Double = Volume / Speed
            Dim timeH As Double = timeS \ 3600
            Dim timeM As Double = (timeS Mod 3600) \ 60
            timeS = CInt(timeS Mod 60)
            Label_Out.Text = timeH & " h " & timeM & " m " & timeS & " s"
        Else
            Label_Out.Text = "00 h 00 m 00 s"
        End If
    End Sub

    Private Sub TextBox_SpeedChanged(sender As Object, e As EventArgs) Handles TextBox_Speed.TextChanged
        mS = Regex.Match(TextBox_Speed.Text, zzS)
        TextBox_Speed.Text = mS.Groups(0).ToString
        Jisuan()
    End Sub

    Private Sub TextBox_Volume_TextChanged(sender As Object, e As EventArgs) Handles TextBox_Volume.TextChanged
        mV = Regex.Match(TextBox_Volume.Text, zzV)
        TextBox_Volume.Text = mV.Groups(0).ToString
        Jisuan()
    End Sub

    Private Sub TextBox_Volume_LostFocus(sender As Object, e As EventArgs) Handles TextBox_Volume.LostFocus
        Dim V As String
        mV = Regex.Match(TextBox_Volume.Text, zzV)
        V = mV.Groups(2).ToString
        Select Case V
            Case "M", "Mb", "m", "mb", "MB", "mB"
                V = " MB"
            Case Else
                V = " GB"
        End Select
        TextBox_Volume.Text = mV.Groups(1).ToString & V
        Jisuan()
    End Sub

    Private Sub TextBox_Speed_LostFocus(sender As Object, e As EventArgs) Handles TextBox_Speed.LostFocus
        Dim S As String
        mS = Regex.Match(TextBox_Speed.Text, zzS)
        S = mS.Groups(2).ToString
        Select Case S
            Case "M", "Mb", "m", "mb", "MB", "mB", "M/s", "Mb/s", "m/s", "mb/s", "MB/s", "mB/s", "M/S", "Mb/S", "m/S", "mb/S", "MB/S", "mB/S"
                S = " MB/S"
            Case Else
                S = " KB/S"
        End Select
        TextBox_Speed.Text = mS.Groups(1).ToString & S
        Jisuan()
    End Sub

    Private Sub TextBox_Volume_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Volume.KeyPress
        If e.KeyChar = ChrW(13) Then
            Dim V As String
            mV = Regex.Match(TextBox_Volume.Text, zzV)
            V = mV.Groups(2).ToString
            Select Case V
                Case "M", "Mb", "m", "mb", "MB", "mB"
                    V = " MB"
                Case Else
                    V = " GB"
            End Select
            TextBox_Volume.Text = mV.Groups(1).ToString & V
            Jisuan()
        End If
    End Sub

    Private Sub TextBox_Speed_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Speed.KeyPress
        If e.KeyChar = ChrW(13) Then
            Dim S As String
            mS = Regex.Match(TextBox_Speed.Text, zzS)
            S = mS.Groups(2).ToString
            Select Case S
                Case "M", "Mb", "m", "mb", "MB", "mB", "M/s", "Mb/s", "m/s", "mb/s", "MB/s", "mB/s", "M/S", "Mb/S", "m/S", "mb/S", "MB/S", "mB/S"
                    S = " MB/S"
                Case Else
                    S = " KB/S"
            End Select
            TextBox_Speed.Text = mS.Groups(1).ToString & S
            Jisuan()
        End If
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Dim Speed As Integer
        If TrackBar1.Value > 0 And TrackBar1.Value <= 50 Then
            Speed = TrackBar1.Value * 20.48
        ElseIf TrackBar1.Value > 50 And TrackBar1.Value <= 70 Then
            Speed = (TrackBar1.Value - 50) * 51.2 + 1024
        ElseIf TrackBar1.Value > 70 And TrackBar1.Value <= 90 Then
            Speed = (TrackBar1.Value - 70) * 102.4 + 2048
        Else
            Speed = (TrackBar1.Value - 90) * 204.8 + 4096
        End If
        TextBox_Speed.Text = Speed & " KB/S"
    End Sub

End Class
