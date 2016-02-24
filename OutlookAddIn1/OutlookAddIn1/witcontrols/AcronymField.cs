using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OutlookAddIn1.witcontrols
{
    class AcronymField : FlowLayoutPanel
    {
        public Label label;
        public TextBox text_box;

        public AcronymField(string label_text): base()
        {
            AutoSize = true;
            label = new Label();
            label.Text = label_text;
            label.AutoSize = true;
            label.Anchor = AnchorStyles.Left;
            label.TextAlign = ContentAlignment.MiddleLeft;

            Controls.Add(label);

            text_box = new TextBox();

            Controls.Add(text_box);
        }

    }
}
