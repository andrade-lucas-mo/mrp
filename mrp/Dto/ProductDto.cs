using mrp.Models;

namespace mrp.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public ICollection<HierarchyDto> Hierarchies { get; set; }
    }
}
