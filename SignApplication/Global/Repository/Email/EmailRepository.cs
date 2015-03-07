using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using SignApplication.Model;
using SignApplication.Model.DBConnection;

namespace SignApplication.Global.Repository.Email
{
    public class EmailRepository : IEmailRepository
    {
        [Inject]
        public SignAppContext context { get; set; }

        public IQueryable<EmailText> Emails
        {
            get
            {
                return context.EmailTexts;
            }
        }

        public void CreateEmail(EmailText aEmail)
        {
            context.EmailTexts.Add(aEmail);
            context.SaveChanges();
        }

        public EmailText GetEmail(int aID)
        {
            return context.EmailTexts.FirstOrDefault(x => x.ID == aID);
        }

        public bool UpdateEmail(EmailText aEmail)
        {
            context.EmailTexts.Attach(aEmail);
            var entry = context.Entry(aEmail);
            entry.State = System.Data.Entity.EntityState.Modified;
            return Convert.ToBoolean(context.SaveChanges());
        }

        public bool DeleteEmail(EmailText aEmail)
        {
            return true;
        }


        public EmailText GetEmailByType(enumEmailType aEmailType)
        {
            return context.EmailTexts.FirstOrDefault(x => x.TypeID == (int)aEmailType);
        }
    }
}