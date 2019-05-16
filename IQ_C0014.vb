Imports System.Data.OleDb
Public Class IQ_C0014
    Dim Permisos As Integer = 0
    Dim counter_lista As Integer
    Dim listarolorig As New System.Windows.Forms.ListBox
    Dim listaroldest As New System.Windows.Forms.ListBox

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles CmdExit.Click
        IQ_C0000.PicFondo.Visible = True
        Me.Dispose()
    End Sub
    Public Sub New()

        InitializeComponent()
        Dim toolTip1 As New ToolTip()
        toolTip1.AutoPopDelay = 5000
        toolTip1.InitialDelay = 1000
        toolTip1.ReshowDelay = 500
        toolTip1.ShowAlways = True
        toolTip1.SetToolTip(Me.CmbRolOrigen, "Rol desde el cual se copian los accesos")
        toolTip1.SetToolTip(Me.CmbRolDestino, "Rol al cual se copian los accesos")
        toolTip1.SetToolTip(CmdRefresh, "Actualizar Listas")
        toolTip1.SetToolTip(CmdExit, "Salir")
        toolTip1.SetToolTip(CmdExec, "Ejecutar")
        toolTip1.SetToolTip(CmdClean, "Limpiar")
        Timer1.Enabled = True
        Timer1.Start()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Timer1.Enabled = False
        If InStr(Me.Text, "|") > 0 Then
            Permisos = CInt(Mid(Me.Text, InStr(Me.Text, "|") + 1, 1))
            Me.Text = Mid(Me.Text, 1, InStr(Me.Text, "|") - 1)
        End If
        Me.Panel_Estado0.Text = ""
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
        Limpiar_Controles()
    End Sub
    Private Sub Limpiar_Controles()
        If Permisos < 4 Then
            Me.CmdExec.Visible = False
        Else
            Me.CmdExec.Visible = True
        End If
        Dim instruccion As String
        Me.listarolorig.MultiColumn = True
        Me.listarolorig.SelectionMode = SelectionMode.One
        Me.listaroldest.MultiColumn = True
        Me.listaroldest.SelectionMode = SelectionMode.One
        Me.CmbRolOrigen.Items.Clear()
        Me.listarolorig.Items.Clear()
        Me.CmbRolOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbRolOrigen.Sorted = True
        Me.CmbRolDestino.Items.Clear()
        Me.listaroldest.Items.Clear()
        Me.CmbRolDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbRolDestino.Sorted = True
        Me.listarolorig.BeginUpdate()
        Me.listaroldest.BeginUpdate()
        instruccion = "Select IqRoles_Codigo, IqRoles_Descripcion from Iq_Roles order by IqRoles_Codigo"
        Dim Carga_Coneccion_O As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O.Open()
        Dim Carga_Comando_O As New OleDb.OleDbCommand(instruccion, Carga_Coneccion_O)
        Dim Carga_Reader_O As OleDb.OleDbDataReader = Carga_Comando_O.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O.Read
            Me.listarolorig.Items.Add(Carga_Reader_O.GetValue(0))
            Me.listarolorig.Items.Add(Carga_Reader_O.GetValue(1))
            Me.CmbRolOrigen.Items.Add(Carga_Reader_O.GetValue(1))
            Me.listaroldest.Items.Add(Carga_Reader_O.GetValue(0))
            Me.listaroldest.Items.Add(Carga_Reader_O.GetValue(1))
            Me.CmbRolDestino.Items.Add(Carga_Reader_O.GetValue(1))
        End While
        Carga_Coneccion_O.Dispose()
        Me.CmbRolOrigen.Items.Add("")
        Me.listarolorig.EndUpdate()
        Me.CmbRolOrigen.EndUpdate()
        Me.CmbRolOrigen.Text = ""
        Me.CmbRolDestino.Items.Add("")
        Me.listaroldest.EndUpdate()
        Me.CmbRolDestino.EndUpdate()
        Me.CmbRolDestino.Text = ""
        Me.CmbRolOrigen.Focus()
    End Sub
    Private Function CodigoRolOrig(ByVal Codigo As String) As String
        CodigoRolOrig = ""
        If Me.listarolorig.Items.Count = 0 Then
            CodigoRolOrig = ""
        Else
            For Me.counter_lista = 1 To Me.listarolorig.Items.Count - 1 Step 2
                If Trim(Codigo) = Trim(Me.listarolorig.Items.Item(Me.counter_lista)) Then
                    CodigoRolOrig = Me.listarolorig.Items.Item(Me.counter_lista - 1)
                End If
            Next
        End If
    End Function
    Private Function CodigoRolDest(ByVal Codigo As String) As String
        CodigoRolDest = ""
        If Me.listaroldest.Items.Count = 0 Then
            CodigoRolDest = ""
        Else
            For Me.counter_lista = 1 To Me.listaroldest.Items.Count - 1 Step 2
                If Trim(Codigo) = Trim(Me.listaroldest.Items.Item(Me.counter_lista)) Then
                    CodigoRolDest = Me.listaroldest.Items.Item(Me.counter_lista - 1)
                End If
            Next
        End If
    End Function
    Private Sub Buttons_Click(sender As Object, e As EventArgs) Handles CmdExec.Click, CmdClean.Click, CmdExit.Click, CmdRefresh.Click
        Select Case UCase(sender.name)
            Case "CMDEXEC"
                Update_Process()
            Case "CMDCLEAN"
                Limpiar_Controles()
            Case "CMDEXIT"
                IQ_C0000.PicFondo.Visible = True
                Me.Dispose()
            Case "CMDREFRESH"
                Dim instruccion As String
                Me.listarolorig.MultiColumn = True
                Me.listarolorig.SelectionMode = SelectionMode.One
                Me.listaroldest.MultiColumn = True
                Me.listaroldest.SelectionMode = SelectionMode.One
                Me.CmbRolOrigen.Items.Clear()
                Me.listarolorig.Items.Clear()
                Me.CmbRolOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
                Me.CmbRolOrigen.Sorted = True
                Me.CmbRolDestino.Items.Clear()
                Me.listaroldest.Items.Clear()
                Me.CmbRolDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
                Me.CmbRolDestino.Sorted = True
                Me.listarolorig.BeginUpdate()
                Me.listaroldest.BeginUpdate()
                instruccion = "Select IqRoles_Codigo, IqRoles_Descripcion from Iq_Roles order by IqRoles_Codigo"
                Dim Carga_Coneccion_O As New OleDb.OleDbConnection(Cnn_Central_Server)
                Carga_Coneccion_O.Open()
                Dim Carga_Comando_O As New OleDb.OleDbCommand(instruccion, Carga_Coneccion_O)
                Dim Carga_Reader_O As OleDb.OleDbDataReader = Carga_Comando_O.ExecuteReader(CommandBehavior.CloseConnection)
                While Carga_Reader_O.Read
                    Me.listarolorig.Items.Add(Carga_Reader_O.GetValue(0))
                    Me.listarolorig.Items.Add(Carga_Reader_O.GetValue(1))
                    Me.CmbRolOrigen.Items.Add(Carga_Reader_O.GetValue(1))
                    Me.listaroldest.Items.Add(Carga_Reader_O.GetValue(0))
                    Me.listaroldest.Items.Add(Carga_Reader_O.GetValue(1))
                    Me.CmbRolDestino.Items.Add(Carga_Reader_O.GetValue(1))
                End While
                Carga_Coneccion_O.Dispose()
                Me.CmbRolOrigen.Items.Add("")
                Me.listarolorig.EndUpdate()
                Me.CmbRolOrigen.EndUpdate()
                Me.CmbRolOrigen.Text = ""
                Me.CmbRolDestino.Items.Add("")
                Me.listaroldest.EndUpdate()
                Me.CmbRolDestino.EndUpdate()
                Me.CmbRolDestino.Text = ""
                Me.CmbRolOrigen.Focus()
            Case Else
                MessageBox.Show("Comando no implementado")
        End Select
    End Sub
    Private Sub Update_Process()
        If Trim(Me.CmbRolDestino.Text) = "" Or Trim(Me.CmbRolOrigen.Text) = "" Then
            MessageBox.Show("Debe seleccionar ambos roles para la copia", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.CmbRolOrigen.Focus()
            Exit Sub
        End If
        Dim TransaccionesCopiadas As Integer
        TransaccionesCopiadas = 0
        Barra_Estado.Panels(1).Text = "Copiando Permisos ...."
        Dim string_command As String
        string_command = "Select * from Iq_Permisos Where IqPerm_Rol = '" & CodigoRolOrig(Me.CmbRolOrigen.Text) & "' order by IqPerm_Menu"
        Dim CnnAnalisis As New OleDb.OleDbConnection(Cnn_Central_Server)
        CnnAnalisis.Open()
        Dim CmmAnalisis As New OleDb.OleDbCommand(string_command, CnnAnalisis)
        Dim DatosAnalisis As OleDb.OleDbDataReader = CmmAnalisis.ExecuteReader(CommandBehavior.CloseConnection)
        While DatosAnalisis.Read()
            If IsDBNull(DatosAnalisis.GetValue(0)) = False Then
                string_command = "insert into IQ_Permisos values ('" & CodigoRolDest(Me.CmbRolDestino.Text) & "', '" & DatosAnalisis.GetValue(1) & "', " & DatosAnalisis.GetValue(2) & ")"
                Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
                Try
                    TransaccionesCopiadas += 1
                    IQ_Cnn.Open()
                    Dim IQ_Cmm2 As New OleDb.OleDbCommand(string_command, IQ_Cnn)
                    Dim RegistrosInsertados2 As Long = IQ_Cmm2.ExecuteNonQuery()
                    IQ_Cnn.Close()
                    IQ_Cnn.Dispose()
                Catch exc As Exception
                    TransaccionesCopiadas -= 1
                    IQ_Cnn.Dispose()
                    Exit Try
                End Try
            End If
        End While
        MessageBox.Show(TransaccionesCopiadas.ToString + " Transaccion(es) fueron copiadas y asignadas satisfactoriamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Limpiar_Controles()
    End Sub
End Class