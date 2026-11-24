Imports MySql.Data.MySqlClient

Module Conexion
    Public cnn As New MySqlConnection("server=127.0.0.1;port=3306;user id=root;password=;database=canchitas")

    Public Sub AbrirConexion()
        If cnn.State = ConnectionState.Closed Then
            cnn.Open()
        End If
    End Sub

    Public Sub CerrarConexion()
        If cnn.State = ConnectionState.Open Then
            cnn.Close()
        End If
    End Sub

End Module
