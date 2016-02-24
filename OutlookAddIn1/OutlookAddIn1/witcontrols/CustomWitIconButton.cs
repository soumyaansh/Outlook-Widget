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
        public CustomWitIconButton(Image iconImage, AnchorStyles style, Color color) {

            Size = new System.Drawing.Size(25, 28);
            Anchor = style;
            FlatStyle = FlatStyle.Flat;
            BackColor = color;
            FlatAppearance.BorderColor = color;
            Image = iconImage;
            
        }


    }
}
