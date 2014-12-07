using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignApplication.Model
{
    [Table("Document")]
    public class Document
    {
        public Document()
        {
        }

        [Key]
        [Column("ID", TypeName = "int")]
        public int ID { set; get; }

        [Required]
        [Column("Name", TypeName = "varchar")]
        [MaxLength(250)]
        public string  Name { set; get; }

        [ForeignKey("User")]
        [Column("UserID", TypeName = "int")]
        public int UserID { get; set; }

        public virtual User User { set; get; }
        
        [Column("UploadDate", TypeName = "datetime")]
        public DateTime? UploadDate { set; get; }

        [Column("Del_fl", TypeName = "bit")]
        public bool IsDelete { set; get; }

        [ForeignKey("State")]
        [Column("StateID", TypeName = "int")]
        public int StateID { set; get; }

        public virtual SystemListValue State { get; set; }

        [ForeignKey("UploadedFile")]
        [Column("UploadedFileID", TypeName = "int")]
        public int UploadedFileID { get; set; }

        public virtual UploadedFile UploadedFile { get; set; }
    }
}
