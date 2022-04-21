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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mesaj>()
                .HasOne(x => x.MesajYollayan)
                .WithMany(x => x.KullanıcıMesajGönder)
                .HasForeignKey(x => x.MesajYollayanId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Mesaj>()
                .HasOne(x => x.MesajAlan)
                .WithMany(x => x.YoneticiMesajAl)
                .HasForeignKey(x => x.MesajAlanId)
                .OnDelete(DeleteBehavior.ClientSetNull);
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
