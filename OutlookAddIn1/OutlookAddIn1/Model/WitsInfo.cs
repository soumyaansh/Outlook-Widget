using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OutlookAddIn1.Model
{
    class WitsInfo
    {

    public string createdDate { get; set; }
    public string modifiedDate { get; set; }
    public CreatedBy createdBy { get; set; }
    public ModifiedBy modifiedBy { get; set; }
    public string id { get; set; }
    public string enterpriseId { get; set; }
    public string workspaceId { get; set; }
    public string name { get; set; }
    public string parentId { get; set; }
    public string firstAlertDate { get; set; }
    public string secondAlertDate { get; set; }
    public string expiryDate { get; set; }
    public string ownerId { get; set; }
    public string locale { get; set; }
    //public int sequenceNumber { get; set; }
    //public int updateNumber { get; set; }
    public string type { get; set; }
    public int version { get; set; }
    public int ratingCount { get; set; }
    public int ratingAggregation { get; set; }
    public string note { get; set; }
    public string desc { get; set; }
    public bool isFavorite { get; set; }
    public string source { get; set; }
    public object status { get; set; }
    public string witType { get; set; }
    public object comments { get; set; }
    public object commentCount { get; set; }
    public List<TagVo> tagVos { get; set; }
    public object attachmentDetails { get; set; }
    public object comboWit { get; set; }
    public string content { get; set; }
    public object acronyms { get; set; }
    public object label { get; set; }
    public LoggedInUserPermission loggedInUserPermission { get; set; }
    }
}
