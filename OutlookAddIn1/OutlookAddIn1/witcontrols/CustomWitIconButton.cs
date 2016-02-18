using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OutlookAddIn1.witcontrols
{
    public class CustomWitIconButton : Button
    {
        public CustomWitIconButton(String icon, AnchorStyles style, Color color) {

            Size = new System.Drawing.Size(25, 20);
            Anchor = style;
            FlatStyle = FlatStyle.Flat;
            BackColor = color;
            FlatAppearance.BorderColor = color;
            //BackColor =  System.Drawing.Color.Silver;
            // FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            Image = new Bitmap(icon);

        }


    }
}
