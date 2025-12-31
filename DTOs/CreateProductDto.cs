using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.API.DTOs
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; }

        public string SKU { get; set; }

        [Range(1, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
