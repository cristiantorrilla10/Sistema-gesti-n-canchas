<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAlquiler
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.lblCodigoCliente = New System.Windows.Forms.Label()
        Me.lblPrecio = New System.Windows.Forms.Label()
        Me.dgvAlquiler = New System.Windows.Forms.DataGridView()
        Me.txtModif_Precio = New System.Windows.Forms.TextBox()
        Me.btnListar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.dtpDia = New System.Windows.Forms.DateTimePicker()
        Me.dtpHora = New System.Windows.Forms.DateTimePicker()
        Me.lblIdAlquiler = New System.Windows.Forms.Label()
        Me.txtId_Alquiler = New System.Windows.Forms.TextBox()
        Me.nudHoras = New System.Windows.Forms.NumericUpDown()
        Me.lblHoras = New System.Windows.Forms.Label()
        Me.btnDisponibilidad = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.lblDia = New System.Windows.Forms.Label()
        Me.lblHora = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.lblCaracteristica = New System.Windows.Forms.Label()
        Me.cmbTecho = New System.Windows.Forms.ComboBox()
        Me.lblDisponible = New System.Windows.Forms.Label()
        Me.cmbCancha = New System.Windows.Forms.ComboBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.lblIluminacion = New System.Windows.Forms.Label()
        Me.cmbLuz = New System.Windows.Forms.ComboBox()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.cmbCodigo_Cliente = New System.Windows.Forms.ComboBox()
        CType(Me.dgvAlquiler, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudHoras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(176, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 17)
        Me.Label1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(176, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 17)
        Me.Label2.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(176, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 17)
        Me.Label3.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(176, 207)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 17)
        Me.Label4.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(176, 277)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 17)
        Me.Label5.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(242, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(0, 17)
        Me.Label6.TabIndex = 12
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Location = New System.Drawing.Point(12, 111)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(36, 17)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Tipo"
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.Location = New System.Drawing.Point(12, 70)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(103, 17)
        Me.lblCodigoCliente.TabIndex = 16
        Me.lblCodigoCliente.Text = "Codigo_Cliente"
        '
        'lblPrecio
        '
        Me.lblPrecio.AutoSize = True
        Me.lblPrecio.Location = New System.Drawing.Point(9, 365)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(48, 17)
        Me.lblPrecio.TabIndex = 17
        Me.lblPrecio.Text = "Precio"
        '
        'dgvAlquiler
        '
        Me.dgvAlquiler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvAlquiler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAlquiler.Location = New System.Drawing.Point(12, 388)
        Me.dgvAlquiler.MultiSelect = False
        Me.dgvAlquiler.Name = "dgvAlquiler"
        Me.dgvAlquiler.ReadOnly = True
        Me.dgvAlquiler.RowTemplate.Height = 24
        Me.dgvAlquiler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAlquiler.Size = New System.Drawing.Size(1348, 144)
        Me.dgvAlquiler.TabIndex = 24
        '
        'txtModif_Precio
        '
        Me.txtModif_Precio.Location = New System.Drawing.Point(167, 360)
        Me.txtModif_Precio.Name = "txtModif_Precio"
        Me.txtModif_Precio.Size = New System.Drawing.Size(100, 22)
        Me.txtModif_Precio.TabIndex = 29
        '
        'btnListar
        '
        Me.btnListar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnListar.Location = New System.Drawing.Point(430, 27)
        Me.btnListar.Name = "btnListar"
        Me.btnListar.Size = New System.Drawing.Size(95, 60)
        Me.btnListar.TabIndex = 30
        Me.btnListar.Text = "Listar"
        Me.btnListar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Location = New System.Drawing.Point(313, 26)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(111, 58)
        Me.btnAgregar.TabIndex = 31
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'dtpDia
        '
        Me.dtpDia.CustomFormat = "dd/MM/yyyy"
        Me.dtpDia.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDia.Location = New System.Drawing.Point(160, 259)
        Me.dtpDia.Name = "dtpDia"
        Me.dtpDia.Size = New System.Drawing.Size(120, 22)
        Me.dtpDia.TabIndex = 32
        '
        'dtpHora
        '
        Me.dtpHora.CustomFormat = "HH:mm"
        Me.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHora.Location = New System.Drawing.Point(160, 291)
        Me.dtpHora.Name = "dtpHora"
        Me.dtpHora.ShowUpDown = True
        Me.dtpHora.Size = New System.Drawing.Size(121, 22)
        Me.dtpHora.TabIndex = 33
        '
        'lblIdAlquiler
        '
        Me.lblIdAlquiler.AutoSize = True
        Me.lblIdAlquiler.Enabled = False
        Me.lblIdAlquiler.Location = New System.Drawing.Point(15, 32)
        Me.lblIdAlquiler.Name = "lblIdAlquiler"
        Me.lblIdAlquiler.Size = New System.Drawing.Size(74, 17)
        Me.lblIdAlquiler.TabIndex = 34
        Me.lblIdAlquiler.Text = "Id_Alquiler"
        '
        'txtId_Alquiler
        '
        Me.txtId_Alquiler.Enabled = False
        Me.txtId_Alquiler.Location = New System.Drawing.Point(167, 26)
        Me.txtId_Alquiler.Name = "txtId_Alquiler"
        Me.txtId_Alquiler.ReadOnly = True
        Me.txtId_Alquiler.Size = New System.Drawing.Size(100, 22)
        Me.txtId_Alquiler.TabIndex = 35
        '
        'nudHoras
        '
        Me.nudHoras.Location = New System.Drawing.Point(163, 324)
        Me.nudHoras.Maximum = New Decimal(New Integer() {6, 0, 0, 0})
        Me.nudHoras.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudHoras.Name = "nudHoras"
        Me.nudHoras.Size = New System.Drawing.Size(120, 22)
        Me.nudHoras.TabIndex = 36
        Me.nudHoras.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblHoras
        '
        Me.lblHoras.AutoSize = True
        Me.lblHoras.Location = New System.Drawing.Point(9, 329)
        Me.lblHoras.Name = "lblHoras"
        Me.lblHoras.Size = New System.Drawing.Size(126, 17)
        Me.lblHoras.TabIndex = 37
        Me.lblHoras.Text = "Cantidad de Horas"
        '
        'btnDisponibilidad
        '
        Me.btnDisponibilidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDisponibilidad.Location = New System.Drawing.Point(531, 27)
        Me.btnDisponibilidad.Name = "btnDisponibilidad"
        Me.btnDisponibilidad.Size = New System.Drawing.Size(154, 56)
        Me.btnDisponibilidad.TabIndex = 38
        Me.btnDisponibilidad.Text = "Disponibilidad"
        Me.btnDisponibilidad.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModificar.Location = New System.Drawing.Point(691, 32)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(97, 52)
        Me.btnModificar.TabIndex = 39
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'lblDia
        '
        Me.lblDia.AutoSize = True
        Me.lblDia.Location = New System.Drawing.Point(9, 259)
        Me.lblDia.Name = "lblDia"
        Me.lblDia.Size = New System.Drawing.Size(29, 17)
        Me.lblDia.TabIndex = 40
        Me.lblDia.Text = "Día"
        '
        'lblHora
        '
        Me.lblHora.AutoSize = True
        Me.lblHora.Location = New System.Drawing.Point(9, 291)
        Me.lblHora.Name = "lblHora"
        Me.lblHora.Size = New System.Drawing.Size(39, 17)
        Me.lblHora.TabIndex = 41
        Me.lblHora.Text = "Hora"
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Items.AddRange(New Object() {"5 ", "8"})
        Me.cmbTipo.Location = New System.Drawing.Point(159, 104)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(121, 24)
        Me.cmbTipo.TabIndex = 42
        '
        'lblCaracteristica
        '
        Me.lblCaracteristica.AutoSize = True
        Me.lblCaracteristica.Location = New System.Drawing.Point(9, 148)
        Me.lblCaracteristica.Name = "lblCaracteristica"
        Me.lblCaracteristica.Size = New System.Drawing.Size(94, 17)
        Me.lblCaracteristica.TabIndex = 43
        Me.lblCaracteristica.Text = "Caracteristica"
        '
        'cmbTecho
        '
        Me.cmbTecho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTecho.FormattingEnabled = True
        Me.cmbTecho.Items.AddRange(New Object() {"Al aire libre", "Techada"})
        Me.cmbTecho.Location = New System.Drawing.Point(159, 141)
        Me.cmbTecho.Name = "cmbTecho"
        Me.cmbTecho.Size = New System.Drawing.Size(121, 24)
        Me.cmbTecho.TabIndex = 44
        '
        'lblDisponible
        '
        Me.lblDisponible.AutoSize = True
        Me.lblDisponible.Location = New System.Drawing.Point(9, 219)
        Me.lblDisponible.Name = "lblDisponible"
        Me.lblDisponible.Size = New System.Drawing.Size(124, 17)
        Me.lblDisponible.TabIndex = 45
        Me.lblDisponible.Text = "Cancha disponible"
        '
        'cmbCancha
        '
        Me.cmbCancha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCancha.FormattingEnabled = True
        Me.cmbCancha.Location = New System.Drawing.Point(162, 212)
        Me.cmbCancha.Name = "cmbCancha"
        Me.cmbCancha.Size = New System.Drawing.Size(121, 24)
        Me.cmbCancha.TabIndex = 46
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.Color.Red
        Me.btnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Location = New System.Drawing.Point(808, 32)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(97, 51)
        Me.btnEliminar.TabIndex = 47
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'lblIluminacion
        '
        Me.lblIluminacion.AutoSize = True
        Me.lblIluminacion.Location = New System.Drawing.Point(9, 183)
        Me.lblIluminacion.Name = "lblIluminacion"
        Me.lblIluminacion.Size = New System.Drawing.Size(78, 17)
        Me.lblIluminacion.TabIndex = 48
        Me.lblIluminacion.Text = "Iluminación"
        '
        'cmbLuz
        '
        Me.cmbLuz.FormattingEnabled = True
        Me.cmbLuz.Location = New System.Drawing.Point(160, 176)
        Me.cmbLuz.Name = "cmbLuz"
        Me.cmbLuz.Size = New System.Drawing.Size(121, 24)
        Me.cmbLuz.TabIndex = 49
        '
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Location = New System.Drawing.Point(313, 132)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(111, 48)
        Me.btnNuevo.TabIndex = 50
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'cmbCodigo_Cliente
        '
        Me.cmbCodigo_Cliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCodigo_Cliente.FormattingEnabled = True
        Me.cmbCodigo_Cliente.Location = New System.Drawing.Point(159, 70)
        Me.cmbCodigo_Cliente.Name = "cmbCodigo_Cliente"
        Me.cmbCodigo_Cliente.Size = New System.Drawing.Size(121, 24)
        Me.cmbCodigo_Cliente.TabIndex = 51
        '
        'FormAlquiler
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1371, 553)
        Me.Controls.Add(Me.cmbCodigo_Cliente)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.cmbLuz)
        Me.Controls.Add(Me.lblIluminacion)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.cmbCancha)
        Me.Controls.Add(Me.lblDisponible)
        Me.Controls.Add(Me.cmbTecho)
        Me.Controls.Add(Me.lblCaracteristica)
        Me.Controls.Add(Me.cmbTipo)
        Me.Controls.Add(Me.lblHora)
        Me.Controls.Add(Me.lblDia)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnDisponibilidad)
        Me.Controls.Add(Me.lblHoras)
        Me.Controls.Add(Me.nudHoras)
        Me.Controls.Add(Me.txtId_Alquiler)
        Me.Controls.Add(Me.lblIdAlquiler)
        Me.Controls.Add(Me.dtpHora)
        Me.Controls.Add(Me.dtpDia)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnListar)
        Me.Controls.Add(Me.txtModif_Precio)
        Me.Controls.Add(Me.dgvAlquiler)
        Me.Controls.Add(Me.lblPrecio)
        Me.Controls.Add(Me.lblCodigoCliente)
        Me.Controls.Add(Me.lblTipo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormAlquiler"
        Me.Text = "Alquiler"
        CType(Me.dgvAlquiler, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudHoras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblTipo As Label
    Friend WithEvents lblCodigoCliente As Label
    Friend WithEvents lblPrecio As Label
    Friend WithEvents dgvAlquiler As DataGridView
    Friend WithEvents txtModif_Precio As TextBox
    Friend WithEvents btnListar As Button
    Friend WithEvents btnAgregar As Button
    Friend WithEvents dtpDia As DateTimePicker
    Friend WithEvents dtpHora As DateTimePicker
    Friend WithEvents lblIdAlquiler As Label
    Friend WithEvents txtId_Alquiler As TextBox
    Friend WithEvents nudHoras As NumericUpDown
    Friend WithEvents lblHoras As Label
    Friend WithEvents btnDisponibilidad As Button
    Friend WithEvents btnModificar As Button
    Friend WithEvents lblDia As Label
    Friend WithEvents lblHora As Label
    Friend WithEvents cmbTipo As ComboBox
    Friend WithEvents lblCaracteristica As Label
    Friend WithEvents cmbTecho As ComboBox
    Friend WithEvents lblDisponible As Label
    Friend WithEvents cmbCancha As ComboBox
    Friend WithEvents btnEliminar As Button
    Friend WithEvents lblIluminacion As Label
    Friend WithEvents cmbLuz As ComboBox
    Friend WithEvents btnNuevo As Button
    Friend WithEvents cmbCodigo_Cliente As ComboBox
End Class
