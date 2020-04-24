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
    Dim errorTabla As Boolean


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
            mostrarTodasLasTransacciones()
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
        txtIdTransaccion.Text = ""
        TxtIdProducto.Text = ""
        TxtIdProvedor.Text = ""
        TxtNombreProducto.Text = ""
        TxtNombreProvedor.Text = ""
        txtCantidad.Text = ""
    End Sub

    Private Sub mostrarTodasLasTransacciones()
        Try
            conectar.conectando()
            Da = New SqlDataAdapter("select transaccion.id, producto.nombre as nombreProducto, provedor.nombre as nombreProvedor, transaccion.fecha, transaccion.cantidad, transaccion.tipo  from ((transaccion INNER JOIN producto ON transaccion.idProducto = producto.id) INNER JOIN provedor ON transaccion.idProvedor = provedor.id)", conectar.cnx)
            dt = New DataTable
            Da.Fill(dt)
            dtTransacciones.DataSource = dt
            conectar.desconectando()
        Catch ex As Exception
            MsgBox("error al cargar datos de tabla", MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub BtnMostrarTransacciones_Click(sender As Object, e As EventArgs) Handles btnMostrarTransacciones.Click
        mostrarTodasLasTransacciones()
    End Sub

    Private Sub DtTransacciones_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtTransacciones.CellContentClick
        Dim i As Integer
        i = dtTransacciones.CurrentRow.Index
        txtIdTransaccion.Text = dtTransacciones.Item(0, i).Value()
        cargarDatosExtras()
        If Not errorTabla Then
            TxtNombreProducto.Text = dtTransacciones.Item(1, i).Value()
            TxtNombreProvedor.Text = dtTransacciones.Item(2, i).Value()
            tiempoControl.Value = dtTransacciones.Item(3, i).Value()
            txtCantidad.Text = dtTransacciones.Item(4, i).Value()
            cbTipo.Text = dtTransacciones.Item(5, i).Value()
            ponerIdsEnCajas()
            modoEdicionEliminacion()
        Else
            limpiarCajas()
        End If

    End Sub

    Private Sub cargarDatosExtras()
        ET.metodo_idTransaccion = txtIdTransaccion.Text
        Dim cadena As String
        cadena = "select idProducto, idProvedor from transaccion where id = " & ET.metodo_idTransaccion
        Try
            conectar.conectando()
            Da = New SqlDataAdapter(cadena, conectar.cnx)
            dt = New DataTable
            Da.Fill(dt)
            dtExtra.DataSource = dt
            conectar.desconectando()
            errorTabla = False
        Catch ex As Exception
            errorTabla = True
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub ponerIdsEnCajas()
        TxtIdProducto.Text = dtExtra.Item(0, 0).Value()
        TxtIdProvedor.Text = dtExtra.Item(1, 0).Value()
    End Sub

    Private Sub modoEdicionEliminacion()
        btnAceptar.Enabled = False
        BtnEdit.Enabled = True
        btnBorrar.Enabled = True
        txtIdTransaccion.Visible = True
        LbIdTransaccion.Visible = True
    End Sub

    Private Sub reset()
        btnAceptar.Enabled = True
        BtnEdit.Enabled = False
        btnBorrar.Enabled = False
        txtIdTransaccion.Visible = False
        LbIdTransaccion.Visible = False
        limpiarCajas()
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        If txtIdTransaccion.Text <> "" And TxtIdProducto.Text <> "" And TxtIdProvedor.Text <> "" And txtCantidad.Text <> "" Then
            obtenerDatosDeCajasActualizacion()
        Else
            MsgBox("los campos no pueden quedar vacios", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub obtenerDatosDeCajasActualizacion()
        ET.metodo_idTransaccion = txtIdTransaccion.Text
        obtenerDatosDeCajas()
        datosTransaccion.Actualizar_transaccion(ET)
        reset()
        limpiarCajas()
        mostrarTodasLasTransacciones()
    End Sub

    Private Sub BtReset_Click(sender As Object, e As EventArgs) Handles btReset.Click
        reset()
    End Sub

    Private Sub BtnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        If txtIdTransaccion.Text <> "" Then
            ET.metodo_idTransaccion = txtIdTransaccion.Text
            datosTransaccion.Eliminar_transaccion(ET)
            limpiarCajas()
            mostrarTodasLasTransacciones()
            reset()
        End If
    End Sub
End Class