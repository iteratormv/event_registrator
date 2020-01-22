using event_registrator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace event_registrator.Data
{
    public class EventContext:DbContext
    {
        public EventContext(DbContextOptions options):base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> users { get; set; }
        public DbSet<Event> events { get; set; }
        public DbSet<Role> roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                new User { Id = 1, firstName = "admin", surName = "admin",
                    Password = "admin", Email = "admin@admin" }
                });
            modelBuilder.Entity<Role>().HasData(
                new Role[]
                {
                    new Role { Id = 1, Name = "superUser", canSendMail = true }
                });
            modelBuilder.Entity<UserInRole>().HasData(
                new UserInRole[]
                {
                    new UserInRole{ Id = 1, userId = 1, roleId = 1 }
                });
        }
    }
}
