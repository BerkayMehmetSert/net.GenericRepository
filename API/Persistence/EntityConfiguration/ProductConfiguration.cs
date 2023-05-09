using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Persistence.EntityConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products").HasKey(x => x.Id);
            builder.Property(x=>x.CreatedAt).IsRequired();
            builder.Property(x=>x.LastModifiedAt).IsRequired(false);
            builder.Property(x=>x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x=>x.Description).IsRequired().HasMaxLength(255);
            builder.Property(x=>x.Price).IsRequired();
            builder.Property(x => x.CategoryId);
            builder.HasOne(x => x.Category)
                .WithMany(x=>x.Products)
                .HasForeignKey(x=>x.CategoryId);
        }
    }
}
