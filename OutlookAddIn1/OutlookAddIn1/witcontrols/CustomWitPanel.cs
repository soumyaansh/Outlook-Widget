using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OutlookAddIn1
{
    public class CustomWitPanel : Panel
    {
        private Color colorBorder = Color.Black;

        public CustomWitPanel() {

            AutoSize = true;
            BackColor = System.Drawing.Color.Silver;
            BorderStyle = BorderStyle.None;
            Dock = System.Windows.Forms.DockStyle.Top;
            Location = new System.Drawing.Point(0, 0);
            Size = new System.Drawing.Size(200, 104);
            TabIndex = 1;
            AutoScroll = true;
            AutoScrollPosition = new System.Drawing.Point(0, 0);
            this.SetStyle(ControlStyles.UserPaint, true);

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //MessageBox.Show("inside OnPaint");
            base.OnPaint(e);
            e.Graphics.DrawRectangle(
                new Pen(
                    new SolidBrush(colorBorder), 2),
                    e.ClipRectangle);
        }


    

    }
}
