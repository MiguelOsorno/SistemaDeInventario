Imports System.Data.SqlClient
Public Class DatosAlmacen
    Dim conectar As New conexion
    Dim sql As New SqlCommand
    Dim Da As New SqlDataAdapter
    Dim dt As New DataTable
    Dim filas As Integer

    Public Function consultarProducto(ByVal EA As EntidadCapa.almacen) As DataTable
        conectar.conectando()
        sql = New SqlCommand("CONSULTA_PRODUCTODOS", conectar.cnx)
        sql.CommandType = CommandType.StoredProcedure
        With sql.Parameters
            .AddWithValue("@Id", EA.metodo_id)
        End With
        Da = New SqlDataAdapter(sql)
        consultarProducto = New DataTable
        Da.Fill(consultarProducto)
        conectar.desconectando()
    End Function

    Public Sub registrarEnAlmacen(ByVal EA As EntidadCapa.almacen)
        Try
            conectar.conectando()
            sql = New SqlCommand("INSERTAR_ALMACEN", conectar.cnx)
            sql.CommandType = CommandType.StoredProcedure
            With sql.Parameters
                .AddWithValue("@IdProducto", EA.metodo_id)
                .AddWithValue("@Cantidad", 0)
            End With
            sql.ExecuteNonQuery()
            MsgBox("Se insertaron los datos con exito", MsgBoxStyle.Information)
            conectar.desconectando()
        Catch ex As Exception
            MsgBox("Error al registrar el producto en el almacen" + ex.ToString, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class
