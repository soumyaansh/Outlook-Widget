using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OutlookAddIn1.controls
{
   public class CustomSearchCheckBox : CheckBox
    {

        public CustomSearchCheckBox(System.Drawing.Point location, String text) {

            this.Text = text;
            this.Location = location;
            this.AutoSize = true;
            this.ForeColor = System.Drawing.Color.Gray;         
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = text;
            this.Size = new System.Drawing.Size(105, 21);
            this.TabIndex = 7;          
            this.UseVisualStyleBackColor = true;
            this.BackColor = System.Drawing.Color.Transparent;

        }


    }
}
