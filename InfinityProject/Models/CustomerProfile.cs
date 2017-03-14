using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InfinityProject.Models
{
    public class CustomerProfile
    {
        [Key]
        public int Id { get; set; }
    }
}