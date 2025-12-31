using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.API.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string SKU { get; set; }

        public decimal Price { get; set; }
    }
}
