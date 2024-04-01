
using Core.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config
{
    public class TicketConfig : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
           builder.HasKey(t => t.Id);
            builder.HasOne(x => x.Concert)
                 .WithMany(x => x.Tickets)
                 .HasForeignKey(x => x.ConcertId);
        }
    }
}
