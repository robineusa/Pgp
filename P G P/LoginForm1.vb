Imports System.Data.SqlClient
Imports System
Imports System.Data

Imports SkinSoft.OSSkin
Public Class LoginForm1
    Public Shared cont As Integer = 0
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Try
            Dim consulta As String
            Dim Usuario As String
            Dim Clave As String

            Dim dttable, dt1 As New DataTable
            Usuario = UsernameTextBox.Text
            Clave = PasswordTextBox.Text

            consulta = "SELECT Nombre_Usuario,Usuario,Clave From USUARIOS Where Usuario='" & Usuario & "' and Clave='" & Clave & "'"
            Dim adaptadorSQL As New SqlDataAdapter(consulta, New SqlConnection(coneccion))
            adaptadorSQL.Fill(dttable)


            If cont < 3 Then
                If dttable.Rows.Count <> 0 Then
                    Label2.DataBindings.Add(New Binding("Text", dttable, "Nombre_Usuario"))
                    nombreusuario = Label2.Text
                    MsgBox(nombreusuario, MsgBoxStyle.Information, "!Bienvenido(a)!")
                    Logueo.Show()
                    Me.Hide()

                Else
                    MsgBox("El usuario la contraseña o el dominio son incorrectos")
                    cont = cont + 1
                End If
            Else
                MsgBox("Excedió el maximo de intentos permitidos")
                Me.Close()
            End If
        Catch ex As Exception When UsernameTextBox.Text = ""
            MsgBox("Debe Escribir el usuario" & ex.Message & vbCrLf & "Asegurese de ingresar un Usuario", MsgBoxStyle.Critical, "CUIDADO")
        Catch ex As Exception When PasswordTextBox.Text = ""
            MsgBox("Debe Escribir la contraseña" & ex.Message & vbCrLf & "Asegurese de ingresar se Contraseña", MsgBoxStyle.Critical, "CUIDADO")

        End Try
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    
End Class
