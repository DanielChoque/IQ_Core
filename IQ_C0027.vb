Public Class IQ_C0027
    Dim dt As New DataTable
    Dim inte As New Integer
    Dim i As Integer

    Public Sub New()
        InitializeComponent()
        recarga()
    End Sub
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs)
        recarga()
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs)
        'Dim s As String
        Dim IQPending_Punto As String
        Dim IQPending_CodPunto As String
        Dim IQPending_Ticket As String
        'Dim s As String
        Dim row As DataGridViewRow
        row = grid.CurrentRow
        If (Not row Is Nothing) Then
            IQPending_Punto = Convert.ToString(row.Cells("Ventanilla").Value)
            IQPending_Ticket = Convert.ToString(row.Cells("Nro Ticket").Value)
            IQPending_CodPunto = Convert.ToString(row.Cells("Codigo Punto").Value)
            's = s + Convert.ToString(row.Cells("Hora Ingresado").Value)
            'MsgBox("Ventanill:" & Convert.ToString(row.Cells("Ventanilla").Value) & " Cod _ Punto :" & Convert.ToString(row.Cells("Codigo Punto").Value))
            If Convert.ToString(row.Cells("Ventanilla").Value) = "" And Convert.ToString(row.Cells("Codigo Punto").Value) = "" Then
                '  MessageBox.Show("Este Ticket NO puede ser eliminado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                MsgBox("Este Ticket NO puede ser eliminado")
            Else
                Try
                    Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
                    IQ_Cnn.Open()
                    Dim IQ_Cmm As New OleDb.OleDbCommand("delete from Iq_Pending where IQPending_Punto='" & IQPending_Punto & "' and IQPending_CodPunto='" & IQPending_CodPunto & "' and IQPending_Ticket='" & IQPending_Ticket & "'", IQ_Cnn)
                    Dim RegistrosEliminados As Long = IQ_Cmm.ExecuteNonQuery()
                    IQ_Cnn.Close()
                    recarga()
                    MsgBox("Nro de Tickets eliminados:" & RegistrosEliminados)
                Catch exc As Exception
                    Dim Mensaje_Excepcion As String
                    Mensaje_Excepcion = exc.Message
                    Mensaje_Excepcion = "Error Integrado: " + Mensaje_Excepcion
                    MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End Try
            End If

        End If


    End Sub

    Private Sub recarga()
        Dim Carga_Coneccion_O2 As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O2.Open()
        Dim Carga_Comando_O2 As New OleDb.OleDbCommand("select * from Iq_Pending", Carga_Coneccion_O2)
        Dim Carga_Reader_O2 As OleDb.OleDbDataReader = Carga_Comando_O2.ExecuteReader(CommandBehavior.CloseConnection)

        dt.Columns.Clear()

        dt.Columns.Add("Ventanilla", GetType(String))
        dt.Columns.Add("Nro Ticket", GetType(String))
        dt.Columns.Add("Codigo Punto", GetType(String))
        dt.Columns.Add("Hora Ingresado", GetType(String))
        i = -35
        grid.DataSource = dt
        grid.Columns(0).Width = 100 + i
        grid.Columns(1).Width = 100 + i
        grid.Columns(2).Width = 200 + i + i
        grid.Columns(3).Width = 200 + i + i
        dt.Rows.Clear()
        While Carga_Reader_O2.Read
            dt.Rows.Add(Carga_Reader_O2.GetValue(2), Carga_Reader_O2.GetValue(1), Carga_Reader_O2.GetValue(3), Carga_Reader_O2.GetValue(4))
        End While
        Carga_Coneccion_O2.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim resulta As Boolean

        Erase_Reg()
    End Sub
    Private Sub Erase_Reg()
        Dim IQPending_Punto As String
        Dim IQPending_CodPunto As String
        Dim IQPending_Ticket As String
        Dim row As DataGridViewRow
        row = grid.CurrentRow
        If (Not row Is Nothing) Then
            IQPending_Punto = Convert.ToString(row.Cells("Ventanilla").Value)
            IQPending_Ticket = Convert.ToString(row.Cells("Nro Ticket").Value)
            IQPending_CodPunto = Convert.ToString(row.Cells("Codigo Punto").Value)
            If Convert.ToString(row.Cells("Ventanilla").Value) = "" And Convert.ToString(row.Cells("Codigo Punto").Value) = "" Then
                MsgBox("Este Ticket NO puede ser eliminado")
            Else

                Dim resulta = MsgBox("ELIMINAR EL REGISTRO" & vbCrLf & "VENTANILLA: " & IQPending_Punto & vbCrLf & "   TICKET: " & IQPending_Ticket, vbYesNo)
                If resulta = vbYes Then
                    MsgBox("marcaste  si")
                    Try
                        Dim IQ_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
                        IQ_Cnn.Open()
                        Dim IQ_Cmm As New OleDb.OleDbCommand("delete from Iq_Pending where IQPending_Punto='" & IQPending_Punto & "' and IQPending_CodPunto='" & IQPending_CodPunto & "' and IQPending_Ticket='" & IQPending_Ticket & "'", IQ_Cnn)
                        Dim RegistrosEliminados As Long = IQ_Cmm.ExecuteNonQuery()
                        IQ_Cnn.Close()
                        recarga()
                        MsgBox("Nro de Tickets eliminados:" & RegistrosEliminados)
                    Catch exc As Exception
                        Dim Mensaje_Excepcion As String
                        Mensaje_Excepcion = exc.Message
                        Mensaje_Excepcion = "Error Integrado: " + Mensaje_Excepcion
                        MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End Try
                Else
                    ' MsgBox("marcaste no")

                End If
                
            End If

        End If


    End Sub

    Private Sub CmdRefresh_Click(sender As Object, e As EventArgs) Handles CmdRefresh.Click
        recarga()
    End Sub
End Class