using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Esoft
{
    public partial class esoftContext : DbContext
    {
        public esoftContext()
        {
        }

        public esoftContext(DbContextOptions<esoftContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<Apartments> Apartments { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Coordinates> Coordinates { get; set; }
        public virtual DbSet<Deal> Deal { get; set; }
        public virtual DbSet<Houses> Houses { get; set; }
        public virtual DbSet<LandPlots> LandPlots { get; set; }
        public virtual DbSet<Needs> Needs { get; set; }
        public virtual DbSet<Realtors> Realtors { get; set; }
        public virtual DbSet<Sentence> Sentence { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=ASUSBAR\\SQLEXPRESS;initial catalog=esoft;integrated security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.Property(e => e.ApartmentNumber).HasDefaultValueSql("('')");

                entity.Property(e => e.City).HasDefaultValueSql("('')");

                entity.Property(e => e.HouseNumber).HasDefaultValueSql("('')");

                entity.Property(e => e.Street).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Apartments>(entity =>
            {
                entity.Property(e => e.Floor).HasDefaultValueSql("((0))");

                entity.Property(e => e.RoomCount).HasDefaultValueSql("((0))");

                entity.Property(e => e.Square).HasDefaultValueSql("((0))");

                entity.Property(e => e.State).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Apartments)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__Apartment__Addre__2BFE89A6");

                entity.HasOne(d => d.Coord)
                    .WithMany(p => p.Apartments)
                    .HasForeignKey(d => d.CoordId)
                    .HasConstraintName("FK__Apartment__Coord__2CF2ADDF");
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.Property(e => e.ClientState)
                    .HasColumnName("client_state")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Coordinates>(entity =>
            {
                entity.Property(e => e.Latitude).HasDefaultValueSql("((0))");

                entity.Property(e => e.Longitude).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Deal>(entity =>
            {
                entity.HasOne(d => d.Needs)
                    .WithMany(p => p.Deal)
                    .HasForeignKey(d => d.NeedsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Deal__NeedsId__7AF13DF7");

                entity.HasOne(d => d.Sentence)
                    .WithMany(p => p.Deal)
                    .HasForeignKey(d => d.SentenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Deal__SentenceId__7BE56230");
            });

            modelBuilder.Entity<Houses>(entity =>
            {
                entity.Property(e => e.FloorCount).HasDefaultValueSql("((0))");

                entity.Property(e => e.RoomCount).HasDefaultValueSql("((0))");

                entity.Property(e => e.Square).HasDefaultValueSql("((0))");

                entity.Property(e => e.State).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Adress)
                    .WithMany(p => p.Houses)
                    .HasForeignKey(d => d.AdressId)
                    .HasConstraintName("FK__Houses__AdressId__1F98B2C1");

                entity.HasOne(d => d.Coord)
                    .WithMany(p => p.Houses)
                    .HasForeignKey(d => d.CoordId)
                    .HasConstraintName("FK__Houses__CoordId__208CD6FA");
            });

            modelBuilder.Entity<LandPlots>(entity =>
            {
                entity.Property(e => e.Square).HasDefaultValueSql("((0))");

                entity.Property(e => e.State).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.LandPlots)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__LandPlots__Addre__30C33EC3");

                entity.HasOne(d => d.Coord)
                    .WithMany(p => p.LandPlots)
                    .HasForeignKey(d => d.CoordId)
                    .HasConstraintName("FK__LandPlots__Coord__31B762FC");
            });

            modelBuilder.Entity<Needs>(entity =>
            {
                entity.Property(e => e.State).HasDefaultValueSql("((0))");

                entity.Property(e => e.TypeOfProperty)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Adress)
                    .WithMany(p => p.Needs)
                    .HasForeignKey(d => d.AdressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Needs__AdressId__69C6B1F5");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Needs)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Needs__ClientId__67DE6983");

                entity.HasOne(d => d.Realtor)
                    .WithMany(p => p.Needs)
                    .HasForeignKey(d => d.RealtorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Needs__RealtorId__68D28DBC");
            });

            modelBuilder.Entity<Realtors>(entity =>
            {
                entity.Property(e => e.ClientState)
                    .HasColumnName("client_state")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Sentence>(entity =>
            {
                entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.State).HasDefaultValueSql("((0))");

                entity.Property(e => e.TypeOfProperty)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Apart)
                    .WithMany(p => p.Sentence)
                    .HasForeignKey(d => d.ApartId)
                    .HasConstraintName("FK__Sentence__ApartI__3335971A");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Sentence)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__Sentence__Client__671F4F74");

                entity.HasOne(d => d.House)
                    .WithMany(p => p.Sentence)
                    .HasForeignKey(d => d.HouseId)
                    .HasConstraintName("FK__Sentence__HouseI__324172E1");

                entity.HasOne(d => d.Plot)
                    .WithMany(p => p.Sentence)
                    .HasForeignKey(d => d.PlotId)
                    .HasConstraintName("FK__Sentence__PlotId__3429BB53");

                entity.HasOne(d => d.Realtor)
                    .WithMany(p => p.Sentence)
                    .HasForeignKey(d => d.RealtorId)
                    .HasConstraintName("FK__Sentence__Realto__681373AD");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
