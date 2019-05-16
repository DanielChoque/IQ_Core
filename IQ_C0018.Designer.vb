<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IQ_C0018
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IQ_C0018))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CmdExit = New System.Windows.Forms.Button()
        Me.CmdExec = New System.Windows.Forms.Button()
        Me.CmdClean = New System.Windows.Forms.Button()
        Me.CmdNewSearch = New System.Windows.Forms.Button()
        Me.CmdSearch = New System.Windows.Forms.Button()
        Me.LblAplicacion = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TrvOficinas = New System.Windows.Forms.TreeView()
        Me.Barra_Estado = New System.Windows.Forms.StatusBar()
        Me.Panel_Estado0 = New System.Windows.Forms.StatusBarPanel()
        Me.Panel_Estado1 = New System.Windows.Forms.StatusBarPanel()
        Me.Panel_Estado2 = New System.Windows.Forms.StatusBarPanel()
        Me.Panel_Estado3 = New System.Windows.Forms.StatusBarPanel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.LblTicket = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TrvTickets = New System.Windows.Forms.TreeView()
        Me.LblDestino = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TrvDestinos = New System.Windows.Forms.TreeView()
        Me.CmdRefresh = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.Panel_Estado0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Panel_Estado1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Panel_Estado2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Panel_Estado3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CmdRefresh)
        Me.Panel1.Controls.Add(Me.CmdExit)
        Me.Panel1.Controls.Add(Me.CmdExec)
        Me.Panel1.Controls.Add(Me.CmdClean)
        Me.Panel1.Controls.Add(Me.CmdNewSearch)
        Me.Panel1.Controls.Add(Me.CmdSearch)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1169, 40)
        Me.Panel1.TabIndex = 2
        '
        'CmdExit
        '
        Me.CmdExit.Image = CType(resources.GetObject("CmdExit.Image"), System.Drawing.Image)
        Me.CmdExit.Location = New System.Drawing.Point(160, 0)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(40, 40)
        Me.CmdExit.TabIndex = 8
        Me.CmdExit.UseVisualStyleBackColor = True
        '
        'CmdExec
        '
        Me.CmdExec.Image = Global.IQ_Core.My.Resources.Resources.Ejecutar
        Me.CmdExec.Location = New System.Drawing.Point(120, 0)
        Me.CmdExec.Name = "CmdExec"
        Me.CmdExec.Size = New System.Drawing.Size(40, 40)
        Me.CmdExec.TabIndex = 7
        Me.CmdExec.UseVisualStyleBackColor = True
        '
        'CmdClean
        '
        Me.CmdClean.Image = Global.IQ_Core.My.Resources.Resources.Limpiar
        Me.CmdClean.Location = New System.Drawing.Point(80, 0)
        Me.CmdClean.Name = "CmdClean"
        Me.CmdClean.Size = New System.Drawing.Size(40, 40)
        Me.CmdClean.TabIndex = 6
        Me.CmdClean.UseVisualStyleBackColor = True
        '
        'CmdNewSearch
        '
        Me.CmdNewSearch.Image = Global.IQ_Core.My.Resources.Resources.NuevaBusqueda
        Me.CmdNewSearch.Location = New System.Drawing.Point(40, 0)
        Me.CmdNewSearch.Name = "CmdNewSearch"
        Me.CmdNewSearch.Size = New System.Drawing.Size(40, 40)
        Me.CmdNewSearch.TabIndex = 5
        Me.CmdNewSearch.UseVisualStyleBackColor = True
        '
        'CmdSearch
        '
        Me.CmdSearch.Image = Global.IQ_Core.My.Resources.Resources.Buscar
        Me.CmdSearch.Location = New System.Drawing.Point(0, 0)
        Me.CmdSearch.Name = "CmdSearch"
        Me.CmdSearch.Size = New System.Drawing.Size(40, 40)
        Me.CmdSearch.TabIndex = 3
        Me.CmdSearch.UseVisualStyleBackColor = True
        '
        'LblAplicacion
        '
        Me.LblAplicacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblAplicacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblAplicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAplicacion.Location = New System.Drawing.Point(12, 65)
        Me.LblAplicacion.Name = "LblAplicacion"
        Me.LblAplicacion.Size = New System.Drawing.Size(311, 23)
        Me.LblAplicacion.TabIndex = 50
        Me.LblAplicacion.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(11, 47)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 23)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "Alcance:"
        '
        'TrvOficinas
        '
        Me.TrvOficinas.Location = New System.Drawing.Point(12, 91)
        Me.TrvOficinas.Name = "TrvOficinas"
        Me.TrvOficinas.Size = New System.Drawing.Size(311, 335)
        Me.TrvOficinas.TabIndex = 46
        '
        'Barra_Estado
        '
        Me.Barra_Estado.Location = New System.Drawing.Point(0, 631)
        Me.Barra_Estado.Name = "Barra_Estado"
        Me.Barra_Estado.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.Panel_Estado0, Me.Panel_Estado1, Me.Panel_Estado2, Me.Panel_Estado3})
        Me.Barra_Estado.ShowPanels = True
        Me.Barra_Estado.Size = New System.Drawing.Size(1169, 32)
        Me.Barra_Estado.TabIndex = 51
        Me.Barra_Estado.Text = "StatusBar1"
        '
        'Panel_Estado0
        '
        Me.Panel_Estado0.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.Panel_Estado0.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
        Me.Panel_Estado0.Name = "Panel_Estado0"
        Me.Panel_Estado0.Width = 10
        '
        'Panel_Estado1
        '
        Me.Panel_Estado1.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.Panel_Estado1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
        Me.Panel_Estado1.Name = "Panel_Estado1"
        Me.Panel_Estado1.Width = 10
        '
        'Panel_Estado2
        '
        Me.Panel_Estado2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.Panel_Estado2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
        Me.Panel_Estado2.Name = "Panel_Estado2"
        Me.Panel_Estado2.Width = 10
        '
        'Panel_Estado3
        '
        Me.Panel_Estado3.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.Panel_Estado3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
        Me.Panel_Estado3.Name = "Panel_Estado3"
        Me.Panel_Estado3.Width = 10
        '
        'Timer1
        '
        '
        'LblTicket
        '
        Me.LblTicket.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblTicket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTicket.Location = New System.Drawing.Point(339, 65)
        Me.LblTicket.Name = "LblTicket"
        Me.LblTicket.Size = New System.Drawing.Size(311, 23)
        Me.LblTicket.TabIndex = 54
        Me.LblTicket.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(338, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 23)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Ticket:"
        '
        'TrvTickets
        '
        Me.TrvTickets.Location = New System.Drawing.Point(339, 91)
        Me.TrvTickets.Name = "TrvTickets"
        Me.TrvTickets.Size = New System.Drawing.Size(311, 335)
        Me.TrvTickets.TabIndex = 52
        '
        'LblDestino
        '
        Me.LblDestino.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDestino.Location = New System.Drawing.Point(665, 65)
        Me.LblDestino.Name = "LblDestino"
        Me.LblDestino.Size = New System.Drawing.Size(311, 23)
        Me.LblDestino.TabIndex = 57
        Me.LblDestino.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(664, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 23)
        Me.Label4.TabIndex = 56
        Me.Label4.Text = "Destino:"
        '
        'TrvDestinos
        '
        Me.TrvDestinos.Location = New System.Drawing.Point(665, 91)
        Me.TrvDestinos.Name = "TrvDestinos"
        Me.TrvDestinos.Size = New System.Drawing.Size(311, 335)
        Me.TrvDestinos.TabIndex = 55
        '
        'CmdRefresh
        '
        Me.CmdRefresh.Image = CType(resources.GetObject("CmdRefresh.Image"), System.Drawing.Image)
        Me.CmdRefresh.Location = New System.Drawing.Point(564, 0)
        Me.CmdRefresh.Name = "CmdRefresh"
        Me.CmdRefresh.Size = New System.Drawing.Size(40, 40)
        Me.CmdRefresh.TabIndex = 535
        Me.CmdRefresh.UseVisualStyleBackColor = True
        '
        'IQ_C0018
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1169, 663)
        Me.Controls.Add(Me.LblDestino)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TrvDestinos)
        Me.Controls.Add(Me.LblTicket)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TrvTickets)
        Me.Controls.Add(Me.LblAplicacion)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TrvOficinas)
        Me.Controls.Add(Me.Barra_Estado)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "IQ_C0018"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Asignación directa de Tickets"
        Me.Panel1.ResumeLayout(False)
        CType(Me.Panel_Estado0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Panel_Estado1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Panel_Estado2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Panel_Estado3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CmdExit As System.Windows.Forms.Button
    Friend WithEvents CmdExec As System.Windows.Forms.Button
    Friend WithEvents CmdClean As System.Windows.Forms.Button
    Friend WithEvents CmdNewSearch As System.Windows.Forms.Button
    Friend WithEvents CmdSearch As System.Windows.Forms.Button
    Friend WithEvents LblAplicacion As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TrvOficinas As System.Windows.Forms.TreeView
    Friend WithEvents Barra_Estado As System.Windows.Forms.StatusBar
    Friend WithEvents Panel_Estado0 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents Panel_Estado1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents Panel_Estado2 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents Panel_Estado3 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents LblTicket As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TrvTickets As System.Windows.Forms.TreeView
    Friend WithEvents LblDestino As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TrvDestinos As System.Windows.Forms.TreeView
    Friend WithEvents CmdRefresh As System.Windows.Forms.Button
End Class
