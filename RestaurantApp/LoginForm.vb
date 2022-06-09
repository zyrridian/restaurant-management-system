Imports System.Data.SqlClient
Public Class LoginForm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Data tidak boleh kosong!")
            TextBox1.Select()
        Else
            Call Koneksi()
            cmd = New SqlCommand("SELECT * FROM MsEmployee WHERE Email = '" & TextBox1.Text & "' AND Password = '" & TextBox2.Text & "'", conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then

                MsgBox("Berhasil Login")
                Me.Hide()

                Dim level As String = dr!Position
                Dim name As String = dr!Name

                If level.ToLower = "admin" Then
                    AdminNavigationForm.Label3.Text = name
                    AdminNavigationForm.Show()
                ElseIf level.ToLower = "cashier" Then
                    CashierNavigationForm.Label3.Text = name
                    CashierNavigationForm.Show()
                End If

            Else
                MsgBox("Data tidak valid!")
            End If
            dr.Close()
            cmd.Dispose()
        End If

    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = "ahmad123@gmail.com"
        TextBox2.Text = "ahmad123"
        TextBox1.AutoSize = False
        TextBox2.AutoSize = False
        TextBox1.Height = 30
        TextBox2.Height = 30
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    'Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover
    '    Button1.BackColor = Color.FromArgb(218, 41, 28)
    '    Button1.ForeColor = Color.FromArgb(255, 255, 255)
    'End Sub

    'Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
    '    Button1.BackColor = Color.FromArgb(255, 255, 255)
    '    Button1.ForeColor = Color.FromArgb(39, 37, 31)
    'End Sub

End Class
