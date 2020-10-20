using ACGMapping.Models;
using Microsoft.EntityFrameworkCore;

namespace ACGMapping.InfraStructure.DB
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
            
        }

        public DbSet<ACGMappingTable> ACGMappingTable { get; set; } 
        public DbSet<ACGBasicIntroductionTable> ACGBasicIntroductionTable { get; set; }
    }
}