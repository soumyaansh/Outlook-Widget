using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OutlookAddIn1.controls
{
    class CustomWorkspacePanel : Panel 
    {
       

        public CustomWorkspacePanel(): base()
        {
            this.BorderStyle = BorderStyle.None;
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
           // MessageBox.Show("inside onpaint workspace");
            base.OnPaint(e);
            Rectangle r = this.ClientRectangle;
            r.Width -= 1;
            r.Height -= 1;
            e.Graphics.DrawRectangle(Pens.DeepSkyBlue, r);
        }

       

    }
}



    

