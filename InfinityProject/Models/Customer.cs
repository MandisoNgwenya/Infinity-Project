using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InfinityProject.Models
{
    public class Customer
    {
        [Key]
        public int customerID { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string IDNumber { get; set; }
        public string Address { get; set; }
        public string TelNo { get; set; }

        public string Device { get; set; }
        public string status { get; set; }
        public string Id { get; set; }
        [ForeignKey("Id")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}