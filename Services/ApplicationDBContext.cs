using IncidentManagmentDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace IncidentManagmentDemo.Services
{
    public class ApplicationDBContext :DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Incident> Incidents { get; set; }

    }
}
