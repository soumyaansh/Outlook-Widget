using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _OutlookAddIn1.Utilities;

namespace _OutlookAddIn1.witcontrols
{
    class CustomWitButton : Button
    {

        public String fieldId { get; set; }
        public String fieldType { get; set; }

        //String wsIcon = Common.path + "/wpdependencies/list_icon.ico";
        //String wsIcon = "C:\\Users\\WittyParrot\\Documents\\Visual Studio 2015\\Projects\\OutlookAddIn1\\packages\\witIcon.ico";

        public CustomWitButton() {
            
            BackColor = System.Drawing.Color.FromArgb(070, 070, 070);
            ForeColor = System.Drawing.Color.Silver;
            Dock = System.Windows.Forms.DockStyle.Top;
            FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(050, 050, 050);
            FlatAppearance.BorderSize = 1;
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;
           
            FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(046, 046, 046);
            BackColorChanged += (s, e) => {
                FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(046, 046, 046);
            };
            Location = new System.Drawing.Point(0, 75);
            Name = "witButton";
            Size = new System.Drawing.Size(200, 40);
            TabIndex = 1;
            TextImageRelation = TextImageRelation.ImageBeforeText;
            TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(appDataPath, "wpoutlookwidget" + @"\");



            Image = new Bitmap(path + "wpdependencies\\list_icon.ico");
            ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            UseVisualStyleBackColor = false;


        }

       

}
}
