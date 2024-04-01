using Core.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence.Data.Context
{
    public class ConcertDbContext : DbContext
    {
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketInOrder> TicketsInOrder { get; set; }
        public DbSet<TicketInShoppingCart> TicketsInShoppingCart { get;set; }
        public DbSet<User> Users { get; set; }

        public ConcertDbContext(DbContextOptions<ConcertDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
