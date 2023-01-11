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



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = tcp:rasmusab.database.windows.net, 1433; Initial Catalog = DBRasmusABWebshop; Persist Security Info = False; User ID = RasmusABGrupp7; Password =Admin123; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
        }
    }
}
