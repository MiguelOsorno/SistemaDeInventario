Imports DatosCapa
Imports EntidadCapa
Imports System.Data.SqlClient
Public Class fTransaccion
    Dim conectar As New conexion
    Dim Da As New SqlDataAdapter
    Dim dt As New DataTable


    Private Sub BtnCargarDatos_Click(sender As Object, e As EventArgs) Handles btnCargarDatos.Click
        mostrarProductos()
        mostrarProvedores()
    End Sub

    Public Sub mostrarProvedores()
        Try
            conectar.conectando()
            Da = New SqlDataAdapter("select * from provedor", conectar.cnx)
            dt = New DataTable
            Da.Fill(dt)
            tablaProvedores.DataSource = dt
            conectar.desconectando()
        Catch ex As Exception
            MsgBox("error al cargar datos de tabla", MsgBoxStyle.Information)
        End Try
    End Sub

    Public Sub mostrarProductos()
        Try
            conectar.conectando()
            Da = New SqlDataAdapter("select identificador,nombre,descripcion from producto", conectar.cnx)
            dt = New DataTable
            Da.Fill(dt)
            tablaProductos.DataSource = dt
            conectar.desconectando()
        Catch ex As Exception
            MsgBox("error al cargar datos de tabla", MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        menuPrincipal.Show()
        Me.Hide()
    End Sub

    Private Sub TablaProductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tablaProductos.CellContentClick
        Dim i As Integer
        i = tablaProductos.CurrentRow.Index
        TxtIdProducto.Text = tablaProductos.Item(0, i).Value()
        TxtNombreProducto.Text = tablaProductos.Item(1, i).Value()
    End Sub

    Private Sub TablaProvedores_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tablaProvedores.CellContentClick
        Dim i As Integer
        i = tablaProvedores.CurrentRow.Index
        TxtIdProvedor.Text = tablaProvedores.Item(0, i).Value()
        TxtNombreProvedor.Text = tablaProvedores.Item(0, i).Value()
    End Sub
End Class