Imports System.Data.SqlClient

Public Class Aprobacion_Novedades

    Private Sub Aprobacion_Novedades_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Dim dt1, dt2 As New DataTable
        Dim c1, c2 As String
        Dim dato1 As String = ""
        Dim nameusu As String = ComboBox1.Text
        Dim estado As String = "Pendiente"

        c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nameusu & "'"
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt1)
        Dim i As Integer

        For i = 0 To dt1.Rows.Count - 1
            dato1 = dt1.Rows(i).Item("Usuario")
        Next

        c2 = "SELECT * FROM NOVEDADES WHERE USUARIO='" & dato1 & "' AND ESTADO='" & estado & "'"
        Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
        adaptadorsql2.Fill(dt2)

        If adaptadorsql2.Fill(dt2) <> 0 Then
            TextBox1.DataBindings.Add(New Binding("Text", dt2, "DESCRIPCION"))
            DateTimePicker1.DataBindings.Add(New Binding("Text", dt2, "FECHA_NOVEDAD"))
            TextBox2.DataBindings.Add(New Binding("Text", dt2, "TIEMPO_TOTAL"))
            ComboBox2.DataBindings.Add(New Binding("Text", dt2, "ESTADO"))
            TextBox3.DataBindings.Add(New Binding("Text", dt2, "ID_NOVEDAD"))
        Else
            MsgBox("El usuario no tiene mas novedades en estado pendiente")
        End If

    End Sub

    Public Sub consultar()
        ComboBox1.DataBindings.Clear()
        ComboBox2.DataBindings.Clear()
        DateTimePicker1.DataBindings.Clear()
        TextBox1.DataBindings.Clear()
        TextBox2.DataBindings.Clear()
        TextBox3.DataBindings.Clear()

        Dim dt1, dt2 As New DataTable
        Dim c1, c2 As String
        Dim dato1 As String = ""
        Dim nameusu As String = ComboBox1.Text
        Dim estado As String = "Pendiente"

        c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nameusu & "'"
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt1)
        Dim i As Integer

        For i = 0 To dt1.Rows.Count - 1
            dato1 = dt1.Rows(i).Item("Usuario")
        Next

        c2 = "SELECT * FROM NOVEDADES WHERE USUARIO='" & dato1 & "' AND ESTADO='" & estado & "'"
        Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
        adaptadorsql2.Fill(dt2)

        If adaptadorsql2.Fill(dt2) <> 0 Then
            TextBox1.DataBindings.Add(New Binding("Text", dt2, "DESCRIPCION"))
            DateTimePicker1.DataBindings.Add(New Binding("Text", dt2, "FECHA_NOVEDAD"))
            TextBox2.DataBindings.Add(New Binding("Text", dt2, "TIEMPO_TOTAL"))
            ComboBox2.DataBindings.Add(New Binding("Text", dt2, "ESTADO"))
            TextBox3.DataBindings.Add(New Binding("Text", dt2, "ID_NOVEDAD"))
        Else
            MsgBox("El usuario no tiene mas novedades en estado pendiente")
            ComboBox1.Text = ""
            ComboBox2.Text = ""
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim dt1, dt2, dt3, dtt4, dt5 As New DataTable
            Dim c1, c2, c3, cc4, c5 As String
            Dim dato1 As String = ""
            Dim nameusu As String = ComboBox1.Text
            Dim estado As String = ComboBox2.Text
            Dim ID As Integer = TextBox3.Text
            Dim fecha As String = DateTimePicker1.Text
            Dim tiempo As Decimal = TextBox2.Text
            Dim tiempo_actual As Decimal = 0
            Dim tiempo_real As Decimal = 0

            c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nameusu & "'"
            Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
            adaptadorsql1.Fill(dt1)
            Dim i As Integer

            For i = 0 To dt1.Rows.Count - 1
                dato1 = dt1.Rows(i).Item("Usuario")
            Next
            If ComboBox2.Text = "Aprobada" Then

                c2 = "UPDATE NOVEDADES SET ESTADO='" & estado & "' WHERE ID_NOVEDAD=" & ID & ""
                Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
                adaptadorsql2.Fill(dt2)

                cc4 = "Select TIEMPO from DIMENCIONAMIENTO_TIEMPOS where USUARIO like '" & dato1 & "'"
                Dim adaptadorsql4 As New SqlDataAdapter(cc4, New SqlConnection(coneccion))
                adaptadorsql4.Fill(dtt4)
                Dim j As Integer

                For j = 0 To dtt4.Rows.Count - 1
                    tiempo_actual = dtt4.Rows(j).Item("TIEMPO")
                Next

                tiempo_real = tiempo_actual - tiempo

                c3 = "UPDATE DIMENCIONAMIENTO_TIEMPOS SET TIEMPO= " & tiempo_real & "  WHERE USUARIO='" & dato1 & "' AND FECHA='" & fecha & "'"
                Dim adaptadorsql3 As New SqlDataAdapter(c3, New SqlConnection(coneccion))
                adaptadorsql3.Fill(dt3)
                MsgBox("Novedad Actualizada")
            Else
                c5 = "UPDATE NOVEDADES SET ESTADO='" & estado & "' WHERE ID_NOVEDAD=" & ID & ""
                Dim adaptadorsql5 As New SqlDataAdapter(c5, New SqlConnection(coneccion))
                adaptadorsql5.Fill(dt5)
                Exit Sub
                ComboBox1.Text = ""
                TextBox2.Text = ""
            End If

            ComboBox1.DataBindings.Clear()
            DateTimePicker1.DataBindings.Clear()
            TextBox1.DataBindings.Clear()
            TextBox2.DataBindings.Clear()
            TextBox3.DataBindings.Clear()
            consultar()
            ComboBox1.Text = ""
            TextBox2.Text = ""
        Finally
        End Try
    End Sub
End Class