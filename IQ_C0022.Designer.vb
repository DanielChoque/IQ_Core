<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IQ_C0022
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IQ_C0022))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CmdExit = New System.Windows.Forms.Button()
        Me.CmdExec = New System.Windows.Forms.Button()
        Me.CmdClean = New System.Windows.Forms.Button()
        Me.CmdPrint = New System.Windows.Forms.Button()
        Me.LblAplicacion = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TrvOficinas = New System.Windows.Forms.TreeView()
        Me.Barra_Estado = New System.Windows.Forms.StatusBar()
        Me.Panel_Estado0 = New System.Windows.Forms.StatusBarPanel()
        Me.Panel_Estado1 = New System.Windows.Forms.StatusBarPanel()
        Me.Panel_Estado2 = New System.Windows.Forms.StatusBarPanel()
        Me.Panel_Estado3 = New System.Windows.Forms.StatusBarPanel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.RbDownload = New System.Windows.Forms.RadioButton()
        Me.RbUpload = New System.Windows.Forms.RadioButton()
        Me.PnlDownload = New System.Windows.Forms.Panel()
        Me.Chk17 = New System.Windows.Forms.CheckBox()
        Me.Chk16 = New System.Windows.Forms.CheckBox()
        Me.Chk15 = New System.Windows.Forms.CheckBox()
        Me.Chk14 = New System.Windows.Forms.CheckBox()
        Me.Chk13 = New System.Windows.Forms.CheckBox()
        Me.Chk12 = New System.Windows.Forms.CheckBox()
        Me.Chk11 = New System.Windows.Forms.CheckBox()
        Me.Chk10 = New System.Windows.Forms.CheckBox()
        Me.Chk9 = New System.Windows.Forms.CheckBox()
        Me.Chk8 = New System.Windows.Forms.CheckBox()
        Me.Chk7 = New System.Windows.Forms.CheckBox()
        Me.Chk6 = New System.Windows.Forms.CheckBox()
        Me.Chk5 = New System.Windows.Forms.CheckBox()
        Me.Chk4 = New System.Windows.Forms.CheckBox()
        Me.Chk3 = New System.Windows.Forms.CheckBox()
        Me.Chk2 = New System.Windows.Forms.CheckBox()
        Me.Chk1 = New System.Windows.Forms.CheckBox()
        Me.PnlUpload = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DtHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtDesde = New System.Windows.Forms.DateTimePicker()
        Me.CrvReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Panel1.SuspendLayout()
        CType(Me.Panel_Estado0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Panel_Estado1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Panel_Estado2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Panel_Estado3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDownload.SuspendLayout()
        Me.PnlUpload.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CmdExit)
        Me.Panel1.Controls.Add(Me.CmdExec)
        Me.Panel1.Controls.Add(Me.CmdClean)
        Me.Panel1.Controls.Add(Me.CmdPrint)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1169, 40)
        Me.Panel1.TabIndex = 2
        '
        'CmdExit
        '
        Me.CmdExit.Image = CType(resources.GetObject("CmdExit.Image"), System.Drawing.Image)
        Me.CmdExit.Location = New System.Drawing.Point(120, 0)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(40, 40)
        Me.CmdExit.TabIndex = 8
        Me.CmdExit.UseVisualStyleBackColor = True
        '
        'CmdExec
        '
        Me.CmdExec.Image = Global.IQ_Core.My.Resources.Resources.Ejecutar
        Me.CmdExec.Location = New System.Drawing.Point(80, 0)
        Me.CmdExec.Name = "CmdExec"
        Me.CmdExec.Size = New System.Drawing.Size(40, 40)
        Me.CmdExec.TabIndex = 7
        Me.CmdExec.UseVisualStyleBackColor = True
        '
        'CmdClean
        '
        Me.CmdClean.Image = Global.IQ_Core.My.Resources.Resources.Limpiar
        Me.CmdClean.Location = New System.Drawing.Point(40, 0)
        Me.CmdClean.Name = "CmdClean"
        Me.CmdClean.Size = New System.Drawing.Size(40, 40)
        Me.CmdClean.TabIndex = 6
        Me.CmdClean.UseVisualStyleBackColor = True
        '
        'CmdPrint
        '
        Me.CmdPrint.Image = Global.IQ_Core.My.Resources.Resources.Reporte
        Me.CmdPrint.Location = New System.Drawing.Point(0, 0)
        Me.CmdPrint.Name = "CmdPrint"
        Me.CmdPrint.Size = New System.Drawing.Size(40, 40)
        Me.CmdPrint.TabIndex = 3
        Me.CmdPrint.UseVisualStyleBackColor = True
        '
        'LblAplicacion
        '
        Me.LblAplicacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblAplicacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblAplicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAplicacion.Location = New System.Drawing.Point(12, 65)
        Me.LblAplicacion.Name = "LblAplicacion"
        Me.LblAplicacion.Size = New System.Drawing.Size(311, 23)
        Me.LblAplicacion.TabIndex = 50
        Me.LblAplicacion.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(11, 47)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 23)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "Alcance:"
        '
        'TrvOficinas
        '
        Me.TrvOficinas.Location = New System.Drawing.Point(12, 91)
        Me.TrvOficinas.Name = "TrvOficinas"
        Me.TrvOficinas.Size = New System.Drawing.Size(311, 335)
        Me.TrvOficinas.TabIndex = 0
        '
        'Barra_Estado
        '
        Me.Barra_Estado.Location = New System.Drawing.Point(0, 631)
        Me.Barra_Estado.Name = "Barra_Estado"
        Me.Barra_Estado.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.Panel_Estado0, Me.Panel_Estado1, Me.Panel_Estado2, Me.Panel_Estado3})
        Me.Barra_Estado.ShowPanels = True
        Me.Barra_Estado.Size = New System.Drawing.Size(1169, 32)
        Me.Barra_Estado.TabIndex = 51
        Me.Barra_Estado.Text = "StatusBar1"
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
        'Timer1
        '
        '
        'RbDownload
        '
        Me.RbDownload.AutoSize = True
        Me.RbDownload.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RbDownload.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RbDownload.ForeColor = System.Drawing.Color.Blue
        Me.RbDownload.Location = New System.Drawing.Point(497, 47)
        Me.RbDownload.Name = "RbDownload"
        Me.RbDownload.Size = New System.Drawing.Size(81, 17)
        Me.RbDownload.TabIndex = 1
        Me.RbDownload.TabStop = True
        Me.RbDownload.Text = "Download"
        Me.RbDownload.UseVisualStyleBackColor = True
        '
        'RbUpload
        '
        Me.RbUpload.AutoSize = True
        Me.RbUpload.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RbUpload.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RbUpload.ForeColor = System.Drawing.Color.Blue
        Me.RbUpload.Location = New System.Drawing.Point(937, 45)
        Me.RbUpload.Name = "RbUpload"
        Me.RbUpload.Size = New System.Drawing.Size(65, 17)
        Me.RbUpload.TabIndex = 2
        Me.RbUpload.TabStop = True
        Me.RbUpload.Text = "Upload"
        Me.RbUpload.UseVisualStyleBackColor = True
        '
        'PnlDownload
        '
        Me.PnlDownload.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PnlDownload.Controls.Add(Me.Chk17)
        Me.PnlDownload.Controls.Add(Me.Chk16)
        Me.PnlDownload.Controls.Add(Me.Chk15)
        Me.PnlDownload.Controls.Add(Me.Chk14)
        Me.PnlDownload.Controls.Add(Me.Chk13)
        Me.PnlDownload.Controls.Add(Me.Chk12)
        Me.PnlDownload.Controls.Add(Me.Chk11)
        Me.PnlDownload.Controls.Add(Me.Chk10)
        Me.PnlDownload.Controls.Add(Me.Chk9)
        Me.PnlDownload.Controls.Add(Me.Chk8)
        Me.PnlDownload.Controls.Add(Me.Chk7)
        Me.PnlDownload.Controls.Add(Me.Chk6)
        Me.PnlDownload.Controls.Add(Me.Chk5)
        Me.PnlDownload.Controls.Add(Me.Chk4)
        Me.PnlDownload.Controls.Add(Me.Chk3)
        Me.PnlDownload.Controls.Add(Me.Chk2)
        Me.PnlDownload.Controls.Add(Me.Chk1)
        Me.PnlDownload.Location = New System.Drawing.Point(337, 65)
        Me.PnlDownload.Name = "PnlDownload"
        Me.PnlDownload.Size = New System.Drawing.Size(405, 407)
        Me.PnlDownload.TabIndex = 54
        '
        'Chk17
        '
        Me.Chk17.AutoSize = True
        Me.Chk17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Chk17.ForeColor = System.Drawing.Color.Blue
        Me.Chk17.Location = New System.Drawing.Point(12, 383)
        Me.Chk17.Name = "Chk17"
        Me.Chk17.Size = New System.Drawing.Size(133, 17)
        Me.Chk17.TabIndex = 19
        Me.Chk17.Text = "Cupos de Atenciòn"
        Me.Chk17.UseVisualStyleBackColor = True
        '
        'Chk16
        '
        Me.Chk16.AutoSize = True
        Me.Chk16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Chk16.ForeColor = System.Drawing.Color.Blue
        Me.Chk16.Location = New System.Drawing.Point(12, 360)
        Me.Chk16.Name = "Chk16"
        Me.Chk16.Size = New System.Drawing.Size(158, 17)
        Me.Chk16.TabIndex = 18
        Me.Chk16.Text = "Capacidad de Atenciòn"
        Me.Chk16.UseVisualStyleBackColor = True
        '
        'Chk15
        '
        Me.Chk15.AutoSize = True
        Me.Chk15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Chk15.ForeColor = System.Drawing.Color.Blue
        Me.Chk15.Location = New System.Drawing.Point(12, 337)
        Me.Chk15.Name = "Chk15"
        Me.Chk15.Size = New System.Drawing.Size(121, 17)
        Me.Chk15.TabIndex = 17
        Me.Chk15.Text = "Tipos de Tràmite"
        Me.Chk15.UseVisualStyleBackColor = True
        '
        'Chk14
        '
        Me.Chk14.AutoSize = True
        Me.Chk14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Chk14.ForeColor = System.Drawing.Color.Blue
        Me.Chk14.Location = New System.Drawing.Point(12, 314)
        Me.Chk14.Name = "Chk14"
        Me.Chk14.Size = New System.Drawing.Size(168, 17)
        Me.Chk14.TabIndex = 16
        Me.Chk14.Text = "Configuración Multimedia"
        Me.Chk14.UseVisualStyleBackColor = True
        '
        'Chk13
        '
        Me.Chk13.AutoSize = True
        Me.Chk13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Chk13.ForeColor = System.Drawing.Color.Blue
        Me.Chk13.Location = New System.Drawing.Point(12, 291)
        Me.Chk13.Name = "Chk13"
        Me.Chk13.Size = New System.Drawing.Size(129, 17)
        Me.Chk13.TabIndex = 15
        Me.Chk13.Text = "Diseño de Tickets"
        Me.Chk13.UseVisualStyleBackColor = True
        '
        'Chk12
        '
        Me.Chk12.AutoSize = True
        Me.Chk12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Chk12.ForeColor = System.Drawing.Color.Blue
        Me.Chk12.Location = New System.Drawing.Point(12, 268)
        Me.Chk12.Name = "Chk12"
        Me.Chk12.Size = New System.Drawing.Size(213, 17)
        Me.Chk12.TabIndex = 14
        Me.Chk12.Text = "Diseño de Ticketeras y Pantallas"
        Me.Chk12.UseVisualStyleBackColor = True
        '
        'Chk11
        '
        Me.Chk11.AutoSize = True
        Me.Chk11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Chk11.ForeColor = System.Drawing.Color.Blue
        Me.Chk11.Location = New System.Drawing.Point(11, 130)
        Me.Chk11.Name = "Chk11"
        Me.Chk11.Size = New System.Drawing.Size(130, 17)
        Me.Chk11.TabIndex = 8
        Me.Chk11.Text = "Areas de Atención"
        Me.Chk11.UseVisualStyleBackColor = True
        '
        'Chk10
        '
        Me.Chk10.AutoSize = True
        Me.Chk10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Chk10.ForeColor = System.Drawing.Color.Blue
        Me.Chk10.Location = New System.Drawing.Point(12, 176)
        Me.Chk10.Name = "Chk10"
        Me.Chk10.Size = New System.Drawing.Size(137, 17)
        Me.Chk10.TabIndex = 10
        Me.Chk10.Text = "Puntos de Atención"
        Me.Chk10.UseVisualStyleBackColor = True
        '
        'Chk9
        '
        Me.Chk9.AutoSize = True
        Me.Chk9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Chk9.ForeColor = System.Drawing.Color.Blue
        Me.Chk9.Location = New System.Drawing.Point(12, 153)
        Me.Chk9.Name = "Chk9"
        Me.Chk9.Size = New System.Drawing.Size(158, 17)
        Me.Chk9.TabIndex = 9
        Me.Chk9.Text = "Configuración de Areas"
        Me.Chk9.UseVisualStyleBackColor = True
        '
        'Chk8
        '
        Me.Chk8.AutoSize = True
        Me.Chk8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Chk8.ForeColor = System.Drawing.Color.Blue
        Me.Chk8.Location = New System.Drawing.Point(12, 245)
        Me.Chk8.Name = "Chk8"
        Me.Chk8.Size = New System.Drawing.Size(115, 17)
        Me.Chk8.TabIndex = 13
        Me.Chk8.Text = "Tipos de Ticket"
        Me.Chk8.UseVisualStyleBackColor = True
        '
        'Chk7
        '
        Me.Chk7.AutoSize = True
        Me.Chk7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Chk7.ForeColor = System.Drawing.Color.Blue
        Me.Chk7.Location = New System.Drawing.Point(12, 222)
        Me.Chk7.Name = "Chk7"
        Me.Chk7.Size = New System.Drawing.Size(161, 17)
        Me.Chk7.TabIndex = 12
        Me.Chk7.Text = "Excepciones de Horario"
        Me.Chk7.UseVisualStyleBackColor = True
        '
        'Chk6
        '
        Me.Chk6.AutoSize = True
        Me.Chk6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Chk6.ForeColor = System.Drawing.Color.Blue
        Me.Chk6.Location = New System.Drawing.Point(12, 199)
        Me.Chk6.Name = "Chk6"
        Me.Chk6.Size = New System.Drawing.Size(73, 17)
        Me.Chk6.TabIndex = 11
        Me.Chk6.Text = "Horarios"
        Me.Chk6.UseVisualStyleBackColor = True
        '
        'Chk5
        '
        Me.Chk5.AutoSize = True
        Me.Chk5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Chk5.ForeColor = System.Drawing.Color.Blue
        Me.Chk5.Location = New System.Drawing.Point(12, 107)
        Me.Chk5.Name = "Chk5"
        Me.Chk5.Size = New System.Drawing.Size(72, 17)
        Me.Chk5.TabIndex = 7
        Me.Chk5.Text = "Oficinas"
        Me.Chk5.UseVisualStyleBackColor = True
        '
        'Chk4
        '
        Me.Chk4.AutoSize = True
        Me.Chk4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Chk4.ForeColor = System.Drawing.Color.Blue
        Me.Chk4.Location = New System.Drawing.Point(12, 84)
        Me.Chk4.Name = "Chk4"
        Me.Chk4.Size = New System.Drawing.Size(76, 17)
        Me.Chk4.TabIndex = 6
        Me.Chk4.Text = "Permisos"
        Me.Chk4.UseVisualStyleBackColor = True
        '
        'Chk3
        '
        Me.Chk3.AutoSize = True
        Me.Chk3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Chk3.ForeColor = System.Drawing.Color.Blue
        Me.Chk3.Location = New System.Drawing.Point(12, 61)
        Me.Chk3.Name = "Chk3"
        Me.Chk3.Size = New System.Drawing.Size(75, 17)
        Me.Chk3.TabIndex = 5
        Me.Chk3.Text = "Usuarios"
        Me.Chk3.UseVisualStyleBackColor = True
        '
        'Chk2
        '
        Me.Chk2.AutoSize = True
        Me.Chk2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Chk2.ForeColor = System.Drawing.Color.Blue
        Me.Chk2.Location = New System.Drawing.Point(12, 38)
        Me.Chk2.Name = "Chk2"
        Me.Chk2.Size = New System.Drawing.Size(63, 17)
        Me.Chk2.TabIndex = 4
        Me.Chk2.Text = "Menús"
        Me.Chk2.UseVisualStyleBackColor = True
        '
        'Chk1
        '
        Me.Chk1.AutoSize = True
        Me.Chk1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Chk1.ForeColor = System.Drawing.Color.Blue
        Me.Chk1.Location = New System.Drawing.Point(12, 15)
        Me.Chk1.Name = "Chk1"
        Me.Chk1.Size = New System.Drawing.Size(58, 17)
        Me.Chk1.TabIndex = 3
        Me.Chk1.Text = "Roles"
        Me.Chk1.UseVisualStyleBackColor = True
        '
        'PnlUpload
        '
        Me.PnlUpload.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PnlUpload.Controls.Add(Me.Label2)
        Me.PnlUpload.Controls.Add(Me.DtHasta)
        Me.PnlUpload.Controls.Add(Me.Label1)
        Me.PnlUpload.Controls.Add(Me.DtDesde)
        Me.PnlUpload.Location = New System.Drawing.Point(752, 65)
        Me.PnlUpload.Name = "PnlUpload"
        Me.PnlUpload.Size = New System.Drawing.Size(405, 78)
        Me.PnlUpload.TabIndex = 55
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(18, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 23)
        Me.Label2.TabIndex = 551
        Me.Label2.Text = "Hasta:"
        '
        'DtHasta
        '
        Me.DtHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.DtHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtHasta.Location = New System.Drawing.Point(87, 41)
        Me.DtHasta.Name = "DtHasta"
        Me.DtHasta.Size = New System.Drawing.Size(112, 20)
        Me.DtHasta.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(18, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 23)
        Me.Label1.TabIndex = 549
        Me.Label1.Text = "Desde:"
        '
        'DtDesde
        '
        Me.DtDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.DtDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtDesde.Location = New System.Drawing.Point(87, 15)
        Me.DtDesde.Name = "DtDesde"
        Me.DtDesde.Size = New System.Drawing.Size(112, 20)
        Me.DtDesde.TabIndex = 3
        '
        'CrvReporte
        '
        Me.CrvReporte.ActiveViewIndex = -1
        Me.CrvReporte.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrvReporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrvReporte.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrvReporte.Location = New System.Drawing.Point(14, 47)
        Me.CrvReporte.Name = "CrvReporte"
        Me.CrvReporte.Size = New System.Drawing.Size(1140, 530)
        Me.CrvReporte.TabIndex = 550
        Me.CrvReporte.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'IQ_C0022
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1169, 663)
        Me.Controls.Add(Me.CrvReporte)
        Me.Controls.Add(Me.PnlUpload)
        Me.Controls.Add(Me.PnlDownload)
        Me.Controls.Add(Me.RbUpload)
        Me.Controls.Add(Me.RbDownload)
        Me.Controls.Add(Me.LblAplicacion)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TrvOficinas)
        Me.Controls.Add(Me.Barra_Estado)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "IQ_C0022"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Transferencia de Información con Oficinas"
        Me.Panel1.ResumeLayout(False)
        CType(Me.Panel_Estado0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Panel_Estado1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Panel_Estado2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Panel_Estado3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDownload.ResumeLayout(False)
        Me.PnlDownload.PerformLayout()
        Me.PnlUpload.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CmdExit As System.Windows.Forms.Button
    Friend WithEvents CmdExec As System.Windows.Forms.Button
    Friend WithEvents CmdClean As System.Windows.Forms.Button
    Friend WithEvents LblAplicacion As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TrvOficinas As System.Windows.Forms.TreeView
    Friend WithEvents Barra_Estado As System.Windows.Forms.StatusBar
    Friend WithEvents Panel_Estado0 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents Panel_Estado1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents Panel_Estado2 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents Panel_Estado3 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents CmdPrint As System.Windows.Forms.Button
    Friend WithEvents RbDownload As System.Windows.Forms.RadioButton
    Friend WithEvents RbUpload As System.Windows.Forms.RadioButton
    Friend WithEvents PnlDownload As System.Windows.Forms.Panel
    Friend WithEvents PnlUpload As System.Windows.Forms.Panel
    Friend WithEvents Chk15 As System.Windows.Forms.CheckBox
    Friend WithEvents Chk14 As System.Windows.Forms.CheckBox
    Friend WithEvents Chk13 As System.Windows.Forms.CheckBox
    Friend WithEvents Chk12 As System.Windows.Forms.CheckBox
    Friend WithEvents Chk11 As System.Windows.Forms.CheckBox
    Friend WithEvents Chk10 As System.Windows.Forms.CheckBox
    Friend WithEvents Chk9 As System.Windows.Forms.CheckBox
    Friend WithEvents Chk8 As System.Windows.Forms.CheckBox
    Friend WithEvents Chk7 As System.Windows.Forms.CheckBox
    Friend WithEvents Chk6 As System.Windows.Forms.CheckBox
    Friend WithEvents Chk5 As System.Windows.Forms.CheckBox
    Friend WithEvents Chk4 As System.Windows.Forms.CheckBox
    Friend WithEvents Chk3 As System.Windows.Forms.CheckBox
    Friend WithEvents Chk2 As System.Windows.Forms.CheckBox
    Friend WithEvents Chk1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DtHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents CrvReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Chk17 As System.Windows.Forms.CheckBox
    Friend WithEvents Chk16 As System.Windows.Forms.CheckBox
End Class
