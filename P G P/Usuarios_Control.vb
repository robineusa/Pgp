Imports System.Data.SqlClient

Public Class Usuarios_Control

    Private Sub Form13_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim consulta1, consulta2, consulta3, consulta4 As String
        Dim dttable1, dttable2, dttable3, dttable4 As New DataTable
        Dim dom As Integer = 3

        consulta1 = "select Nombre_Usuario from USUARIOS where Id_Dominio =" & dom & " order by Nombre_Usuario"
        Dim adaptadorsql1 As New SqlDataAdapter(consulta1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dttable1)

        consulta2 = "select Nombre_Dominio from DOMINIOS"
        Dim adaptadorsql2 As New SqlDataAdapter(consulta2, New SqlConnection(coneccion))
        adaptadorsql2.Fill(dttable2)

        consulta3 = "select Nombre_Gestion from GESTIONES"
        Dim adaptadorsql3 As New SqlDataAdapter(consulta3, New SqlConnection(coneccion))
        adaptadorsql3.Fill(dttable3)

        consulta4 = "select Nombre_Gestion2 from GESTIONES2"
        Dim adaptadorsql4 As New SqlDataAdapter(consulta4, New SqlConnection(coneccion))
        adaptadorsql4.Fill(dttable4)

        Dim i As Integer

        For i = 0 To dttable1.Rows.Count - 1
            ComboBox1.Items.Add(dttable1.Rows(i).Item("Nombre_Usuario"))

        Next
        Dim J As Integer

        For J = 0 To dttable2.Rows.Count - 1
            ComboBox2.Items.Add(dttable2.Rows(J).Item("Nombre_Dominio"))
        Next
        Dim k As Integer

        For k = 0 To dttable3.Rows.Count - 1
            ComboBox3.Items.Add(dttable3.Rows(k).Item("Nombre_Gestion"))

        Next

        Dim l As Integer

        For l = 0 To dttable4.Rows.Count - 1
            ComboBox4.Items.Add(dttable4.Rows(l).Item("Nombre_Gestion2"))

        Next

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        limpiar3(Me)
        TextBox1.DataBindings.Clear()
        TextBox1.Text = ""

        TextBox2.DataBindings.Clear()
        TextBox2.Text = ""

        TextBox3.DataBindings.Clear()
        TextBox3.Text = ""

        TextBox4.DataBindings.Clear()
        TextBox4.Text = ""

        ComboBox1.DataBindings.Clear()
        ComboBox2.DataBindings.Clear()
        ComboBox3.DataBindings.Clear()

        Dim dt1 As New DataTable
        Dim c1 As String
        Dim nombre As String = ComboBox1.Text

        c1 = "select Id_Usuario ,Nombre_Usuario ,Usuario ,Clave ,Nombre_Dominio,Nombre_Gestion,Nombre_Gestion2 from USUARIOS, DOMINIOS,GESTIONES,GESTIONES2 where USUARIOS .Id_Dominio =DOMINIOS .Id_Dominio and USUARIOS.Id_Gestion=GESTIONES.Id_Gestion and USUARIOS.Id_Gestion2=GESTIONES2.Id_Gestion2 and Nombre_Usuario ='" & nombre & "'"
        Dim adaptadorsql As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql.Fill(dt1)

        If adaptadorsql.Fill(dt1) > 0 Then
            TextBox1.DataBindings.Add(New Binding("Text", dt1, "Id_Usuario"))
            TextBox2.DataBindings.Add(New Binding("Text", dt1, "Nombre_Usuario"))
            TextBox3.DataBindings.Add(New Binding("Text", dt1, "Usuario"))
            TextBox4.DataBindings.Add(New Binding("Text", dt1, "Clave"))
            ComboBox2.DataBindings.Add(New Binding("Text", dt1, "Nombre_Dominio"))
            ComboBox3.DataBindings.Add(New Binding("Text", dt1, "Nombre_Gestion"))
            ComboBox4.DataBindings.Add(New Binding("Text", dt1, "Nombre_Gestion2"))
        Else
            MsgBox("No Existen Datos para la Consulta")
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Dim dt1 As New DataTable
        Dim c1 As String
        Dim id As Integer = TextBox1.Text


        If (MsgBox("Desea Eliminar el  Usuario?", MsgBoxStyle.YesNo, "Eliminación de Usuarios")) = MsgBoxResult.Yes Then
            c1 = "DELETE USUARIOS WHERE Id_Usuario= " & id & ""
            Dim adaptadorsql As New SqlDataAdapter(c1, New SqlConnection(coneccion))
            adaptadorsql.Fill(dt1)
            MsgBox("El Usuario fue Eliminado de la Base de Datos con Exito")
        Else
            c1 = ""
        End If

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Dim dt1, dt2, dt3, dt4 As New DataTable
        Dim c1, c2, c3, c4 As String
        Dim Id As Integer = TextBox1.Text
        Dim nombre As String = TextBox2.Text
        Dim usu As String = TextBox3.Text
        Dim clave As String = TextBox4.Text
        Dim iddom As String
        Dim dom As Integer
        Dim ges As String = ComboBox3.Text
        Dim ges2 As String = ComboBox4.Text
        iddom = ComboBox2.Text

        c1 = "select Id_Dominio from DOMINIOS WHERE Nombre_Dominio ='" & iddom & "'"
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt1)

        For i = 0 To dt1.Rows.Count - 1
            dom = dt1.Rows(i).Item("Id_Dominio")
        Next

        c3 = "select Id_Gestion from GESTIONES WHERE Nombre_Gestion ='" & ges & "'"
        Dim adaptadorsql3 As New SqlDataAdapter(c3, New SqlConnection(coneccion))
        adaptadorsql3.Fill(dt3)
        Dim idges As Integer
        For j = 0 To dt3.Rows.Count - 1
            idges = dt3.Rows(j).Item("Id_Gestion")
        Next

        c4 = "select Id_Gestion2 from GESTIONES2 WHERE Nombre_Gestion2 ='" & ges2 & "'"
        Dim adaptadorsql4 As New SqlDataAdapter(c4, New SqlConnection(coneccion))
        adaptadorsql4.Fill(dt4)
        Dim idges2 As Integer

        For l = 0 To dt4.Rows.Count - 1
            idges2 = dt4.Rows(l).Item("Id_Gestion2")
        Next


        If (MsgBox("Desea Actualizar la Informacion del Usuario?", MsgBoxStyle.YesNo, "Actualización de Usuarios")) = MsgBoxResult.Yes Then
            c2 = "UPDATE USUARIOS SET Nombre_Usuario='" & nombre & "', Usuario='" & usu & "', Clave='" & clave & "', Id_Dominio=" & dom & ",Id_Gestion=" & idges & ", Id_Gestion2=" & idges2 & " where Id_Usuario =" & Id & ""
            Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
            adaptadorsql2.Fill(dt2)
            MsgBox("Información del Usuario Actualizada")
        Else
            c2 = ""
        End If

    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        Dim dt1, dt2, dt3, dt4 As New DataTable
        Dim c1, c2, c3, c4 As String
        Dim Id As Integer = TextBox1.Text
        Dim nombre As String = TextBox2.Text
        Dim usu As String = TextBox3.Text
        Dim clave As String = TextBox4.Text
        Dim iddom As String
        Dim dom As Integer
        Dim idges As Integer
        Dim ges As String = ComboBox3.Text
        Dim ges2 As String = ComboBox4.Text
        iddom = ComboBox2.Text
        c1 = "select Id_Dominio from DOMINIOS WHERE Nombre_Dominio ='" & iddom & "'"
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt1)

        For i = 0 To dt1.Rows.Count - 1
            dom = dt1.Rows(i).Item("Id_Dominio")
        Next

        c3 = "select Id_Gestion from GESTIONES WHERE Nombre_Gestion ='" & ges & "'"
        Dim adaptadorsql3 As New SqlDataAdapter(c3, New SqlConnection(coneccion))
        adaptadorsql3.Fill(dt3)

        For j = 0 To dt3.Rows.Count - 1
            idges = dt3.Rows(j).Item("Id_Gestion")
        Next

        c4 = "select Id_Gestion2 from GESTIONES2 WHERE Nombre_Gestion2 ='" & ges2 & "'"
        Dim adaptadorsql4 As New SqlDataAdapter(c4, New SqlConnection(coneccion))
        adaptadorsql4.Fill(dt4)
        Dim idges2 As Integer

        For l = 0 To dt4.Rows.Count - 1
            idges2 = dt4.Rows(l).Item("Id_Gestion2")
        Next


        If (MsgBox("Desea Guardar el Nuevo Usuario?", MsgBoxStyle.YesNo, "Registro de Usuarios")) = MsgBoxResult.Yes Then
            c2 = "Insert Into USUARIOS(Id_Usuario,Nombre_Usuario,Usuario,Clave,Id_Dominio,Id_Gestion,Id_Gestion2)Values(" & Id & ", '" & nombre & "','" & usu & "','" & clave & "'," & dom & "," & idges & " ," & idges2 & ")"
            Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
            adaptadorsql2.Fill(dt2)
            MsgBox("Registro de Usuario Exitoso")
        Else
            c2 = ""
        End If
    End Sub

End Class