Public Class Ent_logueo
    Private usuario As String
    Private contrasena As String

    Public Property metodo_usuario As String
        Get
            Return usuario
        End Get
        Set(value As String)
            usuario = value
        End Set
    End Property

    Public Property metodo_contrasena As String
        Get
            Return contrasena
        End Get
        Set(value As String)
            contrasena = value
        End Set
    End Property
End Class
