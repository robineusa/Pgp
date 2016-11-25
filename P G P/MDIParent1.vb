Imports System
Imports System.Data

Imports SkinSoft.OSSkin
Imports System.Data.SqlClient

Public Class MDIParent1
    Private Sub tbSkin2_Clicked(ByVal sender As Object, ByVal e As EventArgs)
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")

    End Sub
    Private Sub MDIParent1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Dim c1 As String
            Dim tipo As Integer
            Dim dttable, dt1 As New DataTable

            c1 = "select Id_Dominio  from USUARIOS where Nombre_Usuario like'" & nombreusuario & "'"
            Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
            adaptadorsql1.Fill(dt1)

            Dim i As Integer

            For i = 0 To dt1.Rows.Count - 1
                tipo = dt1.Rows(i).Item("Id_Dominio")

            Next

            If tipo = 1 Then
                
            Else
                If tipo = 2 Then

                    toolStrip1.Visible = True
                    ToolStrip2.Visible = False
                    ToolStrip3.Visible = False
                    ToolStrip4.Visible = False

                    toolStrip1.Enabled = True
                    ToolStrip2.Enabled = False
                    ToolStrip3.Enabled = False
                    ToolStrip4.Enabled = False

                    toolStrip1.Show()
                    ToolStrip2.Hide()
                    ToolStrip3.Hide()
                    ToolStrip4.Hide()

                    MyBase.Text = String.Format("Gestion Aseguramiento del Churn")
                    ToolStripLabel1.Text = Today
                    ToolStripLabel3.Text = nombreusuario
                    ToolStripLabel1.Text = "                                                                                 "
                Else
                    If tipo = 3 Then

                        toolStrip1.Visible = False
                        ToolStrip2.Visible = False
                        ToolStrip3.Visible = True
                        ToolStrip4.Visible = False

                        toolStrip1.Enabled = False
                        ToolStrip2.Enabled = False
                        ToolStrip3.Enabled = True
                        ToolStrip4.Enabled = False

                        toolStrip1.Hide()
                        ToolStrip2.Hide()
                        ToolStrip3.Show()
                        ToolStrip4.Hide()

                        MyBase.Text = String.Format("Gestion Control del Churn")
                        ToolStripLabel8.Text = Today
                        ToolStripLabel11.Text = nombreusuario
                        ToolStripLabel9.Text = "                                                                                                                              "
                    Else
                        If tipo = 4 Then

                            toolStrip1.Visible = False
                            ToolStrip2.Visible = True
                            ToolStrip3.Visible = False
                            ToolStrip4.Visible = False

                            toolStrip1.Enabled = False
                            ToolStrip2.Enabled = True
                            ToolStrip3.Enabled = False
                            ToolStrip4.Enabled = False

                            toolStrip1.Hide()
                            ToolStrip2.Show()
                            ToolStrip3.Hide()
                            ToolStrip4.Hide()

                            MyBase.Text = String.Format("Supervision de Gestiones")
                            ToolStripLabel6.Text = Today
                            ToolStripLabel5.Text = nombreusuario
                            ToolStripLabel7.Text = "                                                                                                      "
                        Else
                            If tipo = 5 Then
                                toolStrip1.Visible = False
                                ToolStrip2.Visible = False
                                ToolStrip2.Enabled = False
                                ToolStrip3.Enabled = False
                                ToolStrip3.Visible = False
                                toolStrip1.Hide()
                                ToolStrip2.Hide()
                                ToolStrip3.Hide()
                                ToolStrip4.Show()
                                ToolStrip4.Enabled = True
                                ToolStrip4.Visible = True
                                MyBase.Text = String.Format("Supervision de Gestiones")
                                ToolStripLabel12.Text = Today
                                ToolStripLabel13.Text = nombreusuario
                                ToolStripLabel10.Text = "                                                                     "
                            End If
                        End If
                        End If
                End If
                End If
        Finally
        End Try
    End Sub

    Private Sub tbShadowStyle_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Update shadow
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Select Case CStr(menuItem.Tag)
            Case "SMALL"
                OsSkin1.ShadowStyle = ShadowStyle.Small
            Case "MEDIUM"
                OsSkin1.ShadowStyle = ShadowStyle.Medium
            Case "BOLD"
                OsSkin1.ShadowStyle = ShadowStyle.Bold
        End Select
    End Sub
    Private Sub ActualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Congelaciones.Show()
    End Sub

    Private Sub ConsultarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Estado_Congelaciones.Show()
    End Sub
    Private Sub Cerrar_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Dim c1 As String
            Dim tipo As Integer
            Dim dttable, dt1 As New DataTable

            c1 = "select Id_Dominio  from USUARIOS where Nombre_Usuario like'" & nombreusuario & "'"
            Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
            adaptadorsql1.Fill(dt1)

            Dim i As Integer

            For i = 0 To dt1.Rows.Count - 1
                tipo = dt1.Rows(i).Item("Id_Dominio")

            Next

            If tipo = 1 Then

            Else
                If tipo = 2 Then
                    Deslogueo.Show()
                Else
                    If tipo = 3 Then
                        Deslogueo.Show()
                    Else
                        If tipo = 4 Then
                            Deslogueo.Show()
                        Else
                            If tipo = 5 Then
                                Deslogueo.Show()
                            End If
                        End If
                    End If
                End If
            End If
        Finally
        End Try

    End Sub

    Private Sub ToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
        End Select
        OsSkin1.Style = style
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub LiberacionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Liberaciones.Show()
    End Sub

    Private Sub ToolStripMenuItem49_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem49.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Gestion Aseguramiento del Churn")
    End Sub

    Private Sub ToolStripMenuItem50_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem50.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Gestion Aseguramiento del Churn")
    End Sub

    Private Sub ToolStripMenuItem51_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem51.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Gestion Aseguramiento del Churn")
    End Sub

    Private Sub ToolStripMenuItem52_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem52.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Gestion Aseguramiento del Churn")
    End Sub

    Private Sub ToolStripMenuItem54_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem54.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Gestion Aseguramiento del Churn")
    End Sub

    Private Sub ToolStripMenuItem55_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem55.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Gestion Aseguramiento del Churn")
    End Sub

    Private Sub ToolStripMenuItem56_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem56.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Gestion Aseguramiento del Churn")
    End Sub

    Private Sub ToolStripMenuItem47_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem47.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Gestion Aseguramiento del Churn")
    End Sub

    Private Sub ToolStripMenuItem57_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem57.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Gestion Aseguramiento del Churn")
    End Sub

    Private Sub ToolStripMenuItem58_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem58.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Gestion Aseguramiento del Churn")
    End Sub

    Private Sub ToolStripMenuItem60_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem60.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Gestion Aseguramiento del Churn")
    End Sub

    Private Sub ToolStripMenuItem61_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem61.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Gestion Aseguramiento del Churn")
    End Sub

    Private Sub ToolStripMenuItem62_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem62.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Gestion Aseguramiento del Churn")
    End Sub

    Private Sub ToolStripMenuItem63_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem63.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Gestion Aseguramiento del Churn")
    End Sub

    Private Sub ToolStripMenuItem64_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem64.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Gestion Aseguramiento del Churn")
    End Sub

    Private Sub ToolStripMenuItem66_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem66.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Gestion Aseguramiento del Churn")
    End Sub

    Private Sub ToolStripMenuItem67_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem67.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Gestion Aseguramiento del Churn")
    End Sub

    Private Sub ToolStripMenuItem68_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem68.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Gestion Aseguramiento del Churn")
    End Sub

    Private Sub ToolStripMenuItem70_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem70.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Gestion Aseguramiento del Churn")
    End Sub

    Private Sub ToolStripMenuItem71_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem71.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Gestion Aseguramiento del Churn")
    End Sub

    Private Sub SmallToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SmallToolStripMenuItem.Click
        ' Update shadow
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Select Case CStr(SmallToolStripMenuItem.Tag)

            Case "SMALL"
                OsSkin1.ShadowStyle = ShadowStyle.Small
            Case "MEDIUM"
                OsSkin1.ShadowStyle = ShadowStyle.Medium
            Case "BOLD"
                OsSkin1.ShadowStyle = ShadowStyle.Bold
        End Select
    End Sub

    Private Sub MediumToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MediumToolStripMenuItem.Click
        ' Update shadow
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Select Case CStr(MediumToolStripMenuItem.Tag)
            Case "SMALL"
                OsSkin1.ShadowStyle = ShadowStyle.Small
            Case "MEDIUM"
                OsSkin1.ShadowStyle = ShadowStyle.Medium
            Case "BOLD"
                OsSkin1.ShadowStyle = ShadowStyle.Bold
        End Select
    End Sub

    Private Sub BouldToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BouldToolStripMenuItem.Click
        ' Update shadow
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Select Case CStr(BouldToolStripMenuItem.Tag)

            Case "SMALL"
                OsSkin1.ShadowStyle = ShadowStyle.Small
            Case "MEDIUM"
                OsSkin1.ShadowStyle = ShadowStyle.Medium
            Case "BOLD"
                OsSkin1.ShadowStyle = ShadowStyle.Bold
        End Select
    End Sub
    Private Sub ToolStripMenuItem100_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem100.Click
        OsSkin1.ShadowStyle = ShadowStyle.Bold
        OsSkin1.ShadowVisible = False
    End Sub

    Private Sub ComunidadVirtualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComunidadVirtualToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://comunidadvirtual.claro.com.co")
    End Sub

    Private Sub ModuloDeGestiónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModuloDeGestiónToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://agendamiento.cable.net.co")
    End Sub

    Private Sub OutlookWebToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OutlookWebToolStripMenuItem.Click
        System.Diagnostics.Process.Start("https://webmail.telmexla.com.co")
    End Sub

    Private Sub WebMailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WebMailToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://webmail.claro.net.co/")
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dt1 As New DataTable
        Dim c1 As String
        c1 = "select Nombre_Gestion from USUARIOS ,GESTIONES where USUARIOS .Id_Gestion =GESTIONES .Id_Gestion and Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql18 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql18.Fill(dt1)

        Dim i As Integer
        Dim ges1 As String = ""
        For i = 0 To dt1.Rows.Count - 1
            ges1 = (dt1.Rows(i).Item("Nombre_Gestion"))
        Next


        Dim dt2 As New DataTable
        Dim c2 As String
        c2 = "select Nombre_Gestion2 from USUARIOS ,GESTIONES2 where USUARIOS .Id_Gestion2 =GESTIONES2 .Id_Gestion2 and Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql19 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
        adaptadorsql19.Fill(dt2)

        Dim j As Integer
        Dim ges2 As String = ""
        For j = 0 To dt2.Rows.Count - 1
            ges2 = (dt2.Rows(j).Item("Nombre_Gestion2"))
        Next

        If ges1 = "Casos Vencidos" Then
            Dim CE As New Gestion_Vencidos()

            'Set the Parent Form of the Child window.
            CE.MdiParent = Me
            'Display the new form.
            CE.Show()
            CE.StartPosition = FormStartPosition.CenterScreen

        Else
            If ges2 = "Casos Vencidos" Then
                Dim CE As New Gestion_Vencidos()
                'Set the Parent Form of the Child window.
                CE.MdiParent = Me
                'Display the new form.
                CE.Show()
                CE.StartPosition = FormStartPosition.CenterScreen
            Else
                MsgBox("Usted no esta autorizado para realizar esta Gestion")
            End If
        End If

    End Sub
    Private Sub ConsultarToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultarToolStripMenuItem.Click
        Dim CE As New Consulta_Individual_Productividad()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub
    Private Sub ToolStripMenuItem97_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim CE As New Hallazgos()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem102_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem102.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem103_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem103.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem104_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem104.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem105_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem105.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem107_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem107.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem108_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem108.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem109_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem109.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem111_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem111.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem112_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem112.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem113_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem113.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem115_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem115.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem116_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem116.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem117_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem117.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem118_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem118.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem119_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem119.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem121_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem121.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem122_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem122.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem123_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem123.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem125_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem125.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem126_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem126.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem129_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem129.Click
        ' Update shadow
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Select Case CStr(SmallToolStripMenuItem.Tag)

            Case "SMALL"
                OsSkin1.ShadowStyle = ShadowStyle.Small
            Case "MEDIUM"
                OsSkin1.ShadowStyle = ShadowStyle.Medium
            Case "BOLD"
                OsSkin1.ShadowStyle = ShadowStyle.Bold
        End Select
    End Sub

    Private Sub ToolStripMenuItem130_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem130.Click
        ' Update shadow
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Select Case CStr(SmallToolStripMenuItem.Tag)

            Case "SMALL"
                OsSkin1.ShadowStyle = ShadowStyle.Small
            Case "MEDIUM"
                OsSkin1.ShadowStyle = ShadowStyle.Medium
            Case "BOLD"
                OsSkin1.ShadowStyle = ShadowStyle.Bold
        End Select
    End Sub

    Private Sub ToolStripMenuItem131_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem131.Click
        ' Update shadow
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Select Case CStr(SmallToolStripMenuItem.Tag)

            Case "SMALL"
                OsSkin1.ShadowStyle = ShadowStyle.Small
            Case "MEDIUM"
                OsSkin1.ShadowStyle = ShadowStyle.Medium
            Case "BOLD"
                OsSkin1.ShadowStyle = ShadowStyle.Bold
        End Select
    End Sub

    Private Sub ToolStripMenuItem98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim CE As New Cambio_De_Clave()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem36.Click
        System.Diagnostics.Process.Start("http://comunidadvirtual.claro.com.co")
    End Sub

    Private Sub ToolStripMenuItem37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem37.Click
        System.Diagnostics.Process.Start("http://agenadmiento.cable.net.co")
    End Sub

    Private Sub ToolStripMenuItem38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem38.Click
        System.Diagnostics.Process.Start("https://webmail.telmexla.com.co")
    End Sub

    Private Sub ToolStripMenuItem39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem39.Click
        System.Diagnostics.Process.Start("http://webmail.claro.net.co/")
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub PorUsuariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PorUsuariosToolStripMenuItem.Click
        Dim CE As New Consolidado()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub PorFechasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PorFechasToolStripMenuItem.Click
        Dim CE As New Consolidado_Por_Fechas()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub IndividualPorGestionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IndividualPorGestionToolStripMenuItem.Click
        Dim CE As New Consolidado_Por_Gestiones()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ConsultarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultarToolStripMenuItem1.Click
        Dim CE As New Servicios_Desconectados()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ConsultarToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultarToolStripMenuItem2.Click
        Dim CE As New Cuentas_Desconectadas()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem10.Click
        Dim CE As New Estado_Agendamiento()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem11_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim CE As New Estado_Casos_Vencidos()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem12.Click
        Dim CE As New Estado_Congelaciones()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem13.Click
        Dim CE As New Estado_Desconexiones()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem14.Click
        Dim CE As New Estado_Liberaciones()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem15.Click
        Dim CE As New Reporte_Posventas()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem16.Click
        Dim CE As New Estado_Tarifa_TRE()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem17.Click
        Dim CE As New Estado_Tickets()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem18.Click
        Dim CE As New Reporte_de_Traslados()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem22.Click
        Dim CE As New Estado_Asig_Casos_Vencidos()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem24.Click
        Dim CE As New Estado_Asig_Congelaciones()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem26.Click
        Dim CE As New Estado_Asig_Desconexiones()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem30.Click
        Dim CE As New Estado_Asig_Posventas()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem32.Click
        Dim CE As New Estado_Asignacion_TRE()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem34.Click
        Dim CE As New Estado_Asig_Tickets()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem40.Click
        Dim CE As New Estado_Asig_Traslados()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem41.Click
        Dim CE As New Reporte_Escalamientos()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ReporteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteToolStripMenuItem.Click
        Dim CE As New Reporte_Hallazgos()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ValidacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValidacionToolStripMenuItem.Click
        Dim CE As New Validación_hallazgos()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub
    Private Sub OpcionesDeUsuarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpcionesDeUsuarioToolStripMenuItem.Click
        Dim CE As New Usuarios()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub
    Private Sub ToolStripMenuItem28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem28.Click
        Dim CE As New Cambio_De_Clave()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ToolStripMenuItem132_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem132.Click
        Me.Close()
    End Sub

    Private Sub ToolStripMenuItem134_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem134.Click
        Dim CE As New Cambio_De_Clave()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem138_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem138.Click
        Dim CE As New Consulta_Hallazgos()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem139_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem139.Click
        Dim CE As New Hallazgos()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem135_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem135.Click
        Dim CE As New Consulta_Escalamientos()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem136_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem136.Click
        Dim CE As New Escalamientos_anterior()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem137_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem137.Click
        Dim CE As New Escalamientos_Consultar()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem98_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem98.Click
        Dim CE As New Notas()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub AdherenciaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdherenciaToolStripMenuItem.Click
        Dim CE As New Adherencia()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem44_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim CE As New Congelaciones_Ingreso()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub
    Private Sub ToolStripMenuItem20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem20.Click
        Dim CE As New Estado_Asig_Agendamiento()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub
    Private Sub ToolStripMenuItem187_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem187.Click
        System.Diagnostics.Process.Start("http://comunidadvirtual.claro.com.co")
    End Sub

    Private Sub ToolStripMenuItem188_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem188.Click
        System.Diagnostics.Process.Start("http://agenadmiento.cable.net.co")
    End Sub

    Private Sub ToolStripMenuItem189_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem189.Click
        System.Diagnostics.Process.Start("https://webmail.telmexla.com.co")
    End Sub

    Private Sub ToolStripMenuItem190_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem190.Click
        System.Diagnostics.Process.Start("http://webmail.claro.net.co/")
    End Sub

    Private Sub ToolStripMenuItem193_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem193.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Análisis y seguimiento de bajas")
    End Sub

    Private Sub ToolStripMenuItem194_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem194.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Análisis y seguimiento de bajas")
    End Sub

    Private Sub ToolStripMenuItem195_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem195.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Análisis y seguimiento de bajas")
    End Sub

    Private Sub ToolStripMenuItem196_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem196.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Análisis y seguimiento de bajas")
    End Sub

    Private Sub ToolStripMenuItem198_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem198.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Análisis y seguimiento de bajas")
    End Sub

    Private Sub ToolStripMenuItem199_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem199.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Análisis y seguimiento de bajas")
    End Sub

    Private Sub ToolStripMenuItem200_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem200.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Análisis y seguimiento de bajas")
    End Sub

    Private Sub ToolStripMenuItem202_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem202.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Análisis y seguimiento de bajas")
    End Sub

    Private Sub ToolStripMenuItem203_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem203.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Análisis y seguimiento de bajas")
    End Sub

    Private Sub ToolStripMenuItem204_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem204.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Análisis y seguimiento de bajas")
    End Sub

    Private Sub ToolStripMenuItem206_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem206.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Análisis y seguimiento de bajas")
    End Sub

    Private Sub ToolStripMenuItem207_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem207.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Análisis y seguimiento de bajas")
    End Sub

    Private Sub ToolStripMenuItem208_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem208.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Análisis y seguimiento de bajas")
    End Sub

    Private Sub ToolStripMenuItem209_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem209.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Análisis y seguimiento de bajas")
    End Sub

    Private Sub ToolStripMenuItem210_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem210.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Análisis y aseguramiento de bajas")
    End Sub

    Private Sub ToolStripMenuItem212_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem212.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Análisis y seguimiento de bajas")
    End Sub

    Private Sub ToolStripMenuItem213_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem213.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Análisis y seguimiento de bajas")
    End Sub

    Private Sub ToolStripMenuItem214_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem214.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Análisis y seguimiento de bajas")
    End Sub

    Private Sub ToolStripMenuItem216_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem216.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Análisis y seguimiento de bajas")
    End Sub

    Private Sub ToolStripMenuItem217_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem217.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Análisis y seguimiento de bajas")
    End Sub

    Private Sub ToolStripMenuItem151_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem151.Click
        Dim CE As New Consolidado_Por_Fechas()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem152_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem152.Click
        Dim CE As New Consolidado_Por_Gestiones()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem153_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem153.Click
        Dim CE As New Consolidado()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem144_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem144.Click
        Dim CE As New Servicios_Desconectados()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem146_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem146.Click
        Dim CE As New Cuentas_Desconectadas()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem234_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem234.Click
        Dim CE As New Usuarios_Control()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem243_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem243.Click
        System.Diagnostics.Process.Start("http://comunidadvirtual.claro.com.co")
    End Sub

    Private Sub ToolStripMenuItem244_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem244.Click
        System.Diagnostics.Process.Start("http://agenadmiento.cable.net.co")
    End Sub

    Private Sub ToolStripMenuItem245_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem245.Click
        System.Diagnostics.Process.Start("https://webmail.telmexla.com.co")
    End Sub

    Private Sub ToolStripMenuItem246_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem246.Click
        System.Diagnostics.Process.Start("http://webmail.claro.net.co/")
    End Sub

    Private Sub ToolStripMenuItem280_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem280.Click
        Dim CE As New Cambio_De_Clave()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem249_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem249.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem250_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem250.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem251_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem251.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem252_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem252.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem254_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem254.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem255_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem255.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem256_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem256.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem258_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem258.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem259_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem259.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem260_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem260.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem262_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem262.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem263_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem263.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem264_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem264.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem265_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem265.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem266_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem266.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem268_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem268.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem269_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem269.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem270_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem270.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem272_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem272.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem273_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem273.Click
        ' Get menu item
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Update skin style
        Dim style As SkinStyle
        Select Case CStr(menuItem.Tag)
            Case "XPBLUE"
                style = SkinStyle.XpBlue
            Case "XPOLIVE"
                style = SkinStyle.XpOlive
            Case "XPSILVER"
                style = SkinStyle.XpSilver
            Case "XPROYALE"
                style = SkinStyle.XpRoyale
            Case "OFFICEBLUE"
                style = SkinStyle.Office2007Blue
            Case "OFFICEBLACK"
                style = SkinStyle.Office2007Black
            Case "OFFICESILVER"
                style = SkinStyle.Office2007Silver
            Case "OFFICE2010SILVER"
                style = SkinStyle.Office2010Silver
            Case "OFFICE2010BLUE"
                style = SkinStyle.Office2010Blue
            Case "VISTABASIC"
                style = SkinStyle.VistaBlue
            Case "VISTABLACK"
                style = SkinStyle.VistaBlack
            Case "VISTASILVER"
                style = SkinStyle.VistaSilver
            Case "AEROBLUE"
                style = SkinStyle.AeroBlue
            Case "AEROBLACK"
                style = SkinStyle.AeroBlack
            Case "AEROSILVER"
                style = SkinStyle.AeroSilver
            Case "OSXTIGER"
                style = SkinStyle.MacOSXTiger
            Case "OSXPANTHER"
                style = SkinStyle.MacOSXPanther
            Case "OSXLEOPARD"
                style = SkinStyle.MacOSXLeopard
            Case "OSXITUNES"
                style = SkinStyle.MacOSXiTunes
            Case "OSXBRUSHED"
                style = SkinStyle.MacOSXBrushed

            Case Else
                style = SkinStyle.Office2007Blue
        End Select

        OsSkin1.Style = style

        ' Update skin information
        Dim skinName As String = OsSkin1.Style.ToString()
        MyBase.Text = String.Format("Supervision de Gestiones")
    End Sub

    Private Sub ToolStripMenuItem233_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem233.Click
        Dim CE As New Adherencia()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub
    Private Sub ToolStripMenuItem148_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem148.Click
        Dim CE As New Estado_Movimiento()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem168_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem168.Click
        Dim CE As New Estado_asig_movimiento()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub
    Private Sub ToolStripMenuItem91_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem91.Click
        Dim CE As New Detalle_Logueo()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem142_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem142.Click
        Dim CE As New Detalle_Logueo()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem174_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem174.Click
        Dim CE As New Notas()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem159_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim CE As New Gestion_Correos()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem226_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem226.Click
        Dim CE As New Agendamiento_Ingreso
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem227_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem227.Click

        Dim dt1 As New DataTable
        Dim c1 As String
        c1 = "select Nombre_Gestion from USUARIOS ,GESTIONES where USUARIOS .Id_Gestion =GESTIONES .Id_Gestion and Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql18 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql18.Fill(dt1)

        Dim i As Integer
        Dim ges1 As String = ""
        For i = 0 To dt1.Rows.Count - 1
            ges1 = (dt1.Rows(i).Item("Nombre_Gestion"))
        Next


        Dim dt2 As New DataTable
        Dim c2 As String
        c2 = "select Nombre_Gestion2 from USUARIOS ,GESTIONES2 where USUARIOS .Id_Gestion2 =GESTIONES2 .Id_Gestion2 and Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql19 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
        adaptadorsql19.Fill(dt2)

        Dim j As Integer
        Dim ges2 As String = ""
        For j = 0 To dt2.Rows.Count - 1
            ges2 = (dt2.Rows(j).Item("Nombre_Gestion2"))
        Next


        If ges1 = "Agendamiento" Then

            Dim CE As New Agendamiento()
            'Set the Parent Form of the Child window.
            CE.MdiParent = Me
            'Display the new form.
            CE.Show()
            CE.StartPosition = FormStartPosition.CenterScreen
        Else
            If ges2 = "Agendamiento" Then
                Dim CE As New Agendamiento()
                'Set the Parent Form of the Child window.
                CE.MdiParent = Me
                'Display the new form.
                CE.Show()
                CE.StartPosition = FormStartPosition.CenterScreen
            Else
                MsgBox("Usted no esta autorizado para realizar esta Gestion")
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItem186_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem186.Click

        Dim dt1 As New DataTable
        Dim c1 As String
        c1 = "select Nombre_Gestion from USUARIOS ,GESTIONES where USUARIOS .Id_Gestion =GESTIONES .Id_Gestion and Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql18 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql18.Fill(dt1)

        Dim i As Integer
        Dim ges1 As String = ""
        For i = 0 To dt1.Rows.Count - 1
            ges1 = (dt1.Rows(i).Item("Nombre_Gestion"))
        Next


        Dim dt2 As New DataTable
        Dim c2 As String
        c2 = "select Nombre_Gestion2 from USUARIOS ,GESTIONES2 where USUARIOS .Id_Gestion2 =GESTIONES2 .Id_Gestion2 and Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql19 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
        adaptadorsql19.Fill(dt2)

        Dim j As Integer
        Dim ges2 As String = ""
        For j = 0 To dt2.Rows.Count - 1
            ges2 = (dt2.Rows(j).Item("Nombre_Gestion2"))
        Next


        If ges1 = "Congelaciones" Then

            Dim CE As New Congelaciones()
            'Set the Parent Form of the Child window.
            CE.MdiParent = Me
            'Display the new form.
            CE.Show()
            CE.StartPosition = FormStartPosition.CenterScreen
        Else
            If ges2 = "Congelaciones" Then
                Dim CE As New Congelaciones()
                'Set the Parent Form of the Child window.
                CE.MdiParent = Me
                'Display the new form.
                CE.Show()
                CE.StartPosition = FormStartPosition.CenterScreen
            Else
                MsgBox("Usted no esta autorizado para realizar esta Gestion")
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItem185_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem185.Click
        Dim CE As New Congelaciones_Ingreso()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem161_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem161.Click

        Dim dt1 As New DataTable
        Dim c1 As String
        c1 = "select Nombre_Gestion from USUARIOS ,GESTIONES where USUARIOS .Id_Gestion =GESTIONES .Id_Gestion and Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql18 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql18.Fill(dt1)

        Dim i As Integer
        Dim ges1 As String = ""
        For i = 0 To dt1.Rows.Count - 1
            ges1 = (dt1.Rows(i).Item("Nombre_Gestion"))
        Next


        Dim dt2 As New DataTable
        Dim c2 As String
        c2 = "select Nombre_Gestion2 from USUARIOS ,GESTIONES2 where USUARIOS .Id_Gestion2 =GESTIONES2 .Id_Gestion2 and Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql19 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
        adaptadorsql19.Fill(dt2)

        Dim j As Integer
        Dim ges2 As String = ""
        For j = 0 To dt2.Rows.Count - 1
            ges2 = (dt2.Rows(j).Item("Nombre_Gestion2"))
        Next


        If ges1 = "Desconexiones" Then

            Dim CE As New Desconexiones()
            'Set the Parent Form of the Child window.
            CE.MdiParent = Me
            'Display the new form.
            CE.Show()
            CE.StartPosition = FormStartPosition.CenterScreen
        Else

            If ges2 = "Desconexiones" Then

                Dim CE As New Desconexiones()
                'Set the Parent Form of the Child window.
                CE.MdiParent = Me
                'Display the new form.
                CE.Show()
                CE.StartPosition = FormStartPosition.CenterScreen
            Else

                MsgBox("Usted no esta autorizado para realizar esta Gestion")
            End If

        End If
    End Sub

    Private Sub ToolStripMenuItem160_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem160.Click
        Dim CE As New Desconexiones_Ingreso()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem231_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem231.Click
        Dim dt1 As New DataTable
        Dim c1 As String
        c1 = "select Nombre_Gestion from USUARIOS ,GESTIONES where USUARIOS .Id_Gestion =GESTIONES .Id_Gestion and Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql18 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql18.Fill(dt1)

        Dim i As Integer
        Dim ges1 As String = ""
        For i = 0 To dt1.Rows.Count - 1
            ges1 = (dt1.Rows(i).Item("Nombre_Gestion"))
        Next


        Dim dt2 As New DataTable
        Dim c2 As String
        c2 = "select Nombre_Gestion2 from USUARIOS ,GESTIONES2 where USUARIOS .Id_Gestion2 =GESTIONES2 .Id_Gestion2 and Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql19 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
        adaptadorsql19.Fill(dt2)

        Dim j As Integer
        Dim ges2 As String = ""
        For j = 0 To dt2.Rows.Count - 1
            ges2 = (dt2.Rows(j).Item("Nombre_Gestion2"))
        Next


        If ges1 = "Posventas" Then
            Dim CE As New Posventas()
            'Set the Parent Form of the Child window.
            CE.MdiParent = Me
            'Display the new form.
            CE.Show()
            CE.StartPosition = FormStartPosition.CenterScreen
        Else
            If ges2 = "Posventas" Then
                Dim CE As New Posventas()
                'Set the Parent Form of the Child window.
                CE.MdiParent = Me
                'Display the new form.
                CE.Show()
                CE.StartPosition = FormStartPosition.CenterScreen
            Else
                MsgBox("Usted no esta autorizado para realizar esta Gestion")
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItem230_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem230.Click
        Dim CE As New Posventas_Ingreso()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem182_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem182.Click
        Dim dt1 As New DataTable
        Dim c1 As String
        c1 = "select Nombre_Gestion from USUARIOS ,GESTIONES where USUARIOS .Id_Gestion =GESTIONES .Id_Gestion and Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql18 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql18.Fill(dt1)

        Dim i As Integer
        Dim ges1 As String = ""
        For i = 0 To dt1.Rows.Count - 1
            ges1 = (dt1.Rows(i).Item("Nombre_Gestion"))
        Next


        Dim dt2 As New DataTable
        Dim c2 As String
        c2 = "select Nombre_Gestion2 from USUARIOS ,GESTIONES2 where USUARIOS .Id_Gestion2 =GESTIONES2 .Id_Gestion2 and Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql19 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
        adaptadorsql19.Fill(dt2)

        Dim j As Integer
        Dim ges2 As String = ""
        For j = 0 To dt2.Rows.Count - 1
            ges2 = (dt2.Rows(j).Item("Nombre_Gestion2"))
        Next


        If ges1 = "Tarifa Tre" Then
            Dim CE As New Tre_Gestion_Nueva()
            'Set the Parent Form of the Child window.
            CE.MdiParent = Me
            'Display the new form.
            CE.Show()
            CE.StartPosition = FormStartPosition.CenterScreen
        Else
            If ges2 = "Tarifa Tre" Then
                Dim CE As New Tre_Gestion_Nueva()
                'Set the Parent Form of the Child window.
                CE.MdiParent = Me
                'Display the new form.
                CE.Show()
                CE.StartPosition = FormStartPosition.CenterScreen
            Else
                MsgBox("Usted no esta autorizado para realizar esta Gestion")
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItem181_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem181.Click
        Dim CE As New Tre_Nueva_Ingreso()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub
    Private Sub ToolStripMenuItem183_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem183.Click
        Dim CE As New Tickets_Ingreso()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem165_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem165.Click

        Dim dt1 As New DataTable
        Dim c1 As String
        c1 = "select Nombre_Gestion from USUARIOS ,GESTIONES where USUARIOS .Id_Gestion =GESTIONES .Id_Gestion and Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql18 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql18.Fill(dt1)

        Dim i As Integer
        Dim ges1 As String = ""
        For i = 0 To dt1.Rows.Count - 1
            ges1 = (dt1.Rows(i).Item("Nombre_Gestion"))
        Next


        Dim dt2 As New DataTable
        Dim c2 As String
        c2 = "select Nombre_Gestion2 from USUARIOS ,GESTIONES2 where USUARIOS .Id_Gestion2 =GESTIONES2 .Id_Gestion2 and Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql19 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
        adaptadorsql19.Fill(dt2)

        Dim j As Integer
        Dim ges2 As String = ""
        For j = 0 To dt2.Rows.Count - 1
            ges2 = (dt2.Rows(j).Item("Nombre_Gestion2"))
        Next


        If ges1 = "Liberacones de HHPP" Then
            Dim CE As New Liberaciones()
            'Set the Parent Form of the Child window.
            CE.MdiParent = Me
            'Display the new form.
            CE.Show()
            CE.StartPosition = FormStartPosition.CenterScreen
        Else
            If ges2 = "Liberacones de HHPP" Then
                Dim CE As New Liberaciones()
                'Set the Parent Form of the Child window.
                CE.MdiParent = Me
                'Display the new form.
                CE.Show()
                CE.StartPosition = FormStartPosition.CenterScreen
            Else
                MsgBox("Usted no esta autorizado para realizar esta Gestion")
            End If
        End If

    End Sub
    Private Sub ToolStripMenuItem229_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem229.Click

        Dim dt1 As New DataTable
        Dim c1 As String
        c1 = "select Nombre_Gestion from USUARIOS ,GESTIONES where USUARIOS .Id_Gestion =GESTIONES .Id_Gestion and Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql18 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql18.Fill(dt1)

        Dim i As Integer
        Dim ges1 As String = ""
        For i = 0 To dt1.Rows.Count - 1
            ges1 = (dt1.Rows(i).Item("Nombre_Gestion"))
        Next


        Dim dt2 As New DataTable
        Dim c2 As String
        c2 = "select Nombre_Gestion2 from USUARIOS ,GESTIONES2 where USUARIOS .Id_Gestion2 =GESTIONES2 .Id_Gestion2 and Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql19 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
        adaptadorsql19.Fill(dt2)

        Dim j As Integer
        Dim ges2 As String = ""
        For j = 0 To dt2.Rows.Count - 1
            ges2 = (dt2.Rows(j).Item("Nombre_Gestion2"))
        Next


        If ges1 = "Traslados" Then
            Dim CE As New Traslados()
            'Set the Parent Form of the Child window.
            CE.MdiParent = Me
            'Display the new form.
            CE.Show()
            CE.StartPosition = FormStartPosition.CenterScreen

        Else
            If ges2 = "Traslados" Then
                Dim CE As New Traslados()
                'Set the Parent Form of the Child window.
                CE.MdiParent = Me
                'Display the new form.
                CE.Show()
                CE.StartPosition = FormStartPosition.CenterScreen
            Else
                MsgBox("Usted no esta autorizado para realizar esta Gestion")
            End If
        End If

    End Sub

    Private Sub ToolStripMenuItem228_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem228.Click
        Dim CE As New Traslados_Ingreso()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub NovedadesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NovedadesToolStripMenuItem.Click
        Dim CE As New Registro_Novedades()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub NovedadesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NovedadesToolStripMenuItem1.Click
        Dim CE As New Aprobacion_Novedades()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripButton5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Label1.DataBindings.Clear()
        Dim c1, c2, c3 As String
        Dim dt1, dt2, dt3 As New DataTable
        Dim dato1 As String = ""
        Dim porcentaje As Integer = 0
        Dim fecha As String = Today

        c1 = "Select Usuario from USUARIOS where Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql1 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql1.Fill(dt1)
        Dim i As Integer

        For i = 0 To dt1.Rows.Count - 1
            dato1 = dt1.Rows(i).Item("Usuario")
        Next

        c2 = "EXECUTE PRODUCTIVIDAD_CONSULTA"
        Dim adaptadorsql2 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
        adaptadorsql2.Fill(dt2)

        c3 = "SELECT (PRODUCTIVIDAD)*100 AS TOTAL FROM CONSULTA_PRODUCTIVIDAD WHERE USUARIO='" & dato1 & "' AND FECHA='" & fecha & "'"
        Dim adaptadorsql3 As New SqlDataAdapter(c3, New SqlConnection(coneccion))
        adaptadorsql3.Fill(dt3)

        Dim k As Integer

        For k = 0 To dt3.Rows.Count - 1
            Label1.DataBindings.Add(New Binding("Text", dt3, "TOTAL"))
        Next
        Dim resultado As Decimal = Label1.Text
        ToolStripLabel14.Text = Format(resultado, "0.00")

    End Sub

    Private Sub TiemposToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TiemposToolStripMenuItem.Click
        Dim CE As New Dimencionamiento_Tiempos()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ConsultaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaToolStripMenuItem.Click
        Dim CE As New Reporte_Productividad()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub CorrecciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CorrecciónToolStripMenuItem.Click
        Dim CE As New Correccion_Productividad
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ReportarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportarToolStripMenuItem.Click
        Dim CE As New Reportar_Productividad()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ConexiónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConexiónToolStripMenuItem.Click
        Dim CE As New Novedades_Conexion()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub TicketsDepuraciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TicketsDepuraciónToolStripMenuItem.Click
        Dim dt1 As New DataTable
        Dim c1 As String
        c1 = "select Nombre_Gestion from USUARIOS ,GESTIONES where USUARIOS .Id_Gestion =GESTIONES .Id_Gestion and Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql18 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql18.Fill(dt1)

        Dim i As Integer
        Dim ges1 As String = ""
        For i = 0 To dt1.Rows.Count - 1
            ges1 = (dt1.Rows(i).Item("Nombre_Gestion"))
        Next


        Dim dt2 As New DataTable
        Dim c2 As String
        c2 = "select Nombre_Gestion2 from USUARIOS ,GESTIONES2 where USUARIOS .Id_Gestion2 =GESTIONES2 .Id_Gestion2 and Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql19 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
        adaptadorsql19.Fill(dt2)

        Dim j As Integer
        Dim ges2 As String = ""
        For j = 0 To dt2.Rows.Count - 1
            ges2 = (dt2.Rows(j).Item("Nombre_Gestion2"))
        Next

        If ges1 = "Depuracion Tickets" Then
            Dim CE As New Tickets_Depuracion
            'Set the Parent Form of the Child window.
            CE.MdiParent = Me
            'Display the new form.
            CE.Show()
            CE.StartPosition = FormStartPosition.CenterScreen

        Else
            If ges2 = "Depuracion Tickets" Then
                Dim CE As New Tickets_Depuracion
                'Set the Parent Form of the Child window.
                CE.MdiParent = Me
                'Display the new form.
                CE.Show()
                CE.StartPosition = FormStartPosition.CenterScreen
            Else
                MsgBox("Usted no esta autorizado para realizar esta Gestion")
            End If
        End If
    End Sub

    Private Sub TicketsDesconexionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TicketsDesconexionesToolStripMenuItem.Click
        Dim dt1 As New DataTable
        Dim c1 As String
        c1 = "select Nombre_Gestion from USUARIOS ,GESTIONES where USUARIOS .Id_Gestion =GESTIONES .Id_Gestion and Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql18 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql18.Fill(dt1)

        Dim i As Integer
        Dim ges1 As String = ""
        For i = 0 To dt1.Rows.Count - 1
            ges1 = (dt1.Rows(i).Item("Nombre_Gestion"))
        Next


        Dim dt2 As New DataTable
        Dim c2 As String
        c2 = "select Nombre_Gestion2 from USUARIOS ,GESTIONES2 where USUARIOS .Id_Gestion2 =GESTIONES2 .Id_Gestion2 and Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql19 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
        adaptadorsql19.Fill(dt2)

        Dim j As Integer
        Dim ges2 As String = ""
        For j = 0 To dt2.Rows.Count - 1
            ges2 = (dt2.Rows(j).Item("Nombre_Gestion2"))
        Next

        If ges1 = "Tickets" Then
            Dim CE As New Tickets_DX
            'Set the Parent Form of the Child window.
            CE.MdiParent = Me
            'Display the new form.
            CE.Show()
            CE.StartPosition = FormStartPosition.CenterScreen

        Else
            If ges2 = "Tickets" Then
                Dim CE As New Tickets_DX
                'Set the Parent Form of the Child window.
                CE.MdiParent = Me
                'Display the new form.
                CE.Show()
                CE.StartPosition = FormStartPosition.CenterScreen
            Else
                MsgBox("Usted no esta autorizado para realizar esta Gestion")
            End If
        End If
    End Sub

    Private Sub TicketsOtrosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TicketsOtrosToolStripMenuItem.Click
        Dim dt1 As New DataTable
        Dim c1 As String
        c1 = "select Nombre_Gestion from USUARIOS ,GESTIONES where USUARIOS .Id_Gestion =GESTIONES .Id_Gestion and Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql18 As New SqlDataAdapter(c1, New SqlConnection(coneccion))
        adaptadorsql18.Fill(dt1)

        Dim i As Integer
        Dim ges1 As String = ""
        For i = 0 To dt1.Rows.Count - 1
            ges1 = (dt1.Rows(i).Item("Nombre_Gestion"))
        Next


        Dim dt2 As New DataTable
        Dim c2 As String
        c2 = "select Nombre_Gestion2 from USUARIOS ,GESTIONES2 where USUARIOS .Id_Gestion2 =GESTIONES2 .Id_Gestion2 and Nombre_Usuario like '" & nombreusuario & "'"
        Dim adaptadorsql19 As New SqlDataAdapter(c2, New SqlConnection(coneccion))
        adaptadorsql19.Fill(dt2)

        Dim j As Integer
        Dim ges2 As String = ""
        For j = 0 To dt2.Rows.Count - 1
            ges2 = (dt2.Rows(j).Item("Nombre_Gestion2"))
        Next

        If ges1 = "Tickets" Then
            Dim CE As New Tickets()
            'Set the Parent Form of the Child window.
            CE.MdiParent = Me
            'Display the new form.
            CE.Show()
            CE.StartPosition = FormStartPosition.CenterScreen

        Else
            If ges2 = "Tickets" Then
                Dim CE As New Tickets()
                'Set the Parent Form of the Child window.
                CE.MdiParent = Me
                'Display the new form.
                CE.Show()
                CE.StartPosition = FormStartPosition.CenterScreen
            Else
                MsgBox("Usted no esta autorizado para realizar esta Gestion")
            End If
        End If
    End Sub

    Private Sub GeneradorDeNotasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneradorDeNotasToolStripMenuItem.Click
        Dim CE As New Creador_Notas()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ServiciosSinDesconectarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ServiciosSinDesconectarToolStripMenuItem.Click
        Dim CE As New Servicios_Pendientes_Dx()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim CE As New Estado_Depuracion()
        'Set the Parent Form of the Child window.
        CE.MdiParent = Me
        'Display the new form.
        CE.Show()
        CE.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub MoviLetterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MoviLetterToolStripMenuItem.Click
    End Sub
End Class