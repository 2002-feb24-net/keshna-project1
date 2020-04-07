
using Microsoft.EntityFrameworkCore;


namespace Project1.Controllers
{
    public class InveentoriesController : DbContext
    {
        public InveentoriesController (DbContextOptions<InveentoriesController> options)
            : base(options)
        {
        }

        public DbSet<Project1.Models.InventoryModel> InventoryModel { get; set; }
    }
}
