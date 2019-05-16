<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IQ_C0024
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IQ_C0024))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CmdExit = New System.Windows.Forms.Button()
        Me.CmdClean = New System.Windows.Forms.Button()
        Me.CmdDelete = New System.Windows.Forms.Button()
        Me.CmdModify = New System.Windows.Forms.Button()
        Me.CmdInsert = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GridDatos = New System.Windows.Forms.DataGrid()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Barra_Estado = New System.Windows.Forms.StatusBar()
        Me.Panel_Estado0 = New System.Windows.Forms.StatusBarPanel()
        Me.Panel_Estado1 = New System.Windows.Forms.StatusBarPanel()
        Me.Panel_Estado2 = New System.Windows.Forms.StatusBarPanel()
        Me.Panel_Estado3 = New System.Windows.Forms.StatusBarPanel()
        Me.LblArea = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.GridDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Panel_Estado0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Panel_Estado1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Panel_Estado2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Panel_Estado3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CmdExit)
        Me.Panel1.Controls.Add(Me.CmdClean)
        Me.Panel1.Controls.Add(Me.CmdDelete)
        Me.Panel1.Controls.Add(Me.CmdModify)
        Me.Panel1.Controls.Add(Me.CmdInsert)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(735, 40)
        Me.Panel1.TabIndex = 1
        '
        'CmdExit
        '
        Me.CmdExit.Image = CType(resources.GetObject("CmdExit.Image"), System.Drawing.Image)
        Me.CmdExit.Location = New System.Drawing.Point(160, 0)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(40, 40)
        Me.CmdExit.TabIndex = 9
        Me.CmdExit.UseVisualStyleBackColor = True
        '
        'CmdClean
        '
        Me.CmdClean.Image = Global.IQ_Core.My.Resources.Resources.Limpiar
        Me.CmdClean.Location = New System.Drawing.Point(120, 0)
        Me.CmdClean.Name = "CmdClean"
        Me.CmdClean.Size = New System.Drawing.Size(40, 40)
        Me.CmdClean.TabIndex = 8
        Me.CmdClean.UseVisualStyleBackColor = True
        '
        'CmdDelete
        '
        Me.CmdDelete.Image = Global.IQ_Core.My.Resources.Resources.Eliminar
        Me.CmdDelete.Location = New System.Drawing.Point(80, 0)
        Me.CmdDelete.Name = "CmdDelete"
        Me.CmdDelete.Size = New System.Drawing.Size(40, 40)
        Me.CmdDelete.TabIndex = 6
        Me.CmdDelete.UseVisualStyleBackColor = True
        '
        'CmdModify
        '
        Me.CmdModify.Image = Global.IQ_Core.My.Resources.Resources.Modificar
        Me.CmdModify.Location = New System.Drawing.Point(40, 0)
        Me.CmdModify.Name = "CmdModify"
        Me.CmdModify.Size = New System.Drawing.Size(40, 40)
        Me.CmdModify.TabIndex = 5
        Me.CmdModify.UseVisualStyleBackColor = True
        '
        'CmdInsert
        '
        Me.CmdInsert.Image = Global.IQ_Core.My.Resources.Resources.Insertar
        Me.CmdInsert.Location = New System.Drawing.Point(0, 0)
        Me.CmdInsert.Name = "CmdInsert"
        Me.CmdInsert.Size = New System.Drawing.Size(40, 40)
        Me.CmdInsert.TabIndex = 4
        Me.CmdInsert.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 10
        '
        'GridDatos
        '
        Me.GridDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDatos.DataMember = ""
        Me.GridDatos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.GridDatos.Location = New System.Drawing.Point(1, 70)
        Me.GridDatos.Name = "GridDatos"
        Me.GridDatos.Size = New System.Drawing.Size(732, 322)
        Me.GridDatos.TabIndex = 3
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.AccessibleDescription = "Descripcion del Rol"
        Me.TxtDescripcion.AccessibleName = "Descripcion del Rol"
        Me.TxtDescripcion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtDescripcion.Location = New System.Drawing.Point(137, 398)
        Me.TxtDescripcion.MaxLength = 100
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(760, 20)
        Me.TxtDescripcion.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(0, 395)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 23)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Descripción:"
        '
        'Barra_Estado
        '
        Me.Barra_Estado.Location = New System.Drawing.Point(0, 424)
        Me.Barra_Estado.Name = "Barra_Estado"
        Me.Barra_Estado.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.Panel_Estado0, Me.Panel_Estado1, Me.Panel_Estado2, Me.Panel_Estado3})
        Me.Barra_Estado.ShowPanels = True
        Me.Barra_Estado.Size = New System.Drawing.Size(735, 32)
        Me.Barra_Estado.SizingGrip = False
        Me.Barra_Estado.TabIndex = 532
        '
        'Panel_Estado0
        '
        Me.Panel_Estado0.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.Panel_Estado0.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
        Me.Panel_Estado0.Name = "Panel_Estado0"
        Me.Panel_Estado0.Width = 10
        '
        'Panel_Estado1
        '
        Me.Panel_Estado1.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.Panel_Estado1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
        Me.Panel_Estado1.Name = "Panel_Estado1"
        Me.Panel_Estado1.Width = 10
        '
        'Panel_Estado2
        '
        Me.Panel_Estado2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.Panel_Estado2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
        Me.Panel_Estado2.Name = "Panel_Estado2"
        Me.Panel_Estado2.Width = 10
        '
        'Panel_Estado3
        '
        Me.Panel_Estado3.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.Panel_Estado3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
        Me.Panel_Estado3.Name = "Panel_Estado3"
        Me.Panel_Estado3.Width = 10
        '
        'LblArea
        '
        Me.LblArea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblArea.BackColor = System.Drawing.Color.White
        Me.LblArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblArea.ForeColor = System.Drawing.Color.Red
        Me.LblArea.Location = New System.Drawing.Point(-1, 43)
        Me.LblArea.Name = "LblArea"
        Me.LblArea.Size = New System.Drawing.Size(736, 24)
        Me.LblArea.TabIndex = 533
        Me.LblArea.Text = "AREAS DE ATENCION"
        Me.LblArea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'IQ_C0024
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(735, 456)
        Me.Controls.Add(Me.LblArea)
        Me.Controls.Add(Me.Barra_Estado)
        Me.Controls.Add(Me.TxtDescripcion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GridDatos)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.Name = "IQ_C0024"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Tipos de Tramite"
        Me.Panel1.ResumeLayout(False)
        CType(Me.GridDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Panel_Estado0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Panel_Estado1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Panel_Estado2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Panel_Estado3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CmdExit As System.Windows.Forms.Button
    Friend WithEvents CmdClean As System.Windows.Forms.Button
    Friend WithEvents CmdDelete As System.Windows.Forms.Button
    Friend WithEvents CmdModify As System.Windows.Forms.Button
    Friend WithEvents CmdInsert As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GridDatos As System.Windows.Forms.DataGrid
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Barra_Estado As System.Windows.Forms.StatusBar
    Friend WithEvents Panel_Estado0 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents Panel_Estado1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents Panel_Estado2 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents Panel_Estado3 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents LblArea As System.Windows.Forms.Label
End Class
