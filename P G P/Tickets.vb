Imports System.Data.SqlClient

Public Class Tickets
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

        ComboBox3.DataBindings.Clear()

        Dim consulta2 As String
        Dim dttable As New DataTable

        consulta2 = "SELECT * FROM ASIG_TICKETS WHERE TIPO_RECLAMACION='Otros Procesos' ORDER BY FECHA_CREACION ASC"

        Dim adaptadorSQL As New SqlDataAdapter(consulta2, New SqlConnection(coneccion))
        adaptadorSQL.Fill(dttable)

        If adaptadorSQL.Fill(dttable) = False Then
            MsgBox("NO HAY REGISTROS DISPONIBLES")
        Else
            TextBox1.DataBindings.Add(New Binding("Text", dttable, "Cuenta"))
            TextBox2.DataBindings.Add(New Binding("Text", dttable, "Numero_Ticket"))
            ComboBox3.DataBindings.Add(New Binding("Text", dttable, "Canal_Ingreso"))
            TextBox4.DataBindings.Add(New Binding("Text", dttable, "Usuario_Creacion"))
            DateTimePicker3.DataBindings.Add(New Binding("Text", dttable, "Fecha_Creacion"))
            TextBox6.DataBindings.Add(New Binding("Text", dttable, "SRCAUS"))
            TextBox7.DataBindings.Add(New Binding("Text", dttable, "SRREAS"))
            TextBox8.DataBindings.Add(New Binding("Text", dttable, "Motivo_Dx"))
            TextBox9.DataBindings.Add(New Binding("Text", dttable, "Codigo"))
            TextBox10.DataBindings.Add(New Binding("Text", dttable, "Nota1"))
            TextBox11.DataBindings.Add(New Binding("Text", dttable, "Nota2"))
            TextBox12.DataBindings.Add(New Binding("Text", dttable, "Nota3"))
            TextBox13.DataBindings.Add(New Binding("Text", dttable, "Nota4"))
            TextBox14.DataBindings.Add(New Binding("Text", dttable, "Nota5"))

            Dim dttable1 As New DataTable
            Dim consulta3 As String
            Dim Dato As Double

            Dato = TextBox2.Text
            consulta3 = "delete ASIG_TICKETS where Numero_Ticket = " & Dato & ""

            Dim adaptadorSQL2 As New SqlDataAdapter(consulta3, New SqlConnection(coneccion))
            adaptadorSQL2.Fill(dttable1)
            ComboBox4.Text = 0
            TextBox19.Text = 0

        End If

        TextBox12.Text = "DESCONECTAR FISICAMENTE"
        TextBox13.Text = "ASEGURAMIENTO"

        Dim DIAACTUAL As Integer = Today.Day
        Dim MESACTUAL As Integer = Today.Month
        Dim DIA2 As String = ""
        Dim MES2 As String = ""

        If DIAACTUAL < 10 Then
            DIA2 = "0" & Today.Day
        Else
            DIA2 = Today.Day
        End If

        If MESACTUAL < 10 Then
            MES2 = "0" & Today.Month
        Else
            MES2 = Today.Month
        End If
        TextBox14.Text = Today.Year & MES2 & DIA2

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim dttable4, dttable5, dttable25 As New DataTable
        Dim consulta4, consulta5, consulta25 As String

        Dim Cuenta As Double = TextBox1.Text
        Dim Numero_Ticket As Double = TextBox2.Text
        Dim Canal_ingreso As String = ComboBox3.Text
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
        Dim cant_servicios As Integer = ComboBox4.Text
        Dim Ajuste As String = ComboBox6.Text
        Dim Estado_ticket As String = ComboBox7.Text
        Dim Usuario_escalado As String = TextBox21.Text
        Dim Observaciones As String = TextBox22.Text

        Dim dato1 As String = ""
        Dim dt10 As New DataTable
        Dim c1 As String

        Dim AÑO_CREACION As Integer = DateTimePicker3.Value.Year
        Dim MES_CREACION As Integer = DateTimePicker3.Value.Month
        Dim DIA_CREACION As Integer = DateTimePicker3.Value.Day

        c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt10)
        Dim i As Integer

        For i = 0 To dt10.Rows.Count - 1
            dato1 = dt10.Rows(i).Item("Usuario")
        Next

        If (MsgBox("Desea guardar registro?", MsgBoxStyle.YesNo, "Guardar")) = MsgBoxResult.Yes Then

            Dim id As Integer = 8
            Dim proceso As String = "Tickets"

            consulta4 = "INSERT INTO TICKETS (Fecha_Gestion ,AÑO_GESTION,MES_GESTION,DIA_GESTION,Hora_Gestion ,Usuario ,CANAL_INGRESO ,Cuenta ,Numero_Ticket ,Usuario_Crea ,FECHA_CREACION ,AÑO_CREACION,MES_CREACION,DIA_CREACION,SRCAUS ,SRREAS ,Motivo ,Codigo ,Nota1 ,Nota2 ,Nota3 ,Nota4 ,Nota5,Fecha_Escalamiento,Marca ,Motivo_Rec ,Usu_Retencion ,Ofrec_Ret ,Fecha_sol_can ,Marcacion ,Usuaruio_Can ,Movie_Letter ,Numero_Ser ,Ajuste ,Estado_Ticket ,Usuario_Escala ,Observaciones )values(getdate()," & AÑO & "," & MES & "," & DIA & ",getdate(),'" & dato1 & "','" & Canal_ingreso & "', " & Cuenta & ", " & Numero_Ticket & ", '" & Usuario_Creacion & "','" & Fecha_Creacion & "'," & AÑO_CREACION & "," & MES_CREACION & "," & DIA_CREACION & ",'" & SRCAUS & "','" & SRREAS & "','" & Motivo_Dx & "', '" & Codigo & "', '" & Nota1 & "','" & Nota2 & "','" & Nota3 & "','" & Nota4 & "','" & Nota5 & "','" & Fecha_escalamiento & "','" & Marca & "', '" & Motivo_reclamacion & "','" & Usuario_Retencion & "', '" & Ofreci_reten & "', '" & Fecha_Sol_can & "','" & Marcacion & "', '" & Usuario_cancelacion & "'," & Moviletter & ", " & cant_servicios & ",'" & Ajuste & "','" & Estado_ticket & "','" & Usuario_escalado & "', '" & Observaciones & "')"
            Dim adaptadorSQL4 As New SqlDataAdapter(consulta4, New SqlConnection(coneccion))
            adaptadorSQL4.Fill(dttable4)

            consulta5 = "INSERT INTO CONSOLIDADO(ID_GESTION,CUENTA,CANAL_INGRESO,FECHA_CREACION,PROCESO,GESTION,SUB_RAZON,SERVICIOS_DX,FECHA_GESTION,AÑO_GESTION,MES_GESTION,DIA_GESTION,HORA_GESTION,USUARIO,OBSERVACIONES) VALUES(" & id & ", " & Cuenta & ",'" & Canal_ingreso & "','" & Fecha_Creacion & "','" & proceso & "','" & Marca & "','" & Motivo_reclamacion & "'," & cant_servicios & ",getdate()," & AÑO & "," & MES & "," & DIA & ",getdate(), '" & dato1 & "','" & Observaciones & "')"
            Dim adaptadorSQL5 As New SqlDataAdapter(consulta5, New SqlConnection(coneccion))
            adaptadorSQL5.Fill(dttable5)

            Dim porcen As Decimal
            porcen = 1
            consulta25 = "INSERT INTO PRODUCTIVIDAD (USUARIO,ID_GESTION,FECHA,AÑO,MES,DIA,HORA_GESTION,CUENTA,PROCESO,PORCENTAJE)VALUES('" & dato1 & "'," & id & ",getdate()," & AÑO & "," & MES & "," & DIA & ",getdate()," & Cuenta & ", '" & proceso & "'," & porcen & ")"
            Dim adaptadorSQL25 As New SqlDataAdapter(consulta25, New SqlConnection(coneccion))
            adaptadorSQL25.Fill(dttable5)

            '******************************************************************
            TextBox1.Text = ""
            TextBox2.Text = ""
            ComboBox3.Text = ""
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
            ComboBox4.Text = ""
            TextBox21.Text = ""
            TextBox22.Text = ""
            limpiar(Me)
            TextBox1.DataBindings.Clear()
            TextBox2.DataBindings.Clear()
            ComboBox3.DataBindings.Clear()
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
            ComboBox4.DataBindings.Clear()
            TextBox21.DataBindings.Clear()
            TextBox22.DataBindings.Clear()
            ComboBox1.DataBindings.Clear()
            ComboBox2.DataBindings.Clear()
            ComboBox5.DataBindings.Clear()
            ComboBox6.DataBindings.Clear()
            ComboBox7.DataBindings.Clear()

            Me.ComboBox1.SelectedIndex = -1
            Me.ComboBox2.SelectedIndex = -1
            Me.ComboBox3.SelectedIndex = -1
            Me.ComboBox4.SelectedIndex = -1
            Me.ComboBox5.SelectedIndex = -1
            Me.ComboBox6.SelectedIndex = -1
            Me.ComboBox7.SelectedIndex = -1


            ComboBox1.Text = ""
            ComboBox2.Text = ""
            ComboBox5.Text = ""
            ComboBox6.Text = ""
            ComboBox7.Text = ""

            DateTimePicker1.Text = ""
            DateTimePicker2.Text = ""

            DateTimePicker1.DataBindings.Clear()
            DateTimePicker2.DataBindings.Clear()
            TextBox19.Text = 0
            ComboBox4.Text = 0

            Dim dttable As New DataTable
            Dim consulta2 As String

            consulta2 = "SELECT * FROM ASIG_TICKETS WHERE TIPO_RECLAMACION='Otros Procesos' ORDER BY FECHA_CREACION ASC"

            Dim adaptadorSQL As New SqlDataAdapter(consulta2, New SqlConnection(coneccion))
            adaptadorSQL.Fill(dttable)


            If adaptadorSQL.Fill(dttable) = False Then

                MsgBox("NO HAY REGISTROS DISPONIBLES")

            Else
                TextBox1.DataBindings.Add(New Binding("Text", dttable, "Cuenta"))
                TextBox2.DataBindings.Add(New Binding("Text", dttable, "Numero_Ticket"))
                ComboBox3.DataBindings.Add(New Binding("Text", dttable, "Canal_Ingreso"))
                TextBox4.DataBindings.Add(New Binding("Text", dttable, "Usuario_Creacion"))
                DateTimePicker3.DataBindings.Add(New Binding("Text", dttable, "Fecha_Creacion"))
                TextBox6.DataBindings.Add(New Binding("Text", dttable, "SRCAUS"))
                TextBox7.DataBindings.Add(New Binding("Text", dttable, "SRREAS"))
                TextBox8.DataBindings.Add(New Binding("Text", dttable, "Motivo_Dx"))
                TextBox9.DataBindings.Add(New Binding("Text", dttable, "Codigo"))
                TextBox10.DataBindings.Add(New Binding("Text", dttable, "Nota1"))
                TextBox11.DataBindings.Add(New Binding("Text", dttable, "Nota2"))
                TextBox12.DataBindings.Add(New Binding("Text", dttable, "Nota3"))
                TextBox13.DataBindings.Add(New Binding("Text", dttable, "Nota4"))
                TextBox14.DataBindings.Add(New Binding("Text", dttable, "Nota5"))
                TextBox1.Focus()

                Dim dttable1 As New DataTable
                Dim consulta3 As String
                Dim Dato As Double

                Dato = TextBox2.Text
                consulta3 = "delete ASIG_TICKETS where Numero_Ticket = " & Dato & ""

                Dim adaptadorSQL2 As New SqlDataAdapter(consulta3, New SqlConnection(coneccion))
                adaptadorSQL2.Fill(dttable1)
            End If
        Else
            consulta25 = ""
            consulta4 = ""
            consulta5 = ""

        End If

        TextBox12.Text = "DESCONECTAR FISICAMENTE"
        TextBox13.Text = "ASEGURAMIENTO"

        Dim DIAACTUAL As Integer = Today.Day
        Dim MESACTUAL As Integer = Today.Month
        Dim DIA2 As String = ""
        Dim MES2 As String = ""

        If DIAACTUAL < 10 Then
            DIA2 = "0" & Today.Day
        Else
            DIA2 = Today.Day
        End If

        If MESACTUAL < 10 Then
            MES2 = "0" & Today.Month
        Else
            MES2 = Today.Month
        End If
        TextBox14.Text = Today.Year & MES2 & DIA2
    End Sub
    Private Sub Cerrar_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If TextBox2.Text = "" Then

        Else
            Dim c2 As String
            Dim dt2 As New DataTable
            Dim Cuenta As Double = TextBox1.Text
            Dim Numero_Ticket As Double = TextBox2.Text
            Dim Canal_ingreso As String = ComboBox3.Text
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
            Dim Tipo_Reclamacion = "Otros Procesos"

            If (MsgBox("Recuerde que al cerrar el formulario el registro no va a ser gestionado.", MsgBoxStyle.OkOnly, "Devolucion de Registros")) = MsgBoxResult.Ok Then
                c2 = "INSERT INTO ASIG_TICKETS (Canal_Ingreso ,Cuenta ,Numero_Ticket ,Usuario_Creacion ,Fecha_Creacion ,SRCAUS ,SRREAS ,Motivo_Dx ,Codigo, Nota1 ,Nota2 , Nota3 ,Nota4 ,Nota5,Tipo_Reclamacion ) values('" & Canal_ingreso & "'," & Cuenta & "," & Numero_Ticket & ",'" & Usuario_Creacion & "','" & Fecha_Creacion & "','" & SRCAUS & "','" & SRREAS & "','" & Motivo_Dx & "','" & Codigo & "','" & Nota1 & "','" & Nota2 & "','" & Nota3 & "','" & Nota4 & "','" & Nota5 & "','" & Tipo_Reclamacion & "')"
                Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
                adaptadorsql2.Fill(dt2)
                MsgBox("Se Devolvio el Registro a la Base")
            Else
                c2 = ""

                Exit Sub
            End If
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

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim dttable4, dttable5, dttable25 As New DataTable
        Dim consulta4, consulta5, consulta25 As String

        Dim Cuenta As Double = TextBox1.Text
        Dim Numero_Ticket As Double = TextBox2.Text
        Dim Canal_ingreso As String = ComboBox3.Text
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
        Dim cant_servicios As Integer = ComboBox4.Text
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

        If (MsgBox("Desea escalar el registro a retención?", MsgBoxStyle.YesNo, "Escalar")) = MsgBoxResult.Yes Then

            Dim AÑO_CREACION As Integer = DateTimePicker3.Value.Year
            Dim MES_CREACION As Integer = DateTimePicker3.Value.Month
            Dim DIA_CREACION As Integer = DateTimePicker3.Value.Day


            Dim id As Integer = 11
            Dim proceso As String = "Tickets"

            consulta4 = "INSERT INTO CASOS_RETENCION (Fecha_Gestion ,AÑO_GESTION,MES_GESTION,DIA_GESTION,Hora_Gestion ,Usuario ,CANAL_INGRESO ,Cuenta ,Numero_Ticket ,Usuario_Crea ,FECHA_CREACION,AÑO_CREACION,MES_CREACION,DIA_CREACION,SRCAUS ,SRREAS ,Motivo ,Codigo ,Nota1 ,Nota2 ,Nota3 ,Nota4 ,Nota5,Fecha_Escalamiento,Marca ,Motivo_Rec ,Usu_Retencion ,Ofrec_Ret ,Fecha_sol_can ,Marcacion ,Usuaruio_Can ,Movie_Letter ,Numero_Ser ,Ajuste ,Estado_Ticket ,Usuario_Escala ,Observaciones )values(getdate()," & AÑO & "," & MES & "," & DIA & ",getdate(),'" & dato1 & "','" & Canal_ingreso & "', " & Cuenta & ", " & Numero_Ticket & ", '" & Usuario_Creacion & "','" & Fecha_Creacion & "'," & AÑO_CREACION & "," & MES_CREACION & "," & DIA_CREACION & ", '" & SRCAUS & "','" & SRREAS & "','" & Motivo_Dx & "', '" & Codigo & "', '" & Nota1 & "','" & Nota2 & "','" & Nota3 & "','" & Nota4 & "','" & Nota5 & "','" & Fecha_escalamiento & "','" & Marca & "', '" & Motivo_reclamacion & "','" & Usuario_Retencion & "', '" & Ofreci_reten & "', '" & Fecha_Sol_can & "','" & Marcacion & "', '" & Usuario_cancelacion & "'," & Moviletter & ", " & cant_servicios & ",'" & Ajuste & "','" & Estado_ticket & "','" & Usuario_escalado & "', '" & Observaciones & "')"
            Dim adaptadorSQL4 As New SqlDataAdapter(consulta4, New SqlConnection(coneccion))
            adaptadorSQL4.Fill(dttable4)

            Dim porcen As Decimal
            porcen = 1
            consulta25 = "INSERT INTO PRODUCTIVIDAD (USUARIO,ID_GESTION,FECHA,AÑO,MES,DIA,HORA_GESTION,CUENTA,PROCESO,PORCENTAJE)VALUES('" & dato1 & "'," & id & ",getdate()," & AÑO & "," & MES & "," & DIA & ",getdate()," & Cuenta & ", '" & proceso & "'," & porcen & ")"
            Dim adaptadorSQL25 As New SqlDataAdapter(consulta25, New SqlConnection(coneccion))
            adaptadorSQL25.Fill(dttable5)
            MsgBox("Registro Escalado")

            TextBox1.Text = ""
            TextBox2.Text = ""
            ComboBox3.Text = ""
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
            ComboBox4.Text = ""
            TextBox21.Text = ""
            TextBox22.Text = ""
            limpiar(Me)
            TextBox1.DataBindings.Clear()
            TextBox2.DataBindings.Clear()
            ComboBox3.DataBindings.Clear()
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
            ComboBox4.DataBindings.Clear()
            TextBox21.DataBindings.Clear()
            TextBox22.DataBindings.Clear()
            ComboBox1.DataBindings.Clear()
            ComboBox2.DataBindings.Clear()
            ComboBox5.DataBindings.Clear()
            ComboBox6.DataBindings.Clear()
            ComboBox7.DataBindings.Clear()

            Me.ComboBox1.SelectedIndex = -1
            Me.ComboBox2.SelectedIndex = -1
            Me.ComboBox3.SelectedIndex = -1
            Me.ComboBox4.SelectedIndex = -1
            Me.ComboBox5.SelectedIndex = -1
            Me.ComboBox6.SelectedIndex = -1
            Me.ComboBox7.SelectedIndex = -1


            ComboBox1.Text = ""
            ComboBox2.Text = ""
            ComboBox5.Text = ""
            ComboBox6.Text = ""
            ComboBox7.Text = ""

            DateTimePicker1.Text = ""
            DateTimePicker2.Text = ""

            DateTimePicker1.DataBindings.Clear()
            DateTimePicker2.DataBindings.Clear()
            TextBox19.Text = 0
            ComboBox4.Text = 0

            Dim dttable As New DataTable
            Dim consulta2 As String

            consulta2 = "SELECT * FROM ASIG_TICKETS WHERE TIPO_RECLAMACION='Otros Procesos' ORDER BY FECHA_CREACION ASC"

            Dim adaptadorSQL As New SqlDataAdapter(consulta2, New SqlConnection(coneccion))
            adaptadorSQL.Fill(dttable)


            If adaptadorSQL.Fill(dttable) = False Then

                MsgBox("NO HAY REGISTROS DISPONIBLES")

            Else
                TextBox1.DataBindings.Add(New Binding("Text", dttable, "Cuenta"))
                TextBox2.DataBindings.Add(New Binding("Text", dttable, "Numero_Ticket"))
                ComboBox3.DataBindings.Add(New Binding("Text", dttable, "Canal_Ingreso"))
                TextBox4.DataBindings.Add(New Binding("Text", dttable, "Usuario_Creacion"))
                DateTimePicker3.DataBindings.Add(New Binding("Text", dttable, "Fecha_Creacion"))
                TextBox6.DataBindings.Add(New Binding("Text", dttable, "SRCAUS"))
                TextBox7.DataBindings.Add(New Binding("Text", dttable, "SRREAS"))
                TextBox8.DataBindings.Add(New Binding("Text", dttable, "Motivo_Dx"))
                TextBox9.DataBindings.Add(New Binding("Text", dttable, "Codigo"))
                TextBox10.DataBindings.Add(New Binding("Text", dttable, "Nota1"))
                TextBox11.DataBindings.Add(New Binding("Text", dttable, "Nota2"))
                TextBox12.DataBindings.Add(New Binding("Text", dttable, "Nota3"))
                TextBox13.DataBindings.Add(New Binding("Text", dttable, "Nota4"))
                TextBox14.DataBindings.Add(New Binding("Text", dttable, "Nota5"))
                TextBox1.Focus()

                Dim dttable1 As New DataTable
                Dim consulta3 As String
                Dim Dato As Integer

                Dato = TextBox2.Text
                consulta3 = "delete ASIG_TICKETS where Numero_Ticket = " & Dato & ""

                Dim adaptadorSQL2 As New SqlDataAdapter(consulta3, New SqlConnection(coneccion))
                adaptadorSQL2.Fill(dttable1)
            End If
        Else
            consulta25 = ""
            consulta4 = ""
            consulta5 = ""

        End If
        Button1.Enabled = True

        TextBox12.Text = "DESCONECTAR FISICAMENTE"
        TextBox13.Text = "ASEGURAMIENTO"

        Dim DIAACTUAL As Integer = Today.Day
        Dim MESACTUAL As Integer = Today.Month
        Dim DIA2 As String = ""
        Dim MES2 As String = ""

        If DIAACTUAL < 10 Then
            DIA2 = "0" & Today.Day
        Else
            DIA2 = Today.Day
        End If

        If MESACTUAL < 10 Then
            MES2 = "0" & Today.Month
        Else
            MES2 = Today.Month
        End If
        TextBox14.Text = Today.Year & MES2 & DIA2

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
        duplicidad()
    End Sub
    Public Sub duplicidad()
        TextBox12.Text = "DESCONECTAR FISICAMENTE"
        TextBox13.Text = "ASEGURAMIENTO"

        Dim DIAACTUAL As Integer = Today.Day
        Dim MESACTUAL As Integer = Today.Month
        Dim DIA2 As String = ""
        Dim MES2 As String = ""

        If DIAACTUAL < 10 Then
            DIA2 = "0" & Today.Day
        Else
            DIA2 = Today.Day
        End If

        If MESACTUAL < 10 Then
            MES2 = "0" & Today.Month
        Else
            MES2 = Today.Month
        End If
        TextBox14.Text = Today.Year & MES2 & DIA2

        If TextBox2.Text <> "" Then

            Dim NUMERO_TICKET As Double = TextBox2.Text

            Dim dttable As New DataTable
            Dim consulta2 As String

            consulta2 = "SELECT * FROM TICKETS WHERE NUMERO_TICKET=" & NUMERO_TICKET & ""
            Dim adaptadorSQL As New SqlDataAdapter(consulta2, New SqlConnection(coneccion))
            adaptadorSQL.Fill(dttable)
            If adaptadorSQL.Fill(dttable) <> 0 Then

                DateTimePicker1.DataBindings.Add(New Binding("Text", dttable, "FECHA_ESCALAMIENTO"))
                ComboBox1.DataBindings.Add(New Binding("Text", dttable, "MARCA"))
                ComboBox2.DataBindings.Add(New Binding("Text", dttable, "MOTIVO_REC"))
                TextBox15.DataBindings.Add(New Binding("Text", dttable, "USU_RETENCION"))
                TextBox16.DataBindings.Add(New Binding("Text", dttable, "OFREC_RET"))
                DateTimePicker2.DataBindings.Add(New Binding("Text", dttable, "FECHA_SOL_CAN"))
                ComboBox5.DataBindings.Add(New Binding("Text", dttable, "MARCACION"))
                TextBox17.DataBindings.Add(New Binding("Text", dttable, "USUARUIO_CAN"))
                TextBox19.DataBindings.Add(New Binding("Text", dttable, "MOVIE_LETTER"))
                ComboBox4.DataBindings.Add(New Binding("Text", dttable, "NUMERO_SER"))
                ComboBox6.DataBindings.Add(New Binding("Text", dttable, "AJUSTE"))
                ComboBox7.DataBindings.Add(New Binding("Text", dttable, "ESTADO_TICKET"))
                TextBox21.DataBindings.Add(New Binding("Text", dttable, "USUARIO_ESCALA"))
                TextBox22.DataBindings.Add(New Binding("Text", dttable, "OBSERVACIONES"))
                Button1.Enabled = False
            Else
                TextBox1.DataBindings.Clear()
                TextBox2.DataBindings.Clear()
                ComboBox3.DataBindings.Clear()
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
            End If
        Else
            TextBox1.DataBindings.Clear()
            TextBox2.DataBindings.Clear()
            ComboBox3.DataBindings.Clear()
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
        End If
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If TextBox1.Text <> "" Then

            Dim dttable4, dttable5, dttable25 As New DataTable
            Dim consulta4, consulta5, consulta25 As String

            Dim Cuenta As Double = TextBox1.Text
            Dim Numero_Ticket As Double = TextBox2.Text
            Dim Canal_ingreso As String = ComboBox3.Text
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
            Dim cant_servicios As Integer = ComboBox4.Text
            Dim Ajuste As String = ComboBox6.Text
            Dim Estado_ticket As String = ComboBox7.Text
            Dim Usuario_escalado As String = TextBox21.Text
            Dim Observaciones As String = TextBox22.Text

            Dim dato1 As String = ""
            Dim dt10 As New DataTable
            Dim c1 As String

            Dim AÑO_CREACION As Integer = DateTimePicker3.Value.Year
            Dim MES_CREACION As Integer = DateTimePicker3.Value.Month
            Dim DIA_CREACION As Integer = DateTimePicker3.Value.Day

            c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
            Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
            adaptadorsql1.Fill(dt10)
            Dim i As Integer

            For i = 0 To dt10.Rows.Count - 1
                dato1 = dt10.Rows(i).Item("Usuario")
            Next

            If (MsgBox("Desea Actualizar el Registro?", MsgBoxStyle.YesNo, "Actualizar")) = MsgBoxResult.Yes Then

                Dim id As Integer = 8
                Dim proceso As String = "Tickets"

                consulta4 = "UPDATE TICKETS SET CANAL_INGRESO='" & Canal_ingreso & "' ,Usuario_Crea='" & Usuario_Creacion & "' ,FECHA_CREACION='" & Fecha_Creacion & "' ,AÑO_CREACION=" & AÑO_CREACION & ",MES_CREACION= " & MES_CREACION & ",DIA_CREACION=" & DIA_CREACION & ",SRCAUS='" & SRCAUS & "',SRREAS='" & SRREAS & "' ,Motivo='" & Motivo_Dx & "' ,Codigo=" & Codigo & " ,Nota1='" & Nota1 & "' ,Nota2='" & Nota2 & "' ,Nota3='" & Nota3 & "' ,Nota4='" & Nota4 & "' ,Nota5='" & Nota5 & "',Fecha_Escalamiento='" & Fecha_escalamiento & "',Marca='" & Marca & "' ,Motivo_Rec='" & Motivo_reclamacion & "' ,Usu_Retencion='" & Usuario_Retencion & "' ,Ofrec_Ret='" & Ofreci_reten & "' ,Fecha_sol_can='" & Fecha_Sol_can & "' ,Marcacion='" & Marcacion & "',Usuaruio_Can='" & Usuario_cancelacion & "' ,Movie_Letter=" & Moviletter & " ,Numero_Ser=" & cant_servicios & " ,Ajuste='" & Ajuste & "' ,Estado_Ticket='" & Estado_ticket & "' ,Usuario_Escala='" & Usuario_escalado & "' ,Observaciones='" & Observaciones & "' WHERE CUENTA=" & Cuenta & " AND NUMERO_TICKET=" & Numero_Ticket & ""
                Dim adaptadorSQL4 As New SqlDataAdapter(consulta4, New SqlConnection(coneccion))
                adaptadorSQL4.Fill(dttable4)

                consulta5 = "UPDATE CONSOLIDADO SET CANAL_INGRESO='" & Canal_ingreso & "',GESTION='" & Marca & "',SUB_RAZON='" & Motivo_reclamacion & "',SERVICIOS_DX=" & cant_servicios & ",OBSERVACIONES='" & Observaciones & "' WHERE CUENTA=" & Cuenta & " AND FECHA_CREACION='" & Fecha_Creacion & "' AND ID_GESTION=" & id & ""
                Dim adaptadorSQL5 As New SqlDataAdapter(consulta5, New SqlConnection(coneccion))
                adaptadorSQL5.Fill(dttable5)

                Dim porcen As Decimal
                porcen = 1
                consulta25 = "INSERT INTO PRODUCTIVIDAD (USUARIO,ID_GESTION,FECHA,AÑO,MES,DIA,HORA_GESTION,CUENTA,PROCESO,PORCENTAJE)VALUES('" & dato1 & "'," & id & ",getdate()," & AÑO & "," & MES & "," & DIA & ",getdate()," & Cuenta & ", '" & proceso & "'," & porcen & ")"
                Dim adaptadorSQL25 As New SqlDataAdapter(consulta25, New SqlConnection(coneccion))
                adaptadorSQL25.Fill(dttable5)

                '******************************************************************
                TextBox1.Text = ""
                TextBox2.Text = ""
                ComboBox3.Text = ""
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
                ComboBox4.Text = ""
                TextBox21.Text = ""
                TextBox22.Text = ""
                limpiar(Me)
                TextBox1.DataBindings.Clear()
                TextBox2.DataBindings.Clear()
                ComboBox3.DataBindings.Clear()
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
                ComboBox4.DataBindings.Clear()
                TextBox21.DataBindings.Clear()
                TextBox22.DataBindings.Clear()
                ComboBox1.DataBindings.Clear()
                ComboBox2.DataBindings.Clear()
                ComboBox5.DataBindings.Clear()
                ComboBox6.DataBindings.Clear()
                ComboBox7.DataBindings.Clear()

                Me.ComboBox1.SelectedIndex = -1
                Me.ComboBox2.SelectedIndex = -1
                Me.ComboBox3.SelectedIndex = -1
                Me.ComboBox4.SelectedIndex = -1
                Me.ComboBox5.SelectedIndex = -1
                Me.ComboBox6.SelectedIndex = -1
                Me.ComboBox7.SelectedIndex = -1

                ComboBox1.Text = ""
                ComboBox2.Text = ""
                ComboBox5.Text = ""
                ComboBox6.Text = ""
                ComboBox7.Text = ""

                DateTimePicker1.Text = ""
                DateTimePicker2.Text = ""

                DateTimePicker1.DataBindings.Clear()
                DateTimePicker2.DataBindings.Clear()
                TextBox19.Text = 0
                ComboBox4.Text = 0

                Call Nuevo_Registro()

            Else
                Exit Sub
            End If
        Else
            MsgBox("Formulario habilitado para ingreso")
        End If
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        Try
            If ComboBox4.Text = "" Then
                MsgBox("Este campo no puede quedar vacio")
                ComboBox4.BackColor = Color.Red
                ComboBox4.ForeColor = Color.White
            Else
                If ComboBox4.Text >= 4 Then
                    MsgBox("Numero de servicios invalido")
                    ComboBox4.BackColor = Color.Red
                    ComboBox4.ForeColor = Color.White
                Else
                    ComboBox4.BackColor = Color.WhiteSmoke
                    ComboBox4.ForeColor = Color.Black
                End If
            End If
        Finally
        End Try
    End Sub
    Private Sub ComboBox4_cambio(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.LostFocus
        Try
            If ComboBox4.Text = "" Then
                MsgBox("Este campo no puede quedar vacio")
                ComboBox4.BackColor = Color.Red
                ComboBox4.ForeColor = Color.White
            Else
                If ComboBox4.Text >= 4 Then
                    MsgBox("Numero de servicios invalido")
                    ComboBox4.BackColor = Color.Red
                    ComboBox4.ForeColor = Color.White
                Else
                    ComboBox4.BackColor = Color.WhiteSmoke
                    ComboBox4.ForeColor = Color.Black
                End If
            End If
        Finally
        End Try
    End Sub

    Public Sub Nuevo_Registro()
        TextBox1.DataBindings.Clear()
        TextBox2.DataBindings.Clear()
        ComboBox3.DataBindings.Clear()
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
        ComboBox4.DataBindings.Clear()
        TextBox21.DataBindings.Clear()
        TextBox22.DataBindings.Clear()
        ComboBox1.DataBindings.Clear()
        ComboBox2.DataBindings.Clear()
        ComboBox5.DataBindings.Clear()
        ComboBox6.DataBindings.Clear()
        ComboBox7.DataBindings.Clear()

        Me.ComboBox1.SelectedIndex = -1
        Me.ComboBox2.SelectedIndex = -1
        Me.ComboBox3.SelectedIndex = -1
        Me.ComboBox4.SelectedIndex = -1
        Me.ComboBox5.SelectedIndex = -1
        Me.ComboBox6.SelectedIndex = -1
        Me.ComboBox7.SelectedIndex = -1

        DateTimePicker1.DataBindings.Clear()
        DateTimePicker2.DataBindings.Clear()
        TextBox19.Text = 0
        ComboBox4.Text = 0


        Button1.Enabled = True
        Dim dttable As New DataTable
        Dim consulta2 As String

        consulta2 = "SELECT * FROM ASIG_TICKETS WHERE TIPO_RECLAMACION='Otros Procesos' ORDER BY FECHA_CREACION ASC"

        Dim adaptadorSQL As New SqlDataAdapter(consulta2, New SqlConnection(coneccion))
        adaptadorSQL.Fill(dttable)


        If adaptadorSQL.Fill(dttable) = False Then
            MsgBox("No hay mas registros asignados")
            MsgBox("Formulario habilitado para ingreso")
        Else
            TextBox1.DataBindings.Add(New Binding("Text", dttable, "Cuenta"))
            TextBox2.DataBindings.Add(New Binding("Text", dttable, "Numero_Ticket"))
            ComboBox3.DataBindings.Add(New Binding("Text", dttable, "Canal_Ingreso"))
            TextBox4.DataBindings.Add(New Binding("Text", dttable, "Usuario_Creacion"))
            DateTimePicker3.DataBindings.Add(New Binding("Text", dttable, "Fecha_Creacion"))
            TextBox6.DataBindings.Add(New Binding("Text", dttable, "SRCAUS"))
            TextBox7.DataBindings.Add(New Binding("Text", dttable, "SRREAS"))
            TextBox8.DataBindings.Add(New Binding("Text", dttable, "Motivo_Dx"))
            TextBox9.DataBindings.Add(New Binding("Text", dttable, "Codigo"))
            TextBox10.DataBindings.Add(New Binding("Text", dttable, "Nota1"))
            TextBox11.DataBindings.Add(New Binding("Text", dttable, "Nota2"))
            TextBox12.DataBindings.Add(New Binding("Text", dttable, "Nota3"))
            TextBox13.DataBindings.Add(New Binding("Text", dttable, "Nota4"))
            TextBox14.DataBindings.Add(New Binding("Text", dttable, "Nota5"))
            TextBox1.Focus()

            Dim dttable1 As New DataTable
            Dim consulta3 As String
            Dim Dato As Double

            Dato = TextBox2.Text
            consulta3 = "delete ASIG_TICKETS where Numero_Ticket = " & Dato & ""
            Dim adaptadorSQL2 As New SqlDataAdapter(consulta3, New SqlConnection(coneccion))
            adaptadorSQL2.Fill(dttable1)

        End If

        TextBox12.Text = "DESCONECTAR FISICAMENTE"
        TextBox13.Text = "ASEGURAMIENTO"

        Dim DIAACTUAL As Integer = Today.Day
        Dim MESACTUAL As Integer = Today.Month
        Dim DIA2 As String = ""
        Dim MES2 As String = ""

        If DIAACTUAL < 10 Then
            DIA2 = "0" & Today.Day
        Else
            DIA2 = Today.Day
        End If

        If MESACTUAL < 10 Then
            MES2 = "0" & Today.Month
        Else
            MES2 = Today.Month
        End If
        TextBox14.Text = Today.Year & MES2 & DIA2

    End Sub

End Class