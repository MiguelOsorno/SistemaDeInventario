Imports System.Data.SqlClient
Public Class DatosProvedor
    Dim conectar As New conexion
    Dim sql As New SqlCommand
    Dim Da As New SqlDataAdapter
    Dim dt As New DataTable

    Public Sub Registrar_Provedor(ByVal EP As EntidadCapa.provedor)
        Try
            conectar.conectando()
            sql = New SqlCommand("INSERTAR_PROVEDOR", conectar.cnx)
            sql.CommandType = CommandType.StoredProcedure
            With sql.Parameters
                .AddWithValue("@Nombre", EP.metodo_nombreProvedor)
                .AddWithValue("@Telefono", EP.metodo_telefonoProvedor)
                .AddWithValue("@Direccion", EP.metodo_direccionProvedor)
            End With
            sql.ExecuteNonQuery()
            MsgBox("se insertaron los datos", MsgBoxStyle.Information)
            conectar.desconectando()
        Catch ex As Exception
            MsgBox("error al ingresar los datos", MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Public Sub Actualizar_Provedor(ByVal EP As EntidadCapa.provedor)
        conectar.conectando()
        sql = New SqlCommand("MODIFICAR_PROVEDOR", conectar.cnx)
        sql.CommandType = CommandType.StoredProcedure
        With sql.Parameters
            .AddWithValue("@Nombre", EP.metodo_nombreProvedor)
            .AddWithValue("@Telefono", EP.metodo_telefonoProvedor)
            .AddWithValue("@Direccion", EP.metodo_direccionProvedor)
        End With
        sql.ExecuteNonQuery()
        MsgBox("Se actulizo el registro", MsgBoxStyle.Information)
        conectar.desconectando()
    End Sub

    Public Sub Borrar_Producto(ByVal EP As EntidadCapa.provedor)
        conectar.conectando()
        sql = New SqlCommand("ELIMINAR_PROVEDOR", conectar.cnx)
        sql.CommandType = CommandType.StoredProcedure
        With sql.Parameters
            .AddWithValue("@ID", EP.metodo_nombreProvedor)
        End With
        sql.ExecuteNonQuery()
        MsgBox("Se borro el registro", MsgBoxStyle.Information)
        conectar.desconectando()
    End Sub


End Class
