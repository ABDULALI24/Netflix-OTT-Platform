using NetFlixPrac.EF;
using NetFlixPrac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetFlixPrac.Controllers
{
    public class MembeshipTypesController : OTTController
    {
        private readonly MyContext _context;
        public MembeshipTypesController()
        {
            _context = new MyContext();
        }

        public ActionResult List()
        {
            var list = _context.MembershipTypes.Where( m => m.IsActive == true).ToList();
            return View(list);
        }


        public ActionResult Create() { return View();}
       
        public ActionResult Edit(int id) 
        {
            var edited = _context.MembershipTypes.Find(id);
            return View(edited);
        }

        public ActionResult Save(MembershipType membership) 

        { 
            if (!ModelState.IsValid) 
            {
                return View(membership);
            }
            if (membership.Id == 0) 
            {
                _context.MembershipTypes.Add(membership);
                membership.CreatedOn = DateTime.Now;
                membership.CreatedBy = GetCurresntUserName();
                
            }
            else
            {
                var updatedmembership = _context.MembershipTypes.Find(membership.Id);
                TryUpdateModel(updatedmembership);
                membership.UpdatedOn = DateTime.Now;
                membership.UpdatedBy= GetCurresntUserName();
            }

            _context.SaveChanges();

            return RedirectToAction("List", "MembeshipTypes");

          
        }


        public ActionResult Delete(int id) 
        {
            var delcus = _context.MembershipTypes.Find(id);
            return View(delcus);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id) 
        {
            var deletedmem = _context.MembershipTypes.Find(id);

            deletedmem.IsActive= false;
            deletedmem.DeletedBy = GetCurresntUserName();
            deletedmem.DeletedOn = DateTime.Now;    
            _context.SaveChanges();


            return RedirectToAction("List", "MembeshipTypes"); 
        }
    }
}