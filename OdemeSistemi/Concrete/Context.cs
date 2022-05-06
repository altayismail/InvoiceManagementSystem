using Microsoft.EntityFrameworkCore;
using OdemeSistemi.Entities;

namespace OdemeSistemi.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=ISMAILALTAY; database=OdemeSistemiDB; integrated security=true;");
        }

        public DbSet<KrediKartı> KrediKartları { get; set; }
        public DbSet<Odeme> Odemeler { get; set; }
        public DbSet<BankaHesabı> BankaHesapları { get; set; }
    }
}
