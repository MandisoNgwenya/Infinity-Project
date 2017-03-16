//using InfinityProject.Models;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace InfinityProject.Controllers
//{
//    public class Employees : Controller
//    {
//        ApplicationDbContext db = new ApplicationDbContext();
//        //public Employees() : this(new UserManager<ApplicationUser>
//        //    (new UserStore<ApplicationUser>(new ApplicationDbContext()),
//        //new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext())), new Employee())
//        //{

//        //}

//        // GET: Employees
//        public ActionResult Index(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)
//        {
//     //       userManager.UserValidator = new UserValidator<ApplicationUser>(UserManager);
//     //UserManager =userManager;
//     //       Microsoft.AspNet.Identity.RoleManager = roleManager;



//            return View();
//        }

//        public ActionResult Register(RegEmployees model)
//        {
//            var password = "12345";

//            var user = new ApplicationUser
//            {
//                UserName = model.Email,
//                Email = model.Email,

//                UserProfile = new Employee
//                {

//                    UserProfileId = model.UserProfileId,
//                    ContactNumber = model.ContactNumber,
//                    Email = model.Email,
//                    Name = model.Name,
//                    Surname = model.Surname,
//                    Gender = model.Gender,
//                    IdentityNumber = model.IdentityNumber,
//                    Role = model.Role

//                }

//            };
//            //var result =
//            if (result.Succeded)
//            {
//                if (!RoleManager.RoleExists(model.Role))
//                {
//                    RoleManager.Create(new IdentityRole() { Name = model.Role });

//                }
//                UserManager.AddToRRole(user.Id, model.Role);
//            }
//            return View();
//        }

//        // GET: Employees/Details/5
//        public ActionResult Details(int id)
//        {
//            return View();
//        }

//        // GET: Employees/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Employees/Create
//        [HttpPost]
//        public ActionResult Create(FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add insert logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: Employees/Edit/5
//        public ActionResult Edit(int id)
//        {
//            return View();
//        }

//        // POST: Employees/Edit/5
//        [HttpPost]
//        public ActionResult Edit(int id, FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add update logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: Employees/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }

//        // POST: Employees/Delete/5
//        [HttpPost]
//        public ActionResult Delete(int id, FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add delete logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }
//    }
//}
