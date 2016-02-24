using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OutlookAddIn1.controls
{
    class CustomMainButton : Button
    {

        public CustomMainButton() {

            ForeColor = System.Drawing.Color.FromArgb(64,64,64);
            Size = new System.Drawing.Size(80, 30);
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            //BorderStyle = System.Windows.Forms.BorderStyle.None;
            // BorderStyle = System.Windows.Forms.BorderStyle.None;
            FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
        }

    }
}
