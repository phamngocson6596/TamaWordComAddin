<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MyPanel
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
        Me.InfoTextbox = New System.Windows.Forms.TextBox()
        Me.PrintPDFWorker = New System.ComponentModel.BackgroundWorker()
        Me.SignListview = New System.Windows.Forms.ListView()
        Me.Ten = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SignSearch = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.FindBossButton = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'InfoTextbox
        '
        Me.InfoTextbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.InfoTextbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.InfoTextbox.BackColor = System.Drawing.SystemColors.Info
        Me.InfoTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.InfoTextbox.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.InfoTextbox.Enabled = False
        Me.InfoTextbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.InfoTextbox.ForeColor = System.Drawing.Color.Blue
        Me.InfoTextbox.Location = New System.Drawing.Point(0, 433)
        Me.InfoTextbox.Multiline = True
        Me.InfoTextbox.Name = "InfoTextbox"
        Me.InfoTextbox.Size = New System.Drawing.Size(986, 70)
        Me.InfoTextbox.TabIndex = 8
        Me.InfoTextbox.TabStop = False
        '
        'PrintPDFWorker
        '
        Me.PrintPDFWorker.WorkerReportsProgress = True
        '
        'SignListview
        '
        Me.SignListview.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Ten})
        Me.SignListview.HideSelection = False
        Me.SignListview.Location = New System.Drawing.Point(18, 57)
        Me.SignListview.Name = "SignListview"
        Me.SignListview.Size = New System.Drawing.Size(258, 236)
        Me.SignListview.TabIndex = 12
        Me.SignListview.UseCompatibleStateImageBehavior = False
        '
        'Ten
        '
        Me.Ten.Text = "Tên"
        '
        'SignSearch
        '
        Me.SignSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.SignSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.SignSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.SignSearch.Location = New System.Drawing.Point(18, 28)
        Me.SignSearch.Name = "SignSearch"
        Me.SignSearch.Size = New System.Drawing.Size(258, 23)
        Me.SignSearch.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(18, 298)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(67, 25)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "In"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FindBossButton
        '
        Me.FindBossButton.Location = New System.Drawing.Point(209, 298)
        Me.FindBossButton.Margin = New System.Windows.Forms.Padding(2)
        Me.FindBossButton.Name = "FindBossButton"
        Me.FindBossButton.Size = New System.Drawing.Size(67, 25)
        Me.FindBossButton.TabIndex = 10
        Me.FindBossButton.Text = "Check"
        Me.FindBossButton.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SignSearch)
        Me.GroupBox1.Controls.Add(Me.FindBossButton)
        Me.GroupBox1.Controls.Add(Me.SignListview)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Location = New System.Drawing.Point(676, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(310, 340)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'MyPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.InfoTextbox)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "MyPanel"
        Me.Size = New System.Drawing.Size(986, 503)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents InfoTextbox As Windows.Forms.TextBox
    Friend WithEvents PrintPDFWorker As ComponentModel.BackgroundWorker
    Friend WithEvents SignListview As Windows.Forms.ListView
    Friend WithEvents SignSearch As Windows.Forms.TextBox
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents FindBossButton As Windows.Forms.Button
    Private WithEvents Ten As Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
End Class
