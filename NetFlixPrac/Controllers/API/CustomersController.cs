using NetFlixPrac.EF;
using NetFlixPrac.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;

namespace NetFlixPrac.Controllers.API
{
    public class CustomersController : ApiController
    {
        private readonly MyContext _context;
        public CustomersController(MyContext context)
        {
            _context = context;
        }

        public IEnumerable<CustomeDto> GetCustomers() 
        {
            var list = _context.Customers.ToList();
            var listofCustomerdto = list.Select(Mapper.Map<CustomeDto>);
            return listofCustomerdto;
        }

        public CustomeDto GetCustomer(int id) 
        {
            var customer = _context.Customers.
                Include(c => c.MembershipType).
                SingleOrDefault(c => c.Id == id);

            var customerDto = Mapper.Map<Customer, CustomeDto>(customer);

            return customerDto;
        }

        [HttpPost]
        public CustomeDto create(CustomeDto customerdto) 
        {
            if(!ModelState.IsValid) 
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customer = Mapper.Map<CustomeDto,Customer>(customerdto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerdto.Id = customer.Id;

            return customerdto;
        }

        [HttpPut]
        public void Edit(int id,CustomeDto  customerdto) 
        {
            var cusindb = _context.Customers.Find(id);

            if (cusindb == null) 
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map( customerdto , cusindb);
            

            _context.SaveChanges();

        }

        [HttpDelete]
        public void Delete(int id) 
        {
            var delcus = _context.Customers.Find(id);

            _context.Customers.Remove(delcus);  
            _context.SaveChanges();

        }


    }
}
