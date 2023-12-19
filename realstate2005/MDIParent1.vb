Imports System.Windows.Forms

Public Class MDIParent1

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Global.System.Windows.Forms.Application.Exit()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticleToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer = 0

    Private Sub ÇáÈíÇäÇÊÇáÇÓÇÓíÉToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÇáÈíÇäÇÊÇáÇÓÇÓíÉToolStripMenuItem.Click
        Realestatedata.Show()
    End Sub

    Private Sub ÇáÇíÌÇÑÇÊToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÇáÇíÌÇÑÇÊToolStripMenuItem.Click
        Form1.Show()
    End Sub

    Private Sub ÇáÇíÌÇÑÇáÔåÑíÍÓÈÇáÇÞáíãToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÇáÇíÌÇÑÇáÔåÑíÍÓÈÇáÇÞáíãToolStripMenuItem.Click
        Form2.Show()

    End Sub

    Private Sub ßáÇáÚÞÇÑÇÊÈÇáÇÞÇáíãToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ßáÇáÚÞÇÑÇÊÈÇáÇÞÇáíãToolStripMenuItem.Click
        Form3.Show()

    End Sub

    Private Sub ÌãáÉÇáÇíÌÇÑÇÊÈßáÇÞáíãToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÌãáÉÇáÇíÌÇÑÇÊÈßáÇÞáíãToolStripMenuItem.Click
        Form4.Show()

    End Sub

    Private Sub ÌãáÉãÊÃÎÑÇÊÇáÇÞÇáíãToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÌãáÉãÊÃÎÑÇÊÇáÇÞÇáíãToolStripMenuItem.Click
        Form5.Show()
    End Sub

    Private Sub ãÊÃÎÑÇÊÇáÇÞÇáíãToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ãÊÃÎÑÇÊÇáÇÞÇáíãToolStripMenuItem.Click
        Form6.Show()
    End Sub

    Private Sub ÇáÇíÌÇÑÇÊÇáÔåÑíÉÍÓÈÇáÇÞáíãæÇáãÏíäÉToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÇáÇíÌÇÑÇÊÇáÔåÑíÉÍÓÈÇáÇÞáíãæÇáãÏíäÉToolStripMenuItem.Click
        Form7.Show()
    End Sub

    Private Sub بحثحسبنوعالعقارToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles بحثحسبنوعالعقارToolStripMenuItem.Click
        FrmSearch.Show()

    End Sub

    Private Sub بالتاريخToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles بالتاريخToolStripMenuItem.Click
        Form8.Show()

    End Sub

    Private Sub الذينلميدفعوخلالشهرToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles الذينلميدفعوخلالشهرToolStripMenuItem.Click
        Form10.Show()

    End Sub

    Private Sub جملةالمدفوععنشهرToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles جملةالمدفوععنشهرToolStripMenuItem.Click
        Form11.Show()
    End Sub

    Private Sub نسبةالدفعللايجارToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles نسبةالدفعللايجارToolStripMenuItem.Click
        Form12.Show()
    End Sub

    Private Sub نسبةدفعالمتأخراتToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles نسبةدفعالمتأخراتToolStripMenuItem.Click
        Form13.Show()

    End Sub

    Private Sub المدفوعاتبالاقليمToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles المدفوعاتبالاقليمToolStripMenuItem.Click
        Form14.Show()

    End Sub

    Private Sub الجملةبينتاريخينToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles الجملةبينتاريخينToolStripMenuItem.Click
        SumPaidBetwRep.Show()

    End Sub

    Private Sub الدفعالمـــقــــــــدمToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles الدفعالمـــقــــــــدمToolStripMenuItem.Click
        Form15.Show()

    End Sub
End Class
