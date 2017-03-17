using System.ComponentModel.DataAnnotations;

namespace InfinityProject.Models
{
    public class StatusModel
    {
        [Key]
        public int status { get; set; }
        public string statusName { get; set; }
    }
}