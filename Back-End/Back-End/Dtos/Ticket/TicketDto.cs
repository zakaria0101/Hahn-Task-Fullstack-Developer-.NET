using System.ComponentModel.DataAnnotations;

namespace Back_End.Dtos.Ticket
{
    public class TickeReadtDto
    {
        public int Ticket_ID { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = "Open";
        public DateTime Date { get; set; } = DateTime.Now;
    }

    public class TicketCreateDto
    {
        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [AllowedValues("Open", "Closed", ErrorMessage = "Status value must be either 'Open' or 'Closed'!")]
        public string Status { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }

    public class TicketUpdateDto
    {
        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        [AllowedValues("Open", "Closed", ErrorMessage = "Status value must be either 'Open' or 'Closed'!")]
        public string Status { get; set; } = "Open";
    }
}
