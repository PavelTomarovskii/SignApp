using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignApplication.Model;

namespace SignApplication.Global.Repository.UploadedFiles
{
    public interface IUploadedFileRepository
    {
        IQueryable<UploadedFile> UploadedFiles { get; set; }
        void CreateUploadedFile(UploadedFile aFile);
        UploadedFile GetUploadedFile(int aID);
        bool UpdateUploadedFile(UploadedFile aFile);
        bool DeleteUploadedFile(UploadedFile aFile);
    }
}
