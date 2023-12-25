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
    }
}
