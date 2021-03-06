﻿Imports System.Data.SqlClient

Public Class Tarifa_TRE
    Dim ID_MACROPROCESO As Integer = 8

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        ComboBox1.DataBindings.Clear()
        ComboBox2.DataBindings.Clear()
        ComboBox2.Text = ""
        ComboBox2.SelectedIndex = -1
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


    Private Sub Form24_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DateTimePicker1.MinDate = New DateTime(1985, 6, 12)
        Label12.Text = nombreusuario
        DateTimePicker1.MaxDate = DateTime.Today
        DateTimePicker1.Format = DateTimePickerFormat.Short
        DateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd"

        GroupBox1.Show()
        GroupBox2.Show()
        Button1.Show()


        ComboBox1.Text = "Seleccione una opción"
        ComboBox2.Text = "Seleccione una opción"
        ComboBox4.Text = "Seleccione una opción"


        TextBox3.Text = 0
        ComboBox6.Text = 0
        TextBox5.Text = "Sin Observacion"


        limpiar(Me)

        Dim c1 As String
        Dim dt11 As New DataTable

        c1 = "SELECT NOMBRE_SUB_PROCESO FROM SUB_PROCESOS WHERE ID_MACROPROCESO =" & ID_MACROPROCESO & ""
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt11)

        Dim i As Integer

        For i = 0 To dt11.Rows.Count - 1
            ComboBox1.Items.Add(dt11.Rows(i).Item("NOMBRE_SUB_PROCESO"))
        Next

        Dim dt1 As New DataTable
        Dim dom As String = Label12.Text


        Label12.Text = nombreusuario

        Dim dttable As New DataTable
        Dim consulta2 As String

        consulta2 = "SELECT * FROM ASIG_TARIFA_TRE"

        Dim adaptadorSQL As New SqlDataAdapter(consulta2, New SqlConnection(coneccion))
        adaptadorSQL.Fill(dttable)

        If adaptadorSQL.Fill(dttable) = False Then
            GroupBox1.Hide()
            GroupBox2.Hide()
            Label4.Hide()
            Button1.Hide()
            MsgBox("NO HAY REGISTROS DISPONIBLES")

        Else
            TextBox1.DataBindings.Add(New Binding("Text", dttable, "CUENTA"))
            ComboBox5.DataBindings.Add(New Binding("Text", dttable, "CANAL_INGRESO"))
            DateTimePicker1.DataBindings.Add(New Binding("Text", dttable, "FECHA_CREACION"))

            Dim dttable1 As New DataTable
            Dim consulta3 As String
            Dim Dato As Double

            Dato = TextBox1.Text
            consulta3 = "DELETE ASIG_TARIFA_TRE WHERE CUENTA = " & Dato & ""

            Dim adaptadorSQL2 As New SqlDataAdapter(consulta3, New SqlConnection(coneccion))
            adaptadorSQL2.Fill(dttable1)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim dttable4, dttable5, dttable25 As New DataTable
            Dim consulta4, consulta5, consulta25 As String
            Dim Cuenta As Double = TextBox1.Text
            Dim dato1 As String = ""
            Dim dt10 As New DataTable
            Dim c1 As String
            Dim Gestion As String = ComboBox1.Text
            Dim Subrazon As String = ComboBox2.Text
            Dim Moviletter As Double = TextBox3.Text
            Dim Ajuste As String = ComboBox4.Text
            Dim Serviciosdx As Integer = ComboBox6.Text
            Dim Observaciones As String = TextBox5.Text
            Dim proceso As String
            Dim FECHA_CREACION As String = DateTimePicker1.Text
            Dim CANAL_INGRESO As String = ComboBox5.Text

            c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
            Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
            adaptadorsql1.Fill(dt10)
            Dim i As Integer

            For i = 0 To dt10.Rows.Count - 1
                dato1 = dt10.Rows(i).Item("Usuario")
            Next


            If (MsgBox("Desea Guardar Registro?", MsgBoxStyle.YesNo, "Guardar")) = MsgBoxResult.Yes Then
                consulta4 = "INSERT INTO TARIFA_TRE(Usuario,Fecha_Gestion,AÑO_GESTION,MES_GESTION,DIA_GESTION,Hora_Gestion,Cuenta,FECHA_CREACION,CANAL_INGRESO,Gestion,Razon,Movie_Letter,Ajuste,Cant_Servicios,Observaciones)values('" & dato1 & "',getdate()," & AÑO & "," & MES & "," & DIA & ",getdate()," & Cuenta & ",'" & FECHA_CREACION & "','" & CANAL_INGRESO & "','" & Gestion & "','" & Subrazon & "'," & Moviletter & ",'" & Ajuste & "'," & Serviciosdx & ",'" & Observaciones & "')"
                Dim adaptadorSQL4 As New SqlDataAdapter(consulta4, New SqlConnection(coneccion))
                adaptadorSQL4.Fill(dttable4)

                Dim id As Integer = 7

                proceso = "Solicitudes Cambio Tarifa TRE"

                consulta5 = "INSERT INTO CONSOLIDADO(ID_GESTION,CUENTA,CANAL_INGRESO,FECHA_CREACION,PROCESO,GESTION,SUB_RAZON,SERVICIOS_DX,FECHA_GESTION,AÑO_GESTION,MES_GESTION,DIA_GESTION,HORA_GESTION,USUARIO,OBSERVACIONES) VALUES(" & id & ", " & Cuenta & ",'" & CANAL_INGRESO & "','" & FECHA_CREACION & "','" & proceso & "','" & Gestion & "','" & Subrazon & "'," & Serviciosdx & ",getdate()," & AÑO & "," & MES & "," & DIA & ",getdate(), '" & dato1 & "','" & Observaciones & "')"
                Dim adaptadorSQL5 As New SqlDataAdapter(consulta5, New SqlConnection(coneccion))
                adaptadorSQL5.Fill(dttable5)

                Dim porcen As Integer
                porcen = 1.2
                consulta25 = "INSERT INTO PRODUCTIVIDAD (USUARIO,ID_GESTION,FECHA,AÑO,MES,DIA,HORA_GESTION,CUENTA,PROCESO,PORCENTAJE)VALUES('" & dato1 & "'," & id & ",getdate()," & AÑO & "," & MES & "," & DIA & ",getdate()," & Cuenta & ", '" & proceso & "'," & porcen & ")"
                Dim adaptadorSQL25 As New SqlDataAdapter(consulta25, New SqlConnection(coneccion))
                adaptadorSQL25.Fill(dttable5)

                '******************************************************************
                TextBox1.Text = ""
                TextBox3.Text = ""
                ComboBox6.Text = ""
                limpiar(Me)
                DataBindings.Clear()
                TextBox1.DataBindings.Clear()
                TextBox3.DataBindings.Clear()
                ComboBox6.DataBindings.Clear()

                ComboBox1.DataBindings.Clear()
                ComboBox2.DataBindings.Clear()
                ComboBox4.DataBindings.Clear()
                ComboBox5.DataBindings.Clear()

                Me.ComboBox1.SelectedIndex = -1
                Me.ComboBox2.SelectedIndex = -1
                Me.ComboBox4.SelectedIndex = -1
                Me.ComboBox5.SelectedIndex = -1
                Me.ComboBox6.SelectedIndex = -1


                ComboBox1.Text = ""
                ComboBox2.Text = ""
                ComboBox4.Text = ""
                ComboBox5.Text = ""

                DateTimePicker1.Text = ""
                ComboBox2.Text = "Seleccione una opción"
                ComboBox2.Text = "Seleccione una opción"
                ComboBox4.Text = "Seleccione una opción"
                TextBox3.Text = 0
                ComboBox6.Text = 0
                TextBox5.Text = "Sin Observacion"

                TextBox1.DataBindings.Clear()
                ComboBox5.DataBindings.Clear()
                DateTimePicker1.DataBindings.Clear()


                Dim dttable As New DataTable
                Dim consulta2 As String

                consulta2 = "SELECT * FROM ASIG_TARIFA_TRE"

                Dim adaptadorSQL As New SqlDataAdapter(consulta2, New SqlConnection(coneccion))
                adaptadorSQL.Fill(dttable)


                If adaptadorSQL.Fill(dttable) = False Then

                    GroupBox1.Hide()
                    GroupBox2.Hide()
                    Button1.Hide()
                    MsgBox("NO HAY REGISTROS DISPONIBLES")

                Else
                    TextBox1.DataBindings.Add(New Binding("Text", dttable, "CUENTA"))
                    ComboBox5.DataBindings.Add(New Binding("Text", dttable, "CANAL_INGRESO"))
                    DateTimePicker1.DataBindings.Add(New Binding("Text", dttable, "FECHA_CREACION"))

                    TextBox1.Focus()

                    Dim dttable1 As New DataTable
                    Dim consulta3 As String
                    Dim Dato As Double

                    Dato = TextBox1.Text
                    consulta3 = "DELETE ASIG_TARIFA_TRE WHERE CUENTA = " & Dato & ""
                    Dim adaptadorSQL2 As New SqlDataAdapter(consulta3, New SqlConnection(coneccion))
                    adaptadorSQL2.Fill(dttable1)
                End If
            Else
                consulta25 = ""
                consulta4 = ""
                consulta5 = ""

            End If
        Finally
        End Try

    End Sub
    Private Sub Cerrar_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If TextBox1.Text <> "" Then


            Dim c2 As String
            Dim dt2 As New DataTable
            Dim Cuenta As Double = TextBox1.Text
            Dim FECHA_CREACION As String = DateTimePicker1.Text
            Dim CANAL_INGRESO As String = ComboBox5.Text

            If (MsgBox("Recuerde que al cerrar el formulario el registro no va a ser gestionado.", MsgBoxStyle.OkOnly, "Devolucion de Registros")) = MsgBoxResult.Ok Then
                c2 = "Insert into ASIG_TARIFA_TRE(CUENTA,CANAL_INGRESO,FECHA_CREACION)Values(" & Cuenta & ",'" & CANAL_INGRESO & "','" & FECHA_CREACION & "')"
                Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
                adaptadorsql2.Fill(dt2)
                MsgBox("Se Devolvio el Registro a la Base")
            Else
                c2 = ""
                Exit Sub
            End If
        Else
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

    Private Sub ComboBox6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox6.LostFocus
        Try
            If ComboBox6.Text = "" Then
                MsgBox("Este campo no puede quedar vacio")
                ComboBox6.BackColor = Color.Red
                ComboBox6.ForeColor = Color.White
            Else
                If ComboBox6.Text >= 4 Then
                    MsgBox("Numero de servicios invalido")
                    ComboBox6.BackColor = Color.Red
                    ComboBox6.ForeColor = Color.White
                Else
                    ComboBox6.BackColor = Color.WhiteSmoke
                    ComboBox6.ForeColor = Color.Black
                End If
            End If
        Finally
        End Try
    End Sub

    Private Sub ComboBox6_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox6.SelectedIndexChanged
        Try
            If ComboBox6.Text = "" Then
                MsgBox("Este campo no puede quedar vacio")
                ComboBox6.BackColor = Color.Red
                ComboBox6.ForeColor = Color.White
            Else
                If ComboBox6.Text >= 4 Then
                    MsgBox("Numero de servicios invalido")
                    ComboBox6.BackColor = Color.Red
                    ComboBox6.ForeColor = Color.White
                Else
                    ComboBox6.BackColor = Color.WhiteSmoke
                    ComboBox6.ForeColor = Color.Black
                End If
            End If
        Finally
        End Try
    End Sub
End Class