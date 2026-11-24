Imports MySql.Data.MySqlClient

Public Class FormCanchas

    Private Sub ListarCanchas()
        Try
            AbrirConexion()
            Dim da As New MySqlDataAdapter("SELECT * FROM cancha", cnn)
            Dim dt As New DataTable()
            da.Fill(dt)
            dgvCanchas.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            CerrarConexion()
        End Try
    End Sub

    Private Sub LimpiarCampos()
        txtNumero.Clear()
        txtTipo.Clear()
        chkTecho.Checked = False
        chkLuz.Checked = True
        chkLuz.Enabled = False
        txtPrecioDia.Clear()
        txtPrecioNoche.Clear()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCanchas.CellClick
        If e.RowIndex >= 0 Then
            Dim fila As DataGridViewRow = dgvCanchas.Rows(e.RowIndex)

            txtNumero.Text = Fila.Cells("Numero").Value.ToString()
            txtTipo.Text = Fila.Cells("Tipo").Value.Tostring()
            chkTecho.Checked = Convert.ToBoolean(Fila.Cells("Techo").Value)
            chkLuz.Checked = Convert.ToBoolean(fila.Cells("Luz").Value)
            txtPrecioDia.Text = fila.Cells("Precio_Dia").Value.ToString()
            txtPrecioNoche.Text = fila.Cells("Precio_Noche").Value.ToString()
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If txtNumero.Text.Trim = "" Or txtTipo.Text.Trim = "" Or
           txtPrecioDia.Text.Trim = "" Or txtPrecioNoche.Text.Trim = "" Then

                MessageBox.Show("Complete todos los datos.")
                Exit Sub
            End If

            Dim numero As Integer
            Dim tipo As Integer
            Dim precioDia As Decimal
            Dim precioNoche As Decimal

            If Not Integer.TryParse(txtNumero.Text, numero) OrElse numero <= 0 Then
                MessageBox.Show("Ingrese un número de cancha válido.")
                Exit Sub
            End If

            If Not Integer.TryParse(txtTipo.Text, tipo) OrElse
           (tipo <> 5 AndAlso tipo <> 8) Then
                MessageBox.Show("El tipo de cancha debe ser 5 u 8.")
                Exit Sub
            End If

            If Not Decimal.TryParse(txtPrecioDia.Text, precioDia) OrElse
           Not Decimal.TryParse(txtPrecioNoche.Text, precioNoche) OrElse
           precioDia <= 0 OrElse precioNoche <= 0 Then

                MessageBox.Show("Ingrese precios válidos y mayores que cero.")
                Exit Sub
            End If

            AbrirConexion()

            Dim sqlVerificar As String =
            "SELECT COUNT(*) FROM cancha WHERE Numero=@Numero"

            Dim cmdVerificar As New MySqlCommand(sqlVerificar, cnn)
            cmdVerificar.Parameters.AddWithValue("@Numero", numero)

            Dim existe As Integer = Convert.ToInt32(cmdVerificar.ExecuteScalar())

            If existe > 0 Then
                MessageBox.Show("Ya existe una cancha con ese número.")
                Exit Sub
            End If

            Dim consulta As String =
            "INSERT INTO cancha " &
            "(Numero, Tipo, Techo, Luz, Precio_Dia, Precio_Noche) " &
            "VALUES (@Numero, @Tipo, @Techo, @Luz, @PrecioDia, @PrecioNoche)"

            Dim cmd As New MySqlCommand(consulta, cnn)

            cmd.Parameters.AddWithValue("@Numero", numero)
            cmd.Parameters.AddWithValue("@Tipo", tipo)
            cmd.Parameters.AddWithValue("@Techo", If(chkTecho.Checked, 1, 0))
            cmd.Parameters.AddWithValue("@Luz", 1)
            cmd.Parameters.AddWithValue("@PrecioDia", precioDia)
            cmd.Parameters.AddWithValue("@PrecioNoche", precioNoche)

            cmd.ExecuteNonQuery()

            MessageBox.Show("Cancha agregada correctamente.")

            ListarCanchas()
            ActualizarContadores()
            LimpiarCampos()

        Catch ex As Exception
            MessageBox.Show("Error al agregar la cancha: " & ex.Message)

        Finally
            CerrarConexion()
        End Try
    End Sub

    Private Sub btnListar_Click(sender As Object, e As EventArgs) Handles btnListar.Click
        ListarCanchas()
        ActualizarContadores()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If txtNumero.Text.Trim = "" Then
                MessageBox.Show("Seleccione una cancha para modificar.")
                Exit Sub
            End If

            If txtTipo.Text = "" Or txtPrecioDia.Text = "" Or txtPrecioNoche.Text = "" Then
                MessageBox.Show("Complete todos los datos.")
                Exit Sub
            End If

            Dim numero As Integer = CInt(txtNumero.Text)
            Dim tipo As Integer = CInt(txtTipo.Text)
            Dim precioDia As Decimal
            Dim precioNoche As Decimal

            If Not Integer.TryParse(txtNumero.Text, numero) OrElse numero <= 0 Then
                MessageBox.Show("Ingrese un número de cancha válido.")
                Exit Sub
            End If

            If Not Integer.TryParse(txtTipo.Text, tipo) OrElse
            (tipo <> 5 AndAlso tipo <> 8) Then
                MessageBox.Show("El tipo de cancha debe ser 5 u 8.")
                Exit Sub
            End If

            If Not Decimal.TryParse(txtPrecioDia.Text, precioDia) OrElse
            Not Decimal.TryParse(txtPrecioNoche.Text, precioNoche) OrElse
            precioDia <= 0 OrElse precioNoche <= 0 Then

                MessageBox.Show("Ingrese precios válidos y mayores que cero.")
                Exit Sub
            End If

            AbrirConexion()

            Dim sqlVerificar As String =
            "SELECT " &
            "(SELECT COUNT(*) FROM reserva WHERE Numero_Cancha=@Numero) + " &
            "(SELECT COUNT(*) FROM alquiler WHERE Numero_Cancha=@Numero)"

            Dim cmdVerificar As New MySqlCommand(sqlVerificar, cnn)
            cmdVerificar.Parameters.AddWithValue("@Numero", numero)

            Dim cantidad As Integer =
            Convert.ToInt32(cmdVerificar.ExecuteScalar())

            If cantidad > 0 Then
                Dim sql As String =
                "UPDATE cancha SET Precio_Dia=@PrecioDia, " &
                "Precio_Noche=@PrecioNoche WHERE Numero=@Numero"

                Dim cmd As New MySqlCommand(sql, cnn)
                cmd.Parameters.AddWithValue("@Numero", numero)
                cmd.Parameters.AddWithValue("@PrecioDia", precioDia)
                cmd.Parameters.AddWithValue("@PrecioNoche", precioNoche)

                cmd.ExecuteNonQuery()

                MessageBox.Show(
                "La cancha tiene movimientos asociados. " &
                "Solo se actualizaron los precios.")
            Else
                Dim sql As String =
                "UPDATE cancha SET Tipo=@Tipo, Techo=@Techo, Luz=@Luz, " &
                "Precio_Dia=@PrecioDia, Precio_Noche=@PrecioNoche " &
                "WHERE Numero=@Numero"

                Dim cmd As New MySqlCommand(sql, cnn)
                cmd.Parameters.AddWithValue("@Numero", numero)
                cmd.Parameters.AddWithValue("@Tipo", tipo)
                cmd.Parameters.AddWithValue("@Techo", If(chkTecho.Checked, 1, 0))
                cmd.Parameters.AddWithValue("@Luz", 1)
                cmd.Parameters.AddWithValue("@PrecioDia", precioDia)
                cmd.Parameters.AddWithValue("@PrecioNoche", precioNoche)

                cmd.ExecuteNonQuery()

                MessageBox.Show("Cancha modificada correctamente.")
            End If

            ListarCanchas()
            ActualizarContadores()
            LimpiarCampos()

        Catch ex As Exception
            MessageBox.Show("Error al modificar la cancha: " & ex.Message)
        Finally
            CerrarConexion()
        End Try
    End Sub

    Private Sub Canchas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        chkLuz.Checked = True
        chkLuz.Enabled = False
        ActualizarContadores()

    End Sub
    Private Sub ActualizarContadores()

        Try
            AbrirConexion()

            Dim consulta As String =
            "SELECT Tipo, Techo, COUNT(*) AS Cantidad " &
            "FROM cancha " &
            "GROUP BY Tipo, Techo"

            Dim comando As New MySqlCommand(consulta, cnn)
            Dim lector As MySqlDataReader = comando.ExecuteReader()

            ' Valores iniciales
            lblCantF5Aire.Text = "0 canchas"
            lblCantF5Techo.Text = "0 canchas"
            lblCantF8Aire.Text = "0 canchas"
            lblCantF8Techo.Text = "0 canchas"

            While lector.Read()

                Dim tipo As Integer = Convert.ToInt32(lector("Tipo"))
                Dim techo As Integer = Convert.ToInt32(lector("Techo"))
                Dim cantidad As Integer = Convert.ToInt32(lector("Cantidad"))

                If tipo = 5 AndAlso techo = 0 Then
                    lblCantF5Aire.Text = cantidad & " canchas"

                ElseIf tipo = 5 AndAlso techo = 1 Then
                    lblCantF5Techo.Text = cantidad & " canchas"

                ElseIf tipo = 8 AndAlso techo = 0 Then
                    lblCantF8Aire.Text = cantidad & " canchas"

                ElseIf tipo = 8 AndAlso techo = 1 Then
                    lblCantF8Techo.Text = cantidad & " canchas"
                End If

            End While

            lector.Close()
            CerrarConexion()

        Catch ex As Exception
            If cnn.State = ConnectionState.Open Then
                CerrarConexion()
            End If

            MsgBox("Error al actualizar las cantidades: " & ex.Message)
        End Try

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        If dgvCanchas.SelectedRows.Count = 0 Then
            MessageBox.Show("Seleccione una cancha para eliminar.")
            Exit Sub
        End If

        Dim numero As Integer = Convert.ToInt32(
            dgvCanchas.SelectedRows(0).Cells("Numero").Value)

        Try
            If cnn.State = ConnectionState.Open Then
                cnn.Close()
            End If

            cnn.Open()

            Dim consulta As String =
                "SELECT " &
                "(SELECT COUNT(*) FROM reserva WHERE Numero_Cancha=@Numero) + " &
                "(SELECT COUNT(*) FROM alquiler WHERE Numero_Cancha=@Numero)"

            Dim comandoVerificar As New MySqlCommand(consulta, cnn)
            comandoVerificar.Parameters.AddWithValue("@Numero", numero)

            Dim cantidad As Integer =
                Convert.ToInt32(comandoVerificar.ExecuteScalar())

            If cantidad > 0 Then
                MessageBox.Show(
                    "No se puede eliminar esta cancha porque tiene reservas o alquileres asociados.",
                    "Cancha protegida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim respuesta As DialogResult = MessageBox.Show(
                "¿Está seguro de que desea eliminar la cancha número " & numero & "?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)

            If respuesta = DialogResult.Yes Then

                Dim consultaEliminar As String =
                    "DELETE FROM cancha WHERE Numero=@Numero"

                Dim comandoEliminar As New MySqlCommand(consultaEliminar, cnn)
                comandoEliminar.Parameters.AddWithValue("@Numero", numero)

                comandoEliminar.ExecuteNonQuery()

                MessageBox.Show("Cancha eliminada correctamente.")

                ListarCanchas()
                ActualizarContadores()

            End If

        Catch ex As Exception
            MessageBox.Show("Error al eliminar la cancha: " & ex.Message)

        Finally
            If cnn.State = ConnectionState.Open Then
                cnn.Close()
            End If
        End Try

    End Sub

End Class