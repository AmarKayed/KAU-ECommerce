using ECommerce.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.DAL.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public ProductConfiguration() { }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("ecommerce_products");
            builder.HasKey(our_database_object => our_database_object.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("product_name");
            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");


            builder.Property(p => p.Description)
                .HasMaxLength(500);

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
