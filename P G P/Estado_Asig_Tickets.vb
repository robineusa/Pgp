Imports System.Data.SqlClient

Public Class Estado_Asig_Tickets

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Label2.DataBindings.Clear()
        Label2.Text = 0

        Dim consulta As String = "select COUNT(Cuenta)AS 'Cantidad Faltantes' FROM ASIG_TICKETS"
        Dim dttable As New DataTable
        Dim adaptadorsql = New SqlDataAdapter(consulta, New SqlConnection(coneccion))
        adaptadorsql.Fill(dttable)
        Label2.DataBindings.Add(New Binding("Text", dttable, "Cantidad Faltantes"))
    End Sub

    Private Sub Estado_Asig_Tickets_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class