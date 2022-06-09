Imports System.Data.SqlClient

Public Class ReportForm

    Private Sub SeleksiComboBox() 'Validasi ComboBox2 agar nilainya tidak melebihi ComboBox1

        If ComboBox1.Items.Count > 0 Or ComboBox2.Items.Count > 0 Then
            If ComboBox1.SelectedIndex > ComboBox2.SelectedIndex And ComboBox1.SelectedIndex < ComboBox1.Items.Count - 1 Then
                ComboBox2.SelectedIndex = ComboBox1.SelectedIndex + 1
            End If
            If ComboBox1.SelectedIndex = ComboBox1.Items.Count - 1 Then
                ComboBox2.SelectedIndex = ComboBox1.Items.Count - 1
            End If
        End If

    End Sub

    Private Sub ReportForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Menampilkan nilai default pada ComboBox1 dan ComboBox2
        If ComboBox1.Items.Count > 0 Or ComboBox2.Items.Count > 0 Then
            ComboBox1.SelectedIndex = 0
            ComboBox2.SelectedIndex = 1
        End If

        Chart1.ChartAreas(0).AxisX.Interval = 1 'Menampilkan semua label
        Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = False 'Menghilangkan garis vertikal X

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Call SeleksiComboBox()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Call SeleksiComboBox()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Chart1.Series("Income").Points.Clear()

        Dim thisDate As Date
        Dim kosong As Boolean
        Dim profit As Double = 0
        Dim carbo As Double = 0
        Dim protein As Double = 0
        Dim num As Integer = ComboBox1.SelectedIndex + 1

        For i As Integer = ComboBox1.SelectedIndex To ComboBox2.SelectedIndex

            kosong = False
            Call Koneksi()

            'Cek data bulan
            Dim read As New SqlCommand("SELECT * FROM OrderDetail JOIN OrderHeader ON OrderDetail.OrderHeaderID = OrderHeader.OrderHeaderID WHERE MONTH (Date) = @Date AND Status = 'completed'", conn)
            read.Parameters.Add(New SqlParameter With {.ParameterName = "@Date", .Value = num})
            dr = read.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                thisDate = dr!Date
            Else
                num += 1
                kosong = True
                Continue For
            End If
            dr.Close()
            read.Dispose()

            'Cek pendapatan dari setiap bulan
            Dim read2 As New SqlCommand("SELECT * FROM OrderDetail JOIN OrderHeader ON OrderDetail.OrderHeaderID = OrderHeader.OrderHeaderID WHERE MONTH (Date) = '" & num & "' AND Status = 'completed'", conn)
            read2.Parameters.Add(New SqlParameter With {.ParameterName = "@Date", .Value = num})
            dr = read2.ExecuteReader
            While dr.Read()
                profit += dr!TotalPrice
                carbo += dr!TotalCarbo
                protein += dr!TotalProtein
            End While
            dr.Close()
            read2.Dispose()

            'Hitung pendapatan dalam satuan juta, lalu tambahkan ke Chart
            profit /= 1000000

            '(opsional) Menampilkan diagram untuk carbo & protein ketika CheckBox1 bertanda centang
            If CheckBox1.Checked = True Then
                Chart1.Titles("Title1").Text = "Carbo and Protein"
                Chart1.Series("Carbo").Points.AddXY(thisDate.ToString("MMMM"), Math.Round(carbo, 2))
                Chart1.Series("Protein").Points.AddXY(thisDate.ToString("MMMM"), Math.Round(protein, 2))
            Else
                Chart1.Titles("Title1").Text = "Income in Million"
                Chart1.Series("Income").Points.AddXY(thisDate.ToString("MMMM"), Math.Round(profit, 2))
            End If
            num += 1
        Next

        'Pesan keterangan ketika ada data yang tidak ditampilkan
        If kosong = True Then
            MsgBox("Data yang kosong pada bulan tertentu tidak ditampilkan")
        Else
            MsgBox("Berhasil")
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub
End Class