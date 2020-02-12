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
        public DbSet<UserInRole> userInRoles { get; set; }
        public DbSet<Status> statuses { get; set; }
        public DbSet<Visitor> visitors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                new User { Id = 1, firstName = "admin", surName = "admin", Password = "admin", Email = "admin@admin", canDelete = true },
                new User { Id = 2, firstName = "guest", surName = "guest", Password = "guest", Email = "guest@guest", canDelete = false }
                });

            modelBuilder.Entity<Role>().HasData(
                new Role[]
                {
                    new Role
                    { Id = 1, Name = "superUser",
                        canSendMail = true,
                        canAdministrate = true,
                        canDelete = false,
                        canCreateEvent = true,
                        canCreateCategory = true,
                        canEditCategory = true,
                        canDeleteCategory = true,
                        canEditPaymentStatus = true,
                        canCreateRole = true,
                        canEditRole = true,
                        canDeleteRole = true },
                    new Role
                    { Id = 2, Name = "guest",
                        canSendMail = false,
                        canAdministrate = false,
                        canDelete = false,
                        canCreateEvent = false,
                        canCreateCategory = false,
                        canEditCategory = false,
                        canDeleteCategory = false,
                        canEditPaymentStatus = false,
                        canCreateRole = false,
                        canEditRole = false,
                        canDeleteRole = false },
                                        new Role
                    { Id = 3, Name = "registredUser",
                        canSendMail = false,
                        canAdministrate = false,
                        canDelete = false,
                        canCreateEvent = true,
                        canCreateCategory = false,
                        canEditCategory = false,
                        canDeleteCategory = false,
                        canEditPaymentStatus = false,
                        canCreateRole = false,
                        canEditRole = false,
                        canDeleteRole = false },
                    new Role
                    { Id = 4, Name = "eventOwner",
                        canSendMail = true,
                        canAdministrate = false,
                        canDelete = false,
                        canCreateEvent = true,
                        canCreateCategory = false,
                        canEditCategory = true,
                        canDeleteCategory = false,
                        canCreateRole = true,
                        canEditRole = false,
                        canDeleteRole = false,
                        canEditPaymentStatus = true},
                    new Role
                    { Id = 5, Name = "eventVisitor",
                        canSendMail = false,
                        canAdministrate = false,
                        canDelete = false,
                        canCreateEvent = false,
                        canCreateCategory = false,
                        canEditCategory = false,
                        canDeleteCategory = false,
                        canCreateRole = false,
                        canEditRole = false,
                        canDeleteRole = false,
                        canEditPaymentStatus = false
                    }
                });
            modelBuilder.Entity<UserInRole>().HasData(
                new UserInRole[]
                {
                    new UserInRole{ Id = 1, userId = 1, roleId = 1 },
                    new UserInRole{ Id = 2, userId = 2, roleId = 2 }
                });
        }

        //     public DbSet<event_registrator.Models.UserInRole> UserInRole { get; set; }
    }
}
