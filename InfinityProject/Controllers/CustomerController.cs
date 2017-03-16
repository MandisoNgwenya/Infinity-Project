using InfinityProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfinityProject.Controllers
{

    public class CustomerController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Customer
        public ActionResult Customers()
        {// list all the customers using the system 

            //list of all customers
            return View();
        }

        // GET: Customer/Details/5
      
        public ActionResult Profile(int id)
        {
            // List of all Booking made in the past
            //view individual booking status
           //link to edit profile RedirectToAction("EditProfile")
           //

            return View();
        }

        [HttpPost]
        public ActionResult Profile()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditProfile()
        {
            return View();
        }
        // POST: Customer/Create
        [HttpPost]
        public ActionResult EditProfile(UserProfile model )
        {
            try
            {
              
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

   
     
        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

   
        }
    }
