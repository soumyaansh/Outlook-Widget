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

namespace _OutlookAddIn1
{
    public partial class MyUserControl : UserControl
    {

        UserDBConnector userDBConnector;
        MainDBConnector mainDBConnector;
        BackgroundWorker bw = new BackgroundWorker();
        public TreeNode previousSelectedNode = null;
        String wsIcon = "C:\\Users\\WittyParrot\\Documents\\Visual Studio 2015\\Projects\\OutlookAddIn1\\packages\\list2.ico";
        String folderIcon = "C:\\Users\\WittyParrot\\Documents\\Visual Studio 2015\\Projects\\OutlookAddIn1\\packages\\blackfolder.ico";
        String mailIcon = "C:\\Users\\WittyParrot\\Documents\\Visual Studio 2015\\Projects\\OutlookAddIn1\\packages\\mail.ico";
        String backIcon = "C:\\Users\\WittyParrot\\Documents\\Visual Studio 2015\\Projects\\OutlookAddIn1\\packages\\back.ico";
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

            // hide the treeview brfore successfull login
            myCustomTreeView.Visible = false;
            myCustomListView.Visible = false;

            // Create two StatusBarPanel objects to display in the StatusBar.
            StatusBarPanel networkStatusPanel = new StatusBarPanel();
            StatusBarPanel dateTimePanel = new StatusBarPanel();
            StatusBarPanel networkStatusPanelIcon = new StatusBarPanel();

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
            }
            else {
                networkStatusPanel.Text = "disconnected";
                networkStatusPanelIcon.Icon = Resource.disconnectedicon;
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

        private void SetListViewItemHeight(ListView listView, int height)
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, height);
            listView.SmallImageList = imgList;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {


            //CustomListView customListView = myCustomListView;
            //RichTextBox textBox = myRichTextBox;
            // SetListViewItemHeight(customListView, 20);

            //customTreeView.Visible = false;
            // customListView.Visible = false;
            //textBox.Visible = false;


            Panel witsPanel = this.witsPanel;
            witsPanel.Visible = false;

            Panel panel = this.pnlMenu;
            panel.Visible = true;


            label3.Visible = false;
            pictureBox2.Visible = false;

            // get the username and pasword from the widget
            var userName = textBox1.Text;
            var password = textBox2.Text;

            // class the rest api for login
            // RestClientLogin clientLogin = new RestClientLogin();
            // RootObject rootObj = clientLogin.login(userName, password);

            userDBConnector = new UserDBConnector();
            mainDBConnector = new MainDBConnector();

            //mainDBConnector.prepareMainDBSchema(rootObj);
            //userDBConnector.prepareUserDBSchema(rootObj);

            AccessTokenDao accessTokenDao = new AccessTokenDao();
            //rootObj.accessToken.id = Utilities.GUIDGenerator.getGUID();
           // accessTokenDao.saveAccessToken(rootObj.accessToken);

            UserWorkspaceDao workspaceDao = new UserWorkspaceDao();
            //workspaceDao.saveWorkspaces(rootObj.userProfile.userWorkspaces);


            // fetch all the folders of the workspace and save it to folder list
            List<Folder> allFolderList = null;
            if (workspaceDao.getWorkspaceNameList() != null && workspaceDao.getWorkspaceNameList().Count != 0)
            {
                List<UserWorkspace> workspaces = workspaceDao.getWorkspaceList();
                //workspaces.Sort();
                //workspaces.Reverse();
                allFolderList = new List<Folder>();

                panel.Controls.Clear();
                foreach (var workspace in workspaces)
                {

                    // loop through all the workspaces and get the folders of the workspcasec
                    RestClientFolder restClientFolder = new RestClientFolder();
                   // restClientFolder.getAllFolders(rootObj.accessToken.tokenValue, workspace.WorkspaceId, 0, allFolderList);

                    CustomButton button8 = new CustomButton();
                    button8.Text = " " + workspace.Name;
                    button8.BackColor = System.Drawing.Color.Gray;
                    button8.Dock = System.Windows.Forms.DockStyle.Top;
                    button8.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
                    button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    button8.Location = new System.Drawing.Point(0, 75);
                    button8.Name = "button8";
                    button8.Size = new System.Drawing.Size(200, 60);
                    button8.Image = new Bitmap(wsIcon);
                    button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    button8.TabIndex = 1;

                    button8.ForeColor = System.Drawing.Color.Silver;
                    button8.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular);
                    button8.TextImageRelation = TextImageRelation.ImageBeforeText;
                    button8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    button8.UseVisualStyleBackColor = false;
                    button8.Click += workspaceButtonHandler;

                    Panel childPanel = new Panel();
                    childPanel.AutoScrollMargin = new System.Drawing.Size(0, 400);
                    childPanel.AutoSize = true;
                    childPanel.Dock = System.Windows.Forms.DockStyle.Top;
                    childPanel.Location = new System.Drawing.Point(0, 0);
                    childPanel.Name = "childPanel";
                    childPanel.Size = new System.Drawing.Size(200, 104);
                    childPanel.TabIndex = 1;


                    childPanel.Controls.Add(button8);
                    //childPanel.Controls.Add(childPanel);

                    panel.Controls.Add(childPanel);

                }
            }

            // make the backgroud color silver so that if clicks for wits
            // backgroud should not look odd
            this.BackColor = System.Drawing.Color.Silver;


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
            myImageList.Images.Add(Resource.blackfolder);
            myImageList.Images.Add(Resource.greyopenfolder);
            //myImageList.ImageSize = new Size(25, 25);
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

        // It is used to collapse and expand the workspaces to show and hide folders
        void workspaceButtonHandler(object sender, EventArgs e)
        {
            Button clcikedButton = (Button)sender;
            Panel clcikedPanel = (Panel)((Button)sender).Parent;


            // check if the panel is already expanded, then clear all child
            if (clcikedPanel.Controls.Count > 1)
            {
                clcikedPanel.Controls.Clear();
                clcikedPanel.Controls.Add(clcikedButton);
            }
            else if (clcikedPanel.Controls.Count == 1)
            {

                var workspaceName = clcikedButton.Text;
                UserWorkspaceDao workspaceDao = new UserWorkspaceDao();
                UserWorkspace workspaceSelected = workspaceDao.getByName(workspaceName.Trim());

                FolderDao folderDao = new FolderDao();
                List<Folder> folders = folderDao.getFolders(workspaceSelected.WorkspaceId);
                myCustomTreeView.Nodes.Clear();

                foreach (var folder in folders)
                {

                    CustomTreeNode node = new CustomTreeNode();
                    node.Text = folder.name;
                    node.fieldType = folder.type;
                    node.fieldId = folder.id;

                    Panel childPanel = new Panel();
                    childPanel.AutoSize = true;
                    childPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                    childPanel.Dock = System.Windows.Forms.DockStyle.Top;
                    childPanel.Location = new System.Drawing.Point(0, 0);
                    childPanel.Name = "childPanel";
                    childPanel.Size = new System.Drawing.Size(200, 104);
                    childPanel.TabIndex = 1;
                    childPanel.BackColor = System.Drawing.Color.Silver;


                    myCustomTreeView.Nodes.Add(node);
                   // myCustomTreeView.AfterSelect += new TreeViewEventHandler(myTreeView_AfterSelect);

                    childPanel.Controls.Add(myCustomTreeView);
                    clcikedPanel.Controls.Add(childPanel);
                }

                clcikedPanel.Controls.Add(clcikedButton);
            }

        }

        //
        private void myTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

            CustomTreeNode selectedNode = (CustomTreeNode)e.Node;
            CustomTreeView treeView = (CustomTreeView)e.Node.TreeView;

            // get the folders
            FolderDao folderDao = new FolderDao();
            List<Folder> childFolders = folderDao.getChildFolders(selectedNode.fieldId);

            if (childFolders.Count > 0)
            {
                selectedNode.Nodes.Clear();
                foreach (var folder in childFolders)
                {
                    CustomTreeNode childNode = new CustomTreeNode();
                    childNode.fieldId = folder.id;
                    childNode.fieldType = folder.type;
                    childNode.Text = folder.name;
                    selectedNode.Nodes.Add(childNode);

                }
            }
            //else(wits.Count > 0)
            else if ((childFolders == null || childFolders.Count == 0))
            {
                selectedNode.Nodes.Clear();
                // get the wits 
                WitsDao witsDao = new WitsDao();
                List<Wits> wits = witsDao.getWits(selectedNode.fieldId);
                witsPanel.Controls.Clear();

                pnlMenu.Visible = false;
                witsPanel.Visible = true;

               
                foreach (var wit in wits)
                {             
                    CustomWitButton witButton = new CustomWitButton();
                    witButton.Text = wit.name;
                    witButton.fieldType = wit.type;
                    witButton.fieldId = wit.id;
                    witButton.Click += witHandler;

                    CustomWitPanel childWitPanel = new CustomWitPanel();
                    childWitPanel.Controls.Add(witButton);
                    
                    // add to the clicked panel
                    childWitPanel.Parent = witsPanel;
                    witsPanel.ResumeLayout();
                    //witsPanel.Controls.Add(l);

                }


                //--------------menu panel for back and forth---------------------
                Panel containerWitPanel = new FlowLayoutPanel();
                containerWitPanel.AutoSize = true;
                containerWitPanel.Dock = System.Windows.Forms.DockStyle.Top;
                containerWitPanel.BackColor = System.Drawing.Color.Gray;

                containerWitPanel.Name = "containerWitPanel";
                containerWitPanel.Size = new System.Drawing.Size(200, 30);
                containerWitPanel.TabIndex = 1;
                containerWitPanel.Height = 10;

                CustomWitIconButton backButton = new CustomWitIconButton(backIcon, AnchorStyles.Left);
                backButton.Click += backButtonHandler;
                containerWitPanel.Controls.Add(backButton);

                //CustomWitIconButton logoutButton = new CustomWitIconButton(logoutIcon, AnchorStyles.Left);
                //containerWitPanel.Controls.Add(logoutButton);

                witsPanel.Controls.Add(containerWitPanel);
            }

        }

        protected void witClick(object sender, EventArgs e)
        {
            //var controls  = witsPanel.Controls;
            Label witLabel = sender as Label;
            Panel textBoxContainerPanel = new Panel();
            textBoxContainerPanel.Controls.Add(witLabel);
            textBoxContainerPanel.Location = witLabel.Location;
            RichTextBox tb = new RichTextBox();
            
            tb.AppendText("hello");
            textBoxContainerPanel.Controls.Add(tb);
            witsPanel.Controls.Add(textBoxContainerPanel);

        } 


        private void backButtonHandler(object sender, EventArgs e)
        {
            witsPanel.Visible = false;
            pnlMenu.Visible = true;
        }

        private void witHandler(object sender, EventArgs e) {


            CustomWitButton clickedWitButton = new CustomWitButton();
            Panel clcikedPanel = (Panel)((Button)sender).Parent;
            clickedWitButton = (CustomWitButton)sender;
            var type = clickedWitButton.fieldType;

            if (clickedWitButton.Parent.Controls.Count > 1)
            {
                clcikedPanel.Controls.Clear();
                clcikedPanel.Controls.Add(clickedWitButton);

            }else if(clickedWitButton.Parent.Controls.Count == 1) { 
  
           
                WitsDao witDao = new WitsDao();
                Wits wit = witDao.getWit(clickedWitButton.fieldId);

                // append wit description in the text box 
                CustomRichTextBox textBox = new CustomRichTextBox();
                textBox.AppendText(" \u2028");
                textBox.AppendText(wit.desc == null ? "" : wit.desc);
                textBox.SelectAll();
                textBox.SelectionAlignment = HorizontalAlignment.Left;
               

                // try to add button in the richtextbox
                CustomWitIconButton textMailButton = new CustomWitIconButton(mailIcon,AnchorStyles.Left);   
                textMailButton.Click += textMailButtonHandler;
                Label bround = new Label();
                bround.Size = new System.Drawing.Size(500, 20);
                bround.BackColor = System.Drawing.Color.Silver;
                textBox.Controls.Add(textMailButton);
                textBox.Controls.Add(bround);
                //textBox.Controls.Add(textMailButton);

                // create richTextboxPanel
                Panel childTextBoxPanel = new Panel();
                childTextBoxPanel.AutoSize = true;
                childTextBoxPanel.Dock = System.Windows.Forms.DockStyle.Top;
                childTextBoxPanel.Location = new System.Drawing.Point(0, 0);
                childTextBoxPanel.Name = "childTextBoxPanel";
                //childTextBoxPanel.BackColor = System.Drawing.Color.Silver;
                childTextBoxPanel.Size = new System.Drawing.Size(200, 104);
                childTextBoxPanel.TabIndex = 1;
                childTextBoxPanel.Controls.Add(textBox);

                // create ButtonPanel
                CustomMailButtonPanel mailButtonsPanel = new CustomMailButtonPanel();

                //mailButtonsPanel.Controls.Add(textMailButton);
                

                clcikedPanel.Controls.Add(childTextBoxPanel);
               // clcikedPanel.Controls.Add(textMailButton);
                clcikedPanel.Controls.Add(clickedWitButton);
                
            }

        }

        void textMailButtonHandler(object sender, EventArgs e)
        {
            Button clickedMailButton = new Button();
            clickedMailButton = (Button)sender;
            RichTextBox richTextBox = (RichTextBox)((Button)sender).Parent;
            //CustomMailButtonPanel cus =  (CustomMailButtonPanel)clickedMailButton.Parent;
            //CustomWitPanel cusWitPanel = (CustomWitPanel)cus.Parent;

           // foreach (var control in cusWitPanel.Controls) {

                //if (control is Panel) {

                   // Panel rcihPanel = (Panel)control.;
                    
                   // MessageBox.Show(rcihPanel);
                
            
            TextToEmailBody mail = new TextToEmailBody();
            mail.SendEmailUsingOutLook(richTextBox.Text);


             //Panel containerPanel = (Panel)clcikedPanel.Parent;
        }

        void workspacePanelHandler(object sender, EventArgs e)
        {           
            string parent_name = ((Panel)sender).Parent.Name;
        }

        private void myCustomTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnMenuGroup3_Click(object sender, EventArgs e)
        {
         
        }
        private void btnMenuGroup2_Click(object sender, EventArgs e)
        {

           
        }
    }

}
