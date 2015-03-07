using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignApplication.Model
{
    [Table("EmailText")]
    public class EmailText
    {
        public EmailText()
        {
        }

        [Key]
        [Column("ID", TypeName = "int")]
        public int ID { get; set; }

        [ForeignKey("EmailType")]
        [Column("TypeID", TypeName = "int")]
        public int TypeID { get; set; }

        public virtual SystemListValue EmailType { set; get; }

        [Column("Subject", TypeName = "varchar")]
        [MaxLength(500)]
        public string Subject { set; get; }

        [Column("Text", TypeName = "varchar")]
        [MaxLength(4000)]
        public string Body { set; get; }

    }
}
