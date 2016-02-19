using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OutlookAddIn1
{
    public class CustomWitPanel : Panel
    {

       public CustomWitPanel() {

            AutoSize = true;
            BackColor = System.Drawing.Color.DarkGray;
            Dock = System.Windows.Forms.DockStyle.Top;
            Location = new System.Drawing.Point(0, 0);
            Name = "customWitPanel";
            Size = new System.Drawing.Size(200, 104);
            TabIndex = 1;
            AutoScroll = true;
            

        }

    }
}
