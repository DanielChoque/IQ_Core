Imports CrystalDecisions.CrystalReports.Engine
Public Class IQ_C0026
    Dim ColumnaCodigo As New DataColumn
    Dim ColumnaDescripcion As New DataColumn
    Dim ColumnaStatus As New DataColumn
    Dim ColumnaTicket As New DataColumn
    Dim ColumnaHora As New DataColumn
    Dim TablaDatos As New DataTable
    Dim Permisos As Integer = 0
    Private DsStatus As New DataSet
    Private DbStatus As System.Data.OleDb.OleDbDataAdapter = New System.Data.OleDb.OleDbDataAdapter

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles CmdExit.Click
        IQ_C0000.PicFondo.Visible = True
        Me.Dispose()
    End Sub
    Public Sub New()
        InitializeComponent()
        Timer2.Enabled = False
        Timer2.Stop()
        Timer1.Enabled = True
        Timer1.Start()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Timer1.Enabled = False
        If InStr(Me.Text, "|") > 0 Then
            Permisos = CInt(Mid(Me.Text, InStr(Me.Text, "|") + 1, 1))
            Me.Text = Mid(Me.Text, 1, InStr(Me.Text, "|") - 1)
        End If
        Dim toolTip1 As New ToolTip()
        toolTip1.AutoPopDelay = 5000
        toolTip1.InitialDelay = 1000
        toolTip1.ReshowDelay = 500
        toolTip1.ShowAlways = True
        toolTip1.SetToolTip(CmdExit, "Salir")
        Panel_Estado0.Text = ""
        Panel_Estado1.Text = ""
        Dim cn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(Cnn_Central_Server)
        cn.Open()
        DsStatus.Clear()
        With DbStatus
            Dim SQLStr As String = "Select * from Iq_VwEstados"
            .TableMappings.Add("Table", "Iq_VwEstados")
            Dim cmd As System.Data.OleDb.OleDbCommand = New System.Data.OleDb.OleDbCommand(SQLStr, cn)
            cmd.CommandType = CommandType.Text
            .SelectCommand = cmd
            .Fill(DsStatus)
            .Dispose()
            cmd.Cancel()
        End With
        cn.Dispose()
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
        Busca_Data()
    End Sub
    Private Sub Busca_Data()
        Me.Timer2.Enabled = False
        Me.Timer2.Stop()
        Me.GridDatos.Visible = False
        Formatea_Grid()
        Me.GridDatos.Visible = True
        Me.Timer2.Enabled = True
        Me.Timer2.Start()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Busca_Data()
    End Sub

    Private Sub Formatea_Grid()
        With Me.GridDatos
            .TableStyles.Clear()
        End With
        TablaDatos.Columns.Clear()
        TablaDatos.Rows.Clear()
        ColumnaCodigo.DataType = System.Type.GetType("System.String")
        ColumnaDescripcion.DataType = System.Type.GetType("System.String")
        ColumnaStatus.DataType = System.Type.GetType("System.String")
        ColumnaTicket.DataType = System.Type.GetType("System.String")
        ColumnaHora.DataType = System.Type.GetType("System.String")
        ColumnaCodigo.ColumnName = "Codigo"
        ColumnaDescripcion.ColumnName = "Descripcion"
        ColumnaStatus.ColumnName = "Status"
        ColumnaTicket.ColumnName = "Ticket"
        ColumnaHora.ColumnName = "Hora"
        ColumnaCodigo.Caption = ""
        ColumnaDescripcion.Caption = ""
        ColumnaHora.Caption = ""
        ColumnaStatus.Caption = ""
        ColumnaTicket.Caption = ""
        ColumnaCodigo.AutoIncrement = False
        ColumnaDescripcion.AutoIncrement = False
        ColumnaHora.AutoIncrement = False
        ColumnaStatus.AutoIncrement = False
        ColumnaTicket.AutoIncrement = False
        ColumnaCodigo.ReadOnly = True
        ColumnaDescripcion.ReadOnly = True
        ColumnaHora.ReadOnly = True
        ColumnaStatus.ReadOnly = True
        ColumnaTicket.ReadOnly = True
        TablaDatos.Columns.Add(ColumnaCodigo)
        TablaDatos.Columns.Add(ColumnaDescripcion)
        TablaDatos.Columns.Add(ColumnaStatus)
        TablaDatos.Columns.Add(ColumnaTicket)
        TablaDatos.Columns.Add(ColumnaHora)
        TablaDatos.DefaultView.AllowNew = False
        Dim Carga_Coneccion_O3 As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O3.Open()
        Dim Carga_Comando_O3 As New OleDb.OleDbCommand("Select * from IQ_Vwstatus where Codigo like '" & Computer_Ofic & "%' order by Codigo", Carga_Coneccion_O3)
        Dim Carga_Reader_O3 As OleDb.OleDbDataReader = Carga_Comando_O3.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O3.Read
            If IsDBNull(Carga_Reader_O3.GetValue(0)) = False Then
                Dim fila As DataRow
                fila = TablaDatos.NewRow
                fila("Codigo") = Carga_Reader_O3.GetValue(0)
                fila("Descripcion") = Carga_Reader_O3.GetValue(1)
                fila("Status") = Carga_Reader_O3.GetValue(2)
                fila("Ticket") = Carga_Reader_O3.GetValue(3)
                fila("Hora") = Format(Carga_Reader_O3.GetValue(4), "HH:mm:ss")
                TablaDatos.Rows.Add(fila)
            End If
        End While
        Carga_Coneccion_O3.Dispose()
        Dim table_style As New DataGridTableStyle
        table_style.MappingName = TablaDatos.TableName
        Dim Codigo_Style As New DataGridTextBoxColumn
        With Codigo_Style
            .Alignment = HorizontalAlignment.Left
            .MappingName = "Codigo"
            .HeaderText = "Código"
            .Width = 0
        End With
        Dim Descripcion_Style As New DataGridTextBoxColumn
        With Descripcion_Style
            .Alignment = HorizontalAlignment.Left
            .MappingName = "Descripcion"
            .HeaderText = "Punto de Atención"
            .Width = 300
        End With
        Dim Status_style As New DataGridComboBoxColumn
        With Status_style
            .Alignment = HorizontalAlignment.Left
            .MappingName = "Status"
            .HeaderText = "Estado"
            .Width = 100
            .ColumnComboBox.DataSource = DsStatus.Tables("Iq_VwEstados").DefaultView
            .ColumnComboBox.DisplayMember = "IqVwEstados_Descripcion"
            .ColumnComboBox.ValueMember = "IqVwEstados_Codigo"
        End With
        Dim Ticket_Style As New DataGridTextBoxColumn
        With Ticket_Style
            .Alignment = HorizontalAlignment.Right
            .MappingName = "Ticket"
            .HeaderText = "Ticket"
            .Width = 100
        End With
        Dim Hora_style As New DataGridTextBoxColumn
        With Hora_style
            .Alignment = HorizontalAlignment.Right
            .MappingName = "Hora"
            .HeaderText = "Hora"
            .Width = 100
        End With
        table_style.GridColumnStyles.AddRange _
            (New DataGridColumnStyle() _
            {Codigo_Style, Descripcion_Style, Status_style, Ticket_Style, Hora_style})
        Me.GridDatos.TableStyles.Add(table_style)
        Me.GridDatos.DataSource = TablaDatos
        Me.GridDatos.CaptionVisible = False
        Me.GridDatos.Visible = True
    End Sub
End Class