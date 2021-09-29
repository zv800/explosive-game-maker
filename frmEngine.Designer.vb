﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEngine
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Scripts", 1, 1)
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sprites")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Audio", 2, 2)
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Backgrounds")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Levels")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEngine))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BuildGameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GlobalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdvancedModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ScriptsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DocumentationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutEGMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.CheckForUpdatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlreadyLatestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpriteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ObjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AudioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackgroundToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LevelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ScriptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.tmrDisplay = New System.Windows.Forms.Timer(Me.components)
        Me.tmrNowBuild = New System.Windows.Forms.Timer(Me.components)
        Me.tmrDebugCheck = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.MenuStrip1.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.ViewToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(810, 31)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.OpenToolStripMenuItem, Me.ToolStripSeparator2, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.ToolStripSeparator3, Me.BuildGameToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(50, 27)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(181, 28)
        Me.NewToolStripMenuItem.Text = "New "
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(181, 28)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(178, 6)
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Enabled = False
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(181, 28)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(181, 28)
        Me.SaveAsToolStripMenuItem.Text = "Save As"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(178, 6)
        '
        'BuildGameToolStripMenuItem
        '
        Me.BuildGameToolStripMenuItem.Name = "BuildGameToolStripMenuItem"
        Me.BuildGameToolStripMenuItem.Size = New System.Drawing.Size(181, 28)
        Me.BuildGameToolStripMenuItem.Text = "Build Game"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(178, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(181, 28)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GlobalToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(53, 27)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'GlobalToolStripMenuItem
        '
        Me.GlobalToolStripMenuItem.Name = "GlobalToolStripMenuItem"
        Me.GlobalToolStripMenuItem.Size = New System.Drawing.Size(208, 28)
        Me.GlobalToolStripMenuItem.Text = "Global Settings"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.Enabled = False
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(63, 27)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdvancedModeToolStripMenuItem, Me.ScriptsToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(62, 27)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'AdvancedModeToolStripMenuItem
        '
        Me.AdvancedModeToolStripMenuItem.Enabled = False
        Me.AdvancedModeToolStripMenuItem.Name = "AdvancedModeToolStripMenuItem"
        Me.AdvancedModeToolStripMenuItem.Size = New System.Drawing.Size(224, 28)
        Me.AdvancedModeToolStripMenuItem.Text = "Advanced Mode"
        '
        'ScriptsToolStripMenuItem
        '
        Me.ScriptsToolStripMenuItem.Name = "ScriptsToolStripMenuItem"
        Me.ScriptsToolStripMenuItem.Size = New System.Drawing.Size(224, 28)
        Me.ScriptsToolStripMenuItem.Text = "Scripts"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpToolStripMenuItem1, Me.DocumentationToolStripMenuItem, Me.ToolStripMenuItem3, Me.AboutEGMToolStripMenuItem, Me.ToolStripMenuItem4, Me.CheckForUpdatesToolStripMenuItem, Me.AlreadyLatestToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(59, 27)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'HelpToolStripMenuItem1
        '
        Me.HelpToolStripMenuItem1.Name = "HelpToolStripMenuItem1"
        Me.HelpToolStripMenuItem1.Size = New System.Drawing.Size(235, 28)
        Me.HelpToolStripMenuItem1.Text = "Help "
        '
        'DocumentationToolStripMenuItem
        '
        Me.DocumentationToolStripMenuItem.Name = "DocumentationToolStripMenuItem"
        Me.DocumentationToolStripMenuItem.Size = New System.Drawing.Size(235, 28)
        Me.DocumentationToolStripMenuItem.Text = "Documentation"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Enabled = False
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(235, 28)
        Me.ToolStripMenuItem3.Text = "Feedback"
        '
        'AboutEGMToolStripMenuItem
        '
        Me.AboutEGMToolStripMenuItem.Name = "AboutEGMToolStripMenuItem"
        Me.AboutEGMToolStripMenuItem.Size = New System.Drawing.Size(235, 28)
        Me.AboutEGMToolStripMenuItem.Text = "About EGM"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(232, 6)
        '
        'CheckForUpdatesToolStripMenuItem
        '
        Me.CheckForUpdatesToolStripMenuItem.Name = "CheckForUpdatesToolStripMenuItem"
        Me.CheckForUpdatesToolStripMenuItem.Size = New System.Drawing.Size(235, 28)
        Me.CheckForUpdatesToolStripMenuItem.Text = "Check for Updates"
        '
        'AlreadyLatestToolStripMenuItem
        '
        Me.AlreadyLatestToolStripMenuItem.Enabled = False
        Me.AlreadyLatestToolStripMenuItem.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AlreadyLatestToolStripMenuItem.Name = "AlreadyLatestToolStripMenuItem"
        Me.AlreadyLatestToolStripMenuItem.Size = New System.Drawing.Size(235, 28)
        Me.AlreadyLatestToolStripMenuItem.Text = "Already latest"
        Me.AlreadyLatestToolStripMenuItem.Visible = False
        '
        'TreeView1
        '
        Me.TreeView1.BackColor = System.Drawing.Color.White
        Me.TreeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Left
        Me.TreeView1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TreeView1.Location = New System.Drawing.Point(0, 62)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.ImageIndex = 1
        TreeNode1.Name = "Node0"
        TreeNode1.SelectedImageIndex = 1
        TreeNode1.Text = "Scripts"
        TreeNode2.Name = "Node1"
        TreeNode2.Text = "Sprites"
        TreeNode3.ImageIndex = 2
        TreeNode3.Name = "Node2"
        TreeNode3.SelectedImageIndex = 2
        TreeNode3.Text = "Audio"
        TreeNode4.Name = "Node3"
        TreeNode4.Text = "Backgrounds"
        TreeNode5.Name = "Node4"
        TreeNode5.Text = "Levels"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4, TreeNode5})
        Me.TreeView1.Size = New System.Drawing.Size(155, 497)
        Me.TreeView1.TabIndex = 3
        Me.TreeView1.Visible = False
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.CreateToolStripMenuItem})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 31)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(810, 31)
        Me.MenuStrip2.TabIndex = 4
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = Global.Explosive_Game_Maker.My.Resources.Resources.EGMDebug
        Me.ToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(77, 27)
        Me.ToolStripMenuItem1.Text = "Start"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Enabled = False
        Me.ToolStripMenuItem2.Image = Global.Explosive_Game_Maker.My.Resources.Resources.EGMStop
        Me.ToolStripMenuItem2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(75, 27)
        Me.ToolStripMenuItem2.Text = "Stop"
        '
        'CreateToolStripMenuItem
        '
        Me.CreateToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SpriteToolStripMenuItem, Me.ObjectToolStripMenuItem, Me.AudioToolStripMenuItem, Me.BackgroundToolStripMenuItem, Me.LevelToolStripMenuItem, Me.ScriptToolStripMenuItem})
        Me.CreateToolStripMenuItem.Image = Global.Explosive_Game_Maker.My.Resources.Resources.EGMCreate
        Me.CreateToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CreateToolStripMenuItem.Name = "CreateToolStripMenuItem"
        Me.CreateToolStripMenuItem.Size = New System.Drawing.Size(92, 27)
        Me.CreateToolStripMenuItem.Text = "Create "
        '
        'SpriteToolStripMenuItem
        '
        Me.SpriteToolStripMenuItem.Name = "SpriteToolStripMenuItem"
        Me.SpriteToolStripMenuItem.Size = New System.Drawing.Size(186, 28)
        Me.SpriteToolStripMenuItem.Text = "Sprite"
        '
        'ObjectToolStripMenuItem
        '
        Me.ObjectToolStripMenuItem.Enabled = False
        Me.ObjectToolStripMenuItem.Name = "ObjectToolStripMenuItem"
        Me.ObjectToolStripMenuItem.Size = New System.Drawing.Size(186, 28)
        Me.ObjectToolStripMenuItem.Text = "Object"
        '
        'AudioToolStripMenuItem
        '
        Me.AudioToolStripMenuItem.Enabled = False
        Me.AudioToolStripMenuItem.Name = "AudioToolStripMenuItem"
        Me.AudioToolStripMenuItem.Size = New System.Drawing.Size(186, 28)
        Me.AudioToolStripMenuItem.Text = "Audio"
        '
        'BackgroundToolStripMenuItem
        '
        Me.BackgroundToolStripMenuItem.Enabled = False
        Me.BackgroundToolStripMenuItem.Name = "BackgroundToolStripMenuItem"
        Me.BackgroundToolStripMenuItem.Size = New System.Drawing.Size(186, 28)
        Me.BackgroundToolStripMenuItem.Text = "Background"
        '
        'LevelToolStripMenuItem
        '
        Me.LevelToolStripMenuItem.Enabled = False
        Me.LevelToolStripMenuItem.Name = "LevelToolStripMenuItem"
        Me.LevelToolStripMenuItem.Size = New System.Drawing.Size(186, 28)
        Me.LevelToolStripMenuItem.Text = "Level"
        '
        'ScriptToolStripMenuItem
        '
        Me.ScriptToolStripMenuItem.Name = "ScriptToolStripMenuItem"
        Me.ScriptToolStripMenuItem.Size = New System.Drawing.Size(186, 28)
        Me.ScriptToolStripMenuItem.Text = "Script"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "EGM Project File (*.egm) |*.egm"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "egm"
        Me.SaveFileDialog1.Filter = "EGM Project File (*.egm) |*.egm"
        '
        'tmrDisplay
        '
        Me.tmrDisplay.Interval = 200
        '
        'tmrNowBuild
        '
        Me.tmrNowBuild.Interval = 1000
        '
        'tmrDebugCheck
        '
        Me.tmrDebugCheck.Interval = 500
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'BackgroundWorker2
        '
        Me.BackgroundWorker2.WorkerReportsProgress = True
        Me.BackgroundWorker2.WorkerSupportsCancellation = True
        '
        'frmEngine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(810, 559)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.MenuStrip2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmEngine"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GlobalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SpriteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ObjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AudioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BackgroundToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LevelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScriptToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BuildGameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutEGMToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdvancedModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents tmrDisplay As System.Windows.Forms.Timer
    Friend WithEvents DocumentationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrNowBuild As System.Windows.Forms.Timer
    Friend WithEvents tmrDebugCheck As System.Windows.Forms.Timer
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents CheckForUpdatesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScriptsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AlreadyLatestToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker

End Class
