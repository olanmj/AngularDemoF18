using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularDemoF18.Models;

namespace AngularDemoF18.Data
{
    public class TestProductRepository : IProductRepository
    {
        private static Product[] Products = new Product[] {
            new Product{ProductID = 1, Name = "Product 1", Description = "First product",
            Price = 10M, Quantity = 25, Category = "Misc"},
            new Product{ProductID = 2, Name = "Product 2", Description = "Second product",
            Price = 5M, Quantity = 6, Category = "Misc"}
            };
        public async Task<Product> GetProduct(int id)
        {
            return Products.First(p => p.ProductID == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return Products;
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }
    }
}
