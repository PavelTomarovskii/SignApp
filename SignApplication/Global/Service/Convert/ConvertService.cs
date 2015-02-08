using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Ninject;
using SignApplication.Global.Repository.UploadedFiles;
using SignApplication.Model;

namespace SignApplication.Global.Service.Convert
{
    public class ConvertService : IConvertService
    {
        [Inject]
        public IUploadedFileRepository UploadedFileRepository { get; set; }

        public async Task<int> ConvertPDFtoPNG(int aUserID, int aDocumentID, string aFilePath, string aLargePath, string aSmallPath)
        {
            string guid = string.Format("{0}.png", Guid.NewGuid().ToString().Replace("-", "_"));
            await CreateFiles(aFilePath, guid, aLargePath, true);

            var dr = new DirectoryInfo(aSmallPath);

            foreach (var file in dr.GetFiles())
            {
                var upfile = new UploadedFile()
                {
                    UserID = aUserID,
                    FileName = file.Name,
                    // Page = System.Convert.ToInt32(file.Name.Replace(guid, "").Replace(".png", "").Replace("-", "")),
                    ContentType = "image/png",
                    GroupID = (int) enumUploadedFilesGroup.LargePage,
                    DocumentID = aDocumentID,
                    IsDelete = false,
                    UploadedDate = DateTime.Now
                };
                UploadedFileRepository.CreateUploadedFile(upfile);

                upfile = new UploadedFile()
                {
                    UserID = aUserID,
                    FileName = file.Name,
                    // Page = System.Convert.ToInt32(file.Name.Replace(guid, "").Replace(".png", "").Replace("-", "")),
                    ContentType = "image/png",
                    GroupID = (int) enumUploadedFilesGroup.SmallPage,
                    DocumentID = aDocumentID,
                    IsDelete = false,
                    UploadedDate = DateTime.Now
                };
                UploadedFileRepository.CreateUploadedFile(upfile);
            }

            int z = await CreateFiles(aFilePath, guid, aSmallPath, false);
            return dr.GetFiles().Count();
        }

        private async Task<int> CreateFiles(string aFilePath, string aFileName, string aPath, bool isLarge)
        {
            return await Task.Run(() =>
            {
                string command = string.Format(isLarge
                    ? "convert -density 150 \"{0}\" -quality 100 -sharpen 0x1.0 \"{1}\""
                    : "convert \"{0}\" \"{1}\"",
                    aFilePath, Path.Combine(aPath, aFileName));

                // create the ProcessStartInfo using "cmd" as the program to be run,
                // and "/c " as the parameters.
                // Incidentally, /c tells cmd that we want it to execute the command that follows,
                // and then exit.
                var procStartInfo = new ProcessStartInfo("cmd", "/c " + command);

                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                //procStartInfo.RedirectStandardOutput = true;
                //procStartInfo.UseShellExecute = false;
                // Do not create the black window.
                procStartInfo.CreateNoWindow = true;
                // Now we create a process, assign its ProcessStartInfo and start it
                var proc = new Process();
                proc.StartInfo = procStartInfo;
                proc.Start();

                return 0;
            });

        }
    }
}