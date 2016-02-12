using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OutlookAddIn1
{
    public class CustomListView : ListView
    {
        Icon witIcon = new Icon("C:\\Users\\WittyParrot\\Documents\\Visual Studio 2015\\Projects\\OutlookAddIn1\\packages\\plus.ico");

        public CustomListView()
        {
            int itemHeight = 50;
            ImageList imgList = new ImageList();
            imgList.Images.Add(witIcon);
            imgList.ImageSize = new Size(1, itemHeight);
            SmallImageList = imgList;
            GridLines = true;
            Alignment = ListViewAlignment.Left;

            // Customize the TreeView control by setting various properties.
            BackColor = System.Drawing.Color.White;
            FullRowSelect = true;
            HotTracking = true;
            AutoArrange = false;
            AutoSize = true;
            Height = 30;
            Width = 30;

            Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            ForeColor = System.Drawing.Color.Gray;
           
            HideSelection = false;

            // The ShowLines property must be false for the FullRowSelect 
            // property to work.
        }

           
        protected override void OnColumnClick(System.Windows.Forms.ColumnClickEventArgs e)
        {
            MessageBox.Show("column clicked");
        }


       protected override void OnClick(EventArgs e) {

            // Hide the ListView and show the rich text box to show the wit description
            CustomListView ListView = (CustomListView)this;
            ListView.Visible = false;

            
            CustomListViewItem selectedItem = (CustomListViewItem)ListView.SelectedItems[0];
            var witName = selectedItem.Text.ToString();
            var witId = selectedItem.fieldId;
            var witType = selectedItem.fieldType;
            var witDesc = selectedItem.fieldDesc;

            MyUserControl control = (MyUserControl)this.Parent;
            CustomRichTextBox richBox = control.myRichTextBox;
            

            // append wit description in the text box 
            richBox.AppendText(witDesc == null ? "" : witDesc);
            richBox.Visible = true;
            richBox.Enabled = true;

            //MessageBox.Show(witDesc + " wit type:"+witType + " witId:"+witId);
        }

    }
}
