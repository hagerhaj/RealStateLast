Imports System.Data
Imports System.Data.SqlClient
Public Class FrmSearch
    Public ds As New DataSet
    Public conn As New SqlConnection("Data Source=196.1.236.38; Initial Catalog=RealEstate; user id=sa; password=sa#sa123")
    Private Sub FrmSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cmd As New SqlCommand("SELECT Distinct Propertytype FROM Realestatedata", conn)
        Dim da2 As New SqlDataAdapter(cmd)
        Dim dt2 As New DataTable()
        da2.Fill(dt2)
        If dt2.Rows.Count > 0 Then
            Propertytype.DataSource = dt2
            Propertytype.DisplayMember = "Propertytype"
            'Else
            '    MessageBox.Show("Empty")
        End If
        If conn.State = ConnectionState.Open Then conn.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        Dim drv As DataRowView
        If e.RowIndex >= 0 Then
            If e.RowIndex <= ds.Tables("PropertyV").Rows.Count - 1 Then
                drv = ds.Tables("PropertyV").DefaultView.Item(e.RowIndex)
                Dim c, f As Color

                If drv.Item("المتأخرات") >= 1000 Then
                    'If drv.Item("DurationDay") < 5 Then
                    c = Color.LightBlue
                    f = Color.Black

                Else
                    c = Color.White
                    f = Color.Black
                End If
                e.CellStyle.BackColor = c
                e.CellStyle.ForeColor = f

            End If
        End If
    End Sub

    Private Sub ButSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButSearch.Click
        ds.Clear()
        Dim da As New SqlDataAdapter("Select distinct PropertyID AS 'رقم العقار',MonthlyRent AS 'الايجار الشهري ', LessorName AS 'اسم المـــؤجر',  CityName AS 'المدينة ',  Propertytype AS 'نوع العقار',Arrears AS 'المتأخرات', Payplus AS 'المقدم' From  PropertyV where Propertytype='" & Propertytype.Text & "' ORDER BY Arrears DESC ", conn)

        da.Fill(ds, "PropertyV")

        DataGridView1.DataSource = ds.Tables("PropertyV")

        'ds.Clear()

    End Sub
End Class