﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOutputTesting
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOutputTesting))
        Me.txtOutput = New FastColoredTextBoxNS.FastColoredTextBox()
        CType(Me.txtOutput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtOutput
        '
        Me.txtOutput.AutoScrollMinSize = New System.Drawing.Size(27, 14)
        Me.txtOutput.BackBrush = Nothing
        Me.txtOutput.CharHeight = 14
        Me.txtOutput.CharWidth = 8
        Me.txtOutput.CommentPrefix = "'"
        Me.txtOutput.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOutput.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtOutput.FoldingIndicatorColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtOutput.Font = New System.Drawing.Font("Courier New", 9.75!)
        Me.txtOutput.IsReplaceMode = False
        Me.txtOutput.Language = FastColoredTextBoxNS.Language.VB
        Me.txtOutput.LeftBracket = Global.Microsoft.VisualBasic.ChrW(40)
        Me.txtOutput.Location = New System.Drawing.Point(0, 0)
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.Paddings = New System.Windows.Forms.Padding(0)
        Me.txtOutput.RightBracket = Global.Microsoft.VisualBasic.ChrW(41)
        Me.txtOutput.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtOutput.Size = New System.Drawing.Size(525, 383)
        Me.txtOutput.TabIndex = 0
        Me.txtOutput.Zoom = 100
        '
        'frmOutputTesting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 383)
        Me.Controls.Add(Me.txtOutput)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmOutputTesting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Output - Used for testing only"
        CType(Me.txtOutput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtOutput As FastColoredTextBoxNS.FastColoredTextBox
End Class
