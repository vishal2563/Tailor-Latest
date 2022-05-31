Imports System.Data.SqlClient
Imports System.Data
Imports System.IO

Module connection

    Public cnn, cnn1, cnn2, cnn3, cnn4 As New SqlConnection
    Public loginflag As String = "N"
    Public firm As Integer = "0"
    Public LeaveCalc As String = " "
    Public FirmFormOpen As String = " "
    Public SqlServerName() As String
    Public SqlDataBase() As String
    Public SqlUserId() As String
    Public SqlPassword() As String
    Public currentuser As String = ""
    Public editdelivery As Boolean
    Public editdeliverystatus As Boolean
    Public print_billno As Integer = 0

    'Public str As String = readpath() & "User Id=sa;Password=zipzap"
    Public str As String = readpath() & "User Id=sa;Password=sa@123"

    Public Sub myglobal()
        Dim aa() As String = str.Split(";")
        SqlServerName = aa(0).Split("=")
        SqlDataBase = aa(1).Split("=")
        SqlUserId = aa(2).Split("=")
        SqlPassword = aa(3).Split("=")
    End Sub

    Public Function App_Path() As String
        Return System.AppDomain.CurrentDomain.BaseDirectory()
    End Function

    Public Function readpath() As String
        Dim path As String = App_Path() & "\datapath.txt"
        Dim d As String
        Try
            Dim sr As StreamReader = New StreamReader(path)
            d = sr.ReadLine()

            sr.Close()
            Return d
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Sub openconn()
        'cnn = New SqlConnection("Data Source=" & SqlServerName & "; user id=" & SqlUserId & "; password=" & SqlPassword & ";Initial Catalog=" & SqlDataBase & ";")
        cnn = New SqlConnection(str)
        cnn.Open()
    End Sub

    Public Sub closeconn()
        cnn.Close()
    End Sub

    Public Sub openconn1()
        cnn1 = New SqlConnection(str)
        cnn1.Open()
    End Sub

    Public Sub closeconn1()
        cnn1.Close()
    End Sub

    Public Sub openconn2()
        cnn2 = New SqlConnection(str)
        cnn2.Open()
    End Sub

    Public Sub closeconn2()
        cnn2.Close()
    End Sub

    Public Sub openconn3()
        cnn3 = New SqlConnection(str)
        cnn3.Open()
    End Sub

    Public Sub closeconn3()
        cnn3.Close()
    End Sub

    Public Sub openconn4()
        cnn4 = New SqlConnection(str)
        cnn4.Open()
    End Sub

    Public Sub closeconn4()
        cnn4.Close()
    End Sub
     
    Public Function autonum(ByVal col As String, ByVal table As String) As Integer
        openconn()
        Dim i As Integer = 0
        Dim cmd As SqlCommand
        Dim drd As SqlDataReader
        cmd = New SqlCommand("select max(" & col & ") as temp from " & table & " ", cnn)
        drd = cmd.ExecuteReader
        If drd.Read = True Then
            i = IIf(IsDBNull(drd("temp")), 0, drd("temp"))
            i = i + 1
        End If
        drd.Close()
        closeconn()
        Return i
    End Function


    Public Function autonum2(ByVal col As String, ByVal table As String, ByVal username As String) As Integer
        openconn()
        Dim i As Integer = 0
        Dim cmd As SqlCommand
        Dim drd As SqlDataReader
        cmd = New SqlCommand("select max(" & col & ") as temp from " & table & " where username='" & username & "'", cnn)
        drd = cmd.ExecuteReader
        If drd.Read = True Then
            i = IIf(IsDBNull(drd("temp")), 0, drd("temp"))
            i = i + 1
        End If
        drd.Close()
        closeconn()
        Return i
    End Function


    Public Sub exportme(ByVal datagridview1 As DataGridView)

        Dim strfn2 As String = System.IO.Path.GetTempFileName
        Dim tempfileattb() As String = Split(strfn2, ".")
        Dim tempfilename As String = tempfileattb(0) & ".xls"
        Dim fs As New IO.StreamWriter(tempfilename, False)
        fs.WriteLine("<?xml version=""1.0""?>")
        fs.WriteLine("<?mso-application progid=""Excel.Sheet""?>")
        fs.WriteLine("<ss:Workbook xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet"">")
        fs.WriteLine("    <ss:Styles>")
        fs.WriteLine("        <ss:Style ss:ID=""1"">")
        fs.WriteLine("           <ss:Font ss:Bold=""1""/>")
        fs.WriteLine("        </ss:Style>")
        fs.WriteLine("    </ss:Styles>")
        fs.WriteLine("    <ss:Worksheet ss:Name=""Sheet1"">")
        fs.WriteLine("        <ss:Table>")
        For x As Integer = 0 To datagridview1.Columns.Count - 1
            fs.WriteLine("            <ss:Column ss:Width=""{0}""/>",
                         datagridview1.Columns.Item(x).Width)
        Next
        fs.WriteLine("            <ss:Row ss:StyleID=""1"">")
        For i As Integer = 0 To datagridview1.Columns.Count - 1
            fs.WriteLine("                <ss:Cell>")
            fs.WriteLine(String.Format(
                         "                   <ss:Data ss:Type=""String"">{0}</ss:Data>",
                                       datagridview1.Columns.Item(i).HeaderText))
            fs.WriteLine("                </ss:Cell>")
        Next
        fs.WriteLine("            </ss:Row>")
        For intRow As Integer = 0 To datagridview1.RowCount - 1
            fs.WriteLine(String.Format("            <ss:Row ss:Height =""{0}"">",
                                       datagridview1.Rows(intRow).Height))
            For intCol As Integer = 0 To datagridview1.Columns.Count - 1
                fs.WriteLine("                <ss:Cell>")

                Dim cellvalue As String
                cellvalue = IIf(IsDBNull(datagridview1.Rows(intRow).Cells(intCol).Value), "", datagridview1.Rows(intRow).Cells(intCol).Value)
                If cellvalue = Nothing Then
                    cellvalue = ""
                End If
                fs.WriteLine(String.Format(
                             "                   <ss:Data ss:Type=""String"">{0}</ss:Data>",
                                           IIf(cellvalue Is Nothing, "", cellvalue.ToString)))
                fs.WriteLine("                </ss:Cell>")
            Next
            fs.WriteLine("            </ss:Row>")
        Next
        fs.WriteLine("        </ss:Table>")
        fs.WriteLine("    </ss:Worksheet>")
        fs.WriteLine("</ss:Workbook>")
        fs.Close()
        'MsgBox("File Exported to d:\exported.xls")
        Process.Start(tempfilename)
    End Sub
End Module
