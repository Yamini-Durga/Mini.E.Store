using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mini.E.Store.Core.Models;
using Mini.E.Store.Infrastructure.Contexts;

namespace Mini.E.Store.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _context.Product.ToListAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _context.Product.FindAsync(id);
        }
    }
}
