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
using _OutlookAddIn1.Model;
using _OutlookAddIn1.Utilities;

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

            // get the wits 
            WitsDao witsDao = new WitsDao(control.appDataPath);
            List<Wits> wits = witsDao.getWits(selectedNode.fieldId);

            if (wits.Count > 0)
            {

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


                // Navigation panel with back button on wit panel to go back to workspace panel

                Panel containerWitPanel = new FlowLayoutPanel();
                containerWitPanel.AutoSize = true;
                containerWitPanel.Dock = System.Windows.Forms.DockStyle.Top;
                containerWitPanel.BackColor = System.Drawing.Color.WhiteSmoke;

                containerWitPanel.Name = "containerWitPanel";
                containerWitPanel.Size = new System.Drawing.Size(200, 30);
                containerWitPanel.TabIndex = 1;
                containerWitPanel.Height = 10;

                CustomWitIconButton backButton = new CustomWitIconButton(backIcon, AnchorStyles.Left, System.Drawing.Color.Gray);
                backButton.Click += backButtonHandler;
                containerWitPanel.Controls.Add(backButton);

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
            control = (MyUserControl)clickedWitButton.Parent.Parent.Parent;
            var type = clickedWitButton.fieldType;

            if (clickedWitButton.Parent.Controls.Count > 1)
            {
                clcikedPanel.Controls.Clear();
                clcikedPanel.Controls.Add(clickedWitButton);
            }
            else if (clickedWitButton.Parent.Controls.Count == 1)
            {
                WitsDao witDao = new WitsDao(control.appDataPath);
                Wits wit = witDao.getWit(clickedWitButton.fieldId);

                // try to add buttons in the richtextbox top
                CustomWitIconButton textMailButton = new CustomWitIconButton(mailIcon, AnchorStyles.Left, System.Drawing.Color.Silver);
                textMailButton.Click += textMailButtonHandler;
                textMailButton.Location = new System.Drawing.Point(0, 0);

                CustomWitIconButton textReplyButton = new CustomWitIconButton(replyIcon, AnchorStyles.Left, System.Drawing.Color.Silver);
                textReplyButton.Click += textReplyButtonHandler;
                textReplyButton.Location = new System.Drawing.Point(30, 0);

                Label mailLabel = new Label();
                mailLabel.Size = new System.Drawing.Size(500, 20);
                mailLabel.BackColor = System.Drawing.Color.Silver;

                WebBrowser wb = new WebBrowser();                
                wb.DocumentText = " <br></br> " + wit.content == null ? "" : wit.content;
                wb.Name = wit.id;
                wb.Size = new System.Drawing.Size(500, 400);
                wb.Controls.Add(textReplyButton);
                wb.Controls.Add(textMailButton);
                wb.Controls.Add(mailLabel);

                // create richTextboxPanel
                Panel WebBrowserPanel = new Panel();
                WebBrowserPanel.AutoSize = true;
                WebBrowserPanel.Dock = System.Windows.Forms.DockStyle.Top;
                WebBrowserPanel.Location = new System.Drawing.Point(0, 0);
                WebBrowserPanel.Name = "webBrowser";
                WebBrowserPanel.Size = new System.Drawing.Size(200, 104);
                WebBrowserPanel.TabIndex = 1;

                WebBrowserPanel.Controls.Add(wb);
                clcikedPanel.Controls.Add(WebBrowserPanel);

                // below is the acronym code block
                MatchCollection matches = StringUtils.searchAcronyms(wit.content == null ? "" : wit.content);
                var height = 20;
                foreach (Match m in matches)
                {
                    
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
                    acroText.Leave += acronymHandler;

                    acronymPanel.Controls.Add(acroLabel);
                    acronymPanel.Controls.Add(acroText);
                    clcikedPanel.Controls.Add(acronymPanel);
                }
                clcikedPanel.Controls.Add(clickedWitButton);
            }
        }

        void acronymHandler(object sender, EventArgs e) {

            TextBox acronymText = new TextBox();
            acronymText = (TextBox)sender;         
            var acronymTextValue = "[" + acronymText.Name + "]";
            // AcronymPanel -> customWitPanel -> 
            Panel Panel = (Panel)((TextBox)sender).Parent.Parent;
            foreach (var control in Panel.Controls) {
                if (control is Panel) {
                    Panel webBrowserPanel = (Panel)control;
                    if (webBrowserPanel.Name == "webBrowser")
                    {
                        foreach (var webBrowserControl in webBrowserPanel.Controls)
                        {
                            if (webBrowserControl is WebBrowser)
                            {
                                WebBrowser wb = (WebBrowser)webBrowserControl;
                                wb.Document.Body.InnerHtml = wb.Document.Body.InnerHtml.Replace(acronymTextValue, acronymText.Text);
                                
                            }
                        }
                    }
                }
            }                
        }

        void textMailButtonHandler(object sender, EventArgs e)
        {
            Button clickedMailButton = new Button();
            clickedMailButton = (Button)sender;
            WebBrowser webBrowser = (WebBrowser)((Button)sender).Parent;

            String path = Common.path;
            String witId = webBrowser.Name.ToString();

            WitsDao witDao = new WitsDao(path);
            Wits wit = witDao.getWit(witId);
            List<Docs> docs = witDao.getDocsOfWit(wit.id);

            TextToEmailBody mail = new TextToEmailBody();
            mail.SendEmailUsingOutLook(webBrowser.DocumentText,wit.name, docs);

        }

        void textReplyButtonHandler(object sender, EventArgs e)
        {
            Button clickedReplyButton = new Button();
            clickedReplyButton = (Button)sender;
            WebBrowser webBrowser = (WebBrowser)((Button)sender).Parent;

            String path = Common.path;
            String witId = webBrowser.Name.ToString();
            WitsDao witDao = new WitsDao(path);
            Wits wit = witDao.getWit(witId);
            List<Docs> docs = witDao.getDocsOfWit(wit.id);

            TextToEmailBody mail = new TextToEmailBody();
            mail.replyEmailUsingOutLook(webBrowser.DocumentText, wit.name, docs);

        }
    }

}
