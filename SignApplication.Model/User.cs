using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SignApplication.Model
{
    [Table("User")]
    public class User
    {
        public User()
        { }

        [Key]
        [Column("ID", TypeName = "int")]
        public int ID { set; get; }

        [Column("FirstName", TypeName = "varchar")]
        [MaxLength(250)]
        public string FirstName { set; get; }

        [Column("LastName", TypeName = "varchar")]
        [MaxLength(250)]
        public string LastName { set; get; }

        [Column("PatronymicName", TypeName = "varchar")]
        [MaxLength(250)]
        public string PatronymicName { set; get; }

        [Column("Email", TypeName = "varchar")]
        [MaxLength(250)]
        public string EMail { set; get; }

        [Column("Password", TypeName = "varchar")]
        public string Password { set; get; }

        [Column("Del_fl", TypeName = "bit")]
        public bool IsDelete { set; get; }

        public bool InRoles(string roles)
        {
            return true;
        }
    }
}
