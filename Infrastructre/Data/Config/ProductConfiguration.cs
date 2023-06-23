using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructre.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Access individual Property of the entity
            builder.Property(n => n.Name).IsRequired().HasMaxLength(100);
            builder.Property(d=>d.Description).IsRequired().HasMaxLength(300);
            builder.Property(p=>p.Price).HasColumnType("decimal(18,2)");
            builder.Property(url => url.PictureUrl).IsRequired().HasMaxLength(500);
            builder.HasOne(pb => pb.productBrand).WithMany().HasForeignKey(i => i.ProductBrandId);
            builder.HasOne(pt => pt.productType).WithMany().HasForeignKey(i => i.ProductTypeId);
        }
    }
}
