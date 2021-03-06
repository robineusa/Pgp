﻿Imports System.Data.SqlClient

Public Class Estado_Congelaciones
    Dim bs As New BindingSource
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        DataGridView1.Show()
        DataGridView1.DataSource = bs
        cargar_registros(coneccion, DataGridView1)
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        limpiar(Me)
        DataGridView1.Hide()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Call GridAExcel(DataGridView1)
    End Sub
    Private Sub cargar_registros(ByVal sql As String, ByVal dv As DataGridView)
        Dim fechaini As String = TextBox1.Text
        Dim fechafin As String = TextBox2.Text

        Dim consulta As String = "SELECT * FROM CONGELACIONES where  (((CONGELACIONES.Fecha_Gestion) Between '" & fechaini & "' And '" & fechafin & "'));"
        Dim dttable As New DataTable
        Dim bedit As Boolean
        Dim adaptadorsql = New SqlDataAdapter(consulta, New SqlConnection(coneccion))
        Dim sqlbuilder As New SqlCommandBuilder(adaptadorsql)
        adaptadorsql.Fill(dttable)
        bs.DataSource = dttable

        If Not bs.DataSource Is Nothing Then
            adaptadorsql.Update(bs.DataSource) 'CType(bs.DataSource, DataTable))

        End If

        With DataGridView1
            .Refresh()
        End With
        bedit = False

    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Function GridAExcel(ByVal ElGrid As DataGridView) As Boolean
        pBar1.Value = 0.0
        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

        Try
            'Añadimos el Libro al programa, y la hoja al libro
            exLibro = exApp.Workbooks.Add
            exHoja = exLibro.Worksheets.Add()
            ' ¿Cuantas columnas y cuantas filas? 
            Dim NCol As Integer = ElGrid.ColumnCount
            Dim NRow As Integer = ElGrid.RowCount
            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos 
            For i As Integer = 1 To NCol
                exHoja.Cells.Item(1, i) = ElGrid.Columns(i - 1).Name.ToString
                exHoja.Cells.Item(1, i).HorizontalAlignment = 3

            Next
            For Fila As Integer = 0 To NRow - 1
                For Col As Integer = 0 To NCol - 1
                    exHoja.Cells.Item(Fila + 2, Col + 1) = ElGrid.Rows(Fila).Cells(Col).Value
                    DataGridView1.Visible = False
                    pBar1.Visible = True
                    Label8.Visible = True
                    pBar1.Value = Fila
                    pBar1.Maximum = pBar1.Value + 1
                Next
            Next
            'Titulo en negrita, Alineado al centro y que el tamaño de la columna se ajuste 
            exHoja.Rows.Item(1).Font.Bold = 1
            exHoja.Rows.Item(1).HorizontalAlignment = 3
            exHoja.Columns.AutoFit()
            'Aplicación visible
            exApp.Application.Visible = True
            exHoja = Nothing
            exLibro = Nothing
            exApp = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
            Return False

        End Try
        pBar1.Hide()
        Label8.Visible = False
        DataGridView1.Visible = True
        MsgBox("La exportación a Excel fue exitosa!")
        Return True
    End Function
End Class