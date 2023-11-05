using AutoMapper;
using NetFlixPrac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetFlixPrac.App_Start
{
    public class Mappingprofile : Profile
    {
        public Mappingprofile()
        {
            Mapper.CreateMap<Customer, CustomeDto>();
            Mapper.CreateMap<CustomeDto, Customer>();
        }
    }
}