namespace mrp.Models
{
    public class Material
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Stock Stock { get; set; }
        public ICollection<Need> Needs { get; set; }
        public ICollection<Transit> Transits { get; set; }
        public ICollection<Hierarchy> Hierarchies { get; set; }

    }
}
