Imports System.Drawing
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports Microsoft.Office.Interop.Word
Imports ZXing
Imports MongoDB.Bson
Imports MongoDB.Driver
Imports MongoDB.Driver.Core.Configuration

Public Class QRcode
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim result As String = QrAnalyzer(TextBox1.Text)
        If result = "Sai định dạng" Then
            Label1.Text = "Sai định dạng"
            Label1.BackColor = Color.MistyRose
        End If
    End Sub
    Private Function QrAnalyzer(text As String) As String
        Dim regex As Regex = New Regex("(?<cccd>\d{12})\|(?<cmnd>(\d{9})?)\|(?<name>[^|]+)\|\d{4}(?<YoB>\d{4})\|(?<sex>(Nam|Nữ))\|(?<address>[^|]+)\|(?<dateOfIssue>\d{8})")
        Dim matches = regex.Matches(text.TrimEnd)

        Dim result As String = ""

        If matches.Count > 0 Then
            Label1.Text = $"Thành công. Số lượng: {matches.Count}"
            Label1.BackColor = Color.LightBlue
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

                result &= $"{customer.ExportCustomer()}{vbCr}"
                customer = Nothing
            Next
        Else
            Return "Sai định dạng"
        End If

        Return result.TrimEnd

    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

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
        iRange.Text = QrAnalyzer(TextBox1.Text)
    End Sub

    Private Sub TextBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseDoubleClick
        TextBox1.SelectAll()
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'My.Computer.Clipboard.SetText(QrAnalyzer(TextBox1.Text))

        'MongodbTesting()

    End Sub
    Private Sub SaveQr(text As String)
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
    Sub MongodbTesting()
        ' Configure the MongoDB connection string and database name
        Dim connectionString As String = "mongodb+srv://tama:tama@tama.kzznzu2.mongodb.net/"
        Dim databaseName As String = "mydatabaseTesting"

        ' Create a MongoClient to connect to the MongoDB server
        Dim client As New MongoClient(connectionString)

        ' Get a reference to the database
        Dim database As IMongoDatabase = client.GetDatabase(databaseName)

        ' Get a reference to the collection
        Dim collection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("mycollection")

        ' Insert a document
        Dim document As New BsonDocument()
        document.Add("name", "John Doe")
        document.Add("age", 30)
        collection.InsertOne(document)

        ' Find documents
        Dim filter As New BsonDocument("name", "John Doe")
        Dim result = collection.Find(filter).ToList()

        ' Update a document
        Dim updateFilter As New BsonDocument("name", "John Doe")
        Dim update As New BsonDocument("$set", New BsonDocument("age", 35))
        collection.UpdateOne(updateFilter, update)

        ' Delete a document
        'Dim deleteFilter As New BsonDocument("name", "John Doe")
        'collection.DeleteOne(deleteFilter)
    End Sub
End Class