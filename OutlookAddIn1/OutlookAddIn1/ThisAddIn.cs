using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace _OutlookAddIn1
{
    public partial class ThisAddIn
    {

        private MyUserControl myUserControl1;
        private MyUserControl myUserControl2;
        private Microsoft.Office.Tools.CustomTaskPane myCustomTaskPane;


        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            showWpWidget();

        }

        private void showWpWidget() {

            myUserControl1 = new MyUserControl();
          //  myUserControl2 = new MyUserControl();
            myCustomTaskPane = this.CustomTaskPanes.Add(myUserControl1, "WittyParrot");
          //  myCustomTaskPane = this.CustomTaskPanes.Add(myUserControl2, "WittyParrot");
            myCustomTaskPane.Visible = true;
            myCustomTaskPane.Width = 450;
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see http://go.microsoft.com/fwlink/?LinkId=506785
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
