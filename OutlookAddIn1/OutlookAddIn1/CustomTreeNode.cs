using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OutlookAddIn1
{
    class CustomTreeNode : System.Windows.Forms.TreeNode
    {
        public String fieldId { get; set; }
        public String fieldType { get; set; }

    }
}
