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
                Hide()

                Dim level As String = dr!Position
                Dim emloyeeID As String = dr!EmployeeID
                Dim name As String = dr!Name

                'Validasi role atau position
                If level.ToLower = "admin" Then
                    AdminNavigationForm.Label3.Text = name
                    AdminNavigationForm.EmployeeIDToolStripLabel.Text = emloyeeID
                    AdminNavigationForm.Show()
                ElseIf level.ToLower = "cashier" Then
                    CashierNavigationForm.Label3.Text = name
                    CashierNavigationForm.EmployeeIDToolStripLabel.Text = emloyeeID
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

End Class
