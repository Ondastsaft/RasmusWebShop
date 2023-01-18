using Microsoft.EntityFrameworkCore;

namespace RasmusAB.Models
{
    public class RasmusABContext : DbContext
    {
        public DbSet<Användare> Användare { get; set; }
        //public DbSet<Kund> Kunder { get; set; }
        //public DbSet<Admin> Administratörer { get; set; }
        public DbSet<Varukorg> Varukorgar { get; set; }
        public DbSet<Order> Ordrar { get; set; }
        public DbSet<Produkt> Produkter { get; set; }
        public DbSet<Kategori> Kategorier { get; set; }
        public DbSet<Varukorgsprodukt> Varukorgsprodukts { get; set; }
        public DbSet<Leverantör> Leverantörer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = tcp:rasmusab.database.windows.net, 1433; Initial Catalog = DBRasmusABWebshop; Persist Security Info = False; User ID = RasmusABGrupp7; Password =Admin123; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Användare>().HasOne(a => a.Varukorg).WithOne(v => v.Användare).HasForeignKey<Varukorg>(v => v.AnvändarId);
            modelBuilder.Entity<Order>().HasOne(l => l.Leverantör).WithMany(o => o.Orders).HasForeignKey(l => l.LeverantörsId);
            modelBuilder.Entity<Order>().HasOne(v => v.Varukorg).WithOne(o => o.Order).HasForeignKey<Varukorg>(v => v.OrderId);
            modelBuilder.Entity<Leverantör>().HasMany(o => o.Orders).WithOne(l => l.Leverantör).HasForeignKey(o => o.LeverantörsId);
            modelBuilder.Entity<Varukorg>().HasOne(o => o.Order).WithOne(v => v.Varukorg).HasForeignKey<Order>(o => o.VarukorgsId);
        }

    }
}
