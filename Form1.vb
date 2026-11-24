Public Class Form1

    Private Sub btnClientes_Click(sender As Object, e As EventArgs) Handles btnClientes.Click
        FormCliente.ShowDialog()
    End Sub

    Private Sub btnCancha_Click(sender As Object, e As EventArgs) Handles btnCancha.Click
        FormCanchas.ShowDialog()
    End Sub

    Private Sub btnAquiler_Click(sender As Object, e As EventArgs) Handles btnAlquiler.Click
        FormAlquiler.ShowDialog()
    End Sub

    Private Sub btnFacturas_Click(sender As Object, e As EventArgs) Handles btnFacturas.Click
        formFacturas.ShowDialog()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
