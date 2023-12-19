Public Class Form4

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WebBrowser1.Navigate("http://mrktng-mis31/ReportServer/Pages/ReportViewer.aspx?%2frealregionsrens%2fReport1&rs:Command=Render")
    End Sub
End Class