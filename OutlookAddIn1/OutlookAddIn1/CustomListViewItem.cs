using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OutlookAddIn1
{
    class CustomListViewItem : ListViewItem
    {

        public String fieldId { get; set; }
        public String fieldType { get; set; }

        public String fieldDesc { get; set; }

        public CustomListViewItem()
        {
            // Customize the ListViewItem control by setting various properties.
            BackColor = System.Drawing.Color.White;
            Font = new System.Drawing.Font("Arial", 15, System.Drawing.FontStyle.Bold);
            ForeColor = System.Drawing.Color.Gray;
        }

        }
    }
