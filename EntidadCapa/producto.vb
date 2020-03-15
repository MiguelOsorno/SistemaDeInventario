Public Class producto
    Private id_producto As Integer
    Private nombre_producto As String
    Private descripcion_producto As String

    Public Property metodo_id As Integer
        Get
            Return id_producto
        End Get
        Set(value As Integer)
            id_producto = value
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
