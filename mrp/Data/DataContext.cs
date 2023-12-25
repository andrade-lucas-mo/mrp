using Microsoft.EntityFrameworkCore;
using mrp.Models;

namespace mrp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Hierarchy> Hierarchies { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Need> Needs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Transit> Transits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Garantir unicidade em cada registro, de forma que a concatenação entre os identificadores de Produto e Material sejam únicas
            modelBuilder.Entity<Hierarchy>()
                .HasKey(h => new { h.ProductId, h.MaterialId });

            // Identifica a relação de que um produto possui muitas hierarquias, garantindo OneToMany
            modelBuilder.Entity<Hierarchy>()
                .HasOne(p => p.Product)
                .WithMany(h => h.Hierarchies)
                .HasForeignKey(p => p.ProductId);

            // Identifica a relação de que um material possui muitas hierarquias, garantindo OneToMany
            modelBuilder.Entity<Hierarchy>()
                .HasOne(m => m.Material)
                .WithMany(h => h.Hierarchies)
                .HasForeignKey(m => m.MaterialId);

            // Identifica a relação de que um material possui muitas hierarquias, garantindo OneToMany
            modelBuilder.Entity<Hierarchy>()
                .HasOne(m => m.MaterialFather)
                .WithMany() // Material Father não possui uma coleção de hierarquias
                .HasForeignKey(m => m.MateriaFatherlId)
                .OnDelete(DeleteBehavior.Restrict); // impedir deleção em cascata

            //Identificação da FK na relação OneToOne Material e Stock
            modelBuilder.Entity<Stock>()
                .HasOne(s => s.Material)
                .WithOne(m => m.Stock)
                .HasForeignKey<Stock>(s => s.MaterialId);
        }
    }
}
