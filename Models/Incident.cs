using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace IncidentManagmentDemo.Models
{
    public class Incident
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Details { get; set; } = "";
        public int Intensity { get; set; } 
        public string Image { get; set; } = "";
        public string Location { get; set; } = "";
        public int Status { get; set; }
        public DateTime Reported { get; set; }
        public DateTime CreatedAt { get; set; }

		internal object Tolist()
		{
			throw new NotImplementedException();
		}
	}
}
