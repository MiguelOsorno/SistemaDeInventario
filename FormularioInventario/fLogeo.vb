Imports DatosCapa
Imports EntidadCapa
Public Class fLogeo
    Dim El As New Ent_logueo
    Dim Dl As New Dat_logueo
    Private Sub Btn_logeo_Click(sender As Object, e As EventArgs) Handles Btn_logeo.Click
        Dim dt As New DataTable
        If txtUsuario.Text <> "" And txtcontra.Text <> "" Then
            El.metodo_usuario = txtUsuario.Text
            El.metodo_contrasena = txtcontra.Text
            dt = Dl.validar_usuario(El)
            If dt.Rows.Count > 0 Then
                menuPrincipal.Show()
                Me.Hide()
            Else
                MsgBox("error en contraseña o usuario", MsgBoxStyle.Critical)
            End If
        Else
            MsgBox("Los campos no pueden quedar vacios", MsgBoxStyle.Critical)
        End If
    End Sub
End Class