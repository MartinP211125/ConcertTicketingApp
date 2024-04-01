
using Ardalis.GuardClauses;
using Core.Entities.Entities;
using Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Persistence.Data.Context;
using System;
using System.Linq.Expressions;
using System.Net.Sockets;

namespace Persistence.Data.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ConcertDbContext _context;
        public TicketRepository(ConcertDbContext concert)
        {
            _context = concert;
        }
        public Ticket Add(Ticket ticket)
        {
            Guard.Against.Null(ticket, nameof(ticket));

            ticket.DateCreated = DateTime.UtcNow;
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
            return ticket;
        }

        public IEnumerable<Ticket> AddRange(IEnumerable<Ticket> tickets)
        {
            Guard.Against.Null(tickets, nameof(tickets));

            _context.Tickets.AddRange(tickets);
            _context.SaveChanges() ;
            return tickets;
        }

        public void Delete(Guid id)
        {
            var ticket = _context.Tickets.FirstOrDefault(x => x.Id == id);
            Guard.Against.Null(ticket, nameof(ticket));

            _context.Tickets.Remove(ticket);
            _context.SaveChanges();
        }

        public void DeleteRange(IEnumerable<Ticket> tickets)
        {
            Guard.Against.Null(tickets, nameof(tickets));

            _context.Tickets.RemoveRange(tickets);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Ticket>> Find(Expression<Func<Ticket, bool>> expression)
        {
            var tickets = await _context.Tickets.Where(expression).ToListAsync();
            return tickets;
        }

        public async Task<Ticket> Get(Guid id)
        {
            return await _context.Tickets.FindAsync(id);
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            return await _context.Tickets.ToListAsync();
        }

        public Ticket Update(Ticket ticket, Guid id)
        {
            var entity = _context.Tickets.FirstOrDefault(x => x.Id == id);
            Guard.Against.Null(ticket, nameof(ticket));
            Guard.Against.Null(entity, nameof(entity));

            ticket.LastUpdated = DateTime.UtcNow;
            _context.Entry(entity).CurrentValues.SetValues(ticket);
            _context.SaveChanges();
            return entity;
        }
    }
}
