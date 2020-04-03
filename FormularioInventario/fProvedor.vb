Imports DatosCapa
Imports EntidadCapa
Imports System.Data.SqlClient
Public Class fProvedor
    Dim EP As New provedor
    Dim DP As New DatosProvedor
    Dim conectar As New conexion
    Dim Da As New SqlDataAdapter
    Dim dt As New DataTable
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (TxtNombre.Text <> "" And TxtTelefono.Text <> "" And TxtDireccion.Text <> "") Then
            obtenerDatosDeCajas()
            DP.Registrar_Provedor(EP)
            limpiarCajas()
            mostrarProvedores()

        End If
    End Sub

    Public Sub limpiarCajas()
        TxtNombre.Text = ""
        TxtTelefono.Text = ""
        TxtDireccion.Text = ""
    End Sub

    Public Sub obtenerDatosDeCajas()
        EP.metodo_nombreProvedor = TxtNombre.Text
        EP.metodo_telefonoProvedor = TxtTelefono.Text
        EP.metodo_direccionProvedor = TxtDireccion.Text
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        mostrarProvedores()
    End Sub

    Public Sub mostrarProvedores()
        Try
            conectar.conectando()
            Da = New SqlDataAdapter("select nombre,telefono,direccion from provedor", conectar.cnx)
            dt = New DataTable
            Da.Fill(dt)
            tabla.DataSource = dt
            conectar.desconectando()
        Catch ex As Exception
            MsgBox("error al cargar datos de tabla", MsgBoxStyle.Information)
        End Try
    End Sub
End Class