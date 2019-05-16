<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IQ_C0011
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IQ_C0011))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CmdExit = New System.Windows.Forms.Button()
        Me.CmdClean = New System.Windows.Forms.Button()
        Me.CmdNewSearch = New System.Windows.Forms.Button()
        Me.CmdReport = New System.Windows.Forms.Button()
        Me.CmdSearch = New System.Windows.Forms.Button()
        Me.CmdDelete = New System.Windows.Forms.Button()
        Me.CmdModify = New System.Windows.Forms.Button()
        Me.CmdInsert = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.CmbRoles = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GridDatos = New System.Windows.Forms.DataGrid()
        Me.CmbMenus = New System.Windows.Forms.ComboBox()
        Me.ChkModificacion = New System.Windows.Forms.CheckBox()
        Me.ChkBaja = New System.Windows.Forms.CheckBox()
        Me.ChkAlta = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CrvReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Barra_Estado = New System.Windows.Forms.StatusBar()
        Me.Panel_Estado0 = New System.Windows.Forms.StatusBarPanel()
        Me.Panel_Estado1 = New System.Windows.Forms.StatusBarPanel()
        Me.Panel_Estado2 = New System.Windows.Forms.StatusBarPanel()
        Me.Panel_Estado3 = New System.Windows.Forms.StatusBarPanel()
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
        Me.Panel1.Controls.Add(Me.CmdNewSearch)
        Me.Panel1.Controls.Add(Me.CmdReport)
        Me.Panel1.Controls.Add(Me.CmdSearch)
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
        Me.CmdExit.Location = New System.Drawing.Point(280, 0)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(40, 40)
        Me.CmdExit.TabIndex = 13
        Me.CmdExit.UseVisualStyleBackColor = True
        '
        'CmdClean
        '
        Me.CmdClean.Image = Global.IQ_Core.My.Resources.Resources.Limpiar
        Me.CmdClean.Location = New System.Drawing.Point(240, 0)
        Me.CmdClean.Name = "CmdClean"
        Me.CmdClean.Size = New System.Drawing.Size(40, 40)
        Me.CmdClean.TabIndex = 12
        Me.CmdClean.UseVisualStyleBackColor = True
        '
        'CmdNewSearch
        '
        Me.CmdNewSearch.Image = Global.IQ_Core.My.Resources.Resources.NuevaBusqueda
        Me.CmdNewSearch.Location = New System.Drawing.Point(200, 0)
        Me.CmdNewSearch.Name = "CmdNewSearch"
        Me.CmdNewSearch.Size = New System.Drawing.Size(40, 40)
        Me.CmdNewSearch.TabIndex = 11
        Me.CmdNewSearch.UseVisualStyleBackColor = True
        '
        'CmdReport
        '
        Me.CmdReport.Image = Global.IQ_Core.My.Resources.Resources.Reporte
        Me.CmdReport.Location = New System.Drawing.Point(160, 0)
        Me.CmdReport.Name = "CmdReport"
        Me.CmdReport.Size = New System.Drawing.Size(40, 40)
        Me.CmdReport.TabIndex = 10
        Me.CmdReport.UseVisualStyleBackColor = True
        '
        'CmdSearch
        '
        Me.CmdSearch.Image = Global.IQ_Core.My.Resources.Resources.Buscar
        Me.CmdSearch.Location = New System.Drawing.Point(120, 0)
        Me.CmdSearch.Name = "CmdSearch"
        Me.CmdSearch.Size = New System.Drawing.Size(40, 40)
        Me.CmdSearch.TabIndex = 9
        Me.CmdSearch.UseVisualStyleBackColor = True
        '
        'CmdDelete
        '
        Me.CmdDelete.Image = Global.IQ_Core.My.Resources.Resources.Eliminar
        Me.CmdDelete.Location = New System.Drawing.Point(80, 0)
        Me.CmdDelete.Name = "CmdDelete"
        Me.CmdDelete.Size = New System.Drawing.Size(40, 40)
        Me.CmdDelete.TabIndex = 8
        Me.CmdDelete.UseVisualStyleBackColor = True
        '
        'CmdModify
        '
        Me.CmdModify.Image = Global.IQ_Core.My.Resources.Resources.Modificar
        Me.CmdModify.Location = New System.Drawing.Point(40, 0)
        Me.CmdModify.Name = "CmdModify"
        Me.CmdModify.Size = New System.Drawing.Size(40, 40)
        Me.CmdModify.TabIndex = 7
        Me.CmdModify.UseVisualStyleBackColor = True
        '
        'CmdInsert
        '
        Me.CmdInsert.Image = Global.IQ_Core.My.Resources.Resources.Insertar
        Me.CmdInsert.Location = New System.Drawing.Point(0, 0)
        Me.CmdInsert.Name = "CmdInsert"
        Me.CmdInsert.Size = New System.Drawing.Size(40, 40)
        Me.CmdInsert.TabIndex = 6
        Me.CmdInsert.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 10
        '
        'CmbRoles
        '
        Me.CmbRoles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbRoles.ForeColor = System.Drawing.Color.Red
        Me.CmbRoles.Location = New System.Drawing.Point(51, 55)
        Me.CmbRoles.Name = "CmbRoles"
        Me.CmbRoles.Size = New System.Drawing.Size(456, 21)
        Me.CmbRoles.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(11, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 23)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "Rol:"
        '
        'GridDatos
        '
        Me.GridDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDatos.DataMember = ""
        Me.GridDatos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.GridDatos.Location = New System.Drawing.Point(12, 81)
        Me.GridDatos.Name = "GridDatos"
        Me.GridDatos.Size = New System.Drawing.Size(691, 165)
        Me.GridDatos.TabIndex = 1
        '
        'CmbMenus
        '
        Me.CmbMenus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CmbMenus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbMenus.ForeColor = System.Drawing.Color.Red
        Me.CmbMenus.Location = New System.Drawing.Point(103, 252)
        Me.CmbMenus.Name = "CmbMenus"
        Me.CmbMenus.Size = New System.Drawing.Size(404, 21)
        Me.CmbMenus.Sorted = True
        Me.CmbMenus.TabIndex = 2
        '
        'ChkModificacion
        '
        Me.ChkModificacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkModificacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkModificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkModificacion.ForeColor = System.Drawing.Color.Blue
        Me.ChkModificacion.Location = New System.Drawing.Point(12, 325)
        Me.ChkModificacion.Name = "ChkModificacion"
        Me.ChkModificacion.Size = New System.Drawing.Size(180, 32)
        Me.ChkModificacion.TabIndex = 5
        Me.ChkModificacion.Text = "Modificación"
        '
        'ChkBaja
        '
        Me.ChkBaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkBaja.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkBaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkBaja.ForeColor = System.Drawing.Color.Blue
        Me.ChkBaja.Location = New System.Drawing.Point(12, 300)
        Me.ChkBaja.Name = "ChkBaja"
        Me.ChkBaja.Size = New System.Drawing.Size(180, 32)
        Me.ChkBaja.TabIndex = 4
        Me.ChkBaja.Text = "Eliminación"
        '
        'ChkAlta
        '
        Me.ChkAlta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkAlta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkAlta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkAlta.ForeColor = System.Drawing.Color.Blue
        Me.ChkAlta.Location = New System.Drawing.Point(12, 275)
        Me.ChkAlta.Name = "ChkAlta"
        Me.ChkAlta.Size = New System.Drawing.Size(180, 32)
        Me.ChkAlta.TabIndex = 3
        Me.ChkAlta.Text = "Creación (Ejecucion)"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(12, 255)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 23)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Menú:"
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
        Me.CrvReporte.Size = New System.Drawing.Size(691, 311)
        Me.CrvReporte.TabIndex = 536
        '
        'Barra_Estado
        '
        Me.Barra_Estado.Location = New System.Drawing.Point(0, 374)
        Me.Barra_Estado.Name = "Barra_Estado"
        Me.Barra_Estado.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.Panel_Estado0, Me.Panel_Estado1, Me.Panel_Estado2, Me.Panel_Estado3})
        Me.Barra_Estado.ShowPanels = True
        Me.Barra_Estado.Size = New System.Drawing.Size(703, 32)
        Me.Barra_Estado.SizingGrip = False
        Me.Barra_Estado.TabIndex = 537
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
        'CmdRefresh
        '
        Me.CmdRefresh.Image = CType(resources.GetObject("CmdRefresh.Image"), System.Drawing.Image)
        Me.CmdRefresh.Location = New System.Drawing.Point(490, 0)
        Me.CmdRefresh.Name = "CmdRefresh"
        Me.CmdRefresh.Size = New System.Drawing.Size(40, 40)
        Me.CmdRefresh.TabIndex = 535
        Me.CmdRefresh.UseVisualStyleBackColor = True
        '
        'IQ_C0011
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 406)
        Me.Controls.Add(Me.Barra_Estado)
        Me.Controls.Add(Me.CrvReporte)
        Me.Controls.Add(Me.CmbMenus)
        Me.Controls.Add(Me.ChkModificacion)
        Me.Controls.Add(Me.ChkBaja)
        Me.Controls.Add(Me.ChkAlta)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GridDatos)
        Me.Controls.Add(Me.CmbRoles)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.Name = "IQ_C0011"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Permisos"
        Me.Panel1.ResumeLayout(False)
        CType(Me.GridDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Panel_Estado0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Panel_Estado1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Panel_Estado2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Panel_Estado3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CmdExit As System.Windows.Forms.Button
    Friend WithEvents CmdClean As System.Windows.Forms.Button
    Friend WithEvents CmdReport As System.Windows.Forms.Button
    Friend WithEvents CmdSearch As System.Windows.Forms.Button
    Friend WithEvents CmdDelete As System.Windows.Forms.Button
    Friend WithEvents CmdModify As System.Windows.Forms.Button
    Friend WithEvents CmdInsert As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents CmbRoles As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmdNewSearch As System.Windows.Forms.Button
    Friend WithEvents GridDatos As System.Windows.Forms.DataGrid
    Friend WithEvents CmbMenus As System.Windows.Forms.ComboBox
    Friend WithEvents ChkModificacion As System.Windows.Forms.CheckBox
    Friend WithEvents ChkBaja As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAlta As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CrvReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Barra_Estado As System.Windows.Forms.StatusBar
    Friend WithEvents Panel_Estado0 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents Panel_Estado1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents Panel_Estado2 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents Panel_Estado3 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents CmdRefresh As System.Windows.Forms.Button
End Class
