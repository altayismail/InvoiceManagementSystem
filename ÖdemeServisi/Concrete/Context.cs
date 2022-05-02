using Microsoft.EntityFrameworkCore;
using ÖdemeServisi.Entities;

namespace ÖdemeServisi.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=ISMAILALTAY; database=OdemeServisiDB; integrated security=true;");
        }

        public DbSet<BankaHesap> BankaHesapları { get; set; }
        public DbSet<KrediKartı> KrediKartları { get; set; }
        public DbSet<Odeme> Odemeler { get; set; }
    }
}
