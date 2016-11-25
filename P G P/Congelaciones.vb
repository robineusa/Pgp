Imports System.Data.SqlClient

Public Class Congelaciones
    Dim maximo As Integer = 3
    Private Sub Congelaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DateTimePicker1.MinDate = New DateTime(1985, 6, 12)
        DateTimePicker1.MaxDate = DateTime.Today
        DateTimePicker1.Format = DateTimePickerFormat.Short
        DateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd"


        Label33.Text = nombreusuario
        Dim consulta2 As String
        Dim dttable As New DataTable

        consulta2 = "SELECT * FROM ASIG_CONGELACIONES ORDER BY FECHA_CREACION asc"

        Dim adaptadorSQL As New SqlDataAdapter(consulta2, New SqlConnection(coneccion))
        adaptadorSQL.Fill(dttable)

        If adaptadorSQL.Fill(dttable) = False Then
            MsgBox("NO HAY REGISTROS DISPONIBLES")
        Else
            TextBox1.DataBindings.Add(New Binding("Text", dttable, "CUENTA"))
            ComboBox1.DataBindings.Add(New Binding("Text", dttable, "CANAL_INGRESO"))
            DateTimePicker1.DataBindings.Add(New Binding("Text", dttable, "FECHA_CREACION"))
            TextBox4.DataBindings.Add(New Binding("Text", dttable, "USUARIO_CREACION"))
            TextBox3.DataBindings.Add(New Binding("Text", dttable, "AÑO_CREACION"))
            TextBox7.DataBindings.Add(New Binding("Text", dttable, "MES_CREACION"))
            TextBox8.DataBindings.Add(New Binding("Text", dttable, "DIA_CREACION"))


            Dim dttable1 As New DataTable
            Dim consulta3 As String
            Dim Dato As Integer

            Dato = TextBox1.Text
            consulta3 = "delete ASIG_CONGELACIONES where CUENTA= " & Dato & ""

            Dim adaptadorSQL2 As New SqlDataAdapter(consulta3, New SqlConnection(coneccion))
            adaptadorSQL2.Fill(dttable1)

        End If

        Dim ID_MACROPROCESO = 3
        Dim c1 As String
        Dim dt1 As New DataTable

        c1 = "SELECT NOMBRE_SUB_PROCESO FROM SUB_PROCESOS WHERE ID_MACROPROCESO =" & ID_MACROPROCESO & ""
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt1)

        Dim i As Integer

        For i = 0 To dt1.Rows.Count - 1
            ComboBox5.Items.Add(dt1.Rows(i).Item("NOMBRE_SUB_PROCESO"))
        Next


    End Sub
    Private Sub Cerrar_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If TextBox1.Text = "" Then

        Else
            Dim c2 As String
            Dim dt2 As New DataTable
            Dim Cuenta As Double = TextBox1.Text
            Dim Fecha_Creacion As String = DateTimePicker1.Text
            Dim Canal_Ingreso As String = ComboBox1.Text
            Dim Usuario_Creacion As String = TextBox4.Text

            Dim AÑO_CREACION As Integer = TextBox3.Text
            Dim MES_CREACION As Integer = TextBox7.Text
            Dim DIA_CREACION As Integer = TextBox8.Text

            If (MsgBox("Recuerde que al cerrar el formulario el registro no va a ser gestionado.", MsgBoxStyle.OkOnly, "Devolucion de Registros")) = MsgBoxResult.Ok Then
                c2 = "INSERT INTO ASIG_CONGELACIONES (CUENTA,CANAL_INGRESO,FECHA_CREACION,AÑO_CREACION,MES_CREACION,DIA_CREACION,USUARIO_CREACION)VALUES(" & Cuenta & ",'" & Canal_Ingreso & "','" & Fecha_Creacion & "'," & AÑO_CREACION & "," & MES_CREACION & "," & DIA_CREACION & ",'" & Usuario_Creacion & "')"
                Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
                adaptadorsql2.Fill(dt2)
                MsgBox("Se Devolvio el Registro a la Base")
            Else
                c2 = ""

                Exit Sub
            End If
        End If


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dttable4, dttable5, dttable25 As New DataTable
        Dim consulta4, consulta5, consulta25 As String

        Dim Cuenta As Double = TextBox1.Text
        Dim Ingreso As String = ComboBox1.Text
        Dim Servicios As String = ComboBox2.Text
        Dim Motivo As String = ComboBox3.Text
        Dim Fecha_Creacion As String = DateTimePicker1.Text
        Dim Usuario_Creacion As String = TextBox4.Text
        Dim Mes_Congelar As String = ComboBox4.Text
        Dim Gestion As String = ComboBox5.Text
        Dim Sub_Razon As String = ComboBox6.Text
        Dim Estado As String = ComboBox8.Text
        Dim Motivo_Estado As String = ComboBox9.Text
        Dim Usuaio_Aplico_E4 As String = TextBox5.Text
        Dim Servicios_Dx As Integer = ComboBox10.Text
        Dim Observaciones As String = TextBox6.Text
        Dim AJUSTE As String = ComboBox11.Text
        Dim usuario As String = ""
        Dim dt10 As New DataTable
        Dim c1 As String

        Dim AÑO_CREA As Integer = TextBox3.Text
        Dim MES_CREA As Integer = TextBox7.Text
        Dim DIA_CREA As Integer = TextBox8.Text


        c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt10)
        Dim i As Integer

        For i = 0 To dt10.Rows.Count - 1
            usuario = dt10.Rows(i).Item("Usuario")
        Next

        If (MsgBox("Desea guardar registro?", MsgBoxStyle.YesNo, "Guardar")) = MsgBoxResult.Yes Then

            Dim id As Integer = 3
            Dim proceso As String = "Congelaciones"

            consulta4 = "INSERT INTO CONGELACIONES(FECHA_GESTION,AÑO_GESTION,MES_GESTION,DIA_GESTION,HORA_GESTION,USUARIO,CANAL_INGRESO,FECHA_CREACION,AÑO_CREACION,MES_CREACION,DIA_CREACION,CUENTA,SERVICIOS,MOTIVO_E4,USUARIO_E4,MES_CONGELAR,GESTION,SUB_RAZON,ESTADO,MOTIVO_ESTADO,USUARIO_APLICO_E4,AJUSTE,SERVICIOS_DX,OBSERVACIONES)VALUES(getdate()," & AÑO & "," & MES & "," & DIA & ",getdate(),'" & usuario & "','" & Ingreso & "','" & Fecha_Creacion & "'," & AÑO_CREA & "," & MES_CREA & "," & DIA_CREA & "," & Cuenta & ",'" & Servicios & "','" & Motivo & "','" & Usuario_Creacion & "','" & Mes_Congelar & "','" & Gestion & "','" & Sub_Razon & "','" & Estado & "','" & Motivo_Estado & "','" & Usuaio_Aplico_E4 & "','" & AJUSTE & "', " & Servicios_Dx & ",'" & Observaciones & "')"
            Dim adaptadorSQL4 As New SqlDataAdapter(consulta4, New SqlConnection(coneccion))
            adaptadorSQL4.Fill(dttable4)

            consulta5 = "INSERT INTO CONSOLIDADO(ID_GESTION,CUENTA,CANAL_INGRESO,FECHA_CREACION,PROCESO,GESTION,SUB_RAZON,SERVICIOS_DX,FECHA_GESTION,AÑO_GESTION,MES_GESTION,DIA_GESTION,HORA_GESTION,USUARIO,OBSERVACIONES) VALUES(" & id & ", " & Cuenta & ",'" & Ingreso & "','" & Fecha_Creacion & "','" & proceso & "','" & Gestion & "','" & Sub_Razon & "'," & Servicios_Dx & ",getdate()," & AÑO & "," & MES & "," & DIA & ",getdate(), '" & usuario & "','" & Observaciones & "')"
            Dim adaptadorSQL5 As New SqlDataAdapter(consulta5, New SqlConnection(coneccion))
            adaptadorSQL5.Fill(dttable5)

            Dim porcen As Decimal
            porcen = 1
            consulta25 = "INSERT INTO PRODUCTIVIDAD (USUARIO,ID_GESTION,FECHA,AÑO,MES,DIA,HORA_GESTION,CUENTA,PROCESO,PORCENTAJE)VALUES('" & usuario & "'," & id & ",getdate()," & AÑO & "," & MES & "," & DIA & ",getdate()," & Cuenta & ", '" & proceso & "'," & porcen & ")"
            Dim adaptadorSQL25 As New SqlDataAdapter(consulta25, New SqlConnection(coneccion))
            adaptadorSQL25.Fill(dttable5)

            '******************************************************************
            TextBox1.Text = ""
            ComboBox1.Text = ""
            DateTimePicker1.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox3.Text = ""
            TextBox7.Text = ""
            TextBox8.Text = ""

            TextBox1.DataBindings.Clear()
            ComboBox1.DataBindings.Clear()
            DateTimePicker1.DataBindings.Clear()
            TextBox4.DataBindings.Clear()
            TextBox5.DataBindings.Clear()
            TextBox6.DataBindings.Clear()
            TextBox3.DataBindings.Clear()
            TextBox7.DataBindings.Clear()
            TextBox8.DataBindings.Clear()

            ComboBox2.DataBindings.Clear()
            ComboBox3.DataBindings.Clear()
            ComboBox4.DataBindings.Clear()
            ComboBox5.DataBindings.Clear()
            ComboBox6.DataBindings.Clear()
            ComboBox8.DataBindings.Clear()
            ComboBox9.DataBindings.Clear()
            ComboBox10.DataBindings.Clear()
            ComboBox11.DataBindings.Clear()

            ComboBox1.Refresh()
            ComboBox2.Refresh()
            ComboBox3.Refresh()
            ComboBox4.Refresh()
            ComboBox5.Refresh()
            ComboBox6.Refresh()
            ComboBox8.Refresh()
            ComboBox9.Refresh()
            ComboBox10.Refresh()
            ComboBox11.Refresh()

            Me.ComboBox1.SelectedIndex = -1
            Me.ComboBox2.SelectedIndex = -1
            Me.ComboBox3.SelectedIndex = -1
            Me.ComboBox4.SelectedIndex = -1
            Me.ComboBox5.SelectedIndex = -1
            Me.ComboBox6.SelectedIndex = -1
            Me.ComboBox8.SelectedIndex = -1
            Me.ComboBox9.SelectedIndex = -1
            Me.ComboBox10.SelectedIndex = -1
            Me.ComboBox11.SelectedIndex = -1

            ComboBox2.Text = ""
            ComboBox3.Text = ""
            ComboBox4.Text = ""
            ComboBox5.Text = ""
            ComboBox6.Text = ""
            ComboBox8.Text = ""
            ComboBox9.Text = ""
            ComboBox10.Text = ""
            ComboBox11.Text = ""

            DateTimePicker1.MinDate = New DateTime(1985, 6, 12)
            DateTimePicker1.MaxDate = DateTime.Today
            DateTimePicker1.Format = DateTimePickerFormat.Short
            DateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd"


            Dim dttable As New DataTable
            Dim consulta2 As String

            consulta2 = "SELECT * FROM ASIG_CONGELACIONES ORDER BY FECHA_CREACION asc"

            Dim adaptadorSQL As New SqlDataAdapter(consulta2, New SqlConnection(coneccion))
            adaptadorSQL.Fill(dttable)


            If adaptadorSQL.Fill(dttable) = False Then

                MsgBox("NO HAY REGISTROS DISPONIBLES")

            Else
                TextBox1.DataBindings.Add(New Binding("Text", dttable, "CUENTA"))
                ComboBox1.DataBindings.Add(New Binding("Text", dttable, "CANAL_INGRESO"))
                DateTimePicker1.DataBindings.Add(New Binding("Text", dttable, "FECHA_CREACION"))
                TextBox4.DataBindings.Add(New Binding("Text", dttable, "USUARIO_CREACION"))
                TextBox3.DataBindings.Add(New Binding("Text", dttable, "AÑO_CREACION"))
                TextBox7.DataBindings.Add(New Binding("Text", dttable, "MES_CREACION"))
                TextBox8.DataBindings.Add(New Binding("Text", dttable, "DIA_CREACION"))
                TextBox1.Focus()

                Dim dttable1 As New DataTable
                Dim consulta3 As String
                Dim Dato As Integer

                Dato = TextBox1.Text
                consulta3 = "delete ASIG_CONGELACIONES where CUENTA = " & Dato & ""

                Dim adaptadorSQL2 As New SqlDataAdapter(consulta3, New SqlConnection(coneccion))
                adaptadorSQL2.Fill(dttable1)
            End If
        Else
            consulta25 = ""
            consulta4 = ""
            consulta5 = ""

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

    Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox5.SelectedIndexChanged
        ComboBox5.DataBindings.Clear()
        ComboBox6.DataBindings.Clear()
        ComboBox6.Text = ""
        ComboBox6.Items.Clear()


        Dim c1, c2 As String
        Dim dt1, dt2 As New DataTable
        Dim sub_proceso As Integer
        Dim nombre_sub_proceso As String = ComboBox5.Text


        c2 = "SELECT ID_SUBPROCESO FROM SUB_PROCESOS WHERE NOMBRE_SUB_PROCESO like '" & nombre_sub_proceso & "'"
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
            ComboBox6.Items.Add(dt1.Rows(i).Item("NOMBRE_PROCESO"))
        Next

    End Sub
    Private Sub ComboBox10_Changed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox10.LostFocus
        Try
            If ComboBox10.Text = "" Then
                MsgBox("Este campo no puede quedar vacio")
                ComboBox10.BackColor = Color.Red
                ComboBox10.ForeColor = Color.White
            Else
                If ComboBox10.Text >= 4 Then
                    MsgBox("Numero de servicios invalido")
                    ComboBox10.BackColor = Color.Red
                    ComboBox10.ForeColor = Color.White
                Else
                    ComboBox10.BackColor = Color.WhiteSmoke
                    ComboBox10.ForeColor = Color.Black
                End If
            End If
        Finally
        End Try
    End Sub
End Class