Imports System.Data
Imports System.Data.SqlClient
Public Class Form1
    Public x, y
    Public ds As New DataSet
    Public conn As New SqlConnection("Data Source=196.1.236.38; Initial Catalog=RealEstate; user id=sa; password=sa#sa123")
    Public found As Boolean

    Private Sub Form1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        'If e.KeyChar = ChrW(Keys.Enter) Then

        '    Dim oNextControl As System.Windows.Forms.Control = Me.GetNextControl(sender, True)

        '    oNextControl.Focus()

        'End If
        ''if e.KeyCode = 13 Then SendKeys.Send ({"TAB"}) 'Instructions End If

    End Sub

    Private Sub Form1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Return Then SendKeys.Send("{TAB}")
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim monthw As Integer = ReceiptDate.Value.Month
        'If monthw = 1 Then Rentfor.Text = "يناير"
        'If monthw = 2 Then Rentfor.Text = "فبراير"
        'If monthw = 3 Then Rentfor.Text = "مارس"
        'If monthw = 4 Then Rentfor.Text = "ابريل"
        'If monthw = 5 Then Rentfor.Text = "مايو"
        'If monthw = 6 Then Rentfor.Text = "يونيو"
        'If monthw = 7 Then Rentfor.Text = "يوليو"
        'If monthw = 8 Then Rentfor.Text = "اغسطس"
        'If monthw = 9 Then Rentfor.Text = "سبتمبر"
        'If monthw = 10 Then Rentfor.Text = "اكتوبر"
        'If monthw = 11 Then Rentfor.Text = "نوفمبر"
        'If monthw = 12 Then Rentfor.Text = "ديسمبر"
        ' ''''''''''''''''
        ' Rentfor.Text = MonthName(Now.Date.Month(), False)

        'Rentfor.Text = Month(Now).ToString()

        cmupdate.Enabled = False



        '''''''''''''''''''''
        Dim months = System.Globalization.DateTimeFormatInfo.InvariantInfo.MonthNames
        Rentfor.DataSource = months
        Rentfor.Text = MonthName(Now.Date.Month(), False)

    End Sub
    Sub clearbox()
        proindex.Text = ""
        PropertyID.Text = ""
        PaymentType.Text = "نقداً"
        ReceiptNo.Text = ""
        CheckNumber.Text = ""
        PayMonthlyRent.Text = ""
        PayArrears.Text = ""
        LessorName.Text = ""
        CityName.Text = ""
        RegionName.Text = ""
        Arrears.Text = ""
        PaidAmount.Text = ""
        MonthlyRent.Text = ""
        PayArrears.Text = ""
        TextBox8.Text = ""
        Payplus.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox4.Text = ""
        proindex.Focus()


    End Sub
    Sub updateArrears()
        Dim Sql1 As String

        Sql1 = "update Realestatedata set Arrears= '" & TextBox8.Text & "' Where proindex ='" & Me.proindex.Text & "'"

        Dim cmd As New SqlCommand(Sql1, conn)

        If conn.State = ConnectionState.Closed Then conn.Open()
        cmd.ExecuteNonQuery()

        If conn.State = ConnectionState.Open Then conn.Close()

    End Sub

    Private Sub PaidAmount_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PaidAmount.LostFocus
        '''''''''''''''''
        'في حاله الدفع اكتر من مره في الشهر
        'لايتم استقطاع الايجار مرة اخري 
        '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Try
            '  Dim dr As SqlDataReader

            Dim sql As String = "select DATENAME(month, ReceiptDate)as hh ,ReceiptDate from ArrearsPayment Where proindex='" & Me.proindex.Text & "' and DATENAME(month, ReceiptDate)='" & Me.Rentfor.Text & "' and  year(ReceiptDate)='" & Year(Me.ReceiptDate.Text) & "'"

            Dim cmd1 As New SqlCommand(sql, conn)
            If conn.State = ConnectionState.Closed Then conn.Open()
            'dr = cmd1.ExecuteReader
            Using reader As SqlDataReader = cmd1.ExecuteReader()
                If reader.HasRows Then


                    MsgBox("تم دفع الايجار مسبقا في هذا الشهر .......هل تريد دفع متاخرات او مقدم  !", MsgBoxStyle.Exclamation)
                    '    formadd.Show()
                    'End If
                    TextBox8.Enabled = True
                    Payplus.Enabled = True
                    PayArrears.Enabled = True
                Else


                '''''''''''''''''''''''''''''''''
                x = Val(MonthlyRent.Text) + Val(Arrears.Text)

                ' Label17.Text = x

                If x < Val(PaidAmount.Text) Then
                    Payplus.Text = Val(PaidAmount.Text) - x
                    PayMonthlyRent.Text = Val(MonthlyRent.Text)
                    PayArrears.Text = Val(Arrears.Text)
                    TextBox8.Text = 0
                ElseIf x > Val(PaidAmount.Text) Then

                    If PaidAmount.Text = Val(MonthlyRent.Text) Then
                        PayMonthlyRent.Text = Val(PaidAmount.Text)
                        TextBox8.Text = Val(Arrears.Text)
                        PayArrears.Text = 0
                        Payplus.Text = 0
                    ElseIf PaidAmount.Text > Val(MonthlyRent.Text) Then
                        y = Val(PaidAmount.Text) - Val(MonthlyRent.Text)
                        ' Label18.Text = y
                        PayArrears.Text = y
                        PayMonthlyRent.Text = Val(MonthlyRent.Text)
                        TextBox8.Text = Val(Arrears.Text) - y
                        Payplus.Text = 0
                    ElseIf PaidAmount.Text < Val(MonthlyRent.Text) Then

                        PayMonthlyRent.Text = PaidAmount.Text
                        TextBox8.Text = Val(Arrears.Text) + (Val(MonthlyRent.Text) - Val(PaidAmount.Text))
                        PayArrears.Text = 0
                        Payplus.Text = 0
                    End If
                ElseIf x = Val(PaidAmount.Text) Then
                    PayMonthlyRent.Text = Val(MonthlyRent.Text)
                    PayArrears.Text = Val(Arrears.Text)
                    TextBox8.Text = 0

                End If

                ''''''''''''''''''''
                If Val(Payplus.Text) > Val(MonthlyRent.Text) Then
                    TextBox1.Text = Val(Payplus.Text) \ Val(MonthlyRent.Text)
                    TextBox2.Text = (Val(Payplus.Text) Mod Val(MonthlyRent.Text))
                    Dim month As Integer = ReceiptDate.Value.Month

                    'TextBox3.Text = month
                    TextBox4.Text = ReceiptDate.Value.AddMonths(Val(TextBox1.Text))
                End If

                ''''''''''''''''''
                End If
            End Using
            'Note: I added the usage of a parameterized query in the SELECT * query. You should prefer parameterized queries to 
            'in-line SQL because it will protect your code from SQL Injection attacks. Never trust the data typed in by the user

            If conn.State = ConnectionState.Open Then conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub PaidAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaidAmount.TextChanged

    End Sub

    Private Sub cmdserch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdserch.Click

        DataGridView1.ColumnHeadersVisible = False


        Call FillDataGrid()


    End Sub

    Private Sub cmupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmupdate.Click
        '''''''ÇáÊÚÏíá ''''''''''''''''

        Dim query As String = "ArrearsPaymentupdate"         'Stored Procedure name 
        Dim com As New SqlCommand(query, conn)        'creating  SqlCommand  object
        If conn.State = ConnectionState.Open Then conn.Close()
        com.CommandType = CommandType.StoredProcedure 'here we declaring command type as stored Procedure


        ' adding paramerters to  SqlCommand below 

        com.Parameters.AddWithValue("@proindex", proindex.Text)
        com.Parameters.AddWithValue("@PropertyID", PropertyID.Text)
        com.Parameters.AddWithValue("@PaymentType", PaymentType.Text.ToString())
        com.Parameters.AddWithValue("@PaidAmount", PaidAmount.Text)
        com.Parameters.AddWithValue("@ReceiptNo", ReceiptNo.Text)
        com.Parameters.AddWithValue("@ReceiptDate", ReceiptDate.Text)
        com.Parameters.AddWithValue("@CheckNumber", CheckNumber.Text)
        com.Parameters.AddWithValue("@PayMonthlyRent", PayMonthlyRent.Text)
        com.Parameters.AddWithValue("@PayArrears", PayArrears.Text)
        com.Parameters.AddWithValue("@MonthlyRent", MonthlyRent.Text)
        com.Parameters.AddWithValue("@ArrearsLeft", TextBox8.Text)
        com.Parameters.AddWithValue("@Payplus", Payplus.Text)
        com.Parameters.AddWithValue("@Rentfor", Rentfor.Text)

        If conn.State = ConnectionState.Closed Then conn.Open()
        'conn.Open()
        com.ExecuteNonQuery()                    'executing the sqlcommand
        Call updateArrears()
        MsgBox("تم التعديل", MsgBoxStyle.OkOnly, "ادارة العلاقات")

        Call clearbox()


    End Sub

    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        If conn.State = ConnectionState.Open Then conn.Close()

        Dim query As String = "ArrearsPaymentinsert" 'Stored Procedure name 

        Dim com As New SqlCommand(query, conn) 'creating  SqlCommand  object

        com.CommandType = CommandType.StoredProcedure 'here we declaring command type as stored Procedure


        com.Parameters.AddWithValue("@proindex", proindex.Text)
        com.Parameters.AddWithValue("@PropertyID", PropertyID.Text)
        com.Parameters.AddWithValue("@PaymentType", PaymentType.Text)
        com.Parameters.AddWithValue("@PaidAmount", PaidAmount.Text)
        com.Parameters.AddWithValue("@ReceiptNo", ReceiptNo.Text)
        com.Parameters.AddWithValue("@ReceiptDate", ReceiptDate.Text)
        com.Parameters.AddWithValue("@CheckNumber", CheckNumber.Text)
        com.Parameters.AddWithValue("@PayMonthlyRent", PayMonthlyRent.Text)
        com.Parameters.AddWithValue("@PayArrears", PayArrears.Text)
        com.Parameters.AddWithValue("@MonthlyRent", MonthlyRent.Text)
        com.Parameters.AddWithValue("@ArrearsLeft", TextBox8.Text)
        com.Parameters.AddWithValue("@Payplus", Payplus.Text)
        com.Parameters.AddWithValue("@Rentfor", Rentfor.Text)
        com.Parameters.AddWithValue("@OldArreas", Arrears.Text)



        If conn.State = ConnectionState.Closed Then conn.Open()
        com.ExecuteNonQuery()                    'executing the sqlcommand
        Call updateArrears()
        '''''''''ÊÚÏíá ÇáãÊÃÎÑÇÊ Ýí ÇáÌÏæá ÇáÑÆíÓí'''''''
        Call ArrearsUpdateRealestatedata()
        Call payplusact()
        MsgBox("تم الحفظ", MsgBoxStyle.Information)
        Call clearbox()

        conn.Close()

    End Sub

    Private Sub Payplus_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Payplus.TextChanged

    End Sub

    Private Sub Payplus_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Payplus.Validating
        If Arrears.Text > 0 Then
            Payplus.Text = 0
        End If
    End Sub
    Sub PlusTrafic()
        If conn.State = ConnectionState.Open Then conn.Close()

        Dim query As String = "PlusTraficInsert" 'Stored Procedure name 

        Dim com As New SqlCommand(query, conn) 'creating  SqlCommand  object

        com.CommandType = CommandType.StoredProcedure 'here we declaring command type as stored Procedure


        com.Parameters.AddWithValue("@proindex", proindex.Text)
        com.Parameters.AddWithValue("@PropertyID", PropertyID.Text)
        com.Parameters.AddWithValue("@PaidAmount", PaidAmount.Text)
        com.Parameters.AddWithValue("@Payplus", Payplus.Text)
        com.Parameters.AddWithValue("@Rentfor", Rentfor.Text)
        com.Parameters.AddWithValue("@ReceiptDate", ReceiptDate.Text)
        com.Parameters.AddWithValue("@MonthlyRent", MonthlyRent.Text)

        If conn.State = ConnectionState.Closed Then conn.Open()
        com.ExecuteNonQuery()                    'executing the sqlcommand

        conn.Close()
    End Sub
    Sub oldArreas1()
        ' """"في حاله الحذف يتم ارجاع المتأخرات  ما قبل التعديل """""

        Dim Sql1 As String

        Sql1 = "update Realestatedata set Arrears=(SELECT OldArreas FROM ArrearsPayment WHERE proindex ='" & Me.proindex.Text & "'  and ReceiptDate='" & Me.ReceiptDate.Text & "') where proindex ='" & Me.proindex.Text & "'"
        'update Realestatedata set Arrears = (SELECT OldArreas FROM ArrearsPayment WHERE proindex=802 and ReceiptDate='2014-05-01') where proindex=802
        Dim cmd As New SqlCommand(Sql1, conn)

        If conn.State = ConnectionState.Closed Then conn.Open()
        cmd.ExecuteNonQuery()

        If conn.State = ConnectionState.Open Then conn.Close()
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim sql As String = "delete from ArrearsPayment where proindex= '" & proindex.Text & "' and ReceiptDate='" & ReceiptDate.Text & "' "
            Dim cmd As New SqlCommand(sql, conn)
            If MsgBox(" الرجاء مراجعة المتأخرات قبل الحذف ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                If conn.State = ConnectionState.Closed Then conn.Open()
                'Call oldArreas1()

                cmd.ExecuteNonQuery()

                If conn.State = ConnectionState.Open Then conn.Close()
                MsgBox("تم الحذف     ", MsgBoxStyle.Information)

                Call clearbox()
            Else
                MsgBox(" لم يحذف السجل ", MsgBoxStyle.Information)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub payplusact()

        Dim paysubs As Integer
        paysubs = Val(Payplus.Text) - Val(MonthlyRent.Text)
        'Call  PlusTrafic()
        Dim i As Integer
        i = 0
        Dim mont As Integer

        mont = Val(Payplus.Text) \ Val(MonthlyRent.Text)
        '''''''''''''''''''''''''''''''
        For i = 1 To mont
            'paysubs = paysubs - Val(MonthlyRent.Text)

            If conn.State = ConnectionState.Open Then conn.Close()

            Dim query As String = "PlusTraficInsert" 'Stored Procedure name 

            Dim com As New SqlCommand(query, conn) 'creating  SqlCommand  object

            com.CommandType = CommandType.StoredProcedure 'here we declaring command type as stored Procedure

            com.Parameters.AddWithValue("@proindex", proindex.Text)
            com.Parameters.AddWithValue("@PropertyID", PropertyID.Text)
            com.Parameters.AddWithValue("@PaidAmount", PaidAmount.Text)
            com.Parameters.AddWithValue("@Payplus", paysubs)
            com.Parameters.AddWithValue("@Rentfor", MonthName(Month(ReceiptDate.Value.AddMonths(i))))

            com.Parameters.AddWithValue("@ReceiptDate", ReceiptDate.Value.AddMonths(i))
            com.Parameters.AddWithValue("@MonthlyRent", MonthlyRent.Text)

            If conn.State = ConnectionState.Closed Then conn.Open()
            com.ExecuteNonQuery()                    'executing the sqlcommand

            conn.Close()
            paysubs = paysubs - Val(MonthlyRent.Text)
        Next
    End Sub
    Private Sub ArrearsUpdateRealestatedata()

        If conn.State = ConnectionState.Open Then conn.Close()

        Dim query As String = "ArrearsUpdateRealestatedata" 'Stored Procedure name 

        Dim com As New SqlCommand(query, conn) 'creating  SqlCommand  object

        com.CommandType = CommandType.StoredProcedure 'here we declaring command type as stored Procedure


        com.Parameters.AddWithValue("@proindex", proindex.Text)
        
        
        com.Parameters.AddWithValue("@ArrearsLeft", TextBox8.Text)
        


        If conn.State = ConnectionState.Closed Then conn.Open()
        com.ExecuteNonQuery()                    'executing the sqlcommand
        'Call updateArrears()
        ''Call ArrearsUpdateRealestatedata()
        'Call payplusact()
        'MsgBox("Êã ÇáÍÝÙ", MsgBoxStyle.Information)
        'Call clearbox()

        conn.Close()

    End Sub


    Private Sub PropertyID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropertyID.TextChanged

    End Sub

    Private Sub proindex_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles proindex.LostFocus
        Try
            Dim dr As SqlDataReader
            Dim sql As String = "select * from Realestatedata Where proindex='" & Me.proindex.Text & "' "

            Dim cmd As New SqlCommand(sql, conn)
            If conn.State = ConnectionState.Closed Then conn.Open()
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                dr.Read()


                Me.PropertyID.Text = dr.Item("PropertyID")
                Me.LessorName.Text = dr.Item("LessorName")
                Me.CityName.Text = dr.Item("CityName")
                Me.RegionName.Text = dr.Item("RegionName")
                Me.MonthlyRent.Text = dr.Item("MonthlyRent")
                Me.Arrears.Text = dr.Item("Arrears")
                found = 1
            Else
                MsgBox("لا يوجد سجل بهذا الرقم", MsgBoxStyle.OkOnly, "ادارة العقارات")
                found = 0
            End If
            dr.Close()
            If conn.State = ConnectionState.Open Then conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub
    Sub FillDataGrid()

        ds.Clear()

        Dim da As New SqlDataAdapter("select * from ArrearsPayment Where proindex='" & Me.proindex.Text & "' and Rentfor='" & Me.Rentfor.Text & "'", conn)

        da.Fill(ds, "ArrearsPayment")

        DataGridView1.DataSource = ds.Tables("ArrearsPayment")

        'ds.Clear()
    End Sub

    Private Sub ReceiptDate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReceiptDate.LostFocus
        Try
            Dim dr As SqlDataReader
            Dim sql As String = "select * from arrviews Where proindex='" & Me.proindex.Text & "' and ReceiptDate='" & Me.ReceiptDate.Text & "'"

            Dim cmd As New SqlCommand(sql, conn)
            If conn.State = ConnectionState.Closed Then conn.Open()
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then

                dr.Read()

                'If dr.IsDBNull("CheckNumber") Then
                '    Me.CheckNumber.Text = 0
                'Else
                '    Me.CheckNumber.Text = dr.Item("CheckNumber")
                'End If

                Me.PaidAmount.Text = dr.Item("PaidAmount")
                Me.ReceiptNo.Text = dr.Item("ReceiptNo")
                Me.MonthlyRent.Text = dr.Item("MonthlyRent")

                Me.Rentfor.Text = dr.Item("Rentfor")
                Me.PayArrears.Text = dr.Item("PayArrears")
                Me.Payplus.Text = dr.Item("Payplus")


                found = 1
            Else
                MsgBox(" لا يوجد سجـــــل   ", MsgBoxStyle.OkOnly, " ادارة العقارات  ")
                found = 0
            End If
            dr.Close()
            If conn.State = ConnectionState.Open Then conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Cmddelet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmddelet.Click
        If MsgBox("هل فعلا تريد الحذف?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
            MsgBox("سيتم تعديل المتأخرات    ")
            ''''''''''''تعديل المتأخرات'''''''''
            Call oldArreas1()

            ''''''''''''''الحذف'''''''''''''
            Call deletrecord()


        Else
            MsgBox(" لم يحذف السجل ", MsgBoxStyle.Information)
        End If


    End Sub
    Sub deletrecord()
        Try
            Dim sql As String = "delete from ArrearsPayment where proindex= '" & proindex.Text & "' and ReceiptDate='" & ReceiptDate.Text & "' "
            Dim cmd As New SqlCommand(sql, conn)
            If conn.State = ConnectionState.Closed Then conn.Open()
           
            cmd.ExecuteNonQuery()

            If conn.State = ConnectionState.Open Then conn.Close()
            MsgBox("تم الحذف     ", MsgBoxStyle.Information)

            Call clearbox()
           
        Catch ex As Exception

        End Try

    End Sub
    Sub twicePayMent()
        Try
            '  Dim dr As SqlDataReader
           
            Dim sql As String = "select DATENAME(month, ReceiptDate)as hh ,ReceiptDate from ArrearsPayment Where proindex='" & Me.proindex.Text & "' and DATENAME(month, ReceiptDate)='" & Me.Rentfor.Text & "' and  year(ReceiptDate)='" & Year(Me.ReceiptDate.Text) & "'"

            Dim cmd1 As New SqlCommand(sql, conn)
            If conn.State = ConnectionState.Closed Then conn.Open()
            'dr = cmd1.ExecuteReader
            Using reader As SqlDataReader = cmd1.ExecuteReader()
                If reader.HasRows Then


                    If MsgBox("تم دفع الايجار مسبقا في هذا الشهر .......هل تريد دفع متاخرات او مقدم  !", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        formadd.show()
                    End If
               
                End If
            End Using

           
                If conn.State = ConnectionState.Open Then conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub ReceiptDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceiptDate.ValueChanged

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call twicePayMent()

    End Sub

    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.TextChanged

    End Sub
End Class
