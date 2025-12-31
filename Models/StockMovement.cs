using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.API.Models
{
    public class StockMovement
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Type { get; set; } // "IN" or "OUT"

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
