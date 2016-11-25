
Imports System.Data.SqlClient

Public Class Consolidado
    Dim bs As New BindingSource
    Dim adaptadorsql As SqlDataAdapter

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DataGridView1.DataSource = bs
        cargar_registros(coneccion, DataGridView1)

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
                    pBar1.Maximum = pBar1.Value + 25
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call GridAExcel(DataGridView1)

    End Sub

    Private Sub cargar_registros(ByVal sql As String, ByVal dv As DataGridView)
        Dim nombre As String = ComboBox1.Text
        Dim fechaini As String = TextBox1.Text
        Dim fechafin As String = TextBox2.Text
        Dim usuario As String = ""
        Dim c1 As String
        Dim dt10 As New DataTable

        c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombre & "'"
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt10)
        Dim i As Integer

        For i = 0 To dt10.Rows.Count - 1
            usuario = dt10.Rows(i).Item("Usuario")
        Next
        Dim consulta As String = "SELECT * FROM CONSOLIDADO,GESTIONES WHERE CONSOLIDADO .Id_Gestion =GESTIONES .Id_Gestion and (((CONSOLIDADO.FECHA_GESTION) Between '" & fechaini & "' And '" & fechafin & "'))and Usuario like '" & usuario & "';"
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

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim consulta1 As String
        Dim dttable1 As New DataTable
        Dim dom As Integer = 2

        consulta1 = "select Nombre_Usuario from USUARIOS Where Id_Dominio =" & dom & " order by Nombre_Usuario"
        Dim adaptadorsql1 As New SqlDataAdapter(consulta1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dttable1)

        Dim i As Integer

        For i = 0 To dttable1.Rows.Count - 1
            ComboBox1.Items.Add(dttable1.Rows(i).Item("Nombre_Usuario"))
        Next
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        DataGridView1.Show()
        DataGridView1.DataSource = bs
        cargar_registros(coneccion, DataGridView1)

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Call GridAExcel(DataGridView1)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        limpiar(Me)
        DataGridView1.Hide()
    End Sub
End Class