<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCanchas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dgvCanchas = New System.Windows.Forms.DataGridView()
        Me.btnListar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.txtTipo = New System.Windows.Forms.TextBox()
        Me.txtPrecioDia = New System.Windows.Forms.TextBox()
        Me.txtPrecioNoche = New System.Windows.Forms.TextBox()
        Me.chkTecho = New System.Windows.Forms.CheckBox()
        Me.chkLuz = New System.Windows.Forms.CheckBox()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.gbF5AireLibre = New System.Windows.Forms.GroupBox()
        Me.lblCantF5Aire = New System.Windows.Forms.Label()
        Me.gbF5Techadas = New System.Windows.Forms.GroupBox()
        Me.lblCantF5Techo = New System.Windows.Forms.Label()
        Me.gbF8AireLibre = New System.Windows.Forms.GroupBox()
        Me.lblCantF8Aire = New System.Windows.Forms.Label()
        Me.gbF8Techadas = New System.Windows.Forms.GroupBox()
        Me.lblCantF8Techo = New System.Windows.Forms.Label()
        Me.btnEliminar = New System.Windows.Forms.Button()
        CType(Me.dgvCanchas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbF5AireLibre.SuspendLayout()
        Me.gbF5Techadas.SuspendLayout()
        Me.gbF8AireLibre.SuspendLayout()
        Me.gbF8Techadas.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvCanchas
        '
        Me.dgvCanchas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCanchas.Location = New System.Drawing.Point(29, 363)
        Me.dgvCanchas.Name = "dgvCanchas"
        Me.dgvCanchas.RowTemplate.Height = 24
        Me.dgvCanchas.Size = New System.Drawing.Size(941, 178)
        Me.dgvCanchas.TabIndex = 7
        '
        'btnListar
        '
        Me.btnListar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnListar.Location = New System.Drawing.Point(488, 29)
        Me.btnListar.Name = "btnListar"
        Me.btnListar.Size = New System.Drawing.Size(121, 58)
        Me.btnListar.TabIndex = 8
        Me.btnListar.Text = "Listar"
        Me.btnListar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Location = New System.Drawing.Point(365, 29)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(104, 58)
        Me.btnAgregar.TabIndex = 9
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 17)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Número"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 17)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Tipo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 17)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Techo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 153)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 17)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Luz"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 193)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 17)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "PrecioDia"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(26, 232)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 17)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "PrecioNoche"
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(167, 29)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(100, 22)
        Me.txtNumero.TabIndex = 16
        '
        'txtTipo
        '
        Me.txtTipo.Location = New System.Drawing.Point(167, 70)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.Size = New System.Drawing.Size(100, 22)
        Me.txtTipo.TabIndex = 17
        '
        'txtPrecioDia
        '
        Me.txtPrecioDia.Location = New System.Drawing.Point(167, 193)
        Me.txtPrecioDia.Name = "txtPrecioDia"
        Me.txtPrecioDia.Size = New System.Drawing.Size(100, 22)
        Me.txtPrecioDia.TabIndex = 20
        '
        'txtPrecioNoche
        '
        Me.txtPrecioNoche.Location = New System.Drawing.Point(167, 232)
        Me.txtPrecioNoche.Name = "txtPrecioNoche"
        Me.txtPrecioNoche.Size = New System.Drawing.Size(100, 22)
        Me.txtPrecioNoche.TabIndex = 21
        '
        'chkTecho
        '
        Me.chkTecho.AutoSize = True
        Me.chkTecho.Location = New System.Drawing.Point(167, 109)
        Me.chkTecho.Name = "chkTecho"
        Me.chkTecho.Size = New System.Drawing.Size(18, 17)
        Me.chkTecho.TabIndex = 22
        Me.chkTecho.UseVisualStyleBackColor = True
        '
        'chkLuz
        '
        Me.chkLuz.AutoSize = True
        Me.chkLuz.Location = New System.Drawing.Point(167, 153)
        Me.chkLuz.Name = "chkLuz"
        Me.chkLuz.Size = New System.Drawing.Size(18, 17)
        Me.chkLuz.TabIndex = 23
        Me.chkLuz.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModificar.Location = New System.Drawing.Point(628, 29)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(136, 58)
        Me.btnModificar.TabIndex = 24
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'gbF5AireLibre
        '
        Me.gbF5AireLibre.Controls.Add(Me.lblCantF5Aire)
        Me.gbF5AireLibre.Location = New System.Drawing.Point(365, 109)
        Me.gbF5AireLibre.Name = "gbF5AireLibre"
        Me.gbF5AireLibre.Size = New System.Drawing.Size(200, 100)
        Me.gbF5AireLibre.TabIndex = 25
        Me.gbF5AireLibre.TabStop = False
        Me.gbF5AireLibre.Text = "* Fútbol 5 - Al Aire Libre"
        '
        'lblCantF5Aire
        '
        Me.lblCantF5Aire.AutoSize = True
        Me.lblCantF5Aire.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantF5Aire.Location = New System.Drawing.Point(7, 22)
        Me.lblCantF5Aire.Name = "lblCantF5Aire"
        Me.lblCantF5Aire.Size = New System.Drawing.Size(120, 29)
        Me.lblCantF5Aire.TabIndex = 0
        Me.lblCantF5Aire.Text = "0 canchas"
        '
        'gbF5Techadas
        '
        Me.gbF5Techadas.Controls.Add(Me.lblCantF5Techo)
        Me.gbF5Techadas.Location = New System.Drawing.Point(667, 109)
        Me.gbF5Techadas.Name = "gbF5Techadas"
        Me.gbF5Techadas.Size = New System.Drawing.Size(200, 100)
        Me.gbF5Techadas.TabIndex = 26
        Me.gbF5Techadas.TabStop = False
        Me.gbF5Techadas.Text = "* Fútbol 5 - Techadas"
        '
        'lblCantF5Techo
        '
        Me.lblCantF5Techo.AutoSize = True
        Me.lblCantF5Techo.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantF5Techo.Location = New System.Drawing.Point(7, 22)
        Me.lblCantF5Techo.Name = "lblCantF5Techo"
        Me.lblCantF5Techo.Size = New System.Drawing.Size(120, 29)
        Me.lblCantF5Techo.TabIndex = 0
        Me.lblCantF5Techo.Text = "0 canchas"
        '
        'gbF8AireLibre
        '
        Me.gbF8AireLibre.Controls.Add(Me.lblCantF8Aire)
        Me.gbF8AireLibre.Location = New System.Drawing.Point(365, 243)
        Me.gbF8AireLibre.Name = "gbF8AireLibre"
        Me.gbF8AireLibre.Size = New System.Drawing.Size(200, 100)
        Me.gbF8AireLibre.TabIndex = 27
        Me.gbF8AireLibre.TabStop = False
        Me.gbF8AireLibre.Text = "* Fútbol 8 - Al Aire Libre"
        '
        'lblCantF8Aire
        '
        Me.lblCantF8Aire.AutoSize = True
        Me.lblCantF8Aire.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantF8Aire.Location = New System.Drawing.Point(7, 22)
        Me.lblCantF8Aire.Name = "lblCantF8Aire"
        Me.lblCantF8Aire.Size = New System.Drawing.Size(120, 29)
        Me.lblCantF8Aire.TabIndex = 0
        Me.lblCantF8Aire.Text = "0 canchas"
        '
        'gbF8Techadas
        '
        Me.gbF8Techadas.Controls.Add(Me.lblCantF8Techo)
        Me.gbF8Techadas.Location = New System.Drawing.Point(656, 243)
        Me.gbF8Techadas.Name = "gbF8Techadas"
        Me.gbF8Techadas.Size = New System.Drawing.Size(200, 100)
        Me.gbF8Techadas.TabIndex = 28
        Me.gbF8Techadas.TabStop = False
        Me.gbF8Techadas.Text = "* Fútbol 8 - Techadas"
        '
        'lblCantF8Techo
        '
        Me.lblCantF8Techo.AutoSize = True
        Me.lblCantF8Techo.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantF8Techo.Location = New System.Drawing.Point(7, 22)
        Me.lblCantF8Techo.Name = "lblCantF8Techo"
        Me.lblCantF8Techo.Size = New System.Drawing.Size(120, 29)
        Me.lblCantF8Techo.TabIndex = 0
        Me.lblCantF8Techo.Text = "0 canchas"
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Location = New System.Drawing.Point(785, 29)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(120, 55)
        Me.btnEliminar.TabIndex = 29
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'FormCanchas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(982, 653)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.gbF8Techadas)
        Me.Controls.Add(Me.gbF8AireLibre)
        Me.Controls.Add(Me.gbF5Techadas)
        Me.Controls.Add(Me.gbF5AireLibre)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.chkLuz)
        Me.Controls.Add(Me.chkTecho)
        Me.Controls.Add(Me.txtPrecioNoche)
        Me.Controls.Add(Me.txtPrecioDia)
        Me.Controls.Add(Me.txtTipo)
        Me.Controls.Add(Me.txtNumero)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnListar)
        Me.Controls.Add(Me.dgvCanchas)
        Me.Name = "FormCanchas"
        Me.Text = "Canchas"
        CType(Me.dgvCanchas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbF5AireLibre.ResumeLayout(False)
        Me.gbF5AireLibre.PerformLayout()
        Me.gbF5Techadas.ResumeLayout(False)
        Me.gbF5Techadas.PerformLayout()
        Me.gbF8AireLibre.ResumeLayout(False)
        Me.gbF8AireLibre.PerformLayout()
        Me.gbF8Techadas.ResumeLayout(False)
        Me.gbF8Techadas.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvCanchas As DataGridView
    Friend WithEvents btnListar As Button
    Friend WithEvents btnAgregar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtNumero As TextBox
    Friend WithEvents txtTipo As TextBox
    Friend WithEvents txtPrecioDia As TextBox
    Friend WithEvents txtPrecioNoche As TextBox
    Friend WithEvents chkTecho As CheckBox
    Friend WithEvents chkLuz As CheckBox
    Friend WithEvents btnModificar As Button
    Friend WithEvents gbF5AireLibre As GroupBox
    Friend WithEvents gbF5Techadas As GroupBox
    Friend WithEvents gbF8AireLibre As GroupBox
    Friend WithEvents gbF8Techadas As GroupBox
    Friend WithEvents lblCantF5Aire As Label
    Friend WithEvents lblCantF5Techo As Label
    Friend WithEvents lblCantF8Aire As Label
    Friend WithEvents lblCantF8Techo As Label
    Friend WithEvents btnEliminar As Button
End Class
