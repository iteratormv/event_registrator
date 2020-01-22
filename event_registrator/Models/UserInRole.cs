using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace event_registrator.Models
{
    public class UserInRole
    {
        [Key]
        public int Id { get; set; }

        public int userId { get; set; }
        public int roleId { get; set; }

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }


    }
}
