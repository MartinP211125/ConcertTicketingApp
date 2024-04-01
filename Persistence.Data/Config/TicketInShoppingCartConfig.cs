
using Core.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config
{
    public class TicketInShoppingCartConfig : IEntityTypeConfiguration<TicketInShoppingCart>
    {
        public void Configure(EntityTypeBuilder<TicketInShoppingCart> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasOne(x => x.Ticket)
                .WithMany(x => x.TicketsInShoppingCart)
                .HasForeignKey(x => x.TicketId);
            builder.HasOne(x => x.ShoppingCart)
                .WithMany(x => x.TicketsInShoppingCart)
                .HasForeignKey(x => x.ShoppingCartId);
        }
    }
}
