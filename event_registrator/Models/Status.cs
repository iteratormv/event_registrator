using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace event_registrator.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [Required]
        public DateTime StatusTime { get; set; }

        public int userId { get; set; }
        public int visitorId { get; set; }

        public virtual User User { get; set; }
        public virtual Visitor Visitor { get; set; }
    }
}
