Imports System.Data.SqlClient

Public Class Tarifa_TRE_Ingreso
    Dim ID_MACROPROCESO As Integer = 8

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

                Dim id2 As Integer = 12

                consulta25 = "INSERT INTO PRODUCTIVIDAD (USUARIO,ID_GESTION,FECHA,AÑO,MES,DIA,HORA_GESTION,CUENTA,PROCESO,PORCENTAJE)VALUES('" & dato1 & "'," & id2 & ",getdate()," & AÑO & "," & MES & "," & DIA & ",getdate()," & Cuenta & ", '" & proceso & "'," & porcen & ")"
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
                ComboBox1.Text = ""
                ComboBox2.Text = ""
                ComboBox4.Text = ""
                ComboBox5.Text = ""

                Me.ComboBox1.SelectedIndex = -1
                Me.ComboBox2.SelectedIndex = -1
                Me.ComboBox4.SelectedIndex = -1
                Me.ComboBox5.SelectedIndex = -1
                Me.ComboBox6.SelectedIndex = -1


                DateTimePicker1.Text = ""
                ComboBox2.Text = ""
                ComboBox2.Text = ""
                ComboBox4.Text = ""
                TextBox3.Text = 0
                ComboBox6.Text = 0
                TextBox5.Text = "Sin Observacion"
            Else

            End If

       Finally
        End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Cuenta_escalamiento = TextBox1.Text
        Escalamientos_anterior.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Cuenta_hallazgos = TextBox1.Text
        Hallazgos.Show()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

        TextBox3.Text = ""
        ComboBox6.Text = ""

        DateTimePicker1.DataBindings.Clear()
        TextBox1.DataBindings.Clear()
        TextBox3.DataBindings.Clear()
        ComboBox6.DataBindings.Clear()
        TextBox5.DataBindings.Clear()

        ComboBox1.DataBindings.Clear()
        ComboBox2.DataBindings.Clear()
        ComboBox4.DataBindings.Clear()
        ComboBox5.DataBindings.Clear()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox4.Text = ""
        ComboBox5.Text = ""

        DateTimePicker1.Text = Today
        ComboBox2.Text = ""
        ComboBox2.Text = ""
        ComboBox4.Text = ""
        TextBox3.Text = 0
        ComboBox6.Text = 0
        TextBox5.Text = ""

        If TextBox1.Text <> "" Then

            Dim CUENTA As Double = TextBox1.Text
            Dim consulta2 As String
            Dim dttable As New DataTable


            consulta2 = "SELECT * FROM TARIFA_TRE WHERE CUENTA = " & CUENTA & " AND MES_GESTION=" & MES & ""

            Dim adaptadorSQL As New SqlDataAdapter(consulta2, New SqlConnection(coneccion))
            adaptadorSQL.Fill(dttable)

            DateTimePicker1.DataBindings.Add(New Binding("Text", dttable, "FECHA_CREACION"))
            ComboBox5.DataBindings.Add(New Binding("Text", dttable, "CANAL_INGRESO"))
            ComboBox1.DataBindings.Add(New Binding("Text", dttable, "GESTION"))
            ComboBox2.DataBindings.Add(New Binding("Text", dttable, "RAZON"))
            TextBox3.DataBindings.Add(New Binding("Text", dttable, "MOVIE_LETTER"))
            ComboBox4.DataBindings.Add(New Binding("Text", dttable, "AJUSTE"))
            ComboBox6.DataBindings.Add(New Binding("Text", dttable, "CANT_SERVICIOS"))
            TextBox5.DataBindings.Add(New Binding("Text", dttable, "OBSERVACIONES"))
        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
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

        If (MsgBox("Desea Actualizar el Registro?", MsgBoxStyle.YesNo, "Actualizar")) = MsgBoxResult.Yes Then
            consulta4 = "UPDATE  TARIFA_TRE SET FECHA_CREACION='" & FECHA_CREACION & "',CANAL_INGRESO='" & CANAL_INGRESO & "',Gestion='" & Gestion & "',Razon='" & Subrazon & "',Movie_Letter=" & Moviletter & ",Ajuste='" & Ajuste & "',Cant_Servicios=" & Serviciosdx & ",Observaciones='" & Observaciones & "' WHERE CUENTA=" & Cuenta & " AND MES_GESTION=" & MES & ""
            Dim adaptadorSQL4 As New SqlDataAdapter(consulta4, New SqlConnection(coneccion))
            adaptadorSQL4.Fill(dttable4)

            Dim id As Integer = 7

            proceso = "Solicitudes Cambio Tarifa TRE"

            consulta5 = "UPDATE CONSOLIDADO SET CANAL_INGRESO='" & CANAL_INGRESO & "',GESTION='" & Gestion & "',SUB_RAZON='" & Subrazon & "',SERVICIOS_DX=" & Serviciosdx & " WHERE CUENTA=" & Cuenta & " AND FECHA_CREACION='" & FECHA_CREACION & "' AND ID_GESTION=" & id & ""
            Dim adaptadorSQL5 As New SqlDataAdapter(consulta5, New SqlConnection(coneccion))
            adaptadorSQL5.Fill(dttable5)

            Dim porcen As Integer
            porcen = 1.2
            consulta25 = "INSERT INTO PRODUCTIVIDAD (USUARIO,ID_GESTION,FECHA,AÑO,MES,DIA,HORA_GESTION,CUENTA,PROCESO,PORCENTAJE)VALUES('" & dato1 & "'," & id & ",getdate()," & AÑO & "," & MES & "," & DIA & ",getdate()," & Cuenta & ", '" & proceso & "'," & porcen & ")"
            Dim adaptadorSQL25 As New SqlDataAdapter(consulta25, New SqlConnection(coneccion))
            adaptadorSQL25.Fill(dttable5)
            MsgBox("Registro Actualizado")

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
            ComboBox1.Text = ""
            ComboBox2.Text = ""
            ComboBox4.Text = ""
            ComboBox5.Text = ""

            Me.ComboBox1.SelectedIndex = -1
            Me.ComboBox2.SelectedIndex = -1
            Me.ComboBox4.SelectedIndex = -1
            Me.ComboBox5.SelectedIndex = -1
            Me.ComboBox6.SelectedIndex = -1


            DateTimePicker1.Text = ""
            ComboBox2.Text = ""
            ComboBox2.Text = ""
            ComboBox4.Text = ""
            TextBox3.Text = 0
            ComboBox6.Text = 0
            TextBox5.Text = "Sin Observacion"

        End If


    End Sub

    Private Sub Tarifa_TRE_Ingreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GroupBox1.Show()
        GroupBox2.Show()
        Button1.Show()
        ComboBox6.Text = 0

        DateTimePicker1.MinDate = New DateTime(1985, 6, 12)
        DateTimePicker1.MaxDate = DateTime.Today
        DateTimePicker1.Format = DateTimePickerFormat.Short
        DateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd"

        Dim c1 As String
        Dim dt1 As New DataTable

        c1 = "SELECT NOMBRE_SUB_PROCESO FROM SUB_PROCESOS WHERE ID_MACROPROCESO =" & ID_MACROPROCESO & ""
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt1)

        Dim i As Integer

        For i = 0 To dt1.Rows.Count - 1
            ComboBox1.Items.Add(dt1.Rows(i).Item("NOMBRE_SUB_PROCESO"))
        Next


    End Sub

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
    Private Sub ComboBox5_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox5.LostFocus
        Try
            If ComboBox5.Text = "" Then
                MsgBox("Este campo no puede quedar vacio")
                ComboBox5.BackColor = Color.Red
                ComboBox5.ForeColor = Color.White
                Exit Sub
            Else
                ComboBox5.BackColor = Color.WhiteSmoke
                ComboBox5.ForeColor = Color.Black
            End If
        Finally
        End Try
    End Sub
End Class