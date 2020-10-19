using ACGMapping.Models;
using Microsoft.EntityFrameworkCore;

namespace ACGMapping.Controllers
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
            
        }

        public DbSet<ACGInfoModel> AnimeTable { get; set; } 
    }
}