using AngularDemoF18.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDemoF18.Data
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Task<Product> GetProduct(int id);

        Task<bool> Save();
    }
}
