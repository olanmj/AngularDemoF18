using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularDemoF18.Data;
using AngularDemoF18.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularDemoF18.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Products2Controller : ControllerBase
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public Products2Controller(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _repo.GetProducts();
        }

        [HttpGet("{id}")]
        public async Task<Product> GetProduct(int id)
        {
            return await _repo.GetProduct(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentProduct = await _repo.GetProduct(id);
            currentProduct.Category = product.Category;
            currentProduct.Description = product.Description;
            currentProduct.Name = product.Name;
            currentProduct.Price = product.Price;
            currentProduct.Quantity = product.Quantity;
            bool saved = await _repo.Save();
            if (saved)
            {
                return NoContent();
            }
            return BadRequest("Error saving chanages");
        }

        [HttpPut("altupdate/{id}")]
        public async Task<IActionResult> AlternateUpdateProduct(int id, ProductUpdateDTO product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentProduct = await _repo.GetProduct(id);
            _mapper.Map(product, currentProduct);
            bool saved = await _repo.Save();
            if (saved)
            {
                return NoContent();
            }
            return BadRequest("Error saving chanages");
        }
    }
}