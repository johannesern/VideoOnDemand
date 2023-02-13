using System.Collections.Generic;
using VOD.Common.DTOs;
using VOD.Films.Database.Entities;

namespace VOD.Films.Database.Contexts;

public class VODContext : DbContext
{
    public DbSet<Film> Films => Set<Film>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<Director> Directors => Set<Director>();
    public DbSet<FilmGenre> FilmGenre => Set<FilmGenre>();
    public DbSet<SimilarFilm> SimilarFilms => Set<SimilarFilm>();

    public VODContext(DbContextOptions<VODContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<FilmGenre>().HasKey(fg => new { fg.FilmId, fg.GenreId });
        builder.Entity<SimilarFilm>().HasKey(sf => new { sf.FilmId, sf.SimilarFilmId });

        builder.Entity<Director>(entity =>
        {
            entity
            .HasMany(f => f.Films)
            .WithOne(d => d.Director)
            .OnDelete(DeleteBehavior.ClientSetNull);
        });

        builder.Entity<Genre>(entity =>
        {
            entity
            .HasMany(f => f.Films)
            .WithMany(g => g.Genres)
            .UsingEntity<FilmGenre>()
            .ToTable("FilmGenre");
        });

        builder.Entity<Film>(entity =>
        {
            entity
            .HasMany(sf => sf.SimilarFilms)
            .WithOne(f => f.Film)
            .HasForeignKey(d => d.FilmId)/*SimilarFilmId*/
            .OnDelete(DeleteBehavior.ClientSetNull);

            entity
            .HasMany(g => g.Genres)
            .WithMany(f => f.Films)
            .UsingEntity<FilmGenre>()
            .ToTable("FilmGenre");
        });

        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e
            => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
