using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace event_registrator.Models
{
    public class UserRole
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(100)")]
        public string RoleName { get; set; }

    }
}
