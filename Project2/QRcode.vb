Imports System.Drawing
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports Microsoft.Office.Interop.Word
Imports ZXing
Imports MongoDB.Bson
Imports MongoDB.Driver
Imports System.Threading

Public Class QRcode

    Dim mainRegex As Regex = New Regex("(?<cccd>\d{12})\|(?<cmnd>(\d{9})?)\|(?<name>[^|]+)\|\d{4}(?<YoB>\d{4})\|(?<sex>(Nam|Nữ))\|(?<address>[^|]+)\|(?<dateOfIssue>(\d{8})?)", RegexOptions.IgnoreCase)

    Dim client As New MongoClient("mongodb+srv://tama:tama@tama.kzznzu2.mongodb.net/")
    Dim database As IMongoDatabase = client.GetDatabase("Notary")
    Dim collection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("QRcode")

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim matches = mainRegex.Matches(TextBox1.Text)
        If matches.Count > 0 Then
            Label1.Text = $"Thành công. Số lượng: {matches.Count}"
            Label1.BackColor = Color.LightBlue
            For Each match In matches
                SaveQR(match.value.ToString)
            Next
            Load20FirstQR()
        Else
            Label1.Text = "Sai định dạng"
            Label1.BackColor = Color.MistyRose
        End If
    End Sub

    Private Function QrToDsformatted(text As String) As List(Of String)
        Dim matches = mainRegex.Matches(text.TrimEnd)

        Dim result As New List(Of String)()

        If matches.Count > 0 Then

            For Each match In matches
                Dim customer As New NotaryCustomer
                customer.CCCD = match.Groups("cccd").Value
                customer.CMND = match.Groups("cmnd").Value
                customer.Ten = match.Groups("name").Value.ToUpper()
                customer.Sn = match.Groups("YoB").Value
                customer.TT = match.Groups("address").Value

                If match.Groups("sex").Value = "Nam" Then
                    customer.Gt = "Ông"
                Else
                    customer.Gt = "Bà"
                End If

                result.Add(customer.ExportCustomer())
                customer = Nothing
            Next
        Else
            Return Nothing
        End If

        Return result

    End Function
    Private Sub ExportDStoDocument(QRcode As String)
        Dim iApp = Globals.ThisAddIn.Application

        Dim iRange As Word.Range = iApp.Selection.Range
        iRange.ParagraphFormat.TabStops.ClearAll()
        iRange.ParagraphFormat.TabStops.Add(Position:=iApp.CentimetersToPoints(5.25), Alignment:=WdAlignmentTabAlignment.wdLeft, Leader:=WdTabLeader.wdTabLeaderSpaces)

        Try
            If Regex.IsMatch(iRange.Text, "\s$") Then iRange.MoveEnd(WdUnits.wdCharacter, -1)
        Catch ex As Exception
        End Try

        If Trim(iRange.Text) = "" Then
            iRange.InsertParagraphAfter()
            iRange.MoveEnd(Word.WdUnits.wdParagraph, -1)
        End If

        Dim ds = QrToDsformatted(QRcode)
        Dim result As String
        If ds IsNot Nothing Then
            For Each i In ds
                result &= $"{i}{vbCr}"
            Next
        End If
        iRange.Text = result.TrimEnd
    End Sub
    Private Sub PasteClick(sender As Object, e As EventArgs) Handles PasteToDoc.Click

        ExportDStoDocument(TextBox1.Text)

    End Sub

    Private cts As CancellationTokenSource = Nothing ' CancellationTokenSource to cancel the previous action
    Private Async Sub Load20FirstQR()
        ' Cancel the previous action if it's running
        If cts IsNot Nothing Then
            cts.Cancel()
        End If

        ' Create a new CancellationTokenSource
        cts = New CancellationTokenSource()

        Try

            Dim documents As List(Of BsonDocument) = Await System.Threading.Tasks.Task.Run(
                Function()
                    ' Retrieve the newest 20 records from the collection
                    Dim filter As FilterDefinition(Of BsonDocument) = Builders(Of BsonDocument).Filter.Empty
                    Dim sort As SortDefinition(Of BsonDocument) = Builders(Of BsonDocument).Sort.Descending("AccessTime")
                    Return collection.Find(filter).Sort(sort).Limit(20).ToList()
                End Function,
            cts.Token) ' Pass the CancellationToken to the Task.Run method

            ' Update the ListBox with the retrieved records on the UI thread
            DsListview.Invoke(
                Sub()
                    DsListview.BeginUpdate()
                    DsListview.Items.Clear()

                    For Each document As BsonDocument In documents
                        Dim qrCode As String = document.GetValue("QRcode").ToString()
                        Dim match = mainRegex.Match(qrCode)
                        Dim item As New ListViewItem({match.Groups("name").Value, match.Groups("YoB").Value, match.Groups("cccd").Value})
                        item.Tag = qrCode
                        DsListview.Items.Add(item)
                    Next
                    DsListview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
                    DsListview.EndUpdate()
                End Sub)
        Catch ex As OperationCanceledException
            ' The operation was canceled, handle as needed
            Console.WriteLine("Previous action was canceled.")
        Finally
            ' Reset the CancellationTokenSource
            cts = Nothing
        End Try
    End Sub
    Private Sub SaveQR(text As String)
        Dim matches = mainRegex.Matches(text.TrimEnd)

        If matches.Count = 0 Then Exit Sub

        ' Build the filter to check if the QR code exists
        Dim filter As FilterDefinition(Of BsonDocument) = Builders(Of BsonDocument).Filter.Eq(Of String)("QRcode", text)

        ' Find the document that matches the filter
        Dim existingDocument As BsonDocument = collection.Find(filter).FirstOrDefault()

        If existingDocument Is Nothing Then
            Dim newRecord As BsonDocument = New BsonDocument()
            newRecord("QRcode") = text
            newRecord("CreatedDate") = DateTime.Now
            newRecord("AccessTime") = DateTime.Now

            collection.InsertOne(newRecord)

            Console.WriteLine("New record saved successfully.")
        Else
            Console.WriteLine("QR code already exists in the collection.")
            UpdateAccessDate(text)
        End If

    End Sub
    Private Async Sub UpdateAccessDate(qrCodeToAccess As String)

        ' Update access time for read or write action
        Dim filter As FilterDefinition(Of BsonDocument) = Builders(Of BsonDocument).Filter.Eq(Of String)("QRcode", qrCodeToAccess)
        Dim update As UpdateDefinition(Of BsonDocument) = Builders(Of BsonDocument).Update.Set(Of Date)("AccessTime", DateTime.Now)

        ' Perform the read or write action and update the access time field
        Dim updateResult As UpdateResult = Await collection.UpdateOneAsync(filter, update)

        If updateResult.ModifiedCount > 0 Then
            Console.WriteLine("Access time updated successfully.")
        Else
            Console.WriteLine("Record not found.")
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim a As New OpenFileDialog
        If a.ShowDialog() = DialogResult.Cancel Then Exit Sub
        Dim filePath = a.FileName.ToString()
        Dim barcodeReader As New BarcodeReader()

        Dim result As Result = barcodeReader.Decode(New Bitmap(filePath))

        If result IsNot Nothing Then
            Dim qrCodeText As String = result.Text
            TextBox1.Text = qrCodeText
            Label1.Text = "Thành công"
            Label1.BackColor = Color.LightBlue
        Else
            Label1.Text = "Failed to read QR code"
            Label1.BackColor = Color.MistyRose
        End If

    End Sub
    Private Sub TextBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseDoubleClick
        TextBox1.SelectAll()
    End Sub
    Private Sub QRcode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load20FirstQR()
        'LoadAllQRDocuments()
    End Sub
    Private Sub DsListview_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DsListview.MouseDoubleClick
        Dim QRcode = DsListview.SelectedItems.Item(0).Tag.ToString
        ExportDStoDocument(QRcode)
    End Sub

    Private qrDocuments As List(Of BsonDocument) ' List to store all QR documents
    Private Sub LoadAllQRDocuments()
        qrDocuments = collection.Find(New BsonDocument()).ToList()
    End Sub
    Private Sub TextBox2_GotFocus(sender As Object, e As EventArgs) Handles SearchBox.GotFocus
        LoadAllQRDocuments()
    End Sub

    Private Sub SearchBox_TextChanged(sender As Object, e As EventArgs) Handles SearchBox.TextChanged
        Dim searchQuery As String = SearchBox.Text.Trim().ToLower()

        DsListview.BeginUpdate()
        ' Clear the ListBox to remove previous search results
        DsListview.Items.Clear()

        ' Iterate over the QR documents and check for matches
        For Each document As BsonDocument In qrDocuments
            Dim qrCode As String = document.GetValue("QRcode").ToString().ToLower

            If qrCode.Contains(searchQuery) Then
                Dim match = mainRegex.Match(document.GetValue("QRcode").ToString())
                Dim item As New ListViewItem({match.Groups("name").Value, match.Groups("YoB").Value, match.Groups("cccd").Value})
                item.Tag = document.GetValue("QRcode").ToString()
                DsListview.Items.Add(item)
            End If
        Next
        DsListview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        DsListview.EndUpdate()
    End Sub

    Public Shared Sub Main(args As String())
        ' Configure the MongoDB connection string and database name
        Dim connectionString As String = "mongodb://localhost:27017"
        Dim databaseName As String = "mydatabase"

        ' Create a MongoClient to connect to the MongoDB server
        Dim client As New MongoClient(connectionString)

        ' Get a reference to the database
        Dim database As IMongoDatabase = client.GetDatabase(databaseName)

        ' Get a reference to the collection
        Dim collection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("mycollection")

        ' Create the new document
        Dim newDocument As New BsonDocument()
        newDocument.Add("name", "BÙI MINH TRƯỜNG")
        newDocument.Add("sex", "Ông")
        newDocument.Add("YoB", "1969")
        newDocument.Add("IDcard", New BsonDocument("CCCD", "012069000031").Add("CMND", "024370572"))
        newDocument.Add("address", "29/27 Đoàn Thị Điểm, Phường 1, quận Phú Nhuận, TP. Hồ Chí Minh")

        ' Check if a user with matching ID card exists
        Dim filter As FilterDefinition(Of BsonDocument) = Builders(Of BsonDocument).Filter.AnyEq("IDcard.CCCD", "012069000031") Or
                                                        Builders(Of BsonDocument).Filter.AnyEq("IDcard.CMND", "024370572")
        Dim existingDocument As BsonDocument = collection.Find(filter).FirstOrDefault()

        If existingDocument IsNot Nothing Then
            ' Update the existing document
            Dim updateFilter As FilterDefinition(Of BsonDocument) = Builders(Of BsonDocument).Filter.AnyEq("_id", existingDocument("_id"))
            'Dim update As UpdateDefinition(Of BsonDocument) = Builders(Of BsonDocument).Update.Set("name", newDocument("name"))

            'collection.UpdateOne(updateFilter, update)

            Console.WriteLine("Document updated successfully.")
        Else
            ' Insert the new document
            collection.InsertOne(newDocument)

            Console.WriteLine("Document inserted successfully.")
        End If
    End Sub
    Private Sub SaveQrxxx(text As String)
        Dim regex As Regex = New Regex("\b(?<cccd>\d{12})\|(?<cmnd>\d*)\|(?<name>[^|]+)\|\d{4}(?<YoB>\d{4})\|(?<sex>(Nam|Nữ))\|(?<address>[^|]+)\|(?<dateOfIssue>\d+)\b")
        Dim match As Match = regex.Match(text.TrimEnd)

        If Not match.Success Then Exit Sub

        Dim client As New MongoClient("mongodb+srv://tama:tama@tama.kzznzu2.mongodb.net/")
        Dim database As IMongoDatabase = client.GetDatabase("Notary")
        Dim collection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("Customer")

        Dim IDcard = New BsonDocument()
        IDcard.Add("CCCD", match.Groups("cccd").Value)
        If match.Groups("cmnd").Value.Length > 0 Then
            IDcard.Add("CMND", match.Groups("cmnd").Value)
        End If

        Dim customer As New BsonDocument()
        customer.Add("name", match.Groups("name").Value.ToUpper())

        If match.Groups("sex").Value = "Nam" Then
            customer.Add("sex", "Ông")
        Else
            customer.Add("sex", "Bà")
        End If

        customer.Add("YoB", match.Groups("YoB").Value)
        customer.Add("IDcard", IDcard)
        customer.Add("address", match.Groups("address").Value)
        customer.Add("QrCode", text)

        Dim filter As FilterDefinition(Of BsonDocument) = Builders(Of BsonDocument).Filter.AnyEq("IDcard.CCCD", "012069000031")


    End Sub

    Private Sub DsListview_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DsListview.SelectedIndexChanged

    End Sub

End Class