using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignApplication.Model;

namespace SignApplication.Global.Repository.RequestDocContents
{
    public interface IRequestDocContentRepository
    {
        IQueryable<RequestDocContent> RequestDocContents { get; }
        void CreateRequestDocContent(RequestDocContent aRequestDocContent);
        RequestDocContent GetRequestDocContent(int aID);
        bool UpdateRequestDocContent(RequestDocContent aRequestDocContent);
        bool DeleteRequestDocContent(RequestDocContent aRequestDocContent);
    }
}