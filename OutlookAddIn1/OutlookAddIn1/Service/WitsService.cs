using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _OutlookAddIn1.Model;
using _OutlookAddIn1.Utilities;

namespace _OutlookAddIn1.Service
{
    class WitsService
    {

        RestClientWits restWit = new RestClientWits();
        WitsDao witsDao = new WitsDao();
        public void saveNewWit(String witId) {

            // get the wit from API
            WitsInfo witsInfo = restWit.getWitInfo(witId);

            // check if the wit is a witcombo then get al the con associated wit content and merge it
            if (witsInfo.witType == WitType.COMBO.Value) {
                RestClientWits restWit = new RestClientWits();
                witsInfo.content =  restWit.getWitContent(witsInfo.id);
            }
            // create the wit object
            Wits wit = new Wits();
            wit.content = witsInfo.content;
            wit.id = witsInfo.id;
            wit.name = witsInfo.name;
            wit.workspaceId = witsInfo.workspaceId;
            wit.witType = witsInfo.witType;
            wit.parentId = witsInfo.parentId;
            wit.enterpriseId = witsInfo.enterpriseId;
            wit.type = witsInfo.witType;
            wit.desc = witsInfo.desc;

            // save the wit into database
            witsDao.saveSingleWit(wit);


        }

        public void deleteWit(String witId)
        {
            // save the wit into database
            witsDao.deleteWit(witId);
        }

        }
}
