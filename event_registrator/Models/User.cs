using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace event_registrator.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(100)")]
        public string firstName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string surName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; }
        public bool canDelete { get; set; }


        public virtual List<UserInRole> userInRoles { get; set; }
        public virtual List<Status> Statuses { get; set; }
        public virtual List<Event> Events { get; set; }
//        public virtual List<Visitor> Visitors { get; set; }

    }
}
