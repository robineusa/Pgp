Imports System.Data.SqlClient

Public Class Logueo
    Private Sub Form16_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DateTimePicker1.MaxDate = DateTime.Today
        DateTimePicker1.Format = DateTimePickerFormat.Short
        DateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd"
        DateTimePicker1.Value = Today
        Dim dt1, dt2, dt3 As New DataTable
        Dim c1, c2 As String

        Dim idusu As String = ""
        Dim fecha As String = DateTimePicker1.Text


        c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt1)

        Dim i As Integer

        For i = 0 To dt1.Rows.Count - 1
            idusu = dt1.Rows(i).Item("Usuario")
        Next

        c2 = "Select * from ADHERENCIA where Usuario like '" & idusu & "' and CONVERT(VARCHAR(10),Fecha, 103) like '" & fecha & "'"
        Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
        adaptadorsql2.Fill(dt2)

        If adaptadorsql2.Fill(dt2) > 0 Then
            Me.Close()
            MDIParent1.Show()
        Else
            Button1.Enabled = True
        End If

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt1, dt2, dt3 As New DataTable
        Dim c1, c2 As String

        Dim USUARIO As String = ""
        Dim AÑO As Integer = Now.Year
        Dim MES As Integer = Now.Month
        Dim DIA As Integer = Now.Day
        Dim fecha As String = Today
        Dim tiempo As Decimal = 8.5

        c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt1)

        Dim i As Integer

        For i = 0 To dt1.Rows.Count - 1
            USUARIO = dt1.Rows(i).Item("Usuario")
        Next


        If (MsgBox("Desea Registrar su Logueo?", MsgBoxStyle.YesNo, "Registro de Logueo")) = MsgBoxResult.Yes Then
            c2 = "INSERT INTO ADHERENCIA (USUARIO,FECHA,AÑO,MES,DIA,HORA_INICIO,HORA_FIN)VALUES('" & USUARIO & "',GETDATE ()," & AÑO & "," & MES & "," & DIA & ",GETDATE(),GETDATE())"
            Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
            adaptadorsql2.Fill(dt2)

            tiempos()

            MDIParent1.Show()
            Me.Close()

        Else
            c2 = ""

        End If

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        MDIParent1.Show()
    End Sub

    Public Sub tiempos()

        Dim dt1, dt5 As New DataTable
        Dim c1, c5 As String

        Dim USUARIO As String = ""
        Dim AÑO As Integer = Now.Year
        Dim MES As Integer = Now.Month
        Dim DIA As Integer = Now.Day
        Dim fecha As String = Now
        Dim tiempo As String = "8.5"

        c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt1)

        Dim i As Integer

        For i = 0 To dt1.Rows.Count - 1
            USUARIO = dt1.Rows(i).Item("Usuario")
        Next

        c5 = "INSERT INTO DIMENCIONAMIENTO_TIEMPOS(USUARIO,FECHA,AÑO,MES,DIA,TIEMPO)VALUES('" & USUARIO & "',GETDATE()," & AÑO & "," & MES & "," & DIA & "," & tiempo & ")"
        Dim adaptadorsql5 As New SqlDataAdapter(c5, New SqlConnection(coneccion))
        adaptadorsql5.Fill(dt5)

    End Sub
End Class