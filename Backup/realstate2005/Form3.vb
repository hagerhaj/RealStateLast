Public Class Form3

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'http://mrktng-mis31/ReportServer/Pages/ReportViewer.aspx?%2frealpayrentregion%2fReport1&rs%3aCommand=Render
        WebBrowser1.Navigate("http://mrktng-mis31/ReportServer/Pages/ReportViewer.aspx?%2freal12121%2fReport1&rs:Command=Render")

    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

    End Sub
End Class