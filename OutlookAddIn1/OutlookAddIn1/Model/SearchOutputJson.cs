using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OutlookAddIn1.Model
{
    class SearchOutputJson
    {

        public List<WitResult> witResult { get; set; }
        public List<object> aggregations { get; set; }
    }
}
