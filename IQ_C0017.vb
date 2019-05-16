Imports CrystalDecisions.CrystalReports.Engine
Public Class IQ_C0017
    Inherits System.Windows.Forms.Form
    Dim Permisos As Integer = 0
    Dim oficinas_select(100) As String
    Dim num_nodos(10) As Integer
    Dim nivel_nodo As Integer
    Dim ind_ofic As Integer
    Dim indice_nodos As Integer
    Dim file_data(1, 6) As String
    Dim record_count As Integer
    Private Dictoficinas As New ColeccionOficinas
    Dim alcance(3) As String
    Dim ColumnaDesdeFecha As New DataColumn
    Dim ColumnaHastaFecha As New DataColumn
    Dim ColumnaDesdeHora As New DataColumn
    Dim ColumnaHastaHora As New DataColumn
    Dim ColumnaHabil As New DataColumn
    Dim ColumnaJustificativo As New DataColumn
    Dim TablaDatos As New DataTable
    Private DsSiNo As New DataSet
    Private DbSiNo As System.Data.OleDb.OleDbDataAdapter = New System.Data.OleDb.OleDbDataAdapter

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles CmdExit.Click
        IQ_C0000.PicFondo.Visible = True
        Me.Dispose()
    End Sub
    Public Sub New()
        InitializeComponent()
        Timer1.Enabled = True
        Timer1.Start()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
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
            num_nodos(Nivel) += 1
        End While
        Carga_Coneccion_O2.Dispose()
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
    Private Sub CmdReport_Click(sender As Object, e As EventArgs) Handles CmdReport.Click
        Dim Codigo As String = ""
        Dim alcance_reporte As String = ""
        If alcance(2) <> "" Then
            alcance_reporte = "PUNTO DE ATENCION:"
            Dim Carga_Coneccion_O As New OleDb.OleDbConnection(Cnn_Central_Server)
            Carga_Coneccion_O.Open()
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
        ElseIf Mid(alcance(1), 1, 1) = "K" Then
            alcance_reporte = "TIQUETERA:"
            Dim Carga_Coneccion_O As New OleDb.OleDbConnection(Cnn_Central_Server)
            Codigo = Mid(alcance(1), 3, Len(alcance(1)) - 2)
            Carga_Coneccion_O.Open()
            Dim Carga_Comando_K As New OleDb.OleDbCommand("Select IqConfigOfic_Descripcion, IqConfigOfic_Oficina from IQ_ConfigOfic where IqConfigOfic_Codigo = '" & Codigo & "' And IqConfigOfic_Tipo = 'K'", Carga_Coneccion_O)
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
        ElseIf Mid(alcance(1), 1, 1) = "L" Then
            alcance_reporte = "PANTALLA:"
            Dim Carga_Coneccion_O As New OleDb.OleDbConnection(Cnn_Central_Server)
            Codigo = Mid(alcance(1), 3, Len(alcance(1)) - 2)
            Carga_Coneccion_O.Open()
            Dim Carga_Comando_K As New OleDb.OleDbCommand("Select IqConfigOfic_Descripcion, IqConfigOfic_Oficina from IQ_ConfigOfic where IqConfigOfic_Codigo = '" & Codigo & "'  And IqConfigOfic_Tipo = 'L'", Carga_Coneccion_O)
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
        End If
        Dim rptlayout As New ReportDocument
        Try
            rptlayout.Load(Disco_Appl & ":\I-Q\IQ_Rpt\IQ_C0017.rpt")
            rptlayout.SetDatabaseLogon(Server_User, Server_Pwd)
            rptlayout.SummaryInfo.ReportTitle = Nombre_Cliente + Chr(10) + Me.Text
            Me.crvReporte.SelectionFormula = "{IQ_ExcepHorario.IQExcep_Oficina} = '" + alcance(0) + "' And {IQ_ExcepHorario.IQExcep_Area} = '" + alcance(1) + "' And {IQ_ExcepHorario.IQExcep_Punto} = '" + alcance(2) + "'"
            Dim CrCollection As New CrystalDecisions.Shared.ParameterValues
            Dim CrPvAlcance As New CrystalDecisions.Shared.ParameterDiscreteValue
            CrPvAlcance.Value = Alcance_Reporte
            CrCollection.Add(CrPvAlcance)
            rptlayout.DataDefinition.ParameterFields("Alcance").ApplyCurrentValues(CrCollection)
            Me.crvReporte.ReportSource = rptlayout
            Me.crvReporte.DisplayToolbar = True
            Me.crvReporte.ShowCloseButton = False
            Me.crvReporte.Zoom(1)
            Me.crvReporte.ShowFirstPage()
            Me.crvReporte.BringToFront()
            Me.crvReporte.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            Me.crvReporte.Visible = True
            Me.CmdClean.Enabled = True
            Me.CmdExec.Enabled = False
            Me.CmdExit.Enabled = True
            Me.CmdNewSearch.Enabled = False
            Me.CmdReport.Enabled = False
            Me.CmdSearch.Enabled = False
            'rptlayout.dispose()
        Catch exc As Exception
            Dim Mensaje_Excepcion As String
            Mensaje_Excepcion = exc.Message
            Mensaje_Excepcion = "Error Integrado: " + Mensaje_Excepcion
            MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub CmdNewSearch_Click(sender As Object, e As EventArgs) Handles CmdNewSearch.Click
        If MessageBox.Show("Está Ud. seguro de ABANDONAR el alcance actual y efectuar una nueva búsqueda?", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Me.GridDatos.Visible = False
        CmdClean_Click(CmdNewSearch, e)
    End Sub
    Private Sub CmdSearch_Click(sender As Object, e As EventArgs) Handles CmdSearch.Click
        Dim Carga_Coneccion_O1 As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O1.Open()
        Dim instruct As String = ""
        Try
            Select Case Server_Collation
                Case "ymd"
                    instruct = "Select count(IQEXcep_DesdeFecha) from IQ_ExcepHorario where IQExcep_Oficina = '" & alcance(0) & "' and IQExcep_Area = '" & alcance(1) & "' and IQExcep_Punto = '" & alcance(2) & "' And (IQExcep_DesdeFecha >= '" & Format(DateAdd(DateInterval.Second, desfase_segundos, Date.Now), "yyyy/MM/dd") & "' or IQExcep_HastaFecha >= '" & Format(DateAdd(DateInterval.Second, desfase_segundos, Date.Now), "yyyy/MM/dd") & "')"
                Case "ydm"
                    instruct = "Select count(IQEXcep_DesdeFecha) from IQ_ExcepHorario where IQExcep_Oficina = '" & alcance(0) & "' and IQExcep_Area = '" & alcance(1) & "' and IQExcep_Punto = '" & alcance(2) & "' And (IQExcep_DesdeFecha >= '" & Format(DateAdd(DateInterval.Second, desfase_segundos, Date.Now), "yyyy/dd/MM") & "' or IQExcep_HastaFecha >= '" & Format(DateAdd(DateInterval.Second, desfase_segundos, Date.Now), "yyyy/dd/MM") & "')"
                Case "mdy"
                    instruct = "Select count(IQEXcep_DesdeFecha) from IQ_ExcepHorario where IQExcep_Oficina = '" & alcance(0) & "' and IQExcep_Area = '" & alcance(1) & "' and IQExcep_Punto = '" & alcance(2) & "' And (IQExcep_DesdeFecha >= '" & Format(DateAdd(DateInterval.Second, desfase_segundos, Date.Now), "MM/dd/yyyy") & "' or IQExcep_HastaFecha >= '" & Format(DateAdd(DateInterval.Second, desfase_segundos, Date.Now), "MM/dd/yyyy") & "')"
                Case "dmy"
                    instruct = "Select count(IQEXcep_DesdeFecha) from IQ_ExcepHorario where IQExcep_Oficina = '" & alcance(0) & "' and IQExcep_Area = '" & alcance(1) & "' and IQExcep_Punto = '" & alcance(2) & "' And (IQExcep_DesdeFecha >= '" & Format(DateAdd(DateInterval.Second, desfase_segundos, Date.Now), "dd/MM/yyyy") & "' or IQExcep_HastaFecha >= '" & Format(DateAdd(DateInterval.Second, desfase_segundos, Date.Now), "dd/MM/yyyy") & "')"
            End Select
        Catch ex As Exception
            Select Case Server_Collation
                Case "ymd"
                    instruct = "Select count(IQEXcep_DesdeFecha) from IQ_ExcepHorario where IQExcep_Oficina = '" & alcance(0) & "' and IQExcep_Area = '" & alcance(1) & "' and IQExcep_Punto = '" & alcance(2) & "' And (IQExcep_DesdeFecha >= '" & Format(DateAdd(DateInterval.Second, 0, Date.Now), "yyyy/MM/dd") & "' or IQExcep_HastaFecha >= '" & Format(DateAdd(DateInterval.Second, 0, Date.Now), "yyyy/MM/dd") & "')"
                Case "ydm"
                    instruct = "Select count(IQEXcep_DesdeFecha) from IQ_ExcepHorario where IQExcep_Oficina = '" & alcance(0) & "' and IQExcep_Area = '" & alcance(1) & "' and IQExcep_Punto = '" & alcance(2) & "' And (IQExcep_DesdeFecha >= '" & Format(DateAdd(DateInterval.Second, 0, Date.Now), "yyyy/dd/MM") & "' or IQExcep_HastaFecha >= '" & Format(DateAdd(DateInterval.Second, 0, Date.Now), "yyyy/dd/MM") & "')"
                Case "mdy"
                    instruct = "Select count(IQEXcep_DesdeFecha) from IQ_ExcepHorario where IQExcep_Oficina = '" & alcance(0) & "' and IQExcep_Area = '" & alcance(1) & "' and IQExcep_Punto = '" & alcance(2) & "' And (IQExcep_DesdeFecha >= '" & Format(DateAdd(DateInterval.Second, 0, Date.Now), "MM/dd/yyyy") & "' or IQExcep_HastaFecha >= '" & Format(DateAdd(DateInterval.Second, 0, Date.Now), "MM/dd/yyyy") & "')"
                Case "dmy"
                    instruct = "Select count(IQEXcep_DesdeFecha) from IQ_ExcepHorario where IQExcep_Oficina = '" & alcance(0) & "' and IQExcep_Area = '" & alcance(1) & "' and IQExcep_Punto = '" & alcance(2) & "' And (IQExcep_DesdeFecha >= '" & Format(DateAdd(DateInterval.Second, 0, Date.Now), "dd/MM/yyyy") & "' or IQExcep_HastaFecha >= '" & Format(DateAdd(DateInterval.Second, 0, Date.Now), "dd/MM/yyyy") & "')"
            End Select
        End Try
        Dim Carga_Comando_O1 As New OleDb.OleDbCommand(instruct, Carga_Coneccion_O1)
        Dim Carga_Reader_O1 As OleDb.OleDbDataReader = Carga_Comando_O1.ExecuteReader(CommandBehavior.CloseConnection)
        Dim num_rows As Integer = 0
        While Carga_Reader_O1.Read
            If IsDBNull(Carga_Reader_O1.GetValue(0)) = False Then
                num_rows = Carga_Reader_O1.GetValue(0)
            End If
        End While
        Carga_Coneccion_O1.Close()
        ReDim file_data(1, 6)
        record_count = 0
        If num_rows > 0 Then
            ReDim file_data(num_rows, 6)
            Carga_Coneccion_O1.Open()
            Dim instruc_fec As String = ""
            Select Case Server_Collation
                Case "ymd"
                    instruc_fec = "Select * from IQ_ExcepHorario where IQExcep_Oficina = '" & alcance(0) & "' and IQExcep_Area = '" & alcance(1) & "' and IQExcep_Punto = '" & alcance(2) & "' And (IQExcep_DesdeFecha >= '" & Format(DateAdd(DateInterval.Second, desfase_segundos, Date.Now), "yyyy/MM/dd") & "' or IQExcep_HastaFecha >= '" & Format(DateAdd(DateInterval.Second, desfase_segundos, Date.Now), "yyyy/MM/dd") & "') Order by IQExcep_DesdeFecha, IQExcep_HastaFecha"
                Case "ydm"
                    instruc_fec = "Select * from IQ_ExcepHorario where IQExcep_Oficina = '" & alcance(0) & "' and IQExcep_Area = '" & alcance(1) & "' and IQExcep_Punto = '" & alcance(2) & "' And (IQExcep_DesdeFecha >= '" & Format(DateAdd(DateInterval.Second, desfase_segundos, Date.Now), "yyyy/dd/MM") & "' or IQExcep_HastaFecha >= '" & Format(DateAdd(DateInterval.Second, desfase_segundos, Date.Now), "yyyy/dd/MM") & "') Order by IQExcep_DesdeFecha, IQExcep_HastaFecha"
                Case "mdy"
                    instruc_fec = "Select * from IQ_ExcepHorario where IQExcep_Oficina = '" & alcance(0) & "' and IQExcep_Area = '" & alcance(1) & "' and IQExcep_Punto = '" & alcance(2) & "' And (IQExcep_DesdeFecha >= '" & Format(DateAdd(DateInterval.Second, desfase_segundos, Date.Now), "MM/dd/yyyy") & "' or IQExcep_HastaFecha >= '" & Format(DateAdd(DateInterval.Second, desfase_segundos, Date.Now), "MM/dd/yyyy") & "') Order by IQExcep_DesdeFecha, IQExcep_HastaFecha"
                Case "dmy"
                    instruc_fec = "Select * from IQ_ExcepHorario where IQExcep_Oficina = '" & alcance(0) & "' and IQExcep_Area = '" & alcance(1) & "' and IQExcep_Punto = '" & alcance(2) & "' And (IQExcep_DesdeFecha >= '" & Format(DateAdd(DateInterval.Second, desfase_segundos, Date.Now), "dd/MM/yyyy") & "' or IQExcep_HastaFecha >= '" & Format(DateAdd(DateInterval.Second, desfase_segundos, Date.Now), "dd/MM/yyyy") & "') Order by IQExcep_DesdeFecha, IQExcep_HastaFecha"
            End Select
            Dim Carga_Comando_O1b As New OleDb.OleDbCommand(instruc_fec, Carga_Coneccion_O1)
            Dim Carga_Reader_O1b As OleDb.OleDbDataReader = Carga_Comando_O1b.ExecuteReader(CommandBehavior.CloseConnection)
            While Carga_Reader_O1b.Read
                file_data(record_count, 0) = Format(Carga_Reader_O1b.GetValue(3), "yyyy/MM/dd")
                file_data(record_count, 1) = Format(Carga_Reader_O1b.GetValue(4), "yyyy/MM/dd")
                file_data(record_count, 2) = Format(CDate(Carga_Reader_O1b.GetValue(5)), "HH:mm:ss")
                file_data(record_count, 3) = Format(CDate(Carga_Reader_O1b.GetValue(6)), "HH:mm:ss")
                file_data(record_count, 4) = Carga_Reader_O1b.GetValue(7)
                file_data(record_count, 5) = Carga_Reader_O1b.GetValue(8)
                record_count += 1
            End While
            Carga_Coneccion_O1.Dispose()
        End If
Busca_Fin:
        Formatea_Grid()
        Me.TrvOficinas.Enabled = False
        If Permisos > 3 Then
            Me.CmdExec.Visible = True
        Else
            Me.CmdExec.Visible = False
        End If
        Me.CmdNewSearch.Visible = True
        Me.CmdSearch.Visible = False
        Me.CmdReport.Visible = True
        Me.CmdRefresh.Visible = False
        Me.GridDatos.Visible = True
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
        toolTip1.SetToolTip(CmdNewSearch, "Nueva Búsqueda")
        toolTip1.SetToolTip(CmdReport, "Reporte")
        toolTip1.SetToolTip(CmdSearch, "Buscar")
        toolTip1.SetToolTip(CmdExit, "Salir")
        toolTip1.SetToolTip(CmdExec, "Grabar")
        toolTip1.SetToolTip(CmdClean, "Limpiar")
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
        Dim cn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(Cnn_Central_Server)
        cn.Open()
        DsSiNo.Clear()
        With DbSiNo
            Dim SQLStr As String = "Select * from IQ_VwSiNo"
            .TableMappings.Add("Table", "Iq_VwSiNo")
            Dim cmd As System.Data.OleDb.OleDbCommand = New System.Data.OleDb.OleDbCommand(SQLStr, cn)
            cmd.CommandType = CommandType.Text
            .SelectCommand = cmd
            .Fill(DsSiNo)
            .Dispose()
            cmd.Cancel()
        End With
        cn.Dispose()
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
        Me.CmdExec.Visible = False
        Me.CmdNewSearch.Visible = False
        Me.crvReporte.Visible = False
        Me.CmdSearch.Visible = True
        Me.CmdReport.Visible = False
        Me.GridDatos.Visible = False
    End Sub
    Private Sub Formatea_Grid()
        With Me.GridDatos
            .TableStyles.Clear()
        End With
        TablaDatos.Columns.Clear()
        TablaDatos.Rows.Clear()
        ColumnaDesdeFecha.DataType = System.Type.GetType("System.DateTime")
        ColumnaHastaFecha.DataType = System.Type.GetType("System.DateTime")
        ColumnaDesdeHora.DataType = System.Type.GetType("System.DateTime")
        ColumnaHastaHora.DataType = System.Type.GetType("System.DateTime")
        ColumnaHabil.DataType = System.Type.GetType("System.String")
        ColumnaJustificativo.DataType = System.Type.GetType("System.String")
        ColumnaDesdeFecha.ColumnName = "DesdeFecha"
        ColumnaHastaFecha.ColumnName = "HastaFecha"
        ColumnaDesdeHora.ColumnName = "DesdeHora"
        ColumnaHastaHora.ColumnName = "HastaHora"
        ColumnaHabil.ColumnName = "Habil"
        ColumnaJustificativo.ColumnName = "Justificativo"
        ColumnaDesdeFecha.Caption = ""
        ColumnaHastaFecha.Caption = ""
        ColumnaDesdeHora.Caption = ""
        ColumnaHastaHora.Caption = ""
        ColumnaHabil.Caption = ""
        ColumnaJustificativo.Caption = ""
        ColumnaDesdeFecha.AllowDBNull = False
        ColumnaHastaFecha.AllowDBNull = False
        ColumnaDesdeHora.AllowDBNull = False
        ColumnaHastaHora.AllowDBNull = False
        ColumnaHabil.AllowDBNull = False
        ColumnaJustificativo.AllowDBNull = False
        ColumnaDesdeFecha.AutoIncrement = False
        ColumnaHastaFecha.AutoIncrement = False
        ColumnaDesdeHora.AutoIncrement = False
        ColumnaHastaHora.AutoIncrement = False
        ColumnaHabil.AutoIncrement = False
        ColumnaJustificativo.AutoIncrement = False
        ColumnaDesdeFecha.ReadOnly = False
        ColumnaHastaFecha.ReadOnly = False
        ColumnaDesdeHora.ReadOnly = False
        ColumnaHastaHora.ReadOnly = False
        ColumnaHabil.ReadOnly = False
        ColumnaJustificativo.ReadOnly = False
        TablaDatos.Columns.Add(ColumnaDesdeFecha)
        TablaDatos.Columns.Add(ColumnaHastaFecha)
        TablaDatos.Columns.Add(ColumnaDesdeHora)
        TablaDatos.Columns.Add(ColumnaHastaHora)
        TablaDatos.Columns.Add(ColumnaHabil)
        TablaDatos.Columns.Add(ColumnaJustificativo)
        TablaDatos.DefaultView.AllowNew = True
        Dim fila As DataRow
        Dim indice_string As Integer = 0
        If record_count > 0 Then
            For indice_string = 0 To record_count - 1
                fila = TablaDatos.NewRow
                fila("DesdeFecha") = CDate(file_data(indice_string, 0))
                fila("HastaFecha") = CDate(file_data(indice_string, 1))
                fila("DesdeHora") = CDate(file_data(indice_string, 2))
                fila("HastaHora") = CDate(file_data(indice_string, 3))
                fila("Habil") = file_data(indice_string, 4)
                fila("Justificativo") = file_data(indice_string, 5)
                TablaDatos.Rows.Add(fila)
            Next
        End If
        Dim table_style As New DataGridTableStyle
        table_style.MappingName = TablaDatos.TableName
        Dim DesdeFecha_Style As New DataGridTextBoxColumn
        With DesdeFecha_Style
            .Alignment = HorizontalAlignment.Left
            .MappingName = "DesdeFecha"
            .HeaderText = "Desde Fecha(dd/mm/aaaa)"
            .Width = 150
            .Format = "dd/MM/yyyy"
        End With
        Dim HastaFecha_Style As New DataGridTextBoxColumn
        With HastaFecha_Style
            .Alignment = HorizontalAlignment.Left
            .MappingName = "HastaFecha"
            .HeaderText = "Hasta Fecha(dd/mm/aaaa)"
            .Width = 150
            .Format = "dd/MM/yyyy"
        End With
        Dim DesdeHora_Style As New DataGridTextBoxColumn
        With DesdeHora_Style
            .Alignment = HorizontalAlignment.Left
            .MappingName = "DesdeHora"
            .HeaderText = "Desde Hora(HH:mm)"
            .Width = 130
            .Format = "HH:mm"
        End With
        Dim HastaHora_Style As New DataGridTextBoxColumn
        With HastaHora_Style
            .Alignment = HorizontalAlignment.Left
            .MappingName = "HastaHora"
            .HeaderText = "Hasta Hora(HH:mm)"
            .Width = 130
            .Format = "HH:mm"
        End With
        Dim Habil_style As New DataGridComboBoxColumn
        With Habil_style
            .Alignment = HorizontalAlignment.Left
            .MappingName = "Habil"
            .HeaderText = "Hábil(S/N)"
            .Width = 100
            .ColumnComboBox.DataSource = DsSiNo.Tables("Iq_VwSiNo").DefaultView
            .ColumnComboBox.DisplayMember = "IqVwSiNo_Descripcion"
            .ColumnComboBox.ValueMember = "IqVwSiNo_Codigo"
        End With
        Dim Justificativo_style As New DataGridTextBoxColumn
        With Justificativo_style
            .Alignment = HorizontalAlignment.Left
            .MappingName = "Justificativo"
            .HeaderText = "Justificativo"
            .Width = 300
        End With
        table_style.GridColumnStyles.AddRange _
            (New DataGridColumnStyle() _
            {DesdeFecha_Style, HastaFecha_Style, DesdeHora_Style, HastaHora_Style, Habil_style, Justificativo_style})
        Me.GridDatos.TableStyles.Add(table_style)
        Me.GridDatos.DataSource = TablaDatos
        Me.GridDatos.CaptionVisible = False
        Me.GridDatos.Visible = True
    End Sub
    Private Sub CmdClean_Click(sender As Object, e As EventArgs) Handles CmdClean.Click
        If Me.crvReporte.Visible = True Then
            Me.CmdClean.Enabled = True
            Me.CmdExec.Enabled = True
            Me.CmdExit.Enabled = True
            Me.CmdNewSearch.Enabled = True
            Me.CmdReport.Enabled = True
            Me.CmdSearch.Enabled = True
            Me.crvReporte.Visible = False
        ElseIf Me.GridDatos.Visible = False Then
            Me.crvReporte.Visible = False
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
            Me.CmdExec.Visible = False
            Me.CmdNewSearch.Visible = False
            Me.CmdSearch.Visible = True
            Me.CmdRefresh.Visible = True
            Me.CmdReport.Visible = False
            Me.TrvOficinas.Focus()
        End If
    End Sub
    Private Sub CmdExec_Click(sender As Object, e As EventArgs) Handles CmdExec.Click
        If MessageBox.Show("Está Ud. seguro de GRABAR las excepciones de horario?", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Try
            Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
            IQ_Cnn.Open()
            Dim instruc_fec As String = ""
            Select Case Server_Collation
                Case "ymd"
                    instruc_fec = "Delete from IQ_ExcepHorario Where IQExcep_Oficina = '" + alcance(0) & "' And IQExcep_Area = '" + alcance(1) & "' And IQExcep_Punto = '" + alcance(2) & "'  And (IQExcep_DesdeFecha >= '" & Format(DateAdd(DateInterval.Second, desfase_segundos, Date.Now), "yyyy/MM/dd") & "' or IQExcep_HastaFecha >= '" & Format(DateAdd(DateInterval.Second, desfase_segundos, Date.Now), "yyyy/MM/dd") & "')"
                Case "ydm"
                    instruc_fec = "Delete from IQ_ExcepHorario Where IQExcep_Oficina = '" + alcance(0) & "' And IQExcep_Area = '" + alcance(1) & "' And IQExcep_Punto = '" + alcance(2) & "'  And (IQExcep_DesdeFecha >= '" & Format(DateAdd(DateInterval.Second, desfase_segundos, Date.Now), "yyyy/dd/MM") & "' or IQExcep_HastaFecha >= '" & Format(DateAdd(DateInterval.Second, desfase_segundos, Date.Now), "yyyy/dd/MM") & "')"
                Case "mdy"
                    instruc_fec = "Delete from IQ_ExcepHorario Where IQExcep_Oficina = '" + alcance(0) & "' And IQExcep_Area = '" + alcance(1) & "' And IQExcep_Punto = '" + alcance(2) & "'  And (IQExcep_DesdeFecha >= '" & Format(DateAdd(DateInterval.Second, desfase_segundos, Date.Now), "MM/dd/yyyy") & "' or IQExcep_HastaFecha >= '" & Format(DateAdd(DateInterval.Second, desfase_segundos, Date.Now), "MM/dd/yyyy") & "')"
                Case "dmy"
                    instruc_fec = "Delete from IQ_ExcepHorario Where IQExcep_Oficina = '" + alcance(0) & "' And IQExcep_Area = '" + alcance(1) & "' And IQExcep_Punto = '" + alcance(2) & "'  And (IQExcep_DesdeFecha >= '" & Format(DateAdd(DateInterval.Second, desfase_segundos, Date.Now), "dd/MM/yyyy") & "' or IQExcep_HastaFecha >= '" & Format(DateAdd(DateInterval.Second, desfase_segundos, Date.Now), "dd/MM/yyyy") & "')"
            End Select
            Dim IQ_Cmm As New OleDb.OleDbCommand(instruc_fec, IQ_Cnn)
            Dim RegistrosEliminados As Long = IQ_Cmm.ExecuteNonQuery()
            IQ_Cnn.Close()
        Catch exc As Exception
            Dim Mensaje_Excepcion As String
            Mensaje_Excepcion = exc.Message
            Mensaje_Excepcion = "Error Integrado: " + Mensaje_Excepcion
            MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
        Dim registros As Integer = 0
        For indice = 0 To TablaDatos.Rows.Count - 1
            If IsDBNull(TablaDatos.Rows(indice)("DesdeFecha")) = False Then
                Dim instruccion_insert As String = ""
                instruccion_insert = "Insert Into IQ_ExcepHorario Values('" + alcance(0) + "', '" + alcance(1) + "', '" & alcance(2) + "', "
                Select Case Server_Collation
                    Case "ymd"
                        instruccion_insert = instruccion_insert & "'" & Format(TablaDatos.Rows(indice)("DesdeFecha"), "yyyy/MM/dd") & "', "
                        instruccion_insert = instruccion_insert & "'" & Format(TablaDatos.Rows(indice)("HastaFecha"), "yyyy/MM/dd") & "', "
                    Case "ydm"
                        instruccion_insert = instruccion_insert & "'" & Format(TablaDatos.Rows(indice)("DesdeFecha"), "yyyy/dd/MM") & "', "
                        instruccion_insert = instruccion_insert & "'" & Format(TablaDatos.Rows(indice)("HastaFecha"), "yyyy/dd/MM") & "', "
                    Case "mdy"
                        instruccion_insert = instruccion_insert & "'" & Format(TablaDatos.Rows(indice)("DesdeFecha"), "MM/dd/yyyy") & "', "
                        instruccion_insert = instruccion_insert & "'" & Format(TablaDatos.Rows(indice)("HastaFecha"), "MM/dd/yyyy") & "', "
                    Case "dmy"
                        instruccion_insert = instruccion_insert & "'" & Format(TablaDatos.Rows(indice)("DesdeFecha"), "dd/MM/yyyy") & "', "
                        instruccion_insert = instruccion_insert & "'" & Format(TablaDatos.Rows(indice)("HastaFecha"), "dd/MM/yyyy") & "', "
                End Select
                instruccion_insert = instruccion_insert & "'" & Format(TablaDatos.Rows(indice)("DesdeHora"), "HH:mm") & "', "
                instruccion_insert = instruccion_insert & "'" & Format(TablaDatos.Rows(indice)("HastaHora"), "HH:mm") & "', "
                instruccion_insert = instruccion_insert & "'" & TablaDatos.Rows(indice)("Habil") & "', "
                instruccion_insert = instruccion_insert & "'" & TablaDatos.Rows(indice)("Justificativo") & "')"
                Try
                    Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
                    IQ_Cnn.Open()
                    Dim IQ_Cmm As New OleDb.OleDbCommand(instruccion_insert, IQ_Cnn)
                    Dim RegistrosInsertados As Long = IQ_Cmm.ExecuteNonQuery()
                    registros += 1
                    IQ_Cnn.Close()
                Catch exc As Exception
                    Dim Mensaje_Excepcion As String
                    Mensaje_Excepcion = exc.Message
                    MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End Try
            End If
        Next
        MessageBox.Show(registros.ToString + " Registro(s) fueron insertados satisfactoriamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub

    Private Sub CmdRefresh_Click(sender As Object, e As EventArgs) Handles CmdRefresh.Click
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
    End Sub
End Class