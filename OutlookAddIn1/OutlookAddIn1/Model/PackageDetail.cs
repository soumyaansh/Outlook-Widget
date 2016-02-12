using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OutlookAddIn1
{
    class PackageDetail
    {
        public string id { get; set; }
        public string name { get; set; }
        public string startDate { get; set; }
        public object endDate { get; set; }
        public string status { get; set; }
        public List<Feature> features { get; set; }
    }
}
