﻿namespace VOD.Films.Database.Entities;

public class SimilarFilm : IReferenceEntity
{
    public int FilmId { get; set; }
    public int SimilarFilmId { get; set; }
    public virtual Film Film { get; set; } = null!;

    [ForeignKey("SimilarFilmId")]
    public virtual Film Similar { get; set; } = null!;

}
