using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _OutlookAddIn1.controls
{
    public class MainTabPanel :Panel
    {
        MyUserControl control;


       public  MainTabPanel(MyUserControl control) {

            this.control = control;
            this.AutoSize = true;
            this.Dock = System.Windows.Forms.DockStyle.Top;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "searchBoxPanel";
            this.TabIndex = 1;
            this.BackColor = System.Drawing.Color.LightGray;

            Image searchImage = Resource.searchImage;
            PictureBox searchpb = new PictureBox();
            searchpb.Image = searchImage;
            searchpb.Location = new System.Drawing.Point(152, 9);
            searchpb.Size = new System.Drawing.Size(40, 40);

            CustomSearchTextBox searchBox = new CustomSearchTextBox();
            searchBox.GotFocus += searchTextBoxHandler;
            searchBox.LostFocus += searchTextBoxHandler;

            CustomMainButton folderButton = new CustomMainButton();
            folderButton.Text = "Folders";
            folderButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            folderButton.Location = new System.Drawing.Point(190, 8);
            folderButton.Click += folderButtonHandler;
            folderButton.BackColor = System.Drawing.Color.FromArgb(120, 120, 120);

            CustomMainButton tagButton = new CustomMainButton();
            tagButton.Text = "Tags";
            tagButton.Location = new System.Drawing.Point(270, 8);

            CustomMainButton searchButton = new CustomMainButton();
            searchButton.Text = "Search";
            searchButton.Location = new System.Drawing.Point(350, 8);

            this.Controls.Add(searchBox);
            this.Controls.Add(searchpb);
            this.Controls.Add(folderButton);
            this.Controls.Add(tagButton);
            this.Controls.Add(searchButton);
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

            Button clcikedPanel = (Button)(sender);
            clcikedPanel.BackColor = System.Drawing.Color.FromArgb(120, 120, 120);
            control.witsPanelContainer.Visible = false;
            control.pnlMenu.Visible = true;
        }


    }
}
