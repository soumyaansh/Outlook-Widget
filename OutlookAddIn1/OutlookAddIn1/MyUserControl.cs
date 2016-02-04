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

namespace _OutlookAddIn1
{
   

    public partial class MyUserControl : UserControl
    {

        UserDBConnector userDBConnector;
        MainDBConnector mainDBConnector;
        AccessTokenDao accessTokenDao;

        BackgroundWorker bw = new BackgroundWorker();
        Icon folderIcon = new Icon("C:\\Users\\WittyParrot\\Documents\\Visual Studio 2015\\Projects\\OutlookAddIn1\\packages\\greyfolder.ico");
        Icon wsIcon = new Icon("C:\\Users\\WittyParrot\\Documents\\Visual Studio 2015\\Projects\\OutlookAddIn1\\packages\\greyopenfolder.ico");

        public TreeNode previousSelectedNode = null;

        public MyUserControl()
        {
            InitializeComponent();
        }

        private void MyUserControl_Load(object sender, EventArgs e)
        {
            CreateMyStatusBar();
            bw.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgCheck_RunWorkerCompleted);
            bw.RunWorkerAsync();
        }

       

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // If you need to make a pause between runs
            System.Threading.Thread.Sleep(1000);   
            
            //Do your stuff here
            bool isConnected = CheckNetConnection.CheckForInternetConnection();
            if (isConnected)
            {
               // MessageBox.Show("connected");
                // this.label4.Visible = true;
            }
            else {
                // this.label4.Visible = false;
              // MessageBox.Show("disconnected");
            }
        }

        private void bgCheck_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Run again
            // This will make the BgWorker run again, and never runs before it is completed.
            bw.RunWorkerAsync();
        }

        private void CreateMyStatusBar()
        {
            // Create a StatusBar control.
            StatusBar statusBar1 = new StatusBar();          

            // hide the treeview brfore successfull login
            myCustomTreeView.Visible = false;

            // Create two StatusBarPanel objects to display in the StatusBar.
            StatusBarPanel networkStatusPanel = new StatusBarPanel();
            StatusBarPanel dateTimePanel = new StatusBarPanel();
            StatusBarPanel networkStatusPanelIcon = new StatusBarPanel();

            Icon connectedIcon = new Icon("C:\\Users\\Admin\\Documents\\Visual Studio 2015\\Projects\\18OutlookAddIn4\\packages\\connectedicon.ico");
            Icon disconnectedIcon = new Icon("C:\\Users\\Admin\\Documents\\Visual Studio 2015\\Projects\\18OutlookAddIn4\\packages\\disconnectedicon.ico");          


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
                networkStatusPanelIcon.Icon = connectedIcon;
            }
            else {
                networkStatusPanel.Text = "disconnected";
                networkStatusPanelIcon.Icon = disconnectedIcon;
            }

            // Display panels in the StatusBar control.
            statusBar1.ShowPanels = true;

            // Add both panels to the StatusBarPanelCollection of the StatusBar.			
            statusBar1.Panels.Add(networkStatusPanel);
            statusBar1.Panels.Add(networkStatusPanelIcon);
            statusBar1.Panels.Add(dateTimePanel);

            // Add the StatusBar to the form.
            this.Controls.Add(statusBar1);

        }

        private void afterLogin()
        {
            this.Controls.Remove(textBox1);
            this.Controls.Remove(textBox2);
            this.Controls.Remove(button1);
            this.Controls.Remove(label1);
            this.Controls.Remove(label2);
            this.Controls.Remove(label3);
            this.Controls.Remove(pictureBox1);
            this.Controls.Remove(pictureBox2);
            this.Controls.Remove(checkBox1);
            myCustomTreeView.Visible = true;
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

        private void button1_Click_1(object sender, EventArgs e)
        {
          
            CustomizedTreeView customTreeView = myCustomTreeView;
            label3.Visible = true;
            pictureBox2.Visible = true;

            // get the username and pasword from the widget
            var userName = textBox1.Text;
            var password = textBox2.Text;

            // class the rest api for login
            RestClientLogin clientLogin = new RestClientLogin();
            RootObject rootObj = clientLogin.login(userName, password);

            userDBConnector = new UserDBConnector();
            mainDBConnector = new MainDBConnector();

            mainDBConnector.prepareMainDBSchema(rootObj);
            userDBConnector.prepareUserDBSchema(rootObj);

            accessTokenDao = new AccessTokenDao();
            rootObj.accessToken.id = Utilities.GUIDGenerator.getGUID();
            accessTokenDao.saveAccessToken(rootObj.accessToken);

            UserWorkspaceDao workspaceDao = new UserWorkspaceDao();
            workspaceDao.saveWorkspaces(rootObj.userProfile.userWorkspaces);


            // fetch all the folders of the workspace and save it to folder list
            List<Folder> allFolderList = null;
            if (workspaceDao.getWorkspaceList() != null && workspaceDao.getWorkspaceList().Count != 0) {
                List<UserWorkspace> workspaces = workspaceDao.getWorkspaceList();
                allFolderList = new List<Folder>();

                foreach (var workspace in workspaces) {

                    // loop through all the workspaces and get the folders of the workspcasec
                    RestClientFolder restClientFolder = new RestClientFolder();
                    restClientFolder.getAllFolders(rootObj.accessToken.tokenValue, workspace.WorkspaceId, 1,allFolderList);
                    CustomTreeNode workspaceNode = new CustomTreeNode();
                    workspaceNode.Text = workspace.Name;
                    customTreeView.Nodes.Add(workspaceNode);
                }
            }

            // save all the folders in the database
            FolderDao folderDao = new FolderDao();
            folderDao.saveAllFolders(allFolderList);

            
             // save user profile from login response json
             //userProfileService.saveUserProfile(rootObj);
             //userProfileService.saveUser(rootObj);


            // clear all the controls from the widget and show only listview
            afterLogin();

            
            // save all the images needed to show to the widget
            ImageList myImageList = new ImageList();
            myImageList.Images.Add(folderIcon);
            myImageList.Images.Add(wsIcon);
            myImageList.ImageSize = new Size(25, 25);
            myImageList.ColorDepth = ColorDepth.Depth32Bit;

            // Assign the ImageList to the TreeView.
            myCustomTreeView.ImageList = myImageList;

            // Set the TreeView control's default image and selected image indexes.
            myCustomTreeView.ImageIndex = 0;
            myCustomTreeView.SelectedImageIndex = 0;

        }
    }

}
