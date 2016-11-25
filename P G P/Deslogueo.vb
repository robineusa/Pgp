Imports System.Data.SqlClient
Imports System
Imports System.Data

Imports SkinSoft.OSSkin
Public Class Deslogueo
    Private Sub Form17_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DateTimePicker1.MaxDate = DateTime.Today
        DateTimePicker1.Format = DateTimePickerFormat.Short
        DateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd"

        Dim dt, dt12 As New DataTable
        Dim c1 As String
        Dim idusu As String = ""


        c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql12 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql12.Fill(dt12)

        Dim i As Integer

        For i = 0 To dt12.Rows.Count - 1
            idusu = dt12.Rows(i).Item("Usuario")
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt1, dt2 As New DataTable
        Dim c1, c2 As String
        Dim idusu As String = ""
        Dim fecha As String = DateTimePicker1.Value
        DateTimePicker1.Value = Today

        c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt1)

        Dim i As Integer

        For i = 0 To dt1.Rows.Count - 1
            idusu = dt1.Rows(i).Item("Usuario")
        Next


        If (MsgBox("Desea Registrar el Deslogueo?", MsgBoxStyle.YesNo, "Deslogueo de Turno")) = MsgBoxResult.Yes Then
            c2 = "UPDATE ADHERENCIA SET HORA_FIN= GETDATE() where Usuario like '" & idusu & "' and CONVERT(VARCHAR(10),FECHA, 103)like'" & fecha & "'"

            Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
            adaptadorsql2.Fill(dt2)
            Me.Close()
        Else
            c2 = ""
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class