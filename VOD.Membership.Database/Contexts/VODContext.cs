namespace VOD.Films.Database.Contexts;

public class VODContext : DbContext
{
    public DbSet<Film> Films => Set<Film>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<Director> Directors => Set<Director>();
    public DbSet<FilmGenre> FilmGenres => Set<FilmGenre>();
    public DbSet<SimilarFilm> SimilarFilms => Set<SimilarFilm>();

    public VODContext(DbContextOptions<VODContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<FilmGenre>().HasKey(fg => new { fg.FilmId, fg.GenreId });
        builder.Entity<SimilarFilm>().HasKey(sf => new { sf.FilmId, sf.SimilarFilmId });
        
        builder.Entity<Film>(entity =>
        {
            entity
            .HasMany(sf => sf.SimilarFilms)
            .WithOne(f => f.Film)
            .HasForeignKey(d => d.FilmId)
            .OnDelete(DeleteBehavior.Cascade);

            entity
            .HasMany(g => g.Genres)
            .WithMany(f => f.Films)
            .UsingEntity<FilmGenre>()
            .ToTable("FilmGenres");
        });        
    }
}
