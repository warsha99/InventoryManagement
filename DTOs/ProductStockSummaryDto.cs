namespace InventoryManagement.API.DTOs
{
    public class ProductStockSummaryDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int CurrentStock { get; set; }
    }
}
