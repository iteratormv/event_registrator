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
        [Column(TypeName = "nvarchar(100)")]
        public DateTime imagePath { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public DateTime dateStart { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string dateFinish { get; set; }
    }
}
