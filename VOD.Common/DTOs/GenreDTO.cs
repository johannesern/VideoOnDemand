namespace VOD.Common.DTOs;

public class GenreDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<FilmGenreDTO>? FilmGenres { get; set; }
}
