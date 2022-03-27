using DB.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class PetStoreContext : IdentityDbContext
    {
        public DbSet<PetEntity> Pets { get; set; }
        public DbSet<PhotoEntity> Photos { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }

        public PetStoreContext(DbContextOptions o) : base(o) 
        {
        }
    }
}