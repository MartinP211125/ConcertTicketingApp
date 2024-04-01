
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Entities.Entities
{
    public class TicketInOrderConfig : IEntityTypeConfiguration<TicketInOrder>
    {
        public void Configure(EntityTypeBuilder<TicketInOrder> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Ticket)
                .WithMany(x => x.TicketsInOrder)
                .HasForeignKey(x => x.TicketId);
            builder.HasOne(x => x.Order)
                .WithMany(x => x.TicketsInOrder)
                .HasForeignKey(x => x.OrderId);
        }
    }
}
