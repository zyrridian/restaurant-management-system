Imports System.Data.SqlClient

Public Class ManageMenuForm

    Public Sub LoadData()

        Call Koneksi()
        da = New SqlDataAdapter("SELECT * FROM MsMenu", conn)
        ds = New DataSet
        da.Fill(ds, "MsMenu")
        DataGridView1.DataSource = (ds.Tables("MsMenu"))

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        PictureBox1.Image = Nothing

    End Sub

    Private Sub ManageMenuForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadData()

        TextBox1.AutoSize = False
        TextBox2.AutoSize = False
        TextBox3.AutoSize = False
        TextBox4.AutoSize = False
        TextBox5.AutoSize = False
        TextBox6.AutoSize = False
        TextBox7.AutoSize = False
        TextBox1.Height = 30
        TextBox2.Height = 30
        TextBox3.Height = 30
        TextBox4.Height = 30
        TextBox5.Height = 30
        TextBox6.Height = 30
        TextBox7.Height = 30

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        'Validasi agar tidak terjadi error ketika DataGridView diklik
        If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then

            If Not DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value.ToString.Length = Nothing Then

                'Tampilkan data ketika DataGridView diklik
                TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
                TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
                TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
                TextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
                TextBox6.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
                TextBox7.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value

                PictureBox1.Image = Image.FromFile("D:\Projects\Programming\DesktopAppProjects\RestaurantApp\" + DataGridView1.Rows(e.RowIndex).Cells(3).Value)

            End If

        End If

    End Sub

    Private Sub InsertButton_Click(sender As Object, e As EventArgs) Handles InsertButton.Click

        If TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Then

            MsgBox("Data tidak boleh kosong!")

        Else

            Dim result As DialogResult = MessageBox.Show("Semua data sudah benar?", "Konfirmasi", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then

                Call Koneksi()

                Dim thisDate As Date
                thisDate = Today

                Dim insert As New SqlCommand("INSERT INTO MsMenu VALUES (@Name, @Price, @Photo, @Carbo, @Protein)", conn)
                insert.Parameters.Add(New SqlParameter With {.ParameterName = "@Name", .Value = TextBox3.Text})
                insert.Parameters.Add(New SqlParameter With {.ParameterName = "@Price", .Value = TextBox4.Text})
                insert.Parameters.Add(New SqlParameter With {.ParameterName = "@Photo", .Value = TextBox5.Text})
                insert.Parameters.Add(New SqlParameter With {.ParameterName = "@Carbo", .Value = TextBox6.Text})
                insert.Parameters.Add(New SqlParameter With {.ParameterName = "@Protein", .Value = TextBox7.Text})
                insert.ExecuteNonQuery()
                insert.Dispose()

                MsgBox("Insert data berhasil!")
                LoadData()

            End If

        End If

    End Sub

    Private Sub UpdateButton_Click(sender As Object, e As EventArgs) Handles UpdateButton.Click

        If TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Then

            MsgBox("Data tidak boleh kosong!")

        Else

            Dim result As DialogResult = MessageBox.Show("Apa semua data sudah benar?", "Konfimasi", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then

                Call Koneksi()

                Dim thisDate As Date
                thisDate = Today

                Dim update As New SqlCommand("UPDATE MsMenu SET Name = @Name, Price = @Price, Photo = @Photo, Carbo = @Carbo, Protein = @Protein WHERE MenuID = @MenuID", conn)
                update.Parameters.Add(New SqlParameter With {.ParameterName = "@MenuID", .Value = TextBox2.Text})
                update.Parameters.Add(New SqlParameter With {.ParameterName = "@Name", .Value = TextBox3.Text})
                update.Parameters.Add(New SqlParameter With {.ParameterName = "@Price", .Value = TextBox4.Text})
                update.Parameters.Add(New SqlParameter With {.ParameterName = "@Photo", .Value = TextBox5.Text})
                update.Parameters.Add(New SqlParameter With {.ParameterName = "@Carbo", .Value = TextBox6.Text})
                update.Parameters.Add(New SqlParameter With {.ParameterName = "@Protein", .Value = TextBox7.Text})
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
                Dim delete As New SqlCommand("DELETE MsMenu WHERE MenuID = @MenuID", conn)
                delete.Parameters.Add(New SqlParameter With {.ParameterName = "@MenuID", .Value = TextBox2.Text})
                delete.ExecuteNonQuery()
                delete.Dispose()

                MsgBox("Data berhasil dihapus!")
                LoadData()

            End If

        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        Call Koneksi()
        da = New SqlDataAdapter("SELECT * FROM MsMenu WHERE Name LIKE '%" & TextBox1.Text & "%' OR Price LIKE '%" & TextBox1.Text & "%' OR Carbo LIKE '%" & TextBox1.Text & "%' OR Protein LIKE '%" & TextBox1.Text & "%'", conn)
        ds = New DataSet
        da.Fill(ds, "MsMenu")
        DataGridView1.DataSource = (ds.Tables("MsMenu"))

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        'Mencari gambar
        Dim name As String
        Dim open As New OpenFileDialog
        open.Filter = "Choose image(*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif"
        If open.ShowDialog = DialogResult.OK Then
            name = open.SafeFileName()
            PictureBox1.Image = Image.FromFile(open.FileName)
        End If
        TextBox5.Text = name

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        Call LoadData()
    End Sub
End Class