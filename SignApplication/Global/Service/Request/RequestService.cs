using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using SignApplication.Global.Repository.Requests;
using SignApplication.Global.Repository.Users;
using SignApplication.Global.Service.Email;
using SignApplication.ViewModel;

namespace SignApplication.Global.Service.Request
{
    public class RequestService : IRequestService
    {
        [Inject]
        public IRequestRepository RequestRepository { get; set; }

        [Inject]
        public IUserRepository UserRepository { get; set; }

        //[Inject]
        //public IAddressesBookRepository AddressesBookRepository { get; set; }

        [Inject]
        public IEmailService EmailService { get; set; }

        public void SendRequest(RequestItemView aRequestItem)
        {
           
        }
    }
}