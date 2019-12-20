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
        public DbSet<UserRole> userRoles { get; set; }
    }
}
