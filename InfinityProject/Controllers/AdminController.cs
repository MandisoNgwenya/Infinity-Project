using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using InfinityProject.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace InfinityProject.Controllers
{
    public class AdminController : Controller
    {
       
        //GET: Admin
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateRole(string roleName)
        {
            Roles.CreateRole(roleName);
            return View();
        }
        [HttpGet]
        public ActionResult AddUserRole()
        {

            return View();
        }


        [HttpPost]
        public ActionResult AddUserRole(string user)
        {
            Roles.AddUserToRole(user, "Admin");
            return View("Index");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult AdminPanel()
        {
            return View();
        }

    }
}
//controller
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
////using MvcRoles.Models;//add
//using Microsoft.AspNet.Identity.EntityFramework; //add
//using InfinityProject.Models;

//namespace MvcRoles.Controllers
//{
//    public class AdminController : Controller
//    {
//        private ApplicationDbContext context = new ApplicationDbContext();
//        // GET: Roles
//        public ActionResult Index()
//        {
//            return View(context.Roles.ToList());
//        }

//        public ActionResult Create()
//        {


//            return View();
//        }
//        [HttpPost]
//        public ActionResult CreateRole(FormCollection collection)
//        {
//            try
//            {
//                context.Roles.Add(new IdentityRole()
//                {
//                    Name = collection["RoleName"]
//                });
//                context.SaveChanges();
//                ViewBag.ResultMessage = "Role created successfully !";
//                return View("Create");
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        public ActionResult Delete(string RoleName)
//        {
//            var thisRole = context.Roles.Where(r => r.Name.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
//            context.Roles.Remove(thisRole);
//            context.SaveChanges();
//            return RedirectToAction("Create");
//        }

//        //
//        // GET: /Roles/Edit/5
//        public ActionResult Edit(string roleName)
//        {
//            var thisRole = context.Roles.Where(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

//            return View(thisRole);
//        }

//        //
//        // POST: /Roles/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(Microsoft.AspNet.Identity.EntityFramework.IdentityRole role)
//        {
//            try
//            {
//                context.Entry(role).State = System.Data.Entity.EntityState.Modified;
//                context.SaveChanges();

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }
//    }
//}