Imports DatosCapa
Imports EntidadCapa
Imports System.Data.SqlClient
Public Class fAlmacen
    Dim EA As New almacen
    Dim datosAlmacen As New DatosAlmacen
    Dim conectar As New conexion
    Dim Da As New SqlDataAdapter
    Dim dt As New DataTable
    Private Sub BtnConsulta_Click(sender As Object, e As EventArgs) Handles btnConsulta.Click
        mostrarProductos()
    End Sub

    Private Sub mostrarProductos()
        Try
            conectar.conectando()
            Da = New SqlDataAdapter("select almacen.id, producto.identificador as IdProducto, producto.nombre as producto, producto.descripcion as descripcion, almacen.cantidad as cantidad from (almacen INNER JOIN producto ON almacen.idProducto = producto.id)", conectar.cnx)
            dt = New DataTable
            Da.Fill(dt)
            tablaAlmacen.DataSource = dt
            conectar.desconectando()
        Catch ex As Exception
            MsgBox("error al cargar datos de tabla almacen", MsgBoxStyle.Information)
        End Try
        Try
            conectar.conectando()
            Da = New SqlDataAdapter("select id as No,identificador,nombre,descripcion from producto", conectar.cnx)
            dt = New DataTable
            Da.Fill(dt)
            tablaProductos.DataSource = dt
            conectar.desconectando()
        Catch ex As Exception
            MsgBox("error al cargar datos de tabla productos", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub TablaProductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tablaProductos.CellContentClick
        Dim i As Integer
        i = tablaProductos.CurrentRow.Index
        txtId.Text = tablaProductos.Item(0, i).Value()
        txtIdentificador.Text = tablaProductos.Item(1, i).Value()
        txtProducto.Text = tablaProductos.Item(2, i).Value()
        modoAgregarProducto()
    End Sub

    Private Sub modoAgregarProducto()
        btnAgregar.Enabled = True
        btnEliminar.Enabled = False
    End Sub

    Private Sub modoEliminarProductoDeAlmacen()
        btnAgregar.Enabled = False
        btnEliminar.Enabled = True
    End Sub


    Private Sub TablaAlmacen_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tablaAlmacen.CellContentClick
        Dim i As Integer
        i = tablaAlmacen.CurrentRow.Index
        txtId.Text = tablaAlmacen.Item(0, i).Value()
        txtIdentificador.Text = tablaAlmacen.Item(1, i).Value()
        txtProducto.Text = tablaAlmacen.Item(2, 0).Value()
        modoEliminarProductoDeAlmacen()
    End Sub

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim dtable As New DataTable
        If txtId.Text <> "" And txtIdentificador.Text <> "" And txtProducto.Text <> "" Then
            obtenerDatosDeCajas()
            dtable = datosAlmacen.consultarProducto(EA)
            If dtable.Rows.Count > 0 Then
                MsgBox("Ya existe el producto en el almacen", MsgBoxStyle.Information)
            Else
                datosAlmacen.registrarEnAlmacen(EA)
                limpiarCajas()
                mostrarProductos()
            End If
        Else
            MsgBox("Eliga un producto a agregar", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub obtenerDatosDeCajas()
        EA.metodo_id = txtId.Text
        EA.metodo_identficadorProducto = txtIdentificador.Text
    End Sub

    Private Sub limpiarCajas()
        txtId.Text = ""
        txtIdentificador.Text = ""
        txtProducto.Text = ""
    End Sub
End Class