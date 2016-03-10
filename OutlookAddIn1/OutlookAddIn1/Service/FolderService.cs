using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OutlookAddIn1.Service
{
    class FolderService
    {

        RestClientFolder restFolder = new RestClientFolder();
        FolderDao folderDao = new FolderDao();
        public void saveNewFolder(String folderId)
        {

            // get the folder from API
            Folder folder = restFolder.getFolderDetails(folderId);
            Folder newFolder = new Folder();
            newFolder.id = folder.id;
            newFolder.name = folder.name;
            newFolder.workspaceId = folder.workspaceId;
            newFolder.parentId = folder.parentId;
            newFolder.enterpriseId = folder.enterpriseId;
            newFolder.type = folder.folderType;
            newFolder.children = folder.children;
            newFolder.hasChildren = folder.hasChildren;

            // save the wit into database
            folderDao.saveFolder(folder);

        }

        public void deleteFolder(String folderId)
        {
            // save the wit into database
            folderDao.deleteFolder(folderId);
        }


    }
}
