using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignApplication.Model;

namespace SignApplication.Global.Repository.AddressesBooks
{
    public interface IAddressesBookRepository
    {
        IQueryable<AddressesBook> AddressesBooks { get; }
        void CreateAddressesBook(AddressesBook aAddressesBook);
        AddressesBook GetAddressesBook(int aID);
        AddressesBook GetAddressesBookByUsers(int aIDFrom, int aIDTo);
        bool UpdateAddressesBook(AddressesBook aAddressesBook);
        bool DeleteAddressesBook(AddressesBook aAddressesBook);
    }
}
