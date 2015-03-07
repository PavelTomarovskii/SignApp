using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Web;
using Ninject;
using SignApplication.Global.Repository.AddressesBooks;
using SignApplication.Global.Repository.Email;
using SignApplication.Global.Repository.Users;
using SignApplication.Global.Service.Crypto;
using SignApplication.Model;
using System.Net.Mail;
using SignApplication.ViewModel;

namespace SignApplication.Global.Service.Email
{
    public class EmailService : IEmailService
    {

        private const string EmailFrom = "sign.application@yandex.ru";

        private const string NAME = "<%NAME%>";
        private const string SENDERNAME = "<%SENDERNAME%>";
        private const string LINK = "<%LINK%>";

        [Inject]
        public IEmailRepository EmailRepository { get; set; }

        [Inject]
        public IAddressesBookRepository AddressesBookRepository { get; set; }

        [Inject]
        public IUserRepository UserRepository { get; set; }

        [Inject]
        public ICryptoService CryptoService { get; set; }

        private bool SendEmail(string aEmailTo, string aSubject, string aBody, string[] aAttachments)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    var message = new MailMessage(EmailFrom, aEmailTo, aSubject, aBody);

                    foreach (var aAttachment in aAttachments)
                    {
                        var attachData = new Attachment(aAttachment);
                        message.Attachments.Add(attachData);
                    }
                    client.Send(message);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private string CreateLink(int aRequestID)
        {
            var str = new StringBuilder();
            str.AppendFormat("<a href='http://localhost:38324//{0}'>{1}</a>", CryptoService.Encrypt(aRequestID.ToString()), "Нажмите здесь");
            return str.ToString();
        }

        public void SendEmail_Request(AddressesBook aAddressesBook, int aRequestID)
        {
            var email = EmailRepository.GetEmailByType(enumEmailType.Request);
            var body = new StringBuilder(email.Body);

            var userFrom = UserRepository.GetUser(aAddressesBook.SenderFromID);
            var userTo = UserRepository.GetUser(aAddressesBook.SenderToID);

            body.Replace(SENDERNAME, userFrom.IsFake 
                ? userFrom.FirstName 
                : string.Format("{0} {1}", userFrom.FirstName, userFrom.LastName));

            body.Replace(NAME, userTo.IsFake
                ? userTo.FirstName
                : string.Format("{0} {1}", userTo.FirstName, userTo.LastName));

            body.Replace(LINK, CreateLink(aRequestID));

            SendEmail(userTo.EMail, email.Subject, body.ToString(), new string[0]);
        }



    }
}