using Microsoft.Extensions.Logging;
using Mini.E.Store.Core.Models;
using Mini.E.Store.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mini.E.Store.Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                var curDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\..\\"));
                curDirectory = Path.Combine(curDirectory, "Mini.E.Store.Infrastructure");
                if (!context.ProductBrands.Any())
                {
                    var str = @"Data\SeedData\brands.json";
                    var path = Path.Combine(curDirectory, str);
                    var brandsData = File.ReadAllText(path);
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    foreach(var brand in brands!)
                    {
                        context.ProductBrands.Add(brand);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.ProductTypes.Any())
                {
                    var str = @"Data\SeedData\types.json";
                    var path = Path.Combine(curDirectory, str);
                    var typesData = File.ReadAllText(path);
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                    foreach (var type in types!)
                    {
                        context.ProductTypes.Add(type);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.Products.Any())
                {
                    var str = @"Data\SeedData\products.json";
                    var path = Path.Combine(curDirectory, str);
                    var productsData = File.ReadAllText(path);
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    foreach (var product in products!)
                    {
                        context.Products.Add(product);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
