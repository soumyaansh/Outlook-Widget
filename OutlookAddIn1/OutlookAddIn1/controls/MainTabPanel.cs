using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _OutlookAddIn1.Model;
using _OutlookAddIn1.Rest;
using _OutlookAddIn1.witcontrols;

namespace _OutlookAddIn1.controls
{
    public class MainTabPanel :Panel
    {
        private MyUserControl control { get; set; }

       public  MainTabPanel(MyUserControl control) {

            this.control = control;
            this.AutoSize = true;
            this.Dock = System.Windows.Forms.DockStyle.Top;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "searchBoxPanel";
            this.TabIndex = 1;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Visible = false;

            Image searchImage = Resource.searchImage;
            PictureBox searchpb = new PictureBox();
            searchpb.Image = searchImage;
            searchpb.Location = new System.Drawing.Point(152, 9);
            searchpb.Size = new System.Drawing.Size(40, 40);

            CustomSearchTextBox searchBox = new CustomSearchTextBox();
            searchBox.GotFocus += searchTextBoxHandler;
            searchBox.LostFocus += searchTextBoxHandler;

            CustomMainButton searchButton = new CustomMainButton();
            searchButton.Text = "Search";
            searchButton.Location = new System.Drawing.Point(350, 8);
            searchButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            searchButton.Click += searchButtonHandler;
            searchButton.BackColor = System.Drawing.Color.FromArgb(120, 120, 120);

            CustomMainButton folderButton = new CustomMainButton();
            folderButton.Text = "Folders";
            folderButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            folderButton.Location = new System.Drawing.Point(190, 8);
            folderButton.Click += folderButtonHandler;
            folderButton.BackColor = System.Drawing.Color.FromArgb(120, 120, 120);

            CustomMainButton tagButton = new CustomMainButton();
            tagButton.Text = "Tags";
            tagButton.Location = new System.Drawing.Point(270, 8);

           

            this.Controls.Add(searchBox);
            this.Controls.Add(searchpb);
            this.Controls.Add(folderButton);
            this.Controls.Add(tagButton);
            this.Controls.Add(searchButton);
        }

        private void searchButtonHandler(object sender, EventArgs e)
        {
            control.searchFormPanel.Controls.Clear();

            Button clcikedPanel = (Button)(sender);
            clcikedPanel.BackColor = System.Drawing.Color.FromArgb(120, 120, 120);

            control.witsPanelContainer.Visible = false;
            control.pnlMenu.Visible = false;

            createSearchFormPanel(sender,e);

            control.searchFormPanel.Visible = true;
            control.searchPanelContainer.Visible = true;
 
        }

        private void createSearchFormPanel(object sender, EventArgs e)
        {
           
            CustomSearchLabel searchSubTitle1 = new CustomSearchLabel(new System.Drawing.Point(10, 60), "Search for Keyword in:");

            // left side criteria labels         
            CustomSearchCheckBox witTitle = new CustomSearchCheckBox(new System.Drawing.Point(30, 100), "Wit Title");
            CustomSearchCheckBox extention = new CustomSearchCheckBox(new System.Drawing.Point(30, 140), "File Extention");
            CustomSearchCheckBox folderName = new CustomSearchCheckBox(new System.Drawing.Point(30, 180), "Folder Name");
            CustomSearchCheckBox fileName = new CustomSearchCheckBox(new System.Drawing.Point(30, 220), "File Name");

            // right side criteria labels
            CustomSearchCheckBox tagName = new CustomSearchCheckBox(new System.Drawing.Point(230, 100), "Tag Name");
            CustomSearchCheckBox witContent = new CustomSearchCheckBox(new System.Drawing.Point(230, 140), "Wit Content");
            CustomSearchCheckBox notes = new CustomSearchCheckBox(new System.Drawing.Point(230, 180), "Notes");
            CustomSearchCheckBox documentContent = new CustomSearchCheckBox(new System.Drawing.Point(230, 220), "Document Content");

       
            // left side criteria
            CustomSearchLabel searchSubTitle2 = new CustomSearchLabel(new System.Drawing.Point(20, 260), "Filter by workspace");

            ComboBox workspaceComboBox = new ComboBox();
            workspaceComboBox.Location = new System.Drawing.Point(20, 290);
            workspaceComboBox.DropDownWidth = 200;
            workspaceComboBox.DropDownHeight = 80;
            workspaceComboBox.Size = new System.Drawing.Size(200, 20);
            workspaceComboBox.TabIndex = 0;
            workspaceComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            workspaceComboBox.BackColor = System.Drawing.Color.WhiteSmoke;
            workspaceComboBox.ForeColor = System.Drawing.Color.Gray;

            UserWorkspaceDao userWorkspaceDao = new UserWorkspaceDao();
            List<UserWorkspace> userworkspaces = userWorkspaceDao.getWorkspaceNames();

            if (userworkspaces != null && userworkspaces.Count > 0)
            {
                foreach (UserWorkspace ws in userworkspaces)
                {
                    workspaceComboBox.Items.Add(ws.Name);
                }
            }
          
           


            // right side criteria                  
            CustomSearchLabel searchSubTitle3 = new CustomSearchLabel(new System.Drawing.Point(220, 260), "Filter by wit type");

            CustomSearchCheckBox ordinary = new CustomSearchCheckBox(new System.Drawing.Point(230, 290), "ORDINARY");
            CustomSearchCheckBox docWit = new CustomSearchCheckBox(new System.Drawing.Point(230, 330), "DOC_WIT");
            CustomSearchCheckBox combo = new CustomSearchCheckBox(new System.Drawing.Point(230, 370), "COMBO");


            CustomSearchLabel searchSubTitle4 = new CustomSearchLabel(new System.Drawing.Point(20, 400), "Wit modified date :");

            CustomSearchLabel witmodifiedFromLabel = new CustomSearchLabel(new System.Drawing.Point(20, 430), "From :");
            DateTimePicker witmodifiedFrom = new DateTimePicker();
            witmodifiedFrom.Width = 200;
            witmodifiedFrom.Format = DateTimePickerFormat.Short;
            witmodifiedFrom.Value = DateTime.Today;
            witmodifiedFrom.Location = new System.Drawing.Point(20, 460);

            CustomSearchLabel witmodifiedToLabel = new CustomSearchLabel(new System.Drawing.Point(230, 430), "To :");
            DateTimePicker witmodifiedTo = new DateTimePicker();
            witmodifiedTo.Width = 200;
            witmodifiedTo.Format = DateTimePickerFormat.Short;
            witmodifiedTo.Value = DateTime.Today;
            witmodifiedTo.Location = new System.Drawing.Point(230, 460);

            CustomMainButton searchFormButton = new CustomMainButton();
            searchFormButton.Text = "Search";
            searchFormButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            searchFormButton.Location = new System.Drawing.Point(20, 520);
            searchFormButton.Click += searchFormSearchButtonHandler;
            searchFormButton.BackColor = System.Drawing.Color.FromArgb(120, 120, 120);


            control.searchFormPanel.Controls.Add(witTitle);
            control.searchFormPanel.Controls.Add(tagName);
            control.searchFormPanel.Controls.Add(extention);
            control.searchFormPanel.Controls.Add(witContent);
            control.searchFormPanel.Controls.Add(folderName);
            control.searchFormPanel.Controls.Add(notes);

            control.searchFormPanel.Controls.Add(searchSubTitle1);
            control.searchFormPanel.Controls.Add(searchSubTitle2);

            control.searchFormPanel.Controls.Add(workspaceComboBox);
            
            control.searchFormPanel.Controls.Add(searchSubTitle3);


            control.searchFormPanel.Controls.Add(ordinary);
            control.searchFormPanel.Controls.Add(docWit);
            control.searchFormPanel.Controls.Add(combo);

            control.searchFormPanel.Controls.Add(searchSubTitle4);

            control.searchFormPanel.Controls.Add(witmodifiedFromLabel);
            control.searchFormPanel.Controls.Add(witmodifiedToLabel);

            control.searchFormPanel.Controls.Add(witmodifiedFrom);
            control.searchFormPanel.Controls.Add(witmodifiedTo);
            control.searchFormPanel.Controls.Add(searchFormButton);

          
          
        }

        private void searchFormSearchButtonHandler(object sender, EventArgs e)
        {
            SearchInputJson inputJson = new SearchInputJson();
            inputJson.max = 200;
            inputJson.aggregateFields = new List<Object>();
            inputJson.searchFields = new List<Object>();
            inputJson.witType = new List<Object>();
            inputJson.workspaceIds = new List<Object>();
            inputJson.filterByFolderId = new List<Object>();
            inputJson.filterByTagId = new List<Object>();
            inputJson.witIds = new List<Object>();
            inputJson.labelIds = new List<Object>();

            inputJson.dateBegin = "";
            inputJson.dateEnd = "";
            inputJson.searchTerm = "";



            foreach (var control in control.searchFormPanel.Controls) {

                if (control is ComboBox) {
                    ComboBox com = (ComboBox)control;

                    UserWorkspaceDao workspaceDao = new UserWorkspaceDao();
                    UserWorkspace selectedWorkspace = workspaceDao.getByName(com.SelectedText.ToString());
                    if (selectedWorkspace.id != null && selectedWorkspace.id.Trim().Length > 0) {

                        inputJson.workspaceIds.Add(selectedWorkspace.id);
                    }
                }
            }


            // call the restSerchClient
            RestClientSearch restSearch = new RestClientSearch();
            restSearch.advanceSearch(inputJson);


        }

        void searchTextBoxHandler(object sender, EventArgs e)
        {
            CustomSearchTextBox searchTextBox = (CustomSearchTextBox)sender;
            if (searchTextBox.Text.Trim() == "")
            {
                searchTextBox.Text = "Keywords";
            }
            else if (searchTextBox.Text == "Keywords")
            {
                searchTextBox.Text = "";
            }
        }

        private void folderButtonHandler(object sender, EventArgs e)
        {
            control.witsPanelContainer.Visible = true;
            control.pnlMenu.Visible = true;

            createSearchFormPanel(sender, e);

            control.searchFormPanel.Visible = false;
            control.searchPanelContainer.Visible = false;

            Button clcikedPanel = (Button)(sender);
            clcikedPanel.BackColor = System.Drawing.Color.FromArgb(120, 120, 120);
           
        }


        private  void populateSearchPanel(object sender, EventArgs e)
        {

            // call the restsearch API and get the results
            // get all the result wits and show it
        
            // get the wits 
            WitsDao witsDao = new WitsDao();
            List<Wits> wits = witsDao.getWits("");

            if (wits.Count > 0)
            {

                control.witsPanel.Controls.Clear();
                control.pnlMenu.Visible = false;
                control.witsPanel.Visible = true;
                control.witsPanelContainer.Visible = true;

                foreach (var wit in wits)
                {
                    CustomWitButton witButton = new CustomWitButton();
                    witButton.Text = "  " + wit.name;
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
                control.witsPanelContainer.Controls.Add(control.mainTabPanel);
            }
        }

        private void witHandler(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
