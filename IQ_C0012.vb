Imports System.Data.OleDb
Public Class IQ_C0012
    Dim Permisos As Integer = 0
    Dim counter_lista As Integer
    Dim listaroles As New System.Windows.Forms.ListBox

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
        toolTip1.SetToolTip(CmdExit, "Salir")
        toolTip1.SetToolTip(CmdExec, "Ejecutar")
        toolTip1.SetToolTip(CmdClean, "Limpiar")
        toolTip1.SetToolTip(CmdRefresh, "Actualizar Listas")
        toolTip1.SetToolTip(Me.ChkAlta, "Asigna permiso de Creación/Ejecución")
        toolTip1.SetToolTip(Me.ChkBaja, "Asigna permiso de Eliminación")
        toolTip1.SetToolTip(Me.ChkModificacion, "Asigna permiso de Modificación")
        toolTip1.SetToolTip(Me.CmbRoles, "Rol para el que se asignan accesos")
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
        Limpiar_Controles()
    End Sub
    Private Sub Limpiar_Controles()
        If Permisos < 4 Then
            Me.CmdExec.Visible = False
        Else
            Me.CmdExec.Visible = True
        End If
        Dim instruccion As String
        Me.listaroles.MultiColumn = True
        Me.listaroles.SelectionMode = SelectionMode.One
        Me.CmbRoles.Items.Clear()
        Me.listaroles.Items.Clear()
        Me.CmbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbRoles.Sorted = True
        Me.listaroles.BeginUpdate()
        instruccion = "Select IqRoles_Codigo, IqRoles_Descripcion from Iq_Roles order by IqRoles_Codigo"
        Dim Carga_Coneccion_O As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O.Open()
        Dim Carga_Comando_O As New OleDb.OleDbCommand(instruccion, Carga_Coneccion_O)
        Dim Carga_Reader_O As OleDb.OleDbDataReader = Carga_Comando_O.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O.Read
            Me.listaroles.Items.Add(Carga_Reader_O.GetValue(0))
            Me.listaroles.Items.Add(Carga_Reader_O.GetValue(1))
            Me.CmbRoles.Items.Add(Carga_Reader_O.GetValue(1))
        End While
        Carga_Coneccion_O.Dispose()
        Me.CmbRoles.Items.Add("")
        Me.listaroles.EndUpdate()
        Me.CmbRoles.EndUpdate()
        Me.CmbRoles.Text = ""
        Me.ChkAlta.Checked = False
        Me.ChkBaja.Checked = False
        Me.ChkModificacion.Checked = False
        Me.CmbRoles.Focus()
    End Sub
    Private Function CodigoRol(ByVal Codigo As String) As String
        CodigoRol = ""
        If Me.listaroles.Items.Count = 0 Then
            CodigoRol = ""
        Else
            For Me.counter_lista = 1 To Me.listaroles.Items.Count - 1 Step 2
                If Trim(Codigo) = Trim(Me.listaroles.Items.Item(Me.counter_lista)) Then
                    CodigoRol = Me.listaroles.Items.Item(Me.counter_lista - 1)
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
                Me.listaroles.MultiColumn = True
                Me.listaroles.SelectionMode = SelectionMode.One
                Me.CmbRoles.Items.Clear()
                Me.listaroles.Items.Clear()
                Me.CmbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
                Me.CmbRoles.Sorted = True
                Me.listaroles.BeginUpdate()
                Dim instruccion As String = "Select IqRoles_Codigo, IqRoles_Descripcion from Iq_Roles order by IqRoles_Codigo"
                Dim Carga_Coneccion_O As New OleDb.OleDbConnection(Cnn_Central_Server)
                Carga_Coneccion_O.Open()
                Dim Carga_Comando_O As New OleDb.OleDbCommand(instruccion, Carga_Coneccion_O)
                Dim Carga_Reader_O As OleDb.OleDbDataReader = Carga_Comando_O.ExecuteReader(CommandBehavior.CloseConnection)
                While Carga_Reader_O.Read
                    Me.listaroles.Items.Add(Carga_Reader_O.GetValue(0))
                    Me.listaroles.Items.Add(Carga_Reader_O.GetValue(1))
                    Me.CmbRoles.Items.Add(Carga_Reader_O.GetValue(1))
                End While
                Carga_Coneccion_O.Dispose()
                Me.CmbRoles.Items.Add("")
                Me.listaroles.EndUpdate()
                Me.CmbRoles.EndUpdate()
                Me.CmbRoles.Text = ""
            Case Else
                MessageBox.Show("Comando no implementado")
        End Select
    End Sub
    Private Sub Update_Process()
        If Trim(Me.CmbRoles.Text) = "" Then
            MessageBox.Show("Debe seleccionar el rol para la asignación", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.CmbRoles.Focus()
            Exit Sub
        End If
        Dim TransaccionesAsignadas As Integer
        TransaccionesAsignadas = 0
        Barra_Estado.Panels(1).Text = "Asignando Permisos ...."
        Dim string_command As String
        string_command = "Select * from Iq_Menus order by IqMenus_Codigo"
        Dim CnnAnalisis As New OleDb.OleDbConnection(Cnn_Central_Server)
        CnnAnalisis.Open()
        Dim CmmAnalisis As New OleDb.OleDbCommand(string_command, CnnAnalisis)
        Dim DatosAnalisis As OleDb.OleDbDataReader = CmmAnalisis.ExecuteReader(CommandBehavior.CloseConnection)
        While DatosAnalisis.Read()
            If IsDBNull(DatosAnalisis.GetValue(0)) = False Then
                Dim val_perm As Integer = 0
                If Me.ChkAlta.Checked = True Then val_perm += 4
                If Me.ChkBaja.Checked = True Then val_perm += 2
                If Me.ChkModificacion.Checked = True Then val_perm += 1
                string_command = "insert into Iq_Permisos values ('" & CodigoRol(Me.CmbRoles.Text) & "', '" & DatosAnalisis.GetValue(0) & "', " & CStr(val_perm) & ")"
                Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
                Try
                    TransaccionesAsignadas += 1
                    IQ_Cnn.Open()
                    Dim IQ_Cmm2 As New OleDb.OleDbCommand(string_command, IQ_Cnn)
                    Dim RegistrosInsertados2 As Long = IQ_Cmm2.ExecuteNonQuery()
                    IQ_Cnn.Close()
                    IQ_Cnn.Dispose()
                Catch exc As Exception
                    TransaccionesAsignadas -= 1
                    IQ_Cnn.Dispose()
                    Exit Try
                End Try
            End If
        End While
        MessageBox.Show(TransaccionesAsignadas.ToString + " Transaccion(es) fueron asignadas satisfactoriamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Limpiar_Controles()
    End Sub
End Class