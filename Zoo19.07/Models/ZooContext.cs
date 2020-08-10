using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Zoo.Models
{
    public partial class ZooContext : DbContext
    {
        public ZooContext()
        {
        }

        public ZooContext(DbContextOptions<ZooContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<Individ> Individ { get; set; }
        public virtual DbSet<Main> Main { get; set; }
        public virtual DbSet<MainIstoric> MainIstoric { get; set; }
        public virtual DbSet<PozaIndivid> PozaIndivid { get; set; }
        public virtual DbSet<ZooInfo> ZooInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:diana-maria-andra.database.windows.net,1433;Initial Catalog=Zoo;Persist Security Info=False;User ID=diana-maria-andra;Password=U)v=9`+8S='=<Rj*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.NumeComun)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Specie)
                    .HasMaxLength(128)
                    .IsFixedLength();

                entity.Property(e => e.GreutateMaxima)
                    .HasColumnName("GreutateMaxima");

                entity.Property(e => e.Poza).HasMaxLength(1000)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Individ>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bio)
                    .HasMaxLength(1000)
                    .IsFixedLength();

                entity.Property(e => e.Idanimal).HasColumnName("IDAnimal");

                entity.Property(e => e.Nume)
                    .HasMaxLength(128)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Main>(entity =>
            {
                entity.HasKey(e => e.Ancora);

                entity.Property(e => e.Ancora)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Idindivid).HasColumnName("IDindivid");

                entity.Property(e => e.Idzoo).HasColumnName("IDZoo");
            });

            modelBuilder.Entity<MainIstoric>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Ancora).HasMaxLength(50);

                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.Idindivid).HasColumnName("IDIndivid");

                entity.Property(e => e.Idzoo).HasColumnName("IDZoo");
            });

            modelBuilder.Entity<PozaIndivid>(entity =>
            {
                entity.HasKey(e => e.Idindivid);

                entity.Property(e => e.Idindivid)
                    .HasColumnName("IDIndivid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descriere)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Poza1).HasMaxLength(1000)
                    .IsFixedLength();

                entity.Property(e => e.Poza10).HasMaxLength(1000)
                    .IsFixedLength();

                entity.Property(e => e.Poza2).HasMaxLength(1000)
                    .IsFixedLength();

                entity.Property(e => e.Poza3).HasMaxLength(1000)
                    .IsFixedLength();

                entity.Property(e => e.Poza4).HasMaxLength(1000)
                    .IsFixedLength();

                entity.Property(e => e.Poza5).HasMaxLength(1000)
                    .IsFixedLength();

                entity.Property(e => e.Poza6).HasMaxLength(1000)
                    .IsFixedLength();

                entity.Property(e => e.Poza7).HasMaxLength(1000)
                    .IsFixedLength();

                entity.Property(e => e.Poza8).HasMaxLength(1000)
                    .IsFixedLength();

                entity.Property(e => e.Poza9).HasMaxLength(1000)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ZooInfo>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Detalii)
                    .HasMaxLength(1000)
                    .IsFixedLength();

                entity.Property(e => e.Nume)
                    .HasMaxLength(128)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
