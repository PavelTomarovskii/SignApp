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

    public enum enumContentElementType
    {
        Sign = 9
    }

    public enum enumEventType
    {
        Insert = 10,
        Update = 11,
        Delete = 12,
        ReqeustIsSent = 13
    }

    public enum enumUploadedFilesGroup
    {
        Document = 14
    }
}
