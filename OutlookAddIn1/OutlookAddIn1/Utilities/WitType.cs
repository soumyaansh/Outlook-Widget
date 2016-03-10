using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OutlookAddIn1.Utilities
{
    class WitType
    {

        private WitType(string value) { Value = value; }
        public string Value { get; set; }

        public static WitType COMBO { get { return new WitType("COMBO"); } }
        public static WitType ORDINARY { get { return new WitType("ORDINARY"); } }
        public static WitType DOC_WIT { get { return new WitType("DOC_WIT"); } }
        public static WitType WIT { get { return new WitType("WIT"); } }

    }
}
