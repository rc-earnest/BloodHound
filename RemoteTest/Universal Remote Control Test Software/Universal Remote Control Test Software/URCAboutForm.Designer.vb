<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class URCAboutForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(URCAboutForm))
        Me.AboutFormCloseButton = New System.Windows.Forms.Button()
        Me.AboutFormLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'AboutFormCloseButton
        '
        Me.AboutFormCloseButton.Location = New System.Drawing.Point(360, 187)
        Me.AboutFormCloseButton.Name = "AboutFormCloseButton"
        Me.AboutFormCloseButton.Size = New System.Drawing.Size(177, 52)
        Me.AboutFormCloseButton.TabIndex = 0
        Me.AboutFormCloseButton.Text = "Close"
        Me.AboutFormCloseButton.UseVisualStyleBackColor = True
        '
        'AboutFormLabel
        '
        Me.AboutFormLabel.AutoSize = True
        Me.AboutFormLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AboutFormLabel.Location = New System.Drawing.Point(27, 9)
        Me.AboutFormLabel.Name = "AboutFormLabel"
        Me.AboutFormLabel.Size = New System.Drawing.Size(756, 160)
        Me.AboutFormLabel.TabIndex = 1
        Me.AboutFormLabel.Text = resources.GetString("AboutFormLabel.Text")
        Me.AboutFormLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'URCAboutForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(912, 251)
        Me.Controls.Add(Me.AboutFormLabel)
        Me.Controls.Add(Me.AboutFormCloseButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "URCAboutForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents AboutFormCloseButton As Button
    Friend WithEvents AboutFormLabel As Label
End Class
