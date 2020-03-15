Public Class provedor
    Private nombre_Provedor As String
    Private telefono_provedor As String
    Private direccion_provedor As String

    Public Property metodo_nombre As String
        Get
            Return nombre_Provedor
        End Get
        Set(value As String)
            nombre_Provedor = value
        End Set
    End Property

    Public Property metodo_nombreProducto As String
        Get
            Return nombre_producto
        End Get
        Set(value As String)
            nombre_producto = value
        End Set
    End Property

    Public Property metodo_descripcionProducto As String
        Get
            Return descripcion_producto
        End Get
        Set(value As String)
            descripcion_producto = value
        End Set
    End Property
End Class
