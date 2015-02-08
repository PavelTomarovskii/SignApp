using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using Ninject;
using SignApplication.Global.Constants;
using SignApplication.Global.Repository.UploadedFiles;
using SignApplication.Global.Service.Convert;
using SignApplication.Model;

namespace SignApplication.Global.Service.File
{
    public class FileService : IFileService
    {
        [Inject]
        public IUploadedFileRepository UploadedFileRepository { get; set; }

        [Inject]
        public IConvertService ConvertService { get; set; }

        public string BaseFilesPath { get { return "base"; } }
        public string SmallFilesPath { get { return "small"; } }
        public string LargeFilesPath { get { return "large"; } }
        public string SignsFilePath { get { return "signs"; } }
        public string ResultFilePath { get { return "result"; } }
        
        public async Task CreateDocumentFolders(string aRoot, int aUserID, int aDocumentID)
        {
            await Task.Run( () =>
               {
                   var dir = Path.Combine(aRoot, aUserID.ToString(), aDocumentID.ToString(), BaseFilesPath);
                   var dr = new DirectoryInfo(dir);
                   dr.Create();

                   dir = Path.Combine(aRoot, aUserID.ToString(), aDocumentID.ToString(), LargeFilesPath);
                   dr = new DirectoryInfo(dir);
                   dr.Create();

                   dir = Path.Combine(aRoot, aUserID.ToString(), aDocumentID.ToString(), SmallFilesPath);
                   dr = new DirectoryInfo(dir);
                   dr.Create();

                   dir = Path.Combine(aRoot, aUserID.ToString(), aDocumentID.ToString(), SignsFilePath);
                   dr = new DirectoryInfo(dir);
                   dr.Create();

                   dir = Path.Combine(aRoot, aUserID.ToString(), aDocumentID.ToString(), ResultFilePath);
                   dr = new DirectoryInfo(dir);
                   dr.Create();
               });
        }

        public string GetNewFileName(string aContentType)
        {
            return string.Format("{0}.{1}", Guid.NewGuid().ToString().Replace("-", "_"), GetExtention(aContentType));
        }

        public string GetFilesDirectory(enumUploadedFilesGroup aFileGroup, string aRoot, int aUserID, int aDocumentID)
        {
            var dir = Path.Combine(aRoot, aUserID.ToString(), aDocumentID.ToString());

            string folder;
            switch (aFileGroup)
            {
                case enumUploadedFilesGroup.Document:
                    folder = BaseFilesPath;
                    break;
                case enumUploadedFilesGroup.LargePage:
                    folder = LargeFilesPath;
                    break;
                case enumUploadedFilesGroup.SmallPage:
                    folder = SmallFilesPath;
                    break;
                case enumUploadedFilesGroup.SignPic:
                    folder = SignsFilePath;
                    break;
                case enumUploadedFilesGroup.ResultDoc:
                    folder = ResultFilePath;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("aFileGroup");
            }

            return Path.Combine(dir, folder);
        }

        public async Task SaveFile(HttpPostedFileBase file, enumUploadedFilesGroup aFileGroup, string aRoot, int aUserID, int aDocumentID)
        {
            var filename = GetNewFileName(file.ContentType);
            int count = 0;

            var upfile = new UploadedFile()
            {
                UserID = aUserID,
                FileName = filename,
                PageCount = count,
                ContentType = file.ContentType,
                GroupID = (int)enumUploadedFilesGroup.Document,
                DocumentID = aDocumentID,
                IsDelete = false,
                UploadedDate = DateTime.Now
            };
            
            await Task.Run(() =>
            {
                UploadedFileRepository.CreateUploadedFile(upfile);

                var fullPath = Path.Combine(GetFilesDirectory(aFileGroup, aRoot, aUserID, aDocumentID), filename);
                file.SaveAs(fullPath);
            });

            switch (file.ContentType)
            {
                case "application/pdf":
                    var fullPath = Path.Combine(GetFilesDirectory(aFileGroup, aRoot, aUserID, aDocumentID), filename);

                    count = await ConvertService.ConvertPDFtoPNG(aUserID, aDocumentID, fullPath,
                        GetFilesDirectory(enumUploadedFilesGroup.LargePage, aRoot, aUserID, aDocumentID),
                        GetFilesDirectory(enumUploadedFilesGroup.SmallPage, aRoot, aUserID, aDocumentID));

                    upfile.PageCount = count;
                    UploadedFileRepository.UpdateUploadedFile(upfile);
                    break;
            }
        }

        private string GetExtention(string aContenType)
        {
            switch (aContenType)
            {
                case "image/jpeg":
                    return "jpg";
                case "application/pdf":
                    return "pdf";
                default:
                    return "none";
            }
        }
    }
}