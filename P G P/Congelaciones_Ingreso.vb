Imports System.Data.SqlClient

Public Class Congelaciones_Ingreso

    Private Sub Congelaciones_Ingreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label33.Text = nombreusuario

        DateTimePicker1.MinDate = New DateTime(1985, 6, 12)
        DateTimePicker1.MaxDate = DateTime.Today
        DateTimePicker1.Format = DateTimePickerFormat.Short
        DateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd"

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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dttable4, dttable5, dttable25 As New DataTable
        Dim consulta4, consulta5, consulta25 As String

        Dim Cuenta As Double = TextBox1.Text
        Dim Ingreso As String = ComboBox7.Text
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

            consulta5 = "INSERT INTO CONSOLIDADO(ID_GESTION,CUENTA,CANAL_INGRESO,FECHA_CREACION,PROCESO,GESTION,SUB_RAZON,SERVICIOS_DX,FECHA_GESTION,AÑO_GESTION,MES_GESTION,DIA_GESTION,HORA_GESTION,USUARIO,OBSERVACIONES) VALUES(" & id & ", " & Cuenta & ",'" & Ingreso & "','" & Fecha_Creacion & "', '" & proceso & "','" & Gestion & "','" & Sub_Razon & "'," & Servicios_Dx & ",getdate()," & AÑO & "," & MES & "," & DIA & ",getdate(), '" & usuario & "','" & Observaciones & "')"
            Dim adaptadorSQL5 As New SqlDataAdapter(consulta5, New SqlConnection(coneccion))
            adaptadorSQL5.Fill(dttable5)

            Dim porcen As Decimal
            porcen = 1

            Dim id2 As Integer = 12

            consulta25 = "INSERT INTO PRODUCTIVIDAD (USUARIO,ID_GESTION,FECHA,AÑO,MES,DIA,HORA_GESTION,CUENTA,PROCESO,PORCENTAJE)VALUES('" & usuario & "'," & id2 & ",getdate()," & AÑO & "," & MES & "," & DIA & ",getdate()," & Cuenta & ", '" & proceso & "'," & porcen & ")"
            Dim adaptadorSQL25 As New SqlDataAdapter(consulta25, New SqlConnection(coneccion))
            adaptadorSQL25.Fill(dttable5)

            MsgBox("Registro almacenado")


            TextBox1.Text = 0
            ComboBox7.Text = ""
            DateTimePicker1.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""

            ComboBox7.DataBindings.Clear()
            DateTimePicker1.DataBindings.Clear()
            TextBox4.DataBindings.Clear()
            TextBox5.DataBindings.Clear()
            TextBox6.DataBindings.Clear()
            ComboBox2.DataBindings.Clear()
            ComboBox3.DataBindings.Clear()
            ComboBox4.DataBindings.Clear()
            ComboBox5.DataBindings.Clear()
            ComboBox6.DataBindings.Clear()
            ComboBox8.DataBindings.Clear()
            ComboBox9.DataBindings.Clear()
            ComboBox10.DataBindings.Clear()
            ComboBox11.DataBindings.Clear()
            DateTimePicker1.DataBindings.Clear()
            DateTimePicker1.Value = Today

            ComboBox2.Text = ""
            ComboBox3.Text = ""
            ComboBox4.Text = ""
            ComboBox5.Text = ""
            ComboBox6.Text = ""
            ComboBox8.Text = ""
            ComboBox9.Text = ""
            ComboBox10.Text = ""
            ComboBox11.Text = ""

            Me.ComboBox7.SelectedIndex = -1
            Me.ComboBox2.SelectedIndex = -1
            Me.ComboBox3.SelectedIndex = -1
            Me.ComboBox4.SelectedIndex = -1
            Me.ComboBox5.SelectedIndex = -1
            Me.ComboBox6.SelectedIndex = -1
            Me.ComboBox8.SelectedIndex = -1
            Me.ComboBox9.SelectedIndex = -1
            Me.ComboBox10.SelectedIndex = -1
            Me.ComboBox11.SelectedIndex = -1

            DateTimePicker1.MinDate = New DateTime(1985, 6, 12)
            DateTimePicker1.MaxDate = DateTime.Today
            DateTimePicker1.Format = DateTimePickerFormat.Short
            DateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd"

        End If
        TextBox1.Text = 0

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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Cuenta_hallazgos = TextBox1.Text
        Hallazgos.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Cuenta_escalamiento = TextBox1.Text
        Escalamientos_anterior.Show()
    End Sub

    Public Sub Duplicidad()
        If TextBox1.Text <> "" Then
            Dim c1 As String
            Dim dt1 As New DataTable
            Dim Cuenta As Integer = TextBox1.Text
            Dim rango As String = Today.Month


            c1 = "SELECT* FROM CONGELACIONES WHERE CUENTA=" & Cuenta & " ORDER BY FECHA_CREACION DESC"
            Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
            adaptadorsql1.Fill(dt1)
            If adaptadorsql1.Fill(dt1) > 0 Then
                MsgBox("Este número de cuenta ya fue gestionado durante el mes actual")

                ComboBox7.DataBindings.Add(New Binding("Text", dt1, "CANAL_INGRESO"))
                DateTimePicker1.DataBindings.Add(New Binding("Text", dt1, "FECHA_CREACION"))
                TextBox4.DataBindings.Add(New Binding("Text", dt1, "USUARIO_E4"))
                ComboBox2.DataBindings.Add(New Binding("Text", dt1, "SERVICIOS"))
                ComboBox3.DataBindings.Add(New Binding("Text", dt1, "MOTIVO_E4"))
                ComboBox4.DataBindings.Add(New Binding("Text", dt1, "MES_CONGELAR"))
                ComboBox5.DataBindings.Add(New Binding("Text", dt1, "GESTION"))
                ComboBox6.DataBindings.Add(New Binding("Text", dt1, "SUB_RAZON"))
                ComboBox8.DataBindings.Add(New Binding("Text", dt1, "ESTADO"))
                ComboBox9.DataBindings.Add(New Binding("Text", dt1, "MOTIVO_ESTADO"))
                TextBox5.DataBindings.Add(New Binding("Text", dt1, "USUARIO_APLICO_E4"))
                ComboBox10.DataBindings.Add(New Binding("Text", dt1, "SERVICIOS_DX"))
                TextBox6.DataBindings.Add(New Binding("Text", dt1, "OBSERVACIONES"))
                TextBox3.DataBindings.Add(New Binding("Text", dt1, "AÑO_CREACION"))
                TextBox7.DataBindings.Add(New Binding("Text", dt1, "MES_CREACION"))
                TextBox8.DataBindings.Add(New Binding("Text", dt1, "DIA_CREACION"))
                ComboBox11.DataBindings.Add(New Binding("Text", dt1, "AJUSTE"))
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox3.Text = ""
        TextBox1.DataBindings.Clear()
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
        ComboBox7.DataBindings.Clear()
        ComboBox8.DataBindings.Clear()
        ComboBox9.DataBindings.Clear()
        ComboBox10.DataBindings.Clear()
        ComboBox11.DataBindings.Clear()

        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
        ComboBox4.SelectedIndex = -1
        ComboBox5.SelectedIndex = -1
        ComboBox6.SelectedIndex = -1
        ComboBox7.SelectedIndex = -1
        ComboBox8.SelectedIndex = -1
        ComboBox9.SelectedIndex = -1
        ComboBox10.SelectedIndex = -1
        ComboBox11.SelectedIndex = -1


        DateTimePicker1.DataBindings.Clear()
        DateTimePicker1.Value = Today

        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
        ComboBox5.Text = ""
        ComboBox6.Text = ""
        ComboBox7.Text = ""
        ComboBox8.Text = ""
        ComboBox9.Text = ""
        ComboBox10.Text = ""
        ComboBox11.Text = ""

        Duplicidad()
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim dt1, dt2, dttable5, dt5 As New DataTable
        Dim c1, c2, consulta25, c5 As String


        Dim Cuenta As Double = TextBox1.Text
        Dim Ingreso As String = ComboBox7.Text
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

        Dim AÑO_CREA As Integer = TextBox3.Text
        Dim MES_CREA As Integer = TextBox7.Text
        Dim DIA_CREA As Integer = TextBox8.Text
        Dim MES_GESTION As Integer = Now.Month
        Dim usuario As String = ""
        Dim dt10 As New DataTable


        c5 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql5 As New SqlDataAdapter(c5, New SqlConnection(coneccion))
        adaptadorsql5.Fill(dt5)
        Dim i As Integer

        For i = 0 To dt5.Rows.Count - 1
            usuario = dt5.Rows(i).Item("Usuario")
        Next


        If (MsgBox("Desea actualizar el  registro?", MsgBoxStyle.YesNo, "Actualizar")) = MsgBoxResult.Yes Then
            c1 = "UPDATE CONGELACIONES SET CANAL_INGRESO='" & Ingreso & "', FECHA_CREACION='" & Fecha_Creacion & "',AÑO_CREACION=" & AÑO_CREA & ",MES_CREACION=" & MES_CREA & ",DIA_CREACION=" & DIA_CREA & ",CUENTA=" & Cuenta & ",SERVICIOS='" & Servicios & "',MOTIVO_E4='" & Motivo & "',USUARIO_E4='" & Usuario_Creacion & "',MES_CONGELAR='" & Mes_Congelar & "',GESTION='" & Gestion & "',SUB_RAZON='" & Sub_Razon & "',ESTADO='" & Estado & "',MOTIVO_ESTADO='" & Motivo_Estado & "',USUARIO_APLICO_E4='" & Usuaio_Aplico_E4 & "',AJUSTE='" & AJUSTE & "',SERVICIOS_DX=" & Servicios_Dx & ",OBSERVACIONES='" & Observaciones & "' where CUENTA= " & Cuenta & " AND FECHA_CREACION='" & Fecha_Creacion & "'"
            Dim adaptadorSQL As New SqlDataAdapter(c1, New SqlConnection(coneccion))
            adaptadorSQL.Fill(dt1)
            MsgBox("Registro Actualizado")

            Dim id As Integer = 3
            Dim proceso As String = "Congelaciones"

            c2 = "UPDATE CONSOLIDADO SET CANAL_INGRESO='" & Ingreso & "',GESTION='" & Gestion & "',SUB_RAZON='" & Sub_Razon & "',SERVICIOS_DX=" & Servicios_Dx & ",OBSERVACIONES='" & Observaciones & "' WHERE CUENTA=" & Cuenta & " AND FECHA_CREACION='" & Fecha_Creacion & "' AND ID_GESTION=" & id & ""
            Dim adaptadorSQL2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
            adaptadorSQL2.Fill(dt2)

            Dim porcen As Decimal
            porcen = 1

            consulta25 = "INSERT INTO PRODUCTIVIDAD (USUARIO,ID_GESTION,FECHA,AÑO,MES,DIA,HORA_GESTION,CUENTA,PROCESO,PORCENTAJE)VALUES('" & usuario & "'," & id & ",getdate()," & AÑO & "," & MES & "," & DIA & ",getdate()," & Cuenta & ", '" & proceso & "'," & porcen & ")"
            Dim adaptadorSQL25 As New SqlDataAdapter(consulta25, New SqlConnection(coneccion))
            adaptadorSQL25.Fill(dttable5)


            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox3.Text = ""
            TextBox7.Text = ""
            TextBox8.Text = ""

            TextBox1.DataBindings.Clear()
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
            ComboBox7.DataBindings.Clear()
            ComboBox8.DataBindings.Clear()
            ComboBox9.DataBindings.Clear()
            ComboBox10.DataBindings.Clear()
            ComboBox11.DataBindings.Clear()

            ComboBox2.Text = ""
            ComboBox3.Text = ""
            ComboBox4.Text = ""
            ComboBox5.Text = ""
            ComboBox6.Text = ""
            ComboBox7.Text = ""
            ComboBox8.Text = ""
            ComboBox9.Text = ""
            ComboBox10.Text = ""
            ComboBox11.Text = ""

            Me.ComboBox7.SelectedIndex = -1
            Me.ComboBox2.SelectedIndex = -1
            Me.ComboBox3.SelectedIndex = -1
            Me.ComboBox4.SelectedIndex = -1
            Me.ComboBox5.SelectedIndex = -1
            Me.ComboBox6.SelectedIndex = -1
            Me.ComboBox8.SelectedIndex = -1
            Me.ComboBox9.SelectedIndex = -1
            Me.ComboBox10.SelectedIndex = -1
            Me.ComboBox11.SelectedIndex = -1

            DateTimePicker1.DataBindings.Clear()
            DateTimePicker1.Value = Today
        Else
            Exit Sub
        End If

    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        TextBox3.DataBindings.Clear()
        TextBox7.DataBindings.Clear()
        TextBox8.DataBindings.Clear()
        TextBox3.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox3.Text = DateTimePicker1.Value.Year
        TextBox7.Text = DateTimePicker1.Value.Month
        TextBox8.Text = DateTimePicker1.Value.Day
    End Sub
    Public Sub Validador_Servicios()
        If ComboBox10.Text <> "" Then
            If ComboBox10.SelectedItem >= 4 Then
                MsgBox("Servicios Errados")
            End If
        End If

    End Sub

    Private Sub ComboBox10_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox10.LostFocus
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

    Private Sub ComboBox7_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox7.LostFocus
        Try
            If ComboBox7.Text = "" Then
                MsgBox("Este campo no puede quedar vacio")
                ComboBox7.BackColor = Color.Red
                ComboBox7.ForeColor = Color.White
            Else
                If ComboBox7.SelectedIndex = -1 Then
                    MsgBox("Este campo no puede quedar vacio")
                    ComboBox7.BackColor = Color.Red
                    ComboBox7.ForeColor = Color.White
                Else
                    ComboBox7.BackColor = Color.WhiteSmoke
                    ComboBox7.ForeColor = Color.Black
                End If
            End If
        Finally
        End Try
    End Sub
End Class