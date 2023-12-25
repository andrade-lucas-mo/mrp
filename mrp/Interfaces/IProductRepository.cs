using mrp.Dto;
using mrp.Models;

namespace mrp.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetAll();
        Product Get(int id);
        bool HasAny(int id);
    }
}
