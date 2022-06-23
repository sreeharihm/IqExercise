using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Name = "John",
                Desgination = "Test Engineer",
                Address = "test1",
                JoiningDate = new DateTime(2012, 04, 25),
                Country = "India",
                ImagePath = "",
                Guid = Guid.NewGuid(),
                Street = "",
                State = "",
                City = "",
                PinCode = "",
                CreateDate = DateTime.Now,

            }, new User
            {
                Id = 2,
                Name = "Luther",
                Desgination = "PMO",
                Address = "test1",
                JoiningDate = new DateTime(2019, 09, 12),
                Country = "India",
                ImagePath = "",
                Guid = Guid.NewGuid(),
                Street = "",
                State = "",
                City = "",
                PinCode = "",
                CreateDate = DateTime.Now,
            });
        }
    }
}
