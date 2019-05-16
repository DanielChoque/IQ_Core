Imports System.Security.Principal

Public Class IQ_Connect
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        Limpiar_Controles()
        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IQ_Connect))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'txtCodigo
        '
        resources.ApplyResources(Me.txtCodigo, "txtCodigo")
        Me.txtCodigo.Name = "txtCodigo"
        '
        'txtPassword
        '
        resources.ApplyResources(Me.txtPassword, "txtPassword")
        Me.txtPassword.Name = "txtPassword"
        '
        'btnOK
        '
        resources.ApplyResources(Me.btnOK, "btnOK")
        Me.btnOK.Name = "btnOK"
        '
        'btnCancel
        '
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.Name = "btnCancel"
        '
        'IQ_Connect
        '
        Me.AcceptButton = Me.btnOK
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "IQ_Connect"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Application.Exit()
    End Sub
    Private Sub Limpiar_Controles()
        Me.txtCodigo.Text = ""
        Me.txtPassword.Text = ""
        Me.txtCodigo.Focus()
    End Sub
    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Trim(Me.txtCodigo.Text) = "" Or Trim(Me.txtPassword.Text) = "" Then
            MessageBox.Show("Datos Insuficientes para Conectarse al Sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.txtCodigo.Focus()
            Exit Sub
        End If
        If IsNumeric(Me.txtCodigo.Text) = False Then
            MessageBox.Show("El Código de Operador debe ser Numérico", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.txtCodigo.Focus()
            Exit Sub
        End If
        If Val(Me.txtCodigo.Text) < 0 Then
            MessageBox.Show("El Código de Operador no puede ser negativo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.txtCodigo.Focus()
            Exit Sub
        End If
        User_Role = Nothing
        User_Code = Nothing
        Dim pwd As String = ""
        Try
            Dim CnnUsuarios As New OleDb.OleDbConnection(Cnn_Central_Server)
            CnnUsuarios.Open()
            Dim string_command As String
            string_command = "Select * from Iq_Users where IqUsers_Codigo = " + Me.txtCodigo.Text
            Dim CmmUsuarios As New OleDb.OleDbCommand(string_command, CnnUsuarios)
            Dim DatosUsuarios As OleDb.OleDbDataReader = CmmUsuarios.ExecuteReader(CommandBehavior.CloseConnection)
            Try
                While DatosUsuarios.Read()
                    If User_Role = Nothing And IsDBNull(DatosUsuarios.GetValue(0)) = False Then
                        If CDbl(DatosUsuarios.GetValue(0)) = CDbl(Me.txtCodigo.Text) Then
                            User_Code = DatosUsuarios.GetValue(0)
                            User_Role = DatosUsuarios.GetValue(2)
                            pwd = DatosUsuarios.GetValue(3)
                            Exit While
                        End If
                    End If
                End While
            Catch ex As Exception
                MessageBox.Show("Operador Inexistente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                CnnUsuarios.Dispose()
                Exit Sub
            End Try
            If User_Role = Nothing Then
                MessageBox.Show("Operador Inexistente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                CnnUsuarios.Dispose()
                Exit Sub
            End If
            CnnUsuarios.Dispose()
        Catch exc As Exception
            MessageBox.Show(exc.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
        If IQ_Security.Encriptado(Trim(Me.txtPassword.Text)) <> Trim(pwd) Then
            MessageBox.Show("Clave Incorrecta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            User_Code = Nothing
            User_Role = Nothing
            Exit Sub
        End If
        IQ_Security.Carga_Permisos(User_Role, "")
        Me.Dispose()
    End Sub
End Class
