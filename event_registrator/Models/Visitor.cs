using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace event_registrator.Models
{
    public class Visitor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string firstName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string surName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }



        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string barCode { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string currentStatus { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string paymentStatus { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Category { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Company { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string jobTitle { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string addedInformation1 { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string addedInformation2 { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string addedInformation3 { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string addedInformation4 { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string addedInformation5 { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string addedInformation6 { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string addedInformation7 { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string addedInformation8 { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string addedInformation9 { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string addedInformation10 { get; set; }


        //     public int userId { get; set; }
              public int eventId { get; set; }

        //       public virtual User User { get; set; }
              public virtual Event Event { get; set; }

        public virtual List<Status> Statuses { get; set; }
    }
}
