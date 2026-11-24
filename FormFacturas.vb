Imports MySql.Data.MySqlClient
Public Class FormFacturas
    Dim conexion As New MySqlConnection("server=localhost;port=3306;database=canchitas;user=root;password=")

    Private Sub AbrirConexion()
        If conexion.State = ConnectionState.Closed Then
            conexion.Open()
        End If
    End Sub

    Private Sub CargarFacturas()
        Try
            If conexion.State = ConnectionState.Open Then
                conexion.Close()
            End If

            conexion.Open()

            Dim sql As String = "SELECT * FROM factura_cabecera"
            Dim adaptador As New MySqlDataAdapter(sql, conexion)
            Dim tabla As New DataTable()

            adaptador.Fill(tabla)
            dgvFacturas.DataSource = tabla

            conexion.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)

            If conexion.State = ConnectionState.Open Then
                conexion.Close()
            End If
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Try
            If cmbReserva.SelectedIndex = -1 OrElse cmbReserva.SelectedValue Is Nothing Then
                MessageBox.Show("Seleccioná una reserva para facturar.")
                Exit Sub
            End If

            Dim idReserva As Integer = CInt(cmbReserva.SelectedValue)
            Dim codigoCliente As Integer = CInt(txtCodCliente.Text)

            AbrirConexion()

            ' Obtener el total directamente de la reserva
            Dim sqlTotal As String =
            "SELECT Total FROM reserva WHERE Id_Reserva=@Id"

            Dim cmdTotal As New MySqlCommand(sqlTotal, conexion)
            cmdTotal.Parameters.AddWithValue("@Id", idReserva)

            Dim resultado As Object = cmdTotal.ExecuteScalar()

            If resultado Is Nothing OrElse IsDBNull(resultado) Then
                MessageBox.Show("No se encontró el importe de la reserva.")
                Exit Sub
            End If

            Dim total As Decimal = Convert.ToDecimal(resultado)

            ' Guardar factura vinculada a la reserva
            Dim sqlInsert As String =
            "INSERT INTO factura_cabecera " &
            "(Id_Reserva, Codigo_Cliente, Fecha, Total_Factura) " &
            "VALUES (@Reserva, @Cliente, @Fecha, @Total)"

            Dim cmd As New MySqlCommand(sqlInsert, conexion)

            cmd.Parameters.AddWithValue("@Reserva", idReserva)
            cmd.Parameters.AddWithValue("@Cliente", codigoCliente)
            cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value.Date)
            cmd.Parameters.AddWithValue("@Total", total)

            cmd.ExecuteNonQuery()

            txtTotal.Text = total.ToString("N2")
            conexion.Close()

            MessageBox.Show("Factura guardada correctamente.")

            CargarFacturas()
            CargarReservasPendientes()

        Catch ex As Exception
            MessageBox.Show("Error al guardar la factura: " & ex.Message)

        Finally
            If conexion.State = ConnectionState.Open Then
                conexion.Close()
            End If
        End Try

    End Sub

    Private Sub FormFacturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarFacturas()
        CargarReservasPendientes()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click

        CargarFacturas()
        CargarReservasPendientes()

        txtNroFactura.Clear()
        txtCodCliente.Clear()
        txtTotal.Clear()
        txtBuscarFactura.Clear()

        dtpFecha.Value = Date.Today

        cmbReserva.SelectedIndex = -1
        cmbReserva.Text = ""

        txtCodCliente.Focus()

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            If txtBuscarFactura.Text = "" Then
                MsgBox("Ingresar numero de factura",, "Error")
                Exit Sub
            End If

            If conexion.State = ConnectionState.Open Then
                conexion.Close()
            End If
            conexion.Open()

            Dim sqlBuscar As String = "SELECT * FROM factura_cabecera WHERE Numero_factura = @numero"
            Dim adaptador As New MySqlDataAdapter(sqlBuscar, conexion)
            adaptador.SelectCommand.Parameters.AddWithValue("@numero", txtBuscarFactura.Text)
            Dim tabla As New DataTable()
            adaptador.Fill(tabla)

            dgvFacturas.DataSource = tabla
            conexion.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            conexion.Close()
        End Try
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If txtNroFactura.Text = "" Then
                MessageBox.Show("Ingresá el número de factura.")
                Exit Sub
            End If

            If conexion.State = ConnectionState.Open Then
                conexion.Close()
            End If

            conexion.Open()

            Dim sql As String =
            "UPDATE factura_cabecera SET Fecha=@fecha " &
            "WHERE Numero_factura=@numero"

            Dim cmd As New MySqlCommand(sql, conexion)

            cmd.Parameters.AddWithValue("@fecha", dtpFecha.Value.Date)
            cmd.Parameters.AddWithValue("@numero", txtNroFactura.Text)

            Dim filas As Integer = cmd.ExecuteNonQuery()

            If filas > 0 Then
                MessageBox.Show("Fecha de factura modificada correctamente.")
            Else
                MessageBox.Show("No se encontró la factura.")
            End If

            conexion.Close()
            CargarFacturas()

        Catch ex As Exception
            MessageBox.Show("Error al modificar la factura: " & ex.Message)

            If conexion.State = ConnectionState.Open Then
                conexion.Close()
            End If
        End Try
    End Sub

    Private Sub dgvFacturas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFacturas.CellClick
        If e.RowIndex < 0 Then Exit Sub

        Dim fila As DataGridViewRow = dgvFacturas.Rows(e.RowIndex)

        txtNroFactura.Text = dgvFacturas.Rows(e.RowIndex).Cells(0).Value.ToString
        txtCodCliente.Text = dgvFacturas.Rows(e.RowIndex).Cells(1).Value.ToString
        dtpFecha.Value = Convert.ToDateTime(dgvFacturas.Rows(e.RowIndex).Cells(2).Value)
        txtTotal.Text = dgvFacturas.Rows(e.RowIndex).Cells(3).Value.ToString

    End Sub

    Private Sub CargarReservasPendientes()

        Try
            AbrirConexion()

            Dim consulta As String =
            "SELECT r.Id_Reserva, r.Codigo_Cliente, r.Fecha, " &
            "r.Total, " &
            "CONCAT('Reserva ', r.Id_Reserva, " &
            "' - Cliente ', r.Codigo_Cliente, " &
            "' - ', TIME_FORMAT(r.Hora_Inicio,'%H:%i'), " &
            "' a ', TIME_FORMAT(r.Hora_Fin,'%H:%i')) AS Descripcion " &
            "FROM reserva r " &
            "WHERE NOT EXISTS (" &
            "SELECT 1 FROM factura_cabecera f " &
            "WHERE f.Id_Reserva = r.Id_Reserva) " &
            "ORDER BY r.Fecha, r.Hora_Inicio"

            Dim da As New MySqlDataAdapter(consulta, conexion)
            Dim dt As New DataTable()

            da.Fill(dt)

            cmbReserva.DataSource = Nothing
            cmbReserva.DisplayMember = "Descripcion"
            cmbReserva.ValueMember = "Id_Reserva"
            cmbReserva.DataSource = dt

            cmbReserva.SelectedIndex = -1

        Catch ex As Exception
            MessageBox.Show("Error al cargar las reservas: " & ex.Message)

        Finally
            If conexion.State = ConnectionState.Open Then
                conexion.Close()
            End If
        End Try

    End Sub

    Private Sub cmbReserva_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbReserva.SelectedIndexChanged
        If cmbReserva.SelectedIndex = -1 Then Exit Sub

        Dim fila As DataRowView = TryCast(cmbReserva.SelectedItem, DataRowView)

        If fila Is Nothing Then Exit Sub

        txtCodCliente.Text = fila("Codigo_Cliente").ToString()

        dtpFecha.Value = Convert.ToDateTime(fila("Fecha"))

        txtTotal.Text = Convert.ToDecimal(fila("Total")).ToString("N2")
    End Sub
End Class