Imports System.Data.SqlClient

Public Class AdminNavigationForm
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ManageMemberForm.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ManageMenuForm.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OrderForm.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        PaymentForm.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        ReportForm.Show()

        'Call Koneksi()

        'cmd = New SqlCommand("SELECT * FROM OrderHeader WHERE OrderHeaderID IN (SELECT MAX(OrderHeaderID) FROM OrderHeader)", conn)

        'Dim formatDate As String = DateTime.Now.ToString("yyyyMMdd")
        'Dim urutanKode As String
        'Dim hitung As Long
        'dr = cmd.ExecuteReader
        'dr.Read()
        'If Not dr.HasRows Then
        '    urutanKode = formatDate + "0001"
        'Else
        '    hitung = Microsoft.VisualBasic.Right(dr.GetString(0), 4) + 1
        '    urutanKode = formatDate + Microsoft.VisualBasic.Right("0000" & hitung, 4)
        'End If

        'MsgBox(urutanKode)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim result As DialogResult = MessageBox.Show("Yakin ingin logout?", "Konfirmasi", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            LoginForm.Show()
            Me.Close()
        End If

    End Sub

End Class