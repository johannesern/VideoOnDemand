namespace VOD.Common.Services;

public class UserService : IUserService
{
    public readonly FilmsHttpClient _http;
    public UserService(FilmsHttpClient http) => _http = http;

    public async Task<List<FilmDTO>> GetFilmsAsync()
    {
        try
        {            
            using var response = await _http.Client.GetAsync($"films"); //?free={freeOnly}
            response.EnsureSuccessStatusCode();

            var result = JsonSerializer.Deserialize<List<FilmDTO>>(await
            response.Content.ReadAsStreamAsync(), new JsonSerializerOptions
            { PropertyNameCaseInsensitive = true });

            return result ?? new List<FilmDTO>();
        }
        catch
        {
            throw;
        }
    }

    public async Task<FilmDTO> GetFilmAsync(int? id)
    {
        try
        {
            if (id <= 0) return new();

            using var response = await _http.Client.GetAsync($"films/{id}");
            response.EnsureSuccessStatusCode();

            var result = JsonSerializer.Deserialize<FilmDTO>(await
            response.Content.ReadAsStreamAsync(), new JsonSerializerOptions
            { PropertyNameCaseInsensitive = true });

            return result ?? default;
        }
        catch
        {
            throw;
        }
    }
}
