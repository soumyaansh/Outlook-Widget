using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop;
using System.Net;
using _OutlookAddIn1.Utilities;
using _OutlookAddIn1.Model;

namespace _OutlookAddIn1.Mail
{
    class CalenderUtils
    {

        public void openCalenderPanel(string witBody, String witName, List<Docs> docs)
        {

            var PacktAppointmentItem = (Microsoft.Office.Interop.Outlook.AppointmentItem)Globals.ThisAddIn.Application.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olAppointmentItem);
            PacktAppointmentItem.Subject = witName;
            //PacktAppointmentItem.Location = "My Room";
            PacktAppointmentItem.Start = DateTime.Now.AddHours(24.0);
            PacktAppointmentItem.MeetingStatus = Microsoft.Office.Interop.Outlook.OlMeetingStatus.olMeeting;
            PacktAppointmentItem.End = DateTime.Now.AddHours(25.0);
            PacktAppointmentItem.Body = HTMLUtils.ConvertHtml(witBody);
            if (docs != null && docs.Count > 0)
            {
                foreach (var doc in docs)
                {
                    if (doc.docId != null)
                    {
                        PacktAppointmentItem.Attachments.Add(doc.localPath + "" + doc.fileName, Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, 100000, Type.Missing);
                    }
                }
            }
            PacktAppointmentItem.Display(true);
        }

    }
}
