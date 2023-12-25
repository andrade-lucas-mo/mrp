using mrp.Models;

namespace mrp.Dto
{
    public class HierarchyCascadeDto
    {
        public int Qtd { get; set; }
        public int MaterialId { get; set; }
        public int Level { get; set; }
        public MaterialDto Material { get; set; }
        public List<HierarchyCascadeDto> Hierarchies { get; set; } = new List<HierarchyCascadeDto>();
    }
}
