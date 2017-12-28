<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class transaction_Search
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.transSearchBox = New System.Windows.Forms.TextBox()
        Me.viewDetails = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel32 = New System.Windows.Forms.Panel()
        Me.Button22 = New System.Windows.Forms.Button()
        Me.Button21 = New System.Windows.Forms.Button()
        Me.searchPaginateCounter = New System.Windows.Forms.Label()
        Me.transListView = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel32.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Label80)
        Me.Panel1.Controls.Add(Me.transSearchBox)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1100, 73)
        Me.Panel1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BackgroundImage = Global.Pepsi_Cashier.My.Resources.Resources.sdasd1
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(-1, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(364, 66)
        Me.Panel2.TabIndex = 106
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Pepsi_Cashier.My.Resources.Resources.search1
        Me.PictureBox1.InitialImage = Global.Pepsi_Cashier.My.Resources.Resources.search1
        Me.PictureBox1.Location = New System.Drawing.Point(6, 14)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(35, 35)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(42, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(296, 37)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Search Transaction"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(472, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 19)
        Me.Label3.TabIndex = 104
        Me.Label3.Text = "From :"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(545, 7)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.ShowCheckBox = True
        Me.DateTimePicker1.Size = New System.Drawing.Size(211, 27)
        Me.DateTimePicker1.TabIndex = 103
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGray
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(1043, -2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(55, 40)
        Me.Button3.TabIndex = 102
        Me.Button3.Text = "X"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImage = Global.Pepsi_Cashier.My.Resources.Resources.question
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(908, 40)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(23, 23)
        Me.Button2.TabIndex = 69
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label80
        '
        Me.Label80.AutoSize = True
        Me.Label80.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label80.ForeColor = System.Drawing.Color.White
        Me.Label80.Location = New System.Drawing.Point(472, 44)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(67, 19)
        Me.Label80.TabIndex = 68
        Me.Label80.Text = "Search :"
        '
        'transSearchBox
        '
        Me.transSearchBox.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.transSearchBox.Location = New System.Drawing.Point(545, 40)
        Me.transSearchBox.Name = "transSearchBox"
        Me.transSearchBox.Size = New System.Drawing.Size(357, 26)
        Me.transSearchBox.TabIndex = 67
        '
        'viewDetails
        '
        Me.viewDetails.BackColor = System.Drawing.Color.Transparent
        Me.viewDetails.FlatAppearance.BorderSize = 0
        Me.viewDetails.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGray
        Me.viewDetails.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke
        Me.viewDetails.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray
        Me.viewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.viewDetails.Font = New System.Drawing.Font("Tahoma", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.viewDetails.ForeColor = System.Drawing.Color.White
        Me.viewDetails.Location = New System.Drawing.Point(162, 1)
        Me.viewDetails.Name = "viewDetails"
        Me.viewDetails.Size = New System.Drawing.Size(135, 42)
        Me.viewDetails.TabIndex = 100
        Me.viewDetails.Text = "View Details"
        Me.viewDetails.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGray
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(9, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(134, 38)
        Me.Button1.TabIndex = 101
        Me.Button1.Text = "Void Transaction"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Panel32
        '
        Me.Panel32.BackColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Panel32.Controls.Add(Me.Button1)
        Me.Panel32.Controls.Add(Me.Button22)
        Me.Panel32.Controls.Add(Me.viewDetails)
        Me.Panel32.Controls.Add(Me.Button21)
        Me.Panel32.Controls.Add(Me.searchPaginateCounter)
        Me.Panel32.Location = New System.Drawing.Point(3, 546)
        Me.Panel32.Name = "Panel32"
        Me.Panel32.Size = New System.Drawing.Size(1092, 46)
        Me.Panel32.TabIndex = 102
        '
        'Button22
        '
        Me.Button22.BackColor = System.Drawing.Color.Transparent
        Me.Button22.FlatAppearance.BorderSize = 0
        Me.Button22.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button22.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button22.ForeColor = System.Drawing.Color.White
        Me.Button22.Location = New System.Drawing.Point(992, 6)
        Me.Button22.Name = "Button22"
        Me.Button22.Size = New System.Drawing.Size(93, 30)
        Me.Button22.TabIndex = 94
        Me.Button22.Text = ">>"
        Me.Button22.UseVisualStyleBackColor = False
        '
        'Button21
        '
        Me.Button21.BackColor = System.Drawing.Color.Transparent
        Me.Button21.FlatAppearance.BorderSize = 0
        Me.Button21.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button21.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button21.ForeColor = System.Drawing.Color.White
        Me.Button21.Location = New System.Drawing.Point(760, 6)
        Me.Button21.Name = "Button21"
        Me.Button21.Size = New System.Drawing.Size(93, 30)
        Me.Button21.TabIndex = 93
        Me.Button21.Text = "<<"
        Me.Button21.UseVisualStyleBackColor = False
        '
        'searchPaginateCounter
        '
        Me.searchPaginateCounter.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.searchPaginateCounter.ForeColor = System.Drawing.Color.White
        Me.searchPaginateCounter.Location = New System.Drawing.Point(859, 14)
        Me.searchPaginateCounter.Name = "searchPaginateCounter"
        Me.searchPaginateCounter.Size = New System.Drawing.Size(127, 19)
        Me.searchPaginateCounter.TabIndex = 95
        Me.searchPaginateCounter.Text = "15/100"
        Me.searchPaginateCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'transListView
        '
        Me.transListView.BackgroundImageTiled = True
        Me.transListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.transListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader10, Me.ColumnHeader5, Me.ColumnHeader1, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader2})
        Me.transListView.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.transListView.FullRowSelect = True
        Me.transListView.GridLines = True
        Me.transListView.Location = New System.Drawing.Point(5, 75)
        Me.transListView.MultiSelect = False
        Me.transListView.Name = "transListView"
        Me.transListView.Size = New System.Drawing.Size(1090, 468)
        Me.transListView.TabIndex = 101
        Me.transListView.UseCompatibleStateImageBehavior = False
        Me.transListView.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Trans. ID"
        Me.ColumnHeader3.Width = 80
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Settler Name"
        Me.ColumnHeader4.Width = 120
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "PD Number"
        Me.ColumnHeader10.Width = 110
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Teller"
        Me.ColumnHeader5.Width = 135
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Last Update"
        Me.ColumnHeader1.Width = 110
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Type of Payment"
        Me.ColumnHeader6.Width = 130
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Cash"
        Me.ColumnHeader7.Width = 130
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Check"
        Me.ColumnHeader8.Width = 130
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Total Amount"
        Me.ColumnHeader2.Width = 140
        '
        'transaction_Search
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1100, 596)
        Me.Controls.Add(Me.Panel32)
        Me.Controls.Add(Me.transListView)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "transaction_Search"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "transaction_Search"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel32.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents viewDetails As System.Windows.Forms.Button
    Friend WithEvents Panel32 As System.Windows.Forms.Panel
    Friend WithEvents Button22 As System.Windows.Forms.Button
    Friend WithEvents Button21 As System.Windows.Forms.Button
    Friend WithEvents searchPaginateCounter As System.Windows.Forms.Label
    Friend WithEvents transListView As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents transSearchBox As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
End Class
