using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using Ninject;
using SignApplication.Controllers.Common;
using SignApplication.Global.Authentication;
using SignApplication.Global.Repository.Documents;
using SignApplication.Global.Repository.UploadedFiles;
using SignApplication.Model;

namespace SignApplication.Controllers
{
    [CustomAuthorize]
    public class UploadController : BaseController
    {
        [Inject]
        public IUploadedFileRepository UploadedFileRepository { get; set; }

        [Inject]
        public IDocumentRepository DocumentRepository { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            var r = new List<ViewDataUploadFilesResult>();

            foreach (string file in Request.Files)
            {
                var statuses = new List<ViewDataUploadFilesResult>();
                var headers = Request.Headers;

                if (string.IsNullOrEmpty(headers["X-File-Name"]))
                {
                    UploadWholeFile(Request, statuses);
                }
                else
                {
                    UploadPartialFile(headers["X-File-Name"], Request, statuses);
                }

                JsonResult result = Json(statuses);
                result.ContentType = "text/plain";

                return result;
            }

            return Json(r);
        }

        public ActionResult Dowload()
        {
            return null;
        }

        public ActionResult Delete()
        {
            return null;
        }

        private void UploadPartialFile(string fileName, HttpRequestBase request, List<ViewDataUploadFilesResult> statuses)
        {
            if (request.Files.Count != 1) throw new HttpRequestValidationException("Attempt to upload chunked file containing more than one fragment per request");
            var file = request.Files[0];
            var inputStream = file.InputStream;

            var fullName = Path.Combine(StorageRoot, Path.GetFileName(fileName));

            using (var fs = new FileStream(fullName, FileMode.Append, FileAccess.Write))
            {
                var buffer = new byte[1024];

                var l = inputStream.Read(buffer, 0, 1024);
                while (l > 0)
                {
                    fs.Write(buffer, 0, l);
                    l = inputStream.Read(buffer, 0, 1024);
                }
                fs.Flush();
                fs.Close();
            }

            statuses.Add(new ViewDataUploadFilesResult()
            {
                name = fileName,
                size = file.ContentLength,
                type = file.ContentType,
                url = "/Home/Download/" + fileName,
                delete_url = "/Home/Delete/" + fileName,
                thumbnail_url = @"data:image/png;base64," + EncodeFile(fullName),
                delete_type = "GET",
            });
        }

        private void UploadWholeFile(HttpRequestBase request, List<ViewDataUploadFilesResult> statuses)
        {
            for (int i = 0; i < request.Files.Count; i++)
            {
                var file = request.Files[i];

                var filename = string.Format("{0}.{1}", Guid.NewGuid().ToString().Replace("-", "_"), GetExtention(file.ContentType));
                var dir = Path.Combine(StorageRoot, CurrentUser.ID.ToString());
                var fullPath = Path.Combine(dir, filename);

                var dr = new DirectoryInfo(dir);
                dr.Create();
                file.SaveAs(fullPath);

                var upfile = new UploadedFile()
                {
                    UserID = CurrentUser.ID,
                    FilePath = filename,
                    ContentType = file.ContentType,
                    GroupID = (int)enumUploadedFilesGroup.Document,
                    IsDelete = false,
                    UploadedDate = DateTime.Now
                };
                UploadedFileRepository.CreateUploadedFile(upfile);

                var document = new Document()
                {
                    Name = file.FileName,
                    UploadedFileID = upfile.ID,
                    IsDelete = false,
                    UploadDate = DateTime.Now,
                    UserID = CurrentUser.ID,
                    StateID = (int)enumDocumentState.Upload
                };
                DocumentRepository.CreateDocument(document);

                statuses.Add(new ViewDataUploadFilesResult()
                {
                    name = file.FileName,
                    size = file.ContentLength,
                    type = file.ContentType,
                    url = "/Upload/Download/" + file.FileName,
                    delete_url = "/Upload/Delete/" + file.FileName,
                    thumbnail_url = @"data:image/png;base64," + EncodeFile(fullPath),
                    delete_type = "GET",
                });
            }
        }

        private string EncodeFile(string fileName)
        {
            return Convert.ToBase64String(System.IO.File.ReadAllBytes(fileName));
        }

        private string StorageRoot
        {
            get { return Path.Combine(Server.MapPath(DocFilePath)); }
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

    public class ViewDataUploadFilesResult
    {
        public string name { get; set; }
        public int size { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string delete_url { get; set; }
        public string thumbnail_url { get; set; }
        public string delete_type { get; set; }
    }
}
