
using Core.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.ShoppingCart)
                .WithOne(x => x.Owner)
                .HasForeignKey<User>(x => x.ShoppingCartId);
            builder.HasOne(x => x.Order)
                .WithOne(x => x.Owner)
                .HasForeignKey<User>(x =>x.OrderId);
            builder.Property(x => x.Email)
                .IsRequired();
            builder.Property(x => x.Password)
                .IsRequired();
        }
    }
}
