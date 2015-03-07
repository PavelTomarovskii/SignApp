using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignApplication.Global.Service.Crypto
{
    public interface ICryptoService
    {
        string Encrypt(string str);
        string Decrypt(string str);
    }
}
