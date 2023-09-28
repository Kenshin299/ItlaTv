using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Contexts
{
    public class ItlaTvDbContext : DbContext
    {
        public ItlaTvDbContext(DbContextOptions<ItlaTvDbContext> options) : base(options)
        {
        }

        public DbSet<Series> Series { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<SeriesGenre> SeriesGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Tablas
            modelBuilder.Entity<Series>().ToTable("Series");
            modelBuilder.Entity<Genre>().ToTable("Genres");
            modelBuilder.Entity<Producer>().ToTable("Producers");
            #endregion

            #region Primary Keys
            modelBuilder.Entity<Series>().HasKey(series => series.Id);
            modelBuilder.Entity<Genre>().HasKey(genre => genre.Id);
            modelBuilder.Entity<Producer>().HasKey(producer => producer.Id);
            #endregion

            #region Relaciones
            modelBuilder.Entity<SeriesGenre>()
                .HasKey(sg => new { sg.SeriesId, sg.GenreId });

            modelBuilder.Entity<SeriesGenre>()
                .HasOne(sg => sg.Series)
                .WithMany(s => s.SeriesGenres)
                .HasForeignKey(sg => sg.SeriesId);

            modelBuilder.Entity<SeriesGenre>()
                .HasOne(sg => sg.Genre)
                .WithMany(g => g.SeriesGenres)
                .HasForeignKey(sg => sg.GenreId);
            #endregion

            #region Propiedades
            modelBuilder.Entity<Series>()
                .Property(series => series.Name)
                .IsRequired();

            modelBuilder.Entity<Genre>()
                .Property(genre => genre.Name)
                .IsRequired()
                .HasMaxLength(150);

            modelBuilder.Entity<Producer>()
                .Property(producer => producer.Name)
                .IsRequired();
            #endregion
        }
    }
}