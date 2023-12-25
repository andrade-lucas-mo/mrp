using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mrp.Dto;
using mrp.Interfaces;
using mrp.Models;
using mrp.Repository;

namespace mrp.Controllers
{
    [Route("mrp/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet("{productId}")]
        [ProducesResponseType(200, Type = typeof(ProductCascadeDto))]
        [ProducesResponseType(400)]
        public IActionResult GetExplosion(int productId)
        {
            if(!_productRepository.HasAny(productId)){
                return NotFound();
            }

            var product = _mapper.Map<ProductDto>(_productRepository.Get(productId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productCascade = _mapper.Map<ProductCascadeDto>(product);
            return Ok(productCascade);
        }
    }
}
