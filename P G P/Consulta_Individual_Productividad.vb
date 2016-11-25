Imports System.Data.SqlClient

Public Class Consulta_Individual_Productividad

    Dim bs12 As New BindingSource
    Dim bs4 As New BindingSource
    Dim adaptadorsql12 As SqlDataAdapter
    Dim adaptadorsql4 As SqlDataAdapter

    Private Sub cargar_registros(ByVal sql As String, ByVal dv As DataGridView)
        Dim consulta20 As String
        Dim dt1, dt2 As New DataTable
        Dim fecha As String = DateTimePicker1.Value
        TextBox1.DataBindings.Clear()

        consulta20 = "select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql12 As New SqlDataAdapter(consulta20, New SqlConnection(coneccion))
        adaptadorsql12.Fill(dt1)
        TextBox1.DataBindings.Add(New Binding("Text", dt1, "Usuario"))

        Dim usu As String = TextBox1.Text
        Dim consulta As String = "SELECT NOMBRE_GESTION,FECHA,AÑO,MES,DIA,SUBSTRING (convert(char(38),HORA_GESTION,121),12,8) as 'Hora de Gestion',CUENTA,PROCESO FROM PRODUCTIVIDAD,GESTIONES WHERE  PRODUCTIVIDAD .ID_GESTION =GESTIONES .ID_GESTION and Usuario ='" & usu & "' and CONVERT(VARCHAR(10),FECHA, 103)  like '" & fecha & "'"
        Dim dttable As New DataTable
        Dim bedit As Boolean
        adaptadorsql12 = New SqlDataAdapter(consulta, New SqlConnection(coneccion))
        Dim sqlbuilder As New SqlCommandBuilder(adaptadorsql12)
        adaptadorsql12.Fill(dttable)
        bs12.DataSource = dttable

        If Not bs12.DataSource Is Nothing Then
            adaptadorsql12.Update(bs12.DataSource) 'CType(bs.DataSource, DataTable))

        End If

        With DataGridView1
            .Refresh()
        End With
        bedit = False


    End Sub
    Private Sub cargar_registros2(ByVal sql As String, ByVal dv As DataGridView)
        Dim consulta20 As String
        Dim dt1, dt2 As New DataTable
        Dim fecha As String = DateTimePicker1.Value
        TextBox1.DataBindings.Clear()

        consulta20 = "select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql4 As New SqlDataAdapter(consulta20, New SqlConnection(coneccion))
        adaptadorsql4.Fill(dt1)
        TextBox1.DataBindings.Add(New Binding("Text", dt1, "Usuario"))

        Dim usu As String = TextBox1.Text
        Dim consulta As String = "select Nombre_Gestion ,COUNT(Cuenta)AS 'Cantidad Registros' FROM PRODUCTIVIDAD inner join GESTIONES ON PRODUCTIVIDAD .ID_GESTION =GESTIONES .ID_GESTION and Usuario like '" & usu & "'  and CONVERT(VARCHAR(10),FECHA, 103)like '" & fecha & "' GROUP BY NOMBRE_GESTION"
        Dim dttable As New DataTable
        Dim bedit As Boolean
        adaptadorsql4 = New SqlDataAdapter(consulta, New SqlConnection(coneccion))
        Dim sqlbuilder As New SqlCommandBuilder(adaptadorsql4)
        adaptadorsql4.Fill(dttable)
        bs4.DataSource = dttable

        If Not bs4.DataSource Is Nothing Then
            adaptadorsql4.Update(bs4.DataSource) 'CType(bs.DataSource, DataTable))

        End If

        With DataGridView2
            .Refresh()
        End With
        bedit = False


    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DataGridView1.Show()
        DataGridView1.DataSource = bs12
        cargar_registros(coneccion, DataGridView1)
        cargar_registros2(coneccion, DataGridView2)
        DataGridView2.DataSource = bs4


    End Sub

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DateTimePicker1.MinDate = New DateTime(1985, 6, 12)
        DateTimePicker1.MaxDate = DateTime.Today
        DateTimePicker1.Format = DateTimePickerFormat.Short
        DateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd"
        PictureBox4.Enabled = False

    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        limpiar(Me)
        TextBox1.DataBindings.Clear()
        DataGridView1.Hide()
        DataGridView2.Hide()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        limpiar(Me)
        TextBox1.DataBindings.Clear()
        DataGridView1.Hide()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        DataGridView1.Show()
        DataGridView2.Show()
        DataGridView1.DataSource = bs12
        cargar_registros(coneccion, DataGridView1)
        cargar_registros2(coneccion, DataGridView2)
        DataGridView2.DataSource = bs4
    End Sub

    Private Sub Productividad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        limpiar(Me)
        DataGridView1.Hide()
        DataGridView2.Hide()
    End Sub
    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
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
End Class