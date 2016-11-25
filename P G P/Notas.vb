Imports System.Data.SqlClient

Public Class Notas

    Private Sub Notas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label33.Text = nombreusuario
        Dim c1, c2 As String
        Dim dt1, dt2 As New DataTable
        Dim dato1 As String = ""

        c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt1)
        Dim i As Integer

        For i = 0 To dt1.Rows.Count - 1
            dato1 = dt1.Rows(i).Item("Usuario")
        Next

        c2 = "Select Id_Nota,Nota from NOTAS where Usuario like'" & dato1 & "'"
        Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
        adaptadorsql2.Fill(dt2)
        DataGridView1.DataSource = dt2
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim c1, c2 As String
        Dim dt1, dt2 As New DataTable
        Dim dato1 As String = ""
        Dim NOTA As String = RichTextBox2.Text
        c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt1)

        Dim i As Integer

        For i = 0 To dt1.Rows.Count - 1
            dato1 = dt1.Rows(i).Item("Usuario")
        Next

        c2 = "insert into NOTAS (Usuario ,Nota )values('" & dato1 & "','" & NOTA & "')"
        Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
        adaptadorsql2.Fill(dt2)
        MsgBox("La nota fue registrada")
        Refrescar()
    End Sub
    Public Sub Refrescar()
        DataGridView1.DataBindings.Clear()
        DataGridView1.DataSource.clear()
        Dim c1, c2 As String
        Dim dt1, dt2 As New DataTable
        Dim dato1 As String = ""

        c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt1)
        Dim i As Integer

        For i = 0 To dt1.Rows.Count - 1
            dato1 = dt1.Rows(i).Item("Usuario")
        Next

        c2 = "Select Id_Nota,Nota from NOTAS where Usuario like '" & dato1 & "'"
        Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
        adaptadorsql2.Fill(dt2)
        DataGridView1.DataSource = dt2
    End Sub
End Class