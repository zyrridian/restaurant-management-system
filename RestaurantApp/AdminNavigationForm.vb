Imports System.Data.SqlClient

Public Class AdminNavigationForm
    Private Sub OrderButton_Click(sender As Object, e As EventArgs) Handles OrderButton.Click
        OrderForm.Show()
    End Sub

    Private Sub MemberButton_Click(sender As Object, e As EventArgs) Handles MemberButton.Click
        ManageMemberForm.Show()
    End Sub

    Private Sub MenuButton_Click(sender As Object, e As EventArgs) Handles MenuButton.Click
        ManageMenuForm.Show()
    End Sub

    Private Sub PaymentButton_Click(sender As Object, e As EventArgs) Handles PaymentButton.Click
        PaymentForm.Show()
    End Sub

    Private Sub ReportButton_Click(sender As Object, e As EventArgs) Handles ReportButton.Click
        ReportForm.Show()
    End Sub

    Private Sub LogoutButton_Click(sender As Object, e As EventArgs) Handles LogoutButton.Click

        'Pesan konfirmasi sebelum logout
        Dim result As DialogResult = MessageBox.Show("Yakin ingin logout?", "Konfirmasi", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            LoginForm.Show()
            Close()
        End If

    End Sub

End Class