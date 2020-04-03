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
        Else
            MsgBox("los campos no deben quedar vacios", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Public Sub limpiarCajas()
        TxtIdProvedor.Text = ""
        TxtNombre.Text = ""
        TxtTelefono.Text = ""
        TxtDireccion.Text = ""
    End Sub

    Public Sub obtenerDatosDeCajas()
        If TxtIdProvedor.Text <> "" Then
            EP.metodo_IdProvedor = TxtIdProvedor.Text
        End If
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
            Da = New SqlDataAdapter("select * from provedor", conectar.cnx)
            dt = New DataTable
            Da.Fill(dt)
            tabla.DataSource = dt
            conectar.desconectando()
        Catch ex As Exception
            MsgBox("error al cargar datos de tabla", MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BtnEditar.Click
        If (TxtNombre.Text <> "" And TxtTelefono.Text <> "" And TxtDireccion.Text <> "" And TxtIdProvedor.Text <> "") Then
            obtenerDatosDeCajas()
            DP.Actualizar_Provedor(EP)
            limpiarCajas()
            mostrarProvedores()
        Else
            MsgBox("los campos no deben quedar vacios", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        If (TxtIdProvedor.Text <> "") Then
            obtenerDatosDeCajas()
            DP.Borrar_Provedor(EP)
            limpiarCajas()
            mostrarProvedores()
        Else
            MsgBox("No ha seleccionado un provedor a eliminar", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Tabla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tabla.CellContentClick
        Dim i As Integer

        i = tabla.CurrentRow.Index
        TxtIdProvedor.Text = tabla.Item(0, i).Value()
        TxtNombre.Text = tabla.Item(1, i).Value()
        TxtTelefono.Text = tabla.Item(2, i).Value()
        TxtDireccion.Text = tabla.Item(3, i).Value()
        activarBotones()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        menuPrincipal.Show()
        Me.Hide()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        limpiarCajas()
    End Sub

    Public Sub activarBotones()
        BtnEditar.Enabled = True
        BtnEliminar.Enabled = True
    End Sub
End Class