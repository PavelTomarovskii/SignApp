using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignApplication.Global.Service.Convert
{
    public interface IConvertService
    {
        Task<int> ConvertPDFtoPNG(int aUserID, int aDocumentID, string aFilePath, string aLargePath, string aSmallPath);
    }
}
