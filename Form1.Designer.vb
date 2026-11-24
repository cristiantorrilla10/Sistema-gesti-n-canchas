<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.btnClientes = New System.Windows.Forms.Button()
        Me.btnCancha = New System.Windows.Forms.Button()
        Me.btnAlquiler = New System.Windows.Forms.Button()
        Me.btnFacturas = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnClientes
        '
        Me.btnClientes.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClientes.Location = New System.Drawing.Point(40, 184)
        Me.btnClientes.Name = "btnClientes"
        Me.btnClientes.Size = New System.Drawing.Size(112, 59)
        Me.btnClientes.TabIndex = 0
        Me.btnClientes.Text = "Clientes"
        Me.btnClientes.UseVisualStyleBackColor = True
        '
        'btnCancha
        '
        Me.btnCancha.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancha.Location = New System.Drawing.Point(327, 184)
        Me.btnCancha.Name = "btnCancha"
        Me.btnCancha.Size = New System.Drawing.Size(133, 59)
        Me.btnCancha.TabIndex = 1
        Me.btnCancha.TabStop = False
        Me.btnCancha.Text = "Canchas"
        Me.btnCancha.UseVisualStyleBackColor = True
        '
        'btnAlquiler
        '
        Me.btnAlquiler.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAlquiler.Location = New System.Drawing.Point(579, 183)
        Me.btnAlquiler.Name = "btnAlquiler"
        Me.btnAlquiler.Size = New System.Drawing.Size(110, 49)
        Me.btnAlquiler.TabIndex = 2
        Me.btnAlquiler.Text = "Alquiler"
        Me.btnAlquiler.UseVisualStyleBackColor = True
        '
        'btnFacturas
        '
        Me.btnFacturas.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFacturas.Location = New System.Drawing.Point(335, 305)
        Me.btnFacturas.Name = "btnFacturas"
        Me.btnFacturas.Size = New System.Drawing.Size(125, 62)
        Me.btnFacturas.TabIndex = 3
        Me.btnFacturas.Text = "Facturas"
        Me.btnFacturas.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(304, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(178, 48)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Canchitas"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnFacturas)
        Me.Controls.Add(Me.btnAlquiler)
        Me.Controls.Add(Me.btnCancha)
        Me.Controls.Add(Me.btnClientes)
        Me.Name = "Form1"
        Me.Text = "Menú Principal"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnClientes As Button
    Friend WithEvents btnCancha As Button
    Friend WithEvents btnAlquiler As Button
    Friend WithEvents btnFacturas As Button
    Friend WithEvents Label1 As Label
End Class
