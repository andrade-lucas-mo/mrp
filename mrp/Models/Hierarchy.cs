using mrp.Models;

namespace mrp.Models
{
    public class Hierarchy
    {
        public int Qtd { get; set; }
        public int MaterialId { get; set; }
        public int? MateriaFatherlId { get; set; }
        public int ProductId { get; set; }
        public int Level { get; set; }
        public Material Material { get; set; }
        public Material MaterialFather { get; set; }
        public Product Product { get; set; }
    }
}