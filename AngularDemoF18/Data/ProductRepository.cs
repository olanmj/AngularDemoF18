using AngularDemoF18.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDemoF18.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly AngularDemoF18Context _context;

        public ProductRepository(AngularDemoF18Context context)
        {
            _context = context;
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _context.Product.FindAsync(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Product;
        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
