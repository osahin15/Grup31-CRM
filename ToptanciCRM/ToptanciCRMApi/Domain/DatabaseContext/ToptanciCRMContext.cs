using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ToptanciCRMApi.Domain
{
    public partial class ToptanciCRMContext : DbContext
    {
        public ToptanciCRMContext()
        {
        }

        public ToptanciCRMContext(DbContextOptions<ToptanciCRMContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Bayi> Bayi { get; set; }
        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<Siparis> Siparis { get; set; }
        public virtual DbSet<SiparisDetay> SiparisDetay { get; set; }
        public virtual DbSet<Toptanci> Toptanci { get; set; }
        public virtual DbSet<Urun> Urun { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bayi>(entity =>
            {
                entity.Property(e => e.BayiId).HasColumnName("BayiID");

                entity.Property(e => e.BayiAd).HasMaxLength(50);

                entity.Property(e => e.BayiAdres).HasMaxLength(250);

                entity.Property(e => e.BayiMail).HasMaxLength(50);
            });

            modelBuilder.Entity<Kategori>(entity =>
            {
                entity.Property(e => e.KategoriId).HasColumnName("KategoriID");

                entity.Property(e => e.KategoriAd).HasMaxLength(50);
            });

            modelBuilder.Entity<Kullanici>(entity =>
            {
                entity.Property(e => e.KullaniciId).HasColumnName("KullaniciID");

                entity.Property(e => e.Ad).HasMaxLength(20);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RefreshToken).HasMaxLength(500);

                entity.Property(e => e.RefreshTokenEndDate).HasColumnType("datetime");

                entity.Property(e => e.Sifre).HasMaxLength(8);

                entity.Property(e => e.Soyad).HasMaxLength(20);
            });

            modelBuilder.Entity<Siparis>(entity =>
            {
                entity.Property(e => e.SiparisId).HasColumnName("SiparisID");

                entity.Property(e => e.BayiId).HasColumnName("BayiID");

                //entity.Property(e => e.SiparisDetayId).HasColumnName("SiparisDetayID");

                entity.Property(e => e.SiparisTarih).HasColumnType("datetime");

                entity.Property(e => e.ToptanciId).HasColumnName("ToptanciID");
            });

            modelBuilder.Entity<SiparisDetay>(entity =>
            {
                entity.Property(e => e.SiparisDetayId).HasColumnName("SiparisDetayID");

                entity.Property(e => e.UrunId).HasColumnName("UrunID");

                entity.Property(e => e.Adet).HasColumnName("Adet");               

                entity.Property(e => e.SiparisId).HasColumnName("SiparisID");
            });

            modelBuilder.Entity<Toptanci>(entity =>
            {
                entity.Property(e => e.ToptanciId).HasColumnName("ToptanciID");

                entity.Property(e => e.ToptanciAd).HasMaxLength(50);
            });

            modelBuilder.Entity<Urun>(entity =>
            {
                entity.Property(e => e.UrunId).HasColumnName("UrunID");

                entity.Property(e => e.KategoriId).HasColumnName("KategoriID");

                entity.Property(e => e.UrunAd).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
