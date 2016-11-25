Imports System.Data.SqlClient

Public Class Liberaciones

    Private Sub Liberaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label25.Text = nombreusuario
        DateTimePicker1.MinDate = New DateTime(1985, 6, 12)
        DateTimePicker1.MaxDate = DateTime.Today
        DateTimePicker1.Format = DateTimePickerFormat.Short
        DateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd"

        Dim ID_MACROPROCESO = 6
        Dim c1 As String
        Dim dt1 As New DataTable

        c1 = "SELECT NOMBRE_SUB_PROCESO FROM SUB_PROCESOS WHERE ID_MACROPROCESO =" & ID_MACROPROCESO & ""
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt1)

        Dim i As Integer

        For i = 0 To dt1.Rows.Count - 1
            ComboBox6.Items.Add(dt1.Rows(i).Item("NOMBRE_SUB_PROCESO"))
        Next

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dttable4, dttable5, dttable25 As New DataTable
        Dim consulta4, consulta5, consulta25 As String

        Dim Cuenta As Double = TextBox1.Text
        Dim Registro As Double = TextBox2.Text
        Dim Canal_Ingreso As String = ComboBox1.Text
        Dim Persona_Evia As String = TextBox3.Text
        Dim Numero_Servicios As Integer = ComboBox2.Text
        Dim Fecha_Solicitud As String = DateTimePicker1.Text
        Dim Solicitud_Modulo As String = ComboBox3.Text
        Dim Solicitud_Cancelacion As String = ComboBox4.Text
        Dim Motivo_Dx As String = ComboBox5.Text
        Dim Vendedor As String = TextBox4.Text
        Dim Grupo As String = ComboBox9.Text
        Dim gestion As String = ComboBox6.Text
        Dim Razon1 As String = ComboBox7.Text
        Dim Motivo_liberacion As String = ComboBox8.Text
        Dim Usuario_Libero As String = TextBox6.Text
        Dim Observaciones As String = TextBox7.Text

        Dim AÑO_CREA As Integer = TextBox5.Text
        Dim MES_CREA As Integer = TextBox8.Text
        Dim DIA_CREA As Integer = TextBox9.Text

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

            Dim id As Integer = 5
            Dim proceso As String = "Liberaciones de Home Pass"

            consulta4 = "INSERT INTO LIBERACIONES ( REGISTRO ,CUENTA ,CANAL_INGRESO ,PER_ENVIA ,NUM_SERVICIOS ,FECHA_SOLICITUD ,AÑO_SOLICITUD,MES_SOLICITUD,DIA_SOLICITUD,FECHA_GESTION,AÑO_GESTION,MES_GESTION,DIA_GESTION,HORA_GESTION ,USUARIO ,REGISTRO_MODULO ,SOLICITUD_CANCELACION ,MOTIVO_DX ,VENDEDOR ,GRUPO ,GESTION ,RAZON ,MOTIVO_LIBERACION ,USUARIO_LIBERO ,OBSERVACIONES )VALUES(" & Registro & "," & Cuenta & ",'" & Canal_Ingreso & "','" & Persona_Evia & "'," & Numero_Servicios & ",'" & Fecha_Solicitud & "'," & AÑO_CREA & "," & MES_CREA & "," & DIA_CREA & ",getdate()," & AÑO & "," & MES & "," & DIA & ",getdate(),'" & dato1 & "','" & Solicitud_Modulo & "','" & Solicitud_Cancelacion & "','" & Motivo_Dx & "','" & Vendedor & "','" & Grupo & "','" & gestion & "','" & Razon1 & "','" & Motivo_liberacion & "','" & Usuario_Libero & "','" & Observaciones & "')"
            Dim adaptadorSQL4 As New SqlDataAdapter(consulta4, New SqlConnection(coneccion))
            adaptadorSQL4.Fill(dttable4)

            consulta5 = "INSERT INTO CONSOLIDADO(ID_GESTION,CUENTA,CANAL_INGRESO,FECHA_CREACION,PROCESO,GESTION,SUB_RAZON,SERVICIOS_DX,FECHA_GESTION,AÑO_GESTION,MES_GESTION,DIA_GESTION,HORA_GESTION,USUARIO,OBSERVACIONES) VALUES(" & id & ", " & Cuenta & ",'" & Canal_Ingreso & "','" & Fecha_Solicitud & "','" & proceso & "','" & gestion & "','" & Razon1 & "'," & Numero_Servicios & ",getdate()," & AÑO & "," & MES & "," & DIA & ",getdate(), '" & dato1 & "','" & Observaciones & "')"
            Dim adaptadorSQL5 As New SqlDataAdapter(consulta5, New SqlConnection(coneccion))
            adaptadorSQL5.Fill(dttable5)

            Dim porcen As Decimal
            porcen = 1
            consulta25 = "INSERT INTO PRODUCTIVIDAD (USUARIO,ID_GESTION,FECHA,AÑO,MES,DIA,HORA_GESTION,CUENTA,PROCESO,PORCENTAJE)VALUES('" & dato1 & "'," & id & ",getdate()," & AÑO & "," & MES & "," & DIA & ",getdate()," & Cuenta & ", '" & proceso & "'," & porcen & ")"
            Dim adaptadorSQL25 As New SqlDataAdapter(consulta25, New SqlConnection(coneccion))
            adaptadorSQL25.Fill(dttable5)
            MsgBox("Registro almacedado")
        End If
        limpiar(Me)
        TextBox1.Text = 0
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox9.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
        ComboBox5.Text = ""
        ComboBox6.Text = ""
        ComboBox7.Text = ""
        ComboBox8.Text = ""

        Me.ComboBox1.SelectedIndex = -1
        Me.ComboBox2.SelectedIndex = -1
        Me.ComboBox3.SelectedIndex = -1
        Me.ComboBox4.SelectedIndex = -1
        Me.ComboBox5.SelectedIndex = -1
        Me.ComboBox6.SelectedIndex = -1
        Me.ComboBox7.SelectedIndex = -1
        Me.ComboBox8.SelectedIndex = -1
        Me.ComboBox9.SelectedIndex = -1


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Cuenta_hallazgos = TextBox1.Text
        Hallazgos.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Cuenta_escalamiento = TextBox1.Text
        Escalamientos_anterior.Show()
    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox6.SelectedIndexChanged
        ComboBox6.DataBindings.Clear()
        ComboBox7.DataBindings.Clear()
        ComboBox7.Text = ""
        ComboBox7.Items.Clear()


        Dim c1, c2 As String
        Dim dt1, dt2 As New DataTable
        Dim sub_proceso As Integer
        Dim nombre_sub_proceso As String = ComboBox6.Text


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
            ComboBox7.Items.Add(dt1.Rows(i).Item("NOMBRE_PROCESO"))
        Next
    End Sub

    Public Sub Duplicidad()
        Dim c1 As String
        Dim dt1 As New DataTable
        Dim Cuenta As Integer = TextBox1.Text

        If TextBox1.Text = "" Then
            Exit Sub
        Else
            c1 = "SELECT* FROM LIBERACIONES WHERE Cuenta=" & Cuenta & ""
            Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
            adaptadorsql1.Fill(dt1)
            If adaptadorsql1.Fill(dt1) > 0 Then
                MsgBox("Este número de cuenta ya fue gestionado")
            Else
            End If
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        TextBox5.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""

        TextBox5.Text = DateTimePicker1.Value.Year
        TextBox8.Text = DateTimePicker1.Value.Month
        TextBox9.Text = DateTimePicker1.Value.Day
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox9.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox5.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
        ComboBox5.Text = ""
        ComboBox6.Text = ""
        ComboBox7.Text = ""
        ComboBox8.Text = ""

        TextBox2.DataBindings.Clear()
        TextBox3.DataBindings.Clear()
        TextBox4.DataBindings.Clear()
        TextBox5.DataBindings.Clear()
        TextBox6.DataBindings.Clear()
        TextBox7.DataBindings.Clear()
        TextBox8.DataBindings.Clear()
        TextBox9.DataBindings.Clear()

        ComboBox1.DataBindings.Clear()
        ComboBox2.DataBindings.Clear()
        ComboBox3.DataBindings.Clear()
        ComboBox4.DataBindings.Clear()
        ComboBox5.DataBindings.Clear()
        ComboBox6.DataBindings.Clear()
        ComboBox7.DataBindings.Clear()
        ComboBox8.DataBindings.Clear()
        ComboBox9.DataBindings.Clear()

        DateTimePicker1.DataBindings.Clear()
        DateTimePicker1.Value = Today

        If TextBox1.Text <> "" Then

            Dim CUENTA As Double = TextBox1.Text
            Dim c1, c2 As String
            Dim dt1, dt2 As New DataTable
            Dim MES_SOLICITUD As Integer = 0

            c2 = "SELECT MES_SOLICITUD FROM LIBERACIONES WHERE CUENTA =" & CUENTA & ""
            Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
            adaptadorsql2.Fill(dt2)

            For i = 0 To dt2.Rows.Count - 1
                MES_SOLICITUD = dt2.Rows(i).Item("MES_SOLICITUD")
            Next

            c1 = "SELECT * FROM LIBERACIONES WHERE CUENTA =" & CUENTA & " AND MES_SOLICITUD=" & MES_SOLICITUD & ""
            Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
            adaptadorsql1.Fill(dt1)

            TextBox2.DataBindings.Add(New Binding("Text", dt1, "REGISTRO"))
            ComboBox1.DataBindings.Add(New Binding("Text", dt1, "CANAL_INGRESO"))
            TextBox3.DataBindings.Add(New Binding("Text", dt1, "PER_ENVIA"))
            ComboBox2.DataBindings.Add(New Binding("Text", dt1, "NUM_SERVICIOS"))
            DateTimePicker1.DataBindings.Add(New Binding("Text", dt1, "FECHA_SOLICITUD"))
            TextBox5.DataBindings.Add(New Binding("Text", dt1, "AÑO_SOLICITUD"))
            TextBox8.DataBindings.Add(New Binding("Text", dt1, "MES_SOLICITUD"))
            TextBox9.DataBindings.Add(New Binding("Text", dt1, "DIA_SOLICITUD"))
            ComboBox3.DataBindings.Add(New Binding("Text", dt1, "REGISTRO_MODULO"))
            ComboBox4.DataBindings.Add(New Binding("Text", dt1, "SOLICITUD_CANCELACION"))
            ComboBox5.DataBindings.Add(New Binding("Text", dt1, "MOTIVO_DX"))
            TextBox4.DataBindings.Add(New Binding("Text", dt1, "VENDEDOR"))
            ComboBox9.DataBindings.Add(New Binding("Text", dt1, "GRUPO"))
            ComboBox6.DataBindings.Add(New Binding("Text", dt1, "GESTION"))
            ComboBox7.DataBindings.Add(New Binding("Text", dt1, "RAZON"))
            ComboBox8.DataBindings.Add(New Binding("Text", dt1, "MOTIVO_LIBERACION"))
            TextBox6.DataBindings.Add(New Binding("Text", dt1, "USUARIO_LIBERO"))
            TextBox7.DataBindings.Add(New Binding("Text", dt1, "OBSERVACIONES"))
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click


        Dim Cuenta As Double = TextBox1.Text
        Dim Registro As Double = TextBox2.Text
        Dim Canal_Ingreso As String = ComboBox1.Text
        Dim Persona_Evia As String = TextBox3.Text
        Dim Numero_Servicios As Integer = ComboBox2.Text
        Dim Fecha_Solicitud As String = DateTimePicker1.Text
        Dim Solicitud_Modulo As String = ComboBox3.Text
        Dim Solicitud_Cancelacion As String = ComboBox4.Text
        Dim Motivo_Dx As String = ComboBox5.Text
        Dim Vendedor As String = TextBox4.Text
        Dim Grupo As String = ComboBox9.Text
        Dim gestion As String = ComboBox6.Text
        Dim Razon1 As String = ComboBox7.Text
        Dim Motivo_liberacion As String = ComboBox8.Text
        Dim Usuario_Libero As String = TextBox6.Text
        Dim Observaciones As String = TextBox7.Text

        If TextBox1.Text <> "" Then

            Dim AÑO_CREA As Integer = TextBox5.Text
            Dim MES_CREA As Integer = TextBox8.Text
            Dim DIA_CREA As Integer = TextBox9.Text

            Dim dato1 As String = ""
            Dim dt10, dt2, dt3, dt4, dt8 As New DataTable
            Dim c1, c2, c3, c4, c8 As String

            c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
            Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
            adaptadorsql1.Fill(dt10)
            Dim i As Integer

            For i = 0 To dt10.Rows.Count - 1
                dato1 = dt10.Rows(i).Item("Usuario")
            Next

            Dim id As Integer = 5
            Dim proceso As String = "Liberaciones de Home Pass"
            Dim MES_SOLICITUD As Integer = 0

            c8 = "SELECT MES_SOLICITUD FROM LIBERACIONES WHERE CUENTA =" & Cuenta & ""
            Dim adaptadorsql8 As New SqlDataAdapter(c8, New SqlConnection(coneccion))
            adaptadorsql8.Fill(dt8)

            For j = 0 To dt8.Rows.Count - 1
                MES_SOLICITUD = dt8.Rows(j).Item("MES_SOLICITUD")
            Next

            c2 = "UPDATE LIBERACIONES SET REGISTRO=" & Registro & ",CANAL_INGRESO='" & Canal_Ingreso & "' ,PER_ENVIA='" & Persona_Evia & "' ,NUM_SERVICIOS=" & Numero_Servicios & " ,FECHA_SOLICITUD='" & Fecha_Solicitud & "' ,AÑO_SOLICITUD=" & AÑO & ",MES_SOLICITUD= " & MES & ",DIA_SOLICITUD=" & DIA & ",REGISTRO_MODULO='" & Solicitud_Modulo & "',SOLICITUD_CANCELACION='" & Solicitud_Cancelacion & "',MOTIVO_DX='" & Motivo_Dx & "' ,VENDEDOR='" & Vendedor & "' ,GRUPO='" & Grupo & "' ,GESTION='" & gestion & "' ,RAZON='" & Razon1 & "' ,MOTIVO_LIBERACION='" & Motivo_liberacion & "' ,USUARIO_LIBERO='" & Usuario_Libero & "' ,OBSERVACIONES='" & Observaciones & "' WHERE CUENTA = " & Cuenta & " AND MES_SOLICITUD=" & MES_SOLICITUD & ""
            Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
            adaptadorsql2.Fill(dt2)

            c3 = "UPDATE CONSOLIDADO SET CANAL_INGRESO='" & Canal_Ingreso & "',GESTION='" & gestion & "',SUB_RAZON='" & Razon1 & "',SERVICIOS_DX=" & Numero_Servicios & ", OBSERVACIONES='" & Observaciones & "' WHERE CUENTA=" & Cuenta & " AND FECHA_CREACION='" & Fecha_Solicitud & "' AND ID_GESTION=" & id & ""
            Dim adaptadorsql3 As New SqlDataAdapter(c3, New SqlConnection(coneccion))
            adaptadorsql3.Fill(dt3)

            Dim porcen As Decimal
            porcen = 1

            c4 = "INSERT INTO PRODUCTIVIDAD (USUARIO,ID_GESTION,FECHA,AÑO,MES,DIA,HORA_GESTION,CUENTA,PROCESO,PORCENTAJE)VALUES('" & dato1 & "'," & id & ",getdate()," & AÑO & "," & MES & "," & DIA & ",getdate()," & Cuenta & ", '" & proceso & "'," & porcen & ")"
            Dim adaptadorsql4 As New SqlDataAdapter(c4, New SqlConnection(coneccion))
            adaptadorsql4.Fill(dt4)
            MsgBox("Registro Almacenado")

            TextBox1.Text = 0
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            ComboBox9.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""
            TextBox8.Text = ""
            TextBox9.Text = ""
            TextBox5.Text = ""
            ComboBox1.Text = ""
            ComboBox2.Text = ""
            ComboBox3.Text = ""
            ComboBox4.Text = ""
            ComboBox5.Text = ""
            ComboBox6.Text = ""
            ComboBox7.Text = ""
            ComboBox8.Text = ""
            Me.ComboBox1.SelectedIndex = -1
            Me.ComboBox2.SelectedIndex = -1
            Me.ComboBox3.SelectedIndex = -1
            Me.ComboBox4.SelectedIndex = -1
            Me.ComboBox5.SelectedIndex = -1
            Me.ComboBox6.SelectedIndex = -1
            Me.ComboBox7.SelectedIndex = -1
            Me.ComboBox8.SelectedIndex = -1
            Me.ComboBox9.SelectedIndex = -1

        End If

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.LostFocus
        Try
            If ComboBox2.Text = "" Then
                MsgBox("Este campo no puede quedar vacio")
                ComboBox2.BackColor = Color.Red
                ComboBox2.ForeColor = Color.White
            Else
                If ComboBox2.Text >= 4 Then
                    MsgBox("Numero de servicios invalido")
                    ComboBox2.BackColor = Color.Red
                    ComboBox2.ForeColor = Color.White
                Else
                    ComboBox2.BackColor = Color.WhiteSmoke
                    ComboBox2.ForeColor = Color.Black
                End If
            End If
        Finally
        End Try
    End Sub
End Class