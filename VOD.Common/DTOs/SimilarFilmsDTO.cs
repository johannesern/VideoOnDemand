namespace VOD.Common.DTOs;

public class SimilarFilmsDTO
{
    public int FilmId { get; set; }
    public int SimilarFilmId { get; set; }

	[ForeignKey("SimilarFilmId")]
	public virtual FilmDTO? Similar { get; set; }
}

public class SimilarFilmsCreateDTO
{
	public int FilmId { get; set; }
	public int SimilarFilmId { get; set; }
	
}
