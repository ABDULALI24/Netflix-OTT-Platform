using NetFlixPrac.EF;
using NetFlixPrac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Diagnostics;

namespace NetFlixPrac.Controllers
{
    public class CustomersController : OTTController
    {
       
        private readonly MyContext _Context ;
        public CustomersController(MyContext context)
        {
            _Context = context;
            
        }

        
        public ActionResult List()
        {

            return View(_Context.Customers.Include(c => c.MembershipType).Where(c => c.IsActive == true));
        }

        public ActionResult Create() 
        {
            ViewBag.MembershipTypeList = _Context.MembershipTypes.ToList();
            return View("CustomerForm",new Customer() );

        }
        public ActionResult Save(Customer customer) 
        {
            if(ModelState.IsValid) 
            {
                if (customer.Id == 0)
                {
                     customer.IsActive= true;
                     customer.CreatedOn= DateTime.Now;
                    _Context.Customers.Add(customer);
                    customer.CreatedBy = GetCurresntUserName();
                }
                else
                {
                    var id = customer.Id;
                    var customerindb = _Context.Customers.Find(id);
                    TryUpdateModel(customerindb);
                    customerindb.UpdatedOn = DateTime.Now;
                    customerindb.UpdatedBy = GetCurresntUserName();

                }

                _Context.SaveChanges();

                return RedirectToAction("List","Customers");

            }
            else 
            {

                ViewBag.MembershipTypeList = _Context.MembershipTypes.ToList();
                return View("CustomerForm", customer);
            }


        }

        public ActionResult Edit(int id)
        {
            ViewBag.MembershipTypeList = _Context.MembershipTypes.ToList();
            var customerindb = _Context.Customers.Find(id);
            return View("CustomerForm", customerindb);
        }

        public ActionResult Delete(int id) 
        {
            var delcus = _Context.Customers.Find(id);
            return View (delcus);
        }
        public ActionResult DeletePost(int id) 
        {
            var deletedcus = _Context.Customers.Find(id);
            //_Context.Customers.Remove(deletedcus);
            deletedcus.IsActive = false;
            deletedcus.DeletedOn= DateTime.Now;
            deletedcus.DeletedBy = GetCurresntUserName();
            _Context.SaveChanges();
            return RedirectToAction("List", "Customers");
        }

        public ActionResult Details(int id) 
        {
            var det = _Context.Customers.Include( c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            return View(det);   
        }
        
    }
}