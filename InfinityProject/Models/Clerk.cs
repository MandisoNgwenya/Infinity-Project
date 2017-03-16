using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InfinityProject.Models
{
    public class Clerk
    {
        [Key]
        public int IdCl { get; set; }

        // public string Job_Card { get; set; }

        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Gender { get; set; }
        public DateTime Date_OF_Bith { get; set; }
        public string Address { get; set; }
        public string Contact_nfo { get; set; }
        public string email { get; set; }
        public string User_Name { get; set; }

        public BookingViewModels bookingViewModel { get; set; }

    }
}