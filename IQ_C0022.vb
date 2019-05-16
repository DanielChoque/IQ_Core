Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Public Class IQ_C0022
    Inherits System.Windows.Forms.Form
    Dim Permisos As Integer = 0
    Dim num_nodos_ofic(10) As Integer
    Dim nivel_nodo_ofic As Integer
    Dim indice_nodos_ofic As Integer
    Dim ind_ofic As Integer
    Private DictOficinas As New ColeccionOficinas
    Dim alcance(3) As String

    Public Sub New()
        InitializeComponent()
        Timer1.Enabled = True
        Timer1.Start()
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
    Private Sub CmdExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CmdExit.Click
        IQ_C0000.PicFondo.Visible = True
        Me.Dispose()
    End Sub
    Private Sub Busca_Oficinas(ByVal Codigo As String, ByVal Nodo As Integer, ByVal Nivel As Integer)
        Dim Carga_Coneccion_O2 As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O2.Open()
        Dim Carga_Comando_O2 As New OleDb.OleDbCommand("Select IqOficinas_Codigo, IqOficinas_Descripcion from IQ_Oficinas where IqOficinas_Consolidacion = '" & Codigo & "' order by IqOficinas_Codigo", Carga_Coneccion_O2)
        Dim Carga_Reader_O2 As OleDb.OleDbDataReader = Carga_Comando_O2.ExecuteReader(CommandBehavior.CloseConnection)
        num_nodos_ofic(Nivel) = 0
        While Carga_Reader_O2.Read
            Select Case Nivel
                Case 0
                    Me.TrvOficinas.Nodes(0).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|O:" & Carga_Reader_O2.GetValue(0))
                Case 1
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos_ofic(Nivel - 1)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|O:" & Carga_Reader_O2.GetValue(0))
                Case 2
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos_ofic(0)).Nodes(num_nodos_ofic(1)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|O:" & Carga_Reader_O2.GetValue(0))
                Case 3
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos_ofic(0)).Nodes(num_nodos_ofic(1)).Nodes(num_nodos_ofic(2)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|O:" & Carga_Reader_O2.GetValue(0))
                Case 4
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos_ofic(0)).Nodes(num_nodos_ofic(1)).Nodes(num_nodos_ofic(2)).Nodes(num_nodos_ofic(3)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|O:" & Carga_Reader_O2.GetValue(0))
                Case 5
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos_ofic(0)).Nodes(num_nodos_ofic(1)).Nodes(num_nodos_ofic(2)).Nodes(num_nodos_ofic(3)).Nodes(num_nodos_ofic(4)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|O:" & Carga_Reader_O2.GetValue(0))
                Case 6
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos_ofic(0)).Nodes(num_nodos_ofic(1)).Nodes(num_nodos_ofic(2)).Nodes(num_nodos_ofic(3)).Nodes(num_nodos_ofic(4)).Nodes(num_nodos_ofic(5)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|O:" & Carga_Reader_O2.GetValue(0))
                Case 7
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos_ofic(0)).Nodes(num_nodos_ofic(1)).Nodes(num_nodos_ofic(2)).Nodes(num_nodos_ofic(3)).Nodes(num_nodos_ofic(4)).Nodes(num_nodos_ofic(5)).Nodes(num_nodos_ofic(6)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|O:" & Carga_Reader_O2.GetValue(0))
                Case 8
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos_ofic(0)).Nodes(num_nodos_ofic(1)).Nodes(num_nodos_ofic(2)).Nodes(num_nodos_ofic(3)).Nodes(num_nodos_ofic(4)).Nodes(num_nodos_ofic(5)).Nodes(num_nodos_ofic(6)).Nodes(num_nodos_ofic(7)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|O:" & Carga_Reader_O2.GetValue(0))
                Case 9
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos_ofic(0)).Nodes(num_nodos_ofic(1)).Nodes(num_nodos_ofic(2)).Nodes(num_nodos_ofic(3)).Nodes(num_nodos_ofic(4)).Nodes(num_nodos_ofic(5)).Nodes(num_nodos_ofic(6)).Nodes(num_nodos_ofic(7)).Nodes(num_nodos_ofic(8)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|O:" & Carga_Reader_O2.GetValue(0))
            End Select
            Busca_Oficinas(Carga_Reader_O2.GetValue(0), num_nodos_ofic(Nivel), Nivel + 1)
            num_nodos_ofic(Nivel) += 1
        End While
        Carga_Coneccion_O2.Dispose()
    End Sub
    Private Sub TrvOficinas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrvOficinas.DoubleClick
        Try
            If Me.TrvOficinas.SelectedNode.ForeColor = Color.Green Then
                Me.TrvOficinas.SelectedNode.ForeColor = Color.Black
                Me.LblAplicacion.Text = ""
                alcance(0) = "999999"
                alcance(1) = ""
                alcance(2) = ""
            Else
                Me.TrvOficinas.SelectedNode.ForeColor = Color.Green
                Me.LblAplicacion.Text = Me.TrvOficinas.SelectedNode.Text
                If Trim(Me.TrvOficinas.SelectedNode.Text) = "GLOBAL" Then
                    alcance(0) = "999999"
                    alcance(1) = ""
                    alcance(2) = ""
                Else
                    Dim Pos_Alcance As Integer
                    Pos_Alcance = InStr(Me.TrvOficinas.SelectedNode.Text, "|")
                    If Pos_Alcance > 0 Then
                        Dim tipo_Elem As String = Mid(Me.TrvOficinas.SelectedNode.Text, Pos_Alcance + 1, 1)
                        Dim cod_elem As String = Mid(Me.TrvOficinas.SelectedNode.Text, Pos_Alcance + 3, Len(Me.TrvOficinas.SelectedNode.Text) - (Pos_Alcance) + 2)
                        Select Case tipo_Elem
                            Case "O"
                                alcance(0) = cod_elem
                                alcance(1) = ""
                                alcance(2) = ""
                            Case "A"
                                alcance(0) = ""
                                alcance(1) = "A:" & cod_elem
                                alcance(2) = ""
                            Case "K"
                                alcance(0) = ""
                                alcance(1) = "K:" & cod_elem
                                alcance(2) = ""
                            Case "L"
                                alcance(0) = ""
                                alcance(1) = "L:" & cod_elem
                                alcance(2) = ""
                            Case "P"
                                alcance(0) = ""
                                alcance(1) = ""
                                alcance(2) = cod_elem
                        End Select
                    End If
                End If
                Dim indice_nodo As Integer
                For indice_nodo = 0 To 9
                    num_nodos_ofic(indice_nodo) = 0
                Next
                nivel_nodo_ofic = 0
                If TrvOficinas.Nodes(0).Text <> Me.LblAplicacion.Text Then
                    TrvOficinas.Nodes(0).ForeColor = Color.Black
                End If
                limpia_nodos_ofic(0, nivel_nodo_ofic)
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
    Private Sub limpia_nodos_ofic(ByVal nodo As Integer, ByVal nivel As Integer)
        Select Case nivel
            Case 0
                num_nodos_ofic(0) = 0
                For Each ChildNode As TreeNode In TrvOficinas.Nodes(0).Nodes
                    If ChildNode.Text <> Me.LblAplicacion.Text Then
                        ChildNode.ForeColor = Color.Black
                    End If
                    limpia_nodos_ofic(num_nodos_ofic(0), 1)
                    num_nodos_ofic(0) += 1
                Next
            Case 1
                num_nodos_ofic(1) = 0
                For Each ChildNode As TreeNode In TrvOficinas.Nodes(0).Nodes(num_nodos_ofic(0)).Nodes
                    If ChildNode.Text <> Me.LblAplicacion.Text Then
                        ChildNode.ForeColor = Color.Black
                    End If
                    limpia_nodos_ofic(num_nodos_ofic(1), 2)
                    num_nodos_ofic(1) += 1
                Next
            Case 2
                num_nodos_ofic(2) = 0
                For Each ChildNode As TreeNode In TrvOficinas.Nodes(0).Nodes(num_nodos_ofic(0)).Nodes(num_nodos_ofic(1)).Nodes
                    If ChildNode.Text <> Me.LblAplicacion.Text Then
                        ChildNode.ForeColor = Color.Black
                    End If
                    limpia_nodos_ofic(num_nodos_ofic(2), 3)
                    num_nodos_ofic(2) += 1
                Next
            Case 3
                num_nodos_ofic(3) = 0
                For Each ChildNode As TreeNode In TrvOficinas.Nodes(0).Nodes(num_nodos_ofic(0)).Nodes(num_nodos_ofic(1)).Nodes(num_nodos_ofic(2)).Nodes
                    If ChildNode.Text <> Me.LblAplicacion.Text Then
                        ChildNode.ForeColor = Color.Black
                    End If
                    limpia_nodos_ofic(num_nodos_ofic(3), 4)
                    num_nodos_ofic(3) += 1
                Next
            Case 4
                num_nodos_ofic(4) = 0
                For Each ChildNode As TreeNode In TrvOficinas.Nodes(0).Nodes(num_nodos_ofic(0)).Nodes(num_nodos_ofic(1)).Nodes(num_nodos_ofic(2)).Nodes(num_nodos_ofic(3)).Nodes
                    If ChildNode.Text <> Me.LblAplicacion.Text Then
                        ChildNode.ForeColor = Color.Black
                    End If
                    limpia_nodos_ofic(num_nodos_ofic(4), 5)
                    num_nodos_ofic(4) += 1
                Next
            Case 5
                num_nodos_ofic(5) = 0
                For Each ChildNode As TreeNode In TrvOficinas.Nodes(0).Nodes(num_nodos_ofic(0)).Nodes(num_nodos_ofic(1)).Nodes(num_nodos_ofic(2)).Nodes(num_nodos_ofic(3)).Nodes(num_nodos_ofic(4)).Nodes
                    If ChildNode.Text <> Me.LblAplicacion.Text Then
                        ChildNode.ForeColor = Color.Black
                    End If
                    limpia_nodos_ofic(num_nodos_ofic(5), 6)
                    num_nodos_ofic(5) += 1
                Next
            Case 6
                num_nodos_ofic(6) = 0
                For Each ChildNode As TreeNode In TrvOficinas.Nodes(0).Nodes(num_nodos_ofic(0)).Nodes(num_nodos_ofic(1)).Nodes(num_nodos_ofic(2)).Nodes(num_nodos_ofic(3)).Nodes(num_nodos_ofic(4)).Nodes(num_nodos_ofic(5)).Nodes
                    If ChildNode.Text <> Me.LblAplicacion.Text Then
                        ChildNode.ForeColor = Color.Black
                    End If
                    limpia_nodos_ofic(num_nodos_ofic(6), 7)
                    num_nodos_ofic(6) += 1
                Next
            Case 7
                num_nodos_ofic(7) = 0
                For Each ChildNode As TreeNode In TrvOficinas.Nodes(0).Nodes(num_nodos_ofic(0)).Nodes(num_nodos_ofic(1)).Nodes(num_nodos_ofic(2)).Nodes(num_nodos_ofic(3)).Nodes(num_nodos_ofic(4)).Nodes(num_nodos_ofic(5)).Nodes(num_nodos_ofic(6)).Nodes
                    If ChildNode.Text <> Me.LblAplicacion.Text Then
                        ChildNode.ForeColor = Color.Black
                    End If
                    limpia_nodos_ofic(num_nodos_ofic(7), 8)
                    num_nodos_ofic(7) += 1
                Next
            Case 8
                num_nodos_ofic(8) = 0
                For Each ChildNode As TreeNode In TrvOficinas.Nodes(0).Nodes(num_nodos_ofic(0)).Nodes(num_nodos_ofic(1)).Nodes(num_nodos_ofic(2)).Nodes(num_nodos_ofic(3)).Nodes(num_nodos_ofic(4)).Nodes(num_nodos_ofic(5)).Nodes(num_nodos_ofic(6)).Nodes(num_nodos_ofic(7)).Nodes
                    If ChildNode.Text <> Me.LblAplicacion.Text Then
                        ChildNode.ForeColor = Color.Black
                    End If
                    limpia_nodos_ofic(num_nodos_ofic(8), 9)
                    num_nodos_ofic(8) += 1
                Next
            Case 9
                num_nodos_ofic(9) = 0
                For Each ChildNode As TreeNode In TrvOficinas.Nodes(0).Nodes(num_nodos_ofic(0)).Nodes(num_nodos_ofic(1)).Nodes(num_nodos_ofic(2)).Nodes(num_nodos_ofic(3)).Nodes(num_nodos_ofic(4)).Nodes(num_nodos_ofic(5)).Nodes(num_nodos_ofic(6)).Nodes(num_nodos_ofic(7)).Nodes(num_nodos_ofic(8)).Nodes
                    If ChildNode.Text <> Me.LblAplicacion.Text Then
                        ChildNode.ForeColor = Color.Black
                    End If
                    limpia_nodos_ofic(num_nodos_ofic(9), 10)
                    num_nodos_ofic(9) += 1
                Next
        End Select
    End Sub
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
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
        toolTip1.SetToolTip(CmdPrint, "Reporte")
        toolTip1.SetToolTip(CmdExit, "Salir")
        toolTip1.SetToolTip(CmdExec, "Ejecutar")
        toolTip1.SetToolTip(CmdClean, "Limpiar")
        Me.PnlUpload.Visible = False
        Me.PnlDownload.Visible = False
        Me.RbDownload.Enabled = True
        Me.RbUpload.Enabled = True
        Me.RbDownload.Checked = False
        Me.RbUpload.Checked = False
        num_nodos_ofic(0) = 0
        Me.TrvOficinas.Nodes.Clear()
        If Menu_Parameter <> "A" Then
            Me.TrvOficinas.Nodes.Add("GLOBAL")
            Dim Carga_Coneccion_O As New OleDb.OleDbConnection(Cnn_Central_Server)
            Carga_Coneccion_O.Open()
            Dim Carga_Comando_O As New OleDb.OleDbCommand("Select IqOficinas_Codigo, IqOficinas_Descripcion from IQ_Oficinas where IqOficinas_Consolidacion = '999999' order by IqOficinas_Codigo", Carga_Coneccion_O)
            Dim Carga_Reader_O As OleDb.OleDbDataReader = Carga_Comando_O.ExecuteReader(CommandBehavior.CloseConnection)
            While Carga_Reader_O.Read
                Me.TrvOficinas.Nodes(0).Nodes.Add(Carga_Reader_O.GetValue(1) & Space(500) & "|O:" & Carga_Reader_O.GetValue(0))
                nivel_nodo_ofic = 1
                Busca_Oficinas(Carga_Reader_O.GetValue(0), num_nodos_ofic(0), nivel_nodo_ofic)
                num_nodos_ofic(0) += 1
            End While
            Carga_Coneccion_O.Dispose()
            Me.LblAplicacion.Text = "GLOBAL"
            alcance(0) = "999999"
            alcance(1) = ""
            alcance(2) = ""
        Else
            Dim Carga_Coneccion_O As New OleDb.OleDbConnection(Cnn_Central_Server)
            Carga_Coneccion_O.Open()
            Dim Carga_Comando_O As New OleDb.OleDbCommand("Select IqOficinas_Codigo, IqOficinas_Descripcion from IQ_Oficinas where IqOficinas_Codigo = '" & Computer_Ofic & "' order by IqOficinas_Codigo", Carga_Coneccion_O)
            Dim Carga_Reader_O As OleDb.OleDbDataReader = Carga_Comando_O.ExecuteReader(CommandBehavior.CloseConnection)
            While Carga_Reader_O.Read
                Me.TrvOficinas.Nodes.Add(Carga_Reader_O.GetValue(1) & Space(500) & "|O:" & Carga_Reader_O.GetValue(0))
                nivel_nodo_ofic = 0
                Busca_Oficinas(Carga_Reader_O.GetValue(0), 0, nivel_nodo_ofic)
                Me.LblAplicacion.Text = Carga_Reader_O.GetValue(1)
                alcance(0) = Computer_Ofic
                alcance(1) = ""
                alcance(2) = ""
            End While
            Carga_Coneccion_O.Dispose()
        End If
        Panel_Estado0.Text = ""
        Panel_Estado1.Text = ""
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
        Me.CrvReporte.Visible = False
        Me.CmdClean.Enabled = True
        Me.CmdExec.Enabled = True
        Me.CmdExit.Enabled = True
        Me.CmdPrint.Enabled = True
        Me.TrvOficinas.Enabled = True
        Me.CmdExec.Visible = True
    End Sub
    Private Sub CmdClean_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CmdClean.Click
        If Me.CrvReporte.Visible = True Then
            Me.CrvReporte.Visible = False
            Me.CmdPrint.Enabled = True
        Else
            If Menu_Parameter <> "A" Then
                Me.LblAplicacion.Text = "GLOBAL"
                alcance(0) = "999999"
                alcance(1) = ""
                alcance(2) = ""
            Else
                Me.LblAplicacion.Text = TrvOficinas.Nodes(0).Text
                alcance(0) = Computer_Ofic
                alcance(1) = ""
                alcance(2) = ""
            End If
            TrvOficinas.Nodes(0).ForeColor = Color.Green
            nivel_nodo_ofic = 0
            limpia_nodos_ofic(0, nivel_nodo_ofic)
            Me.TrvOficinas.Enabled = True
            Me.TrvOficinas.CollapseAll()
            Me.PnlDownload.Visible = False
            Me.PnlUpload.Visible = False
            Me.RbDownload.Enabled = True
            Me.RbUpload.Enabled = True
            Me.RbDownload.Checked = False
            Me.RbUpload.Checked = False
            Me.CmdPrint.Visible = True
            Me.CmdExec.Visible = True
            Barra_Estado.Panels(1).Text = ""
            Barra_Estado.Refresh()
            Me.TrvOficinas.Focus()
        End If
    End Sub
    Private Sub CmdPrint_Click(sender As Object, e As EventArgs) Handles CmdPrint.Click
        Dim Codigo As String = ""
        Dim selform As String = ""
        Dim alcance_reporte As String = ""
        If alcance(0) <> "999999" Then
            selform = "({IQ_TransferLog.IQTransfer_Agencia} = '" + alcance(0) + "' or {IQ_Oficinas.IQOficinas_Consolidacion} = '" + alcance(0) + "')"
            alcance_reporte = "OFICINA: "
            Dim Carga_Coneccion_O As New OleDb.OleDbConnection(Cnn_Central_Server)
            Carga_Coneccion_O.Open()
            Dim Carga_Comando_O As New OleDb.OleDbCommand("Select IqOficinas_Descripcion from IQ_Oficinas where IqOficinas_Codigo = '" & alcance(0) & "'", Carga_Coneccion_O)
            Dim Carga_Reader_O As OleDb.OleDbDataReader = Carga_Comando_O.ExecuteReader(CommandBehavior.CloseConnection)
            While Carga_Reader_O.Read
                If IsDBNull(Carga_Reader_O.GetValue(0)) = False Then
                    alcance_reporte = alcance_reporte & Carga_Reader_O.GetValue(0)
                End If
            End While
            Carga_Coneccion_O.Dispose()
        Else
            alcance_reporte = "GLOBAL"
            selform = ""
        End If
        If Me.PnlUpload.Visible = True Then
            If selform <> "" Then
                selform = selform & " And "
            End If
            selform = selform & "{IQ_TransferLog.IQTransfer_Tipo} = 'U'"
            selform = selform & " And {IQ_TransferLog.IQTransfer_Fecha} >= Date (" + Format(Me.DtDesde.Value, "yyyy,MM,dd") + ") "
            selform = selform & " And {IQ_TransferLog.IQTransfer_Hasta} <= Date (" + Format(Me.DtHasta.Value, "yyyy,MM,dd") + ") "
        End If
        If Me.PnlDownload.Visible = True Then
            If selform <> "" Then
                selform = selform & " And "
            End If
            selform = selform & "{IQ_TransferLog.IQTransfer_Tipo} = 'D'"
        End If
        Dim rptlayout As New ReportDocument
        Try
            rptlayout.Load(Disco_Appl & ":\I-Q\IQ_Rpt\IQ_C0022.rpt")
            rptlayout.SetDatabaseLogon(Server_User, Server_Pwd)
            rptlayout.SummaryInfo.ReportTitle = Nombre_Cliente + Chr(10) + Me.Text
            Me.CrvReporte.SelectionFormula = selform
            Dim CrCollection As New CrystalDecisions.Shared.ParameterValues
            Dim CrPvAlcance As New CrystalDecisions.Shared.ParameterDiscreteValue
            CrPvAlcance.Value = alcance_reporte
            CrCollection.Add(CrPvAlcance)
            rptlayout.DataDefinition.ParameterFields("Alcance").ApplyCurrentValues(CrCollection)
            Me.CrvReporte.ReportSource = rptlayout
            Me.CrvReporte.DisplayToolbar = True
            Me.CrvReporte.ShowCloseButton = False
            Me.CrvReporte.Zoom(1)
            Me.CrvReporte.ShowFirstPage()
            Me.CrvReporte.BringToFront()
            Me.CrvReporte.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            Me.CrvReporte.Visible = True
            Me.CmdClean.Enabled = True
            Me.CmdExit.Enabled = True
            Me.CmdPrint.Enabled = False
        Catch exc As Exception
            Dim Mensaje_Excepcion As String
            Mensaje_Excepcion = exc.Message
            Mensaje_Excepcion = "Error Integrado: " + Mensaje_Excepcion
            MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub RbDownload_Click(sender As Object, e As EventArgs) Handles RbDownload.Click, RbUpload.Click
        If Me.RbDownload.Checked = True Then
            Me.PnlDownload.Visible = True
            Me.PnlUpload.Visible = False
            Me.Chk1.Checked = False
            Me.Chk2.Checked = False
            Me.Chk3.Checked = False
            Me.Chk4.Checked = False
            Me.Chk5.Checked = False
            Me.Chk6.Checked = False
            Me.Chk7.Checked = False
            Me.Chk8.Checked = False
            Me.Chk9.Checked = False
            Me.Chk10.Checked = False
            Me.Chk11.Checked = False
            Me.Chk12.Checked = False
            Me.Chk13.Checked = False
            Me.Chk14.Checked = False
            Me.Chk15.Checked = False
            Me.Chk16.Checked = False
            Me.Chk17.Checked = False
            Me.Chk1.Focus()
        ElseIf Me.RbUpload.Checked = True Then
            Me.PnlDownload.Visible = False
            Me.PnlUpload.Visible = True
            Me.DtDesde.Value = DateAdd(DateInterval.Day, -1, DateTime.Today)
            Me.DtHasta.Value = DateAdd(DateInterval.Day, -1, DateTime.Today)
            Me.DtDesde.Focus()
        End If
    End Sub
    Private Sub CmdExec_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CmdExec.Click
        If Me.RbDownload.Checked = True Then
            If Me.Chk1.Checked = False And Me.Chk2.Checked = False And Me.Chk3.Checked = False And Me.Chk4.Checked = False And Me.Chk5.Checked = False And Me.Chk6.Checked = False And Me.Chk7.Checked = False And Me.Chk8.Checked = False And Me.Chk9.Checked = False And Me.Chk10.Checked = False And Me.Chk11.Checked = False And Me.Chk12.Checked = False And Me.Chk13.Checked = False And Me.Chk14.Checked = False And Me.Chk15.Checked = False And Me.Chk16.Checked = False And Me.Chk17.Checked = False Then
                MessageBox.Show("Debe seleccionar por lo menos un tipo de dato a transferir", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If
        If alcance(0) = "999999" Then
            Dim Carga_Coneccion_O2 As New OleDb.OleDbConnection(Cnn_Central_Server)
            Carga_Coneccion_O2.Open()
            Dim Carga_Comando_O2 As New OleDb.OleDbCommand("Select IqOficinas_Codigo, IqOficinas_LInkServer, IqOficinas_Descripcion from IQ_Oficinas where IqOficinas_LinkServer is not null and IqOficinas_LinkServer not like '*%' order by IqOficinas_Codigo", Carga_Coneccion_O2)
            Dim Carga_Reader_O2 As OleDb.OleDbDataReader = Carga_Comando_O2.ExecuteReader(CommandBehavior.CloseConnection)
            While Carga_Reader_O2.Read
                If Trim(Carga_Reader_O2.GetValue(1)) <> "" Then
                    Transfer_Process(Carga_Reader_O2.GetValue(0), Carga_Reader_O2.GetValue(1), Carga_Reader_O2.GetValue(1))
                End If
            End While
            Carga_Coneccion_O2.Dispose()
        Else
            Dim Carga_Coneccion_O2 As New OleDb.OleDbConnection(Cnn_Central_Server)
            Carga_Coneccion_O2.Open()
            Dim Carga_Comando_O2 As New OleDb.OleDbCommand("Select IqOficinas_Codigo, IqOficinas_LInkServer, IqOficinas_Descripcion from IQ_Oficinas where IqOficinas_LinkServer is not null and IqOficinas_LinkServer not like '*%' and (IqOficinas_Codigo = '" & alcance(0) & "' or IqOficinas_COnsolidacion = '" & alcance(0) & "') order by IqOficinas_Codigo", Carga_Coneccion_O2)
            Dim Carga_Reader_O2 As OleDb.OleDbDataReader = Carga_Comando_O2.ExecuteReader(CommandBehavior.CloseConnection)
            While Carga_Reader_O2.Read
                If Trim(Carga_Reader_O2.GetValue(1)) <> "" Then
                    Transfer_Process(Carga_Reader_O2.GetValue(0), Carga_Reader_O2.GetValue(1), Carga_Reader_O2.GetValue(2))
                End If
            End While
            Carga_Coneccion_O2.Dispose()
        End If
        MessageBox.Show("Información transferida satisfactoriamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        CmdClean_Click(CmdExec, e)
    End Sub
    Private Sub Transfer_Process(Oficina As String, Server As String, Desc_Oficina As String)
        Dim Central_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
        Dim CmmCentral As New OleDb.OleDbCommand("", Central_Cnn)
        Dim Tipo_Transfer As String
        CmmCentral.CommandTimeout = 0
        CmmCentral.CommandType = CommandType.StoredProcedure
        CmmCentral.CommandText = "IQ_SpTransfer"
        If Me.RbUpload.Checked = True Then
            Tipo_Transfer = "U"
        Else
            Tipo_Transfer = "D"
        End If
        CmmCentral.Parameters.Add("Direccion", OleDbType.VarChar, 1).Value = Tipo_Transfer
        CmmCentral.Parameters.Add("Oficina", OleDbType.VarChar, 6).Value = Oficina
        CmmCentral.Parameters.Add("Server", OleDbType.VarChar, 50).Value = Server
        CmmCentral.Parameters.Add("Desde", OleDbType.Date).Value = Me.DtDesde.Value
        CmmCentral.Parameters.Add("Hasta", OleDbType.Date).Value = Me.DtHasta.Value
        Dim string_files As String = ""
        If Me.Chk1.Checked = True Then
            string_files = string_files & "X"
        Else
            string_files = string_files & " "
        End If
        If Me.Chk2.Checked = True Then
            string_files = string_files & "X"
        Else
            string_files = string_files & " "
        End If
        If Me.Chk3.Checked = True Then
            string_files = string_files & "X"
        Else
            string_files = string_files & " "
        End If
        If Me.Chk4.Checked = True Then
            string_files = string_files & "X"
        Else
            string_files = string_files & " "
        End If
        If Me.Chk5.Checked = True Then
            string_files = string_files & "X"
        Else
            string_files = string_files & " "
        End If
        If Me.Chk6.Checked = True Then
            string_files = string_files & "X"
        Else
            string_files = string_files & " "
        End If
        If Me.Chk7.Checked = True Then
            string_files = string_files & "X"
        Else
            string_files = string_files & " "
        End If
        If Me.Chk8.Checked = True Then
            string_files = string_files & "X"
        Else
            string_files = string_files & " "
        End If
        If Me.Chk9.Checked = True Then
            string_files = string_files & "X"
        Else
            string_files = string_files & " "
        End If
        If Me.Chk10.Checked = True Then
            string_files = string_files & "X"
        Else
            string_files = string_files & " "
        End If
        If Me.Chk11.Checked = True Then
            string_files = string_files & "X"
        Else
            string_files = string_files & " "
        End If
        If Me.Chk12.Checked = True Then
            string_files = string_files & "X"
        Else
            string_files = string_files & " "
        End If
        If Me.Chk13.Checked = True Then
            string_files = string_files & "X"
        Else
            string_files = string_files & " "
        End If
        If Me.Chk14.Checked = True Then
            string_files = string_files & "X"
        Else
            string_files = string_files & " "
        End If
        If Me.Chk15.Checked = True Then
            string_files = string_files & "X"
        Else
            string_files = string_files & " "
        End If
        If Me.Chk16.Checked = True Then
            string_files = string_files & "X"
        Else
            string_files = string_files & " "
        End If
        If Me.Chk17.Checked = True Then
            string_files = string_files & "X"
        Else
            string_files = string_files & " "
        End If
        CmmCentral.Parameters.Add("File", OleDbType.VarChar, 30).Value = string_files
        Barra_Estado.Panels(1).Text = "Transfiriendo " & Oficina & " - " & Desc_Oficina
        Barra_Estado.Refresh()
        Try
            Central_Cnn.Open()
            CmmCentral.ExecuteNonQuery()
            Central_Cnn.Close()
        Catch exc As Exception
            Dim Mensaje_Excepcion As String
            Mensaje_Excepcion = exc.Message
            Dim instruccion_insert As String = ""
            instruccion_insert = "Insert Into IQ_TransferLog Values('" + Oficina + "', '" + Tipo_Transfer + "', "
            If Tipo_Transfer = "U" Then
                Select Case Server_Collation
                    Case "ymd"
                        instruccion_insert = instruccion_insert & "'" & Format(Me.DtDesde.Value, "yyyy/MM/dd") & "', '" & Format(Me.DtHasta.Value, "yyyy/MM/dd") & "', "
                    Case "ydm"
                        instruccion_insert = instruccion_insert & "'" & Format(Me.DtDesde.Value, "yyyy/dd/MM") & "', '" & Format(Me.DtHasta.Value, "yyyy/dd/MM") & "', "
                    Case "mdy"
                        instruccion_insert = instruccion_insert & "'" & Format(Me.DtDesde.Value, "MM/dd/yyyy") & "', '" & Format(Me.DtHasta.Value, "MM/dd/yyyy") & "', "
                    Case "dmy"
                        instruccion_insert = instruccion_insert & "'" & Format(Me.DtDesde.Value, "dd/MM/yyyy") & "', '" & Format(Me.DtHasta.Value, "dd/MM/yyyy") & "', "
                End Select
            Else
                instruccion_insert = instruccion_insert & "null, null, "
            End If
            instruccion_insert = instruccion_insert & "'" & string_files & "', getdate(), "
            Do While InStr(Mensaje_Excepcion, "'") > 0
                Mid(Mensaje_Excepcion, InStr(Mensaje_Excepcion, "'"), 1) = " "
            Loop
            instruccion_insert = instruccion_insert & "'" & Mensaje_Excepcion & "')"
            Try
                Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
                IQ_Cnn.Open()
                Dim IQ_Cmm As New OleDb.OleDbCommand(instruccion_insert, IQ_Cnn)
                Dim RegistrosInsertados As Long = IQ_Cmm.ExecuteNonQuery()
                IQ_Cnn.Close()
            Catch ex As Exception
                Dim Mensaje_Excepcion2 As String
                Mensaje_Excepcion2 = ex.Message
                MessageBox.Show(Mensaje_Excepcion2, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
            MessageBox.Show("Error Integrado: " + Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
End Class