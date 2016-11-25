Imports System.Data.SqlClient

Public Class Gestion_Vencidos
    Dim ID_MACROPROCESO = 9
    Private Sub Tickets_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label33.Text = nombreusuario

        Dim c1 As String
        Dim dt1 As New DataTable

        c1 = "SELECT NOMBRE_SUB_PROCESO FROM SUB_PROCESOS WHERE ID_MACROPROCESO =" & ID_MACROPROCESO & ""
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt1)

        Dim i As Integer

        For i = 0 To dt1.Rows.Count - 1
            ComboBox1.Items.Add(dt1.Rows(i).Item("NOMBRE_SUB_PROCESO"))
        Next


        DateTimePicker1.MinDate = New DateTime(1985, 6, 12)
        DateTimePicker1.MaxDate = DateTime.Today
        DateTimePicker1.Format = DateTimePickerFormat.Short
        DateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd"

        DateTimePicker2.MinDate = New DateTime(1985, 6, 12)
        DateTimePicker2.MaxDate = DateTime.Today
        DateTimePicker2.Format = DateTimePickerFormat.Short
        DateTimePicker2.CustomFormat = "MMMM dd, yyyy - dddd"

        DateTimePicker3.MinDate = New DateTime(1985, 6, 12)
        DateTimePicker3.MaxDate = DateTime.Today
        DateTimePicker3.Format = DateTimePickerFormat.Short
        DateTimePicker3.CustomFormat = "MMMM dd, yyyy - dddd"

        Dim consulta2 As String
        Dim dttable As New DataTable

        consulta2 = "SELECT * FROM ASIG_VENCIDOS"

        Dim adaptadorSQL As New SqlDataAdapter(consulta2, New SqlConnection(coneccion))
        adaptadorSQL.Fill(dttable)

        If adaptadorSQL.Fill(dttable) = False Then
            MsgBox("NO HAY REGISTROS DISPONIBLES")
        Else
            TextBox1.DataBindings.Add(New Binding("Text", dttable, "Cuenta"))
            TextBox2.DataBindings.Add(New Binding("Text", dttable, "Numero_Ticket"))
            Dim dttable1 As New DataTable
            Dim consulta3 As String
            Dim Dato As Integer

            Dato = TextBox2.Text
            consulta3 = "delete ASIG_VENCIDOS where Numero_Ticket = " & Dato & ""

            Dim adaptadorSQL2 As New SqlDataAdapter(consulta3, New SqlConnection(coneccion))
            adaptadorSQL2.Fill(dttable1)
            TextBox20.Text = 0
            TextBox19.Text = 0
            cargar_registros()
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim dttable4, dttable5, dttable25, dt50 As New DataTable
        Dim consulta4, consulta5, consulta25, ct50 As String

        Dim Cuenta As Double = TextBox1.Text
        Dim Numero_Ticket As Double = TextBox2.Text
        Dim Canal_ingreso As String = TextBox3.Text
        Dim Usuario_Creacion As String = TextBox4.Text
        Dim Fecha_Creacion As String = DateTimePicker3.Text
        Dim SRCAUS As String = TextBox6.Text
        Dim SRREAS As String = TextBox7.Text
        Dim Motivo_Dx As String = TextBox8.Text
        Dim Codigo As String = TextBox9.Text
        Dim Nota1 As String = TextBox10.Text
        Dim Nota2 As String = TextBox11.Text
        Dim Nota3 As String = TextBox12.Text
        Dim Nota4 As String = TextBox13.Text
        Dim Nota5 As String = TextBox14.Text
        Dim Fecha_escalamiento As String = DateTimePicker1.Text
        Dim Marca As String = ComboBox1.Text
        Dim Motivo_reclamacion As String = ComboBox2.Text
        Dim Usuario_Retencion As String = TextBox15.Text
        Dim Ofreci_reten As String = TextBox16.Text
        Dim Fecha_Sol_can As String = DateTimePicker2.Text
        Dim Marcacion As String = ComboBox5.Text
        Dim Usuario_cancelacion As String = TextBox17.Text
        Dim Moviletter As Double = TextBox19.Text
        Dim cant_servicios As Integer = TextBox20.Text
        Dim Ajuste As String = ComboBox6.Text
        Dim Estado_ticket As String = ComboBox7.Text
        Dim Usuario_escalado As String = TextBox21.Text
        Dim Observaciones As String = TextBox22.Text

        Dim dato1 As String = ""
        Dim dt10 As New DataTable
        Dim c1 As String


        c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt10)
        Dim i As Integer

        For i = 0 To dt10.Rows.Count - 1
            dato1 = dt10.Rows(i).Item("Usuario")
        Next

        If (MsgBox("Desea guardar registro?", MsgBoxStyle.YesNo, "Guardar")) = MsgBoxResult.Yes Then

            Dim id As Integer = 10
            Dim proceso As String = "Gestion Tickets"
            Dim proceso2 As String = "Casos Vencidos"
            Dim Id_Gestion As Integer = 8

            consulta4 = "UPDATE TICKETS SET Fecha_Escalamiento= '" & Fecha_escalamiento & "',Marca= '" & Marca & "' ,Motivo_Rec= '" & Motivo_reclamacion & "' ,Usu_Retencion= '" & Usuario_Retencion & "' ,Ofrec_Ret= '" & Ofreci_reten & "' ,Fecha_sol_can= '" & Fecha_Sol_can & "' ,Marcacion= '" & Marcacion & "' ,Usuaruio_Can= '" & Usuario_cancelacion & "' ,Movie_Letter = " & Moviletter & " ,Numero_Ser= " & cant_servicios & " ,Ajuste= '" & Ajuste & "' ,Estado_Ticket= '" & Estado_ticket & "' ,Usuario_Escala= '" & Usuario_escalado & "' ,Observaciones= '" & Observaciones & "' where Cuenta= " & Cuenta & " and Numero_Ticket= " & Numero_Ticket & ""
            Dim adaptadorSQL4 As New SqlDataAdapter(consulta4, New SqlConnection(coneccion))
            adaptadorSQL4.Fill(dttable4)

            consulta5 = "UPDATE CONSOLIDADO SET Gestion= '" & Marca & "',Sub_Razon='" & Motivo_reclamacion & "',Servicios_Dx= " & cant_servicios & " where Cuenta= " & Cuenta & " and Id_Gestion=" & Id_Gestion & ""
            Dim adaptadorSQL5 As New SqlDataAdapter(consulta5, New SqlConnection(coneccion))
            adaptadorSQL5.Fill(dttable5)

            Dim porcen As Decimal
            porcen = 1
            consulta25 = "INSERT INTO PRODUCTIVIDAD(Usuario, Id_Gestion,Fecha,Hora_Gestion,Cuenta,Proceso,Porcentaje)Values('" & dato1 & "'," & id & ",getdate(),getdate()," & Cuenta & ", '" & proceso2 & "'," & porcen & ")"
            Dim adaptadorSQL25 As New SqlDataAdapter(consulta25, New SqlConnection(coneccion))
            adaptadorSQL25.Fill(dttable5)

            ct50 = "insert into CONSOLIDADO (Id_Gestion ,Cuenta ,Proceso ,Gestion,Sub_Razon,Servicios_Dx,Fecha ,Hora_Gestion,Usuario) values(" & id & ", " & Cuenta & ", '" & proceso2 & "','" & Marca & "','" & Motivo_reclamacion & "'," & cant_servicios & ",getdate(),getdate(), '" & dato1 & "')"
            Dim adaptadorSQL50 As New SqlDataAdapter(ct50, New SqlConnection(coneccion))
            adaptadorSQL50.Fill(dt50)

            insertar()

            '******************************************************************
            TextBox1.Text = 0
            TextBox2.Text = 0
            TextBox3.Text = ""
            TextBox4.Text = ""
            DateTimePicker3.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""
            TextBox8.Text = ""
            TextBox9.Text = ""
            TextBox11.Text = ""
            TextBox12.Text = ""
            TextBox13.Text = ""
            TextBox14.Text = ""
            TextBox15.Text = ""
            TextBox16.Text = ""
            TextBox17.Text = ""
            TextBox19.Text = ""
            TextBox20.Text = ""
            TextBox21.Text = ""
            TextBox22.Text = ""
            limpiar(Me)
            TextBox1.DataBindings.Clear()
            TextBox2.DataBindings.Clear()
            TextBox3.DataBindings.Clear()
            TextBox4.DataBindings.Clear()
            DateTimePicker3.DataBindings.Clear()
            TextBox6.DataBindings.Clear()
            TextBox7.DataBindings.Clear()
            TextBox8.DataBindings.Clear()
            TextBox9.DataBindings.Clear()
            TextBox10.DataBindings.Clear()
            TextBox11.DataBindings.Clear()
            TextBox12.DataBindings.Clear()
            TextBox13.DataBindings.Clear()
            TextBox14.DataBindings.Clear()
            TextBox15.DataBindings.Clear()
            TextBox16.DataBindings.Clear()
            TextBox17.DataBindings.Clear()
            TextBox19.DataBindings.Clear()
            TextBox20.DataBindings.Clear()
            TextBox21.DataBindings.Clear()
            TextBox22.DataBindings.Clear()
            ComboBox1.DataBindings.Clear()
            ComboBox2.DataBindings.Clear()
            ComboBox5.DataBindings.Clear()
            ComboBox6.DataBindings.Clear()
            ComboBox7.DataBindings.Clear()

            ComboBox1.Text = ""
            ComboBox2.Text = ""
            ComboBox5.Text = ""
            ComboBox6.Text = ""
            ComboBox7.Text = ""

            DateTimePicker1.Text = ""
            DateTimePicker2.Text = ""
            DateTimePicker3.Text = ""

            DateTimePicker1.DataBindings.Clear()
            DateTimePicker2.DataBindings.Clear()
            DateTimePicker3.DataBindings.Clear()
            TextBox19.Text = 0
            TextBox20.Text = 0

            Dim dttable As New DataTable
            Dim consulta2 As String

            consulta2 = "SELECT * FROM ASIG_VENCIDOS"

            Dim adaptadorSQL As New SqlDataAdapter(consulta2, New SqlConnection(coneccion))
            adaptadorSQL.Fill(dttable)


            If adaptadorSQL.Fill(dttable) = False Then

                MsgBox("NO HAY REGISTROS DISPONIBLES")

            Else
                TextBox1.DataBindings.Add(New Binding("Text", dttable, "Cuenta"))
                TextBox2.DataBindings.Add(New Binding("Text", dttable, "Numero_Ticket"))
                TextBox1.Focus()

                Dim dttable1 As New DataTable
                Dim consulta3 As String
                Dim Dato As Integer

                Dato = TextBox2.Text
                consulta3 = "delete ASIG_VENCIDOS where Numero_Ticket = " & Dato & ""

                Dim adaptadorSQL2 As New SqlDataAdapter(consulta3, New SqlConnection(coneccion))
                adaptadorSQL2.Fill(dttable1)
                cargar_registros()
            End If
        Else
            consulta25 = ""
            consulta4 = ""
            consulta5 = ""

        End If
    End Sub
    Public Sub insertar()
        Dim ct55 As String
        Dim dt55 As New DataTable

        Dim Cuenta As Double = TextBox1.Text
        Dim Numero_Ticket As Double = TextBox2.Text
        Dim Canal_ingreso As String = TextBox3.Text
        Dim Usuario_Creacion As String = TextBox4.Text
        Dim Fecha_Creacion As String = DateTimePicker3.Text
        Dim SRCAUS As String = TextBox6.Text
        Dim SRREAS As String = TextBox7.Text
        Dim Motivo_Dx As String = TextBox8.Text
        Dim Codigo As String = TextBox9.Text
        Dim Nota1 As String = TextBox10.Text
        Dim Nota2 As String = TextBox11.Text
        Dim Nota3 As String = TextBox12.Text
        Dim Nota4 As String = TextBox13.Text
        Dim Nota5 As String = TextBox14.Text
        Dim Fecha_escalamiento As String = DateTimePicker1.Text
        Dim Marca As String = ComboBox1.Text
        Dim Motivo_reclamacion As String = ComboBox2.Text
        Dim Usuario_Retencion As String = TextBox15.Text
        Dim Ofreci_reten As String = TextBox16.Text
        Dim Fecha_Sol_can As String = DateTimePicker2.Text
        Dim Marcacion As String = ComboBox5.Text
        Dim Usuario_cancelacion As String = TextBox17.Text
        Dim Moviletter As Double = TextBox19.Text
        Dim cant_servicios As Integer = TextBox20.Text
        Dim Ajuste As String = ComboBox6.Text
        Dim Estado_ticket As String = ComboBox7.Text
        Dim Usuario_escalado As String = TextBox21.Text
        Dim Observaciones As String = TextBox22.Text

        Dim dato1 As String = ""
        Dim dt10 As New DataTable
        Dim c1 As String
        Dim nameusu As String = Label33.Text


        c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nameusu & "'"
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt10)
        Dim i As Integer

        For i = 0 To dt10.Rows.Count - 1
            dato1 = dt10.Rows(i).Item("Usuario")
        Next

        ct55 = "INSERT INTO CASOS_VENCIDOS(Fecha_Gestion,Hora_Gestion,Usuario,Cuenta,Numero_Ticket,Fecha_Escalamiento,Marca,Motivo_Rec,Usu_Retencion,Ofrec_Ret,Fecha_sol_can,Marcacion,Usuaruio_Can,Movie_Letter,Numero_Ser,Ajuste,Estado_Ticket,Usuario_Escala,Observaciones)Values(getdate(),getdate(),'" & dato1 & "'," & Cuenta & "," & Numero_Ticket & ",'" & Fecha_escalamiento & "','" & Marca & "','" & Motivo_reclamacion & "','" & Usuario_Retencion & "','" & Ofreci_reten & "','" & Fecha_Sol_can & "','" & Marcacion & "','" & Usuario_cancelacion & "'," & Moviletter & "," & cant_servicios & ",'" & Ajuste & "','" & Estado_ticket & "','" & Usuario_escalado & "','" & Observaciones & "')"
        Dim adaptadorSQL55 As New SqlDataAdapter(ct55, New SqlConnection(coneccion))
        adaptadorSQL55.Fill(dt55)
    End Sub
    Private Sub Cerrar_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If TextBox2.Text = "" Then

        Else
            Dim c2 As String
            Dim dt2 As New DataTable
            Dim Cuenta As Double = TextBox1.Text
            Dim Numero_Ticket As Double = TextBox2.Text

            If (MsgBox("Recuerde que al cerrar el formulario el registro no va a ser gestionado.", MsgBoxStyle.OkOnly, "Devolucion de Registros")) = MsgBoxResult.Ok Then
                c2 = "INSERT INTO ASIG_VENCIDOS (Cuenta ,Numero_Ticket) values(" & Cuenta & "," & Numero_Ticket & ")"
                Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
                adaptadorsql2.Fill(dt2)
                MsgBox("Se Devolvio el Registro a la Base")
            Else
                c2 = ""
                Exit Sub
            End If
        End If


    End Sub

    Private Sub cargar_registros()

        TextBox3.Text = ""
        TextBox4.Text = ""
        DateTimePicker3.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""
        TextBox13.Text = ""
        TextBox14.Text = ""
        TextBox15.Text = ""
        TextBox16.Text = ""
        TextBox17.Text = ""
        TextBox19.Text = ""
        TextBox20.Text = ""
        TextBox21.Text = ""
        TextBox22.Text = ""
        limpiar(Me)
        TextBox1.DataBindings.Clear()
        TextBox2.DataBindings.Clear()
        TextBox3.DataBindings.Clear()
        TextBox4.DataBindings.Clear()
        DateTimePicker3.DataBindings.Clear()
        TextBox6.DataBindings.Clear()
        TextBox7.DataBindings.Clear()
        TextBox8.DataBindings.Clear()
        TextBox9.DataBindings.Clear()
        TextBox10.DataBindings.Clear()
        TextBox11.DataBindings.Clear()
        TextBox12.DataBindings.Clear()
        TextBox13.DataBindings.Clear()
        TextBox14.DataBindings.Clear()
        TextBox15.DataBindings.Clear()
        TextBox16.DataBindings.Clear()
        TextBox17.DataBindings.Clear()
        TextBox19.DataBindings.Clear()
        TextBox20.DataBindings.Clear()
        TextBox21.DataBindings.Clear()
        TextBox22.DataBindings.Clear()
        ComboBox1.DataBindings.Clear()
        ComboBox2.DataBindings.Clear()
        ComboBox5.DataBindings.Clear()
        ComboBox6.DataBindings.Clear()
        ComboBox7.DataBindings.Clear()

        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox5.Text = ""
        ComboBox6.Text = ""
        ComboBox7.Text = ""

        DateTimePicker1.Text = ""
        DateTimePicker2.Text = ""
        DateTimePicker3.Text = ""

        DateTimePicker1.DataBindings.Clear()
        DateTimePicker2.DataBindings.Clear()
        DateTimePicker3.DataBindings.Clear()
        TextBox19.Text = 0
        TextBox20.Text = 0

        Dim dt1 As New DataTable
        Dim c1 As String
        Dim Cuenta As Integer = TextBox1.Text
        Dim PQR As Integer = TextBox2.Text

        c1 = "Select * From TICKETS WHERE Cuenta = " & Cuenta & " and Numero_Ticket=" & PQR & ""
        Dim Adaptadorsql As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        Adaptadorsql.Fill(dt1)

        If Adaptadorsql.Fill(dt1) <> 0 Then
            TextBox3.DataBindings.Add(New Binding("Text", dt1, "Ingreso"))
            TextBox4.DataBindings.Add(New Binding("Text", dt1, "Usuario_Crea"))
            DateTimePicker3.DataBindings.Add(New Binding("Text", dt1, "Fecha_Tiket"))
            TextBox6.DataBindings.Add(New Binding("Text", dt1, "SRCAUS"))
            TextBox7.DataBindings.Add(New Binding("Text", dt1, "SRREAS"))
            TextBox8.DataBindings.Add(New Binding("Text", dt1, "Motivo"))
            TextBox9.DataBindings.Add(New Binding("Text", dt1, "Codigo"))
            TextBox10.DataBindings.Add(New Binding("Text", dt1, "Nota1"))
            TextBox11.DataBindings.Add(New Binding("Text", dt1, "Nota2"))
            TextBox12.DataBindings.Add(New Binding("Text", dt1, "Nota3"))
            TextBox13.DataBindings.Add(New Binding("Text", dt1, "Nota4"))
            TextBox14.DataBindings.Add(New Binding("Text", dt1, "Nota5"))
            DateTimePicker1.DataBindings.Add(New Binding("Text", dt1, "Fecha_Escalamiento"))
            ComboBox1.DataBindings.Add(New Binding("Text", dt1, "Marca"))
            ComboBox2.DataBindings.Add(New Binding("Text", dt1, "Motivo_Rec"))
            TextBox15.DataBindings.Add(New Binding("Text", dt1, "Usu_Retencion"))
            TextBox16.DataBindings.Add(New Binding("Text", dt1, "Ofrec_Ret"))
            DateTimePicker2.DataBindings.Add(New Binding("Text", dt1, "Fecha_sol_can"))
            ComboBox5.DataBindings.Add(New Binding("Text", dt1, "Marcacion"))
            TextBox17.DataBindings.Add(New Binding("Text", dt1, "Usuaruio_Can"))
            TextBox19.DataBindings.Add(New Binding("Text", dt1, "Movie_Letter"))
            TextBox20.DataBindings.Add(New Binding("Text", dt1, "Numero_Ser"))
            ComboBox6.DataBindings.Add(New Binding("Text", dt1, "Ajuste"))
            ComboBox7.DataBindings.Add(New Binding("Text", dt1, "Estado_Ticket"))
            TextBox21.DataBindings.Add(New Binding("Text", dt1, "Usuario_Escala"))
            TextBox22.DataBindings.Add(New Binding("Text", dt1, "Observaciones"))

        Else
            MsgBox("No hay registros relacionados con la consulta")
        End If


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Cuenta_hallazgos = TextBox1.Text
        Hallazgos.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Cuenta_escalamiento = TextBox1.Text
        Escalamientos_anterior.Show()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        ComboBox1.DataBindings.Clear()
        ComboBox2.DataBindings.Clear()
        ComboBox2.Text = ""
        ComboBox2.Items.Clear()


        Dim c1, c2 As String
        Dim dt1, dt2 As New DataTable
        Dim sub_proceso As Integer
        Dim nombre_sub_proceso As String = ComboBox1.Text


        c2 = "SELECT ID_SUBPROCESO FROM SUB_PROCESOS WHERE NOMBRE_SUB_PROCESO like '" & nombre_sub_proceso & "' and ID_MACROPROCESO=" & ID_MACROPROCESO & ""
        Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
        adaptadorsql2.Fill(dt2)
        Dim j As Integer

        For j = 0 To dt2.Rows.Count - 1
            sub_proceso = dt2.Rows(j).Item("ID_SUBPROCESO")
        Next

        c1 = "SELECT NOMBRE_PROCESO FROM PROCESOS WHERE ID_SUBPROCESO =" & sub_proceso & ""
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt1)

        Dim i As Integer

        For i = 0 To dt1.Rows.Count - 1
            ComboBox2.Items.Add(dt1.Rows(i).Item("NOMBRE_PROCESO"))
        Next

    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

        Dim dt1 As New DataTable
        Dim c1 As String
        Dim Cuenta As Integer = TextBox1.Text
        Dim PQR As Integer = TextBox2.Text

        c1 = "Select * From TICKETS WHERE Cuenta = " & Cuenta & " and Numero_Ticket=" & PQR & ""
        Dim Adaptadorsql As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        Adaptadorsql.Fill(dt1)

        If Adaptadorsql.Fill(dt1) <> 0 Then
            TextBox3.DataBindings.Add(New Binding("Text", dt1, "Ingreso"))
            TextBox4.DataBindings.Add(New Binding("Text", dt1, "Usuario_Crea"))
            DateTimePicker3.DataBindings.Add(New Binding("Text", dt1, "Fecha_Tiket"))
            TextBox6.DataBindings.Add(New Binding("Text", dt1, "SRCAUS"))
            TextBox7.DataBindings.Add(New Binding("Text", dt1, "SRREAS"))
            TextBox8.DataBindings.Add(New Binding("Text", dt1, "Motivo"))
            TextBox9.DataBindings.Add(New Binding("Text", dt1, "Codigo"))
            TextBox10.DataBindings.Add(New Binding("Text", dt1, "Nota1"))
            TextBox11.DataBindings.Add(New Binding("Text", dt1, "Nota2"))
            TextBox12.DataBindings.Add(New Binding("Text", dt1, "Nota3"))
            TextBox13.DataBindings.Add(New Binding("Text", dt1, "Nota4"))
            TextBox14.DataBindings.Add(New Binding("Text", dt1, "Nota5"))
            DateTimePicker1.DataBindings.Add(New Binding("Text", dt1, "Fecha_Escalamiento"))
            ComboBox1.DataBindings.Add(New Binding("Text", dt1, "Marca"))
            ComboBox2.DataBindings.Add(New Binding("Text", dt1, "Motivo_Rec"))
            TextBox15.DataBindings.Add(New Binding("Text", dt1, "Usu_Retencion"))
            TextBox16.DataBindings.Add(New Binding("Text", dt1, "Ofrec_Ret"))
            DateTimePicker2.DataBindings.Add(New Binding("Text", dt1, "Fecha_sol_can"))
            ComboBox5.DataBindings.Add(New Binding("Text", dt1, "Marcacion"))
            TextBox17.DataBindings.Add(New Binding("Text", dt1, "Usuaruio_Can"))
            TextBox19.DataBindings.Add(New Binding("Text", dt1, "Movie_Letter"))
            TextBox20.DataBindings.Add(New Binding("Text", dt1, "Numero_Ser"))
            ComboBox6.DataBindings.Add(New Binding("Text", dt1, "Ajuste"))
            ComboBox7.DataBindings.Add(New Binding("Text", dt1, "Estado_Ticket"))
            TextBox21.DataBindings.Add(New Binding("Text", dt1, "Usuario_Escala"))
            TextBox22.DataBindings.Add(New Binding("Text", dt1, "Observaciones"))

        Else

        End If

    End Sub
End Class