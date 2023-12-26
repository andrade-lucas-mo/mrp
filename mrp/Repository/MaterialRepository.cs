using Microsoft.EntityFrameworkCore;
using mrp.Data;
using mrp.Interfaces;
using mrp.Models;

namespace mrp.Repository
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly DataContext _context;

        public MaterialRepository(DataContext context)
        { 
            _context = context;
        }

        public ICollection<Material> GetAll()
        {
            return _context.Materials.Include(m => m.Stock).OrderBy(m => m.Name).ToList();
        }

        public bool HasAny(int id)
        {
            return _context.Materials.Any(m => m.Id == id);
        }

        public bool CreateMaterial(int qtd, int idProduct, int idMaterialFather, int qtdStock, Material material)
        {
            var product = _context.Products.Include(p => p.Hierarchies).Where(p => p.Id == idProduct).FirstOrDefault();
            var newStock = new Stock()
            {
                Qtd = qtdStock,
                Material = material
            };

            var materialFather = _context.Materials.Where(m => m.Id == idMaterialFather).FirstOrDefault();
            var level = 1;
            if(materialFather != null)
            {
                var productHierarchies = product.Hierarchies.Where(h => h.MaterialId == materialFather.Id).FirstOrDefault();
                level = productHierarchies.Level + 1;
            }
            var newHierarchy = new Hierarchy()
            {
                Material = material,
                Product = product,
                MaterialFather = materialFather,
                Qtd = qtd,
                Level = level
            };

            _context.Add(newStock);

            _context.Add(newHierarchy);

            _context.Add(material);

            return Save();
        }

        public bool DeleteMaterial(int id)
        {
            Material material = _context.Materials.Where(m => m.Id == id).FirstOrDefault();
            _context.Remove(material);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}
