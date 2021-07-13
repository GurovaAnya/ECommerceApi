using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ECommerceApi.Models
{
    public class ECommerceDbContext: DbContext
    {
        public ECommerceDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {}
        
        public DbSet<Item> Items { get; set; }
    }
}