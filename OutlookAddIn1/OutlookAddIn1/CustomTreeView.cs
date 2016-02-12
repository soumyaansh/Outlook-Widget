using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.VisualStyles;
using _OutlookAddIn1.witcontrols;
using _OutlookAddIn1.TextBoxControls;
using System.Text.RegularExpressions;

namespace _OutlookAddIn1
{
    public class CustomTreeView : System.Windows.Forms.TreeView
    {

        String mailIcon = "C:\\Users\\WittyParrot\\Documents\\Visual Studio 2015\\Projects\\OutlookAddIn1\\packages\\mail.ico";
        String backIcon = "C:\\Users\\WittyParrot\\Documents\\Visual Studio 2015\\Projects\\OutlookAddIn1\\packages\\back.ico";
        String logoutIcon = "C:\\Users\\WittyParrot\\Documents\\Visual Studio 2015\\Projects\\OutlookAddIn1\\packages\\logout.ico";
        String replyIcon = "C:\\Users\\WittyParrot\\Documents\\Visual Studio 2015\\Projects\\OutlookAddIn1\\packages\\reply.ico";
        MyUserControl control;
        RichTextBox richTextBox;

        public CustomTreeNode treeNode { get; set; }

        protected override void OnAfterSelect(System.Windows.Forms.TreeViewEventArgs e)
        {

            CustomTreeNode selectedNode = (CustomTreeNode)e.Node;
            CustomTreeView treeView = (CustomTreeView)e.Node.TreeView;
            control = (MyUserControl)treeView.Parent.Parent.Parent.Parent;

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
               

                if (wits.Count > 0) {

                    control.witsPanel.Controls.Clear();
                    control.pnlMenu.Visible = false;
                    control.witsPanel.Visible = true;


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
                        childWitPanel.Parent = control.witsPanel;
                        control.witsPanel.ResumeLayout();
                        //witsPanel.Controls.Add(l);

                    }


                }
                


                // Navigation panel with back button on wit panel to go back to workspace panel

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

                control.witsPanel.Controls.Add(containerWitPanel);
            }
        }

        private void backButtonHandler(object sender, EventArgs e)
        {
            control.witsPanel.Visible = false;
            control.pnlMenu.Visible = true;
        }


        private void witHandler(object sender, EventArgs e)
        {


            CustomWitButton clickedWitButton = new CustomWitButton();
            Panel clcikedPanel = (Panel)((Button)sender).Parent;
            clickedWitButton = (CustomWitButton)sender;
            var type = clickedWitButton.fieldType;

            if (clickedWitButton.Parent.Controls.Count > 1)
            {
                clcikedPanel.Controls.Clear();
                clcikedPanel.Controls.Add(clickedWitButton);

            }
            else if (clickedWitButton.Parent.Controls.Count == 1)
            {


                WitsDao witDao = new WitsDao();
                Wits wit = witDao.getWit(clickedWitButton.fieldId);

                // append wit description in the text box from the 2nd line 
                CustomRichTextBox textBox = control.myRichTextBox;
                textBox.Clear();
                textBox.AppendText(" \u2028");
                textBox.AppendText(wit.desc == null ? "" : wit.desc);
                textBox.SelectAll();
                textBox.SelectionAlignment = HorizontalAlignment.Left;


                // try to add buttons in the richtextbox top
                CustomWitIconButton textMailButton = new CustomWitIconButton(mailIcon, AnchorStyles.Left);
                textMailButton.Click += textMailButtonHandler;
                textMailButton.Location = new System.Drawing.Point(0, 0);

                CustomWitIconButton textReplyButton = new CustomWitIconButton(replyIcon, AnchorStyles.Left);
                textReplyButton.Click += textReplyButtonHandler;
                textReplyButton.Location = new System.Drawing.Point(30, 0);

                Label bround = new Label();
                bround.Size = new System.Drawing.Size(500, 20);
                bround.BackColor = System.Drawing.Color.Silver;

                textBox.Controls.Add(textReplyButton);
                textBox.Controls.Add(textMailButton);
                textBox.Controls.Add(bround);
               


                // create richTextboxPanel
                Panel childTextBoxPanel = new Panel();
                childTextBoxPanel.AutoSize = true;
                childTextBoxPanel.Dock = System.Windows.Forms.DockStyle.Top;
                childTextBoxPanel.Location = new System.Drawing.Point(0, 0);
                childTextBoxPanel.Name = "childTextBoxPanel";
                childTextBoxPanel.Size = new System.Drawing.Size(200, 104);
                childTextBoxPanel.TabIndex = 1;

                childTextBoxPanel.Controls.Add(textBox);           
                clcikedPanel.Controls.Add(childTextBoxPanel);

                // below is the acronym code block

                MatchCollection matches = StringUtils.searchAcronyms(wit.desc == null ? "" : wit.desc);
                var height = 20;
                foreach (Match m in matches)
                {
                    textBox.AppendText(" \u2028");
                    height += 20;
                    CustomAcronymPanel acronymPanel = new CustomAcronymPanel();
                    acronymPanel.Location = new System.Drawing.Point(30, height);

                    Label acroLabel = new Label();                    
                    acroLabel.Text = m.Groups[1].ToString();
                    acroLabel.Name = m.Groups[1].ToString();
                    acroLabel.AutoSize = true;
                    acroLabel.Size = new System.Drawing.Size(78, 20);
                    
                    acroLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                    TextBox acroText = new TextBox();
                    acroText.Size = new System.Drawing.Size(161, 26);
                    acroText.Name = m.Groups[1].ToString();
                    acroText.KeyUp += acronymHandler;

                    acronymPanel.Controls.Add(acroLabel);
                    acronymPanel.Controls.Add(acroText);
                    clcikedPanel.Controls.Add(acronymPanel);


                }
     
                clcikedPanel.Controls.Add(clickedWitButton);

            }

        }

        void acronymHandler(object sender, KeyEventArgs e) {

           
            TextBox acronymText = new TextBox();
            acronymText = (TextBox)sender;
            //MessageBox.Show(acronymText.Name + " : "+ acronymText.Text);
           // MessageBox.Show(control.myRichTextBox.Text);
            var acronymTextValue = "[" + acronymText.Name + "]";
            //control.myRichTextBox.Text = "hello";
            //MessageBox.Show(acronymTextValue + " : " + acronymText.Text);
            control.myRichTextBox.Text.Replace(acronymTextValue.ToString(),acronymText.Text.ToString());
            //richTextBox.Text = yourRichTextBox.Text.Replace("e", acronymText.Text);
           
        }

        void textMailButtonHandler(object sender, EventArgs e)
        {
            Button clickedMailButton = new Button();
            clickedMailButton = (Button)sender;
            RichTextBox richTextBox = (RichTextBox)((Button)sender).Parent;

            TextToEmailBody mail = new TextToEmailBody();
            mail.SendEmailUsingOutLook(richTextBox.Text);

        }

        void textReplyButtonHandler(object sender, EventArgs e)
        {
            Button clickedReplyButton = new Button();
            clickedReplyButton = (Button)sender;
            RichTextBox richTextBox = (RichTextBox)((Button)sender).Parent;

            TextToEmailBody mail = new TextToEmailBody();
            mail.replyEmailUsingOutLook(richTextBox.Text);

        }




    }

    
}
