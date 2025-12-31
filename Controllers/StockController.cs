using Microsoft.AspNetCore.Mvc;
using InventoryManagement.API.Data;
using InventoryManagement.API.DTOs;
using InventoryManagement.API.Models;

namespace InventoryManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StockController(ApplicationDbContext context)
        {
            _context = context;
        }

        // STOCK IN
        [HttpPost("in")]
        public IActionResult StockIn(StockRequestDto dto)
        {
            var productExists = _context.Products.Any(p => p.Id == dto.ProductId);
            if (!productExists)
                return NotFound("Product not found");

            var movement = new StockMovement
            {
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                Type = "IN"
            };

            _context.StockMovements.Add(movement);
            _context.SaveChanges();

            return Ok("Stock added successfully");
        }

        // STOCK OUT
        [HttpPost("out")]
        public IActionResult StockOut(StockRequestDto dto)
        {
            var productExists = _context.Products.Any(p => p.Id == dto.ProductId);
            if (!productExists)
                return NotFound("Product not found");

            var totalIn = _context.StockMovements
                .Where(s => s.ProductId == dto.ProductId && s.Type == "IN")
                .Sum(s => s.Quantity);

            var totalOut = _context.StockMovements
                .Where(s => s.ProductId == dto.ProductId && s.Type == "OUT")
                .Sum(s => s.Quantity);

            var currentStock = totalIn - totalOut;

            if (currentStock < dto.Quantity)
                return BadRequest("Not enough stock available");

            var movement = new StockMovement
            {
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                Type = "OUT"
            };

            _context.StockMovements.Add(movement);
            _context.SaveChanges();

            return Ok("Stock removed successfully");
        }

        [HttpGet("summary")]
        public IActionResult GetStockSummary()
        {
            var products = _context.Products.ToList();

            var result = products.Select(product =>
            {
                var totalIn = _context.StockMovements
                    .Where(s => s.ProductId == product.Id && s.Type == "IN")
                    .Sum(s => s.Quantity);

                var totalOut = _context.StockMovements
                    .Where(s => s.ProductId == product.Id && s.Type == "OUT")
                    .Sum(s => s.Quantity);

                return new ProductStockSummaryDto
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    CurrentStock = totalIn - totalOut
                };
            }).ToList();

            return Ok(result);
        }

        [HttpGet("summary/{productId}")]
        public IActionResult GetStockSummaryForProduct(Guid productId)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
                return NotFound("Product not found");

            var totalIn = _context.StockMovements
                .Where(s => s.ProductId == productId && s.Type == "IN")
                .Sum(s => s.Quantity);

            var totalOut = _context.StockMovements
                .Where(s => s.ProductId == productId && s.Type == "OUT")
                .Sum(s => s.Quantity);

            var result = new ProductStockSummaryDto
            {
                ProductId = product.Id,
                ProductName = product.Name,
                CurrentStock = totalIn - totalOut
            };

            return Ok(result);
        }
    }
}
