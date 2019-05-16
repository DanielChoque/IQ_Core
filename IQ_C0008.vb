Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine

Public Class IQ_C0008
    Dim Permisos As Integer = 0
    Dim Counter_Lista As Integer = 0
    Protected DatosUsuarios As New DataSet
    Dim listaRoles As New System.Windows.Forms.ListBox
    Dim pwd_modif As Boolean
    Dim pwd_old As String
    Private DictRoles As New ColeccionRoles
    Public Sub New()
        InitializeComponent()
        Dim toolTip1 As New ToolTip()
        toolTip1.AutoPopDelay = 5000
        toolTip1.InitialDelay = 1000
        toolTip1.ReshowDelay = 500
        toolTip1.ShowAlways = True
        toolTip1.SetToolTip(CmdInsert, "Insertar")
        toolTip1.SetToolTip(CmdModify, "Modificar")
        toolTip1.SetToolTip(CmdReport, "Reporte")
        toolTip1.SetToolTip(CmdExit, "Salir")
        toolTip1.SetToolTip(CmdDelete, "Eliminar")
        toolTip1.SetToolTip(CmdClean, "Limpiar")
        toolTip1.SetToolTip(CmdRefresh, "Actualizar Listas")
        toolTip1.SetToolTip(Me.CmbRoles, "Rol asignado al Usuario")
        toolTip1.SetToolTip(Me.TxtCodigo, "Código del Usuario")
        toolTip1.SetToolTip(Me.TxtDescripcion, "Nombre del Usuario")
        toolTip1.SetToolTip(Me.TxtClave, "Password del Usuario")
        toolTip1.SetToolTip(Me.TxtVerif, "Verificación del Password del Usuario")
        toolTip1.SetToolTip(Me.GridDatos, "Usarios ya registrados")
        Timer1.Enabled = True
        Timer1.Start()
        pwd_modif = False
        pwd_old = ""
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
    End Sub
    Private Sub Buttons_Click(sender As Object, e As EventArgs) Handles CmdDelete.Click, CmdClean.Click, CmdExit.Click, CmdInsert.Click, CmdModify.Click, CmdReport.Click, CmdRefresh.Click
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
            Case "CMDCLEAN"
                If Me.CrvReporte.Visible = True Then
                    Me.CrvReporte.Visible = False
                Else
                    Limpiar_Controles()
                End If
            Case "CMDREFRESH"
                Dim instruccion As String
                Me.listaRoles.MultiColumn = True
                Me.listaRoles.SelectionMode = SelectionMode.One
                Me.DictRoles.Clear()
                Me.CmbRoles.Items.Clear()
                Me.listaRoles.Items.Clear()
                Me.CmbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
                Me.CmbRoles.Sorted = True
                Me.listaRoles.BeginUpdate()
                instruccion = "Select IqRoles_Codigo, IqRoles_Descripcion from Iq_Roles order by IqRoles_Codigo"
                Dim Carga_Coneccion_O As New OleDb.OleDbConnection(Cnn_Central_Server)
                Carga_Coneccion_O.Open()
                Dim Carga_Comando_O As New OleDb.OleDbCommand(instruccion, Carga_Coneccion_O)
                Dim Carga_Reader_O As OleDb.OleDbDataReader = Carga_Comando_O.ExecuteReader(CommandBehavior.CloseConnection)
                While Carga_Reader_O.Read
                    Me.listaRoles.Items.Add(Carga_Reader_O.GetValue(0))
                    Me.listaRoles.Items.Add(Carga_Reader_O.GetValue(1))
                    Me.CmbRoles.Items.Add(Carga_Reader_O.GetValue(1))
                End While
                Carga_Coneccion_O.Dispose()
                Me.CmbRoles.Items.Add("")
                Me.listaRoles.EndUpdate()
                Me.CmbRoles.EndUpdate()
                If Me.listaRoles.Items.Count > 0 Then
                    For Me.Counter_Lista = 0 To Me.listaRoles.Items.Count - 2 Step 2
                        Me.DictRoles.Add_ColeccionRoles(Me.listaRoles.Items.Item(Counter_Lista), Me.listaRoles.Items.Item(Counter_Lista + 1))
                    Next
                End If
                Me.CmbRoles.Text = ""
            Case "CMDEXIT"
                IQ_C0000.PicFondo.Visible = True
                Me.Dispose()
            Case Else
                MessageBox.Show("Comando no implementado")
        End Select
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Timer1.Enabled = False
        If InStr(Me.Text, "|") > 0 Then
            Permisos = CInt(Mid(Me.Text, InStr(Me.Text, "|") + 1, 1))
            Me.Text = Mid(Me.Text, 1, InStr(Me.Text, "|") - 1)
        End If
        Limpiar_Controles()
    End Sub
    Private Class ColeccionRoles
        Inherits System.Collections.DictionaryBase

        Public Sub Add_ColeccionRoles(ByVal Key As String, ByVal Item As String)
            Dictionary.Add(Key, Item)
        End Sub

        Public Function Valor(ByVal Key As String) As String
            Valor = Dictionary.Item(Key)
        End Function
    End Class
    Private Function CodigoRol(ByVal Codigo As String) As String
        CodigoRol = ""
        If Me.listaRoles.Items.Count = 0 Then
            CodigoRol = ""
        Else
            For Me.Counter_Lista = 1 To Me.listaRoles.Items.Count - 1 Step 2
                If Trim(Codigo) = Trim(Me.listaRoles.Items.Item(Counter_Lista)) Then
                    CodigoRol = Me.listaRoles.Items.Item(Counter_Lista - 1)
                End If
            Next
        End If
    End Function
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
        End With
        Dim grdTableStyle1 As New DataGridTableStyle
        With grdTableStyle1
            .MappingName = "Iq_Users"
        End With
        Dim grdColStyle1 As New DataGridTextBoxColumn
        With grdColStyle1
            .HeaderText = "Codigo"
            .MappingName = "IqUsers_Codigo"
            .Width = 50
        End With
        Dim grdColStyle2 As New DataGridTextBoxColumn
        With grdColStyle2
            .HeaderText = "Nombre"
            .MappingName = "IqUsers_Nombre"
            .Width = 600
        End With
        Dim grdColStyle3 As New DataGridTextBoxColumn
        With grdColStyle3
            .HeaderText = "Rol"
            .MappingName = "IqUsers_Rol"
            .Width = 80
        End With
        Dim grdColStyle4 As New DataGridTextBoxColumn
        With grdColStyle4
            .HeaderText = "Pwd"
            .MappingName = "IqUsers_Pwd"
            .Width = 0
        End With
        grdTableStyle1.GridColumnStyles.AddRange _
            (New DataGridColumnStyle() _
            {grdColStyle1, grdColStyle2, grdColStyle3, grdColStyle4})
        Me.GridDatos.TableStyles.Add(grdTableStyle1)
    End Sub
    Private Sub Limpiar_Controles()
        Dim instruccion As String
        Me.listaRoles.MultiColumn = True
        Me.listaRoles.SelectionMode = SelectionMode.One
        Me.DictRoles.Clear()
        Me.CmbRoles.Items.Clear()
        Me.listaRoles.Items.Clear()
        Me.CmbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbRoles.Sorted = True
        Me.listaRoles.BeginUpdate()
        instruccion = "Select IqRoles_Codigo, IqRoles_Descripcion from Iq_Roles order by IqRoles_Codigo"
        Dim Carga_Coneccion_O As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O.Open()
        Dim Carga_Comando_O As New OleDb.OleDbCommand(instruccion, Carga_Coneccion_O)
        Dim Carga_Reader_O As OleDb.OleDbDataReader = Carga_Comando_O.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O.Read
            Me.listaRoles.Items.Add(Carga_Reader_O.GetValue(0))
            Me.listaRoles.Items.Add(Carga_Reader_O.GetValue(1))
            Me.CmbRoles.Items.Add(Carga_Reader_O.GetValue(1))
        End While
        Carga_Coneccion_O.Dispose()
        Me.CmbRoles.Items.Add("")
        Me.listaRoles.EndUpdate()
        Me.CmbRoles.EndUpdate()
        If Me.listaRoles.Items.Count > 0 Then
            For Me.Counter_Lista = 0 To Me.listaRoles.Items.Count - 2 Step 2
                Me.DictRoles.Add_ColeccionRoles(Me.listaRoles.Items.Item(Counter_Lista), Me.listaRoles.Items.Item(Counter_Lista + 1))
            Next
        End If
        Me.CmbRoles.Text = ""
        If Not IsNothing(DatosUsuarios.Tables("Iq_Users")) Then
            DatosUsuarios.Tables("Iq_Users").Clear()
        End If
        With Me.GridDatos
            .TableStyles.Clear()
        End With
        Dim SeConecta As Boolean = True
        While SeConecta
            Try
                Dim CnnConceptos As New OleDb.OleDbConnection(Cnn_Central_Server)
                Dim AdapterConceptos As New OleDbDataAdapter("select * from Iq_Users order by IqUsers_Codigo", CnnConceptos)
                DatosUsuarios.Clear()
                AdapterConceptos.Fill(DatosUsuarios, "Iq_Users")
                Me.GridDatos.DataSource = DatosUsuarios.Tables("Iq_Users")
                SeConecta = False
            Catch exc As Exception
                MessageBox.Show(exc.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.Dispose()
                Exit Sub
            End Try
        End While
        Formatea_Grid()
        Me.GridDatos.Visible = True
        Me.TxtCodigo.Enabled = True
        Me.TxtCodigo.Text = ""
        Me.TxtDescripcion.Text = ""
        Me.TxtVerif.Text = ""
        Me.TxtClave.Text = ""
        Me.CrvReporte.Visible = False
        If Permisos >= 4 Then
            Me.CmdInsert.Visible = True
        Else
            Me.CmdInsert.Visible = False
        End If
        pwd_modif = False
        pwd_old = ""
        Me.CmdReport.Visible = True
        Me.CmdModify.Visible = False
        Me.CmdDelete.Visible = False
        Me.TxtCodigo.Focus()
    End Sub
    Private Sub GridDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDatos.DoubleClick
        If Me.GridDatos.VisibleRowCount = 0 Then
            Exit Sub
        End If
        Me.TxtCodigo.Text = Me.GridDatos.Item(Me.GridDatos.CurrentCell.RowNumber, 0)
        Me.TxtDescripcion.Text = Me.GridDatos.Item(Me.GridDatos.CurrentCell.RowNumber, 1)
        Me.CmbRoles.Text = DictRoles.Valor(Me.GridDatos.Item(Me.GridDatos.CurrentCell.RowNumber, 2))
        pwd_modif = False
        pwd_old = Me.GridDatos.Item(Me.GridDatos.CurrentCell.RowNumber, 3)
        Me.TxtClave.Text = Me.GridDatos.Item(Me.GridDatos.CurrentCell.RowNumber, 3)
        Me.TxtVerif.Text = Me.GridDatos.Item(Me.GridDatos.CurrentCell.RowNumber, 3)
        Me.TxtCodigo.Enabled = False
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
    End Sub
    Private Sub Emitir_Reporte()
        Dim rptlayout As New ReportDocument
        Try
            rptlayout.Load(Disco_Appl & ":\I-Q\IQ_Rpt\IQ_C0008.rpt")
            rptlayout.SetDatabaseLogon(Server_User, Server_Pwd)
            rptlayout.SummaryInfo.ReportTitle = Nombre_Cliente + Chr(10) + "Definición de Usuarios"
            Me.CrvReporte.ReportSource = rptlayout
            Me.CrvReporte.DisplayToolbar = True
            Me.CrvReporte.ShowCloseButton = False
            Me.CrvReporte.Zoom(1)
            Me.CrvReporte.ShowFirstPage()
            Me.CrvReporte.BringToFront()
            Me.CrvReporte.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            Me.CrvReporte.Visible = True
            '            rptlayout.Dispose()
        Catch exc As Exception
            Dim Mensaje_Excepcion As String
            Mensaje_Excepcion = exc.Message
            MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Update_Process()
        If Trim(Me.TxtCodigo.Text) = "" Then
            MessageBox.Show("Debe registrar el Codigo del Usuario", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.TxtCodigo.Focus()
            Exit Sub
        End If
        If IsNumeric(Me.TxtCodigo.Text) = False Then
            MessageBox.Show("El Codigo del Usuario debe ser numérico", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.TxtCodigo.Focus()
            Exit Sub
        End If
        If CDbl(Me.TxtCodigo.Text) < 0 Then
            MessageBox.Show("El Codigo del Usuario no puede ser negativo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.TxtCodigo.Focus()
            Exit Sub
        End If
        If Trim(Me.TxtDescripcion.Text) = "" Then
            MessageBox.Show("Debe registrar el Nombre del Usuario", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.TxtDescripcion.Focus()
            Exit Sub
        End If
        If Trim(Me.CmbRoles.Text) = "" Then
            MessageBox.Show("Debe registrar el Rol del Usuario", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.CmbRoles.Focus()
            Exit Sub
        End If
        If Trim(Me.TxtClave.Text) = "" Then
            MessageBox.Show("Debe registrar la Clave de Acceso o Password del Usuario", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.TxtClave.Focus()
            Exit Sub
        End If
        If Trim(Me.TxtVerif.Text) = "" Then
            MessageBox.Show("Debe verificar la Clave de Acceso o Password del Usuario", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.TxtVerif.Focus()
            Exit Sub
        End If
        If Me.TxtClave.Text <> Me.TxtVerif.Text Then
            MessageBox.Show("La Clave no coincide con su Verificación", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.TxtClave.Focus()
            Exit Sub
        End If
        Select Case File_Action
            Case "A"
                Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
                Try
                    IQ_Cnn.Open()
                    Dim IQ_Cmm As New OleDb.OleDbCommand("Insert Into Iq_Users Values(" + Me.TxtCodigo.Text + ", '" + Me.TxtDescripcion.Text + "', '" & CodigoRol(Me.CmbRoles.Text) & "', '" & IQ_Security.Encriptado(Me.TxtClave.Text) & "')", IQ_Cnn)
                    Dim RegistrosInsertados As Long = IQ_Cmm.ExecuteNonQuery()
                    IQ_Cnn.Close()
                    MessageBox.Show(RegistrosInsertados.ToString + " Registro(s) fueron insertados satisfactoriamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch exc As Exception
                    Dim Mensaje_Excepcion As String
                    Mensaje_Excepcion = exc.Message
                    If InStr(UCase(exc.Message), "PRIMARY KEY") > 0 Then
                        MessageBox.Show("EL CODIGO DE USUARIO INGRESADO YA EXISTE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                    MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End Try
            Case "M"
                Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
                Try
                    IQ_Cnn.Open()
                    Dim pwd_insert As String
                    If Me.TxtClave.Text <> pwd_old Then
                        pwd_modif = True
                    Else
                        pwd_modif = False
                    End If
                    If pwd_modif = False Then
                        pwd_insert = Me.TxtClave.Text
                    Else
                        pwd_insert = IQ_Security.Encriptado(Me.TxtClave.Text)
                    End If
                    Dim IQ_Cmm As New OleDb.OleDbCommand("Update Iq_Users Set IqUsers_Nombre = '" + Me.TxtDescripcion.Text + "', IqUsers_Rol = '" & CodigoRol(Me.CmbRoles.Text) & "', IqUsers_Pwd = '" & pwd_insert & "' Where IqUsers_Codigo = " + Me.TxtCodigo.Text, IQ_Cnn)
                    Dim RegistrosModificados As Long = IQ_Cmm.ExecuteNonQuery()
                    IQ_Cnn.Close()
                    MessageBox.Show(RegistrosModificados.ToString + " Registro(s) fueron modificados satisfactoriamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch exc As Exception
                    Dim Mensaje_Excepcion As String
                    Mensaje_Excepcion = exc.Message
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
                    Dim inst_del As String = ""
                    inst_del = "Delete Iq_Users Where IqUsers_Codigo = " + Me.TxtCodigo.Text
                    Dim IQ_Cmm As New OleDb.OleDbCommand(inst_del, IQ_Cnn)
                    Dim RegistrosEliminados As Long = IQ_Cmm.ExecuteNonQuery()
                    IQ_Cnn.Close()
                    MessageBox.Show(RegistrosEliminados.ToString + " Registro(s) fueron eliminados satisfactoriamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch exc As Exception
                    Dim Mensaje_Excepcion As String
                    Mensaje_Excepcion = exc.Message
                    If InStr(UCase(exc.Message), "REFERENCE CONSTRAINT") > 0 Then
                        MessageBox.Show("EL REGISTRO NO PUEDE SER ELIMINADO PORQUE TIENE INFORMACION DEPENDIENTE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                    MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End Try
        End Select
        Limpiar_Controles()
    End Sub
End Class