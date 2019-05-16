Public Class DataGridComboBoxColumn
    Inherits DataGridTextBoxColumn
    Public ColumnComboBox As ComboSinKeyUp 'Atención aquí con esta declaración
    Private _Origen As System.Windows.Forms.CurrencyManager
    Private _NroRenglon As Integer
    Private _EstaEditando As Boolean
    Public Shared RowCount As Integer

    Public Sub New()
        _Origen = Nothing
        _EstaEditando = False
        RowCount = -1

        ColumnComboBox = New ComboSinKeyUp
        ColumnComboBox.DropDownStyle = ComboBoxStyle.DropDownList

        AddHandler ColumnComboBox.Leave, AddressOf DejaComboBox
        AddHandler ColumnComboBox.SelectionChangeCommitted, AddressOf ComienzaEditarCombo
    End Sub

    Private Sub ManejaScroll(ByVal sender As Object, ByVal e As EventArgs)
        If ColumnComboBox.Visible Then
            ColumnComboBox.Hide()
        End If
    End Sub

    Private Sub ComienzaEditarCombo(ByVal sender As Object, ByVal e As EventArgs)
        _EstaEditando = True
        MyBase.ColumnStartedEditing(sender)
    End Sub

    Private Sub DejaComboBox(ByVal sender As Object, ByVal e As EventArgs)
        If _EstaEditando Then
            SetColumnValueAtRow(_Origen, _NroRenglon, ColumnComboBox.Text)
            _EstaEditando = False
            Invalidate()

        End If
        ColumnComboBox.Hide()
        AddHandler Me.DataGridTableStyle.DataGrid.Scroll, New EventHandler(AddressOf ManejaScroll)
    End Sub

    Protected Overloads Overrides Sub Edit(ByVal [source] As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal bounds As System.Drawing.Rectangle, ByVal [readOnly] As Boolean, ByVal instantText As String, ByVal cellIsVisible As Boolean)

        MyBase.Edit([source], rowNum, bounds, [readOnly], instantText, cellIsVisible)

        _NroRenglon = rowNum
        _Origen = [source]

        ColumnComboBox.Parent = Me.TextBox.Parent
        ColumnComboBox.Location = Me.TextBox.Location
        ColumnComboBox.Size = New Size(Me.TextBox.Size.Width, ColumnComboBox.Size.Height)
        ColumnComboBox.SelectedIndex = ColumnComboBox.FindStringExact(Me.TextBox.Text)
        ColumnComboBox.Text = Me.TextBox.Text
        Me.TextBox.Visible = False
        ColumnComboBox.Visible = True
        AddHandler Me.DataGridTableStyle.DataGrid.Scroll, AddressOf ManejaScroll

        ColumnComboBox.BringToFront()
        ColumnComboBox.Focus()
    End Sub


    Protected Overrides Function Commit(ByVal dataSource As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer) As Boolean

        If _EstaEditando Then
            _EstaEditando = False
            SetColumnValueAtRow(dataSource, rowNum, ColumnComboBox.Text)
        End If
        Return True
    End Function

    Protected Overrides Sub ConcedeFocus()
        MyBase.ConcedeFocus()
    End Sub

    Protected Overrides Function GetColumnValueAtRow(ByVal [source] As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer) As Object

        Dim s As Object = MyBase.GetColumnValueAtRow([source], rowNum)
        Dim dv As DataView = CType(Me.ColumnComboBox.DataSource, DataView)
        Dim rowCount As Integer = dv.Count
        Dim i As Integer = 0
        Dim s1 As Object

        While i < rowCount
            s1 = dv(i)(Me.ColumnComboBox.ValueMember)
            If (Not s1 Is DBNull.Value) AndAlso _
            (Not s Is DBNull.Value) AndAlso _
            s = s1 Then
                Exit While
            End If
            i = i + 1
        End While

        If i < rowCount Then
            Return dv(i)(Me.ColumnComboBox.DisplayMember)
        End If
        Return DBNull.Value
    End Function

    Protected Overrides Sub SetColumnValueAtRow(ByVal [source] As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal value As Object)
        Dim s As Object = value

        Dim dv As DataView = CType(Me.ColumnComboBox.DataSource, DataView)
        Dim rowCount As Integer = dv.Count
        Dim i As Integer = 0
        Dim s1 As Object

        While i < rowCount
            s1 = dv(i)(Me.ColumnComboBox.DisplayMember)
            If (Not s1 Is DBNull.Value) AndAlso _
            s = s1 Then
                Exit While
            End If
            i = i + 1
        End While
        If i < rowCount Then
            s = dv(i)(Me.ColumnComboBox.ValueMember)
        Else
            s = DBNull.Value
        End If
        MyBase.SetColumnValueAtRow([source], rowNum, s)
    End Sub
End Class

Public Class ComboSinKeyUp
    Inherits ComboBox
    Private WM_KEYUP As Integer = &H101

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WM_KEYUP Then
            'Ignora el keyup para evita problemas de tabulación
            Return
        End If
        MyBase.WndProc(m)
    End Sub
End Class


