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

        public virtual SystemListValue Content { get; set; }

        [Column("X", TypeName = "float")]
        public float X { get; set; } //расположение верхнего левого угла

        [Column("Y", TypeName = "float")]
        public float Y { get; set; } //расположение верхнего левого угла

        [Column("Width", TypeName = "float")]
        public float Width { get; set; }

        [Column("Height", TypeName = "float")]
        public float Height { get; set; }

        [Column("Text", TypeName = "varchar")]
        [MaxLength(1000)]
        public string Text { get; set; }

        [Column("Required_fl", TypeName = "bit")]
        public bool IsRequired { get; set; }
    }
}
