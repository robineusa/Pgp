Imports System.Data.SqlClient

Public Class Estado_Asig_Agendamiento

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Label2.DataBindings.Clear()
        Label2.Text = 0

        Dim consulta As String = "select COUNT(Cuenta)AS 'Cantidad Faltantes' FROM ASIG_AGENDAMIENTO"
        Dim dttable As New DataTable
        Dim adaptadorsql = New SqlDataAdapter(consulta, New SqlConnection(coneccion))
        adaptadorsql.Fill(dttable)
        Label2.DataBindings.Add(New Binding("Text", dttable, "Cantidad Faltantes"))
    End Sub
End Class