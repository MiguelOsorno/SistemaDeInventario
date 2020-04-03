Imports System.Data.SqlClient
Imports EntidadCapa
Public Class Dat_logueo
    Dim conectar As New conexion
    Dim sql As New SqlCommand
    Dim DA As New SqlDataAdapter

    Public Function validar_usuario(ByVal CE As EntidadCapa.Ent_logueo) As DataTable
        conectar.conectando()
        sql = New SqlCommand("logueo", conectar.cnx)
        sql.CommandType = CommandType.StoredProcedure
        With sql.Parameters
            .AddWithValue("@usuario", CE.metodo_usuario)
            .AddWithValue("@contrasena", CE.metodo_contrasena)
        End With
        DA = New SqlDataAdapter(sql)
        validar_usuario = New DataTable
        DA.Fill(validar_usuario)
        conectar.desconectando()
    End Function
End Class
