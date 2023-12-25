using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mrp.Dto;
using mrp.Interfaces;
using mrp.Models;

namespace mrp.Controllers
{
    [Route("mrp/[controller]")]
    [ApiController]
    public class MaterialController : Controller
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;
        public MaterialController(IMaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<MaterialDto>))]
        public IActionResult GetMaterials()
        {
            var materials = _mapper.Map<List<MaterialDto>>(_materialRepository.GetAll());
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(materials);
        }
    }
}
