using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignApplication.Model
{
    [Table("RequestDocContent")]
    public class RequestDocContent
    {
        public RequestDocContent()
        {
        }

        [Key]
        [Column("ID", TypeName = "int")]
        public int ID { get; set; }

        [ForeignKey("Request")]
        [Column("RequestID", TypeName = "int")]
        public int RequestID { get; set; }

        public virtual Request Request { get; set; }

        [ForeignKey("ContentTemplate")]
        [Column("ContentTemplateID", TypeName = "int")]
        public int ContentTemplateID { get; set; }

        public virtual ContentTemplate ContentTemplate { get; set; }

        [Column("Value", TypeName = "varchar")]
        [MaxLength(1000)]
        public string Value { get; set; } // либо 1/0; текст;id image

        [Column("Del_fl", TypeName = "bit")]
        public bool IsDelete { get; set; }
    }
}
