using mrp.Models;

namespace mrp.Dto
{
    public class MaterialDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public StockDto Stock { get; set; }
    }
}
