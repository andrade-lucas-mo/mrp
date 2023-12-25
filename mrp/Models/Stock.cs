namespace mrp.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public int Qtd { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; }
    }
}
