Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Text.RegularExpressions

Public Class IQ_C0003
    Dim Permisos As Integer = 0
    Dim Counter_Lista As Integer = 0
    Dim listaoficinas As New System.Windows.Forms.ListBox
    Private Dictoficinas As New ColeccionOficinas
    Protected DatosOficinas As New DataSet

    Public Sub New()
        Try
            InitializeComponent()
            Dim toolTip1 As New ToolTip()
            toolTip1.AutoPopDelay = 5000
            toolTip1.InitialDelay = 1000
            toolTip1.ReshowDelay = 500
            toolTip1.ShowAlways = True
            toolTip1.SetToolTip(CmdInsert, "Insertar")
            toolTip1.SetToolTip(CmdModify, "Modificar")
            toolTip1.SetToolTip(CmdReport, "Reporte")
            toolTip1.SetToolTip(CmdRefresh, "Actualizar Listas")
            toolTip1.SetToolTip(CmdExit, "Salir")
            toolTip1.SetToolTip(CmdDelete, "Eliminar")
            toolTip1.SetToolTip(CmdConfig, "Configuración de las Áreas de Atención de la Oficina")
            toolTip1.SetToolTip(CmdClean, "Limpiar")
            toolTip1.SetToolTip(Me.CmbOficina, "Oficina Consolidadora")
            toolTip1.SetToolTip(Me.TxtCodigo, "Código de la Oficina")
            toolTip1.SetToolTip(Me.TxtDescripcion, "Descripción de la Oficina")
            toolTip1.SetToolTip(Me.TxtIp, "Máscara del Segmento de Red de la Oficina (Opcional)")
            toolTip1.SetToolTip(Me.TxtServer, "Nombre del Servidor Vinculado de SQL Server")
            toolTip1.SetToolTip(Me.GridDatos, "Oficinas ya definidas")
            Timer1.Enabled = True
            Timer1.Start()
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
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Timer1.Enabled = False
        If InStr(Me.Text, "|") > 0 Then
            Permisos = CInt(Mid(Me.Text, InStr(Me.Text, "|") + 1, 1))
            Me.Text = Mid(Me.Text, 1, InStr(Me.Text, "|") - 1)
        End If
        Limpiar_Controles()
    End Sub
    Private Class ColeccionOficinas
        Inherits System.Collections.DictionaryBase

        Public Sub Add_ColeccionOficinas(ByVal Key As String, ByVal Item As String)
            Dictionary.Add(Key, Item)
        End Sub

        Public Function Valor(ByVal Key As String) As String
            Valor = Dictionary.Item(Key)
        End Function
    End Class
    Private Function CodigoOficina(ByVal Codigo As String) As String
        CodigoOficina = ""
        If Me.listaoficinas.Items.Count = 0 Then
            CodigoOficina = ""
        Else
            For Me.Counter_Lista = 1 To Me.listaoficinas.Items.Count - 1 Step 2
                If Trim(Codigo) = Trim(Me.listaoficinas.Items.Item(Counter_Lista)) Then
                    CodigoOficina = Me.listaoficinas.Items.Item(Counter_Lista - 1)
                End If
            Next
        End If
    End Function
    Private Sub Emitir_Reporte()
        Dim rptlayout As New ReportDocument
        Try
            rptlayout.Load(Disco_Appl & ":\I-Q\IQ_Rpt\IQ_C0003.rpt")
            rptlayout.SetDatabaseLogon(Server_User, Server_Pwd)
            rptlayout.SummaryInfo.ReportTitle = Nombre_Cliente + Chr(10) + "Definición de Oficinas"
            Me.CrvReporte.ReportSource = rptlayout
            Me.CrvReporte.DisplayToolbar = True
            Me.CrvReporte.ShowCloseButton = False
            Me.CrvReporte.Zoom(1)
            Me.CrvReporte.ShowFirstPage()
            Me.CrvReporte.BringToFront()
            Me.CrvReporte.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            Me.CrvReporte.Visible = True
            '            rptlayout.Dispose()
        Catch exc As Exception
            Dim Mensaje_Excepcion As String
            Mensaje_Excepcion = exc.Message
            MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Buttons_Click(sender As Object, e As EventArgs) Handles CmdDelete.Click, CmdClean.Click, CmdExit.Click, CmdInsert.Click, CmdModify.Click, CmdReport.Click, CmdConfig.Click, CmdRefresh.Click
        Select Case UCase(sender.name)
            Case "CMDINSERT"
                File_Action = "A"
                Update_Process()
            Case "CMDMODIFY"
                File_Action = "M"
                Update_Process()
            Case "CMDDELETE"
                File_Action = "B"
                Update_Process()
            Case "CMDREPORT"
                Emitir_Reporte()
            Case "CMDCLEAN"
                If Me.CrvReporte.Visible = True Then
                    Me.CrvReporte.Visible = False
                Else
                    Limpiar_Controles()
                End If
            Case "CMDEXIT"
                IQ_C0000.PicFondo.Visible = True
                Me.Dispose()
            Case "CMDCONFIG"
                Dim obj As Object = Activator.CreateInstance(Type.GetType("IQ_Core.IQ_C0016"))
                Dim f As Form = CType(obj, Form)
                f.Location = New Point(0, Me.Top + 60)
                f.Width = Me.Width - 25
                f.Height = Me.Height - 60
                f.Text = "Configuración de Areas de las Oficinas" & "|" & Trim(CStr(DictAccesos.Valor_Permiso("Iq_0212"))) & "|" & Me.TxtCodigo.Text
                f.Show()
            Case "CMDREFRESH"
                Dim INSTRUCCION As String
                Me.listaoficinas.MultiColumn = True
                Me.listaoficinas.SelectionMode = SelectionMode.One
                Me.Dictoficinas.Clear()
                Me.CmbOficina.Items.Clear()
                Me.listaoficinas.Items.Clear()
                Me.CmbOficina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
                Me.CmbOficina.Sorted = True
                Me.listaoficinas.BeginUpdate()
                INSTRUCCION = "Select IQOficinas_Codigo, IQOficinas_Descripcion from Iq_Oficinas order by IqOficinas_Codigo"
                Dim Carga_Coneccion_O As New OleDb.OleDbConnection(Cnn_Central_Server)
                Carga_Coneccion_O.Open()
                Dim Carga_Comando_O As New OleDb.OleDbCommand(INSTRUCCION, Carga_Coneccion_O)
                Dim Carga_Reader_O As OleDb.OleDbDataReader = Carga_Comando_O.ExecuteReader(CommandBehavior.CloseConnection)
                While Carga_Reader_O.Read
                    Me.listaoficinas.Items.Add(Carga_Reader_O.GetValue(0))
                    Me.listaoficinas.Items.Add(Carga_Reader_O.GetValue(1))
                    Me.CmbOficina.Items.Add(Carga_Reader_O.GetValue(1))
                End While
                Carga_Coneccion_O.Dispose()
                Me.listaoficinas.Items.Add("999999")
                Me.listaoficinas.Items.Add("CONSOLIDADO")
                Me.CmbOficina.Items.Add("CONSOLIDADO")
                Me.CmbOficina.Items.Add("")
                Me.listaoficinas.EndUpdate()
                Me.CmbOficina.EndUpdate()
                If Me.listaoficinas.Items.Count > 0 Then
                    For Me.Counter_Lista = 0 To Me.listaoficinas.Items.Count - 2 Step 2
                        Me.Dictoficinas.Add_ColeccionOficinas(Me.listaoficinas.Items.Item(Counter_Lista), Me.listaoficinas.Items.Item(Counter_Lista + 1))
                    Next
                End If
                Me.CmbOficina.Text = ""
            Case Else
                MessageBox.Show("Comando no implementado")
        End Select
    End Sub
    Private Function IPValidate(ByVal strFindin As String) As Boolean
        Dim myRegex As New Regex("^(([01]?\d\d?|2[0-4]\d|25[0-5])\.){3}([01]?\d\d?|25[0-5]|2[0-4]\d)$")
        If myRegex.IsMatch(strFindin) Then
            IPValidate = True
        Else
            IPValidate = False
        End If
    End Function
    Private Sub TxtIp_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtIp.Validating
        If Trim(Me.TxtIp.Text) <> "" Then
            If IPValidate(Me.TxtIp.Text) = False Then
                MessageBox.Show("Ingrese Una Dirección I.P. Válida", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                e.Cancel = True
                Exit Sub
            End If
        End If
    End Sub
    Private Sub Limpiar_Controles()
        Dim instruccion As String
        Me.listaoficinas.MultiColumn = True
        Me.listaoficinas.SelectionMode = SelectionMode.One
        Me.Dictoficinas.Clear()
        Me.CmbOficina.Items.Clear()
        Me.listaoficinas.Items.Clear()
        Me.CmbOficina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbOficina.Sorted = True
        Me.listaoficinas.BeginUpdate()
        instruccion = "Select IQOficinas_Codigo, IQOficinas_Descripcion from Iq_Oficinas order by IqOficinas_Codigo"
        Dim Carga_Coneccion_O As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O.Open()
        Dim Carga_Comando_O As New OleDb.OleDbCommand(instruccion, Carga_Coneccion_O)
        Dim Carga_Reader_O As OleDb.OleDbDataReader = Carga_Comando_O.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O.Read
            Me.listaoficinas.Items.Add(Carga_Reader_O.GetValue(0))
            Me.listaoficinas.Items.Add(Carga_Reader_O.GetValue(1))
            Me.CmbOficina.Items.Add(Carga_Reader_O.GetValue(1))
        End While
        Carga_Coneccion_O.Dispose()
        Me.listaoficinas.Items.Add("999999")
        Me.listaoficinas.Items.Add("CONSOLIDADO")
        Me.CmbOficina.Items.Add("CONSOLIDADO")
        Me.CmbOficina.Items.Add("")
        Me.listaoficinas.EndUpdate()
        Me.CmbOficina.EndUpdate()
        If Me.listaoficinas.Items.Count > 0 Then
            For Me.Counter_Lista = 0 To Me.listaoficinas.Items.Count - 2 Step 2
                Me.Dictoficinas.Add_ColeccionOficinas(Me.listaoficinas.Items.Item(Counter_Lista), Me.listaoficinas.Items.Item(Counter_Lista + 1))
            Next
        End If
        Me.CmbOficina.Text = ""
        If Not IsNothing(DatosOficinas.Tables("Iq_Oficinas")) Then
            DatosOficinas.Tables("Iq_Oficinas").Clear()
        End If
        With Me.GridDatos
            .TableStyles.Clear()
        End With
        Dim SeConecta As Boolean = True
        While SeConecta
            Try
                Dim CnnConceptos As New OleDb.OleDbConnection(Cnn_Central_Server)
                Dim AdapterConceptos As New OleDbDataAdapter("select Iq_Oficinas.*, Iq_VwOficinas.Descripcion as DescOficina from Iq_Oficinas Join IQ_VwOficinas on IQOficinas_Consolidacion = IQ_VwOficinas.Codigo order by IQOficinas_Codigo", CnnConceptos)
                DatosOficinas.Clear()
                AdapterConceptos.Fill(DatosOficinas, "Iq_Oficinas")
                Me.GridDatos.DataSource = DatosOficinas.Tables("Iq_Oficinas")
                SeConecta = False
            Catch exc As Exception
                MessageBox.Show(exc.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.Dispose()
                Exit Sub
            End Try
        End While
        Formatea_Grid()
        Me.GridDatos.Visible = True
        Me.TxtCodigo.Enabled = True
        Me.TxtCodigo.Text = ""
        Me.TxtIp.Text = ""
        Me.TxtServer.Text = ""
        Me.TxtDescripcion.Text = ""
        Me.CrvReporte.Visible = False
        If Permisos >= 4 Then
            Me.CmdInsert.Visible = True
        Else
            Me.CmdInsert.Visible = False
        End If
        Me.CmdReport.Visible = True
        Me.CmdModify.Visible = False
        Me.CmdDelete.Visible = False
        Me.CmdConfig.Visible = False
        Me.TxtCodigo.Focus()
    End Sub
    Private Sub Formatea_Grid()
        With Me.GridDatos
            .BackColor = Color.GhostWhite
            .BackgroundColor = Color.Lavender
            .BorderStyle = BorderStyle.Fixed3D
            .CaptionBackColor = Color.RoyalBlue
            .CaptionFont = New Font("Tahoma", 10.0!, FontStyle.Bold)
            .CaptionForeColor = Color.Bisque
            .Font = New Font("Tahoma", 8.0!)
            .ParentRowsBackColor = Color.Lavender
            .ParentRowsForeColor = Color.MidnightBlue
            .ReadOnly = True
        End With
        Dim grdTableStyle1 As New DataGridTableStyle
        With grdTableStyle1
            .MappingName = "Iq_Oficinas"
        End With
        Dim grdColStyle1 As New DataGridTextBoxColumn
        With grdColStyle1
            .HeaderText = "Codigo"
            .MappingName = "IqOficinas_Codigo"
            .Width = 50
        End With
        Dim grdColStyle2 As New DataGridTextBoxColumn
        With grdColStyle2
            .HeaderText = "Descripcion"
            .MappingName = "IqOficinas_Descripcion"
            .Width = 600
        End With
        Dim grdColStyle3 As New DataGridTextBoxColumn
        With grdColStyle3
            .HeaderText = ""
            .MappingName = "IqOficinas_Consolidacion"
            .Width = 0
        End With
        Dim grdColStyle3b As New DataGridTextBoxColumn
        With grdColStyle3b
            .HeaderText = "Consolidacion"
            .MappingName = "DescOficina"
            .Width = 200
        End With
        Dim grdColStyle4 As New DataGridTextBoxColumn
        With grdColStyle4
            .HeaderText = "Segmento de Red"
            .MappingName = "IqOficinas_IP"
            .Width = 200
        End With
        Dim grdColStyle5 As New DataGridTextBoxColumn
        With grdColStyle5
            .HeaderText = "Servidor Vinculado"
            .MappingName = "IqOficinas_LinkServer"
            .Width = 200
        End With
        grdTableStyle1.GridColumnStyles.AddRange _
             (New DataGridColumnStyle() _
             {grdColStyle1, grdColStyle2, grdColStyle3, grdColStyle3b, grdColStyle4, grdColStyle5})
        Me.GridDatos.TableStyles.Add(grdTableStyle1)
    End Sub
    Private Sub GridDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDatos.DoubleClick
        If Me.GridDatos.VisibleRowCount = 0 Then
            Exit Sub
        End If
        Me.TxtCodigo.Text = Me.GridDatos.Item(Me.GridDatos.CurrentCell.RowNumber, 0)
        Me.TxtDescripcion.Text = Me.GridDatos.Item(Me.GridDatos.CurrentCell.RowNumber, 1)
        Me.CmbOficina.Text = Dictoficinas.Valor(Me.GridDatos.Item(Me.GridDatos.CurrentCell.RowNumber, 2))
        Me.TxtIp.Text = Me.GridDatos.Item(Me.GridDatos.CurrentCell.RowNumber, 4)
        If IsDBNull(Me.GridDatos.Item(Me.GridDatos.CurrentCell.RowNumber, 5)) Then
            Me.TxtServer.Text = ""
        Else
            Me.TxtServer.Text = Me.GridDatos.Item(Me.GridDatos.CurrentCell.RowNumber, 5)
        End If
        Me.TxtCodigo.Enabled = False
        Me.CmdInsert.Visible = False
        If Permisos = 1 Or Permisos = 3 Or Permisos = 5 Or Permisos = 7 Then
            Me.CmdModify.Visible = True
        Else
            Me.CmdModify.Visible = False
        End If
        If Permisos = 2 Or Permisos = 3 Or Permisos = 6 Or Permisos = 7 Then
            Me.CmdDelete.Visible = True
        Else
            Me.CmdDelete.Visible = False
        End If
        If DictAccesos.Valor_Permiso("Iq_0212") <> Nothing Then
            Me.CmdConfig.Visible = True
        Else
            Me.CmdConfig.Visible = False
        End If
    End Sub
    Private Sub Update_Process()
        If Trim(Me.TxtCodigo.Text) = "" Then
            MessageBox.Show("Debe registrar el Codigo de la Oficina", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.TxtCodigo.Focus()
            Exit Sub
        End If
        If Trim(Me.TxtDescripcion.Text) = "" Then
            MessageBox.Show("Debe registrar la Descripción de la Oficina", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.TxtDescripcion.Focus()
            Exit Sub
        End If
        If Trim(Me.CmbOficina.Text) = "" Then
            MessageBox.Show("Debe registrar la Oficina Consolidadora", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.CmbOficina.Focus()
            Exit Sub
        End If
        Select Case File_Action
            Case "A"
                Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
                Try
                    IQ_Cnn.Open()
                    Dim IQ_Cmm As New OleDb.OleDbCommand("Insert Into Iq_Oficinas Values('" + Me.TxtCodigo.Text + "', '" + Me.TxtDescripcion.Text + "', '" & CodigoOficina(Me.CmbOficina.Text) + "', '" & Me.TxtIp.Text & "', '" & Me.TxtServer.Text & "')", IQ_Cnn)
                    Dim RegistrosInsertados As Long = IQ_Cmm.ExecuteNonQuery()
                    IQ_Cnn.Close()
                    MessageBox.Show(RegistrosInsertados.ToString + " Registro(s) fueron insertados satisfactoriamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch exc As Exception
                    Dim Mensaje_Excepcion As String
                    If InStr(UCase(exc.Message), "PRIMARY KEY") > 0 Then
                        MessageBox.Show("EL CODIGO DE OFICINA INGRESADO YA EXISTE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                    Mensaje_Excepcion = exc.Message
                    MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End Try
            Case "M"
                Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
                Try
                    IQ_Cnn.Open()
                    Dim IQ_Cmm As New OleDb.OleDbCommand("Update Iq_Oficinas Set IQOficinas_Descripcion = '" + Me.TxtDescripcion.Text + "', IQOficinas_Consolidacion = '" & CodigoOficina(Me.CmbOficina.Text) & "', IQOficinas_IP = '" + Me.TxtIp.Text + "', IQOficinas_LinkServer = '" + Me.TxtServer.Text + "' Where IQOficinas_Codigo = '" + Me.TxtCodigo.Text + "'", IQ_Cnn)
                    Dim RegistrosModificados As Long = IQ_Cmm.ExecuteNonQuery()
                    IQ_Cnn.Close()
                    MessageBox.Show(RegistrosModificados.ToString + " Registro(s) fueron modificados satisfactoriamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch exc As Exception
                    Dim Mensaje_Excepcion As String
                    Mensaje_Excepcion = exc.Message
                    MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End Try
            Case "B"
                Dim resp_par As String
                resp_par = MessageBox.Show("Está Ud. seguro de eliminar el registro?", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If resp_par = vbCancel Then
                    Exit Sub
                End If
                Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
                Try
                    IQ_Cnn.Open()
                    Dim inst_del As String = ""
                    inst_del = "Delete Iq_Oficinas Where IQOficinas_Codigo = '" + Me.TxtCodigo.Text + "'"
                    Dim IQ_Cmm As New OleDb.OleDbCommand(inst_del, IQ_Cnn)
                    Dim RegistrosEliminados As Long = IQ_Cmm.ExecuteNonQuery()
                    IQ_Cnn.Close()
                    MessageBox.Show(RegistrosEliminados.ToString + " Registro(s) fueron eliminados satisfactoriamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch exc As Exception
                    Dim Mensaje_Excepcion As String
                    Mensaje_Excepcion = exc.Message
                    If InStr(UCase(exc.Message), "REFERENCE CONSTRAINT") > 0 Then
                        MessageBox.Show("EL REGISTRO NO PUEDE SER ELIMINADO PORQUE TIENE INFORMACION DEPENDIENTE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                    MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End Try
        End Select
        Limpiar_Controles()
    End Sub
End Class