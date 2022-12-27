using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VeterinerKlinik.Models;

public partial class VeterinerKlinikContext : DbContext
{
    public VeterinerKlinikContext()
    {
    }

    public VeterinerKlinikContext(DbContextOptions<VeterinerKlinikContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adres> Adres { get; set; }

    public virtual DbSet<Asistan> Asistan { get; set; }

    public virtual DbSet<Cins> Cin { get; set; }

    public virtual DbSet<HastaNotu> HastaNotu { get; set; }

    public virtual DbSet<Hasta> Hasta { get; set; }

    public virtual DbSet<Il> Il { get; set; }

    public virtual DbSet<Ilce> Ilce { get; set; }

    public virtual DbSet<IletisimBilgileri> IletisimBilgileri { get; set; }

    public virtual DbSet<Klinik> Klinik { get; set; }

    public virtual DbSet<Kullanici> Kullanici { get; set; }

    public virtual DbSet<Mahalle> Mahalle { get; set; }

    public virtual DbSet<Musteri> Musteri { get; set; }

    public virtual DbSet<Randevu> Randevu { get; set; }

    public virtual DbSet<RandevuTipi> RandevuTipi { get; set; }

    public virtual DbSet<Tur> Tur { get; set; }

    public virtual DbSet<Veteriner> Veteriner { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=VeterinerKlinik;Username=postgres;Password=admin");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adres>(entity =>
        {
            entity.HasKey(e => e.AdresNo).HasName("Adres_pkey");

            entity.HasIndex(e => e.MahalleNo, "fki_mahalleFK");

            entity.Property(e => e.AdresNo).HasColumnName("adresNo");
            entity.Property(e => e.Adres)
                .HasMaxLength(100)
                .HasColumnName("adres");
            entity.Property(e => e.MahalleNo).HasColumnName("mahalleNo");

            entity.HasOne(d => d.MahalleNoNavigation).WithMany(p => p.Adres)
                .HasForeignKey(d => d.MahalleNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("mahalleFK");
        });

        modelBuilder.Entity<Asistan>(entity =>
        {
            entity.HasKey(e => e.KisiNo).HasName("Asistan_pkey");

            entity.ToTable("Asistan");

            entity.HasIndex(e => e.VeterinerNo, "fki_veterinerFK");

            entity.Property(e => e.KisiNo)
                .ValueGeneratedNever()
                .HasColumnName("kisiNo");
            entity.Property(e => e.VeterinerNo).HasColumnName("veterinerNo");

            entity.HasOne(d => d.KisiNoNavigation).WithOne(p => p.Asistan)
                .HasForeignKey<Asistan>(d => d.KisiNo)
                .HasConstraintName("Asistan");

            entity.HasOne(d => d.VeterinerNoNavigation).WithMany(p => p.Asistans)
                .HasForeignKey(d => d.VeterinerNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("veterinerFK");
        });

        modelBuilder.Entity<Cins>(entity =>
        {
            entity.HasKey(e => e.CinsNo).HasName("Cins_pkey");

            entity.Property(e => e.CinsNo).HasColumnName("cinsNo");
            entity.Property(e => e.CinsAdi)
                .HasMaxLength(40)
                .HasColumnName("cinsAdi");
            entity.Property(e => e.TurNo).HasColumnName("turNo");
        });

        modelBuilder.Entity<HastaNotu>(entity =>
        {
            entity.HasKey(e => e.Not).HasName("HastaNotu_pkey");

            entity.ToTable("HastaNotu");

            entity.HasIndex(e => e.HastaNo, "fki_hastaNoFK");

            entity.HasIndex(e => e.RandevuNo, "fki_randevuNoFK");

            entity.Property(e => e.Not).HasColumnName("not");
            entity.Property(e => e.HastaNo).HasColumnName("hastaNo");
            entity.Property(e => e.No)
                .ValueGeneratedOnAdd()
                .HasColumnName("no");
            entity.Property(e => e.RandevuNo).HasColumnName("randevuNo");
            entity.Property(e => e.Tarih)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("tarih");

            entity.HasOne(d => d.HastaNoNavigation).WithMany(p => p.HastaNotus)
                .HasForeignKey(d => d.HastaNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hastaNoFK");

            entity.HasOne(d => d.RandevuNoNavigation).WithMany(p => p.HastaNotus)
                .HasForeignKey(d => d.RandevuNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("randevuNoFK");
        });

        modelBuilder.Entity<Hasta>(entity =>
        {
            entity.HasKey(e => e.HastaNo).HasName("Hasta_pkey");

            entity.HasIndex(e => e.Cins, "fki_cinsFK");

            entity.HasIndex(e => e.MusteriNo, "fki_kisiFK");

            entity.Property(e => e.HastaNo).HasColumnName("hastaNo");
            entity.Property(e => e.Adi)
                .HasMaxLength(40)
                .HasColumnName("adi");
            entity.Property(e => e.Aktif)
                .HasDefaultValueSql("true")
                .HasColumnName("aktif");
            entity.Property(e => e.Cins).HasColumnName("cins");
            entity.Property(e => e.DogumYili).HasColumnName("dogumYili");
            entity.Property(e => e.MusteriNo).HasColumnName("musteriNo");
            entity.Property(e => e.Tur).HasColumnName("tur");
            entity.Property(e => e.Yas).HasColumnName("yas");

            entity.HasOne(d => d.CinsNavigation).WithMany(p => p.Hasta)
                .HasForeignKey(d => d.Cins)
                .HasConstraintName("cinsFK");

            entity.HasOne(d => d.MusteriNoNavigation).WithMany(p => p.Hasta)
                .HasForeignKey(d => d.MusteriNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("kisiFK");
        });

        modelBuilder.Entity<Il>(entity =>
        {
            entity.HasKey(e => e.IlNo).HasName("Il_pkey");

            entity.ToTable("Il");

            entity.Property(e => e.IlNo).HasColumnName("ilNo");
            entity.Property(e => e.IlAdi)
                .HasMaxLength(40)
                .HasColumnName("ilAdi");
        });

        modelBuilder.Entity<Ilce>(entity =>
        {
            entity.HasKey(e => e.IlceNo).HasName("Ilce_pkey");

            entity.ToTable("Ilce");

            entity.HasIndex(e => e.IlNo, "fki_ilFK");

            entity.Property(e => e.IlceNo).HasColumnName("ilceNo");
            entity.Property(e => e.IlNo).HasColumnName("ilNo");
            entity.Property(e => e.IlceAdi)
                .HasMaxLength(40)
                .HasColumnName("ilceAdi");

            entity.HasOne(d => d.IlNoNavigation).WithMany(p => p.Ilces)
                .HasForeignKey(d => d.IlNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ilFK");
        });

        modelBuilder.Entity<IletisimBilgileri>(entity =>
        {
            entity.HasKey(e => e.No).HasName("IletisimBilgileri_pkey");

            entity.ToTable("IletisimBilgileri");

            entity.HasIndex(e => e.AdresNo, "fki_adresFk");

            entity.Property(e => e.No).HasColumnName("no");
            entity.Property(e => e.AdresNo).HasColumnName("adresNo");
            entity.Property(e => e.Email)
                .HasMaxLength(254)
                .HasColumnName("email");
            entity.Property(e => e.KisiNo).HasColumnName("kisiNo");
            entity.Property(e => e.TelNo)
                .HasMaxLength(11)
                .HasColumnName("telNo");

            entity.HasOne(d => d.AdresNoNavigation).WithMany(p => p.IletisimBilgileris)
                .HasForeignKey(d => d.AdresNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("adresFk");
        });

        modelBuilder.Entity<Klinik>(entity =>
        {
            entity.HasKey(e => e.KlinikNo).HasName("Klinik_pkey");

            entity.ToTable("Klinik");

            entity.HasIndex(e => e.AdresNo, "fki_adresFK");

            entity.Property(e => e.KlinikNo).HasColumnName("klinikNo");
            entity.Property(e => e.Adi)
                .HasMaxLength(40)
                .HasColumnName("adi");
            entity.Property(e => e.AdresNo).HasColumnName("adresNo");

            entity.HasOne(d => d.AdresNoNavigation).WithMany(p => p.Kliniks)
                .HasForeignKey(d => d.AdresNo)
                .HasConstraintName("adresFK");
        });

        modelBuilder.Entity<Kullanici>(entity =>
        {
            entity.HasKey(e => e.KullaniciNo).HasName("Kullanici_pkey");

            entity.ToTable("Kullanici");

            entity.HasIndex(e => e.KullaniciAdi, "kullanciAdi_Un").IsUnique();

            entity.Property(e => e.KullaniciNo).HasColumnName("kullaniciNo");
            entity.Property(e => e.Adi)
                .HasMaxLength(40)
                .HasColumnName("adi");
            entity.Property(e => e.Aktif)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("aktif");
            entity.Property(e => e.KullaniciAdi)
                .HasMaxLength(60)
                .HasColumnName("kullaniciAdi");
            entity.Property(e => e.Rol)
                .HasMaxLength(40)
                .HasDefaultValueSql("'kullanici'::character varying")
                .HasColumnName("rol");
            entity.Property(e => e.Sifre).HasColumnName("sifre");
            entity.Property(e => e.SoyAdi)
                .HasMaxLength(40)
                .HasColumnName("soyAdi");

            entity.HasMany(d => d.KlinikNos).WithMany(p => p.KullaniciNos)
                .UsingEntity<Dictionary<string, object>>(
                    "KullaniciKlinik",
                    r => r.HasOne<Klinik>().WithMany()
                        .HasForeignKey("KlinikNo")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("klinikNoFK"),
                    l => l.HasOne<Kullanici>().WithMany()
                        .HasForeignKey("KullaniciNo")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("kullaniciNoFK"),
                    j =>
                    {
                        j.HasKey("KullaniciNo", "KlinikNo").HasName("KullaniciKlinik_pkey");
                        j.ToTable("KullaniciKlinik");
                        j.HasIndex(new[] { "KlinikNo" }, "fki_klinikNoFK");
                        j.HasIndex(new[] { "KullaniciNo" }, "fki_kullaniciNoFK");
                    });
        });

        modelBuilder.Entity<Mahalle>(entity =>
        {
            entity.HasKey(e => e.MahalleNo).HasName("Mahalle_pkey");

            entity.ToTable("Mahalle");

            entity.HasIndex(e => e.IlceNo, "fki_ilceFK");

            entity.Property(e => e.MahalleNo).HasColumnName("mahalleNo");
            entity.Property(e => e.IlceNo).HasColumnName("ilceNo");
            entity.Property(e => e.MahalleAdi)
                .HasMaxLength(40)
                .HasColumnName("mahalleAdi");

            entity.HasOne(d => d.IlceNoNavigation).WithMany(p => p.Mahalles)
                .HasForeignKey(d => d.IlceNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ilceFK");
        });

        modelBuilder.Entity<Musteri>(entity =>
        {
            entity.HasKey(e => e.KisiNo).HasName("Musteri_pkey");

            entity.ToTable("Musteri");

            entity.Property(e => e.KisiNo)
                .ValueGeneratedNever()
                .HasColumnName("kisiNo");
            entity.Property(e => e.SigortaNo)
                .HasMaxLength(40)
                .HasColumnName("sigortaNo");

            entity.HasOne(d => d.KisiNoNavigation).WithOne(p => p.Musteri)
                .HasForeignKey<Musteri>(d => d.KisiNo)
                .HasConstraintName("Musteri");
        });

        modelBuilder.Entity<Randevu>(entity =>
        {
            entity.HasKey(e => e.RandevuNo).HasName("Randevu_pkey");

            entity.ToTable("Randevu");

            entity.Property(e => e.RandevuNo).HasColumnName("randevuNo");
            entity.Property(e => e.Durum)
                .HasMaxLength(40)
                .HasDefaultValueSql("'Yeni'::character varying")
                .HasColumnName("durum");
            entity.Property(e => e.HastaNo).HasColumnName("hastaNo");
            entity.Property(e => e.Tarih)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("tarih");
            entity.Property(e => e.VeterinerNo).HasColumnName("veterinerNo");
            entity.Property(e => e.VeterinerNot).HasColumnName("veterinerNot");

            entity.HasOne(d => d.HastaNoNavigation).WithMany(p => p.Randevus)
                .HasForeignKey(d => d.HastaNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hastaFK");

            entity.HasOne(d => d.VeterinerNoNavigation).WithMany(p => p.Randevus)
                .HasForeignKey(d => d.VeterinerNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("kisiFK");
        });

        modelBuilder.Entity<RandevuTipi>(entity =>
        {
            entity.HasKey(e => e.RandevuNo).HasName("RandevuTipi_pkey");

            entity.ToTable("RandevuTipi");

            entity.Property(e => e.RandevuNo).HasColumnName("randevuNo");
            entity.Property(e => e.RandevuTipi1)
                .HasMaxLength(100)
                .HasColumnName("randevuTipi");
        });

        modelBuilder.Entity<Tur>(entity =>
        {
            entity.HasKey(e => e.TurNo).HasName("Tur_pkey");

            entity.ToTable("Tur");

            entity.Property(e => e.TurNo).HasColumnName("turNo");
            entity.Property(e => e.TurAdi)
                .HasColumnType("character varying")
                .HasColumnName("turAdi");
        });

        modelBuilder.Entity<Veteriner>(entity =>
        {
            entity.HasKey(e => e.KisiNo).HasName("Veteriner_pkey");

            entity.ToTable("Veteriner");

            entity.HasIndex(e => e.VekilNo, "fki_vekilNoFK");

            entity.Property(e => e.KisiNo)
                .ValueGeneratedNever()
                .HasColumnName("kisiNo");
            entity.Property(e => e.Unvan)
                .HasMaxLength(40)
                .HasColumnName("unvan");
            entity.Property(e => e.VekilNo).HasColumnName("vekilNo");

            entity.HasOne(d => d.KisiNoNavigation).WithOne(p => p.Veteriner)
                .HasForeignKey<Veteriner>(d => d.KisiNo)
                .HasConstraintName("Veteriner");

            entity.HasOne(d => d.VekilNoNavigation).WithMany(p => p.InverseVekilNoNavigation)
                .HasForeignKey(d => d.VekilNo)
                .HasConstraintName("vekilNoFK");

            entity.HasMany(d => d.HastaNos).WithMany(p => p.VeterinerNos)
                .UsingEntity<Dictionary<string, object>>(
                    "VeterinerHastum",
                    r => r.HasOne<Hasta>().WithMany()
                        .HasForeignKey("HastaNo")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("hastaFK"),
                    l => l.HasOne<Veteriner>().WithMany()
                        .HasForeignKey("VeterinerNo")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("veterinerFK"),
                    j =>
                    {
                        j.HasKey("VeterinerNo", "HastaNo").HasName("VeterinerHasta_pkey");
                        j.HasIndex(new[] { "HastaNo" }, "fki_hastaFK");
                    });
        });
        modelBuilder.HasSequence<int>("Randevu_randevuNo_seq");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
