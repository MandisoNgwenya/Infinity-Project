using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfinityProject.Models
{
    public class BookingViewModels
    {
        [Key]
        public int BookingID { get; set; }

        [Display(Name = "Name")]
        public string cName { get; set; }
        [Display(Name = "Surname")]
        public string cSurname { get; set; }
        [Display(Name = "ID Number")]
        public string IDNumber { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Cell:No")]
        public string TelNo { get; set; }

        [Display(Name = "Device")]
        public string Device { get; set; }
        [Display(Name = "Date")]
        public string Date{ get; set; }
        public string Clerk { get; set; }
        public string Technician { get; set; }
        public string JobCard { get; set; }

        public string Id { get; set; }
        [ForeignKey("Id")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}