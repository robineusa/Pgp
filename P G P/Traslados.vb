Imports System.Data.SqlClient

Public Class Traslados
    Dim ID_MACROPROCESO = 10
    Private Sub Traslados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim c1 As String
        Dim dt1 As New DataTable

        c1 = "SELECT NOMBRE_SUB_PROCESO FROM SUB_PROCESOS WHERE ID_MACROPROCESO =" & ID_MACROPROCESO & ""
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt1)

        Dim i As Integer

        For i = 0 To dt1.Rows.Count - 1
            ComboBox4.Items.Add(dt1.Rows(i).Item("NOMBRE_SUB_PROCESO"))
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

        Label25.Text = nombreusuario

        GroupBox1.Show()
        TextBox1.Focus()


        Dim dttable As New DataTable
        Dim consulta2 As String

        consulta2 = "SELECT * FROM ASIG_TRASLADOS ORDER BY  RANGO_ORDEN DESC, FECHA_CREACION ASC"

        Dim adaptadorSQL As New SqlDataAdapter(consulta2, New SqlConnection(coneccion))
        adaptadorSQL.Fill(dttable)

        If adaptadorSQL.Fill(dttable) = False Then
            MsgBox("NO HAY REGISTROS DISPONIBLES")
            GroupBox1.Hide()
            GroupBox2.Hide()
            GroupBox3.Hide()
        Else
            TextBox1.DataBindings.Add(New Binding("Text", dttable, "Cuenta"))
            TextBox2.DataBindings.Add(New Binding("Text", dttable, "Orden"))
            ComboBox6.DataBindings.Add(New Binding("Text", dttable, "CANAL_INGRESO"))
            TextBox3.DataBindings.Add(New Binding("Text", dttable, "Division"))
            TextBox4.DataBindings.Add(New Binding("Text", dttable, "USUARIO_CREACION"))
            DateTimePicker3.DataBindings.Add(New Binding("Text", dttable, "Fecha_Creacion"))
            TextBox6.DataBindings.Add(New Binding("Text", dttable, "Rango_Orden"))
            TextBox7.DataBindings.Add(New Binding("Text", dttable, "Estado"))

            Dim dttable1 As New DataTable
            Dim consulta3 As String
            Dim Dato As Double

            Dato = TextBox2.Text
            consulta3 = "DELETE ASIG_TRASLADOS where ORDEN = " & Dato & ""
            Dim adaptadorSQL2 As New SqlDataAdapter(consulta3, New SqlConnection(coneccion))
            adaptadorSQL2.Fill(dttable1)

        End If

    End Sub
    Private Sub Cerrar_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If TextBox2.Text = "" Then

        Else
            Dim c2 As String
            Dim dt2 As New DataTable
            Dim Cuenta As Double = TextBox1.Text
            Dim Orden As Double = TextBox2.Text
            Dim Division As String = TextBox3.Text
            Dim Usuario_crea As String = TextBox4.Text
            Dim Fecha_Crea As String = DateTimePicker3.Text
            Dim Rango_Ot As Integer = TextBox6.Text
            Dim Estado As String = TextBox7.Text
            Dim AÑO_CREACION As Integer = DateTimePicker3.Value.Year
            Dim MES_CREACION As Integer = DateTimePicker3.Value.Month
            Dim DIA_CREACION As Integer = DateTimePicker3.Value.Day
            Dim canal_Ingreso As String = ComboBox6.Text


            If (MsgBox("Recuerde que al cerrar el formulario el registro no va a ser gestionado.", MsgBoxStyle.OkOnly, "Devolucion de Registros")) = MsgBoxResult.Ok Then
                c2 = "INSERT INTO ASIG_TRASLADOS(Cuenta,Orden,CANAL_INGRESO,Division,Usuario_Creacion,Fecha_Creacion,AÑO_CREACION,MES_CREACION,DIA_CREACION,Rango_Orden,Estado)VALUES(" & Cuenta & "," & Orden & ",'" & canal_Ingreso & "','" & Division & "','" & Usuario_crea & "','" & Fecha_Crea & "'," & AÑO_CREACION & "," & MES_CREACION & "," & DIA_CREACION & "," & Rango_Ot & ",'" & Estado & "')"
                Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
                adaptadorsql2.Fill(dt2)
                MsgBox("Se Devolvio el Registro a la Base")
            Else
                c2 = ""

                Exit Sub
            End If
        End If


    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        ComboBox2.Hide()
        ComboBox3.Hide()

        If ComboBox1.SelectedItem = "Efectivo" Then
            ComboBox2.Show()
        Else
            If ComboBox1.SelectedItem = "No Efectivo" Then
                ComboBox3.Show()
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim dttable4, dttable5, dttable25 As New DataTable
        Dim consulta4, consulta5, consulta25 As String
        Dim Cuenta As Double = TextBox1.Text
        Dim Orden As Double = TextBox2.Text
        Dim Division As String = TextBox3.Text
        Dim Usuario_crea As String = TextBox4.Text
        Dim Fecha_Crea As String = DateTimePicker3.Text
        Dim Rango_Ot As Integer = TextBox6.Text
        Dim Estado As String = TextBox7.Text
        Dim Fecha_Marcacion As String = DateTimePicker1.Text
        Dim Usuario_Mod As String = TextBox9.Text
        Dim Fecha_Modif As String = DateTimePicker2.Text
        Dim contacto As String = ComboBox1.Text
        Dim Tipo_Contacto As String = ""
        Dim Gestion As String = ComboBox4.Text
        Dim Subrazon As String = ComboBox5.Text
        Dim Razon_Impo As String = ComboBox10.Text
        Dim Estado_Orden As String = ComboBox11.Text
        Dim Preaviso As String = ComboBox12.Text
        Dim Estado_Cuenta As String = ComboBox13.Text
        Dim Llamada As String = ComboBox14.Text
        Dim Observ As String = TextBox5.Text
        Dim intentos As Integer = TextBox8.Text
        Dim canal_ingreso As String = ComboBox6.Text
        Dim dato1 As String = ""
        Dim dt10 As New DataTable
        Dim c1 As String
        Dim AÑO_CREACION As Integer = DateTimePicker3.Value.Year
        Dim MES_CREACION As Integer = DateTimePicker3.Value.Month
        Dim DIA_CREACION As Integer = DateTimePicker3.Value.Day
        Dim AÑO_MARCACION As Integer = DateTimePicker1.Value.Year
        Dim MES_MARCACION As Integer = DateTimePicker1.Value.Month
        Dim DIA_MARCACION As Integer = DateTimePicker1.Value.Day
        Dim AÑO_MODIFICACION As Integer = DateTimePicker2.Value.Year
        Dim MES_MODIFICACION As Integer = DateTimePicker2.Value.Month
        Dim DIA_MODIFICACION As Integer = DateTimePicker2.Value.Day



        c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt10)
        Dim i As Integer

        For i = 0 To dt10.Rows.Count - 1
            dato1 = dt10.Rows(i).Item("Usuario")
        Next

        If ComboBox2.Visible = True Then
            Tipo_Contacto = ComboBox2.Text
        Else
            If ComboBox3.Visible = True Then
                Tipo_Contacto = ComboBox3.Text
            End If
        End If

        If (MsgBox("Desea guardar registro?", MsgBoxStyle.YesNo, "Guardar")) = MsgBoxResult.Yes Then

            Dim id As Integer = 9
            Dim proceso As String = "Traslados No Cobertura"
            Dim Cant_serv As Integer = 0

            consulta4 = "INSERT INTO TRASLADOS (Fecha_Gestion ,AÑO_GESTION,MES_GESTION,DIA_GESTION,Hora_Gestion ,Usuario ,Cuenta,Orden ,CANAL_INGRESO,Division,Usu_Creacion,Fecha_Creacion ,AÑO_CREACION,MES_CREACION,DIA_CREACION,Rango_Ot ,Estado ,Fecha_Marcacion ,AÑO_MARCACION,MES_MARCACION,DIA_MARCACION,Usu_Modificacion ,Fecha_Modific ,AÑO_MODIFICACION,MES_MODIFICACION,DIA_MODIFICACION,Contacto ,Tipo_Contacto ,Gestion ,Sub_Razon ,Razon_Iposibilidad ,Estado_Orden ,Preaviso ,Etado_Cuenta ,Llamada_Sericio ,Observaciones ,Intentos_Contato )Values(getdate()," & AÑO & "," & MES & "," & DIA & ",getdate(),'" & dato1 & "'," & Cuenta & "," & Orden & ",'" & canal_ingreso & "','" & Division & "','" & Usuario_crea & "','" & Fecha_Crea & "'," & AÑO_CREACION & "," & MES_CREACION & "," & DIA_CREACION & "," & Rango_Ot & ",'" & Estado & "','" & Fecha_Marcacion & "'," & AÑO_MARCACION & "," & MES_MARCACION & "," & DIA_MARCACION & ",'" & Usuario_Mod & "','" & Fecha_Modif & "'," & AÑO_MODIFICACION & "," & MES_MODIFICACION & "," & DIA_MODIFICACION & ",'" & contacto & "','" & Tipo_Contacto & "','" & Gestion & "','" & Subrazon & "','" & Razon_Impo & "', '" & Estado_Orden & "','" & Preaviso & "','" & Estado_Cuenta & "','" & Llamada & "','" & Observ & "'," & intentos & ")"
            Dim adaptadorSQL4 As New SqlDataAdapter(consulta4, New SqlConnection(coneccion))
            adaptadorSQL4.Fill(dttable4)

            consulta5 = "INSERT INTO CONSOLIDADO(ID_GESTION,CUENTA,CANAL_INGRESO,FECHA_CREACION,PROCESO,GESTION,SUB_RAZON,SERVICIOS_DX,FECHA_GESTION,AÑO_GESTION,MES_GESTION,DIA_GESTION,HORA_GESTION,USUARIO,OBSERVACIONES) VALUES(" & id & ", " & Cuenta & ",'" & canal_ingreso & "','" & Fecha_Crea & "','" & proceso & "','" & Gestion & "','" & Subrazon & "'," & Cant_serv & ",getdate()," & AÑO & "," & MES & "," & DIA & ",getdate(), '" & dato1 & "','" & Observ & "')"
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
            TextBox3.Text = ""
            TextBox4.Text = ""
            DateTimePicker3.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""
            TextBox9.Text = ""

            ComboBox13.Text = ""

            limpiar(Me)
            DataBindings.Clear()
            TextBox1.DataBindings.Clear()
            TextBox2.DataBindings.Clear()
            TextBox3.DataBindings.Clear()
            TextBox4.DataBindings.Clear()
            DateTimePicker3.DataBindings.Clear()
            TextBox6.DataBindings.Clear()
            TextBox7.DataBindings.Clear()
            TextBox9.DataBindings.Clear()
            ComboBox13.DataBindings.Clear()

            ComboBox1.DataBindings.Clear()
            ComboBox2.DataBindings.Clear()
            ComboBox3.DataBindings.Clear()
            ComboBox4.DataBindings.Clear()
            ComboBox6.DataBindings.Clear()

            ComboBox1.Text = ""
            ComboBox2.Text = ""
            ComboBox3.Text = ""
            ComboBox4.Text = ""
            ComboBox5.Text = ""
            ComboBox10.Text = ""
            ComboBox11.Text = ""
            ComboBox12.Text = ""
            ComboBox13.Text = ""
            ComboBox6.Text = ""

            Me.ComboBox1.SelectedIndex = -1
            Me.ComboBox2.SelectedIndex = -1
            Me.ComboBox3.SelectedIndex = -1
            Me.ComboBox4.SelectedIndex = -1
            Me.ComboBox5.SelectedIndex = -1
            Me.ComboBox6.SelectedIndex = -1
            Me.ComboBox12.SelectedIndex = -1
            Me.ComboBox13.SelectedIndex = -1
            Me.ComboBox14.SelectedIndex = -1
            Me.ComboBox10.SelectedIndex = -1
            Me.ComboBox11.SelectedIndex = -1
           


            DateTimePicker1.Text = ""
            DateTimePicker2.Text = ""

            DateTimePicker1.DataBindings.Clear()
            DateTimePicker2.DataBindings.Clear()

            ComboBox2.Text = ""
            ComboBox3.Text = ""
            ComboBox14.Text = ""
            TextBox8.Text = 1
            TextBox5.Text = ""
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

            DateTimePicker1.Value = Today
            DateTimePicker2.Value = Today
            DateTimePicker3.Value = Today

            Dim dttable As New DataTable
            Dim consulta2 As String

            consulta2 = "SELECT * FROM ASIG_TRASLADOS order by  RANGO_ORDEN desc, FECHA_CREACION asc"

            Dim adaptadorSQL As New SqlDataAdapter(consulta2, New SqlConnection(coneccion))
            adaptadorSQL.Fill(dttable)


            If adaptadorSQL.Fill(dttable) = False Then


                Button1.Hide()
                MsgBox("NO HAY REGISTROS DISPONIBLES")
                GroupBox1.Hide()
                GroupBox2.Hide()
                GroupBox3.Hide()
            Else
                TextBox1.DataBindings.Add(New Binding("Text", dttable, "Cuenta"))
                TextBox2.DataBindings.Add(New Binding("Text", dttable, "Orden"))
                ComboBox6.DataBindings.Add(New Binding("Text", dttable, "CANAL_INGRESO"))
                TextBox3.DataBindings.Add(New Binding("Text", dttable, "Division"))
                TextBox4.DataBindings.Add(New Binding("Text", dttable, "Usuario_Creacion"))
                DateTimePicker3.DataBindings.Add(New Binding("Text", dttable, "Fecha_Creacion"))
                TextBox6.DataBindings.Add(New Binding("Text", dttable, "Rango_Orden"))
                TextBox7.DataBindings.Add(New Binding("Text", dttable, "Estado"))
                TextBox1.Focus()

                Dim dttable1 As New DataTable
                Dim consulta3 As String
                Dim Dato As Double

                Dato = TextBox2.Text
                consulta3 = "DELETE ASIG_TRASLADOS where ORDEN = " & Dato & ""

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

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        ComboBox4.DataBindings.Clear()
        ComboBox5.DataBindings.Clear()
        ComboBox5.Text = ""
        ComboBox5.Items.Clear()


        Dim c1, c2 As String
        Dim dt1, dt2 As New DataTable
        Dim sub_proceso As Integer
        Dim nombre_sub_proceso As String = ComboBox4.Text


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
            ComboBox5.Items.Add(dt1.Rows(i).Item("NOMBRE_PROCESO"))
        Next
    End Sub
End Class