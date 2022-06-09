Imports System.Data.SqlClient

Public Class PaymentForm

    Public Shared totalPrice As Integer
    Public Shared orderHeaderID As Integer
    Public Shared employeeID As String
    Public Shared memberID As Integer
    Public Shared thisDate As Date

    Public Shared orderDetailID As Integer
    Public Shared menuID As Integer
    Public Shared qty As Integer
    Public Shared totalPricee As Integer
    Public Shared totalCarbo As Integer
    Public Shared totalProtein As Integer
    Public Shared status As String

    Public Shared total As Integer

    Public Sub GenerateOrderHeaderID() 'Memunculkan list OrderHeaderID di ComboBox1 yang statusnya masih 'pending'
        Call Koneksi()
        ComboBox1.Items.Clear()
        cmd = New SqlCommand(
            "SELECT OrderHeader.OrderHeaderID
            FROM OrderHeader JOIN OrderDetail
            ON OrderHeader.OrderHeaderID = OrderDetail.OrderHeaderID AND OrderDetail.Status = 'pending'
            GROUP BY OrderHeader.OrderHeaderID, OrderDetail.Status", conn)
        dr = cmd.ExecuteReader
        Do While dr.Read()
            ComboBox1.Items.Add(dr.Item(0))
        Loop
        If ComboBox1.Items.Count > 0 Then
            ComboBox1.SelectedIndex = 0
        End If
    End Sub

    Public Sub LoadData() 'Menampilkan tabel

        Call Koneksi()
        da = New SqlDataAdapter("SELECT OrderDetail.OrderDetailID, MsMenu.Name, OrderDetail.Qty, MsMenu.Price, OrderDetail.TotalPrice FROM MsMenu INNER JOIN OrderDetail ON MsMenu.MenuID = OrderDetail.MenuID WHERE OrderHeaderID = '" & ComboBox1.Text & "'", conn)
        ds = New DataSet
        da.Fill(ds, "MsMenu")
        DataGridView1.DataSource = (ds.Tables("MsMenu"))
        DataGridView1.Columns(0).Visible = False

        TextBox1.Text = ""

    End Sub

    Private Sub PaymentForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call GenerateOrderHeaderID()
        Call LoadData()

        'Menampilkan item pertama ComboBox
        If ComboBox2.Items.Count > 0 Or ComboBox3.Items.Count > 0 Then
            ComboBox2.SelectedIndex = 0
            ComboBox3.SelectedIndex = 0
        End If

        TextBox1.AutoSize = False
        TextBox1.Height = 30

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        LoadData()

        'Menghitung total harga dan menampilkannya
        total = 0
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            total += DataGridView1.Rows(i).Cells(4).Value
        Next
        totalPriceLabel.Text = String.Format("{0:n}", total)

        'Mengambil data di OrderHeader untuk digunakan di query UPDATE
        Call Koneksi()
        Dim read As New SqlCommand("SELECT * FROM OrderHeader WHERE OrderHeaderID = @OrderHeaderID", conn)
        read.Parameters.Add(New SqlParameter With {.ParameterName = "@OrderHeaderID", .Value = ComboBox1.Text})
        dr = read.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            employeeID = dr!EmployeeID
            memberID = dr!MemberID
            thisDate = dr!Date
        End If
        dr.Close()
        read.Dispose()

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

        If ComboBox2.SelectedIndex = 0 Then 'Jika credit card
            Label4.Text = "Card Number"
            Label5.Text = "Bank Name"
            ComboBox3.Visible = True
        ElseIf ComboBox2.SelectedIndex = 1 Then 'Jika cash
            Label4.Text = "Jumlah Uang"
            Label5.Visible = False
            ComboBox3.Visible = False
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'Cek apakah data sudah diisi
        If TextBox1.Text = "" Then

            MsgBox("Data tidak boleh kosong!")

        Else 'Jika data sudah diisi

            Dim result As DialogResult = MessageBox.Show("Semua data sudah benar?", "Konfirmasi", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then

                Call Koneksi()

                'Jika metode pembayarannya menggunakan kartu kredit
                If ComboBox2.Text.ToLower = "credit cards" Then

                    'Ubah data PaymentType, CardNumber, dan Bank di OrderHeader yang masih kosong
                    Dim editOrderHeader As New SqlCommand("UPDATE OrderHeader SET EmployeeID = @EmployeeID, MemberID = @MemberID, Date = @Date, PaymentType = @PaymentType, CardNumber = @CardNumber, Bank = @Bank WHERE OrderHeaderID = @OrderHeaderID", conn)
                    editOrderHeader.Parameters.Add(New SqlParameter With {.ParameterName = "@OrderHeaderID", .Value = ComboBox1.Text})
                    editOrderHeader.Parameters.Add(New SqlParameter With {.ParameterName = "@EmployeeID", .Value = employeeID})
                    editOrderHeader.Parameters.Add(New SqlParameter With {.ParameterName = "@MemberID", .Value = memberID})
                    editOrderHeader.Parameters.Add(New SqlParameter With {.ParameterName = "@Date", .Value = thisDate})
                    editOrderHeader.Parameters.Add(New SqlParameter With {.ParameterName = "@PaymentType", .Value = ComboBox2.Text})
                    editOrderHeader.Parameters.Add(New SqlParameter With {.ParameterName = "@CardNumber", .Value = Convert.ToInt32(TextBox1.Text)})
                    editOrderHeader.Parameters.Add(New SqlParameter With {.ParameterName = "@Bank", .Value = ComboBox3.Text})
                    editOrderHeader.ExecuteNonQuery()
                    editOrderHeader.Dispose()

                    'Ubah status 'pending' di OrderDetail menjadi 'completed'
                    For i As Integer = 0 To DataGridView1.Rows.Count - 1

                        orderDetailID = DataGridView1.Rows(i).Cells(0).Value

                        'Ambil semua data di OrderDetail sebelum melakukan query UPDATE
                        Dim read As New SqlCommand("SELECT * FROM OrderDetail WHERE OrderDetailID = @OrderDetailID", conn)
                        read.Parameters.Add(New SqlParameter With {.ParameterName = "@OrderDetailID", .Value = orderDetailID})
                        dr = read.ExecuteReader
                        dr.Read()
                        If dr.HasRows Then
                            menuID = dr!MenuID
                            qty = dr!Qty
                            totalPricee = dr!TotalPrice
                            totalCarbo = dr!TotalCarbo
                            totalProtein = dr!TotalProtein
                            status = dr!Status
                        End If
                        dr.Close()
                        read.Dispose()

                        'Ubah status pembayaran menjadi 'completed'
                        Dim edit As New SqlCommand("UPDATE OrderDetail SET OrderHeaderID = @OrderHeaderID, MenuID = @MenuID, Qty = @Qty, TotalPrice = @TotalPrice, TotalCarbo = @TotalCarbo, TotalProtein = @TotalProtein, Status = @Status WHERE OrderDetailID = @OrderDetailID", conn)
                        edit.Parameters.Add(New SqlParameter With {.ParameterName = "@OrderDetailID", .Value = orderDetailID})
                        edit.Parameters.Add(New SqlParameter With {.ParameterName = "@OrderHeaderID", .Value = ComboBox1.Text})
                        edit.Parameters.Add(New SqlParameter With {.ParameterName = "@MenuID", .Value = menuID})
                        edit.Parameters.Add(New SqlParameter With {.ParameterName = "@Qty", .Value = qty})
                        edit.Parameters.Add(New SqlParameter With {.ParameterName = "@TotalPrice", .Value = totalPricee})
                        edit.Parameters.Add(New SqlParameter With {.ParameterName = "@TotalCarbo", .Value = totalCarbo})
                        edit.Parameters.Add(New SqlParameter With {.ParameterName = "@TotalProtein", .Value = totalProtein})
                        edit.Parameters.Add(New SqlParameter With {.ParameterName = "@Status", .Value = "completed"})
                        edit.ExecuteNonQuery()
                        edit.Dispose()

                    Next

                    MsgBox("Insert data berhasil!")
                    Call GenerateOrderHeaderID()
                    Call LoadData()

                    'Jika metode pembayarannya secara tunai
                ElseIf ComboBox2.Text.ToLower = "cash" Then

                    Dim uang As Integer = Convert.ToInt32(TextBox1.Text)

                    'Cek apakah uang yang diinputkan sudah cukup
                    If uang < total Then

                        MsgBox("Uang anda kurang!")

                    Else 'Jika uang sudah cukup

                        'Ubah data PaymentType, CardNumber, dan Bank di OrderHeader yang masih kosong
                        Dim editOrderHeader As New SqlCommand("UPDATE OrderHeader SET EmployeeID = @EmployeeID, MemberID = @MemberID, Date = @Date, PaymentType = @PaymentType, CardNumber = @CardNumber, Bank = @Bank WHERE OrderHeaderID = @OrderHeaderID", conn)
                        editOrderHeader.Parameters.Add(New SqlParameter With {.ParameterName = "@OrderHeaderID", .Value = ComboBox1.Text})
                        editOrderHeader.Parameters.Add(New SqlParameter With {.ParameterName = "@EmployeeID", .Value = employeeID})
                        editOrderHeader.Parameters.Add(New SqlParameter With {.ParameterName = "@MemberID", .Value = memberID})
                        editOrderHeader.Parameters.Add(New SqlParameter With {.ParameterName = "@Date", .Value = thisDate})
                        editOrderHeader.Parameters.Add(New SqlParameter With {.ParameterName = "@PaymentType", .Value = ComboBox2.Text})
                        editOrderHeader.Parameters.Add(New SqlParameter With {.ParameterName = "@CardNumber", .Value = ""})
                        editOrderHeader.Parameters.Add(New SqlParameter With {.ParameterName = "@Bank", .Value = ""})
                        editOrderHeader.ExecuteNonQuery()
                        editOrderHeader.Dispose()

                        'Ubah status 'pending' di OrderDetail menjadi 'completed'
                        For i As Integer = 0 To DataGridView1.Rows.Count - 1

                            orderDetailID = DataGridView1.Rows(i).Cells(0).Value

                            'Ambil semua data di OrderDetail sebelum melakukan query UPDATE
                            Dim read As New SqlCommand("SELECT * FROM OrderDetail WHERE OrderDetailID = @OrderDetailID", conn)
                            read.Parameters.Add(New SqlParameter With {.ParameterName = "@OrderDetailID", .Value = orderDetailID})
                            dr = read.ExecuteReader
                            dr.Read()
                            If dr.HasRows Then
                                menuID = dr!MenuID
                                qty = dr!Qty
                                totalPricee = dr!TotalPrice
                                totalCarbo = dr!TotalCarbo
                                totalProtein = dr!TotalProtein
                                status = dr!Status
                            End If
                            dr.Close()
                            read.Dispose()

                            'Ubah status pembayaran menjadi 'completed'
                            Dim edit As New SqlCommand("UPDATE OrderDetail SET OrderHeaderID = @OrderHeaderID, MenuID = @MenuID, Qty = @Qty, TotalPrice = @TotalPrice, TotalCarbo = @TotalCarbo, TotalProtein = @TotalProtein, Status = @Status WHERE OrderDetailID = @OrderDetailID", conn)
                            edit.Parameters.Add(New SqlParameter With {.ParameterName = "@OrderDetailID", .Value = orderDetailID})
                            edit.Parameters.Add(New SqlParameter With {.ParameterName = "@OrderHeaderID", .Value = ComboBox1.Text})
                            edit.Parameters.Add(New SqlParameter With {.ParameterName = "@MenuID", .Value = menuID})
                            edit.Parameters.Add(New SqlParameter With {.ParameterName = "@Qty", .Value = qty})
                            edit.Parameters.Add(New SqlParameter With {.ParameterName = "@TotalPrice", .Value = totalPricee})
                            edit.Parameters.Add(New SqlParameter With {.ParameterName = "@TotalCarbo", .Value = totalCarbo})
                            edit.Parameters.Add(New SqlParameter With {.ParameterName = "@TotalProtein", .Value = totalProtein})
                            edit.Parameters.Add(New SqlParameter With {.ParameterName = "@Status", .Value = "completed"})
                            edit.ExecuteNonQuery()
                            edit.Dispose()

                        Next

                        MsgBox("Insert data berhasil! Jumlah kembalian: " + String.Format("{0:n}", uang - total))
                        Call GenerateOrderHeaderID()
                        Call LoadData()

                    End If

                End If

            End If

        End If

    End Sub
End Class