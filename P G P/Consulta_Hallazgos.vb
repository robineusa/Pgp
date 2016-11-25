Imports System.Data.SqlClient

Public Class Consulta_Hallazgos
    Dim bs As New BindingSource

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        DataGridView1.Show()
        DataGridView1.DataSource = bs
        cargar_registros(coneccion, DataGridView1)
    End Sub
    Private Sub cargar_registros(ByVal sql As String, ByVal dv As DataGridView)
        Dim fechaini As String = TextBox1.Text
        Dim fechafin As String = TextBox2.Text
        Dim c1 As String = ""
        Dim dt10 As New DataTable
        Dim usuario As String = ""

        c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt10)
        Dim i As Integer

        For i = 0 To dt10.Rows.Count - 1
            usuario = dt10.Rows(i).Item("Usuario")
        Next


        Dim consulta As String = "SELECT Usuario , Cuenta,Tipo_Error,Motivo_Error, CONVERT(VARCHAR(10),Fecha, 103)as 'Fecha de Gestion',SUBSTRING (convert(char(38),Hora, 121),12,8)as 'Hora de Gestion',Cantidad_Servicios,Estado  from HALLAZGOS where (((HALLAZGOS.Fecha) Between '" & fechaini & "' And '" & fechafin & "')) and Usuario like '" & usuario & "'"
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
End Class