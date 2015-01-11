using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignApplication.Model
{

    [Table("SystemListValue")]
    public class SystemListValue
    {
        public SystemListValue()
        {
        }

        [Key]
        [Column("ID", TypeName = "int")]
        public int ID { get; set; }

        [ForeignKey("SystemList")]
        [Column("SystemListID", TypeName = "int")]
        public int SystemListID { get; set; }

        public virtual SystemList SystemList { get; set; }

        [Column("Title", TypeName = "varchar")]
        [MaxLength(250)]
        public string Title { get; set; }

        [Column("Del_fl", TypeName = "bit")]
        public bool IsDelete { get; set; }

    }
}
