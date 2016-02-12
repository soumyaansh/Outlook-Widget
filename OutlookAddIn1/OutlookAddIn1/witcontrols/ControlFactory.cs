using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OutlookAddIn1.witcontrols
{
    class ControlFactory
    {

        public List<CustomWitPanel> getChildWitPanels() {

            List<CustomWitPanel> witChildPanels = new List<CustomWitPanel>();
            for (int i = 0; i <= 9; i++)
            {
                CustomWitButton witButton = new CustomWitButton();
                CustomWitPanel childWitPanel = new CustomWitPanel();
                childWitPanel.Controls.Add(witButton);
                witChildPanels.Add(childWitPanel);
            }
            return witChildPanels;


        }

    }
}
