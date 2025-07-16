using ECommerce.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.DAL.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category> 
    {
        
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("category_name");

            // Reduntant, but can be useful for clarity
            builder.HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
