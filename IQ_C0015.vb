Imports CrystalDecisions.CrystalReports.Engine

Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports

Imports System.IO
Imports System.Net
Imports System.Net.Mail
Public Class IQ_C0015
    Dim Permisos As Integer = 0
    Dim oficinas_select(100) As String
    Dim num_nodos(10) As Integer
    Dim nivel_nodo As Integer
    Dim ind_ofic As Integer
    Dim indice_nodos As Integer
    Private Dictoficinas As New ColeccionOficinas
    Private DictTT As New ColeccionTT
    Private DictEstados As New ColeccionEstados
    Dim alcance(3) As String
    Dim cod_elemAux As String
    Dim listaTT As New System.Windows.Forms.ListBox
    Dim listaEstados As New System.Windows.Forms.ListBox
    Dim vectorHoras() As String = {"", "", "", "", "", "", "", "", "", ""}

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles CmdExit.Click
        IQ_C0000.PicFondo.Visible = True
        Me.Dispose()
    End Sub
    Public Sub New()
        InitializeComponent()
        initHour()
        Timer1.Enabled = True
        Timer1.Start()
    End Sub
    Private Class ColeccionTT
        Inherits System.Collections.DictionaryBase

        Public Sub Add_ColeccionTT(ByVal Key As String, ByVal Item As String)
            Dictionary.Add(Key, Item)
        End Sub

        Public Function Valor(ByVal Key As String) As String
            Valor = Dictionary.Item(Key)
        End Function
    End Class
    Private Function CodigoTT(ByVal Codigo As String) As String
        CodigoTT = ""
        If Me.listaTT.Items.Count = 0 Then
            CodigoTT = ""
        Else
            For Counter_Lista = 1 To Me.listaTT.Items.Count - 1 Step 2
                If Trim(Codigo) = Trim(Me.listaTT.Items.Item(Counter_Lista)) Then
                    CodigoTT = Me.listaTT.Items.Item(Counter_Lista - 1)
                End If
            Next
        End If
    End Function
    Private Class ColeccionOficinas
        Inherits System.Collections.DictionaryBase

        Public Sub Add_ColeccionOficinas(ByVal Key As String, ByVal Item As String)
            Dictionary.Add(Key, Item)
        End Sub

        Public Function Valor(ByVal Key As String) As String
            Valor = Dictionary.Item(Key)
        End Function
    End Class
    Private Class ColeccionEstados
        Inherits System.Collections.DictionaryBase

        Public Sub Add_ColeccionEstados(ByVal Key As String, ByVal Item As String)
            Dictionary.Add(Key, Item)
        End Sub

        Public Function Valor(ByVal Key As String) As String
            Valor = Dictionary.Item(Key)
        End Function
    End Class
    Private Function CodigoEstado(ByVal Codigo As String) As String
        CodigoEstado = ""
        If Me.listaEstados.Items.Count = 0 Then
            CodigoEstado = ""
        Else
            For Counter_Lista = 1 To Me.listaEstados.Items.Count - 1 Step 2
                If Trim(Codigo) = Trim(Me.listaEstados.Items.Item(Counter_Lista)) Then
                    CodigoEstado = Me.listaEstados.Items.Item(Counter_Lista - 1)
                End If
            Next
        End If
    End Function
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
                        cod_elemAux = ""
                        Select Case tipo_Elem
                            Case "O"
                                alcance(0) = cod_elem
                                alcance(1) = ""
                                alcance(2) = ""
                            Case "A"
                                alcance(0) = ""
                                alcance(1) = "A:" & cod_elem
                                alcance(2) = ""
                                cod_elemAux = cod_elem
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
                    num_nodos(indice_nodo) = 0
                Next
                nivel_nodo = 0
                If TrvOficinas.Nodes(0).Text <> Me.LblAplicacion.Text Then
                    TrvOficinas.Nodes(0).ForeColor = Color.Black
                End If
                limpia_nodos(0, nivel_nodo)
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
    Private Sub limpia_nodos(nodo As Integer, nivel As Integer)
        Select Case nivel
            Case 0
                num_nodos(0) = 0
                For Each ChildNode As TreeNode In TrvOficinas.Nodes(0).Nodes
                    If ChildNode.Text <> Me.LblAplicacion.Text Then
                        ChildNode.ForeColor = Color.Black
                    End If
                    limpia_nodos(num_nodos(0), 1)
                    num_nodos(0) += 1
                Next
            Case 1
                num_nodos(1) = 0
                For Each ChildNode As TreeNode In TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes
                    If ChildNode.Text <> Me.LblAplicacion.Text Then
                        ChildNode.ForeColor = Color.Black
                    End If
                    limpia_nodos(num_nodos(1), 2)
                    num_nodos(1) += 1
                Next
            Case 2
                num_nodos(2) = 0
                For Each ChildNode As TreeNode In TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes
                    If ChildNode.Text <> Me.LblAplicacion.Text Then
                        ChildNode.ForeColor = Color.Black
                    End If
                    limpia_nodos(num_nodos(2), 3)
                    num_nodos(2) += 1
                Next
            Case 3
                num_nodos(3) = 0
                For Each ChildNode As TreeNode In TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes
                    If ChildNode.Text <> Me.LblAplicacion.Text Then
                        ChildNode.ForeColor = Color.Black
                    End If
                    limpia_nodos(num_nodos(3), 4)
                    num_nodos(3) += 1
                Next
            Case 4
                num_nodos(4) = 0
                For Each ChildNode As TreeNode In TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes(num_nodos(3)).Nodes
                    If ChildNode.Text <> Me.LblAplicacion.Text Then
                        ChildNode.ForeColor = Color.Black
                    End If
                    limpia_nodos(num_nodos(4), 5)
                    num_nodos(4) += 1
                Next
            Case 5
                num_nodos(5) = 0
                For Each ChildNode As TreeNode In TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes(num_nodos(3)).Nodes(num_nodos(4)).Nodes
                    If ChildNode.Text <> Me.LblAplicacion.Text Then
                        ChildNode.ForeColor = Color.Black
                    End If
                    limpia_nodos(num_nodos(5), 6)
                    num_nodos(5) += 1
                Next
            Case 6
                num_nodos(6) = 0
                For Each ChildNode As TreeNode In TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes(num_nodos(3)).Nodes(num_nodos(4)).Nodes(num_nodos(5)).Nodes
                    If ChildNode.Text <> Me.LblAplicacion.Text Then
                        ChildNode.ForeColor = Color.Black
                    End If
                    limpia_nodos(num_nodos(6), 7)
                    num_nodos(6) += 1
                Next
            Case 7
                num_nodos(7) = 0
                For Each ChildNode As TreeNode In TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes(num_nodos(3)).Nodes(num_nodos(4)).Nodes(num_nodos(5)).Nodes(num_nodos(6)).Nodes
                    If ChildNode.Text <> Me.LblAplicacion.Text Then
                        ChildNode.ForeColor = Color.Black
                    End If
                    limpia_nodos(num_nodos(7), 8)
                    num_nodos(7) += 1
                Next
            Case 8
                num_nodos(8) = 0
                For Each ChildNode As TreeNode In TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes(num_nodos(3)).Nodes(num_nodos(4)).Nodes(num_nodos(5)).Nodes(num_nodos(6)).Nodes(num_nodos(7)).Nodes
                    If ChildNode.Text <> Me.LblAplicacion.Text Then
                        ChildNode.ForeColor = Color.Black
                    End If
                    limpia_nodos(num_nodos(8), 9)
                    num_nodos(8) += 1
                Next
            Case 9
                num_nodos(9) = 0
                For Each ChildNode As TreeNode In TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes(num_nodos(3)).Nodes(num_nodos(4)).Nodes(num_nodos(5)).Nodes(num_nodos(6)).Nodes(num_nodos(7)).Nodes(num_nodos(8)).Nodes
                    If ChildNode.Text <> Me.LblAplicacion.Text Then
                        ChildNode.ForeColor = Color.Black
                    End If
                    limpia_nodos(num_nodos(9), 10)
                    num_nodos(9) += 1
                Next
        End Select
    End Sub
    Private Sub Busca_Oficinas(Codigo As String, Nodo As Integer, Nivel As Integer)
        Dim Carga_Coneccion_O2 As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O2.Open()
        Dim Carga_Comando_O2 As New OleDb.OleDbCommand("Select IqOficinas_Codigo, IqOficinas_Descripcion from IQ_Oficinas where IqOficinas_Consolidacion = '" & Codigo & "' order by IqOficinas_Codigo", Carga_Coneccion_O2)
        Dim Carga_Reader_O2 As OleDb.OleDbDataReader = Carga_Comando_O2.ExecuteReader(CommandBehavior.CloseConnection)
        num_nodos(Nivel) = 0
        While Carga_Reader_O2.Read
            Select Case Nivel
                Case 0
                    Me.TrvOficinas.Nodes(0).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|O:" & Carga_Reader_O2.GetValue(0))
                Case 1
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(Nivel - 1)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|O:" & Carga_Reader_O2.GetValue(0))
                Case 2
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|O:" & Carga_Reader_O2.GetValue(0))
                Case 3
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|O:" & Carga_Reader_O2.GetValue(0))
                Case 4
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes(num_nodos(3)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|O:" & Carga_Reader_O2.GetValue(0))
                Case 5
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes(num_nodos(3)).Nodes(num_nodos(4)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|O:" & Carga_Reader_O2.GetValue(0))
                Case 6
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes(num_nodos(3)).Nodes(num_nodos(4)).Nodes(num_nodos(5)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|O:" & Carga_Reader_O2.GetValue(0))
                Case 7
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes(num_nodos(3)).Nodes(num_nodos(4)).Nodes(num_nodos(5)).Nodes(num_nodos(6)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|O:" & Carga_Reader_O2.GetValue(0))
                Case 8
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes(num_nodos(3)).Nodes(num_nodos(4)).Nodes(num_nodos(5)).Nodes(num_nodos(6)).Nodes(num_nodos(7)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|O:" & Carga_Reader_O2.GetValue(0))
                Case 9
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes(num_nodos(3)).Nodes(num_nodos(4)).Nodes(num_nodos(5)).Nodes(num_nodos(6)).Nodes(num_nodos(7)).Nodes(num_nodos(8)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|O:" & Carga_Reader_O2.GetValue(0))
            End Select
            Busca_Oficinas(Carga_Reader_O2.GetValue(0), num_nodos(Nivel), Nivel + 1)
            Busca_Areas(Carga_Reader_O2.GetValue(0), num_nodos(Nivel), Nivel + 1)
            num_nodos(Nivel) += 1
        End While
        Carga_Coneccion_O2.Dispose()
    End Sub
    Private Sub Busca_Areas(Codigo As String, Nodo As Integer, Nivel As Integer)
        Dim Carga_Coneccion_O2 As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O2.Open()
        Dim Carga_Comando_O2 As New OleDb.OleDbCommand("Select IqAreas_Codigo, IqAreas_Descripcion from IQ_Areas where IqAreas_Oficina = '" & Codigo & "' order by IqAreas_Codigo", Carga_Coneccion_O2)
        Dim Carga_Reader_O2 As OleDb.OleDbDataReader = Carga_Comando_O2.ExecuteReader(CommandBehavior.CloseConnection)
        num_nodos(Nivel) = 0
        While Carga_Reader_O2.Read
            Select Case Nivel
                Case 0
                    Me.TrvOficinas.Nodes(0).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|A:" & Carga_Reader_O2.GetValue(0))
                Case 1
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(Nivel - 1)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|A:" & Carga_Reader_O2.GetValue(0))
                Case 2
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|A:" & Carga_Reader_O2.GetValue(0))
                Case 3
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|A:" & Carga_Reader_O2.GetValue(0))
                Case 4
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes(num_nodos(3)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|A:" & Carga_Reader_O2.GetValue(0))
                Case 5
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes(num_nodos(3)).Nodes(num_nodos(4)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|A:" & Carga_Reader_O2.GetValue(0))
                Case 6
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes(num_nodos(3)).Nodes(num_nodos(4)).Nodes(num_nodos(5)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|A:" & Carga_Reader_O2.GetValue(0))
                Case 7
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes(num_nodos(3)).Nodes(num_nodos(4)).Nodes(num_nodos(5)).Nodes(num_nodos(6)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|A:" & Carga_Reader_O2.GetValue(0))
                Case 8
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes(num_nodos(3)).Nodes(num_nodos(4)).Nodes(num_nodos(5)).Nodes(num_nodos(6)).Nodes(num_nodos(7)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|A:" & Carga_Reader_O2.GetValue(0))
                Case 9
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes(num_nodos(3)).Nodes(num_nodos(4)).Nodes(num_nodos(5)).Nodes(num_nodos(6)).Nodes(num_nodos(7)).Nodes(num_nodos(8)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|A:" & Carga_Reader_O2.GetValue(0))
            End Select
            Busca_Puntos(Carga_Reader_O2.GetValue(0), num_nodos(Nivel), Nivel + 1)
            num_nodos(Nivel) += 1
        End While
        Carga_Coneccion_O2.Dispose()
    End Sub
    Private Sub Busca_Puntos(Codigo As String, Nodo As Integer, Nivel As Integer)
        Dim Carga_Coneccion_O2 As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O2.Open()
        Dim Carga_Comando_O2 As New OleDb.OleDbCommand("Select IqPuntos_Codigo, IqPuntos_Descripcion from IQ_PuntosAtencion where IqPuntos_Area = '" & Codigo & "' order by IqPuntos_Codigo", Carga_Coneccion_O2)
        Dim Carga_Reader_O2 As OleDb.OleDbDataReader = Carga_Comando_O2.ExecuteReader(CommandBehavior.CloseConnection)
        num_nodos(Nivel) = 0
        While Carga_Reader_O2.Read
            Select Case Nivel
                Case 0
                    Me.TrvOficinas.Nodes(0).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|P:" & Carga_Reader_O2.GetValue(0))
                Case 1
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(Nivel - 1)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|P:" & Carga_Reader_O2.GetValue(0))
                Case 2
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|P:" & Carga_Reader_O2.GetValue(0))
                Case 3
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|P:" & Carga_Reader_O2.GetValue(0))
                Case 4
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes(num_nodos(3)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|P:" & Carga_Reader_O2.GetValue(0))
                Case 5
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes(num_nodos(3)).Nodes(num_nodos(4)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|P:" & Carga_Reader_O2.GetValue(0))
                Case 6
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes(num_nodos(3)).Nodes(num_nodos(4)).Nodes(num_nodos(5)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|P:" & Carga_Reader_O2.GetValue(0))
                Case 7
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes(num_nodos(3)).Nodes(num_nodos(4)).Nodes(num_nodos(5)).Nodes(num_nodos(6)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|P:" & Carga_Reader_O2.GetValue(0))
                Case 8
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes(num_nodos(3)).Nodes(num_nodos(4)).Nodes(num_nodos(5)).Nodes(num_nodos(6)).Nodes(num_nodos(7)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|P:" & Carga_Reader_O2.GetValue(0))
                Case 9
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes(num_nodos(3)).Nodes(num_nodos(4)).Nodes(num_nodos(5)).Nodes(num_nodos(6)).Nodes(num_nodos(7)).Nodes(num_nodos(8)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|P:" & Carga_Reader_O2.GetValue(0))
            End Select
            num_nodos(Nivel) += 1
        End While
        Carga_Coneccion_O2.Dispose()
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
        toolTip1.SetToolTip(CmdReport, "Reporte")
        toolTip1.SetToolTip(CmdExit, "Salir")
        toolTip1.SetToolTip(CmdClean, "Limpiar")
        toolTip1.SetToolTip(TrvOficinas, "Alcance del Reporte")
        toolTip1.SetToolTip(CmbTipoTick, "Tipo de Ticket a incluir en el Reporte")
        toolTip1.SetToolTip(CmbEstados, "Estado de Ticket a incluir en el Reporte")
        toolTip1.SetToolTip(DtFechaDesde, "Fecha Inicial del Reporte")
        toolTip1.SetToolTip(DtFechaHasta, "Fecha Final del Reporte")
        toolTip1.SetToolTip(DtHoraDesde, "Hora Inicial del Reporte")
        toolTip1.SetToolTip(DtHoraHasta, "Hora Final del Reporte")
        toolTip1.SetToolTip(DtFechaDesde, "Fecha Inicial del Reporte")
        toolTip1.SetToolTip(RbDiario, "El corte del reporte se hará con caracter diario (donde aplique)")
        toolTip1.SetToolTip(RbSemanal, "El corte del reporte se hará con caracter semanal (donde aplique)")
        toolTip1.SetToolTip(RbMensual, "El corte del reporte se hará con caracter mensual (donde aplique)")
        toolTip1.SetToolTip(RbAnual, "El corte del reporte se hará con caracter anual (donde aplique)")
        toolTip1.SetToolTip(ChkInterno, "En reportes de Demoras, se aplicarán los plazos internos y no los de la ASFI")
        For Each controlito In Panel2.Controls
            If (TypeOf controlito Is RadioButton) Then
                controlito.visible = False
                If controlito.text <> "" Then
                    controlito.visible = True
                    toolTip1.SetToolTip(controlito, controlito.text)
                End If
            End If
        Next controlito
        num_nodos(0) = 0
        Me.TrvOficinas.Nodes.Clear()
        If Menu_Parameter <> "A" Then
            Me.TrvOficinas.Nodes.Add("GLOBAL")
            Dim Carga_Coneccion_O As New OleDb.OleDbConnection(Cnn_Central_Server)
            Carga_Coneccion_O.Open()
            Dim Carga_Comando_O As New OleDb.OleDbCommand("Select IqOficinas_Codigo, IqOficinas_Descripcion from IQ_Oficinas where IqOficinas_Consolidacion = '999999' order by IqOficinas_Codigo", Carga_Coneccion_O)
            Dim Carga_Reader_O As OleDb.OleDbDataReader = Carga_Comando_O.ExecuteReader(CommandBehavior.CloseConnection)
            While Carga_Reader_O.Read
                Me.TrvOficinas.Nodes(0).Nodes.Add(Carga_Reader_O.GetValue(1) & Space(500) & "|O:" & Carga_Reader_O.GetValue(0))
                nivel_nodo = 1
                Busca_Oficinas(Carga_Reader_O.GetValue(0), num_nodos(0), nivel_nodo)
                Busca_Areas(Carga_Reader_O.GetValue(0), num_nodos(0), nivel_nodo)
                num_nodos(0) += 1
            End While
            Me.LblAplicacion.Text = "GLOBAL"
            alcance(0) = "999999"
            alcance(1) = ""
            alcance(2) = ""
            Carga_Coneccion_O.Dispose()
        Else
            Dim Carga_Coneccion_O As New OleDb.OleDbConnection(Cnn_Central_Server)
            Carga_Coneccion_O.Open()
            Dim Carga_Comando_O As New OleDb.OleDbCommand("Select IqOficinas_Codigo, IqOficinas_Descripcion from IQ_Oficinas where IqOficinas_Codigo = '" & Computer_Ofic & "' order by IqOficinas_Codigo", Carga_Coneccion_O)
            Dim Carga_Reader_O As OleDb.OleDbDataReader = Carga_Comando_O.ExecuteReader(CommandBehavior.CloseConnection)
            While Carga_Reader_O.Read
                Me.TrvOficinas.Nodes.Add(Carga_Reader_O.GetValue(1) & Space(500) & "|O:" & Carga_Reader_O.GetValue(0))
                nivel_nodo = 0
                Busca_Oficinas(Carga_Reader_O.GetValue(0), 0, nivel_nodo)
                Busca_Areas(Carga_Reader_O.GetValue(0), 0, nivel_nodo)
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
        Me.listaTT.MultiColumn = True
        Me.listaTT.SelectionMode = SelectionMode.One
        Me.DictTT.Clear()
        Me.CmbTipoTick.Items.Clear()
        Me.listaTT.Items.Clear()
        Me.CmbTipoTick.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipoTick.Sorted = True
        Me.listaTT.BeginUpdate()
        Dim instruccion As String
        instruccion = "Select IqTipTick_Codigo, IqTipTick_Descripcion from Iq_TipoTick group by IqTipTick_Codigo, IqTipTick_Descripcion order by IqTipTick_Codigo, IqTipTick_Descripcion"
        Dim Carga_Coneccion_O2 As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O2.Open()
        Dim Carga_Comando_O2 As New OleDb.OleDbCommand(instruccion, Carga_Coneccion_O2)
        Dim Carga_Reader_O2 As OleDb.OleDbDataReader = Carga_Comando_O2.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O2.Read
            Me.listaTT.Items.Add(Carga_Reader_O2.GetValue(0))
            Me.listaTT.Items.Add(Carga_Reader_O2.GetValue(1) & " - " & Carga_Reader_O2.GetValue(0))
            Me.CmbTipoTick.Items.Add(Carga_Reader_O2.GetValue(1) & " - " & Carga_Reader_O2.GetValue(0))
        End While
        Carga_Coneccion_O2.Dispose()
        Me.CmbTipoTick.Items.Add("")
        Me.listaTT.EndUpdate()
        Me.CmbTipoTick.EndUpdate()
        If Me.listaTT.Items.Count > 0 Then
            For Counter_Lista = 0 To Me.listaTT.Items.Count - 2 Step 2
                Me.DictTT.Add_ColeccionTT(Me.listaTT.Items.Item(Counter_Lista), Me.listaTT.Items.Item(Counter_Lista + 1))
            Next
        End If
        Me.CmbTipoTick.Text = ""
        Me.listaEstados.MultiColumn = True
        Me.listaEstados.SelectionMode = SelectionMode.One
        Me.DictEstados.Clear()
        Me.CmbEstados.Items.Clear()
        Me.listaEstados.Items.Clear()
        Me.CmbEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEstados.Sorted = True
        Me.listaEstados.BeginUpdate()
        Me.listaEstados.Items.Add("N")
        Me.listaEstados.Items.Add("Non Show")
        Me.CmbEstados.Items.Add("Non Show")
        Me.listaEstados.Items.Add("W")
        Me.listaEstados.Items.Add("En Espera")
        Me.CmbEstados.Items.Add("En Espera")
        Me.listaEstados.Items.Add("X")
        Me.listaEstados.Items.Add("Concluido")
        Me.CmbEstados.Items.Add("Concluido")
        Me.listaEstados.Items.Add("R")
        Me.listaEstados.Items.Add("Redireccionado")
        Me.CmbEstados.Items.Add("Redireccionado")
        Me.listaEstados.Items.Add("E")
        Me.listaEstados.Items.Add("Emitido")
        Me.CmbEstados.Items.Add("Emitido")
        Me.listaEstados.Items.Add("A")
        Me.listaEstados.Items.Add("Asignado (Pendiente)")
        Me.CmbEstados.Items.Add("Asignado (Pendiente)")
        Me.listaEstados.Items.Add("P")
        Me.listaEstados.Items.Add("En Atención")
        Me.CmbEstados.Items.Add("En Atención")
        Me.CmbEstados.Items.Add("")
        Me.listaEstados.EndUpdate()
        Me.CmbEstados.EndUpdate()
        If Me.listaEstados.Items.Count > 0 Then
            For Counter_Lista = 0 To Me.listaEstados.Items.Count - 2 Step 2
                Me.DictEstados.Add_ColeccionEstados(Me.listaEstados.Items.Item(Counter_Lista), Me.listaEstados.Items.Item(Counter_Lista + 1))
            Next
        End If
        Me.CmbEstados.Text = ""
        Me.DtFechaDesde.Value = DateAdd(DateInterval.Second, desfase_segundos, Date.Now)
        Me.DtFechaHasta.Value = DateAdd(DateInterval.Second, desfase_segundos, Date.Now)
        Me.DtHoraDesde.Format = DateTimePickerFormat.Custom
        Me.DtHoraDesde.CustomFormat = "HH:mm:ss"
        Me.DtHoraHasta.Format = DateTimePickerFormat.Custom
        Me.DtHoraHasta.CustomFormat = "HH:mm:ss"
        Me.DtHoraDesde.Value = Format(DateAdd(DateInterval.Second, desfase_segundos, Date.Now), "yyyy/MM/dd") & " 00:00:00"
        Me.DtHoraHasta.Value = Format(DateAdd(DateInterval.Second, desfase_segundos, Date.Now), "yyyy/MM/dd") & " 23:59:59"
        Me.RbDiario.Checked = False
        Me.RbAnual.Checked = False
        Me.RbMensual.Checked = False
        Me.RbSemanal.Checked = False
        Me.ChkInterno.Checked = False
        For Each controlito In Panel2.Controls
            If (TypeOf controlito Is RadioButton) Then
                controlito.checked = False
            End If
        Next controlito
        Me.CrvReporte.Visible = False
        Me.CmdExit.Visible = True
        Me.CmdClean.Visible = True
        If Permisos > 0 Then
            Me.CmdReport.Visible = True
        Else
            Me.CmdReport.Visible = False
        End If
    End Sub
    Private Sub CmdClean_Click(sender As Object, e As EventArgs) Handles CmdClean.Click
        If Me.CrvReporte.Visible = True Then
            Me.CmdClean.Enabled = True
            Me.CmdReport.Enabled = True
            Me.CrvReporte.Visible = False
        Else
            Me.CrvReporte.Visible = False
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
            nivel_nodo = 0
            limpia_nodos(0, nivel_nodo)
            Me.TrvOficinas.Enabled = True
            Me.TrvOficinas.CollapseAll()
            Me.CmbTipoTick.Text = ""
            Me.CmbEstados.Text = ""
            Me.RbDiario.Checked = False
            Me.RbAnual.Checked = False
            Me.RbMensual.Checked = False
            Me.RbSemanal.Checked = False
            Me.ChkInterno.Checked = False
            For Each controlito In Panel2.Controls
                If (TypeOf controlito Is RadioButton) Then
                    controlito.checked = False
                End If
            Next controlito
            Try
                Me.DtFechaDesde.Value = DateAdd(DateInterval.Second, desfase_segundos, Date.Now)
                Me.DtFechaHasta.Value = DateAdd(DateInterval.Second, desfase_segundos, Date.Now)
                Me.DtHoraDesde.Value = Format(DateAdd(DateInterval.Second, desfase_segundos, Date.Now), "yyyy/MM/dd") & " 00:00:00"
                Me.DtHoraHasta.Value = Format(DateAdd(DateInterval.Second, desfase_segundos, Date.Now), "yyyy/MM/dd") & " 23:59:59"
            Catch ex As Exception
                Me.DtFechaDesde.Value = DateAdd(DateInterval.Second, 0, Date.Now)
                Me.DtFechaHasta.Value = DateAdd(DateInterval.Second, 0, Date.Now)
                Me.DtHoraDesde.Value = Format(DateAdd(DateInterval.Second, 0, Date.Now), "yyyy/MM/dd") & " 00:00:00"
                Me.DtHoraHasta.Value = Format(DateAdd(DateInterval.Second, 0, Date.Now), "yyyy/MM/dd") & " 23:59:59"
                Exit Try
            End Try
            Me.TrvOficinas.Focus()
        End If
    End Sub
    Private Sub CmdReport_Click(sender As Object, e As EventArgs) Handles CmdReport.Click
        Dim Num_rep As Integer = 0
        Dim NOM_REP As String = ""
        For Each controlito In Panel2.Controls
            If (TypeOf controlito Is RadioButton) Then
                If controlito.checked = True Then
                    Num_rep = CInt(Mid(controlito.name, 3, Len(controlito.name) - 2))
                    NOM_REP = controlito.TEXT
                    Exit For
                End If
            End If
        Next controlito
        If Num_rep = 0 Then
            MessageBox.Show("Debe selecciona el reporte a emitir", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim Codigo As String = ""
        Dim selform As String = ""
        Dim alcance_reporte As String = ""
        If alcance(2) <> "" Then
            alcance_reporte = "PUNTO DE ATENCION:"
            Dim Carga_Coneccion_O As New OleDb.OleDbConnection(Cnn_Central_Server)
            Carga_Coneccion_O.Open()
            Codigo = alcance(2)
            If Num_rep = 33 Then
                selform = "{IQ_Ausencias.IQAusencias_Punto} = '" + Codigo + "' and {IQ_Ausencias.IQAusencias_Justificativo} <> '6c7afada99e4170ca0c400e54c1540bcd334578ff2ec993ef2aa3c771143384f' "
            Else
                selform = "{IQ_Tickets.IQTicket_Punto} = '" + Codigo + "'"
            End If
            Dim Carga_Comando_P As New OleDb.OleDbCommand("Select IqPuntos_Descripcion, IqPuntos_Area from IQ_PuntosAtencion where IqPuntos_Codigo = '" & Codigo & "'", Carga_Coneccion_O)
            Dim Carga_Reader_P As OleDb.OleDbDataReader = Carga_Comando_P.ExecuteReader(CommandBehavior.CloseConnection)
            While Carga_Reader_P.Read
                If IsDBNull(Carga_Reader_P.GetValue(0)) = False Then
                    alcance_reporte = alcance_reporte & " - " & Carga_Reader_P.GetValue(0)
                    Codigo = Carga_Reader_P.GetValue(1)
                End If
            End While
            Carga_Coneccion_O.Close()
            Carga_Coneccion_O.Open()
            Dim Carga_Comando_K As New OleDb.OleDbCommand("Select IqAreas_Descripcion, IqAreas_Oficina from IQ_Areas where IqAreas_Codigo = '" & Codigo & "'", Carga_Coneccion_O)
            Dim Carga_Reader_K As OleDb.OleDbDataReader = Carga_Comando_K.ExecuteReader(CommandBehavior.CloseConnection)
            While Carga_Reader_K.Read
                If IsDBNull(Carga_Reader_K.GetValue(0)) = False Then
                    alcance_reporte = alcance_reporte & " - " & Carga_Reader_K.GetValue(0)
                    Codigo = Carga_Reader_K.GetValue(1)
                End If
            End While
            Carga_Coneccion_O.Close()
            Carga_Coneccion_O.Open()
            Dim Carga_Comando_O As New OleDb.OleDbCommand("Select IqOficinas_Descripcion from IQ_Oficinas where IqOficinas_Codigo = '" & Codigo & "'", Carga_Coneccion_O)
            Dim Carga_Reader_O As OleDb.OleDbDataReader = Carga_Comando_O.ExecuteReader(CommandBehavior.CloseConnection)
            While Carga_Reader_O.Read
                If IsDBNull(Carga_Reader_O.GetValue(0)) = False Then
                    alcance_reporte = alcance_reporte & " - " & Carga_Reader_O.GetValue(0)
                End If
            End While
            Carga_Coneccion_O.Dispose()
        ElseIf Mid(alcance(1), 1, 1) = "A" Then
            alcance_reporte = "AREA:"
            Dim Carga_Coneccion_O As New OleDb.OleDbConnection(Cnn_Central_Server)
            Codigo = Mid(alcance(1), 3, Len(alcance(1)) - 2)
            If Num_rep = 33 Then
                selform = "{IQ_Ausencias.IQAusencias_Area} = '" + Codigo + "'"
            Else
                selform = "{IQ_Tickets.IQTicket_Area} = '" + Codigo + "'"
            End If
            Carga_Coneccion_O.Open()
            Dim Carga_Comando_K As New OleDb.OleDbCommand("Select IqAreas_Descripcion, IqAreas_Oficina from IQ_Areas where IqAreas_Codigo = '" & Codigo & "'", Carga_Coneccion_O)
            Dim Carga_Reader_K As OleDb.OleDbDataReader = Carga_Comando_K.ExecuteReader(CommandBehavior.CloseConnection)
            While Carga_Reader_K.Read
                If IsDBNull(Carga_Reader_K.GetValue(0)) = False Then
                    alcance_reporte = alcance_reporte & " - " & Carga_Reader_K.GetValue(0)
                    Codigo = Carga_Reader_K.GetValue(1)
                End If
            End While
            Carga_Coneccion_O.Close()
            Carga_Coneccion_O.Open()
            Dim Carga_Comando_O As New OleDb.OleDbCommand("Select IqOficinas_Descripcion from IQ_Oficinas where IqOficinas_Codigo = '" & Codigo & "'", Carga_Coneccion_O)
            Dim Carga_Reader_O As OleDb.OleDbDataReader = Carga_Comando_O.ExecuteReader(CommandBehavior.CloseConnection)
            While Carga_Reader_O.Read
                If IsDBNull(Carga_Reader_O.GetValue(0)) = False Then
                    alcance_reporte = alcance_reporte & " - " & Carga_Reader_O.GetValue(0)
                End If
            End While
            Carga_Coneccion_O.Dispose()
        ElseIf alcance(0) <> "999999" Then
            alcance_reporte = "OFICINA: "
            selform = "({IQ_Oficinas.IQoficinas_Codigo} = '" + alcance(0) + "' or {IQ_Oficinas.IQoficinas_Consolidacion} = '" + alcance(0) + "')"
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
        If selform <> "" Then
            selform = selform & " And "
        End If
        If Num_rep = 33 Then
            selform = selform & "{IQ_Ausencias.IQAusencias_Fecha} >= Date (" + Format(Me.DtFechaDesde.Value, "yyyy,MM,dd") + ") "
            selform = selform & " And {IQ_Ausencias.IQAusencias_Fecha} <= Date (" + Format(Me.DtFechaHasta.Value, "yyyy,MM,dd") + ") "
            selform = selform & " And timevalue({IQ_Ausencias.IQAusencias_Fecha}) >= time(" & Format(Me.DtHoraDesde.Value, "HH,mm,ss") & ")"
            selform = selform & " And timevalue({IQ_Ausencias.IQAusencias_Fecha}) <= time(" & Format(Me.DtHoraHasta.Value, "HH,mm,ss") & ")"
            selform = selform & " And NOT ({IQ_Ausencias.IQAusencias_Justificativo}  LIKE '%6c7afada99e4170ca0c400e54c1540bcd334578ff2ec993ef2aa3c771143384f%')"
        Else
            selform = selform & "{IQ_Tickets.IQTicket_Emision} >= Date (" + Format(Me.DtFechaDesde.Value, "yyyy,MM,dd") + ") "
            selform = selform & " And {IQ_Tickets.IQTicket_Emision} <= Date (" + Format(Me.DtFechaHasta.Value, "yyyy,MM,dd") + ") "
            If Trim(Me.CmbTipoTick.Text) <> "" Then
                selform = selform & " And {IQ_Tickets.IQTicket_Tipo} = '" + CodigoTT(Me.CmbTipoTick.Text) + "'"
            End If
            If Trim(Me.CmbEstados.Text) <> "" Then
                selform = selform & " And {IQ_Tickets.IQTicket_Estado} = '" + CodigoEstado(Me.CmbEstados.Text) + "'"
            End If
            selform = selform & " And timevalue({IQ_Tickets.IQTicket_Emision}) >= time(" & Format(Me.DtHoraDesde.Value, "HH,mm,ss") & ")"
            selform = selform & " And timevalue({IQ_Tickets.IQTicket_Emision}) <= time(" & Format(Me.DtHoraHasta.Value, "HH,mm,ss") & ")"
        End If
        If Num_rep = 1 Or Num_rep = 2 Or Num_rep = 3 Or Num_rep = 4 Then
            selform = selform & " And ({IQ_Tickets.IQTicket_Estado} = 'X' or {IQ_Tickets.IQTicket_Estado} = 'N' or {IQ_Tickets.IQTicket_Estado} = 'R')"
        ElseIf Num_rep = 40 Then
            selform = selform & " And ({IQ_Tickets.IQTicket_Estado} = 'X' or {IQ_Tickets.IQTicket_Estado} = 'R')"
        ElseIf Num_rep = 14 Or Num_rep = 25 Or Num_rep = 37 Or Num_rep = 43 Or Num_rep = 44 Or Num_rep = 17 Or Num_rep = 13 Then
            selform = selform & " And ({IQ_Tickets.IQTicket_Punto} <> '')"
            ' ElseIf Num_rep = 31 Then
            '    selform = selform & " And (isnull({@Exceso}) = FALSE AND {@Exceso} > 0)"
            '       ElseIf Num_rep = 30 Or Num_rep = 31 Then
            '           selform = selform & " And (isnull({IQ_Tickets.IQTicket_Atencion}) = false)"
        ElseIf Num_rep = 18 Or Num_rep = 19 Or Num_rep = 20 Or Num_rep = 21 Then
            If Me.ChkInterno.Checked = True Then
                selform = selform & " And (isnull({IQ_Tickets.IQTicket_Asignacion}) = false)  And ({IQ_Tickets.IQTicket_Asignacion} > {IQ_Tickets.IQTicket_Maximo})"
            Else
                selform = selform & " And (isnull({IQ_Tickets.IQTicket_Asignacion}) = false)  And ({IQ_Tickets.IQTicket_Asignacion} > DateAdd ('n', 30, {IQ_Tickets.IQTicket_Emision}))"
            End If
        End If
        Dim rptlayout As New ReportDocument
            Try

            If Num_rep = 17 Or Num_rep = 40 Then
                If Me.RbDiario.Checked = True Then
                    rptlayout.Load(Disco_Appl & ":\I-Q\IQ_Rpt\IQ_C0015_" & Trim(CStr(Num_rep)) & "_D.rpt")
                    rptlayout.SetDatabaseLogon(Server_User, Server_Pwd)
                    rptlayout.SummaryInfo.ReportTitle = Nombre_Cliente + Chr(10) + NOM_REP + Chr(10) + "(Diario)"
                ElseIf Me.RbSemanal.Checked = True Then
                    rptlayout.Load(Disco_Appl & ":\I-Q\IQ_Rpt\IQ_C0015_" & Trim(CStr(Num_rep)) & "_S.rpt")
                    rptlayout.SetDatabaseLogon(Server_User, Server_Pwd)
                    rptlayout.SummaryInfo.ReportTitle = Nombre_Cliente + Chr(10) + NOM_REP + Chr(10) + "(Semanal)"
                Else
                    rptlayout.Load(Disco_Appl & ":\I-Q\IQ_Rpt\IQ_C0015_" & Trim(CStr(Num_rep)) & "_M.rpt")
                    rptlayout.SetDatabaseLogon(Server_User, Server_Pwd)
                    rptlayout.SummaryInfo.ReportTitle = Nombre_Cliente + Chr(10) + NOM_REP + Chr(10) + "(Mensual)"
                End If
            ElseIf Num_rep = 13 Or Num_rep = 18 Or Num_rep = 19 Or Num_rep = 20 Or Num_rep = 21 Then
                If Me.RbDiario.Checked = True Then
                    rptlayout.Load(Disco_Appl & ":\I-Q\IQ_Rpt\IQ_C0015_" & Trim(CStr(Num_rep)) & "_D.rpt")
                    rptlayout.SetDatabaseLogon(Server_User, Server_Pwd)
                    rptlayout.SummaryInfo.ReportTitle = Nombre_Cliente + Chr(10) + NOM_REP + Chr(10) + "(Diario)"
                ElseIf Me.RbSemanal.Checked = True Then
                    rptlayout.Load(Disco_Appl & ":\I-Q\IQ_Rpt\IQ_C0015_" & Trim(CStr(Num_rep)) & "_S.rpt")
                    rptlayout.SetDatabaseLogon(Server_User, Server_Pwd)
                    rptlayout.SummaryInfo.ReportTitle = Nombre_Cliente + Chr(10) + NOM_REP + Chr(10) + "(Semanal)"
                ElseIf Me.RbMensual.Checked = True Then
                    rptlayout.Load(Disco_Appl & ":\I-Q\IQ_Rpt\IQ_C0015_" & Trim(CStr(Num_rep)) & "_M.rpt")
                    rptlayout.SetDatabaseLogon(Server_User, Server_Pwd)
                    rptlayout.SummaryInfo.ReportTitle = Nombre_Cliente + Chr(10) + NOM_REP + Chr(10) + "(Mensual)"
                Else
                    rptlayout.Load(Disco_Appl & ":\I-Q\IQ_Rpt\IQ_C0015_" & Trim(CStr(Num_rep)) & "_A.rpt")
                    rptlayout.SetDatabaseLogon(Server_User, Server_Pwd)
                    rptlayout.SummaryInfo.ReportTitle = Nombre_Cliente + Chr(10) + NOM_REP + Chr(10) + "(Anual)"
                End If
            Else
                rptlayout.Load(Disco_Appl & ":\I-Q\IQ_Rpt\IQ_C0015_" & Trim(CStr(Num_rep)) & ".rpt")
                rptlayout.SetDatabaseLogon(Server_User, Server_Pwd)
                rptlayout.SummaryInfo.ReportTitle = Nombre_Cliente + Chr(10) + NOM_REP
            End If


                Me.CrvReporte.SelectionFormula = selform
                Dim CrCollection As New CrystalDecisions.Shared.ParameterValues
                Dim CrPvAlcance As New CrystalDecisions.Shared.ParameterDiscreteValue
                Dim CrPvFD As New CrystalDecisions.Shared.ParameterDiscreteValue
                Dim CrPvFH As New CrystalDecisions.Shared.ParameterDiscreteValue
                Dim CrPvHD As New CrystalDecisions.Shared.ParameterDiscreteValue
                Dim CrPvHH As New CrystalDecisions.Shared.ParameterDiscreteValue
                Dim CrPvTT As New CrystalDecisions.Shared.ParameterDiscreteValue
                Dim CrPvST As New CrystalDecisions.Shared.ParameterDiscreteValue
            Dim CrPvCorte As New CrystalDecisions.Shared.ParameterDiscreteValue
            Dim CrPvInterno As New CrystalDecisions.Shared.ParameterDiscreteValue
                CrPvAlcance.Value = alcance_reporte
                CrCollection.Add(CrPvAlcance)
            rptlayout.DataDefinition.ParameterFields("Alcance").ApplyCurrentValues(CrCollection)
                CrPvFD.Value = Me.DtFechaDesde.Value
                CrCollection.Add(CrPvFD)
                rptlayout.DataDefinition.ParameterFields("FechaDesde").ApplyCurrentValues(CrCollection)
                CrPvFH.Value = Me.DtFechaHasta.Value
                CrCollection.Add(CrPvFH)
                rptlayout.DataDefinition.ParameterFields("FechaHasta").ApplyCurrentValues(CrCollection)
            CrPvHD.Value = Format(Me.DtHoraDesde.Value, "HH:mm:ss")
                CrCollection.Add(CrPvHD)
                rptlayout.DataDefinition.ParameterFields("HoraDesde").ApplyCurrentValues(CrCollection)
                CrPvHH.Value = Format(Me.DtHoraHasta.Value, "HH:mm:ss")
                CrCollection.Add(CrPvHH)
                rptlayout.DataDefinition.ParameterFields("HoraHasta").ApplyCurrentValues(CrCollection)

            If Trim(CmbTipoTick.Text) = "" Then
                CrPvTT.Value = "Todos"
            Else
                CrPvTT.Value = CmbTipoTick.Text
            End If
                CrCollection.Add(CrPvTT)
                rptlayout.DataDefinition.ParameterFields("TipoTicket").ApplyCurrentValues(CrCollection)

            If Trim(CmbEstados.Text) = "" Then
                CrPvST.Value = "Todos"
            Else
                CrPvST.Value = CmbEstados.Text
            End If
                CrCollection.Add(CrPvST)
                rptlayout.DataDefinition.ParameterFields("Estado").ApplyCurrentValues(CrCollection)

            If Me.RbDiario.Checked = True Then
                CrPvCorte.Value = "D"
            ElseIf Me.RbSemanal.Checked = True Then
                CrPvCorte.Value = "S"
            ElseIf Me.RbMensual.Checked = True Then
                CrPvCorte.Value = "M"
            Else
                CrPvCorte.Value = "A"
            End If
                CrCollection.Add(CrPvCorte)
            rptlayout.DataDefinition.ParameterFields("Corte").ApplyCurrentValues(CrCollection)
            If Num_rep = 18 Or Num_rep = 19 Or Num_rep = 20 Or Num_rep = 21 Or Num_rep = 31 Then
                If Me.ChkInterno.Checked = True Then
                    CrPvInterno.Value = "S"
                Else
                    CrPvInterno.Value = "N"
                End If
                CrCollection.Add(CrPvInterno)
                rptlayout.DataDefinition.ParameterFields("Interno").ApplyCurrentValues(CrCollection)
            End If
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
                Me.CmdReport.Enabled = False
            Catch exc As Exception
                Dim Mensaje_Excepcion As String
                Mensaje_Excepcion = exc.Message
                Mensaje_Excepcion = "Error Integrado: " + Mensaje_Excepcion
                MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
         'MsgBox("0:" & alcance(0) & "\n1:" & alcance(1) & "\n2:" & alcance(2) & " \ncod:" & cod_elemAux)
        If alcance(0) <> "" And alcance(0) <> "999999" Then
            'MsgBox("alcance(0):" & alcance(0))
            s("ReporteOficina", "" + alcance(0))
        ElseIf alcance(1) <> "" Then
            s("ReporteArea", "" + cod_elemAux)
            'MsgBox(" AREa alcance(1):" & cod_elemAux)ReporteVentanilla
        ElseIf alcance(2) <> "" Then
            'MsgBox("Ventanilla alcance(2):" & alcance(2))
            s("ReporteVentanilla", "" + alcance(2))
        Else
            MsgBox("Seleccione un área, oficina o ventanilla para poder emitir el reporte. ")
        End If
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs)
        MsgBox("0:" & alcance(0) & " 1:" & alcance(1) & " 2:" & alcance(2) & " cod:" & cod_elemAux)
        Dim cryRpt As New ReportDocument
        cryRpt.Load(Disco_Appl & ":\I-Q\IQ_Rpt\Prueba.rpt")
        cryRpt.SetParameterValue("R_ID", "203000001000006")
        cryRpt.SetParameterValue("R_DateIni", "01/06/2016")
        cryRpt.SetParameterValue("R_DateEnd", "30/06/2017")
        cryRpt.SetParameterValue("R_Ticket", "SAC")
        cryRpt.SetParameterValue("MiParametro", "Daniel Choque Canaviri")
        cryRpt.SetDatabaseLogon("sa", "as")
        CrvReporte.ReportSource = cryRpt

        CrvReporte.Refresh()

        Try
            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New  _
            DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
            CrDiskFileDestinationOptions.DiskFileName = _
                                        "C:\IQ\crystalExport.pdf"
            CrExportOptions = cryRpt.ExportOptions
            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With
            cryRpt.Export()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
       
    End Sub
    Private Sub s(name As String, ID As String)
        Dim rpt As New ReportDocument
        rpt.Load(Disco_Appl & ":\I-Q\IQ_Rpt\" & name & ".rpt")
        rpt.SetParameterValue("R_ID", "" + ID)
        rpt.SetParameterValue("M_ID", "" + ID)
        rpt.SetParameterValue("R_DateIni", Format(Me.DtFechaDesde.Value, "Short Date"))
        rpt.SetParameterValue("R_DateEnd", Format(Me.DtFechaHasta.Value, "Short Date"))
        rpt.SetParameterValue("MiParametro", "" + txtName.Text)
        'rpt.SetDatabaseLogon("sa", "as")
        rpt.SetDatabaseLogon(Server_User, Server_Pwd)
        Me.CrvReporte.ReportSource = rpt
        Me.CrvReporte.DisplayToolbar = True
        Me.CrvReporte.ShowCloseButton = False
        Me.CrvReporte.ShowFirstPage()
        Me.CrvReporte.BringToFront()
        Me.CrvReporte.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.CrvReporte.Visible = True
    End Sub
    Private Sub initHour()
        DtHoraDesde2.Visible = False
        DtHoraDesde3.Visible = False
        DtHoraDesde4.Visible = False
        DtHoraHasta2.Visible = False
        DtHoraHasta3.Visible = False
        DtHoraHasta4.Visible = False
        btnGenerar.Visible = False
        DtHoraDesde.Value = New DateTime(2019, 1, 1, 0, 0, 0)
        DtHoraHasta.Value = New DateTime(2019, 1, 1, 23, 59, 59)
    End Sub
    Private Sub enableHour()
        DtHoraDesde2.Visible = True
        DtHoraDesde3.Visible = True
        DtHoraDesde4.Visible = True
        'Dim d As Date = Me.DateTimePicker1.Value
        Dim newDate As Date = Date.Now.AddHours(2)
        btnGenerar.Visible = True

        DtHoraDesde.Value = New DateTime(2019, 1, 1, 7, 30, 0)
        DtHoraDesde2.Value = New DateTime(2019, 1, 1, 8, 30, 0)
        DtHoraDesde3.Value = New DateTime(2019, 1, 1, 12, 30, 0)
        DtHoraDesde4.Value = New DateTime(2019, 1, 1, 14, 30, 0)

        DtHoraHasta2.Visible = True
        DtHoraHasta3.Visible = True
        DtHoraHasta4.Visible = True

        DtHoraHasta.Value = New DateTime(2019, 1, 1, 8, 29, 59)
        DtHoraHasta2.Value = New DateTime(2019, 1, 1, 12, 29, 59)
        DtHoraHasta3.Value = New DateTime(2019, 1, 1, 14, 29, 59)
        DtHoraHasta4.Value = New DateTime(2019, 1, 1, 18, 30, 0)
       

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If Me.CheckBox1.Checked Then
            enableHour()
        Else
            initHour()
        End If
    End Sub
    Private Sub repor(horaDesde As String, horaHasta As String, direct As String)
        Dim Num_rep As Integer = 0
        Dim NOM_REP As String = ""
        For Each controlito In Panel2.Controls
            If (TypeOf controlito Is RadioButton) Then
                If controlito.checked = True Then
                    Num_rep = CInt(Mid(controlito.name, 3, Len(controlito.name) - 2))
                    NOM_REP = controlito.TEXT
                    Exit For
                End If
            End If
        Next controlito
        If Num_rep = 0 Then
            MessageBox.Show("Debe selecciona el reporte a emitir", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim Codigo As String = ""
        Dim selform As String = ""
        Dim alcance_reporte As String = ""
        If alcance(2) <> "" Then
            alcance_reporte = "PUNTO DE ATENCION:"
            Dim Carga_Coneccion_O As New OleDb.OleDbConnection(Cnn_Central_Server)
            Carga_Coneccion_O.Open()
            Codigo = alcance(2)
            If Num_rep = 33 Then
                selform = "{IQ_Ausencias.IQAusencias_Punto} = '" + Codigo + "'"
            Else
                selform = "{IQ_Tickets.IQTicket_Punto} = '" + Codigo + "'"
            End If
            Dim Carga_Comando_P As New OleDb.OleDbCommand("Select IqPuntos_Descripcion, IqPuntos_Area from IQ_PuntosAtencion where IqPuntos_Codigo = '" & Codigo & "'", Carga_Coneccion_O)
            Dim Carga_Reader_P As OleDb.OleDbDataReader = Carga_Comando_P.ExecuteReader(CommandBehavior.CloseConnection)
            While Carga_Reader_P.Read
                If IsDBNull(Carga_Reader_P.GetValue(0)) = False Then
                    alcance_reporte = alcance_reporte & " - " & Carga_Reader_P.GetValue(0)
                    Codigo = Carga_Reader_P.GetValue(1)
                End If
            End While
            Carga_Coneccion_O.Close()
            Carga_Coneccion_O.Open()
            Dim Carga_Comando_K As New OleDb.OleDbCommand("Select IqAreas_Descripcion, IqAreas_Oficina from IQ_Areas where IqAreas_Codigo = '" & Codigo & "'", Carga_Coneccion_O)
            Dim Carga_Reader_K As OleDb.OleDbDataReader = Carga_Comando_K.ExecuteReader(CommandBehavior.CloseConnection)
            While Carga_Reader_K.Read
                If IsDBNull(Carga_Reader_K.GetValue(0)) = False Then
                    alcance_reporte = alcance_reporte & " - " & Carga_Reader_K.GetValue(0)
                    Codigo = Carga_Reader_K.GetValue(1)
                End If
            End While
            Carga_Coneccion_O.Close()
            Carga_Coneccion_O.Open()
            Dim Carga_Comando_O As New OleDb.OleDbCommand("Select IqOficinas_Descripcion from IQ_Oficinas where IqOficinas_Codigo = '" & Codigo & "'", Carga_Coneccion_O)
            Dim Carga_Reader_O As OleDb.OleDbDataReader = Carga_Comando_O.ExecuteReader(CommandBehavior.CloseConnection)
            While Carga_Reader_O.Read
                If IsDBNull(Carga_Reader_O.GetValue(0)) = False Then
                    alcance_reporte = alcance_reporte & " - " & Carga_Reader_O.GetValue(0)
                End If
            End While
            Carga_Coneccion_O.Dispose()
        ElseIf Mid(alcance(1), 1, 1) = "A" Then
            alcance_reporte = "AREA:"
            Dim Carga_Coneccion_O As New OleDb.OleDbConnection(Cnn_Central_Server)
            Codigo = Mid(alcance(1), 3, Len(alcance(1)) - 2)
            If Num_rep = 33 Then
                selform = "{IQ_Ausencias.IQAusencias_Area} = '" + Codigo + "'"
            Else
                selform = "{IQ_Tickets.IQTicket_Area} = '" + Codigo + "'"
            End If
            Carga_Coneccion_O.Open()
            Dim Carga_Comando_K As New OleDb.OleDbCommand("Select IqAreas_Descripcion, IqAreas_Oficina from IQ_Areas where IqAreas_Codigo = '" & Codigo & "'", Carga_Coneccion_O)
            Dim Carga_Reader_K As OleDb.OleDbDataReader = Carga_Comando_K.ExecuteReader(CommandBehavior.CloseConnection)
            While Carga_Reader_K.Read
                If IsDBNull(Carga_Reader_K.GetValue(0)) = False Then
                    alcance_reporte = alcance_reporte & " - " & Carga_Reader_K.GetValue(0)
                    Codigo = Carga_Reader_K.GetValue(1)
                End If
            End While
            Carga_Coneccion_O.Close()
            Carga_Coneccion_O.Open()
            Dim Carga_Comando_O As New OleDb.OleDbCommand("Select IqOficinas_Descripcion from IQ_Oficinas where IqOficinas_Codigo = '" & Codigo & "'", Carga_Coneccion_O)
            Dim Carga_Reader_O As OleDb.OleDbDataReader = Carga_Comando_O.ExecuteReader(CommandBehavior.CloseConnection)
            While Carga_Reader_O.Read
                If IsDBNull(Carga_Reader_O.GetValue(0)) = False Then
                    alcance_reporte = alcance_reporte & " - " & Carga_Reader_O.GetValue(0)
                End If
            End While
            Carga_Coneccion_O.Dispose()
        ElseIf alcance(0) <> "999999" Then
            alcance_reporte = "OFICINA: "
            selform = "({IQ_Oficinas.IQoficinas_Codigo} = '" + alcance(0) + "' or {IQ_Oficinas.IQoficinas_Consolidacion} = '" + alcance(0) + "')"
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
        If selform <> "" Then
            selform = selform & " And "
        End If
        If Num_rep = 33 Then
            selform = selform & "{IQ_Ausencias.IQAusencias_Fecha} >= Date (" + Format(Me.DtFechaDesde.Value, "yyyy,MM,dd") + ") "
            selform = selform & " And {IQ_Ausencias.IQAusencias_Fecha} <= Date (" + Format(Me.DtFechaHasta.Value, "yyyy,MM,dd") + ") "
            selform = selform & " And timevalue({IQ_Ausencias.IQAusencias_Fecha}) >= time(" & horaDesde & ")"
            selform = selform & " And timevalue({IQ_Ausencias.IQAusencias_Fecha}) <= time(" & horaHasta & ")"
        Else
            selform = selform & "{IQ_Tickets.IQTicket_Emision} >= Date (" + Format(Me.DtFechaDesde.Value, "yyyy,MM,dd") + ") "
            selform = selform & " And {IQ_Tickets.IQTicket_Emision} <= Date (" + Format(Me.DtFechaHasta.Value, "yyyy,MM,dd") + ") "
            If Trim(Me.CmbTipoTick.Text) <> "" Then
                selform = selform & " And {IQ_Tickets.IQTicket_Tipo} = '" + CodigoTT(Me.CmbTipoTick.Text) + "'"
            End If
            If Trim(Me.CmbEstados.Text) <> "" Then
                selform = selform & " And {IQ_Tickets.IQTicket_Estado} = '" + CodigoEstado(Me.CmbEstados.Text) + "'"
            End If
            selform = selform & " And timevalue({IQ_Tickets.IQTicket_Emision}) >= time(" & horaDesde & ")"
            selform = selform & " And timevalue({IQ_Tickets.IQTicket_Emision}) <= time(" & horaHasta & ")"
        End If
        If Num_rep = 1 Or Num_rep = 2 Or Num_rep = 3 Or Num_rep = 4 Then
            selform = selform & " And ({IQ_Tickets.IQTicket_Estado} = 'X' or {IQ_Tickets.IQTicket_Estado} = 'N' or {IQ_Tickets.IQTicket_Estado} = 'R')"
        ElseIf Num_rep = 40 Then
            selform = selform & " And ({IQ_Tickets.IQTicket_Estado} = 'X' or {IQ_Tickets.IQTicket_Estado} = 'R')"
        ElseIf Num_rep = 14 Or Num_rep = 25 Or Num_rep = 37 Or Num_rep = 43 Or Num_rep = 44 Or Num_rep = 17 Or Num_rep = 13 Then
            selform = selform & " And ({IQ_Tickets.IQTicket_Punto} <> '')"
            ' ElseIf Num_rep = 31 Then
            '    selform = selform & " And (isnull({@Exceso}) = FALSE AND {@Exceso} > 0)"
            '       ElseIf Num_rep = 30 Or Num_rep = 31 Then
            '           selform = selform & " And (isnull({IQ_Tickets.IQTicket_Atencion}) = false)"
        ElseIf Num_rep = 18 Or Num_rep = 19 Or Num_rep = 20 Or Num_rep = 21 Then
            If Me.ChkInterno.Checked = True Then
                selform = selform & " And (isnull({IQ_Tickets.IQTicket_Asignacion}) = false)  And ({IQ_Tickets.IQTicket_Asignacion} > {IQ_Tickets.IQTicket_Maximo})"
            Else
                selform = selform & " And (isnull({IQ_Tickets.IQTicket_Asignacion}) = false)  And ({IQ_Tickets.IQTicket_Asignacion} > DateAdd ('n', 30, {IQ_Tickets.IQTicket_Emision}))"
            End If
        End If
        Dim rptlayout As New ReportDocument
        Try

            If Num_rep = 17 Or Num_rep = 40 Then
                If Me.RbDiario.Checked = True Then
                    rptlayout.Load(Disco_Appl & ":\I-Q\IQ_Rpt\IQ_C0015_" & Trim(CStr(Num_rep)) & "_D.rpt")
                    rptlayout.SetDatabaseLogon(Server_User, Server_Pwd)
                    rptlayout.SummaryInfo.ReportTitle = Nombre_Cliente + Chr(10) + NOM_REP + Chr(10) + "(Diario)"
                ElseIf Me.RbSemanal.Checked = True Then
                    rptlayout.Load(Disco_Appl & ":\I-Q\IQ_Rpt\IQ_C0015_" & Trim(CStr(Num_rep)) & "_S.rpt")
                    rptlayout.SetDatabaseLogon(Server_User, Server_Pwd)
                    rptlayout.SummaryInfo.ReportTitle = Nombre_Cliente + Chr(10) + NOM_REP + Chr(10) + "(Semanal)"
                Else
                    rptlayout.Load(Disco_Appl & ":\I-Q\IQ_Rpt\IQ_C0015_" & Trim(CStr(Num_rep)) & "_M.rpt")
                    rptlayout.SetDatabaseLogon(Server_User, Server_Pwd)
                    rptlayout.SummaryInfo.ReportTitle = Nombre_Cliente + Chr(10) + NOM_REP + Chr(10) + "(Mensual)"
                End If
            ElseIf Num_rep = 13 Or Num_rep = 18 Or Num_rep = 19 Or Num_rep = 20 Or Num_rep = 21 Then
                If Me.RbDiario.Checked = True Then
                    rptlayout.Load(Disco_Appl & ":\I-Q\IQ_Rpt\IQ_C0015_" & Trim(CStr(Num_rep)) & "_D.rpt")
                    rptlayout.SetDatabaseLogon(Server_User, Server_Pwd)
                    rptlayout.SummaryInfo.ReportTitle = Nombre_Cliente + Chr(10) + NOM_REP + Chr(10) + "(Diario)"
                ElseIf Me.RbSemanal.Checked = True Then
                    rptlayout.Load(Disco_Appl & ":\I-Q\IQ_Rpt\IQ_C0015_" & Trim(CStr(Num_rep)) & "_S.rpt")
                    rptlayout.SetDatabaseLogon(Server_User, Server_Pwd)
                    rptlayout.SummaryInfo.ReportTitle = Nombre_Cliente + Chr(10) + NOM_REP + Chr(10) + "(Semanal)"
                ElseIf Me.RbMensual.Checked = True Then
                    rptlayout.Load(Disco_Appl & ":\I-Q\IQ_Rpt\IQ_C0015_" & Trim(CStr(Num_rep)) & "_M.rpt")
                    rptlayout.SetDatabaseLogon(Server_User, Server_Pwd)
                    rptlayout.SummaryInfo.ReportTitle = Nombre_Cliente + Chr(10) + NOM_REP + Chr(10) + "(Mensual)"
                Else
                    rptlayout.Load(Disco_Appl & ":\I-Q\IQ_Rpt\IQ_C0015_" & Trim(CStr(Num_rep)) & "_A.rpt")
                    rptlayout.SetDatabaseLogon(Server_User, Server_Pwd)
                    rptlayout.SummaryInfo.ReportTitle = Nombre_Cliente + Chr(10) + NOM_REP + Chr(10) + "(Anual)"
                End If
            Else
                rptlayout.Load(Disco_Appl & ":\I-Q\IQ_Rpt\IQ_C0015_" & Trim(CStr(Num_rep)) & ".rpt")
                rptlayout.SetDatabaseLogon(Server_User, Server_Pwd)
                rptlayout.SummaryInfo.ReportTitle = Nombre_Cliente + Chr(10) + NOM_REP
            End If


            Me.CrvReporte.SelectionFormula = selform
            Dim CrCollection As New CrystalDecisions.Shared.ParameterValues
            Dim CrPvAlcance As New CrystalDecisions.Shared.ParameterDiscreteValue
            Dim CrPvFD As New CrystalDecisions.Shared.ParameterDiscreteValue
            Dim CrPvFH As New CrystalDecisions.Shared.ParameterDiscreteValue
            Dim CrPvHD As New CrystalDecisions.Shared.ParameterDiscreteValue
            Dim CrPvHH As New CrystalDecisions.Shared.ParameterDiscreteValue
            Dim CrPvTT As New CrystalDecisions.Shared.ParameterDiscreteValue
            Dim CrPvST As New CrystalDecisions.Shared.ParameterDiscreteValue
            Dim CrPvCorte As New CrystalDecisions.Shared.ParameterDiscreteValue
            Dim CrPvInterno As New CrystalDecisions.Shared.ParameterDiscreteValue
            CrPvAlcance.Value = alcance_reporte
            CrCollection.Add(CrPvAlcance)
            rptlayout.DataDefinition.ParameterFields("Alcance").ApplyCurrentValues(CrCollection)
            CrPvFD.Value = Me.DtFechaDesde.Value
            CrCollection.Add(CrPvFD)
            rptlayout.DataDefinition.ParameterFields("FechaDesde").ApplyCurrentValues(CrCollection)
            CrPvFH.Value = Me.DtFechaHasta.Value
            CrCollection.Add(CrPvFH)
            rptlayout.DataDefinition.ParameterFields("FechaHasta").ApplyCurrentValues(CrCollection)
            CrPvHD.Value = Replace(horaDesde, ",", ":")
            'Format(Me.DtHoraDesde2.Value, "HH:mm:ss")
            CrCollection.Add(CrPvHD)
            rptlayout.DataDefinition.ParameterFields("HoraDesde").ApplyCurrentValues(CrCollection)
            CrPvHH.Value = Replace(horaHasta, ",", ":")
                'Format(Me.DtHoraHasta2.Value, "HH:mm:ss")
            CrCollection.Add(CrPvHH)
            rptlayout.DataDefinition.ParameterFields("HoraHasta").ApplyCurrentValues(CrCollection)

            If Trim(CmbTipoTick.Text) = "" Then
                CrPvTT.Value = "Todos"
            Else
                CrPvTT.Value = CmbTipoTick.Text
            End If
            CrCollection.Add(CrPvTT)
            rptlayout.DataDefinition.ParameterFields("TipoTicket").ApplyCurrentValues(CrCollection)

            If Trim(CmbEstados.Text) = "" Then
                CrPvST.Value = "Todos"
            Else
                CrPvST.Value = CmbEstados.Text
            End If
            CrCollection.Add(CrPvST)
            rptlayout.DataDefinition.ParameterFields("Estado").ApplyCurrentValues(CrCollection)

            If Me.RbDiario.Checked = True Then
                CrPvCorte.Value = "D"
            ElseIf Me.RbSemanal.Checked = True Then
                CrPvCorte.Value = "S"
            ElseIf Me.RbMensual.Checked = True Then
                CrPvCorte.Value = "M"
            Else
                CrPvCorte.Value = "A"
            End If
            CrCollection.Add(CrPvCorte)
            rptlayout.DataDefinition.ParameterFields("Corte").ApplyCurrentValues(CrCollection)
            If Num_rep = 18 Or Num_rep = 19 Or Num_rep = 20 Or Num_rep = 21 Or Num_rep = 31 Then
                If Me.ChkInterno.Checked = True Then
                    CrPvInterno.Value = "S"
                Else
                    CrPvInterno.Value = "N"
                End If
                CrCollection.Add(CrPvInterno)
                rptlayout.DataDefinition.ParameterFields("Interno").ApplyCurrentValues(CrCollection)
            End If
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
            Me.CmdReport.Enabled = False
        Catch exc As Exception
            Dim Mensaje_Excepcion As String
            Mensaje_Excepcion = exc.Message
            Mensaje_Excepcion = "Error Integrado: " + Mensaje_Excepcion
            MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
        Dim regDate As Date = Date.Now()
        Dim strDate As String = regDate.ToString("ddMMMyyyy")
        Dim todaysdate As String = String.Format("{0:dd/MM/yyyy}", DateTime.Now)
        ' MsgBox(DateTime.Now.ToString("yyyy-MM-dd") + "_" + DateTime.Now.ToString("HH.mm.ss"))
        'Dim direct As String

        Try
            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New  _
            DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
            CrDiskFileDestinationOptions.DiskFileName = _
                                        Disco_Appl & ":\I-Q\Reporte\" & direct & "\crystalExport" & Replace(horaDesde, ",", ".") & "_" & Replace(horaHasta, ",", ".") & ".pdf"
            CrExportOptions = rptlayout.ExportOptions
            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With
            rptlayout.Export()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        'repor("", "", "", "")
        Dim direct As String
        direct = DateTime.Now.ToString("yyyy-MM-dd") + "_" + DateTime.Now.ToString("HH.mm.ss")
        MkDir(Disco_Appl & ":\I-Q\Reporte\" + direct)

        vectorHoras(0) = Format(Me.DtHoraDesde.Value, "HH,mm,ss")
        vectorHoras(1) = Format(Me.DtHoraHasta.Value, "HH,mm,ss")
        vectorHoras(2) = Format(Me.DtHoraDesde2.Value, "HH,mm,ss")
        vectorHoras(3) = Format(Me.DtHoraHasta2.Value, "HH,mm,ss")
        vectorHoras(4) = Format(Me.DtHoraDesde3.Value, "HH,mm,ss")
        vectorHoras(5) = Format(Me.DtHoraHasta3.Value, "HH,mm,ss")
        vectorHoras(6) = Format(Me.DtHoraDesde4.Value, "HH,mm,ss")
        vectorHoras(7) = Format(Me.DtHoraHasta4.Value, "HH,mm,ss")
        vectorHoras(8) = Format(Me.DtHoraDesde.Value, "HH,mm,ss")
        vectorHoras(9) = Format(Me.DtHoraHasta4.Value, "HH,mm,ss")
        Dim cc As Integer = 0
        For index As Integer = 0 To 4 'Step 2
            repor("" & vectorHoras(cc), "" & vectorHoras(cc + 1), direct)
            cc = cc + 2
        Next
    End Sub
End Class