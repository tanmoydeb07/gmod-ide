using System;
using System.Windows.Forms;
using Fireball.Docking;
using GModIDE.PluginConnector;
using GModIDE.Windows;

namespace GModIDE.Classes
{
    public class Workspace
    {
        #region Fields
        private MainForm _main;
        private DockContainer _manager;
        //private Project _project;
        private ContextMenuStrip _tabStrip;
        private ContextMenuStrip _editStrip;
        private ContextMenuStrip _projectStrip;
        private ContextMenuStrip _codeStrip;
        private ContextMenuStrip _folderStrip;
        //private OutputWindow _woutput;
        //private TaskWindow _wtask;
        //private ProjectExplorer _wexplorer;
        //private ObjectBrowser _wobj;
        //private CodeProvider _wcode;
        //private ProjectProperties _wproperties;
        //private bool _fileLoading = false;
        #endregion

        #region Properties
        /// <summary>
        /// Docking Container
        /// </summary>
        public DockContainer Manager { get { return _manager; } }

        /// <summary>
        /// Current Project
        /// </summary>
        //public Project Project { get { return _project; } }

        /// <summary>
        /// Tab Strip
        /// </summary>
        public ContextMenuStrip TabStrip { get { return _tabStrip; } }

        /// <summary>
        /// Edit Strip
        /// </summary>
        public ContextMenuStrip EditStrip { get { return _editStrip; } }

        /// <summary>
        /// Project Strip
        /// </summary>
        public ContextMenuStrip ProjectStrip { get { return _projectStrip; } }

        /// <summary>
        /// Code Strip
        /// </summary>
        public ContextMenuStrip CodeStrip { get { return _codeStrip; } }

        /// <summary>
        /// Code Strip
        /// </summary>
        public ContextMenuStrip FolderStrip { get { return _folderStrip; } }

        /// <summary>
        /// Code Strip
        /// </summary>
        public ContextMenuStrip OutputWindow { get { return _codeStrip; } }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new Environment class
        /// </summary>
        /// <param name="main">The main form</param>
        /// <param name="sdm">The docking manager used by IDE</param>
        /// <param name="tStrip">Tab context menu</param>
        /// <param name="eStrip">Edit control context menu</param>
        /// <param name="pStrip">Project node context menu</param>
        /// <param name="cStrip">Code node context menu</param>
        /// <param name="fStrip">Folder node context menu</param>
        /// <param name="code">Code provider for code completion</param>
        public Workspace(MainForm main, DockContainer sdm, ContextMenuStrip tStrip, ContextMenuStrip eStrip, ContextMenuStrip pStrip, ContextMenuStrip cStrip, ContextMenuStrip fStrip)
        {
            /* load windows, etc */
            _main = main;
            _manager = sdm;

            _tabStrip = tStrip;
            _editStrip = eStrip;
            _projectStrip = pStrip;
            _codeStrip = cStrip;
            _folderStrip = fStrip;

            /*explorer = new ProjectExplorer(this);
            treeView = explorer.tvFiles;
            imageList = explorer.imgList;
            explorer.Show(sdm, DockState.DockLeft);//, DockState.DockLeft);
            tabStrip = tStrip;
            editStrip = eStrip;
            projectStrip = explorer.projectMenu;
            codeStrip = explorer.fileMenu;
            folderStrip = explorer.folderMenu;

            // used to set the right clicked node as the current node
            //treeView.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeView_NodeMouseClick);

            // Taken out by Marine
            // !  Put back in by VoiDeD
            // load the code database and settings
            this.code = CodeProvider.Load(Application.StartupPath + "\\code.db");

            obj = new ObjectBrowser(code, images, this);
            */
        }
        #endregion

        #region Methods
        /// <summary>
        /// Add a menu item to main window
        /// </summary>
        /// <param name="sec">Menu Section</param>
        /// <param name="tmi">Menu Item</param>
        public void AddMenuItem(MenuSection sec, ToolStripItem tmi)
        {
            switch (sec)
            {
                case MenuSection.FILE:
                    _main.fileToolStripMenuItem.DropDownItems.Add(tmi);
                    break;
                case MenuSection.EDIT:
                    _main.editToolStripMenuItem.DropDownItems.Add(tmi);
                    break;
                case MenuSection.VIEW:
                    _main.viewToolStripMenuItem.DropDownItems.Add(tmi);
                    break;
                case MenuSection.TOOLS:
                    _main.toolsToolStripMenuItem.DropDownItems.Add(tmi);
                    break;
                case MenuSection.HELP:
                    _main.helpToolStripMenuItem.DropDownItems.Add(tmi);
                    break;
            }
        }
        #endregion

        /*
        /// <summary>
        /// Checks if a project is open
        /// </summary>
        /// <returns>True if a project is open, otherwise false</returns>
        public bool IsProjectOpen()
        {
            return (project != null);
        }
        /// <summary>
        /// Checks if the current project is saved, does not check if a project is open
        /// </summary>
        /// <returns>True if saved, otherwise false</returns>
        public bool IsProjectSaved()
        {
            return project.IsProjectSaved();
        }
        /// <summary>
        /// Checks if a specific project file is shown in the interface
        /// </summary>
        /// <param name="file">The project file to check</param>
        /// <returns>True if the file is open, otherwise false</returns>
        public bool IsProjectFileShown(OpenedFile file)
        {
            foreach (DockableWindow tp in manager.Documents)
            {
                if (!IsSpecialTab(tp))
                {
                    if (tp.Tag == file)
                        return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Checks if a special tab is open, such as the Object Browser
        /// </summary>
        /// <param name="tab">The special tab to check</param>
        /// <returns>True if the tab is shown, otherwise false</returns>
        public bool IsSpecialTabShown(SpecialTab tab)
        {
            foreach (DockableWindow tp in manager.Documents)
            {
                if (IsSpecialTab(tp))
                {
                    if (((SpecialTab)tp.Tag).Type == tab.Type)
                        return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Checks if the object browser window is shown
        /// </summary>
        /// <returns>Returns true if the object browser is shown, otherwise false</returns>
        public bool IsObjectBrowserShown()
        {
            foreach (DockableWindow tp in manager.Documents)
            {
                if (IsSpecialTab(tp))
                {
                    if (((SpecialTab)tp.Tag).Type == TabType.ObjectBrowser)
                        return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Checks if the project info window is shown
        /// </summary>
        /// <returns>Returns true if the project info window is shown, otherwise false</returns>
        public bool IsProjectInfoShown()
        {
            foreach (DockableWindow tp in manager.Documents)
            {
                if (IsSpecialTab(tp))
                {
                    if (((SpecialTab)tp.Tag).Type == TabType.ProjectInfo)
                        return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Checks if a tab window is a special tab
        /// </summary>
        /// <param name="tp">The window to check</param>
        /// <returns>True if the window is a special tab, otherwise false</returns>
        public bool IsSpecialTab(DockableWindow tp)
        {
            return (tp != null) && (tp.GetType().Name != "CodeTab");
        }
        /// <summary>
        /// Checks if a specific dockable window is a special tab
        /// </summary>
        /// <param name="tp">The window to check</param>
        /// <returns>True if the window is a special tab, otherwise false</returns>
        //public bool IsSpecialTab( DockableWindow tp )
        //{
        //    return ((tp is DockableWindow) && (tp.Tag is SpecialTab));
        //}
        /// <summary>
        /// Checks if any tabs are open
        /// </summary>
        /// <returns>True if a tab is open, otherwise false</returns>
        public bool IsTabOpen()
        {
            return (manager.Documents.Length > 0);
        }
        /// <summary>
        /// Checks if any code tabs are open
        /// </summary>
        /// <returns>True if a tab is open, otherwise false</returns>
        public bool IsCodeTabOpen()
        {
            if (IsTabOpen())
            {
                foreach (DockableWindow td in manager.Documents)
                {
                    if (IsCodeTab(td))
                        return true;
                }
                return false;
            }
            return false;
        }
        /// <summary>
        /// Checks if the active tab is a special tab
        /// </summary>
        /// <returns>True if the tab is a special tab, otherwise false</returns>
        public bool IsActiveTabSpecial()
        {
            return IsSpecialTab((DockableWindow)manager.ActiveDocument);
        }
        /// <summary>
        /// Checks if a tab is a code tab
        /// </summary>
        /// <param name="tp">The tab to check</param>
        /// <returns>True if the tab is a code tab, otherwise false</returns>
        public bool IsCodeTab(DockableWindow tp)
        {
            return (tp != null) && ((tp.GetType().Name == "CodeTab"));
        }
        /// <summary>
        /// Checks if a window is a code tab
        /// </summary>
        /// <param name="tp">The window to check</param>
        /// <returns>True if the window is a code tab, otherwise false</returns>
        //public bool IsCodeTab( DockableWindow tp )
        //{
        //    return ((tp is DockableWindow) && !(tp.Tag is SpecialTab));
        //}
        /// <summary>
        /// Checks if a specific char is a char that strings should be split by, used for auto-completion
        /// </summary>
        /// <param name="chr">The character to check</param>
        /// <returns>True if the char is a split char, otherwise false</returns>
        public bool IsSplitChar(char chr)
        {
            return (
                (chr == ' ') ||
                (chr == '\t') ||
                (chr == '\r') ||
                (chr == '\n') ||
                (chr == '(') ||
                (chr == '|') ||
                (chr == '!') ||
                (chr == '.') ||
                (chr == ':') ||
                (chr == '&') ||
                (chr == '~') ||
                (chr == '-')
            );
        }
        /// <summary>
        /// Checks if a file in the project exists by name
        /// </summary>
        /// <param name="name">The filename to check</param>
        /// <returns>True if the file exists, otherwise false</returns>
        public bool DoesProjectFileExist(string fullname)
        {
            if (IsProjectOpen())
            {
                foreach (OpenedFile pf in project.Files)
                {
                    if (pf.FullName == fullname)
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns the name of the currently focused tab
        /// </summary>
        /// <returns>The name of the tab</returns>
        public string GetActiveTabName()
        {
            if (IsTabOpen())
            {
                return manager.ActiveDocument.DockHandler.TabText;
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// Returns a tree node object of the currently focused node
        /// </summary>
        /// <returns>The treenode</returns>
        public TreeNode GetSelectedTreeNode()
        {
            if (treeView.SelectedNode != null)
                return treeView.SelectedNode;
            else
                return null;
        }

        /// <summary>
        /// Clears all nodes and tabs
        /// </summary>
        public void Clear()
        {
            ClearNodes();
            ClearTabs();
            taskList.lstTasks.Items.Clear();
            output.Hide();
            output.Dispose();

            taskList.Hide();
            taskList.Dispose();

        }
        /// <summary>
        /// Clears all the nodes in the treeview
        /// </summary>
        public void ClearNodes()
        {
            treeView.Nodes.Clear();
        }
        /// <summary>
        /// Clears all tabs in the environment, but keeps the object browser open
        /// </summary>
        public void ClearTabs()
        {
            foreach (DockableWindow tp in manager.Documents)
            {
                if (IsSpecialTab(tp))
                {
                    if (((SpecialTab)tp.Tag).Type == TabType.ObjectBrowser)
                        continue;
                }
                tp.Close();
            }
        }
        /// <summary>
        /// Refreshes the nodes of the current project
        /// </summary>
        public void ReloadNodes()
        {
            ClearNodes();
            AddProject(project);
        }
        /// <summary>
        /// Removes a specific project file node
        /// </summary>
        /// <param name="file">The project file to remove</param>
        public void RemoveNode(OpenedFile file)
        {
            if (IsProjectOpen())
            {
                foreach (TreeNode tn in treeView.Nodes[0].Nodes)
                {
                    if (tn.Tag is OpenedFile)
                    {
                        if (tn.Tag == file)
                            tn.Remove();
                    }
                }
            }
        }
        /// <summary>
        /// Renames an existing project file node to something else
        /// </summary>
        /// <param name="file">The file to rename</param>
        /// <param name="newName">The new name to give the file</param>
        public void RenameNode(OpenedFile file, string newName)
        {
            if (IsProjectOpen())
            {
                foreach (TreeNode tn in treeView.Nodes[0].Nodes)
                {
                    if (tn.Tag is OpenedFile)
                    {
                        if (tn.Tag == file)
                            tn.Text = newName;
                    }
                }
            }
        }
        /// <summary>
        /// Renames the currently opened project's node to something new
        /// </summary>
        /// <param name="newName">The new name to assign to the project</param>
        public void RenameProjectNode(string newName)
        {
            if (IsProjectOpen())
            {
                treeView.Nodes[0].Text = "Project '" + newName + "'";
            }
        }

        /// <summary>
        /// Shows the object browser
        /// </summary>
        public void ShowObjectBrowser()
        {
            obj.Show(manager);
        }
        /// <summary>
        /// Makes the object browser the currently active tab
        /// </summary>
        public void MakeObjectBrowserActive()
        {
            // HACK: FIX!

            //foreach ( TabbedDocument tp in manager.Documents )
            //{
            //    if ( IsSpecialTab( tp ) )
            //    {
            //        if ( ( ( SpecialTab )tp.Tag ).Type == TabType.ObjectBrowser )
            //            manager.ActiveDocument = tp;
            //    }
            //}
        }
        /// <summary>
        /// Closes the object browser
        /// </summary>
        public void CloseObjectBrowser()
        {
            if (IsObjectBrowserShown())
            {
                foreach (DockableWindow tp in manager.Documents)
                {
                    if (IsSpecialTab(tp))
                    {
                        if (((SpecialTab)tp.Tag).Type == TabType.ObjectBrowser)
                        {
                            tp.Close();
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Shows the project info tab
        /// </summary>
        public void ShowProjectInfo()
        {
            if (IsProjectOpen())
            {
                if (IsProjectInfoShown())
                {
                    MakeProjectInfoActive();
                    return;
                }

                // HACK!!! Fix for Project Properties.
                //DockableWindow tp = new DockableWindow();
                //tp.Text = "Project Properties";
                //SpecialTab st = new SpecialTab();
                //st.Type = TabType.ProjectInfo;
                //tp.Tag = st;
                //tp.BackColor = System.Drawing.SystemColors.Control;

                //ProjectProperties pp = new ProjectProperties(project);
                //pp.Dock = DockStyle.Fill;
                //tp.Controls.Add(pp);

                //tp.Show(manager);
                if (projProperties == null)
                {
                    projProperties = new ProjectProperties(project);
                    projProperties.TabText = "[ Project Properties ]";
                    projProperties.DockableAreas = DockAreas.Document;
                    projProperties.Show(manager, DockState.Document);

                }
                else
                {
                    projProperties.Show(manager, DockState.Document);
                }

            }
        }
        /// <summary>
        /// Makes the project info tab the currently active tab
        /// </summary>
        public void MakeProjectInfoActive()
        {
            // HACK: FIX!

            //foreach (DockableWindow tp in manager.Documents)
            //{
            //    if ( IsSpecialTab( tp ) )
            //    {
            //        if ( ( ( SpecialTab )tp.Tag ).Type == TabType.ProjectInfo )
            //            manager.ActiveDocument = tp;
            //    }
            //}
        }
        /// <summary>
        /// Closes the project info tab
        /// </summary>
        public void CloseProjectInfo()
        {
            if (IsProjectInfoShown())
            {
                foreach (DockableWindow tp in manager.Documents)
                {
                    // HACK!!! FIX!
                    //if (IsSpecialTab(tp))
                    //{
                    //    if (((SpecialTab)tp.Tag).Type == TabType.ProjectInfo)
                    //    {
                    //        project = ((ProjectProperties)tp.Controls[0]).Project;
                    //        project.Saved = false;
                    //        tp.Close();
                    //        ReloadNodes();
                    //    }
                    //}
                }
            }
        }

        /// <summary>
        /// Displays the settings dialog
        /// </summary>
        public void ShowSettingsDialog()
        {
            // HACK!!! FIX!!!
            //SettingsDialog sd = new SettingsDialog(settings);
            //sd.ShowDialog();

            //settings = sd.Settings;
        }

        /// <summary>
        /// Adds a project to the environment, and loads all nodes
        /// </summary>
        /// <param name="proj"></param>
        public void AddProject(Project proj)
        {
            project = proj;

            ClearNodes();

            TreeNode tn = new TreeNode();
            tn.Text = "Project '" + proj.Name + "'";
            tn.ImageKey = "root";
            tn.Tag = proj;
            tn.ContextMenuStrip = projectStrip;
            tn.SelectedImageKey = "root";

            treeView.Nodes.Add(tn);

            foreach (Folder f in proj.Folders)
            {
                TreeNode tn_ = new TreeNode();
                tn_.Text = f.Name;
                tn_.ContextMenuStrip = folderStrip;
                tn_.ImageKey = "project_folder_closed";
                tn_.SelectedImageKey = "project_folder_closed";
                tn_.Tag = f;
                f.Node = tn_;
                treeView.Nodes[0].Nodes.Add(tn_);

                f.BuildTreeview(this, proj);

            }

            foreach (OpenedFile pf in proj.Files)
            {
                if (!File.Exists(proj.Path + "\\" + pf.Name))
                {
                    pf.Valid = false;
                    pf.Saved = true;
                    TreeNode tn_ = new TreeNode();
                    tn_.Text = pf.Name;
                    tn_.ContextMenuStrip = codeStrip;
                    tn_.ImageKey = "file_lost";
                    tn_.SelectedImageKey = "file_lost";
                    tn_.Tag = pf;
                    pf.Node = tn_;
                    treeView.Nodes[0].Nodes.Add(tn_);
                    continue;
                }
                pf.FullName = proj.Path + "\\" + pf.Name;
                pf.Saved = true;
                pf.Valid = true;

                TreeNode tn2 = new TreeNode();
                tn2.Text = pf.Name;
                tn2.ContextMenuStrip = codeStrip;
                tn2.ImageKey = "code";
                tn2.SelectedImageKey = "code";
                tn2.Tag = pf;
                pf.Node = tn2;

                treeView.Nodes[0].Nodes.Add(tn2);
            }

            treeView.ExpandAll();

            // And setup all the tasks
            output = new OutputWindow(this);
            output.Show(manager, DockState.DockBottomAutoHide);//, DockState.DockBottom);

            taskList = new TaskWindow(this);
            taskList.Show(manager, DockState.DockBottomAutoHide);//, DockState.DockBottom);

            // Now load in the tasks
            taskList.Reload();
        }

        /// <summary>
        /// Removes the currently open project from the envionment, use CloseProject() unless you need to force delete a project
        /// </summary>
        public void RemoveProject()
        {
            project = null;

            Clear();
        }
        /// <summary>
        /// Checks if a project is currently open and creates a new project
        /// </summary>
        public void NewProject()
        {
            if (IsProjectOpen())
            {
                if (!IsProjectSaved())
                {
                    DialogResult res = Util.ShowQuestion(StringTable.ProjectNotSaved);

                    switch (res)
                    {
                        case DialogResult.Yes:
                            project.Save();
                            break;
                        case DialogResult.No:
                            break;
                        case DialogResult.Cancel:
                            return;
                    }
                }
                DialogResult result = Util.ShowQuestion(StringTable.OpenProject);

                switch (result)
                {
                    case DialogResult.Yes:
                        RemoveProject();
                        NewProject();
                        break;
                    case DialogResult.No:
                        return;
                    case DialogResult.Cancel:
                        return;
                }
            }
            else
            {
                project = Project.NewProject();
                if (project == null)
                    return;

                SaveProject();

                AddProject(project);
            }
        }
        /// <summary>
        /// Shows a dialog and opens an existing project
        /// </summary>
        public void OpenProject()
        {
            if (IsProjectOpen())
            {
                if (!IsProjectSaved())
                {
                    DialogResult res = Util.ShowQuestion(StringTable.ProjectNotSaved);

                    switch (res)
                    {
                        case DialogResult.Yes:
                            project.Save();
                            break;
                        case DialogResult.No:
                            break;
                        case DialogResult.Cancel:
                            return;
                    }
                }
                DialogResult result = Util.ShowQuestion(StringTable.OpenProject);

                switch (result)
                {
                    case DialogResult.Yes:
                        RemoveProject();
                        OpenProject();
                        break;
                    case DialogResult.No:
                        return;
                    case DialogResult.Cancel:
                        return;
                }
            }
            else
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Open project...";
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                ofd.DereferenceLinks = true;
                ofd.Filter = "GLua Projects (*.glu)|*.glu";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                project = Project.LoadProject(ofd.FileName);
                if (project == null)
                    return;
                project.FullName = ofd.FileName;
                project.Path = new FileInfo(ofd.FileName).Directory.FullName;
                project.Saved = true;
                foreach (Folder folder in project.Folders)
                {
                    folder.RebuildParents(folder, true);
                }
                AddProject(project);
            }
        }
        /// <summary>
        /// Asks to save, closes the project, and calls RemoveProject()
        /// </summary>
        public void CloseProject()
        {
            if (IsProjectOpen())
            {
                if (!IsProjectSaved())
                {
                    DialogResult res = Util.ShowQuestion(StringTable.ProjectNotSaved);

                    switch (res)
                    {
                        case DialogResult.Yes:
                            project.Save();
                            RemoveProject();
                            break;
                        case DialogResult.No:
                            RemoveProject();
                            break;
                        case DialogResult.Cancel:
                            return;
                    }
                }
                else
                {
                    RemoveProject();
                }
            }
        }
        /// <summary>
        /// Saves the currently opened project
        /// </summary>
        public void SaveProject()
        {
            if (IsProjectOpen())
            {
                if (project.FullName == "")
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Title = "Save project...";
                    sfd.AddExtension = true;
                    sfd.DefaultExt = ".glu";
                    sfd.Filter = "GLua Project (*.glu)|*.glu";
                    sfd.OverwritePrompt = true;
                    sfd.SupportMultiDottedExtensions = true;
                    sfd.ValidateNames = true;

                    if (sfd.ShowDialog() != DialogResult.OK)
                        return;

                    project.FullName = sfd.FileName;
                    project.Path = new FileInfo(project.FullName).Directory.FullName;
                    project.Save();
                }
                else
                {
                    project.Save();
                }
            }
        }
        /// <summary>
        /// Displays a dialog and renames the project
        /// </summary>
        public void RenameProject()
        {
            if (IsProjectOpen())
            {
                // HACK!!! FIX!!!
                //RenameResult rr = RenameDialog.ShowDialog(project.Name);

                //foreach (char chr in rr.RenameRes.ToCharArray())
                //{
                //    foreach (char invalidChar in Path.GetInvalidFileNameChars())
                //    {
                //        if (chr == invalidChar)
                //        {
                //            Util.ShowError(StringTable.InvalidProjectName);
                //            RenameProject();
                //            return;
                //        }
                //    }
                //}

                //switch (rr.DialogRes)
                //{
                //    case DialogResult.OK:
                //        bool pInfoShown = false;
                //        if (IsProjectInfoShown())
                //        {
                //            pInfoShown = true;
                //            CloseProjectInfo();
                //        }
                //        RenameProjectNode(rr.RenameRes);
                //        project.Name = rr.RenameRes;
                //        if (pInfoShown)
                //            ShowProjectInfo();
                //        project.Saved = false;
                //        break;
                //    case DialogResult.Cancel:
                //        return;
                //}
            }
        }

        /// <summary>
        /// Shows a dialog and opens a file which will not be part of the project
        /// </summary>
        public void OpenFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open file...";
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.DereferenceLinks = true;
            ofd.Filter = "Lua Files (*.lua)|*.lua|All Files (*.*)|*.*";
            ofd.Multiselect = true;

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            foreach (string file in ofd.FileNames)
            {
                OpenedFile of = new OpenedFile();
                of.FullName = file;
                FileInfo fi = new FileInfo(file);
                of.Name = fi.Name;
                of.Saved = true;

                ShowOpenedFile(of);
            }
        }
        /// <summary>
        /// Opens a file directly from a filename
        /// </summary>
        /// <param name="fname">The filename to open</param>
        public void OpenFile(string fname)
        {
            OpenedFile of = new OpenedFile();
            of.FullName = fname;
            FileInfo fi = new FileInfo(fname);
            of.Name = fi.Name;
            of.Saved = true;

            ShowOpenedFile(of);
        }
        /// <summary>
        /// Creates and shows a tab for an opened file which is sperate from the project
        /// </summary>
        /// <param name="file">The file to open</param>
        public void ShowOpenedFile(OpenedFile file)
        {
            fileLoading = true;

            CodeTab ct = new CodeTab(file);
            ct.TabText = file.Name;
            ct.Show(manager);

            if (file.Editor == null)
                file.Editor = ct.editor;

            fileLoading = false;

        }
        /// <summary>
        /// Adds a previously created project file to the project
        /// </summary>
        /// <param name="file">The file to add</param>
        public void AddProjectFile(OpenedFile file)
        {
            if (file.Folder == null)
            {
                // Add to Project
                project.Files.Add(file);
                TreeNode tn = new TreeNode();
                tn.Text = file.Name;
                tn.ImageKey = "code";
                tn.ContextMenuStrip = codeStrip;
                tn.SelectedImageKey = "code";
                tn.Tag = file;
                file.Node = tn;
                treeView.Nodes[0].Nodes.Add(tn);
                treeView.ExpandAll();
            }
            else
            {
                // Add to the folder
                file.Folder.Files.Add(file);
                TreeNode tn = new TreeNode();
                tn.Text = file.Name;
                tn.ImageKey = "code";
                tn.ContextMenuStrip = codeStrip;
                tn.SelectedImageKey = "code";
                tn.Tag = file;
                file.Node = tn;
                file.Folder.Node.Nodes.Add(tn);
                treeView.ExpandAll();
            }
        }

        public void AddProjectFolder(Folder folder)
        {
            TreeNode tn = new TreeNode();
            tn.Text = folder.Name;
            tn.ImageKey = "project_folder_closed";
            tn.ContextMenuStrip = folderStrip;
            tn.SelectedImageKey = "project_folder_closed";
            tn.Tag = folder;
            folder.Node = tn;

            if (folder.Parent == null)
                treeView.Nodes[0].Nodes.Add(tn);
            else
                folder.Parent.Node.Nodes.Add(tn);

            treeView.ExpandAll();
        }

        public void NewFolder()
        {
            NewFolderDialog nfd = new NewFolderDialog();
            if (nfd.ShowDialog() == DialogResult.OK)
            {
                if (explorer.tvFiles.SelectedNode != null && explorer.tvFiles.SelectedNode.Tag.GetType().Name == "Project")
                {
                    bool found = false;
                    foreach (Folder f in project.Folders)
                    {
                        if (f.Name == nfd.txtFolderName.Text)
                        {
                            Util.ShowError(" Folder Already Exists: " + nfd.txtFolderName.Text + " ");
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        // Try and create the folder on the filesystem
                        try { Directory.CreateDirectory(project.Path + "\\" + nfd.txtFolderName.Text); }
                        catch { }

                        Folder folder = new Folder();
                        folder.Name = nfd.txtFolderName.Text;
                        folder.project = project;
                        folder.Parent = null;
                        folder.workspace = this;
                        project.Folders.Add(folder);
                        AddProjectFolder(folder);
                    }
                }
                else if (explorer.tvFiles.SelectedNode != null && explorer.tvFiles.SelectedNode.Tag.GetType().Name == "Folder")
                {
                    bool found = false;
                    foreach (Folder f in ((Folder)explorer.tvFiles.SelectedNode.Tag).Folders)
                    {
                        if (f.Name == nfd.txtFolderName.Text)
                        {
                            Util.ShowError(" Folder Already Exists: " + nfd.txtFolderName.Text + " ");
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {

                        string filepath = project.Path;

                        // Recurse through the folders (parents) until the parent is null, then work our way back through
                        Folder ff = ((Folder)explorer.tvFiles.SelectedNode.Tag);

                        List<Folder> fldrList = new List<Folder>();

                        while (ff != null)
                        {
                            fldrList.Add(ff);
                            ff = ff.Parent;
                        }

                        for (int i = fldrList.Count - 1; i >= 0; i--)
                        {
                            if (ff == ((Folder)explorer.tvFiles.SelectedNode.Tag))
                            {
                                break;
                            }
                            else
                            {
                                ff = fldrList[i];
                                filepath += "\\" + ff.Name;
                            }
                        }

                        filepath += "\\";

                        // Try and create the folder on the filesystem
                        try { Directory.CreateDirectory(filepath + nfd.txtFolderName.Text); }
                        catch { }

                        Folder folder = new Folder();
                        folder.Name = nfd.txtFolderName.Text;
                        folder.project = project;
                        folder.Parent = ((Folder)explorer.tvFiles.SelectedNode.Tag);
                        folder.workspace = this;
                        // WTF WTF WTF WTF WTF WTF WTF WTF WTF WTF WTF WTF WTF WTF WTF WTF WTF WTF WTF WTF WTF WTF WTF
                        //project.Folders.Add( folder );
                        // This should fix our little issue..
                        ((Folder)explorer.tvFiles.SelectedNode.Tag).Folders.Add(folder);
                        AddProjectFolder(folder);
                    }
                }

            }
        }

        /// <summary>
        /// Removes a previously created project file from the project
        /// </summary>
        /// <param name="file">The file to remove</param>
        public void RemoveProjectFile(OpenedFile file)
        {
            if (IsProjectOpen())
            {
                // HACK!!! FIX!!!
                //DialogResult res = FileRemoveDialog.ShowDialog(file.Name);

                //switch (res)
                //{
                //    case DialogResult.Yes:
                //        File.Delete(file.FullName);
                //        CloseCodeTab(file);
                //        RemoveNode(file);
                //        project.Files.Remove(file);
                //        project.Saved = false;
                //        break;
                //    case DialogResult.No:
                //        CloseCodeTab(file);
                //        RemoveNode(file);
                //        project.Files.Remove(file);
                //        project.Saved = false;
                //        break;
                //    case DialogResult.Cancel:
                //        return;
                //}

            }
        }
        /// <summary>
        /// Displays a dialog and renames a project file
        /// </summary>
        /// <param name="file">The file to rename</param>
        public void RenameProjectFile(OpenedFile file)
        {
            if (IsProjectOpen())
            {

                // HACK!!! FIX!!!
                //RenameResult rr = RenameDialog.ShowDialog(file.Name);

                //foreach (char chr in rr.RenameRes.ToCharArray())
                //{
                //    foreach (char invalidChar in Path.GetInvalidFileNameChars())
                //    {
                //        if (chr == invalidChar)
                //        {
                //            // invalid character, call RenameProjectFile() again
                //            Util.ShowError(StringTable.InvalidFileName);
                //            RenameProjectFile(file);
                //            return;
                //        }
                //    }
                //}

                //switch (rr.DialogRes)
                //{
                //    case DialogResult.OK:
                //        if (file.Name == rr.RenameRes)
                //            return;

                //        File.Copy(file.FullName, file.FullName.Replace(file.Name, rr.RenameRes));
                //        File.Delete(file.FullName);
                //        RenameNode(file, rr.RenameRes);
                //        RenameCodeTab(file, rr.RenameRes);
                //        file.FullName = file.FullName.Replace(file.Name, rr.RenameRes);
                //        file.Name = rr.RenameRes;
                //        file.Saved = false;
                //        project.Saved = false;
                //        break;
                //    case DialogResult.Cancel:
                //        return;
                //}
            }
        }
        /// <summary>
        /// Makes a previously opened project file active
        /// </summary>
        /// <param name="file">The file to activate</param>
        public void MakeProjectFileActive(OpenedFile file)
        {
            // HACK: FIX!
            //foreach ( TabbedDocument tp in manager.Documents )
            //{
            //    if ( !IsSpecialTab( tp ) )
            //    {
            //        if ( tp.Tag == file )
            //            manager.ActiveDocument = tp;
            //    }
            //}
        }
        /// <summary>
        /// Creates a tab and shows a project file, if the tab is already created it is made active
        /// </summary>
        /// <param name="file">The file to show</param>
        public void ShowProjectFile(OpenedFile file)
        {
            if (IsProjectFileShown(file))
            {
                MakeProjectFileActive(file);
                return;
            }

            if (File.Exists(file.FullName))
            {
                file.Valid = true;
                file.Node.ImageKey = "code";
                file.Node.SelectedImageKey = "code";
            }
            else
            {
                Util.ShowError(StringTable.ProjectFileLost.Replace("%FILE%", file.Name));
                return;
            }

            if (!fileLoading)
            {
                fileLoading = true;

                CodeTab ct = new CodeTab(file);
                ct.TabText = file.Name;
                ct.Show(manager);

                file.Editor = ct.editor;

                fileLoading = false;
            }
        }

        /// <summary>
        /// Saves a project file
        /// </summary>
        /// <param name="file">The project file to save</param>
        public void SaveProjectFile(OpenedFile file)
        {
            file.Save();
        }

        /// <summary>
        /// Shows a special tab
        /// </summary>
        /// <param name="specialTab">The special tab to open</param>
        public void ShowSpecialTab(SpecialTab specialTab)
        {
            if (IsSpecialTabShown(specialTab))
                return;

            switch (specialTab.Type)
            {
                case TabType.ObjectBrowser:
                    ShowObjectBrowser();
                    break;
                case TabType.ProjectInfo:
                    ShowProjectInfo();
                    break;
            }
        }
        /// <summary>
        /// Checks for special tabs and files, asks to save, and then closes the currently active tab
        /// </summary>
        public void CloseActiveTab()
        {
            // BIG HACK!!!!!

            //if (IsSpecialTab((DockableWindow)manager.ActiveDocument))
            //{
            //    if ( ( ( SpecialTab )manager.ActiveDocument.DockHandler.Tag ).Type == TabType.ObjectBrowser )
            //    {
            //        CloseObjectBrowser();
            //        return;
            //    }
            //    if ( ( ( SpecialTab )manager.ActiveDocument ).Type == TabType.ProjectInfo )
            //    {
            //        CloseProjectInfo();
            //        return;
            //    }
            //}
            //else
            //{
            //    if ( manager.ActiveDocument.DockHandler.Tag is ProjectFile )
            //    {
            //        ProjectFile pf = ( ProjectFile )manager.ActiveDocument.DockHandler.Tag;

            //        if ( !pf.Saved )
            //        {
            //            DialogResult res = Util.ShowQuestion( StringTable.FileNotSaved.Replace( "%FILE%", pf.Name ) );

            //            switch ( res )
            //            {
            //                case DialogResult.Yes:
            //                    pf.Save();
            //                    manager.ActiveDocument.Close();
            //                    break;
            //                case DialogResult.No:
            //                    manager.ActiveDocument.Close();
            //                    break;
            //                case DialogResult.Cancel:
            //                    return;

            //            }
            //        }
            //        else
            //        {
            //            manager.ActiveDocument.Close();
            //        }
            //    }
            //    else if ( manager.ActiveDocument.Tag is OpenedFile )
            //    {
            //        OpenedFile of = ( OpenedFile )manager.ActiveDocument.Tag;

            //        if ( !of.Saved )
            //        {
            //            DialogResult res = Util.ShowQuestion( StringTable.FileNotSaved.Replace( "%FILE%", of.Name ) );

            //            switch ( res )
            //            {
            //                case DialogResult.Yes:
            //                    of.Save();
            //                    manager.ActiveDocument.Close();
            //                    break;
            //                case DialogResult.No:
            //                    manager.ActiveDocument.Close();
            //                    break;
            //                case DialogResult.Cancel:
            //                    return;

            //            }
            //        }
            //        else
            //        {
            //            manager.ActiveDocument.Close();
            //        }
            //    }
            //}
        }
        /// <summary>
        /// Closes a code tab without saving
        /// </summary>
        /// <param name="file"></param>
        public void CloseCodeTab(OpenedFile file)
        {
            foreach (DockableWindow td in manager.Documents)
            {
                if (!IsSpecialTab(td))
                {
                    if (td.Tag == file)
                        td.Close();
                }
            }
        }
        /// <summary>
        /// Renames a a code tab of a project file
        /// </summary>
        /// <param name="file">The project file to rename</param>
        /// <param name="newName">The new name to give the code tab</param>
        public void RenameCodeTab(OpenedFile file, string newName)
        {
            foreach (DockableWindow td in manager.Documents)
            {
                if (!IsSpecialTab(td))
                {
                    if (td.Tag == file)
                        td.Text = newName;
                }
            }
        }
        /// <summary>
        /// Asks to save and closes all tabs except the active tab
        /// </summary>
        public void CloseAllButActiveTab()
        {
            foreach (DockableWindow tp in manager.Documents)
            {
                if (tp == manager.ActiveDocument)
                    continue;

                if (IsSpecialTab(tp))
                {
                    if (((SpecialTab)tp.Tag).Type == TabType.ObjectBrowser)
                        CloseObjectBrowser();
                    if (((SpecialTab)tp.Tag).Type == TabType.ProjectInfo)
                        CloseProjectInfo();
                }
                else
                {
                    if (tp.Tag is OpenedFile)
                    {
                        OpenedFile pf = (OpenedFile)tp.Tag;

                        if (!pf.Saved)
                        {
                            DialogResult res = Util.ShowQuestion(StringTable.FileNotSaved.Replace("%FILE%", pf.Name));

                            switch (res)
                            {
                                case DialogResult.Yes:
                                    pf.Save();
                                    tp.Close();
                                    break;
                                case DialogResult.No:
                                    tp.Close();
                                    break;
                                case DialogResult.Cancel:
                                    return;

                            }
                        }
                        else
                        {
                            tp.Close();
                        }
                    }

                }
            }
        }
        /// <summary>
        /// Attempts to save the currently active tab
        /// </summary>
        public void SaveActiveTab()
        {
            if (manager.ActiveDocument == null)
                return;
            else
            {
                if (manager.ActiveDocument.GetType().Name == "CodeTab")
                {
                    System.Diagnostics.Debug.WriteLine("Active Tabs Name: " + ((CodeTab)manager.ActiveDocument).Tag.GetType().Name);
                    if (((CodeTab)manager.ActiveDocument).Tag.GetType().Name == "OpenedFile")
                        ((OpenedFile)((CodeTab)manager.ActiveDocument).Tag).Save();
                }
            }

        }

        /// <summary>
        /// Shows a save dialog and generates an info file
        /// </summary>
        public void GenerateInfoFile()
        {
            if (IsProjectOpen())
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.AddExtension = true;
                sfd.DefaultExt = ".txt";
                sfd.FileName = "info.txt";
                sfd.Filter = "Info Files (info.txt)|info.txt";
                sfd.InitialDirectory = project.Path;
                sfd.Title = "Save Info File...";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                InfoGenerator.GenerateInfo(sfd.FileName, project);
            }
        }

        /// <summary>
        /// Checks for any active code files and projects, asks to save, closes and removes tabs, and saves settings
        /// </summary>
        /// <returns>True if the exit completed successfully, otherwise false if the user decided to cancel</returns>
        public bool Exit()
        {
            if (IsProjectOpen())
            {
                if (!IsProjectSaved())
                {
                    DialogResult res = Util.ShowQuestion(StringTable.ProjectNotSaved);

                    switch (res)
                    {
                        case DialogResult.Yes:
                            SaveProject();
                            RemoveProject();
                            break;
                        case DialogResult.No:
                            RemoveProject();
                            break;
                        case DialogResult.Cancel:
                            return false;
                    }
                }
                RemoveProject();
            }

            if (IsCodeTabOpen())
            {
                foreach (DockableWindow td in manager.Documents)
                {
                    if (!IsSpecialTab(td))
                    {
                        if (td.Tag is OpenedFile)
                        {
                            OpenedFile of = (OpenedFile)td.Tag;

                            if (!of.Saved)
                            {

                                DialogResult res = Util.ShowQuestion(StringTable.FileNotSaved.Replace("%FILE%", of.Name));

                                switch (res)
                                {
                                    case DialogResult.Yes:
                                        of.Save();
                                        td.Close();
                                        break;
                                    case DialogResult.No:
                                        td.Close();
                                        break;
                                    case DialogResult.Cancel:
                                        return false;
                                }
                            }
                        }
                    }
                }
            }
            // HACK!!! FIX!!!
            //Settings.Save(Application.StartupPath + "\\data\\settings.xml", settings);

            return true;
        }

        /// <summary>
        /// Shows the add new item dialog and adds a new item
        /// </summary>
        public void AddNewItem()
        {
            if (IsProjectOpen())
            {

                NewFileDialog nfd = new NewFileDialog();

                if (nfd.ShowDialog() != DialogResult.OK)
                    return;

                OpenedFile pf = new OpenedFile();
                string filePath = "";

                if (explorer.tvFiles.SelectedNode == null) // Just do the normal adding to project...
                {
                    filePath = project.Path;
                    pf.Folder = null;
                }
                else if (explorer.tvFiles.SelectedNode.Tag.GetType().Name == "Project") // Clicked on project
                {
                    filePath = project.Path;
                    pf.Folder = null;
                }
                else if (explorer.tvFiles.SelectedNode.Tag.GetType().Name == "Folder") // Clicked on Folder
                {
                    filePath = ((Folder)explorer.tvFiles.SelectedNode.Tag).FullName();
                    pf.Folder = ((Folder)explorer.tvFiles.SelectedNode.Tag);
                }
                else if (explorer.tvFiles.SelectedNode.Tag.GetType().Name == "OpenedFile") // Clicked on a File so get its folder or parent.
                {
                    if (((OpenedFile)explorer.tvFiles.SelectedNode.Tag).Folder == null) // Project File
                    {
                        filePath = project.Path;
                        pf.Folder = null;
                    }
                    else // File in Folder, so folders parent is cool :D
                    {
                        filePath = ((OpenedFile)explorer.tvFiles.SelectedNode.Tag).Folder.FullName();
                        pf.Folder = ((OpenedFile)explorer.tvFiles.SelectedNode.Tag).Folder;
                    }
                }
                else
                {
                    filePath = project.Path;
                    pf.Folder = null;
                }

                if (File.Exists(filePath + "\\" + nfd.FileName))
                {
                    Util.ShowError(StringTable.FileAlreadyExists);
                    AddNewItem();
                    return;
                }
                File.Create(filePath + "\\" + nfd.FileName).Close();
                File.WriteAllText(filePath + "\\" + nfd.FileName, nfd.SelectedTemplate.Code);

                pf.Name = nfd.FileName;
                pf.Saved = false;
                pf.FullName = filePath + "\\" + pf.Name;

                project.Saved = false;

                AddProjectFile(pf);

                SaveProject();

                OpenFile(filePath + "\\" + nfd.FileName);

            }
        }
        /// <summary>
        /// Shows the open file dialog and adds an existing item
        /// </summary>
        public void AddExistingItem()
        {
            if (IsProjectOpen())
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Lua Files (*.lua)|*.lua";
                ofd.Multiselect = true;
                ofd.Title = "Add Existing Item...";

                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                foreach (string name in ofd.FileNames)
                {
                    FileInfo fi = new FileInfo(name);

                    // Were we clicked on a node in the treeview? If so, was it a folder or a file in a 
                    // Folder? If so, add it to that folder, otherwise just add it to the project.
                    object selNode = explorer.tvFiles.SelectedNode.Tag;
                    OpenedFile selFile;
                    Folder selFolder;
                    OpenedFile pf;
                    if (selNode.GetType().Name == "OpenedFile")
                    {
                        selFile = ((OpenedFile)selNode);
                        if (selFile.Folder == null)
                        {
                            // Add to Project
                            pf = new OpenedFile();
                            pf.Name = fi.Name;
                            pf.Saved = true;
                            pf.FullName = project.Path + "\\" + pf.Name;
                        }
                        else
                        {
                            // Add to the selected files containing folder
                            pf = new OpenedFile();
                            pf.Name = fi.Name;
                            pf.Saved = true;
                            pf.Folder = selFile.Folder;
                            pf.FullName = selFile.Folder.FullName() + "\\" + fi.Name;
                        }
                    }
                    else if (selNode.GetType().Name == "Folder")
                    {
                        selFolder = ((Folder)selNode);
                        // Add to the selected files containing folder
                        pf = new OpenedFile();
                        pf.Name = fi.Name;
                        pf.Saved = true;
                        pf.Folder = selFolder;
                        pf.FullName = selFolder.FullName() + "\\" + fi.Name;
                    }
                    else
                    {
                        // Just add it to the project
                        // Add to Project
                        pf = new OpenedFile();
                        pf.Name = fi.Name;
                        pf.Saved = true;
                        pf.FullName = project.Path + "\\" + pf.Name;
                    }

                    if (DoesProjectFileExist(pf.FullName))
                    {
                        Util.ShowError(StringTable.FileAlreadyAdded);
                        continue;
                    }
                    AddProjectFile(pf);
                }

                project.Saved = false;

                SaveProject();
            }
        }

        /// <summary>
        /// Deletes a folder from the Project, and possibly from the filesystem also.
        /// </summary>
        /// <param name="folder">The folder to Delete</param>
        public void DeleteFolder(Folder folder)
        {
            DialogResult msgRes = Util.ShowQuestion("Do you want to remove the physical folder from the hard drive?\nYes: Remove both Project Reference and Physical Folder\nNo: Remove Project Reference and leave Physical Folder\nCancel: Cancel File Operation");

            if (msgRes == DialogResult.Yes)
            {
                // Remove the TreeNode
                folder.Node.Remove();
                // Remove physical file
                Directory.Delete(folder.FullName(), true);
                // Remove the project reference
                if (folder.Parent == null)
                    // Remove from Project
                    project.Folders.Remove(folder);
                else
                    // Remove from the parent folder
                    folder.Parent.Folders.Remove(folder);
            }
            else if (msgRes == DialogResult.No)
            {
                folder.Node.Remove();
                // Remove just the project reference
                if (folder.Parent == null)
                    // Remove from Project
                    project.Folders.Remove(folder);
                else
                    // Remove from the parent folder
                    folder.Parent.Folders.Remove(folder);
            }
            else
            {
                // Do Nothing.
            }

        }

        public void DeleteFile(OpenedFile file)
        {
            DialogResult msgRes = Util.ShowQuestion("Do you want to remove the physical File from the hard drive?\nYes: Remove both Project Reference and Physical File\nNo: Remove Project Reference and leave Physical File\nCancel: Cancel File Operation");

            if (msgRes == DialogResult.Yes)
            {
                // Remove the TreeNode
                file.Node.Remove();
                if (file.FullName != null)
                    // Remove physical file
                    File.Delete(file.FullName);
                // Remove the project reference
                if (file.Folder == null)
                    // Remove from Project
                    project.Files.Remove(file);
                else
                    // Remove from the parent folder
                    file.Folder.Files.Remove(file);
            }
            else if (msgRes == DialogResult.No)
            {
                file.Node.Remove();
                // Remove the project reference
                if (file.Folder == null)
                    // Remove from Project
                    project.Files.Remove(file);
                else
                    // Remove from the parent folder
                    file.Folder.Files.Remove(file);
            }
            else
            {
                // Do Nothing.
            }
        }

        ///// <summary>
        ///// Creates an lua specific syntax editor control
        ///// </summary>
        ///// <returns>A customized syntax edit control used for editing lua files</returns>
        //public CodeEditorControl CreateTextEditor()
        //{
        //    CodeEditorControl se = new CodeEditorControl();

        //    //se.Lexer = new Lexer();
        //    //se.Lexer.LoadScheme( Application.StartupPath + "\\data\\lua_scheme.xml" );

        //    //se.Dock = DockStyle.Fill;

        //    //se.Gutter.Options = GutterOptions.PaintLineModificators | GutterOptions.PaintLineNumbers;
        //    //se.Source.HighlightUrls = true;
        //    //se.Source.UndoOptions = UndoOptions.AllowUndo | UndoOptions.UndoAfterSave;
        //    //se.TextChanged += new EventHandler( se_TextChanged );
        //    //se.NeedCodeCompletion += new CodeCompletionEvent( se_NeedCodeCompletion );
        //    //se.MouseClick += new MouseEventHandler( se_MouseClick );
        //    //se.Braces.BracesOptions = BracesOptions.Highlight | BracesOptions.HighlightBounds;
        //    //se.Braces.ClosingBraces = new char[] { ')', ']', '}' };
        //    //se.Braces.OpenBraces = new char[] { '(', '[', '{' };
        //    //se.CodeCompletionChars = new char[] { '.', ':', '(', ',' };
        //    //se.DisplayLines.AllowOutlining = true;
        //    //se.DisplayLines.OutlineOptions = OutlineOptions.DrawButtons | OutlineOptions.DrawLines | OutlineOptions.ShowHints;
        //    //se.Gutter.LineNumbersAlignment = StringAlignment.Far;
        //    //se.Gutter.LineNumbersStart = 1;
        //    //se.Gutter.LineNumbersLeftIndent = 20;
        //    //se.IndentOptions = IndentOptions.AutoIndent;
        //    //se.Scrolling.Options = ScrollingOptions.SmoothScroll | ScrollingOptions.ShowScrollHint;

        //    //// file menu shortcuts
        //    //se.KeyList.Add( Keys.Control | Keys.Shift | Keys.S, new KeyEvent( se_SaveProject ) );
        //    //se.KeyList.Add( Keys.Control | Keys.S, new KeyEvent( se_SaveActive ) );
        //    //se.KeyList.Add( Keys.Control | Keys.Shift | Keys.N, new KeyEvent( se_NewProject ) );
        //    //se.KeyList.Add( Keys.Control | Keys.Shift | Keys.O, new KeyEvent( se_OpenProject ) );
        //    //se.KeyList.Add( Keys.Control | Keys.O, new KeyEvent( se_OpenFile ) );
        //    //se.KeyList.Add( Keys.Alt | Keys.F4, new KeyEvent( se_Exit ) );

        //    //// view menu shortcuts
        //    //se.KeyList.Add( Keys.Control | Keys.Alt | Keys.E, new KeyEvent( se_ShowProjectExplorer ) );
        //    //se.KeyList.Add( Keys.Control | Keys.Alt | Keys.B, new KeyEvent( se_ShowObjectBrowser ) );
        //    //se.KeyList.Add( Keys.Control | Keys.Alt | Keys.T, new KeyEvent( se_ShowTaskList ) );
        //    //se.KeyList.Add( Keys.Control | Keys.Alt | Keys.O, new KeyEvent( se_ShowOutput ) );

        //    //// project menu shortcuts
        //    //se.KeyList.Add( Keys.Control | Keys.Shift | Keys.A, new KeyEvent( se_AddNewItem ) );
        //    //se.KeyList.Add( Keys.Alt | Keys.Shift | Keys.A, new KeyEvent( se_AddExistingItem ) );

        //    //// help menu shortcuts
        //    //se.KeyList.Add( Keys.F1, new KeyEvent( se_GmodWiki ) );
        //    //se.KeyList.Add( Keys.Alt | Keys.F1, new KeyEvent( se_FPLuaScripting ) );
        //    //se.KeyList.Add( Keys.Control | Keys.F1, new KeyEvent( se_GLuaHome ) );

        //    //// code edit shortcuts
        //    //se.KeyList.Add( Keys.Control | Keys.J, new KeyEvent( se_WordCompletion ) );


        //    //se.DefaultMenu.MenuItems.Clear();
        //    //se.Refresh();
        //    //se.Update();
        //    se.BorderStyle = ControlBorderStyle.SunkenThin;
        //    return se;
        //}
        /// <summary>
        /// Checks if the environment can undo
        /// </summary>
        /// <returns>True if undo is allowed, otherwise false</returns>
        public bool CanUndo()
        {
            if (IsTabOpen())
            {
                if (IsActiveTabSpecial())
                    return false;
                else
                {
                    CodeEditorControl edit = (CodeEditorControl)manager.ActiveDocument.DockHandler.DockPanel.Controls[0];
                    return edit.CanUndo;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Checks if the environment can redo
        /// </summary>
        /// <returns>True if redo is allowed, otherwise false</returns>
        public bool CanRedo()
        {
            if (IsTabOpen())
            {
                if (IsActiveTabSpecial())
                    return false;
                else
                {
                    CodeEditorControl edit = (CodeEditorControl)manager.ActiveDocument.DockHandler.DockPanel.Controls[0];
                    return edit.CanRedo;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Checks if the environment can cut
        /// </summary>
        /// <returns>True if cut is allowed, otherwise false</returns>
        public bool CanCut()
        {
            if (IsTabOpen())
            {
                if (IsActiveTabSpecial())
                    return false;
                else
                {
                    CodeEditorControl edit = (CodeEditorControl)manager.ActiveDocument.DockHandler.DockPanel.Controls[0];
                    return edit.CanCopy;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Checks if the environment can copy
        /// </summary>
        /// <returns>True if copy is allowed, otherwise false</returns>
        public bool CanCopy()
        {
            if (IsTabOpen())
            {
                if (IsActiveTabSpecial())
                    return false;
                else
                {
                    CodeEditorControl edit = (CodeEditorControl)manager.ActiveDocument.DockHandler.DockPanel.Controls[0];
                    return edit.CanCopy;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Checks if the environment can paste
        /// </summary>
        /// <returns>True if paste is allowed, otherwise false</returns>
        public bool CanPaste()
        {
            if (IsTabOpen())
            {
                if (IsActiveTabSpecial())
                    return false;
                else
                {
                    CodeEditorControl edit = (CodeEditorControl)manager.ActiveDocument.DockHandler.DockPanel.Controls[0];
                    return edit.CanPaste;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Checks if the environment can delete
        /// </summary>
        /// <returns>True if delete is allowed, otherwise false</returns>
        public bool CanDelete()
        {
            return IsCodeTabOpen();
        }
        /// <summary>
        /// Undo's the last change in the editor
        /// </summary>
        public void Undo()
        {
            if (IsActiveTabSpecial())
                return;
            else
            {
                if (IsCodeTab(((DockableWindow)manager.ActiveDocument)))
                {
                    CodeEditorControl edit = ((CodeTab)manager.ActiveDocument).editor;
                    edit.Undo();
                }
            }
        }
        /// <summary>
        /// Redo's the last change in the editor
        /// </summary>
        public void Redo()
        {
            if (IsActiveTabSpecial())
                return;
            else
            {
                if (IsCodeTab((DockableWindow)manager.ActiveDocument))
                {
                    CodeEditorControl edit = ((CodeTab)manager.ActiveDocument).editor;
                    edit.Redo();
                }
            }
        }
        /// <summary>
        /// Cuts text from the editor
        /// </summary>
        public void Cut()
        {
            if (IsActiveTabSpecial())
                return;
            else
            {
                if (IsCodeTab((DockableWindow)manager.ActiveDocument))
                {
                    CodeEditorControl edit = ((CodeTab)manager.ActiveDocument).editor;
                    edit.Cut();
                }
            }
        }
        /// <summary>
        /// Copies text from the editor
        /// </summary>
        public void Copy()
        {
            if (IsActiveTabSpecial())
                return;
            else
            {
                if (IsCodeTab((DockableWindow)manager.ActiveDocument))
                {
                    CodeEditorControl edit = ((CodeTab)manager.ActiveDocument).editor;
                    edit.Copy();
                }
            }
        }
        /// <summary>
        /// Pastes text to the editor
        /// </summary>
        public void Paste()
        {
            if (IsActiveTabSpecial())
                return;
            else
            {
                if (IsCodeTab((DockableWindow)manager.ActiveDocument))
                {
                    CodeEditorControl edit = ((CodeTab)manager.ActiveDocument).editor;
                    edit.Paste();
                }
            }
        }
        /// <summary>
        /// Deletes the currently selected text in the editor
        /// </summary>
        public void Delete()
        {
            if (IsActiveTabSpecial())
                return;
            else
            {
                if (IsCodeTab((DockableWindow)manager.ActiveDocument))
                {
                    CodeEditorControl edit = ((CodeTab)manager.ActiveDocument).editor;
                    edit.Delete();
                }
            }
        }
        /// <summary>
        /// Selects all text in the editor
        /// </summary>
        public void SelectAll()
        {
            if (IsActiveTabSpecial())
                return;
            else
            {
                if (IsCodeTab((DockableWindow)manager.ActiveDocument))
                {
                    CodeEditorControl edit = ((CodeTab)manager.ActiveDocument).editor;
                    edit.SelectAll();
                }
            }
        }
        /// <summary>
        /// Displays a find dialog
        /// </summary>
        public void FindDialog()
        {

        }
        /// <summary>
        /// Displays a find dialog with pre-entered text in the textbox
        /// </summary>
        /// <param name="input">The text to have displayed</param>
        // Apparently the editor control doesn't support this
        // A quit edit in the SE library can change this
        public void FindDialog(string input)
        {

        }
        /// <summary>
        /// Displays the replace dialog
        /// </summary>
        public void ReplaceDialog()
        {
            //// TODO: REPLACE DIALOG
        }



        public void Find()
        {
            FindDialog();
        }

        public void Find(String findStr)
        {

        }

        public void Replace()
        {
            ReplaceDialog();
        }

        public void GenerateInfo()
        {
            if (IsProjectOpen())
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.AddExtension = true;
                sfd.DefaultExt = ".txt";
                sfd.FileName = "info.txt";
                sfd.Filter = "Info Files (info.txt)|info.txt";
                sfd.InitialDirectory = project.Path;
                sfd.Title = "Save Info File...";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                InfoGenerator.GenerateInfo(sfd.FileName, project);
            }
        }

        // Blame P90 for all bugs related to this.
        public void ShowAbout()
        {
            //new AboutBox().Show();
        }

        public void ShowSettings()
        {

        }

        public void ShowProjectExplorer()
        {
            explorer.Show();
        }

        public void HideProjectExplorer()
        {
            explorer.Hide();
        }

        public void ShowOutputWindow()
        {
            if (output == null)
                return;
            output.Show();
        }

        public void ShowTaskList()
        {
            if (taskList == null)
                return;
            taskList.Show();
        }

        public void ReportBug()
        {
            bug.Show(manager);
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (treeView.SelectedNode == null)
                return;

            //if (treeView.SelectedNode.Tag.GetType().Name == "ProjectFile")
            //{
            //    MessageBox.Show(((ProjectFile)treeView.SelectedNode.Tag).FullName);
            //}
        }

        #region "Tasks"

        public void AddTask()
        {
            frmAddEditTask taskEdit = new frmAddEditTask();
            if (taskEdit.ShowDialog() == DialogResult.OK)
            {
                Task task = new Task();
                if (taskEdit.cmbPriority.SelectedIndex == -1)
                    taskEdit.cmbPriority.SelectedIndex = 2;

                task.Priority = (Task.TaskPriority)taskEdit.cmbPriority.SelectedIndex;
                task.Text = taskEdit.txtTaskName.Text;
                project.Tasks.Add(task);
                taskList.Reload();

            }
        }

        public void EditTask(ListViewItem task)
        {
            Task currTask = null;

            foreach (Task taskk in project.Tasks)
            {
                if (taskk.lvm == task)
                    currTask = taskk;
            }

            if (currTask == null)
                return;

            frmAddEditTask taskEdit = new frmAddEditTask();
            taskEdit.txtTaskName.Text = currTask.Text;
            taskEdit.cmbPriority.SelectedIndex = (int)currTask.Priority;

            if (taskEdit.ShowDialog() == DialogResult.OK)
            {
                currTask.Text = taskEdit.txtTaskName.Text;
                if (taskEdit.cmbPriority.SelectedIndex == -1)
                    taskEdit.cmbPriority.SelectedIndex = 2;

                currTask.Priority = (Task.TaskPriority)taskEdit.cmbPriority.SelectedIndex;
                taskList.Reload();
            }
        }

        public void DeleteTask(ListView.SelectedListViewItemCollection tasks)
        {
            if (Util.ShowQuestion("Do you want to delete these tasks?") == DialogResult.Yes)
                foreach (ListViewItem ttask in tasks)
                {
                    foreach (Task task in project.Tasks)
                    {
                        if (task.lvm == ttask)
                        {
                            project.Tasks.Remove(task);
                        }
                    }
                }
            taskList.Reload();
        }

        #endregion
        */
    }
}
