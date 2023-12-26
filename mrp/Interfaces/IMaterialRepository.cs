using mrp.Models;

namespace mrp.Interfaces
{
    public interface IMaterialRepository
    {
        ICollection<Material> GetAll();
        bool HasAny(int id);
        bool CreateMaterial(int qtd, int idProduct, int idMaterialFather, int qtdStock, Material material);
        bool DeleteMaterial(int id);
        bool Save();
    }
}
