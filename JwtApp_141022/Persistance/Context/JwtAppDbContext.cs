using JwtApp_141022.Core.Domain;
using JwtApp_141022.Persistance.Configuration;
using Microsoft.EntityFrameworkCore;

namespace JwtApp_141022.Persistance.Context
{
    public class JwtAppDbContext : DbContext
    {
        public JwtAppDbContext(DbContextOptions<JwtAppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
        public DbSet<Product> Products
        {
            get
            {
                return this.Set<Product>();
            }
        }
        public DbSet<Category> Categories
        {
            get
            {
                return this.Set<Category>();
            }
        }
        public DbSet<AppUser> AppUsers
        {
            get
            {
                return this.Set<AppUser>();

            }
        }
        public DbSet<AppRole> AppRoles { get { return this.Set<AppRole>(); } }
    }
}

