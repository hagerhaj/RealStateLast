Imports System.Net

Imports System.Data
Imports System.Data.SqlClient

Public Class Form2
   
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Dim credential As New NetworkCredential("administrator", "mis2014#")
            Me.ReportViewer1.ServerReport.ReportServerCredentials.NetworkCredentials = credential
            'select where the report should be generated with the report viewer control or on the report server using the SSRS service.
            Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote
            Me.ReportViewer1.ServerReport.ReportServerUrl = New Uri("http://196.1.236.38/ReportServer")
            ReportViewer1.ServerReport.ReportPath = "/realpayrentregion/Report1"
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
        'Call GetConnectionOfReportServer()
        Me.ReportViewer1.RefreshReport()
    End Sub

    Public Sub GetConnectionOfReportServer()
        Try
            Dim credential As New NetworkCredential("administrator", "mis2014#", "Domain")
            Me.ReportViewer1.ServerReport.ReportServerCredentials.NetworkCredentials = credential
            'select where the report should be generated with the report viewer control or on the report server using the SSRS service.
            Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote
            Me.ReportViewer1.ServerReport.ReportServerUrl = New Uri("http://196.1.236.38/ReportServer")
            ReportViewer1.ServerReport.ReportPath = "/realpayrentregion/Report1"
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub ReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ReportViewer1_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportViewer1.Load

    End Sub
End Class