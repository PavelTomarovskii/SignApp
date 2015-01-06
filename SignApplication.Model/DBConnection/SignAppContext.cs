using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignApplication.Model.DBConnection
{
    public class SignAppContext : DbContext
    {
        public SignAppContext(string aConnectionString)
            : base(aConnectionString)
        {
            //Database.SetInitializer(new SignDBInitializer());
            //Configuration.LazyLoadingEnabled = true;

            //Disable initializer
            Database.SetInitializer<SignAppContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<Document>()
                    .HasRequired(d => d.State)
                    .WithMany()
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<UploadedFile>()
                    .HasRequired(d => d.Group)
                    .WithMany()
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Request>()
                    .HasRequired(d => d.Status)
                    .WithMany()
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContentTemplate>()
                    .HasRequired(d => d.Content)
                    .WithMany()
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<SystemLog>()
                    .HasRequired(d => d.EventType)
                    .WithMany()
                    .WillCascadeOnDelete(false);
            */
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<ContentTemplate> ContentTemplates { get; set; }
        public DbSet<RequestDocContent> RequestDocContents { get; set; }
        public DbSet<UploadedFile> UploadedFiles { get; set; }

        public DbSet<SystemLog> SystemLogs { get; set; }
        public DbSet<SystemListValue> SystemListValues { get; set; }
        public DbSet<SystemList> SystemLists { get; set; }
    }
}
