using Microsoft.EntityFrameworkCore;
using Mini.E.Store.Core.Models;

namespace Mini.E.Store.Infrastructure.Contexts
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
    }
}
