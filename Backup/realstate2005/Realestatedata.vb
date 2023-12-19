Imports System.Data
Imports System.Data.SqlClient
Public Class Realestatedata
    Public conn As New SqlConnection("Data Source=MRKTNG-MIS31; Initial Catalog=RealEstate; user id=sa; password=@Sa123456")
    Public found As Boolean

    Private Sub Realestatedata_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        'If e.KeyCode = Keys.Enter Then : e.SuppressKeyPress = True : SendKeys.Send("{TAB}") : End If

        'Dim nextControl As Control
        'If e.KeyCode = Keys.Enter Then
        '    nextControl = GetNextControl(ActiveControl, Not e.Shift)
        '    If nextControl Is Nothing Then
        '        nextControl = GetNextControl(Nothing, True)
        '    End If
        '    nextControl.Focus()
        '    e.SuppressKeyPress = True
        'End If
        'If e.KeyCode = Keys.Enter Then

        '    Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
        '    e.Handled = True
        'End If
        If e.KeyCode = Keys.Enter Then
            System.Windows.Forms.SendKeys.Send("{TAB}")
        End If

        'If e.KeyCode = Keys.Return Then
        '    SendKeys.Send("{TAB}")
        'End If

    End Sub

    Private Sub Realestatedata_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Enter Then
            System.Windows.Forms.SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Realestatedata_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Try
            'Dim dr As SqlDataReader
            Dim Str As String


            Dim com As New SqlCommand
            conn.Open()
            Str = "SELECT max (proindex)+1 from Realestatedata"
            com = New SqlCommand(Str, conn)
            TextBox1.Text = com.ExecuteScalar().ToString()
            If conn.State = ConnectionState.Open Then conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ''''''''
        ''''''''''''''

        conn.Open()
        Dim strSQL As String = "SELECT Distinct RegionID,RegionName FROM Regionss"
        Dim da As New SqlDataAdapter(strSQL, conn)
        Dim ds As New DataSet
        da.Fill(ds, "Regionss")
        'da.Fill(ds)
        With (RegionName)
            .DataSource = ds.Tables("Regionss")
            .DisplayMember = "RegionName"
            .ValueMember = "RegionID"
            .SelectedIndex = 0
        End With
        'Close connection
        conn.Close()


        Dim cmd As New SqlCommand("SELECT Distinct CityName FROM Realestatedata", conn)
        Dim da2 As New SqlDataAdapter(cmd)
        Dim dt2 As New DataTable()
        da2.Fill(dt2)
        If dt2.Rows.Count > 0 Then
            CityName.DataSource = dt2
            CityName.DisplayMember = "CityName"
            'Else
            '    MessageBox.Show("Empty")
        End If
        If conn.State = ConnectionState.Open Then conn.Close()

        ' '''''''''''
        Dim cmd2 As New SqlCommand("SELECT Distinct Propertytype FROM Realestatedata", conn)
        Dim da22 As New SqlDataAdapter(cmd2)
        Dim dt22 As New DataTable()
        da22.Fill(dt22)
        If dt22.Rows.Count > 0 Then
            Propertytype.DataSource = dt22
            Propertytype.DisplayMember = "Propertytype"
            'Else
            '    MessageBox.Show("Empty")
        End If
        If conn.State = ConnectionState.Open Then conn.Close()
        ''''''''''''''''''''''
    End Sub
    Sub clearbox()

        PropertyID.Text = ""
        LessorName.Text = ""
        CityName.Text = ""
        RegionName.Text = ""
        MonthlyRent.Text = ""
        PropertyDes.Text = ""
        ContractDuration.Text = ""
        Arrears.Text = ""
        Propertytype.Text = ""
        TextBox1.Text = ""
        'PropertyID.Focus()


    End Sub

    Private Sub cmdsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsave.Click

        Try
            Dim Sql As String
            If found = 0 Then
                Sql = "insert into Realestatedata(proindex,PropertyID,LessorName,CityName,RegionName, MonthlyRent,ContractDuration,Arrears,Propertytype,PropertyDes)values('" & TextBox1.Text & "','" & PropertyID.Text & "', '" & LessorName.Text & "','" & CityName.Text & "', '" & RegionName.Text & "',  '" & MonthlyRent.Text & "',  '" & ContractDuration.Text & "',  '" & Arrears.Text & "' ,  '" & Propertytype.Text & "' , '" & PropertyDes.Text & "')"
            Else
                Sql = "update Realestatedata set LessorName='" & LessorName.Text & "', CityName='" & CityName.Text & "',RegionName='" & RegionName.Text & "', MonthlyRent='" & MonthlyRent.Text & "',ContractDuration='" & ContractDuration.Text & "',Arrears='" & Arrears.Text & "',PropertyDes= '" & PropertyDes.Text & "',Propertytype='" & Propertytype.Text & "'  Where proindex='" & Me.TextBox1.Text & "' "
                'PropertyID ='" & Me.PropertyID.Text & "'and CityName='" & CityName.Text & "'and RegionName='" & RegionName.Text & "'"
            End If
            Dim cmd As New SqlCommand(Sql, conn)
            If conn.State = ConnectionState.Closed Then conn.Open()
            cmd.ExecuteNonQuery()
            If conn.State = ConnectionState.Open Then conn.Close()
            MsgBox(" „ «·Õ›Ÿ", MsgBoxStyle.Information)
            Call clearbox()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click

        Try

            Dim sql As String = "delete from Realestatedata where proindex= '" & TextBox1.Text & "' "
            Dim cmd As New SqlCommand(sql, conn)
            If MsgBox("Â·  —Ìœ Õ–› «·”Ã· ›⁄·«", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                '''''''''''''''''''''
                Call insertdelet()
                '''''''''''''''''''''
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

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        'OnKeyDown = "if(event.keyCode==13)event.keyCode=9"

        'If e.KeyCode = Keys.Enter Then
        '    SendKeys.Send("{TAB}")
        'End If
    End Sub

    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        Try
            Dim dr As SqlDataReader
            Dim sql As String = "select * from Realestatedata Where proindex='" & Me.TextBox1.Text & "' "
            'and CityName='" & CityName.Text & "' and RegionName='" & RegionName.Text & "'"
            Dim cmd As New SqlCommand(sql, conn)
            If conn.State = ConnectionState.Closed Then conn.Open()
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                dr.Read()

                'Me.PropertyID = dr.Item("PropertyID")
                'Me.PropertyID.Text = dr.Item("PropertyID")

                If DBNull.Value.Equals(dr.Item("PropertyID")) Then
                    PropertyID.Text = ""
                Else
                    PropertyID.Text = dr.Item("PropertyID")
                End If

                If DBNull.Value.Equals(dr.Item("LessorName")) Then
                    Me.LessorName.Text = ""
                Else
                    Me.LessorName.Text = dr.Item("LessorName")
                End If
                If DBNull.Value.Equals(dr.Item("CityName")) Then
                    Me.CityName.Text = ""
                Else
                    Me.CityName.Text = dr.Item("CityName")
                End If
                ''''''''
                If DBNull.Value.Equals(dr.Item("RegionName")) Then
                    Me.RegionName.Text = ""
                Else
                    Me.RegionName.Text = dr.Item("RegionName")
                End If
                If DBNull.Value.Equals(dr.Item("PropertyDes")) Then
                    Me.PropertyDes.Text = ""
                Else
                    Me.PropertyDes.Text = dr.Item("PropertyDes")
                End If
                '''''
                If DBNull.Value.Equals(dr.Item("Arrears")) Then
                    Me.Arrears.Text = ""
                Else
                    Me.Arrears.Text = dr.Item("Arrears")
                End If

                If DBNull.Value.Equals(dr.Item("MonthlyRent")) Then
                    Me.MonthlyRent.Text = ""
                Else
                    Me.MonthlyRent.Text = dr.Item("MonthlyRent")
                End If
                '''''''''
                If DBNull.Value.Equals(dr.Item("ContractDuration")) Then
                    Me.ContractDuration.Text = ""
                Else
                    Me.ContractDuration.Text = dr.Item("ContractDuration")
                End If
                '''''''''''
                If DBNull.Value.Equals(dr.Item("Propertytype")) Then
                    Me.Propertytype.Text = ""
                Else
                    Me.Propertytype.Text = dr.Item("Propertytype")
                End If

                'Me.PropertyID.Text = dr.Item("PropertyID")
                'Me.LessorName.Text = dr.Item("LessorName")
                'Me.CityName.Text = dr.Item("CityName")
                'Me.RegionName.Text = dr.Item("RegionName")
                ''Me.PropertyDes.Text = dr.Item("PropertyDes")
                'Me.Arrears.Text = dr.Item("Arrears")
                'Me.MonthlyRent.Text = dr.Item("MonthlyRent")
                'Me.ContractDuration.Text = dr.Item("ContractDuration")
                'Me.Propertytype.Text = dr.Item("Propertytype")

                found = 1
            Else
                found = 0
            End If
            dr.Close()
            If conn.State = ConnectionState.Open Then conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    

    Private Sub cmdclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclose.Click
        Me.Close()

    End Sub

    Private Sub PropertyID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PropertyID.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    System.Windows.Forms.SendKeys.Send("{TAB}")
        'End If

    End Sub

    Private Sub PropertyID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropertyID.TextChanged

    End Sub

    Private Sub RegionName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RegionName.KeyDown

        'If e.KeyCode = Keys.Enter Then
        '    System.Windows.Forms.SendKeys.Send("{TAB}")
        'End If


    End Sub

    Private Sub RegionName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegionName.SelectedIndexChanged

    End Sub

    Private Sub CityName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CityName.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    System.Windows.Forms.SendKeys.Send("{TAB}")
        'End If

    End Sub

    Private Sub CityName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CityName.SelectedIndexChanged

    End Sub

    Private Sub Propertytype_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Propertytype.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    System.Windows.Forms.SendKeys.Send("{TAB}")
        'End If

    End Sub

    Private Sub Propertytype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Propertytype.SelectedIndexChanged

    End Sub

    Private Sub PropertyDes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropertyDes.TextChanged

    End Sub

    Private Sub LessorName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LessorName.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    System.Windows.Forms.SendKeys.Send("{TAB}")
        'End If

    End Sub

    Private Sub LessorName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LessorName.TextChanged

    End Sub

    Private Sub MonthlyRent_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MonthlyRent.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    System.Windows.Forms.SendKeys.Send("{TAB}")
        'End If

    End Sub

    Private Sub MonthlyRent_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthlyRent.TextChanged

    End Sub

    Private Sub ContractDuration_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ContractDuration.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    System.Windows.Forms.SendKeys.Send("{TAB}")
        'End If


    End Sub

    Private Sub ContractDuration_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContractDuration.TextChanged

    End Sub

    Private Sub Arrears_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Arrears.KeyDown

        'If e.KeyCode = Keys.Enter Then
        '    System.Windows.Forms.SendKeys.Send("{TAB}")
        'End If


    End Sub

    Private Sub Arrears_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Arrears.TextChanged

    End Sub

    Private Sub cmdsave_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdsave.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    System.Windows.Forms.SendKeys.Send("{TAB}")
        'End If

    End Sub

    Private Sub cmddelete_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmddelete.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    System.Windows.Forms.SendKeys.Send("{TAB}")
        'End If

        'If e.KeyCode = Keys.Return Then
        '    SendKeys.Send("{TAB}")
        'End If

    End Sub

    Private Sub cmdclose_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdclose.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    System.Windows.Forms.SendKeys.Send("{TAB}")

        'End If

        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If

    End Sub
    Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            'AndAlso Not ActiveControl.GetType() Is GetType(Class1) Then
            e.Handled = True
            Me.ProcessTabKey(Not e.Shift)
        Else
            MyBase.OnKeyUp(e)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            'Dim dr As SqlDataReader
            Dim Str As String


            Dim com As New SqlCommand
            conn.Open()
            Str = "SELECT max (proindex)+1 from Realestatedata"
            com = New SqlCommand(Str, conn)
            TextBox1.Text = com.ExecuteScalar().ToString()
            If conn.State = ConnectionState.Open Then conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Sub insertdelet()
        Try
            Dim Sl As String
            'If found = 0 Then
            Sl = "insert into Realestatedata22(proindex,PropertyID,LessorName,CityName,RegionName, MonthlyRent,ContractDuration,Arrears,Propertytype,PropertyDes)values('" & TextBox1.Text & "','" & PropertyID.Text & "', '" & LessorName.Text & "','" & CityName.Text & "', '" & RegionName.Text & "',  '" & MonthlyRent.Text & "',  '" & ContractDuration.Text & "',  '" & Arrears.Text & "' ,  '" & Propertytype.Text & "' , '" & PropertyDes.Text & "')"
            'Else
            'Sl = "update Realestatedata22 set LessorName='" & LessorName.Text & "', CityName='" & CityName.Text & "',RegionName='" & RegionName.Text & "', MonthlyRent='" & MonthlyRent.Text & "',ContractDuration='" & ContractDuration.Text & "',Arrears='" & Arrears.Text & "',PropertyDes= '" & PropertyDes.Text & "',Propertytype='" & Propertytype.Text & "'  Where proindex='" & Me.TextBox1.Text & "' "
            'PropertyID ='" & Me.PropertyID.Text & "'and CityName='" & CityName.Text & "'and RegionName='" & RegionName.Text & "'"
            'End If
            Dim cmd2 As New SqlCommand(Sl, conn)
            If conn.State = ConnectionState.Closed Then conn.Open()
            cmd2.ExecuteNonQuery()
            If conn.State = ConnectionState.Open Then conn.Close()

            'MsgBox(" „ «·Õ›Ÿ", MsgBoxStyle.Information)
            'Call clearbox()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class