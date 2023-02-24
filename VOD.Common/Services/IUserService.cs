namespace VOD.Common.Services
{
    public interface IUserService
    {
        Task<FilmDTO> GetFilmAsync(int? id);
        Task<List<FilmGenreDTO>> GetFilmGenresAsync();
        Task<List<FilmDTO>> GetFilmsAsync();
        Task<List<GenreDTO>> GetGenresAsync();
        Task<List<SimilarFilmsDTO>> GetSimilarAsync();
    }
}