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

    Private Sub «·»Ì«‰« «·«”«”Ì…ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles «·»Ì«‰« «·«”«”Ì…ToolStripMenuItem.Click
        Realestatedata.Show()
    End Sub

    Private Sub «·«ÌÃ«—« ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles «·«ÌÃ«—« ToolStripMenuItem.Click
        Form1.Show()
    End Sub

    Private Sub «·«ÌÃ«—«·‘Â—ÌÕ”»«·«ﬁ·Ì„ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles «·«ÌÃ«—«·‘Â—ÌÕ”»«·«ﬁ·Ì„ToolStripMenuItem.Click
        Form2.Show()

    End Sub

    Private Sub ﬂ·«·⁄ﬁ«—« »«·«ﬁ«·Ì„ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ﬂ·«·⁄ﬁ«—« »«·«ﬁ«·Ì„ToolStripMenuItem.Click
        Form3.Show()

    End Sub

    Private Sub Ã„·…«·«ÌÃ«—« »ﬂ·«ﬁ·Ì„ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ã„·…«·«ÌÃ«—« »ﬂ·«ﬁ·Ì„ToolStripMenuItem.Click
        Form4.Show()

    End Sub

    Private Sub Ã„·…„ √Œ—« «·«ﬁ«·Ì„ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ã„·…„ √Œ—« «·«ﬁ«·Ì„ToolStripMenuItem.Click
        Form5.Show()
    End Sub

    Private Sub „ √Œ—« «·«ﬁ«·Ì„ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles „ √Œ—« «·«ﬁ«·Ì„ToolStripMenuItem.Click
        Form6.Show()
    End Sub

    Private Sub «·«ÌÃ«—« «·‘Â—Ì…Õ”»«·«ﬁ·Ì„Ê«·„œÌ‰…ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles «·«ÌÃ«—« «·‘Â—Ì…Õ”»«·«ﬁ·Ì„Ê«·„œÌ‰…ToolStripMenuItem.Click
        Form7.Show()
    End Sub
End Class
