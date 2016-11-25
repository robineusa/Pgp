Imports System.Data.SqlClient

Public Class Validación_hallazgos

    Private Sub Validación_hallazgos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim consulta1 As String
        Dim dttable1 As New DataTable
        Dim dom As Integer = 2

        consulta1 = "select Nombre_Usuario from USUARIOS where Id_Dominio =" & dom & " order by Nombre_Usuario"
        Dim adaptadorsql1 As New SqlDataAdapter(consulta1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dttable1)

        Dim i As Integer

        For i = 0 To dttable1.Rows.Count - 1
            ComboBox4.Items.Add(dttable1.Rows(i).Item("Nombre_Usuario"))

        Next
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        TextBox1.DataBindings.Clear()
        ComboBox1.DataBindings.Clear()
        ComboBox2.DataBindings.Clear()
        ComboBox3.DataBindings.Clear()
        ComboBox5.DataBindings.Clear()

        TextBox1.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox5.Text = ""


        Dim dt1, dt2 As New DataTable
        Dim c1, c2 As String
        Dim dato1 As String = ""
        Dim nameusu As String = ComboBox4.Text
        Dim estado As String = " Pendiente"

        c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nameusu & "'"
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt1)
        Dim i As Integer

        For i = 0 To dt1.Rows.Count - 1
            dato1 = dt1.Rows(i).Item("Usuario")
        Next

        c2 = "Select * From HALLAZGOS WHERE Usuario='" & dato1 & "' and Estado='" & estado & "'"
        Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
        adaptadorsql2.Fill(dt2)

        If adaptadorsql2.Fill(dt2) <> 0 Then

            TextBox1.DataBindings.Add(New Binding("Text", dt2, "Cuenta"))
            ComboBox1.DataBindings.Add(New Binding("Text", dt2, "Tipo_Error"))
            ComboBox2.DataBindings.Add(New Binding("Text", dt2, "Motivo_Error"))
            ComboBox3.DataBindings.Add(New Binding("Text", dt2, "Cantidad_Servicios"))
            ComboBox5.DataBindings.Add(New Binding("Text", dt2, "Estado"))
        Else
            MsgBox("el usuario no tiene mas hallazgos en estado pendiente")
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt1, dt2, dt3 As New DataTable
        Dim c1, c2, c3 As String
        Dim dato1 As String = ""
        Dim nameusu As String = ComboBox4.Text
        Dim estado As String = " Pendiente"

        c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nameusu & "'"
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt1)
        Dim i As Integer

        For i = 0 To dt1.Rows.Count - 1
            dato1 = dt1.Rows(i).Item("Usuario")
        Next
        Dim Cuenta As Integer = TextBox1.Text
        Dim estado2 As String = ComboBox5.Text

        c3 = "UPDATE HALLAZGOS SET Estado='" & estado2 & "' where Cuenta=" & Cuenta & " and Usuario='" & dato1 & "'"
        Dim adaptadorsql3 As New SqlDataAdapter(c3, New SqlConnection(coneccion))
        adaptadorsql3.Fill(dt3)
        MsgBox("registro actualizado")

        TextBox1.DataBindings.Clear()
        TextBox1.Text = ""
        ComboBox1.DataBindings.Clear()
        ComboBox2.DataBindings.Clear()
        ComboBox3.DataBindings.Clear()
        ComboBox5.DataBindings.Clear()

        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox5.Text = ""

        '*******************************************************************************

        c2 = "Select * From HALLAZGOS WHERE Usuario='" & dato1 & "' and Estado='" & estado & "'"
        Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
        adaptadorsql2.Fill(dt2)

        If adaptadorsql2.Fill(dt2) <> 0 Then

            TextBox1.DataBindings.Add(New Binding("Text", dt2, "Cuenta"))
            ComboBox1.DataBindings.Add(New Binding("Text", dt2, "Tipo_Error"))
            ComboBox2.DataBindings.Add(New Binding("Text", dt2, "Motivo_Error"))
            ComboBox3.DataBindings.Add(New Binding("Text", dt2, "Cantidad_Servicios"))
            ComboBox5.DataBindings.Add(New Binding("Text", dt2, "Estado"))
        Else
            MsgBox("el usuario no tiene mas hallazgos en estado pendiente")
        End If
    End Sub
End Class