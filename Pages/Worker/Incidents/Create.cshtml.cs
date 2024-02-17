using IncidentManagmentDemo.Models;
using IncidentManagmentDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IncidentManagmentDemo.Pages.Worker.Incidents
{
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDBContext context;

        [BindProperty]
        public IncidentDto IncidentDto { get; set; } = new IncidentDto();
        public CreateModel(IWebHostEnvironment environment, ApplicationDBContext context)
        {
            this.environment = environment;
            this.context = context;
        }
        public void OnGet()
        {
        }
        public string errorMessage = "";
        public string successMessage = "";
        public void OnPost() {

            if (!ModelState.IsValid)
            {
                errorMessage = "Please Provide All The required Fields";
                return;
            }
            //save Image file
            string _imageName = null;
            if (IncidentDto.Image != null)
            {
                string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileName += Path.GetExtension(IncidentDto.Image!.FileName);
                string imageFullPath = environment.WebRootPath + "/incidents/" + newFileName;
                using (var stream = System.IO.File.Create(imageFullPath))
                {
                    IncidentDto.Image.CopyTo(stream);
                }
                _imageName= newFileName;
            }
            
            //save the new product in the database.
            Incident incident = new Incident()
            {
                Title = IncidentDto.Title,
                Details = IncidentDto.Details,
                Intensity = IncidentDto.Intensity,
                Location = IncidentDto.Location,
                Reported = DateTime.Now,
                Image = _imageName,
                CreatedAt = DateTime.Now,
            };

            context.Incidents.Add(incident);
            context.SaveChanges();


            //clear the form
            IncidentDto.Title = "";
            IncidentDto.Details = "";
            IncidentDto.Location = "";
            IncidentDto.Intensity = 1;
            IncidentDto.Image = null;
            ModelState.Clear();

            successMessage = "Incident Was Added Successfully";

        }
        
    }
}

