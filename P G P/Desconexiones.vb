Imports System.Data.SqlClient

Public Class Desconexiones
    Private Sub Cerrar_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If TextBox2.Text <> "" Then

            Dim c2 As String
            Dim dt2 As New DataTable
            Dim Cuenta As Double = TextBox1.Text
            Dim Motivo_Dx As String = TextBox2.Text
            Dim Codigo As String = TextBox3.Text
            Dim Nota1 As String = TextBox7.Text
            Dim Nota2 As String = TextBox8.Text
            Dim Nota3 As String = TextBox9.Text
            Dim Nota4 As String = TextBox10.Text
            Dim Nota5 As String = TextBox11.Text
            Dim Red As String = TextBox4.Text
            Dim Servicios As String = TextBox5.Text
            Dim Fecha_Sol As String = DateTimePicker1.Text
            Dim Fecha_Corte As String = DateTimePicker2.Text
            Dim Fecha_Preav As String = DateTimePicker3.Text
            Dim Dia_DX As Integer = TextBox6.Text
            Dim tarifa_anterior As String = TextBox14.Text
            Dim CANAL_INGRESO As String = TextBox18.Text


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
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DateTimePicker1.MaxDate = DateTime.Today
        DateTimePicker1.Format = DateTimePickerFormat.Short
        DateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd"

        DateTimePicker2.MaxDate = DateTime.Today
        DateTimePicker2.Format = DateTimePickerFormat.Short
        DateTimePicker2.CustomFormat = "MMMM dd, yyyy - dddd"

        DateTimePicker3.MaxDate = DateTime.Today
        DateTimePicker3.Format = DateTimePickerFormat.Short
        DateTimePicker3.CustomFormat = "MMMM dd, yyyy - dddd"


        Label1.Text = nombreusuario

        Dim dttable As New DataTable
        Dim consulta2 As String

        consulta2 = "SELECT * FROM ASIG_DESCONEXIONES order by DIA_DX ASC,FECHA_PREAVISO ASC,SERVICIOS ASC,MOTIVO_DX ASC"

        Dim adaptadorSQL As New SqlDataAdapter(consulta2, New SqlConnection(coneccion))
        adaptadorSQL.Fill(dttable)

        If adaptadorSQL.Fill(dttable) = False Then
            MsgBox("NO HAY REGISTROS DISPONIBLES")

        Else
            TextBox1.DataBindings.Add(New Binding("Text", dttable, "CUENTA"))
            TextBox2.DataBindings.Add(New Binding("Text", dttable, "MOTIVO_DX"))
            TextBox3.DataBindings.Add(New Binding("Text", dttable, "CODIGO"))
            TextBox7.DataBindings.Add(New Binding("Text", dttable, "NOTA1"))
            TextBox8.DataBindings.Add(New Binding("Text", dttable, "NOTA2"))
            TextBox9.DataBindings.Add(New Binding("Text", dttable, "NOTA3"))
            TextBox10.DataBindings.Add(New Binding("Text", dttable, "NOTA4"))
            TextBox11.DataBindings.Add(New Binding("Text", dttable, "NOTA5"))
            TextBox4.DataBindings.Add(New Binding("Text", dttable, "RED"))
            TextBox5.DataBindings.Add(New Binding("Text", dttable, "SERVICIOS"))
            DateTimePicker1.DataBindings.Add(New Binding("Text", dttable, "FECHA_SOLICITUD"))
            DateTimePicker2.DataBindings.Add(New Binding("Text", dttable, "FECHA_CORTE"))
            DateTimePicker3.DataBindings.Add(New Binding("Text", dttable, "FECHA_PREAVISO"))
            TextBox6.DataBindings.Add(New Binding("Text", dttable, "DIA_DX"))
            TextBox14.DataBindings.Add(New Binding("Text", dttable, "TARIFA_ANTERIOR"))
            TextBox18.DataBindings.Add(New Binding("Text", dttable, "CANAL_INGRESO"))

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
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim dttable4, dttable5, dttable25 As New DataTable
            Dim consulta4, consulta5, consulta25 As String

            Dim Cuenta As Double = TextBox1.Text
            Dim Motivo_Dx As String = TextBox2.Text
            Dim Codigo As String = TextBox3.Text
            Dim Nota1 As String = TextBox7.Text
            Dim Nota2 As String = TextBox8.Text
            Dim Nota3 As String = TextBox9.Text
            Dim Nota4 As String = TextBox10.Text
            Dim Nota5 As String = TextBox11.Text
            Dim Red As String = TextBox4.Text
            Dim Servicios As String = TextBox5.Text
            Dim Fecha_Sol As String = DateTimePicker1.Text
            Dim Fecha_Corte As String = DateTimePicker2.Text
            Dim Fecha_Preav As String = DateTimePicker3.Text
            Dim Dia_DX As Integer = TextBox6.Text
            Dim tarifa_anterior As String = TextBox14.Text
            Dim Gestion As String = ComboBox1.Text
            Dim Subrazon As String = ComboBox2.Text
            Dim Movie As Double = TextBox12.Text
            Dim Ajuste As String = ComboBox4.Text
            Dim Cant_serv As Integer = ComboBox5.Text
            Dim Observ As String = TextBox13.Text
            Dim proceso_retencion As String = ComboBox3.Text
            Dim CANAL_INGRESO As String = TextBox18.Text
            Dim fecha_dos As String = Now

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
                consulta4 = "INSERT INTO DESCONEXIONES (USUARIO ,FECHA_GESTION ,AÑO_GESTION,MES_GESTION,DIA_GESTION,HORA_GESTION,CANAL_INGRESO,CUENTA ,MOTIVO_DX ,CODIGO ,NOTA1 ,NOTA2 ,NOTA3 ,NOTA4 ,NOTA5 ,RED ,SERVICIOS,FECHA_SOLICITUD ,FECHA_CORTE ,FECHA_PREAVISO ,DIA_DX ,TARIFA_ANTERIOR,GESTION ,RAZON ,MOVIE_LETTER ,AJUSTE ,CANTIDAD_SERVICIOS ,OBSERVACIONES,PROCESO_RETENCION) Values('" & usuario & "',getdate()," & AÑO & " ," & MES & "," & DIA & ",getdate(),'" & CANAL_INGRESO & "'," & Cuenta & ",'" & Motivo_Dx & "','" & Codigo & "','" & Nota1 & "','" & Nota2 & "','" & Nota3 & "','" & Nota4 & "','" & Nota5 & "','" & Red & "','" & Servicios & "','" & Fecha_Sol & "','" & Fecha_Corte & "','" & Fecha_Preav & "'," & Dia_DX & ",'" & tarifa_anterior & "','" & Gestion & "','" & Subrazon & "'," & Movie & ",'" & Ajuste & "'," & Cant_serv & ",'" & Observ & "','" & proceso_retencion & "')"
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
                DateTimePicker1.DataBindings.Clear()
                DateTimePicker2.DataBindings.Clear()
                DateTimePicker3.DataBindings.Clear()

                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox6.Text = 0
                TextBox7.Text = ""
                TextBox8.Text = ""
                TextBox9.Text = ""
                TextBox10.Text = ""
                TextBox11.Text = ""
                TextBox12.Text = ""
                TextBox13.Text = ""
                TextBox14.Text = ""
                DateTimePicker1.Text = ""
                DateTimePicker2.Text = ""
                DateTimePicker3.Text = ""

                Me.ComboBox1.SelectedIndex = -1
                Me.ComboBox2.SelectedIndex = -1
                Me.ComboBox3.SelectedIndex = -1
                Me.ComboBox4.SelectedIndex = -1
                Me.ComboBox5.SelectedIndex = -1


                
                ComboBox1.Text = ""
                ComboBox2.Text = ""
                ComboBox4.Text = ""
                ComboBox5.Text = ""
                ComboBox5.Text = 0
                ComboBox4.Text = "No"
                TextBox12.Text = 0
                TextBox13.Text = "Sin Observaciones"
                Dim dttable As New DataTable
                Dim consulta2 As String

                consulta2 = "SELECT * FROM ASIG_DESCONEXIONES ORDER BY DIA_DX ASC,FECHA_PREAVISO ASC,SERVICIOS ASC,MOTIVO_DX ASC"

                Dim adaptadorSQL As New SqlDataAdapter(consulta2, New SqlConnection(coneccion))
                adaptadorSQL.Fill(dttable)


                If adaptadorSQL.Fill(dttable) = False Then
                    MsgBox("NO HAY REGISTROS DISPONIBLES")
                Else

                    TextBox1.DataBindings.Add(New Binding("Text", dttable, "Cuenta"))
                    TextBox2.DataBindings.Add(New Binding("Text", dttable, "Motivo_Dx"))
                    TextBox3.DataBindings.Add(New Binding("Text", dttable, "Codigo"))
                    TextBox7.DataBindings.Add(New Binding("Text", dttable, "Nota1"))
                    TextBox8.DataBindings.Add(New Binding("Text", dttable, "Nota2"))
                    TextBox9.DataBindings.Add(New Binding("Text", dttable, "Nota3"))
                    TextBox10.DataBindings.Add(New Binding("Text", dttable, "Nota4"))
                    TextBox11.DataBindings.Add(New Binding("Text", dttable, "Nota5"))
                    TextBox4.DataBindings.Add(New Binding("Text", dttable, "Red"))
                    TextBox5.DataBindings.Add(New Binding("Text", dttable, "Servicios"))
                    DateTimePicker1.DataBindings.Add(New Binding("Text", dttable, "Fecha_Solicitud"))
                    DateTimePicker2.DataBindings.Add(New Binding("Text", dttable, "Fecha_Corte"))
                    DateTimePicker3.DataBindings.Add(New Binding("Text", dttable, "Fecha_Preaviso"))
                    TextBox6.DataBindings.Add(New Binding("Text", dttable, "Dia_Dx"))
                    TextBox14.DataBindings.Add(New Binding("Text", dttable, "Tarifa_Anterior"))
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
        Catch ex As Exception When ComboBox1.ValueMember = ""
            MsgBox("Debe Seleccionar una opcion" & ex.Message & vbCrLf & "Existen Campos Vacios", MsgBoxStyle.Critical, "CUIDADO")
            ComboBox1.Focus()
        Catch ex As Exception When ComboBox2.ValueMember = ""
            MsgBox("Debe Seleccionar una opcion" & ex.Message & vbCrLf & "Existen Campos Vacios", MsgBoxStyle.Critical, "CUIDADO")
            ComboBox2.Focus()

        Catch ex As Exception When ComboBox4.ValueMember = ""
            MsgBox("Debe Seleccionar una opcion" & ex.Message & vbCrLf & "Existen Campos Vacios", MsgBoxStyle.Critical, "CUIDADO")
            ComboBox4.Focus()
        End Try

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

    Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox5.LostFocus
        Try
            If ComboBox5.Text = "" Then
                MsgBox("Este campo no puede quedar vacio")
                ComboBox5.BackColor = Color.Red
                ComboBox5.ForeColor = Color.White
            Else
                If ComboBox5.Text >= 4 Then
                    MsgBox("Numero de servicios invalido")
                    ComboBox5.BackColor = Color.Red
                    ComboBox5.ForeColor = Color.White
                Else
                    ComboBox5.BackColor = Color.WhiteSmoke
                    ComboBox5.ForeColor = Color.Black
                End If
            End If
        Finally
        End Try
    End Sub
End Class