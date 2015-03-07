using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignApplication.Model;

namespace SignApplication.Global.Repository.Email
{
    public interface IEmailRepository
    {
        IQueryable<EmailText> Emails { get; }
        void CreateEmail(EmailText aEmail);
        EmailText GetEmail(int aID);
        EmailText GetEmailByType(enumEmailType aEmailType);
        bool UpdateEmail(EmailText aEmail);
        bool DeleteEmail(EmailText aEmail);
    }
}
