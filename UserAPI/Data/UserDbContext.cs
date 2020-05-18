using Microsoft.EntityFrameworkCore;
using UserAPI.Models;

namespace UserAPI.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasData(
        //        new User
        //        {
        //            Name = "John",
        //            Age = 23,
        //            Email = "john.doe@google.com",
        //            UserId = 1
        //        },
        //        new User
        //        { 
        //            Name = "John2", Age = 22, Email = "john.doe2@google.com", UserId = 2 
        //        }
        //    );
        //}
    }
}
