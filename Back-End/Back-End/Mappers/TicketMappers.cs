using Back_End.Dtos.Ticket;
using Back_End.Models;
namespace Back_End.Mappers
{
    public static class TicketMappers
    {
        public static TickeReadtDto ToDto(this Ticket ticket)
        {
            return new TickeReadtDto
            {
                Ticket_ID = ticket.Ticket_ID,
                Description = ticket.Description,
                Status = ticket.Status,
                Date = ticket.Date
            };
        }

        public static Ticket ToModel(this TickeReadtDto ticketDto)
        {
            return new Ticket
            {
                Ticket_ID = ticketDto.Ticket_ID,
                Description = ticketDto.Description,
                Status = ticketDto.Status,
                Date = ticketDto.Date
            };
        }

        public static Ticket ToModel(this TicketCreateDto ticketDto)
        {
            return new Ticket
            {
                Description = ticketDto.Description,
                Status = ticketDto.Status,
                Date = ticketDto.Date
            };
        }

        public static Ticket ToModel(this TicketUpdateDto ticketDto)
        {
            return new Ticket
            {
                Description = ticketDto.Description,
                Status = ticketDto.Status
            };
        }


        public static TicketUpdateDto ToUpdateDto(this Ticket ticket)
        {
            return new TicketUpdateDto
            {
                Description = ticket.Description,
                Status = ticket.Status
            };
        }
    }
}
