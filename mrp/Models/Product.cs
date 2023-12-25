namespace mrp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public ICollection<Hierarchy> Hierarchies { get; set; }
    }
}
