using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SignApplication.Model;

namespace SignApplication.Global.Constants
{
    public interface IFileService
    {
        string BaseFilesPath { get; }
        string SmallFilesPath { get; }
        string LargeFilesPath { get; }
        string SignsFilePath { get; }
        string ResultFilePath { get; }

        Task CreateDocumentFolders(string aRoot, int aUserID, int aDocumentID);
        Task<int> SaveFile(HttpPostedFileBase file, enumUploadedFilesGroup aFileGroup, string aRoot, int aUserID, int aDocumentID);

        string GetNewFileName(string aContentType);
        string GetFilesDirectory(enumUploadedFilesGroup aFileGroup, string aRoot, int aUserID, int aDocumentID);
    }
}
