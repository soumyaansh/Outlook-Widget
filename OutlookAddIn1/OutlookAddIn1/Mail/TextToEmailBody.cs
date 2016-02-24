using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;
using System.Windows.Forms;
using _OutlookAddIn1.Model;
using System.IO;

namespace _OutlookAddIn1
{
    public class TextToEmailBody
    {
        public void SendEmailUsingOutLook(string witBody,String witName, List<Docs> docs)
        {

            Microsoft.Office.Interop.Outlook.Application outlookApplication =
            new Microsoft.Office.Interop.Outlook.Application();

            Microsoft.Office.Interop.Outlook.MailItem email =
            (Microsoft.Office.Interop.Outlook.MailItem)outlookApplication.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

            email.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatRichText;
            email.Subject = witName;
            email.HTMLBody = witBody;

            if (docs != null && docs.Count > 0) {

                foreach (var doc in docs) {
                    if (doc.docId != null)
                    {
                        email.Attachments.Add(doc.localPath + "" + doc.fileName, Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, 100000, Type.Missing);
                    }
                }
            }
           

            email.Display(true);

        }

        public void replyEmailUsingOutLook(string witBody,String witName, List<Docs> docs)
        {            
            Microsoft.Office.Interop.Outlook.Application outlookApp = new Microsoft.Office.Interop.Outlook.Application();

            if (outlookApp.ActiveExplorer().Selection.Count > 0)
            {
                Object selectedMail = outlookApp.ActiveExplorer().Selection[1];

                if (selectedMail is Microsoft.Office.Interop.Outlook.MailItem)
                {
                    Microsoft.Office.Interop.Outlook.MailItem mail = (selectedMail as Microsoft.Office.Interop.Outlook.MailItem);
                    Microsoft.Office.Interop.Outlook.MailItem reply = mail.Reply();
                   
                    Microsoft.Office.Interop.Outlook.MailItem email =
                    (Microsoft.Office.Interop.Outlook.MailItem)outlookApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                    email.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatRichText;
                    email.HTMLBody = witBody + reply.HTMLBody;
                   
                    email.To = mail.SenderEmailAddress;
                    email.Subject = reply.Subject;

                    if (docs != null && docs.Count > 0)
                    {

                        foreach (var doc in docs)
                        {
                            if (doc.docId != null)
                            {
                                email.Attachments.Add(doc.localPath + "" + doc.fileName, Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, 100000, Type.Missing);
                            }
                        }
                    }

                    email.Display(true);
                   
                }
            }

        }
    }
}
