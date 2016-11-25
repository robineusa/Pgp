Imports System.Data.SqlClient

Public Class Generador_Datos_Moviletter

   
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If TextBox1.Text <> "" Then
            Dim dt1 As New DataTable
            Dim c1 As String
            Dim cuenta As Integer = TextBox1.Text

            c1 = "select * from TBL_CLIENTES_TODOS where CUENTA=" & cuenta & ""
            Dim adaptadorsql As New SqlDataAdapter(c1, New SqlConnection(coneccion))
            adaptadorsql.Fill(dt1)

            If adaptadorsql.Fill(dt1) <> 0 Then

                TextBox2.DataBindings.Add(New Binding("Text", dt1, "NOMBRE_1"))
                TextBox3.DataBindings.Add(New Binding("Text", dt1, "APELLIDO_1"))
                TextBox4.DataBindings.Add(New Binding("Text", dt1, "APELLIDO_2"))
                TextBox5.DataBindings.Add(New Binding("Text", dt1, "ESTADO_CUENTA"))
                TextBox6.DataBindings.Add(New Binding("Text", dt1, "TELEFONO_1"))
                TextBox7.DataBindings.Add(New Binding("Text", dt1, "TELEFONO_2"))
                TextBox8.DataBindings.Add(New Binding("Text", dt1, "DIR_INSTALACION"))
                TextBox9.DataBindings.Add(New Binding("Text", dt1, "COMUNIDAD"))
                TextBox10.DataBindings.Add(New Binding("Text", dt1, "DIVISION"))
                TextBox11.DataBindings.Add(New Binding("Text", dt1, "TARIFA"))
                TextBox12.DataBindings.Add(New Binding("Text", dt1, "CICLO_FACTURACION"))
                TextBox13.DataBindings.Add(New Binding("Text", dt1, "NODO"))
                TextBox14.DataBindings.Add(New Binding("Text", dt1, "ESTRATO"))
                Dim NOMBRE As String = TextBox2.Text
                Dim APELL1 As String = TextBox3.Text
                Dim APELL2 As String = TextBox4.Text
                Dim NOMBRE_COMPLETO As String
                Dim NOTA_1 As String = ""
                Dim TELEFONO1 As String = TextBox6.Text
                Dim TELEFONO2 As String = TextBox7.Text
                Dim NOTA_3 As String = "DESCONECTAR FISICAMENTE"
                Dim NOTA_4 As String = "ASEGURAMIENTO"

                Dim DIAACTUAL As Integer = Today.Day
                Dim MESACTUAL As Integer = Today.Month
                Dim DIA2 As String = ""
                Dim MES2 As String = ""

                If DIAACTUAL < 10 Then
                    DIA2 = "0" & Today.Day
                Else
                    DIA2 = Today.Day
                End If

                If MESACTUAL < 10 Then
                    MES2 = "0" & Today.Month
                Else
                    MES2 = Today.Month
                End If

                NOMBRE_COMPLETO = NOMBRE & " " & APELL1 & APELL2

                NOTA_1 = cuenta & " TEL: " & TELEFONO1 & " - " & TELEFONO2

                TextBox15.Text = NOTA_1
                TextBox16.Text = NOMBRE_COMPLETO
                TextBox17.Text = NOTA_3
                TextBox18.Text = NOTA_4
                TextBox19.Text = Today.Year & MES2 & DIA2
                PictureBox1.Visible = False
            Else
                MsgBox("Sin Información Exixtente")
            End If

        Else
            Exit Sub
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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
        TextBox18.DataBindings.Clear()
        TextBox19.DataBindings.Clear()

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
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
        TextBox18.Text = ""
        TextBox19.Text = ""

        PictureBox1.Visible = True
    End Sub
End Class