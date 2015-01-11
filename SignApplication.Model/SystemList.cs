using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignApplication.Model
{
    [Table("SystemList")]
    public class SystemList
    {
        public SystemList()
        {
            SystemListValues = new List<SystemListValue>();
        }

        [Key]
        [Column("ID", TypeName = "int")]
        public int ID { get; set; }

        [Column("Title", TypeName = "varchar")]
        [MaxLength(250)]
        public string Title { get; set; }

        public virtual ICollection<SystemListValue> SystemListValues { get; set; }

        [Column("Del_fl", TypeName = "bit")]
        public bool IsDelete { get; set; }
    }
}
