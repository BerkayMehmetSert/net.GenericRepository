using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Persistence.EntityConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories").HasKey(x => x.Id);
            builder.Property(x=>x.CreatedAt).IsRequired();
            builder.Property(x=>x.LastModifiedAt).IsRequired(false);
            builder.Property(x=>x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x=>x.Description).IsRequired().HasMaxLength(255);
        }
    }
}
