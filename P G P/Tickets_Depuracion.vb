Imports System.Data.SqlClient

Public Class Tickets_Depuracion

    Private Sub Tickets_Depuracion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Label33.Text = nombreusuario

        DateTimePicker3.MinDate = New DateTime(1985, 6, 12)
        DateTimePicker3.MaxDate = DateTime.Today
        DateTimePicker3.Format = DateTimePickerFormat.Short
        DateTimePicker3.CustomFormat = "MMMM dd, yyyy - dddd"

        Dim consulta2 As String
        Dim dttable As New DataTable

        consulta2 = "SELECT * FROM ASIG_TICKETS WHERE TIPO_RECLAMACION='Pendiente' ORDER BY FECHA_CREACION ASC"

        Dim adaptadorSQL As New SqlDataAdapter(consulta2, New SqlConnection(coneccion))
        adaptadorSQL.Fill(dttable)

        If adaptadorSQL.Fill(dttable) = False Then
            MsgBox("NO HAY REGISTROS DISPONIBLES")
        Else
            TextBox1.DataBindings.Add(New Binding("Text", dttable, "Cuenta"))
            TextBox2.DataBindings.Add(New Binding("Text", dttable, "Numero_Ticket"))
            ComboBox3.DataBindings.Add(New Binding("Text", dttable, "Canal_Ingreso"))
            TextBox4.DataBindings.Add(New Binding("Text", dttable, "Usuario_Creacion"))
            DateTimePicker3.DataBindings.Add(New Binding("Text", dttable, "Fecha_Creacion"))
            TextBox6.DataBindings.Add(New Binding("Text", dttable, "SRCAUS"))
            TextBox7.DataBindings.Add(New Binding("Text", dttable, "SRREAS"))
            TextBox8.DataBindings.Add(New Binding("Text", dttable, "Motivo_Dx"))
            TextBox9.DataBindings.Add(New Binding("Text", dttable, "Codigo"))
            TextBox10.DataBindings.Add(New Binding("Text", dttable, "Nota1"))
            TextBox11.DataBindings.Add(New Binding("Text", dttable, "Nota2"))
            TextBox12.DataBindings.Add(New Binding("Text", dttable, "Nota3"))
            TextBox13.DataBindings.Add(New Binding("Text", dttable, "Nota4"))
            TextBox14.DataBindings.Add(New Binding("Text", dttable, "Nota5"))

            Dim dttable1 As New DataTable
            Dim consulta3 As String
            Dim Dato As Double

            Dato = TextBox2.Text
            consulta3 = "delete ASIG_TICKETS where Numero_Ticket = " & Dato & ""

            Dim adaptadorSQL2 As New SqlDataAdapter(consulta3, New SqlConnection(coneccion))
            adaptadorSQL2.Fill(dttable1)
        End If
        TextBox1.Focus()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox2.Text = "" Then
            MsgBox("Existen Campos Vacios")
        Else
            Dim c2 As String
            Dim dt2 As New DataTable
            Dim Cuenta As Double = TextBox1.Text
            Dim Numero_Ticket As Double = TextBox2.Text
            Dim Canal_ingreso As String = ComboBox3.Text
            Dim Usuario_Creacion As String = TextBox4.Text
            Dim Fecha_Creacion As String = DateTimePicker3.Text
            Dim SRCAUS As String = TextBox6.Text
            Dim SRREAS As String = TextBox7.Text
            Dim Motivo_Dx As String = TextBox8.Text
            Dim Codigo As String = TextBox9.Text
            Dim Nota1 As String = TextBox10.Text
            Dim Nota2 As String = TextBox11.Text
            Dim Nota3 As String = TextBox12.Text
            Dim Nota4 As String = TextBox13.Text
            Dim Nota5 As String = TextBox14.Text
            Dim Tipo_Reclamacion As String = "Proceso Desconexiones"
            Dim Cantidad_Servicios As Integer = ComboBox4.Text

            If (MsgBox("Desea escalar el PQR para gestión por Desconexiones?", MsgBoxStyle.YesNo, "Escalamiento de Registros")) = MsgBoxResult.Yes Then
                c2 = "INSERT INTO ASIG_TICKETS (Canal_Ingreso ,Cuenta ,Numero_Ticket ,Usuario_Creacion ,Fecha_Creacion ,SRCAUS ,SRREAS ,Motivo_Dx ,Codigo, Nota1 ,Nota2 , Nota3 ,Nota4 ,Nota5,Tipo_Reclamacion,Cantidad_Servicios ) values('" & Canal_ingreso & "'," & Cuenta & "," & Numero_Ticket & ",'" & Usuario_Creacion & "','" & Fecha_Creacion & "','" & SRCAUS & "','" & SRREAS & "','" & Motivo_Dx & "','" & Codigo & "','" & Nota1 & "','" & Nota2 & "','" & Nota3 & "','" & Nota4 & "','" & Nota5 & "','" & Tipo_Reclamacion & "'," & Cantidad_Servicios & ")"
                Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
                adaptadorsql2.Fill(dt2)

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

                Dim id As Integer = 11
                Dim proceso As String = "Depuracion Tickets"


                Dim consulta25 As String
                Dim dttable5 As New DataTable


                Dim porcen As Decimal
                porcen = 1
                consulta25 = "INSERT INTO PRODUCTIVIDAD (USUARIO,ID_GESTION,FECHA,AÑO,MES,DIA,HORA_GESTION,CUENTA,PROCESO,PORCENTAJE)VALUES('" & dato1 & "'," & id & ",getdate()," & AÑO & "," & MES & "," & DIA & ",getdate()," & Cuenta & ", '" & proceso & "'," & porcen & ")"
                Dim adaptadorSQL25 As New SqlDataAdapter(consulta25, New SqlConnection(coneccion))
                adaptadorSQL25.Fill(dttable5)

                MsgBox("Se escalo el caso por proceso de Desconexión")


                TextBox1.DataBindings.Clear()
                TextBox2.DataBindings.Clear()
                TextBox4.DataBindings.Clear()
                TextBox6.DataBindings.Clear()
                TextBox7.DataBindings.Clear()
                TextBox8.DataBindings.Clear()
                TextBox9.DataBindings.Clear()
                TextBox10.DataBindings.Clear()
                TextBox11.DataBindings.Clear()
                TextBox12.DataBindings.Clear()
                TextBox13.DataBindings.Clear()
                TextBox14.DataBindings.Clear()
                DateTimePicker3.DataBindings.Clear()
                ComboBox3.DataBindings.Clear()

                TextBox1.Text = ""
                TextBox2.Text = ""
                ComboBox3.Text = ""
                TextBox4.Text = ""
                DateTimePicker3.Text = ""
                TextBox6.Text = ""
                TextBox7.Text = ""
                TextBox8.Text = ""
                TextBox9.Text = ""
                TextBox11.Text = ""
                TextBox12.Text = ""
                TextBox13.Text = ""
                TextBox14.Text = ""
                ComboBox3.Text = ""
                Me.ComboBox4.SelectedIndex = -1
                Call Cargar_Un_Registro()

            Else
                c2 = ""
                Exit Sub
            End If
        End If
        TextBox1.Focus()
        TextBox1.SelectAll()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox2.Text = "" Then
            MsgBox("Existen Campos Vacios")
        Else
            Dim c2 As String
            Dim dt2 As New DataTable
            Dim Cuenta As Double = TextBox1.Text
            Dim Numero_Ticket As Double = TextBox2.Text
            Dim Canal_ingreso As String = ComboBox3.Text
            Dim Usuario_Creacion As String = TextBox4.Text
            Dim Fecha_Creacion As String = DateTimePicker3.Text
            Dim SRCAUS As String = TextBox6.Text
            Dim SRREAS As String = TextBox7.Text
            Dim Motivo_Dx As String = TextBox8.Text
            Dim Codigo As String = TextBox9.Text
            Dim Nota1 As String = TextBox10.Text
            Dim Nota2 As String = TextBox11.Text
            Dim Nota3 As String = TextBox12.Text
            Dim Nota4 As String = TextBox13.Text
            Dim Nota5 As String = TextBox14.Text
            Dim Cantidad_Servicios As Integer = ComboBox4.Text
            Dim Tipo_Reclamacion As String = "Otros Procesos"

            If (MsgBox("Desea escalar el PQR para gestión por otras reclamaciones?", MsgBoxStyle.YesNo, "Devolucion de Registros")) = MsgBoxResult.Yes Then
                c2 = "INSERT INTO ASIG_TICKETS (Canal_Ingreso ,Cuenta ,Numero_Ticket ,Usuario_Creacion ,Fecha_Creacion ,SRCAUS ,SRREAS ,Motivo_Dx ,Codigo, Nota1 ,Nota2 , Nota3 ,Nota4 ,Nota5,Tipo_Reclamacion,Cantidad_Servicios ) values('" & Canal_ingreso & "'," & Cuenta & "," & Numero_Ticket & ",'" & Usuario_Creacion & "','" & Fecha_Creacion & "','" & SRCAUS & "','" & SRREAS & "','" & Motivo_Dx & "','" & Codigo & "','" & Nota1 & "','" & Nota2 & "','" & Nota3 & "','" & Nota4 & "','" & Nota5 & "','" & Tipo_Reclamacion & "'," & Cantidad_Servicios & ")"
                Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
                adaptadorsql2.Fill(dt2)

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

                Dim id As Integer = 11
                Dim proceso As String = "Depuracion Tickets"


                Dim consulta25 As String
                Dim dttable5 As New DataTable

                Dim porcen As Decimal
                porcen = 1
                consulta25 = "INSERT INTO PRODUCTIVIDAD (USUARIO,ID_GESTION,FECHA,AÑO,MES,DIA,HORA_GESTION,CUENTA,PROCESO,PORCENTAJE)VALUES('" & dato1 & "'," & id & ",getdate()," & AÑO & "," & MES & "," & DIA & ",getdate()," & Cuenta & ", '" & proceso & "'," & porcen & ")"
                Dim adaptadorSQL25 As New SqlDataAdapter(consulta25, New SqlConnection(coneccion))
                adaptadorSQL25.Fill(dttable5)

                MsgBox("Se escalo el caso por otros procesos")

                TextBox1.DataBindings.Clear()
                TextBox2.DataBindings.Clear()
                TextBox4.DataBindings.Clear()
                TextBox6.DataBindings.Clear()
                TextBox7.DataBindings.Clear()
                TextBox8.DataBindings.Clear()
                TextBox9.DataBindings.Clear()
                TextBox10.DataBindings.Clear()
                TextBox11.DataBindings.Clear()
                TextBox12.DataBindings.Clear()
                TextBox13.DataBindings.Clear()
                TextBox14.DataBindings.Clear()
                DateTimePicker3.DataBindings.Clear()
                ComboBox3.DataBindings.Clear()

                TextBox1.Text = ""
                TextBox2.Text = ""
                ComboBox3.Text = ""
                TextBox4.Text = ""
                DateTimePicker3.Text = ""
                TextBox6.Text = ""
                TextBox7.Text = ""
                TextBox8.Text = ""
                TextBox9.Text = ""
                TextBox11.Text = ""
                TextBox12.Text = ""
                TextBox13.Text = ""
                TextBox14.Text = ""
                ComboBox3.Text = ""
                Me.ComboBox4.SelectedIndex = -1

                Call Cargar_Un_Registro()

            Else
                c2 = ""

                Exit Sub
            End If
        End If
        TextBox1.Focus()
        TextBox1.SelectAll()
    End Sub
    Public Sub Cargar_Un_Registro()
        Dim consulta2 As String
        Dim dttable As New DataTable

        consulta2 = "SELECT * FROM ASIG_TICKETS WHERE TIPO_RECLAMACION='Pendiente' ORDER BY FECHA_CREACION ASC"

        Dim adaptadorSQL As New SqlDataAdapter(consulta2, New SqlConnection(coneccion))
        adaptadorSQL.Fill(dttable)

        If adaptadorSQL.Fill(dttable) = False Then
            MsgBox("NO HAY REGISTROS DISPONIBLES")
        Else
            TextBox1.DataBindings.Add(New Binding("Text", dttable, "Cuenta"))
            TextBox2.DataBindings.Add(New Binding("Text", dttable, "Numero_Ticket"))
            ComboBox3.DataBindings.Add(New Binding("Text", dttable, "Canal_Ingreso"))
            TextBox4.DataBindings.Add(New Binding("Text", dttable, "Usuario_Creacion"))
            DateTimePicker3.DataBindings.Add(New Binding("Text", dttable, "Fecha_Creacion"))
            TextBox6.DataBindings.Add(New Binding("Text", dttable, "SRCAUS"))
            TextBox7.DataBindings.Add(New Binding("Text", dttable, "SRREAS"))
            TextBox8.DataBindings.Add(New Binding("Text", dttable, "Motivo_Dx"))
            TextBox9.DataBindings.Add(New Binding("Text", dttable, "Codigo"))
            TextBox10.DataBindings.Add(New Binding("Text", dttable, "Nota1"))
            TextBox11.DataBindings.Add(New Binding("Text", dttable, "Nota2"))
            TextBox12.DataBindings.Add(New Binding("Text", dttable, "Nota3"))
            TextBox13.DataBindings.Add(New Binding("Text", dttable, "Nota4"))
            TextBox14.DataBindings.Add(New Binding("Text", dttable, "Nota5"))

            Dim dttable1 As New DataTable
            Dim consulta3 As String
            Dim Dato As Double

            Dato = TextBox2.Text
            consulta3 = "delete ASIG_TICKETS where Numero_Ticket = " & Dato & ""

            Dim adaptadorSQL2 As New SqlDataAdapter(consulta3, New SqlConnection(coneccion))
            adaptadorSQL2.Fill(dttable1)
        End If
        TextBox1.Focus()
        TextBox1.SelectAll()
    End Sub

    Private Sub Cerrar_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ComboBox4.Text = 0

        If TextBox2.Text = "" Then

        Else
            Dim c2 As String
            Dim dt2 As New DataTable
            Dim Cuenta As Double = TextBox1.Text
            Dim Numero_Ticket As Double = TextBox2.Text
            Dim Canal_ingreso As String = ComboBox3.Text
            Dim Usuario_Creacion As String = TextBox4.Text
            Dim Fecha_Creacion As String = DateTimePicker3.Text
            Dim SRCAUS As String = TextBox6.Text
            Dim SRREAS As String = TextBox7.Text
            Dim Motivo_Dx As String = TextBox8.Text
            Dim Codigo As String = TextBox9.Text
            Dim Nota1 As String = TextBox10.Text
            Dim Nota2 As String = TextBox11.Text
            Dim Nota3 As String = TextBox12.Text
            Dim Nota4 As String = TextBox13.Text
            Dim Nota5 As String = TextBox14.Text
            Dim Tipo_Reclamacion = "Pendiente"
            Dim Cantidad_Servicios As Integer = 0
            If (MsgBox("Recuerde que al cerrar el formulario el registro no va a ser gestionado.", MsgBoxStyle.OkOnly, "Devolucion de Registros")) = MsgBoxResult.Ok Then
                c2 = "INSERT INTO ASIG_TICKETS (Canal_Ingreso ,Cuenta ,Numero_Ticket ,Usuario_Creacion ,Fecha_Creacion ,SRCAUS ,SRREAS ,Motivo_Dx ,Codigo, Nota1 ,Nota2 , Nota3 ,Nota4 ,Nota5,Tipo_Reclamacion,Cantidad_Servicios ) values('" & Canal_ingreso & "'," & Cuenta & "," & Numero_Ticket & ",'" & Usuario_Creacion & "','" & Fecha_Creacion & "','" & SRCAUS & "','" & SRREAS & "','" & Motivo_Dx & "','" & Codigo & "','" & Nota1 & "','" & Nota2 & "','" & Nota3 & "','" & Nota4 & "','" & Nota5 & "','" & Tipo_Reclamacion & "'," & Cantidad_Servicios & ")"
                Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
                adaptadorsql2.Fill(dt2)
                MsgBox("Se Devolvio el Registro a la Base")
            Else
                c2 = ""

                Exit Sub
            End If
        End If


    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        Try
            If ComboBox4.Text = "" Then
                MsgBox("Este campo no puede quedar vacio")
                ComboBox4.BackColor = Color.Red
                ComboBox4.ForeColor = Color.White
                Button1.Enabled = False
                Button2.Enabled = False
            Else
                If ComboBox4.Text >= 4 Then
                    MsgBox("Numero de servicios invalido")
                    ComboBox4.BackColor = Color.Red
                    ComboBox4.ForeColor = Color.White
                    Button1.Enabled = False
                    Button2.Enabled = False
                Else
                    ComboBox4.BackColor = Color.WhiteSmoke
                    ComboBox4.ForeColor = Color.Black
                    Button1.Enabled = True
                    Button2.Enabled = True
                End If
            End If
        Finally
        End Try
    End Sub
    Private Sub ComboBox4_cambio(sender As Object, e As EventArgs) Handles ComboBox4.LostFocus
        Try
            If ComboBox4.Text = "" Then
                MsgBox("Este campo no puede quedar vacio")
                ComboBox4.BackColor = Color.Red
                ComboBox4.ForeColor = Color.White
                Button1.Enabled = False
                Button2.Enabled = False
            Else
                If ComboBox4.Text >= 4 Then
                    MsgBox("Numero de servicios invalido")
                    ComboBox4.BackColor = Color.Red
                    ComboBox4.ForeColor = Color.White
                    Button1.Enabled = False
                    Button2.Enabled = False
                Else
                    ComboBox4.BackColor = Color.WhiteSmoke
                    ComboBox4.ForeColor = Color.Black
                    Button1.Enabled = True
                    Button2.Enabled = True
                End If
            End If
        Finally
        End Try
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.LostFocus
        ComboBox4.Focus()
    End Sub
End Class