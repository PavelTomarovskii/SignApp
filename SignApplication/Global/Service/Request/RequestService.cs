using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}