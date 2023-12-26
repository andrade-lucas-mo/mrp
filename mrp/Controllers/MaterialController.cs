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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult CreateMaterial([FromQuery] int qtd, [FromQuery] int idProduct, [FromQuery] int idMaterialFather, [FromBody] MaterialDto materialDto)
        {
            if(materialDto == null || idProduct == null)
            {
                return BadRequest(ModelState);
            }

            var materialsAlredyExist = _materialRepository.GetAll().Where(m => m.Code.Trim().ToUpper() == materialDto.Code.Trim().ToUpper()).FirstOrDefault();
            if(materialsAlredyExist != null)
            {
                ModelState.AddModelError("", "Material code already exists");
                return StatusCode(400, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var material = _mapper.Map<Material>(materialDto);
            var qtdStock = materialDto.Qtd;
            if (!_materialRepository.CreateMaterial(qtd, idProduct, idMaterialFather, qtdStock, material))
            {
                ModelState.AddModelError("", "Error when try to create the material");
                return StatusCode(500, ModelState);
            }
            return Ok("Material created successfully");
        }
    }
}
