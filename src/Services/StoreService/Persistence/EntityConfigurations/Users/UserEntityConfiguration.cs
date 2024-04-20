using StoreService.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StoreService.Persistence.EntityConfigurations.Users
{
    internal class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            #region Limmits


            #endregion

            #region Relations

            builder.HasMany(x =>x.Orders)
                .WithOne(x => x.Buyer)
                .HasForeignKey(x => x.BuyerId);

            #endregion
        }
    }
}