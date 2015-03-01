using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignApplication.Model;

namespace SignApplication.Global.Service.Email
{
    public interface IEmailService
    {
        bool SendEmail(User aCurrentUser, string aTextMessage, string aDocFilePath = null);
    }
}
