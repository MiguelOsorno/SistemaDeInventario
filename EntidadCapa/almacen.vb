Public Class almacen
    Private id As Integer
    Private identificadorProducto As Integer

    Public Property metodo_id As Integer
        Get
            Return id
        End Get
        Set(value As Integer)
            id = value
        End Set
    End Property

    Public Property metodo_identficadorProducto As Integer
        Get
            Return identificadorProducto
        End Get
        Set(value As Integer)
            identificadorProducto = value
        End Set
    End Property
End Class
