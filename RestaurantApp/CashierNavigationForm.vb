Public Class CashierNavigationForm
    Private Sub PaymentButton_Click(sender As Object, e As EventArgs) Handles PaymentButton.Click
        PaymentForm.Show()
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