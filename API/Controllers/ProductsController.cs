using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers {
    [ApiController]
    [Route ("api/[controller]")]
    public class ProductsController : ControllerBase {

        private readonly IProductRepository _repo;

        public ProductsController (IProductRepository repo) {
            _repo = repo;

        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts () {
            var poducts = await _repo.GetProductsAsync();
            return Ok (poducts);
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<Product>> GetProduct (int id) {

            return await _repo.GetProductByIdAsync(id);  
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands () {
            var poductsBrands = await _repo.GetProductBrandsAsync();
            return Ok (poductsBrands);
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypes () {
            var poductsTypes = await _repo.GetProductTyepsAsync();
            return Ok (poductsTypes);
        }
    }
}