using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using SignApplication.Model;
using SignApplication.Model.DBConnection;

namespace SignApplication.Global.Repository.UploadedFiles
{
    public class UploadedFileRepository : IUploadedFileRepository
    {
        [Inject]
        public SignAppContext context { get; set; }

        public IQueryable<UploadedFile> UploadedFiles { get; set; }

        public void CreateUploadedFile(UploadedFile aFile)
        {
            using (context)
            {
                context.UploadedFiles.Add(aFile);
                context.SaveChanges();
            }
        }

        public UploadedFile GetUploadedFile(int aID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUploadedFile(UploadedFile aFile)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUploadedFile(UploadedFile aFile)
        {
            throw new NotImplementedException();
        }
    }
}