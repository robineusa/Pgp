Imports System.Data.SqlClient

Public Class Escalamientos_Consultar

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Cuenta_escalamiento = TextBox1.Text
        Escalamientos_anterior.Show()
    End Sub

    Private Sub Escalamientos_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label25.Text = nombreusuario

        DateTimePicker1.MinDate = New DateTime(1985, 6, 12)
        DateTimePicker1.MaxDate = DateTime.Today
        DateTimePicker1.Format = DateTimePickerFormat.Short
        DateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd"

        Dim dt1, dt2 As New DataTable
        Dim c1, c2 As String
        Dim estado As String = "Pendiente"
        Dim usuario As String = ""


        c2 = "select Usuario from  USUARIOS where Nombre_Usuario like'" & nombreusuario & "'"
        Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
        adaptadorsql2.Fill(dt2)
        Dim i As Integer

        For i = 0 To dt2.Rows.Count - 1
            usuario = dt2.Rows(i).Item("Usuario")
        Next

        c1 = "select CONVERT(VARCHAR(10),Fecha_Escalamiento , 103)as Fecha,Usuario_Escala,Cuenta,Area,Motivo,Estado from ESCALAMIENTOS where Usuario like'" & usuario & "' and Estado like'" & estado & "'"
        Dim adaptadorsql As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql.Fill(dt1)
        If adaptadorsql.Fill(dt1) = 0 Then
            MsgBox("Usted no tiene casos escalados")
        Else
            TextBox1.DataBindings.Add(New Binding("Text", dt1, "Cuenta"))
            DateTimePicker1.DataBindings.Add(New Binding("Text", dt1, "Fecha"))
            TextBox2.DataBindings.Add(New Binding("Text", dt1, "Usuario_Escala"))
            TextBox3.DataBindings.Add(New Binding("Text", dt1, "Area"))
            TextBox4.DataBindings.Add(New Binding("Text", dt1, "Motivo"))
            ComboBox1.DataBindings.Add(New Binding("Text", dt1, "Estado"))

        End If


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dttable, dt2, dt1 As New DataTable
        Dim consulta, c2, c1 As String
        Dim estado As String = ComboBox1.Text
        Dim Cuenta As Integer = TextBox1.Text
        Dim Usuario As String = ""

        c2 = "select Usuario from  USUARIOS where Nombre_Usuario like'" & nombreusuario & "'"
        Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
        adaptadorsql2.Fill(dt2)
        Dim i As Integer

        For i = 0 To dt2.Rows.Count - 1
            Usuario = dt2.Rows(i).Item("Usuario")
        Next

        consulta = "UPDATE ESCALAMIENTOS SET Estado='" & estado & "' where Usuario='" & Usuario & "' and Cuenta=" & Cuenta & ""
        Dim adaptadorsql10 As New SqlDataAdapter(consulta, New SqlConnection(coneccion))
        adaptadorsql10.Fill(dttable)
        MsgBox("Registro actualizado")
        '***************************************************************************
        TextBox1.DataBindings.Clear()
        TextBox2.DataBindings.Clear()
        TextBox3.DataBindings.Clear()
        TextBox4.DataBindings.Clear()
        ComboBox1.DataBindings.Clear()
        DateTimePicker1.DataBindings.Clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox1.Text = ""
        DateTimePicker1.Value = Today

        Dim estado1 As String = "Pendiente"
        c1 = "select CONVERT(VARCHAR(10),Fecha_Escalamiento , 103)as Fecha,Usuario_Escala,Cuenta,Area,Motivo,Estado from ESCALAMIENTOS where Usuario like'" & Usuario & "' and Estado like'" & estado & "'"
        Dim adaptadorsql As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql.Fill(dt1)
        If adaptadorsql.Fill(dt1) = 0 Then
            MsgBox("Usted no tiene casos escalados")

            TextBox1.DataBindings.Clear()
            TextBox2.DataBindings.Clear()
            TextBox3.DataBindings.Clear()
            TextBox4.DataBindings.Clear()
            ComboBox1.DataBindings.Clear()
            DateTimePicker1.DataBindings.Clear()
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            ComboBox1.Text = ""
            DateTimePicker1.Value = Today
        Else
            TextBox1.DataBindings.Add(New Binding("Text", dt1, "Cuenta"))
            DateTimePicker1.DataBindings.Add(New Binding("Text", dt1, "Fecha"))
            TextBox2.DataBindings.Add(New Binding("Text", dt1, "Usuario_Escala"))
            TextBox3.DataBindings.Add(New Binding("Text", dt1, "Area"))
            TextBox4.DataBindings.Add(New Binding("Text", dt1, "Motivo"))
            ComboBox1.DataBindings.Add(New Binding("Text", dt1, "Estado"))
        End If
    End Sub
End Class