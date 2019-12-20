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
        public int IventId { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(100)")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(512)")]
        public string Description { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string ImagePath { get; set; }
    }
}
