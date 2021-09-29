Imports System.CodeDom.Compiler
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Reflection
Imports System.Diagnostics
Imports System.Threading
Imports FastColoredTextBoxNS
Imports System.Resources

Public Class frmEngine

#Region "Declarations"

    'Declarations
    Public EngineTitle As String = "[Alpha] Explosive Game Maker - "
    Public EngineTitleEx As String = ".egm"
    Public EngineSetTitle As String = "Untitled"
    Public RCol = 64
    Public GCol = 64
    Public BCol = 64
    Public Startmode As Integer = 0 '0 for Windowed or 1 for full screen
    Public ScriptText() As Char
    Public ScriptText2() As Char
    Public HasBeenShown As Boolean = False
    Public CoreText As String
    Public IsDebugging As Boolean = False
    'Variables used to keep only one script window and sprite window open 
    Public ScriptCount As Integer = 0
    Public SpriteCount As Integer = 0
    'Needed for compiling errors to display properly
    Friend frm As frmScrptWndw
    Friend cd As String
    'For new debug
    Friend dTick As Integer = 0

#End Region

#Region "Load"

    Private Sub tmrDisplay_Tick(sender As Object, e As EventArgs) Handles tmrDisplay.Tick
        'tmrDisplay.Stop()

    End Sub

    Private Sub frmEngine_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ''Swapped these around
        Dim thr As Thread = New Thread(AddressOf BasicLoadEvents)
        thr.IsBackground = True
        thr.Start()
        frmNewProject.ShowDialog()
        frmGlobalSettings.CheckBox1.Checked = My.Settings.dInfo
        '=========================
        'TIPS - MERGED - LAST PIECE OF MERGING
        'BasicLoadEvents()
    End Sub

    Private Sub Me_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
    End Sub

    Public Sub BasicLoadEvents()
        CheckDirectorys()
        'Set the images of the TreeView Nodes
        Dim ImgLst As New ImageList
        ImgLst.Images.Add(My.Resources.egm_folder)
        ImgLst.Images.Add(My.Resources.script)
        ImgLst.Images.Add(My.Resources.audio)
        TreeView1.ImageList = ImgLst
        TreeView1.SelectedImageIndex = 0
        'Set and build the title
        Me.Invoke(New MethodInvoker(Sub() Me.Text = EngineTitle & EngineSetTitle & EngineTitleEx))

        'Backcolor
        Dim Ctl As Control
        Dim CtlMDI As MdiClient
        For Each Ctl In Me.Controls
            Try
                CtlMDI = CType(Ctl, MdiClient)
                CtlMDI.BackColor = Color.FromArgb(64, 64, 64)
            Catch ex As Exception

            End Try
        Next

    End Sub

#End Region

#Region "Associate"

    Public Sub AssociateFiles()
        Dim extension As String = "egm"
        'Ensure the extension has a leading dot
        If Not extension.StartsWith(".") Then extension = "." & extension
        Dim fileTypeName As String = extension.Substring(1, extension.Length - 1)

        My.Computer.Registry.ClassesRoot.CreateSubKey(extension) _
            .SetValue("", fileTypeName, Microsoft.Win32.RegistryValueKind.String)
        My.Computer.Registry.ClassesRoot.CreateSubKey(fileTypeName & "\shell\open\command") _
            .SetValue("", Application.StartupPath & "\Projects\" & EngineSetTitle & ".egm" & " ""%l"" ", Microsoft.Win32.RegistryValueKind.String)
        Dim extension2 As String = "egms"
        'Ensure the extension has a leading dot
        If Not extension2.StartsWith(".") Then extension2 = "." & extension2
        Dim fileTypeName2 As String = extension2.Substring(1, extension2.Length - 1)

        My.Computer.Registry.ClassesRoot.CreateSubKey(extension2) _
            .SetValue("", fileTypeName2, Microsoft.Win32.RegistryValueKind.String)
        My.Computer.Registry.ClassesRoot.CreateSubKey(fileTypeName2 & "\shell\open\command") _
            .SetValue("", Application.StartupPath & "\Projects\" & EngineSetTitle & ".egms" & " ""%l"" ", Microsoft.Win32.RegistryValueKind.String)
        Dim extension3 As String = "egmr"
        'Ensure the extension has a leading dot
        If Not extension3.StartsWith(".") Then extension3 = "." & extension3
        Dim fileTypeName3 As String = extension3.Substring(1, extension.Length - 1)

        My.Computer.Registry.ClassesRoot.CreateSubKey(extension3) _
            .SetValue("", fileTypeName3, Microsoft.Win32.RegistryValueKind.String)
        My.Computer.Registry.ClassesRoot.CreateSubKey(fileTypeName3 & "\shell\open\command") _
            .SetValue("", Application.StartupPath & "\Projects\" & EngineSetTitle & ".egmr" & " ""%l"" ", Microsoft.Win32.RegistryValueKind.String)
    End Sub

#End Region

#Region "Menu Items"

    Private Sub HelpToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem1.Click
        Process.Start("https://github.com/zv800/explosive-game-maker/blob/main/README.md")
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        Try
            frmNewProject.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        frmFeedback.ShowDialog()
    End Sub

    Private Sub DocumentationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DocumentationToolStripMenuItem.Click
        Try
            Process.Start("https://github.com/zv800/explosive-game-maker/blob/main/README.md")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GlobalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GlobalToolStripMenuItem.Click
        frmGlobalSettings.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        If IsDebugging = False Then
            dTick = 0
            'Compile and then process the game
            'frmScrptWndw.SaveScripts()
            'We need this because was not working
            If Application.OpenForms().OfType(Of frmScrptWndw).Any Then
                For Each a As frmScrptWndw In Application.OpenForms.OfType(Of frmScrptWndw)()
                    If a.Created = True Then
                        a.SaveScripts()
                        Exit For
                    End If
                Next
            End If

            Try
                BuildCore()
                CompileGame(CoreText, EngineSetTitle, True)
            Catch ex As Exception

            End Try
            'BeginBuildWork()
            IsDebugging = True
            ToolStripMenuItem1.Enabled = False
            ToolStripMenuItem2.Enabled = True
            tmrDebugCheck.Start()
        Else
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        'stop debugging the game
        If IsDebugging = True Then
            Try
                For Each p As Process In System.Diagnostics.Process.GetProcessesByName(EngineSetTitle)
                    p.Kill()
                    p.WaitForExit()
                    'now del the file
                    'My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\" & EngineSetTitle & ".exe")
                Next
                ToolStripMenuItem1.Enabled = True
                IsDebugging = False
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        'Exit the application 
        End
    End Sub

    Private Sub SpriteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpriteToolStripMenuItem.Click
        If SpriteCount = 0 Then
            Dim SpriteWndw As New frmAddSprite
            'SpriteWndw.MdiParent = Me
            SpriteWndw.Show()
            'TODO update the titles of the nodes
            TreeView1.Nodes.Add("SprName", "SprName", 0, 0)
            SpriteCount = 1
        Else
            'do nothing, it's open 
        End If
        'create new sprite window 

    End Sub

    Private Sub ScriptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScriptToolStripMenuItem.Click
        If ScriptCount = 0 Then
            'Open the script window 
            Dim ScrptWndw As New frmScrptWndw
            'CreateScrptWnd()
            ScrptWndw.Show()
            TreeView1.Nodes(0).Nodes.Add("Script1")
            TreeView1.ExpandAll()
            ScriptCount = 1
        Else
            'do nothing its already open
        End If

    End Sub

    Private Sub AboutEGMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutEGMToolStripMenuItem.Click
        MsgBox("EGM - Explosive Game Maker was developed by zv800 © 2013 and is a Game Engine focused on the creation of 2D video Games entirely free!" &
               vbNewLine & vbNewLine & "Updated by Author & github community.", MsgBoxStyle.Information)
    End Sub


    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        'Save
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        'save as
        SaveFileDialog1.FileName = EngineSetTitle
        SaveFileDialog1.InitialDirectory = Application.StartupPath & "\Projects\"
        SaveFileDialog1.ShowDialog()
    End Sub

    Private Sub ScriptsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScriptsToolStripMenuItem.Click
        If File.Exists(Application.StartupPath & "\Projects\" & EngineSetTitle & ".egms1") Then frmScrptWndw.rtbScript.Text = File.ReadAllText(Application.StartupPath & "\Projects\" & EngineSetTitle & ".egms1")
        If File.Exists(Application.StartupPath & "\Projects\" & EngineSetTitle & ".egms2") Then frmScrptWndw.rtbScript2.Text = File.ReadAllText(Application.StartupPath & "\Projects\" & EngineSetTitle & ".egms2")
        frmScrptWndw.MdiParent = Me
        frmScrptWndw.Show()
    End Sub

#End Region

#Region "Build/Debug"

    Public Sub CheckDirectorys()
        'This routine is used to check if the core folders are existing or not, this is critical
        If My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\Projects\") = False Then
            My.Computer.FileSystem.CreateDirectory(Application.StartupPath & "\Projects\")
        End If
        If My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\Published\") = False Then
            My.Computer.FileSystem.CreateDirectory(Application.StartupPath & "\Published\")
        End If
        If My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\Samples\") = False Then
            My.Computer.FileSystem.CreateDirectory(Application.StartupPath & "\Samples\")
        End If
    End Sub
    ''' <summary>
    ''' Always use this. FirstTimeCore got deleted because it is not necessary
    ''' Makes application source code.
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub BuildCore()
        'Build all split files into one string

        Dim Startupmode1 As String = ""
        Dim startupmode2 As String = ""
        If Startmode = 0 Then
            'windowed 
            Startupmode1 = ""
            startupmode2 = ""
        ElseIf Startmode = 1 Then
            'Full screen 
            Startupmode1 = "Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None"
            startupmode2 = "Me.WindowState = FormWindowState.Maximized"
        End If
        'Dim fullicon As String = "Dim Ico As New System.Drawing.Icon(""" & My.Settings.gamesicon & """)" & vbNewLine & "Me.Icon = Ico"
        Dim ReadFile As String
        ReadFile = My.Resources.EGMCore1
        Dim ReadFile2 As String
        ReadFile2 = My.Resources.EGMCore2
        Dim ReadFile3 As String
        ReadFile3 = My.Resources.EGMCore3
        Dim ReadFile4 As String
        ReadFile4 = My.Resources.EGMCore4
        Dim ReadFile5 As String
        ReadFile5 = My.Resources.EGMCore5
        Dim DefBcolor As String = My.Settings.defaultback
        Dim ColorString As String = "Me.BackColor = System.Drawing.Color." & DefBcolor
        CoreText = ReadFile & EngineSetTitle & ReadFile2 & ColorString & vbCrLf & Startupmode1 & vbCrLf & startupmode2 & vbNewLine & ScriptText & vbCrLf & ReadFile4 & vbCrLf & "Public WindowText As String = """ & EngineSetTitle & """" & vbCrLf & ReadFile3 & vbCrLf & ScriptText2 & vbNewLine & ReadFile5

    End Sub


    <Obsolete("This method is deprecated, use BeginBuildWork() instead.")>
    Public Sub FirstTimeBuildWork()
        Try
            BuildCore()
            ' frmOutputTesting.txtOutput.Text = CoreText
            ' frmOutputTesting.Show()
            CompileGame(CoreText, EngineSetTitle)
        Catch ex As Exception

        End Try

    End Sub

    Public Sub BeginMainBuildWork()
        BuildCore()
        CompileGame(CoreText, EngineSetTitle)
    End Sub

    Friend Function CreateCompiler() As CodeDomProvider
        Return New VBCodeProvider()
    End Function
    <Obsolete("This method is deprecated, use CompileGame(...) instead.")>
    Public Sub BuildGame(ByVal ToCompile As String, ByVal Title As String)

        Try
            Dim objCompilerParameters As New System.CodeDom.Compiler.CompilerParameters()
            ' Add reference
            objCompilerParameters.ReferencedAssemblies.Add("System.dll")
            objCompilerParameters.ReferencedAssemblies.Add("System.Windows.Forms.dll")
            objCompilerParameters.ReferencedAssemblies.Add("Microsoft.VisualBasic.dll")
            objCompilerParameters.ReferencedAssemblies.Add("System.Drawing.dll")

            'Compile in memory
            Dim Output1 As String = Title
            objCompilerParameters.GenerateExecutable = True
            objCompilerParameters.OutputAssembly = Output1
            objCompilerParameters.CompilerOptions = "/target:winexe"
            ' objCompilerParameters.CompilerOptions = "/win32icon:" & My.Settings.gamesicon

            Dim strCode As String = ToCompile
            Dim objCompileResults As System.CodeDom.Compiler.CompilerResults = _
            CreateCompiler.CompileAssemblyFromSource(objCompilerParameters, strCode)
            If objCompileResults.Errors.HasErrors Then
                ' If an error occurs
                MsgBox("Error: Line>" & objCompileResults.Errors(0).Line - 45 & ", " & objCompileResults.Errors(0).ErrorText)
                'frmScrptWndw.rtbScript.Lines(objCompileResults.Errors(0).Line - 45)
                ToolStripMenuItem1.Enabled = True
                Exit Sub
            End If
        Catch ex As Exception

        Finally
        End Try
    End Sub
    Private err As TextStyle = New TextStyle(Brushes.LightSlateGray, Nothing, FontStyle.Regular)
    ''' <summary>
    ''' Compiles source code into .exe
    ''' Get more info while typing in parameters
    ''' </summary>
    ''' <param name="ToCompile">Source to compile</param>
    ''' <param name="Title">Title of app</param>
    ''' <param name="LaunchApp">Pass true if you want to run the app</param>
    ''' <remarks></remarks>
    Public Sub CompileGame(ByVal ToCompile As String, ByVal Title As String, Optional ByVal LaunchApp As Boolean = False, Optional ByVal Debug As Boolean = False)

        Try
            Dim pr As frmScrptWndw
            If Application.OpenForms().OfType(Of frmScrptWndw).Any Then
                For Each a As frmScrptWndw In Application.OpenForms.OfType(Of frmScrptWndw)()
                    If a.Created = True Then
                        pr = a
                        pr.MdiParent = Me
                        pr.BringToFront()
                        Exit For
                    End If
                Next
            Else
                pr = New frmScrptWndw
                pr.MdiParent = Me
                pr.Show()
            End If
            pr.ListView1.Items.Clear()
            Dim objCompilerParameters As New System.CodeDom.Compiler.CompilerParameters()
            ' Add reference
            objCompilerParameters.ReferencedAssemblies.Add("System.dll")
            objCompilerParameters.ReferencedAssemblies.Add("System.Windows.Forms.dll")
            objCompilerParameters.ReferencedAssemblies.Add("Microsoft.VisualBasic.dll")
            objCompilerParameters.ReferencedAssemblies.Add("System.Drawing.dll")

            'Compile in memory
            Dim Output1 As String = Title
            objCompilerParameters.GenerateExecutable = True
            objCompilerParameters.OutputAssembly = Output1
            If My.Settings.dInfo Then
                objCompilerParameters.GenerateInMemory = False
                objCompilerParameters.IncludeDebugInformation = True
                If My.Computer.FileSystem.DirectoryExists(CurDir() & "\Temp\") = False Then My.Computer.FileSystem.CreateDirectory(CurDir() & "\Temp\")
                objCompilerParameters.TempFiles = New TempFileCollection(CurDir() & "\Temp\", True)
                objCompilerParameters.TempFiles.KeepFiles = True

            End If
            'For debuggin:                       use /target:exe on line below - will show more errors on runtime!
            If Debug Then
                objCompilerParameters.CompilerOptions += "/target:exe " ' & "/debug:pdbonly "
            Else
                objCompilerParameters.CompilerOptions += "/target:winexe "
            End If
            objCompilerParameters.CompilerOptions += "/win32icon:" & My.Settings.gamesicon
            'Add icon as embedded resource. Then in EGMCore1 set it as Me.Icon
            If Not Directory.Exists(CurDir() & "\Resources\" & Title) Then Directory.CreateDirectory(CurDir() & "\Resources\" & Title)
            Dim RW As ResourceWriter = New ResourceWriter(CurDir() & "\Resources\" & Title & "\res.resources")
            Dim tmp_ic As Object = New Icon(My.Settings.gamesicon)
            RW.AddResource("icon", tmp_ic)
            RW.Generate()
            RW.Close()
            RW.Dispose()
            objCompilerParameters.EmbeddedResources.Add(CurDir() & "\Resources\" & Title & "\res.resources")
            Dim objCompileResults As System.CodeDom.Compiler.CompilerResults = _
            CreateCompiler.CompileAssemblyFromSource(objCompilerParameters, ToCompile)
            pr.rtbScript.Text = New String(ScriptText)
            If objCompileResults.Errors.HasErrors Then
                dTick = 5 ' See debug timer tick
                'If an error occurs - V2.1 Exception beta handling - lines become red and listview gather ALL the errors from compiler
                For i As Integer = 0 To objCompileResults.Errors.Count - 1
                    Dim lvi As ListViewItem = New ListViewItem(objCompileResults.Errors(i).ErrorText)
                    If (objCompileResults.Errors(i).Line - 46) < 1 Or (objCompileResults.Errors(i).Line - 46) > pr.rtbScript.Lines.Count Then
                        lvi.SubItems.Add("Internal Game Code")
                    Else
                        lvi.SubItems.Add(objCompileResults.Errors(i).Line - 46)
                    End If
                    pr.ListView1.Items.Add(lvi)
                    'pr.rtbScript.SelectionStart = pr.rtbScript.Text.IndexOf(pr.rtbScript.Lines(objCompileResults.Errors(i).Line - 47))
                    'pr.rtbScript.SelectionLength = pr.rtbScript.GetLineLength(objCompileResults.Errors(i).Line - 47) 'frmScrptWndw.rtbScript.Lines(frmScrptWndw.rtbScript.Lines(objCompileResults.Errors(i).Line - 45)).Length
                    pr.rtbScript(objCompileResults.Errors(i).Line - 47).BackgroundBrush = Brushes.Khaki
                Next
                pr.rtbScript.DoCaretVisible()
                pr.BringToFront()
                Exit Sub
            Else
                If LaunchApp Then
                    Dim app_thr As Thread = New Thread(AddressOf RunGame) 'Don't want the OutputTesting shown so using RunGame instead
                    app_thr.IsBackground = True
                    app_thr.Start() 'Start with app_thr.Start("args") if you need args
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Friend Sub RunGame()
        Process.Start(Application.StartupPath & "\" & EngineSetTitle & ".exe")
    End Sub
    ''' <summary>
    ''' Runs app(not the published once).
    ''' </summary>
    ''' <param name="args">Arguments to pass to program</param>
    ''' <remarks></remarks>
    Friend Sub RunApp(Optional ByVal args As String = "")
        Dim out As frmOutputTesting
        If Application.OpenForms().OfType(Of frmOutputTesting).Any Then
            For Each a As frmOutputTesting In Application.OpenForms.OfType(Of frmOutputTesting)()
                If a.Created = True Then
                    out = a
                    Me.Invoke(New MethodInvoker(Sub() out.MdiParent = Me))
                    Me.Invoke(New MethodInvoker(Sub() out.BringToFront()))
                    Exit For
                End If
            Next
        Else
            out = New frmOutputTesting
            Me.Invoke(New MethodInvoker(Sub() out.MdiParent = Me))
            Me.Invoke(New MethodInvoker(Sub() out.Show()))
        End If
        Me.Invoke(New MethodInvoker(Sub() out.txtOutput.Clear()))
        Dim app As Process = New Process()
        app.StartInfo.FileName = Application.StartupPath & "\" & EngineSetTitle & ".exe"
        app.StartInfo.UseShellExecute = False
        app.StartInfo.RedirectStandardOutput = True
        app.StartInfo.CreateNoWindow = True
        app.StartInfo.Arguments = args
        app.Start()
        Dim SROutput As System.IO.StreamReader = app.StandardOutput
        Dim tmp As String
        Do While app.HasExited = False
            tmp = SROutput.ReadLine
            If tmp <> "" Then
                Me.Invoke(New MethodInvoker(Sub() out.txtOutput.AppendText(tmp & vbNewLine)))
            End If
        Loop
        app.Dispose()
    End Sub


#End Region

#Region "Dialogs"

    Private Sub LevelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LevelToolStripMenuItem.Click
        If HasBeenShown = False Then
            frmRoom.MdiParent = Me
            frmRoom.Show()
            HasBeenShown = True
        Else

        End If
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        'load the file
        Dim ReadFile As New System.IO.StreamReader(OpenFileDialog1.FileName)
        Dim AllLines As List(Of String) = New List(Of String)
        Do While Not ReadFile.EndOfStream
            AllLines.Add(ReadFile.ReadLine())
        Loop
        ReadFile.Close()
        EngineSetTitle = ReadLine(1, AllLines)
        Startmode = ReadLine(2, AllLines)
        RCol = ReadLine(3, AllLines)
        GCol = ReadLine(4, AllLines)
        BCol = ReadLine(5, AllLines)
        BasicLoadEvents()
    End Sub

    Public Function ReadLine(lineNumber As Integer, lines As List(Of String)) As String
        Try
            Return lines(lineNumber - 1)
        Catch ex As Exception
        End Try
        Return Nothing
    End Function

    Private Sub BuildGameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuildGameToolStripMenuItem.Click
        CompileGame(CoreText, EngineSetTitle) 'BeginMainBuildWork()
        Try
            My.Computer.FileSystem.MoveFile(Application.StartupPath & "\" & EngineSetTitle & ".exe", Application.StartupPath & "\Published\" & EngineSetTitle & ".exe", True)
            Process.Start(Application.StartupPath & "\Published\" & EngineSetTitle & ".exe")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        'save the file
        Dim BuildFileText As String = EngineSetTitle & vbCrLf & Startmode & vbCrLf & RCol & vbCrLf & GCol & vbCrLf & BCol & vbCrLf
        My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, BuildFileText, True)
        If My.Settings.Recent1 = "" Then
            My.Settings.Recent1 = SaveFileDialog1.FileName
        ElseIf My.Settings.Recent2 = "" Then
            My.Settings.Recent2 = SaveFileDialog1.FileName
        ElseIf My.Settings.Recent3 = "" Then
            My.Settings.Recent3 = SaveFileDialog1.FileName
        ElseIf My.Settings.Recent4 = "" Then
            My.Settings.Recent4 = SaveFileDialog1.FileName
        ElseIf My.Settings.Recent5 = "" Then
            My.Settings.Recent5 = SaveFileDialog1.FileName
        ElseIf My.Settings.Recent6 = "" Then
            My.Settings.Recent6 = SaveFileDialog1.FileName
        ElseIf My.Settings.Recent7 = "" Then
            My.Settings.Recent7 = SaveFileDialog1.FileName
        ElseIf My.Settings.Recent8 = "" Then
            My.Settings.Recent8 = SaveFileDialog1.FileName
        End If
        My.Settings.Save()
        'AssociateFiles()
    End Sub

#End Region

#Region "Misc Events"

    Private Sub trmDebugCheck_Tick(sender As Object, e As EventArgs) Handles tmrDebugCheck.Tick
        'As now we are launching apps in new thread - we will add some additional checks
        If dTick < 4 Then
            dTick += 1
            Exit Sub
        End If

        Dim isRunning As Boolean = False
        For Each p As Process In System.Diagnostics.Process.GetProcessesByName(EngineSetTitle)
            isRunning = True
        Next
        If isRunning = False Then
            IsDebugging = False
            ToolStripMenuItem1.Enabled = True
            ToolStripMenuItem2.Enabled = False
            'If My.Computer.FileSystem.FileExists(Application.StartupPath & "\" & EngineSetTitle & ".exe") Then My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\" & EngineSetTitle & ".exe")
            tmrDebugCheck.Stop()
            dTick = 0
        End If
    End Sub
#End Region

#Region "Needs repairing/changing"



#End Region

#Region "Testing"

    'Public xCharacter As System.Drawing.Bitmap = System.Drawing.Image.FromFile("")
    ' Public Function DrawControlField()
    'Dim Field As New PictureBox
    '  Field.Dock = DockStyle.Fill
    '  Field.BorderStyle = BorderStyle.None
    '  Field.BackColor = Me.BackColor
    '  Me.Controls.Add(Field)
    '  Return Nothing
    ' End Function

#End Region

#Region "Updater"

    Public Sub UpdateEngine()
        Try
            Dim MyAppName As String = "Explosive Game Maker.exe"
            Dim url As String = "http://creativeprogramming.info/EGM/" & "FileUpdates371.php"
            Dim pageRequest As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            Dim pageResponse As WebResponse = pageRequest.GetResponse()
            Dim filelist As String : Dim Mainlist As String
            Using r As New StreamReader(pageResponse.GetResponseStream())
                filelist = r.ReadToEnd
                If Not IO.File.Exists(Application.StartupPath & "\" & "Updates") Then
                    IO.File.WriteAllText(Application.StartupPath & "\" & "Updates", filelist)
                End If
                Dim sr As New StreamReader(Application.StartupPath & "\" & "Updates")
                Mainlist = sr.ReadToEnd
                Dim FileLines() As String = filelist.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                Dim MainLines() As String = Mainlist.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                If Not Mainlist = filelist And Not FileLines.Length < MainLines.Length Then
                    AlreadyLatestToolStripMenuItem.Visible = False
                    Dim answer As DialogResult
                    answer = MessageBox.Show("Updates are available. Would you like to update now?", "Software Updates", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If answer = vbYes Then
                        Dim App As New Process
                        App.StartInfo.FileName = Application.StartupPath & "\" & "InfinityBlue.exe"
                        App.StartInfo.Arguments = "Update|" & MyAppName & "|" & url
                        App.Start()
                        Me.Close()
                    End If
                Else
                    AlreadyLatestToolStripMenuItem.Visible = True
                    'MsgBox("You have the lates version available.", MsgBoxStyle.Information)
                End If
            End Using
            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\" & "InfinityBlueUpdate.exe") Then
                My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\" & "InfinityBlue.exe", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                My.Computer.FileSystem.RenameFile(Application.StartupPath & "\" & "InfinityBlueUpdate.exe", "InfinityBlue.exe")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CheckForUpdatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckForUpdatesToolStripMenuItem.Click
        'Experimental update. Using try catch for result
        Dim upd As Thread
        Try
            upd = New Thread(AddressOf UpdateEngine)
            upd.IsBackground = True
            upd.Start()
        Catch ex As Exception
            If upd IsNot Nothing Then upd.Join()
            UpdateEngine()
        End Try

        'UpdateEngine()
    End Sub

#End Region

#Region "Unsorted"

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        'Try
        'Cleaning from last build
        frm.ListView1.Items.Clear()
        For i As Integer = 0 To frm.rtbScript.LinesCount - 1
            Dim k As Integer = i
            frm.Invoke(New MethodInvoker(Sub() frm.rtbScript(k).BackgroundBrush = Brushes.White))
        Next
        frm.Invoke(New MethodInvoker(Sub() frm.rtbScript.Refresh()))
        Dim objCompilerParameters As New System.CodeDom.Compiler.CompilerParameters()
        ' Add reference
        objCompilerParameters.ReferencedAssemblies.Add("System.dll")
        objCompilerParameters.ReferencedAssemblies.Add("System.Windows.Forms.dll")
        objCompilerParameters.ReferencedAssemblies.Add("Microsoft.VisualBasic.dll")
        objCompilerParameters.ReferencedAssemblies.Add("System.Drawing.dll")

        'Compile in memory
        Dim Output1 As String = EngineSetTitle
        objCompilerParameters.GenerateExecutable = True
        objCompilerParameters.OutputAssembly = Output1
        objCompilerParameters.CompilerOptions = "/target:winexe"
        If My.Settings.dInfo Then
            objCompilerParameters.GenerateInMemory = False
            objCompilerParameters.IncludeDebugInformation = True
            If My.Computer.FileSystem.DirectoryExists(CurDir() & "\Temp\") = False Then My.Computer.FileSystem.CreateDirectory(CurDir() & "\Temp\")
            objCompilerParameters.TempFiles = New TempFileCollection(CurDir() & "\Temp\", True)
            objCompilerParameters.TempFiles.KeepFiles = True

        End If
        Dim objCompileResults As System.CodeDom.Compiler.CompilerResults = CreateCompiler.CompileAssemblyFromSource(objCompilerParameters, cd)
        If objCompileResults.Errors.HasErrors Then
            Dim erre As String = New String(ScriptText).Remove(0, 2)
            frm.Invoke(New MethodInvoker(Sub() frm.rtbScript.Text = erre))
            'V2 Exception handling - lines become red and listview 
            For i As Integer = 0 To objCompileResults.Errors.Count - 1
                Dim lvi As ListViewItem = New ListViewItem(objCompileResults.Errors(i).ErrorText)
                lvi.SubItems.Add(objCompileResults.Errors(i).Line - 46)
                frm.ListView1.Items.Add(lvi)
                Dim rr As Integer = i
                frm.Invoke(New MethodInvoker(Sub() frm.rtbScript(objCompileResults.Errors(rr).Line - 47).BackgroundBrush = Brushes.LightSlateGray))
                'BackgroundWorker2.ReportProgress(objCompileResults.Errors(i).Line - 47)
                frm.Update()
            Next
            Try
                frm.rtbScript.DoCaretVisible()
                frm.BringToFront()
            Catch ex As Exception
                frm.Show()
            End Try

            Exit Sub
        End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    frm.Invoke(New MethodInvoker(Sub()
        '                                     frm.ToolStripMenuButton2.Enabled = True
        '                                     frm.ToolStripMenuButton2.Text = "Build"
        '                                 End Sub))
        'End Try
    End Sub

    Private Sub BackgroundWorker2_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker2.ProgressChanged
        'frm.rtbScript(e.ProgressPercentage).BackgroundBrush = Brushes.MediumVioletRed
    End Sub

#End Region

#Region "Undone yet stuff"
    ''This is a work in progress for an enemy following a character to be used as FollowCharacter("sprCharacter", 3, "sprEnemy") don't touch yet :) 
    'FFenixW0rks to Author: Maybe it would be better to create new class for enemies
    Public FCCharacter As String
    Public FCEnemy As String
    Public FCSpeed As Integer
    Public FCCharacterPath As String
    Public FCEnemyPath As String
    Public Function FollowCharacter(ByVal Character As String, Speed As Integer, Enemy As String)
        'Follow the character here
        FCCharacter = Character
        FCEnemy = Enemy
        FCSpeed = Speed
        GrabFCPaths()
        Dim FCTimer As New System.Windows.Forms.Timer
        FCTimer.Interval = 10
        FCTimer.Enabled = True
        AddHandler FCTimer.Tick, AddressOf FollowCharacterTimer_Tick
        Return Nothing
    End Function

    Public Sub FollowCharacterTimer_Tick(sender As Object, e As EventArgs)

    End Sub

    Public Sub GrabFCPaths()
        Dim DI As New System.IO.DirectoryInfo(Application.StartupPath & "\Projects\Resources\Misc\")
        Dim FIARR As System.IO.FileInfo() = DI.GetFiles()
        Dim FRI As System.IO.FileInfo
        For Each FRI In FIARR
            Dim ReadFile As New System.IO.StreamReader(FRI.FullName)
            Dim AllLines As List(Of String) = New List(Of String)
            Do While Not ReadFile.EndOfStream
                AllLines.Add(ReadFile.ReadLine())
            Loop
            ReadFile.Close()
            Dim Reader = ReadLine(2, AllLines)
            If Reader = FCCharacter Then
                Dim DI2 As New System.IO.DirectoryInfo(Application.StartupPath & "\Projects\Resources\")
                Dim FIARR2 As System.IO.FileInfo() = DI2.GetFiles()
                For Each FRI2 In FIARR2
                    Dim test As String = FRI2.FullName
                    If test.Contains(System.IO.Path.GetFileNameWithoutExtension(FRI.FullName)) Then
                        FCCharacterPath = FRI.FullName
                        MsgBox(FCCharacterPath)
                    End If
                Next
            End If
        Next

    End Sub

    Private Sub AdvancedModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdvancedModeToolStripMenuItem.Click

    End Sub

    Private Sub BackgroundToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackgroundToolStripMenuItem.Click

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

    End Sub
#End Region

End Class
