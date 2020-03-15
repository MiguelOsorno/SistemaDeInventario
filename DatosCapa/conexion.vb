Imports System.Data.SqlClient
Public Class conexion
    Public cnx As New SqlConnection
    Public cmd As New SqlCommand

    Public Function conectando()
        Try
            cnx.Close()
            cnx = New SqlConnection(My.Settings.myConexion)
            cnx.Open()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try
    End Function

    Public Sub desconectando()
        Try
            If cnx.State = ConnectionState.Open Then
                cnx.Close()
                cnx.Dispose()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class
