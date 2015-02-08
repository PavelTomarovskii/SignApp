using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignApplication.Model
{
    public enum enumDocumentState
    {
        Upload = 1,
        Edit = 2,
        Sent = 3,
        ReadyToSend = 4
    }

    public enum enumRequestStatus
    {
        Sent = 5,
        Canceled = 6,
        Viewed = 7,
        Signed = 8
    }

    public enum enumEventType
    {
        Insert = 9,
        Update = 10,
        Delete = 11,
        ReqeustIsSent = 12
    }

    public enum enumUploadedFilesGroup
    {
        Document = 13,
        LargePage = 14,
        SmallPage = 15,
        SignPic = 16,
        ResultDoc = 17
    }

    public enum enumContentType
    {
        Sign = 1,
        Label = 2
    }
}
