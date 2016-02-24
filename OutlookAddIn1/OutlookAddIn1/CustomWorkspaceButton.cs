using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OutlookAddIn1
{
    public class CustomWorkspaceButton : Button
    {
        public String fieldId { get; set; }
        public String fieldType { get; set; }


        public CustomWorkspaceButton()
        {
           
            BackColor = System.Drawing.Color.FromArgb(166, 166, 166);
            Dock = System.Windows.Forms.DockStyle.Top;
            FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            FlatAppearance.BorderSize = 1- Convert.ToInt32(.5);
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Location = new System.Drawing.Point(0, 75);
            Name = "workspaceButton";
            Size = new System.Drawing.Size(200, 60);       
            ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            TabIndex = 1;
            ForeColor = System.Drawing.Color.White;
            Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular);
            TextImageRelation = TextImageRelation.ImageBeforeText;
            TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            UseVisualStyleBackColor = false;
        }


    }

   

  


}
