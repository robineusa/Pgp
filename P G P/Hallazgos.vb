Imports System.Data.SqlClient

Public Class Hallazgos

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Hallazgos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label25.Text = nombreusuario
        TextBox1.Text = Cuenta_hallazgos

        Dim ID_MACROPROCESO = 5
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim dttable4 As New DataTable
            Dim consulta4 As String
            Dim Cuenta As Double = TextBox1.Text
            Dim dato1 As String = ""
            Dim dt10 As New DataTable
            Dim c1 As String
            Dim Tipo_Error As String = ComboBox1.Text
            Dim Motivo_Error As String = ComboBox2.Text
            Dim Serviciosdx As Integer = ComboBox3.Text
            Dim Usuario_error As String = TextBox2.Text
            Dim Estado As String = " Pendiente"


            c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
            Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
            adaptadorsql1.Fill(dt10)
            Dim i As Integer

            For i = 0 To dt10.Rows.Count - 1
                dato1 = dt10.Rows(i).Item("Usuario")
            Next


            If (MsgBox("Desea Guardar Registro?", MsgBoxStyle.YesNo, "Guardar")) = MsgBoxResult.Yes Then
                consulta4 = "insert into HALLAZGOS (Usuario ,Cuenta , Tipo_Error ,Motivo_Error ,Fecha ,Hora ,Cantidad_Servicios ,Usuario_Error,Estado ) VALUES('" & dato1 & "'," & Cuenta & ",'" & Tipo_Error & "','" & Motivo_Error & "',getdate(),getdate()," & Serviciosdx & ",'" & Usuario_error & "','" & Estado & "' )"
                Dim adaptadorSQL4 As New SqlDataAdapter(consulta4, New SqlConnection(coneccion))
                adaptadorSQL4.Fill(dttable4)
                MsgBox("El hallazgo fue almacenado")
            End If
        Finally
        End Try
        TextBox1.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        Cuenta_hallazgos = 0
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

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim dttable As New DataTable
        Dim cta As String
        Dim Cuenta As Integer = TextBox1.Text
        Dim Tipo_Error As String = ComboBox2.Text

        cta = "Select * From HALLAZGOS where Cuenta = " & Cuenta & " and Motivo_Error like '" & Tipo_Error & "'"
        Dim adaptadorsql As New SqlDataAdapter(cta, New SqlConnection(coneccion))
        adaptadorsql.Fill(dttable)
        If adaptadorsql.Fill(dttable) <= 0 Then
        Else
            MsgBox("Este tipo de hallazgo ya fue registrado por otro usuario")
            ComboBox1.Text = ""
            ComboBox2.Text = ""
            ComboBox3.Text = ""
        End If
    End Sub
End Class