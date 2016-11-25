Imports System.Data.SqlClient

Public Class Estado_Asig_Desconexiones
    Private Sub can_Cuentasdia()
        Dim dia As Integer = ComboBox1.Text
        Dim consulta As String = "select COUNT(Cuenta )AS 'Cantidad Faltantes' FROM ASIG_DESCONEXIONES where Dia_Dx=" & dia & ""
        Dim dttable As New DataTable
        Dim adaptadorsql = New SqlDataAdapter(consulta, New SqlConnection(coneccion))
        adaptadorsql.Fill(dttable)
        Label5.DataBindings.Add(New Binding("Text", dttable, "Cantidad Faltantes"))
    End Sub
    Private Sub can_Toalcuentas()
        Dim consulta As String = "select count(Cuenta) As 'Cantidad Faltantes' from  ASIG_DESCONEXIONES "
        Dim dttable As New DataTable
        Dim adaptadorsql = New SqlDataAdapter(consulta, New SqlConnection(coneccion))
        adaptadorsql.Fill(dttable)
        Label6.DataBindings.Add(New Binding("Text", dttable, "Cantidad Faltantes"))
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Label5.DataBindings.Clear()
        Label5.Text = ""
        can_Cuentasdia()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        limpiar(Me)
        Label6.DataBindings.Clear()
        Label6.Text = 0
        can_Toalcuentas()
    End Sub
End Class
