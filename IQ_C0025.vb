Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Text.RegularExpressions

Public Class IQ_C0025
    Dim Permisos As Integer = 0
    Dim Counter_Lista As Integer = 0
    Dim cod_area As String
    Dim cupo_file(7) As String
    Dim capacidad_file(7) As String
    Dim ColumnaHora As New DataColumn
    Dim ColumnaLunes As New DataColumn
    Dim ColumnaMartes As New DataColumn
    Dim ColumnaMiercoles As New DataColumn
    Dim ColumnaJueves As New DataColumn
    Dim ColumnaViernes As New DataColumn
    Dim ColumnaSabado As New DataColumn
    Dim ColumnaDomingo As New DataColumn
    Dim TablaCap As New DataTable
    Dim ColumnaCupoLunes As New DataColumn
    Dim ColumnaCupoMartes As New DataColumn
    Dim ColumnaCupoMiercoles As New DataColumn
    Dim ColumnaCupoJueves As New DataColumn
    Dim ColumnaCupoViernes As New DataColumn
    Dim ColumnaCupoSabado As New DataColumn
    Dim ColumnaCupoDomingo As New DataColumn
    Dim TablaCupo As New DataTable

    Dim Cod_Tipo As Integer = 0
    Protected DatosTipTram As New DataSet


    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles CmdExit.Click
        IQ_C0000.PicFondo.Visible = True
        Me.Dispose()
    End Sub
    Public Sub New()
        Try
            InitializeComponent()
            Dim toolTip1 As New ToolTip()
            toolTip1.AutoPopDelay = 5000
            toolTip1.InitialDelay = 1000
            toolTip1.ReshowDelay = 500
            toolTip1.ShowAlways = True
            toolTip1.SetToolTip(CmdInsert, "Grabar")
            toolTip1.SetToolTip(CmdExit, "Salir")
            toolTip1.SetToolTip(CmdClean, "Limpiar")
            AddHandler TablaCap.ColumnChanging, AddressOf Cap_ColumnChanging
            AddHandler TablaCupo.ColumnChanging, AddressOf Cupo_ColumnChanging
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
            cod_area = CInt(Mid(text_aux, 1, pos1 - 1))
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
        Buscar_Data()
    End Sub
    Private Sub Buttons_Click(sender As Object, e As EventArgs) Handles CmdClean.Click, CmdExit.Click, CmdInsert.Click
        Select Case UCase(sender.name)
            Case "CMDINSERT"
                Update_Process()
            Case "CMDCLEAN"
                Limpiar_Controles()
            Case "CMDEXIT"
                IQ_C0000.PicFondo.Visible = True
                Me.Dispose()
            Case Else
                MessageBox.Show("Comando no implementado")
        End Select
    End Sub
    Private Sub Limpiar_Controles()
        Buscar_Data()
    End Sub
    Private Sub Formatea_Grid_Cap()
        With Me.GridCap
            .TableStyles.Clear()
        End With
        TablaCap.Columns.Clear()
        TablaCap.Rows.Clear()
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
        TablaCap.Columns.Add(ColumnaHora)
        TablaCap.Columns.Add(ColumnaLunes)
        TablaCap.Columns.Add(ColumnaMartes)
        TablaCap.Columns.Add(ColumnaMiercoles)
        TablaCap.Columns.Add(ColumnaJueves)
        TablaCap.Columns.Add(ColumnaViernes)
        TablaCap.Columns.Add(ColumnaSabado)
        TablaCap.Columns.Add(ColumnaDomingo)
        TablaCap.DefaultView.AllowNew = False
        Dim fila As DataRow
        Dim hora_ant As Date
        Dim hora As Date
        Dim fecha_orig As Date = hora
        Dim fecha_act As Date = hora
        Dim indice_string As Integer = 1
        Do While Format(fecha_act, "yyyy/MM/dd") = Format(fecha_orig, "yyyy/MM/dd")
            hora_ant = hora
            If Format(hora, "HH:mm") < "05:00" Or Format(hora, "HH:mm") >= "21:00" Then
                hora = DateAdd(DateInterval.Minute, 60, hora)
            ElseIf Format(hora, "HH:mm") < "07:00" Or Format(hora, "HH:mm") >= "19:00" Then
                hora = DateAdd(DateInterval.Minute, 30, hora)
            Else
                hora = DateAdd(DateInterval.Minute, 15, hora)
            End If
            fila = TablaCap.NewRow
            fila("Hora") = Format(hora_ant, "HH:mm") & " - " & Format(hora, "HH:mm")
            fila("Lunes") = Mid(capacidad_file(0), indice_string, 3)
            fila("Martes") = Mid(capacidad_file(1), indice_string, 3)
            fila("Miercoles") = Mid(capacidad_file(2), indice_string, 3)
            fila("Jueves") = Mid(capacidad_file(3), indice_string, 3)
            fila("Viernes") = Mid(capacidad_file(4), indice_string, 3)
            fila("Sabado") = Mid(capacidad_file(5), indice_string, 3)
            fila("Domingo") = Mid(capacidad_file(6), indice_string, 3)
            TablaCap.Rows.Add(fila)
            indice_string += 3
            fecha_act = hora
        Loop
        Dim table_style As New DataGridTableStyle
        table_style.MappingName = TablaCap.TableName
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
        Me.GridCap.TableStyles.Add(table_style)
        Me.GridCap.DataSource = TablaCap
        Me.GridCap.CaptionVisible = False
        Me.GridCap.Visible = True
    End Sub
    Private Sub Formatea_Grid_Cupo()
        With Me.GridCupos
            .TableStyles.Clear()
        End With
        TablaCupo.Columns.Clear()
        TablaCupo.Rows.Clear()
        ColumnaCupoLunes.DataType = System.Type.GetType("System.String")
        ColumnaCupoMartes.DataType = System.Type.GetType("System.String")
        ColumnaCupoMiercoles.DataType = System.Type.GetType("System.String")
        ColumnaCupoJueves.DataType = System.Type.GetType("System.String")
        ColumnaCupoViernes.DataType = System.Type.GetType("System.String")
        ColumnaCupoSabado.DataType = System.Type.GetType("System.String")
        ColumnaCupoDomingo.DataType = System.Type.GetType("System.String")
        ColumnaCupoLunes.ColumnName = "Lunes"
        ColumnaCupoMartes.ColumnName = "Martes"
        ColumnaCupoMiercoles.ColumnName = "Miercoles"
        ColumnaCupoJueves.ColumnName = "Jueves"
        ColumnaCupoViernes.ColumnName = "Viernes"
        ColumnaCupoSabado.ColumnName = "Sabado"
        ColumnaCupoDomingo.ColumnName = "Domingo"
        ColumnaCupoLunes.Caption = ""
        ColumnaCupoMartes.Caption = ""
        ColumnaCupoMiercoles.Caption = ""
        ColumnaCupoJueves.Caption = ""
        ColumnaCupoViernes.Caption = ""
        ColumnaCupoSabado.Caption = ""
        ColumnaCupoDomingo.Caption = ""
        ColumnaCupoLunes.AutoIncrement = False
        ColumnaCupoMartes.AutoIncrement = False
        ColumnaCupoMiercoles.AutoIncrement = False
        ColumnaCupoJueves.AutoIncrement = False
        ColumnaCupoViernes.AutoIncrement = False
        ColumnaCupoSabado.AutoIncrement = False
        ColumnaCupoDomingo.AutoIncrement = False
        ColumnaCupoLunes.ReadOnly = False
        ColumnaCupoMartes.ReadOnly = False
        ColumnaCupoMiercoles.ReadOnly = False
        ColumnaCupoJueves.ReadOnly = False
        ColumnaCupoViernes.ReadOnly = False
        ColumnaCupoSabado.ReadOnly = False
        ColumnaCupoDomingo.ReadOnly = False
        TablaCupo.Columns.Add(ColumnaCupoLunes)
        TablaCupo.Columns.Add(ColumnaCupoMartes)
        TablaCupo.Columns.Add(ColumnaCupoMiercoles)
        TablaCupo.Columns.Add(ColumnaCupoJueves)
        TablaCupo.Columns.Add(ColumnaCupoViernes)
        TablaCupo.Columns.Add(ColumnaCupoSabado)
        TablaCupo.Columns.Add(ColumnaCupoDomingo)
        TablaCupo.DefaultView.AllowNew = False
        Dim fila As DataRow
        fila = TablaCupo.NewRow
        fila("Lunes") = cupo_file(0)
        fila("Martes") = cupo_file(1)
        fila("Miercoles") = cupo_file(2)
        fila("Jueves") = cupo_file(3)
        fila("Viernes") = cupo_file(4)
        fila("Sabado") = cupo_file(5)
        fila("Domingo") = cupo_file(6)
        TablaCupo.Rows.Add(fila)
        Dim table_style As New DataGridTableStyle
        table_style.MappingName = TablaCupo.TableName
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
            {Lunes_style, Martes_style, Miercoles_style, Jueves_style, Viernes_style, Sabado_style, Domingo_style})
        Me.GridCupos.TableStyles.Add(table_style)
        Me.GridCupos.DataSource = TablaCupo
        Me.GridCupos.CaptionVisible = False
        Me.GridCupos.Visible = True
    End Sub
    Private Sub Buscar_Data()
        For indice = 0 To 6
            capacidad_file(indice) = ""
            cupo_file(indice) = ""
        Next
        Dim Carga_Coneccion_O1 As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O1.Open()
        Dim Carga_Comando_O1 As New OleDb.OleDbCommand("Select * from IQ_Cupos where IQCupos_Area = '" & cod_area & "' Order by IQCupos_Dia", Carga_Coneccion_O1)
        Dim Carga_Reader_O1 As OleDb.OleDbDataReader = Carga_Comando_O1.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O1.Read
            If IsDBNull(Carga_Reader_O1.GetValue(0)) = False Then
                cupo_file(Carga_Reader_O1.GetValue(1) - 1) = Carga_Reader_O1.GetValue(2)
            End If
        End While
        Carga_Coneccion_O1.Close()
        Carga_Coneccion_O1.Open()
        Dim Carga_Comando_O2 As New OleDb.OleDbCommand("Select * from IQ_Capacidad where IQCapacidad_Area = '" & cod_area & "' Order by IQCapacidad_Dia", Carga_Coneccion_O1)
        Dim Carga_Reader_O2 As OleDb.OleDbDataReader = Carga_Comando_O2.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O2.Read
            If IsDBNull(Carga_Reader_O2.GetValue(0)) = False Then
                capacidad_file(Carga_Reader_O2.GetValue(1) - 1) = Carga_Reader_O2.GetValue(2)
            End If
        End While
        Carga_Coneccion_O1.Dispose()
        Formatea_Grid_Cupo()
        Formatea_Grid_Cap()
        Me.GridCap.Visible = True
        Me.GridCupos.Visible = True
        If Permisos >= 4 Then
            Me.CmdInsert.Visible = True
        Else
            Me.CmdInsert.Visible = False
        End If
    End Sub
    Private Sub Update_Process()
        If MessageBox.Show("Está Ud. seguro de GRABAR la CAPACIDAD DE ATENCION?", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Try
            Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
            IQ_Cnn.Open()
            Dim IQ_Cmm As New OleDb.OleDbCommand("Delete from IQ_Cupos Where IQCupos_Area = '" + cod_area & "'", IQ_Cnn)
            Dim RegistrosEliminados As Long = IQ_Cmm.ExecuteNonQuery()
            IQ_Cnn.Close()
        Catch exc As Exception
            Dim Mensaje_Excepcion As String
            Mensaje_Excepcion = exc.Message
            Mensaje_Excepcion = "Error Integrado: " + Mensaje_Excepcion
            MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
        Try
            Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
            IQ_Cnn.Open()
            Dim IQ_Cmm As New OleDb.OleDbCommand("Delete from IQ_Capacidad Where IQCapacidad_Area = '" + cod_area & "'", IQ_Cnn)
            Dim RegistrosEliminados As Long = IQ_Cmm.ExecuteNonQuery()
            IQ_Cnn.Close()
        Catch exc As Exception
            Dim Mensaje_Excepcion As String
            Mensaje_Excepcion = exc.Message
            Mensaje_Excepcion = "Error Integrado: " + Mensaje_Excepcion
            MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
        Dim cupos(7) As String
        Dim capacidades(7) As String
        For indice = 0 To TablaCupo.Rows.Count - 1
            If TablaCupo.Rows(indice)("Lunes") = "" Then
                cupos(0) = ""
            Else
                cupos(0) = CStr(TablaCupo.Rows(indice)("Lunes"))
            End If
            If TablaCupo.Rows(indice)("Martes") = "" Then
                cupos(1) = ""
            Else
                cupos(1) = CStr(TablaCupo.Rows(indice)("Martes"))
            End If
            If TablaCupo.Rows(indice)("Miercoles") = "" Then
                cupos(2) = ""
            Else
                cupos(2) = CStr(TablaCupo.Rows(indice)("Miercoles"))
            End If
            If TablaCupo.Rows(indice)("Jueves") = "" Then
                cupos(3) = ""
            Else
                cupos(3) = CStr(TablaCupo.Rows(indice)("Jueves"))
            End If
            If TablaCupo.Rows(indice)("Viernes") = "" Then
                cupos(4) = ""
            Else
                cupos(4) = CStr(TablaCupo.Rows(indice)("Viernes"))
            End If
            If TablaCupo.Rows(indice)("Sabado") = "" Then
                cupos(5) = ""
            Else
                cupos(5) = CStr(TablaCupo.Rows(indice)("Sabado"))
            End If
            If TablaCupo.Rows(indice)("Domingo") = "" Then
                cupos(6) = ""
            Else
                cupos(6) = CStr(TablaCupo.Rows(indice)("Domingo"))
            End If
        Next
        For indice = 0 To TablaCap.Rows.Count - 1
            If IsDBNull(TablaCap.Rows(indice)("Hora")) = False Then
                If Trim(TablaCap.Rows(indice)("Lunes")) = "" Then
                    capacidades(0) = capacidades(0) & "   "
                Else
                    capacidades(0) = capacidades(0) & Format(CInt(TablaCap.Rows(indice)("Lunes")), "000")
                End If
                If Trim(TablaCap.Rows(indice)("Martes")) = "" Then
                    capacidades(1) = capacidades(1) & "   "
                Else
                    capacidades(1) = capacidades(1) & Format(CInt(TablaCap.Rows(indice)("Martes")), "000")
                End If
                If Trim(TablaCap.Rows(indice)("Miercoles")) = "" Then
                    capacidades(2) = capacidades(2) & "   "
                Else
                    capacidades(2) = capacidades(2) & Format(CInt(TablaCap.Rows(indice)("Miercoles")), "000")
                End If
                If Trim(TablaCap.Rows(indice)("Jueves")) = "" Then
                    capacidades(3) = capacidades(3) & "   "
                Else
                    capacidades(3) = capacidades(3) & Format(CInt(TablaCap.Rows(indice)("Jueves")), "000")
                End If
                If Trim(TablaCap.Rows(indice)("Viernes")) = "" Then
                    capacidades(4) = capacidades(4) & "   "
                Else
                    capacidades(4) = capacidades(4) & Format(CInt(TablaCap.Rows(indice)("Viernes")), "000")
                End If
                If Trim(TablaCap.Rows(indice)("Sabado")) = "" Then
                    capacidades(5) = capacidades(5) & "   "
                Else
                    capacidades(5) = capacidades(5) & Format(CInt(TablaCap.Rows(indice)("Sabado")), "000")
                End If
                If Trim(TablaCap.Rows(indice)("Domingo")) = "" Then
                    capacidades(6) = capacidades(6) & "   "
                Else
                    capacidades(6) = capacidades(6) & Format(CInt(TablaCap.Rows(indice)("Domingo")), "000")
                End If
            End If
        Next
        Dim registros As Integer = 0
        For indice = 0 To 6
            Dim instruccion_insert As String = ""
            instruccion_insert = "Insert Into IQ_Cupos Values('" + cod_area + "', "
            instruccion_insert = instruccion_insert & CStr(indice + 1) & ", "
            instruccion_insert = instruccion_insert & "'" & cupos(indice) & "')"
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
            instruccion_insert = "Insert Into IQ_Capacidad Values('" + cod_area + "', "
            instruccion_insert = instruccion_insert & CStr(indice + 1) & ", "
            instruccion_insert = instruccion_insert & "'" & capacidades(indice) & "')"
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
        Limpiar_Controles()
    End Sub
    Private Sub Cupo_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
        If e.Column.ColumnName.Equals("Lunes") Or e.Column.ColumnName.Equals("Martes") Or e.Column.ColumnName.Equals("Miercoles") Or e.Column.ColumnName.Equals("Jueves") Or e.Column.ColumnName.Equals("Viernes") Or e.Column.ColumnName.Equals("Sabado") Or e.Column.ColumnName.Equals("Domingo") Then
            If Trim(CType(e.ProposedValue, String)) = "" Then
                e.ProposedValue = " "
            ElseIf IsNumeric(CType(e.ProposedValue, String)) = False Then
                Dim badValue As Object = e.ProposedValue
                e.ProposedValue = " "
            End If
        End If
    End Sub
    Private Sub Cap_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
        If e.Column.ColumnName.Equals("Lunes") Or e.Column.ColumnName.Equals("Martes") Or e.Column.ColumnName.Equals("Miercoles") Or e.Column.ColumnName.Equals("Jueves") Or e.Column.ColumnName.Equals("Viernes") Or e.Column.ColumnName.Equals("Sabado") Or e.Column.ColumnName.Equals("Domingo") Then
            If Trim(CType(e.ProposedValue, String)) = "" Then
                e.ProposedValue = " "
            ElseIf IsNumeric(CType(e.ProposedValue, String)) = False Then
                Dim badValue As Object = e.ProposedValue
                e.ProposedValue = " "
            End If
        End If
    End Sub
End Class