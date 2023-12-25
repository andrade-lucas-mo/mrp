using mrp.Models;

namespace mrp.Dto
{
    public class HierarchyDto
    {
        public int Qtd { get; set; }
        public int MaterialId { get; set; }
        public int? MateriaFatherlId { get; set; }
        public int Level { get; set; }
        public MaterialDto Material { get; set; }
        public MaterialDto MaterialFather { get; set; }
    }
}
