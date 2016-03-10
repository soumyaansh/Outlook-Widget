using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OutlookAddIn1.controls
{
   public class CustomSearchLabel :Label
    {

        public CustomSearchLabel(System.Drawing.Point location,String text) {

            this.AutoSize = true;
            this.Font = new System.Drawing.Font("Arial", 10F);
            this.ForeColor = System.Drawing.Color.Gray;
            this.Location = location;
            this.Name = text;
            this.Text = text;
            this.BackColor = System.Drawing.Color.Transparent;

        }

    }
}
