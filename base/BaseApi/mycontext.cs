using BaseApi.Model;
using Microsoft.EntityFrameworkCore;

namespace BaseApi
{
    public class mycontext:DbContext
    {
        public mycontext(DbContextOptions<mycontext>options):base(options) 
        {

        }
        public DbSet<User> UserT { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
                 new User() { address = "tehran", age = 27,id=1, name = "kananiHassan" },
            new User() { address = "Ahvaz", age = 14, id = 2, name = "Aref" },
            new User() { address = "Khorasan", age = 17, id = 3, name = "Ali" },
            new User() { address = "iran", age = 23, id = 4, name = "Mehdi" },
            new User() { address = "boujnord", age = 25, id = 5, name = "Reza" }

                );
        }
    }
}
