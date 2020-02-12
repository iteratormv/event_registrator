using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace event_registrator.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(100)")]
        public string Name { get; set; }
        [Required]
        public bool canSendMail { get; set; }
        [Required]
        public bool canAdministrate { get; set; }
        [Required]
        public bool canDelete { get; set; }

        public bool canCreateEvent { get; set; }

        public bool canEditCategory { get; set; }
        public bool canCreateCategory { get; set; }
        public bool canDeleteCategory { get; set; }

        public bool canEditPaymentStatus { get; set; }

        public bool canEditRole { get; set; }
        public bool canCreateRole { get; set; }
        public bool canDeleteRole { get; set; }

        public virtual List<UserInRole> userInRoles { get; set; }

    }
}
