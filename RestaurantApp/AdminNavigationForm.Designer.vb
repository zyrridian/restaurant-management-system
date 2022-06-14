<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdminNavigationForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OrderButton = New System.Windows.Forms.Button()
        Me.MenuButton = New System.Windows.Forms.Button()
        Me.MemberButton = New System.Windows.Forms.Button()
        Me.LogoutButton = New System.Windows.Forms.Button()
        Me.PaymentButton = New System.Windows.Forms.Button()
        Me.ReportButton = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.EmployeeIDToolStripLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(127, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(217, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Admin Navigation"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(12, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Welcome, "
        '
        'OrderButton
        '
        Me.OrderButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.OrderButton.FlatAppearance.BorderSize = 0
        Me.OrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OrderButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OrderButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.OrderButton.Location = New System.Drawing.Point(49, 174)
        Me.OrderButton.Name = "OrderButton"
        Me.OrderButton.Size = New System.Drawing.Size(190, 30)
        Me.OrderButton.TabIndex = 2
        Me.OrderButton.Text = "Order"
        Me.OrderButton.UseVisualStyleBackColor = False
        '
        'MenuButton
        '
        Me.MenuButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.MenuButton.FlatAppearance.BorderSize = 0
        Me.MenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MenuButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.MenuButton.Location = New System.Drawing.Point(49, 215)
        Me.MenuButton.Name = "MenuButton"
        Me.MenuButton.Size = New System.Drawing.Size(190, 30)
        Me.MenuButton.TabIndex = 3
        Me.MenuButton.Text = "Manage Menu"
        Me.MenuButton.UseVisualStyleBackColor = False
        '
        'MemberButton
        '
        Me.MemberButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.MemberButton.FlatAppearance.BorderSize = 0
        Me.MemberButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MemberButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MemberButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.MemberButton.Location = New System.Drawing.Point(255, 174)
        Me.MemberButton.Name = "MemberButton"
        Me.MemberButton.Size = New System.Drawing.Size(190, 30)
        Me.MemberButton.TabIndex = 4
        Me.MemberButton.Text = "Manage Member"
        Me.MemberButton.UseVisualStyleBackColor = False
        '
        'LogoutButton
        '
        Me.LogoutButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.LogoutButton.FlatAppearance.BorderSize = 0
        Me.LogoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LogoutButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LogoutButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.LogoutButton.Location = New System.Drawing.Point(255, 215)
        Me.LogoutButton.Name = "LogoutButton"
        Me.LogoutButton.Size = New System.Drawing.Size(190, 30)
        Me.LogoutButton.TabIndex = 5
        Me.LogoutButton.Text = "Logout"
        Me.LogoutButton.UseVisualStyleBackColor = False
        '
        'PaymentButton
        '
        Me.PaymentButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.PaymentButton.FlatAppearance.BorderSize = 0
        Me.PaymentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PaymentButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaymentButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.PaymentButton.Location = New System.Drawing.Point(49, 256)
        Me.PaymentButton.Name = "PaymentButton"
        Me.PaymentButton.Size = New System.Drawing.Size(190, 30)
        Me.PaymentButton.TabIndex = 6
        Me.PaymentButton.Text = "Payment"
        Me.PaymentButton.UseVisualStyleBackColor = False
        '
        'ReportButton
        '
        Me.ReportButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ReportButton.FlatAppearance.BorderSize = 0
        Me.ReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ReportButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReportButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.ReportButton.Location = New System.Drawing.Point(255, 256)
        Me.ReportButton.Name = "ReportButton"
        Me.ReportButton.Size = New System.Drawing.Size(190, 30)
        Me.ReportButton.TabIndex = 7
        Me.ReportButton.Text = "Report"
        Me.ReportButton.UseVisualStyleBackColor = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.EmployeeIDToolStripLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 338)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(480, 22)
        Me.StatusStrip1.TabIndex = 8
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(79, 17)
        Me.ToolStripStatusLabel1.Text = "Employee ID: "
        '
        'EmployeeIDToolStripLabel
        '
        Me.EmployeeIDToolStripLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.EmployeeIDToolStripLabel.Name = "EmployeeIDToolStripLabel"
        Me.EmployeeIDToolStripLabel.Size = New System.Drawing.Size(0, 17)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(88, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 18)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "[Admin Name]"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(480, 100)
        Me.Panel1.TabIndex = 10
        '
        'AdminNavigationForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(480, 360)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ReportButton)
        Me.Controls.Add(Me.PaymentButton)
        Me.Controls.Add(Me.LogoutButton)
        Me.Controls.Add(Me.MemberButton)
        Me.Controls.Add(Me.MenuButton)
        Me.Controls.Add(Me.OrderButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "AdminNavigationForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AdminNavigationForm"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents OrderButton As Button
    Friend WithEvents MenuButton As Button
    Friend WithEvents MemberButton As Button
    Friend WithEvents LogoutButton As Button
    Friend WithEvents PaymentButton As Button
    Friend WithEvents ReportButton As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents EmployeeIDToolStripLabel As ToolStripStatusLabel
End Class
