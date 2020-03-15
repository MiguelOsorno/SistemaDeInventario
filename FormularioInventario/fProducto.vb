Imports DatosCapa
Imports EntidadCapa
Imports System.Data.SqlClient
Public Class fProducto
    Dim EP As New producto
    Dim DP As New DatosProducto
    Dim conectar As New conexion
    Dim Da As New SqlDataAdapter
    Dim dt As New DataTable

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtIdProducto.TextChanged

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Btn_nuevoProducto.Click
        If (txtIdProducto.Text <> "" And txtNombreProducto.Text <> "" And txtDescripcionProducto.Text <> "") Then
            EP.metodo_id = txtIdProducto.Text
            EP.metodo_nombreProducto = txtNombreProducto.Text
            EP.metodo_descripcionProducto = txtDescripcionProducto.Text
            DP.Registrar_Producto(EP)
            txtIdProducto.Text = ""
            txtNombreProducto.Text = ""
            txtDescripcionProducto.Text = ""
            mostrarProductos()
        Else
            MsgBox("los campos no deben quedar vacios", MsgBoxStyle.Exclamation)
        End If


    End Sub

    Private Sub Btn_Modificar_Click(sender As Object, e As EventArgs) Handles Btn_Modificar.Click
        If (txtIdProducto.Text <> "" And txtNombreProducto.Text <> "" And txtDescripcionProducto.Text <> "") Then
            EP.metodo_id = txtIdProducto.Text
            EP.metodo_nombreProducto = txtNombreProducto.Text
            EP.metodo_descripcionProducto = txtDescripcionProducto.Text
            DP.Actualizar_Producto(EP)
            txtIdProducto.Text = ""
            txtNombreProducto.Text = ""
            txtDescripcionProducto.Text = ""
            mostrarProductos()
        Else
            MsgBox("Error los campos no pueden quedar vacios", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click
        EP.metodo_id = txtIdProducto.Text
        EP.metodo_nombreProducto = txtNombreProducto.Text
        EP.metodo_descripcionProducto = txtDescripcionProducto.Text
        DP.Borrar_Producto(EP)
        txtIdProducto.Text = ""
        txtNombreProducto.Text = ""
        txtDescripcionProducto.Text = ""
        mostrarProductos()
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
        Catch ex As Exception
            MsgBox("error al cargar datos de tabla", MsgBoxStyle.Information)
        End Try
    End Sub



    Private Sub TxtNombreProducto_TextChanged(sender As Object, e As EventArgs) Handles txtNombreProducto.TextChanged

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class
