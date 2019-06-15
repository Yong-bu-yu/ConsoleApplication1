'visual Basic
Option Explicit On
Option Strict On
Imports System
Imports System.IO
Class MyStream
    Private Const FILE_NAME As String = "Test.data"
    Public Shared Sub Main()
        'Create the new, empty data file.
        If File.Exists(FILE_NAME) Then
            Console.WriteLine("{0} already exists!", FILE_NAME)
            Return
        End If
        Dim fs As New FileStream(FILE_NAME, FileMode.CreateNew)
        'Create the writer for data.
        Dim w As New BinaryWriter(fs)
        'Write data to Test.data.
        Dim i As Integer
        For i = 0 To 10
            w.Write(CInt(i))
        Next i
        w.Close()
        fs.Close()
        'Create the reader for data.
        fs = New FileStream(FILE_NAME, FileMode.Open, FileAccess.Read)
        Dim r As New BinaryReader(fs)
        'Read data from Test.data.
        For i = 0 To 10
            Console.WriteLine(r.ReadInt32())
            w.Close()
        Next i
    End Sub
End Class

