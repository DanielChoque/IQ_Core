Imports System.Data.SQLClient
Imports System.Data.OleDb
Imports System.IO
Imports System

Public Class ColeccionAccesos
    Inherits System.Collections.DictionaryBase

    Public Sub Add(ByVal Key As String, ByVal Item As String)
        dictionary.Add(Key, Item)
    End Sub

    Public Function Valor_Permiso(ByVal Key As String) As String
        Valor_Permiso = Dictionary.Item(UCase(Key))
    End Function
End Class
Public Class IQ_Security
    Inherits System.ComponentModel.Component

    Public Shared Function Encriptado(ByVal Aux As String) As String
        Dim suma_total As Double
        Dim indice_encript As Integer
        suma_total = 0
        For indice_encript = 1 To Len(Aux)
            suma_total = suma_total + (Asc(Mid(Aux, indice_encript, 1))) * indice_encript
        Next
        Encriptado = CStr(suma_total)
    End Function

    Public Shared Sub Carga_Permisos(ByVal Rol As String, ByVal Operador As String)
        Dim Instruccion As String = ""
        Dim Val_Permisos As Byte
        If Rol <> "" Then
            Instruccion = "Select * from Iq_Permisos where IqPerm_Rol = '" + Rol + "'"
            Dim Security_Coneccion As New OleDb.OleDbConnection(Cnn_Central_Server)
            Dim Security_Comando As New OleDb.OleDbCommand(Instruccion, Security_Coneccion)
            Security_Coneccion.Open()
            DictAccesos.Clear()
            Dim Security_Reader As OleDb.OleDbDataReader = Security_Comando.ExecuteReader(CommandBehavior.CloseConnection)
            While Security_Reader.Read
                Val_Permisos = Security_Reader.GetValue(2)
                DictAccesos.Add(UCase(Security_Reader.GetValue(1)), Val_Permisos.ToString)
            End While
        End If
    End Sub

End Class
