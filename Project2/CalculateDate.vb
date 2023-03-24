Public Class CalculateDate
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim iDay As String = CalculateExactDateDifference(DateTimePicker1.Value, DateTimePicker2.Value)
        Label1.Text = iDay
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub
End Class