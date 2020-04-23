Imports DatosCapa
Imports EntidadCapa
Imports System.Data.SqlClient
Public Class fTransaccion
    Dim conectar As New conexion
    Dim Da As New SqlDataAdapter
    Dim dt As New DataTable
    Dim valorCombo As String
    Dim ET As New transaccion
    Dim datosTransaccion As New DatosTransaccion


    Private Sub BtnCargarDatos_Click(sender As Object, e As EventArgs) Handles btnCargarDatos.Click
        mostrarProductos()
        mostrarProvedores()
    End Sub

    Public Sub mostrarProvedores()
        Try
            conectar.conectando()
            Da = New SqlDataAdapter("select * from provedor", conectar.cnx)
            dt = New DataTable
            Da.Fill(dt)
            tablaProvedores.DataSource = dt
            conectar.desconectando()
        Catch ex As Exception
            MsgBox("error al cargar datos de tabla", MsgBoxStyle.Information)
        End Try
    End Sub

    Public Sub mostrarProductos()
        Try
            conectar.conectando()
            Da = New SqlDataAdapter("select id,identificador,nombre,descripcion from producto", conectar.cnx)
            dt = New DataTable
            Da.Fill(dt)
            tablaProductos.DataSource = dt
            conectar.desconectando()
        Catch ex As Exception
            MsgBox("error al cargar datos de tabla", MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        menuPrincipal.Show()
        Me.Hide()
    End Sub

    Private Sub TablaProductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tablaProductos.CellContentClick
        Dim i As Integer
        i = tablaProductos.CurrentRow.Index
        TxtIdProducto.Text = tablaProductos.Item(0, i).Value()
        TxtNombreProducto.Text = tablaProductos.Item(2, i).Value()
    End Sub

    Private Sub TablaProvedores_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tablaProvedores.CellContentClick
        Dim i As Integer
        i = tablaProvedores.CurrentRow.Index
        TxtIdProvedor.Text = tablaProvedores.Item(0, i).Value()
        TxtNombreProvedor.Text = tablaProvedores.Item(1, i).Value()
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If TxtNombreProducto.Text <> "" And TxtNombreProvedor.Text <> "" And txtCantidad.Text <> "" And valorCombo <> "" Then
            obtenerDatosDeCajas()
            datosTransaccion.Registrar_transaccion(ET)
            limpiarCajas()
        Else
            MsgBox("los campos no pueden quedar vacios", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub CbTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTipo.SelectedIndexChanged
        valorCombo = cbTipo.Text
    End Sub

    Private Sub obtenerDatosDeCajas()
        If TxtIdProvedor.Text <> "" And TxtIdProducto.Text <> "" Then
            ET.metodo_idProvedorTransaccion = TxtIdProvedor.Text
            ET.metodo_idProductoTrasaccion = TxtIdProducto.Text
        End If
        ET.metodo_fechaTransaccion = tiempoControl.Value
        ET.metodo_cantidadTransaccion = txtCantidad.Text
        ET.metodo_tipoTransaccion = valorCombo
    End Sub

    Private Sub limpiarCajas()
        TxtNombreProducto.Text = ""
        TxtNombreProvedor.Text = ""
        txtCantidad.Text = ""
    End Sub
End Class