using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OutlookAddIn1
{
    public class CustomRichTextBox : RichTextBox
    {

        public CustomRichTextBox() {

            BackColor = System.Drawing.Color.WhiteSmoke;
            Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular);
            //ForeColor = System.Drawing.Color.Gray;
            Size = new System.Drawing.Size(460, 800);
            Location = new System.Drawing.Point(0, 0);
            WordWrap = true;
            ReadOnly = true;
            //RightMargin = 1;

        }

        protected override void OnDoubleClick(EventArgs e)
        {

            TextToEmailBody textToEmailBody = new TextToEmailBody();
            textToEmailBody.SendEmailUsingOutLook("hello this is the wit content to email body");
            MessageBox.Show("RichTextBox clicked");
        }


       
        }
}
