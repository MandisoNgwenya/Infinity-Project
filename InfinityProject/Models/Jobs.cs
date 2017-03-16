using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InfinityProject.Models
{
    public class TechTask
    {
        [Key]
        public int TID { get; set; }
        public DateTime Date { get; set; }
        public int JobCardNumber { get; set; }
        public string ContactNumber { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public double Deposit { get; set; }
        public double Balance { get; set; }
        public double Total { get; set; }
        public ICollection<BookingViewModels> BookingViewModel { get; set; }
    }
}