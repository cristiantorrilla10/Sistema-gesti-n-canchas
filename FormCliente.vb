Imports MySql.Data.MySqlClient

Public Class FormCliente

    Private Sub ListarClientes()
        Try
            AbrirConexion()
            Dim da As New MySqlDataAdapter("SELECT * FROM cliente", cnn)
            Dim dt As New DataTable()
            da.Fill(dt)
            dgvClientes.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            CerrarConexion()
        End Try
    End Sub

    Private Sub LimpiarCampos()
        txtCodigo.Clear()
        txtNombre.Clear()
        txtDNI.Clear()
        txtTelefono.Clear()
        txtMail.Clear()
    End Sub

    Private Sub btnListar_Click(sender As Object, e As EventArgs) Handles btnListar.Click
        ListarClientes()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            AbrirConexion()
            Dim res As Integer
            If txtNombre.Text.Trim() = "" Or
   txtDNI.Text.Trim() = "" Or
   txtTelefono.Text.Trim() = "" Or
   txtMail.Text.Trim() = "" Then

                MsgBox("Ingrese todos los datos del cliente",, "Error")
                Exit Sub

            End If
            Dim cmd As New MySqlCommand("INSERT INTO cliente (Nombre, DNI, Telefono, Mail) VALUES (@Nombre, @DNI, @Telefono, @Mail)", cnn)

            cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text)
            cmd.Parameters.AddWithValue("@DNI", txtDNI.Text)
            cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text)
            cmd.Parameters.AddWithValue("@Mail", txtMail.Text)

            cmd.ExecuteNonQuery()

            MessageBox.Show("Cliente agregado correctamente")
            ListarClientes()
            LimpiarCampos()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            CerrarConexion()
        End Try
    End Sub

    Private Sub dgvClientes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClientes.CellClick
        If e.RowIndex >= 0 Then
            txtCodigo.Text = dgvClientes.Rows(e.RowIndex).Cells(0).Value.ToString()
            txtNombre.Text = dgvClientes.Rows(e.RowIndex).Cells(1).Value.ToString()
            txtDNI.Text = dgvClientes.Rows(e.RowIndex).Cells(2).Value.ToString()
            txtTelefono.Text = dgvClientes.Rows(e.RowIndex).Cells(3).Value.ToString()
            txtMail.Text = dgvClientes.Rows(e.RowIndex).Cells(4).Value.ToString()
        End If
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If txtCodigo.Text.Trim = "" Then
                MessageBox.Show("Seleccione un cliente para modificar")
                Exit Sub
            End If
            If txtNombre.Text = "" Or txtTelefono.Text = "" Or txtDNI.Text = "" Or txtMail.Text = "" Then
                MessageBox.Show("Complete todos los datos")
                Exit Sub
            End If
            AbrirConexion()

            Dim cmd As New MySqlCommand("UPDATE cliente SET Nombre=@Nombre, DNI=@DNI, Telefono=@Telefono, Mail=@Mail WHERE Codigo_cliente=@Codigo", cnn)

            cmd.Parameters.AddWithValue("@Codigo", txtCodigo.Text)
            cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text)
            cmd.Parameters.AddWithValue("@DNI", txtDNI.Text)
            cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text)
            cmd.Parameters.AddWithValue("@Mail", txtMail.Text)

            cmd.ExecuteNonQuery()

            MessageBox.Show("Cliente modificado correctamente")
            ListarClientes()
            LimpiarCampos()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            CerrarConexion()
        End Try
    End Sub

    Private Sub FormCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        Try
            If dgvClientes.CurrentRow Is Nothing Then
                MessageBox.Show("Seleccione un cliente de la grilla.")
                Exit Sub
            End If

            Dim codigo As Integer =
                Convert.ToInt32(dgvClientes.CurrentRow.Cells("Codigo_Cliente").Value)

            AbrirConexion()

            Dim sql As String =
                "SELECT " &
                "(SELECT COUNT(*) FROM reserva WHERE Codigo_Cliente=@Codigo) + " &
                "(SELECT COUNT(*) FROM alquiler WHERE Codigo_Cliente=@Codigo) + " &
                "(SELECT COUNT(*) FROM factura_cabecera WHERE Codigo_Cliente=@Codigo)"

            Dim cmdVerificar As New MySqlCommand(sql, cnn)
            cmdVerificar.Parameters.AddWithValue("@Codigo", codigo)

            Dim cantidad As Integer = Convert.ToInt32(cmdVerificar.ExecuteScalar())

            If cantidad > 0 Then
                MessageBox.Show("No se puede eliminar este cliente porque tiene reservas, alquileres o facturas asociados.")
                Exit Sub
            End If

            Dim respuesta As DialogResult =
                MessageBox.Show("¿Está seguro de eliminar este cliente?",
                                "Confirmar eliminación",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question)

            If respuesta = DialogResult.Yes Then
                Dim cmdEliminar As New MySqlCommand(
                    "DELETE FROM cliente WHERE Codigo_Cliente=@Codigo", cnn)

                cmdEliminar.Parameters.AddWithValue("@Codigo", codigo)
                cmdEliminar.ExecuteNonQuery()

                MessageBox.Show("Cliente eliminado correctamente.")

                ListarClientes()
                LimpiarCampos()
            End If

        Catch ex As Exception
            MessageBox.Show("Error al eliminar el cliente: " & ex.Message)
        Finally
            CerrarConexion()
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarCampos()
        txtNombre.Focus()
    End Sub
End Class