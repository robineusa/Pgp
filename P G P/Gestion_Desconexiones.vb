Imports System.Data.SqlClient

Public Class Gestion_Desconexiones


    Private Sub Gestion_Desconexiones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.MaxDate = DateTime.Today
        DateTimePicker1.Format = DateTimePickerFormat.Short
        DateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd"

        DateTimePicker2.MaxDate = DateTime.Today
        DateTimePicker2.Format = DateTimePickerFormat.Short
        DateTimePicker2.CustomFormat = "MMMM dd, yyyy - dddd"

        DateTimePicker3.MaxDate = DateTime.Today
        DateTimePicker3.Format = DateTimePickerFormat.Short
        DateTimePicker3.CustomFormat = "MMMM dd, yyyy - dddd"

        DateTimePicker4.MaxDate = DateTime.Today
        DateTimePicker4.Format = DateTimePickerFormat.Short
        DateTimePicker4.CustomFormat = "MMMM dd, yyyy - dddd"

        DateTimePicker5.MaxDate = DateTime.Today
        DateTimePicker5.Format = DateTimePickerFormat.Short
        DateTimePicker5.CustomFormat = "MMMM dd, yyyy - dddd"

        GroupBox5.Hide()
        GroupBox6.Hide()

        TextBox1.DataBindings.Clear()
        TextBox2.DataBindings.Clear()
        TextBox3.DataBindings.Clear()
        TextBox4.DataBindings.Clear()
        TextBox5.DataBindings.Clear()
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
        DateTimePicker1.DataBindings.Clear()
        DateTimePicker2.DataBindings.Clear()
        DateTimePicker3.DataBindings.Clear()
        DateTimePicker4.DataBindings.Clear()
        DateTimePicker5.DataBindings.Clear()


        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""
        TextBox13.Text = ""
        TextBox14.Text = ""
        TextBox15.Text = ""
        TextBox16.Text = ""
        TextBox17.Text = ""

        DateTimePicker1.Text = ""
        DateTimePicker2.Text = ""
        DateTimePicker3.Text = ""
        DateTimePicker4.Text = ""
        DateTimePicker5.Text = ""

        Me.ComboBox1.SelectedIndex = -1
        Me.ComboBox2.SelectedIndex = -1
        Me.ComboBox3.SelectedIndex = -1
        Me.ComboBox4.SelectedIndex = -1
        Me.ComboBox5.SelectedIndex = -1
        Me.ComboBox6.SelectedIndex = -1
        Me.ComboBox7.SelectedIndex = -1
        Me.ComboBox8.SelectedIndex = -1
        Me.ComboBox9.SelectedIndex = -1

        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
        ComboBox5.Text = ""
        ComboBox6.Text = ""
        ComboBox7.Text = ""
        ComboBox8.Text = ""
        ComboBox9.Text = ""
        TextBox12.Text = ""
        TextBox14.Text = 0
        ComboBox3.Text = "No"
        ComboBox5.Text = "No"
        TextBox15.Text = "Sin Observaciones"


        Label35.Text = nombreusuario


        Dim dttable As New DataTable
        Dim consulta2 As String

        consulta2 = "SELECT * FROM ASIG_DESCONEXIONES order by DIA_DX ASC,FECHA_PREAVISO ASC,SERVICIOS ASC,MOTIVO_DX ASC"

        Dim adaptadorSQL As New SqlDataAdapter(consulta2, New SqlConnection(coneccion))
        adaptadorSQL.Fill(dttable)

        If adaptadorSQL.Fill(dttable) = False Then
            MsgBox("NO HAY REGISTROS DISPONIBLES")

        Else
            TextBox1.DataBindings.Add(New Binding("Text", dttable, "CUENTA"))
            TextBox3.DataBindings.Add(New Binding("Text", dttable, "MOTIVO_DX"))
            TextBox4.DataBindings.Add(New Binding("Text", dttable, "CODIGO"))
            TextBox9.DataBindings.Add(New Binding("Text", dttable, "NOTA1"))
            TextBox10.DataBindings.Add(New Binding("Text", dttable, "NOTA2"))
            TextBox11.DataBindings.Add(New Binding("Text", dttable, "NOTA3"))
            TextBox12.DataBindings.Add(New Binding("Text", dttable, "NOTA4"))
            TextBox13.DataBindings.Add(New Binding("Text", dttable, "NOTA5"))
            TextBox6.DataBindings.Add(New Binding("Text", dttable, "RED"))
            TextBox5.DataBindings.Add(New Binding("Text", dttable, "SERVICIOS"))
            DateTimePicker1.DataBindings.Add(New Binding("Text", dttable, "FECHA_SOLICITUD"))
            DateTimePicker2.DataBindings.Add(New Binding("Text", dttable, "FECHA_CORTE"))
            DateTimePicker3.DataBindings.Add(New Binding("Text", dttable, "FECHA_PREAVISO"))
            TextBox7.DataBindings.Add(New Binding("Text", dttable, "DIA_DX"))
            TextBox8.DataBindings.Add(New Binding("Text", dttable, "TARIFA_ANTERIOR"))
            TextBox2.DataBindings.Add(New Binding("Text", dttable, "CANAL_INGRESO"))

            TextBox1.Focus()
            TextBox1.SelectAll()

            Dim dttable1 As New DataTable
            Dim consulta3 As String
            Dim Dato As Integer

            Dato = TextBox1.Text

            consulta3 = "delete ASIG_DESCONEXIONES where CUENTA = " & Dato & ""

            Dim adaptadorSQL2 As New SqlDataAdapter(consulta3, New SqlConnection(coneccion))
            adaptadorSQL2.Fill(dttable1)

        End If

        TextBox1.Focus()
        TextBox1.SelectAll()

        Dim ID_MACROPROCESO = 4
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
    Private Sub Cerrar_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If TextBox2.Text <> "" Then

            Dim c2 As String
            Dim dt2 As New DataTable
            Dim Cuenta As Double = TextBox1.Text
            Dim Motivo_Dx As String = TextBox3.Text
            Dim Codigo As String = TextBox4.Text
            Dim Nota1 As String = TextBox9.Text
            Dim Nota2 As String = TextBox10.Text
            Dim Nota3 As String = TextBox11.Text
            Dim Nota4 As String = TextBox12.Text
            Dim Nota5 As String = TextBox13.Text
            Dim Red As String = TextBox6.Text
            Dim Servicios As String = TextBox5.Text
            Dim Fecha_Sol As String = DateTimePicker1.Text
            Dim Fecha_Corte As String = DateTimePicker2.Text
            Dim Fecha_Preav As String = DateTimePicker3.Text
            Dim Dia_DX As Integer = TextBox7.Text
            Dim tarifa_anterior As String = TextBox8.Text
            Dim CANAL_INGRESO As String = TextBox2.Text


            If (MsgBox("Recuerde que al cerrar el formulario el registro no va a ser gestionado.", MsgBoxStyle.OkOnly, "Devolucion de Registros")) = MsgBoxResult.Ok Then
                c2 = "INSERT INTO ASIG_DESCONEXIONES(CUENTA,CANAL_INGRESO ,MOTIVO_DX,CODIGO,NOTA1,NOTA2,NOTA3,NOTA4,NOTA5,RED,SERVICIOS,FECHA_SOLICITUD,FECHA_CORTE,FECHA_PREAVISO,DIA_DX,TARIFA_ANTERIOR) VALUES(" & Cuenta & ",'" & CANAL_INGRESO & "','" & Motivo_Dx & "','" & Codigo & "','" & Nota1 & "','" & Nota2 & "','" & Nota3 & "','" & Nota4 & "','" & Nota5 & "','" & Red & "','" & Servicios & "','" & Fecha_Sol & "','" & Fecha_Corte & "','" & Fecha_Preav & "'," & Dia_DX & ",'" & tarifa_anterior & "')"
                Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
                adaptadorsql2.Fill(dt2)
                MsgBox("Se Devolvio el Registro a la Base")
            Else
                c2 = ""

                Exit Sub


            End If
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            Dim dttable4, dttable5, dttable25 As New DataTable
            Dim consulta4, consulta5, consulta25 As String

            Dim Cuenta As Double = TextBox1.Text
            Dim Motivo_Dx As String = TextBox3.Text
            Dim Codigo As String = TextBox4.Text
            Dim Nota1 As String = TextBox9.Text
            Dim Nota2 As String = TextBox10.Text
            Dim Nota3 As String = TextBox11.Text
            Dim Nota4 As String = TextBox12.Text
            Dim Nota5 As Double = TextBox13.Text
            Dim Red As String = TextBox4.Text
            Dim Servicios As String = TextBox5.Text
            Dim Fecha_Sol As String = DateTimePicker1.Text
            Dim Fecha_Corte As String = DateTimePicker2.Text
            Dim Fecha_Preav As String = DateTimePicker3.Text
            Dim Dia_DX As Integer = TextBox7.Text
            Dim tarifa_anterior As String = TextBox8.Text
            Dim Gestion As String = ComboBox1.Text
            Dim Subrazon As String = ComboBox2.Text
            Dim Movie As Double = TextBox14.Text
            Dim Ajuste As String = ComboBox3.Text
            Dim Cant_serv As Integer = ComboBox4.Text
            Dim Observ As String = TextBox15.Text
            Dim proceso_retencion As String = ComboBox5.Text
            Dim CANAL_INGRESO As String = TextBox2.Text
            Dim fecha_dos As String = Now
            Dim USUARIO_CAN As String = TextBox16.Text
            Dim USUARIO_RETE As String = TextBox17.Text
            Dim FECHA_CANCELACION As String = DateTimePicker4.Text
            Dim FECHA_RETENCION As String = DateTimePicker5.Text
            Dim MOTIVO_DE_CANCELACION As String = ComboBox6.Text
            Dim MARCACION_RETE As String = ComboBox7.Text
            Dim SERVICIO_A_CAN As String = ComboBox8.Text
            Dim SERVICIO_ACTUAL As String = ComboBox9.Text

            Dim usuario As String = ""
            Dim dt10 As New DataTable
            Dim c1 As String

            c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
            Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
            adaptadorsql1.Fill(dt10)
            Dim i As Integer

            For i = 0 To dt10.Rows.Count - 1
                usuario = dt10.Rows(i).Item("Usuario")
            Next

            If (MsgBox("Desea Guardar Registro?", MsgBoxStyle.YesNo, "Guardar")) = MsgBoxResult.Yes Then
                consulta4 = "INSERT INTO DESCONEXIONES (USUARIO_GESTION,FECHA_GESTION ,AÑO_GESTION,MES_GESTION,DIA_GESTION,HORA_GESTION,CANAL_INGRESO,CUENTA ,MOTIVO_CANCELACION ,CODIGO ,NOTA1 ,NOTA2 ,NOTA3 ,NOTA4 ,NOTA5 ,RED ,SERVICIOS,FECHA_SOLICITUD ,FECHA_CORTE ,FECHA_PREAVISO ,DIA_DX ,TARIFA_ANTERIOR,GESTION ,RAZON,USUARIO_CANCELACION,USUARIO_RETENCION,FECHA_CANCELACION,FECHA_RETENCION,MOTIVO_DESCONEXION,MARCACION_RETENCION,SERVICIO_A_CANCELAR,SERVICIO_ACTUAL,MOVIE_LETTER ,AJUSTE ,CANTIDAD_SERVICIOS,PROCESO_RETENCION,OBSERVACIONES) Values('" & usuario & "',getdate()," & AÑO & " ," & MES & "," & DIA & ",getdate(),'" & CANAL_INGRESO & "'," & Cuenta & ",'" & Motivo_Dx & "','" & Codigo & "','" & Nota1 & "','" & Nota2 & "','" & Nota3 & "','" & Nota4 & "'," & Nota5 & ",'" & Red & "','" & Servicios & "','" & Fecha_Sol & "','" & Fecha_Corte & "','" & Fecha_Preav & "'," & Dia_DX & ",'" & tarifa_anterior & "','" & Gestion & "','" & Subrazon & "','" & USUARIO_CAN & "','" & USUARIO_RETE & "','" & FECHA_CANCELACION & "','" & FECHA_RETENCION & "','" & MOTIVO_DE_CANCELACION & "','" & MARCACION_RETE & "','" & SERVICIO_A_CAN & "','" & SERVICIO_ACTUAL & "'," & Movie & ",'" & Ajuste & "'," & Cant_serv & ",'" & proceso_retencion & "','" & Observ & "')"
                Dim adaptadorSQL4 As New SqlDataAdapter(consulta4, New SqlConnection(coneccion))
                adaptadorSQL4.Fill(dttable4)

                Dim id As Integer = 4
                Dim proceso As String = "Desconexion de Servicios"
                consulta5 = "INSERT INTO CONSOLIDADO(ID_GESTION,CUENTA,CANAL_INGRESO,FECHA_CREACION,PROCESO,GESTION,SUB_RAZON,SERVICIOS_DX,FECHA_GESTION,AÑO_GESTION,MES_GESTION,DIA_GESTION,HORA_GESTION,USUARIO,OBSERVACIONES) VALUES(" & id & ", " & Cuenta & ",'" & CANAL_INGRESO & "','" & Fecha_Sol & "','" & proceso & "','" & Gestion & "','" & Subrazon & "'," & Cant_serv & ",getdate()," & AÑO & "," & MES & "," & DIA & ",getdate(), '" & usuario & "','" & Observ & "')"
                Dim adaptadorSQL5 As New SqlDataAdapter(consulta5, New SqlConnection(coneccion))
                adaptadorSQL5.Fill(dttable5)

                Dim porcen As Decimal
                porcen = 1
                consulta25 = "INSERT INTO PRODUCTIVIDAD (USUARIO,ID_GESTION,FECHA,AÑO,MES,DIA,HORA_GESTION,CUENTA,PROCESO,PORCENTAJE)VALUES('" & usuario & "'," & id & ",getdate()," & AÑO & "," & MES & "," & DIA & ",getdate()," & Cuenta & ", '" & proceso & "'," & porcen & ")"
                Dim adaptadorSQL25 As New SqlDataAdapter(consulta25, New SqlConnection(coneccion))
                adaptadorSQL25.Fill(dttable5)

                '******************************************************************

                TextBox1.DataBindings.Clear()
                TextBox2.DataBindings.Clear()
                TextBox3.DataBindings.Clear()
                TextBox4.DataBindings.Clear()
                TextBox5.DataBindings.Clear()
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
                DateTimePicker1.DataBindings.Clear()
                DateTimePicker2.DataBindings.Clear()
                DateTimePicker3.DataBindings.Clear()
                DateTimePicker4.DataBindings.Clear()
                DateTimePicker5.DataBindings.Clear()


                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox6.Text = ""
                TextBox7.Text = ""
                TextBox8.Text = ""
                TextBox9.Text = ""
                TextBox10.Text = ""
                TextBox11.Text = ""
                TextBox12.Text = ""
                TextBox13.Text = ""
                TextBox14.Text = ""
                TextBox15.Text = ""
                TextBox16.Text = ""
                TextBox17.Text = ""

                DateTimePicker1.Text = ""
                DateTimePicker2.Text = ""
                DateTimePicker3.Text = ""
                DateTimePicker4.Text = ""
                DateTimePicker5.Text = ""

                Me.ComboBox1.SelectedIndex = -1
                Me.ComboBox2.SelectedIndex = -1
                Me.ComboBox3.SelectedIndex = -1
                Me.ComboBox4.SelectedIndex = -1
                Me.ComboBox5.SelectedIndex = -1
                Me.ComboBox6.SelectedIndex = -1
                Me.ComboBox7.SelectedIndex = -1
                Me.ComboBox8.SelectedIndex = -1
                Me.ComboBox9.SelectedIndex = -1

                ComboBox1.Text = ""
                ComboBox2.Text = ""
                ComboBox3.Text = ""
                ComboBox4.Text = ""
                ComboBox5.Text = ""
                ComboBox6.Text = ""
                ComboBox7.Text = ""
                ComboBox8.Text = ""
                ComboBox9.Text = ""
                TextBox12.Text = ""
                TextBox14.Text = 0
                ComboBox3.Text = "No"
                ComboBox5.Text = "No"
                TextBox15.Text = "Sin Observaciones"

                Dim dttable As New DataTable
                Dim consulta2 As String

                consulta2 = "SELECT * FROM ASIG_DESCONEXIONES ORDER BY DIA_DX ASC,FECHA_PREAVISO ASC,SERVICIOS ASC,MOTIVO_DX ASC"

                Dim adaptadorSQL As New SqlDataAdapter(consulta2, New SqlConnection(coneccion))
                adaptadorSQL.Fill(dttable)


                If adaptadorSQL.Fill(dttable) = False Then
                    MsgBox("NO HAY REGISTROS DISPONIBLES")
                Else
                    TextBox1.DataBindings.Add(New Binding("Text", dttable, "CUENTA"))
                    TextBox3.DataBindings.Add(New Binding("Text", dttable, "MOTIVO_DX"))
                    TextBox4.DataBindings.Add(New Binding("Text", dttable, "CODIGO"))
                    TextBox9.DataBindings.Add(New Binding("Text", dttable, "NOTA1"))
                    TextBox10.DataBindings.Add(New Binding("Text", dttable, "NOTA2"))
                    TextBox11.DataBindings.Add(New Binding("Text", dttable, "NOTA3"))
                    TextBox12.DataBindings.Add(New Binding("Text", dttable, "NOTA4"))
                    TextBox13.DataBindings.Add(New Binding("Text", dttable, "NOTA5"))
                    TextBox6.DataBindings.Add(New Binding("Text", dttable, "RED"))
                    TextBox5.DataBindings.Add(New Binding("Text", dttable, "SERVICIOS"))
                    DateTimePicker1.DataBindings.Add(New Binding("Text", dttable, "FECHA_SOLICITUD"))
                    DateTimePicker2.DataBindings.Add(New Binding("Text", dttable, "FECHA_CORTE"))
                    DateTimePicker3.DataBindings.Add(New Binding("Text", dttable, "FECHA_PREAVISO"))
                    TextBox7.DataBindings.Add(New Binding("Text", dttable, "DIA_DX"))
                    TextBox8.DataBindings.Add(New Binding("Text", dttable, "TARIFA_ANTERIOR"))
                    TextBox2.DataBindings.Add(New Binding("Text", dttable, "CANAL_INGRESO"))

                    TextBox1.Focus()

                    Dim dttable1 As New DataTable
                    Dim consulta3 As String
                    Dim Dato As Integer

                    Dato = TextBox1.Text
                    consulta3 = "DELETE ASIG_DESCONEXIONES WHERE CUENTA = " & Dato & ""

                    Dim adaptadorSQL2 As New SqlDataAdapter(consulta3, New SqlConnection(coneccion))
                    adaptadorSQL2.Fill(dttable1)
                End If
            Else
                consulta25 = ""
                consulta4 = ""
                consulta5 = ""

            End If
        Catch ex As Exception When ComboBox1.SelectedIndex = -1
            MsgBox("Debe Seleccionar una opcion" & ex.Message & vbCrLf & "Campo Gestion Vacio", MsgBoxStyle.Critical, "CUIDADO")
            ComboBox1.Focus()

        Catch ex As Exception When ComboBox2.SelectedIndex = -1
            MsgBox("Debe Seleccionar una opcion" & ex.Message & vbCrLf & "Campo Razon Vacio", MsgBoxStyle.Critical, "CUIDADO")
            ComboBox2.Focus()

        Catch ex As Exception When ComboBox3.SelectedIndex = -1
            MsgBox("Debe Seleccionar una opcion" & ex.Message & vbCrLf & "Campo Ajustes Vacio", MsgBoxStyle.Critical, "CUIDADO")
            ComboBox3.Focus()


        Catch ex As Exception When ComboBox4.SelectedIndex = -1
            MsgBox("Debe Seleccionar una opcion" & ex.Message & vbCrLf & "Campo Servicios Dx Vacio", MsgBoxStyle.Critical, "CUIDADO")
            ComboBox4.Focus()

        Catch ex As Exception When ComboBox5.SelectedIndex = -1
            MsgBox("Debe Seleccionar una opcion" & ex.Message & vbCrLf & "Campo Proceso retencion Vacio", MsgBoxStyle.Critical, "CUIDADO")
            ComboBox5.Focus()

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Cuenta_escalamiento = TextBox1.Text
        Escalamientos_anterior.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Cuenta_hallazgos = TextBox1.Text
        Hallazgos.Show()
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.LostFocus
        Try
            If ComboBox4.Text = "" Then
                MsgBox("Este campo no puede quedar vacio")
                ComboBox4.BackColor = Color.Red
                ComboBox4.ForeColor = Color.White
                ComboBox4.Focus()
            Else
                ComboBox4.BackColor = Color.WhiteSmoke
                ComboBox4.ForeColor = Color.Black
                End If
        Finally
        End Try
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.LostFocus
        GroupBox5.Hide()
        GroupBox6.Hide()
        ComboBox8.Enabled = True
        ComboBox9.Enabled = True
        ComboBox8.Visible = True
        ComboBox9.Visible = True
        ComboBox6.Enabled = True
        ComboBox6.Text = ""
        ComboBox7.Text = ""
        ComboBox8.Text = ""
        ComboBox9.Text = ""
        Label30.Visible = True
        Label31.Visible = True
        TextBox16.DataBindings.Clear()
        TextBox17.DataBindings.Clear()
        TextBox16.Text = ""
        TextBox17.Text = ""
        Me.ComboBox6.SelectedIndex = -1
        Me.ComboBox7.SelectedIndex = -1
        Me.ComboBox8.SelectedIndex = -1
        Me.ComboBox9.SelectedIndex = -1

        Try
            If ComboBox2.Text = "Se desconecta cuenta activa sin servicios" Then
                GroupBox5.Show()
                Dim usuario As String = ""
                Dim dt10 As New DataTable
                Dim c1 As String

                c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
                Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
                adaptadorsql1.Fill(dt10)
                Dim i As Integer

                For i = 0 To dt10.Rows.Count - 1
                    usuario = dt10.Rows(i).Item("Usuario")
                Next
                Dim motivo As String = TextBox3.Text
                ComboBox6.SelectedItem = motivo
                DateTimePicker4.Value = Today

                TextBox16.Text = usuario
                ComboBox8.Enabled = False
                ComboBox9.Enabled = False
                ComboBox8.Visible = False
                ComboBox9.Visible = False
                Label30.Visible = False
                Label31.Visible = False
            End If
            If ComboBox2.Text = "Se Desconecta en el tiempo establecido" Then

                GroupBox5.Show()
                Dim usuario As String = ""
                Dim dt10 As New DataTable
                Dim c1 As String

                c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
                Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
                adaptadorsql1.Fill(dt10)
                Dim i As Integer

                For i = 0 To dt10.Rows.Count - 1
                    usuario = dt10.Rows(i).Item("Usuario")
                Next

                Dim motivo As String = TextBox3.Text
                DateTimePicker4.Value = Today
                ComboBox6.SelectedItem = motivo
                TextBox16.Text = usuario
                ComboBox8.Enabled = False
                ComboBox9.Enabled = False
                ComboBox8.Visible = False
                ComboBox9.Visible = False
                Label30.Visible = False
                Label31.Visible = False
            End If
            If ComboBox2.Text = "Se desconecta fuera de la fecha de preaviso" Then
                GroupBox5.Show()
                Dim usuario As String = ""
                Dim dt10 As New DataTable
                Dim c1 As String

                c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
                Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
                adaptadorsql1.Fill(dt10)
                Dim i As Integer

                For i = 0 To dt10.Rows.Count - 1
                    usuario = dt10.Rows(i).Item("Usuario")
                Next
                Dim motivo As String = TextBox3.Text
                DateTimePicker4.Value = Today
                ComboBox6.SelectedItem = motivo
                TextBox16.Text = usuario
                ComboBox8.Enabled = False
                ComboBox9.Enabled = False
                ComboBox8.Visible = False
                ComboBox9.Visible = False
                Label30.Visible = False
                Label31.Visible = False
            End If
            If ComboBox2.Text = "Se Desconecta uno de los servicios" Then
                GroupBox5.Show()
                Dim usuario As String = ""
                Dim dt10 As New DataTable
                Dim c1 As String

                c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
                Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
                adaptadorsql1.Fill(dt10)
                Dim i As Integer

                For i = 0 To dt10.Rows.Count - 1
                    usuario = dt10.Rows(i).Item("Usuario")
                Next

                DateTimePicker4.Value = Today
                TextBox16.Text = usuario
                ComboBox8.Enabled = True
                ComboBox9.Enabled = True
                ComboBox6.Enabled = False
                ComboBox8.Visible = True
                ComboBox9.Visible = True
                Label30.Visible = True
                Label31.Visible = True
            End If

            If ComboBox2.Text = "Cartera ya desconecto la cuenta" Then
                GroupBox5.Show()
                ComboBox8.Enabled = False
                ComboBox9.Enabled = False
                ComboBox8.Visible = False
                ComboBox9.Visible = False
                Label30.Visible = False
                Label31.Visible = False
            End If

            If ComboBox2.Text = "Se desconecto con anterioridad" Then
                GroupBox5.Show()
                ComboBox8.Enabled = False
                ComboBox9.Enabled = False
                ComboBox8.Visible = False
                ComboBox9.Visible = False
                Label30.Visible = False
                Label31.Visible = False
            End If

            If ComboBox2.Text = "La Cuenta Esta Retenida" Then
                GroupBox6.Show()
                GroupBox6.Visible = True
                GroupBox6.Location = New Point(519, 353)


            End If

            If ComboBox2.Text = "Desconectada por cesion" Then
                GroupBox5.Show()
                ComboBox8.Enabled = False
                ComboBox9.Enabled = False
                ComboBox8.Visible = False
                ComboBox9.Visible = False
                Label30.Visible = False
                Label31.Visible = False
            End If

            If ComboBox2.Text = "Servicio ya desconectado" Then
                GroupBox5.Show()
                
                ComboBox8.Enabled = True
                ComboBox9.Enabled = True
                ComboBox6.Enabled = False
                ComboBox8.Visible = True
                ComboBox9.Visible = True
                Label30.Visible = True
                Label31.Visible = True
            End If

            If ComboBox2.Text = "" Then
                MsgBox("Este campo no puede quedar vacio")
                ComboBox2.BackColor = Color.Red
                ComboBox2.ForeColor = Color.White
            Else
                ComboBox2.BackColor = Color.WhiteSmoke
                ComboBox2.ForeColor = Color.Black
            End If


        Catch ex As Exception

        End Try



    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ComboBox1.DataBindings.Clear()
        ComboBox2.DataBindings.Clear()
        ComboBox2.Text = ""
        ComboBox2.Items.Clear()
        GroupBox5.Hide()
        GroupBox6.Hide()

        Me.ComboBox2.SelectedIndex = -1

        Dim c1, c2 As String
        Dim dt1, dt2 As New DataTable
        Dim sub_proceso As Integer
        Dim nombre_sub_proceso As String = ComboBox1.Text


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
            ComboBox2.Items.Add(dt1.Rows(i).Item("NOMBRE_PROCESO"))
        Next

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.LostFocus
        Try
            If ComboBox3.Text = "" Then
                MsgBox("Este campo no puede quedar vacio")
                ComboBox3.BackColor = Color.Red
                ComboBox3.ForeColor = Color.White
                ComboBox3.Focus()
            Else
                ComboBox3.BackColor = Color.WhiteSmoke
                ComboBox3.ForeColor = Color.Black
                End If
        Finally
        End Try
    End Sub
    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.LostFocus
        Try
            If ComboBox5.Text = "" Then
                MsgBox("Este campo no puede quedar vacio")
                ComboBox5.BackColor = Color.Red
                ComboBox5.ForeColor = Color.White
                ComboBox5.Focus()
            Else
                ComboBox5.BackColor = Color.WhiteSmoke
                ComboBox5.ForeColor = Color.Black
            End If
        Finally
        End Try
    End Sub
    Private Sub ComboBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox6.LostFocus
        Try
            If ComboBox6.Text = "" Then
                MsgBox("Este campo no puede quedar vacio")
                ComboBox6.BackColor = Color.Red
                ComboBox6.ForeColor = Color.White
                ComboBox6.Focus()
            Else
                ComboBox6.BackColor = Color.WhiteSmoke
                ComboBox6.ForeColor = Color.Black
            End If
        Finally
        End Try
    End Sub
    Private Sub ComboBox7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox7.LostFocus
        Try
            If ComboBox7.Text = "" Then
                MsgBox("Este campo no puede quedar vacio")
                ComboBox7.BackColor = Color.Red
                ComboBox7.ForeColor = Color.White
                ComboBox7.Focus()
            Else
                ComboBox7.BackColor = Color.WhiteSmoke
                ComboBox7.ForeColor = Color.Black
            End If
        Finally
        End Try
    End Sub

    Private Sub ComboBox8_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox8.LostFocus
        Try
            If ComboBox8.Text = "" Then
                MsgBox("Este campo no puede quedar vacio")
                ComboBox8.BackColor = Color.Red
                ComboBox8.ForeColor = Color.White
                ComboBox8.Focus()

            Else
                ComboBox8.BackColor = Color.WhiteSmoke
                ComboBox8.ForeColor = Color.Black
            End If
        Finally
        End Try
    End Sub
    Private Sub ComboBox9_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox9.LostFocus
        Try
            If ComboBox9.Text = "" Then
                MsgBox("Este campo no puede quedar vacio")
                ComboBox9.BackColor = Color.Red
                ComboBox9.ForeColor = Color.White
                ComboBox9.Focus()
            Else
                ComboBox9.BackColor = Color.WhiteSmoke
                ComboBox9.ForeColor = Color.Black
            End If
        Finally
        End Try
    End Sub

    Private Sub TextBox16_TextChanged(sender As Object, e As EventArgs) Handles TextBox16.LostFocus
        Try
            If TextBox16.Text = "" Then
                MsgBox("Este campo no puede quedar vacio")
                TextBox16.BackColor = Color.Red
                TextBox16.ForeColor = Color.White
                TextBox16.Focus()
                TextBox16.SelectAll()
            Else
                TextBox16.BackColor = Color.WhiteSmoke
                TextBox16.ForeColor = Color.Black
            End If
        Finally
        End Try

    End Sub

    Private Sub TextBox17_TextChanged(sender As Object, e As EventArgs) Handles TextBox17.LostFocus
        Try
            If TextBox17.Text = "" Then
                MsgBox("Este campo no puede quedar vacio")
                TextBox17.BackColor = Color.Red
                TextBox17.ForeColor = Color.White
                TextBox17.Focus()
                TextBox17.SelectAll()
            Else
                TextBox17.BackColor = Color.WhiteSmoke
                TextBox17.ForeColor = Color.Black
            End If
        Finally
        End Try
    End Sub
    Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs) Handles TextBox14.LostFocus
        Try
            If TextBox14.Text = "" Then
                MsgBox("Este campo no puede quedar vacio")
                TextBox14.BackColor = Color.Red
                TextBox14.ForeColor = Color.White
                TextBox14.Focus()
                TextBox14.SelectAll()
            Else
                TextBox14.BackColor = Color.WhiteSmoke
                TextBox14.ForeColor = Color.Black
            End If
        Finally
        End Try

    End Sub


End Class