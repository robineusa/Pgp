Imports System.Data.SqlClient

Public Class Reporte_Productividad
    Dim bs As New BindingSource
    Dim adaptadorsql As SqlDataAdapter
    Private Sub cargar_registros(ByVal sql As String, ByVal dv As DataGridView)
        Dim fecha As String = DateTimePicker1.Value
        Actualizar_Consulta()

        Dim consulta As String = "SELECT USUARIO,PRODUCTIVIDAD FROM CONSULTA_PRODUCTIVIDAD WHERE  FECHA='" & fecha & "'"
        Dim dttable As New DataTable

        Dim bedit As Boolean
        adaptadorsql = New SqlDataAdapter(consulta, New SqlConnection(coneccion))
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
    Private Sub actualizar(Optional ByVal bcargar As Boolean = True)
        ' Actualizar y guardar cambios  
        If Not bs.DataSource Is Nothing Then
            adaptadorsql.Update(bs.DataSource) 'CType(bs.DataSource, DataTable))
            If bcargar Then
                cargar_registros(coneccion, DataGridView1)
            End If
        End If
    End Sub


    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DateTimePicker1.MinDate = New DateTime(1985, 6, 12)
        DateTimePicker1.MaxDate = DateTime.Today
        DateTimePicker1.Format = DateTimePickerFormat.Short
        DateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd"


    End Sub


    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
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
    Function GridAExcel(ByVal ElGrid As DataGridView) As Boolean

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
        Return True
    End Function
    Public Sub Actualizar_Consulta()
        Dim c2 As String
        Dim dt2 As New DataTable
        c2 = "EXECUTE PRODUCTIVIDAD_CONSULTA"
        Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
        adaptadorsql2.Fill(dt2)
    End Sub
End Class