Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine

Public Class IQ_C0011
    Dim Permisos As Integer = 0
    Protected DatosPermisos As New DataSet
    Dim counter_lista As Integer
    Dim Tipo_Limpieza As String
    Dim listaroles As New System.Windows.Forms.ListBox
    Private DictRoles As New ColeccionRoles
    Dim listaMenus As New System.Windows.Forms.ListBox
    Private DictMenus As New ColeccionMenus

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
        toolTip1.SetToolTip(CmdInsert, "Insertar")
        toolTip1.SetToolTip(CmdModify, "Modificar")
        toolTip1.SetToolTip(CmdNewSearch, "Nueva Búsqueda")
        toolTip1.SetToolTip(CmdReport, "Reporte")
        toolTip1.SetToolTip(CmdSearch, "Buscar")
        toolTip1.SetToolTip(CmdExit, "Salir")
        toolTip1.SetToolTip(CmdDelete, "Eliminar")
        toolTip1.SetToolTip(CmdRefresh, "Actualizar Listas")
        toolTip1.SetToolTip(CmdClean, "Limpiar")
        toolTip1.SetToolTip(Me.ChkAlta, "Tiene permiso de Creación y/o Ejecucion")
        toolTip1.SetToolTip(Me.ChkBaja, "Tiene permiso de Eliminación")
        toolTip1.SetToolTip(Me.ChkModificacion, "Tiene permiso de Modificación")
        toolTip1.SetToolTip(Me.GridDatos, "Permisos ya definidos")
        toolTip1.SetToolTip(Me.CmbRoles, "Rol para el que se definen Permisos")
        toolTip1.SetToolTip(Me.CmbMenus, "Menú/Opción  para el que se definen Permisos")
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
        Tipo_Limpieza = "T"
        Limpiar_Controles()
    End Sub
    Private Sub Formatea_Grid()
        With Me.GridDatos
            .BackColor = Color.GhostWhite
            .BackgroundColor = Color.Lavender
            .BorderStyle = BorderStyle.Fixed3D
            .CaptionBackColor = Color.RoyalBlue
            .CaptionFont = New Font("Tahoma", 10.0!, FontStyle.Bold)
            .CaptionForeColor = Color.Bisque
            .Font = New Font("Tahoma", 8.0!)
            .ParentRowsBackColor = Color.Lavender
            .ParentRowsForeColor = Color.MidnightBlue
            .ReadOnly = True
            .AllowSorting = True
        End With
        Dim grdTableStyle1 As New DataGridTableStyle
        With grdTableStyle1
            .MappingName = "Iq_Permisos"
        End With
        Dim grdColStyle1 As New DataGridTextBoxColumn
        With grdColStyle1
            .HeaderText = "Menú/Opción"
            .MappingName = "IqPerm_Menu"
            .Width = 100
        End With
        Dim grdColStyle1b As New DataGridTextBoxColumn
        With grdColStyle1b
            .HeaderText = "Descripción"
            .MappingName = "IqMenus_Descripcion"
            .Width = 200
        End With
        Dim grdColStyle2 As New DataGridTextBoxColumn
        With grdColStyle2
            .HeaderText = "Permiso"
            .MappingName = "IqPerm_Acces"
            .Width = 100
        End With
        grdTableStyle1.GridColumnStyles.AddRange _
            (New DataGridColumnStyle() _
            {grdColStyle1, grdColStyle1b, grdColStyle2})
        Me.GridDatos.TableStyles.Add(grdTableStyle1)
    End Sub

    Private Class ColeccionRoles
        Inherits System.Collections.DictionaryBase

        Public Sub Add_ColeccionRoles(ByVal Key As String, ByVal Item As String)
            dictionary.Add(Key, Item)
        End Sub
    End Class

    Private Class ColeccionMenus
        Inherits System.Collections.DictionaryBase

        Public Sub Add_ColeccionMenus(ByVal Key As String, ByVal Item As String)
            dictionary.Add(Key, Item)
        End Sub

        Public Function Valor(ByVal Key As String) As String
            Valor = Dictionary.Item(Key)
        End Function
    End Class

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

    Private Function CodigoMenu(ByVal Codigo As String) As String
        CodigoMenu = ""
        If Me.listaMenus.Items.Count = 0 Then
            CodigoMenu = ""
        Else
            For Me.counter_lista = 1 To Me.listaMenus.Items.Count - 1 Step 2
                If Trim(Codigo) = Trim(Me.listaMenus.Items.Item(Me.counter_lista)) Then
                    CodigoMenu = Me.listaMenus.Items.Item(Me.counter_lista - 1)
                End If
            Next
        End If
    End Function

    Private Sub Limpiar_Controles()
        If Permisos > 0 Then
            Me.CmdReport.Visible = True
        Else
            Me.CmdReport.Visible = False
        End If
        Me.listaMenus.MultiColumn = True
        Me.listaMenus.SelectionMode = SelectionMode.One
        Me.DictMenus.Clear()
        Me.CmbMenus.Items.Clear()
        Me.listaMenus.Items.Clear()
        Me.CmbMenus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMenus.Sorted = True
        Me.listaMenus.BeginUpdate()
        Dim instruccion As String
        instruccion = "Select IqMenus_Codigo, IqMenus_Descripcion from Iq_Menus order by IqMenus_Codigo"
        Dim Carga_Coneccion_O0 As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O0.Open()
        Dim Carga_Comando_O0 As New OleDb.OleDbCommand(instruccion, Carga_Coneccion_O0)
        Dim Carga_Reader_O0 As OleDb.OleDbDataReader = Carga_Comando_O0.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O0.Read
            Me.listaMenus.Items.Add(Carga_Reader_O0.GetValue(0))
            Me.listaMenus.Items.Add(Carga_Reader_O0.GetValue(1))
            Me.CmbMenus.Items.Add(Carga_Reader_O0.GetValue(1))
        End While
        Carga_Coneccion_O0.Dispose()
        Me.CmbMenus.Items.Add("")
        Me.listaMenus.EndUpdate()
        Me.CmbMenus.EndUpdate()
        If Me.listaMenus.Items.Count > 0 Then
            For Me.counter_lista = 0 To Me.listaMenus.Items.Count - 2 Step 2
                Me.DictMenus.Add_ColeccionMenus(Me.listaMenus.Items.Item(counter_lista), Me.listaMenus.Items.Item(counter_lista + 1))
            Next
        End If
        Me.CmbMenus.Text = ""
        Me.CmbMenus.Enabled = True
        Me.ChkAlta.Checked = False
        Me.ChkBaja.Checked = False
        Me.ChkModificacion.Checked = False
        Me.crvReporte.Visible = False
        If Tipo_Limpieza = "T" Then
            Me.listaroles.MultiColumn = True
            Me.listaroles.SelectionMode = SelectionMode.One
            Me.DictRoles.Clear()
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
            If Me.listaroles.Items.Count > 0 Then
                For Me.counter_lista = 0 To Me.listaroles.Items.Count - 2 Step 2
                    Me.DictRoles.Add_ColeccionRoles(Me.listaroles.Items.Item(counter_lista), Me.listaroles.Items.Item(counter_lista + 1))
                Next
            End If
            Me.CmbRoles.Text = ""
            Me.GridDatos.DataSource = Nothing
            DatosPermisos.Clear()
            Me.GridDatos.Visible = False
            Me.CmbRoles.Enabled = True
            Me.ChkAlta.Visible = False
            Me.ChkBaja.Visible = False
            Me.ChkModificacion.Visible = False
            Me.CmbMenus.Visible = False
            Me.Label1.Visible = False
            Me.CmdInsert.Visible = False
            Me.CmdModify.Visible = False
            Me.CmdDelete.Visible = False
            Me.CmdSearch.Visible = True
            Me.CmbRoles.Focus()
        Else
            Me.CmdModify.Visible = False
            If Me.CmdDelete.Visible = True Then
                If Permisos > 3 Then
                    Me.CmdInsert.Visible = True
                Else
                    Me.CmdInsert.Visible = False
                End If
            End If
            Me.CmdDelete.Visible = False
            Me.CmbMenus.Focus()
        End If
    End Sub

    Private Sub Buscar_Data()
        If Trim(Me.CmbRoles.Text) = "" Then
            MessageBox.Show("Debe seleccionar el rol a buscar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.CmbRoles.Focus()
            Exit Sub
        End If
        If Not IsNothing(DatosPermisos.Tables("Iq_Permisos")) Then
            DatosPermisos.Tables("Iq_Permisos").Clear()
        End If
        With Me.GridDatos
            .TableStyles.Clear()
        End With
        Dim SeConecta As Boolean = True
        While SeConecta
            Try
                Dim CnnPermisos As New OleDb.OleDbConnection(Cnn_Central_Server)
                Dim AdapterPermisos As New OleDbDataAdapter("Select Iq_permisos.*, Iq_Menus.IqMEnus_Descripcion from Iq_Permisos join Iq_Menus on Iq_Permisos.iqPerm_Menu = Iq_Menus.IqMenus_Codigo Where Iq_Permisos.IqPerm_Rol = '" & CodigoRol(Me.CmbRoles.Text) & "'", CnnPermisos)
                DatosPermisos.Clear()
                AdapterPermisos.Fill(DatosPermisos, "Iq_Permisos")
                Me.GridDatos.DataSource = DatosPermisos.Tables("Iq_Permisos")
                SeConecta = False
            Catch exc As Exception
                MessageBox.Show(exc.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.Dispose()
                Exit Sub
            End Try
        End While
        Formatea_Grid()
        If Permisos > 0 Then
            Me.GridDatos.Visible = True
        Else
            Me.GridDatos.Visible = False
        End If
        Me.CmbRoles.Enabled = False
        Me.ChkAlta.Visible = True
        Me.ChkBaja.Visible = True
        Me.ChkModificacion.Visible = True
        Me.Label1.Visible = True
        Me.CmbMenus.Visible = True
        If Permisos > 3 Then
            Me.CmdInsert.Visible = True
        Else
            Me.CmdInsert.Visible = False
        End If
        Me.CmdModify.Visible = False
        Me.CmdDelete.Visible = False
        Me.CmdSearch.Visible = False
    End Sub

    Private Sub Update_Process()
        If Trim(Me.CmbRoles.Text) = "" Then
            MessageBox.Show("Debe seleccionar el rol", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.CmbRoles.Focus()
            Exit Sub
        End If
        If Trim(Me.CmbMenus.Text) = "" Then
            MessageBox.Show("Debe seleccionar la Opción/Menú", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.CmbMenus.Focus()
            Exit Sub
        End If
        Select Case File_Action
            Case "A"
                Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
                Try
                    IQ_Cnn.Open()
                    Dim val_perm As Integer = 0
                    If Me.ChkAlta.Checked = True Then val_perm += 4
                    If Me.ChkBaja.Checked = True Then val_perm += 2
                    If Me.ChkModificacion.Checked = True Then val_perm += 1
                    Dim IQ_Cmm As New OleDb.OleDbCommand("Insert Iq_Permisos Values('" + CodigoRol(Me.CmbRoles.Text) + "', '" + CodigoMenu(Me.CmbMenus.Text) + "', " + CStr(val_perm) + ")", IQ_Cnn)
                    Dim RegistrosInsertados As Long = IQ_Cmm.ExecuteNonQuery()
                    IQ_Cnn.Close()
                    MessageBox.Show(RegistrosInsertados.ToString + " Registro(s) fueron insertados satisfactoriamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch exc As Exception
                    MessageBox.Show(exc.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End Try
            Case "M"
                Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
                Try
                    IQ_Cnn.Open()
                    Dim val_perm As Integer = 0
                    If Me.ChkAlta.Checked = True Then val_perm += 4
                    If Me.ChkBaja.Checked = True Then val_perm += 2
                    If Me.ChkModificacion.Checked = True Then val_perm += 1
                    Dim IQ_Cmm As New OleDb.OleDbCommand("Update Iq_Permisos Set IqPerm_Acces = " + CStr(val_perm) + " Where Iqperm_Rol = '" + CodigoRol(Me.CmbRoles.Text) + "' And IqPerm_Menu = '" + CodigoMenu(Me.CmbMenus.Text) + "'", IQ_Cnn)
                    Dim RegistrosModificados As Long = IQ_Cmm.ExecuteNonQuery()
                    IQ_Cnn.Close()
                    MessageBox.Show(RegistrosModificados.ToString + " Registro(s) fueron modificados satisfactoriamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch exc As Exception
                    Dim Mensaje_Excepcion As String
                    Mensaje_Excepcion = exc.Message
                    Mensaje_Excepcion = "Error Integrado: " + Mensaje_Excepcion
                    MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End Try
            Case "B"
                Dim resp_par As String
                resp_par = MessageBox.Show("Está Ud. seguro de eliminar el registro?", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If resp_par = vbCancel Then
                    Exit Sub
                End If
                Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
                Try
                    IQ_Cnn.Open()
                    Dim IQ_Cmm As New OleDb.OleDbCommand("Delete from Iq_Permisos Where iqPerm_Rol = '" + CodigoRol(Me.CmbRoles.Text) + "' And iqPerm_Menu = '" + CodigoMenu(Me.CmbMenus.Text) + "'", IQ_Cnn)
                    Dim RegistrosEliminados As Long = IQ_Cmm.ExecuteNonQuery()
                    IQ_Cnn.Close()
                    MessageBox.Show(RegistrosEliminados.ToString + " Registro(s) fueron eliminados satisfactoriamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch exc As Exception
                    Dim Mensaje_Excepcion As String
                    Mensaje_Excepcion = exc.Message
                    Mensaje_Excepcion = "Error Integrado: " + Mensaje_Excepcion
                    MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End Try
        End Select
        Buscar_Data()
        Tipo_Limpieza = "P"
        Limpiar_Controles()
    End Sub

    Private Sub GridDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDatos.DoubleClick
        If Me.GridDatos.VisibleRowCount = 0 Then
            Exit Sub
        End If
        Me.CmbMenus.Text = Me.DictMenus.Valor(Me.GridDatos.Item(Me.GridDatos.CurrentCell.RowNumber, 0))
        Select Case Me.GridDatos.Item(Me.GridDatos.CurrentCell.RowNumber, 2)
            Case 0
                Me.ChkAlta.Checked = False
                Me.ChkBaja.Checked = False
                Me.ChkModificacion.Checked = False
            Case 1
                Me.ChkAlta.Checked = False
                Me.ChkBaja.Checked = False
                Me.ChkModificacion.Checked = True
            Case 2
                Me.ChkAlta.Checked = False
                Me.ChkBaja.Checked = True
                Me.ChkModificacion.Checked = False
            Case 3
                Me.ChkAlta.Checked = False
                Me.ChkBaja.Checked = True
                Me.ChkModificacion.Checked = True
            Case 4
                Me.ChkAlta.Checked = True
                Me.ChkBaja.Checked = False
                Me.ChkModificacion.Checked = False
            Case 5
                Me.ChkAlta.Checked = True
                Me.ChkBaja.Checked = False
                Me.ChkModificacion.Checked = True
            Case 6
                Me.ChkAlta.Checked = True
                Me.ChkBaja.Checked = True
                Me.ChkModificacion.Checked = False
            Case 7
                Me.ChkAlta.Checked = True
                Me.ChkBaja.Checked = True
                Me.ChkModificacion.Checked = True
        End Select
        Me.CmbMenus.Enabled = False
        Me.CmdInsert.Visible = False
        If Permisos = 1 Or Permisos = 3 Or Permisos = 5 Or Permisos = 7 Then
            Me.CmdModify.Visible = True
        Else
            Me.CmdModify.Visible = False
        End If
        If Permisos = 2 Or Permisos = 3 Or Permisos = 6 Or Permisos = 7 Then
            Me.CmdDelete.Visible = True
        Else
            Me.CmdDelete.Visible = False
        End If
        Me.CmdSearch.Visible = False
    End Sub
    Private Sub Buttons_Click(sender As Object, e As EventArgs) Handles CmdDelete.Click, CmdClean.Click, CmdExit.Click, CmdInsert.Click, CmdModify.Click, CmdReport.Click, CmdSearch.Click, CmdNewSearch.Click, CmdRefresh.Click
        Select Case UCase(sender.name)
            Case "CMDINSERT"
                File_Action = "A"
                Update_Process()
            Case "CMDMODIFY"
                File_Action = "M"
                Update_Process()
            Case "CMDDELETE"
                File_Action = "B"
                Update_Process()
            Case "CMDREPORT"
                Emitir_Reporte()
            Case "CMDSEARCH"
                Buscar_Data()
            Case "CMDNEWSEARCH"
                If Me.CrvReporte.Visible = True Then
                    Me.CrvReporte.Visible = False
                Else
                    Tipo_Limpieza = "T"
                    Limpiar_Controles()
                End If
            Case "CMDCLEAN"
                If Me.CrvReporte.Visible = True Then
                    Me.CrvReporte.Visible = False
                Else
                    Tipo_Limpieza = "P"
                    Limpiar_Controles()
                End If
            Case "CMDREFRESH"
                If Me.GridDatos.Visible = True Then
                    Me.listaMenus.MultiColumn = True
                    Me.listaMenus.SelectionMode = SelectionMode.One
                    Me.DictMenus.Clear()
                    Me.CmbMenus.Items.Clear()
                    Me.listaMenus.Items.Clear()
                    Me.CmbMenus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
                    Me.CmbMenus.Sorted = True
                    Me.listaMenus.BeginUpdate()
                    Dim instruccion As String
                    instruccion = "Select IqMenus_Codigo, IqMenus_Descripcion from Iq_Menus order by IqMenus_Codigo"
                    Dim Carga_Coneccion_O0 As New OleDb.OleDbConnection(Cnn_Central_Server)
                    Carga_Coneccion_O0.Open()
                    Dim Carga_Comando_O0 As New OleDb.OleDbCommand(instruccion, Carga_Coneccion_O0)
                    Dim Carga_Reader_O0 As OleDb.OleDbDataReader = Carga_Comando_O0.ExecuteReader(CommandBehavior.CloseConnection)
                    While Carga_Reader_O0.Read
                        Me.listaMenus.Items.Add(Carga_Reader_O0.GetValue(0))
                        Me.listaMenus.Items.Add(Carga_Reader_O0.GetValue(1))
                        Me.CmbMenus.Items.Add(Carga_Reader_O0.GetValue(1))
                    End While
                    Carga_Coneccion_O0.Dispose()
                    Me.CmbMenus.Items.Add("")
                    Me.listaMenus.EndUpdate()
                    Me.CmbMenus.EndUpdate()
                    If Me.listaMenus.Items.Count > 0 Then
                        For Me.counter_lista = 0 To Me.listaMenus.Items.Count - 2 Step 2
                            Me.DictMenus.Add_ColeccionMenus(Me.listaMenus.Items.Item(counter_lista), Me.listaMenus.Items.Item(counter_lista + 1))
                        Next
                    End If
                    Me.CmbMenus.Text = ""
                Else
                    Me.listaMenus.MultiColumn = True
                    Me.listaMenus.SelectionMode = SelectionMode.One
                    Me.DictMenus.Clear()
                    Me.CmbMenus.Items.Clear()
                    Me.listaMenus.Items.Clear()
                    Me.CmbMenus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
                    Me.CmbMenus.Sorted = True
                    Me.listaMenus.BeginUpdate()
                    Dim instruccion As String
                    instruccion = "Select IqMenus_Codigo, IqMenus_Descripcion from Iq_Menus order by IqMenus_Codigo"
                    Dim Carga_Coneccion_O0 As New OleDb.OleDbConnection(Cnn_Central_Server)
                    Carga_Coneccion_O0.Open()
                    Dim Carga_Comando_O0 As New OleDb.OleDbCommand(instruccion, Carga_Coneccion_O0)
                    Dim Carga_Reader_O0 As OleDb.OleDbDataReader = Carga_Comando_O0.ExecuteReader(CommandBehavior.CloseConnection)
                    While Carga_Reader_O0.Read
                        Me.listaMenus.Items.Add(Carga_Reader_O0.GetValue(0))
                        Me.listaMenus.Items.Add(Carga_Reader_O0.GetValue(1))
                        Me.CmbMenus.Items.Add(Carga_Reader_O0.GetValue(1))
                    End While
                    Carga_Coneccion_O0.Dispose()
                    Me.CmbMenus.Items.Add("")
                    Me.listaMenus.EndUpdate()
                    Me.CmbMenus.EndUpdate()
                    If Me.listaMenus.Items.Count > 0 Then
                        For Me.counter_lista = 0 To Me.listaMenus.Items.Count - 2 Step 2
                            Me.DictMenus.Add_ColeccionMenus(Me.listaMenus.Items.Item(counter_lista), Me.listaMenus.Items.Item(counter_lista + 1))
                        Next
                    End If
                    Me.CmbMenus.Text = ""
                    Me.listaroles.MultiColumn = True
                    Me.listaroles.SelectionMode = SelectionMode.One
                    Me.DictRoles.Clear()
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
                    If Me.listaroles.Items.Count > 0 Then
                        For Me.counter_lista = 0 To Me.listaroles.Items.Count - 2 Step 2
                            Me.DictRoles.Add_ColeccionRoles(Me.listaroles.Items.Item(counter_lista), Me.listaroles.Items.Item(counter_lista + 1))
                        Next
                    End If
                    Me.CmbRoles.Text = ""
                End If
            Case "CMDEXIT"
                IQ_C0000.PicFondo.Visible = True
                Me.Dispose()
            Case Else
                MessageBox.Show("Comando no implementado")
        End Select
    End Sub
    Private Sub Emitir_Reporte()
        Dim rptlayout As New ReportDocument
        Try
            rptlayout.Load(Disco_Appl & ":\I-Q\IQ_Rpt\IQ_C0011.rpt")
            rptlayout.SetDatabaseLogon(Server_User, Server_Pwd)
            rptlayout.SummaryInfo.ReportTitle = Nombre_Cliente + Chr(10) + "Reporte de Permisos"
            If Me.CmbRoles.Text <> "" Then
                Me.CrvReporte.SelectionFormula = "{Permisos.IqPerm_Rol} = '" + CodigoRol(Me.CmbRoles.Text) + "'"
            End If
            Me.CrvReporte.ReportSource = rptlayout
            Me.CrvReporte.DisplayToolbar = True
            Me.CrvReporte.ShowCloseButton = False
            Me.CrvReporte.Zoom(1)
            Me.CrvReporte.ShowFirstPage()
            Me.CrvReporte.BringToFront()
            Me.CrvReporte.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            Me.CrvReporte.Visible = True
            'rptlayout.dispose()
        Catch exc As Exception
            Dim Mensaje_Excepcion As String
            Mensaje_Excepcion = exc.Message
            Mensaje_Excepcion = "Error Integrado: " + Mensaje_Excepcion
            MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
End Class