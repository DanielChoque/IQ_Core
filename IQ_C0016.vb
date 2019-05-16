Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Text.RegularExpressions

Public Class IQ_C0016
    Inherits System.Windows.Forms.Form
    Protected DatosConceptos As New DataSet
    Dim Permisos As Integer
    Dim TablaAreas As New DataTable
    Dim TablaKioskos As New DataTable
    Dim TablaLCD As New DataTable
    Dim TablaPuntos As New DataTable
    Dim ColumnaCodigoArea As New DataColumn
    Dim ColumnaDescripArea As New DataColumn
    Dim ColumnaCodigoKiosko As New DataColumn
    Dim ColumnaIPKiosko As New DataColumn
    Dim ColumnaDescripKiosko As New DataColumn
    Dim ColumnaArea1Kiosko As New DataColumn
    Dim ColumnaArea2Kiosko As New DataColumn
    Dim ColumnaArea3Kiosko As New DataColumn
    Dim ColumnaArea4Kiosko As New DataColumn
    Dim ColumnaArea5Kiosko As New DataColumn
    Dim ColumnaArea6Kiosko As New DataColumn
    Dim ColumnaArea7Kiosko As New DataColumn
    Dim ColumnaArea8Kiosko As New DataColumn
    Dim ColumnaArea9Kiosko As New DataColumn
    Dim ColumnaArea10Kiosko As New DataColumn
    Dim ColumnaArea11Kiosko As New DataColumn
    Dim ColumnaArea12Kiosko As New DataColumn
    Dim ColumnaArea13Kiosko As New DataColumn
    Dim ColumnaArea14Kiosko As New DataColumn
    Dim ColumnaArea15Kiosko As New DataColumn
    Dim ColumnaArea16Kiosko As New DataColumn
    Dim ColumnaArea17Kiosko As New DataColumn
    Dim ColumnaArea18Kiosko As New DataColumn
    Dim ColumnaArea19Kiosko As New DataColumn
    Dim ColumnaArea20Kiosko As New DataColumn
    Dim ColumnaSalidaKiosko As New DataColumn
    Dim ColumnaCodigoLCD As New DataColumn
    Dim ColumnaIPLCD As New DataColumn
    Dim ColumnaCorrelLCD As New DataColumn
    Dim ColumnaSalidaLCD As New DataColumn
    Dim ColumnaDescripLCD As New DataColumn
    Dim ColumnaArea1LCD As New DataColumn
    Dim ColumnaArea2LCD As New DataColumn
    Dim ColumnaArea3LCD As New DataColumn
    Dim ColumnaArea4LCD As New DataColumn
    Dim ColumnaArea5LCD As New DataColumn
    Dim ColumnaArea6LCD As New DataColumn
    Dim ColumnaArea7LCD As New DataColumn
    Dim ColumnaArea8LCD As New DataColumn
    Dim ColumnaArea9LCD As New DataColumn
    Dim ColumnaArea10LCD As New DataColumn
    Dim ColumnaArea11LCD As New DataColumn
    Dim ColumnaArea12LCD As New DataColumn
    Dim ColumnaArea13LCD As New DataColumn
    Dim ColumnaArea14LCD As New DataColumn
    Dim ColumnaArea15LCD As New DataColumn
    Dim ColumnaArea16LCD As New DataColumn
    Dim ColumnaArea17LCD As New DataColumn
    Dim ColumnaArea18LCD As New DataColumn
    Dim ColumnaArea19LCD As New DataColumn
    Dim ColumnaArea20LCD As New DataColumn
    Dim ColumnaCodigoPunto As New DataColumn
    Dim ColumnaIPPunto As New DataColumn
    Dim ColumnaDescripPunto As New DataColumn
    Dim ColumnaSiglaPunto As New DataColumn
    Dim ColumnaAudioPunto As New DataColumn
    Dim ColumnaTicket1Punto As New DataColumn
    Dim ColumnaTicket2Punto As New DataColumn
    Dim ColumnaTicket3Punto As New DataColumn
    Dim ColumnaTicket4Punto As New DataColumn
    Dim ColumnaTicket5Punto As New DataColumn
    Dim ColumnaTicket6Punto As New DataColumn
    Dim ColumnaTicket7Punto As New DataColumn
    Dim ColumnaTicket8Punto As New DataColumn
    Dim ColumnaTicket9Punto As New DataColumn
    Dim ColumnaTicket10Punto As New DataColumn
    Dim ColumnaTicket11Punto As New DataColumn
    Dim ColumnaTicket12Punto As New DataColumn
    Dim ColumnaTicket13Punto As New DataColumn
    Dim ColumnaTicket14Punto As New DataColumn
    Dim ColumnaTicket15Punto As New DataColumn
    Dim ColumnaTicket16Punto As New DataColumn
    Dim ColumnaTicket17Punto As New DataColumn
    Dim ColumnaTicket18Punto As New DataColumn
    Dim ColumnaTicket19Punto As New DataColumn
    Dim ColumnaTicket20Punto As New DataColumn
    Dim ColumnaTipoAtencionPunto As New DataColumn
    Private DsAreas As New DataSet
    Private DbAreas As System.Data.OleDb.OleDbDataAdapter = New System.Data.OleDb.OleDbDataAdapter
    Private DsPrinters As New DataSet
    Private DbPrinters As System.Data.OleDb.OleDbDataAdapter = New System.Data.OleDb.OleDbDataAdapter
    Private DsTickets As New DataSet
    Private DbTickets As System.Data.OleDb.OleDbDataAdapter = New System.Data.OleDb.OleDbDataAdapter
    Private DsTipoAtencion As New DataSet
    Private DbTipoAtencion As System.Data.OleDb.OleDbDataAdapter = New System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents LblLCD As System.Windows.Forms.Label
    Friend WithEvents GridLCD As System.Windows.Forms.DataGrid
    Friend WithEvents LblPuntos As System.Windows.Forms.Label
    Friend WithEvents GridPuntos As System.Windows.Forms.DataGrid
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LblOficina As System.Windows.Forms.Label
    Friend WithEvents CmdExit As System.Windows.Forms.Button
    Friend WithEvents CmdClean As System.Windows.Forms.Button
    Friend WithEvents CmdReport As System.Windows.Forms.Button
    Friend WithEvents CmdInsert As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Dim cod_area As String
    Dim Area_env As String
    Dim descArea_env As String
    Friend WithEvents CmdCupos As System.Windows.Forms.Button
    Dim cod_oficina As String

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        AddHandler TablaAreas.ColumnChanging, AddressOf Areas_ColumnChanging
        AddHandler TablaKioskos.ColumnChanging, AddressOf Kioskos_ColumnChanging
        AddHandler TablaLCD.ColumnChanging, AddressOf LCD_ColumnChanging
        AddHandler TablaPuntos.ColumnChanging, AddressOf Puntos_ColumnChanging

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        Dim tooltip1 As New ToolTip(Me.components)
        tooltip1.AutoPopDelay = 5000
        tooltip1.InitialDelay = 500
        tooltip1.ReshowDelay = 500
        tooltip1.ShowAlways = True
        tooltip1.SetToolTip(CmdCupos, "Definición de Capacidad de Atenciòn del Area")
        tooltip1.SetToolTip(Me.GridAreas, "Areas Actualmente definidas")
        tooltip1.SetToolTip(Me.GridKioskos, "Tiqueteras definidas para la Oficina")
        tooltip1.SetToolTip(Me.GridLCD, "Pantallas definidas para la Oficina")
        tooltip1.SetToolTip(Me.GridPuntos, "Puntos de Atención definidos para el Area")
        tooltip1.SetToolTip(Me.CmdClean, "Limpiar")
        tooltip1.SetToolTip(Me.CmdInsert, "Grabar")
        tooltip1.SetToolTip(Me.CmdExit, "Salir")
        tooltip1.SetToolTip(Me.CmdReport, "Reporte")

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        Timer1.Enabled = True
        Timer1.Start()
    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents Barra_Estado As System.Windows.Forms.StatusBar
    Friend WithEvents Panel_Estado0 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents Panel_Estado1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents Panel_Estado2 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents Panel_Estado3 As System.Windows.Forms.StatusBarPanel
    Private WithEvents crvReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents GridAreas As System.Windows.Forms.DataGrid
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents GridKioskos As System.Windows.Forms.DataGrid
    Friend WithEvents LblAreas As System.Windows.Forms.Label
    Friend WithEvents lblKioskos As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IQ_C0016))
        Me.Barra_Estado = New System.Windows.Forms.StatusBar()
        Me.Panel_Estado0 = New System.Windows.Forms.StatusBarPanel()
        Me.Panel_Estado1 = New System.Windows.Forms.StatusBarPanel()
        Me.Panel_Estado2 = New System.Windows.Forms.StatusBarPanel()
        Me.Panel_Estado3 = New System.Windows.Forms.StatusBarPanel()
        Me.crvReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.GridAreas = New System.Windows.Forms.DataGrid()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.GridKioskos = New System.Windows.Forms.DataGrid()
        Me.LblAreas = New System.Windows.Forms.Label()
        Me.lblKioskos = New System.Windows.Forms.Label()
        Me.LblLCD = New System.Windows.Forms.Label()
        Me.GridLCD = New System.Windows.Forms.DataGrid()
        Me.LblPuntos = New System.Windows.Forms.Label()
        Me.GridPuntos = New System.Windows.Forms.DataGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CmdCupos = New System.Windows.Forms.Button()
        Me.LblOficina = New System.Windows.Forms.Label()
        Me.CmdExit = New System.Windows.Forms.Button()
        Me.CmdClean = New System.Windows.Forms.Button()
        Me.CmdReport = New System.Windows.Forms.Button()
        Me.CmdInsert = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.Panel_Estado0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Panel_Estado1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Panel_Estado2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Panel_Estado3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridAreas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridKioskos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridLCD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridPuntos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Barra_Estado
        '
        Me.Barra_Estado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Barra_Estado.Dock = System.Windows.Forms.DockStyle.None
        Me.Barra_Estado.Location = New System.Drawing.Point(0, 520)
        Me.Barra_Estado.Name = "Barra_Estado"
        Me.Barra_Estado.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.Panel_Estado0, Me.Panel_Estado1, Me.Panel_Estado2, Me.Panel_Estado3})
        Me.Barra_Estado.ShowPanels = True
        Me.Barra_Estado.Size = New System.Drawing.Size(1000, 32)
        Me.Barra_Estado.SizingGrip = False
        Me.Barra_Estado.TabIndex = 19
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
        'crvReporte
        '
        Me.crvReporte.ActiveViewIndex = -1
        Me.crvReporte.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crvReporte.BackColor = System.Drawing.SystemColors.Control
        Me.crvReporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvReporte.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvReporte.Location = New System.Drawing.Point(8, 46)
        Me.crvReporte.Name = "crvReporte"
        Me.crvReporte.SelectionFormula = ""
        Me.crvReporte.ShowGroupTreeButton = False
        Me.crvReporte.ShowRefreshButton = False
        Me.crvReporte.Size = New System.Drawing.Size(992, 468)
        Me.crvReporte.TabIndex = 248
        Me.crvReporte.ViewTimeSelectionFormula = ""
        Me.crvReporte.Visible = False
        '
        'GridAreas
        '
        Me.GridAreas.DataMember = ""
        Me.GridAreas.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.GridAreas.Location = New System.Drawing.Point(8, 73)
        Me.GridAreas.Name = "GridAreas"
        Me.GridAreas.Size = New System.Drawing.Size(341, 123)
        Me.GridAreas.TabIndex = 250
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "")
        Me.ImageList1.Images.SetKeyName(4, "")
        Me.ImageList1.Images.SetKeyName(5, "")
        Me.ImageList1.Images.SetKeyName(6, "")
        Me.ImageList1.Images.SetKeyName(7, "")
        Me.ImageList1.Images.SetKeyName(8, "")
        Me.ImageList1.Images.SetKeyName(9, "")
        Me.ImageList1.Images.SetKeyName(10, "")
        Me.ImageList1.Images.SetKeyName(11, "")
        '
        'GridKioskos
        '
        Me.GridKioskos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridKioskos.DataMember = ""
        Me.GridKioskos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.GridKioskos.Location = New System.Drawing.Point(8, 226)
        Me.GridKioskos.Name = "GridKioskos"
        Me.GridKioskos.Size = New System.Drawing.Size(992, 127)
        Me.GridKioskos.TabIndex = 253
        '
        'LblAreas
        '
        Me.LblAreas.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblAreas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAreas.ForeColor = System.Drawing.Color.Blue
        Me.LblAreas.Location = New System.Drawing.Point(8, 46)
        Me.LblAreas.Name = "LblAreas"
        Me.LblAreas.Size = New System.Drawing.Size(341, 24)
        Me.LblAreas.TabIndex = 254
        Me.LblAreas.Text = "AREAS DE ATENCION"
        Me.LblAreas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblKioskos
        '
        Me.lblKioskos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblKioskos.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblKioskos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKioskos.ForeColor = System.Drawing.Color.Black
        Me.lblKioskos.Location = New System.Drawing.Point(5, 199)
        Me.lblKioskos.Name = "lblKioskos"
        Me.lblKioskos.Size = New System.Drawing.Size(995, 24)
        Me.lblKioskos.TabIndex = 255
        Me.lblKioskos.Text = "Tiqueteras"
        Me.lblKioskos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblLCD
        '
        Me.LblLCD.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblLCD.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblLCD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLCD.ForeColor = System.Drawing.Color.Black
        Me.LblLCD.Location = New System.Drawing.Point(5, 356)
        Me.LblLCD.Name = "LblLCD"
        Me.LblLCD.Size = New System.Drawing.Size(995, 24)
        Me.LblLCD.TabIndex = 257
        Me.LblLCD.Text = "Pantallas"
        Me.LblLCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GridLCD
        '
        Me.GridLCD.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridLCD.DataMember = ""
        Me.GridLCD.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.GridLCD.Location = New System.Drawing.Point(8, 387)
        Me.GridLCD.Name = "GridLCD"
        Me.GridLCD.Size = New System.Drawing.Size(992, 127)
        Me.GridLCD.TabIndex = 256
        '
        'LblPuntos
        '
        Me.LblPuntos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblPuntos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblPuntos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPuntos.ForeColor = System.Drawing.Color.Black
        Me.LblPuntos.Location = New System.Drawing.Point(355, 46)
        Me.LblPuntos.Name = "LblPuntos"
        Me.LblPuntos.Size = New System.Drawing.Size(645, 24)
        Me.LblPuntos.TabIndex = 259
        Me.LblPuntos.Text = "Puntos de Atención"
        Me.LblPuntos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GridPuntos
        '
        Me.GridPuntos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPuntos.DataMember = ""
        Me.GridPuntos.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridPuntos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.GridPuntos.Location = New System.Drawing.Point(355, 73)
        Me.GridPuntos.Name = "GridPuntos"
        Me.GridPuntos.Size = New System.Drawing.Size(645, 123)
        Me.GridPuntos.TabIndex = 258
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CmdCupos)
        Me.Panel1.Controls.Add(Me.LblOficina)
        Me.Panel1.Controls.Add(Me.CmdExit)
        Me.Panel1.Controls.Add(Me.CmdClean)
        Me.Panel1.Controls.Add(Me.CmdReport)
        Me.Panel1.Controls.Add(Me.CmdInsert)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1012, 40)
        Me.Panel1.TabIndex = 260
        '
        'CmdCupos
        '
        Me.CmdCupos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdCupos.Image = CType(resources.GetObject("CmdCupos.Image"), System.Drawing.Image)
        Me.CmdCupos.Location = New System.Drawing.Point(969, 0)
        Me.CmdCupos.Name = "CmdCupos"
        Me.CmdCupos.Size = New System.Drawing.Size(40, 40)
        Me.CmdCupos.TabIndex = 257
        Me.CmdCupos.UseVisualStyleBackColor = True
        '
        'LblOficina
        '
        Me.LblOficina.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblOficina.BackColor = System.Drawing.Color.White
        Me.LblOficina.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOficina.ForeColor = System.Drawing.Color.Red
        Me.LblOficina.Location = New System.Drawing.Point(166, 8)
        Me.LblOficina.Name = "LblOficina"
        Me.LblOficina.Size = New System.Drawing.Size(736, 24)
        Me.LblOficina.TabIndex = 255
        Me.LblOficina.Text = "AREAS DE ATENCION"
        Me.LblOficina.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CmdExit
        '
        Me.CmdExit.Image = CType(resources.GetObject("CmdExit.Image"), System.Drawing.Image)
        Me.CmdExit.Location = New System.Drawing.Point(120, 0)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(40, 40)
        Me.CmdExit.TabIndex = 9
        Me.CmdExit.UseVisualStyleBackColor = True
        '
        'CmdClean
        '
        Me.CmdClean.Image = Global.IQ_Core.My.Resources.Resources.Limpiar
        Me.CmdClean.Location = New System.Drawing.Point(80, 0)
        Me.CmdClean.Name = "CmdClean"
        Me.CmdClean.Size = New System.Drawing.Size(40, 40)
        Me.CmdClean.TabIndex = 8
        Me.CmdClean.UseVisualStyleBackColor = True
        '
        'CmdReport
        '
        Me.CmdReport.Image = Global.IQ_Core.My.Resources.Resources.Reporte
        Me.CmdReport.Location = New System.Drawing.Point(40, 0)
        Me.CmdReport.Name = "CmdReport"
        Me.CmdReport.Size = New System.Drawing.Size(40, 40)
        Me.CmdReport.TabIndex = 7
        Me.CmdReport.UseVisualStyleBackColor = True
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
        'IQ_C0016
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1012, 560)
        Me.Controls.Add(Me.crvReporte)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LblPuntos)
        Me.Controls.Add(Me.GridPuntos)
        Me.Controls.Add(Me.LblLCD)
        Me.Controls.Add(Me.GridLCD)
        Me.Controls.Add(Me.lblKioskos)
        Me.Controls.Add(Me.LblAreas)
        Me.Controls.Add(Me.GridKioskos)
        Me.Controls.Add(Me.GridAreas)
        Me.Controls.Add(Me.Barra_Estado)
        Me.Location = New System.Drawing.Point(0, 75)
        Me.Name = "IQ_C0016"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Configuración de Áreas de Atención"
        CType(Me.Panel_Estado0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Panel_Estado1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Panel_Estado2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Panel_Estado3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridAreas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridKioskos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridLCD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridPuntos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Function descrip_oficina(codigo As String) As String
        descrip_oficina = "?????"
        Dim Carga_Coneccion As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion.Open()
        Dim Carga_Comando As New OleDb.OleDbCommand("Select IQOficinas_Descripcion from IQ_Oficinas where IQOficinas_Codigo= '" & codigo & "'", Carga_Coneccion)
        Carga_Comando.CommandTimeout = 0
        Dim Carga_Reader As OleDb.OleDbDataReader = Carga_Comando.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader.Read
            If IsDBNull(Carga_Reader.GetValue(0)) = False Then
                descrip_oficina = Carga_Reader.GetValue(0)
            End If
        End While
        Carga_Coneccion.Close()
    End Function
    Private Sub Kioskos_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
        Dim valor_ingresado As String
        If e.Column.ColumnName.Equals("IPKiosko") Then
            valor_ingresado = CType(e.ProposedValue, String)
            If Trim(valor_ingresado) <> "" Then
                If IPValidate(valor_ingresado) = False Then
                    MessageBox.Show("Ingrese Una Dirección I.P. Válida", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Dim badValue As Object = e.ProposedValue
                    e.ProposedValue = e.Row("IPKiosko")
                    Exit Sub
                End If
            End If
        ElseIf e.Column.ColumnName.Equals("DescripKiosko") Then
            valor_ingresado = CType(e.ProposedValue, String)
            If Len(valor_ingresado) > 100 Then
                Dim badValue As Object = e.ProposedValue
                e.ProposedValue = e.Row("DescripKiosko")
                Exit Sub
            End If
        End If
    End Sub
    Private Sub Puntos_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
        Dim valor_ingresado As String
        If e.Column.ColumnName.Equals("IPPunto") Then
            valor_ingresado = CType(e.ProposedValue, String)
            If Trim(valor_ingresado) <> "" Then
                If IPValidate(valor_ingresado) = False Then
                    MessageBox.Show("Ingrese Una Dirección I.P. Válida", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Dim badValue As Object = e.ProposedValue
                    e.ProposedValue = e.Row("IPPunto")
                    Exit Sub
                End If
            End If
        ElseIf e.Column.ColumnName.Equals("DescripPunto") Then
            valor_ingresado = CType(e.ProposedValue, String)
            If Len(valor_ingresado) > 100 Then
                Dim badValue As Object = e.ProposedValue
                e.ProposedValue = e.Row("DescripPunto")
                Exit Sub
            End If
        ElseIf e.Column.ColumnName.Equals("SiglaPunto") Then
            valor_ingresado = CType(e.ProposedValue, String)
            If Len(valor_ingresado) > 6 Then
                Dim badValue As Object = e.ProposedValue
                e.ProposedValue = e.Row("SiglaPunto")
                Exit Sub
            End If
        ElseIf e.Column.ColumnName.Equals("AudioPunto") Then
            valor_ingresado = CType(e.ProposedValue, String)
            If Trim(valor_ingresado) <> "" Then
                If InStr(valor_ingresado, ".") = 0 Then
                    MessageBox.Show("Ingrese un nombre de archivo de Audio válido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Dim badValue As Object = e.ProposedValue
                    e.ProposedValue = e.Row("AudioPunto")
                    Exit Sub
                ElseIf UCase(Mid(valor_ingresado, InStr(valor_ingresado, ".") + 1, Len(valor_ingresado) - InStr(valor_ingresado, "."))) <> "MP3" And UCase(Mid(valor_ingresado, InStr(valor_ingresado, ".") + 1, Len(valor_ingresado) - InStr(valor_ingresado, "."))) <> "WAV" And UCase(Mid(valor_ingresado, InStr(valor_ingresado, ".") + 1, Len(valor_ingresado) - InStr(valor_ingresado, "."))) <> "WMA" Then
                    MessageBox.Show("Ingrese un nombre de archivo de Audio válido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Dim badValue As Object = e.ProposedValue
                    e.ProposedValue = e.Row("AudioPunto")
                    Exit Sub
                End If
            End If
        End If
    End Sub
    Private Sub Buttons_Click(sender As Object, e As EventArgs) Handles CmdClean.Click, CmdExit.Click, CmdInsert.Click, CmdReport.Click, CmdCupos.Click
        Select Case UCase(sender.name)
            Case "CMDINSERT"
                Insertar_Registros()
            Case "CMDREPORT"
                Emitir_Reporte()
            Case "CMDCLEAN"
                If Me.crvReporte.Visible = True Then
                    Me.crvReporte.Visible = False
                ElseIf Me.GridPuntos.Visible = True Then
                    Me.GridKioskos.Enabled = True
                    Me.GridLCD.Enabled = True
                    Me.GridPuntos.Visible = False
                    Me.GridAreas.Enabled = True
                    Me.LblPuntos.Visible = False
                    Me.CmdCupos.Visible = False
                End If
            Case "CMDCUPOS"
                Dim obj As Object = Activator.CreateInstance(Type.GetType("IQ_Core.IQ_C0025"))
                Dim f As Form = CType(obj, Form)
                f.Location = New Point(0, Me.Top + 60)
                f.Width = Me.Width - 25
                f.Height = Me.Height - 60
                f.Text = "Definición de Capacidad de Atenciòn" & "|" & Trim(CStr(DictAccesos.Valor_Permiso("Iq_0214"))) & "|" & Area_env & "|" & descArea_env
                f.Show()
            Case "CMDEXIT"
                If MessageBox.Show("¿Está Ud. seguro de ABANDONAR EL PROGRAMA?", Me.Text, MessageBoxButtons.OKCancel) = 2 Then
                    Exit Sub
                End If
                Me.Dispose()
            Case Else
                MessageBox.Show("Comando no implementado")
        End Select
    End Sub
    Private Sub Areas_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
        Dim valor_ingresado As String
        If e.Column.ColumnName.Equals("DescripArea") Then
            valor_ingresado = CType(e.ProposedValue, String)
            If Len(valor_ingresado) > 100 Then
                Dim badValue As Object = e.ProposedValue
                e.ProposedValue = e.Row("DescripArea")
                Exit Sub
            End If
        End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Timer1.Enabled = False
        Dim text_aux As String = Me.Text
        Dim pos1 As Integer
        pos1 = InStr(text_aux, "|")
        If pos1 > 0 Then
            Me.Text = Mid(text_aux, 1, pos1 - 1)
            text_aux = Mid(text_aux, pos1 + 1, Len(text_aux) - pos1)
        End If
        pos1 = InStr(text_aux, "|")
        If pos1 > 0 Then
            Permisos = CInt(Mid(text_aux, 1, pos1 - 1))
            text_aux = Mid(text_aux, pos1 + 1, Len(text_aux) - pos1)
        End If
        cod_oficina = Trim(text_aux)
        Panel_Estado0.Text = ""
        Panel_Estado1.Text = ""
        Try
            Fecha_Sis = DateAdd(DateInterval.Second, desfase_segundos, Date.Now)
        Catch ex As Exception
            Fecha_Sis = DateAdd(DateInterval.Second, 0, Date.Now)
        End Try
        Try
            Panel_Estado3.Text = DateAdd(DateInterval.Second, desfase_segundos, Date.Now).ToLongDateString()
        Catch ex As Exception
            Panel_Estado3.Text = DateAdd(DateInterval.Second, 0, Date.Now).ToLongDateString()
        End Try
        Try
            Panel_Estado3.ToolTipText = DateAdd(DateInterval.Second, desfase_segundos, Date.Now).ToShortTimeString()
        Catch ex As Exception
            Panel_Estado3.ToolTipText = DateAdd(DateInterval.Second, 0, Date.Now).ToShortTimeString()
        End Try
        buscar_data(0)
    End Sub
    Private Sub GridValores_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridAreas.DoubleClick
        If Me.GridAreas.VisibleRowCount = 0 Then
            Exit Sub
        End If
        Try
            cod_area = Me.GridAreas.Item(Me.GridAreas.CurrentCell.RowNumber, 0)
            descArea_env = Me.GridAreas.Item(Me.GridAreas.CurrentCell.RowNumber, 1)
            buscar_data(1)
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
    Private Function IPValidate(ByVal strFindin As String) As Boolean
        Dim myRegex As New Regex("^(([01]?\d\d?|2[0-4]\d|25[0-5])\.){3}([01]?\d\d?|25[0-5]|2[0-4]\d)$")
        If myRegex.IsMatch(strFindin) Then
            IPValidate = True
        Else
            IPValidate = False
        End If
    End Function
    Private Sub Formatea_Grid(ByVal nivel As Integer)
        Select Case nivel
            Case 0
                With Me.GridAreas
                    .TableStyles.Clear()
                End With
                TablaAreas.Columns.Clear()
                TablaAreas.Rows.Clear()
                ColumnaCodigoArea.DataType = System.Type.GetType("System.String")
                ColumnaDescripArea.DataType = System.Type.GetType("System.String")
                ColumnaCodigoArea.ColumnName = "CodArea"
                ColumnaDescripArea.ColumnName = "DescripArea"
                ColumnaCodigoArea.Caption = "Codigo"
                ColumnaDescripArea.Caption = "Descripción"
                ColumnaCodigoArea.AutoIncrement = False
                ColumnaDescripArea.AutoIncrement = False
                ColumnaCodigoArea.ReadOnly = False
                ColumnaDescripArea.ReadOnly = False
                TablaAreas.Columns.Add(ColumnaCodigoArea)
                TablaAreas.Columns.Add(ColumnaDescripArea)
                TablaAreas.DefaultView.AllowNew = True
                Dim table_style As New DataGridTableStyle
                table_style.MappingName = TablaAreas.TableName
                Dim codigo_style As New DataGridTextBoxColumn
                With codigo_style
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "CodArea"
                    .HeaderText = "Codigo"
                    .Width = 0
                End With
                Dim descrip_style As New DataGridTextBoxColumn
                With descrip_style
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "DescripArea"
                    .HeaderText = "Descripción"
                    .Width = Me.GridAreas.Width - 40
                End With
                table_style.GridColumnStyles.AddRange _
                    (New DataGridColumnStyle() _
                    {codigo_style, descrip_style})
                Me.GridAreas.TableStyles.Add(table_style)
                Me.GridAreas.DataSource = TablaAreas
                Me.GridAreas.CaptionVisible = False
                With Me.GridKioskos
                    .TableStyles.Clear()
                End With
                TablaKioskos.Columns.Clear()
                TablaKioskos.Rows.Clear()
                ColumnaCodigoKiosko.DataType = System.Type.GetType("System.String")
                ColumnaIPKiosko.DataType = System.Type.GetType("System.String")
                ColumnaDescripKiosko.DataType = System.Type.GetType("System.String")
                ColumnaSalidaKiosko.DataType = System.Type.GetType("System.String")
                ColumnaCodigoKiosko.ColumnName = "CodKiosko"
                ColumnaIPKiosko.ColumnName = "IPKiosko"
                ColumnaDescripKiosko.ColumnName = "DescripKiosko"
                ColumnaSalidaKiosko.ColumnName = "SalidaKiosko"
                ColumnaCodigoKiosko.Caption = "Codigo"
                ColumnaIPKiosko.Caption = "I.P."
                ColumnaDescripKiosko.Caption = "Descripción"
                ColumnaSalidaKiosko.Caption = "Impresora"
                ColumnaCodigoKiosko.AutoIncrement = False
                ColumnaIPKiosko.AutoIncrement = False
                ColumnaDescripKiosko.AutoIncrement = False
                ColumnaSalidaKiosko.AutoIncrement = False
                ColumnaCodigoKiosko.ReadOnly = False
                ColumnaIPKiosko.ReadOnly = False
                ColumnaDescripKiosko.ReadOnly = False
                ColumnaSalidaKiosko.ReadOnly = False
                ColumnaCodigoKiosko.DataType = System.Type.GetType("System.String")
                ColumnaArea1Kiosko.DataType = System.Type.GetType("System.String")
                ColumnaArea1Kiosko.ColumnName = "Area1Kiosko"
                ColumnaArea1Kiosko.Caption = "Area1"
                ColumnaArea1Kiosko.AutoIncrement = False
                ColumnaArea1Kiosko.ReadOnly = False
                ColumnaArea2Kiosko.DataType = System.Type.GetType("System.String")
                ColumnaArea2Kiosko.ColumnName = "Area2Kiosko"
                ColumnaArea2Kiosko.Caption = "Area2"
                ColumnaArea2Kiosko.AutoIncrement = False
                ColumnaArea2Kiosko.ReadOnly = False
                ColumnaArea3Kiosko.DataType = System.Type.GetType("System.String")
                ColumnaArea3Kiosko.ColumnName = "Area3Kiosko"
                ColumnaArea3Kiosko.Caption = "Area3"
                ColumnaArea3Kiosko.AutoIncrement = False
                ColumnaArea3Kiosko.ReadOnly = False
                ColumnaArea4Kiosko.DataType = System.Type.GetType("System.String")
                ColumnaArea4Kiosko.ColumnName = "Area4Kiosko"
                ColumnaArea4Kiosko.Caption = "Area4"
                ColumnaArea4Kiosko.AutoIncrement = False
                ColumnaArea4Kiosko.ReadOnly = False
                ColumnaArea5Kiosko.DataType = System.Type.GetType("System.String")
                ColumnaArea5Kiosko.ColumnName = "Area5Kiosko"
                ColumnaArea5Kiosko.Caption = "Area5"
                ColumnaArea5Kiosko.AutoIncrement = False
                ColumnaArea5Kiosko.ReadOnly = False
                ColumnaArea6Kiosko.DataType = System.Type.GetType("System.String")
                ColumnaArea6Kiosko.ColumnName = "Area6Kiosko"
                ColumnaArea6Kiosko.Caption = "Area6"
                ColumnaArea6Kiosko.AutoIncrement = False
                ColumnaArea6Kiosko.ReadOnly = False
                ColumnaArea7Kiosko.DataType = System.Type.GetType("System.String")
                ColumnaArea7Kiosko.ColumnName = "Area7Kiosko"
                ColumnaArea7Kiosko.Caption = "Area7"
                ColumnaArea7Kiosko.AutoIncrement = False
                ColumnaArea7Kiosko.ReadOnly = False
                ColumnaArea8Kiosko.DataType = System.Type.GetType("System.String")
                ColumnaArea8Kiosko.ColumnName = "Area8Kiosko"
                ColumnaArea8Kiosko.Caption = "Area8"
                ColumnaArea8Kiosko.AutoIncrement = False
                ColumnaArea8Kiosko.ReadOnly = False
                ColumnaArea9Kiosko.DataType = System.Type.GetType("System.String")
                ColumnaArea9Kiosko.ColumnName = "Area9Kiosko"
                ColumnaArea9Kiosko.Caption = "Area9"
                ColumnaArea9Kiosko.AutoIncrement = False
                ColumnaArea9Kiosko.ReadOnly = False
                ColumnaArea10Kiosko.DataType = System.Type.GetType("System.String")
                ColumnaArea10Kiosko.ColumnName = "Area10Kiosko"
                ColumnaArea10Kiosko.Caption = "Area10"
                ColumnaArea10Kiosko.AutoIncrement = False
                ColumnaArea10Kiosko.ReadOnly = False
                ColumnaArea11Kiosko.DataType = System.Type.GetType("System.String")
                ColumnaArea11Kiosko.ColumnName = "Area11Kiosko"
                ColumnaArea11Kiosko.Caption = "Area11"
                ColumnaArea11Kiosko.AutoIncrement = False
                ColumnaArea11Kiosko.ReadOnly = False
                ColumnaArea12Kiosko.DataType = System.Type.GetType("System.String")
                ColumnaArea12Kiosko.ColumnName = "Area12Kiosko"
                ColumnaArea12Kiosko.Caption = "Area12"
                ColumnaArea12Kiosko.AutoIncrement = False
                ColumnaArea12Kiosko.ReadOnly = False
                ColumnaArea13Kiosko.DataType = System.Type.GetType("System.String")
                ColumnaArea13Kiosko.ColumnName = "Area13Kiosko"
                ColumnaArea13Kiosko.Caption = "Area13"
                ColumnaArea13Kiosko.AutoIncrement = False
                ColumnaArea13Kiosko.ReadOnly = False
                ColumnaArea14Kiosko.DataType = System.Type.GetType("System.String")
                ColumnaArea14Kiosko.ColumnName = "Area14Kiosko"
                ColumnaArea14Kiosko.Caption = "Area14"
                ColumnaArea14Kiosko.AutoIncrement = False
                ColumnaArea14Kiosko.ReadOnly = False
                ColumnaArea15Kiosko.DataType = System.Type.GetType("System.String")
                ColumnaArea15Kiosko.ColumnName = "Area15Kiosko"
                ColumnaArea15Kiosko.Caption = "Area15"
                ColumnaArea15Kiosko.AutoIncrement = False
                ColumnaArea15Kiosko.ReadOnly = False
                ColumnaArea16Kiosko.DataType = System.Type.GetType("System.String")
                ColumnaArea16Kiosko.ColumnName = "Area16Kiosko"
                ColumnaArea16Kiosko.Caption = "Area16"
                ColumnaArea16Kiosko.AutoIncrement = False
                ColumnaArea16Kiosko.ReadOnly = False
                ColumnaArea17Kiosko.DataType = System.Type.GetType("System.String")
                ColumnaArea17Kiosko.ColumnName = "Area17Kiosko"
                ColumnaArea17Kiosko.Caption = "Area17"
                ColumnaArea17Kiosko.AutoIncrement = False
                ColumnaArea17Kiosko.ReadOnly = False
                ColumnaArea18Kiosko.DataType = System.Type.GetType("System.String")
                ColumnaArea18Kiosko.ColumnName = "Area18Kiosko"
                ColumnaArea18Kiosko.Caption = "Area18"
                ColumnaArea18Kiosko.AutoIncrement = False
                ColumnaArea18Kiosko.ReadOnly = False
                ColumnaArea19Kiosko.DataType = System.Type.GetType("System.String")
                ColumnaArea19Kiosko.ColumnName = "Area19Kiosko"
                ColumnaArea19Kiosko.Caption = "Area19"
                ColumnaArea19Kiosko.AutoIncrement = False
                ColumnaArea19Kiosko.ReadOnly = False
                ColumnaArea20Kiosko.DataType = System.Type.GetType("System.String")
                ColumnaArea20Kiosko.ColumnName = "Area20Kiosko"
                ColumnaArea20Kiosko.Caption = "Area20"
                ColumnaArea20Kiosko.AutoIncrement = False
                ColumnaArea20Kiosko.ReadOnly = False
                TablaKioskos.Columns.Add(ColumnaCodigoKiosko)
                TablaKioskos.Columns.Add(ColumnaIPKiosko)
                TablaKioskos.Columns.Add(ColumnaDescripKiosko)
                TablaKioskos.Columns.Add(ColumnaSalidaKiosko)
                TablaKioskos.Columns.Add(ColumnaArea1Kiosko)
                TablaKioskos.Columns.Add(ColumnaArea2Kiosko)
                TablaKioskos.Columns.Add(ColumnaArea3Kiosko)
                TablaKioskos.Columns.Add(ColumnaArea4Kiosko)
                TablaKioskos.Columns.Add(ColumnaArea5Kiosko)
                TablaKioskos.Columns.Add(ColumnaArea6Kiosko)
                TablaKioskos.Columns.Add(ColumnaArea7Kiosko)
                TablaKioskos.Columns.Add(ColumnaArea8Kiosko)
                TablaKioskos.Columns.Add(ColumnaArea9Kiosko)
                TablaKioskos.Columns.Add(ColumnaArea10Kiosko)
                TablaKioskos.Columns.Add(ColumnaArea11Kiosko)
                TablaKioskos.Columns.Add(ColumnaArea12Kiosko)
                TablaKioskos.Columns.Add(ColumnaArea13Kiosko)
                TablaKioskos.Columns.Add(ColumnaArea14Kiosko)
                TablaKioskos.Columns.Add(ColumnaArea15Kiosko)
                TablaKioskos.Columns.Add(ColumnaArea16Kiosko)
                TablaKioskos.Columns.Add(ColumnaArea17Kiosko)
                TablaKioskos.Columns.Add(ColumnaArea18Kiosko)
                TablaKioskos.Columns.Add(ColumnaArea19Kiosko)
                TablaKioskos.Columns.Add(ColumnaArea20Kiosko)
                TablaKioskos.DefaultView.AllowNew = True
                Dim table_style_kiosko As New DataGridTableStyle
                table_style_kiosko.MappingName = TablaKioskos.TableName
                Dim codigo_style_kiosko As New DataGridTextBoxColumn
                With codigo_style_kiosko
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "CodKiosko"
                    .HeaderText = "Codigo"
                    .Width = 0
                End With
                Dim ip_style_kiosko As New DataGridTextBoxColumn
                With ip_style_kiosko
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "IPKiosko"
                    .HeaderText = "I.P."
                    .Width = 100
                End With
                Dim descrip_style_kiosko As New DataGridTextBoxColumn
                With descrip_style_kiosko
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "DescripKiosko"
                    .HeaderText = "Descripción"
                    .Width = Me.GridKioskos.Width - 1020
                End With
                Dim Salida_style_kiosko As New DataGridComboBoxColumn
                With Salida_style_kiosko
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "SalidaKiosko"
                    .HeaderText = "Impresora"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsPrinters.Tables("Iq_VwPrinters").DefaultView
                    .ColumnComboBox.DisplayMember = "IqVwPrinters_Descripcion"
                    .ColumnComboBox.ValueMember = "IqVwPrinters_Codigo"
                End With
                Dim Area1_style_kiosko As New DataGridComboBoxColumn
                With Area1_style_kiosko
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area1Kiosko"
                    .HeaderText = "Area1"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area2_style_kiosko As New DataGridComboBoxColumn
                With Area2_style_kiosko
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area2Kiosko"
                    .HeaderText = "Area2"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area3_style_kiosko As New DataGridComboBoxColumn
                With Area3_style_kiosko
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area3Kiosko"
                    .HeaderText = "Area3"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area4_style_kiosko As New DataGridComboBoxColumn
                With Area4_style_kiosko
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area4Kiosko"
                    .HeaderText = "Area4"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area5_style_kiosko As New DataGridComboBoxColumn
                With Area5_style_kiosko
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area5Kiosko"
                    .HeaderText = "Area5"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area6_style_kiosko As New DataGridComboBoxColumn
                With Area6_style_kiosko
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area6Kiosko"
                    .HeaderText = "Area6"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area7_style_kiosko As New DataGridComboBoxColumn
                With Area7_style_kiosko
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area7Kiosko"
                    .HeaderText = "Area7"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area8_style_kiosko As New DataGridComboBoxColumn
                With Area8_style_kiosko
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area8Kiosko"
                    .HeaderText = "Area8"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area9_style_kiosko As New DataGridComboBoxColumn
                With Area9_style_kiosko
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area9Kiosko"
                    .HeaderText = "Area9"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area10_style_kiosko As New DataGridComboBoxColumn
                With Area10_style_kiosko
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area10Kiosko"
                    .HeaderText = "Area10"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area11_style_kiosko As New DataGridComboBoxColumn
                With Area11_style_kiosko
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area11Kiosko"
                    .HeaderText = "Area11"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area12_style_kiosko As New DataGridComboBoxColumn
                With Area12_style_kiosko
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area12Kiosko"
                    .HeaderText = "Area12"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area13_style_kiosko As New DataGridComboBoxColumn
                With Area13_style_kiosko
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area13Kiosko"
                    .HeaderText = "Area13"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area14_style_kiosko As New DataGridComboBoxColumn
                With Area14_style_kiosko
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area14Kiosko"
                    .HeaderText = "Area14"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area15_style_kiosko As New DataGridComboBoxColumn
                With Area15_style_kiosko
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area15Kiosko"
                    .HeaderText = "Area15"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area16_style_kiosko As New DataGridComboBoxColumn
                With Area16_style_kiosko
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area16Kiosko"
                    .HeaderText = "Area16"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area17_style_kiosko As New DataGridComboBoxColumn
                With Area17_style_kiosko
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area17Kiosko"
                    .HeaderText = "Area17"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area18_style_kiosko As New DataGridComboBoxColumn
                With Area18_style_kiosko
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area18Kiosko"
                    .HeaderText = "Area18"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area19_style_kiosko As New DataGridComboBoxColumn
                With Area19_style_kiosko
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area19Kiosko"
                    .HeaderText = "Area19"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area20_style_kiosko As New DataGridComboBoxColumn
                With Area20_style_kiosko
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area20Kiosko"
                    .HeaderText = "Area20"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                table_style_kiosko.GridColumnStyles.AddRange _
                    (New DataGridColumnStyle() _
                    {codigo_style_kiosko, ip_style_kiosko, descrip_style_kiosko, Salida_style_kiosko, Area1_style_kiosko, Area2_style_kiosko, Area3_style_kiosko, Area4_style_kiosko, Area5_style_kiosko, Area6_style_kiosko, Area7_style_kiosko, Area8_style_kiosko, Area9_style_kiosko, Area10_style_kiosko, Area11_style_kiosko, Area12_style_kiosko, Area13_style_kiosko, Area14_style_kiosko, Area15_style_kiosko, Area16_style_kiosko, Area17_style_kiosko, Area18_style_kiosko, Area19_style_kiosko, Area20_style_kiosko})
                Me.GridKioskos.TableStyles.Add(table_style_kiosko)
                Me.GridKioskos.DataSource = TablaKioskos
                Me.GridKioskos.CaptionVisible = False
                With Me.GridLCD
                    .TableStyles.Clear()
                End With
                TablaLCD.Columns.Clear()
                TablaLCD.Rows.Clear()
                ColumnaCodigoLCD.DataType = System.Type.GetType("System.String")
                ColumnaIPLCD.DataType = System.Type.GetType("System.String")
                ColumnaCorrelLCD.DataType = System.Type.GetType("System.String")
                ColumnaSalidaLCD.DataType = System.Type.GetType("System.String")
                ColumnaDescripLCD.DataType = System.Type.GetType("System.String")
                ColumnaCodigoLCD.ColumnName = "CodLCD"
                ColumnaIPLCD.ColumnName = "IPLCD"
                ColumnaCorrelLCD.ColumnName = "CorrelLCD"
                ColumnaSalidaLCD.ColumnName = "SalidaLCD"
                ColumnaDescripLCD.ColumnName = "DescripLCD"
                ColumnaCodigoLCD.Caption = "Codigo"
                ColumnaIPLCD.Caption = "I.P."
                ColumnaCorrelLCD.Caption = "Corr."
                ColumnaSalidaLCD.Caption = "Output"
                ColumnaDescripLCD.Caption = "Descripción"
                ColumnaCodigoLCD.AutoIncrement = False
                ColumnaSalidaLCD.AutoIncrement = False
                ColumnaIPLCD.AutoIncrement = False
                ColumnaCorrelLCD.AutoIncrement = False
                ColumnaDescripLCD.AutoIncrement = False
                ColumnaCodigoLCD.ReadOnly = False
                ColumnaSalidaLCD.ReadOnly = False
                ColumnaSalidaLCD.AllowDBNull = False
                ColumnaIPLCD.ReadOnly = False
                ColumnaCorrelLCD.ReadOnly = False
                ColumnaDescripLCD.ReadOnly = False
                ColumnaCodigoLCD.DataType = System.Type.GetType("System.String")
                ColumnaArea1LCD.DataType = System.Type.GetType("System.String")
                ColumnaArea1LCD.ColumnName = "Area1LCD"
                ColumnaArea1LCD.Caption = "Area 1"
                ColumnaArea1LCD.AutoIncrement = False
                ColumnaArea1LCD.ReadOnly = False
                ColumnaArea2LCD.DataType = System.Type.GetType("System.String")
                ColumnaArea2LCD.ColumnName = "Area2LCD"
                ColumnaArea2LCD.Caption = "Area 2"
                ColumnaArea2LCD.AutoIncrement = False
                ColumnaArea2LCD.ReadOnly = False
                ColumnaArea3LCD.DataType = System.Type.GetType("System.String")
                ColumnaArea3LCD.ColumnName = "Area3LCD"
                ColumnaArea3LCD.Caption = "Area 3"
                ColumnaArea3LCD.AutoIncrement = False
                ColumnaArea3LCD.ReadOnly = False
                ColumnaArea4LCD.DataType = System.Type.GetType("System.String")
                ColumnaArea4LCD.ColumnName = "Area4LCD"
                ColumnaArea4LCD.Caption = "Area 4"
                ColumnaArea4LCD.AutoIncrement = False
                ColumnaArea4LCD.ReadOnly = False
                ColumnaArea5LCD.DataType = System.Type.GetType("System.String")
                ColumnaArea5LCD.ColumnName = "Area5LCD"
                ColumnaArea5LCD.Caption = "Area 5"
                ColumnaArea5LCD.AutoIncrement = False
                ColumnaArea5LCD.ReadOnly = False
                ColumnaArea6LCD.DataType = System.Type.GetType("System.String")
                ColumnaArea6LCD.ColumnName = "Area6LCD"
                ColumnaArea6LCD.Caption = "Area 6"
                ColumnaArea6LCD.AutoIncrement = False
                ColumnaArea6LCD.ReadOnly = False
                ColumnaArea7LCD.DataType = System.Type.GetType("System.String")
                ColumnaArea7LCD.ColumnName = "Area7LCD"
                ColumnaArea7LCD.Caption = "Area 7"
                ColumnaArea7LCD.AutoIncrement = False
                ColumnaArea7LCD.ReadOnly = False
                ColumnaArea8LCD.DataType = System.Type.GetType("System.String")
                ColumnaArea8LCD.ColumnName = "Area8LCD"
                ColumnaArea8LCD.Caption = "Area 8"
                ColumnaArea8LCD.AutoIncrement = False
                ColumnaArea8LCD.ReadOnly = False
                ColumnaArea9LCD.DataType = System.Type.GetType("System.String")
                ColumnaArea9LCD.ColumnName = "Area9LCD"
                ColumnaArea9LCD.Caption = "Area 9"
                ColumnaArea9LCD.AutoIncrement = False
                ColumnaArea9LCD.ReadOnly = False
                ColumnaArea10LCD.DataType = System.Type.GetType("System.String")
                ColumnaArea10LCD.ColumnName = "Area10LCD"
                ColumnaArea10LCD.Caption = "Area 10"
                ColumnaArea10LCD.AutoIncrement = False
                ColumnaArea10LCD.ReadOnly = False
                ColumnaArea11LCD.DataType = System.Type.GetType("System.String")
                ColumnaArea11LCD.ColumnName = "Area11LCD"
                ColumnaArea11LCD.Caption = "Area 11"
                ColumnaArea11LCD.AutoIncrement = False
                ColumnaArea11LCD.ReadOnly = False
                ColumnaArea12LCD.DataType = System.Type.GetType("System.String")
                ColumnaArea12LCD.ColumnName = "Area12LCD"
                ColumnaArea12LCD.Caption = "Area 12"
                ColumnaArea12LCD.AutoIncrement = False
                ColumnaArea12LCD.ReadOnly = False
                ColumnaArea13LCD.DataType = System.Type.GetType("System.String")
                ColumnaArea13LCD.ColumnName = "Area13LCD"
                ColumnaArea13LCD.Caption = "Area 13"
                ColumnaArea13LCD.AutoIncrement = False
                ColumnaArea13LCD.ReadOnly = False
                ColumnaArea14LCD.DataType = System.Type.GetType("System.String")
                ColumnaArea14LCD.ColumnName = "Area14LCD"
                ColumnaArea14LCD.Caption = "Area 14"
                ColumnaArea14LCD.AutoIncrement = False
                ColumnaArea14LCD.ReadOnly = False
                ColumnaArea15LCD.DataType = System.Type.GetType("System.String")
                ColumnaArea15LCD.ColumnName = "Area15LCD"
                ColumnaArea15LCD.Caption = "Area 15"
                ColumnaArea15LCD.AutoIncrement = False
                ColumnaArea15LCD.ReadOnly = False
                ColumnaArea16LCD.DataType = System.Type.GetType("System.String")
                ColumnaArea16LCD.ColumnName = "Area16LCD"
                ColumnaArea16LCD.Caption = "Area 16"
                ColumnaArea16LCD.AutoIncrement = False
                ColumnaArea16LCD.ReadOnly = False
                ColumnaArea17LCD.DataType = System.Type.GetType("System.String")
                ColumnaArea17LCD.ColumnName = "Area17LCD"
                ColumnaArea17LCD.Caption = "Area 17"
                ColumnaArea17LCD.AutoIncrement = False
                ColumnaArea17LCD.ReadOnly = False
                ColumnaArea18LCD.DataType = System.Type.GetType("System.String")
                ColumnaArea18LCD.ColumnName = "Area18LCD"
                ColumnaArea18LCD.Caption = "Area 18"
                ColumnaArea18LCD.AutoIncrement = False
                ColumnaArea18LCD.ReadOnly = False
                ColumnaArea19LCD.DataType = System.Type.GetType("System.String")
                ColumnaArea19LCD.ColumnName = "Area19LCD"
                ColumnaArea19LCD.Caption = "Area 19"
                ColumnaArea19LCD.AutoIncrement = False
                ColumnaArea19LCD.ReadOnly = False
                ColumnaArea20LCD.DataType = System.Type.GetType("System.String")
                ColumnaArea20LCD.ColumnName = "Area20LCD"
                ColumnaArea20LCD.Caption = "Area 20"
                ColumnaArea20LCD.AutoIncrement = False
                ColumnaArea20LCD.ReadOnly = False
                TablaLCD.Columns.Add(ColumnaCodigoLCD)
                TablaLCD.Columns.Add(ColumnaIPLCD)
                TablaLCD.Columns.Add(ColumnaCorrelLCD)
                TablaLCD.Columns.Add(ColumnaDescripLCD)
                TablaLCD.Columns.Add(ColumnaSalidaLCD)
                TablaLCD.Columns.Add(ColumnaArea1LCD)
                TablaLCD.Columns.Add(ColumnaArea2LCD)
                TablaLCD.Columns.Add(ColumnaArea3LCD)
                TablaLCD.Columns.Add(ColumnaArea4LCD)
                TablaLCD.Columns.Add(ColumnaArea5LCD)
                TablaLCD.Columns.Add(ColumnaArea6LCD)
                TablaLCD.Columns.Add(ColumnaArea7LCD)
                TablaLCD.Columns.Add(ColumnaArea8LCD)
                TablaLCD.Columns.Add(ColumnaArea9LCD)
                TablaLCD.Columns.Add(ColumnaArea10LCD)
                TablaLCD.Columns.Add(ColumnaArea11LCD)
                TablaLCD.Columns.Add(ColumnaArea12LCD)
                TablaLCD.Columns.Add(ColumnaArea13LCD)
                TablaLCD.Columns.Add(ColumnaArea14LCD)
                TablaLCD.Columns.Add(ColumnaArea15LCD)
                TablaLCD.Columns.Add(ColumnaArea16LCD)
                TablaLCD.Columns.Add(ColumnaArea17LCD)
                TablaLCD.Columns.Add(ColumnaArea18LCD)
                TablaLCD.Columns.Add(ColumnaArea19LCD)
                TablaLCD.Columns.Add(ColumnaArea20LCD)
                TablaLCD.DefaultView.AllowNew = True
                Dim table_style_LCD As New DataGridTableStyle
                table_style_LCD.MappingName = TablaLCD.TableName
                Dim codigo_style_LCD As New DataGridTextBoxColumn
                With codigo_style_LCD
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "CodLCD"
                    .HeaderText = "Codigo"
                    .Width = 0
                End With
                Dim ip_style_LCD As New DataGridTextBoxColumn
                With ip_style_LCD
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "IPLCD"
                    .HeaderText = "I.P."
                    .Width = 100
                End With
                Dim correl_style_LCD As New DataGridTextBoxColumn
                With correl_style_LCD
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "CorrelLCD"
                    .HeaderText = "Corr."
                    .Width = 100
                End With
                Dim descrip_style_LCD As New DataGridTextBoxColumn
                With descrip_style_LCD
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "DescripLCD"
                    .HeaderText = "Descripción"
                    .Width = Me.GridLCD.Width - 1020
                End With
                Dim Salida_style_LCD As New DataGridTextBoxColumn
                With Salida_style_LCD
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "SalidaLCD"
                    .HeaderText = "Output"
                    .Width = 100
                End With
                Dim Area1_style_LCD As New DataGridComboBoxColumn
                With Area1_style_LCD
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area1LCD"
                    .HeaderText = "Area 1"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area2_style_LCD As New DataGridComboBoxColumn
                With Area2_style_LCD
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area2LCD"
                    .HeaderText = "Area 2"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area3_style_LCD As New DataGridComboBoxColumn
                With Area3_style_LCD
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area3LCD"
                    .HeaderText = "Area 3"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area4_style_LCD As New DataGridComboBoxColumn
                With Area4_style_LCD
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area4LCD"
                    .HeaderText = "Area 4"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area5_style_LCD As New DataGridComboBoxColumn
                With Area5_style_LCD
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area5LCD"
                    .HeaderText = "Area 5"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area6_style_LCD As New DataGridComboBoxColumn
                With Area6_style_LCD
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area6LCD"
                    .HeaderText = "Area 6"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area7_style_LCD As New DataGridComboBoxColumn
                With Area7_style_LCD
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area7LCD"
                    .HeaderText = "Area 7"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area8_style_LCD As New DataGridComboBoxColumn
                With Area8_style_LCD
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area8LCD"
                    .HeaderText = "Area 8"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area9_style_LCD As New DataGridComboBoxColumn
                With Area9_style_LCD
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area9LCD"
                    .HeaderText = "Area 9"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area10_style_LCD As New DataGridComboBoxColumn
                With Area10_style_LCD
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area10LCD"
                    .HeaderText = "Area 10"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area11_style_LCD As New DataGridComboBoxColumn
                With Area11_style_LCD
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area11LCD"
                    .HeaderText = "Area 11"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area12_style_LCD As New DataGridComboBoxColumn
                With Area12_style_LCD
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area12LCD"
                    .HeaderText = "Area 12"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area13_style_LCD As New DataGridComboBoxColumn
                With Area13_style_LCD
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area13LCD"
                    .HeaderText = "Area 13"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area14_style_LCD As New DataGridComboBoxColumn
                With Area14_style_LCD
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area14LCD"
                    .HeaderText = "Area 14"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area15_style_LCD As New DataGridComboBoxColumn
                With Area15_style_LCD
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area15LCD"
                    .HeaderText = "Area 15"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area16_style_LCD As New DataGridComboBoxColumn
                With Area16_style_LCD
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area16LCD"
                    .HeaderText = "Area 16"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area17_style_LCD As New DataGridComboBoxColumn
                With Area17_style_LCD
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area17LCD"
                    .HeaderText = "Area 17"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area18_style_LCD As New DataGridComboBoxColumn
                With Area18_style_LCD
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area18LCD"
                    .HeaderText = "Area 18"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area19_style_LCD As New DataGridComboBoxColumn
                With Area19_style_LCD
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area19LCD"
                    .HeaderText = "Area 19"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                Dim Area20_style_LCD As New DataGridComboBoxColumn
                With Area20_style_LCD
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Area20LCD"
                    .HeaderText = "Area 20"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsAreas.Tables("Iq_Areas").DefaultView
                    .ColumnComboBox.DisplayMember = "IqAreas_Descripcion"
                    .ColumnComboBox.ValueMember = "IqAreas_Codigo"
                End With
                table_style_LCD.GridColumnStyles.AddRange _
                    (New DataGridColumnStyle() _
                    {codigo_style_LCD, ip_style_LCD, correl_style_LCD, descrip_style_LCD, Salida_style_LCD, Area1_style_LCD, Area2_style_LCD, Area3_style_LCD, Area4_style_LCD, Area5_style_LCD, Area6_style_LCD, Area7_style_LCD, Area8_style_LCD, Area9_style_LCD, Area10_style_LCD, Area11_style_LCD, Area12_style_LCD, Area13_style_LCD, Area14_style_LCD, Area15_style_LCD, Area16_style_LCD, Area17_style_LCD, Area18_style_LCD, Area19_style_LCD, Area20_style_LCD})
                Me.GridLCD.TableStyles.Add(table_style_LCD)
                Me.GridLCD.DataSource = TablaLCD
                Me.GridLCD.CaptionVisible = False
            Case 1
                With Me.GridPuntos
                    .TableStyles.Clear()
                End With
                TablaPuntos.Columns.Clear()
                TablaPuntos.Rows.Clear()
                ColumnaCodigoPunto.DataType = System.Type.GetType("System.String")
                ColumnaIPPunto.DataType = System.Type.GetType("System.String")
                ColumnaDescripPunto.DataType = System.Type.GetType("System.String")
                ColumnaSiglaPunto.DataType = System.Type.GetType("System.String")
                ColumnaAudioPunto.DataType = System.Type.GetType("System.String")
                ColumnaTicket1Punto.DataType = System.Type.GetType("System.String")
                ColumnaTicket2Punto.DataType = System.Type.GetType("System.String")
                ColumnaTicket3Punto.DataType = System.Type.GetType("System.String")
                ColumnaTicket4Punto.DataType = System.Type.GetType("System.String")
                ColumnaTicket5Punto.DataType = System.Type.GetType("System.String")
                ColumnaTicket6Punto.DataType = System.Type.GetType("System.String")
                ColumnaTicket7Punto.DataType = System.Type.GetType("System.String")
                ColumnaTicket8Punto.DataType = System.Type.GetType("System.String")
                ColumnaTicket9Punto.DataType = System.Type.GetType("System.String")
                ColumnaTicket10Punto.DataType = System.Type.GetType("System.String")
                ColumnaTicket11Punto.DataType = System.Type.GetType("System.String")
                ColumnaTicket12Punto.DataType = System.Type.GetType("System.String")
                ColumnaTicket13Punto.DataType = System.Type.GetType("System.String")
                ColumnaTicket14Punto.DataType = System.Type.GetType("System.String")
                ColumnaTicket15Punto.DataType = System.Type.GetType("System.String")
                ColumnaTicket16Punto.DataType = System.Type.GetType("System.String")
                ColumnaTicket17Punto.DataType = System.Type.GetType("System.String")
                ColumnaTicket18Punto.DataType = System.Type.GetType("System.String")
                ColumnaTicket19Punto.DataType = System.Type.GetType("System.String")
                ColumnaTicket20Punto.DataType = System.Type.GetType("System.String")
                ColumnaTipoAtencionPunto.DataType = System.Type.GetType("System.String")
                ColumnaCodigoPunto.ColumnName = "CodPunto"
                ColumnaIPPunto.ColumnName = "IPPunto"
                ColumnaDescripPunto.ColumnName = "DescripPunto"
                ColumnaSiglaPunto.ColumnName = "SiglaPunto"
                ColumnaAudioPunto.ColumnName = "AudioPunto"
                ColumnaTicket1Punto.ColumnName = "Ticket1Punto"
                ColumnaTicket2Punto.ColumnName = "Ticket2Punto"
                ColumnaTicket3Punto.ColumnName = "Ticket3Punto"
                ColumnaTicket4Punto.ColumnName = "Ticket4Punto"
                ColumnaTicket5Punto.ColumnName = "Ticket5Punto"
                ColumnaTicket6Punto.ColumnName = "Ticket6Punto"
                ColumnaTicket7Punto.ColumnName = "Ticket7Punto"
                ColumnaTicket8Punto.ColumnName = "Ticket8Punto"
                ColumnaTicket9Punto.ColumnName = "Ticket9Punto"
                ColumnaTicket10Punto.ColumnName = "Ticket10Punto"
                ColumnaTicket11Punto.ColumnName = "Ticket11Punto"
                ColumnaTicket12Punto.ColumnName = "Ticket12Punto"
                ColumnaTicket13Punto.ColumnName = "Ticket13Punto"
                ColumnaTicket14Punto.ColumnName = "Ticket14Punto"
                ColumnaTicket15Punto.ColumnName = "Ticket15Punto"
                ColumnaTicket16Punto.ColumnName = "Ticket16Punto"
                ColumnaTicket17Punto.ColumnName = "Ticket17Punto"
                ColumnaTicket18Punto.ColumnName = "Ticket18Punto"
                ColumnaTicket19Punto.ColumnName = "Ticket19Punto"
                ColumnaTicket20Punto.ColumnName = "Ticket20Punto"
                ColumnaTipoAtencionPunto.ColumnName = "TipoAtencion"
                ColumnaCodigoPunto.Caption = "Codigo"
                ColumnaIPPunto.Caption = "I.P."
                ColumnaAudioPunto.Caption = "Audio"
                ColumnaDescripPunto.Caption = "Descripción"
                ColumnaSiglaPunto.Caption = "Sigla"
                ColumnaTicket1Punto.Caption = "Ticket 1"
                ColumnaTicket2Punto.Caption = "Ticket 2"
                ColumnaTicket3Punto.Caption = "Ticket 3"
                ColumnaTicket4Punto.Caption = "Ticket 4"
                ColumnaTicket5Punto.Caption = "Ticket 5"
                ColumnaTicket6Punto.Caption = "Ticket 6"
                ColumnaTicket7Punto.Caption = "Ticket 7"
                ColumnaTicket8Punto.Caption = "Ticket 8"
                ColumnaTicket9Punto.Caption = "Ticket 9"
                ColumnaTicket10Punto.Caption = "Ticket 10"
                ColumnaTicket11Punto.Caption = "Ticket 11"
                ColumnaTicket12Punto.Caption = "Ticket 12"
                ColumnaTicket13Punto.Caption = "Ticket 13"
                ColumnaTicket14Punto.Caption = "Ticket 14"
                ColumnaTicket15Punto.Caption = "Ticket 15"
                ColumnaTicket16Punto.Caption = "Ticket 16"
                ColumnaTicket17Punto.Caption = "Ticket 17"
                ColumnaTicket18Punto.Caption = "Ticket 18"
                ColumnaTicket19Punto.Caption = "Ticket 19"
                ColumnaTicket20Punto.Caption = "Ticket 20"
                ColumnaTipoAtencionPunto.Caption = "Tipo Ass."
                ColumnaCodigoPunto.AutoIncrement = False
                ColumnaIPPunto.AutoIncrement = False
                ColumnaDescripPunto.AutoIncrement = False
                ColumnaSiglaPunto.AutoIncrement = False
                ColumnaAudioPunto.AutoIncrement = False
                ColumnaTicket1Punto.AutoIncrement = False
                ColumnaTicket2Punto.AutoIncrement = False
                ColumnaTicket3Punto.AutoIncrement = False
                ColumnaTicket4Punto.AutoIncrement = False
                ColumnaTicket5Punto.AutoIncrement = False
                ColumnaTicket6Punto.AutoIncrement = False
                ColumnaTicket7Punto.AutoIncrement = False
                ColumnaTicket8Punto.AutoIncrement = False
                ColumnaTicket9Punto.AutoIncrement = False
                ColumnaTicket10Punto.AutoIncrement = False
                ColumnaTicket11Punto.AutoIncrement = False
                ColumnaTicket12Punto.AutoIncrement = False
                ColumnaTicket13Punto.AutoIncrement = False
                ColumnaTicket14Punto.AutoIncrement = False
                ColumnaTicket15Punto.AutoIncrement = False
                ColumnaTicket16Punto.AutoIncrement = False
                ColumnaTicket17Punto.AutoIncrement = False
                ColumnaTicket18Punto.AutoIncrement = False
                ColumnaTicket19Punto.AutoIncrement = False
                ColumnaTicket20Punto.AutoIncrement = False
                ColumnaTipoAtencionPunto.AutoIncrement = False
                ColumnaCodigoPunto.ReadOnly = False
                ColumnaIPPunto.ReadOnly = False
                ColumnaDescripPunto.ReadOnly = False
                ColumnaSiglaPunto.ReadOnly = False
                ColumnaAudioPunto.ReadOnly = False
                ColumnaTicket1Punto.ReadOnly = False
                ColumnaTicket2Punto.ReadOnly = False
                ColumnaTicket3Punto.ReadOnly = False
                ColumnaTicket4Punto.ReadOnly = False
                ColumnaTicket5Punto.ReadOnly = False
                ColumnaTicket6Punto.ReadOnly = False
                ColumnaTicket7Punto.ReadOnly = False
                ColumnaTicket8Punto.ReadOnly = False
                ColumnaTicket9Punto.ReadOnly = False
                ColumnaTicket10Punto.ReadOnly = False
                ColumnaTicket11Punto.ReadOnly = False
                ColumnaTicket12Punto.ReadOnly = False
                ColumnaTicket13Punto.ReadOnly = False
                ColumnaTicket14Punto.ReadOnly = False
                ColumnaTicket15Punto.ReadOnly = False
                ColumnaTicket16Punto.ReadOnly = False
                ColumnaTicket17Punto.ReadOnly = False
                ColumnaTicket18Punto.ReadOnly = False
                ColumnaTicket19Punto.ReadOnly = False
                ColumnaTicket20Punto.ReadOnly = False
                ColumnaTipoAtencionPunto.ReadOnly = False
                TablaPuntos.Columns.Add(ColumnaCodigoPunto)
                TablaPuntos.Columns.Add(ColumnaIPPunto)
                TablaPuntos.Columns.Add(ColumnaDescripPunto)
                TablaPuntos.Columns.Add(ColumnaSiglaPunto)
                TablaPuntos.Columns.Add(ColumnaAudioPunto)
                TablaPuntos.Columns.Add(ColumnaTipoAtencionPunto)
                TablaPuntos.Columns.Add(ColumnaTicket1Punto)
                TablaPuntos.Columns.Add(ColumnaTicket2Punto)
                TablaPuntos.Columns.Add(ColumnaTicket3Punto)
                TablaPuntos.Columns.Add(ColumnaTicket4Punto)
                TablaPuntos.Columns.Add(ColumnaTicket5Punto)
                TablaPuntos.Columns.Add(ColumnaTicket6Punto)
                TablaPuntos.Columns.Add(ColumnaTicket7Punto)
                TablaPuntos.Columns.Add(ColumnaTicket8Punto)
                TablaPuntos.Columns.Add(ColumnaTicket9Punto)
                TablaPuntos.Columns.Add(ColumnaTicket10Punto)
                TablaPuntos.Columns.Add(ColumnaTicket11Punto)
                TablaPuntos.Columns.Add(ColumnaTicket12Punto)
                TablaPuntos.Columns.Add(ColumnaTicket13Punto)
                TablaPuntos.Columns.Add(ColumnaTicket14Punto)
                TablaPuntos.Columns.Add(ColumnaTicket15Punto)
                TablaPuntos.Columns.Add(ColumnaTicket16Punto)
                TablaPuntos.Columns.Add(ColumnaTicket17Punto)
                TablaPuntos.Columns.Add(ColumnaTicket18Punto)
                TablaPuntos.Columns.Add(ColumnaTicket19Punto)
                TablaPuntos.Columns.Add(ColumnaTicket20Punto)
                TablaPuntos.DefaultView.AllowNew = True
                Dim table_style_Puntos As New DataGridTableStyle
                table_style_Puntos.MappingName = TablaPuntos.TableName
                Dim codigo_style_Puntos As New DataGridTextBoxColumn
                With codigo_style_Puntos
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "CodPunto"
                    .HeaderText = "Codigo"
                    .Width = 0
                End With
                Dim ip_style_Puntos As New DataGridTextBoxColumn
                With ip_style_Puntos
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "IPPunto"
                    .HeaderText = "I.P."
                    .Width = 100
                End With
                Dim descrip_style_Puntos As New DataGridTextBoxColumn
                With descrip_style_Puntos
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "DescripPunto"
                    .HeaderText = "Descripción"
                    .Width = Me.GridPuntos.Width - 780
                End With
                Dim sigla_style_Puntos As New DataGridTextBoxColumn
                With sigla_style_Puntos
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "SiglaPunto"
                    .HeaderText = "Sigla (X6)"
                    .Width = 80
                End With
                Dim audio_style_Puntos As New DataGridTextBoxColumn
                With audio_style_Puntos
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "AudioPunto"
                    .HeaderText = "Audio"
                    .Width = 80
                End With
                Dim TipoAtencion_style_puntos As New DataGridComboBoxColumn
                With TipoAtencion_style_puntos
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "TipoAtencion"
                    .HeaderText = "Tipo Ass."
                    .Width = 100
                    .ColumnComboBox.DataSource = DsTipoAtencion.Tables("TipoAtencion").DefaultView
                    .ColumnComboBox.DisplayMember = "Descripcion"
                    .ColumnComboBox.ValueMember = "Codigo"
                End With
                Dim Ticket1_style_puntos As New DataGridComboBoxColumn
                With Ticket1_style_puntos
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Ticket1Punto"
                    .HeaderText = "Ticket1"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsTickets.Tables("Iq_TipoTick").DefaultView
                    .ColumnComboBox.DisplayMember = "IqTipTick_Descripcion"
                    .ColumnComboBox.ValueMember = "IqTipTick_Codigo"
                End With
                Dim Ticket2_style_puntos As New DataGridComboBoxColumn
                With Ticket2_style_puntos
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Ticket2Punto"
                    .HeaderText = "Ticket2"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsTickets.Tables("Iq_TipoTick").DefaultView
                    .ColumnComboBox.DisplayMember = "IqTipTick_Descripcion"
                    .ColumnComboBox.ValueMember = "IqTipTick_Codigo"
                End With
                Dim Ticket3_style_puntos As New DataGridComboBoxColumn
                With Ticket3_style_puntos
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Ticket3Punto"
                    .HeaderText = "Ticket3"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsTickets.Tables("Iq_TipoTick").DefaultView
                    .ColumnComboBox.DisplayMember = "IqTipTick_Descripcion"
                    .ColumnComboBox.ValueMember = "IqTipTick_Codigo"
                End With
                Dim Ticket4_style_puntos As New DataGridComboBoxColumn
                With Ticket4_style_puntos
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Ticket4Punto"
                    .HeaderText = "Ticket4"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsTickets.Tables("Iq_TipoTick").DefaultView
                    .ColumnComboBox.DisplayMember = "IqTipTick_Descripcion"
                    .ColumnComboBox.ValueMember = "IqTipTick_Codigo"
                End With
                Dim Ticket5_style_puntos As New DataGridComboBoxColumn
                With Ticket5_style_puntos
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Ticket5Punto"
                    .HeaderText = "Ticket5"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsTickets.Tables("Iq_TipoTick").DefaultView
                    .ColumnComboBox.DisplayMember = "IqTipTick_Descripcion"
                    .ColumnComboBox.ValueMember = "IqTipTick_Codigo"
                End With
                Dim Ticket6_style_puntos As New DataGridComboBoxColumn
                With Ticket6_style_puntos
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Ticket6Punto"
                    .HeaderText = "Ticket6"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsTickets.Tables("Iq_TipoTick").DefaultView
                    .ColumnComboBox.DisplayMember = "IqTipTick_Descripcion"
                    .ColumnComboBox.ValueMember = "IqTipTick_Codigo"
                End With
                Dim Ticket7_style_puntos As New DataGridComboBoxColumn
                With Ticket7_style_puntos
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Ticket7Punto"
                    .HeaderText = "Ticket7"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsTickets.Tables("Iq_TipoTick").DefaultView
                    .ColumnComboBox.DisplayMember = "IqTipTick_Descripcion"
                    .ColumnComboBox.ValueMember = "IqTipTick_Codigo"
                End With
                Dim Ticket8_style_puntos As New DataGridComboBoxColumn
                With Ticket8_style_puntos
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Ticket8Punto"
                    .HeaderText = "Ticket8"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsTickets.Tables("Iq_TipoTick").DefaultView
                    .ColumnComboBox.DisplayMember = "IqTipTick_Descripcion"
                    .ColumnComboBox.ValueMember = "IqTipTick_Codigo"
                End With
                Dim Ticket9_style_puntos As New DataGridComboBoxColumn
                With Ticket9_style_puntos
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Ticket9Punto"
                    .HeaderText = "Ticket9"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsTickets.Tables("Iq_TipoTick").DefaultView
                    .ColumnComboBox.DisplayMember = "IqTipTick_Descripcion"
                    .ColumnComboBox.ValueMember = "IqTipTick_Codigo"
                End With
                Dim Ticket10_style_puntos As New DataGridComboBoxColumn
                With Ticket10_style_puntos
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Ticket10Punto"
                    .HeaderText = "Ticket10"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsTickets.Tables("Iq_TipoTick").DefaultView
                    .ColumnComboBox.DisplayMember = "IqTipTick_Descripcion"
                    .ColumnComboBox.ValueMember = "IqTipTick_Codigo"
                End With
                Dim Ticket11_style_puntos As New DataGridComboBoxColumn
                With Ticket11_style_puntos
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Ticket11Punto"
                    .HeaderText = "Ticket11"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsTickets.Tables("Iq_TipoTick").DefaultView
                    .ColumnComboBox.DisplayMember = "IqTipTick_Descripcion"
                    .ColumnComboBox.ValueMember = "IqTipTick_Codigo"
                End With
                Dim Ticket12_style_puntos As New DataGridComboBoxColumn
                With Ticket12_style_puntos
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Ticket12Punto"
                    .HeaderText = "Ticket12"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsTickets.Tables("Iq_TipoTick").DefaultView
                    .ColumnComboBox.DisplayMember = "IqTipTick_Descripcion"
                    .ColumnComboBox.ValueMember = "IqTipTick_Codigo"
                End With
                Dim Ticket13_style_puntos As New DataGridComboBoxColumn
                With Ticket13_style_puntos
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Ticket13Punto"
                    .HeaderText = "Ticket13"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsTickets.Tables("Iq_TipoTick").DefaultView
                    .ColumnComboBox.DisplayMember = "IqTipTick_Descripcion"
                    .ColumnComboBox.ValueMember = "IqTipTick_Codigo"
                End With
                Dim Ticket14_style_puntos As New DataGridComboBoxColumn
                With Ticket14_style_puntos
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Ticket14Punto"
                    .HeaderText = "Ticket14"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsTickets.Tables("Iq_TipoTick").DefaultView
                    .ColumnComboBox.DisplayMember = "IqTipTick_Descripcion"
                    .ColumnComboBox.ValueMember = "IqTipTick_Codigo"
                End With
                Dim Ticket15_style_puntos As New DataGridComboBoxColumn
                With Ticket15_style_puntos
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Ticket15Punto"
                    .HeaderText = "Ticket15"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsTickets.Tables("Iq_TipoTick").DefaultView
                    .ColumnComboBox.DisplayMember = "IqTipTick_Descripcion"
                    .ColumnComboBox.ValueMember = "IqTipTick_Codigo"
                End With
                Dim Ticket16_style_puntos As New DataGridComboBoxColumn
                With Ticket16_style_puntos
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Ticket16Punto"
                    .HeaderText = "Ticket16"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsTickets.Tables("Iq_TipoTick").DefaultView
                    .ColumnComboBox.DisplayMember = "IqTipTick_Descripcion"
                    .ColumnComboBox.ValueMember = "IqTipTick_Codigo"
                End With
                Dim Ticket17_style_puntos As New DataGridComboBoxColumn
                With Ticket17_style_puntos
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Ticket17Punto"
                    .HeaderText = "Ticket17"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsTickets.Tables("Iq_TipoTick").DefaultView
                    .ColumnComboBox.DisplayMember = "IqTipTick_Descripcion"
                    .ColumnComboBox.ValueMember = "IqTipTick_Codigo"
                End With
                Dim Ticket18_style_puntos As New DataGridComboBoxColumn
                With Ticket18_style_puntos
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Ticket18Punto"
                    .HeaderText = "Ticket18"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsTickets.Tables("Iq_TipoTick").DefaultView
                    .ColumnComboBox.DisplayMember = "IqTipTick_Descripcion"
                    .ColumnComboBox.ValueMember = "IqTipTick_Codigo"
                End With
                Dim Ticket19_style_puntos As New DataGridComboBoxColumn
                With Ticket19_style_puntos
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Ticket19Punto"
                    .HeaderText = "Ticket19"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsTickets.Tables("Iq_TipoTick").DefaultView
                    .ColumnComboBox.DisplayMember = "IqTipTick_Descripcion"
                    .ColumnComboBox.ValueMember = "IqTipTick_Codigo"
                End With
                Dim Ticket20_style_puntos As New DataGridComboBoxColumn
                With Ticket20_style_puntos
                    .Alignment = HorizontalAlignment.Left
                    .MappingName = "Ticket20Punto"
                    .HeaderText = "Ticket20"
                    .Width = 100
                    .ColumnComboBox.DataSource = DsTickets.Tables("Iq_TipoTick").DefaultView
                    .ColumnComboBox.DisplayMember = "IqTipTick_Descripcion"
                    .ColumnComboBox.ValueMember = "IqTipTick_Codigo"
                End With
                table_style_Puntos.GridColumnStyles.AddRange _
                    (New DataGridColumnStyle() _
                    {codigo_style_Puntos, ip_style_Puntos, descrip_style_Puntos, sigla_style_Puntos, audio_style_Puntos, TipoAtencion_style_puntos, Ticket1_style_puntos, Ticket2_style_puntos, Ticket3_style_puntos, Ticket4_style_puntos, Ticket5_style_puntos, Ticket6_style_puntos, Ticket7_style_puntos, Ticket8_style_puntos, Ticket9_style_puntos, Ticket10_style_puntos, Ticket11_style_puntos, Ticket12_style_puntos, Ticket13_style_puntos, Ticket14_style_puntos, Ticket15_style_puntos, Ticket16_style_puntos, Ticket17_style_puntos, Ticket18_style_puntos, Ticket19_style_puntos, Ticket20_style_puntos})
                Me.GridPuntos.TableStyles.Add(table_style_Puntos)
                Me.GridPuntos.DataSource = TablaPuntos
                Me.GridPuntos.CaptionVisible = False
        End Select
    End Sub
    Private Sub buscar_data(ByVal nivel As Integer)
        Me.LblOficina.Text = descrip_oficina(cod_oficina)
        Dim cn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(Cnn_Central_Server)
        cn.Open()
        DsAreas.Clear()
        With DbAreas
            Dim SQLStr As String = "Select * from IQ_Areas where IQAreas_Oficina = '" & cod_oficina & "' order by IqAreas_Descripcion"
            .TableMappings.Add("Table", "Iq_Areas")
            Dim cmd As System.Data.OleDb.OleDbCommand = New System.Data.OleDb.OleDbCommand(SQLStr, cn)
            cmd.CommandType = CommandType.Text
            .SelectCommand = cmd
            .Fill(DsAreas)
            .Dispose()
            cmd.Cancel()
        End With
        cn.Close()
        cn.Open()
        DsPrinters.Clear()
        With DbPrinters
            Dim SQLStr As String = "Select * from IQ_VwPrinters"
            .TableMappings.Add("Table", "IQ_VwPrinters")
            Dim cmd As System.Data.OleDb.OleDbCommand = New System.Data.OleDb.OleDbCommand(SQLStr, cn)
            cmd.CommandType = CommandType.Text
            .SelectCommand = cmd
            .Fill(DsPrinters)
            .Dispose()
            cmd.Cancel()
        End With
        cn.Close()
        cn.Open()
        DsTipoAtencion.Clear()
        With DbTipoAtencion
            Dim SQLStr As String = "Select * from IQ_VwTipoAtencion"
            .TableMappings.Add("Table", "TipoAtencion")
            Dim cmd As System.Data.OleDb.OleDbCommand = New System.Data.OleDb.OleDbCommand(SQLStr, cn)
            cmd.CommandType = CommandType.Text
            .SelectCommand = cmd
            .Fill(DsTipoAtencion)
            .Dispose()
            cmd.Cancel()
        End With
        cn.Dispose()
        Dim anyRow As DataRow = DsAreas.Tables("Iq_Areas").NewRow
        anyRow("IqAreas_Codigo") = "XXX"
        anyRow("IqAreas_Descripcion") = " "
        DsAreas.Tables("Iq_Areas").Rows.Add(anyRow)
        If nivel = 1 Then
            Dim Alcance_recup(3) As String
            Alcance_recup(0) = ""
            Alcance_recup(1) = cod_area
            Alcance_recup(2) = ""
            Dim encontrado As Boolean = False
            Dim tipo_busq As String = "A"
            Dim cod_busq As String = cod_area
            Dim Carga_Coneccion_O2 As New OleDb.OleDbConnection(Cnn_Central_Server)
            Carga_Coneccion_O2.Open()
            Dim Carga_Comando_O2 As New OleDb.OleDbCommand("Select * from IQ_TipoTick where IQTipTick_Oficina = '' and IQTipTick_Area = 'A:" & Alcance_recup(1) & "' and IQTipTick_Punto = '' Order by IQTipTick_Codigo", Carga_Coneccion_O2)
            Dim Carga_Reader_O2 As OleDb.OleDbDataReader = Carga_Comando_O2.ExecuteReader(CommandBehavior.CloseConnection)
            While Carga_Reader_O2.Read
                If IsDBNull(Carga_Reader_O2.GetValue(0)) = False Then
                    encontrado = True
                    Dim cn2 As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(Cnn_Central_Server)
                    cn2.Open()
                    DsTickets.Clear()
                    With DbTickets
                        Dim SQLStr As String = "Select * from IQ_TipoTick where IQTipTick_Oficina = '' and IQTipTick_Area = 'A:" & Alcance_recup(1) & "' and IQTipTick_Punto = '' Order by IQTipTick_Codigo"
                        .TableMappings.Add("Table", "IQ_TipoTick")
                        Dim cmd As System.Data.OleDb.OleDbCommand = New System.Data.OleDb.OleDbCommand(SQLStr, cn2)
                        cmd.CommandType = CommandType.Text
                        .SelectCommand = cmd
                        .Fill(DsTickets)
                        .Dispose()
                        cmd.Cancel()
                    End With
                    cn2.Dispose()
                    Dim anyRow_2 As DataRow = DsTickets.Tables("IQ_TipoTick").NewRow
                    anyRow_2("IQTipTick_Codigo") = ""
                    anyRow_2("IQTipTick_Descripcion") = " "
                    DsTickets.Tables("Iq_TipoTick").Rows.Add(anyRow_2)
                End If
            End While
            Carga_Coneccion_O2.Dispose()
            If encontrado = False Then
                Dim Carga_Coneccion_O2b As New OleDb.OleDbConnection(Cnn_Central_Server)
                Carga_Coneccion_O2b.Open()
                Dim instruc_busq As String = ""
                instruc_busq = "Select IQAreas_Oficina from IQ_Areas where IQAreaS_Codigo = '" & cod_busq & "'"
                Dim Carga_Comando_O2b As New OleDb.OleDbCommand(instruc_busq, Carga_Coneccion_O2b)
                Dim Carga_Reader_O2b As OleDb.OleDbDataReader = Carga_Comando_O2b.ExecuteReader(CommandBehavior.CloseConnection)
                While Carga_Reader_O2b.Read
                    If IsDBNull(Carga_Reader_O2b.GetValue(0)) = False Then
                        Alcance_recup(1) = ""
                        Alcance_recup(0) = Carga_Reader_O2b.GetValue(0)
                    End If
                End While
                Carga_Coneccion_O2b.Dispose()
            End If
Busca_3:
            If Alcance_recup(0) = "999999" Then GoTo busca_4
            Dim consolidadora As String = ""
            Dim Carga_Coneccion_O3 As New OleDb.OleDbConnection(Cnn_Central_Server)
            Carga_Coneccion_O3.Open()
            Dim Carga_Comando_O3 As New OleDb.OleDbCommand("Select IQ_TipoTick.*, Iq_Oficinas.IQOficinas_Descripcion,  Iq_Oficinas.IQOficinas_Consolidacion from IQ_TipoTick join IQ_Oficinas on IQTipTick_Oficina = IQOficinas_Codigo where IQTipTick_Oficina = '" & Alcance_recup(0) & "' and IQTipTick_Area = '' and IQTipTick_Punto = '' Order by IQTipTick_Codigo", Carga_Coneccion_O3)
            Dim Carga_Reader_O3 As OleDb.OleDbDataReader = Carga_Comando_O3.ExecuteReader(CommandBehavior.CloseConnection)
            While Carga_Reader_O3.Read
                If IsDBNull(Carga_Reader_O3.GetValue(0)) = False Then
                    encontrado = True
                    Dim cn2 As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(Cnn_Central_Server)
                    cn2.Open()
                    DsTickets.Clear()
                    With DbTickets
                        Dim SQLStr As String = "Select IQ_TipoTick.*, Iq_Oficinas.IQOficinas_Descripcion,  Iq_Oficinas.IQOficinas_Consolidacion from IQ_TipoTick join IQ_Oficinas on IQTipTick_Oficina = IQOficinas_Codigo where IQTipTick_Oficina = '" & Alcance_recup(0) & "' and IQTipTick_Area = '' and IQTipTick_Punto = '' Order by IQTipTick_Codigo"
                        .TableMappings.Add("Table", "IQ_TipoTick")
                        Dim cmd As System.Data.OleDb.OleDbCommand = New System.Data.OleDb.OleDbCommand(SQLStr, cn2)
                        cmd.CommandType = CommandType.Text
                        .SelectCommand = cmd
                        .Fill(DsTickets)
                        .Dispose()
                        cmd.Cancel()
                    End With
                    cn2.Dispose()
                    Dim anyRow_2 As DataRow = DsTickets.Tables("IQ_TipoTick").NewRow
                    anyRow_2("IQTipTick_Codigo") = ""
                    anyRow_2("IQTipTick_Descripcion") = " "
                    DsTickets.Tables("Iq_TipoTick").Rows.Add(anyRow_2)
                End If
            End While
            Carga_Coneccion_O3.Dispose()
            If encontrado = True Then
                GoTo Busca_Fin
            End If
            If encontrado = False Then
                Dim Carga_Coneccion_O3b As New OleDb.OleDbConnection(Cnn_Central_Server)
                Carga_Coneccion_O3b.Open()
                Dim Carga_Comando_O3b As New OleDb.OleDbCommand("Select IQOficinas_Consolidacion from IQ_Oficinas where IQOficinas_Codigo = '" & Alcance_recup(0) & "'", Carga_Coneccion_O3b)
                Dim Carga_Reader_O3b As OleDb.OleDbDataReader = Carga_Comando_O3b.ExecuteReader(CommandBehavior.CloseConnection)
                While Carga_Reader_O3b.Read
                    If IsDBNull(Carga_Reader_O3b.GetValue(0)) = False Then
                        consolidadora = Carga_Reader_O3b.GetValue(0)
                    End If
                End While
                Carga_Coneccion_O3.Dispose()
                Alcance_recup(0) = consolidadora
                GoTo busca_3
            End If
Busca_4:
            Dim Carga_Coneccion_O4 As New OleDb.OleDbConnection(Cnn_Central_Server)
            Carga_Coneccion_O4.Open()
            Dim Carga_Comando_O4 As New OleDb.OleDbCommand("Select * from IQ_TipoTick where IQTipTick_Oficina = '999999' and IQTipTick_Area = '' and IQTipTick_Punto = '' Order by IQTipTick_Codigo", Carga_Coneccion_O4)
            Dim Carga_Reader_O4 As OleDb.OleDbDataReader = Carga_Comando_O4.ExecuteReader(CommandBehavior.CloseConnection)
            While Carga_Reader_O4.Read
                If IsDBNull(Carga_Reader_O4.GetValue(0)) = False Then
                    encontrado = True
                    Dim cn2 As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(Cnn_Central_Server)
                    cn2.Open()
                    DsTickets.Clear()
                    With DbTickets
                        Dim SQLStr As String = "Select * from IQ_TipoTick where IQTipTick_Oficina = '999999' and IQTipTick_Area = '' and IQTipTick_Punto = '' Order by IQTipTick_Codigo"
                        .TableMappings.Add("Table", "IQ_TipoTick")
                        Dim cmd As System.Data.OleDb.OleDbCommand = New System.Data.OleDb.OleDbCommand(SQLStr, cn2)
                        cmd.CommandType = CommandType.Text
                        .SelectCommand = cmd
                        .Fill(DsTickets)
                        .Dispose()
                        cmd.Cancel()
                    End With
                    cn2.Dispose()
                    Dim anyRow_2 As DataRow = DsTickets.Tables("IQ_TipoTick").NewRow
                    anyRow_2("IQTipTick_Codigo") = ""
                    anyRow_2("IQTipTick_Descripcion") = " "
                    DsTickets.Tables("Iq_TipoTick").Rows.Add(anyRow_2)
                End If
            End While
            Carga_Coneccion_O4.Dispose()
Busca_Fin:
        End If
        Formatea_Grid(nivel)
        Dim instruccion As String
        Select Case nivel
            Case 0
                Me.CmdCupos.Visible = False
                Me.GridPuntos.Visible = False
                Me.LblPuntos.Visible = False
                instruccion = "Select * from IQ_Areas where IqAreas_Oficina = '" & cod_oficina & "' Order by IQAreas_Descripcion"
                Dim Carga_Coneccion_M2 As New OleDb.OleDbConnection(Cnn_Central_Server)
                Carga_Coneccion_M2.Open()
                Dim Carga_Comando_M2 As New OleDb.OleDbCommand(instruccion, Carga_Coneccion_M2)
                Dim Carga_Reader_M2 As OleDb.OleDbDataReader = Carga_Comando_M2.ExecuteReader(CommandBehavior.CloseConnection)
                While Carga_Reader_M2.Read
                    Dim fila As DataRow
                    fila = TablaAreas.NewRow
                    fila("CodArea") = Carga_Reader_M2.GetValue(0)
                    fila("DescripArea") = Carga_Reader_M2.GetValue(2)
                    TablaAreas.Rows.Add(fila)
                End While
                Carga_Coneccion_M2.Dispose()
                instruccion = "Select * from IQ_ConfigOfic where IQConfigOfic_Oficina = '" & cod_oficina & "' Order by IQConfigOfic_Descripcion"
                Dim Carga_Coneccion_M2b As New OleDb.OleDbConnection(Cnn_Central_Server)
                Carga_Coneccion_M2b.Open()
                Dim Carga_Comando_M2b As New OleDb.OleDbCommand(instruccion, Carga_Coneccion_M2b)
                Dim Carga_Reader_M2b As OleDb.OleDbDataReader = Carga_Comando_M2b.ExecuteReader(CommandBehavior.CloseConnection)
                While Carga_Reader_M2b.Read
                    Dim fila As DataRow
                    Select Case Carga_Reader_M2b.GetValue(2)
                        Case "K"
                            fila = TablaKioskos.NewRow
                            fila("CodKiosko") = Carga_Reader_M2b.GetValue(0)
                            fila("DescripKiosko") = Carga_Reader_M2b.GetValue(3)
                            fila("IPKiosko") = Carga_Reader_M2b.GetValue(4)
                            fila("SalidaKiosko") = Carga_Reader_M2b.GetValue(6)
                            Dim areas(20) As String
                            Dim ind_areas As Integer = 0
                            Dim posicion As Integer
                            Dim areas_aux As String = Carga_Reader_M2b.GetValue(5)
                            Do While areas_aux <> ""
                                posicion = InStr(areas_aux, "|")
                                If posicion > 0 Then
                                    areas(ind_areas) = Mid(areas_aux, 1, posicion - 1)
                                    If areas(ind_areas) = "" Or areas(ind_areas) = " " Then
                                        areas(ind_areas) = "XXX"
                                    End If
                                    areas_aux = Mid(areas_aux, posicion + 1, Len(areas_aux) - posicion)
                                    ind_areas += 1
                                Else
                                    areas(ind_areas) = Trim(areas_aux)
                                    If areas(ind_areas) = "" Or areas(ind_areas) = " " Then
                                        areas(ind_areas) = "XXX"
                                    End If
                                    areas_aux = ""
                                End If
                            Loop
                            fila("Area1Kiosko") = areas(0)
                            fila("Area2Kiosko") = areas(1)
                            fila("Area3Kiosko") = areas(2)
                            fila("Area4Kiosko") = areas(3)
                            fila("Area5Kiosko") = areas(4)
                            fila("Area6Kiosko") = areas(5)
                            fila("Area7Kiosko") = areas(6)
                            fila("Area8Kiosko") = areas(7)
                            fila("Area9Kiosko") = areas(8)
                            fila("Area10Kiosko") = areas(9)
                            fila("Area11Kiosko") = areas(10)
                            fila("Area12Kiosko") = areas(11)
                            fila("Area13Kiosko") = areas(12)
                            fila("Area14Kiosko") = areas(13)
                            fila("Area15Kiosko") = areas(14)
                            fila("Area16Kiosko") = areas(15)
                            fila("Area17Kiosko") = areas(16)
                            fila("Area18Kiosko") = areas(17)
                            fila("Area19Kiosko") = areas(18)
                            fila("Area20Kiosko") = areas(19)
                            TablaKioskos.Rows.Add(fila)
                        Case "L"
                            fila = TablaLCD.NewRow
                            fila("CodLCD") = Carga_Reader_M2b.GetValue(0)
                            fila("DescripLCD") = Carga_Reader_M2b.GetValue(3)
                            Dim pos_corr As Integer = InStr(Carga_Reader_M2b.GetValue(4), "(")
                            fila("IPLCD") = Mid(Carga_Reader_M2b.GetValue(4), 1, pos_corr - 1)
                            fila("CorrelLCD") = Mid(Carga_Reader_M2b.GetValue(4), pos_corr + 1, Len(Carga_Reader_M2b.GetValue(4)) - pos_corr - 1)
                            fila("SalidaLCD") = Carga_Reader_M2b.GetValue(6)
                            Dim areas(20) As String
                            Dim ind_areas As Integer = 0
                            Dim posicion As Integer
                            Dim areas_aux As String = Carga_Reader_M2b.GetValue(5)
                            Do While areas_aux <> ""
                                posicion = InStr(areas_aux, "|")
                                If posicion > 0 Then
                                    areas(ind_areas) = Mid(areas_aux, 1, posicion - 1)
                                    If areas(ind_areas) = "" Or areas(ind_areas) = " " Then
                                        areas(ind_areas) = "XXX"
                                    End If
                                    areas_aux = Mid(areas_aux, posicion + 1, Len(areas_aux) - posicion)
                                    ind_areas += 1
                                Else
                                    areas(ind_areas) = Trim(areas_aux)
                                    If areas(ind_areas) = "" Or areas(ind_areas) = " " Then
                                        areas(ind_areas) = "XXX"
                                    End If
                                    areas_aux = ""
                                End If
                            Loop
                            fila("Area1LCD") = areas(0)
                            fila("Area2LCD") = areas(1)
                            fila("Area3LCD") = areas(2)
                            fila("Area4LCD") = areas(3)
                            fila("Area5LCD") = areas(4)
                            fila("Area6LCD") = areas(5)
                            fila("Area7LCD") = areas(6)
                            fila("Area8LCD") = areas(7)
                            fila("Area9LCD") = areas(8)
                            fila("Area10LCD") = areas(9)
                            fila("Area11LCD") = areas(10)
                            fila("Area12LCD") = areas(11)
                            fila("Area13LCD") = areas(12)
                            fila("Area14LCD") = areas(13)
                            fila("Area15LCD") = areas(14)
                            fila("Area16LCD") = areas(15)
                            fila("Area17LCD") = areas(16)
                            fila("Area18LCD") = areas(17)
                            fila("Area19LCD") = areas(18)
                            fila("Area20LCD") = areas(19)
                            TablaLCD.Rows.Add(fila)
                    End Select
                End While
                Carga_Coneccion_M2.Dispose()
                Me.GridAreas.Visible = True
                Me.GridKioskos.Visible = True
                Me.GridLCD.Visible = True
                If Permisos > 3 Then
                    Me.CmdInsert.Visible = True
                Else
                    Me.CmdInsert.Visible = False
                End If
                Me.CmdReport.Visible = True
                Me.CmdClean.Visible = True
            Case 1
                Area_env = cod_area
                instruccion = "Select * from IQ_PuntosAtencion where IQPuntos_Area = '" & cod_area & "' Order by IQPuntos_Descripcion"
                Dim Carga_Coneccion_M2 As New OleDb.OleDbConnection(Cnn_Central_Server)
                Carga_Coneccion_M2.Open()
                Dim Carga_Comando_M2 As New OleDb.OleDbCommand(instruccion, Carga_Coneccion_M2)
                Dim Carga_Reader_M2 As OleDb.OleDbDataReader = Carga_Comando_M2.ExecuteReader(CommandBehavior.CloseConnection)
                While Carga_Reader_M2.Read
                    Dim fila As DataRow
                    fila = TablaPuntos.NewRow
                    fila("CodPunto") = Carga_Reader_M2.GetValue(0)
                    fila("DescripPunto") = Carga_Reader_M2.GetValue(2)
                    fila("AudioPunto") = Carga_Reader_M2.GetValue(3)
                    If IsDBNull(Carga_Reader_M2.GetValue(6)) Then
                        fila("SiglaPunto") = ""
                    Else
                        fila("SiglaPunto") = Carga_Reader_M2.GetValue(6)
                    End If
                    If IsDBNull(Carga_Reader_M2.GetValue(7)) Then
                        fila("TipoAtencion") = ""
                    Else
                        fila("TipoAtencion") = Carga_Reader_M2.GetValue(7)
                    End If
                    fila("IPPunto") = Carga_Reader_M2.GetValue(4)
                    Dim tickets(20) As String
                    Dim ind_tickets As Integer = 0
                    Dim posicion As Integer
                    Dim tickets_aux As String = Carga_Reader_M2.GetValue(5)
                    Do While tickets_aux <> ""
                        posicion = InStr(tickets_aux, "|")
                        If posicion > 0 Then
                            tickets(ind_tickets) = Mid(tickets_aux, 1, posicion - 1)
                            tickets_aux = Mid(tickets_aux, posicion + 1, Len(tickets_aux) - posicion)
                            ind_tickets += 1
                        Else
                            tickets(ind_tickets) = Trim(tickets_aux)
                            tickets_aux = ""
                        End If
                    Loop
                    If tickets(19) = Nothing Then
                        tickets(19) = ""
                    End If
                    fila("Ticket1Punto") = tickets(0)
                    fila("Ticket2Punto") = tickets(1)
                    fila("Ticket3Punto") = tickets(2)
                    fila("Ticket4Punto") = tickets(3)
                    fila("Ticket5Punto") = tickets(4)
                    fila("Ticket6Punto") = tickets(5)
                    fila("Ticket7Punto") = tickets(6)
                    fila("Ticket8Punto") = tickets(7)
                    fila("Ticket9Punto") = tickets(8)
                    fila("Ticket10Punto") = tickets(9)
                    fila("Ticket11Punto") = tickets(10)
                    fila("Ticket12Punto") = tickets(11)
                    fila("Ticket13Punto") = tickets(12)
                    fila("Ticket14Punto") = tickets(13)
                    fila("Ticket15Punto") = tickets(14)
                    fila("Ticket16Punto") = tickets(15)
                    fila("Ticket17Punto") = tickets(16)
                    fila("Ticket18Punto") = tickets(17)
                    fila("Ticket19Punto") = tickets(18)
                    fila("Ticket20Punto") = tickets(19)
                    TablaPuntos.Rows.Add(fila)
                End While
                Me.GridKioskos.Enabled = False
                Me.GridLCD.Enabled = False
                Me.GridPuntos.Visible = True
                If DictAccesos.Valor_Permiso("Iq_0214") <> Nothing Then
                    Me.CmdCupos.Visible = True
                Else
                    Me.CmdCupos.Visible = False
                End If
                Me.LblPuntos.Visible = True
                Me.GridAreas.Enabled = False
                If Permisos > 3 Then
                    Me.CmdInsert.Visible = True
                Else
                    Me.CmdInsert.Visible = False
                End If
                Me.CmdReport.Visible = True
                Me.CmdClean.Visible = True
        End Select
    End Sub
    Private Sub Insertar_Registros()
        Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
        Dim indice As Integer
        Dim registros As Integer
        Dim instruccion_insert As String
        If MessageBox.Show("¿Está Ud. seguro de GRABAR LA INFORMACION REGISTRADA?", Me.Text, MessageBoxButtons.OKCancel) = 2 Then
            Exit Sub
        End If
        If Me.GridPuntos.Visible = False Then
            Dim inst_del As String
            inst_del = ""
            inst_del = "Delete from IQ_Areas Where IqAreas_Oficina = '" & cod_oficina & "'"
            IQ_Cnn.Open()
            Dim IQ_Cmm As New OleDb.OleDbCommand(inst_del, IQ_Cnn)
            Dim RegistrosEliminados As Long = IQ_Cmm.ExecuteNonQuery()
            IQ_Cnn.Close()
            registros = 0
            IQ_Cnn.Open()
            For indice = 0 To TablaAreas.Rows.Count - 1
                Dim codigo_a_insertar As String
                If IsDBNull(TablaAreas.Rows(indice)("CodArea")) Then
                    codigo_a_insertar = Trim(cod_oficina)
                    Dim codigo_maximo As String = codigo_a_insertar & "000000"
                    Dim instruccion_select As String
                    instruccion_select = "select max(IQAreas_Codigo)  from IQ_Areas where IQAreas_Oficina = '" & cod_oficina & "'"
                    Dim Carga_Coneccion_Arr0 As New OleDb.OleDbConnection(Cnn_Central_Server)
                    Dim Carga_Comando_Arr0 As New OleDb.OleDbCommand(instruccion_select, Carga_Coneccion_Arr0)
                    Carga_Comando_Arr0.CommandTimeout = 0
                    Carga_Coneccion_Arr0.Open()
                    Dim Carga_Reader_Arr0 As OleDb.OleDbDataReader = Carga_Comando_Arr0.ExecuteReader(CommandBehavior.CloseConnection)
                    While Carga_Reader_Arr0.Read
                        If IsDBNull(Carga_Reader_Arr0.GetValue(0)) = False Then
                            codigo_maximo = Carga_Reader_Arr0.GetValue(0)
                        End If
                    End While
                    Carga_Coneccion_Arr0.Dispose()
                    Dim numero_ultimo As Integer = CInt(Mid(codigo_maximo, Len(codigo_maximo) - 5, 6))
                    numero_ultimo += 1
                    codigo_a_insertar = Trim(cod_oficina) & Format(numero_ultimo, "000000")
                    TablaAreas.Rows(indice)("CodArea") = codigo_a_insertar
                End If
                codigo_a_insertar = TablaAreas.Rows(indice)("CodArea")
                instruccion_insert = "insert into IQ_Areas values ("
                instruccion_insert = instruccion_insert & "'" & codigo_a_insertar & "', "
                instruccion_insert = instruccion_insert & "'" & cod_oficina & "', "
                instruccion_insert = instruccion_insert & " '" & TablaAreas.Rows(indice)("DescripArea") & "')"
                Try
                    Dim IQ_Cmm2 As New OleDb.OleDbCommand(instruccion_insert, IQ_Cnn)
                    Dim RegistrosInsertados As Long = IQ_Cmm2.ExecuteNonQuery()
                    registros += 1
                Catch ex As Exception
                    IQ_Cnn.Close()
                    MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            Next
            IQ_Cnn.Close()
            Dim cn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(Cnn_Central_Server)
            cn.Open()
            DsAreas.Clear()
            With DbAreas
                Dim SQLStr As String = "Select * from IQ_Areas where IQAreas_Oficina = '" & cod_oficina & "' order by IqAreas_Descripcion"
                .TableMappings.Add("Table", "IQ_Areas")
                Dim cmd As System.Data.OleDb.OleDbCommand = New System.Data.OleDb.OleDbCommand(SQLStr, cn)
                cmd.CommandType = CommandType.Text
                .SelectCommand = cmd
                .Fill(DsAreas)
                .Dispose()
                cmd.Cancel()
            End With
            cn.Dispose()
            Dim anyRow As DataRow = DsAreas.Tables("IQ_Areas").NewRow
            anyRow("IqAreas_Codigo") = "XXX"
            anyRow("IqAreas_Descripcion") = " "
            DsAreas.Tables("IQ_Areas").Rows.Add(anyRow)
            inst_del = ""
            inst_del = "Delete from IQ_ConfigOfic Where IQConfigOfic_Oficina = '" & cod_oficina & "'"
            IQ_Cnn.Open()
            Dim IQ_Cmm3 As New OleDb.OleDbCommand(inst_del, IQ_Cnn)
            Dim RegistrosEliminados2 As Long = IQ_Cmm3.ExecuteNonQuery()
            IQ_Cnn.Close()
            Dim cod_punto As String = cod_oficina & "000001"
            For indice = 0 To TablaKioskos.Rows.Count - 1
                Dim codigo_a_insertar As String
                If IsDBNull(TablaKioskos.Rows(indice)("CodKiosko")) Then
                    codigo_a_insertar = Trim(cod_punto)
                    Dim codigo_maximo As String = codigo_a_insertar & "000000"
                    Dim instruccion_select As String
                    instruccion_select = "select max(IQConfigOfic_Codigo)  from IQ_ConfigOfic where IQConfigOfic_Oficina = '" & cod_oficina & "'"
                    Dim Carga_Coneccion_Arr0 As New OleDb.OleDbConnection(Cnn_Central_Server)
                    Dim Carga_Comando_Arr0 As New OleDb.OleDbCommand(instruccion_select, Carga_Coneccion_Arr0)
                    Carga_Comando_Arr0.CommandTimeout = 0
                    Carga_Coneccion_Arr0.Open()
                    Dim Carga_Reader_Arr0 As OleDb.OleDbDataReader = Carga_Comando_Arr0.ExecuteReader(CommandBehavior.CloseConnection)
                    While Carga_Reader_Arr0.Read
                        If IsDBNull(Carga_Reader_Arr0.GetValue(0)) = False Then
                            codigo_maximo = Carga_Reader_Arr0.GetValue(0)
                        End If
                    End While
                    Carga_Coneccion_Arr0.Dispose()
                    Dim numero_ultimo As Integer = CInt(Mid(codigo_maximo, Len(codigo_maximo) - 5, 6))
                    numero_ultimo += 1
                    codigo_a_insertar = Trim(cod_punto) & Format(numero_ultimo, "000000")
                    TablaKioskos.Rows(indice)("CodKiosko") = codigo_a_insertar
                End If
                codigo_a_insertar = TablaKioskos.Rows(indice)("CodKiosko")
                instruccion_insert = "insert into IQ_ConfigOfic values ("
                instruccion_insert = instruccion_insert & "'" & codigo_a_insertar & "', "
                instruccion_insert = instruccion_insert & "'" & cod_oficina & "', "
                instruccion_insert = instruccion_insert & "'K', "
                instruccion_insert = instruccion_insert & " '" & TablaKioskos.Rows(indice)("DescripKiosko") & "', "
                instruccion_insert = instruccion_insert & " '" & TablaKioskos.Rows(indice)("IPKiosko") & "', "
                instruccion_insert = instruccion_insert & " '"
                If IsDBNull(TablaKioskos.Rows(indice)("Area1Kiosko")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaKioskos.Rows(indice)("Area1Kiosko") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaKioskos.Rows(indice)("Area1Kiosko") & "|"
                End If
                If IsDBNull(TablaKioskos.Rows(indice)("Area2Kiosko")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaKioskos.Rows(indice)("Area2Kiosko") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaKioskos.Rows(indice)("Area2Kiosko") & "|"
                End If
                If IsDBNull(TablaKioskos.Rows(indice)("Area3Kiosko")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaKioskos.Rows(indice)("Area3Kiosko") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaKioskos.Rows(indice)("Area3Kiosko") & "|"
                End If
                If IsDBNull(TablaKioskos.Rows(indice)("Area4Kiosko")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaKioskos.Rows(indice)("Area4Kiosko") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaKioskos.Rows(indice)("Area4Kiosko") & "|"
                End If
                If IsDBNull(TablaKioskos.Rows(indice)("Area5Kiosko")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaKioskos.Rows(indice)("Area5Kiosko") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaKioskos.Rows(indice)("Area5Kiosko") & "|"
                End If
                If IsDBNull(TablaKioskos.Rows(indice)("Area6Kiosko")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaKioskos.Rows(indice)("Area6Kiosko") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaKioskos.Rows(indice)("Area6Kiosko") & "|"
                End If
                If IsDBNull(TablaKioskos.Rows(indice)("Area7Kiosko")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaKioskos.Rows(indice)("Area7Kiosko") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaKioskos.Rows(indice)("Area7Kiosko") & "|"
                End If
                If IsDBNull(TablaKioskos.Rows(indice)("Area8Kiosko")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaKioskos.Rows(indice)("Area8Kiosko") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaKioskos.Rows(indice)("Area8Kiosko") & "|"
                End If
                If IsDBNull(TablaKioskos.Rows(indice)("Area9Kiosko")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaKioskos.Rows(indice)("Area9Kiosko") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaKioskos.Rows(indice)("Area9Kiosko") & "|"
                End If
                If IsDBNull(TablaKioskos.Rows(indice)("Area10Kiosko")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaKioskos.Rows(indice)("Area10Kiosko") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaKioskos.Rows(indice)("Area10Kiosko") & "|"
                End If
                If IsDBNull(TablaKioskos.Rows(indice)("Area11Kiosko")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaKioskos.Rows(indice)("Area11Kiosko") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaKioskos.Rows(indice)("Area11Kiosko") & "|"
                End If
                If IsDBNull(TablaKioskos.Rows(indice)("Area12Kiosko")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaKioskos.Rows(indice)("Area12Kiosko") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaKioskos.Rows(indice)("Area12Kiosko") & "|"
                End If
                If IsDBNull(TablaKioskos.Rows(indice)("Area13Kiosko")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaKioskos.Rows(indice)("Area13Kiosko") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaKioskos.Rows(indice)("Area13Kiosko") & "|"
                End If
                If IsDBNull(TablaKioskos.Rows(indice)("Area14Kiosko")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaKioskos.Rows(indice)("Area14Kiosko") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaKioskos.Rows(indice)("Area14Kiosko") & "|"
                End If
                If IsDBNull(TablaKioskos.Rows(indice)("Area15Kiosko")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaKioskos.Rows(indice)("Area15Kiosko") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaKioskos.Rows(indice)("Area15Kiosko") & "|"
                End If
                If IsDBNull(TablaKioskos.Rows(indice)("Area16Kiosko")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaKioskos.Rows(indice)("Area16Kiosko") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaKioskos.Rows(indice)("Area16Kiosko") & "|"
                End If
                If IsDBNull(TablaKioskos.Rows(indice)("Area17Kiosko")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaKioskos.Rows(indice)("Area17Kiosko") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaKioskos.Rows(indice)("Area17Kiosko") & "|"
                End If
                If IsDBNull(TablaKioskos.Rows(indice)("Area18Kiosko")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaKioskos.Rows(indice)("Area18Kiosko") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaKioskos.Rows(indice)("Area18Kiosko") & "|"
                End If
                If IsDBNull(TablaKioskos.Rows(indice)("Area19Kiosko")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaKioskos.Rows(indice)("Area19Kiosko") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaKioskos.Rows(indice)("Area19Kiosko") & "|"
                End If
                If IsDBNull(TablaKioskos.Rows(indice)("Area20Kiosko")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaKioskos.Rows(indice)("Area20Kiosko") = "XXX" Then
                    instruccion_insert = instruccion_insert
                Else
                    instruccion_insert = instruccion_insert & TablaKioskos.Rows(indice)("Area20Kiosko")
                End If
                instruccion_insert = instruccion_insert & "', "
                instruccion_insert = instruccion_insert & " '" & TablaKioskos.Rows(indice)("SalidaKiosko") & "'"
                instruccion_insert = instruccion_insert & ")"
                Try
                    IQ_Cnn.Open()
                    Dim IQ_Cmm2 As New OleDb.OleDbCommand(instruccion_insert, IQ_Cnn)
                    Dim RegistrosInsertados As Long = IQ_Cmm2.ExecuteNonQuery()
                    IQ_Cnn.Close()
                    registros += 1
                Catch ex As Exception
                    IQ_Cnn.Close()
                    MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            Next
            For indice = 0 To TablaLCD.Rows.Count - 1
                Dim codigo_a_insertar As String
                If IsDBNull(TablaLCD.Rows(indice)("CodLCD")) Then
                    codigo_a_insertar = Trim(cod_punto)
                    Dim codigo_maximo As String = codigo_a_insertar & "000000"
                    Dim instruccion_select As String
                    instruccion_select = "select max(IQConfigOfic_Codigo)  from IQ_ConfigOfic where IQConfigOfic_Oficina = '" & cod_oficina & "'"
                    Dim Carga_Coneccion_Arr0 As New OleDb.OleDbConnection(Cnn_Central_Server)
                    Dim Carga_Comando_Arr0 As New OleDb.OleDbCommand(instruccion_select, Carga_Coneccion_Arr0)
                    Carga_Comando_Arr0.CommandTimeout = 0
                    Carga_Coneccion_Arr0.Open()
                    Dim Carga_Reader_Arr0 As OleDb.OleDbDataReader = Carga_Comando_Arr0.ExecuteReader(CommandBehavior.CloseConnection)
                    While Carga_Reader_Arr0.Read
                        If IsDBNull(Carga_Reader_Arr0.GetValue(0)) = False Then
                            codigo_maximo = Carga_Reader_Arr0.GetValue(0)
                        End If
                    End While
                    Carga_Coneccion_Arr0.Dispose()
                    Dim numero_ultimo As Integer = CInt(Mid(codigo_maximo, Len(codigo_maximo) - 5, 6))
                    numero_ultimo += 1
                    codigo_a_insertar = Trim(cod_punto) & Format(numero_ultimo, "000000")
                    TablaLCD.Rows(indice)("CodLCD") = codigo_a_insertar
                End If
                codigo_a_insertar = TablaLCD.Rows(indice)("CodLCD")
                instruccion_insert = "insert into IQ_ConfigOfic values ("
                instruccion_insert = instruccion_insert & "'" & codigo_a_insertar & "', "
                instruccion_insert = instruccion_insert & "'" & cod_oficina & "', "
                instruccion_insert = instruccion_insert & "'L', "
                instruccion_insert = instruccion_insert & " '" & TablaLCD.Rows(indice)("DescripLCD") & "', "
                instruccion_insert = instruccion_insert & " '" & TablaLCD.Rows(indice)("IPLCD") & "(" & Trim(CStr(CInt(TablaLCD.Rows(indice)("CorrelLCD")))) & ")', "
                instruccion_insert = instruccion_insert & " '"
                If IsDBNull(TablaLCD.Rows(indice)("Area1LCD")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaLCD.Rows(indice)("Area1LCD") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaLCD.Rows(indice)("Area1LCD") & "|"
                End If
                If IsDBNull(TablaLCD.Rows(indice)("Area2LCD")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaLCD.Rows(indice)("Area2LCD") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaLCD.Rows(indice)("Area2LCD") & "|"
                End If
                If IsDBNull(TablaLCD.Rows(indice)("Area3LCD")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaLCD.Rows(indice)("Area3LCD") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaLCD.Rows(indice)("Area3LCD") & "|"
                End If
                If IsDBNull(TablaLCD.Rows(indice)("Area4LCD")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaLCD.Rows(indice)("Area4LCD") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaLCD.Rows(indice)("Area4LCD") & "|"
                End If
                If IsDBNull(TablaLCD.Rows(indice)("Area5LCD")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaLCD.Rows(indice)("Area5LCD") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaLCD.Rows(indice)("Area5LCD") & "|"
                End If
                If IsDBNull(TablaLCD.Rows(indice)("Area6LCD")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaLCD.Rows(indice)("Area6LCD") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaLCD.Rows(indice)("Area6LCD") & "|"
                End If
                If IsDBNull(TablaLCD.Rows(indice)("Area7LCD")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaLCD.Rows(indice)("Area7LCD") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaLCD.Rows(indice)("Area7LCD") & "|"
                End If
                If IsDBNull(TablaLCD.Rows(indice)("Area8LCD")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaLCD.Rows(indice)("Area8LCD") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaLCD.Rows(indice)("Area8LCD") & "|"
                End If
                If IsDBNull(TablaLCD.Rows(indice)("Area9LCD")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaLCD.Rows(indice)("Area9LCD") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaLCD.Rows(indice)("Area9LCD") & "|"
                End If
                If IsDBNull(TablaLCD.Rows(indice)("Area10LCD")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaLCD.Rows(indice)("Area10LCD") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaLCD.Rows(indice)("Area10LCD") & "|"
                End If
                If IsDBNull(TablaLCD.Rows(indice)("Area11LCD")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaLCD.Rows(indice)("Area11LCD") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaLCD.Rows(indice)("Area11LCD") & "|"
                End If
                If IsDBNull(TablaLCD.Rows(indice)("Area12LCD")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaLCD.Rows(indice)("Area12LCD") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaLCD.Rows(indice)("Area12LCD") & "|"
                End If
                If IsDBNull(TablaLCD.Rows(indice)("Area13LCD")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaLCD.Rows(indice)("Area13LCD") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaLCD.Rows(indice)("Area13LCD") & "|"
                End If
                If IsDBNull(TablaLCD.Rows(indice)("Area14LCD")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaLCD.Rows(indice)("Area14LCD") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaLCD.Rows(indice)("Area14LCD") & "|"
                End If
                If IsDBNull(TablaLCD.Rows(indice)("Area15LCD")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaLCD.Rows(indice)("Area15LCD") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaLCD.Rows(indice)("Area15LCD") & "|"
                End If
                If IsDBNull(TablaLCD.Rows(indice)("Area16LCD")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaLCD.Rows(indice)("Area16LCD") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaLCD.Rows(indice)("Area16LCD") & "|"
                End If
                If IsDBNull(TablaLCD.Rows(indice)("Area17LCD")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaLCD.Rows(indice)("Area17LCD") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaLCD.Rows(indice)("Area17LCD") & "|"
                End If
                If IsDBNull(TablaLCD.Rows(indice)("Area18LCD")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaLCD.Rows(indice)("Area18LCD") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaLCD.Rows(indice)("Area18LCD") & "|"
                End If
                If IsDBNull(TablaLCD.Rows(indice)("Area19LCD")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaLCD.Rows(indice)("Area19LCD") = "XXX" Then
                    instruccion_insert = instruccion_insert & "|"
                Else
                    instruccion_insert = instruccion_insert & TablaLCD.Rows(indice)("Area19LCD") & "|"
                End If
                If IsDBNull(TablaLCD.Rows(indice)("Area20LCD")) Then
                    instruccion_insert = instruccion_insert & "|"
                ElseIf TablaLCD.Rows(indice)("Area20LCD") = "XXX" Then
                    instruccion_insert = instruccion_insert
                Else
                    instruccion_insert = instruccion_insert & TablaLCD.Rows(indice)("Area20LCD")
                End If
                instruccion_insert = instruccion_insert & "', "
                instruccion_insert = instruccion_insert & " '" & TablaLCD.Rows(indice)("SalidaLCD") & "'"
                instruccion_insert = instruccion_insert & ")"
                Try
                    IQ_Cnn.Open()
                    Dim IQ_Cmm2 As New OleDb.OleDbCommand(instruccion_insert, IQ_Cnn)
                    Dim RegistrosInsertados As Long = IQ_Cmm2.ExecuteNonQuery()
                    IQ_Cnn.Close()
                    registros += 1
                Catch ex As Exception
                    IQ_Cnn.Close()
                    MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            Next
            IQ_Cnn.Dispose()
        Else
            Dim inst_del As String
            inst_del = ""
            inst_del = "Delete from IQ_PuntosAtencion Where IQPuntos_Area = '" & cod_area & "'"
            IQ_Cnn.Open()
            Dim IQ_Cmm As New OleDb.OleDbCommand(inst_del, IQ_Cnn)
            Dim RegistrosEliminados As Long = IQ_Cmm.ExecuteNonQuery()
            IQ_Cnn.Close()
            registros = 0
            For indice = 0 To TablaPuntos.Rows.Count - 1
                Dim codigo_a_insertar As String
                If IsDBNull(TablaPuntos.Rows(indice)("CodPunto")) Then
                    codigo_a_insertar = Trim(cod_area)
                    Dim codigo_maximo As String = codigo_a_insertar & "000000"
                    Dim instruccion_select As String
                    instruccion_select = "select max(IQPuntos_Codigo)  from IQ_PuntosAtencion where IQPuntos_Area = '" & cod_area & "'"
                    Dim Carga_Coneccion_Arr0 As New OleDb.OleDbConnection(Cnn_Central_Server)
                    Dim Carga_Comando_Arr0 As New OleDb.OleDbCommand(instruccion_select, Carga_Coneccion_Arr0)
                    Carga_Comando_Arr0.CommandTimeout = 0
                    Carga_Coneccion_Arr0.Open()
                    Dim Carga_Reader_Arr0 As OleDb.OleDbDataReader = Carga_Comando_Arr0.ExecuteReader(CommandBehavior.CloseConnection)
                    While Carga_Reader_Arr0.Read
                        If IsDBNull(Carga_Reader_Arr0.GetValue(0)) = False Then
                            codigo_maximo = Carga_Reader_Arr0.GetValue(0)
                        End If
                    End While
                    Carga_Coneccion_Arr0.Dispose()
                    Dim numero_ultimo As Integer = CInt(Mid(codigo_maximo, Len(codigo_maximo) - 5, 6))
                    numero_ultimo += 1
                    codigo_a_insertar = Trim(cod_area) & Format(numero_ultimo, "000000")
                Else
                    codigo_a_insertar = TablaPuntos.Rows(indice)("CodPunto")
                End If
                instruccion_insert = "insert into IQ_PuntosAtencion values ("
                instruccion_insert = instruccion_insert & "'" & codigo_a_insertar & "', "
                instruccion_insert = instruccion_insert & "'" & cod_area & "', "
                instruccion_insert = instruccion_insert & " '" & TablaPuntos.Rows(indice)("DescripPunto") & "', "
                instruccion_insert = instruccion_insert & " '" & TablaPuntos.Rows(indice)("AudioPunto") & "', "
                instruccion_insert = instruccion_insert & " '" & TablaPuntos.Rows(indice)("IPPunto") & "', "
                instruccion_insert = instruccion_insert & " '"
                instruccion_insert = instruccion_insert & TablaPuntos.Rows(indice)("Ticket1Punto") & "|"
                instruccion_insert = instruccion_insert & TablaPuntos.Rows(indice)("Ticket2Punto") & "|"
                instruccion_insert = instruccion_insert & TablaPuntos.Rows(indice)("Ticket3Punto") & "|"
                instruccion_insert = instruccion_insert & TablaPuntos.Rows(indice)("Ticket4Punto") & "|"
                instruccion_insert = instruccion_insert & TablaPuntos.Rows(indice)("Ticket5Punto") & "|"
                instruccion_insert = instruccion_insert & TablaPuntos.Rows(indice)("Ticket6Punto") & "|"
                instruccion_insert = instruccion_insert & TablaPuntos.Rows(indice)("Ticket7Punto") & "|"
                instruccion_insert = instruccion_insert & TablaPuntos.Rows(indice)("Ticket8Punto") & "|"
                instruccion_insert = instruccion_insert & TablaPuntos.Rows(indice)("Ticket9Punto") & "|"
                instruccion_insert = instruccion_insert & TablaPuntos.Rows(indice)("Ticket10Punto") & "|"
                instruccion_insert = instruccion_insert & TablaPuntos.Rows(indice)("Ticket11Punto") & "|"
                instruccion_insert = instruccion_insert & TablaPuntos.Rows(indice)("Ticket12Punto") & "|"
                instruccion_insert = instruccion_insert & TablaPuntos.Rows(indice)("Ticket13Punto") & "|"
                instruccion_insert = instruccion_insert & TablaPuntos.Rows(indice)("Ticket14Punto") & "|"
                instruccion_insert = instruccion_insert & TablaPuntos.Rows(indice)("Ticket15Punto") & "|"
                instruccion_insert = instruccion_insert & TablaPuntos.Rows(indice)("Ticket16Punto") & "|"
                instruccion_insert = instruccion_insert & TablaPuntos.Rows(indice)("Ticket17Punto") & "|"
                instruccion_insert = instruccion_insert & TablaPuntos.Rows(indice)("Ticket18Punto") & "|"
                instruccion_insert = instruccion_insert & TablaPuntos.Rows(indice)("Ticket19Punto") & "|"
                instruccion_insert = instruccion_insert & TablaPuntos.Rows(indice)("Ticket20Punto") & "', "
                instruccion_insert = instruccion_insert & " '" & TablaPuntos.Rows(indice)("SiglaPunto") & "', "
                instruccion_insert = instruccion_insert & " '" & TablaPuntos.Rows(indice)("TipoAtencion") & "')"
                Try
                    IQ_Cnn.Open()
                    Dim IQ_Cmm2 As New OleDb.OleDbCommand(instruccion_insert, IQ_Cnn)
                    Dim RegistrosInsertados As Long = IQ_Cmm2.ExecuteNonQuery()
                    IQ_Cnn.Close()
                    registros += 1
                Catch ex As Exception
                    IQ_Cnn.Close()
                    MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            Next
            IQ_Cnn.Dispose()
        End If
        MessageBox.Show(registros.ToString & " REGISTROS GRABADOS SATISFACTORIAMENTE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub Emitir_Reporte()
        Dim rptlayout As New ReportDocument
        Try
            rptlayout.Load(Disco_Appl & ":\I-Q\IQ_Rpt\IQ_C0016.rpt")
            rptlayout.SetDatabaseLogon(Server_User, Server_Pwd)
            rptlayout.SummaryInfo.ReportTitle = Nombre_Cliente + Chr(10) + "Configuración de Areas de Atención por Oficina"
            Me.crvReporte.SelectionFormula = "{IQ_Oficinas.IQOficinas_Codigo} = '" + cod_oficina + "'"
            Me.crvReporte.ReportSource = rptlayout
            Me.crvReporte.DisplayToolbar = True
            Me.crvReporte.ShowCloseButton = False
            Me.crvReporte.Zoom(1)
            Me.crvReporte.ShowFirstPage()
            Me.crvReporte.BringToFront()
            Me.crvReporte.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            Me.crvReporte.Visible = True
            'rptlayout.dispose()
        Catch exc As Exception
            Dim Mensaje_Excepcion As String
            Mensaje_Excepcion = exc.Message
            Mensaje_Excepcion = "Error Integrado: " + Mensaje_Excepcion
            MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub LCD_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
        Dim valor_ingresado As String
        If e.Column.ColumnName.Equals("IPLCD") Then
            valor_ingresado = CType(e.ProposedValue, String)
            If Trim(valor_ingresado) <> "" Then
                If IPValidate(valor_ingresado) = False Then
                    MessageBox.Show("Ingrese Una Dirección I.P. Válida", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Dim badValue As Object = e.ProposedValue
                    e.ProposedValue = e.Row("IPLCD")
                    Exit Sub
                End If
            End If
        ElseIf e.Column.ColumnName.Equals("DescripLCD") Then
            valor_ingresado = CType(e.ProposedValue, String)
            If Len(valor_ingresado) > 100 Then
                Dim badValue As Object = e.ProposedValue
                e.ProposedValue = e.Row("DescripLCD")
                Exit Sub
            End If
        ElseIf e.Column.ColumnName.Equals("SalidaLCD") Then
            valor_ingresado = CType(e.ProposedValue, String)
            If valor_ingresado <> "0" And valor_ingresado <> "1" And valor_ingresado <> "2" And valor_ingresado <> "3" And valor_ingresado <> "4" Then
                Dim badValue As Object = e.ProposedValue
                e.ProposedValue = e.Row("SalidaLCD")
                Exit Sub
            End If
        ElseIf e.Column.ColumnName.Equals("CorrelLCD") Then
            valor_ingresado = CType(e.ProposedValue, String)
            If IsNumeric(valor_ingresado) = False Then
                Dim badValue As Object = e.ProposedValue
                e.ProposedValue = e.Row("CorrelLCD")
                Exit Sub
            End If
        End If
    End Sub

End Class
