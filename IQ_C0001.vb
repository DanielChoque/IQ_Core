Imports CrystalDecisions.CrystalReports.Engine
Public Class IQ_C0001
    Inherits System.Windows.Forms.Form
    Dim Tipo_Env As String
    Dim Desc_Env As String
    Dim Permisos As Integer = 0
    Dim oficinas_select(100) As String
    Dim num_nodos(10) As Integer
    Dim nivel_nodo As Integer
    Dim ind_ofic As Integer
    Dim indice_nodos As Integer
    Dim file_data(100, 7) As String
    Private Dictoficinas As New ColeccionOficinas
    Dim alcance(3) As String
    Dim ColumnaCodigo As New DataColumn
    Dim ColumnaDescripcion As New DataColumn
    Dim ColumnaPrefijo As New DataColumn
    Dim ColumnaPrioridad As New DataColumn
    Dim ColumnaTiempo As New DataColumn
    Dim ColumnaTarjeta As New DataColumn
    Dim TablaDatos As New DataTable
    Private DsSiNo As New DataSet
    Private DbSiNo As System.Data.OleDb.OleDbDataAdapter = New System.Data.OleDb.OleDbDataAdapter

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles CmdExit.Click
        IQ_C0000.PicFondo.Visible = True
        Me.Dispose()
    End Sub
    Public Sub New()
        InitializeComponent()
        AddHandler TablaDatos.ColumnChanging, AddressOf Grid_ColumnChanging
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
            'Busca_Kioskos(Carga_Reader_O2.GetValue(0), num_nodos(Nivel), Nivel + 1)
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
    Private Sub Busca_Kioskos(Codigo As String, Nodo As Integer, Nivel As Integer)
        Dim Carga_Coneccion_O2 As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O2.Open()
        Dim Carga_Comando_O2 As New OleDb.OleDbCommand("Select IqConfigOfic_Codigo, IqConfigOfic_Descripcion from IQ_ConfigOfic where IqConfigOfic_Oficina = '" & Codigo & "' And IqConfigOfic_Tipo = 'K' order by IqConfigOfic_Codigo", Carga_Coneccion_O2)
        Dim Carga_Reader_O2 As OleDb.OleDbDataReader = Carga_Comando_O2.ExecuteReader(CommandBehavior.CloseConnection)
        num_nodos(Nivel) = 0
        While Carga_Reader_O2.Read
            Select Case Nivel
                Case 0
                    Me.TrvOficinas.Nodes(0).Nodes.Add("TKT:" & Carga_Reader_O2.GetValue(1) & Space(500) & "|K:" & Carga_Reader_O2.GetValue(0))
                Case 1
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(Nivel - 1)).Nodes.Add("TKT:" & Carga_Reader_O2.GetValue(1) & Space(500) & "|K:" & Carga_Reader_O2.GetValue(0))
                Case 2
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes.Add("TKT:" & Carga_Reader_O2.GetValue(1) & Space(500) & "|K:" & Carga_Reader_O2.GetValue(0))
                Case 3
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes.Add("TKT:" & Carga_Reader_O2.GetValue(1) & Space(500) & "|K:" & Carga_Reader_O2.GetValue(0))
                Case 4
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes(num_nodos(3)).Nodes.Add("TKT:" & Carga_Reader_O2.GetValue(1) & Space(500) & "|K:" & Carga_Reader_O2.GetValue(0))
                Case 5
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes(num_nodos(3)).Nodes(num_nodos(4)).Nodes.Add("TKT:" & Carga_Reader_O2.GetValue(1) & Space(500) & "|K:" & Carga_Reader_O2.GetValue(0))
                Case 6
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes(num_nodos(3)).Nodes(num_nodos(4)).Nodes(num_nodos(5)).Nodes.Add("TKT:" & Carga_Reader_O2.GetValue(1) & Space(500) & "|K:" & Carga_Reader_O2.GetValue(0))
                Case 7
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes(num_nodos(3)).Nodes(num_nodos(4)).Nodes(num_nodos(5)).Nodes(num_nodos(6)).Nodes.Add("TKT:" & Carga_Reader_O2.GetValue(1) & Space(500) & "|K:" & Carga_Reader_O2.GetValue(0))
                Case 8
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes(num_nodos(3)).Nodes(num_nodos(4)).Nodes(num_nodos(5)).Nodes(num_nodos(6)).Nodes(num_nodos(7)).Nodes.Add("TKT:" & Carga_Reader_O2.GetValue(1) & Space(500) & "|K:" & Carga_Reader_O2.GetValue(0))
                Case 9
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos(0)).Nodes(num_nodos(1)).Nodes(num_nodos(2)).Nodes(num_nodos(3)).Nodes(num_nodos(4)).Nodes(num_nodos(5)).Nodes(num_nodos(6)).Nodes(num_nodos(7)).Nodes(num_nodos(8)).Nodes.Add("TKT:" & Carga_Reader_O2.GetValue(1) & Space(500) & "|K:" & Carga_Reader_O2.GetValue(0))
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
    Private Sub Limpia_Oficinas(Codigo As String)
        Try
            Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
            IQ_Cnn.Open()
            Dim IQ_Cmm As New OleDb.OleDbCommand("Delete from IQ_TipoTick Where IQTipTick_Oficina = '" + Codigo & "' And IQTipTick_Area = '' And IQTipTick_Punto = ''", IQ_Cnn)
            Dim RegistrosEliminados As Long = IQ_Cmm.ExecuteNonQuery()
            IQ_Cnn.Close()
        Catch exc As Exception
            Dim Mensaje_Excepcion As String
            Mensaje_Excepcion = exc.Message
            Mensaje_Excepcion = "Error Integrado: " + Mensaje_Excepcion
            MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
        Dim Carga_Coneccion_O As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O.Open()
        Dim Carga_Comando_O As New OleDb.OleDbCommand("Select IqOficinas_Codigo from IQ_Oficinas where IqOficinas_Consolidacion = '" & Codigo & "'", Carga_Coneccion_O)
        Dim Carga_Reader_O As OleDb.OleDbDataReader = Carga_Comando_O.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O.Read
            Limpia_Oficinas(Carga_Reader_O.GetValue(0))
            LImpia_Areas(Carga_Reader_O.GetValue(0))
            LImpia_Kioskos(Carga_Reader_O.GetValue(0))
        End While
        Carga_Coneccion_O.Dispose()
    End Sub
    Private Sub LImpia_Kioskos(Codigo As String)
        Dim Carga_Coneccion_O As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O.Open()
        Dim Carga_Comando_O As New OleDb.OleDbCommand("Select IqConfigOfic_Codigo from IQ_ConfigOfic where IqConfigOfic_Oficina = '" & Codigo & "' And IqConfigOfic_Tipo = 'K'", Carga_Coneccion_O)
        Dim Carga_Reader_O As OleDb.OleDbDataReader = Carga_Comando_O.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O.Read
            Try
                Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
                IQ_Cnn.Open()
                Dim IQ_Cmm As New OleDb.OleDbCommand("Delete from IQ_TipoTick Where IQTipTick_Oficina = '' And IQTipTick_Area = 'K:" & Trim(Carga_Reader_O.GetValue(0)) & "' And IQTipTick_Punto = ''", IQ_Cnn)
                Dim RegistrosEliminados As Long = IQ_Cmm.ExecuteNonQuery()
                IQ_Cnn.Close()
            Catch exc As Exception
                Dim Mensaje_Excepcion As String
                Mensaje_Excepcion = exc.Message
                Mensaje_Excepcion = "Error Integrado: " + Mensaje_Excepcion
                MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        End While
        Carga_Coneccion_O.Dispose()
    End Sub
    Private Sub LImpia_Areas(Codigo As String)
        Dim Carga_Coneccion_O As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O.Open()
        Dim Carga_Comando_O As New OleDb.OleDbCommand("Select IqAreas_Codigo from IQ_Areas where IqAreas_Oficina = '" & Codigo & "'", Carga_Coneccion_O)
        Dim Carga_Reader_O As OleDb.OleDbDataReader = Carga_Comando_O.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O.Read
            Try
                Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
                IQ_Cnn.Open()
                Dim IQ_Cmm As New OleDb.OleDbCommand("Delete from IQ_TipoTick Where IQTipTick_Oficina = '' And IQTipTick_Area = 'A:" & Trim(Carga_Reader_O.GetValue(0)) & "' And IQTipTick_Punto = ''", IQ_Cnn)
                Dim RegistrosEliminados As Long = IQ_Cmm.ExecuteNonQuery()
                IQ_Cnn.Close()
            Catch exc As Exception
                Dim Mensaje_Excepcion As String
                Mensaje_Excepcion = exc.Message
                Mensaje_Excepcion = "Error Integrado: " + Mensaje_Excepcion
                MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
            LImpia_Puntos(Trim(Carga_Reader_O.GetValue(0)))
        End While
        Carga_Coneccion_O.Dispose()
    End Sub
    Private Sub LImpia_Puntos(Codigo As String)
        Dim Carga_Coneccion_O As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O.Open()
        Dim Carga_Comando_O As New OleDb.OleDbCommand("Select IqPuntos_Codigo from IQ_PuntosAtencion where IqPuntos_Area = '" & Codigo & "'", Carga_Coneccion_O)
        Dim Carga_Reader_O As OleDb.OleDbDataReader = Carga_Comando_O.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O.Read
            Try
                Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
                IQ_Cnn.Open()
                Dim IQ_Cmm As New OleDb.OleDbCommand("Delete from IQ_TipoTick Where IQTipTick_Oficina = '' And IQTipTick_Area = '' And IQTipTick_Punto = '" & Trim(Carga_Reader_O.GetValue(0)) & "'", IQ_Cnn)
                Dim RegistrosEliminados As Long = IQ_Cmm.ExecuteNonQuery()
                IQ_Cnn.Close()
            Catch exc As Exception
                Dim Mensaje_Excepcion As String
                Mensaje_Excepcion = exc.Message
                Mensaje_Excepcion = "Error Integrado: " + Mensaje_Excepcion
                MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        End While
        Carga_Coneccion_O.Dispose()
    End Sub
    Private Sub CmdNewSearch_Click(sender As Object, e As EventArgs) Handles CmdNewSearch.Click
        If MessageBox.Show("Está Ud. seguro de ABANDONAR el alcance actual y efectuar una nueva búsqueda?", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Me.GridDatos.Visible = False
        CmdClean_Click(CmdNewSearch, e)
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
            rptlayout.Load(Disco_Appl & ":\I-Q\IQ_Rpt\IQ_C0001.rpt")
            rptlayout.SetDatabaseLogon(Server_User, Server_Pwd)
            rptlayout.SummaryInfo.ReportTitle = Nombre_Cliente + Chr(10) + Me.Text
            Me.crvReporte.SelectionFormula = "{IQ_TIpoTick.IQTipTick_Oficina} = '" + alcance(0) + "' And {IQ_TIpoTick.IQTipTick_Area} = '" + alcance(1) + "' And {IQ_TIpoTick.IQTipTick_Punto} = '" + alcance(2) + "'"
            Dim CrCollection As New CrystalDecisions.Shared.ParameterValues
            Dim CrPvAlcance As New CrystalDecisions.Shared.ParameterDiscreteValue
            CrPvAlcance.Value = alcance_reporte
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
    Private Sub CmdSearch_Click(sender As Object, e As EventArgs) Handles CmdSearch.Click
        Dim Alcance_recup(3) As String
        Alcance_recup(0) = alcance(0)
        Alcance_recup(1) = alcance(1)
        Alcance_recup(2) = alcance(2)
        Dim indice As Integer
        For indice = 0 To 99
            file_data(indice, 0) = ""
            file_data(indice, 1) = ""
            file_data(indice, 2) = ""
            file_data(indice, 3) = ""
            file_data(indice, 4) = ""
            file_data(indice, 5) = ""
            file_data(indice, 6) = ""
        Next
        indice = 0
        Dim encontrado As Boolean = False
        Dim mensaje_recup As String = ""
        If Alcance_recup(2) = "" Then GoTo busca_2
        Dim Carga_Coneccion_O1 As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O1.Open()
        Dim Carga_Comando_O1 As New OleDb.OleDbCommand("Select IQ_TipoTick.*, IQ_PuntosAtencion.IQPUntos_Descripcion from IQ_TipoTick join IQ_PuntosAtencion on IQ_TipoTick.IIQTipTick_Punto = IQ_PuntosAtencion.IQPuntos_Codigo where IQTipTick_Oficina = '' and IQTipTick_Area = '' and IQTipTick_Punto = '" & Alcance_recup(2) & "' Order by IQTipTick_Codigo", Carga_Coneccion_O1)
        Dim Carga_Reader_O1 As OleDb.OleDbDataReader = Carga_Comando_O1.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O1.Read
            If IsDBNull(Carga_Reader_O1.GetValue(0)) = False Then
                If encontrado = False Then
                    mensaje_recup = "RECUPERANDO PLANTILLA NIVEL PUNTO DE ATENCION: " & Carga_Reader_O1.GetValue(5)
                End If
                encontrado = True
                file_data(indice, 0) = Carga_Reader_O1.GetValue(3)
                file_data(indice, 1) = Carga_Reader_O1.GetValue(4)
                file_data(indice, 2) = Carga_Reader_O1.GetValue(5)
                file_data(indice, 3) = CStr(Carga_Reader_O1.GetValue(6))
                file_data(indice, 4) = CStr(Carga_Reader_O1.GetValue(7))
                file_data(indice, 5) = Carga_Reader_O1.GetValue(8)
                indice += 1
            End If
        End While
        Carga_Coneccion_O1.Dispose()
        If encontrado = True Then
            GoTo Busca_Fin
        End If
        If encontrado = False Then
            Dim Carga_Coneccion_O1b As New OleDb.OleDbConnection(Cnn_Central_Server)
            Carga_Coneccion_O1b.Open()
            Dim Carga_Comando_O1b As New OleDb.OleDbCommand("Select IQPuntos_Area from IQ_PuntosAtencion where IQPuntos_Codigo = '" & Alcance_recup(2) & "'", Carga_Coneccion_O1b)
            Dim Carga_Reader_O1b As OleDb.OleDbDataReader = Carga_Comando_O1b.ExecuteReader(CommandBehavior.CloseConnection)
            While Carga_Reader_O1b.Read
                If IsDBNull(Carga_Reader_O1b.GetValue(0)) = False Then
                    Alcance_recup(2) = ""
                    Alcance_recup(1) = "A:" & Carga_Reader_O1b.GetValue(0)
                End If
            End While
            Carga_Coneccion_O1b.Dispose()
        End If
Busca_2:
        If Alcance_recup(1) = "" Then GoTo busca_3
        Dim tipo_busq As String = Mid(Alcance_recup(1), 1, 1)
        Dim cod_busq As String = Mid(Alcance_recup(1), 3, Len(Alcance_recup(1)) - 2)
        Dim Carga_Coneccion_O2 As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O2.Open()
        Dim Carga_Comando_O2 As New OleDb.OleDbCommand("Select * from IQ_TipoTick where IQTipTick_Oficina = '' and IQTipTick_Area = '" & Alcance_recup(1) & "' and IQTipTick_Punto = '' Order by IQTipTick_Codigo", Carga_Coneccion_O2)
        Dim Carga_Reader_O2 As OleDb.OleDbDataReader = Carga_Comando_O2.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O2.Read
            If IsDBNull(Carga_Reader_O2.GetValue(0)) = False Then
                encontrado = True
                file_data(indice, 0) = Carga_Reader_O2.GetValue(3)
                file_data(indice, 1) = Carga_Reader_O2.GetValue(4)
                file_data(indice, 2) = Carga_Reader_O2.GetValue(5)
                file_data(indice, 3) = CStr(Carga_Reader_O2.GetValue(6))
                file_data(indice, 4) = CStr(Carga_Reader_O2.GetValue(7))
                file_data(indice, 5) = Carga_Reader_O2.GetValue(8)
                indice += 1
            End If
        End While
        Carga_Coneccion_O2.Dispose()
        If encontrado = True Then
            Dim instruc_busq As String = ""
            Select Case tipo_busq
                Case "A"
                    instruc_busq = "Select IQAreas_Descripcion from IQ_Areas where IQAreas_Codigo = '" & cod_busq & "'"
                    mensaje_recup = "RECUPERANDO PLANTILLA NIVEL AREA: "
                Case "K"
                    instruc_busq = "Select IQConfigOfic_Descripcion from IQ_ConfigOfic where IQConfigOfic_Codigo = '" & cod_busq & "'"
                    mensaje_recup = "RECUPERANDO PLANTILLA NIVEL TIQUETERA: "
                Case "L"
                    instruc_busq = "Select IQConfigOfic_Descripcion from IQ_ConfigOfic where IQConfigOfic_Codigo = '" & cod_busq & "'"
                    mensaje_recup = "RECUPERANDO PLANTILLA NIVEL PANTALLA: "
            End Select
            Dim Carga_Coneccion_O2c As New OleDb.OleDbConnection(Cnn_Central_Server)
            Dim Carga_Comando_O2c As New OleDb.OleDbCommand(instruc_busq, Carga_Coneccion_O2c)
            Carga_Coneccion_O2c.Open()
            Dim Carga_Reader_O2c As OleDb.OleDbDataReader = Carga_Comando_O2c.ExecuteReader(CommandBehavior.CloseConnection)
            While Carga_Reader_O2c.Read
                If IsDBNull(Carga_Reader_O2c.GetValue(0)) = False Then
                    mensaje_recup = mensaje_recup & Carga_Reader_O2c.GetValue(0)
                End If
            End While
            Carga_Coneccion_O2c.Dispose()
            GoTo Busca_Fin
        End If
        If encontrado = False Then
            Dim Carga_Coneccion_O2b As New OleDb.OleDbConnection(Cnn_Central_Server)
            Carga_Coneccion_O2b.Open()
            Dim instruc_busq As String = ""
            Select Case tipo_busq
                Case "A"
                    instruc_busq = "Select IQAreas_Oficina from IQ_Areas where IQAreaS_Codigo = '" & cod_busq & "'"
                Case "K"
                    instruc_busq = "Select IQConfigOfic_Oficina from IQ_ConfigOfic where IQConfigOfic_Codigo = '" & cod_busq & "'"
                Case "L"
                    instruc_busq = "Select IQConfigOfic_Oficina from IQ_ConfigOfic where IQConfigOfic_Codigo = '" & cod_busq & "'"
            End Select
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
                If encontrado = False Then
                    mensaje_recup = "RECUPERANDO PLANTILLA NIVEL OFICINA: " & Carga_Reader_O3.GetValue(5)
                End If
                encontrado = True
                file_data(indice, 0) = Carga_Reader_O3.GetValue(3)
                file_data(indice, 1) = Carga_Reader_O3.GetValue(4)
                file_data(indice, 2) = Carga_Reader_O3.GetValue(5)
                file_data(indice, 3) = CStr(Carga_Reader_O3.GetValue(6))
                file_data(indice, 4) = CStr(Carga_Reader_O3.GetValue(7))
                file_data(indice, 5) = Carga_Reader_O3.GetValue(8)
                indice += 1
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
                file_data(indice, 0) = Carga_Reader_O4.GetValue(3)
                file_data(indice, 1) = Carga_Reader_O4.GetValue(4)
                file_data(indice, 2) = Carga_Reader_O4.GetValue(5)
                file_data(indice, 3) = CStr(Carga_Reader_O4.GetValue(6))
                file_data(indice, 4) = CStr(Carga_Reader_O4.GetValue(7))
                file_data(indice, 5) = Carga_Reader_O4.GetValue(8)
                indice += 1
            End If
        End While
        Carga_Coneccion_O4.Dispose()
        If encontrado = True Then
            mensaje_recup = "RECUPERANDO PLANTILLA NIVEL GLOBAL"
            GoTo Busca_Fin
        End If
Busca_Fin:
        If mensaje_recup <> "" Then
            MessageBox.Show(mensaje_recup, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Formatea_Grid()
        Me.TrvOficinas.Enabled = False
        If Permisos > 3 Then
            Me.CmdExec.Visible = True
        Else
            Me.CmdExec.Visible = False
        End If
        If DictAccesos.Valor_Permiso("Iq_0213") <> Nothing Then
            Me.CmdTipTram.Visible = True
        Else
            Me.CmdTipTram.Visible = False
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
        toolTip1.SetToolTip(CmdTipTram, "Definición de Tipos de Trámite del Area")
        toolTip1.SetToolTip(CmdReport, "Reporte")
        toolTip1.SetToolTip(CmdSearch, "Buscar")
        toolTip1.SetToolTip(CmdExit, "Salir")
        toolTip1.SetToolTip(CmdExec, "Grabar")
        toolTip1.SetToolTip(CmdClean, "Limpiar")
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
                'Busca_Kioskos(Carga_Reader_O.GetValue(0), num_nodos(0), nivel_nodo)
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
        Tipo_Env = ""
        Me.CmdExec.Visible = False
        Me.CmdTipTram.Visible = False
        Me.CmdNewSearch.Visible = False
        Me.crvReporte.Visible = False
        Me.CmdSearch.Visible = True
        Me.CmdRefresh.Visible = True
        Me.CmdReport.Visible = False
        Me.GridDatos.Visible = False
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
            Tipo_Env = ""
            TrvOficinas.Nodes(0).ForeColor = Color.Green
            nivel_nodo = 0
            limpia_nodos(0, nivel_nodo)
            Me.TrvOficinas.Enabled = True
            Me.TrvOficinas.CollapseAll()
            Me.CmdExec.Visible = False
            Me.CmdRefresh.Visible = True
            Me.CmdTipTram.Visible = False
            Me.CmdNewSearch.Visible = False
            Me.CmdSearch.Visible = True
            Me.CmdReport.Visible = False
            Me.TrvOficinas.Focus()
        End If
    End Sub
    Private Sub Formatea_Grid()
        With Me.GridDatos
            .TableStyles.Clear()
        End With
        TablaDatos.Columns.Clear()
        TablaDatos.Rows.Clear()
        ColumnaCodigo.DataType = System.Type.GetType("System.String")
        ColumnaDescripcion.DataType = System.Type.GetType("System.String")
        ColumnaPrefijo.DataType = System.Type.GetType("System.String")
        ColumnaPrioridad.DataType = System.Type.GetType("System.Int32")
        ColumnaTiempo.DataType = System.Type.GetType("System.Int32")
        ColumnaTarjeta.DataType = System.Type.GetType("System.String")
        ColumnaCodigo.ColumnName = "Codigo"
        ColumnaDescripcion.ColumnName = "Descripcion"
        ColumnaPrefijo.ColumnName = "Prefijo"
        ColumnaPrioridad.ColumnName = "Prioridad"
        ColumnaTiempo.ColumnName = "Tiempo"
        ColumnaTarjeta.ColumnName = "Tarjeta"
        ColumnaCodigo.Caption = ""
        ColumnaDescripcion.Caption = ""
        ColumnaPrefijo.Caption = ""
        ColumnaPrioridad.Caption = ""
        ColumnaTiempo.Caption = ""
        ColumnaTarjeta.Caption = ""
        ColumnaCodigo.AllowDBNull = False
        ColumnaDescripcion.AllowDBNull = False
        ColumnaPrefijo.AllowDBNull = False
        ColumnaPrioridad.AllowDBNull = False
        ColumnaTiempo.AllowDBNull = False
        ColumnaTarjeta.AllowDBNull = False
        ColumnaCodigo.AutoIncrement = False
        ColumnaDescripcion.AutoIncrement = False
        ColumnaPrefijo.AutoIncrement = False
        ColumnaPrioridad.AutoIncrement = False
        ColumnaTiempo.AutoIncrement = False
        ColumnaTarjeta.AutoIncrement = False
        ColumnaCodigo.ReadOnly = False
        ColumnaDescripcion.ReadOnly = False
        ColumnaPrefijo.ReadOnly = False
        ColumnaPrioridad.ReadOnly = False
        ColumnaTiempo.ReadOnly = False
        ColumnaTarjeta.ReadOnly = False
        TablaDatos.Columns.Add(ColumnaCodigo)
        TablaDatos.Columns.Add(ColumnaDescripcion)
        TablaDatos.Columns.Add(ColumnaPrefijo)
        TablaDatos.Columns.Add(ColumnaPrioridad)
        TablaDatos.Columns.Add(ColumnaTiempo)
        TablaDatos.Columns.Add(ColumnaTarjeta)
        TablaDatos.DefaultView.AllowNew = True
        Dim fila As DataRow
        Dim indice_string As Integer = 0
        For indice_string = 0 To 99
            If file_data(indice_string, 0) <> "" Then
                fila = TablaDatos.NewRow
                fila("Codigo") = file_data(indice_string, 0)
                fila("Descripcion") = file_data(indice_string, 1)
                fila("Prefijo") = file_data(indice_string, 2)
                fila("Prioridad") = CInt(file_data(indice_string, 3))
                fila("Tiempo") = CInt(file_data(indice_string, 4))
                fila("Tarjeta") = file_data(indice_string, 5)
                TablaDatos.Rows.Add(fila)
            End If
        Next
        Dim table_style As New DataGridTableStyle
        table_style.MappingName = TablaDatos.TableName
        Dim Codigo_Style As New DataGridTextBoxColumn
        With Codigo_Style
            .Alignment = HorizontalAlignment.Left
            .MappingName = "Codigo"
            .HeaderText = "Código (XXX)"
            .Width = 80
        End With
        Dim Descripcion_Style As New DataGridTextBoxColumn
        With Descripcion_Style
            .Alignment = HorizontalAlignment.Left
            .MappingName = "Descripcion"
            .HeaderText = "Descripción (X100)"
            .Width = 200
        End With
        Dim Prefijo_Style As New DataGridTextBoxColumn
        With Prefijo_Style
            .Alignment = HorizontalAlignment.Left
            .MappingName = "Prefijo"
            .HeaderText = "Prefijo (XXX)"
            .Width = 80
        End With
        Dim Prioridad_Style As New DataGridTextBoxColumn
        With Prioridad_Style
            .Alignment = HorizontalAlignment.Right
            .MappingName = "Prioridad"
            .HeaderText = "Prioridad (#)|"
            .Width = 100
        End With
        Dim Tiempo_style As New DataGridTextBoxColumn
        With Tiempo_style
            .Alignment = HorizontalAlignment.Right
            .MappingName = "Tiempo"
            .HeaderText = "Max.Espera (###)|"
            .Width = 110
        End With
        Dim Tarjeta_style As New DataGridComboBoxColumn
        With Tarjeta_style
            .Alignment = HorizontalAlignment.Left
            .MappingName = "Tarjeta"
            .HeaderText = "Tarjeta (Si/No)"
            .Width = 100
            .ColumnComboBox.DataSource = DsSiNo.Tables("Iq_VwSiNo").DefaultView
            .ColumnComboBox.DisplayMember = "IqVwSiNo_Descripcion"
            .ColumnComboBox.ValueMember = "IqVwSiNo_Codigo"
        End With
        table_style.GridColumnStyles.AddRange _
            (New DataGridColumnStyle() _
            {Codigo_Style, Descripcion_Style, Prefijo_Style, Prioridad_Style, Tiempo_style, Tarjeta_style})
        Me.GridDatos.TableStyles.Add(table_style)
        Me.GridDatos.DataSource = TablaDatos
        Me.GridDatos.CaptionVisible = False
        Me.GridDatos.Visible = True
    End Sub
    Private Sub CmdExec_Click(sender As Object, e As EventArgs) Handles CmdExec.Click
        If MessageBox.Show("Está Ud. seguro de GRABAR los tipos de ticket?", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Try
            Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
            IQ_Cnn.Open()
            Dim IQ_Cmm As New OleDb.OleDbCommand("Delete from IQ_TipoTick Where IQTipTick_Oficina = '" + alcance(0) & "' And IQTipTick_Area = '" + alcance(1) & "' And IQTipTick_Punto = '" + alcance(2) & "'", IQ_Cnn)
            Dim RegistrosEliminados As Long = IQ_Cmm.ExecuteNonQuery()
            IQ_Cnn.Close()
        Catch exc As Exception
            Dim Mensaje_Excepcion As String
            Mensaje_Excepcion = exc.Message
            Mensaje_Excepcion = "Error Integrado: " + Mensaje_Excepcion
            MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
        If alcance(2) <> "" Then
            GoTo Fin_Limpia
        End If
        If alcance(1) <> "" Then
            If Mid(alcance(1), 1, 1) = "A" Then
                Dim Carga_Coneccion_O2 As New OleDb.OleDbConnection(Cnn_Central_Server)
                Carga_Coneccion_O2.Open()
                Dim Carga_Comando_O2 As New OleDb.OleDbCommand("Select IqPuntos_Codigo from IQ_PuntosAtencion where IqPuntos_Area = '" & Mid(alcance(1), 3, Len(alcance(1)) - 2) & "'", Carga_Coneccion_O2)
                Dim Carga_Reader_O2 As OleDb.OleDbDataReader = Carga_Comando_O2.ExecuteReader(CommandBehavior.CloseConnection)
                While Carga_Reader_O2.Read
                    If IsDBNull(Carga_Reader_O2.GetValue(0)) = False Then
                        Try
                            Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
                            IQ_Cnn.Open()
                            Dim IQ_Cmm As New OleDb.OleDbCommand("Delete from IQ_TipoTick Where IQTipTick_Oficina = '' And IQTipTick_Area = '' And IQTipTick_Punto = '" + Carga_Reader_O2.GetValue(0) & "'", IQ_Cnn)
                            Dim RegistrosEliminados As Long = IQ_Cmm.ExecuteNonQuery()
                            IQ_Cnn.Close()
                        Catch exc As Exception
                            Dim Mensaje_Excepcion As String
                            Mensaje_Excepcion = exc.Message
                            Mensaje_Excepcion = "Error Integrado: " + Mensaje_Excepcion
                            MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End Try
                    End If
                End While
                Carga_Coneccion_O2.Dispose()
            End If
            GoTo fin_limpia
        End If
        If alcance(0) = "999999" Then
            Try
                Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
                IQ_Cnn.Open()
                Dim IQ_Cmm As New OleDb.OleDbCommand("Delete from IQ_TipoTick", IQ_Cnn)
                Dim RegistrosEliminados As Long = IQ_Cmm.ExecuteNonQuery()
                IQ_Cnn.Close()
                GoTo fin_limpia
            Catch exc As Exception
                Dim Mensaje_Excepcion As String
                Mensaje_Excepcion = exc.Message
                Mensaje_Excepcion = "Error Integrado: " + Mensaje_Excepcion
                MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        End If
        LImpia_Kioskos(alcance(0))
        LImpia_Areas(alcance(0))
        Dim Carga_Coneccion_O As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O.Open()
        Dim Carga_Comando_O As New OleDb.OleDbCommand("Select IqOficinas_Codigo from IQ_Oficinas where IqOficinas_Consolidacion = '" & alcance(0) & "'", Carga_Coneccion_O)
        Dim Carga_Reader_O As OleDb.OleDbDataReader = Carga_Comando_O.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O.Read
            Limpia_Oficinas(Carga_Reader_O.GetValue(0))
            LImpia_Kioskos(Carga_Reader_O.GetValue(0))
            LImpia_Areas(Carga_Reader_O.GetValue(0))
        End While
        Carga_Coneccion_O.Dispose()
Fin_Limpia:
        Dim registros As Integer = 0
        For indice = 0 To TablaDatos.Rows.Count - 1
            Dim instruccion_insert As String = ""
            instruccion_insert = "Insert Into IQ_TipoTick Values('" + alcance(0) + "', '" + alcance(1) + "', '" & alcance(2) + "', "
            instruccion_insert = instruccion_insert & "'" & TablaDatos.Rows(indice)("Codigo") & "', "
            instruccion_insert = instruccion_insert & "'" & TablaDatos.Rows(indice)("Descripcion") & "', "
            instruccion_insert = instruccion_insert & "'" & TablaDatos.Rows(indice)("Prefijo") & "', "
            instruccion_insert = instruccion_insert & CStr(TablaDatos.Rows(indice)("Prioridad")) & ", "
            instruccion_insert = instruccion_insert & CStr(TablaDatos.Rows(indice)("Tiempo")) & ", "
            instruccion_insert = instruccion_insert & "'" & TablaDatos.Rows(indice)("Tarjeta") & "')"
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
                'Busca_Kioskos(Carga_Reader_O.GetValue(0), num_nodos(0), nivel_nodo)
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
    Private Sub Grid_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
        Dim valor_ingresado As String
        If e.Column.ColumnName.Equals("Codigo") Then
            valor_ingresado = CType(e.ProposedValue, String)
            If Len(valor_ingresado) > 3 Then
                Dim badValue As Object = e.ProposedValue
                e.ProposedValue = e.Row("Codigo")
                Exit Sub
            End If
        ElseIf e.Column.ColumnName.Equals("Descripcion") Then
            valor_ingresado = CType(e.ProposedValue, String)
            If Len(valor_ingresado) > 100 Then
                Dim badValue As Object = e.ProposedValue
                e.ProposedValue = e.Row("Descripcion")
                Exit Sub
            End If
        ElseIf e.Column.ColumnName.Equals("Prefijo") Then
            valor_ingresado = CType(e.ProposedValue, String)
            If Len(valor_ingresado) > 3 Then
                Dim badValue As Object = e.ProposedValue
                e.ProposedValue = e.Row("Prefijo")
                Exit Sub
            End If
        ElseIf e.Column.ColumnName.Equals("Prioridad") Then
            valor_ingresado = CType(e.ProposedValue, String)
            If IsNumeric(valor_ingresado) = False Then
                Dim badValue As Object = e.ProposedValue
                e.ProposedValue = e.Row("Prioridad")
                Exit Sub
            ElseIf CDbl(valor_ingresado) > 9 Or CDbl(valor_ingresado) < 0 Then
                Dim badValue As Object = e.ProposedValue
                e.ProposedValue = e.Row("Prioridad")
                Exit Sub
            End If
        ElseIf e.Column.ColumnName.Equals("Tiempo") Then
            valor_ingresado = CType(e.ProposedValue, String)
            If IsNumeric(valor_ingresado) = False Then
                Dim badValue As Object = e.ProposedValue
                e.ProposedValue = e.Row("Tiempo")
                Exit Sub
            ElseIf CDbl(valor_ingresado) > 999 Or CDbl(valor_ingresado) < 1 Then
                Dim badValue As Object = e.ProposedValue
                e.ProposedValue = e.Row("Tiempo")
                Exit Sub
            End If
        End If
    End Sub
    Private Sub GridValores_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDatos.DoubleClick
        If Me.GridDatos.VisibleRowCount = 0 Then
            Exit Sub
        End If
        Try
            Tipo_Env = Me.GridDatos.Item(Me.GridDatos.CurrentCell.RowNumber, 0)
            Desc_Env = Me.GridDatos.Item(Me.GridDatos.CurrentCell.RowNumber, 1)
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
    Private Sub CmdTipTram_Click(sender As Object, e As EventArgs) Handles CmdTipTram.Click
        If Tipo_Env = "" Then
            Exit Sub
        End If
        Dim obj As Object = Activator.CreateInstance(Type.GetType("IQ_Core.IQ_C0024"))
        Dim f As Form = CType(obj, Form)
        f.Location = New Point(0, Me.Top + 60)
        f.Width = Me.Width - 25
        f.Height = Me.Height - 60
        f.Text = "Definición de Tipos de Trámite" & "|" & Trim(CStr(DictAccesos.Valor_Permiso("Iq_0213"))) & "|" & Tipo_Env & "|" & Desc_Env
        f.Show()
    End Sub
End Class