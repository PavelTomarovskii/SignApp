using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignApplication.Model
{
    [Table("SystemLog")]
    public class SystemLog
    {
        public SystemLog()
        {
        }

        [Key]
        [Column("ID", TypeName = "int")]
        public int ID { get; set; }

        [ForeignKey("EventType")]
        [Column("EventTypeID", TypeName = "int")]
        public int EventTypeID { get; set; }

        public virtual SystemListValue EventType { get; set; }

        [ForeignKey("User")]
        [Column("UserID", TypeName = "int")]
        public int UserID { get; set; }

        public virtual User User { get; set; }

        [Column("Date", TypeName = "datetime")]
        public DateTime? Date { get; set; }

        [Column("Message", TypeName = "varchar")]
        [MaxLength(250)]
        public string Message { get; set; }

        [Column("Del_fl", TypeName = "bit")]
        public bool IsDelete { get; set; }
    }
}
