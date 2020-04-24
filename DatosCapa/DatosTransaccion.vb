Imports System.Data.SqlClient
Public Class DatosTransaccion
    Dim conectar As New conexion
    Dim sql As New SqlCommand
    Dim Da As New SqlDataAdapter
    Dim dt As New DataTable
    Dim filas As Integer

    Public Function consultarProducto(ByVal ET As EntidadCapa.transaccion) As DataTable
        conectar.conectando()
        sql = New SqlCommand("CONSULTA_PRODUCTODOS", conectar.cnx)
        sql.CommandType = CommandType.StoredProcedure
        With sql.Parameters
            .AddWithValue("@Id", ET.metodo_idProductoTrasaccion)
        End With
        Da = New SqlDataAdapter(sql)
        consultarProducto = New DataTable
        Da.Fill(consultarProducto)
        conectar.desconectando()
    End Function

    Public Sub Registrar_transaccion(ByVal ET As EntidadCapa.transaccion)
        Try
            conectar.conectando()
            sql = New SqlCommand("INSERTAR_TRANSACCION", conectar.cnx)
            sql.CommandType = CommandType.StoredProcedure
            With sql.Parameters
                .AddWithValue("@Fecha", ET.metodo_fechaTransaccion)
                .AddWithValue("@IdProducto", ET.metodo_idProductoTrasaccion)
                .AddWithValue("@IdProvedor", ET.metodo_idProvedorTransaccion)
                .AddWithValue("@Cantidad", ET.metodo_cantidadTransaccion)
                .AddWithValue("@Tipo", ET.metodo_tipoTransaccion)
            End With
            filas = sql.ExecuteNonQuery()
            If filas > 0 Then
                MsgBox("Se insertaron los datos con exito", MsgBoxStyle.Information)
            Else
                MsgBox("No se pudo realizar la transaccion debido a la cantidad", MsgBoxStyle.Information)
            End If
            conectar.desconectando()
        Catch ex As Exception
            MsgBox("Error al realizar la transaccion" + ex.ToString, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Public Sub Actualizar_transaccion(ByVal ET As EntidadCapa.transaccion)
        Try
            conectar.conectando()
            sql = New SqlCommand("MODIFICAR_TRANSACCION", conectar.cnx)
            sql.CommandType = CommandType.StoredProcedure
            With sql.Parameters
                .AddWithValue("@id", ET.metodo_idTransaccion)
                .AddWithValue("@Fecha", ET.metodo_fechaTransaccion)
                .AddWithValue("@IdProducto", ET.metodo_idProductoTrasaccion)
                .AddWithValue("@IdProvedor", ET.metodo_idProvedorTransaccion)
                .AddWithValue("@Cantidad", ET.metodo_cantidadTransaccion)
                .AddWithValue("@Tipo", ET.metodo_tipoTransaccion)
            End With
            filas = sql.ExecuteNonQuery()
            If filas > 0 Then
                MsgBox("Se insertaron los datos correctamente", MsgBoxStyle.Information)
            Else
                MsgBox("No se pudo realizar la transaccion debido a la cantidad", MsgBoxStyle.Information)
            End If
            conectar.desconectando()
        Catch ex As Exception
            MsgBox("Error al actualizar la transaccion" + ex.ToString, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Public Sub Eliminar_transaccion(ByVal ET As EntidadCapa.transaccion)
        Try
            conectar.conectando()
            sql = New SqlCommand("ELIMINAR_TRANSACCION", conectar.cnx)
            sql.CommandType = CommandType.StoredProcedure
            With sql.Parameters
                .AddWithValue("@ID", ET.metodo_idTransaccion)
            End With
            sql.ExecuteNonQuery()
            MsgBox("Se elimino el registro con exito", MsgBoxStyle.Information)
            conectar.desconectando()
        Catch ex As Exception
            MsgBox("" + ex.ToString, MsgBoxStyle.Exclamation)
        End Try
    End Sub

End Class
