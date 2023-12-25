namespace mrp.Models
{
    public class Need
    {
        public int Id { get; set; }
        public int Qtd { get; set; }
        public DateTime DoDate { get; set; }
        public Material Material { get; set; }
    }
}
