<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IQ_C0000
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IQ_C0000))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.MenuIQ = New System.Windows.Forms.MenuStrip()
        Me.PicFondo = New System.Windows.Forms.PictureBox()
        Me.IQVideo = New AxWMPLib.AxWindowsMediaPlayer()
        Me.TimerWarning = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PicFondo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IQVideo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'Timer2
        '
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Salir.jpg")
        '
        'MenuIQ
        '
        Me.MenuIQ.Location = New System.Drawing.Point(0, 0)
        Me.MenuIQ.Name = "MenuIQ"
        Me.MenuIQ.Size = New System.Drawing.Size(967, 24)
        Me.MenuIQ.TabIndex = 0
        Me.MenuIQ.Text = "MenuStrip1"
        '
        'PicFondo
        '
        Me.PicFondo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicFondo.Image = CType(resources.GetObject("PicFondo.Image"), System.Drawing.Image)
        Me.PicFondo.Location = New System.Drawing.Point(0, 68)
        Me.PicFondo.Name = "PicFondo"
        Me.PicFondo.Size = New System.Drawing.Size(967, 354)
        Me.PicFondo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicFondo.TabIndex = 2
        Me.PicFondo.TabStop = False
        '
        'IQVideo
        '
        Me.IQVideo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IQVideo.Enabled = True
        Me.IQVideo.Location = New System.Drawing.Point(0, 68)
        Me.IQVideo.Name = "IQVideo"
        Me.IQVideo.OcxState = CType(resources.GetObject("IQVideo.OcxState"), System.Windows.Forms.AxHost.State)
        Me.IQVideo.Size = New System.Drawing.Size(967, 626)
        Me.IQVideo.TabIndex = 3
        '
        'TimerWarning
        '
        Me.TimerWarning.Interval = 60000
        '
        'IQ_C0000
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(967, 421)
        Me.Controls.Add(Me.IQVideo)
        Me.Controls.Add(Me.MenuIQ)
        Me.Controls.Add(Me.PicFondo)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuIQ
        Me.Name = "IQ_C0000"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PicFondo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IQVideo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents MenuIQ As System.Windows.Forms.MenuStrip
    Friend WithEvents PicFondo As System.Windows.Forms.PictureBox
    Friend WithEvents IQVideo As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents TimerWarning As System.Windows.Forms.Timer
End Class
