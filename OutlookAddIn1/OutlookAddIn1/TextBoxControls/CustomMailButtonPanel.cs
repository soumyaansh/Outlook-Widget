using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OutlookAddIn1.TextBoxControls
{
    class CustomMailButtonPanel : Panel
    {
        public CustomMailButtonPanel()
        {

            AutoSize = true;
            Dock = System.Windows.Forms.DockStyle.Top;
            BackColor = System.Drawing.Color.Silver;
            Location = new System.Drawing.Point(0, 0);
            Name = "buttonsPanel";
            Size = new System.Drawing.Size(100, 5);
            TabIndex = 1;
            Height = 10;


        }

    }
}
