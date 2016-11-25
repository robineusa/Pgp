Imports System.Data.SqlClient

Public Class Desconexiones_Ingreso

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
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
        ComboBox6.DataBindings.Clear()

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
        TextBox15.Text = ""
        TextBox16.Text = ""
        TextBox17.Text = ""
        ComboBox6.Text = ""


        ComboBox1.DataBindings.Clear()
        ComboBox2.DataBindings.Clear()
        ComboBox4.DataBindings.Clear()
        ComboBox5.DataBindings.Clear()
        ComboBox3.DataBindings.Clear()

        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox4.Text = ""
        ComboBox5.Text = ""
        ComboBox3.Text = ""

        If TextBox1.Text <> "" Then


            Dim CUENTA As Double = TextBox1.Text
            Dim c1 As String
            Dim dttable As New DataTable
            Dim MES As Integer = Now.Month

            c1 = "SELECT * FROM DESCONEXIONES WHERE CUENTA=" & CUENTA & " AND MES_GESTION=" & MES & ""
            Dim adaptadorSQL As New SqlDataAdapter(c1, New SqlConnection(coneccion))
            adaptadorSQL.Fill(dttable)

            If adaptadorSQL.Fill(dttable) = False Then
                
            Else
                ComboBox6.DataBindings.Add(New Binding("Text", dttable, "CANAL_INGRESO"))
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
                TextBox15.DataBindings.Add(New Binding("Text", dttable, "FECHA_SOLICITUD"))
                TextBox16.DataBindings.Add(New Binding("Text", dttable, "FECHA_CORTE"))
                TextBox17.DataBindings.Add(New Binding("Text", dttable, "FECHA_PREAVISO"))
                TextBox6.DataBindings.Add(New Binding("Text", dttable, "DIA_DX"))
                TextBox14.DataBindings.Add(New Binding("Text", dttable, "TARIFA_ANTERIOR"))
                ComboBox1.DataBindings.Add(New Binding("Text", dttable, "GESTION"))
                ComboBox2.DataBindings.Add(New Binding("Text", dttable, "RAZON"))
                TextBox12.DataBindings.Add(New Binding("Text", dttable, "MOVIE_LETTER"))
                ComboBox4.DataBindings.Add(New Binding("Text", dttable, "AJUSTE"))
                ComboBox5.DataBindings.Add(New Binding("Text", dttable, "CANTIDAD_SERVICIOS"))
                TextBox13.DataBindings.Add(New Binding("Text", dttable, "OBSERVACIONES"))
                ComboBox3.DataBindings.Add(New Binding("Text", dttable, "PROCESO_RETENCION"))
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
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
        Dim Fecha_Sol As String = TextBox15.Text
        Dim Fecha_Corte As String = TextBox16.Text
        Dim Fecha_Preav As String = TextBox17.Text
        Dim Dia_DX As Integer = TextBox6.Text
        Dim Gestion As String = ComboBox1.Text
        Dim Subrazon As String = ComboBox2.Text
        Dim Movie As Double = TextBox12.Text
        Dim Ajuste As String = ComboBox4.Text
        Dim Cant_serv As Integer = ComboBox5.Text
        Dim Observ As String = TextBox13.Text
        Dim proceso_retencion As String = ComboBox3.Text
        Dim CANAL_INGRESO As String = ComboBox6.Text
        Dim TARIFA_ANTERIOR As String = TextBox14.Text


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
            consulta4 = "INSERT INTO DESCONEXIONES (USUARIO ,FECHA_GESTION ,AÑO_GESTION,MES_GESTION,DIA_GESTION,HORA_GESTION,CANAL_INGRESO,CUENTA ,MOTIVO_DX ,CODIGO ,NOTA1 ,NOTA2 ,NOTA3 ,NOTA4 ,NOTA5 ,RED ,SERVICIOS,FECHA_SOLICITUD ,FECHA_CORTE ,FECHA_PREAVISO ,DIA_DX ,TARIFA_ANTERIOR,GESTION ,RAZON ,MOVIE_LETTER ,AJUSTE ,CANTIDAD_SERVICIOS ,OBSERVACIONES,PROCESO_RETENCION) Values('" & usuario & "',getdate()," & AÑO & " ," & MES & "," & DIA & ",getdate(),'" & CANAL_INGRESO & "'," & Cuenta & ",'" & Motivo_Dx & "','" & Codigo & "','" & Nota1 & "','" & Nota2 & "','" & Nota3 & "','" & Nota4 & "','" & Nota5 & "','" & Red & "','" & Servicios & "','" & Fecha_Sol & "','" & Fecha_Corte & "','" & Fecha_Preav & "'," & Dia_DX & ",'" & TARIFA_ANTERIOR & "','" & Gestion & "','" & Subrazon & "'," & Movie & ",'" & Ajuste & "'," & Cant_serv & ",'" & Observ & "','" & proceso_retencion & "')"
            Dim adaptadorSQL4 As New SqlDataAdapter(consulta4, New SqlConnection(coneccion))
            adaptadorSQL4.Fill(dttable4)

            Dim id As Integer = 4
            Dim proceso As String = "Desconexion de Servicios"
            consulta5 = "INSERT INTO CONSOLIDADO(ID_GESTION,CUENTA,CANAL_INGRESO,FECHA_CREACION,PROCESO,GESTION,SUB_RAZON,SERVICIOS_DX,FECHA_GESTION,AÑO_GESTION,MES_GESTION,DIA_GESTION,HORA_GESTION,USUARIO,OBSERVACIONES) VALUES(" & id & ", " & Cuenta & ",'" & CANAL_INGRESO & "','" & Fecha_Sol & "','" & proceso & "','" & Gestion & "','" & Subrazon & "'," & Cant_serv & ",getdate()," & AÑO & "," & MES & "," & DIA & ",getdate(), '" & usuario & "','" & Observ & "')"
            Dim adaptadorSQL5 As New SqlDataAdapter(consulta5, New SqlConnection(coneccion))
            adaptadorSQL5.Fill(dttable5)

            Dim porcen As Decimal
            porcen = 1

            Dim id2 As Integer = 12

            consulta25 = "INSERT INTO PRODUCTIVIDAD (USUARIO,ID_GESTION,FECHA,AÑO,MES,DIA,HORA_GESTION,CUENTA,PROCESO,PORCENTAJE)VALUES('" & usuario & "'," & id2 & ",getdate()," & AÑO & "," & MES & "," & DIA & ",getdate()," & Cuenta & ", '" & proceso & "'," & porcen & ")"
            Dim adaptadorSQL25 As New SqlDataAdapter(consulta25, New SqlConnection(coneccion))
            adaptadorSQL25.Fill(dttable5)
            MsgBox("Registro Almacenado")

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
            ComboBox6.DataBindings.Clear()

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
            TextBox15.Text = ""
            TextBox16.Text = ""
            TextBox17.Text = ""
            ComboBox6.Text = ""



            ComboBox1.DataBindings.Clear()
            ComboBox2.DataBindings.Clear()
            ComboBox4.DataBindings.Clear()
            ComboBox5.DataBindings.Clear()
            ComboBox3.DataBindings.Clear()

            Me.ComboBox1.SelectedIndex = -1
            Me.ComboBox2.SelectedIndex = -1
            Me.ComboBox3.SelectedIndex = -1
            Me.ComboBox4.SelectedIndex = -1
            Me.ComboBox5.SelectedIndex = -1
            Me.ComboBox6.SelectedIndex = -1


            ComboBox1.Text = ""
            ComboBox2.Text = ""
            ComboBox4.Text = ""
            ComboBox5.Text = ""
            ComboBox3.Text = ""
        Else
            Exit Sub
        End If

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

    Private Sub Desconexiones_Ingreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim dttable4, dttable5, dttable25, dt5 As New DataTable
        Dim consulta4, consulta5, consulta25, c5 As String

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
        Dim Fecha_Sol As String = TextBox15.Text
        Dim Fecha_Corte As String = TextBox16.Text
        Dim Fecha_Preav As String = TextBox17.Text
        Dim Dia_DX As Integer = TextBox6.Text
        Dim Gestion As String = ComboBox1.Text
        Dim Subrazon As String = ComboBox2.Text
        Dim Movie As Double = TextBox12.Text
        Dim Ajuste As String = ComboBox4.Text
        Dim Cant_serv As Integer = ComboBox5.Text
        Dim Observ As String = TextBox13.Text
        Dim proceso_retencion As String = ComboBox3.Text
        Dim CANAL_INGRESO As String = ComboBox6.Text
        Dim usuario As String = ""
        Dim TARIFA_ANTERIOR As String = TextBox14.Text
        Dim MES As Integer = Now.Month


        c5 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql55 As New SqlDataAdapter(c5, New SqlConnection(coneccion))
        adaptadorsql55.Fill(dt5)
        Dim i As Integer

        For i = 0 To dt5.Rows.Count - 1
            usuario = dt5.Rows(i).Item("Usuario")
        Next

        consulta4 = "UPDATE DESCONEXIONES SET CANAL_INGRESO='" & CANAL_INGRESO & "',MOTIVO_DX='" & Motivo_Dx & "' ,CODIGO= " & Codigo & " ,NOTA1='" & Nota1 & "' ,NOTA2='" & Nota2 & "' ,NOTA3='" & Nota3 & "' ,NOTA4= '" & Nota4 & "' ,NOTA5=" & Nota5 & ",RED='" & Red & "' ,SERVICIOS='" & Servicios & "',FECHA_SOLICITUD='" & Fecha_Sol & "' ,FECHA_CORTE='" & Fecha_Corte & "' ,FECHA_PREAVISO='" & Fecha_Preav & "',DIA_DX=" & Dia_DX & ",TARIFA_ANTERIOR='" & TARIFA_ANTERIOR & "',GESTION='" & Gestion & "',RAZON='" & Subrazon & "' ,MOVIE_LETTER=" & Movie & " ,AJUSTE='" & Ajuste & "' ,CANTIDAD_SERVICIOS=" & Cant_serv & " ,OBSERVACIONES='" & Observ & "',PROCESO_RETENCION='" & proceso_retencion & "' WHERE CUENTA=" & Cuenta & " AND MES_GESTION=" & MES & ""
        Dim adaptadorSQL4 As New SqlDataAdapter(consulta4, New SqlConnection(coneccion))
        adaptadorSQL4.Fill(dttable4)

        Dim id As Integer = 4
        Dim proceso As String = "Desconexion de Servicios"
        consulta5 = "UPDATE CONSOLIDADO SET CANAL_INGRESO='" & CANAL_INGRESO & "',GESTION='" & Gestion & "',SUB_RAZON='" & Subrazon & "',SERVICIOS_DX=" & Cant_serv & ", OBSERVACIONES='" & Observ & "' WHERE CUENTA=" & Cuenta & " AND FECHA_CREACION='" & Fecha_Sol & "' AND ID_GESTION=" & id & ""
        Dim adaptadorSQL5 As New SqlDataAdapter(consulta5, New SqlConnection(coneccion))
        adaptadorSQL5.Fill(dttable5)

        Dim porcen As Decimal
        porcen = 1
        consulta25 = "INSERT INTO PRODUCTIVIDAD (USUARIO,ID_GESTION,FECHA,AÑO,MES,DIA,HORA_GESTION,CUENTA,PROCESO,PORCENTAJE)VALUES('" & usuario & "'," & id & ",getdate()," & AÑO & "," & MES & "," & DIA & ",getdate()," & Cuenta & ", '" & proceso & "'," & porcen & ")"
        Dim adaptadorSQL25 As New SqlDataAdapter(consulta25, New SqlConnection(coneccion))
        adaptadorSQL25.Fill(dttable5)
        MsgBox("Registro Actualizado")

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
        ComboBox6.DataBindings.Clear()

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
        TextBox15.Text = ""
        TextBox16.Text = ""
        TextBox17.Text = ""
        ComboBox6.Text = ""


        ComboBox1.DataBindings.Clear()
        ComboBox2.DataBindings.Clear()
        ComboBox4.DataBindings.Clear()
        ComboBox5.DataBindings.Clear()
        ComboBox3.DataBindings.Clear()

        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox4.Text = ""
        ComboBox5.Text = ""
        ComboBox3.Text = ""
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Cuenta_escalamiento = TextBox1.Text
        Escalamientos_anterior.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Cuenta_hallazgos = TextBox1.Text
        Hallazgos.Show()
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