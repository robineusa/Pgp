Imports System.Data.SqlClient

Public Class Agendamiento_Ingreso
    Dim MACROPROCESO As Integer = 1
    Private Sub Agendamiento_Ingreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Label33.Text = nombreusuario
        DateTimePicker1.Value = Today
        DateTimePicker1.MinDate = New DateTime(1985, 6, 12)
        DateTimePicker1.Format = DateTimePickerFormat.Short
        DateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd"

        DateTimePicker2.Value = Today
        DateTimePicker2.MinDate = New DateTime(1985, 6, 12)
        DateTimePicker2.Format = DateTimePickerFormat.Short
        DateTimePicker2.CustomFormat = "MMMM dd, yyyy - dddd"

        Dim c1, c2 As String
        Dim dt1, dt2, dt3, dt4 As New DataTable

        c1 = "SELECT NOMBRE_PROCESO FROM PROCESOS WHERE ID_SUBPROCESO=7"
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt1)

        Dim i As Integer

        For i = 0 To dt1.Rows.Count - 1
            ComboBox1.Items.Add(dt1.Rows(i).Item("NOMBRE_PROCESO"))

        Next


        c2 = "SELECT NOMBRE_PROCESO FROM PROCESOS WHERE ID_SUBPROCESO=6"
        Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
        adaptadorsql2.Fill(dt2)


        Dim j As Integer

        For j = 0 To dt2.Rows.Count - 1
            ComboBox2.Items.Add(dt2.Rows(j).Item("NOMBRE_PROCESO"))

        Next

        TextBox7.Text = "Sin Observaciones"
        TextBox6.Text = "0"
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Cuenta_escalamiento = TextBox1.Text
        Escalamientos_anterior.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Cuenta_hallazgos = TextBox1.Text
        Hallazgos.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim c1, c2, c3, c4, c5, c6, c7 As String
        Dim dt1, dt2, dt3, dt4, dt5, dt6, dt7 As New DataTable

        Dim usuario As String = ""
        Dim cuenta As Double = TextBox1.Text
        Dim orden As Double = TextBox2.Text
        Dim rango_dias As String = TextBox5.Text
        Dim comunidad As String = TextBox3.Text
        Dim nodo As String = TextBox4.Text
        Dim reporte_aliado As String = ComboBox1.Text
        Dim veces_programada As String = TextBox6.Text
        Dim gestion As String = ComboBox2.Text
        Dim fecha_agenda As String = DateTimePicker1.Text
        Dim observaciones As String = TextBox7.Text
        Dim CANAL_INGRESO As String = ComboBox3.Text
        Dim FECHA_CREACION As String = DateTimePicker2.Text

        c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt1)
        Dim i As Integer

        For i = 0 To dt1.Rows.Count - 1
            usuario = dt1.Rows(i).Item("Usuario")
        Next

        Dim subrazon As String = "No Aplica"
        Dim Servicios_Dx As Integer = 0

        If (MsgBox("Desea guardar registro?", MsgBoxStyle.YesNo, "Guardar")) = MsgBoxResult.Yes Then

            Dim id As Integer = 1
            Dim proceso As String = "Agendamiento de Ordenes"

            c2 = "INSERT INTO AGENDAMIENTO (FECHA_GESTION,AÑO_GESTION ,MES_GESTION ,DIA_GESTION,HORA_GESTION,USUARIO,CANAL_INGRESO ,CUENTA,ORDEN ,FECHA_CREACION,RANGO_DIAS,COMUNIDAD,NODO,REPORTE_ALIADO,VECES_PROGRAMADA,GESTION,FECHA_AGENDA,OBSERVACIONES)VALUES(getdate()," & AÑO & "," & MES & "," & DIA & " ,getdate(),'" & usuario & "','" & CANAL_INGRESO & "'," & cuenta & "," & orden & ",'" & FECHA_CREACION & "','" & rango_dias & "','" & comunidad & "','" & nodo & "','" & reporte_aliado & "','" & veces_programada & "','" & gestion & "','" & fecha_agenda & "','" & observaciones & "')"
            Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
            adaptadorsql2.Fill(dt2)



            c3 = "INSERT INTO CONSOLIDADO(ID_GESTION,CUENTA,CANAL_INGRESO,FECHA_CREACION,PROCESO,GESTION,SUB_RAZON,SERVICIOS_DX,FECHA_GESTION,AÑO_GESTION,MES_GESTION,DIA_GESTION,HORA_GESTION,USUARIO,OBSERVACIONES) VALUES(" & id & ", " & cuenta & ",'" & CANAL_INGRESO & "','" & FECHA_CREACION & "',  '" & proceso & "','" & gestion & "','" & subrazon & "'," & Servicios_Dx & ",getdate()," & AÑO & "," & MES & "," & DIA & ",getdate(), '" & usuario & "','" & observaciones & "')"
            Dim adaptadorsql3 As New SqlDataAdapter(c3, New SqlConnection(coneccion))
            adaptadorsql3.Fill(dt3)

            Dim porcen As Decimal
            porcen = 1

            Dim id2 As Integer = 12

            c4 = "INSERT INTO PRODUCTIVIDAD (USUARIO,ID_GESTION,FECHA,AÑO,MES,DIA,HORA_GESTION,CUENTA,PROCESO,PORCENTAJE)VALUES('" & usuario & "'," & id2 & ",getdate()," & AÑO & "," & MES & "," & DIA & ",getdate()," & cuenta & ", '" & proceso & "'," & porcen & ")"
            Dim adaptadorsql4 As New SqlDataAdapter(c4, New SqlConnection(coneccion))
            adaptadorsql4.Fill(dt4)

            '******************************************************

            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""

            TextBox1.DataBindings.Clear()
            TextBox2.DataBindings.Clear()
            TextBox3.DataBindings.Clear()
            TextBox4.DataBindings.Clear()
            TextBox5.DataBindings.Clear()
            TextBox6.DataBindings.Clear()
            TextBox7.DataBindings.Clear()

            ComboBox1.Text = ""
            ComboBox2.Text = ""
            ComboBox3.Text = ""

            ComboBox1.DataBindings.Clear()
            ComboBox2.DataBindings.Clear()
            ComboBox3.DataBindings.Clear()

            Me.ComboBox1.SelectedIndex = -1
            Me.ComboBox2.SelectedIndex = -1
            Me.ComboBox3.SelectedIndex = -1


            DateTimePicker1.Text = ""
            DateTimePicker1.Value = Today
            DateTimePicker2.DataBindings.Clear()
            DateTimePicker2.Text = ""
            DateTimePicker2.Value = Today
        Else
            c1 = ""
            c2 = ""
            c3 = ""
            c4 = ""
            c5 = ""
            c6 = ""
            c7 = ""
        End If
        TextBox1.Focus()
        TextBox7.Text = "Sin Observaciones"
        TextBox6.Text = "0"
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""

        TextBox1.DataBindings.Clear()
        TextBox2.DataBindings.Clear()
        TextBox3.DataBindings.Clear()
        TextBox4.DataBindings.Clear()
        TextBox5.DataBindings.Clear()
        TextBox6.DataBindings.Clear()
        TextBox7.DataBindings.Clear()

        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""

        DateTimePicker1.DataBindings.Clear()
        DateTimePicker2.DataBindings.Clear()
        ComboBox1.DataBindings.Clear()
        ComboBox2.DataBindings.Clear()
        ComboBox3.DataBindings.Clear()

        DateTimePicker1.Text = ""
        DateTimePicker1.Value = Today

        If TextBox1.Text <> "" And TextBox2.Text <> "" Then
            Dim cuenta As Double = TextBox1.Text
            Dim orden As Double = TextBox2.Text

            Dim c1 As String
            Dim dt1 As New DataTable

            c1 = "SELECT * FROM AGENDAMIENTO WHERE CUENTA=" & cuenta & " AND ORDEN=" & orden & ""
            Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
            adaptadorsql1.Fill(dt1)

            ComboBox3.DataBindings.Add(New Binding("Text", dt1, "CANAL_INGRESO"))
            TextBox1.DataBindings.Add(New Binding("Text", dt1, "CUENTA"))
            TextBox2.DataBindings.Add(New Binding("Text", dt1, "ORDEN"))
            TextBox5.DataBindings.Add(New Binding("Text", dt1, "RANGO_DIAS"))
            TextBox3.DataBindings.Add(New Binding("Text", dt1, "COMUNIDAD"))
            TextBox4.DataBindings.Add(New Binding("Text", dt1, "NODO"))
            ComboBox1.DataBindings.Add(New Binding("Text", dt1, "REPORTE_ALIADO"))
            TextBox6.DataBindings.Add(New Binding("Text", dt1, "VECES_PROGRAMADA"))
            ComboBox2.DataBindings.Add(New Binding("Text", dt1, "GESTION"))
            DateTimePicker1.DataBindings.Add(New Binding("Text", dt1, "FECHA_AGENDA"))
            TextBox7.DataBindings.Add(New Binding("Text", dt1, "OBSERVACIONES"))
            DateTimePicker2.DataBindings.Add(New Binding("Text", dt1, "FECHA_CREACION"))
        Else
            Exit Sub
        End If


    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If TextBox1.Text <> "" And TextBox2.Text <> "" Then

            Dim c1, c2, c4 As String
            Dim dt1, dt2, dt4 As New DataTable

            Dim usuario As String = ""
            Dim cuenta As Double = TextBox1.Text
            Dim orden As Double = TextBox2.Text
            Dim rango_dias As String = TextBox5.Text
            Dim comunidad As String = TextBox3.Text
            Dim nodo As String = TextBox4.Text
            Dim reporte_aliado As String = ComboBox1.Text
            Dim veces_programada As String = TextBox6.Text
            Dim gestion As String = ComboBox2.Text
            Dim fecha_agenda As String = DateTimePicker1.Text
            Dim observaciones As String = TextBox7.Text
            Dim CANAL_INGRESO As String = ComboBox3.Text

            Dim id As Integer = 1
            Dim proceso As String = "Agendamiento de Ordenes"
            Dim c10 As String
            Dim dt10 As New DataTable

            c10 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
            Dim adaptadorsql10 As New SqlDataAdapter(c10, New SqlConnection(coneccion))
            adaptadorsql10.Fill(dt10)
            Dim i As Integer

            For i = 0 To dt10.Rows.Count - 1
                usuario = dt10.Rows(i).Item("Usuario")
            Next


            c1 = "UPDATE AGENDAMIENTO SET CUENTA=" & cuenta & ", ORDEN=" & orden & ",RANGO_DIAS='" & rango_dias & "', COMUNIDAD='" & comunidad & "',NODO='" & nodo & "',REPORTE_ALIADO= '" & reporte_aliado & "',VECES_PROGRAMADA=" & veces_programada & ",GESTION='" & gestion & "',FECHA_AGENDA='" & fecha_agenda & "', OBSERVACIONES='" & observaciones & "' WHERE CUENTA=" & cuenta & " AND ORDEN=" & orden & ""
            Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
            adaptadorsql1.Fill(dt1)

            Dim subrazon As String = "No Aplica"
            Dim Servicios_Dx As Integer = 0

            Dim FECHA_CREACION As String = DateTimePicker2.Text


            c2 = "UPDATE CONSOLIDADO SET CANAL_INGRESO='" & CANAL_INGRESO & "',GESTION='" & gestion & "',SUB_RAZON='" & subrazon & "',SERVICIOS_DX=" & Servicios_Dx & ",OBSERVACIONES='" & observaciones & "' WHERE CUENTA=" & cuenta & " AND FECHA_CREACION='" & FECHA_CREACION & "' AND ID_GESTION=" & id & ""
            Dim adaptadorSQL2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
            adaptadorSQL2.Fill(dt2)

            Dim porcen As Decimal
            porcen = 1
            c4 = "INSERT INTO PRODUCTIVIDAD (USUARIO,ID_GESTION,FECHA,AÑO,MES,DIA,HORA_GESTION,CUENTA,PROCESO,PORCENTAJE)VALUES('" & usuario & "'," & id & ",getdate()," & AÑO & "," & MES & "," & DIA & ",getdate()," & cuenta & ", '" & proceso & "'," & porcen & ")"
            Dim adaptadorsql4 As New SqlDataAdapter(c4, New SqlConnection(coneccion))
            adaptadorsql4.Fill(dt4)
            MsgBox("Registro Actualizado")



        Else
            Exit Sub
        End If
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""

        TextBox1.DataBindings.Clear()
        TextBox2.DataBindings.Clear()
        TextBox3.DataBindings.Clear()
        TextBox4.DataBindings.Clear()
        TextBox5.DataBindings.Clear()
        TextBox6.DataBindings.Clear()
        TextBox7.DataBindings.Clear()

        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""

        DateTimePicker1.DataBindings.Clear()
        ComboBox1.DataBindings.Clear()
        ComboBox2.DataBindings.Clear()
        ComboBox3.DataBindings.Clear()

        DateTimePicker1.Text = ""
        DateTimePicker1.Value = Today

    End Sub
End Class