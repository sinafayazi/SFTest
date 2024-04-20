using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreService.Domain;
using StoreService.Domain.Products;

namespace StoreService.Persistence.EntityConfigurations.Products
{
    internal class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            
            #region Limmits
            builder.Property(b => b.Title)
                .HasMaxLength(Defaults.TitleLength);
            
            builder.HasIndex(x => x.Title).IsUnique();

            #endregion

            #region Relations

            
            #endregion
        }
    }
}