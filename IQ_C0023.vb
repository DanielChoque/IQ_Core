Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Public Class IQ_C0023
    Inherits System.Windows.Forms.Form
    Private IsDragging As Boolean = False
    Private StartPoint As Point
    Private Control_a_cargo As Object
    Dim controles(500, 20) As String
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
    Public Sub New()
        InitializeComponent()
        num_controles = 0
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
    Private Sub Busca_Oficinas(ByVal Codigo As String, ByVal Nodo As Integer, ByVal Nivel As Integer)
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
    Private Sub Busca_Kioskos(ByVal Codigo As String, ByVal Nodo As Integer, ByVal Nivel As Integer)
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
    Private Sub Control_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        IsDragging = False
    End Sub
    Private Sub Control_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        '      sender.bringtofront()
        StartPoint = sender.PointToScreen(New Point(e.X, e.Y))
        IsDragging = True
    End Sub
    Private Sub Control_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If IsDragging Then
            Dim EndPoint As Point = sender.PointToScreen(New Point(e.X, e.Y))
            sender.Left += (EndPoint.X - StartPoint.X)
            sender.Top += (EndPoint.Y - StartPoint.Y)
            StartPoint = EndPoint
        End If
    End Sub
    Private Sub CmdExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CmdExit.Click
        IQ_C0000.PicFondo.Visible = True
        Me.Dispose()
    End Sub
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim NuevoTexto As New PictureBox()
        PanelDesign.Controls.Add(NuevoTexto)
        NuevoTexto.Height = 40
        If Me.PanelDesign.Width > 500 Then
            NuevoTexto.Width = 500
        Else
            NuevoTexto.Width = Me.PanelDesign.Width
        End If
        NuevoTexto.BorderStyle = BorderStyle.Fixed3D
        NuevoTexto.BackColor = Color.WhiteSmoke
        NuevoTexto.Image = System.Drawing.Image.FromFile(Disco_Appl & ":\I-Q\Iconos\Text.jpg")
        NuevoTexto.SizeMode = PictureBoxSizeMode.CenterImage
        NuevoTexto.Location = New System.Drawing.Point(0, 0)
        controles(num_controles, 0) = Busca_Maximo("Texto")
        controles(num_controles, 1) = "Texto Fijo"
        controles(num_controles, 2) = ""
        controles(num_controles, 3) = ""
        controles(num_controles, 5) = CStr(num_controles)
        controles(num_controles, 11) = "11"
        controles(num_controles, 12) = "N"
        controles(num_controles, 13) = "N"
        controles(num_controles, 14) = ""
        controles(num_controles, 15) = ""
        NuevoTexto.Name = controles(num_controles, 0)
        num_controles += 1
        NuevoTexto.BringToFront()
        Dim tooltip1 As New ToolTip(Me.components)
        tooltip1.SetToolTip(NuevoTexto, "Area de Texto Fijo")
        AddHandler NuevoTexto.Click, AddressOf Control_Click
        AddHandler NuevoTexto.DoubleClick, AddressOf Control_DoubleClick
        AddHandler NuevoTexto.MouseDown, AddressOf Control_MouseDown
        AddHandler NuevoTexto.MouseMove, AddressOf Control_MouseMove
        AddHandler NuevoTexto.MouseUp, AddressOf Control_MouseUp
        Control_a_cargo = NuevoTexto
        Nro_Control = num_controles - 1
        Me.TxtNombre.Text = Control_a_cargo.name
        Me.TxtTipo.Text = controles(num_controles - 1, 1)
        Me.txtSize.Text = controles(num_controles, 11)
        If controles(num_controles, 12) = "S" Then
            Me.ChkBold.Checked = True
        Else
            Me.ChkBold.Checked = False
        End If
        Me.TxtFile.Text = controles(num_controles, 14)
        Me.TxtTexto.Text = controles(num_controles, 15)
    End Sub
    Private Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim NuevoTexto As New PictureBox()
        PanelDesign.Controls.Add(NuevoTexto)
        NuevoTexto.Height = 40
        If Me.PanelDesign.Width > 500 Then
            NuevoTexto.Width = 500
        Else
            NuevoTexto.Width = Me.PanelDesign.Width
        End If
        NuevoTexto.BorderStyle = BorderStyle.Fixed3D
        NuevoTexto.BackColor = Color.WhiteSmoke
        NuevoTexto.Image = System.Drawing.Image.FromFile(Disco_Appl & ":\I-Q\Iconos\Oficinas.Png")
        NuevoTexto.SizeMode = PictureBoxSizeMode.CenterImage
        NuevoTexto.Location = New System.Drawing.Point(0, 0)
        controles(num_controles, 0) = Busca_Maximo("Oficina")
        controles(num_controles, 1) = "Oficina"
        controles(num_controles, 2) = ""
        controles(num_controles, 3) = ""
        controles(num_controles, 5) = CStr(num_controles)
        controles(num_controles, 11) = "11"
        controles(num_controles, 12) = "N"
        controles(num_controles, 13) = "N"
        controles(num_controles, 14) = ""
        controles(num_controles, 15) = ""
        NuevoTexto.Name = controles(num_controles, 0)
        num_controles += 1
        NuevoTexto.BringToFront()
        Dim tooltip1 As New ToolTip(Me.components)
        tooltip1.SetToolTip(NuevoTexto, "Area para Nombre de la Oficina")
        AddHandler NuevoTexto.Click, AddressOf Control_Click
        AddHandler NuevoTexto.DoubleClick, AddressOf Control_DoubleClick
        AddHandler NuevoTexto.MouseDown, AddressOf Control_MouseDown
        AddHandler NuevoTexto.MouseMove, AddressOf Control_MouseMove
        AddHandler NuevoTexto.MouseUp, AddressOf Control_MouseUp
        Control_a_cargo = NuevoTexto
        Nro_Control = num_controles - 1
        Me.TxtNombre.Text = Control_a_cargo.name
        Me.TxtTipo.Text = controles(num_controles - 1, 1)
        Me.txtSize.Text = controles(num_controles, 11)
        If controles(num_controles, 12) = "S" Then
            Me.ChkBold.Checked = True
        Else
            Me.ChkBold.Checked = False
        End If
        Me.TxtFile.Text = controles(num_controles, 14)
        Me.TxtTexto.Text = controles(num_controles, 15)
    End Sub
    Private Sub Button9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button9.Click
        If Control_a_cargo Is Nothing Then
            Exit Sub
        End If
        If MessageBox.Show("Está Ud. seguro de eliminar el elemento " & Control_a_cargo.name & "?", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Dim counter As Integer
        For counter = 0 To num_controles
            If controles(counter, 0) = Control_a_cargo.name Then
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
                controles(counter, 10) = Nothing
                controles(counter, 11) = Nothing
                controles(counter, 12) = Nothing
                controles(counter, 13) = Nothing
                controles(counter, 14) = Nothing
                controles(counter, 15) = Nothing
                controles(counter, 16) = Nothing
                controles(counter, 17) = Nothing
                controles(counter, 18) = Nothing
                controles(counter, 19) = Nothing
                Exit For
            End If
        Next
        Control_a_cargo.dispose()
        Control_a_cargo = Nothing
        Nro_Control = 9999
        Me.TxtNombre.Text = ""
        Me.TxtTipo.Text = ""
        Me.txtSize.Text = ""
        Me.TxtFile.Text = ""
        Me.TxtTexto.Text = ""
        Me.ChkBold.Checked = False
    End Sub
    Private Sub Button10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button10.Click
        If Control_a_cargo Is Nothing Then
            Exit Sub
        End If
        Dim counter As Integer
        Dim orden_actual As Integer
        Dim pos_control As Integer
        For counter = 0 To num_controles
            If controles(counter, 0) = Control_a_cargo.name Then
                orden_actual = CInt(controles(counter, 5))
                pos_control = counter
            End If
        Next
        For counter = 0 To num_controles
            If counter = pos_control Then
                controles(counter, 5) = CStr(num_controles)
            ElseIf CInt(controles(counter, 5)) > orden_actual Then
                controles(counter, 5) = CStr(CInt(controles(counter, 5)) - 1)
            End If
        Next
        Control_a_cargo.bringtofront()
    End Sub
    Private Sub Button11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button11.Click
        If Control_a_cargo Is Nothing Then
            Exit Sub
        End If
        Dim counter As Integer
        Dim orden_actual As Integer
        Dim pos_control As Integer
        For counter = 0 To num_controles
            If controles(counter, 0) = Control_a_cargo.name Then
                orden_actual = CInt(controles(counter, 5))
                pos_control = counter
            End If
        Next
        For counter = 0 To num_controles
            If counter = pos_control Then
                controles(counter, 5) = CStr(0)
            ElseIf CInt(controles(counter, 5)) < orden_actual Then
                controles(counter, 5) = CStr(CInt(controles(counter, 5)) + 1)
            End If
        Next
        Control_a_cargo.sendtoback()
    End Sub
    Private Sub Button12_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button12.Click
        If Control_a_cargo Is Nothing Then
            Exit Sub
        End If
        Dim NuevoControl As New PictureBox()
        PanelDesign.Controls.Add(NuevoControl)
        Dim counter As Integer
        For counter = 0 To num_controles
            If controles(counter, 0) = Control_a_cargo.name Then
                Exit For
            End If
        Next
        NuevoControl.Height = Control_a_cargo.height
        NuevoControl.Width = Control_a_cargo.width
        NuevoControl.BorderStyle = Control_a_cargo.borderstyle
        NuevoControl.BackColor = Control_a_cargo.backcolor
        NuevoControl.Image = Control_a_cargo.image
        NuevoControl.SizeMode = Control_a_cargo.sizemode
        NuevoControl.Location = New System.Drawing.Point(0, 0)
        Dim tooltip1 As New ToolTip(Me.components)
        Select Case controles(counter, 1)
            Case "Texto Fijo"
                controles(num_controles, 0) = Busca_Maximo("Texto")
                tooltip1.SetToolTip(NuevoControl, "Area de Texto Fijo")
            Case "Fecha y Hora"
                controles(num_controles, 0) = Busca_Maximo("Fecha")
                tooltip1.SetToolTip(NuevoControl, "Area de Fecha y Hora")
            Case "Ticket"
                controles(num_controles, 0) = Busca_Maximo("Ticket")
                tooltip1.SetToolTip(NuevoControl, "Area para el Número de Ticket")
            Case "Oficina"
                controles(num_controles, 0) = Busca_Maximo("Oficina")
                tooltip1.SetToolTip(NuevoControl, "Area para Nombre de la Oficina")
            Case ""
        End Select
        controles(num_controles, 1) = controles(counter, 1)
        controles(num_controles, 2) = controles(counter, 2)
        controles(num_controles, 3) = controles(counter, 3)
        controles(num_controles, 11) = controles(counter, 11)
        controles(num_controles, 12) = controles(counter, 12)
        controles(num_controles, 13) = controles(counter, 13)
        controles(num_controles, 14) = controles(counter, 14)
        controles(num_controles, 15) = controles(counter, 15)
        controles(num_controles, 5) = CStr(num_controles)
        NuevoControl.Name = controles(num_controles, 0)
        num_controles += 1
        NuevoControl.BringToFront()
        AddHandler NuevoControl.Click, AddressOf Control_Click
        AddHandler NuevoControl.DoubleClick, AddressOf Control_DoubleClick
        AddHandler NuevoControl.MouseDown, AddressOf Control_MouseDown
        AddHandler NuevoControl.MouseMove, AddressOf Control_MouseMove
        AddHandler NuevoControl.MouseUp, AddressOf Control_MouseUp
        Control_a_cargo = NuevoControl
        Nro_Control = num_controles - 1
        Me.TxtNombre.Text = Control_a_cargo.name
        Me.TxtTipo.Text = controles(num_controles - 1, 1)
        Me.txtSize.Text = controles(num_controles, 11)
        If controles(num_controles, 12) = "S" Then
            Me.ChkBold.Checked = True
        Else
            Me.ChkBold.Checked = False
        End If
        Me.TxtFile.Text = controles(num_controles, 14)
        Me.TxtTexto.Text = controles(num_controles, 15)
    End Sub
    Private Sub Button13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button13.Click
        Dim NuevoTexto As New PictureBox()
        PanelDesign.Controls.Add(NuevoTexto)
        NuevoTexto.Height = 40
        If Me.PanelDesign.Width > 500 Then
            NuevoTexto.Width = 500
        Else
            NuevoTexto.Width = Me.PanelDesign.Width
        End If
        NuevoTexto.BorderStyle = BorderStyle.Fixed3D
        NuevoTexto.BackColor = Color.WhiteSmoke
        NuevoTexto.Image = System.Drawing.Image.FromFile(Disco_Appl & ":\I-Q\Iconos\Ticket.Jpg")
        NuevoTexto.SizeMode = PictureBoxSizeMode.CenterImage
        NuevoTexto.Location = New System.Drawing.Point(0, 0)
        controles(num_controles, 0) = Busca_Maximo("Ticket")
        controles(num_controles, 1) = "Ticket"
        controles(num_controles, 2) = ""
        controles(num_controles, 3) = ""
        controles(num_controles, 5) = CStr(num_controles)
        controles(num_controles, 11) = "22"
        controles(num_controles, 12) = "N"
        controles(num_controles, 13) = "N"
        controles(num_controles, 14) = ""
        controles(num_controles, 15) = ""
        NuevoTexto.Name = controles(num_controles, 0)
        num_controles += 1
        NuevoTexto.BringToFront()
        Dim tooltip1 As New ToolTip(Me.components)
        tooltip1.SetToolTip(NuevoTexto, "Area para el Número de Ticket")
        AddHandler NuevoTexto.Click, AddressOf Control_Click
        AddHandler NuevoTexto.DoubleClick, AddressOf Control_DoubleClick
        AddHandler NuevoTexto.MouseDown, AddressOf Control_MouseDown
        AddHandler NuevoTexto.MouseMove, AddressOf Control_MouseMove
        AddHandler NuevoTexto.MouseUp, AddressOf Control_MouseUp
        Control_a_cargo = NuevoTexto
        Nro_Control = num_controles - 1
        Me.TxtNombre.Text = Control_a_cargo.name
        Me.TxtTipo.Text = controles(num_controles - 1, 1)
        Me.txtSize.Text = controles(num_controles, 11)
        If controles(num_controles, 12) = "S" Then
            Me.ChkBold.Checked = True
        Else
            Me.ChkBold.Checked = False
        End If
        Me.TxtFile.Text = controles(num_controles, 14)
        Me.TxtTexto.Text = controles(num_controles, 15)
    End Sub
    Private Sub Button14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button14.Click
        Dim NuevoTexto As New PictureBox()
        PanelDesign.Controls.Add(NuevoTexto)
        NuevoTexto.Height = 40
        If Me.PanelDesign.Width > 500 Then
            NuevoTexto.Width = 500
        Else
            NuevoTexto.Width = Me.PanelDesign.Width
        End If
        NuevoTexto.BorderStyle = BorderStyle.Fixed3D
        NuevoTexto.BackColor = Color.WhiteSmoke
        NuevoTexto.Image = System.Drawing.Image.FromFile(Disco_Appl & ":\I-Q\Iconos\DateTime.Png")
        NuevoTexto.SizeMode = PictureBoxSizeMode.CenterImage
        NuevoTexto.Location = New System.Drawing.Point(0, 0)
        controles(num_controles, 0) = Busca_Maximo("Fecha")
        controles(num_controles, 1) = "Fecha y Hora"
        controles(num_controles, 2) = ""
        controles(num_controles, 3) = ""
        controles(num_controles, 5) = CStr(num_controles)
        controles(num_controles, 11) = "11"
        controles(num_controles, 12) = "N"
        controles(num_controles, 13) = "N"
        controles(num_controles, 14) = ""
        controles(num_controles, 15) = ""
        NuevoTexto.Name = controles(num_controles, 0)
        num_controles += 1
        NuevoTexto.BringToFront()
        Dim tooltip1 As New ToolTip(Me.components)
        tooltip1.SetToolTip(NuevoTexto, "Area de Fecha y Hora")
        AddHandler NuevoTexto.Click, AddressOf Control_Click
        AddHandler NuevoTexto.DoubleClick, AddressOf Control_DoubleClick
        AddHandler NuevoTexto.MouseDown, AddressOf Control_MouseDown
        AddHandler NuevoTexto.MouseMove, AddressOf Control_MouseMove
        AddHandler NuevoTexto.MouseUp, AddressOf Control_MouseUp
        Control_a_cargo = NuevoTexto
        Nro_Control = num_controles - 1
        Me.TxtNombre.Text = Control_a_cargo.name
        Me.TxtTipo.Text = controles(num_controles - 1, 1)
        Me.txtSize.Text = controles(num_controles, 11)
        If controles(num_controles, 12) = "S" Then
            Me.ChkBold.Checked = True
        Else
            Me.ChkBold.Checked = False
        End If
        Me.TxtFile.Text = controles(num_controles, 14)
        Me.TxtTexto.Text = controles(num_controles, 15)
    End Sub
    Private Sub Control_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Control_a_cargo = sender
        Me.TxtNombre.Text = Control_a_cargo.name
        Dim counter As Integer
        For counter = 0 To num_controles
            If controles(counter, 0) = Control_a_cargo.name Then
                Me.TxtTipo.Text = controles(counter, 1)
                Me.txtSize.Text = controles(counter, 11)
                If controles(counter, 12) = "S" Then
                    Me.ChkBold.Checked = True
                Else
                    Me.ChkBold.Checked = False
                End If
                Me.TxtFile.Text = controles(counter, 14)
                Me.TxtTexto.Text = controles(counter, 15)
                Nro_Control = counter
                Exit For
            End If
        Next
    End Sub
    Private Sub Control_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Control_a_cargo = sender
        Me.TxtNombre.Text = Control_a_cargo.name
        Dim counter As Integer
        For counter = 0 To num_controles
            If controles(counter, 0) = Control_a_cargo.name Then
                Me.TxtTipo.Text = controles(counter, 1)
                Me.txtSize.Text = controles(counter, 11)
                If controles(counter, 12) = "S" Then
                    Me.ChkBold.Checked = True
                Else
                    Me.ChkBold.Checked = False
                End If
                Me.TxtFile.Text = controles(counter, 14)
                Me.TxtTexto.Text = controles(counter, 15)
                Nro_Control = counter
                Exit For
            End If
        Next
        Me.txtSize.Enabled = True
        Me.ChkBold.Enabled = True
        Me.TxtFile.Enabled = True
        Me.TxtTexto.Enabled = True
        Dim tipo_input As String = ""
        Select Case controles(Nro_Control, 1)
            Case "Texto Fijo"
                Me.TxtFile.Enabled = False
                tipo_input = "F"
            Case "Fecha y Hora"
                Me.TxtFile.Enabled = False
                Me.TxtTexto.Enabled = False
                tipo_input = "D"
            Case "Ticket"
                Me.TxtFile.Enabled = False
                Me.TxtTexto.Enabled = False
                tipo_input = "T"
            Case "Oficina"
                Me.TxtFile.Enabled = False
                Me.TxtTexto.Enabled = False
                tipo_input = "A"
        End Select
        If tipo_input = "I" Or tipo_input = "P" Then
            If Archivo_A_Abrir.ShowDialog() = Windows.Forms.DialogResult.OK And Archivo_A_Abrir.FileName <> "" Then
                If tipo_input = "I" Then
                    If UCase(Path.GetExtension(Archivo_A_Abrir.FileName)) <> ".JPG" And UCase(Path.GetExtension(Archivo_A_Abrir.FileName)) <> ".JPEG" And UCase(Path.GetExtension(Archivo_A_Abrir.FileName)) <> ".JPE" And UCase(Path.GetExtension(Archivo_A_Abrir.FileName)) <> ".JPEG" And UCase(Path.GetExtension(Archivo_A_Abrir.FileName)) <> ".GIF" And UCase(Path.GetExtension(Archivo_A_Abrir.FileName)) <> ".TIF" And UCase(Path.GetExtension(Archivo_A_Abrir.FileName)) <> ".TIFF" And UCase(Path.GetExtension(Archivo_A_Abrir.FileName)) <> ".PNG" And UCase(Path.GetExtension(Archivo_A_Abrir.FileName)) <> ".ICO" Then
                        MessageBox.Show("EL ARCHIVO SELECCIONADO NO ES DEL TIPO CORRECTO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        controles(Nro_Control, 14) = Archivo_A_Abrir.FileName
                        Me.TxtFile.Text = Archivo_A_Abrir.FileName
                    End If
                ElseIf tipo_input = "P" Then
                    If UCase(Path.GetExtension(Archivo_A_Abrir.FileName)) <> ".PDF" Then
                        MessageBox.Show("EL ARCHIVO SELECCIONADO NO ES DEL TIPO CORRECTO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        controles(Nro_Control, 14) = Archivo_A_Abrir.FileName
                        Me.TxtFile.Text = Archivo_A_Abrir.FileName
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub CmdClean_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CmdClean.Click
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
            Me.CmdSearch.Visible = True
            Me.CmdReport.Visible = False
            Me.CmdRefresh.Visible = True
            Me.PanelDesign.Visible = False
            Me.Panel2.Visible = False
            Me.Panel3.Visible = False
            Me.TrvOficinas.Focus()
        End If
    End Sub
    Private Sub CmdNewSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CmdNewSearch.Click
        If MessageBox.Show("Está Ud. seguro de ABANDONAR el alcance actual y efectuar una nueva búsqueda?", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Me.PanelDesign.Visible = False
        CmdClean_Click(CmdNewSearch, e)
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
        toolTip1.SetToolTip(CmdReport, "Reporte")
        toolTip1.SetToolTip(CmdSearch, "Buscar")
        toolTip1.SetToolTip(CmdExit, "Salir")
        toolTip1.SetToolTip(CmdExec, "Ejecutar")
        toolTip1.SetToolTip(CmdClean, "Limpiar")
        toolTip1.SetToolTip(Me.Button1, "Texto Fijo")
        toolTip1.SetToolTip(Me.Button3, "Oficina")
        toolTip1.SetToolTip(Me.Button9, "Eliminar")
        toolTip1.SetToolTip(Me.Button10, "Traer al Frente")
        toolTip1.SetToolTip(Me.Button11, "Enviar al Fondo")
        toolTip1.SetToolTip(Me.Button12, "Duplicar")
        toolTip1.SetToolTip(Me.Button13, "Ticket")
        toolTip1.SetToolTip(Me.Button14, "Fecha y Hora")
        Me.TxtNombre.Enabled = False
        Me.TxtTipo.Enabled = False
        Me.txtSize.Enabled = False
        Me.TxtFile.Enabled = False
        Me.TxtTexto.Enabled = False
        Me.ChkBold.Checked = False
        Me.ChkBold.Enabled = False
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
            Carga_Coneccion_O.Dispose()
            Me.LblAplicacion.Text = "GLOBAL"
            alcance(0) = "999999"
            alcance(1) = ""
            alcance(2) = ""
            alcance_control_c(0) = ""
            alcance_control_c(1) = ""
            alcance_control_c(2) = ""
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
        Panel_Estado3.Text = DateAdd(DateInterval.Second, desfase_segundos, Date.Now).ToLongDateString()
        Panel_Estado3.ToolTipText = DateAdd(DateInterval.Second, desfase_segundos, Date.Now).ToShortTimeString()
        Me.CmdClean.Enabled = True
        Me.CmdExec.Enabled = True
        Me.CmdExit.Enabled = True
        Me.CmdNewSearch.Enabled = True
        Me.CmdReport.Enabled = True
        Me.CmdSearch.Enabled = True
        Me.TrvOficinas.Enabled = True
        Me.CmdExec.Visible = False
        Me.CmdNewSearch.Visible = False
        Me.CmdSearch.Visible = True
        Me.CmdReport.Visible = False
        Me.CmdRefresh.Visible = True
        Me.PanelDesign.Visible = False
        Me.Panel2.Visible = False
        Me.PanelDesign.Width = "300"
        Me.PanelDesign.Height = "300"
        Me.crvReporte.Visible = False
        Me.Panel3.Visible = False
    End Sub
    Private Sub Limpia_Oficinas(ByVal Codigo As String)
        Try
            Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
            IQ_Cnn.Open()
            Dim IQ_Cmm As New OleDb.OleDbCommand("Delete from Iq_SerialDesign Where IQSerialDesign_Oficina = '" + Codigo & "' And IQSerialDesign_Area = '' And IQSerialDesign_Punto = '' And IQSerialDesign_Tipo = 'K'", IQ_Cnn)
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
    Private Sub LImpia_Kioskos(ByVal Codigo As String)
        Dim Carga_Coneccion_O As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O.Open()
        Dim Carga_Comando_O As New OleDb.OleDbCommand("Select IqConfigOfic_Codigo from IQ_ConfigOfic where IqConfigOfic_Oficina = '" & Codigo & "' And IqConfigOfic_Tipo = 'K'", Carga_Coneccion_O)
        Dim Carga_Reader_O As OleDb.OleDbDataReader = Carga_Comando_O.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O.Read
            Try
                Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
                IQ_Cnn.Open()
                Dim IQ_Cmm As New OleDb.OleDbCommand("Delete from Iq_SerialDesign Where IQSerialDesign_Oficina = '' And IQSerialDesign_Area = 'K:" & Trim(Carga_Reader_O.GetValue(0)) & "' And IQSerialDesign_Punto = '' And IQSerialDesign_Tipo = 'K'", IQ_Cnn)
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
    Private Sub LImpia_Areas(ByVal Codigo As String)
        Dim Carga_Coneccion_O As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O.Open()
        Dim Carga_Comando_O As New OleDb.OleDbCommand("Select IqAreas_Codigo from IQ_Areas where IqAreas_Oficina = '" & Codigo & "'", Carga_Coneccion_O)
        Dim Carga_Reader_O As OleDb.OleDbDataReader = Carga_Comando_O.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O.Read
            Try
                Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
                IQ_Cnn.Open()
                Dim IQ_Cmm As New OleDb.OleDbCommand("Delete from Iq_SerialDesign Where IQSerialDesign_Oficina = '' And IQSerialDesign_Area = 'A:" & Trim(Carga_Reader_O.GetValue(0)) & "' And IQSerialDesign_Punto = '' And IQSerialDesign_Tipo = 'K'", IQ_Cnn)
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
    Private Sub LImpia_Puntos(ByVal Codigo As String)
        Dim Carga_Coneccion_O As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O.Open()
        Dim Carga_Comando_O As New OleDb.OleDbCommand("Select IqPuntos_Codigo from IQ_PuntosAtencion where IqPuntos_Area = '" & Codigo & "'", Carga_Coneccion_O)
        Dim Carga_Reader_O As OleDb.OleDbDataReader = Carga_Comando_O.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O.Read
            Try
                Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
                IQ_Cnn.Open()
                Dim IQ_Cmm As New OleDb.OleDbCommand("Delete from Iq_SerialDesign Where IQSerialDesign_Oficina = '' And IQSerialDesign_Area = '' And IQSerialDesign_Punto = '" & Trim(Carga_Reader_O.GetValue(0)) & "' And IQSerialDesign_Tipo = 'K'", IQ_Cnn)
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
    Private Sub txtSize_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSize.Validating
        If IsNumeric(Me.txtSize.Text) = False Then
            e.Cancel = True
            Exit Sub
        End If
        If Len(Me.txtSize.Text) <> 2 Then
            e.Cancel = True
            Exit Sub
        End If
        If Mid(Me.txtSize.Text, 1, 1) <> "1" And Mid(Me.txtSize.Text, 1, 1) <> "2" And Mid(Me.txtSize.Text, 1, 1) <> "3" And Mid(Me.txtSize.Text, 1, 1) <> "4" Then
            e.Cancel = True
            Exit Sub
        End If
        If Mid(Me.txtSize.Text, 2, 1) <> "1" And Mid(Me.txtSize.Text, 2, 1) <> "2" And Mid(Me.txtSize.Text, 2, 1) <> "3" And Mid(Me.txtSize.Text, 2, 1) <> "4" Then
            e.Cancel = True
            Exit Sub
        End If
        Me.txtSize.Text = CStr(Math.Abs(Int(CDbl(Me.txtSize.Text))))
        controles(Nro_Control, 11) = Me.txtSize.Text
    End Sub
    Private Sub limpia_nodos(ByVal nodo As Integer, ByVal nivel As Integer)
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
    Private Function Busca_Maximo(ByVal Codigo As String) As String
        Dim numero_maximo As Integer = 0
        Dim ind_cont As Integer
        If num_controles > 0 Then
            For ind_cont = 0 To num_controles - 1
                If Mid(controles(ind_cont, 0), 1, Len(Codigo)) = Codigo Then
                    Dim nomiro As Integer = CInt(Mid(controles(ind_cont, 0), Len(Codigo) + 1, Len(controles(ind_cont, 0)) - Len(Codigo)))
                    If nomiro > numero_maximo Then
                        numero_maximo = CInt(Mid(controles(ind_cont, 0), Len(Codigo) + 1, Len(controles(ind_cont, 0)) - Len(Codigo)))
                    End If
                End If
            Next
        End If
        numero_maximo += 1
        Busca_Maximo = Codigo & Trim(CStr(numero_maximo))
    End Function
    Private Sub ChkBold_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkBold.Click
        If Me.ChkBold.Checked = True Then
            controles(Nro_Control, 12) = "S"
        Else
            controles(Nro_Control, 12) = "N"
        End If
    End Sub
    Private Sub TxtTexto_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtTexto.Validating
        controles(Nro_Control, 15) = Me.TxtTexto.Text
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
            Carga_Coneccion_O.Dispose()
            Me.LblAplicacion.Text = "GLOBAL"
            alcance(0) = "999999"
            alcance(1) = ""
            alcance(2) = ""
            alcance_control_c(0) = ""
            alcance_control_c(1) = ""
            alcance_control_c(2) = ""
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
    Private Sub CmdReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CmdReport.Click
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
            rptlayout.Load(Disco_Appl & ":\I-Q\IQ_Rpt\IQ_C0023.rpt")
            rptlayout.SetDatabaseLogon(Server_User, Server_Pwd)
            rptlayout.SummaryInfo.ReportTitle = Nombre_Cliente + Chr(10) + Me.Text
            Me.crvReporte.SelectionFormula = "{Iq_Design.IQSerialDesign_Oficina} = '" + alcance(0) + "' And {Iq_Design.IQSerialDesign_Area} = '" + alcance(1) + "' And {Iq_Design.IQSerialDesign_Punto} = '" + alcance(2) + "' And {Iq_Design.IQSerialDesign_Tipo} = 'K'"
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
    Private Sub CmdExec_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CmdExec.Click
        If MessageBox.Show("Está Ud. seguro de GRABAR el diseño del Ticket?", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Try
            Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
            IQ_Cnn.Open()
            Dim IQ_Cmm As New OleDb.OleDbCommand("Delete from Iq_SerialDesign Where IQSerialDesign_Oficina = '" + alcance(0) & "' And IQSerialDesign_Area = '" + alcance(1) & "' And IQSerialDesign_Punto = '" + alcance(2) & "' And IQSerialDesign_Tipo = 'K'", IQ_Cnn)
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
                            Dim IQ_Cmm As New OleDb.OleDbCommand("Delete from Iq_SerialDesign Where IQSerialDesign_Oficina = '' And IQSerialDesign_Area = '' And IQSerialDesign_Punto = '" + Carga_Reader_O2.GetValue(0) & "' And IQSerialDesign_Tipo = 'K'", IQ_Cnn)
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
                Dim IQ_Cmm As New OleDb.OleDbCommand("Delete from Iq_SerialDesign Where IQSerialDesign_Tipo = 'K'", IQ_Cnn)
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
        Dim topes(num_controles) As Integer
        For counter = 0 To num_controles - 1
            If Trim(controles(counter, 0)) <> "" Then
                For Each control_a_buscar As Control In PanelDesign.Controls
                    If controles(counter, 0) = control_a_buscar.Name Then
                        control_en_curso = control_a_buscar
                        topes(counter) = control_en_curso.Top
                    End If
                Next
            End If
        Next
        Dim ordenados(num_controles, 2) As Integer
        Dim counter_2 As Integer
        Dim counter_3 As Integer
        For counter = 0 To num_controles - 1
            For counter_2 = 0 To num_controles - 1
                If ordenados(counter_2, 0) = Nothing Then
                    ordenados(counter_2, 0) = topes(counter)
                    ordenados(counter_2, 1) = counter
                    Exit For
                ElseIf topes(counter) < ordenados(counter_2, 0) Then
                    For counter_3 = num_controles - 1 To counter_2 + 1 Step -1
                        ordenados(counter_3, 0) = ordenados(counter_3 - 1, 0)
                        ordenados(counter_3, 1) = ordenados(counter_3 - 1, 1)
                    Next
                    ordenados(counter_2, 0) = topes(counter)
                    ordenados(counter_2, 1) = counter
                    Exit For
                End If
            Next
        Next
        For counter_2 = 0 To num_controles - 1
            counter = ordenados(counter_2, 1)
            If Trim(controles(counter, 0)) <> "" Then
                For Each control_a_buscar As Control In PanelDesign.Controls
                    If controles(counter, 0) = control_a_buscar.Name Then
                        control_en_curso = control_a_buscar
                        Exit For
                    End If
                Next
                Dim instruccion_insert As String = ""
                instruccion_insert = "Insert Into Iq_SerialDesign Values('" + alcance(0) + "', '" + alcance(1) + "', '" & alcance(2) + "', 'K', "
                instruccion_insert = instruccion_insert & "'" & controles(counter, 1) & "', "
                instruccion_insert = instruccion_insert & "'" & controles(counter, 0) & "', "
                instruccion_insert = instruccion_insert & "'" & controles(counter, 11) & "', "
                instruccion_insert = instruccion_insert & "'" & controles(counter, 12) & "', "
                instruccion_insert = instruccion_insert & "'" & controles(counter, 14) & "', "
                instruccion_insert = instruccion_insert & "'" & controles(counter, 15) & "', "
                instruccion_insert = instruccion_insert & CStr(counter_2) & ")"
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
    Private Sub CmdSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CmdSearch.Click
        Dim Alcance_recup(3) As String
        Dim recup_block As Boolean = False
        If alcance_control_c(0) <> "" Or alcance_control_c(1) <> "" Or alcance_control_c(2) <> "" Then
            Alcance_recup(0) = alcance_control_c(0)
            Alcance_recup(1) = alcance_control_c(1)
            Alcance_recup(2) = alcance_control_c(2)
            recup_block = True
        Else
            Alcance_recup(0) = alcance(0)
            Alcance_recup(1) = alcance(1)
            Alcance_recup(2) = alcance(2)
        End If
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
            controles(counter, 10) = Nothing
            controles(counter, 11) = Nothing
            controles(counter, 12) = Nothing
            controles(counter, 13) = Nothing
            controles(counter, 14) = Nothing
            controles(counter, 15) = Nothing
            controles(counter, 16) = Nothing
            controles(counter, 17) = Nothing
            controles(counter, 18) = Nothing
            controles(counter, 19) = Nothing
        Next
        Me.PanelDesign.Controls.Clear()
        Dim encontrado As Boolean = False
        Dim mensaje_recup As String = ""
        num_controles = 0
        If Alcance_recup(2) = "" Then GoTo busca_2
        Dim Carga_Coneccion_O1 As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O1.Open()
        Dim Carga_Comando_O1 As New OleDb.OleDbCommand("Select Iq_SerialDesign.*, IQ_PuntosAtencion.IQPUntos_Descripcion from Iq_SerialDesign join IQ_PuntosAtencion on Iq_SerialDesign.IIQSerialDesign_Punto = IQ_PuntosAtencion.IQPuntos_Codigo where IQSerialDesign_Oficina = '' and IQSerialDesign_Area = '' and IQSerialDesign_Punto = '" & Alcance_recup(2) & "' And IQSerialDesign_Tipo = 'K' Order by IQSerialDesign_Orden", Carga_Coneccion_O1)
        Dim Carga_Reader_O1 As OleDb.OleDbDataReader = Carga_Comando_O1.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O1.Read
            If IsDBNull(Carga_Reader_O1.GetValue(0)) = False Then
                If encontrado = False Then
                    mensaje_recup = "RECUPERANDO PLANTILLA NIVEL PUNTO DE ATENCION: " & Carga_Reader_O1.GetValue(11)
                End If
                encontrado = True
                controles(num_controles, 0) = Carga_Reader_O1.GetValue(5)
                controles(num_controles, 1) = Carga_Reader_O1.GetValue(4)
                controles(num_controles, 5) = CStr(num_controles)
                controles(num_controles, 11) = CStr(Carga_Reader_O1.GetValue(6))
                controles(num_controles, 12) = CStr(Carga_Reader_O1.GetValue(7))
                controles(num_controles, 14) = CStr(Carga_Reader_O1.GetValue(8))
                controles(num_controles, 15) = CStr(Carga_Reader_O1.GetValue(9))
                num_controles += 1
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
        Dim Carga_Comando_O2 As New OleDb.OleDbCommand("Select * from Iq_SerialDesign where IQSerialDesign_Oficina = '' and IQSerialDesign_Area = '" & Alcance_recup(1) & "' and IQSerialDesign_Punto = '' And IQSerialDesign_Tipo = 'K' Order by IQSerialDesign_Orden", Carga_Coneccion_O2)
        Dim Carga_Reader_O2 As OleDb.OleDbDataReader = Carga_Comando_O2.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O2.Read
            If IsDBNull(Carga_Reader_O2.GetValue(0)) = False Then
                If encontrado = False Then
                    Me.PanelDesign.Width = CInt(Carga_Reader_O2.GetValue(15))
                    Me.PanelDesign.Height = CInt(Carga_Reader_O2.GetValue(16))
                End If
                encontrado = True
                controles(num_controles, 0) = Carga_Reader_O2.GetValue(5)
                controles(num_controles, 1) = Carga_Reader_O2.GetValue(4)
                controles(num_controles, 5) = CStr(num_controles)
                controles(num_controles, 11) = CStr(Carga_Reader_O2.GetValue(6))
                controles(num_controles, 12) = CStr(Carga_Reader_O2.GetValue(7))
                controles(num_controles, 14) = CStr(Carga_Reader_O2.GetValue(8))
                controles(num_controles, 15) = CStr(Carga_Reader_O2.GetValue(9))
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
        Dim Carga_Comando_O3 As New OleDb.OleDbCommand("Select Iq_SerialDesign.*, Iq_Oficinas.IQOficinas_Descripcion,  Iq_Oficinas.IQOficinas_Consolidacion from Iq_SerialDesign join IQ_Oficinas on IQSerialDesign_Oficina = IQOficinas_Codigo where IQSerialDesign_Oficina = '" & Alcance_recup(0) & "' and IQSerialDesign_Area = '' and IQSerialDesign_Punto = '' And IQSerialDesign_Tipo = 'K' Order by IQSerialDesign_Orden", Carga_Coneccion_O3)
        Dim Carga_Reader_O3 As OleDb.OleDbDataReader = Carga_Comando_O3.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O3.Read
            If IsDBNull(Carga_Reader_O3.GetValue(0)) = False Then
                If encontrado = False Then
                    mensaje_recup = "RECUPERANDO PLANTILLA NIVEL OFICINA: " & Carga_Reader_O3.GetValue(11)
                End If
                encontrado = True
                controles(num_controles, 0) = Carga_Reader_O3.GetValue(5)
                controles(num_controles, 1) = Carga_Reader_O3.GetValue(4)
                controles(num_controles, 5) = CStr(num_controles)
                controles(num_controles, 11) = CStr(Carga_Reader_O3.GetValue(6))
                controles(num_controles, 12) = CStr(Carga_Reader_O3.GetValue(7))
                controles(num_controles, 14) = CStr(Carga_Reader_O3.GetValue(8))
                controles(num_controles, 15) = CStr(Carga_Reader_O3.GetValue(9))
                num_controles += 1
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
        Dim Carga_Comando_O4 As New OleDb.OleDbCommand("Select * from Iq_SerialDesign where IQSerialDesign_Oficina = '999999' and IQSerialDesign_Area = '' and IQSerialDesign_Punto = '' And IQSerialDesign_Tipo = 'K' Order by IQSerialDesign_Orden", Carga_Coneccion_O4)
        Dim Carga_Reader_O4 As OleDb.OleDbDataReader = Carga_Comando_O4.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O4.Read
            If IsDBNull(Carga_Reader_O4.GetValue(0)) = False Then
                encontrado = True
                controles(num_controles, 0) = Carga_Reader_O4.GetValue(5)
                controles(num_controles, 1) = Carga_Reader_O4.GetValue(4)
                controles(num_controles, 5) = CStr(num_controles)
                controles(num_controles, 11) = CStr(Carga_Reader_O4.GetValue(6))
                controles(num_controles, 12) = CStr(Carga_Reader_O4.GetValue(7))
                controles(num_controles, 14) = CStr(Carga_Reader_O4.GetValue(8))
                controles(num_controles, 15) = CStr(Carga_Reader_O4.GetValue(9))
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
                NuevoControl.Height = 40
                NuevoControl.Width = Me.PanelDesign.Width
                NuevoControl.Location = New System.Drawing.Point(0, indice_controles * 40)
                NuevoControl.BorderStyle = BorderStyle.Fixed3D
                NuevoControl.BackColor = Color.WhiteSmoke
                NuevoControl.Name = controles(indice_controles, 0)
                Dim tooltip1 As New ToolTip(Me.components)
                Select Case (controles(indice_controles, 1))
                    Case "Texto Fijo"
                        NuevoControl.Image = System.Drawing.Image.FromFile(Disco_Appl & ":\I-Q\Iconos\Text.jpg")
                        NuevoControl.SizeMode = PictureBoxSizeMode.CenterImage
                        tooltip1.SetToolTip(NuevoControl, "Area de Texto Fijo")
                    Case "Fecha y Hora"
                        NuevoControl.Image = System.Drawing.Image.FromFile(Disco_Appl & ":\I-Q\Iconos\DateTime.png")
                        NuevoControl.SizeMode = PictureBoxSizeMode.CenterImage
                        tooltip1.SetToolTip(NuevoControl, "Area de Fecha y Hora")
                    Case "Ticket"
                        NuevoControl.Image = System.Drawing.Image.FromFile(Disco_Appl & ":\I-Q\Iconos\Ticket.Jpg")
                        NuevoControl.SizeMode = PictureBoxSizeMode.CenterImage
                        tooltip1.SetToolTip(NuevoControl, "Area para el Número de Ticket")
                    Case "Oficina"
                        NuevoControl.Image = System.Drawing.Image.FromFile(Disco_Appl & ":\I-Q\Iconos\Oficinas.Png")
                        NuevoControl.SizeMode = PictureBoxSizeMode.CenterImage
                        tooltip1.SetToolTip(NuevoControl, "Area para Nombre de la Oficina")
                End Select
                NuevoControl.BringToFront()
                AddHandler NuevoControl.Click, AddressOf Control_Click
                AddHandler NuevoControl.DoubleClick, AddressOf Control_DoubleClick
                AddHandler NuevoControl.MouseDown, AddressOf Control_MouseDown
                AddHandler NuevoControl.MouseMove, AddressOf Control_MouseMove
                AddHandler NuevoControl.MouseUp, AddressOf Control_MouseUp
                Control_a_cargo = NuevoControl
                Nro_Control = indice_controles
                Me.TxtNombre.Text = Control_a_cargo.name
                Me.TxtTipo.Text = controles(indice_controles, 1)
                Me.txtSize.Text = controles(indice_controles, 11)
                If controles(indice_controles, 12) = "S" Then
                    Me.ChkBold.Checked = True
                Else
                    Me.ChkBold.Checked = False
                End If
                Me.TxtFile.Text = controles(indice_controles, 14)
                Me.TxtTexto.Text = controles(indice_controles, 15)
            Next
        End If
        Me.PanelDesign.Visible = True
        Me.Panel2.Visible = True
        Me.Panel3.Visible = True
        Me.TrvOficinas.Enabled = False
        If Permisos > 3 Then
            Me.CmdExec.Visible = True
        Else
            Me.CmdExec.Visible = False
        End If
        Me.CmdNewSearch.Visible = True
        Me.CmdRefresh.Visible = False
        Me.CmdSearch.Visible = False
        Me.CmdReport.Visible = True
        Me.PanelDesign.Visible = True
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
                If MessageBox.Show("Está Ud. Seguro de definir " & labelito & " Como la Plantilla a recuperar?", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
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
                MessageBox.Show(labelito & " ESTABLECIDO COMO PLANTILLA A RECUPERAR", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                Exit Sub
            End Try
        End If
    End Sub
End Class