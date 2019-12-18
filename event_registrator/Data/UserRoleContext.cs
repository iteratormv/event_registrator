using event_registrator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace event_registrator.Data
{
    public class UserRoleContext:DbContext
    {
        public UserRoleContext(DbContextOptions options):base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<UserRole> userRoles { get; set; }
    }
}
