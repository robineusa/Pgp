Imports System.Data.SqlClient

Public Class Reportar_Productividad

    Private Sub Reportar_Productividad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DateTimePicker1.MaxDate = DateTime.Today
        DateTimePicker1.Format = DateTimePickerFormat.Short
        DateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim c1 As String
        Dim dt1 As New DataTable
        Dim FECHA As String = DateTimePicker1.Text

        c1 = "INSERT INTO PRODUCTIVIDAD_DIARIA (USUARIO, FECHA, PRODUCTIVIDAD, AÑO, MES, DIA )SELECT CONSULTA_PRODUCTIVIDAD.USUARIO, CONSULTA_PRODUCTIVIDAD.FECHA, CONSULTA_PRODUCTIVIDAD.PRODUCTIVIDAD, CONSULTA_PRODUCTIVIDAD.AÑO, CONSULTA_PRODUCTIVIDAD.MES, CONSULTA_PRODUCTIVIDAD.DIA FROM CONSULTA_PRODUCTIVIDAD WHERE (((CONSULTA_PRODUCTIVIDAD.FECHA)='" & FECHA & "'))GROUP BY CONSULTA_PRODUCTIVIDAD.USUARIO, CONSULTA_PRODUCTIVIDAD.FECHA, CONSULTA_PRODUCTIVIDAD.PRODUCTIVIDAD, CONSULTA_PRODUCTIVIDAD.AÑO, CONSULTA_PRODUCTIVIDAD.MES, CONSULTA_PRODUCTIVIDAD.DIA"
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt1)
        MsgBox("Productividad Reportada")
    End Sub
End Class