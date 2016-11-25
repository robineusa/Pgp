Public Class Creador_Notas

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim texto1 As String = Label1.Text
        Dim texto2 As String = DateTimePicker1.Text
        Dim texto3 As String = Label2.Text
        Dim texto4 As String = DateTimePicker2.Text
        Dim texto5 As String = Label3.Text
        Dim texto6 As String = DateTimePicker3.Text


        Dim texto7 As String = Button2.Text
        Dim texto8 As String = Label4.Text
        Dim texto9 As String = TextBox1.Text
        Dim texto10 As String = Label5.Text
        Dim texto11 As String = TextBox2.Text
        Dim texto12 As String = Label6.Text
        Dim texto13 As String = TextBox3.Text

        Dim texto14 As String = Button9.Text
        Dim texto15 As String = Label9.Text
        Dim texto16 As String = TextBox6.Text
        Dim texto17 As String = Label8.Text
        Dim texto18 As String = TextBox5.Text
        Dim texto19 As String = Label7.Text
        Dim texto20 As String = TextBox4.Text

        Dim texto21 As String = Button13.Text
        Dim texto22 As String = Label12.Text
        Dim texto23 As String = TextBox9.Text
        Dim texto24 As String = Label11.Text
        Dim texto25 As String = TextBox8.Text
        Dim texto26 As String = Label10.Text
        Dim texto27 As String = TextBox7.Text


        Dim resultado As String
        Dim medida As String = " $ "
        GroupBox1.Hide()
        GroupBox2.Hide()
        GroupBox3.Hide()
        GroupBox4.Hide()
        GroupBox5.Hide()

        RichTextBox1.Show()
        RichTextBox1.Location = New Point(20, 15)

        RichTextBox1.Size = New Size(570, 410)

        resultado = texto1 & texto2 + vbCrLf + texto3 & texto4 & texto5 & texto6 + vbCrLf + vbCrLf + texto7 + vbCrLf + texto8 & medida & texto9 + vbCrLf + texto10 & medida & texto11 + vbCrLf + texto12 & medida & texto13 + vbCrLf + vbCrLf + texto14 + vbCrLf + texto15 & medida & texto16 + vbCrLf + texto17 & medida & texto18 + vbCrLf + texto19 & medida & texto20 + vbCrLf + vbCrLf + texto21 + vbCrLf + texto22 & medida & texto23 + vbCrLf + texto24 & medida & texto25 + vbCrLf + texto26 & medida & texto27
        '" & texto2 & "' teniendo en cuenta "
        RichTextBox1.Text = resultado

        Me.RichTextBox1.SelectAll()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.MinDate = New DateTime(1985, 6, 12)
        DateTimePicker1.MaxDate = DateTime.Today
        DateTimePicker1.Format = DateTimePickerFormat.Short
        DateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd"

        DateTimePicker2.MinDate = New DateTime(1985, 6, 12)
        DateTimePicker2.MaxDate = DateTime.Today
        DateTimePicker2.Format = DateTimePickerFormat.Short
        DateTimePicker2.CustomFormat = "MMMM dd, yyyy - dddd"

        DateTimePicker3.MinDate = New DateTime(1985, 6, 12)
        DateTimePicker3.MaxDate = DateTime.Today
        DateTimePicker3.Format = DateTimePickerFormat.Short
        DateTimePicker3.CustomFormat = "MMMM dd, yyyy - dddd"

        TextBox1.Text = 0
        TextBox2.Text = 0
        TextBox3.Text = 0
        TextBox4.Text = 0
        TextBox5.Text = 0
        TextBox6.Text = 0
        TextBox7.Text = 0
        TextBox8.Text = 0
        TextBox9.Text = 0

        DateTimePicker1.Text = Today
        DateTimePicker2.Text = Today
        DateTimePicker3.Text = Today
        RichTextBox1.Hide()
        DateTimePicker1.Focus()
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        TextBox2.Focus()
        TextBox8.Enabled = True
        TextBox7.Enabled = True
        Label11.Visible = True
        Label10.Visible = True
        Button10.Visible = True
        Button11.Visible = True
        TextBox8.Visible = True
        TextBox7.Visible = True

    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        TextBox2.Focus()
        TextBox8.Enabled = True
        TextBox7.Enabled = True
        Label11.Visible = True
        Label10.Visible = True
        Button10.Visible = True
        Button11.Visible = True
        TextBox8.Visible = True
        TextBox7.Visible = True

    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        TextBox2.Focus()
        TextBox8.Enabled = True
        TextBox7.Enabled = True
        Label11.Visible = True
        Label10.Visible = True
        Button10.Visible = True
        Button11.Visible = True
        TextBox8.Visible = True
        TextBox7.Visible = True

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        TextBox2.Focus()
        TextBox8.Enabled = False
        TextBox7.Enabled = False
        Label11.Visible = False
        Label10.Visible = False
        Button10.Visible = False
        Button11.Visible = False
        TextBox8.Visible = False
        TextBox7.Visible = False
        TextBox9.Enabled = True
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        TextBox2.Focus()
        TextBox8.Enabled = False
        TextBox7.Enabled = False
        Label11.Visible = False
        Label10.Visible = False
        Button10.Visible = False
        Button11.Visible = False
        TextBox8.Visible = False
        TextBox7.Visible = False
        TextBox9.Enabled = True

    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        TextBox2.Focus()
        TextBox8.Enabled = False
        TextBox7.Enabled = False
        Label11.Visible = False
        Label10.Visible = False
        Button10.Visible = False
        Button11.Visible = False
        TextBox8.Visible = False
        TextBox7.Visible = False
        TextBox9.Enabled = True

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

        If TextBox2.Text <> "" Then

            TextBox1.Text = 0
            TextBox3.Text = 0
            Dim VALOR_IVA As Integer = 0
            Dim VALOR_SERVICIO As Integer = TextBox2.Text
            Dim VALOR_TOTAL As Integer = 0

            VALOR_IVA = VALOR_SERVICIO * 16 / 100
            TextBox3.Text = VALOR_IVA

            VALOR_TOTAL = VALOR_SERVICIO + VALOR_IVA
            TextBox1.Text = VALOR_TOTAL
        Else
            Exit Sub
            TextBox1.Text = 0
            TextBox3.Text = 0
        End If

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        If TextBox5.Text <> "" Then
            TextBox4.Text = 0
            TextBox6.Text = 0
            Dim VALOR_IVA As Integer = 0
            Dim VALOR_SERVICIO As Integer = TextBox5.Text
            Dim VALOR_TOTAL As Integer = 0
            Dim MEDIA As String = "$ "

            VALOR_IVA = VALOR_SERVICIO * 16 / 100
            TextBox4.Text = VALOR_IVA

            VALOR_TOTAL = VALOR_SERVICIO + VALOR_IVA

            TextBox6.Text = VALOR_TOTAL
        Else
            Exit Sub
            TextBox1.Text = 0
            TextBox3.Text = 0
        End If
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        If TextBox8.Text <> "" Then
            TextBox7.Text = 0
            TextBox9.Text = 0

            Dim VALOR_IVA As Integer = 0
            Dim VALOR_SERVICIO As Integer = TextBox8.Text
            Dim VALOR_TOTAL As Integer = 0
            Dim MEDIA As String = "$ "

            VALOR_IVA = VALOR_SERVICIO * 16 / 100
            TextBox7.Text = VALOR_IVA

            VALOR_TOTAL = VALOR_SERVICIO + VALOR_IVA

            TextBox9.Text = VALOR_TOTAL
        Else
            Exit Sub
            TextBox1.Text = 0
            TextBox3.Text = 0
        End If
    End Sub

    Public Sub cambiar(sender As Object, e As EventArgs) Handles RichTextBox1.Click
        Me.RichTextBox1.SelectAll()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        RichTextBox1.Copy()
        RichTextBox1.BackColor = Color.LightGray
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        DateTimePicker1.MinDate = New DateTime(1985, 6, 12)
        DateTimePicker1.MaxDate = DateTime.Today
        DateTimePicker1.Format = DateTimePickerFormat.Short
        DateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd"

        DateTimePicker2.MinDate = New DateTime(1985, 6, 12)
        DateTimePicker2.MaxDate = DateTime.Today
        DateTimePicker2.Format = DateTimePickerFormat.Short
        DateTimePicker2.CustomFormat = "MMMM dd, yyyy - dddd"

        DateTimePicker3.MinDate = New DateTime(1985, 6, 12)
        DateTimePicker3.MaxDate = DateTime.Today
        DateTimePicker3.Format = DateTimePickerFormat.Short
        DateTimePicker3.CustomFormat = "MMMM dd, yyyy - dddd"

        TextBox1.Text = 0
        TextBox2.Text = 0
        TextBox3.Text = 0
        TextBox4.Text = 0
        TextBox5.Text = 0
        TextBox6.Text = 0
        TextBox7.Text = 0
        TextBox8.Text = 0
        TextBox9.Text = 0

        DateTimePicker1.Text = Today
        DateTimePicker2.Text = Today
        DateTimePicker3.Text = Today
        RichTextBox1.Text = ""
        RichTextBox1.Hide()
        GroupBox1.Show()
        GroupBox2.Show()
        GroupBox3.Show()
        GroupBox4.Show()
        GroupBox5.Show()
        RichTextBox1.BackColor = Color.White
        DateTimePicker1.Focus()
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Me.Close()
    End Sub
    Private Sub suiguiente(sender As Object, e As EventArgs) Handles TextBox2.LostFocus
        TextBox5.Focus()
    End Sub
    Private Sub suiguiente2(sender As Object, e As EventArgs) Handles TextBox5.LostFocus

        If TextBox8.Visible = True Then
            TextBox8.Focus()
        Else
            TextBox9.Focus()
        End If

    End Sub
    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.LostFocus
        Button1.Focus()
    End Sub

    Private Sub nextss(sender As Object, e As EventArgs) Handles TextBox8.LostFocus
        Button1.Focus()
    End Sub
End Class