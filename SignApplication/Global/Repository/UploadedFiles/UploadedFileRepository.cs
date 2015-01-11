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

        public IQueryable<UploadedFile> UploadedFiles
        {
            get
            {
                return context.UploadedFiles;
            }
        }

        public void CreateUploadedFile(UploadedFile aFile)
        {
            context.UploadedFiles.Add(aFile);
            context.SaveChanges();
        }

        public UploadedFile GetUploadedFile(int aID)
        {
            return context.UploadedFiles.FirstOrDefault(x => x.ID == aID);
        }

        public bool UpdateUploadedFile(UploadedFile aFile)
        {
            UploadedFile uplFile = context.UploadedFiles.FirstOrDefault(x => x.ID == aFile.ID);
            if (uplFile != null)
            {
                uplFile = aFile;
            }
            context.Entry(uplFile).State = System.Data.Entity.EntityState.Modified;
            return Convert.ToBoolean(context.SaveChanges());
        }

        public bool DeleteUploadedFile(UploadedFile aFile)
        {
            UploadedFile uplFile = context.UploadedFiles.FirstOrDefault(x => x.ID == aFile.ID);
            if (uplFile != null)
            {
                uplFile.IsDelete = true;
            }
            context.Entry(uplFile).State = System.Data.Entity.EntityState.Modified;
            return Convert.ToBoolean(context.SaveChanges());
        }
    }
}