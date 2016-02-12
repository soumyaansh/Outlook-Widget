using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;
using System.Windows.Forms;

namespace _OutlookAddIn1
{
    public class TextToEmailBody
    {
        public void SendEmailUsingOutLook(string witBody)
        {

            Microsoft.Office.Interop.Outlook.Application outlookApplication =
            new Microsoft.Office.Interop.Outlook.Application();

            Microsoft.Office.Interop.Outlook.MailItem email =
            (Microsoft.Office.Interop.Outlook.MailItem)outlookApplication.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

            email.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatRichText;
            email.Body = witBody;

            email.Display(true);

        }

        public void replyEmailUsingOutLook(string witBody)
        {            
            Microsoft.Office.Interop.Outlook.Application outlookApp = new Microsoft.Office.Interop.Outlook.Application();

            if (outlookApp.ActiveExplorer().Selection.Count > 0)
            {
                Object selectedMail = outlookApp.ActiveExplorer().Selection[1];

                if (selectedMail is Microsoft.Office.Interop.Outlook.MailItem)
                {
                    Microsoft.Office.Interop.Outlook.MailItem mailItem = (selectedMail as Microsoft.Office.Interop.Outlook.MailItem);
                    String htmlBody = mailItem.HTMLBody;
                    String Body = mailItem.Body;

                    var newBody = "<br>" + witBody + "<br> <br>" + mailItem.HTMLBody;
                    mailItem.HTMLBody = newBody;

                    mailItem.Reply();
                    mailItem.Display(true);
                    //MessageBox.Show(mailItem.Subject);
                }
            }

        }
    }
}
