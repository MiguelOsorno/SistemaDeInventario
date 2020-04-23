Imports System.Data.SqlClient
Public Class DatosTransaccion
    Dim conectar As New conexion
    Dim sql As New SqlCommand
    Dim Da As New SqlDataAdapter
    Dim dt As New DataTable

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
            sql.ExecuteNonQuery()
            MsgBox("Se insertaron los datos", MsgBoxStyle.Information)
            conectar.desconectando()
        Catch ex As Exception
            MsgBox("" + ex.ToString, MsgBoxStyle.Exclamation)
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
            sql.ExecuteNonQuery()
            MsgBox("Se insertaron los datos", MsgBoxStyle.Information)
            conectar.desconectando()
        Catch ex As Exception
            MsgBox("" + ex.ToString, MsgBoxStyle.Exclamation)
        End Try
    End Sub

End Class
