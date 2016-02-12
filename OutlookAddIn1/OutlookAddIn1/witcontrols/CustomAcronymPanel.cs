using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OutlookAddIn1.witcontrols
{
    public class CustomAcronymPanel : FlowLayoutPanel
    {
        public CustomAcronymPanel() {

          
            AutoSize = true;
            BackColor = System.Drawing.Color.Silver;
            Dock = System.Windows.Forms.DockStyle.Top;
            Size = new System.Drawing.Size(20, 200);
            TabIndex = 1;


        }
    }
}
