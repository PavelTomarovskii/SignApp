using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using Ninject;
using SignApplication.Global.Repository.AddressesBooks;
using SignApplication.Global.Repository.Requests;
using SignApplication.Global.Repository.Users;
using SignApplication.Global.Service.Email;
using SignApplication.Model;
using SignApplication.ViewModel;

namespace SignApplication.Global.Service.Request
{
    public class RequestService : IRequestService
    {
        [Inject]
        public IRequestRepository RequestRepository { get; set; }

        [Inject]
        public IUserRepository UserRepository { get; set; }

        [Inject]
        public IAddressesBookRepository AddressesBookRepository { get; set; }

        [Inject]
        public IEmailService EmailService { get; set; }

        public void SendRequest(RequestItemView aRequestItem)
        {
            foreach (var person in aRequestItem.Persons)
            {
                AddressesBook address;
                if (person.UserID > 0)
                {
                    address = AddressesBookRepository.GetAddressesBookByUsers(aRequestItem.UserID, person.UserID);
                }
                else
                {
                    var user = new User()
                    {
                        EMail = person.Email,
                        FirstName = person.Name,
                        IsFake = true
                    };
                    UserRepository.CreateUser(user);

                    address = new AddressesBook
                    {
                        SenderFromID = aRequestItem.UserID,
                        SenderToID = user.ID
                    };
                    AddressesBookRepository.CreateAddressesBook(address);
                }

                var request = new Model.Request()
                {
                    DocumentID = aRequestItem.DocumentID,
                    AddressesBookID = address.ID,
                    Date = DateTime.Now,
                    StatusID = (int)enumRequestStatus.Sent,
                    IsDelete = false
                };
                RequestRepository.CreateRequest(request);

                EmailService.SendEmail_Request(address, request.ID);
            }
        }

        public IQueryable<User> GetPersons(int aUserID, string aEmailPart)
        {
            //var ret = from address in AddressesBookRepository.AddressesBooks
            //    join userTo in UserRepository.Users on address.SenderToID equals userTo.ID
            //    where address.SenderFromID == aUserID
            //    select new Persons()
            //    {
            //        //Email = userTo.EMail,
            //        //Name = userTo.IsFake ? userTo.FirstName ?? "" : userTo.FirstName ?? "" + " " + userTo.PatronymicName ?? "",
            //        UserID = userTo.ID
            //    };

            var ret1 = from address in AddressesBookRepository.AddressesBooks
                       join userTo in UserRepository.Users on address.SenderToID equals userTo.ID
                       where address.SenderFromID == aUserID && userTo.EMail.Contains(aEmailPart)
                       select userTo;



            return ret1;
        }
    }
}