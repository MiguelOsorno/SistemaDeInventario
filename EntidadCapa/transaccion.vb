Public Class transaccion
    Private fecha_trasaccion As Date
    Private idProducto_transaccion As Integer
    Private idProvedor_transaccion As Integer
    Private cantidad_transaccion As Integer
    Private tipoTransaccion As String

    Public Property metodo_fechaTransaccion As Date
        Get
            Return fecha_trasaccion
        End Get
        Set(value As Date)
            fecha_trasaccion = value
        End Set
    End Property

    Public Property metodo_idProductoTrasaccion As Integer
        Get
            Return idProducto_transaccion
        End Get
        Set(value As Integer)
            idProducto_transaccion = value
        End Set
    End Property

    Public Property metodo_idProvedorTransaccion As Integer
        Get
            Return idProvedor_transaccion
        End Get
        Set(value As Integer)
            idProvedor_transaccion = value
        End Set
    End Property

    Public Property metodo_cantidadTransaccion As Integer
        Get
            Return cantidad_transaccion
        End Get
        Set(value As Integer)
            cantidad_transaccion = value
        End Set
    End Property

    Public Property metodo_tipoTransaccion As String
        Get
            Return tipoTransaccion
        End Get
        Set(value As String)
            tipoTransaccion = value
        End Set
    End Property
End Class
