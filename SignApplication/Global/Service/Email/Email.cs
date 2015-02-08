using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using SignApplication.Model;
using System.Net.Mail;

namespace SignApplication.Global.Service.Email
{
    public class Email : IEmail
    {
        public bool SendEmail(User aCurrentUser, string aTextMessage, string aDocFilePath = @"C:\Users\Pavel\Desktop\test.pdf")
        {
            var client = new SmtpClient();
            client.Port = 25;
            client.Host = "smtp.yandex.ru";
            client.EnableSsl = true;
            client.Timeout = 100000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            var attachData = new Attachment(aDocFilePath);
            client.Credentials = new System.Net.NetworkCredential("sign.application@yandex.ru", "MesLu21#Clz0");
            var mm = new MailMessage("sign.application@yandex.ru", aCurrentUser.EMail, "Sign App", aCurrentUser.LastName + "\n" + aCurrentUser.EMail + "\n" + "Был произведен вход в систему");
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            mm.Attachments.Add(attachData);
            client.Send(mm);
            return true;
        }
    }
}