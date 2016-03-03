using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop;
using System.Net;

namespace _OutlookAddIn1.Mail
{
    class CalenderUtils
    {

        public void openCalenderPanel(string witBody, String witName)
        {

            var PacktAppointmentItem = (Microsoft.Office.Interop.Outlook.AppointmentItem)Globals.ThisAddIn.Application.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olAppointmentItem);
            PacktAppointmentItem.Subject = witName;
            //PacktAppointmentItem.Location = "My Room";
            PacktAppointmentItem.Start = DateTime.Now.AddHours(24.0);
            PacktAppointmentItem.MeetingStatus = Microsoft.Office.Interop.Outlook.OlMeetingStatus.olMeeting;
            PacktAppointmentItem.End = DateTime.Now.AddHours(25.0);
            PacktAppointmentItem.Body = WebUtility.UrlDecode(witBody);
                //ConvertToPlainText(witBody);
            //PacktAppointmentItem.RequiredAttendees = String.Join(";", rooms);
            PacktAppointmentItem.Display(true);
        }

    }
}
