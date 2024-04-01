
using Core.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config
{
    public class ConcertConfig : IEntityTypeConfiguration<Concert>
    {
        public void Configure(EntityTypeBuilder<Concert> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ConcertName)
                .IsRequired();
            builder.Property(x => x.ConcertImage)
                .IsRequired();
            builder.Property(x => x.ConcertRaiting)
                .IsRequired();
        }
    }
}
