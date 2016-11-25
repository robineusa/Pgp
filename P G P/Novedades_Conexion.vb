Imports System.Data.SqlClient

Public Class Novedades_Conexion

    Private Sub Novedades_Conexion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.MaxDate = DateTime.Today
        DateTimePicker1.Format = DateTimePickerFormat.Short
        DateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd"

        Dim consulta1 As String
        Dim dttable1 As New DataTable
        Dim dom As Integer = 2

        consulta1 = "select Nombre_Usuario from USUARIOS where Id_Dominio =" & dom & " order by Nombre_Usuario"
        Dim adaptadorsql1 As New SqlDataAdapter(consulta1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dttable1)

        Dim i As Integer

        For i = 0 To dttable1.Rows.Count - 1
            ComboBox1.Items.Add(dttable1.Rows(i).Item("Nombre_Usuario"))
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim dt1, dt2, dt3, dtt4 As New DataTable
            Dim c1, c3 As String
            Dim dato1 As String = ""
            Dim nameusu As String = ComboBox1.Text
            Dim fecha As String = DateTimePicker1.Text
          
            c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nameusu & "'"
            Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
            adaptadorsql1.Fill(dt1)
            Dim i As Integer

            For i = 0 To dt1.Rows.Count - 1
                dato1 = dt1.Rows(i).Item("Usuario")
            Next

            c3 = "INSERT INTO NOVEDAD_TURNOS (FECHA_NOVEDAD,USUARIO)VALUES('" & fecha & "','" & dato1 & "')"
            Dim adaptadorsql3 As New SqlDataAdapter(c3, New SqlConnection(coneccion))
            adaptadorsql3.Fill(dt3)
            MsgBox("Novedad Registrada")
            ComboBox1.Text = ""

        Finally
        End Try
    End Sub
End Class