Public Class provedor
    Private nombre_Provedor As String
    Private telefono_provedor As String
    Private direccion_provedor As String

    Public Property metodo_nombreProvedor As String
        Get
            Return nombre_Provedor
        End Get
        Set(value As String)
            nombre_Provedor = value
        End Set
    End Property

    Public Property metodo_telefonoProvedor As String
        Get
            Return telefono_provedor
        End Get
        Set(value As String)
            telefono_provedor = value
        End Set
    End Property

    Public Property metodo_direccionProvedor As String
        Get
            Return direccion_provedor
        End Get
        Set(value As String)
            direccion_provedor = value
        End Set
    End Property
End Class
