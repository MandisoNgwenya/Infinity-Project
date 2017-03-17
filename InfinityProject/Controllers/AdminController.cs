using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace InfinityProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
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