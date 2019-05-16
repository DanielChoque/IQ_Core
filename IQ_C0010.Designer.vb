<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IQ_C0010
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IQ_C0010))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CmdExit = New System.Windows.Forms.Button()
        Me.CmdClean = New System.Windows.Forms.Button()
        Me.CmdReport = New System.Windows.Forms.Button()
        Me.CmdDelete = New System.Windows.Forms.Button()
        Me.CmdModify = New System.Windows.Forms.Button()
        Me.CmdInsert = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GridDatos = New System.Windows.Forms.DataGrid()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmbMenus = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtToolTip = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtImagen = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtForm = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ChkButton = New System.Windows.Forms.CheckBox()
        Me.CrvReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Barra_Estado = New System.Windows.Forms.StatusBar()
        Me.Panel_Estado0 = New System.Windows.Forms.StatusBarPanel()
        Me.Panel_Estado1 = New System.Windows.Forms.StatusBarPanel()
        Me.Panel_Estado2 = New System.Windows.Forms.StatusBarPanel()
        Me.Panel_Estado3 = New System.Windows.Forms.StatusBarPanel()
        Me.txtParameter = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CmdRefresh = New System.Windows.Forms.Button()
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
        Me.Panel1.Controls.Add(Me.CmdRefresh)
        Me.Panel1.Controls.Add(Me.CmdExit)
        Me.Panel1.Controls.Add(Me.CmdClean)
        Me.Panel1.Controls.Add(Me.CmdReport)
        Me.Panel1.Controls.Add(Me.CmdDelete)
        Me.Panel1.Controls.Add(Me.CmdModify)
        Me.Panel1.Controls.Add(Me.CmdInsert)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(703, 40)
        Me.Panel1.TabIndex = 1
        '
        'CmdExit
        '
        Me.CmdExit.Image = CType(resources.GetObject("CmdExit.Image"), System.Drawing.Image)
        Me.CmdExit.Location = New System.Drawing.Point(200, 0)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(40, 40)
        Me.CmdExit.TabIndex = 13
        Me.CmdExit.UseVisualStyleBackColor = True
        '
        'CmdClean
        '
        Me.CmdClean.Image = Global.IQ_Core.My.Resources.Resources.Limpiar
        Me.CmdClean.Location = New System.Drawing.Point(160, 0)
        Me.CmdClean.Name = "CmdClean"
        Me.CmdClean.Size = New System.Drawing.Size(40, 40)
        Me.CmdClean.TabIndex = 12
        Me.CmdClean.UseVisualStyleBackColor = True
        '
        'CmdReport
        '
        Me.CmdReport.Image = Global.IQ_Core.My.Resources.Resources.Reporte
        Me.CmdReport.Location = New System.Drawing.Point(120, 0)
        Me.CmdReport.Name = "CmdReport"
        Me.CmdReport.Size = New System.Drawing.Size(40, 40)
        Me.CmdReport.TabIndex = 11
        Me.CmdReport.UseVisualStyleBackColor = True
        '
        'CmdDelete
        '
        Me.CmdDelete.Image = Global.IQ_Core.My.Resources.Resources.Eliminar
        Me.CmdDelete.Location = New System.Drawing.Point(80, 0)
        Me.CmdDelete.Name = "CmdDelete"
        Me.CmdDelete.Size = New System.Drawing.Size(40, 40)
        Me.CmdDelete.TabIndex = 10
        Me.CmdDelete.UseVisualStyleBackColor = True
        '
        'CmdModify
        '
        Me.CmdModify.Image = Global.IQ_Core.My.Resources.Resources.Modificar
        Me.CmdModify.Location = New System.Drawing.Point(40, 0)
        Me.CmdModify.Name = "CmdModify"
        Me.CmdModify.Size = New System.Drawing.Size(40, 40)
        Me.CmdModify.TabIndex = 9
        Me.CmdModify.UseVisualStyleBackColor = True
        '
        'CmdInsert
        '
        Me.CmdInsert.Image = Global.IQ_Core.My.Resources.Resources.Insertar
        Me.CmdInsert.Location = New System.Drawing.Point(0, 0)
        Me.CmdInsert.Name = "CmdInsert"
        Me.CmdInsert.Size = New System.Drawing.Size(40, 40)
        Me.CmdInsert.TabIndex = 8
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
        Me.GridDatos.Location = New System.Drawing.Point(1, 40)
        Me.GridDatos.Name = "GridDatos"
        Me.GridDatos.Size = New System.Drawing.Size(700, 145)
        Me.GridDatos.TabIndex = 7
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.AccessibleDescription = "Descripcion del Rol"
        Me.TxtDescripcion.AccessibleName = "Descripcion del Rol"
        Me.TxtDescripcion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtDescripcion.Location = New System.Drawing.Point(100, 217)
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
        Me.Label2.Location = New System.Drawing.Point(10, 217)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 23)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Descripción:"
        '
        'TxtCodigo
        '
        Me.TxtCodigo.AccessibleDescription = "Codigo del Rol"
        Me.TxtCodigo.AccessibleName = "Codigo del Rol"
        Me.TxtCodigo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtCodigo.Location = New System.Drawing.Point(100, 191)
        Me.TxtCodigo.MaxLength = 8
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(131, 20)
        Me.TxtCodigo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(10, 191)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 23)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Código:"
        '
        'CmbMenus
        '
        Me.CmbMenus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CmbMenus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbMenus.ForeColor = System.Drawing.Color.Red
        Me.CmbMenus.Location = New System.Drawing.Point(100, 243)
        Me.CmbMenus.Name = "CmbMenus"
        Me.CmbMenus.Size = New System.Drawing.Size(336, 21)
        Me.CmbMenus.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(10, 243)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 23)
        Me.Label5.TabIndex = 531
        Me.Label5.Text = "Menú:"
        '
        'TxtToolTip
        '
        Me.TxtToolTip.AccessibleDescription = "Codigo del Rol"
        Me.TxtToolTip.AccessibleName = "Codigo del Rol"
        Me.TxtToolTip.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtToolTip.Location = New System.Drawing.Point(100, 270)
        Me.TxtToolTip.MaxLength = 1000
        Me.TxtToolTip.Multiline = True
        Me.TxtToolTip.Name = "TxtToolTip"
        Me.TxtToolTip.Size = New System.Drawing.Size(591, 67)
        Me.TxtToolTip.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(10, 270)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 23)
        Me.Label3.TabIndex = 533
        Me.Label3.Text = "ToolTip:"
        '
        'TxtImagen
        '
        Me.TxtImagen.AccessibleDescription = "Codigo del Rol"
        Me.TxtImagen.AccessibleName = "Codigo del Rol"
        Me.TxtImagen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtImagen.Location = New System.Drawing.Point(100, 343)
        Me.TxtImagen.MaxLength = 30
        Me.TxtImagen.Name = "TxtImagen"
        Me.TxtImagen.Size = New System.Drawing.Size(117, 20)
        Me.TxtImagen.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(10, 343)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 23)
        Me.Label4.TabIndex = 535
        Me.Label4.Text = "Imagen:"
        '
        'TxtForm
        '
        Me.TxtForm.AccessibleDescription = "Codigo del Rol"
        Me.TxtForm.AccessibleName = "Codigo del Rol"
        Me.TxtForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtForm.Location = New System.Drawing.Point(362, 346)
        Me.TxtForm.MaxLength = 30
        Me.TxtForm.Name = "TxtForm"
        Me.TxtForm.Size = New System.Drawing.Size(120, 20)
        Me.TxtForm.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(292, 346)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 23)
        Me.Label6.TabIndex = 537
        Me.Label6.Text = "Formulario:"
        '
        'ChkButton
        '
        Me.ChkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkButton.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ChkButton.ForeColor = System.Drawing.Color.Blue
        Me.ChkButton.Location = New System.Drawing.Point(223, 343)
        Me.ChkButton.Name = "ChkButton"
        Me.ChkButton.Size = New System.Drawing.Size(63, 24)
        Me.ChkButton.TabIndex = 5
        Me.ChkButton.Text = "Botón"
        '
        'CrvReporte
        '
        Me.CrvReporte.ActiveViewIndex = -1
        Me.CrvReporte.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrvReporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrvReporte.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrvReporte.Location = New System.Drawing.Point(12, 46)
        Me.CrvReporte.Name = "CrvReporte"
        Me.CrvReporte.Size = New System.Drawing.Size(691, 320)
        Me.CrvReporte.TabIndex = 538
        '
        'Barra_Estado
        '
        Me.Barra_Estado.Location = New System.Drawing.Point(0, 374)
        Me.Barra_Estado.Name = "Barra_Estado"
        Me.Barra_Estado.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.Panel_Estado0, Me.Panel_Estado1, Me.Panel_Estado2, Me.Panel_Estado3})
        Me.Barra_Estado.ShowPanels = True
        Me.Barra_Estado.Size = New System.Drawing.Size(703, 32)
        Me.Barra_Estado.SizingGrip = False
        Me.Barra_Estado.TabIndex = 539
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
        'txtParameter
        '
        Me.txtParameter.AccessibleDescription = "Codigo del Rol"
        Me.txtParameter.AccessibleName = "Codigo del Rol"
        Me.txtParameter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtParameter.Location = New System.Drawing.Point(560, 347)
        Me.txtParameter.MaxLength = 30
        Me.txtParameter.Name = "txtParameter"
        Me.txtParameter.Size = New System.Drawing.Size(131, 20)
        Me.txtParameter.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(488, 347)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 23)
        Me.Label7.TabIndex = 541
        Me.Label7.Text = "Parámetro:"
        '
        'CmdRefresh
        '
        Me.CmdRefresh.Image = CType(resources.GetObject("CmdRefresh.Image"), System.Drawing.Image)
        Me.CmdRefresh.Location = New System.Drawing.Point(418, 0)
        Me.CmdRefresh.Name = "CmdRefresh"
        Me.CmdRefresh.Size = New System.Drawing.Size(40, 40)
        Me.CmdRefresh.TabIndex = 535
        Me.CmdRefresh.UseVisualStyleBackColor = True
        '
        'IQ_C0010
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 406)
        Me.Controls.Add(Me.CrvReporte)
        Me.Controls.Add(Me.txtParameter)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Barra_Estado)
        Me.Controls.Add(Me.ChkButton)
        Me.Controls.Add(Me.TxtForm)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtImagen)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtToolTip)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CmbMenus)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtDescripcion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtCodigo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GridDatos)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.Name = "IQ_C0010"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Menús"
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
    Friend WithEvents CmdReport As System.Windows.Forms.Button
    Friend WithEvents CmdDelete As System.Windows.Forms.Button
    Friend WithEvents CmdModify As System.Windows.Forms.Button
    Friend WithEvents CmdInsert As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GridDatos As System.Windows.Forms.DataGrid
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbMenus As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtToolTip As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtImagen As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtForm As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ChkButton As System.Windows.Forms.CheckBox
    Friend WithEvents CrvReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Barra_Estado As System.Windows.Forms.StatusBar
    Friend WithEvents Panel_Estado0 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents Panel_Estado1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents Panel_Estado2 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents Panel_Estado3 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents txtParameter As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CmdRefresh As System.Windows.Forms.Button
End Class
