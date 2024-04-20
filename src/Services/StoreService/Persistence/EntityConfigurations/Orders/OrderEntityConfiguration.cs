using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreService.Domain.Orders;

namespace StoreService.Persistence.EntityConfigurations.Orders
{
    internal class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            
            #region Limmits
            

            #endregion

            #region Relations
            
            builder.HasOne(x =>x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId);
            
            builder.HasOne(x => x.Buyer)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.BuyerId);

            #endregion
        }
    }
}