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
using _OutlookAddIn1.controls;
using HtmlAgilityPack;
using System.IO;
using _OutlookAddIn1.Mail;

namespace _OutlookAddIn1
{
    public class CustomTreeView : System.Windows.Forms.TreeView
    {

        MyUserControl control;
        public CustomTreeNode treeNode { get; set; }

        protected override void OnAfterSelect(System.Windows.Forms.TreeViewEventArgs e)
        {

            CustomTreeNode selectedNode = (CustomTreeNode)e.Node;
            CustomTreeView treeView = (CustomTreeView)e.Node.TreeView;
            control = (MyUserControl)treeView.Parent.Parent.Parent.Parent;
            

           // get the wits 
           WitsDao witsDao = new WitsDao();
           List<Wits> wits = witsDao.getWits(selectedNode.fieldId);

            if (wits.Count > 0)
            {

                control.witsPanel.Controls.Clear();
                control.pnlMenu.Visible = false;
                control.witsPanel.Visible = true;
                control.witsPanelContainer.Visible = true;

                foreach (var wit in wits)
                {
                    CustomWitButton witButton = new CustomWitButton();
                    witButton.Text = "  "+wit.name;
                    witButton.fieldType = wit.type;
                    witButton.fieldId = wit.id;
                    witButton.Click += witHandler;

                    CustomWitPanel childWitPanel = new CustomWitPanel();
                    childWitPanel.Name = "childWitPanel";
                    childWitPanel.Controls.Add(witButton);
                  
                    // add to the clicked panel
                    childWitPanel.Parent = control.witsPanel;
                    control.witsPanel.ResumeLayout();
                  

                }
             
                control.witsPanelContainer.Controls.Add(control.witsPanel);
                //control.witsPanelContainer.Controls.Add(control.mainTabPanel);
            }
        }

      
      

        private void witHandler(object sender, EventArgs e)
        {
            CustomWitButton clickedWitButton = new CustomWitButton();
            Panel clcikedPanel = (Panel)((Button)sender).Parent;
            clickedWitButton = (CustomWitButton)sender;
            clickedWitButton.BackColor = System.Drawing.Color.FromArgb(26, 26, 26); // change the color to selected color

            control = (MyUserControl)clickedWitButton.Parent.Parent.Parent.Parent;
            var type = clickedWitButton.fieldType;

            if (clickedWitButton.Parent.Controls.Count > 1)
            {
                clcikedPanel.Controls.Clear();
                clcikedPanel.Controls.Add(clickedWitButton);
                clickedWitButton.BackColor = System.Drawing.Color.FromArgb(070, 070, 070);   // back to previous color
            }
            else if (clickedWitButton.Parent.Controls.Count == 1)
            {
                WitsDao witDao = new WitsDao();
                Wits wit = witDao.getWit(clickedWitButton.fieldId);

               

                // try to add buttons in the richtextbox top
                CustomWitIconButton textMailButton = new CustomWitIconButton(Resource.mail_24px1, AnchorStyles.Left, System.Drawing.Color.FromArgb(64, 64, 64),"new mail");       
                textMailButton.Click += textMailButtonHandler;
                textMailButton.Location = new System.Drawing.Point(280, 0);

                CustomWitIconButton forwardMailButton = new CustomWitIconButton(Resource.mail_24px1, AnchorStyles.Left, System.Drawing.Color.FromArgb(64, 64, 64), "forward");
                forwardMailButton.Click += forwardMailButtonHandler;
                forwardMailButton.Location = new System.Drawing.Point(310, 0);

                CustomWitIconButton textReplyButton = new CustomWitIconButton(Resource.post_24px1, AnchorStyles.Left, System.Drawing.Color.FromArgb(64, 64, 64),"reply");
                textReplyButton.Click += textReplyButtonHandler;
                textReplyButton.Location = new System.Drawing.Point(340, 0);

                CustomWitIconButton textReplyAllButton = new CustomWitIconButton(Resource.post_24px1, AnchorStyles.Left, System.Drawing.Color.FromArgb(64, 64, 64), "reply All");
                textReplyAllButton.Click += textReplyAllButtonHandler;
                textReplyAllButton.Location = new System.Drawing.Point(370, 0);

                CustomWitIconButton meetingButton = new CustomWitIconButton(Resource.paste_24px1, AnchorStyles.Left, System.Drawing.Color.FromArgb(64, 64, 64),"meeting");
                meetingButton.Click += meetingButtonHandler;
                meetingButton.Location = new System.Drawing.Point(400, 0);

                WebBrowser wb = new WebBrowser();                
                wb.DocumentText = " <br></br> " + wit.content == null ? "" : wit.content;
                wb.Name = wit.id;
                wb.Size = new System.Drawing.Size(435, 450);

                Panel panel1 = new Panel();
                panel1.Size = new System.Drawing.Size(500, 30);
                panel1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);  // gray color for mail panel
                panel1.Location = new System.Drawing.Point(0, 0);

                Panel panel2 = new Panel();
                panel2.Size = new System.Drawing.Size(500, 20);
                panel2.BackColor = System.Drawing.Color.Silver;  // silver for rating stars 
                panel2.Location = new System.Drawing.Point(0,30);

                panel1.Controls.Add(meetingButton);
                panel1.Controls.Add(textReplyAllButton);
                panel1.Controls.Add(textReplyButton);
                panel1.Controls.Add(forwardMailButton);
                panel1.Controls.Add(textMailButton);


                // create richTextboxPanel
                Panel WebBrowserPanel = new Panel();
                WebBrowserPanel.SuspendLayout();
                WebBrowserPanel.AutoSize = true;
                WebBrowserPanel.Dock = System.Windows.Forms.DockStyle.Top;
                WebBrowserPanel.Location = new System.Drawing.Point(0, 0);
                WebBrowserPanel.Name = "webBrowser";
                WebBrowserPanel.Size = new System.Drawing.Size(300, 600);
                WebBrowserPanel.TabIndex = 1;
               

                WebBrowserPanel.Controls.Add(panel1);   // gray
                WebBrowserPanel.Controls.Add(panel2);   // silver 

                // below is the acronym code block
                List<string> matches = StringUtils.searchAcronyms(wit.content == null ? "" : wit.content);
               
                var height = 20;
                foreach (String m in matches)
                {
                    var acro = m.Replace("]","").Replace("[","");
                    height += 30;
                    Panel acronymPanel = new FlowLayoutPanel();
                    acronymPanel.Size = new System.Drawing.Size(500, 30);
                    acronymPanel.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);  // gray color for mail panel
                    acronymPanel.Location = new System.Drawing.Point(0, height);
                    acronymPanel.AutoSize = true;
                    acronymPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;

                    Label acroLabel = new Label();
                    acroLabel.Size = new System.Drawing.Size(150, 30);
                    acroLabel.Text = acro;
                    acroLabel.Name = acro;
                    acroLabel.AutoSize = false;  // make it false to provide particular size
                  

                    TextBox acroText = new TextBox();
                    acroText.Size = new System.Drawing.Size(260, 30);
                    acroText.Name = acro;
                    acroText.LostFocus += acronymHandler;
                    acroText.Font = new System.Drawing.Font("Arial", 10F);
                    acroText.ForeColor = System.Drawing.Color.Gray;

                    acronymPanel.Controls.Add(acroLabel);
                    acronymPanel.Controls.Add(acroText);
                    WebBrowserPanel.Controls.Add(acronymPanel);
                }

                wb.Location = new System.Drawing.Point(0, height + 30);
                WebBrowserPanel.Controls.Add(wb);
                WebBrowserPanel.ResumeLayout();
                clcikedPanel.Controls.Add(WebBrowserPanel);
                clcikedPanel.Controls.Add(clickedWitButton);
            }
        }

        void acronymHandler(object sender, EventArgs e)
        {
           
            TextBox acronymText = new TextBox();
            acronymText = (TextBox)sender;
           

            var acronymTextValue = "[" + acronymText.Name + "]";
            // AcronymPanel -> web browser panel -> 
            Panel WebBrowserPanel = (Panel)((TextBox)sender).Parent.Parent;
            foreach (var webBrowserControl in WebBrowserPanel.Controls)
            {
                if (webBrowserControl is WebBrowser)
                {
                    WebBrowser wb = (WebBrowser)webBrowserControl;

                    // when the user has inputed values to change 
                    if (acronymText.Text.Length > 0)
                    {
                        wb.Document.Body.InnerHtml = wb.Document.Body.InnerHtml.Replace(acronymTextValue, acronymText.Text);
                        wb.DocumentText = changeHTMLColorToBlack(wb.Document.Body.InnerHtml, acronymText.Name).ToString();
                    }
                    else if(acronymText.Text.Length == 0) {
                        wb.DocumentText = changeHTMLColorToRed(wb.Document.Body.InnerHtml, acronymText.Name).ToString();
                    }
                }
            }
        }

        String changeHTMLColorToBlack(String stringDoc, String variableToChange)
        {
            var html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(stringDoc);
            var root = html.DocumentNode;
            var anchors = root.Descendants("SPAN");

            foreach (HtmlNode item in anchors)
            {
                foreach (HtmlAttribute arr in item.Attributes)
                {
                    if (arr.Name == "var" && arr.Value == variableToChange)
                    {
                        item.SetAttributeValue("style", "COLOR: rgb(0,0,0)");
                    }
                }
            }
            return html.DocumentNode.InnerHtml;
        }

        String changeHTMLColorToRed(String stringDoc, String variableToChange)
        {
            var html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(stringDoc);
            var root = html.DocumentNode;
            var anchors = root.Descendants("SPAN");

            foreach (HtmlNode item in anchors)
            {
                foreach (HtmlAttribute arr in item.Attributes)
                {
                    if (arr.Name == "var" && arr.Value == variableToChange)
                    {
                        item.InnerHtml = "["+variableToChange+"]";
                        item.SetAttributeValue("style", "COLOR: rgb(236,27,82)");
                      
                    }
                }
            }
            return html.DocumentNode.InnerHtml;
        }

        void textMailButtonHandler(object sender, EventArgs e)
        {
            Button clickedMailButton = new Button();
            clickedMailButton = (Button)sender;
            Panel webBrowserPanel = (Panel)((Button)sender).Parent.Parent;

            foreach (var control in webBrowserPanel.Controls) {

                if (control is WebBrowser) {

                    WebBrowser webBrowser = (WebBrowser)control;
                    String witId = webBrowser.Name.ToString();

                    String path = Common.path;
                    WitsDao witDao = new WitsDao();
                    Wits wit = witDao.getWit(witId);
                    List<Docs> docs = witDao.getDocsOfWit(wit.id);

                    TextToEmailBody mail = new TextToEmailBody();
                    mail.SendEmailUsingOutLook(webBrowser.DocumentText,wit.name, docs);

                }

            }
           
        }

        void textReplyButtonHandler(object sender, EventArgs e)
        {
            Button clickedReplyButton = new Button();
            clickedReplyButton = (Button)sender;
            Panel webBrowserPanel = (Panel)((Button)sender).Parent.Parent;

            foreach (var control in webBrowserPanel.Controls)
            {
                if (control is WebBrowser)
                {
                    WebBrowser webBrowser = (WebBrowser)control;
                    String witId = webBrowser.Name.ToString();

                    String path = Common.path;
                    WitsDao witDao = new WitsDao();
                    Wits wit = witDao.getWit(witId);
                    List<Docs> docs = witDao.getDocsOfWit(wit.id);

                    TextToEmailBody mail = new TextToEmailBody();
                    mail.replyEmailUsingOutLook(webBrowser.DocumentText, wit.name, docs);

                }
            }
        }

        void forwardMailButtonHandler(object sender, EventArgs e)
        {
            Button clickedReplyButton = new Button();
            clickedReplyButton = (Button)sender;
            Panel webBrowserPanel = (Panel)((Button)sender).Parent.Parent;

            foreach (var control in webBrowserPanel.Controls)
            {
                if (control is WebBrowser)
                {
                    WebBrowser webBrowser = (WebBrowser)control;
                    String witId = webBrowser.Name.ToString();

                    String path = Common.path;
                    WitsDao witDao = new WitsDao();
                    Wits wit = witDao.getWit(witId);
                    List<Docs> docs = witDao.getDocsOfWit(wit.id);

                    TextToEmailBody mail = new TextToEmailBody();
                    mail.ForwardEmailUsingOutLook(webBrowser.DocumentText, wit.name, docs);

                }
            }

        }

        void textReplyAllButtonHandler(object sender, EventArgs e)
        {
            Button clickedReplyButton = new Button();
            clickedReplyButton = (Button)sender;
            Panel webBrowserPanel = (Panel)((Button)sender).Parent.Parent;

            foreach (var control in webBrowserPanel.Controls)
            {
                if (control is WebBrowser)
                {
                    WebBrowser webBrowser = (WebBrowser)control;
                    String witId = webBrowser.Name.ToString();

                    String path = Common.path;
                    WitsDao witDao = new WitsDao();
                    Wits wit = witDao.getWit(witId);
                    List<Docs> docs = witDao.getDocsOfWit(wit.id);

                    TextToEmailBody mail = new TextToEmailBody();
                    mail.replyAllEmailUsingOutLook(webBrowser.DocumentText, wit.name, docs);

                }
            }

        }




        void meetingButtonHandler(object sender, EventArgs e)
        {
            Button clickedReplyButton = new Button();
            clickedReplyButton = (Button)sender;
            Panel webBrowserPanel = (Panel)((Button)sender).Parent.Parent;

            foreach (var control in webBrowserPanel.Controls)
            {
                if (control is WebBrowser)
                {
                    WebBrowser webBrowser = (WebBrowser)control;
                    String witId = webBrowser.Name.ToString();

                    String path = Common.path;
                    WitsDao witDao = new WitsDao();
                    Wits wit = witDao.getWit(witId);
                    List<Docs> docs = witDao.getDocsOfWit(wit.id);

                    CalenderUtils calenderUtil = new CalenderUtils();
                    calenderUtil.openCalenderPanel(webBrowser.DocumentText, wit.name, docs);

                }
            }

        }
    }

}
