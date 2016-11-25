Imports System.Data.SqlClient

Public Class Escalamientos_anterior

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Escalamientos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label25.Text = nombreusuario
        TextBox1.Text = Cuenta_escalamiento
        Dim consulta1 As String = ""
        Dim dttable1 As New DataTable
        Dim dom As Integer = 2


        consulta1 = "select Nombre_Usuario from USUARIOS where Id_Dominio =" & dom & " order by Nombre_Usuario"
        Dim adaptadorsql1 As New SqlDataAdapter(consulta1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dttable1)

        Dim i As Integer

        For i = 0 To dttable1.Rows.Count - 1
            ComboBox3.Items.Add(dttable1.Rows(i).Item("Nombre_Usuario"))
        Next

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim consulta1, c1, c3 As String
        Dim dttable1, dt10, dt3 As New DataTable
        Dim dato1 As String = ""
        Dim dato2 As String = ""
        Dim Cuenta As Double = TextBox1.Text
        Dim nameusu As String = ComboBox3.Text
        Dim area As String = ComboBox1.Text
        Dim motivo As String = ComboBox2.Text
        Dim estado As String = "Pendiente"

        c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql2 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql2.Fill(dt10)
        Dim i As Integer

        For i = 0 To dt10.Rows.Count - 1
            dato1 = dt10.Rows(i).Item("Usuario")
        Next

        c3 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nameusu & "'"
        Dim adaptadorsql3 As New SqlDataAdapter(c3, New SqlConnection(coneccion))
        adaptadorsql3.Fill(dt3)
        Dim j As Integer

        For j = 0 To dt3.Rows.Count - 1
            dato2 = dt3.Rows(j).Item("Usuario")
        Next

        consulta1 = "INSERT INTO ESCALAMIENTOS (Fecha_Escalamiento,Usuario_Escala,Cuenta,Area,Motivo,Usuario,Estado)values(getdate(),'" & dato1 & "'," & Cuenta & ",'" & area & "','" & motivo & "','" & dato2 & "','" & estado & "')"
        Dim adaptadorsql1 As New SqlDataAdapter(consulta1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dttable1)
        MsgBox("El caso fue escalado al usuario " & dato2 & "")
        Me.Close()
        Cuenta_escalamiento = 0
    End Sub
End Class