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
        public int UserId { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(100)")]
        public string UserEmail { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string UserPassword { get; set; }
    }
}
