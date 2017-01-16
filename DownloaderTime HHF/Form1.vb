Public Class Form1
    Private Sub Jisuan(Volume As Double, Speed As Double)

    End Sub

    Private Function DataVolume(Volume As Double) As Double

    End Function

    Private Function DataSpeed(Speed As Double) As Double

    End Function

    Private Sub TextBox_SpeedChanged(sender As Object, e As EventArgs) Handles TextBox_Speed.TextChanged
        Jisuan(TextBox_Volume.Text, TextBox_Speed.Text)
    End Sub

    Private Sub TTextBox_VolumeChanged(sender As Object, e As EventArgs) Handles TextBox_Volume.TextChanged
        DataVolume(TextBox_Volume.Text)
    End Sub
End Class
