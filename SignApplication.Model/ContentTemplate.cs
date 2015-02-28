using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignApplication.Model
{
    [Table("ContentTemplate")]
    public class ContentTemplate
    {
        public ContentTemplate()
        {
        }

        [Key]
        [Column("ID", TypeName = "int")]
        public int ID { get; set; }

        [ForeignKey("Document")]
        [Column("DocumentID", TypeName = "int")]
        public int DocumentID { get; set; }

        public virtual Document Document { get; set; }

        [ForeignKey("Content")]
        [Column("ContentID", TypeName = "int")]
        public int ContentID { get; set; }

        [Column("Page", TypeName = "int")]
        public int Page { get; set; }

        public virtual ContentType Content { get; set; }

        [Column("Left", TypeName = "float")]
        public float Left { get; set; }

        [Column("Top", TypeName = "float")]
        public float Top { get; set; }

        [Column("Zindex", TypeName = "float")]
        public int Zindex { get; set; }

        [Column("Width", TypeName = "float")]
        public float Width { get; set; }

        [Column("Height", TypeName = "float")]
        public float Height { get; set; }

        [Column("Text", TypeName = "varchar")]
        [MaxLength(1000)]
        public string Text { get; set; }

        [Column("Required_fl", TypeName = "bit")]
        public bool IsRequired { get; set; }

        [Column("Del_fl", TypeName = "bit")]
        public bool IsDelete { get; set; }
    }
}
