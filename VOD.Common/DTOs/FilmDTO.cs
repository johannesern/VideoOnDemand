namespace VOD.Common.DTOs;

public class FilmDTO
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public DateTime? Released { get; set; }
    public int? DirectorId { get; set; }
    public string? Director { get; set; }
    public string? ThumbnailURL { get; set; }
    public string? Description { get; set; }
    public string? FilmUrl { get; set; }
    public bool Free { get; set; }
    public List<FilmGenreDTO>? FilmGenres { get; set; }
}

public class FilmCreateDTO : FilmDTO
{
    public string? Title { get; set; }
    public DateTime? Released { get; set; }
    public string? ThumbnailURL { get; set; }
    public string? Description { get; set; }
    public string? FilmUrl { get; set; }
    public bool Free { get; set; }
}

public class FilmEditDTO : FilmDTO
{
    public string? Title { get; set; }
    public DateTime? Released { get; set; }
    public string? ThumbnailURL { get; set; }
    public string? Description { get; set; }
    public string? FilmUrl { get; set; }
    public bool Free { get; set; }
}


