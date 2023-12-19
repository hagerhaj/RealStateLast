Imports System.Data
Imports System.Data.SqlClient
Public Class Form1
    Public x, y
    Public conn As New SqlConnection("Data Source=MRKTNG-MIS31; Initial Catalog=RealEstate; user id=sa; password=@Sa123456")
    Public found As Boolean

    Private Sub Form1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then

            Dim oNextControl As System.Windows.Forms.Control = Me.GetNextControl(sender, True)

            oNextControl.Focus()

        End If
        'if e.KeyCode = 13 Then SendKeys.Send ({"TAB"}) 'Instructions End If

    End Sub

    Private Sub Form1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Enter Then
            System.Windows.Forms.SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim monthw As Integer = ReceiptDate.Value.Month
        If monthw = 1 Then Rentfor.Text = "Ì‰«Ì—"
        If monthw = 2 Then Rentfor.Text = "›»—«Ì—"
        If monthw = 3 Then Rentfor.Text = "„«—”"
        If monthw = 4 Then Rentfor.Text = "«»—Ì·"
        If monthw = 5 Then Rentfor.Text = "„«ÌÊ"
        If monthw = 6 Then Rentfor.Text = "ÌÊ‰ÌÊ"
        If monthw = 7 Then Rentfor.Text = "ÌÊ·ÌÊ"
        If monthw = 8 Then Rentfor.Text = "«€”ÿ”"
        If monthw = 9 Then Rentfor.Text = "”» „»—"
        If monthw = 10 Then Rentfor.Text = "«ﬂ Ê»—"
        If monthw = 11 Then Rentfor.Text = "‰Ê›„»—"
        If monthw = 12 Then Rentfor.Text = "œÌ”„»—"
        ''''''''''''''''
        cmupdate.Enabled = False
    End Sub
    Sub clearbox()
        proindex.Text = ""
        PropertyID.Text = ""
        PaymentType.Text = "‰ﬁœ«"
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
    End Sub

    Private Sub PaidAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaidAmount.TextChanged

    End Sub

    Private Sub cmdserch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdserch.Click
        Try
            Dim dr As SqlDataReader
            Dim sql As String = "select * from ArrearsPayment Where proindex='" & Me.proindex.Text & "' and Rentfor='" & Me.Rentfor.Text & "'"
            'and CityName='" & CityName.Text & "' and RegionName='" & RegionName.Text & "'"
            Dim cmd As New SqlCommand(sql, conn)
            If conn.State = ConnectionState.Closed Then conn.Open()
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                dr.Read()


                If DBNull.Value.Equals(dr.Item("PaidAmount")) Then
                    PaidAmount.Text = ""
                Else
                    PaidAmount.Text = dr.Item("PaidAmount")
                End If
                ''''''''''''''''''''''
                If DBNull.Value.Equals(dr.Item("ReceiptNo")) Then
                    Me.ReceiptNo.Text = ""
                Else
                    Me.ReceiptNo.Text = dr.Item("ReceiptNo")
                End If
                ''''''''''''''''''
                If DBNull.Value.Equals(dr.Item("ReceiptDate")) Then
                    Me.ReceiptDate.Text = ""
                Else
                    Me.ReceiptDate.Text = dr.Item("ReceiptDate")
                End If
                ''''''''

                If DBNull.Value.Equals(dr.Item("CheckNumber")) Then
                    Me.CheckNumber.Text = ""
                Else
                    Me.CheckNumber.Text = dr.Item("CheckNumber")
                End If
                ''''''''''''''''''
                If DBNull.Value.Equals(dr.Item("PayMonthlyRent")) Then
                    Me.PayMonthlyRent.Text = ""
                Else
                    Me.PayMonthlyRent.Text = dr.Item("PayMonthlyRent")
                End If

                '''''
                If DBNull.Value.Equals(dr.Item("PayArrears")) Then
                    Me.PayArrears.Text = ""
                Else
                    Me.PayArrears.Text = dr.Item("PayArrears")
                End If
                '''''''''''''''''''''
                If DBNull.Value.Equals(dr.Item("MonthlyRent")) Then
                    Me.MonthlyRent.Text = ""
                Else
                    Me.MonthlyRent.Text = dr.Item("MonthlyRent")
                End If
                '''''''''
                If DBNull.Value.Equals(dr.Item("MonthlyRent")) Then
                    Me.MonthlyRent.Text = ""
                Else
                    Me.MonthlyRent.Text = dr.Item("MonthlyRent")
                End If
                '''''''''''
                If DBNull.Value.Equals(dr.Item("ArrearsLeft")) Then
                    Me.TextBox8.Text = ""
                Else
                    Me.TextBox8.Text = dr.Item("ArrearsLeft")
                End If
                '''''''''''''''''
                If DBNull.Value.Equals(dr.Item("Payplus")) Then
                    Me.Payplus.Text = ""
                Else
                    Me.Payplus.Text = dr.Item("Payplus")
                End If
                ''''''''''''''''''''''''''''
                'If DBNull.Value.Equals(dr.Item("Payplus")) Then
                '    Me.Payplus.Text = ""
                'Else
                '    Me.Payplus.Text = dr.Item("Payplus")
                'End If
                ''com.Parameters.AddWithValue("PaidAmount", PaidAmount.Text)
                ''com.Parameters.AddWithValue("ReceiptNo", ReceiptNo.Text)
                ''com.Parameters.AddWithValue("ReceiptDate", ReceiptDate.Text)
                ''com.Parameters.AddWithValue("CheckNumber", CheckNumber.Text)
                ''com.Parameters.AddWithValue("PayMonthlyRent", PayMonthlyRent.Text)
                ''com.Parameters.AddWithValue("PayArrears", PayArrears.Text)
                ''com.Parameters.AddWithValue("MonthlyRent", MonthlyRent.Text)
                'com.Parameters.AddWithValue("ArrearsLeft", TextBox8.Text)
                'com.Parameters.AddWithValue("Payplus", Payplus.Text)
                'com.Parameters.AddWithValue("@Rentfor", Rentfor.Text)

                found = 1
                cmupdate.Enabled = True
            Else
                MsgBox(" ·«ÌÊÃœ ”Ã· »Â–« «·—ﬁ„ Ê«· «—ÌŒ", MsgBoxStyle.OkOnly, "»—‰«„Ã «·⁄ﬁ«—« ")
                found = 0
            End If
            dr.Close()
            If conn.State = ConnectionState.Open Then conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try



        ''''''''''''''''«·»ÕÀ »«·—ﬁ„'''''''''''''''''''''
        'Try
        '    Dim dr As SqlDataReader
        '    Dim sql2 As String = "select * from ArrearsPayment Where proindex='" & Me.proindex.Text & "' and ReceiptDate='" & Me.ReceiptDate.Text & "'"
        '    Dim cmd As New SqlCommand(sql2, conn)
        '    If conn.State = ConnectionState.Closed Then conn.Open()
        '    dr = cmd.ExecuteReader
        '    If dr.HasRows = True Then
        '        dr.Read()
        '        Me.PropertyID.Text = dr.Item("PropertyID")
        '        Me.PaymentType.Text = dr.Item("PaymentType")
        '        Me.PayMonthlyRent.Text = dr.Item("PayMonthlyRent")
        '        Me.PayArrears.Text = dr.Item("PayArrears")
        '        Me.MonthlyRent.Text = dr.Item("MonthlyRent")
        '        Me.TextBox8.Text = dr.Item("ArrearsLeft")
        '        Me.Payplus.Text = dr.Item("Payplus")
        '        Me.PaidAmount.Text = dr.Item("PaidAmount")
        '        Me.ReceiptNo.Text = dr.Item("ReceiptNo")
        '        Me.ReceiptDate.Text = dr.Item("ReceiptDate")
        '        Me.CheckNumber.Text = dr.Item("CheckNumber")
        '        'Me.ReceiptNo.Text = dr.Item("ReceiptNo")
        '        Me.Rentfor.Text = dr.Item("Rentfor")


        '        found = 1
        '    Else
        '        MsgBox(" ·«ÌÊÃœ ”Ã· »Â–« «·—ﬁ„ Ê«· «—ÌŒ", MsgBoxStyle.OkOnly, "»—‰«„Ã «·⁄ﬁ«—« ")
        '        found = 0
        '    End If
        '    dr.Close()
        '    If conn.State = ConnectionState.Open Then conn.Close()
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try
    End Sub

    Private Sub cmupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmupdate.Click
        '''''''«· ⁄œÌ· ''''''''''''''''

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
        MsgBox(" „ «· ⁄œÌ·", MsgBoxStyle.OkOnly, "»—‰«„Ã «·⁄ﬁ«—« ")

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


        If conn.State = ConnectionState.Closed Then conn.Open()
        com.ExecuteNonQuery()                    'executing the sqlcommand
        Call updateArrears()
        ''''''''' ⁄œÌ· «·„ √Œ—«  ›Ì «·ÃœÊ· «·—∆Ì”Ì'''''''
        Call ArrearsUpdateRealestatedata()
        Call payplusact()
        MsgBox(" „ «·Õ›Ÿ", MsgBoxStyle.Information)
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

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try

            Dim sql As String = "delete from ArrearsPayment where proindex= '" & proindex.Text & "' and ReceiptDate='" & ReceiptDate.Text & "' "
            Dim cmd As New SqlCommand(sql, conn)
            If MsgBox("Â·  —Ìœ Õ–› «·”Ã· ›⁄·«........ «·—Ã«¡ „—«Ã⁄… «·„ √Œ—«  ﬁ»· «·Õ–›", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If conn.State = ConnectionState.Closed Then conn.Open()
                cmd.ExecuteNonQuery()
                If conn.State = ConnectionState.Open Then conn.Close()
                MsgBox(" „ «·Õ–›     ", MsgBoxStyle.Information)
                Call clearbox()
            Else
                MsgBox("  —«Ã⁄ ⁄‰ «·Õ–›", MsgBoxStyle.Information)
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
            com.Parameters.AddWithValue("@Rentfor", Rentfor.Text)
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
        'MsgBox(" „ «·Õ›Ÿ", MsgBoxStyle.Information)
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
                MsgBox(" ·«ÌÊÃœ ”Ã· »Â–« «·—ﬁ„ Ê«· «—ÌŒ", MsgBoxStyle.OkOnly, "»—‰«„Ã «·⁄ﬁ«—« ")
                found = 0
            End If
            dr.Close()
            If conn.State = ConnectionState.Open Then conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        ''''''''''''''''''''''''''''''


        'Me.PropertyID = dr.Item("PropertyID")
        ''

        'Me.PropertyDes.Text = dr.Item("PropertyDes")
        'Me.Arrears.Text = dr.Item("Arrears")
        'Me.MonthlyRent.Text = dr.Item("MonthlyRent")
        'Me.ContractDuration.Text = dr.Item("ContractDuration")
        'Me.Propertytype.Text = dr.Item("Propertytype")
        ''''''''''''«·«” —Ã«⁄'''''''''''
        'Try
        '    Dim dr As SqlDataReader
        '    Dim sql As String = "select * from ArrearsPayment Where proindex='" & Me.proindex.Text & "' and Rentfor='" & Me.Rentfor.Text & "'"
        '    'and CityName='" & CityName.Text & "' and RegionName='" & RegionName.Text & "'"
        '    Dim cmd As New SqlCommand(sql, conn)
        '    If conn.State = ConnectionState.Closed Then conn.Open()
        '    dr = cmd.ExecuteReader
        '    If dr.HasRows = True Then
        '        dr.Read()


        '        If DBNull.Value.Equals(dr.Item("PaidAmount")) Then
        '            PaidAmount.Text = ""
        '        Else
        '            PropertyID.Text = dr.Item("PaidAmount")
        '        End If
        '        ''''''''''''''''''''''
        '        If DBNull.Value.Equals(dr.Item("ReceiptNo")) Then
        '            Me.ReceiptNo.Text = ""
        '        Else
        '            Me.LessorName.Text = dr.Item("ReceiptNo")
        '        End If
        '        ''''''''''''''''''
        '        If DBNull.Value.Equals(dr.Item("ReceiptDate")) Then
        '            Me.ReceiptDate.Text = ""
        '        Else
        '            Me.CityName.Text = dr.Item("ReceiptDate")
        '        End If
        '        ''''''''

        '        If DBNull.Value.Equals(dr.Item("CheckNumber")) Then
        '            Me.CheckNumber.Text = ""
        '        Else
        '            Me.CheckNumber.Text = dr.Item("CheckNumber")
        '        End If
        '        ''''''''''''''''''
        '        If DBNull.Value.Equals(dr.Item("PayMonthlyRent")) Then
        '            Me.PayMonthlyRent.Text = ""
        '        Else
        '            Me.PayMonthlyRent.Text = dr.Item("PayMonthlyRent")
        '        End If

        '        '''''
        '        If DBNull.Value.Equals(dr.Item("PayArrears")) Then
        '            Me.PayArrears.Text = ""
        '        Else
        '            Me.PayArrears.Text = dr.Item("PayArrears")
        '        End If
        '        '''''''''''''''''''''
        '        If DBNull.Value.Equals(dr.Item("MonthlyRent")) Then
        '            Me.MonthlyRent.Text = ""
        '        Else
        '            Me.MonthlyRent.Text = dr.Item("MonthlyRent")
        '        End If
        '        '''''''''
        '        If DBNull.Value.Equals(dr.Item("MonthlyRent")) Then
        '            Me.MonthlyRent.Text = ""
        '        Else
        '            Me.MonthlyRent.Text = dr.Item("MonthlyRent")
        '        End If
        '        '''''''''''
        '        If DBNull.Value.Equals(dr.Item("ArrearsLeft")) Then
        '            Me.TextBox8.Text = ""
        '        Else
        '            Me.TextBox8.Text = dr.Item("ArrearsLeft")
        '        End If
        '        '''''''''''''''''
        '        If DBNull.Value.Equals(dr.Item("Payplus")) Then
        '            Me.Payplus.Text = ""
        '        Else
        '            Me.Payplus.Text = dr.Item("Payplus")
        '        End If
        '        ''''''''''''''''''''''''''''
        '        'If DBNull.Value.Equals(dr.Item("Payplus")) Then
        '        '    Me.Payplus.Text = ""
        '        'Else
        '        '    Me.Payplus.Text = dr.Item("Payplus")
        '        'End If
        '        ''com.Parameters.AddWithValue("PaidAmount", PaidAmount.Text)
        '        ''com.Parameters.AddWithValue("ReceiptNo", ReceiptNo.Text)
        '        ''com.Parameters.AddWithValue("ReceiptDate", ReceiptDate.Text)
        '        ''com.Parameters.AddWithValue("CheckNumber", CheckNumber.Text)
        '        ''com.Parameters.AddWithValue("PayMonthlyRent", PayMonthlyRent.Text)
        '        ''com.Parameters.AddWithValue("PayArrears", PayArrears.Text)
        '        ''com.Parameters.AddWithValue("MonthlyRent", MonthlyRent.Text)
        '        'com.Parameters.AddWithValue("ArrearsLeft", TextBox8.Text)
        '        'com.Parameters.AddWithValue("Payplus", Payplus.Text)
        '        'com.Parameters.AddWithValue("@Rentfor", Rentfor.Text)

        '        found = 1
        '    Else
        '        found = 0
        '    End If
        '    dr.Close()
        '    If conn.State = ConnectionState.Open Then conn.Close()
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try

    End Sub

    Private Sub proindex_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles proindex.TextChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()

    End Sub

    Private Sub Rentfor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rentfor.SelectedIndexChanged

    End Sub
End Class
