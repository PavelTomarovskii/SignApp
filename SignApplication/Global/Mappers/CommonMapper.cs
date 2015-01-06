using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SignApplication.Model;
using SignApplication.ViewModel;

namespace SignApplication.Global.Mappers
{
    public class CommonMapper : IMapper
    {
        static CommonMapper()
        {
            Mapper.CreateMap<Document, DocumentView>();
            Mapper.CreateMap<DocumentView, Document>();
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }
    }
}