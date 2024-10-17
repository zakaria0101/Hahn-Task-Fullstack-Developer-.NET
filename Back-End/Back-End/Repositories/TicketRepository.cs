using Back_End.Data;
using Back_End.Helpers;
using Back_End.Interfaces;
using Back_End.Models;
using Microsoft.EntityFrameworkCore;

namespace Back_End.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDBContext _context;

        public TicketRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ticket>> GetAllTickets(QueryObject query)
        {
            var tickets = _context.Ticket.AsQueryable();
            var skipNumber = (query.PageNumber - 1) * query.PageSize;
            return await tickets.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Ticket?> GetTicketById(int id)
        {
            return await _context.Ticket.FindAsync(id);
        }

        public async Task CreateTicket(Ticket ticket)
        {
            if (ticket == null) {
                throw new ArgumentNullException(nameof(ticket));
            }

            await _context.Ticket.AddAsync(ticket);
        }

        public Task UpdateTicket(Ticket ticket)
        {
            _context.Ticket.Update(ticket);
            return Task.CompletedTask;
        }

        public Task DeleteTicket(Ticket ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException(nameof(ticket));
            }
            _context.Ticket.Remove(ticket);
            return Task.CompletedTask;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
