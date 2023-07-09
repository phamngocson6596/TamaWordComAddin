<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class QRcode
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PasteToDoc = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.DsListview = New System.Windows.Forms.ListView()
        Me.TenColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SnColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CmtColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SearchBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label1.Location = New System.Drawing.Point(4, 223)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 16)
        Me.Label1.TabIndex = 7
        '
        'PasteToDoc
        '
        Me.PasteToDoc.Location = New System.Drawing.Point(4, 185)
        Me.PasteToDoc.Margin = New System.Windows.Forms.Padding(4)
        Me.PasteToDoc.Name = "PasteToDoc"
        Me.PasteToDoc.Size = New System.Drawing.Size(164, 33)
        Me.PasteToDoc.TabIndex = 5
        Me.PasteToDoc.Text = "Dán vào văn bản"
        Me.PasteToDoc.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.AllowDrop = True
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(4, 4)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(383, 214)
        Me.TextBox1.TabIndex = 4
        '
        'Button3
        '
        Me.Button3.BackgroundImage = Global.Project2.My.Resources.Resources.qr_code__2_
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button3.Location = New System.Drawing.Point(351, 185)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(37, 34)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "QR"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'DsListview
        '
        Me.DsListview.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.TenColumn, Me.SnColumn, Me.CmtColumn})
        Me.DsListview.FullRowSelect = True
        Me.DsListview.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.DsListview.HideSelection = False
        Me.DsListview.Location = New System.Drawing.Point(4, 258)
        Me.DsListview.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DsListview.MultiSelect = False
        Me.DsListview.Name = "DsListview"
        Me.DsListview.Size = New System.Drawing.Size(383, 196)
        Me.DsListview.TabIndex = 9
        Me.DsListview.UseCompatibleStateImageBehavior = False
        Me.DsListview.View = System.Windows.Forms.View.Details
        '
        'TenColumn
        '
        Me.TenColumn.Text = "Tên"
        Me.TenColumn.Width = 123
        '
        'SnColumn
        '
        Me.SnColumn.Text = "Sn"
        Me.SnColumn.Width = 38
        '
        'CmtColumn
        '
        Me.CmtColumn.Text = "CMT"
        Me.CmtColumn.Width = 116
        '
        'SearchBox
        '
        Me.SearchBox.Location = New System.Drawing.Point(4, 459)
        Me.SearchBox.Name = "SearchBox"
        Me.SearchBox.Size = New System.Drawing.Size(384, 22)
        Me.SearchBox.TabIndex = 10
        '
        'QRcode
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SearchBox)
        Me.Controls.Add(Me.DsListview)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PasteToDoc)
        Me.Controls.Add(Me.TextBox1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "QRcode"
        Me.Size = New System.Drawing.Size(400, 520)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents PasteToDoc As Windows.Forms.Button
    Friend WithEvents TextBox1 As Windows.Forms.TextBox
    Friend WithEvents Button3 As Windows.Forms.Button
    Friend WithEvents DsListview As Windows.Forms.ListView
    Friend WithEvents TenColumn As Windows.Forms.ColumnHeader
    Friend WithEvents SnColumn As Windows.Forms.ColumnHeader
    Friend WithEvents CmtColumn As Windows.Forms.ColumnHeader
    Friend WithEvents SearchBox As Windows.Forms.TextBox
End Class
