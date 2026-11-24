Imports MySql.Data.MySqlClient
Public Class FormAlquiler

    Private Sub ListarAlquiler()
        Try
            AbrirConexion()

            Dim consulta As String =
        "SELECT a.Id_Alquiler, a.Id_Reserva, a.Codigo_Cliente, " &
        "CONCAT('F', a.Tipo) AS Tipo_Cancha, " &
        "a.Numero_Cancha, " &
        "CASE WHEN c.Techo = 1 THEN 'Techada' ELSE 'Aire libre' END AS Caracteristica, " &
        "a.Dia, a.Hora, a.Modif_Precio AS Precio, " &
        "CASE WHEN r.Usa_Luz = 1 THEN 'Con luz' ELSE 'Sin luz' END AS Iluminacion " &
        "FROM alquiler a " &
        "LEFT JOIN cancha c ON a.Numero_Cancha = c.Numero " &
        "LEFT JOIN reserva r ON a.Id_Reserva = r.Id_Reserva " &
        "ORDER BY a.Dia ASC, a.Hora ASC"

            Dim da As New MySqlDataAdapter(consulta, cnn)
            Dim dt As New DataTable()

            da.Fill(dt)
            dgvAlquiler.DataSource = dt
            With dgvAlquiler.Columns
                .Item("Id_Alquiler").HeaderText = "N.º de alquiler"
                .Item("Id_Reserva").HeaderText = "N.º de reserva"
                .Item("Codigo_Cliente").HeaderText = "Código de cliente"
                .Item("Tipo_Cancha").HeaderText = "Tipo de cancha"
                .Item("Numero_Cancha").HeaderText = "N.º de cancha"
                .Item("Caracteristica").HeaderText = "Característica"
                .Item("Dia").HeaderText = "Fecha"
                .Item("Hora").HeaderText = "Hora"
                .Item("Precio").HeaderText = "Precio por hora"
                .Item("Iluminacion").HeaderText = "Iluminación"
            End With

        Catch ex As Exception
            MessageBox.Show("Error al listar alquileres: " & ex.Message)

        Finally
            CerrarConexion()
        End Try
    End Sub

    Private Sub LimpiarCampos()

        txtId_Alquiler.Clear()
        cmbCodigo_Cliente.SelectedIndex = -1

        cmbTipo.SelectedIndex = -1
        cmbTecho.SelectedIndex = -1
        cmbCancha.Items.Clear()
        cmbCancha.SelectedIndex = -1

        dtpDia.Value = Date.Now
        dtpHora.Value = Date.Now

        nudHoras.Value = 1

        txtModif_Precio.Clear()

    End Sub

    Private Sub ListarReservas()
        Try
            AbrirConexion()

            Dim consulta As String =
    "SELECT r.Id_Reserva, r.Codigo_Cliente, " &
    "r.Numero_Cancha, c.Tipo, c.Techo, " &
    "r.Fecha, r.Hora_Inicio, r.Hora_Fin, r.Total, " &
    "CASE WHEN r.Usa_Luz = 1 THEN 'Con luz' ELSE 'Sin luz' END AS Iluminacion " &
    "FROM reserva r " &
    "LEFT JOIN cancha c ON r.Numero_Cancha = c.Numero " &
    "WHERE r.Fecha >= DATE_SUB(CURDATE(), INTERVAL 30 DAY) " &
    "ORDER BY r.Fecha DESC, r.Hora_Inicio ASC"

            Dim da As New MySqlDataAdapter(consulta, cnn)
            Dim dt As New DataTable()

            da.Fill(dt)

            dgvAlquiler.DataSource = dt
            dgvAlquiler.Columns("Iluminacion").HeaderText = "Iluminación"

        Catch ex As Exception
            MessageBox.Show("Error al listar las reservas: " & ex.Message)

        Finally
            CerrarConexion()
        End Try
    End Sub

    Private Sub btnListar_Click(sender As Object, e As EventArgs) Handles btnListar.Click
        ListarReservas()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If cmbLuz.SelectedIndex() = -1 Then
                MessageBox.Show("Seleccioná si queres utilizar la cancha con luz o sin luz")
                cmbLuz.Focus()
                Exit Sub
            End If

            If cmbTipo.SelectedIndex = -1 OrElse
           cmbTecho.SelectedIndex = -1 OrElse
           cmbCancha.SelectedIndex = -1 Then

                MessageBox.Show("Seleccioná el dia, hora, el tipo, el techo y el número de cancha.")
                Exit Sub
            End If

            If cmbCodigo_Cliente.SelectedIndex = -1 Then
                MessageBox.Show("Seleccioná un cliente.")
                cmbCodigo_Cliente.Focus()
                Exit Sub
            End If

            Dim codigoCliente As Integer =
            Convert.ToInt32(cmbCodigo_Cliente.SelectedValue)

            Dim tipoCancha As Integer = CInt(cmbTipo.SelectedItem)
            Dim numeroCancha As Integer = CInt(cmbCancha.SelectedItem)
            Dim fecha As Date = dtpDia.Value.Date
            Dim hora As DateTime = dtpHora.Value
            If hora.Minute <> 0 Then
                MessageBox.Show("Los turnos deben comenzar en una hora exacta")
                Exit Sub
            End If
            Dim cantidadHoras As Integer = CInt(nudHoras.Value)
            Dim usarLuz As Boolean = cmbLuz.SelectedItem.ToString() = "Con luz"

            If cantidadHoras <= 0 Then
                MessageBox.Show("La duración debe ser mayor a cero.")
                Exit Sub
            End If

            If hora.TimeOfDay < New TimeSpan(10, 0, 0) Then
                MessageBox.Show("El complejo está cerrado. El horario de atención es de 10:00 a 00:00.")
                Exit Sub
            End If

            If hora.TimeOfDay + TimeSpan.FromHours(cantidadHoras) > New TimeSpan(24, 0, 0) Then
                MessageBox.Show("El complejo cierra a las 00:00. El último turno es de 23:00 a 00:00.")
                Exit Sub
            End If

            AbrirConexion()
            ' Verificar que el cliente exista
            Dim sqlCliente As String =
            "SELECT COUNT(*) FROM cliente WHERE Codigo_Cliente = @Codigo"

            Dim cmdCliente As New MySqlCommand(sqlCliente, cnn)
            cmdCliente.Parameters.AddWithValue("@Codigo", codigoCliente)

            Dim existeCliente As Integer =
            Convert.ToInt32(cmdCliente.ExecuteScalar())

            If existeCliente = 0 Then
                MessageBox.Show("El código de cliente ingresado no existe.")
                cmbCodigo_Cliente.Focus()
                Exit Sub
            End If

            ' Verificar disponibilidad
            For i As Integer = 0 To cantidadHoras - 1

                Dim fechaHora As DateTime =
                fecha.Date.Add(hora.TimeOfDay).AddHours(i)

                If Not TurnoDisponible(numeroCancha,
                                  fechaHora.Date,
                                  fechaHora.ToString("HH:mm")) Then

                    MessageBox.Show("La cancha no está disponible en ese horario.")
                    Exit Sub
                End If
            Next

            ' Calcular el precio de cada hora
            Dim precios As New List(Of Integer)
            Dim total As Decimal = 0

            For i As Integer = 0 To cantidadHoras - 1

                Dim fechaHora As DateTime =
                fecha.Date.Add(hora.TimeOfDay).AddHours(i)

                Dim precioHora As Integer =
                ObtenerPrecio(tipoCancha, fechaHora.Date, fechaHora, usarLuz)

                precios.Add(precioHora)
                total += precioHora
            Next

            ' Iniciar transacción
            Dim trans As MySqlTransaction = cnn.BeginTransaction()

            Try
                ' Crear reserva completa
                Dim sqlReserva As String =
                "INSERT INTO reserva " &
                "(Codigo_Cliente, Numero_Cancha, Fecha, Hora_Inicio, Hora_Fin, Total, Usa_Luz) " &
                "VALUES (@Cliente, @Cancha, @Fecha, @Inicio, @Fin, @Total, @Luz)"

                Dim cmdReserva As New MySqlCommand(sqlReserva, cnn, trans)

                cmdReserva.Parameters.AddWithValue("@Cliente", codigoCliente)
                cmdReserva.Parameters.AddWithValue("@Cancha", numeroCancha)
                cmdReserva.Parameters.AddWithValue("@Fecha", fecha.ToString("yyyy-MM-dd"))
                cmdReserva.Parameters.AddWithValue("@Inicio", hora.ToString("HH:mm:00"))
                cmdReserva.Parameters.AddWithValue("@Fin", hora.AddHours(cantidadHoras).ToString("HH:mm:00"))
                cmdReserva.Parameters.AddWithValue("@Total", total)
                cmdReserva.Parameters.AddWithValue("@Luz", usarLuz)

                cmdReserva.ExecuteNonQuery()

                Dim idReserva As Integer =
                Convert.ToInt32(cmdReserva.LastInsertedId)

                ' Guardar el detalle de cada hora
                For i As Integer = 0 To cantidadHoras - 1

                    Dim fechaHora As DateTime =
                    fecha.Date.Add(hora.TimeOfDay).AddHours(i)

                    Dim sqlAlquiler As String =
                    "INSERT INTO alquiler " &
                    "(Id_Reserva, Codigo_Cliente, Tipo, Numero_Cancha, Dia, Hora, Modif_Precio) " &
                    "VALUES (@Reserva, @Cliente, @Tipo, @Cancha, @Dia, @Hora, @Precio)"

                    Dim cmdAlquiler As New MySqlCommand(sqlAlquiler, cnn, trans)

                    cmdAlquiler.Parameters.AddWithValue("@Reserva", idReserva)
                    cmdAlquiler.Parameters.AddWithValue("@Cliente", codigoCliente)
                    cmdAlquiler.Parameters.AddWithValue("@Tipo", tipoCancha)
                    cmdAlquiler.Parameters.AddWithValue("@Cancha", numeroCancha)
                    cmdAlquiler.Parameters.AddWithValue("@Dia", fechaHora.ToString("yyyy-MM-dd"))
                    cmdAlquiler.Parameters.AddWithValue("@Hora", fechaHora.ToString("HH:mm:00"))
                    cmdAlquiler.Parameters.AddWithValue("@Precio", precios(i))

                    cmdAlquiler.ExecuteNonQuery()
                Next

                trans.Commit()

                MessageBox.Show("Reserva registrada correctamente." &
                            vbCrLf & "Número de reserva: " & idReserva &
                            vbCrLf & "Total: $" & total.ToString("N2"))

                txtModif_Precio.Text = precios(0).ToString()

                ListarReservas()
                LimpiarCampos()

            Catch
                trans.Rollback()
                Throw
            End Try

        Catch ex As Exception
            MessageBox.Show("Error al registrar la reserva: " & ex.Message)

        Finally
            CerrarConexion()
        End Try
    End Sub

    Private Function TurnoDisponible(numeroCancha As Integer,
                                 fecha As Date,
                                 hora As String,
                                 Optional idReserva As Integer = 0) As Boolean

        Dim sql As String =
        "SELECT COUNT(*) FROM alquiler " &
        "WHERE Numero_Cancha = @Numero_Cancha " &
        "AND Dia = @Dia " &
        "AND TIME_FORMAT(Hora,'%H:%i') = @Hora " &
        "AND (Id_Reserva IS NULL OR Id_Reserva <> @IdReserva)"

        Dim cmd As New MySqlCommand(sql, cnn)

        cmd.Parameters.AddWithValue("@Numero_Cancha", numeroCancha)
        cmd.Parameters.AddWithValue("@Dia", fecha.ToString("yyyy-MM-dd"))
        cmd.Parameters.AddWithValue("@Hora", hora)
        cmd.Parameters.AddWithValue("@IdReserva", idReserva)

        Dim cantidad As Integer = Convert.ToInt32(cmd.ExecuteScalar())

        Return cantidad = 0

    End Function

    Private Sub btnDisponibilidad_Click(sender As Object, e As EventArgs) Handles btnDisponibilidad.Click

        If cmbLuz.SelectedIndex = -1 Then

            MessageBox.Show("Por favor, completá los datos de la reserva para continuar.",
                    "Datos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)

            cmbLuz.Focus()
            Exit Sub

        End If

        CargarCanchasDisponibles()

    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click

        Dim trans As MySqlTransaction = Nothing

        Try
            If txtId_Alquiler.Text.Trim() = "" Then
                MessageBox.Show("Seleccioná una reserva para modificar.")
                Exit Sub
            End If

            If cmbTipo.SelectedIndex = -1 OrElse
           cmbTecho.SelectedIndex = -1 OrElse
           cmbCancha.SelectedIndex = -1 Then

                MessageBox.Show("Seleccioná el tipo, el techo y la cancha.")
                Exit Sub
            End If

            Dim idReserva As Integer = CInt(txtId_Alquiler.Text)

            If cmbCodigo_Cliente.SelectedIndex = -1 Then
                MessageBox.Show("Seleccioná un cliente.")
                cmbCodigo_Cliente.Focus()
                Exit Sub
            End If

            Dim codigoCliente As Integer =
            Convert.ToInt32(cmbCodigo_Cliente.SelectedValue)
            Dim tipoCancha As Integer = CInt(cmbTipo.SelectedItem)
            Dim numeroCancha As Integer = CInt(cmbCancha.SelectedItem)
            Dim fecha As Date = dtpDia.Value.Date
            Dim hora As DateTime = dtpHora.Value
            If hora.Minute <> 0 Then
                MessageBox.Show("Los turnos deben comenzar en una hora exacta")
                Exit Sub
            End If
            Dim cantidadHoras As Integer = CInt(nudHoras.Value)
            If cmbLuz.SelectedIndex = -1 Then
                MessageBox.Show("Seleccioná si querés utilizar la cancha con luz o sin luz.")
                cmbLuz.Focus()
                Exit Sub
            End If
            Dim usarLuz As Boolean = cmbLuz.SelectedItem.ToString() = "Con luz"

            If cantidadHoras <= 0 Then
                MessageBox.Show("La duración debe ser mayor a cero.")
                Exit Sub
            End If

            If hora.TimeOfDay < New TimeSpan(10, 0, 0) Then
                MessageBox.Show("El complejo está cerrado. El horario de atención es de 10:00 a 00:00.")
                Exit Sub
            End If

            If hora.TimeOfDay + TimeSpan.FromHours(cantidadHoras) > New TimeSpan(24, 0, 0) Then
                MessageBox.Show("El complejo cierra a las 00:00. El último turno es de 23:00 a 00:00.")
                Exit Sub
            End If

            AbrirConexion()

            ' Verificar si la reserva ya tiene factura
            Dim sqlFactura As String =
            "SELECT COUNT(*) FROM factura_cabecera WHERE Id_Reserva=@Id"

            Dim cmdFactura As New MySqlCommand(sqlFactura, cnn)
            cmdFactura.Parameters.AddWithValue("@Id", idReserva)

            Dim tieneFactura As Integer =
            Convert.ToInt32(cmdFactura.ExecuteScalar())

            If tieneFactura > 0 Then
                MessageBox.Show("No se puede modificar esta reserva porque ya tiene una factura asociada.")
                Exit Sub
            End If

            ' Comprobar disponibilidad
            For i As Integer = 0 To cantidadHoras - 1

                Dim fechaHora As DateTime =
                fecha.Date.Add(hora.TimeOfDay).AddHours(i)

                If Not TurnoDisponible(numeroCancha,
                                  fechaHora.Date,
                                  fechaHora.ToString("HH:mm"),
                                  idReserva) Then

                    MessageBox.Show("La cancha no está disponible en ese horario.")
                    Exit Sub
                End If
            Next

            ' Calcular precios y total
            Dim precios As New List(Of Integer)
            Dim total As Decimal = 0

            For i As Integer = 0 To cantidadHoras - 1

                Dim fechaHora As DateTime =
                fecha.Date.Add(hora.TimeOfDay).AddHours(i)

                Dim precioHora As Integer =
                ObtenerPrecio(tipoCancha, fechaHora.Date, fechaHora, usarLuz)

                precios.Add(precioHora)
                total += precioHora
            Next

            ' Iniciar transacción
            trans = cnn.BeginTransaction()

            ' Actualizar reserva completa
            Dim sqlReserva As String =
            "UPDATE reserva SET Codigo_Cliente=@Cliente, " &
            "Numero_Cancha=@Cancha, Fecha=@Fecha, " &
            "Hora_Inicio=@Inicio, Hora_Fin=@Fin, " &
            "Total=@Total, Usa_Luz=@Luz " &
            "WHERE Id_Reserva=@Id"

            Dim cmdReserva As New MySqlCommand(sqlReserva, cnn, trans)

            cmdReserva.Parameters.AddWithValue("@Cliente", codigoCliente)
            cmdReserva.Parameters.AddWithValue("@Cancha", numeroCancha)
            cmdReserva.Parameters.AddWithValue("@Fecha", fecha)
            cmdReserva.Parameters.AddWithValue("@Inicio", hora.ToString("HH:mm:00"))
            cmdReserva.Parameters.AddWithValue("@Fin", hora.AddHours(cantidadHoras).ToString("HH:mm:00"))
            cmdReserva.Parameters.AddWithValue("@Total", total)
            cmdReserva.Parameters.AddWithValue("@Luz", usarLuz)
            cmdReserva.Parameters.AddWithValue("@Id", idReserva)

            cmdReserva.ExecuteNonQuery()

            ' Eliminar el detalle horario anterior
            Dim cmdEliminar As New MySqlCommand(
            "DELETE FROM alquiler WHERE Id_Reserva=@Id",
            cnn, trans)

            cmdEliminar.Parameters.AddWithValue("@Id", idReserva)
            cmdEliminar.ExecuteNonQuery()

            ' Guardar los nuevos horarios
            For i As Integer = 0 To cantidadHoras - 1

                Dim fechaHora As DateTime =
                fecha.Date.Add(hora.TimeOfDay).AddHours(i)

                Dim sqlAlquiler As String =
                "INSERT INTO alquiler " &
                "(Id_Reserva, Codigo_Cliente, Tipo, Numero_Cancha, Dia, Hora, Modif_Precio) " &
                "VALUES (@Reserva, @Cliente, @Tipo, @Cancha, @Dia, @Hora, @Precio)"

                Dim cmdAlquiler As New MySqlCommand(sqlAlquiler, cnn, trans)

                cmdAlquiler.Parameters.AddWithValue("@Reserva", idReserva)
                cmdAlquiler.Parameters.AddWithValue("@Cliente", codigoCliente)
                cmdAlquiler.Parameters.AddWithValue("@Tipo", tipoCancha)
                cmdAlquiler.Parameters.AddWithValue("@Cancha", numeroCancha)
                cmdAlquiler.Parameters.AddWithValue("@Dia", fechaHora.Date)
                cmdAlquiler.Parameters.AddWithValue("@Hora", fechaHora.ToString("HH:mm:00"))
                cmdAlquiler.Parameters.AddWithValue("@Precio", precios(i))

                cmdAlquiler.ExecuteNonQuery()
            Next

            trans.Commit()

            MessageBox.Show("Reserva modificada correctamente.")

            txtModif_Precio.Text = total.ToString("N2")

            ListarReservas()
            LimpiarCampos()

        Catch ex As Exception

            If trans IsNot Nothing Then
                trans.Rollback()
            End If

            MessageBox.Show("Error al modificar la reserva: " & ex.Message)

        Finally
            CerrarConexion()
        End Try

    End Sub

    Private Sub dgvAlquiler_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAlquiler.CellClick

        If e.RowIndex < 0 Then Exit Sub

        Dim fila As DataGridViewRow = dgvAlquiler.Rows(e.RowIndex)

        ' Identificador de la reserva
        txtId_Alquiler.Text = fila.Cells("Id_Reserva").Value.ToString()

        ' Cliente
        cmbCodigo_Cliente.SelectedValue =
        Convert.ToInt32(fila.Cells("Codigo_Cliente").Value)

        ' Tipo de cancha
        cmbTipo.SelectedItem = fila.Cells("Tipo").Value.ToString()

        ' Característica de la cancha
        If Convert.ToInt32(fila.Cells("Techo").Value) = 1 Then
            cmbTecho.SelectedItem = "Techada"
        Else
            cmbTecho.SelectedItem = "Al aire libre"
        End If

        ' Cargar las canchas correspondientes
        CargarCanchas()

        ' Seleccionar número de cancha
        cmbCancha.SelectedItem = fila.Cells("Numero_Cancha").Value.ToString()

        ' Fecha
        dtpDia.Value = Convert.ToDateTime(fila.Cells("Fecha").Value)

        ' Hora de inicio
        Dim inicio As TimeSpan =
        TimeSpan.Parse(fila.Cells("Hora_Inicio").Value.ToString())

        dtpHora.Value = Date.Today.Add(inicio)

        ' Duración de la reserva
        Dim fin As TimeSpan =
        TimeSpan.Parse(fila.Cells("Hora_Fin").Value.ToString())

        Dim duracion As Double = (fin - inicio).TotalHours

        If duracion <= 0 Then
            duracion += 24
        End If

        If duracion >= nudHoras.Minimum AndAlso duracion <= nudHoras.Maximum Then
            nudHoras.Value = CDec(duracion)
        End If

        ' Total
        txtModif_Precio.Text = fila.Cells("Total").Value.ToString()
        ' Iluminación
        Dim iluminacion As String =
            fila.Cells("Iluminacion").Value.ToString()

        If iluminacion = "Con luz" Then
            cmbLuz.SelectedItem = "Con luz"
        ElseIf iluminacion = "Sin luz" Then
            cmbLuz.SelectedItem = "Sin luz"
        End If

    End Sub

    Private Function ObtenerPrecio(tipoCancha As Integer, fecha As Date, hora As DateTime, usarLuz As Boolean) As Integer

        Dim precio As Integer = 0

        Dim cmdPrecio As New MySqlCommand(
        "SELECT Precio_Dia, Precio_Noche FROM cancha WHERE Tipo=@tipo LIMIT 1", cnn)

        cmdPrecio.Parameters.AddWithValue("@tipo", tipoCancha)

        Dim dr As MySqlDataReader = cmdPrecio.ExecuteReader()

        If dr.Read() Then
            If hora.Hour >= 18 Then
                precio = Convert.ToInt32(dr("Precio_Noche"))
            Else
                precio = Convert.ToInt32(dr("Precio_Dia"))
            End If
        End If

        dr.Close()

        If fecha.DayOfWeek = DayOfWeek.Saturday OrElse
       fecha.DayOfWeek = DayOfWeek.Sunday Then
            precio += 10000
        End If

        Return precio

    End Function

    Private Sub CargarClientes()
        Try
            AbrirConexion()

            Dim consulta As String =
            "SELECT Codigo_Cliente, Nombre FROM cliente ORDER BY Nombre"

            Dim da As New MySqlDataAdapter(consulta, cnn)
            Dim dt As New DataTable()

            da.Fill(dt)

            cmbCodigo_Cliente.DataSource = dt
            cmbCodigo_Cliente.DisplayMember = "Nombre"
            cmbCodigo_Cliente.ValueMember = "Codigo_Cliente"
            cmbCodigo_Cliente.SelectedIndex = -1

        Catch ex As Exception
            MessageBox.Show("Error al cargar los clientes: " & ex.ToString())

        Finally
            CerrarConexion()
        End Try
    End Sub

    Private Sub FormAlquiler_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbTipo.Items.Clear()
        cmbTipo.Items.Add("5")
        cmbTipo.Items.Add("8")

        cmbTecho.Items.Clear()
        cmbTecho.Items.Add("Al aire libre")
        cmbTecho.Items.Add("Techada")

        cmbLuz.Items.Clear()
        cmbLuz.Items.Add("Con luz")
        cmbLuz.Items.Add("Sin luz")
        cmbLuz.SelectedIndex = 0

        cmbCancha.Items.Clear()
        CargarClientes()
    End Sub

    Private Sub CargarCanchasDisponibles()

        cmbCancha.Items.Clear()

        If cmbTipo.SelectedIndex = -1 OrElse
           cmbTecho.SelectedIndex = -1 Then

            MessageBox.Show("Seleccione el tipo y la característica de la cancha.")
            Exit Sub
        End If

        Try
            AbrirConexion()

            Dim tipo As Integer = CInt(cmbTipo.SelectedItem)
            Dim techo As Integer = If(cmbTecho.SelectedItem.ToString() = "Techada", 1, 0)

            Dim fecha As Date = dtpDia.Value.Date
            Dim horaInicio As DateTime = dtpHora.Value
            Dim cantidadHoras As Integer = CInt(nudHoras.Value)
            If horaInicio.TimeOfDay.TotalHours + cantidadHoras > 24 Then
                MessageBox.Show("El complejo cierra a las 00:00. No se pueden reservar horarios posteriores.")
                Exit Sub
            End If

            Dim consulta As String =
                "SELECT Numero FROM cancha WHERE Tipo=@Tipo AND Techo=@Techo ORDER BY Numero"

            Dim da As New MySqlDataAdapter(consulta, cnn)
            da.SelectCommand.Parameters.AddWithValue("@Tipo", tipo)
            da.SelectCommand.Parameters.AddWithValue("@Techo", techo)

            Dim dt As New DataTable()
            da.Fill(dt)

            For Each fila As DataRow In dt.Rows

                Dim numero As Integer = Convert.ToInt32(fila("Numero"))
                Dim disponible As Boolean = True

                For i As Integer = 0 To cantidadHoras - 1

                    Dim horaTurno As String =
                        horaInicio.AddHours(i).ToString("HH:mm")

                    Dim sql As String =
                        "SELECT COUNT(*) FROM alquiler " &
                        "WHERE Numero_Cancha=@Numero AND Dia=@Dia " &
                        "AND TIME_FORMAT(Hora,'%H:%i')=@Hora"

                    Dim cmd As New MySqlCommand(sql, cnn)

                    cmd.Parameters.AddWithValue("@Numero", numero)
                    cmd.Parameters.AddWithValue("@Dia", fecha.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@Hora", horaTurno)

                    Dim ocupada As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                    If ocupada > 0 Then
                        disponible = False
                        Exit For
                    End If

                Next

                If disponible Then
                    cmbCancha.Items.Add(numero)
                End If

            Next

            If cmbCancha.Items.Count > 0 Then

                cmbCancha.SelectedIndex = 0

                Dim horaFin As DateTime = horaInicio.AddHours(cantidadHoras)

                Dim caracteristica As String = If(techo = 1, "Techada", "Aire libre")

                MessageBox.Show(
        "¡Disponibilidad encontrada!" & vbCrLf & vbCrLf &
        "Fecha: " & fecha.ToString("dd/MM/yyyy") & vbCrLf &
        "Horario: " & horaInicio.ToString("HH:mm") & " a " & horaFin.ToString("HH:mm") & vbCrLf &
        "Tipo: F" & tipo & " - " & caracteristica & vbCrLf & vbCrLf &
        "Canchas disponibles: " & cmbCancha.Items.Count & vbCrLf &
        "Seleccione una cancha para continuar.",
        "Consulta de disponibilidad",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information)

            Else
                MessageBox.Show("No hay canchas disponibles para esa fecha y horario.",
                    "Sin disponibilidad",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error al buscar disponibilidad: " & ex.Message)

        Finally
            CerrarConexion()
        End Try

    End Sub

    Private Sub CargarCanchas()
        Try
            cmbCancha.Items.Clear()

            If cmbTipo.SelectedIndex = -1 OrElse cmbTecho.SelectedIndex = -1 Then
                Exit Sub
            End If

            Dim tipo As Integer = Convert.ToInt32(cmbTipo.SelectedItem)
            Dim techo As Integer

            If cmbTecho.SelectedItem.ToString() = "Techada" Then
                techo = 1
            Else
                techo = 0
            End If

            AbrirConexion()

            Dim consulta As String =
                "SELECT Numero FROM cancha WHERE Tipo=@Tipo AND Techo=@Techo ORDER BY Numero"

            Dim cmd As New MySqlCommand(consulta, cnn)
            cmd.Parameters.AddWithValue("@Tipo", tipo)
            cmd.Parameters.AddWithValue("@Techo", techo)

            Dim lector As MySqlDataReader = cmd.ExecuteReader()

            While lector.Read()
                cmbCancha.Items.Add(lector("Numero").ToString())
            End While

            lector.Close()

        Catch ex As Exception
            MessageBox.Show("Error al cargar las canchas: " & ex.Message)
        Finally
            CerrarConexion()
        End Try
    End Sub

    Private Sub cmbCancha_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCancha.SelectedIndexChanged

        If cmbCancha.SelectedIndex = -1 OrElse
            cmbTipo.SelectedIndex = -1 OrElse
            cmbLuz.SelectedIndex = -1 Then
            Exit Sub
        End If

        Try
            AbrirConexion()

            Dim tipoCancha As Integer = CInt(cmbTipo.SelectedItem)
            Dim fecha As Date = dtpDia.Value.Date
            Dim hora As DateTime = dtpHora.Value
            Dim cantidadHoras As Integer = CInt(nudHoras.Value)
            Dim usarLuz As Boolean = cmbLuz.SelectedItem.ToString() = "Con luz"
            Dim total As Decimal = 0

            For i As Integer = 0 To cantidadHoras - 1

                Dim fechaHora As DateTime =
                fecha.Add(hora.TimeOfDay).AddHours(i)

                total += ObtenerPrecio(tipoCancha, fechaHora.Date, fechaHora, usarLuz)

            Next

            txtModif_Precio.Text = total.ToString("N2")

        Catch ex As Exception
            MessageBox.Show("Error al calcular el precio: " & ex.Message)

        Finally
            CerrarConexion()
        End Try

    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipo.SelectedIndexChanged
        CargarCanchas()
    End Sub

    Private Sub cmbTecho_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTecho.SelectedIndexChanged
        CargarCanchas()
        ActualizarPrecio()
    End Sub

    Private Sub ActualizarPrecio()
        If cmbCancha.SelectedIndex = -1 OrElse
       cmbTipo.SelectedIndex = -1 Then
            Exit Sub
        End If

        cmbCancha_SelectedIndexChanged(cmbCancha, EventArgs.Empty)
    End Sub

    Private Sub dtpDia_ValueChanged(sender As Object, e As EventArgs) Handles dtpDia.ValueChanged
        ActualizarPrecio()
    End Sub

    Private Sub dtpHora_ValueChanged(sender As Object, e As EventArgs) Handles dtpHora.ValueChanged
        ActualizarPrecio()
    End Sub

    Private Sub nudHoras_ValueChanged(sender As Object, e As EventArgs) Handles nudHoras.ValueChanged
        ActualizarPrecio()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If txtId_Alquiler.Text.Trim() = "" Then
                MessageBox.Show("Seleccioná una reserva para eliminar.")
                Exit Sub
            End If

            Dim idReserva As Integer = CInt(txtId_Alquiler.Text)

            Dim respuesta As DialogResult =
                MessageBox.Show(
                    "¿Estás seguro de que querés eliminar esta reserva?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question)

            If respuesta = DialogResult.No Then
                Exit Sub
            End If

            AbrirConexion()
            Dim sqlFactura As String =
    "SELECT COUNT(*) FROM factura_cabecera WHERE Id_Reserva=@Id"

            Dim cmdFactura As New MySqlCommand(sqlFactura, cnn)
            cmdFactura.Parameters.AddWithValue("@Id", idReserva)

            Dim tieneFactura As Integer =
    Convert.ToInt32(cmdFactura.ExecuteScalar())

            If tieneFactura > 0 Then
                MessageBox.Show("No se puede eliminar esta reserva porque ya tiene una factura asociada.")
                Exit Sub
            End If

            Dim sql As String =
                "DELETE FROM reserva WHERE Id_Reserva = @Id"

            Dim cmd As New MySqlCommand(sql, cnn)
            cmd.Parameters.AddWithValue("@Id", idReserva)

            Dim resultado As Integer = cmd.ExecuteNonQuery()

            If resultado > 0 Then
                CerrarConexion()
                MessageBox.Show("Reserva eliminada correctamente.")

                ListarReservas()
                LimpiarCampos()
                txtId_Alquiler.Clear()
            Else
                MessageBox.Show("No se encontró la reserva seleccionada.")
            End If

        Catch ex As Exception
            MessageBox.Show("Error al eliminar la reserva: " & ex.Message)

        Finally
            CerrarConexion()
        End Try
    End Sub

    Private Sub cmbLuz_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLuz.SelectedIndexChanged
        ActualizarPrecio()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarCampos()

        txtId_Alquiler.Clear()
        cmbCodigo_Cliente.SelectedIndex = -1

        cmbTipo.SelectedIndex = -1
        cmbTecho.SelectedIndex = -1
        cmbCancha.Items.Clear()
        cmbLuz.SelectedIndex = -1

        dtpDia.Value = Date.Today
        dtpHora.Value = Date.Today.AddHours(16)

        nudHoras.Value = 1

        txtModif_Precio.Clear()

        cmbCodigo_Cliente.Focus()
    End Sub

End Class
