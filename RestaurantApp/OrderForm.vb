Imports System.Data.SqlClient

Public Class OrderForm

    Public Shared orderHeaderID As String
    Public Shared menuID As Integer
    Public Shared thisDate As Date

    Public Sub GenerateOrderHeaderID() 'Membuat OrderHeaderID dengan format tertentu

        thisDate = Today
        Dim formatDate As String = thisDate.ToString("yyyyMMdd")
        Dim hitung As Long

        Call Koneksi()
        cmd = New SqlCommand("SELECT * FROM OrderHeader WHERE OrderHeaderID IN (SELECT MAX(OrderHeaderID) FROM OrderHeader)", conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If Not dr.HasRows Then
            orderHeaderID = formatDate + "0001"
        Else
            hitung = Microsoft.VisualBasic.Right(dr.GetString(0), 4) + 1
            orderHeaderID = formatDate + Microsoft.VisualBasic.Right("0000" & hitung, 4)
        End If
        dr.Close()
        cmd.Dispose()

    End Sub

    Public Sub BuatTabel() 'Membuat tabel di DataGridView2
        DataGridView2.Columns.Clear()
        DataGridView2.Columns.Add("name", "Name")
        DataGridView2.Columns.Add("qty", "Qty")
        DataGridView2.Columns.Add("totalCarbo", "Carbo")
        DataGridView2.Columns.Add("totalProtein", "Protein")
        DataGridView2.Columns.Add("price", "Price")
        DataGridView2.Columns.Add("totalPrice", "Total Price")
    End Sub

    Public Sub LoadData() 'Menampilkan kondisi awal OrderForm

        Call BuatTabel()
        Call Koneksi()
        da = New SqlDataAdapter("SELECT MenuID, Name, Price, Carbo, Protein, Photo FROM MsMenu", conn)
        ds = New DataSet
        da.Fill(ds, "MsMenu")
        DataGridView1.DataSource = (ds.Tables("MsMenu"))
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(5).Visible = False

        TextBox1.Text = ""
        TextBox2.Text = ""
        PictureBox1.Image = Nothing

    End Sub

    Private Sub OrderForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadData()

        TextBox1.AutoSize = False
        TextBox2.AutoSize = False
        TextBox1.Height = 30
        TextBox2.Height = 30

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        'Validasi agar tidak terjadi error ketika meng-klik kolom kosong
        If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then
            If Not DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value.ToString.Length = Nothing Then
                menuID = DataGridView1.Rows(e.RowIndex).Cells(0).Value
                TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
                PictureBox1.Image = Image.FromFile("D:\Projects\Programming\DesktopAppProjects\RestaurantApp\" + DataGridView1.Rows(e.RowIndex).Cells(5).Value)
            End If
        End If

    End Sub

    Private Sub AddButton_Click(sender As Object, e As EventArgs) Handles AddButton.Click

        If TextBox1.Text = "" Or TextBox2.Text = "" Then 'Jika data kosong

            MsgBox("Data tidak boleh kosong!")

        Else 'Jika data tidak kosong

            'Lakukan pengulangan (for) untuk mengecek apakah menu sudah ada
            Dim test As Boolean = False
            For Each row In DataGridView2.Rows
                If TextBox1.Text = row.Cells("name").Value Then
                    test = True
                    Exit For
                End If
            Next

            If test = False Then 'Jika menu belum dimasukkan

                'Ambil data carbo, protein, dan price sesuai menu yang dipilih
                Dim qty As Integer = Convert.ToInt32(TextBox2.Text)
                Dim carbo, protein, price As New Integer
                Dim read As New SqlCommand("SELECT * FROM MsMenu WHERE MenuID = @MenuID", conn)
                read.Parameters.Add(New SqlParameter With {.ParameterName = "@MenuID", .Value = menuID})
                dr = read.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    carbo = dr!Carbo
                    protein = dr!Protein
                    price = dr!Price
                End If
                dr.Close()
                read.Dispose()

                'Tambahkan menu ke DataGridView2
                DataGridView2.Rows.Add(New String() {TextBox1.Text, qty, (carbo * qty), (protein * qty), price, (price * qty)})

                Dim totalCarbo As Integer
                Dim totalProtein As Integer
                Dim totalPrice As Integer

                'Lakukan pengulangan (for) untuk menjumlahkan TotalCarbo, TotalProtein, dan TotalPrice dari menu yang sudah ditambahkan
                For j As Integer = 0 To DataGridView2.Rows.Count - 1
                    totalCarbo += DataGridView2.Rows(j).Cells(2).Value
                    totalProtein += DataGridView2.Rows(j).Cells(3).Value
                    totalPrice += DataGridView2.Rows(j).Cells(5).Value
                Next

                'Tampilkan datanya ke label
                carboLabel.Text = totalCarbo.ToString()
                proteinLabel.Text = totalProtein.ToString()
                priceLabel.Text = String.Format("{0:n}", totalPrice) 'Format khusus agar jumlah uang lebih mudah dibaca

                TextBox1.Text = ""
                TextBox2.Text = ""
                PictureBox1.Image = Nothing

            Else 'Jika menu sudah dimasukan, tambahkan jumlah 'Qty' nya

                'Ambil posisi atau index menu yang sudah dimasukkan
                Dim rowIndex As Integer = -1
                For Each rows In DataGridView2.Rows
                    If rows.Cells(0).Value.ToString.Equals(TextBox1.Text) Then
                        rowIndex = rows.Index
                        Exit For
                    End If
                Next

                'Ambil data carbo, protein, dan price sesuai menu yang dipilih
                Dim qty As Integer = DataGridView2.Rows(rowIndex).Cells(1).Value + Convert.ToInt32(TextBox2.Text)
                Dim carbo, protein, price As New Integer
                Dim read As New SqlCommand("SELECT * FROM MsMenu WHERE MenuID = @MenuID", conn)
                read.Parameters.Add(New SqlParameter With {.ParameterName = "@MenuID", .Value = menuID})
                dr = read.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    carbo = dr!Carbo
                    protein = dr!Protein
                    price = dr!Price
                End If
                dr.Close()
                read.Dispose()

                MsgBox("Jumlah menu sudah berubah")

                'Hapus data yang duplikat, lalu ganti dengan yang baru
                DataGridView2.Rows(rowIndex).Selected = True
                DataGridView2.Rows.Remove(DataGridView2.SelectedRows(0))
                DataGridView2.Rows.Add(New String() {TextBox1.Text, qty, (carbo * qty), (protein * qty), price, (price * qty)})

                Dim totalCarbo As Integer
                Dim totalProtein As Integer
                Dim totalPrice As Integer

                'Lakukan pengulangan (for) untuk menjumlahkan TotalCarbo, TotalProtein, dan TotalPrice dari menu yang sudah ditambahkan
                For j As Integer = 0 To DataGridView2.Rows.Count - 1
                    totalCarbo += DataGridView2.Rows(j).Cells(2).Value
                    totalProtein += DataGridView2.Rows(j).Cells(3).Value
                    totalPrice += DataGridView2.Rows(j).Cells(5).Value
                Next

                carboLabel.Text = totalCarbo.ToString()
                proteinLabel.Text = totalProtein.ToString()
                priceLabel.Text = String.Format("{0:n}", totalPrice) 'Format khusus agar jumlah uang lebih mudah dibaca

                TextBox1.Text = ""
                TextBox2.Text = ""
                PictureBox1.Image = Nothing

            End If

        End If

    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click

        If DataGridView2.SelectedRows.Count > 0 Then 'Jika baris yang ingin dihapus sudah dipilih
            Dim result As DialogResult = MessageBox.Show("Yakin ingin menghapus data?", "Konfirmasi", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then

                MsgBox("Data berhasil dihapus!")
                DataGridView2.Rows.Remove(DataGridView2.SelectedRows(0)) 'Hapus data yang dipilih

                Dim totalCarbo As Integer
                Dim totalProtein As Integer
                Dim totalPrice As Integer

                'Lakukan pengulangan (for) untuk menghitung ulang TotalCarbo, TotalProtein, dan TotalPrice
                For j As Integer = 0 To DataGridView2.Rows.Count - 1
                    totalCarbo += DataGridView2.Rows(j).Cells(2).Value
                    totalProtein += DataGridView2.Rows(j).Cells(3).Value
                    totalPrice += DataGridView2.Rows(j).Cells(5).Value
                Next

                'Tampilkan datanya ke label
                carboLabel.Text = totalCarbo.ToString()
                proteinLabel.Text = totalProtein.ToString()
                priceLabel.Text = String.Format("{0:n}", totalPrice)

                TextBox1.Text = ""
                TextBox2.Text = ""
                PictureBox1.Image = Nothing

            End If
        Else 'Jika baris yang ingin dihapus belum dipilih
            MsgBox("Pilih menu yang ingin dihapus")
        End If

    End Sub

    Private Sub OrderButton_Click(sender As Object, e As EventArgs) Handles OrderButton.Click

        Dim result As DialogResult = MessageBox.Show("Semua data sudah benar?", "Konfirmasi", MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then

            GenerateOrderHeaderID()
            Call Koneksi()

            'Masukkan data ke tabel OrderHeader
            Dim insertOrderHeader As New SqlCommand("INSERT INTO OrderHeader VALUES (@OrderHeaderID, @EmployeeID, @MemberID, @Date, @PaymentType, @CardNumber, @Bank)", conn)
            insertOrderHeader.Parameters.Add(New SqlParameter With {.ParameterName = "@OrderHeaderID", .Value = orderHeaderID})
            insertOrderHeader.Parameters.Add(New SqlParameter With {.ParameterName = "@EmployeeID", .Value = AdminNavigationForm.EmployeeIDToolStripLabel.Text})
            insertOrderHeader.Parameters.Add(New SqlParameter With {.ParameterName = "@MemberID", .Value = 1})
            insertOrderHeader.Parameters.Add(New SqlParameter With {.ParameterName = "@Date", .Value = thisDate})
            insertOrderHeader.Parameters.Add(New SqlParameter With {.ParameterName = "@PaymentType", .Value = ""})
            insertOrderHeader.Parameters.Add(New SqlParameter With {.ParameterName = "@CardNumber", .Value = ""})
            insertOrderHeader.Parameters.Add(New SqlParameter With {.ParameterName = "@Bank", .Value = ""})
            insertOrderHeader.ExecuteNonQuery()
            insertOrderHeader.Dispose()

            Dim name As String
            Dim menuID As Integer
            Dim qty As Integer
            Dim totalCarbo As Integer
            Dim totalProtein As Integer
            Dim totalPrice As Integer

            'Lakukan pengulangan (for) untuk memasukkan semua baris yang ada pada DataGridView2
            For row As Integer = 0 To DataGridView2.Rows.Count - 2

                name = DataGridView2.Rows(row).Cells(0).Value
                qty = DataGridView2.Rows(row).Cells(1).Value
                totalCarbo = DataGridView2.Rows(row).Cells(2).Value
                totalProtein = DataGridView2.Rows(row).Cells(3).Value
                totalPrice = DataGridView2.Rows(row).Cells(5).Value

                'Mengambil MenuID berdasarkan nama yang ada di TextBox1
                Dim read As New SqlCommand("SELECT * FROM MsMenu WHERE Name = @Name", conn)
                read.Parameters.Add(New SqlParameter With {.ParameterName = "@Name", .Value = name})
                dr = read.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    menuID = dr!MenuID
                End If
                dr.Close()
                read.Dispose()

                'Memasukkan data ke tabel OrderDetail
                Dim insert As New SqlCommand("INSERT INTO OrderDetail VALUES (@OrderHeaderID, @MenuID, @Qty, @TotalPrice, @TotalCarbo, @TotalProtein, @Status)", conn)
                insert.Parameters.Add(New SqlParameter With {.ParameterName = "@OrderHeaderID", .Value = orderHeaderID})
                insert.Parameters.Add(New SqlParameter With {.ParameterName = "@MenuID", .Value = menuID})
                insert.Parameters.Add(New SqlParameter With {.ParameterName = "@Qty", .Value = qty})
                insert.Parameters.Add(New SqlParameter With {.ParameterName = "@TotalPrice", .Value = totalPrice})
                insert.Parameters.Add(New SqlParameter With {.ParameterName = "@TotalCarbo", .Value = totalCarbo})
                insert.Parameters.Add(New SqlParameter With {.ParameterName = "@TotalProtein", .Value = totalProtein})
                insert.Parameters.Add(New SqlParameter With {.ParameterName = "@Status", .Value = "pending"})
                insert.ExecuteNonQuery()
                insert.Dispose()

            Next

            MsgBox("Order berhasil")
            LoadData()

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

End Class