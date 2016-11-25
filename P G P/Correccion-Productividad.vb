Imports System.Data.SqlClient

Public Class Correccion_Productividad
    Dim dato1 As String = ""
    Private Sub Correccion_Productividad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        TextBox2.DataBindings.Clear()
        Dim dt1, dt2, dt3 As New DataTable
        Dim c1, c2 As String

        Dim nameusu As String = ComboBox1.Text
        Dim FECHA As String = DateTimePicker1.Text

        c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nameusu & "'"
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt1)
        Dim i As Integer

        For i = 0 To dt1.Rows.Count - 1
            dato1 = dt1.Rows(i).Item("Usuario")
        Next
        c2 = "SELECT TIEMPO FROM DIMENCIONAMIENTO_TIEMPOS WHERE USUARIO='" & dato1 & "' AND FECHA='" & FECHA & "'"
        Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
        adaptadorsql2.Fill(dt2)
        If adaptadorsql2.Fill(dt2) <> 0 Then
            TextBox2.DataBindings.Add(New Binding("Text", dt2, "TIEMPO"))
            TextBox2.BackColor = Color.Red
            TextBox3.Text = 1
        Else
            MsgBox("El usuario tiene una novedad total")
            TextBox2.DataBindings.Add(New Binding("Text", dt2, "TIEMPO"))
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim c3 As String
        Dim dt3 As New DataTable
        Dim años As Integer = DateTimePicker1.Value.Year
        Dim mess As Integer = DateTimePicker1.Value.Month
        Dim diass As Integer = DateTimePicker1.Value.Day

        Dim producto As Double = TextBox3.Text
        c3 = "INSERT INTO PRODUCTIVIDAD_DIARIA (USUARIO, FECHA, PRODUCTIVIDAD, AÑO, MES, DIA ) VALUES('" & dato1 & "',getdate()," & producto & "," & años & "," & mess & "," & diass & ")"
        Dim adaptadorsql3 As New SqlDataAdapter(c3, New SqlConnection(coneccion))
        adaptadorsql3.Fill(dt3)
        MsgBox("Productividad corregida")
        TextBox3.Text = ""
        TextBox2.Text = ""
        TextBox2.DataBindings.Clear()
        TextBox3.DataBindings.Clear()
        TextBox2.BackColor = Color.White
    End Sub
End Class