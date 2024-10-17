using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_End.Models
{
    [Table("Tickets")]
    public class Ticket
    {
        [Key]
        public int Ticket_ID { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Status { get; set; } = "Open";

        [Required]
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
