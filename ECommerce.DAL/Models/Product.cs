using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.DAL.Models
{
    [Table("ecommerce_products")]
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(100)]
        [Column("product_name")]
        public string Name { get; set; }
        
        public decimal Price { get; set; }

        [NotMapped]
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
