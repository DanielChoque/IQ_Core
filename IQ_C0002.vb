Imports CrystalDecisions.CrystalReports.Engine
Public Class IQ_C0002
    Inherits System.Windows.Forms.Form
    Dim Permisos As Integer = 0
    Dim oficinas_select(100) As String
    Dim num_nodos(10) As Integer
    Dim nivel_nodo As Integer
    Dim ind_ofic As Integer
    Dim indice_nodos As Integer
    Dim horario_file(7) As String
    Private Dictoficinas As New ColeccionOficinas
    Dim alcance(3) As String
    Dim ColumnaHora As New DataColumn
    Dim ColumnaLunes As New DataColumn
    Dim ColumnaMartes As New DataColumn
    Dim ColumnaMiercoles As New DataColumn
    Dim ColumnaJueves As New DataColumn
    Dim ColumnaViernes As New DataColumn
    Dim ColumnaSabado As New DataColumn
    Dim ColumnaDomingo As New DataColumn
    Dim TablaDatos As New DataTable

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles CmdExit.Click
        IQ_C0000.PicFondo.Visible = True
        Me.Dispose()
    End Sub
    Public Sub New()

        InitializeComponent()
        AddHandler TablaDatos.ColumnChanging, AddressOf Horarios_ColumnChanging
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
    Private Sub Limpia_Oficinas(Codigo As String)
        Try
            Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
            IQ_Cnn.Open()
            Dim IQ_Cmm As New OleDb.OleDbCommand("Delete from IQ_Horario Where IQHorario_Oficina = '" + Codigo & "' And IQHorario_Area = '' And IQHorario_Punto = ''", IQ_Cnn)
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
                Dim IQ_Cmm As New OleDb.OleDbCommand("Delete from IQ_Horario Where IQHorario_Oficina = '' And IQHorario_Area = 'K:" & Trim(Carga_Reader_O.GetValue(0)) & "' And IQHorario_Punto = ''", IQ_Cnn)
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
                Dim IQ_Cmm As New OleDb.OleDbCommand("Delete from IQ_Horario Where IQHorario_Oficina = '' And IQHorario_Area = 'A:" & Trim(Carga_Reader_O.GetValue(0)) & "' And IQHorario_Punto = ''", IQ_Cnn)
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
                Dim IQ_Cmm As New OleDb.OleDbCommand("Delete from IQ_Horario Where IQHorario_Oficina = '' And IQHorario_Area = '' And IQHorario_Punto = '" & Trim(Carga_Reader_O.GetValue(0)) & "'", IQ_Cnn)
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
            rptlayout.Load(Disco_Appl & ":\I-Q\IQ_Rpt\IQ_C0002.rpt")
            rptlayout.SetDatabaseLogon(Server_User, Server_Pwd)
            rptlayout.SummaryInfo.ReportTitle = Nombre_Cliente + Chr(10) + Me.Text
            Me.crvReporte.SelectionFormula = "{IQ_Horario.IQHorario_Oficina} = '" + alcance(0) + "' And {IQ_Horario.IQHorario_Area} = '" + alcance(1) + "' And {IQ_Horario.IQHorario_Punto} = '" + alcance(2) + "'"
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
        Dim Alcance_recup(3) As String
        Alcance_recup(0) = alcance(0)
        Alcance_recup(1) = alcance(1)
        Alcance_recup(2) = alcance(2)
        For indice = 0 To 6
            horario_file(indice) = ""
        Next
        Dim encontrado As Boolean = False
        Dim mensaje_recup As String = ""
        If Alcance_recup(2) = "" Then GoTo busca_2
        Dim Carga_Coneccion_O1 As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O1.Open()
        Dim Carga_Comando_O1 As New OleDb.OleDbCommand("Select IQ_Horario.*, IQ_PuntosAtencion.IQPUntos_Descripcion from IQ_Horario join IQ_PuntosAtencion on IQ_Horario.IIQHorario_Punto = IQ_PuntosAtencion.IQPuntos_Codigo where IQHorario_Oficina = '' and IQHorario_Area = '' and IQHorario_Punto = '" & Alcance_recup(2) & "' Order by IQHorario_Dia", Carga_Coneccion_O1)
        Dim Carga_Reader_O1 As OleDb.OleDbDataReader = Carga_Comando_O1.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O1.Read
            If IsDBNull(Carga_Reader_O1.GetValue(0)) = False Then
                If encontrado = False Then
                    mensaje_recup = "RECUPERANDO PLANTILLA NIVEL PUNTO DE ATENCION: " & Carga_Reader_O1.GetValue(5)
                End If
                encontrado = True
                horario_file(Carga_Reader_O1.GetValue(3) - 1) = Carga_Reader_O1.GetValue(4)
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
        Dim Carga_Comando_O2 As New OleDb.OleDbCommand("Select * from IQ_Horario where IQHorario_Oficina = '' and IQHorario_Area = '" & Alcance_recup(1) & "' and IQHorario_Punto = '' Order by IQHorario_Dia", Carga_Coneccion_O2)
        Dim Carga_Reader_O2 As OleDb.OleDbDataReader = Carga_Comando_O2.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O2.Read
            If IsDBNull(Carga_Reader_O2.GetValue(0)) = False Then
                encontrado = True
                horario_file(Carga_Reader_O2.GetValue(3) - 1) = Carga_Reader_O2.GetValue(4)
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
        Dim Carga_Comando_O3 As New OleDb.OleDbCommand("Select IQ_Horario.*, Iq_Oficinas.IQOficinas_Descripcion,  Iq_Oficinas.IQOficinas_Consolidacion from IQ_Horario join IQ_Oficinas on IQHorario_Oficina = IQOficinas_Codigo where IQHorario_Oficina = '" & Alcance_recup(0) & "' and IQHorario_Area = '' and IQHorario_Punto = '' Order by IQHorario_Dia", Carga_Coneccion_O3)
        Dim Carga_Reader_O3 As OleDb.OleDbDataReader = Carga_Comando_O3.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O3.Read
            If IsDBNull(Carga_Reader_O3.GetValue(0)) = False Then
                If encontrado = False Then
                    mensaje_recup = "RECUPERANDO PLANTILLA NIVEL OFICINA: " & Carga_Reader_O3.GetValue(5)
                End If
                encontrado = True
                horario_file(Carga_Reader_O3.GetValue(3) - 1) = Carga_Reader_O3.GetValue(4)
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
        Dim Carga_Comando_O4 As New OleDb.OleDbCommand("Select * from IQ_Horario where IQHorario_Oficina = '999999' and IQHorario_Area = '' and IQHorario_Punto = '' Order by IQHorario_Dia", Carga_Coneccion_O4)
        Dim Carga_Reader_O4 As OleDb.OleDbDataReader = Carga_Comando_O4.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O4.Read
            If IsDBNull(Carga_Reader_O4.GetValue(0)) = False Then
                encontrado = True
                horario_file(Carga_Reader_O4.GetValue(3) - 1) = Carga_Reader_O4.GetValue(4)
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
        Me.CmdNewSearch.Visible = True
        Me.CmdSearch.Visible = False
        Me.CmdRefresh.Visible = False
        Me.CmdReport.Visible = True
        Me.GridDatos.Visible = True
    End Sub
    Private Sub CmdExec_Click(sender As Object, e As EventArgs) Handles CmdExec.Click
        If MessageBox.Show("Está Ud. seguro de GRABAR el horario?", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Try
            Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
            IQ_Cnn.Open()
            Dim IQ_Cmm As New OleDb.OleDbCommand("Delete from IQ_Horario Where IQHorario_Oficina = '" + alcance(0) & "' And IQHorario_Area = '" + alcance(1) & "' And IQHorario_Punto = '" + alcance(2) & "'", IQ_Cnn)
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
                            Dim IQ_Cmm As New OleDb.OleDbCommand("Delete from IQ_Horario Where IQHorario_Oficina = '' And IQHorario_Area = '' And IQHorario_Punto = '" + Carga_Reader_O2.GetValue(0) & "'", IQ_Cnn)
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
                Dim IQ_Cmm As New OleDb.OleDbCommand("Delete from IQ_Horario", IQ_Cnn)
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
        Dim horarios(7) As String
        For indice = 0 To TablaDatos.Rows.Count - 1
            If IsDBNull(TablaDatos.Rows(indice)("Hora")) = False Then
                If TablaDatos.Rows(indice)("Lunes") = "" Then
                    horarios(0) = horarios(0) & " "
                Else
                    horarios(0) = horarios(0) & TablaDatos.Rows(indice)("Lunes")
                End If
                If TablaDatos.Rows(indice)("Martes") = "" Then
                    horarios(1) = horarios(1) & " "
                Else
                    horarios(1) = horarios(1) & TablaDatos.Rows(indice)("Martes")
                End If
                If TablaDatos.Rows(indice)("Miercoles") = "" Then
                    horarios(2) = horarios(2) & " "
                Else
                    horarios(2) = horarios(2) & TablaDatos.Rows(indice)("Miercoles")
                End If
                If TablaDatos.Rows(indice)("Jueves") = "" Then
                    horarios(3) = horarios(3) & " "
                Else
                    horarios(3) = horarios(3) & TablaDatos.Rows(indice)("Jueves")
                End If
                If TablaDatos.Rows(indice)("Viernes") = "" Then
                    horarios(4) = horarios(4) & " "
                Else
                    horarios(4) = horarios(4) & TablaDatos.Rows(indice)("Viernes")
                End If
                If TablaDatos.Rows(indice)("Sabado") = "" Then
                    horarios(5) = horarios(5) & " "
                Else
                    horarios(5) = horarios(5) & TablaDatos.Rows(indice)("Sabado")
                End If
                If TablaDatos.Rows(indice)("Domingo") = "" Then
                    horarios(6) = horarios(6) & " "
                Else
                    horarios(6) = horarios(6) & TablaDatos.Rows(indice)("Domingo")
                End If
            End If
        Next
        Dim registros As Integer = 0
        For indice = 0 To 6
            Dim instruccion_insert As String = ""
            instruccion_insert = "Insert Into IQ_Horario Values('" + alcance(0) + "', '" + alcance(1) + "', '" & alcance(2) + "', "
            instruccion_insert = instruccion_insert & CStr(indice + 1) & ", "
            instruccion_insert = instruccion_insert & "'" & horarios(indice) & "')"
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
        toolTip1.SetToolTip(CmdRefresh, "Actualizar Listas")
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
        Panel_Estado0.Text = ""
        Panel_Estado1.Text = ""
        Me.crvReporte.Visible = False
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
        ColumnaHora.DataType = System.Type.GetType("System.String")
        ColumnaLunes.DataType = System.Type.GetType("System.String")
        ColumnaMartes.DataType = System.Type.GetType("System.String")
        ColumnaMiercoles.DataType = System.Type.GetType("System.String")
        ColumnaJueves.DataType = System.Type.GetType("System.String")
        ColumnaViernes.DataType = System.Type.GetType("System.String")
        ColumnaSabado.DataType = System.Type.GetType("System.String")
        ColumnaDomingo.DataType = System.Type.GetType("System.String")
        ColumnaHora.ColumnName = "Hora"
        ColumnaLunes.ColumnName = "Lunes"
        ColumnaMartes.ColumnName = "Martes"
        ColumnaMiercoles.ColumnName = "Miercoles"
        ColumnaJueves.ColumnName = "Jueves"
        ColumnaViernes.ColumnName = "Viernes"
        ColumnaSabado.ColumnName = "Sabado"
        ColumnaDomingo.ColumnName = "Domingo"
        ColumnaHora.Caption = ""
        ColumnaLunes.Caption = ""
        ColumnaMartes.Caption = ""
        ColumnaMiercoles.Caption = ""
        ColumnaJueves.Caption = ""
        ColumnaViernes.Caption = ""
        ColumnaSabado.Caption = ""
        ColumnaDomingo.Caption = ""
        ColumnaHora.AutoIncrement = False
        ColumnaLunes.AutoIncrement = False
        ColumnaMartes.AutoIncrement = False
        ColumnaMiercoles.AutoIncrement = False
        ColumnaJueves.AutoIncrement = False
        ColumnaViernes.AutoIncrement = False
        ColumnaSabado.AutoIncrement = False
        ColumnaDomingo.AutoIncrement = False
        ColumnaHora.ReadOnly = True
        ColumnaLunes.ReadOnly = False
        ColumnaMartes.ReadOnly = False
        ColumnaMiercoles.ReadOnly = False
        ColumnaJueves.ReadOnly = False
        ColumnaViernes.ReadOnly = False
        ColumnaSabado.ReadOnly = False
        ColumnaDomingo.ReadOnly = False
        TablaDatos.Columns.Add(ColumnaHora)
        TablaDatos.Columns.Add(ColumnaLunes)
        TablaDatos.Columns.Add(ColumnaMartes)
        TablaDatos.Columns.Add(ColumnaMiercoles)
        TablaDatos.Columns.Add(ColumnaJueves)
        TablaDatos.Columns.Add(ColumnaViernes)
        TablaDatos.Columns.Add(ColumnaSabado)
        TablaDatos.Columns.Add(ColumnaDomingo)
        TablaDatos.DefaultView.AllowNew = False
        Dim fila As DataRow
        Dim hora_ant As Date
        Dim hora As Date
        Dim fecha_orig As Date = hora
        Dim fecha_act As Date = hora
        Dim indice_string As Integer = 0
        Do While Format(fecha_act, "yyyy/MM/dd") = Format(fecha_orig, "yyyy/MM/dd")
            hora_ant = hora
            If Format(hora, "HH:mm") < "05:00" Or Format(hora, "HH:mm") >= "21:00" Then
                hora = DateAdd(DateInterval.Minute, 60, hora)
            ElseIf Format(hora, "HH:mm") < "07:00" Or Format(hora, "HH:mm") >= "19:00" Then
                hora = DateAdd(DateInterval.Minute, 30, hora)
            Else
                hora = DateAdd(DateInterval.Minute, 15, hora)
            End If
            indice_string += 1
            fila = TablaDatos.NewRow
            fila("Hora") = Format(hora_ant, "HH:mm") & " - " & Format(hora, "HH:mm")
            fila("Lunes") = Mid(horario_file(0), indice_string, 1)
            fila("Martes") = Mid(horario_file(1), indice_string, 1)
            fila("Miercoles") = Mid(horario_file(2), indice_string, 1)
            fila("Jueves") = Mid(horario_file(3), indice_string, 1)
            fila("Viernes") = Mid(horario_file(4), indice_string, 1)
            fila("Sabado") = Mid(horario_file(5), indice_string, 1)
            fila("Domingo") = Mid(horario_file(6), indice_string, 1)
            TablaDatos.Rows.Add(fila)
            fecha_act = hora
        Loop
        Dim table_style As New DataGridTableStyle
        table_style.MappingName = TablaDatos.TableName
        Dim Hora_style As New DataGridTextBoxColumn
        With Hora_style
            .Alignment = HorizontalAlignment.Left
            .MappingName = "Hora"
            .HeaderText = "Hora"
            .Width = 100
        End With
        Dim Lunes_style As New DataGridTextBoxColumn
        With Lunes_style
            .Alignment = HorizontalAlignment.Center
            .MappingName = "Lunes"
            .HeaderText = "Lunes"
            .Width = 90
        End With
        Dim Martes_style As New DataGridTextBoxColumn
        With Martes_style
            .Alignment = HorizontalAlignment.Center
            .MappingName = "Martes"
            .HeaderText = "Martes"
            .Width = 90
        End With
        Dim Miercoles_style As New DataGridTextBoxColumn
        With Miercoles_style
            .Alignment = HorizontalAlignment.Center
            .MappingName = "Miercoles"
            .HeaderText = "Miércoles"
            .Width = 90
        End With
        Dim Jueves_style As New DataGridTextBoxColumn
        With Jueves_style
            .Alignment = HorizontalAlignment.Center
            .MappingName = "Jueves"
            .HeaderText = "Jueves"
            .Width = 90
        End With
        Dim Viernes_style As New DataGridTextBoxColumn
        With Viernes_style
            .Alignment = HorizontalAlignment.Center
            .MappingName = "Viernes"
            .HeaderText = "Viernes"
            .Width = 90
        End With
        Dim Sabado_style As New DataGridTextBoxColumn
        With Sabado_style
            .Alignment = HorizontalAlignment.Center
            .MappingName = "Sabado"
            .HeaderText = "Sábado"
            .Width = 90
        End With
        Dim Domingo_style As New DataGridTextBoxColumn
        With Domingo_style
            .Alignment = HorizontalAlignment.Center
            .MappingName = "Domingo"
            .HeaderText = "Domingo"
            .Width = 90
        End With
        table_style.GridColumnStyles.AddRange _
            (New DataGridColumnStyle() _
            {Hora_style, Lunes_style, Martes_style, Miercoles_style, Jueves_style, Viernes_style, Sabado_style, Domingo_style})
        Me.GridDatos.TableStyles.Add(table_style)
        Me.GridDatos.DataSource = TablaDatos
        Me.GridDatos.CaptionVisible = False
        Me.GridDatos.Visible = True
    End Sub
    Private Sub CmdClean_Click(sender As Object, e As EventArgs) Handles CmdClean.Click
        If Me.crvReporte.Visible = True Then
            Me.crvReporte.Visible = False
            Me.CmdClean.Enabled = True
            Me.CmdExec.Enabled = True
            Me.CmdExit.Enabled = True
            Me.CmdNewSearch.Enabled = True
            Me.CmdReport.Enabled = True
            Me.CmdSearch.Enabled = True
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
            Me.CmdReport.Visible = False
            Me.TrvOficinas.Focus()
        End If
    End Sub
    Private Sub Horarios_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
        If e.Column.ColumnName.Equals("Lunes") Or e.Column.ColumnName.Equals("Martes") Or e.Column.ColumnName.Equals("Miercoles") Or e.Column.ColumnName.Equals("Jueves") Or e.Column.ColumnName.Equals("Viernes") Or e.Column.ColumnName.Equals("Sabado") Or e.Column.ColumnName.Equals("Domingo") Then
            If CType(e.ProposedValue, String) = "x" Or CType(e.ProposedValue, String) = "X" Then
                e.ProposedValue = "X"
            ElseIf CType(e.ProposedValue, String) = "" Or CType(e.ProposedValue, String) = " " Then
                e.ProposedValue = " "
            Else
                Dim badValue As Object = e.ProposedValue
                e.ProposedValue = " "
            End If
        End If
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
                'Busca_LCD(Carga_Reader_O.GetValue(0), num_nodos(0), nivel_nodo)
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