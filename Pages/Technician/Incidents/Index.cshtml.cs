using IncidentManagmentDemo.Models;
using IncidentManagmentDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace IncidentManagmentDemo.Pages.Technician.Incidents
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext context;

        public List<Incident> Incidents { get; set; } = new List<Incident>();
		public IncidentDto IncidentDto { get; set; } = new IncidentDto();

		public IndexModel(ApplicationDBContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            Incidents = context.Incidents.Where(i=>i.Status<3).OrderByDescending(i=>i.Id).ToList();
        }
		public async Task<IActionResult> OnPostInvestigationClicked()
		{
            Console.WriteLine("came here");
            // Perform action specific to investigation 
           int _id = int.Parse(Request.Form["Id"]);
           
            var _incident=context.Incidents.Find(_id);
            _incident.Status += 1;
            await context.SaveChangesAsync();


			return RedirectToPage("/Technician/Incidents/Index"); // Redirect to the same page
		}
	}
}
