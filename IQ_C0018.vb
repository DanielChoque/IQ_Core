Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Public Class IQ_C0018
    Inherits System.Windows.Forms.Form
    Dim Permisos As Integer = 0
    Dim num_nodos_ofic(10) As Integer
    Dim nivel_nodo_ofic As Integer
    Dim indice_nodos_ofic As Integer
    Dim num_nodos_tick(10) As Integer
    Dim nivel_nodo_tick As Integer
    Dim indice_nodos_tick As Integer
    Dim num_nodos_punto(10) As Integer
    Dim nivel_nodo_punto As Integer
    Dim indice_nodos_punto As Integer
    Dim ind_ofic As Integer
    Dim ind_tick As Integer
    Dim ind_punto As Integer
    Private DictOficinas As New ColeccionOficinas
    Private DictPuntos As New ColeccionPuntos
    Private DictTickets As New ColeccionTickets
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
    Private Class ColeccionPuntos
        Inherits System.Collections.DictionaryBase

        Public Sub Add_ColeccionPuntos(ByVal Key As String, ByVal Item As String)
            Dictionary.Add(Key, Item)
        End Sub

        Public Function Valor(ByVal Key As String) As String
            Valor = Dictionary.Item(Key)
        End Function
    End Class
    Private Class ColeccionTickets
        Inherits System.Collections.DictionaryBase

        Public Sub Add_ColeccionTickets(ByVal Key As String, ByVal Item As String)
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
            Busca_Areas(Carga_Reader_O2.GetValue(0), num_nodos_ofic(Nivel), Nivel + 1)
            num_nodos_ofic(Nivel) += 1
        End While
        Carga_Coneccion_O2.Dispose()
    End Sub
    Private Sub Busca_Areas(ByVal Codigo As String, ByVal Nodo As Integer, ByVal Nivel As Integer)
        Dim Carga_Coneccion_O2 As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O2.Open()
        Dim Carga_Comando_O2 As New OleDb.OleDbCommand("Select IqAreas_Codigo, IqAreas_Descripcion from IQ_Areas where IqAreas_Oficina = '" & Codigo & "' order by IqAreas_Codigo", Carga_Coneccion_O2)
        Dim Carga_Reader_O2 As OleDb.OleDbDataReader = Carga_Comando_O2.ExecuteReader(CommandBehavior.CloseConnection)
        num_nodos_ofic(Nivel) = 0
        While Carga_Reader_O2.Read
            Select Case Nivel
                Case 0
                    Me.TrvOficinas.Nodes(0).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|A:" & Carga_Reader_O2.GetValue(0))
                Case 1
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos_ofic(Nivel - 1)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|A:" & Carga_Reader_O2.GetValue(0))
                Case 2
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos_ofic(0)).Nodes(num_nodos_ofic(1)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|A:" & Carga_Reader_O2.GetValue(0))
                Case 3
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos_ofic(0)).Nodes(num_nodos_ofic(1)).Nodes(num_nodos_ofic(2)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|A:" & Carga_Reader_O2.GetValue(0))
                Case 4
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos_ofic(0)).Nodes(num_nodos_ofic(1)).Nodes(num_nodos_ofic(2)).Nodes(num_nodos_ofic(3)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|A:" & Carga_Reader_O2.GetValue(0))
                Case 5
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos_ofic(0)).Nodes(num_nodos_ofic(1)).Nodes(num_nodos_ofic(2)).Nodes(num_nodos_ofic(3)).Nodes(num_nodos_ofic(4)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|A:" & Carga_Reader_O2.GetValue(0))
                Case 6
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos_ofic(0)).Nodes(num_nodos_ofic(1)).Nodes(num_nodos_ofic(2)).Nodes(num_nodos_ofic(3)).Nodes(num_nodos_ofic(4)).Nodes(num_nodos_ofic(5)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|A:" & Carga_Reader_O2.GetValue(0))
                Case 7
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos_ofic(0)).Nodes(num_nodos_ofic(1)).Nodes(num_nodos_ofic(2)).Nodes(num_nodos_ofic(3)).Nodes(num_nodos_ofic(4)).Nodes(num_nodos_ofic(5)).Nodes(num_nodos_ofic(6)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|A:" & Carga_Reader_O2.GetValue(0))
                Case 8
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos_ofic(0)).Nodes(num_nodos_ofic(1)).Nodes(num_nodos_ofic(2)).Nodes(num_nodos_ofic(3)).Nodes(num_nodos_ofic(4)).Nodes(num_nodos_ofic(5)).Nodes(num_nodos_ofic(6)).Nodes(num_nodos_ofic(7)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|A:" & Carga_Reader_O2.GetValue(0))
                Case 9
                    Me.TrvOficinas.Nodes(0).Nodes(num_nodos_ofic(0)).Nodes(num_nodos_ofic(1)).Nodes(num_nodos_ofic(2)).Nodes(num_nodos_ofic(3)).Nodes(num_nodos_ofic(4)).Nodes(num_nodos_ofic(5)).Nodes(num_nodos_ofic(6)).Nodes(num_nodos_ofic(7)).Nodes(num_nodos_ofic(8)).Nodes.Add(Carga_Reader_O2.GetValue(1) & Space(500) & "|A:" & Carga_Reader_O2.GetValue(0))
            End Select
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
    Private Sub CmdNewSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CmdNewSearch.Click
        If MessageBox.Show("Está Ud. seguro de ABANDONAR el alcance actual y efectuar una nueva búsqueda?", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        CmdClean_Click(CmdNewSearch, e)
    End Sub
    Private Sub CmdClean_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CmdClean.Click
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
        Me.LblDestino.Visible = False
        Me.LblTicket.Visible = False
        Me.Label2.Visible = False
        Me.Label4.Visible = False
        Me.TrvDestinos.Visible = False
        Me.TrvTickets.Visible = False
        Me.CmdExec.Visible = False
        Me.CmdNewSearch.Visible = False
        Me.CmdSearch.Visible = True
        Me.TrvOficinas.Focus()
    End Sub
    Private Sub TrvTicket_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrvTickets.DoubleClick
        If Me.TrvTickets.SelectedNode.ForeColor = Color.Green Then
            Me.TrvTickets.SelectedNode.ForeColor = Color.Black
            Me.LblTicket.Text = ""
        Else
            Me.TrvTickets.SelectedNode.ForeColor = Color.Green
            Me.LblTicket.Text = Me.TrvTickets.SelectedNode.Text
            For Each NODITO In TrvTickets.Nodes
                If NODITO.Text <> Me.LblTicket.Text Then
                    NODITO.ForeColor = Color.Black
                End If
            Next
        End If
    End Sub
    Private Sub TrvDestinos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrvDestinos.DoubleClick
        If Me.TrvDestinos.SelectedNode.ForeColor = Color.Green Then
            Me.TrvDestinos.SelectedNode.ForeColor = Color.Black
            Me.LblDestino.Text = ""
        Else
            Me.TrvDestinos.SelectedNode.ForeColor = Color.Green
            Me.LblDestino.Text = Me.TrvDestinos.SelectedNode.Text
            For Each NODITO In TrvDestinos.Nodes
                If NODITO.Text <> Me.LblDestino.Text Then
                    NODITO.ForeColor = Color.Black
                End If
            Next
        End If
    End Sub
    Private Sub CmdRefresh_Click(sender As Object, e As EventArgs) Handles CmdRefresh.Click
        If CmdSearch.Visible = True Then
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
                    Busca_Areas(Carga_Reader_O.GetValue(0), num_nodos_ofic(0), nivel_nodo_ofic)
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
                    Busca_Areas(Carga_Reader_O.GetValue(0), 0, nivel_nodo_ofic)
                    Me.LblAplicacion.Text = Carga_Reader_O.GetValue(1)
                    alcance(0) = Computer_Ofic
                    alcance(1) = ""
                    alcance(2) = ""
                End While
                Carga_Coneccion_O.Dispose()
            End If
        End If
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
        toolTip1.SetToolTip(CmdNewSearch, "Nueva Búsqueda")
        toolTip1.SetToolTip(CmdSearch, "Buscar")
        toolTip1.SetToolTip(CmdExit, "Salir")
        toolTip1.SetToolTip(CmdExec, "Ejecutar")
        toolTip1.SetToolTip(CmdClean, "Limpiar")
        toolTip1.SetToolTip(CmdRefresh, "Actualizar Listas")
        Me.LblDestino.Visible = False
        Me.LblTicket.Visible = False
        Me.Label2.Visible = False
        Me.Label4.Visible = False
        Me.TrvDestinos.Visible = False
        Me.TrvTickets.Visible = False
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
                Busca_Areas(Carga_Reader_O.GetValue(0), num_nodos_ofic(0), nivel_nodo_ofic)
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
                Busca_Areas(Carga_Reader_O.GetValue(0), 0, nivel_nodo_ofic)
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
        Me.CmdClean.Enabled = True
        Me.CmdExec.Enabled = True
        Me.CmdExit.Enabled = True
        Me.CmdNewSearch.Enabled = True
        Me.CmdSearch.Enabled = True
        Me.TrvOficinas.Enabled = True
        Me.CmdExec.Visible = False
        Me.CmdNewSearch.Visible = False
        Me.CmdSearch.Visible = True
    End Sub
    Private Sub CmdSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CmdSearch.Click
        Dim Ofic_recup As String = ""
        Dim Area_recup As String = ""
        Dim encontrado As Boolean = False
        Dim mensaje_recup As String = ""
        If alcance(1) <> "" Then
            Area_recup = Mid(alcance(1), 3, Len(alcance(1)) - 2)
        Else
            Ofic_recup = alcance(0)
        End If
        num_nodos_tick(0) = 0
        Me.TrvTickets.Nodes.Clear()
        Dim Carga_Coneccion_O As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O.Open()
        Dim instruc_warning As String
        If Area_recup <> "" Then
            instruc_warning = "select IQ_Pending.*, IQAreas_Oficina, IQAreas_Descripcion from IQ_Pending Join IQ_Areas on IQPending_Area = IQAreas_Codigo where IQPending_Area = '" & Area_recup & "' And IQPending_Punto = '' order by IQAreas_Oficina, IQPending_Area, IQPending_Ticket"
        ElseIf Ofic_recup <> "999999" Then
            instruc_warning = "select IQ_Pending.*, IQAreas_Oficina, IQAreas_Descripcion from IQ_Pending Join IQ_Areas on IQPending_Area = IQAreas_Codigo where IQAreas_Oficina = '" & Ofic_recup & "' And IQPending_Punto = '' order by IQAreas_Oficina, IQPending_Area, IQPending_Ticket"
        Else
            instruc_warning = "select IQ_Pending.*, IQAreas_Oficina, IQAreas_Descripcion from IQ_Pending Join IQ_Areas on IQPending_Area = IQAreas_Codigo where IQPending_Punto = '' order by IQAreas_Oficina, IQPending_Area, IQPending_Ticket"
        End If
        Dim Carga_Comando_O As New OleDb.OleDbCommand(instruc_warning, Carga_Coneccion_O)
        Dim Carga_Reader_O As OleDb.OleDbDataReader = Carga_Comando_O.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O.Read
            Me.TrvTickets.Nodes.Add("Tk:" & Carga_Reader_O.GetValue(1) & "; Of:" & Carga_Reader_O.GetValue(10) & "; Area:" & Carga_Reader_O.GetValue(11) & "((" & Carga_Reader_O.GetValue(0) & "))")
            nivel_nodo_tick = 1
            num_nodos_tick(0) += 1
        End While
        Carga_Coneccion_O.Dispose()
        Me.LblTicket.Text = ""
        Me.LblTicket.Visible = True
        Me.TrvTickets.Visible = True
        num_nodos_punto(0) = 0
        Me.TrvDestinos.Nodes.Clear()
        Dim Carga_Coneccion_O2 As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O2.Open()
        If Area_recup <> "" Then
            instruc_warning = "select IQ_PuntosAtencion.*, IQAreas_Oficina, IQAreas_Descripcion from IQ_PuntosAtencion Join IQ_Areas on IQPuntos_Area = IQAreas_Codigo Join IQ_Workstations on IQPuntos_Codigo = IQWS_CodPunto where IQPuntos_Area = '" & Area_recup & "'  and (iqws_status = 'l' or iqws_status = 'b' or iqws_status = 't') order by IQAreas_Oficina, IQPuntos_Area, IQPuntos_Codigo"
        ElseIf Ofic_recup <> "999999" Then
            instruc_warning = "select IQ_PuntosAtencion.*, IQAreas_Oficina, IQAreas_Descripcion from IQ_PuntosAtencion Join IQ_Areas on IQPuntos_Area = IQAreas_Codigo Join IQ_Workstations on IQPuntos_Codigo = IQWS_CodPunto where IQAreas_Oficina = '" & Ofic_recup & "'  and (iqws_status = 'l' or iqws_status = 'b' or iqws_status = 't') order by IQAreas_Oficina, IQPuntos_Area, IQPuntos_Codigo"
        Else
            instruc_warning = "select IQ_PuntosAtencion.*, IQAreas_Oficina, IQAreas_Descripcion from IQ_PuntosAtencion Join IQ_Areas on IQPuntos_Area = IQAreas_Codigo Join IQ_Workstations on IQPuntos_Codigo = IQWS_CodPunto WHERE  (iqws_status = 'l' or iqws_status = 'b' or iqws_status = 't')  order by IQAreas_Oficina, IQPuntos_Area, IQPuntos_Codigo"
        End If
        Dim Carga_Comando_O2 As New OleDb.OleDbCommand(instruc_warning, Carga_Coneccion_O2)
        Dim Carga_Reader_O2 As OleDb.OleDbDataReader = Carga_Comando_O2.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O2.Read
            Me.TrvDestinos.Nodes.Add(Carga_Reader_O2.GetValue(2) & "; Of:" & Carga_Reader_O2.GetValue(7) & "; Area:" & Carga_Reader_O2.GetValue(8) & Space(500) & ">>" & Carga_Reader_O2.GetValue(0) & "<<" & Carga_Reader_O2.GetValue(6))
            nivel_nodo_punto = 1
            num_nodos_punto(0) += 1
        End While
        Carga_Coneccion_O2.Dispose()
        Me.LblDestino.Text = ""
        Me.LblDestino.Visible = True
        Me.Label2.Visible = True
        Me.Label4.Visible = True
        Me.TrvDestinos.Visible = True
        Me.TrvOficinas.Enabled = False
        If Permisos > 3 Then
            Me.CmdExec.Visible = True
        Else
            Me.CmdExec.Visible = False
        End If
        Me.CmdNewSearch.Visible = True
        Me.CmdSearch.Visible = False
    End Sub
    Private Sub CmdExec_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CmdExec.Click
        If Trim(Me.LblTicket.Text) = "" Or Trim(Me.LblDestino.Text) = "" Then
            MessageBox.Show("PAAR PODER ASIGNAR UN TICKET, DEBE SELECCIONAR TANTO EL TICKET COMO EL PUNTO DE ATENCION DE DESTINO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim Punto As String = ""
        Dim Codigo_Area As String = ""
        Dim Codigo_Punto As String = ""
        Dim Codigo_Ticket As String = ""
        Dim Pos_Area As Integer = InStr(Me.LblTicket.Text, "((")
        Dim Pos_Ticket As Integer = InStr(Me.LblTicket.Text, ";")
        Dim Pos_Punto As Integer = InStr(Me.LblDestino.Text, ">>")
        Dim Pos_Sigla As Integer = InStr(Me.LblDestino.Text, "<<")
        Codigo_Ticket = Mid(Me.LblTicket.Text, 4, Pos_Ticket - 4)
        Codigo_Area = Mid(Me.LblTicket.Text, Pos_Area + 2, Len(Me.LblTicket.Text) - (Pos_Area + 3))
        Punto = Mid(Me.LblDestino.Text, Pos_Sigla + 2, Len(Me.LblDestino.Text) - (Pos_Sigla - 1))
        Codigo_Punto = Mid(Me.LblDestino.Text, Pos_Punto + 2, Pos_Sigla - (Pos_Punto + 2))
        Dim instruccion_insert As String = ""
        instruccion_insert = "Update Iq_Tickets Set IQTicket_Punto = '" & Codigo_Punto & "', IQTicket_Estado = 'R',  IQTicket_Asignacion = getdate() where IQTicket_Area = '" & Codigo_Area & "' and IQTicket_Ticket = '" & Codigo_Ticket & "' And IQTicket_Estado = 'E' and IQTicket_Fecha = CONVERT(varchar(10), getdate(), 111)"
        Try
            Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
            IQ_Cnn.Open()
            Dim IQ_Cmm As New OleDb.OleDbCommand(instruccion_insert, IQ_Cnn)
            Dim RegistrosInsertados As Long = IQ_Cmm.ExecuteNonQuery()
            IQ_Cnn.Close()
        Catch exc As Exception
            Dim Mensaje_Excepcion As String
            Mensaje_Excepcion = exc.Message
            MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
        instruccion_insert = "Update Iq_Pending Set IQPending_Punto = '" & Punto & "', IQPending_CodPunto = '', IQPending_Redirect = '" & Codigo_Punto & "', IQPending_Asignado = GETDATE(), IqPending_Call = 'S' where IQPending_Area = '" & Codigo_Area & "' and IQPending_Ticket = '" & Codigo_Ticket & "'"
        Try
            Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
            IQ_Cnn.Open()
            Dim IQ_Cmm As New OleDb.OleDbCommand(instruccion_insert, IQ_Cnn)
            Dim RegistrosInsertados As Long = IQ_Cmm.ExecuteNonQuery()
            IQ_Cnn.Close()
        Catch exc As Exception
            Dim Mensaje_Excepcion As String
            Mensaje_Excepcion = exc.Message
            MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
        Dim Central_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
        Dim CmmCentral As New OleDb.OleDbCommand("", Central_Cnn)
        CmmCentral.CommandTimeout = 0
        CmmCentral.CommandType = CommandType.StoredProcedure
        CmmCentral.CommandText = "IQ_SpAssign"
        CmmCentral.Parameters.Add("Destino", OleDbType.VarChar, 19).Value = Codigo_Punto
        CmmCentral.Parameters.Add("Area", OleDbType.VarChar, 19).Value = Codigo_Area
        CmmCentral.Parameters.Add("NT", OleDbType.VarChar, 19).Value = Codigo_Ticket
        CmmCentral.Parameters.Add("Resultado", OleDbType.VarChar, 100).Direction = ParameterDirection.Output
        Try
            Central_Cnn.Open()
            CmmCentral.ExecuteNonQuery()
            Central_Cnn.Close()
        Catch exc As Exception
            Dim Mensaje_Excepcion As String
            Mensaje_Excepcion = exc.Message
            MessageBox.Show("Error Integrado: " + Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
        MessageBox.Show("Ticket asignado satisfactoriamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        CmdClean_Click(CmdNewSearch, e)
    End Sub
End Class