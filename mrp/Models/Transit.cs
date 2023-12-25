namespace mrp.Models
{
    public class Transit
    {
        public int Id { get; set; }
        public int Qtd { get; set; }
        public string Supplier { get; set; }
        public DateTime DoDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public Material Material { get; set; }
    }
}
