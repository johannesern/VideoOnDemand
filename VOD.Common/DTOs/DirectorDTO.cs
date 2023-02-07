namespace VOD.Common.DTOs;

public class DirectorDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<FilmDTO>? Films { get; set; }
}

public class DirectorCreateDTO : DirectorDTO
{
    public string? Name { get; set; }
}

public class DirectorEditDTO : DirectorDTO
{
    public string? Name { get; set; }
    public List<FilmDTO>? Films { get; set; }
}
