namespace VOD.Common.Services
{
    public interface IUserService
    {
        Task<FilmDTO> GetFilmAsync(int? id);
        Task<List<FilmDTO>> GetFilmsAsync();
    }
}