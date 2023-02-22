namespace VOD.Films.Database.Entities;
public class Film : IEntity
{
    public Film()
    {
        SimilarFilms = new HashSet<SimilarFilm>();
        Genres = new HashSet<Genre>();
    }

    public int Id { get; set; }
    [MaxLength(50), Required]
    public string Title { get; set; }
    public string? Released { get; set; }
    public int? DirectorId { get; set; }
    [MaxLength(1024)]
    public string? ThumbnailURL { get; set; }
    [MaxLength(1024)]
    public string? BackgroundURL { get; set; }
    [MaxLength(200)]
    public string? Description { get; set; }
    [MaxLength(1024)]
    public string? FilmUrl { get; set; }
    public bool Free { get; set; }

    public virtual Director? Director { get; set; }
    public virtual ICollection<Genre>? Genres { get; set; }
    public virtual ICollection<SimilarFilm>? SimilarFilms { get; set; }

}
