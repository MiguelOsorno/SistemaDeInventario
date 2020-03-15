Imports System.Data.SqlClient
Public Class DatosProducto
    Dim conectar As New conexion
    Dim sql As New SqlCommand
    Dim Da As New SqlDataAdapter
    Dim dt As New DataTable

    Public Sub Registrar_Producto(ByVal EP As EntidadCapa.producto)
        Try
            conectar.conectando()
            sql = New SqlCommand("INSERTAR_PRODUCTO", conectar.cnx)
                sql.CommandType = CommandType.StoredProcedure
                With sql.Parameters
                    .AddWithValue("@ID", EP.metodo_id)
                    .AddWithValue("@Nombre", EP.metodo_nombreProducto)
                    .AddWithValue("@descripcion", EP.metodo_descripcionProducto)
                End With
                sql.ExecuteNonQuery()
            MsgBox("se insertaron los datos", MsgBoxStyle.Information)
            conectar.desconectando()
        Catch ex As Exception
            MsgBox("error al ingresar los datos", MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Public Sub Actualizar_Producto(ByVal EP As EntidadCapa.producto)
        conectar.conectando()
        sql = New SqlCommand("MODIFICAR_PRODUCTO", conectar.cnx)
        sql.CommandType = CommandType.StoredProcedure
        With sql.Parameters
            .AddWithValue("@ID", EP.metodo_id)
            .AddWithValue("@Nombre", EP.metodo_nombreProducto)
            .AddWithValue("@descripcion", EP.metodo_descripcionProducto)
        End With
        sql.ExecuteNonQuery()
        MsgBox("Se actulizo el registro", MsgBoxStyle.Information)
        conectar.desconectando()
    End Sub

    Public Sub Borrar_Producto(ByVal EP As EntidadCapa.producto)
        conectar.conectando()
        sql = New SqlCommand("ELIMINAR_PRODUCTO", conectar.cnx)
        sql.CommandType = CommandType.StoredProcedure
        With sql.Parameters
            .AddWithValue("@ID", EP.metodo_id)
        End With
        sql.ExecuteNonQuery()
        MsgBox("Se borro el registro", MsgBoxStyle.Information)
        conectar.desconectando()
    End Sub




End Class
