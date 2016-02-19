using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OutlookAddIn1.controls
{
    class CustomTextBox : TextBox
    {

        public CustomTextBox() {

            Size = new System.Drawing.Size(150, 25);
            BackColor = System.Drawing.Color.WhiteSmoke;
            BorderStyle = System.Windows.Forms.BorderStyle.None;
            Location = new System.Drawing.Point(5, 10);
            Text = "Enter Keywords to Search";
            Multiline = true;
            ForeColor = System.Drawing.Color.Gray;
            TextAlign = HorizontalAlignment.Left;

        }
    }
}
