using InfinityProject.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace InfinityProject.Controllers
{
    public class RolesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public RolesController()
        {
            db = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var Roles = db.Roles.ToList();

            return View(Roles);
        }
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);

        }
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            db.Roles.Add(Role);
            db.SaveChanges();
            return RedirectToAction("Index");

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