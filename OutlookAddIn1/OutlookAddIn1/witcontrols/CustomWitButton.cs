using System;
using System.Collections.Generic;
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


        public CustomWitButton() {
            
            BackColor = System.Drawing.Color.FromArgb(060, 060, 060);
            ForeColor = System.Drawing.Color.Gray;
            Dock = System.Windows.Forms.DockStyle.Top;
            FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Location = new System.Drawing.Point(0, 75);
            Name = "witButton";
            Size = new System.Drawing.Size(200, 40);
            TabIndex = 1;

            // TextImageRelation = TextImageRelation.ImageBeforeText;
            TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            UseVisualStyleBackColor = false;


        }

    }
}
