namespace VOD.Common.DTOs;

public class FilmGenreDTO
{
    public int FilmId { get; set; }
    public int GenreId { get; set; }
    public virtual FilmDTO? Film { get; set; } 
    public virtual GenreDTO? Genre { get; set; }
}
