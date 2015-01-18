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
            context.UploadedFiles.Attach(aFile);
            var entry = context.Entry(aFile);
            entry.State = System.Data.Entity.EntityState.Modified;
            return Convert.ToBoolean(context.SaveChanges());
        }

        public bool DeleteUploadedFile(UploadedFile aFile)
        {
            aFile.IsDelete = true;
            context.UploadedFiles.Attach(aFile);
            var entry = context.Entry(aFile);
            entry.State = System.Data.Entity.EntityState.Modified;
            return Convert.ToBoolean(context.SaveChanges());
        }
    }
}