<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IQ_C0027
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IQ_C0027))
        Me.grid = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CmdRefresh = New System.Windows.Forms.Button()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grid
        '
        Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid.Location = New System.Drawing.Point(12, 12)
        Me.grid.Name = "grid"
        Me.grid.Size = New System.Drawing.Size(455, 537)
        Me.grid.TabIndex = 9
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Button1.Image = Global.IQ_Core.My.Resources.Resources.Eliminar
        Me.Button1.Location = New System.Drawing.Point(484, 299)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(40, 40)
        Me.Button1.TabIndex = 10
        Me.Button1.UseVisualStyleBackColor = False
        '
        'CmdRefresh
        '
        Me.CmdRefresh.Image = CType(resources.GetObject("CmdRefresh.Image"), System.Drawing.Image)
        Me.CmdRefresh.Location = New System.Drawing.Point(484, 12)
        Me.CmdRefresh.Name = "CmdRefresh"
        Me.CmdRefresh.Size = New System.Drawing.Size(40, 40)
        Me.CmdRefresh.TabIndex = 536
        Me.CmdRefresh.UseVisualStyleBackColor = True
        '
        'IQ_C0027
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(557, 561)
        Me.Controls.Add(Me.CmdRefresh)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.grid)
        Me.Name = "IQ_C0027"
        Me.Text = "PanelCC"
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grid As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CmdRefresh As System.Windows.Forms.Button
End Class
