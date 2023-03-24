Imports System.Windows.Forms

Public Class LicenseForm
    Dim ls As String


    Public ReadOnly Property GetLicense() As String
        Get
            Return ls
        End Get
    End Property


    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                e.SuppressKeyPress = True
                ls = Trim(TextBox1.Text)
                Me.Hide()
        End Select

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ls = Trim(TextBox1.Text)
        Me.Hide()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub
End Class