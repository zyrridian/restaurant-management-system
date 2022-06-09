Imports System.Data.SqlClient

Public Class ManageMemberForm

    Public Shared thisDate As Date

    Public Sub LoadData()

        Call Koneksi()
        da = New SqlDataAdapter("SELECT * FROM MsMember", conn)
        ds = New DataSet
        da.Fill(ds, "MsMember")
        DataGridView1.DataSource = (ds.Tables("MsMember"))

        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""

    End Sub

    Private Sub ManageMemberForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadData()

        TextBox1.AutoSize = False
        TextBox2.AutoSize = False
        TextBox3.AutoSize = False
        TextBox4.AutoSize = False
        TextBox5.AutoSize = False
        TextBox1.Height = 30
        TextBox2.Height = 30
        TextBox3.Height = 30
        TextBox4.Height = 30
        TextBox5.Height = 30

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then

            If Not DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value.ToString.Length = Nothing Then

                TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
                TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
                TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
                TextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
                thisDate = DataGridView1.Rows(e.RowIndex).Cells(4).Value

            End If

        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        Call Koneksi()
        da = New SqlDataAdapter("SELECT * FROM MsMember WHERE Name LIKE '%" & TextBox1.Text & "%' OR Email LIKE '%" & TextBox1.Text & "%' OR Handphone LIKE '%" & TextBox1.Text & "%'", conn)
        ds = New DataSet
        da.Fill(ds, "MsMember")
        DataGridView1.DataSource = (ds.Tables("MsMember"))

    End Sub

    Private Sub InsertButton_Click(sender As Object, e As EventArgs) Handles InsertButton.Click

        If TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Then

            MsgBox("Data tidak boleh kosong!")

        Else

            Dim result As DialogResult = MessageBox.Show("Semua data sudah benar?", "Konfirmasi", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then

                Call Koneksi()
                Dim salesinsert As New SqlCommand("INSERT INTO MsMember VALUES (@Name, @Email, @Handphone, @JoinDate)", conn)
                salesinsert.Parameters.Add(New SqlParameter With {.ParameterName = "@Name", .Value = TextBox3.Text})
                salesinsert.Parameters.Add(New SqlParameter With {.ParameterName = "@Email", .Value = TextBox4.Text})
                salesinsert.Parameters.Add(New SqlParameter With {.ParameterName = "@Handphone", .Value = TextBox5.Text})
                salesinsert.Parameters.Add(New SqlParameter With {.ParameterName = "@JoinDate", .Value = Today})
                salesinsert.ExecuteNonQuery()
                salesinsert.Dispose()

                MsgBox("Insert data berhasil!")
                LoadData()

            End If

        End If

    End Sub

    Private Sub UpdateButton_Click(sender As Object, e As EventArgs) Handles UpdateButton.Click

        If TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Then

            MsgBox("Data tidak boleh kosong!")

        Else

            Dim result As DialogResult = MessageBox.Show("Apa semua data sudah benar?", "Konfimasi", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then

                Call Koneksi()
                Dim update As New SqlCommand("UPDATE MsMember SET Name = @Name, Email = @Email, Handphone = @Handphone WHERE MemberID = @MemberID", conn)
                update.Parameters.Add(New SqlParameter With {.ParameterName = "@MemberID", .Value = TextBox2.Text})
                update.Parameters.Add(New SqlParameter With {.ParameterName = "@Name", .Value = TextBox3.Text})
                update.Parameters.Add(New SqlParameter With {.ParameterName = "@Email", .Value = TextBox4.Text})
                update.Parameters.Add(New SqlParameter With {.ParameterName = "@Handphone", .Value = TextBox5.Text})
                update.Parameters.Add(New SqlParameter With {.ParameterName = "@JoinDate", .Value = thisDate})
                update.ExecuteNonQuery()
                update.Dispose()

                MsgBox("Edit data berhasil!")
                LoadData()

            End If

        End If

    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click

        If TextBox2.Text = "" Then

            MsgBox("Silahkan pilih data yang ingin dihapus")

        Else

            Dim result As DialogResult = MessageBox.Show("Yakin ingin menghapus data?", "Konfirmasi", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then

                Call Koneksi()
                Dim delete As New SqlCommand("DELETE MsMember WHERE MemberID = @MemberID", conn)
                delete.Parameters.Add(New SqlParameter With {.ParameterName = "@MemberID", .Value = TextBox2.Text})
                delete.ExecuteNonQuery()
                delete.Dispose()

                MsgBox("Data berhasil dihapus!")
                LoadData()

            End If

        End If

    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Close()
    End Sub

End Class