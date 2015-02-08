using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignApplication.Model
{
    [Table("UploadedFile")]
    public class UploadedFile
    {
        public UploadedFile()
        {
        }

        [Key]
        [Column("ID", TypeName = "int")]
        public int ID { get; set; }

        [ForeignKey("Group")]
        [Column("GroupID", TypeName = "int")]
        public int GroupID { get; set; }

        public virtual SystemListValue Group { get; set; }

        [ForeignKey("Document")]
        [Column("DocumentID", TypeName = "int")]
        public int DocumentID { get; set; }

        public virtual Document Document { get; set; }

        [Column("PageCount", TypeName = "int")]
        public int PageCount { get; set; }

        [Column("Page", TypeName = "int")]
        public int Page { get; set; }

        [Column("UploadedDate", TypeName = "datetime")]
        public DateTime? UploadedDate { get; set; }

        [Column("Del_fl", TypeName = "bit")]
        public bool IsDelete { get; set; }

        [Column("FileName", TypeName = "varchar")]
        [MaxLength(250)]
        public string FileName { get; set; }

        [Column("ContentType", TypeName = "varchar")]
        [MaxLength(500)]
        public string ContentType { get; set; }

        [ForeignKey("User")]
        [Column("UserID", TypeName = "int")]
        public int UserID { get; set; }

        public virtual User User { set; get; }
    }
}
