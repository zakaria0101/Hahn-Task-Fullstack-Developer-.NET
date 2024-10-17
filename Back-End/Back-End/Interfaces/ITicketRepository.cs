using Back_End.Helpers;
using Back_End.Models;
namespace Back_End.Interfaces
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAllTickets(QueryObject query);
        Task<Ticket?> GetTicketById(int id);
        Task CreateTicket(Ticket ticket);
        Task UpdateTicket(Ticket ticket);
        Task DeleteTicket(Ticket ticket);
        Task<bool> SaveChangesAsync();
    }
}
