Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Public Class IQ_C0006
    Inherits System.Windows.Forms.Form
    Private Control_a_cargo As Object
    Dim controles(500, 10) As String
    Dim num_controles As Integer
    Dim Nro_Control As Integer
    Dim Permisos As Integer = 0
    Dim oficinas_select(100) As String
    Dim num_nodos(10) As Integer
    Dim nivel_nodo As Integer
    Dim ind_ofic As Integer
    Dim indice_nodos As Integer
    Private Dictoficinas As New ColeccionOficinas
    Dim alcance(3) As String
    Dim alcance_control_c(3) As String

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles CmdExit.Click
        IQ_C0000.PicFondo.Visible = True
        Me.Dispose()
    End Sub
    Public Sub New()

        InitializeComponent()
        num_controles = 0
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
            'Busca_Areas(Carga_Reader_O2.GetValue(0), num_nodos(Nivel), Nivel + 1)
            Busca_Kioskos(Carga_Reader_O2.GetValue(0), num_nodos(Nivel), Nivel + 1)
            'Busca_LCD(Carga_Reader_O2.GetValue(0), num_nodos(Nivel), Nivel + 1)
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
    Private Sub Control_DobleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Control_a_cargo = sender
        Me.txtNombre.Text = Control_a_cargo.name
        Dim counter As Integer
        For counter = 0 To num_controles
            If controles(counter, 0) = Control_a_cargo.name Then
                Me.txtTipo.Text = controles(counter, 1)
                Nro_Control = counter
                Exit For
            End If
        Next
        Me.txtAlto.Text = CStr(Control_a_cargo.Height)
        Me.txtAncho.Text = CStr(Control_a_cargo.Width)
        Me.txtX.Text = CStr(Control_a_cargo.Left)
        Me.txtY.Text = CStr(Control_a_cargo.Top)
        Me.TxtURL.Text = ""
        Me.txtFile.Text = ""
        Me.TxtURL.Enabled = False
        Me.txtFile.Enabled = False
        Dim tipo_input As String = ""
        Dim Valid_File As String = ""
        Select Case controles(Nro_Control, 1)
            Case "Texto Fijo"
                Me.txtFile.Text = controles(Nro_Control, 4)
                Archivo_a_Abrir.Filter = "Archivos de Texto | *.txt"
                tipo_input = "F"
                Valid_File = "T"
            Case "Texto Dinámico"
                Me.txtFile.Text = controles(Nro_Control, 4)
                Archivo_a_Abrir.Filter = "Archivos de Texto | *.txt"
                tipo_input = "F"
                Valid_File = "T"
            Case "Texto Parpadeante"
                Me.txtFile.Text = controles(Nro_Control, 4)
                Archivo_a_Abrir.Filter = "Archivos de Texto | *.txt"
                tipo_input = "F"
                Valid_File = "T"
            Case "Video"
                Me.txtFile.Text = controles(Nro_Control, 4)
                Archivo_a_Abrir.Filter = "Archivos de Video | *.mov;*.mpg;*.wmv;*.mp4;*.mpeg;*.avi"
                tipo_input = "F"
                Valid_File = "V"
            Case "Imagen"
                Me.txtFile.Text = controles(Nro_Control, 4)
                Archivo_a_Abrir.Filter = "Archivos de Imagen | *.jpg;*.jpeg;*.jpe;*.gif;*.tif;*.tiff;*.´png;*.ico"
                tipo_input = "F"
                Valid_File = "I"
            Case "Galería de Videos"
                Me.txtFile.Text = controles(Nro_Control, 4)
                Archivo_a_Abrir.Filter = "Archivos de Video | *.mov;*.mpg;*.wmv;*.mp4;*.mpeg;*.avi"
                tipo_input = "D"
                Valid_File = "V"
            Case "Galería de Imágenes"
                Me.txtFile.Text = controles(Nro_Control, 4)
                Archivo_a_Abrir.Filter = "Archivos de Imagen | *.jpg;*.jpeg;*.jpe;*.gif;*.tif;*.tiff;*.´png;*.ico"
                tipo_input = "D"
                Valid_File = "I"
            Case "Audio"
                Me.txtFile.Text = controles(Nro_Control, 4)
                Archivo_a_Abrir.Filter = "Archivos de Audio | *.mp3;*.wav;*.wma"
                tipo_input = "F"
                Valid_File = "A"
            Case "Botón"
                Me.txtFile.Text = controles(Nro_Control, 4)
                Archivo_a_Abrir.Filter = "Archivos de Imagen | *.jpg;*.jpeg;*.jpe;*.gif;*.tif;*.tiff;*.´png;*.ico"
                tipo_input = "F"
                Valid_File = "I"
            Case "PDF"
                Me.txtFile.Text = controles(Nro_Control, 4)
                Archivo_a_Abrir.Filter = "Archivos PDF | *.*"
                tipo_input = "F"
                Valid_File = "P"
            Case "LiveFeed"
                Me.TxtURL.Text = controles(Nro_Control, 3)
                tipo_input = "U"
        End Select
        If tipo_input = "F" Or tipo_input = "D" Then
            If Archivo_a_Abrir.ShowDialog() = Windows.Forms.DialogResult.OK And Archivo_a_Abrir.FileName <> "" Then
                Dim SIRVE As Boolean = True
                If Valid_File = "I" Then
                    If UCase(Path.GetExtension(Archivo_a_Abrir.FileName)) <> ".JPG" And UCase(Path.GetExtension(Archivo_a_Abrir.FileName)) <> ".JPEG" And UCase(Path.GetExtension(Archivo_a_Abrir.FileName)) <> ".JPE" And UCase(Path.GetExtension(Archivo_a_Abrir.FileName)) <> ".JPEG" And UCase(Path.GetExtension(Archivo_a_Abrir.FileName)) <> ".GIF" And UCase(Path.GetExtension(Archivo_a_Abrir.FileName)) <> ".TIF" And UCase(Path.GetExtension(Archivo_a_Abrir.FileName)) <> ".TIFF" And UCase(Path.GetExtension(Archivo_a_Abrir.FileName)) <> ".PNG" And UCase(Path.GetExtension(Archivo_a_Abrir.FileName)) <> ".ICO" Then
                        MessageBox.Show("EL ARCHIVO SELECCIONADO NO ES DEL TIPO CORRECTO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        SIRVE = False
                    End If
                ElseIf Valid_File = "A" Then
                    If UCase(Path.GetExtension(Archivo_a_Abrir.FileName)) <> ".MP3" And UCase(Path.GetExtension(Archivo_a_Abrir.FileName)) <> ".WAV" And UCase(Path.GetExtension(Archivo_a_Abrir.FileName)) <> ".WMA" Then
                        MessageBox.Show("EL ARCHIVO SELECCIONADO NO ES DEL TIPO CORRECTO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        SIRVE = False
                    End If
                ElseIf Valid_File = "T" Then
                    If UCase(Path.GetExtension(Archivo_a_Abrir.FileName)) <> ".TXT" Then
                        MessageBox.Show("EL ARCHIVO SELECCIONADO NO ES DEL TIPO CORRECTO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        SIRVE = False
                    End If
                ElseIf Valid_File = "V" Then
                    If UCase(Path.GetExtension(Archivo_a_Abrir.FileName)) <> ".MOV" And UCase(Path.GetExtension(Archivo_a_Abrir.FileName)) <> ".MPG" And UCase(Path.GetExtension(Archivo_a_Abrir.FileName)) <> ".WMV" And UCase(Path.GetExtension(Archivo_a_Abrir.FileName)) <> ".MP4" And UCase(Path.GetExtension(Archivo_a_Abrir.FileName)) <> ".MPEG" And UCase(Path.GetExtension(Archivo_a_Abrir.FileName)) <> ".AVI" Then
                        MessageBox.Show("EL ARCHIVO SELECCIONADO NO ES DEL TIPO CORRECTO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        SIRVE = False
                    End If
                ElseIf Valid_File = "P" Then
                    If UCase(Path.GetExtension(Archivo_a_Abrir.FileName)) = ".ABC" Then
                        MessageBox.Show("EL ARCHIVO SELECCIONADO NO ES DEL TIPO CORRECTO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        SIRVE = False
                    End If
                End If
                If SIRVE = True Then
                    If tipo_input = "F" Then
                        controles(Nro_Control, 4) = Archivo_a_Abrir.FileName
                        Me.txtFile.Text = Archivo_a_Abrir.FileName
                    ElseIf tipo_input = "D" Then
                        controles(Nro_Control, 4) = Mid(System.IO.Path.GetFullPath(Archivo_a_Abrir.FileName), 1, Len(System.IO.Path.GetFullPath(Archivo_a_Abrir.FileName)) - 1 - Len(System.IO.Path.GetFileName(Archivo_a_Abrir.FileName)))
                        Me.txtFile.Text = controles(Nro_Control, 4)
                    End If
                End If
            End If
        ElseIf tipo_input = "U" Then
            Me.TxtURL.Enabled = True
            Me.TxtURL.Focus()
        End If
    End Sub
    Private Sub Control_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Control_a_cargo = sender
        Me.txtNombre.Text = Control_a_cargo.name
        Dim counter As Integer
        For counter = 0 To num_controles
            If controles(counter, 0) = Control_a_cargo.name Then
                Me.txtTipo.Text = controles(counter, 1)
                Nro_Control = counter
                Exit For
            End If
        Next
        Me.txtAlto.Text = CStr(Control_a_cargo.Height)
        Me.txtAncho.Text = CStr(Control_a_cargo.Width)
        Me.txtX.Text = CStr(Control_a_cargo.Left)
        Me.txtY.Text = CStr(Control_a_cargo.Top)
        Me.TxtURL.Text = ""
        Me.txtFile.Text = ""
        Me.TxtURL.Enabled = False
        Me.txtFile.Enabled = False
        Select Case controles(Nro_Control, 1)
            Case "Texto Fijo"
                Me.txtFile.Text = controles(Nro_Control, 4)
            Case "Texto Dinámico"
                Me.txtFile.Text = controles(Nro_Control, 4)
            Case "Texto Parpadeante"
                Me.txtFile.Text = controles(Nro_Control, 4)
            Case "Video"
                Me.txtFile.Text = controles(Nro_Control, 4)
            Case "Botón"
                Me.txtFile.Text = controles(Nro_Control, 4)
            Case "Imagen"
                Me.txtFile.Text = controles(Nro_Control, 4)
            Case "Galería de Videos"
                Me.txtFile.Text = controles(Nro_Control, 4)
            Case "Galería de Imágenes"
                Me.txtFile.Text = controles(Nro_Control, 4)
            Case "Audio"
                Me.txtFile.Text = controles(Nro_Control, 4)
            Case "PDF"
                Me.txtFile.Text = controles(Nro_Control, 4)
            Case "LiveFeed"
                Me.TxtURL.Text = controles(Nro_Control, 3)
        End Select
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
        ElseIf Me.PanelDesign.Visible = False Then
            Me.crvReporte.Visible = False
            If Menu_Parameter <> "A" Then
                Me.LblAplicacion.Text = "GLOBAL"
                alcance(0) = "999999"
                alcance(1) = ""
                alcance(2) = ""
                alcance_control_c(0) = ""
                alcance_control_c(1) = ""
                alcance_control_c(2) = ""
            Else
                Me.LblAplicacion.Text = TrvOficinas.Nodes(0).Text
                alcance(0) = Computer_Ofic
                alcance(1) = ""
                alcance(2) = ""
                alcance_control_c(0) = ""
                alcance_control_c(1) = ""
                alcance_control_c(2) = ""
            End If
            TrvOficinas.Nodes(0).ForeColor = Color.Green
            nivel_nodo = 0
            limpia_nodos(0, nivel_nodo)
            Me.TrvOficinas.Enabled = True
            Me.TrvOficinas.CollapseAll()
            Me.CmdExec.Visible = False
            Me.CmdNewSearch.Visible = False
            Me.CmdRefresh.Visible = True
            Me.CmdSearch.Visible = True
            Me.CmdReport.Visible = False
            Me.PanelDesign.Visible = False
            Me.Panel3.Visible = False
            Me.TrvOficinas.Focus()
        End If
    End Sub
    Private Sub CmdNewSearch_Click(sender As Object, e As EventArgs) Handles CmdNewSearch.Click
        If MessageBox.Show("Está Ud. seguro de ABANDONAR el alcance actual y efectuar una nueva búsqueda?", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Me.PanelDesign.Visible = False
        CmdClean_Click(CmdNewSearch, e)
    End Sub
    Private Sub TxtURL_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtURL.Validating
        controles(Nro_Control, 3) = Me.TxtURL.Text
        Me.TxtURL.Enabled = False
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
                Busca_Kioskos(Carga_Reader_O.GetValue(0), num_nodos(0), nivel_nodo)
                num_nodos(0) += 1
            End While
            Me.LblAplicacion.Text = "GLOBAL"
            alcance(0) = "999999"
            alcance(1) = ""
            alcance(2) = ""
            alcance_control_c(0) = ""
            alcance_control_c(1) = ""
            alcance_control_c(2) = ""
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
                Busca_Kioskos(Carga_Reader_O.GetValue(0), 0, nivel_nodo)
                Me.LblAplicacion.Text = Carga_Reader_O.GetValue(1)
                alcance(0) = Computer_Ofic
                alcance(1) = ""
                alcance(2) = ""
                alcance_control_c(0) = ""
                alcance_control_c(1) = ""
                alcance_control_c(2) = ""
            End While
            Carga_Coneccion_O.Dispose()
        End If
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
            Dim IQ_Cmm As New OleDb.OleDbCommand("Delete from Iq_MMConfig Where IQMMConfig_Oficina = '" + Codigo & "' And IQMMConfig_Area = '' And IQMMConfig_Punto = '' And IQMMConfig_Tipo = 'K'", IQ_Cnn)
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
                Dim IQ_Cmm As New OleDb.OleDbCommand("Delete from IQ_MMConfig Where IQMMConfig_Oficina = '' And IQMMConfig_Area = 'K:" & Trim(Carga_Reader_O.GetValue(0)) & "' And IQMMConfig_Punto = '' And IQMMConfig_Tipo = 'K'", IQ_Cnn)
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
                Dim IQ_Cmm As New OleDb.OleDbCommand("Delete from IQ_MMConfig Where IQMMConfig_Oficina = '' And IQMMConfig_Area = 'A:" & Trim(Carga_Reader_O.GetValue(0)) & "' And IQMMConfig_Punto = '' And IQMMConfig_Tipo = 'K'", IQ_Cnn)
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
                Dim IQ_Cmm As New OleDb.OleDbCommand("Delete from IQ_MMConfig Where IQMMConfig_Oficina = '' And IQMMConfig_Area = '' And IQMMConfig_Punto = '" & Trim(Carga_Reader_O.GetValue(0)) & "' And IQMMConfig_Tipo = 'K'", IQ_Cnn)
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
        toolTip1.SetToolTip(CmdExec, "Ejecutar")
        toolTip1.SetToolTip(CmdClean, "Limpiar")
        Me.txtNombre.Enabled = False
        Me.txtTipo.Enabled = False
        Me.txtAlto.Enabled = False
        Me.txtAncho.Enabled = False
        Me.txtX.Enabled = False
        Me.txtY.Enabled = False
        Me.txtFile.Enabled = False
        Me.TxtURL.Enabled = False
        Nro_Control = 9999
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
                Busca_Kioskos(Carga_Reader_O.GetValue(0), num_nodos(0), nivel_nodo)
                num_nodos(0) += 1
            End While
            Me.LblAplicacion.Text = "GLOBAL"
            alcance(0) = "999999"
            alcance(1) = ""
            alcance(2) = ""
            alcance_control_c(0) = ""
            alcance_control_c(1) = ""
            alcance_control_c(2) = ""
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
                Busca_Kioskos(Carga_Reader_O.GetValue(0), 0, nivel_nodo)
                Me.LblAplicacion.Text = Carga_Reader_O.GetValue(1)
                alcance(0) = Computer_Ofic
                alcance(1) = ""
                alcance(2) = ""
                alcance_control_c(0) = ""
                alcance_control_c(1) = ""
                alcance_control_c(2) = ""
            End While
            Carga_Coneccion_O.Dispose()
        End If
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
        Me.crvReporte.Visible = False
        Me.CmdExec.Visible = False
        Me.CmdNewSearch.Visible = False
        Me.CmdSearch.Visible = True
        Me.CmdReport.Visible = False
        Me.PanelDesign.Visible = False
        Me.Panel3.Visible = False
    End Sub
    Private Sub CmdExec_Click(sender As Object, e As EventArgs) Handles CmdExec.Click
        If MessageBox.Show("Está Ud. seguro de GRABAR la configuración?", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Try
            Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
            IQ_Cnn.Open()
            Dim IQ_Cmm As New OleDb.OleDbCommand("Delete from IQ_MMConfig Where IQMMConfig_Oficina = '" + alcance(0) & "' And IQMMConfig_Area = '" + alcance(1) & "' And IQMMConfig_Punto = '" + alcance(2) & "' And IQMMConfig_Tipo = 'K'", IQ_Cnn)
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
                            Dim IQ_Cmm As New OleDb.OleDbCommand("Delete from IQ_MMConfig Where IQMMConfig_Oficina = '' And IQMMConfig_Area = '' And IQMMConfig_Punto = '" + Carga_Reader_O2.GetValue(0) & "' And IQMMConfig_Tipo = 'K'", IQ_Cnn)
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
                Dim IQ_Cmm As New OleDb.OleDbCommand("Delete from IQ_MMConfig Where IQMMConfig_Tipo = 'K'", IQ_Cnn)
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
        Dim control_en_curso As Control = Nothing
        Dim counter As Integer
        Dim registros As Integer = 0
        For counter = 0 To num_controles
            If Trim(controles(counter, 0)) <> "" Then
                For Each control_a_buscar As Control In PanelDesign.Controls
                    If controles(counter, 0) = control_a_buscar.Name Then
                        control_en_curso = control_a_buscar
                        Exit For
                    End If
                Next
                Dim instruccion_insert As String = ""
                instruccion_insert = "Insert Into IQ_MMConfig Values('" + alcance(0) + "', '" + alcance(1) + "', '" & alcance(2) + "', 'K', "
                instruccion_insert = instruccion_insert & "'" & controles(counter, 0) & "', "
                instruccion_insert = instruccion_insert & "'" & controles(counter, 3) & "', "
                instruccion_insert = instruccion_insert & "'" & controles(counter, 4) & "')"
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
    Private Sub CmdReport_Click(sender As Object, e As EventArgs) Handles CmdReport.Click
        Dim Codigo As String = ""
        Dim alcance_reporte As String = ""
        If Mid(alcance(1), 1, 1) = "K" Then
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
            rptlayout.Load(Disco_Appl & ":\I-Q\IQ_Rpt\IQ_C0006.rpt")
            rptlayout.SetDatabaseLogon(Server_User, Server_Pwd)
            rptlayout.SummaryInfo.ReportTitle = Nombre_Cliente + Chr(10) + Me.Text
            Me.crvReporte.SelectionFormula = "{IQ_MMConfig.IQMMCOnfig_Oficina} = '" + alcance(0) + "' And {IQ_MMCOnfig.IQMMCOnfig_Area} = '" + alcance(1) + "' And {IQ_MMCOnfig.IQMMCOnfig_Punto} = '" + alcance(2) + "' And {IQ_MMCOnfig.IQMMCOnfig_Tipo} = 'K'"
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
        Dim counter As Integer
        For counter = 0 To 499
            controles(counter, 0) = Nothing
            controles(counter, 1) = Nothing
            controles(counter, 2) = Nothing
            controles(counter, 3) = Nothing
            controles(counter, 4) = Nothing
            controles(counter, 5) = Nothing
            controles(counter, 6) = Nothing
            controles(counter, 7) = Nothing
            controles(counter, 8) = Nothing
            controles(counter, 9) = Nothing
        Next
        Me.PanelDesign.Controls.Clear()
        Dim encontrado As Boolean = False
        Dim mensaje_recup As String = ""
        num_controles = 0
        If Alcance_recup(2) = "" Then GoTo busca_2
        Dim Carga_Coneccion_O1 As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O1.Open()
        Dim Carga_Comando_O1 As New OleDb.OleDbCommand("Select IQ_Design.*, IQ_PuntosAtencion.IQPUntos_Descripcion from IQ_Design join IQ_PuntosAtencion on IQ_Design.IIQDesign_Punto = IQ_PuntosAtencion.IQPuntos_Codigo where IQDesign_Oficina = '' and IQDesign_Area = '' and IQDEsign_Punto = '" & Alcance_recup(2) & "' And IQDesign_Tipo = 'K' Order by IQDesign_Orden", Carga_Coneccion_O1)
        Dim Carga_Reader_O1 As OleDb.OleDbDataReader = Carga_Comando_O1.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O1.Read
            If IsDBNull(Carga_Reader_O1.GetValue(0)) = False Then
                If encontrado = False Then
                    mensaje_recup = "RECUPERANDO PLANTILLA NIVEL PUNTO DE ATENCION: " & Carga_Reader_O1.GetValue(11)
                End If
                encontrado = True
                controles(num_controles, 0) = Carga_Reader_O1.GetValue(5)
                controles(num_controles, 1) = Carga_Reader_O1.GetValue(4)
                controles(num_controles, 3) = ""
                controles(num_controles, 4) = ""
                If IsDBNull(Carga_Reader_O1.GetValue(10)) Then
                    controles(num_controles, 5) = CStr(num_controles)
                Else
                    controles(num_controles, 5) = CStr(Carga_Reader_O1.GetValue(10))
                End If
                controles(num_controles, 6) = CStr(Carga_Reader_O1.GetValue(6))
                controles(num_controles, 7) = CStr(Carga_Reader_O1.GetValue(7))
                controles(num_controles, 8) = CStr(Carga_Reader_O1.GetValue(8))
                controles(num_controles, 9) = CStr(Carga_Reader_O1.GetValue(9))
                num_controles += 1
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
        Dim Carga_Comando_O2 As New OleDb.OleDbCommand("Select * from IQ_Design where IQDesign_Oficina = '' and IQDesign_Area = '" & Alcance_recup(1) & "' and IQDEsign_Punto = '' And IQDesign_Tipo = 'K' Order by IQDesign_Orden", Carga_Coneccion_O2)
        Dim Carga_Reader_O2 As OleDb.OleDbDataReader = Carga_Comando_O2.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O2.Read
            If IsDBNull(Carga_Reader_O2.GetValue(0)) = False Then
                encontrado = True
                controles(num_controles, 0) = Carga_Reader_O2.GetValue(5)
                controles(num_controles, 1) = Carga_Reader_O2.GetValue(4)
                controles(num_controles, 3) = ""
                controles(num_controles, 4) = ""
                If IsDBNull(Carga_Reader_O2.GetValue(10)) Then
                    controles(num_controles, 5) = CStr(num_controles)
                Else
                    controles(num_controles, 5) = CStr(Carga_Reader_O2.GetValue(10))
                End If
                controles(num_controles, 6) = CStr(Carga_Reader_O2.GetValue(6))
                controles(num_controles, 7) = CStr(Carga_Reader_O2.GetValue(7))
                controles(num_controles, 8) = CStr(Carga_Reader_O2.GetValue(8))
                controles(num_controles, 9) = CStr(Carga_Reader_O2.GetValue(9))
                num_controles += 1
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
                    instruc_busq = "Select IQAreas_Oficina from IQ_Areas where IQAreas_Codigo = '" & cod_busq & "'"
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
        Dim Carga_Comando_O3 As New OleDb.OleDbCommand("Select IQ_Design.*, Iq_Oficinas.IQOficinas_Descripcion,  Iq_Oficinas.IQOficinas_Consolidacion from IQ_Design join IQ_Oficinas on IQDesign_Oficina = IQOficinas_Codigo where IQDesign_Oficina = '" & Alcance_recup(0) & "' and IQDesign_Area = '' and IQDEsign_Punto = '' And IQDesign_Tipo = 'K' Order by IQDesign_Orden", Carga_Coneccion_O3)
        Dim Carga_Reader_O3 As OleDb.OleDbDataReader = Carga_Comando_O3.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O3.Read
            If IsDBNull(Carga_Reader_O3.GetValue(0)) = False Then
                If encontrado = False Then
                    mensaje_recup = "RECUPERANDO PLANTILLA NIVEL OFICINA: " & Carga_Reader_O3.GetValue(11)
                End If
                encontrado = True
                controles(num_controles, 0) = Carga_Reader_O3.GetValue(5)
                controles(num_controles, 1) = Carga_Reader_O3.GetValue(4)
                controles(num_controles, 3) = ""
                controles(num_controles, 4) = ""
                If IsDBNull(Carga_Reader_O3.GetValue(10)) Then
                    controles(num_controles, 5) = CStr(num_controles)
                Else
                    controles(num_controles, 5) = CStr(Carga_Reader_O3.GetValue(10))
                End If
                controles(num_controles, 6) = CStr(Carga_Reader_O3.GetValue(6))
                controles(num_controles, 7) = CStr(Carga_Reader_O3.GetValue(7))
                controles(num_controles, 8) = CStr(Carga_Reader_O3.GetValue(8))
                controles(num_controles, 9) = CStr(Carga_Reader_O3.GetValue(9))
                num_controles += 1
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
        Dim Carga_Comando_O4 As New OleDb.OleDbCommand("Select * from IQ_Design where IQDesign_Oficina = '999999' and IQDesign_Area = '' and IQDEsign_Punto = '' And IQDesign_Tipo = 'K' Order by IQDesign_Orden", Carga_Coneccion_O4)
        Dim Carga_Reader_O4 As OleDb.OleDbDataReader = Carga_Comando_O4.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O4.Read
            If IsDBNull(Carga_Reader_O4.GetValue(0)) = False Then
                encontrado = True
                controles(num_controles, 0) = Carga_Reader_O4.GetValue(5)
                controles(num_controles, 1) = Carga_Reader_O4.GetValue(4)
                controles(num_controles, 3) = ""
                controles(num_controles, 4) = ""
                If IsDBNull(Carga_Reader_O4.GetValue(10)) Then
                    controles(num_controles, 5) = CStr(num_controles)
                Else
                    controles(num_controles, 5) = CStr(Carga_Reader_O4.GetValue(10))
                End If
                controles(num_controles, 6) = CStr(Carga_Reader_O4.GetValue(6))
                controles(num_controles, 7) = CStr(Carga_Reader_O4.GetValue(7))
                controles(num_controles, 8) = CStr(Carga_Reader_O4.GetValue(8))
                controles(num_controles, 9) = CStr(Carga_Reader_O4.GetValue(9))
                num_controles += 1
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
        If num_controles > 0 Then
            Dim indice_controles As Integer
            For indice_controles = 0 To num_controles - 1
                Dim NuevoControl As New PictureBox()
                PanelDesign.Controls.Add(NuevoControl)
                NuevoControl.Height = CInt(controles(indice_controles, 7))
                NuevoControl.Width = CInt(controles(indice_controles, 6))
                NuevoControl.Location = New System.Drawing.Point(CInt(controles(indice_controles, 8)), CInt(controles(indice_controles, 9)))
                NuevoControl.BorderStyle = BorderStyle.Fixed3D
                NuevoControl.BackColor = Color.WhiteSmoke
                NuevoControl.Name = controles(indice_controles, 0)
                Buscar_Files(indice_controles)
                Dim tooltip1 As New ToolTip(Me.components)
                Select Case (controles(indice_controles, 1))
                    Case "Texto Fijo"
                        NuevoControl.Image = System.Drawing.Image.FromFile(Disco_Appl & ":\I-Q\Iconos\Text.jpg")
                        NuevoControl.SizeMode = PictureBoxSizeMode.CenterImage
                        tooltip1.SetToolTip(NuevoControl, "Area de Texto Fijo")
                    Case "Texto Dinámico"
                        NuevoControl.Image = System.Drawing.Image.FromFile(Disco_Appl & ":\I-Q\Iconos\Moving.png")
                        NuevoControl.SizeMode = PictureBoxSizeMode.CenterImage
                        tooltip1.SetToolTip(NuevoControl, "Area de Texto Dinámico")
                    Case "Texto Parpadeante"
                        NuevoControl.Image = System.Drawing.Image.FromFile(Disco_Appl & ":\I-Q\Iconos\Blink.jpg")
                        NuevoControl.SizeMode = PictureBoxSizeMode.CenterImage
                        tooltip1.SetToolTip(NuevoControl, "Area de Texto Parpadeante")
                    Case "Fecha y Hora"
                        NuevoControl.Image = System.Drawing.Image.FromFile(Disco_Appl & ":\I-Q\Iconos\DateTime.png")
                        NuevoControl.SizeMode = PictureBoxSizeMode.CenterImage
                        tooltip1.SetToolTip(NuevoControl, "Area de Fecha y Hora")
                    Case "Video"
                        NuevoControl.Image = System.Drawing.Image.FromFile(Disco_Appl & ":\I-Q\Iconos\Video2.jpg")
                        NuevoControl.SizeMode = PictureBoxSizeMode.StretchImage
                        tooltip1.SetToolTip(NuevoControl, "Area de Video")
                    Case "Imagen"
                        NuevoControl.Image = System.Drawing.Image.FromFile(Disco_Appl & ":\I-Q\Iconos\Picture2.Png")
                        NuevoControl.SizeMode = PictureBoxSizeMode.StretchImage
                        tooltip1.SetToolTip(NuevoControl, "Area de Imagen")
                    Case "Galería de Videos"
                        NuevoControl.Image = System.Drawing.Image.FromFile(Disco_Appl & ":\I-Q\Iconos\VideoFolder.jpg")
                        NuevoControl.SizeMode = PictureBoxSizeMode.StretchImage
                        tooltip1.SetToolTip(NuevoControl, "Galería de Videos")
                    Case "Galería de Imágenes"
                        NuevoControl.Image = System.Drawing.Image.FromFile(Disco_Appl & ":\I-Q\Iconos\Slideshow.Png")
                        NuevoControl.SizeMode = PictureBoxSizeMode.StretchImage
                        tooltip1.SetToolTip(NuevoControl, "Galería de Imágenes")
                    Case "Audio"
                        NuevoControl.Image = System.Drawing.Image.FromFile(Disco_Appl & ":\I-Q\Iconos\Audio.jpg")
                        NuevoControl.SizeMode = PictureBoxSizeMode.StretchImage
                        tooltip1.SetToolTip(NuevoControl, "Area de Seleccion del Audio")
                    Case "Botón"
                        NuevoControl.Image = System.Drawing.Image.FromFile(Disco_Appl & ":\I-Q\Iconos\Boton2.jpg")
                        NuevoControl.SizeMode = PictureBoxSizeMode.StretchImage
                        tooltip1.SetToolTip(NuevoControl, "Area para Botón de Selección")
                    Case "Ticket"
                        NuevoControl.Image = System.Drawing.Image.FromFile(Disco_Appl & ":\I-Q\Iconos\Ticket2.Png")
                        NuevoControl.SizeMode = PictureBoxSizeMode.StretchImage
                        tooltip1.SetToolTip(NuevoControl, "Area de Despliegue de Tickets")
                    Case "LiveFeed"
                        NuevoControl.Image = System.Drawing.Image.FromFile(Disco_Appl & ":\I-Q\Iconos\Livefeed2.Png")
                        NuevoControl.SizeMode = PictureBoxSizeMode.StretchImage
                        tooltip1.SetToolTip(NuevoControl, "Live Feed desde Internet")
                    Case "PDF"
                        NuevoControl.Image = System.Drawing.Image.FromFile(Disco_Appl & ":\I-Q\Iconos\PDF2.Jpg")
                        NuevoControl.SizeMode = PictureBoxSizeMode.StretchImage
                        tooltip1.SetToolTip(NuevoControl, "Area para texto PDF")
                End Select
                NuevoControl.BringToFront()
                AddHandler NuevoControl.Click, AddressOf Control_Click
                AddHandler NuevoControl.DoubleClick, AddressOf Control_DobleClick
                Control_a_cargo = NuevoControl
                Nro_Control = indice_controles
                Me.txtNombre.Text = Control_a_cargo.name
                Me.txtTipo.Text = controles(indice_controles, 1)
                Me.txtAlto.Text = CStr(Control_a_cargo.Height)
                Me.txtAncho.Text = CStr(Control_a_cargo.Width)
                Me.txtX.Text = CStr(Control_a_cargo.Left)
                Me.txtY.Text = CStr(Control_a_cargo.Top)
                Me.TxtURL.Text = controles(Nro_Control, 3)
                Me.txtFile.Text = controles(Nro_Control, 4)
            Next
        End If
        Me.PanelDesign.Visible = True
        Me.Panel3.Visible = True
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
        Me.PanelDesign.Visible = True
    End Sub
    Private Sub Buscar_Files(Indice As Integer)
        Dim Alcance_Recfiles(3) As String
        Dim recup_block As Boolean = False
        If alcance_control_c(0) <> "" Or alcance_control_c(1) <> "" Or alcance_control_c(2) <> "" Then
            Alcance_Recfiles(0) = alcance_control_c(0)
            Alcance_Recfiles(1) = alcance_control_c(1)
            Alcance_Recfiles(2) = alcance_control_c(2)
            recup_block = True
        Else
            Alcance_Recfiles(0) = alcance(0)
            Alcance_Recfiles(1) = alcance(1)
            Alcance_Recfiles(2) = alcance(2)
        End If
        controles(Indice, 3) = ""
        controles(Indice, 4) = ""
        Dim encontrado As Boolean = False
        If Alcance_Recfiles(2) = "" Then GoTo busca_2
        Dim Carga_Coneccion_O1 As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O1.Open()
        Dim Carga_Comando_O1 As New OleDb.OleDbCommand("Select IQ_MMConfig.*, IQ_PuntosAtencion.IQPUntos_Descripcion from IQ_MMConfig join IQ_PuntosAtencion on IQ_MMConfig.IIQMMConfig_Punto = IQ_PuntosAtencion.IQPuntos_Codigo where IQMMConfig_Oficina = '' and IQMMConfig_Area = '' and IQMMConfig_Punto = '" & Alcance_Recfiles(2) & "' And IQMMConfig_Tipo = 'K' And IQMMConfig_Nombre = '" & controles(Indice, 0) & "'", Carga_Coneccion_O1)
        Dim Carga_Reader_O1 As OleDb.OleDbDataReader = Carga_Comando_O1.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O1.Read
            If IsDBNull(Carga_Reader_O1.GetValue(0)) = False Then
                encontrado = True
                controles(Indice, 3) = Carga_Reader_O1.GetValue(5)
                controles(Indice, 4) = Carga_Reader_O1.GetValue(6)
            End If
        End While
        Carga_Coneccion_O1.Dispose()
        If encontrado = True Then
            GoTo Busca_Fin
        End If
        If encontrado = False Then
            If recup_block = True Then
                GoTo busca_fin
            End If
            Dim Carga_Coneccion_O1b As New OleDb.OleDbConnection(Cnn_Central_Server)
            Carga_Coneccion_O1b.Open()
            Dim Carga_Comando_O1b As New OleDb.OleDbCommand("Select IQPuntos_Area from IQ_PuntosAtencion where IQPuntos_Codigo = '" & Alcance_Recfiles(2) & "'", Carga_Coneccion_O1b)
            Dim Carga_Reader_O1b As OleDb.OleDbDataReader = Carga_Comando_O1b.ExecuteReader(CommandBehavior.CloseConnection)
            While Carga_Reader_O1b.Read
                If IsDBNull(Carga_Reader_O1b.GetValue(0)) = False Then
                    Alcance_Recfiles(2) = ""
                    Alcance_Recfiles(1) = "A:" & Carga_Reader_O1b.GetValue(0)
                End If
            End While
            Carga_Coneccion_O1b.Dispose()
        End If
Busca_2:
        If Alcance_Recfiles(1) = "" Then GoTo busca_3
        Dim tipo_busq As String = Mid(Alcance_Recfiles(1), 1, 1)
        Dim cod_busq As String = Mid(Alcance_Recfiles(1), 3, Len(Alcance_Recfiles(1)) - 2)
        Dim Carga_Coneccion_O2 As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O2.Open()
        Dim Carga_Comando_O2 As New OleDb.OleDbCommand("Select * from IQ_MMConfig where IQMMConfig_Oficina = '' and IQMMConfig_Area = '" & Alcance_Recfiles(1) & "' and IQMMConfig_Punto = '' And IQMMConfig_Tipo = 'K' And IQMMConfig_Nombre = '" & controles(Indice, 0) & "'", Carga_Coneccion_O2)
        Dim Carga_Reader_O2 As OleDb.OleDbDataReader = Carga_Comando_O2.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O2.Read
            If IsDBNull(Carga_Reader_O2.GetValue(0)) = False Then
                encontrado = True
                controles(Indice, 3) = Carga_Reader_O2.GetValue(5)
                controles(Indice, 4) = Carga_Reader_O2.GetValue(6)
            End If
        End While
        Carga_Coneccion_O2.Dispose()
        If encontrado = True Then
            GoTo Busca_Fin
        End If
        If encontrado = False Then
            If recup_block = True Then
                GoTo busca_fin
            End If
            Dim Carga_Coneccion_O2b As New OleDb.OleDbConnection(Cnn_Central_Server)
            Carga_Coneccion_O2b.Open()
            Dim instruc_busq As String = ""
            Select Case tipo_busq
                Case "A"
                    instruc_busq = "Select IQAreas_Oficina from IQ_Areas where IQAreas_Codigo = '" & cod_busq & "'"
                Case "K"
                    instruc_busq = "Select IQConfigOfic_Oficina from IQ_ConfigOfic where IQConfigOfic_Codigo = '" & cod_busq & "'"
                Case "L"
                    instruc_busq = "Select IQConfigOfic_Oficina from IQ_ConfigOfic where IQConfigOfic_Codigo = '" & cod_busq & "'"
            End Select
            Dim Carga_Comando_O2b As New OleDb.OleDbCommand(instruc_busq, Carga_Coneccion_O2b)
            Dim Carga_Reader_O2b As OleDb.OleDbDataReader = Carga_Comando_O2b.ExecuteReader(CommandBehavior.CloseConnection)
            While Carga_Reader_O2b.Read
                If IsDBNull(Carga_Reader_O2b.GetValue(0)) = False Then
                    Alcance_Recfiles(1) = ""
                    Alcance_Recfiles(0) = Carga_Reader_O2b.GetValue(0)
                End If
            End While
            Carga_Coneccion_O2b.Dispose()
        End If
Busca_3:
        If Alcance_Recfiles(0) = "999999" Then GoTo busca_4
        Dim consolidadora As String = ""
        Dim Carga_Coneccion_O3 As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O3.Open()
        Dim Carga_Comando_O3 As New OleDb.OleDbCommand("Select IQ_MMConfig.*, Iq_Oficinas.IQOficinas_Descripcion,  Iq_Oficinas.IQOficinas_Consolidacion from IQ_MMConfig join IQ_Oficinas on IQMMConfig_Oficina = IQOficinas_Codigo where IQMMConfig_Oficina = '" & Alcance_Recfiles(0) & "' and IQMMConfig_Area = '' and IQMMConfig_Punto = '' And IQMMConfig_Tipo = 'K'  And IQMMConfig_Nombre = '" & controles(Indice, 0) & "'", Carga_Coneccion_O3)
        Dim Carga_Reader_O3 As OleDb.OleDbDataReader = Carga_Comando_O3.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O3.Read
            If IsDBNull(Carga_Reader_O3.GetValue(0)) = False Then
                encontrado = True
                controles(Indice, 3) = Carga_Reader_O3.GetValue(5)
                controles(Indice, 4) = Carga_Reader_O3.GetValue(6)
            End If
        End While
        Carga_Coneccion_O3.Dispose()
        If encontrado = True Then
            GoTo Busca_Fin
        End If
        If encontrado = False Then
            If recup_block = True Then
                GoTo busca_fin
            End If
            Dim Carga_Coneccion_O3b As New OleDb.OleDbConnection(Cnn_Central_Server)
            Carga_Coneccion_O3b.Open()
            Dim Carga_Comando_O3b As New OleDb.OleDbCommand("Select IQOficinas_Consolidacion from IQ_Oficinas where IQOficinas_Codigo = '" & Alcance_Recfiles(0) & "'", Carga_Coneccion_O3b)
            Dim Carga_Reader_O3b As OleDb.OleDbDataReader = Carga_Comando_O3b.ExecuteReader(CommandBehavior.CloseConnection)
            While Carga_Reader_O3b.Read
                If IsDBNull(Carga_Reader_O3b.GetValue(0)) = False Then
                    consolidadora = Carga_Reader_O3b.GetValue(0)
                End If
            End While
            Carga_Coneccion_O3.Dispose()
            Alcance_Recfiles(0) = consolidadora
            GoTo busca_3
        End If
Busca_4:
        Dim Carga_Coneccion_O4 As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O4.Open()
        Dim Carga_Comando_O4 As New OleDb.OleDbCommand("Select * from IQ_MMConfig where IQMMConfig_Oficina = '999999' and IQMMConfig_Area = '' and IQMMConfig_Punto = '' And IQMMConfig_Tipo = 'K' And IQMMConfig_Nombre = '" & controles(Indice, 0) & "'", Carga_Coneccion_O4)
        Dim Carga_Reader_O4 As OleDb.OleDbDataReader = Carga_Comando_O4.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O4.Read
            If IsDBNull(Carga_Reader_O4.GetValue(0)) = False Then
                encontrado = True
                controles(Indice, 3) = Carga_Reader_O4.GetValue(5)
                controles(Indice, 4) = Carga_Reader_O4.GetValue(6)
            End If
        End While
        Carga_Coneccion_O4.Dispose()
        If encontrado = True Then
            GoTo Busca_Fin
        End If
Busca_Fin:
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
    Private Sub TrvOficinas_KeyDown(sender As Object, e As KeyEventArgs) Handles TrvOficinas.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.C Then
            Dim labelito As String
            If Trim(Me.TrvOficinas.SelectedNode.Text) = "GLOBAL" Then
                labelito = "GLOBAL"
            Else
                labelito = Trim(Mid(Me.TrvOficinas.SelectedNode.Text, 1, InStr(Me.TrvOficinas.SelectedNode.Text, "   ")))
            End If
            Try
                If MessageBox.Show("Está Ud. Seguro de definir " & labelito & " Como la Configuración Multimedia a recuperar?", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
                    alcance_control_c(0) = ""
                    alcance_control_c(1) = ""
                    alcance_control_c(2) = ""
                    Exit Sub
                End If
                If Trim(Me.TrvOficinas.SelectedNode.Text) = "GLOBAL" Then
                    alcance_control_c(0) = "999999"
                    alcance_control_c(1) = ""
                    alcance_control_c(2) = ""
                Else
                    Dim Pos_Alcance As Integer
                    Pos_Alcance = InStr(Me.TrvOficinas.SelectedNode.Text, "|")
                    If Pos_Alcance > 0 Then
                        Dim tipo_Elem As String = Mid(Me.TrvOficinas.SelectedNode.Text, Pos_Alcance + 1, 1)
                        Dim cod_elem As String = Mid(Me.TrvOficinas.SelectedNode.Text, Pos_Alcance + 3, Len(Me.TrvOficinas.SelectedNode.Text) - (Pos_Alcance) + 2)
                        Select Case tipo_Elem
                            Case "O"
                                alcance_control_c(0) = cod_elem
                                alcance_control_c(1) = ""
                                alcance_control_c(2) = ""
                            Case "A"
                                alcance_control_c(0) = ""
                                alcance_control_c(1) = "A:" & cod_elem
                                alcance_control_c(2) = ""
                            Case "K"
                                alcance_control_c(0) = ""
                                alcance_control_c(1) = "K:" & cod_elem
                                alcance_control_c(2) = ""
                            Case "L"
                                alcance_control_c(0) = ""
                                alcance_control_c(1) = "L:" & cod_elem
                                alcance_control_c(2) = ""
                            Case "P"
                                alcance_control_c(0) = ""
                                alcance_control_c(1) = ""
                                alcance_control_c(2) = cod_elem
                        End Select
                    End If
                End If
                MessageBox.Show(labelito & " ESTABLECIDO COMO CONFIGURACION MULTIMEDIA A RECUPERAR", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                Exit Sub
            End Try
        End If
    End Sub
End Class