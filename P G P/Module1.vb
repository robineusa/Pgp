Module Module1
    Public nombreusuario As String

    Public Razon As String
    Public Cuenta_hallazgos As Double
    Public Cuenta_escalamiento As Double
    Public AÑO As Integer = Now.Year
    Public MES As Integer = Now.Month
    Public DIA As Integer = Now.Day

    'Public perfil As Integer
    'Public consulta As String
    'Public ingresar As String

    'Public archivo As String = "C:\ASEGURAMIENTO\ARRANQUE.ini"
    'Public logo As String = Ini_read(archivo, "empresa", "logo")
    'Public empresa As String = Ini_read(archivo, "empresa", "empresa")
    'Public nit As String = Ini_read(archivo, "empresa", "nit")
    'Public direccion As String = Ini_read(archivo, "empresa", "direccion")

    'Public base As String = Ini_read(archivo, "aplication2", "base")
    'Public base As String = ("ASEGURAMIENTO")
    'Public servidor As String = Ini_read(archivo, "aplication2", "Servidor")
    'Public servidor As String = ("\\172.19.92.126")
    'Public base As String = Ini_read(archivo, "aplication", "base")
    'Public servidor As String = Ini_read(archivo, "aplication", "Servidor")
    'Public base As String = Ini_read(archivo, "aplication4", "base")
    'Public servidor As String = Ini_read(archivo, "aplication4", "Servidor")
    'Public base As String = Ini_read(archivo, "aplication", "base")
    'Public servidor As String = Ini_read(archivo, "aplication", "Servidor")

    Public coneccion As String = ("data source=ICC-APP1; initial catalog=CIERRE_EXPERIENCIA;user id=Userpgp; password=Pgp2015*")
    'Public coneccion As String = ("data source=\\172.19.113.30; initial catalog=CIERRE_EXPERIENCIA;user id=consulta; password=consulta")
    'Public coneccion3 As String = ("data source=MXL2180F5D\SQLEXPRESS; initial catalog=ROBINEUSA;user id=consulta; password=consulta")
    'Public coneccion As String = ("data source=NEO; initial catalog=CEC;user id=sa; password=Aseguramiento2013*")
    'Public coneccion As String = ("data source=" & servidor & "; initial catalog=" & base & "; Integrated Security=True")


    'SQLOLEDB.1

    'Public tblresultado As New DataTable




    'Declaración de las funciones API's para escribir y leer archivos INI. 


    ' Leer una clave de un fichero INI
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As Integer, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer

    ' Escribir una clave de un fichero INI (también para borrar claves y secciones)
    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer
    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As Integer, ByVal lpFileName As String) As Integer
    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As Integer, ByVal lpString As Integer, ByVal lpFileName As String) As Integer



    Public Function Ini_read(ByVal sFileName As String, ByVal sSection As String, ByVal sKeyName As String, Optional ByVal sDefault As String = "") As String
        '--------------------------------------------------------------------------
        ' Devuelve el valor de una clave de un fichero INI
        ' Los parámetros son:
        '   sFileName   El fichero INI
        '   sSection    La sección de la que se quiere leer
        '   sKeyName    Clave
        '   sDefault    Valor opcional que devolverá si no se encuentra la clave
        '--------------------------------------------------------------------------
        Dim ret As Integer
        Dim sRetVal As String
        '
        sRetVal = New String(Chr(0), 255)
        '
        ret = GetPrivateProfileString(sSection, sKeyName, sDefault, sRetVal, Len(sRetVal), sFileName)
        If ret = 0 Then
            Return sDefault
        Else
            Return Left(sRetVal, ret)
        End If
    End Function

    Public Sub Grabar_Ini(ByVal sFileName As String, ByVal sSection As String, ByVal sKeyName As String, ByVal sValue As String)
        '--------------------------------------------------------------------------
        ' Guarda los datos de configuración
        ' Los parámetros son los mismos que en LeerIni
        ' Siendo sValue el valor a guardar
        '
        Call WritePrivateProfileString(sSection, sKeyName, sValue, sFileName)
    End Sub

    Public Sub limpiar(ByVal frmcontrol As Form)

        For Each Control In frmcontrol.Controls
            If (TypeOf Control Is TextBox) Then
                Control.text = ""
                Control.DataBindings.clear()
            End If
            If (TypeOf Control Is ComboBox) Then
                Control.text = ""
                Control.DataBindings.clear()
            End If

            If (TypeOf Control Is Label) Then
                Control.DataBindings.clear()
            End If
            If (TypeOf Control Is MaskedTextBox) Then
                Control.DataBindings.clear()
            End If

        Next
    End Sub
    Public Sub limpiar2(ByVal frmcontrol As Form)

        For Each Control In frmcontrol.Controls
            If (TypeOf Control Is TextBox) Then
                Control.DataBindings.clear()
            End If
        Next
    End Sub
    Public Sub limpiar3(ByVal frmcontrol As Form)

        For Each Control In frmcontrol.Controls
            If (TypeOf Control Is Label) Then
                Control.DataBindings.clear()
            End If
            If (TypeOf Control Is ComboBox) Then
                Control.DataBindings.clear()
            End If
            If (TypeOf Control Is DateTimePicker) Then
                Control.DataBindings.clear()
            End If
        Next

    End Sub
    Public Sub combo_limpia(ByVal frmcontrol As Form)

        For Each Control In frmcontrol.Controls
            If (TypeOf Control Is ComboBox) Then
                Control.text = ""
            End If
        Next

    End Sub

End Module
