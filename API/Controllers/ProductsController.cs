using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class ProductsController : BaseApiController {

        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController (IGenericRepository<Product> productRepo,
            IGenericRepository<ProductBrand> productBrandRepo,
            IGenericRepository<ProductType> productTypeRepo,
            IMapper mapper
        ) {
            _productTypeRepo = productTypeRepo;
            _mapper = mapper;
            _productRepo = productRepo;
            _productBrandRepo = productBrandRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductToReturnDTO>>> GetProducts () {

            var spec = new ProductWithTypesAndBrandsSpecification();
            var products = await _productRepo.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDTO>>(products)); /* products.Select(product => new ProductToReturnDTO{
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                PictureUrl = product.PictureUrl,
                ProductBrand = product.ProductBrand.Name,
                ProductType = product.ProductType.Name
            }).ToList(); */
        }

        [HttpGet ("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDTO>> GetProduct (int id) {
            var spec = new ProductWithTypesAndBrandsSpecification(id);
            var product = await _productRepo.GetEntityWithSpec(spec);

            if(product == null)
            return NotFound(new ApiResponse(404));
            return _mapper.Map<Product, ProductToReturnDTO>(product);
            /* new ProductToReturnDTO{
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                PictureUrl = product.PictureUrl,
                ProductBrand = product.ProductBrand.Name,
                ProductType = product.ProductType.Name

            }; */
        }

        [HttpGet ("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands () {
            var poductsBrands = await _productBrandRepo.ListAllAsync();
            return Ok (poductsBrands);
        }

        [HttpGet ("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypes () {
            var poductsTypes = await _productTypeRepo.ListAllAsync();
            return Ok (poductsTypes);
        }
    }
}