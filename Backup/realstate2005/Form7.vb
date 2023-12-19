Public Class Form7

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted


    End Sub

    Private Sub Form7_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WebBrowser1.Navigate("http://mrktng-mis31/ReportServer/Pages/ReportViewer.aspx?%2frealcityregion%2fReport1&rs:Command=Render")
    End Sub
End Class