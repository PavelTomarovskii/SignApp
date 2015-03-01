using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignApplication.Model
{
    [Table("Request")]
    public class Request
    {
        public Request()
        {
        }

        [Key]
        [Column("ID", TypeName = "int")]
        public int ID { get; set; }

        [ForeignKey("AddressesBook")]
        [Column("AddressesBookID", TypeName = "int")]
        public int AddressesBookID { get; set; }

        public virtual AddressesBook AddressesBook { get; set; }

        [Column("Date", TypeName = "datetime")]
        public DateTime? Date { get; set; }

        [ForeignKey("Document")]
        [Column("DocumentID", TypeName = "int")]
        public int DocumentID { get; set; }

        public virtual Document Document { get; set; }

        [ForeignKey("Status")]
        [Column("StatusID", TypeName = "int")]
        public int StatusID { get; set; }

        public virtual SystemListValue Status { get; set; }

        [Column("Del_fl", TypeName = "bit")]
        public bool IsDelete { get; set; }
    }
}
