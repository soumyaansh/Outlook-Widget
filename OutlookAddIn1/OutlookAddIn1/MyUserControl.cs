using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _OutlookAddIn1.Auth;
using _OutlookAddIn1.witcontrols;
using _OutlookAddIn1.TextBoxControls;
using System.Threading;
using _OutlookAddIn1.controls;

namespace _OutlookAddIn1
{
    public partial class MyUserControl : UserControl
    {

        UserDBConnector userDBConnector;
        MainDBConnector mainDBConnector;
        BackgroundWorker bw = new BackgroundWorker();
        public TreeNode previousSelectedNode = null;
        public String appDataPath = null;
        public String userName = null;
        public String password = null;
        String wsIcon = "C:\\Users\\WittyParrot\\Documents\\Visual Studio 2015\\Projects\\OutlookAddIn1\\packages\\list_icon.ico";
        String folderIcon = "C:\\Users\\WittyParrot\\Documents\\Visual Studio 2015\\Projects\\OutlookAddIn1\\packages\\blackfolder.ico";
        String mailIcon = "C:\\Users\\WittyParrot\\Documents\\Visual Studio 2015\\Projects\\OutlookAddIn1\\packages\\mail.ico";
        String backIcon = "C:\\Users\\WittyParrot\\Documents\\Visual Studio 2015\\Projects\\OutlookAddIn1\\packages\\back.ico";
        String replyIcon = "C:\\Users\\WittyParrot\\Documents\\Visual Studio 2015\\Projects\\OutlookAddIn1\\packages\\reply.ico";
        String logoutIcon = "C:\\Users\\WittyParrot\\Documents\\Visual Studio 2015\\Projects\\OutlookAddIn1\\packages\\logout.ico";
        List<CustomWitPanel> witChildPanels;

        public MyUserControl()
        {
            InitializeComponent();
        }

        private void MyUserControl_Load(object sender, EventArgs e)
        {
            CreateMyStatusBar();
        }

        private void CreateMyStatusBar()
        {
            // Create a StatusBar control.
            StatusBar statusBar1 = new StatusBar();
            statusBar1.PanelClick += new StatusBarPanelClickEventHandler(statusBar1_PanelClick);
            statusBar1.Size = new System.Drawing.Size(400, 40);
           
            // hide the treeview brfore successfull login
            myCustomTreeView.Visible = false;

            
            // Create two StatusBarPanel objects to display in the StatusBar.
            StatusBarPanel networkStatusPanel = new StatusBarPanel();
            StatusBarPanel dateTimePanel = new StatusBarPanel();

            StatusBarPanel networkStatusPanelIcon = new StatusBarPanel();
            networkStatusPanelIcon.Width = 40;

            StatusBarPanel logoutPanel = new StatusBarPanel();
            logoutPanel.Name = "logout";
            logoutPanel.Width = 40;
            logoutPanel.Alignment = HorizontalAlignment.Center;
            logoutPanel.Icon = Resource.Power;

            StatusBarPanel refreshPanel = new StatusBarPanel();
            refreshPanel.Name = "refresh";
            refreshPanel.Width = 40;
            refreshPanel.Alignment = HorizontalAlignment.Center;
            refreshPanel.Icon = Resource.refreshgray;

            StatusBarPanel wpIconPanel = new StatusBarPanel();
            wpIconPanel.Name = "wpiconPanel";
            wpIconPanel.Width = 160;
            wpIconPanel.Alignment = HorizontalAlignment.Center;
            wpIconPanel.Icon = Resource.wplogo;

            networkStatusPanel.AutoSize = StatusBarPanelAutoSize.Spring;
            dateTimePanel.BorderStyle = StatusBarPanelBorderStyle.Raised;

            // Create ToolTip text that displays time the application was started.
            dateTimePanel.ToolTipText = "Started: " + System.DateTime.Now.ToShortTimeString();
            dateTimePanel.Text = System.DateTime.Today.ToLongDateString();
            dateTimePanel.AutoSize = StatusBarPanelAutoSize.Contents;

            // check if net connection is working or not
            bool isConnected = CheckNetConnection.CheckForInternetConnection();
            if (isConnected)
            {
                networkStatusPanel.Text = "connected";
                networkStatusPanelIcon.Icon = Resource.connectedicon;
                networkStatusPanelIcon.Alignment = HorizontalAlignment.Center;
            }
            else {
                networkStatusPanel.Text = "disconnected";
                networkStatusPanelIcon.Icon = Resource.disconnectedicon;
                networkStatusPanelIcon.Alignment = HorizontalAlignment.Center;
            }

            // Display panels in the StatusBar control.
            statusBar1.ShowPanels = true;
            statusBar1.Visible = true;

            // Add both panels to the StatusBarPanelCollection of the StatusBar.			
            statusBar1.Panels.Add(logoutPanel);
            statusBar1.Panels.Add(refreshPanel);
            statusBar1.Panels.Add(networkStatusPanelIcon);           
            statusBar1.Panels.Add(dateTimePanel);
            statusBar1.Panels.Add(wpIconPanel);

            // Add the StatusBar to the form.

            this.Controls.Add(statusBar1);
        }

        public void statusBar1_PanelClick(object sender, StatusBarPanelClickEventArgs e) {

            if (e.StatusBarPanel.Name == "refresh")
            {
                if (userName == null || password == null)
                {
                    MessageBox.Show("User not loggedin");
                }
                else {
                    refreshDatabaseThread();
                }

               
            }

            if (e.StatusBarPanel.Name == "logout")
            {
                if (userName == null || password == null)
                {
                    MessageBox.Show("User not loggedin");
                }
                else {
                    logout();
                }
            }
        }

        private void afterLogin()
        {
            this.Controls.Remove(textBox1);
            this.Controls.Remove(textBox2);
            this.Controls.Remove(button1);
            this.Controls.Remove(label1);
   
            this.Controls.Remove(checkBox1);
            myCustomTreeView.Visible = true;
        }


        private void logout()
        {

            this.Controls.Remove(pnlMenu);
            this.Controls.Remove(witsPanel);
            this.Controls.Remove(myCustomTreeView);


            textBox1.Visible = true;
            textBox2.Visible = true;
            button1.Visible = true;
            label1.Visible = true;
           
            checkBox1.Visible = true;

           
        }

        private void treeView1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            myCustomTreeView.SelectedNode.BackColor = SystemColors.Highlight;
            myCustomTreeView.SelectedNode.ForeColor = Color.White;
            previousSelectedNode = myCustomTreeView.SelectedNode;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (previousSelectedNode != null)
            {
                previousSelectedNode.BackColor = myCustomTreeView.BackColor;
                previousSelectedNode.ForeColor = myCustomTreeView.ForeColor;
            }
        }

        private void SetListViewItemHeight(ListView listView, int height)
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, height);
            listView.SmallImageList = imgList;
        }

        private void refreshDatabaseThread() {

            Thread thread = new Thread(new ThreadStart(refreshDatabase));
            thread.Start();

        }

        private void refreshDatabase()
        {

            try
            {

                RestClientLogin clientLogin = new RestClientLogin();
                RootObject userObject = clientLogin.login(userName, password);

                userDBConnector = new UserDBConnector(userName);
                mainDBConnector = new MainDBConnector();

                mainDBConnector.prepareMainDBSchema(userObject);
                userDBConnector.prepareUserDBSchema(userObject);
                appDataPath = userDBConnector.appPath;

                AccessTokenDao accessTokenDao = new AccessTokenDao();
                userObject.accessToken.id = Utilities.GUIDGenerator.getGUID();
                accessTokenDao.saveAccessToken(userObject.accessToken);

                UserWorkspaceDao workspaceDao = new UserWorkspaceDao(appDataPath);
                workspaceDao.saveWorkspaces(userObject.userProfile.userWorkspaces);

                if (workspaceDao.getWorkspaceNameList() != null && workspaceDao.getWorkspaceNameList().Count != 0)
                {
                    List<UserWorkspace> workspaces = workspaceDao.getWorkspaceList();
                    List<Folder> allFolderList = new List<Folder>();
                    foreach (var workspace in workspaces)
                    {
                        RestClientFolder restClientFolder = new RestClientFolder(appDataPath);
                        restClientFolder.getAllFolders(userObject.accessToken.tokenValue, workspace.WorkspaceId, 0, allFolderList);
                    }

                    FolderDao folderDao = new FolderDao(appDataPath);
                    folderDao.saveAllFolders(allFolderList);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Error occured while refreshing data:" + e.Message);
               
            }

        }
        private void button1_Click_1(object sender, EventArgs e)
        {

            Panel witsPanel = this.witsPanel;
            witsPanel.Visible = false;

            Panel panel = this.pnlMenu;
            panel.Visible = true;

            // get the username and pasword from the widget
            var userName = textBox1.Text;
            var password = textBox2.Text;

            // rest api for login
            RestClientLogin clientLogin = new RestClientLogin();
            RootObject rootObj = clientLogin.login(userName, password);
            this.userName = userName;
            this.password = password;


            // check if the db is already present or not
            userDBConnector = new UserDBConnector(userName);
            if (!userDBConnector.isDataBaseExists()) {
                refreshDatabase();
            }
           

            userDBConnector = new UserDBConnector(userName);
            appDataPath =  userDBConnector.prepareAppLocalSchema();

            UserWorkspaceDao workspaceDao = null;
            List<Folder> allFolderList = null;
            if (rootObj.userProfile.userWorkspaces != null && rootObj.userProfile.userWorkspaces.Count > 0) {

                workspaceDao = new UserWorkspaceDao(appDataPath);
                // fetch all the workspaces and show it in the workspace panel

                if (workspaceDao.getWorkspaceNameList() != null && workspaceDao.getWorkspaceNameList().Count != 0)
                {
                    List<UserWorkspace> workspaces = workspaceDao.getWorkspaceList();
                    allFolderList = new List<Folder>();
                    panel.Controls.Clear();
                    foreach (var workspace in workspaces)
                    {

                        // loop through all the workspaces and get the folders of the workspaces

                        CustomWorkspaceButton workspaceButton = new CustomWorkspaceButton();
                        workspaceButton.Text = " " + workspace.Name;
                        workspaceButton.Image = new Bitmap(wsIcon);
                        workspaceButton.Click += workspaceButtonHandler;

                        CustomWorkspacePanel childPanel = new CustomWorkspacePanel();
                        childPanel.AutoScrollMargin = new System.Drawing.Size(0, 400);
                        childPanel.AutoSize = true;
                        childPanel.Dock = System.Windows.Forms.DockStyle.Top;
                        childPanel.Location = new System.Drawing.Point(0, 0);
                        childPanel.Name = "childPanel";
                        childPanel.Size = new System.Drawing.Size(200, 104);
                        childPanel.TabIndex = 1;
                        childPanel.Controls.Add(workspaceButton);
                        
                        panel.Controls.Add(childPanel);


                    }
                }

                // add search box to the workspace panel
                Panel searchBoxPanel = new Panel();
                searchBoxPanel.AutoSize = true;
                searchBoxPanel.Dock = System.Windows.Forms.DockStyle.Top;
                searchBoxPanel.Location = new System.Drawing.Point(0, 0);
                searchBoxPanel.Name = "searchBoxPanel";              
                searchBoxPanel.TabIndex = 1;
                searchBoxPanel.BackColor = System.Drawing.Color.LightGray;

                Image searchImage = Resource.searchImage;
                PictureBox searchpb = new PictureBox();
                searchpb.Image = searchImage;
                searchpb.Location = new System.Drawing.Point(152, 9);
                searchpb.Size = new System.Drawing.Size(40, 40);

                CustomSearchTextBox searchBox = new CustomSearchTextBox();
                searchBox.GotFocus  += searchTextBoxHandler;
                searchBox.LostFocus += searchTextBoxHandler;

                CustomMainButton folderButton = new CustomMainButton();
                folderButton.Text = "Folders";
                folderButton.Location = new System.Drawing.Point(190, 8);
                folderButton.BackColor = System.Drawing.Color.Gray;  // initially by default show it as selected.
                folderButton.ForeColor = System.Drawing.Color.WhiteSmoke;  // when it is selected show the forecolor white.

                CustomMainButton tagButton = new CustomMainButton();
                tagButton.Text = "Tags";
                tagButton.Location = new System.Drawing.Point(270, 8);

                CustomMainButton searchButton = new CustomMainButton();
                searchButton.Text = "Search";
                searchButton.Location = new System.Drawing.Point(350, 8);

                searchBoxPanel.Controls.Add(searchBox);
                searchBoxPanel.Controls.Add(searchpb);
                searchBoxPanel.Controls.Add(folderButton);
                searchBoxPanel.Controls.Add(tagButton);
                searchBoxPanel.Controls.Add(searchButton);

                panel.Controls.Add(searchBoxPanel);

                // make the backgroud color silver so that if clicks for wits
                // backgroud should should not look odd
                this.BackColor = System.Drawing.Color.WhiteSmoke;

                // clear all the controls from the widget and show only listview
                afterLogin();


                // save all the images needed to show to the widget
                ImageList myImageList = new ImageList();
                myImageList.Images.Add(Resource.grayfolder);
                myImageList.Images.Add(Resource.grayfolder);
                myImageList.ColorDepth = ColorDepth.Depth32Bit;

                // Assign the ImageList to the TreeView.
                myCustomTreeView.ImageList = myImageList;

                // Set the TreeView control's default image and selected image indexes.
                myCustomTreeView.ImageIndex = 0;
                myCustomTreeView.SelectedImageIndex = 0;

                // control factory for future use
                witChildPanels = new List<CustomWitPanel>();
                ControlFactory controlFactory = new ControlFactory();
                witChildPanels = controlFactory.getChildWitPanels();

            }
            else {

                // when there is no folders to show !!!
                MessageBox.Show("No folders to show");
            }         

        }

        void searchTextBoxHandler(object sender, EventArgs e)
        {
            CustomSearchTextBox searchTextBox = (CustomSearchTextBox)sender;
            if (searchTextBox.Text.Trim() == "")
            {
                searchTextBox.Text = "Keywords";
            }
            else if(searchTextBox.Text == "Keywords")
            {
                searchTextBox.Text = "";
            }
           

        }

        void loginTextBoxGetHandler(object sender, EventArgs e)
        {
            TextBox loginTextBox = (TextBox)sender;
            if (loginTextBox.Text == "Username" || loginTextBox.Text == "Password")
            {
                loginTextBox.Text = "";
            }
        }

        void loginTextBoxLostHandler(object sender, EventArgs e)
        {
            TextBox loginTextBox = (TextBox)sender;

            if (loginTextBox.Name == "username")
            {

                if (loginTextBox.Text.Trim() == "")
                {
                    loginTextBox.Text = "Username";
                }
            } else if (loginTextBox.Name == "password")
            {
                if (loginTextBox.Text.Trim() == "")
                {
                    loginTextBox.Text = "Password";
                }
            }

        }

        // It is used to collapse and expand the workspaces to show and hide folders
        void workspaceButtonHandler(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            CustomWorkspacePanel clickedPanel = (CustomWorkspacePanel)((Button)sender).Parent;

            // check if the panel is already expanded, then clear all child
            if (clickedPanel.Controls.Count > 1)
            {
                clickedPanel.Controls.Clear();
                clickedPanel.Controls.Add(clickedButton);
            }
            else if (clickedPanel.Controls.Count == 1)
            {

                var workspaceName = clickedButton.Text;
                UserWorkspaceDao workspaceDao = new UserWorkspaceDao(appDataPath);
                UserWorkspace workspaceSelected = workspaceDao.getByName(workspaceName.Trim());
                prepareTreeNodeHeirarchy(workspaceSelected.WorkspaceId);

                Panel childPanel = new Panel();
                childPanel.AutoSize = true;
                childPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                childPanel.Dock = System.Windows.Forms.DockStyle.Top;
                childPanel.Location = new System.Drawing.Point(0, 0);
                childPanel.Name = "childPanel";
                childPanel.Size = new System.Drawing.Size(200, 104);
                childPanel.TabIndex = 1;
                childPanel.BackColor = System.Drawing.Color.WhiteSmoke;
                childPanel.Controls.Add(myCustomTreeView);
                clickedPanel.Controls.Add(childPanel);

                clickedPanel.Controls.Add(clickedButton);
            }

        }

        private void prepareTreeNodeHeirarchy(String selectedWSid)
        {
            FolderDao folderDao = new FolderDao(appDataPath);
            List<Folder> folders = folderDao.getFolders(selectedWSid);
            //CustomTreeNode rootNode = new CustomTreeNode();

            if (folders.Count > 0) {

                myCustomTreeView.Nodes.Clear();   
                foreach (var folder in folders)
                {
                    CustomTreeNode node = createNodes(folder);
                    myCustomTreeView.Nodes.Add(node);
                }
            }          
        }

        private CustomTreeNode createNodes(Folder folder) {

            // first create the root node
            CustomTreeNode node = new CustomTreeNode();
            node.Name = folder.name;
            node.Text = folder.name;
            node.fieldType = folder.type;
            node.fieldId = folder.id;

            // check for the child folders and call this method again
            // it will be a self loop method
            FolderDao folderDao = new FolderDao(appDataPath);
            List<Folder> childFolders = folderDao.getChildFolders(node.fieldId);
            if (childFolders.Count > 0)
            {
                foreach (var childFolder in childFolders)
                {
                    CustomTreeNode childNode = createNodes(childFolder);
                    node.Nodes.Add(childNode);
                }
            }
            return node;
        }


        private void myCustomTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

       
    }

}
