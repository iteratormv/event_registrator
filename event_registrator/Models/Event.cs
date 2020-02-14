using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace event_registrator.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(250)")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(1000)")]
        public string Description { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string imagePath { get; set; }
        [Required]
        public DateTime dateStart { get; set; }
        [Required]
        public DateTime dateFinish { get; set; }

        public int ownerId { get; set; }
        public virtual User User { get; set; }

        public virtual List<Visitor> Visitors { get; set; }
    }
}
