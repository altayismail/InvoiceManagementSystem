using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=ISMAILALTAY; database=FaturaYonetimDB; integrated security=true;");
        }

        public DbSet<Aidat> Aidatlar { get; set; }
        public DbSet<Daire> Daireler { get; set; }
        public DbSet<Fatura> Faturalar { get; set; }
        public DbSet<Kullanıcı> Kullanıcılar { get; set; }
        public DbSet<Mesaj> Mesajlar { get; set; }
        public DbSet<Yonetici> Yoneticiler { get; set; }
        public DbSet<Iletisim> Iletisim { get; set; }
    }
}
