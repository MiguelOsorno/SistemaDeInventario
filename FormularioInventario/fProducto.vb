Imports DatosCapa
Imports EntidadCapa
Imports System.Data.SqlClient
Public Class fProducto
    Dim EP As New producto
    Dim DP As New DatosProducto
    Dim conectar As New conexion
    Dim Da As New SqlDataAdapter
    Dim dt As New DataTable



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Btn_nuevoProducto.Click
        Dim dtable As New DataTable
        If (txtIdProducto.Text <> "" And txtNombreProducto.Text <> "" And txtDescripcionProducto.Text <> "") Then
            obtenerDatosDeCajas()

            dtable = DP.consultarProducto(EP)
            If dtable.Rows.Count > 0 Then
                MsgBox("Ya existe un producto con ese identificador", MsgBoxStyle.Exclamation)
            Else
                DP.Registrar_Producto(EP)
                limpiarCajas()
                mostrarProductos()
            End If
        Else
                MsgBox("los campos no deben quedar vacios", MsgBoxStyle.Exclamation)
        End If


    End Sub

    Private Sub Btn_Modificar_Click(sender As Object, e As EventArgs) Handles Btn_Modificar.Click
        If (txtIdProducto.Text <> "" And txtNombreProducto.Text <> "" And txtDescripcionProducto.Text <> "") Then
            obtenerDatosDeCajas()
            DP.Actualizar_Producto(EP)
            limpiarCajas()
            mostrarProductos()
        Else
            MsgBox("Error los campos no pueden quedar vacios", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click
        If (txtIdProducto.Text <> "") Then
            obtenerDatosDeCajas()
            DP.Borrar_Producto(EP)
            limpiarCajas()
            mostrarProductos()
        Else
            MsgBox("Ingrese el identificador del producto a eliminar", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Consultar_Click(sender As Object, e As EventArgs) Handles Consultar.Click
        mostrarProductos()
    End Sub

    Public Sub mostrarProductos()
        Try
            conectar.conectando()
            Da = New SqlDataAdapter("select identificador,nombre,descripcion from producto", conectar.cnx)
            dt = New DataTable
            Da.Fill(dt)
            tabla.DataSource = dt
            conectar.desconectando()
        Catch ex As Exception
            MsgBox("error al cargar datos de tabla", MsgBoxStyle.Information)
        End Try
    End Sub


    Public Sub limpiarCajas()
        txtIdProducto.Text = ""
        txtNombreProducto.Text = ""
        txtDescripcionProducto.Text = ""
    End Sub

    Public Sub obtenerDatosDeCajas()
        EP.metodo_id = txtIdProducto.Text
        EP.metodo_nombreProducto = txtNombreProducto.Text
        EP.metodo_descripcionProducto = txtDescripcionProducto.Text
    End Sub

    Private Sub Tabla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tabla.CellContentClick
        Dim i As Integer

        i = tabla.CurrentRow.Index
        txtIdProducto.Text = tabla.Item(0, i).Value()
        txtNombreProducto.Text = tabla.Item(1, i).Value()
        txtDescripcionProducto.Text = tabla.Item(2, i).Value()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        menuPrincipal.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        limpiarCajas()
    End Sub
End Class
