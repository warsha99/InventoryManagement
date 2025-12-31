using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.API.DTOs
{
    public class StockRequestDto
    {
        [Required]
        public Guid ProductId { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
