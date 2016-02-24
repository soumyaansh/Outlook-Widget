using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OutlookAddIn1.witcontrols
{
    class CustomWitButton : Button
    {

        public String fieldId { get; set; }
        public String fieldType { get; set; }

        String wsIcon = "C:\\Users\\WittyParrot\\Documents\\Visual Studio 2015\\Projects\\OutlookAddIn1\\packages\\ws128Icon.ico";

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
            Image = new Bitmap(wsIcon);
            ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            UseVisualStyleBackColor = false;


        }

       

}
}
