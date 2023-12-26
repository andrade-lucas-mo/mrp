using AutoMapper;
using mrp.Dto;
using mrp.Models;

namespace mrp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Material, MaterialDto>()
                .ForMember(dest => dest.Qtd, opt => opt.Ignore())
                .AfterMap((src, dest) => {
                    dest.Qtd = src.Stock.Qtd;
                })
                .ReverseMap()
                .ForMember(dest => dest.Stock, opt => opt.Ignore());
            CreateMap<Stock, StockDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, ProductCascadeDto>()
                .ForMember(dest => dest.Hierarchies, opt => opt.Ignore())
                .AfterMap((src, dest) => {
                    dest.Hierarchies = GetHierarchyCascades(src.Hierarchies);
                });
            CreateMap<Hierarchy, HierarchyDto>();
        }

        public ICollection<HierarchyCascadeDto> GetHierarchyCascades(ICollection<HierarchyDto> hierarchies)
        {
            var cascadeDict = hierarchies.ToDictionary(
                h => h.MaterialId,
                h => new HierarchyCascadeDto
                {
                    Qtd = h.Qtd,
                    MaterialId = h.MaterialId,
                    Level = h.Level,
                    Material = h.Material,
                    Hierarchies = new List<HierarchyCascadeDto>()
                }
            );

            var topLevelHierarchies = new List<HierarchyCascadeDto>();

            foreach (var dto in hierarchies)
            {
                if (dto.MateriaFatherlId.HasValue)
                {
                    var parentDto = cascadeDict[dto.MateriaFatherlId.Value];
                    parentDto.Hierarchies.Add(cascadeDict[dto.MaterialId]);
                }
                else
                {
                    topLevelHierarchies.Add(cascadeDict[dto.MaterialId]);
                }
            }

            return topLevelHierarchies;
        }
    }
}
