using Microsoft.EntityFrameworkCore;
using mrp.Data;
using mrp.Dto;
using mrp.Interfaces;
using mrp.Models;

namespace mrp.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }
        public Product Get(int id)
        {
            return _context.Products
                .Include(p => p.Hierarchies)
                    .ThenInclude(h => h.Material)
                        .ThenInclude(m => m.Stock)
                .Include(p => p.Hierarchies)
                    .ThenInclude(h => h.MaterialFather)
                        .ThenInclude(m => m.Stock)
                .Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Product> GetAll()
        {
            return _context.Products.Include(p => p.Hierarchies).OrderBy(p => p.Name).ToList();
        }
        public bool HasAny(int id)
        {
            return _context.Products.Any(p => p.Id == id);
        }
    }
}
