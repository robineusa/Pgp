Imports System.Data.SqlClient

Public Class Gestiones_Asignadas
    Dim bs As New BindingSource

    Private Sub cargar_registros(ByVal sql As String, ByVal dv As DataGridView)
        Dim dom As String = 2
        Dim consulta As String = "select Nombre_Usuario ,Nombre_Gestion AS 'Gestion 1' ,Nombre_Gestion2 as 'Gestion 2' from USUARIOS,GESTIONES,GESTIONES2 WHERE USUARIOS .Id_Gestion = GESTIONES .Id_Gestion and USUARIOS .Id_Gestion2=GESTIONES2.Id_Gestion2 and  Id_Dominio= " & dom & " order by Nombre_Usuario"
        Dim dttable As New DataTable
        Dim bedit As Boolean
        Dim adaptadorsql = New SqlDataAdapter(consulta, New SqlConnection(coneccion))
        Dim sqlbuilder As New SqlCommandBuilder(adaptadorsql)
        adaptadorsql.Fill(dttable)
        bs.DataSource = dttable

        If Not bs.DataSource Is Nothing Then
            adaptadorsql.Update(bs.DataSource) 'CType(bs.DataSource, DataTable))

        End If

        With DataGridView1
            .Refresh()
        End With
        bedit = False

    End Sub

    Private Sub Form19_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        DataGridView1.Show()
        DataGridView1.DataSource = bs
        cargar_registros(coneccion, DataGridView1)

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        DataGridView1.Show()
        DataGridView1.DataSource = bs
        cargar_registros(coneccion, DataGridView1)

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        limpiar(Me)
        DataGridView1.Hide()
    End Sub
End Class