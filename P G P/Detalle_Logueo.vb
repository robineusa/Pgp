Imports System.Data.SqlClient

Public Class Detalle_Logueo

    Private Sub Form21_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DateTimePicker1.MaxDate = DateTime.Today
        DateTimePicker1.Format = DateTimePickerFormat.Short
        DateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd"
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged

        TextBox1.DataBindings.Clear()
        TextBox1.Text = ""
        TextBox2.DataBindings.Clear()
        TextBox2.Text = ""
        TextBox3.DataBindings.Clear()
        TextBox3.Text = ""

        Dim consulta1, c2 As String
        Dim dttable1, dt2 As New DataTable
        Dim fecha As String = DateTimePicker1.Value
        Dim dato1 As String = ""

        c2 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
        adaptadorsql2.Fill(dt2)
        Dim i As Integer

        For i = 0 To dt2.Rows.Count - 1
            dato1 = dt2.Rows(i).Item("Usuario")
        Next

        consulta1 = "SELECT Hora_Inicio, Hora_Fin, SUBSTRING (convert(char(38),Hora_Fin - Hora_Inicio ,121),12,8)as Total   FROM ADHERENCIA where CONVERT(VARCHAR(10),Fecha, 103) like'" & fecha & "' and Usuario ='" & dato1 & "'"
        Dim adaptadorsql1 As New SqlDataAdapter(consulta1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dttable1)

        If adaptadorsql1.Fill(dttable1) = False Then
            MsgBox("No Existen Registros de Logueo")
        Else
            TextBox1.DataBindings.Add(New Binding("Text", dttable1, "Hora_Inicio"))
            TextBox2.DataBindings.Add(New Binding("Text", dttable1, "Hora_Fin"))
            TextBox3.DataBindings.Add(New Binding("Text", dttable1, "Total"))
        End If

    End Sub
End Class