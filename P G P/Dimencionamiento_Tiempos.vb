Imports System.Data.SqlClient

Public Class Dimencionamiento_Tiempos

    Private Sub Dimencionamiento_Tiempos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Dim dt1, dt2 As New DataTable
        Dim c1, c2 As String
        Dim dato1 As String = ""
        Dim nameusu As String = ComboBox1.Text
        Dim FECHA As String = DateTimePicker1.Text

        c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nameusu & "'"
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt1)
        Dim i As Integer

        For i = 0 To dt1.Rows.Count - 1
            dato1 = dt1.Rows(i).Item("Usuario")
        Next

        c2 = "SELECT TIEMPO FROM DIMENCIONAMIENTO_TIEMPOS where USUARIO='" & dato1 & "' AND fecha >'01/07/2014'"
        Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
        adaptadorsql2.Fill(dt2)

        If adaptadorsql2.Fill(dt2) <> 0 Then
            TextBox2.DataBindings.Add(New Binding("Text", dt2, "TIEMPO"))
        Else
            MsgBox("El usuario no reporto tiempo esta fecha")
            ComboBox1.Text = ""
            TextBox2.Text = ""
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim dt1, dt2, dt3, dtt4 As New DataTable
            Dim c1, c3 As String
            Dim dato1 As String = ""
            Dim nameusu As String = ComboBox1.Text
            Dim fecha As String = DateTimePicker1.Text
            Dim tiempo_real As Double = TextBox2.Text

            c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nameusu & "'"
            Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
            adaptadorsql1.Fill(dt1)
            Dim i As Integer

            For i = 0 To dt1.Rows.Count - 1
                dato1 = dt1.Rows(i).Item("Usuario")
            Next

            c3 = "UPDATE DIMENCIONAMIENTO_TIEMPOS SET TIEMPO= " & tiempo_real & "  WHERE USUARIO='" & dato1 & "' AND FECHA='" & fecha & "'"
            Dim adaptadorsql3 As New SqlDataAdapter(c3, New SqlConnection(coneccion))
            adaptadorsql3.Fill(dt3)
            MsgBox("Tiempo Actualizado")
            ComboBox1.Text = ""
            TextBox2.Text = ""
        Finally
        End Try
    End Sub

End Class