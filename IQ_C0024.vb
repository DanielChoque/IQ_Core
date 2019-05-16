Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Text.RegularExpressions

Public Class IQ_C0024
    Dim Permisos As Integer = 0
    Dim Counter_Lista As Integer = 0
    Dim cod_ticket As String
    Dim Cod_Tipo As Integer = 0
    Protected DatosTipTram As New DataSet

    Public Sub New()
        Try
            InitializeComponent()
            Dim toolTip1 As New ToolTip()
            toolTip1.AutoPopDelay = 5000
            toolTip1.InitialDelay = 1000
            toolTip1.ReshowDelay = 500
            toolTip1.ShowAlways = True
            toolTip1.SetToolTip(CmdInsert, "Insertar")
            toolTip1.SetToolTip(CmdModify, "Modificar")
            toolTip1.SetToolTip(CmdExit, "Salir")
            toolTip1.SetToolTip(CmdDelete, "Eliminar")
            toolTip1.SetToolTip(CmdClean, "Limpiar")
            toolTip1.SetToolTip(Me.TxtDescripcion, "Descripción del Tipo de Trámite")
            toolTip1.SetToolTip(Me.GridDatos, "Tipos de Tramite ya definidos")
            Timer1.Enabled = True
            Timer1.Start()
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
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Timer1.Enabled = False
        Dim text_aux As String = Me.Text
        Dim pos1 As Integer
        pos1 = InStr(text_aux, "|")
        If pos1 > 0 Then
            Me.Text = Mid(text_aux, 1, pos1 - 1)
            text_aux = Mid(text_aux, pos1 + 1, Len(text_aux) - pos1)
        End If
        pos1 = InStr(text_aux, "|")
        If pos1 > 0 Then
            Permisos = CInt(Mid(text_aux, 1, pos1 - 1))
            text_aux = Mid(text_aux, pos1 + 1, Len(text_aux) - pos1)
        End If
        pos1 = InStr(text_aux, "|")
        If pos1 > 0 Then
            cod_ticket = Trim(Mid(text_aux, 1, pos1 - 1))
            text_aux = Mid(text_aux, pos1 + 1, Len(text_aux) - pos1)
        End If
        Me.LblArea.Text = Trim(text_aux)
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
        buscar_data()
    End Sub
    Private Sub Buttons_Click(sender As Object, e As EventArgs) Handles CmdDelete.Click, CmdClean.Click, CmdExit.Click, CmdInsert.Click, CmdModify.Click
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
            Case "CMDCLEAN"
                Limpiar_Controles()
            Case "CMDEXIT"
                Me.Dispose()
            Case Else
                MessageBox.Show("Comando no implementado")
        End Select
    End Sub
    Private Sub Limpiar_Controles()
        Buscar_Data()
    End Sub
    Private Sub Buscar_Data()
        If Not IsNothing(DatosTipTram.Tables("Iq_TipTram")) Then
            DatosTipTram.Tables("Iq_TipTram").Clear()
        End If
        With Me.GridDatos
            .TableStyles.Clear()
        End With
        Dim SeConecta As Boolean = True
        While SeConecta
            Try
                Dim CnnConceptos As New OleDb.OleDbConnection(Cnn_Central_Server)
                Dim AdapterConceptos As New OleDbDataAdapter("select * from Iq_TipTram where IqTipTram_Ticket = '" & cod_ticket & "' order by IQTipTram_Codigo", CnnConceptos)
                DatosTipTram.Clear()
                AdapterConceptos.Fill(DatosTipTram, "Iq_TipTram")
                Me.GridDatos.DataSource = DatosTipTram.Tables("Iq_TipTram")
                SeConecta = False
            Catch exc As Exception
                MessageBox.Show(exc.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.Dispose()
                Exit Sub
            End Try
        End While
        Formatea_Grid()
        Me.GridDatos.Visible = True
        Cod_Tipo = 0
        Me.TxtDescripcion.Text = ""
        If Permisos >= 4 Then
            Me.CmdInsert.Visible = True
        Else
            Me.CmdInsert.Visible = False
        End If
        Me.CmdModify.Visible = False
        Me.CmdDelete.Visible = False
        Me.TxtDescripcion.Focus()
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
            .MappingName = "Iq_TipTram"
        End With
        Dim grdColStyle1 As New DataGridTextBoxColumn
        With grdColStyle1
            .HeaderText = "Codigo"
            .MappingName = "IqTipTram_Codigo"
            .Width = 0
        End With
        Dim grdColStyle2 As New DataGridTextBoxColumn
        With grdColStyle2
            .HeaderText = "Descripcion"
            .MappingName = "IqTipTram_Descripcion"
            .Width = 600
        End With
        grdTableStyle1.GridColumnStyles.AddRange _
             (New DataGridColumnStyle() _
             {grdColStyle1, grdColStyle2})
        Me.GridDatos.TableStyles.Add(grdTableStyle1)
    End Sub
    Private Sub GridDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDatos.DoubleClick
        If Me.GridDatos.VisibleRowCount = 0 Then
            Exit Sub
        End If
        Cod_Tipo = Me.GridDatos.Item(Me.GridDatos.CurrentCell.RowNumber, 0)
        Me.TxtDescripcion.Text = Me.GridDatos.Item(Me.GridDatos.CurrentCell.RowNumber, 1)
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
    Private Sub Update_Process()
        If Trim(Me.TxtDescripcion.Text) = "" Then
            MessageBox.Show("Debe registrar la Descripción del Tipo de Tramite", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.TxtDescripcion.Focus()
            Exit Sub
        End If
        Select Case File_Action
            Case "A"
                Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
                Try
                    IQ_Cnn.Open()
                    Dim IQ_Cmm As New OleDb.OleDbCommand("Insert Into Iq_TipTram (IQTipTram_Ticket, IQTipTram_Descripcion)  Values('" + cod_ticket + "', '" + Me.TxtDescripcion.Text + "')", IQ_Cnn)
                    Dim RegistrosInsertados As Long = IQ_Cmm.ExecuteNonQuery()
                    IQ_Cnn.Close()
                    MessageBox.Show(RegistrosInsertados.ToString + " Registro(s) fueron insertados satisfactoriamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch exc As Exception
                    Dim Mensaje_Excepcion As String
                    Mensaje_Excepcion = exc.Message
                    MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End Try
            Case "M"
                Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
                Try
                    IQ_Cnn.Open()
                    Dim IQ_Cmm As New OleDb.OleDbCommand("Update Iq_TipTram Set IQTipTram_Descripcion = '" + Me.TxtDescripcion.Text + "' where IQTipTram_Codigo = " + CStr(Cod_Tipo), IQ_Cnn)
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
                    inst_del = "Delete Iq_TipTram where IQTipTram_Codigo = " + CStr(Cod_Tipo)
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