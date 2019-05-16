Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class IQ_C0000
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Dim cont_menus As Integer
    Dim Image_Name As String
    Dim Button_Tooltip As String
    Dim Button_Counter As Integer
    Private DsMenus As New DataSet
    Private DbMenus As System.Data.OleDb.OleDbDataAdapter = New System.Data.OleDb.OleDbDataAdapter

    Public Sub New()
        InitializeComponent()
        Dim Ips_Prov(50) As String
        Dim Indice_Ips As Integer = 0
        Me.PicFondo.Visible = False
        Disco_Appl = GetSetting("I-Queue", "Appl", "Disco", "D")
        If Disco_Appl Is Nothing Then
            Disco_Appl = "C"
        End If
        Me.TimerWarning.Enabled = False
        Me.TimerWarning.Stop()
        Icon_Folder = Disco_Appl & ":\I-Q\Iconos\"
        '      IQVideo.URL = Icon_Folder & "IQUEUElOGO.mpg"
        '      Me.IQVideo.Width = Me.Width
        '      Me.IQVideo.Height = Me.Height + 100
        '      Me.IQVideo.Location = New Point(0, 0)
        '      Me.IQVideo.Visible = True
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
        Me.Text = "IQ_CORE " & LblVersion
        Server_Name = GetSetting("I-Queue", "Appl", "ServerName", "")
        Server_Ip = GetSetting("I-Queue", "Appl", "ServerIp", "")
        Server_User = GetSetting("I-Queue", "Appl", "ServerUser", "")
        Server_Pwd = GetSetting("I-Queue", "Appl", "ServerPwd", "")
        Server_Collation = GetSetting("I-Queue", "Appl", "ServerCollation", "ymd")
        If Server_Name = "" Or Server_Ip = "" Or Server_User = "" Then
            MessageBox.Show("EQUIPO NO CONFIGURADO PARA I-Q", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End If
        Cnn_Central_Server = "Provider=SQLOLEDB.1;Persist Security Info=False;User ID=" & Server_User & ";Password=" & Server_Pwd & ";Data Source=" & Server_Name & ";Initial Catalog=IQData;Use Procedure for Prepare=1;Auto Translate=True;Packet Size=4096;Workstation ID=RIESGO2;Use Encryption for Data=False;Tag with column collation when possible=False"
        User_Code = Nothing
        User_Role = Nothing
        User_Name = Nothing
        Timer2.Enabled = False
        Timer2.Stop()
        Dim cn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(Cnn_Central_Server)
        cn.Open()
        DsMenus.Clear()
        With DbMenus
            Dim SQLStr As String = "Select * from Iq_Menus order by IqMenus_Codigo"
            .TableMappings.Add("Table", "Iq_Menus")
            Dim cmd As System.Data.OleDb.OleDbCommand = New System.Data.OleDb.OleDbCommand(SQLStr, cn)
            cmd.CommandType = CommandType.Text
            .SelectCommand = cmd
            .Fill(DsMenus)
            .Dispose()
            cmd.Cancel()
        End With
        cn.Close()
        DictAccesos.Clear()
        Computer_Ip = Nothing
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim iphe As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(strHostName)
        For Each ipheal As System.Net.IPAddress In iphe.AddressList
            If ipheal.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                Ips_Prov(Indice_Ips) = ipheal.ToString()
                Indice_Ips += 1
            End If
        Next
        Dim instruccion As String
        Computer_Ofic = ""
        For Indice_Ips = 0 To 49
            If Ips_Prov(Indice_Ips) = Nothing Then
                Exit For
            End If
            Dim ip_mask As String = Ips_Prov(Indice_Ips)
            Dim mascara_red As String = ""
            Dim pos1 As Integer = 0
            pos1 = InStr(ip_mask, ".")
            If pos1 > 0 Then
                mascara_red = Mid(ip_mask, 1, pos1)
                ip_mask = Mid(ip_mask, pos1 + 1, Len(ip_mask) - pos1)
                pos1 = InStr(ip_mask, ".")
                If pos1 > 0 Then
                    mascara_red = mascara_red & Mid(ip_mask, 1, pos1)
                    ip_mask = Mid(ip_mask, pos1 + 1, Len(ip_mask) - pos1)
                    pos1 = InStr(ip_mask, ".")
                    If pos1 > 0 Then
                        mascara_red = mascara_red & Mid(ip_mask, 1, pos1)
                    End If
                End If
            End If
            instruccion = "Select IQOficinas_Codigo from IQ_Oficinas where IQOficinas_Ip like '" & mascara_red & "%'"
            Dim Carga_Coneccion_M2b As New OleDb.OleDbConnection(Cnn_Central_Server)
            Carga_Coneccion_M2b.Open()
            Dim Carga_Comando_M2b As New OleDb.OleDbCommand(instruccion, Carga_Coneccion_M2b)
            Dim Carga_Reader_M2b As OleDb.OleDbDataReader = Carga_Comando_M2b.ExecuteReader(CommandBehavior.CloseConnection)
            While Carga_Reader_M2b.Read
                If IsDBNull(Carga_Reader_M2b.GetValue(0)) = False Then
                    Computer_Ip = Ips_Prov(Indice_Ips)
                    Computer_Ofic = Carga_Reader_M2b.GetValue(0)
                End If
            End While
            Carga_Coneccion_M2b.Dispose()
            If Computer_Ofic <> "" Then
                Exit For
            End If
        Next
        Synchronize_Date_Server()
        Timer1.Enabled = True
        Timer1.Start()
    End Sub
    Private Function Menu_Icon(Menu_Buscado As String) As String
        Menu_Icon = Nothing
        Button_Tooltip = Nothing
        Dim cont_cont_3 As Integer
        Dim cont_lista_3 As Integer
        cont_cont_3 = DsMenus.Tables("Iq_Menus").Rows.Count
        For cont_lista_3 = 0 To cont_cont_3 - 1
            If DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Codigo") = Menu_Buscado Then
                If IsDBNull(DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Image")) = False Then
                    Menu_Icon = DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Image")
                    Button_Tooltip = DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Tooltip")
                End If
            End If
        Next
    End Function
    Private Function Menu_Button(Menu_Buscado As String) As Boolean
        Menu_Button = False
        Dim cont_cont_3 As Integer
        Dim cont_lista_3 As Integer
        cont_cont_3 = DsMenus.Tables("Iq_Menus").Rows.Count
        For cont_lista_3 = 0 To cont_cont_3 - 1
            If DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Codigo") = Menu_Buscado Then
                If IsDBNull(DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Button")) Then
                    Menu_Button = False
                Else
                    Menu_Button = DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Button")
                End If
            End If
        Next
    End Function
    Private Sub Synchronize_Date_Server()
        Dim Central_Cnn As New OleDb.OleDbConnection(Cnn_Central_Server)
        Dim CmmCentral As New OleDb.OleDbCommand("", Central_Cnn)
        CmmCentral.CommandTimeout = 0
        CmmCentral.CommandType = CommandType.StoredProcedure
        CmmCentral.CommandText = "IQ_SpGetServerDate"
        CmmCentral.Parameters.Add("Fecha", OleDbType.Date).Direction = ParameterDirection.Output
        Dim Fecha_Sistema As Date
        Dim Fecha_Maquina As Date
        Try
            Central_Cnn.Open()
            CmmCentral.ExecuteNonQuery()
            Fecha_Sistema = CmmCentral.Parameters("Fecha").Value
            Fecha_Maquina = DateTime.Now
            desfase_segundos = DateDiff(DateInterval.Second, Fecha_Maquina, Fecha_Sistema)
            Central_Cnn.Close()
        Catch exc As Exception
            Dim Mensaje_Excepcion As String
            Mensaje_Excepcion = exc.Message
            MessageBox.Show("Error Integrado: " + Mensaje_Excepcion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Timer1.Enabled = False
        Me.IQVideo.Visible = False
        Me.PicFondo.Width = Me.Width
        Me.PicFondo.Height = Me.Height - 100
        Me.PicFondo.Location = New Point(0, 68)
        Me.PicFondo.Visible = True
        If User_Code = Nothing Then
            Dim doc As IQ_Connect = New IQ_Connect
            doc.Visible = False
            doc.ShowDialog()
            Load_Initial()
        End If
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer2.Enabled = False
        Timer2.Stop()
        If Me.MdiChildren.Length > 0 Then
            MessageBox.Show("Para desconectarse debe cerrar primero todas las ventanas que tenga abiertas", "Desconexión del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Me.TimerWarning.Enabled = False
        Me.TimerWarning.Stop()
        MenuIQ.Items.Clear()
        Dim Hay_Botones As Boolean
        Hay_Botones = True
        Do While Hay_Botones = True
            Hay_Botones = False
            For Each controlito In Me.Controls
                If (TypeOf controlito Is Button) Then
                    controlito.dispose()
                    Hay_Botones = True
                    Exit For
                End If
            Next controlito
        Loop
        Button_Counter = 0
        Dim MenuItem9 As New ToolStripMenuItem("Acceso")
        Image_Name = Menu_Icon("Iq_0009")
        If Image_Name <> Nothing Then
            MenuItem9.Image = Image.FromFile(Icon_Folder & Image_Name)
            If Menu_Button("Iq_0009") = True Then
                Create_Button(Image_Name, "Iq_0009")
            End If
        End If
        MenuItem9.Tag = "Iq_0009"
        MenuIQ.Items.Add(MenuItem9)
        Dim MenuItem901 As New ToolStripMenuItem("Conectar")
        MenuItem9.DropDownItems.Add(MenuItem901)
        Image_Name = Menu_Icon("Iq_0901")
        If Image_Name <> Nothing Then
            MenuItem901.Image = Image.FromFile(Icon_Folder & Image_Name)
            If Menu_Button("Iq_0901") = True Then
                Create_Button(Image_Name, "Iq_0901")
            End If
        End If
        MenuItem901.Tag = "Iq_0901"
        AddHandler MenuItem901.Click, AddressOf Items_Menu_Click
        Dim MenuItem999 As New ToolStripMenuItem("Salir")
        MenuItem9.DropDownItems.Add(MenuItem999)
        Image_Name = Menu_Icon("Iq_0999")
        If Image_Name <> Nothing Then
            MenuItem999.Image = Image.FromFile(Icon_Folder & Image_Name)
            If Menu_Button("Iq_0999") = True Then
                Create_Button(Image_Name, "Iq_0999")
            End If
        End If
        MenuItem999.Tag = "Iq_0999"
        AddHandler MenuItem999.Click, AddressOf Items_Menu_Click
        Dim MenuItemAbout As New ToolStripMenuItem("Acerca De...")
        Image_Name = Menu_Icon("Iq_About")
        If Image_Name <> Nothing Then
            MenuItemAbout.Image = Image.FromFile(Icon_Folder & Image_Name)
            If Menu_Button("Iq_About") = True Then
                Create_Button(Image_Name, "Iq_About")
            End If
        End If
        MenuItemAbout.Tag = "Iq_About"
        MenuIQ.Items.Add(MenuItemAbout)
        AddHandler MenuItemAbout.Click, AddressOf Items_Menu_Click
        MenuItem901.Visible = True
        MenuItem999.Visible = True
    End Sub
    Private Sub Items_Menu_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If UCase(sender.Tag) = "IQ_0999" Then
            If MessageBox.Show("¿Está Ud. seguro de abandonar el sistema?", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
            Application.Exit()
        End If
        If UCase(sender.Tag) = "IQ_0902" Then
            If MessageBox.Show("¿Está Ud. seguro de desconectarse del sistema?", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
            Timer2.Enabled = True
            Timer2.Start()
            Exit Sub
        End If
        If UCase(sender.Tag) = "IQ_ABOUT" Then
            Dim doc As IQ_About = New IQ_About
            doc.Visible = False
            doc.ShowDialog()
            Exit Sub
        End If
        If UCase(sender.Tag) = "IQ_0901" Then
            Dim doc As IQ_Connect = New IQ_Connect
            doc.Visible = False
            doc.ShowDialog()
            MenuIQ.Items.Clear()
            Load_Initial()
            Exit Sub
        End If
        Dim cont_cont_3 As Integer
        Dim cont_lista_3 As Integer
        Dim Form_to_call As String = ""
        Dim Text_to_call As String = ""
        Dim Perm_to_Call As String = ""
        Dim Param_to_Call As String = ""
        cont_cont_3 = DsMenus.Tables("Iq_Menus").Rows.Count
        For cont_lista_3 = 0 To cont_cont_3 - 1
            If UCase(DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Codigo")) = UCase(sender.tag) Then
                If IsDBNull(DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Form")) = False Then
                    Form_to_call = DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Form")
                    Text_to_call = DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Descripcion")
                    Perm_to_Call = DictAccesos.Valor_Permiso(DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Codigo"))
                    If IsDBNull(DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Parameter")) = False Then
                        Param_to_Call = DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Parameter")
                    Else
                        Param_to_Call = ""
                    End If
                    Exit For
                End If
            End If
        Next
        If Form_to_call <> "" Then
            Try
                Dim obj As Object = Activator.CreateInstance(Type.GetType(Form_to_call))
                Me.PicFondo.Visible = False
                Dim f As Form = CType(obj, Form)
                If InStr(Form_to_call, "W0001") = 0 Then
                    f.MdiParent = Me
                    f.Location = New Point(0, (Int(Button_Counter / 20) * 40) + 40)
                    f.Width = Me.Width - 25
                    f.Height = Me.Height - ((Int(Button_Counter / 20) * 40) + 50) - 60
                    f.Text = Text_to_call & "|" & Perm_to_Call
                End If
                Menu_Parameter = Param_to_Call
                f.Show()
            Catch ex As Exception
                Dim Mensaje_Excepcion As String
                Mensaje_Excepcion = ex.Message
                MessageBox.Show("ERROR EN LA CONSTRUCCION DE LOS MENUS: " & ex.Message + ". POR FAVOR INFORME A SISTEMAS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End Try
        End If
    End Sub
    Private Sub Create_Button(Imagen As String, Tag As String)
        Dim CommandButton As New Button
        CommandButton.Image = Image.FromFile(Icon_Folder & Image_Name)
        CommandButton.Tag = Tag
        CommandButton.Height = 40
        CommandButton.Width = 40
        CommandButton.Anchor = AnchorStyles.Top + AnchorStyles.Left
        CommandButton.Location = New Point(0 + (Button_Counter * 40), 25)
        Me.Controls.Add(CommandButton)
        AddHandler CommandButton.Click, AddressOf Items_Menu_Click
        Dim toolTip1 As New ToolTip()
        toolTip1.AutoPopDelay = 5000
        toolTip1.InitialDelay = 1000
        toolTip1.ReshowDelay = 500
        toolTip1.ShowAlways = True
        toolTip1.SetToolTip(CommandButton, Button_Tooltip)
        Button_Counter += 1
    End Sub
    Private Sub Carga_Submenus(Item_Menu As ToolStripMenuItem, Codigo_Menu As String)
        Dim cont_cont_3 As Integer
        Dim cont_lista_3 As Integer
        cont_cont_3 = DsMenus.Tables("Iq_Menus").Rows.Count
        For cont_lista_3 = 0 To cont_cont_3 - 1
            If DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Menu") = Codigo_Menu Then
                If DictAccesos.Valor_Permiso(DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Codigo")) <> Nothing Then
                    Dim nombre_menu As String = DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Descripcion")
                    Dim MenuItem As New ToolStripMenuItem(nombre_menu)
                    Image_Name = Menu_Icon(DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Codigo"))
                    If Image_Name <> Nothing Then
                        MenuItem.Image = Image.FromFile(Icon_Folder & Image_Name)
                        If Menu_Button(DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Codigo")) = True Then
                            Create_Button(Image_Name, DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Codigo"))
                        End If
                    End If
                    Item_Menu.DropDownItems.Add(MenuItem)
                    MenuItem.Tag = DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Codigo")
                    AddHandler MenuItem.Click, AddressOf Items_Menu_Click
                    Carga_Submenus(MenuItem, DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Codigo"))
                End If
            End If
        Next
    End Sub
    Private Sub Load_Initial()
        Dim cont_cont_3 As Integer
        Dim cont_lista_3 As Integer
        Dim Hay_Botones As Boolean
        Hay_Botones = True
        Do While Hay_Botones = True
            Hay_Botones = False
            For Each controlito In Me.Controls
                If (TypeOf controlito Is Button) Then
                    controlito.dispose()
                    Hay_Botones = True
                    Exit For
                End If
            Next controlito
        Loop
        Button_Counter = 0
        cont_cont_3 = DsMenus.Tables("Iq_Menus").Rows.Count
        Me.TimerWarning.Enabled = False
        Me.TimerWarning.Stop()
        Warning_Parameter = ""
        For cont_lista_3 = 0 To cont_cont_3 - 1
            'If Me.TimerWarning.Enabled = False Then
            'If UCase(DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Menu")) = "FORM" Then
            'If UCase(Mid(DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Codigo"), 1, 4)) = "IQ_W" Then
            'If DictAccesos.Valor_Permiso(DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Codigo")) <> Nothing Then
            'If IsDBNull(DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Parameter")) Then
            'Warning_Parameter = ""
            'Else
            'Warning_Parameter = DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Parameter")
            'End If
            'Me.TimerWarning.Enabled = True
            'Me.TimerWarning.Start()
            'End If
            'End If
            'End If
            'End If
            If UCase(DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Menu")) = "ROOT" And UCase(DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Codigo")) <> "IQ_0009" And UCase(DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Codigo")) <> "IQ_ABOUT" Then
                If DictAccesos.Valor_Permiso(DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Codigo")) <> Nothing Then
                    Dim nombre_menu As String = DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Descripcion")
                    Dim MenuItem As New ToolStripMenuItem(nombre_menu)
                    MenuIQ.Items.Add(MenuItem)
                    Image_Name = Menu_Icon(DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Codigo"))
                    If Image_Name <> Nothing Then
                        MenuItem.Image = Image.FromFile(Icon_Folder & Image_Name)
                        If Menu_Button(DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Codigo")) = True Then
                            Create_Button(Image_Name, DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Codigo"))
                        End If
                    End If
                    MenuItem.Tag = DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Codigo")
                    AddHandler MenuItem.Click, AddressOf Items_Menu_Click
                    Carga_Submenus(MenuItem, DsMenus.Tables("Iq_Menus").Rows(cont_lista_3).Item("IqMenus_Codigo"))
                End If
            End If
        Next
        Dim MenuItem9 As New ToolStripMenuItem("Acceso")
        Image_Name = Menu_Icon("Iq_0009")
        If Image_Name <> Nothing Then
            MenuItem9.Image = Image.FromFile(Icon_Folder & Image_Name)
            If Menu_Button("Iq_0009") = True Then
                Create_Button(Image_Name, "Iq_0009")
            End If
        End If
        MenuItem9.Tag = "Iq_0009"
        MenuIQ.Items.Add(MenuItem9)
        Dim MenuItem902 As New ToolStripMenuItem("Desconectar")
        MenuItem9.DropDownItems.Add(MenuItem902)
        Image_Name = Menu_Icon("Iq_0902")
        If Image_Name <> Nothing Then
            MenuItem902.Image = Image.FromFile(Icon_Folder & Image_Name)
            If Menu_Button("Iq_0902") = True Then
                Create_Button(Image_Name, "Iq_0902")
            End If
        End If
        MenuItem902.Tag = "Iq_0902"
        AddHandler MenuItem902.Click, AddressOf Items_Menu_Click
        Dim MenuItem999 As New ToolStripMenuItem("Salir")
        MenuItem9.DropDownItems.Add(MenuItem999)
        Image_Name = Menu_Icon("Iq_0999")
        If Image_Name <> Nothing Then
            MenuItem999.Image = Image.FromFile(Icon_Folder & Image_Name)
            If Menu_Button("Iq_0999") = True Then
                Create_Button(Image_Name, "Iq_0999")
            End If
        End If
        MenuItem999.Tag = "Iq_0999"
        AddHandler MenuItem999.Click, AddressOf Items_Menu_Click
        Dim MenuItemAbout As New ToolStripMenuItem("Acerca De...")
        Image_Name = Menu_Icon("Iq_About")
        If Image_Name <> Nothing Then
            MenuItemAbout.Image = Image.FromFile(Icon_Folder & Image_Name)
            If Menu_Button("Iq_About") = True Then
                Create_Button(Image_Name, "Iq_About")
            End If
        End If
        MenuItemAbout.Tag = "Iq_About"
        MenuIQ.Items.Add(MenuItemAbout)
        AddHandler MenuItemAbout.Click, AddressOf Items_Menu_Click
        MenuItem902.Visible = True
        MenuItem999.Visible = True
    End Sub
    Private Sub TimerWarning_Tick(sender As Object, e As EventArgs) Handles TimerWarning.Tick
        TimerWarning.Enabled = False
        TimerWarning.Stop()
        Dim Carga_Coneccion_O2 As New OleDb.OleDbConnection(Cnn_Central_Server)
        Carga_Coneccion_O2.Open()
        Dim instruc_warning As String
        instruc_warning = "select count(codoficina) from IQ_VwAlertasASFI where (saldo < 0 or (saldo > 0 and (saldo / plazo) < 0.1))"
        If Warning_Parameter = "A" Then
            instruc_warning = instruc_warning & " And IQ_VwAlertasASFI.CodOficina = '" & Computer_Ofic & "'"
        End If
        Try
            instruc_warning = instruc_warning & " And CONVERT(VARCHAR(10), Emision, 111) = '" & Format(DateAdd(DateInterval.Second, desfase_segundos, Date.Now), "yyyy/MM/dd") & "'"
        Catch ex As Exception
            instruc_warning = instruc_warning & " And CONVERT(VARCHAR(10), Emision, 111) = '" & Format(DateAdd(DateInterval.Second, 0, Date.Now), "yyyy/MM/dd") & "'"
        End Try
        Dim num_warnings As Integer = 0
        Dim Carga_Comando_O2 As New OleDb.OleDbCommand(instruc_warning, Carga_Coneccion_O2)
        Dim Carga_Reader_O2 As OleDb.OleDbDataReader = Carga_Comando_O2.ExecuteReader(CommandBehavior.CloseConnection)
        While Carga_Reader_O2.Read
            If IsDBNull(Carga_Reader_O2.GetValue(0)) = False Then
                num_warnings = Carga_Reader_O2.GetValue(0)
            End If
        End While
        Carga_Coneccion_O2.Dispose()
        If num_warnings > 0 Then
            Dim RESP_WARNING = MessageBox.Show("EXISTEN " & CStr(num_warnings) & " ALERTAS PREVIAS. ¿Desea reporte?", Me.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If RESP_WARNING = Windows.Forms.DialogResult.Yes Then
                Dim doc As IQ_W0001 = New IQ_W0001
                doc.Visible = False
                doc.ShowDialog()
                TimerWarning.Enabled = True
                TimerWarning.Start()
            ElseIf RESP_WARNING = Windows.Forms.DialogResult.No Then
                TimerWarning.Enabled = True
                TimerWarning.Start()
            End If
        End If
    End Sub
End Class