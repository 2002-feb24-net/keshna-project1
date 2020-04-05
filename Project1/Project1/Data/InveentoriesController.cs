using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project1.Models;

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
