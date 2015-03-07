using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using SignApplication.Model;
using SignApplication.Model.DBConnection;

namespace SignApplication.Global.Repository.AddressesBooks
{
    public class AddressesBookRepository : IAddressesBookRepository
    {
        [Inject]
        public SignAppContext context { get; set; }


        public IQueryable<AddressesBook> AddressesBooks
        {
            get
            {
                return context.AddressesBooks;
            }
        }
        public void CreateAddressesBook(AddressesBook aAddressesBook)
        {
            context.AddressesBooks.Add(aAddressesBook);
            context.SaveChanges();
        }

        public AddressesBook GetAddressesBook(int aID)
        {
            return context.AddressesBooks.FirstOrDefault(x => x.ID == aID);
        }

        public AddressesBook GetAddressesBookByUsers(int aIDFrom, int aIDTo)
        {
            return context.AddressesBooks.FirstOrDefault(x => x.SenderFromID == aIDFrom && x.SenderToID == aIDTo);
        }

        public bool UpdateAddressesBook(AddressesBook aAddressesBook)
        {
            context.AddressesBooks.Attach(aAddressesBook);
            var entry = context.Entry(aAddressesBook);
            entry.State = System.Data.Entity.EntityState.Modified;
            return Convert.ToBoolean(context.SaveChanges());
        }

        public bool DeleteAddressesBook(AddressesBook aAddressesBook)
        {
            //aAddressesBook.IsDelete = true;
            //context.AddressesBooks.Attach(aAddressesBook);
            //var entry = context.Entry(aAddressesBook);
            //entry.State = System.Data.Entity.EntityState.Modified;
            //return Convert.ToBoolean(context.SaveChanges());
            return true;
        }
    }
}