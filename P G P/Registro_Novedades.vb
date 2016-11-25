Imports System.Data.SqlClient

Public Class Registro_Novedades

    Private Sub Registro_Novedades_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label25.Text = nombreusuario

        DateTimePicker1.MaxDate = DateTime.Today
        DateTimePicker1.Format = DateTimePickerFormat.Short
        DateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim c1, c2 As String
        Dim dt1, dt2 As New DataTable
        Dim usuario As String = ""
        Dim DESCRIPCION As String = ComboBox1.Text
        Dim FECHA_NOVEDAD As String = DateTimePicker1.Text
        Dim AÑO As Integer = DateTimePicker1.Value.Year
        Dim MES As Integer = DateTimePicker1.Value.Month
        Dim DIA As Integer = DateTimePicker1.Value.Day
        Dim TIEMPO As Decimal = TextBox1.Text
        Dim ESTADO As String = "Pendiente"

        c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql.Fill(dt1)
        Dim i As Integer

        For i = 0 To dt1.Rows.Count - 1
            usuario = dt1.Rows(i).Item("Usuario")
        Next


        c2 = "INSERT INTO NOVEDADES(DESCRIPCION,FECHA_NOVEDAD,AÑO_NOVEDAD,MES_NOVEDAD,DIA_NOVEDAD,TIEMPO_TOTAL,ESTADO,USUARIO)VALUES('" & DESCRIPCION & "','" & FECHA_NOVEDAD & "'," & AÑO & "," & MES & "," & DIA & "," & TIEMPO & ",'" & ESTADO & "','" & usuario & "')"
        Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
        adaptadorsql2.Fill(dt2)
        MsgBox("Novedad Ingresada")

        Me.ComboBox1.SelectedIndex = -1
        TextBox1.Text = ""
        DateTimePicker1.Value = Today

    End Sub
End Class