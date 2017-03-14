using InfinityProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfinityProject.Controllers
{
    public class Quotation : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Quotation
        public ActionResult Index()
        {
            // when  the clerk views this page it returns nothing  
            // there is a textbox and a search  button where a clerk inserts ID number
            //ID number searches and returns customer booking linked to that number '
            //click on create quote 
            //retirect to create quote
            //filter beweetn finished pending and finished
            return View();

        }


        public ActionResult NewQuote()
        {
           
            //Take the details for all user booking then assin them to textboxt
            //BookingsModel (table) Quotation (table) //customer(table) Technians
            //allocate technician 
            //add device accessories
            //



            return View();
        }

        //public ActionResult FinishQuote()
        //{
        //    //search job
        //    // 
        //    //technician enters fault disc
        //    //enters total
        //    //enter depoit amount
        //    //calculate balance
        //    //send confirmation email & sms 
        //    //update status
            

        //}
        
        //public ActionResult CloseJob()
        //{

        //    //close job 
        //}
        //technician

    }
}
