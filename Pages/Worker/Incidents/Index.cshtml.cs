using IncidentManagmentDemo.Models;
using IncidentManagmentDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IncidentManagmentDemo.Pages.Worker.Incidents
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext context;

        public List<Incident> Incidents { get; set; } = new List<Incident>();

        public IndexModel(ApplicationDBContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            Incidents = context.Incidents.OrderByDescending(i=>i.Id).ToList();
        }
    }
}
