using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignApplication.Model;
using SignApplication.ViewModel;

namespace SignApplication.Global.Service.Email
{
    public interface IEmailService
    {
        void SendEmail_Request(AddressesBook aAddressesBook, int aRequestID);
    }
}
