Imports CrystalDecisions.CrystalReports.Engine
Public Class IQ_W0001

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub
    Public Sub New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        Me.Size = New System.Drawing.Size(581, 482)
        Dim rptlayout As New ReportDocument
        Dim selform As String
        Try
            rptlayout.Load(Disco_Appl & ":\I-Q\IQ_Rpt\IQ_W0001.rpt")
            rptlayout.SetDatabaseLogon(Server_User, Server_Pwd)
            rptlayout.SummaryInfo.ReportTitle = Nombre_Cliente + Chr(10) + Me.Text
            selform = "({IQ_VwAlertas1.Saldo} < 0 or ({IQ_VwAlertas1.Saldo} > 0 and ({IQ_VwAlertas1.Saldo} / {IQ_VwAlertas1.Plazo}) < 0.1))"
            If Warning_Parameter = "A" Then
                selform = selform & " And {IQ_VwAlertas1.CodOficina} = '" & Computer_Ofic & "'"
            End If
            Try
                selform = selform & " And {IQ_VwAlertas1.Emision} = date(" & Format(DateAdd(DateInterval.Second, desfase_segundos, Date.Now), "yyyy,MM,dd") & ")"
            Catch ex As Exception
                selform = selform & " And {IQ_VwAlertas1.Emision} = date(" & Format(DateAdd(DateInterval.Second, 0, Date.Now), "yyyy,MM,dd") & ")"
            End Try
            Me.CrvReporte.SelectionFormula = selform
            Me.CrvReporte.ReportSource = rptlayout
            Me.CrvReporte.DisplayToolbar = True
            Me.CrvReporte.ShowCloseButton = False
            Me.CrvReporte.Zoom(1)
            Me.CrvReporte.ShowFirstPage()
            Me.CrvReporte.BringToFront()
            Me.CrvReporte.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            Me.CrvReporte.Visible = True
        Catch exc As Exception
            Dim Mensaje_Excepcion As String
            Mensaje_Excepcion = exc.Message
            Mensaje_Excepcion = "Error Integrado: " + Mensaje_Excepcion
            MessageBox.Show(Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
End Class