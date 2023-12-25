using mrp.Models;

namespace mrp.Interfaces
{
    public interface IMaterialRepository
    {
        ICollection<Material> GetAll();
        bool HasAny(int id);
    }
}
