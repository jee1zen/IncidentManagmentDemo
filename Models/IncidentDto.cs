using System.ComponentModel.DataAnnotations;

namespace IncidentManagmentDemo.Models
{
    public class IncidentDto
    {
        [Required]
        public string Title { get; set; } = "";
        [Required]
        public string Details { get; set; } = "";
        [Required]
        public int Intensity { get; set; }
        public IFormFile? Image { get; set; } 
        [Required]
        public string Location { get; set; } = "";
        public int Status { get; set; }
        [Required]
        public DateTime Reported { get; set; } = DateTime.Now;
    }
}
