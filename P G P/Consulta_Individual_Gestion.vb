Imports System.Data.SqlClient

Public Class Consulta_Individual_Gestion
    Dim bs As New BindingSource

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DateTimePicker1.MaxDate = DateTime.Today
        DateTimePicker1.Format = DateTimePickerFormat.Short
        DateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd"

        Dim consulta1 As String
        Dim dttable1 As New DataTable
        Dim dom As Integer = 2
        consulta1 = "select Nombre_Usuario from USUARIOS where Id_Dominio=" & dom & " order by Nombre_Usuario"
        Dim adaptadorsql1 As New SqlDataAdapter(consulta1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dttable1)

        Dim i As Integer

        For i = 0 To dttable1.Rows.Count - 1
            ComboBox1.Items.Add(dttable1.Rows(i).Item("Nombre_Usuario"))
        Next
    End Sub
    Private Sub cargar_registros(ByVal sql As String, ByVal dv As DataGridView)
        Dim c2 As String
        Dim back As String = ComboBox1.Text
        Dim dt2 As New DataTable


        c2 = "select Usuario from USUARIOS  where Nombre_Usuario like '" & back & "'"
        Dim adaptadorsql5 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
        adaptadorsql5.Fill(dt2)
        Dim back1 As String = ""
        Dim fecha As String = DateTimePicker1.Value
        Dim i As Integer

        For i = 0 To dt2.Rows.Count - 1
            back1 = dt2.Rows(i).Item("Usuario")
        Next
        Dim consulta As String = "select Nombre_Gestion as 'Gestion' ,Fecha,SUBSTRING (convert(char(38),Hora_Gestion ,121),12,8)as 'Hora de Gestion', Cuenta , Proceso  from PRODUCTIVIDAD,GESTIONES   where PRODUCTIVIDAD .Id_Gestion =GESTIONES .Id_Gestion and  Usuario like '" & back1 & "' and CONVERT(VARCHAR(10),Fecha, 103) like '" & fecha & "'"
        Dim adaptadorsql As SqlDataAdapter
        Dim dttable As New DataTable



        Dim bedit As Boolean

        'se crea el adaptador para cargar los datos de la consulta
        adaptadorsql = New SqlDataAdapter(consulta, New SqlConnection(coneccion))
        'se crea el comando para construir la conexion
        Dim sqlbuilder As New SqlCommandBuilder(adaptadorsql)
        'Se llena el datatable
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

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        limpiar(Me)
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        DataGridView1.DataSource = bs
        DataGridView1.Show()
        cargar_registros(coneccion, DataGridView1)

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        limpiar(Me)
        DataGridView1.Hide()
    End Sub
End Class