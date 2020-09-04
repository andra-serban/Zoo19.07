using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Zoo19._07.Models
{
    public partial class zoodatabaseContext : DbContext
    {
        public zoodatabaseContext()
        {
        }

        public zoodatabaseContext(DbContextOptions<zoodatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<Individ> Individ { get; set; }
        public virtual DbSet<IndividImages> IndividImages { get; set; }
        public virtual DbSet<Main> Main { get; set; }
        public virtual DbSet<MainHistory> MainHistory { get; set; }
        public virtual DbSet<ZooInfo> ZooInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:zoo-server.database.windows.net,1433;Initial Catalog=zoo-database;Persist Security Info=False;User ID=andra-maria-diana;Password=e^X.jpE^>54f?TWf;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CommonName).IsRequired();

                entity.Property(e => e.Image).IsRequired();

                entity.Property(e => e.Specie).IsRequired();
            });

            modelBuilder.Entity<Individ>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bio).IsRequired();

                entity.Property(e => e.Idanimal).HasColumnName("IDAnimal");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Individ)
                    .HasForeignKey<Individ>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Individ_IndividImages");

                entity.HasOne(d => d.IdanimalNavigation)
                    .WithMany(p => p.Individ)
                    .HasForeignKey(d => d.Idanimal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Individ_Animal");
            });

            modelBuilder.Entity<IndividImages>(entity =>
            {
                entity.HasKey(e => e.Idindivid);

                entity.Property(e => e.Idindivid)
                    .HasColumnName("IDIndivid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).IsRequired();
            });

            modelBuilder.Entity<Main>(entity =>
            {
                entity.HasKey(e => e.Anchor);

                entity.Property(e => e.Anchor).HasMaxLength(100);

                entity.Property(e => e.Idindivid).HasColumnName("IDIndivid");

                entity.Property(e => e.Idzoo).HasColumnName("IDZoo");

                entity.HasOne(d => d.Idindiv)
                    .WithMany(p => p.Main)
                    .HasForeignKey(d => d.Idindivid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Main_Individ");

                entity.HasOne(d => d.IdzooNavigation)
                    .WithMany(p => p.Main)
                    .HasForeignKey(d => d.Idzoo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Main_ZooInfo");
            });

            modelBuilder.Entity<MainHistory>(entity =>
            {
                entity.HasKey(e => e.Anchor);

                entity.Property(e => e.Anchor).HasMaxLength(100);

                entity.Property(e => e.Data).IsRequired();

                entity.Property(e => e.Idindivid).HasColumnName("IDIndivid");

                entity.Property(e => e.Idzoo).HasColumnName("IDZoo");

                entity.HasOne(d => d.Idindiv)
                    .WithMany(p => p.MainHistory)
                    .HasForeignKey(d => d.Idindivid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MainHistory_Individ");

                entity.HasOne(d => d.IdzooNavigation)
                    .WithMany(p => p.MainHistory)
                    .HasForeignKey(d => d.Idzoo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MainHistory_ZooInfo");
            });

            modelBuilder.Entity<ZooInfo>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Details).IsRequired();

                entity.Property(e => e.Name).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
