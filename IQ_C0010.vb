Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine

Public Class IQ_C0010
    Dim Permisos As Integer = 0
    Dim Counter_Lista As Integer = 0
    Protected DatosUsuarios As New DataSet
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
        toolTip1.SetToolTip(CmdReport, "Reporte")
        toolTip1.SetToolTip(CmdExit, "Salir")
        toolTip1.SetToolTip(CmdDelete, "Eliminar")
        toolTip1.SetToolTip(CmdClean, "Limpiar")
        toolTip1.SetToolTip(CmdRefresh, "Actualizar Listas")
        toolTip1.SetToolTip(Me.CmbMenus, "Menú al que corresponde la Opción")
        toolTip1.SetToolTip(Me.TxtForm, "Formulario al que llama la Opción")
        toolTip1.SetToolTip(Me.TxtCodigo, "Código de la Opción")
        toolTip1.SetToolTip(Me.TxtDescripcion, "Descripción de la Opción")
        toolTip1.SetToolTip(Me.TxtImagen, "Imagen de la Opción")
        toolTip1.SetToolTip(Me.txtParameter, "Parámetro a pasar al Formulario")
        toolTip1.SetToolTip(Me.TxtToolTip, "Mensaje de la ayuda emergente de la opción")
        toolTip1.SetToolTip(Me.ChkButton, "la Opción tiene Botón de Acceso Directo")
        toolTip1.SetToolTip(Me.GridDatos, "Menús ya registrados")
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
        Limpiar_Controles()
    End Sub
    Private Sub GridDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDatos.DoubleClick
        If Me.GridDatos.VisibleRowCount = 0 Then
            Exit Sub
        End If
        Me.TxtCodigo.Text = Me.GridDatos.Item(Me.GridDatos.CurrentCell.RowNumber, 0)
        Me.TxtDescripcion.Text = Me.GridDatos.Item(Me.GridDatos.CurrentCell.RowNumber, 1)
        Me.CmbMenus.Text = DictMenus.Valor(Me.GridDatos.Item(Me.GridDatos.CurrentCell.RowNumber, 2))
        Me.TxtToolTip.Text = Me.GridDatos.Item(Me.GridDatos.CurrentCell.RowNumber, 3)
        If IsDBNull(Me.GridDatos.Item(Me.GridDatos.CurrentCell.RowNumber, 4)) Then
            Me.TxtImagen.Text = ""
        Else
            Me.TxtImagen.Text = Me.GridDatos.Item(Me.GridDatos.CurrentCell.RowNumber, 4)
        End If
        If Me.GridDatos.Item(Me.GridDatos.CurrentCell.RowNumber, 5) = True Then
            Me.ChkButton.Checked = True
        Else
            Me.ChkButton.Checked = False
        End If
        If IsDBNull(Me.GridDatos.Item(Me.GridDatos.CurrentCell.RowNumber, 6)) Then
            Me.TxtForm.Text = ""
        Else
            Me.TxtForm.Text = Me.GridDatos.Item(Me.GridDatos.CurrentCell.RowNumber, 6)
        End If
        If IsDBNull(Me.GridDatos.Item(Me.GridDatos.CurrentCell.RowNumber, 7)) Then
            Me.txtParameter.Text = ""
        Else
            Me.txtParameter.Text = Me.GridDatos.Item(Me.GridDatos.CurrentCell.RowNumber, 7)
        End If
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
    Private Class ColeccionMenus
        Inherits System.Collections.DictionaryBase

        Public Sub Add_ColeccionMenus(ByVal Key As String, ByVal Item As String)
            Dictionary.Add(Key, Item)
        End Sub

        Public Function Valor(ByVal Key As String) As String
            Valor = Dictionary.Item(Key)
        End Function
    End Class
    Private Function CodigoMenu(ByVal Codigo As String) As String
        CodigoMenu = ""
        If Me.listaMenus.Items.Count = 0 Then
            CodigoMenu = ""
        Else
            For Me.Counter_Lista = 1 To Me.listaMenus.Items.Count - 1 Step 2
                If Trim(Codigo) = Trim(Me.listaMenus.Items.Item(Counter_Lista)) Then
                    CodigoMenu = Me.listaMenus.Items.Item(Counter_Lista - 1)
                End If
            Next
        End If
    End Function
    Private Sub Emitir_Reporte()
        Dim rptlayout As New ReportDocument
        Try
            rptlayout.Load(Disco_Appl & ":\I-Q\IQ_Rpt\IQ_C0010.rpt")
            rptlayout.SetDatabaseLogon(Server_User, Server_Pwd)
            rptlayout.SummaryInfo.ReportTitle = Nombre_Cliente + Chr(10) + "Definición de Menús"
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
            MessageBox.Show("Debe registrar el Codigo de la Opción", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.TxtCodigo.Focus()
            Exit Sub
        End If
        If Trim(Me.TxtDescripcion.Text) = "" Then
            MessageBox.Show("Debe registrar la Descripción de la Opción", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.TxtDescripcion.Focus()
            Exit Sub
        End If
        If Trim(Me.CmbMenus.Text) = "" Then
            MessageBox.Show("Debe registrar el Menú de la Opción", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.CmbMenus.Focus()
            Exit Sub
        End If
        If Trim(Me.TxtToolTip.Text) = "" Then
            MessageBox.Show("Debe registrar el Mensaje Emergente de la Opción", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.TxtToolTip.Focus()
            Exit Sub
        End If
        Select Case File_Action
            Case "A"
                Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
                Try
                    IQ_Cnn.Open()
                    Dim instruccion_insert As String = "Insert into Iq_Menus Values('" + Me.TxtCodigo.Text + "', '" + Me.TxtDescripcion.Text + "', '" & CodigoMenu(Me.CmbMenus.Text) & "', '" & Me.TxtToolTip.Text & "', "
                    If Me.TxtImagen.Text = "" Then
                        instruccion_insert = instruccion_insert & "null, "
                    Else
                        instruccion_insert = instruccion_insert & "'" & Me.TxtImagen.Text & "', "
                    End If
                    If Me.ChkButton.Checked = True Then
                        instruccion_insert = instruccion_insert & "1, "
                    Else
                        instruccion_insert = instruccion_insert & "0, "
                    End If
                    If Me.TxtForm.Text = "" Then
                        instruccion_insert = instruccion_insert & "null, "
                    Else
                        instruccion_insert = instruccion_insert & "'" & Me.TxtForm.Text & "', "
                    End If
                    If Me.txtParameter.Text = "" Then
                        instruccion_insert = instruccion_insert & "null)"
                    Else
                        instruccion_insert = instruccion_insert & "'" & Me.txtParameter.Text & "')"
                    End If
                    Dim IQ_Cmm As New OleDb.OleDbCommand(instruccion_insert, IQ_Cnn)
                    Dim RegistrosInsertados As Long = IQ_Cmm.ExecuteNonQuery()
                    IQ_Cnn.Close()
                    MessageBox.Show(RegistrosInsertados.ToString + " Registro(s) fueron insertados satisfactoriamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch exc As Exception
                    Dim Mensaje_Excepcion As String
                    Mensaje_Excepcion = exc.Message
                    If InStr(UCase(exc.Message), "PRIMARY KEY") > 0 Then
                        MessageBox.Show("EL CODIGO DE MENU O TRANSACCION INGRESADO YA EXISTE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                    MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End Try
            Case "M"
                Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
                Try
                    IQ_Cnn.Open()
                    Dim instruccion_insert As String = "Update Iq_Menus set IqMenus_Descripcion = '" + Me.TxtDescripcion.Text + "', IqMenus_Menu = '" & CodigoMenu(Me.CmbMenus.Text) & "', IqMenus_Tooltip = '" & Me.TxtToolTip.Text & "', "
                    If Me.TxtImagen.Text = "" Then
                        instruccion_insert = instruccion_insert & "IqMenus_IMage = null, "
                    Else
                        instruccion_insert = instruccion_insert & "IqMenus_Image = '" & Me.TxtImagen.Text & "', "
                    End If
                    If Me.ChkButton.Checked = True Then
                        instruccion_insert = instruccion_insert & "IqMenus_Button = 1, "
                    Else
                        instruccion_insert = instruccion_insert & "IqMenus_Button = 0, "
                    End If
                    If Me.TxtForm.Text = "" Then
                        instruccion_insert = instruccion_insert & "IqMenus_Form = null, "
                    Else
                        instruccion_insert = instruccion_insert & "IqMenus_Form = '" & Me.TxtForm.Text & "', "
                    End If
                    If Me.txtParameter.Text = "" Then
                        instruccion_insert = instruccion_insert & "IqMenus_Parameter = null "
                    Else
                        instruccion_insert = instruccion_insert & "IqMenus_Parameter = '" & Me.txtParameter.Text & "' "
                    End If
                    instruccion_insert = instruccion_insert & " Where IqMenus_Codigo = '" + Me.TxtCodigo.Text & "'"
                    Dim IQ_Cmm As New OleDb.OleDbCommand(instruccion_insert, IQ_Cnn)
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
                    inst_del = "Delete Iq_Menus Where IqMenus_Codigo = '" + Me.TxtCodigo.Text & "'"
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
                Me.listaMenus.MultiColumn = True
                Me.listaMenus.SelectionMode = SelectionMode.One
                Me.DictMenus.Clear()
                Me.CmbMenus.Items.Clear()
                Me.listaMenus.Items.Clear()
                Me.CmbMenus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
                Me.CmbMenus.Sorted = True
                Me.listaMenus.BeginUpdate()
                instruccion = "Select IqMenus_Codigo, IqMenus_Descripcion from Iq_Menus where IqMenus_Form is null order by IqMenus_Codigo"
                Dim Carga_Coneccion_O As New OleDb.OleDbConnection(Cnn_Central_Server)
                Carga_Coneccion_O.Open()
                Dim Carga_Comando_O As New OleDb.OleDbCommand(instruccion, Carga_Coneccion_O)
                Dim Carga_Reader_O As OleDb.OleDbDataReader = Carga_Comando_O.ExecuteReader(CommandBehavior.CloseConnection)
                While Carga_Reader_O.Read
                    Me.listaMenus.Items.Add(Carga_Reader_O.GetValue(0))
                    Me.listaMenus.Items.Add(Carga_Reader_O.GetValue(1) & " - " & Carga_Reader_O.GetValue(0))
                    Me.CmbMenus.Items.Add(Carga_Reader_O.GetValue(1) & " - " & Carga_Reader_O.GetValue(0))
                End While
                Carga_Coneccion_O.Dispose()
                Me.listaMenus.Items.Add("Root")
                Me.listaMenus.Items.Add(" Menú Raíz")
                Me.CmbMenus.Items.Add(" Menú Raíz")
                Me.listaMenus.Items.Add("Form")
                Me.listaMenus.Items.Add(" Directo desde Formulario")
                Me.CmbMenus.Items.Add(" Directo desde Formulario")
                Me.CmbMenus.Items.Add("")
                Me.listaMenus.EndUpdate()
                Me.CmbMenus.EndUpdate()
                If Me.listaMenus.Items.Count > 0 Then
                    For Me.Counter_Lista = 0 To Me.listaMenus.Items.Count - 2 Step 2
                        Me.DictMenus.Add_ColeccionMenus(Me.listaMenus.Items.Item(Counter_Lista), Me.listaMenus.Items.Item(Counter_Lista + 1))
                    Next
                End If
                Me.CmbMenus.Text = ""
            Case "CMDEXIT"
                IQ_C0000.PicFondo.Visible = True
                Me.Dispose()
            Case Else
                MessageBox.Show("Comando no implementado")
        End Select
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
        End With
        Dim grdTableStyle1 As New DataGridTableStyle
        With grdTableStyle1
            .MappingName = "Iq_Menus"
        End With
        Dim grdColStyle1 As New DataGridTextBoxColumn
        With grdColStyle1
            .HeaderText = "Codigo"
            .MappingName = "IqMenus_Codigo"
            .Width = 50
        End With
        Dim grdColStyle2 As New DataGridTextBoxColumn
        With grdColStyle2
            .HeaderText = "Descripción"
            .MappingName = "IqMenus_Descripcion"
            .Width = 600
        End With
        Dim grdColStyle3 As New DataGridTextBoxColumn
        With grdColStyle3
            .HeaderText = "Menú"
            .MappingName = "IqMenus_Menu"
            .Width = 80
        End With
        Dim grdColStyle4 As New DataGridTextBoxColumn
        With grdColStyle4
            .HeaderText = "ToolTip"
            .MappingName = "IqMenus_Tooltip"
            .Width = 200
        End With
        Dim grdColStyle5 As New DataGridTextBoxColumn
        With grdColStyle5
            .HeaderText = "Imagen"
            .MappingName = "IqMenus_Image"
            .Width = 100
        End With
        Dim grdColStyle6 As New DataGridTextBoxColumn
        With grdColStyle6
            .HeaderText = "Botón"
            .MappingName = "IqMenus_Button"
            .Width = 50
        End With
        Dim grdColStyle7 As New DataGridTextBoxColumn
        With grdColStyle7
            .HeaderText = "Formulario"
            .MappingName = "IqMenus_Form"
            .Width = 100
        End With
        Dim grdColStyle8 As New DataGridTextBoxColumn
        With grdColStyle8
            .HeaderText = "Parámetro"
            .MappingName = "IqMenus_Parameter"
            .Width = 100
        End With
        grdTableStyle1.GridColumnStyles.AddRange _
             (New DataGridColumnStyle() _
             {grdColStyle1, grdColStyle2, grdColStyle3, grdColStyle4, grdColStyle5, grdColStyle6, grdColStyle7, grdColStyle8})
        Me.GridDatos.TableStyles.Add(grdTableStyle1)
    End Sub
    Private Sub Limpiar_Controles()
        Dim instruccion As String
        Me.listaMenus.MultiColumn = True
        Me.listaMenus.SelectionMode = SelectionMode.One
        Me.DictMenus.Clear()
        Me.CmbMenus.Items.Clear()
        Me.listaMenus.Items.Clear()
        Me.CmbMenus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMenus.Sorted = True
        Me.listaMenus.BeginUpdate()
        instruccion = "Select IqMenus_Codigo, IqMenus_Descripcion from Iq_Menus where IqMenus_Form is null order by IqMenus_Codigo"
        Dim Carga_Coneccion_O As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O.Open()
        Dim Carga_Comando_O As New OleDb.OleDbCommand(instruccion, Carga_Coneccion_O)
        Dim Carga_Reader_O As OleDb.OleDbDataReader = Carga_Comando_O.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O.Read
            Me.listaMenus.Items.Add(Carga_Reader_O.GetValue(0))
            Me.listaMenus.Items.Add(Carga_Reader_O.GetValue(1) & " - " & Carga_Reader_O.GetValue(0))
            Me.CmbMenus.Items.Add(Carga_Reader_O.GetValue(1) & " - " & Carga_Reader_O.GetValue(0))
        End While
        Carga_Coneccion_O.Dispose()
        Me.listaMenus.Items.Add("Root")
        Me.listaMenus.Items.Add(" Menú Raíz")
        Me.CmbMenus.Items.Add(" Menú Raíz")
        Me.listaMenus.Items.Add("Form")
        Me.listaMenus.Items.Add(" Directo desde Formulario")
        Me.CmbMenus.Items.Add(" Directo desde Formulario")
        Me.CmbMenus.Items.Add("")
        Me.listaMenus.EndUpdate()
        Me.CmbMenus.EndUpdate()
        If Me.listaMenus.Items.Count > 0 Then
            For Me.Counter_Lista = 0 To Me.listaMenus.Items.Count - 2 Step 2
                Me.DictMenus.Add_ColeccionMenus(Me.listaMenus.Items.Item(Counter_Lista), Me.listaMenus.Items.Item(Counter_Lista + 1))
            Next
        End If
        Me.CmbMenus.Text = ""
        If Not IsNothing(DatosUsuarios.Tables("Iq_Menus")) Then
            DatosUsuarios.Tables("Iq_Menus").Clear()
        End If
        With Me.GridDatos
            .TableStyles.Clear()
        End With
        Dim SeConecta As Boolean = True
        While SeConecta
            Try
                Dim CnnConceptos As New OleDb.OleDbConnection(Cnn_Central_Server)
                Dim AdapterConceptos As New OleDbDataAdapter("select * from Iq_Menus order by IqMenus_Codigo", CnnConceptos)
                DatosUsuarios.Clear()
                AdapterConceptos.Fill(DatosUsuarios, "Iq_Menus")
                Me.GridDatos.DataSource = DatosUsuarios.Tables("Iq_Menus")
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
        Me.TxtForm.Text = ""
        Me.TxtImagen.Text = ""
        Me.txtParameter.Text = ""
        Me.TxtToolTip.Text = ""
        Me.ChkButton.Checked = False
        Me.CrvReporte.Visible = False
        If Permisos >= 4 Then
            Me.CmdInsert.Visible = True
        Else
            Me.CmdInsert.Visible = False
        End If
        Me.CmdReport.Visible = True
        Me.CmdModify.Visible = False
        Me.CmdDelete.Visible = False
        Me.TxtCodigo.Focus()
    End Sub
End Class