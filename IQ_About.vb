Public Class IQ_About
    Inherits System.Windows.Forms.Form
#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()
        Dim linea_1 As String = " "
        Dim linea_2 As String
        Dim linea_3 As String
        Dim linea_4 As String
        Dim linea_5 As String
        Dim linea_6 As String
        Dim linea_7 As String
        Dim linea_8 As String
        Dim linea_9 As String
        Dim linea_10 As String
        Dim linea_11 As String

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        linea_1 = " "
        linea_2 = "I-Queue"
        linea_3 = " "
        Dim LblVersion As String = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString
        Dim version_ok As Boolean = False
        Do Until version_ok = True
            For indice_version = Len(LblVersion) To 1 Step -1
                If Mid(LblVersion, indice_version, 1) = "." Then
                    LblVersion = Mid(LblVersion, 1, Len(LblVersion) - 1)
                    version_ok = True
                    Exit For
                Else
                    LblVersion = Mid(LblVersion, 1, Len(LblVersion) - 1)
                End If
            Next
        Loop
        linea_4 = "Version " & LblVersion
        linea_5 = " "
        linea_6 = "Propiedad Intelectual"
        linea_7 = "JORGE GONZALO TAVERA WACHTEL"
        linea_8 = Format(DateTime.Today, "yyyy")
        linea_9 = " "
        linea_10 = "Licenciado a:"
        linea_11 = Nombre_Cliente & Chr(10) & Nombre_Oficina & Chr(10) & Nombre_Ciudad
        Me.Etiqueta_About.Text = linea_1 & Chr(10) & linea_2 & Chr(10) & linea_3 & Chr(10) & linea_4 & Chr(10) & linea_5 & Chr(10) & linea_6 & Chr(10) & linea_7 & Chr(10) & linea_8 & Chr(10) & linea_9 & Chr(10) & linea_10 & Chr(10) & linea_11
        Me.Show()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents Etiqueta_About As System.Windows.Forms.Label
    Friend WithEvents BotonOK As System.Windows.Forms.Button
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IQ_About))
        Me.Etiqueta_About = New System.Windows.Forms.Label()
        Me.BotonOK = New System.Windows.Forms.Button()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Etiqueta_About
        '
        Me.Etiqueta_About.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Etiqueta_About.ForeColor = System.Drawing.Color.Red
        Me.Etiqueta_About.Location = New System.Drawing.Point(0, 0)
        Me.Etiqueta_About.Name = "Etiqueta_About"
        Me.Etiqueta_About.Size = New System.Drawing.Size(336, 256)
        Me.Etiqueta_About.TabIndex = 11
        Me.Etiqueta_About.Text = "Label1"
        Me.Etiqueta_About.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BotonOK
        '
        Me.BotonOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BotonOK.Location = New System.Drawing.Point(120, 256)
        Me.BotonOK.Name = "BotonOK"
        Me.BotonOK.Size = New System.Drawing.Size(88, 32)
        Me.BotonOK.TabIndex = 14
        Me.BotonOK.Text = "O.K."
        '
        'PictureBox5
        '
        Me.PictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox5.Image = Global.IQ_Core.My.Resources.Resources.IQLogo
        Me.PictureBox5.Location = New System.Drawing.Point(296, 0)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 15
        Me.PictureBox5.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(44, 42)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        '
        'IQ_About
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(344, 293)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.BotonOK)
        Me.Controls.Add(Me.Etiqueta_About)
        Me.Name = "IQ_About"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acerca de ......"
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub BotonOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BotonOK.Click
        Me.Dispose()
    End Sub
End Class
