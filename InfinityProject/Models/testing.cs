using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InfinityProject.Models
{
    public class testing
    {
        [Key]
        public int Id { get; set; }
        public string Job_Card { get; set; }
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public double Deposit { get; set; }
        public double Total { get; set; }
        public double Balance { get; set; }
        public string IDNumber { get; set; }
        //public string technician { get; set; }
        public string Accessories { get; set; }
        public string status { get; set; }
        public string email { get; set; }

        public int SelectedTechId { get; set; }
        public List<Technician> technicians { get; set; }
        public Technician technician { get; set; }
        public int selectedBookingID { get; set; }
        public List<BookingViewModels> bookings { get; set; }
        public BookingViewModels booking { get; set; }
    }
}