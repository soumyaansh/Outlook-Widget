using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace _OutlookAddIn1
{
    class CustomizedTreeView : System.Windows.Forms.TreeView
    {

        public CustomTreeNode treeNode { get; set; }
        Icon folderIcon = new Icon("C:\\Users\\WittyParrot\\Documents\\Visual Studio 2015\\Projects\\OutlookAddIn1\\packages\\folder.ico");
        Icon wsIcon = new Icon("C:\\Users\\WittyParrot\\Documents\\Visual Studio 2015\\Projects\\OutlookAddIn1\\packages\\ws.ico");

        public CustomizedTreeView()
        {
            // Customize the TreeView control by setting various properties.
            BackColor = System.Drawing.Color.White;
            FullRowSelect = true;
            HotTracking = true;
            Indent = 10;
            ShowPlusMinus = false;
            Font = new System.Drawing.Font("Arial", 15, System.Drawing.FontStyle.Bold);
            ForeColor = System.Drawing.Color.Gray;
            //DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            HideSelection = false;

            // The ShowLines property must be false for the FullRowSelect 
            // property to work.
            ShowLines = true;
        }

        protected override void OnAfterSelect(System.Windows.Forms.TreeViewEventArgs e)
        {

            // level is the heirarchy level for workspace it will be 0 for folder 1 for wits 2
            // index is the element number, if 3 workspcase is there then firsst will be 0 second will be 2
            // Text will be the Name of the perticular node, in this case workspace is neww1, neww2, neww3
            ImageList myImageList = new ImageList();
            myImageList.Images.Add(folderIcon);
            myImageList.Images.Add(wsIcon);

            //MessageBox.Show(" you clicked: "+ e.Node.Checked + " index: "+e.Node.Index + " level: "+e.Node.Level + " Name: "+ e.Node.Name + " text: "+e.Node.Text);
            CustomTreeNode selectedNode = (CustomTreeNode)e.Node;

            // Assign the ImageList to the TreeNode.
          
            selectedNode.ImageIndex = 1;
            selectedNode.SelectedImageIndex = 0;

            if (selectedNode.Level == 0) {  // this is the workspace level

                selectedNode.Nodes.Clear();
                UserWorkspaceDao workspaceDao = new UserWorkspaceDao();
                UserWorkspace workspaceSelected = workspaceDao.getByName(selectedNode.Text);
                FolderDao folderDao = new FolderDao();
                List<Folder> folders = folderDao.getFolders(workspaceSelected.WorkspaceId);

                foreach (var folder in folders)
                {
                    CustomTreeNode childNode = new CustomTreeNode();
                    childNode.fieldId = folder.id;
                    childNode.fieldType = folder.type;
                    childNode.Text = folder.name;
                    selectedNode.Nodes.Add(childNode);

                }

            }

            if ((selectedNode.Level == 1 || selectedNode.Level > 1) && selectedNode.fieldType=="FOLDER")    
            {
                selectedNode.Nodes.Clear();
                FolderDao folderDao = new FolderDao();
                List<Folder> childFolders = folderDao.getChildFolders(selectedNode.fieldId);

                if (childFolders.Count > 0)
                {
                    foreach (var folder in childFolders)
                    {
                        CustomTreeNode childNode = new CustomTreeNode();
                        childNode.fieldId = folder.id;
                        childNode.fieldType = folder.type;
                        childNode.Text = folder.name;
                        selectedNode.Nodes.Add(childNode);

                    }
                } else if (childFolders == null || childFolders.Count == 0) {

                    WitsDao witsDao = new WitsDao();
                    List<Wits> wits = witsDao.getAllWits(selectedNode.fieldId);

                    foreach (var wit in wits)
                    {
                        CustomTreeNode childNode = new CustomTreeNode();
                        childNode.fieldId = wit.id;
                        childNode.fieldType = wit.type;
                        childNode.Text = wit.name;
                        selectedNode.Nodes.Add(childNode);

                    }

                }
               
            }

            if (selectedNode.Level > 1 && selectedNode.fieldType == "FOLDER") // this is the wits level
            {

                // first check if the folder has child folder
                // if not then check for wits in the folder

                selectedNode.Nodes.Clear();
                FolderDao folderDao = new FolderDao();
                List<Folder> childFolders = folderDao.getChildFolders(selectedNode.fieldId);

                if (childFolders.Count == 0) {

                    WitsDao witsDao = new WitsDao();
                    List<Wits> wits = witsDao.getAllWits(selectedNode.fieldId);

                    foreach (var wit in wits)
                    {
                        CustomTreeNode childNode = new CustomTreeNode();
                        childNode.fieldId = wit.id;
                        childNode.fieldType = wit.type;
                        childNode.Text = wit.name;
                        selectedNode.Nodes.Add(childNode);

                    }

                }
            }

            // Confirm that the user initiated the selection.
            // This prevents the first node from expanding when it is
            // automatically selected during the initialization of 
            // the TreeView control.


           

            // Remove the selection. This allows the same node to be
            // clicked twice in succession to toggle the expansion state.
            SelectedNode = null;
        }

    }
}
