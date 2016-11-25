Imports System.Data.SqlClient

Public Class Cambio_De_Clave

    Private Sub Form12_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim consulta20 As String
        Dim dt1 As New DataTable
        Dim dom As String = Label1.Text



        consulta20 = "Select Id_Usuario, Nombre_Usuario,Usuario ,Clave  from USUARIOS WHERE Nombre_Usuario like '" & nombreusuario & "'"

        Dim adaptadorsql1 As New SqlDataAdapter(consulta20, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt1)
        TextBox1.DataBindings.Add(New Binding("Text", dt1, "Id_Usuario"))
        TextBox2.DataBindings.Add(New Binding("Text", dt1, "Nombre_Usuario"))
        TextBox3.DataBindings.Add(New Binding("Text", dt1, "Usuario"))
        TextBox4.DataBindings.Add(New Binding("Text", dt1, "Clave"))
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Dim consulta2 As String
        Dim id As Integer = TextBox1.Text
        Dim dt10 As New DataTable
        Dim nombre As String = TextBox2.Text
        Dim usu As String = TextBox3.Text
        Dim clave As String = TextBox5.Text
        consulta2 = "UPDATE USUARIOS SET  Nombre_Usuario='" & nombre & "', Usuario='" & usu & "', Clave='" & clave & "' where Id_Usuario like " & id & ""

        Dim adaptadorsql1 As New SqlDataAdapter(consulta2, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt10)

        MsgBox("Clave Modificada Con Exito")

        PictureBox2.Hide()
        limpiar(Me)

    End Sub
End Class