Public Class menuPrincipal
    Private Sub LbModuloProducto_Click(sender As Object, e As EventArgs) Handles lbModuloProducto.Click

    End Sub

    Private Sub BtnProducto_Click(sender As Object, e As EventArgs) Handles btnProducto.Click
        fProducto.Show()
        Me.Hide()
    End Sub

    Private Sub BtnProvedor_Click(sender As Object, e As EventArgs) Handles btnProvedor.Click
        fProvedor.Show()
        Me.Hide()
    End Sub

    Private Sub BtnTransaccion_Click(sender As Object, e As EventArgs) Handles btnTransaccion.Click
        fTransaccion.Show()
        Me.Hide()
    End Sub
End Class