Imports System.Data.SqlClient

Public Class Posventas_Ingreso

    Private Sub Posventas_Ingreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label33.Text = nombreusuario

        DateTimePicker1.MinDate = New DateTime(1985, 6, 12)
        DateTimePicker1.MaxDate = DateTime.Today
        DateTimePicker1.Format = DateTimePickerFormat.Short
        DateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd"

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim dttable4, dttable5, dttable25 As New DataTable
            Dim consulta4, consulta5, consulta25 As String
            Dim Cuenta As Double = TextBox1.Text
            Dim Orden As Double = TextBox2.Text
            Dim Rango_Dias As Integer = TextBox3.Text
            Dim Tipo_Trabajo As String = TextBox4.Text
            Dim Usu_Creacion As String = TextBox5.Text
            Dim Fecha_Creacion As String = DateTimePicker1.Text
            Dim Estado_Orden As String = ComboBox1.Text
            Dim Tipo_Orden As String = ComboBox2.Text
            Dim Motivo_Orden As String = ""
            Dim Num_Servicios As Integer = ComboBox9.Text
            Dim Observaciones As String = TextBox6.Text
            Dim AÑO_CREACION As String = DateTimePicker1.Value.Year
            Dim MES_CREACION As Integer = DateTimePicker1.Value.Month
            Dim DIA_CREACION As Integer = DateTimePicker1.Value.Day
            Dim CANAL_INGRESO As String = ComboBox10.Text

            Dim dato1 As String = ""
            Dim dt10 As New DataTable
            Dim c1 As String
            Dim proceso As String = "Posventas"


            c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
            Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
            adaptadorsql1.Fill(dt10)
            Dim i As Integer

            For i = 0 To dt10.Rows.Count - 1
                dato1 = dt10.Rows(i).Item("Usuario")
            Next

            If ComboBox3.Visible = True Then
                Motivo_Orden = ComboBox3.Text
            Else
                If ComboBox4.Visible = True Then
                    Motivo_Orden = ComboBox4.Text
                Else
                    If ComboBox5.Visible = True Then
                        Motivo_Orden = ComboBox5.Text
                    Else
                        If ComboBox6.Visible = True Then
                            Motivo_Orden = ComboBox6.Text
                        Else
                            If ComboBox7.Visible = True Then
                                Motivo_Orden = ComboBox7.Text
                            Else
                                If ComboBox8.Visible = True Then
                                    Motivo_Orden = ComboBox8.Text

                                End If
                            End If
                        End If
                    End If
                End If

            End If

            If (MsgBox("Desea Guardar Registro?", MsgBoxStyle.YesNo, "Guardar")) = MsgBoxResult.Yes Then
                consulta4 = "INSERT INTO POSVENTAS (Fecha_Gestion ,AÑO_GESTION,MES_GESTION,DIA_GESTION,Hora_Gestion ,Usuario ,Cuenta ,Orden ,CANAL_INGRESO,Rango_Dias ,Tipo_Trabajo ,Usu_Creacion ,Fecha_Creacion ,AÑO_CREACION,MES_CREACION,DIA_CREACION,Estado_Orden ,Tipo_Orden ,Motivo_Orden ,Num_Servicios ,Observaciones )VALUES(GETDATE()," & AÑO & "," & MES & "," & DIA & ",GETDATE(),'" & dato1 & "'," & Cuenta & "," & Orden & ",'" & CANAL_INGRESO & "'," & Rango_Dias & ",'" & Tipo_Trabajo & "','" & Usu_Creacion & "','" & Fecha_Creacion & "'," & AÑO_CREACION & "," & MES_CREACION & "," & DIA_CREACION & ",'" & Estado_Orden & "','" & Tipo_Orden & "','" & Motivo_Orden & "'," & Num_Servicios & ",'" & Observaciones & "')"
                Dim adaptadorSQL4 As New SqlDataAdapter(consulta4, New SqlConnection(coneccion))
                adaptadorSQL4.Fill(dttable4)

                Dim id As Integer = 6

                consulta5 = "INSERT INTO CONSOLIDADO(ID_GESTION,CUENTA,CANAL_INGRESO,FECHA_CREACION,PROCESO,GESTION,SUB_RAZON,SERVICIOS_DX,FECHA_GESTION,AÑO_GESTION,MES_GESTION,DIA_GESTION,HORA_GESTION,USUARIO,OBSERVACIONES) VALUES(" & id & ", " & Cuenta & ",'" & CANAL_INGRESO & "','" & Fecha_Creacion & "','" & proceso & "','" & Tipo_Orden & "','" & Motivo_Orden & "'," & Num_Servicios & ",getdate()," & AÑO & "," & MES & "," & DIA & ",getdate(), '" & dato1 & "','" & Observaciones & "')"
                Dim adaptadorSQL5 As New SqlDataAdapter(consulta5, New SqlConnection(coneccion))
                adaptadorSQL5.Fill(dttable5)

                Dim porcen As Integer
                porcen = 1.2

                Dim id2 As Integer = 12

                consulta25 = "INSERT INTO PRODUCTIVIDAD (USUARIO,ID_GESTION,FECHA,AÑO,MES,DIA,HORA_GESTION,CUENTA,PROCESO,PORCENTAJE)VALUES('" & dato1 & "'," & id2 & ",getdate()," & AÑO & "," & MES & "," & DIA & ",getdate()," & Cuenta & ", '" & proceso & "'," & porcen & ")"
                Dim adaptadorSQL25 As New SqlDataAdapter(consulta25, New SqlConnection(coneccion))
                adaptadorSQL25.Fill(dttable5)

                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox6.Text = ""
                TextBox1.DataBindings.Clear()
                TextBox2.DataBindings.Clear()
                TextBox3.DataBindings.Clear()
                TextBox4.DataBindings.Clear()
                TextBox5.DataBindings.Clear()
                TextBox6.DataBindings.Clear()

                ComboBox1.Text = ""
                ComboBox2.Text = ""
                ComboBox3.Text = ""
                ComboBox4.Text = ""
                ComboBox5.Text = ""
                ComboBox6.Text = ""
                ComboBox7.Text = ""
                ComboBox8.Text = ""
                ComboBox9.Text = ""
                ComboBox10.Text = ""

                Me.ComboBox1.SelectedIndex = -1
                Me.ComboBox2.SelectedIndex = -1
                Me.ComboBox3.SelectedIndex = -1
                Me.ComboBox4.SelectedIndex = -1
                Me.ComboBox5.SelectedIndex = -1
                Me.ComboBox6.SelectedIndex = -1
                Me.ComboBox7.SelectedIndex = -1
                Me.ComboBox8.SelectedIndex = -1
                Me.ComboBox9.SelectedIndex = -1
                Me.ComboBox10.SelectedIndex = -1


                ComboBox1.DataBindings.Clear()
                ComboBox2.DataBindings.Clear()
                ComboBox3.DataBindings.Clear()
                ComboBox4.DataBindings.Clear()
                ComboBox5.DataBindings.Clear()
                ComboBox6.DataBindings.Clear()
                ComboBox7.DataBindings.Clear()
                ComboBox8.DataBindings.Clear()
                ComboBox9.DataBindings.Clear()
                ComboBox10.DataBindings.Clear()

                DateTimePicker1.DataBindings.Clear()
                DateTimePicker1.Value = Today
            End If
        Finally
        End Try
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""

        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
        ComboBox5.Text = ""
        ComboBox6.Text = ""
        ComboBox7.Text = ""
        ComboBox8.Text = ""
        ComboBox9.Text = ""
        ComboBox10.Text = ""

        TextBox3.DataBindings.Clear()
        TextBox4.DataBindings.Clear()
        TextBox5.DataBindings.Clear()
        TextBox6.DataBindings.Clear()

        ComboBox1.DataBindings.Clear()
        ComboBox2.DataBindings.Clear()
        ComboBox3.DataBindings.Clear()
        ComboBox4.DataBindings.Clear()
        ComboBox5.DataBindings.Clear()
        ComboBox6.DataBindings.Clear()
        ComboBox7.DataBindings.Clear()
        ComboBox8.DataBindings.Clear()
        ComboBox9.DataBindings.Clear()
        ComboBox10.DataBindings.Clear()

        DateTimePicker1.DataBindings.Clear()
        DateTimePicker1.Value = Today

        Dim CUENTA As Double = TextBox1.Text
        Dim ORDEN As Double = TextBox2.Text
        Dim MES_CREACION As Integer = DateTimePicker1.Value.Month

        Dim c1 As String
        Dim dttable As New DataTable

        c1 = "SELECT * FROM POSVENTAS WHERE CUENTA=" & CUENTA & " AND ORDEN =" & ORDEN & ""

        Dim adaptadorSQL As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorSQL.Fill(dttable)

        TextBox3.DataBindings.Add(New Binding("Text", dttable, "RANGO_DIAS"))
        TextBox4.DataBindings.Add(New Binding("Text", dttable, "TIPO_TRABAJO"))
        TextBox5.DataBindings.Add(New Binding("Text", dttable, "USU_CREACION"))
        DateTimePicker1.DataBindings.Add(New Binding("Text", dttable, "FECHA_CREACION"))
        ComboBox10.DataBindings.Add(New Binding("Text", dttable, "CANAL_INGRESO"))
        ComboBox1.DataBindings.Add(New Binding("Text", dttable, "ESTADO_ORDEN"))
        ComboBox2.DataBindings.Add(New Binding("Text", dttable, "TIPO_ORDEN"))
        ComboBox3.DataBindings.Add(New Binding("Text", dttable, "MOTIVO_ORDEN"))
        ComboBox4.DataBindings.Add(New Binding("Text", dttable, "MOTIVO_ORDEN"))
        ComboBox5.DataBindings.Add(New Binding("Text", dttable, "MOTIVO_ORDEN"))
        ComboBox6.DataBindings.Add(New Binding("Text", dttable, "MOTIVO_ORDEN"))
        ComboBox7.DataBindings.Add(New Binding("Text", dttable, "MOTIVO_ORDEN"))
        ComboBox8.DataBindings.Add(New Binding("Text", dttable, "MOTIVO_ORDEN"))
        ComboBox9.DataBindings.Add(New Binding("Text", dttable, "NUM_SERVICIOS"))
        TextBox6.DataBindings.Add(New Binding("Text", dttable, "OBSERVACIONES"))

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim dttable4, dttable5, dttable25 As New DataTable
            Dim consulta4, consulta5, consulta25 As String
            Dim Cuenta As Double = TextBox1.Text
            Dim Orden As Double = TextBox2.Text
            Dim Rango_Dias As Integer = TextBox3.Text
            Dim Tipo_Trabajo As String = TextBox4.Text
            Dim Usu_Creacion As String = TextBox5.Text
            Dim Fecha_Creacion As String = DateTimePicker1.Text
            Dim Estado_Orden As String = ComboBox1.Text
            Dim Tipo_Orden As String = ComboBox2.Text
            Dim Motivo_Orden As String = ""
            Dim Num_Servicios As Integer = ComboBox9.Text
            Dim Observaciones As String = TextBox6.Text
            Dim AÑO_CREACION As String = DateTimePicker1.Value.Year
            Dim MES_CREACION As Integer = DateTimePicker1.Value.Month
            Dim DIA_CREACION As Integer = DateTimePicker1.Value.Day
            Dim CANAL_INGRESO As String = ComboBox10.Text

            Dim dato1 As String = ""
            Dim dt10 As New DataTable
            Dim c1 As String
            Dim proceso As String = "Posventas"


            c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
            Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
            adaptadorsql1.Fill(dt10)
            Dim i As Integer

            For i = 0 To dt10.Rows.Count - 1
                dato1 = dt10.Rows(i).Item("Usuario")
            Next

            If ComboBox3.Visible = True Then
                Motivo_Orden = ComboBox3.Text
            Else
                If ComboBox4.Visible = True Then
                    Motivo_Orden = ComboBox4.Text
                Else
                    If ComboBox5.Visible = True Then
                        Motivo_Orden = ComboBox5.Text
                    Else
                        If ComboBox6.Visible = True Then
                            Motivo_Orden = ComboBox6.Text
                        Else
                            If ComboBox7.Visible = True Then
                                Motivo_Orden = ComboBox7.Text
                            Else
                                If ComboBox8.Visible = True Then
                                    Motivo_Orden = ComboBox8.Text

                                End If
                            End If
                        End If
                    End If
                End If

            End If

            If (MsgBox("Desea Actualizar el Registro?", MsgBoxStyle.YesNo, "Actualizar")) = MsgBoxResult.Yes Then
                consulta4 = "UPDATE POSVENTAS SET CANAL_INGRESO='" & CANAL_INGRESO & "' ,Rango_Dias=" & Rango_Dias & " ,Tipo_Trabajo='" & Tipo_Trabajo & "' ,Usu_Creacion='" & Usu_Creacion & "' ,Fecha_Creacion='" & Fecha_Creacion & "' ,AÑO_CREACION=" & AÑO_CREACION & ",MES_CREACION=" & MES_CREACION & ",DIA_CREACION=" & DIA_CREACION & ",Estado_Orden='" & Estado_Orden & "' ,Tipo_Orden='" & Tipo_Orden & "' ,Motivo_Orden='" & Motivo_Orden & "' ,Num_Servicios=" & Num_Servicios & " ,Observaciones='" & Observaciones & "' WHERE CUENTA=" & Cuenta & " AND ORDEN =" & Orden & ""
                Dim adaptadorSQL4 As New SqlDataAdapter(consulta4, New SqlConnection(coneccion))
                adaptadorSQL4.Fill(dttable4)

                Dim id As Integer = 6

                consulta5 = "UPDATE CONSOLIDADO SET CANAL_INGRESO='" & CANAL_INGRESO & "',GESTION='" & Tipo_Orden & "',SUB_RAZON='" & Motivo_Orden & "',SERVICIOS_DX=" & Num_Servicios & ", OBSERVACIONES='" & Observaciones & "' WHERE CUENTA=" & Cuenta & " AND FECHA_CREACION='" & Fecha_Creacion & "' AND ID_GESTION=" & id & ""
                Dim adaptadorSQL5 As New SqlDataAdapter(consulta5, New SqlConnection(coneccion))
                adaptadorSQL5.Fill(dttable5)

                Dim porcen As Integer
                porcen = 1.2
                consulta25 = "INSERT INTO PRODUCTIVIDAD (USUARIO,ID_GESTION,FECHA,AÑO,MES,DIA,HORA_GESTION,CUENTA,PROCESO,PORCENTAJE)VALUES('" & dato1 & "'," & id & ",getdate()," & AÑO & "," & MES & "," & DIA & ",getdate()," & Cuenta & ", '" & proceso & "'," & porcen & ")"
                Dim adaptadorSQL25 As New SqlDataAdapter(consulta25, New SqlConnection(coneccion))
                adaptadorSQL25.Fill(dttable5)
                MsgBox("Registro Actualizado")

                TextBox1.Text = 0
                TextBox2.Text = 0
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox6.Text = ""
                TextBox1.DataBindings.Clear()
                TextBox2.DataBindings.Clear()
                TextBox3.DataBindings.Clear()
                TextBox4.DataBindings.Clear()
                TextBox5.DataBindings.Clear()
                TextBox6.DataBindings.Clear()

                ComboBox1.Text = ""
                ComboBox2.Text = ""
                ComboBox3.Text = ""
                ComboBox4.Text = ""
                ComboBox5.Text = ""
                ComboBox6.Text = ""
                ComboBox7.Text = ""
                ComboBox8.Text = ""
                ComboBox9.Text = ""
                ComboBox10.Text = ""

                Me.ComboBox1.SelectedIndex = -1
                Me.ComboBox2.SelectedIndex = -1
                Me.ComboBox3.SelectedIndex = -1
                Me.ComboBox4.SelectedIndex = -1
                Me.ComboBox5.SelectedIndex = -1
                Me.ComboBox6.SelectedIndex = -1
                Me.ComboBox7.SelectedIndex = -1
                Me.ComboBox8.SelectedIndex = -1
                Me.ComboBox9.SelectedIndex = -1
                Me.ComboBox10.SelectedIndex = -1


                ComboBox1.DataBindings.Clear()
                ComboBox2.DataBindings.Clear()
                ComboBox3.DataBindings.Clear()
                ComboBox4.DataBindings.Clear()
                ComboBox5.DataBindings.Clear()
                ComboBox6.DataBindings.Clear()
                ComboBox7.DataBindings.Clear()
                ComboBox8.DataBindings.Clear()
                ComboBox9.DataBindings.Clear()
                ComboBox10.DataBindings.Clear()

                DateTimePicker1.DataBindings.Clear()
                DateTimePicker1.Value = Today

            End If
        Finally
        End Try
    End Sub

    Private Sub ComboBox9_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox9.LostFocus
        Try
            If ComboBox9.Text = "" Then
                MsgBox("Este campo no puede quedar vacio")
                ComboBox9.BackColor = Color.Red
                ComboBox9.ForeColor = Color.White
            Else
                If ComboBox9.Text >= 4 Then
                    MsgBox("Numero de servicios invalido")
                    ComboBox9.BackColor = Color.Red
                    ComboBox9.ForeColor = Color.White
                Else
                    ComboBox9.BackColor = Color.WhiteSmoke
                    ComboBox9.ForeColor = Color.Black
                End If
            End If
        Finally
        End Try
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        ComboBox3.Hide()
        ComboBox4.Hide()
        ComboBox5.Hide()
        ComboBox6.Hide()
        ComboBox7.Hide()
        ComboBox8.Hide()


        If ComboBox2.SelectedItem = "Desconexiones" Then
            ComboBox3.Show()
        Else
            If ComboBox2.SelectedItem = "Corporativo" Then
                ComboBox7.Show()
            Else
                If ComboBox2.SelectedItem = "Error De Creacion" Then
                    ComboBox4.Show()
                Else
                    If ComboBox2.SelectedItem = "Instalaciones" Then
                        ComboBox8.Show()
                    Else
                        If ComboBox2.SelectedItem = "Posventas" Then
                            ComboBox5.Show()
                        Else
                            If ComboBox2.SelectedItem = "Reconexiones" Then
                                ComboBox6.Show()
                            Else
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub
End Class