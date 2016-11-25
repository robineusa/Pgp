Imports System.Data.SqlClient

Public Class Gestion_Correos

    Private Sub Gestion_Correos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label33.Text = nombreusuario
        Dim c1 As String
        Dim dt1 As New DataTable

        c1 = "SELECT NOMBRE_MACROPROCESO FROM MACROPROCESOS"
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt1)

        Dim i As Integer

        For i = 0 To dt1.Rows.Count - 1
            ComboBox1.Items.Add(dt1.Rows(i).Item("NOMBRE_MACROPROCESO"))
        Next
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        ComboBox2.Items.Clear()
        ComboBox2.Text = ""
        ComboBox3.Items.Clear()
        ComboBox3.Text = ""

        Dim c1 As String
        Dim dt1 As New DataTable
        Dim MACRO As String = ComboBox1.Text
        Dim dt10 As New DataTable
        Dim dato1 As Integer

        c1 = "Select ID_MACROPROCESO from MACROPROCESOS where NOMBRE_MACROPROCESO like '" & MACRO & "'"
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt10)
        Dim i As Integer

        For i = 0 To dt10.Rows.Count - 1
            dato1 = dt10.Rows(i).Item("ID_MACROPROCESO")
        Next

        c1 = "SELECT NOMBRE_SUB_PROCESO FROM SUB_PROCESOS WHERE ID_MACROPROCESO =" & dato1 & ""
        Dim adaptadorsql2 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql2.Fill(dt1)

        Dim j As Integer

        For j = 0 To dt1.Rows.Count - 1
            ComboBox2.Items.Add(dt1.Rows(j).Item("NOMBRE_SUB_PROCESO"))
        Next
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        ComboBox3.Items.Clear()
        ComboBox3.Text = ""
        Dim c1 As String
        Dim dt1 As New DataTable
        Dim SUBPROCESO As String = ComboBox2.Text
        Dim dt10 As New DataTable
        Dim dato1 As Integer

        c1 = "Select ID_SUBPROCESO from SUB_PROCESOS where NOMBRE_SUB_PROCESO like '" & SUBPROCESO & "'"
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt10)
        Dim i As Integer

        For i = 0 To dt10.Rows.Count - 1
            dato1 = dt10.Rows(i).Item("ID_SUBPROCESO")
        Next

        c1 = "SELECT NOMBRE_PROCESO FROM PROCESOS WHERE ID_SUBPROCESO =" & dato1 & ""
        Dim adaptadorsql2 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql2.Fill(dt1)

        Dim j As Integer

        For j = 0 To dt1.Rows.Count - 1
            ComboBox3.Items.Add(dt1.Rows(j).Item("NOMBRE_PROCESO"))
        Next
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
        Dim dt1, dt2, dt3, dt4 As New DataTable
        Dim c1, c2, c3, c4 As String

        Dim cuenta As Double = TextBox1.Text
        Dim orden As Double = TextBox2.Text
        Dim macroproceso As String = ComboBox1.Text
        Dim sub_proceso As String = ComboBox2.Text
        Dim proceso As String = ComboBox3.Text
        Dim servicios_dx As Double = ComboBox4.Text
        Dim observaciones As String = TextBox3.Text


        Dim usuario As String = ""

        c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt1)
        Dim i As Integer

        For i = 0 To dt1.Rows.Count - 1
            usuario = dt1.Rows(i).Item("Usuario")
        Next

        If (MsgBox("Desea guardar registro?", MsgBoxStyle.YesNo, "Guardar")) = MsgBoxResult.Yes Then

            Dim id As Integer = 12
            Dim proceso1 As String = "Gestion Correos"

            c2 = "INSERT INTO CORREOS (FECHA_GESTION,HORA_GESTION,USUARIO,CUENTA,ORDEN_PQR,MACROPROCESO,SUB_PROCESO,PROCESO,SERVICIOS_DX,OBSERVACIONES)VALUES(GETDATE(),GETDATE(),'" & usuario & "'," & cuenta & "," & orden & ",'" & macroproceso & "','" & sub_proceso & "','" & proceso & "'," & servicios_dx & ",'" & observaciones & "')"
            Dim adaptadorSQL2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
            adaptadorSQL2.Fill(dt2)

            c3 = "insert into CONSOLIDADO (Id_Gestion ,Cuenta ,Proceso ,Gestion,Sub_Razon,Servicios_Dx,Fecha ,Hora_Gestion,Usuario) values(" & id & ", " & cuenta & ", '" & proceso1 & "','" & sub_proceso & "','" & proceso & "'," & servicios_dx & ",getdate(),getdate(), '" & usuario & "')"
            Dim adaptadorSQL3 As New SqlDataAdapter(c3, New SqlConnection(coneccion))
            adaptadorSQL3.Fill(dt3)

            Dim porcen As Decimal
            porcen = 1
            c4 = "INSERT INTO PRODUCTIVIDAD(Usuario, Id_Gestion,Fecha,Hora_Gestion,Cuenta,Proceso,Porcentaje)Values('" & usuario & "'," & id & ",getdate(),getdate()," & cuenta & ", '" & proceso1 & "'," & porcen & ")"
            Dim adaptadorSQL4 As New SqlDataAdapter(c4, New SqlConnection(coneccion))
            adaptadorSQL4.Fill(dt4)
            MsgBox("Registro Almacenado")
        Else
            c2 = ""
            c3 = ""
            c4 = ""
            Exit Sub
        End If

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""

    End Sub
End Class