namespace VOD.Common.DTOs;

public class FilmDTO
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Released { get; set; }
    public int? DirectorId { get; set; }
    public string? Director { get; set; }
    public string? ThumbnailURL { get; set; }
    public string? Description { get; set; }
    public string? FilmUrl { get; set; }
    public bool Free { get; set; }
	public List<string>? Genres { get; set; }
	public List<string>? Similar { get; set; }
}

public class FilmCreateDTO
{
    public string? Title { get; set; }
    public string? Released { get; set; }
	public string? ThumbnailURL { get; set; }
    public string? Description { get; set; }
    public string? FilmUrl { get; set; }
    public bool Free { get; set; }
    public FilmGenreDTO? FilmGenre { get; set; }
}

public class FilmEditDTO : FilmCreateDTO
{
	public int? Id { get; set; }
    public int? DirectorId { get; set; }
}
