using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignApplication.Model
{
    [Table("AddressesBook")]
    public class AddressesBook
    {
        public AddressesBook()
        {
        }

        [Key]
        [Column("ID", TypeName = "int")]
        public int ID { get; set; }

        [ForeignKey("SenderFrom")]
        [Column("SenderFromID", TypeName = "int")]
        public int SenderFromID { get; set; }

        public virtual User SenderFrom { get; set; }

        [ForeignKey("SenderTo")]
        [Column("SenderToID", TypeName = "int")]
        public int SenderToID { get; set; }

        public virtual User SenderTo { get; set; }
    }
}
