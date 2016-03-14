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
            this.AutoScrollMargin = new System.Drawing.Size(0, 400);
            this.AutoSize = true;
            this.Dock = System.Windows.Forms.DockStyle.Top;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "childPanel";
            this.Size = new System.Drawing.Size(200, 104);
            this.TabIndex = 1;
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



    

