using mrp.Models;

namespace mrp.Dto
{
    public class ProductCascadeDto : ProductDto
    {
        public ICollection<HierarchyCascadeDto> Hierarchies { get; set; }
    }
}
