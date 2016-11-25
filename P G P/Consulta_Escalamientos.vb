Imports System.Data.SqlClient

Public Class Consulta_Escalamientos

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        limpiar(Me)
        DataGridView1.Show()
        DataGridView1.DataBindings.Clear()
        DataGridView1.DataSource = ""

        Dim dt1, dt2 As New DataTable
        Dim c1, c2 As String
        Dim usuario As String = ""
        Dim fechaini As String = TextBox1.Text
        Dim fechafin As String = TextBox2.Text


        c1 = "select Usuario from  USUARIOS where Nombre_Usuario like'" & nombreusuario & "'"
        Dim adaptadorsql As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql.Fill(dt1)
        Dim i As Integer

        For i = 0 To dt1.Rows.Count - 1
            usuario = dt1.Rows(i).Item("Usuario")
        Next

        c2 = "select * from ESCALAMIENTOS where Usuario like'" & usuario & "' and CONVERT(VARCHAR(10),Fecha_Escalamiento, 103) between '" & fechaini & "' and '" & fechafin & "'"
        Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
        adaptadorsql2.Fill(dt2)
        DataGridView1.DataSource = dt2
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        limpiar(Me)
        DataGridView1.Hide()
        DataGridView1.DataBindings.Clear()
        DataGridView1.DataSource = ""
    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        limpiar(Me)
        DataGridView1.Hide()
        DataGridView1.DataBindings.Clear()
        DataGridView1.DataSource = ""
    End Sub
End Class